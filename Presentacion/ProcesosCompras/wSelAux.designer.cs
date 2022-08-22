namespace Presentacion.ProcesosCompras
{
    partial class wSelAux
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumSolPedidoCab = new System.Windows.Forms.TextBox();
            this.gbBus = new System.Windows.Forms.GroupBox();
            this.txtBus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            this.gbBus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(252, 459);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(154, 23);
            this.btnCancelar.TabIndex = 112;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(87, 459);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(159, 23);
            this.btnGenerar.TabIndex = 111;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // DgvLista
            // 
            this.DgvLista.BackgroundColor = System.Drawing.Color.White;
            this.DgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Location = new System.Drawing.Point(22, 117);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.Size = new System.Drawing.Size(472, 336);
            this.DgvLista.TabIndex = 110;
            this.DgvLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellContentClick);
            this.DgvLista.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvLista_ColumnHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 14);
            this.label1.TabIndex = 114;
            this.label1.Text = "Número:";
            // 
            // txtNumSolPedidoCab
            // 
            this.txtNumSolPedidoCab.Location = new System.Drawing.Point(65, 17);
            this.txtNumSolPedidoCab.Name = "txtNumSolPedidoCab";
            this.txtNumSolPedidoCab.Size = new System.Drawing.Size(163, 22);
            this.txtNumSolPedidoCab.TabIndex = 113;
            // 
            // gbBus
            // 
            this.gbBus.Controls.Add(this.txtBus);
            this.gbBus.Controls.Add(this.txtNumSolPedidoCab);
            this.gbBus.Controls.Add(this.label1);
            this.gbBus.Location = new System.Drawing.Point(22, 28);
            this.gbBus.Name = "gbBus";
            this.gbBus.Size = new System.Drawing.Size(472, 83);
            this.gbBus.TabIndex = 0;
            this.gbBus.TabStop = false;
            this.gbBus.Text = "GroupBox1";
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(9, 45);
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(457, 22);
            this.txtBus.TabIndex = 115;
            this.txtBus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBus_KeyPress);
            this.txtBus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBus_KeyUp);
            // 
            // wSelAux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(518, 507);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.DgvLista);
            this.Controls.Add(this.gbBus);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wSelAux";
            this.Text = "Listar ItemG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wSelAux_FormClosing);
            this.Controls.SetChildIndex(this.gbBus, 0);
            this.Controls.SetChildIndex(this.DgvLista, 0);
            this.Controls.SetChildIndex(this.btnGenerar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            this.gbBus.ResumeLayout(false);
            this.gbBus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnGenerar;
        internal System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumSolPedidoCab;
        internal System.Windows.Forms.GroupBox gbBus;
        internal System.Windows.Forms.TextBox txtBus;
    }
}
