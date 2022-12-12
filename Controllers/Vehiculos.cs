using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using Newtonsoft.Json;

using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Controllers
{

    internal class Vehiculos
    {
        
        public string ApiKey = "AIzaSyD7ZTFhFn6-2UvEyzIrfI3W55BZWCqKy5M";
        FirebaseClient cliente = new FirebaseClient("https://parcial2automovil-default-rtdb.firebaseio.com/");

        public string currentImage { get; set; }
        public ObservableCollection<Vehiculo> VehiculosDB { get; set; } = new ObservableCollection<Vehiculo>();
        public ObservableCollection<Vehiculo> VehiculosUsuario { get; set; } = new ObservableCollection<Vehiculo>();
        //IFirebaseClient cliente;

        public Vehiculos()
        {
            var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));


            var collection = cliente
             .Child("Vehiculos")
             .AsObservable<Vehiculo>()
             .Subscribe((item) =>
              {
                    if (item.Object != null)
                    {
                        VehiculosDB.Add(item.Object);
                      if (item.Object.Vendedor.Equals(userInfo.User.Email))
                      {
                          VehiculosUsuario.Add(item.Object);
                      }
                  }
                  
                });
        }

        public async void uploadImage(Stream fileImage, string name)
        {
           

            //authentication
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            //var a = await auth.SignInWithEmailAndPasswordAsync("email", "password");

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage(
                "parcial2automovil.appspot.com",
                   new FirebaseStorageOptions
                   {
                       ThrowOnCancel = true
                   })
                .Child("images")
                
                .Child(name + ".png")
                .PutAsync(fileImage);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            string downloadUrl = await task;
           currentImage = downloadUrl;
            Console.WriteLine(currentImage);

        }
        public ObservableCollection<Vehiculo> obtenerVehiculosUsuario(string email)
        {

            var collection = cliente
             .Child("Vehiculos")
             .AsObservable<Vehiculo>()
             .Subscribe((item) =>
             {
                 if (item.Object != null)
                 {
                     if (item.Object.Vendedor.Equals(email))
                     {
                         VehiculosUsuario.Add(item.Object);
                     }
                 }

             });
            return VehiculosUsuario;
        }
        public async void crearVehiculo(int _anio, string _foto, string _marca, string _modelo, double _precio, string _vendedor)
        {

            Vehiculo vh = new Vehiculo(_anio, _foto, _marca, _modelo, _precio, _vendedor);
           
            var vehiculloDB = await cliente.Child("Vehiculos").PostAsync(vh);

        }


    }

}
