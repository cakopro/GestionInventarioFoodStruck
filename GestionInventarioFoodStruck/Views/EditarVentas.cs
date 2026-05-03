using System;
using System.Windows.Forms;

namespace GestionInventarioFoodStruck.Views
{
    public partial class Form2 : Form
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtProductoEditar.Text = this.NombreProducto;
            numCantidadEditar.Value = this.Cantidad;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            this.NombreProducto = txtProductoEditar.Text;
            this.Cantidad = (int)numCantidadEditar.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}