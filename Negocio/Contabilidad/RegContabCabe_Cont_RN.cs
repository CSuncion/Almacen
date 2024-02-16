using Comun;
using Datos;
using Datos.Contabilidad;
using Entidades;
using Entidades.Adicionales;
using Entidades.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contabilidad
{
    public class RegContabCabe_Cont_RN
    {
        public static string vaucherCorrelativoRegCont = string.Empty;
        public static string vaucherCorrelativoRegContDeta = string.Empty;
        public static RegContabCabe_Cont_EN EnBlanco()
        {
            RegContabCabe_Cont_EN iPerEN = new RegContabCabe_Cont_EN();
            return iPerEN;
        }

        //public static List<List<RegContabCabe_Cont_EN>> ListarRegContabDetasParaImportar(string pCodigoPeriodo)
        //{
        //    RegContabCabe_Cont_EN iPerAD = new RegContabCabe_Cont_EN();
        //    return iPerAD.ListarRegContabDetasParaImportar(pCodigoPeriodo);
        //}

        public static string ObtenerValorDeCampo(RegContabCabe_Cont_EN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case RegContabCabe_Cont_EN.ClaObj: return pObj.ClaveObjeto;
                case RegContabCabe_Cont_EN._ClaveRegContabCabe: return pObj.ClaveRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._CodigoEmpresa: return pObj.CodigoEmpresa.ToString();
                case RegContabCabe_Cont_EN._PeriodoRegContabCabe: return pObj.PeriodoRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._COrigen: return pObj.COrigen.ToString();
                case RegContabCabe_Cont_EN._CFile: return pObj.CFile.ToString();
                case RegContabCabe_Cont_EN._CorrelativoRegContabCabe: return pObj.CorrelativoRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._FechaRegContabCabe: return pObj.FechaRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._CodigoAuxiliar: return pObj.CodigoAuxiliar.ToString();
                case RegContabCabe_Cont_EN._CModoCompra: return pObj.CModoCompra.ToString();
                case RegContabCabe_Cont_EN._CTipoCompra: return pObj.CTipoCompra.ToString();
                case RegContabCabe_Cont_EN._CTipoDocumento: return pObj.CTipoDocumento.ToString();
                case RegContabCabe_Cont_EN._SerieDocumento: return pObj.SerieDocumento.ToString();
                case RegContabCabe_Cont_EN._NumeroDocumento: return pObj.NumeroDocumento.ToString();
                case RegContabCabe_Cont_EN._FechaDocumento: return pObj.FechaDocumento.ToString();
                case RegContabCabe_Cont_EN._FechaVctoDocumento: return pObj.FechaVctoDocumento.ToString();
                case RegContabCabe_Cont_EN._CMonedaDocumento: return pObj.CMonedaDocumento.ToString();
                case RegContabCabe_Cont_EN._CTipoDocumentoRef: return pObj.CTipoDocumentoRef.ToString();
                case RegContabCabe_Cont_EN._SerieDocumentoRef: return pObj.SerieDocumentoRef.ToString();
                case RegContabCabe_Cont_EN._NumeroDocumentoRef: return pObj.NumeroDocumentoRef.ToString();
                case RegContabCabe_Cont_EN._FechaDocumentoRef: return pObj.FechaDocumentoRef.ToString();
                case RegContabCabe_Cont_EN._FechaVctoDocumentoRef: return pObj.FechaVctoDocumentoRef.ToString();
                case RegContabCabe_Cont_EN._CMonedaDocumentoRef: return pObj.CMonedaDocumentoRef.ToString();
                case RegContabCabe_Cont_EN._VentaTipoCambio: return pObj.VentaTipoCambio.ToString();
                case RegContabCabe_Cont_EN._PorcentajeIgv: return pObj.PorcentajeIgv.ToString();
                case RegContabCabe_Cont_EN._CAplicaIgv: return pObj.CAplicaIgv.ToString();
                case RegContabCabe_Cont_EN._CAplicaInafecto: return pObj.CAplicaInafecto.ToString();
                case RegContabCabe_Cont_EN._ValorVentaRegContabCabe: return pObj.ValorVentaRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._IgvRegContabCabe: return pObj.IgvRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._ExoneradoRegContabCabe: return pObj.ExoneradoRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._InafectoRegContabCabe: return pObj.InafectoRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._PrecioVentaRegContabCabe: return pObj.PrecioVentaRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._ValorVentaSolRegContabCabe: return pObj.ValorVentaSolRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._IgvSolRegContabCabe: return pObj.IgvSolRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._ExoneradoSolRegContabCabe: return pObj.ExoneradoSolRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._InafectoSolRegContabCabe: return pObj.InafectoSolRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._PrecioVentaSolRegContabCabe: return pObj.PrecioVentaSolRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._GlosaRegContabCabe: return pObj.GlosaRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._CAplicaDetraccion: return pObj.CAplicaDetraccion.ToString();
                case RegContabCabe_Cont_EN._NumeroPapeletaDetraccion: return pObj.NumeroPapeletaDetraccion.ToString();
                case RegContabCabe_Cont_EN._FechaDetraccion: return pObj.FechaDetraccion.ToString();
                case RegContabCabe_Cont_EN._CodigoCuenta: return pObj.CodigoCuenta.ToString();
                case RegContabCabe_Cont_EN._CAplicaRetencion: return pObj.CAplicaRetencion.ToString();
                case RegContabCabe_Cont_EN._TotalHonorario: return pObj.TotalHonorario.ToString();
                case RegContabCabe_Cont_EN._RetencionHonorario: return pObj.RetencionHonorario.ToString();
                case RegContabCabe_Cont_EN._PagoHonorario: return pObj.PagoHonorario.ToString();
                case RegContabCabe_Cont_EN._ImporteRegContabCabe: return pObj.ImporteRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._ImporteSolRegContabCabe: return pObj.ImporteSolRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._CModoPago: return pObj.CModoPago.ToString();
                case RegContabCabe_Cont_EN._GiradoPagoRegContabCabe: return pObj.GiradoPagoRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._CartaRegContabCabe: return pObj.CartaRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._ClaveIngresoRegContabCabe: return pObj.ClaveIngresoRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._CEstadoRegContabCabe: return pObj.CEstadoRegContabCabe.ToString();
                case RegContabCabe_Cont_EN._UsuarioAgrega: return pObj.UsuarioAgrega.ToString();
                case RegContabCabe_Cont_EN._FechaAgrega: return pObj.FechaAgrega.ToString();
                case RegContabCabe_Cont_EN._UsuarioModifica: return pObj.UsuarioModifica.ToString();
                case RegContabCabe_Cont_EN._FechaModifica: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<RegContabCabe_Cont_EN> FiltrarRegContabDeta_Cont_sXTextoEnCualquierPosicion(List<RegContabCabe_Cont_EN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<RegContabCabe_Cont_EN> iLisRes = new List<RegContabCabe_Cont_EN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (RegContabCabe_Cont_EN xPer in pLista)
            {
                string iTexto = RegContabCabe_Cont_RN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<RegContabCabe_Cont_EN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<RegContabCabe_Cont_EN> pListaRegContabDeta_Cont_s)
        {
            //lista resultado
            List<RegContabCabe_Cont_EN> iLisRes = new List<RegContabCabe_Cont_EN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaRegContabDeta_Cont_s; }

            //filtar la lista
            iLisRes = RegContabCabe_Cont_RN.FiltrarRegContabDeta_Cont_sXTextoEnCualquierPosicion(pListaRegContabDeta_Cont_s, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string TransformarAPeriodoContable(string pCodigoPeriodoAlmacen)
        {
            //valor resulatdo
            string iValor = string.Empty;

            //operar
            iValor = pCodigoPeriodoAlmacen.Replace("-", "");

            //devolver
            return iValor;
        }

        public static bool EsCompraNacional(RegContabCabe_Cont_EN pObj)
        {
            //validar por el tipo documento
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CTipoDocumento, "00,46,51,52,53,91,97,98") == true)
            {
                //seria importacion por lotanto devuelve false
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void AdicionarRegContaCabe(RegContabCabe_Cont_EN pObj)
        {
            RegContabCabe_Cont_AD iPerAD = new RegContabCabe_Cont_AD();
            iPerAD.AgregarRegContaCabe(pObj);
        }
        public static void ExportarOrdenCompraAContabilidad(string periodo)
        {
            List<MovimientoOCCabeEN> movimientoOCCabeENs = new List<MovimientoOCCabeEN>();
            MovimientoOCCabeEN movimientoOCCabeEN = new MovimientoOCCabeEN();
            movimientoOCCabeEN.PeriodoMovimientoCabe = periodo;
            movimientoOCCabeEN.Adicionales.CampoOrden = MovimientoOCCabeEN.NumMovCab;
            movimientoOCCabeENs = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodo(movimientoOCCabeEN);

            foreach (MovimientoOCCabeEN movimientoOC in movimientoOCCabeENs)
            {
                if (movimientoOC.FlagExportadoConta == 0)
                {
                    RegContabCabe_Cont_EN regContabCabe_Cont_EN = new RegContabCabe_Cont_EN();
                    RegContabCabe_Cont_RN.AsignarReContabCabe(regContabCabe_Cont_EN, movimientoOC);
                    RegContabCabe_Cont_RN.AdicionarRegContaCabe(regContabCabe_Cont_EN);

                    MovimientoOCDetaEN movimientoOCDetaEN = new MovimientoOCDetaEN();
                    List<MovimientoOCDetaEN> movimientoOCDetaENs = new List<MovimientoOCDetaEN>();
                    movimientoOCDetaEN.ClaveMovimientoCabe = movimientoOC.ClaveMovimientoCabe;
                    movimientoOCDetaENs = MovimientoOCDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(movimientoOCDetaEN);

                    for (int i = 0; i < 3; i++)
                    {
                        RegContabDeta_Cont_EN regContabDeta_Cont_EN = new RegContabDeta_Cont_EN();
                        RegContabCabe_Cont_RN.AsignarRegContabDeta(regContabDeta_Cont_EN, regContabCabe_Cont_EN, i, movimientoOCDetaENs);
                        RegContabDeta_Cont_RN.AdicionarRegContaDeta(regContabDeta_Cont_EN);
                    }
                }
            }
        }

        public static void AsignarRegContabDeta(RegContabDeta_Cont_EN regContabDeta_Cont_EN, RegContabCabe_Cont_EN regContabCabe_Cont_EN, int count, List<MovimientoOCDetaEN> movimientoOCDetaENs)
        {




            regContabDeta_Cont_EN.CodigoEmpresa = regContabCabe_Cont_EN.CodigoEmpresa;
            regContabDeta_Cont_EN.PeriodoRegContabCabe = regContabCabe_Cont_EN.PeriodoRegContabCabe;

            regContabDeta_Cont_EN.CFile = regContabCabe_Cont_EN.CFile;
            regContabDeta_Cont_EN.COrigen = regContabCabe_Cont_EN.COrigen;
            regContabDeta_Cont_EN.CorrelativoRegContabCabe = regContabCabe_Cont_EN.CorrelativoRegContabCabe;
            regContabDeta_Cont_EN.ClaveRegContabCabe = regContabCabe_Cont_EN.ClaveRegContabCabe;

            regContabDeta_Cont_EN.ClaveRegContabDeta = RegContabCabe_Cont_RN.ObtenerClaveMovimientoDeta(regContabDeta_Cont_EN);

            regContabDeta_Cont_EN.CodigoAuxiliar = count == 0 ? regContabCabe_Cont_EN.CodigoAuxiliar : string.Empty;
            regContabDeta_Cont_EN.CTipoDocumento = count == 0 ? regContabCabe_Cont_EN.CTipoDocumento : string.Empty;
            regContabDeta_Cont_EN.SerieDocumento = count == 0 ? regContabCabe_Cont_EN.SerieDocumento : string.Empty;
            regContabDeta_Cont_EN.NumeroDocumento = count == 0 ? regContabCabe_Cont_EN.NumeroDocumento : string.Empty;
            regContabDeta_Cont_EN.FechaDocumento = count == 0 ? regContabCabe_Cont_EN.FechaDocumento : string.Empty;
            regContabDeta_Cont_EN.FechaVctoDocumento = count == 0 ? regContabCabe_Cont_EN.FechaVctoDocumento : string.Empty;
            regContabDeta_Cont_EN.CMonedaDocumento = count == 0 ? regContabCabe_Cont_EN.CMonedaDocumento : string.Empty;

            regContabDeta_Cont_EN.VentaTipoCambio = 0;

            // 0 = 421101 total venta // 1 = 521111 valor venta // 2 = 721111 igv

            regContabDeta_Cont_EN.CodigoCuenta = count == 0 ? "421101" : count == 1 ? "521111" : "721111";
            regContabDeta_Cont_EN.CDebeHaber = count == 0 ? "1" : "0";

            regContabDeta_Cont_EN.ImporteSolRegContabDeta = count == 0 ? regContabCabe_Cont_EN.PrecioVentaRegContabCabe : count == 1 ? regContabCabe_Cont_EN.ValorVentaRegContabCabe : regContabCabe_Cont_EN.IgvRegContabCabe; ;

            regContabDeta_Cont_EN.GlosaRegContabDeta = regContabCabe_Cont_EN.GlosaRegContabCabe;



            regContabDeta_Cont_EN.ImporteMonedaRegContabDeta = 0;
            regContabDeta_Cont_EN.CIngresoEgreso = string.Empty;
            regContabDeta_Cont_EN.CCentroCosto = count == 1 ? movimientoOCDetaENs.FirstOrDefault().CodigoCentroCosto : string.Empty;
            regContabDeta_Cont_EN.CArea = string.Empty;
            regContabDeta_Cont_EN.CFlujoCaja = string.Empty;
            regContabDeta_Cont_EN.CodigoAlmacen = string.Empty;
            regContabDeta_Cont_EN.CodigoItemAlmacen = string.Empty;
            regContabDeta_Cont_EN.CantidadItemAlmacen = 0;
            regContabDeta_Cont_EN.CTipoLineaAsiento = count == 1 ? "0" : "1";
            regContabDeta_Cont_EN.CEstadoRegContabDeta = "1";
            regContabDeta_Cont_EN.UsuarioAgrega = regContabCabe_Cont_EN.UsuarioAgrega;
            regContabDeta_Cont_EN.FechaAgrega = DateTime.Now;
            regContabDeta_Cont_EN.UsuarioModifica = regContabCabe_Cont_EN.UsuarioModifica;
            regContabDeta_Cont_EN.FechaModifica = DateTime.Now;


        }

        public static void AsignarReContabCabe(RegContabCabe_Cont_EN regContabCabe_Cont_EN, MovimientoOCCabeEN movimientoOC)
        {
            regContabCabe_Cont_EN.CodigoEmpresa = movimientoOC.CodigoEmpresa;
            regContabCabe_Cont_EN.PeriodoRegContabCabe = movimientoOC.PeriodoMovimientoCabe;
            regContabCabe_Cont_EN.ClaveRegContabCabe = RegContabCabe_Cont_RN.ObtenerClaveMovimientoCabe(regContabCabe_Cont_EN);
            regContabCabe_Cont_EN.COrigen = "4";
            regContabCabe_Cont_EN.CFile = "401";
            regContabCabe_Cont_EN.CorrelativoRegContabCabe = vaucherCorrelativoRegCont;
            regContabCabe_Cont_EN.FechaRegContabCabe = DateTime.Now.ToShortDateString();
            regContabCabe_Cont_EN.CodigoAuxiliar = movimientoOC.CodigoAuxiliar;
            regContabCabe_Cont_EN.CModoCompra = "1";
            regContabCabe_Cont_EN.CTipoCompra = "0";
            regContabCabe_Cont_EN.CTipoDocumento = movimientoOC.CTipoDocumento;
            regContabCabe_Cont_EN.SerieDocumento = movimientoOC.SerieDocumento;
            regContabCabe_Cont_EN.NumeroDocumento = movimientoOC.NumeroDocumento;
            regContabCabe_Cont_EN.FechaDocumento = movimientoOC.FechaDocumento;
            regContabCabe_Cont_EN.FechaVctoDocumento = movimientoOC.FechaValidezCotizacion;
            regContabCabe_Cont_EN.CMonedaDocumento = movimientoOC.CCodigoMoneda;
            regContabCabe_Cont_EN.CTipoDocumentoRef = string.Empty;
            regContabCabe_Cont_EN.SerieDocumentoRef = string.Empty;
            regContabCabe_Cont_EN.NumeroDocumentoRef = string.Empty;
            regContabCabe_Cont_EN.FechaDocumentoRef = string.Empty;
            regContabCabe_Cont_EN.FechaVctoDocumentoRef = string.Empty;
            regContabCabe_Cont_EN.CMonedaDocumentoRef = string.Empty;
            regContabCabe_Cont_EN.VentaTipoCambio = movimientoOC.TipoCambio;
            regContabCabe_Cont_EN.PorcentajeIgv = movimientoOC.IgvPorcentaje;
            regContabCabe_Cont_EN.CAplicaIgv = movimientoOC.IgvPorcentaje == 0 ? "0" : "1";
            regContabCabe_Cont_EN.CAplicaInafecto = movimientoOC.IgvPorcentaje == 0 ? "0" : "1";
            regContabCabe_Cont_EN.ValorVentaRegContabCabe = movimientoOC.ValorVtaMovimientoCabe;
            regContabCabe_Cont_EN.IgvRegContabCabe = movimientoOC.IgvMovimientoCabe;
            regContabCabe_Cont_EN.ExoneradoRegContabCabe = 0;
            regContabCabe_Cont_EN.InafectoRegContabCabe = 0;
            regContabCabe_Cont_EN.PrecioVentaRegContabCabe = movimientoOC.MontoTotalMovimientoCabe;
            regContabCabe_Cont_EN.ValorVentaSolRegContabCabe = movimientoOC.ValorVtaMovimientoCabe;
            regContabCabe_Cont_EN.IgvSolRegContabCabe = movimientoOC.IgvMovimientoCabe;
            regContabCabe_Cont_EN.ExoneradoSolRegContabCabe = 0;
            regContabCabe_Cont_EN.InafectoSolRegContabCabe = 0;
            regContabCabe_Cont_EN.PrecioVentaSolRegContabCabe = movimientoOC.MontoTotalMovimientoCabe;
            regContabCabe_Cont_EN.GlosaRegContabCabe = movimientoOC.GlosaMovimientoCabe;
            regContabCabe_Cont_EN.CAplicaDetraccion = "0";
            regContabCabe_Cont_EN.NumeroPapeletaDetraccion = string.Empty;
            regContabCabe_Cont_EN.FechaDetraccion = string.Empty;
            regContabCabe_Cont_EN.CodigoCuenta = movimientoOC.CCodigoMoneda == "0" ? "421101" : "421102";
            regContabCabe_Cont_EN.CAplicaRetencion = string.Empty;
            regContabCabe_Cont_EN.TotalHonorario = 0;
            regContabCabe_Cont_EN.RetencionHonorario = 0;
            regContabCabe_Cont_EN.PagoHonorario = 0;
            regContabCabe_Cont_EN.ImporteRegContabCabe = 0;
            regContabCabe_Cont_EN.ImporteSolRegContabCabe = 0;
            regContabCabe_Cont_EN.CModoPago = string.Empty;
            regContabCabe_Cont_EN.GiradoPagoRegContabCabe = string.Empty;
            regContabCabe_Cont_EN.CartaRegContabCabe = string.Empty;
            regContabCabe_Cont_EN.ClaveIngresoRegContabCabe = string.Empty;
            regContabCabe_Cont_EN.CEstadoRegContabCabe = "1";
            regContabCabe_Cont_EN.UsuarioAgrega = movimientoOC.UsuarioAgrega;
            regContabCabe_Cont_EN.FechaAgrega = DateTime.Now;
            regContabCabe_Cont_EN.UsuarioModifica = movimientoOC.UsuarioModifica;
            regContabCabe_Cont_EN.FechaModifica = DateTime.Now;

        }
        public static string ObtenerClaveMovimientoCabe(RegContabCabe_Cont_EN pPer)
        {
            RegContabCabe_Cont_RN.MostrarNuevoNumero(pPer);
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.PeriodoRegContabCabe + "-";
            iClave += "4-";
            iClave += "401-";
            iClave += vaucherCorrelativoRegCont;

            //retornar
            return iClave;
        }
        public static void MostrarNuevoNumero(RegContabCabe_Cont_EN pObj)
        {
            //asignar parametros
            RegContabCabe_Cont_EN iRegConCabEN = new RegContabCabe_Cont_EN();

            iRegConCabEN.PeriodoRegContabCabe = pObj.PeriodoRegContabCabe;
            iRegConCabEN.CFile = "401";
            iRegConCabEN.COrigen = "4";

            //obtener el nuevo numero
            string iNuevoNumero = RegContabCabe_Cont_RN.ObtenerNuevoNumeroRegContaCabeAutogenerado(iRegConCabEN);

            //mostrar en pantalla
            vaucherCorrelativoRegCont = iNuevoNumero;
        }

        public static string ObtenerNuevoNumeroRegContaCabeAutogenerado(RegContabCabe_Cont_EN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = RegContabCabe_Cont_RN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }
        public static string ObtenerMaximoValorEnColumna(RegContabCabe_Cont_EN pObj)
        {
            RegContabCabe_Cont_AD iCliAD = new RegContabCabe_Cont_AD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }



        public static string ObtenerClaveMovimientoDeta(RegContabDeta_Cont_EN pPer)
        {
            RegContabCabe_Cont_RN.MostrarNuevoNumeroDeta(pPer);
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.PeriodoRegContabCabe + "-";
            iClave += "4-";
            iClave += "401-";
            iClave += vaucherCorrelativoRegCont + "-";
            iClave += vaucherCorrelativoRegContDeta;

            //retornar
            return iClave;
        }
        public static void MostrarNuevoNumeroDeta(RegContabDeta_Cont_EN pObj)
        {
            //asignar parametros
            RegContabDeta_Cont_EN iRegConCabEN = new RegContabDeta_Cont_EN();

            iRegConCabEN.PeriodoRegContabCabe = pObj.PeriodoRegContabCabe;
            iRegConCabEN.CFile = "401";
            iRegConCabEN.COrigen = "4";
            iRegConCabEN.CorrelativoRegContabCabe = vaucherCorrelativoRegCont;

            //obtener el nuevo numero
            string iNuevoNumero = RegContabCabe_Cont_RN.ObtenerNuevoNumeroMovimientoDetaAutogenerado(iRegConCabEN);

            //mostrar en pantalla
            vaucherCorrelativoRegCont = iNuevoNumero;
        }

        public static string ObtenerNuevoNumeroMovimientoDetaAutogenerado(RegContabDeta_Cont_EN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = RegContabCabe_Cont_RN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }
        public static string ObtenerMaximoValorEnColumna(RegContabDeta_Cont_EN pObj)
        {
            RegContabDeta_Cont_AD iCliAD = new RegContabDeta_Cont_AD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }

    }
}
