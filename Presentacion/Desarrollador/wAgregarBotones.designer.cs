namespace Presentacion.Desarrollador
{
    partial class wAgregarBotones
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
            this.lblTit = new System.Windows.Forms.Label();
            this.DgvBot = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(197, 350);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(82, 350);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblTit
            // 
            this.lblTit.BackColor = System.Drawing.Color.DarkGray;
            this.lblTit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTit.ForeColor = System.Drawing.Color.White;
            this.lblTit.Location = new System.Drawing.Point(17, 33);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(289, 14);
            this.lblTit.TabIndex = 74;
            this.lblTit.Text = "Botones de la Ventana";
            this.lblTit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvBot
            // 
            this.DgvBot.BackgroundColor = System.Drawing.Color.White;
            this.DgvBot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvBot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBot.GridColor = System.Drawing.Color.Silver;
            this.DgvBot.Location = new System.Drawing.Point(17, 52);
            this.DgvBot.Name = "DgvBot";
            this.DgvBot.Size = new System.Drawing.Size(289, 293);
            this.DgvBot.TabIndex = 96;
            this.DgvBot.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBot_CellValueChanged);
            // 
            // wAgregarBotones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(322, 386);
            this.Controls.Add(this.DgvBot);
            this.Controls.Add(this.lblTit);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wAgregarBotones";
            this.Text = "Botones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wAgregarBotones_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblTit, 0);
            this.Controls.SetChildIndex(this.DgvBot, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTit;
        private System.Windows.Forms.DataGridView DgvBot;
    }
}
