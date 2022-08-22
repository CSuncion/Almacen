using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heredados;
using WinControles;
using Entidades.Adicionales;
using Negocio;
using Comun;
using Entidades;
using WinControles.ControlesWindows;
using Presentacion.Principal;

namespace Presentacion.Sistema
{
    public partial class wCambiarClave : MiForm8
    {
        public wCambiarClave()
        {
            InitializeComponent();
        }

        Masivo eMas = new Masivo();

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUsu, this.txtClaAct, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtLetrasYNumerosSinEspacion(this.txtClaAct, true, "Clave actual", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtLetrasYNumerosSinEspacion(this.txtClaNue, true, "Nueva clave", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtLetrasYNumerosSinEspacion(this.txtClaCon, true, "Confirmar clave", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "f");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana()
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //Mostrar ventana
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.ValoresXDefecto();        
            this.txtClaAct.Focus();        
        }

        public void ValoresXDefecto()
        {
            this.txtUsu.Text = Universal.gCodigoUsuario + " : " + Universal.gNombreUsuario;
        }

        public void EsContrasenaCorrecta()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.CodigoUsuario = Universal.gCodigoUsuario;
            iUsuEN.ClaveUsuario = Encriptacion.Encriptar(this.txtClaAct.Text.Trim());
            iUsuEN = UsuarioRN.EsContrasenaDeUsuario(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Clave");
                this.txtClaAct.Clear();
                this.txtClaAct.Focus();
            }
        }

        public void Aceptar()
        {
            //validar que no alla campos vacios
            if (eMas.CamposObligatorios() == false) { return; }

            //validar que la clave nueva y confirmar sean iguales
            if (Txt.CompararTextos(this.txtClaNue, this.txtClaCon, "Las claves") == false) { return; }

            //modificar la clave del usuario
            this.ModificarUsuario();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Su clave se modifico correctamente", "Clave");

            //cerrar ventana
            this.Close();
        }

        public void ModificarUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.CodigoUsuario = Universal.gCodigoUsuario;
            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(iUsuEN);
            //modificar solo la clave
            iUsuEN.ClaveUsuario = Encriptacion.Encriptar(this.txtClaNue.Text.Trim());
            UsuarioRN.ModificarUsuario(iUsuEN);
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.ItecambioDeClave, null);         
        }

        #endregion

        private void txtClaAct_Validated(object sender, EventArgs e)
        {
            this.EsContrasenaCorrecta();
        }

        private void txtClaNue_Validated(object sender, EventArgs e)
        {
            Txt.ValidarLongitudTexto(this.txtClaNue, 6, 20, false);
        }

        private void txtClaCon_Validated(object sender, EventArgs e)
        {
            Txt.ValidarLongitudTexto(this.txtClaNue, 6, 20, false);
        }

        private void wCambiarClave_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     


    }
}
