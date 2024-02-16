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
using Presentacion.ProcesosCompras;
using Entidades.Adicionales;
using System.Linq;

namespace Presentacion.ProcesosCompras
{
    public partial class wLisAuxGenerarCompra : Heredados.MiForm8
    {
        public wLisAuxGenerarCompra()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Condicion
        {
            Proveedores = 0,
            Clientes,
            ProveedoresActivos,
            ClientesActivos,
        }


        #endregion

        public Form eVentana = new Form();
        public AuxiliarEN eAuxEN = new AuxiliarEN();
        public List<AuxiliarEN> eLisAux = new List<AuxiliarEN>();
        public string eTituloVentana;
        public Condicion eCondicionLista;
        public string eCampoBusqueda;
        public TextBox eCtrlValor;
        public Control eCtrlFoco;
        public string codAux;
        wRequerimiento wFrm = new wRequerimiento();
        List<SolicitudPedidoCabeEN> listSolPed = new List<SolicitudPedidoCabeEN>();
        string iNuevoNumero = string.Empty;
        public List<SolicitudPedidoDetaEN> eLisSolDet = new List<SolicitudPedidoDetaEN>();
        public List<SolicitudPedidoDetaEN> eLisSolDetParcial = new List<SolicitudPedidoDetaEN>();
        string iCorrelativo = "0000";
        public List<LoteEN> eLisLot = new List<LoteEN>();
        #region Metodos


        public void InicializaVentana()
        {
            this.eVentana.Enabled = false;
            eAuxEN.Adicionales.CampoOrden = AuxiliarEN.DesAux;
            this.Text = "Listado de" + Cadena.Espacios(1) + this.eTituloVentana;
            this.eCampoBusqueda = "Descripcion";
            this.ActualizaVentana();
        }

        public void NuevaVentana(List<SolicitudPedidoCabeEN> pMovCab)
        {
            this.InicializaVentana();
            this.Show();
            this.txtBus.Focus();
            this.listSolPed = pMovCab;
        }

        public void ActualizaVentana()
        {
            this.ActualizarListaAuxiliarsDeBaseDatos();
            this.gbBus.Text = "Criterio de busqueda / Por :" + this.eCampoBusqueda;
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
        }

        public void ActualizarListaAuxiliarsDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (txtBus.Text.Trim() != string.Empty) { return; }

            //ejecutar segun condicion
            switch (eCondicionLista)
            {
                case Condicion.Proveedores: { this.eLisAux = AuxiliarRN.ListarProveedores(eAuxEN); break; }
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
                if (this.eCtrlValor != null)
                {
                    this.eCtrlValor.Text = Dgv.ObtenerValorCelda(this.DgvLista, AuxiliarEN.CodAux);
                    this.Close();
                    this.eCtrlValor.Focus();
                    this.eCtrlFoco.Focus();
                }
                else
                {
                    this.codAux = Dgv.ObtenerValorCelda(this.DgvLista, AuxiliarEN.CodAux);
                    this.MostrarPersistencia();
                    this.GenerarOrdenCompra();
                    this.Close();
                }
            }
        }


        public void OrdenarPorColumna(int pColumna)
        {
            eAuxEN.Adicionales.CampoOrden = this.DgvLista.Columns[pColumna].Name;
            this.eCampoBusqueda = this.DgvLista.Columns[pColumna].HeaderText;
            this.ActualizaVentana();
            Txt.CursorAlUltimo(this.txtBus);
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

        public MovimientoOCCabeEN NuevoMovimientoCabeDeVentana(SolicitudPedidoCabeEN iIngEN)
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iMovCabEN);
            return iMovCabEN;
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
            pMovCab.CodigoAuxiliar = this.codAux;
            pMovCab.DescripcionAuxiliar = iIngEN.DescripcionAuxiliar;
            pMovCab.OrdenCompra = string.Empty;
            pMovCab.CTipoDocumento = string.Empty;
            pMovCab.SerieDocumento = string.Empty;
            pMovCab.NumeroDocumento = string.Empty;
            pMovCab.FechaDocumento = Fecha.ObtenerAnoMesDia(DateTime.Now);
            pMovCab.GlosaMovimientoCabe = iIngEN.GlosaSolicitudPedidoCabe;
            pMovCab.COrigenVentanaCreacion = "1";//ingreso     
            pMovCab.FlagCreadoxSolicitud = 1;
            pMovCab.ClaveSolicitudPedidoCabe = iIngEN.ClaveSolicitudPedidoCabe;
            pMovCab.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
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
        public string ObtenerClaveMovimientoCabe(SolicitudPedidoCabeEN iIngEN)
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
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

