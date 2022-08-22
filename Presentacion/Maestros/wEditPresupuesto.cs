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
using Presentacion.Listas;

namespace Presentacion.Maestros
{
    public partial class wEditPresupuesto : Heredados.MiForm8
    {
        public wEditPresupuesto()
        {
            InitializeComponent();
        }

        //atributos
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Periodo";

        #region Propietario

        public wPresupuesto wPer;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodPer,txtAnoPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtAnoPer, true, "Año", "vfff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMesPer, "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCenCto, false, "Codigo Centro Costo", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCenCto, this.txtCodCenCto, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtImpPre, true, "Importe Presupuesto Mensual", "vvff", 4, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtImpAdiPre, false, "Importe Presupuesto Mensual Adicinal", "fvff", 4, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtSalPre, this.txtImpPre, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtSalPreTem, this.txtImpPre, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstPer, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
         
            //llenar combos
            this.CargarMeses();
            this.CargarEstadosPresupuesto();

            // Deshabilitar al propietario
            this.wPer.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarPresupuesto(PresupuestoRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtAnoPer.Focus();
        }

        public void VentanaModificar(PresupuestoEN pPer)
        {
            this.InicializaVentana();            
            this.MostrarPresupuesto(pPer);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtImpPre.Focus();
        }

        public void VentanaEliminar(PresupuestoEN pPer)
        {
            this.InicializaVentana();            
            this.MostrarPresupuesto(pPer);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(PresupuestoEN pPer)
        {
            this.InicializaVentana();            
            this.MostrarPresupuesto(pPer);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void CargarMeses()
        {
            Cmb.Cargar(this.cmbMesPer, ItemGRN.ListarItemsG("Mes"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadosPresupuesto()
        {
            Cmb.Cargar(this.cmbEstPer, ItemGRN.ListarItemsG("EstPer"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarPresupuesto(PresupuestoEN pPer)
        {
            pPer.CodigoEmpresa = Universal.gCodigoEmpresa;
            pPer.CodigoPresupuesto = this.txtCodPer.Text.Trim();
            pPer.AnoPresupuesto = this.txtAnoPer.Text.Trim();
            pPer.CMesPresupuesto = Cmb.ObtenerValor(this.cmbMesPer, string.Empty);
            pPer.NMesPresupuesto = cmbMesPer.Text;
            pPer.CCentroCosto = this.txtCodCenCto.Text.Trim();
            pPer.NCentroCosto = this.txtDesCenCto.Text;
            pPer.ImportePresupuesto = Convert.ToDecimal(this.txtImpPre.Text);
            pPer.ImporteAdicionalPresupuesto = Convert.ToDecimal(this.txtImpAdiPre.Text);
            pPer.SaldoPresupuesto = Convert.ToDecimal(this.txtImpPre.Text);
            pPer.SaldoPresupuestoTemporal = Convert.ToDecimal(this.txtImpPre.Text);
            pPer.CEstadoPresupuesto = Cmb.ObtenerValor(this.cmbEstPer, string.Empty);
            pPer.ClavePresupuesto = PresupuestoRN.ObtenerClavePresupuesto(pPer);
        }

        public void MostrarPresupuesto(PresupuestoEN pPer)
        {
            this.txtCodPer.Text = pPer.CodigoPresupuesto;
            this.txtAnoPer.Text = pPer.AnoPresupuesto;
            this.cmbMesPer.SelectedValue = pPer.CMesPresupuesto;
            this.txtCodCenCto.Text = pPer.CCentroCosto;
            this.txtDesCenCto.Text = pPer.NCentroCosto;
            this.txtImpPre.Text = Formato.NumeroDecimal(pPer.ImportePresupuesto.ToString(), 2);
            this.txtImpAdiPre.Text = Formato.NumeroDecimal(pPer.ImporteAdicionalPresupuesto.ToString(), 2);
            this.txtSalPre.Text = Formato.NumeroDecimal(pPer.SaldoPresupuesto.ToString(), 2);
            this.txtSalPreTem.Text = Formato.NumeroDecimal(pPer.SaldoPresupuestoTemporal.ToString(), 2);
            this.cmbEstPer.SelectedValue = pPer.CEstadoPresupuesto;            
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

            //el codigo ya existe?
            if (this.EsCodigoPresupuestoDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //mostrar nuevo codigo
            this.MostrarCodigoPresupuesto();

            //adicionando el registro
            this.AdicionarPresupuesto();
                 
            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Presupuesto se adiciono correctamente", "Presupuesto");
                     
            //actualizar al propietario
            this.wPer.eClaveDgvPer = this.ObtenerClaveObjeto();
            this.wPer.ActualizarVentana();

            //limpiar controles
            this.MostrarPresupuesto(PresupuestoRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtAnoPer.Focus();
        }

        public void MostrarCodigoPresupuesto()
        {
            txtCodPer.Text = txtAnoPer.Text + "-" + Cmb.ObtenerValor(cmbMesPer, "");        
        }

        public void AdicionarPresupuesto()
        {
            PresupuestoEN iPerEN = new PresupuestoEN();
            this.AsignarPresupuesto(iPerEN);
            PresupuestoRN.AdicionarPresupuesto(iPerEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPer.EsPresupuestoExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarPresupuesto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Presupuesto se modifico correctamente", "Periodo");

            //actualizar al wUsu
            this.wPer.eClaveDgvPer = this.ObtenerClaveObjeto();
            this.wPer.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarPresupuesto()
        {
            PresupuestoEN iPerEN = new PresupuestoEN();
            this.AsignarPresupuesto(iPerEN);
            iPerEN = PresupuestoRN.BuscarPresupuestoXClave(iPerEN);
            this.AsignarPresupuesto(iPerEN);
            PresupuestoRN.ModificarPresupuesto(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPer.EsActoEliminarPresupuesto().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarPresupuesto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Presupuesto se elimino correctamente", "Periodo");

            //actualizar al propietario           
            this.wPer.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarPresupuesto()
        {
            PresupuestoEN iPerEN = new PresupuestoEN();
            this.AsignarPresupuesto(iPerEN);
            PresupuestoRN.EliminarPresupuesto(iPerEN);
        }

        public void ListarCentrosCostos()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodCenCto.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            win.eCtrlValor = this.txtCodCenCto;
            win.eCtrlFoco = this.txtImpPre;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCentroCostoValido()
        {
            return Generico.EsCodigoItemEActivoValido("CenCos", this.txtCodCenCto, this.txtDesCenCto, "Centro Costos");
        }

        public bool EsCodigoPresupuestoDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            PresupuestoEN iPerEN = new PresupuestoEN();
            this.AsignarPresupuesto(iPerEN);         
            iPerEN = PresupuestoRN.EsPresupuestoDisponible(iPerEN);           
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, "Periodo");
                this.txtAnoPer.Clear();
                this.txtAnoPer.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }
             
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }

        public string ObtenerClaveObjeto()
        {
            PresupuestoEN iPerEN = new PresupuestoEN();
            this.AsignarPresupuesto(iPerEN);
            return iPerEN.ClavePresupuesto;
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodPer_Validated(object sender, EventArgs e)
        {
            this.EsCodigoPresupuestoDisponible();
        }

        private void wEditPeriodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPer.Enabled = true;           
        }

        private void txtCodCenCos_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCentrosCostos();
        }

        private void txtCodCenCto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCentrosCostos(); }
        }

        private void txtCodCenCto_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCentroCostoValido();
        }

        private void txtImpPre_Validated(object sender, EventArgs e)
        {
            this.txtSalPre.Text = this.txtImpPre.Text;
        }
    }

    
}
