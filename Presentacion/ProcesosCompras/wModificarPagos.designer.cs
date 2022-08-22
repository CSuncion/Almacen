namespace Presentacion.ProcesosCompras
{
    partial class wModificarPagos
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
            this.txtCorCob = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtNomBan = new System.Windows.Forms.TextBox();
            this.txtCodBan = new System.Windows.Forms.TextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.txtMonCue = new System.Windows.Forms.TextBox();
            this.txtClaCtaBco = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCorCob
            // 
            this.txtCorCob.Location = new System.Drawing.Point(130, 36);
            this.txtCorCob.MaxLength = 150;
            this.txtCorCob.Name = "txtCorCob";
            this.txtCorCob.ReadOnly = true;
            this.txtCorCob.Size = new System.Drawing.Size(124, 20);
            this.txtCorCob.TabIndex = 243;
            this.txtCorCob.TabStop = false;
            this.txtCorCob.Tag = "100";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label12.Location = new System.Drawing.Point(27, 39);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(52, 13);
            this.Label12.TabIndex = 244;
            this.Label12.Text = "Cobranza";
            // 
            // txtNomBan
            // 
            this.txtNomBan.Location = new System.Drawing.Point(130, 117);
            this.txtNomBan.MaxLength = 150;
            this.txtNomBan.Name = "txtNomBan";
            this.txtNomBan.ReadOnly = true;
            this.txtNomBan.Size = new System.Drawing.Size(124, 20);
            this.txtNomBan.TabIndex = 294;
            this.txtNomBan.TabStop = false;
            this.txtNomBan.Tag = "100";
            // 
            // txtCodBan
            // 
            this.txtCodBan.Location = new System.Drawing.Point(129, 91);
            this.txtCodBan.MaxLength = 150;
            this.txtCodBan.Name = "txtCodBan";
            this.txtCodBan.Size = new System.Drawing.Size(125, 20);
            this.txtCodBan.TabIndex = 281;
            this.txtCodBan.Tag = "15";
            this.txtCodBan.DoubleClick += new System.EventHandler(this.txtCodBan_DoubleClick);
            this.txtCodBan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodBan_KeyDown);
            this.txtCodBan.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodBan_Validating);
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label24.Location = new System.Drawing.Point(27, 94);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(41, 13);
            this.Label24.TabIndex = 293;
            this.Label24.Text = "Cuenta";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(260, 218);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 23);
            this.btnCancelar.TabIndex = 283;
            this.btnCancelar.Tag = "17";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAceptar.Location = new System.Drawing.Point(129, 218);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(125, 23);
            this.btnAceptar.TabIndex = 282;
            this.btnAceptar.Tag = "16";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtObs
            // 
            this.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObs.Location = new System.Drawing.Point(129, 169);
            this.txtObs.MaxLength = 60;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(248, 43);
            this.txtObs.TabIndex = 280;
            this.txtObs.Tag = "14";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.Black;
            this.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label21.Location = new System.Drawing.Point(27, 172);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(67, 13);
            this.Label21.TabIndex = 290;
            this.Label21.Text = "Observacion";
            // 
            // txtMonCue
            // 
            this.txtMonCue.Location = new System.Drawing.Point(130, 143);
            this.txtMonCue.MaxLength = 150;
            this.txtMonCue.Name = "txtMonCue";
            this.txtMonCue.ReadOnly = true;
            this.txtMonCue.Size = new System.Drawing.Size(124, 20);
            this.txtMonCue.TabIndex = 311;
            this.txtMonCue.TabStop = false;
            this.txtMonCue.Tag = "100";
            // 
            // txtClaCtaBco
            // 
            this.txtClaCtaBco.Location = new System.Drawing.Point(255, 91);
            this.txtClaCtaBco.MaxLength = 150;
            this.txtClaCtaBco.Name = "txtClaCtaBco";
            this.txtClaCtaBco.Size = new System.Drawing.Size(11, 20);
            this.txtClaCtaBco.TabIndex = 312;
            this.txtClaCtaBco.Tag = "15";
            this.txtClaCtaBco.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(27, 146);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 13);
            this.label30.TabIndex = 371;
            this.label30.Text = "Moneda Cta";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(27, 120);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(38, 13);
            this.label31.TabIndex = 372;
            this.label31.Text = "Banco";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkGray;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(27, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(353, 18);
            this.label13.TabIndex = 373;
            this.label13.Text = "Datos Generales";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wModificarPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(410, 268);
            this.ControlBox = false;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtClaCtaBco);
            this.Controls.Add(this.txtMonCue);
            this.Controls.Add(this.txtNomBan);
            this.Controls.Add(this.txtCodBan);
            this.Controls.Add(this.Label24);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.txtCorCob);
            this.Controls.Add(this.Label12);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wModificarPagos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Datos Cobranza";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wModificarPagos_FormClosing);
            this.Controls.SetChildIndex(this.Label12, 0);
            this.Controls.SetChildIndex(this.txtCorCob, 0);
            this.Controls.SetChildIndex(this.Label21, 0);
            this.Controls.SetChildIndex(this.txtObs, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.Label24, 0);
            this.Controls.SetChildIndex(this.txtCodBan, 0);
            this.Controls.SetChildIndex(this.txtNomBan, 0);
            this.Controls.SetChildIndex(this.txtMonCue, 0);
            this.Controls.SetChildIndex(this.txtClaCtaBco, 0);
            this.Controls.SetChildIndex(this.label30, 0);
            this.Controls.SetChildIndex(this.label31, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtCorCob;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txtNomBan;
        internal System.Windows.Forms.TextBox txtCodBan;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.TextBox txtObs;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.TextBox txtMonCue;
        internal System.Windows.Forms.TextBox txtClaCtaBco;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label13;
    }
}