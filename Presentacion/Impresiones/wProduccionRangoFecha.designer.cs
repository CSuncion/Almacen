namespace Presentacion.Impresiones
{
    partial class wProduccionRangoFecha
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
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFecDes = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecHas = new System.Windows.Forms.DateTimePicker();
            this.cmbTipUni = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTit
            // 
            this.lblTit.BackColor = System.Drawing.Color.DarkGray;
            this.lblTit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTit.ForeColor = System.Drawing.Color.White;
            this.lblTit.Location = new System.Drawing.Point(24, 31);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(290, 14);
            this.lblTit.TabIndex = 418;
            this.lblTit.Text = "Filtros Fecha de produccion";
            this.lblTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(90, 145);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 25);
            this.btnExportar.TabIndex = 432;
            this.btnExportar.Text = "Exportar Excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(205, 145);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 25);
            this.btnSalir.TabIndex = 433;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 14);
            this.label10.TabIndex = 435;
            this.label10.Text = "Fc. Desde";
            // 
            // dtpFecDes
            // 
            this.dtpFecDes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDes.Location = new System.Drawing.Point(122, 54);
            this.dtpFecDes.Name = "dtpFecDes";
            this.dtpFecDes.Size = new System.Drawing.Size(112, 22);
            this.dtpFecDes.TabIndex = 434;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 437;
            this.label1.Text = "Fc. Hasta";
            // 
            // dtpFecHas
            // 
            this.dtpFecHas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecHas.Location = new System.Drawing.Point(122, 82);
            this.dtpFecHas.Name = "dtpFecHas";
            this.dtpFecHas.Size = new System.Drawing.Size(112, 22);
            this.dtpFecHas.TabIndex = 436;
            // 
            // cmbTipUni
            // 
            this.cmbTipUni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipUni.Items.AddRange(new object[] {
            "UND",
            "KG"});
            this.cmbTipUni.Location = new System.Drawing.Point(122, 110);
            this.cmbTipUni.Name = "cmbTipUni";
            this.cmbTipUni.Size = new System.Drawing.Size(64, 22);
            this.cmbTipUni.TabIndex = 439;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 14);
            this.label11.TabIndex = 438;
            this.label11.Text = "Tipo Unidad";
            // 
            // wProduccionRangoFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(342, 194);
            this.Controls.Add(this.cmbTipUni);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecHas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpFecDes);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblTit);
            this.Name = "wProduccionRangoFecha";
            this.Text = "Reporte Formato Envasado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wProduccionRangoFecha_FormClosing);
            this.Controls.SetChildIndex(this.lblTit, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtpFecDes, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.dtpFecHas, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.cmbTipUni, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTit;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFecDes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecHas;
        private System.Windows.Forms.ComboBox cmbTipUni;
        private System.Windows.Forms.Label label11;
    }
}
