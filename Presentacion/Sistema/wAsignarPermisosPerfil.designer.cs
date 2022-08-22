namespace Presentacion.Sistema
{
    partial class wAsignarPermisosPerfil
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblTitVen = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPer = new System.Windows.Forms.TextBox();
            this.DgvVen = new System.Windows.Forms.DataGridView();
            this.txtCodPer = new System.Windows.Forms.TextBox();
            this.lblTitPer = new System.Windows.Forms.Label();
            this.btnMarcarTodas = new System.Windows.Forms.Button();
            this.btnDesmarcarTodas = new System.Windows.Forms.Button();
            this.DgvPer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(273, 514);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 25);
            this.btnSalir.TabIndex = 71;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(159, 514);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblTitVen
            // 
            this.lblTitVen.BackColor = System.Drawing.Color.DarkGray;
            this.lblTitVen.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitVen.ForeColor = System.Drawing.Color.White;
            this.lblTitVen.Location = new System.Drawing.Point(23, 63);
            this.lblTitVen.Name = "lblTitVen";
            this.lblTitVen.Size = new System.Drawing.Size(365, 14);
            this.lblTitVen.TabIndex = 74;
            this.lblTitVen.Text = "Ventanas";
            this.lblTitVen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 75;
            this.label11.Text = "Perfil:";
            // 
            // txtPer
            // 
            this.txtPer.Location = new System.Drawing.Point(87, 34);
            this.txtPer.Name = "txtPer";
            this.txtPer.ReadOnly = true;
            this.txtPer.Size = new System.Drawing.Size(295, 22);
            this.txtPer.TabIndex = 76;
            // 
            // DgvVen
            // 
            this.DgvVen.BackgroundColor = System.Drawing.Color.White;
            this.DgvVen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvVen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVen.GridColor = System.Drawing.Color.Silver;
            this.DgvVen.Location = new System.Drawing.Point(17, 80);
            this.DgvVen.Name = "DgvVen";
            this.DgvVen.Size = new System.Drawing.Size(365, 220);
            this.DgvVen.TabIndex = 96;
            this.DgvVen.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVen_CellEnter);
            // 
            // txtCodPer
            // 
            this.txtCodPer.Location = new System.Drawing.Point(383, 34);
            this.txtCodPer.Name = "txtCodPer";
            this.txtCodPer.ReadOnly = true;
            this.txtCodPer.Size = new System.Drawing.Size(10, 22);
            this.txtCodPer.TabIndex = 97;
            this.txtCodPer.Visible = false;
            // 
            // lblTitPer
            // 
            this.lblTitPer.BackColor = System.Drawing.Color.DarkGray;
            this.lblTitPer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitPer.ForeColor = System.Drawing.Color.White;
            this.lblTitPer.Location = new System.Drawing.Point(17, 304);
            this.lblTitPer.Name = "lblTitPer";
            this.lblTitPer.Size = new System.Drawing.Size(365, 14);
            this.lblTitPer.TabIndex = 100;
            this.lblTitPer.Text = "Botones de laVentana";
            this.lblTitPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMarcarTodas
            // 
            this.btnMarcarTodas.Location = new System.Drawing.Point(17, 321);
            this.btnMarcarTodas.Name = "btnMarcarTodas";
            this.btnMarcarTodas.Size = new System.Drawing.Size(109, 25);
            this.btnMarcarTodas.TabIndex = 101;
            this.btnMarcarTodas.Text = "Marcar Todas";
            this.btnMarcarTodas.UseVisualStyleBackColor = true;
            this.btnMarcarTodas.Click += new System.EventHandler(this.btnMarcarTodas_Click);
            // 
            // btnDesmarcarTodas
            // 
            this.btnDesmarcarTodas.Location = new System.Drawing.Point(132, 321);
            this.btnDesmarcarTodas.Name = "btnDesmarcarTodas";
            this.btnDesmarcarTodas.Size = new System.Drawing.Size(109, 25);
            this.btnDesmarcarTodas.TabIndex = 102;
            this.btnDesmarcarTodas.Text = "Desmarcar Todas";
            this.btnDesmarcarTodas.UseVisualStyleBackColor = true;
            this.btnDesmarcarTodas.Click += new System.EventHandler(this.btnDesmarcarTodas_Click);
            // 
            // DgvPer
            // 
            this.DgvPer.BackgroundColor = System.Drawing.Color.White;
            this.DgvPer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvPer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPer.GridColor = System.Drawing.Color.Silver;
            this.DgvPer.Location = new System.Drawing.Point(17, 352);
            this.DgvPer.Name = "DgvPer";
            this.DgvPer.Size = new System.Drawing.Size(365, 159);
            this.DgvPer.TabIndex = 103;
            this.DgvPer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPer_CellContentClick);
            this.DgvPer.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPer_CellContentDoubleClick);
            // 
            // wAsignarPermisosPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(400, 551);
            this.Controls.Add(this.DgvPer);
            this.Controls.Add(this.btnDesmarcarTodas);
            this.Controls.Add(this.btnMarcarTodas);
            this.Controls.Add(this.lblTitPer);
            this.Controls.Add(this.txtCodPer);
            this.Controls.Add(this.DgvVen);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPer);
            this.Controls.Add(this.lblTitVen);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wAsignarPermisosPerfil";
            this.Text = "Asignar Permisos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wAsignarPermisosPerfil_FormClosing);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblTitVen, 0);
            this.Controls.SetChildIndex(this.txtPer, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.DgvVen, 0);
            this.Controls.SetChildIndex(this.txtCodPer, 0);
            this.Controls.SetChildIndex(this.lblTitPer, 0);
            this.Controls.SetChildIndex(this.btnMarcarTodas, 0);
            this.Controls.SetChildIndex(this.btnDesmarcarTodas, 0);
            this.Controls.SetChildIndex(this.DgvPer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvVen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTitVen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPer;
        private System.Windows.Forms.DataGridView DgvVen;
        private System.Windows.Forms.TextBox txtCodPer;
        private System.Windows.Forms.Label lblTitPer;
        private System.Windows.Forms.Button btnMarcarTodas;
        private System.Windows.Forms.Button btnDesmarcarTodas;
        private System.Windows.Forms.DataGridView DgvPer;
    }
}
