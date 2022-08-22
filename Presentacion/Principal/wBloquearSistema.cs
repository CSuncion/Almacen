using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Negocio;
using Entidades;
using Comun;
using Entidades.Adicionales;

namespace Presentacion.Principal
{
    public partial class wBloquearSistema : Form
    {
        public wBloquearSistema()
        {
            InitializeComponent();
        }

        Masivo eMas = new Masivo();

        #region Propietario

        public wMenu wMen;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUsu, this.txtClaUsu, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtClaUsu, true, "Contraseña", "f");
            xLis.Add(xCtrl);
                        
            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnIngresar, "f");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana()
        {
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.ValoresXDefecto();        
            this.txtClaUsu.Focus();
            this.ShowDialog();
        }

        public void ValoresXDefecto()
        {
            this.txtUsu.Text = Universal.gCodigoUsuario + " : " + Universal.gNombreUsuario;
        }

        public bool EsClaveDeUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.CodigoUsuario = Universal.gCodigoUsuario;           
            iUsuEN.ClaveUsuario = Encriptacion.Encriptar(this.txtClaUsu.Text.Trim());
            iUsuEN = UsuarioRN.EsContrasenaDeUsuario(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Clave");
                this.txtClaUsu.Clear();
                this.txtClaUsu.Focus();
            }
            return iUsuEN.Adicionales.EsVerdad;
        }

        public void Ingresar()
        {
            //chequear campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //comprobar si la clave es correcta     
            if (this.EsClaveDeUsuario() == false) { return; }

            //habilitamos el menu principal
            if (this.wMen.tbcContenedor.TabPages.Count != 0)
            {
                this.wMen.tbcContenedor.Visible = true;
                this.wMen.BackColor = Color.LightYellow;
            }          
            this.Close();
        }

        #endregion

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Ingresar();
        }
    }
}
