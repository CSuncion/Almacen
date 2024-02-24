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
using Entidades;
using Negocio;
using Entidades.Adicionales;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;

namespace Presentacion.ProcesosCompras
{
    public partial class wSelAux : Heredados.MiForm8
    {
        public wSelAux()
        {
            InitializeComponent();
        }


        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumSolPedidoCab, this.btnGenerar, "ffff");
            xLis.Add(xCtrl);
            return xLis;
        }

        #endregion

        #region Enumeraciones

        public enum Condicion
        {
            Proveedores = 0,
            Clientes,
            ProveedoresActivos,
            ClientesActivos,
        }


        #endregion

        #region Propietario

        public wSolicitudPedido wSol;
        public wRequerimiento wFrm;
        public Form eVentana = new Form();
        public AuxiliarEN eAuxEN = new AuxiliarEN();
        public List<AuxiliarEN> eLisAux = new List<AuxiliarEN>();
        public List<SolicitudPedidoCabeEN> eLisMovCab = new List<SolicitudPedidoCabeEN>();
        public List<SolicitudPedidoDetaEN> eLisMovDet = new List<SolicitudPedidoDetaEN>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        public Universal.Opera eOperacion;
        public string periodo;
        public string xAux;
        Masivo eMas = new Masivo();
        #endregion


        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eAuxEN.Adicionales.CampoOrden = AuxiliarEN.DesAux;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = " Descripcion";

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            this.ActualizaVentana();
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.Show();
            //this.txtBus.Focus();
        }

        public void ActualizaVentana()
        {
            this.ActualizarListaAuxiliarsDeBaseDatos();
            this.gbBus.Text = "Solicitud de Pedido :" + this.eCampoBusqueda;
            this.ActualizarDgvLista();
            Dgv.PintarColumna(this.DgvLista, eAuxEN.Adicionales.CampoOrden);
        }

        public void ActualizarDgvLista()
        {
            //llenar la grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvLista;
            iDgv.RefrescarDatosGrilla(this.ObtenerDatosParaGrilla());

            //asignando columnas
            iDgv.AsignarColumnaTextCadena(AuxiliarEN.CodAux, "Codigo", 80);
            iDgv.AsignarColumnaTextCadena(AuxiliarEN.DesAux, "Descripcion", 260);
            iDgv.AsignarColumnaCheckBox(AuxiliarEN.VerFal, "Seleccionar", 80);
            iDgv.AsignarColumnaTextCadena(AuxiliarEN.ClaAux, "ClaveObjeto", 10, false);
        }

        public void ActualizarListaAuxiliarsDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //valida si ya hay chequeados
            if (this.eLisAux.Count != 0) { return; }

            //if (this.eLisAux.FirstOrDefault(x => x.VerdadFalso).VerdadFalso) { return; }
            eAuxEN.CodigoAuxiliar = this.xAux;

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.Proveedores: { this.eLisAux = AuxiliarRN.ListarProveedoresSinAuxiliarSolicitudPedido(eAuxEN); break; }
                case Condicion.Clientes: { this.eLisAux = AuxiliarRN.ListarClientes(eAuxEN); break; }
                case Condicion.ProveedoresActivos: { this.eLisAux = AuxiliarRN.ListarProveedoresActivos(eAuxEN); break; }
                case Condicion.ClientesActivos: { this.eLisAux = AuxiliarRN.ListarClientesActivos(eAuxEN); break; }
            }
        }

        public List<AuxiliarEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = txtBus.Text.Trim();
            string iCampoBusqueda = eAuxEN.Adicionales.CampoOrden;
            List<AuxiliarEN> iListaAuxiliars = eLisAux;

            //ejecutar y retornar
            return AuxiliarRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaAuxiliars);
        }

        public void DevolverDato()
        {
            if (this.DgvLista.Rows.Count == 0)
            {
                return;
            }
            else
            {
                this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, AuxiliarEN.CodAux);
                this.Close();
                this.eCtrlValor.Focus();
                this.eCtrlFoco.Focus();
            }
        }

        public void OrdenarPorColumna(int pColumna)
        {
            eAuxEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            //Txt.CursorAlUltimo(this.txtBus);
        }

        public void VentanaAgregarVarios(SolicitudPedidoCabeEN pMovCab)
        {
            this.MostrarSolicitudPedidoCabe(pMovCab);
            this.InicializaVentana();
            //this.LLenarSolicitudPedidoDetaDeBaseDatos(pMovCab);
            //this.LLenarLotesDeBaseDatos(pMovCab);
            //this.MostrarSolicitudPedidosDeta();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            //this.txtBus.Focus();
        }

        public void MostrarSolicitudPedidoCabe(SolicitudPedidoCabeEN pMovCab)
        {
            this.txtNumSolPedidoCab.Text = pMovCab.NumeroSolicitudPedidoCabe;
            this.periodo = pMovCab.PeriodoSolicitudPedidoCabe;
            this.xAux = pMovCab.CodigoAuxiliar;
            //this.txtCodAlm.Text = pMovCab.CodigoAlmacen;
            //this.txtDesAlm.Text = pMovCab.DescripcionAlmacen;
            //this.txtCodPer.Text = pMovCab.CodigoPersonal;
            //this.txtNomPer.Text = pMovCab.NombrePersonal;
            //this.txtCodPerAut.Text = pMovCab.CodigoPersonalAutoriza;
            //this.txtNomPerAut.Text = pMovCab.NombrePersonalAutoriza;
            //this.txtCosFle.Text = Formato.NumeroDecimal(pMovCab.CostoFleteSolicitudPedidoCabe, 2);
            //Cmb.SeleccionarValorItem(this.cmbMon, pMovCab.CCodigoMoneda);
            //this.txtCodAux.Text = pMovCab.CodigoAuxiliar;
            //this.txtDesAux.Text = pMovCab.DescripcionAuxiliar;
            //this.dtpFecDoc.Text = pMovCab.FechaDocumento;
            //this.txtGloMovCab.Text = pMovCab.GlosaSolicitudPedidoCabe;
        }
        public void AsignarNuevaSolicitudPedido(int pFilaChequeada, int pColumnaChequeada)
        {
            //solo debe actuar cuando la columna sea "0" y la fila diferente de "-1"
            if (pColumnaChequeada == 2 && pFilaChequeada != -1)
            {
                AuxiliarEN iAuxEN = new AuxiliarEN();
                iAuxEN.ClaveAuxiliar = Dgv.ObtenerValorCelda(this.DgvLista, AuxiliarEN.ClaAux);
                iAuxEN.VerdadFalso = !this.eLisAux[pFilaChequeada].VerdadFalso;
                AuxiliarRN.AsignarAuxiliarPedido(iAuxEN, this.eLisAux);
            }
        }

        public List<int> listaCheckAux()
        {
            List<int> cuentaCheck = new List<int>();
            int cuenta = 0;
            for (int i = 0; i < this.eLisAux.Count; i++)
            {
                if (Convert.ToBoolean(this.eLisAux[i].VerdadFalso))
                {
                    cuentaCheck.Add(cuenta++);
                }
            }
            return cuentaCheck;
        }


        public bool EsValidoEnvio()
        {
            //valida la grilla vacia
            if (DgvLista.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("no hay registros en la grilla", this.wSol.eTitulo);
                return false;
            }

            //validar cuotas marcadas
            List<int> iLisMar = this.listaCheckAux();
            if (iLisMar.Count == 0)
            {
                Mensaje.OperacionDenegada("Al menos debes chequear un registro", this.wSol.eTitulo);
                return false;
            }

            //ok
            return true;
        }

        public void GenerarNuevaSolicitudPedido()
        {
            //validar envio
            if (this.EsValidoEnvio() == false) { return; }


            if (Mensaje.DeseasRealizarOperacion(this.wSol.eTitulo) == false) { return; }
            //ir a la bd
            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            iCuoEN.PeriodoSolicitudPedidoCabe = this.periodo;
            //iCuoEN.CClaseTipoOperacion = "1";//ingreso
            iCuoEN.Adicionales.CampoOrden = txtNumSolPedidoCab.Text;
            this.eLisMovCab = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesXPeriodoYClaseOperacion(iCuoEN);

            //asignar parametros
            string iValorBusqueda = txtNumSolPedidoCab.Text.Trim();
            string iCampoBusqueda = SolicitudPedidoCabeEN.NumMovCab;
            List<SolicitudPedidoCabeEN> iListaSolicitudPedidoCabes = eLisMovCab;

            //ejecutar y retornar
            this.eLisMovCab = SolicitudPedidoCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaSolicitudPedidoCabes);

            string xClaveSolicitudPedidoCabe = eLisMovCab.Find(x => x.NumeroSolicitudPedidoCabe == txtNumSolPedidoCab.Text.Trim()).ClaveSolicitudPedidoCabe;

            //bool xMasivoSolicitudPedidoCabe = eLisMovCab.Find(x => x.NumeroSolicitudPedidoCabe == txtNumSolPedidoCab.Text.Trim()).MasivoSolicitudPedidoCabe;
            //if (!xMasivoSolicitudPedidoCabe)
            //{

            //}
            //else
            foreach (AuxiliarEN xAux in eLisAux)
            {
                if (xAux.VerdadFalso)
                {
                    foreach (SolicitudPedidoCabeEN xSolPedCabe in this.eLisMovCab)
                    {
                        //mostrar en pantalla

                        xSolPedCabe.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(xSolPedCabe);
                        xSolPedCabe.CodigoAuxiliar = xAux.CodigoAuxiliar;
                        xSolPedCabe.CCopiaSolicitudPedidoCabe = "1";
                        xSolPedCabe.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(xSolPedCabe);
                        SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(xSolPedCabe);

                        SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
                        iMovDetEN.ClaveSolicitudPedidoCabe = xClaveSolicitudPedidoCabe;
                        iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;
                        this.eLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(iMovDetEN);

                        string iCorrelativo = "0000";
                        foreach (SolicitudPedidoDetaEN xSolPedDeta in this.eLisMovDet)
                        {
                            //incrementar el correlativo
                            iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);
                            xSolPedDeta.ClaveSolicitudPedidoCabe = xSolPedCabe.ClaveSolicitudPedidoCabe;
                            xSolPedDeta.CorrelativoSolicitudPedidoDeta = iCorrelativo;
                            xSolPedDeta.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(xSolPedDeta);

                            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(xSolPedDeta);
                        }

                        this.GenerarSolicitudPedido(xSolPedCabe, this.eLisMovDet);
                    }
                }
            }

            Mensaje.OperacionSatisfactoria("Se agrego la solicitud de pedido correctamente", this.wSol.eTitulo);

            //actualizar al propietario           
            //this.wFrm.eClaveDgvMovCab = this.ObtenerClaveSolicitudPedidoCabe();
            this.wSol.ActualizarVentana();
            this.Close();
        }

        public void GenerarSolicitudPedido(SolicitudPedidoCabeEN eLisMovCab,
        List<SolicitudPedidoDetaEN> eLisMovDet)
        {

            ParametroEN iParEN = ParametroRN.BuscarParametro();

            string fileName = "SolicitudPedido_" + eLisMovCab.ClaveSolicitudPedidoCabe + ".xlsx";

            string sourceFile = iParEN.RutaCarpetaPlantillas + @"\FORMATO ORDEN DE COMPRA.xlsx";

            string targetPath = iParEN.RutaCarpetaPlantillas;

            string destFile = System.IO.Path.Combine(targetPath, fileName);

            System.IO.Directory.CreateDirectory(targetPath);

            if (System.IO.File.Exists(destFile))
            {
                System.IO.File.Delete(destFile);
            }

            System.IO.File.Copy(sourceFile, destFile, true);


            Excel.Application app = new Excel.Application();

            Excel.Workbook iLibro;
            Excel.Worksheet iHoja;
            Excel.Range iRango;
            object iOpcional = System.Reflection.Missing.Value;

            //creamos una nueva aplicacion excel
            app = new Microsoft.Office.Interop.Excel.Application();

            //adicionamos el libro a la aplicacion
            iLibro = app.Workbooks.Add(destFile);

            //obtener la hoja 1 del libro
            iHoja = iLibro.Worksheets["PLANTILLA"];

            //dando el zoom predeterminado a la hoja
            app.ActiveWindow.Zoom = 73;

            iHoja.Cells[2, "AA"] = "Lima " + DateTime.Now.Day.ToString("00") + " de " + Fecha.ObtenerMesEnNombre(DateTime.Now.Month) + " del " + DateTime.Now.Year;
            iHoja.Cells[2, "AH"] = Fecha.ObtenerHoraActualEnFormato24Horas();

            iHoja.Cells[12, "F"] = eLisMovCab.NumeroSolicitudPedidoCabe;
            iHoja.Cells[13, "F"] = eLisMovCab.NOrigenVentanaCreacion;
            iHoja.Cells[14, "F"] = eLisMovCab.FechaSolicitudPedidoCabe;
            iHoja.Cells[17, "F"] = eLisMovCab.NumeroSolicitudPedidoCabe;

            iHoja.Cells[21, "F"] = eLisMovCab.DescripcionAuxiliar;
            iHoja.Cells[22, "F"] = eLisMovCab.CodigoAuxiliar;

            int filaItem = 29;
            int filaNueva = 0;
            int item = 0;

            foreach (SolicitudPedidoDetaEN solDeta in eLisMovDet)
            {
                item++;
                iHoja.Cells[filaItem, "A"] = item;
                iHoja.Cells[filaItem, "D"] = solDeta.CodigoExistencia;
                iHoja.Cells[filaItem, "F"] = solDeta.DescripcionExistencia;
                iHoja.Cells[filaItem, "U"] = solDeta.CantidadSolicitudPedidoDeta;
                iHoja.Cells[filaItem, "X"] = solDeta.NombreUnidadMedida;
                filaItem++;
                Excel.Range to = iHoja.Range["A" + filaItem + ":AI" + filaItem];
                to.Insert();
                //from.Copy(to);                
            }

            iLibro.SaveAs(destFile, Excel.XlFileFormat.xlWorkbookDefault, iOpcional, iOpcional, true, iOpcional,
                Excel.XlSaveAsAccessMode.xlExclusive, iOpcional, iOpcional, iOpcional, iOpcional, iOpcional);
            iLibro.Close(true, iOpcional, iOpcional);
            app.Quit();

        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvLista, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.txtBus); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        this.ActualizaVentana();
                        break;
                    }
            }
        }

        private void wSelAux_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.GenerarNuevaSolicitudPedido();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.AsignarNuevaSolicitudPedido(e.RowIndex, e.ColumnIndex);
        }
        #endregion

        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si se selecciono la barra espaciadora
            //if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13){this.DevolverDato();}
        }

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }
    }
}
