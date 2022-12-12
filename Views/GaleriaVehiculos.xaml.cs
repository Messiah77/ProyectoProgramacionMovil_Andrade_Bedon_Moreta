using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Controllers;
using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models;
using System.Collections.ObjectModel;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;

public partial class GaleriaVehiculos : ContentPage
{
    //private INavigation _navigation;
   
    public GaleriaVehiculos()
    {
        InitializeComponent();
        BindingContext = new Vehiculos();


    }

    public void OnBtnAgregarClicked(object sender, EventArgs e)
    {
        //new AgregarVehiculo();
       
    }

    private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //Console.WriteLine(e.CurrentSelection.FirstOrDefault() as Vehiculo);
        //Vehiculos vh = new Vehiculos();
        Vehiculo vehi = e.CurrentSelection.FirstOrDefault() as Vehiculo;

        await Navigation.PushAsync(new PaginaVehiculo(vehi));
    }
}