        public bool EsValidoEnvio()
        {
            //valida la grilla vacia
            if (this.listSolPed.Count == 0)
            {
                Mensaje.OperacionDenegada("no hay registros en la grilla", this.wFrm.eTitulo);
                return false;
            }

            //validar cuotas marcadas
            List<int> iLisMar = this.listaSolicitudesEnviadas();
            if (iLisMar.Count == 0)
            {
                Mensaje.OperacionDenegada("Al menos debes chequear un registro", this.wFrm.eTitulo);
                return false;
            }

            //ok
            return true;
        }

        public List<int> listaSolicitudesEnviadas()
        {
            List<int> cuentaCheck = new List<int>();
            int cuenta = 0;
            for (int i = 0; i < this.listSolPed.Count; i++)
            {
                if (Convert.ToBoolean(this.listSolPed[i].VerdadFalso))
                {
                    cuentaCheck.Add(cuenta++);
                }
            }
            return cuentaCheck;
        }
        public void MostrarPersistencia()
        {
            TsL.MostrarValor(this.wFrm.lblPeriodo, Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa);
        }
        public void GenerarOrdenCompra()
        {
            if (this.EsValidoEnvio() == false) { return; }

            if (this.codAux == string.Empty) { Mensaje.OperacionDenegada("Debe seleccionar un proveedor.", this.wFrm.eTitulo); return; }

            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();

            foreach (SolicitudPedidoCabeEN item in this.listSolPed)
            {
                if (item.VerdadFalso)
                {
                    //preguntar si el registro seleccionado existe
                    iIngEN = this.EsActoGenerarOrdenCompra(item);

                    if (iIngEN.Adicionales.EsVerdad == false) { return; }

                    if (iIngEN.CEstadoSolicitudPedidoCabe == "5")
                    {
                        Mensaje.OperacionDenegada("La solicitud ha sido desaprobada, no se puede eliminar.", this.wFrm.eTitulo);
                        return;
                    }
                    this.MostrarNuevoNumero(iIngEN);
                }
            }

            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iCuoEN);
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iCuoEN);

            foreach (SolicitudPedidoCabeEN item in this.listSolPed)
            {
                if (item.VerdadFalso)
                {
                    SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
                    iMovDetEN.ClaveSolicitudPedidoCabe = item.ClaveSolicitudPedidoCabe;
                    iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;
                    this.eLisSolDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(iMovDetEN);
                    foreach (SolicitudPedidoDetaEN deta in this.eLisSolDet)
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

                    }
                }
            }



            iCorrelativo = "0000";
            foreach (SolicitudPedidoDetaEN objSD in this.eLisSolDetParcial)
            {
                this.AdicionarMovimientosDeta(iIngEN, objSD);
            }

            LoteEN iLotEN = new LoteEN();
            iLotEN.ClaveMovimientoCabe = iIngEN.ClaveSolicitudPedidoCabe;
            iLotEN.Adicionales.CampoOrden = LoteEN.CodExi + "," + LoteEN.CodLot;

            //ejecutar metodo
            this.eLisLot = LoteRN.ListarLotesDeClaveMovimientoCabe(iLotEN);
            List<LoteEN> eLote = new List<LoteEN>();

            //recorrer cada objeto
            foreach (LoteEN xLot in this.eLisLot)
            {
                //actualizar con la claveSolicitudPedidoCabe
                LoteEN iObjLot = new LoteEN();
                xLot.CodigoLote = "";
                this.AsignarLote(iObjLot, xLot);
                xLot.ClaveMovimientoCabe = iCuoEN.ClaveMovimientoCabe;
                xLot.CodigoLote = LoteRN.ObtenerNuevoCodigoLoteAutogenerado(iObjLot, eLote);

                this.AsignarLote(iObjLot, xLot);
                xLot.ClaveLote = iObjLot.ClaveLote;
                eLote.Add(xLot);
            }

            LoteRN.AdicionarLote(this.eLisLot);

            foreach (SolicitudPedidoCabeEN solCabe in this.listSolPed)
            {
                if (solCabe.VerdadFalso)
                {
                    SolicitudPedidoCabeRN.EnviadoSolicitudPedidoCabe(solCabe);
                }
            }

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se genero la orden de compra correctamente", this.wFrm.eTitulo);

            SolicitudPedidoCabeRN.CerrarSolicitudPedidoCabe(iIngEN);
            this.wFrm.ActualizarVentana();
        }


        #endregion


        private void wLisAux_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eVentana.Enabled = true;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DevolverDato();
        }

        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si se selecciono la barra espaciadora
            if (Encoding.ASCII.GetBytes(e.KeyChar.ToString())[0] == 13) { this.DevolverDato(); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DevolverDato();
        }

        private void txtBus_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void DgvLista_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }


    }
}
