namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta;
using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;
public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
		//MainPage = new NavigationPage(new MainPage());
        MainPage = new NavigationPage(new Login());
       
    }
}
