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
    public partial class wSaldosPorExistencia : Heredados.MiForm8
    {
        public wSaldosPorExistencia()
        {
            InitializeComponent();
        }

        //atributos      
        Masivo eMas = new Masivo();
        List<SaldosExistencia> eLisSalExi = new List<SaldosExistencia>();
               

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;
            
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Existencia", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCodExi, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtAño, true, "Año", "vfff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnExportar, "vvvv");
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
            this.MostrarAñoActual();
            this.ActualizarListaSaldosExistencia();
            this.ActualizarDgvSal();
            this.txtCodAlm.Focus();
        }

        public void MostrarAñoActual()
        {
            this.txtAño.Text = Fecha.ObtenerAño(DateTime.Now);
        }

        public void ListarAlmacenes()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm;
            win.eCtrlFoco = this.txtCodExi;
            win.eCondicionLista = Listas.wLisAlm.Condicion.Almacenes;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el codigo almacen
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, "Almacen");
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarExistencias()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExi.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias";
            win.eCtrlValor = this.txtCodExi;
            win.eCtrlFoco = this.txtAño;
            win.eExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();            
            win.eCondicionLista = wLisExi.Condicion.ExistenciasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodExi.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN =new ExistenciaEN();
            iExiEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaValido(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia");
                this.txtCodExi.Focus();
            }

            //pasar datos
            this.txtCodExi.Text = iExiEN.CodigoExistencia;
            this.txtDesExi.Text = iExiEN.DescripcionExistencia;           
            this.txtNUniMed.Text = iExiEN.NombreUnidadMedida;
          
            //devolver
            return iExiEN.Adicionales.EsVerdad;
        }

        public List<SaldosExistencia> ObtenerConsulta()
        {
            //asignar parametros
            SaldoEN iSalEN = new SaldoEN();
            iSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSalEN.AñoSaldo = this.txtAño.Text.Trim();
            iSalEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iSalEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iSalEN.ClaveSaldo = SaldoRN.ObtenerClaveSaldo(iSalEN);

            //ejecutar metodo
            return SaldoRN.ListarParaSaldosExistencia(iSalEN);
        }

        public void ActualizarListaSaldosExistencia()
        {
            this.eLisSalExi = this.ObtenerConsulta();
        }

        public void ActualizarDgvSal()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<SaldosExistencia> iFuenteDatos = this.eLisSalExi;
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SaldosExistencia.NMes, "Mes", 90));          
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(SaldosExistencia.StoAnt, "Sal.Inicial", 100, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(SaldosExistencia.Ing, "Ingresos", 100, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(SaldosExistencia.Sal, "Salidas", 100, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(SaldosExistencia.StoAct, "Saldo", 100, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SaldosExistencia.CMes, "CMes", 90, false));

            //devolver
            return iLisRes;
        }

        public void Aceptar()
        {
            //validar campos obligatorios
            if (this.eMas.CamposObligatorios() == false) { return; }

            //actualizar la lista de saldo existencia
            this.ActualizarListaSaldosExistencia();

            //Imprime si todo esta ok
            this.ActualizarDgvSal();
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

                iHoja.Cells.Item[1, 1] = "Almacen :  " + this.txtCodAlm.Text + " - " + this.txtDesAlm.Text;
                iHoja.Cells.Item[2, 1] = "Existencia :  " + this.txtCodExi.Text + " - "+ this.txtDesExi.Text;
                iHoja.Cells.Item[3, 1] = "Unidad :  " + this.txtNUniMed.Text;
                iHoja.Cells.Item[4, 1] = "Año :  " + this.txtAño.Text;

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Mes", 12));                
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Sal.Inicial", 18, 3));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Ingresos", 18, 3));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Salidas", 18, 3));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("Saldo", 18, 3));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 5;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = this.eLisSalExi.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 5;

                //recorrer cada objeto
                foreach (SaldosExistencia xSalExi in this.eLisSalExi)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xSalExi.NombreMes;
                    iHoja.Cells.Item[iIndiceFila, 2] = xSalExi.StockAnterior;
                    iHoja.Cells.Item[iIndiceFila, 3] = xSalExi.Ingresos;
                    iHoja.Cells.Item[iIndiceFila, 4] = xSalExi.Salidas;
                    iHoja.Cells.Item[iIndiceFila, 5] = xSalExi.StockActual;
                    
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

        public void AccionConsultarMovimientosAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //instanciar ventana
            wMovimientosXExistencia win = new wMovimientosXExistencia();
            win.wSalExi = this;            
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(this.ObtenerMovimientoDetaParaConsulta());
        }

        public MovimientoDetaEN ObtenerMovimientoDetaParaConsulta()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iMovDetEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iMovDetEN.PeriodoMovimientoCabe = this.txtAño.Text.Trim() + "-" + Dgv.ObtenerValorCelda(this.dgvMovDet, SaldosExistencia.CMes);

            //devolver
            return iMovDetEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteSaldosPorExistencia, null);
        }

        #endregion

        private void wSaldosPorExistencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();         
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValido();
        }

        private void txtCodAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes(); }
        }

        private void txtCodAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValido();
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistencias(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistencias();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.ExportarExcel();
        }

        private void dgvMovDet_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionConsultarMovimientosAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }


    }
}
