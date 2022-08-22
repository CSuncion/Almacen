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
    public partial class wImpCompraPorExistencia : Heredados.MiForm8
    {
        public wImpCompraPorExistencia()
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
            xCtrl.TxtTodo(this.txtCodCenCosDes, true, "Centro Costo", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCenCosDes, this.txtCodCenCosDes, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, true, "Proveedor", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Existencia", "vfff", 3);
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

            //cargar combos
            this.CargarMeses();

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

        public List<MovimientoDetaEN> ObtenerReporte()
        {
            MovimientoDetaEN iIngEN = new MovimientoDetaEN();

            //asignar parametros
            string iAño = this.txtAño.Text.Trim();
            string iCodigoMes = Cmb.ObtenerValor(this.cmbMes, "");
            iIngEN.PeriodoMovimientoCabe = iAño + "-" + iCodigoMes;
            iIngEN.CodigoCentroCosto = this.txtCodCenCosDes.Text.Trim();
            iIngEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iIngEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iIngEN.CodigoExistencia = this.txtCodExi.Text.Trim();

            //ejecutar metodo
            return MovimientoDetaRN.ListarListasDeMovimientoCompraPorProvedor(iIngEN);
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
            string iTextoSustituto = this.ckbAlm.Text;
            string iSeparador = ":";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iTextoSustituto, iSeparador);
        }

        public string ObtenerTxtObjCodExi()
        {
            //asignar parametros
            string iTexto1 = this.txtCodExi.Text;
            string iTexto2 = this.txtDesExi.Text;
            string iTextoSustituto = this.ckbExi.Text;
            string iSeparador = "-->";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iTextoSustituto, iSeparador);
        }

        public void Imprimir()
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            TextObject txtObjEmp = (TextObject)(this.crCompraExistencia1.Section2.ReportObjects["txtObjEmp"]);
            txtObjEmp.Text = Universal.gNombreEmpresa;

            TextObject txtObjPer = (TextObject)(this.crCompraExistencia1.Section2.ReportObjects["txtObjPer"]);
            txtObjPer.Text = this.ObtenerTxtObjPer();

            TextObject txtObjAlm = (TextObject)(this.crCompraExistencia1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = this.ObtenerTxtObjAlm();

            TextObject txtObjCodExi = (TextObject)(this.crCompraExistencia1.Section2.ReportObjects["txtObjCodExi"]);
            txtObjCodExi.Text = this.ObtenerTxtObjCodExi();


            //----------------
            //imprimir detalle
            //----------------

            //creamos el dataset para cargar los datos del detalle
            Impresion iDs = new Impresion();

            //traemos el reporte a mostrar en el detalle
            List<MovimientoDetaEN> iLisRep = this.ObtenerReporte();

            //pasamos los objetos de la lista  a la tabla del reporte
            foreach (MovimientoDetaEN xObj in iLisRep)
            {
                //creamos un nuevo registro
                Impresion.MovimientoDetaRow iRow;
                iRow = iDs.MovimientoDeta.NewMovimientoDetaRow();

                //pasamos datos
                iRow.CodigoAuxiliar = xObj.CodigoAuxiliar;
                iRow.DescripcionAuxiliar = xObj.DescripcionAuxiliar;
                iRow.FechaMovimientoCabe = xObj.FechaMovimientoCabe;
                iRow.SerieDocumento = xObj.SerieDocumento;
                iRow.NumeroDocumento = xObj.NumeroDocumento;
                iRow.CantidadMovimientoDeta = xObj.CantidadMovimientoDeta;
                iRow.CostoMovimientoDeta = xObj.CostoMovimientoDeta;
                iRow.DescripcionCentroCosto = xObj.DescripcionCentroCosto;
                iRow.DescripcionAlmacen = xObj.DescripcionAlmacen;

                //insertamos en la tabla del dataset
                iDs.MovimientoDeta.Rows.Add(iRow);
            }

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.crCompraExistencia1.SetDataSource(iDs);
            this.crv1.ReportSource = this.crCompraExistencia1;
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
            wMen.CerrarVentanaHijo(this, wMen.iteCompraExistencia, null);
        }

        public bool EsCodigoCentroCostoDesdeValido()
        {
            return Generico.EsCodigoItemEValido("CenCos", this.txtCodCenCosDes, this.txtDesCenCosDes, "Centro costo");
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
            win.eCtrlFoco = this.txtCodAux;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsProveedorValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAux.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iAuxEN = AuxiliarRN.EsProveedorActivoValido(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, "Compra por Proveedor");
                this.txtCodAux.Focus();
            }

            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void ListarProveedores()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            wLisAux win = new wLisAux();
            win.eVentana = this;
            win.eTituloVentana = "Proveedores";
            win.eCtrlValor = this.txtCodAux;
            win.eCtrlFoco = this.txtCodAlm;
            win.eCondicionLista = Listas.wLisAux.Condicion.ProveedoresActivos;
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
            win.eCtrlFoco = this.btnAceptar;
            win.eExiEN.CodigoAlmacen = this.txtCodAlm.Text;//almacen semi elaborados
            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void CambiarCkbCeCo()
        {
            Txt.HabilitarParaFiltro1(this.txtCodCenCosDes, this.txtDesCenCosDes, this.ckbCeCo.Checked);
        }
        public void CambiarCkbAux()
        {
            Txt.HabilitarParaFiltro1(this.txtCodAux, this.txtDesAux, this.ckbProv.Checked);
        }
        public void CambiarCkbAlm()
        {
            this.ckbExi.Checked = !this.ckbExi.Checked;
            Txt.HabilitarParaFiltro1(this.txtCodAlm, this.txtDesAlm, this.ckbAlm.Checked);
            Txt.HabilitarParaFiltro1(this.txtCodExi, this.txtDesExi, this.ckbAlm.Checked);
        }

        public void CambiarCkbCodExi()
        {
            Txt.HabilitarParaFiltro(this.txtCodExi, this.txtDesExi, this.ckbExi.Checked);
        }
        #endregion

        private void wImpCompraPorExistencia_FormClosing(object sender, FormClosingEventArgs e)
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
            //this.CambiarCkbTipExi();
        }

        private void ckbCodExi_CheckedChanged(object sender, EventArgs e)
        {
            //this.CambiarCkbCodExi();
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

        private void txtCodAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsProveedorValido();
        }

        private void txtCodAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarProveedores(); }
        }

        private void txtCodAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarProveedores();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValido();
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistencias(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistencias();
        }

        private void ckbCeCo_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCeCo();
        }

        private void ckbProv_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbAux();
        }

        private void ckbAlm_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbAlm();
        }

        private void ckbExi_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCodExi();
        }
    }
}
