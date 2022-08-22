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
    public partial class wCostosAcumuladosPorProceso : Heredados.MiForm8
    {
        public wCostosAcumuladosPorProceso()
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
            xCtrl.TxtTodo(this.txtCodExiPT, true, "Existencia PT", "vvff", 20);
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

        public List<AcumuladoProceso> ObtenerReporte()
        {
            //asignar parametros
            RetiquetadoEN iRetEN = new RetiquetadoEN();
            iRetEN.Adicionales.Desde1 = this.dtpFecDes.Text;
            iRetEN.Adicionales.Hasta1 = this.dtpFecHas.Text;
            iRetEN.CodigoExistenciaRE = this.txtCodExiPT.Text.Trim();

            //ejecutar metodo
            return RetiquetadoRN.ObtenerReporteAcumuladosPorProcesoActualizadoNuevo(iRetEN);
        }

        public string ObtenerTextoFecha()
        {
            //valor resultado
            string iValor = string.Empty;

            //armar texto
            iValor += "DESDE : " + Fecha.ObtenerDiaMesAno(this.dtpFecDes.Text);
            iValor += " HASTA : " + Fecha.ObtenerDiaMesAno(this.dtpFecHas.Text);

            //devolver
            return iValor;
        }

        public string ObtenerTextoProducto()
        {
            //valor resultado
            string iValor = string.Empty;

            //armar texto
            iValor += "PRODUCTO : " + Cadena.CompararDosValores(this.txtCodExiPT.Text, string.Empty, "TODOS", this.txtCodExiPT.Text + " - " +
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

                iHoja.Cells.Item[1, 1] = "COSTOS ACUMULADOS POR PROCESO(PRESUPUESTADOS Y REALES) POR FECHAS";
                iHoja.Cells.Item[2, 1] = this.ObtenerTextoFecha();
                iHoja.Cells.Item[3, 1] = this.ObtenerTextoProducto();

                //------------------
                //Obtener el reporte
                //------------------
                List <AcumuladoProceso> iLisAcuPro = this.ObtenerReporte();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("ELEMENTOS", 27));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENVASADO", 20, 2, "COSTOS PRESUPUESTADOS"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENCAJADO", 20, 2, "COSTOS PRESUPUESTADOS"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REETIQUETADO", 20, 2, "COSTOS PRESUPUESTADOS"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("COSTOS TOTALES", 20, 2, "COSTOS PRESUPUESTADOS"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENVASADO", 20, 2, "COSTOS REALES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENCAJADO", 20, 2, "COSTOS REALES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REETIQUETADO", 20, 2, "COSTOS REALES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("COSTOS TOTALES", 20, 2, "COSTOS REALES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENVASADO", 20, 2, "COSTOS PRESUPUESTADOS - COSTOS REALES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENCAJADO", 20, 2, "COSTOS PRESUPUESTADOS - COSTOS REALES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REETIQUETADO", 20, 2, "COSTOS PRESUPUESTADOS - COSTOS REALES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("COSTOS TOTALES", 20, 2, "COSTOS PRESUPUESTADOS - COSTOS REALES"));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 2;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 4;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisAcuPro.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);
               
                //-----------------------------------------
                //llenando la matriz de datos para el excel
                //-----------------------------------------

                //matriz 
                object[,] objData = new Object[iEncExc.NumeroRegistros, 13];

                //indice para cada fila
                int iIndiceFila = -1;

                //recorrer cada objeto
                foreach (AcumuladoProceso xAcuPro in iLisAcuPro)
                {
                    iIndiceFila++;
                    objData[iIndiceFila, 0] = xAcuPro.Elemento;
                    objData[iIndiceFila, 1] = xAcuPro.EnvasadoPpto;
                    objData[iIndiceFila, 2] = xAcuPro.EncajadoPpto;
                    objData[iIndiceFila, 3] = xAcuPro.RetiquetadoPpto;
                    objData[iIndiceFila, 4] = xAcuPro.CostoTotalPpto;
                    objData[iIndiceFila, 5] = xAcuPro.EnvasadoRea;
                    objData[iIndiceFila, 6] = xAcuPro.EncajadoRea;
                    objData[iIndiceFila, 7] = xAcuPro.RetiquetadoRea;
                    objData[iIndiceFila, 8] = xAcuPro.CostoTotalRea;
                    objData[iIndiceFila, 9] = xAcuPro.EnvasadoDif;
                    objData[iIndiceFila, 10] = xAcuPro.EncajadoDif;
                    objData[iIndiceFila, 11] = xAcuPro.RetiquetadoDif;
                    objData[iIndiceFila, 12] = xAcuPro.CostoTotalDif;
                }

                //si la lista del reporte esta vacia,no ejecuta este codigo
                if (iLisAcuPro.Count != 0)
                {
                    //insertar los datos al excel
                    iRango = iHoja.get_Range("A6", iOpcional);
                    iRango = iRango.get_Resize(iEncExc.NumeroRegistros, 13);
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

        public void ListarExistenciasPT()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExiPT.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias PT";
            win.eCtrlValor = this.txtCodExiPT;
            win.eCtrlFoco = this.btnExportar;
            win.eExiEN.CodigoAlmacen = "A13";//almacen productos terminados
            win.eCondicionLista = wLisExi.Condicion.ListarExistenciasProductosTerminadosActivosDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValidoPT()
        {
            //solo si esta habilitado el control
            if (this.txtCodExiPT.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = "A13";//almacen productos terminados
            iExiEN.CodigoExistencia = this.txtCodExiPT.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaProductoTerminadoActivoValido(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia PT");
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
            wMen.CerrarVentanaHijo(this, wMen.IteCosAcuPorProcesos, null);
        }

        #endregion

        private void wCostosAcumuladosPorProceso_FormClosing(object sender, FormClosingEventArgs e)
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
            this.EsCodigoExistenciaValidoPT();
        }

        private void txtCodExiPT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistenciasPT(); }
        }

        private void txtCodExiPT_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistenciasPT();
        }

        private void ckbCodExi_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCodExi();
        }
    }
}
