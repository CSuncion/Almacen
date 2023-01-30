using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.Listas;
using Presentacion.Principal;
using Presentacion.Maestros;
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Presentacion.ProcesosCompras
{
    public partial class wEditOrdenCompra : Heredados.MiForm8
    {
        public wEditOrdenCompra()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvTipOpe = TipoCambioEN.FecTipCam;
        string eNombreColumnaDgvPer = PresupuestoEN.CodPre;
        public Universal.Opera eOperacion;
        public string wTipoCambio, wano, wmes, wperiodo;
        Masivo eMas = new Masivo();
        public List<MovimientoOCDetaEN> eLisMovDet = new List<MovimientoOCDetaEN>();
        public List<LoteEN> eLisLot = new List<LoteEN>();
        public string eClaveDgvMovDet = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;
        public List<PresupuestoEN> eLisPre = new List<PresupuestoEN>();
        public List<TipoCambioEN> eLisTipCam = new List<TipoCambioEN>();
        public int eFlgCrdSol = 0;
        public bool eFlgEnvOC = true;
        public string eClavSolPedCab = string.Empty;
        #endregion

        #region Propietario

        public wOrdenCompra wOrdCom;

        #endregion

        #region Eventos controles

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
            xCtrl.TxtTodo(this.txtCodTipOpe, true, "Tipo Operacion", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipOpe, this.txtCodTipOpe, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer, true, "Personal", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer, this.txtCodPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPerAut, true, "Persona Autoriza", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPerAut, this.txtCodPerAut, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPerRec, true, "Persona Recibe", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPerRec, this.txtCodPerRec, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCosFle, false, "Flete", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, false, "Proveedor", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtOrdCom, false, "O / C", "vvff", 50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTipCam, false, "Tipo Cambio", "ffff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCTipDoc, false, "T.D", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNTipDoc, this.txtCTipDoc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDoc, false, "Serie", "vvff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumDoc, false, "N.D", "vvff", 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDoc, "vvff");
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
            xCtrl.Btn(this.btnPendiente, "vvff");
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
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wOrdCom.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            //Cargas Monedas
            this.CargarMonedas();

            //valores x defecto
            this.ValoresXDefecto();

            // Deshabilitar al propietario de esta ventana
            this.wOrdCom.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto()
        {
            txtPerMovCab.Text = wOrdCom.lblDescripcionPeriodo.Text;
        }

        public void VentanaAdicionar()
        {
            //             
            txtPerMovCab.Text = wOrdCom.lblDescripcionPeriodo.Text;
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
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            //this.txtTipCam.Text = wTipoCambio;
            this.dtpFecMovCab.Focus();
            this.CargarTipoCambio();
            this.btnPendiente.Enabled = false;
            this.eFlgCrdSol = 0;
            this.eFlgEnvOC = true;
        }

        public void VentanaModificar(MovimientoOCCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
            this.CargarTipoCambio();
            this.btnPendiente.Enabled = false;
        }

        public void VentanaEliminar(MovimientoOCCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
            this.CargarTipoCambio();
            this.btnPendiente.Enabled = false;
        }

        public void VentanaVisualizar(MovimientoOCCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
            this.CargarTipoCambio();
            if (pMovCab.FlagEnviadoMovimientoCabe)
            {
                if (pMovCab.CEstadoMovimientoCabe == "4")
                {
                    this.btnPendiente.Enabled = false;
                }
                else
                {
                    this.btnPendiente.Enabled = true;
                }
            }
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

        public void CargarMonedas()
        {
            Cmb.Cargar(this.cmbMon, ItemGRN.ListarItemsG("Moneda"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarTipoCambio()
        {
            TipoCambioEN objTipCam = new TipoCambioEN();
            objTipCam.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            eLisTipCam = TipoCambioRN.ListarTipoCambio(objTipCam);

            string fechaTipoCambio = Fecha.ObtenerDiaMesAno(Conversion.ADateTime(dtpFecMovCab.Text));

            if (eLisTipCam.Where(e => e.FechaTipoCambio == fechaTipoCambio).Count() == 0)
            {
                Mensaje.OperacionDenegada("Se debe ingresar un tipo de cambio para la fecha del documento.", this.wOrdCom.eTitulo);
                txtTipCam.Text = Formato.NumeroDecimal(0, 4);
            }
            else
                txtTipCam.Text = eLisTipCam.FirstOrDefault(e => e.FechaTipoCambio == fechaTipoCambio).VentaTipoCambio.ToString();

        }

        public void AsignarMovimientoCabe(MovimientoOCCabeEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCab.PeriodoMovimientoCabe = wOrdCom.lblPeriodo.Text;
            pMovCab.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();
            pMovCab.FechaMovimientoCabe = dtpFecMovCab.Text;
            pMovCab.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            pMovCab.DescripcionTipoOperacion = this.txtDesTipOpe.Text.Trim();
            pMovCab.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pMovCab.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            pMovCab.CodigoPersonal = this.txtCodPer.Text.Trim();
            pMovCab.CodigoPersonalAutoriza = this.txtCodPerAut.Text.Trim();
            pMovCab.CodigoPersonalRecibe = this.txtCodPerRec.Text.Trim();
            pMovCab.CostoFleteMovimientoCabe = Conversion.ADecimal(this.txtCosFle.Text, 0);
            pMovCab.CCodigoMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            pMovCab.TipoCambio = Conversion.ADecimal(this.txtTipCam.Text, 0);
            pMovCab.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pMovCab.DescripcionAuxiliar = this.txtDesAux.Text.Trim();
            pMovCab.OrdenCompra = this.txtOrdCom.Text.Trim();
            pMovCab.CTipoDocumento = this.txtCTipDoc.Text.Trim();
            pMovCab.SerieDocumento = this.txtSerDoc.Text.Trim();
            pMovCab.NumeroDocumento = this.txtNumDoc.Text.Trim();
            pMovCab.FechaDocumento = dtpFecDoc.Text;
            pMovCab.GlosaMovimientoCabe = this.txtGloMovCab.Text;
            pMovCab.COrigenVentanaCreacion = "1";//ingreso 
            if (pMovCab.FlagCreadoxSolicitud == 1)
            {
                this.eFlgCrdSol = 1;
                this.eFlgEnvOC = false;
            }
            pMovCab.FlagCreadoxSolicitud = this.eFlgCrdSol;
            pMovCab.FlagEnviadoMovimientoCabe = this.eFlgEnvOC;
            pMovCab.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }

        public void MostrarMovimientoCabe(MovimientoOCCabeEN pMovCab)
        {
            this.txtNumMovCab.Text = pMovCab.NumeroMovimientoCabe;
            this.dtpFecMovCab.Text = pMovCab.FechaMovimientoCabe;
            this.txtCodTipOpe.Text = pMovCab.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = pMovCab.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = pMovCab.CCalculaPrecioPromedio;
            this.txtCConUni.Text = pMovCab.CConversionUnidad;
            this.txtCodAlm.Text = pMovCab.CodigoAlmacen;
            this.txtDesAlm.Text = pMovCab.DescripcionAlmacen;
            this.txtCodPer.Text = pMovCab.CodigoPersonal;
            this.txtNomPer.Text = pMovCab.NombrePersonal;
            this.txtCodPerAut.Text = pMovCab.CodigoPersonalAutoriza;
            this.txtNomPerAut.Text = pMovCab.NombrePersonalAutoriza;
            this.txtCodPerRec.Text = pMovCab.CodigoPersonalRecibe;
            this.txtNomPerRec.Text = pMovCab.NombrePersonalRecibe;
            this.txtCosFle.Text = Formato.NumeroDecimal(pMovCab.CostoFleteMovimientoCabe, 2);
            Cmb.SeleccionarValorItem(this.cmbMon, pMovCab.CCodigoMoneda);
            this.txtCodMonSyD.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            this.txtTipCam.Text = Formato.NumeroDecimal(pMovCab.TipoCambio, 4);
            this.txtCodAux.Text = pMovCab.CodigoAuxiliar;
            this.txtDesAux.Text = pMovCab.DescripcionAuxiliar;
            this.txtOrdCom.Text = pMovCab.OrdenCompra;
            this.txtCTipDoc.Text = pMovCab.CTipoDocumento;
            this.txtNTipDoc.Text = pMovCab.NTipoDocumento;
            this.txtSerDoc.Text = pMovCab.SerieDocumento;
            this.txtNumDoc.Text = pMovCab.NumeroDocumento;
            this.dtpFecDoc.Text = pMovCab.FechaDocumento;
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;
            this.eClavSolPedCab = pMovCab.ClaveSolicitudPedidoCabe;
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
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoOCDetaEN.CosFleMovDet, "Flete", 70, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.NCodMon, "Moneda", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarMovimientoDetaDeBaseDatos(MovimientoOCCabeEN pObj)
        {
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;
            this.eLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void LLenarLotesDeBaseDatos(MovimientoOCCabeEN pObj)
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            iLotEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
            iLotEN.Adicionales.CampoOrden = LoteEN.CodExi + "," + LoteEN.CodLot;

            //ejecutar metodo
            this.eLisLot = LoteRN.ListarLotesDeClaveMovimientoCabe(iLotEN);
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
            if (this.wOrdCom.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wOrdCom.eTitulo) == false) { return; }

            //mostrar numero movimientoCabe
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarMovimientoCabe();

            //adicionando detalles
            this.AdicionarMovimientosDeta();

            //adicionando lotes
            this.AdicionarLotes();

            //actualizar las existencias referenciadas
            this.ActualizarExistenciasPorAdicion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la orden de compra correctamente", this.wOrdCom.eTitulo);

            //actualizar al propietario           
            this.wOrdCom.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
            this.wOrdCom.ActualizarVentana();

            //imprimir la nota
            //this.wOrdCom.AccionImprimirNota();

            this.GenerarOrdenCompra();

            //limpiar controles
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeParaSegundaAdicion());
            this.eLisMovDet.Clear();
            this.MostrarMovimientosDeta();
            this.eLisLot.Clear();
            this.CambiarSoloLecturaACodigoTipoOperacion();
            this.CambiarSoloLecturaACodigoAlmacen();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
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
            decimal iCostoFleteUnitario = this.ObtenerCostoFleteUnitario();
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
                xMovDet.CostoFleteMovimientoCabe = Conversion.ADecimal(this.txtCosFle.Text.Trim(), 0);
                xMovDet.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(xMovDet);
                xMovDet.CCodigoMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
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
            MovimientoOCCabeRN.ActualizarCostoTotalMovimientoOCCabe(periodo, clavemovimientocabe, MontoTotalMovimientoOCCabe);
            //adicion masiva
            MovimientoOCDetaRN.AdicionarMovimientoDeta(this.eLisMovDet);
        }

        public decimal ObtenerCostoFleteUnitario()
        {
            //asignar parametros
            decimal iTotalKilos = ListaG.Sumar<MovimientoOCDetaEN>(this.eLisMovDet, MovimientoOCDetaEN.CanMovDet);
            decimal iCostoFleteTotal = Conversion.ADecimal(this.txtCosFle.Text, 0);

            //ejecutar metodo
            return Math.Round(Operador.DivisionDecimal(iCostoFleteTotal, iTotalKilos), 2);
        }

        public void AdicionarLotes()
        {
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();

            //recorrer cada objeto
            foreach (LoteEN xLot in this.eLisLot)
            {
                //actualizar con la claveMovimientoCabe
                xLot.ClaveMovimientoCabe = iClaveMovimientoCabe;
            }

            //adicionar masivo
            LoteRN.AdicionarLote(this.eLisLot);
        }

        public void ActualizarExistenciasPorAdicion()
        {
            //asignar parametros
            List<MovimientoOCDetaEN> iLisMovDet = this.eLisMovDet;

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDetaOC(iLisMovDet);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wOrdCom.EsMovimientoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wOrdCom.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarMovimientoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //adicionando nuevos MovimientoDeta
            this.AdicionarMovimientosDeta();

            //actualizar existencias por adicion
            this.ActualizarExistenciasPorAdicion();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //adicionar lotes
            this.AdicionarLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la orden de compra correctamente", this.wOrdCom.eTitulo);

            //actualizar al wLot          
            this.wOrdCom.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
            this.wOrdCom.ActualizarVentana();

            //imprimir la nota
            //this.wOrdCom.AccionImprimirNota();
            this.GenerarOrdenCompra();

            //salir de la ventana
            this.Close();
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

        public void EliminarAntiguosLotes()
        {
            //asignar parametros
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();

            //ejecutar metodo
            LoteRN.EliminarLoteXClaveMovimientoCabe(iClaveMovimientoCabe);
        }

        public void ActualizarExistenciasPorEliminacion()
        {
            //asignar parametros
            List<MovimientoOCDetaEN> iLisMovDet = this.ListarMovimientosDeta();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDetaOC(iLisMovDet);
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDeta()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wOrdCom.EsMovimientoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wOrdCom.eTitulo) == false) { return; }

            //retornar presupuesto
            this.RetornarPresupuesto();

            //eliminar el registro
            this.EliminarMovimientoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la orden de compra correctamente", this.wOrdCom.eTitulo);

            //actualizar al wLot           
            this.wOrdCom.ActualizarVentana();

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

        public void ListarTiposOperacion()
        {
            //si es de lectura , entonces no lista
            if (txtCodTipOpe.ReadOnly == true) { return; }

            //instanciar
            wLisTipOpe win = new wLisTipOpe();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Operacion";
            win.eCtrlValor = this.txtCodTipOpe;
            win.eCtrlFoco = this.txtCodAlm;
            win.eTipOpeEN.CClaseTipoOperacion = "3";//orden de compra
            win.eCondicionLista = Listas.wLisTipOpe.Condicion.TiposOperacionXClaseActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsTipoOperacionValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodTipOpe.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            iTipOpeEN.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionOrdenCompraActivoValido(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, this.wOrdCom.eTitulo);
                this.txtCodTipOpe.Focus();
            }

            //mostrar datos
            this.txtCodTipOpe.Text = iTipOpeEN.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = iTipOpeEN.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = iTipOpeEN.CCalculaPrecioPromedio;
            this.txtCConUni.Text = iTipOpeEN.CConversionUnidad;

            //devolver
            return iTipOpeEN.Adicionales.EsVerdad;
        }

        public void DeshabitarControles()
        {
            if (this.txtCodTipOpe.Text == "02") //Compras
            {
                this.cmbMon.Enabled = true;
            }
            else
            {
                this.cmbMon.Enabled = false;
            }

        }

        public void ListarAlmacenes()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm;
            win.eCtrlFoco = this.txtCodPer;
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wOrdCom.eTitulo);
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
            this.txtCodPer.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer.Text = iAlmEN.NombrePersonal;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
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
            win.eCtrlFoco = this.txtCosFle;
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
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wOrdCom.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPer.Text = iPerEN.CodigoPersonal;
            this.txtNomPer.Text = iPerEN.NombrePersonal;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarPersonalesAutorizan()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPerAut.ReadOnly == true) { return; }

            //instanciar
            wLisPerAut win = new wLisPerAut();
            win.eVentana = this;
            win.eTituloVentana = "Personal Autorizan";
            win.eCtrlValor = this.txtCodPerAut;
            win.eCtrlFoco = this.txtCodPerRec;
            win.eCondicionLista = Listas.wLisPerAut.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalAutorizanValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodPerAut.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();
            iPerEN.CodigoPersonalAutoriza = this.txtCodPerAut.Text.Trim();
            iPerEN = PersonalAutorizanRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wOrdCom.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPerAut.Text = iPerEN.CodigoPersonalAutoriza;
            this.txtNomPerAut.Text = iPerEN.NombrePersonalAutoriza;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarPersonalesReciben()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer.ReadOnly == true) { return; }

            //instanciar
            wLisPerRec win = new wLisPerRec();
            win.eVentana = this;
            win.eTituloVentana = "Personal Reciben";
            win.eCtrlValor = this.txtCodPerRec;
            win.eCtrlFoco = this.txtCodAux;
            win.eCondicionLista = Listas.wLisPerRec.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalRecibenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodPerRec.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            iPerEN.CodigoPersonalRecibe = this.txtCodPerRec.Text.Trim();
            iPerEN = PersonalRecibenRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wOrdCom.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPerRec.Text = iPerEN.CodigoPersonalRecibe;
            this.txtNomPerRec.Text = iPerEN.NombrePersonalRecibe;

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
            win.eCtrlFoco = this.txtOrdCom;
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
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wOrdCom.eTitulo);
                this.txtCodAux.Focus();
            }

            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void ListarTiposDocumento()
        {
            //si es de lectura , entonces no lista
            if (this.txtCTipDoc.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Documento";
            win.eCtrlValor = this.txtCTipDoc;
            win.eCtrlFoco = this.txtSerDoc;
            win.eIteEN.CodigoTabla = "TipCom";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsTipoDocumentoValido()
        {
            return Generico.EsCodigoItemGValido("TipCom", this.txtCTipDoc, this.txtNTipDoc, "Tipo documento");
        }


        public MovimientoOCCabeEN NuevoMovimientoCabeDeVentana()
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN;
        }

        public string ObtenerClaveMovimientoCabe()
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public void AccionAgregarItem()
        {
            //valida cuando no hay tipo operacion
            if (this.ElegirTipoOperacionAntesDeLlenarGrilla() == false) { return; }

            //valida cuando no hay almacen
            if (this.ElegirAlmacenAntesDeLlenarGrilla() == false) { return; }

            //instanciar
            wDetalleOrdenCompra win = new wDetalleOrdenCompra();
            win.wEditOrdCom = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleOrdenCompra win = new wDetalleOrdenCompra();
            win.wEditOrdCom = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            wDetalleOrdenCompra win = new wDetalleOrdenCompra();
            win.wEditOrdCom = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public void AccionPendienteItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que visualizar", "Detalle");
                return;
            }

            wDetalleOrdenCompraPendiente win = new wDetalleOrdenCompraPendiente();
            win.wEditOrdCom = this;
            win.eOperacion = Universal.Opera.Pendiente;
            this.eFranjaDgvMovDet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaPendiente(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public bool ElegirTipoOperacionAntesDeLlenarGrilla()
        {
            if (this.txtCodTipOpe.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un tipo de operacion", "Tipo operacion");
                this.txtCodTipOpe.Focus();
                return false;
            }
            return true;
        }

        public bool ElegirAlmacenAntesDeLlenarGrilla()
        {
            if (this.txtCodAlm.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un almacen", "Almacen");
                this.txtCodAlm.Focus();
                return false;
            }
            return true;
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
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.wOrdCom.eTitulo);
                this.dtpFecMovCab.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public void CambiarSoloLecturaACodigoAlmacen()
        {
            //valida cuando no es adicionar
            if (this.eOperacion != Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtCodAlm, iValor);
        }

        public void CambiarSoloLecturaACodigoTipoOperacion()
        {
            //valida cuando no es adicionar
            if (this.eOperacion != Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtCodTipOpe, iValor);
        }

        public void MostrarFechaIngresoSugerida()
        {
            //asignar parametros
            string iPeriodoRegistro = this.wOrdCom.lblPeriodo.Text;
            string iFechaMovimientoCabeDtp = Fecha.ObtenerDiaMesAno(this.dtpFecMovCab.Value);
            string iFechaDocumentoDtp = Fecha.ObtenerDiaMesAno(this.dtpFecDoc.Value);

            //ejecutar metodo
            this.dtpFecMovCab.Text = MovimientoOCCabeRN.ObtenerFechaMovimientoCabeSugerido(iPeriodoRegistro, iFechaMovimientoCabeDtp);
            this.dtpFecDoc.Text = MovimientoOCCabeRN.ObtenerFechaMovimientoCabeSugerido(iPeriodoRegistro, iFechaDocumentoDtp);
        }

        public void Cancelar()
        {
            List<MovimientoOCDetaEN> eListMovDeta = new List<MovimientoOCDetaEN>();
            List<MovimientoOCDetaEN> eListMovDetTmp = new List<MovimientoOCDetaEN>();

            eListMovDeta = this.eLisMovDet;

            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            this.LLenarMovimientoDetaDeBaseDatos(iCuoEN);

            if (this.eLisMovDet.Count > 0)
            {
                foreach (MovimientoOCDetaEN obj in eListMovDeta)
                {
                    if (eLisMovDet.Where(e => e.ClaveObjeto == obj.ClaveObjeto).Count() == 0)
                    {
                        eListMovDetTmp.Add(obj);
                    }
                }

                PresupuestoEN iPerEN = new PresupuestoEN();
                iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
                this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);



                PresupuestoEN xObj = new PresupuestoEN();
                foreach (MovimientoOCDetaEN objDeta in eListMovDetTmp)
                {
                    string presupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdCom.lblPeriodo.Text
                                            && x.CCentroCosto == objDeta.CodigoCentroCosto).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                                            Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdCom.lblPeriodo.Text 
                                            && x.CCentroCosto == objDeta.CodigoCentroCosto).FirstOrDefault().SaldoPresupuesto.ToString(), 2);

                    xObj = new PresupuestoEN();
                    xObj.CodigoPresupuesto = wOrdCom.lblPeriodo.Text;
                    xObj.CCentroCosto = objDeta.CodigoCentroCosto;
                    xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(presupuesto) + (objDeta.PrecioUnitarioMovimientoDeta * objDeta.CantidadMovimientoDeta);
                    PresupuestoRN.ModificarPresupuesto(xObj);
                }
            }
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wOrdCom.eTitulo);
        }

        public void GenerarOrdenCompra()
        {
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);

            AuxiliarEN aux = AuxiliarRN.BuscarAuxiliarXCodigo(iCuoEN.CodigoAuxiliar);

            iCuoEN = MovimientoOCCabeRN.BuscarMovimientoCabeXClave(iCuoEN.ClaveMovimientoCabe);


            List<MovimientoOCDetaEN> list = this.eLisMovDet;

            ParametroEN iParEN = ParametroRN.BuscarParametro();

            string fileName = "OrdenCompra_" + iCuoEN.ClaveMovimientoCabe + ".xlsx";

            string sourceFile = iParEN.RutaCarpetaPlantillas + @"\FORMATO REQUERIMIENTO DE COMPRA.xlsx";

            string targetPath = iParEN.RutaCarpetaPlantillas;

            string destFile = System.IO.Path.Combine(targetPath, fileName);

            System.IO.Directory.CreateDirectory(targetPath);

            if (System.IO.File.Exists(destFile))
            {
                System.IO.File.Delete(destFile);
            }

            System.IO.File.Copy(sourceFile, destFile, true);


            Excel.Application app = new Excel.Application();

            Excel.Workbook iLibro;
            Excel.Worksheet iHoja;
            Excel.Range iRango;
            object iOpcional = System.Reflection.Missing.Value;

            //creamos una nueva aplicacion excel
            app = new Microsoft.Office.Interop.Excel.Application();

            //adicionamos el libro a la aplicacion
            iLibro = app.Workbooks.Add(destFile);

            //obtener la hoja 1 del libro
            iHoja = iLibro.Worksheets["PLANTILLA RQM"];

            //dando el zoom predeterminado a la hoja
            app.ActiveWindow.Zoom = 80;

            string[] fechaOrdenCompra = DateTime.Now.ToString("dd/MM/yyyy").Split('/');

            string anio = string.Empty, mes = string.Empty, dia = string.Empty, fecha = string.Empty;


            anio = fechaOrdenCompra[2];
            mes = string.Format("{0:00}", fechaOrdenCompra[1]);
            dia = string.Format("{0:00}", fechaOrdenCompra[0]);

            fecha = dia.ToString() + "/" + mes.ToString() + "/" + anio.ToString();

            iHoja.Cells[3, "BC"] = fecha;
            iHoja.Cells[4, "BC"] = fecha;

            iHoja.Cells[12, "E"] = iCuoEN.GlosaMovimientoCabe;

            iHoja.Cells[10, "AT"] = iCuoEN.FechaMovimientoCabe;

            //iHoja.Cells[12, "F"] = iCuoEN.NumeroSolicitudPedidoCabe;
            //iHoja.Cells[13, "F"] = iCuoEN.NOrigenVentanaCreacion;
            //iHoja.Cells[14, "F"] = iCuoEN.FechaSolicitudPedidoCabe;
            //iHoja.Cells[17, "F"] = iCuoEN.NumeroSolicitudPedidoCabe;

            //iHoja.Cells[21, "F"] = iCuoEN.DescripcionAuxiliar;
            //iHoja.Cells[22, "F"] = iCuoEN.CodigoAuxiliar;

            int filaItem = 17;
            int item = 0;

            foreach (MovimientoOCDetaEN movDeta in list)
            {
                item++;
                iHoja.Cells[filaItem, "B"] = item;
                iHoja.Cells[filaItem, "C"] = movDeta.CodigoExistencia;
                iHoja.Cells[filaItem, "D"] = movDeta.DescripcionExistencia;
                iHoja.Cells[filaItem, "W"] = movDeta.CantidadMovimientoDeta;
                iHoja.Cells[filaItem, "Y"] = movDeta.NombreUnidadMedida;
                iHoja.Cells[filaItem, "Z"] = movDeta.NombreUnidadMedida;
                iHoja.Cells[filaItem, "BB"] = movDeta.DescripcionCentroCosto;
                filaItem++;
                Excel.Range to = iHoja.Range["B" + filaItem + ":BH" + filaItem];
                to.Insert();
                //from.Copy(to);                
            }

            iLibro.SaveAs(destFile, Excel.XlFileFormat.xlWorkbookDefault, iOpcional, iOpcional, true, iOpcional,
                Excel.XlSaveAsAccessMode.xlExclusive, iOpcional, iOpcional, iOpcional, iOpcional, iOpcional);
            iLibro.Close(true, iOpcional, iOpcional);
            app.Quit();

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
                foreach (MovimientoOCDetaEN objDeta in eLisMovDet)
                {
                    this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);
                    string presupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdCom.lblPeriodo.Text
                && x.CCentroCosto == objDeta.CodigoCentroCosto).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wOrdCom.lblPeriodo.Text && x.CCentroCosto == objDeta.CodigoCentroCosto).FirstOrDefault().SaldoPresupuesto.ToString(), 2);

                    xObj = new PresupuestoEN();
                    xObj.CodigoPresupuesto = wOrdCom.lblPeriodo.Text;
                    xObj.CCentroCosto = objDeta.CodigoCentroCosto;
                    xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(presupuesto) + (objDeta.PrecioUnitarioMovimientoDeta * objDeta.CantidadMovimientoDeta);
                    PresupuestoRN.ModificarPresupuesto(xObj);
                }
            }
        }

        #endregion


        private void wEditOrdenCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wOrdCom.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCodTipOpe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposOperacion(); }
        }

        private void txtCodTipOpe_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposOperacion();
        }

        private void txtCodTipOpe_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoOperacionValido();
        }

        private void txtCodAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValido();
        }

        private void txtCodAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes(); }
        }

        private void txtCodAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes();
        }

        private void txtCodPer_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalValido();
        }

        private void txtCodPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonales(); }
        }

        private void txtCodPer_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonales();
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

        private void txtCTipDoc_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoDocumentoValido();
        }

        private void txtCTipDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposDocumento(); }
        }

        private void txtCTipDoc_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposDocumento();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarItem();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificarItem();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

        private void dtpFecMovCab_Validated(object sender, EventArgs e)
        {
            this.ValidaFechaMovimientoCabe();
            this.CargarTipoCambio();
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

        private void txtCodPerAut_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonalesAutorizan();
        }

        private void txtCodPerAut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonalesAutorizan(); }
        }

        private void txtCodPerAut_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalAutorizanValido();
        }

        private void txtCodTipOpe_Validated(object sender, EventArgs e)
        {
            //this.DeshabitarControles();
        }

        private void btnPendiente_Click(object sender, EventArgs e)
        {
            this.AccionPendienteItem();
        }

        private void txtCodPerRec_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonalesReciben();
        }

        private void txtCodPerRec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonalesReciben(); }
        }

        private void txtCodPerRec_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalRecibenValido();
        }
    }
}
