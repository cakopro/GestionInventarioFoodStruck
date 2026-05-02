using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioFoodStruck.Model
{
    public class Receta
    {
        private int Id;
        private int Id_producto;
        private int Id_Insumo;
        private float CantidadRequerida;
        //usadas para mostrar en la tabla de insumos en productos
        private string nombreInsumo;
        private string UnidadMedida;

       
        
        public Receta() { }

        public Receta(int id, int id_producto, int id_Insumo, float cantidadRequerida, string nombreInsumo, string unidadMedida)
        {
            Id1 = id;
            Id_producto1 = id_producto;
            Id_Insumo1 = id_Insumo;
            CantidadRequerida1 = cantidadRequerida;
            this.NombreInsumo = nombreInsumo;
            UnidadMedida1 = unidadMedida;
        }

        public int Id1 { get => Id; set => Id = value; }
        public int Id_producto1 { get => Id_producto; set => Id_producto = value; }
        public int Id_Insumo1 { get => Id_Insumo; set => Id_Insumo = value; }
        public float CantidadRequerida1 { get => CantidadRequerida; set => CantidadRequerida = value; }
        public string NombreInsumo { get => nombreInsumo; set => nombreInsumo = value; }
        public string UnidadMedida1 { get => UnidadMedida; set => UnidadMedida = value; }
    }
}
