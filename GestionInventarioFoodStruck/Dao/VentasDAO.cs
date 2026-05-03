using System;
using System.Data;
using System.Linq;
using GestionInventarioFoodStruck.GestionInventarioDBDataSet5TableAdapters; // Ajusta según tu namespace

namespace GestionInventarioFoodStruck.DAO
{
    public class VentasDAO
    {
        
        private VentasTableAdapter ventasAdapter = new VentasTableAdapter();
        private DetalleVentaTableAdapter detalleAdapter = new DetalleVentaTableAdapter();

        
        public bool FinalizarVentaCompleta(DateTime fecha, int neto, int iva, int total, DataTable detalleCarrito)
        {
            try
            {
                
                
                ventasAdapter.Insert(fecha, total, neto, iva);

                
                var tablaVentas = new GestionInventarioDBDataSet5.VentasDataTable();
                ventasAdapter.Fill(tablaVentas);
                int ultimaVentaId = tablaVentas.Max(v => v.Id);

                
                foreach (DataRow fila in detalleCarrito.Rows)
                {
                    
                    detalleAdapter.Insert(
                        ultimaVentaId,                         
                        Convert.ToInt32(fila["Id_Producto"]),  
                        fila["NombreProducto"].ToString(),     
                        Convert.ToInt32(fila["Cantidad"]),     
                        Convert.ToInt32(fila["Subtotal"])      
                    );
                }

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}