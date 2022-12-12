using Microsoft.Maui.Controls;
using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Controllers;
namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;

public partial class VehiculosUsuario : ContentPage
{
    //private INavigation _navigation;
    public VehiculosUsuario()
	{
		InitializeComponent();
		BindingContext = new Vehiculos();
        //this._navigation = navigation;

    }

    private async void OnBtnAgregarClicked(object sender, EventArgs e)
    {
        //App.Current.MainPage = new NavigationPage(new AgregarVehiculo());
        //await this._navigation.PushAsync(new AgregarVehiculo(_navigation));
        await Navigation.PushAsync(new AgregarVehiculo());
    }

    private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Console.WriteLine("");
    }
}