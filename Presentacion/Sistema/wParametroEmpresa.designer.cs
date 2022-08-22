namespace Presentacion.Sistema
{
    partial class wParametroEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpIma = new System.Windows.Forms.TabPage();
            this.btnActLogEmp = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lblRutLog = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pbImaLog = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tpIma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImaLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(526, 370);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 25);
            this.btnCancelar.TabIndex = 283;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpIma);
            this.tabControl1.Location = new System.Drawing.Point(23, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(614, 331);
            this.tabControl1.TabIndex = 290;
            // 
            // tpIma
            // 
            this.tpIma.Controls.Add(this.btnActLogEmp);
            this.tpIma.Controls.Add(this.label22);
            this.tpIma.Controls.Add(this.lblRutLog);
            this.tpIma.Controls.Add(this.btnAgregar);
            this.tpIma.Controls.Add(this.pbImaLog);
            this.tpIma.Location = new System.Drawing.Point(4, 23);
            this.tpIma.Name = "tpIma";
            this.tpIma.Padding = new System.Windows.Forms.Padding(3);
            this.tpIma.Size = new System.Drawing.Size(606, 304);
            this.tpIma.TabIndex = 1;
            this.tpIma.Text = "Imagenes";
            this.tpIma.UseVisualStyleBackColor = true;
            // 
            // btnActLogEmp
            // 
            this.btnActLogEmp.Image = global::Presentacion.Properties.Resources.arrow_refresh;
            this.btnActLogEmp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActLogEmp.Location = new System.Drawing.Point(158, 105);
            this.btnActLogEmp.Name = "btnActLogEmp";
            this.btnActLogEmp.Size = new System.Drawing.Size(31, 24);
            this.btnActLogEmp.TabIndex = 290;
            this.btnActLogEmp.UseVisualStyleBackColor = true;
            this.btnActLogEmp.Click += new System.EventHandler(this.btnActLogEmp_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(158, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(134, 56);
            this.label22.TabIndex = 157;
            this.label22.Text = "Aqui se muestra la imagen\r\nque se visualizara como\r\nlogo en los reportes\r\n\r\n";
            // 
            // lblRutLog
            // 
            this.lblRutLog.AutoSize = true;
            this.lblRutLog.Location = new System.Drawing.Point(158, 84);
            this.lblRutLog.Name = "lblRutLog";
            this.lblRutLog.Size = new System.Drawing.Size(19, 14);
            this.lblRutLog.TabIndex = 156;
            this.lblRutLog.Text = "---";
            this.lblRutLog.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(27, 104);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(125, 25);
            this.btnAgregar.TabIndex = 155;
            this.btnAgregar.Text = "Cambiar Imagen";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pbImaLog
            // 
            this.pbImaLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImaLog.Location = new System.Drawing.Point(27, 22);
            this.pbImaLog.Name = "pbImaLog";
            this.pbImaLog.Size = new System.Drawing.Size(125, 76);
            this.pbImaLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImaLog.TabIndex = 154;
            this.pbImaLog.TabStop = false;
            // 
            // wParametroEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(658, 414);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wParametroEmpresa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wParametroEmpresa_FormClosing);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tpIma.ResumeLayout(false);
            this.tpIma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImaLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpIma;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblRutLog;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.PictureBox pbImaLog;
        private System.Windows.Forms.Button btnActLogEmp;
      
    }
}