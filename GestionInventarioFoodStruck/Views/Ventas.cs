using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GestionInventarioFoodStruck.Views
{
    public partial class Ventas : Form
    {
        
        
        GestionInventarioDBDataSet4 ds4 = new GestionInventarioDBDataSet4();
        GestionInventarioDBDataSet4TableAdapters.ProductosTableAdapter productosTableAdapter = new GestionInventarioDBDataSet4TableAdapters.ProductosTableAdapter();

        
        int netoTotal = 0;
        int ivaTotal = 0;
        int totalAPagar = 0;

        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            
            this.detalleVentaTableAdapter.Fill(this.gestionInventarioDBDataSet51.DetalleVenta);
            
            this.detalleVentaTableAdapter.Fill(this.gestionInventarioDBDataSet51.DetalleVenta);
            try
            {
                
                this.productosTableAdapter.Fill(this.ds4.Productos);

                
                this.ventasTableAdapter.Fill(this.gestionInventarioDBDataSet5.Ventas);

                
                cmbProducto.DataSource = this.ds4.Productos;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "Id";

                cmbProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void ActualizarTotales()
        {
            try
            {
                netoTotal = 0;

                
                var ds = (GestionInventarioDBDataSet5)detalleVentaBindingSource6.DataSource;

                foreach (var fila in ds.DetalleVenta)
                {
                    
                    if (fila.RowState != DataRowState.Deleted && fila.RowState != DataRowState.Detached)
                    {
                        netoTotal += Convert.ToInt32(fila.Subtotal);
                    }
                }

                ivaTotal = (int)Math.Round(netoTotal * 0.19);
                totalAPagar = netoTotal + ivaTotal;

                
                lblNeto.Text = "Neto: " + netoTotal.ToString("C0");
                lblIVA.Text = "IVA (19%): " + ivaTotal.ToString("C0");
                lblTotal.Text = "Total a Pagar: " + totalAPagar.ToString("C0");
            }
            catch (Exception ex)
            {
                lblTotal.Text = "Total a Pagar: $0";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null) return;

            try
            {
                DataRowView producto = (DataRowView)cmbProducto.SelectedItem;
                int precio = Convert.ToInt32(producto["PrecioVenta"]);
                int cant = (int)numCantidad.Value;

                
                
                var ds = (GestionInventarioDBDataSet5)detalleVentaBindingSource6.DataSource;
                var tabla = ds.DetalleVenta;

                
                var nuevaFila = tabla.NewDetalleVentaRow();
                nuevaFila.Id_Venta = 0;
                nuevaFila.Id_Producto = Convert.ToInt32(producto["Id"]);
                nuevaFila.NombreProducto = producto["Nombre"].ToString();
                nuevaFila.Cantidad = cant;
                nuevaFila.Subtotal = precio * cant;

                
                tabla.AddDetalleVentaRow(nuevaFila);

                ActualizarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }



        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            
            var tablaDetalle = this.gestionInventarioDBDataSet51.DetalleVenta;

            if (tablaDetalle.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Debe agregar al menos un producto.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                this.ventasTableAdapter.Insert(DateTime.Now, totalAPagar, ivaTotal, netoTotal);

                
                int idVentaActual = (int)this.ventasTableAdapter.GetData().Last().Id;

                
                foreach (GestionInventarioDBDataSet5.DetalleVentaRow fila in tablaDetalle)
                {
                    if (fila.RowState != DataRowState.Deleted && fila.RowState != DataRowState.Detached)
                    {
                        this.detalleVentaTableAdapter.Insert(
                            idVentaActual,
                            fila.Id_Producto,
                            fila.NombreProducto,
                            fila.Cantidad,
                            fila.Subtotal
                        );
                    }
                }

                MessageBox.Show("Venta guardada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                tablaDetalle.Clear();
                this.ventasTableAdapter.Fill(this.gestionInventarioDBDataSet5.Ventas);

                
                ActualizarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbProducto.SelectedItem != null && cmbProducto.SelectedItem is DataRowView)
            {
                try
                {
                    
                    DataRowView producto = (DataRowView)cmbProducto.SelectedItem;

                    
                    int precio = Convert.ToInt32(producto["PrecioVenta"]);

                    
                    lblPrecio.Text = precio.ToString("C0");
                }
                catch (Exception ex)
                {
                    lblPrecio.Text = "$0";
                }
            }
            else
            {
                
                lblPrecio.Text = "$0";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (dgvDetalleVenta.CurrentRow != null && dgvDetalleVenta.CurrentRow.DataBoundItem != null)
            {
                try
                {
                    
                    DataRowView filaActual = (DataRowView)dgvDetalleVenta.CurrentRow.DataBoundItem;

                    
                    filaActual.Delete();

                    
                    ActualizarTotales();

                    MessageBox.Show("Producto quitado del detalle.", "Food Truck");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila en el detalle para eliminar.");
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvDetalleVenta.CurrentRow != null)
            {
                var fila = (GestionInventarioDBDataSet5.DetalleVentaRow)((DataRowView)dgvDetalleVenta.CurrentRow.DataBoundItem).Row;

                Form2 frmEditar = new Form2();

                frmEditar.NombreProducto = fila.NombreProducto;
                frmEditar.Cantidad = (int)fila.Cantidad;

                if (fila.Cantidad > 0)
                {
                    frmEditar.PrecioUnitario = (int)(fila.Subtotal / fila.Cantidad);
                }
                else
                {
                    frmEditar.PrecioUnitario = 0;
                }

                if (frmEditar.ShowDialog() == DialogResult.OK)
                {
                    
                    
                    fila.NombreProducto = frmEditar.NombreProducto;
                    fila.Cantidad = frmEditar.Cantidad;
                    fila.Subtotal = frmEditar.Cantidad * frmEditar.PrecioUnitario;

                    ActualizarTotales();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la tabla para editar.");
            }
        }
    }
}
