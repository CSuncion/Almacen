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
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;

namespace Presentacion.Maestros
{
    public partial class wExistencia : Heredados.MiForm8
    {
        public wExistencia()
        {
            InitializeComponent();
        }

        //atributos
        string eNombreColumnaDgvExi = ExistenciaEN.ClaExi;
        string eEncabezadoColumnaDgvExi = "Clave";
        public string eClaveDgvExi = string.Empty;
        Dgv.Franja eFranjaDgvExi = Dgv.Franja.PorIndice;
        public List<ExistenciaEN> eLisExi = new List<ExistenciaEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Existencia";        

        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.ActualizarVentana();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaExistenciaesDeBaseDatos();
            this.ActualizarDgvExi();
            Dgv.HabilitarDesplazadores(this.DgvExi, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvExi, this.sst1);
        }

        public void ActualizarDgvExi()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvExi;
            List<ExistenciaEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvExi;
            string iClaveBusqueda = eClaveDgvExi;
            string iColumnaPintura = eNombreColumnaDgvExi;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvExi();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvExi()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.ClaExi, "Clave", 130));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.CodAlm, "Cod.Alma", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.DesAlm, "Nom.Almacen", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.CodExi, "Codigo", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.DesExi, "Descripcion", 350));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.NomUniMed, "Unid.Med", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ExistenciaEN.StoActExi, "Stock.Act", 70, 5));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.NCodUbi, "Des.Ubica", 80));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.NomMar, "Marca", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ExistenciaEN.StoMinExi, "Stock.Minimo", 80,5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ExistenciaEN.StoAleExi, "Stock.Alerta", 70, 5));           
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ExistenciaEN.PreProExi, "Precio.Pro", 80, 2));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.NEstExi, "Estado", 70));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaExistenciaesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            ExistenciaEN iPerEN = new ExistenciaEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvExi;            

            this.eLisExi = ExistenciaRN.ListarExistencias(iPerEN);
        }

        public List<ExistenciaEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvExi;
            List<ExistenciaEN> iLisPer = eLisExi;

            //ejecutar y retornar
            return ExistenciaRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("011", DgvExi.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AsignarExistencia(ExistenciaEN pObj)
        {
            pObj.ClaveExistencia = Dgv.ObtenerValorCelda(this.DgvExi, ExistenciaEN.ClaObj);
            pObj.CodigoExistencia = Dgv.ObtenerValorCelda(this.DgvExi, ExistenciaEN.CodExi);
            pObj.CodigoAlmacen = Dgv.ObtenerValorCelda(this.DgvExi, ExistenciaEN.CodAlm);
            pObj.DescripcionAlmacen = Dgv.ObtenerValorCelda(this.DgvExi, ExistenciaEN.DesAlm);
        }

        public void AccionAdicionar()
        {
            wEditExistencia win = new wEditExistencia();
            win.wExi = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvExi = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            ExistenciaEN iPerEN = this.EsActoModificarExistencia();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditExistencia win = new wEditExistencia();
            win.wExi = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvExi = Dgv.Franja.PorValor;
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
            ExistenciaEN iPerEN = this.EsActoEliminarExistencia();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditExistencia win = new wEditExistencia();
            win.wExi = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvExi = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            ExistenciaEN iPerEN = this.EsExistenciaExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditExistencia win = new wEditExistencia();
            win.wExi = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);
        }

        public void AccionAdicionarMasivo()
        {
            //si existe
            wAdicionarExistenciaMasivo win = new wAdicionarExistenciaMasivo();
            win.wExi = this;           
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionEliminarMasivo()
        {
            //si existe
            wEliminarExistenciaMasivo win = new wEliminarExistenciaMasivo();
            win.wExi = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionExportarExistencias()
        {
            //listar todas las existencias de la b.d            
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistencias();

            //declarar objetos de excel         
            Microsoft.Office.Interop.Excel.Application iAplicacion;
            Workbook iLibro;
            Worksheet iHoja;
            Range iRango;
            object iOpcional= System.Reflection.Missing.Value;

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

                iHoja.Cells.Item[1, 1] = "Existencias";

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo.Alm", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion.Alm", 35));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo.Exi", 16));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion.Exi", 35));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Unidad", 9));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Ubicacion", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Tipo", 20));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Sub.Clase", 20));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Produccion", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Marca", 13));                
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Centro.Costo", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Es.Lote", 8));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Stock.Minino", 14, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Stock.Alerta", 14, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Convierte.Uni", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Factor.Conver", 14, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Stock.Actual", 14, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Precio.Promedio", 17, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UnidadesxEmpaque", 20, 2));
                

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 2;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisExi.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //-----------------------------------------
                //llenando la matriz de datos para el excel
                //-----------------------------------------

                //matriz 
                object[,] objData = new Object[iEncExc.NumeroRegistros, 19];

                //indice para cada fila
                int iIndiceFila = -1;

                //recorrer cada objeto
                foreach (ExistenciaEN xExi in iLisExi)
                {
                    iIndiceFila++;
                    objData[iIndiceFila, 0] = xExi.CodigoAlmacen;
                    objData[iIndiceFila, 1] = xExi.DescripcionAlmacen;
                    objData[iIndiceFila, 2] = xExi.CodigoExistencia;
                    objData[iIndiceFila, 3] = xExi.DescripcionExistencia;
                    objData[iIndiceFila, 4] = xExi.NombreUnidadMedida;
                    objData[iIndiceFila, 5] = xExi.NCodigoUbicacion;
                    objData[iIndiceFila, 6] = xExi.NombreTipo;
                    objData[iIndiceFila, 7] = xExi.NombreGrupo;
                    objData[iIndiceFila, 8] = xExi.NEsProduccion;
                    objData[iIndiceFila, 9] = xExi.NombreMarca;
                    objData[iIndiceFila, 10] = xExi.NCentroCosto;
                    objData[iIndiceFila, 11] = xExi.NEsLote;
                    objData[iIndiceFila, 12] = xExi.StockMinimoExistencia;
                    objData[iIndiceFila, 13] = xExi.StockAlertaExistencia;
                    objData[iIndiceFila, 14] = xExi.NEsUnidadConvertida;
                    objData[iIndiceFila, 15] = xExi.FactorConversion;
                    objData[iIndiceFila, 16] = xExi.StockActualExistencia;
                    objData[iIndiceFila, 17] = xExi.PrecioPromedioExistencia;
                    objData[iIndiceFila, 18] = xExi.UnidadesPorEmpaque;                   
                }

                //insertar los datos al excel
                iRango = iHoja.get_Range("A3", iOpcional);
                iRango = iRango.get_Resize(iEncExc.NumeroRegistros, 19);
                iRango.set_Value(iOpcional, objData);

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

        public ExistenciaEN EsExistenciaExistente()
        {
            ExistenciaEN iPerEN = new ExistenciaEN();
            this.AsignarExistencia(iPerEN);
            iPerEN = ExistenciaRN.EsExistenciaExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public ExistenciaEN EsActoModificarExistencia()
        {
            ExistenciaEN iExiEN = new ExistenciaEN();
            this.AsignarExistencia(iExiEN);
            iExiEN = ExistenciaRN.EsActoModificarExistencia(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, eTitulo);
            }
            return iExiEN;
        }

        public ExistenciaEN EsActoEliminarExistencia()
        {
            ExistenciaEN iExiEN = new ExistenciaEN();
            this.AsignarExistencia(iExiEN);
            iExiEN = ExistenciaRN.EsActoEliminarExistencia(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, eTitulo);
            }
            return iExiEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteExistencias, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvExi = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvExi = this.DgvExi.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvExi = this.DgvExi.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvExi, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvExi, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
             
        private void wExistencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvExi = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvExi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvExi, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvExi, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvExi, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvExi, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvExi, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvExi, Dgv.Desplazar.Ultimo);
        }

        private void DgvExi_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvExi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void IteAdicionarMasivo_Click(object sender, EventArgs e)
        {
            this.AccionAdicionarMasivo();
        }

        private void IteEliminarMasivo_Click(object sender, EventArgs e)
        {
            this.AccionEliminarMasivo();
        }

        private void tsbExpExi_Click(object sender, EventArgs e)
        {
            this.AccionExportarExistencias();
        }
    }
}
