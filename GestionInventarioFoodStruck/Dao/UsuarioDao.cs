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
            using (SqlConnection conectarse = instancia.Conectarse())
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Usuario WHERE Nombre = @usuario AND Contrasena = @contrasena";

                    SqlCommand comando = new SqlCommand(query, conectarse);
                    comando.Parameters.AddWithValue("@usuario", usuario.Nombre);
                    comando.Parameters.AddWithValue("@contrasena", usuario.Contrasena);

                    conectarse.Open();

                    int resultado = Convert.ToInt32(comando.ExecuteScalar());

                    return resultado > 0;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error al agregar: {e.Message}");
                    return false;
                }
            }
        }
    }
}
