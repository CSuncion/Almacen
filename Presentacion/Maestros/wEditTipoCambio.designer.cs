namespace Presentacion.Maestros
{
    partial class wEditTipoCambio
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
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstTipCam = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecTipCam = new System.Windows.Forms.DateTimePicker();
            this.txtTipCamCom = new System.Windows.Forms.TextBox();
            this.txtTipCamVta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 75);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 18);
            this.label11.TabIndex = 52;
            this.label11.Text = "Fecha:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 183);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 18);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstTipCam
            // 
            this.cmbEstTipCam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstTipCam.Location = new System.Drawing.Point(219, 180);
            this.cmbEstTipCam.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstTipCam.Name = "cmbEstTipCam";
            this.cmbEstTipCam.Size = new System.Drawing.Size(179, 26);
            this.cmbEstTipCam.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(31, 111);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 18);
            this.label15.TabIndex = 61;
            this.label15.Text = "Tipo Cambio Compra:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(426, 234);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(145, 32);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(274, 234);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 32);
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
            this.label21.Location = new System.Drawing.Point(31, 41);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(540, 18);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 75;
            this.label1.Text = "Tipo Cambio Venta:";
            // 
            // dtpFecTipCam
            // 
            this.dtpFecTipCam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecTipCam.Location = new System.Drawing.Point(219, 69);
            this.dtpFecTipCam.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecTipCam.Name = "dtpFecTipCam";
            this.dtpFecTipCam.Size = new System.Drawing.Size(179, 26);
            this.dtpFecTipCam.TabIndex = 422;
            // 
            // txtTipCamCom
            // 
            this.txtTipCamCom.Location = new System.Drawing.Point(219, 108);
            this.txtTipCamCom.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipCamCom.MaxLength = 10;
            this.txtTipCamCom.Name = "txtTipCamCom";
            this.txtTipCamCom.Size = new System.Drawing.Size(179, 26);
            this.txtTipCamCom.TabIndex = 423;
            this.txtTipCamCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTipCamVta
            // 
            this.txtTipCamVta.Location = new System.Drawing.Point(219, 144);
            this.txtTipCamVta.Margin = new System.Windows.Forms.Padding(4);
            this.txtTipCamVta.MaxLength = 10;
            this.txtTipCamVta.Name = "txtTipCamVta";
            this.txtTipCamVta.Size = new System.Drawing.Size(179, 26);
            this.txtTipCamVta.TabIndex = 424;
            this.txtTipCamVta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // wEditTipoCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(604, 361);
            this.Controls.Add(this.txtTipCamVta);
            this.Controls.Add(this.txtTipCamCom);
            this.Controls.Add(this.dtpFecTipCam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbEstTipCam);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "wEditTipoCambio";
            this.Text = "Edit Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditTipoOperacion_FormClosing);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbEstTipCam, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpFecTipCam, 0);
            this.Controls.SetChildIndex(this.txtTipCamCom, 0);
            this.Controls.SetChildIndex(this.txtTipCamVta, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstTipCam;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DateTimePicker dtpFecTipCam;
        private System.Windows.Forms.TextBox txtTipCamCom;
        private System.Windows.Forms.TextBox txtTipCamVta;
    }
}
