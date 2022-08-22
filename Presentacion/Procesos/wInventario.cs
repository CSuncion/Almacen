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
using Presentacion.Procesos;
using Heredados.VentanasPersonalizadas;
using Presentacion.VentanasComunes;
using Presentacion.Impresiones;

namespace Presentacion.Procesos
{
    public partial class wInventario : Heredados.MiForm8
    {
        public wInventario()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvInv = InventarioCabeEN.CorInvCab;
        string eEncabezadoColumnaDgvInv = "Correlativo";
        public string eClaveDgvInv = string.Empty;
        Dgv.Franja eFranjaDgvInv = Dgv.Franja.PorIndice;
        public List<InventarioCabeEN> eLisLic = new List<InventarioCabeEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Inventario";

        #endregion
      
        #region General


        public void NuevaVentana()
        {
            this.Show();        
            this.ActualizarVentana();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaInventarioCabesDeBaseDatos();
            this.ActualizarDgvInv();
            Dgv.HabilitarDesplazadores(this.DgvInv, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvInv, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvInv;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvInv()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvInv;
            List<InventarioCabeEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvInv;
            string iClaveBusqueda = eClaveDgvInv;
            string iColumnaPintura = eNombreColumnaDgvInv;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvInv();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvInv()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.CorInvCab, "Correlativo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.DesAlm, "Almacen", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.NomPer, "Personal", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.FecInvCab, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.ObsInvCab, "Observacion", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.FecGen, "Fc.Genera", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.NEstInvCab, "Estado", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.CodAlm, "CodigoAlmacen", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InventarioCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaInventarioCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();         
            iInvCabEN.Adicionales.CampoOrden = eNombreColumnaDgvInv;
            this.eLisLic = InventarioCabeRN.ListarInventarioCabes(iInvCabEN);
        }

        public List<InventarioCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvInv;
            List<InventarioCabeEN> iListaInventarioCabes = eLisLic;

            //ejecutar y retornar
            return InventarioCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaInventarioCabes);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("024", DgvInv.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AsignarInventarioCabe(InventarioCabeEN pIng)
        {
            pIng.ClaveInventarioCabe = Dgv.ObtenerValorCelda(this.DgvInv, InventarioCabeEN.ClaObj);
            pIng.CorrelativoInventarioCabe = Dgv.ObtenerValorCelda(this.DgvInv, InventarioCabeEN.CorInvCab);
        }

        public void AccionAdicionar()
        {           
            //instanciar
            wEditInventario win = new wEditInventario();
            win.wInv = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvInv = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iLicEN = this.EsActoModificarInventarioCabe();
            if (iLicEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditInventario win = new wEditInventario();
            win.wInv = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvInv = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iLicEN);
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
            InventarioCabeEN iLicEN = this.EsActoEliminarInventarioCabe();
            if (iLicEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditInventario win = new wEditInventario();
            win.wInv = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvInv = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iLicEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iCuoEN = this.EsInventarioCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditInventario win = new wEditInventario();
            win.wInv = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }

        public void AccionActualizarToma()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iInvCabEN = this.EsActoActualizarCantidad();
            if (iInvCabEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wActualizarTomaInventario win = new wActualizarTomaInventario();
            win.wInv = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionGeneraMovimientosAjuste()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iInvCabEN = this.EsActoGenerarMovimientosAjuste();
            if (iInvCabEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wAjusteInventario win = new wAjusteInventario();
            win.wInv = this;
            this.eFranjaDgvInv = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionTerminarProceso()
        {
            //validar
            InventarioCabeEN iInvCabEN = this.EsActoTerminarProceso();
            if (iInvCabEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Terminar proceso Inventario") == false) { return; }

            //cambiar el estado
            InventarioCabeRN.CambiarEstadoATerminado(iInvCabEN);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se termino el proceso para este Inventario", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionCambiarAProcesando()
        {
            //validar
            InventarioCabeEN iInvCabEN = this.EsActoCambiarAProcesando();
            if (iInvCabEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Poner a procesando el Inventario") == false) { return; }

            //cambiar el estado
            InventarioCabeRN.CambiarEstadoAProcesando(iInvCabEN);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se cambio a procesando para este Inventario", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionEliminarMovimientosAjuste()
        {
            //validar
            InventarioCabeEN iInvCabEN = this.EsActoEliminarMovimientosAjuste();
            if (iInvCabEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar movimientos ajustes") == false) { return; }

            //eliminar
            InventarioCabeRN.AccionEliminarMovimientosAjuste(iInvCabEN);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se eliminaron los movimientos de ajuste", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionImprimirParaToma()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iCuoEN = this.EsInventarioCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wImpExistenciaInventario win = new wImpExistenciaInventario();
            win.wInv = this;           
            TabCtrl.InsertarVentana(this, win, 94);
            win.NuevaVentana();
        }

        public void AccionImprimirToma()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iCuoEN = this.EsInventarioCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wImpExistenciaTomaInventario win = new wImpExistenciaTomaInventario();
            win.wInv = this;
            TabCtrl.InsertarVentana(this, win, 94);
            win.NuevaVentana();
        }

        public void AccionImprimirDiferenciaStock()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iCuoEN = this.EsInventarioCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wImpDiferenciaStock win = new wImpDiferenciaStock();
            win.wInv = this;
            TabCtrl.InsertarVentana(this, win, 94);
            win.NuevaVentana();
        }

        public void AccionImprimirAjusteIngreso()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iInvCabEN = this.EsInventarioCabeExistente();
            if (iInvCabEN.Adicionales.EsVerdad == false) { return; }

            //obtener el movimientoCabe del ingreso de mercaderias
            MovimientoCabeEN iMovCabEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(iInvCabEN.ClaveMovimientoIngreso);

            //si existe
            wImpNotaIngreso win = new wImpNotaIngreso();
            win.wInv = this;
            win.eVentana = wImpNotaIngreso.Ventana.wInventarios;
            win.NuevaVentana(iMovCabEN);
        }

        public void AccionImprimirAjusteSalida()
        {
            //preguntar si el registro seleccionado existe
            InventarioCabeEN iInvCabEN = this.EsInventarioCabeExistente();
            if (iInvCabEN.Adicionales.EsVerdad == false) { return; }

            //obtener el movimientoCabe del ingreso de mercaderias
            MovimientoCabeEN iMovCabEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(iInvCabEN.ClaveMovimientoSalida);

            //si existe
            wImpNotaSalida win = new wImpNotaSalida();
            win.wInv = this;
            win.eVentana = wImpNotaSalida.Ventana.wInventarios;
            win.NuevaVentana(iMovCabEN);
        }

        public InventarioCabeEN EsInventarioCabeExistente()
        {
            InventarioCabeEN iCuoEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iCuoEN);
            iCuoEN = InventarioCabeRN.EsInventarioCabeExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public InventarioCabeEN EsActoModificarInventarioCabe()
        {
            InventarioCabeEN iIngEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iIngEN);
            iIngEN = InventarioCabeRN.EsActoModificarInventarioCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public InventarioCabeEN EsActoEliminarInventarioCabe()
        {
            InventarioCabeEN iIngEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iIngEN);
            iIngEN = InventarioCabeRN.EsActoEliminarInventarioCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public InventarioCabeEN EsActoActualizarCantidad()
        {
            InventarioCabeEN iIngEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iIngEN);
            iIngEN = InventarioCabeRN.EsActoActualizarCantidad(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public InventarioCabeEN EsActoGenerarMovimientosAjuste()
        {
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iInvCabEN);
            iInvCabEN = InventarioCabeRN.EsActoGenerarMovimientosAjustes(iInvCabEN);
            if (iInvCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iInvCabEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iInvCabEN;
        }

        public InventarioCabeEN EsActoTerminarProceso()
        {
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iInvCabEN);
            iInvCabEN = InventarioCabeRN.EsActoTerminarProceso(iInvCabEN);
            if (iInvCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iInvCabEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iInvCabEN;
        }

        public InventarioCabeEN EsActoCambiarAProcesando()
        {
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iInvCabEN);
            iInvCabEN = InventarioCabeRN.EsActoCambiarAProcesando(iInvCabEN);
            if (iInvCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iInvCabEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iInvCabEN;
        }

        public InventarioCabeEN EsActoEliminarMovimientosAjuste()
        {
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();
            this.AsignarInventarioCabe(iInvCabEN);
            iInvCabEN = InventarioCabeRN.EsActoEliminarMovimientosAjuste(iInvCabEN);
            if (iInvCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iInvCabEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iInvCabEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteInventarios, null);
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvInv = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvInv = this.DgvInv.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvInv = this.DgvInv.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvInv, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvInv, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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


        private void wInventario_FormClosing(object sender, FormClosingEventArgs e)
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
            this.eFranjaDgvInv = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvInv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvInv, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvInv, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvInv, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvInv, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvInv, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvInv, Dgv.Desplazar.Ultimo);
        }

        private void DgvInv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvInv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void IteImpParTomInv_Click(object sender, EventArgs e)
        {
            this.AccionImprimirParaToma();
        }

        private void tsbActualizarToma_Click(object sender, EventArgs e)
        {
            this.AccionActualizarToma();
        }

        private void IteImpTomInv_Click(object sender, EventArgs e)
        {
            this.AccionImprimirToma();
        }

        private void IteImpDifSto_Click(object sender, EventArgs e)
        {
            this.AccionImprimirDiferenciaStock();
        }

        private void tsbGeneraMovimientosAjuste_Click(object sender, EventArgs e)
        {
            this.AccionGeneraMovimientosAjuste();
        }

        private void tsbTerminarProceso_Click(object sender, EventArgs e)
        {
            this.AccionTerminarProceso();
        }

        private void tsmiCambiarAProcesando_Click(object sender, EventArgs e)
        {
            this.AccionCambiarAProcesando();
        }

        private void tsmiEliminarMvimientosAjuste_Click(object sender, EventArgs e)
        {
            this.AccionEliminarMovimientosAjuste();
        }

        private void tsmiImpAjusteIngreso_Click(object sender, EventArgs e)
        {
            this.AccionImprimirAjusteIngreso();
        }

        private void tsmiImpAjusteSalida_Click(object sender, EventArgs e)
        {
            this.AccionImprimirAjusteSalida();
        }
    }
}
