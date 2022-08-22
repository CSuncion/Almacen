namespace Presentacion.Consultas
{
    partial class wMovimientos
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
            this.tsSecundario = new System.Windows.Forms.ToolStrip();
            this.tsbPrimero = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbSiguiente = new System.Windows.Forms.ToolStripButton();
            this.tsbUltimo = new System.Windows.Forms.ToolStripButton();
            this.tsbActualizarTabla = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPeriodo = new System.Windows.Forms.ToolStripLabel();
            this.lblDescripcionPeriodo = new System.Windows.Forms.ToolStripLabel();
            this.btnPeriodo = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsbImprimirNota = new System.Windows.Forms.ToolStripButton();
            this.DgvMovCab = new System.Windows.Forms.DataGridView();
            this.lblTituloCabe = new System.Windows.Forms.Label();
            this.lblTituloDeta = new System.Windows.Forms.Label();
            this.dgvMovDet = new System.Windows.Forms.DataGridView();
            this.tsbExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.tsSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMovCab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).BeginInit();
            this.SuspendLayout();
            // 
            // tsSecundario
            // 
            this.tsSecundario.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSecundario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrimero,
            this.tsbAnterior,
            this.tsbSiguiente,
            this.tsbUltimo,
            this.tsbActualizarTabla,
            this.toolStripSeparator1,
            this.tstBuscar,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.lblPeriodo,
            this.lblDescripcionPeriodo,
            this.btnPeriodo,
            this.toolStripLabel2,
            this.tsbImprimirNota,
            this.tsbExportarExcel});
            this.tsSecundario.Location = new System.Drawing.Point(6, 23);
            this.tsSecundario.Name = "tsSecundario";
            this.tsSecundario.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsSecundario.Size = new System.Drawing.Size(1011, 25);
            this.tsSecundario.TabIndex = 94;
            this.tsSecundario.Text = "ToolStrip2";
            // 
            // tsbPrimero
            // 
            this.tsbPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrimero.Image = global::Presentacion.Properties.Resources._18;
            this.tsbPrimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrimero.Name = "tsbPrimero";
            this.tsbPrimero.Size = new System.Drawing.Size(23, 22);
            this.tsbPrimero.Click += new System.EventHandler(this.tsbPrimero_Click);
            // 
            // tsbAnterior
            // 
            this.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnterior.Image = global::Presentacion.Properties.Resources._16;
            this.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnterior.Name = "tsbAnterior";
            this.tsbAnterior.Size = new System.Drawing.Size(23, 22);
            this.tsbAnterior.Click += new System.EventHandler(this.tsbAnterior_Click);
            // 
            // tsbSiguiente
            // 
            this.tsbSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSiguiente.Image = global::Presentacion.Properties.Resources._17;
            this.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSiguiente.Name = "tsbSiguiente";
            this.tsbSiguiente.Size = new System.Drawing.Size(23, 22);
            this.tsbSiguiente.Click += new System.EventHandler(this.tsbSiguiente_Click);
            // 
            // tsbUltimo
            // 
            this.tsbUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUltimo.Image = global::Presentacion.Properties.Resources._19;
            this.tsbUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUltimo.Name = "tsbUltimo";
            this.tsbUltimo.Size = new System.Drawing.Size(23, 22);
            this.tsbUltimo.Click += new System.EventHandler(this.tsbUltimo_Click);
            // 
            // tsbActualizarTabla
            // 
            this.tsbActualizarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActualizarTabla.Image = global::Presentacion.Properties.Resources.arrow_refresh;
            this.tsbActualizarTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizarTabla.Name = "tsbActualizarTabla";
            this.tsbActualizarTabla.Size = new System.Drawing.Size(23, 22);
            this.tsbActualizarTabla.Text = "Actualiza Grilla";
            this.tsbActualizarTabla.Click += new System.EventHandler(this.tsbActualizarTabla_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tstBuscar
            // 
            this.tstBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstBuscar.Name = "tstBuscar";
            this.tstBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tstBuscar.Size = new System.Drawing.Size(150, 25);
            this.tstBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tstBuscar_KeyUp);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::Presentacion.Properties.Resources._16__Filter_;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(13, 22);
            this.lblPeriodo.Text = "x";
            this.lblPeriodo.Visible = false;
            this.lblPeriodo.TextChanged += new System.EventHandler(this.lblPeriodo_TextChanged);
            // 
            // lblDescripcionPeriodo
            // 
            this.lblDescripcionPeriodo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblDescripcionPeriodo.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescripcionPeriodo.Name = "lblDescripcionPeriodo";
            this.lblDescripcionPeriodo.Size = new System.Drawing.Size(16, 22);
            this.lblDescripcionPeriodo.Text = "...";
            // 
            // btnPeriodo
            // 
            this.btnPeriodo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPeriodo.Image = global::Presentacion.Properties.Resources._16__Hand_point_;
            this.btnPeriodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPeriodo.Name = "btnPeriodo";
            this.btnPeriodo.Size = new System.Drawing.Size(23, 22);
            this.btnPeriodo.Text = "Filtrar";
            this.btnPeriodo.Click += new System.EventHandler(this.btnPeriodo_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel2.Text = "Periodo :";
            // 
            // tsbImprimirNota
            // 
            this.tsbImprimirNota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImprimirNota.Image = global::Presentacion.Properties.Resources._16__Print_;
            this.tsbImprimirNota.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimirNota.Name = "tsbImprimirNota";
            this.tsbImprimirNota.Size = new System.Drawing.Size(23, 22);
            this.tsbImprimirNota.Text = "Imprimir Nota";
            this.tsbImprimirNota.Click += new System.EventHandler(this.tsbImprimirNota_Click);
            // 
            // DgvMovCab
            // 
            this.DgvMovCab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvMovCab.BackgroundColor = System.Drawing.Color.White;
            this.DgvMovCab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvMovCab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMovCab.GridColor = System.Drawing.Color.Silver;
            this.DgvMovCab.Location = new System.Drawing.Point(6, 64);
            this.DgvMovCab.Name = "DgvMovCab";
            this.DgvMovCab.Size = new System.Drawing.Size(1010, 276);
            this.DgvMovCab.TabIndex = 95;
            this.DgvMovCab.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMovCab_CellEnter);
            this.DgvMovCab.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvMovCab_ColumnHeaderMouseClick);
            // 
            // lblTituloCabe
            // 
            this.lblTituloCabe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloCabe.BackColor = System.Drawing.Color.DarkGray;
            this.lblTituloCabe.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCabe.ForeColor = System.Drawing.Color.White;
            this.lblTituloCabe.Location = new System.Drawing.Point(7, 48);
            this.lblTituloCabe.Name = "lblTituloCabe";
            this.lblTituloCabe.Size = new System.Drawing.Size(1008, 14);
            this.lblTituloCabe.TabIndex = 96;
            this.lblTituloCabe.Text = "...";
            this.lblTituloCabe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloDeta
            // 
            this.lblTituloDeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloDeta.BackColor = System.Drawing.Color.DarkGray;
            this.lblTituloDeta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDeta.ForeColor = System.Drawing.Color.White;
            this.lblTituloDeta.Location = new System.Drawing.Point(7, 342);
            this.lblTituloDeta.Name = "lblTituloDeta";
            this.lblTituloDeta.Size = new System.Drawing.Size(1008, 14);
            this.lblTituloDeta.TabIndex = 97;
            this.lblTituloDeta.Text = "...";
            this.lblTituloDeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvMovDet
            // 
            this.dgvMovDet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovDet.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovDet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMovDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovDet.GridColor = System.Drawing.Color.Silver;
            this.dgvMovDet.Location = new System.Drawing.Point(5, 357);
            this.dgvMovDet.Name = "dgvMovDet";
            this.dgvMovDet.Size = new System.Drawing.Size(1010, 67);
            this.dgvMovDet.TabIndex = 98;
            // 
            // tsbExportarExcel
            // 
            this.tsbExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportarExcel.Image = global::Presentacion.Properties.Resources._01_Excel;
            this.tsbExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportarExcel.Name = "tsbExportarExcel";
            this.tsbExportarExcel.Size = new System.Drawing.Size(23, 22);
            this.tsbExportarExcel.Text = "Exportar a Excel";
            this.tsbExportarExcel.Click += new System.EventHandler(this.tsbExportarExcel_Click);
            // 
            // wMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1023, 438);
            this.Controls.Add(this.dgvMovDet);
            this.Controls.Add(this.lblTituloDeta);
            this.Controls.Add(this.lblTituloCabe);
            this.Controls.Add(this.DgvMovCab);
            this.Controls.Add(this.tsSecundario);
            this.Name = "wMovimientos";
            this.Text = "Movimientos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wMovimientos_FormClosing);
            this.Controls.SetChildIndex(this.tsSecundario, 0);
            this.Controls.SetChildIndex(this.DgvMovCab, 0);
            this.Controls.SetChildIndex(this.lblTituloCabe, 0);
            this.Controls.SetChildIndex(this.lblTituloDeta, 0);
            this.Controls.SetChildIndex(this.dgvMovDet, 0);
            this.tsSecundario.ResumeLayout(false);
            this.tsSecundario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMovCab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ToolStrip tsSecundario;
        internal System.Windows.Forms.ToolStripButton tsbPrimero;
        internal System.Windows.Forms.ToolStripButton tsbAnterior;
        internal System.Windows.Forms.ToolStripButton tsbSiguiente;
        internal System.Windows.Forms.ToolStripButton tsbUltimo;
        internal System.Windows.Forms.ToolStripButton tsbActualizarTabla;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView DgvMovCab;
        private System.Windows.Forms.ToolStripTextBox tstBuscar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnPeriodo;
        public System.Windows.Forms.ToolStripLabel lblDescripcionPeriodo;
        internal System.Windows.Forms.ToolStripLabel lblPeriodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        internal System.Windows.Forms.ToolStripButton tsbImprimirNota;
        private System.Windows.Forms.Label lblTituloCabe;
        private System.Windows.Forms.Label lblTituloDeta;
        private System.Windows.Forms.DataGridView dgvMovDet;
        private System.Windows.Forms.ToolStripButton tsbExportarExcel;
    }
}
