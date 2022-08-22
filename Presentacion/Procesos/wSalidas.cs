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
    public partial class wSalidas : Heredados.MiForm8
    {
        public wSalidas()
        {
            InitializeComponent();
        }

        //Atributos
        string eNombreColumnaDgvMovCab = MovimientoCabeEN.NumMovCab;
        string eEncabezadoColumnaDgvMovCab = "Numero";
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<MovimientoCabeEN> eLisMovCab = new List<MovimientoCabeEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Salida";

        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.MostrarPersistencia();
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.CodTipOpe, "T.O", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.DesTipOpe, "Descripción T.O", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.DesAlm, "Almacen", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.DesAux, "Cliente", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.NomPer, "Personal", 160));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.GloMovCab, "Glosa", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.NOriVenCre, "Origen", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.NEstMovCab, "Estado", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaMovimientoCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            iCuoEN.PeriodoMovimientoCabe = lblPeriodo.Text;
            iCuoEN.CClaseTipoOperacion = "2";//salida
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvMovCab;
            this.eLisMovCab = MovimientoCabeRN.ListarMovimientoCabesXPeriodoYClaseOperacion(iCuoEN);
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
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("014", DgvMovCab.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AsignarMovimientoCabe(MovimientoCabeEN pIng)
        {
            pIng.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoCabeEN.ClaObj);
            pIng.PeriodoMovimientoCabe = lblPeriodo.Text;
            pIng.COrigenVentanaCreacion = "2";//salida
        }

        public void AccionAdicionar()
        {
            //validar
            MovimientoCabeEN iIngEN = this.EsActoAdicionarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //instanciar
            wEditSalida win = new wEditSalida();
            win.wSal = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            MovimientoCabeEN iIngEN = this.EsActoModificarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditSalida win = new wEditSalida();
            win.wSal = this;
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
            MovimientoCabeEN iCuoEN = this.EsActoEliminarMovimientoCabe();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditSalida win = new wEditSalida();
            win.wSal = this;
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
            wEditSalida win = new wEditSalida();
            win.wSal = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }

        public void AccionImprimirNota()
        {
            //preguntar si el registro seleccionado existe
            MovimientoCabeEN iSalEN = this.EsMovimientoCabeExistente();
            if (iSalEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wImpNotaSalida win = new wImpNotaSalida();
            win.wSal = this;
            win.eVentana = wImpNotaSalida.Ventana.wSalidas;
            win.NuevaVentana(iSalEN);
        }

        public void AccionImportarExcel()
        {
            //instanciar
            wImportarMovimientosSalidas win = new wImportarMovimientosSalidas();
            win.wSal = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionEliminarImportarExcel()
        {
            //validar
            MovimientoCabeEN iMovCabEN = this.EsActoEliminarImportacionMovimientoCabes();
            if (iMovCabEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar importacion") == false) { return; }

            //eliminar copia
            MovimientoCabeRN.EliminarAntesDeImportarSalida(this.lblPeriodo.Text);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la importacion", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionSeleccionarPeriodo()
        {
            vSeleccionarPeriodo win = new vSeleccionarPeriodo();
            win.eVentanaInvoca = this;
            win.eControlDevuelveValor =  lblPeriodo;
            win.ePeriodoActual = lblPeriodo.Text;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
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

        public MovimientoCabeEN EsActoEliminarImportacionMovimientoCabes()
        {
            MovimientoCabeEN iIngEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoCabeRN.EsActoEliminarImportacionMovimientoCabeSalida(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public void AccionCambiaPeriodo()
        {
            //poner la descripcion del mes
            lblDescripcionPeriodo.Text = AñoMes.ObtenerDescripcionPeriodo(lblPeriodo.Text);
           
            //guardar el nuevo periodo
            Properties.Settings.Default.GuardarPeriodoSalidas = TsL.ModificarValor(Properties.Settings.Default.GuardarPeriodoSalidas, Universal.gCodigoEmpresa, lblPeriodo);
            Properties.Settings.Default.Save();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void MostrarPersistencia()
        {
            TsL.MostrarValor(lblPeriodo, Properties.Settings.Default.GuardarPeriodoSalidas, Universal.gCodigoEmpresa);
        }
      
        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteSalidas, wMen.tsbSalidas);
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

        
        private void wSalidas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
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

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }

        private void tsbImprimirNota_Click(object sender, EventArgs e)
        {
            this.AccionImprimirNota();
        }

        private void IteImportarAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionImportarExcel();
        }

        private void IteImportarEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminarImportarExcel();
        }
    }
}
