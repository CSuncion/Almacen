﻿namespace Presentacion.Impresiones
{
    partial class wImpSalidasCeCoDeta
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
            this.ckbExi = new System.Windows.Forms.CheckBox();
            this.txtCodExiHas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodExiDes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckbCeCo = new System.Windows.Forms.CheckBox();
            this.txtCodCenCosHas = new System.Windows.Forms.TextBox();
            this.txtDesCenCosHas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodCenCosDes = new System.Windows.Forms.TextBox();
            this.txtDesCenCosDes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecHasMovCab = new System.Windows.Forms.DateTimePicker();
            this.dtpFecDesMovCab = new System.Windows.Forms.DateTimePicker();
            this.ckbAlm = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crv1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrSalidaCeCoDetalle1 = new Presentacion.Impresiones.CrSalidaCeCoDetalle();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1089, 46);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(1089, 18);
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
            this.groupBox1.Controls.Add(this.ckbExi);
            this.groupBox1.Controls.Add(this.txtCodExiHas);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCodExiDes);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ckbCeCo);
            this.groupBox1.Controls.Add(this.txtCodCenCosHas);
            this.groupBox1.Controls.Add(this.txtDesCenCosHas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCodCenCosDes);
            this.groupBox1.Controls.Add(this.txtDesCenCosDes);
            this.groupBox1.Controls.Add(this.label3);
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
            this.groupBox1.Size = new System.Drawing.Size(1206, 84);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de listado";
            // 
            // ckbExi
            // 
            this.ckbExi.AutoSize = true;
            this.ckbExi.ForeColor = System.Drawing.Color.Black;
            this.ckbExi.Location = new System.Drawing.Point(671, 23);
            this.ckbExi.Name = "ckbExi";
            this.ckbExi.Size = new System.Drawing.Size(58, 18);
            this.ckbExi.TabIndex = 436;
            this.ckbExi.Text = "Todos";
            this.ckbExi.UseVisualStyleBackColor = true;
            this.ckbExi.CheckedChanged += new System.EventHandler(this.ckbExi_CheckedChanged);
            // 
            // txtCodExiHas
            // 
            this.txtCodExiHas.Location = new System.Drawing.Point(593, 47);
            this.txtCodExiHas.MaxLength = 15;
            this.txtCodExiHas.Name = "txtCodExiHas";
            this.txtCodExiHas.Size = new System.Drawing.Size(72, 22);
            this.txtCodExiHas.TabIndex = 435;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(525, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 14);
            this.label6.TabIndex = 433;
            this.label6.Text = "Exi.Hasta";
            // 
            // txtCodExiDes
            // 
            this.txtCodExiDes.Location = new System.Drawing.Point(593, 21);
            this.txtCodExiDes.MaxLength = 15;
            this.txtCodExiDes.Name = "txtCodExiDes";
            this.txtCodExiDes.Size = new System.Drawing.Size(72, 22);
            this.txtCodExiDes.TabIndex = 432;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 14);
            this.label5.TabIndex = 430;
            this.label5.Text = "Exi.Desde";
            // 
            // ckbCeCo
            // 
            this.ckbCeCo.AutoSize = true;
            this.ckbCeCo.ForeColor = System.Drawing.Color.Black;
            this.ckbCeCo.Location = new System.Drawing.Point(287, 23);
            this.ckbCeCo.Name = "ckbCeCo";
            this.ckbCeCo.Size = new System.Drawing.Size(58, 18);
            this.ckbCeCo.TabIndex = 429;
            this.ckbCeCo.Text = "Todos";
            this.ckbCeCo.UseVisualStyleBackColor = true;
            this.ckbCeCo.CheckedChanged += new System.EventHandler(this.ckbCeCo_CheckedChanged);
            // 
            // txtCodCenCosHas
            // 
            this.txtCodCenCosHas.Location = new System.Drawing.Point(106, 47);
            this.txtCodCenCosHas.MaxLength = 15;
            this.txtCodCenCosHas.Name = "txtCodCenCosHas";
            this.txtCodCenCosHas.Size = new System.Drawing.Size(43, 22);
            this.txtCodCenCosHas.TabIndex = 428;
            this.txtCodCenCosHas.DoubleClick += new System.EventHandler(this.txtCodCenCosHas_DoubleClick);
            this.txtCodCenCosHas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodCenCosHas_KeyDown);
            this.txtCodCenCosHas.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCenCosHas_Validating);
            // 
            // txtDesCenCosHas
            // 
            this.txtDesCenCosHas.Location = new System.Drawing.Point(150, 47);
            this.txtDesCenCosHas.Name = "txtDesCenCosHas";
            this.txtDesCenCosHas.ReadOnly = true;
            this.txtDesCenCosHas.Size = new System.Drawing.Size(131, 22);
            this.txtDesCenCosHas.TabIndex = 427;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 14);
            this.label4.TabIndex = 426;
            this.label4.Text = "Ce.Co Hasta";
            // 
            // txtCodCenCosDes
            // 
            this.txtCodCenCosDes.Location = new System.Drawing.Point(106, 21);
            this.txtCodCenCosDes.MaxLength = 15;
            this.txtCodCenCosDes.Name = "txtCodCenCosDes";
            this.txtCodCenCosDes.Size = new System.Drawing.Size(43, 22);
            this.txtCodCenCosDes.TabIndex = 425;
            this.txtCodCenCosDes.DoubleClick += new System.EventHandler(this.txtCodCenCosDes_DoubleClick);
            this.txtCodCenCosDes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodCenCosDes_KeyDown);
            this.txtCodCenCosDes.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodCenCosDes_Validating);
            // 
            // txtDesCenCosDes
            // 
            this.txtDesCenCosDes.Location = new System.Drawing.Point(150, 21);
            this.txtDesCenCosDes.Name = "txtDesCenCosDes";
            this.txtDesCenCosDes.ReadOnly = true;
            this.txtDesCenCosDes.Size = new System.Drawing.Size(131, 22);
            this.txtDesCenCosDes.TabIndex = 424;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 14);
            this.label3.TabIndex = 423;
            this.label3.Text = "Ce.Co Desde";
            // 
            // dtpFecHasMovCab
            // 
            this.dtpFecHasMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecHasMovCab.Location = new System.Drawing.Point(413, 48);
            this.dtpFecHasMovCab.Name = "dtpFecHasMovCab";
            this.dtpFecHasMovCab.Size = new System.Drawing.Size(96, 22);
            this.dtpFecHasMovCab.TabIndex = 422;
            // 
            // dtpFecDesMovCab
            // 
            this.dtpFecDesMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDesMovCab.Location = new System.Drawing.Point(413, 21);
            this.dtpFecDesMovCab.Name = "dtpFecDesMovCab";
            this.dtpFecDesMovCab.Size = new System.Drawing.Size(96, 22);
            this.dtpFecDesMovCab.TabIndex = 421;
            // 
            // ckbAlm
            // 
            this.ckbAlm.AutoSize = true;
            this.ckbAlm.ForeColor = System.Drawing.Color.Black;
            this.ckbAlm.Location = new System.Drawing.Point(987, 23);
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
            this.label18.Location = new System.Drawing.Point(743, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 14);
            this.label18.TabIndex = 417;
            this.label18.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(817, 21);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(28, 22);
            this.txtCodAlm.TabIndex = 415;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(846, 21);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(135, 22);
            this.txtDesAlm.TabIndex = 416;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 14);
            this.label2.TabIndex = 86;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 24);
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
            this.crv1.Location = new System.Drawing.Point(12, 118);
            this.crv1.Name = "crv1";
            this.crv1.ReportSource = this.CrSalidaCeCoDetalle1;
            this.crv1.Size = new System.Drawing.Size(1206, 248);
            this.crv1.TabIndex = 77;
            this.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // wImpSalidasCeCoDeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(1231, 378);
            this.Controls.Add(this.crv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "wImpSalidasCeCoDeta";
            this.Text = "Salidas x Centro Costos Detalle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wImpSalidasCeCoDeta_FormClosing);
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
        private System.Windows.Forms.TextBox txtCodCenCosDes;
        private System.Windows.Forms.TextBox txtDesCenCosDes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbCeCo;
        private System.Windows.Forms.TextBox txtCodCenCosHas;
        private System.Windows.Forms.TextBox txtDesCenCosHas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckbExi;
        private System.Windows.Forms.TextBox txtCodExiHas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodExiDes;
        private System.Windows.Forms.Label label5;
        private CrSalidaCeCoDetalle CrSalidaCeCoDetalle1;
    }
}
