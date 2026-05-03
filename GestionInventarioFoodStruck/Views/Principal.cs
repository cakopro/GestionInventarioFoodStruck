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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirNuevoPanel(new proveedorescs());
        }

        private void abrirNuevoPanel(Form ventanaHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                Control controlAnterior = this.panelContenedor.Controls[0];

                this.panelContenedor.Controls.RemoveAt(0);

                if (controlAnterior is Form formularioAnterior)
                {
                    formularioAnterior.Close();
                    formularioAnterior.Dispose();
                }
            }
            ventanaHijo.TopLevel = false;
            ventanaHijo.FormBorderStyle = FormBorderStyle.None;
            ventanaHijo.Dock = DockStyle.Fill;

            this.panelContenedor.Controls.Add(ventanaHijo);
            this.panelContenedor.Tag = ventanaHijo;
            ventanaHijo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            abrirNuevoPanel(new Productos());
        }

        private void btnInsumo_Click(object sender, EventArgs e)
        {
            abrirNuevoPanel(new InsumosView());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            login ventanta = new login();
            this.Dispose();
            ventanta.Show();
        }
    }
}
