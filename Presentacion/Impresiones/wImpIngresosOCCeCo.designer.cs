namespace Presentacion.Impresiones
{
    partial class wImpIngresosOCCeCo
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
            this.ckbAlm = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ckbExi = new System.Windows.Forms.CheckBox();
            this.txtCodExi = new System.Windows.Forms.TextBox();
            this.txtDesExi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbPar = new System.Windows.Forms.CheckBox();
            this.txtCodPar = new System.Windows.Forms.TextBox();
            this.txtDesPar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbCeCo = new System.Windows.Forms.CheckBox();
            this.txtCodCenCosDes = new System.Windows.Forms.TextBox();
            this.txtDesCenCosDes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecHasMovCab = new System.Windows.Forms.DateTimePicker();
            this.dtpFecDesMovCab = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crIngresoOCCeCoResumen1 = new Presentacion.Impresiones.CrIngresoOCCeCoResumen();
            this.crv1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crIngresoOCCeCoDetalle1 = new Presentacion.Impresiones.CrIngresoOCCeCoDetalle();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoOrden = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbAlm
            // 
            this.ckbAlm.AutoSize = true;
            this.ckbAlm.ForeColor = System.Drawing.Color.Black;
            this.ckbAlm.Location = new System.Drawing.Point(769, 23);
            this.ckbAlm.Name = "ckbAlm";
            this.ckbAlm.Size = new System.Drawing.Size(95, 18);
            this.ckbAlm.TabIndex = 467;
            this.ckbAlm.Text = "Consolidado";
            this.ckbAlm.UseVisualStyleBackColor = true;
            this.ckbAlm.CheckedChanged += new System.EventHandler(this.ckbAlm_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(525, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 14);
            this.label18.TabIndex = 466;
            this.label18.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(599, 21);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(28, 22);
            this.txtCodAlm.TabIndex = 464;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(628, 21);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(135, 22);
            this.txtDesAlm.TabIndex = 465;
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Location = new System.Drawing.Point(953, 19);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(134, 22);
            this.cmbTipoReporte.TabIndex = 463;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(870, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 462;
            this.label6.Text = "Tipo Reporte";
            // 
            // ckbExi
            // 
            this.ckbExi.AutoSize = true;
            this.ckbExi.ForeColor = System.Drawing.Color.Black;
            this.ckbExi.Location = new System.Drawing.Point(789, 51);
            this.ckbExi.Name = "ckbExi";
            this.ckbExi.Size = new System.Drawing.Size(58, 18);
            this.ckbExi.TabIndex = 461;
            this.ckbExi.Text = "Todos";
            this.ckbExi.UseVisualStyleBackColor = true;
            this.ckbExi.CheckedChanged += new System.EventHandler(this.ckbExi_CheckedChanged);
            // 
            // txtCodExi
            // 
            this.txtCodExi.Location = new System.Drawing.Point(599, 49);
            this.txtCodExi.MaxLength = 15;
            this.txtCodExi.Name = "txtCodExi";
            this.txtCodExi.Size = new System.Drawing.Size(43, 22);
            this.txtCodExi.TabIndex = 460;
            this.txtCodExi.DoubleClick += new System.EventHandler(this.txtCodExi_DoubleClick);
            this.txtCodExi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExi_KeyDown);
            this.txtCodExi.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExi_Validating);
            // 
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(648, 49);
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(131, 22);
            this.txtDesExi.TabIndex = 459;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 14);
            this.label5.TabIndex = 458;
            this.label5.Text = "Existencia";
            // 
            // ckbPar
            // 
            this.ckbPar.AutoSize = true;
            this.ckbPar.ForeColor = System.Drawing.Color.Black;
            this.ckbPar.Location = new System.Drawing.Point(436, 51);
            this.ckbPar.Name = "ckbPar";
            this.ckbPar.Size = new System.Drawing.Size(58, 18);
            this.ckbPar.TabIndex = 457;
            this.ckbPar.Text = "Todos";
            this.ckbPar.UseVisualStyleBackColor = true;
            this.ckbPar.CheckedChanged += new System.EventHandler(this.ckbPar_CheckedChanged);
            // 
            // txtCodPar
            // 
            this.txtCodPar.Location = new System.Drawing.Point(255, 49);
            this.txtCodPar.MaxLength = 15;
            this.txtCodPar.Name = "txtCodPar";
            this.txtCodPar.Size = new System.Drawing.Size(43, 22);
            this.txtCodPar.TabIndex = 456;
            this.txtCodPar.DoubleClick += new System.EventHandler(this.txtCodPar_DoubleClick);
            this.txtCodPar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodPar_KeyDown);
            this.txtCodPar.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodPar_Validating);
            // 
            // txtDesPar
            // 
            this.txtDesPar.Location = new System.Drawing.Point(299, 49);
            this.txtDesPar.Name = "txtDesPar";
            this.txtDesPar.ReadOnly = true;
            this.txtDesPar.Size = new System.Drawing.Size(131, 22);
            this.txtDesPar.TabIndex = 455;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 454;
            this.label4.Text = "Partida";
            // 
            // ckbCeCo
            // 
            this.ckbCeCo.AutoSize = true;
            this.ckbCeCo.ForeColor = System.Drawing.Color.Black;
            this.ckbCeCo.Location = new System.Drawing.Point(436, 23);
            this.ckbCeCo.Name = "ckbCeCo";
            this.ckbCeCo.Size = new System.Drawing.Size(58, 18);
            this.ckbCeCo.TabIndex = 453;
            this.ckbCeCo.Text = "Todos";
            this.ckbCeCo.UseVisualStyleBackColor = true;
            this.ckbCeCo.CheckedChanged += new System.EventHandler(this.ckbCeCo_CheckedChanged);
            // 
            // txtCodCenCosDes
            // 
            this.txtCodCenCosDes.Location = new System.Drawing.Point(255, 21);
            this.txtCodCenCosDes.MaxLength = 15;
            this.txtCodCenCosDes.Name = "txtCodCenCosDes";
            this.txtCodCenCosDes.Size = new System.Drawing.Size(43, 22);
            this.txtCodCenCosDes.TabIndex = 452;
            this.txtCodCenCosDes.DoubleClick += new System.EventHandler(this.txtCodCenCosDes_DoubleClick);
            this.txtCodCenCosDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodCenCosDes_KeyDown);
            this.txtCodCenCosDes.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCenCosDes_Validating);
            // 
            // txtDesCenCosDes
            // 
            this.txtDesCenCosDes.Location = new System.Drawing.Point(299, 21);
            this.txtDesCenCosDes.Name = "txtDesCenCosDes";
            this.txtDesCenCosDes.ReadOnly = true;
            this.txtDesCenCosDes.Size = new System.Drawing.Size(131, 22);
            this.txtDesCenCosDes.TabIndex = 451;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 450;
            this.label3.Text = "Centro Costo";
            // 
            // dtpFecHasMovCab
            // 
            this.dtpFecHasMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecHasMovCab.Location = new System.Drawing.Point(61, 46);
            this.dtpFecHasMovCab.Name = "dtpFecHasMovCab";
            this.dtpFecHasMovCab.Size = new System.Drawing.Size(96, 22);
            this.dtpFecHasMovCab.TabIndex = 449;
            // 
            // dtpFecDesMovCab
            // 
            this.dtpFecDesMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDesMovCab.Location = new System.Drawing.Point(61, 18);
            this.dtpFecDesMovCab.Name = "dtpFecDesMovCab";
            this.dtpFecDesMovCab.Size = new System.Drawing.Size(96, 22);
            this.dtpFecDesMovCab.TabIndex = 448;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 14);
            this.label2.TabIndex = 447;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 446;
            this.label1.Text = "Desde";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(1122, 19);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 445;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1122, 48);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 444;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoOrden);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.ckbAlm);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodAlm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDesAlm);
            this.groupBox1.Controls.Add(this.dtpFecDesMovCab);
            this.groupBox1.Controls.Add(this.cmbTipoReporte);
            this.groupBox1.Controls.Add(this.dtpFecHasMovCab);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ckbExi);
            this.groupBox1.Controls.Add(this.txtDesCenCosDes);
            this.groupBox1.Controls.Add(this.txtCodExi);
            this.groupBox1.Controls.Add(this.txtCodCenCosDes);
            this.groupBox1.Controls.Add(this.txtDesExi);
            this.groupBox1.Controls.Add(this.ckbCeCo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ckbPar);
            this.groupBox1.Controls.Add(this.txtDesPar);
            this.groupBox1.Controls.Add(this.txtCodPar);
            this.groupBox1.Location = new System.Drawing.Point(16, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1236, 100);
            this.groupBox1.TabIndex = 468;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de Consultas";
            // 
            // crv1
            // 
            this.crv1.ActiveViewIndex = -1;
            this.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv1.Location = new System.Drawing.Point(11, 134);
            this.crv1.Name = "crv1";
            this.crv1.Size = new System.Drawing.Size(1241, 380);
            this.crv1.TabIndex = 469;
            this.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(870, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 468;
            this.label7.Text = "Tipo Orden";
            // 
            // cmbTipoOrden
            // 
            this.cmbTipoOrden.FormattingEnabled = true;
            this.cmbTipoOrden.Location = new System.Drawing.Point(953, 52);
            this.cmbTipoOrden.Name = "cmbTipoOrden";
            this.cmbTipoOrden.Size = new System.Drawing.Size(134, 22);
            this.cmbTipoOrden.TabIndex = 469;
            // 
            // wImpIngresosOCCeCo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(1263, 526);
            this.Controls.Add(this.crv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "wImpIngresosOCCeCo";
            this.Text = "Ingresos Orden Compra x Centro Costos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wImpIngresosOCCeCo_FormClosing);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.crv1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker dtpFecHasMovCab;
        internal System.Windows.Forms.DateTimePicker dtpFecDesMovCab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.TextBox txtCodAlm;
        internal System.Windows.Forms.CheckBox ckbAlm;
        internal System.Windows.Forms.TextBox txtDesAlm;
        internal System.Windows.Forms.CheckBox ckbExi;
        internal System.Windows.Forms.TextBox txtCodExi;
        internal System.Windows.Forms.TextBox txtDesExi;
        internal System.Windows.Forms.CheckBox ckbPar;
        internal System.Windows.Forms.TextBox txtCodPar;
        internal System.Windows.Forms.TextBox txtDesPar;
        internal System.Windows.Forms.CheckBox ckbCeCo;
        internal System.Windows.Forms.TextBox txtCodCenCosDes;
        internal System.Windows.Forms.TextBox txtDesCenCosDes;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrIngresoOCCeCoResumen crIngresoOCCeCoResumen1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv1;
        private CrIngresoOCCeCoDetalle crIngresoOCCeCoDetalle1;
        private System.Windows.Forms.ComboBox cmbTipoOrden;
        private System.Windows.Forms.Label label7;
    }
}
