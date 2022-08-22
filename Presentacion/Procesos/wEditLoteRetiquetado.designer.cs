namespace Presentacion.Procesos
{
    partial class wEditLoteRetiquetado
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtClaLib = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCanUni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPreUni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCorProCab = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodEnc = new System.Windows.Forms.TextBox();
            this.txtFecVen = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecProDet = new System.Windows.Forms.TextBox();
            this.txtFecLot = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(252, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 25);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "Liberacion";
            // 
            // txtClaLib
            // 
            this.txtClaLib.Location = new System.Drawing.Point(142, 53);
            this.txtClaLib.MaxLength = 15;
            this.txtClaLib.Name = "txtClaLib";
            this.txtClaLib.Size = new System.Drawing.Size(152, 22);
            this.txtClaLib.TabIndex = 43;
            this.txtClaLib.DoubleClick += new System.EventHandler(this.txtCodExi_DoubleClick);
            this.txtClaLib.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExi_KeyDown);
            this.txtClaLib.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExi_Validating);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(142, 252);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 25);
            this.btnAceptar.TabIndex = 48;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCanUni
            // 
            this.txtCanUni.Location = new System.Drawing.Point(142, 221);
            this.txtCanUni.MaxLength = 7;
            this.txtCanUni.Name = "txtCanUni";
            this.txtCanUni.Size = new System.Drawing.Size(102, 22);
            this.txtCanUni.TabIndex = 52;
            this.txtCanUni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanUni.Validated += new System.EventHandler(this.txtCanUniProTer_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 223);
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
            this.label21.Size = new System.Drawing.Size(324, 14);
            this.label21.TabIndex = 357;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPreUni
            // 
            this.txtPreUni.Location = new System.Drawing.Point(142, 193);
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
            this.label3.Location = new System.Drawing.Point(31, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 14);
            this.label3.TabIndex = 415;
            this.label3.Text = "Precio.Unit";
            // 
            // txtCorProCab
            // 
            this.txtCorProCab.Location = new System.Drawing.Point(142, 81);
            this.txtCorProCab.MaxLength = 7;
            this.txtCorProCab.Name = "txtCorProCab";
            this.txtCorProCab.ReadOnly = true;
            this.txtCorProCab.Size = new System.Drawing.Size(102, 22);
            this.txtCorProCab.TabIndex = 420;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 14);
            this.label5.TabIndex = 419;
            this.label5.Text = "Produccion";
            // 
            // txtCodEnc
            // 
            this.txtCodEnc.Location = new System.Drawing.Point(245, 193);
            this.txtCodEnc.Name = "txtCodEnc";
            this.txtCodEnc.ReadOnly = true;
            this.txtCodEnc.Size = new System.Drawing.Size(10, 22);
            this.txtCodEnc.TabIndex = 421;
            this.txtCodEnc.Visible = false;
            // 
            // txtFecVen
            // 
            this.txtFecVen.Location = new System.Drawing.Point(142, 165);
            this.txtFecVen.MaxLength = 7;
            this.txtFecVen.Name = "txtFecVen";
            this.txtFecVen.ReadOnly = true;
            this.txtFecVen.Size = new System.Drawing.Size(102, 22);
            this.txtFecVen.TabIndex = 432;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 14);
            this.label7.TabIndex = 431;
            this.label7.Text = "Fc. Vencimiento";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(32, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 14);
            this.label19.TabIndex = 430;
            this.label19.Text = "Fc. Lote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 434;
            this.label1.Text = "Fc. Produccion";
            // 
            // txtFecProDet
            // 
            this.txtFecProDet.Location = new System.Drawing.Point(142, 109);
            this.txtFecProDet.MaxLength = 7;
            this.txtFecProDet.Name = "txtFecProDet";
            this.txtFecProDet.ReadOnly = true;
            this.txtFecProDet.Size = new System.Drawing.Size(102, 22);
            this.txtFecProDet.TabIndex = 435;
            // 
            // txtFecLot
            // 
            this.txtFecLot.Location = new System.Drawing.Point(142, 137);
            this.txtFecLot.MaxLength = 7;
            this.txtFecLot.Name = "txtFecLot";
            this.txtFecLot.ReadOnly = true;
            this.txtFecLot.Size = new System.Drawing.Size(102, 22);
            this.txtFecLot.TabIndex = 436;
            // 
            // wEditLoteRetiquetado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(394, 304);
            this.ControlBox = false;
            this.Controls.Add(this.txtFecLot);
            this.Controls.Add(this.txtFecProDet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFecVen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtCodEnc);
            this.Controls.Add(this.txtCorProCab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPreUni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCanUni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtClaLib);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wEditLoteRetiquetado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditLoteRetiquetado_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtClaLib, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCanUni, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtPreUni, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtCorProCab, 0);
            this.Controls.SetChildIndex(this.txtCodEnc, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtFecVen, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtFecProDet, 0);
            this.Controls.SetChildIndex(this.txtFecLot, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtClaLib;
        internal System.Windows.Forms.TextBox txtCanUni;
        internal System.Windows.Forms.TextBox txtPreUni;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtCorProCab;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtCodEnc;
        internal System.Windows.Forms.TextBox txtFecVen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtFecProDet;
        internal System.Windows.Forms.TextBox txtFecLot;
    }
}