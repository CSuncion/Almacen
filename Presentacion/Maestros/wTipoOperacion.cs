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
    public partial class wTipoOperacion : Heredados.MiForm8
    {
        public wTipoOperacion()
        {
            InitializeComponent();
        }

        //atributos
        string eNombreColumnaDgvTipOpe = TipoOperacionEN.CodTipOpe;
        string eEncabezadoColumnaDvgTipOpe = "Codigo";
        public string eClaveDgvTipOpe = string.Empty;
        Dgv.Franja eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
        public List<TipoOperacionEN> eLisTipOpe = new List<TipoOperacionEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Tipo Operacion";

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
            Dgv.HabilitarDesplazadores(this.DgvPer, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvPer, this.sst1);         
        }
        
        public void ActualizarDgvTipOpe()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvPer;
            List<TipoOperacionEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoOperacionEN.CodTipOpe, "Codigo", 45));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoOperacionEN.DesTipOpe, "Descripcion", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoOperacionEN.NClaTipOpe, "Clase", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(TipoOperacionEN.NEstTipOpe, "Estado", 70));           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PerfilEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaTiposOperacionDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            iTipOpeEN.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            this.eLisTipOpe = TipoOperacionRN.ListarTipoOperaciones(iTipOpeEN);
        }

        public List<TipoOperacionEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvTipOpe;
            List<TipoOperacionEN> iLisTipOpe = eLisTipOpe;

            //ejecutar y retornar
            return TipoOperacionRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisTipOpe);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("006", DgvPer.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarTipoOperacion(TipoOperacionEN pObj)
        {
            pObj.CodigoTipoOperacion = Dgv.ObtenerValorCelda(this.DgvPer, TipoOperacionEN.CodTipOpe);
        }
        
        public void AccionAdicionar()
        {
            wEditTipoOperacion win = new wEditTipoOperacion();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            TipoOperacionEN iTipOpeEN = this.EsActoModificarTipoOperacion();
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoOperacion win = new wEditTipoOperacion();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iTipOpeEN);            
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
            TipoOperacionEN iTipOpeEN = this.EsActoEliminarTipoOperacion();
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoOperacion win = new wEditTipoOperacion();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iTipOpeEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            TipoOperacionEN iTipOpeEN = this.EsTipoOperacionExistente();
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditTipoOperacion win = new wEditTipoOperacion();
            win.wTipOpe = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iTipOpeEN);               
        }

        public TipoOperacionEN EsTipoOperacionExistente()
        {
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            this.AsignarTipoOperacion(iTipOpeEN);
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipOpeEN;
        }

        public TipoOperacionEN EsActoModificarTipoOperacion()
        {
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            this.AsignarTipoOperacion(iTipOpeEN);
            iTipOpeEN = TipoOperacionRN.EsActoModificarTipoOperacion(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipOpeEN;
        }

        public TipoOperacionEN EsActoEliminarTipoOperacion()
        {
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            this.AsignarTipoOperacion(iTipOpeEN);
            iTipOpeEN = TipoOperacionRN.EsActoEliminarTipoOperacion(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, eTitulo);
            }
            return iTipOpeEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteTiposOperacion, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvTipOpe = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvTipOpe = this.DgvPer.Columns[pColumna].Name;
            this.eEncabezadoColumnaDvgTipOpe = this.DgvPer.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
            Dgv.HabilitarDesplazadores(this.DgvPer, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvPer, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvPer, Dgv.Desplazar.Ultimo);
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
            this.Close();
        }

    }
}
