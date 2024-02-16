using Negocio;
using Presentacion.Desarrollador;
using Presentacion.Maestros;
using Presentacion.Sistema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles.ControlesWindows;
using Comun;
using WinControles;
using Presentacion.Procesos;
using Presentacion.ProcesosCompras;
using Presentacion.Varios;
using Entidades.Adicionales;
using Presentacion.Impresiones;
using Presentacion.Consultas;
using System.Threading;

namespace Presentacion.Principal
{
    public partial class wMenu : Form
    {
        public wMenu()
        {
            InitializeComponent();
        }

        #region Metodos

        public void NuevaVentanaAcceso()
        {
            //instanciamos wAcceso
            wAcceso win = new wAcceso();
            win.wMen = this;
            win.NuevaVentana();
        }

        public List<Form> ObtenerListaDeVentanasAbiertas()
        {
            //lista resultado
            List<Form> iLisRes = new List<Form>();

            //solo excepto el wMenu y el wAcceso
            foreach (Form xWin in Application.OpenForms)
            {
                if (xWin.Name != "wMenu" && xWin.Name != "wAcceso")
                {
                    iLisRes.Add(xWin);
                }
            }

            //devolver
            return iLisRes;
        }

        public void EliminarTodasLasVentanasAbiertas()
        {
            //obtener la lista de ventanas a eliminar
            List<Form> iLisVenEli = this.ObtenerListaDeVentanasAbiertas();

            //obtener el numero de formularios abiertos
            int iNumeroVentanasAbiertas = iLisVenEli.Count;

            //ir eliminando cada ventana 
            for (int i = 0; i < iNumeroVentanasAbiertas; i++)
            {
                iLisVenEli[i].Close();
            }
        }

        public void EliminarTodosLosTabVentanas()
        {
            //esta ventana puede ser instanciada por el boton cambiar usuario
            //y en ese momento puede tener modulos abiertos , entonces cuando el usuario
            //ingrese con otro usuario , cerraremos todos los modulos 
            //obtener el numero de tab
            int iNroTabPage = this.tbcContenedor.TabPages.Count;

            //eliminar todos los tabpage pero desde el indice 1
            for (int i = 0; i < iNroTabPage; i++)
            {
                this.tbcContenedor.TabPages.RemoveAt(0);
            }
        }

        public void FormatoVentanaHijoPrincipal(Form pWin, ToolStripMenuItem pItem, ToolStripButton pAccDir, int PAncVen, int pAltVen)
        {
            pItem.Enabled = false;
            if (pAccDir != null) { pAccDir.Enabled = false; }
            this.tbcContenedor.Visible = true;
            //this.BackColor = System.Drawing.SystemColors.Control;
            this.BackColor = Color.White;
            TabCtrl.InsertarVentanaConTabPage(this.tbcContenedor, pWin, PAncVen, pAltVen);
        }

        public void CerrarVentanaHijo(Form pWin, ToolStripMenuItem pItem, ToolStripButton pAccDir)
        {
            pItem.Enabled = true;
            if (pAccDir != null) { pAccDir.Enabled = true; }
            TabCtrl.EliminarTabPageAlCerrarVentana(this.tbcContenedor, pWin);
            if (this.tbcContenedor.TabPages.Count == 0)
            {
                this.tbcContenedor.Visible = false;
                this.BackColor = Color.Gray;
            }
        }

        public void BloquearSistema()
        {
            wBloquearSistema win = new wBloquearSistema();
            this.tbcContenedor.Visible = false;
            this.BackColor = Color.Gray;
            win.wMen = this;
            win.NuevaVentana();
        }

        public void CambiarAcceso()
        {
            //instanciamos wAcceso
            wAcceso win = new wAcceso();
            this.tbcContenedor.Visible = false;
            this.BackColor = Color.Gray;
            win.wMen = this;
            win.eFlagInvoca = 1;
            win.NuevaVentana();
        }

        public void HabilitarAcciones()
        {
            //asignar parametros          
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaMenuPrincipal();

            //ejecutar metodo para el menu
            this.HabilitaAccionesMenu(iLisPer);

            //ejecutar metodo para los accesos directos
            this.HabilitaAccionesAccesosDirectos(iLisPer);
        }

        public void HabilitaAccionesMenu(Hashtable pListaPermisos)
        {
            //asignar parametros
            MenuStrip iMenu = msMenu;
            Hashtable iLisPer = pListaPermisos;

            //ejecutar metodo
            MeSt.HabilitarItems(iMenu, iLisPer);
        }

