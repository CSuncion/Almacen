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

namespace Presentacion.Impresiones
{
    public partial class wImpStockFisicoProgramado : Heredados.MiForm8
    {
        public wImpStockFisicoProgramado()
        {
            InitializeComponent();
        }

        //atributos      
        Masivo eMas = new Masivo();

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExiDes, true, "Codigo existencia desde", "vfff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExiHas, true, "Codigo existencia hasta", "vfff", 20);
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

            //mostrar ventana
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.txtCodAlm.Focus();
        }

        public void CambiarCkbAlm()
        {
            Txt.HabilitarParaFiltro1(this.txtCodAlm, this.txtDesAlm, this.ckbAlm.Checked);
        }

        public void CambiarCkbCodExi()
        {
            Txt.HabilitarParaFiltro(this.txtCodExiDes, this.txtCodExiHas, this.ckbCodExi.Checked);
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
            win.eCtrlFoco = this.txtCodExiDes;
            win.eCondicionLista = Listas.wLisAlm.Condicion.Almacenes;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el codigo almacen
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, "Almacen");
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public List<dynamic> ObtenerReporte()
        {
            //asignar parametros            
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iExiEN.Adicionales.Desde1 = this.txtCodExiDes.Text.Trim();
            iExiEN.Adicionales.Hasta1 = this.txtCodExiHas.Text.Trim();

            //ejecutar metodo
            return ExistenciaRN.ObtenerReporteExistenciaStockFisicoProgramado(iExiEN);
        }

        public string ObtenerTxtObjAlm()
        {
            //asignar parametros
            string iTexto1 = this.txtCodAlm.Text;
            string iTexto2 = this.txtDesAlm.Text;
            string iTextoSustituto = this.ckbAlm.Text;
            string iSeparador = ":";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iTextoSustituto, iSeparador);
        }

        public string ObtenerTxtObjCodExi()
        {
            //asignar parametros
            string iTexto1 = this.txtCodExiDes.Text;
            string iTexto2 = this.txtCodExiHas.Text;
            string iTextoSustituto = this.ckbCodExi.Text;
            string iSeparador = "-->";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iTextoSustituto, iSeparador);
        }

        public void Imprimir()
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            TextObject txtObjEmp = (TextObject)(this.crStockFisicoProgramado1.Section2.ReportObjects["txtObjEmp"]);
            txtObjEmp.Text = Universal.gNombreEmpresa;

            TextObject txtObjAlm = (TextObject)(this.crStockFisicoProgramado1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = this.ObtenerTxtObjAlm();

            TextObject txtObjCodExi = (TextObject)(this.crStockFisicoProgramado1.Section2.ReportObjects["txtObjCodExi"]);
            txtObjCodExi.Text = this.ObtenerTxtObjCodExi();

            //----------------
            //imprimir detalle
            //----------------

            //creamos el dataset para cargar los datos del detalle
            Impresion iDs = new Impresion();

            //traemos el reporte a mostrar en el detalle
            List<dynamic> iLisRep = this.ObtenerReporte();

            //pasamos los objetos de la lista  a la tabla del reporte
            foreach (dynamic xObj in iLisRep)
            {
                //creamos un nuevo registro
                Impresion.StockFisicoProgramadoRow iRow;
                iRow = iDs.StockFisicoProgramado.NewStockFisicoProgramadoRow();

                //pasamos datos
                iRow.CodigoExistencia = xObj.GetType().GetProperty("CodigoExistencia").GetValue(xObj);
                iRow.DescripcionExistencia = xObj.GetType().GetProperty("DescripcionExistencia").GetValue(xObj);
                iRow.NombreUnidadMedida = xObj.GetType().GetProperty("NombreUnidadMedida").GetValue(xObj);
                iRow.StockActualExistencia = xObj.GetType().GetProperty("StockActualExistencia").GetValue(xObj); 
                iRow.CantidadSolicitudPedidoDeta = xObj.GetType().GetProperty("CantidadSolicitudPedidoDeta").GetValue(xObj); 
                iRow.CantidadPendiente = xObj.GetType().GetProperty("CantidadPendiente").GetValue(xObj); 
                iRow.StockTotal = xObj.GetType().GetProperty("StockTotal").GetValue(xObj);
                iDs.StockFisicoProgramado.Rows.Add(iRow);

            }

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.crStockFisicoProgramado1.SetDataSource(iDs);
            this.crv1.ReportSource = this.crStockFisicoProgramado1;
        }

        public void Ejecutar()
        {
            //validar campos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //Imprime si todo esta ok
            this.Imprimir();
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.iteStockFisicoProgramado, null);
        }

        #endregion

        private void wImpStockFisicoProgramado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Ejecutar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbTipExi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ckbCodExi_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCodExi();
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

        private void ckbAlm_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbAlm();
        }
    }
}
