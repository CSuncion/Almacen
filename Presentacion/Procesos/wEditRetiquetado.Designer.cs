namespace Presentacion.Procesos
{
    partial class wEditRetiquetado
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
            this.lblCorRet = new System.Windows.Forms.Label();
            this.txtCorRet = new System.Windows.Forms.TextBox();
            this.lblFecRet = new System.Windows.Forms.Label();
            this.dtpFecRet = new System.Windows.Forms.DateTimePicker();
            this.lblCodAlmPT = new System.Windows.Forms.Label();
            this.txtCodAlmPT = new System.Windows.Forms.TextBox();
            this.txtDesAlmPT = new System.Windows.Forms.TextBox();
            this.lblCodExiPT = new System.Windows.Forms.Label();
            this.txtCodExiPT = new System.Windows.Forms.TextBox();
            this.txtDesExiPT = new System.Windows.Forms.TextBox();
            this.lblCodAlmRE = new System.Windows.Forms.Label();
            this.txtCodAlmRE = new System.Windows.Forms.TextBox();
            this.txtDesAlmRE = new System.Windows.Forms.TextBox();
            this.lblCodExiRE = new System.Windows.Forms.Label();
            this.txtCodExiRE = new System.Windows.Forms.TextBox();
            this.txtDesExiRE = new System.Windows.Forms.TextBox();
            this.lblCanUniRet = new System.Windows.Forms.Label();
            this.txtCanUniRet = new System.Windows.Forms.TextBox();
            this.lblCanCajRet = new System.Windows.Forms.Label();
            this.txtCanCajRet = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvRetProTer = new System.Windows.Forms.DataGridView();
            this.txtUniPorEmp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetProTer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCorRet
            // 
            this.lblCorRet.AutoSize = true;
            this.lblCorRet.Location = new System.Drawing.Point(25, 56);
            this.lblCorRet.Name = "lblCorRet";
            this.lblCorRet.Size = new System.Drawing.Size(50, 14);
            this.lblCorRet.TabIndex = 0;
            this.lblCorRet.Text = "Numero";
            // 
            // txtCorRet
            // 
            this.txtCorRet.Location = new System.Drawing.Point(135, 53);
            this.txtCorRet.Name = "txtCorRet";
            this.txtCorRet.ReadOnly = true;
            this.txtCorRet.Size = new System.Drawing.Size(100, 22);
            this.txtCorRet.TabIndex = 1;
            // 
            // lblFecRet
            // 
            this.lblFecRet.AutoSize = true;
            this.lblFecRet.Location = new System.Drawing.Point(25, 84);
            this.lblFecRet.Name = "lblFecRet";
            this.lblFecRet.Size = new System.Drawing.Size(39, 14);
            this.lblFecRet.TabIndex = 2;
            this.lblFecRet.Text = "Fecha";
            // 
            // dtpFecRet
            // 
            this.dtpFecRet.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecRet.Location = new System.Drawing.Point(135, 81);
            this.dtpFecRet.Name = "dtpFecRet";
            this.dtpFecRet.Size = new System.Drawing.Size(100, 22);
            this.dtpFecRet.TabIndex = 3;
            // 
            // lblCodAlmPT
            // 
            this.lblCodAlmPT.AutoSize = true;
            this.lblCodAlmPT.Location = new System.Drawing.Point(25, 112);
            this.lblCodAlmPT.Name = "lblCodAlmPT";
            this.lblCodAlmPT.Size = new System.Drawing.Size(69, 14);
            this.lblCodAlmPT.TabIndex = 4;
            this.lblCodAlmPT.Text = "Almacen PT";
            // 
            // txtCodAlmPT
            // 
            this.txtCodAlmPT.Location = new System.Drawing.Point(135, 109);
            this.txtCodAlmPT.Name = "txtCodAlmPT";
            this.txtCodAlmPT.Size = new System.Drawing.Size(100, 22);
            this.txtCodAlmPT.TabIndex = 5;
            this.txtCodAlmPT.DoubleClick += new System.EventHandler(this.txtCodAlmPT_DoubleClick);
            this.txtCodAlmPT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlmPT_KeyDown);
            this.txtCodAlmPT.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlmPT_Validating);
            // 
            // txtDesAlmPT
            // 
            this.txtDesAlmPT.Location = new System.Drawing.Point(236, 109);
            this.txtDesAlmPT.Name = "txtDesAlmPT";
            this.txtDesAlmPT.ReadOnly = true;
            this.txtDesAlmPT.Size = new System.Drawing.Size(317, 22);
            this.txtDesAlmPT.TabIndex = 7;
            // 
            // lblCodExiPT
            // 
            this.lblCodExiPT.AutoSize = true;
            this.lblCodExiPT.Location = new System.Drawing.Point(25, 140);
            this.lblCodExiPT.Name = "lblCodExiPT";
            this.lblCodExiPT.Size = new System.Drawing.Size(77, 14);
            this.lblCodExiPT.TabIndex = 8;
            this.lblCodExiPT.Text = "Existencia PT";
            // 
            // txtCodExiPT
            // 
            this.txtCodExiPT.Location = new System.Drawing.Point(135, 137);
            this.txtCodExiPT.Name = "txtCodExiPT";
            this.txtCodExiPT.Size = new System.Drawing.Size(100, 22);
            this.txtCodExiPT.TabIndex = 9;
            this.txtCodExiPT.DoubleClick += new System.EventHandler(this.txtCodExiPT_DoubleClick);
            this.txtCodExiPT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExiPT_KeyDown);
            this.txtCodExiPT.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExiPT_Validating);
            // 
            // txtDesExiPT
            // 
            this.txtDesExiPT.Location = new System.Drawing.Point(236, 137);
            this.txtDesExiPT.Name = "txtDesExiPT";
            this.txtDesExiPT.ReadOnly = true;
            this.txtDesExiPT.Size = new System.Drawing.Size(317, 22);
            this.txtDesExiPT.TabIndex = 11;
            // 
            // lblCodAlmRE
            // 
            this.lblCodAlmRE.AutoSize = true;
            this.lblCodAlmRE.Location = new System.Drawing.Point(24, 168);
            this.lblCodAlmRE.Name = "lblCodAlmRE";
            this.lblCodAlmRE.Size = new System.Drawing.Size(70, 14);
            this.lblCodAlmRE.TabIndex = 12;
            this.lblCodAlmRE.Text = "Almacen RE";
            // 
            // txtCodAlmRE
            // 
            this.txtCodAlmRE.Location = new System.Drawing.Point(135, 165);
            this.txtCodAlmRE.Name = "txtCodAlmRE";
            this.txtCodAlmRE.Size = new System.Drawing.Size(100, 22);
            this.txtCodAlmRE.TabIndex = 13;
            this.txtCodAlmRE.DoubleClick += new System.EventHandler(this.txtCodAlmRE_DoubleClick);
            this.txtCodAlmRE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodAlmRE_KeyDown);
            this.txtCodAlmRE.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodAlmRE_Validating);
            // 
            // txtDesAlmRE
            // 
            this.txtDesAlmRE.Location = new System.Drawing.Point(236, 165);
            this.txtDesAlmRE.Name = "txtDesAlmRE";
            this.txtDesAlmRE.ReadOnly = true;
            this.txtDesAlmRE.Size = new System.Drawing.Size(317, 22);
            this.txtDesAlmRE.TabIndex = 15;
            // 
            // lblCodExiRE
            // 
            this.lblCodExiRE.AutoSize = true;
            this.lblCodExiRE.Location = new System.Drawing.Point(25, 196);
            this.lblCodExiRE.Name = "lblCodExiRE";
            this.lblCodExiRE.Size = new System.Drawing.Size(78, 14);
            this.lblCodExiRE.TabIndex = 16;
            this.lblCodExiRE.Text = "Existencia RE";
            // 
            // txtCodExiRE
            // 
            this.txtCodExiRE.Location = new System.Drawing.Point(135, 193);
            this.txtCodExiRE.Name = "txtCodExiRE";
            this.txtCodExiRE.Size = new System.Drawing.Size(100, 22);
            this.txtCodExiRE.TabIndex = 17;
            this.txtCodExiRE.DoubleClick += new System.EventHandler(this.txtCodExiRE_DoubleClick);
            this.txtCodExiRE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodExiRE_KeyDown);
            this.txtCodExiRE.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodExiRE_Validating);
            // 
            // txtDesExiRE
            // 
            this.txtDesExiRE.Location = new System.Drawing.Point(236, 193);
            this.txtDesExiRE.Name = "txtDesExiRE";
            this.txtDesExiRE.ReadOnly = true;
            this.txtDesExiRE.Size = new System.Drawing.Size(317, 22);
            this.txtDesExiRE.TabIndex = 19;
            // 
            // lblCanUniRet
            // 
            this.lblCanUniRet.AutoSize = true;
            this.lblCanUniRet.Location = new System.Drawing.Point(254, 224);
            this.lblCanUniRet.Name = "lblCanUniRet";
            this.lblCanUniRet.Size = new System.Drawing.Size(76, 14);
            this.lblCanUniRet.TabIndex = 20;
            this.lblCanUniRet.Text = "Unidades RE";
            // 
            // txtCanUniRet
            // 
            this.txtCanUniRet.Location = new System.Drawing.Point(336, 221);
            this.txtCanUniRet.Name = "txtCanUniRet";
            this.txtCanUniRet.ReadOnly = true;
            this.txtCanUniRet.Size = new System.Drawing.Size(77, 22);
            this.txtCanUniRet.TabIndex = 21;
            this.txtCanUniRet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCanCajRet
            // 
            this.lblCanCajRet.AutoSize = true;
            this.lblCanCajRet.Location = new System.Drawing.Point(432, 224);
            this.lblCanCajRet.Name = "lblCanCajRet";
            this.lblCanCajRet.Size = new System.Drawing.Size(52, 14);
            this.lblCanCajRet.TabIndex = 22;
            this.lblCanCajRet.Text = "Cajas RE";
            // 
            // txtCanCajRet
            // 
            this.txtCanCajRet.Location = new System.Drawing.Point(490, 220);
            this.txtCanCajRet.Name = "txtCanCajRet";
            this.txtCanCajRet.ReadOnly = true;
            this.txtCanCajRet.Size = new System.Drawing.Size(63, 22);
            this.txtCanCajRet.TabIndex = 23;
            this.txtCanCajRet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DarkGray;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(25, 32);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(629, 14);
            this.label24.TabIndex = 387;
            this.label24.Text = "Datos Generales";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(555, 390);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 389;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(450, 390);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 25);
            this.btnAceptar.TabIndex = 388;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(188, 390);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(80, 25);
            this.btnQuitar.TabIndex = 437;
            this.btnQuitar.Tag = "19";
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(107, 390);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 25);
            this.btnModificar.TabIndex = 436;
            this.btnModificar.Tag = "19";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(26, 390);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 25);
            this.btnAgregar.TabIndex = 435;
            this.btnAgregar.Tag = "19";
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvRetProTer
            // 
            this.dgvRetProTer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetProTer.Location = new System.Drawing.Point(27, 250);
            this.dgvRetProTer.Name = "dgvRetProTer";
            this.dgvRetProTer.Size = new System.Drawing.Size(627, 134);
            this.dgvRetProTer.TabIndex = 434;
            // 
            // txtUniPorEmp
            // 
            this.txtUniPorEmp.Location = new System.Drawing.Point(135, 221);
            this.txtUniPorEmp.Name = "txtUniPorEmp";
            this.txtUniPorEmp.ReadOnly = true;
            this.txtUniPorEmp.Size = new System.Drawing.Size(100, 22);
            this.txtUniPorEmp.TabIndex = 439;
            this.txtUniPorEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 438;
            this.label1.Text = "Uni x Caja RE";
            // 
            // wEditRetiquetado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 440);
            this.Controls.Add(this.txtUniPorEmp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvRetProTer);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtCanCajRet);
            this.Controls.Add(this.lblCanCajRet);
            this.Controls.Add(this.txtCanUniRet);
            this.Controls.Add(this.lblCanUniRet);
            this.Controls.Add(this.txtDesExiRE);
            this.Controls.Add(this.txtCodExiRE);
            this.Controls.Add(this.lblCodExiRE);
            this.Controls.Add(this.txtDesAlmRE);
            this.Controls.Add(this.txtCodAlmRE);
            this.Controls.Add(this.lblCodAlmRE);
            this.Controls.Add(this.txtDesExiPT);
            this.Controls.Add(this.txtCodExiPT);
            this.Controls.Add(this.lblCodExiPT);
            this.Controls.Add(this.txtDesAlmPT);
            this.Controls.Add(this.txtCodAlmPT);
            this.Controls.Add(this.lblCodAlmPT);
            this.Controls.Add(this.dtpFecRet);
            this.Controls.Add(this.lblFecRet);
            this.Controls.Add(this.txtCorRet);
            this.Controls.Add(this.lblCorRet);
            this.Name = "wEditRetiquetado";
            this.Text = "Editar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditRetiquetado_FormClosing);
            this.Controls.SetChildIndex(this.lblCorRet, 0);
            this.Controls.SetChildIndex(this.txtCorRet, 0);
            this.Controls.SetChildIndex(this.lblFecRet, 0);
            this.Controls.SetChildIndex(this.dtpFecRet, 0);
            this.Controls.SetChildIndex(this.lblCodAlmPT, 0);
            this.Controls.SetChildIndex(this.txtCodAlmPT, 0);
            this.Controls.SetChildIndex(this.txtDesAlmPT, 0);
            this.Controls.SetChildIndex(this.lblCodExiPT, 0);
            this.Controls.SetChildIndex(this.txtCodExiPT, 0);
            this.Controls.SetChildIndex(this.txtDesExiPT, 0);
            this.Controls.SetChildIndex(this.lblCodAlmRE, 0);
            this.Controls.SetChildIndex(this.txtCodAlmRE, 0);
            this.Controls.SetChildIndex(this.txtDesAlmRE, 0);
            this.Controls.SetChildIndex(this.lblCodExiRE, 0);
            this.Controls.SetChildIndex(this.txtCodExiRE, 0);
            this.Controls.SetChildIndex(this.txtDesExiRE, 0);
            this.Controls.SetChildIndex(this.lblCanUniRet, 0);
            this.Controls.SetChildIndex(this.txtCanUniRet, 0);
            this.Controls.SetChildIndex(this.lblCanCajRet, 0);
            this.Controls.SetChildIndex(this.txtCanCajRet, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.dgvRetProTer, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtUniPorEmp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetProTer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCorRet;
        private System.Windows.Forms.TextBox txtCorRet;
        private System.Windows.Forms.Label lblFecRet;
        private System.Windows.Forms.DateTimePicker dtpFecRet;
        private System.Windows.Forms.Label lblCodAlmPT;
        private System.Windows.Forms.TextBox txtDesAlmPT;
        private System.Windows.Forms.Label lblCodExiPT;
        private System.Windows.Forms.TextBox txtDesExiPT;
        private System.Windows.Forms.Label lblCodAlmRE;
        private System.Windows.Forms.TextBox txtCodAlmRE;
        private System.Windows.Forms.TextBox txtDesAlmRE;
        private System.Windows.Forms.Label lblCodExiRE;
        private System.Windows.Forms.TextBox txtCodExiRE;
        private System.Windows.Forms.TextBox txtDesExiRE;
        private System.Windows.Forms.Label lblCanUniRet;
        private System.Windows.Forms.TextBox txtCanUniRet;
        private System.Windows.Forms.Label lblCanCajRet;
        private System.Windows.Forms.TextBox txtCanCajRet;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        internal System.Windows.Forms.Button btnQuitar;
        internal System.Windows.Forms.Button btnModificar;
        internal System.Windows.Forms.Button btnAgregar;
        internal System.Windows.Forms.DataGridView dgvRetProTer;
        internal System.Windows.Forms.TextBox txtCodAlmPT;
        internal System.Windows.Forms.TextBox txtCodExiPT;
        private System.Windows.Forms.TextBox txtUniPorEmp;
        private System.Windows.Forms.Label label1;
    }
}