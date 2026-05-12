using GestionInventarioFoodStruck.Dao;
using GestionInventarioFoodStruck.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventarioFoodStruck.Views
{
    public partial class AgregarProducto : Form
    {
        public InsumosDao insumos = new InsumosDao();
        List<Receta> listaTemporal = new List<Receta>();
        ProductosDao productosDao = new ProductosDao();
        private ProductosClase productoExistente = null;
        public AgregarProducto(ProductosClase prod = null, List<Receta> receta = null)
        {
            InitializeComponent();
            this.productoExistente = prod;
            this.listaTemporal = receta ?? new List<Receta>();
            cmbIngredientes.DropDownStyle = ComboBoxStyle.DropDownList;

            dataReceta.AutoGenerateColumns = false;
            cargarCatalogo();
            configuracionInicial();

        }

        private void configuracionInicial()
        {
            if (productoExistente != null)
            {
                this.Text = "Editar Producto";
                lblTitulo.Text = "Modificando: " + productoExistente.Nombre1;
                txtNombre.Text = productoExistente.Nombre1;

                dataReceta.DataSource = listaTemporal;
            }
            else
            {
                this.Text = "Nuevo Producto";
                lblTitulo.Text = "Agregar Producto";
                dataReceta.DataSource = null;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || cmbIngredientes.SelectedValue == null)
            {
                MessageBox.Show("Por favor, completa todos los campos de texto.");
                return;
            }
            if (float.Parse(txtCantidad.Text) < 0.0f) {
                MessageBox.Show("El campo cantidad debe ser positivo.");
                return;
            }

            Insumos seleccionado = (Insumos)cmbIngredientes.SelectedItem;

            Receta nueva = new Receta();

            nueva.Id_Insumo1 = (int)cmbIngredientes.SelectedValue;
            nueva.NombreInsumo = cmbIngredientes.Text;
            nueva.CantidadRequerida1 = float.Parse(txtCantidad.Text);
            nueva.UnidadMedida1 = seleccionado.UnidadMedida1;

            listaTemporal.Add(nueva);
            dataReceta.DataSource = null;
            dataReceta.DataSource = listaTemporal;
            txtNombre.Enabled = false;
            ActualizarPantallaYPrecio();
        }
        void cargarCatalogo()
        {
            var listaInsumos = insumos.traerTodo().Where(i => i.Estado == true).ToList();

            cmbIngredientes.DataSource = listaInsumos;
            cmbIngredientes.DisplayMember = "Nombre1";
            cmbIngredientes.ValueMember = "Id";
        }

        private float calcularNetoRenglon(float precioUnitario, float cantidad)
        {
            return precioUnitario * cantidad;
        }
        private void ActualizarPantallaYPrecio()
        {
            dataReceta.DataSource = null;
            dataReceta.DataSource = listaTemporal;

            float subtotalNeto = 0;

            foreach (var item in listaTemporal)
            {
                var insumo = ((List<Insumos>)cmbIngredientes.DataSource)
                             .FirstOrDefault(i => i.Id == item.Id_Insumo1);

                if (insumo != null)
                {
                    subtotalNeto += calcularNetoRenglon(insumo.PrecioUnitario1, item.CantidadRequerida1);
                }
            }

            float iva = subtotalNeto * 0.19f;
            float totalFinal = subtotalNeto + iva;

            double netoRedondo = Math.Round(subtotalNeto, 0);
            double ivaRedondo = Math.Round(iva, 0);
            double totalRedondo = Math.Round(totalFinal, 0);

            lblPrecioSumado.Text = $"Neto: ${netoRedondo:N0} | IVA: ${ivaRedondo:N0} | Total: ${totalRedondo:N0}";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || listaTemporal.Count == 0)
            {
                MessageBox.Show("Faltan datos.");
                return;
            }

            float subtotalParaDB = 0;
            foreach (var item in listaTemporal)
            {
                var insumo = ((List<Insumos>)cmbIngredientes.DataSource)
                             .FirstOrDefault(i => i.Id == item.Id_Insumo1);
                if (insumo != null)
                    subtotalParaDB += calcularNetoRenglon(insumo.PrecioUnitario1, item.CantidadRequerida1);
            }
            float precioFinalConIva = (float)Math.Round(subtotalParaDB * 1.19f, 0);

            bool exito;

            if (productoExistente != null)
            {
                productoExistente.Nombre1 = txtNombre.Text;
                productoExistente.PrecioVenta1 = precioFinalConIva; 
                exito = productosDao.ActualizarProductoConReceta(productoExistente, listaTemporal);
            }
            else
            {
                ProductosClase productoNuevo = new ProductosClase();
                productoNuevo.Nombre1 = txtNombre.Text;
                productoNuevo.PrecioVenta1 = precioFinalConIva; 
                productoNuevo.Estado = true;
                exito = productosDao.GuardarProductoConReceta(productoNuevo, listaTemporal);
            }

            if (exito)
            {
                MessageBox.Show("Operación realizada con éxito.");
                this.Close();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataReceta.CurrentRow != null)
            {
                Receta item = (Receta)dataReceta.CurrentRow.DataBoundItem;

                cmbIngredientes.SelectedValue = item.Id_Insumo1;
                txtCantidad.Text = item.CantidadRequerida1.ToString();

                listaTemporal.Remove(item);

                ActualizarPantallaYPrecio();
            }
            else
            {
                MessageBox.Show("Seleccione un insumo de la tabla para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataReceta.CurrentRow != null)
            {
                Receta itemAEliminar = (Receta)dataReceta.CurrentRow.DataBoundItem;

                listaTemporal.Remove(itemAEliminar);
                ActualizarPantallaYPrecio();
                dataReceta.DataSource = null;
                dataReceta.DataSource = listaTemporal;
            }
            else
            {
                MessageBox.Show("Seleccione un ingrediente para quitar de la receta.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //para permitir 1 coma decimal no lo hice yo pero lo otro si
            //este de abajo permite numeros y el borrar pero no letras ni espacios
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
