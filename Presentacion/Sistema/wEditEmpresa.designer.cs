namespace Presentacion.Sistema
{
    partial class wEditEmpresa
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
            this.txtCodEmp = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNomEmp = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstEmp = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDirEmp = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCorEmp = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTelFijEmp = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTelCelEmp = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtRucEmp = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Codigo:";
            // 
            // txtCodEmp
            // 
            this.txtCodEmp.Location = new System.Drawing.Point(137, 58);
            this.txtCodEmp.MaxLength = 5;
            this.txtCodEmp.Name = "txtCodEmp";
            this.txtCodEmp.Size = new System.Drawing.Size(34, 22);
            this.txtCodEmp.TabIndex = 53;
            this.txtCodEmp.Validated += new System.EventHandler(this.txtCodEmp_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 14);
            this.label12.TabIndex = 54;
            this.label12.Text = "Nombre:";
            // 
            // txtNomEmp
            // 
            this.txtNomEmp.Location = new System.Drawing.Point(137, 86);
            this.txtNomEmp.MaxLength = 100;
            this.txtNomEmp.Name = "txtNomEmp";
            this.txtNomEmp.Size = new System.Drawing.Size(301, 22);
            this.txtNomEmp.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstEmp
            // 
            this.cmbEstEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstEmp.Location = new System.Drawing.Point(137, 142);
            this.cmbEstEmp.Name = "cmbEstEmp";
            this.cmbEstEmp.Size = new System.Drawing.Size(125, 22);
            this.cmbEstEmp.TabIndex = 57;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 14);
            this.label14.TabIndex = 58;
            this.label14.Text = "Ruc:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 201);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 14);
            this.label15.TabIndex = 61;
            this.label15.Text = "Direccion:";
            // 
            // txtDirEmp
            // 
            this.txtDirEmp.Location = new System.Drawing.Point(137, 197);
            this.txtDirEmp.MaxLength = 100;
            this.txtDirEmp.Name = "txtDirEmp";
            this.txtDirEmp.Size = new System.Drawing.Size(341, 22);
            this.txtDirEmp.TabIndex = 62;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(30, 229);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 14);
            this.label17.TabIndex = 65;
            this.label17.Text = "Correo:";
            // 
            // txtCorEmp
            // 
            this.txtCorEmp.Location = new System.Drawing.Point(137, 225);
            this.txtCorEmp.MaxLength = 50;
            this.txtCorEmp.Name = "txtCorEmp";
            this.txtCorEmp.Size = new System.Drawing.Size(341, 22);
            this.txtCorEmp.TabIndex = 66;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(30, 257);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 14);
            this.label18.TabIndex = 67;
            this.label18.Text = "Tel. Fijo:";
            // 
            // txtTelFijEmp
            // 
            this.txtTelFijEmp.Location = new System.Drawing.Point(137, 253);
            this.txtTelFijEmp.MaxLength = 10;
            this.txtTelFijEmp.Name = "txtTelFijEmp";
            this.txtTelFijEmp.Size = new System.Drawing.Size(125, 22);
            this.txtTelFijEmp.TabIndex = 68;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(30, 285);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 14);
            this.label19.TabIndex = 69;
            this.label19.Text = "Tel. Celular:";
            // 
            // txtTelCelEmp
            // 
            this.txtTelCelEmp.Location = new System.Drawing.Point(137, 281);
            this.txtTelCelEmp.MaxLength = 10;
            this.txtTelCelEmp.Name = "txtTelCelEmp";
            this.txtTelCelEmp.Size = new System.Drawing.Size(125, 22);
            this.txtTelCelEmp.TabIndex = 70;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(369, 318);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 24);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(254, 318);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 24);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtRucEmp
            // 
            this.txtRucEmp.Location = new System.Drawing.Point(137, 114);
            this.txtRucEmp.MaxLength = 11;
            this.txtRucEmp.Name = "txtRucEmp";
            this.txtRucEmp.Size = new System.Drawing.Size(125, 22);
            this.txtRucEmp.TabIndex = 75;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(30, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(448, 15);
            this.label21.TabIndex = 341;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.DarkGray;
            this.label22.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(30, 173);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(448, 15);
            this.label22.TabIndex = 342;
            this.label22.Text = "Datos Contacto";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wEditEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(505, 373);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtDirEmp);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbEstEmp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTelFijEmp);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtTelCelEmp);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCorEmp);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtRucEmp);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtNomEmp);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCodEmp);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "wEditEmpresa";
            this.Text = "Edit Empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditEmpresa_FormClosing);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtCodEmp, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtNomEmp, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtRucEmp, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtCorEmp, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtTelCelEmp, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.txtTelFijEmp, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.cmbEstEmp, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtDirEmp, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodEmp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNomEmp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstEmp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDirEmp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCorEmp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTelFijEmp;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTelCelEmp;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtRucEmp;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
    }
}
