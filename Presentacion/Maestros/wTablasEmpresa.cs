using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heredados;
using WinControles;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Comun;
using Entidades;
using Negocio;
using Presentacion.Principal;
using System.Collections;

namespace Presentacion.Maestros
{
    public partial class wTablasEmpresa : Heredados.MiForm8
    {
        public wTablasEmpresa()
        {
            InitializeComponent();
        }

        #region Variables

        string eNombreColumna = ItemEEN.CodIteE;
        string eEncabezadoColumna = "Codigo";
        public string eClaveDgvIte = string.Empty;
        Dgv.Franja eFranja = Dgv.Franja.PorIndice;
        int eIndiceFilaAnterior = 0;

        #endregion
        
        #region General
        
        public void NuevaVentana()
        {
            this.Show();        
            this.ActualizarDgvTab();
            this.ActualizarVentana();          
        }

        public void ActualizarDgvTab()
        {          
            TablaEN iTabEN = new TablaEN();
            iTabEN.CategoriaTabla = "E";//tablas empresa
            iTabEN.Adicionales.CampoOrden = TablaEN.NomTab;

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvTab;
            iDgv.RefrescarDatosGrilla(TablaRN.ListarTablasXCategoria(iTabEN));
            //asignar columnas
            iDgv.AsignarColumnaTextCadena(TablaEN.NomTab, "Nombre", 380);
            iDgv.AsignarColumnaTextCadena(TablaEN.ClaObj, "Clave", 90, false);
        }

        public void TituloItems()
        {
            this.lblTitIte.Text = "Registros de la tabla : " + Dgv.ObtenerValorCelda(this.DgvTab, TablaEN.NomTab);
        }

        public void ActualizarVentana()
        {
            this.TituloItems();
            this.ActualizarDgvIte();            
            this.HabilitarAcciones();        
        }

        public void ActualizarDgvIte()
        {
            eIndiceFilaAnterior = Dgv.ObtenerIndiceRegistroXFranja(this.DgvIte);
            this.ActualizarDatosDgvIte();
            Dgv.PintarColumna(this.DgvIte, eNombreColumna);
            Dgv.PosicionarFranja(this.DgvIte, eFranja, eIndiceFilaAnterior, eClaveDgvIte);
        }

        public void ActualizarDatosDgvIte()
        {
            ItemEEN iIteEN = new ItemEEN();
            iIteEN.CodigoTabla = Dgv.ObtenerValorCelda(this.DgvTab, ItemEEN.ClaObj);
            iIteEN.Adicionales.CampoOrden = eNombreColumna;

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvIte;
            iDgv.RefrescarDatosGrilla(ItemERN.ListarItemsGXTabla(iIteEN));

            //asignar columnas
            iDgv.AsignarColumnaTextCadena(ItemEEN.CodIteE, "Codigo", 70);
            iDgv.AsignarColumnaTextCadena(ItemEEN.NomIteE, "Nombre", 310);           
            iDgv.AsignarColumnaTextCadena(ItemEEN.ClaObj, "Clave", 90, false);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("035", DgvIte.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iLisPer);
        }
        
        public void AsignarItemE(ItemEEN pObj)
        {
            pObj.ClaveItemE = Dgv.ObtenerValorCelda(this.DgvIte, ItemEEN.ClaObj);
        }
        
        public void AccionAdicionar()
        {
            wEditTablaEmpresa win = new wEditTablaEmpresa();
            win.wTabEmp = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            ItemEEN iIteEN = this.EsItemEExistente();
            if (iIteEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTablaEmpresa win = new wEditTablaEmpresa();
            win.wTabEmp = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iIteEN);            
        }

        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            if (tsbModificar.Enabled == false)
            {
                Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            }
            else
            {
                this.AccionModificar();
            }
        }

        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            ItemEEN iIteEN = this.EsItemEExistente();
            if (iIteEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTablaEmpresa win = new wEditTablaEmpresa();
            win.wTabEmp = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranja = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iIteEN);    
        }
              
        public ItemEEN EsItemEExistente()
        {
            ItemEEN iIteEN = new ItemEEN();
            this.AsignarItemE(iIteEN);
            iIteEN = ItemERN.EsItemEExistente(iIteEN);
            if (iIteEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIteEN.Adicionales.Mensaje, "ItemE");
            }
            return iIteEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteTablasEmpresa, null);               
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranja = Dgv.Franja.PorIndice;
            this.eNombreColumna = this.DgvIte.Columns[pColumna].Name;
            this.eEncabezadoColumna = this.DgvIte.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }
       
        #endregion


     
        private void wTablasEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
            
        private void DgvIte_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.ActualizarVentana();            
        }
        
        private void DgvIte_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
     
       
    }
}
