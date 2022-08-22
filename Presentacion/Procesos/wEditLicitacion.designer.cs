namespace Presentacion.Procesos
{
    partial class wEditLicitacion
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtCodLic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDesLic = new System.Windows.Forms.TextBox();
            this.dtpFecLic = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodAux = new System.Windows.Forms.TextBox();
            this.txtDesAux = new System.Windows.Forms.TextBox();
            this.cmbEstLic = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(379, 212);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(274, 212);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 25);
            this.btnAceptar.TabIndex = 42;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DarkGray;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(32, 38);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(446, 14);
            this.label24.TabIndex = 343;
            this.label24.Text = "Datos Generales";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(32, 176);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(44, 14);
            this.label36.TabIndex = 367;
            this.label36.Text = "Estado";
            // 
            // txtCodLic
            // 
            this.txtCodLic.Location = new System.Drawing.Point(130, 89);
            this.txtCodLic.MaxLength = 50;
            this.txtCodLic.Name = "txtCodLic";
            this.txtCodLic.Size = new System.Drawing.Size(112, 22);
            this.txtCodLic.TabIndex = 408;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 14);
            this.label7.TabIndex = 409;
            this.label7.Text = "Codigo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 14);
            this.label8.TabIndex = 411;
            this.label8.Text = "Descripcion";
            // 
            // txtDesLic
            // 
            this.txtDesLic.Location = new System.Drawing.Point(130, 117);
            this.txtDesLic.MaxLength = 150;
            this.txtDesLic.Name = "txtDesLic";
            this.txtDesLic.Size = new System.Drawing.Size(348, 22);
            this.txtDesLic.TabIndex = 410;
            // 
            // dtpFecLic
            // 
            this.dtpFecLic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecLic.Location = new System.Drawing.Point(130, 145);
            this.dtpFecLic.Name = "dtpFecLic";
            this.dtpFecLic.Size = new System.Drawing.Size(112, 22);
            this.dtpFecLic.TabIndex = 414;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 14);
            this.label10.TabIndex = 415;
            this.label10.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 425;
            this.label4.Text = "Cliente";
            // 
            // txtCodAux
            // 
            this.txtCodAux.Location = new System.Drawing.Point(130, 61);
            this.txtCodAux.Name = "txtCodAux";
            this.txtCodAux.Size = new System.Drawing.Size(86, 22);
            this.txtCodAux.TabIndex = 423;
            this.txtCodAux.DoubleClick += new System.EventHandler(this.txtCodAux_DoubleClick);
            this.txtCodAux.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAux_KeyDown);
            this.txtCodAux.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAux_Validating);
            // 
            // txtDesAux
            // 
            this.txtDesAux.Location = new System.Drawing.Point(217, 61);
            this.txtDesAux.Name = "txtDesAux";
            this.txtDesAux.ReadOnly = true;
            this.txtDesAux.Size = new System.Drawing.Size(261, 22);
            this.txtDesAux.TabIndex = 424;
            // 
            // cmbEstLic
            // 
            this.cmbEstLic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstLic.Location = new System.Drawing.Point(130, 173);
            this.cmbEstLic.Name = "cmbEstLic";
            this.cmbEstLic.Size = new System.Drawing.Size(112, 22);
            this.cmbEstLic.TabIndex = 426;
            // 
            // wEditLicitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(513, 267);
            this.ControlBox = false;
            this.Controls.Add(this.cmbEstLic);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodAux);
            this.Controls.Add(this.txtDesAux);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpFecLic);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDesLic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCodLic);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wEditLicitacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Existencia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditLicitacion_FormClosing);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label36, 0);
            this.Controls.SetChildIndex(this.txtCodLic, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtDesLic, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.dtpFecLic, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtDesAux, 0);
            this.Controls.SetChildIndex(this.txtCodAux, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cmbEstLic, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtCodLic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesLic;
        private System.Windows.Forms.DateTimePicker dtpFecLic;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtCodAux;
        private System.Windows.Forms.TextBox txtDesAux;
        private System.Windows.Forms.ComboBox cmbEstLic;
    }
}