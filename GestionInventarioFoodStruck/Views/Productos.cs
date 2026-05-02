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
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gestionInventarioDBDataSet.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.gestionInventarioDBDataSet.Productos);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataProductos.CurrentRow != null)
            {
                DataRowView fila = (DataRowView)dataProductos.CurrentRow.DataBoundItem;
                int id = Convert.ToInt32(fila["Id"]);
                var listaInsumos = productosDao.traerInsumos(id);
                dataIngredientes.DataSource = listaInsumos;
                dataIngredientes.Refresh();

            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto ventana = new AgregarProducto();
            ventana.ShowDialog();
            this.productosTableAdapter.Fill(this.gestionInventarioDBDataSet.Productos);
            dataIngredientes.DataSource = null;
        }
    }
}
