namespace Presentacion.Impresiones
{
    partial class wImpDocumentosEmitidosDeta
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodTipOpe = new System.Windows.Forms.TextBox();
            this.txtDesTipOpe = new System.Windows.Forms.TextBox();
            this.dtpFecHasMovCab = new System.Windows.Forms.DateTimePicker();
            this.dtpFecDesMovCab = new System.Windows.Forms.DateTimePicker();
            this.cmbClaOpe = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbAlm = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbTipOpe = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.crv1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrDocumentoEmitidoDetalle1 = new Presentacion.Impresiones.CrDocumentoEmitidoDetalle();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1008, 47);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(1008, 19);
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
            this.groupBox1.Controls.Add(this.txtCodTipOpe);
            this.groupBox1.Controls.Add(this.txtDesTipOpe);
            this.groupBox1.Controls.Add(this.dtpFecHasMovCab);
            this.groupBox1.Controls.Add(this.dtpFecDesMovCab);
            this.groupBox1.Controls.Add(this.cmbClaOpe);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ckbAlm);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtCodAlm);
            this.groupBox1.Controls.Add(this.txtDesAlm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ckbTipOpe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1138, 83);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de listado";
            // 
            // txtCodTipOpe
            // 
            this.txtCodTipOpe.Location = new System.Drawing.Point(123, 50);
            this.txtCodTipOpe.Name = "txtCodTipOpe";
            this.txtCodTipOpe.Size = new System.Drawing.Size(33, 22);
            this.txtCodTipOpe.TabIndex = 423;
            this.txtCodTipOpe.DoubleClick += new System.EventHandler(this.txtCodTipOpe_DoubleClick);
            this.txtCodTipOpe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodTipOpe_KeyDown);
            this.txtCodTipOpe.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodTipOpe_Validating);
            // 
            // txtDesTipOpe
            // 
            this.txtDesTipOpe.Location = new System.Drawing.Point(157, 50);
            this.txtDesTipOpe.Name = "txtDesTipOpe";
            this.txtDesTipOpe.ReadOnly = true;
            this.txtDesTipOpe.Size = new System.Drawing.Size(166, 22);
            this.txtDesTipOpe.TabIndex = 424;
            // 
            // dtpFecHasMovCab
            // 
            this.dtpFecHasMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecHasMovCab.Location = new System.Drawing.Point(462, 50);
            this.dtpFecHasMovCab.Name = "dtpFecHasMovCab";
            this.dtpFecHasMovCab.Size = new System.Drawing.Size(99, 22);
            this.dtpFecHasMovCab.TabIndex = 422;
            // 
            // dtpFecDesMovCab
            // 
            this.dtpFecDesMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDesMovCab.Location = new System.Drawing.Point(462, 23);
            this.dtpFecDesMovCab.Name = "dtpFecDesMovCab";
            this.dtpFecDesMovCab.Size = new System.Drawing.Size(99, 22);
            this.dtpFecDesMovCab.TabIndex = 421;
            // 
            // cmbClaOpe
            // 
            this.cmbClaOpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClaOpe.Location = new System.Drawing.Point(123, 23);
            this.cmbClaOpe.Name = "cmbClaOpe";
            this.cmbClaOpe.Size = new System.Drawing.Size(200, 22);
            this.cmbClaOpe.TabIndex = 420;
            this.cmbClaOpe.SelectionChangeCommitted += new System.EventHandler(this.cmbClaOpe_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 419;
            this.label4.Text = "Movimiento";
            // 
            // ckbAlm
            // 
            this.ckbAlm.AutoSize = true;
            this.ckbAlm.ForeColor = System.Drawing.Color.Black;
            this.ckbAlm.Location = new System.Drawing.Point(899, 25);
            this.ckbAlm.Name = "ckbAlm";
            this.ckbAlm.Size = new System.Drawing.Size(95, 18);
            this.ckbAlm.TabIndex = 418;
            this.ckbAlm.Text = "Consolidado";
            this.ckbAlm.UseVisualStyleBackColor = true;
            this.ckbAlm.CheckedChanged += new System.EventHandler(this.ckbAlm_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(609, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 14);
            this.label18.TabIndex = 417;
            this.label18.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(683, 23);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(28, 22);
            this.txtCodAlm.TabIndex = 415;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(712, 23);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(184, 22);
            this.txtDesAlm.TabIndex = 416;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 14);
            this.label2.TabIndex = 86;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 84;
            this.label1.Text = "Desde";
            // 
            // ckbTipOpe
            // 
            this.ckbTipOpe.AutoSize = true;
            this.ckbTipOpe.ForeColor = System.Drawing.Color.Black;
            this.ckbTipOpe.Location = new System.Drawing.Point(326, 53);
            this.ckbTipOpe.Name = "ckbTipOpe";
            this.ckbTipOpe.Size = new System.Drawing.Size(58, 18);
            this.ckbTipOpe.TabIndex = 83;
            this.ckbTipOpe.Text = "Todos";
            this.ckbTipOpe.UseVisualStyleBackColor = true;
            this.ckbTipOpe.CheckedChanged += new System.EventHandler(this.ckbTipOpe_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 14);
            this.label3.TabIndex = 81;
            this.label3.Text = "Tipo Operacion";
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
            this.crv1.ReportSource = this.CrDocumentoEmitidoDetalle1;
            this.crv1.Size = new System.Drawing.Size(1138, 249);
            this.crv1.TabIndex = 77;
            this.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // wImpDocumentosEmitidosDeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(1163, 378);
            this.Controls.Add(this.crv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "wImpDocumentosEmitidosDeta";
            this.Text = "Documentos Emitidos Detalle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wImpDocumentosEmitidosDeta_FormClosing);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.crv1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbTipOpe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCodAlm;
        private System.Windows.Forms.TextBox txtDesAlm;
        private System.Windows.Forms.CheckBox ckbAlm;
        private System.Windows.Forms.ComboBox cmbClaOpe;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtpFecHasMovCab;
        internal System.Windows.Forms.DateTimePicker dtpFecDesMovCab;
        internal System.Windows.Forms.TextBox txtCodTipOpe;
        private System.Windows.Forms.TextBox txtDesTipOpe;
        private CrDocumentoEmitidoDetalle CrDocumentoEmitidoDetalle1;
    }
}
