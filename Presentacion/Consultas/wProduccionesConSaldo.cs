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
using System.Collections;

namespace Presentacion.Consultas
{
    public partial class wProduccionesConSaldo : Heredados.MiForm8
    {
        public wProduccionesConSaldo()
        {
            InitializeComponent();
        }

        //atributos  
        string eNombreColumnaDgvAux = ProduccionDetaEN.CorProCab;
        string eEncabezadoColumnaDgvAux = "Solicitud";
        public string eClaveDgvAux = string.Empty;
        Dgv.Franja eFranjaDgvAux = Dgv.Franja.PorIndice;
        List<ProduccionDetaEN> eLisProDet = new List<ProduccionDetaEN>();
        int eVaBD = 1;//0 : no , 1 : si 
        
               

        #region General

        public void InicializaVentana()
        {          
            //mostrar ventana
            this.Show();
            this.ActualizarVentana();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();         
            this.ActualizarListaProduccionDeta();
            this.ActualizarListaProduccionDetaDeBaseDatos();
            this.ActualizarDgvSal();
            this.MostrarTitulo();
            this.btnExportar.Focus();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaProduccionDeta();
            this.ActualizarDgvSal();

            Dgv.HabilitarDesplazadores(this.dgvMovDet, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.dgvMovDet, this.sst1);
        }

        public void ActualizarListaProduccionDeta()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            this.eLisProDet = ProduccionDetaRN.ListarProduccionDetaConSaldoLiberacion();

            //Dgv.HabilitarDesplazadores(this.dgvMovDet, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            //this.HabilitarAcciones();
            //Dgv.ActualizarBarraEstado(this.dgvMovDet, this.sst1);
        }

        public void ActualizarListaProduccionDetaDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            ProduccionDetaEN iPerEN = new ProduccionDetaEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvAux;
            this.eLisProDet = ProduccionDetaRN.ListarProduccionDetaConSaldoLiberacionNew(iPerEN);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            //ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("011", dgvMovDet.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs2, iLisPer);
        }

        public void ActualizarDgvSal()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<ProduccionDetaEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvAux;
            string iClaveBusqueda = string.Empty;
            string iColumnaPintura = eNombreColumnaDgvAux;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionDetaEN.CorProCab, "Solicitud", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionDetaEN.FecProDet, "Fc.Produccion", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionDetaEN.CodSemPro, "Codigo", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionDetaEN.DesSemPro, "Descripcion", 350));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionDetaEN.SalLib, "Saldo", 90, 2));            
                        
            //devolver
            return iLisRes;
        }

        public List<ProduccionDetaEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvAux;
            List<ProduccionDetaEN> iLisPer = eLisProDet;

            //ejecutar y retornar
            return ProduccionDetaRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
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
                //lista resultado a exportar
                List<ProduccionDetaEN> iLisProDet = this.ObtenerDatosParaGrilla();

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Solicitud", 10));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fc.Produccion", 15));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo", 11));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion", 60));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Saldo", 18, 2));
                //iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Stock.Alerta", 18, 2));
                //iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Stock.Actual", 18, 2));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 1;
                iEncExc.Color = Color.GreenYellow;
                iEncExc.NumeroRegistros = iLisProDet.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 1;

                //recorrer cada objeto
                foreach (ProduccionDetaEN xProDet in iLisProDet)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xProDet.CorrelativoProduccionCabe;
                    iHoja.Cells.Item[iIndiceFila, 2] = xProDet.FechaProduccionDeta;
                    iHoja.Cells.Item[iIndiceFila, 3] = xProDet.CodigoSemiProducto;
                    iHoja.Cells.Item[iIndiceFila, 4] = xProDet.DescripcionSemiProducto;
                    iHoja.Cells.Item[iIndiceFila, 5] = xProDet.SaldoLiberacion;
                    //iHoja.Cells.Item[iIndiceFila, 6] = xLib.StockAlertaExistencia;
                    //iHoja.Cells.Item[iIndiceFila, 7] = xLib.StockActualExistencia;
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
            string iTexto1 = "Cantidad de Producciones pendientes con saldo ";
            string iTexto2 = this.eLisProDet.Count.ToString();

            //ejecutar metodo
            this.lblTit.Text = Formato.UnionDosTextos(iTexto1, iTexto2, " / ");
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvAux = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvAux = this.dgvMovDet.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvAux = this.dgvMovDet.Columns[pColumna].HeaderText;
            this.ActualizarDgvSal();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovDet, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovDet, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        //this.ActualizarDgvSal();
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteProduccionConSaldo, null);
        }

        #endregion

        private void wProduccionesConSaldo_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvMovDet_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvAux = Dgv.Franja.PorIndice;
            //this.ActualizarDgvSal();
            this.ActualizarVentana();
        }        

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovDet, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovDet, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovDet, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvMovDet, Dgv.Desplazar.Ultimo);
        }

        private void dgvMovDet_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.dgvMovDet, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.dgvMovDet, this.sst1);
        }
    }
}
