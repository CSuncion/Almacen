using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Negocio;
using Comun;
using Presentacion;
using WinControles.ControlesWindows;
using Entidades;
using Entidades.Adicionales;
using Presentacion.Principal;
using Presentacion.Listas;

namespace Presentacion.Principal
{
    public partial class wAcceso : Form
    {
        public wAcceso()
        {
            InitializeComponent();
        }

        Masivo eMas = new Masivo();
        public int eFlagInvoca = 0;//0: al iniciar el sistema,1: cambio de usuario

        #region Propietario

        public wMenu wMen;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomUsu, this.txtCodUsu, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer, this.txtCodUsu, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodUsu, true, "Usuario", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCla, true, "Contraseña", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodEmp, true, "Empresa", "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomEmp, this.txtCodUsu, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnIngresar, "f");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "f");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana()
        {
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
        }
        
        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarPersistencia();                  
            this.ShowDialog();
        }
        
        public bool EsUsuarioValido()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsUsuarioValido(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
                this.txtCodUsu.Focus();
            }
            this.txtCodUsu.Text = iUsuEN.CodigoUsuario;
            this.txtNomUsu.Text = iUsuEN.NombreUsuario;
            this.txtCodPer.Text = iUsuEN.CodigoPerfil;
            this.txtNomPer.Text = iUsuEN.NombrePerfil;
            return iUsuEN.Adicionales.EsVerdad;
        }

        public void AsignarUsuario(UsuarioEN pUsu)
        {
            pUsu.CodigoUsuario = this.txtCodUsu.Text.Trim();
            pUsu.NombreUsuario = this.txtNomUsu.Text.Trim();
            pUsu.ClaveUsuario = Encriptacion.Encriptar(this.txtCla.Text.Trim());
        }
        
        public void ListarUsuarios()
        {
            wLisUsuExt win = new wLisUsuExt();
            this.AddOwnedForm(win);
            win.eVentana = this;          
            win.eTituloVentana = "Usuarios activos";
            win.eCtrlValor = this.txtCodUsu;
            win.eCtrlFoco = this.txtCla;
            win.eCondicionLista = wLisUsuExt.Condicion.UsuariosActivos;           
            win.NuevaVentana();
        }
        
        public bool EsEmpresaDeUsuario()
        {
            //preguntamos si la empresa que se digita es del usuario seleccionado
            PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
            iPemEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            iPemEN.CodigoEmpresa = this.txtCodEmp.Text.Trim();
            iPemEN.ClavePermisoEmpresa = PermisoEmpresaRN.ObtenerClavePermisoEmpresa(iPemEN);
            iPemEN = PermisoEmpresaRN.EsEmpresaDeUsuario(iPemEN);
            if (iPemEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPemEN.Adicionales.Mensaje, "Empresa");          
                this.txtCodEmp.Focus();
            }
            this.txtCodEmp.Text = iPemEN.CodigoEmpresa;
            this.txtNomEmp.Text = iPemEN.NombreEmpresa;
            return iPemEN.Adicionales.EsVerdad;
        }
        
        public void ListarEmpresasDeUsuario()
        {
            wLisPerEmpExt win = new wLisPerEmpExt();
            win.eVentana = this;
            win.eTituloVentana = "Empresas autorizadas";
            win.eCtrlValor = this.txtCodEmp;
            win.eCtrlFoco = this.btnIngresar;
            //condicion
            win.ePemEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            win.eCondicionLista = wLisPerEmpExt.Condicion.EmpresasAutorizadasDeUsuario;
            win.NuevaVentana();
        }
        
        public bool EsClaveDeUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsContrasenaDeUsuario(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Clave");
                this.txtCla.Clear();                
                this.txtCla.Focus();
            }
            return iUsuEN.Adicionales.EsVerdad;
        }

        public bool EsSistemaCaducado()
        {
            ////traemos al objeto parametro
            //ParametroEN iParEN = ParametroRN.BuscarParametro();

            ////compramos fecha de caducidad con fecha de acceso al sistema
            //if (DateTime.Today.Date > iParEN.FechaCaducidad.Date)
            //{
            //    Mensaje.OperacionDenegada("El periodo de prueba del sistema a terminado", "Caducidad");
            //    return false;
            //}
            return true;
        }

        public void AccesarSistema()
        {
            //bloqueaSistemaArquiglass
            //if (this.EsSistemaCaducado() == false) { return; }

            //chequear campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //chequear si el usuario es valido
            if (this.EsUsuarioValido() == false) { return; }

            //chaquear si es empresa del usuario
            if (this.EsEmpresaDeUsuario() == false) { return; }

            //comprobar si la clave es correcta     
            if (this.EsClaveDeUsuario() == false) { return; }

            //aqui paso todas las validaciones
            //pasamos las variables globales
            this.GuardarValoresUniversales();
                     
            //Guardar la persistencia de datos
            this.GrabarPersistencia();
                     
            //barra de estado para el menu         
            this.wMen.tssBarraEstado.Text = Universal.EstadoBarra();

            //eliminar todas las ventanas abiertas
            this.wMen.EliminarTodasLasVentanasAbiertas();

            //eliminar todos los TabModulos que esten abiertos
            this.wMen.EliminarTodosLosTabVentanas();           

            //habilitar los items del menu
            MeSt.HabilitarMenu(this.wMen.msMenu, true);

            //habilitar segun permisos
            this.wMen.HabilitarAcciones();

            //accion ventana alarma
            this.VentanaAlarmaStockMinimo();

            //cerrar ventana acceso
            this.Close();
        }

        public void GuardarValoresUniversales()
        {
            Universal.gCodigoUsuario = this.txtCodUsu.Text.Trim();
            Universal.gNombreUsuario = this.txtNomUsu.Text.Trim();
            Universal.gCodigoEmpresa = this.txtCodEmp.Text.Trim();
            Universal.gNombreEmpresa = this.txtNomEmp.Text.Trim();
            Universal.gCodigoPerfil = this.txtCodPer.Text.Trim();
            Universal.gNombrePerfil = this.txtNomPer.Text.Trim();
            Universal.gStrPermisosAlmacen = PermisoAlmacenRN.ObtenerStrPermisosAlmacen();
        }

        public void GrabarPersistencia()
        {               
            //guardando datos usuario
            Properties.Settings.Default.GuardarCheckUsuario = this.ckbUsu.Checked.ToString().ToLower();
            bool iValor = this.ckbUsu.Checked;
            Properties.Settings.Default.GuardarCodigoUsuario = Cadena.ObtenerValor(iValor, this.txtCodUsu.Text);
            Properties.Settings.Default.GuardarNombreUsuario = Cadena.ObtenerValor(iValor, this.txtNomUsu.Text);
            Properties.Settings.Default.GuardarCodigoPerfil = Cadena.ObtenerValor(iValor, this.txtCodPer.Text);
            Properties.Settings.Default.GuardarNombrePerfil = Cadena.ObtenerValor(iValor, this.txtNomPer.Text);

            //guardando datos clave
            Properties.Settings.Default.GuardarCheckClave = this.ckbCla.Checked.ToString().ToLower();
            iValor = this.ckbCla.Checked;
            Properties.Settings.Default.GuardarClaveUsuario = Cadena.ObtenerValor(iValor, this.txtCla.Text);
            
            //guardando datos empresa
            Properties.Settings.Default.GuardarCheckEmpresa = this.ckbEmp.Checked.ToString().ToLower();
            iValor = this.ckbEmp.Checked;
            Properties.Settings.Default.GuardarCodigoEmpresa = Cadena.ObtenerValor(iValor, this.txtCodEmp.Text);
            Properties.Settings.Default.GuardarNombreEmpresa = Cadena.ObtenerValor(iValor, this.txtNomEmp.Text);
            
            //guardar todos los datos
            Properties.Settings.Default.Save();
        }

        public void MostrarPersistencia()
        {
            this.txtNomUsu.Text = Properties.Settings.Default.GuardarNombreUsuario;
            this.txtCodUsu.Text = Properties.Settings.Default.GuardarCodigoUsuario;
            this.txtCodPer.Text = Properties.Settings.Default.GuardarCodigoPerfil;
            this.txtNomPer.Text = Properties.Settings.Default.GuardarNombrePerfil;
            this.txtCla.Text = Properties.Settings.Default.GuardarClaveUsuario;
            this.txtCodEmp.Text = Properties.Settings.Default.GuardarCodigoEmpresa;
            this.txtNomEmp.Text = Properties.Settings.Default.GuardarNombreEmpresa;
            this.ckbUsu.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckUsuario, false);
            this.ckbCla.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckClave, false);
            this.ckbEmp.Checked = Conversion.CadenaABoolean(Properties.Settings.Default.GuardarCheckEmpresa, false);
        }

        public void VentanaAlarmaStockMinimo()
        {
            //validar si este usuario tiene permiso para ver esta ventana
            if (this.wMen.IteAlertaStockMinimo.Enabled == false) { return; }

            //valida si hay existencias para alarma stock minimo
            ExistenciaEN iExiEN = ExistenciaRN.HayExistenciasParaAlarmaStockMinimo();
            if (iExiEN.Adicionales.EsVerdad == false) { return; }                    

            //instanciar ventana
            this.wMen.InstanciarAlertaStockMinimo();
        }

        public void Cancelar()
        { 
            //segun flag de invocacion de la ventana
            if (this.eFlagInvoca == 0)
            {
                Application.Exit();
            }
            else
            {
                //habilitamos el menu principal
                if (this.wMen.tbcContenedor.TabPages.Count != 0)
                {
                    this.wMen.tbcContenedor.Visible = true;
                    this.wMen.BackColor = Color.LightYellow;
                }      
                this.Close();
            }        
        }

        #endregion

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.AccesarSistema();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodUsu_Validating(object sender, CancelEventArgs e)
        {
            this.EsUsuarioValido();
        }

        private void txtCodUsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1){this.ListarUsuarios();}   
        }

        private void txtCodUsu_DoubleClick(object sender, EventArgs e)
        {
            this.ListarUsuarios();
        }

        private void txtCodEmp_Validating(object sender, CancelEventArgs e)
        {
            this.EsEmpresaDeUsuario();
        }

        private void txtCodEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarEmpresasDeUsuario(); }   
        }

        private void txtCodEmp_DoubleClick(object sender, EventArgs e)
        {
            this.ListarEmpresasDeUsuario();
        }



    }
}
