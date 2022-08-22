namespace Presentacion.Impresiones
{
    partial class wImpCompraPorProveedor
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
            this.txtAño = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbProv = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodAux = new System.Windows.Forms.TextBox();
            this.txtDesAux = new System.Windows.Forms.TextBox();
            this.ckbCeCo = new System.Windows.Forms.CheckBox();
            this.txtCodCenCosDes = new System.Windows.Forms.TextBox();
            this.txtDesCenCosDes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbAlm = new System.Windows.Forms.CheckBox();
            this.ckbExi = new System.Windows.Forms.CheckBox();
            this.txtCodExi = new System.Windows.Forms.TextBox();
            this.txtDesExi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.crv1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crCompraProveedor1 = new Presentacion.Impresiones.CrCompraProveedor();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Año";
            // 
            // txtAño
            // 
            this.txtAño.Location = new System.Drawing.Point(78, 21);
            this.txtAño.MaxLength = 2;
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(108, 22);
            this.txtAño.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Mes";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Location = new System.Drawing.Point(78, 48);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(108, 22);
            this.cmbMes.TabIndex = 57;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1104, 46);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(1104, 19);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ckbProv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodAux);
            this.groupBox1.Controls.Add(this.txtDesAux);
            this.groupBox1.Controls.Add(this.ckbCeCo);
            this.groupBox1.Controls.Add(this.txtCodCenCosDes);
            this.groupBox1.Controls.Add(this.txtDesCenCosDes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ckbAlm);
            this.groupBox1.Controls.Add(this.ckbExi);
            this.groupBox1.Controls.Add(this.txtCodExi);
            this.groupBox1.Controls.Add(this.txtDesExi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtCodAlm);
            this.groupBox1.Controls.Add(this.txtDesAlm);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.txtAño);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbMes);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1219, 83);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de listado";
            // 
            // ckbProv
            // 
            this.ckbProv.AutoSize = true;
            this.ckbProv.ForeColor = System.Drawing.Color.Black;
            this.ckbProv.Location = new System.Drawing.Point(591, 49);
            this.ckbProv.Name = "ckbProv";
            this.ckbProv.Size = new System.Drawing.Size(58, 18);
            this.ckbProv.TabIndex = 476;
            this.ckbProv.Text = "Todos";
            this.ckbProv.UseVisualStyleBackColor = true;
            this.ckbProv.CheckedChanged += new System.EventHandler(this.ckbProv_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 475;
            this.label1.Text = "Proveedor";
            // 
            // txtCodAux
            // 
            this.txtCodAux.Location = new System.Drawing.Point(296, 47);
            this.txtCodAux.Name = "txtCodAux";
            this.txtCodAux.Size = new System.Drawing.Size(86, 22);
            this.txtCodAux.TabIndex = 473;
            this.txtCodAux.DoubleClick += new System.EventHandler(this.txtCodAux_DoubleClick);
            this.txtCodAux.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAux_KeyDown);
            this.txtCodAux.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAux_Validating);
            // 
            // txtDesAux
            // 
            this.txtDesAux.Location = new System.Drawing.Point(388, 47);
            this.txtDesAux.Name = "txtDesAux";
            this.txtDesAux.ReadOnly = true;
            this.txtDesAux.Size = new System.Drawing.Size(197, 22);
            this.txtDesAux.TabIndex = 474;
            // 
            // ckbCeCo
            // 
            this.ckbCeCo.AutoSize = true;
            this.ckbCeCo.ForeColor = System.Drawing.Color.Black;
            this.ckbCeCo.Location = new System.Drawing.Point(477, 23);
            this.ckbCeCo.Name = "ckbCeCo";
            this.ckbCeCo.Size = new System.Drawing.Size(58, 18);
            this.ckbCeCo.TabIndex = 472;
            this.ckbCeCo.Text = "Todos";
            this.ckbCeCo.UseVisualStyleBackColor = true;
            this.ckbCeCo.CheckedChanged += new System.EventHandler(this.ckbCeCo_CheckedChanged);
            // 
            // txtCodCenCosDes
            // 
            this.txtCodCenCosDes.Location = new System.Drawing.Point(296, 21);
            this.txtCodCenCosDes.MaxLength = 15;
            this.txtCodCenCosDes.Name = "txtCodCenCosDes";
            this.txtCodCenCosDes.Size = new System.Drawing.Size(43, 22);
            this.txtCodCenCosDes.TabIndex = 471;
            this.txtCodCenCosDes.DoubleClick += new System.EventHandler(this.txtCodCenCosDes_DoubleClick);
            this.txtCodCenCosDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodCenCosDes_KeyDown);
            this.txtCodCenCosDes.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCenCosDes_Validating);
            // 
            // txtDesCenCosDes
            // 
            this.txtDesCenCosDes.Location = new System.Drawing.Point(340, 21);
            this.txtDesCenCosDes.Name = "txtDesCenCosDes";
            this.txtDesCenCosDes.ReadOnly = true;
            this.txtDesCenCosDes.Size = new System.Drawing.Size(131, 22);
            this.txtDesCenCosDes.TabIndex = 470;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 469;
            this.label3.Text = "Centro Costo";
            // 
            // ckbAlm
            // 
            this.ckbAlm.AutoSize = true;
            this.ckbAlm.ForeColor = System.Drawing.Color.Black;
            this.ckbAlm.Location = new System.Drawing.Point(985, 21);
            this.ckbAlm.Name = "ckbAlm";
            this.ckbAlm.Size = new System.Drawing.Size(95, 18);
            this.ckbAlm.TabIndex = 468;
            this.ckbAlm.Text = "Consolidado";
            this.ckbAlm.UseVisualStyleBackColor = true;
            this.ckbAlm.CheckedChanged += new System.EventHandler(this.ckbAlm_CheckedChanged);
            // 
            // ckbExi
            // 
            this.ckbExi.AutoSize = true;
            this.ckbExi.ForeColor = System.Drawing.Color.Black;
            this.ckbExi.Location = new System.Drawing.Point(985, 49);
            this.ckbExi.Name = "ckbExi";
            this.ckbExi.Size = new System.Drawing.Size(58, 18);
            this.ckbExi.TabIndex = 465;
            this.ckbExi.Text = "Todos";
            this.ckbExi.UseVisualStyleBackColor = true;
            this.ckbExi.CheckedChanged += new System.EventHandler(this.ckbExi_CheckedChanged);
            // 
            // txtCodExi
            // 
            this.txtCodExi.Location = new System.Drawing.Point(766, 46);
            this.txtCodExi.MaxLength = 15;
            this.txtCodExi.Name = "txtCodExi";
            this.txtCodExi.Size = new System.Drawing.Size(43, 22);
            this.txtCodExi.TabIndex = 464;
            this.txtCodExi.DoubleClick += new System.EventHandler(this.txtCodExi_DoubleClick);
            this.txtCodExi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExi_KeyDown);
            this.txtCodExi.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExi_Validating);
            // 
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(815, 46);
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(164, 22);
            this.txtDesExi.TabIndex = 463;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(688, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 14);
            this.label5.TabIndex = 462;
            this.label5.Text = "Existencia";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(688, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 14);
            this.label18.TabIndex = 417;
            this.label18.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(766, 19);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(28, 22);
            this.txtCodAlm.TabIndex = 415;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(795, 19);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(184, 22);
            this.txtDesAlm.TabIndex = 416;
            // 
            // crv1
            // 
            this.crv1.ActiveViewIndex = 0;
            this.crv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv1.Location = new System.Drawing.Point(12, 117);
            this.crv1.Name = "crv1";
            this.crv1.ReportSource = this.crCompraProveedor1;
            this.crv1.Size = new System.Drawing.Size(1219, 249);
            this.crv1.TabIndex = 77;
            this.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // wImpCompraPorProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(1244, 378);
            this.Controls.Add(this.crv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "wImpCompraPorProveedor";
            this.Text = "Compra por Proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wImpCompraPorProveedor_FormClosing);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.crv1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCodAlm;
        private System.Windows.Forms.TextBox txtDesAlm;
        internal System.Windows.Forms.CheckBox ckbExi;
        internal System.Windows.Forms.TextBox txtCodExi;
        internal System.Windows.Forms.TextBox txtDesExi;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.CheckBox ckbAlm;
        internal System.Windows.Forms.CheckBox ckbCeCo;
        internal System.Windows.Forms.TextBox txtCodCenCosDes;
        internal System.Windows.Forms.TextBox txtDesCenCosDes;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.CheckBox ckbProv;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCodAux;
        private System.Windows.Forms.TextBox txtDesAux;
        private CrCompraProveedor crCompraProveedor1;
    }
}
