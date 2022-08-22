namespace Presentacion.Procesos
{
    partial class wDetalleSalida
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
            this.txtCosMovDet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDesExi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodExi = new System.Windows.Forms.TextBox();
            this.txtGloMovDet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtPreUniMovDet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantMovDet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNUniMed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCUniMed = new System.Windows.Forms.TextBox();
            this.txtCodAre = new System.Windows.Forms.TextBox();
            this.txtDesAre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStoAntExi = new System.Windows.Forms.TextBox();
            this.txtPreAntExi = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCodTip = new System.Windows.Forms.TextBox();
            this.txtCEsLot = new System.Windows.Forms.TextBox();
            this.txtCodPar = new System.Windows.Forms.TextBox();
            this.txtDesPar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCosMovDet
            // 
            this.txtCosMovDet.Location = new System.Drawing.Point(207, 215);
            this.txtCosMovDet.Margin = new System.Windows.Forms.Padding(4);
            this.txtCosMovDet.MaxLength = 8;
            this.txtCosMovDet.Name = "txtCosMovDet";
            this.txtCosMovDet.ReadOnly = true;
            this.txtCosMovDet.Size = new System.Drawing.Size(135, 26);
            this.txtCosMovDet.TabIndex = 3;
            this.txtCosMovDet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Costo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(509, 409);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(139, 32);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(344, 71);
            this.txtDesExi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(303, 26);
            this.txtDesExi.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 41;
            this.label2.Text = "Existencia";
            // 
            // txtCodExi
            // 
            this.txtCodExi.Location = new System.Drawing.Point(207, 71);
            this.txtCodExi.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodExi.MaxLength = 15;
            this.txtCodExi.Name = "txtCodExi";
            this.txtCodExi.Size = new System.Drawing.Size(135, 26);
            this.txtCodExi.TabIndex = 43;
            this.txtCodExi.DoubleClick += new System.EventHandler(this.txtCodExi_DoubleClick);
            this.txtCodExi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExi_KeyDown);
            this.txtCodExi.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExi_Validating);
            // 
            // txtGloMovDet
            // 
            this.txtGloMovDet.Location = new System.Drawing.Point(207, 323);
            this.txtGloMovDet.Margin = new System.Windows.Forms.Padding(4);
            this.txtGloMovDet.MaxLength = 250;
            this.txtGloMovDet.Multiline = true;
            this.txtGloMovDet.Name = "txtGloMovDet";
            this.txtGloMovDet.Size = new System.Drawing.Size(440, 70);
            this.txtGloMovDet.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 18);
            this.label4.TabIndex = 46;
            this.label4.Text = "Glosa";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(363, 409);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 32);
            this.btnAceptar.TabIndex = 48;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtPreUniMovDet
            // 
            this.txtPreUniMovDet.Location = new System.Drawing.Point(207, 143);
            this.txtPreUniMovDet.Margin = new System.Windows.Forms.Padding(4);
            this.txtPreUniMovDet.MaxLength = 10;
            this.txtPreUniMovDet.Name = "txtPreUniMovDet";
            this.txtPreUniMovDet.Size = new System.Drawing.Size(135, 26);
            this.txtPreUniMovDet.TabIndex = 49;
            this.txtPreUniMovDet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPreUniMovDet.Validated += new System.EventHandler(this.txtPreUni_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.TabIndex = 50;
            this.label5.Text = "Precio.Unitario";
            // 
            // txtCantMovDet
            // 
            this.txtCantMovDet.Location = new System.Drawing.Point(207, 179);
            this.txtCantMovDet.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantMovDet.MaxLength = 7;
            this.txtCantMovDet.Name = "txtCantMovDet";
            this.txtCantMovDet.Size = new System.Drawing.Size(135, 26);
            this.txtCantMovDet.TabIndex = 52;
            this.txtCantMovDet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantMovDet.Validated += new System.EventHandler(this.txtCant_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 51;
            this.label6.Text = "Cantidad";
            // 
            // txtNUniMed
            // 
            this.txtNUniMed.Location = new System.Drawing.Point(207, 107);
            this.txtNUniMed.Margin = new System.Windows.Forms.Padding(4);
            this.txtNUniMed.Name = "txtNUniMed";
            this.txtNUniMed.ReadOnly = true;
            this.txtNUniMed.Size = new System.Drawing.Size(135, 26);
            this.txtNUniMed.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 18);
            this.label9.TabIndex = 63;
            this.label9.Text = "Unidad Medida";
            // 
            // txtCUniMed
            // 
            this.txtCUniMed.Location = new System.Drawing.Point(344, 107);
            this.txtCUniMed.Margin = new System.Windows.Forms.Padding(4);
            this.txtCUniMed.Name = "txtCUniMed";
            this.txtCUniMed.ReadOnly = true;
            this.txtCUniMed.Size = new System.Drawing.Size(12, 26);
            this.txtCUniMed.TabIndex = 65;
            this.txtCUniMed.Visible = false;
            // 
            // txtCodAre
            // 
            this.txtCodAre.Location = new System.Drawing.Point(207, 251);
            this.txtCodAre.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodAre.MaxLength = 15;
            this.txtCodAre.Name = "txtCodAre";
            this.txtCodAre.Size = new System.Drawing.Size(85, 26);
            this.txtCodAre.TabIndex = 68;
            this.txtCodAre.DoubleClick += new System.EventHandler(this.txtCodAre_DoubleClick);
            this.txtCodAre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAre_KeyDown);
            this.txtCodAre.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAre_Validating);
            // 
            // txtDesAre
            // 
            this.txtDesAre.Location = new System.Drawing.Point(295, 251);
            this.txtDesAre.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesAre.Name = "txtDesAre";
            this.txtDesAre.ReadOnly = true;
            this.txtDesAre.Size = new System.Drawing.Size(352, 26);
            this.txtDesAre.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 255);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 66;
            this.label3.Text = "Area";
            // 
            // txtStoAntExi
            // 
            this.txtStoAntExi.Location = new System.Drawing.Point(359, 107);
            this.txtStoAntExi.Margin = new System.Windows.Forms.Padding(4);
            this.txtStoAntExi.Name = "txtStoAntExi";
            this.txtStoAntExi.ReadOnly = true;
            this.txtStoAntExi.Size = new System.Drawing.Size(12, 26);
            this.txtStoAntExi.TabIndex = 69;
            this.txtStoAntExi.Visible = false;
            // 
            // txtPreAntExi
            // 
            this.txtPreAntExi.Location = new System.Drawing.Point(373, 107);
            this.txtPreAntExi.Margin = new System.Windows.Forms.Padding(4);
            this.txtPreAntExi.Name = "txtPreAntExi";
            this.txtPreAntExi.ReadOnly = true;
            this.txtPreAntExi.Size = new System.Drawing.Size(12, 26);
            this.txtPreAntExi.TabIndex = 70;
            this.txtPreAntExi.Visible = false;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(43, 41);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(605, 18);
            this.label21.TabIndex = 358;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCodTip
            // 
            this.txtCodTip.Location = new System.Drawing.Point(388, 107);
            this.txtCodTip.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodTip.Name = "txtCodTip";
            this.txtCodTip.ReadOnly = true;
            this.txtCodTip.Size = new System.Drawing.Size(12, 26);
            this.txtCodTip.TabIndex = 360;
            this.txtCodTip.Visible = false;
            // 
            // txtCEsLot
            // 
            this.txtCEsLot.Location = new System.Drawing.Point(403, 107);
            this.txtCEsLot.Margin = new System.Windows.Forms.Padding(4);
            this.txtCEsLot.Name = "txtCEsLot";
            this.txtCEsLot.ReadOnly = true;
            this.txtCEsLot.Size = new System.Drawing.Size(12, 26);
            this.txtCEsLot.TabIndex = 361;
            this.txtCEsLot.Visible = false;
            // 
            // txtCodPar
            // 
            this.txtCodPar.Location = new System.Drawing.Point(207, 287);
            this.txtCodPar.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodPar.MaxLength = 15;
            this.txtCodPar.Name = "txtCodPar";
            this.txtCodPar.Size = new System.Drawing.Size(85, 26);
            this.txtCodPar.TabIndex = 364;
            this.txtCodPar.DoubleClick += new System.EventHandler(this.txtCodPar_DoubleClick);
            this.txtCodPar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodPar_KeyDown);
            this.txtCodPar.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodPar_Validating);
            // 
            // txtDesPar
            // 
            this.txtDesPar.Location = new System.Drawing.Point(295, 287);
            this.txtDesPar.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesPar.Name = "txtDesPar";
            this.txtDesPar.ReadOnly = true;
            this.txtDesPar.Size = new System.Drawing.Size(352, 26);
            this.txtDesPar.TabIndex = 363;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 290);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 18);
            this.label7.TabIndex = 362;
            this.label7.Text = "Partida";
            // 
            // wDetalleSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(737, 520);
            this.ControlBox = false;
            this.Controls.Add(this.txtCodPar);
            this.Controls.Add(this.txtDesPar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCEsLot);
            this.Controls.Add(this.txtCodTip);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtPreAntExi);
            this.Controls.Add(this.txtStoAntExi);
            this.Controls.Add(this.txtCodAre);
            this.Controls.Add(this.txtDesAre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCUniMed);
            this.Controls.Add(this.txtNUniMed);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCantMovDet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPreUniMovDet);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtGloMovDet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodExi);
            this.Controls.Add(this.txtDesExi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtCosMovDet);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wDetalleSalida";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wDetalleSalida_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCosMovDet, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDesExi, 0);
            this.Controls.SetChildIndex(this.txtCodExi, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtGloMovDet, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.txtPreUniMovDet, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCantMovDet, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtNUniMed, 0);
            this.Controls.SetChildIndex(this.txtCUniMed, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDesAre, 0);
            this.Controls.SetChildIndex(this.txtCodAre, 0);
            this.Controls.SetChildIndex(this.txtStoAntExi, 0);
            this.Controls.SetChildIndex(this.txtPreAntExi, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.txtCodTip, 0);
            this.Controls.SetChildIndex(this.txtCEsLot, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtDesPar, 0);
            this.Controls.SetChildIndex(this.txtCodPar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCosMovDet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtDesExi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodExi;
        private System.Windows.Forms.TextBox txtGloMovDet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtPreUniMovDet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantMovDet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNUniMed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCUniMed;
        private System.Windows.Forms.TextBox txtCodAre;
        private System.Windows.Forms.TextBox txtDesAre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStoAntExi;
        private System.Windows.Forms.TextBox txtPreAntExi;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCodTip;
        private System.Windows.Forms.TextBox txtCEsLot;
        private System.Windows.Forms.TextBox txtCodPar;
        private System.Windows.Forms.TextBox txtDesPar;
        private System.Windows.Forms.Label label7;
    }
}