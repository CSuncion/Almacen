namespace Presentacion.Impresiones
{
    partial class wImpKardexFisico
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
            this.label18 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.ckbCodExi = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodExiHas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodExiDes = new System.Windows.Forms.TextBox();
            this.ckbTipExi = new System.Windows.Forms.CheckBox();
            this.cmbTipExi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.crv1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrKardexFisico1 = new Presentacion.Impresiones.CrKardexFisico();
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
            this.btnCancelar.Location = new System.Drawing.Point(779, 48);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(779, 21);
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
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtCodAlm);
            this.groupBox1.Controls.Add(this.txtDesAlm);
            this.groupBox1.Controls.Add(this.ckbCodExi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodExiHas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodExiDes);
            this.groupBox1.Controls.Add(this.ckbTipExi);
            this.groupBox1.Controls.Add(this.cmbTipExi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.txtAño);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbMes);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 83);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de listado";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(207, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 14);
            this.label18.TabIndex = 417;
            this.label18.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(285, 21);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(28, 22);
            this.txtCodAlm.TabIndex = 415;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(314, 21);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(184, 22);
            this.txtDesAlm.TabIndex = 416;
            // 
            // ckbCodExi
            // 
            this.ckbCodExi.AutoSize = true;
            this.ckbCodExi.Location = new System.Drawing.Point(715, 24);
            this.ckbCodExi.Name = "ckbCodExi";
            this.ckbCodExi.Size = new System.Drawing.Size(58, 18);
            this.ckbCodExi.TabIndex = 91;
            this.ckbCodExi.Text = "Todos";
            this.ckbCodExi.UseVisualStyleBackColor = true;
            this.ckbCodExi.CheckedChanged += new System.EventHandler(this.ckbCodExi_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 86;
            this.label2.Text = "Exis Hasta";
            // 
            // txtCodExiHas
            // 
            this.txtCodExiHas.Location = new System.Drawing.Point(609, 48);
            this.txtCodExiHas.MaxLength = 2;
            this.txtCodExiHas.Name = "txtCodExiHas";
            this.txtCodExiHas.Size = new System.Drawing.Size(100, 22);
            this.txtCodExiHas.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 84;
            this.label1.Text = "Exis Desde";
            // 
            // txtCodExiDes
            // 
            this.txtCodExiDes.Location = new System.Drawing.Point(609, 21);
            this.txtCodExiDes.MaxLength = 2;
            this.txtCodExiDes.Name = "txtCodExiDes";
            this.txtCodExiDes.Size = new System.Drawing.Size(100, 22);
            this.txtCodExiDes.TabIndex = 85;
            // 
            // ckbTipExi
            // 
            this.ckbTipExi.AutoSize = true;
            this.ckbTipExi.ForeColor = System.Drawing.Color.Black;
            this.ckbTipExi.Location = new System.Drawing.Point(440, 51);
            this.ckbTipExi.Name = "ckbTipExi";
            this.ckbTipExi.Size = new System.Drawing.Size(58, 18);
            this.ckbTipExi.TabIndex = 83;
            this.ckbTipExi.Text = "Todos";
            this.ckbTipExi.UseVisualStyleBackColor = true;
            this.ckbTipExi.CheckedChanged += new System.EventHandler(this.ckbTipExi_CheckedChanged);
            // 
            // cmbTipExi
            // 
            this.cmbTipExi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipExi.Location = new System.Drawing.Point(285, 48);
            this.cmbTipExi.Name = "cmbTipExi";
            this.cmbTipExi.Size = new System.Drawing.Size(148, 22);
            this.cmbTipExi.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 81;
            this.label3.Text = "Tipo";
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
            this.crv1.ReportSource = this.CrKardexFisico1;
            this.crv1.Size = new System.Drawing.Size(961, 249);
            this.crv1.TabIndex = 77;
            this.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // wImpKardexFisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(986, 378);
            this.Controls.Add(this.crv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "wImpKardexFisico";
            this.Text = "Kardex Fisico";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wImpKardexFisico_FormClosing);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodExiHas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodExiDes;
        private System.Windows.Forms.CheckBox ckbTipExi;
        private System.Windows.Forms.ComboBox cmbTipExi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbCodExi;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCodAlm;
        private System.Windows.Forms.TextBox txtDesAlm;
        private Impresiones.CrKardexFisico CrKardexFisico1;
    }
}
