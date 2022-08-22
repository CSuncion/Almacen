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
    public partial class wImpDocumentosEmitidosResu : Heredados.MiForm8
    {
        public wImpDocumentosEmitidosResu()
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
            xCtrl.Cmb(this.cmbClaOpe, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodTipOpe, true, "Tipo Operacion", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipOpe, this.txtCodTipOpe, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDesMovCab, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecHasMovCab, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
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
            this.CargarClasesTipoOperacion();

            //mostrar ventana
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.cmbClaOpe.Focus();
        }

        public void CargarClasesTipoOperacion()
        {
            Cmb.Cargar(this.cmbClaOpe, ItemGRN.ListarItemsG("ClaOpe"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CambiarCkbAlm()
        {
            Txt.HabilitarParaFiltro1(this.txtCodAlm, this.txtDesAlm, this.ckbAlm.Checked);
        }

        public void CambiarCkbTipOpe()
        {
            Txt.HabilitarParaFiltro1(this.txtCodTipOpe, this.txtDesTipOpe, this.ckbTipOpe.Checked);
        }

        public void ListarTiposOperacion()
        {
            //si es de lectura , entonces no lista
            if (txtCodTipOpe.ReadOnly == true) { return; }

            //instanciar
            wLisTipOpe win = new wLisTipOpe();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Operacion";
            win.eCtrlValor = this.txtCodTipOpe;
            win.eCtrlFoco = this.dtpFecDesMovCab;
            win.eTipOpeEN.CClaseTipoOperacion = Cmb.ObtenerValor(this.cmbClaOpe);
            win.eCondicionLista = Listas.wLisTipOpe.Condicion.TiposOperacionXClase;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsTipoOperacionValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodTipOpe.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            iTipOpeEN.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            string iCClaseTipoOperacion = Cmb.ObtenerValor(this.cmbClaOpe);
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionValido(iTipOpeEN, iCClaseTipoOperacion);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, "Tipo Operacion");
                this.txtCodTipOpe.Focus();
            }

            //mostrar datos
            this.txtCodTipOpe.Text = iTipOpeEN.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = iTipOpeEN.DescripcionTipoOperacion;
           
            //devolver
            return iTipOpeEN.Adicionales.EsVerdad;
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
            win.eCtrlFoco = this.btnAceptar;
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
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.CClaseTipoOperacion = Cmb.ObtenerValor(this.cmbClaOpe, "");          
            iMovDetEN.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            iMovDetEN.Adicionales.Desde1 = this.dtpFecDesMovCab.Text;
            iMovDetEN.Adicionales.Hasta1 = this.dtpFecHasMovCab.Text;
            iMovDetEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerReporteDocumentosEmitidosResumen(iMovDetEN);
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

        public string ObtenerTxtObjPer()
        {
            //asignar parametros
            string iDesde = this.dtpFecDesMovCab.Text;
            string iHasta = this.dtpFecHasMovCab.Text;
            string iTextoSustituto = string.Empty;

            //ejecutar metodo
            return Formato.RangoDelAl(iDesde, iHasta, iTextoSustituto);
        }

        public string ObtenerTxtObjCodTipOpe()
        {
            //asignar parametros
            string iTexto1 = this.txtCodTipOpe.Text;
            string iTexto2 = this.txtDesTipOpe.Text;
            string iTextoSustituto = this.ckbTipOpe.Text;
            string iSeparador = ":";

            //ejecutar metodo
            return Formato.UnionDosTextos(iTexto1, iTexto2, iTextoSustituto, iSeparador);
        }

        public void Imprimir()
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            TextObject txtObjEmp = (TextObject)(this.CrDocumentoEmitidoResumen1.Section2.ReportObjects["txtObjEmp"]);
            txtObjEmp.Text = Universal.gNombreEmpresa;

            TextObject txtObjAlm = (TextObject)(this.CrDocumentoEmitidoResumen1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = this.ObtenerTxtObjAlm();

            TextObject txtObjPer = (TextObject)(this.CrDocumentoEmitidoResumen1.Section2.ReportObjects["txtObjPer"]);
            txtObjPer.Text = this.ObtenerTxtObjPer();

            TextObject txtObjMov = (TextObject)(this.CrDocumentoEmitidoResumen1.Section2.ReportObjects["txtObjMov"]);
            txtObjMov.Text = Cmb.ObtenerTexto(this.cmbClaOpe);

            TextObject txtObjCodTipOpe = (TextObject)(this.CrDocumentoEmitidoResumen1.Section2.ReportObjects["txtObjCodTipOpe"]);
            txtObjCodTipOpe.Text = this.ObtenerTxtObjCodTipOpe();

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
                iRow.CodigoExistencia = xObj.CodigoExistencia;
                iRow.DescripcionExistencia = xObj.DescripcionExistencia;              
                iRow.CodigoTipo = xObj.CodigoTipo;
                iRow.NombreTipo = xObj.NombreTipo;
                iRow.CantidadMovimientoDeta = xObj.CantidadMovimientoDeta;
                iRow.CostoMovimientoDeta = xObj.CostoMovimientoDeta;
                iRow.PrecioExistencia = xObj.PrecioExistencia;
                
                //insertamos en la tabla del dataset
                iDs.MovimientoDeta.Rows.Add(iRow);
            }

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.CrDocumentoEmitidoResumen1.SetDataSource(iDs);
            this.crv1.ReportSource = this.CrDocumentoEmitidoResumen1;
        }

        public void Ejecutar()
        {
            //validar campos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //Imprime si todo esta ok
            this.Imprimir();
        }

        public void AccionAlCambiarMovimiento()
        {
            this.txtCodTipOpe.Clear();
            this.txtDesTipOpe.Clear();
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteDocEmiResumen, null);
        }

        #endregion

        private void wImpDocumentosEmitidosDeta_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ckbTipOpe_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbTipOpe();
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

        private void txtCodTipOpe_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoOperacionValido();
        }

        private void txtCodTipOpe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposOperacion(); }
        }

        private void txtCodTipOpe_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposOperacion();
        }

        private void cmbClaOpe_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.AccionAlCambiarMovimiento();
        }
    }
}
