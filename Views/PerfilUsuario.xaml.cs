using Newtonsoft.Json;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;

public partial class PerfilUsuario : ContentPage
{
	public PerfilUsuario()
	{
		InitializeComponent();
        GetProfileInfo();
	}

    private void GetProfileInfo()
    {
        var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
        correoUsuario.Text = userInfo.User.Email;
        //bienvenidaTxt.Text = userInfo.User.Email;
    }
}