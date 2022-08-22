namespace Presentacion.Procesos
{
    partial class wAprobarSolicitud
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.DgvBot = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnDesaprobar = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(595, 348);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 25);
            this.btnSalir.TabIndex = 71;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(20, 348);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(109, 25);
            this.btnAgregar.TabIndex = 72;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(21, 29);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(683, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Solicitudes para Aprobar";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvBot
            // 
            this.DgvBot.BackgroundColor = System.Drawing.Color.White;
            this.DgvBot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvBot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBot.GridColor = System.Drawing.Color.Silver;
            this.DgvBot.Location = new System.Drawing.Point(20, 46);
            this.DgvBot.Name = "DgvBot";
            this.DgvBot.Size = new System.Drawing.Size(684, 296);
            this.DgvBot.TabIndex = 96;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(135, 348);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(109, 25);
            this.btnQuitar.TabIndex = 98;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnDesaprobar
            // 
            this.btnDesaprobar.Location = new System.Drawing.Point(480, 348);
            this.btnDesaprobar.Name = "btnDesaprobar";
            this.btnDesaprobar.Size = new System.Drawing.Size(109, 25);
            this.btnDesaprobar.TabIndex = 99;
            this.btnDesaprobar.Text = "Desaprobar";
            this.btnDesaprobar.UseVisualStyleBackColor = true;
            this.btnDesaprobar.Click += new System.EventHandler(this.btnDesaprobar_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.Location = new System.Drawing.Point(365, 348);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(109, 25);
            this.btnAprobar.TabIndex = 100;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Location = new System.Drawing.Point(250, 348);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(109, 25);
            this.btnCompras.TabIndex = 101;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // wAprobarSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(727, 402);
            this.Controls.Add(this.btnCompras);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnDesaprobar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.DgvBot);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wAprobarSolicitud";
            this.Text = "Aprobacion de Solicitudes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wAprobarSolicitud_FormClosing);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.DgvBot, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.btnDesaprobar, 0);
            this.Controls.SetChildIndex(this.btnAprobar, 0);
            this.Controls.SetChildIndex(this.btnCompras, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView DgvBot;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnDesaprobar;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnCompras;
    }
}
