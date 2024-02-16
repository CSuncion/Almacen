using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Contabilidad
{
    public class RegContabCabe_Cont_EN
    {
        public const string ClaObj = "ClaveObjeto";
        public const string _ClaveRegContabCabe = "ClaveRegContabCabe";
        public const string _CodigoEmpresa = "CodigoEmpresa";
        public const string _PeriodoRegContabCabe = "PeriodoRegContabCabe";
        public const string _COrigen = "COrigen";
        public const string _CFile = "CFile";
        public const string _CorrelativoRegContabCabe = "CorrelativoRegContabCabe";
        public const string _FechaRegContabCabe = "FechaRegContabCabe";
        public const string _CodigoAuxiliar = "CodigoAuxiliar";
        public const string _CModoCompra = "CModoCompra";
        public const string _CTipoCompra = "CTipoCompra";
        public const string _CTipoDocumento = "CTipoDocumento";
        public const string _SerieDocumento = "SerieDocumento";
        public const string _NumeroDocumento = "NumeroDocumento";
        public const string _FechaDocumento = "FechaDocumento";
        public const string _FechaVctoDocumento = "FechaVctoDocumento";
        public const string _CMonedaDocumento = "CMonedaDocumento";
        public const string _CTipoDocumentoRef = "CTipoDocumentoRef";
        public const string _SerieDocumentoRef = "SerieDocumentoRef";
        public const string _NumeroDocumentoRef = "NumeroDocumentoRef";
        public const string _FechaDocumentoRef = "FechaDocumentoRef";
        public const string _FechaVctoDocumentoRef = "FechaVctoDocumentoRef";
        public const string _CMonedaDocumentoRef = "CMonedaDocumentoRef";
        public const string _VentaTipoCambio = "VentaTipoCambio";
        public const string _PorcentajeIgv = "PorcentajeIgv";
        public const string _CAplicaIgv = "CAplicaIgv";
        public const string _CAplicaInafecto = "CAplicaInafecto";
        public const string _ValorVentaRegContabCabe = "ValorVentaRegContabCabe";
        public const string _IgvRegContabCabe = "IgvRegContabCabe";
        public const string _ExoneradoRegContabCabe = "ExoneradoRegContabCabe";
        public const string _InafectoRegContabCabe = "InafectoRegContabCabe";
        public const string _PrecioVentaRegContabCabe = "PrecioVentaRegContabCabe";
        public const string _ValorVentaSolRegContabCabe = "ValorVentaSolRegContabCabe";
        public const string _IgvSolRegContabCabe = "IgvSolRegContabCabe";
        public const string _ExoneradoSolRegContabCabe = "ExoneradoSolRegContabCabe";
        public const string _InafectoSolRegContabCabe = "InafectoSolRegContabCabe";
        public const string _PrecioVentaSolRegContabCabe = "PrecioVentaSolRegContabCabe";
        public const string _GlosaRegContabCabe = "GlosaRegContabCabe";
        public const string _CAplicaDetraccion = "CAplicaDetraccion";
        public const string _NumeroPapeletaDetraccion = "NumeroPapeletaDetraccion";
        public const string _FechaDetraccion = "FechaDetraccion";
        public const string _CodigoCuenta = "CodigoCuenta";
        public const string _CAplicaRetencion = "CAplicaRetencion";
        public const string _TotalHonorario = "TotalHonorario";
        public const string _RetencionHonorario = "RetencionHonorario";
        public const string _PagoHonorario = "PagoHonorario";
        public const string _ImporteRegContabCabe = "ImporteRegContabCabe";
        public const string _ImporteSolRegContabCabe = "ImporteSolRegContabCabe";
        public const string _CModoPago = "CModoPago";
        public const string _GiradoPagoRegContabCabe = "GiradoPagoRegContabCabe";
        public const string _CartaRegContabCabe = "CartaRegContabCabe";
        public const string _ClaveIngresoRegContabCabe = "ClaveIngresoRegContabCabe";
        public const string _CEstadoRegContabCabe = "CEstadoRegContabCabe";
        public const string _UsuarioAgrega = "UsuarioAgrega";
        public const string _FechaAgrega = "FechaAgrega";
        public const string _UsuarioModifica = "UsuarioModifica";
        public const string _FechaModifica = "FechaModifica";


        public string ClaveObjeto { get; set; }
        public string ClaveRegContabCabe { get; set; }
        public string CodigoEmpresa { get; set; }
        public string PeriodoRegContabCabe { get; set; }
        public string COrigen { get; set; }
        public string CFile { get; set; }
        public string CorrelativoRegContabCabe { get; set; }
        public string FechaRegContabCabe { get; set; }
        public string CodigoAuxiliar { get; set; }
        public string CModoCompra { get; set; }
        public string CTipoCompra { get; set; }
        public string CTipoDocumento { get; set; }
        public string SerieDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string FechaDocumento { get; set; }
        public string FechaVctoDocumento { get; set; }
        public string CMonedaDocumento { get; set; }
        public string CTipoDocumentoRef { get; set; }
        public string SerieDocumentoRef { get; set; }
        public string NumeroDocumentoRef { get; set; }
        public string FechaDocumentoRef { get; set; }
        public string FechaVctoDocumentoRef { get; set; }
        public string CMonedaDocumentoRef { get; set; }
        public decimal VentaTipoCambio { get; set; }
        public decimal PorcentajeIgv { get; set; }
        public string CAplicaIgv { get; set; }
        public string CAplicaInafecto { get; set; }
        public decimal ValorVentaRegContabCabe { get; set; }
        public decimal IgvRegContabCabe { get; set; }
        public decimal ExoneradoRegContabCabe { get; set; }
        public decimal InafectoRegContabCabe { get; set; }
        public decimal PrecioVentaRegContabCabe { get; set; }
        public decimal ValorVentaSolRegContabCabe { get; set; }
        public decimal IgvSolRegContabCabe { get; set; }
        public decimal ExoneradoSolRegContabCabe { get; set; }
        public decimal InafectoSolRegContabCabe { get; set; }
        public decimal PrecioVentaSolRegContabCabe { get; set; }
        public string GlosaRegContabCabe { get; set; }
        public string CAplicaDetraccion { get; set; }
        public string NumeroPapeletaDetraccion { get; set; }
        public string FechaDetraccion { get; set; }
        public string CodigoCuenta { get; set; }
        public string CAplicaRetencion { get; set; }
        public decimal TotalHonorario { get; set; }
        public decimal RetencionHonorario { get; set; }
        public decimal PagoHonorario { get; set; }
        public decimal ImporteRegContabCabe { get; set; }
        public decimal ImporteSolRegContabCabe { get; set; }
        public string CModoPago { get; set; }
        public string GiradoPagoRegContabCabe { get; set; }
        public string CartaRegContabCabe { get; set; }
        public string ClaveIngresoRegContabCabe { get; set; }
        public string CEstadoRegContabCabe { get; set; }
        public string UsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime FechaModifica { get; set; }
        private Adicional _Adicionales = new Adicional();

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
