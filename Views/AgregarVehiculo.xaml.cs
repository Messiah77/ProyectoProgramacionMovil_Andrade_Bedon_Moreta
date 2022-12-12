using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models;
using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Controllers;
using Firebase.Auth;
using Newtonsoft.Json;
using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Services;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;

public partial class AgregarVehiculo : ContentPage
{
    //private INavigation _navigation;
    private int count = 0;
    UploadImage uploadImage { get; set; }
    private string newImageUrl { get; set; }
    public AgregarVehiculo()
    {
        InitializeComponent();
        uploadImage = new UploadImage();
        //this._navigation = navigation;

    }

    private async void onAgregarClicked(object sender, EventArgs e)
    {
        var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
        string userKey = userInfo.User.Email;
        Vehiculos vh = new Vehiculos();
        Console.WriteLine(newImageUrl);
        vh.crearVehiculo(Int32.Parse(AnioInput.Text), "https://firebasestorage.googleapis.com/v0/b/parcial2automovil.appspot.com/o/images%2Fmontero0.png?alt=media&token=525d54bd-234c-4eb2-9909-43bb24fce183", MarcaInput.Text, ModeloInput.Text, Convert.ToDouble(PrecioInput.Text), userKey);
        await Navigation.PopAsync();
    }

    private async void OnSubirClicked(object sender, EventArgs e)
    {
        var img = await uploadImage.OpenMediaPickerAsync();
        var imagefile = await uploadImage.Upload(img);
        Image_Upload.Source = ImageSource.FromStream(() =>
            uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase64))
        );
        Vehiculos vhImg = new Vehiculos();
        string imageName = ModeloInput.Text + count.ToString();
        vhImg.uploadImage(uploadImage.streamImg, imageName);
        newImageUrl = vhImg.currentImage;
        count++;
    }
}