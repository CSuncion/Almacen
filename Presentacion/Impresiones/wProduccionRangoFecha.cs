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
    public partial class wProduccionRangoFecha : Heredados.MiForm8
    {
        public wProduccionRangoFecha()
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
            xCtrl.Cmb(this.cmbTipUni, "vvvv");
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
            this.cmbTipUni.SelectedIndex = 0;         
            this.dtpFecDes.Focus();
        }

        public List<ProduccionDetaEN> ObtenerReporte()
        {
            //asignar parametros
            string iFechaDesde = this.dtpFecDes.Text;
            string iFechaHasta = this.dtpFecHas.Text;
            string iTipoUnidad = Cmb.ObtenerTexto(this.cmbTipUni);

            //ejecutar metodo
            return ProduccionDetaRN.ObtenerReporteProduccionRangoFecha(iFechaDesde, iFechaHasta, iTipoUnidad);
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
                //variables
                string iTipoUnidad = Cmb.ObtenerTexto(this.cmbTipUni);
               
                //------------------
                //Obtener el reporte
                //------------------
                List<ProduccionDetaEN> iLisProDet = this.ObtenerReporte();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Parte Trabajo", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fecha", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Periodo", 11));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Almacen", 9));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo Formula", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion Formula", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Peso En KG Por Producto", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Cantidad Plan ("+ iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Cantidad Real (" + iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Pendiente Por Liberar (" + iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Numero de Aprobadas (" + iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Numero de Reprocesos (" + iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Numero de Donadas (" + iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Numero de Contramuestra (" + iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Numero de Desechas (" + iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Total Envases Desmedrado (" + iTipoUnidad + ")", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("%  Desmedro de Envases(" + iTipoUnidad + ")", 18, 2));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 1;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisProDet.Count;
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
                foreach (ProduccionDetaEN xProDet in iLisProDet)
                {
                    iIndiceFila++;
                    objData[iIndiceFila, 0] = xProDet.CorrelativoProduccionCabe;
                    objData[iIndiceFila, 1] = xProDet.FechaProduccionDeta;
                    objData[iIndiceFila, 2] = xProDet.PeriodoProduccionDeta;
                    objData[iIndiceFila, 3] = xProDet.CodigoAlmacenSemiProducto;
                    objData[iIndiceFila, 4] = xProDet.CodigoExistencia;
                    objData[iIndiceFila, 5] = xProDet.DescripcionExistencia;
                    objData[iIndiceFila, 6] = xProDet.MasaUnidad;
                    objData[iIndiceFila, 7] = xProDet.CantidadProduccionDeta;
                    objData[iIndiceFila, 8] = xProDet.CantidadRealProduccion;
                    objData[iIndiceFila, 9] = xProDet.SaldoLiberacion;
                    objData[iIndiceFila, 10] = xProDet.UnidadesAprobadasLiberacion;
                    objData[iIndiceFila, 11] = xProDet.UnidadesReprocesoLiberacion;
                    objData[iIndiceFila, 12] = xProDet.UnidadesDonacionLiberacion;
                    objData[iIndiceFila, 13] = xProDet.UnidadesMuestraLiberacion;
                    objData[iIndiceFila, 14] = xProDet.UnidadesDesechasLiberacion;
                    objData[iIndiceFila, 15] = xProDet.TotalEnvasesDesmedro;
                    objData[iIndiceFila, 16] = xProDet.PorcentajeEnvasesDesmedro;
                }

                //si la lista del reporte esta vacia,no ejecuta este codigo
                if (iLisProDet.Count != 0)
                {
                    //insertar los datos al excel
                    iRango = iHoja.get_Range("A2", iOpcional);
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

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteFormatoEnvasado, null);
        }

        #endregion

        private void wProduccionRangoFecha_FormClosing(object sender, FormClosingEventArgs e)
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
