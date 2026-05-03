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

               
                foreach (GestionInventarioDBDataSet5.DetalleVentaRow fila in this.gestionInventarioDBDataSet5.DetalleVenta)
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

                
                int idProd = Convert.ToInt32(producto["Id"]);
                string nombreProd = producto["Nombre"].ToString();
                int precio = Convert.ToInt32(producto["PrecioVenta"]);
                int cant = (int)numCantidad.Value;

               
                var nuevaFila = this.gestionInventarioDBDataSet5.DetalleVenta.NewDetalleVentaRow();

                nuevaFila.Id_Producto = idProd;
                nuevaFila.NombreProducto = nombreProd; 
                nuevaFila.Cantidad = cant;
                nuevaFila.Subtotal = precio * cant;
                nuevaFila.Id_Venta = 0;

                this.gestionInventarioDBDataSet5.DetalleVenta.AddDetalleVentaRow(nuevaFila);
                ActualizarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        
        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            
            if (this.gestionInventarioDBDataSet5.DetalleVenta.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Debe agregar al menos un producto para finalizar la venta.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                
                this.ventasTableAdapter.Insert(DateTime.Now, totalAPagar, netoTotal, ivaTotal);

                
                
                int idVentaActual = (int)this.ventasTableAdapter.GetData().Last().Id;

                
                foreach (GestionInventarioDBDataSet5.DetalleVentaRow fila in this.gestionInventarioDBDataSet5.DetalleVenta)
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

                
                MessageBox.Show("Venta guardada exitosamente en el historial", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                this.gestionInventarioDBDataSet5.DetalleVenta.Clear();

                
                this.ventasTableAdapter.Fill(this.gestionInventarioDBDataSet5.Ventas);

                ActualizarTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al finalizar la venta: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
