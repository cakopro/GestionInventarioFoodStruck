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
            this.proveedoresTableAdapter.Fill(this.gestionInventarioDBDataSet.Proveedores);

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
                provedor.Estado = Convert.ToBoolean(fila["estado"]);


                AgregarEditarProveedores ventana = new AgregarEditarProveedores(provedor);
                ventana.ShowDialog();
                this.proveedoresTableAdapter.Fill(this.gestionInventarioDBDataSet.Proveedores);

            }
            else
            {
                MessageBox.Show("Dese seleccionar una fila para actualizar.", "Id incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataProveedores.CurrentRow != null) {
                DialogResult result = MessageBox.Show("¿Seguro que desea desactivar este proveedor?", "Confirmar", MessageBoxButtons.YesNo);
                DataRowView fila = (DataRowView)dataProveedores.CurrentRow.DataBoundItem;
                int id = Convert.ToInt32(fila["Id"]);
                ProveedoresDao provedor = new ProveedoresDao();
                ProveedoresDao dao = new ProveedoresDao();
                if (dao.eliminarProveedor(id))
                {
                    this.proveedoresTableAdapter.Fill(this.gestionInventarioDBDataSet.Proveedores);
                }

            }
            else
            {
                MessageBox.Show("Dese seleccionar una fila para eliminar.", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerInactivos.Checked)
            {
                proveedoresBindingSource.Filter = "estado = 0";
            }
            else
            {
                proveedoresBindingSource.Filter = "estado = 1";
            }
        }

        private void proveedorescs_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gestionInventarioDBDataSet.Proveedores' Puede moverla o quitarla según sea necesario.
            this.proveedoresTableAdapter.Fill(this.gestionInventarioDBDataSet.Proveedores);
            proveedoresBindingSource.Filter = "estado = 1";
        }
    }
}
