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
    public partial class wEditPersonalReciben : Heredados.MiForm8
    {
        public wEditPersonalReciben()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion
        
        #region Propietario

        public wPersonalReciben wPerRec;

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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wPerRec.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos        
            this.CargarEstadosPersonal();

            // Deshabilitar al propietario
            this.wPerRec.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarPersonal(PersonalRecibenRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodPer.Focus();
        }

        public void VentanaModificar(PersonalRecibenEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarPersonal(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomPer.Focus();
        }

        public void VentanaEliminar(PersonalRecibenEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarPersonal(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(PersonalRecibenEN pObj)
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

        public void AsignarPersonal(PersonalRecibenEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoPersonalRecibe = this.txtCodPer.Text.Trim();
            pObj.NombrePersonalRecibe = this.txtNomPer.Text.Trim();
            pObj.CEstadoPersonalRecibe = Cmb.ObtenerValor(this.cmbEstPer, string.Empty);
            pObj.ClavePersonalRecibe = PersonalRecibenRN.ObtenerClavePersonal(pObj);
        }

        public void MostrarPersonal(PersonalRecibenEN pObj)
        {
            this.txtCodPer.Text = pObj.CodigoPersonalRecibe;
            this.txtNomPer.Text = pObj.NombrePersonalRecibe;
            this.cmbEstPer.SelectedValue = pObj.CEstadoPersonalRecibe;
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
            if (Mensaje.DeseasRealizarOperacion(this.wPerRec.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarPersonal();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Personal se adiciono correctamente", this.wPerRec.eTitulo);
                     
            //actualizar al propietario
            this.wPerRec.eClaveDgvPer = this.ObtenerClavePersonal();
            this.wPerRec.ActualizarVentana();

            //limpiar controles
            this.MostrarPersonal(PersonalRecibenRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodPer.Focus();
        }

        public string ObtenerClavePersonal()
        {
            //asignar parametros
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            this.AsignarPersonal(iPerEN);

            //devolver
            return iPerEN.ClavePersonalRecibe;
        }

        public void AdicionarPersonal()
        {
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            this.AsignarPersonal(iPerEN);
            PersonalRecibenRN.AdicionarPersonal(iPerEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPerRec.EsActoModificarPersonal().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wPerRec.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarPersonal();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Personal se modifico correctamente", this.wPerRec.eTitulo);

            //actualizar al wUsu
            this.wPerRec.eClaveDgvPer = this.ObtenerClavePersonal();
            this.wPerRec.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarPersonal()
        {
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            this.AsignarPersonal(iPerEN);
            iPerEN = PersonalRecibenRN.BuscarPersonalXClave(iPerEN);
            this.AsignarPersonal(iPerEN);
            PersonalRecibenRN.ModificarPersonal(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPerRec.EsActoEliminarPersonal().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wPerRec.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarPersonal();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Personal se elimino correctamente", this.wPerRec.eTitulo);

            //actualizar al propietario           
            this.wPerRec.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarPersonal()
        {
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            this.AsignarPersonal(iPerEN);
            PersonalRecibenRN.EliminarPersonal(iPerEN);
        }
                
        public bool EsCodigoPersonalDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            this.AsignarPersonal(iPerEN);
            iPerEN = PersonalRecibenRN.EsCodigoPersonalDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wPerRec.eTitulo);
                this.txtCodPer.Clear();
                this.txtCodPer.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }
             
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wPerRec.eTitulo);
        }
        
        #endregion

        private void wEditPersonal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPerRec.Enabled = true;           
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
