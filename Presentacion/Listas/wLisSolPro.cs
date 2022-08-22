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
    public partial class wLisSolPro : Heredados.MiForm8
    {
        public wLisSolPro()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            Solicitudes = 0,     
            SolicitudesPendientesDeAlmacen,
            SolicitudesAprobadasDeAlmacen,
        }


        #endregion

        public Form eVentana = new Form();
        public ProduccionCabeEN eProCabEN = new ProduccionCabeEN();
        public List<ProduccionCabeEN> eLisProCab = new List<ProduccionCabeEN>();        
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
       

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eProCabEN.Adicionales.CampoOrden = ProduccionCabeEN.CorProCab;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Numero";
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
            this.ActualizarListaProduccionCabesDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eProCabEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {          
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(ProduccionCabeEN.CorProCab, "Numero", 70);
            iDgv.AsignarColumnaTextCadena(ProduccionCabeEN.FecProCab, "Fecha", 70);
            iDgv.AsignarColumnaTextCadena(ProduccionCabeEN.DesExi, "Descripcion", 240);
            iDgv.AsignarColumnaTextNumerico(ProduccionCabeEN.SalProCab, "Saldo", 90, 5);
        }

        public void ActualizarListaProduccionCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.Solicitudes: { this.eLisProCab = ProduccionCabeRN.ListarProduccionCabeActivos(eProCabEN); break; }
                case Condicion.SolicitudesPendientesDeAlmacen: { this.eLisProCab = ProduccionCabeRN.ListarProduccionCabePendientesDeAlmacen(eProCabEN); break; }
                case Condicion.SolicitudesAprobadasDeAlmacen: { this.eLisProCab = ProduccionCabeRN.ListarProduccionCabeAprobadasDeAlmacen(eProCabEN); break; }
            }
        }

        public List<ProduccionCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eProCabEN.Adicionales.CampoOrden;
            List<ProduccionCabeEN> iListaProduccionCabes = eLisProCab;

            //ejecutar y retornar
            return ProduccionCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaProduccionCabes);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, ProduccionCabeEN.CorProCab);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eProCabEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
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

   
        private void wLisSolPro_FormClosing(object sender, FormClosingEventArgs e)
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
