using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;


public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
		BindingContext= new RegisterModel(Navigation);
	}
}