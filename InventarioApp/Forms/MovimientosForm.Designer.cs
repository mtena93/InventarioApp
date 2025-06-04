namespace InventarioApp.Forms
{
    partial class MovimientosForm
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
            this.lblProducto = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cmbFiltroProducto = new System.Windows.Forms.ComboBox();
            this.cmbFiltroTipo = new System.Windows.Forms.ComboBox();
            this.txtFiltroCantidad = new System.Windows.Forms.TextBox();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.lblTotalFiltrado = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(12, 87);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(53, 13);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(71, 84);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(121, 21);
            this.cmbProducto.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(12, 124);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 13);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo: ";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(71, 121);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 163);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(55, 13);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad: ";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(71, 160);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(52, 20);
            this.txtCantidad.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRegistrar.Location = new System.Drawing.Point(129, 158);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(63, 22);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(198, 84);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.Size = new System.Drawing.Size(590, 293);
            this.dgvMovimientos.TabIndex = 7;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(713, 403);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cmbFiltroProducto
            // 
            this.cmbFiltroProducto.FormattingEnabled = true;
            this.cmbFiltroProducto.Location = new System.Drawing.Point(370, 58);
            this.cmbFiltroProducto.Name = "cmbFiltroProducto";
            this.cmbFiltroProducto.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltroProducto.TabIndex = 9;
            // 
            // cmbFiltroTipo
            // 
            this.cmbFiltroTipo.FormattingEnabled = true;
            this.cmbFiltroTipo.Location = new System.Drawing.Point(497, 58);
            this.cmbFiltroTipo.Name = "cmbFiltroTipo";
            this.cmbFiltroTipo.Size = new System.Drawing.Size(76, 21);
            this.cmbFiltroTipo.TabIndex = 10;
            // 
            // txtFiltroCantidad
            // 
            this.txtFiltroCantidad.Location = new System.Drawing.Point(579, 58);
            this.txtFiltroCantidad.Name = "txtFiltroCantidad";
            this.txtFiltroCantidad.Size = new System.Drawing.Size(53, 20);
            this.txtFiltroCantidad.TabIndex = 11;
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Location = new System.Drawing.Point(317, 61);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(34, 13);
            this.lblFiltros.TabIndex = 13;
            this.lblFiltros.Text = "Filtros";
            // 
            // dateDesde
            // 
            this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDesde.Location = new System.Drawing.Point(638, 58);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(72, 20);
            this.dateDesde.TabIndex = 14;
            // 
            // dateHasta
            // 
            this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateHasta.Location = new System.Drawing.Point(716, 58);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(72, 20);
            this.dateHasta.TabIndex = 15;
            // 
            // lblTotalFiltrado
            // 
            this.lblTotalFiltrado.AutoSize = true;
            this.lblTotalFiltrado.Location = new System.Drawing.Point(195, 390);
            this.lblTotalFiltrado.Name = "lblTotalFiltrado";
            this.lblTotalFiltrado.Size = new System.Drawing.Size(72, 13);
            this.lblTotalFiltrado.TabIndex = 16;
            this.lblTotalFiltrado.Text = "Resultados: 0";
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Blue;
            this.btnExportar.Location = new System.Drawing.Point(589, 403);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(118, 23);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // MovimientosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblTotalFiltrado);
            this.Controls.Add(this.dateHasta);
            this.Controls.Add(this.dateDesde);
            this.Controls.Add(this.lblFiltros);
            this.Controls.Add(this.txtFiltroCantidad);
            this.Controls.Add(this.cmbFiltroTipo);
            this.Controls.Add(this.cmbFiltroProducto);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.lblProducto);
            this.Name = "MovimientosForm";
            this.Text = "Movimientos de Stock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cmbFiltroProducto;
        private System.Windows.Forms.ComboBox cmbFiltroTipo;
        private System.Windows.Forms.TextBox txtFiltroCantidad;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label lblTotalFiltrado;
        private System.Windows.Forms.Button btnExportar;
    }
}