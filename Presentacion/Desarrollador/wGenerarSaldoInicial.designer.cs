namespace Presentacion.Desarrollador
{
    partial class wGenerarSaldoInicial
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
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.DgvImportar = new System.Windows.Forms.DataGridView();
            this.cmbHojas = new System.Windows.Forms.ComboBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtLoad = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnVisualize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvImportar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExcel
            // 
            this.dgvExcel.BackgroundColor = System.Drawing.Color.White;
            this.dgvExcel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.GridColor = System.Drawing.Color.Silver;
            this.dgvExcel.Location = new System.Drawing.Point(365, 293);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.Size = new System.Drawing.Size(69, 22);
            this.dgvExcel.TabIndex = 262;
            this.dgvExcel.Visible = false;
            // 
            // DgvDatos
            // 
            this.DgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.DgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.GridColor = System.Drawing.Color.Silver;
            this.DgvDatos.Location = new System.Drawing.Point(31, 323);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.Size = new System.Drawing.Size(723, 200);
            this.DgvDatos.TabIndex = 261;
            // 
            // DgvImportar
            // 
            this.DgvImportar.BackgroundColor = System.Drawing.Color.White;
            this.DgvImportar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvImportar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvImportar.GridColor = System.Drawing.Color.Silver;
            this.DgvImportar.Location = new System.Drawing.Point(31, 88);
            this.DgvImportar.Name = "DgvImportar";
            this.DgvImportar.Size = new System.Drawing.Size(723, 200);
            this.DgvImportar.TabIndex = 260;
            // 
            // cmbHojas
            // 
            this.cmbHojas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHojas.FormattingEnabled = true;
            this.cmbHojas.Location = new System.Drawing.Point(549, 58);
            this.cmbHojas.Name = "cmbHojas";
            this.cmbHojas.Size = new System.Drawing.Size(117, 22);
            this.cmbHojas.TabIndex = 259;
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(32, 292);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(122, 25);
            this.btnImportar.TabIndex = 258;
            this.btnImportar.Text = "Importar Archivos";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(155, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 25);
            this.btnClose.TabIndex = 257;
            this.btnClose.Text = "Salir";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtLoad
            // 
            this.txtLoad.Location = new System.Drawing.Point(31, 58);
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.ReadOnly = true;
            this.txtLoad.Size = new System.Drawing.Size(417, 22);
            this.txtLoad.TabIndex = 256;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(452, 57);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(92, 25);
            this.btnLoad.TabIndex = 255;
            this.btnLoad.Text = "Cargar Archivo";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(31, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(723, 15);
            this.label21.TabIndex = 254;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // btnVisualize
            // 
            this.btnVisualize.Location = new System.Drawing.Point(672, 57);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(83, 25);
            this.btnVisualize.TabIndex = 263;
            this.btnVisualize.Text = "Cargar Hoja";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
            // 
            // wGenerarSaldoInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(785, 565);
            this.Controls.Add(this.btnVisualize);
            this.Controls.Add(this.dgvExcel);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.DgvImportar);
            this.Controls.Add(this.cmbHojas);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtLoad);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label21);
            this.Name = "wGenerarSaldoInicial";
            this.Text = "Generar Movimiento Saldo Inicial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wMigrarExistencias_FormClosing);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.btnLoad, 0);
            this.Controls.SetChildIndex(this.txtLoad, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnImportar, 0);
            this.Controls.SetChildIndex(this.cmbHojas, 0);
            this.Controls.SetChildIndex(this.DgvImportar, 0);
            this.Controls.SetChildIndex(this.DgvDatos, 0);
            this.Controls.SetChildIndex(this.dgvExcel, 0);
            this.Controls.SetChildIndex(this.btnVisualize, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvImportar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvExcel;
        internal System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.DataGridView DgvImportar;
        private System.Windows.Forms.ComboBox cmbHojas;
        internal System.Windows.Forms.Button btnImportar;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.TextBox txtLoad;
        internal System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.Button btnVisualize;


    }
}
