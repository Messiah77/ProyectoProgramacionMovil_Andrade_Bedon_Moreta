using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models
{
    internal class RegisterModel : INotifyPropertyChanged


    {

        public string webApiKey = "AIzaSyD7ZTFhFn6-2UvEyzIrfI3W55BZWCqKy5M";
        private INavigation _navigation;
        private string email;
        private string password;


        public event PropertyChangedEventHandler PropertyChanged;

        public string UserMail { get => email; 
            
            set 
            { 
                email = value;
                RaisePropertyChange("UserMail");
            } 
        }

        public string UserPassword { get => password;

            set
            {
                password = value;
                RaisePropertyChange("UserPassword");
            }
        }
        public Command RegisterBtn { get; set; }


        private void RaisePropertyChange(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }


        public RegisterModel(INavigation navigation) 
        {
            this._navigation = navigation;

            RegisterBtn = new Command(RegisterBtnTappedAsync);

              
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            try
            {
                //var testEmail = UserMail;
                //var testPass = UserPassword;
                //Console.WriteLine(testEmail);
                //Console.WriteLine(testPass);

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserMail, UserPassword);
                string token = auth.FirebaseToken;
                if(token != null)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "El usuario se registró correctamente.", "OK");
                    await this._navigation.PopAsync();
                }
            }
            
            catch (Exception ex) 
            {

                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }
    }
}
