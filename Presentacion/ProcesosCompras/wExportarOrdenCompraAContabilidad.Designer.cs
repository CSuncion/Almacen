namespace Presentacion.ProcesosCompras
{
    partial class wExportarOrdenCompraAContabilidad
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAñoSal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbMesSal = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtAñoSal);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbMesSal);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 65);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DarkGray;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(12, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(351, 17);
            this.label24.TabIndex = 387;
            this.label24.Text = "Exportar Orden de Compra";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(204, 116);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(285, 116);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 14);
            this.label11.TabIndex = 58;
            this.label11.Text = "Año";
            // 
            // txtAñoSal
            // 
            this.txtAñoSal.Location = new System.Drawing.Point(64, 21);
            this.txtAñoSal.MaxLength = 2;
            this.txtAñoSal.Name = "txtAñoSal";
            this.txtAñoSal.Size = new System.Drawing.Size(67, 22);
            this.txtAñoSal.TabIndex = 59;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 14);
            this.label13.TabIndex = 60;
            this.label13.Text = "Mes";
            // 
            // cmbMesSal
            // 
            this.cmbMesSal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesSal.Location = new System.Drawing.Point(218, 21);
            this.cmbMesSal.Name = "cmbMesSal";
            this.cmbMesSal.Size = new System.Drawing.Size(124, 22);
            this.cmbMesSal.TabIndex = 61;
            // 
            // wExportarOrdenCompraAContabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 151);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "wExportarOrdenCompraAContabilidad";
            this.Text = "Exportar Orden de Compra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wExportarOrdenCompraAContabilidad_FormClosing);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAñoSal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbMesSal;
    }
}