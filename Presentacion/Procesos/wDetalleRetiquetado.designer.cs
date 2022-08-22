namespace Presentacion.Procesos
{
    partial class wDetalleRetiquetado
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
            this.txtClaProProTer = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCanUniProTer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPreUni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCorRetProTer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodEnc = new System.Windows.Forms.TextBox();
            this.btnProducciones = new System.Windows.Forms.Button();
            this.txtDetCanSemPro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(368, 176);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 25);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(245, 81);
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(228, 22);
            this.txtDesExi.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "Encajado";
            // 
            // txtClaProProTer
            // 
            this.txtClaProProTer.Location = new System.Drawing.Point(142, 81);
            this.txtClaProProTer.MaxLength = 15;
            this.txtClaProProTer.Name = "txtClaProProTer";
            this.txtClaProProTer.Size = new System.Drawing.Size(102, 22);
            this.txtClaProProTer.TabIndex = 43;
            this.txtClaProProTer.DoubleClick += new System.EventHandler(this.txtCodExi_DoubleClick);
            this.txtClaProProTer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExi_KeyDown);
            this.txtClaProProTer.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExi_Validating);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(258, 176);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 25);
            this.btnAceptar.TabIndex = 48;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCanUniProTer
            // 
            this.txtCanUniProTer.Location = new System.Drawing.Point(142, 137);
            this.txtCanUniProTer.MaxLength = 7;
            this.txtCanUniProTer.Name = "txtCanUniProTer";
            this.txtCanUniProTer.ReadOnly = true;
            this.txtCanUniProTer.Size = new System.Drawing.Size(102, 22);
            this.txtCanUniProTer.TabIndex = 52;
            this.txtCanUniProTer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanUniProTer.Validated += new System.EventHandler(this.txtCanUniProTer_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 51;
            this.label6.Text = "Cantidad Uni";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(32, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(441, 14);
            this.label21.TabIndex = 357;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPreUni
            // 
            this.txtPreUni.Location = new System.Drawing.Point(142, 109);
            this.txtPreUni.MaxLength = 7;
            this.txtPreUni.Name = "txtPreUni";
            this.txtPreUni.ReadOnly = true;
            this.txtPreUni.Size = new System.Drawing.Size(102, 22);
            this.txtPreUni.TabIndex = 416;
            this.txtPreUni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 14);
            this.label3.TabIndex = 415;
            this.label3.Text = "Precio.Unit";
            // 
            // txtCorRetProTer
            // 
            this.txtCorRetProTer.Location = new System.Drawing.Point(142, 53);
            this.txtCorRetProTer.MaxLength = 7;
            this.txtCorRetProTer.Name = "txtCorRetProTer";
            this.txtCorRetProTer.ReadOnly = true;
            this.txtCorRetProTer.Size = new System.Drawing.Size(45, 22);
            this.txtCorRetProTer.TabIndex = 420;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 14);
            this.label5.TabIndex = 419;
            this.label5.Text = "Correlativo";
            // 
            // txtCodEnc
            // 
            this.txtCodEnc.Location = new System.Drawing.Point(245, 109);
            this.txtCodEnc.Name = "txtCodEnc";
            this.txtCodEnc.ReadOnly = true;
            this.txtCodEnc.Size = new System.Drawing.Size(10, 22);
            this.txtCodEnc.TabIndex = 421;
            this.txtCodEnc.Visible = false;
            // 
            // btnProducciones
            // 
            this.btnProducciones.Location = new System.Drawing.Point(245, 135);
            this.btnProducciones.Name = "btnProducciones";
            this.btnProducciones.Size = new System.Drawing.Size(104, 25);
            this.btnProducciones.TabIndex = 428;
            this.btnProducciones.Text = "Lotes Encajado";
            this.btnProducciones.UseVisualStyleBackColor = true;
            this.btnProducciones.Click += new System.EventHandler(this.btnProducciones_Click);
            // 
            // txtDetCanSemPro
            // 
            this.txtDetCanSemPro.Location = new System.Drawing.Point(256, 109);
            this.txtDetCanSemPro.Name = "txtDetCanSemPro";
            this.txtDetCanSemPro.ReadOnly = true;
            this.txtDetCanSemPro.Size = new System.Drawing.Size(10, 22);
            this.txtDetCanSemPro.TabIndex = 429;
            this.txtDetCanSemPro.Visible = false;
            // 
            // wDetalleRetiquetado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(502, 227);
            this.ControlBox = false;
            this.Controls.Add(this.txtDetCanSemPro);
            this.Controls.Add(this.btnProducciones);
            this.Controls.Add(this.txtCodEnc);
            this.Controls.Add(this.txtCorRetProTer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPreUni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCanUniProTer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtClaProProTer);
            this.Controls.Add(this.txtDesExi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wDetalleRetiquetado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wDetalleRetiquetado_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDesExi, 0);
            this.Controls.SetChildIndex(this.txtClaProProTer, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCanUniProTer, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPreUni, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtCorRetProTer, 0);
            this.Controls.SetChildIndex(this.txtCodEnc, 0);
            this.Controls.SetChildIndex(this.btnProducciones, 0);
            this.Controls.SetChildIndex(this.txtDetCanSemPro, 0);
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
        internal System.Windows.Forms.TextBox txtClaProProTer;
        internal System.Windows.Forms.TextBox txtCanUniProTer;
        internal System.Windows.Forms.TextBox txtPreUni;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtCorRetProTer;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtCodEnc;
        private System.Windows.Forms.Button btnProducciones;
        internal System.Windows.Forms.TextBox txtDetCanSemPro;
    }
}