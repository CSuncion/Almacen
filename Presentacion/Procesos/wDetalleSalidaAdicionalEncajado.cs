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

namespace Presentacion.Procesos
{
    public partial class wDetalleSalidaAdicionalEncajado : Heredados.MiForm8
    {
        public wDetalleSalidaAdicionalEncajado()
        {
            InitializeComponent( );
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Item";

        #endregion

        #region Propietario

        public wEditSalidaAdicionalEncajado wEditSalAdiEnc;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;
                    
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Existencia", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCodExi, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNUniMed, this.txtCodExi, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPreUniMovDet, true, "Precio Unitario", "vvff", 2,12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.TxtNumeroConDecimales( this.txtCantMovDet , true , "Cantidad" , "vvff" , 5,12 );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosMovDet, this.txtCantMovDet, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCenCos, false, "Centro Costo", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCenCos, this.txtCodCenCos, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.TxtTodo( this.txtGloMovDet , false , "Glosa" , "vvff" );
            xLis.Add( xCtrl );
            
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
            this.wEditSalAdiEnc.Enabled = false;

            //ver ventana
            this.Show( );
        }
        
        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Adicionar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMovimientoDeta( MovimientoDetaRN.EnBlanco( ) );                       
            eMas.AccionHabilitarControles( 0 );
            eMas.AccionPasarTextoPrincipal( );
            this.CambiarAtributoSoloLecturaAPrecioUnitario();
            this.txtCodExi.Focus();
        }
        
        public void VentanaModificar( MovimientoDetaEN pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMovimientoDeta( pObj );           
            eMas.AccionHabilitarControles( 1 );
            eMas.AccionPasarTextoPrincipal( );
            this.CambiarAtributoSoloLecturaAPrecioUnitario();
            this.txtCodExi.Focus();
        }
        
        public void VentanaEliminar( MovimientoDetaEN pObj )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Eliminar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMovimientoDeta(pObj);          
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void AsignarMovimientoDeta(MovimientoDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.FechaMovimientoCabe = this.wEditSalAdiEnc.dtpFecMovCab.Text;
            pObj.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(pObj.FechaMovimientoCabe, "-");
            pObj.CodigoAlmacen = this.wEditSalAdiEnc.txtCodAlm.Text.Trim();
            pObj.CodigoTipoOperacion = this.wEditSalAdiEnc.txtCodTipOpe.Text.Trim();
            pObj.CCalculaPrecioPromedio = this.wEditSalAdiEnc.txtCCalPrePro.Text.Trim();
            pObj.CClaseTipoOperacion = "2";//salida
            pObj.NumeroMovimientoCabe = this.wEditSalAdiEnc.txtNumMovCab.Text.Trim();           
            pObj.CodigoCentroCosto = this.txtCodCenCos.Text.Trim();
            pObj.DescripcionCentroCosto = this.txtDesCenCos.Text.Trim();
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.CodigoUnidadMedida = this.txtCUniMed.Text.Trim();
            pObj.NombreUnidadMedida = this.txtNUniMed.Text.Trim();
            pObj.StockAnteriorExistencia = Convert.ToDecimal(this.txtStoAntExi.Text);
            pObj.PrecioAnteriorExistencia = Convert.ToDecimal(this.txtPreAntExi.Text);
            pObj.PrecioUnitarioMovimientoDeta = Convert.ToDecimal(this.txtPreUniMovDet.Text);
            pObj.CantidadMovimientoDeta = Convert.ToDecimal(this.txtCantMovDet.Text);
            pObj.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(pObj);
            pObj.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(pObj);
            pObj.CostoMovimientoDeta = Convert.ToDecimal(this.txtCosMovDet.Text);
            pObj.GlosaMovimientoDeta = this.txtGloMovDet.Text.Trim();
            pObj.CodigoTipo = this.txtCodTip.Text.Trim();
            pObj.CEsLote = this.txtCEsLot.Text.Trim();
            pObj.PrecioUnitarioProduccion = pObj.PrecioUnitarioMovimientoDeta;
            pObj.ClaveMovimientoCabe = this.wEditSalAdiEnc.ObtenerClaveMovimientoCabe();
        }

