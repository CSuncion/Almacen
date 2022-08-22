using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comun;
using WinControles.ControlesWindows;
using Entidades;
using Negocio;

namespace Presentacion.Listas
{
    public partial class wLisUsuExt : Form
    {
        public wLisUsuExt()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            UsuariosActivos = 0,
        }

        #endregion

        public Form eVentana = new Form();
        public UsuarioEN eUsuEN = new UsuarioEN();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eUsuEN.Adicionales.CampoOrden = UsuarioEN.NomUsu;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Descripcion";
            this.ActualizaVentana();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.Show();
        }

        public void ActualizaVentana()
        {
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eUsuEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {
          
            List<UsuarioEN> iLis = new List<UsuarioEN>();
            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.UsuariosActivos: { iLis = UsuarioRN.ListarUsuariosActivos(eUsuEN); break; }
            }

            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(iLis);
            //asignando columnas
            iDgv.AsignarColumnaTextCadena(UsuarioEN.CodUsu, "Codigo", 100);
            iDgv.AsignarColumnaTextCadena(UsuarioEN.NomUsu, "Descripcion", 227);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, UsuarioEN.CodUsu);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eUsuEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            Txt.CursorAlUltimo(this.txtBus);
        }

        #endregion

        private void wLisUsu_FormClosing(object sender, FormClosingEventArgs e)
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
            if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13) { this.DevolverDato(); }
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
            Dgv.BusquedaInteligenteEnColumna(this.DgvLista, eUsuEN.Adicionales.CampoOrden, this.txtBus, e);       
        }

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }



    }
}
