﻿using System;
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
    public partial class wImpIngresosOCCeCoDeta : Heredados.MiForm8
    {
        public wImpIngresosOCCeCoDeta()
        {
            InitializeComponent();
        }

        //atributos      
        Masivo eMas = new Masivo();

        #region Propietario

        public wImpIngresosOCCeCo wImpIng;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtCodCenCosDes, true, "Centro Costo Desde", "vvff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.txtNoFoco(this.txtDesCenCosDes, this.txtCodCenCosDes, "ffff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtCodCenCosHas, true, "Centro Costo Hasta", "vvff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.txtNoFoco(this.txtDesCenCosHas, this.txtCodCenCosHas, "ffff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Dtp(this.dtpFecDesMovCab, "vvvf");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Dtp(this.dtpFecHasMovCab, "vvvf");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtCodExiDes, true, "Existencia Desde", "vvff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtCodExiHas, true, "Existencia Hasta", "vvff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff", 3);
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Btn(this.btnAceptar, "vvvf");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Btn(this.btnCancelar, "vvvv");
            //xLis.Add(xCtrl);

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

        public void NuevaVentana(Impresion imp)
        {
            this.InicializaVentana();
            this.Imprimir(imp);
            //this.txtCodCenCosDes.Focus();
        }

        public void CambiarCkbAlm()
        {
            //Txt.HabilitarParaFiltro1(this.txtCodAlm, this.txtDesAlm, this.ckbAlm.Checked);
        }

        public void CambiarCkbCeCo()
        {
            //Txt.HabilitarParaFiltro1(this.txtCodCenCosHas, this.txtDesCenCosHas, this.ckbCeCo.Checked);
            //Txt.HabilitarParaFiltro1(this.txtCodCenCosDes, this.txtDesCenCosDes, this.ckbCeCo.Checked);
        }

        public void CambiarCkbCodExi()
        {
            //Txt.HabilitarParaFiltro(this.txtCodExiDes, this.txtCodExiHas, this.ckbExi.Checked);
        }

        public void ListarAlmacenes()
        {
            //si es de lectura , entonces no lista
            //if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            //win.eCtrlValor = this.txtCodAlm;
            //win.eCtrlFoco = this.btnAceptar;
            win.eCondicionLista = Listas.wLisAlm.Condicion.Almacenes;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            //if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el codigo almacen
            AlmacenEN iAlmEN = new AlmacenEN();
            //iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, "Almacen");
                //this.txtCodAlm.Focus();
            }

            //mostrar datos
            //this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            //this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarCentrosCostosDesde()
        {
            //solo cuando el control esta habilitado de escritura
            //if (this.txtCodCenCosDes.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            //win.eCtrlValor = this.txtCodCenCosDes;
            //win.eCtrlFoco = this.txtCodCenCosHas;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCentroCostoDesdeValido()
        {
            return true;
            //return Generico.EsCodigoItemEValido("CenCos", this.txtCodCenCosDes, this.txtDesCenCosDes, "Centro costo");
        }

        public void ListarCentrosCostosHasta()
        {
            //solo cuando el control esta habilitado de escritura
            //if (this.txtCodCenCosHas.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            //win.eCtrlValor = this.txtCodCenCosHas;
            //win.eCtrlFoco = this.dtpFecDesMovCab;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCentroCostoHastaValido()
        {
            return true;
            //return Generico.EsCodigoItemEValido("CenCos", this.txtCodCenCosHas, this.txtDesCenCosHas, "Centro costo");
        }

        public List<MovimientoDetaEN> ObtenerReporteDeta()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            //iMovDetEN.Adicionales.Desde1 = this.dtpFecDesMovCab.Text;
            //iMovDetEN.Adicionales.Hasta1 = this.dtpFecHasMovCab.Text;
            //iMovDetEN.Adicionales.Desde2 = this.txtCodExiDes.Text;
            //iMovDetEN.Adicionales.Hasta2 = this.txtCodExiHas.Text;
            //iMovDetEN.Adicionales.Desde3 = this.txtCodCenCosDes.Text;
            //iMovDetEN.Adicionales.Hasta3 = this.txtCodCenCosHas.Text;
            //iMovDetEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.CodExi;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaParaIngresoXCeCoDetalle(iMovDetEN);
        }

        public List<MovimientoCabeEN> ObtenerReporteCabe()
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.Adicionales.CampoOrden = MovimientoCabeEN.ClaMovCab;

            //ejecutar metodo
            return MovimientoCabeRN.ListarMovimientoCabes(iMovCabEN);
        }


        public string ObtenerTxtObjAlm()
        {
            //asignar parametros
            string iTexto1 = this.wImpIng.txtCodAlm.Text;
            string iTexto2 = this.wImpIng.txtDesAlm.Text;
            string iTextoSustituto = this.wImpIng.ckbAlm.Text;
            string iSeparador = ":";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iTextoSustituto, iSeparador);
            //return "";
        }

        public string ObtenerTxtObjPer()
        {
            //asignar parametros
            string iDesde = this.wImpIng.dtpFecDesMovCab.Text;
            string iHasta = this.wImpIng.dtpFecHasMovCab.Text;
            string iTextoSustituto = string.Empty;

            //ejecutar metodo
            return Formato.RangoDelAl(iDesde, iHasta, iTextoSustituto);
            //return "";
        }

        public void Imprimir(Impresion iDs)
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            TextObject txtObjEmp = (TextObject)(this.CrIngresoOCCeCoDetalle1.Section2.ReportObjects["txtObjEmp"]);
            txtObjEmp.Text = Universal.gNombreEmpresa;

            TextObject txtObjAlm = (TextObject)(this.CrIngresoOCCeCoDetalle1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = this.ObtenerTxtObjAlm();

            TextObject txtObjPer = (TextObject)(this.CrIngresoOCCeCoDetalle1.Section2.ReportObjects["txtObjPer"]);
            txtObjPer.Text = this.ObtenerTxtObjPer();



            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.CrIngresoOCCeCoDetalle1.SetDataSource(iDs);
            this.crv1.ReportSource = this.CrIngresoOCCeCoDetalle1;
        }

        public void Ejecutar()
        {
            //validar campos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //Imprime si todo esta ok
            //this.Imprimir();
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteRepIngOCCeCo, null);
        }

        #endregion

        private void wImpIngresosOCCeCoDeta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Cerrar();
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

        private void txtCodCenCosHas_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCentroCostoHastaValido();
        }

        private void txtCodCenCosHas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCentrosCostosHasta(); }
        }

        private void txtCodCenCosHas_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCentrosCostosHasta();
        }
    }
}
