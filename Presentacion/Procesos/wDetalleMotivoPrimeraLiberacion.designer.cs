namespace Presentacion.Procesos
{
    partial class wDetalleMotivoPrimeraLiberacion
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
            this.txtDesMotLib = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodMotLib = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCanMotLib = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(352, 113);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 25);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDesMotLib
            // 
            this.txtDesMotLib.Location = new System.Drawing.Point(186, 56);
            this.txtDesMotLib.Name = "txtDesMotLib";
            this.txtDesMotLib.ReadOnly = true;
            this.txtDesMotLib.Size = new System.Drawing.Size(270, 22);
            this.txtDesMotLib.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "Motivo";
            // 
            // txtCodMotLib
            // 
            this.txtCodMotLib.Location = new System.Drawing.Point(125, 56);
            this.txtCodMotLib.MaxLength = 15;
            this.txtCodMotLib.Name = "txtCodMotLib";
            this.txtCodMotLib.Size = new System.Drawing.Size(60, 22);
            this.txtCodMotLib.TabIndex = 43;
            this.txtCodMotLib.DoubleClick += new System.EventHandler(this.txtCodExi_DoubleClick);
            this.txtCodMotLib.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExi_KeyDown);
            this.txtCodMotLib.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExi_Validating);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(242, 113);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(104, 25);
            this.btnAceptar.TabIndex = 48;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCanMotLib
            // 
            this.txtCanMotLib.Location = new System.Drawing.Point(125, 84);
            this.txtCanMotLib.MaxLength = 7;
            this.txtCanMotLib.Name = "txtCanMotLib";
            this.txtCanMotLib.Size = new System.Drawing.Size(102, 22);
            this.txtCanMotLib.TabIndex = 52;
            this.txtCanMotLib.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanMotLib.Validated += new System.EventHandler(this.txtCanUniProTer_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 51;
            this.label6.Text = "Cantidad";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(32, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(424, 14);
            this.label21.TabIndex = 357;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wDetalleMotivoLiberacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(488, 164);
            this.ControlBox = false;
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCanMotLib);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCodMotLib);
            this.Controls.Add(this.txtDesMotLib);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wDetalleMotivoLiberacion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wDetalleMotivoLiberacion_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDesMotLib, 0);
            this.Controls.SetChildIndex(this.txtCodMotLib, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtCanMotLib, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtDesMotLib;
        internal System.Windows.Forms.TextBox txtCodMotLib;
        internal System.Windows.Forms.TextBox txtCanMotLib;
    }
}