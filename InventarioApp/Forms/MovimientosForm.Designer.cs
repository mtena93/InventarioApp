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
            this.lblTotalFiltrado = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblAñadirMovimiento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.txtFiltroCantidad = new System.Windows.Forms.TextBox();
            this.lblFiltroCantidad = new System.Windows.Forms.Label();
            this.cmbFiltroTipo = new System.Windows.Forms.ComboBox();
            this.lblFiltroTipo = new System.Windows.Forms.Label();
            this.cmbFiltroProducto = new System.Windows.Forms.ComboBox();
            this.lblFiltroProducto = new System.Windows.Forms.Label();
            this.lblFiltros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(77, 197);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(53, 13);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(136, 194);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(121, 21);
            this.cmbProducto.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(77, 234);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 13);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo: ";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(136, 231);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(77, 273);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(55, 13);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad: ";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(136, 270);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(52, 20);
            this.txtCantidad.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRegistrar.Location = new System.Drawing.Point(194, 268);
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
            this.dgvMovimientos.Location = new System.Drawing.Point(295, 158);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.Size = new System.Drawing.Size(560, 258);
            this.dgvMovimientos.TabIndex = 7;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(855, 431);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(106, 23);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTotalFiltrado
            // 
            this.lblTotalFiltrado.AutoSize = true;
            this.lblTotalFiltrado.Location = new System.Drawing.Point(292, 431);
            this.lblTotalFiltrado.Name = "lblTotalFiltrado";
            this.lblTotalFiltrado.Size = new System.Drawing.Size(72, 13);
            this.lblTotalFiltrado.TabIndex = 16;
            this.lblTotalFiltrado.Text = "Resultados: 0";
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Blue;
            this.btnExportar.Location = new System.Drawing.Point(737, 129);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(118, 23);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblAñadirMovimiento
            // 
            this.lblAñadirMovimiento.AutoSize = true;
            this.lblAñadirMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAñadirMovimiento.Location = new System.Drawing.Point(80, 158);
            this.lblAñadirMovimiento.Name = "lblAñadirMovimiento";
            this.lblAñadirMovimiento.Size = new System.Drawing.Size(177, 20);
            this.lblAñadirMovimiento.TabIndex = 23;
            this.lblAñadirMovimiento.Text = "AÑADIR MOVIMIENTO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(424, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "MOVIMIENTOS DE STOCK";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.dateHasta);
            this.panel1.Controls.Add(this.lblHasta);
            this.panel1.Controls.Add(this.dateDesde);
            this.panel1.Controls.Add(this.lblDesde);
            this.panel1.Controls.Add(this.txtFiltroCantidad);
            this.panel1.Controls.Add(this.lblFiltroCantidad);
            this.panel1.Controls.Add(this.cmbFiltroTipo);
            this.panel1.Controls.Add(this.lblFiltroTipo);
            this.panel1.Controls.Add(this.cmbFiltroProducto);
            this.panel1.Controls.Add(this.lblFiltroProducto);
            this.panel1.Location = new System.Drawing.Point(855, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 258);
            this.panel1.TabIndex = 25;
            // 
            // dateHasta
            // 
            this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateHasta.Location = new System.Drawing.Point(14, 209);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(81, 20);
            this.dateHasta.TabIndex = 28;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(35, 193);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 27;
            this.lblHasta.Text = "Hasta";
            // 
            // dateDesde
            // 
            this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDesde.Location = new System.Drawing.Point(15, 170);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(81, 20);
            this.dateDesde.TabIndex = 26;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(33, 154);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 25;
            this.lblDesde.Text = "Desde";
            // 
            // txtFiltroCantidad
            // 
            this.txtFiltroCantidad.Location = new System.Drawing.Point(14, 121);
            this.txtFiltroCantidad.Name = "txtFiltroCantidad";
            this.txtFiltroCantidad.Size = new System.Drawing.Size(81, 20);
            this.txtFiltroCantidad.TabIndex = 24;
            // 
            // lblFiltroCantidad
            // 
            this.lblFiltroCantidad.AutoSize = true;
            this.lblFiltroCantidad.Location = new System.Drawing.Point(28, 105);
            this.lblFiltroCantidad.Name = "lblFiltroCantidad";
            this.lblFiltroCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblFiltroCantidad.TabIndex = 23;
            this.lblFiltroCantidad.Text = "Cantidad";
            // 
            // cmbFiltroTipo
            // 
            this.cmbFiltroTipo.FormattingEnabled = true;
            this.cmbFiltroTipo.Location = new System.Drawing.Point(14, 78);
            this.cmbFiltroTipo.Name = "cmbFiltroTipo";
            this.cmbFiltroTipo.Size = new System.Drawing.Size(81, 21);
            this.cmbFiltroTipo.TabIndex = 22;
            // 
            // lblFiltroTipo
            // 
            this.lblFiltroTipo.AutoSize = true;
            this.lblFiltroTipo.Location = new System.Drawing.Point(36, 63);
            this.lblFiltroTipo.Name = "lblFiltroTipo";
            this.lblFiltroTipo.Size = new System.Drawing.Size(28, 13);
            this.lblFiltroTipo.TabIndex = 21;
            this.lblFiltroTipo.Text = "Tipo";
            // 
            // cmbFiltroProducto
            // 
            this.cmbFiltroProducto.FormattingEnabled = true;
            this.cmbFiltroProducto.Location = new System.Drawing.Point(14, 38);
            this.cmbFiltroProducto.Name = "cmbFiltroProducto";
            this.cmbFiltroProducto.Size = new System.Drawing.Size(81, 21);
            this.cmbFiltroProducto.TabIndex = 20;
            // 
            // lblFiltroProducto
            // 
            this.lblFiltroProducto.AutoSize = true;
            this.lblFiltroProducto.Location = new System.Drawing.Point(27, 22);
            this.lblFiltroProducto.Name = "lblFiltroProducto";
            this.lblFiltroProducto.Size = new System.Drawing.Size(50, 13);
            this.lblFiltroProducto.TabIndex = 19;
            this.lblFiltroProducto.Text = "Producto";
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltros.Location = new System.Drawing.Point(880, 132);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(52, 20);
            this.lblFiltros.TabIndex = 14;
            this.lblFiltros.Text = "Filtros";
            // 
            // MovimientosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 595);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAñadirMovimiento);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblTotalFiltrado);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblFiltros);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.lblProducto);
            this.Name = "MovimientosForm";
            this.Text = "Movimientos de Stock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label lblTotalFiltrado;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblAñadirMovimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.TextBox txtFiltroCantidad;
        private System.Windows.Forms.Label lblFiltroCantidad;
        private System.Windows.Forms.ComboBox cmbFiltroTipo;
        private System.Windows.Forms.Label lblFiltroTipo;
        private System.Windows.Forms.ComboBox cmbFiltroProducto;
        private System.Windows.Forms.Label lblFiltroProducto;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label lblHasta;
    }
}