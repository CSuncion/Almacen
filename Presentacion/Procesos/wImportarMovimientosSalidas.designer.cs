namespace Presentacion.Procesos
{
    partial class wImportarMovimientosSalidas
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
            this.label24 = new System.Windows.Forms.Label();
            this.txtArcExc = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbHoj = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnBusArcExc = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.lblRegImp = new System.Windows.Forms.Label();
            this.dgvAux = new System.Windows.Forms.DataGridView();
            this.dgvErr = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbError = new System.Windows.Forms.ComboBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.txtPerMovCab = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAux)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErr)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(721, 519);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 25);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DarkGray;
            this.label24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(27, 64);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(793, 14);
            this.label24.TabIndex = 386;
            this.label24.Text = "Datos Archivo excel";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtArcExc
            // 
            this.txtArcExc.Location = new System.Drawing.Point(82, 88);
            this.txtArcExc.Name = "txtArcExc";
            this.txtArcExc.ReadOnly = true;
            this.txtArcExc.Size = new System.Drawing.Size(410, 22);
            this.txtArcExc.TabIndex = 384;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 14);
            this.label15.TabIndex = 398;
            this.label15.Text = "Ruta";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(534, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 14);
            this.label17.TabIndex = 401;
            this.label17.Text = "Hoja";
            // 
            // cmbHoj
            // 
            this.cmbHoj.BackColor = System.Drawing.Color.White;
            this.cmbHoj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoj.FormattingEnabled = true;
            this.cmbHoj.Location = new System.Drawing.Point(572, 88);
            this.cmbHoj.Name = "cmbHoj";
            this.cmbHoj.Size = new System.Drawing.Size(143, 22);
            this.cmbHoj.TabIndex = 405;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(616, 519);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 25);
            this.btnAceptar.TabIndex = 406;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnBusArcExc
            // 
            this.btnBusArcExc.Location = new System.Drawing.Point(493, 88);
            this.btnBusArcExc.Name = "btnBusArcExc";
            this.btnBusArcExc.Size = new System.Drawing.Size(26, 23);
            this.btnBusArcExc.TabIndex = 407;
            this.btnBusArcExc.Text = "...";
            this.btnBusArcExc.UseVisualStyleBackColor = true;
            this.btnBusArcExc.Click += new System.EventHandler(this.btnBusArcExc_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(721, 87);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(99, 25);
            this.btnValidar.TabIndex = 408;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // lblRegImp
            // 
            this.lblRegImp.BackColor = System.Drawing.Color.DarkGray;
            this.lblRegImp.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegImp.ForeColor = System.Drawing.Color.White;
            this.lblRegImp.Location = new System.Drawing.Point(27, 120);
            this.lblRegImp.Name = "lblRegImp";
            this.lblRegImp.Size = new System.Drawing.Size(793, 14);
            this.lblRegImp.TabIndex = 409;
            this.lblRegImp.Text = "Registros a importar";
            this.lblRegImp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvAux
            // 
            this.dgvAux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAux.Location = new System.Drawing.Point(27, 137);
            this.dgvAux.Name = "dgvAux";
            this.dgvAux.Size = new System.Drawing.Size(793, 166);
            this.dgvAux.TabIndex = 410;
            // 
            // dgvErr
            // 
            this.dgvErr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErr.Location = new System.Drawing.Point(27, 345);
            this.dgvErr.Name = "dgvErr";
            this.dgvErr.Size = new System.Drawing.Size(793, 158);
            this.dgvErr.TabIndex = 412;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 413;
            this.label2.Text = "Errores";
            // 
            // cmbError
            // 
            this.cmbError.BackColor = System.Drawing.Color.White;
            this.cmbError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbError.FormattingEnabled = true;
            this.cmbError.Location = new System.Drawing.Point(82, 314);
            this.cmbError.Name = "cmbError";
            this.cmbError.Size = new System.Drawing.Size(209, 22);
            this.cmbError.TabIndex = 414;
            this.cmbError.SelectionChangeCommitted += new System.EventHandler(this.cmbError_SelectionChangeCommitted);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(27, 509);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(144, 25);
            this.btnExportar.TabIndex = 415;
            this.btnExportar.Text = "Exportar excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // txtPerMovCab
            // 
            this.txtPerMovCab.Location = new System.Drawing.Point(82, 33);
            this.txtPerMovCab.MaxLength = 4;
            this.txtPerMovCab.Name = "txtPerMovCab";
            this.txtPerMovCab.ReadOnly = true;
            this.txtPerMovCab.Size = new System.Drawing.Size(127, 22);
            this.txtPerMovCab.TabIndex = 417;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 416;
            this.label14.Text = "Periodo";
            // 
            // wImportarMovimientosSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(847, 563);
            this.ControlBox = false;
            this.Controls.Add(this.txtPerMovCab);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.cmbError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvErr);
            this.Controls.Add(this.dgvAux);
            this.Controls.Add(this.lblRegImp);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnBusArcExc);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbHoj);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtArcExc);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wImportarMovimientosSalidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Movimientos de Salidas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wImportarAuxiliar_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.txtArcExc, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.cmbHoj, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnBusArcExc, 0);
            this.Controls.SetChildIndex(this.btnValidar, 0);
            this.Controls.SetChildIndex(this.lblRegImp, 0);
            this.Controls.SetChildIndex(this.dgvAux, 0);
            this.Controls.SetChildIndex(this.dgvErr, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbError, 0);
            this.Controls.SetChildIndex(this.btnExportar, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtPerMovCab, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAux)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtArcExc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbHoj;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnBusArcExc;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label lblRegImp;
        private System.Windows.Forms.DataGridView dgvAux;
        private System.Windows.Forms.DataGridView dgvErr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbError;
        private System.Windows.Forms.Button btnExportar;
        internal System.Windows.Forms.TextBox txtPerMovCab;
        private System.Windows.Forms.Label label14;
    }
}