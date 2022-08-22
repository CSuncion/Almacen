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
using Entidades;
using Negocio;
using Entidades.Adicionales;
using Comun;
using Presentacion.Principal;
using System.Collections;
using Presentacion.Maestros;
using Heredados.VentanasPersonalizadas;
using System.Reflection;
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;

namespace Presentacion.Procesos
{
    public partial class wIngresosDevolucion : Heredados.MiForm8
    {
        public wIngresosDevolucion()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvMovCab = MovimientoCabeEN.NumMovCab;
        string eEncabezadoColumnaDgvMovCab = "Numero";
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<MovimientoCabeEN> eLisMovCab = new List<MovimientoCabeEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Ingreso";

        #endregion

        #region Propietario

        //public wParteTrabajo wParTra;

        #endregion

        #region General


        public void NuevaVentana()
        {
            //this.wParTra.Enabled = false;
            this.Show();
            this.ActualizarVentana();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaMovimientoCabesDeBaseDatos();
            this.ActualizarDgvMovCab();
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();      
            Dgv.ActualizarBarraEstado(this.DgvMovCab, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvMovCab;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvMovCab()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvMovCab;
            List<MovimientoCabeEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvMovCab;
            string iClaveBusqueda = eClaveDgvMovCab;
            string iColumnaPintura = eNombreColumnaDgvMovCab;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMovCab();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMovCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.NumMovCab, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.FecMovCab, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.PerMovCab, "Periodo", 62));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.DesTipOpe, "Tip.Operacion", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.DesAlm, "Almacen", 110));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.GloMovCab, "Glosa", 200));           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaMovimientoCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            //iMovCabEN.ClaveProduccionDeta = Dgv.ObtenerValorCelda(this.wParTra.DgvProDet, ProduccionDetaEN.ClaObj);
            iMovCabEN.CClaseTipoOperacion = "1";//ingreso
            iMovCabEN.Adicionales.CampoOrden = eNombreColumnaDgvMovCab;
            this.eLisMovCab = MovimientoCabeRN.ListarMovimientoCabesXClaveProduccionDetaYClaseOperacion(iMovCabEN);
        }

        public List<MovimientoCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvMovCab;
            List<MovimientoCabeEN> iListaMovimientoCabes = eLisMovCab;

            //ejecutar y retornar
            return MovimientoCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaMovimientoCabes);
        }

        public void HabilitarAcciones()
        {
            //obtener el valor de verdad, segun el estado del produccionDeta
            //bool iValorPorEstado = Cadena.CompararDosValores(Dgv.ObtenerValorCelda(this.wParTra.DgvProDet, ProduccionDetaEN.CEstProDet),
            //    "0", true, false);

            //obtener el valor de verdad, segun la grilla
            bool iValorPorGrilla = Cadena.CompararDosValores(this.DgvMovCab.Rows.Count, 0, false, true);

            //obtener el valor de verdad, segun los dos valores anteriores
            //bool iValorPorCombinacion = Cadena.CompararDosValores(iValorPorGrilla, false, false, iValorPorEstado);

            //habilitando los controles
            //this.tsbAdicionar.Enabled = iValorPorEstado;
            //this.tsbModificar.Enabled = iValorPorCombinacion;
            //this.tsbEliminar.Enabled = iValorPorCombinacion;
            this.tsbVisualizar.Enabled = iValorPorGrilla;
        }

        public void AsignarMovimientoCabe(MovimientoCabeEN pIng)
        {
            pIng.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoCabeEN.ClaObj);           
            pIng.COrigenVentanaCreacion = "4";//produccion
        }

        public void AccionAdicionar()
        {
            //validar
            //MovimientoCabeEN iIngEN = this.EsActoAdicionarMovimientoCabe();
            //if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //instanciar
            wEditIngresoDevolucion win = new wEditIngresoDevolucion();
            win.wIngDev = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            //win.VentanaAdicionar(this.wParTra.EsProduccionDetaExistente());
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            MovimientoCabeEN iIngEN = this.EsMovimientoCabeExistente();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditIngresoDevolucion win = new wEditIngresoDevolucion();
            win.wIngDev = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iIngEN);
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
            MovimientoCabeEN iCuoEN = this.EsMovimientoCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditIngresoDevolucion win = new wEditIngresoDevolucion();
            win.wIngDev = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iCuoEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            MovimientoCabeEN iCuoEN = this.EsMovimientoCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditIngresoDevolucion win = new wEditIngresoDevolucion();
            win.wIngDev = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }

        public void AccionImprimirNota()
        {
            //preguntar si el registro seleccionado existe
            MovimientoCabeEN iIngEN = this.EsMovimientoCabeExistente();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wImpNotaIngreso win = new wImpNotaIngreso();
            win.wIngDev = this;
            win.eVentana = wImpNotaIngreso.Ventana.wIngresosDevolucion;
            win.NuevaVentana(iIngEN);
        }

        public MovimientoCabeEN EsMovimientoCabeExistente()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            iCuoEN = MovimientoCabeRN.EsMovimientoCabeExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public MovimientoCabeEN EsActoAdicionarMovimientoCabe()
        {
            MovimientoCabeEN iIngEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoCabeRN.EsActoAdicionarMovimientoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public MovimientoCabeEN EsActoModificarMovimientoCabe()
        {
            MovimientoCabeEN iIngEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoCabeRN.EsActoModificarMovimientoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public MovimientoCabeEN EsActoEliminarMovimientoCabe()
        {
            MovimientoCabeEN iIngEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoCabeRN.EsActoEliminarMovimientoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvMovCab = this.DgvMovCab.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvMovCab = this.DgvMovCab.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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

        
        private void wIngresosDevolucion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wParTra.Enabled = true;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvMovCab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvMovCab, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Ultimo);
        }

        private void DgvMovCab_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvMovCab_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbImprimirNota_Click(object sender, EventArgs e)
        {
            this.AccionImprimirNota();
        }
    }
}
