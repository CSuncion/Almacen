namespace Presentacion.Principal
{
    partial class wAcceso
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
            this.ckbEmp = new System.Windows.Forms.CheckBox();
            this.txtNomEmp = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtCodEmp = new System.Windows.Forms.TextBox();
            this.ckbCla = new System.Windows.Forms.CheckBox();
            this.ckbUsu = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtCodUsu = new System.Windows.Forms.TextBox();
            this.txtNomUsu = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCla = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomPer = new System.Windows.Forms.TextBox();
            this.txtCodPer = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ckbEmp
            // 
            this.ckbEmp.AutoSize = true;
            this.ckbEmp.ForeColor = System.Drawing.Color.Black;
            this.ckbEmp.Location = new System.Drawing.Point(95, 320);
            this.ckbEmp.Name = "ckbEmp";
            this.ckbEmp.Size = new System.Drawing.Size(106, 17);
            this.ckbEmp.TabIndex = 194;
            this.ckbEmp.Text = "Persistir Empresa";
            this.ckbEmp.UseVisualStyleBackColor = true;
            // 
            // txtNomEmp
            // 
            this.txtNomEmp.Location = new System.Drawing.Point(129, 231);
            this.txtNomEmp.MaxLength = 100;
            this.txtNomEmp.Name = "txtNomEmp";
            this.txtNomEmp.ReadOnly = true;
            this.txtNomEmp.Size = new System.Drawing.Size(201, 20);
            this.txtNomEmp.TabIndex = 193;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(20, 234);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(48, 13);
            this.Label3.TabIndex = 192;
            this.Label3.Text = "Empresa";
            // 
            // txtCodEmp
            // 
            this.txtCodEmp.BackColor = System.Drawing.Color.White;
            this.txtCodEmp.Location = new System.Drawing.Point(95, 231);
            this.txtCodEmp.MaxLength = 100;
            this.txtCodEmp.Name = "txtCodEmp";
            this.txtCodEmp.Size = new System.Drawing.Size(33, 20);
            this.txtCodEmp.TabIndex = 191;
            this.txtCodEmp.Tag = "Empresa";
            this.txtCodEmp.DoubleClick += new System.EventHandler(this.txtCodEmp_DoubleClick);
            this.txtCodEmp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodEmp_KeyDown);
            this.txtCodEmp.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodEmp_Validating);
            // 
            // ckbCla
            // 
            this.ckbCla.AutoSize = true;
            this.ckbCla.ForeColor = System.Drawing.Color.Black;
            this.ckbCla.Location = new System.Drawing.Point(95, 303);
            this.ckbCla.Name = "ckbCla";
            this.ckbCla.Size = new System.Drawing.Size(119, 17);
            this.ckbCla.TabIndex = 189;
            this.ckbCla.Text = "Persistir Contraseña";
            this.ckbCla.UseVisualStyleBackColor = true;
            // 
            // ckbUsu
            // 
            this.ckbUsu.AutoSize = true;
            this.ckbUsu.ForeColor = System.Drawing.Color.Black;
            this.ckbUsu.Location = new System.Drawing.Point(95, 286);
            this.ckbUsu.Name = "ckbUsu";
            this.ckbUsu.Size = new System.Drawing.Size(101, 17);
            this.ckbUsu.TabIndex = 188;
            this.ckbUsu.Text = "Persistir Usuario";
            this.ckbUsu.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 187;
            this.label5.Text = "Nombre :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(20, 208);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 13);
            this.Label1.TabIndex = 186;
            this.Label1.Text = "Contraseña :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(20, 182);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(49, 13);
            this.Label2.TabIndex = 185;
            this.Label2.Text = "Usuario :";
            // 
            // txtCodUsu
            // 
            this.txtCodUsu.BackColor = System.Drawing.Color.White;
            this.txtCodUsu.Location = new System.Drawing.Point(95, 179);
            this.txtCodUsu.MaxLength = 100;
            this.txtCodUsu.Name = "txtCodUsu";
            this.txtCodUsu.Size = new System.Drawing.Size(236, 20);
            this.txtCodUsu.TabIndex = 180;
            this.txtCodUsu.Tag = "Usuario";
            this.txtCodUsu.DoubleClick += new System.EventHandler(this.txtCodUsu_DoubleClick);
            this.txtCodUsu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodUsu_KeyDown);
            this.txtCodUsu.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodUsu_Validating);
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(95, 127);
            this.txtNomUsu.MaxLength = 100;
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(236, 20);
            this.txtNomUsu.TabIndex = 184;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(215, 257);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 23);
            this.btnCancelar.TabIndex = 183;
            this.btnCancelar.Tag = "3";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCla
            // 
            this.txtCla.Location = new System.Drawing.Point(95, 205);
            this.txtCla.MaxLength = 20;
            this.txtCla.Name = "txtCla";
            this.txtCla.PasswordChar = '*';
            this.txtCla.Size = new System.Drawing.Size(235, 20);
            this.txtCla.TabIndex = 181;
            this.txtCla.Tag = "Contraseña";
            // 
            // btnIngresar
            // 
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.Location = new System.Drawing.Point(95, 257);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(115, 23);
            this.btnIngresar.TabIndex = 182;
            this.btnIngresar.Tag = "2";
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 196;
            this.label4.Text = "Perfil :";
            // 
            // txtNomPer
            // 
            this.txtNomPer.Location = new System.Drawing.Point(95, 153);
            this.txtNomPer.MaxLength = 100;
            this.txtNomPer.Name = "txtNomPer";
            this.txtNomPer.ReadOnly = true;
            this.txtNomPer.Size = new System.Drawing.Size(236, 20);
            this.txtNomPer.TabIndex = 195;
            // 
            // txtCodPer
            // 
            this.txtCodPer.Location = new System.Drawing.Point(333, 153);
            this.txtCodPer.MaxLength = 100;
            this.txtCodPer.Name = "txtCodPer";
            this.txtCodPer.ReadOnly = true;
            this.txtCodPer.Size = new System.Drawing.Size(10, 20);
            this.txtCodPer.TabIndex = 197;
            this.txtCodPer.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentacion.Properties.Resources.acceso6;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 198;
            this.pictureBox1.TabStop = false;
            // 
            // wAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(359, 351);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtCodPer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNomPer);
            this.Controls.Add(this.ckbEmp);
            this.Controls.Add(this.txtNomEmp);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtCodEmp);
            this.Controls.Add(this.ckbCla);
            this.Controls.Add(this.ckbUsu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtCodUsu);
            this.Controls.Add(this.txtNomUsu);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtCla);
            this.Controls.Add(this.btnIngresar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wAcceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso al sistema";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbEmp;
        internal System.Windows.Forms.TextBox txtNomEmp;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtCodEmp;
        private System.Windows.Forms.CheckBox ckbCla;
        private System.Windows.Forms.CheckBox ckbUsu;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtCodUsu;
        internal System.Windows.Forms.TextBox txtNomUsu;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.TextBox txtCla;
        internal System.Windows.Forms.Button btnIngresar;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtNomPer;
        internal System.Windows.Forms.TextBox txtCodPer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}