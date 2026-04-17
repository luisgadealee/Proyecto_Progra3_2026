namespace Sistema_Alquiler_Vehiculos.Forms
{
    partial class FrmRegistrarDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrarDevolucion));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.grpCheckOut = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.grpInformacionAlquiler = new System.Windows.Forms.GroupBox();
            this.txtFechaPactada = new System.Windows.Forms.TextBox();
            this.txtVehiculo = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblTipoValor = new System.Windows.Forms.Label();
            this.lblMarcaModeloValor = new System.Windows.Forms.Label();
            this.lblPlacaValor = new System.Windows.Forms.Label();
            this.lblFechaPactada = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dtpFechaDevolucion = new System.Windows.Forms.DateTimePicker();
            this.txtCostoDanios = new System.Windows.Forms.TextBox();
            this.lblCostoDanios = new System.Windows.Forms.Label();
            this.chkDanios = new System.Windows.Forms.CheckBox();
            this.grpCheckOut.SuspendLayout();
            this.grpInformacionAlquiler.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(251, 343);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(177, 50);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.ForeColor = System.Drawing.Color.Black;
            this.btnProcesar.Location = new System.Drawing.Point(7, 345);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(177, 46);
            this.btnProcesar.TabIndex = 20;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // grpCheckOut
            // 
            this.grpCheckOut.Controls.Add(this.chkDanios);
            this.grpCheckOut.Controls.Add(this.dtpFechaDevolucion);
            this.grpCheckOut.Controls.Add(this.txtCostoDanios);
            this.grpCheckOut.Controls.Add(this.label5);
            this.grpCheckOut.Controls.Add(this.label6);
            this.grpCheckOut.Controls.Add(this.lblCostoDanios);
            this.grpCheckOut.Controls.Add(this.lblFechaEntrega);
            this.grpCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.grpCheckOut.Location = new System.Drawing.Point(5, 175);
            this.grpCheckOut.Name = "grpCheckOut";
            this.grpCheckOut.Size = new System.Drawing.Size(423, 162);
            this.grpCheckOut.TabIndex = 19;
            this.grpCheckOut.TabStop = false;
            this.grpCheckOut.Text = "Check-out";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(175, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 25);
            this.label5.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(179, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 25);
            this.label6.TabIndex = 3;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEntrega.Location = new System.Drawing.Point(9, 36);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(190, 25);
            this.lblFechaEntrega.TabIndex = 0;
            this.lblFechaEntrega.Text = "Fecha de Entrega:";
            // 
            // grpInformacionAlquiler
            // 
            this.grpInformacionAlquiler.Controls.Add(this.txtFechaPactada);
            this.grpInformacionAlquiler.Controls.Add(this.txtVehiculo);
            this.grpInformacionAlquiler.Controls.Add(this.txtCliente);
            this.grpInformacionAlquiler.Controls.Add(this.lblTipoValor);
            this.grpInformacionAlquiler.Controls.Add(this.lblMarcaModeloValor);
            this.grpInformacionAlquiler.Controls.Add(this.lblPlacaValor);
            this.grpInformacionAlquiler.Controls.Add(this.lblFechaPactada);
            this.grpInformacionAlquiler.Controls.Add(this.lblApellido);
            this.grpInformacionAlquiler.Controls.Add(this.lblCliente);
            this.grpInformacionAlquiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInformacionAlquiler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(60)))));
            this.grpInformacionAlquiler.Location = new System.Drawing.Point(5, 12);
            this.grpInformacionAlquiler.Name = "grpInformacionAlquiler";
            this.grpInformacionAlquiler.Size = new System.Drawing.Size(423, 157);
            this.grpInformacionAlquiler.TabIndex = 18;
            this.grpInformacionAlquiler.TabStop = false;
            this.grpInformacionAlquiler.Text = "Informacion del Alquiler";
            // 
            // txtFechaPactada
            // 
            this.txtFechaPactada.Location = new System.Drawing.Point(125, 109);
            this.txtFechaPactada.Name = "txtFechaPactada";
            this.txtFechaPactada.ReadOnly = true;
            this.txtFechaPactada.Size = new System.Drawing.Size(283, 30);
            this.txtFechaPactada.TabIndex = 11;
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.Location = new System.Drawing.Point(125, 73);
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.ReadOnly = true;
            this.txtVehiculo.Size = new System.Drawing.Size(283, 30);
            this.txtVehiculo.TabIndex = 10;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(125, 38);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(283, 30);
            this.txtCliente.TabIndex = 9;
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
            // lblFechaPactada
            // 
            this.lblFechaPactada.AutoSize = true;
            this.lblFechaPactada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPactada.Location = new System.Drawing.Point(9, 112);
            this.lblFechaPactada.Name = "lblFechaPactada";
            this.lblFechaPactada.Size = new System.Drawing.Size(115, 25);
            this.lblFechaPactada.TabIndex = 2;
            this.lblFechaPactada.Text = "Fecha Fin:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(9, 78);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(103, 25);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Vehiculo:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(9, 41);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(87, 25);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // dtpFechaDevolucion
            // 
            this.dtpFechaDevolucion.Location = new System.Drawing.Point(196, 31);
            this.dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            this.dtpFechaDevolucion.Size = new System.Drawing.Size(212, 30);
            this.dtpFechaDevolucion.TabIndex = 12;
            // 
            // txtCostoDanios
            // 
            this.txtCostoDanios.Enabled = false;
            this.txtCostoDanios.Location = new System.Drawing.Point(161, 117);
            this.txtCostoDanios.Name = "txtCostoDanios";
            this.txtCostoDanios.Size = new System.Drawing.Size(256, 30);
            this.txtCostoDanios.TabIndex = 10;
            this.txtCostoDanios.Text = "0.00";
            // 
            // lblCostoDanios
            // 
            this.lblCostoDanios.AutoSize = true;
            this.lblCostoDanios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoDanios.Location = new System.Drawing.Point(9, 97);
            this.lblCostoDanios.Name = "lblCostoDanios";
            this.lblCostoDanios.Size = new System.Drawing.Size(150, 50);
            this.lblCostoDanios.TabIndex = 1;
            this.lblCostoDanios.Text = "Costo \r\nde Danios ($):";
            // 
            // chkDanios
            // 
            this.chkDanios.AutoSize = true;
            this.chkDanios.Location = new System.Drawing.Point(14, 64);
            this.chkDanios.Name = "chkDanios";
            this.chkDanios.Size = new System.Drawing.Size(372, 29);
            this.chkDanios.TabIndex = 13;
            this.chkDanios.Text = "El vehiculo presenta danios fisicos.";
            this.chkDanios.UseVisualStyleBackColor = true;
            this.chkDanios.CheckedChanged += new System.EventHandler(this.chkDanios_CheckedChanged);
            // 
            // FrmRegistrarDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(432, 403);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.grpCheckOut);
            this.Controls.Add(this.grpInformacionAlquiler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistrarDevolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Devolucion de Vehiculo";
            this.Load += new System.EventHandler(this.FrmRegistrarDevolucion_Load);
            this.grpCheckOut.ResumeLayout(false);
            this.grpCheckOut.PerformLayout();
            this.grpInformacionAlquiler.ResumeLayout(false);
            this.grpInformacionAlquiler.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.GroupBox grpCheckOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.GroupBox grpInformacionAlquiler;
        private System.Windows.Forms.TextBox txtFechaPactada;
        private System.Windows.Forms.TextBox txtVehiculo;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblTipoValor;
        private System.Windows.Forms.Label lblMarcaModeloValor;
        private System.Windows.Forms.Label lblPlacaValor;
        private System.Windows.Forms.Label lblFechaPactada;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DateTimePicker dtpFechaDevolucion;
        private System.Windows.Forms.TextBox txtCostoDanios;
        private System.Windows.Forms.Label lblCostoDanios;
        private System.Windows.Forms.CheckBox chkDanios;
    }
}