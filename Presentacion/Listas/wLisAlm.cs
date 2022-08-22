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
    public partial class wLisAlm : Heredados.MiForm8
    {
        public wLisAlm()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            Almacenes = 0,      
            AlmacenesExceptoUno,
            AlmacenesActivos,
            AlmacenesActivosExceptoUno,
            AlmacenesActivosParaProduccion,
            AlmacenesActivosParaEncajado,
        }


        #endregion

        public Form eVentana = new Form();
        public AlmacenEN eAlmEN = new AlmacenEN();
        public ProduccionDetaEN eProDetEN = new ProduccionDetaEN();
        public EncajadoEN eProDetEN1 = new EncajadoEN();
        public List<AlmacenEN> eLisAlm = new List<AlmacenEN>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eAlmEN.Adicionales.CampoOrden = AlmacenEN.DesAlm;
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
            this.ActualizarListaAlmacensDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eAlmEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {          
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(AlmacenEN.CodAlm, "Codigo", 80);
            iDgv.AsignarColumnaTextCadena(AlmacenEN.DesAlm, "Descripcion", 260);
        }

        public void ActualizarListaAlmacensDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.Almacenes: { this.eLisAlm = AlmacenRN.ListarAlmacenes(eAlmEN); break; }
                case Condicion.AlmacenesExceptoUno: { this.eLisAlm = AlmacenRN.ListarAlmacenesExceptoUno(eAlmEN); break; }
                case Condicion.AlmacenesActivos: { this.eLisAlm = AlmacenRN.ListarAlmacenesActivos(eAlmEN); break; }
                case Condicion.AlmacenesActivosExceptoUno: { this.eLisAlm = AlmacenRN.ListarAlmacenesActivosExceptoUno(eAlmEN); break; }
                case Condicion.AlmacenesActivosParaProduccion: { this.eLisAlm = AlmacenRN.ListarAlmacenesActivosParaProduccion(eAlmEN,eProDetEN); break; }
                case Condicion.AlmacenesActivosParaEncajado: { this.eLisAlm = AlmacenRN.ListarAlmacenesActivosParaAdicionalesEncajado(eAlmEN); break; }
            }
        }

        public List<AlmacenEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eAlmEN.Adicionales.CampoOrden;
            List<AlmacenEN> iListaAlmacens = eLisAlm;

            //ejecutar y retornar
            return AlmacenRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAlmacens);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, AlmacenEN.CodAlm);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eAlmEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
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

   
        private void wLisAlm_FormClosing(object sender, FormClosingEventArgs e)
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
