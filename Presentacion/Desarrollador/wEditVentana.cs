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

namespace Presentacion.Desarrollador
{
    public partial class wEditVentana : Heredados.MiForm8
    {
        public wEditVentana()
        {
            InitializeComponent();
        }

        //variables
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Ventana";

        #region Propietario

        public wVentana wVen;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodVen, false, "Codigo", "ffff",3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomVen, true, "Nombre", "vvff",80);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomConVen, true, "Control", "vvff", 300);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstVen, "vvff");
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
            
            //Deshabilitar al propietario de esta ventana
            this.wVen.Enabled = false;

            //llenar combos
            this.CargarEstadosVentana();
            
            //Mostrar ventana
            this.Show();            
        }

        public void CambiarCkbAuto()
        {
            if (this.ckbAuto.Checked == true)
            {
                this.txtCodVen.Clear();
                this.txtCodVen.ReadOnly = true;
                this.txtCodVen.BackColor = System.Drawing.SystemColors.Control;
                this.txtNomVen.Focus();
            }
            else
            {
                this.txtCodVen.ReadOnly = false;
                this.txtCodVen.BackColor = Color.White;
                this.txtCodVen.Focus();
            }
        }

        public void FoquearSegunAutomatica()
        {
            if (this.ckbAuto.Checked == true)
            {             
                this.txtNomVen.Focus();
            }
            else
            {             
                this.txtCodVen.Focus();
            }
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Adicionar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarVentana(VentanaRN.EnBlanco());         
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.ckbAuto.Enabled = true;
            this.txtNomVen.Focus();
        }

        public void VentanaModificar(VentanaEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Modificar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarVentana(pObj);         
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomVen.Focus();
        }

        public void VentanaEliminar(VentanaEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Eliminar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarVentana(pObj);            
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(VentanaEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Visualizar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarVentana(pObj);            
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        
        public void CargarEstadosVentana()
        {           
            Cmb.Cargar(this.cmbEstVen, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarVentana(VentanaEN pObj)
        {           
            pObj.CodigoVentana = this.txtCodVen.Text.Trim();           
            pObj.NombreVentana = this.txtNomVen.Text.Trim();
            pObj.NombreControlVentana = this.txtNomConVen.Text.Trim();
            pObj.CEstadoVentana = this.cmbEstVen.SelectedValue.ToString();                        
        }

        public void MostrarVentana(VentanaEN pObj)
        {          
            this.txtCodVen.Text = pObj.CodigoVentana;
            this.txtNomVen.Text = pObj.NombreVentana;
            this.txtNomConVen.Text = pObj.NombreControlVentana;
            this.cmbEstVen.SelectedValue = pObj.CEstadoVentana;            
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
            if (this.EsCodigoVentanaDisponible(true) == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //obtener nuevo codigo
            this.ObtenerNuevoCodigo();

            //adicionando el registro
            this.AdicionarVentana();
                     
            //actualizar al wBot            
            this.wVen.eClaveDgvVen = this.txtCodVen.Text.Trim();
            this.wVen.ActualizarVentana();

            //limpiar controles
            this.MostrarVentana(VentanaRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.FoquearSegunAutomatica();
        }

        public void ObtenerNuevoCodigo()
        {
            //solo si es automatico
            if (this.ckbAuto.Checked == true)
            {              
                VentanaEN ivenEN = new VentanaEN();               
                this.txtCodVen.Text = VentanaRN.ObtenerNuevoCodigo(ivenEN);
            }            
        }

        public void AdicionarVentana()
        {          
            VentanaEN iVenEN = new VentanaEN();
            this.AsignarVentana(iVenEN);
            VentanaRN.AdicionarVentana(iVenEN);
        }
                
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wVen.EsVentanaExistente().Adicionales.EsVerdad == false) { return; }                       

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarVentana();

            //actualizar al wUsu
            this.wVen.eClaveDgvVen =this.txtCodVen.Text.Trim();
            this.wVen.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarVentana()
        {           
            VentanaEN iVenEN = new VentanaEN();
            this.AsignarVentana(iVenEN);
            iVenEN = VentanaRN.BuscarVentanaXCodigo(iVenEN);
            this.AsignarVentana(iVenEN);
            VentanaRN.ModificarVentana(iVenEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wVen.EsVentanaExistente().Adicionales.EsVerdad == false) { return; }                       

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarVentana();

            //eliminar las ventanas opciones
            this.EliminarVentanasBoton();

            //eliminar los permisosUsuario de esta ventana
            this.EliminarPermisosUsuario();

            //eliminar los permisosPerfil de esta ventana
            this.EliminarPermisosPerfil();
            
            //actualizar al PROPIETARIO          
            this.wVen.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarVentana()
        {
            VentanaEN iVenEN = new VentanaEN();
            this.AsignarVentana(iVenEN);
            VentanaRN.EliminarVentana(iVenEN);
        }

        public void EliminarVentanasBoton()
        {
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();
            iVenBotEN.CodigoVentana = this.txtCodVen.Text.Trim();
            VentanaBotonRN.EliminarVentanaBotonXVentana(iVenBotEN);
        }

        public void EliminarPermisosUsuario()
        {
            PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
            iPerUsuEN.CodigoVentana = this.txtCodVen.Text.Trim();
            PermisoUsuarioRN.EliminarPermisosUsuarioXVentana(iPerUsuEN);
        }

        public void EliminarPermisosPerfil()
        {
            PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
            iPerPerEN.CodigoVentana = this.txtCodVen.Text.Trim();
            PermisoPerfilRN.EliminarPermisosPerfilXVentana(iPerPerEN);
        }

        public bool EsCodigoVentanaDisponible(bool pConsideraVacio)
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            //validar
            VentanaEN iVenEN = new VentanaEN();
            this.AsignarVentana(iVenEN);
            iVenEN = VentanaRN.EsCodigoVentanaDisponible(iVenEN, this.ckbAuto.Checked, pConsideraVacio);
            if (iVenEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iVenEN.Adicionales.Mensaje, this.eTitulo);
                this.txtCodVen.Clear();
                this.txtCodVen.Focus();
            }
            return iVenEN.Adicionales.EsVerdad;
        }       
        
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }
        
        #endregion

        private void wEditVentana_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wVen.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodVen_Validated(object sender, EventArgs e)
        {
            this.EsCodigoVentanaDisponible(false);
        }

        private void ckbAuto_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbAuto();
        }

        
    }
}
