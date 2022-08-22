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
using Entidades;
using Negocio;
using Entidades.Estructuras;

namespace Presentacion.Procesos
{
    public partial class wMotivoDesmedro : Heredados.MiForm8
    {
        public wMotivoDesmedro()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public List<MotivoLiberacion> eLisMotDes = new List<MotivoLiberacion>();
        public string eTipoMotivo = string.Empty;
        public decimal eCantidadMotivo = 0;
        public string eDetalleMotivo = string.Empty;
        public string eClaveDgvMotLib = string.Empty;
        Dgv.Franja eFranjaDgvMotLib = Dgv.Franja.PorIndice;

        #endregion

        #region Propietario

        public wDetalleDesmedroEnvasado wDetDesEnv;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvvf");
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
         
            // Deshabilitar al propietario de esta ventana
            this.wDetDesEnv.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarTitulo();
            this.ActualizarListaMotivos();         
            this.ActualizarDgvMot();
            this.MostrarCantidadTotal();
            this.HabilitarBotonesAcciones();
            this.PonerFoco();
        }

        public void HabilitarBotonesAcciones()
        {
            //obtener valor
            bool iValor= (this.wDetDesEnv.eOperacion == Universal.Opera.Visualizar) ? false : true;

            //ejecutar metodos
            this.btnAgregar.Enabled = iValor;
            this.btnModificar.Enabled = iValor;
            this.btnQuitar.Enabled = iValor;
        }

        public void PonerFoco()
        {
            if (this.wDetDesEnv.eOperacion == Universal.Opera.Visualizar)
            {
                this.btnSalir.Focus();
            }
            else
            {
                this.btnAgregar.Focus();
            }
        }

        public void MostrarTitulo()
        {
            //ejecutar metodo(segun tipoMotivo)
            switch (this.eTipoMotivo)
            {
                case "MotDmd": this.lblTitulo.Text = "Motivos Desmedro"; break;                
            }
        }

        public void ActualizarDgvMot()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvBot;
            List<MotivoLiberacion> iFuenteDatos = ListaG.Refrescar<MotivoLiberacion>(this.eLisMotDes);
            Dgv.Franja iCondicionFranja =  eFranjaDgvMotLib;
            string iClaveBusqueda = eClaveDgvMotLib;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMot();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMot()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MotivoLiberacion.CodMotLib, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MotivoLiberacion.DesMotLib, "Descripcion", 380));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MotivoLiberacion.CanMotLib, "Cantidad", 80, 0));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MotivoLiberacion.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaMotivos()
        {
            //asignar parametros
            List<ItemGEN> iLisMot = ItemGRN.ListarItemsG(this.eTipoMotivo);

            //ejecutar metodo
            this.eLisMotDes = LiberacionRN.ConvertirCampoDetalleMotivoALista(this.eDetalleMotivo, iLisMot);
        }

        public void AccionAgregarItem()
        {
            //instanciar
            wDetalleMotivoDesmedro win = new wDetalleMotivoDesmedro();
            win.wMotDes = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMotLib = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.eLisMotDes.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleMotivoDesmedro win = new wDetalleMotivoDesmedro();
            win.wMotDes = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMotLib = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisMotDes[Dgv.ObtenerIndiceRegistroXFranja(this.DgvBot)]);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisMotDes.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            wDetalleMotivoDesmedro win = new wDetalleMotivoDesmedro();
            win.wMotDes = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMotLib = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMotDes[Dgv.ObtenerIndiceRegistroXFranja(this.DgvBot)]);
        }

        public void MostrarCantidadTotal()
        {
            //ejecutar metodo
            decimal iCantidad = Dgv.SumarColumna(this.DgvBot, MotivoLiberacion.CanMotLib);

            //mostrar en pantalla
            this.txtCanTot.Text = Formato.NumeroDecimal(iCantidad, 0);
        }

        #endregion

        private void wMotivoDesmedro_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wDetDesEnv.Enabled = true;           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarItem();
          
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificarItem();
        }
    }
}
