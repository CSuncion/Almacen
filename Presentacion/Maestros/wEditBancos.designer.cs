namespace Presentacion.ModuloMaestros
{
    partial class wEditBancos
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
            this.txtNomBco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodBco = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCodSun = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEstBco = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomBco
            // 
            this.txtNomBco.Location = new System.Drawing.Point(126, 90);
            this.txtNomBco.MaxLength = 50;
            this.txtNomBco.Name = "txtNomBco";
            this.txtNomBco.Size = new System.Drawing.Size(204, 22);
            this.txtNomBco.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre";
            // 
            // txtCodBco
            // 
            this.txtCodBco.Location = new System.Drawing.Point(126, 62);
            this.txtCodBco.MaxLength = 3;
            this.txtCodBco.Name = "txtCodBco";
            this.txtCodBco.Size = new System.Drawing.Size(99, 22);
            this.txtCodBco.TabIndex = 14;
            this.txtCodBco.TextChanged += new System.EventHandler(this.txtCodBco_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Código";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(248, 179);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(143, 179);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 25);
            this.btnAceptar.TabIndex = 42;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCodSun
            // 
            this.txtCodSun.Location = new System.Drawing.Point(126, 118);
            this.txtCodSun.MaxLength = 8;
            this.txtCodSun.Name = "txtCodSun";
            this.txtCodSun.Size = new System.Drawing.Size(97, 22);
            this.txtCodSun.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 45;
            this.label4.Text = "Codigo Sunat";
            // 
            // cmbEstBco
            // 
            this.cmbEstBco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstBco.FormattingEnabled = true;
            this.cmbEstBco.Location = new System.Drawing.Point(126, 146);
            this.cmbEstBco.Name = "cmbEstBco";
            this.cmbEstBco.Size = new System.Drawing.Size(97, 22);
            this.cmbEstBco.TabIndex = 47;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 149);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 14);
            this.label16.TabIndex = 46;
            this.label16.Text = "Estado";
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DarkGray;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(27, 36);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(320, 17);
            this.label24.TabIndex = 344;
            this.label24.Text = "Datos Generales";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wEditBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(376, 227);
            this.ControlBox = false;
            this.Controls.Add(this.label24);
            this.Controls.Add(this.cmbEstBco);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodSun);
            this.Controls.Add(this.txtNomBco);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCodBco);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wEditBancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Banco";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditBancos_FormClosing);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCodBco, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNomBco, 0);
            this.Controls.SetChildIndex(this.txtCodSun, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.cmbEstBco, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomBco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodBco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCodSun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEstBco;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label24;
    }
}