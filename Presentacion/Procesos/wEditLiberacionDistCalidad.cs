using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Comun;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Negocio;
using Entidades;
using Presentacion.FuncionesGenericas;
using Presentacion.Principal;

namespace Presentacion.Procesos
{
    public partial class wEditLiberacionDistCalidad : Heredados.MiForm8
    {
        public wEditLiberacionDistCalidad()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string eTitulo = "Cantidad";
        public LiberacionEN eLibMotEN = new LiberacionEN();
                
        #endregion

        #region Propietario

        //public wLiberacionDist wLibDis;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodLib, this.dtpFecLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtSalLib, this.dtpFecLib, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanLib, true, "Cantidad", "ffff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtNumUniPas, false, "Encajadas", "ffff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtNumUniSal, false, "Saldo", "ffff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtNumUniObs, false, "Observadas", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtUniParRep, false, "Reproceso", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMotRep, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtUniDon, false, "Donacion", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMotDon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtUniParMue, false, "Contra Muestra", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMotMue, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumUniDes, this.txtNumUniPas, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMotDes, "vvff");
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
            //this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wLibDis.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            
            //deshabilitar propietario
            //this.wLibDis.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void VentanaModificar(LiberacionEN pObj)
        {
            this.InicializaVentana();
            this.MostrarLiberacion(pObj);            
            eMas.AccionHabilitarControles(1);
            this.HabilitarMotivos();
            eMas.AccionPasarTextoPrincipal();
            this.txtNumUniObs.Focus();
        }
        
        public void VentanaVisualizar(LiberacionEN pObj)
        {
            this.InicializaVentana();
            this.MostrarLiberacion(pObj);           
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarLiberacion(LiberacionEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.FechaProduccionDeta = pObj.FechaProduccionDeta;
            pObj.CodigoLiberacion = this.txtCodLib.Text.Trim();
            pObj.FechaLiberacion = this.dtpFecLib.Text;
            pObj.PeriodoLiberacion = Fecha.ObtenerPeriodo(pObj.FechaLiberacion, "-");
            pObj.SaldoLiberacion = Conversion.ADecimal(this.txtSalLib.Text, 0);
            pObj.CantidadLiberacion = Conversion.ADecimal(this.txtCanLib.Text, 0);
            pObj.UnidadesPasan = Conversion.ADecimal(this.txtNumUniPas.Text, 0);
            pObj.UnidadesSaldo = Conversion.ADecimal(this.txtNumUniSal.Text, 0);
            pObj.UnidadesObservadas = Conversion.ADecimal(this.txtNumUniObs.Text, 0);
            pObj.UnidadesParaReproceso = Conversion.ADecimal(this.txtUniParRep.Text, 0);
            pObj.UnidadesParaDonacion = Conversion.ADecimal(this.txtUniDon.Text, 0);
            pObj.UnidadesParaMuestra = Conversion.ADecimal(this.txtUniParMue.Text, 0);
            pObj.UnidadesDesechas = Conversion.ADecimal(this.txtNumUniDes.Text, 0);         
            pObj.DetalleMotivoReproceso = this.eLibMotEN.DetalleMotivoReproceso;
            pObj.DetalleMotivoDonacion = this.eLibMotEN.DetalleMotivoDonacion;
            pObj.DetalleMotivoMuestra = this.eLibMotEN.DetalleMotivoMuestra;
            pObj.DetalleMotivoDesecho = this.eLibMotEN.DetalleMotivoDesecho;
            //pObj.ClaveProduccionDeta = Dgv.ObtenerValorCelda(this.wLibDis.DgvLib, LiberacionEN.ClaProDet);
            //pObj.ClaveLiberacion = Dgv.ObtenerValorCelda(this.wLibDis.DgvLib, LiberacionEN.ClaObj);
            //pObj.CAlmacenLiberacion = this.wLibDis.eAlmacenLiberacion;          
        }

        public void MostrarLiberacion(LiberacionEN pObj)
        {
            this.txtCodLib.Text = pObj.CodigoLiberacion;
            this.dtpFecLib.Text = pObj.FechaLiberacion;
            this.txtSalLib.Text = Formato.NumeroDecimal(pObj.SaldoLiberacion, 0);
            this.txtCanLib.Text = Formato.NumeroDecimal(pObj.CantidadLiberacion, 0);           
            this.txtNumUniPas.Text = Formato.NumeroDecimal(pObj.UnidadesPasan, 0);
            this.txtNumUniSal.Text = Formato.NumeroDecimal(pObj.UnidadesSaldo, 0);
            this.txtNumUniObs.Text = Formato.NumeroDecimal(pObj.UnidadesObservadas, 0);
            this.txtUniParRep.Text = Formato.NumeroDecimal(pObj.UnidadesParaReproceso, 0);
            this.txtUniDon.Text = Formato.NumeroDecimal(pObj.UnidadesParaDonacion, 0);
            this.txtUniParMue.Text = Formato.NumeroDecimal(pObj.UnidadesParaMuestra, 0);
            this.txtNumUniDes.Text = Formato.NumeroDecimal(pObj.UnidadesDesechas, 0);
            this.eLibMotEN.DetalleMotivoReproceso = pObj.DetalleMotivoReproceso;
            this.eLibMotEN.DetalleMotivoDonacion = pObj.DetalleMotivoDonacion;
            this.eLibMotEN.DetalleMotivoMuestra = pObj.DetalleMotivoMuestra;
            this.eLibMotEN.DetalleMotivoDesecho = pObj.DetalleMotivoDesecho;   
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {               
                case Universal.Opera.Modificar: { this.Modificar(); break; }                
                default: break;
            }
        }
        
        public void ModificarProduccionDetaAlAdicionar()
        {
            //asignar parametros            
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();            

            //ejecutar metodo
            ProduccionDetaRN.ModificarProduccionDetaAlAdicionarPorLiberacion(iLibEN);
        }
        
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //valida unidades desechas negativas
            if (this.ValidaCuandoUnidadesDesechasEstanEnNegativo(this.txtNumUniObs) == false) { return; }

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }
            
