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
    public partial class proveedorescs : Form
    {
        public proveedorescs()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarProveedores ventana = new AgregarEditarProveedores();
            ventana.ShowDialog();
            this.proveedoresTableAdapter.Fill(this.gestionInventarioDBDataSet1.Proveedores);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataProveedores.CurrentRow != null)
            {
                DataRowView fila = (DataRowView)dataProveedores.CurrentRow.DataBoundItem;
                Proveedores provedor = new Proveedores();
                provedor.Id = Convert.ToInt32(fila["Id"]);
                provedor.Nombre = fila["Nombre"].ToString();
                provedor.Telefono = fila["Telefono"].ToString();
                provedor.Correo = fila["Correo"].ToString();
                provedor.Empresa = fila["Empresa"].ToString();
                provedor.Direccion = fila["Direccion"].ToString();

                AgregarEditarProveedores ventana = new AgregarEditarProveedores(provedor);
                ventana.ShowDialog();
                this.proveedoresTableAdapter.Fill(this.gestionInventarioDBDataSet1.Proveedores);

            }
            else
            {
                MessageBox.Show("Dese seleccionar una fila para actualizar.", "Id incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void proveedorescs_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gestionInventarioDBDataSet1.Proveedores' Puede moverla o quitarla según sea necesario.
            this.proveedoresTableAdapter.Fill(this.gestionInventarioDBDataSet1.Proveedores);

        }
    }
}
