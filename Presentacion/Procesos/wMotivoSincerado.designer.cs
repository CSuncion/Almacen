namespace Presentacion.Procesos
{
    partial class wMotivoSincerado
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.DgvBot = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCanRan = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPorRan = new System.Windows.Forms.TextBox();
            this.txtNUniMed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodExi = new System.Windows.Forms.TextBox();
            this.txtDesExi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCorProCab = new System.Windows.Forms.TextBox();
            this.txtCanProCab = new System.Windows.Forms.TextBox();
            this.txtDesAlm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodAlm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUniRep = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCanOri = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(495, 414);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(109, 25);
            this.btnSalir.TabIndex = 71;
            this.btnSalir.Text = "Cancelar";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(21, 381);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(109, 25);
            this.btnAgregar.TabIndex = 72;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.DarkGray;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(22, 226);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(583, 14);
            this.lblTitulo.TabIndex = 74;
            this.lblTitulo.Text = "Motivos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvBot
            // 
            this.DgvBot.BackgroundColor = System.Drawing.Color.White;
            this.DgvBot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvBot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBot.GridColor = System.Drawing.Color.Silver;
            this.DgvBot.Location = new System.Drawing.Point(21, 243);
            this.DgvBot.Name = "DgvBot";
            this.DgvBot.Size = new System.Drawing.Size(584, 132);
            this.DgvBot.TabIndex = 96;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(136, 381);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(109, 25);
            this.btnQuitar.TabIndex = 98;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(380, 414);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 99;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCanRan
            // 
            this.txtCanRan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCanRan.Location = new System.Drawing.Point(222, 194);
            this.txtCanRan.MaxLength = 0;
            this.txtCanRan.Name = "txtCanRan";
            this.txtCanRan.Size = new System.Drawing.Size(89, 22);
            this.txtCanRan.TabIndex = 458;
            this.txtCanRan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(59, 197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 14);
            this.label14.TabIndex = 457;
            this.label14.Text = "Cantidad Rango(Envasado)";
            // 
            // txtPorRan
            // 
            this.txtPorRan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPorRan.Location = new System.Drawing.Point(464, 166);
            this.txtPorRan.MaxLength = 0;
            this.txtPorRan.Name = "txtPorRan";
            this.txtPorRan.ReadOnly = true;
            this.txtPorRan.Size = new System.Drawing.Size(89, 22);
            this.txtPorRan.TabIndex = 456;
            this.txtPorRan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNUniMed
            // 
            this.txtNUniMed.Location = new System.Drawing.Point(222, 138);
            this.txtNUniMed.Name = "txtNUniMed";
            this.txtNUniMed.ReadOnly = true;
            this.txtNUniMed.Size = new System.Drawing.Size(102, 22);
            this.txtNUniMed.TabIndex = 455;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 454;
            this.label1.Text = "Unidad Medida";
            // 
            // txtCodExi
            // 
            this.txtCodExi.Location = new System.Drawing.Point(222, 110);
            this.txtCodExi.MaxLength = 15;
            this.txtCodExi.Name = "txtCodExi";
            this.txtCodExi.ReadOnly = true;
            this.txtCodExi.Size = new System.Drawing.Size(102, 22);
            this.txtCodExi.TabIndex = 453;
            // 
            // txtDesExi
            // 
            this.txtDesExi.Location = new System.Drawing.Point(325, 110);
            this.txtDesExi.Name = "txtDesExi";
            this.txtDesExi.ReadOnly = true;
            this.txtDesExi.Size = new System.Drawing.Size(228, 22);
            this.txtDesExi.TabIndex = 452;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 451;
            this.label2.Text = "Formula";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 14);
            this.label9.TabIndex = 450;
            this.label9.Text = "Numero";
            // 
            // txtCorProCab
            // 
            this.txtCorProCab.Location = new System.Drawing.Point(222, 54);
            this.txtCorProCab.MaxLength = 16;
            this.txtCorProCab.Name = "txtCorProCab";
            this.txtCorProCab.ReadOnly = true;
            this.txtCorProCab.Size = new System.Drawing.Size(89, 22);
            this.txtCorProCab.TabIndex = 449;
            // 
            // txtCanProCab
            // 
            this.txtCanProCab.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCanProCab.Location = new System.Drawing.Point(222, 166);
            this.txtCanProCab.MaxLength = 0;
            this.txtCanProCab.Name = "txtCanProCab";
            this.txtCanProCab.Size = new System.Drawing.Size(89, 22);
            this.txtCanProCab.TabIndex = 448;
            this.txtCanProCab.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCanProCab.Validated += new System.EventHandler(this.txtCanProCab_Validated);
            // 
            // txtDesAlm
            // 
            this.txtDesAlm.Location = new System.Drawing.Point(253, 82);
            this.txtDesAlm.MaxLength = 3;
            this.txtDesAlm.Name = "txtDesAlm";
            this.txtDesAlm.ReadOnly = true;
            this.txtDesAlm.Size = new System.Drawing.Size(300, 22);
            this.txtDesAlm.TabIndex = 447;
            this.txtDesAlm.Tag = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 14);
            this.label5.TabIndex = 446;
            this.label5.Text = "Almacen";
            // 
            // txtCodAlm
            // 
            this.txtCodAlm.Location = new System.Drawing.Point(222, 82);
            this.txtCodAlm.MaxLength = 3;
            this.txtCodAlm.Name = "txtCodAlm";
            this.txtCodAlm.ReadOnly = true;
            this.txtCodAlm.Size = new System.Drawing.Size(30, 22);
            this.txtCodAlm.TabIndex = 445;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 14);
            this.label3.TabIndex = 444;
            this.label3.Text = "Cantidad Sincerado(Uni)";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(583, 14);
            this.label4.TabIndex = 459;
            this.label4.Text = "Datos Solicitud";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(387, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 14);
            this.label13.TabIndex = 460;
            this.label13.Text = "% Rango";
            // 
            // txtUniRep
            // 
            this.txtUniRep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUniRep.Location = new System.Drawing.Point(464, 194);
            this.txtUniRep.MaxLength = 0;
            this.txtUniRep.Name = "txtUniRep";
            this.txtUniRep.ReadOnly = true;
            this.txtUniRep.Size = new System.Drawing.Size(89, 22);
            this.txtUniRep.TabIndex = 462;
            this.txtUniRep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(317, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 14);
            this.label12.TabIndex = 461;
            this.label12.Text = "Cantidad Reproceso(Uni)";
            // 
            // txtCanOri
            // 
            this.txtCanOri.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCanOri.Location = new System.Drawing.Point(464, 138);
            this.txtCanOri.MaxLength = 0;
            this.txtCanOri.Name = "txtCanOri";
            this.txtCanOri.ReadOnly = true;
            this.txtCanOri.Size = new System.Drawing.Size(89, 22);
            this.txtCanOri.TabIndex = 463;
            this.txtCanOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(337, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 14);
            this.label6.TabIndex = 464;
            this.label6.Text = "Cantidad Real(Uni)";
            // 
            // wMotivoSincerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(626, 464);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCanOri);
            this.Controls.Add(this.txtUniRep);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCanRan);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPorRan);
            this.Controls.Add(this.txtNUniMed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodExi);
            this.Controls.Add(this.txtDesExi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCorProCab);
            this.Controls.Add(this.txtCanProCab);
            this.Controls.Add(this.txtDesAlm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodAlm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.DgvBot);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Calibri", 8.75F);
            this.Name = "wMotivoSincerado";
            this.Text = "Cantidad Sincerado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wMotivoSincerado_FormClosing);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.DgvBot, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtCodAlm, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDesAlm, 0);
            this.Controls.SetChildIndex(this.txtCanProCab, 0);
            this.Controls.SetChildIndex(this.txtCorProCab, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtDesExi, 0);
            this.Controls.SetChildIndex(this.txtCodExi, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNUniMed, 0);
            this.Controls.SetChildIndex(this.txtPorRan, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtCanRan, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtUniRep, 0);
            this.Controls.SetChildIndex(this.txtCanOri, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnQuitar;
        internal System.Windows.Forms.DataGridView DgvBot;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCanRan;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPorRan;
        private System.Windows.Forms.TextBox txtNUniMed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodExi;
        private System.Windows.Forms.TextBox txtDesExi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCorProCab;
        private System.Windows.Forms.TextBox txtCanProCab;
        internal System.Windows.Forms.TextBox txtDesAlm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodAlm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUniRep;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCanOri;
        private System.Windows.Forms.Label label6;
    }
}
