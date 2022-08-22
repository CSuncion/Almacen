namespace Presentacion.Impresiones
{
    partial class wPorCumplimientoProduccion
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
            this.lblTit = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAñoSal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbMesSal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTit
            // 
            this.lblTit.BackColor = System.Drawing.Color.DarkGray;
            this.lblTit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTit.ForeColor = System.Drawing.Color.White;
            this.lblTit.Location = new System.Drawing.Point(24, 31);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(307, 14);
            this.lblTit.TabIndex = 418;
            this.lblTit.Text = "Filtros Fecha de produccion";
            this.lblTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(107, 96);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 25);
            this.btnExportar.TabIndex = 432;
            this.btnExportar.Text = "Exportar Excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(222, 96);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 25);
            this.btnSalir.TabIndex = 433;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 14);
            this.label11.TabIndex = 434;
            this.label11.Text = "Año";
            // 
            // txtAñoSal
            // 
            this.txtAñoSal.Location = new System.Drawing.Point(68, 63);
            this.txtAñoSal.MaxLength = 2;
            this.txtAñoSal.Name = "txtAñoSal";
            this.txtAñoSal.Size = new System.Drawing.Size(67, 22);
            this.txtAñoSal.TabIndex = 435;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(161, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 14);
            this.label13.TabIndex = 436;
            this.label13.Text = "Mes";
            // 
            // cmbMesSal
            // 
            this.cmbMesSal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesSal.Location = new System.Drawing.Point(207, 63);
            this.cmbMesSal.Name = "cmbMesSal";
            this.cmbMesSal.Size = new System.Drawing.Size(124, 22);
            this.cmbMesSal.TabIndex = 437;
            // 
            // wPorCumplimientoProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(359, 153);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAñoSal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbMesSal);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblTit);
            this.Name = "wPorCumplimientoProduccion";
            this.Text = "Reporte % Cumplimiento Produccion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wPorCumplimientoProduccion_FormClosing);
            this.Controls.SetChildIndex(this.lblTit, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.cmbMesSal, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtAñoSal, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTit;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAñoSal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbMesSal;
    }
}