        public void MostrarMovimientoDeta( MovimientoDetaEN pObj )
        {
            this.txtCodCenCos.Text = pObj.CodigoCentroCosto;
            this.txtDesCenCos.Text = pObj.DescripcionCentroCosto;
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;            
            this.txtNUniMed.Text = pObj.NombreUnidadMedida;
            this.txtCUniMed.Text = pObj.CodigoUnidadMedida;
            this.txtStoAntExi.Text = Formato.NumeroDecimal(pObj.StockAnteriorExistencia.ToString(), 5);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(pObj.PrecioAnteriorExistencia.ToString(), 5);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal( pObj.PrecioUnitarioMovimientoDeta.ToString( ) , 5 );
            this.txtCantMovDet.Text = Formato.NumeroDecimal(pObj.CantidadMovimientoDeta.ToString(), 5);
            this.txtCosMovDet.Text = Formato.NumeroDecimal(pObj.CostoMovimientoDeta.ToString(), 5);
            this.txtGloMovDet.Text = pObj.GlosaMovimientoDeta;
            this.txtCodTip.Text = pObj.CodigoTipo;
            this.txtCEsLot.Text = pObj.CEsLote;
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

            //adicionar MovimientoDeta
            this.AdicionarMovimientoDeta( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se adiciono el registro" , "Detalle" );

            //actualizar propietario
            this.wEditSalAdiEnc.eClaveDgvMovDet = this.wEditSalAdiEnc.eLisMovDet[this.wEditSalAdiEnc.eLisMovDet.Count - 1].ClaveObjeto;
            this.wEditSalAdiEnc.MostrarMovimientosDeta( );
            this.wEditSalAdiEnc.CambiarSoloLecturaACodigoAlmacen();

            //limpiar controles
            this.MostrarMovimientoDeta( MovimientoDetaRN.EnBlanco( ) );          
            eMas.AccionPasarTextoPrincipal( );
            this.txtCodExi.Focus( );                       
        }
        
        public void AdicionarMovimientoDeta()
        {         
            MovimientoDetaEN iComDetEN = new MovimientoDetaEN( );
            this.AsignarMovimientoDeta(iComDetEN);

            //adicionar detalle
            MovimientoDetaRN.AdicionarMovimientoDeta(this.wEditSalAdiEnc.eLisMovDet, iComDetEN); 
        }
        
        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }
                     
