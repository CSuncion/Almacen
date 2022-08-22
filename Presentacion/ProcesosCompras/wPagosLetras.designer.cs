namespace Presentacion.ProcesosCompras
{
    partial class wPagosLetras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodAux = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomAux = new System.Windows.Forms.TextBox();
            this.txtNomDir = new System.Windows.Forms.TextBox();
            this.DgvOrdCom = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblLetras = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdCom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 31;
            this.label1.Text = "Auxiliar";
            // 
            // txtCodAux
            // 
            this.txtCodAux.Location = new System.Drawing.Point(114, 38);
            this.txtCodAux.MaxLength = 4;
            this.txtCodAux.Name = "txtCodAux";
            this.txtCodAux.ReadOnly = true;
            this.txtCodAux.Size = new System.Drawing.Size(89, 22);
            this.txtCodAux.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "Dirección";
            // 
            // txtNomAux
            // 
            this.txtNomAux.Location = new System.Drawing.Point(209, 38);
            this.txtNomAux.Name = "txtNomAux";
            this.txtNomAux.ReadOnly = true;
            this.txtNomAux.Size = new System.Drawing.Size(281, 22);
            this.txtNomAux.TabIndex = 34;
            // 
            // txtNomDir
            // 
            this.txtNomDir.Location = new System.Drawing.Point(114, 97);
            this.txtNomDir.Name = "txtNomDir";
            this.txtNomDir.ReadOnly = true;
            this.txtNomDir.Size = new System.Drawing.Size(376, 22);
            this.txtNomDir.TabIndex = 39;
            // 
            // DgvOrdCom
            // 
            this.DgvOrdCom.AllowUserToAddRows = false;
            this.DgvOrdCom.AllowUserToDeleteRows = false;
            this.DgvOrdCom.BackgroundColor = System.Drawing.Color.White;
            this.DgvOrdCom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvOrdCom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvOrdCom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvOrdCom.Location = new System.Drawing.Point(25, 144);
            this.DgvOrdCom.MultiSelect = false;
            this.DgvOrdCom.Name = "DgvOrdCom";
            this.DgvOrdCom.Size = new System.Drawing.Size(465, 177);
            this.DgvOrdCom.TabIndex = 271;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(383, 327);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 25);
            this.btnCancelar.TabIndex = 283;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(267, 327);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 25);
            this.btnAceptar.TabIndex = 282;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblLetras
            // 
            this.lblLetras.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblLetras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLetras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.ForeColor = System.Drawing.Color.White;
            this.lblLetras.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLetras.Location = new System.Drawing.Point(25, 122);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(465, 19);
            this.lblLetras.TabIndex = 286;
            this.lblLetras.Text = "LETRAS PENDIENTES :";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 287;
            this.label3.Text = "Correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(114, 66);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.ReadOnly = true;
            this.txtCorreo.Size = new System.Drawing.Size(376, 22);
            this.txtCorreo.TabIndex = 288;
            // 
            // wPagosLetras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(518, 366);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblLetras);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.DgvOrdCom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodAux);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomAux);
            this.Controls.Add(this.txtNomDir);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wPagosLetras";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos de letras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wPagosLetras_FormClosing);
            this.Controls.SetChildIndex(this.txtNomDir, 0);
            this.Controls.SetChildIndex(this.txtNomAux, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCodAux, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.DgvOrdCom, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblLetras, 0);
            this.Controls.SetChildIndex(this.txtCorreo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrdCom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.TextBox txtCodAux;
        internal System.Windows.Forms.TextBox txtNomAux;
        internal System.Windows.Forms.TextBox txtNomDir;
        internal System.Windows.Forms.Label lblLetras;
        public System.Windows.Forms.DataGridView DgvOrdCom;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtCorreo;
    }
}