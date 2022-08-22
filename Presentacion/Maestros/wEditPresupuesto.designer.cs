namespace Presentacion.Maestros
{
    partial class wEditPresupuesto
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
            this.txtCodPer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAnoPer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstPer = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbMesPer = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImpPre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodCenCto = new System.Windows.Forms.TextBox();
            this.txtDesCenCto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImpAdiPre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSalPre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSalPreTem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 73);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 18);
            this.label11.TabIndex = 52;
            this.label11.Text = "Codigo:";
            // 
            // txtCodPer
            // 
            this.txtCodPer.Location = new System.Drawing.Point(205, 70);
            this.txtCodPer.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodPer.MaxLength = 2;
            this.txtCodPer.Name = "txtCodPer";
            this.txtCodPer.ReadOnly = true;
            this.txtCodPer.Size = new System.Drawing.Size(103, 26);
            this.txtCodPer.TabIndex = 53;
            this.txtCodPer.Validated += new System.EventHandler(this.txtCodPer_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 109);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 18);
            this.label12.TabIndex = 54;
            this.label12.Text = "Año:";
            // 
            // txtAnoPer
            // 
            this.txtAnoPer.Location = new System.Drawing.Point(205, 106);
            this.txtAnoPer.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnoPer.MaxLength = 50;
            this.txtAnoPer.Name = "txtAnoPer";
            this.txtAnoPer.Size = new System.Drawing.Size(103, 26);
            this.txtAnoPer.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 360);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 18);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstPer
            // 
            this.cmbEstPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstPer.Location = new System.Drawing.Point(205, 357);
            this.cmbEstPer.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstPer.Name = "cmbEstPer";
            this.cmbEstPer.Size = new System.Drawing.Size(159, 26);
            this.cmbEstPer.TabIndex = 57;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(358, 401);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(145, 32);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(205, 401);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 32);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(35, 44);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(658, 18);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMesPer
            // 
            this.cmbMesPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesPer.Location = new System.Drawing.Point(205, 140);
            this.cmbMesPer.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMesPer.Name = "cmbMesPer";
            this.cmbMesPer.Size = new System.Drawing.Size(159, 26);
            this.cmbMesPer.TabIndex = 76;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 179);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 18);
            this.label14.TabIndex = 75;
            this.label14.Text = "Centro Costo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 77;
            this.label1.Text = "Importe Ppto";
            // 
            // txtImpPre
            // 
            this.txtImpPre.Location = new System.Drawing.Point(205, 208);
            this.txtImpPre.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpPre.MaxLength = 50;
            this.txtImpPre.Name = "txtImpPre";
            this.txtImpPre.Size = new System.Drawing.Size(159, 26);
            this.txtImpPre.TabIndex = 78;
            this.txtImpPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImpPre.Validated += new System.EventHandler(this.txtImpPre_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 79;
            this.label2.Text = "Mes:";
            // 
            // txtCodCenCto
            // 
            this.txtCodCenCto.Location = new System.Drawing.Point(205, 174);
            this.txtCodCenCto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCenCto.MaxLength = 50;
            this.txtCodCenCto.Name = "txtCodCenCto";
            this.txtCodCenCto.Size = new System.Drawing.Size(103, 26);
            this.txtCodCenCto.TabIndex = 80;
            this.txtCodCenCto.DoubleClick += new System.EventHandler(this.txtCodCenCos_DoubleClick);
            this.txtCodCenCto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodCenCto_KeyDown);
            this.txtCodCenCto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCenCto_Validating);
            // 
            // txtDesCenCto
            // 
            this.txtDesCenCto.Location = new System.Drawing.Point(324, 176);
            this.txtDesCenCto.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesCenCto.MaxLength = 2;
            this.txtDesCenCto.Name = "txtDesCenCto";
            this.txtDesCenCto.ReadOnly = true;
            this.txtDesCenCto.Size = new System.Drawing.Size(384, 26);
            this.txtDesCenCto.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 247);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 82;
            this.label3.Text = "Adicional Ppto";
            // 
            // txtImpAdiPre
            // 
            this.txtImpAdiPre.Location = new System.Drawing.Point(205, 244);
            this.txtImpAdiPre.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpAdiPre.MaxLength = 50;
            this.txtImpAdiPre.Name = "txtImpAdiPre";
            this.txtImpAdiPre.Size = new System.Drawing.Size(159, 26);
            this.txtImpAdiPre.TabIndex = 83;
            this.txtImpAdiPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 281);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 84;
            this.label4.Text = "Saldo Ppto";
            // 
            // txtSalPre
            // 
            this.txtSalPre.Location = new System.Drawing.Point(205, 278);
            this.txtSalPre.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalPre.MaxLength = 50;
            this.txtSalPre.Name = "txtSalPre";
            this.txtSalPre.Size = new System.Drawing.Size(159, 26);
            this.txtSalPre.TabIndex = 85;
            this.txtSalPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 315);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 18);
            this.label5.TabIndex = 86;
            this.label5.Text = "Saldo Ppto Temporal";
            // 
            // txtSalPreTem
            // 
            this.txtSalPreTem.Location = new System.Drawing.Point(205, 312);
            this.txtSalPreTem.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalPreTem.MaxLength = 50;
            this.txtSalPreTem.Name = "txtSalPreTem";
            this.txtSalPreTem.Size = new System.Drawing.Size(159, 26);
            this.txtSalPreTem.TabIndex = 87;
            this.txtSalPreTem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // wEditPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(768, 484);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSalPreTem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSalPre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImpAdiPre);
            this.Controls.Add(this.txtDesCenCto);
            this.Controls.Add(this.txtCodCenCto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImpPre);
            this.Controls.Add(this.cmbMesPer);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbEstPer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAnoPer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodPer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "wEditPresupuesto";
            this.Text = "Edit Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditPeriodo_FormClosing);
            this.Controls.SetChildIndex(this.txtCodPer, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtAnoPer, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbEstPer, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.cmbMesPer, 0);
            this.Controls.SetChildIndex(this.txtImpPre, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCodCenCto, 0);
            this.Controls.SetChildIndex(this.txtDesCenCto, 0);
            this.Controls.SetChildIndex(this.txtImpAdiPre, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtSalPre, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtSalPreTem, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodPer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAnoPer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstPer;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbMesPer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImpPre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodCenCto;
        private System.Windows.Forms.TextBox txtDesCenCto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImpAdiPre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSalPre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSalPreTem;
    }
}
