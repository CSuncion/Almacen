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
    public partial class wCostoLoteEtaEnv : Heredados.MiForm8
    {
        public wCostoLoteEtaEnv()
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

        public List<ProduccionDetaEN> ObtenerReporte()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.Adicionales.Desde1 = this.dtpFecDes.Text;
            iProDetEN.Adicionales.Hasta1 = this.dtpFecHas.Text;
            iProDetEN.CodigoSemiProducto = this.txtCodExiPT.Text.Trim();

            //ejecutar metodo
            return ProduccionDetaRN.ObtenerReporteCostoLoteFaseEnvasado(iProDetEN);
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

                iHoja.Cells.Item[1, 1] = "COSTOS POR LOTE - ETAPA ENVASADO";
                iHoja.Cells.Item[2, 1] = this.ObtenerTextoRangoFecha();
                iHoja.Cells.Item[3, 1] = this.ObtenerTextoProducto();

                //------------------
                //Obtener el reporte
                //------------------
                List <ProduccionDetaEN> iLisProDet = this.ObtenerReporte();
                
                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("LOTE", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("PRODUCCION", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("CODIGO", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("PRODUCTO", 50));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("UNIDADES", 20, 0));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("MATERIA PRIMA - ALMACEN MP", 20, 2, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("MATERIA PRIMA - REPROCESO", 20, 2, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENVASES", 20, 2, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("MANO OBRA DIRECTA", 20, 2, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("COSTOS INDIRECTOS DE FABRICACION - VARIABLES", 20, 2, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("TOTAL COSTO VARIABLE", 20, 2, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("COSTOS INDIRECTOS DE FABRICACION - FIJOS", 20, 2, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("COSTO TOTAL ENVASADO", 20, 2, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("COSTO UNITARIO ENVASADO", 20, 6, "COSTOS - ETAPA PROCESO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("POR LIBERAR", 20, 0, "CLASIFICACION - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("POR DESBLOQUEAR", 20, 0, "CLASIFICACION - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENCAJADAS", 20, 0, "CLASIFICACION - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REPROCESO", 20, 0, "CLASIFICACION - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("OBSERVACION", 20, 0, "CLASIFICACION - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("MUESTRA", 20, 0, "CLASIFICACION - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DONACION", 20, 0, "CLASIFICACION - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DESMEDRO", 20, 0, "CLASIFICACION - UNIDADES"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("POR LIBERAR", 20, 2, "CLASIFICACION - COSTO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("POR DESBLOQUEAR", 20, 2, "CLASIFICACION - COSTO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("ENCAJADAS", 20, 2, "CLASIFICACION - COSTO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("REPROCESO", 20, 2, "CLASIFICACION - COSTO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("OBSERVACION", 20, 2, "CLASIFICACION - COSTO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("MUESTRA", 20, 2, "CLASIFICACION - COSTO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DONACION", 20, 2, "CLASIFICACION - COSTO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("DESMEDRO", 20, 2, "CLASIFICACION - COSTO"));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("% DESMEDRO", 20, 2 ));


                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 2;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 4;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisProDet.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);
               
                //-----------------------------------------
                //llenando la matriz de datos para el excel
                //-----------------------------------------

                //matriz 
                object[,] objData = new Object[iEncExc.NumeroRegistros, 31];

                //indice para cada fila
                int iIndiceFila = -1;

                //recorrer cada objeto
                foreach (ProduccionDetaEN xProDet in iLisProDet)
                {
                    iIndiceFila++;
                    objData[iIndiceFila, 0] = xProDet.FechaProduccionDeta;
                    objData[iIndiceFila, 1] = xProDet.CorrelativoProduccionCabe;
                    objData[iIndiceFila, 2] = xProDet.CodigoSemiProducto;
                    objData[iIndiceFila, 3] = xProDet.DescripcionSemiProducto;
                    objData[iIndiceFila, 4] = xProDet.CantidadRealProduccion;
                    objData[iIndiceFila, 5] = xProDet.CostoMasaTotal;
                    objData[iIndiceFila, 6] = xProDet.CostoUnidadesReproceso;
                    objData[iIndiceFila, 7] = xProDet.CostoConCalTotal;
                    objData[iIndiceFila, 8] = xProDet.CostoTotalManoObra;
                    objData[iIndiceFila, 9] = xProDet.CostoCIFVariable;
                    objData[iIndiceFila, 10] = xProDet.CostoTotalVariable;
                    objData[iIndiceFila, 11] = xProDet.CostoCIFFijo;
                    objData[iIndiceFila, 12] = xProDet.CostoTotalEnvasado;
                    objData[iIndiceFila, 13] = xProDet.CostoTotalProducto;
                    objData[iIndiceFila, 14] = xProDet.SaldoLiberacion;
                    objData[iIndiceFila, 15] = xProDet.SaldoLiberacionBloqueadas;
                    objData[iIndiceFila, 16] = xProDet.UnidadesAprobadasLiberacion;
                    objData[iIndiceFila, 17] = xProDet.UnidadesReprocesoLiberacion;
                    objData[iIndiceFila, 18] = xProDet.UnidadesObservadasLiberacion;
                    objData[iIndiceFila, 19] = xProDet.UnidadesMuestraLiberacion;
                    objData[iIndiceFila, 20] = xProDet.UnidadesDonacionLiberacion;                    
                    objData[iIndiceFila, 21] = xProDet.UnidadesDesechasLiberacion;
                    objData[iIndiceFila, 22] = xProDet.CostoUnidadesPorLiberarLiberacion;
                    objData[iIndiceFila, 23] = xProDet.CostoUnidadesPorDesbloquearLiberacion;
                    objData[iIndiceFila, 24] = xProDet.CostoUnidadesAprobadasLiberacion;
                    objData[iIndiceFila, 25] = xProDet.CostoUnidadesReprocesoLiberacion;
                    objData[iIndiceFila, 26] = xProDet.CostoUnidadesObservadasLiberacion;
                    objData[iIndiceFila, 27] = xProDet.CostoUnidadesMuestraLiberacion;
                    objData[iIndiceFila, 28] = xProDet.CostoUnidadesDonacionLiberacion;                    
                    objData[iIndiceFila, 29] = xProDet.CostoUnidadesDesechasLiberacion;
                    objData[iIndiceFila, 30] = xProDet.PorcentajeUnidadesDesechasLiberacion;
                }

                //si la lista del reporte esta vacia,no ejecuta este codigo
                if (iLisProDet.Count != 0)
                {
                    //insertar los datos al excel
                    iRango = iHoja.get_Range("A6", iOpcional);
                    iRango = iRango.get_Resize(iEncExc.NumeroRegistros, 31);
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

        public void ListarExistenciasSE()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExiPT.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias SE";
            win.eCtrlValor = this.txtCodExiPT;
            win.eCtrlFoco = this.btnExportar;
            win.eExiEN.CodigoAlmacen = "A11";//almacen semi elaborados
            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValidoSE()
        {
            //solo si esta habilitado el control
            if (this.txtCodExiPT.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = "A11";//almacen semi elaborados
            iExiEN.CodigoExistencia = this.txtCodExiPT.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaValido(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia SE");
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
            wMen.CerrarVentanaHijo(this, wMen.IteCosLotEtaEnv, null);
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
            this.EsCodigoExistenciaValidoSE();
        }

        private void txtCodExiPT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistenciasSE(); }
        }

        private void txtCodExiPT_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistenciasSE();
        }

        private void ckbCodExi_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarCkbCodExi();
        }
    }
}
