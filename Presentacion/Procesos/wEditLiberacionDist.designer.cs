namespace Presentacion.Procesos
{
    partial class wEditLiberacionDist
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
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumUniPas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumUniDes = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCanLib = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUniParRep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUniDon = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpFecLib = new System.Windows.Forms.DateTimePicker();
            this.txtCodLib = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalLib = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUniParMue = new System.Windows.Forms.TextBox();
            this.btnMotRep = new System.Windows.Forms.Button();
            this.btnMotDon = new System.Windows.Forms.Button();
            this.btnMotMue = new System.Windows.Forms.Button();
            this.btnMotDes = new System.Windows.Forms.Button();
            this.txtNumUniObs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumUniSal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(439, 475);
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
            this.btnAceptar.Location = new System.Drawing.Point(287, 475);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 32);
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
            this.label2.Location = new System.Drawing.Point(33, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(551, 18);
            this.label2.TabIndex = 76;
            this.label2.Text = "Datos generales";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 220);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 18);
            this.label7.TabIndex = 84;
            this.label7.Text = "# Unidades Encajadas";
            // 
            // txtNumUniPas
            // 
            this.txtNumUniPas.Location = new System.Drawing.Point(287, 216);
            this.txtNumUniPas.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumUniPas.MaxLength = 2;
            this.txtNumUniPas.Name = "txtNumUniPas";
            this.txtNumUniPas.Size = new System.Drawing.Size(156, 26);
            this.txtNumUniPas.TabIndex = 85;
            this.txtNumUniPas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumUniPas.Validated += new System.EventHandler(this.txtNumUniPas_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 435);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 18);
            this.label8.TabIndex = 86;
            this.label8.Text = "# Unidades Desechan";
            // 
            // txtNumUniDes
            // 
            this.txtNumUniDes.Location = new System.Drawing.Point(287, 431);
            this.txtNumUniDes.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumUniDes.MaxLength = 2;
            this.txtNumUniDes.Name = "txtNumUniDes";
            this.txtNumUniDes.ReadOnly = true;
            this.txtNumUniDes.Size = new System.Drawing.Size(156, 26);
            this.txtNumUniDes.TabIndex = 87;
            this.txtNumUniDes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 184);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 18);
            this.label12.TabIndex = 92;
            this.label12.Text = "Cantidad Liberada";
            // 
            // txtCanLib
            // 
            this.txtCanLib.Location = new System.Drawing.Point(287, 180);
            this.txtCanLib.Margin = new System.Windows.Forms.Padding(4);
            this.txtCanLib.MaxLength = 2;
            this.txtCanLib.Name = "txtCanLib";
            this.txtCanLib.ReadOnly = true;
            this.txtCanLib.Size = new System.Drawing.Size(156, 26);
            this.txtCanLib.TabIndex = 93;
            this.txtCanLib.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanLib.Validated += new System.EventHandler(this.txtCanLib_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 18);
            this.label4.TabIndex = 317;
            this.label4.Text = "# Unidades para Reproceso";
            // 
            // txtUniParRep
            // 
            this.txtUniParRep.Location = new System.Drawing.Point(287, 323);
            this.txtUniParRep.Margin = new System.Windows.Forms.Padding(4);
            this.txtUniParRep.MaxLength = 2;
            this.txtUniParRep.Name = "txtUniParRep";
            this.txtUniParRep.Size = new System.Drawing.Size(156, 26);
            this.txtUniParRep.TabIndex = 318;
            this.txtUniParRep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUniParRep.Validated += new System.EventHandler(this.txtUniParRep_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 363);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 18);
            this.label3.TabIndex = 319;
            this.label3.Text = "# Unidades para Donacion";
            // 
            // txtUniDon
            // 
            this.txtUniDon.Location = new System.Drawing.Point(287, 359);
            this.txtUniDon.Margin = new System.Windows.Forms.Padding(4);
            this.txtUniDon.MaxLength = 2;
            this.txtUniDon.Name = "txtUniDon";
            this.txtUniDon.Size = new System.Drawing.Size(156, 26);
            this.txtUniDon.TabIndex = 320;
            this.txtUniDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUniDon.Validated += new System.EventHandler(this.txtUniDon_Validated);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(33, 111);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 18);
            this.label19.TabIndex = 405;
            this.label19.Text = "Fecha";
            // 
            // dtpFecLib
            // 
            this.dtpFecLib.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecLib.Location = new System.Drawing.Point(287, 108);
            this.dtpFecLib.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecLib.Name = "dtpFecLib";
            this.dtpFecLib.Size = new System.Drawing.Size(145, 26);
            this.dtpFecLib.TabIndex = 404;
            // 
            // txtCodLib
            // 
            this.txtCodLib.Location = new System.Drawing.Point(287, 72);
            this.txtCodLib.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodLib.MaxLength = 4;
            this.txtCodLib.Name = "txtCodLib";
            this.txtCodLib.ReadOnly = true;
            this.txtCodLib.Size = new System.Drawing.Size(56, 26);
            this.txtCodLib.TabIndex = 438;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 76);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 18);
            this.label14.TabIndex = 437;
            this.label14.Text = "Codigo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 439;
            this.label1.Text = "Saldo";
            // 
            // txtSalLib
            // 
            this.txtSalLib.Location = new System.Drawing.Point(287, 144);
            this.txtSalLib.Margin = new System.Windows.Forms.Padding(4);
            this.txtSalLib.MaxLength = 2;
            this.txtSalLib.Name = "txtSalLib";
            this.txtSalLib.ReadOnly = true;
            this.txtSalLib.Size = new System.Drawing.Size(156, 26);
            this.txtSalLib.TabIndex = 440;
            this.txtSalLib.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 400);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 18);
            this.label5.TabIndex = 441;
            this.label5.Text = "# Unidades para Contra Muestra";
            // 
            // txtUniParMue
            // 
            this.txtUniParMue.Location = new System.Drawing.Point(287, 395);
            this.txtUniParMue.Margin = new System.Windows.Forms.Padding(4);
            this.txtUniParMue.MaxLength = 2;
            this.txtUniParMue.Name = "txtUniParMue";
            this.txtUniParMue.Size = new System.Drawing.Size(156, 26);
            this.txtUniParMue.TabIndex = 442;
            this.txtUniParMue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUniParMue.Validated += new System.EventHandler(this.txtUniParMue_Validated);
            // 
            // btnMotRep
            // 
            this.btnMotRep.Location = new System.Drawing.Point(445, 322);
            this.btnMotRep.Margin = new System.Windows.Forms.Padding(4);
            this.btnMotRep.Name = "btnMotRep";
            this.btnMotRep.Size = new System.Drawing.Size(100, 31);
            this.btnMotRep.TabIndex = 443;
            this.btnMotRep.Text = "Motivos";
            this.btnMotRep.UseVisualStyleBackColor = true;
            this.btnMotRep.Click += new System.EventHandler(this.btnMotRep_Click);
            // 
            // btnMotDon
            // 
            this.btnMotDon.Location = new System.Drawing.Point(445, 358);
            this.btnMotDon.Margin = new System.Windows.Forms.Padding(4);
            this.btnMotDon.Name = "btnMotDon";
            this.btnMotDon.Size = new System.Drawing.Size(100, 31);
            this.btnMotDon.TabIndex = 444;
            this.btnMotDon.Text = "Motivos";
            this.btnMotDon.UseVisualStyleBackColor = true;
            this.btnMotDon.Click += new System.EventHandler(this.btnMotDon_Click);
            // 
            // btnMotMue
            // 
            this.btnMotMue.Location = new System.Drawing.Point(445, 394);
            this.btnMotMue.Margin = new System.Windows.Forms.Padding(4);
            this.btnMotMue.Name = "btnMotMue";
            this.btnMotMue.Size = new System.Drawing.Size(100, 31);
            this.btnMotMue.TabIndex = 445;
            this.btnMotMue.Text = "Motivos";
            this.btnMotMue.UseVisualStyleBackColor = true;
            this.btnMotMue.Click += new System.EventHandler(this.btnMotMue_Click);
            // 
            // btnMotDes
            // 
            this.btnMotDes.Location = new System.Drawing.Point(445, 430);
            this.btnMotDes.Margin = new System.Windows.Forms.Padding(4);
            this.btnMotDes.Name = "btnMotDes";
            this.btnMotDes.Size = new System.Drawing.Size(100, 31);
            this.btnMotDes.TabIndex = 446;
            this.btnMotDes.Text = "Motivos";
            this.btnMotDes.UseVisualStyleBackColor = true;
            this.btnMotDes.Click += new System.EventHandler(this.btnMotDes_Click);
            // 
            // txtNumUniObs
            // 
            this.txtNumUniObs.Location = new System.Drawing.Point(287, 287);
            this.txtNumUniObs.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumUniObs.MaxLength = 2;
            this.txtNumUniObs.Name = "txtNumUniObs";
            this.txtNumUniObs.Size = new System.Drawing.Size(156, 26);
            this.txtNumUniObs.TabIndex = 448;
            this.txtNumUniObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumUniObs.Validated += new System.EventHandler(this.txtNumUniObs_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 290);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 18);
            this.label6.TabIndex = 447;
            this.label6.Text = "# Unidades Observadas";
            // 
            // txtNumUniSal
            // 
            this.txtNumUniSal.Location = new System.Drawing.Point(287, 251);
            this.txtNumUniSal.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumUniSal.MaxLength = 2;
            this.txtNumUniSal.Name = "txtNumUniSal";
            this.txtNumUniSal.Size = new System.Drawing.Size(156, 26);
            this.txtNumUniSal.TabIndex = 450;
            this.txtNumUniSal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumUniSal.Validated += new System.EventHandler(this.txtNumUniSal_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 254);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 18);
            this.label9.TabIndex = 449;
            this.label9.Text = "# Unidades Saldo";
            // 
            // wEditLiberacionDist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(620, 543);
            this.Controls.Add(this.txtNumUniSal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNumUniObs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnMotDes);
            this.Controls.Add(this.btnMotMue);
            this.Controls.Add(this.btnMotDon);
            this.Controls.Add(this.btnMotRep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUniParMue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSalLib);
            this.Controls.Add(this.txtCodLib);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dtpFecLib);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUniDon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUniParRep);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNumUniPas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNumUniDes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCanLib);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "wEditLiberacionDist";
            this.Text = "Unidades Producidas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditLiberacionDist_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.txtCanLib, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtNumUniDes, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtNumUniPas, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtUniParRep, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtUniDon, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpFecLib, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtCodLib, 0);
            this.Controls.SetChildIndex(this.txtSalLib, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtUniParMue, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnMotRep, 0);
            this.Controls.SetChildIndex(this.btnMotDon, 0);
            this.Controls.SetChildIndex(this.btnMotMue, 0);
            this.Controls.SetChildIndex(this.btnMotDes, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNumUniObs, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtNumUniSal, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumUniPas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCanLib;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.DateTimePicker dtpFecLib;
        internal System.Windows.Forms.TextBox txtCodLib;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalLib;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMotRep;
        private System.Windows.Forms.Button btnMotDon;
        private System.Windows.Forms.Button btnMotMue;
        private System.Windows.Forms.Button btnMotDes;
        internal System.Windows.Forms.TextBox txtNumUniDes;
        internal System.Windows.Forms.TextBox txtUniParRep;
        internal System.Windows.Forms.TextBox txtUniDon;
        internal System.Windows.Forms.TextBox txtUniParMue;
        private System.Windows.Forms.TextBox txtNumUniObs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumUniSal;
        private System.Windows.Forms.Label label9;
    }
}
