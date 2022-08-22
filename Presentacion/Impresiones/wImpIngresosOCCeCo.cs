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
    public partial class wImpIngresosOCCeCo : Heredados.MiForm8
    {
        public wImpIngresosOCCeCo()
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
            xCtrl.TxtTodo(this.txtCodCenCosDes, true, "Centro Costo", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCenCosDes, this.txtCodCenCosDes, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPar, true, "Partida", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesPar, this.txtCodPar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDesMovCab, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecHasMovCab, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Existencia", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCodExi, "ffff");
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
            this.CargarTipoReporte();
            //mostrar ventana
            this.Show();
        }

        public void CargarTipoReporte()
        {
            Cmb.Cargar(this.cmbTipoReporte, ItemGRN.ListarItemsG("TipRep"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.txtCodCenCosDes.Focus();
        }

        public void CambiarCkbAlm()
        {
            this.ckbExi.Checked = !this.ckbExi.Checked;
            Txt.HabilitarParaFiltro1(this.txtCodAlm, this.txtDesAlm, this.ckbAlm.Checked);
            Txt.HabilitarParaFiltro1(this.txtCodExi, this.txtDesExi, this.ckbAlm.Checked);
        }

        public void CambiarCkbCeCo()
        {
            this.ckbPar.Checked = !this.ckbPar.Checked;
            Txt.HabilitarParaFiltro1(this.txtCodCenCosDes, this.txtDesCenCosDes, this.ckbCeCo.Checked);
            Txt.HabilitarParaFiltro1(this.txtCodPar, this.txtDesPar, this.ckbCeCo.Checked);
        }

        public void CambiarCkbPar()
        {
            Txt.HabilitarParaFiltro1(this.txtCodPar, this.txtDesPar, this.ckbPar.Checked);
        }

        public void CambiarCkbCodExi()
        {
            Txt.HabilitarParaFiltro(this.txtCodExi, this.txtDesExi, this.ckbExi.Checked);
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
            win.eCtrlFoco = this.txtCodExi;
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

        public void ListarCentrosCostosDesde()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodCenCosDes.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            win.eCtrlValor = this.txtCodCenCosDes;
            win.eCtrlFoco = this.txtCodPar;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCentroCostoDesdeValido()
        {
            return Generico.EsCodigoItemEValido("CenCos", this.txtCodCenCosDes, this.txtDesCenCosDes, "Centro costo");
        }

        public List<MovimientoDetaEN> ObtenerReporte()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.Adicionales.Desde1 = this.dtpFecDesMovCab.Text;
            iMovDetEN.Adicionales.Hasta1 = this.dtpFecHasMovCab.Text;
            iMovDetEN.Adicionales.Desde3 = this.txtCodCenCosDes.Text;
            iMovDetEN.CodigoCentroCosto = this.txtCodCenCosDes.Text.Trim();
            iMovDetEN.CCodigoPartida = this.txtCodPar.Text.Trim();
            iMovDetEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iMovDetEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.CodExi;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaParaIngresoXOrdCompraXCeCoDetalle(iMovDetEN);
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
            //return "";
        }

        public string ObtenerTxtObjPer()
        {
            //asignar parametros
            string iDesde = this.dtpFecDesMovCab.Text;
            string iHasta = this.dtpFecHasMovCab.Text;
            string iTextoSustituto = string.Empty;

            //ejecutar metodo
            return Formato.RangoDelAl(iDesde, iHasta, iTextoSustituto);
        }

        public void Imprimir()
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            if (this.cmbTipoReporte.SelectedValue.ToString().Trim() == "01")
            {
                TextObject txtObjEmp = (TextObject)(this.crIngresoOCCeCoDetalle1.Section2.ReportObjects["txtObjEmp"]);
                txtObjEmp.Text = Universal.gNombreEmpresa;

                TextObject txtObjAlm = (TextObject)(this.crIngresoOCCeCoDetalle1.Section2.ReportObjects["txtObjAlm"]);
                txtObjAlm.Text = this.ObtenerTxtObjAlm();

                TextObject txtObjPer = (TextObject)(this.crIngresoOCCeCoDetalle1.Section2.ReportObjects["txtObjPer"]);
                txtObjPer.Text = this.ObtenerTxtObjPer();
            }
            else
            {
                TextObject txtObjEmp = (TextObject)(this.crIngresoOCCeCoResumen1.Section2.ReportObjects["txtObjEmp"]);
                txtObjEmp.Text = Universal.gNombreEmpresa;

                TextObject txtObjAlm = (TextObject)(this.crIngresoOCCeCoResumen1.Section2.ReportObjects["txtObjAlm"]);
                txtObjAlm.Text = this.ObtenerTxtObjAlm();

                TextObject txtObjPer = (TextObject)(this.crIngresoOCCeCoResumen1.Section2.ReportObjects["txtObjPer"]);
                txtObjPer.Text = this.ObtenerTxtObjPer();
            }
            //----------------
            //imprimir detalle
            //----------------



            //creamos el dataset para cargar los datos del detalle
            Impresion iDs = new Impresion();

            //traemos el reporte a mostrar en el detalle
            List<MovimientoDetaEN> iLisRepDet = this.ObtenerReporte();

            //pasamos los objetos de la lista  a la tabla del reporte
            foreach (MovimientoDetaEN xObj in iLisRepDet)
            {
                //creamos un nuevo registro
                Impresion.MovimientoDetaRow iRow;
                iRow = iDs.MovimientoDeta.NewMovimientoDetaRow();

                //pasamos datos
                iRow.CodigoExistencia = xObj.CodigoExistencia;
                iRow.DescripcionExistencia = xObj.DescripcionExistencia;
                iRow.CodigoUnidadMedida = xObj.CodigoUnidadMedida;
                iRow.CantidadMovimientoDeta = xObj.CantidadMovimientoDeta;
                iRow.CostoMovimientoDeta = xObj.CostoMovimientoDeta;
                iRow.PrecioExistencia = xObj.PrecioUnitarioMovimientoDeta;
                iRow.CodigoCentroCosto = xObj.CodigoCentroCosto;
                iRow.DescripcionCentroCosto = xObj.DescripcionCentroCosto;
                iRow.CodigoTipo = xObj.CodigoTipo;
                iRow.NombreTipo = xObj.NombreTipo;
                iRow.CodigoTipoOperacion = xObj.CodigoTipoOperacion;
                iRow.NumeroMovimientoCabe = xObj.NumeroMovimientoCabe;
                iRow.FechaMovimientoCabe = xObj.FechaMovimientoCabe;
                iRow.CodigoPartida = xObj.CCodigoPartida;
                iRow.NombrePartida = xObj.NCodigoPartida;
                iRow.CodigoAuxiliar = xObj.CodigoAuxiliar;
                iRow.DescripcionAuxiliar = xObj.DescripcionAuxiliar;
                iRow.Flete = xObj.CostoFleteMovimientoDeta;

                //insertamos en la tabla del dataset
                iDs.MovimientoDeta.Rows.Add(iRow);
            }
            if (this.cmbTipoReporte.SelectedValue.ToString().Trim() == "01")
            {
                //si existe
                this.crIngresoOCCeCoDetalle1.SetDataSource(iDs);
                this.crv1.ReportSource = this.crIngresoOCCeCoDetalle1;
            }
            else
            {
                //si existe
                this.crIngresoOCCeCoResumen1.SetDataSource(iDs);
                this.crv1.ReportSource = this.crIngresoOCCeCoResumen1;
            }
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
            wMen.CerrarVentanaHijo(this, wMen.IteRepIngOCCeCo, null);
        }

        public void ListarPartidas()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodCenCosDes.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Partidas";
            win.eCtrlValor = this.txtCodPar;
            win.eCtrlFoco = this.txtCodExi;
            win.eIteEN.CodigoTabla = "CodPar";
            win.eIteEN.CodigoItemE = this.txtCodCenCosDes.Text.Trim();
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTablaYArea;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public bool EsCodigoPartidaValido()
        {
            return Generico.EsCodigoItemEActivoValido("CodPar", this.txtCodPar, this.txtDesPar, "Partidas");
        }
        public void ListarExistencias()
        {
            // solo cuando se selecciono un almacen
            if (this.txtCodAlm.Text == string.Empty) { Mensaje.OperacionDenegada("Debe seleccionar un almacen.", "Existencia"); return; }
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExi.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias";
            win.eCtrlValor = this.txtCodExi;
            win.eCtrlFoco = this.cmbTipoReporte;
            win.eExiEN.CodigoAlmacen = this.txtCodAlm.Text;//almacen semi elaborados
            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValido()
        {
            // solo si hay codigo de almacen
            if (this.txtCodAlm.Text == string.Empty) { return true; }
            // solo si hay codigo de almacen
            if (this.txtCodExi.Text == string.Empty) { return true; }
            //solo si esta habilitado el control
            if (this.txtCodExi.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaExistente(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia");
                this.txtCodAlm.Focus();
            }

            //pasar datos
            this.txtCodExi.Text = iExiEN.CodigoExistencia;
            this.txtDesExi.Text = iExiEN.DescripcionExistencia;

            //devolver
            return iExiEN.Adicionales.EsVerdad;
        }

        public void CambiarCkbExi()
        {
            Txt.HabilitarParaFiltro1(this.txtCodExi, this.txtDesExi, this.ckbExi.Checked);
        }

        #endregion

        private void wImpIngresosOCCeCo_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ckbCeCo_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCeCo();
        }

        private void ckbExi_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCodExi();
        }

        private void txtCodCenCosDes_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCentroCostoDesdeValido();
        }

        private void txtCodCenCosDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCentrosCostosDesde(); }
        }

        private void txtCodCenCosDes_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCentrosCostosDesde();
        }

        private void txtCodPar_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPartidas();
        }

        private void txtCodPar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPartidas(); }
        }

        private void ckbPar_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbPar();
        }

        private void txtCodPar_Validated(object sender, EventArgs e)
        {

        }

        private void txtCodPar_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoPartidaValido();
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistencias(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistencias();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValido();

        }
    }
}
