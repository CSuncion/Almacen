namespace Presentacion.Sistema
{
    partial class wCopiarPermiso
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
            this.txtNomUsu = new System.Windows.Forms.TextBox();
            this.txtCodUsu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomUsuCop = new System.Windows.Forms.TextBox();
            this.txtCodUsuCop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(175, 53);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(257, 22);
            this.txtNomUsu.TabIndex = 5;
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.Location = new System.Drawing.Point(91, 53);
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.ReadOnly = true;
            this.txtCodUsu.Size = new System.Drawing.Size(83, 22);
            this.txtCodUsu.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            // 
            // txtNomUsuCop
            // 
            this.txtNomUsuCop.Location = new System.Drawing.Point(175, 105);
            this.txtNomUsuCop.Name = "txtNomUsuCop";
            this.txtNomUsuCop.ReadOnly = true;
            this.txtNomUsuCop.Size = new System.Drawing.Size(257, 22);
            this.txtNomUsuCop.TabIndex = 16;
            // 
            // txtCodUsuCop
            // 
            this.txtCodUsuCop.Location = new System.Drawing.Point(91, 105);
            this.txtCodUsuCop.Name = "txtCodUsuCop";
            this.txtCodUsuCop.Size = new System.Drawing.Size(83, 22);
            this.txtCodUsuCop.TabIndex = 15;
            this.txtCodUsuCop.DoubleClick += new System.EventHandler(this.txtCodUsuCop_DoubleClick);
            this.txtCodUsuCop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodUsuCop_KeyDown);
            this.txtCodUsuCop.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodUsuCop_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "Usuario";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(329, 139);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 25);
            this.btnCancelar.TabIndex = 142;
            this.btnCancelar.Tag = "8";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(216, 139);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 25);
            this.btnAceptar.TabIndex = 141;
            this.btnAceptar.Tag = "7";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(26, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(406, 14);
            this.label21.TabIndex = 143;
            this.label21.Text = "Usuario que recibe la copia";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 14);
            this.label2.TabIndex = 144;
            this.label2.Text = "Usuario de donde se va a copiar los permisos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wCopiarPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(458, 192);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNomUsuCop);
            this.Controls.Add(this.txtCodUsuCop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomUsu);
            this.Controls.Add(this.txtCodUsu);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wCopiarPermiso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Permisos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wCopiarPermiso_FormClosing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCodUsu, 0);
            this.Controls.SetChildIndex(this.txtNomUsu, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtCodUsuCop, 0);
            this.Controls.SetChildIndex(this.txtNomUsuCop, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomUsu;
        private System.Windows.Forms.TextBox txtCodUsu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomUsuCop;
        private System.Windows.Forms.TextBox txtCodUsuCop;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label2;
    }
}