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
using Presentacion.ProcesosCompras;
using Presentacion.FuncionesGenericas;

namespace Presentacion.ProcesosCompras
{
    public partial class wDetalleOrdenServicio : Heredados.MiForm8
    {
        public wDetalleOrdenServicio()
        {
            InitializeComponent();
        }


        //variables
        string eNombreColumnaDgvPer = PresupuestoEN.CodPre;
        public Universal.Opera eOperacion;
        public int wMoneda = 0;
        Masivo eMas = new Masivo();
        public List<LoteEN> eLisLotExi = new List<LoteEN>();
        string eTitulo = "Item";
        public List<PresupuestoEN> eLisPre = new List<PresupuestoEN>();
        string eCodAre = string.Empty;
        decimal eCan = 0;
        MovimientoOCDetaEN eMovDet = new MovimientoOCDetaEN();
        decimal precioMatAcc = 0;

        #region Propietario

        public wEditOrdenServicio wEditOrdSer;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
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

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanCon, true, "Cantidad Conversion", "vvff", 3, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCantMovDet, true, "Cantidad", "vvff", 3, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosMovDet, this.txtCantMovDet, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPresupuesto, true, "Presupuesto", "ffff", 3, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtSaldoPresupuesto, true, "Nuevo Presupuesto", "ffff", 3, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGloMovDet, false, "Glosa", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
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

            //deshabilita propietario
            this.wEditOrdSer.Enabled = false;
            if (wEditOrdSer.txtCodMonSyD.Text == "0")  //Soles
            {
                this.txtPreUniDol.Enabled = false;
                this.txtPreUniMovDet.Enabled = true;
            }
            else
            {
                this.txtPreUniDol.Enabled = true;
                this.txtPreUniMovDet.Enabled = false;
            }

            //ver ventana
            this.Show();
        }

        public void LlenarListaLotesExistencia()
        {
            //asignar parametros
            string iCodigoExistenciaGrilla = Dgv.ObtenerValorCelda(this.wEditOrdSer.dgvMovDet, MovimientoOCDetaEN.CodExi);

        }

        public void VentanaAdicionar(decimal precioMaterialAccesorio)
        {
            this.precioMatAcc = precioMaterialAccesorio;
            this.InicializaVentana();
            this.Text = Universal.Opera.Adicionar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarMovimientoDeta(MovimientoOCDetaRN.EnBlanco());
            eMas.AccionHabilitarControles(0);
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
            this.ValidacionCostoOrdenServicio();
            this.txtCodExi.Focus();
        }

        //public void VentanaModificar( MovimientoOCDetaEN pObj )
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

        public void VentanaModificar(MovimientoOCDetaEN pObj, decimal precioMaterialAccesorio)
        {
            this.precioMatAcc = precioMaterialAccesorio;
            this.eMovDet = pObj;
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

            this.CargarPresupuesto();

            //retorna presupuesto
            this.RetornarPresupuesto();

            //this.CargarPresupuesto();
            this.MostrarCosto();
            this.ValidacionCostoOrdenServicio();
        }


        public void VentanaEliminar(MovimientoOCDetaEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Eliminar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarMovimientoDeta(pObj);
            this.LlenarListaLotesExistencia();
            eMas.AccionHabilitarControles(2);
            eMas.AccionPasarTextoPrincipal();
            this.btnAceptar.Focus();

            this.CargarPresupuesto();

            //retorna presupuesto
            this.RetornarPresupuesto();
            //this.CargarPresupuesto();
            this.MostrarCosto();
            this.ValidacionCostoOrdenServicio();
        }

