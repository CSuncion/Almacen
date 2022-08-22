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
using Entidades.Adicionales;
using Entidades;
using Negocio;
using Presentacion.Principal;

namespace Presentacion.Desarrollador
{
    public partial class wBoton : Heredados.MiForm8
    {
        public wBoton()
        {
            InitializeComponent();
        }

        //variables
        string eNombreColumna = BotonEN.CodBot;
        string eEncabezadoColumna = "Codigo";
        public string eClaveDgvBot = string.Empty;     
        Dgv.Franja eFranja = Dgv.Franja.PorIndice;
        int eIndiceFilaAnterior = 0;

        #region General


        public void NuevaVentana()
        {
            this.Show();        
            this.ActualizarVentana();          
        }
         
        public void ActualizarVentana()
        {            
            this.ActualizarDgvBot();
            Dgv.HabilitarDesplazadores(this.DgvBot, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvBot, this.sst1);
            this.AccionBuscar();
        }
        
        public void ActualizarDgvBot()
        {
            eIndiceFilaAnterior = Dgv.ObtenerIndiceRegistroXFranja(this.DgvBot);
            this.ActualizarDatosDgvBot();
            Dgv.PintarColumna(this.DgvBot, eNombreColumna);
            Dgv.PosicionarFranja(this.DgvBot, eFranja, eIndiceFilaAnterior, eClaveDgvBot);
        }
        
        public void ActualizarDatosDgvBot()
        {          
            BotonEN iBotEN = new BotonEN();
            iBotEN.Adicionales.CampoOrden = eNombreColumna;
            
            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvBot;
            iDgv.RefrescarDatosGrilla(BotonRN.ListarBotones(iBotEN));
            //asignar columnas
            iDgv.AsignarColumnaTextCadena(BotonEN.CodBot, "Codigo", 60);
            iDgv.AsignarColumnaTextCadena(BotonEN.NomBot, "Nombre", 455);
            iDgv.AsignarColumnaTextCadena(BotonEN.NEstBot, "Estado", 126);
            iDgv.AsignarColumnaTextCadena(BotonEN.ClaObj, "Clave", 90, false);
        }
        
        public void HabilitarAcciones()
        {
            int iNumeroRegistros = this.DgvBot.Rows.Count;
            bool iVerdadFalso = true;
            if (iNumeroRegistros == 0) { iVerdadFalso = false; }
            this.tsbModificar.Enabled = iVerdadFalso;
            this.tsbEliminar.Enabled = iVerdadFalso;
            this.tsbVisualizar.Enabled = iVerdadFalso;
        }
                     
        public void AccionBuscar()
        {
            this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumna;
            this.tstBuscar.Focus();
        }
        
        public void AsignarBoton(BotonEN pObj)
        {
            pObj.CodigoBoton = Dgv.ObtenerValorCelda(this.DgvBot, BotonEN.ClaObj);
        }
        
        public void AccionAdicionar()
        {
            wEditBoton win = new wEditBoton();
            win.wBot = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            BotonEN iBotEN = this.EsBotonExistente();
            if (iBotEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditBoton win = new wEditBoton();
            win.wBot = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iBotEN);            
        }
        
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            BotonEN iBotEN = this.EsBotonExistente();
            if (iBotEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditBoton win = new wEditBoton();
            win.wBot = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranja = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iBotEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            BotonEN iBotEN = this.EsBotonExistente();
            if (iBotEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditBoton win = new wEditBoton();
            win.wBot = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iBotEN);               
        }
        
        public BotonEN EsBotonExistente()
        {          
            BotonEN iBotEN = new BotonEN();
            this.AsignarBoton(iBotEN);
            iBotEN = BotonRN.EsBotonExistente(iBotEN);
            if (iBotEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iBotEN.Adicionales.Mensaje, "Boton");
            }
            return iBotEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteBotones, null);   
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranja = Dgv.Franja.PorIndice;
            this.eNombreColumna = this.DgvBot.Columns[pColumna].Name;
            this.eEncabezadoColumna = this.DgvBot.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }
       
        #endregion


     
        private void wBoton_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranja = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvBot_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvBot, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvBot, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBot, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBot, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBot, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBot, Dgv.Desplazar.Ultimo);
        }

        private void DgvBot_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Dgv.BusquedaInteligenteEnColumna(this.DgvBot, this.eNombreColumna, this.tstBuscar, e);
        }

       
    }
}
