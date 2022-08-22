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
using System.IO;
using Entidades;
using System.Drawing.Drawing2D;
using Presentacion.FuncionesGenericas;

namespace Presentacion.Sistema
{
    public partial class wEditEmpresa : Heredados.MiForm8
    {
        public wEditEmpresa()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Empresa";

        #endregion
        
        #region Propietario

        public wEmpresa wEmp;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodEmp, true, "Codigo", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomEmp, true, "Nombre", "vvff",100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtRucEmp, true, "Ruc", "vvff",11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstEmp, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDirEmp, false, "Direccion", "vvff",100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCorEmp, false, "Correo", "vvff",50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConEspacion(this.txtTelFijEmp, false, "Tel Fijo", "vvff",10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConEspacion(this.txtTelCelEmp, false, "Tel Celular", "vvff",10);
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
            this.CargarEstadosEmpresa();
            
            //Deshabilitar al propietario de esta ventana
            this.wEmp.Enabled = false;

            //mostrar ventana
            this.Show();
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarEmpresa(EmpresaRN.EnBlanco());         
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodEmp.Focus();
        }

        public void VentanaModificar(EmpresaEN pEmp)
        {
            this.InicializaVentana();          
            this.MostrarEmpresa(pEmp);      
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomEmp.Focus();
        }

        public void VentanaEliminar(EmpresaEN pEmp)
        {
            this.InicializaVentana();           
            this.MostrarEmpresa(pEmp);        
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(EmpresaEN pEmp)
        {
            this.InicializaVentana();           
            this.MostrarEmpresa(pEmp);          
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        
        public void CargarEstadosEmpresa()
        {          
            Cmb.Cargar(this.cmbEstEmp, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarEmpresa(EmpresaEN pEmp)
        {
            pEmp.CodigoEmpresa = this.txtCodEmp.Text.Trim();
            pEmp.NombreEmpresa = this.txtNomEmp.Text.Trim();
            pEmp.CEstadoEmpresa = Cmb.ObtenerValor(this.cmbEstEmp, string.Empty);            
            pEmp.RucEmpresa = this.txtRucEmp.Text.Trim();
            pEmp.DireccionEmpresa = this.txtDirEmp.Text.Trim();
            pEmp.CorreoEmpresa = this.txtCorEmp.Text.Trim();
            pEmp.TelFijoEmpresa = this.txtTelFijEmp.Text.Trim();
            pEmp.TelCelularEmpresa = this.txtTelCelEmp.Text.Trim();         
        }

        public void MostrarEmpresa(EmpresaEN pEmp)
        {
            this.txtCodEmp.Text = pEmp.CodigoEmpresa;
            this.txtNomEmp.Text = pEmp.NombreEmpresa;
            this.cmbEstEmp.SelectedValue = pEmp.CEstadoEmpresa;
            this.txtRucEmp.Text = pEmp.RucEmpresa;
            this.txtDirEmp.Text = pEmp.DireccionEmpresa;            
            this.txtCorEmp.Text = pEmp.CorreoEmpresa;
            this.txtTelFijEmp.Text = pEmp.TelFijoEmpresa;
            this.txtTelCelEmp.Text = pEmp.TelCelularEmpresa;        
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

            //el codigo es disponible?
            if (this.EsCodigoEmpresaDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarEmpresa();

            //generar los permisos empresa para esta empresa
            this.GenerarPermisosEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " adicionada correctamente", this.eTitulo);

            //actualizar al propietario
            this.wEmp.eClaveDgvEmp = this.txtCodEmp.Text.Trim();
            this.wEmp.ActualizarVentana();

            //limpiar controles
            this.MostrarEmpresa(EmpresaRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodEmp.Focus();
        }
        
        public void AdicionarEmpresa()
        {          
            EmpresaEN iEmpEN = new EmpresaEN();
            this.AsignarEmpresa(iEmpEN);
            EmpresaRN.AdicionarEmpresa(iEmpEN);
        }

        public void GenerarPermisosEmpresa()
        {          
            PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
            iPemEN.CodigoEmpresa = this.txtCodEmp.Text.Trim();
            PermisoEmpresaRN.AdicionarPermisosEmpresaXEmpresa(iPemEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.EsActoModificarEmpresa() == false) { return; }                       

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " modificada correctamente", this.eTitulo);

            //actualizar al propietario
            this.wEmp.eClaveDgvEmp = this.txtCodEmp.Text.Trim();
            this.wEmp.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarEmpresa()
        {           
            EmpresaEN iEmpEN = new EmpresaEN();
            this.AsignarEmpresa(iEmpEN);
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);
            this.AsignarEmpresa(iEmpEN);
            EmpresaRN.ModificarEmpresa(iEmpEN);
        }
        
        public void Eliminar()
        {                        
            //es acto eliminar esta empresa
            if (this.wEmp.EsActoEliminarEmpresa().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarEmpresa();  
            
            //eliminar los permisos empresa de esta empresa
            this.EliminarPermisosEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eTitulo + " eliminada correctamente", this.eTitulo);

            //actualizar al wUsu           
            this.wEmp.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarEmpresa()
        {          
            EmpresaEN iEmpEN = new EmpresaEN();
            this.AsignarEmpresa(iEmpEN);
            EmpresaRN.EliminarEmpresa(iEmpEN);
        }

        public void EliminarPermisosEmpresa()
        {          
            PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
            iPemEN.CodigoEmpresa = this.txtCodEmp.Text.Trim();
            PermisoEmpresaRN.EliminarPermisosEmpresaXEmpresa(iPemEN);
        }

        public bool EsCodigoEmpresaDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }
                   
            //validar
            EmpresaEN iEmpEN = new EmpresaEN();
            this.AsignarEmpresa(iEmpEN);
            iEmpEN = EmpresaRN.EsCodigoEmpresaDisponible(iEmpEN);
            if (iEmpEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, this.eTitulo);
                this.txtCodEmp.Clear();
                this.txtCodEmp.Focus();
            }
            return iEmpEN.Adicionales.EsVerdad;
        }
        
        public bool EsActoModificarEmpresa()
        {            
            //validar
            EmpresaEN iEmpEN = new EmpresaEN();
            this.AsignarEmpresa(iEmpEN);
            iEmpEN = EmpresaRN.EsActoModificarEmpresa(iEmpEN);
            if (iEmpEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iEmpEN.Adicionales.Mensaje, this.eTitulo);
                this.cmbEstEmp.Focus();
            }
            return iEmpEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }

        #endregion

        private void wEditEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEmp.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodEmp_Validated(object sender, EventArgs e)
        {
            this.EsCodigoEmpresaDisponible();
        }
   
       
    }
}
