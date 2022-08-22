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

namespace Presentacion.Procesos
{
    public partial class wCantidadDevolver : Heredados.MiForm8
    {
        public wCantidadDevolver()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public List<ProduccionExisEN> eLisProExi = new List<ProduccionExisEN>();
        //public List<InventarioDetaEN> eLisInvDet = new List<InventarioDetaEN>();
        public string eClaveDgvMovDet = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;

        #endregion

        #region Propietario

        public wMotivoSinceradoParTra wMotSinParTra;
        
        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

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

            //deshabilitar al propietario de esta ventana
            this.wMotSinParTra.Enabled = false;

            //mostrar
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.LLenarProduccionExisDeBaseDatos();       
            this.MostrarProduccionExis();
            this.btnCancelar.Focus();
        }
        
        public void MostrarProduccionExis()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<ProduccionExisEN> iFuenteDatos = ProduccionExisRN.RefrescarListaProduccionExis(this.eLisProExi);
            Dgv.Franja iCondicionFranja = eFranjaDgvMovDet;
            string iClaveBusqueda = eClaveDgvMovDet;
            //string iColumnaPintura = ProduccionExisEN.CanDevProExi;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);

            //pintamos las dos columnas digitables            
            Dgv.PintarSoloColumna(iGrilla, ProduccionExisEN.CanDevProExi);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.CodExi, "Codigo", 75));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.DesExi, "Descripcion", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.NomUniMed, "Uni.Med", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionExisEN.CanFor, "Cant.Transferida", 110, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionExisEN.CanProExi, "Cant.Producida", 100, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumericoEditable(ProduccionExisEN.CanDevProExi, "Cant.Devolver", 100, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarProduccionExisDeBaseDatos()
        {
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            //iProExiEN.ClaveProduccionDeta = Dgv.ObtenerValorCelda(this.wMotSinParTra.wParTra.DgvProDet, ProduccionDetaEN.ClaObj);
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            this.eLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDeta(iProExiEN);
        }

        public void Recalcular()
        {
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wMotSinParTra.eTitulo) == false) { return; }

            //modificar registro
            this.RecalcularProduccionExi();

            //llenar la lista de bd
            this.LLenarProduccionExisDeBaseDatos();

            //mostrar en pantalla
            this.MostrarProduccionExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se recalculo la cantidad sincerada correctamente", this.wMotSinParTra.eTitulo);
        }

        public void RecalcularProduccionExi()
        {
            //asignar parametros
            //ProduccionExisRN.RecalcularPorSincerado(this.ObtenerObjetoParaRecalculo());
        }

        //public ProduccionDetaEN ObtenerObjetoParaRecalculo()
        //{
        //    //primero traer al objeto de bd
        //    //ProduccionDetaEN iProDetEN = this.wMotSinParTra.wParTra.EsProduccionDetaExistente();

        //    //actualizamos los datos de la ventana motivo sincerado
        //    //this.wMotSinParTra.AsignarProduccionDeta(iProDetEN);

        //    ////devolver
        //    //return iProDetEN;
        //}

        public void ModificarProduccionExisDigitado(int pIndiceColumna)
        {
            //asignar parametro
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionExis = Dgv.ObtenerValorCelda(this.dgvMovDet, ProduccionExisEN.ClaObj);
            iProExiEN.CantidadDevueltaProduccionExis = Conversion.ADecimal(Dgv.ObtenerValorCelda(this.dgvMovDet, ProduccionExisEN.CanDevProExi), 5);

            //ejecutar metodo
            ProduccionExisRN.ModificarPorCantidadDigitadaSincerado(iProExiEN);
        }

        public void ValidarFormatoDecimal(DataGridViewCellValidatingEventArgs pE, string pNombreColumna, string pEncabezadoColumna)
        {
            //asignar parametros
            int iIndiceColumna = this.dgvMovDet.Columns[pNombreColumna].Index;
            string iEncabezadoColumna = pEncabezadoColumna;
            DataGridViewCellValidatingEventArgs iE = pE;

            //ejecutar metodo
            ValidarCeldaDgv.vNumerosDecimalesPositivos(iIndiceColumna, iEncabezadoColumna, iE);
        }

        #endregion

        private void wCantidadDevolver_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wMotSinParTra.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Recalcular();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMovDet_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvMovDet.BeginEdit(true);
        }

        private void dgvMovDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.EditarEnCeldaDeFilaSeleccionada(this.dgvMovDet, ProduccionExisEN.CanDevProExi);
        }

        private void dgvMovDet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarProduccionExisDigitado(e.ColumnIndex);
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExis();
            Dgv.EditarEnCeldaDeFilaSeleccionada(this.dgvMovDet, e.ColumnIndex);
        }

        private void dgvMovDet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            this.ValidarFormatoDecimal(e, ProduccionExisEN.CanDevProExi, "Cantidad Devolver");
        }
    }
}
