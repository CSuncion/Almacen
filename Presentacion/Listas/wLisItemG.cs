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
    public partial class wLisItemG : Heredados.MiForm8
    {
        public wLisItemG()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            ItemsActivosXTabla = 0,
            ItemsActivosXTablaNoSeleccionadasEnGrillaMotivos,
        }


        #endregion

        public Form eVentana = new Form();
        public ItemGEN eIteEN = new ItemGEN();
        public List<ItemGEN> eLisItem = new List<ItemGEN>();
        public List<MotivoLiberacion> eLisMotLib;
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eIteEN.Adicionales.CampoOrden = ItemGEN.NomIteG;
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
            this.ActualizarListaItemGsDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eIteEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {          
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(ItemGEN.CodIteG, "Codigo", 80);
            iDgv.AsignarColumnaTextCadena(ItemGEN.NomIteG, "Descripcion", 260);
        }

        public void ActualizarListaItemGsDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.ItemsActivosXTabla: { this.eLisItem = ItemGRN.ListarItemsGActivosXTabla(eIteEN); break; }
                case Condicion.ItemsActivosXTablaNoSeleccionadasEnGrillaMotivos: { this.eLisItem = ItemGRN.ListarItemsGTablaNoSeleccionadasEnGrilla(eIteEN.CodigoTabla,eLisMotLib); break; }
            }
        }

        public List<ItemGEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eIteEN.Adicionales.CampoOrden;
            List<ItemGEN> iListaItemG = eLisItem;

            //ejecutar y retornar
            return ItemGRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaItemG);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, ItemGEN.CodIteG);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eIteEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
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

   

        private void wLisItemG_FormClosing(object sender, FormClosingEventArgs e)
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
