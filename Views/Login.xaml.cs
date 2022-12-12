using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models;
namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;

public partial class Login : ContentPage
{
	public Login()
	{
        InitializeComponent();
        BindingContext = new LoginModel(Navigation);
	}

    //private INavigation _navigation;
    //private void RegisterBtnAsync(object obj)
    //{
    //    this._navigation.PushAsync(new Register());
    //}

    //public Command RegisterBtn { get; set; }
}