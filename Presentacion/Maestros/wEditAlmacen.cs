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
using Presentacion.Listas;

namespace Presentacion.Maestros
{
    public partial class wEditAlmacen : Heredados.MiForm8
    {
        public wEditAlmacen()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion
        
        #region Propietario

        public wAlmacen wAlm;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtLetrasYNumerosSinEspacion(this.txtCodAlm, true, "Codigo", "vfff",3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesAlm, true, "Descripcion", "vvff",100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDirAlm, true, "Direccion", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer, true, "Personal", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer, this.txtCodPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstAlm, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wAlm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos        
            this.CargarEstadosAlmacen();

            // Deshabilitar al propietario
            this.wAlm.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarAlmacen(AlmacenRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodAlm.Focus();
        }

        public void VentanaModificar(AlmacenEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarAlmacen(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDesAlm.Focus();
        }

        public void VentanaEliminar(AlmacenEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarAlmacen(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(AlmacenEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarAlmacen(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void CargarEstadosAlmacen()
        {
            Cmb.Cargar(this.cmbEstAlm, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarAlmacen(AlmacenEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pObj.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            pObj.DireccionAlmacen = this.txtDirAlm.Text.Trim();
            pObj.CodigoPersonal = this.txtCodPer.Text.Trim();
            pObj.CEstadoAlmacen = Cmb.ObtenerValor(this.cmbEstAlm, string.Empty);
            pObj.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(pObj);
        }

        public void MostrarAlmacen(AlmacenEN pObj)
        {
            this.txtCodAlm.Text = pObj.CodigoAlmacen;
            this.txtDesAlm.Text = pObj.DescripcionAlmacen;
            this.txtDirAlm.Text = pObj.DireccionAlmacen;
            this.txtCodPer.Text = pObj.CodigoPersonal;
            this.txtNomPer.Text = pObj.NombrePersonal;
            this.cmbEstAlm.SelectedValue = pObj.CEstadoAlmacen;
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
            if (this.EsCodigoAlmacenDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAlm.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarAlmacen();

            //genera permisos almacen
            this.GenerarPermisosAlmacen();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Almacen se adiciono correctamente", this.wAlm.eTitulo);

            //actualizar al propietario
            this.wAlm.eClaveDgvAlm = this.ObtenerClaveAlmacen();
            this.wAlm.ActualizarVentana();

            //limpiar controles
            this.MostrarAlmacen(AlmacenRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodAlm.Focus();
        }
        
        public void AdicionarAlmacen()
        {
            AlmacenEN iPerEN = new AlmacenEN();
            this.AsignarAlmacen(iPerEN);
            AlmacenRN.AdicionarAlmacen(iPerEN);
        }

        public void GenerarPermisosAlmacen()
        {
            //asignar parameros
            AlmacenEN iPlaEN = new AlmacenEN();
            this.AsignarAlmacen(iPlaEN);

            //ejecutar metodo
            PermisoAlmacenRN.AdicionarPermisosAlmacenXAlmacen(iPlaEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAlm.EsActoModificarAlmacen().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAlm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarAlmacen();
           
            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Almacen se modifico correctamente", this.wAlm.eTitulo);

            //actualizar al wUsu
            this.wAlm.eClaveDgvAlm = this.ObtenerClaveAlmacen();
            this.wAlm.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarAlmacen()
        {
            AlmacenEN iPerEN = new AlmacenEN();
            this.AsignarAlmacen(iPerEN);
            iPerEN = AlmacenRN.BuscarAlmacenXClave(iPerEN);
            this.AsignarAlmacen(iPerEN);
            AlmacenRN.ModificarAlmacen(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wAlm.EsActoEliminarAlmacen().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wAlm.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarAlmacen();

            //eliminar permisos Almacen
            this.EliminarPermisosAlmacen();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Almacen se elimino correctamente", this.wAlm.eTitulo);

            //actualizar al propietario           
            this.wAlm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarAlmacen()
        {
            AlmacenEN iPerEN = new AlmacenEN();
            this.AsignarAlmacen(iPerEN);
            AlmacenRN.EliminarAlmacen(iPerEN);
        }

        public void EliminarPermisosAlmacen()
        {
            //asignar parametros
            string iCodigoAlmacen = this.txtCodAlm.Text.Trim();

            //ejecutar metodo
            PermisoAlmacenRN.EliminarPermisoAlmacenXAlmacen(iCodigoAlmacen);
        }

        public bool EsCodigoAlmacenDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            AlmacenEN iPerEN = new AlmacenEN();
            this.AsignarAlmacen(iPerEN);
            iPerEN = AlmacenRN.EsCodigoAlmacenDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wAlm.eTitulo);
                this.txtCodAlm.Clear();
                this.txtCodAlm.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }
             
        public string ObtenerClaveAlmacen()
        {
            AlmacenEN iAlmEN = new AlmacenEN();
            this.AsignarAlmacen(iAlmEN);
            return iAlmEN.ClaveAlmacen;
        }

        public void ListarPersonales()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer.ReadOnly == true) { return; }

            //instanciar
            wLisPer win = new wLisPer();
            win.eVentana = this;
            win.eTituloVentana = "Personales";
            win.eCtrlValor = this.txtCodPer;
            win.eCtrlFoco = this.cmbEstAlm;
            win.eCondicionLista = Listas.wLisPer.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodPer.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            Entidades.PersonalEN iPerEN = new Entidades.PersonalEN();
            iPerEN.CodigoPersonal = this.txtCodPer.Text.Trim();
            iPerEN = PersonalRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wAlm.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPer.Text = iPerEN.CodigoPersonal;
            this.txtNomPer.Text = iPerEN.NombrePersonal;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wAlm.eTitulo);
        }
        
        #endregion

        private void wEditAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wAlm.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodAlm_Validated(object sender, EventArgs e)
        {
            this.EsCodigoAlmacenDisponible();
        }

        private void txtCodPer_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalValido();
        }

        private void txtCodPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonales(); }
        }

        private void txtCodPer_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonales();
        }



    }
}
