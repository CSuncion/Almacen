namespace Presentacion.Sistema
{
    partial class wAsignarAlmacenes
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
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.DgvPer = new System.Windows.Forms.DataGridView();
            this.txtCodUsu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(405, 262);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(291, 262);
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
            this.label21.Location = new System.Drawing.Point(20, 63);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(494, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Permisos";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 14);
            this.label11.TabIndex = 75;
            this.label11.Text = "Usuario:";
            // 
            // txtUsu
            // 
            this.txtUsu.Location = new System.Drawing.Point(77, 34);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.ReadOnly = true;
            this.txtUsu.Size = new System.Drawing.Size(437, 22);
            this.txtUsu.TabIndex = 76;
            // 
            // DgvPer
            // 
            this.DgvPer.BackgroundColor = System.Drawing.Color.White;
            this.DgvPer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvPer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPer.GridColor = System.Drawing.Color.Silver;
            this.DgvPer.Location = new System.Drawing.Point(20, 85);
            this.DgvPer.Name = "DgvPer";
            this.DgvPer.Size = new System.Drawing.Size(494, 171);
            this.DgvPer.TabIndex = 96;
            this.DgvPer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPer_CellContentClick);
            this.DgvPer.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPer_CellContentDoubleClick);
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Location = new System.Drawing.Point(516, 34);
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.ReadOnly = true;
            this.txtCodUsu.Size = new System.Drawing.Size(10, 22);
            this.txtCodUsu.TabIndex = 97;
            this.txtCodUsu.Visible = false;
            // 
            // wAsignarPlantas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(537, 310);
            this.Controls.Add(this.txtCodUsu);
            this.Controls.Add(this.DgvPer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtUsu);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wAsignarPlantas";
            this.Text = "Asignar Almacenes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wAsignarPlantas_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.txtUsu, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.DgvPer, 0);
            this.Controls.SetChildIndex(this.txtCodUsu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.DataGridView DgvPer;
        private System.Windows.Forms.TextBox txtCodUsu;
    }
}
