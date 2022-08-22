namespace Presentacion.Impresiones
{
    partial class wActualizarTomaInventario
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
            this.ckbCodExi = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodExiHas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodExiDes = new System.Windows.Forms.TextBox();
            this.cmbTipExi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvMovDet = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(509, 84);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(509, 58);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // ckbCodExi
            // 
            this.ckbCodExi.AutoSize = true;
            this.ckbCodExi.Location = new System.Drawing.Point(211, 62);
            this.ckbCodExi.Name = "ckbCodExi";
            this.ckbCodExi.Size = new System.Drawing.Size(58, 18);
            this.ckbCodExi.TabIndex = 91;
            this.ckbCodExi.Text = "Todos";
            this.ckbCodExi.UseVisualStyleBackColor = true;
            this.ckbCodExi.CheckedChanged += new System.EventHandler(this.ckbCodExi_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 86;
            this.label2.Text = "Exis Hasta";
            // 
            // txtCodExiHas
            // 
            this.txtCodExiHas.Location = new System.Drawing.Point(105, 86);
            this.txtCodExiHas.MaxLength = 2;
            this.txtCodExiHas.Name = "txtCodExiHas";
            this.txtCodExiHas.Size = new System.Drawing.Size(100, 22);
            this.txtCodExiHas.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 84;
            this.label1.Text = "Exis Desde";
            // 
            // txtCodExiDes
            // 
            this.txtCodExiDes.Location = new System.Drawing.Point(105, 59);
            this.txtCodExiDes.MaxLength = 2;
            this.txtCodExiDes.Name = "txtCodExiDes";
            this.txtCodExiDes.Size = new System.Drawing.Size(100, 22);
            this.txtCodExiDes.TabIndex = 85;
            // 
            // cmbTipExi
            // 
            this.cmbTipExi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipExi.Location = new System.Drawing.Point(366, 59);
            this.cmbTipExi.Name = "cmbTipExi";
            this.cmbTipExi.Size = new System.Drawing.Size(128, 22);
            this.cmbTipExi.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 81;
            this.label3.Text = "Orden";
            // 
            // dgvMovDet
            // 
            this.dgvMovDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovDet.Location = new System.Drawing.Point(26, 161);
            this.dgvMovDet.Name = "dgvMovDet";
            this.dgvMovDet.Size = new System.Drawing.Size(592, 306);
            this.dgvMovDet.TabIndex = 431;
            this.dgvMovDet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovDet_CellClick);
            this.dgvMovDet.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovDet_CellEnter);
            this.dgvMovDet.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvMovDet_CellValidating);
            this.dgvMovDet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovDet_CellValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(413, 14);
            this.label4.TabIndex = 432;
            this.label4.Text = "Posicionece en las celdas de la columna \"Cantidad\" y digite el nuevo valor";
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DarkGray;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(23, 36);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(595, 14);
            this.label24.TabIndex = 433;
            this.label24.Text = "Datos Filtros";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(23, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(595, 14);
            this.label5.TabIndex = 434;
            this.label5.Text = "Datos Existencias";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wActualizarTomaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(645, 492);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.ckbCodExi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvMovDet);
            this.Controls.Add(this.txtCodExiHas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodExiDes);
            this.Controls.Add(this.cmbTipExi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "wActualizarTomaInventario";
            this.Text = "Actualizar Cantidad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wActualizarTomaInventario_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbTipExi, 0);
            this.Controls.SetChildIndex(this.txtCodExiDes, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCodExiHas, 0);
            this.Controls.SetChildIndex(this.dgvMovDet, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.ckbCodExi, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodExiHas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodExiDes;
        private System.Windows.Forms.ComboBox cmbTipExi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbCodExi;
        internal System.Windows.Forms.DataGridView dgvMovDet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label5;
    }
}
