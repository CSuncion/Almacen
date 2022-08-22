namespace Presentacion.Maestros
{
    partial class wEditPersonal
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
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstPer = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNomPer = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
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
            // txtCodPer
            // 
            this.txtCodPer.Location = new System.Drawing.Point(122, 57);
            this.txtCodPer.MaxLength = 2;
            this.txtCodPer.Name = "txtCodPer";
            this.txtCodPer.Size = new System.Drawing.Size(32, 22);
            this.txtCodPer.TabIndex = 53;
            this.txtCodPer.Validated += new System.EventHandler(this.txtCodPer_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstPer
            // 
            this.cmbEstPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstPer.Location = new System.Drawing.Point(122, 113);
            this.cmbEstPer.Name = "cmbEstPer";
            this.cmbEstPer.Size = new System.Drawing.Size(105, 22);
            this.cmbEstPer.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 14);
            this.label15.TabIndex = 61;
            this.label15.Text = "Nombre";
            // 
            // txtNomPer
            // 
            this.txtNomPer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomPer.Location = new System.Drawing.Point(122, 85);
            this.txtNomPer.MaxLength = 100;
            this.txtNomPer.Name = "txtNomPer";
            this.txtNomPer.Size = new System.Drawing.Size(261, 22);
            this.txtNomPer.TabIndex = 62;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(274, 154);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(160, 154);
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
            this.label21.Size = new System.Drawing.Size(360, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wEditPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(404, 208);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtNomPer);
            this.Controls.Add(this.cmbEstPer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodPer);
            this.Name = "wEditPersonal";
            this.Text = "Edit Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditPersonal_FormClosing);
            this.Controls.SetChildIndex(this.txtCodPer, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbEstPer, 0);
            this.Controls.SetChildIndex(this.txtNomPer, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodPer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstPer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNomPer;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
    }
}
