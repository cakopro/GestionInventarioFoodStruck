using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarioFoodStruck.Model
{
    public class Proveedores
    {
        int id;
        string nombre;
        string telefono;
        string correo;
        string empresa;
        string direccion;
        bool estado;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Estado { get => estado; set => estado = value; }

        public Proveedores(int id, string nombre, string telefono, string correo, string empresa, string direccion, bool estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Empresa = empresa;
            this.Direccion = direccion;
            this.Estado = estado;
        }

        public Proveedores(){ }

    }
}
