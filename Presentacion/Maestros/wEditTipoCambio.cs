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


namespace Presentacion.Maestros
{
    public partial class wEditTipoCambio : Heredados.MiForm8
    {
        public wEditTipoCambio()
        {
            InitializeComponent();
        }

        //atributos
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
       

        #region Propietario

        public wTipoCambio wTipOpe;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecTipCam, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtTipCamCom, true, "Tipo Cambio Compra", "vvff", 3, 7);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtTipCamVta, true, "Tipo Cambio Vta", "vvff", 3, 7);
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstTipCam, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wTipOpe.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos            
            this.CargarEstadosTiposOperacion();

            // Deshabilitar al propietario
            this.wTipOpe.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarTipoCambio(TipoCambioRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            //this.HabilitarParaClaseIngreso();
            this.dtpFecTipCam.Focus();
        }

        public void VentanaModificar(TipoCambioEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarTipoCambio(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            //this.HabilitarParaClaseIngreso();
            this.txtTipCamCom.Focus();
        }

        public void VentanaEliminar(TipoCambioEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarTipoCambio(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(TipoCambioEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarTipoCambio(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        

        public void CargarEstadosTiposOperacion()
        {
            Cmb.Cargar(this.cmbEstTipCam, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarTipoCambio(TipoCambioEN pObj)
        {
            pObj.FechaTipoCambio = dtpFecTipCam.Text;
            pObj.CompraTipoCambio = Convert.ToDecimal( this.txtTipCamCom.Text);
            pObj.VentaTipoCambio = Convert.ToDecimal(this.txtTipCamVta.Text);           
            pObj.CEstadoTipoCambio = Cmb.ObtenerValor(this.cmbEstTipCam, string.Empty);
        }

        public void MostrarTipoCambio(TipoCambioEN pObj)
        {
            this.dtpFecTipCam.Text = pObj.FechaTipoCambio;
            this.txtTipCamCom.Text = Formato.NumeroDecimal(pObj.CompraTipoCambio.ToString(), 3);
            this.txtTipCamVta.Text = Formato.NumeroDecimal(pObj.VentaTipoCambio.ToString(), 3);           
            this.cmbEstTipCam.SelectedValue = pObj.CEstadoTipoCambio;
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

            //el codigo de usuario ya existe?
            if (this.EsCodigoTipoOperacionDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipOpe.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Cambio se adiciono correctamente", this.wTipOpe.eTitulo);
                     
            //actualizar al propietario
            this.wTipOpe.eClaveDgvTipOpe = this.dtpFecTipCam.Text;
            this.wTipOpe.ActualizarVentana();

            //limpiar controles
            this.MostrarTipoCambio(TipoCambioRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.dtpFecTipCam.Focus();
        }
        
        public void AdicionarTipoCambio()
        {
            TipoCambioEN iTipOpeEN = new TipoCambioEN();
            this.AsignarTipoCambio(iTipOpeEN);
            TipoCambioRN.AdicionarTipoCambio(iTipOpeEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTipOpe.EsTipoCambioExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipOpe.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Operacion se modifico correctamente", this.wTipOpe.eTitulo);

            //actualizar al wUsu
            this.wTipOpe.eClaveDgvTipOpe = this.dtpFecTipCam.Text;
            this.wTipOpe.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarTipoCambio()
        {
            TipoCambioEN iTipOpeEN = new TipoCambioEN();
            this.AsignarTipoCambio(iTipOpeEN);
            iTipOpeEN = TipoCambioRN.BuscarTipoCambioXFecha(iTipOpeEN);
            this.AsignarTipoCambio(iTipOpeEN);
            TipoCambioRN.ModificarTipoCambio(iTipOpeEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTipOpe.EsActoEliminarTipoCambio().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipOpe.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarTipoCambio();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Operacion se elimino correctamente", this.wTipOpe.eTitulo);

            //actualizar al propietario           
            this.wTipOpe.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarTipoCambio()
        {
            TipoCambioEN iTipOpeEN = new TipoCambioEN();
            this.AsignarTipoCambio(iTipOpeEN);
            TipoCambioRN.EliminarTipoCambio(iTipOpeEN);
        }
                
        public bool EsCodigoTipoOperacionDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            TipoCambioEN iTipOpeEN = new TipoCambioEN();
            this.AsignarTipoCambio(iTipOpeEN);
            iTipOpeEN = TipoCambioRN.EsCodigoTipoCambioDisponible(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, this.wTipOpe.eTitulo);
                //this.dtpFecTipCam.Clear();
                this.dtpFecTipCam.Focus();
            }
            return iTipOpeEN.Adicionales.EsVerdad;
        }

        //public void HabilitarParaClaseIngreso()
        //{
        //    //valida cuando no se adicionar o modificar
        //    if (MiForm.VerdaderoCuandoAdicionaYModifica((int)eOperacion) == false) { return; }

        //    //obtener codigo de CClase
        //    string iCodigo = this.cmbClaTipOpe.SelectedValue.ToString();

        //    //obtener el valor para habilitar
        //    bool iValor = Cadena.CompararDosValores(iCodigo, "1", true, false);

        //    //habilitar combo cmbCalPrePro
        //    Cmb.Habilitar(this.cmbCalPrePro, iValor);
        //    Cmb.Habilitar(this.cmbCConUni, iValor);

        //    //cuando sea clase "Salida" , el valor del combo por defecto es "No"
        //    if (iCodigo == "2") { this.cmbCalPrePro.SelectedValue = "0"; this.cmbCConUni.SelectedValue = "0"; }    
        //}

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wTipOpe.eTitulo);
        }
        
        #endregion

        private void wEditTipoOperacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wTipOpe.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodTipOpe_Validated(object sender, EventArgs e)
        {
            this.EsCodigoTipoOperacionDisponible();
        }

        private void cmbClaTipOpe_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.HabilitarParaClaseIngreso();
        }
    }
}
