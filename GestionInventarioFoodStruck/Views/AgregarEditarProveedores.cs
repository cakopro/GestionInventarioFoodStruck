using GestionInventarioFoodStruck.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using GestionInventarioFoodStruck.Dao;

namespace GestionInventarioFoodStruck.Views
{
    public partial class AgregarEditarProveedores : Form
    {
        private Proveedores provedor = null;
        ProveedoresDao proveedoresDao = new ProveedoresDao();

        public AgregarEditarProveedores(Proveedores proveedor = null)
        {
            InitializeComponent();
            this.provedor = proveedor;
            configuracionVentana();
            this.ActiveControl = txtNombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            string correo = txtCorreo.Text;
            if (!validarCorreo(correo))
            {
                MessageBox.Show("Formato incorrecto de correo.");
                return;
            }


            if (provedor != null)
            {
                provedor.Nombre = txtNombre.Text;
                provedor.Telefono = txtTelefono.Text.Replace(" ", "");
                provedor.Correo = txtCorreo.Text;
                provedor.Empresa = txtEmpresa.Text;
                provedor.Direccion = txtDireccion.Text;
                if (cmbEstado.SelectedIndex == 0)
                {
                    provedor.Estado = true;
                }
                else
                {
                    provedor.Estado = false;
                }
                bool respuesta = proveedoresDao.editarProveedor(provedor);
                if (respuesta)
                {
                    MessageBox.Show("Proveedor actualizado con éxito.");

                }
                else
                {
                    MessageBox.Show("Error al actualizar.");

                }
                this.Close();
            }
            else
            {
                Proveedores provedorNuevo = new Proveedores();
                provedorNuevo.Nombre = txtNombre.Text;
                provedorNuevo.Telefono = txtTelefono.Text.Replace(" ", "");
                provedorNuevo.Correo = txtCorreo.Text;
                provedorNuevo.Empresa = txtEmpresa.Text;
                provedorNuevo.Direccion = txtDireccion.Text;
                provedorNuevo.Estado = true;
                bool respuesta = proveedoresDao.agregarProveedor(provedorNuevo);
                if (respuesta)
                {
                    MessageBox.Show("Proveedor agregado con éxito.");
                }
                else { 
                    MessageBox.Show("Error al agregar el proveedor.");
                }
            }
            this.Close();
        
        }
        private void configuracionVentana()
        {
            if (provedor != null)
            {
                this.Text = "Editar";
                lblTitulo.Text = "Editar datos";
                btnAccion.Text = "Guardar";

                txtNombre.Text = provedor.Nombre;
                txtNombre.ForeColor = Color.Black;
                txtTelefono.Text = provedor.Telefono;
                txtTelefono.ForeColor = Color.Black;
                txtCorreo.Text = provedor.Correo;
                txtCorreo.ForeColor = Color.Black;
                txtEmpresa.Text = provedor.Empresa;
                txtEmpresa.ForeColor = Color.Black;
                txtDireccion.Text = provedor.Direccion;
                txtDireccion.ForeColor = Color.Black;
                if(provedor.Estado)
                {
                    cmbEstado.SelectedIndex = 0;
                }
                else
                {
                    cmbEstado.SelectedIndex = 1;
                }
            }
            else
            {
                this.Text = "Agregar proveedor";
                btnAccion.Text = "Agregar";
                lblEstado.Visible = false;
                cmbEstado.Visible=false;
                lblTitulo.Text = "Agregar";
            }
        }

        private bool ValidarCampos()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                {
                    if (txt.ForeColor == Color.Gray || String.IsNullOrWhiteSpace(txt.Text))
                    {
                        MessageBox.Show("Por favor, completa todos los campos.");
                        return false;
                    }
                }
            }
            return true;
        }
        private bool validarCorreo(string email)
        {
            string expresion = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, expresion);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '+' && txtTelefono.SelectionStart == 0)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Pepe")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Pepe";
                txtNombre.ForeColor = Color.Gray;
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "+56 9 2343 3244")
            {
                txtTelefono.Text = "";
                txtTelefono.ForeColor = Color.Black;
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "+56 9 1234 5678";
                txtTelefono.ForeColor = Color.Gray;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "usuario@gmail.com";
                txtCorreo.ForeColor = Color.Gray;
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "usuario@gmail.com")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.Black;
            }
        }

        private void txtEmpresa_Enter(object sender, EventArgs e)
        {
            if (txtEmpresa.Text == "Verduras con cako")
            {
                txtEmpresa.Text = "";
                txtEmpresa.ForeColor = Color.Black;
            }
        }

        private void txtEmpresa_Leave(object sender, EventArgs e)
        {
            if (txtEmpresa.Text == "")
            {
                txtEmpresa.Text = "Verduras con cako";
                txtEmpresa.ForeColor = Color.Gray;
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Av. Libertador Bernardo O'Higgins 1234";
                txtDireccion.ForeColor = Color.Gray;
            }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "Av. Libertador Bernardo O'Higgins 1234")
            {
                txtDireccion.Text = "";
                txtDireccion.ForeColor = Color.Black;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
