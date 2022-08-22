namespace Presentacion.Procesos
{
    partial class wInsumosFaltantesCompra
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
            this.label16 = new System.Windows.Forms.Label();
            this.dgvInsFal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(554, 289);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExpExc
            // 
            this.btnExpExc.Location = new System.Drawing.Point(427, 289);
            this.btnExpExc.Name = "btnExpExc";
            this.btnExpExc.Size = new System.Drawing.Size(121, 25);
            this.btnExpExc.TabIndex = 42;
            this.btnExpExc.Text = "Exportar excel";
            this.btnExpExc.UseVisualStyleBackColor = true;
            this.btnExpExc.Click += new System.EventHandler(this.btnExpExc_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.DarkGray;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(25, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(628, 14);
            this.label16.TabIndex = 399;
            this.label16.Text = "Existencias sin stock suficiente";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvInsFal
            // 
            this.dgvInsFal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsFal.Location = new System.Drawing.Point(25, 46);
            this.dgvInsFal.Name = "dgvInsFal";
            this.dgvInsFal.Size = new System.Drawing.Size(628, 237);
            this.dgvInsFal.TabIndex = 430;
            // 
            // wInsumosFaltantesCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(680, 333);
            this.ControlBox = false;
            this.Controls.Add(this.dgvInsFal);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExpExc);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wInsumosFaltantesCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insumos Faltantes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wInsumosFaltantesCompra_FormClosing);
            this.Controls.SetChildIndex(this.btnExpExc, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.dgvInsFal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsFal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExpExc;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.DataGridView dgvInsFal;
    }
}