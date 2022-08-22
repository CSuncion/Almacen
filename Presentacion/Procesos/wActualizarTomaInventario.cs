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
using Presentacion.Principal;
using CrystalDecisions.CrystalReports.Engine;
using Presentacion.Impresiones;
using Entidades.Estructuras;
using Presentacion.Listas;
using Presentacion.Procesos;

namespace Presentacion.Impresiones
{
    public partial class wActualizarTomaInventario : Heredados.MiForm8
    {
        public wActualizarTomaInventario()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        //public List<InventarioDetaEN> eLisInvDet = new List<InventarioDetaEN>();
        public string eClaveDgvMovDet = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;

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
            xCtrl.TxtTodo(this.txtCodExiDes, true, "Codigo existencia desde", "vfff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExiHas, true, "Codigo existencia hasta", "vfff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTipExi, "vvff");
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

            //cargar combos         
            this.CargarOrden();

            //deshabilitar al propietario de esta ventana
            this.wInv.Enabled = false;

            //mostrar
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.ckbCodExi.Checked = true;
            this.MostrarInventariosDeta();
            this.txtCodExiDes.Focus();
        }

        public void CargarOrden()
        {
            //asignar parametros
            List<string> iLisItems = InventarioDetaRN.ListarItemsOrden();

            //ejecutar metodo
            Cmb.CargarListaDeCadenas(this.cmbTipExi, iLisItems);            
        }

        public void CambiarCkbCodExi()
        {
            Txt.HabilitarParaFiltro(this.txtCodExiDes, this.txtCodExiHas, this.ckbCodExi.Checked);            
        }

        public void MostrarInventariosDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<InventarioDetaEN> iFuenteDatos = this.LLenarInventarioDetaDeBaseDatos();
            Dgv.Franja iCondicionFranja = eFranjaDgvMovDet;
            string iClaveBusqueda = eClaveDgvMovDet;
            string iColumnaPintura = InventarioDetaEN.StoFis;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda,iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioDetaEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioDetaEN.DesExi, "Descripcion", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioDetaEN.CodUniMed, "Uni.Med", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioDetaEN.UbiExi, "Ubicacion", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumericoEditable(InventarioDetaEN.StoFis, "Cantidad", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public List<InventarioDetaEN> LLenarInventarioDetaDeBaseDatos()
        {
            //asignar parametros
            InventarioDetaEN iInvDetEN = new InventarioDetaEN();
            iInvDetEN.ClaveInventarioCabe = Dgv.ObtenerValorCelda(this.wInv.DgvInv, InventarioCabeEN.ClaObj);
            iInvDetEN.Adicionales.CampoOrden = InventarioDetaRN.HomologarItemOrden(this.cmbTipExi.Text);
            iInvDetEN.Adicionales.Desde1 = this.txtCodExiDes.Text.Trim();
            iInvDetEN.Adicionales.Hasta1 = this.txtCodExiHas.Text.Trim();

            //ejecutar metodo,segun opcion
            return InventarioDetaRN.ListarInventarioDetasParaTomaInventario(iInvDetEN);
        }

        public void Ejecutar()
        {
            //validar campos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //actualizar grilla
            this.MostrarInventariosDeta();
          
        }

        public void ModificarInventarioDetaDigitado()
        {
            //asignar parametro
            InventarioDetaEN iInvDetEN = new InventarioDetaEN();
            iInvDetEN.ClaveInventarioDeta = Dgv.ObtenerValorCelda(this.dgvMovDet, InventarioDetaEN.ClaObj);
            iInvDetEN.StockFisico = Conversion.ADecimal(Dgv.ObtenerValorCelda(this.dgvMovDet, InventarioDetaEN.StoFis), 0);

            //ejecutar metodo
            InventarioDetaRN.ModificarStockFisicoInventarioDeta(iInvDetEN);
        }

        public void ValidarFormatoDecimal(DataGridViewCellValidatingEventArgs pE)
        {
            //asignar parametros
            int iIndiceColumna = this.dgvMovDet.Columns[InventarioDetaEN.StoFis].Index;
            string iEncabezadoColumna = "Cantidad";
            DataGridViewCellValidatingEventArgs iE = pE;

            //ejecutar metodo
            ValidarCeldaDgv.vNumerosDecimalesPositivos(iIndiceColumna, iEncabezadoColumna, iE);          
        }

        #endregion

        private void wActualizarTomaInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wInv.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Ejecutar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbCodExi_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCodExi();
        }

        private void dgvMovDet_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvMovDet.BeginEdit(true);
        }

        private void dgvMovDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.EditarEnCeldaDeFilaSeleccionada(this.dgvMovDet, InventarioDetaEN.StoFis);
        }

        private void dgvMovDet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {           
            this.ModificarInventarioDetaDigitado();
        }

        private void dgvMovDet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            this.ValidarFormatoDecimal(e);
        }
    }
}
