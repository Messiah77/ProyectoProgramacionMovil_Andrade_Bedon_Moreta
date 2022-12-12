using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;
using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Controllers;
using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models;
using System.Collections.ObjectModel;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta;

public partial class MainPage : ContentPage
{
	int count = 0;
    public ObservableCollection<Vehiculo> VehiculosDB { get; set; } = new ObservableCollection<Vehiculo>();

    public MainPage()
	{
		InitializeComponent();
		BindingContext = new Login();
	}


}

