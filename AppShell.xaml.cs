using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;
namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.GaleriaVehiculos), typeof(Views.GaleriaVehiculos));
    }
}
