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
using Entidades.Estructuras;
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;

namespace Presentacion.Procesos
{
    public partial class wRetiquetado : Heredados.MiForm8
    {
        public wRetiquetado()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvRet = RetiquetadoEN.CorRet;
        string eEncabezadoColumnaDgvRet = "Numero";
        public string eClaveDgvRet = string.Empty;
        Dgv.Franja eFranjaDgvRet = Dgv.Franja.PorIndice;
        public List<RetiquetadoEN> eLisRet = new List<RetiquetadoEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Retiquetado";

        #endregion


        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.MostrarFiltroXDefecto();
            this.ActualizarVentana();
        }

        public void MostrarFiltroXDefecto()
        {
            tslCodFil.Text = "0";
            tslNomFil.Text = "Pendiente";
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaRetiquetadosDeBaseDatos();
            this.ActualizarDgvRet();
            Dgv.HabilitarDesplazadores(this.DgvRet, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvRet, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvRet;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvRet()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvRet;
            List<RetiquetadoEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvRet;
            string iClaveBusqueda = eClaveDgvRet;
            string iColumnaPintura = eNombreColumnaDgvRet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvRet();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvRet()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoEN.CorRet, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoEN.FecRet, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoEN.CodExiPT, "Cod.Exi.PT", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoEN.DesExiPT, "Des.Exi.PT", 270));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoEN.CodExiRE, "Cod.Exi.RET", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoEN.DesExiRE, "Des.Exi.RET", 270));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoEN.NEstRet, "Estado", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaRetiquetadosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            RetiquetadoEN iCuoEN = new RetiquetadoEN();
            iCuoEN.CEstadoRetiquetado = tslCodFil.Text;          
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvRet;
            this.eLisRet = RetiquetadoRN.ListarRetiquetadoXEstado(iCuoEN);
        }

        public List<RetiquetadoEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvRet;
            List<RetiquetadoEN> iListaRetiquetados = eLisRet;

            //ejecutar y retornar
            return RetiquetadoRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaRetiquetados);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("042", DgvRet.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AsignarRetiquetado(RetiquetadoEN pIng)
        {
            pIng.ClaveRetiquetado = Dgv.ObtenerValorCelda(this.DgvRet, RetiquetadoEN.ClaObj);
            pIng.CorrelativoRetiquetado = Dgv.ObtenerValorCelda(this.DgvRet, RetiquetadoEN.CorRet);
        }

        public void AccionAdicionar()
        {           
            //instanciar
            wEditRetiquetado win = new wEditRetiquetado();
            win.wRet = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvRet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            RetiquetadoEN iProCabEN = this.EsActoModificarRetiquetado();
            if (iProCabEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditRetiquetado win = new wEditRetiquetado();
            win.wRet = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvRet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iProCabEN);
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
            RetiquetadoEN iProCabEN = this.EsActoEliminarRetiquetado();
            if (iProCabEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditRetiquetado win = new wEditRetiquetado();
            win.wRet = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvRet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iProCabEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            RetiquetadoEN iCuoEN = this.EsRetiquetadoExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditRetiquetado win = new wEditRetiquetado();
            win.wRet = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }

        public void AccionListarInsumosParaRetiquetado()
        {
            //listar existencias con el stock para esta compra            
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosDetalladoParaEncajar();

            //declarar objetos de excel         
            Microsoft.Office.Interop.Excel.Application iAplicacion;
            Workbook iLibro;
            Worksheet iHoja;

            //creamos una nueva aplicacion excel
            iAplicacion = new Microsoft.Office.Interop.Excel.Application();

            //adicionamos el libro a la aplicacion
            iLibro = iAplicacion.Workbooks.Add();

            //obtener la hoja 1 del libro
            iHoja = iLibro.Worksheets["Hoja1"];

            //dando el zoom predeterminado a la hoja
            iAplicacion.ActiveWindow.Zoom = 73;

            try
            {

                //-----------------
                //llenando cabecera
                //-----------------

                iHoja.Cells.Item[1, 1] = "Lista para Retiquetado";

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Retiquetado", 15));               
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo.For", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion.For", 50));                
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Linea", 7));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Almacen", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion", 45));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Unidad", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Insumos", 14, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Stock", 14, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Faltante", 14, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Comprar", 10));                
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("STK.Actual", 14, 5));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 2;             
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisInsFal.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 2;

                //recorrer cada objeto
                foreach (InsumoFaltante xInsFal in iLisInsFal)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xInsFal.CodigoSolicitud;                  
                    iHoja.Cells.Item[iIndiceFila, 2] = xInsFal.CodigoFormula;
                    iHoja.Cells.Item[iIndiceFila, 3] = xInsFal.DescripcionFormula;                 
                    iHoja.Cells.Item[iIndiceFila, 4] = xInsFal.CodigoLinea;
                    iHoja.Cells.Item[iIndiceFila, 5] = xInsFal.CodigoAlmacen;
                    iHoja.Cells.Item[iIndiceFila, 6] = xInsFal.CodigoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 7] = xInsFal.DescripcionExistencia;
                    iHoja.Cells.Item[iIndiceFila, 8] = xInsFal.NUnidadMedida;
                    iHoja.Cells.Item[iIndiceFila, 9] = xInsFal.CantidadParteTrabajo;
                    iHoja.Cells.Item[iIndiceFila, 10] = xInsFal.CantidadStockExistencia;
                    iHoja.Cells.Item[iIndiceFila, 11] = xInsFal.CantidadFaltante;
                    iHoja.Cells.Item[iIndiceFila, 12] = (xInsFal.CantidadFaltante == 0) ? "" : "si";                   
                    iHoja.Cells.Item[iIndiceFila, 13] = xInsFal.CantidadStockExistencia - xInsFal.CantidadParteTrabajo;
                }

                //ver el excel
                iAplicacion.Application.Visible = true;

            }
            catch (Exception ex)
            {
                Mensaje.OperacionDenegada(ex.Message, "Error");
            }
            finally
            {
                //liberamos recursos
                MiExcel.LiberarObjetoCom(iAplicacion);
                MiExcel.LiberarObjetoCom(iLibro);
                MiExcel.LiberarObjetoCom(iHoja);
            }
        }

        public void AccionSalidaInsumosFaseEmpaquetado()
        {
            //preguntar si el registro seleccionado existe
            RetiquetadoEN iRetEN = this.EsRetiquetadoExistente();
            if (iRetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wSalidaFaseEmpaquetadoRE win = new wSalidaFaseEmpaquetadoRE();
            win.wRet = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iRetEN);
        }

        public void AccionSalidaParaEmpaquetar()
        {
            //preguntar si el registro seleccionado existe
            RetiquetadoEN iProDetEN = this.EsRetiquetadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wSalidaUnidadesEmpacarRE win = new wSalidaUnidadesEmpacarRE();
            win.wRet = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iProDetEN);
        }

        public void AccionIngresoMercaderia()
        {
            //preguntar si el registro seleccionado existe
            RetiquetadoEN iProDetEN = this.EsRetiquetadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wIngresoMercaderiasRE win = new wIngresoMercaderiasRE();
            win.wRet = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iProDetEN);
        }

        public void AccionTerminarProceso()
        {
            //validar
            RetiquetadoEN iProDetEN = this.EsActoTerminarProcesoRetiquetado();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Terminar proceso Plan Retiquetado") == false) { return; }

            //cambiar el estado
            //RetiquetadoRN.CambiarEstadoATerminado(iProDetEN);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se termino el proceso para este Plan Retiquetado", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionFiltrarEstado()
        {
            //instanciar   
            wFiltraEstado win = new wFiltraEstado();
            win.wRet = this;
            win.eVentana = wFiltraEstado.Ventana.wRetiquetado;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public RetiquetadoEN EsRetiquetadoExistente()
        {
            RetiquetadoEN iCuoEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iCuoEN);
            iCuoEN = RetiquetadoRN.EsRetiquetadoExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public RetiquetadoEN EsActoModificarRetiquetado()
        {
            RetiquetadoEN iIngEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iIngEN);
            iIngEN = RetiquetadoRN.EsActoModificarRetiquetado(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public RetiquetadoEN EsActoEliminarRetiquetado()
        {
            RetiquetadoEN iIngEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iIngEN);
            iIngEN = RetiquetadoRN.EsActoEliminarRetiquetado(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public RetiquetadoEN EsActoIngresarProductosTerminados()
        {
            RetiquetadoEN iIngEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iIngEN);
            //iIngEN = RetiquetadoRN.EsActoIngresarProductoTerminado(iIngEN);
            //if (iIngEN.Adicionales.EsVerdad == false)
            //{
            //    Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            //}
            return iIngEN;
        }

        public RetiquetadoEN EsActoTerminarProcesoRetiquetado()
        {
            RetiquetadoEN iIngEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iIngEN);
            //iIngEN = RetiquetadoRN.EsActoTerminarProcesoRetiquetado(iIngEN);
            //if (iIngEN.Adicionales.EsVerdad == false)
            //{
            //    Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            //}
            return iIngEN;
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvRet = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvRet = this.DgvRet.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvRet = this.DgvRet.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvRet, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvRet, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            //wMen.CerrarVentanaHijo(this, wMen.IteRetiquetado, wMen.tsbRetiquetado);
        }


        #endregion


        private void wRetiquetado_FormClosing(object sender, FormClosingEventArgs e)
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
            this.eFranjaDgvRet = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvRet_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvRet, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvRet, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvRet, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvRet, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvRet, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvRet, Dgv.Desplazar.Ultimo);
        }

        private void DgvRet_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvRet_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            this.AccionFiltrarEstado();
        }
        
        private void tsbSalidaFaseEmpaquetado_Click(object sender, EventArgs e)
        {
            this.AccionSalidaInsumosFaseEmpaquetado();
        }

        private void tsbSalidaUniEmp_Click(object sender, EventArgs e)
        {
            this.AccionSalidaParaEmpaquetar();
        }

        private void tsbIngresoMercaderia_Click(object sender, EventArgs e)
        {
            this.AccionIngresoMercaderia();
        }

        private void tsbTerminarProceso_Click(object sender, EventArgs e)
        {
            this.AccionTerminarProceso();
        }


    }
}