        public void HabilitaAccionesAccesosDirectos(Hashtable pListaPermisos)
        {
            //asignar parametros
            ToolStrip iTs = this.tsAccDir;
            Hashtable iLisPer = pListaPermisos;

            //ejecutar metodo
            Tst.HabilitarItems(iTs, iLisPer);
        }

        #endregion

        #region Instancias

        public void InstanciarEmpresas()
        {
            wEmpresa win = new wEmpresa();
            this.FormatoVentanaHijoPrincipal(win, this.IteEmpresas, null, 85, 85);
            win.NuevaVentana();
        }

        public void InstanciarUsuarios()
        {
            wUsuario win = new wUsuario();
            this.FormatoVentanaHijoPrincipal(win, this.IteUsuarios, null, 80, 80);
            win.NuevaVentana();
        }

        public void InstanciarPerfil()
        {
            wPerfil win = new wPerfil();
            this.FormatoVentanaHijoPrincipal(win, this.ItePerfiles, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarCambioDeClave()
        {
            wCambiarClave win = new wCambiarClave();
            this.FormatoVentanaHijoPrincipal(win, this.ItecambioDeClave, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarBotones()
        {
            wBoton win = new wBoton();
            this.FormatoVentanaHijoPrincipal(win, this.IteBotones, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarVentanas()
        {
            wVentana win = new wVentana();
            this.FormatoVentanaHijoPrincipal(win, this.IteVentanas, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarTablasGenerales()
        {
            wTablasGeneral win = new wTablasGeneral();
            this.FormatoVentanaHijoPrincipal(win, this.IteTablasGenerales, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarTiposOperaciones()
        {
            wTipoOperacion win = new wTipoOperacion();
            this.FormatoVentanaHijoPrincipal(win, this.IteTiposOperacion, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarPersonales()
        {
            wPersonal win = new wPersonal();
            this.FormatoVentanaHijoPrincipal(win, this.ItePersonalAlmacen, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarPersonalAutorizan()
        {
            wPersonalAutorizan win = new wPersonalAutorizan();
            this.FormatoVentanaHijoPrincipal(win, this.ItePersonalAutorizan, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarPersonalReciben()
        {
            wPersonalReciben win = new wPersonalReciben();
            this.FormatoVentanaHijoPrincipal(win, this.ItePersonalReciben, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarAuxiliares()
        {
            wAuxiliar win = new wAuxiliar();
            this.FormatoVentanaHijoPrincipal(win, this.IteAuxiliares, this.tsbAuxiliares, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarPeriodos()
        {
            wPeriodo win = new wPeriodo();
            this.FormatoVentanaHijoPrincipal(win, this.ItePeriodos, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarAlmacenes()
        {
            wAlmacen win = new wAlmacen();
            this.FormatoVentanaHijoPrincipal(win, this.IteAlmacenes, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarExistencias()
        {
            wExistencia win = new wExistencia();
            this.FormatoVentanaHijoPrincipal(win, this.IteExistencias, null, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarIngresos()
        {
            wIngresos win = new wIngresos();
            this.FormatoVentanaHijoPrincipal(win, this.IteIngresos, this.tsbIngresos, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarSolicitudPedido()
        {
            wSolicitudPedido win = new wSolicitudPedido();
            this.FormatoVentanaHijoPrincipal(win, this.iteSolicitudPedido, null, 90, 90);
            win.NuevaVentana();
        }
        public void InstanciarRequerimiento()
        {
            wRequerimiento win = new wRequerimiento();
            this.FormatoVentanaHijoPrincipal(win, this.iteRequerimiento, null, 90, 90);
            win.NuevaVentana();
        }
        public void InstanciarExportarOrdenCompra()
        {
            wExportarOrdenCompraAContabilidad win = new wExportarOrdenCompraAContabilidad();
            this.FormatoVentanaHijoPrincipal(win, this.iteExportarOrdComAConta, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarOrdenCompra()
        {
            wOrdenCompra win = new wOrdenCompra();
            this.FormatoVentanaHijoPrincipal(win, this.iteOrdenCompra, null, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarPresupuesto()
        {
            wPresupuesto win = new wPresupuesto();
            this.FormatoVentanaHijoPrincipal(win, this.itePresupuestos, null, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarEnviarRecibo()
        {
            wEnviarRecibos win = new wEnviarRecibos();
            this.FormatoVentanaHijoPrincipal(win, this.IteEnviarRecibo, null, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarCentrosCostos()
        {
            wCentroCosto win = new wCentroCosto();
            //this.FormatoVentanaHijoPrincipal(win, this.IteCentroCosto, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarSalidas()
        {
            wSalidas win = new wSalidas();
            this.FormatoVentanaHijoPrincipal(win, this.IteSalidas, this.tsbSalidas, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarRecalculo()
        {
            wRecalculo win = new wRecalculo();
            this.FormatoVentanaHijoPrincipal(win, this.IteRecalculoSaldos, this.tsbRecalculo, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarFormulas()
        {

        }

        public void InstanciarTransferencias()
        {
            wTransferencias win = new wTransferencias();
            this.FormatoVentanaHijoPrincipal(win, this.IteTransferencias, this.tsbTransferencias, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarParametrosGenerales()
        {
            wParametrosGenerales win = new wParametrosGenerales();
            this.FormatoVentanaHijoPrincipal(win, this.IteParametros, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarProducciones()
        {

        }

        public void InstanciarCopiaSeguridadBD()
        {
            wCopiaSeguridad win = new wCopiaSeguridad();
            this.FormatoVentanaHijoPrincipal(win, this.IteCopiaSeguridadBD, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarPartesTrabajo()
        {

        }

        public void InstanciarKardexValorizado()
        {
            wImpKardexValorizado win = new wImpKardexValorizado();
            this.FormatoVentanaHijoPrincipal(win, this.IteKardexValorizado, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarKardexFisico()
        {
            wImpKardexFisico win = new wImpKardexFisico();
            this.FormatoVentanaHijoPrincipal(win, this.IteKardexFisico, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarTablasEmpresas()
        {
            wTablasEmpresa win = new wTablasEmpresa();
            this.FormatoVentanaHijoPrincipal(win, this.IteTablasEmpresa, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarLicitaciones()
        {

        }

        public void InstanciarImportacionContabilidad()
        {
            wImportarContabilidad win = new wImportarContabilidad();
            this.FormatoVentanaHijoPrincipal(win, this.IteImpContabilidad, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarExistenciasGeneralesDetalle()
        {
            wImpExistenciaGeneralDeta win = new wImpExistenciaGeneralDeta();
            this.FormatoVentanaHijoPrincipal(win, this.IteExiGenDetalle, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarMigrarExistencias()
        {
            wMigrarExistencias win = new wMigrarExistencias();
            this.FormatoVentanaHijoPrincipal(win, this.IteMigracionExistencias, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarValidarExistencias()
        {
            wValidarExistencias win = new wValidarExistencias();
            this.FormatoVentanaHijoPrincipal(win, this.IteValidarExistencia, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarSaldosPorExistencia()
        {
            wSaldosPorExistencia win = new wSaldosPorExistencia();
            this.FormatoVentanaHijoPrincipal(win, this.IteSaldosPorExistencia, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarMovimientos()
        {
            wMovimientos win = new wMovimientos();
            this.FormatoVentanaHijoPrincipal(win, this.IteMovimientos, null, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarExistenciasGeneralesResumen()
        {
            wImpExistenciaGeneralResu win = new wImpExistenciaGeneralResu();
            this.FormatoVentanaHijoPrincipal(win, this.IteExiGenResumen, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarResumenTipoExistencia()
        {
            wImpResumenTipoExistencia win = new wImpResumenTipoExistencia();
            this.FormatoVentanaHijoPrincipal(win, this.IteResumenTipoExistencia, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarInventarios()
        {
            wInventario win = new wInventario();
            this.FormatoVentanaHijoPrincipal(win, this.IteInventarios, null, 0, 87);
            win.NuevaVentana();
        }

        public void InstanciarDocumentosEmitidosResumen()
        {
            wImpDocumentosEmitidosResu win = new wImpDocumentosEmitidosResu();
            this.FormatoVentanaHijoPrincipal(win, this.IteDocEmiResumen, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarDocumentosEmitidosDetalle()
        {
            wImpDocumentosEmitidosDeta win = new wImpDocumentosEmitidosDeta();
            this.FormatoVentanaHijoPrincipal(win, this.IteDocEmiDetalle, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarRecords()
        {
            wImpRecords win = new wImpRecords();
            this.FormatoVentanaHijoPrincipal(win, this.IteRepSalRecord, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarSalidasCentroCostoDetalle()
        {
            wImpSalidasCeCoDeta win = new wImpSalidasCeCoDeta();
            this.FormatoVentanaHijoPrincipal(win, this.IteRepSalCeCoDeta, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarControlMovimientoISDetalle()
        {
            wImpControlMovISDeta win = new wImpControlMovISDeta();
            this.FormatoVentanaHijoPrincipal(win, this.IteConMovISDetalle, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarAlertaStockMinimo()
        {
            wAlertaStockMinimo win = new wAlertaStockMinimo();
            this.FormatoVentanaHijoPrincipal(win, this.IteAlertaStockMinimo, null, 87, 94);
            win.NuevaVentana();
        }

        public void InstanciarCierreAnual()
        {
            wCierreAnual win = new wCierreAnual();
            this.FormatoVentanaHijoPrincipal(win, this.IteCierreAnual, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarMigracionProduccion()
        {
            wMigrarProduccion win = new wMigrarProduccion();
            this.FormatoVentanaHijoPrincipal(win, this.IteMigrarProduccion, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteProduccionFormatoEnvasado()
        {
            wProduccionRangoFecha win = new wProduccionRangoFecha();
            this.FormatoVentanaHijoPrincipal(win, this.IteFormatoEnvasado, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarFactorCostos()
        {

        }

        public void InstanciarFactorCIF()
        {

        }

        public void InstanciarPlanEncajado()
        {
            wPlanEncajado win = new wPlanEncajado();
            //this.FormatoVentanaHijoPrincipal(win, this.ItePlanEncajado, this.tsbPlanEncajado, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarRecalculoProduccion()
        {
            wRecalculoProduccion win = new wRecalculoProduccion();
            this.FormatoVentanaHijoPrincipal(win, this.IteRecalculoProduccion, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarDoctor()
        {
            wDoctor win = new wDoctor();
            this.FormatoVentanaHijoPrincipal(win, this.IteDoctor, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarRetiquetados()
        {
            wRetiquetado win = new wRetiquetado();
            //this.FormatoVentanaHijoPrincipal(win, this.IteRetiquetado, this.tsbRetiquetado, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarLiberacionesSinMovimientos()
        {
            wLiberacionesSinMovimientos win = new wLiberacionesSinMovimientos();
            this.FormatoVentanaHijoPrincipal(win, this.IteLiberacionesSinMovimientos, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosUnitariosPorProducto()
        {
            wCostoUnitarioPorFechas win = new wCostoUnitarioPorFechas();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosUniPorProducto, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosUnitariosPromedioAcumulado()
        {
            wCostoUnitarioPromedioAcumulado win = new wCostoUnitarioPromedioAcumulado();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosUniPromediosAcumulados, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosUnitariosVariabilidadCosto()
        {
            wCostoUnitarioVariabilidadCosto win = new wCostoUnitarioVariabilidadCosto();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosUniVarCostos, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosPresupuestadoVsRealPorProducto()
        {
            wPresupuestoVsRealXProducto win = new wPresupuestoVsRealXProducto();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosPreVsReaXPro, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosPresupuestadoVsRealPorFechas()
        {
            wPresupuestoVsRealXFechas win = new wPresupuestoVsRealXFechas();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosPreVsReaXFec, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosAcumuladosPorProcesos()
        {
            wCostosAcumuladosPorProceso win = new wCostosAcumuladosPorProceso();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosAcuPorProcesos, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosLoteEtapaEnvasado()
        {
            wCostoLoteEtaEnv win = new wCostoLoteEtaEnv();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosLotEtaEnv, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosLoteClasificacionEncajado()
        {
            wCostoLoteClaEnc win = new wCostoLoteClaEnc();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosLotClaEnc, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosLoteEtapaEncajado()
        {
            wCostoLoteEtaEnc win = new wCostoLoteEtaEnc();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosLotEtaEnc, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosLoteEtapaRetiquetado()
        {
            wCostoLoteEtaRet win = new wCostoLoteEtaRet();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosLotEtaRet, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCostosLoteTotalProduccion()
        {
            wCostoTotalProduccion win = new wCostoTotalProduccion();
            this.FormatoVentanaHijoPrincipal(win, this.IteCosLotTotPro, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteCumplimientoProduccion()
        {
            wPorCumplimientoProduccion win = new wPorCumplimientoProduccion();
            this.FormatoVentanaHijoPrincipal(win, this.ItePorCumProd, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarConsultaProductoTerminado()
        {
            wProductoTerminado win = new wProductoTerminado();
            this.FormatoVentanaHijoPrincipal(win, this.IteConsultaProductoTerminado, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarConsultaProduccionesConSaldo()
        {
            wProduccionesConSaldo win = new wProduccionesConSaldo();
            this.FormatoVentanaHijoPrincipal(win, this.IteProduccionConSaldo, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarConsultaProduccionesSinLiberar()
        {
            wProduccionesSinLiberar win = new wProduccionesSinLiberar();
            this.FormatoVentanaHijoPrincipal(win, this.IteControlCalidad, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteKpiDesmedro()
        {
            wKpiDesmedro win = new wKpiDesmedro();
            this.FormatoVentanaHijoPrincipal(win, this.IteKpiDesmedro, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteKpiVersus()
        {
            wKpiVersus win = new wKpiVersus();
            this.FormatoVentanaHijoPrincipal(win, this.IteKpiVersus, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarReporteDesmedroPT()
        {
            wDesmedroPT win = new wDesmedroPT();
            this.FormatoVentanaHijoPrincipal(win, this.IteDesPT, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarTipoCambio()
        {
            wTipoCambio win = new wTipoCambio();
            this.FormatoVentanaHijoPrincipal(win, this.iteTipoCambio, null, 90, 90);
            win.NuevaVentana();
        }
        public void InstanciarSolicitudPedidos()
        {
            wSolicitudPedidos win = new wSolicitudPedidos();
            this.FormatoVentanaHijoPrincipal(win, this.IteSolicitudPedidos, null, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarConsultaOrdenCompra()
        {
            wMovimientosOrdenCompra win = new wMovimientosOrdenCompra();
            this.FormatoVentanaHijoPrincipal(win, this.IteConsultaOrdenCompra, null, 90, 90);
            win.NuevaVentana();
        }
        public void InstanciarIngresosOrdenCompra()
        {
            wIngresosOrdenCompra win = new wIngresosOrdenCompra();
            this.FormatoVentanaHijoPrincipal(win, this.IteIngresosOrdenCompra, null, 90, 90);
            win.NuevaVentana();
        }

        public void InstanciarIngOCCentroCosto()
        {
            wImpIngresosOCCeCo win = new wImpIngresosOCCeCo();
            this.FormatoVentanaHijoPrincipal(win, this.IteRepIngOCCeCo, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarStockFisicoProgramado()
        {
            wImpStockFisicoProgramado win = new wImpStockFisicoProgramado();
            this.FormatoVentanaHijoPrincipal(win, this.iteStockFisicoProgramado, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarCompraPorProveedor()
        {
            wImpCompraPorProveedor win = new wImpCompraPorProveedor();
            this.FormatoVentanaHijoPrincipal(win, this.iteCompraProveedor, null, 94, 94);
            win.NuevaVentana();
        }


        public void InstanciarCompraPorExistencia()
        {
            wImpCompraPorExistencia win = new wImpCompraPorExistencia();
            this.FormatoVentanaHijoPrincipal(win, this.iteCompraExistencia, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarPagosPorOrdenCompra()
        {
            wPagos win = new wPagos();
            this.FormatoVentanaHijoPrincipal(win, this.itePagosPorOrdenCompra, null, 94, 94);
            win.NuevaVentana();
        }

        public void InstanciarBancos()
        {
            wBancos win = new wBancos();
            this.FormatoVentanaHijoPrincipal(win, this.IteBancos, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarCuentasBancos()
        {
            wCuentaBanco win = new wCuentaBanco();
            this.FormatoVentanaHijoPrincipal(win, this.IteCuentaBancos, null, 0, 0);
            win.NuevaVentana();
        }

        public void InstanciarRecalculoPresupuesto()
        {
            wRecalculoPresupuesto win = new wRecalculoPresupuesto();
            this.FormatoVentanaHijoPrincipal(win, this.iteRecalculoPresupuesto, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarOrdenServicio()
        {
            wOrdenServicio win = new wOrdenServicio();
            this.FormatoVentanaHijoPrincipal(win, this.iteOrdenServicio, null, 0, 0);
            win.NuevaVentana();
        }
        public void InstanciarImpresionOrdenServicio()
        {
            wImpOrdSerCeCo win = new wImpOrdSerCeCo();
            this.FormatoVentanaHijoPrincipal(win, this.IteRepOrdSerCeCo, null, 0, 0);
            win.NuevaVentana();
        }
        #endregion

        private void wMenu_Load(object sender, EventArgs e)
        {
            this.NuevaVentanaAcceso();
        }

        private void wMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                bool iRpta = Mensaje.DeseasRealizarOperacion("Salir del sistema");
                if (iRpta == false)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void IteSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ItecambioDeClave_Click(object sender, EventArgs e)
        {
            this.InstanciarCambioDeClave();
        }

        private void IteBloquearSistema_Click(object sender, EventArgs e)
        {
            this.BloquearSistema();
        }

        private void IteCambiarAcceso_Click(object sender, EventArgs e)
        {
            this.CambiarAcceso();
        }

        private void tsbBloSis_Click(object sender, EventArgs e)
        {
            this.BloquearSistema();
        }

        private void tsbCamAcc_Click(object sender, EventArgs e)
        {
            this.CambiarAcceso();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IteEmpresas_Click(object sender, EventArgs e)
        {
            this.InstanciarEmpresas();
        }

        private void IteUsuarios_Click(object sender, EventArgs e)
        {
            this.InstanciarUsuarios();
        }

        private void ItePerfiles_Click(object sender, EventArgs e)
        {
            this.InstanciarPerfil();
        }

        private void IteTablasGenerales_Click(object sender, EventArgs e)
        {
            this.InstanciarTablasGenerales();
        }

        private void IteBotones_Click(object sender, EventArgs e)
        {
            this.InstanciarBotones();
        }

        private void IteVentanas_Click(object sender, EventArgs e)
        {
            this.InstanciarVentanas();
        }

        private void IteTiposOperacion_Click(object sender, EventArgs e)
        {
            this.InstanciarTiposOperaciones();
        }

        private void ItePersonal_Click(object sender, EventArgs e)
        {
            //this.InstanciarPersonales();
        }

        private void IteAuxiliares_Click(object sender, EventArgs e)
        {
            this.InstanciarAuxiliares();
        }

        private void tsbAuxiliares_Click(object sender, EventArgs e)
        {
            this.InstanciarAuxiliares();
        }

        private void IteAlmacenes_Click(object sender, EventArgs e)
        {
            this.InstanciarAlmacenes();
        }

        private void IteExistencias_Click(object sender, EventArgs e)
        {
            this.InstanciarExistencias();
        }

        private void IteIngresos_Click(object sender, EventArgs e)
        {
            this.InstanciarIngresos();
        }

        private void IteSalidas_Click(object sender, EventArgs e)
        {
            this.InstanciarSalidas();
        }

        private void IteRecalculo_Click(object sender, EventArgs e)
        {

        }

        private void IteFormulas_Click(object sender, EventArgs e)
        {
            this.InstanciarFormulas();
        }

        private void ItePeriodos_Click(object sender, EventArgs e)
        {
            this.InstanciarPeriodos();
        }

        private void IteTransferencias_Click(object sender, EventArgs e)
        {
            this.InstanciarTransferencias();
        }

        private void IteParametros_Click(object sender, EventArgs e)
        {
            this.InstanciarParametrosGenerales();
        }

        private void IteCopiaSeguridadBD_Click(object sender, EventArgs e)
        {
            this.InstanciarCopiaSeguridadBD();
        }

        private void IteSolicitudesProduccion_Click(object sender, EventArgs e)
        {
            this.InstanciarProducciones();
        }

        private void ItePartesTrabajo_Click(object sender, EventArgs e)
        {
            this.InstanciarPartesTrabajo();
        }

        private void IteKardexValorizado_Click(object sender, EventArgs e)
        {
            this.InstanciarKardexValorizado();
        }

        private void IteKardexFisico_Click(object sender, EventArgs e)
        {
            this.InstanciarKardexFisico();
        }

        private void tsbIngresos_Click(object sender, EventArgs e)
        {
            this.InstanciarIngresos();
        }

        private void tsbSalidas_Click(object sender, EventArgs e)
        {
            this.InstanciarSalidas();
        }

        private void tsbTransferencias_Click(object sender, EventArgs e)
        {
            this.InstanciarTransferencias();
        }

        private void tsbSolicitudesProduccion_Click(object sender, EventArgs e)
        {
            this.InstanciarProducciones();
        }

        private void tsbPartesTrabajo_Click(object sender, EventArgs e)
        {
            this.InstanciarPartesTrabajo();
        }

        private void tsbRecalculo_Click(object sender, EventArgs e)
        {
            this.InstanciarRecalculo();
        }

        private void IteTablasEmpresa_Click(object sender, EventArgs e)
        {
            this.InstanciarTablasEmpresas();
        }

        private void tsbLicitacion_Click(object sender, EventArgs e)
        {
            this.InstanciarLicitaciones();
        }

        private void IteLicitaciones_Click(object sender, EventArgs e)
        {
            this.InstanciarLicitaciones();
        }

        private void IteImpContabilidad_Click(object sender, EventArgs e)
        {
            this.InstanciarImportacionContabilidad();
        }

        private void IteExiGenDetalle_Click(object sender, EventArgs e)
        {
            this.InstanciarExistenciasGeneralesDetalle();
        }

        private void IteMigracionExistencias_Click(object sender, EventArgs e)
        {
            this.InstanciarMigrarExistencias();
        }

        private void IteSaldosPorExistencia_Click(object sender, EventArgs e)
        {
            this.InstanciarSaldosPorExistencia();
        }

        private void IteMovimientos_Click(object sender, EventArgs e)
        {
            this.InstanciarMovimientos();
        }

        private void IteExiGenResumen_Click(object sender, EventArgs e)
        {
            this.InstanciarExistenciasGeneralesResumen();
        }

        private void IteResumenTipoExistencia_Click(object sender, EventArgs e)
        {
            this.InstanciarResumenTipoExistencia();
        }

        private void IteInventarios_Click(object sender, EventArgs e)
        {
            this.InstanciarInventarios();
        }

        private void IteDocEmiResumen_Click(object sender, EventArgs e)
        {
            this.InstanciarDocumentosEmitidosResumen();
        }

        private void IteDocEmiDetalle_Click(object sender, EventArgs e)
        {
            this.InstanciarDocumentosEmitidosDetalle();
        }

        private void IteRepSalRecord_Click(object sender, EventArgs e)
        {
            this.InstanciarRecords();
        }

        private void IteRepSalCeCoDeta_Click(object sender, EventArgs e)
        {
            this.InstanciarSalidasCentroCostoDetalle();
        }

        private void IteConMovISDetalle_Click(object sender, EventArgs e)
        {
            this.InstanciarControlMovimientoISDetalle();
        }

        private void IteAlertaStockMinimo_Click(object sender, EventArgs e)
        {
            this.InstanciarAlertaStockMinimo();
        }

        private void IteCierreAnual_Click(object sender, EventArgs e)
        {
            this.InstanciarCierreAnual();
        }

        private void tbcContenedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IteMigrarProduccion_Click(object sender, EventArgs e)
        {
            this.InstanciarMigracionProduccion();
        }

        private void IteProdRangoFecha_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteProduccionFormatoEnvasado();
        }

        private void IteFactorCostos_Click(object sender, EventArgs e)
        {

        }

        private void IteRecalculoSaldos_Click(object sender, EventArgs e)
        {
            this.InstanciarRecalculo();
        }

        private void ItePlanEncajado_Click(object sender, EventArgs e)
        {
            this.InstanciarPlanEncajado();
        }

        private void tsbPlanEncajado_Click(object sender, EventArgs e)
        {
            this.InstanciarPlanEncajado();
        }

        private void IteExistenciasGenerales_Click(object sender, EventArgs e)
        {

        }

        private void IteValidarExistencia_Click(object sender, EventArgs e)
        {
            this.InstanciarValidarExistencias();
        }

        private void IteRecalculoProduccion_Click(object sender, EventArgs e)
        {
            this.InstanciarRecalculoProduccion();
        }

        private void IteDoctor_Click(object sender, EventArgs e)
        {
            this.InstanciarDoctor();
        }

        private void IteRetiquetado_Click(object sender, EventArgs e)
        {
            this.InstanciarRetiquetados();
        }

        private void tsbRetiquetado_Click(object sender, EventArgs e)
        {
            this.InstanciarRetiquetados();
        }

        private void IteFactorCIF_Click(object sender, EventArgs e)
        {

        }

        private void IteLiberacionesSinMovimientos_Click(object sender, EventArgs e)
        {
            this.InstanciarLiberacionesSinMovimientos();
        }

        private void IteCosUniPorProducto_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosUnitariosPorProducto();
        }

        private void IteCosUniPromediosAcumulados_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosUnitariosPromedioAcumulado();
        }

        private void IteCosUniVarCostos_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosUnitariosVariabilidadCosto();
        }

        private void IteCosPreVsReaXPro_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosPresupuestadoVsRealPorProducto();
        }

        private void IteCosPreVsReaXFec_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosPresupuestadoVsRealPorFechas();
        }

        private void IteCosAcuPorProcesos_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosAcumuladosPorProcesos();
        }

        private void IteCosLotEtaEnv_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosLoteEtapaEnvasado();
        }

        private void IteCosLotClaEnc_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosLoteClasificacionEncajado();
        }

        private void IteCosLotEtaEnc_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosLoteEtapaEncajado();
        }

        private void IteCosLotEtaRet_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosLoteEtapaRetiquetado();
        }

        private void IteCosLotTotPro_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCostosLoteTotalProduccion();
        }

        private void ItePorCumProd_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteCumplimientoProduccion();
        }

        private void IteConsultaProductoTerminado_Click(object sender, EventArgs e)
        {
            this.InstanciarConsultaProductoTerminado();
        }

        private void IteProduccionConSaldo_Click(object sender, EventArgs e)
        {
            this.InstanciarConsultaProduccionesConSaldo();
        }

        private void IteControlCalidad_Click(object sender, EventArgs e)
        {
            this.InstanciarConsultaProduccionesSinLiberar();
        }

        private void IteKpiDesmedro_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteKpiDesmedro();
        }

        private void IteKpiVersus_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteKpiVersus();
        }

        private void IteDesPT_Click(object sender, EventArgs e)
        {
            this.InstanciarReporteDesmedroPT();
        }

        private void ItePersonalAlmacen_Click(object sender, EventArgs e)
        {
            this.InstanciarPersonales();
        }

        private void ItePersonalutorizan_Click(object sender, EventArgs e)
        {
            this.InstanciarPersonalAutorizan();
        }

        private void ItePersonalReciben_Click(object sender, EventArgs e)
        {
            this.InstanciarPersonalReciben();
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iteSolicitudPedido_Click(object sender, EventArgs e)
        {
            this.InstanciarSolicitudPedido();
        }

        private void itePresupuestos_Click(object sender, EventArgs e)
        {
            this.InstanciarPresupuesto();
        }

        private void IteEnviarRecibo_Click(object sender, EventArgs e)
        {
            this.InstanciarEnviarRecibo();
        }

        private void iteOrdenCompra_Click(object sender, EventArgs e)
        {
            this.InstanciarOrdenCompra();
        }

        private void iteTipoCambio_Click(object sender, EventArgs e)
        {
            this.InstanciarTipoCambio();
        }

        private void IteSolicitudPedidos_Click(object sender, EventArgs e)
        {
            this.InstanciarSolicitudPedidos();
        }

        private void IteConsultaOrdenCompra_Click(object sender, EventArgs e)
        {
            this.InstanciarConsultaOrdenCompra();
        }

        private void IteIngresoOrdenCompra_Click(object sender, EventArgs e)
        {
            this.InstanciarIngresosOrdenCompra();
        }

        private void IteRepIngOCCeCoDeta_Click(object sender, EventArgs e)
        {

        }

        private void IteRepIngOCCeCo_Click(object sender, EventArgs e)
        {
            this.InstanciarIngOCCentroCosto();
        }

        private void iteStockFisicoProgramado_Click(object sender, EventArgs e)
        {
            this.InstanciarStockFisicoProgramado();
        }

        private void iteCompraProveedor_Click(object sender, EventArgs e)
        {
            this.InstanciarCompraPorProveedor();
        }

        private void iteCompraExistencia_Click(object sender, EventArgs e)
        {
            this.InstanciarCompraPorExistencia();
        }

        private void itePagosPorOrdenCompra_Click(object sender, EventArgs e)
        {
            this.InstanciarPagosPorOrdenCompra();
        }

        private void IteBancos_Click(object sender, EventArgs e)
        {
            this.InstanciarBancos();
        }

        private void IteCuentaBancos_Click(object sender, EventArgs e)
        {
            this.InstanciarCuentasBancos();
        }

        private void iteRecalculoPresupuesto_Click(object sender, EventArgs e)
        {
            this.InstanciarRecalculoPresupuesto();
        }

        private void iteOrdenServicio_Click(object sender, EventArgs e)
        {
            this.InstanciarOrdenServicio();
        }

        private void IteRepOrdSerCeCo_Click(object sender, EventArgs e)
        {
            this.InstanciarImpresionOrdenServicio();
        }

        private void iteRequerimiento_Click(object sender, EventArgs e)
        {
            this.InstanciarRequerimiento();
        }

        private void iteExportarOrdComAConta_Click(object sender, EventArgs e)
        {
            this.InstanciarExportarOrdenCompra();
        }
    }
}
