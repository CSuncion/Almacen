namespace Presentacion.Sistema
{
    partial class wEditUsuario
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
            this.txtCodUsu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtClaUsu = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbPer = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNomUsu = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDirUsu = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCorUsu = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTelFijUsu = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTelCelUsu = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbEstUsu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 78);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 18);
            this.label11.TabIndex = 52;
            this.label11.Text = "Usuario:";
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Location = new System.Drawing.Point(160, 75);
            this.txtCodUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodUsu.MaxLength = 20;
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.Size = new System.Drawing.Size(231, 26);
            this.txtCodUsu.TabIndex = 53;
            this.txtCodUsu.Validated += new System.EventHandler(this.txtCodUsu_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 114);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 18);
            this.label12.TabIndex = 54;
            this.label12.Text = "Contraseña:";
            // 
            // txtClaUsu
            // 
            this.txtClaUsu.Location = new System.Drawing.Point(160, 111);
            this.txtClaUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClaUsu.MaxLength = 20;
            this.txtClaUsu.Name = "txtClaUsu";
            this.txtClaUsu.PasswordChar = '*';
            this.txtClaUsu.Size = new System.Drawing.Size(231, 26);
            this.txtClaUsu.TabIndex = 55;
            this.txtClaUsu.Validated += new System.EventHandler(this.txtClaUsu_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 150);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 18);
            this.label13.TabIndex = 56;
            this.label13.Text = "Perfil:";
            // 
            // cmbPer
            // 
            this.cmbPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPer.Location = new System.Drawing.Point(160, 147);
            this.cmbPer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPer.Name = "cmbPer";
            this.cmbPer.Size = new System.Drawing.Size(231, 26);
            this.cmbPer.TabIndex = 57;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 186);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 18);
            this.label14.TabIndex = 58;
            this.label14.Text = "Estado:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 258);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 18);
            this.label15.TabIndex = 61;
            this.label15.Text = "Nombres:";
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(160, 255);
            this.txtNomUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNomUsu.MaxLength = 100;
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.Size = new System.Drawing.Size(391, 26);
            this.txtNomUsu.TabIndex = 62;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 294);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 18);
            this.label16.TabIndex = 63;
            this.label16.Text = "Direccion:";
            // 
            // txtDirUsu
            // 
            this.txtDirUsu.Location = new System.Drawing.Point(160, 291);
            this.txtDirUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDirUsu.MaxLength = 100;
            this.txtDirUsu.Name = "txtDirUsu";
            this.txtDirUsu.Size = new System.Drawing.Size(391, 26);
            this.txtDirUsu.TabIndex = 64;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(32, 330);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 18);
            this.label17.TabIndex = 65;
            this.label17.Text = "Correo:";
            // 
            // txtCorUsu
            // 
            this.txtCorUsu.Location = new System.Drawing.Point(160, 327);
            this.txtCorUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCorUsu.MaxLength = 80;
            this.txtCorUsu.Name = "txtCorUsu";
            this.txtCorUsu.Size = new System.Drawing.Size(231, 26);
            this.txtCorUsu.TabIndex = 66;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(32, 366);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 18);
            this.label18.TabIndex = 67;
            this.label18.Text = "Tel. Fijo:";
            // 
            // txtTelFijUsu
            // 
            this.txtTelFijUsu.Location = new System.Drawing.Point(160, 363);
            this.txtTelFijUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelFijUsu.MaxLength = 10;
            this.txtTelFijUsu.Name = "txtTelFijUsu";
            this.txtTelFijUsu.Size = new System.Drawing.Size(231, 26);
            this.txtTelFijUsu.TabIndex = 68;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(32, 402);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 18);
            this.label19.TabIndex = 69;
            this.label19.Text = "Tel. Celular:";
            // 
            // txtTelCelUsu
            // 
            this.txtTelCelUsu.Location = new System.Drawing.Point(160, 399);
            this.txtTelCelUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelCelUsu.MaxLength = 10;
            this.txtTelCelUsu.Name = "txtTelCelUsu";
            this.txtTelCelUsu.Size = new System.Drawing.Size(231, 26);
            this.txtTelCelUsu.TabIndex = 70;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(407, 445);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(145, 32);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(253, 445);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 32);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.DarkGray;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(32, 226);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(520, 18);
            this.label20.TabIndex = 73;
            this.label20.Text = "Datos Personales";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(32, 44);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(520, 18);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Sistema";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbEstUsu
            // 
            this.cmbEstUsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstUsu.Location = new System.Drawing.Point(160, 183);
            this.cmbEstUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEstUsu.Name = "cmbEstUsu";
            this.cmbEstUsu.Size = new System.Drawing.Size(231, 26);
            this.cmbEstUsu.TabIndex = 75;
            // 
            // wEditUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(583, 500);
            this.Controls.Add(this.cmbEstUsu);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtTelCelUsu);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtTelFijUsu);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtCorUsu);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtDirUsu);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtNomUsu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbPer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtClaUsu);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodUsu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "wEditUsuario";
            this.Text = "Edit Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditUsuario_FormClosing);
            this.Controls.SetChildIndex(this.txtCodUsu, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtClaUsu, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbPer, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtNomUsu, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtDirUsu, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtCorUsu, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.txtTelFijUsu, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtTelCelUsu, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.cmbEstUsu, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodUsu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtClaUsu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbPer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNomUsu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDirUsu;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCorUsu;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTelFijUsu;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTelCelUsu;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbEstUsu;
    }
}
