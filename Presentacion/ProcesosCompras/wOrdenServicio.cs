using Comun;
using Entidades;
using Entidades.Adicionales;
using Heredados.VentanasPersonalizadas;
using Negocio;
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
using WinControles;
using WinControles.ControlesWindows;

namespace Presentacion.ProcesosCompras
{
    public partial class wOrdenServicio : Heredados.MiForm8
    {
        string eNombreColumnaDgvMovCab = MovimientoOCCabeEN.NumMovCab;
        string eEncabezadoColumnaDgvMovCab = "Numero";
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<MovimientoOCCabeEN> eLisMovCab = new List<MovimientoOCCabeEN>();
        public List<MovimientoOCDetaEN> eLisMovDet = new List<MovimientoOCDetaEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Orden de Servicio";
        string iNuevoNumero = string.Empty;
        string iCorrelativo = "0000";

        public wOrdenServicio()
        {
            InitializeComponent();
        }

        public void NuevaVentana()
        {
            this.Show();
            this.MostrarPersistencia();
        }

        public void MostrarPersistencia()
        {
            TsL.MostrarValor(lblPeriodo, Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa);
        }

        public void AccionAdicionar()
        {
            //validar
            MovimientoOCCabeEN iIngEN = this.EsActoAdicionarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            ////instanciar
            wEditOrdenServicio win = new wEditOrdenServicio();
            win.wOrdSer = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        public MovimientoOCCabeEN EsActoAdicionarMovimientoCabe()
        {
            MovimientoOCCabeEN iIngEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoOCCabeRN.EsActoAdicionarMovimientoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }

            return iIngEN;
        }

        public void AsignarMovimientoCabe(MovimientoOCCabeEN pIng)
        {
            pIng.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoOCCabeEN.ClaObj);
            pIng.PeriodoMovimientoCabe = lblPeriodo.Text;
            pIng.COrigenVentanaCreacion = "1";//ingreso      
        }

        public void ActualizarListaMovimientoCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            iCuoEN.PeriodoMovimientoCabe = lblPeriodo.Text;
            iCuoEN.CClaseTipoOperacion = "4";//orden de servicio
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvMovCab;
            this.eLisMovCab = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodoYClaseOperacion(iCuoEN);
        }

        public void AccionCambiaPeriodo()
        {
            //poner la descripcion del mes
            lblDescripcionPeriodo.Text = AñoMes.ObtenerDescripcionPeriodo(lblPeriodo.Text);

            //MessageBox.Show(lblDescripcionPeriodo.Text);

            //guardar el nuevo periodo
            Properties.Settings.Default.GuardarPeriodoIngresos = TsL.ModificarValor(Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa, lblPeriodo);
            Properties.Settings.Default.Save();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionSeleccionarPeriodo()
        {
            vSeleccionarPeriodo win = new vSeleccionarPeriodo();
            win.eVentanaInvoca = this;
            win.eControlDevuelveValor = lblPeriodo;
            win.ePeriodoActual = lblPeriodo.Text;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaMovimientoCabesDeBaseDatos();
            this.ActualizarDgvMovCab();
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvMovCab, this.sst1);
            this.AccionBuscar();
        }

        public void ActualizarDgvMovCab()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvMovCab;
            List<MovimientoOCCabeEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvMovCab;
            string iClaveBusqueda = eClaveDgvMovCab;
            string iColumnaPintura = eNombreColumnaDgvMovCab;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMovCab();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("013", DgvMovCab.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvMovCab;
            this.tstBuscar.Focus();
        }

        public List<MovimientoOCCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvMovCab;
            List<MovimientoOCCabeEN> iListaMovimientoCabes = eLisMovCab;

            //ejecutar y retornar
            return MovimientoOCCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaMovimientoCabes);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMovCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NumMovCab, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.FecMovCab, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.PerMovCab, "Periodo", 62));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.CodTipOpe, "T.O", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesTipOpe, "Descripción T.O", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesAlm, "Tipo Servicio", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesAux, "Proveedor", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xPlazoEntrega, "P. Entrega", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NomPer, "Personal", 160));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.GloMovCab, "Glosa", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NOriVenCre, "Origen", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NEstMovCab, "Estado", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NCodMon, "Moneda", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xCondiciones, "Condiciones", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xGarantia, "Garantia", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xValidezCotizacion, "V. Cot.", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xNFormaPago, "Forma Pago", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }
    }
}
