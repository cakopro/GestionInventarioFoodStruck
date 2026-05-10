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
    public class InsumosDao
    {
        public List<Insumos> traerTodo()
        {
            List<Insumos> lista = new List<Insumos>();
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "SELECT * FROM Insumos";
                SqlCommand comando = new SqlCommand(query, conectarse);

                conectarse.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Insumos insumo = new Insumos();
                    insumo.Id = int.Parse(reader["Id"].ToString());
                    insumo.Nombre1 = (reader["Nombre"].ToString());
                    insumo.StockActual1 = float.Parse(reader["StockActual"].ToString());
                    insumo.UnidadMedida1 = reader["UnidadMedida"].ToString();
                    insumo.PrecioUnitario1 = float.Parse(reader["PrecioUnitario"].ToString());
                    insumo.FechaCaducidad1 = DateTime.Parse(reader["FechaCaducidad"].ToString());
                    insumo.Id_Proveedor1 = int.Parse(reader["Id_Proveedor"].ToString());
                    insumo.Estado = Convert.ToBoolean(reader["Estado"]);

                    lista.Add(insumo);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error:{e.Message}");
            }
            finally { conectarse.Close(); }
            return lista;
        }

        public bool agregarInsumo(Insumos insumo)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "INSERT INTO Insumos (Nombre, StockActual, UnidadMedida, PrecioUnitario, FechaCaducidad, Id_Proveedor) " +
                               "VALUES (@Nombre, @StockActual, @UnidadMedida, @PrecioUnitario, @FechaCaducidad, @Id_Proveedor)";

                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Nombre", insumo.Nombre1);
                comando.Parameters.AddWithValue("@StockActual", insumo.StockActual1);
                comando.Parameters.AddWithValue("@UnidadMedida", insumo.UnidadMedida1);
                comando.Parameters.AddWithValue("@PrecioUnitario", insumo.PrecioUnitario1);
                comando.Parameters.AddWithValue("@FechaCaducidad", insumo.FechaCaducidad1);
                comando.Parameters.AddWithValue("@Id_Proveedor", insumo.Id_Proveedor1);

                conectarse.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al agregar: {e.Message}");
                return false;
            }
            finally { conectarse.Close(); }
        }

        public bool editarInsumo(Insumos insumo)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "UPDATE Insumos SET Nombre = @Nombre, StockActual = @StockActual, " +
                               "UnidadMedida = @UnidadMedida, PrecioUnitario = @PrecioUnitario, " +
                               "FechaCaducidad = @FechaCaducidad, Id_Proveedor = @Id_Proveedor WHERE Id = @Id";

                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Nombre", insumo.Nombre1);
                comando.Parameters.AddWithValue("@StockActual", insumo.StockActual1);
                comando.Parameters.AddWithValue("@UnidadMedida", insumo.UnidadMedida1);
                comando.Parameters.AddWithValue("@PrecioUnitario", insumo.PrecioUnitario1);
                comando.Parameters.AddWithValue("@FechaCaducidad", insumo.FechaCaducidad1);
                comando.Parameters.AddWithValue("@Id_Proveedor", insumo.Id_Proveedor1);
                comando.Parameters.AddWithValue("@Id", insumo.Id); 

                conectarse.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al editar: {e.Message}");
                return false;
            }
            finally { conectarse.Close(); }
        }

        public bool eliminarInsumo(int id)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
               
                string query = "UPDATE Insumos SET Estado = 0 WHERE Id = @Id";

                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Id", id);

                conectarse.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al desactivar en la base de datos: {e.Message}");
                return false;
            }
            finally { conectarse.Close(); }
        }

        public bool existeInsumo(string nombreInsumo, int idExcluir = 0)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {

                string query = "SELECT COUNT(*) FROM Insumos WHERE LTRIM(RTRIM(Nombre)) = @Nombre AND Id != @IdExcluir";

                SqlCommand comando = new SqlCommand(query, conectarse);


                comando.Parameters.AddWithValue("@Nombre", nombreInsumo.Trim());
                comando.Parameters.AddWithValue("@IdExcluir", idExcluir);

                conectarse.Open();


                int cantidad = Convert.ToInt32(comando.ExecuteScalar());

               
                return cantidad > 0;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al validar duplicado: {e.Message}");
                return false;
            }
            finally { conectarse.Close(); }
        }
    }
}
