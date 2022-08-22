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
using Presentacion.Impresiones;


namespace Presentacion.ProcesosCompras
{
    public partial class wEliminarPagos : Heredados.MiForm4
    {
        public wEliminarPagos()
        {
            InitializeComponent();
        }


        //Variables     
        string eNombreColumna;
        string eEncabezadoColumna;
        public string eClaveDgvLet = string.Empty;
        int eIndiceFilaAnterior;
        Dgv.Franja eFranja;

        #region Propietario

        public wPagos wPag;

        #endregion

        #region General


        public void NuevaVentana()
        {
            this.wPag.Enabled = false;
            this.Show();
            this.eNombreColumna = MovimientoOCCabeEN.ClaMovCab;
            this.eEncabezadoColumna = "Comprobante";
            this.eFranja = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        public void ActualizarVentana()
        {
            //actualizar DgvLet
            this.ActualizarDgvMov();

            //habilitar desplazadores segun DgvLet
            Dgv.HabilitarDesplazadores(this.dgvMovOrdCom, this.btnPrimero, this.btnAnterior, this.btnSiguiente, this.btnUltimo);

            //titulo movimiento
            this.TituloMovimiento();

            //actualizar Pago
            this.ActualizarDatosDgvCob();

            //titulo Pagos
            this.TituloPagos();

            //habilitar el boton eliminar
            this.HabilitarBotonEliminar();
        }

        public void ActualizarDgvMov()
        {
            //obtener el indice fila del DgvPro antes de actualizar los datos
            eIndiceFilaAnterior = Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovOrdCom);

            //actualizar los datos del DgvCon
            this.ActualizarDatosDgvMov();

            //pintar la columna activa del DgvPro
            Dgv.PintarColumna(this.dgvMovOrdCom, eNombreColumna);

            //poner franja segun operacion
            Dgv.PosicionarFranja(this.dgvMovOrdCom, eFranja, eIndiceFilaAnterior, eClaveDgvLet);
        }

        public void ActualizarDatosDgvMov()
        {
            MovimientoOCCabeEN iMovCabe = new MovimientoOCCabeEN();
            iMovCabe.CodigoAuxiliar = Dgv.ObtenerValorCelda(this.wPag.dgvCon, MovimientoOCCabeEN.CodAux);
            iMovCabe.EstadoPago = "0,1";
            iMovCabe.Adicionales.CampoOrden = MovimientoOCCabeEN.FecDoc;

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.dgvMovOrdCom;
            iDgv.RefrescarDatosGrilla(MovimientoOCCabeRN.BuscarMovimientoCabeXAuxiliar(iMovCabe));

            //asignar columnas
            iDgv.AsignarColumnaTextCadena(MovimientoOCCabeEN.ClaMovCab, "Movimiento", 100);
            iDgv.AsignarColumnaTextNumerico(MovimientoOCCabeEN.MonPen, "Monto", 90, 2);
            iDgv.AsignarColumnaTextCadena(MovimientoOCCabeEN.NEstPag, "Estado", 70);
        }

        public void TituloMovimiento()
        {
            int iNumeroLetras = Dgv.ObtenerNumeroRegistros(this.dgvMovOrdCom);
            this.lblLetras.Text = string.Empty;
            this.lblLetras.Text += "Movimientos canceladas del contrato : " + Dgv.ObtenerValorCelda(this.wPag.dgvCon, MovimientoOCCabeEN.CodAux);
            this.lblLetras.Text += " / Nro : " + iNumeroLetras.ToString();
        }

        public void ActualizarDatosDgvCob()
        {
            PagoEN iPagEN = new PagoEN();
            iPagEN.ClaveComprobante = Dgv.ObtenerValorCelda(this.dgvMovOrdCom, MovimientoOCCabeEN.ClaMovCab);
            iPagEN.Adicionales.CampoOrden = PagoEN.CorPag;

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.dgvPag;
            iDgv.RefrescarDatosGrilla(PagoRN.ListarPagosXCuota(iPagEN));
            //asignar columnas         
            iDgv.AsignarColumnaTextCadena(PagoEN.CorPag, "Correlativo", 100);
            iDgv.AsignarColumnaTextCadena(PagoEN.FecVenCuo, "Vencimiento", 100);
            iDgv.AsignarColumnaTextCadena(PagoEN.FecDepPag, "Deposito", 90);
            iDgv.AsignarColumnaTextCadena(PagoEN.FecPag, "Fc.Pago", 90);
            iDgv.AsignarColumnaTextNumerico(PagoEN.ImpPag, "Mto Letra", 100, 2);
            iDgv.AsignarColumnaTextNumerico(PagoEN.ImpPag, "Importe", 90, 2);
            iDgv.AsignarColumnaTextNumerico(PagoEN.MonCobPag, "Pagado", 90, 2);
            iDgv.AsignarColumnaTextCadena(PagoEN.ObsPag, "Observacion", 250);
            iDgv.AsignarColumnaTextCadena(PagoEN.ClaObj, "ClaveObjeto", 2, false);

        }

