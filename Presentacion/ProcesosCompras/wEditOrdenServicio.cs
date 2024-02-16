using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.FuncionesGenericas;
using Presentacion.Listas;
using Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace Presentacion.ProcesosCompras
{
    public partial class wEditOrdenServicio : Heredados.MiForm8
    {
        public wOrdenServicio wOrdSer;
        string eNombreColumnaDgvTipOpe = TipoCambioEN.FecTipCam;
        string eNombreColumnaDgvPer = PresupuestoEN.CodPre;
        public Universal.Opera eOperacion;
        public string wTipoCambio, wano, wmes, wperiodo;
        Masivo eMas = new Masivo();
        public List<MovimientoOCDetaEN> eLisMovDet = new List<MovimientoOCDetaEN>();
        public string eClaveDgvMovDet = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;
        public List<PresupuestoEN> eLisPre = new List<PresupuestoEN>();
        public List<TipoCambioEN> eLisTipCam = new List<TipoCambioEN>();
        public int eFlgCrdSol = 0;
        public bool eFlgEnvOC = true;
        public string eClavSolPedCab = string.Empty;
        public decimal preVenta = 0;
        public int valCoti = 0;
        public string Presupuesto = string.Empty;
        public string SaldoPresupuesto = string.Empty;

        public wEditOrdenServicio()
        {
            InitializeComponent();
        }

        public void VentanaAdicionar()
        {
            //             
            txtPerMovCab.Text = wOrdSer.lblDescripcionPeriodo.Text;
            wano = this.txtPerMovCab.Text.Substring(0, 4);
            wmes = this.txtPerMovCab.Text.Substring(5).ToUpper();
            this.NumeroMesDelNombreDelMes();
            wperiodo = Universal.gCodigoEmpresa + "-" + wano + "-" + wmes;
            //Buscar Tipo de cambio del periodo
            PeriodoEN nPeri = new PeriodoEN();
            nPeri.ClavePeriodo = wperiodo;
            nPeri = PeriodoRN.BuscarPeriodoXClave(nPeri);
            wTipoCambio = nPeri.TipoCambioPeriodo.ToString();
            //
            this.InicializaVentana();
            this.MostrarMovimientoCabe(MovimientoOCCabeRN.EnBlanco());
            this.MostrarFechaIngresoSugerida();
            this.MostrarMovimientosDeta();
            //Cargar Igv
            this.ObtenerIgv();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            //this.txtTipCam.Text = wTipoCambio;
            this.dtpFecMovCab.Focus();
            this.CargarTipoCambio();
            this.eFlgCrdSol = 0;
            this.eFlgEnvOC = true;
        }
        public void NumeroMesDelNombreDelMes()
        {
            if (wmes == "ENERO")
            {
                wmes = "01";
            }
            if (wmes == "FEBRERO")
            {
                wmes = "02";
            }
            if (wmes == "MARZO")
            {
                wmes = "03";
            }
            if (wmes == "ABRIL")
            {
                wmes = "04";
            }
            if (wmes == "MAYO")
            {
                wmes = "05";
            }
            if (wmes == "JUNIO")
            {
                wmes = "06";
            }
            if (wmes == "JULIO")
            {
                wmes = "07";
            }
            if (wmes == "AGOSTO")
            {
                wmes = "08";
            }
            if (wmes == "SETIEMBRE")
            {
                wmes = "09";
            }
            if (wmes == "OCTUBRE")
            {
                wmes = "10";
            }
            if (wmes == "NOVIEMBRE")
            {
                wmes = "11";
            }
            if (wmes == "DICIEMBRE")
            {
                wmes = "12";
            }
        }

        public void InicializaVentana()
        {
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wOrdSer.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            //Cargas Combobox
            this.CargarMonedas();
            this.CargarGarantia();
            this.CargarFormaPago();

            //valores x defecto
            this.ValoresXDefecto();

            // Deshabilitar al propietario de esta ventana
            this.wOrdSer.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPerMovCab, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumMovCab, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecMovCab, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodTipSer, true, "Tipo Operacion", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipSer, this.txtCodTipSer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer, true, "Personal", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer, this.txtCodPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTipCam, false, "Tipo Cambio", "ffff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtIgv, true, "Igv", "ffff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCondiciones, true, "Condiciones", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGarantia, true, "Garantia", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbGarantia, "vvff");
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtValCotizacion, true, "Validez Cotización", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAre, true, "Código Área", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPar, true, "Código Partida", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbFormaPago, "vvff");
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, false, "Proveedor", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCtaDeposito, true, "Cuenta Deposito", "ffff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCII, true, "Cuenta CII", "ffff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtPreVenta, true, "Precio Venta", "vvff", 2);
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtPreMatAcc, false, "Precio Material y Accesorio", "vvff", 2);
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtValorVenta, true, "Valor Venta", "ffff", 2);
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtValorIGV, true, "Valor I.G.V.", "ffff", 2);
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTotalGral, true, "Total General", "ffff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGloMovCab, false, "Glosa", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnModificar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }

        public void CargarMonedas()
        {
            Cmb.Cargar(this.cmbMon, ItemGRN.ListarItemsG("Moneda"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarGarantia()
        {
            Cmb.Cargar(this.cmbGarantia, ItemGRN.ListarItemsG("Garant"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarFormaPago()
        {
            Cmb.Cargar(this.cmbFormaPago, ItemGRN.ListarItemsG("ForPag"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void ValoresXDefecto()
        {
            txtPerMovCab.Text = wOrdSer.lblDescripcionPeriodo.Text;
        }


        public void MostrarMovimientoCabe(MovimientoOCCabeEN pMovCab)
        {
            this.txtNumMovCab.Text = pMovCab.NumeroMovimientoCabe;
            this.dtpFecMovCab.Text = pMovCab.FechaMovimientoCabe;
            this.txtCodTipSer.Text = pMovCab.CTipoServicio;
            this.txtDesTipSer.Text = pMovCab.NTipoServicio;
            this.txtCodPer.Text = pMovCab.CodigoPersonal;
            this.txtNomPer.Text = pMovCab.NombrePersonal;
            this.txtIgv.Text = pMovCab.IgvPorcentaje.ToString();
            this.txtCondiciones.Text = pMovCab.Condiciones;
            this.txtGarantia.Text = pMovCab.Garantia.ToString();
            this.txtTipCam.Text = pMovCab.TipoCambio.ToString();
            Cmb.SeleccionarValorItem(this.cmbGarantia, pMovCab.CGarantia);
            Cmb.SeleccionarValorItem(this.cmbMon, pMovCab.CCodigoMoneda);
            this.txtCodMonSyD.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            this.txtValCotizacion.Text = pMovCab.ValidezCotizacion.ToString();
            this.valCoti = pMovCab.ValidezCotizacion;
            this.lblValCot.Text = pMovCab.FechaValidezCotizacion.ToString();
            this.txtPreVenta.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                Formato.NumeroDecimal(pMovCab.PrecioVtaMovimientoCabe, 2)
                : (Convert.ToDecimal(Formato.NumeroDecimal(pMovCab.PrecioVtaMovimientoCabe, 2)) / Convert.ToDecimal(this.txtTipCam.Text)).ToString();
            this.lblPreVenTipCam.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                "0" : Formato.NumeroDecimal(pMovCab.PrecioVtaMovimientoCabe, 2);
            this.txtPreMatAcc.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                Formato.NumeroDecimal(pMovCab.PrecioMaterialAccesorioOrdenServicio, 2)
                : (Convert.ToDecimal(Formato.NumeroDecimal(pMovCab.PrecioMaterialAccesorioOrdenServicio, 2)) / Convert.ToDecimal(this.txtTipCam.Text)).ToString();
            this.lblPreMatAccTipCam.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                "0" : Formato.NumeroDecimal(pMovCab.PrecioMaterialAccesorioOrdenServicio, 2);
            this.txtValorVenta.Text = Formato.NumeroDecimal(pMovCab.ValorVtaMovimientoCabe, 2);
            this.txtValorIGV.Text = Formato.NumeroDecimal(pMovCab.IgvMovimientoCabe, 2);
            this.txtTotalGral.Text = Formato.NumeroDecimal(pMovCab.MontoTotalMovimientoCabe, 2);
            Cmb.SeleccionarValorItem(this.cmbFormaPago, pMovCab.CFormaPago);
            this.txtCodAux.Text = pMovCab.CodigoAuxiliar;
            this.txtDesAux.Text = pMovCab.DescripcionAuxiliar;
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;
            this.eClavSolPedCab = pMovCab.ClaveSolicitudPedidoCabe;
            this.txtIgv.Text = pMovCab.IgvPorcentaje.ToString();
            this.txtCodAre.Text = string.Empty;
            this.txtDesAre.Text = string.Empty;
            this.txtCodPar.Text = string.Empty;
            this.txtDesPar.Text = string.Empty;
            this.dtpPlazoEntrega.Text = pMovCab.PlazoEntrega;
        }

        public void MostrarFechaIngresoSugerida()
        {
            //asignar parametros
            string iPeriodoRegistro = this.wOrdSer.lblPeriodo.Text;
            string iFechaMovimientoCabeDtp = Fecha.ObtenerDiaMesAno(this.dtpFecMovCab.Value);
            string iFechaDocumentoDtp = Fecha.ObtenerDiaMesAno(this.dtpPlazoEntrega.Value);

            //ejecutar metodo
            this.dtpFecMovCab.Text = MovimientoOCCabeRN.ObtenerFechaMovimientoCabeSugerido(iPeriodoRegistro, iFechaMovimientoCabeDtp);
            this.dtpPlazoEntrega.Text = MovimientoOCCabeRN.ObtenerFechaMovimientoCabeSugerido(iPeriodoRegistro, iFechaDocumentoDtp);
        }


        public void MostrarMovimientosDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<MovimientoOCDetaEN> iFuenteDatos = MovimientoOCDetaRN.RefrescarListaMovimientoDeta(this.eLisMovDet);
            Dgv.Franja iCondicionFranja = eFranjaDgvMovDet;
            string iClaveBusqueda = eClaveDgvMovDet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
            if (iFuenteDatos.Count != 0)
            {
                this.txtCodAre.Text = iFuenteDatos.FirstOrDefault().CodigoCentroCosto;
                this.txtDesAre.Text = iFuenteDatos.FirstOrDefault().DescripcionCentroCosto;
                this.txtCodPar.Text = iFuenteDatos.FirstOrDefault().CCodigoPartida;
                this.txtDesPar.Text = iFuenteDatos.FirstOrDefault().NCodigoPartida;
            }
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.CorMovDet, "Linea", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.DesExi, "Descripcion", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.DesCenCos, "Centro Costo", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoOCDetaEN.CanMovDet, "Cant", 60, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoOCDetaEN.PreUniMovDet, "P/U", 85, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoOCDetaEN.CosMovDet, "Costo", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.NCodMon, "Moneda", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ListarTiposServicios()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodTipSer.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Servicios";
            win.eCtrlValor = this.txtCodTipSer;
            win.eCtrlFoco = this.txtCodPer;
            win.eIteEN.CodigoTabla = "TipSer";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsTipoServicioValido()
        {
            return Generico.EsCodigoItemGValido("TipSer", this.txtCodTipSer, this.txtDesTipSer, "Tipo servicio");
        }

        public void ListarPersonales()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer.ReadOnly == true) { return; }

            //instanciar
            wLisPer win = new wLisPer();
            win.eVentana = this;
            win.eTituloVentana = "Personales";
            win.eCtrlValor = this.txtCodPer;
            win.eCtrlFoco = this.txtCondiciones;
            win.eCondicionLista = Listas.wLisPer.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodPer.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            Entidades.PersonalEN iPerEN = new Entidades.PersonalEN();
            iPerEN.CodigoPersonal = this.txtCodPer.Text.Trim();
            iPerEN = PersonalRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wOrdSer.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPer.Text = iPerEN.CodigoPersonal;
            this.txtNomPer.Text = iPerEN.NombrePersonal;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarProveedores()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            wLisAux win = new wLisAux();
            win.eVentana = this;
            win.eTituloVentana = "Proveedores";
            win.eCtrlValor = this.txtCodAux;
            win.eCtrlFoco = this.txtPreVenta;
            win.eCondicionLista = Listas.wLisAux.Condicion.ProveedoresActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsProveedorValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAux.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iAuxEN = AuxiliarRN.EsProveedorActivoValido(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wOrdSer.eTitulo);
                this.txtCodAux.Focus();
            }

            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;
            this.txtCtaDeposito.Text = iAuxEN.CuentaBancariaAuxiliar;
            this.txtCII.Text = iAuxEN.CuentaInterBancariaAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void ObtenerIgv()
        {
            //variables
            ParametroEN iParEN = ParametroRN.BuscarParametro();
            this.txtIgv.Text = iParEN.PorcentajeIgv.ToString();
        }

        public void ObtenerValoresCalculados()
        {
            decimal preVenta = 0;
            decimal preMatAcc = 0;
            decimal tipoCambio = Convert.ToDecimal(this.txtTipCam.Text);

            if (Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0")
            {
                preVenta = Convert.ToDecimal(this.txtPreVenta.Text);
                preMatAcc = this.txtPreMatAcc.Text == string.Empty ? 0 : Convert.ToDecimal(this.txtPreMatAcc.Text);
            }
            else
            {
                preVenta = Convert.ToDecimal(this.txtPreVenta.Text) * tipoCambio;
                this.lblPreVenTipCam.Text = preVenta.ToString();
                preMatAcc = this.txtPreMatAcc.Text == string.Empty ? 0 : Convert.ToDecimal(this.txtPreMatAcc.Text) * tipoCambio;
                this.lblPreMatAccTipCam.Text = preMatAcc.ToString();
            }

            decimal igv = Convert.ToDecimal(this.txtIgv.Text);


            decimal valIgv = (preVenta + preMatAcc) * igv / (igv + 100);

            decimal valVenta = (preVenta + preMatAcc) - valIgv;

            this.txtValorVenta.Text = (Formato.NumeroDecimal(valVenta, 2)).ToString();
            this.txtValorIGV.Text = (Formato.NumeroDecimal(valIgv, 2)).ToString();
            this.txtTotalGral.Text = (preVenta + preMatAcc).ToString();
        }

        public void AdicionarMovimientoDeta()
        {
            MovimientoOCDetaEN iComDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iComDetEN);

            //adicionar detalle
            MovimientoOCDetaRN.AdicionarMovimientoDeta(this.eLisMovDet, iComDetEN);
        }


        public void AsignarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.FechaMovimientoCabe = this.dtpFecMovCab.Text;
            pObj.PeriodoMovimientoCabe = this.wOrdSer.lblPeriodo.Text;
            pObj.CodigoAlmacen = "A90";
            pObj.CodigoTipoOperacion = "79";
            pObj.CCalculaPrecioPromedio = "0";
            pObj.CConversionUnidad = "0";
            pObj.CClaseTipoOperacion = "4";//orden de compra
            pObj.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();
            pObj.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pObj.CTipoDocumento = string.Empty;
            pObj.SerieDocumento = string.Empty;
            pObj.NumeroDocumento = string.Empty;
            pObj.FechaDocumento = string.Empty;
            pObj.CodigoCentroCosto = this.txtCodAre.Text.Trim();
            pObj.DescripcionCentroCosto = this.txtDesAre.Text.Trim();
            pObj.CCodigoPartida = this.txtCodPar.Text.Trim();
            pObj.NCodigoPartida = this.txtDesPar.Text.Trim();
            pObj.CodigoExistencia = "999999";
            pObj.DescripcionExistencia = "ORDEN DE SERVICIO";
            pObj.CodigoUnidadMedida = "NIU";
            pObj.NombreUnidadMedida = string.Empty;
            pObj.StockAnteriorExistencia = 0;
            pObj.PrecioAnteriorExistencia = Convert.ToDecimal(0);
            pObj.PrecioUnitarioMovimientoDeta = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                Convert.ToDecimal(this.txtPreVenta.Text)
                : Convert.ToDecimal(this.txtPreVenta.Text) * Convert.ToDecimal(this.txtTipCam.Text);
            pObj.PrecioUnitarioDolarMovimientoDeta = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                Convert.ToDecimal(this.txtPreVenta.Text) / Convert.ToDecimal(this.txtTipCam.Text)
                : Convert.ToDecimal(this.txtPreVenta.Text);
            pObj.CantidadMovimientoDeta = Convert.ToDecimal(1);
            pObj.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(pObj);
            pObj.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(pObj);
            pObj.CostoMovimientoDeta = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                Convert.ToDecimal(this.txtPreVenta.Text)
                : Convert.ToDecimal(this.txtPreVenta.Text) * Convert.ToDecimal(this.txtTipCam.Text);
            pObj.GlosaMovimientoDeta = this.txtGloMovCab.Text.Trim();
            pObj.CodigoTipo = "PT";
            pObj.CEsLote = string.Empty;
            pObj.CEsUnidadConvertida = string.Empty;
            pObj.FactorConversion = Convert.ToDecimal(0);
            pObj.PrecioUnitarioConversion = Convert.ToDecimal(this.txtPreVenta.Text);
            pObj.CantidadConversion = Convert.ToDecimal(1);
            pObj.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            pObj.CCodigoMoneda = this.txtCodMonSyD.Text.ToString().Trim();
        }

        public void AccionAgregarItem()
        {
            //valida cuando no hay centro de costo
            if (this.ElegirCentroCostoAntesDeLlenarGrilla() == false) { return; }

            //valida cuando no hay precio materiales y accesorios
            if (this.IngresarPrecioMaterialesAccesorioDeLlenarGrilla() == false) { return; }

            //instanciar
            wDetalleOrdenServicio win = new wDetalleOrdenServicio();
            win.wEditOrdSer = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar(Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ? Convert.ToDecimal(this.txtPreMatAcc.Text)
                : Convert.ToDecimal(this.lblPreMatAccTipCam.Text));
        }

        public bool ElegirCentroCostoAntesDeLlenarGrilla()
        {
            if (this.txtCodAre.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un centro de costo", "Centro de Costo");
                this.txtCodAre.Focus();
                return false;
            }
            return true;
        }

        public bool IngresarPrecioMaterialesAccesorioDeLlenarGrilla()
        {
            if (this.txtPreMatAcc.Text.Trim() == string.Empty || Convert.ToDecimal(this.txtPreMatAcc.Text) < 1)
            {
                Mensaje.OperacionDenegada("Debes insertar un monto en el precio de materiales y accesorios", "Precio Materiales y Accesorios");
                this.txtPreMatAcc.Focus();
                return false;
            }
            return true;
        }

        public bool ValidarSiAreaTienePresupuesto()
        {
            List<PresupuestoEN> eListPresupuesto = new List<PresupuestoEN>();
            PresupuestoEN iPerEN = new PresupuestoEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
            eListPresupuesto = PresupuestoRN.ListarPresupuestos(iPerEN);
            int existsPresupuesto = eListPresupuesto.Where(p => p.CodigoPresupuesto == wOrdSer.lblPeriodo.Text
                                    && p.CCentroCosto == this.txtCodAre.Text.Trim()).Count();
            if (existsPresupuesto == 0)
            {
                Mensaje.OperacionDenegada("El área seleccionada no tiene presupuesto asignado.", "Presupuesto");
                this.txtCodAre.Focus();
                this.txtCodAre.Text = string.Empty;
                this.txtDesAre.Text = string.Empty;
                return false;
            }
            return true;
        }

        public string ObtenerClaveMovimientoCabe()
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public void AsignarMovimientoCabe(MovimientoOCCabeEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCab.PeriodoMovimientoCabe = wOrdSer.lblPeriodo.Text;
            pMovCab.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();
            pMovCab.FechaMovimientoCabe = dtpFecMovCab.Text;
            pMovCab.CodigoTipoOperacion = "79";
            pMovCab.DescripcionTipoOperacion = "SERVICIOS";
            pMovCab.CClaseTipoOperacion = "4";
            pMovCab.CodigoAlmacen = "A90";
            pMovCab.DescripcionAlmacen = "ORDEN DE SERVICIO";
            pMovCab.CodigoPersonal = this.txtCodPer.Text.Trim();
            pMovCab.CodigoPersonalAutoriza = string.Empty;
            pMovCab.CodigoPersonalRecibe = string.Empty;
            pMovCab.CostoFleteMovimientoCabe = Conversion.ADecimal(null, 0);
            pMovCab.CCodigoMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            pMovCab.NCodigoMoneda = Cmb.ObtenerTexto(this.cmbMon);
            pMovCab.TipoCambio = Conversion.ADecimal(this.txtTipCam.Text, 0);
            pMovCab.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pMovCab.DescripcionAuxiliar = this.txtDesAux.Text.Trim();
            pMovCab.OrdenCompra = string.Empty;
            pMovCab.CTipoDocumento = string.Empty;
            pMovCab.SerieDocumento = string.Empty;
            pMovCab.NumeroDocumento = string.Empty;
            pMovCab.FechaDocumento = string.Empty;
            pMovCab.GlosaMovimientoCabe = this.txtGloMovCab.Text;
            pMovCab.IgvPorcentaje = Conversion.ADecimal(this.txtIgv.Text, 2);
            pMovCab.COrigenVentanaCreacion = "1";//ingreso 
            if (pMovCab.FlagCreadoxSolicitud == 1)
            {
                this.eFlgCrdSol = 1;
                this.eFlgEnvOC = false;
            }
            pMovCab.FlagCreadoxSolicitud = this.eFlgCrdSol;
            pMovCab.FlagEnviadoMovimientoCabe = this.eFlgEnvOC;
            pMovCab.PlazoEntrega = this.dtpPlazoEntrega.Text;
            pMovCab.Condiciones = this.txtCondiciones.Text;
            pMovCab.Garantia = Convert.ToInt32(this.txtGarantia.Text);
            pMovCab.CGarantia = Cmb.ObtenerValor(this.cmbGarantia, string.Empty);
            pMovCab.ValidezCotizacion = Convert.ToInt32(this.txtValCotizacion.Text);
            pMovCab.FechaValidezCotizacion = this.lblValCot.Text;
            pMovCab.MontoTotalMovimientoCabe = Convert.ToDecimal(this.txtTotalGral.Text);
            pMovCab.CFormaPago = Cmb.ObtenerValor(this.cmbFormaPago, string.Empty);
            pMovCab.NFormaPago = Cmb.ObtenerTexto(this.cmbFormaPago);
            pMovCab.CTipoServicio = this.txtCodTipSer.Text;
            pMovCab.PrecioMaterialAccesorioOrdenServicio = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                Convert.ToDecimal(this.txtPreMatAcc.Text)
                : Convert.ToDecimal(this.txtPreMatAcc.Text) * Convert.ToDecimal(this.txtTipCam.Text);
            pMovCab.IgvMovimientoCabe = Convert.ToDecimal(this.txtValorIGV.Text);
            pMovCab.PrecioVtaMovimientoCabe = Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                Convert.ToDecimal(this.txtPreVenta.Text)
                : Convert.ToDecimal(this.txtPreVenta.Text) * Convert.ToDecimal(this.txtTipCam.Text);
            pMovCab.ValorVtaMovimientoCabe = Convert.ToDecimal(this.txtValorVenta.Text);
            pMovCab.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }

        public void CargarTipoCambio()
        {
            TipoCambioEN objTipCam = new TipoCambioEN();
            objTipCam.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            eLisTipCam = TipoCambioRN.ListarTipoCambio(objTipCam);

            string fechaTipoCambio = Fecha.ObtenerDiaMesAno(Conversion.ADateTime(dtpFecMovCab.Text));

            if (eLisTipCam.Where(e => e.FechaTipoCambio == fechaTipoCambio).Count() == 0)
            {
                Mensaje.OperacionDenegada("Se debe ingresar un tipo de cambio para la fecha del documento.", this.wOrdSer.eTitulo);
                txtTipCam.Text = Formato.NumeroDecimal(0, 4);
            }
            else
                txtTipCam.Text = eLisTipCam.FirstOrDefault(e => e.FechaTipoCambio == fechaTipoCambio).VentaTipoCambio.ToString();

        }

        public bool ValidaFechaMovimientoCabe()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //validar
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoFechaNoEsDelPeriodoElegido(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.wOrdSer.eTitulo);
                this.dtpFecMovCab.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public MovimientoOCCabeEN NuevoMovimientoCabeDeVentana()
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN;
        }

        public bool EsCodigoAreaValido()
        {
            return Generico.EsCodigoItemEActivoValido("CenCos", this.txtCodAre, this.txtDesAre, "Centro costo");
        }

        public void ListarAreas()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodAre.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centro de Costo";
            win.eCtrlValor = this.txtCodAre;
            win.eCtrlFoco = this.txtCodPar;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void EliminarMovimientoDeta()
        {
            this.eLisMovDet.Remove(this.eLisMovDet.Find(x => x.CodigoExistencia == "999999"));
        }

        public void AccionParaAgregarEliminarMovimientoDeta()
        {
            //valida cuando no hay centro de costo
            if (this.ElegirCentroCostoAntesDeLlenarGrilla() == false)
            {
                this.txtPreVenta.Text = Formato.NumeroDecimal(0, 2);
                return;
            }

            if (this.txtPreVenta.Text == string.Empty || Convert.ToDecimal(this.txtPreVenta.Text) <= 0)
            {
                if (this.eLisMovDet.Count > 0)
                {
                    this.CargarPresupuesto();
                    this.ActualizarPresupuesto();
                    this.EliminarMovimientoDeta();
                }
            }
            else
            {
                this.CargarPresupuesto();
                this.ActualizarPresupuesto();
                this.EliminarMovimientoDeta();
                this.ObtenerValoresCalculados();
                this.AdicionarMovimientoDeta();
                this.MostrarMovimientosDeta();
            }
        }


        public void CargarPresupuesto()
        {
            if (this.txtCodAre.Text.Trim() != string.Empty)
            {
                PresupuestoEN iPerEN = new PresupuestoEN();
                iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
                this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);
                this.Presupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text
                && x.CCentroCosto == this.txtCodAre.Text.Trim()).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text && x.CCentroCosto == this.txtCodAre.Text.Trim()).FirstOrDefault().SaldoPresupuesto.ToString(), 2);

                this.SaldoPresupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text
                 && x.CCentroCosto == this.txtCodAre.Text.Trim()).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text && x.CCentroCosto == this.txtCodAre.Text.Trim()).FirstOrDefault().SaldoPresupuesto.ToString(), 2);
            }
        }

        public void ActualizarPresupuesto()
        {
            PresupuestoEN xObj = new PresupuestoEN();
            xObj.CodigoPresupuesto = wOrdSer.lblPeriodo.Text;
            xObj.CCentroCosto = this.txtCodAre.Text;
            if (this.txtPreVenta.Text == string.Empty || Convert.ToDecimal(this.txtPreVenta.Text) <= 0)
                xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(this.SaldoPresupuesto)
                    + Convert.ToDecimal(this.eLisMovDet.Find(x => x.CodigoExistencia == "999999").PrecioUnitarioMovimientoDeta);
            else
            {
                if (this.eLisMovDet.Count > 0)
                    xObj.NuevoSaldoPresupuesto = (Convert.ToDecimal(this.SaldoPresupuesto)
                        + Convert.ToDecimal(this.eLisMovDet.Find(x => x.CodigoExistencia == "999999").PrecioUnitarioMovimientoDeta))
                        - (Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                        Convert.ToDecimal(this.txtPreVenta.Text)
                        : Convert.ToDecimal(this.txtPreVenta.Text) * Convert.ToDecimal(this.txtTipCam.Text));
                else
                    xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(this.SaldoPresupuesto)
                        - (Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ?
                        Convert.ToDecimal(this.txtPreVenta.Text)
                        : Convert.ToDecimal(this.txtPreVenta.Text) * Convert.ToDecimal(this.txtTipCam.Text));
            }

            PresupuestoRN.ModificarPresupuestoActual(xObj);
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            if (this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)].CodigoExistencia == "999999")
            {
                Mensaje.OperacionDenegada("No se puede modificar la orden de servicio", "Detalle");
                return;
            }

            wDetalleOrdenServicio win = new wDetalleOrdenServicio();
            win.wEditOrdSer = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)],
                Cmb.ObtenerValor(this.cmbMon, string.Empty) == "0" ? Convert.ToDecimal(this.txtPreMatAcc.Text)
                : Convert.ToDecimal(this.lblPreMatAccTipCam.Text));
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            if (this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)].CodigoExistencia == "999999")
            {
                Mensaje.OperacionDenegada("No se puede eliminar la orden de servicio", "Detalle");
                return;
            }

            wDetalleOrdenServicio win = new wDetalleOrdenServicio();
            win.wEditOrdSer = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public void Cancelar()
        {
            this.eOperacion = Universal.Opera.Cancelar;
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wOrdSer.eTitulo);
        }

        public void LLenarMovimientoDetaDeBaseDatos(MovimientoOCCabeEN pObj)
        {
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;
            this.eLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
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

            //volver a preguntar si es acto adicionar
            if (this.wOrdSer.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad == false) { return; }

            //validar si los totales coinciden
            if (!this.ValidarTotalesCabeceraConDetalle()) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wOrdSer.eTitulo) == false) { return; }

            //mostrar numero movimientoCabe
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarMovimientoCabe();

            //adicionando detalles
            this.AdicionarMovimientosDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la orden de servicio correctamente", this.wOrdSer.eTitulo);

            //actualizar al propietario           
            this.wOrdSer.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
            this.wOrdSer.ActualizarVentana();

            //imprimir la nota
            //this.wOrdSer.AccionImprimirOrdenServicio();
            this.GenerarOrdenServicioExcel();

            //limpiar controles
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeParaSegundaAdicion());
            this.eLisMovDet.Clear();
            this.MostrarMovimientosDeta();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wOrdSer.EsMovimientoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //validar si los totales coinciden
            if (!this.ValidarTotalesCabeceraConDetalle()) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wOrdSer.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarMovimientoCabe();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //adicionando nuevos MovimientoDeta
            this.AdicionarMovimientosDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la orden de servicio correctamente", this.wOrdSer.eTitulo);

            //actualizar al wLot          
            this.wOrdSer.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
            this.wOrdSer.ActualizarVentana();

            //imprimir la nota
            //this.wOrdSer.AccionImprimirOrdenServicio();
            this.GenerarOrdenServicioExcel();

            //salir de la ventana
            this.Close();
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wOrdSer.EsMovimientoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wOrdSer.eTitulo) == false) { return; }

            //retornar presupuesto
            this.RetornarPresupuesto();

            //eliminar el registro
            this.EliminarMovimientoCabe();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la orden de servicio correctamente", this.wOrdSer.eTitulo);

            //actualizar al wLot           
            this.wOrdSer.ActualizarVentana();

            this.eLisMovDet.Clear();

            //salir de la ventana
            this.Close();

        }


        public void EliminarMovimientoCabe()
        {
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            SolicitudPedidoCabeEN pObj = new SolicitudPedidoCabeEN();

            this.AsignarMovimientoCabe(iCuoEN);

            pObj.ClaveSolicitudPedidoCabe = this.eClavSolPedCab;
            pObj.PeriodoSolicitudPedidoCabe = iCuoEN.PeriodoMovimientoCabe;

            SolicitudPedidoCabeRN.EnviadoSolicitudPedidoCabe(pObj);

            MovimientoOCCabeRN.EliminarMovimientoCabe(iCuoEN);
        }

        public void ModificarMovimientoCabe()
        {
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            iCuoEN = MovimientoOCCabeRN.BuscarMovimientoCabeXClave(iCuoEN);
            this.AsignarMovimientoCabe(iCuoEN);
            MovimientoOCCabeRN.ModificarMovimientoCabe(iCuoEN);
        }

        public void EliminarAntiguosMovimientosDeta()
        {
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }


        public void RetornarPresupuesto()
        {
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            this.LLenarMovimientoDetaDeBaseDatos(iCuoEN);

            if (this.eLisMovDet.Count > 0)
            {
                PresupuestoEN iPerEN = new PresupuestoEN();
                iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
                PresupuestoEN xObj = new PresupuestoEN();

                this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);
                xObj = new PresupuestoEN();
                xObj = this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text
                                && x.CCentroCosto == this.txtCodAre.Text.Trim()).FirstOrDefault();
                xObj.SaldoPresupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text
                                            && x.CCentroCosto == this.txtCodAre.Text.Trim()).FirstOrDefault().SaldoPresupuesto + this.eLisMovDet.Sum(x => x.CostoMovimientoDeta);
                PresupuestoRN.ModificarPresupuesto(xObj);
            }
        }

        public void CerrarYDevolverPresupuesto()
        {
            List<MovimientoOCDetaEN> eListMovDeta = new List<MovimientoOCDetaEN>();
            List<MovimientoOCDetaEN> eListMovDetTmp = new List<MovimientoOCDetaEN>();

            eListMovDeta = this.eLisMovDet;

            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            this.LLenarMovimientoDetaDeBaseDatos(iCuoEN);

            foreach (MovimientoOCDetaEN obj in eListMovDeta)
            {
                if (eListMovDeta.Count() != eLisMovDet.Count())
                {
                    if (eLisMovDet.Count() == 0 && this.eOperacion == Universal.Opera.Cancelar)
                    {
                        eListMovDetTmp.Add(obj);
                    }
                    else
                    {
                        eLisMovDet.ForEach(x =>
                        {
                            if (x.ClaveObjeto != obj.ClaveObjeto)
                            {
                                eListMovDetTmp.Add(obj);
                            }
                        });
                    }
                }
            }

            PresupuestoEN iPerEN = new PresupuestoEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
            this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);

            PresupuestoEN xObj = new PresupuestoEN();
            foreach (MovimientoOCDetaEN objDeta in eListMovDetTmp)
            {
                string presupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text
                                        && x.CCentroCosto == objDeta.CodigoCentroCosto).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                                        Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text
                                        && x.CCentroCosto == objDeta.CodigoCentroCosto).FirstOrDefault().SaldoPresupuesto.ToString(), 2);

                xObj = new PresupuestoEN();
                xObj = this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdSer.lblPeriodo.Text
                            && x.CCentroCosto == this.txtCodAre.Text.Trim()).FirstOrDefault();
                if (eLisMovDet.Count() == 0 && this.eOperacion == Universal.Opera.Cancelar)
                {
                    xObj.SaldoPresupuesto = Convert.ToDecimal(presupuesto) + (objDeta.PrecioUnitarioMovimientoDeta * objDeta.CantidadMovimientoDeta);
                }
                else
                {
                    xObj.SaldoPresupuesto = Convert.ToDecimal(presupuesto) - (objDeta.PrecioUnitarioMovimientoDeta * objDeta.CantidadMovimientoDeta);
                }
                PresupuestoRN.ModificarPresupuesto(xObj);
            }

        }

        public void MostrarNuevoNumero()
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);

            //mostrar en pantalla
            this.txtNumMovCab.Text = iNuevoNumero;
        }

        public void AdicionarMovimientoCabe()
        {
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iCuoEN);
        }

        public void AdicionarMovimientosDeta()
        {
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            string iCorrelativo = "0000";
            decimal iCostoFleteUnitario = 0;
            decimal MontoTotalMovimientoOCCabe = 0;
            string periodo = string.Empty;
            string clavemovimientocabe = string.Empty;

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in this.eLisMovDet)
            {
                //incrementar el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

                //actualizar algunos datos antes de grabar
                xMovDet.FechaMovimientoCabe = this.dtpFecMovCab.Text;
                xMovDet.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioConFlete(xMovDet, iCostoFleteUnitario);
                xMovDet.CostoFleteMovimientoDeta = iCostoFleteUnitario;
                xMovDet.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(xMovDet);
                xMovDet.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);
                xMovDet.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();
                xMovDet.ClaveMovimientoCabe = iClaveMovimientoCabe;
                xMovDet.CorrelativoMovimientoDeta = iCorrelativo;
                xMovDet.CostoFleteMovimientoCabe = Conversion.ADecimal("0", 0);
                xMovDet.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(xMovDet);
                xMovDet.CCodigoMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
                xMovDet.CodigoCentroCosto = this.txtCodAre.Text.Trim();
                xMovDet.DescripcionCentroCosto = this.txtDesAre.Text.Trim();
                xMovDet.CCodigoPartida = this.txtCodPar.Text.Trim();
                xMovDet.NCodigoPartida = this.txtDesPar.Text.Trim();
                if (this.eFlgCrdSol == 0)
                {
                    xMovDet.CantidadRecibida = xMovDet.CantidadMovimientoDeta;
                    xMovDet.CantidadPendiente = 0;
                    xMovDet.CantidadRecibidaVarios = xMovDet.CantidadMovimientoDeta.ToString();
                }
                else
                {
                    xMovDet.CantidadRecibida = 0;
                    xMovDet.CantidadPendiente = xMovDet.CantidadMovimientoDeta;
                }

                MontoTotalMovimientoOCCabe += xMovDet.CostoMovimientoDeta;
                periodo = xMovDet.PeriodoMovimientoCabe;
                clavemovimientocabe = xMovDet.ClaveMovimientoCabe;
            }
            MovimientoOCCabeRN.ActualizarCostoTotalMovimientoOSCabe(periodo, clavemovimientocabe, MontoTotalMovimientoOCCabe);
            //adicion masiva
            MovimientoOCDetaRN.AdicionarMovimientoDeta(this.eLisMovDet);
        }

        public MovimientoOCCabeEN ObtenerMovimientoCabeParaSegundaAdicion()
        {
            //objeto
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasamos los datos que queremos persistir para una segundo o mas adiciones
            iMovCabEN.FechaMovimientoCabe = this.dtpFecMovCab.Text;

            //devolver
            return iMovCabEN;
        }

        public bool ValidarTotalesCabeceraConDetalle()
        {
            if (this.eLisMovDet.Sum(x => x.CostoMovimientoDeta) != Convert.ToDecimal(this.txtTotalGral.Text))
            {
                Mensaje.OperacionDenegada("El total general no coincide con el monto total de detalle.", "Detalle");
                return false;
            }
            return true;
        }

        public void VentanaModificar(MovimientoOCCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
            this.CargarTipoCambio();
        }

        public void VentanaEliminar(MovimientoOCCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
            this.CargarTipoCambio();
        }

        public void VentanaVisualizar(MovimientoOCCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
            this.CargarTipoCambio();
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
            win.eCtrlFoco = this.txtCodAux;
            win.eIteEN.CodigoTabla = "CodPar";
            win.eIteEN.CodigoItemE = this.txtCodAre.Text.Trim();
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTablaYArea;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsCodigoPartidaValido()
        {
            return Generico.EsCodigoItemEActivoValido("CodPar", this.txtCodPar, this.txtDesPar, "Partidas");
        }

        public void GenerarOrdenServicioExcel()
        {
            Utilidad oMoneda = new Utilidad();
            MovimientoOCCabeEN iMovCabEn = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iMovCabEn);

            List<MovimientoOCDetaEN> list = this.eLisMovDet;

            ParametroEN iParEN = ParametroRN.BuscarParametro();

            string fileName = "OrdenServicio_" + iMovCabEn.ClaveMovimientoCabe + ".xlsx";

            string sourceFile = iParEN.RutaCarpetaPlantillas + @"\Plantilla Orden Servicio.xlsx";

            string targetPath = iParEN.RutaCarpetaPlantillas;

            System.IO.Directory.CreateDirectory(targetPath);

            targetPath = targetPath + @"\" + iMovCabEn.ClaveMovimientoCabe;

            System.IO.Directory.CreateDirectory(targetPath);

            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (System.IO.File.Exists(destFile))
            {
                System.IO.File.Delete(destFile);
            }

            System.IO.File.Copy(sourceFile, destFile, true);


            Excel.Application app = new Excel.Application();

            Excel.Workbook iLibro;
            Excel.Worksheet iHoja;
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            Excel.Range iRango;
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            object iOpcional = System.Reflection.Missing.Value;

            //creamos una nueva aplicacion excel
            app = new Microsoft.Office.Interop.Excel.Application();

            //adicionamos el libro a la aplicacion
            iLibro = app.Workbooks.Add(destFile);

            //obtener la hoja 1 del libro
            iHoja = iLibro.Worksheets["PLANTILLA"];

            //dando el zoom predeterminado a la hoja
            app.ActiveWindow.Zoom = 73;

            iHoja.Cells[5, "N"] = iMovCabEn.ClaveMovimientoCabe;
            iHoja.Cells[6, "N"] = iMovCabEn.FechaMovimientoCabe;

            iHoja.Cells[23, "M"] = "'" + iMovCabEn.CodigoAuxiliar;
            iHoja.Cells[25, "M"] = iMovCabEn.CorreoAuxiliar;
            iHoja.Cells[23, "D"] = iMovCabEn.DescripcionAuxiliar;
            iHoja.Cells[25, "D"] = iMovCabEn.NFormaPago;

            iHoja.Cells[28, "M"] = iMovCabEn.NCodigoMoneda;

            iHoja.Cells[29, "D"] = iMovCabEn.DireccionAuxiliar;


            iHoja.Cells[36, "D"] = iMovCabEn.GlosaMovimientoCabe;
            iHoja.Cells[39, "E"] = this.eLisMovDet.FirstOrDefault().NCodigoPartida;

            string resultado = string.Empty;

            if (iMovCabEn.CCodigoMoneda == "0")
            {
                iHoja.Cells[79, "O"] = iMovCabEn.ValorVtaMovimientoCabe;
                iHoja.Cells[81, "O"] = iMovCabEn.ValorVtaMovimientoCabe;
                iHoja.Cells[82, "O"] = iMovCabEn.IgvMovimientoCabe;
                iHoja.Cells[85, "O"] = iMovCabEn.MontoTotalMovimientoCabe;
                resultado = oMoneda.Convertir(iMovCabEn.MontoTotalMovimientoCabe.ToString("0.00"), true, "SOLES");
            }
            else
            {
                iHoja.Cells[79, "O"] = iMovCabEn.ValorVtaMovimientoCabe / iMovCabEn.TipoCambio;
                iHoja.Cells[81, "O"] = iMovCabEn.ValorVtaMovimientoCabe / iMovCabEn.TipoCambio;
                iHoja.Cells[82, "O"] = iMovCabEn.IgvMovimientoCabe / iMovCabEn.TipoCambio;
                iHoja.Cells[85, "O"] = iMovCabEn.MontoTotalMovimientoCabe / iMovCabEn.TipoCambio;
                resultado = oMoneda.Convertir((iMovCabEn.MontoTotalMovimientoCabe / iMovCabEn.TipoCambio).ToString("0.00"), true, "DOLARES");
            }


            iHoja.Cells[79, "C"] = resultado;

            int filaItem = 45;
#pragma warning disable CS0219 // La variable está asignada pero nunca se usa su valor
            int filaNueva = 0;
#pragma warning restore CS0219 // La variable está asignada pero nunca se usa su valor
            int item = 0;

            foreach (MovimientoOCDetaEN movDeta in list)
            {
                item++;
                iHoja.Cells[filaItem, "B"] = item;
                iHoja.Cells[filaItem, "C"] = movDeta.DescripcionExistencia;
                iHoja.Cells[filaItem, "K"] = movDeta.NombreUnidadMedida;
                iHoja.Cells[filaItem, "L"] = movDeta.CantidadMovimientoDeta;
                if (iMovCabEn.CCodigoMoneda == "0")
                {
                    iHoja.Cells[filaItem, "M"] = movDeta.PrecioUnitarioMovimientoDeta;
                    iHoja.Cells[filaItem, "O"] = movDeta.CostoMovimientoDeta;
                }
                else
                {
                    iHoja.Cells[filaItem, "M"] = movDeta.PrecioUnitarioMovimientoDeta / iMovCabEn.TipoCambio;
                    iHoja.Cells[filaItem, "O"] = movDeta.CostoMovimientoDeta / iMovCabEn.TipoCambio;
                }

                filaItem++;
                //Excel.Range to = iHoja.Range["A" + filaItem + ":AI" + filaItem];
                //to.Insert();
                //from.Copy(to);                
            }

            iLibro.SaveAs(destFile, Excel.XlFileFormat.xlWorkbookDefault, iOpcional, iOpcional, true, iOpcional,
                Excel.XlSaveAsAccessMode.xlExclusive, iOpcional, iOpcional, iOpcional, iOpcional, iOpcional);
            iLibro.Close(true, iOpcional, iOpcional);
            Process.Start(destFile);
            app.Quit();
        }

        private void txtCodTipSer_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoServicioValido();
        }

        private void txtCodTipSer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposServicios(); }
        }

        private void txtCodTipSer_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposServicios();
        }


        private void txtCodPer_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalValido();
        }

        private void txtCodPer_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonales();
        }

        private void txtCodPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonales(); }
        }

        private void txtValCotizacion_Validating(object sender, CancelEventArgs e)
        {
            int vC = 0;
            if (int.TryParse(this.txtValCotizacion.Text, out vC))
            {
                if (this.eOperacion == Universal.Opera.Adicionar)
                    this.lblValCot.Text = this.txtValCotizacion.Text == string.Empty ? DateTime.Now.ToShortDateString()
                        : DateTime.Now.AddDays(Convert.ToInt32(this.txtValCotizacion.Text)).ToShortDateString();
                else
                    this.lblValCot.Text = this.txtValCotizacion.Text == string.Empty ? this.lblValCot.Text
                        : Convert.ToDateTime(this.lblValCot.Text).AddDays(-this.valCoti)
                        .AddDays(Convert.ToInt32(this.txtValCotizacion.Text)).ToShortDateString();

                this.valCoti = Convert.ToInt32(this.txtValCotizacion.Text);
            }
            else
            {
                this.txtValCotizacion.Text = "0";
                Mensaje.OperacionDenegada("Debe ingresar un día valido.", "Detalle");
            }
        }

        private void wEditOrdenServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CerrarYDevolverPresupuesto();
            this.wOrdSer.Enabled = true;
        }

        private void txtGarantia_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(this.txtGarantia.Text) > 12)
                Cmb.SeleccionarValorItem(this.cmbGarantia, "001");
        }

        private void txtPreVenta_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtPreMatAcc_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarItem();
        }

        private void cmbMon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtCodMonSyD.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            if (this.txtCodMonSyD.Text == "1")
            {
                this.txtTipCam.ReadOnly = false;
                this.txtTipCam.Text = wTipoCambio;
                this.txtTipCam.Text = "0.0000";
                //this.txtTipCam.Focus();
            }
            else
            {
                this.txtTipCam.ReadOnly = true;
                this.txtTipCam.Text = "0.0000";
                //this.txtCodAux.Focus();
            }
            this.CargarTipoCambio();
        }

        private void dtpFecMovCab_Validated(object sender, EventArgs e)
        {
            this.ValidaFechaMovimientoCabe();
            this.CargarTipoCambio();
        }

        private void txtCodAre_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoAreaValido();
            if (this.txtCodAre.Text != string.Empty)
                if (this.ValidarSiAreaTienePresupuesto() == false) { return; }
        }

        private void txtCodAre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAreas(); }
        }

        private void txtCodAre_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAreas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificarItem();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodPar_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoPartidaValido();
        }

        private void txtCodPar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.txtCodAre.Text.Trim() == string.Empty)
                {
                    Mensaje.OperacionDenegada("Debe seleccionar el centro de costo", "Detalle");
                    this.txtCodAre.Focus();
                }
                else
                    this.ListarPartidas();
            }
        }

        private void txtCodPar_DoubleClick(object sender, EventArgs e)
        {
            if (this.txtCodAre.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debe seleccionar el centro de costo", "Detalle");
                this.txtCodAre.Focus();
            }
            else
                this.ListarPartidas();
        }

        private void txtPreVenta_Validated(object sender, EventArgs e)
        {
            this.AccionParaAgregarEliminarMovimientoDeta();
        }

        private void txtPreMatAcc_Validated(object sender, EventArgs e)
        {
            this.ObtenerValoresCalculados();
        }

        private void txtCodAre_Validated(object sender, EventArgs e)
        {

        }

        private void txtCodAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsProveedorValido();
        }

        private void txtCodAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarProveedores(); }
        }

        private void txtCodAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarProveedores();
        }
    }
}
