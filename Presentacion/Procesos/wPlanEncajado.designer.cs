namespace Presentacion.Procesos
{
    partial class wPlanEncajado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wPlanEncajado));
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tslCodFil = new System.Windows.Forms.ToolStripLabel();
            this.tslNomFil = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnFiltro = new System.Windows.Forms.ToolStripButton();
            this.tsbPlaEncDetLib = new System.Windows.Forms.ToolStripButton();
            this.tsbPlaEnc = new System.Windows.Forms.ToolStripButton();
            this.tsbPlaCom = new System.Windows.Forms.ToolStripButton();
            this.tsbSalidaFaseEmpaquetado = new System.Windows.Forms.ToolStripButton();
            this.tsbSalidaUniEmp = new System.Windows.Forms.ToolStripButton();
            this.tsbSalidaUniEmpObs = new System.Windows.Forms.ToolStripButton();
            this.tsbCantidadReal = new System.Windows.Forms.ToolStripButton();
            this.tsbSegundaLiberacion = new System.Windows.Forms.ToolStripButton();
            this.tsbSalidaUniEmpCua = new System.Windows.Forms.ToolStripButton();
            this.tsbIngresoMercaderia = new System.Windows.Forms.ToolStripButton();
            this.tsbAdicionales = new System.Windows.Forms.ToolStripButton();
            this.tsbTerminarProceso = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.DgvProCab = new System.Windows.Forms.DataGridView();
            this.tsPrincipal.SuspendLayout();
            this.sst1.SuspendLayout();
            this.tsSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProCab)).BeginInit();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdicionar,
            this.tsbModificar,
            this.tsbEliminar,
            this.tsbVisualizar,
            this.tsbSalir});
            this.tsPrincipal.Location = new System.Drawing.Point(6, 23);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPrincipal.Size = new System.Drawing.Size(1105, 62);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 53;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // tsbAdicionar
            // 
            this.tsbAdicionar.Image = global::Presentacion.Properties.Resources._16__Plus_;
            this.tsbAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdicionar.Name = "tsbAdicionar";
            this.tsbAdicionar.Size = new System.Drawing.Size(71, 59);
            this.tsbAdicionar.Text = "Adicionar";
            this.tsbAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdicionar.Click += new System.EventHandler(this.tsbAdicionar_Click);
            // 
            // tsbModificar
            // 
            this.tsbModificar.Image = global::Presentacion.Properties.Resources._16__Pencil_tool_;
            this.tsbModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificar.Name = "tsbModificar";
            this.tsbModificar.Size = new System.Drawing.Size(70, 59);
            this.tsbModificar.Text = "Modificar";
            this.tsbModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbModificar.Click += new System.EventHandler(this.tsbModificar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.Image = global::Presentacion.Properties.Resources._16__Refuse_;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(63, 59);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbVisualizar
            // 
            this.tsbVisualizar.Image = global::Presentacion.Properties.Resources.Game_11_32x32_32;
            this.tsbVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVisualizar.Name = "tsbVisualizar";
            this.tsbVisualizar.Size = new System.Drawing.Size(72, 59);
            this.tsbVisualizar.Text = "Visualizar";
            this.tsbVisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbVisualizar.Click += new System.EventHandler(this.tsbVisualizar_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = global::Presentacion.Properties.Resources.gnome_home;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(39, 59);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // sst1
            // 
            this.sst1.BackColor = System.Drawing.SystemColors.Control;
            this.sst1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sst1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssEstado});
            this.sst1.Location = new System.Drawing.Point(6, 585);
            this.sst1.Name = "sst1";
            this.sst1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sst1.Size = new System.Drawing.Size(1105, 25);
            this.sst1.TabIndex = 54;
            this.sst1.Text = "statusStrip1";
            // 
            // tssEstado
            // 
            this.tssEstado.BackColor = System.Drawing.SystemColors.Control;
            this.tssEstado.Name = "tssEstado";
            this.tssEstado.Size = new System.Drawing.Size(12, 20);
            this.tssEstado.Text = ".";
            // 
            // tsSecundario
            // 
            this.tsSecundario.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSecundario.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsSecundario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrimero,
            this.tsbAnterior,
            this.tsbSiguiente,
            this.tsbUltimo,
            this.tsbActualizarTabla,
            this.toolStripSeparator1,
            this.tstBuscar,
            this.toolStripLabel1,
            this.tslCodFil,
            this.tslNomFil,
            this.toolStripLabel2,
            this.btnFiltro,
            this.tsbPlaEncDetLib,
            this.tsbPlaEnc,
            this.tsbPlaCom,
            this.tsbSalidaFaseEmpaquetado,
            this.tsbSalidaUniEmp,
            this.tsbSalidaUniEmpObs,
            this.tsbCantidadReal,
            this.tsbSegundaLiberacion,
            this.tsbSalidaUniEmpCua,
            this.tsbIngresoMercaderia,
            this.tsbAdicionales,
            this.tsbTerminarProceso,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.tsSecundario.Location = new System.Drawing.Point(6, 85);
            this.tsSecundario.Name = "tsSecundario";
            this.tsSecundario.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsSecundario.Size = new System.Drawing.Size(1105, 27);
            this.tsSecundario.Stretch = true;
            this.tsSecundario.TabIndex = 94;
            this.tsSecundario.Text = "ToolStrip2";
            // 
            // tsbPrimero
            // 
            this.tsbPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrimero.Image = global::Presentacion.Properties.Resources._18;
            this.tsbPrimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrimero.Name = "tsbPrimero";
            this.tsbPrimero.Size = new System.Drawing.Size(24, 24);
            this.tsbPrimero.Click += new System.EventHandler(this.tsbPrimero_Click);
            // 
            // tsbAnterior
            // 
            this.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnterior.Image = global::Presentacion.Properties.Resources._16;
            this.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnterior.Name = "tsbAnterior";
            this.tsbAnterior.Size = new System.Drawing.Size(24, 24);
            this.tsbAnterior.Click += new System.EventHandler(this.tsbAnterior_Click);
            // 
            // tsbSiguiente
            // 
            this.tsbSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSiguiente.Image = global::Presentacion.Properties.Resources._17;
            this.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSiguiente.Name = "tsbSiguiente";
            this.tsbSiguiente.Size = new System.Drawing.Size(24, 24);
            this.tsbSiguiente.Click += new System.EventHandler(this.tsbSiguiente_Click);
            // 
            // tsbUltimo
            // 
            this.tsbUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUltimo.Image = global::Presentacion.Properties.Resources._19;
            this.tsbUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUltimo.Name = "tsbUltimo";
            this.tsbUltimo.Size = new System.Drawing.Size(24, 24);
            this.tsbUltimo.Click += new System.EventHandler(this.tsbUltimo_Click);
            // 
            // tsbActualizarTabla
            // 
            this.tsbActualizarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbActualizarTabla.Image = global::Presentacion.Properties.Resources.arrow_refresh;
            this.tsbActualizarTabla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActualizarTabla.Name = "tsbActualizarTabla";
            this.tsbActualizarTabla.Size = new System.Drawing.Size(24, 24);
            this.tsbActualizarTabla.Text = "Actualiza Grilla";
            this.tsbActualizarTabla.Click += new System.EventHandler(this.tsbActualizarTabla_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tstBuscar
            // 
            this.tstBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tstBuscar.Name = "tstBuscar";
            this.tstBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tstBuscar.Size = new System.Drawing.Size(199, 27);
            this.tstBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tstBuscar_KeyUp);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::Presentacion.Properties.Resources._16__Filter_;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 24);
            // 
            // tslCodFil
            // 
            this.tslCodFil.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslCodFil.Name = "tslCodFil";
            this.tslCodFil.Size = new System.Drawing.Size(16, 24);
            this.tslCodFil.Text = "x";
            this.tslCodFil.Visible = false;
            // 
            // tslNomFil
            // 
            this.tslNomFil.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslNomFil.BackColor = System.Drawing.SystemColors.Control;
            this.tslNomFil.Name = "tslNomFil";
            this.tslNomFil.Size = new System.Drawing.Size(18, 24);
            this.tslNomFil.Text = "...";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(61, 24);
            this.toolStripLabel2.Text = "Estado :";
            // 
            // btnFiltro
            // 
            this.btnFiltro.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFiltro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFiltro.Image = global::Presentacion.Properties.Resources._16__Hand_point_;
            this.btnFiltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(24, 24);
            this.btnFiltro.Text = "Filtrar";
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // tsbPlaEncDetLib
            // 
            this.tsbPlaEncDetLib.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPlaEncDetLib.Image = global::Presentacion.Properties.Resources._01_Excel;
            this.tsbPlaEncDetLib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlaEncDetLib.Name = "tsbPlaEncDetLib";
            this.tsbPlaEncDetLib.Size = new System.Drawing.Size(24, 24);
            this.tsbPlaEncDetLib.Text = "Planificacion encajado detallado liberación";
            this.tsbPlaEncDetLib.Visible = false;
            this.tsbPlaEncDetLib.Click += new System.EventHandler(this.tsbPlaEncDetLib_Click);
            // 
            // tsbPlaEnc
            // 
            this.tsbPlaEnc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPlaEnc.Image = global::Presentacion.Properties.Resources._01_Excel;
            this.tsbPlaEnc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlaEnc.Name = "tsbPlaEnc";
            this.tsbPlaEnc.Size = new System.Drawing.Size(24, 24);
            this.tsbPlaEnc.Text = "Planificacion Encajado";
            this.tsbPlaEnc.Visible = false;
            this.tsbPlaEnc.Click += new System.EventHandler(this.tsbPlaEnc_Click);
            // 
            // tsbPlaCom
            // 
            this.tsbPlaCom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPlaCom.Image = global::Presentacion.Properties.Resources._01_Excel;
            this.tsbPlaCom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlaCom.Name = "tsbPlaCom";
            this.tsbPlaCom.Size = new System.Drawing.Size(24, 24);
            this.tsbPlaCom.Text = "Plan de abastecimiento de Packing";
            this.tsbPlaCom.Click += new System.EventHandler(this.tsbPlaCom_Click);
            // 
            // tsbSalidaFaseEmpaquetado
            // 
            this.tsbSalidaFaseEmpaquetado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalidaFaseEmpaquetado.Image = global::Presentacion.Properties.Resources.door_out;
            this.tsbSalidaFaseEmpaquetado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalidaFaseEmpaquetado.Name = "tsbSalidaFaseEmpaquetado";
            this.tsbSalidaFaseEmpaquetado.Size = new System.Drawing.Size(24, 24);
            this.tsbSalidaFaseEmpaquetado.Text = "Salida de embalajes y etiquetas";
            this.tsbSalidaFaseEmpaquetado.Click += new System.EventHandler(this.tsbSalidaFaseEmpaquetado_Click);
            // 
            // tsbSalidaUniEmp
            // 
            this.tsbSalidaUniEmp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalidaUniEmp.Image = global::Presentacion.Properties.Resources.door_out;
            this.tsbSalidaUniEmp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalidaUniEmp.Name = "tsbSalidaUniEmp";
            this.tsbSalidaUniEmp.Size = new System.Drawing.Size(24, 24);
            this.tsbSalidaUniEmp.Text = "Salida de unidades del almacén de packing";
            this.tsbSalidaUniEmp.Click += new System.EventHandler(this.tsbSalidaUniEmp_Click);
            // 
            // tsbSalidaUniEmpObs
            // 
            this.tsbSalidaUniEmpObs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalidaUniEmpObs.Image = global::Presentacion.Properties.Resources.door_out;
            this.tsbSalidaUniEmpObs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalidaUniEmpObs.Name = "tsbSalidaUniEmpObs";
            this.tsbSalidaUniEmpObs.Size = new System.Drawing.Size(24, 24);
            this.tsbSalidaUniEmpObs.Text = "Salidas Unidades Observados Para Empaquetar";
            this.tsbSalidaUniEmpObs.Click += new System.EventHandler(this.tsbSalidaUniEmpObs_Click);
            // 
            // tsbCantidadReal
            // 
            this.tsbCantidadReal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCantidadReal.Image = global::Presentacion.Properties.Resources._16__Card_update_;
            this.tsbCantidadReal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCantidadReal.Name = "tsbCantidadReal";
            this.tsbCantidadReal.Size = new System.Drawing.Size(24, 24);
            this.tsbCantidadReal.Text = "Distribucion";
            this.tsbCantidadReal.Click += new System.EventHandler(this.tsbCantidadReal_Click);
            // 
            // tsbSegundaLiberacion
            // 
            this.tsbSegundaLiberacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSegundaLiberacion.Image = global::Presentacion.Properties.Resources.Media_12_32x32_32;
            this.tsbSegundaLiberacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSegundaLiberacion.Name = "tsbSegundaLiberacion";
            this.tsbSegundaLiberacion.Size = new System.Drawing.Size(24, 24);
            this.tsbSegundaLiberacion.Text = "Segunda Liberacion";
            this.tsbSegundaLiberacion.Click += new System.EventHandler(this.tsbSegundaLiberacion_Click);
            // 
            // tsbSalidaUniEmpCua
            // 
            this.tsbSalidaUniEmpCua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalidaUniEmpCua.Image = global::Presentacion.Properties.Resources.door_out;
            this.tsbSalidaUniEmpCua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalidaUniEmpCua.Name = "tsbSalidaUniEmpCua";
            this.tsbSalidaUniEmpCua.Size = new System.Drawing.Size(24, 24);
            this.tsbSalidaUniEmpCua.Text = "Salidas Unidades Cuarentena Para Empaquetar";
            this.tsbSalidaUniEmpCua.Visible = false;
            this.tsbSalidaUniEmpCua.Click += new System.EventHandler(this.tsbSalidaUniEmpCua_Click);
            // 
            // tsbIngresoMercaderia
            // 
            this.tsbIngresoMercaderia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbIngresoMercaderia.Image = global::Presentacion.Properties.Resources.door_in;
            this.tsbIngresoMercaderia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIngresoMercaderia.Name = "tsbIngresoMercaderia";
            this.tsbIngresoMercaderia.Size = new System.Drawing.Size(24, 24);
            this.tsbIngresoMercaderia.Text = "Ingreso Productos Terminados";
            this.tsbIngresoMercaderia.Click += new System.EventHandler(this.tsbIngresoMercaderia_Click);
            // 
            // tsbAdicionales
            // 
            this.tsbAdicionales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdicionales.Image = global::Presentacion.Properties.Resources.door_out;
            this.tsbAdicionales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdicionales.Name = "tsbAdicionales";
            this.tsbAdicionales.Size = new System.Drawing.Size(24, 24);
            this.tsbAdicionales.Text = "Adicionales/Devoluciones";
            this.tsbAdicionales.Click += new System.EventHandler(this.tsbAdicionales_Click);
            // 
            // tsbTerminarProceso
            // 
            this.tsbTerminarProceso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTerminarProceso.Image = global::Presentacion.Properties.Resources.accept;
            this.tsbTerminarProceso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTerminarProceso.Name = "tsbTerminarProceso";
            this.tsbTerminarProceso.Size = new System.Drawing.Size(24, 24);
            this.tsbTerminarProceso.Text = "Terminar proceso";
            this.tsbTerminarProceso.Click += new System.EventHandler(this.tsbTerminarProceso_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            // 
            // DgvProCab
            // 
            this.DgvProCab.BackgroundColor = System.Drawing.Color.White;
            this.DgvProCab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvProCab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProCab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvProCab.GridColor = System.Drawing.Color.Silver;
            this.DgvProCab.Location = new System.Drawing.Point(6, 112);
            this.DgvProCab.Margin = new System.Windows.Forms.Padding(4);
            this.DgvProCab.Name = "DgvProCab";
            this.DgvProCab.Size = new System.Drawing.Size(1105, 473);
            this.DgvProCab.TabIndex = 95;
            this.DgvProCab.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProCab_CellEnter);
            this.DgvProCab.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvProCab_CellMouseDoubleClick);
            this.DgvProCab.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvProCab_ColumnHeaderMouseClick);
            // 
            // wPlanEncajado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1117, 616);
            this.Controls.Add(this.DgvProCab);
            this.Controls.Add(this.tsSecundario);
            this.Controls.Add(this.sst1);
            this.Controls.Add(this.tsPrincipal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "wPlanEncajado";
            this.Text = "Plan Packing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wPlanEncajado_FormClosing);
            this.Controls.SetChildIndex(this.tsPrincipal, 0);
            this.Controls.SetChildIndex(this.sst1, 0);
            this.Controls.SetChildIndex(this.tsSecundario, 0);
            this.Controls.SetChildIndex(this.DgvProCab, 0);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.sst1.ResumeLayout(false);
            this.sst1.PerformLayout();
            this.tsSecundario.ResumeLayout(false);
            this.tsSecundario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProCab)).EndInit();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tssEstado;
        internal System.Windows.Forms.StatusStrip sst1;
        private System.Windows.Forms.ToolStripTextBox tstBuscar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnFiltro;
        public System.Windows.Forms.ToolStripLabel tslNomFil;
        internal System.Windows.Forms.ToolStripLabel tslCodFil;
        internal System.Windows.Forms.ToolStripButton tsbPlaCom;
        internal System.Windows.Forms.ToolStripButton tsbSalidaFaseEmpaquetado;
        internal System.Windows.Forms.DataGridView DgvProCab;
        internal System.Windows.Forms.ToolStripButton tsbSalidaUniEmp;
        internal System.Windows.Forms.ToolStripButton tsbIngresoMercaderia;
        internal System.Windows.Forms.ToolStripButton tsbTerminarProceso;
        internal System.Windows.Forms.ToolStripButton tsbPlaEnc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton tsbCantidadReal;
        internal System.Windows.Forms.ToolStripButton tsbPlaEncDetLib;
        internal System.Windows.Forms.ToolStripButton tsbSalidaUniEmpObs;
        internal System.Windows.Forms.ToolStripButton tsbAdicionales;
        internal System.Windows.Forms.ToolStripButton tsbSalidaUniEmpCua;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        internal System.Windows.Forms.ToolStripButton tsbSegundaLiberacion;
    }
}
