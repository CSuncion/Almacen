using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Adicionales;
using WinControles;
using Negocio;
using Entidades;
using WinControles.ControlesWindows;
using Presentacion.Listas;

namespace Presentacion.Sistema
{
    public partial class wCopiarPermiso : Heredados.MiForm8
    {
        public wCopiarPermiso()
        {
            InitializeComponent( );
        }

        //variables   
        Masivo eMas = new Masivo( );


        #region Propietario

        public wUsuario wUsu;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar( );
            xCtrl.txtNoFoco( this.txtCodUsu , this.txtCodUsuCop , "f" );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar( );
            xCtrl.txtNoFoco(this.txtNomUsu, this.txtCodUsuCop, "f");
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodUsuCop,true,"Ingreso Usuario","vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomUsuCop, this.txtCodUsuCop, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnAceptar , "v" );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "v");
            xLis.Add(xCtrl);


            return xLis;
        }

        #endregion

        #region General

        public void NuevaVentana( UsuarioEN pUsu )
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls( );
            eMas.EjecutarTodosLosEventos();
            eMas.AccionHabilitarControles( 0 );

            //Deshabilitar al propietario de esta ventana
            this.wUsu.Enabled = false;                       

            //valores por defecto
            this.ValoresPorDefecto( pUsu );

            //mostrar ventana
            this.Show( );

            //foco
            this.txtCodUsuCop.Focus();    
        }
               
        public void ValoresPorDefecto( UsuarioEN pUsu )
        {
            this.txtCodUsu.Text = pUsu.CodigoUsuario;
            this.txtNomUsu.Text = pUsu.NombreUsuario;
        }
        
        public void ListarUsuarios()
        {
            wLisUsu win = new wLisUsu();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodUsuCop;
            win.eCtrlFoco = this.btnAceptar;
            win.eUsuEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            win.eCondicionLista = Listas.wLisUsu.Condicion.UsuariosActivosExceptoUno;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsUsuarioValido()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.CodigoUsuario = this.txtCodUsuCop.Text.Trim();
            string iCodigoUsuarioExcepcion = this.txtCodUsu.Text.Trim();
            iUsuEN = UsuarioRN.EsUsuarioValido(iUsuEN, iCodigoUsuarioExcepcion);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
                this.txtCodUsuCop.Focus();          
            }
            
            //pasamos los datos
            this.txtCodUsuCop.Text = iUsuEN.CodigoUsuario;
            this.txtNomUsuCop.Text = iUsuEN.NombreUsuario;

            //devolver
            return iUsuEN.Adicionales.EsVerdad;
        }

        public void Aceptar()
        {
            //validar campos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //ejecutar la copia de permisos
            this.CopiarPermisos();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se copiaron los registros correctamente", "Permisos");

            //salir
            this.Close();
        }

        public void CopiarPermisos()
        {
            //asignar parametros
            string iCodigoUsuarioRecibe = this.txtCodUsu.Text.Trim();
            string iCodigoUsuarioDa = this.txtCodUsuCop.Text.Trim();

            //ejecutar metodo
            PermisoUsuarioRN.CopiarPermisos(iCodigoUsuarioRecibe, iCodigoUsuarioDa);
        }

        #endregion


        private void wCopiarPermiso_FormClosing( object sender , FormClosingEventArgs e )
        {
            this.wUsu.Enabled = true;
        }
    
        private void txtCodUsuCop_Validating(object sender, CancelEventArgs e)
        {
            this.EsUsuarioValido();
        }

        private void txtCodUsuCop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarUsuarios(); }
        }

        private void txtCodUsuCop_DoubleClick(object sender, EventArgs e)
        {
            this.ListarUsuarios();
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
