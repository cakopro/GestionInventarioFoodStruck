using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioFoodStruck.Model
{
    public class Venta
    {
        public int Id { get; set; }

        public string NombreCliente { get; set; }

        public DateTime Fecha { get; set; }

        public float IVA { get; set; }

        public float Total
        {
            get
            {
                return Detalles.Sum(x => x.Subtotal) + IVA;
            }
        }

        public List<DetalleVenta> Detalles { get; set; }

        public Venta()
        {
            Detalles = new List<DetalleVenta>();
        }
    }
}
