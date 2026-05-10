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
    public partial class InsumosView : Form
    {
        public InsumosView()
        {
            InitializeComponent();
        }

       

        private void btonAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarInsumo ventana = new AgregarEditarInsumo();
            ventana.ShowDialog();
            this.insumosTableAdapter.Fill(this.gestionInventarioDBDataSet.Insumos);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
              
                DataRowView fila = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;

               
                Model.Insumos insumoSeleccionado = new Model.Insumos();

                
                insumoSeleccionado.Id = Convert.ToInt32(fila["Id"]);
                insumoSeleccionado.Nombre1 = fila["Nombre"].ToString();
                insumoSeleccionado.StockActual1 = float.Parse(fila["StockActual"].ToString());
                insumoSeleccionado.UnidadMedida1 = fila["UnidadMedida"].ToString();
                insumoSeleccionado.PrecioUnitario1 = float.Parse(fila["PrecioUnitario"].ToString());
                insumoSeleccionado.FechaCaducidad1 = Convert.ToDateTime(fila["FechaCaducidad"]);
                insumoSeleccionado.Id_Proveedor1 = Convert.ToInt32(fila["Id_Proveedor"]);

               
                AgregarEditarInsumo ventana = new AgregarEditarInsumo(insumoSeleccionado);
                ventana.ShowDialog();


                this.insumosTableAdapter.Fill(this.gestionInventarioDBDataSet.Insumos);

            }
            else
            {
                
                MessageBox.Show("Debe seleccionar una fila para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentRow != null)
            {
              
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar este insumo permanentemente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

               
                if (respuesta == DialogResult.Yes)
                {
                    
                    DataRowView fila = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                    int idSeleccionado = Convert.ToInt32(fila["Id"]);

                  
                    Dao.InsumosDao insumosDao = new Dao.InsumosDao();
                    bool exito = insumosDao.eliminarInsumo(idSeleccionado);

                  
                    if (exito)
                    {
                        MessageBox.Show("Insumo eliminado correctamente.");
                        this.insumosTableAdapter.Fill(this.gestionInventarioDBDataSet.Insumos);

                    }
                }
            }
            else
            {
              
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InsumosView_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gestionInventarioDBDataSet.Insumos' Puede moverla o quitarla según sea necesario.
            this.insumosTableAdapter.Fill(this.gestionInventarioDBDataSet.Insumos);

        }
    }
}
