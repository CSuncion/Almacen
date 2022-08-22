using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Entidades.Adicionales;
using WinControles.ControlesWindows;
using Entidades;
using Negocio;
using Comun;
using Presentacion.Listas;
using Presentacion.Procesos;
using Presentacion.FuncionesGenericas;

namespace Presentacion.ProcesosCompras
{
    public partial class wEditLoteSolPedido : Heredados.MiForm8
    {
        public wEditLoteSolPedido()
        {
            InitializeComponent( );
        }


        //variables
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo( );           
        string eTitulo = "Lote";
       

        #region Propietario

        public wLoteSolPedido wLot;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;
            
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodLot, this.dtpFecVenLot, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecVenLot, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecProLot, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumLot, true, "Numero Lote", "vvff", 50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.TxtNumeroConDecimales( this.txtStoConLot , false , "Cantidad Conversion" , "vvff" , 3,12 );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtStoLot, true, "Cantidad", "vvff", 3, 12);
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
            eMas.EjecutarTodosLosEventos( );
            
            //deshabilita propietario
            this.wLot.Enabled = false;

            //ver ventana
            this.Show( );
        }
        
        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Adicionar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarLote( LoteRN.EnBlanco( ) );                                   
            eMas.AccionHabilitarControles( 0 );
            this.CambiarAtributoSoloLecturaACantidadConversion();
            this.CambiarAtributoSoloLecturaACantidad();
            eMas.AccionPasarTextoPrincipal( );          
            this.dtpFecVenLot.Focus();
        }
        
        public void VentanaModificar( LoteEN pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarLote( pObj );           
            eMas.AccionHabilitarControles( 1 );
            this.CambiarAtributoSoloLecturaACantidadConversion();
            this.CambiarAtributoSoloLecturaACantidad();
            eMas.AccionPasarTextoPrincipal( );           
            this.dtpFecVenLot.Focus();
        }
        
        public void VentanaEliminar( LoteEN pObj )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Eliminar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarLote(pObj);          
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void AsignarLote(LoteEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAlmacen = this.wLot.wDetSolPedido.wEditIng.txtCodAlm.Text.Trim();
            pObj.CodigoExistencia = this.wLot.wDetSolPedido.txtCodExi.Text.Trim();
            pObj.DescripcionExistencia = this.wLot.wDetSolPedido.txtDesExi.Text.Trim();
            pObj.CodigoLote = this.txtCodLot.Text.Trim();
            pObj.FechaVencimientoLote = this.dtpFecVenLot.Text;
            pObj.NumeroLote = this.txtNumLot.Text.Trim();
            pObj.FechaProduccionLote = this.dtpFecProLot.Text;
            pObj.StockConversionLote = Convert.ToDecimal(this.txtStoConLot.Text);
            pObj.StockLote = Convert.ToDecimal(this.txtStoLot.Text);
            pObj.StockSaldoLote = pObj.StockLote;
            pObj.ClaveLote = LoteRN.ObtenerClaveLote(pObj);
        }

        public void MostrarLote( LoteEN pObj )
        {
            this.txtCodLot.Text = pObj.CodigoLote;
            this.dtpFecVenLot.Text = pObj.FechaVencimientoLote;
            this.txtNumLot.Text = pObj.NumeroLote;
            this.dtpFecProLot.Text = pObj.FechaProduccionLote;
            this.txtStoConLot.Text = Formato.NumeroDecimal(pObj.StockConversionLote.ToString(), 3);
            this.txtStoLot.Text = Formato.NumeroDecimal(pObj.StockLote.ToString(), 3);
        }
               
        public void Aceptar( )
        {
            switch ( this.eOperacion )
            {
                case Universal.Opera.Adicionar: { this.Adicionar( ); break; }
                case Universal.Opera.Modificar: { this.Modificar( ); break; }
                case Universal.Opera.Eliminar: { this.Eliminar( ); break; }
                default: break;
            }
        }

        public void Adicionar( )
        {
            //validar los campos obligatorios
            if ( eMas.CamposObligatorios( ) == false ) { return; }

            //mostrar codigolote autogenerado
            this.MostrarNuevoCodigoLote();

            //adicionar 
            this.AdicionarLote( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se adiciono el registro" , "Detalle" );

            //actualizar propietario
            this.wLot.eClaveDgvLot = this.ObtenerClaveLoteDeVentana();
            this.wLot.MostrarLotes( );
            this.wLot.MostrarCantidadTotal();
            this.MostrarCantidadEnWDetalleIngreso();
            this.wLot.wDetSolPedido.CambiarAtributoSoloLecturaACodigoExistencia();
            this.wLot.wDetSolPedido.MostrarCosto();

            //limpiar controles
            this.MostrarLote( LoteRN.EnBlanco( ) );          
            eMas.AccionPasarTextoPrincipal( );
            this.dtpFecVenLot.Focus( );                       
        }

        public void MostrarNuevoCodigoLote()
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            this.AsignarLote(iLotEN);
            List<LoteEN> iLisLot = this.wLot.wDetSolPedido.eLisLotExi;

            //ejecutar metodo
            this.txtCodLot.Text = LoteRN.ObtenerNuevoCodigoLoteAutogenerado(iLotEN, iLisLot);
        }

        public void AdicionarLote()
        {
            LoteEN iLotEN = new LoteEN( );
            this.AsignarLote(iLotEN);

            //adicionar detalle
            LoteRN.AdicionarLote(this.wLot.wDetSolPedido.eLisLotExi, iLotEN); 
        }
        
        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }
                     
            //modificar detalle
            this.ModificarLote();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wLot.eClaveDgvLot = this.ObtenerClaveLoteDeVentana();
            this.wLot.MostrarLotes( );
            this.wLot.MostrarCantidadTotal();
            this.MostrarCantidadEnWDetalleIngreso();
            this.wLot.wDetSolPedido.MostrarCosto();

            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarLote()
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            this.AsignarLote(iLotEN);

            //ejecutar metodo
            LoteRN.ModificarLote(this.wLot.wDetSolPedido.eLisLotExi, iLotEN);
        }
        
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarLote( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //mostra detalle comprobante
            this.wLot.MostrarLotes( );
            this.wLot.MostrarCantidadTotal();
            this.MostrarCantidadEnWDetalleIngreso();
            this.wLot.wDetSolPedido.CambiarAtributoSoloLecturaACodigoExistencia();
            this.wLot.wDetSolPedido.MostrarCosto();

            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarLote()
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            this.AsignarLote(iLotEN);

            //ejecutar metodo
            LoteRN.EliminarLote(this.wLot.wDetSolPedido.eLisLotExi, iLotEN);
        }
      
        public string ObtenerClaveLoteDeVentana()
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            this.AsignarLote(iLotEN);

            //devolver
            return iLotEN.ClaveLote;
        }

        public void MostrarCantidadEnWDetalleIngreso()
        {
            this.wLot.wDetSolPedido.txtCantMovDet.Text = Formato.NumeroDecimal(Dgv.SumarColumna(this.wLot.dgvLot, LoteEN.StoLot), 3);
            this.wLot.wDetSolPedido.txtCanCon.Text = Formato.NumeroDecimal(Dgv.SumarColumna(this.wLot.dgvLot, LoteEN.StoConLot), 3);
        }

        public void CambiarAtributoSoloLecturaACantidadConversion()
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            this.wLot.wDetSolPedido.AsignarSolicitudPedidoDeta(iMovDetEN);
            iMovDetEN.CEsLote = "0";//solo para que evite el primer if de la funcion

            //ejecutar metodo
            bool iValor = SolicitudPedidoDetaRN.EsActoDigitarCantidadConversion(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtStoConLot, !iValor);
        }

        public void CambiarAtributoSoloLecturaACantidad()
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            this.wLot.wDetSolPedido.AsignarSolicitudPedidoDeta(iMovDetEN);
            iMovDetEN.CEsLote = "0";//solo para que evite el primer if de la funcion

            //ejecutar metodo
            bool iValor = SolicitudPedidoDetaRN.EsActoDigitarCantidad(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtStoLot, !iValor);
        }

        public decimal ObtenerCantidad()
        {
            //asignar parametros
            decimal iCantidadConvertida = Conversion.ADecimal(this.txtStoConLot.Text, 0);
            decimal iFactorConversion = Conversion.ADecimal(this.wLot.wDetSolPedido.txtFacCon.Text, 0);
            

            //ejecutar metodo
            return iCantidadConvertida * iFactorConversion;
        }

        public void MostrarCantidadCalculado()
        {
            //valida cuando el control es readOnly
            if (this.txtStoConLot.ReadOnly == true) { return; }

            //obtener valor
            decimal iValor = this.ObtenerCantidad();

            //mostrar en pantalla
            this.txtStoLot.Text = Formato.NumeroDecimal(iValor, 5);
        }

        public void MostrarCantidadConvertidaCalculado()
        {
            //valida cuando el control es readOnly
            if (this.txtStoLot.ReadOnly == true) { return; }

            //obtener valor
            decimal iValor = 0;

            //mostrar en pantalla
            this.txtStoConLot.Text = Formato.NumeroDecimal(iValor, 3);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.eTitulo);
        }

        #endregion


        private void btnCancelar_Click( object sender , EventArgs e )
        {
            this.Cancelar( );
        }

        private void wDetalleIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wLot.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }

        private void txtStoConLot_Validated(object sender, EventArgs e)
        {
            this.MostrarCantidadCalculado();
        }

        private void txtStoLot_Validated(object sender, EventArgs e)
        {
            this.MostrarCantidadConvertidaCalculado();
        }
    }
}
