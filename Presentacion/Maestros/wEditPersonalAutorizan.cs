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
    public partial class wEditPersonalAutorizan : Heredados.MiForm8
    {
        public wEditPersonalAutorizan()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion
        
        #region Propietario

        public wPersonalAutorizan wPerAut;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodPer, true, "Codigo", "vfff",3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomPer, true, "Nombre", "vvff",100);
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wPerAut.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos        
            this.CargarEstadosPersonal();

            // Deshabilitar al propietario
            this.wPerAut.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarPersonal(PersonalAutorizanRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodPer.Focus();
        }

        public void VentanaModificar(PersonalAutorizanEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarPersonal(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomPer.Focus();
        }

        public void VentanaEliminar(PersonalAutorizanEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarPersonal(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(PersonalAutorizanEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarPersonal(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void CargarEstadosPersonal()
        {
            Cmb.Cargar(this.cmbEstPer, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarPersonal(PersonalAutorizanEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoPersonalAutoriza = this.txtCodPer.Text.Trim();
            pObj.NombrePersonalAutoriza = this.txtNomPer.Text.Trim();
            pObj.CEstadoPersonalAutoriza = Cmb.ObtenerValor(this.cmbEstPer, string.Empty);
            pObj.ClavePersonalAutoriza = PersonalAutorizanRN.ObtenerClavePersonal(pObj);
        }

        public void MostrarPersonal(PersonalAutorizanEN pObj)
        {
            this.txtCodPer.Text = pObj.CodigoPersonalAutoriza;
            this.txtNomPer.Text = pObj.NombrePersonalAutoriza;
            this.cmbEstPer.SelectedValue = pObj.CEstadoPersonalAutoriza;
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
            if (this.EsCodigoPersonalDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wPerAut.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarPersonal();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Personal se adiciono correctamente", this.wPerAut.eTitulo);
                     
            //actualizar al propietario
            this.wPerAut.eClaveDgvPer = this.ObtenerClavePersonal();
            this.wPerAut.ActualizarVentana();

            //limpiar controles
            this.MostrarPersonal(PersonalAutorizanRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodPer.Focus();
        }

        public string ObtenerClavePersonal()
        {
            //asignar parametros
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();
            this.AsignarPersonal(iPerEN);

            //devolver
            return iPerEN.ClavePersonalAutoriza;
        }

        public void AdicionarPersonal()
        {
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();
            this.AsignarPersonal(iPerEN);
            PersonalAutorizanRN.AdicionarPersonal(iPerEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPerAut.EsActoModificarPersonal().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wPerAut.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarPersonal();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Personal se modifico correctamente", this.wPerAut.eTitulo);

            //actualizar al wUsu
            this.wPerAut.eClaveDgvPer = this.ObtenerClavePersonal();
            this.wPerAut.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarPersonal()
        {
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();
            this.AsignarPersonal(iPerEN);
            iPerEN = PersonalAutorizanRN.BuscarPersonalXClave(iPerEN);
            this.AsignarPersonal(iPerEN);
            PersonalAutorizanRN.ModificarPersonal(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPerAut.EsActoEliminarPersonal().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wPerAut.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarPersonal();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Personal se elimino correctamente", this.wPerAut.eTitulo);

            //actualizar al propietario           
            this.wPerAut.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarPersonal()
        {
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();
            this.AsignarPersonal(iPerEN);
            PersonalAutorizanRN.EliminarPersonal(iPerEN);
        }
                
        public bool EsCodigoPersonalDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();
            this.AsignarPersonal(iPerEN);
            iPerEN = PersonalAutorizanRN.EsCodigoPersonalDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wPerAut.eTitulo);
                this.txtCodPer.Clear();
                this.txtCodPer.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }
             
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wPerAut.eTitulo);
        }
        
        #endregion

        private void wEditPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPerAut.Enabled = true;           
        }

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
            this.EsCodigoPersonalDisponible();
        }
        
    }
}
