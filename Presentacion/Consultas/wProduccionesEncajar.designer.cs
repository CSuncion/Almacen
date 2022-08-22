namespace Presentacion.Consultas
{
    partial class wProduccionesEncajar
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
            this.lblTit = new System.Windows.Forms.Label();
            this.dgvMovDet = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtNumCaj = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCanUniProTer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdicionarDistr = new System.Windows.Forms.Button();
            this.btnEliminarDistr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLibProTer = new System.Windows.Forms.DataGridView();
            this.btnModificarFcLote = new System.Windows.Forms.Button();
            this.txtUniXEmp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibProTer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTit
            // 
            this.lblTit.BackColor = System.Drawing.Color.DarkGray;
            this.lblTit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTit.ForeColor = System.Drawing.Color.White;
            this.lblTit.Location = new System.Drawing.Point(24, 31);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(532, 14);
            this.lblTit.TabIndex = 418;
            this.lblTit.Text = "Filtros";
            this.lblTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvMovDet
            // 
            this.dgvMovDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovDet.Location = new System.Drawing.Point(25, 48);
            this.dgvMovDet.Name = "dgvMovDet";
            this.dgvMovDet.Size = new System.Drawing.Size(531, 163);
            this.dgvMovDet.TabIndex = 431;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(447, 472);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 25);
            this.btnSalir.TabIndex = 433;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtNumCaj
            // 
            this.txtNumCaj.Location = new System.Drawing.Point(134, 273);
            this.txtNumCaj.MaxLength = 7;
            this.txtNumCaj.Name = "txtNumCaj";
            this.txtNumCaj.ReadOnly = true;
            this.txtNumCaj.Size = new System.Drawing.Size(102, 22);
            this.txtNumCaj.TabIndex = 437;
            this.txtNumCaj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 14);
            this.label4.TabIndex = 436;
            this.label4.Text = "Cantidad Cajas";
            // 
            // txtCanUniProTer
            // 
            this.txtCanUniProTer.Location = new System.Drawing.Point(134, 245);
            this.txtCanUniProTer.MaxLength = 7;
            this.txtCanUniProTer.Name = "txtCanUniProTer";
            this.txtCanUniProTer.Size = new System.Drawing.Size(102, 22);
            this.txtCanUniProTer.TabIndex = 435;
            this.txtCanUniProTer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanUniProTer.Validated += new System.EventHandler(this.txtCanUniProTer_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 434;
            this.label6.Text = "Cantidad Uni";
            // 
            // btnAdicionarDistr
            // 
            this.btnAdicionarDistr.Location = new System.Drawing.Point(268, 273);
            this.btnAdicionarDistr.Name = "btnAdicionarDistr";
            this.btnAdicionarDistr.Size = new System.Drawing.Size(141, 25);
            this.btnAdicionarDistr.TabIndex = 438;
            this.btnAdicionarDistr.Text = "Adicionar Distribucion";
            this.btnAdicionarDistr.UseVisualStyleBackColor = true;
            this.btnAdicionarDistr.Click += new System.EventHandler(this.btnAdicionarDistr_Click);
            // 
            // btnEliminarDistr
            // 
            this.btnEliminarDistr.Location = new System.Drawing.Point(415, 273);
            this.btnEliminarDistr.Name = "btnEliminarDistr";
            this.btnEliminarDistr.Size = new System.Drawing.Size(141, 25);
            this.btnEliminarDistr.TabIndex = 439;
            this.btnEliminarDistr.Text = "Eliminar Distribucion";
            this.btnEliminarDistr.UseVisualStyleBackColor = true;
            this.btnEliminarDistr.Click += new System.EventHandler(this.btnEliminarDistr_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(532, 14);
            this.label1.TabIndex = 440;
            this.label1.Text = "Distribucion de unidades a empaquetar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvLibProTer
            // 
            this.dgvLibProTer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibProTer.Location = new System.Drawing.Point(25, 319);
            this.dgvLibProTer.Name = "dgvLibProTer";
            this.dgvLibProTer.Size = new System.Drawing.Size(531, 149);
            this.dgvLibProTer.TabIndex = 441;
            // 
            // btnModificarFcLote
            // 
            this.btnModificarFcLote.Location = new System.Drawing.Point(25, 472);
            this.btnModificarFcLote.Name = "btnModificarFcLote";
            this.btnModificarFcLote.Size = new System.Drawing.Size(126, 25);
            this.btnModificarFcLote.TabIndex = 442;
            this.btnModificarFcLote.Text = "Modificar Fc. Lote";
            this.btnModificarFcLote.UseVisualStyleBackColor = true;
            this.btnModificarFcLote.Click += new System.EventHandler(this.btnModificarFcLote_Click);
            // 
            // txtUniXEmp
            // 
            this.txtUniXEmp.Location = new System.Drawing.Point(134, 217);
            this.txtUniXEmp.MaxLength = 7;
            this.txtUniXEmp.Name = "txtUniXEmp";
            this.txtUniXEmp.ReadOnly = true;
            this.txtUniXEmp.Size = new System.Drawing.Size(102, 22);
            this.txtUniXEmp.TabIndex = 444;
            this.txtUniXEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 14);
            this.label3.TabIndex = 443;
            this.label3.Text = "Uni x Empaque";
            // 
            // wProduccionesEncajar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(584, 521);
            this.Controls.Add(this.txtUniXEmp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModificarFcLote);
            this.Controls.Add(this.dgvLibProTer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminarDistr);
            this.Controls.Add(this.btnAdicionarDistr);
            this.Controls.Add(this.txtNumCaj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCanUniProTer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvMovDet);
            this.Controls.Add(this.lblTit);
            this.Name = "wProduccionesEncajar";
            this.Text = "Liberaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wProduccionesEncajar_FormClosing);
            this.Controls.SetChildIndex(this.lblTit, 0);
            this.Controls.SetChildIndex(this.dgvMovDet, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCanUniProTer, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtNumCaj, 0);
            this.Controls.SetChildIndex(this.btnAdicionarDistr, 0);
            this.Controls.SetChildIndex(this.btnEliminarDistr, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgvLibProTer, 0);
            this.Controls.SetChildIndex(this.btnModificarFcLote, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtUniXEmp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibProTer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTit;
        internal System.Windows.Forms.DataGridView dgvMovDet;
        private System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.TextBox txtNumCaj;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtCanUniProTer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdicionarDistr;
        private System.Windows.Forms.Button btnEliminarDistr;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView dgvLibProTer;
        private System.Windows.Forms.Button btnModificarFcLote;
        internal System.Windows.Forms.TextBox txtUniXEmp;
        private System.Windows.Forms.Label label3;
    }
}
