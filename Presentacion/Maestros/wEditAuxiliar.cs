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
    public partial class wEditAuxiliar : Heredados.MiForm8
    {
        public wEditAuxiliar()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion



        #region Propietario

        public wAuxiliar wAux;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodAux, true, "Codigo", "vfff",11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesAux, true, "Nombre", "vvff",150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDirAux, true, "Direccion", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTelAux, false, "Telefono", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCelAux, false, "Celular", "vvff", 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCorAux, false, "Correo", "vvff", 40);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtRefAux, false, "Referencia", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTipAux, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstAux, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wAux.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos      
            this.CargarTiposAuxiliar();
            this.CargarEstadosAuxiliar();

            // Deshabilitar al propietario
            this.wAux.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarAuxiliar(AuxiliarRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodAux.Focus();
        }

        public void VentanaModificar(AuxiliarEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarAuxiliar(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDesAux.Focus();
        }

        public void VentanaEliminar(AuxiliarEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarAuxiliar(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(AuxiliarEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarAuxiliar(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void CargarTiposAuxiliar()
        {
            Cmb.Cargar(this.cmbTipAux, ItemGRN.ListarItemsG("TipAux"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadosAuxiliar()
        {
            Cmb.Cargar(this.cmbEstAux, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarAuxiliar(AuxiliarEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pObj.DescripcionAuxiliar = this.txtDesAux.Text.Trim();
            pObj.DireccionAuxiliar = this.txtDirAux.Text.Trim();
            pObj.TelefonoAuxiliar = this.txtTelAux.Text.Trim();
            pObj.CelularAuxiliar = this.txtCelAux.Text.Trim();
            pObj.CorreoAuxiliar = this.txtCorAux.Text.Trim();
            pObj.ReferenciaAuxiliar = this.txtRefAux.Text.Trim();
            pObj.CTipoAuxiliar = Cmb.ObtenerValor(this.cmbTipAux, string.Empty);
            pObj.CEstadoAuxiliar = Cmb.ObtenerValor(this.cmbEstAux, string.Empty);
            pObj.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(pObj);
        }

        public void MostrarAuxiliar(AuxiliarEN pObj)
        {
            this.txtCodAux.Text = pObj.CodigoAuxiliar;
            this.txtDesAux.Text = pObj.DescripcionAuxiliar;
            this.txtDirAux.Text = pObj.DireccionAuxiliar;
            this.txtTelAux.Text = pObj.TelefonoAuxiliar;
            this.txtCelAux.Text = pObj.CelularAuxiliar;
            this.txtCorAux.Text = pObj.CorreoAuxiliar;
            this.txtRefAux.Text = pObj.ReferenciaAuxiliar;
            this.cmbTipAux.SelectedValue = pObj.CTipoAuxiliar;
            this.cmbEstAux.SelectedValue = pObj.CEstadoAuxiliar;
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
            if (this.EsCodigoAuxiliarDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se adiciono correctamente", this.wAux.eTitulo);
                     
            //actualizar al propietario
            this.wAux.eClaveDgvAux = this.ObtenerClaveAuxiliar();
            this.wAux.ActualizarVentana();

            //limpiar controles
            this.MostrarAuxiliar(AuxiliarRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodAux.Focus();
        }

        public string ObtenerClaveAuxiliar()
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            this.AsignarAuxiliar(iAuxEN);

            //devolver
            return iAuxEN.ClaveAuxiliar;
        }

        public void AdicionarAuxiliar()
        {
            AuxiliarEN iPerEN = new AuxiliarEN();
            this.AsignarAuxiliar(iPerEN);
            AuxiliarRN.AdicionarAuxiliar(iPerEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAux.EsActoModificarAuxiliar().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se modifico correctamente", this.wAux.eTitulo);

            //actualizar al wUsu
            this.wAux.eClaveDgvAux = this.ObtenerClaveAuxiliar();
            this.wAux.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarAuxiliar()
        {
            AuxiliarEN iPerEN = new AuxiliarEN();
            this.AsignarAuxiliar(iPerEN);
            iPerEN = AuxiliarRN.BuscarAuxiliarXClave(iPerEN);
            this.AsignarAuxiliar(iPerEN);
            AuxiliarRN.ModificarAuxiliar(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAux.EsActoEliminarAuxiliar().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAux.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarAuxiliar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Auxiliar se elimino correctamente", this.wAux.eTitulo);

            //actualizar al propietario           
            this.wAux.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarAuxiliar()
        {
            AuxiliarEN iPerEN = new AuxiliarEN();
            this.AsignarAuxiliar(iPerEN);
            AuxiliarRN.EliminarAuxiliar(iPerEN);
        }
                
        public bool EsCodigoAuxiliarDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            AuxiliarEN iAuxEN = new AuxiliarEN();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = AuxiliarRN.EsCodigoAuxiliarDisponible(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wAux.eTitulo);
                this.txtCodAux.Clear();
                this.txtCodAux.Focus();
            }
            return iAuxEN.Adicionales.EsVerdad;
        }
             
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wAux.eTitulo);
        }
        
        #endregion

        private void wEditAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wAux.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodAux_Validated(object sender, EventArgs e)
        {
            this.EsCodigoAuxiliarDisponible();
        }
        
    }
}
