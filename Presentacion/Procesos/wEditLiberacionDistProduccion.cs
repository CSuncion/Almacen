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
    public partial class wEditLiberacionDistProduccion : Heredados.MiForm8
    {
        public wEditLiberacionDistProduccion()
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
            xCtrl.TxtNumeroPositivoConDecimales(this.txtNumUniPas, false, "Encajadas", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtNumUniSal, false, "Saldo", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumUniObs, this.txtNumUniPas, "fffff");
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
            eMas.AccionPasarTextoPrincipal();
            this.txtNumUniPas.Focus();
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
            if (this.ValidaCuandoUnidadesObservadasEstanEnNegativo(this.txtNumUniPas) == false) { return; }

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }
            
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

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se modifico la liberacion correctamente", this.wLibDis.eTitulo);

            ////actualizar al propietario wLiberacion         
            //this.wLibDis.eClaveDgvLib = this.ObtenerClaveLiberacion();
            //this.wLibDis.ActualizarVentana();
            
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

        public void MostrarNumeroUnidadesObservadas()
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            decimal iCantidad = LiberacionRN.ObtenerNumeroUnidadesObservadas(iProDetEN);

            //mostrar en pantalla
            this.txtNumUniObs.Text = Formato.NumeroDecimal(iCantidad, 0);
        }

        public bool ValidaCuandoUnidadesObservadasEstanEnNegativo(TextBox pTxt)
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            iProDetEN = LiberacionRN.ValidaCuandoUnidadesObservadasEstanEnNegativo(iProDetEN);

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

        private void wEditLiberacionDistProduccion_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtNumUniPas_Validated(object sender, EventArgs e)
        {
            this.MostrarNumeroUnidadesObservadas();            
        }
      
        private void txtNumUniSal_Validated(object sender, EventArgs e)
        {
            this.MostrarNumeroUnidadesObservadas();            
        }
    }
}
