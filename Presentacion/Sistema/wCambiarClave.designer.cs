namespace Presentacion.Sistema
{
    partial class wCambiarClave
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
            this.txtClaAct = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtClaNue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtClaCon = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtClaAct
            // 
            this.txtClaAct.BackColor = System.Drawing.Color.White;
            this.txtClaAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaAct.Location = new System.Drawing.Point(129, 92);
            this.txtClaAct.MaxLength = 20;
            this.txtClaAct.Name = "txtClaAct";
            this.txtClaAct.PasswordChar = '*';
            this.txtClaAct.Size = new System.Drawing.Size(250, 20);
            this.txtClaAct.TabIndex = 206;
            this.txtClaAct.Tag = "Confirmar Nueva";
            this.txtClaAct.Validated += new System.EventHandler(this.txtClaAct_Validated);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(276, 270);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 25);
            this.btnCancelar.TabIndex = 205;
            this.btnCancelar.Tag = "8";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(167, 270);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(103, 25);
            this.btnAceptar.TabIndex = 204;
            this.btnAceptar.Tag = "7";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(140, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(194, 14);
            this.label11.TabIndex = 203;
            this.label11.Text = "(Minimo 6 y maximo 20 caracteres)";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(40, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(339, 30);
            this.label12.TabIndex = 202;
            this.label12.Text = "Advertencia :  Puede digitar solo letras y numeros, se diferencia entre mayuscula" +
    "s y minusculas\r\n";
            // 
            // txtClaNue
            // 
            this.txtClaNue.BackColor = System.Drawing.Color.White;
            this.txtClaNue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaNue.Location = new System.Drawing.Point(129, 192);
            this.txtClaNue.MaxLength = 20;
            this.txtClaNue.Name = "txtClaNue";
            this.txtClaNue.PasswordChar = '*';
            this.txtClaNue.Size = new System.Drawing.Size(250, 20);
            this.txtClaNue.TabIndex = 197;
            this.txtClaNue.Tag = "Clave Nueva";
            this.txtClaNue.Validated += new System.EventHandler(this.txtClaNue_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(16, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 14);
            this.label13.TabIndex = 199;
            this.label13.Text = "Digite clave actual";
            // 
            // txtClaCon
            // 
            this.txtClaCon.BackColor = System.Drawing.Color.White;
            this.txtClaCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaCon.Location = new System.Drawing.Point(129, 238);
            this.txtClaCon.MaxLength = 20;
            this.txtClaCon.Name = "txtClaCon";
            this.txtClaCon.PasswordChar = '*';
            this.txtClaCon.Size = new System.Drawing.Size(250, 20);
            this.txtClaCon.TabIndex = 198;
            this.txtClaCon.Tag = "Confirmar Nueva";
            this.txtClaCon.Validated += new System.EventHandler(this.txtClaCon_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(16, 241);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 14);
            this.label14.TabIndex = 201;
            this.label14.Text = "Confirmar clave :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(16, 195);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 14);
            this.label15.TabIndex = 200;
            this.label15.Text = "Nueva clave :";
            // 
            // txtUsu
            // 
            this.txtUsu.Location = new System.Drawing.Point(129, 59);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.ReadOnly = true;
            this.txtUsu.Size = new System.Drawing.Size(250, 22);
            this.txtUsu.TabIndex = 196;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 14);
            this.label16.TabIndex = 195;
            this.label16.Text = "Usuario:";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(19, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(360, 15);
            this.label21.TabIndex = 207;
            this.label21.Text = "Datos Anteriores";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.DarkGray;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(19, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(360, 15);
            this.label17.TabIndex = 208;
            this.label17.Text = "Datos Nuevos";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wCambiarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 319);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtClaAct);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtClaNue);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtClaCon);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtUsu);
            this.Controls.Add(this.label16);
            this.Name = "wCambiarClave";
            this.Text = "Cambio de Clave";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wCambiarClave_FormClosing);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtUsu, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtClaCon, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtClaNue, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtClaAct, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtClaAct;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtClaNue;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtClaCon;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
    }
}