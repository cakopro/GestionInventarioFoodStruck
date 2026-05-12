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
    public partial class Productos : Form
    {
        ProductosDao productosDao = new ProductosDao();
        public Productos()
        {
            InitializeComponent();
            dataProductos.AutoGenerateColumns = false;
            dataIngredientes.AutoGenerateColumns = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto ventana = new AgregarProducto();
            ventana.ShowDialog();
            actualizarTablaProductos();
        }

        void actualizarTablaProductos()
        {
            dataProductos.DataSource = null;
            dataProductos.DataSource = productosDao.traerTodo(checkBox1.Checked);
            dataIngredientes.DataSource = null;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            actualizarTablaProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataProductos.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea desactivar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ProductosClase prod = (ProductosClase)dataProductos.CurrentRow.DataBoundItem;

                    int id = prod.Id1;

                    if (productosDao.eliminarProducto(id))
                    {
                        MessageBox.Show("Producto desactivado correctamente.");
                        actualizarTablaProductos();
                    }

                }
                
            }else
                {
                    MessageBox.Show("Dese seleccionar una fila para eliminar.", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            actualizarTablaProductos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataProductos.CurrentRow != null)
            {
                ProductosClase producto = (ProductosClase)dataProductos.CurrentRow.DataBoundItem;
                var lista = productosDao.traerInsumos(producto.Id1);
                AgregarProducto ventana = new AgregarProducto(producto, lista);

                ventana.ShowDialog();
                actualizarTablaProductos();
            }
            else
            {
                MessageBox.Show("Dese seleccionar una fila para editar.", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dataProductos.CurrentRow != null && dataProductos.CurrentRow.DataBoundItem != null)
            {
                ProductosClase prod = (ProductosClase)dataProductos.CurrentRow.DataBoundItem;

                var listaInsumos = productosDao.traerInsumos(prod.Id1);

                dataIngredientes.DataSource = null;
                dataIngredientes.DataSource = listaInsumos;
            }
        }
    }
}
