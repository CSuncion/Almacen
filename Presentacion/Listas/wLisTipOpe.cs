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
    public partial class wLisTipOpe : Heredados.MiForm8
    {
        public wLisTipOpe()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            TiposOperacion = 0,
            TiposOperacionXClase,
            TiposOperacionXClaseExceptoParametrizados,
            TiposOperacionXClaseActivos,
        }


        #endregion

        public Form eVentana = new Form();
        public TipoOperacionEN eTipOpeEN = new TipoOperacionEN();
        public List<TipoOperacionEN> eLisTipOpe = new List<TipoOperacionEN>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eTipOpeEN.Adicionales.CampoOrden = TipoOperacionEN.DesTipOpe;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Descripcion";
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
            this.ActualizarListaTipoOperacionsDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eTipOpeEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {          
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(TipoOperacionEN.CodTipOpe, "Codigo", 80);
            iDgv.AsignarColumnaTextCadena(TipoOperacionEN.DesTipOpe, "Descripcion", 260);
        }

        public void ActualizarListaTipoOperacionsDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.TiposOperacion: { this.eLisTipOpe = TipoOperacionRN.ListarTipoOperaciones(eTipOpeEN); break; }
                case Condicion.TiposOperacionXClase: { this.eLisTipOpe = TipoOperacionRN.ListarTiposOperacionesXClase(eTipOpeEN); break; }
                case Condicion.TiposOperacionXClaseExceptoParametrizados: { this.eLisTipOpe = TipoOperacionRN.ListarTiposOperacionesXClaseExceptoParametrizados(eTipOpeEN); break; }
                case Condicion.TiposOperacionXClaseActivos: { this.eLisTipOpe = TipoOperacionRN.ListarTiposOperacionesXClaseActivos(eTipOpeEN); break; }
            }
        }

        public List<TipoOperacionEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eTipOpeEN.Adicionales.CampoOrden;
            List<TipoOperacionEN> iListaTipoOperacions = eLisTipOpe;

            //ejecutar y retornar
            return TipoOperacionRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaTipoOperacions);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, TipoOperacionEN.CodTipOpe);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eTipOpeEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
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

   
        private void wLisTipOpe_FormClosing(object sender, FormClosingEventArgs e)
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
