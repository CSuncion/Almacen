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
    public partial class wImpDiferenciaStock : Heredados.MiForm8
    {
        public wImpDiferenciaStock()
        {
            InitializeComponent();
        }

        #region Atributos

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

        public List<InventarioDetaEN> ObtenerReporte()
        {
            //asignar parametros
            InventarioDetaEN iInvDetEN = new InventarioDetaEN();
            iInvDetEN.ClaveInventarioCabe = Dgv.ObtenerValorCelda(this.wInv.DgvInv, InventarioCabeEN.ClaObj);
            iInvDetEN.Adicionales.CampoOrden = InventarioDetaRN.HomologarItemOrden(this.cmbTipExi.Text);
            iInvDetEN.Adicionales.Desde1 = this.txtCodExiDes.Text.Trim();
            iInvDetEN.Adicionales.Hasta1 = this.txtCodExiHas.Text.Trim();

            //ejecutar metodo,segun opcion
            return InventarioDetaRN.ListarInventarioDetasParaDiferenciaStock(iInvDetEN);
        }
        
        public string ObtenerCodigosExistencia()
        {
            if (this.txtCodExiDes.Text.Trim() == string.Empty)
            {
                return "Todos";
            }
            else
            {
                return this.txtCodExiDes.Text + " --> " + this.txtCodExiHas.Text;
            }
        }

        public string ObtenerDescripcionAlmacen()
        {
            //armar
            string iTexto = Dgv.ObtenerValorCelda(this.wInv.DgvInv, InventarioCabeEN.CodAlm) + " : ";
            iTexto += Dgv.ObtenerValorCelda(this.wInv.DgvInv, InventarioCabeEN.DesAlm);

            //devolver
            return iTexto;
        }

        public void Imprimir()
        {
            //-----------------
            //imprimir cabecera
            //-----------------          
            TextObject txtObjEmp = (TextObject)(this.CrDiferenciaStock1.Section2.ReportObjects["txtObjEmp"]);
            txtObjEmp.Text = Universal.gNombreEmpresa;

            TextObject txtObjAlm = (TextObject)(this.CrDiferenciaStock1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = this.ObtenerDescripcionAlmacen();

            //----------------
            //imprimir detalle
            //----------------

            //creamos el dataset para cargar los datos del detalle
            Impresion iDs = new Impresion();

            //traemos el reporte a mostrar en el detalle
            List<InventarioDetaEN> iLisRep = this.ObtenerReporte();

            //pasamos los objetos de la lista  a la tabla del reporte
            foreach (InventarioDetaEN xObj in iLisRep)
            {
                //creamos un nuevo registro
                Impresion.InventarioDetaRow iRow;
                iRow = iDs.InventarioDeta.NewInventarioDetaRow();

                //pasamos datos
                iRow.CodigoExistencia = xObj.CodigoExistencia;
                iRow.DescripcionExistencia = xObj.DescripcionExistencia;
                iRow.CodigoUnidadMedida = xObj.CodigoUnidadMedida;                
                iRow.UbicacionExistencia = xObj.UbicacionExistencia;
                iRow.StockFisico = xObj.StockFisico;
                iRow.StockTeorico = xObj.StockTeorico;
                iRow.DiferenciaStock = xObj.DiferenciaStock;             
                                               
                //insertamos en la tabla del dataset
                iDs.InventarioDeta.Rows.Add(iRow);
            }

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.CrDiferenciaStock1.SetDataSource(iDs);
            this.crv1.ReportSource = this.CrDiferenciaStock1;
        }

        public void Ejecutar()
        {
            //validar campos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //Imprime si todo esta ok
            this.Imprimir();
        }


        #endregion

        private void wImpDiferenciaStock_FormClosing(object sender, FormClosingEventArgs e)
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


    }
}
