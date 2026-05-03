namespace GestionInventarioFoodStruck.Views
{
    partial class Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataProductos = new System.Windows.Forms.DataGridView();
            this.productosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gestionInventarioDBDataSet = new GestionInventarioFoodStruck.GestionInventarioDBDataSet();
            this.dataIngredientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.productosTableAdapter = new GestionInventarioFoodStruck.GestionInventarioDBDataSetTableAdapters.ProductosTableAdapter();
            this.gestionInventarioDBDataSet5 = new GestionInventarioFoodStruck.GestionInventarioDBDataSet5();
            this.proveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proveedoresTableAdapter = new GestionInventarioFoodStruck.GestionInventarioDBDataSet5TableAdapters.ProveedoresTableAdapter();
            this.gestionInventarioDBDataSet4 = new GestionInventarioFoodStruck.GestionInventarioDBDataSet4();
            this.gestionInventarioDBDataSet4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productosTableAdapter1 = new GestionInventarioFoodStruck.GestionInventarioDBDataSet4TableAdapters.ProductosTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productosBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.gestionInventarioDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productosBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.detalleVentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detalleVentaTableAdapter = new GestionInventarioFoodStruck.GestionInventarioDBDataSet5TableAdapters.DetalleVentaTableAdapter();
            this.recetasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recetasTableAdapter = new GestionInventarioFoodStruck.GestionInventarioDBDataSet5TableAdapters.RecetasTableAdapter();
            this.productosBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.recetasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.recetasTableAdapter1 = new GestionInventarioFoodStruck.GestionInventarioDBDataSet4TableAdapters.RecetasTableAdapter();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idInsumoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadRequeridaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataIngredientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetasBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataProductos
            // 
            this.dataProductos.AllowUserToAddRows = false;
            this.dataProductos.AllowUserToDeleteRows = false;
            this.dataProductos.AutoGenerateColumns = false;
            this.dataProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.precioVentaDataGridViewTextBoxColumn});
            this.dataProductos.DataSource = this.productosBindingSource4;
            this.dataProductos.Location = new System.Drawing.Point(34, 97);
            this.dataProductos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataProductos.Name = "dataProductos";
            this.dataProductos.ReadOnly = true;
            this.dataProductos.RowHeadersWidth = 82;
            this.dataProductos.RowTemplate.Height = 33;
            this.dataProductos.Size = new System.Drawing.Size(424, 154);
            this.dataProductos.TabIndex = 0;
            this.dataProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProductos_CellContentClick);
            this.dataProductos.SelectionChanged += new System.EventHandler(this.dataProductos_SelectionChanged);
            // 
            // productosBindingSource
            // 
            this.productosBindingSource.DataMember = "Productos";
            this.productosBindingSource.DataSource = this.gestionInventarioDBDataSet;
            // 
            // gestionInventarioDBDataSet
            // 
            this.gestionInventarioDBDataSet.DataSetName = "GestionInventarioDBDataSet";
            this.gestionInventarioDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataIngredientes
            // 
            this.dataIngredientes.AllowUserToAddRows = false;
            this.dataIngredientes.AllowUserToDeleteRows = false;
            this.dataIngredientes.AutoGenerateColumns = false;
            this.dataIngredientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataIngredientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.idProductoDataGridViewTextBoxColumn,
            this.idInsumoDataGridViewTextBoxColumn,
            this.cantidadRequeridaDataGridViewTextBoxColumn});
            this.dataIngredientes.DataSource = this.recetasBindingSource1;
            this.dataIngredientes.Location = new System.Drawing.Point(30, 281);
            this.dataIngredientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataIngredientes.Name = "dataIngredientes";
            this.dataIngredientes.ReadOnly = true;
            this.dataIngredientes.RowHeadersWidth = 82;
            this.dataIngredientes.RowTemplate.Height = 33;
            this.dataIngredientes.Size = new System.Drawing.Size(428, 154);
            this.dataIngredientes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Productos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 263);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingredientes";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(462, 97);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(151, 28);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // productosTableAdapter
            // 
            this.productosTableAdapter.ClearBeforeFill = true;
            // 
            // gestionInventarioDBDataSet5
            // 
            this.gestionInventarioDBDataSet5.DataSetName = "GestionInventarioDBDataSet5";
            this.gestionInventarioDBDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // proveedoresBindingSource
            // 
            this.proveedoresBindingSource.DataMember = "Proveedores";
            this.proveedoresBindingSource.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // proveedoresTableAdapter
            // 
            this.proveedoresTableAdapter.ClearBeforeFill = true;
            // 
            // gestionInventarioDBDataSet4
            // 
            this.gestionInventarioDBDataSet4.DataSetName = "GestionInventarioDBDataSet4";
            this.gestionInventarioDBDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gestionInventarioDBDataSet4BindingSource
            // 
            this.gestionInventarioDBDataSet4BindingSource.DataSource = this.gestionInventarioDBDataSet4;
            this.gestionInventarioDBDataSet4BindingSource.Position = 0;
            // 
            // productosBindingSource1
            // 
            this.productosBindingSource1.DataMember = "Productos";
            this.productosBindingSource1.DataSource = this.gestionInventarioDBDataSet4BindingSource;
            // 
            // productosTableAdapter1
            // 
            this.productosTableAdapter1.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            this.precioVentaDataGridViewTextBoxColumn.DataPropertyName = "PrecioVenta";
            this.precioVentaDataGridViewTextBoxColumn.HeaderText = "PrecioVenta";
            this.precioVentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            this.precioVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productosBindingSource2
            // 
            this.productosBindingSource2.DataMember = "Productos";
            this.productosBindingSource2.DataSource = this.gestionInventarioDBDataSet4;
            // 
            // gestionInventarioDBDataSetBindingSource
            // 
            this.gestionInventarioDBDataSetBindingSource.DataSource = this.gestionInventarioDBDataSet;
            this.gestionInventarioDBDataSetBindingSource.Position = 0;
            // 
            // productosBindingSource3
            // 
            this.productosBindingSource3.DataMember = "Productos";
            this.productosBindingSource3.DataSource = this.gestionInventarioDBDataSet4;
            // 
            // detalleVentaBindingSource
            // 
            this.detalleVentaBindingSource.DataMember = "DetalleVenta";
            this.detalleVentaBindingSource.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // detalleVentaTableAdapter
            // 
            this.detalleVentaTableAdapter.ClearBeforeFill = true;
            // 
            // recetasBindingSource
            // 
            this.recetasBindingSource.DataMember = "Recetas";
            this.recetasBindingSource.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // recetasTableAdapter
            // 
            this.recetasTableAdapter.ClearBeforeFill = true;
            // 
            // productosBindingSource4
            // 
            this.productosBindingSource4.DataMember = "Productos";
            this.productosBindingSource4.DataSource = this.gestionInventarioDBDataSet4;
            // 
            // recetasBindingSource1
            // 
            this.recetasBindingSource1.DataMember = "Recetas";
            this.recetasBindingSource1.DataSource = this.gestionInventarioDBDataSet4;
            // 
            // recetasTableAdapter1
            // 
            this.recetasTableAdapter1.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // idProductoDataGridViewTextBoxColumn
            // 
            this.idProductoDataGridViewTextBoxColumn.DataPropertyName = "Id_Producto";
            this.idProductoDataGridViewTextBoxColumn.HeaderText = "Id_Producto";
            this.idProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idProductoDataGridViewTextBoxColumn.Name = "idProductoDataGridViewTextBoxColumn";
            this.idProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idInsumoDataGridViewTextBoxColumn
            // 
            this.idInsumoDataGridViewTextBoxColumn.DataPropertyName = "Id_Insumo";
            this.idInsumoDataGridViewTextBoxColumn.HeaderText = "Id_Insumo";
            this.idInsumoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idInsumoDataGridViewTextBoxColumn.Name = "idInsumoDataGridViewTextBoxColumn";
            this.idInsumoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadRequeridaDataGridViewTextBoxColumn
            // 
            this.cantidadRequeridaDataGridViewTextBoxColumn.DataPropertyName = "CantidadRequerida";
            this.cantidadRequeridaDataGridViewTextBoxColumn.HeaderText = "CantidadRequerida";
            this.cantidadRequeridaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cantidadRequeridaDataGridViewTextBoxColumn.Name = "cantidadRequeridaDataGridViewTextBoxColumn";
            this.cantidadRequeridaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 463);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataIngredientes);
            this.Controls.Add(this.dataProductos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Productos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataIngredientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetasBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataProductos;
        private System.Windows.Forms.DataGridView dataIngredientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private GestionInventarioDBDataSet gestionInventarioDBDataSet;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private GestionInventarioDBDataSetTableAdapters.ProductosTableAdapter productosTableAdapter;
        private GestionInventarioDBDataSet5 gestionInventarioDBDataSet5;
        private System.Windows.Forms.BindingSource proveedoresBindingSource;
        private GestionInventarioDBDataSet5TableAdapters.ProveedoresTableAdapter proveedoresTableAdapter;
        private GestionInventarioDBDataSet4 gestionInventarioDBDataSet4;
        private System.Windows.Forms.BindingSource gestionInventarioDBDataSet4BindingSource;
        private System.Windows.Forms.BindingSource productosBindingSource1;
        private GestionInventarioDBDataSet4TableAdapters.ProductosTableAdapter productosTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productosBindingSource2;
        private System.Windows.Forms.BindingSource gestionInventarioDBDataSetBindingSource;
        private System.Windows.Forms.BindingSource productosBindingSource3;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource;
        private GestionInventarioDBDataSet5TableAdapters.DetalleVentaTableAdapter detalleVentaTableAdapter;
        private System.Windows.Forms.BindingSource recetasBindingSource;
        private GestionInventarioDBDataSet5TableAdapters.RecetasTableAdapter recetasTableAdapter;
        private System.Windows.Forms.BindingSource productosBindingSource4;
        private System.Windows.Forms.BindingSource recetasBindingSource1;
        private GestionInventarioDBDataSet4TableAdapters.RecetasTableAdapter recetasTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idInsumoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadRequeridaDataGridViewTextBoxColumn;
    }
}