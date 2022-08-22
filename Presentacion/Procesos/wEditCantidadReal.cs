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
    public partial class wEditCantidadReal : Heredados.MiForm8
    {
        public wEditCantidadReal()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string eTitulo = "Cantidad";
        
        #endregion

        #region Propietario

        public wCantidadReal wCanRea;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodExi, this.txtCanUniReaEnc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCanUniReaEnc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUniXEmp, this.txtCanUniReaEnc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanUniEnc, this.txtCanUniReaEnc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumCaj, this.txtCanUniReaEnc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanUniReaEnc, true, "Cantidad", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanCajReaEnc, this.txtCanUniReaEnc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDev, this.txtCanUniReaEnc, "ffff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wCanRea.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            
            //deshabilitar propietario
            this.wCanRea.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaModificar(ProduccionProTerEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionProTer(pObj);            
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtCanUniReaEnc.Focus();
        }
        
        public void AsignarProduccionProTer(ProduccionProTerEN pObj)
        {
            pObj.UnidadesPorEmpaque = Conversion.ADecimal(this.txtUniXEmp.Text, 0);
            pObj.CantidadUnidadesProTer = Conversion.ADecimal(this.txtCanUniEnc.Text, 0);
            pObj.CantidadUnidadesRealEncajado = Conversion.ADecimal(this.txtCanUniReaEnc.Text, 0);
            pObj.CantidadCajasRealEncajado = Conversion.ADecimal(this.txtCanCajReaEnc.Text, 0);
            pObj.CantidadDevueltaEncajado = Conversion.ADecimal(this.txtDev.Text, 0);
            pObj.DetalleCantidadesSemiProducto = Dgv.ObtenerValorCelda(this.wCanRea.DgvProProTer, ProduccionProTerEN.DetCanSemPro);
            pObj.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wCanRea.DgvProProTer, ProduccionProTerEN.ClaObj);                    
        }

        public void MostrarProduccionProTer(ProduccionProTerEN pObj)
        {
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;
            this.txtUniXEmp.Text = Formato.NumeroDecimal(pObj.UnidadesPorEmpaque, 0);
            this.txtCanUniEnc.Text = Formato.NumeroDecimal(pObj.CantidadUnidadesProTer, 0);
            this.txtNumCaj.Text = Formato.NumeroDecimal(pObj.NumeroCajas, 0);
            this.txtCanUniReaEnc.Text = Formato.NumeroDecimal(pObj.CantidadUnidadesRealEncajado, 0);           
            this.txtCanCajReaEnc.Text = Formato.NumeroDecimal(pObj.CantidadCajasRealEncajado, 0);            
            this.txtDev.Text = Formato.NumeroDecimal(pObj.CantidadDevueltaEncajado, 0);         
        }

        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            ////valida unidades desechas negativas
            //if (this.ValidaCuandoUnidadesDesechasEstanEnNegativo(this.txtNumUniPas) == false) { return; }
            
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCanRea.eTitulo) == false) { return; }

            //modificar liberaciones
            this.ModificarLiberaciones();

            //modificar el registro ProduccionProTer    
            this.ModificarProduccionProTer();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la ProduccionProTer correctamente", this.wCanRea.eTitulo);

            //actualizar al propietario wProduccionProTer         
            this.wCanRea.eClaveDgvProProTer = this.ObtenerClaveProduccionProTer();
            this.wCanRea.ActualizarVentana();
            
            //salir de la ventana
            this.Close();
        }

        public void ModificarProduccionProTer()
        {
            //traer al ProduccionProTer de b.d
            ProduccionProTerEN iProDetEN = this.wCanRea.EsProduccionProTerExistente();

            //modificar datos
            this.AsignarProduccionProTer(iProDetEN);

            //ejecutar metodo
            ProduccionProTerRN.ModificarProduccionProTer(iProDetEN);
        }

        public void ModificarLiberaciones()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = this.NuevoProduccionProTerDeVentana();

            //ejecutar metodo
            LiberacionRN.ActualizarSaldosLiberacionPorDevolucionesEncajado(iProProTerEN);
        }

        public ProduccionProTerEN NuevoProduccionProTerDeVentana()
        {
            ProduccionProTerEN iProDetEN = new ProduccionProTerEN();
            this.AsignarProduccionProTer(iProDetEN);
            return iProDetEN;
        }

        public string ObtenerClaveProduccionProTer()
        {
            //asignar parametros
            ProduccionProTerEN iLebEN = this.NuevoProduccionProTerDeVentana();

            //devolver
            return iLebEN.ClaveProduccionProTer;
        }

        public bool EsCantidadUnidadesCorrecto()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = this.NuevoProduccionProTerDeVentana();
            
            //ejecutar metodo
            iProProTerEN = ProduccionProTerRN.EsCantidadUnidadesRealesCorrecta(iProProTerEN);

            //mensaje error
            Generico.MostrarMensajeError(iProProTerEN.Adicionales, this.txtCanUniReaEnc);

            //devolver
            return iProProTerEN.Adicionales.EsVerdad;
        }

        public void MostrarCantidadCajas()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = this.NuevoProduccionProTerDeVentana();

            //ejecutar metodos          
            decimal iNumeroCajas = ProduccionProTerRN.CalcularNumeroCajasReales(iProProTerEN);

            //mostrar en pantalla
            this.txtCanCajReaEnc.Text = Formato.NumeroDecimal(iNumeroCajas, 2);
        }

        public void MostrarUnidadesDevueltas()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = this.NuevoProduccionProTerDeVentana();

            //ejecutar metodos          
            decimal iNumeroCajas = ProduccionProTerRN.CalcularUnidadesDevueltas(iProProTerEN);

            //mostrar en pantalla
            this.txtDev.Text = Formato.NumeroDecimal(iNumeroCajas, 2);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wCanRea.eTitulo);
        }

        #endregion

        private void wEditCantidadReal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCanRea.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
              
        private void txtCanUniReaEnc_Validated(object sender, EventArgs e)
        {
            this.MostrarCantidadCajas();
            this.MostrarUnidadesDevueltas();
            this.EsCantidadUnidadesCorrecto();
        }


    }
}
