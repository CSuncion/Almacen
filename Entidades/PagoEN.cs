using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class PagoEN
    {
        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string CorPag = "CorrelativoPago";
        public const string FecPagCuo = "FechaPagoCuota";
        public const string FecPag = "FechaPago";
        public const string AnoPag = "AnoPago";
        public const string CMesPag = "CMesPago";
        public const string NMesPag = "NMesPago";
        public const string ClaCuo = "ClaveCuota";
        public const string NumCon = "NumeroContrato";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodPro = "CodigoProyecto";
        public const string NomPro = "NombreProyecto";
        public const string CodUrbPro = "CodigoUrbanizacionProyecto";
        public const string NomUrbPro = "NombreUrbanizacionProyecto";
        public const string FecVenCuo = "FechaVencimientoCuota";
        public const string CodCli = "CodigoCliente";
        public const string NomCli = "NombreCliente";
        public const string MonCuo = "MontoCuota";
        public const string FecDepPag = "FechaDepositoPago";
        public const string ImpPag = "ImportePago";
        public const string MonDesPag = "MontoDescuentoPago";
        public const string MonMorPag = "MontoMoraPago";
        public const string MonProPag = "MontoProtestoPago";
        public const string MonOtrPag = "MontoOtrosPago";
        public const string MonaCobPag = "MontoaCobrarPago";
        public const string MonCobPag = "MontoCobradoPago";
        public const string CForCobPag = "CFormaCobroPago";
        public const string NForCobPag = "NFormaCobroPago";
        public const string CModCobPag = "CModoCobroPago";
        public const string NModCobPag = "NModoCobroPago";
        public const string MonDolPag = "MontoDolaresPago";
        public const string MonSolPag = "MontoSolesPago";
        public const string TipCamPag = "TipoCambioPago";
        public const string CLugPag = "CLugarPago";
        public const string NLugPag = "NLugarPago";
        public const string ObsPag = "ObservacionPago";
        public const string ClaCom = "ClaveComprobante";
        public const string ClaComRetLet = "ClaveComprobanteRetLet";
        public const string ClaCtaBco = "ClaveCuentaBanco";
        public const string CodCueBco = "CodigoCuentaBanco";
        public const string CodBco = "CodigoBanco";
        public const string NomBco = "NombreBanco";
        public const string AgeCtaBco = "AgenciaCuentaBanco";
        public const string NumCtaBco = "NumeroCuentaBanco";
        public const string NMonCtaBco = "NMonedaCuentaBanco";
        public const string CTipPag = "CTipoPago";
        public const string NTipPag = "NTipoPago";
        public const string CForPagLet = "CFormaPagoLetra";
        public const string NForPagLet = "NFormaPagoLetra";
        public const string DifDia = "DiferenciaDias";
        public const string EtaLot = "EtapaLote";
        public const string MzaLot = "ManzanaLote";
        public const string NumLot = "NumeroLote";
        public const string DirAct = "DireccionActual";
        public const string UbiAct = "UbigeoActual";
        public const string DirAnt = "DireccionAnterior";
        public const string UbiAnt = "UbigeoAnterior";
        public const string MonComBcoPag = "MontoComisionBcoPago";
        public const string ClaNoIde = "ClaveNoIdentificado";
        public const string TipDoc = "TipoDocumento";
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string ClaVou = "ClaveVoucher";
        public const string CorVou = "CorrelativoVoucher";
        public const string MonVou = "MontoVoucher";
        public const string CuoPagPag = "CuotaPagadaPago";
        public const string MorPagPag = "MoraPagadaPago";
        public const string CuoPenAnt = "CuotaPendienteAnterior";
        public const string MorAnt = "MoraAnterior";
        public const string MorPenAnt = "MoraPendienteAnterior";
        public const string CGenMorFijAnt = "CGeneroMoraFijaAnterior";
        public const string NGenMorFijAnt = "NGeneroMoraFijaAnterior";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CorrelativoPago = string.Empty;
        private string _FechaPagoCuota = string.Empty;
        private string _FechaPago = string.Empty;
        private string _AnoPago = string.Empty;
        private string _CMesPago = string.Empty;
        private string _NMesPago = string.Empty;
        private string _ClaveCuota = string.Empty;
        private string _NumeroContrato = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoProyecto = string.Empty;
        private string _NombreProyecto = string.Empty;
        private string _CodigoUrbanizacionProyecto = string.Empty;
        private string _NombreUrbanizacionProyecto = string.Empty;
        private string _FechaVencimientoCuota = string.Empty;
        private string _CodigoCliente = string.Empty;
        private string _NombreCliente = string.Empty;
        private decimal _MontoCuota = 0;
        private string _FechaDepositoPago = string.Empty;
        private decimal _ImportePago = 0;
        private decimal _MontoDescuentoPago = 0;
        private decimal _MontoMoraPago = 0;
        private decimal _MontoProtestoPago = 0;
        private decimal _MontoOtrosPago = 0;
        private decimal _MontoaCobrarPago = 0;
        private decimal _MontoCobradoPago = 0;
        private string _CFormaCobroPago = "1";
        private string _NFormaCobroPago = "Total";
        private string _CModoCobroPago = "1";
        private string _NModoCobroPago = "Dolares";
        private decimal _MontoDolaresPago = 0;
        private decimal _MontoSolesPago = 0;
        private decimal _TipoCambioPago = 1;
        private string _CLugarPago = string.Empty;
        private string _NLugarPago = string.Empty;
        private string _ObservacionPago = string.Empty;
        private string _ClaveComprobante = string.Empty;
        private string _ClaveComprobanteRetLet = string.Empty;
        private string _ClaveCuentaBanco = string.Empty;
        private string _CodigoCuentaBanco = string.Empty;
        private string _CodigoBanco = string.Empty;
        private string _NombreBanco = string.Empty;
        private string _AgenciaCuentaBanco = string.Empty;
        private string _NumeroCuentaBanco = string.Empty;
        private string _NMonedaCuentaBanco = string.Empty;
        private string _CTipoPago = "0";
        private string _NTipoPago = "De Letra";
        private string _CFormaPagoLetra = "0";
        private string _NFormaPagoLetra = "Ninguna";
        private int _DiferenciaDias = 0;
        private string _EtapaLote = string.Empty;
        private string _ManzanaLote = string.Empty;
        private string _NumeroLote = string.Empty;
        private string _DireccionActual = string.Empty;
        private string _UbigeoActual = string.Empty;
        private string _DireccionAnterior = string.Empty;
        private string _UbigeoAnterior = string.Empty;
        private decimal _MontoComisionBcoPago = 0;
        private string _ClaveNoIdentificado = string.Empty;
        private string _TipoDocumento = string.Empty;
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _ClaveVoucher = string.Empty;
        private string _CorrelativoVoucher = string.Empty;
        private decimal _MontoVoucher = 0;
        private decimal _CuotaPagadaPago = 0;
        private decimal _MoraPagadaPago = 0;
        private decimal _CuotaPendienteAnterior = 0;
        private decimal _MoraAnterior = 0;
        private decimal _MoraPendienteAnterior = 0;
        private string _CGeneroMoraFijaAnterior = "0";
        private string _NGeneroMoraFijaAnterior = "No";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;

        //propiedades

        public string ClaveNoIdentificado
        {
            get { return this._ClaveNoIdentificado; }
            set { this._ClaveNoIdentificado = value; }
        }

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string CorrelativoPago
        {
            get { return this._CorrelativoPago; }
            set { this._CorrelativoPago = value; }
        }

        public string FechaPagoCuota
        {
            get { return this._FechaPagoCuota; }
            set { this._FechaPagoCuota = value; }
        }

        public string FechaPago
        {
            get { return this._FechaPago; }
            set { this._FechaPago = value; }
        }

        public string AnoPago
        {
            get { return this._AnoPago; }
            set { this._AnoPago = value; }
        }

        public string CMesPago
        {
            get { return this._CMesPago; }
            set { this._CMesPago = value; }
        }

        public string NMesPago
        {
            get { return this._NMesPago; }
            set { this._NMesPago = value; }
        }

        public string ClaveCuota
        {
            get { return this._ClaveCuota; }
            set { this._ClaveCuota = value; }
        }

        public string NumeroContrato
        {
            get { return this._NumeroContrato; }
            set { this._NumeroContrato = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string NombreEmpresa
        {
            get { return this._NombreEmpresa; }
            set { this._NombreEmpresa = value; }
        }

        public string CodigoProyecto
        {
            get { return this._CodigoProyecto; }
            set { this._CodigoProyecto = value; }
        }

        public string NombreProyecto
        {
            get { return this._NombreProyecto; }
            set { this._NombreProyecto = value; }
        }

        public string CodigoUrbanizacionProyecto
        {
            get { return this._CodigoUrbanizacionProyecto; }
            set { this._CodigoUrbanizacionProyecto = value; }
        }

        public string NombreUrbanizacionProyecto
        {
            get { return this._NombreUrbanizacionProyecto; }
            set { this._NombreUrbanizacionProyecto = value; }
        }

        public string FechaVencimientoCuota
        {
            get { return this._FechaVencimientoCuota; }
            set { this._FechaVencimientoCuota = value; }
        }

        public string CodigoCliente
        {
            get { return this._CodigoCliente; }
            set { this._CodigoCliente = value; }
        }

        public string NombreCliente
        {
            get { return this._NombreCliente; }
            set { this._NombreCliente = value; }
        }

        public decimal MontoCuota
        {
            get { return this._MontoCuota; }
            set { this._MontoCuota = value; }
        }

        public string FechaDepositoPago
        {
            get { return this._FechaDepositoPago; }
            set { this._FechaDepositoPago = value; }
        }

        public decimal ImportePago
        {
            get { return this._ImportePago; }
            set { this._ImportePago = value; }
        }

        public decimal MontoDescuentoPago
        {
            get { return this._MontoDescuentoPago; }
            set { this._MontoDescuentoPago = value; }
        }

        public decimal MontoMoraPago
        {
            get { return this._MontoMoraPago; }
            set { this._MontoMoraPago = value; }
        }

        public decimal MontoProtestoPago
        {
            get { return this._MontoProtestoPago; }
            set { this._MontoProtestoPago = value; }
        }

        public decimal MontoOtrosPago
        {
            get { return this._MontoOtrosPago; }
            set { this._MontoOtrosPago = value; }
        }

        public decimal MontoaCobrarPago
        {
            get { return this._MontoaCobrarPago; }
            set { this._MontoaCobrarPago = value; }
        }

        public decimal MontoCobradoPago
        {
            get { return this._MontoCobradoPago; }
            set { this._MontoCobradoPago = value; }
        }

        public decimal MontoComisionBcoPago
        {
            get { return this._MontoComisionBcoPago; }
            set { this._MontoComisionBcoPago = value; }
        }

        public string CFormaCobroPago
        {
            get { return this._CFormaCobroPago; }
            set { this._CFormaCobroPago = value; }
        }

        public string NFormaCobroPago
        {
            get { return this._NFormaCobroPago; }
            set { this._NFormaCobroPago = value; }
        }

        public string CModoCobroPago
        {
            get { return this._CModoCobroPago; }
            set { this._CModoCobroPago = value; }
        }

        public string NModoCobroPago
        {
            get { return this._NModoCobroPago; }
            set { this._NModoCobroPago = value; }
        }

        public decimal MontoDolaresPago
        {
            get { return this._MontoDolaresPago; }
            set { this._MontoDolaresPago = value; }
        }

        public decimal MontoSolesPago
        {
            get { return this._MontoSolesPago; }
            set { this._MontoSolesPago = value; }
        }

        public decimal TipoCambioPago
        {
            get { return this._TipoCambioPago; }
            set { this._TipoCambioPago = value; }
        }

        public string CLugarPago
        {
            get { return this._CLugarPago; }
            set { this._CLugarPago = value; }
        }

        public string NLugarPago
        {
            get { return this._NLugarPago; }
            set { this._NLugarPago = value; }
        }

        public string ObservacionPago
        {
            get { return this._ObservacionPago; }
            set { this._ObservacionPago = value; }
        }

        public string ClaveComprobante
        {
            get { return this._ClaveComprobante; }
            set { this._ClaveComprobante = value; }
        }

        public string ClaveComprobanteRetLet
        {
            get { return this._ClaveComprobanteRetLet; }
            set { this._ClaveComprobanteRetLet = value; }
        }

        public string ClaveCuentaBanco
        {
            get { return this._ClaveCuentaBanco; }
            set { this._ClaveCuentaBanco = value; }
        }

        public string AgenciaCuentaBanco
        {
            get { return this._AgenciaCuentaBanco; }
            set { this._AgenciaCuentaBanco = value; }
        }

        public string NumeroCuentaBanco
        {
            get { return this._NumeroCuentaBanco; }
            set { this._NumeroCuentaBanco = value; }
        }

        public string CodigoCuentaBanco
        {
            get { return this._CodigoCuentaBanco; }
            set { this._CodigoCuentaBanco = value; }
        }

        public string CodigoBanco
        {
            get { return this._CodigoBanco; }
            set { this._CodigoBanco = value; }
        }

        public string NombreBanco
        {
            get { return this._NombreBanco; }
            set { this._NombreBanco = value; }
        }

        public string NMonedaCuentaBanco
        {
            get { return this._NMonedaCuentaBanco; }
            set { this._NMonedaCuentaBanco = value; }
        }

        public string CTipoPago
        {
            get { return this._CTipoPago; }
            set { this._CTipoPago = value; }
        }

        public string NTipoPago
        {
            get { return this._NTipoPago; }
            set { this._NTipoPago = value; }
        }

        public string CFormaPagoLetra
        {
            get { return this._CFormaPagoLetra; }
            set { this._CFormaPagoLetra = value; }
        }

        public string NFormaPagoLetra
        {
            get { return this._NFormaPagoLetra; }
            set { this._NFormaPagoLetra = value; }
        }

        public string EtapaLote
        {
            get { return this._EtapaLote; }
            set { this._EtapaLote = value; }
        }

        public string ManzanaLote
        {
            get { return this._ManzanaLote; }
            set { this._ManzanaLote = value; }
        }

        public string NumeroLote
        {
            get { return this._NumeroLote; }
            set { this._NumeroLote = value; }
        }

        public string DireccionActual
        {
            get { return this._DireccionActual; }
            set { this._DireccionActual = value; }
        }

        public string UbigeoActual
        {
            get { return this._UbigeoActual; }
            set { this._UbigeoActual = value; }
        }

        public string DireccionAnterior
        {
            get { return this._DireccionAnterior; }
            set { this._DireccionAnterior = value; }
        }

        public string UbigeoAnterior
        {
            get { return this._UbigeoAnterior; }
            set { this._UbigeoAnterior = value; }
        }

        public string TipoDocumento
        {
            get { return this._TipoDocumento; }
            set { this._TipoDocumento = value; }
        }

        public string SerieDocumento
        {
            get { return this._SerieDocumento; }
            set { this._SerieDocumento = value; }
        }

        public string NumeroDocumento
        {
            get { return this._NumeroDocumento; }
            set { this._NumeroDocumento = value; }
        }

        public string ClaveVoucher
        {
            get { return this._ClaveVoucher; }
            set { this._ClaveVoucher = value; }
        }

        public string CorrelativoVoucher
        {
            get { return this._CorrelativoVoucher; }
            set { this._CorrelativoVoucher = value; }
        }

        public decimal MontoVoucher
        {
            get { return this._MontoVoucher; }
            set { this._MontoVoucher = value; }
        }

        public decimal CuotaPagadaPago
        {
            get { return this._CuotaPagadaPago; }
            set { this._CuotaPagadaPago = value; }
        }

        public decimal MoraPagadaPago
        {
            get { return this._MoraPagadaPago; }
            set { this._MoraPagadaPago = value; }
        }

        public decimal CuotaPendienteAnterior
        {
            get { return this._CuotaPendienteAnterior; }
            set { this._CuotaPendienteAnterior = value; }
        }

        public decimal MoraAnterior
        {
            get { return this._MoraAnterior; }
            set { this._MoraAnterior = value; }
        }

        public decimal MoraPendienteAnterior
        {
            get { return this._MoraPendienteAnterior; }
            set { this._MoraPendienteAnterior = value; }
        }

        public string CGeneroMoraFijaAnterior
        {
            get { return this._CGeneroMoraFijaAnterior; }
            set { this._CGeneroMoraFijaAnterior = value; }
        }

        public string NGeneroMoraFijaAnterior
        {
            get { return this._NGeneroMoraFijaAnterior; }
            set { this._NGeneroMoraFijaAnterior = value; }
        }

        public string UsuarioAgrega
        {
            get { return this._UsuarioAgrega; }
            set { this._UsuarioAgrega = value; }
        }

        public DateTime FechaAgrega
        {
            get { return this._FechaAgrega; }
            set { this._FechaAgrega = value; }
        }

        public string UsuarioModifica
        {
            get { return this._UsuarioModifica; }
            set { this._UsuarioModifica = value; }
        }

        public DateTime FechaModifica
        {
            get { return this._FechaModifica; }
            set { this._FechaModifica = value; }
        }

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }

        public string CodigoAuxiliar
        {
            get { return this._CodigoAuxiliar; }
            set { this._CodigoAuxiliar = value; }
        }

        public string DescripcionAuxiliar
        {
            get { return this._DescripcionAuxiliar; }
            set { this._DescripcionAuxiliar = value; }
        }
    }
}
