namespace Presentacion.ProcesosCompras
{
    partial class wGenerarOrdenCompraPorItemDeRequerimiento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFecDoc = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodAux = new System.Windows.Forms.TextBox();
            this.txtDesAux = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvMovDet = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(521, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 14);
            this.label10.TabIndex = 435;
            this.label10.Text = "Fech.Docum";
            // 
            // dtpFecDoc
            // 
            this.dtpFecDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDoc.Location = new System.Drawing.Point(524, 64);
            this.dtpFecDoc.Name = "dtpFecDoc";
            this.dtpFecDoc.Size = new System.Drawing.Size(108, 22);
            this.dtpFecDoc.TabIndex = 434;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 14);
            this.label5.TabIndex = 433;
            this.label5.Text = "Proveedor:";
            // 
            // txtCodAux
            // 
            this.txtCodAux.Location = new System.Drawing.Point(17, 64);
            this.txtCodAux.Name = "txtCodAux";
            this.txtCodAux.Size = new System.Drawing.Size(102, 22);
            this.txtCodAux.TabIndex = 431;
            this.txtCodAux.DoubleClick += new System.EventHandler(this.txtCodAux_DoubleClick);
            this.txtCodAux.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAux_KeyDown);
            this.txtCodAux.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAux_Validating);
            // 
            // txtDesAux
            // 
            this.txtDesAux.Location = new System.Drawing.Point(125, 64);
            this.txtDesAux.Name = "txtDesAux";
            this.txtDesAux.ReadOnly = true;
            this.txtDesAux.Size = new System.Drawing.Size(393, 22);
            this.txtDesAux.TabIndex = 432;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(620, 22);
            this.label4.TabIndex = 430;
            this.label4.Text = "Datos Proveedor";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvMovDet
            // 
            this.dgvMovDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovDet.Location = new System.Drawing.Point(11, 92);
            this.dgvMovDet.Name = "dgvMovDet";
            this.dgvMovDet.Size = new System.Drawing.Size(621, 178);
            this.dgvMovDet.TabIndex = 436;
            this.dgvMovDet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovDet_CellContentClick);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(428, 276);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 25);
            this.btnAceptar.TabIndex = 437;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(533, 276);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 438;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // wGenerarOrdenCompraPorItemDeRequerimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 315);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvMovDet);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpFecDoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodAux);
            this.Controls.Add(this.txtDesAux);
            this.Controls.Add(this.label4);
            this.Name = "wGenerarOrdenCompraPorItemDeRequerimiento";
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wGenerarOrdenCompraPorItemDeRequerimiento_FormClosing);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDesAux, 0);
            this.Controls.SetChildIndex(this.txtCodAux, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dtpFecDoc, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.dgvMovDet, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.DateTimePicker dtpFecDoc;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtCodAux;
        private System.Windows.Forms.TextBox txtDesAux;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DataGridView dgvMovDet;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}