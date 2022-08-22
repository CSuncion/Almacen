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
    public partial class wDetalleIngreso : Heredados.MiForm8
    {
        public wDetalleIngreso()
        {
            InitializeComponent( );
        }


        //variables
        public Universal.Opera eOperacion;
        public int wMoneda = 0;
        Masivo eMas = new Masivo( );
        public List<LoteEN> eLisLotExi = new List<LoteEN>();
        string eTitulo = "Item";
       

        #region Propietario

        public wEditIngreso wEditIng;


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
            xCtrl.TxtNumeroConDecimales(this.txtPreUniCon, true, "Precio Unitario Conversion", "vvff", 5, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPreUniDol, false, "Precio Unitario US$", "vvff", 5, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPreUniMovDet, true, "Precio Unitario S/. ", "vvff", 5, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.TxtNumeroConDecimales( this.txtCanCon , true , "Cantidad Conversion" , "vvff" , 3,12 );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCantMovDet, true, "Cantidad", "vvff", 3, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnLote, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosMovDet, this.txtCantMovDet, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAre, false, "Codigo Area", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAre, this.txtCodAre, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPar, false, "Codigo Partida", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesPar, this.txtCodPar, "ffff");
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
            this.wEditIng.Enabled = false;
            if (wEditIng.txtCodMonSyD.Text == "0")  //Soles
            {
                this.txtPreUniDol.Enabled = false;
            }
            else
            {
                this.txtPreUniDol.Enabled = true;
            }

            //ver ventana
            this.Show( );
        }

        public void LlenarListaLotesExistencia()
        {
            //asignar parametros
            string iCodigoExistenciaGrilla = Dgv.ObtenerValorCelda(this.wEditIng.dgvMovDet, MovimientoDetaEN.CodExi);

            //ejecutar metodo    
            this.eLisLotExi = ListaG.Filtrar<LoteEN>(this.wEditIng.eLisLot, LoteEN.CodExi, iCodigoExistenciaGrilla);
        }

        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Adicionar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMovimientoDeta( MovimientoDetaRN.EnBlanco( ) );                       
            eMas.AccionHabilitarControles( 0 );
            this.CambiarAtributoSoloLecturaACodigoExistencia();
            this.CambiarAtributoSoloLecturaAlCambiarExistencia();
            eMas.AccionPasarTextoPrincipal();
            //Editar Monto US$
            if (this.txtCodMon.Text == "1")
            {
                this.txtPreUniDol.ReadOnly = false;
            }
            else
            {
                this.txtPreUniDol.ReadOnly = true;
            }

            this.txtCodExi.Focus();
        }

        //public void VentanaModificar( MovimientoDetaEN pObj )
        //{          
        //    this.InicializaVentana( );
        //    this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
        //    this.MostrarMovimientoDeta( pObj );
        //    this.LlenarListaLotesExistencia();        
        //    eMas.AccionHabilitarControles( 1 );
        //    //this.HabilitarControlesSegunPropiedadLote(pObj.CodigoTipo);//xxxxxxxxxx
        //    this.CambiarAtributoSoloLecturaACodigoExistencia();
        //    this.CambiarAtributoSoloLecturaAlCambiarExistencia();
        //    eMas.AccionPasarTextoPrincipal();
        //    this.txtCodExi.Focus();
        //}

        public void VentanaModificar(MovimientoDetaEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Modificar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarMovimientoDeta(pObj);
            this.LlenarListaLotesExistencia();
            eMas.AccionHabilitarControles(1);
            this.CambiarAtributoSoloLecturaACantidad();
            this.CambiarAtributoSoloLecturaACodigoExistencia();
            this.CambiarAtributoSoloLecturaAlCambiarExistencia();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodExi.Focus();
        }


        public void VentanaEliminar( MovimientoDetaEN pObj )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Eliminar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMovimientoDeta(pObj);
            this.LlenarListaLotesExistencia();
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void AsignarMovimientoDeta(MovimientoDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.FechaMovimientoCabe = this.wEditIng.dtpFecMovCab.Text;
            pObj.PeriodoMovimientoCabe = this.wEditIng.wIng.lblPeriodo.Text;
            pObj.CodigoAlmacen = this.wEditIng.txtCodAlm.Text.Trim();
            pObj.CodigoTipoOperacion = this.wEditIng.txtCodTipOpe.Text.Trim();
            pObj.CCalculaPrecioPromedio = this.wEditIng.txtCCalPrePro.Text.Trim();
            pObj.CConversionUnidad = this.wEditIng.txtCConUni.Text.Trim();
            pObj.CClaseTipoOperacion = "1";//ingreso
            pObj.NumeroMovimientoCabe = this.wEditIng.txtNumMovCab.Text.Trim();
            pObj.CodigoAuxiliar = this.wEditIng.txtCodAux.Text.Trim();
            pObj.CTipoDocumento = this.wEditIng.txtCTipDoc.Text.Trim();
            pObj.SerieDocumento = this.wEditIng.txtSerDoc.Text.Trim();
            pObj.NumeroDocumento = this.wEditIng.txtNumDoc.Text.Trim();
            pObj.FechaDocumento = this.wEditIng.dtpFecDoc.Text;
            pObj.CCodigoArea = this.txtCodAre.Text.Trim();
            pObj.NCodigoArea = this.txtDesAre.Text.Trim();
            pObj.CCodigoPartida = this.txtCodPar.Text.Trim();
            pObj.NCodigoPartida = this.txtDesPar.Text.Trim();
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.CodigoUnidadMedida = this.txtCUniMed.Text.Trim();
            pObj.NombreUnidadMedida = this.txtNUniMed.Text.Trim();
            pObj.StockAnteriorExistencia = Convert.ToDecimal(this.txtStoAntExi.Text);
            pObj.PrecioAnteriorExistencia = Convert.ToDecimal(this.txtPreAntExi.Text);
            pObj.PrecioUnitarioMovimientoDeta = Convert.ToDecimal(this.txtPreUniMovDet.Text);
            pObj.PrecioUnitarioDolarMovimientoDeta = Convert.ToDecimal(this.txtPreUniDol.Text);
            pObj.CantidadMovimientoDeta = Convert.ToDecimal(this.txtCantMovDet.Text);
            pObj.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(pObj);
            pObj.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(pObj);
            pObj.CostoMovimientoDeta = Convert.ToDecimal(this.txtCosMovDet.Text);
            pObj.GlosaMovimientoDeta = this.txtGloMovDet.Text.Trim();
            pObj.CodigoTipo = this.txtCodTip.Text.Trim();
            pObj.CEsLote = this.txtCEsLot.Text.Trim();
            pObj.CEsUnidadConvertida = this.txtCEsUniCon.Text.Trim();
            pObj.FactorConversion= Convert.ToDecimal(this.txtFacCon.Text);
            pObj.PrecioUnitarioConversion=Convert.ToDecimal(this.txtPreUniCon.Text);
            pObj.CantidadConversion = Convert.ToDecimal(this.txtCanCon.Text);            
            pObj.ClaveMovimientoCabe = this.wEditIng.ObtenerClaveMovimientoCabe();
            pObj.CCodigoMoneda = this.wEditIng.txtCodMonSyD.Text.ToString().Trim();
        }

        public void MostrarMovimientoDeta( MovimientoDetaEN pObj )
        {
            this.txtCodAre.Text = pObj.CCodigoArea;
            this.txtDesAre.Text = pObj.NCodigoArea;
            this.txtCodPar.Text = pObj.CCodigoPartida;
            this.txtDesPar.Text = pObj.NCodigoPartida;
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;            
            this.txtNUniMed.Text = pObj.NombreUnidadMedida;
            this.txtCUniMed.Text = pObj.CodigoUnidadMedida;
            this.txtStoAntExi.Text = Formato.NumeroDecimal(pObj.StockAnteriorExistencia.ToString(), 3);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(pObj.PrecioAnteriorExistencia.ToString(), 5);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal(MovimientoDetaRN.ObtenerPrecioUnitarioSinFlete(pObj), 5);
            this.txtPreUniDol.Text = Formato.NumeroDecimal(pObj.PrecioUnitarioDolarMovimientoDeta.ToString(), 5);
            this.txtCantMovDet.Text = Formato.NumeroDecimal(pObj.CantidadMovimientoDeta.ToString(), 3);
            this.txtCosMovDet.Text = Formato.NumeroDecimal(MovimientoDetaRN.ObtenerCostoSinFlete(pObj), 2);
            this.txtGloMovDet.Text = pObj.GlosaMovimientoDeta;
            this.txtCodTip.Text = pObj.CodigoTipo;
            this.txtCEsLot.Text = pObj.CEsLote;
            this.txtPreUniCon.Text = Formato.NumeroDecimal(pObj.PrecioUnitarioConversion.ToString(), 5);
            this.txtCanCon.Text = Formato.NumeroDecimal(pObj.CantidadConversion.ToString(), 3);
            this.txtCEsUniCon.Text = pObj.CEsUnidadConvertida;
            this.txtFacCon.Text = Formato.NumeroDecimal(pObj.FactorConversion.ToString(), 3);
            this.txtCodMon.Text = this.wEditIng.txtCodMonSyD.Text.ToString().Trim();
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

            //adicionar lotes para la existencia
            this.AdicionarLotesExistencia();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se adiciono el registro" , "Detalle" );

            //actualizar propietario
            this.wEditIng.eClaveDgvMovDet = this.wEditIng.eLisMovDet[this.wEditIng.eLisMovDet.Count - 1].ClaveObjeto;
            this.wEditIng.MostrarMovimientosDeta( );
            this.wEditIng.CambiarSoloLecturaACodigoAlmacen();
            this.wEditIng.CambiarSoloLecturaACodigoTipoOperacion();
            
            //limpiar controles
            this.MostrarMovimientoDeta( MovimientoDetaRN.EnBlanco( ) );
            //this.HabilitarControlesSegunPropiedadLote("");          
            this.CambiarAtributoSoloLecturaACodigoExistencia();
            this.eLisLotExi.Clear();
            eMas.AccionPasarTextoPrincipal( );
            this.txtCodExi.Focus( );                       
        }
        
        public void AdicionarMovimientoDeta()
        {         
            MovimientoDetaEN iComDetEN = new MovimientoDetaEN( );
            this.AsignarMovimientoDeta(iComDetEN);

            //adicionar detalle
            MovimientoDetaRN.AdicionarMovimientoDeta(this.wEditIng.eLisMovDet, iComDetEN); 
        }

        public void AdicionarLotesExistencia()
        {
            this.wEditIng.eLisLot.AddRange(this.eLisLotExi);
        }

        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }
                     
            //modificar detalle
            this.ModificarMovimientoDeta();

            //eliminar lotes anteriores
            this.EliminarLotesExistenciaAnterior();

            //adicionar nuevos lotes
            this.AdicionarLotesExistencia();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wEditIng.eClaveDgvMovDet = this.wEditIng.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditIng.dgvMovDet)].ClaveObjeto;
            this.wEditIng.MostrarMovimientosDeta( );

            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarMovimientoDeta()
        {
            //obtener el objeto de la franja
            MovimientoDetaEN iMovDetEN = this.wEditIng.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditIng.dgvMovDet)];

            //asignar los nuevos valores
            this.AsignarMovimientoDeta(iMovDetEN);

            //actualizar a cero el costoflete
            iMovDetEN.CostoFleteMovimientoDeta = 0;

            //actualizar este objeto en la lista
            ListaG.Modificar<MovimientoDetaEN>(this.wEditIng.eLisMovDet, iMovDetEN, MovimientoDetaEN.CodExi, iMovDetEN.CodigoExistencia);
        }

        public void EliminarLotesExistenciaAnterior()
        {
            //asignar parametros
            string iCodigoExistencia = Dgv.ObtenerValorCelda(this.wEditIng.dgvMovDet, MovimientoDetaEN.CodExi);

            //ejecutar metodo           
            ListaG.Eliminar<LoteEN>(this.wEditIng.eLisLot, LoteEN.CodExi, iCodigoExistencia);           
        }

        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarMovimientoDeta( );

            //eliminar lotes anteriores
            this.EliminarLotesExistenciaAnterior();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //mostra detalle comprobante
            this.wEditIng.MostrarMovimientosDeta( );
            this.wEditIng.CambiarSoloLecturaACodigoAlmacen();
            this.wEditIng.CambiarSoloLecturaACodigoTipoOperacion();

            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarMovimientoDeta()
        {
            this.wEditIng.eLisMovDet.RemoveAt( Dgv.ObtenerIndiceRegistroXFranja( this.wEditIng.dgvMovDet ) );
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
            if (this.txtCodPar.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            win.eCtrlValor = this.txtCodPar;
            win.eCtrlFoco = this.txtGloMovDet;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCentroCostoValido()
        {
            return Generico.EsCodigoItemEActivoValido("CenCos", this.txtCodPar, this.txtDesPar, "Centro costo");
        }

        public bool EsCodigoAreaValido()
        {
            return Generico.EsCodigoItemEActivoValido("CodAre", this.txtCodAre, this.txtDesAre, "Areas");
        }

        public bool EsCodigoPartidaValido()
        {
            return Generico.EsCodigoItemEActivoValido("CodPar", this.txtCodPar, this.txtDesPar, "Partidas");
        }


        public void ListarAreas()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodAre.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Areas";
            win.eCtrlValor = this.txtCodAre;
            win.eCtrlFoco = this.txtCodPar;
            win.eIteEN.CodigoTabla = "CodAre";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void ListarPartidas()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodAre.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Partidas";
            win.eCtrlValor = this.txtCodPar;
            win.eCtrlFoco = this.txtGloMovDet;
            win.eIteEN.CodigoTabla = "CodPar";
            win.eIteEN.CodigoItemE = this.txtCodAre.Text.Trim();
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTablaYArea;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
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
            if (this.wEditIng.txtCodMonSyD.Text == "1")
            {
                win.eCtrlFoco = this.txtPreUniDol;
            }
            else
            {
                win.eCtrlFoco = this.txtPreUniMovDet;
            }            
            win.eExiEN.CodigoAlmacen = this.wEditIng.txtCodAlm.Text.Trim();
            win.eLisMovDet = this.wEditIng.eLisMovDet;
            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaMovimiento;
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
            string iCodigoExistenciaFranjaGrilla = Dgv.ObtenerValorCelda(this.wEditIng.dgvMovDet, MovimientoDetaEN.CodExi);
            List<MovimientoDetaEN> iLisMovDetGrilla = this.wEditIng.eLisMovDet;
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaActivoNoProduccionValido(iExiEN, iOperacionVentana, iCodigoExistenciaFranjaGrilla, iLisMovDetGrilla);
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
            this.txtCEsUniCon.Text = iExiEN.CEsUnidadConvertida;
            this.txtFacCon.Text = Formato.NumeroDecimal(iExiEN.FactorConversion, 3);
            this.txtStoAntExi.Text = Formato.NumeroDecimal(this.ObtenerStockActualExistencia(iExiEN), 3);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(this.ObtenerPrecioActualExistencia(iExiEN), 2);
            this.txtPreUniCon.Text= Formato.NumeroDecimal(this.ObtenerPrecioUnitarioConvertido(), 3);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal(this.ObtenerPrecioUnitario(), 3);
            this.txtCanCon.Text = Formato.NumeroDecimal(this.ObtenerCantidadConvertido(), 3);
            this.txtCantMovDet.Text = Formato.NumeroDecimal(this.ObtenerCantidad(), 3);

            //mostrar costo
            this.MostrarCosto();

            //cambiar atributo solo lectura al cambiar existencia
            this.CambiarAtributoSoloLecturaAlCambiarExistencia();

            //poner el foco
            this.PonerFocoAlCambiarExistencia();

            //devolver
            return iExiEN.Adicionales.EsVerdad;         
        }

        public MovimientoDetaEN ObtenerMovimientoDetaFranjaGrilla()
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //si la grilla esta llena, toma al objeto
            if (this.wEditIng.eLisMovDet.Count != 0)
            {
                iMovDetEN = this.wEditIng.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditIng.dgvMovDet)];
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

        public decimal ObtenerPrecioUnitario()
        {
            //asignar parametros          
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerPrecioUnitarioSugerido(iMovDetEN);
        }

        public decimal ObtenerPrecioUnitarioConvertido()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerPrecioUnitarioConvertidoSugerido(iMovDetEN);
        }

        public void CambiarAtributoSoloLecturaAPrecioUnitario()
        {            
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoDetaRN.EsActoDigitarPrecioUnitario(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtPreUniMovDet, !iValor);
        }
        
        public ExistenciaEN NuevaExistenciaVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.wEditIng.txtCodAlm.Text.Trim();
            iExiEN.DescripcionAlmacen = this.wEditIng.txtDesAlm.Text.Trim();
            iExiEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public void HabilitarControlesSegunPropiedadLote(string pCEsLote)
        {
            //obtener el valor de veracidad de este flag
            bool iValor = Conversion.CadenaABoolean(pCEsLote, false);

            //cambiamos el atributo del control
            Txt.SoloEscritura3(this.txtCantMovDet, iValor);
            this.btnLote.Enabled = iValor;

            //ahora saber si se debe limpiar el valor que tiene "txtCantMovDet" solo si es readonly
            //si la existencia tiene lotes registrados, entonces el valor "txtCantMovDet"
            //no se limpia 
            List<LoteEN> iLisLotExi = LoteRN.FiltrarLotes(this.wEditIng.eLisLot, LoteEN.CodExi, this.txtCodExi.Text);
            if (this.txtCantMovDet.ReadOnly == true && iLisLotExi.Count == 0)
            {
                this.txtCantMovDet.Text = Txt.ObtenerValorXDefecto(this.txtCantMovDet);
            }
        }

        public void InstanciarLotes()
        {
            wLote win = new wLote();
            win.wDetIng = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void CambiarAtributoSoloLecturaACodigoExistencia()
        {
            if (this.txtCantMovDet.ReadOnly == true && Conversion.ADecimal(this.txtCantMovDet.Text, 0) != 0)
            {
                this.txtCodExi.ReadOnly = true;
            }
            else
            {
                this.txtCodExi.ReadOnly = false;
            }
        }

        public void CambiarAtributoSoloLecturaAPrecioUnitarioConversion()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoDetaRN.EsActoDigitarPrecioUnitarioConversion(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtPreUniCon, !iValor);
        }

        public void CambiarAtributoSoloLecturaACantidadConversion()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoDetaRN.EsActoDigitarCantidadConversion(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtCanCon, !iValor);
        }

        public void CambiarAtributoSoloLecturaACantidad()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoDetaRN.EsActoDigitarCantidad(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtCantMovDet, !iValor);
        }

        public void CambiarAtributoHabilitarALote()
        {
            //obtener el valor de veracidad de este flag
            bool iValor = Conversion.CadenaABoolean(this.txtCEsLot.Text.Trim(), false);

            //cambiamos el atributo del control            
            this.btnLote.Enabled = iValor;
        }

        public void MostrarPrecioUnitarioCalculado()
        {
            //valida cuando el control es readOnly
            if (this.txtPreUniCon.ReadOnly == true) { return; }

            //obtener valor
            decimal iValor = this.ObtenerPrecioUnitario();

            //mostrar en pantalla
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal(iValor, 5);
        }

        public decimal ObtenerCantidadConvertido()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerCantidadConvertidoSugerido(iMovDetEN);
        }

        public decimal ObtenerCantidad()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);
            List<LoteEN> iLisLotExi = ListaG.Filtrar<LoteEN>(this.wEditIng.eLisLot, LoteEN.CodExi, this.txtCodExi.Text);

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerCantidadSugerido(iMovDetEN, iLisLotExi);
        }

        public void MostrarCantidadCalculado()
        {
            //valida cuando el control es readOnly
            if (this.txtCanCon.ReadOnly == true) { return; }

            //obtener valor
            decimal iValor = this.ObtenerCantidad();

            //mostrar en pantalla
            this.txtCantMovDet.Text = Formato.NumeroDecimal(iValor, 3);
        }

        public void CambiarAtributoSoloLecturaAlCambiarExistencia()
        {
            this.CambiarAtributoSoloLecturaAPrecioUnitarioConversion();
            this.CambiarAtributoSoloLecturaAPrecioUnitario();            
            this.CambiarAtributoSoloLecturaACantidadConversion();
            this.CambiarAtributoSoloLecturaACantidad();
            this.CambiarAtributoHabilitarALote();
        }

        public void AccionCambiarPrecioUnitarioConversion()
        {
            this.MostrarPrecioUnitarioCalculado();
            this.MostrarCosto();
        }

        public void AccionCambiarCantidadConversion()
        {
            this.MostrarCantidadCalculado();
            this.MostrarCosto();
        }

        public void PonerFocoAlCambiarExistencia()
        {
            if (this.txtCodExi.Text.Trim() == string.Empty) { return; }
            if (this.txtPreUniCon.ReadOnly == false) { this.txtPreUniCon.Focus();return; }
            if (this.txtPreUniDol.ReadOnly == false) { this.txtPreUniDol.Focus(); return; }
            if (this.txtPreUniMovDet.ReadOnly == false) { this.txtPreUniMovDet.Focus(); return; }
            if (this.txtCanCon.ReadOnly == false) { this.txtCanCon.Focus(); return; }
            if (this.txtCantMovDet.ReadOnly == false) { this.txtCantMovDet.Focus(); return; }
            if (this.btnLote.Enabled == true) { this.btnLote.Focus(); return; }
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
            this.wEditIng.Enabled = true;
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
            this.MostrarCosto();
        }

        private void txtPreUni_Validated(object sender, EventArgs e)
        {
            this.MostrarCosto();
        } 

        private void btnLote_Click(object sender, EventArgs e)
        {
            this.InstanciarLotes();
        }

        private void txtPreUniCon_Validated(object sender, EventArgs e)
        {
            this.AccionCambiarPrecioUnitarioConversion();
        }

        private void txtCanCon_Validated(object sender, EventArgs e)
        {
            this.AccionCambiarCantidadConversion();
        }
        
        private void txtCodAre_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAreas();            
        }

        private void txtCodAre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAreas(); }
        }

        private void txtCodAre_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoAreaValido();
        }

        private void txtCodPar_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPartidas();
        }

        private void txtCodPar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPartidas(); }
        }

        private void txtCodPar_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoPartidaValido();

        }

        private void txtPreUniDol_Validated(object sender, EventArgs e)
        {
            if (this.txtCodMon.Text == "1")
            {
                decimal tc = 0 , precio = 0;
                tc = Convert.ToDecimal( this.wEditIng.txtTipCam.Text);
                precio = Convert.ToDecimal(this.txtPreUniDol.Text);
                this.txtPreUniMovDet.Text = Formato.NumeroDecimal((precio * tc).ToString(),5);                
            }            
        }
    }
}
