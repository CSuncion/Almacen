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
    public partial class wImpKardexFisico : Heredados.MiForm8
    {
        public wImpKardexFisico()
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
            xCtrl.TxtNumeroSinEspacion(this.txtAño, true, "Año", "vfff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMes, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTipExi, "vvff");
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

            //cargar combos
            this.CargarMeses();
            this.CargarTiposExistencia();

            //mostrar ventana
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            MiControl.MostrarPeriodoActual(this.txtAño, this.cmbMes);
            this.txtAño.Focus();
        }

        public void CargarMeses()
        {
            Cmb.Cargar(this.cmbMes, ItemGRN.ListarItemsG("Mes"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarTiposExistencia()
        {
            Cmb.Cargar(this.cmbTipExi, ItemGRN.ListarItemsG("TipExi"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CambiarCkbTipExi()
        {
            Cmb.HabilitarParaFiltro(this.cmbTipExi,this.ckbTipExi.Checked);
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
            win.eCtrlFoco = this.cmbTipExi;
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

        public List<KardexFisico> ObtenerReporte()
        {
            //asignar parametros
            string iAño = this.txtAño.Text.Trim();
            string iCodigoMes = Cmb.ObtenerValor(this.cmbMes, "");
            string iCodigoAlmacen = this.txtCodAlm.Text.Trim();
            string iTipoExistencia = Cmb.ObtenerValor(this.cmbTipExi);
            string iCodigoExistenciaDesde = this.txtCodExiDes.Text.Trim();
            string iCodigoExistenciaHasta = this.txtCodExiHas.Text.Trim();

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerReporteKardexFisico(iAño, iCodigoMes, iCodigoAlmacen, iTipoExistencia,
                iCodigoExistenciaDesde, iCodigoExistenciaHasta);
        }

        public string ObtenerTxtObjPer()
        {
            //asignar parametros
            string iTexto1 = this.cmbMes.Text;
            string iTexto2 = this.txtAño.Text;
            string iSeparador = "-";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iSeparador);
        }

        public string ObtenerTxtObjAlm()
        {
            //asignar parametros
            string iTexto1 = this.txtCodAlm.Text;
            string iTexto2 = this.txtDesAlm.Text;
            string iSeparador = ":";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iSeparador);
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

        public string ObtenerTxtObjTipExi()
        {
            //asignar parametros
            string iTexto1 = Cmb.ObtenerValor(this.cmbTipExi);
            string iTexto2 = Cmb.ObtenerTexto(this.cmbTipExi);
            string iTextoSustituto = this.ckbTipExi.Text;
            string iSeparador = ":";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iTextoSustituto, iSeparador);
        }

        public void Imprimir()
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            TextObject txtObjEmp = (TextObject)(this.CrKardexFisico1.Section2.ReportObjects["txtObjEmp"]);
            txtObjEmp.Text = Universal.gNombreEmpresa;

            TextObject txtObjPer = (TextObject)(this.CrKardexFisico1.Section2.ReportObjects["txtObjPer"]);
            txtObjPer.Text = this.ObtenerTxtObjPer();

            TextObject txtObjAlm = (TextObject)(this.CrKardexFisico1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = this.ObtenerTxtObjAlm();

            TextObject txtObjCodExi = (TextObject)(this.CrKardexFisico1.Section2.ReportObjects["txtObjCodExi"]);
            txtObjCodExi.Text = this.ObtenerTxtObjCodExi();

            TextObject txtObjCodTipExi = (TextObject)(this.CrKardexFisico1.Section2.ReportObjects["txtObjCodTipExi"]);
            txtObjCodTipExi.Text = this.ObtenerTxtObjTipExi();

            //----------------
            //imprimir detalle
            //----------------

            //creamos el dataset para cargar los datos del detalle
            Impresion iDs = new Impresion();

            //traemos el reporte a mostrar en el detalle
            List<KardexFisico> iLisRep = this.ObtenerReporte();

            //pasamos los objetos de la lista  a la tabla del reporte
            foreach (KardexFisico xObj in iLisRep)
            {
                //creamos un nuevo registro
                Impresion.KardexFisicoRow iRow;
                iRow = iDs.KardexFisico.NewKardexFisicoRow();

                //pasamos datos
                iRow.CodigoExistencia = xObj.CodigoExistencia;
                iRow.DescripcionExistencia = xObj.DescripcionExistencia;
                iRow.CodigoUnidadMedida = xObj.CodigoUnidadMedida;
                iRow.NombreUnidadMedida = xObj.NombreUnidadMedida;
                iRow.CodigoTipo = xObj.CodigoTipo;
                iRow.NombreTipo = xObj.NombreTipo;
                iRow.StockAnterior = xObj.StockAnterior;
                iRow.Ingresos = xObj.Ingresos;
                iRow.Salidas = xObj.Salidas;
                iRow.StockActual = xObj.StockActual;
                iRow.PrecioUnitario = xObj.PrecioUnitario;
                iRow.Total = xObj.Total;
                
                //insertamos en la tabla del dataset
                iDs.KardexFisico.Rows.Add(iRow);
            }

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.CrKardexFisico1.SetDataSource(iDs);
            this.crv1.ReportSource = this.CrKardexFisico1;
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
            wMen.CerrarVentanaHijo(this, wMen.IteKardexFisico, null);
        }

        #endregion

        private void wImpKardexFisico_FormClosing(object sender, FormClosingEventArgs e)
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
            this.CambiarCkbTipExi();
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
    }
}
