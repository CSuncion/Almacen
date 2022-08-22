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
    public partial class wEditTipoOperacion : Heredados.MiForm8
    {
        public wEditTipoOperacion()
        {
            InitializeComponent();
        }

        //atributos
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
       

        #region Propietario

        public wTipoOperacion wTipOpe;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodTipOpe, true, "Codigo", "vfff",2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesTipOpe, true, "Descripcion", "vvff",100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbClaTipOpe, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCalPrePro, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCConUni, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstTipOpe, "vvff");
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
            this.CargarClasesTiposOperacion();
            this.CargarCalculaPrecioPromedio();
            this.CargarConversionUnidad();
            this.CargarEstadosTiposOperacion();

            // Deshabilitar al propietario
            this.wTipOpe.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarTipoOperacion(TipoOperacionRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.HabilitarParaClaseIngreso();
            this.txtCodTipOpe.Focus();
        }

        public void VentanaModificar(TipoOperacionEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarTipoOperacion(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.HabilitarParaClaseIngreso();
            this.txtDesTipOpe.Focus();
        }

        public void VentanaEliminar(TipoOperacionEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarTipoOperacion(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(TipoOperacionEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarTipoOperacion(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void CargarClasesTiposOperacion()
        {
            Cmb.Cargar(this.cmbClaTipOpe, ItemGRN.ListarItemsG("ClaOpe"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCalculaPrecioPromedio()
        {
            Cmb.Cargar(this.cmbCalPrePro, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarConversionUnidad()
        {
            Cmb.Cargar(this.cmbCConUni, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadosTiposOperacion()
        {
            Cmb.Cargar(this.cmbEstTipOpe, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarTipoOperacion(TipoOperacionEN pObj)
        {
            pObj.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            pObj.DescripcionTipoOperacion = this.txtDesTipOpe.Text.Trim();
            pObj.CClaseTipoOperacion = Cmb.ObtenerValor(this.cmbClaTipOpe, string.Empty);
            pObj.CCalculaPrecioPromedio = Cmb.ObtenerValor(this.cmbCalPrePro, string.Empty);
            pObj.CConversionUnidad = Cmb.ObtenerValor(this.cmbCConUni, string.Empty);
            pObj.CEstadoTipoOperacion = Cmb.ObtenerValor(this.cmbEstTipOpe, string.Empty);
        }

        public void MostrarTipoOperacion(TipoOperacionEN pObj)
        {
            this.txtCodTipOpe.Text = pObj.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = pObj.DescripcionTipoOperacion;
            this.cmbClaTipOpe.SelectedValue = pObj.CClaseTipoOperacion;
            this.cmbCalPrePro.SelectedValue = pObj.CCalculaPrecioPromedio;
            this.cmbCConUni.SelectedValue = pObj.CConversionUnidad;
            this.cmbEstTipOpe.SelectedValue = pObj.CEstadoTipoOperacion;
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
            this.AdicionarTipoOperacion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Operacion se adiciono correctamente", this.wTipOpe.eTitulo);
                     
            //actualizar al propietario
            this.wTipOpe.eClaveDgvTipOpe = this.txtCodTipOpe.Text.Trim();
            this.wTipOpe.ActualizarVentana();

            //limpiar controles
            this.MostrarTipoOperacion(TipoOperacionRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodTipOpe.Focus();
        }
        
        public void AdicionarTipoOperacion()
        {
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            this.AsignarTipoOperacion(iTipOpeEN);
            TipoOperacionRN.AdicionarTipoOperacion(iTipOpeEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTipOpe.EsTipoOperacionExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipOpe.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarTipoOperacion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Operacion se modifico correctamente", this.wTipOpe.eTitulo);

            //actualizar al wUsu
            this.wTipOpe.eClaveDgvTipOpe = this.txtCodTipOpe.Text.Trim();
            this.wTipOpe.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarTipoOperacion()
        {
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            this.AsignarTipoOperacion(iTipOpeEN);
            iTipOpeEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iTipOpeEN);
            this.AsignarTipoOperacion(iTipOpeEN);
            TipoOperacionRN.ModificarTipoOperacion(iTipOpeEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTipOpe.EsActoEliminarTipoOperacion().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTipOpe.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarTipoOperacion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Tipo Operacion se elimino correctamente", this.wTipOpe.eTitulo);

            //actualizar al propietario           
            this.wTipOpe.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarTipoOperacion()
        {
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            this.AsignarTipoOperacion(iTipOpeEN);
            TipoOperacionRN.EliminarTipoOperacion(iTipOpeEN);
        }
                
        public bool EsCodigoTipoOperacionDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            this.AsignarTipoOperacion(iTipOpeEN);
            iTipOpeEN = TipoOperacionRN.EsCodigoTipoOperacionDisponible(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, this.wTipOpe.eTitulo);
                this.txtCodTipOpe.Clear();
                this.txtCodTipOpe.Focus();
            }
            return iTipOpeEN.Adicionales.EsVerdad;
        }

        public void HabilitarParaClaseIngreso()
        {
            //valida cuando no se adicionar o modificar
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)eOperacion) == false) { return; }

            //obtener codigo de CClase
            string iCodigo = this.cmbClaTipOpe.SelectedValue.ToString();

            //obtener el valor para habilitar
            bool iValor = Cadena.CompararDosValores(iCodigo, "1", true, false);

            //habilitar combo cmbCalPrePro
            Cmb.Habilitar(this.cmbCalPrePro, iValor);
            Cmb.Habilitar(this.cmbCConUni, iValor);

            //cuando sea clase "Salida" , el valor del combo por defecto es "No"
            if (iCodigo == "2") { this.cmbCalPrePro.SelectedValue = "0"; this.cmbCConUni.SelectedValue = "0"; }    
        }

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
            this.HabilitarParaClaseIngreso();
        }
    }
}
