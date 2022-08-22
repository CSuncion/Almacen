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
    public partial class wPrimeraLiberacion : Heredados.MiForm8
    {
        public wPrimeraLiberacion()
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

        //public wParteTrabajo wParTra;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;                       

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumUniMas, this.txtUniCuaQal, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtUniCuaQal, false, "Unidades a Cuarentena", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtUniRepQal, false, "Unidades a Reprocesar", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMotRep, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtUniMueQal, false, "Unidades para Muestra", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMotMue, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUniDesQal, this.txtUniRepQal, "fffff");
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
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //deshabilitar propietario
            //this.wParTra.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana(ProduccionDetaEN pObj)
        {
            //actualizar a eOperacion al ingresar a la ventana
            this.ActualizareOperacion(pObj);

            //segun eOperacion
            switch (this.eOperacion)
            {                
                case Universal.Opera.Modificar: { this.VentanaModificar(pObj); break; }
                case Universal.Opera.Visualizar: { this.VentanaVisualizar(pObj); break; }
                default: break;
            }           
        }

        public void VentanaModificar(ProduccionDetaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pObj);           
            eMas.AccionHabilitarControles(1);
            this.HabilitarMotivos();
            this.txtUniCuaQal.Focus();
        }

        public void VentanaVisualizar(ProduccionDetaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void ActualizareOperacion(ProduccionDetaEN pObj)
        {
            if (pObj.ClaveIngresoCuarentenaQali == string.Empty)
            {
                this.eOperacion = Universal.Opera.Modificar;
            }
            else
            {
                this.eOperacion = Universal.Opera.Visualizar;
            }
        }

        public void AsignarProduccionDeta(ProduccionDetaEN pObj)
        {
            pObj.NumeroUnidadesMasa= Conversion.ADecimal(this.txtNumUniMas.Text, 0);
            pObj.CantidadCuarentenaQali = Conversion.ADecimal(this.txtUniCuaQal.Text, 0);
            pObj.SaldoLiberacionCuarentenaQali = pObj.CantidadCuarentenaQali;
            pObj.CantidadReprocesoQali = Conversion.ADecimal(this.txtUniRepQal.Text, 0);
            pObj.CantidadMuestraQali = Conversion.ADecimal(this.txtUniMueQal.Text, 0);
            pObj.CantidadDesechoQali = Conversion.ADecimal(this.txtUniDesQal.Text, 0);
            pObj.DetalleMotivoReprocesoQali = this.eLibMotEN.DetalleMotivoReproceso;
            pObj.DetalleMotivoMuestraQali = this.eLibMotEN.DetalleMotivoMuestra;
            pObj.DetalleMotivoDesechoQali = this.eLibMotEN.DetalleMotivoDesecho;
        }

        public void MostrarProduccionDeta(ProduccionDetaEN pObj)
        {
            this.txtNumUniMas.Text = Formato.NumeroDecimal(pObj.NumeroUnidadesMasa, 0);           
            this.txtUniCuaQal.Text = Formato.NumeroDecimal(pObj.CantidadCuarentenaQali, 0);
            this.txtUniRepQal.Text = Formato.NumeroDecimal(pObj.CantidadReprocesoQali, 0);
            this.txtUniMueQal.Text = Formato.NumeroDecimal(pObj.CantidadMuestraQali, 0);
            this.txtUniDesQal.Text = Formato.NumeroDecimal(pObj.CantidadDesechoQali, 0);
            this.eLibMotEN.DetalleMotivoReproceso = pObj.DetalleMotivoReprocesoQali;
            this.eLibMotEN.DetalleMotivoMuestra = pObj.DetalleMotivoMuestraQali;
            this.eLibMotEN.DetalleMotivoDesecho = pObj.DetalleMotivoDesechoQali;
        }

        public ProduccionDetaEN NuevoProduccionDetaDeVentana()
        {
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            this.AsignarProduccionDeta(iProDetEN);
            return iProDetEN;
        }

        public void MostrarCantidadDesechasQali()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevoProduccionDetaDeVentana();

            //ejecutar metodo
            decimal iCantidad = ProduccionDetaRN.ObtenerCantidadDesechasQali(iProDetEN);

            //mostrar en pantalla
            this.txtUniDesQal.Text = Formato.NumeroDecimal(iCantidad, 0);
        }

        public void MostrarCalculosAlCambiarCantidadCuarentena()
        {
            //valida cuando el control es solo lectura
            if (this.txtUniCuaQal.ReadOnly == true) { return; }

            //ejecutar
            this.MostrarCantidadDesechasQali();                     
        }

        public bool ValidaCuandoUnidadesDesechasEstanEnNegativo(TextBox pTxt)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevoProduccionDetaDeVentana();

            //ejecutar metodo
            iProDetEN = ProduccionDetaRN.ValidaCuandoUnidadesDesechasQaliEstanEnNegativo(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, pTxt);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //validar que las unidades observadas no sea negativo
            if (this.ValidaCuandoUnidadesDesechasEstanEnNegativo(this.txtUniDesQal) == false) { return; }

            //valida motivos
            if (this.EsValidarUnidadesConMotivos() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarProduccionDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la cantidad", this.eTitulo);

            //actualizar propietario
            //this.wParTra.eClaveDgvProDet = Dgv.ObtenerValorCelda(this.wParTra.DgvProDet, ProduccionDetaEN.ClaObj);
            //this.wParTra.ActualizarVentana();

            //cerrar esta ventana         
            this.Close();
        }

        //public void ModificarProduccionDeta()
        //{
        //    //traer al ProduccionDeta de b.d
        //    ProduccionDetaEN iProDetEN = this.wParTra.EsProduccionDetaExistente();

        //    //modificar datos
        //    this.AsignarProduccionDeta(iProDetEN);

        //    //actualizamos los detalles,en caso se digito cero pero ya se habian registrado los motivos
        //    ProduccionDetaRN.ActualizarCamposDetallePorMontosCeros(iProDetEN);

        //    //ejecutar metodo
        //    ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        //}

        public void ModificarProduccionDeta()
        {
            //traer al ProduccionDeta de b.d
            //ProduccionDetaEN iProDetEN = this.wParTra.EsProduccionDetaExistente();

            //modificar datos
            //this.AsignarProduccionDeta(iProDetEN);

            //actualizamos los detalles,en caso se digito cero pero ya se habian registrado los motivos
            //ProduccionDetaRN.ActualizarCamposDetallePorMontosCeros(iProDetEN);

            //actulizar campos acumulados por liberacion
            //ProduccionDetaRN.ActualizarCamposAcumuladosPorPrimeraLiberacion(iProDetEN);

            ////ejecutar metodo
            //ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public void AccionMotivosReproceso()
        {
            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }

            //instanciar
            wMotivoPrimeraLiberacion win = new wMotivoPrimeraLiberacion();
            win.wPriLib = this;
            win.eTipoMotivo = "MotRep";
            win.eCantidadMotivo = Conversion.ADecimal(this.txtUniRepQal.Text, 0);
            win.eDetalleMotivo = this.eLibMotEN.DetalleMotivoReproceso;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionMotivosMuestra()
        {
            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }

            //instanciar
            wMotivoPrimeraLiberacion win = new wMotivoPrimeraLiberacion();
            win.wPriLib = this;
            win.eTipoMotivo = "MotMue";
            win.eCantidadMotivo = Conversion.ADecimal(this.txtUniMueQal.Text, 0);
            win.eDetalleMotivo = this.eLibMotEN.DetalleMotivoMuestra;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionMotivosDesecho()
        {
            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }

            //instanciar
            wMotivoPrimeraLiberacion win = new wMotivoPrimeraLiberacion();
            win.wPriLib = this;
            win.eTipoMotivo = "MotDes";
            win.eCantidadMotivo = Conversion.ADecimal(this.txtUniDesQal.Text, 0);
            win.eDetalleMotivo = this.eLibMotEN.DetalleMotivoDesecho;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void HabilitarMotivos()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevoProduccionDetaDeVentana();

            //ejecutar metodos
            this.btnMotRep.Enabled = Cadena.CompararDosValores(iProDetEN.CantidadReprocesoQali, 0, false, true);
            this.btnMotMue.Enabled = Cadena.CompararDosValores(iProDetEN.CantidadMuestraQali, 0, false, true);
            this.btnMotDes.Enabled = Cadena.CompararDosValores(iProDetEN.CantidadDesechoQali, 0, false, true);
        }

        public bool EsValidarUnidadesConMotivos()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevoProduccionDetaDeVentana();

            //valida reproceso
            ProduccionDetaEN iLibValEN = ProduccionDetaRN.ValidaCuandoUnidadesReprocesoNoTieneIgualCantidadUnidadesMotivos(iProDetEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Motivos");
                this.btnMotRep.Focus();
                return false;
            }

            //valida muestras
            iLibValEN = ProduccionDetaRN.ValidaCuandoUnidadesMuestraNoTieneIgualCantidadUnidadesMotivos(iProDetEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Motivos");
                this.btnMotMue.Focus();
                return false;
            }

            //valida desechas
            iLibValEN = ProduccionDetaRN.ValidaCuandoUnidadesDesechaNoTieneIgualCantidadUnidadesMotivos(iProDetEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Motivos");
                this.btnMotDes.Focus();
                return false;
            }

            //ok
            return true;
        }


        #endregion

        private void wPrimeraLiberacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wParTra.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumUniMas_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtUniEnc_Validated(object sender, EventArgs e)
        {
            this.MostrarCalculosAlCambiarCantidadCuarentena();
            this.HabilitarMotivos();
        }

        private void txtUniConMue_Validated(object sender, EventArgs e)
        {
            this.MostrarCalculosAlCambiarCantidadCuarentena();
            this.HabilitarMotivos();
        }

        private void btnMotRep_Click(object sender, EventArgs e)
        {
            this.AccionMotivosReproceso();
        }

        private void btnMotDes_Click(object sender, EventArgs e)
        {
            this.AccionMotivosDesecho();
        }

        private void btnMotMue_Click(object sender, EventArgs e)
        {
            this.AccionMotivosMuestra();
        }

        private void txtUniMueQal_Validated(object sender, EventArgs e)
        {
            this.MostrarCalculosAlCambiarCantidadCuarentena();
            this.HabilitarMotivos();
        }
    }
}
