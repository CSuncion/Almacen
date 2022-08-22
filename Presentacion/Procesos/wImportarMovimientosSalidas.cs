using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.Listas;
using Presentacion.Principal;
using Presentacion.Maestros;
using Presentacion.FuncionesGenericas;
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;
 


namespace Presentacion.Procesos
{
    public partial class wImportarMovimientosSalidas : Heredados.MiForm8
    {
        public wImportarMovimientosSalidas()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Movimiento Salida";
        List<MovimientoDetaEN> eLisMovDet = new List<MovimientoDetaEN>();
        List<ErrorCeldaExcel> eLisErr = new List<ErrorCeldaExcel>();

        #endregion

        #region Propietario

        public wSalidas wSal;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnBusArcExc, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbHoj, "Hoja", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnValidar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbError, "Error", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General


        public void InicializaVentana()
        {            
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //valores por defecto
            this.ValoresXDefecto();

            //Deshabilitar al propietario de esta ventana
            this.wSal.Enabled = false;

            //Mostrar ventana        
            this.Show();
        }
             
        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.ActualizarVentana();
            eMas.AccionPasarTextoPrincipal();
            this.btnBusArcExc.Focus();
        }

        public void ValoresXDefecto()
        {
            txtPerMovCab.Text = wSal.lblDescripcionPeriodo.Text;
        }

        public void ActualizarVentana()
        {
            this.ActualizarDgvMovDet();
            this.MostrarTituloDgvMovDet();
            this.CargarErrores();
            this.ActualizarDgvErr();
            this.HabilitarControles();
        }

        public void ActualizarDgvMovDet()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvAux;
            List<MovimientoDetaEN> iFuenteDatos = this.eLisMovDet;
            Dgv.Franja iCondicionFranja =  Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty  ;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMovDet();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMovDet()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodEmp, "Empresa", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.FecMovCab, "Fecha", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodAux, "Cliente", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.PerMovCab, "Periodo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodAlm, "Almacen", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodTipOpe, "TipoOpe", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodExi, "Cod.Exi", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CanMovDet, "Cantidad", 80, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void MostrarTituloDgvMovDet()
        {
            //asignar parametros
            string iTexto1 = "Registros a importar";            
            string iTexto2 = "# : " + this.dgvAux.Rows.Count;
            string iSeparador = "/";

            //ejecutar metodo
            string iTextoFormato = Formato.UnionDosTextos(iTexto1, iTexto2, iSeparador);

            //mostrar
            this.lblRegImp.Text = iTextoFormato;
        }

        public void ActualizarDgvErr()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvErr;
            List<ErrorCeldaExcel> iFuenteDatos = MiExcel.FiltrarPorTipoError(this.eLisErr, Cmb.ObtenerValor(this.cmbError,""));
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvErr();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvErr()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena("Celda", "Celda", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena("MensajeErrorCelda", "Error", 390));

