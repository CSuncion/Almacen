using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.Listas;
using Presentacion.Principal;
using Presentacion.Procesos;
using Presentacion.FuncionesGenericas;

 


namespace Presentacion.Procesos
{
    public partial class wEditLicitacion : Heredados.MiForm8
    {
        public wEditLicitacion()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();             

        #endregion

        #region Propietario

        //public wLicitacion wLic;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, false, "Cliente", "vffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodLic, true, "Codigo", "vffff", 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesLic, true, "Descripcion", "vvfff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecLic, "vvfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstLic, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvfv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvvv");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General


        public void InicializaVentana()
        {
            //titulo ventana
            //this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wLic.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos        
            this.CargarEstadosLicitacion();

            //Deshabilitar al propietario de esta ventana
            //this.wLic.Enabled = false;

            //Mostrar ventana        
            this.Show();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarLicitacion(LicitacionRN.EnBlanco());           
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodAux.Focus();
        }

        public void VentanaModificar(LicitacionEN pPro)
        {
            this.InicializaVentana();
            this.MostrarLicitacion(pPro);           
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDesLic.Focus();
        }

        public void VentanaEliminar(LicitacionEN pPro)
        {
            this.InicializaVentana();
            this.MostrarLicitacion(pPro);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(LicitacionEN pPro)
        {
            this.InicializaVentana();
            this.MostrarLicitacion(pPro);           
            eMas.AccionHabilitarControles(3);
            this.btnAceptar.Focus();
        }

        public void CargarEstadosLicitacion()
        {
            Cmb.Cargar(this.cmbEstLic, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarLicitacion(LicitacionEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pObj.CodigoLicitacion = this.txtCodLic.Text.Trim();
            pObj.DescripcionLicitacion = this.txtDesLic.Text.Trim();
            pObj.FechaLicitacion = this.dtpFecLic.Text;
            pObj.PeriodoLicitacion = Fecha.ObtenerPeriodo(pObj.FechaLicitacion, "-");
            pObj.CEstadoLicitacion = Cmb.ObtenerValor(this.cmbEstLic, string.Empty);
            pObj.ClaveLicitacion = LicitacionRN.ObtenerClaveLicitacion(pObj);            
        }

        public void MostrarLicitacion(LicitacionEN pObj)
        {
            this.txtCodAux.Text = pObj.CodigoAuxiliar;
            this.txtDesAux.Text = pObj.DescripcionAuxiliar;
            this.txtCodLic.Text = pObj.CodigoLicitacion;
            this.txtDesLic.Text = pObj.DescripcionLicitacion;
            this.dtpFecLic.Text = pObj.FechaLicitacion;
            this.cmbEstLic.SelectedValue = pObj.CEstadoLicitacion;
        }

        public LicitacionEN NuevaLicitacionDeVentana()
        {
            LicitacionEN iProCabEN = new LicitacionEN();
            this.AsignarLicitacion(iProCabEN);
            return iProCabEN;
        }

        public string ObtenerClaveLicitacionDeVentana()
        {
            //asignar parametros
            LicitacionEN iLicEN = this.NuevaLicitacionDeVentana();

            //sacar dato
            return iLicEN.ClaveLicitacion;
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

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wLic.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarLicitacion();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se agrego la licitacion correctamente", this.wLic.eTitulo);

            ////actualizar al wLot          
            //this.wLic.eClaveDgvLic = this.ObtenerClaveLicitacionDeVentana();
            //this.wLic.ActualizarVentana();

            //limpiar controles
            this.MostrarLicitacion(LicitacionRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();          
            this.txtCodAux.Focus();
        }

        public void AdicionarLicitacion()
        {
            LicitacionEN iProEN = new LicitacionEN();
            this.AsignarLicitacion(iProEN);
            LicitacionRN.AdicionarLicitacion(iProEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wLic.EsActoModificarLicitacion().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wLic.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarLicitacion();

            ////mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se modifico la licitacion correctamente", this.wLic.eTitulo);

            ////actualizar al wLot
            //this.wLic.eClaveDgvLic = this.ObtenerClaveLicitacionDeVentana();
            //this.wLic.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarLicitacion()
        {
            LicitacionEN iProEN = new LicitacionEN();
            this.AsignarLicitacion(iProEN);
            iProEN = LicitacionRN.BuscarLicitacionXClave(iProEN);
            this.AsignarLicitacion(iProEN);
            LicitacionRN.ModificarLicitacion(iProEN);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wLic.EsActoEliminarLicitacion().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wLic.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarLicitacion();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se elimino la licitacion correctamente", this.wLic.eTitulo);

            //actualizar al wLot           
            //this.wLic.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarLicitacion()
        {
            LicitacionEN iProEN = new LicitacionEN();
            this.AsignarLicitacion(iProEN);
            LicitacionRN.EliminarLicitacion(iProEN);
        }

        public void ListarClientes()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            wLisAux win = new wLisAux();
            win.eVentana = this;
            win.eTituloVentana = "Clientes";
            win.eCtrlValor = this.txtCodAux;
            win.eCtrlFoco = this.txtCodLic;
            win.eCondicionLista = Listas.wLisAux.Condicion.ClientesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsClienteValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAux.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iAuxEN = AuxiliarRN.EsClienteActivoValido(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                //Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wLic.eTitulo);
                this.txtCodAux.Focus();
            }

            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            //Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wLic.eTitulo);
        }


            

        #endregion
                

        private void wEditLicitacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wLic.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
       
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCodAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsClienteValido();
        }

        private void txtCodAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarClientes(); }
        }

        private void txtCodAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarClientes();
        }

    }
}
