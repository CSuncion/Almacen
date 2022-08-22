namespace Presentacion.Varios
{
    partial class wCopiaSeguridad
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
            this.btnBusLogEmps = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRutLogEmps = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBusLogEmps
            // 
            this.btnBusLogEmps.Location = new System.Drawing.Point(433, 53);
            this.btnBusLogEmps.Name = "btnBusLogEmps";
            this.btnBusLogEmps.Size = new System.Drawing.Size(31, 24);
            this.btnBusLogEmps.TabIndex = 53;
            this.btnBusLogEmps.Text = "...";
            this.btnBusLogEmps.UseVisualStyleBackColor = true;
            this.btnBusLogEmps.Click += new System.EventHandler(this.btnBusLogEmps_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 51;
            this.label11.Text = "Carpeta";
            // 
            // txtRutLogEmps
            // 
            this.txtRutLogEmps.Location = new System.Drawing.Point(92, 54);
            this.txtRutLogEmps.MaxLength = 150;
            this.txtRutLogEmps.Name = "txtRutLogEmps";
            this.txtRutLogEmps.ReadOnly = true;
            this.txtRutLogEmps.Size = new System.Drawing.Size(338, 22);
            this.txtRutLogEmps.TabIndex = 52;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(206, 86);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 74;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(321, 86);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 73;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // wCopiaSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(488, 143);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBusLogEmps);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRutLogEmps);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wCopiaSeguridad";
            this.Text = "Copia de Seguridad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wCopiaSeguridad_FormClosing);
            this.Controls.SetChildIndex(this.txtRutLogEmps, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.btnBusLogEmps, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBusLogEmps;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRutLogEmps;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;

    }
}
