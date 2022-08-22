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

namespace Presentacion.Desarrollador
{
    public partial class wBotonesVentana : Heredados.MiForm8
    {
        public wBotonesVentana()
        {
            InitializeComponent();
        }

        //variables     
        Masivo eMas = new Masivo();
               
        #region Propietario

        public wVentana wVen;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtVen, this.btnAgregar , "ffff");
            xLis.Add(xCtrl);                       

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
            this.wVen.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }

        public void ValoresXDefecto(VentanaEN pObj)
        {
            this.txtCodVen.Text = pObj.CodigoVentana;
            this.txtVen.Text = pObj.CodigoVentana + " : " + pObj.NombreVentana;
        }

        public void NuevaVentana(VentanaEN pObj)
        {
            this.InicializaVentana();
            this.ValoresXDefecto(pObj);
            this.ActualizarDgvBot();
            this.btnAgregar.Focus();
        }

        public void ActualizarDgvBot()
        {           
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();          
            iVenBotEN.CodigoVentana = this.txtCodVen.Text.Trim();
            iVenBotEN.Adicionales.CampoOrden = VentanaBotonEN.CodBot;
            List<VentanaBotonEN> iLisVenBot = VentanaBotonRN.ListarVentanaBotonesXVentana(iVenBotEN);

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvBot;
            iDgv.RefrescarDatosGrilla(iLisVenBot);
            //asignar columnas
            iDgv.AsignarColumnaTextCadena(VentanaBotonEN.CodBot, "Codigo", 50);
            iDgv.AsignarColumnaTextCadena(VentanaBotonEN.NomBot, "Nombre", 248);
            iDgv.AsignarColumnaTextCadena(VentanaBotonEN.ClaObj, "ClaveObjeto", 10, false);
        }

        public void AccionAgregarBotones()
        {
            wAgregarBotones win = new wAgregarBotones();
            win.wBotVen = this;
            win.eOperacion = Universal.Opera.Adicionar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAgregar();
        }

        public void AccionQuitarBotones()
        {
            wAgregarBotones win = new wAgregarBotones();
            win.wBotVen = this;
            win.eOperacion = Universal.Opera.Eliminar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaQuitar();
        }

        #endregion

        private void wOpciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wVen.Enabled = true;           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarBotones();
          
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarBotones();
        }
               
      
                
    }
}
