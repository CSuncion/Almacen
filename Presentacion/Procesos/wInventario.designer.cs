namespace Presentacion.Procesos
{
    partial class wInventario
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
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbAdicionar = new System.Windows.Forms.ToolStripButton();
            this.tsbModificar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbVisualizar = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.sst1 = new System.Windows.Forms.StatusStrip();
            this.tssEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSecundario = new System.Windows.Forms.ToolStrip();
            this.tsbPrimero = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbSiguiente = new System.Windows.Forms.ToolStripButton();
            this.tsbUltimo = new System.Windows.Forms.ToolStripButton();
            this.tsbActualizarTabla = new System.Windows.Forms.ToolStripButton();
            this.tstBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbActualizarToma = new System.Windows.Forms.ToolStripButton();
            this.tsbGeneraMovimientosAjuste = new System.Windows.Forms.ToolStripButton();
            this.tsbTerminarProceso = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsImpresiones = new System.Windows.Forms.ToolStripDropDownButton();
            this.IteImpParTomInv = new System.Windows.Forms.ToolStripMenuItem();
            this.IteImpTomInv = new System.Windows.Forms.ToolStripMenuItem();
            this.IteImpDifSto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddbDoc = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiCambiarAProcesando = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEliminarMvimientosAjuste = new System.Windows.Forms.ToolStripMenuItem();
            this.DgvInv = new System.Windows.Forms.DataGridView();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImpAjusteIngreso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImpAjusteSalida = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrincipal.SuspendLayout();
            this.sst1.SuspendLayout();
            this.tsSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInv)).BeginInit();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdicionar,
            this.tsbModificar,
            this.tsbEliminar,
            this.tsbVisualizar,
            this.tsbSalir});
            this.tsPrincipal.Location = new System.Drawing.Point(6, 23);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPrincipal.Size = new System.Drawing.Size(1023, 48);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 53;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // tsbAdicionar
            // 
            this.tsbAdicionar.Image = global::Presentacion.Properties.Resources._16__Plus_;
            this.tsbAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdicionar.Name = "tsbAdicionar";
            this.tsbAdicionar.Size = new System.Drawing.Size(63, 45);
            this.tsbAdicionar.Text = "Adicionar";
            this.tsbAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdicionar.Click += new System.EventHandler(this.tsbAdicionar_Click);
            // 
            // tsbModificar
            // 
            this.tsbModificar.Image = global::Presentacion.Properties.Resources._16__Pencil_tool_;
            this.tsbModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificar.Name = "tsbModificar";
            this.tsbModificar.Size = new System.Drawing.Size(61, 45);
            this.tsbModificar.Text = "Modificar";
            this.tsbModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbModificar.Click += new System.EventHandler(this.tsbModificar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.Image = global::Presentacion.Properties.Resources._16__Refuse_;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(57, 45);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbVisualizar
            // 
            this.tsbVisualizar.Image = global::Presentacion.Properties.Resources.Game_11_32x32_32;
            this.tsbVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVisualizar.Name = "tsbVisualizar";
            this.tsbVisualizar.Size = new System.Drawing.Size(66, 45);
            this.tsbVisualizar.Text = "Visualizar";
            this.tsbVisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbVisualizar.Click += new System.EventHandler(this.tsbVisualizar_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = global::Presentacion.Properties.Resources.gnome_home;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(36, 45);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // sst1
            // 
            this.sst1.BackColor = System.Drawing.SystemColors.Control;
            this.sst1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssEstado});
            this.sst1.Location = new System.Drawing.Point(6, 482);
            this.sst1.Name = "sst1";
            this.sst1.Size = new System.Drawing.Size(1023, 22);
            this.sst1.TabIndex = 54;
            this.sst1.Text = "statusStrip1";
            // 
            // tssEstado
            // 
            this.tssEstado.BackColor = System.Drawing.SystemColors.Control;
            this.tssEstado.Name = "tssEstado";
            this.tssEstado.Size = new System.Drawing.Size(10, 17);
            this.tssEstado.Text = ".";
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
            this.tstBuscar,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.tsbActualizarToma,
            this.tsbGeneraMovimientosAjuste,
            this.tsbTerminarProceso,
            this.toolStripSeparator1,
            this.tsImpresiones,
            this.toolStripSeparator4,
            this.tsddbDoc});
            this.tsSecundario.Location = new System.Drawing.Point(6, 71);
            this.tsSecundario.Name = "tsSecundario";
            this.tsSecundario.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsSecundario.Size = new System.Drawing.Size(1023, 25);
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
            this.toolStripLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::Presentacion.Properties.Resources._16__Filter_;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // tsbActualizarToma
            // 
            this.tsbActualizarToma.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActualizarToma.Image = global::Presentacion.Properties.Resources._106;
            this.tsbActualizarToma.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizarToma.Name = "tsbActualizarToma";
            this.tsbActualizarToma.Size = new System.Drawing.Size(23, 22);
            this.tsbActualizarToma.Text = "Actualizar Cantidad";
            this.tsbActualizarToma.Click += new System.EventHandler(this.tsbActualizarToma_Click);
            // 
            // tsbGeneraMovimientosAjuste
            // 
            this.tsbGeneraMovimientosAjuste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGeneraMovimientosAjuste.Image = global::Presentacion.Properties.Resources.cog;
            this.tsbGeneraMovimientosAjuste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGeneraMovimientosAjuste.Name = "tsbGeneraMovimientosAjuste";
            this.tsbGeneraMovimientosAjuste.Size = new System.Drawing.Size(23, 22);
            this.tsbGeneraMovimientosAjuste.Text = "Generar Movimientos Ajuste";
            this.tsbGeneraMovimientosAjuste.Click += new System.EventHandler(this.tsbGeneraMovimientosAjuste_Click);
            // 
            // tsbTerminarProceso
            // 
            this.tsbTerminarProceso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTerminarProceso.Image = global::Presentacion.Properties.Resources.accept;
            this.tsbTerminarProceso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTerminarProceso.Name = "tsbTerminarProceso";
            this.tsbTerminarProceso.Size = new System.Drawing.Size(23, 22);
            this.tsbTerminarProceso.Text = "Terminar proceso";
            this.tsbTerminarProceso.Click += new System.EventHandler(this.tsbTerminarProceso_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // tsImpresiones
            // 
            this.tsImpresiones.AutoToolTip = false;
            this.tsImpresiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IteImpParTomInv,
            this.IteImpTomInv,
            this.IteImpDifSto,
            this.toolStripSeparator3,
            this.tsmiImpAjusteIngreso,
            this.tsmiImpAjusteSalida});
            this.tsImpresiones.Image = global::Presentacion.Properties.Resources._16__Print_;
            this.tsImpresiones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImpresiones.Name = "tsImpresiones";
            this.tsImpresiones.Size = new System.Drawing.Size(100, 22);
            this.tsImpresiones.Text = "Impresiones";
            // 
            // IteImpParTomInv
            // 
            this.IteImpParTomInv.Name = "IteImpParTomInv";
            this.IteImpParTomInv.Size = new System.Drawing.Size(225, 22);
            this.IteImpParTomInv.Text = "Lista Para Toma Inventario";
            this.IteImpParTomInv.Click += new System.EventHandler(this.IteImpParTomInv_Click);
            // 
            // IteImpTomInv
            // 
            this.IteImpTomInv.Name = "IteImpTomInv";
            this.IteImpTomInv.Size = new System.Drawing.Size(225, 22);
            this.IteImpTomInv.Text = "Lista de Toma Inventario";
            this.IteImpTomInv.Click += new System.EventHandler(this.IteImpTomInv_Click);
            // 
            // IteImpDifSto
            // 
            this.IteImpDifSto.Name = "IteImpDifSto";
            this.IteImpDifSto.Size = new System.Drawing.Size(225, 22);
            this.IteImpDifSto.Text = "Lista Diferencia Stock";
            this.IteImpDifSto.Click += new System.EventHandler(this.IteImpDifSto_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 20);
            // 
            // tsddbDoc
            // 
            this.tsddbDoc.AutoToolTip = false;
            this.tsddbDoc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCambiarAProcesando,
            this.tsmiEliminarMvimientosAjuste});
            this.tsddbDoc.Image = global::Presentacion.Properties.Resources.undo16;
            this.tsddbDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbDoc.Name = "tsddbDoc";
            this.tsddbDoc.Size = new System.Drawing.Size(72, 22);
            this.tsddbDoc.Text = "Doctor";
            // 
            // tsmiCambiarAProcesando
            // 
            this.tsmiCambiarAProcesando.Name = "tsmiCambiarAProcesando";
            this.tsmiCambiarAProcesando.Size = new System.Drawing.Size(231, 22);
            this.tsmiCambiarAProcesando.Text = "Cambiar a Procesando";
            this.tsmiCambiarAProcesando.Click += new System.EventHandler(this.tsmiCambiarAProcesando_Click);
            // 
            // tsmiEliminarMvimientosAjuste
            // 
            this.tsmiEliminarMvimientosAjuste.Name = "tsmiEliminarMvimientosAjuste";
            this.tsmiEliminarMvimientosAjuste.Size = new System.Drawing.Size(231, 22);
            this.tsmiEliminarMvimientosAjuste.Text = "Eliminar Movimientos Ajustes";
            this.tsmiEliminarMvimientosAjuste.Click += new System.EventHandler(this.tsmiEliminarMvimientosAjuste_Click);
            // 
            // DgvInv
            // 
            this.DgvInv.BackgroundColor = System.Drawing.Color.White;
            this.DgvInv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvInv.GridColor = System.Drawing.Color.Silver;
            this.DgvInv.Location = new System.Drawing.Point(6, 96);
            this.DgvInv.Name = "DgvInv";
            this.DgvInv.Size = new System.Drawing.Size(1023, 386);
            this.DgvInv.TabIndex = 95;
            this.DgvInv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInv_CellEnter);
            this.DgvInv.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvInv_CellMouseDoubleClick);
            this.DgvInv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvInv_ColumnHeaderMouseClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(222, 6);
            // 
            // tsmiImpAjusteIngreso
            // 
            this.tsmiImpAjusteIngreso.Name = "tsmiImpAjusteIngreso";
            this.tsmiImpAjusteIngreso.Size = new System.Drawing.Size(225, 22);
            this.tsmiImpAjusteIngreso.Text = "Ajuste Ingreso(Nota Ingreso)";
            this.tsmiImpAjusteIngreso.Click += new System.EventHandler(this.tsmiImpAjusteIngreso_Click);
            // 
            // tsmiImpAjusteSalida
            // 
            this.tsmiImpAjusteSalida.Name = "tsmiImpAjusteSalida";
            this.tsmiImpAjusteSalida.Size = new System.Drawing.Size(225, 22);
            this.tsmiImpAjusteSalida.Text = "Ajuste Salida(Nota Salida)";
            this.tsmiImpAjusteSalida.Click += new System.EventHandler(this.tsmiImpAjusteSalida_Click);
            // 
            // wInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1035, 510);
            this.Controls.Add(this.DgvInv);
            this.Controls.Add(this.tsSecundario);
            this.Controls.Add(this.sst1);
            this.Controls.Add(this.tsPrincipal);
            this.Name = "wInventario";
            this.Text = "Inventarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wInventario_FormClosing);
            this.Controls.SetChildIndex(this.tsPrincipal, 0);
            this.Controls.SetChildIndex(this.sst1, 0);
            this.Controls.SetChildIndex(this.tsSecundario, 0);
            this.Controls.SetChildIndex(this.DgvInv, 0);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.sst1.ResumeLayout(false);
            this.sst1.PerformLayout();
            this.tsSecundario.ResumeLayout(false);
            this.tsSecundario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsbAdicionar;
        internal System.Windows.Forms.ToolStrip tsSecundario;
        internal System.Windows.Forms.ToolStripButton tsbPrimero;
        internal System.Windows.Forms.ToolStripButton tsbAnterior;
        internal System.Windows.Forms.ToolStripButton tsbSiguiente;
        internal System.Windows.Forms.ToolStripButton tsbUltimo;
        internal System.Windows.Forms.ToolStripButton tsbActualizarTabla;
        private System.Windows.Forms.ToolStripButton tsbModificar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbVisualizar;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.ToolStripStatusLabel tssEstado;
        internal System.Windows.Forms.StatusStrip sst1;
        private System.Windows.Forms.ToolStripTextBox tstBuscar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton tsImpresiones;
        internal System.Windows.Forms.DataGridView DgvInv;
        internal System.Windows.Forms.ToolStripButton tsbActualizarToma;
        internal System.Windows.Forms.ToolStripButton tsbGeneraMovimientosAjuste;
        internal System.Windows.Forms.ToolStripMenuItem IteImpDifSto;
        internal System.Windows.Forms.ToolStripMenuItem IteImpParTomInv;
        internal System.Windows.Forms.ToolStripMenuItem IteImpTomInv;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton tsddbDoc;
        private System.Windows.Forms.ToolStripMenuItem tsmiCambiarAProcesando;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminarMvimientosAjuste;
        internal System.Windows.Forms.ToolStripButton tsbTerminarProceso;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiImpAjusteIngreso;
        private System.Windows.Forms.ToolStripMenuItem tsmiImpAjusteSalida;
    }
}
