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

namespace Presentacion.Listas
{
    public partial class wLisProTer : Heredados.MiForm8
    {
        public wLisProTer()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            ProduccionesProTerDeAlmacenYExistencia = 0,
            ProduccionesProTerDeAlmacenYExistenciaNoSeleccionadasEnGrillaRetiquetadoProTer,
        }


        #endregion

        public Form eVentana = new Form();
        public ProduccionProTerEN eProProTerEN = new ProduccionProTerEN();
        public List<ProduccionProTerEN> eLisProProTer = new List<ProduccionProTerEN>();
        public List<RetiquetadoProTerEN> eLisRetProTer;       
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
       

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eProProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.CorEnc;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Encajado";
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
            this.ActualizarListaProduccionProTersDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eProProTerEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {          
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas            
            iDgv.AsignarColumnaTextCadena(ProduccionProTerEN.CorEnc, "Encajado", 70);
            iDgv.AsignarColumnaTextCadena(ProduccionProTerEN.FecEnc, "Fecha", 80);
            iDgv.AsignarColumnaTextCadena(ProduccionProTerEN.DesExi, "Descripcion", 240);
            iDgv.AsignarColumnaTextNumerico(ProduccionProTerEN.CosTotPro, "Costo.Uni", 90, 5);
            iDgv.AsignarColumnaTextCadena(ProduccionProTerEN.ClaProProTer, "Clave", 80, false);
        }

        public void ActualizarListaProduccionProTersDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.ProduccionesProTerDeAlmacenYExistencia: { this.eLisProProTer = ProduccionProTerRN.ListarProduccionProTerDeAlmacenYExistencia(eProProTerEN); break; }
                case Condicion.ProduccionesProTerDeAlmacenYExistenciaNoSeleccionadasEnGrillaRetiquetadoProTer: { this.eLisProProTer = ProduccionProTerRN.ListarProduccionProTerNoSeleccionadasEnGrilla(eProProTerEN,eLisRetProTer); break; }
            }
        }

        public List<ProduccionProTerEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eProProTerEN.Adicionales.CampoOrden;
            List<ProduccionProTerEN> iListaProduccionProTers = eLisProProTer;

            //ejecutar y retornar
            return ProduccionProTerRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaProduccionProTers);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, ProduccionProTerEN.ClaProProTer);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eProProTerEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            Txt.CursorAlUltimo(this.txtBus);  
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
            this.OrdenarPorColumna(e.ColumnIndex);
        }



       

   
    }
}
