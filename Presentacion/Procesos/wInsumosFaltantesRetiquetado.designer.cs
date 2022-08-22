namespace Presentacion.Procesos
{
    partial class wInsumosFaltantesRetiquetado
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
            this.dgvInsFal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(564, 299);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExpExc
            // 
            this.btnExpExc.Location = new System.Drawing.Point(437, 299);
            this.btnExpExc.Name = "btnExpExc";
            this.btnExpExc.Size = new System.Drawing.Size(121, 25);
            this.btnExpExc.TabIndex = 42;
            this.btnExpExc.Text = "Exportar excel";
            this.btnExpExc.UseVisualStyleBackColor = true;
            this.btnExpExc.Click += new System.EventHandler(this.btnExpExc_Click);
            // 
            // txtCorProDet
            // 
            this.txtCorProDet.Location = new System.Drawing.Point(118, 40);
            this.txtCorProDet.MaxLength = 4;
            this.txtCorProDet.Name = "txtCorProDet";
            this.txtCorProDet.ReadOnly = true;
            this.txtCorProDet.Size = new System.Drawing.Size(84, 22);
            this.txtCorProDet.TabIndex = 377;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 14);
            this.label14.TabIndex = 376;
            this.label14.Text = "Numero";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.DarkGray;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(35, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(628, 14);
            this.label16.TabIndex = 399;
            this.label16.Text = "Existencias sin stock suficiente";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvInsFal
            // 
            this.dgvInsFal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsFal.Location = new System.Drawing.Point(35, 86);
            this.dgvInsFal.Name = "dgvInsFal";
            this.dgvInsFal.Size = new System.Drawing.Size(628, 207);
            this.dgvInsFal.TabIndex = 430;
            // 
            // wInsumosFaltantesEncajado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(696, 350);
            this.ControlBox = false;
            this.Controls.Add(this.dgvInsFal);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtCorProDet);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExpExc);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wInsumosFaltantesEncajado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insumos Faltantes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wInsumosFaltantesRetiquetado_FormClosing);
            this.Controls.SetChildIndex(this.btnExpExc, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtCorProDet, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.dgvInsFal, 0);
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
        internal System.Windows.Forms.DataGridView dgvInsFal;
    }
}