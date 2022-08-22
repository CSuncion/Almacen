namespace Presentacion.Procesos
{
    partial class wEditIngreso
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCodTipOpe = new System.Windows.Forms.TextBox();
            this.txtDesTipOpe = new System.Windows.Forms.TextBox();
            this.txtPerMovCab = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtGloMovCab = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpFecMovCab = new System.Windows.Forms.DateTimePicker();
            this.txtNumMovCab = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodPer = new System.Windows.Forms.TextBox();
            this.txtNomPer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodAux = new System.Windows.Forms.TextBox();
            this.txtDesAux = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCTipDoc = new System.Windows.Forms.TextBox();
            this.txtNTipDoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSerDoc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOrdCom = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFecDoc = new System.Windows.Forms.DateTimePicker();
            this.dgvMovDet = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCCalPrePro = new System.Windows.Forms.TextBox();
            this.txtCConUni = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCosFle = new System.Windows.Forms.TextBox();
            this.cmbMon = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodMonSyD = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCodPerRec = new System.Windows.Forms.TextBox();
            this.txtNomPerRec = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCodPerAut = new System.Windows.Forms.TextBox();
            this.txtNomPerAut = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTipCam = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(735, 529);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(630, 529);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 25);
            this.btnAceptar.TabIndex = 42;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DarkGray;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(34, 69);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(800, 14);
            this.label24.TabIndex = 386;
            this.label24.Text = "Datos Generales";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(33, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 14);
            this.label18.TabIndex = 385;
            this.label18.Text = "Tipo Operacion";
            // 
            // txtCodTipOpe
            // 
            this.txtCodTipOpe.Location = new System.Drawing.Point(148, 121);
            this.txtCodTipOpe.Name = "txtCodTipOpe";
            this.txtCodTipOpe.Size = new System.Drawing.Size(33, 22);
            this.txtCodTipOpe.TabIndex = 383;
            this.txtCodTipOpe.DoubleClick += new System.EventHandler(this.txtCodTipOpe_DoubleClick);
            this.txtCodTipOpe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodTipOpe_KeyDown);
            this.txtCodTipOpe.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodTipOpe_Validating);
            this.txtCodTipOpe.Validated += new System.EventHandler(this.txtCodTipOpe_Validated);
            // 
            // txtDesTipOpe
            // 
            this.txtDesTipOpe.Location = new System.Drawing.Point(182, 121);
            this.txtDesTipOpe.Name = "txtDesTipOpe";
            this.txtDesTipOpe.ReadOnly = true;
            this.txtDesTipOpe.Size = new System.Drawing.Size(284, 22);
            this.txtDesTipOpe.TabIndex = 384;
            // 
            // txtPerMovCab
            // 
            this.txtPerMovCab.Location = new System.Drawing.Point(148, 40);
            this.txtPerMovCab.MaxLength = 4;
            this.txtPerMovCab.Name = "txtPerMovCab";
            this.txtPerMovCab.ReadOnly = true;
            this.txtPerMovCab.Size = new System.Drawing.Size(127, 22);
            this.txtPerMovCab.TabIndex = 377;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 376;
            this.label14.Text = "Periodo";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.DarkGray;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(35, 290);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(799, 14);
            this.label16.TabIndex = 399;
            this.label16.Text = "Observacion";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGloMovCab
            // 
            this.txtGloMovCab.Location = new System.Drawing.Point(148, 313);
            this.txtGloMovCab.Name = "txtGloMovCab";
            this.txtGloMovCab.Size = new System.Drawing.Size(686, 22);
            this.txtGloMovCab.TabIndex = 400;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(33, 316);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 14);
            this.label17.TabIndex = 401;
            this.label17.Text = "Glosa";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(33, 97);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 14);
            this.label19.TabIndex = 403;
            this.label19.Text = "Fecha";
            // 
            // dtpFecMovCab
            // 
            this.dtpFecMovCab.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecMovCab.Location = new System.Drawing.Point(148, 93);
            this.dtpFecMovCab.Name = "dtpFecMovCab";
            this.dtpFecMovCab.Size = new System.Drawing.Size(99, 22);
            this.dtpFecMovCab.TabIndex = 402;
            this.dtpFecMovCab.Validated += new System.EventHandler(this.dtpFecMovCab_Validated);
            // 
            // txtNumMovCab
            // 
            this.txtNumMovCab.Location = new System.Drawing.Point(591, 40);
            this.txtNumMovCab.MaxLength = 4;
            this.txtNumMovCab.Name = "txtNumMovCab";
            this.txtNumMovCab.ReadOnly = true;
            this.txtNumMovCab.Size = new System.Drawing.Size(74, 22);
            this.txtNumMovCab.TabIndex = 408;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 407;
            this.label1.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 411;
            this.label2.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(582, 121);
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.Size = new System.Drawing.Size(28, 22);
            this.txtCodAlm.TabIndex = 409;
            this.txtCodAlm.DoubleClick += new System.EventHandler(this.txtCodAlm_DoubleClick);
            this.txtCodAlm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlm_KeyDown);
            this.txtCodAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlm_Validating);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(620, 121);
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(214, 22);
            this.txtDesAlm.TabIndex = 410;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 414;
            this.label3.Text = "Personal";
            // 
            // txtCodPer
            // 
            this.txtCodPer.Location = new System.Drawing.Point(148, 149);
            this.txtCodPer.Name = "txtCodPer";
            this.txtCodPer.Size = new System.Drawing.Size(33, 22);
            this.txtCodPer.TabIndex = 412;
            this.txtCodPer.DoubleClick += new System.EventHandler(this.txtCodPer_DoubleClick);
            this.txtCodPer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodPer_KeyDown);
            this.txtCodPer.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodPer_Validating);
            // 
            // txtNomPer
            // 
            this.txtNomPer.Location = new System.Drawing.Point(182, 149);
            this.txtNomPer.Name = "txtNomPer";
            this.txtNomPer.ReadOnly = true;
            this.txtNomPer.Size = new System.Drawing.Size(284, 22);
            this.txtNomPer.TabIndex = 413;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(35, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(799, 14);
            this.label4.TabIndex = 415;
            this.label4.Text = "Datos Proveedor";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 418;
            this.label5.Text = "Proveedor";
            // 
            // txtCodAux
            // 
            this.txtCodAux.Location = new System.Drawing.Point(148, 231);
            this.txtCodAux.Name = "txtCodAux";
            this.txtCodAux.Size = new System.Drawing.Size(86, 22);
            this.txtCodAux.TabIndex = 416;
            this.txtCodAux.DoubleClick += new System.EventHandler(this.txtCodAux_DoubleClick);
            this.txtCodAux.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAux_KeyDown);
            this.txtCodAux.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAux_Validating);
            // 
            // txtDesAux
            // 
            this.txtDesAux.Location = new System.Drawing.Point(235, 231);
            this.txtDesAux.Name = "txtDesAux";
            this.txtDesAux.ReadOnly = true;
            this.txtDesAux.Size = new System.Drawing.Size(231, 22);
            this.txtDesAux.TabIndex = 417;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 14);
            this.label6.TabIndex = 421;
            this.label6.Text = "Tipo Documento";
            // 
            // txtCTipDoc
            // 
            this.txtCTipDoc.Location = new System.Drawing.Point(148, 259);
            this.txtCTipDoc.Name = "txtCTipDoc";
            this.txtCTipDoc.Size = new System.Drawing.Size(33, 22);
            this.txtCTipDoc.TabIndex = 419;
            this.txtCTipDoc.DoubleClick += new System.EventHandler(this.txtCTipDoc_DoubleClick);
            this.txtCTipDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCTipDoc_KeyDown);
            this.txtCTipDoc.Validating += new System.ComponentModel.CancelEventHandler(this.txtCTipDoc_Validating);
            // 
            // txtNTipDoc
            // 
            this.txtNTipDoc.Location = new System.Drawing.Point(182, 259);
            this.txtNTipDoc.Name = "txtNTipDoc";
            this.txtNTipDoc.ReadOnly = true;
            this.txtNTipDoc.Size = new System.Drawing.Size(168, 22);
            this.txtNTipDoc.TabIndex = 420;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 423;
            this.label7.Text = "Serie";
            // 
            // txtSerDoc
            // 
            this.txtSerDoc.Location = new System.Drawing.Point(418, 259);
            this.txtSerDoc.Name = "txtSerDoc";
            this.txtSerDoc.Size = new System.Drawing.Size(48, 22);
            this.txtSerDoc.TabIndex = 422;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(493, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 14);
            this.label8.TabIndex = 425;
            this.label8.Text = "N°.Documento";
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Location = new System.Drawing.Point(582, 259);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(74, 22);
            this.txtNumDoc.TabIndex = 424;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(493, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 14);
            this.label9.TabIndex = 427;
            this.label9.Text = "O / C";
            // 
            // txtOrdCom
            // 
            this.txtOrdCom.Location = new System.Drawing.Point(582, 233);
            this.txtOrdCom.Name = "txtOrdCom";
            this.txtOrdCom.Size = new System.Drawing.Size(74, 22);
            this.txtOrdCom.TabIndex = 426;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(661, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 14);
            this.label10.TabIndex = 429;
            this.label10.Text = "Fech.Docum";
            // 
            // dtpFecDoc
            // 
            this.dtpFecDoc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecDoc.Location = new System.Drawing.Point(742, 259);
            this.dtpFecDoc.Name = "dtpFecDoc";
            this.dtpFecDoc.Size = new System.Drawing.Size(92, 22);
            this.dtpFecDoc.TabIndex = 428;
            // 
            // dgvMovDet
            // 
            this.dgvMovDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovDet.Location = new System.Drawing.Point(35, 344);
            this.dgvMovDet.Name = "dgvMovDet";
            this.dgvMovDet.Size = new System.Drawing.Size(799, 178);
            this.dgvMovDet.TabIndex = 430;
            // 
            // btnQuitar
            // 
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(200, 529);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(80, 25);
            this.btnQuitar.TabIndex = 433;
            this.btnQuitar.Tag = "19";
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(119, 529);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 25);
            this.btnModificar.TabIndex = 432;
            this.btnModificar.Tag = "19";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(38, 529);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 25);
            this.btnAgregar.TabIndex = 431;
            this.btnAgregar.Tag = "19";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCCalPrePro
            // 
            this.txtCCalPrePro.Location = new System.Drawing.Point(467, 121);
            this.txtCCalPrePro.Name = "txtCCalPrePro";
            this.txtCCalPrePro.ReadOnly = true;
            this.txtCCalPrePro.Size = new System.Drawing.Size(10, 22);
            this.txtCCalPrePro.TabIndex = 434;
            this.txtCCalPrePro.Visible = false;
            // 
            // txtCConUni
            // 
            this.txtCConUni.Location = new System.Drawing.Point(478, 121);
            this.txtCConUni.Name = "txtCConUni";
            this.txtCConUni.ReadOnly = true;
            this.txtCConUni.Size = new System.Drawing.Size(10, 22);
            this.txtCConUni.TabIndex = 435;
            this.txtCConUni.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(493, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 437;
            this.label11.Text = "Flete";
            // 
            // txtCosFle
            // 
            this.txtCosFle.Location = new System.Drawing.Point(582, 177);
            this.txtCosFle.Name = "txtCosFle";
            this.txtCosFle.Size = new System.Drawing.Size(74, 22);
            this.txtCosFle.TabIndex = 436;
            this.txtCosFle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbMon
            // 
            this.cmbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMon.Location = new System.Drawing.Point(742, 176);
            this.cmbMon.Name = "cmbMon";
            this.cmbMon.Size = new System.Drawing.Size(93, 22);
            this.cmbMon.TabIndex = 439;
            this.cmbMon.SelectionChangeCommitted += new System.EventHandler(this.cmbMon_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(661, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 14);
            this.label12.TabIndex = 438;
            this.label12.Text = "Moneda";
            // 
            // txtCodMonSyD
            // 
            this.txtCodMonSyD.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodMonSyD.Location = new System.Drawing.Point(823, 231);
            this.txtCodMonSyD.Name = "txtCodMonSyD";
            this.txtCodMonSyD.Size = new System.Drawing.Size(11, 22);
            this.txtCodMonSyD.TabIndex = 440;
            this.txtCodMonSyD.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 14);
            this.label13.TabIndex = 443;
            this.label13.Text = "Recibe";
            // 
            // txtCodPerRec
            // 
            this.txtCodPerRec.Location = new System.Drawing.Point(148, 177);
            this.txtCodPerRec.Name = "txtCodPerRec";
            this.txtCodPerRec.Size = new System.Drawing.Size(33, 22);
            this.txtCodPerRec.TabIndex = 441;
            this.txtCodPerRec.DoubleClick += new System.EventHandler(this.txtCodPerRec_DoubleClick);
            this.txtCodPerRec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodPerRec_KeyDown);
            this.txtCodPerRec.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodPerRec_Validating);
            // 
            // txtNomPerRec
            // 
            this.txtNomPerRec.Location = new System.Drawing.Point(182, 177);
            this.txtNomPerRec.Name = "txtNomPerRec";
            this.txtNomPerRec.ReadOnly = true;
            this.txtNomPerRec.Size = new System.Drawing.Size(284, 22);
            this.txtNomPerRec.TabIndex = 442;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(493, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 14);
            this.label15.TabIndex = 446;
            this.label15.Text = "Autoriza";
            // 
            // txtCodPerAut
            // 
            this.txtCodPerAut.Location = new System.Drawing.Point(582, 149);
            this.txtCodPerAut.Name = "txtCodPerAut";
            this.txtCodPerAut.Size = new System.Drawing.Size(33, 22);
            this.txtCodPerAut.TabIndex = 444;
            this.txtCodPerAut.DoubleClick += new System.EventHandler(this.txtCodPerAut_DoubleClick);
            this.txtCodPerAut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodPerAut_KeyDown);
            this.txtCodPerAut.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodPerAut_Validating);
            // 
            // txtNomPerAut
            // 
            this.txtNomPerAut.Location = new System.Drawing.Point(620, 149);
            this.txtNomPerAut.Name = "txtNomPerAut";
            this.txtNomPerAut.ReadOnly = true;
            this.txtNomPerAut.Size = new System.Drawing.Size(215, 22);
            this.txtNomPerAut.TabIndex = 445;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(661, 234);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 14);
            this.label20.TabIndex = 447;
            this.label20.Text = "T.C";
            // 
            // txtTipCam
            // 
            this.txtTipCam.Location = new System.Drawing.Point(742, 231);
            this.txtTipCam.MaxLength = 10;
            this.txtTipCam.Name = "txtTipCam";
            this.txtTipCam.Size = new System.Drawing.Size(76, 22);
            this.txtTipCam.TabIndex = 448;
            this.txtTipCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // wEditIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(865, 577);
            this.ControlBox = false;
            this.Controls.Add(this.txtTipCam);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCodPerAut);
            this.Controls.Add(this.txtNomPerAut);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCodPerRec);
            this.Controls.Add(this.txtNomPerRec);
            this.Controls.Add(this.txtCodMonSyD);
            this.Controls.Add(this.cmbMon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCosFle);
            this.Controls.Add(this.txtCConUni);
            this.Controls.Add(this.txtCCalPrePro);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvMovDet);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpFecDoc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtOrdCom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNumDoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSerDoc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCTipDoc);
            this.Controls.Add(this.txtNTipDoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodAux);
            this.Controls.Add(this.txtDesAux);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodPer);
            this.Controls.Add(this.txtNomPer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodAlm);
            this.Controls.Add(this.txtDesAlm);
            this.Controls.Add(this.txtNumMovCab);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dtpFecMovCab);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtGloMovCab);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtCodTipOpe);
            this.Controls.Add(this.txtDesTipOpe);
            this.Controls.Add(this.txtPerMovCab);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wEditIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditIngresos_FormClosing);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtPerMovCab, 0);
            this.Controls.SetChildIndex(this.txtDesTipOpe, 0);
            this.Controls.SetChildIndex(this.txtCodTipOpe, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.txtGloMovCab, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.dtpFecMovCab, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNumMovCab, 0);
            this.Controls.SetChildIndex(this.txtDesAlm, 0);
            this.Controls.SetChildIndex(this.txtCodAlm, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtNomPer, 0);
            this.Controls.SetChildIndex(this.txtCodPer, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDesAux, 0);
            this.Controls.SetChildIndex(this.txtCodAux, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNTipDoc, 0);
            this.Controls.SetChildIndex(this.txtCTipDoc, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtSerDoc, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtNumDoc, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtOrdCom, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.dtpFecDoc, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.dgvMovDet, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.txtCCalPrePro, 0);
            this.Controls.SetChildIndex(this.txtCConUni, 0);
            this.Controls.SetChildIndex(this.txtCosFle, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.cmbMon, 0);
            this.Controls.SetChildIndex(this.txtCodMonSyD, 0);
            this.Controls.SetChildIndex(this.txtNomPerRec, 0);
            this.Controls.SetChildIndex(this.txtCodPerRec, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.txtNomPerAut, 0);
            this.Controls.SetChildIndex(this.txtCodPerAut, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.txtTipCam, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovDet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDesTipOpe;
        internal System.Windows.Forms.TextBox txtPerMovCab;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtGloMovCab;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.TextBox txtNumMovCab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodPer;
        private System.Windows.Forms.TextBox txtNomPer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDesAux;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNTipDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOrdCom;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtCodTipOpe;
        internal System.Windows.Forms.TextBox txtCodAlm;
        internal System.Windows.Forms.TextBox txtCodAux;
        internal System.Windows.Forms.TextBox txtCTipDoc;
        internal System.Windows.Forms.TextBox txtSerDoc;
        internal System.Windows.Forms.TextBox txtNumDoc;
        internal System.Windows.Forms.DateTimePicker dtpFecDoc;
        internal System.Windows.Forms.DataGridView dgvMovDet;
        internal System.Windows.Forms.TextBox txtDesAlm;
        internal System.Windows.Forms.Button btnQuitar;
        internal System.Windows.Forms.Button btnModificar;
        internal System.Windows.Forms.Button btnAgregar;
        internal System.Windows.Forms.TextBox txtCCalPrePro;
        internal System.Windows.Forms.DateTimePicker dtpFecMovCab;
        internal System.Windows.Forms.TextBox txtCConUni;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txtCosFle;
        private System.Windows.Forms.ComboBox cmbMon;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtCodMonSyD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCodPerRec;
        private System.Windows.Forms.TextBox txtNomPerRec;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCodPerAut;
        private System.Windows.Forms.TextBox txtNomPerAut;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.TextBox txtTipCam;
    }
}