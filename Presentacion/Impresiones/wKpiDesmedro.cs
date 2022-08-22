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
    public partial class wKpiDesmedro : Heredados.MiForm8
    {
        public wKpiDesmedro()
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

        public List<KpiDesmedro> ObtenerReporte()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.Adicionales.Desde1 = this.dtpFecDes.Text;
            iProProTerEN.Adicionales.Hasta1 = this.dtpFecHas.Text;
            iProProTerEN.CodigoExistencia = this.txtCodExiPT.Text.Trim();

            //ejecutar metodo
            return ProduccionProTerRN.ObtenerReporteKpiDesmedro(iProProTerEN);
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

                iHoja.Cells.Item[1, 1] = "KPI DESMEDROS";
                iHoja.Cells.Item[2, 1] = this.ObtenerTextoRangoFecha();
                iHoja.Cells.Item[3, 1] = this.ObtenerTextoProducto();

                //------------------
                //Obtener el reporte
                //------------------
                List <KpiDesmedro> iLisProProTer = this.ObtenerReporte();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("FECHA PRODUCTO TERMINADO", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("FECHA ENCAJADO", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("LOTE", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("PRODUCCION", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("CODIGO", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("DESCRIPCION", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("CANTIDAD PLANIFICADA", 20, 0));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("CANTIDAD PRODUCIDA", 20, 0));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("APROBADO", 20, 0,"CLASIFICACION PROCESO - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REPROCESO", 20, 0, "CLASIFICACION PROCESO - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("OBSERVACION", 20, 0, "CLASIFICACION PROCESO - UNIDADES"));
                //iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DESECHO", 20, 0, "CLASIFICACION PROCESO - UNIDADES"));
                //iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DONACION", 20, 0, "CLASIFICACION PROCESO - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DESMEDRO", 20, 0, "CLASIFICACION PROCESO - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("APROBADO", 20, 0, "CLASIFICACION ENCAJADO - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REPROCESO", 20, 0, "CLASIFICACION ENCAJADO - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("OBSERVACION", 20, 0, "CLASIFICACION ENCAJADO - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DESMEDRO", 20, 0, "CLASIFICACION ENCAJADO - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("TOTAL DESMEDRO", 20, 0));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("APROBADO", 20, 2, "CLASIFICACION PROCESO - %"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REPROCESO", 20, 2, "CLASIFICACION PROCESO - %"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("OBSERVACION", 20, 2, "CLASIFICACION PROCESO - %"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DESMEDRO", 20, 2, "CLASIFICACION PROCESO - %"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("APROBADO", 20, 2, "CLASIFICACION ENCAJADO - %"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REPROCESO", 20, 2, "CLASIFICACION ENCAJADO - %"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("OBSERVACION", 20, 2, "CLASIFICACION ENCAJADO - %"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DESMEDRO", 20, 2, "CLASIFICACION ENCAJADO - %"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("TOTAL DESMEDRO %", 20, 2));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 2;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 4;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisProProTer.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);
               
                //-----------------------------------------
                //llenando la matriz de datos para el excel
                //-----------------------------------------

                //matriz 
                object[,] objData = new Object[iEncExc.NumeroRegistros, 26];

                //indice para cada fila
                int iIndiceFila = -1;

                //recorrer cada objeto
                foreach (KpiDesmedro xKpi in iLisProProTer)
                {
                    iIndiceFila++;
                    objData[iIndiceFila, 0] = xKpi.FechaProductoTerminado;
                    objData[iIndiceFila, 1] = xKpi.FechaEncajado;
                    objData[iIndiceFila, 2] = xKpi.Lote;
                    objData[iIndiceFila, 3] = xKpi.Produccion;
                    objData[iIndiceFila, 4] = xKpi.Codigo;
                    objData[iIndiceFila, 5] = xKpi.Descripcion;
                    objData[iIndiceFila, 6] = xKpi.CantidadPlanificada;
                    objData[iIndiceFila, 7] = xKpi.CantidadProducida;
                    objData[iIndiceFila, 8] = xKpi.AprobadoClaProUni;
                    objData[iIndiceFila, 9] = xKpi.ReprocesoClaProUni;
                    objData[iIndiceFila, 10] = xKpi.ObservacionClaProUni;
                    //objData[iIndiceFila, 11] = xKpi.DesmedroClaEncUni;
                    //objData[iIndiceFila, 11] = xKpi.DesechoClaProUni;
                    //objData[iIndiceFila, 12] = xKpi.DonacionClaProUni;
                    objData[iIndiceFila, 11] = xKpi.DesmedroClaProUni;
                    objData[iIndiceFila, 12] = xKpi.AprobadoClaEncUni;
                    objData[iIndiceFila, 13] = xKpi.ReprocesoClaEncUni;
                    objData[iIndiceFila, 14] = xKpi.ObservacionClaEncUni;
                    objData[iIndiceFila, 15] = xKpi.DesmedroClaEncUni;
                    objData[iIndiceFila, 16] = xKpi.TotalDesmedroUni;
                    objData[iIndiceFila, 17] = xKpi.AprobadoClaProPor;
                    objData[iIndiceFila, 18] = xKpi.ReprocesoClaProPor;
                    objData[iIndiceFila, 19] = xKpi.ObservacionClaProPor;
                    objData[iIndiceFila, 20] = xKpi.DesmedroClaProPor;
                    objData[iIndiceFila, 21] = xKpi.AprobadoClaEncPor;
                    objData[iIndiceFila, 22] = xKpi.ReprocesoClaEncPor;
                    objData[iIndiceFila, 23] = xKpi.ObservacionClaEncPor;
                    objData[iIndiceFila, 24] = xKpi.DesmedroClaEncPor;
                    objData[iIndiceFila, 25] = xKpi.TotalDesmedroPor;
                }

                //si la lista del reporte esta vacia,no ejecuta este codigo
                if (iLisProProTer.Count != 0)
                {
                    //insertar los datos al excel
                    iRango = iHoja.get_Range("A6", iOpcional);
                    iRango = iRango.get_Resize(iEncExc.NumeroRegistros, 26);
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
            wMen.CerrarVentanaHijo(this, wMen.IteKpiDesmedro, null);
        }

        #endregion

        private void wKpiDesmedro_FormClosing(object sender, FormClosingEventArgs e)
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