        public void AsignarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.FechaMovimientoCabe = this.wEditOrdSer.dtpFecMovCab.Text;
            pObj.PeriodoMovimientoCabe = this.wEditOrdSer.wOrdSer.lblPeriodo.Text;
            pObj.CodigoAlmacen = "A90";
            pObj.CodigoTipoOperacion = "79";
            pObj.CCalculaPrecioPromedio = "0";
            pObj.CConversionUnidad = "0";
            pObj.CClaseTipoOperacion = "4";//orden de compra
            pObj.NumeroMovimientoCabe = this.wEditOrdSer.txtNumMovCab.Text.Trim();
            pObj.CodigoAuxiliar = this.wEditOrdSer.txtCodAux.Text.Trim();
            pObj.CTipoDocumento = string.Empty;
            pObj.SerieDocumento = string.Empty;
            pObj.NumeroDocumento = string.Empty;
            pObj.FechaDocumento = string.Empty;
            pObj.CodigoCentroCosto = this.wEditOrdSer.txtCodAre.Text.Trim();
            pObj.DescripcionCentroCosto = this.wEditOrdSer.txtDesAre.Text.Trim();
            pObj.CCodigoPartida = string.Empty;
            pObj.NCodigoPartida = string.Empty;
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.CodigoUnidadMedida = this.txtCUniMed.Text.Trim();
            pObj.NombreUnidadMedida = this.txtNUniMed.Text.Trim();
            pObj.StockAnteriorExistencia = Convert.ToDecimal(this.txtStoAntExi.Text);
            pObj.PrecioAnteriorExistencia = Convert.ToDecimal(this.txtPreAntExi.Text);
            pObj.PrecioUnitarioMovimientoDeta = Convert.ToDecimal(this.txtPreUniMovDet.Text);
            pObj.PrecioUnitarioDolarMovimientoDeta = Convert.ToDecimal(this.txtPreUniDol.Text);
            pObj.CantidadMovimientoDeta = Convert.ToDecimal(this.txtCantMovDet.Text);
            pObj.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(pObj);
            pObj.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(pObj);
            pObj.CostoMovimientoDeta = Convert.ToDecimal(this.txtCosMovDet.Text);
            pObj.GlosaMovimientoDeta = this.txtGloMovDet.Text.Trim();
            pObj.CodigoTipo = this.txtCodTip.Text.Trim();
            pObj.CEsLote = this.txtCEsLot.Text.Trim();
            pObj.CEsUnidadConvertida = this.txtCEsUniCon.Text.Trim();
            pObj.FactorConversion = Convert.ToDecimal(this.txtFacCon.Text);
            pObj.PrecioUnitarioConversion = Convert.ToDecimal(this.txtPreUniCon.Text);
            pObj.CantidadConversion = Convert.ToDecimal(this.txtCanCon.Text);
            pObj.ClaveMovimientoCabe = this.wEditOrdSer.ObtenerClaveMovimientoCabe();
            pObj.CCodigoMoneda = this.wEditOrdSer.txtCodMonSyD.Text.ToString().Trim();
        }

        public void MostrarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;
            this.txtNUniMed.Text = pObj.NombreUnidadMedida;
            this.txtCUniMed.Text = pObj.CodigoUnidadMedida;
            this.txtStoAntExi.Text = Formato.NumeroDecimal(pObj.StockAnteriorExistencia.ToString(), 3);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(pObj.PrecioAnteriorExistencia.ToString(), 5);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal(MovimientoOCDetaRN.ObtenerPrecioUnitarioSinFlete(pObj), 5);
            this.txtPreUniDol.Text = Formato.NumeroDecimal(pObj.PrecioUnitarioDolarMovimientoDeta.ToString(), 5);
            this.txtCantMovDet.Text = Formato.NumeroDecimal(pObj.CantidadMovimientoDeta.ToString(), 3);
            this.txtCosMovDet.Text = Formato.NumeroDecimal(MovimientoOCDetaRN.ObtenerCostoSinFlete(pObj), 2);
            this.txtGloMovDet.Text = pObj.GlosaMovimientoDeta;
            this.txtCodTip.Text = pObj.CodigoTipo;
            this.txtCEsLot.Text = pObj.CEsLote;
            this.txtPreUniCon.Text = Formato.NumeroDecimal(pObj.PrecioUnitarioConversion.ToString(), 5);
            this.txtCanCon.Text = Formato.NumeroDecimal(pObj.CantidadConversion.ToString(), 3);
            this.txtCEsUniCon.Text = pObj.CEsUnidadConvertida;
            this.txtFacCon.Text = Formato.NumeroDecimal(pObj.FactorConversion.ToString(), 3);
            this.txtCodMon.Text = this.wEditOrdSer.txtCodMonSyD.Text.ToString().Trim();
            this.txtPresupuesto.Text = Formato.NumeroDecimal(0, 3);
            this.txtSaldoPresupuesto.Text = Formato.NumeroDecimal(0, 3);
            eCodAre = pObj.CodigoCentroCosto;
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            // validar que la existencia no sea 999999
            if (!this.ValidarNoOrdenServicio()) { return; }

            // validar que el costo no sea mayor al de la cabecera
            if (!ValidarPrecioMaterialAccesorio()) { return; }

            //adicionar MovimientoDeta
            this.AdicionarMovimientoDeta();

            //actualizar presupuesto
            this.ActualizarPresupuesto();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se adiciono el registro", "Detalle");

            //actualizar propietario
            this.wEditOrdSer.eClaveDgvMovDet = this.wEditOrdSer.eLisMovDet[this.wEditOrdSer.eLisMovDet.Count - 1].ClaveObjeto;
            this.wEditOrdSer.MostrarMovimientosDeta();

            //limpiar controles
            this.MostrarMovimientoDeta(MovimientoOCDetaRN.EnBlanco());
            //this.HabilitarControlesSegunPropiedadLote("");          
            this.CambiarAtributoSoloLecturaACodigoExistencia();
            this.eLisLotExi.Clear();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodExi.Focus();
        }

        public void ActualizarPresupuesto()
        {
            PresupuestoEN xObj = new PresupuestoEN();
            xObj.CodigoPresupuesto = wEditOrdSer.wOrdSer.lblPeriodo.Text;
            xObj.CCentroCosto = this.wEditOrdSer.txtCodAre.Text;
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar:
                    {
                        xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(this.txtSaldoPresupuesto.Text);
                        break;
                    }
                case Universal.Opera.Modificar:
                    {
                        xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(this.txtSaldoPresupuesto.Text);

                        break;
                    }
                case Universal.Opera.Eliminar:
                    {
                        xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(this.txtPresupuesto.Text); break;
                    }
                default: break;
            }
            PresupuestoRN.ModificarPresupuestoActual(xObj);
        }

        public void AdicionarMovimientoDeta()
        {
            MovimientoOCDetaEN iComDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iComDetEN);

            //adicionar detalle
            MovimientoOCDetaRN.AdicionarMovimientoDeta(this.wEditOrdSer.eLisMovDet, iComDetEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            // validar que la existencia no sea 999999
            if (!this.ValidarNoOrdenServicio()) { return; }

            // validar que el costo no sea mayor al de la cabecera
            if (!ValidarPrecioMaterialAccesorio()) { return; }

            //modificar detalle
            this.ModificarMovimientoDeta();

            //eliminar lotes anteriores
            this.EliminarLotesExistenciaAnterior();

            //actualizar presupuesto
            this.ActualizarPresupuesto();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se modifico el registro", "Detalle");

            //Actualizar propietario
            this.wEditOrdSer.eClaveDgvMovDet = this.wEditOrdSer.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditOrdSer.dgvMovDet)].ClaveObjeto;
            this.wEditOrdSer.MostrarMovimientosDeta();

            //salir de la ventana
            this.Close();

        }

        public void ModificarMovimientoDeta()
        {
            //obtener el objeto de la franja
            MovimientoOCDetaEN iMovDetEN = this.wEditOrdSer.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditOrdSer.dgvMovDet)];

            //asignar los nuevos valores
            this.AsignarMovimientoDeta(iMovDetEN);

            //actualizar a cero el costoflete
            iMovDetEN.CostoFleteMovimientoDeta = 0;

            //actualizar este objeto en la lista
            ListaG.Modificar<MovimientoOCDetaEN>(this.wEditOrdSer.eLisMovDet, iMovDetEN, MovimientoOCDetaEN.CodExi, iMovDetEN.CodigoExistencia);
        }

        public void EliminarLotesExistenciaAnterior()
        {
            //asignar parametros
            string iCodigoExistencia = Dgv.ObtenerValorCelda(this.wEditOrdSer.dgvMovDet, MovimientoOCDetaEN.CodExi);
        }

        public void Eliminar()
        {
            //eliminar particpante
            this.EliminarMovimientoDeta();

            //eliminar lotes anteriores
            this.EliminarLotesExistenciaAnterior();

            this.ActualizarPresupuesto();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se elimino el registro", "Detalle");

            //mostra detalle comprobante
            this.wEditOrdSer.MostrarMovimientosDeta();

            //salir de la ventana
            this.Close();
        }

        public void EliminarMovimientoDeta()
        {
            this.wEditOrdSer.eLisMovDet.RemoveAt(Dgv.ObtenerIndiceRegistroXFranja(this.wEditOrdSer.dgvMovDet));
        }

        public void MostrarCosto()
        {
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);
            this.txtCosMovDet.Text = Formato.NumeroDecimal(MovimientoOCDetaRN.ObtenerCosto(iMovDetEN).ToString(), 2);
            decimal presupuesto = Convert.ToDecimal(Formato.NumeroDecimal(this.txtPresupuesto.Text, 2));
            decimal precio = Convert.ToDecimal(Formato.NumeroDecimal(this.txtPreUniMovDet.Text, 2));
            decimal cantidad = Convert.ToDecimal(Formato.NumeroDecimal(this.txtCantMovDet.Text, 2));
            this.txtSaldoPresupuesto.Text = Formato.NumeroDecimal(presupuesto - (precio * cantidad), 2);
        }

        public bool EsValidaDetallePresupuestoxCC()
        {
            decimal precio = Convert.ToDecimal(Formato.NumeroDecimal(this.txtCosMovDet.Text, 2));
            decimal presupuesto = Convert.ToDecimal(Formato.NumeroDecimal(this.txtPresupuesto.Text, 2));

            if (precio >= presupuesto)
            {
                Mensaje.OperacionDenegada("La cantidad solicitada por el precio de la ultima compra supera al presupuesto por centro de costo.", eTitulo);
                return false;
            }

            //ok          
            return true;
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
            if (this.wEditOrdSer.txtCodMonSyD.Text == "1")
            {
                win.eCtrlFoco = this.txtPreUniDol;
            }
            else
            {
                win.eCtrlFoco = this.txtPreUniMovDet;
            }
            win.eExiEN.CodigoAlmacen = "A90";
            win.eLisMovDetOC = this.wEditOrdSer.eLisMovDet;
            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaOC;
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
            string iCodigoExistenciaFranjaGrilla = Dgv.ObtenerValorCelda(this.wEditOrdSer.dgvMovDet, MovimientoOCDetaEN.CodExi);
            List<MovimientoOCDetaEN> iLisMovDetGrilla = this.wEditOrdSer.eLisMovDet;
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaActivoNoProduccionValidoOC(iExiEN, iOperacionVentana, iCodigoExistenciaFranjaGrilla, iLisMovDetGrilla);
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
            this.txtPreUniCon.Text = Formato.NumeroDecimal(this.ObtenerPrecioUnitarioConvertido(), 3);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal(0, 3);
            this.txtCanCon.Text = Formato.NumeroDecimal(this.ObtenerCantidadConvertido(), 3);
            //this.txtCantMovDet.Text = Formato.NumeroDecimal(this.ObtenerCantidad(), 3);

            //mostrar costo
            this.MostrarCosto();

            //cambiar atributo solo lectura al cambiar existencia
            this.CambiarAtributoSoloLecturaAlCambiarExistencia();

            //poner el foco
            this.PonerFocoAlCambiarExistencia();

            //devolver
            return iExiEN.Adicionales.EsVerdad;
        }

        public MovimientoOCDetaEN ObtenerMovimientoDetaFranjaGrilla()
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //si la grilla esta llena, toma al objeto
            if (this.wEditOrdSer.eLisMovDet.Count != 0)
            {
                iMovDetEN = this.wEditOrdSer.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditOrdSer.dgvMovDet)];
            }

            //retornar
            return iMovDetEN;
        }

        public decimal ObtenerStockActualExistencia(ExistenciaEN pObj)
        {
            //asignar parametros
            ExistenciaEN iExiBDEN = pObj;
            MovimientoOCDetaEN iMovDetGriEN = this.ObtenerMovimientoDetaFranjaGrilla();
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerStockAnteriorExistenciaPorDigitacion(iExiBDEN, iMovDetGriEN, iOperacionVentana);
        }

        public decimal ObtenerPrecioActualExistencia(ExistenciaEN pObj)
        {
            //asignar parametros
            ExistenciaEN iExiBDEN = pObj;
            MovimientoOCDetaEN iMovDetGriEN = this.ObtenerMovimientoDetaFranjaGrilla();
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerPrecioAnteriorExistenciaPorDigitacion(iExiBDEN, iMovDetGriEN, iOperacionVentana);
        }

        public decimal ObtenerPrecioUnitario()
        {
            //asignar parametros          
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerPrecioUnitarioSugerido(iMovDetEN);
        }

        public decimal ObtenerPrecioUnitarioConvertido()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerPrecioUnitarioConvertidoSugerido(iMovDetEN);
        }

        public void CambiarAtributoSoloLecturaAPrecioUnitario()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoOCDetaRN.EsActoDigitarPrecioUnitario(iMovDetEN);

            //cambiar atributo readOnly
            //Txt.SoloEscritura3(this.txtPreUniMovDet, !iValor);
        }

        public ExistenciaEN NuevaExistenciaVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = "A90";
            iExiEN.DescripcionAlmacen = "ALMACEN SERVICIO";
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
            //Txt.SoloEscritura3(this.txtCantMovDet, iValor);

            //ahora saber si se debe limpiar el valor que tiene "txtCantMovDet" solo si es readonly
            //si la existencia tiene lotes registrados, entonces el valor "txtCantMovDet"
            //no se limpia 
            List<LoteEN> iLisLotExi = LoteRN.FiltrarLotes(null, LoteEN.CodExi, this.txtCodExi.Text);
            if (this.txtCantMovDet.ReadOnly == true && iLisLotExi.Count == 0)
            {
                this.txtCantMovDet.Text = Txt.ObtenerValorXDefecto(this.txtCantMovDet);
            }
        }

        //public void InstanciarLotes()
        //{
        //    wLote win = new wLote();
        //    win.wDetOrdSer = this;
        //    TabCtrl.InsertarVentana(this, win);
        //    win.NuevaVentana();
        //}

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
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoOCDetaRN.EsActoDigitarPrecioUnitarioConversion(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtPreUniCon, !iValor);
        }

        public void CambiarAtributoSoloLecturaACantidadConversion()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoOCDetaRN.EsActoDigitarCantidadConversion(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtCanCon, !iValor);
        }

        public void CambiarAtributoSoloLecturaACantidad()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoOCDetaRN.EsActoDigitarCantidad(iMovDetEN);

            //cambiar atributo readOnly
            //Txt.SoloEscritura3(this.txtCantMovDet, !iValor);
        }

        public void CambiarAtributoHabilitarALote()
        {
            //obtener el valor de veracidad de este flag
            bool iValor = Conversion.CadenaABoolean(this.txtCEsLot.Text.Trim(), false);

            //cambiamos el atributo del control            
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
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerCantidadConvertidoSugerido(iMovDetEN);
        }

        //public decimal ObtenerCantidad()
        //{
        //    //asignar parametros
        //    MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
        //    this.AsignarMovimientoDeta(iMovDetEN);
        //    List<LoteEN> iLisLotExi = ListaG.Filtrar<LoteEN>(this.wEditOrdSer.eLisLot, LoteEN.CodExi, this.txtCodExi.Text);

        //    //ejecutar metodo
        //    return MovimientoOCDetaRN.ObtenerCantidadSugerido(iMovDetEN, iLisLotExi);
        //}

        public void MostrarCantidadCalculado()
        {
            //valida cuando el control es readOnly
            if (this.txtCanCon.ReadOnly == true) { return; }

            //obtener valor
            //decimal iValor = this.ObtenerCantidad();

            //mostrar en pantalla
            //this.txtCantMovDet.Text = Formato.NumeroDecimal(iValor, 3);
        }

        public void CambiarAtributoSoloLecturaAlCambiarExistencia()
        {
            this.CambiarAtributoSoloLecturaAPrecioUnitarioConversion();
            this.CambiarAtributoSoloLecturaAPrecioUnitario();
            this.CambiarAtributoSoloLecturaACantidadConversion();
            this.CambiarAtributoSoloLecturaACantidad();
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
            if (this.txtPreUniCon.ReadOnly == false) { this.txtPreUniCon.Focus(); return; }
            if (this.txtPreUniDol.ReadOnly == false) { this.txtPreUniDol.Focus(); return; }
            if (this.txtPreUniMovDet.ReadOnly == false) { this.txtPreUniMovDet.Focus(); return; }
            if (this.txtCanCon.ReadOnly == false) { this.txtCanCon.Focus(); return; }
            if (this.txtCantMovDet.ReadOnly == false) { this.txtCantMovDet.Focus(); return; }
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.eTitulo);
        }

        public void CargarPresupuesto()
        {
            if (this.wEditOrdSer.txtCodAre.Text.Trim() != string.Empty)
            {
                PresupuestoEN iPerEN = new PresupuestoEN();
                iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
                this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);
                this.txtPresupuesto.Text = this.eLisPre.Where(x => x.CodigoPresupuesto == wEditOrdSer.wOrdSer.lblPeriodo.Text
                && x.CCentroCosto == this.wEditOrdSer.txtCodAre.Text.Trim()).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wEditOrdSer.wOrdSer.lblPeriodo.Text && x.CCentroCosto == this.wEditOrdSer.txtCodAre.Text.Trim()).FirstOrDefault().SaldoPresupuesto.ToString(), 2);

                this.txtSaldoPresupuesto.Text = this.eLisPre.Where(x => x.CodigoPresupuesto == wEditOrdSer.wOrdSer.lblPeriodo.Text
                && x.CCentroCosto == this.wEditOrdSer.txtCodAre.Text.Trim()).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wEditOrdSer.wOrdSer.lblPeriodo.Text && x.CCentroCosto == this.wEditOrdSer.txtCodAre.Text.Trim()).FirstOrDefault().SaldoPresupuesto.ToString(), 2);
            }
        }

        public void RetornarPresupuesto()
        {
            PresupuestoEN iPerEN = new PresupuestoEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
            this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);

            string presupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wEditOrdSer.wOrdSer.lblPeriodo.Text
                && x.CCentroCosto == this.wEditOrdSer.txtCodAre.Text.Trim()).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wEditOrdSer.wOrdSer.lblPeriodo.Text && x.CCentroCosto == this.wEditOrdSer.txtCodAre.Text.Trim()).FirstOrDefault().ImportePresupuesto.ToString(), 2);

            string nuevoPresupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wEditOrdSer.wOrdSer.lblPeriodo.Text
                && x.CCentroCosto == this.wEditOrdSer.txtCodAre.Text.Trim()).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wEditOrdSer.wOrdSer.lblPeriodo.Text && x.CCentroCosto == this.wEditOrdSer.txtCodAre.Text.Trim()).FirstOrDefault().SaldoPresupuesto.ToString(), 2);

            decimal ultimoPrecio = Convert.ToDecimal(Formato.NumeroDecimal(this.txtPreUniMovDet.Text, 2));
            decimal cantidad = Convert.ToDecimal(Formato.NumeroDecimal(this.txtCantMovDet.Text, 2));

            if (Convert.ToDecimal(nuevoPresupuesto) != Convert.ToDecimal(presupuesto))
            {
                if (Convert.ToDecimal(nuevoPresupuesto) < Convert.ToDecimal(presupuesto))
                {
                    this.txtPresupuesto.Text = (Convert.ToDecimal(nuevoPresupuesto) + (ultimoPrecio * cantidad)).ToString();
                }
            }
        }

        public void ValidacionCostoOrdenServicio()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.CargarPresupuesto(); break; }
                case Universal.Opera.Modificar:
                    {
                        eCodAre = this.wEditOrdSer.txtCodAre.Text;
                        eCan = Convert.ToDecimal(this.txtCantMovDet.Text);
                        if (this.eMovDet.CodigoCentroCosto != eCodAre)
                        {
                            this.CargarPresupuesto();

                        }
                        else
                        {
                            if (this.eMovDet.CantidadMovimientoDeta == eCan)
                            {
                                //this.RetornarPresupuesto();
                            }
                        }
                        break;
                    }
                case Universal.Opera.Eliminar: { break; }
                default: break;
            }

            this.MostrarCosto();
        }

        public bool ValidarNoOrdenServicio()
        {
            if (this.txtCodExi.Text == "999999")
            {
                Mensaje.OperacionDenegada("El código de existencia no puede ser seleccionada.", "Detalle");
                return false;
            }
            return true;
        }

        public bool ValidarPrecioMaterialAccesorio()
        {
            if (Convert.ToDecimal(this.txtCosMovDet.Text) > this.precioMatAcc)
            {
                Mensaje.OperacionDenegada("El precio de materiales y accesorios ingresado es mayor a lo ingresada anteriormente.", "Detalle");
                return false;
            }
            return true;
        }
        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void wDetalleOrdenServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEditOrdSer.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
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
            if (this.txtCodMon.Text == "0")
            {
                if (this.wEditOrdSer.txtTipCam.Text == "0.0000")
                {
                    Mensaje.OperacionDenegada("Debe ingresar un tipo de cambio", this.wEditOrdSer.wOrdSer.eTitulo);
                    this.txtPreUniDol.Text = Formato.NumeroDecimal(0, 5);
                    this.txtPreUniMovDet.Text = Formato.NumeroDecimal(0, 5);
                    return;
                }
                else
                {
                    decimal tc = 0, precio = 0;
                    tc = Convert.ToDecimal(this.wEditOrdSer.txtTipCam.Text);
                    precio = Convert.ToDecimal(this.txtPreUniMovDet.Text);
                    this.txtPreUniDol.Text = Formato.NumeroDecimal((precio / tc).ToString(), 5);
                }
            }
        }

        private void btnLote_Click(object sender, EventArgs e)
        {
            //this.InstanciarLotes();
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

        }

        private void txtCodAre_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCodAre_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtPreUniDol_Validated(object sender, EventArgs e)
        {
            if (this.txtCodMon.Text == "1")
            {
                if (this.wEditOrdSer.txtTipCam.Text == "0.0000")
                {
                    Mensaje.OperacionDenegada("Debe ingresar un tipo de cambio", this.wEditOrdSer.wOrdSer.eTitulo);
                    this.txtPreUniDol.Text = Formato.NumeroDecimal(0, 5);
                    this.txtPreUniMovDet.Text = Formato.NumeroDecimal(0, 5);
                    return;
                }
                else
                {
                    decimal tc = 0, precio = 0;
                    tc = Convert.ToDecimal(this.wEditOrdSer.txtTipCam.Text);
                    precio = Convert.ToDecimal(this.txtPreUniDol.Text);
                    this.txtPreUniMovDet.Text = Formato.NumeroDecimal((precio * tc).ToString(), 5);
                }
            }
        }
    }
}