            //valida motivos
            if (this.EsValidarUnidadesConMotivos() == false) { return; }

            //valida la cantidad para packing
            if (EsValidoUnidadesObservadasAlModificar() == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wLibDis.eTitulo) == false) { return; }

            //modificar el registro ProduccionDeta
            this.ModificarProduccionDetaAlEliminar();

            //modificar el registro liberacion    
            this.ModificarLiberacion();

            //modificar el registro ProduccionDeta
            this.ModificarProduccionDetaAlAdicionar();

            //modificar produccionProTer
            this.ModificarProduccionProTer();

            //modificar los saldos a las liberaciones tipo observadas
            this.ModificarSaldoLiberacionDeLiberacionesTipoObservadas();

            ////mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se modifico la liberacion correctamente", this.wLibDis.eTitulo);

            ////actualizar al propietario wLiberacion         
            //this.wLibDis.eClaveDgvLib = this.ObtenerClaveLiberacion();
            //this.wLibDis.ActualizarVentana();

            ////actualizar al propietario wParteTrabajo
            //this.wLibDis.wParTra.eClaveDgvProDet = this.ObtenerClaveProduccionDeta();
            //this.wLibDis.wParTra.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarSaldoLiberacionDeLiberacionesTipoObservadas()
        {
            //asignar parametros
            string iClaveProduccionDeta = this.ObtenerClaveProduccionDeta();

            //ejecutar metodo
            LiberacionRN.ModificarSaldoLiberacionDeLiberacionObservadas(iClaveProduccionDeta);
        }

