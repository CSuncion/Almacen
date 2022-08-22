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

namespace Presentacion.Consultas
{
    public partial class wAlertaStockMinimo : Heredados.MiForm8
    {
        public wAlertaStockMinimo()
        {
            InitializeComponent();
        }

        //atributos   
        List<ExistenciaEN> eLisExi = new List<ExistenciaEN>();
               

        #region General

        public void InicializaVentana()
        {          
            //mostrar ventana
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();         
            this.ActualizarListaSaldosExistencia();
            this.ActualizarDgvSal();
            this.MostrarTitulo();
            this.btnExportar.Focus();
        }

        public void ActualizarListaSaldosExistencia()
        {
            this.eLisExi = ExistenciaRN.ListarExistenciasParaAlertaStock();
        }

        public void ActualizarDgvSal()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<ExistenciaEN> iFuenteDatos = this.eLisExi;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.CodAlm, "Almacen", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.DesAlm, "Nombre", 220));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.CodExi, "Codigo", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.DesExi, "Descripcion", 350));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.NomUniMed, "Uni", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ExistenciaEN.StoMinExi, "Stock.Minimo", 100, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ExistenciaEN.StoAleExi, "Stock.Alerta", 100, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ExistenciaEN.StoActExi, "Stock.Actual", 100, 5));
                        
            //devolver
            return iLisRes;
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

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Almacen", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Uni", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Stock.Minimo", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Stock.Alerta", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Stock.Actual", 18, 2));
                
                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 1;
                iEncExc.Color = Color.GreenYellow;
                iEncExc.NumeroRegistros = this.eLisExi.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 1;

                //recorrer cada objeto
                foreach (ExistenciaEN xExi in this.eLisExi)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xExi.CodigoAlmacen;
                    iHoja.Cells.Item[iIndiceFila, 2] = xExi.CodigoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 3] = xExi.DescripcionExistencia;
                    iHoja.Cells.Item[iIndiceFila, 4] = xExi.NombreUnidadMedida;
                    iHoja.Cells.Item[iIndiceFila, 5] = xExi.StockMinimoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 6] = xExi.StockAlertaExistencia;
                    iHoja.Cells.Item[iIndiceFila, 7] = xExi.StockActualExistencia;
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

        public void MostrarTitulo()
        {
            //asignar parametros
            string iTexto1 = "Cantidad de existencias ";
            string iTexto2 = this.eLisExi.Count.ToString();

            //ejecutar metodo
            this.lblTit.Text = Formato.UnionDosTextos(iTexto1, iTexto2, " / ");
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteAlertaStockMinimo, null);
        }

        #endregion

        private void wAlertaStockMinimo_FormClosing(object sender, FormClosingEventArgs e)
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
