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
                string query = "SELECT Insumos.Id, Insumos.Nombre, Recetas.CantidadRequerida, Insumos.UnidadMedida " +
                    "FROM Recetas INNER JOIN Insumos ON Recetas.Id_Insumo = Insumos.Id " +
                    "WHERE Recetas.Id_Producto = @Id";
                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Id", idProducto);

                conectarse.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Receta receta = new Receta();
                    receta.Id_Insumo1 = int.Parse(reader["Id"].ToString());
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
                    string queryProducto = "INSERT INTO Productos (Nombre, PrecioVenta,estado) VALUES (@Nombre, @PrecioVenta,@Estado); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdProd = new SqlCommand(queryProducto, conectarse, transaccion);
                    cmdProd.Parameters.AddWithValue("@Nombre", producto.Nombre1);
                    cmdProd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta1);
                    cmdProd.Parameters.AddWithValue("@Estado", producto.Estado);

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
        public List<ProductosClase> traerTodo(bool verInactivos = false)
        {
            List<ProductosClase> lista = new List<ProductosClase>();
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                int estadoFiltro = verInactivos ? 0 : 1;

                string query = "SELECT Id, Nombre, PrecioVenta, estado FROM Productos Where estado = @Estado";
                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Estado", estadoFiltro);

                conectarse.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new ProductosClase(
                        int.Parse(reader["Id"].ToString()),
                        reader["Nombre"].ToString(),
                        float.Parse(reader["PrecioVenta"].ToString()),
                        Convert.ToBoolean(reader["estado"]
                    )));
                }
            }
            catch (Exception e) { MessageBox.Show($"Error: {e.Message}"); }
            finally { conectarse.Close(); }
            return lista;
        }

        public bool eliminarProducto(int id)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "UPDATE Productos SET estado = 0 WHERE Id = @Id";
                SqlCommand comando = new SqlCommand(query, conectarse);
                comando.Parameters.AddWithValue("@Id", id);
                conectarse.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al eliminar: {e.Message}");
                return false;
            }
            finally { conectarse.Close(); }
        }
        public bool ActualizarProductoConReceta(ProductosClase producto, List<Receta> listaReceta)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            conectarse.Open();
            SqlTransaction transaccion = conectarse.BeginTransaction();

            try
            {
                string queryProd = "UPDATE Productos SET Nombre = @Nom, PrecioVenta = @Pre, estado = @Est WHERE Id = @Id";
                SqlCommand cmdProd = new SqlCommand(queryProd, conectarse, transaccion);
                cmdProd.Parameters.AddWithValue("@Nom", producto.Nombre1);
                cmdProd.Parameters.AddWithValue("@Pre", producto.PrecioVenta1);
                cmdProd.Parameters.AddWithValue("@Est", producto.Estado);
                cmdProd.Parameters.AddWithValue("@Id", producto.Id1);
                cmdProd.ExecuteNonQuery();

                string queryDel = "DELETE FROM Recetas WHERE Id_Producto = @IdProd";
                SqlCommand cmdDel = new SqlCommand(queryDel, conectarse, transaccion);
                cmdDel.Parameters.AddWithValue("@IdProd", producto.Id1);
                cmdDel.ExecuteNonQuery();

                foreach (Receta item in listaReceta)
                {
                    string queryIns = "INSERT INTO Recetas (Id_Producto, Id_Insumo, CantidadRequerida) VALUES (@P, @I, @C)";
                    SqlCommand cmdIns = new SqlCommand(queryIns, conectarse, transaccion);
                    cmdIns.Parameters.AddWithValue("@P", producto.Id1);
                    cmdIns.Parameters.AddWithValue("@I", item.Id_Insumo1);
                    cmdIns.Parameters.AddWithValue("@C", item.CantidadRequerida1);
                    cmdIns.ExecuteNonQuery();
                }

                transaccion.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                MessageBox.Show("Error al actualizar: " + ex.Message);
                return false;
            }
            finally { conectarse.Close(); }
        }
        public List<ProductosClase> ObtenerProductos()
        {
            List<ProductosClase> lista = new List<ProductosClase>();

            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();

            try
            {
                string query = "SELECT * FROM Productos WHERE estado = 1";

                SqlCommand comando = new SqlCommand(query, conectarse);

                conectarse.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ProductosClase producto = new ProductosClase();

                    producto.Id1 = int.Parse(reader["Id"].ToString());
                    producto.Nombre1 = reader["Nombre"].ToString();
                    producto.PrecioVenta1 = float.Parse(reader["PrecioVenta"].ToString());

                    lista.Add(producto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conectarse.Close();
            }

            return lista;
        }
        public bool HayStockSuficiente(int idProducto, int cantidadVendida)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conexion = instancia.Conectarse();

            try
            {
                conexion.Open();
                string query = @"
                SELECT 
                    I.Nombre,
                    I.StockActual,
                    R.CantidadRequerida
                FROM Recetas R
                INNER JOIN Insumos I
                ON R.Id_Insumo = I.Id
                WHERE R.Id_Producto = @IdProducto";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   
                    float stockActual = Convert.ToSingle(reader["StockActual"]);
                    float cantidadRequerida = Convert.ToSingle(reader["CantidadRequerida"]);
                    string nombreInsumo = reader["Nombre"].ToString();

                    float necesario = cantidadRequerida * cantidadVendida;
                    if (stockActual < necesario)
                    {
                        MessageBox.Show("No hay suficiente stock de: " + nombreInsumo, "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar stock: " + ex.Message);
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void DescontarInsumos(int idProducto, int cantidadVendida)
        {
            Conexion instancia = Conexion.getInstance();
            SqlConnection conexion = instancia.Conectarse();

            try
            {
                conexion.Open();

                 
                string query = @"
                UPDATE I
                SET I.StockActual = I.StockActual - (R.CantidadRequerida * @CantidadVendida)
                FROM Insumos I
                INNER JOIN Recetas R
                ON R.Id_Insumo = I.Id
                WHERE R.Id_Producto = @IdProducto";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.Parameters.AddWithValue("@CantidadVendida", cantidadVendida);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al descontar insumos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}