        public void ModificarLiberacion()
        {
            //traer al Liberacion de b.d
            //LiberacionEN iLibEN = this.wLibDis.EsLiberacionExistente();

            //modificar datos
            //this.AsignarLiberacion(iLibEN);

            //actualizamos los detalles,en caso se digito cero pero ya se habian registrado los motivos
            //LiberacionRN.ActualizarCamposDetallePorMontosCeros(iLibEN);

            //ejecutar metodo
            //LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public void ModificarProduccionDetaAlEliminar()
        {
            //asignar parametros            
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            ProduccionDetaRN.ModificarProduccionDetaAlEliminarPorLiberacion(iLibEN);
        }

        public LiberacionEN NuevoLiberacionDeVentana()
        {
            LiberacionEN iProDetEN = new LiberacionEN();
            this.AsignarLiberacion(iProDetEN);
            return iProDetEN;
        }

        public string ObtenerClaveLiberacion()
        {
            //asignar parametros
            LiberacionEN iLebEN = this.NuevoLiberacionDeVentana();

            //devolver
            return iLebEN.ClaveLiberacion;
        }

        public string ObtenerClaveProduccionDeta()
        {
            //asignar parametros
            LiberacionEN iLebEN = this.NuevoLiberacionDeVentana();

            //devolver
            return iLebEN.ClaveProduccionDeta;
        }

        public void MostrarNumeroUnidadesDesechas()
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            decimal iCantidad = LiberacionRN.ObtenerNumeroUnidadesDesecha(iProDetEN);

            //mostrar en pantalla
            this.txtNumUniDes.Text = Formato.NumeroDecimal(iCantidad, 0);
        }

        public bool ValidaCuandoUnidadesDesechasEstanEnNegativo(TextBox pTxt)
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            iProDetEN = LiberacionRN.ValidaCuandoUnidadesDesechasEstanEnNegativo(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, pTxt);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public bool EsFechaValida()
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            this.AsignarLiberacion(iLibEN);

