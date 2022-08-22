namespace Presentacion.ProcesosCompras
{
    partial class wEliminarPagos
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
            this.tst2 = new System.Windows.Forms.ToolStrip();
            this.btnPrimero = new System.Windows.Forms.ToolStripButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.btnSiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnUltimo = new System.Windows.Forms.ToolStripButton();
            this.btnActualizarTabla = new System.Windows.Forms.ToolStripButton();
            this.tstBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dgvMovOrdCom = new System.Windows.Forms.DataGridView();
            this.dgvPag = new System.Windows.Forms.DataGridView();
            this.lblLetras = new System.Windows.Forms.Label();
            this.lblPagos = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tst2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovOrdCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPag)).BeginInit();
            this.SuspendLayout();
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
            this.ToolStripLabel1});
            this.tst2.Location = new System.Drawing.Point(6, 27);
            this.tst2.Name = "tst2";
            this.tst2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tst2.Size = new System.Drawing.Size(710, 29);
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
            // dgvMovOrdCom
            // 
            this.dgvMovOrdCom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovOrdCom.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovOrdCom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovOrdCom.GridColor = System.Drawing.Color.Silver;
            this.dgvMovOrdCom.Location = new System.Drawing.Point(8, 56);
            this.dgvMovOrdCom.Name = "dgvMovOrdCom";
            this.dgvMovOrdCom.Size = new System.Drawing.Size(708, 250);
            this.dgvMovOrdCom.TabIndex = 98;
            this.dgvMovOrdCom.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLet_CellEnter);
            this.dgvMovOrdCom.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCuo_ColumnHeaderMouseClick);
            // 
            // dgvPag
            // 
            this.dgvPag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPag.BackgroundColor = System.Drawing.Color.White;
            this.dgvPag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPag.GridColor = System.Drawing.Color.Silver;
            this.dgvPag.Location = new System.Drawing.Point(6, 331);
            this.dgvPag.Name = "dgvPag";
            this.dgvPag.Size = new System.Drawing.Size(710, 130);
            this.dgvPag.TabIndex = 238;
            // 
            // lblLetras
            // 
            this.lblLetras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLetras.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblLetras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLetras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetras.ForeColor = System.Drawing.Color.White;
            this.lblLetras.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLetras.Location = new System.Drawing.Point(0, 30);
            this.lblLetras.Name = "lblLetras";
            this.lblLetras.Size = new System.Drawing.Size(722, 26);
            this.lblLetras.TabIndex = 239;
            this.lblLetras.Text = "LETRAS PENDIENTES :";
            this.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblPagos.Location = new System.Drawing.Point(0, 309);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.Size = new System.Drawing.Size(722, 19);
            this.lblPagos.TabIndex = 237;
            this.lblPagos.Text = "LETRAS PENDIENTES :";
            this.lblPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(604, 468);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 25);
            this.btnSalir.TabIndex = 287;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(488, 468);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 25);
            this.btnEliminar.TabIndex = 286;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // wEliminarPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(722, 516);
            this.Controls.Add(this.dgvMovOrdCom);
            this.Controls.Add(this.tst2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblLetras);
            this.Controls.Add(this.dgvPag);
            this.Controls.Add(this.lblPagos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wEliminarPagos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Cobranzas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEliminarPagos_FormClosing);
            this.Controls.SetChildIndex(this.lblPagos, 0);
            this.Controls.SetChildIndex(this.dgvPag, 0);
            this.Controls.SetChildIndex(this.lblLetras, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.tst2, 0);
            this.Controls.SetChildIndex(this.dgvMovOrdCom, 0);
            this.tst2.ResumeLayout(false);
            this.tst2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovOrdCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStrip tst2;
        internal System.Windows.Forms.ToolStripButton btnPrimero;
        internal System.Windows.Forms.ToolStripButton btnAnterior;
        internal System.Windows.Forms.ToolStripButton btnSiguiente;
        internal System.Windows.Forms.ToolStripButton btnUltimo;
        internal System.Windows.Forms.ToolStripButton btnActualizarTabla;
        internal System.Windows.Forms.ToolStripTextBox tstBuscar;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
        internal System.Windows.Forms.DataGridView dgvMovOrdCom;
        internal System.Windows.Forms.DataGridView dgvPag;
        internal System.Windows.Forms.Label lblLetras;
        internal System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
    }
}