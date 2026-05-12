using GestionInventarioFoodStruck.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventarioFoodStruck.Dao
{
    internal class UsuarioDao
    {

        public bool validarUsuario(Usuario usuario)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "SELECT *FROM USUARIO WHERE usuario = @usuario and contrasena = @contrasena)";

                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@usuario", usuario.Nombre);
                comando.Parameters.AddWithValue("@contrasena", usuario.Contrasena);

                conectarse.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al agregar: {e.Message}");
                return false;
            }
        }
    }
}
