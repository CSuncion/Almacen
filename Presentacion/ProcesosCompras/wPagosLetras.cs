using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Adicionales;
using WinControles;
using Entidades;
using Negocio;
using WinControles.ControlesWindows;
using Comun;

namespace Presentacion.ProcesosCompras
{
    public partial class wPagosLetras : Heredados.MiForm4
    {
        public wPagosLetras()
        {
            InitializeComponent();
        }

        //variables        
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public int eTipoVentana = 0;
        //0:cobranza
        //1:consulta
        public AuxiliarEN eAuxEN;


        #region Propietario

        public wPagos wPag;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodAux, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomAux, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCorreo, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomDir, this.btnAceptar, "ffff");
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

            // Deshabilitar al propietario de esta ventana
            this.wPag.Enabled = false;

            // Mostrar ventana          
            this.Show();
        }

        public void ValoresXDefecto()
        {
            this.txtCodAux.Text = this.eAuxEN.CodigoAuxiliar;
            this.txtNomAux.Text = this.eAuxEN.DescripcionAuxiliar;
            this.txtCorreo.Text = this.eAuxEN.CorreoAuxiliar;
            this.txtNomDir.Text = this.eAuxEN.DireccionAuxiliar;
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.ValoresXDefecto();
            this.ActualizarVentana();
            this.btnAceptar.Focus();
        }

        public void ActualizarVentana()
        {
            this.ActualizarDatosDgvOC();
            this.TituloOrdenCompra();
        }

        public void TituloOrdenCompra()
        {
            int iNumeroLetras = Dgv.ObtenerNumeroRegistros(this.DgvOrdCom);
            this.lblLetras.Text = string.Empty;
            this.lblLetras.Text += "Orden compra pendientes : ";
            this.lblLetras.Text += " / Nro : " + iNumeroLetras.ToString();
            this.lblLetras.Text += " / Monto : " + Dgv.SumarColumna(this.DgvOrdCom, MovimientoOCCabeEN.MonPen).ToString();
        }

        public void ActualizarDatosDgvOC()
        {
            MovimientoOCCabeEN iMovDetEN = new MovimientoOCCabeEN();
            iMovDetEN.CodigoAuxiliar = this.eAuxEN.CodigoAuxiliar;
            iMovDetEN.EstadoPago = "0";
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCCabeEN.ClaMovCab;

            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvOrdCom;
            iDgv.RefrescarFormatoGrilla();
            iDgv.AsignarColumnaCheckBox("Seleccionar", "Seleccionar", 75);
            iDgv.AsignarColumnaTextCadenaSinFuente(MovimientoOCCabeEN.ClaMovCab, "Clave", 180);
            iDgv.AsignarColumnaTextNumericoSinFuente(MovimientoOCCabeEN.MonPen, "Monto", 90, 2);
            iDgv.AsignarColumnaTextCadenaSinFuente(MovimientoOCCabeEN.NEstPag, "Estado", 70);

            //llenando manualmente la grilla
            int n = -1;
            foreach (MovimientoOCCabeEN xMov in MovimientoOCCabeRN.BuscarMovimientoCabeXAuxiliar(iMovDetEN))
            {
                n++;
                this.DgvOrdCom.Rows.Add();
                this.DgvOrdCom[MovimientoOCCabeEN.ClaMovCab, n].Value = xMov.ClaveMovimientoCabe;
                this.DgvOrdCom[MovimientoOCCabeEN.MonPen, n].Value = xMov.MontoPendiente;
                this.DgvOrdCom[MovimientoOCCabeEN.NEstPag, n].Value = xMov.NEstadoPago;
            }
        }

        public void Aceptar()
        {
            //verificar los check
            if (this.EsValidoMarcados() == false) { return; }

            //preguntar si va a consultar o cobrar
            if (this.eTipoVentana == 1)//consulta
            {
                // this.ConsultarMontoLetras( );  
            }
            else
            {
                //instanciar ventana cobranza unica o cobranza varios
                //segun el numero de celdas chequeadas
                List<int> iLisIndMar = Dgv.ListarIndicesMarcadosEnCheckBox(this.DgvOrdCom, "Seleccionar");
                if (iLisIndMar.Count == 1)
                {
                    //solo se chequeo una letra
                    this.AdicionarPago(iLisIndMar[0]);
                }
                else
                {
                    //aqui se chequearon mas de una letra
                    //this.AdicionarCobranzas( );
                }
            }
        }

        public List<CuotaEN> ListarCuotasMarcadas()
        {
            List<CuotaEN> iLisRes = new List<CuotaEN>();
            for (int n = 0; n <= this.DgvOrdCom.Rows.Count - 1; n++)
            {
                bool iValor = Convert.ToBoolean(this.DgvOrdCom["Seleccionar", n].Value);
                if (iValor == true)
                {
                    CuotaEN iCuoEN = new CuotaEN();
                    iCuoEN.ClaveCuota = this.DgvOrdCom.Rows[n].Cells[CuotaEN.ClaObj].Value.ToString();
                    iCuoEN = CuotaRN.BuscarCuotaXClave(iCuoEN);
                    iLisRes.Add(iCuoEN);
                }
            }
            return iLisRes;
        }

        public void AdicionarPago(int pIndiceMarcado)
        {
            //traer la cuota seleccionada de la b.d
            MovimientoOCCabeEN iMovOCEN = new MovimientoOCCabeEN();
            iMovOCEN.ClaveMovimientoCabe = this.DgvOrdCom[MovimientoOCCabeEN.ClaMovCab, pIndiceMarcado].Value.ToString();
            iMovOCEN = MovimientoOCCabeRN.BuscarMovimientoCabeXClave(iMovOCEN);

            //instanciar ventana
            wEditPagosUnica win = new wEditPagosUnica();
            win.wPagLet = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iMovOCEN);
        }

        public bool EsValidoMarcados()
        {
            //llenamos una lista con los indices de los registros
            //que estan marcados con check
            List<int> iLisIndMar = Dgv.ListarIndicesMarcadosEnCheckBox(this.DgvOrdCom, "Seleccionar");

            //si la lista esta vacia es por que no marco ningun registro
            //por lo tanto es falso
            if (iLisIndMar.Count == 0)
            {
                Mensaje.OperacionDenegada("Debes marcar un comprobante", "Orden Compra");
                return false;
            }

            //si la lista contiene un indice entonces es verdadero
            if (iLisIndMar.Count > 1)
            {
                Mensaje.OperacionDenegada("Solo se puede marcar un comprobante", "Orden Compra");
                return false;
            }

            //si paso todas estas restricciones entonces es verdadero
            return true;
        }

        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wPagosLetras_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPag.Enabled = true;
            this.wPag.dgvCon.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

    }
}
