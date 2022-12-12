using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;

public partial class PaginaVehiculo : ContentPage
{
	public PaginaVehiculo(Vehiculo v)
	{
		InitializeComponent();
		marcaTxt.Text = v.Marca;
		anioTxt.Text = v.Anio.ToString();
		precioTxt.Text = v.Precio.ToString();
		modeloTxt.Text = v.Modelo;
		imagenCarro.Source = v.Foto;
	}
}