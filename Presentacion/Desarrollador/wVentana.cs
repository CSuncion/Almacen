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
    public partial class wVentana : Heredados.MiForm8
    {
        public wVentana()
        {
            InitializeComponent();
        }

        //variables
        string eNombreColumna = VentanaEN.CodVen;
        string eEncabezadoColumna = "Codigo";
        public string eClaveDgvVen = string.Empty;     
        Dgv.Franja eFranja = Dgv.Franja.PorIndice;
        int eIndiceFilaAnterior = 0;
        
        //objetos controles
        public ToolStripMenuItem miItem;        
        public TabControl miTc;

        #region General


        public void NuevaVentana()
        {
            this.Show();    
            this.ActualizarVentana();          
        }

        public void ActualizarVentana()
        {            
            this.ActualizarDgvVen();
            Dgv.HabilitarDesplazadores(this.DgvVen, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvVen, this.sst1);
            this.AccionBuscar();
        }
        
        public void ActualizarDgvVen()
        {
            eIndiceFilaAnterior = Dgv.ObtenerIndiceRegistroXFranja(this.DgvVen);
            this.ActualizarDatosDgvVen();
            Dgv.PintarColumna(this.DgvVen, eNombreColumna);
            Dgv.PosicionarFranja(this.DgvVen, eFranja, eIndiceFilaAnterior, eClaveDgvVen);
        }
        
        public void ActualizarDatosDgvVen()
        {
            
            VentanaEN iVenEN = new VentanaEN();
            iVenEN.Adicionales.CampoOrden = eNombreColumna;
           
            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvVen;
            iDgv.RefrescarDatosGrilla(VentanaRN.ListarVentanas(iVenEN));

            //asignar columnas
            iDgv.AsignarColumnaTextCadena(VentanaEN.CodVen, "Codigo", 60);
            iDgv.AsignarColumnaTextCadena(VentanaEN.NomVen, "Nombre", 400);
            iDgv.AsignarColumnaTextCadena(VentanaEN.NomSubMen, "Modulo", 140);
            iDgv.AsignarColumnaTextCadena(VentanaEN.NEstVen, "Estado", 138);
            iDgv.AsignarColumnaTextCadena(VentanaEN.ClaObj, "Clave", 90, false);
        }
        
        public void HabilitarAcciones()
        {
            int iNumeroRegistros = this.DgvVen.Rows.Count;
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
        
        public void AsignarVentana(VentanaEN pObj)
        {
            pObj.CodigoVentana = Dgv.ObtenerValorCelda(this.DgvVen, VentanaEN.ClaObj);
        }
        
        public void AccionAdicionar()
        {
            wEditVentana win = new wEditVentana();
            win.wVen = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            VentanaEN iVenEN = this.EsVentanaExistente();
            if (iVenEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditVentana win = new wEditVentana();
            win.wVen = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranja = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iVenEN);            
        }
        
        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            VentanaEN iVenEN = this.EsVentanaExistente();
            if (iVenEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditVentana win = new wEditVentana();
            win.wVen = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranja = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iVenEN);           
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            VentanaEN iVenEN = this.EsVentanaExistente();
            if (iVenEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditVentana win = new wEditVentana();
            win.wVen = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iVenEN);            
        }

        public void AccionAgregarBotones()
        {
            //preguntar si el registro seleccionado existe
            VentanaEN iVenEN = this.EsVentanaExistente();
            if (iVenEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wBotonesVentana win = new wBotonesVentana();
            win.wVen = this;            
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iVenEN);            
        }

        public VentanaEN EsVentanaExistente()
        {
            VentanaEN iVenEN = new VentanaEN();
            this.AsignarVentana(iVenEN);
            iVenEN = VentanaRN.EsVentanaExistente(iVenEN);
            if (iVenEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iVenEN.Adicionales.Mensaje, "Ventana");
            }
            return iVenEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteVentanas, null);   
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranja = Dgv.Franja.PorIndice;
            this.eNombreColumna = this.DgvVen.Columns[pColumna].Name;
            this.eEncabezadoColumna = this.DgvVen.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }
       
        #endregion


     
        private void wVentana_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DgvVen_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvVen, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvVen, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvVen, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvVen, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvVen, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvVen, Dgv.Desplazar.Ultimo);
        }

        private void DgvVen_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Dgv.BusquedaInteligenteEnColumna(this.DgvVen, this.eNombreColumna, this.tstBuscar, e);
        }

        private void tsbAgregarBotones_Click(object sender, EventArgs e)
        {
            this.AccionAgregarBotones();
        }

      
       
    }
}
