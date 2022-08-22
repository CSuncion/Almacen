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
    public partial class wLisExi : Heredados.MiForm8
    {
        public wLisExi()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            Existencias = 0,     
            ExistenciasDeAlmacen,
            ExistenciasActivasDeAlmacen,
            ExistenciasDeAlmacenNoSeleccionadasGrillaMovimiento,
            ExistenciasNoProduccionDeAlmacenNoSeleccionadasGrillaFormula,
            ExistenciasNoProduccionDeAlmacenNoSeleccionadasGrillaMovimiento,
            ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaMovimiento,
            ExistenciasProduccionNoGrabadasEnFormula,
            ExistenciasNoProduccionNoGrabadasEnFormula,
            ExistenciasDeAlmacenNoSeleccionadasTransferencia,
            ExistenciasActivosDeAlmacenNoSeleccionadasTransferencia,
            ExistenciasActivasDeAlmacenNoSeleccionadasGrillaMovimiento,
            ListarExistenciasProductosTerminadosActivosDeAlmacen,
            ExistenciasDeFormulaNoSeleccionadasGrillaMovimiento,
            ListarExistenciasParaProduccionNoSeleccionadasEnGrilla,
            ListarExistenciasProductosTerminadosActivosDeAlmacenNoSeleccionadasGrilla,
            ExistenciasActivasNoProduccionDeAlmacen,
            ListarExistenciasFaseEncajadoParaProduccionNoSeleccionadasEnGrilla,
            ListarExistenciasParaEncajadoNoSeleccionadasEnGrilla,
            ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaSolicitudPedido,
            ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaOC,
        }


        #endregion

        public Form eVentana = new Form();
        public ExistenciaEN eExiEN = new ExistenciaEN();
        public ProduccionProTerEN eProProTerEN = new ProduccionProTerEN();
        public List<ExistenciaEN> eLisExi = new List<ExistenciaEN>();
        public List<MovimientoDetaEN> eLisMovDet;
        public List<MovimientoOCDetaEN> eLisMovDetOC;
        public List<SolicitudPedidoDetaEN> eLisSolPedidoDet;
        public List<FormulaDetaEN> eLisForDet;
        public List<ProduccionProTerEN> eLisProProTer;
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        public string eCodigoAlmacenSalida;
        public string eCodigoAlmacenIngreso;
        public string eClaveFormulaCabe;
        public string eClaveProduccionProTer;

        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eExiEN.Adicionales.CampoOrden = ExistenciaEN.DesExi;
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
            this.ActualizarListaExistenciasDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eExiEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {          
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(ExistenciaEN.CodExi, "Codigo", 80);
            iDgv.AsignarColumnaTextCadena(ExistenciaEN.DesExi, "Descripcion", 260);
        }

        public void ActualizarListaExistenciasDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.Existencias: { this.eLisExi = ExistenciaRN.ListarExistencias(eExiEN); break; }
                case Condicion.ExistenciasDeAlmacen: { this.eLisExi = ExistenciaRN.ListarExistenciasDeAlmacen(eExiEN); break; }
                case Condicion.ExistenciasActivasDeAlmacen: { this.eLisExi = ExistenciaRN.ListarExistenciasActivasDeAlmacen(eExiEN); break; }
                case Condicion.ExistenciasDeAlmacenNoSeleccionadasGrillaMovimiento: { this.eLisExi = ExistenciaRN.ListarExistenciasAlmacenNoSeleccionadasEnGrilla(eExiEN.CodigoAlmacen, this.eLisMovDet); break; }
                case Condicion.ExistenciasNoProduccionDeAlmacenNoSeleccionadasGrillaFormula: { this.eLisExi = ExistenciaRN.ListarExistenciasNoProduccionDeAlmacenNoSeleccionadasEnGrilla(eExiEN.CodigoAlmacen, this.eLisForDet); break; }
                case Condicion.ExistenciasNoProduccionDeAlmacenNoSeleccionadasGrillaMovimiento: { this.eLisExi = ExistenciaRN.ListarExistenciasNoProduccionDeAlmacenNoSeleccionadasEnGrilla(eExiEN.CodigoAlmacen, this.eLisMovDet); break; }
                case Condicion.ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaMovimiento: { this.eLisExi = ExistenciaRN.ListarExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasEnGrilla(eExiEN.CodigoAlmacen, this.eLisMovDet); break; }
                case Condicion.ExistenciasProduccionNoGrabadasEnFormula: { this.eLisExi = ExistenciaRN.ListarExistenciasParaGrabarAFormula(eExiEN.CodigoAlmacen); break; }
                case Condicion.ExistenciasNoProduccionNoGrabadasEnFormula: { this.eLisExi = ExistenciaRN.ListarExistenciasNoProduccionNoGrabadasEnFormula(eExiEN.CodigoAlmacen); break; }
                case Condicion.ExistenciasDeAlmacenNoSeleccionadasTransferencia: { this.eLisExi = ExistenciaRN.ListarExistenciasAlmacenNoSeleccionadasEnGrillaTransferencia(this.eCodigoAlmacenSalida, this.eCodigoAlmacenIngreso, this.eLisMovDet); break; }
                case Condicion.ExistenciasActivosDeAlmacenNoSeleccionadasTransferencia: { this.eLisExi = ExistenciaRN.ListarExistenciasActivasAlmacenNoSeleccionadasEnGrillaTransferencia(this.eCodigoAlmacenSalida, this.eCodigoAlmacenIngreso, this.eLisMovDet); break; }
                case Condicion.ExistenciasActivasDeAlmacenNoSeleccionadasGrillaMovimiento: { this.eLisExi = ExistenciaRN.ListarExistenciasActivasDeAlmacenNoSeleccionadasEnGrilla(eExiEN.CodigoAlmacen, this.eLisMovDet); break; }
                case Condicion.ListarExistenciasProductosTerminadosActivosDeAlmacen: { this.eLisExi = ExistenciaRN.ListarExistenciasProductosTerminadosActivosDeAlmacen(eExiEN); break; }
                case Condicion.ExistenciasDeFormulaNoSeleccionadasGrillaMovimiento: { this.eLisExi = ExistenciaRN.ListarExistenciasDeFormulaNoSeleccionadasEnGrilla(eExiEN.CodigoAlmacen, eClaveFormulaCabe, this.eLisMovDet); break; }
                case Condicion.ListarExistenciasParaProduccionNoSeleccionadasEnGrilla: { this.eLisExi = ExistenciaRN.ListarExistenciasParaProduccionNoSeleccionadasEnGrilla(eExiEN.CodigoAlmacen, eClaveFormulaCabe, this.eLisMovDet); break; }
                case Condicion.ListarExistenciasProductosTerminadosActivosDeAlmacenNoSeleccionadasGrilla: { this.eLisExi = ExistenciaRN.ListarExistenciasProductosTerminadosDeAlmacenNoSeleccionadasEnGrilla(eExiEN.CodigoAlmacen, this.eLisProProTer); break; }
                case Condicion.ExistenciasActivasNoProduccionDeAlmacen: { this.eLisExi = ExistenciaRN.ListarExistenciasActivasDeAlmacenYNoProduccion(eExiEN); break; }
                case Condicion.ListarExistenciasFaseEncajadoParaProduccionNoSeleccionadasEnGrilla: { this.eLisExi = ExistenciaRN.ListarExistenciasFaseEncajadoParaProduccionNoSeleccionadasEnGrilla(eClaveProduccionProTer, this.eLisMovDet); break; }
                case Condicion.ListarExistenciasParaEncajadoNoSeleccionadasEnGrilla: { this.eLisExi = ExistenciaRN.ListarExistenciasParaEncajadoNoSeleccionadasEnGrilla(eCodigoAlmacenIngreso, eProProTerEN, this.eLisMovDet); break; }
                case Condicion.ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaSolicitudPedido: { this.eLisExi = ExistenciaRN.ListarExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasEnGrillaSolPedido(eExiEN.CodigoAlmacen, this.eLisSolPedidoDet); break; }
                case Condicion.ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaOC: { this.eLisExi = ExistenciaRN.ListarExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasEnGrillaOC(eExiEN.CodigoAlmacen, this.eLisMovDetOC); break; }
            }
        }

        public List<ExistenciaEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eExiEN.Adicionales.CampoOrden;
            List<ExistenciaEN> iListaExistencias = eLisExi;

            //ejecutar y retornar
            return ExistenciaRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaExistencias);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, ExistenciaEN.CodExi);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eExiEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
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

   
        private void wLisExi_FormClosing(object sender, FormClosingEventArgs e)
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
