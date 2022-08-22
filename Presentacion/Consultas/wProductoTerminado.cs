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
using Entidades;
using Negocio;
using Entidades.Adicionales;
using Comun;
using Presentacion.Principal;
using System.Collections;
using Presentacion.Maestros;
using Heredados.VentanasPersonalizadas;
using System.Reflection;
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;
using Presentacion.Listas;

namespace Presentacion.Consultas
{
    public partial class wProductoTerminado : Heredados.MiForm8
    {
        public wProductoTerminado()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<MovimientoCabeEN> eLisMovCab = new List<MovimientoCabeEN>();
       
        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Formula", "vvfff", 16);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodProPro, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesProPro, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodProTer, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesProTer, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDes, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecHas, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnEjecutar, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnSalir, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General

        public void NuevaVentana()
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            this.Show();
            this.ActualizarVentana();
            this.txtCodExi.Focus();
        }

        public void ActualizarVentana()
        {            
            this.ActualizarDgvProDet();            
            this.TituloProduccionDeta();
            this.ActualizarDgvLib();
            this.TituloLiberacion();
            this.ActualizarDgvProTer();
            this.TituloProduccionProTer();          
        }

        public void TituloProduccionDeta()
        {
            int iNumeroRegistros = Dgv.ObtenerNumeroRegistros(this.DgvProDet);
            this.lblTituloCabe.Text = string.Empty;
            this.lblTituloCabe.Text += "Partes de Trabajo : ";
            this.lblTituloCabe.Text += " / Nro : " + iNumeroRegistros.ToString();
        }

        public void TituloLiberacion()
        {
            string iMovimientoActual = string.Empty;
            int iNumeroLineas = Dgv.ObtenerNumeroRegistros(this.dgvLib);
            this.lblTituloDeta.Text = string.Empty;
            iMovimientoActual = Dgv.ObtenerValorCelda(this.DgvProDet, ProduccionDetaEN.CorProCab);
            this.lblTituloDeta.Text += "Liberaciones : " + iMovimientoActual;
            this.lblTituloDeta.Text += " / Nro : " + iNumeroLineas.ToString();
        }

        public void TituloProduccionProTer()
        {
            string iMovimientoActual = string.Empty;
            int iNumeroLineas = Dgv.ObtenerNumeroRegistros(this.dgvEnc);
            this.lblTituloDeta.Text = string.Empty;
            iMovimientoActual = Dgv.ObtenerValorCelda(this.dgvLib, LiberacionEN.CodLib);
            this.lblTituloDeta.Text += "Encajados : " + iMovimientoActual;
            this.lblTituloDeta.Text += " / Nro : " + iNumeroLineas.ToString();
        }

