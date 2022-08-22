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
using Entidades;
using Negocio;
using Entidades.Estructuras;

namespace Presentacion.Listas
{
    public partial class wLisLibProTer : Heredados.MiForm8
    {
        public wLisLibProTer()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            LiberacionesProTerNoSeleccionadasEnGrillaLoteRetiquetado = 0,            
        }


        #endregion

        public Form eVentana = new Form();
        public LiberacionProTer eLibProTerEN = new LiberacionProTer();
        public List<LiberacionProTer> eLisLibProTer = new List<LiberacionProTer>();
        public List<LoteRetiquetado> eLisLotRet;       
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
       

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;            
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Liberacion";
            this.ActualizaVentana();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();        
            this.Show();
            this.txtBus.Focus();
        }
        
        public void ActualizaVentana()
        {
            this.ActualizarListaLiberacionProTersDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();            
        }

        public void ActualizarDgvLista()
        {          
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas            
            iDgv.AsignarColumnaTextCadena(LiberacionProTer.ClaLib, "Liberacion", 70);
            iDgv.AsignarColumnaTextCadena(LiberacionProTer.FecLot, "Fecha", 80);
            iDgv.AsignarColumnaTextCadena(LiberacionProTer.FecVcto, "Fecha", 80);
            iDgv.AsignarColumnaTextNumerico(LiberacionProTer.CosTotPro, "Costo.Uni", 90, 5);
            iDgv.AsignarColumnaTextNumerico(LiberacionProTer.Can, "Cantidad", 90, 0);
        }

        public void ActualizarListaLiberacionProTersDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.LiberacionesProTerNoSeleccionadasEnGrillaLoteRetiquetado: { this.eLisLibProTer = RetiquetadoProTerRN.ListarLiberacionesProTerDiferentesDeLoteRetiquetado(eLisLibProTer,eLisLotRet); break; }
                
            }
        }

        public List<LiberacionProTer> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = LiberacionProTer.ClaLib;
            List<LiberacionProTer> iListaLiberacionProTers = eLisLibProTer;

            //ejecutar y retornar
            return RetiquetadoProTerRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaLiberacionProTers);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, LiberacionProTer.ClaLib);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        this.ActualizaVentana();
                        break;
                    }
            }
        }

        #endregion

   
        private void wLisProTer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;           
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DevolverDato();
        }

        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {         
            //si se selecciono la barra espaciadora
            if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13){this.DevolverDato();}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DevolverDato();
        }

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);       
        }

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }



       

   
    }
}
