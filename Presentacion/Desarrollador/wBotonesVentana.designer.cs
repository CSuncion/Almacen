namespace Presentacion.Desarrollador
{
    partial class wBotonesVentana
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
            this.label11 = new System.Windows.Forms.Label();
            this.txtVen = new System.Windows.Forms.TextBox();
            this.DgvBot = new System.Windows.Forms.DataGridView();
            this.txtCodVen = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(250, 384);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 25);
            this.btnSalir.TabIndex = 71;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(20, 384);
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
            this.label21.Location = new System.Drawing.Point(17, 66);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(342, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Botones de la Ventana";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 14);
            this.label11.TabIndex = 75;
            this.label11.Text = "Ventana:";
            // 
            // txtVen
            // 
            this.txtVen.Location = new System.Drawing.Point(74, 34);
            this.txtVen.Name = "txtVen";
            this.txtVen.ReadOnly = true;
            this.txtVen.Size = new System.Drawing.Size(285, 22);
            this.txtVen.TabIndex = 76;
            // 
            // DgvBot
            // 
            this.DgvBot.BackgroundColor = System.Drawing.Color.White;
            this.DgvBot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvBot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBot.GridColor = System.Drawing.Color.Silver;
            this.DgvBot.Location = new System.Drawing.Point(17, 85);
            this.DgvBot.Name = "DgvBot";
            this.DgvBot.Size = new System.Drawing.Size(342, 293);
            this.DgvBot.TabIndex = 96;
            // 
            // txtCodVen
            // 
            this.txtCodVen.Location = new System.Drawing.Point(359, 34);
            this.txtCodVen.Name = "txtCodVen";
            this.txtCodVen.ReadOnly = true;
            this.txtCodVen.Size = new System.Drawing.Size(10, 22);
            this.txtCodVen.TabIndex = 97;
            this.txtCodVen.Visible = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(135, 384);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(109, 25);
            this.btnQuitar.TabIndex = 98;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // wBotonesVentana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(376, 423);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.txtCodVen);
            this.Controls.Add(this.DgvBot);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtVen);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wBotonesVentana";
            this.Text = "Botones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wOpciones_FormClosing);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.txtVen, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.DgvBot, 0);
            this.Controls.SetChildIndex(this.txtCodVen, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView DgvBot;
        private System.Windows.Forms.Button btnQuitar;
        internal System.Windows.Forms.TextBox txtCodVen;
        internal System.Windows.Forms.TextBox txtVen;
    }
}
