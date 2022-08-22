using Comun;
using Entidades;
using Entidades.Adicionales;
using Entidades.Estructuras;
using Negocio;
using Presentacion.FuncionesGenericas;
using Presentacion.Listas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace Presentacion.Procesos
{
    public partial class wLoteRetiquetado : Heredados.MiForm8
    {
        public wLoteRetiquetado()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<LiberacionProTer> eLisLibProTer = new List<LiberacionProTer>();
        public List<LoteRetiquetado> eLisLotRet = new List<LoteRetiquetado>();
        public string eClaveDgvRetProTer = string.Empty;
        Dgv.Franja eFranjaDgvRetProTer = Dgv.Franja.PorIndice;

        #endregion

        #region Propietario

        public wDetalleRetiquetado wDetRet;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;
            
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
            
            //deshabilitar al propietario
            this.wDetRet.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.ActualizarListaLiberacionProTer();
            this.ActualizarListaLoteRetiquetado();     
            this.ActualizarDgvLibProTer();            
        }

        public void ActualizarListaLiberacionProTer()
        {
            //ejecutar metodo
            this.eLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(this.wDetRet.txtDetCanSemPro.Text);
        }

        public void ActualizarDgvLibProTer()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvRetProTer;
            List<LoteRetiquetado> iFuenteDatos = ListaG.Refrescar<LoteRetiquetado>(this.eLisLotRet);
            Dgv.Franja iCondicionFranja = this.eFranjaDgvRetProTer;
            string iClaveBusqueda = this.eClaveDgvRetProTer;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvLotRet();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);            
        }

        public List<DataGridViewColumn> ListarColumnasDgvLotRet()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteRetiquetado.FecLot, "Fc.Lote", 110));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteRetiquetado.FecVcto, "Fc.Vcto", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LoteRetiquetado.Can, "Unidades", 85, 0));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(LoteRetiquetado.CosTotPro, "Precio", 85, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(LoteRetiquetado.ClaObj, "CLaveObjeto", 70, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaLoteRetiquetado()
        {
            //ejecutar metodo
            this.eLisLotRet = RetiquetadoProTerRN.ConvertirCampoDetalleCantidadesLoteALista(this.wDetRet.eLoteRetiquetado);
        }
      
        public void AccionAgregarItem()
        {
            //instanciar
            wEditLoteRetiquetado win = new wEditLoteRetiquetado();
            win.wLotRet = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvRetProTer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.eLisLotRet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wEditLoteRetiquetado win = new wEditLoteRetiquetado();
            win.wLotRet = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvRetProTer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisLotRet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvRetProTer)]);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisLotRet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wEditLoteRetiquetado win = new wEditLoteRetiquetado();
            win.wLotRet = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvRetProTer = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisLotRet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvRetProTer)]);
        }
      
        #endregion

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
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wLoteRetiquetado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wDetRet.Enabled = true;
        }
        
    }
}
