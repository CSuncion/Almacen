namespace Presentacion.Procesos
{
    partial class wPrimeraLiberacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUniDesQal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUniCuaQal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumUniMas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUniRepQal = new System.Windows.Forms.TextBox();
            this.btnMotRep = new System.Windows.Forms.Button();
            this.btnMotDes = new System.Windows.Forms.Button();
            this.btnMotMue = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUniMueQal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(366, 308);
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
            this.btnAceptar.Location = new System.Drawing.Point(214, 308);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 32);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 46);
            this.label1.TabIndex = 75;
            this.label1.Text = "Este proceso sirve para editar la cantidad exacta de Unidades a cuarentena, repro" +
    "cesa y desechas";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(35, 91);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(480, 18);
            this.label6.TabIndex = 83;
            this.label6.Text = "Cantidades";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 267);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 18);
            this.label7.TabIndex = 84;
            this.label7.Text = "Unidades Desechas";
            // 
            // txtUniDesQal
            // 
            this.txtUniDesQal.Location = new System.Drawing.Point(359, 264);
            this.txtUniDesQal.Margin = new System.Windows.Forms.Padding(4);
            this.txtUniDesQal.MaxLength = 2;
            this.txtUniDesQal.Name = "txtUniDesQal";
            this.txtUniDesQal.ReadOnly = true;
            this.txtUniDesQal.Size = new System.Drawing.Size(156, 26);
            this.txtUniDesQal.TabIndex = 85;
            this.txtUniDesQal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 18);
            this.label8.TabIndex = 86;
            this.label8.Text = "Unidades a Cuarentena";
            // 
            // txtUniCuaQal
            // 
            this.txtUniCuaQal.Location = new System.Drawing.Point(357, 156);
            this.txtUniCuaQal.Margin = new System.Windows.Forms.Padding(4);
            this.txtUniCuaQal.MaxLength = 2;
            this.txtUniCuaQal.Name = "txtUniCuaQal";
            this.txtUniCuaQal.Size = new System.Drawing.Size(156, 26);
            this.txtUniCuaQal.TabIndex = 87;
            this.txtUniCuaQal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUniCuaQal.Validated += new System.EventHandler(this.txtUniEnc_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 18);
            this.label9.TabIndex = 88;
            this.label9.Text = "# Unidades Selladas";
            // 
            // txtNumUniMas
            // 
            this.txtNumUniMas.Location = new System.Drawing.Point(357, 120);
            this.txtNumUniMas.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumUniMas.MaxLength = 2;
            this.txtNumUniMas.Name = "txtNumUniMas";
            this.txtNumUniMas.ReadOnly = true;
            this.txtNumUniMas.Size = new System.Drawing.Size(156, 26);
            this.txtNumUniMas.TabIndex = 89;
            this.txtNumUniMas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumUniMas.Validated += new System.EventHandler(this.txtNumUniMas_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 18);
            this.label2.TabIndex = 90;
            this.label2.Text = "Unidades a Reprocesar";
            // 
            // txtUniRepQal
            // 
            this.txtUniRepQal.BackColor = System.Drawing.SystemColors.Window;
            this.txtUniRepQal.Location = new System.Drawing.Point(357, 192);
            this.txtUniRepQal.Margin = new System.Windows.Forms.Padding(4);
            this.txtUniRepQal.MaxLength = 2;
            this.txtUniRepQal.Name = "txtUniRepQal";
            this.txtUniRepQal.ReadOnly = true;
            this.txtUniRepQal.Size = new System.Drawing.Size(156, 26);
            this.txtUniRepQal.TabIndex = 91;
            this.txtUniRepQal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUniRepQal.Validated += new System.EventHandler(this.txtUniConMue_Validated);
            // 
            // btnMotRep
            // 
            this.btnMotRep.Location = new System.Drawing.Point(516, 189);
            this.btnMotRep.Margin = new System.Windows.Forms.Padding(4);
            this.btnMotRep.Name = "btnMotRep";
            this.btnMotRep.Size = new System.Drawing.Size(100, 31);
            this.btnMotRep.TabIndex = 444;
            this.btnMotRep.Text = "Motivos";
            this.btnMotRep.UseVisualStyleBackColor = true;
            this.btnMotRep.Click += new System.EventHandler(this.btnMotRep_Click);
            // 
            // btnMotDes
            // 
            this.btnMotDes.Location = new System.Drawing.Point(516, 261);
            this.btnMotDes.Margin = new System.Windows.Forms.Padding(4);
            this.btnMotDes.Name = "btnMotDes";
            this.btnMotDes.Size = new System.Drawing.Size(100, 31);
            this.btnMotDes.TabIndex = 445;
            this.btnMotDes.Text = "Motivos";
            this.btnMotDes.UseVisualStyleBackColor = true;
            this.btnMotDes.Click += new System.EventHandler(this.btnMotDes_Click);
            // 
            // btnMotMue
            // 
            this.btnMotMue.Location = new System.Drawing.Point(516, 225);
            this.btnMotMue.Margin = new System.Windows.Forms.Padding(4);
            this.btnMotMue.Name = "btnMotMue";
            this.btnMotMue.Size = new System.Drawing.Size(100, 31);
            this.btnMotMue.TabIndex = 448;
            this.btnMotMue.Text = "Motivos";
            this.btnMotMue.UseVisualStyleBackColor = true;
            this.btnMotMue.Click += new System.EventHandler(this.btnMotMue_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 231);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 18);
            this.label3.TabIndex = 446;
            this.label3.Text = "Unidades Muestras";
            // 
            // txtUniMueQal
            // 
            this.txtUniMueQal.BackColor = System.Drawing.SystemColors.Window;
            this.txtUniMueQal.Location = new System.Drawing.Point(357, 228);
            this.txtUniMueQal.Margin = new System.Windows.Forms.Padding(4);
            this.txtUniMueQal.MaxLength = 2;
            this.txtUniMueQal.Name = "txtUniMueQal";
            this.txtUniMueQal.ReadOnly = true;
            this.txtUniMueQal.Size = new System.Drawing.Size(156, 26);
            this.txtUniMueQal.TabIndex = 447;
            this.txtUniMueQal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUniMueQal.Validated += new System.EventHandler(this.txtUniMueQal_Validated);
            // 
            // wPrimeraLiberacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(653, 391);
            this.Controls.Add(this.btnMotMue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUniMueQal);
            this.Controls.Add(this.btnMotDes);
            this.Controls.Add(this.btnMotRep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUniRepQal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNumUniMas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUniCuaQal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUniDesQal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "wPrimeraLiberacion";
            this.Text = "Primera Liberacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wPrimeraLiberacion_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtUniDesQal, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtUniCuaQal, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtNumUniMas, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtUniRepQal, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnMotRep, 0);
            this.Controls.SetChildIndex(this.btnMotDes, 0);
            this.Controls.SetChildIndex(this.txtUniMueQal, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnMotMue, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUniDesQal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUniCuaQal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumUniMas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUniRepQal;
        private System.Windows.Forms.Button btnMotRep;
        private System.Windows.Forms.Button btnMotDes;
        private System.Windows.Forms.Button btnMotMue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUniMueQal;
    }
}
