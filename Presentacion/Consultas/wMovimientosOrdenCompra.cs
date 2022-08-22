using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heredados;
using WinControles;
using WinControles.ControlesWindows;
using Entidades;
using Negocio;
using Entidades.Adicionales;
using Comun;
using Presentacion.Principal;
using System.Collections;
using Presentacion.Maestros;
using Heredados.VentanasPersonalizadas;
using System.Reflection;
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;

namespace Presentacion.Consultas
{
    public partial class wMovimientosOrdenCompra : Heredados.MiForm8
    {
        public wMovimientosOrdenCompra()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvMovCab = MovimientoOCCabeEN.NumMovCab;
        string eEncabezadoColumnaDgvMovCab = "Numero";
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<MovimientoOCCabeEN> eLisMovCab = new List<MovimientoOCCabeEN>();
        int eVaBD = 1;//0 : no , 1 : si
        string eTitulo = "Orden de Compra";

        #endregion
        
        #region General
        
        public void NuevaVentana()
        {
            this.Show();
            this.MostrarPersistencia();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaMovimientoCabesDeBaseDatos();
            this.ActualizarDgvMovCab();
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.TituloCabe();
            this.ActualizarDgvMovDet();
            this.TituloDeta();
            this.AccionBuscar();
        }

        public void TituloCabe()
        {
            int iNumeroRegistros = Dgv.ObtenerNumeroRegistros(this.DgvMovCab);
            this.lblTituloCabe.Text = string.Empty;
            this.lblTituloCabe.Text += "Movimientos de la empresa : " + Universal.gNombreEmpresa;
            this.lblTituloCabe.Text += " / Nro : " + iNumeroRegistros.ToString();
        }

        public void TituloDeta()
        {
            string iMovimientoActual = string.Empty;
            int iNumeroLineas = Dgv.ObtenerNumeroRegistros(this.dgvMovDet);
            this.lblTituloDeta.Text = string.Empty;
            iMovimientoActual = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoOCCabeEN.NumMovCab);
            this.lblTituloDeta.Text += "Lineas del movimiento : " + iMovimientoActual;
            this.lblTituloDeta.Text += " / Nro : " + iNumeroLineas.ToString();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvMovCab;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvMovCab()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvMovCab;
            List<MovimientoOCCabeEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvMovCab;
            string iClaveBusqueda = eClaveDgvMovCab;
            string iColumnaPintura = eNombreColumnaDgvMovCab;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMovCab();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMovCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NumMovCab, "Numero", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.FecMovCab, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.PerMovCab, "Periodo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NClaTipOpe, "Clase", 62));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesTipOpe, "Tip.Operacion", 220));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesAlm, "Almacen", 130));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesAux, "Cliente/Proveedor", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NTipDoc, "T.D", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.SerDoc, "Serie", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NumDoc, "N.D", 65));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NomPer, "Personal", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.GloMovCab, "Glosa", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NOriVenCre, "Origen", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaMovimientoCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            iCuoEN.PeriodoMovimientoCabe = lblPeriodo.Text;          
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvMovCab;
            this.eLisMovCab = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodo(iCuoEN);
        }

        public List<MovimientoOCCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvMovCab;
            List<MovimientoOCCabeEN> iListaMovimientoCabes = eLisMovCab;

            //ejecutar y retornar
            return MovimientoOCCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaMovimientoCabes);
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDeta()
        {
            //asignar parametros
            string iClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoOCCabeEN.ClaObj);

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iClaveMovimientoCabe);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMovDet()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.CorMovDet, "Linea", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.DesExi, "Descripcion", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.DesCenCos, "Centro Costo", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoOCDetaEN.CanMovDet, "Cant", 60, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoOCDetaEN.PreUniMovDet, "P/U", 85, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoOCDetaEN.CosMovDet, "Costo", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarDgvMovDet()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<MovimientoOCDetaEN> iFuenteDatos = this.ListarMovimientosDeta();
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMovDet();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public void AsignarMovimientoCabe(MovimientoOCCabeEN pIng)
        {
            pIng.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoOCCabeEN.ClaObj);
            pIng.PeriodoMovimientoCabe = lblPeriodo.Text;         
        }

        //public void AccionImprimirNota()
        //{
        //    //preguntar si el registro seleccionado existe
        //    MovimientoOCCabeEN iMovCabEN = this.EsMovimientoCabeExistente();
        //    if (iMovCabEN.Adicionales.EsVerdad == false) { return; }

        //    //segun ClaseTipoOperacion
        //    if (iMovCabEN.CClaseTipoOperacion == "1")//ingreso
        //    {
        //        wImpNotaIngreso win = new wImpNotaIngreso();
        //        win.wMov = this;
        //        win.eVentana = wImpNotaIngreso.Ventana.wMovimientosOrdenCompra;
        //        win.NuevaVentana(iMovCabEN);
        //    }
        //    else
        //    {
        //        //salida
        //        wImpNotaSalida win = new wImpNotaSalida();
        //        win.wMov = this;
        //        win.eVentana = wImpNotaSalida.Ventana.wMovimientosOrdenCompra;
        //        win.NuevaVentana(iMovCabEN);
        //    }           
        //}

        public void AccionExportarExcel()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
            excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
            int IndiceColumna = 0;
            foreach (DataGridViewColumn columna in this.DgvMovCab.Columns) //Aquí empezamos a leer las columnas del listado a exportar
            {
                IndiceColumna++;
                excel.Cells[1, IndiceColumna] = columna.Name;
            }
            int IndiceFila = 0;
            foreach (DataGridViewRow fila in this.DgvMovCab.Rows) //Aquí leemos las filas de las columnas leídas
            {
                IndiceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn columna in this.DgvMovCab.Columns)
                {
                    IndiceColumna++;
                    excel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
                }
            }
            excel.Visible = true;
        }

        public void AccionSeleccionarPeriodo()
        {
            vSeleccionarPeriodo win = new vSeleccionarPeriodo();
            win.eVentanaInvoca = this;
            win.eControlDevuelveValor =  lblPeriodo;
            win.ePeriodoActual = lblPeriodo.Text;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
          
        public MovimientoOCCabeEN EsMovimientoCabeExistente()
        {
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            iCuoEN = MovimientoOCCabeRN.EsMovimientoCabeExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public void AccionCambiaPeriodo()
        {
            //poner la descripcion del mes
            lblDescripcionPeriodo.Text = AñoMes.ObtenerDescripcionPeriodo(lblPeriodo.Text);
           
            //guardar el nuevo periodo
            Properties.Settings.Default.GuardarPeriodoMovimientos = TsL.ModificarValor(Properties.Settings.Default.GuardarPeriodoMovimientos, Universal.gCodigoEmpresa, lblPeriodo);
            Properties.Settings.Default.Save();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void MostrarPersistencia()
        {
            TsL.MostrarValor(lblPeriodo, Properties.Settings.Default.GuardarPeriodoMovimientos, Universal.gCodigoEmpresa);
        }
      
        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteConsultaOrdenCompra, null);
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvMovCab = this.DgvMovCab.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvMovCab = this.DgvMovCab.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }


        #endregion

        
        private void wMovimientosOrdenCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvMovCab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.ActualizarDgvMovDet();
            this.TituloDeta();
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Ultimo);
        }

        private void DgvMovCab_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }

        private void tsbImprimirNota_Click(object sender, EventArgs e)
        {
            //this.AccionImprimirNota();
        }

        private void tsbExportarExcel_Click(object sender, EventArgs e)
        {
            this.AccionExportarExcel();
        }
    }
}
