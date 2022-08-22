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
using Entidades;
using Negocio;
using Comun;
using WinControles.ControlesWindows;
using Presentacion.Listas;
using Presentacion.Impresiones;
using Presentacion.FuncionesGenericas;

namespace Presentacion.ProcesosCompras
{
    public partial class wModificarPagos : Heredados.MiForm4
    {
        public wModificarPagos()
        {
            InitializeComponent( );
        }

        //variables        
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo( );
        string eTitulo = "Pago";
   
        #region Propietario

        public wPagos wCob;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar( );
            xCtrl.txtNoFoco( this.txtCorCob , this.txtCodBan , "ffff" );
            xLis.Add( xCtrl );   

            xCtrl = new ControlEditar( );
            xCtrl.TxtTodo( this.txtCodBan , true , "Banco" , "vfff" );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar( );
            xCtrl.txtNoFoco(this.txtNomBan, this.txtCodBan, "ffff");
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtMonCue, this.txtCodBan, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtObs, false, "Observacion", "vfff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnAceptar , "vvvf" );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnCancelar , "vvvv" );
            xLis.Add( xCtrl );

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana( )
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls( );
            eMas.EjecutarTodosLosEventos();

            // Deshabilitar al propietario de esta ventana
            this.wCob.Enabled = false;
            
            // Mostrar ventana          
            this.Show( );
        }

        public void ValoresXDefecto( PagoEN pCob )
        {        
            this.txtCorCob.Text = pCob.CorrelativoPago; 
        }

        public void NuevaVentana( PagoEN pCob )
        {
            this.InicializaVentana( );
            this.ValoresXDefecto( pCob );
            this.MostrarPago(pCob);
            eMas.AccionHabilitarControles( 0 );           
            eMas.AccionPasarTextoPrincipal( );         
            this.txtCodBan.Focus( );
        }
  
        public void AsignarPago( PagoEN pCob )
        {
            pCob.CorrelativoPago = this.txtCorCob.Text.Trim();
            pCob.ClaveCuentaBanco = this.txtClaCtaBco.Text.Trim();
            pCob.ObservacionPago = this.txtObs.Text.Trim();
        }

        public void MostrarPago( PagoEN pCob )
        {
            this.txtCodBan.Text = pCob.NumeroCuentaBanco;
            this.txtNomBan.Text = pCob.NombreBanco;
            this.txtMonCue.Text = pCob.NMonedaCuentaBanco;
            this.txtClaCtaBco.Text = pCob.ClaveCuentaBanco;
            this.txtObs.Text = pCob.ObservacionPago;
        }

        public void Aceptar( )
        {        
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }
        
            //desea realizar la operacion?
            if( Mensaje.DeseasRealizarOperacion( this.eTitulo ) == false ) { return; }
            
            //modificar Pago
            this.ModificarPago();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se realizo la Pago","Pago");
                        
            //actualizar wLet
            //this.wCob.eClaveDgvCob = Dgv.ObtenerValorCelda(this.wCob.dgvCob, PagoEN.ClaObj);
            this.wCob.ActualizarDgvPag( );

            //cerrar ventana
            this.Close( );
        }

        public void ModificarPago()
        {
            PagoEN iCobEN = new PagoEN();
            this.AsignarPago(iCobEN);
            iCobEN = PagoRN.BuscarPagoXCorrelativo(iCobEN);
            this.AsignarPago(iCobEN);
            PagoRN.ModificarPago(iCobEN);        
        }
                   
        public void Cancelar( )
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }

        public void ListarCuentaBanco()
        {
            //solo se ejecuta cuando adiciona o modifica
            if (this.eOperacion != Universal.Opera.Adicionar && this.eOperacion != Universal.Opera.Modificar) { return; }

            //instanciar
            //wLisCueBan win = new wLisCueBan();
            //win.eVentana = this;
            //win.eTituloVentana = "Cuentas Bancarias";
            //win.eCtrlValor = this.txtCodBan;
            //win.eCtrlFoco = this.txtObs;
            //win.eCondicionLista = Listas.wLisCueBan.Condicion.CuentasActivas;
            //TabCtrl.InsertarVentana(this, win);
            //win.NuevaVentana();
        }

        public bool EsCuentaBancoValida()
        {
            //solo se ejecuta cuando adiciona o modifica
            if (this.eOperacion != Universal.Opera.Adicionar && this.eOperacion != Universal.Opera.Modificar) { return true; }

            //validar el codigo proyecto
            //CuentaBancoEN iCueBanEN = new CuentaBancoEN();
            //iCueBanEN.NumeroCuentaBanco = this.txtCodBan.Text.Trim();
            //iCueBanEN = CuentaBancoRN.EsCuentaBancoValidoXNumero(iCueBanEN);
            //if (iCueBanEN.Adicionales.EsVerdad == false)
            //{
            //    Mensaje.OperacionDenegada(iCueBanEN.Adicionales.Mensaje, "Cuenta");
            //    this.txtCodBan.Focus();
            //}

            //mostrar datos
            //this.txtCodBan.Text = iCueBanEN.NumeroCuentaBanco;
            //this.txtClaCtaBco.Text = iCueBanEN.ClaveCuentaBanco;
            //this.txtNomBan.Text = iCueBanEN.NombreBanco;
            //this.txtMonCue.Text = iCueBanEN.NMonedaCuentaBanco;

            //devolver
            //return iCueBanEN.Adicionales.EsVerdad;
            return true;
        }
        
   
     
        #endregion
        

        private void wModificarPagos_FormClosing( object sender , FormClosingEventArgs e )
        {
            this.wCob.Enabled = true;
        }

        private void btnCancelar_Click( object sender , EventArgs e )
        {
            this.Close( );
        }
        
        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }

        private void txtCodBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCuentaBanco(); }
        }

        private void txtCodBan_Validating(object sender, CancelEventArgs e)
        {
            this.EsCuentaBancoValida();
        }

        private void txtCodBan_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCuentaBanco();
        }

       
      


    }
}
