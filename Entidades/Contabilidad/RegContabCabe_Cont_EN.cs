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
        public const string _CodigoOrigen = "CodigoOrigen";
        public const string _CodigoFile = "CodigoFile";
        public const string _NumeroVoucherRegContabCabe = "NumeroVoucherRegContabCabe";
        public const string _UltimoCorrelativo = "UltimoCorrelativo";
        public const string _MonedaVoucherRegContabCabe = "MonedaVoucherRegContabCabe";
        public const string _CorrelativoRegContabCabe = "CorrelativoRegContabCabe";
        public const string _DiaVoucherRegContabCabe = "DiaVoucherRegContabCabe";
        public const string _FechaVoucherRegContabCabe = "FechaVoucherRegContabCabe";
        public const string _CodigoAuxiliar = "CodigoAuxiliar";
        public const string _CModoCompra = "CModoCompra";
        public const string _CTipoCompra = "CTipoCompra";
        public const string _TipoDocumento = "TipoDocumento";
        public const string _SerieDocumento = "SerieDocumento";
        public const string _NumeroDocumento = "NumeroDocumento";
        public const string _FechaDocumento = "FechaDocumento";
        public const string _FechaVencimiento = "FechaVencimiento";
        public const string _CMonedaDocumento = "MonedaDocumento";
        public const string _CTipoDocumentoRef = "TipoDocumento1";
        public const string _SerieDocumentoRef = "SerieDocumento1";
        public const string _NumeroDocumentoRef = "NumeroDocumento1";
        public const string _FechaDocumentoRef = "FechaDocumento1";
        public const string _FechaVctoDocumentoRef = "FechaVctoDocumentoRef";
        public const string _CMonedaDocumentoRef = "MonedaDocumento1";
        public const string _VentaTipoCambio = "VentaTipoCambio";
        public const string _PorcentajeIgv = "IgvPar";
        public const string _CAplicaIgv = "CAplicaIgv";
        public const string _CAplicaInafecto = "CAplicaInafecto";
        public const string _ValorVentaRegContabCabe = "ValorVtaRegContabCabe";
        public const string _IgvRegContabCabe = "IgvRegContabCabe";
        public const string _ExoneradoRegContabCabe = "ExoneradoRegContabCabe";
        public const string _InafectoRegContabCabe = "InafectoRegContabCabe";
        public const string _PrecioVentaRegContabCabe = "PrecioVtaRegContabCabe";
        public const string _ValorVentaSolRegContabCabe = "ValorVentaSolRegContabCabe";
        public const string _IgvSolRegContabCabe = "IgvSolRegContabCabe";
        public const string _ExoneradoSolRegContabCabe = "ExoneradoSolRegContabCabe";
        public const string _InafectoSolRegContabCabe = "InafectoSolRegContabCabe";
        public const string _PrecioVentaSolRegContabCabe = "PrecioVtaSolRegContabCabe";
        public const string _GlosaRegContabCabe = "GlosaRegContabCabe";
        public const string _CAplicaDetraccion = "DetraccionRegContabCabe";
        public const string _NumeroPapeletaDetraccion = "NumeroPapeletaRegContabCabe";
        public const string _FechaDetraccion = "FechaDetraccionRegContabCabe";
        public const string _CodigoCuenta = "CodigoCuentaBanco";
        public const string _CAplicaRetencion = "CAplicaRetencion";
        public const string _TotalHonorario = "TotalHonorario";
        public const string _RetencionHonorario = "RetencionRegContabCabe";
        public const string _PagoHonorario = "PagoHonorario";
        public const string _ImporteRegContabCabe = "ImporteRegContabCabe";
        public const string _ImporteSolRegContabCabe = "ImporteSolRegContabCabe";
        public const string _CModoPago = "CodigoModoPago";
        public const string _GiradoPagoRegContabCabe = "GiradoPagoRegContabCabe";
        public const string _CartaRegContabCabe = "CartaRegContabCabe";
        public const string _DescripcionRegContabCabe = "DescripcionRegContabCabe";
        public const string _VoucherIngresoRegContabCabe = "VoucherIngresoRegContabCabe";
        public const string _ClaveIngresoRegContabCabe = "ClaveIngresoRegContabCabe";
        public const string _EstadoRegContabCabe = "EstadoRegContabCabe";
        public const string _SumaDebeRegContabCabe = "SumaDebeRegContabCabe";
        public const string _SumaHaberRegContabCabe = "SumaHaberRegContabCabe";
        public const string _CodigoIngEgr = "CodigoIngEgr";
        public const string _ModoCompra = "ModoCompra";
        public const string _FlagDescuentoRegcontabCabe = "FlagDescuentoRegcontabCabe";
        public const string _CodigoAfp = "CodigoAfp";
        public const string _ImporteDescuentoRegContabCabe = "ImporteDescuentoRegContabCabe";
        public const string _DescuentoFondo = "DescuentoFondo";
        public const string _DescuentoSalud = "DescuentoSalud";
        public const string _DescuentoRemu = "DescuentoRemu";
        public const string _PorcentajeDetraccionRegContabCabe = "PorcentajeDetraccionRegContabCabe";
        public const string _ImporteDetraccionRegContabCabe = "ImporteDetraccionRegContabCabe";
        public const string _CCodigoBienesYServicios = "CCodigoBienesYServicios";
        public const string _Exporta = "Exporta";
        public const string _EstadoRegistro = "EstadoRegistro";
        public const string _EliminadoRegistro = "EliminadoRegistro";
        public const string _UsuarioAgrega = "CodigoUsuarioAgrega";
        public const string _NombreUsuarioAgrega = "NombreUsuarioAgrega";
        public const string _FechaAgrega = "FechaAgrega";
        public const string _UsuarioModifica = "CodigoUsuarioModifica";
        public const string _NombreUsuarioModifica = "NombreUsuarioModifica";
        public const string _FechaModifica = "FechaModifica";


        public string ClaveObjeto { get; set; }
        public string ClaveRegContabCabe { get; set; }
        public string CodigoEmpresa { get; set; }
        public string PeriodoRegContabCabe { get; set; }
        public string CodigoOrigen { get; set; }
        public string CodigoFile { get; set; }
        public string CorrelativoRegContabCabe { get; set; }
        public string NumeroVoucherRegContabCabe { get; set; }
        public string UltimoCorrelativo { get; set; }
        public string MonedaVoucherRegContabCabe { get; set; }
        public string DiaVoucherRegContabCabe { get; set; }
        public string FechaVoucherRegContabCabe { get; set; }
        public string CodigoAuxiliar { get; set; }
        public string CModoCompra { get; set; }
        public string CTipoCompra { get; set; }
        public string TipoDocumento { get; set; }
        public string SerieDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string FechaDocumento { get; set; }
        public string FechaVencimiento { get; set; } = DateTime.Now.ToString();
        public string MonedaDocumento { get; set; }
        public string TipoDocumento1 { get; set; }
        public string SerieDocumento1 { get; set; }
        public string NumeroDocumento1 { get; set; }
        public string FechaDocumento1 { get; set; } = DateTime.Now.ToString();
        public string MonedaDocumento1 { get; set; }
        public decimal VentaTipoCambio { get; set; }
        public decimal VentaEurTipoCambio { get; set; } = 0;
        public decimal IgvPar { get; set; }
        public string CAplicaIgv { get; set; }
        public string CAplicaInafecto { get; set; }
        public decimal ValorVtaRegContabCabe { get; set; }
        public decimal IgvRegContabCabe { get; set; }
        public decimal ExoneradoRegContabCabe { get; set; }
        public decimal InafectoRegContabCabe { get; set; }
        public decimal PrecioVtaRegContabCabe { get; set; }

        public decimal IgvSolRegContabCabe { get; set; }
        public decimal ExoneradoSolRegContabCabe { get; set; }
        public decimal InafectoSolRegContabCabe { get; set; }
        public decimal PrecioVtaSolRegContabCabe { get; set; }
        public string GlosaRegContabCabe { get; set; }
        public string DetraccionRegContabCabe { get; set; }
        public string NumeroPapeletaRegContabCabe { get; set; }
        public string FechaDetraccionRegContabCabe { get; set; } = DateTime.Now.ToString();
        public string CodigoCuentaBanco { get; set; }
        public string CAplicaRetencion { get; set; }
        public decimal TotalHonorario { get; set; }
        public decimal RetencionRegContabCabe { get; set; }
        public decimal PagoHonorario { get; set; }
        public decimal ImporteRegContabCabe { get; set; }
        public decimal ImporteSolRegContabCabe { get; set; }
        public string CodigoModoPago { get; set; }
        public string GiradoPagoRegContabCabe { get; set; }
        public string CartaRegContabCabe { get; set; }
        public string DescripcionRegContabCabe { get; set; }
        public string VoucherIngresoRegContabCabe { get; set; }
        public decimal SumaDebeRegContabCabe { get; set; } = 0;
        public decimal SumaHaberRegContabCabe { get; set; } = 0;
        public string CodigoIngEgr { get; set; } = string.Empty;
        public string ModoCompra { get; set; } = string.Empty;
        public string FlagDescuentoRegcontabCabe { get; set; } = string.Empty;
        public string CodigoAfp { get; set; } = string.Empty;
        public decimal ImporteDescuentoRegContabCabe { get; set; } = 0;
        public decimal DescuentoFondo { get; set; } = 0;
        public decimal DescuentoSalud { get; set; } = 0;
        public decimal DescuentoRemu { get; set; } = 0;
        public decimal PorcentajeDetraccionRegContabCabe { get; set; } = 0;
        public decimal ImporteDetraccionRegContabCabe { get; set; } = 0;
        public string CCodigoBienesYServicios { get; set; } = string.Empty;
        public string Exporta { get; set; } = string.Empty;
        public string EstadoRegistro { get; set; } = string.Empty;
        public string EliminadoRegistro { get; set; } = string.Empty;
        public string ClaveIngresoRegContabCabe { get; set; }
        public string EstadoRegContabCabe { get; set; }
        public string UsuarioAgrega { get; set; }
        public string NombreUsuarioAgrega { get; set; }
        public DateTime FechaAgrega { get; set; }
        public string UsuarioModifica { get; set; }
        public string NombreUsuarioModifica { get; set; }
        public DateTime FechaModifica { get; set; }
        private Adicional _Adicionales = new Adicional();

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
