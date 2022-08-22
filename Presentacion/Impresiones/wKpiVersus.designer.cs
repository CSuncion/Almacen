namespace Presentacion.Impresiones
{
    partial class wKpiVersus
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
            this.txtDesExiPT = new System.Windows.Forms.TextBox();
            this.txtCodExiPT = new System.Windows.Forms.TextBox();
            this.lblCodExiPT = new System.Windows.Forms.Label();
            this.ckbCodExi = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblTit
            // 
            this.lblTit.BackColor = System.Drawing.Color.DarkGray;
            this.lblTit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTit.ForeColor = System.Drawing.Color.White;
            this.lblTit.Location = new System.Drawing.Point(32, 40);
            this.lblTit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(641, 18);
            this.lblTit.TabIndex = 418;
            this.lblTit.Text = "Filtros Fecha de produccion";
            this.lblTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(289, 189);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(145, 32);
            this.btnExportar.TabIndex = 432;
            this.btnExportar.Text = "Exportar Excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(443, 189);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(145, 32);
            this.btnSalir.TabIndex = 433;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 75);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 18);
            this.label10.TabIndex = 435;
            this.label10.Text = "Fc. Desde";
            // 
            // dtpFecDes
            // 
            this.dtpFecDes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDes.Location = new System.Drawing.Point(163, 69);
            this.dtpFecDes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFecDes.Name = "dtpFecDes";
            this.dtpFecDes.Size = new System.Drawing.Size(148, 26);
            this.dtpFecDes.TabIndex = 434;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 437;
            this.label1.Text = "Fc. Hasta";
            // 
            // dtpFecHas
            // 
            this.dtpFecHas.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecHas.Location = new System.Drawing.Point(163, 105);
            this.dtpFecHas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFecHas.Name = "dtpFecHas";
            this.dtpFecHas.Size = new System.Drawing.Size(148, 26);
            this.dtpFecHas.TabIndex = 436;
            // 
            // txtDesExiPT
            // 
            this.txtDesExiPT.Location = new System.Drawing.Point(267, 141);
            this.txtDesExiPT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDesExiPT.Name = "txtDesExiPT";
            this.txtDesExiPT.ReadOnly = true;
            this.txtDesExiPT.Size = new System.Drawing.Size(320, 26);
            this.txtDesExiPT.TabIndex = 441;
            // 
            // txtCodExiPT
            // 
            this.txtCodExiPT.Location = new System.Drawing.Point(163, 141);
            this.txtCodExiPT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodExiPT.Name = "txtCodExiPT";
            this.txtCodExiPT.Size = new System.Drawing.Size(101, 26);
            this.txtCodExiPT.TabIndex = 440;
            this.txtCodExiPT.DoubleClick += new System.EventHandler(this.txtCodExiPT_DoubleClick);
            this.txtCodExiPT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExiPT_KeyDown);
            this.txtCodExiPT.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExiPT_Validating);
            // 
            // lblCodExiPT
            // 
            this.lblCodExiPT.AutoSize = true;
            this.lblCodExiPT.Location = new System.Drawing.Point(32, 145);
            this.lblCodExiPT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodExiPT.Name = "lblCodExiPT";
            this.lblCodExiPT.Size = new System.Drawing.Size(87, 18);
            this.lblCodExiPT.TabIndex = 439;
            this.lblCodExiPT.Text = "Existencia SE";
            // 
            // ckbCodExi
            // 
            this.ckbCodExi.AutoSize = true;
            this.ckbCodExi.Location = new System.Drawing.Point(596, 144);
            this.ckbCodExi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckbCodExi.Name = "ckbCodExi";
            this.ckbCodExi.Size = new System.Drawing.Size(66, 22);
            this.ckbCodExi.TabIndex = 442;
            this.ckbCodExi.Text = "Todos";
            this.ckbCodExi.UseVisualStyleBackColor = true;
            this.ckbCodExi.CheckedChanged += new System.EventHandler(this.ckbCodExi_CheckedChanged);
            // 
            // wKpiVersus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.ClientSize = new System.Drawing.Size(707, 258);
            this.Controls.Add(this.ckbCodExi);
            this.Controls.Add(this.txtDesExiPT);
            this.Controls.Add(this.txtCodExiPT);
            this.Controls.Add(this.lblCodExiPT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecHas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpFecDes);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblTit);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "wKpiVersus";
            this.Text = "Reporte KPI Unidades Planificadas y Reales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wKpiVersus_FormClosing);
            this.Controls.SetChildIndex(this.lblTit, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.dtpFecDes, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.dtpFecHas, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblCodExiPT, 0);
            this.Controls.SetChildIndex(this.txtCodExiPT, 0);
            this.Controls.SetChildIndex(this.txtDesExiPT, 0);
            this.Controls.SetChildIndex(this.ckbCodExi, 0);
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
        private System.Windows.Forms.TextBox txtDesExiPT;
        internal System.Windows.Forms.TextBox txtCodExiPT;
        private System.Windows.Forms.Label lblCodExiPT;
        private System.Windows.Forms.CheckBox ckbCodExi;
    }
}
