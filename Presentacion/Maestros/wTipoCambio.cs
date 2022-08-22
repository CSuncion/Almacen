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
using Comun;
using Entidades;
using Negocio;
using Presentacion.Principal;
using System.Collections;

namespace Presentacion.Maestros
{
    public partial class wTipoCambio : Heredados.MiForm8
    {
        public wTipoCambio()
        {
            InitializeComponent();
        }

        //atributos
        string eNombreColumnaDgvTipOpe = TipoCambioEN.FecTipCam;
        string eEncabezadoColumnaDvgTipOpe = "Codigo";
        public string eClaveDgvTipOpe = string.Empty;
        Dgv.Franja eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
        public List<TipoCambioEN> eLisTipOpe = new List<TipoCambioEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Tipo Cambio";

        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaTiposOperacionDeBaseDatos();
            this.ActualizarDgvTipOpe();
            Dgv.HabilitarDesplazadores(this.DgvTipCam, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvTipCam, this.sst1);         
        }
        
        public void ActualizarDgvTipOpe()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvTipCam;
            List<TipoCambioEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvTipOpe;
            string iClaveBusqueda = eClaveDgvTipOpe;
            string iColumnaPintura = eNombreColumnaDgvTipOpe;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvTipOpe();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvTipOpe()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoCambioEN.FecTipCam, "Fecha", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(TipoCambioEN.ComTipCam, "T.C.Compra", 100,3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(TipoCambioEN.VtaTipCam, "T.C.Venta", 100,3));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoCambioEN.NEstTipCam, "Estado", 100));           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PerfilEN.ClaObj, "Clave", 100, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaTiposOperacionDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            TipoCambioEN iTipOpeEN = new TipoCambioEN();
            iTipOpeEN.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            this.eLisTipOpe = TipoCambioRN.ListarTipoCambio(iTipOpeEN);
        }

        public List<TipoCambioEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvTipOpe;
            List<TipoCambioEN> iLisTipOpe = eLisTipOpe;

            //ejecutar y retornar
            return TipoCambioRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisTipOpe);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("006", DgvTipCam.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarTipoCambio(TipoCambioEN pObj)
        {
            pObj.FechaTipoCambio = Dgv.ObtenerValorCelda(this.DgvTipCam, TipoCambioEN.FecTipCam);
        }
        
        public void AccionAdicionar()
        {
            wEditTipoCambio win = new wEditTipoCambio();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            TipoCambioEN iTipCamEN = this.EsActoModificarTipoCambio();
            if (iTipCamEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoCambio win = new wEditTipoCambio();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iTipCamEN);            
        }

        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            if (tsbModificar.Enabled == false)
            {
                Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            }
            else
            {
                this.AccionModificar();
            }
        }

        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            TipoCambioEN iTipamEN = this.EsActoEliminarTipoCambio();
            if (iTipamEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoCambio win = new wEditTipoCambio();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iTipamEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            TipoCambioEN iTipamEN = this.EsTipoCambioExistente();
            if (iTipamEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoCambio win = new wEditTipoCambio();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iTipamEN);               
        }

        public TipoCambioEN EsTipoCambioExistente()
        {
            TipoCambioEN iTipamEN = new TipoCambioEN();
            this.AsignarTipoCambio(iTipamEN);
            iTipamEN = TipoCambioRN.EsTipoCambioExistente(iTipamEN);
            if (iTipamEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipamEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipamEN;
        }

        public TipoCambioEN EsActoModificarTipoCambio()
        {
            TipoCambioEN iTipamEN = new TipoCambioEN();
            this.AsignarTipoCambio(iTipamEN);
            iTipamEN = TipoCambioRN.EsActoModificarTipoCambio(iTipamEN);
            if (iTipamEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipamEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipamEN;
        }

        public TipoCambioEN EsActoEliminarTipoCambio()
        {
            TipoCambioEN iTipCamEN = new TipoCambioEN();
            this.AsignarTipoCambio(iTipCamEN);
            iTipCamEN = TipoCambioRN.EsActoEliminarTipoCambio(iTipCamEN);
            if (iTipCamEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipCamEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipCamEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.iteTipoCambio, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvTipOpe = this.DgvTipCam.Columns[pColumna].Name;
            this.eEncabezadoColumnaDvgTipOpe = this.DgvTipCam.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }

        #endregion
             
        private void wTipoOperacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvTipOpe_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvTipCam, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvTipCam, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvTipCam, Dgv.Desplazar.Ultimo);
        }

        private void DgvTipOpe_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvTipOpe_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
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
        
        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Cerrar();
        }

        
    }
}
