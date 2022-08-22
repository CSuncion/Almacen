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


namespace Presentacion.Sistema
{
    public partial class wEditPerfil : Heredados.MiForm8
    {
        public wEditPerfil()
        {
            InitializeComponent();
        }

        //atributos
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Perfil";

        #region Propietario

        public wPerfil wPer;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodPer, true, "Codigo", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomPer, true, "Nombre", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesPer, false, "Descripcion", "vvff");
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
            this.CargarEstadosPerfiles();

            // Deshabilitar al propietario
            this.wPer.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarPerfil(PerfilRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodPer.Focus();
        }

        public void VentanaModificar(PerfilEN pPer)
        {
            this.InicializaVentana();            
            this.MostrarPerfil(pPer);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomPer.Focus();
        }

        public void VentanaEliminar(PerfilEN pPer)
        {
            this.InicializaVentana();            
            this.MostrarPerfil(pPer);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(PerfilEN pPer)
        {
            this.InicializaVentana();            
            this.MostrarPerfil(pPer);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        
        public void CargarEstadosPerfiles()
        {
            Cmb.Cargar(this.cmbEstPer, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarPerfil(PerfilEN pPer)
        {
            pPer.CodigoPerfil = this.txtCodPer.Text.Trim();
            pPer.NombrePerfil = this.txtNomPer.Text.Trim();
            pPer.DescripcionPerfil = this.txtDesPer.Text.Trim();
            pPer.CEstadoPerfil = Cmb.ObtenerValor(this.cmbEstPer, string.Empty);        
        }

        public void MostrarPerfil(PerfilEN pPer)
        {
            this.txtCodPer.Text = pPer.CodigoPerfil;
            this.txtNomPer.Text = pPer.NombrePerfil;
            this.txtDesPer.Text = pPer.DescripcionPerfil;
            this.cmbEstPer.SelectedValue = pPer.CEstadoPerfil;            
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
            if (this.EsCodigoPerfilDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarPerfil();

            //generar los permisos del perfil
            this.GenerarPermisosPerfil();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El perfil se adiciono correctamente", "Perfil");
                     
            //actualizar al propietario
            this.wPer.eClaveDgvPer = this.txtCodPer.Text.Trim();
            this.wPer.ActualizarVentana();

            //limpiar controles
            this.MostrarPerfil(PerfilRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodPer.Focus();
        }
        
        public void AdicionarPerfil()
        {
            PerfilEN iPerEN = new PerfilEN();
            this.AsignarPerfil(iPerEN);
            PerfilRN.AdicionarPerfil(iPerEN);
        }

        public void GenerarPermisosPerfil()
        {
            PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
            iPerPerEN.CodigoPerfil= this.txtCodPer.Text.Trim();
            PermisoPerfilRN.AdicionarPermisosPerfilParaNuevoPerfil(iPerPerEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPer.EsPerfilExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarPerfil();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El perfil se modifico correctamente", "Perfil");

            //actualizar al wUsu
            this.wPer.eClaveDgvPer = this.txtCodPer.Text.Trim();
            this.wPer.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarPerfil()
        {
            PerfilEN iPerEN = new PerfilEN();
            this.AsignarPerfil(iPerEN);
            iPerEN = PerfilRN.BuscarPerfilXCodigo(iPerEN);
            this.AsignarPerfil(iPerEN);
            PerfilRN.ModificarPerfil(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wPer.EsActoEliminarPerfil().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarPerfil();

            //eliminar los PermisosPerfil de este perfil
            this.EliminarPermisosPerfil();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El perfil se elimino correctamente", "Perfil");

            //actualizar al propietario           
            this.wPer.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarPerfil()
        {
            PerfilEN iPerEN = new PerfilEN();
            this.AsignarPerfil(iPerEN);
            PerfilRN.EliminarPerfil(iPerEN);
        }

        public void EliminarPermisosPerfil()
        {
            PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
            iPerPerEN.CodigoPerfil = this.txtCodPer.Text.Trim();
            PermisoPerfilRN.EliminarPermisosPerfilDePerfil(iPerPerEN);
        }

        public bool EsCodigoPerfilDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            PerfilEN iPerEN = new PerfilEN();
            this.AsignarPerfil(iPerEN);
            iPerEN = PerfilRN.EsCodigoPerfilDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, "Usuario");
                this.txtCodPer.Clear();
                this.txtCodPer.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }
             
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }
        
        #endregion

        private void wEditPerfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPer.Enabled = true;           
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
            this.EsCodigoPerfilDisponible();
        }
        
    }
}
