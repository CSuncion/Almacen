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
    public partial class wEditTablaEmpresa : Heredados.MiForm8
    {
        public wEditTablaEmpresa()
        {
            InitializeComponent();
        }

        #region Variables

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Registro";

        #endregion
        
        #region Propietario

        public wTablasEmpresa wTabEmp;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodIte, true, "Codigo", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomIte, true, "Nombre", "vvff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtAbrIte, false, "Abrevia", "vvff");
            xLis.Add(xCtrl);
                        
            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstIte, "vvff");
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
         
            //valores x defecto
            this.ValoresXDefecto();

            //llenar combos            
            this.CargarEstadosItem();

            //Deshabilitar al propietario de esta ventana
            this.wTabEmp.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void ValoresXDefecto()
        {
            this.txtNomTab.Text = Dgv.ObtenerValorCelda(this.wTabEmp.DgvTab, TablaEN.NomTab);
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarItemE(ItemERN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodIte.Focus();
        }

        public void VentanaModificar(ItemEEN pObj)
        {
            this.InicializaVentana();           
            this.MostrarItemE(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomIte.Focus();
        }

        public void VentanaEliminar(ItemEEN pObj)
        {
            this.InicializaVentana();           
            this.MostrarItemE(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(ItemEEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarItemE(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        
        public void CargarEstadosItem()
        {
            Cmb.Cargar(this.cmbEstIte, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarItemE(ItemEEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoTabla = Dgv.ObtenerValorCelda(this.wTabEmp.DgvTab, TablaEN.ClaObj);
            pObj.CodigoItemE = this.txtCodIte.Text.Trim();
            pObj.NombreItemE = this.txtNomIte.Text.Trim();            
            pObj.AbreviaItemE = this.txtAbrIte.Text.Trim();
            pObj.CEstadoItemE = this.cmbEstIte.SelectedValue.ToString();
            pObj.ClaveItemE = ItemERN.ObtenerClaveItemE(pObj);
        }

        public void MostrarItemE(ItemEEN pObj)
        {
            this.txtCodIte.Text = pObj.CodigoItemE;
            this.txtNomIte.Text = pObj.NombreItemE;            
            this.txtAbrIte.Text = pObj.AbreviaItemE;            
            this.cmbEstIte.SelectedValue = pObj.CEstadoItemE;            
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
            if (this.EsCodigoItemEDisponible() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarItemE();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego el Item correctamente", "Item");

            //actualizar al wUsu
            this.wTabEmp.eClaveDgvIte = this.ObtenerClaveItemE();
            this.wTabEmp.ActualizarVentana();

            //limpiar controles
            this.MostrarItemE(ItemERN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodIte.Focus();
        }

        public string ObtenerClaveItemE()
        {
            //asignar parametros
            ItemEEN iIteEN = new ItemEEN();
            this.AsignarItemE(iIteEN);

            //sacar valor
            return iIteEN.ClaveItemE;
        }

        public void AdicionarItemE()
        {
            ItemEEN iIteEN = new ItemEEN();
            this.AsignarItemE(iIteEN);
            ItemERN.AdicionarItemE(iIteEN);
        }
                
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTabEmp.EsItemEExistente().Adicionales.EsVerdad == false) { return; }
            
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarItemE();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico el Item correctamente", "Item");

            //actualizar al propietario
            this.wTabEmp.eClaveDgvIte = this.ObtenerClaveItemE();
            this.wTabEmp.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarItemE()
        {
            ItemEEN iIteEN = new ItemEEN();
            this.AsignarItemE(iIteEN);
            iIteEN = ItemERN.buscarItemEXClave(iIteEN);
            this.AsignarItemE(iIteEN);
            ItemERN.ModificarItemE(iIteEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTabEmp.EsItemEExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarItemE();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el Item correctamente", "Item");

            //actualizar al propietario           
            this.wTabEmp.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarItemE()
        {
            ItemEEN iIteEN = new ItemEEN();
            this.AsignarItemE(iIteEN);
            ItemERN.EliminarItemE(iIteEN);
        }

        public bool EsCodigoItemEDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            ItemEEN iIteEN = new ItemEEN();
            this.AsignarItemE(iIteEN);
            iIteEN = ItemERN.EsCodigoItemEDisponible(iIteEN);
            if (iIteEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIteEN.Adicionales.Mensaje, "Registro");
                this.txtCodIte.Clear();
                this.txtCodIte.Focus();
            }
            return iIteEN.Adicionales.EsVerdad;
        }          
        
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.txtNomTab.Text);
        }
        
        #endregion

        private void wEditTablaEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wTabEmp.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodIte_Validated(object sender, EventArgs e)
        {
            this.EsCodigoItemEDisponible();
        }

        
    }
}
