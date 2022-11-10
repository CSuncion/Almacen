using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.FuncionesGenericas;
using Presentacion.Listas;
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
            xCtrl.TxtTodo(this.txtIgv, true, "Igv", "ffff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCondiciones, true, "Condiciones", "vvff", 6);
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
            xCtrl.TxtNumeroPositivoConDecimales(this.txtPreVenta, true, "Precio Venta", "vvff", 2);
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtPreMatAcc, true, "Precio Material y Accesorio", "vvff", 2);
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
            this.txtCCalPrePro.Text = pMovCab.CCalculaPrecioPromedio;
            this.txtCConUni.Text = pMovCab.CConversionUnidad;
            this.txtCodPer.Text = pMovCab.CodigoPersonal;
            this.txtNomPer.Text = pMovCab.NombrePersonal;
            this.txtIgv.Text = pMovCab.IgvPorcentaje.ToString();
            this.txtCondiciones.Text = pMovCab.Condiciones;
            this.txtGarantia.Text = pMovCab.Garantia.ToString();
            Cmb.SeleccionarValorItem(this.cmbGarantia, pMovCab.CGarantia);
            this.txtValCotizacion.Text = pMovCab.ValidezCotizacion.ToString();
            this.txtPreVenta.Text = Formato.NumeroDecimal(pMovCab.PrecioVtaMovimientoCabe, 2);
            this.txtPreMatAcc.Text = Formato.NumeroDecimal(pMovCab.PrecioMaterialAccesorioOrdenServicio, 2);
            this.txtValorVenta.Text = Formato.NumeroDecimal(pMovCab.ValorVtaMovimientoCabe, 2);
            this.txtValorIGV.Text = Formato.NumeroDecimal(pMovCab.IgvMovimientoCabe, 2);
            this.txtTotalGral.Text = Formato.NumeroDecimal(pMovCab.MontoTotalMovimientoCabe, 2);
            Cmb.SeleccionarValorItem(this.cmbMon, pMovCab.CCodigoMoneda);
            Cmb.SeleccionarValorItem(this.cmbFormaPago, pMovCab.CFormaPago);
            this.txtCodAux.Text = pMovCab.CodigoAuxiliar;
            this.txtDesAux.Text = pMovCab.DescripcionAuxiliar;
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;
            this.eClavSolPedCab = pMovCab.ClaveSolicitudPedidoCabe;
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
            List<MovimientoOCDetaEN> iFuenteDatos = MovimientoOCDetaRN.RefrescarListaMovimientoDeta(this.eLisMovDet); ;
            Dgv.Franja iCondicionFranja = eFranjaDgvMovDet;
            string iClaveBusqueda = eClaveDgvMovDet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.NCodPar, "Partida", 100));
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
            win.eCtrlFoco = this.txtIgv;
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
            win.eCtrlFoco = this.txtGloMovCab;
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

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void ObtenerIgv()
        {
            //variables
            ParametroEN iParEN = ParametroRN.BuscarParametro();
            this.txtIgv.Text = iParEN.PorcentajeIgv.ToString();
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
            this.dtpPlazoEntrega.Text = this.txtValCotizacion.Text == string.Empty ? DateTime.Now.ToShortDateString()
                : DateTime.Now.AddDays(Convert.ToInt32(this.txtValCotizacion.Text)).ToShortDateString();
        }

        private void wEditOrdenServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wOrdSer.Enabled = true;
        }

        private void txtGarantia_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(this.txtGarantia.Text) > 12)
                Cmb.SeleccionarValorItem(this.cmbGarantia, "001");
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
