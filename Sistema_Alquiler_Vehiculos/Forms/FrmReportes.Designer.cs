namespace Sistema_Alquiler_Vehiculos.Forms
{
    partial class FrmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            this.cmbDetalleTransacciones = new System.Windows.Forms.GroupBox();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.grpIngresosRentas = new System.Windows.Forms.GroupBox();
            this.lblTotalRenta = new System.Windows.Forms.Label();
            this.grpMultas = new System.Windows.Forms.GroupBox();
            this.lblTotalMulta = new System.Windows.Forms.Label();
            this.grpDanios = new System.Windows.Forms.GroupBox();
            this.lblTotalDanio = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cmbDetalleTransacciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.grpIngresosRentas.SuspendLayout();
            this.grpMultas.SuspendLayout();
            this.grpDanios.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDetalleTransacciones
            // 
            this.cmbDetalleTransacciones.Controls.Add(this.dgvPagos);
            this.cmbDetalleTransacciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDetalleTransacciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.cmbDetalleTransacciones.Location = new System.Drawing.Point(12, 213);
            this.cmbDetalleTransacciones.Name = "cmbDetalleTransacciones";
            this.cmbDetalleTransacciones.Size = new System.Drawing.Size(808, 228);
            this.cmbDetalleTransacciones.TabIndex = 16;
            this.cmbDetalleTransacciones.TabStop = false;
            this.cmbDetalleTransacciones.Text = "Detalle de Transacciones";
            // 
            // dgvPagos
            // 
            this.dgvPagos.BackgroundColor = System.Drawing.Color.Black;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagos.Location = new System.Drawing.Point(3, 26);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.RowHeadersWidth = 51;
            this.dgvPagos.RowTemplate.Height = 24;
            this.dgvPagos.Size = new System.Drawing.Size(802, 199);
            this.dgvPagos.TabIndex = 0;
            // 
            // grpIngresosRentas
            // 
            this.grpIngresosRentas.Controls.Add(this.lblTotalRenta);
            this.grpIngresosRentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpIngresosRentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.grpIngresosRentas.Location = new System.Drawing.Point(9, 81);
            this.grpIngresosRentas.Name = "grpIngresosRentas";
            this.grpIngresosRentas.Size = new System.Drawing.Size(238, 126);
            this.grpIngresosRentas.TabIndex = 17;
            this.grpIngresosRentas.TabStop = false;
            this.grpIngresosRentas.Text = "Ingresos Rentas";
            // 
            // lblTotalRenta
            // 
            this.lblTotalRenta.AutoSize = true;
            this.lblTotalRenta.BackColor = System.Drawing.Color.Black;
            this.lblTotalRenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTotalRenta.Location = new System.Drawing.Point(38, 61);
            this.lblTotalRenta.Name = "lblTotalRenta";
            this.lblTotalRenta.Size = new System.Drawing.Size(42, 25);
            this.lblTotalRenta.TabIndex = 1;
            this.lblTotalRenta.Text = "0.0";
            // 
            // grpMultas
            // 
            this.grpMultas.Controls.Add(this.lblTotalMulta);
            this.grpMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMultas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.grpMultas.Location = new System.Drawing.Point(303, 81);
            this.grpMultas.Name = "grpMultas";
            this.grpMultas.Size = new System.Drawing.Size(238, 126);
            this.grpMultas.TabIndex = 18;
            this.grpMultas.TabStop = false;
            this.grpMultas.Text = "Ingresos Multas";
            // 
            // lblTotalMulta
            // 
            this.lblTotalMulta.AutoSize = true;
            this.lblTotalMulta.BackColor = System.Drawing.Color.Black;
            this.lblTotalMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMulta.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalMulta.Location = new System.Drawing.Point(54, 61);
            this.lblTotalMulta.Name = "lblTotalMulta";
            this.lblTotalMulta.Size = new System.Drawing.Size(42, 25);
            this.lblTotalMulta.TabIndex = 1;
            this.lblTotalMulta.Text = "0.0";
            // 
            // grpDanios
            // 
            this.grpDanios.Controls.Add(this.lblTotalDanio);
            this.grpDanios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.grpDanios.Location = new System.Drawing.Point(579, 81);
            this.grpDanios.Name = "grpDanios";
            this.grpDanios.Size = new System.Drawing.Size(238, 126);
            this.grpDanios.TabIndex = 18;
            this.grpDanios.TabStop = false;
            this.grpDanios.Text = "Ingresos Danios";
            // 
            // lblTotalDanio
            // 
            this.lblTotalDanio.AutoSize = true;
            this.lblTotalDanio.BackColor = System.Drawing.Color.Black;
            this.lblTotalDanio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDanio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalDanio.Location = new System.Drawing.Point(52, 61);
            this.lblTotalDanio.Name = "lblTotalDanio";
            this.lblTotalDanio.Size = new System.Drawing.Size(42, 25);
            this.lblTotalDanio.TabIndex = 1;
            this.lblTotalDanio.Text = "0.0";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Black;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.lblHeader.Location = new System.Drawing.Point(8, 26);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(708, 38);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Dashboard de Ingresos y Auditoria de Pagos";
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.grpDanios);
            this.Controls.Add(this.grpMultas);
            this.Controls.Add(this.grpIngresosRentas);
            this.Controls.Add(this.cmbDetalleTransacciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Control Financiero";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.cmbDetalleTransacciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.grpIngresosRentas.ResumeLayout(false);
            this.grpIngresosRentas.PerformLayout();
            this.grpMultas.ResumeLayout(false);
            this.grpMultas.PerformLayout();
            this.grpDanios.ResumeLayout(false);
            this.grpDanios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox cmbDetalleTransacciones;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.GroupBox grpIngresosRentas;
        private System.Windows.Forms.Label lblTotalRenta;
        private System.Windows.Forms.GroupBox grpMultas;
        private System.Windows.Forms.Label lblTotalMulta;
        private System.Windows.Forms.GroupBox grpDanios;
        private System.Windows.Forms.Label lblTotalDanio;
        private System.Windows.Forms.Label lblHeader;
    }
}