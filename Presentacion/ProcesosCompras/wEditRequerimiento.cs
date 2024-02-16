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
using Presentacion.Impresiones;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Presentacion.ProcesosCompras
{
    public partial class wEditRequerimiento : Heredados.MiForm8
    {
        public wEditRequerimiento()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvTipOpe = TipoCambioEN.FecTipCam;
        string eNombreColumnaDgvPer = PresupuestoEN.CodPre;
        public Universal.Opera eOperacion;
        public string wTipoCambio, wano, wmes, wperiodo;
        Masivo eMas = new Masivo();
        public List<SolicitudPedidoDetaEN> eLisMovDet = new List<SolicitudPedidoDetaEN>();
        public List<LoteEN> eLisLot = new List<LoteEN>();
        public string eClaveDgvMovDet = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;
        public List<PresupuestoEN> eLisPre = new List<PresupuestoEN>();
        public List<TipoCambioEN> eLisTipCam = new List<TipoCambioEN>();

        #endregion

        #region Propietario

        public wRequerimiento wFrm;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPerMovCab, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumMovCab, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecMovCab, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecMovFinCab, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "ffff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer, true, "Personal", "ffff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer, this.txtCodPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPerAut, true, "Persona Autoriza", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPerAut, this.txtCodPerAut, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCosFle, false, "Flete", "vvff", 2);
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtNumeroPositivoConDecimales(this.txtPresupuesto, false, "Presupuesto", "ffff", 2);
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMon, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTipCam, false, "Tipo Cambio", "ffff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, false, "Proveedor", "ffff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux, "ffff");
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDoc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGloMovCab, false, "Glosa", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnModificar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
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
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wFrm.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //Cargas Monedas
            this.CargarMonedas();

            //valores x defecto
            this.ValoresXDefecto();
            this.EsAlmacenValido();

            // Deshabilitar al propietario de esta ventana
            this.wFrm.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto()
        {
            this.txtPerMovCab.Text = wFrm.lblDescripcionPeriodo.Text;
            this.txtCodAlm.Text = "A01";
        }

        public void VentanaAdicionar()
        {
            //
            
            txtPerMovCab.Text = wFrm.lblDescripcionPeriodo.Text;
            wano = this.txtPerMovCab.Text.Substring(0, 4);
            wmes = this.txtPerMovCab.Text.Substring(5).ToUpper();
            this.NumeroMesDelNombreDelMes();
            wperiodo = Universal.gCodigoEmpresa + "-" + wano + "-" + wmes;
            //Buscar Tipo de cambio del periodo
            PeriodoEN nPeri = new PeriodoEN();
            nPeri.ClavePeriodo = wperiodo;
            nPeri = PeriodoRN.BuscarPeriodoXClave(nPeri);
            wTipoCambio = nPeri.TipoCambioPeriodo.ToString();
            //
            this.InicializaVentana();
            this.MostrarSolicitudPedidoCabe(SolicitudPedidoCabeRN.EnBlanco());
            this.MostrarFechaIngresoSugerida();
            this.CargarTipoCambio();
            this.MostrarSolicitudPedidosDeta();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            //this.txtTipCam.Text = wTipoCambio;
            this.dtpFecMovCab.Focus();
        }

        public void VentanaModificar(SolicitudPedidoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarSolicitudPedidoCabe(pMovCab);
            this.CargarTipoCambio();
            this.LLenarSolicitudPedidoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarSolicitudPedidosDeta();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void VentanaEliminar(SolicitudPedidoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarSolicitudPedidoCabe(pMovCab);
            this.CargarTipoCambio();
            this.LLenarSolicitudPedidoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarSolicitudPedidosDeta();
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(SolicitudPedidoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarSolicitudPedidoCabe(pMovCab);
            this.CargarTipoCambio();
            this.LLenarSolicitudPedidoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarSolicitudPedidosDeta();
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void NumeroMesDelNombreDelMes()
        {
            if (wmes == "ENERO")
            {
                wmes = "01";
            }
            if (wmes == "FEBRERO")
            {
                wmes = "02";
            }
            if (wmes == "MARZO")
            {
                wmes = "03";
            }
            if (wmes == "ABRIL")
            {
                wmes = "04";
            }
            if (wmes == "MAYO")
            {
                wmes = "05";
            }
            if (wmes == "JUNIO")
            {
                wmes = "06";
            }
            if (wmes == "JULIO")
            {
                wmes = "07";
            }
            if (wmes == "AGOSTO")
            {
                wmes = "08";
            }
            if (wmes == "SETIEMBRE")
            {
                wmes = "09";
            }
            if (wmes == "OCTUBRE")
            {
                wmes = "10";
            }
            if (wmes == "NOVIEMBRE")
            {
                wmes = "11";
            }
            if (wmes == "DICIEMBRE")
            {
                wmes = "12";
            }
        }


        public void CargarMonedas()
        {
            Cmb.Cargar(this.cmbMon, ItemGRN.ListarItemsG("Moneda"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarSolicitudPedidoCabe(SolicitudPedidoCabeEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCab.PeriodoSolicitudPedidoCabe = wFrm.lblPeriodo.Text;
            pMovCab.NumeroSolicitudPedidoCabe = this.txtNumMovCab.Text.Trim();
            pMovCab.FechaSolicitudPedidoCabe = dtpFecMovCab.Text;
            pMovCab.FechaSolicitudPedidoFinCabe = dtpFecMovFinCab.Text;
            pMovCab.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pMovCab.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            pMovCab.CodigoPersonal = this.txtCodPer.Text.Trim();
            pMovCab.CodigoPersonalAutoriza = this.txtCodPerAut.Text.Trim();
            pMovCab.CostoFleteSolicitudPedidoCabe = Conversion.ADecimal(this.txtCosFle.Text, 0);
            pMovCab.MasivoSolicitudPedidoCabe = chkMasivo.Checked;
            pMovCab.CCodigoMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            pMovCab.TipoCambio = Conversion.ADecimal(this.txtTipCam.Text, 2);
            pMovCab.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pMovCab.DescripcionAuxiliar = this.txtDesAux.Text.Trim();
            pMovCab.FechaDocumento = dtpFecDoc.Text;
            pMovCab.GlosaSolicitudPedidoCabe = this.txtGloMovCab.Text;
            pMovCab.COrigenVentanaCreacion = "1";//ingreso          
            pMovCab.FlagEnviadoSolicitudPedido = false;//ingreso       
            pMovCab.CEstadoSolicitudPedidoCabe = "1";
            pMovCab.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(pMovCab);
        }

        public void MostrarSolicitudPedidoCabe(SolicitudPedidoCabeEN pMovCab)
        {
            this.txtNumMovCab.Text = pMovCab.NumeroSolicitudPedidoCabe;
            this.dtpFecMovCab.Text = pMovCab.FechaSolicitudPedidoCabe;
            this.dtpFecMovFinCab.Text = pMovCab.FechaSolicitudPedidoFinCabe;
            //this.txtCodAlm.Text = pMovCab.CodigoAlmacen;
            //this.txtDesAlm.Text = pMovCab.DescripcionAlmacen;
            //this.txtCodPer.Text = pMovCab.CodigoPersonal;
            //this.txtNomPer.Text = pMovCab.NombrePersonal;
            this.txtCodPerAut.Text = pMovCab.CodigoPersonalAutoriza;
            this.txtNomPerAut.Text = pMovCab.NombrePersonalAutoriza;
            this.txtCosFle.Text = Formato.NumeroDecimal(pMovCab.CostoFleteSolicitudPedidoCabe, 2);
            Cmb.SeleccionarValorItem(this.cmbMon, pMovCab.CCodigoMoneda);
            this.txtCodAux.Text = pMovCab.CodigoAuxiliar;
            this.txtDesAux.Text = pMovCab.DescripcionAuxiliar;
            this.dtpFecDoc.Text = pMovCab.FechaDocumento;
            this.txtGloMovCab.Text = pMovCab.GlosaSolicitudPedidoCabe;
            this.chkMasivo.Checked = pMovCab.MasivoSolicitudPedidoCabe;
        }

        public void MostrarSolicitudPedidosDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<SolicitudPedidoDetaEN> iFuenteDatos = SolicitudPedidoDetaRN.RefrescarListaSolicitudPedidoDeta(this.eLisMovDet); ;
            Dgv.Franja iCondicionFranja = eFranjaDgvMovDet;
            string iClaveBusqueda = eClaveDgvMovDet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoDetaEN.CorMovDet, "Linea", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoDetaEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoDetaEN.DesExi, "Descripcion", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoDetaEN.DesCenCos, "Centro Costo", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoDetaEN.NCodPar, "Partida", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(SolicitudPedidoDetaEN.CanMovDet, "Cant", 60, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(SolicitudPedidoDetaEN.PreUltCom, "Prec. Ult. Compra", 85, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoDetaEN.FecUltCom, "Fec. Ult. Compra", 90));
            //iLisRes.Add(Dgv.NuevaColumnaTextNumerico(SolicitudPedidoDetaEN.CosFleMovDet, "Flete", 70, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoDetaEN.NCodMon, "Moneda", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarSolicitudPedidoDetaDeBaseDatos(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveSolicitudPedidoCabe = pObj.ClaveSolicitudPedidoCabe;
            iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;
            this.eLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(iMovDetEN);
        }

        public void LLenarLotesDeBaseDatos(SolicitudPedidoCabeEN pObj)
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            iLotEN.ClaveMovimientoCabe = pObj.ClaveSolicitudPedidoCabe;
            iLotEN.Adicionales.CampoOrden = LoteEN.CodExi + "," + LoteEN.CodLot;

            //ejecutar metodo
            this.eLisLot = LoteRN.ListarLotesDeClaveMovimientoCabe(iLotEN);
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto adicionar
            if (this.wFrm.EsActoAdicionarSolicitudPedidoCabe().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //mostrar numero SolicitudPedidoCabe
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarSolicitudPedidoCabe();

            //adicionando detalles
            this.AdicionarSolicitudPedidosDeta();

            //adicionando lotes
            this.AdicionarLotes();

            //actualizar las existencias referenciadas
            this.ActualizarExistenciasPorAdicion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la solicitud de pedido correctamente", this.wFrm.eTitulo);

            //actualizar al propietario           
            this.wFrm.eClaveDgvMovCab = this.ObtenerClaveSolicitudPedidoCabe();
            this.wFrm.ActualizarVentana();

            //imprimir la nota
            //this.wFrm.AccionImprimirNota();

            this.GenerarSolicitudPedido();

            //limpiar controles
            this.MostrarSolicitudPedidoCabe(this.ObtenerSolicitudPedidoCabeParaSegundaAdicion());
            this.eLisMovDet.Clear();
            this.MostrarSolicitudPedidosDeta();
            this.eLisLot.Clear();
            this.CambiarSoloLecturaACodigoTipoOperacion();
            this.CambiarSoloLecturaACodigoAlmacen();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void GenerarSolicitudPedido()
        {
            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iCuoEN);

            List<SolicitudPedidoDetaEN> list = this.eLisMovDet;

            ParametroEN iParEN = ParametroRN.BuscarParametro();

            string fileName = "SolicitudPedido_" + iCuoEN.ClaveSolicitudPedidoCabe + ".xlsx";

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
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            Excel.Range iRango;
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
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

            iHoja.Cells[12, "F"] = iCuoEN.NumeroSolicitudPedidoCabe;
            iHoja.Cells[13, "F"] = iCuoEN.NOrigenVentanaCreacion;
            iHoja.Cells[14, "F"] = iCuoEN.FechaSolicitudPedidoCabe;
            iHoja.Cells[17, "F"] = iCuoEN.NumeroSolicitudPedidoCabe;

            iHoja.Cells[21, "F"] = iCuoEN.DescripcionAuxiliar;
            iHoja.Cells[22, "F"] = iCuoEN.CodigoAuxiliar;

            int filaItem = 29;
#pragma warning disable CS0219 // La variable está asignada pero nunca se usa su valor
            int filaNueva = 0;
#pragma warning restore CS0219 // La variable está asignada pero nunca se usa su valor
            int item = 0;

            foreach (SolicitudPedidoDetaEN solDeta in list)
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

        public SolicitudPedidoCabeEN ObtenerSolicitudPedidoCabeParaSegundaAdicion()
        {
            //objeto
            SolicitudPedidoCabeEN iMovCabEN = new SolicitudPedidoCabeEN();

            //pasamos los datos que queremos persistir para una segundo o mas adiciones
            iMovCabEN.FechaSolicitudPedidoCabe = this.dtpFecMovCab.Text;

            //devolver
            return iMovCabEN;
        }

        public void MostrarNuevoNumero()
        {
            //asignar parametros
            SolicitudPedidoCabeEN iMovCabEN = this.NuevoSolicitudPedidoCabeDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iMovCabEN);

            //mostrar en pantalla
            this.txtNumMovCab.Text = iNuevoNumero;
        }

        public void AdicionarSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iCuoEN);
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iCuoEN);
        }

        public void AdicionarSolicitudPedidosDeta()
        {
            //variables
            string iClaveSolicitudPedidoCabe = this.ObtenerClaveSolicitudPedidoCabe();
            string iCorrelativo = "0000";
            decimal iCostoFleteUnitario = this.ObtenerCostoFleteUnitario();

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in this.eLisMovDet)
            {
                //incrementar el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

                //actualizar algunos datos antes de grabar
                xMovDet.FechaSolicitudPedidoCabe = this.dtpFecMovCab.Text;
                //xMovDet.PrecioUnitarioSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerPrecioUnitarioConFlete(xMovDet, iCostoFleteUnitario);
                xMovDet.CostoFleteSolicitudPedidoDeta = iCostoFleteUnitario;
                //xMovDet.CostoSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerCosto(xMovDet);
                //xMovDet.PrecioExistencia = SolicitudPedidoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);
                xMovDet.CCodigoMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
                xMovDet.NumeroSolicitudPedidoCabe = this.txtNumMovCab.Text.Trim();
                xMovDet.ClaveSolicitudPedidoCabe = iClaveSolicitudPedidoCabe;
                xMovDet.CorrelativoSolicitudPedidoDeta = iCorrelativo;
                xMovDet.CostoFleteSolicitudPedidoCabe = Conversion.ADecimal(this.txtCosFle.Text.Trim(), 0);
                xMovDet.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(xMovDet);

                this.ModificacionSolicitudPedidoDetalleConCabecera(xMovDet);
            }

            //adicion masiva
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(this.eLisMovDet);
        }

        public void ModificacionSolicitudPedidoDetalleConCabecera(SolicitudPedidoDetaEN xMovDet)
        {
            xMovDet.FechaSolicitudPedidoCabe = this.dtpFecMovCab.Text;
            xMovDet.PeriodoSolicitudPedidoCabe = this.wFrm.lblPeriodo.Text;
            xMovDet.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            xMovDet.NumeroSolicitudPedidoCabe = this.txtNumMovCab.Text.Trim();
            xMovDet.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            xMovDet.FechaDocumento = this.dtpFecDoc.Text;
        }

        public decimal ObtenerCostoFleteUnitario()
        {
            //asignar parametros
            decimal iTotalKilos = ListaG.Sumar<SolicitudPedidoDetaEN>(this.eLisMovDet, SolicitudPedidoDetaEN.CanMovDet);
            decimal iCostoFleteTotal = Conversion.ADecimal(this.txtCosFle.Text, 0);

            //ejecutar metodo
            return Math.Round(Operador.DivisionDecimal(iCostoFleteTotal, iTotalKilos), 2);
        }

        public void AdicionarLotes()
        {
            //variables
            string iClaveSolicitudPedidoCabe = this.ObtenerClaveSolicitudPedidoCabe();

            //recorrer cada objeto
            foreach (LoteEN xLot in this.eLisLot)
            {
                //actualizar con la claveSolicitudPedidoCabe
                xLot.ClaveMovimientoCabe = iClaveSolicitudPedidoCabe;
            }

            //adicionar masivo
            LoteRN.AdicionarLote(this.eLisLot);
        }

        public void ActualizarExistenciasPorAdicion()
        {
            //asignar parametros
            List<SolicitudPedidoDetaEN> iLisMovDet = this.eLisMovDet;

            //ejecutar metodo
            //ExistenciaRN.ActualizarExistenciasPorAdicionSolicitudPedidosDeta(iLisMovDet);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsSolicitudPedidoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarSolicitudPedidoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar SolicitudPedidosDeta anterior
            this.EliminarAntiguosSolicitudPedidosDeta();

            //adicionando nuevos SolicitudPedidoDeta
            this.AdicionarSolicitudPedidosDeta();

            //actualizar existencias por adicion
            this.ActualizarExistenciasPorAdicion();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //adicionar lotes
            this.AdicionarLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la solicitud de pedido correctamente", this.wFrm.eTitulo);

            //actualizar al wLot          
            this.wFrm.eClaveDgvMovCab = this.ObtenerClaveSolicitudPedidoCabe();
            this.wFrm.ActualizarVentana();

            //imprimir la nota
            //this.wFrm.AccionImprimirNota();

            this.GenerarSolicitudPedido();

            //salir de la ventana
            this.Close();
        }

        public void ModificarSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iCuoEN);
            iCuoEN = SolicitudPedidoCabeRN.BuscarSolicitudPedidoCabeXClave(iCuoEN);
            this.AsignarSolicitudPedidoCabe(iCuoEN);
            SolicitudPedidoCabeRN.ModificarSolicitudPedidoCabe(iCuoEN);
        }

        public void EliminarAntiguosSolicitudPedidosDeta()
        {
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveSolicitudPedidoCabe = this.ObtenerClaveSolicitudPedidoCabe();
            SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iMovDetEN);
        }

        public void EliminarAntiguosLotes()
        {
            //asignar parametros
            string iClaveSolicitudPedidoCabe = this.ObtenerClaveSolicitudPedidoCabe();

            //ejecutar metodo
            LoteRN.EliminarLoteXClaveMovimientoCabe(iClaveSolicitudPedidoCabe);
        }

        public void ActualizarExistenciasPorEliminacion()
        {
            //asignar parametros
            List<SolicitudPedidoDetaEN> iLisMovDet = this.ListarSolicitudPedidosDeta();

            //ejecutar metodo
            //ExistenciaRN.ActualizarExistenciasPorEliminacionSolicitudPedidosDeta(iLisMovDet);
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDeta()
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveSolicitudPedidoCabe = this.ObtenerClaveSolicitudPedidoCabe();
            iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(iMovDetEN);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wFrm.EsSolicitudPedidoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wFrm.eTitulo) == false) { return; }

            if (this.wFrm.EsSolicitudPedidoCabeExistente().CCopiaSolicitudPedidoCabe != "1")
            {
                //retornar presupuesto
                this.RetornarPresupuesto();
            }

            //eliminar el registro
            this.EliminarSolicitudPedidoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar SolicitudPedidosDeta anterior
            this.EliminarAntiguosSolicitudPedidosDeta();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el ingreso correctamente", this.wFrm.eTitulo);

            //actualizar al wLot           
            this.wFrm.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iCuoEN);
            SolicitudPedidoCabeRN.EliminarSolicitudPedidoCabe(iCuoEN);
        }

        public void ListarTiposOperacion()
        {
            //si es de lectura , entonces no lista

            //instanciar
            wLisTipOpe win = new wLisTipOpe();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Operacion";
            win.eCtrlFoco = this.txtCodAlm;
            win.eTipOpeEN.CClaseTipoOperacion = "1";//ingresos
            win.eCondicionLista = Listas.wLisTipOpe.Condicion.TiposOperacionXClaseActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsTipoOperacionValido()
        {
            //si es de lectura , entonces no lista

            //validar el numerocontrato del lote
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionIngresoActivoValido(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, this.wFrm.eTitulo);

            }


            //devolver
            return iTipOpeEN.Adicionales.EsVerdad;
        }

        public void DeshabitarControles()
        {

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
            win.eCtrlFoco = this.txtCodPer;
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
            this.txtCodPer.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer.Text = iAlmEN.NombrePersonal;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarPersonales()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer.ReadOnly == true) { return; }

            //instanciar
            wLisPer win = new wLisPer();
            win.eVentana = this;
            win.eTituloVentana = "Personales";
            win.eCtrlValor = this.txtCodPer;
            win.eCtrlFoco = this.txtCosFle;
            win.eCondicionLista = Listas.wLisPer.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodPer.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            Entidades.PersonalEN iPerEN = new Entidades.PersonalEN();
            iPerEN.CodigoPersonal = this.txtCodPer.Text.Trim();
            iPerEN = PersonalRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPer.Text = iPerEN.CodigoPersonal;
            this.txtNomPer.Text = iPerEN.NombrePersonal;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarPersonalesAutorizan()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPerAut.ReadOnly == true) { return; }

            //instanciar
            wLisPerAut win = new wLisPerAut();
            win.eVentana = this;
            win.eTituloVentana = "Personal Autorizan";
            win.eCtrlValor = this.txtCodPerAut;
            win.eCtrlFoco = this.txtCodAux;
            win.eCondicionLista = Listas.wLisPerAut.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalAutorizanValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodPerAut.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();
            iPerEN.CodigoPersonalAutoriza = this.txtCodPerAut.Text.Trim();
            iPerEN = PersonalAutorizanRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPerAut.Text = iPerEN.CodigoPersonalAutoriza;
            this.txtNomPerAut.Text = iPerEN.NombrePersonalAutoriza;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarPersonalesReciben()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer.ReadOnly == true) { return; }

            //instanciar
            wLisPerRec win = new wLisPerRec();
            win.eVentana = this;
            win.eTituloVentana = "Personal Reciben";
            win.eCtrlFoco = this.txtCodAux;
            win.eCondicionLista = Listas.wLisPerRec.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalRecibenValido()
        {
            //si es de lectura , entonces no lista

            //validar el numerocontrato del lote
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            iPerEN = PersonalRecibenRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarProveedores()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            wLisAux win = new wLisAux();
            win.eVentana = this;
            win.eTituloVentana = "Proveedores";
            win.eCtrlValor = this.txtCodAux;
            win.eCtrlFoco = this.dtpFecDoc;
            win.eCondicionLista = Listas.wLisAux.Condicion.ProveedoresActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsProveedorValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAux.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iAuxEN = AuxiliarRN.EsProveedorActivoValido(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.txtCodAux.Focus();
            }

            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void ListarTiposDocumento()
        {
            //si es de lectura , entonces no lista

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Documento";
            win.eIteEN.CodigoTabla = "TipCom";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }


        public SolicitudPedidoCabeEN NuevoSolicitudPedidoCabeDeVentana()
        {
            SolicitudPedidoCabeEN iMovCabEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iMovCabEN);
            return iMovCabEN;
        }

        public string ObtenerClaveSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iMovCabEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iMovCabEN);
            return iMovCabEN.ClaveSolicitudPedidoCabe;
        }

        public void AccionAgregarItem()
        {
            //valida cuando no hay tipo operacion
            if (this.ElegirTipoOperacionAntesDeLlenarGrilla() == false) { return; }

            //valida cuando no hay almacen
            if (this.ElegirAlmacenAntesDeLlenarGrilla() == false) { return; }

            //instanciar
            wDetalleSolicitudPedido win = new wDetalleSolicitudPedido();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleSolicitudPedido win = new wDetalleSolicitudPedido();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            wDetalleSolicitudPedido win = new wDetalleSolicitudPedido();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public bool ElegirTipoOperacionAntesDeLlenarGrilla()
        {
            return true;
        }

        public bool ElegirAlmacenAntesDeLlenarGrilla()
        {
            if (this.txtCodAlm.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un almacen", "Almacen");
                this.txtCodAlm.Focus();
                return false;
            }
            return true;
        }

        public bool ValidaFechaSolicitudPedidoCabe()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            SolicitudPedidoCabeEN iMovCabEN = this.NuevoSolicitudPedidoCabeDeVentana();

            //validar
            iMovCabEN = SolicitudPedidoCabeRN.ValidaCuandoFechaNoEsDelPeriodoElegido(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.wFrm.eTitulo);
                this.dtpFecMovCab.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public void CambiarSoloLecturaACodigoAlmacen()
        {
            //valida cuando no es adicionar
            if (this.eOperacion != Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtCodAlm, iValor);
        }

        public void CambiarSoloLecturaACodigoTipoOperacion()
        {
            //valida cuando no es adicionar
            if (this.eOperacion != Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
        }

        public void MostrarFechaIngresoSugerida()
        {
            //asignar parametros
            string iPeriodoRegistro = this.wFrm.lblPeriodo.Text;
            string iFechaSolicitudPedidoCabeDtp = Fecha.ObtenerDiaMesAno(this.dtpFecMovCab.Value);
            string iFechaDocumentoDtp = Fecha.ObtenerDiaMesAno(this.dtpFecDoc.Value);

            //ejecutar metodo
            this.dtpFecMovCab.Text = SolicitudPedidoCabeRN.ObtenerFechaSolicitudPedidoCabeSugerido(iPeriodoRegistro, iFechaSolicitudPedidoCabeDtp);
            this.dtpFecDoc.Text = SolicitudPedidoCabeRN.ObtenerFechaSolicitudPedidoCabeSugerido(iPeriodoRegistro, iFechaDocumentoDtp);
        }

        public void Cancelar()
        {
            this.eOperacion = Universal.Opera.Cancelar;
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wFrm.eTitulo);
        }

        public void CerrarYDevolverPresupuesto()
        {
            List<SolicitudPedidoDetaEN> eListMovDeta = new List<SolicitudPedidoDetaEN>();
            List<SolicitudPedidoDetaEN> eListMovDetTmp = new List<SolicitudPedidoDetaEN>();

            eListMovDeta = this.eLisMovDet;

            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iCuoEN);
            this.LLenarSolicitudPedidoDetaDeBaseDatos(iCuoEN);

            foreach (SolicitudPedidoDetaEN obj in eListMovDeta)
            {
                if (eListMovDeta.Count() != eLisMovDet.Count())
                {
                    if (eLisMovDet.Count() == 0 && this.eOperacion == Universal.Opera.Cancelar)
                    {
                        eListMovDetTmp.Add(obj);
                    }
                    else
                    {
                        eLisMovDet.ForEach(x =>
                        {
                            if (x.ClaveObjeto != obj.ClaveObjeto)
                            {
                                eListMovDetTmp.Add(obj);
                            }
                        });
                    }
                }
            }

            PresupuestoEN iPerEN = new PresupuestoEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
            this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);

            PresupuestoEN xObj = new PresupuestoEN();
            foreach (SolicitudPedidoDetaEN objDeta in eListMovDetTmp)
            {
                string presupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wFrm.lblPeriodo.Text
                                        && x.CCentroCosto == objDeta.CodigoCentroCosto).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                                        Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wFrm.lblPeriodo.Text
                                        && x.CCentroCosto == objDeta.CodigoCentroCosto).FirstOrDefault().SaldoPresupuestoTemporal.ToString(), 2);

                xObj = new PresupuestoEN();
                xObj = this.eLisPre.Where(x => x.CodigoPresupuesto == wFrm.lblPeriodo.Text
                            && x.CCentroCosto == objDeta.CodigoCentroCosto).FirstOrDefault();
                if (eLisMovDet.Count() == 0 && this.eOperacion == Universal.Opera.Cancelar)
                {
                    xObj.SaldoPresupuestoTemporal = Convert.ToDecimal(presupuesto) + (objDeta.PrecioUltimaCompra * objDeta.CantidadSolicitudPedidoDeta);
                }
                else
                {
                    xObj.SaldoPresupuestoTemporal = Convert.ToDecimal(presupuesto) - (objDeta.PrecioUltimaCompra * objDeta.CantidadSolicitudPedidoDeta);
                }
                PresupuestoRN.ModificarPresupuesto(xObj);
            }

        }

        public void RetornarPresupuesto()
        {
            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iCuoEN);
            this.LLenarSolicitudPedidoDetaDeBaseDatos(iCuoEN);

            if (this.eLisMovDet.Count > 0)
            {
                PresupuestoEN iPerEN = new PresupuestoEN();
                iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvPer;
                PresupuestoEN xObj = new PresupuestoEN();
                foreach (SolicitudPedidoDetaEN objDeta in this.eLisMovDet)
                {
                    this.eLisPre = PresupuestoRN.ListarPresupuestos(iPerEN);
                    string presupuesto = this.eLisPre.Where(x => x.CodigoPresupuesto == wFrm.lblPeriodo.Text
                && x.CCentroCosto == objDeta.CodigoCentroCosto).Count() == 0 ? Formato.NumeroDecimal(0, 2) :
                Formato.NumeroDecimal(this.eLisPre.Where(x => x.CodigoPresupuesto == wFrm.lblPeriodo.Text && x.CCentroCosto == objDeta.CodigoCentroCosto).FirstOrDefault().SaldoPresupuestoTemporal.ToString(), 2);

                    xObj = new PresupuestoEN();
                    xObj.CodigoPresupuesto = wFrm.lblPeriodo.Text;
                    xObj.CCentroCosto = objDeta.CodigoCentroCosto;
                    xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(presupuesto) + (objDeta.PrecioUltimaCompra * objDeta.CantidadSolicitudPedidoDeta);
                    PresupuestoRN.ModificarPresupuestoTemporal(xObj);
                }
            }
        }
        public void CargarTipoCambio()
        {
            TipoCambioEN objTipCam = new TipoCambioEN();
            objTipCam.Adicionales.CampoOrden = eNombreColumnaDgvTipOpe;
            eLisTipCam = TipoCambioRN.ListarTipoCambio(objTipCam);

            string fechaTipoCambio = Fecha.ObtenerDiaMesAno(Conversion.ADateTime(dtpFecMovCab.Text));

            if (eLisTipCam.Where(e => e.FechaTipoCambio == fechaTipoCambio).Count() == 0)
            {
                Mensaje.OperacionDenegada("Se debe ingresar un tipo de cambio para la fecha del documento.", this.wFrm.eTitulo);
                txtTipCam.Text = Formato.NumeroDecimal(0, 4);
            }
            else
                txtTipCam.Text = eLisTipCam.FirstOrDefault(e => e.FechaTipoCambio == fechaTipoCambio).VentaTipoCambio.ToString();

        }
        #endregion


        private void wEditSolicitudPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CerrarYDevolverPresupuesto();
            this.wFrm.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCodTipOpe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposOperacion(); }
        }

        private void txtCodTipOpe_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposOperacion();
        }

        private void txtCodTipOpe_Validating(object sender, CancelEventArgs e)
        {
            this.EsTipoOperacionValido();
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

        private void txtCodPer_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalValido();
        }

        private void txtCodPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonales(); }
        }

        private void txtCodPer_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonales();
        }

        private void txtCodAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsProveedorValido();
        }

        private void txtCodAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarProveedores(); }
        }

        private void txtCodAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarProveedores();
        }

        private void txtCTipDoc_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtCTipDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarTiposDocumento(); }
        }

        private void txtCTipDoc_DoubleClick(object sender, EventArgs e)
        {
            this.ListarTiposDocumento();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarItem();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificarItem();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

        private void dtpFecMovCab_Validated(object sender, EventArgs e)
        {
            this.ValidaFechaSolicitudPedidoCabe();
        }

        private void cmbMon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtCodMonSyD.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            if (this.txtCodMonSyD.Text == "1")
            {
                this.txtTipCam.ReadOnly = false;
                this.txtTipCam.Text = wTipoCambio;
                this.txtTipCam.Text = "0.0000";
                //this.txtTipCam.Focus();
            }
            else
            {
                this.txtTipCam.ReadOnly = true;
                this.txtTipCam.Text = "0.0000";
                //this.txtCodAux.Focus();
            }
            this.CargarTipoCambio();
        }

        private void txtCodPerAut_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonalesAutorizan();
        }

        private void txtCodPerAut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonalesAutorizan(); }
        }

        private void txtCodPerAut_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalAutorizanValido();
        }

        private void txtCodTipOpe_Validated(object sender, EventArgs e)
        {
            this.DeshabitarControles();
        }

        private void txtCodPerRec_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonalesReciben();
        }

        private void txtCodPerRec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonalesReciben(); }
        }

        private void txtCodPerRec_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalRecibenValido();
        }
    }
}
