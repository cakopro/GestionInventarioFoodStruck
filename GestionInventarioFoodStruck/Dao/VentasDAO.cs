using GestionInventarioFoodStruck.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestionInventarioFoodStruck.Dao
{
    public class VentasDao
    {
        Conexion instancia = Conexion.getInstance();

        public bool GuardarVenta(Venta venta)
        {
            SqlConnection conexion = instancia.Conectarse();

            try
            {
                conexion.Open();

                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    string queryVenta = @"INSERT INTO Ventas
                    (NombreCliente, Fecha, IVA, Total)
                    VALUES
                    (@NombreCliente, @Fecha, @IVA, @Total);

                    SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaccion);

                    cmdVenta.Parameters.AddWithValue("@NombreCliente", venta.NombreCliente);
                    cmdVenta.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    cmdVenta.Parameters.AddWithValue("@IVA", venta.IVA);
                    cmdVenta.Parameters.AddWithValue("@Total", venta.Total);

                    int idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());

                    foreach (DetalleVenta d in venta.Detalles)
                    {
                        string queryDetalle = @"INSERT INTO DetalleVenta
                        (IdVenta, IdProducto, Producto, Precio, Cantidad, Subtotal)
                        VALUES
                        (@IdVenta, @IdProducto, @Producto, @Precio, @Cantidad, @Subtotal)";

                        SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion);

                        cmdDetalle.Parameters.AddWithValue("@IdVenta", idVenta);
                        cmdDetalle.Parameters.AddWithValue("@IdProducto", d.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@Producto", d.Producto);
                        cmdDetalle.Parameters.AddWithValue("@Precio", d.Precio);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@Subtotal", d.Subtotal);

                        cmdDetalle.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();

                    MessageBox.Show("Error: " + ex.Message);

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conexión: " + ex.Message);

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}