using System;
using System.Data;
using System.Linq;
using GestionInventarioFoodStruck.GestionInventarioDBDataSet5TableAdapters; // Ajusta según tu namespace

namespace GestionInventarioFoodStruck.DAO
{
    public class VentasDAO
    {
        // Instanciamos los adaptadores que ya creaste en el diseño
        private VentasTableAdapter ventasAdapter = new VentasTableAdapter();
        private DetalleVentaTableAdapter detalleAdapter = new DetalleVentaTableAdapter();

        // Método para registrar la venta completa (Cabecera y Detalle)
        public bool FinalizarVentaCompleta(DateTime fecha, int neto, int iva, int total, DataTable detalleCarrito)
        {
            try
            {
                // 1. Insertar en el Historial de Ventas (Cabecera)
                // Asegúrate de que el orden coincida con tu tabla 'Ventas'
                ventasAdapter.Insert(fecha, total, neto, iva);

                // 2. Obtener el ID de la venta que acabamos de crear
                var tablaVentas = new GestionInventarioDBDataSet5.VentasDataTable();
                ventasAdapter.Fill(tablaVentas);
                int ultimaVentaId = tablaVentas.Max(v => v.Id);

                // 3. Insertar cada producto en el Detalle de Venta
                foreach (DataRow fila in detalleCarrito.Rows)
                {
                    // SOLUCIÓN: Pasamos los 5 parámetros exactos que pide el TableAdapter
                    detalleAdapter.Insert(
                        ultimaVentaId,                         // 1. Id_Venta (int)
                        Convert.ToInt32(fila["Id_Producto"]),  // 2. Id_Producto (int)
                        fila["NombreProducto"].ToString(),     // 3. NombreProducto (string) - ESTO EVITA EL ERROR
                        Convert.ToInt32(fila["Cantidad"]),     // 4. Cantidad (int)
                        Convert.ToInt32(fila["Subtotal"])      // 5. Subtotal (int)
                    );
                }

                return true;
            }
            catch (Exception ex)
            {
                // Si hay un error, lo ideal es capturarlo para depurar
                return false;
            }
        }
    }
}