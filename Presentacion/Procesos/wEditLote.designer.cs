namespace Presentacion.Procesos
{
    partial class wEditLote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCodLot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtStoLot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpFecVenLot = new System.Windows.Forms.DateTimePicker();
            this.dtpFecProLot = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumLot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStoConLot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(277, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 25);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodLot
            // 
            this.txtCodLot.Location = new System.Drawing.Point(167, 55);
            this.txtCodLot.Name = "txtCodLot";
            this.txtCodLot.ReadOnly = true;
            this.txtCodLot.Size = new System.Drawing.Size(102, 22);
            this.txtCodLot.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "Lote";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(167, 227);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 25);
            this.btnAceptar.TabIndex = 48;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtStoLot
            // 
            this.txtStoLot.Location = new System.Drawing.Point(167, 195);
            this.txtStoLot.MaxLength = 7;
            this.txtStoLot.Name = "txtStoLot";
            this.txtStoLot.Size = new System.Drawing.Size(102, 22);
            this.txtStoLot.TabIndex = 52;
            this.txtStoLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStoLot.Validated += new System.EventHandler(this.txtStoLot_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 51;
            this.label6.Text = "Cantidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 14);
            this.label9.TabIndex = 63;
            this.label9.Text = "Fc. Vcto";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(32, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(349, 14);
            this.label21.TabIndex = 357;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFecVenLot
            // 
            this.dtpFecVenLot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecVenLot.Location = new System.Drawing.Point(167, 83);
            this.dtpFecVenLot.Name = "dtpFecVenLot";
            this.dtpFecVenLot.Size = new System.Drawing.Size(102, 22);
            this.dtpFecVenLot.TabIndex = 403;
            // 
            // dtpFecProLot
            // 
            this.dtpFecProLot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecProLot.Location = new System.Drawing.Point(167, 111);
            this.dtpFecProLot.Name = "dtpFecProLot";
            this.dtpFecProLot.Size = new System.Drawing.Size(102, 22);
            this.dtpFecProLot.TabIndex = 407;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 406;
            this.label1.Text = "Fc. Produccion";
            // 
            // txtNumLot
            // 
            this.txtNumLot.Location = new System.Drawing.Point(167, 139);
            this.txtNumLot.MaxLength = 7;
            this.txtNumLot.Name = "txtNumLot";
            this.txtNumLot.Size = new System.Drawing.Size(102, 22);
            this.txtNumLot.TabIndex = 405;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 404;
            this.label3.Text = "Numero Lote";
            // 
            // txtStoConLot
            // 
            this.txtStoConLot.Location = new System.Drawing.Point(167, 167);
            this.txtStoConLot.MaxLength = 7;
            this.txtStoConLot.Name = "txtStoConLot";
            this.txtStoConLot.ReadOnly = true;
            this.txtStoConLot.Size = new System.Drawing.Size(102, 22);
            this.txtStoConLot.TabIndex = 409;
            this.txtStoConLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStoConLot.Validated += new System.EventHandler(this.txtStoConLot_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 14);
            this.label4.TabIndex = 408;
            this.label4.Text = "Cantidad Conversion";
            // 
            // wEditLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(402, 276);
            this.ControlBox = false;
            this.Controls.Add(this.txtStoConLot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFecProLot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumLot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFecVenLot);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStoLot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCodLot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wEditLote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wDetalleIngreso_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCodLot, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtStoLot, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.dtpFecVenLot, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNumLot, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpFecProLot, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtStoConLot, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtStoLot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtCodLot;
        internal System.Windows.Forms.DateTimePicker dtpFecVenLot;
        internal System.Windows.Forms.DateTimePicker dtpFecProLot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumLot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStoConLot;
        private System.Windows.Forms.Label label4;
    }
}