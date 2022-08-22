namespace Presentacion.Procesos
{
    partial class wEditInventario
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label11 = new System.Windows.Forms.Label();
            this.txtCorInvCab = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObsInvCab = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodPer = new System.Windows.Forms.TextBox();
            this.txtNomPer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpFecInvCab = new System.Windows.Forms.DateTimePicker();
            this.txtNEstProDet = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Correlativo";
            // 
            // txtCorInvCab
            // 
            this.txtCorInvCab.Location = new System.Drawing.Point(122, 57);
            this.txtCorInvCab.MaxLength = 2;
            this.txtCorInvCab.Name = "txtCorInvCab";
            this.txtCorInvCab.ReadOnly = true;
            this.txtCorInvCab.Size = new System.Drawing.Size(32, 22);
            this.txtCorInvCab.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 199);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 171);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 14);
            this.label15.TabIndex = 61;
            this.label15.Text = "Observacion";
            // 
            // txtObsInvCab
            // 
            this.txtObsInvCab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObsInvCab.Location = new System.Drawing.Point(122, 168);
            this.txtObsInvCab.MaxLength = 100;
            this.txtObsInvCab.Name = "txtObsInvCab";
            this.txtObsInvCab.Size = new System.Drawing.Size(307, 22);
            this.txtObsInvCab.TabIndex = 62;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(320, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(206, 234);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(23, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(406, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 417;
            this.label3.Text = "Personal";
            // 
            // txtCodPer
            // 
            this.txtCodPer.Location = new System.Drawing.Point(122, 140);
            this.txtCodPer.Name = "txtCodPer";
            this.txtCodPer.Size = new System.Drawing.Size(33, 22);
            this.txtCodPer.TabIndex = 415;
            this.txtCodPer.DoubleClick += new System.EventHandler(this.txtCodPer_DoubleClick);
            this.txtCodPer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodPer_KeyDown);
            this.txtCodPer.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodPer_Validating);
            // 
            // txtNomPer
            // 
            this.txtNomPer.Location = new System.Drawing.Point(156, 140);
            this.txtNomPer.Name = "txtNomPer";
            this.txtNomPer.ReadOnly = true;
            this.txtNomPer.Size = new System.Drawing.Size(273, 22);
            this.txtNomPer.TabIndex = 416;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 420;
            this.label2.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(122, 112);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(33, 22);
            this.txtCodAlm.TabIndex = 418;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(156, 112);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(273, 22);
            this.txtDesAlm.TabIndex = 419;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 87);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 14);
            this.label19.TabIndex = 422;
            this.label19.Text = "Fecha";
            // 
            // dtpFecInvCab
            // 
            this.dtpFecInvCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecInvCab.Location = new System.Drawing.Point(122, 84);
            this.dtpFecInvCab.Name = "dtpFecInvCab";
            this.dtpFecInvCab.Size = new System.Drawing.Size(99, 22);
            this.dtpFecInvCab.TabIndex = 421;
            // 
            // txtNEstProDet
            // 
            this.txtNEstProDet.Location = new System.Drawing.Point(122, 196);
            this.txtNEstProDet.Name = "txtNEstProDet";
            this.txtNEstProDet.ReadOnly = true;
            this.txtNEstProDet.Size = new System.Drawing.Size(102, 22);
            this.txtNEstProDet.TabIndex = 429;
            // 
            // wEditInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(453, 282);
            this.Controls.Add(this.txtNEstProDet);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dtpFecInvCab);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodAlm);
            this.Controls.Add(this.txtDesAlm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodPer);
            this.Controls.Add(this.txtNomPer);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtObsInvCab);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCorInvCab);
            this.Name = "wEditInventario";
            this.Text = "Edit Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditInventario_FormClosing);
            this.Controls.SetChildIndex(this.txtCorInvCab, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtObsInvCab, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.txtNomPer, 0);
            this.Controls.SetChildIndex(this.txtCodPer, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDesAlm, 0);
            this.Controls.SetChildIndex(this.txtCodAlm, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtpFecInvCab, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtNEstProDet, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCorInvCab;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObsInvCab;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodPer;
        private System.Windows.Forms.TextBox txtNomPer;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtCodAlm;
        internal System.Windows.Forms.TextBox txtDesAlm;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.DateTimePicker dtpFecInvCab;
        private System.Windows.Forms.TextBox txtNEstProDet;
    }
}
