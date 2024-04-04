using Comun;
using Entidades;
using Entidades.Adicionales;
using Heredados;
using Negocio;
using Presentacion.FuncionesGenericas;
using Presentacion.Listas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace Presentacion.ProcesosCompras
{
    public partial class wGenerarOrdenCompraPorItemDeRequerimiento : MiForm8
    {
        public enum Condicion
        {
            Generar = 0
        }
        public wRequerimiento wFrm;
        public Form eVentana = new Form();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        List<SolicitudPedidoCabeEN> listSolPed = new List<SolicitudPedidoCabeEN>();
        public List<SolicitudPedidoDetaEN> eLisMovDet = new List<SolicitudPedidoDetaEN>();
        public List<LoteEN> eLisLot = new List<LoteEN>();
        public string eClaveDgvMovDet = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string iNuevoNumero = string.Empty;
        string iCorrelativo = "0000";
        public List<SolicitudPedidoDetaEN> eLisSolDetParcial = new List<SolicitudPedidoDetaEN>();
        public string ClaveSolicitudPedidoCabe = string.Empty;
        public wGenerarOrdenCompraPorItemDeRequerimiento()
        {
            InitializeComponent();
        }
        public void NuevaVentana(List<SolicitudPedidoCabeEN> pMovCab)
        {
            this.listSolPed = pMovCab;
            this.InicializaVentana();
            this.Show();
            this.txtCodAux.Focus();
        }
        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            this.MostrarDetalleRequerimientoDeBD();
            //this.LLenarLotesDeBaseDatos();
            this.MostrarSolicitudPedidosDeta();
        }
        public void MostrarDetalleRequerimientoDeBD()
        {
            foreach (SolicitudPedidoCabeEN item in this.listSolPed)
            {
                if (item.CEstadoSolicitudPedidoCabe == "2" && item.VerdadFalso)
                {
                    SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
                    iMovDetEN.ClaveSolicitudPedidoCabe = item.ClaveSolicitudPedidoCabe;
                    iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;
                    this.eLisMovDet.AddRange(SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(iMovDetEN).Where(x => x.FlagCheckItem == false).ToList());
                }
            }
        }
        public void MostrarSolicitudPedidosDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<SolicitudPedidoDetaEN> iFuenteDatos = SolicitudPedidoDetaRN.RefrescarListaSolicitudPedidoDeta(this.eLisMovDet);
            Dgv.Franja iCondicionFranja = eFranjaDgvMovDet;
            string iClaveBusqueda = eClaveDgvMovDet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }
        public void ListarProveedores()
        {
            //si es de lectura , entonces no lista
            //if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            wLisAux win = new wLisAux();
            win.eVentana = this;
            win.eTituloVentana = "Proveedores";
            win.eCtrlValor = this.txtCodAux;
            win.eCtrlFoco = this.dtpFecDoc;
            win.eCondicionLista = wLisAux.Condicion.ProveedoresActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }
        public void LLenarLotesDeBaseDatos()
        {
            foreach (SolicitudPedidoCabeEN item in this.listSolPed)
            {
                if (item.CEstadoSolicitudPedidoCabe == "2")
                {
                    //asignar parametros
                    LoteEN iLotEN = new LoteEN();
                    iLotEN.ClaveMovimientoCabe = item.ClaveSolicitudPedidoCabe;
                    iLotEN.Adicionales.CampoOrden = LoteEN.CodExi + "," + LoteEN.CodLot;

                    //ejecutar metodo
                    this.eLisLot.AddRange(LoteRN.ListarLotesDeClaveMovimientoCabe(iLotEN));
                }
            }
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaCheckBox(SolicitudPedidoDetaEN.FlgChkIt, "OC", 50));
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
        public void Cancelar()
        {
            this.eOperacion = Universal.Opera.Cancelar;
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wFrm.eTitulo);
        }

        public void GenerarOrdenCompra()
        {
            if (this.EsValidoEnvio() == false) { return; }

            if (this.txtCodAux.Text == string.Empty) { Mensaje.OperacionDenegada("Debe seleccionar un proveedor.", this.wFrm.eTitulo); return; }

            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();

            foreach (SolicitudPedidoCabeEN item in this.listSolPed)
            {
                if (item.CEstadoSolicitudPedidoCabe == "2" && item.VerdadFalso)
                {
                    //preguntar si el registro seleccionado existe
                    iIngEN = this.EsActoGenerarOrdenCompra(item);

                    if (iIngEN.Adicionales.EsVerdad == false) { return; }

                    if (iIngEN.CEstadoSolicitudPedidoCabe == "5")
                    {
                        Mensaje.OperacionDenegada("La solicitud ha sido desaprobada, no se puede eliminar.", this.wFrm.eTitulo);
                        return;
                    }
                    this.ClaveSolicitudPedidoCabe = this.ClaveSolicitudPedidoCabe + iIngEN.ClaveSolicitudPedidoCabe + "|";
                    //
                    this.MostrarNuevoNumero(iIngEN);

                }

            }

            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iCuoEN);
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iCuoEN);

            foreach (SolicitudPedidoDetaEN deta in this.eLisMovDet)
            {
                if (deta.VerdadFalso)
                {
                    if (this.eLisSolDetParcial.Count == 0)
                    { this.eLisSolDetParcial.Add(deta); }
                    else
                    {
                        if (this.eLisSolDetParcial.Exists(x => x.CodigoExistencia == deta.CodigoExistencia))
                        {
                            deta.CantidadSolicitudPedidoDeta += this.eLisSolDetParcial.Find(x => x.CodigoExistencia == deta.CodigoExistencia).CantidadSolicitudPedidoDeta;
                            this.eLisSolDetParcial.RemoveAll(x => x.CodigoExistencia == deta.CodigoExistencia);
                            this.eLisSolDetParcial.Add(deta);
                        }
                        else
                        {
                            this.eLisSolDetParcial.Add(deta);
                        }
                    }
                    SolicitudPedidoDetaRN.ActualizarFlagCheckItem(deta);
                }
            }

            iCorrelativo = "0000";
            foreach (SolicitudPedidoDetaEN objSD in this.eLisSolDetParcial)
            {
                this.AdicionarMovimientosDeta(iIngEN, objSD);
            }

            this.ValidaDetalleParaGenerarOC();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se genero la orden de compra correctamente", this.wFrm.eTitulo);
            this.Close();
            this.wFrm.ActualizarVentana();
        }
        public void ValidaDetalleParaGenerarOC()
        {
            foreach (SolicitudPedidoCabeEN item in this.listSolPed)
            {
                if (item.CEstadoSolicitudPedidoCabe == "2" && item.VerdadFalso)
                {
                    SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
                    iMovDetEN.ClaveSolicitudPedidoCabe = item.ClaveSolicitudPedidoCabe;
                    iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;
                    List<SolicitudPedidoDetaEN> lMovDetEN = new List<SolicitudPedidoDetaEN>();
                    lMovDetEN = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(iMovDetEN).Where(x => x.FlagCheckItem == false).ToList();
                    if (lMovDetEN.Count == 0)
                        SolicitudPedidoCabeRN.EnviadoSolicitudPedidoCabe(item);
                }
            }
        }
        public SolicitudPedidoCabeEN EsActoGenerarOrdenCompra(SolicitudPedidoCabeEN obj)
        {
            //obj = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(obj);
            obj = SolicitudPedidoCabeRN.EsActoGenerarOrdenCompra(obj);
            if (obj.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(obj.Adicionales.Mensaje, this.wFrm.eTitulo);
            }
            return obj;
        }
        public void AsignarSolicitudPedidoCabe(SolicitudPedidoCabeEN pIng)
        {
            pIng.ClaveSolicitudPedidoCabe = pIng.ClaveSolicitudPedidoCabe;
            pIng.PeriodoSolicitudPedidoCabe = this.wFrm.lblPeriodo.Text;
            pIng.COrigenVentanaCreacion = "1";//ingreso      
        }
        public void MostrarNuevoNumero(SolicitudPedidoCabeEN iIngEN)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana(iIngEN);

            //obtener el nuevo numero
            iNuevoNumero = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
        }

        public void AsignarMovimientoCabe(SolicitudPedidoCabeEN iIngEN, MovimientoOCCabeEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCab.PeriodoMovimientoCabe = iIngEN.PeriodoSolicitudPedidoCabe;
            pMovCab.NumeroMovimientoCabe = iNuevoNumero;
            pMovCab.FechaMovimientoCabe = Fecha.ObtenerAnoMesDia(DateTime.Now);
            pMovCab.CodigoTipoOperacion = "41";
            pMovCab.DescripcionTipoOperacion = "COMPRAS LOCALES";
            pMovCab.CodigoAlmacen = iIngEN.CodigoAlmacen;
            pMovCab.DescripcionAlmacen = iIngEN.DescripcionAlmacen;
            pMovCab.CodigoPersonal = iIngEN.CodigoPersonal;
            pMovCab.CodigoPersonalAutoriza = iIngEN.CodigoPersonalAutoriza;
            pMovCab.CodigoPersonalRecibe = string.Empty;
            pMovCab.CostoFleteMovimientoCabe = iIngEN.CostoFleteSolicitudPedidoCabe;
            pMovCab.CCodigoMoneda = iIngEN.CCodigoMoneda;
            pMovCab.TipoCambio = iIngEN.TipoCambio;
            pMovCab.CodigoAuxiliar = this.txtCodAux.Text;
            pMovCab.DescripcionAuxiliar = this.txtDesAux.Text;
            pMovCab.OrdenCompra = string.Empty;
            pMovCab.CTipoDocumento = string.Empty;
            pMovCab.SerieDocumento = string.Empty;
            pMovCab.NumeroDocumento = string.Empty;
            pMovCab.FechaDocumento = Fecha.ObtenerAnoMesDia(DateTime.Now);
            pMovCab.GlosaMovimientoCabe = iIngEN.GlosaSolicitudPedidoCabe;
            pMovCab.COrigenVentanaCreacion = "1";//ingreso     
            pMovCab.FlagCreadoxSolicitud = 1;
            pMovCab.ClaveSolicitudPedidoCabe = this.ClaveSolicitudPedidoCabe.TrimEnd('|');
            pMovCab.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }


        public MovimientoOCCabeEN NuevoMovimientoCabeDeVentana(SolicitudPedidoCabeEN iIngEN)
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iMovCabEN);
            return iMovCabEN;
        }

        public void AdicionarMovimientosDeta(SolicitudPedidoCabeEN iIngEN, SolicitudPedidoDetaEN iSolDet)
        {
            MovimientoOCDetaEN xMovDet = new MovimientoOCDetaEN();
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe(iIngEN);

            //incrementar el correlativo
            iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

            //actualizar algunos datos antes de grabar
            xMovDet.CodigoEmpresa = iSolDet.CodigoEmpresa;
            xMovDet.NombreEmpresa = iSolDet.NombreEmpresa;
            xMovDet.PeriodoMovimientoCabe = iSolDet.PeriodoSolicitudPedidoCabe;
            xMovDet.CodigoAlmacen = iSolDet.CodigoAlmacen;
            xMovDet.DescripcionAlmacen = iSolDet.DescripcionAlmacen;
            xMovDet.CodigoTipoOperacion = "41";
            xMovDet.DescripcionTipoOperacion = "COMPRAS LOCALES";
            xMovDet.CClaseTipoOperacion = "1";
            xMovDet.CodigoAuxiliar = iSolDet.CodigoAuxiliar;
            xMovDet.DescripcionAuxiliar = iSolDet.DescripcionAuxiliar;
            xMovDet.CodigoCentroCosto = iSolDet.CodigoCentroCosto;
            xMovDet.DescripcionCentroCosto = iSolDet.DescripcionCentroCosto;
            xMovDet.CodigoExistencia = iSolDet.CodigoExistencia;
            xMovDet.DescripcionExistencia = iSolDet.DescripcionExistencia;
            xMovDet.CodigoTipo = iSolDet.CodigoTipo;
            xMovDet.NombreTipo = iSolDet.NombreTipo;
            xMovDet.CEsLote = iSolDet.CEsLote;
            xMovDet.CCodigoPartida = iSolDet.CCodigoPartida;
            xMovDet.NCodigoPartida = iSolDet.NCodigoPartida;
            xMovDet.GlosaMovimientoDeta = iSolDet.GlosaSolicitudPedidoDeta;
            xMovDet.FechaMovimientoCabe = iSolDet.FechaSolicitudPedidoCabe;
            xMovDet.PrecioUnitarioMovimientoDeta = 0;
            xMovDet.CostoFleteMovimientoDeta = 0;
            xMovDet.FactorConversion = 0;
            xMovDet.CodigoUnidadMedida = iSolDet.CodigoUnidadMedida;
            xMovDet.NombreUnidadMedida = iSolDet.NombreUnidadMedida;
            xMovDet.CantidadMovimientoDeta = iSolDet.CantidadSolicitudPedidoDeta;
            xMovDet.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(xMovDet);
            xMovDet.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);
            xMovDet.NumeroMovimientoCabe = iSolDet.NumeroSolicitudPedidoCabe;
            xMovDet.ClaveMovimientoCabe = iClaveMovimientoCabe;
            xMovDet.CorrelativoMovimientoDeta = iCorrelativo;
            xMovDet.CostoFleteMovimientoCabe = iSolDet.CostoFleteSolicitudPedidoCabe;
            xMovDet.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(xMovDet);
            xMovDet.CCodigoMoneda = iSolDet.CCodigoMoneda;

            //adicion masiva
            MovimientoOCDetaRN.AdicionarMovimientoDeta(xMovDet);
        }
        public void AsignarLote(LoteEN pObj, LoteEN objLote)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAlmacen = objLote.CodigoAlmacen;
            pObj.CodigoExistencia = objLote.CodigoExistencia;
            pObj.DescripcionExistencia = objLote.DescripcionExistencia;
            pObj.CodigoLote = objLote.CodigoLote;
            pObj.FechaVencimientoLote = objLote.FechaVencimientoLote;
            pObj.NumeroLote = objLote.NumeroLote;
            pObj.FechaProduccionLote = objLote.FechaProduccionLote;
            pObj.StockConversionLote = objLote.StockConversionLote;
            pObj.StockLote = objLote.StockLote;
            pObj.StockSaldoLote = pObj.StockLote;
            pObj.ClaveLote = LoteRN.ObtenerClaveLote(pObj);
        }

        public string ObtenerClaveMovimientoCabe(SolicitudPedidoCabeEN iIngEN)
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public void AsignarSolicitudEnviar(int pFilaChequeada, int pColumnaChequeada)
        {
            //solo debe actuar cuando la columna sea "0" y la fila diferente de "-1"
            if (pColumnaChequeada == 0 && pFilaChequeada != -1)
            {
                SolicitudPedidoDetaEN iSolEN = new SolicitudPedidoDetaEN();
                iSolEN.ClaveSolicitudPedidoDeta = Dgv.ObtenerValorCelda(this.dgvMovDet, SolicitudPedidoDetaEN.ClaObj);
                bool flagEnviado = Convert.ToBoolean(Dgv.ObtenerValorCelda(this.dgvMovDet, SolicitudPedidoDetaEN.FlgChkIt));
                if (!flagEnviado)
                    foreach (SolicitudPedidoDetaEN item in this.eLisMovDet)
                    {
                        if (item.ClaveSolicitudPedidoDeta == iSolEN.ClaveSolicitudPedidoDeta)
                            item.VerdadFalso = !this.eLisMovDet[pFilaChequeada].VerdadFalso;
                    }
            }
        }
        public bool EsValidoEnvio()
        {
            //valida la grilla vacia
            if (dgvMovDet.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("no hay registros en la grilla", this.wFrm.eTitulo);
                return false;
            }

            //validar cuotas marcadas
            List<int> iLisMar = this.listaSolicitudesEnviadas();
            if (iLisMar.Count == 0)
            {
                Mensaje.OperacionDenegada("Al menos debes chequear un item", this.wFrm.eTitulo);
                return false;
            }

            //ok
            return true;
        }

        public List<int> listaSolicitudesEnviadas()
        {
            List<int> cuentaCheck = new List<int>();
            int cuenta = 0;
            for (int i = 0; i < this.eLisMovDet.Count; i++)
            {
                if (Convert.ToBoolean(this.eLisMovDet[i].VerdadFalso))
                {
                    cuentaCheck.Add(cuenta++);
                }
            }
            return cuentaCheck;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void wGenerarOrdenCompraPorItemDeRequerimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wFrm.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GenerarOrdenCompra();
        }

        private void dgvMovDet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.AsignarSolicitudEnviar(e.RowIndex, e.ColumnIndex);
        }
    }
}
