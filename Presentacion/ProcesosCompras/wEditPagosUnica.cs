using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Entidades;
using Negocio;
using Comun;
using WinControles.ControlesWindows;
using Presentacion.Listas;
using Presentacion.Impresiones;
using Entidades.Adicionales;
using Presentacion.FuncionesGenericas;

namespace Presentacion.ProcesosCompras
{
    public partial class wEditPagosUnica : Heredados.MiForm4
    {
        public wEditPagosUnica()
        {
            InitializeComponent();
        }

        //variables        
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Pago";


        #region Propietario

        public wPagosLetras wPagLet;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtFecUltPag, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtOrdComTot, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumDia, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtFecAper, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDep, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtPorcInt, false, "% Interes", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtPorcDscto, false, "% Dscto", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtProte, false, "Portes", "vfff", 2, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtComBco, false, "Comision Bco", "vfff", 2, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtOtros, false, "Ret.Letras", "vfff", 2, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbForPag, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtOrdComPen, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtMonaPag, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtMone, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCuoPag, false, "Cuota pagado", "vfff", 2, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtMonPag, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbModPag, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtDol, false, "Dolares", "vfff", 2, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtTipCam, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtSol, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtObs, false, "Observacion", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodBan, false, "Banco", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomBan, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtMonCue, this.dtpFecDep, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbModalidad, "vfff");
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
            this.wPagLet.Enabled = false;

            //cargar combos
            this.CargarFormaDePago();
            this.CargarModoDePago();
            this.CargarModalidadPago();

