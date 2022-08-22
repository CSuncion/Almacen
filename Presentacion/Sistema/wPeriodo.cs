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

namespace Presentacion.Sistema
{
    public partial class wPeriodo : Heredados.MiForm8
    {
        public wPeriodo()
        {
            InitializeComponent();
        }

        //atributos
        string eNombreColumnaDgvPer = PeriodoEN.CodPer;
        string eEncabezadoColumnaDgvPer = "Codigo";
        public string eClaveDgvPer = string.Empty;
        Dgv.Franja eFranjaDgvPer = Dgv.Franja.PorIndice;
        public List<PeriodoEN> eLisPer = new List<PeriodoEN>();
        int eVaBD = 1;//0 : no , 1 : si

        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaPeriodosDeBaseDatos();
            this.ActualizarDgvPer();
            Dgv.HabilitarDesplazadores(this.DgvPer, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvPer, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvPer;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvPer()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvPer;
            List<PeriodoEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvPer;
            string iClaveBusqueda = eClaveDgvPer;
            string iColumnaPintura = eNombreColumnaDgvPer;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvEmp();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvEmp()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PeriodoEN.CodPer, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PeriodoEN.AnoPer, "Año", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PeriodoEN.NMesPer, "Mes", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PeriodoEN.NEstPer, "Estado", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PeriodoEN.CodPer, "Codigo", 90, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(PeriodoEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaPeriodosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
            this.eLisPer = PeriodoRN.ListarPeriodos(iPerEN);
        }

        public List<PeriodoEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvPer;
            List<PeriodoEN> iListaPeriodos = eLisPer;

            //ejecutar y retornar
            return PeriodoRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaPeriodos);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;          
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("002", DgvPer.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iLisPer);
        }
             
        public void AsignarPeriodo(PeriodoEN pPer)
        {
            pPer.ClavePeriodo = Dgv.ObtenerValorCelda(this.DgvPer, PeriodoEN.ClaObj);       
            pPer.CodigoPeriodo = Dgv.ObtenerValorCelda(this.DgvPer, PeriodoEN.CodPer);
        }
        
        public void AccionAdicionar()
        {
            wEditPeriodo win = new wEditPeriodo();
            win.wPer = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvPer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            PeriodoEN iPerEN = this.EsPeriodoExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditPeriodo win = new wEditPeriodo();
            win.wPer = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvPer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);            
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
            PeriodoEN iPerEN = this.EsActoEliminarPeriodo();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditPeriodo win = new wEditPeriodo();
            win.wPer = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvPer = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            PeriodoEN iPerEN = this.EsPeriodoExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditPeriodo win = new wEditPeriodo();
            win.wPer = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);               
        }
        
        public PeriodoEN EsPeriodoExistente()
        {
            PeriodoEN iPerEN = new PeriodoEN();
            this.AsignarPeriodo(iPerEN);
            iPerEN = PeriodoRN.EsPeriodoExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, "Periodo");
            }
            return iPerEN;
        }

        public PeriodoEN EsActoEliminarPeriodo()
        {
            PeriodoEN iPerEN = new PeriodoEN();
            this.AsignarPeriodo(iPerEN);
            iPerEN = PeriodoRN.EsActoEliminarPeriodo(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, "Periodo");
            }
            return iPerEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.ItePeriodos, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvPer = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvPer = this.DgvPer.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvPer = this.DgvPer.Columns[pColumna].HeaderText;
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
             
      
        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvPer = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvPer_CellEnter(object sender, DataGridViewCellEventArgs e)
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

        private void DgvPer_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvPer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void wPeriodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }


    }
}
