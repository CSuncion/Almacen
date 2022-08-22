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
    public partial class wDetalleTransferencia : Heredados.MiForm8
    {
        public wDetalleTransferencia()
        {
            InitializeComponent( );
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Item";

        #endregion
     
        #region Propietario

        public wEditTransferencia wEditTra;

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
            xCtrl.TxtNumeroConDecimales(this.txtPreUniMovDet, true, "Precio Unitario", "vvff", 3,12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.TxtNumeroConDecimales( this.txtCantMovDet , true , "Cantidad" , "vvff" , 3,12 );
            xLis.Add( xCtrl );

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
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls( );
            eMas.EjecutarTodosLosEventos( );
            
            //deshabilita propietario
            this.wEditTra.Enabled = false;

            //ver ventana
            this.Show( );
        }
        
        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );           
            this.MostrarMovimientoDeta( MovimientoDetaRN.EnBlanco( ) );                       
            eMas.AccionHabilitarControles( 0 );
            eMas.AccionPasarTextoPrincipal( );
            this.CambiarAtributoSoloLecturaAPrecioUnitario();
            this.txtCodExi.Focus();
        }
        
        public void VentanaModificar( MovimientoDetaEN pObj )
        {          
            this.InicializaVentana( );           
            this.MostrarMovimientoDeta( pObj );           
            eMas.AccionHabilitarControles( 1 );
            eMas.AccionPasarTextoPrincipal( );
            this.CambiarAtributoSoloLecturaAPrecioUnitario();
            this.txtCodExi.Focus();
        }
        
        public void VentanaEliminar( MovimientoDetaEN pObj )
        {
            this.InicializaVentana( );           
            this.MostrarMovimientoDeta(pObj);          
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void AsignarMovimientoDeta(MovimientoDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.FechaMovimientoCabe = this.wEditTra.dtpFecMovCab.Text;
            pObj.PeriodoMovimientoCabe = this.wEditTra.wTra.lblPeriodo.Text;
            pObj.CodigoAlmacen = this.wEditTra.txtCodAlm.Text.Trim();
            pObj.CodigoTipoOperacion = this.wEditTra.txtCodTipOpe.Text.Trim();
            pObj.CCalculaPrecioPromedio = this.wEditTra.txtCCalPrePro.Text.Trim();
            pObj.CClaseTipoOperacion = "2";//salida
            pObj.NumeroMovimientoCabe = this.wEditTra.txtNumMovCab.Text.Trim();
            pObj.CCodigoArea = this.txtCodAre.Text.Trim();
            pObj.NCodigoPartida = this.txtDesAre.Text.Trim();
            pObj.CCodigoPartida = this.txtCodPar.Text.Trim();
            pObj.NCodigoPartida = this.txtDesPar.Text.Trim();
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
            pObj.CEsLote = this.txtCEsLot.Text.Trim();           
            pObj.ClaveMovimientoCabe = this.wEditTra.ObtenerClaveMovimientoCabeSalida();
            pObj.ClaveMovimientoDeta = Dgv.ObtenerValorCelda(this.wEditTra.dgvMovDet, MovimientoDetaEN.ClaObj);
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
            this.txtPreAntExi.Text = Formato.NumeroDecimal(pObj.PrecioAnteriorExistencia.ToString(), 3);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal( pObj.PrecioUnitarioMovimientoDeta.ToString( ) , 3 );
            this.txtCantMovDet.Text = Formato.NumeroDecimal(pObj.CantidadMovimientoDeta.ToString(), 3);
            this.txtCosMovDet.Text = Formato.NumeroDecimal(pObj.CostoMovimientoDeta.ToString(), 2);
            this.txtGloMovDet.Text = pObj.GlosaMovimientoDeta;
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
            this.wEditTra.eClaveDgvMovDet = this.wEditTra.eLisMovDet[this.wEditTra.eLisMovDet.Count - 1].ClaveObjeto;
            this.wEditTra.MostrarMovimientosDetaSalida( );
            this.wEditTra.CambiarSoloLecturaACodigoAlmacenSalida();           
            this.wEditTra.CambiarSoloLecturaACodigoAlmacenIngreso();
          
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
            MovimientoDetaRN.AdicionarMovimientoDeta(this.wEditTra.eLisMovDet, iComDetEN); 
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
            this.wEditTra.eClaveDgvMovDet = this.wEditTra.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditTra.dgvMovDet)].ClaveObjeto;
            this.wEditTra.MostrarMovimientosDetaSalida( );

            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarMovimientoDeta()
        {           
            this.AsignarMovimientoDeta( this.wEditTra.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja( this.wEditTra.dgvMovDet )] );
        }
        
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarMovimientoDeta( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //mostra detalle comprobante
            this.wEditTra.MostrarMovimientosDetaSalida( );
            this.wEditTra.CambiarSoloLecturaACodigoAlmacenSalida();           
            this.wEditTra.CambiarSoloLecturaACodigoAlmacenIngreso();
           
            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarMovimientoDeta()
        {
            this.wEditTra.eLisMovDet.RemoveAt( Dgv.ObtenerIndiceRegistroXFranja( this.wEditTra.dgvMovDet ) );
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
            if (this.txtCodAre.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            win.eCtrlValor = this.txtCodAre;
            win.eCtrlFoco = this.txtGloMovDet;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
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

        public bool EsCodigoCentroCostoValido()
        {
            return Generico.EsCodigoItemEActivoValido("CenCos", this.txtCodAre, this.txtDesAre, "Centro costo");
        }

        public bool EsCodigoAreaValido()
        {
            return Generico.EsCodigoItemEActivoValido("CodAre", this.txtCodAre, this.txtDesAre, "Areas");
        }

        public bool EsCodigoPartidaValido()
        {
            return Generico.EsCodigoItemEActivoValido("CodPar", this.txtCodPar, this.txtDesPar, "Partidas");
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
            win.eCodigoAlmacenSalida = this.wEditTra.txtCodAlm.Text.Trim();
            win.eCodigoAlmacenIngreso = this.wEditTra.txtCodAlm1.Text.Trim();
            win.eLisMovDet = this.wEditTra.eLisMovDet;
            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivosDeAlmacenNoSeleccionadasTransferencia;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodExi.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiSalEN = this.NuevaExistenciaSalidaVentana();
            ExistenciaEN iExiIngEN = this.NuevaExistenciaIngresoVentana();
            string iCodigoExistenciaFranjaGrilla = Dgv.ObtenerValorCelda(this.wEditTra.dgvMovDet, MovimientoDetaEN.CodExi);
            List<MovimientoDetaEN> iLisMovDetGrilla = this.wEditTra.eLisMovDet;
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iExiSalEN = ExistenciaRN.EsExistenciaActivoValido(iExiSalEN, iExiIngEN, iOperacionVentana, iCodigoExistenciaFranjaGrilla, iLisMovDetGrilla);
            if (iExiSalEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiSalEN.Adicionales.Mensaje, "Existencia");
                this.txtCodExi.Focus();
            }

            //pasar datos
            this.txtCodExi.Text = iExiSalEN.CodigoExistencia;
            this.txtDesExi.Text = iExiSalEN.DescripcionExistencia;
            this.txtCUniMed.Text = iExiSalEN.CodigoUnidadMedida;
            this.txtNUniMed.Text = iExiSalEN.NombreUnidadMedida;
            this.txtCEsLot.Text = iExiSalEN.CEsLote;
            this.txtStoAntExi.Text = Formato.NumeroDecimal(this.ObtenerStockActualExistencia(iExiSalEN), 3);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(this.ObtenerPrecioActualExistencia(iExiSalEN), 3);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal(this.ObtenerPrecioUnitario(iExiSalEN), 3);

            //mostrar costo
            this.MostrarCosto();

            //devolver
            return iExiSalEN.Adicionales.EsVerdad;         
        }

        public MovimientoDetaEN ObtenerMovimientoDetaFranjaGrilla()
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //si la grilla esta llena, toma al objeto
            if (this.wEditTra.eLisMovDet.Count != 0)
            {
                iMovDetEN = this.wEditTra.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditTra.dgvMovDet)];
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
            string iCCalculaPrecioPromedio = this.wEditTra.txtCCalPrePro.Text.Trim();
            string iCodigoExistenciaAModificar = Dgv.ObtenerValorCelda(this.wEditTra.dgvMovDet, MovimientoDetaEN.CodExi);
            string iCodigoExistenciaActual = this.txtCodExi.Text.Trim();
            decimal iPrecioUnitarioAnterior = Convert.ToDecimal(this.txtPreUniMovDet.Text);

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerPrecioUnitarioSugerido(iPrecioPromedioExistencia, iCCalculaPrecioPromedio, iCodigoExistenciaAModificar,
                                                                    iCodigoExistenciaActual, iPrecioUnitarioAnterior);
        }

        public void CambiarAtributoSoloLecturaAPrecioUnitario()
        {
            //obtener el flag si debe o no calcular precio promedio
            string iCCalculaPrecioPromedio = this.wEditTra.txtCCalPrePro.Text.Trim();

            //obtener el valor de veracidad de este flag
            bool iValor = Conversion.CadenaABoolean(iCCalculaPrecioPromedio, false);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtPreUniMovDet, !iValor);
        }
        
        public ExistenciaEN NuevaExistenciaSalidaVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.wEditTra.txtCodAlm.Text.Trim();
            iExiEN.DescripcionAlmacen = this.wEditTra.txtDesAlm.Text.Trim();
            iExiEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public ExistenciaEN NuevaExistenciaIngresoVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.wEditTra.txtCodAlm1.Text.Trim();
            iExiEN.DescripcionAlmacen = this.wEditTra.txtDesAlm1.Text.Trim();
            iExiEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public bool EsCantidadMovimientoDetaCorrecto()
        {
            //solo si esta habilitado el control
            if (this.txtCantMovDet.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros  
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);
            string iCodigoAlmacenIngreso = this.wEditTra.txtCodAlm1.Text.Trim();

            //ejecutar metodo
            iMovDetEN = MovimientoDetaRN.EsCantidadTransferenciaMovimientoDetaCorrecta(iMovDetEN, iCodigoAlmacenIngreso);
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

        private void wDetalleTransferencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEditTra.Enabled = true;
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
            this.EsCantidadMovimientoDetaCorrecto();
        }

        private void txtPreUni_Validated(object sender, EventArgs e)
        {
            this.MostrarCosto();
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
    }
}
