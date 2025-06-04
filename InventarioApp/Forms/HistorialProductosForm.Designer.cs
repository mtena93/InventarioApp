namespace InventarioApp.Forms
{
    partial class HistorialProductosForm
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
            this.dateHistorial = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblTotalBeneficio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // dateHistorial
            // 
            this.dateHistorial.Location = new System.Drawing.Point(75, 105);
            this.dateHistorial.Name = "dateHistorial";
            this.dateHistorial.Size = new System.Drawing.Size(183, 20);
            this.dateHistorial.TabIndex = 0;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(275, 105);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 1;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(75, 131);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(620, 166);
            this.dgvHistorial.TabIndex = 2;
            // 
            // lblTotalBeneficio
            // 
            this.lblTotalBeneficio.AutoSize = true;
            this.lblTotalBeneficio.Location = new System.Drawing.Point(568, 316);
            this.lblTotalBeneficio.Name = "lblTotalBeneficio";
            this.lblTotalBeneficio.Size = new System.Drawing.Size(81, 13);
            this.lblTotalBeneficio.TabIndex = 3;
            this.lblTotalBeneficio.Text = "Total Beneficio:";
            // 
            // HistorialProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotalBeneficio);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dateHistorial);
            this.Name = "HistorialProductosForm";
            this.Text = "HistorialProductosForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateHistorial;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblTotalBeneficio;
    }
}