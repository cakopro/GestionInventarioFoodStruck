using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace GestionInventarioFoodStruck.Dao
{
    public class Conexion
    {
        private static Conexion instancia;
        private readonly string cadenaConexion;

        private Conexion(){
            this.cadenaConexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString; 
        }

    public static Conexion getInstance() {
            if (instancia == null) {
                instancia = new Conexion();
            }
            return instancia;
        }
    public SqlConnection Conectarse()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
