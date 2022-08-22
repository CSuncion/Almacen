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
    public partial class wPorCumplimientoProduccion : Heredados.MiForm8
    {
        public wPorCumplimientoProduccion()
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
            xCtrl.TxtNumeroSinEspacion(this.txtAñoSal, true, "Año", "vfff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMesSal, "vvff");
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

            //llenar combos        
            this.CargarMeses();

            //mostrar ventana
            this.Show();
        }

        public void CargarMeses()
        {
            Cmb.Cargar(this.cmbMesSal, ItemGRN.ListarItemsG("Mes"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            MiControl.MostrarPeriodoActual(this.txtAñoSal, this.cmbMesSal);
            this.txtAñoSal.Focus();
        }

        public List<CumplimientoProduccion> ObtenerReporte()
        {
            //asignar parametros
            string iAño = this.txtAñoSal.Text.Trim();
            string iCodigoMes = Cmb.ObtenerValor(this.cmbMesSal, "");

            //ejecutar metodo
            return ProduccionDetaRN.ObtenerReportePorcentajeCumplimientoProduccion(iAño, iCodigoMes);
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
                //------------------
                //Obtener el reporte
                //------------------
                List<CumplimientoProduccion> iLisCumPro = this.ObtenerReporte();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("SEMANA", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("TURNO", 8));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("PRODUCCION", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("CODIGO", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("PRODUCTO", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("FECHA", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("MES", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("KG ITEM", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("CANTIDAD PLANIFICADA", 18, 0));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("CANTIDAD SINCERADA", 18, 0));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("KG PLANIFICADA", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("KG SINCERADOS", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("PRODUCIDOS", 18, 0));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("LIBERADOS", 18, 0));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("KG PRODUCIDOS", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("KG PRODUCIDOS PARA VENTA", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("RESULTADO", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("RESULTADO", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("% CUMPLIMIENTO BRUTO", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("% CUMPLIMIENTO NETO", 18, 2));


                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 1;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisCumPro.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);
               
                //-----------------------------------------
                //llenando la matriz de datos para el excel
                //-----------------------------------------

                //matriz 
                object[,] objData = new Object[iEncExc.NumeroRegistros, 20];

                //indice para cada fila
                int iIndiceFila = -1;

                //recorrer cada objeto
                foreach (CumplimientoProduccion xCumPro in iLisCumPro)
                {
                    iIndiceFila++;
                    objData[iIndiceFila, 0] = xCumPro.Semana;
                    objData[iIndiceFila, 1] = xCumPro.NTurno;
                    objData[iIndiceFila, 2] = xCumPro.CorrelativoProduccionCabe;
                    objData[iIndiceFila, 3] = xCumPro.CodigoSemiProducto;
                    objData[iIndiceFila, 4] = xCumPro.DescripcionSemiProducto;
                    objData[iIndiceFila, 5] = xCumPro.FechaProduccion;
                    objData[iIndiceFila, 6] = xCumPro.NombreMes;
                    objData[iIndiceFila, 7] = xCumPro.KgItem;
                    objData[iIndiceFila, 8] = xCumPro.CantidadPlanificada;
                    objData[iIndiceFila, 9] = xCumPro.CantidadSincerada;
                    objData[iIndiceFila, 10] = xCumPro.KgPlanificada;
                    objData[iIndiceFila, 11] = xCumPro.KgSincerado;
                    objData[iIndiceFila, 12] = xCumPro.CantidadProducido;
                    objData[iIndiceFila, 13] = xCumPro.CantidadLiberado;
                    objData[iIndiceFila, 14] = xCumPro.KgProducido;
                    objData[iIndiceFila, 15] = xCumPro.KgLiberado;
                    objData[iIndiceFila, 16] = xCumPro.resultado;
                    objData[iIndiceFila, 17] = xCumPro.resultado2;
                    objData[iIndiceFila, 18] = xCumPro.PorcentajeCumplimientoBruto;
                    objData[iIndiceFila, 19] = xCumPro.PorcentajeCumplimientoNeto;
                }

                //si la lista del reporte esta vacia,no ejecuta este codigo
                if (iLisCumPro.Count != 0)
                {
                    //insertar los datos al excel
                    iRango = iHoja.get_Range("A2", iOpcional);
                    iRango = iRango.get_Resize(iEncExc.NumeroRegistros, 20);
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

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.ItePorCumProd, null);
        }

        #endregion

        private void wPorCumplimientoProduccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();         
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.ExportarExcel();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
