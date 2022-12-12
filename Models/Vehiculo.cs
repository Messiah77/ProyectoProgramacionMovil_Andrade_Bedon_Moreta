using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models
{
    public class Vehiculo
    {
        public int Anio { get; set; }
        public string Foto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Precio { get; set; }
        public string Vendedor { get; set; }
  
        public Vehiculo(int _anio, string _foto, string _marca, string _modelo, double _precio , string _vendedor) {
            this.Anio = _anio;
            this.Foto = _foto;
            this.Marca = _marca;
            this.Modelo = _modelo;
            this.Precio = _precio;
            this.Vendedor = _vendedor;
        }

        public Vehiculo() { }
    }
}
