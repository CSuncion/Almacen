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
    public partial class wMovimientosXExistencia : Heredados.MiForm8
    {
        public wMovimientosXExistencia()
        {
            InitializeComponent();
        }

        #region Atributos

        List<MovimientoDetaEN> eLisMovDet = new List<MovimientoDetaEN>();

        #endregion
        
        #region Propietario

        public wSaldosPorExistencia wSalExi;

        #endregion

        #region General

        public void InicializaVentana()
        {
            //Deshabilitar al propietario de esta ventana
            this.wSalExi.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void NuevaVentana(MovimientoDetaEN pObj)
        {
            this.InicializaVentana();         
            this.ActualizarListaMovimientosDeta(pObj);
            this.ActualizarDgvSal();
            this.MostrarTitulo();
            this.btnExportar.Focus();
        }

        public void ActualizarListaMovimientosDeta(MovimientoDetaEN pObj)
        {
            this.eLisMovDet = MovimientoDetaRN.ListarMovimientosDetaParaSaldosXExistencia(pObj);
        }

        public void ActualizarDgvSal()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<MovimientoDetaEN> iFuenteDatos = this.eLisMovDet;
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.NumMovCab, "Numero", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.FecMovCab, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.PerMovCab, "Periodo", 60));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.DesTipOpe, "Tipo.Operacion", 130));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodAlm, "Almacen", 60));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodExi, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.DesExi, "Descripcion", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.NomUniMed, "Uni", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CanMovDet, "Cantidad", 100, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.PreUniMovDet, "Precio.Uni", 85, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CosMovDet, "Costo", 85, 2));
                        
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
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Numero", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fecha", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Periodo", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Tipo.Operacion", 30));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Almacen", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Uni", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Cantidad", 18, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Precio.Uni", 18, 2));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Costo", 18, 2));
                
                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 1;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = this.eLisMovDet.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 1;

                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in this.eLisMovDet)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xMovDet.NumeroMovimientoCabe;
                    iHoja.Cells.Item[iIndiceFila, 2] = xMovDet.FechaMovimientoCabe;
                    iHoja.Cells.Item[iIndiceFila, 3] = xMovDet.PeriodoMovimientoCabe;
                    iHoja.Cells.Item[iIndiceFila, 4] = xMovDet.DescripcionTipoOperacion;
                    iHoja.Cells.Item[iIndiceFila, 5] = xMovDet.CodigoAlmacen;
                    iHoja.Cells.Item[iIndiceFila, 6] = xMovDet.CodigoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 7] = xMovDet.DescripcionExistencia;
                    iHoja.Cells.Item[iIndiceFila, 8] = xMovDet.NombreUnidadMedida;
                    iHoja.Cells.Item[iIndiceFila, 9] = xMovDet.CantidadMovimientoDeta;
                    iHoja.Cells.Item[iIndiceFila, 10] = xMovDet.PrecioUnitarioMovimientoDeta;
                    iHoja.Cells.Item[iIndiceFila, 11] = xMovDet.CostoMovimientoDeta;
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
            string iTexto1 = "Cantidad de movimientos ";
            string iTexto2 = this.eLisMovDet.Count.ToString();

            //ejecutar metodo
            this.lblTit.Text = Formato.UnionDosTextos(iTexto1, iTexto2, " / ");
        }

        #endregion

        private void wMovimientosXExistencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wSalExi.Enabled = true;         
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
