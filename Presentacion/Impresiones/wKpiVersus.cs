using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Comun;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Negocio;
using Entidades;
using Presentacion.FuncionesGenericas;
using Presentacion.Principal;
using CrystalDecisions.CrystalReports.Engine;
using Presentacion.Impresiones;
using Entidades.Estructuras;
using Presentacion.Listas;
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;

namespace Presentacion.Impresiones
{
    public partial class wKpiVersus : Heredados.MiForm8
    {
        public wKpiVersus()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();

        #endregion
        
        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDes, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecHas, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExiPT, true, "Existencia SE", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExiPT, this.txtDesExiPT, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnExportar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnSalir, "vvvv");
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

            //mostrar ventana
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();                
            this.dtpFecDes.Focus();
        }

        public List<KpiVersus> ObtenerReporte()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.Adicionales.Desde1 = this.dtpFecDes.Text;
            iProDetEN.Adicionales.Hasta1 = this.dtpFecHas.Text;
            iProDetEN.CodigoSemiProducto = this.txtCodExiPT.Text.Trim();

            //ejecutar metodo
            return ProduccionDetaRN.ObtenerReporteKpiVersus(iProDetEN);
        }

        public string ObtenerTextoRangoFecha()
        {
            //valor resultado
            string iValor = string.Empty;

            //armar texto
            iValor += "DESDE : " + Fecha.ObtenerDiaMesAno(this.dtpFecDes.Text);
            iValor+= " HASTA : " + Fecha.ObtenerDiaMesAno(this.dtpFecHas.Text);

            //devolver
            return iValor;
        }

        public string ObtenerTextoProducto()
        {
            //valor resultado
            string iValor = string.Empty;

            //armar texto
            iValor += "PRODUCTO : " + Cadena.CompararDosValores(this.txtCodExiPT.Text, string.Empty, "TODOS", this.txtCodExiPT.Text+ " - " +
                this.txtDesExiPT.Text);
            
            //devolver
            return iValor;
        }

        public void EjecutarExcel()
        {
            if (this.eMas.CamposObligatorios() == false) { return; }
            this.ExportarExcel();
        }

        public void ExportarExcel()
        {
            //declarar objetos de excel         
            Microsoft.Office.Interop.Excel.Application iAplicacion;
            Workbook iLibro;
            Worksheet iHoja;
            Range iRango;
            object iOpcional = System.Reflection.Missing.Value;

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

                iHoja.Cells.Item[1, 1] = "KPI UNIDADES PLANIFICADAS Y REALES POR FECHAS";
                iHoja.Cells.Item[2, 1] = this.ObtenerTextoRangoFecha();
                iHoja.Cells.Item[3, 1] = this.ObtenerTextoProducto();

                //------------------
                //Obtener el reporte
                //------------------
                List <KpiVersus> iLisKpiVer = this.ObtenerReporte();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("FECHA PLAN", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("LOTE", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("PRODUCCION", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("CODIGO", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("PRODUCTO", 50));                
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UN. PLANIFICADO", 20, 2, "PLAN ENVASADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UN. REAL", 20, 2, "PLAN ENVASADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DIFERENCIA", 20, 2, "PLAN ENVASADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("%", 20, 2, "PLAN ENVASADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UN. PLANIFICADO", 20, 2, "PLAN ENCAJADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UN. REAL", 20, 2, "PLAN ENCAJADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DIFERENCIA", 20, 2, "PLAN ENCAJADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("%", 20, 2, "PLAN ENCAJADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UN. PLANIFICADO", 20, 2, "PLAN REETIQUETADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UN. REAL", 20, 2, "PLAN REETIQUETADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DIFERENCIA", 20, 2, "PLAN REETIQUETADO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("%", 20, 2, "PLAN REETIQUETADO"));


                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 2;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 4;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisKpiVer.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);
               
                //-----------------------------------------
                //llenando la matriz de datos para el excel
                //-----------------------------------------

                //matriz 
                object[,] objData = new Object[iEncExc.NumeroRegistros, 17];

                //indice para cada fila
                int iIndiceFila = -1;

                //recorrer cada objeto
                foreach (KpiVersus xKpiVer in iLisKpiVer)
                {
                    iIndiceFila++;
                    objData[iIndiceFila, 0] = xKpiVer.FechaProceso;
                    objData[iIndiceFila, 1] = xKpiVer.Lote;
                    objData[iIndiceFila, 2] = xKpiVer.Produccion;
                    objData[iIndiceFila, 3] = xKpiVer.Codigo;
                    objData[iIndiceFila, 4] = xKpiVer.Descripcion;
                    objData[iIndiceFila, 5] = xKpiVer.EnvasadoUniPla;
                    objData[iIndiceFila, 6] = xKpiVer.EnvasadoUniRea;
                    objData[iIndiceFila, 7] = xKpiVer.EnvasadoDif;
                    objData[iIndiceFila, 8] = xKpiVer.EnvasadoPor;
                    objData[iIndiceFila, 9] = xKpiVer.EncajadoUniPla;
                    objData[iIndiceFila, 10] = xKpiVer.EncajadoUniRea;
                    objData[iIndiceFila, 11] = xKpiVer.EncajadoDif;
                    objData[iIndiceFila, 12] = xKpiVer.EncajadoPor;
                    objData[iIndiceFila, 13] = xKpiVer.RetiquetadoUniPla;
                    objData[iIndiceFila, 14] = xKpiVer.RetiquetadoUniRea;
                    objData[iIndiceFila, 15] = xKpiVer.RetiquetadoDif;
                    objData[iIndiceFila, 16] = xKpiVer.RetiquetadoPor;                    
                }

                //si la lista del reporte esta vacia,no ejecuta este codigo
                if (iLisKpiVer.Count != 0)
                {
                    //insertar los datos al excel
                    iRango = iHoja.get_Range("A6", iOpcional);
                    iRango = iRango.get_Resize(iEncExc.NumeroRegistros, 17);
                    iRango.set_Value(iOpcional, objData);
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

        public void ListarExistenciasSE()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExiPT.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias SE";
            win.eCtrlValor = this.txtCodExiPT;
            win.eCtrlFoco = this.btnExportar;
            win.eExiEN.CodigoAlmacen = "A11";//almacen semi elaborados
            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValidoSE()
        {
            //solo si esta habilitado el control
            if (this.txtCodExiPT.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = "A11";//almacen semi elaborados
            iExiEN.CodigoExistencia = this.txtCodExiPT.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaValido(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia SE");
                this.txtCodExiPT.Focus();
            }

            //pasar datos
            this.txtCodExiPT.Text = iExiEN.CodigoExistencia;
            this.txtDesExiPT.Text = iExiEN.DescripcionExistencia;

            //devolver
            return iExiEN.Adicionales.EsVerdad;
        }

        public void CambiarCkbCodExi()
        {
            Txt.HabilitarParaFiltro1(this.txtCodExiPT, this.txtDesExiPT, this.ckbCodExi.Checked);
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteKpiVersus, null);
        }

        #endregion

        private void wKpiVersus_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();         
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.EjecutarExcel();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodExiPT_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValidoSE();
        }

        private void txtCodExiPT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistenciasSE(); }
        }

        private void txtCodExiPT_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistenciasSE();
        }

        private void ckbCodExi_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCodExi();
        }
    }
}
