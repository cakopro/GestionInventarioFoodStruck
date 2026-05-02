using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioFoodStruck.Model
{
    public class Insumos
    {
        private int id;
        private string Nombre;
        private float StockActual;
        private string UnidadMedida;
        private float PrecioUnitario;
        private DateTime FechaCaducidad;
        private int Id_Proveedor;

        public int Id { get => id; set => id = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public float StockActual1 { get => StockActual; set => StockActual = value; }
        public string UnidadMedida1 { get => UnidadMedida; set => UnidadMedida = value; }
        public float PrecioUnitario1 { get => PrecioUnitario; set => PrecioUnitario = value; }
        public DateTime FechaCaducidad1 { get => FechaCaducidad; set => FechaCaducidad = value; }
        public int Id_Proveedor1 { get => Id_Proveedor; set => Id_Proveedor = value; }

        public Insumos(int id, string nombre, float stockActual, string unidadMedida, float precioUnitario, DateTime fechaCaducidad, int id_Proveedor)
        {
            this.Id = id;
            Nombre1 = nombre;
            StockActual1 = stockActual;
            UnidadMedida1 = unidadMedida;
            PrecioUnitario1 = precioUnitario;
            FechaCaducidad1 = fechaCaducidad;
            Id_Proveedor1 = id_Proveedor;
        }
        public Insumos() { }

    }
}
