namespace Presentacion.Procesos
{
    partial class wDetalleEncajado
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
            if ( disposing && (components != null) )
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDesExi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodExi = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCanUniProTer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.txtUniXEmp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumCaj = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPriEnc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObsProTer = new System.Windows.Forms.TextBox();
            this.btnProducciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(492, 341);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(139, 32);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(327, 140);
            this.txtDesExi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(303, 26);
            this.txtDesExi.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 41;
            this.label2.Text = "Existencia P.T";
            // 
            // txtCodExi
            // 
            this.txtCodExi.Location = new System.Drawing.Point(189, 140);
            this.txtCodExi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodExi.MaxLength = 15;
            this.txtCodExi.Name = "txtCodExi";
            this.txtCodExi.Size = new System.Drawing.Size(135, 26);
            this.txtCodExi.TabIndex = 43;
            this.txtCodExi.DoubleClick += new System.EventHandler(this.txtCodExi_DoubleClick);
            this.txtCodExi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExi_KeyDown);
            this.txtCodExi.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExi_Validating);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(345, 341);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 32);
            this.btnAceptar.TabIndex = 48;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCanUniProTer
            // 
            this.txtCanUniProTer.Location = new System.Drawing.Point(189, 212);
            this.txtCanUniProTer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCanUniProTer.MaxLength = 7;
            this.txtCanUniProTer.Name = "txtCanUniProTer";
            this.txtCanUniProTer.ReadOnly = true;
            this.txtCanUniProTer.Size = new System.Drawing.Size(135, 26);
            this.txtCanUniProTer.TabIndex = 52;
            this.txtCanUniProTer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanUniProTer.Validated += new System.EventHandler(this.txtCanUniProTer_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 216);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 51;
            this.label6.Text = "Cantidad Uni";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(43, 41);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(588, 18);
            this.label21.TabIndex = 357;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 414;
            this.label1.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(189, 104);
            this.txtCodAlm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(36, 26);
            this.txtCodAlm.TabIndex = 412;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(228, 104);
            this.txtDesAlm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(284, 26);
            this.txtDesAlm.TabIndex = 413;
            // 
            // txtUniXEmp
            // 
            this.txtUniXEmp.Location = new System.Drawing.Point(189, 176);
            this.txtUniXEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUniXEmp.MaxLength = 7;
            this.txtUniXEmp.Name = "txtUniXEmp";
            this.txtUniXEmp.ReadOnly = true;
            this.txtUniXEmp.Size = new System.Drawing.Size(135, 26);
            this.txtUniXEmp.TabIndex = 416;
            this.txtUniXEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 415;
            this.label3.Text = "Uni x Empaque";
            // 
            // txtNumCaj
            // 
            this.txtNumCaj.Location = new System.Drawing.Point(189, 248);
            this.txtNumCaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumCaj.MaxLength = 7;
            this.txtNumCaj.Name = "txtNumCaj";
            this.txtNumCaj.ReadOnly = true;
            this.txtNumCaj.Size = new System.Drawing.Size(135, 26);
            this.txtNumCaj.TabIndex = 418;
            this.txtNumCaj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 252);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 417;
            this.label4.Text = "Cantidad Cajas";
            // 
            // txtPriEnc
            // 
            this.txtPriEnc.Location = new System.Drawing.Point(189, 68);
            this.txtPriEnc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPriEnc.MaxLength = 7;
            this.txtPriEnc.Name = "txtPriEnc";
            this.txtPriEnc.ReadOnly = true;
            this.txtPriEnc.Size = new System.Drawing.Size(59, 26);
            this.txtPriEnc.TabIndex = 420;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 419;
            this.label5.Text = "Prioridad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 288);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 18);
            this.label8.TabIndex = 426;
            this.label8.Text = "Observacion";
            // 
            // txtObsProTer
            // 
            this.txtObsProTer.Location = new System.Drawing.Point(189, 284);
            this.txtObsProTer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObsProTer.Multiline = true;
            this.txtObsProTer.Name = "txtObsProTer";
            this.txtObsProTer.Size = new System.Drawing.Size(440, 43);
            this.txtObsProTer.TabIndex = 425;
            // 
            // btnProducciones
            // 
            this.btnProducciones.Location = new System.Drawing.Point(327, 210);
            this.btnProducciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProducciones.Name = "btnProducciones";
            this.btnProducciones.Size = new System.Drawing.Size(139, 32);
            this.btnProducciones.TabIndex = 427;
            this.btnProducciones.Text = "Aprobadas";
            this.btnProducciones.UseVisualStyleBackColor = true;
            this.btnProducciones.Click += new System.EventHandler(this.btnProducciones_Click);
            // 
            // wDetalleEncajado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(669, 410);
            this.ControlBox = false;
            this.Controls.Add(this.btnProducciones);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtObsProTer);
            this.Controls.Add(this.txtPriEnc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumCaj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUniXEmp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodAlm);
            this.Controls.Add(this.txtDesAlm);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCanUniProTer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCodExi);
            this.Controls.Add(this.txtDesExi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wDetalleEncajado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wDetalleEncajado_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDesExi, 0);
            this.Controls.SetChildIndex(this.txtCodExi, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCanUniProTer, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.txtDesAlm, 0);
            this.Controls.SetChildIndex(this.txtCodAlm, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtUniXEmp, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtNumCaj, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPriEnc, 0);
            this.Controls.SetChildIndex(this.txtObsProTer, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btnProducciones, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtDesExi;
        internal System.Windows.Forms.TextBox txtCodExi;
        internal System.Windows.Forms.TextBox txtCanUniProTer;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCodAlm;
        internal System.Windows.Forms.TextBox txtDesAlm;
        internal System.Windows.Forms.TextBox txtUniXEmp;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtNumCaj;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtPriEnc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtObsProTer;
        private System.Windows.Forms.Button btnProducciones;
    }
}