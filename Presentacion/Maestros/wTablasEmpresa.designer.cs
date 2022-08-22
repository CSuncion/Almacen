namespace Presentacion.Maestros
{
    partial class wTablasEmpresa
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
            this.DgvTab = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTitIte = new System.Windows.Forms.Label();
            this.DgvIte = new System.Windows.Forms.DataGridView();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbAdicionar = new System.Windows.Forms.ToolStripButton();
            this.tsbModificar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIte)).BeginInit();
            this.tsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvTab
            // 
            this.DgvTab.BackgroundColor = System.Drawing.Color.White;
            this.DgvTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvTab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTab.GridColor = System.Drawing.Color.Silver;
            this.DgvTab.Location = new System.Drawing.Point(16, 68);
            this.DgvTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgvTab.Name = "DgvTab";
            this.DgvTab.Size = new System.Drawing.Size(641, 267);
            this.DgvTab.TabIndex = 95;
            this.DgvTab.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvIte_CellEnter);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(16, 44);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(641, 19);
            this.label21.TabIndex = 96;
            this.label21.Text = "Tablas";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitIte
            // 
            this.lblTitIte.BackColor = System.Drawing.Color.DarkGray;
            this.lblTitIte.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitIte.ForeColor = System.Drawing.Color.White;
            this.lblTitIte.Location = new System.Drawing.Point(19, 391);
            this.lblTitIte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitIte.Name = "lblTitIte";
            this.lblTitIte.Size = new System.Drawing.Size(638, 19);
            this.lblTitIte.TabIndex = 98;
            this.lblTitIte.Text = "Registros de la tabla";
            this.lblTitIte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvIte
            // 
            this.DgvIte.BackgroundColor = System.Drawing.Color.White;
            this.DgvIte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvIte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvIte.GridColor = System.Drawing.Color.Silver;
            this.DgvIte.Location = new System.Drawing.Point(16, 414);
            this.DgvIte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgvIte.Name = "DgvIte";
            this.DgvIte.Size = new System.Drawing.Size(641, 309);
            this.DgvIte.TabIndex = 97;
            this.DgvIte.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvIte_CellMouseDoubleClick);
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tsPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPrincipal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdicionar,
            this.tsbModificar,
            this.tsbEliminar,
            this.tsbSalir});
            this.tsPrincipal.Location = new System.Drawing.Point(16, 339);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsPrincipal.Size = new System.Drawing.Size(569, 48);
            this.tsPrincipal.Stretch = true;
            this.tsPrincipal.TabIndex = 99;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // tsbAdicionar
            // 
            this.tsbAdicionar.Image = global::Presentacion.Properties.Resources._16__Plus_;
            this.tsbAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdicionar.Name = "tsbAdicionar";
            this.tsbAdicionar.Size = new System.Drawing.Size(71, 45);
            this.tsbAdicionar.Text = "Adicionar";
            this.tsbAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdicionar.Click += new System.EventHandler(this.tsbAdicionar_Click);
            // 
            // tsbModificar
            // 
            this.tsbModificar.Image = global::Presentacion.Properties.Resources._16__Pencil_tool_;
            this.tsbModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbModificar.Name = "tsbModificar";
            this.tsbModificar.Size = new System.Drawing.Size(70, 45);
            this.tsbModificar.Text = "Modificar";
            this.tsbModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbModificar.Click += new System.EventHandler(this.tsbModificar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.Image = global::Presentacion.Properties.Resources._16__Refuse_;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(63, 45);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = global::Presentacion.Properties.Resources.gnome_home;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(39, 45);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // wTablasEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(670, 741);
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.lblTitIte);
            this.Controls.Add(this.DgvIte);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.DgvTab);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "wTablasEmpresa";
            this.Text = "Tablas Empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wTablasEmpresa_FormClosing);
            this.Controls.SetChildIndex(this.DgvTab, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.DgvIte, 0);
            this.Controls.SetChildIndex(this.lblTitIte, 0);
            this.Controls.SetChildIndex(this.tsPrincipal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvIte)).EndInit();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvTab;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTitIte;
        internal System.Windows.Forms.DataGridView DgvIte;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsbAdicionar;
        private System.Windows.Forms.ToolStripButton tsbModificar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.ToolStripButton tsbSalir;

    }
}