            //modificar detalle
            this.ModificarMovimientoDeta();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wEditSalAdiEnc.eClaveDgvMovDet = this.wEditSalAdiEnc.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditSalAdiEnc.dgvMovDet)].ClaveObjeto;
            this.wEditSalAdiEnc.MostrarMovimientosDeta( );

            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarMovimientoDeta()
        {           
            this.AsignarMovimientoDeta( this.wEditSalAdiEnc.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja( this.wEditSalAdiEnc.dgvMovDet )] );
        }
        
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarMovimientoDeta( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //mostra detalle comprobante
            this.wEditSalAdiEnc.MostrarMovimientosDeta( );
            this.wEditSalAdiEnc.CambiarSoloLecturaACodigoAlmacen();

            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarMovimientoDeta()
        {
            this.wEditSalAdiEnc.eLisMovDet.RemoveAt( Dgv.ObtenerIndiceRegistroXFranja( this.wEditSalAdiEnc.dgvMovDet ) );
        }
      
        public void MostrarCosto()
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);
            this.txtCosMovDet.Text = Formato.NumeroDecimal(MovimientoDetaRN.ObtenerCosto(iMovDetEN).ToString(), 2);
        }

        public void ListarCentrosCostos()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodCenCos.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            win.eCtrlValor = this.txtCodCenCos;
            win.eCtrlFoco = this.txtGloMovDet;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCentroCostoValido()
        {
            return Generico.EsCodigoItemEActivoValido("CenCos", this.txtCodCenCos, this.txtDesCenCos, "Centro costo");
        }

        public void ListarExistencias()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExi.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias";
            win.eCtrlValor = this.txtCodExi;
            win.eCtrlFoco = this.txtCantMovDet;           
            win.eLisMovDet = this.wEditSalAdiEnc.eLisMovDet;
            win.eCodigoAlmacenIngreso = this.wEditSalAdiEnc.txtCodAlm.Text.Trim();
            win.eProProTerEN = this.wEditSalAdiEnc.wSalAdiEnc.wCanAdiEnc.EsProduccionProTerExistente();
            win.eCondicionLista = wLisExi.Condicion.ListarExistenciasParaEncajadoNoSeleccionadasEnGrilla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodExi.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = this.NuevaExistenciaVentana();
            string iCodigoExistenciaFranjaGrilla = Dgv.ObtenerValorCelda(this.wEditSalAdiEnc.dgvMovDet, MovimientoDetaEN.CodExi);
            List<MovimientoDetaEN> iLisMovDetGrilla = this.wEditSalAdiEnc.eLisMovDet;
            Universal.Opera iOperacionVentana = this.eOperacion;
            ProduccionProTerEN iProProTerEN = this.wEditSalAdiEnc.wSalAdiEnc.wCanAdiEnc.EsProduccionProTerExistente();

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaActivoParaEncajadoValido(iExiEN, iOperacionVentana, iCodigoExistenciaFranjaGrilla,
                iProProTerEN, iLisMovDetGrilla);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia");
                this.txtCodExi.Focus();
            }

            //pasar datos
            this.txtCodExi.Text = iExiEN.CodigoExistencia;
            this.txtDesExi.Text = iExiEN.DescripcionExistencia;
            this.txtCUniMed.Text = iExiEN.CodigoUnidadMedida;
            this.txtNUniMed.Text = iExiEN.NombreUnidadMedida;
            this.txtCodTip.Text = iExiEN.CodigoTipo;
            this.txtCEsLot.Text = iExiEN.CEsLote;
            this.txtStoAntExi.Text = Formato.NumeroDecimal(this.ObtenerStockActualExistencia(iExiEN), 5);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(this.ObtenerPrecioActualExistencia(iExiEN), 5);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal(this.ObtenerPrecioUnitario(iExiEN), 5);

            //mostrar costo
            this.MostrarCosto();

            //devolver
            return iExiEN.Adicionales.EsVerdad;         
        }

        public MovimientoDetaEN ObtenerMovimientoDetaFranjaGrilla()
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //si la grilla esta llena, toma al objeto
            if (this.wEditSalAdiEnc.eLisMovDet.Count != 0)
            {
                iMovDetEN = this.wEditSalAdiEnc.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditSalAdiEnc.dgvMovDet)];
            }

            //retornar
            return iMovDetEN;
        }

        public decimal ObtenerStockActualExistencia(ExistenciaEN pObj)
        {
            //asignar parametros
            ExistenciaEN iExiBDEN = pObj;
            MovimientoDetaEN iMovDetGriEN = this.ObtenerMovimientoDetaFranjaGrilla();
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerStockAnteriorExistenciaPorDigitacion(iExiBDEN, iMovDetGriEN, iOperacionVentana);
        }

        public decimal ObtenerPrecioActualExistencia(ExistenciaEN pObj)
        {
            //asignar parametros
            ExistenciaEN iExiBDEN = pObj;
            MovimientoDetaEN iMovDetGriEN = this.ObtenerMovimientoDetaFranjaGrilla();
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerPrecioAnteriorExistenciaPorDigitacion(iExiBDEN, iMovDetGriEN, iOperacionVentana);
        }

        public decimal ObtenerPrecioUnitario(ExistenciaEN pObj)
        {
            //asignar parametros
            decimal iPrecioPromedioExistencia = pObj.PrecioPromedioExistencia;
            string iCCalculaPrecioPromedio = this.wEditSalAdiEnc.txtCCalPrePro.Text.Trim();
            string iCodigoExistenciaAModificar = Dgv.ObtenerValorCelda(this.wEditSalAdiEnc.dgvMovDet, MovimientoDetaEN.CodExi);
            string iCodigoExistenciaActual = this.txtCodExi.Text.Trim();
            decimal iPrecioUnitarioAnterior = Convert.ToDecimal(this.txtPreUniMovDet.Text);

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerPrecioUnitarioSugerido(iPrecioPromedioExistencia, iCCalculaPrecioPromedio, iCodigoExistenciaAModificar,
                                                                    iCodigoExistenciaActual, iPrecioUnitarioAnterior);
        }

        public void CambiarAtributoSoloLecturaAPrecioUnitario()
        {
            //obtener el flag si debe o no calcular precio promedio
            string iCCalculaPrecioPromedio = this.wEditSalAdiEnc.txtCCalPrePro.Text.Trim();

            //obtener el valor de veracidad de este flag
            bool iValor = Conversion.CadenaABoolean(iCCalculaPrecioPromedio, false);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtPreUniMovDet, !iValor);
        }
        
        public ExistenciaEN NuevaExistenciaVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.wEditSalAdiEnc.txtCodAlm.Text.Trim();
            iExiEN.DescripcionAlmacen = this.wEditSalAdiEnc.txtDesAlm.Text.Trim();
            iExiEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public bool EsCantidadCorrecta()
        {
            //solo si esta habilitado el control
            if (this.txtCantMovDet.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros  
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            iMovDetEN = MovimientoDetaRN.EsCantidadAdicionalMovimientoDetaCorrecta(iMovDetEN);
            if (iMovDetEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovDetEN.Adicionales.Mensaje, "Cantidad");
                this.txtCantMovDet.Focus();
            }

            //mostrar costo
            this.MostrarCosto();

            //devolver
            return iMovDetEN.Adicionales.EsVerdad;
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

        private void wDetalleSalidaAdicional_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEditSalAdiEnc.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistencias(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistencias();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValido();
        }

        private void txtCant_Validated(object sender, EventArgs e)
        {
            //this.EsCantidadCorrecta();
        }

        private void txtPreUni_Validated(object sender, EventArgs e)
        {
            this.MostrarCosto();
        }

        private void txtCodCenCos_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCentroCostoValido();
        }

        private void txtCodCenCos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCentrosCostos(); }
        }

        private void txtCodCenCos_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCentrosCostos();
        }

    }
}
