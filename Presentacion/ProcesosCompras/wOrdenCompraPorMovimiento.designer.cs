namespace Presentacion.ProcesosCompras
{
    partial class wOrdenCompraPorMovimiento
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
            this.dgvMov = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.txtClaveOC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCanTot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMov)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(119, 211);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 25);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvMov
            // 
            this.dgvMov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMov.Location = new System.Drawing.Point(33, 64);
            this.dgvMov.Name = "dgvMov";
            this.dgvMov.Size = new System.Drawing.Size(429, 138);
            this.dgvMov.TabIndex = 430;
            // 
            // btnQuitar
            // 
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(33, 211);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(80, 25);
            this.btnQuitar.TabIndex = 433;
            this.btnQuitar.Tag = "19";
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // txtClaveOC
            // 
            this.txtClaveOC.Location = new System.Drawing.Point(119, 35);
            this.txtClaveOC.MaxLength = 15;
            this.txtClaveOC.Name = "txtClaveOC";
            this.txtClaveOC.ReadOnly = true;
            this.txtClaveOC.Size = new System.Drawing.Size(192, 22);
            this.txtClaveOC.TabIndex = 436;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 434;
            this.label2.Text = "Orden Compra";
            // 
            // txtCanTot
            // 
            this.txtCanTot.Location = new System.Drawing.Point(399, 208);
            this.txtCanTot.MaxLength = 15;
            this.txtCanTot.Name = "txtCanTot";
            this.txtCanTot.ReadOnly = true;
            this.txtCanTot.Size = new System.Drawing.Size(63, 22);
            this.txtCanTot.TabIndex = 438;
            this.txtCanTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 437;
            this.label1.Text = "Cantidad Total";
            // 
            // wOrdenCompraPorMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 257);
            this.ControlBox = false;
            this.Controls.Add(this.txtCanTot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClaveOC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.dgvMov);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wOrdenCompraPorMovimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento por Orden de Compra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wOrdenCompraPorMovimiento_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.dgvMov, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtClaveOC, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCanTot, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.DataGridView dgvMov;
        internal System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.TextBox txtClaveOC;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCanTot;
        internal System.Windows.Forms.Label label2;
    }
}