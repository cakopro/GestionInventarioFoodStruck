namespace GestionInventarioFoodStruck.Views
{
    partial class Ventas
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.ventasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvHistorialVentas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnFinalizarCompra = new System.Windows.Forms.Button();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ventasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gestionInventarioDBDataSet5 = new GestionInventarioFoodStruck.GestionInventarioDBDataSet5();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleVentaBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.gestionInventarioDBDataSet5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detalleVentaBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.gestionInventarioDBDataSet = new GestionInventarioFoodStruck.GestionInventarioDBDataSet();
            this.gestionInventarioDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detalleVentaBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.gestionInventarioDBDataSet51 = new GestionInventarioFoodStruck.GestionInventarioDBDataSet5();
            this.detalleVentaBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.detalleVentaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.detalleVentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ventasTableAdapter = new GestionInventarioFoodStruck.GestionInventarioDBDataSet5TableAdapters.VentasTableAdapter();
            this.detalleVentaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.detalleVentaTableAdapter = new GestionInventarioFoodStruck.GestionInventarioDBDataSet5TableAdapters.DetalleVentaTableAdapter();
            this.ventasBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialVentas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(82, 9);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(187, 24);
            this.cmbProducto.TabIndex = 1;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Precio:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(357, 17);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(21, 16);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.Text = "0$";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad:";
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AutoGenerateColumns = false;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreProducto,
            this.idDataGridViewTextBoxColumn,
            this.idVentaDataGridViewTextBoxColumn,
            this.idProductoDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.subtotalDataGridViewTextBoxColumn});
            this.dgvDetalleVenta.DataSource = this.detalleVentaBindingSource6;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(3, 21);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.RowHeadersWidth = 51;
            this.dgvDetalleVenta.RowTemplate.Height = 24;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(853, 147);
            this.dgvDetalleVenta.TabIndex = 6;
            // 
            // ventasBindingSource
            // 
            this.ventasBindingSource.DataMember = "Ventas";
            this.ventasBindingSource.DataSource = this.gestionInventarioDBDataSet5BindingSource;
            // 
            // dgvHistorialVentas
            // 
            this.dgvHistorialVentas.AutoGenerateColumns = false;
            this.dgvHistorialVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.fechaDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.netoDataGridViewTextBoxColumn,
            this.iVADataGridViewTextBoxColumn});
            this.dgvHistorialVentas.DataSource = this.ventasBindingSource1;
            this.dgvHistorialVentas.Location = new System.Drawing.Point(0, 21);
            this.dgvHistorialVentas.Name = "dgvHistorialVentas";
            this.dgvHistorialVentas.RowHeadersWidth = 51;
            this.dgvHistorialVentas.RowTemplate.Height = 24;
            this.dgvHistorialVentas.Size = new System.Drawing.Size(956, 165);
            this.dgvHistorialVentas.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDetalleVenta);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(858, 174);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle venta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvHistorialVentas);
            this.groupBox2.Location = new System.Drawing.Point(15, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(956, 192);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Historial de ventas";
            // 
            // lblNeto
            // 
            this.lblNeto.AutoSize = true;
            this.lblNeto.Location = new System.Drawing.Point(284, 257);
            this.lblNeto.Name = "lblNeto";
            this.lblNeto.Size = new System.Drawing.Size(56, 16);
            this.lblNeto.TabIndex = 10;
            this.lblNeto.Text = "Neto: $0";
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(411, 257);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(85, 16);
            this.lblIVA.TabIndex = 11;
            this.lblIVA.Text = "IVA (19%): $0";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(908, 90);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(908, 148);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(908, 205);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 15;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnFinalizarCompra
            // 
            this.btnFinalizarCompra.Location = new System.Drawing.Point(15, 257);
            this.btnFinalizarCompra.Name = "btnFinalizarCompra";
            this.btnFinalizarCompra.Size = new System.Drawing.Size(135, 23);
            this.btnFinalizarCompra.TabIndex = 16;
            this.btnFinalizarCompra.Text = "Finalizar compra";
            this.btnFinalizarCompra.UseVisualStyleBackColor = true;
            this.btnFinalizarCompra.Click += new System.EventHandler(this.btnFinalizarCompra_Click);
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(587, 12);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(89, 22);
            this.numCantidad.TabIndex = 17;
            // 
            // NombreProducto
            // 
            this.NombreProducto.DataPropertyName = "NombreProducto";
            this.NombreProducto.HeaderText = "NombreProducto";
            this.NombreProducto.MinimumWidth = 6;
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            this.NombreProducto.Width = 125;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(567, 257);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(186, 16);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total a Pagar: $0";
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Width = 125;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.Width = 125;
            // 
            // netoDataGridViewTextBoxColumn
            // 
            this.netoDataGridViewTextBoxColumn.DataPropertyName = "Neto";
            this.netoDataGridViewTextBoxColumn.HeaderText = "Neto";
            this.netoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.netoDataGridViewTextBoxColumn.Name = "netoDataGridViewTextBoxColumn";
            this.netoDataGridViewTextBoxColumn.Width = 125;
            // 
            // iVADataGridViewTextBoxColumn
            // 
            this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
            this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
            this.iVADataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
            this.iVADataGridViewTextBoxColumn.Width = 125;
            // 
            // ventasBindingSource1
            // 
            this.ventasBindingSource1.DataMember = "Ventas";
            this.ventasBindingSource1.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // gestionInventarioDBDataSet5
            // 
            this.gestionInventarioDBDataSet5.DataSetName = "GestionInventarioDBDataSet5";
            this.gestionInventarioDBDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // idVentaDataGridViewTextBoxColumn
            // 
            this.idVentaDataGridViewTextBoxColumn.DataPropertyName = "Id_Venta";
            this.idVentaDataGridViewTextBoxColumn.HeaderText = "Id_Venta";
            this.idVentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idVentaDataGridViewTextBoxColumn.Name = "idVentaDataGridViewTextBoxColumn";
            this.idVentaDataGridViewTextBoxColumn.Width = 125;
            // 
            // idProductoDataGridViewTextBoxColumn
            // 
            this.idProductoDataGridViewTextBoxColumn.DataPropertyName = "Id_Producto";
            this.idProductoDataGridViewTextBoxColumn.HeaderText = "Id_Producto";
            this.idProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idProductoDataGridViewTextBoxColumn.Name = "idProductoDataGridViewTextBoxColumn";
            this.idProductoDataGridViewTextBoxColumn.Width = 125;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.Width = 125;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            this.subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            this.subtotalDataGridViewTextBoxColumn.Width = 125;
            // 
            // detalleVentaBindingSource6
            // 
            this.detalleVentaBindingSource6.DataMember = "DetalleVenta";
            this.detalleVentaBindingSource6.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // gestionInventarioDBDataSet5BindingSource
            // 
            this.gestionInventarioDBDataSet5BindingSource.DataSource = this.gestionInventarioDBDataSet5;
            this.gestionInventarioDBDataSet5BindingSource.Position = 0;
            // 
            // detalleVentaBindingSource5
            // 
            this.detalleVentaBindingSource5.DataMember = "DetalleVenta";
            this.detalleVentaBindingSource5.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // gestionInventarioDBDataSet
            // 
            this.gestionInventarioDBDataSet.DataSetName = "GestionInventarioDBDataSet";
            this.gestionInventarioDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gestionInventarioDBDataSetBindingSource
            // 
            this.gestionInventarioDBDataSetBindingSource.DataSource = this.gestionInventarioDBDataSet;
            this.gestionInventarioDBDataSetBindingSource.Position = 0;
            // 
            // detalleVentaBindingSource4
            // 
            this.detalleVentaBindingSource4.DataMember = "DetalleVenta";
            this.detalleVentaBindingSource4.DataSource = this.gestionInventarioDBDataSet51;
            // 
            // gestionInventarioDBDataSet51
            // 
            this.gestionInventarioDBDataSet51.DataSetName = "GestionInventarioDBDataSet5";
            this.gestionInventarioDBDataSet51.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // detalleVentaBindingSource3
            // 
            this.detalleVentaBindingSource3.DataMember = "DetalleVenta";
            this.detalleVentaBindingSource3.DataSource = this.gestionInventarioDBDataSet51;
            // 
            // detalleVentaBindingSource1
            // 
            this.detalleVentaBindingSource1.DataMember = "DetalleVenta";
            this.detalleVentaBindingSource1.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // detalleVentaBindingSource
            // 
            this.detalleVentaBindingSource.DataMember = "DetalleVenta";
            this.detalleVentaBindingSource.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // ventasTableAdapter
            // 
            this.ventasTableAdapter.ClearBeforeFill = true;
            // 
            // detalleVentaBindingSource2
            // 
            this.detalleVentaBindingSource2.DataMember = "DetalleVenta";
            this.detalleVentaBindingSource2.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // detalleVentaTableAdapter
            // 
            this.detalleVentaTableAdapter.ClearBeforeFill = true;
            // 
            // ventasBindingSource2
            // 
            this.ventasBindingSource2.DataMember = "Ventas";
            this.ventasBindingSource2.DataSource = this.gestionInventarioDBDataSet5;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 508);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnFinalizarCompra);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblNeto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.label1);
            this.Name = "Ventas";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialVentas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gestionInventarioDBDataSet51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalleVentaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private GestionInventarioDBDataSet gestionInventarioDBDataSet;
        private System.Windows.Forms.BindingSource gestionInventarioDBDataSetBindingSource;
        private System.Windows.Forms.BindingSource gestionInventarioDBDataSet5BindingSource;
        private GestionInventarioDBDataSet5 gestionInventarioDBDataSet5;
        private System.Windows.Forms.BindingSource ventasBindingSource;
        private GestionInventarioDBDataSet5TableAdapters.VentasTableAdapter ventasTableAdapter;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource1;
        private System.Windows.Forms.DataGridView dgvHistorialVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn netoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ventasBindingSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnFinalizarCompra;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource2;
        private GestionInventarioDBDataSet5 gestionInventarioDBDataSet51;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource3;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource4;
        private GestionInventarioDBDataSet5TableAdapters.DetalleVentaTableAdapter detalleVentaTableAdapter;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource5;
        private System.Windows.Forms.BindingSource detalleVentaBindingSource6;
        private System.Windows.Forms.BindingSource ventasBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblTotal;
    }
}