        public void ActualizarDgvProDet()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvProDet;
            List<ProduccionDetaEN> iFuenteDatos = this.ListarProduccionesDeta();
            Dgv.Franja iCondicionFranja = eFranjaDgvMovCab;
            string iClaveBusqueda = eClaveDgvMovCab;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvProDet();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvProDet()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionDetaEN.CorProCab, "Produccion", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionDetaEN.FecProDet, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionDetaEN.NTur, "Turno", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanProDet, "Planificado", 100,2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanSinProDet, "Sincerada", 100, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanReaPro, "Real", 100,2));
            if (this.txtCCuarentena.Text == "0")
            {
                iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanEnc, "Unidades.Encajar", 100, 2));
                iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanConMue, "Muestra", 100, 2));
                iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanBlo, "Observadas", 100, 2));
            }
            else
            {
                iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanCuaQal, "Cuarentena", 100, 2));
                iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanRepQal, "Reproceso", 100, 2));
                iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanMueQal, "Muestra", 100, 2));
                iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.CanDesQal, "Desechas", 100, 2));
            }            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }
        
        public List<ProduccionDetaEN> ListarProduccionesDeta()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.Adicionales.Desde1 = this.dtpFecDes.Text;
            iProDetEN.Adicionales.Hasta1 = this.dtpFecHas.Text;
            iProDetEN.CodigoExistencia = this.txtCodExi.Text.Trim();

            //ejecutar metodo
            return ProduccionDetaRN.ListarProduccionDetaParaConsultaProductoTerminado(iProDetEN);
        }

        public void ActualizarDgvLib()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvLib;
            List<LiberacionEN> iFuenteDatos = this.ListarLiberaciones();
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvLib();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvLib()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionEN.CodLib, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionEN.FecLib, "Codigo", 80));            
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LiberacionEN.CanLib, "Cant.Liberada", 100, 5));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public List<LiberacionEN> ListarLiberaciones()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.ClaveProduccionDeta = Dgv.ObtenerValorCelda(this.DgvProDet, ProduccionDetaEN.ClaObj);

            //ejecutar metodo
            return LiberacionRN.ListarLiberacionXClaveProduccionDeta(iProDetEN);
        }

        public void ActualizarDgvProTer()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvEnc;
            List<ProduccionProTerEN> iFuenteDatos = this.ListarProduccionesProTer();
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvProTer();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvProTer()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.CorEnc, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.FecEnc, "Fecha", 80));
            //iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LiberacionEN.CanLib, "Cant.Liberada", 100, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public List<ProduccionProTerEN> ListarProduccionesProTer()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.DetalleCantidadesSemiProducto = Dgv.ObtenerValorCelda(this.dgvLib, LiberacionEN.ClaObj);
            iProProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.CorEnc;

            //ejecutar metodo
            return ProduccionProTerRN.ListarProduccionProTerXClaveLiberacion(iProProTerEN);
        }

        public void Ejecutar()
        {
            //validar campos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //ejecutar
            this.ActualizarVentana();
        }

        public void ListarFormulas()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExi.ReadOnly == true) { return; }

            //instanciar lista
            wLisFor win = new wLisFor();
            win.eVentana = this;
            win.eTituloVentana = "Formulas";
            win.eCtrlValor = this.txtCodExi;
            win.eCtrlFoco = this.dtpFecDes;
            win.eExiEN.CodigoAlmacen = "A10";
            win.eCondicionLista = wLisFor.Condicion.FormulaCabesActivasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoFormulaValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodExi.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            FormulaCabeEN iForCabEN = this.NuevaFormulaCabeVentana();

            //ejecutar metodo
            iForCabEN = FormulaCabeRN.EsFormulaCabeActivoValido(iForCabEN);

            //mensaje de error
            Generico.MostrarMensajeError(iForCabEN.Adicionales, this.txtCodExi);

            //pasar datos
            this.txtCodExi.Text = iForCabEN.CodigoExistencia;
            this.txtDesExi.Text = iForCabEN.DescripcionExistencia;
            this.txtCodProPro.Text = iForCabEN.CodigoSemiProducto;
            this.txtDesProPro.Text = iForCabEN.DescripcionExistenciaSemiProducto;
            this.txtCCuarentena.Text = iForCabEN.CManejaCuarentena;
            this.txtClaForDet.Text = iForCabEN.ClaveFormulaCabe;
            this.MostrarProductoTerminado();

            //devolver
            return iForCabEN.Adicionales.EsVerdad;
        }

        public void MostrarProductoTerminado()
        {
            //ejecutar metodo
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaConProTer(this.txtClaForDet.Text);

            //mostrar datos en pantalla
            this.txtCodProTer.Text = iForDetEN.CodigoExistenciaProTer;
            this.txtDesProTer.Text = iForDetEN.DescripcionExistenciaProTer;
        }

        public FormulaCabeEN NuevaFormulaCabeVentana()
        {
            //crear un nuevo objeto
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //pasamos datos desde las ventanas
            iForCabEN.CodigoAlmacen = "A10";
            iForCabEN.DescripcionAlmacen = "ALMACEN DE PRODUCCION";
            iForCabEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iForCabEN.ClaveFormulaCabe = FormulaCabeRN.ObtenerClaveFormulaCabe(iForCabEN);

            //devolver
            return iForCabEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteConsultaProductoTerminado, null);
        }


        #endregion

        
        private void wProductoTerminado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void DgvMovCab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {            
            this.ActualizarDgvLib();
            this.TituloLiberacion();
            this.ActualizarDgvProTer();
            this.TituloProduccionProTer();
        }

        private void DgvMovCab_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarFormulas(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarFormulas();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoFormulaValido();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            this.Ejecutar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLib_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.ActualizarDgvProTer();
            this.TituloProduccionProTer();
        }
    }
}
