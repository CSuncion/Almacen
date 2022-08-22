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


namespace Presentacion.Maestros
{
    public partial class wEditTablaGeneral : Heredados.MiForm8
    {
        public wEditTablaGeneral()
        {
            InitializeComponent();
        }

        //variables
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Registro";

        #region Propietario

        public wTablasGeneral wTabGen;

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
            this.wTabGen.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void ValoresXDefecto()
        {
            this.txtNomTab.Text = Dgv.ObtenerValorCelda(this.wTabGen.DgvTab, TablaEN.NomTab);
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarItemG(ItemGRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodIte.Focus();
        }

        public void VentanaModificar(ItemGEN pObj)
        {
            this.InicializaVentana();           
            this.MostrarItemG(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomIte.Focus();
        }

        public void VentanaEliminar(ItemGEN pObj)
        {
            this.InicializaVentana();           
            this.MostrarItemG(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(ItemGEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarItemG(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }
        
        public void CargarEstadosItem()
        {
            Cmb.Cargar(this.cmbEstIte, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarItemG(ItemGEN pObj)
        {
            pObj.CodigoTabla = Dgv.ObtenerValorCelda(this.wTabGen.DgvTab, TablaEN.ClaObj);
            pObj.CodigoItemG = this.txtCodIte.Text.Trim();
            pObj.NombreItemG = this.txtNomIte.Text.Trim();            
            pObj.AbreviaItemG = this.txtAbrIte.Text.Trim();
            pObj.CEstadoItemG = this.cmbEstIte.SelectedValue.ToString();
            pObj.ClaveItemG = ItemGRN.ObtenerClaveItemG(pObj);
        }

        public void MostrarItemG(ItemGEN pObj)
        {
            this.txtCodIte.Text = pObj.CodigoItemG;
            this.txtNomIte.Text = pObj.NombreItemG;            
            this.txtAbrIte.Text = pObj.AbreviaItemG;            
            this.cmbEstIte.SelectedValue = pObj.CEstadoItemG;            
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
            if (this.EsCodigoItemGDisponible(true) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarItemG();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego el Item correctamente", "Item");
                     
            //actualizar al wUsu
            this.wTabGen.eClaveDgvIte = Dgv.ObtenerValorCelda(this.wTabGen.DgvTab, TablaEN.ClaObj) +"-" + this.txtCodIte.Text.Trim();
            this.wTabGen.ActualizarVentana();

            //limpiar controles
            this.MostrarItemG(ItemGRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodIte.Focus();
        }
        
        public void AdicionarItemG()
        {
            ItemGEN iIteEN = new ItemGEN();
            this.AsignarItemG(iIteEN);
            ItemGRN.AdicionarItemG(iIteEN);
        }
                
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTabGen.EsItemGExistente().Adicionales.EsVerdad == false) { return; }
            
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarItemG();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico el Item correctamente", "Item");

            //actualizar al propietario
            this.wTabGen.eClaveDgvIte = Dgv.ObtenerValorCelda(this.wTabGen.DgvIte, ItemGEN.ClaObj);
            this.wTabGen.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarItemG()
        {
            ItemGEN iIteEN = new ItemGEN();
            this.AsignarItemG(iIteEN);
            iIteEN = ItemGRN.buscarItemGXClave(iIteEN);
            this.AsignarItemG(iIteEN);
            ItemGRN.ModificarItemG(iIteEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTabGen.EsItemGExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarItemG();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el Item correctamente", "Item");

            //actualizar al propietario           
            this.wTabGen.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarItemG()
        {
            ItemGEN iIteEN = new ItemGEN();
            this.AsignarItemG(iIteEN);
            ItemGRN.EliminarItemG(iIteEN);
        }

        public bool EsCodigoItemGDisponible(bool pVacio)
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            ItemGEN iIteEN = new ItemGEN();
            this.AsignarItemG(iIteEN);
            iIteEN = ItemGRN.EsCodigoItemGDisponible(iIteEN, pVacio);
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
            if (this.eOperacion == Universal.Opera.Visualizar || this.eOperacion == Universal.Opera.Eliminar)
            {
                this.Close();
                return;
            }
            //solo para adicionar y modificar
            if (eMas.SonTextosIguales() == false)
            {
                if (Mensaje.DeseasCancelarOperacion(this.eTitulo) == false)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        
        #endregion

        private void wEditTablaGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wTabGen.Enabled = true;           
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
            this.EsCodigoItemGDisponible(false);
        }

        
    }
}
