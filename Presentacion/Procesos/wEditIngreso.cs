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

namespace Presentacion.Procesos
{
    public partial class wEditIngreso : Heredados.MiForm8
    {
        public wEditIngreso()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        public string wTipoCambio, wano, wmes, wperiodo, wOrigenVentana;
        Masivo eMas = new Masivo();
        public List<MovimientoDetaEN> eLisMovDet = new List<MovimientoDetaEN>();
        public List<LoteEN> eLisLot = new List<LoteEN>();
        public string eClaveDgvMovDet = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;

        #endregion

        #region Propietario

        public wIngresos wIng;
        public wIngresosOrdenCompra wIngOC;

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
            xCtrl.TxtTodo(this.txtCodTipOpe, true, "Tipo Operacion", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipOpe, this.txtCodTipOpe, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer, true, "Personal", "vvff", 6);
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
            xCtrl.TxtTodo(this.txtCodPerRec, true, "Persona Recibe", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPerRec, this.txtCodPerRec, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCosFle, false, "Flete", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMon, "vvff");
            xLis.Add(xCtrl);



            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, false, "Proveedor", "vvff", 11);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtOrdCom, false, "O / C", "vvff", 50);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtTipCam, false, "Tipo Cambio", "vvff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCTipDoc, false, "T.D", "vvff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNTipDoc, this.txtCTipDoc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtSerDoc, false, "Serie", "vvff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumDoc, false, "N.D", "vvff", 15);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecDoc, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo);

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            //Cargas Monedas
            this.CargarMonedas();

            //valores x defecto
            this.ValoresXDefecto();

            // Deshabilitar al propietario de esta ventana
            if (this.wOrigenVentana == "7") { this.wIngOC.Enabled = false; } else { this.wIng.Enabled = false; }

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto()
        {
            txtPerMovCab.Text = (this.wOrigenVentana == "7" ? this.wIngOC.lblDescripcionPeriodo.Text : this.wIng.lblDescripcionPeriodo.Text);
        }

        public void VentanaAdicionar()
        {
            //             
            txtPerMovCab.Text = (this.wOrigenVentana == "7" ? this.wIngOC.lblDescripcionPeriodo.Text : this.wIng.lblDescripcionPeriodo.Text);
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
            this.MostrarMovimientoCabe(MovimientoCabeRN.EnBlanco());
            this.MostrarFechaIngresoSugerida();
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            //this.txtTipCam.Text = wTipoCambio;
            this.dtpFecMovCab.Focus();
        }

        public void VentanaModificar(MovimientoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void VentanaEliminar(MovimientoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(MovimientoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.LLenarLotesDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
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

        public void AsignarMovimientoCabe(MovimientoCabeEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCab.PeriodoMovimientoCabe = (this.wOrigenVentana == "7" ? this.wIngOC.lblPeriodo.Text : this.wIng.lblPeriodo.Text);
            pMovCab.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();
            pMovCab.FechaMovimientoCabe = dtpFecMovCab.Text;
            pMovCab.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            pMovCab.DescripcionTipoOperacion = this.txtDesTipOpe.Text.Trim();
            pMovCab.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pMovCab.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            pMovCab.CodigoPersonal = this.txtCodPer.Text.Trim();
            pMovCab.CodigoPersonalAutoriza = this.txtCodPerAut.Text.Trim();
            pMovCab.CodigoPersonalRecibe = this.txtCodPerRec.Text.Trim();
            pMovCab.CostoFleteMovimientoCabe = Conversion.ADecimal(this.txtCosFle.Text, 0);
            pMovCab.CCodigoMoneda = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            pMovCab.TipoCambio = Conversion.ADecimal(this.txtTipCam.Text, 0);
            pMovCab.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pMovCab.DescripcionAuxiliar = this.txtDesAux.Text.Trim();
            pMovCab.OrdenCompra = this.txtOrdCom.Text.Trim();
            pMovCab.CTipoDocumento = this.txtCTipDoc.Text.Trim();
            pMovCab.SerieDocumento = this.txtSerDoc.Text.Trim();
            pMovCab.NumeroDocumento = this.txtNumDoc.Text.Trim();
            pMovCab.FechaDocumento = dtpFecDoc.Text;
            pMovCab.GlosaMovimientoCabe = this.txtGloMovCab.Text;
            pMovCab.COrigenVentanaCreacion = "1";//ingreso          
            pMovCab.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }

        public void MostrarMovimientoCabe(MovimientoCabeEN pMovCab)
        {
            this.txtNumMovCab.Text = pMovCab.NumeroMovimientoCabe;
            this.dtpFecMovCab.Text = pMovCab.FechaMovimientoCabe;
            this.txtCodTipOpe.Text = pMovCab.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = pMovCab.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = pMovCab.CCalculaPrecioPromedio;
            this.txtCConUni.Text = pMovCab.CConversionUnidad;
            this.txtCodAlm.Text = pMovCab.CodigoAlmacen;
            this.txtDesAlm.Text = pMovCab.DescripcionAlmacen;
            this.txtCodPer.Text = pMovCab.CodigoPersonal;
            this.txtNomPer.Text = pMovCab.NombrePersonal;
            this.txtCodPerAut.Text = pMovCab.CodigoPersonalAutoriza;
            this.txtNomPerAut.Text = pMovCab.NombrePersonalAutoriza;
            this.txtCodPerRec.Text = pMovCab.CodigoPersonalRecibe;
            this.txtNomPerRec.Text = pMovCab.NombrePersonalRecibe;
            this.txtCosFle.Text = Formato.NumeroDecimal(pMovCab.CostoFleteMovimientoCabe, 2);
            Cmb.SeleccionarValorItem(this.cmbMon, pMovCab.CCodigoMoneda);
            this.txtCodMonSyD.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            this.txtTipCam.Text = Formato.NumeroDecimal(pMovCab.TipoCambio, 4);
            this.txtCodAux.Text = pMovCab.CodigoAuxiliar;
            this.txtDesAux.Text = pMovCab.DescripcionAuxiliar;
            this.txtOrdCom.Text = pMovCab.OrdenCompra;
            this.txtCTipDoc.Text = pMovCab.CTipoDocumento;
            this.txtNTipDoc.Text = pMovCab.NTipoDocumento;
            this.txtSerDoc.Text = pMovCab.SerieDocumento;
            this.txtNumDoc.Text = pMovCab.NumeroDocumento;
            this.dtpFecDoc.Text = pMovCab.FechaDocumento;
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;
        }

        public void MostrarMovimientosDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<MovimientoDetaEN> iFuenteDatos = MovimientoDetaRN.RefrescarListaMovimientoDeta(this.eLisMovDet); ;
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CorMovDet, "Linea", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.DesExi, "Descripcion", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.NCodAre, "Area", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.NCodPar, "Partida", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CanMovDet, "Cant", 60, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.PreUniMovDet, "P/U", 85, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CosMovDet, "Costo", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CosFleMovDet, "Flete", 70, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.NCodMon, "Moneda", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarMovimientoDetaDeBaseDatos(MovimientoCabeEN pObj)
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;
            this.eLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void LLenarLotesDeBaseDatos(MovimientoCabeEN pObj)
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            iLotEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
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
            if ((this.wOrigenVentana == "7" ? this.wIngOC.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad : this.wIng.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion((this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo)) == false) { return; }

            //mostrar numero movimientoCabe
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarMovimientoCabe();

            //adicionando detalles
            this.AdicionarMovimientosDeta();

            //adicionando lotes
            this.AdicionarLotes();

            //actualizar las existencias referenciadas
            this.ActualizarExistenciasPorAdicion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego el ingreso correctamente", (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));

            //actualizar al propietario  
            if (this.wOrigenVentana == "7")
            {
                this.wIngOC.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
                this.wIngOC.ActualizarVentana();
                //this.wIngOC.AccionImprimirNota();
            }
            else
            {
                this.wIng.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
                this.wIng.ActualizarVentana();
                this.wIng.AccionImprimirNota();
            }



            //imprimir la nota


            //limpiar controles
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeParaSegundaAdicion());
            this.eLisMovDet.Clear();
            this.MostrarMovimientosDeta();
            this.eLisLot.Clear();
            this.CambiarSoloLecturaACodigoTipoOperacion();
            this.CambiarSoloLecturaACodigoAlmacen();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public MovimientoCabeEN ObtenerMovimientoCabeParaSegundaAdicion()
        {
            //objeto
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //pasamos los datos que queremos persistir para una segundo o mas adiciones
            iMovCabEN.FechaMovimientoCabe = this.dtpFecMovCab.Text;

            //devolver
            return iMovCabEN;
        }

        public void MostrarNuevoNumero()
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);

            //mostrar en pantalla
            this.txtNumMovCab.Text = iNuevoNumero;
        }

        public void AdicionarMovimientoCabe()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            MovimientoCabeRN.AdicionarMovimientoCabe(iCuoEN);
        }

        public void AdicionarMovimientosDeta()
        {
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            string iCorrelativo = "0000";
            decimal iCostoFleteUnitario = this.ObtenerCostoFleteUnitario();

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in this.eLisMovDet)
            {
                //incrementar el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

                //actualizar algunos datos antes de grabar
                xMovDet.FechaMovimientoCabe = this.dtpFecMovCab.Text;
                xMovDet.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioConFlete(xMovDet, iCostoFleteUnitario);
                xMovDet.CostoFleteMovimientoDeta = iCostoFleteUnitario;
                xMovDet.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(xMovDet);
                xMovDet.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);
                xMovDet.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();
                xMovDet.ClaveMovimientoCabe = iClaveMovimientoCabe;
                xMovDet.CorrelativoMovimientoDeta = iCorrelativo;
                xMovDet.CostoFleteMovimientoCabe = Conversion.ADecimal(this.txtCosFle.Text.Trim(), 0);
                xMovDet.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(xMovDet);
                xMovDet.CCodigoMoneda = this.txtCodMonSyD.Text.ToString().Trim();
            }

            //adicion masiva
            MovimientoDetaRN.AdicionarMovimientoDeta(this.eLisMovDet);
        }

        public decimal ObtenerCostoFleteUnitario()
        {
            //asignar parametros
            decimal iTotalKilos = ListaG.Sumar<MovimientoDetaEN>(this.eLisMovDet, MovimientoDetaEN.CanMovDet);
            decimal iCostoFleteTotal = Conversion.ADecimal(this.txtCosFle.Text, 0);

            //ejecutar metodo
            return Math.Round(Operador.DivisionDecimal(iCostoFleteTotal, iTotalKilos), 2);
        }

        public void AdicionarLotes()
        {
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();

            //recorrer cada objeto
            foreach (LoteEN xLot in this.eLisLot)
            {
                //actualizar con la claveMovimientoCabe
                xLot.ClaveMovimientoCabe = iClaveMovimientoCabe;
            }

            //adicionar masivo
            LoteRN.AdicionarLote(this.eLisLot);
        }

        public void ActualizarExistenciasPorAdicion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.eLisMovDet;

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if ((this.wOrigenVentana == "7" ? this.wIngOC.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad : this.wIng.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion((this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo)) == false) { return; }

            //modificar el registro    
            this.ModificarMovimientoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //adicionando nuevos MovimientoDeta
            this.AdicionarMovimientosDeta();

            //actualizar existencias por adicion
            this.ActualizarExistenciasPorAdicion();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //adicionar lotes
            this.AdicionarLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico el ingreso correctamente", (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));

            if (this.wOrigenVentana == "7")
            {
                this.wIngOC.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
                this.wIngOC.ActualizarVentana();
                //this.wIngOC.AccionImprimirNota();
            }
            else
            {
                //actualizar al wLot          
                this.wIng.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
                this.wIng.ActualizarVentana();

                //imprimir la nota
                this.wIng.AccionImprimirNota();
            }




            //salir de la ventana
            this.Close();
        }

        public void ModificarMovimientoCabe()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            iCuoEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(iCuoEN);
            this.AsignarMovimientoCabe(iCuoEN);
            MovimientoCabeRN.ModificarMovimientoCabe(iCuoEN);
        }

        public void EliminarAntiguosMovimientosDeta()
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public void EliminarAntiguosLotes()
        {
            //asignar parametros
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();

            //ejecutar metodo
            LoteRN.EliminarLoteXClaveMovimientoCabe(iClaveMovimientoCabe);
        }

        public void ActualizarExistenciasPorEliminacion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDeta();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDeta(iLisMovDet);
        }

        public List<MovimientoDetaEN> ListarMovimientosDeta()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if ((this.wOrigenVentana == "7" ? this.wIngOC.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad : this.wIng.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion((this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo)) == false) { return; }

            //eliminar el registro
            this.EliminarMovimientoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el ingreso correctamente", (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));

            if (this.wOrigenVentana == "7")
            {
                //actualizar al wLot           
                this.wIngOC.ActualizarVentana();
            }
            else
            {
                this.wIng.ActualizarVentana();
            }
            //salir de la ventana
            this.Close();

        }

        public void EliminarMovimientoCabe()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            MovimientoCabeRN.EliminarMovimientoCabe(iCuoEN);
        }

        public void ListarTiposOperacion()
        {
            //si es de lectura , entonces no lista
            if (txtCodTipOpe.ReadOnly == true) { return; }

            //instanciar
            wLisTipOpe win = new wLisTipOpe();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Operacion";
            win.eCtrlValor = this.txtCodTipOpe;
            win.eCtrlFoco = this.txtCodAlm;
            win.eTipOpeEN.CClaseTipoOperacion = "1";//ingresos
            win.eCondicionLista = Listas.wLisTipOpe.Condicion.TiposOperacionXClaseActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsTipoOperacionValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodTipOpe.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            iTipOpeEN.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionIngresoActivoValido(iTipOpeEN);
            if (iTipOpeEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iTipOpeEN.Adicionales.Mensaje, (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));
                this.txtCodTipOpe.Focus();
            }

            //mostrar datos
            this.txtCodTipOpe.Text = iTipOpeEN.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = iTipOpeEN.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = iTipOpeEN.CCalculaPrecioPromedio;
            this.txtCConUni.Text = iTipOpeEN.CConversionUnidad;

            //devolver
            return iTipOpeEN.Adicionales.EsVerdad;
        }

        public void DeshabitarControles()
        {
            if (this.txtCodTipOpe.Text == "02") //Compras
            {
                this.cmbMon.Enabled = true;
            }
            else
            {
                this.cmbMon.Enabled = false;
            }

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
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));
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
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));
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
            win.eCtrlFoco = this.txtCodPerRec;
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
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));
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
            win.eCtrlValor = this.txtCodPerRec;
            win.eCtrlFoco = this.txtCodAux;
            win.eCondicionLista = Listas.wLisPerRec.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalRecibenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodPerRec.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            iPerEN.CodigoPersonalRecibe = this.txtCodPerRec.Text.Trim();
            iPerEN = PersonalRecibenRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPerRec.Text = iPerEN.CodigoPersonalRecibe;
            this.txtNomPerRec.Text = iPerEN.NombrePersonalRecibe;

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
            win.eCtrlFoco = this.txtOrdCom;
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
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));
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
            if (this.txtCTipDoc.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Tipos Documento";
            win.eCtrlValor = this.txtCTipDoc;
            win.eCtrlFoco = this.txtSerDoc;
            win.eIteEN.CodigoTabla = "TipCom";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsTipoDocumentoValido()
        {
            return Generico.EsCodigoItemGValido("TipCom", this.txtCTipDoc, this.txtNTipDoc, "Tipo documento");
        }

        public MovimientoCabeEN NuevoMovimientoCabeDeVentana()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN;
        }

        public string ObtenerClaveMovimientoCabe()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public void AccionAgregarItem()
        {
            //valida cuando no hay tipo operacion
            if (this.ElegirTipoOperacionAntesDeLlenarGrilla() == false) { return; }

            //valida cuando no hay almacen
            if (this.ElegirAlmacenAntesDeLlenarGrilla() == false) { return; }

            //instanciar
            wDetalleIngreso win = new wDetalleIngreso();
            win.wEditIng = this;
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

            wDetalleIngreso win = new wDetalleIngreso();
            win.wEditIng = this;
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

            wDetalleIngreso win = new wDetalleIngreso();
            win.wEditIng = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public bool ElegirTipoOperacionAntesDeLlenarGrilla()
        {
            if (this.txtCodTipOpe.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un tipo de operacion", "Tipo operacion");
                this.txtCodTipOpe.Focus();
                return false;
            }
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

        public bool ValidaFechaMovimientoCabe()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //validar
            iMovCabEN = MovimientoCabeRN.ValidaCuandoFechaNoEsDelPeriodoElegido(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));
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
            Txt.SoloEscritura1(this.txtCodTipOpe, iValor);
        }

        public void MostrarFechaIngresoSugerida()
        {
            //asignar parametros
            string iPeriodoRegistro = (this.wOrigenVentana == "7" ? this.wIngOC.lblPeriodo.Text : this.wIng.lblPeriodo.Text);
            string iFechaMovimientoCabeDtp = Fecha.ObtenerDiaMesAno(this.dtpFecMovCab.Value);
            string iFechaDocumentoDtp = Fecha.ObtenerDiaMesAno(this.dtpFecDoc.Value);

            //ejecutar metodo
            this.dtpFecMovCab.Text = MovimientoCabeRN.ObtenerFechaMovimientoCabeSugerido(iPeriodoRegistro, iFechaMovimientoCabeDtp);
            this.dtpFecDoc.Text = MovimientoCabeRN.ObtenerFechaMovimientoCabeSugerido(iPeriodoRegistro, iFechaDocumentoDtp);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, (this.wOrigenVentana == "7" ? this.wIngOC.eTitulo : this.wIng.eTitulo));
        }


        #endregion


        private void wEditIngresos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.wOrigenVentana == "7") { this.wIngOC.Enabled = true; } else { this.wIng.Enabled = true; }
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
            this.EsTipoDocumentoValido();
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
            this.ValidaFechaMovimientoCabe();
        }

        private void cmbMon_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtCodMonSyD.Text = Cmb.ObtenerValor(this.cmbMon, string.Empty);
            if (this.txtCodMonSyD.Text == "1")
            {
                this.txtTipCam.ReadOnly = false;
                this.txtTipCam.Text = wTipoCambio;
                //this.txtTipCam.Focus();
            }
            else
            {
                this.txtTipCam.ReadOnly = true;
                this.txtTipCam.Text = "0.00";
                //this.txtCodAux.Focus();
            }
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
