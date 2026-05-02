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
        public AgregarProducto()
        {
            InitializeComponent();
            dataReceta.AutoGenerateColumns = false;
            cargarCatalogo();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
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
            txtPrecio.Enabled = false;
        }
        void cargarCatalogo()
        {
            var listaInsumos = insumos.traerTodo();
            cmbIngredientes.DataSource = listaInsumos;
            cmbIngredientes.DisplayMember = "Nombre1";
            cmbIngredientes.ValueMember = "Id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || listaTemporal.Count == 0)
            {
                MessageBox.Show("Debe ingresar el nombre del producto y al menos un ingrediente.");
                return;
            }
            ProductosClase productoNuevo = new ProductosClase();
            productoNuevo.Nombre1 = txtNombre.Text;
            productoNuevo.PrecioVenta1 = int.Parse(txtPrecio.Text);

            bool exito = productosDao.GuardarProductoConReceta(productoNuevo, listaTemporal);

            if (exito)
            {
                MessageBox.Show("Producto y Receta guardados correctamente.");
                this.Close(); 
            }
        }
    }
}
