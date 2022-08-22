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
    public partial class wCostoUnitarioPorFechas : Heredados.MiForm8
    {
        public wCostoUnitarioPorFechas()
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

        //public List<ProduccionProTerEN> ObtenerReporte()
        //{
        //    //asignar parametros
        //    ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
        //    iProProTerEN.Adicionales.Desde1 = this.dtpFecDes.Text;
        //    iProProTerEN.Adicionales.Hasta1 = this.dtpFecHas.Text;
        //    iProProTerEN.CodigoExistencia = this.txtCodExiPT.Text.Trim();

        //    //ejecutar metodo
        //    return ProduccionProTerRN.ObtenerReporteCostoUnitarioPorFechas(iProProTerEN);
        //}

        public List<CostoUnitarioProTer> ObtenerReporte()
        {
            //asignar parametros
            RetiquetadoEN iRetEN = new RetiquetadoEN();
            iRetEN.Adicionales.Desde1 = this.dtpFecDes.Text;
            iRetEN.Adicionales.Hasta1 = this.dtpFecHas.Text;
            iRetEN.CodigoExistenciaRE = this.txtCodExiPT.Text.Trim();

            //ejecutar metodo
            return RetiquetadoRN.ObtenerReporteCostoUnitarioPorFechasActualizado(iRetEN);
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

                iHoja.Cells.Item[1, 1] = "COSTOS UNITARIOS POR PRODUCTO POR FECHAS";
                iHoja.Cells.Item[2, 1] = this.ObtenerTextoRangoFecha();
                iHoja.Cells.Item[3, 1] = this.ObtenerTextoProducto();

                //------------------
                //Obtener el reporte
                //------------------
                List <CostoUnitarioProTer> iLisCosUniProTer = this.ObtenerReporte();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("TIPO OPERACION", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("CORRELATIVO OPERACION", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("FECHA", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("CODIGO", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("DESCRIPCION", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("LOTE", 60));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UNIDADES ENCAJADAS", 20, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("MATERIA PRIMA", 20, 6));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENVASES", 20, 6));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("EMBALAJES", 20, 6));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("MANO OBRA DIRECTA", 20, 6));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("CIF", 20, 6));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("COSTO UNITARIO", 20, 6));
                

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 4;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisCosUniProTer.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);
               
                //-----------------------------------------
                //llenando la matriz de datos para el excel
                //-----------------------------------------

                //matriz 
                object[,] objData = new Object[iEncExc.NumeroRegistros,13];

                //indice para cada fila
                int iIndiceFila = -1;

                //recorrer cada objeto
                foreach (CostoUnitarioProTer xCosUniProTer in iLisCosUniProTer)
                {
                    iIndiceFila++;
                    objData[iIndiceFila, 0] = xCosUniProTer.TipoOperacion;
                    objData[iIndiceFila, 1] = xCosUniProTer.CorrelativoOperacion;
                    objData[iIndiceFila, 2] = xCosUniProTer.FechaProTer;
                    objData[iIndiceFila, 3] = xCosUniProTer.CodigoExistencia;
                    objData[iIndiceFila, 4] = xCosUniProTer.DescripcionExistencia;
                    objData[iIndiceFila, 5] = xCosUniProTer.FechaLote;
                    objData[iIndiceFila, 6] = xCosUniProTer.UnidadesProducidas;
                    objData[iIndiceFila, 7] = xCosUniProTer.MateriaPrimaUnitario;
                    objData[iIndiceFila, 8] = xCosUniProTer.EnvaseUnitario;
                    objData[iIndiceFila, 9] = xCosUniProTer.EmbalajeUnitario;
                    objData[iIndiceFila, 10] = xCosUniProTer.ManoObraUnitario;
                    objData[iIndiceFila, 11] = xCosUniProTer.CostoCifUnitario;
                    objData[iIndiceFila, 12] = xCosUniProTer.CostoUnitario;                    
                }

                //si la lista del reporte esta vacia,no ejecuta este codigo
                if (iLisCosUniProTer.Count != 0)
                {
                    //insertar los datos al excel
                    iRango = iHoja.get_Range("A5", iOpcional);
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
            wMen.CerrarVentanaHijo(this, wMen.IteCosUniPorProducto, null);
        }

        #endregion

        private void wCostoUnitarioPorFechas_FormClosing(object sender, FormClosingEventArgs e)
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
