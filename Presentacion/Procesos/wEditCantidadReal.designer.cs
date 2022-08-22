namespace Presentacion.Procesos
{
    partial class wEditCantidadReal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDev = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCanUniReaEnc = new System.Windows.Forms.TextBox();
            this.txtCodExi = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCanUniEnc = new System.Windows.Forms.TextBox();
            this.txtDesExi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumCaj = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCanCajReaEnc = new System.Windows.Forms.TextBox();
            this.txtUniXEmp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(395, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(281, 286);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(479, 14);
            this.label2.TabIndex = 76;
            this.label2.Text = "Datos generales";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 14);
            this.label8.TabIndex = 86;
            this.label8.Text = "Devueltas";
            // 
            // txtDev
            // 
            this.txtDev.Location = new System.Drawing.Point(215, 252);
            this.txtDev.MaxLength = 2;
            this.txtDev.Name = "txtDev";
            this.txtDev.ReadOnly = true;
            this.txtDev.Size = new System.Drawing.Size(118, 22);
            this.txtDev.TabIndex = 87;
            this.txtDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 14);
            this.label12.TabIndex = 92;
            this.label12.Text = "Unidades Real";
            // 
            // txtCanUniReaEnc
            // 
            this.txtCanUniReaEnc.Location = new System.Drawing.Point(215, 196);
            this.txtCanUniReaEnc.MaxLength = 2;
            this.txtCanUniReaEnc.Name = "txtCanUniReaEnc";
            this.txtCanUniReaEnc.Size = new System.Drawing.Size(118, 22);
            this.txtCanUniReaEnc.TabIndex = 93;
            this.txtCanUniReaEnc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanUniReaEnc.Validated += new System.EventHandler(this.txtCanUniReaEnc_Validated);
            // 
            // txtCodExi
            // 
            this.txtCodExi.Location = new System.Drawing.Point(215, 56);
            this.txtCodExi.MaxLength = 4;
            this.txtCodExi.Name = "txtCodExi";
            this.txtCodExi.ReadOnly = true;
            this.txtCodExi.Size = new System.Drawing.Size(75, 22);
            this.txtCodExi.TabIndex = 438;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 14);
            this.label14.TabIndex = 437;
            this.label14.Text = "Codigo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 14);
            this.label1.TabIndex = 439;
            this.label1.Text = "Unidades Plan";
            // 
            // txtCanUniEnc
            // 
            this.txtCanUniEnc.Location = new System.Drawing.Point(215, 140);
            this.txtCanUniEnc.MaxLength = 2;
            this.txtCanUniEnc.Name = "txtCanUniEnc";
            this.txtCanUniEnc.ReadOnly = true;
            this.txtCanUniEnc.Size = new System.Drawing.Size(118, 22);
            this.txtCanUniEnc.TabIndex = 440;
            this.txtCanUniEnc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(215, 84);
            this.txtDesExi.MaxLength = 4;
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(289, 22);
            this.txtDesExi.TabIndex = 442;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 441;
            this.label5.Text = "Descripcion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 443;
            this.label6.Text = "Cajas Plan";
            // 
            // txtNumCaj
            // 
            this.txtNumCaj.Location = new System.Drawing.Point(215, 168);
            this.txtNumCaj.MaxLength = 2;
            this.txtNumCaj.Name = "txtNumCaj";
            this.txtNumCaj.ReadOnly = true;
            this.txtNumCaj.Size = new System.Drawing.Size(118, 22);
            this.txtNumCaj.TabIndex = 444;
            this.txtNumCaj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 14);
            this.label9.TabIndex = 445;
            this.label9.Text = "Cajas Real";
            // 
            // txtCanCajReaEnc
            // 
            this.txtCanCajReaEnc.Location = new System.Drawing.Point(215, 224);
            this.txtCanCajReaEnc.MaxLength = 2;
            this.txtCanCajReaEnc.Name = "txtCanCajReaEnc";
            this.txtCanCajReaEnc.ReadOnly = true;
            this.txtCanCajReaEnc.Size = new System.Drawing.Size(118, 22);
            this.txtCanCajReaEnc.TabIndex = 446;
            this.txtCanCajReaEnc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUniXEmp
            // 
            this.txtUniXEmp.Location = new System.Drawing.Point(215, 112);
            this.txtUniXEmp.MaxLength = 7;
            this.txtUniXEmp.Name = "txtUniXEmp";
            this.txtUniXEmp.ReadOnly = true;
            this.txtUniXEmp.Size = new System.Drawing.Size(118, 22);
            this.txtUniXEmp.TabIndex = 448;
            this.txtUniXEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 14);
            this.label3.TabIndex = 447;
            this.label3.Text = "Uni x Empaque";
            // 
            // wEditCantidadReal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(531, 338);
            this.Controls.Add(this.txtUniXEmp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCanCajReaEnc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumCaj);
            this.Controls.Add(this.txtDesExi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCanUniEnc);
            this.Controls.Add(this.txtCodExi);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDev);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCanUniReaEnc);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "wEditCantidadReal";
            this.Text = "Unidades Producidas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditCantidadReal_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.txtCanUniReaEnc, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtDev, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtCodExi, 0);
            this.Controls.SetChildIndex(this.txtCanUniEnc, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDesExi, 0);
            this.Controls.SetChildIndex(this.txtNumCaj, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCanCajReaEnc, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtUniXEmp, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDev;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCanUniReaEnc;
        internal System.Windows.Forms.TextBox txtCodExi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCanUniEnc;
        internal System.Windows.Forms.TextBox txtDesExi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumCaj;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCanCajReaEnc;
        internal System.Windows.Forms.TextBox txtUniXEmp;
        private System.Windows.Forms.Label label3;
    }
}
