using GestionInventarioFoodStruck.Model;
using GestionInventarioFoodStruck.Dao;
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
    public partial class AgregarEditarInsumo : Form
    {
        private Insumos insumoLocal = null;
        InsumosDao insumosDao = new InsumosDao();

        public AgregarEditarInsumo(Insumos insumo = null)
        {
            InitializeComponent();
            this.insumoLocal = insumo;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidadMedida.SelectedIndex = 1;


        }


        private void AgregarEditarInsumo_Load(object sender, EventArgs e)
        {
            
            this.proveedoresTableAdapter.Fill(this.gestionInventarioDBDataSet.Proveedores);

            DataView proveedoresActivos = new DataView(this.gestionInventarioDBDataSet.Proveedores);

            
            proveedoresActivos.RowFilter = "estado = 1";

            cmbProveedor.DataSource = proveedoresActivos;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "Id";
          

            
            if (this.insumoLocal != null)
            {
                txtNombre.Text = insumoLocal.Nombre1;
                txtStockActual.Text = insumoLocal.StockActual1.ToString();
                txtPrecioUnitario.Text = insumoLocal.PrecioUnitario1.ToString();
                cmbUnidadMedida.Text = insumoLocal.UnidadMedida1;
                dtpFechaCaducidad.Value = insumoLocal.FechaCaducidad1;

                cmbProveedor.SelectedValue = insumoLocal.Id_Proveedor1;
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtStockActual.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos de texto.");
                    return;
                }
                if (float.Parse(txtPrecioUnitario.Text) < 0 || float.Parse(txtStockActual.Text)<0) {
                    MessageBox.Show("El precio y el stock debe ser numeros positivos..");
                    return;
                }

               
                if (cmbProveedor.SelectedValue == null)
                {
                    MessageBox.Show("No se puede crear un insumo sin su proveedor. Por favor, asegúrese de tener proveedores activos registrados.",
                                    "Proveedor requerido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; 
                }
         
                if (dtpFechaCaducidad.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("No se puede registrar un insumo que ya está vencido o vence antes de hoy.",
                                    "Fecha de caducidad inválida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand);
                    return;
                }

                int idActual = 0;
                if (this.insumoLocal != null)
                {
                    idActual = this.insumoLocal.Id;
                }

                if (insumosDao.existeInsumo(txtNombre.Text, idActual))
                {
                    MessageBox.Show("Ya existe un insumo registrado con este nombre. Por favor, ingrese un nombre diferente.",
                                    "Insumo Duplicado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (this.insumoLocal != null)
                {
                    insumoLocal.Nombre1 = txtNombre.Text;
                    insumoLocal.StockActual1 = float.Parse(txtStockActual.Text);
                    insumoLocal.PrecioUnitario1 = float.Parse(txtPrecioUnitario.Text);
                    insumoLocal.UnidadMedida1 = cmbUnidadMedida.Text;
                    insumoLocal.FechaCaducidad1 = dtpFechaCaducidad.Value;
                    insumoLocal.Id_Proveedor1 = Convert.ToInt32(cmbProveedor.SelectedValue);

                    bool respuesta = insumosDao.editarInsumo(insumoLocal);

                    if (respuesta) MessageBox.Show("Insumo actualizado con éxito.");
                    else MessageBox.Show("Error al actualizar el insumo.");
                }
                else
                {
                    Insumos insumoNuevo = new Insumos();
                    insumoNuevo.Nombre1 = txtNombre.Text;
                    insumoNuevo.StockActual1 = float.Parse(txtStockActual.Text);
                    insumoNuevo.PrecioUnitario1 = float.Parse(txtPrecioUnitario.Text);
                    insumoNuevo.UnidadMedida1 = cmbUnidadMedida.Text;
                    insumoNuevo.FechaCaducidad1 = dtpFechaCaducidad.Value;
                    insumoNuevo.Id_Proveedor1 = Convert.ToInt32(cmbProveedor.SelectedValue);

                    bool respuesta = insumosDao.agregarInsumo(insumoNuevo);

                    if (respuesta) MessageBox.Show("Insumo agregado con éxito.");
                    else MessageBox.Show("Error al agregar el insumo.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Asegúrese de ingresar solo números en los campos de 'Stock actual' y 'Precio unitario'.\nNo se permiten letras.",
                      "Error de formato",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else
            {
                
                e.Handled = true;
            }
        }
    }
}
