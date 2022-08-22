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

namespace Presentacion.Procesos
{
    public partial class wEditInventario : Heredados.MiForm8
    {
        public wEditInventario()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();

        #endregion
        
        #region Propietario

        public wInventario wInv;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCorInvCab,this.dtpFecInvCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecInvCab, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "InventarioCabe", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer, true, "Personal", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer, this.txtCodPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtObsInvCab, false, "Descripcion", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNEstProDet, this.dtpFecInvCab, "ffff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wInv.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            // Deshabilitar al propietario
            this.wInv.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarInventarioCabe(InventarioCabeRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecInvCab.Focus();
        }

        public void VentanaModificar(InventarioCabeEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarInventarioCabe(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecInvCab.Focus();
        }

        public void VentanaEliminar(InventarioCabeEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarInventarioCabe(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(InventarioCabeEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarInventarioCabe(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarInventarioCabe(InventarioCabeEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CorrelativoInventarioCabe = this.txtCorInvCab.Text.Trim();
            pObj.FechaInventarioCabe = this.dtpFecInvCab.Text;
            pObj.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pObj.CodigoPersonal = this.txtCodPer.Text.Trim();
            pObj.ObservacionInventarioCabe = this.txtObsInvCab.Text.Trim();         
            pObj.ClaveInventarioCabe = InventarioCabeRN.ObtenerClaveInventarioCabe(pObj);
        }

        public void MostrarInventarioCabe(InventarioCabeEN pObj)
        {
            this.txtCorInvCab.Text = pObj.CorrelativoInventarioCabe;
            this.dtpFecInvCab.Text = pObj.FechaInventarioCabe;
            this.txtCodAlm.Text = pObj.CodigoAlmacen;
            this.txtDesAlm.Text = pObj.DescripcionAlmacen;
            this.txtCodPer.Text = pObj.CodigoPersonal;
            this.txtNomPer.Text = pObj.NombrePersonal;
            this.txtObsInvCab.Text = pObj.ObservacionInventarioCabe;
            this.txtNEstProDet.Text = pObj.NEstadoInventarioCabe;
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
            if (Mensaje.DeseasRealizarOperacion(this.wInv.eTitulo) == false) { return; }

            //mostrar numero movimientoCabe
            this.MostrarNuevoCorrelativo();

            //adicionando el registro
            this.AdicionarInventarioCabe();

            //adicionar todas las existencias del almacen
            this.AdicionarInventarioDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Inventario se adiciono correctamente", this.wInv.eTitulo);

            //actualizar al propietario
            this.wInv.eClaveDgvInv = this.ObtenerClaveInventarioCabe();
            this.wInv.ActualizarVentana();

            //limpiar controles
            this.MostrarInventarioCabe(InventarioCabeRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCorInvCab.Focus();
        }

        public void MostrarNuevoCorrelativo()
        {
            //asignar parametros
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();
            iInvCabEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();

            //obtener el nuevo numero
            string iNuevoNumero = InventarioCabeRN.ObtenerNuevoCorrelativoInventarioCabeAutogenerado(iInvCabEN);

            //mostrar en pantalla
            this.txtCorInvCab.Text = iNuevoNumero;
        }

        public void AdicionarInventarioCabe()
        {
            InventarioCabeEN iPerEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iPerEN);
            InventarioCabeRN.AdicionarInventarioCabe(iPerEN);
        }

        public void AdicionarInventarioDeta()
        {
            //asignar parametros
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iInvCabEN);

            //ejecutar metodo
            InventarioDetaRN.AdicionarInventariosDetaParaInventarioCabe(iInvCabEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wInv.EsActoModificarInventarioCabe().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wInv.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarInventarioCabe();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Inventario se modifico correctamente", this.wInv.eTitulo);

            //actualizar al wUsu
            this.wInv.eClaveDgvInv = this.ObtenerClaveInventarioCabe();
            this.wInv.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarInventarioCabe()
        {
            InventarioCabeEN iPerEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iPerEN);
            iPerEN = InventarioCabeRN.BuscarInventarioCabeXClave(iPerEN);
            this.AsignarInventarioCabe(iPerEN);
            InventarioCabeRN.ModificarInventarioCabe(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wInv.EsActoEliminarInventarioCabe().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wInv.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarInventarioCabe();

            //eliminar inventarios deta
            this.EliminarInventarioDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Inventario se elimino correctamente", this.wInv.eTitulo);

            //actualizar al propietario           
            this.wInv.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarInventarioCabe()
        {
            InventarioCabeEN iPerEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iPerEN);
            InventarioCabeRN.EliminarInventarioCabe(iPerEN);
        }

        public void EliminarInventarioDeta()
        {
            InventarioDetaEN iPerEN = new InventarioDetaEN();
            iPerEN.ClaveInventarioCabe = this.ObtenerClaveInventarioCabe();
            InventarioDetaRN.EliminarInventarioDetaXClaveInventarioCabe(iPerEN);
        }

        public string ObtenerClaveInventarioCabe()
        {
            InventarioCabeEN iAlmEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iAlmEN);
            return iAlmEN.ClaveInventarioCabe;
        }

        public void ListarAlmacenes()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm;
            win.eCtrlFoco = this.txtCodPer;
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wInv.eTitulo);
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
            this.txtCodPer.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer.Text = iAlmEN.NombrePersonal;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
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
            win.eCtrlFoco = this.txtObsInvCab;
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
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wInv.eTitulo);
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
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wInv.eTitulo);
        }
        
        #endregion

        private void wEditInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wInv.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
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

        private void txtCodAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValido();
        }

        private void txtCodAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes(); }
        }

        private void txtCodAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes();
        }
    }
}
