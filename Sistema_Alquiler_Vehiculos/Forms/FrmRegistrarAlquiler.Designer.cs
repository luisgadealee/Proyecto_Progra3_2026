namespace Sistema_Alquiler_Vehiculos.Forms
{
    partial class FrmRegistrarAlquiler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrarAlquiler));
            this.grpVehiculo = new System.Windows.Forms.GroupBox();
            this.grpAlquiler = new System.Windows.Forms.GroupBox();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblMarcaModelo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblPlacaValor = new System.Windows.Forms.Label();
            this.lblMarcaModeloValor = new System.Windows.Forms.Label();
            this.lblTipoValor = new System.Windows.Forms.Label();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblCosto = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblCostoValor = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbTarifa = new System.Windows.Forms.ComboBox();
            this.grpVehiculo.SuspendLayout();
            this.grpAlquiler.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpVehiculo
            // 
            this.grpVehiculo.Controls.Add(this.lblTipoValor);
            this.grpVehiculo.Controls.Add(this.lblMarcaModeloValor);
            this.grpVehiculo.Controls.Add(this.lblPlacaValor);
            this.grpVehiculo.Controls.Add(this.lblTipo);
            this.grpVehiculo.Controls.Add(this.lblMarcaModelo);
            this.grpVehiculo.Controls.Add(this.lblPlaca);
            this.grpVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.grpVehiculo.Location = new System.Drawing.Point(12, 12);
            this.grpVehiculo.Name = "grpVehiculo";
            this.grpVehiculo.Size = new System.Drawing.Size(408, 169);
            this.grpVehiculo.TabIndex = 0;
            this.grpVehiculo.TabStop = false;
            this.grpVehiculo.Text = "Datos del Vehiculo";
            // 
            // grpAlquiler
            // 
            this.grpAlquiler.Controls.Add(this.cmbTarifa);
            this.grpAlquiler.Controls.Add(this.lblCostoValor);
            this.grpAlquiler.Controls.Add(this.dtpFechaFin);
            this.grpAlquiler.Controls.Add(this.lblCosto);
            this.grpAlquiler.Controls.Add(this.dtpFechaInicio);
            this.grpAlquiler.Controls.Add(this.lblFechaFin);
            this.grpAlquiler.Controls.Add(this.lblFechaInicio);
            this.grpAlquiler.Controls.Add(this.lblTarifa);
            this.grpAlquiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAlquiler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.grpAlquiler.Location = new System.Drawing.Point(12, 187);
            this.grpAlquiler.Name = "grpAlquiler";
            this.grpAlquiler.Size = new System.Drawing.Size(408, 169);
            this.grpAlquiler.TabIndex = 1;
            this.grpAlquiler.TabStop = false;
            this.grpAlquiler.Text = "Datos del Alquiler";
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.Location = new System.Drawing.Point(15, 36);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(73, 25);
            this.lblPlaca.TabIndex = 0;
            this.lblPlaca.Text = "Placa:";
            // 
            // lblMarcaModelo
            // 
            this.lblMarcaModelo.AutoSize = true;
            this.lblMarcaModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcaModelo.Location = new System.Drawing.Point(15, 78);
            this.lblMarcaModelo.Name = "lblMarcaModelo";
            this.lblMarcaModelo.Size = new System.Drawing.Size(103, 25);
            this.lblMarcaModelo.TabIndex = 1;
            this.lblMarcaModelo.Text = "Vehiculo:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(15, 123);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(62, 25);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblPlacaValor
            // 
            this.lblPlacaValor.AutoSize = true;
            this.lblPlacaValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacaValor.ForeColor = System.Drawing.Color.White;
            this.lblPlacaValor.Location = new System.Drawing.Point(179, 36);
            this.lblPlacaValor.Name = "lblPlacaValor";
            this.lblPlacaValor.Size = new System.Drawing.Size(0, 25);
            this.lblPlacaValor.TabIndex = 3;
            // 
            // lblMarcaModeloValor
            // 
            this.lblMarcaModeloValor.AutoSize = true;
            this.lblMarcaModeloValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcaModeloValor.ForeColor = System.Drawing.Color.White;
            this.lblMarcaModeloValor.Location = new System.Drawing.Point(179, 78);
            this.lblMarcaModeloValor.Name = "lblMarcaModeloValor";
            this.lblMarcaModeloValor.Size = new System.Drawing.Size(0, 25);
            this.lblMarcaModeloValor.TabIndex = 4;
            // 
            // lblTipoValor
            // 
            this.lblTipoValor.AutoSize = true;
            this.lblTipoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoValor.ForeColor = System.Drawing.Color.White;
            this.lblTipoValor.Location = new System.Drawing.Point(179, 123);
            this.lblTipoValor.Name = "lblTipoValor";
            this.lblTipoValor.Size = new System.Drawing.Size(0, 25);
            this.lblTipoValor.TabIndex = 5;
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifa.Location = new System.Drawing.Point(15, 26);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(75, 25);
            this.lblTarifa.TabIndex = 3;
            this.lblTarifa.Text = "Tarifa:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(15, 61);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(136, 25);
            this.lblFechaInicio.TabIndex = 4;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(15, 95);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(115, 25);
            this.lblFechaFin.TabIndex = 5;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(157, 61);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(233, 30);
            this.dtpFechaInicio.TabIndex = 6;
            this.dtpFechaInicio.Value = new System.DateTime(2026, 4, 13, 17, 32, 24, 0);
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(15, 131);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(171, 25);
            this.lblCosto.TabIndex = 7;
            this.lblCosto.Text = "Costo Estimado:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(157, 97);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(233, 30);
            this.dtpFechaFin.TabIndex = 8;
            this.dtpFechaFin.Value = new System.DateTime(2026, 4, 13, 17, 32, 24, 0);
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // lblCostoValor
            // 
            this.lblCostoValor.AutoSize = true;
            this.lblCostoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoValor.ForeColor = System.Drawing.Color.White;
            this.lblCostoValor.Location = new System.Drawing.Point(179, 131);
            this.lblCostoValor.Name = "lblCostoValor";
            this.lblCostoValor.Size = new System.Drawing.Size(42, 25);
            this.lblCostoValor.TabIndex = 9;
            this.lblCostoValor.Text = "0.0";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmar.Location = new System.Drawing.Point(14, 376);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(177, 50);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(243, 376);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(177, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbTarifa
            // 
            this.cmbTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarifa.FormattingEnabled = true;
            this.cmbTarifa.Location = new System.Drawing.Point(157, 23);
            this.cmbTarifa.Name = "cmbTarifa";
            this.cmbTarifa.Size = new System.Drawing.Size(233, 33);
            this.cmbTarifa.TabIndex = 10;
            this.cmbTarifa.SelectedIndexChanged += new System.EventHandler(this.cmbTarifa_SelectedIndexChanged);
            // 
            // FrmRegistrarAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(432, 453);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.grpAlquiler);
            this.Controls.Add(this.grpVehiculo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistrarAlquiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Alquiler";
            this.Load += new System.EventHandler(this.FrmRegistrarAlquiler_Load);
            this.grpVehiculo.ResumeLayout(false);
            this.grpVehiculo.PerformLayout();
            this.grpAlquiler.ResumeLayout(false);
            this.grpAlquiler.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVehiculo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblMarcaModelo;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.GroupBox grpAlquiler;
        private System.Windows.Forms.Label lblTipoValor;
        private System.Windows.Forms.Label lblMarcaModeloValor;
        private System.Windows.Forms.Label lblPlacaValor;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblCostoValor;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbTarifa;
    }
}