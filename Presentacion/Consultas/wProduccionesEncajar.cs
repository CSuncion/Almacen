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
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;
using Presentacion.Procesos;

namespace Presentacion.Consultas
{
    public partial class wProduccionesEncajar : Heredados.MiForm8
    {
        public wProduccionesEncajar()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string eClaveDgvLibProTer = string.Empty;       
        public List<LiberacionEN> eLisLib = new List<LiberacionEN>();
        public List<LiberacionProTer> eLisLibProTer = new List<LiberacionProTer>();

        #endregion
               
        #region Propietario

        public wDetalleEncajado wDetEnc;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;
                        
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUniXEmp, this.txtCanUniProTer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanUniProTer, true, "Cantidad", "ffff", 0, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumCaj, this.txtCanUniProTer, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAdicionarDistr, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnEliminarDistr, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnModificarFcLote, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnSalir, "vvvv");
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

            //Deshabilitar al propietario de esta ventana
            this.wDetEnc.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void NuevaVentana(ProduccionProTerEN pObj)
        {
            this.InicializaVentana();
            this.ActualizarListaLiberacionProTer();
            this.ActualizarListaLiberacion(pObj);           
            this.ActualizarDgvSal();
            this.MostrarProduccionProTer(pObj);           
            this.ActualizarDgvLibProTer();
            this.MostrarTitulo();
            eMas.AccionHabilitarControles(1);
            this.HabilitarControlesAlEntrarAPantalla();           
            this.txtCanUniProTer.Focus();
        }

        public void AsignarProduccionProTer(ProduccionProTerEN pObj)
        {           
            pObj.UnidadesPorEmpaque = Conversion.ADecimal(this.txtUniXEmp.Text, 0);
            pObj.CantidadUnidadesProTer = Conversion.ADecimal(this.txtCanUniProTer.Text, 0);
            pObj.NumeroCajas = Conversion.ADecimal(this.txtNumCaj.Text, 0);            
        }

        public void MostrarProduccionProTer(ProduccionProTerEN pObj)
        {
            this.txtUniXEmp.Text = Formato.NumeroDecimal(pObj.UnidadesPorEmpaque, 0);
            this.txtCanUniProTer.Text = Formato.NumeroDecimal(pObj.CantidadUnidadesProTer.ToString(), 0);
            this.txtNumCaj.Text = Formato.NumeroDecimal(pObj.NumeroCajas, 2);
        }

        public void ActualizarListaLiberacion(ProduccionProTerEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = pObj;
            bool iAccionAdicionar = this.ObtenerAccionAdicionar();
            List<LiberacionProTer> iLisLibProTer = this.eLisLibProTer;

            //ejecutar metodo
            this.eLisLib = LiberacionRN.ListarLiberacionParaEmpaquetarXCodigoSemiProducto(pObj, iAccionAdicionar, iLisLibProTer); 
        }

        public bool ObtenerAccionAdicionar()
        {
            if (this.wDetEnc.eOperacion == Universal.Opera.Adicionar)
            {
                return true;
            }
            else
            {
                //preguntamos si el objeto a modificar esta grabado en bd
                if (Dgv.ObtenerValorCelda(this.wDetEnc.wEditEnc.dgvProProTer, ProduccionProTerEN.UsuAgr) == string.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void ActualizarDgvSal()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<LiberacionEN> iFuenteDatos = this.eLisLib;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionEN.CodSemPro, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionEN.DesSemPro, "Descripcion", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionEN.FecProDet, "Fc.Produccion", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionEN.FecLib, "Fc.Liberacion", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LiberacionEN.SalUniAEmp, "Unidades", 60, 2));
                                    
            //devolver
            return iLisRes;
        }
      
        public void MostrarTitulo()
        {
            //asignar parametros
            string iTexto1 = "Cantidad de Liberaciones ";
            string iTexto2 = this.eLisLib.Count.ToString();

            //ejecutar metodo
            this.lblTit.Text = Formato.UnionDosTextos(iTexto1, iTexto2, " / ");
        }

