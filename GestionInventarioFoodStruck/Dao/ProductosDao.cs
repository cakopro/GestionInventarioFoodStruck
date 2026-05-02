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
    public class ProductosDao
    {
        public List<Receta> traerInsumos(int idProducto)
        {
            List<Receta> lista = new List<Receta>();
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "SELECT Insumos.Nombre, Recetas.CantidadRequerida, Insumos.UnidadMedida FROM Recetas INNER " +
                    "JOIN Insumos ON Recetas.Id_Insumo = Insumos.Id WHERE Recetas.Id_Producto = @Id";
                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Id", idProducto);

                conectarse.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) { 
                    Receta receta = new Receta();
                    receta.NombreInsumo = reader["Nombre"].ToString();
                    receta.CantidadRequerida1 = float.Parse(reader["CantidadRequerida"].ToString());
                    receta.UnidadMedida1 = reader["UnidadMedida"].ToString();
                    lista.Add(receta);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error:{e.Message}");
            }
            finally { conectarse.Close(); }
            return lista;
        }
        public bool GuardarProductoConReceta(ProductosClase producto, List<Receta> listaReceta)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();

            try
            {
                conectarse.Open();
                SqlTransaction transaccion = conectarse.BeginTransaction();

                try
                {
                    string queryProducto = "INSERT INTO Productos (Nombre, PrecioVenta) VALUES (@Nombre, @PrecioVenta); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdProd = new SqlCommand(queryProducto, conectarse, transaccion);
                    cmdProd.Parameters.AddWithValue("@Nombre", producto.Nombre1);
                    cmdProd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta1);

                    int nuevoIdProducto = Convert.ToInt32(cmdProd.ExecuteScalar());

                    foreach (Receta item in listaReceta)
                    {
                        string queryReceta = "INSERT INTO Recetas (Id_Producto, Id_Insumo, CantidadRequerida) " +
                                             "VALUES (@IdProd, @IdInsumo, @Cant)";
                        SqlCommand cmdReceta = new SqlCommand(queryReceta, conectarse, transaccion);
                        cmdReceta.Parameters.AddWithValue("@IdProd", nuevoIdProducto);
                        cmdReceta.Parameters.AddWithValue("@IdInsumo", item.Id_Insumo1);
                        cmdReceta.Parameters.AddWithValue("@Cant", item.CantidadRequerida1);

                        cmdReceta.ExecuteNonQuery();
                    }

                    transaccion.Commit(); 
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback(); 
                    MessageBox.Show("Error en la transacción: " + ex.Message);
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error de conexión: {e.Message}");
                return false;
            }
            finally { conectarse.Close(); }
        }
    }
}
