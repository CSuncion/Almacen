namespace Presentacion.Maestros
{
    partial class wEditTipoOperacion
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
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodTipOpe = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstTipOpe = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDesTipOpe = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbClaTipOpe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCalPrePro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCConUni = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Codigo:";
            // 
            // txtCodTipOpe
            // 
            this.txtCodTipOpe.Location = new System.Drawing.Point(142, 55);
            this.txtCodTipOpe.MaxLength = 2;
            this.txtCodTipOpe.Name = "txtCodTipOpe";
            this.txtCodTipOpe.Size = new System.Drawing.Size(32, 22);
            this.txtCodTipOpe.TabIndex = 53;
            this.txtCodTipOpe.Validated += new System.EventHandler(this.txtCodTipOpe_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 198);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstTipOpe
            // 
            this.cmbEstTipOpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstTipOpe.Location = new System.Drawing.Point(142, 195);
            this.cmbEstTipOpe.Name = "cmbEstTipOpe";
            this.cmbEstTipOpe.Size = new System.Drawing.Size(105, 22);
            this.cmbEstTipOpe.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 14);
            this.label15.TabIndex = 61;
            this.label15.Text = "Descripcion:";
            // 
            // txtDesTipOpe
            // 
            this.txtDesTipOpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesTipOpe.Location = new System.Drawing.Point(142, 83);
            this.txtDesTipOpe.MaxLength = 100;
            this.txtDesTipOpe.Name = "txtDesTipOpe";
            this.txtDesTipOpe.Size = new System.Drawing.Size(286, 22);
            this.txtDesTipOpe.TabIndex = 62;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(319, 231);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(205, 231);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(23, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(405, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbClaTipOpe
            // 
            this.cmbClaTipOpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClaTipOpe.Location = new System.Drawing.Point(142, 111);
            this.cmbClaTipOpe.Name = "cmbClaTipOpe";
            this.cmbClaTipOpe.Size = new System.Drawing.Size(85, 22);
            this.cmbClaTipOpe.TabIndex = 76;
            this.cmbClaTipOpe.SelectionChangeCommitted += new System.EventHandler(this.cmbClaTipOpe_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 75;
            this.label1.Text = "Clase:";
            // 
            // cmbCalPrePro
            // 
            this.cmbCalPrePro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCalPrePro.Location = new System.Drawing.Point(142, 139);
            this.cmbCalPrePro.Name = "cmbCalPrePro";
            this.cmbCalPrePro.Size = new System.Drawing.Size(46, 22);
            this.cmbCalPrePro.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 77;
            this.label2.Text = "Calcula Pre.Pro";
            // 
            // cmbCConUni
            // 
            this.cmbCConUni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCConUni.Location = new System.Drawing.Point(142, 167);
            this.cmbCConUni.Name = "cmbCConUni";
            this.cmbCConUni.Size = new System.Drawing.Size(46, 22);
            this.cmbCConUni.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 14);
            this.label3.TabIndex = 79;
            this.label3.Text = "Convierte Unidad";
            // 
            // wEditTipoOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(453, 281);
            this.Controls.Add(this.cmbCConUni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCalPrePro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClaTipOpe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtDesTipOpe);
            this.Controls.Add(this.cmbEstTipOpe);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodTipOpe);
            this.Name = "wEditTipoOperacion";
            this.Text = "Edit Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditTipoOperacion_FormClosing);
            this.Controls.SetChildIndex(this.txtCodTipOpe, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbEstTipOpe, 0);
            this.Controls.SetChildIndex(this.txtDesTipOpe, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbClaTipOpe, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbCalPrePro, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbCConUni, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodTipOpe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstTipOpe;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDesTipOpe;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbClaTipOpe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCalPrePro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCConUni;
        private System.Windows.Forms.Label label3;
    }
}
