namespace Presentacion.Maestros
{
    partial class wEditTablaEmpresa
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
            this.txtCodIte = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNomIte = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstIte = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAbrIte = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNomTab = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Codigo:";
            // 
            // txtCodIte
            // 
            this.txtCodIte.Location = new System.Drawing.Point(111, 82);
            this.txtCodIte.MaxLength = 6;
            this.txtCodIte.Name = "txtCodIte";
            this.txtCodIte.Size = new System.Drawing.Size(89, 22);
            this.txtCodIte.TabIndex = 53;
            this.txtCodIte.Validated += new System.EventHandler(this.txtCodIte_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 14);
            this.label12.TabIndex = 54;
            this.label12.Text = "Nombre:";
            // 
            // txtNomIte
            // 
            this.txtNomIte.Location = new System.Drawing.Point(111, 110);
            this.txtNomIte.MaxLength = 50;
            this.txtNomIte.Name = "txtNomIte";
            this.txtNomIte.Size = new System.Drawing.Size(226, 22);
            this.txtNomIte.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstIte
            // 
            this.cmbEstIte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstIte.Location = new System.Drawing.Point(111, 166);
            this.cmbEstIte.Name = "cmbEstIte";
            this.cmbEstIte.Size = new System.Drawing.Size(151, 22);
            this.cmbEstIte.TabIndex = 57;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(243, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(128, 200);
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
            this.label21.Location = new System.Drawing.Point(28, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(309, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(25, 141);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 14);
            this.label16.TabIndex = 77;
            this.label16.Text = "Abrevia:";
            // 
            // txtAbrIte
            // 
            this.txtAbrIte.Location = new System.Drawing.Point(111, 138);
            this.txtAbrIte.MaxLength = 20;
            this.txtAbrIte.Name = "txtAbrIte";
            this.txtAbrIte.Size = new System.Drawing.Size(151, 22);
            this.txtAbrIte.TabIndex = 78;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 14);
            this.label14.TabIndex = 79;
            this.label14.Text = "Tabla:";
            // 
            // txtNomTab
            // 
            this.txtNomTab.Location = new System.Drawing.Point(111, 32);
            this.txtNomTab.Name = "txtNomTab";
            this.txtNomTab.ReadOnly = true;
            this.txtNomTab.Size = new System.Drawing.Size(226, 22);
            this.txtNomTab.TabIndex = 80;
            // 
            // wEditTablaGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(370, 246);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtNomTab);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtAbrIte);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbEstIte);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNomIte);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodIte);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wEditTablaGeneral";
            this.Text = "Edit tabla";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditTablaEmpresa_FormClosing);
            this.Controls.SetChildIndex(this.txtCodIte, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtNomIte, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbEstIte, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.txtAbrIte, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtNomTab, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodIte;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNomIte;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstIte;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAbrIte;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNomTab;
    }
}
