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
    public partial class wImpKardexValorizado : Heredados.MiForm8
    {
        public wImpKardexValorizado()
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

        public List<KardexValorizado> ObtenerReporte()
        {
            //asignar parametros
            string iAño = this.txtAño.Text.Trim();
            string iCodigoMes = Cmb.ObtenerValor(this.cmbMes, "");
            string iCodigoAlmacen = this.txtCodAlm.Text.Trim();
            string iTipoExistencia = Cmb.ObtenerValor(this.cmbTipExi);
            string iCodigoExistenciaDesde = this.txtCodExiDes.Text.Trim();
            string iCodigoExistenciaHasta = this.txtCodExiHas.Text.Trim();

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerReporteKardexValorizado(iAño, iCodigoMes, iCodigoAlmacen, iTipoExistencia,
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

        public void Imprimir()
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            TextObject txtObjPer = (TextObject)(this.CrKardexValorizado1.Section2.ReportObjects["txtObjPer"]);
            txtObjPer.Text = this.ObtenerTxtObjPer();

            TextObject txtObjRuc = (TextObject)(this.CrKardexValorizado1.Section2.ReportObjects["txtObjRuc"]);
            txtObjRuc.Text = EmpresaRN.ObtenerRucEmpresaDeAcceso();

            TextObject txtObjRazSoc = (TextObject)(this.CrKardexValorizado1.Section2.ReportObjects["txtObjRazSoc"]);
            txtObjRazSoc.Text = Universal.gNombreEmpresa;

            TextObject txtObjAlm = (TextObject)(this.CrKardexValorizado1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text =this.ObtenerTxtObjAlm();

            TextObject txtObjCodExi = (TextObject)(this.CrKardexValorizado1.Section2.ReportObjects["txtObjCodExi"]);
            txtObjCodExi.Text = this.ObtenerTxtObjCodExi();

            TextObject txtObjCodTipExi = (TextObject)(this.CrKardexValorizado1.Section2.ReportObjects["txtObjCodTipExi"]);
            txtObjCodTipExi.Text = Cmb.ObtenerValor(this.cmbTipExi);

            TextObject txtObjNomTipExi = (TextObject)(this.CrKardexValorizado1.Section2.ReportObjects["txtObjNomTipExi"]);
            txtObjNomTipExi.Text = Cmb.ObtenerTexto(this.cmbTipExi);

            //----------------
            //imprimir detalle
            //----------------

            //creamos el dataset para cargar los datos del detalle
            Impresion iDs = new Impresion();

            //traemos el reporte a mostrar en el detalle
            List<KardexValorizado> iLisRep = this.ObtenerReporte();

            //pasamos los objetos de la lista  a la tabla del reporte
            foreach (KardexValorizado xObj in iLisRep)
            {
                //creamos un nuevo registro
                Impresion.KardexValorizadoRow iRow;
                iRow = iDs.KardexValorizado.NewKardexValorizadoRow();

                //pasamos datos
                iRow.CodigoExistencia = xObj.CodigoExistencia;
                iRow.DescripcionExistencia = xObj.DescripcionExistencia;
                iRow.CodigoUnidadMedida = xObj.CodigoUnidadMedida;
                iRow.NombreUnidadMedida = xObj.NombreUnidadMedida;
                iRow.CodigoUnidadMedida1 = xObj.CodigoUnidadMedida1;
                iRow.CantidadAnterior = xObj.CantidadAnterior;
                iRow.PrecioAnterior = xObj.PrecioAnterior;
                iRow.TotalAnterior = xObj.TotalAnterior;
                iRow.CantidadActual = xObj.CantidadActual;
                iRow.PrecioActual = xObj.PrecioActual;
                iRow.TotalActual = xObj.TotalActual;
                iRow.FechaMovimientoCabe = xObj.FechaMovimientoCabe;
                iRow.NumeroMovimientoCabe = xObj.NumeroMovimientoCabe;
                iRow.CTipoDocumento = xObj.CTipoDocumento;
                iRow.NTipoDocumento = xObj.NTipoDocumento;
                iRow.SerieDocumento = xObj.SerieDocumento;
                iRow.NumeroDocumento = xObj.NumeroDocumento;
                iRow.CodigoTipoOperacion = xObj.CodigoTipoOperacion;
                iRow.DescripcionTipoOperacion = xObj.DescripcionTipoOperacion;
                iRow.CClaseTipoOperacion = xObj.CClaseTipoOperacion;
                iRow.CantidadIngreso = xObj.CantidadIngreso;
                iRow.PrecioIngreso = xObj.PrecioIngreso;
                iRow.TotalIngreso = xObj.TotalIngreso;
                iRow.CantidadSalida = xObj.CantidadSalida;
                iRow.PrecioSalida = xObj.PrecioSalida;
                iRow.TotalSalida = xObj.TotalSalida;
                iRow.CantidadSaldo = xObj.CantidadSaldo;
                iRow.PrecioSaldo = xObj.PrecioSaldo;
                iRow.TotalSaldo = xObj.TotalSaldo;

                //insertamos en la tabla del dataset
                iDs.KardexValorizado.Rows.Add(iRow);
            }

            //-------------------
            //imprimir pie pagina
            //-------------------
            TextObject txtObjTotKar = (TextObject)(this.CrKardexValorizado1.Section4.ReportObjects["txtObjTotKar"]);
            txtObjTotKar.Text = Formato.NumeroDecimal(MovimientoDetaRN.ObtenerTotalKardexValorizado(iLisRep), 2);

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.CrKardexValorizado1.SetDataSource(iDs);
            this.crv1.ReportSource = this.CrKardexValorizado1;
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
            wMen.CerrarVentanaHijo(this, wMen.IteKardexValorizado, null);
        }

        #endregion

        private void wImpKardexValorizado_FormClosing(object sender, FormClosingEventArgs e)
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