            // Mostrar ventana          
            this.Show();
        }

        public void ValoresXDefecto(MovimientoOCCabeEN pMovOC)
        {
            //pasamos valores del dia 
            this.txtFecAper.Text = DateTime.Now.ToShortDateString();
            this.txtTipCam.Text = "1.00";

            //objeto cuota     
            this.txtClaOrdCom.Text = pMovOC.ClaveMovimientoCabe;
            this.txtFecUltPag.Text = pMovOC.FechaDocumento;
            this.txtOrdComTot.Text = Formato.NumeroDecimal(pMovOC.MontoTotal, 2);
            this.txtMone.Text = pMovOC.CCodigoMoneda;
            this.txtCMone.Text = pMovOC.NCodigoMoneda;
            this.txtOrdComPen.Text = Formato.NumeroDecimal(pMovOC.MontoPendiente, 2);

            //Calculo numero dia de diferencia
            this.MostrarDiferenciaDeDias();

            //Monto a pagar
            this.MostrarMontoAPagar();

            //forma pago
            this.EfectoFormaPago();

            //modo pago
            this.EfectoModoPago();
        }

        public void CargarFormaDePago()
        {
            Cmb.Cargar(this.cmbForPag, ItemGRN.ListarItemsG("ForPag"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarModalidadPago()
        {
            Cmb.Cargar(this.cmbModalidad, ItemGRN.ListarItemsG("FoPaLe"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarModoDePago()
        {
            Cmb.Cargar(this.cmbModPag, ItemGRN.ListarItemsG("ModPag"), ItemGEN.CodIteG, ItemGEN.NomIteG);
            //modo por defecto
            this.cmbModPag.SelectedValue = "0";//soles
        }

        public void NuevaVentana(MovimientoOCCabeEN pMovOC)
        {
            this.InicializaVentana();
            this.ValoresXDefecto(pMovOC);
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecDep.Focus();
        }

        public void MostrarDiferenciaDeDias()
        {
            PagoEN iPagEN = new PagoEN();
            iPagEN.FechaDepositoPago = this.dtpFecDep.Text;
            iPagEN.FechaVencimientoCuota = this.txtFecUltPag.Text;
            iPagEN.FechaPagoCuota = this.txtFecUltPag.Text;
            this.txtNumDia.Text = PagoRN.ObtenerDiferenciaDeDias(iPagEN).ToString();
        }

        public void MostrarMontoAPagar()
        {
            //asignar parametros
            decimal iCuotaAPagar = Conversion.ADecimal(txtOrdComPen.Text, 0);
            decimal iMoraAPagar = 0;

            //ejecutar metodo
            decimal iMontoACobrar = PagoRN.CalculoMontoAPagar(iCuotaAPagar, iMoraAPagar);

            //mostrar en pantalla
            txtMonaPag.Text = Formato.NumeroDecimal(iMontoACobrar, 2);
        }

        public void EfectoFormaPago()
        {
            string iFormaPago = Cmb.ObtenerValor(this.cmbForPag, "0");
            if (iFormaPago == "0")//total
            {
                Txt.SoloEscritura(txtCuoPag, true);
                this.txtCuoPag.Text = this.txtOrdComPen.Text;
                this.txtMonPag.Text = this.txtMonaPag.Text;
            }
            else
            {
                //obtener el valor verdad o falso
                if (txtOrdComPen.Text == "0.00")
                {
                    Txt.SoloEscritura(txtCuoPag, true);
                }
                else
                {
                    Txt.SoloEscritura(txtCuoPag, false);
                }
                this.txtCuoPag.Text = "0.00";
                this.txtMonPag.Text = "0.00";
            }
        }

        public void EfectoModoPago()
        {
            PagoEN iCobEN = new PagoEN();
            iCobEN.CModoCobroPago = Cmb.ObtenerValor(this.cmbModPag, "0");
            iCobEN.TipoCambioPago = Conversion.ADecimal(this.txtTipCam.Text.Trim(), 0);
            iCobEN.MontoCobradoPago = Conversion.ADecimal(this.txtMonPag.Text.Trim(), 0);

            //habilitar controles segun modo Pago
            switch (iCobEN.CModoCobroPago)
            {
                case "0": { this.txtDol.ReadOnly = true; break; }//soles
                case "1": { this.txtDol.ReadOnly = true; break; }//dolares
                case "2": { this.txtDol.ReadOnly = false; break; }//ambos
            }

            //mostrar monto en soles y dolares
            string iMonedaLetra = this.txtCMone.Text;
            this.txtDol.Text = Formato.NumeroDecimal(PagoRN.CalculoMontoEnDolares(iCobEN, iMonedaLetra).ToString(), 2);
            iCobEN.MontoDolaresPago = Convert.ToDecimal(this.txtDol.Text);
            this.txtSol.Text = Formato.NumeroDecimal(PagoRN.CalculoMontoEnSoles(iCobEN, iMonedaLetra).ToString(), 2);
        }

        public void ValidandoMontoEnDolares()
        {
            if (this.txtDol.ReadOnly == false)
            {
                PagoEN iCobEN = new PagoEN();
                iCobEN.CModoCobroPago = Cmb.ObtenerValor(this.cmbModPag, "0");
                iCobEN.TipoCambioPago = Conversion.ADecimal(this.txtTipCam.Text.Trim(), 0);
                iCobEN.MontoCobradoPago = Conversion.ADecimal(this.txtMonPag.Text.Trim(), 0);

                //mostrar monto en soles 
                string iMonedaLetra = this.txtCMone.Text;
                iCobEN.MontoDolaresPago = Convert.ToDecimal(this.txtDol.Text);
                this.txtSol.Text = Formato.NumeroDecimal(PagoRN.CalculoMontoEnSoles(iCobEN, iMonedaLetra).ToString(), 2);

                //validar que no salga negativo
                iCobEN.MontoSolesPago = Convert.ToDecimal(this.txtSol.Text);
                iCobEN = PagoRN.EsMontoEnDolaresCorrecto(iCobEN);
                if (iCobEN.Adicionales.EsVerdad == false)
                {
                    MessageBox.Show(iCobEN.Adicionales.Mensaje, "Pago");
                    this.txtDol.Text = "0.00";
                    this.txtDol.Focus();
                }
            }

        }

        public bool EsValidoCuotaPagado()
        {
            //asignar parametros
            string iFormaPago = Cmb.ObtenerValor(this.cmbForPag, "0");
            decimal iMontoPagado = Conversion.ADecimal(this.txtMonPag.Text.Trim(), 0);
            decimal iMontoAPagar = Conversion.ADecimal(this.txtMonaPag.Text.Trim(), 0);

            //ejecutar metodo
            PagoEN iPagEN = PagoRN.EsMontoPagadoCorrecto(iFormaPago, iMontoAPagar, iMontoPagado);

            //mensaje error
            if (iPagEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPagEN.Adicionales.Mensaje, "Pago");
                this.txtCuoPag.Text = "0.00";
                this.txtCuoPag.Focus();
            }

            //devolver
            return iPagEN.Adicionales.EsVerdad;
        }

        public void AdicionarPago()
        {
            //traemos a la letra que se esta cobrando en pantalla
            //para sacar datos que debe tener la Pago         
            MovimientoOCCabeEN iMovOCEN = new MovimientoOCCabeEN();
            iMovOCEN.ClaveMovimientoCabe = this.txtClaOrdCom.Text.Trim();
            iMovOCEN = MovimientoOCCabeRN.BuscarMovimientoCabeXClave(iMovOCEN);

            //creamos la Pago
            PagoRN iPagRN = new PagoRN();
            PagoEN iPagEN = new PagoEN();
            iPagEN.CodigoEmpresa = iMovOCEN.CodigoAuxiliar;
            iPagEN.CodigoProyecto = string.Empty;
            iPagEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iPagEN.FechaPagoCuota = this.txtFecUltPag.Text.Trim();
            iPagEN.FechaPagoCuota = iMovOCEN.FechaDocumento;
            iPagEN.FechaPago = this.txtFecAper.Text;
            iPagEN.ClaveCuota = string.Empty;
            iPagEN.NumeroContrato = iMovOCEN.CodigoAuxiliar;
            iPagEN.FechaVencimientoCuota = iMovOCEN.FechaDocumento;
            iPagEN.ClaveComprobante = iMovOCEN.ClaveMovimientoCabe;
            iPagEN.EtapaLote = string.Empty;
            iPagEN.ManzanaLote = string.Empty;
            iPagEN.NumeroLote = string.Empty;
            iPagEN.MontoCuota = iMovOCEN.MontoTotal;
            iPagEN.FechaDepositoPago = this.dtpFecDep.Text;
            iPagEN.CuotaPendienteAnterior = Convert.ToDecimal(this.txtOrdComPen.Text);
            iPagEN.MoraAnterior = 0;
            iPagEN.MoraPendienteAnterior = 0;
            iPagEN.ImportePago = iPagEN.CuotaPendienteAnterior + iPagEN.MoraPendienteAnterior;
            iPagEN.MontoDescuentoPago = 0;
            iPagEN.MontoMoraPago = 0;
            iPagEN.MontoProtestoPago = Convert.ToDecimal(this.txtProte.Text);
            iPagEN.MontoOtrosPago = Convert.ToDecimal(this.txtOtros.Text);
            iPagEN.MontoaCobrarPago = Convert.ToDecimal(this.txtMonaPag.Text);
            iPagEN.CuotaPagadaPago = Convert.ToDecimal(this.txtCuoPag.Text);
            iPagEN.MoraPagadaPago = 0;
            iPagEN.MontoCobradoPago = Convert.ToDecimal(this.txtMonPag.Text);
            iPagEN.MontoComisionBcoPago = Convert.ToDecimal(this.txtComBco.Text);
            iPagEN.CFormaCobroPago = this.cmbForPag.SelectedValue.ToString();
            iPagEN.CModoCobroPago = this.cmbModPag.SelectedValue.ToString();
            iPagEN.MontoDolaresPago = Convert.ToDecimal(this.txtDol.Text);
            iPagEN.MontoSolesPago = Convert.ToDecimal(this.txtSol.Text);
            iPagEN.TipoCambioPago = Convert.ToDecimal(this.txtTipCam.Text);
            iPagEN.CLugarPago = "0";
            iPagEN.ObservacionPago = this.txtObs.Text.Trim();
            iPagEN.ClaveCuentaBanco = this.txtClaCtaBco.Text.Trim();
            iPagEN.CTipoPago = "0";
            iPagEN.CFormaPagoLetra = this.cmbModalidad.SelectedValue.ToString();
            iPagEN.CorrelativoPago = PagoRN.ObtenerCorrelativoPago(iPagEN);
            iPagEN.CGeneroMoraFijaAnterior = this.txtCGenMorFij.Text.Trim();
            iPagEN.CodigoAuxiliar = iMovOCEN.CodigoAuxiliar;

            //adicionar la Pago
            PagoRN.AdicionarPago(iPagEN);

            MovimientoOCCabeRN.ActualizarMontoPendienteMovimientoOCCabe(iMovOCEN.PeriodoMovimientoCabe, iMovOCEN.ClaveMovimientoCabe, (iMovOCEN.MontoPendiente - iPagEN.CuotaPagadaPago));

            //Evalua si debe cerrar el comprobante
            string iFormaPago = Cmb.ObtenerValor(this.cmbForPag, "0");
            if (iFormaPago == "0")
            {
                MovimientoOCCabeRN.CambiarEstadoPagoMovimientoOCCabe(iMovOCEN, "1");
            }
        }

        public void ModificarCuota()
        {
            //traemos a la cuota de la b.d
            CuotaEN iCuoEN = new CuotaEN();
            iCuoEN.ClaveCuota = this.txtClaOrdCom.Text.Trim();
            iCuoEN = CuotaRN.BuscarCuotaXClave(iCuoEN);

            //los nuevos datos
            iCuoEN.FechaPagoCuota = this.dtpFecDep.Text;
            iCuoEN.FechaPagoCuota = DateTime.Now.ToShortDateString();
            iCuoEN.MontoPendienteCuota = Convert.ToDecimal(this.txtOrdComPen.Text) - Convert.ToDecimal(this.txtCuoPag.Text);
            iCuoEN.MontoMoraPendiente = 0;
            iCuoEN.MontoMora = Convert.ToDecimal(this.txtMorCuoAnt.Text) + 0;
            iCuoEN.CEstadoCuota = CuotaRN.ObtenerCEstadoCuota(Cmb.ObtenerValor(cmbForPag, ""));
            iCuoEN.CGeneroMoraFija = this.ObtenerCGeneroMoraFija();

            //modificar en b.d
            CuotaRN.ModificarCuota(iCuoEN);
        }

        public string ObtenerCGeneroMoraFija()
        {
            //asignar parametros
            string iFechaVcto = txtFecUltPag.Text;
            string iFechaDeposito = dtpFecDep.Text;
            EmpresaEN iEmpEN = EmpresaRN.BuscarEmpresaDeAcceso();

            //ejecutar metodo
            return CuotaRN.ObtenerCGeneroMoraFija(iFechaVcto, iFechaDeposito, iEmpEN);
        }

        public bool EsValidoCuentaBanco()
        {
            if (this.txtCodBan.ReadOnly == false)
            {
                if (this.txtCodBan.Text.Trim() == string.Empty)
                {
                    Mensaje.OperacionDenegada("Debes elegir una cuenta de banco", "Cuenta");
                    this.txtCodBan.Focus();
                    return false;
                }
            }
            return true;
        }

        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //validando monto pagado
            if (this.EsValidoCuotaPagado() == false) { return; }

            //validar cuenta banco
            if (this.EsValidoCuentaBanco() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicinar la Pago
            this.AdicionarPago();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se realizo el Pago", "Pago");

            //actualizar wLet
            this.wPagLet.ActualizarVentana();

            //cerrar ventana
            this.Close();
        }

        public void ListarCuentaBanco()
        {
            //solo si el control no esta de solo lectura
            if (this.txtCodBan.ReadOnly == true) { return; }

            //instanciar
            wLisCueBan win = new wLisCueBan();
            win.eVentana = this;
            win.eTituloVentana = "Cuentas Bancarias";
            win.eCtrlValor = this.txtCodBan;
            win.eCtrlFoco = this.cmbModalidad;
            win.eCondicionLista = Listas.wLisCueBan.Condicion.CuentasActivas;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCuentaBancoValida()
        {
            ////validar el codigo proyecto
            CuentaBancoEN iCueBanEN = new CuentaBancoEN();
            iCueBanEN.NumeroCuentaBanco = this.txtCodBan.Text.Trim();
            iCueBanEN = CuentaBancoRN.EsCuentaBancoValidoXNumero(iCueBanEN);
            if (iCueBanEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCueBanEN.Adicionales.Mensaje, "Cuenta");
                this.txtCodBan.Focus();
            }

            ////mostrar datos
            this.txtCodBan.Text = iCueBanEN.NumeroCuentaBanco;
            this.txtClaCtaBco.Text = iCueBanEN.ClaveCuentaBanco;
            this.txtNomBan.Text = iCueBanEN.NombreBanco;
            this.txtMonCue.Text = iCueBanEN.NMonedaCuentaBanco;

            ////devolver
            return iCueBanEN.Adicionales.EsVerdad;
        }


        public CuotaEN ObtenerCuotaDeVentana()
        {
            //instanciar nueva cuota
            CuotaEN iCuoEN = new CuotaEN();

            //pasar los datos de la ventana
            iCuoEN.CGeneroMoraFija = txtCGenMorFij.Text;
            iCuoEN.FechaVencimientoCuota = txtFecUltPag.Text;
            iCuoEN.MontoMora = Conversion.ADecimal(txtMorCuoAnt.Text, 0);
            iCuoEN.FechaPagoCuota = txtFecUltPag.Text;

            //devolver
            return iCuoEN;
        }

        public void MostrarMontoPagado()
        {
            //asignar parametros
            decimal iCuotaPagada = Conversion.ADecimal(txtCuoPag.Text, 0);
            decimal iMoraPagada = 0;

            //ejecutar metodo
            decimal iMontoCobrado = PagoRN.ObtenerMontoPagado(iCuotaPagada, iMoraPagada);

            //mostrar en pantalla
            txtMonPag.Text = Formato.NumeroDecimal(iMontoCobrado, 2);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }



        #endregion


        private void wEditPagosUnica_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPagLet.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void dtpFecDep_Validating(object sender, CancelEventArgs e)
        {
            this.MostrarDiferenciaDeDias();
            this.MostrarMontoAPagar();
            this.EfectoFormaPago();
            this.EfectoModoPago();
        }

        private void txtDol_Validated(object sender, EventArgs e)
        {
            this.ValidandoMontoEnDolares();
        }

        private void cmbForPag_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.EfectoFormaPago();
            this.EfectoModoPago();
        }

        private void cmbForPag_DropDownClosed(object sender, EventArgs e)
        {
            this.EfectoFormaPago();
            this.EfectoModoPago();
        }

        private void cmbModPag_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.EfectoModoPago();
        }

        private void cmbModPag_DropDownClosed(object sender, EventArgs e)
        {
            this.EfectoModoPago();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCodBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCuentaBanco(); }
        }

        private void txtCodBan_Validating(object sender, CancelEventArgs e)
        {
            this.EsCuentaBancoValida();
        }

        private void txtCodBan_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCuentaBanco();
        }

        private void ckbAuto_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtDsctoMor_Validated(object sender, EventArgs e)
        {
            this.MostrarMontoAPagar();
            this.EfectoFormaPago();
            this.EfectoModoPago();
        }

        private void txtCuoPag_Validated(object sender, EventArgs e)
        {
            this.EsValidoCuotaPagado();
        }

        private void txtMorPag_Validated(object sender, EventArgs e)
        {
        }

        private void txtCuoPag_Validating(object sender, CancelEventArgs e)
        {
            this.MostrarMontoPagado();
            this.EfectoModoPago();
        }

        private void txtMorPag_Validating(object sender, CancelEventArgs e)
        {
            this.MostrarMontoPagado();
            this.EfectoModoPago();
        }



    }
}