            //ejecutar metodo
            iLibEN = LiberacionRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iLibEN);

            //mostrar mensaje error
            Generico.MostrarMensajeError(iLibEN.Adicionales, this.dtpFecLib);

            //devolver
            return iLibEN.Adicionales.EsVerdad;
        }

        public bool EsValidaCantidadLiberada()
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            iProDetEN = LiberacionRN.EsValidaCantidadLiberada(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, this.txtCanLib);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public bool EsValidaFechaLiberacion()
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            iProDetEN = LiberacionRN.EsValidaFechaLiberacion(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, this.dtpFecLib);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public void AccionMotivosReproceso()
        {
            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }
                       
            //instanciar
            wMotivoLiberacion win = new wMotivoLiberacion();
            win.wEdiLibCal = this;
            win.eVentana = 2;
            win.eTipoMotivo = "MotRep";
            win.eCantidadMotivo = Conversion.ADecimal(this.txtUniParRep.Text, 0);
            win.eDetalleMotivo = this.eLibMotEN.DetalleMotivoReproceso;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionMotivosDonacion()
        {
            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }

            //instanciar
            wMotivoLiberacion win = new wMotivoLiberacion();
            win.wEdiLibCal = this;
            win.eVentana = 2;
            win.eTipoMotivo = "MotDon";
            win.eCantidadMotivo = Conversion.ADecimal(this.txtUniDon.Text, 0);
            win.eDetalleMotivo = this.eLibMotEN.DetalleMotivoDonacion;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionMotivosMuestra()
        {
            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }

            //instanciar
            wMotivoLiberacion win = new wMotivoLiberacion();
            win.wEdiLibCal = this;
            win.eVentana = 2;
            win.eTipoMotivo = "MotMue";
            win.eCantidadMotivo = Conversion.ADecimal(this.txtUniParMue.Text, 0);
            win.eDetalleMotivo = this.eLibMotEN.DetalleMotivoMuestra;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionMotivosDesecho()
        {
            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }

            //instanciar
            wMotivoLiberacion win = new wMotivoLiberacion();
            win.wEdiLibCal = this;
            win.eVentana = 2;
            win.eTipoMotivo = "MotDes";
            win.eCantidadMotivo = Conversion.ADecimal(this.txtNumUniDes.Text, 0);
            win.eDetalleMotivo = this.eLibMotEN.DetalleMotivoDesecho;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void HabilitarMotivos()
        {
            //asignar parametros
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodos
            this.btnMotRep.Enabled = Cadena.CompararDosValores(iLibEN.UnidadesParaReproceso, 0, false, true);
            this.btnMotDon.Enabled = Cadena.CompararDosValores(iLibEN.UnidadesParaDonacion, 0, false, true);
            this.btnMotMue.Enabled = Cadena.CompararDosValores(iLibEN.UnidadesParaMuestra, 0, false, true);
            this.btnMotDes.Enabled = Cadena.CompararDosValores(iLibEN.UnidadesDesechas, 0, false, true);
        }

        public bool EsValidarUnidadesConMotivos()
        {
            //asignar parametros
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();

            //valida reproceso
            LiberacionEN iLibValEN = LiberacionRN.ValidaCuandoUnidadesReprocesoNoTieneIgualCantidadUnidadesMotivos(iLibEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Motivos");
                this.btnMotRep.Focus();
                return false;
            }

            //valida donacion
            iLibValEN = LiberacionRN.ValidaCuandoUnidadesDonacionNoTieneIgualCantidadUnidadesMotivos(iLibEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Motivos");
                this.btnMotDon.Focus();
                return false;
            }

            //valida muestra
            iLibValEN = LiberacionRN.ValidaCuandoUnidadesMuestraNoTieneIgualCantidadUnidadesMotivos(iLibEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Motivos");
                this.btnMotMue.Focus();
                return false;
            }

            //valida desechas
            iLibValEN = LiberacionRN.ValidaCuandoUnidadesDesechaNoTieneIgualCantidadUnidadesMotivos(iLibEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Motivos");
                this.btnMotDes.Focus();
                return false;
            }

            //ok
            return true;
        }

        public void ModificarProduccionProTer()
        {
            //asignar parametros
            //string iClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wLibDis.wCanRea.DgvProProTer, ProduccionProTerEN.ClaObj);

            //ejecutar metodo
            //ProduccionProTerRN.ModificarPorDistribucionLiberacion(iClaveProduccionProTer);
        }

        public bool EsValidoUnidadesObservadasAlModificar()
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            iProDetEN = LiberacionRN.EsValidoUnidadesObservadasAlModificar(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, this.txtNumUniPas);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            //Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wLibDis.eTitulo);
        }

        #endregion

        private void wEditLiberacionDistCalidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wLibDis.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtUniParRep_Validated(object sender, EventArgs e)
        {
            this.MostrarNumeroUnidadesDesechas();
            this.HabilitarMotivos();
            this.btnMotRep.Focus();
        }

        private void txtUniDon_Validated(object sender, EventArgs e)
        {
            this.MostrarNumeroUnidadesDesechas();
            this.HabilitarMotivos();
            this.btnMotDon.Focus();
        }
        
        private void txtUniParMue_Validated(object sender, EventArgs e)
        {
            this.MostrarNumeroUnidadesDesechas();
            this.HabilitarMotivos();
            this.btnMotMue.Focus();
        }

        private void btnMotRep_Click(object sender, EventArgs e)
        {
            this.AccionMotivosReproceso();
        }

        private void btnMotDon_Click(object sender, EventArgs e)
        {
            this.AccionMotivosDonacion();
        }

        private void btnMotMue_Click(object sender, EventArgs e)
        {
            this.AccionMotivosMuestra();
        }

        private void btnMotDes_Click(object sender, EventArgs e)
        {
            this.AccionMotivosDesecho();
        }

        private void txtNumUniObs_Validated(object sender, EventArgs e)
        {
            this.MostrarNumeroUnidadesDesechas();
            this.HabilitarMotivos();
        }
        
    }
}