            //devolver
            return iLisRes;
        }

        public void HabilitarControles()
        {
            this.btnExportar.Enabled = Cadena.CompararDosValores(this.dgvErr.Rows.Count, 0, false, true);
            this.btnAceptar.Enabled = Cadena.CompararDosValores(this.dgvAux.Rows.Count, 0, false, true);
            this.cmbError.Enabled = Cadena.CompararDosValores(this.dgvErr.Rows.Count, 0, false, true);
        }

        public void BuscarExcel()
        {
            //asignar parametros
            OpenFileDialog win = new OpenFileDialog();
            System.Windows.Forms.TextBox iControlRuta = txtArcExc;
            ComboBox iControlHojas = cmbHoj;
            
            //ejecutar metodo
            MiControl.MostrarRutaYHojasExcel(win, iControlRuta, iControlHojas);
        }

        public void Validar()
        {
            //campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //actualizar la lista de errores
            this.ActualizarListaErroresExcel();

            //actualizar la lista de registros a importar
            this.ActualizarListaMovimientosDetaAImportar();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void Aceptar()
        {
            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Importar") == false) { return; }

            //importar
            MovimientoCabeRN.ImportarSalidasDeExcel(this.eLisMovDet);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se importaron los registros correctamente", this.eTitulo);

            //actualizar al propietario
            this.wSal.ActualizarVentana();

            //cerrar esta ventana
            this.Close();
        }

        public void ActualizarListaMovimientosDetaAImportar()
        {
            //asignar parametro
            List<MovimientoDetaEN> iLisMovDet = this.TransformarExcelAListaMovimientosDeta();

            //ejecutar metodo
            //AuxiliarRN.ActualizarAuxiliaresImportacionExcelParaGrabar(iLisMovDet);

            //pasar a la lista externa
            this.eLisMovDet = iLisMovDet;
        }

        public List<MovimientoDetaEN> TransformarExcelAListaMovimientosDeta()
        {
            //obtener la hoja de la lectura de agua
            Worksheet iHoja = this.ObtenerHojaExcel();

            //lista de movimientos deta transformadas
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //recorrer cada fila del excel
            for (int i = 2; i < 100000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["A" + i].Value;
                if (iNulo == null) { break; }
                
                //si el indice fila existe en la lista de errores, entonces este registro no se carga
                if(MiExcel.ExisteIndiceFila(this.eLisErr, i.ToString()) == true) { continue; }

                //creamos un nuevo objeto MovimientoDeta
                MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

                //actualizamos datos
                iMovDetEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovDetEN.FechaMovimientoCabe = iHoja.Range["C" + i].Text;
                iMovDetEN.OrdenCompra = iHoja.Range["D" + i].Text;
                iMovDetEN.PeriodoMovimientoCabe = iHoja.Range["F" + i].Text;
                iMovDetEN.CodigoAlmacen = iHoja.Range["G" + i].Text;
                iMovDetEN.CodigoTipoOperacion = iHoja.Range["I" + i].Text;
                iMovDetEN.CodigoAuxiliar = iHoja.Range["L" + i].Text;
                iMovDetEN.DescripcionAuxiliar = iHoja.Range["M" + i].Text;
                iMovDetEN.CTipoDocumento = iHoja.Range["N" + i].Text;
                iMovDetEN.SerieDocumento = iHoja.Range["P" + i].Text;
                iMovDetEN.NumeroDocumento = iHoja.Range["Q" + i].Text;
                iMovDetEN.FechaDocumento = iHoja.Range["R" + i].Text;
                iMovDetEN.CodigoCentroCosto = iHoja.Range["S" + i].Text;
                iMovDetEN.CodigoExistencia = iHoja.Range["U" + i].Text;
                iMovDetEN.CantidadMovimientoDeta = Convert.ToDecimal(iHoja.Range["X" + i].Value2);               
                iMovDetEN.PrecioUnitarioMovimientoDeta = Convert.ToDecimal(iHoja.Range["Y" + i].Value2);
                iMovDetEN.CostoMovimientoDeta = Convert.ToDecimal(iHoja.Range["Z" + i].Value2);
                iMovDetEN.GlosaMovimientoDeta = iHoja.Range["AA" + i].Text;
                
                //insertar a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //destruor ala hoja
            MiExcel.EliminarHojaExcel(iHoja);

            //devolver
            return iLisRes;
        }

        public Worksheet ObtenerHojaExcel()
        {
            //asignar parametros
            string iRutaArchivoExcel = txtArcExc.Text.Trim();          
            string iHojaExcel = MiExcel.ObtenerNombreHoja(this.cmbHoj.Text);
           
            //ejecutar metodo
            return MiExcel.ObtenerHojaExcel(iRutaArchivoExcel, iHojaExcel);          
        }

        public int ObtenerNumeroRegistrosExcel(Worksheet pHoja)
        {
            //asignar parametros
            string iColumnaClave = "B";
            int iIndiceFilaInicia = 2;
            Worksheet iHoja = pHoja;

            //ejecutar metodo
            return MiExcel.ObtenerNumeroCeldasConDatos(iColumnaClave, iIndiceFilaInicia, iHoja);        
        }

        public void CargarErrores()
        {
            Cmb.Cargar(this.cmbError, MiExcel.ListarTiposErroresDistintos(this.eLisErr), "Codigo", "Descripcion");
        }

        public void ExportarExcel()
        {
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

                iHoja.Cells.Item[1, 1] = "Error :  " + this.cmbError.Text.Trim();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();              
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Celda", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Error", 70));                

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 2;
                iEncExc.Color = Color.GreenYellow;
                iEncExc.NumeroRegistros = this.dgvErr.Rows.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 2;

                //recorrer cada objeto
                foreach (DataGridViewRow xInsFal in this.dgvErr.Rows)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xInsFal.Cells[0].Value;
                    iHoja.Cells.Item[iIndiceFila, 2] = xInsFal.Cells[1].Value;

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

        public void ActualizarListaErroresExcel()
        {
            this.eLisErr = this.ListarErroresCeldasExcel();
        }

        public List<ErrorCeldaExcel> ListarErroresCeldasExcel()
        {
            //lista resultado
            List<ErrorCeldaExcel> iLisRes = new List<ErrorCeldaExcel>();

            //traer la hoja que se quiere importar
            Worksheet iHoja = this.ObtenerHojaExcel();

            //obtener el numero de registros del excel
            int iNumeroRegistros = this.ObtenerNumeroRegistrosExcel(iHoja);

            //lista de codigos de almacen de la empresa
            List<string> iListaAlmacenes = AlmacenRN.ListarCodigosAlmacenes();

            //lista de codigos de tipos de operacion
            List<string> iListaTiposOperacion = TipoOperacionRN.ListarCodigosTiposOperacion();

            //lista de codigos tipos de documentos
            List<string> iListaTiposDocumentos = ItemGRN.ListarCodigosItems("TipCom");

            //lista de claves de existencias
            List<string> iListaClavesExistencias = ExistenciaRN.ListarClavesExistencias();
                       
            //lista de codigos de Si No
            List<string> ilistaSiNo = ItemGRN.ListarCodigosItems("SiNo");

            //declaracion de objeto error
            ErrorCeldaExcel iErr;

            //recorrer cada fila del excel
            for (int i = 2; i < 100000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["A" + i].Value;
                if (iNulo == null) { break; }

                //validar valor igual a
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorComparacion("CodigoEmpresa", Universal.gCodigoEmpresa, "A" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacio("Fecha Movimiento", "C" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacio("Orden Venta", "D" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar valor igual a
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorComparacion("Periodo", this.wSal.lblPeriodo.Text, "F" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }
                
                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("CodigoAlmacen", "G" + i, iListaAlmacenes, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("CodigoTipoOperacion", "I" + i, iListaTiposOperacion, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacio("Ruc Cliente", "L" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Tipo Documento", "N" + i, iListaTiposDocumentos, iHoja, false);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar codigo inexistente 
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorCodigoInexistente("Codigo Almacen", "G" + i, "Existencia", "U" + i, iListaClavesExistencias, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacio("Cantidad", "X" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar valor decimal
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorTipoDatoDecimalPositivoSinCero("Cantidad", "X" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacio("Valor Unitario", "Y" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar valor decimal
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorTipoDatoDecimalPositivoSinCero("Valor Unitario", "Y" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar dato vacio
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorDatoVacio("Costo", "Z" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }

                //validar valor decimal
                iErr = new ErrorCeldaExcel();
                iErr = MiExcel.ObtenerErrorExcelPorTipoDatoDecimalPositivoSinCero("Costo", "Z" + i, iHoja);
                if (iErr.Celda != string.Empty) { iLisRes.Add(iErr); }
            }

            ////listar errores al validar las claves repetidas en el excel(Codigo)
            //iLisRes.AddRange(this.ListarErroresPorClavesRepetidasEnExcel(iHoja, iNumeroRegistros));

            //eliminar la hoja excel
            MiExcel.EliminarHojaExcel(iHoja);

            //devolver
            return iLisRes;
        }
        
        public List<ErrorCeldaExcel> ListarErroresPorClavesRepetidasEnExcel(Worksheet pHoja, int pNumeroRegistros)
        {
            //asignar parametros
            string iColumnaClave = "B";
            int iIndiceFilaInicia = 2;
            int iNumeroRegistros = pNumeroRegistros;
            string iNombreCampo = "Numero";
            
            //ejectuar metodo
            return MiExcel.ListarErroresExcelPorClavesRepetidasExcel(iColumnaClave, iIndiceFilaInicia, iNumeroRegistros, pHoja, iNombreCampo);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }


        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void wImportarAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wSal.Enabled = true;
        }

        private void btnBusArcExc_Click(object sender, EventArgs e)
        {
            this.BuscarExcel();         
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            this.Validar();
        }

        private void cmbError_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ActualizarDgvErr();
            this.HabilitarControles();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.ExportarExcel();
        }
    }
}
