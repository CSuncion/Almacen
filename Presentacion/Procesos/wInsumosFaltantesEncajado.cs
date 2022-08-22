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
using Entidades.Estructuras;
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;

namespace Presentacion.Procesos
{
    public partial class wInsumosFaltantesEncajado : Heredados.MiForm8
    {
        public wInsumosFaltantesEncajado()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public List<InsumoFaltante> eLisInsFal = new List<InsumoFaltante>();
        public Form eVentanaPropietario;
                       
        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCorProDet, this.btnExpExc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnExpExc, "vvvf");
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

            // Deshabilitar al propietario de esta ventana
            this.eVentanaPropietario.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto(EncajadoEN pObj)
        {
            this.txtCorProDet.Text = pObj.CorrelativoEncajado;         
        }
              
        public void NuevaVentana(EncajadoEN pObj)
        {
            this.InicializaVentana();
            this.ValoresXDefecto(pObj);
            this.MostrarInsumosFaltantes();
            this.btnExpExc.Focus();
        }

        public void MostrarInsumosFaltantes()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvInsFal;
            List<InsumoFaltante> iFuenteDatos = this.eLisInsFal ;
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InsumoFaltante.CodLin, "Linea", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InsumoFaltante.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InsumoFaltante.DesExi, "Descripcion", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InsumoFaltante.NUniMed, "Unidad", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(InsumoFaltante.CanParTra, "C.Insumos", 80, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(InsumoFaltante.CanStoExi, "C.Stock", 80, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(InsumoFaltante.CanFal, "C.Faltante", 80, 5));
           
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

                //-----------------
                //llenando cabecera
                //-----------------

                iHoja.Cells.Item[1, 1] = "Encajado :  " + this.txtCorProDet.Text.Trim();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Linea", 7));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Unidad", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Insumos", 14, 5));             
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Stock", 14, 5));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Faltante", 14, 5));
              
                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 2;
                iEncExc.Color = Color.GreenYellow;
                iEncExc.NumeroRegistros = this.eLisInsFal.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 2;

                //recorrer cada objeto
                foreach (InsumoFaltante xInsFal in this.eLisInsFal)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xInsFal.CodigoLinea;
                    iHoja.Cells.Item[iIndiceFila, 2] = xInsFal.CodigoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 3] = xInsFal.DescripcionExistencia;
                    iHoja.Cells.Item[iIndiceFila, 4] = xInsFal.NUnidadMedida;
                    iHoja.Cells.Item[iIndiceFila, 5] = xInsFal.CantidadParteTrabajo;
                    iHoja.Cells.Item[iIndiceFila, 6] = xInsFal.CantidadStockExistencia;
                    iHoja.Cells.Item[iIndiceFila, 7] = xInsFal.CantidadFaltante;
                    
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
        
        #endregion


        private void wInsumosFaltantesEncajado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentanaPropietario.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void btnExpExc_Click(object sender, EventArgs e)
        {
            this.ExportarExcel();   
        }
     
    }
}
