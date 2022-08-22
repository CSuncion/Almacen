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
    public partial class wInsumosFaltantesTransferir : Heredados.MiForm8
    {
        public wInsumosFaltantesTransferir()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public List<InsumoFaltante> eLisInsFal = new List<InsumoFaltante>();
        public Form eVentanaPropietario;
                       
        #endregion
                
        #region General


        public void InicializaVentana()
        {   
            // Deshabilitar al propietario de esta ventana
            this.eVentanaPropietario.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }
      
        public void NuevaVentana()
        {
            this.InicializaVentana();
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InsumoFaltante.CodAlm, "Almacen", 40));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InsumoFaltante.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InsumoFaltante.DesExi, "Descripcion", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(InsumoFaltante.NUniMed, "Unidad", 70));            
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(InsumoFaltante.CanFalOri, "C.Faltante", 80, 3));
           
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

                iHoja.Cells.Item[1, 1] = "Transferir";
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();               
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Almacen", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Unidad", 13));                
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Faltante", 14, 3));

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
                    iHoja.Cells.Item[iIndiceFila, 1] = xInsFal.CodigoAlmacen;
                    iHoja.Cells.Item[iIndiceFila, 2] = xInsFal.CodigoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 3] = xInsFal.DescripcionExistencia;
                    iHoja.Cells.Item[iIndiceFila, 4] = xInsFal.NUnidadMedida;                    
                    iHoja.Cells.Item[iIndiceFila, 5] = xInsFal.CantidadFaltanteOrigen;

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


        private void wInsumosFaltantesCompra_FormClosing(object sender, FormClosingEventArgs e)
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
