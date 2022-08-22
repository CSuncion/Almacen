namespace Presentacion.Procesos
{
    partial class wInsumosFaltantes
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExpExc = new System.Windows.Forms.Button();
            this.txtCorProDet = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.dgvInsFal = new System.Windows.Forms.DataGridView();
            this.txtCodExi = new System.Windows.Forms.TextBox();
            this.txtDesExi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCorProCab = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(567, 382);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExpExc
            // 
            this.btnExpExc.Location = new System.Drawing.Point(440, 382);
            this.btnExpExc.Name = "btnExpExc";
            this.btnExpExc.Size = new System.Drawing.Size(121, 25);
            this.btnExpExc.TabIndex = 42;
            this.btnExpExc.Text = "Exportar excel";
            this.btnExpExc.UseVisualStyleBackColor = true;
            this.btnExpExc.Click += new System.EventHandler(this.btnExpExc_Click);
            // 
            // txtCorProDet
            // 
            this.txtCorProDet.Location = new System.Drawing.Point(148, 40);
            this.txtCorProDet.MaxLength = 4;
            this.txtCorProDet.Name = "txtCorProDet";
            this.txtCorProDet.ReadOnly = true;
            this.txtCorProDet.Size = new System.Drawing.Size(33, 22);
            this.txtCorProDet.TabIndex = 377;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 14);
            this.label14.TabIndex = 376;
            this.label14.Text = "Correlativo";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.DarkGray;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(38, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(628, 14);
            this.label16.TabIndex = 399;
            this.label16.Text = "Existencias sin stock suficiente";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 411;
            this.label2.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(148, 96);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.ReadOnly = true;
            this.txtCodAlm.Size = new System.Drawing.Size(28, 22);
            this.txtCodAlm.TabIndex = 409;
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(177, 96);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(214, 22);
            this.txtDesAlm.TabIndex = 410;
            // 
            // dgvInsFal
            // 
            this.dgvInsFal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsFal.Location = new System.Drawing.Point(38, 169);
            this.dgvInsFal.Name = "dgvInsFal";
            this.dgvInsFal.Size = new System.Drawing.Size(628, 207);
            this.dgvInsFal.TabIndex = 430;
            // 
            // txtCodExi
            // 
            this.txtCodExi.Location = new System.Drawing.Point(148, 124);
            this.txtCodExi.MaxLength = 15;
            this.txtCodExi.Name = "txtCodExi";
            this.txtCodExi.ReadOnly = true;
            this.txtCodExi.Size = new System.Drawing.Size(102, 22);
            this.txtCodExi.TabIndex = 433;
            // 
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(251, 124);
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(360, 22);
            this.txtDesExi.TabIndex = 432;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 431;
            this.label1.Text = "Formula";
            // 
            // txtCorProCab
            // 
            this.txtCorProCab.Location = new System.Drawing.Point(148, 68);
            this.txtCorProCab.MaxLength = 15;
            this.txtCorProCab.Name = "txtCorProCab";
            this.txtCorProCab.ReadOnly = true;
            this.txtCorProCab.Size = new System.Drawing.Size(102, 22);
            this.txtCorProCab.TabIndex = 435;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 434;
            this.label4.Text = "Solicitud";
            // 
            // wInsumosFaltantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(696, 428);
            this.ControlBox = false;
            this.Controls.Add(this.txtCorProCab);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodExi);
            this.Controls.Add(this.txtDesExi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInsFal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodAlm);
            this.Controls.Add(this.txtDesAlm);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtCorProDet);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExpExc);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wInsumosFaltantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insumos Faltantes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wInsumosFaltantes_FormClosing);
            this.Controls.SetChildIndex(this.btnExpExc, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtCorProDet, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtDesAlm, 0);
            this.Controls.SetChildIndex(this.txtCodAlm, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dgvInsFal, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDesExi, 0);
            this.Controls.SetChildIndex(this.txtCodExi, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtCorProCab, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExpExc;
        internal System.Windows.Forms.TextBox txtCorProDet;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtCodAlm;
        internal System.Windows.Forms.DataGridView dgvInsFal;
        internal System.Windows.Forms.TextBox txtDesAlm;
        private System.Windows.Forms.TextBox txtCodExi;
        private System.Windows.Forms.TextBox txtDesExi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCorProCab;
        private System.Windows.Forms.Label label4;
    }
}