using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioFoodStruck.Model
{
    public class ProductosClase
    {
        private int Id;
        private string Nombre;
        private float PrecioVenta;
        private bool estado;

        public ProductosClase(int id, string nombre, float precioVenta, bool estado)
        {
            Id1 = id;
            Nombre1 = nombre;
            PrecioVenta1 = precioVenta;
            this.Estado = estado;
        }

        public ProductosClase()
        {
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public float PrecioVenta1 { get => PrecioVenta; set => PrecioVenta = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
