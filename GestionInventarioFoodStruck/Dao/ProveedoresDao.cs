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
    public class ProveedoresDao
    {
        public bool agregarProveedor(Proveedores proveedor)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "INSERT INTO Proveedores (Nombre,Telefono,Correo,Empresa,Direccion) VALUES (" +
                    "@Nombre,@Telefono,@Correo,@Empresa,@Direccion)";
                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                comando.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                comando.Parameters.AddWithValue("@Correo", proveedor.Correo);
                comando.Parameters.AddWithValue("@Empresa", proveedor.Empresa);
                comando.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                conectarse.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) { 
                MessageBox.Show($"Error:{e.Message}");
                return false;
            }
            finally { conectarse.Close(); }
        }

        public bool editarProveedor(Proveedores proveedor)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "UPDATE Proveedores SET Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, " +
                    "Empresa = @Empresa, Direccion = @Direccion WHERE Id = @Id";
                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                comando.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                comando.Parameters.AddWithValue("@Correo", proveedor.Correo);
                comando.Parameters.AddWithValue("@Empresa", proveedor.Empresa);
                comando.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                comando.Parameters.AddWithValue("@Id", proveedor.Id);

                conectarse.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error:{e.Message}");
                return false;
            }
            finally { conectarse.Close(); }
        }
    }
}
