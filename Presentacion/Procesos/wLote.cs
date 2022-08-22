using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.Listas;
using Presentacion.Principal;
using Presentacion.Maestros;
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;
using Presentacion.ProcesosCompras;

namespace Presentacion.Procesos
{
    public partial class wLote : Heredados.MiForm8
    {
        public wLote()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();       
        public string eClaveDgvLot = string.Empty;
        Dgv.Franja eFranjaDgvLot = Dgv.Franja.PorIndice;
      
        #endregion

        #region Propietario

        public wDetalleIngreso wDetIng;
        public wDetalleSolicitudPedido wDetSolPedido;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodExi, this.btnAgregar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.btnAgregar, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnModificar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvff");
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

            //valores x defecto
            this.ValoresXDefecto();

            // Deshabilitar al propietario de esta ventana
            this.wDetIng.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto()
        {
            this.txtCodExi.Text = wDetIng.txtCodExi.Text;
            this.txtDesExi.Text = wDetIng.txtDesExi.Text;
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarLotes();
            this.MostrarCantidadTotal();
            this.btnAgregar.Focus();
        }

        public void MostrarLotes()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvLot;
            List<LoteEN> iFuenteDatos = ListaG.Refrescar<LoteEN>(this.wDetIng.eLisLotExi);
            Dgv.Franja iCondicionFranja = eFranjaDgvLot;
            string iClaveBusqueda = eClaveDgvLot;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        //public List<DataGridViewColumn> ListarColumnasDgvCom()
        //{
        //    //lista resultado
        //    List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

        //    //agregando las columnas
        //    iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.CodLot, "Lote", 80));
        //    iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.FecVenLot, "Fc.Vcto", 80));
        //    iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.FecProLot, "Fc.Prod", 80));
        //    iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.NumLot, "Numero.Lot", 100));
        //    iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LoteEN.StoLot, "Cant", 90, 2));            
        //    iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.ClaObj, "Clave", 50, false));

        //    //devolver
        //    return iLisRes;
        //}

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.CodLot, "Lote", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.FecVenLot, "Fc.Vcto", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.FecProLot, "Fc.Prod", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.NumLot, "Numero.Lot", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LoteEN.StoConLot, "Cant.Conversion", 90, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LoteEN.StoLot, "Cant", 90, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void AccionAgregarItem()
        {           
            //instanciar
            wEditLote win = new wEditLote();
            win.wLot = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvLot = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.dgvLot.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wEditLote win = new wEditLote();
            win.wLot = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvLot = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(LoteRN.BuscarLoteXClave(Dgv.ObtenerValorCelda(this.dgvLot,LoteEN.ClaObj),this.wDetIng.eLisLotExi));
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.dgvLot.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            wEditLote win = new wEditLote();
            win.wLot = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvLot = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(LoteRN.BuscarLoteXClave(Dgv.ObtenerValorCelda(this.dgvLot, LoteEN.ClaObj), this.wDetIng.eLisLotExi));
        }

        public void MostrarCantidadTotal()
        {
            //obtener la suma total
            decimal iSumaTotal = Dgv.SumarColumna(this.dgvLot, LoteEN.StoLot);

            //mostrar en pantalla
            this.txtCanTot.Text = Formato.NumeroDecimal(iSumaTotal, 2);
        }

        #endregion
                

        private void wLote_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wDetIng.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarItem();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificarItem();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

    }
}
