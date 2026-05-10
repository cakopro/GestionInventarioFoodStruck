using GestionInventarioFoodStruck.Dao;
using GestionInventarioFoodStruck.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventarioFoodStruck.Views
{
    public partial class Ventas : Form
    {
        ProductosDao productosDao = new ProductosDao();
        VentasDao ventasDao = new VentasDao();
        List<ProductosClase> listaProductos = new List<ProductosClase>();
        List<DetalleVenta> detallesVenta = new List<DetalleVenta>();

        public Ventas()
        {
            InitializeComponent();
            CargarProductos();
            dgvDetalle.AutoGenerateColumns = true;
        }
        void CargarProductos()
        {
            listaProductos = productosDao.ObtenerProductos();

            cmbProducto.DataSource = null;
            cmbProducto.DataSource = listaProductos;

            cmbProducto.DisplayMember = "Nombre1";
            cmbProducto.ValueMember = "Id1";
        }
        void ActualizarDetalle()
        {
            dgvDetalle.DataSource = null;

            dgvDetalle.DataSource = detallesVenta;

            dgvDetalle.Columns["Precio"].DefaultCellStyle.Format = "C0";

            dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "C0";
        }
        void CalcularTotal()
        {
            float subtotal = detallesVenta.Sum(x => x.Subtotal);

            float iva = subtotal * 0.19f;

            float total = subtotal + iva;

            lblIVA.Text = "IVA: $" + iva.ToString("N0");

            lblTotal.Text = "TOTAL: $" + total.ToString("N0");
        }
        void ActualizarPrecio()
        {
            if (cmbProducto.SelectedItem != null)
            {
                ProductosClase producto = (ProductosClase)cmbProducto.SelectedItem;

                float total = producto.PrecioVenta1 * (float)numericUpDown1.Value;

                lblPrecio.Text = "$" + total.ToString("N0");
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Ingrese cantidad");
                return;
            }

            ProductosClase producto = (ProductosClase)cmbProducto.SelectedItem;
            int cantidadNuevaAñadir = (int)numericUpDown1.Value;

          
            int cantidadYaEnCarrito = 0;
            foreach (var item in detallesVenta)
            {
                if (item.IdProducto == producto.Id1)
                {
                    cantidadYaEnCarrito += item.Cantidad;
                }
            }

           
            int totalAValidar = cantidadYaEnCarrito + cantidadNuevaAñadir;

          
            bool stockDisponible = productosDao.HayStockSuficiente(producto.Id1, totalAValidar);

           
            if (!stockDisponible)
            {
                return;
            }

         
            DetalleVenta detalle = new DetalleVenta()
            {
                IdProducto = producto.Id1,
                Producto = producto.Nombre1,
                Precio = producto.PrecioVenta1,
                Cantidad = cantidadNuevaAñadir
            };

            detallesVenta.Add(detalle);
            ActualizarDetalle();
            CalcularTotal();
            numericUpDown1.Value = 1;
        }
        void CargarVentas()
        {
            this.ventasTableAdapter.Fill(this.gestionInventarioDBDataSet.Ventas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Ingrese nombre del cliente");
                return;
            }

            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("Agregue productos");
                return;
            }

            float subtotal = detallesVenta.Sum(x => x.Subtotal);

            float iva = subtotal * 0.19f;

            Venta venta = new Venta()
            {
                NombreCliente = txtCliente.Text,
                Fecha = DateTime.Now,
                IVA = iva,
                Detalles = detallesVenta
            };

            bool respuesta = ventasDao.GuardarVenta(venta);

            if (respuesta)
            {
                foreach (DetalleVenta item in detallesVenta)
                {
                    productosDao.DescontarInsumos(
                        item.IdProducto,
                        item.Cantidad);
                }

                MessageBox.Show("Venta guardada correctamente");

                CargarVentas();

                this.ventasTableAdapter.Fill(this.gestionInventarioDBDataSet.Ventas);

                this.detalleVentaTableAdapter.Fill(this.gestionInventarioDBDataSet.DetalleVenta);

                detallesVenta.Clear();

                ActualizarDetalle();

                CalcularTotal();

                txtCliente.Clear();

                numericUpDown1.Value = 1;
            }
            else
            {
                MessageBox.Show("Error al guardar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                int index = dgvDetalle.CurrentRow.Index;

                detallesVenta.RemoveAt(index);

                ActualizarDetalle();

                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Seleccione un producto");
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            try
            {
                this.ventasTableAdapter.Fill(this.gestionInventarioDBDataSet.Ventas);

                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvVentas.Columns[3].DefaultCellStyle.Format = "C0";

                dgvVentas.Columns[4].DefaultCellStyle.Format = "C0";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos: " + ex.Message);
            }


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }
    }
}

