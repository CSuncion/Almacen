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
    public partial class wPlanEncajado : Heredados.MiForm8
    {
        public wPlanEncajado()
        {
            InitializeComponent();
        }

        //Atributos
        string eNombreColumnaDgvProCab = EncajadoEN.CorEnc;
        string eEncabezadoColumnaDgvProCab = "Numero";
        public string eClaveDgvProCab = string.Empty;
        Dgv.Franja eFranjaDgvProCab = Dgv.Franja.PorIndice;
        public List<EncajadoEN> eLisEnc = new List<EncajadoEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Plan Packing";

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
            this.ActualizarListaEncajadosDeBaseDatos();
            this.ActualizarDgvProCab();
            Dgv.HabilitarDesplazadores(this.DgvProCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvProCab, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvProCab;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvProCab()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvProCab;
            List<EncajadoEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvProCab;
            string iClaveBusqueda = eClaveDgvProCab;
            string iColumnaPintura = eNombreColumnaDgvProCab;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvProCab();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvProCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(EncajadoEN.CorEnc, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(EncajadoEN.FecEnc, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(EncajadoEN.DesEnc, "Descripcion", 250));          
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(EncajadoEN.NEstEnc, "Estado", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(EncajadoEN.CEstEnc, "Cod.Est", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(EncajadoEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaEncajadosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            EncajadoEN iCuoEN = new EncajadoEN();
            iCuoEN.CEstadoEncajado = tslCodFil.Text;          
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvProCab;
            this.eLisEnc = EncajadoRN.ListarEncajadoXEstado(iCuoEN);
        }

        public List<EncajadoEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvProCab;
            List<EncajadoEN> iListaEncajados = eLisEnc;

            //ejecutar y retornar
            return EncajadoRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaEncajados);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("041", DgvProCab.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AsignarEncajado(EncajadoEN pIng)
        {
            pIng.ClaveEncajado = Dgv.ObtenerValorCelda(this.DgvProCab, EncajadoEN.ClaObj);
            pIng.CorrelativoEncajado = Dgv.ObtenerValorCelda(this.DgvProCab, EncajadoEN.CorEnc);
        }

        public void AccionAdicionar()
        {           
            //instanciar
            wEditEncajado win = new wEditEncajado();
            win.wEnc = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvProCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iProCabEN = this.EsActoModificarEncajado();
            if (iProCabEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditEncajado win = new wEditEncajado();
            win.wEnc = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvProCab = Dgv.Franja.PorValor;
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
            EncajadoEN iProCabEN = this.EsActoEliminarEncajado();
            if (iProCabEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditEncajado win = new wEditEncajado();
            win.wEnc = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvProCab = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iProCabEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iCuoEN = this.EsEncajadoExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditEncajado win = new wEditEncajado();
            win.wEnc = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }

        public void AccionListarPlanificacionEncajadoDetalladoLiberacion()
        {
            //listar planificacion encajado            
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerParaPlanificacionEncajadoDetalleLiberacion();

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

                iHoja.Cells.Item[1, 1] = "Planificacion encajado";

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Cod.Encajado", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fc.Encajado", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo.PT", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion.PT", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Prioridad", 9));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Unidades", 14, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Cajas", 14, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Parte Trabajo", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fc.Produccion", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fc.Vcto", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Observacion", 50));                

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 2;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisProProTer.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 2;

                //recorrer cada objeto
                foreach (ProduccionProTerEN xProProTer in iLisProProTer)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xProProTer.CorrelativoEncajado;
                    iHoja.Cells.Item[iIndiceFila, 2] = xProProTer.FechaEncajado;
                    iHoja.Cells.Item[iIndiceFila, 3] = xProProTer.CodigoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 4] = xProProTer.DescripcionExistencia;
                    iHoja.Cells.Item[iIndiceFila, 5] = xProProTer.CorrelativoProduccionProTer;
                    iHoja.Cells.Item[iIndiceFila, 6] = xProProTer.CantidadUnidadesProTer;
                    iHoja.Cells.Item[iIndiceFila, 7] = xProProTer.NumeroCajas;
                    iHoja.Cells.Item[iIndiceFila, 8] = xProProTer.ClaveProduccionDeta; //Parte de trabajo
                    iHoja.Cells.Item[iIndiceFila, 9] = xProProTer.FechaLoteProTer;
                    iHoja.Cells.Item[iIndiceFila, 10] = xProProTer.FechaVctoProTer;
                    iHoja.Cells.Item[iIndiceFila, 11] = xProProTer.ObservacionProTer;                    
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

        public void AccionListarPlanificacionEncajado()
        {
            //listar planificacion encajado            
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerParaPlanificacionEncajado();

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

                iHoja.Cells.Item[1, 1] = "Planificacion encajado";

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Cod.Encajado", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fc.Encajado", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo.PT", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion.PT", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Prioridad", 9));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Unidades", 14, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Cajas", 14, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fc.Produccion", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fc.Vcto", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Observacion", 50));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 2;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisProProTer.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 2;

                //recorrer cada objeto
                foreach (ProduccionProTerEN xProProTer in iLisProProTer)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xProProTer.CorrelativoEncajado;
                    iHoja.Cells.Item[iIndiceFila, 2] = xProProTer.FechaEncajado;
                    iHoja.Cells.Item[iIndiceFila, 3] = xProProTer.CodigoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 4] = xProProTer.DescripcionExistencia;
                    iHoja.Cells.Item[iIndiceFila, 5] = xProProTer.CorrelativoProduccionProTer;
                    iHoja.Cells.Item[iIndiceFila, 6] = xProProTer.CantidadUnidadesProTer;
                    iHoja.Cells.Item[iIndiceFila, 7] = xProProTer.NumeroCajas;
                    iHoja.Cells.Item[iIndiceFila, 8] = xProProTer.FechaLoteProTer;
                    iHoja.Cells.Item[iIndiceFila, 9] = xProProTer.FechaVctoProTer;
                    iHoja.Cells.Item[iIndiceFila, 10] = xProProTer.ObservacionProTer;
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

        public void AccionListarInsumosParaEncajado()
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

                iHoja.Cells.Item[1, 1] = "Lista para encajado";

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Encajado", 15));               
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
            EncajadoEN iProDetEN = this.EsEncajadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wProTerFaseEmpaquetado win = new wProTerFaseEmpaquetado();
            win.wPlaEnc = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionSalidaParaEmpaquetar()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iProDetEN = this.EsEncajadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wSalidaProduccionAnterior win = new wSalidaProduccionAnterior();
            win.wEnc = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iProDetEN);
        }

        public void AccionSalidaParaEmpaquetarObservados()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iProDetEN = this.EsEncajadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wSalidaProduccionAnteriorObs win = new wSalidaProduccionAnteriorObs();
            win.wEnc = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iProDetEN);
        }

        public void AccionSalidaParaEmpaquetarCuarentena()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iProDetEN = this.EsEncajadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wSalidaProduccionAnteriorCua win = new wSalidaProduccionAnteriorCua();
            win.wEnc = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iProDetEN);
        }

        public void AccionCantidadReal()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iProDetEN = this.EsEncajadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wCantidadReal win = new wCantidadReal();
            win.wPlaEnc = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionSegundaLiberacion()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iProDetEN = this.EsEncajadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wSegundaLiberacion win = new wSegundaLiberacion();
            win.wPlaEnc = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionCantidadAdicionalEncajado()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iProDetEN = this.EsEncajadoExistente();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wCantidadAdicionalEncajado win = new wCantidadAdicionalEncajado();
            win.wPlaEnc = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }



        public void AccionIngresoMercaderia()
        {
            //preguntar si el registro seleccionado existe
            EncajadoEN iProDetEN = this.EsActoIngresarProductosTerminados();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wIngresoMercaderias win = new wIngresoMercaderias();
            win.wEnc = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iProDetEN);
        }

        public void AccionTerminarProceso()
        {
            //validar
            EncajadoEN iProDetEN = this.EsActoTerminarProcesoEncajado();
            if (iProDetEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Terminar proceso Plan Encajado") == false) { return; }

            //cambiar el estado
            EncajadoRN.CambiarEstadoATerminado(iProDetEN);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se termino el proceso para este Plan Encajado", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionFiltrarEstado()
        {
            //instanciar   
            wFiltraEstado win = new wFiltraEstado();
            win.wEnc = this;
            win.eVentana = wFiltraEstado.Ventana.wPlanEncajado;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public EncajadoEN EsEncajadoExistente()
        {
            EncajadoEN iCuoEN = new EncajadoEN();
            this.AsignarEncajado(iCuoEN);
            iCuoEN = EncajadoRN.EsEncajadoExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public EncajadoEN EsActoModificarEncajado()
        {
            EncajadoEN iIngEN = new EncajadoEN();
            this.AsignarEncajado(iIngEN);
            iIngEN = EncajadoRN.EsActoModificarEncajado(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public EncajadoEN EsActoEliminarEncajado()
        {
            EncajadoEN iIngEN = new EncajadoEN();
            this.AsignarEncajado(iIngEN);
            iIngEN = EncajadoRN.EsActoEliminarEncajado(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public EncajadoEN EsActoIngresarProductosTerminados()
        {
            EncajadoEN iIngEN = new EncajadoEN();
            this.AsignarEncajado(iIngEN);
            iIngEN = EncajadoRN.EsActoIngresarProductoTerminado(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public EncajadoEN EsActoTerminarProcesoEncajado()
        {
            EncajadoEN iIngEN = new EncajadoEN();
            this.AsignarEncajado(iIngEN);
            iIngEN = EncajadoRN.EsActoTerminarProcesoEncajado(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            //wMen.CerrarVentanaHijo(this, wMen.ItePlanEncajado, wMen.tsbPlanEncajado);
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvProCab = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvProCab = this.DgvProCab.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvProCab = this.DgvProCab.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProCab, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProCab, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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


        private void wPlanEncajado_FormClosing(object sender, FormClosingEventArgs e)
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
            this.eFranjaDgvProCab = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvProCab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvProCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvProCab, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProCab, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProCab, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProCab, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProCab, Dgv.Desplazar.Ultimo);
        }

        private void DgvProCab_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvProCab_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void tsbPlaCom_Click(object sender, EventArgs e)
        {
            this.AccionListarInsumosParaEncajado();
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

        private void tsbPlaEnc_Click(object sender, EventArgs e)
        {
            this.AccionListarPlanificacionEncajado();
        }

        private void tsbCantidadReal_Click(object sender, EventArgs e)
        {
            this.AccionCantidadReal();
        }

        private void tsbPlaEncDetLib_Click(object sender, EventArgs e)
        {
            this.AccionListarPlanificacionEncajadoDetalladoLiberacion();
        }

        private void tsbSalidaUniEmpObs_Click(object sender, EventArgs e)
        {
            this.AccionSalidaParaEmpaquetarObservados();
        }

        private void tsbAdicionales_Click(object sender, EventArgs e)
        {
            this.AccionCantidadAdicionalEncajado();            
        }

        private void tsbSalidaUniEmpCua_Click(object sender, EventArgs e)
        {
            this.AccionSalidaParaEmpaquetarCuarentena();
        }

        private void tsbSegundaLiberacion_Click(object sender, EventArgs e)
        {
            this.AccionSegundaLiberacion();
        }
    }
}
