namespace Presentacion.Procesos
{
    partial class wDistribucionEmpaquetado
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
            this.label11 = new System.Windows.Forms.Label();
            this.txtCosEmpPri = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCosEmpAdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCosEmpDev = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCosEmpTot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumUniSemEla = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumUniProTer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCosUniProTer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCosUniSemEla = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Costo Principal";
            // 
            // txtCosEmpPri
            // 
            this.txtCosEmpPri.Location = new System.Drawing.Point(268, 93);
            this.txtCosEmpPri.MaxLength = 2;
            this.txtCosEmpPri.Name = "txtCosEmpPri";
            this.txtCosEmpPri.ReadOnly = true;
            this.txtCosEmpPri.Size = new System.Drawing.Size(118, 22);
            this.txtCosEmpPri.TabIndex = 53;
            this.txtCosEmpPri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(277, 348);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(163, 348);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 34);
            this.label1.TabIndex = 75;
            this.label1.Text = "Este proceso sirve para distribuir los costos de los productos semi elaborados y " +
    "productos terminados";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 14);
            this.label2.TabIndex = 76;
            this.label2.Text = "Costo EmpaquetadoTotal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 77;
            this.label3.Text = "Costo Adicional";
            // 
            // txtCosEmpAdi
            // 
            this.txtCosEmpAdi.Location = new System.Drawing.Point(268, 121);
            this.txtCosEmpAdi.MaxLength = 2;
            this.txtCosEmpAdi.Name = "txtCosEmpAdi";
            this.txtCosEmpAdi.ReadOnly = true;
            this.txtCosEmpAdi.Size = new System.Drawing.Size(118, 22);
            this.txtCosEmpAdi.TabIndex = 78;
            this.txtCosEmpAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 14);
            this.label4.TabIndex = 79;
            this.label4.Text = "Costo Devueltos (-)";
            // 
            // txtCosEmpDev
            // 
            this.txtCosEmpDev.ForeColor = System.Drawing.Color.Red;
            this.txtCosEmpDev.Location = new System.Drawing.Point(268, 149);
            this.txtCosEmpDev.MaxLength = 2;
            this.txtCosEmpDev.Name = "txtCosEmpDev";
            this.txtCosEmpDev.ReadOnly = true;
            this.txtCosEmpDev.Size = new System.Drawing.Size(118, 22);
            this.txtCosEmpDev.TabIndex = 80;
            this.txtCosEmpDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 81;
            this.label5.Text = "Costo Total";
            // 
            // txtCosEmpTot
            // 
            this.txtCosEmpTot.Location = new System.Drawing.Point(268, 177);
            this.txtCosEmpTot.MaxLength = 2;
            this.txtCosEmpTot.Name = "txtCosEmpTot";
            this.txtCosEmpTot.ReadOnly = true;
            this.txtCosEmpTot.Size = new System.Drawing.Size(118, 22);
            this.txtCosEmpTot.TabIndex = 82;
            this.txtCosEmpTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(360, 14);
            this.label6.TabIndex = 83;
            this.label6.Text = "Costo Por Unidad masa";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 14);
            this.label8.TabIndex = 86;
            this.label8.Text = "# Unidades Semi Elaborados";
            // 
            // txtNumUniSemEla
            // 
            this.txtNumUniSemEla.Location = new System.Drawing.Point(268, 230);
            this.txtNumUniSemEla.MaxLength = 2;
            this.txtNumUniSemEla.Name = "txtNumUniSemEla";
            this.txtNumUniSemEla.ReadOnly = true;
            this.txtNumUniSemEla.Size = new System.Drawing.Size(118, 22);
            this.txtNumUniSemEla.TabIndex = 87;
            this.txtNumUniSemEla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 14);
            this.label10.TabIndex = 90;
            this.label10.Text = "# Unidades Producto Terminado";
            // 
            // txtNumUniProTer
            // 
            this.txtNumUniProTer.Location = new System.Drawing.Point(268, 286);
            this.txtNumUniProTer.MaxLength = 2;
            this.txtNumUniProTer.Name = "txtNumUniProTer";
            this.txtNumUniProTer.ReadOnly = true;
            this.txtNumUniProTer.Size = new System.Drawing.Size(118, 22);
            this.txtNumUniProTer.TabIndex = 91;
            this.txtNumUniProTer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 317);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(191, 14);
            this.label12.TabIndex = 92;
            this.label12.Text = "Costo Unidad Producto Terminado";
            // 
            // txtCosUniProTer
            // 
            this.txtCosUniProTer.Location = new System.Drawing.Point(268, 314);
            this.txtCosUniProTer.MaxLength = 2;
            this.txtCosUniProTer.Name = "txtCosUniProTer";
            this.txtCosUniProTer.ReadOnly = true;
            this.txtCosUniProTer.Size = new System.Drawing.Size(118, 22);
            this.txtCosUniProTer.TabIndex = 93;
            this.txtCosUniProTer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 261);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 14);
            this.label13.TabIndex = 94;
            this.label13.Text = "Costo Unidad Semi Elaborado";
            // 
            // txtCosUniSemEla
            // 
            this.txtCosUniSemEla.Location = new System.Drawing.Point(268, 258);
            this.txtCosUniSemEla.MaxLength = 2;
            this.txtCosUniSemEla.Name = "txtCosUniSemEla";
            this.txtCosUniSemEla.ReadOnly = true;
            this.txtCosUniSemEla.Size = new System.Drawing.Size(118, 22);
            this.txtCosUniSemEla.TabIndex = 95;
            this.txtCosUniSemEla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // wDistribucionEmpaquetado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(412, 402);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCosUniSemEla);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCosUniProTer);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNumUniProTer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNumUniSemEla);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCosEmpTot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCosEmpDev);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCosEmpAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCosEmpPri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "wDistribucionEmpaquetado";
            this.Text = "Distribucion Costo Fase Empaquetado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wDistribucionEmpaquetado_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCosEmpPri, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCosEmpAdi, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtCosEmpDev, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtCosEmpTot, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNumUniSemEla, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtNumUniProTer, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtCosUniProTer, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtCosUniSemEla, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCosEmpPri;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCosEmpAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCosEmpDev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCosEmpTot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumUniSemEla;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumUniProTer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCosUniProTer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCosUniSemEla;
    }
}
