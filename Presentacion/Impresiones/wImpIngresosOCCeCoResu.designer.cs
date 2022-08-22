namespace Presentacion.Impresiones
{
    partial class wImpIngresosOCCeCoResu
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
            this.crv1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crIngresoOCCeCoResumen1 = new Presentacion.Impresiones.CrIngresoOCCeCoResumen();
            this.SuspendLayout();
            // 
            // crv1
            // 
            this.crv1.ActiveViewIndex = -1;
            this.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv1.Location = new System.Drawing.Point(6, 23);
            this.crv1.Name = "crv1";
            this.crv1.ReportSource = this.crIngresoOCCeCoResumen1;
            this.crv1.Size = new System.Drawing.Size(1219, 349);
            this.crv1.TabIndex = 77;
            this.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // wImpIngresosOCCeCoResu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(1231, 378);
            this.Controls.Add(this.crv1);
            this.Name = "wImpIngresosOCCeCoResu";
            this.Text = "Ingresos Orden Compra x Centro Costos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wImpIngresosOCCeCoResu_FormClosing);
            this.Controls.SetChildIndex(this.crv1, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv1;
        private CrIngresoOCCeCoResumen crIngresoOCCeCoResumen1;
    }
}
