namespace Presentacion.Desarrollador
{
    partial class wEditVentana
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
            this.txtCodVen = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNomVen = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstVen = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.ckbAuto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomConVen = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Codigo:";
            // 
            // txtCodVen
            // 
            this.txtCodVen.Location = new System.Drawing.Point(113, 57);
            this.txtCodVen.Name = "txtCodVen";
            this.txtCodVen.Size = new System.Drawing.Size(32, 22);
            this.txtCodVen.TabIndex = 53;
            this.txtCodVen.Validated += new System.EventHandler(this.txtCodVen_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 14);
            this.label12.TabIndex = 54;
            this.label12.Text = "Nombre:";
            // 
            // txtNomVen
            // 
            this.txtNomVen.Location = new System.Drawing.Point(113, 83);
            this.txtNomVen.Name = "txtNomVen";
            this.txtNomVen.Size = new System.Drawing.Size(255, 22);
            this.txtNomVen.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstVen
            // 
            this.cmbEstVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstVen.Location = new System.Drawing.Point(113, 134);
            this.cmbEstVen.Name = "cmbEstVen";
            this.cmbEstVen.Size = new System.Drawing.Size(255, 22);
            this.cmbEstVen.TabIndex = 57;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(259, 168);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(145, 168);
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
            this.label21.Location = new System.Drawing.Point(17, 38);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(373, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckbAuto
            // 
            this.ckbAuto.AutoSize = true;
            this.ckbAuto.Checked = true;
            this.ckbAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAuto.Enabled = false;
            this.ckbAuto.Location = new System.Drawing.Point(151, 60);
            this.ckbAuto.Name = "ckbAuto";
            this.ckbAuto.Size = new System.Drawing.Size(87, 18);
            this.ckbAuto.TabIndex = 77;
            this.ckbAuto.Text = "Automatico";
            this.ckbAuto.UseVisualStyleBackColor = true;
            this.ckbAuto.CheckedChanged += new System.EventHandler(this.ckbAuto_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 78;
            this.label1.Text = "Control:";
            // 
            // txtNomConVen
            // 
            this.txtNomConVen.Location = new System.Drawing.Point(113, 109);
            this.txtNomConVen.Name = "txtNomConVen";
            this.txtNomConVen.Size = new System.Drawing.Size(255, 22);
            this.txtNomConVen.TabIndex = 79;
            // 
            // wEditVentana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(408, 221);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomConVen);
            this.Controls.Add(this.ckbAuto);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbEstVen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNomVen);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodVen);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wEditVentana";
            this.Text = "Edit Boton";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditVentana_FormClosing);
            this.Controls.SetChildIndex(this.txtCodVen, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtNomVen, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbEstVen, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.ckbAuto, 0);
            this.Controls.SetChildIndex(this.txtNomConVen, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodVen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNomVen;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstVen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox ckbAuto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomConVen;
    }
}
