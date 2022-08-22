namespace Presentacion.Impresiones
{
    partial class wImpRecords
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
            this.dtpFecHasMovCab = new System.Windows.Forms.DateTimePicker();
            this.dtpFecDesMovCab = new System.Windows.Forms.DateTimePicker();
            this.ckbAlm = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crv1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrRecord1 = new Presentacion.Impresiones.CrRecord();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(630, 46);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(630, 18);
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
            this.groupBox1.Controls.Add(this.dtpFecHasMovCab);
            this.groupBox1.Controls.Add(this.dtpFecDesMovCab);
            this.groupBox1.Controls.Add(this.ckbAlm);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtCodAlm);
            this.groupBox1.Controls.Add(this.txtDesAlm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 83);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de listado";
            // 
            // dtpFecHasMovCab
            // 
            this.dtpFecHasMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecHasMovCab.Location = new System.Drawing.Point(84, 49);
            this.dtpFecHasMovCab.Name = "dtpFecHasMovCab";
            this.dtpFecHasMovCab.Size = new System.Drawing.Size(99, 22);
            this.dtpFecHasMovCab.TabIndex = 422;
            // 
            // dtpFecDesMovCab
            // 
            this.dtpFecDesMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDesMovCab.Location = new System.Drawing.Point(84, 22);
            this.dtpFecDesMovCab.Name = "dtpFecDesMovCab";
            this.dtpFecDesMovCab.Size = new System.Drawing.Size(99, 22);
            this.dtpFecDesMovCab.TabIndex = 421;
            // 
            // ckbAlm
            // 
            this.ckbAlm.AutoSize = true;
            this.ckbAlm.ForeColor = System.Drawing.Color.Black;
            this.ckbAlm.Location = new System.Drawing.Point(521, 24);
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
            this.label18.Location = new System.Drawing.Point(231, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 14);
            this.label18.TabIndex = 417;
            this.label18.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(305, 22);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(28, 22);
            this.txtCodAlm.TabIndex = 415;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(334, 22);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(184, 22);
            this.txtDesAlm.TabIndex = 416;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 14);
            this.label2.TabIndex = 86;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 84;
            this.label1.Text = "Desde";
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
            this.crv1.ReportSource = this.CrRecord1;
            this.crv1.Size = new System.Drawing.Size(891, 249);
            this.crv1.TabIndex = 77;
            this.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // wImpRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(916, 378);
            this.Controls.Add(this.crv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "wImpRecords";
            this.Text = "Records de existencias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wImpRecords_FormClosing);
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
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCodAlm;
        private System.Windows.Forms.TextBox txtDesAlm;
        private System.Windows.Forms.CheckBox ckbAlm;
        internal System.Windows.Forms.DateTimePicker dtpFecHasMovCab;
        internal System.Windows.Forms.DateTimePicker dtpFecDesMovCab;
        private CrRecord CrRecord1;
    }
}