        public void TituloPagos()
        {
            string iLetraActual = Dgv.ObtenerValorCelda(this.dgvMovOrdCom, MovimientoOCCabeEN.ClaMovCab);
            int iNumeroPagos = Dgv.ObtenerNumeroRegistros(this.dgvPag);
            this.lblPagos.Text = string.Empty;
            this.lblPagos.Text += "Pagos de la movimientos : " + iLetraActual;
            this.lblPagos.Text += " / Nro : " + iNumeroPagos.ToString();
        }

        public void HabilitarBotonEliminar()
        {
            //solo si hay Pago se habilita el boton eliminar
            if (this.dgvPag.Rows.Count == 0)
            {
                this.btnEliminar.Enabled = false;
            }
            else
            {
                this.btnEliminar.Enabled = true;
            }
        }

        public void Eliminar()
        {
            //es acto eliminar
            if (this.EsAptoEliminarPago() == false) { return; }

            //desas realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar Pago") == false) { return; }

            //modificamos la letra de esta Pago
            //this.ModificarCuota();

            //eliminamos esta Pago
            this.EliminarPago();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la Pago", "Pago");

            //actualizar grilla
            this.ActualizarVentana();
        }

        public bool EsAptoEliminarPago()
        {
            PagoEN iCobEN = new PagoEN();
            iCobEN.CorrelativoPago = Dgv.ObtenerValorCelda(this.dgvPag, PagoEN.ClaObj);
            iCobEN = PagoRN.EsActoEliminarPago(iCobEN);
            if (iCobEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCobEN.Adicionales.Mensaje, "Pago");
            }
            return iCobEN.Adicionales.EsVerdad;
        }

        public void ModificarCuota()
        {
            //traer la Pago actual       
            PagoEN iCobEN = new PagoEN();
            iCobEN.CorrelativoPago = Dgv.ObtenerValorCelda(this.dgvPag, PagoEN.ClaObj);
            iCobEN = PagoRN.BuscarPagoXCorrelativo(iCobEN);

            //buscar la cuota        
            CuotaEN iCuoEN = new CuotaEN();
            iCuoEN.ClaveCuota = Dgv.ObtenerValorCelda(this.dgvMovOrdCom, CuotaEN.ClaObj);
            iCuoEN = CuotaRN.BuscarCuotaXClave(iCuoEN);

            //actualizar datos
            iCuoEN.FechaPagoCuota = iCobEN.FechaPagoCuota;
            iCuoEN.FechaPagoCuota = iCobEN.FechaPagoCuota;
            iCuoEN.MontoPendienteCuota = iCobEN.CuotaPendienteAnterior;
            iCuoEN.MontoMora = iCobEN.MoraAnterior;
            iCuoEN.MontoMoraPendiente = iCobEN.MoraPendienteAnterior;
            iCuoEN.CGeneroMoraFija = iCobEN.CGeneroMoraFijaAnterior;
            iCuoEN.CEstadoCuota = "0";//pendiente

            //modificar cuota
            CuotaRN.ModificarCuota(iCuoEN);
        }

        public void EliminarPago()
        {
            MovimientoOCCabeEN iMovOCEN = new MovimientoOCCabeEN();
            iMovOCEN.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.dgvMovOrdCom, MovimientoOCCabeEN.ClaMovCab);
            iMovOCEN = MovimientoOCCabeRN.BuscarMovimientoCabeXClave(iMovOCEN);

            PagoEN iPagEN = new PagoEN();
            iPagEN.CorrelativoPago = Dgv.ObtenerValorCelda(this.dgvPag, PagoEN.ClaObj);
            iPagEN = PagoRN.BuscarPagoXCorrelativo(iPagEN);
            PagoRN.EliminarPagoXCorrelativo(iPagEN);

            MovimientoOCCabeRN.ActualizarMontoPendienteMovimientoOCCabe(iMovOCEN.PeriodoMovimientoCabe, iMovOCEN.ClaveMovimientoCabe, ((iMovOCEN.MontoPendiente + iPagEN.CuotaPagadaPago)));

            MovimientoOCCabeRN.CambiarEstadoPagoMovimientoOCCabe(iMovOCEN, "0");
        }

        #endregion



        private void wEliminarPagos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPag.Enabled = true;
            this.wPag.dgvCon.Focus();
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranja = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void dgvLet_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.dgvMovOrdCom, this.btnPrimero, this.btnAnterior, this.btnSiguiente, this.btnUltimo);
            this.ActualizarDatosDgvCob();
            this.TituloPagos();
            this.HabilitarBotonEliminar();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovOrdCom, Dgv.Desplazar.Primero);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovOrdCom, Dgv.Desplazar.Anterior);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovOrdCom, Dgv.Desplazar.Siguiente);

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovOrdCom, Dgv.Desplazar.Ultimo);
        }

        private void dgvCuo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.eNombreColumna = this.dgvMovOrdCom.Columns[e.ColumnIndex].Name;
            this.eEncabezadoColumna = this.dgvMovOrdCom.Columns[e.ColumnIndex].HeaderText;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Dgv.BusquedaInteligenteEnColumna(this.dgvMovOrdCom, this.eNombreColumna, this.tstBuscar, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.Eliminar();
        }












    }
}
