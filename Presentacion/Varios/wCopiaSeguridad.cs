using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Comun;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Entidades;
using Negocio;
using Presentacion.Principal;

namespace Presentacion.Varios
{
    public partial class wCopiaSeguridad : Heredados.MiForm8
    {
        public wCopiaSeguridad()
        {
            InitializeComponent();
        }
            
                    
        #region General

        public void InicializaVentana()
        {          
           
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
          
        }

        public void Aceptar()
        { 
            //validar campo vacio
            if (this.ValidaRutaEnBlanco() == false) { return; }

            //generando copia
            this.GenerarCopiaBd();
        
            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se realizo la copia correctamente", "BD");

            //cerrar la ventana
            this.Close();
        }

        public bool ValidaRutaEnBlanco()
        {
            if (txtRutLogEmps.Text == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir una ruta para tu copia", "BD");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void GenerarCopiaBd()
        {
            UsuarioRN iUsuRN = new UsuarioRN();
            iUsuRN.GenerarCopiaSeguridad("LaQuebrada_Almacen", txtRutLogEmps.Text);
        }

        public void SeleccionarUbicacion(TextBox pTextBox)
        {
            FolderBrowserDialog iBuscarRuta = new FolderBrowserDialog();
            if (iBuscarRuta.ShowDialog() == DialogResult.OK)
            {
                pTextBox.Text = iBuscarRuta.SelectedPath;
            }
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteCopiaSeguridadBD, null);
        }

        #endregion

        private void wCopiaSeguridad_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void btnBusLogEmps_Click(object sender, EventArgs e)
        {
            this.SeleccionarUbicacion(this.txtRutLogEmps);
        }
      
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }


                     
    }
}
