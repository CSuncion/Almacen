namespace Presentacion.ProcesosCompras
{
    partial class wPagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tst1 = new System.Windows.Forms.ToolStrip();
            this.btnPagos = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarPago = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.tst2 = new System.Windows.Forms.ToolStrip();
            this.btnPrimero = new System.Windows.Forms.ToolStripButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.btnSiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnUltimo = new System.Windows.Forms.ToolStripButton();
            this.btnActualizarTabla = new System.Windows.Forms.ToolStripButton();
            this.tstBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportarPago = new System.Windows.Forms.ToolStripButton();
            this.dgvCon = new System.Windows.Forms.DataGridView();
            this.dgvPago = new System.Windows.Forms.DataGridView();
            this.lblContratos = new System.Windows.Forms.Label();
            this.lblPagos = new System.Windows.Forms.Label();
            this.tst1.SuspendLayout();
            this.tst2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPago)).BeginInit();
            this.SuspendLayout();
            // 
            // tst1
            // 
            this.tst1.AutoSize = false;
            this.tst1.BackColor = System.Drawing.SystemColors.Control;
            this.tst1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tst1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tst1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPagos,
            this.btnEliminarPago,
            this.btnSalir});
            this.tst1.Location = new System.Drawing.Point(6, 27);
            this.tst1.Name = "tst1";
            this.tst1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tst1.ShowItemToolTips = false;
            this.tst1.Size = new System.Drawing.Size(972, 48);
            this.tst1.TabIndex = 96;
            this.tst1.Text = "ToolStrip2";
            // 
            // btnPagos
            // 
            this.btnPagos.Image = global::Presentacion.Properties.Resources._16__Plus_;
            this.btnPagos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnPagos.Size = new System.Drawing.Size(92, 45);
            this.btnPagos.Text = "&Adicionar Pago";
            this.btnPagos.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPagos.ToolTipText = "Pago Unica";
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // btnEliminarPago
            // 
            this.btnEliminarPago.Image = global::Presentacion.Properties.Resources._16__Refuse_;
            this.btnEliminarPago.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarPago.Name = "btnEliminarPago";
            this.btnEliminarPago.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.btnEliminarPago.Size = new System.Drawing.Size(86, 45);
            this.btnEliminarPago.Text = "&Eliminar Pago";
            this.btnEliminarPago.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnEliminarPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarPago.ToolTipText = "Pago Unica";
            this.btnEliminarPago.Click += new System.EventHandler(this.btnEliminarPago_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Presentacion.Properties.Resources.gnome_home;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(36, 45);
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tst2
            // 
            this.tst2.AutoSize = false;
            this.tst2.BackColor = System.Drawing.SystemColors.Control;
            this.tst2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tst2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrimero,
            this.btnAnterior,
            this.btnSiguiente,
            this.btnUltimo,
            this.btnActualizarTabla,
            this.tstBuscar,
            this.ToolStripLabel1,
            this.toolStripSeparator1,
            this.btnExportarPago});
            this.tst2.Location = new System.Drawing.Point(6, 75);
            this.tst2.Name = "tst2";
            this.tst2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tst2.Size = new System.Drawing.Size(972, 29);
            this.tst2.TabIndex = 97;
            this.tst2.Text = "ToolStrip2";
            // 
            // btnPrimero
            // 
            this.btnPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrimero.Image = global::Presentacion.Properties.Resources._18;
            this.btnPrimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(23, 26);
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnterior.Image = global::Presentacion.Properties.Resources._16;
            this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(23, 26);
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguiente.Image = global::Presentacion.Properties.Resources._17;
            this.btnSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(23, 26);
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUltimo.Image = global::Presentacion.Properties.Resources._19;
            this.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(23, 26);
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnActualizarTabla
            // 
            this.btnActualizarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizarTabla.Image = global::Presentacion.Properties.Resources._16__Refresh_;
            this.btnActualizarTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizarTabla.Name = "btnActualizarTabla";
            this.btnActualizarTabla.Size = new System.Drawing.Size(23, 26);
            this.btnActualizarTabla.Text = "Actualiza Grilla";
            this.btnActualizarTabla.Click += new System.EventHandler(this.btnActualizarTabla_Click);
            // 
            // tstBuscar
            // 
            this.tstBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstBuscar.Name = "tstBuscar";
            this.tstBuscar.Size = new System.Drawing.Size(150, 29);
            this.tstBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tstBuscar_KeyUp);
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(10, 26);
            this.ToolStripLabel1.Text = " ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btnExportarPago
            // 
            this.btnExportarPago.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExportarPago.Image = global::Presentacion.Properties.Resources._01_Excel;
            this.btnExportarPago.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportarPago.Name = "btnExportarPago";
            this.btnExportarPago.Size = new System.Drawing.Size(23, 26);
            this.btnExportarPago.Text = "Exportar Pagos De Contrato";
            this.btnExportarPago.Click += new System.EventHandler(this.btnExportarPago_Click);
            // 
            // dgvCon
            // 
            this.dgvCon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCon.BackgroundColor = System.Drawing.Color.White;
            this.dgvCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCon.GridColor = System.Drawing.Color.Silver;
            this.dgvCon.Location = new System.Drawing.Point(6, 129);
            this.dgvCon.Name = "dgvCon";
            this.dgvCon.Size = new System.Drawing.Size(972, 243);
            this.dgvCon.TabIndex = 98;
            this.dgvCon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCon_CellDoubleClick);
            this.dgvCon.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCon_CellEnter);
            this.dgvCon.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCon_ColumnHeaderMouseClick);
            // 
            // dgvPago
            // 
            this.dgvPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPago.BackgroundColor = System.Drawing.Color.White;
            this.dgvPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPago.GridColor = System.Drawing.Color.Silver;
            this.dgvPago.Location = new System.Drawing.Point(6, 416);
            this.dgvPago.Name = "dgvPago";
            this.dgvPago.Size = new System.Drawing.Size(972, 95);
            this.dgvPago.TabIndex = 238;
            // 
            // lblContratos
            // 
            this.lblContratos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContratos.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblContratos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblContratos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContratos.ForeColor = System.Drawing.Color.White;
            this.lblContratos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblContratos.Location = new System.Drawing.Point(5, 107);
            this.lblContratos.Name = "lblContratos";
            this.lblContratos.Size = new System.Drawing.Size(974, 19);
            this.lblContratos.TabIndex = 239;
            this.lblContratos.Text = "LETRAS PENDIENTES :";
            this.lblContratos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPagos
            // 
            this.lblPagos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPagos.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblPagos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagos.ForeColor = System.Drawing.Color.White;
            this.lblPagos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPagos.Location = new System.Drawing.Point(4, 393);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.Size = new System.Drawing.Size(974, 19);
            this.lblPagos.TabIndex = 237;
            this.lblPagos.Text = "LETRAS PENDIENTES :";
            this.lblPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(984, 523);
            this.Controls.Add(this.lblPagos);
            this.Controls.Add(this.dgvCon);
            this.Controls.Add(this.tst2);
            this.Controls.Add(this.tst1);
            this.Controls.Add(this.lblContratos);
            this.Controls.Add(this.dgvPago);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wPagos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wPagos_FormClosing);
            this.Controls.SetChildIndex(this.dgvPago, 0);
            this.Controls.SetChildIndex(this.lblContratos, 0);
            this.Controls.SetChildIndex(this.tst1, 0);
            this.Controls.SetChildIndex(this.tst2, 0);
            this.Controls.SetChildIndex(this.dgvCon, 0);
            this.Controls.SetChildIndex(this.lblPagos, 0);
            this.tst1.ResumeLayout(false);
            this.tst1.PerformLayout();
            this.tst2.ResumeLayout(false);
            this.tst2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStrip tst1;
        public System.Windows.Forms.ToolStripButton btnPagos;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStrip tst2;
        internal System.Windows.Forms.ToolStripButton btnPrimero;
        internal System.Windows.Forms.ToolStripButton btnAnterior;
        internal System.Windows.Forms.ToolStripButton btnSiguiente;
        internal System.Windows.Forms.ToolStripButton btnUltimo;
        internal System.Windows.Forms.ToolStripButton btnActualizarTabla;
        internal System.Windows.Forms.ToolStripTextBox tstBuscar;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
        internal System.Windows.Forms.DataGridView dgvCon;
        internal System.Windows.Forms.DataGridView dgvPago;
        internal System.Windows.Forms.Label lblContratos;
        internal System.Windows.Forms.Label lblPagos;
        public System.Windows.Forms.ToolStripButton btnEliminarPago;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExportarPago;
    }
}