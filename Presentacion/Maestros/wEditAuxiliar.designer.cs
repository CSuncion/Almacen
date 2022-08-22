namespace Presentacion.Maestros
{
    partial class wEditAuxiliar
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
            this.txtCodAux = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstAux = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDesAux = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirAux = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelAux = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCelAux = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCorAux = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRefAux = new System.Windows.Forms.TextBox();
            this.cmbTipAux = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Codigo:";
            // 
            // txtCodAux
            // 
            this.txtCodAux.Location = new System.Drawing.Point(122, 57);
            this.txtCodAux.MaxLength = 2;
            this.txtCodAux.Name = "txtCodAux";
            this.txtCodAux.Size = new System.Drawing.Size(105, 22);
            this.txtCodAux.TabIndex = 53;
            this.txtCodAux.Validated += new System.EventHandler(this.txtCodAux_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstAux
            // 
            this.cmbEstAux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstAux.Location = new System.Drawing.Point(122, 281);
            this.cmbEstAux.Name = "cmbEstAux";
            this.cmbEstAux.Size = new System.Drawing.Size(105, 22);
            this.cmbEstAux.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 14);
            this.label15.TabIndex = 61;
            this.label15.Text = "Nombre:";
            // 
            // txtDesAux
            // 
            this.txtDesAux.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesAux.Location = new System.Drawing.Point(122, 85);
            this.txtDesAux.MaxLength = 100;
            this.txtDesAux.Name = "txtDesAux";
            this.txtDesAux.Size = new System.Drawing.Size(462, 22);
            this.txtDesAux.TabIndex = 62;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(475, 318);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(361, 318);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
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
            this.label21.Location = new System.Drawing.Point(23, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(561, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 75;
            this.label1.Text = "Direccion:";
            // 
            // txtDirAux
            // 
            this.txtDirAux.Location = new System.Drawing.Point(122, 113);
            this.txtDirAux.MaxLength = 100;
            this.txtDirAux.Name = "txtDirAux";
            this.txtDirAux.Size = new System.Drawing.Size(462, 22);
            this.txtDirAux.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 77;
            this.label2.Text = "Telefono:";
            // 
            // txtTelAux
            // 
            this.txtTelAux.Location = new System.Drawing.Point(122, 141);
            this.txtTelAux.MaxLength = 100;
            this.txtTelAux.Name = "txtTelAux";
            this.txtTelAux.Size = new System.Drawing.Size(147, 22);
            this.txtTelAux.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 79;
            this.label3.Text = "Celular:";
            // 
            // txtCelAux
            // 
            this.txtCelAux.Location = new System.Drawing.Point(122, 169);
            this.txtCelAux.MaxLength = 100;
            this.txtCelAux.Name = "txtCelAux";
            this.txtCelAux.Size = new System.Drawing.Size(105, 22);
            this.txtCelAux.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 81;
            this.label4.Text = "Correo:";
            // 
            // txtCorAux
            // 
            this.txtCorAux.Location = new System.Drawing.Point(122, 197);
            this.txtCorAux.MaxLength = 100;
            this.txtCorAux.Name = "txtCorAux";
            this.txtCorAux.Size = new System.Drawing.Size(221, 22);
            this.txtCorAux.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 14);
            this.label5.TabIndex = 83;
            this.label5.Text = "Referencia:";
            // 
            // txtRefAux
            // 
            this.txtRefAux.Location = new System.Drawing.Point(122, 225);
            this.txtRefAux.MaxLength = 100;
            this.txtRefAux.Name = "txtRefAux";
            this.txtRefAux.Size = new System.Drawing.Size(399, 22);
            this.txtRefAux.TabIndex = 84;
            // 
            // cmbTipAux
            // 
            this.cmbTipAux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipAux.Location = new System.Drawing.Point(122, 253);
            this.cmbTipAux.Name = "cmbTipAux";
            this.cmbTipAux.Size = new System.Drawing.Size(184, 22);
            this.cmbTipAux.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 14);
            this.label6.TabIndex = 85;
            this.label6.Text = "Tipo:";
            // 
            // wEditAuxiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(615, 373);
            this.Controls.Add(this.cmbTipAux);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRefAux);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCorAux);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCelAux);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTelAux);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDirAux);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtDesAux);
            this.Controls.Add(this.cmbEstAux);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodAux);
            this.Name = "wEditAuxiliar";
            this.Text = "Edit Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditAuxiliar_FormClosing);
            this.Controls.SetChildIndex(this.txtCodAux, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbEstAux, 0);
            this.Controls.SetChildIndex(this.txtDesAux, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.txtDirAux, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTelAux, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCelAux, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtCorAux, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRefAux, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbTipAux, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodAux;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstAux;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDesAux;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirAux;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelAux;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCelAux;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCorAux;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRefAux;
        private System.Windows.Forms.ComboBox cmbTipAux;
        private System.Windows.Forms.Label label6;
    }
}
