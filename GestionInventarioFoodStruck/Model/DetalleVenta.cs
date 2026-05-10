using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioFoodStruck.Model
{
    public class DetalleVenta
    {
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }

        public float Subtotal
        {
            get { return Precio * Cantidad; }
        }
    }
}