        public void ActualizarDgvLibProTer()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvLibProTer;
            List<LiberacionProTer> iFuenteDatos = this.eLisLibProTer;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvLibProTer();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvLibProTer()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionProTer.FecLot, "Fc.Lote", 110));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionProTer.FecVcto, "Fc.Vcto", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LiberacionProTer.Can, "Unidades", 85, 0));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LiberacionProTer.CosTotPro, "Precio", 85, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LiberacionProTer.ClaLib, "CLaveObjeto", 70, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaLiberacionProTer()
        {
            //ejecutar metodo
            this.eLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(this.wDetEnc.eLiberacionProTer);
        }

        public void AdicionarDistribucion()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //valida cantidad
            if (this.ValidaCantidadUnidadesParaDistribucion() == false) { return; }

            //actualizar la lista LiberacionProTer por proceso de ddistribucion
            this.ActualizarListaLiberacionProTerPorDistribucion();

            //actualizar la grilla
            this.ActualizarDgvLibProTer();

            //habilitar controles
            this.HabilitarControles(true);

            //actualiza datos del propietario
            this.ActualizarDatosPropietario();
        }

        public void ActualizarListaLiberacionProTerPorDistribucion()
        {
            //asignar parametros
            List<LiberacionEN> iLisLib = this.eLisLib;
            decimal iCantidad = Conversion.ADecimal(this.txtCanUniProTer.Text, 0);
            int iNumeroDiasVcto = FormulaDetaRN.ObtenerNumeroDiasVcto(this.wDetEnc.NuevaProduccionProTerVentana());

            //ejecutar metodo
            this.eLisLibProTer = LiberacionRN.ListarLiberacionesDistribucion(iLisLib, iCantidad, iNumeroDiasVcto);
        }

        public void ArmarCampoDetalleLiberacionProTer()
        {
            //ejecutar metodo
            this.wDetEnc.eLiberacionProTer = ProduccionProTerRN.ConvertirListaACampoDetalleCantidadesSemiProducto(this.eLisLibProTer);
        }

        public void HabilitarControles(bool pValor)
        {
            if (this.wDetEnc.eOperacion == Universal.Opera.Adicionar) { Txt.SoloEscritura3(this.wDetEnc.txtCodAlm, pValor); }
            if (this.wDetEnc.eOperacion == Universal.Opera.Adicionar) { Txt.SoloEscritura3(this.wDetEnc.txtCodExi, pValor); }          
            Txt.SoloEscritura3(this.txtCanUniProTer, pValor);
            this.btnAdicionarDistr.Enabled = !pValor;
            this.btnEliminarDistr.Enabled = pValor;
            this.btnModificarFcLote.Enabled = pValor;
        }

        public void ActualizarDatosPropietario()
        {
            this.wDetEnc.txtCanUniProTer.Text = this.txtCanUniProTer.Text;
            this.wDetEnc.txtNumCaj.Text = this.txtNumCaj.Text;
            this.ArmarCampoDetalleLiberacionProTer();
        }

        public void HabilitarControlesAlEntrarAPantalla()
        {
            //asignar parametros
            bool iValor = Cadena.CompararDosValores(this.wDetEnc.eLiberacionProTer, string.Empty, false, true);

            //ejecutar metodo
            this.HabilitarControles(iValor);
        }

        public void EliminarDistribucion()
        {
            //actualizar la lista LiberacionProTer (limpiarla)
            this.eLisLibProTer.Clear();

            //actualizar la grilla
            this.ActualizarDgvLibProTer();

            //habilitar controles
            this.HabilitarControles(false);

            //limpiar cantidad a cero
            this.LimpiarCantidadACero();

            //actualiza datos del propietario
            this.ActualizarDatosPropietario();

            //foco
            this.txtCanUniProTer.Focus();
        }

        public void LimpiarCantidadACero()
        {
            this.txtCanUniProTer.Text = "0";
            this.txtNumCaj.Text = "0.00";
        }

        public void AccionModificarFcVcto()
        {
            //instanciar
            wCambiarFcLote win = new wCambiarFcLote();
            win.wProEnc = this;
            win.eOperacion = Universal.Opera.Modificar;           
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisLibProTer[Dgv.ObtenerIndiceRegistroXFranja(this.dgvLibProTer)]);
        }

        public bool EsCantidadUnidadesCorrecto()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = this.NuevaProduccionProTerVentana();
            decimal iCantidadSaldoLiberacion = ListaG.Sumar<LiberacionEN>(this.eLisLib, LiberacionEN.SalUniAEmp);

            //ejecutar metodo
            iProProTerEN = ProduccionProTerRN.EsCantidadUnidadesCorrecta(iProProTerEN, iCantidadSaldoLiberacion);

            //mensaje error
            Generico.MostrarMensajeError(iProProTerEN.Adicionales, this.txtCanUniProTer);

            //devolver
            return iProProTerEN.Adicionales.EsVerdad;
        }

        public void MostrarCantidadCajas()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = this.NuevaProduccionProTerVentana();

            //ejecutar metodos          
            decimal iNumeroCajas = ProduccionProTerRN.CalcularNumeroCajas(iProProTerEN);

            //mostrar en pantalla
            this.txtNumCaj.Text = Formato.NumeroDecimal(iNumeroCajas, 2);
        }

        public ProduccionProTerEN NuevaProduccionProTerVentana()
        {
            //asignar parameros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            this.AsignarProduccionProTer(iProProTerEN);

            //devolver
            return iProProTerEN;
        }

        public bool ValidaCantidadUnidadesParaDistribucion()
        {
            //asignar parametros
            List<LiberacionEN> iLisLib = this.eLisLib;
            decimal iCantidad = Conversion.ADecimal(this.txtCanUniProTer.Text, 0);

            //ejecutar metodo
            ProduccionProTerEN iProProTerEN = ProduccionProTerRN.ValidadCantidadUnidadesParaDistribucion(iLisLib, iCantidad);

            //mensaje error
            Generico.MostrarMensajeError(iProProTerEN.Adicionales, this.txtCanUniProTer);

            //devolver
            return iProProTerEN.Adicionales.EsVerdad;
        }

        #endregion

        private void wProduccionesEncajar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wDetEnc.Enabled = true;
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionarDistr_Click(object sender, EventArgs e)
        {
            this.AdicionarDistribucion();
        }

        private void btnEliminarDistr_Click(object sender, EventArgs e)
        {
            this.EliminarDistribucion();
        }

        private void btnModificarFcLote_Click(object sender, EventArgs e)
        {
            this.AccionModificarFcVcto();
        }

        private void txtCanUniProTer_Validated(object sender, EventArgs e)
        {
            this.MostrarCantidadCajas();
            this.EsCantidadUnidadesCorrecto();
        }
    }
}
