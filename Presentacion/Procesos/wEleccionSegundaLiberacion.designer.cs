namespace Presentacion.Procesos
{
    partial class wEleccionSegundaLiberacion
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
            this.txtCodExi = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDesExi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstSegLib = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(400, 190);
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
            this.btnAceptar.Location = new System.Drawing.Point(248, 190);
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
            this.label2.Size = new System.Drawing.Size(512, 18);
            this.label2.TabIndex = 76;
            this.label2.Text = "Datos generales";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodExi
            // 
            this.txtCodExi.Location = new System.Drawing.Point(161, 72);
            this.txtCodExi.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodExi.MaxLength = 4;
            this.txtCodExi.Name = "txtCodExi";
            this.txtCodExi.ReadOnly = true;
            this.txtCodExi.Size = new System.Drawing.Size(99, 26);
            this.txtCodExi.TabIndex = 438;
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
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(161, 108);
            this.txtDesExi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesExi.MaxLength = 4;
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(384, 26);
            this.txtDesExi.TabIndex = 442;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 441;
            this.label5.Text = "Descripcion";
            // 
            // cmbEstSegLib
            // 
            this.cmbEstSegLib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstSegLib.Location = new System.Drawing.Point(161, 142);
            this.cmbEstSegLib.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstSegLib.Name = "cmbEstSegLib";
            this.cmbEstSegLib.Size = new System.Drawing.Size(296, 26);
            this.cmbEstSegLib.TabIndex = 444;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 145);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 18);
            this.label15.TabIndex = 443;
            this.label15.Text = "Estado";
            // 
            // wEleccionSegundaLiberacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(580, 247);
            this.Controls.Add(this.cmbEstSegLib);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtDesExi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodExi);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "wEleccionSegundaLiberacion";
            this.Text = "Eleccion Segunda Liberacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEleccionSegundaLiberacion_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtCodExi, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDesExi, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.cmbEstSegLib, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtCodExi;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtDesExi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEstSegLib;
        private System.Windows.Forms.Label label15;
    }
}
