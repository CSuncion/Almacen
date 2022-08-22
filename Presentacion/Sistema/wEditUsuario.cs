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
    public partial class wEditUsuario : Heredados.MiForm8
    {
        public wEditUsuario()
        {
            InitializeComponent();
        }

        //variables
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Usuario";

        #region Propietario

        public wUsuario wUsu;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtLetrasYNumerosSinEspacion(this.txtCodUsu, true, "Usuario", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtLetrasYNumerosSinEspacion(this.txtClaUsu, true, "Contraseña", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbPer, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstUsu, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomUsu, true, "Nombre", "vvff");            
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDirUsu, true, "Direccion", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCorUsu, false, "Correo", "vvff");            
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConEspacion(this.txtTelFijUsu, false, "Tel Fijo", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConEspacion(this.txtTelCelUsu, false, "Tel Celular", "vvff");
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Btn(this.btnImaUsu, "vvff");
            //xCtrl.NTabPage = this.tbpFotografia;
            //xLis.Add(xCtrl);

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
            this.CargarPerfiles();
            this.CargarEstadosUsuario();

            // Deshabilitar al propietario de esta ventana
            this.wUsu.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarUsuario(UsuarioRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodUsu.Focus();
        }
        
        public void VentanaModificar(UsuarioEN pUsu)
        {
            this.InicializaVentana();           
            this.MostrarUsuario(pUsu);         
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtClaUsu.Focus();
        }
        
        public void VentanaEliminar(UsuarioEN pUsu)
        {
            this.InicializaVentana();            
            this.MostrarUsuario(pUsu);          
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }
        
        public void VentanaVisualizar(UsuarioEN pUsu)
        {
            this.InicializaVentana();            
            this.MostrarUsuario(pUsu);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        
        public void CargarPerfiles()
        {
            PerfilEN iPerEN = new PerfilEN();
            iPerEN.CEstadoPerfil = "1";//activado
            iPerEN.Adicionales.CampoOrden = PerfilEN.CodPer;
            Cmb.Cargar(this.cmbPer, PerfilRN.ListarPerfilesXEstado(iPerEN), PerfilEN.CodPer, PerfilEN.NomPer);
        }

        public void CargarEstadosUsuario()
        {
            Cmb.Cargar(this.cmbEstUsu, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }
        
        public void AsignarUsuario(UsuarioEN pUsu)
        {
            pUsu.CodigoUsuario = this.txtCodUsu.Text.Trim();
            pUsu.ClaveUsuario = Encriptacion.Encriptar(this.txtClaUsu.Text.Trim());
            pUsu.CodigoPerfil = Cmb.ObtenerValor(this.cmbPer, string.Empty);
            pUsu.CEstadoUsuario = Cmb.ObtenerValor(this.cmbEstUsu, string.Empty);     
            pUsu.NombreUsuario = this.txtNomUsu.Text.Trim();
            pUsu.DireccionUsuario = this.txtDirUsu.Text.Trim();
            pUsu.CorreoUsuario = this.txtCorUsu.Text.Trim();
            pUsu.TelFijoUsuario = this.txtTelFijUsu.Text.Trim();
            pUsu.TelCelularUsuario = this.txtTelCelUsu.Text.Trim();          
        }
        
        public void MostrarUsuario(UsuarioEN pUsu)
        {
            this.txtCodUsu.Text = pUsu.CodigoUsuario;
            this.txtClaUsu.Text = Encriptacion.Desencriptar(pUsu.ClaveUsuario);
            this.cmbPer.SelectedValue = pUsu.CodigoPerfil;
            this.cmbEstUsu.SelectedValue = pUsu.CEstadoUsuario;
            this.txtNomUsu.Text = pUsu.NombreUsuario;
            this.txtDirUsu.Text = pUsu.DireccionUsuario;
            this.txtCorUsu.Text = pUsu.CorreoUsuario;
            this.txtTelFijUsu.Text = pUsu.TelFijoUsuario;
            this.txtTelCelUsu.Text = pUsu.TelCelularUsuario;       
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
            if (this.EsCodigoUsuarioDisponible(true) == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarUsuario();

            //generar permisos empresas
            this.GenerarPermisosEmpresa();
            
            //generar permisos sistema
            this.GenerarPermisosSistema();

            //generar permisos almacen
            this.GenerarPermisosAlmacen();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " adicionado correctamente", this.eTitulo);

            //actualizar al propietario
            this.wUsu.eClaveDgvUsu = this.txtCodUsu.Text.Trim();
            this.wUsu.ActualizarVentana();

            //limpiar controles
            this.MostrarUsuario(UsuarioRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodUsu.Focus();
        }
        
        public void AdicionarUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            UsuarioRN.AdicionarUsuario(iUsuEN);
        }
        
        public void GenerarPermisosEmpresa()
        {           
            PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
            iPemEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            PermisoEmpresaRN.AdicionarPermisosEmpresaXUsuario(iPemEN);
        }
                      
        public void GenerarPermisosSistema()
        {
            PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
            iPerUsuEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            PermisoUsuarioRN.AdicionarPermisosUsuarioParaUsuario(iPerUsuEN);
        }

        public void GenerarPermisosAlmacen()
        {
            //asignar parametros
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);

            //ejecutar metodo            
            PermisoAlmacenRN.AdicionarPermisosAlmacenXUsuario(iUsuEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wUsu.EsUsuarioExistente().Adicionales.EsVerdad == false) { return; }
                      
            //validar si se puede modificar el tipo de este usuario
            if (this.EsModificableTipoUsuario() == false) { return; }

            //validar si se puede modificar el estado de este usuario
            if (this.EsModificableEstadoUsuario() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarUsuario();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " modificado correctamente", this.eTitulo);

            //actualizar al wUsu
            this.wUsu.eClaveDgvUsu = this.txtCodUsu.Text.Trim();
            this.wUsu.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(iUsuEN);
            this.AsignarUsuario(iUsuEN);
            UsuarioRN.ModificarUsuario(iUsuEN);
        }
        
        public void Eliminar()
        {
            //preguntar si es el unico administrador activo del sistema
            //en ese caso no podras eliminar este usuario
            if (this.wUsu.EsEliminableUsuario().Adicionales.EsVerdad == false) { return; }
            
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarUsuario();

            //eliminar los permisos empresa de este usuario
            this.EliminarPermisosEmpresa();
                     
            //eliminar los permisos sistema de este usuario
            this.EliminarPermisosSistema();

            //eliminar los permisos almacen de este usuario
            this.EliminarPermisosAlmacen();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " eliminado correctamente", this.eTitulo);

            //actualizar al wUsu           
            this.wUsu.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            UsuarioRN.EliminarUsuario(iUsuEN);
        }

        public void EliminarPermisosEmpresa()
        {
            PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
            iPemEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            PermisoEmpresaRN.EliminarPermisosEmpresaXUsuario(iPemEN);
        }
    
        public void EliminarPermisosSistema()
        {
            PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
            iPerUsuEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            PermisoUsuarioRN.EliminarPermisosUsuarioDeUsuario(iPerUsuEN);
        }

        public void EliminarPermisosAlmacen()
        {
            //asignar parametros
            string iCodigoUsuario = this.txtCodUsu.Text.Trim();

            //ejecutar metodo
            PermisoAlmacenRN.EliminarPermisoAlmacenXUsuario(iCodigoUsuario);
        }

        public bool EsCodigoUsuarioDisponible(bool pVacio)
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }
           
            //
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsCodigoUsuarioDisponible(iUsuEN, pVacio);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
                this.txtCodUsu.Clear();
                this.txtCodUsu.Focus();
            }
            return iUsuEN.Adicionales.EsVerdad;
        }
          
        public bool EsModificableTipoUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsModificableTipoUsuario(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
                this.cmbPer.Focus();         
            }
            return iUsuEN.Adicionales.EsVerdad;
        }

        public bool EsModificableEstadoUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsModificableEstadoUsuario(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
                this.cmbEstUsu.Focus();
            }
            return iUsuEN.Adicionales.EsVerdad;
        }
                       
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }
        
        #endregion

        private void wEditUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wUsu.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodUsu_Validated(object sender, EventArgs e)
        {
            this.EsCodigoUsuarioDisponible(false);
        }

        private void txtClaUsu_Validated(object sender, EventArgs e)
        {
            Txt.ValidarLongitudTexto(this.txtClaUsu, 6, 20, false);
        }

      



    }
}
