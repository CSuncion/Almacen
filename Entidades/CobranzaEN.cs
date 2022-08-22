using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class CobranzaEN
    {
        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string CorCob = "CorrelativoCobranza";
        public const string FecPagCuo = "FechaPagoCuota";
        public const string FecCobCuo = "FechaCobranzaCuota";
        public const string FecCob = "FechaCobranza";
        public const string AnoCob = "AnoCobranza";
        public const string CMesCob = "CMesCobranza";
        public const string NMesCob = "NMesCobranza";
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
        public const string FecDepCob = "FechaDepositoCobranza";
        public const string ImpCob = "ImporteCobranza";
        public const string MonDesCob = "MontoDescuentoCobranza";
        public const string MonMorCob = "MontoMoraCobranza";
        public const string MonProCob = "MontoProtestoCobranza";
        public const string MonOtrCob = "MontoOtrosCobranza";
        public const string MonaCobCob = "MontoaCobrarCobranza";
        public const string MonCobCob = "MontoCobradoCobranza";
        public const string CForCobCob = "CFormaCobroCobranza";
        public const string NForCobCob = "NFormaCobroCobranza";
        public const string CModCobCob = "CModoCobroCobranza";
        public const string NModCobCob = "NModoCobroCobranza";
        public const string MonDolCob = "MontoDolaresCobranza";
        public const string MonSolCob = "MontoSolesCobranza";
        public const string TipCamCob = "TipoCambioCobranza";
        public const string CLugCob = "CLugarCobranza";
        public const string NLugCob = "NLugarCobranza";
        public const string ObsCob = "ObservacionCobranza";
        public const string ClaCom = "ClaveComprobante";
        public const string ClaComRetLet = "ClaveComprobanteRetLet";
        public const string ClaCtaBco = "ClaveCuentaBanco";
        public const string CodCueBco = "CodigoCuentaBanco";
        public const string CodBco = "CodigoBanco";
        public const string NomBco = "NombreBanco";
        public const string AgeCtaBco = "AgenciaCuentaBanco";
        public const string NumCtaBco = "NumeroCuentaBanco";
        public const string NMonCtaBco = "NMonedaCuentaBanco";
        public const string CTipCob = "CTipoCobranza";
        public const string NTipCob = "NTipoCobranza";
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
        public const string MonComBcoCob = "MontoComisionBcoCobranza";
        public const string ClaNoIde = "ClaveNoIdentificado";
        public const string TipDoc = "TipoDocumento";
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string ClaVou = "ClaveVoucher";
        public const string CorVou = "CorrelativoVoucher";
        public const string MonVou = "MontoVoucher";
        public const string CuoPagCob = "CuotaPagadaCobranza";
        public const string MorPagCob = "MoraPagadaCobranza";
        public const string CuoPenAnt = "CuotaPendienteAnterior";
        public const string MorAnt = "MoraAnterior";
        public const string MorPenAnt = "MoraPendienteAnterior";
        public const string CGenMorFijAnt = "CGeneroMoraFijaAnterior";
        public const string NGenMorFijAnt = "NGeneroMoraFijaAnterior";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CorrelativoCobranza = string.Empty;
        private string _FechaPagoCuota = string.Empty;
        private string _FechaCobranzaCuota = string.Empty;
        private string _FechaCobranza = string.Empty;
        private string _AnoCobranza = string.Empty;
        private string _CMesCobranza = string.Empty;
        private string _NMesCobranza = string.Empty;
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
        private string _FechaDepositoCobranza = string.Empty;
        private decimal _ImporteCobranza = 0;
        private decimal _MontoDescuentoCobranza = 0;
        private decimal _MontoMoraCobranza = 0;
        private decimal _MontoProtestoCobranza = 0;
        private decimal _MontoOtrosCobranza = 0;
        private decimal _MontoaCobrarCobranza = 0;
        private decimal _MontoCobradoCobranza = 0;
        private string _CFormaCobroCobranza = "1";
        private string _NFormaCobroCobranza = "Total";
        private string _CModoCobroCobranza = "1";
        private string _NModoCobroCobranza = "Dolares";
        private decimal _MontoDolaresCobranza = 0;
        private decimal _MontoSolesCobranza = 0;
        private decimal _TipoCambioCobranza = 1;
        private string _CLugarCobranza = string.Empty;
        private string _NLugarCobranza = string.Empty;
        private string _ObservacionCobranza = string.Empty;
        private string _ClaveComprobante = string.Empty;
        private string _ClaveComprobanteRetLet = string.Empty;
        private string _ClaveCuentaBanco = string.Empty;
        private string _CodigoCuentaBanco = string.Empty;
        private string _CodigoBanco = string.Empty;
        private string _NombreBanco = string.Empty;
        private string _AgenciaCuentaBanco = string.Empty;
        private string _NumeroCuentaBanco = string.Empty;
        private string _NMonedaCuentaBanco = string.Empty;
        private string _CTipoCobranza = "0";
        private string _NTipoCobranza = "De Letra";
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
        private decimal _MontoComisionBcoCobranza = 0;
        private string _ClaveNoIdentificado = string.Empty;
        private string _TipoDocumento = string.Empty;
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _ClaveVoucher = string.Empty;
        private string _CorrelativoVoucher = string.Empty;
        private decimal _MontoVoucher = 0;
        private decimal _CuotaPagadaCobranza = 0;
        private decimal _MoraPagadaCobranza = 0;
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

        public string CorrelativoCobranza
        {
            get { return this._CorrelativoCobranza; }
            set { this._CorrelativoCobranza = value; }
        }

        public string FechaPagoCuota
        {
            get { return this._FechaPagoCuota; }
            set { this._FechaPagoCuota = value; }
        }

        public string FechaCobranzaCuota
        {
            get { return this._FechaCobranzaCuota; }
            set { this._FechaCobranzaCuota = value; }
        }

        public string FechaCobranza
        {
            get { return this._FechaCobranza; }
            set { this._FechaCobranza = value; }
        }

        public string AnoCobranza
        {
            get { return this._AnoCobranza; }
            set { this._AnoCobranza = value; }
        }

        public string CMesCobranza
        {
            get { return this._CMesCobranza; }
            set { this._CMesCobranza = value; }
        }

        public string NMesCobranza
        {
            get { return this._NMesCobranza; }
            set { this._NMesCobranza = value; }
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

        public string FechaDepositoCobranza
        {
            get { return this._FechaDepositoCobranza; }
            set { this._FechaDepositoCobranza = value; }
        }

        public decimal ImporteCobranza
        {
            get { return this._ImporteCobranza; }
            set { this._ImporteCobranza = value; }
        }

        public decimal MontoDescuentoCobranza
        {
            get { return this._MontoDescuentoCobranza; }
            set { this._MontoDescuentoCobranza = value; }
        }

        public decimal MontoMoraCobranza
        {
            get { return this._MontoMoraCobranza; }
            set { this._MontoMoraCobranza = value; }
        }

        public decimal MontoProtestoCobranza
        {
            get { return this._MontoProtestoCobranza; }
            set { this._MontoProtestoCobranza = value; }
        }

        public decimal MontoOtrosCobranza
        {
            get { return this._MontoOtrosCobranza; }
            set { this._MontoOtrosCobranza = value; }
        }

        public decimal MontoaCobrarCobranza
        {
            get { return this._MontoaCobrarCobranza; }
            set { this._MontoaCobrarCobranza = value; }
        }

        public decimal MontoCobradoCobranza
        {
            get { return this._MontoCobradoCobranza; }
            set { this._MontoCobradoCobranza = value; }
        }

        public decimal MontoComisionBcoCobranza
        {
            get { return this._MontoComisionBcoCobranza; }
            set { this._MontoComisionBcoCobranza = value; }
        }

        public string CFormaCobroCobranza
        {
            get { return this._CFormaCobroCobranza; }
            set { this._CFormaCobroCobranza = value; }
        }

        public string NFormaCobroCobranza
        {
            get { return this._NFormaCobroCobranza; }
            set { this._NFormaCobroCobranza = value; }
        }

        public string CModoCobroCobranza
        {
            get { return this._CModoCobroCobranza; }
            set { this._CModoCobroCobranza = value; }
        }

        public string NModoCobroCobranza
        {
            get { return this._NModoCobroCobranza; }
            set { this._NModoCobroCobranza = value; }
        }

        public decimal MontoDolaresCobranza
        {
            get { return this._MontoDolaresCobranza; }
            set { this._MontoDolaresCobranza = value; }
        }

        public decimal MontoSolesCobranza
        {
            get { return this._MontoSolesCobranza; }
            set { this._MontoSolesCobranza = value; }
        }

        public decimal TipoCambioCobranza
        {
            get { return this._TipoCambioCobranza; }
            set { this._TipoCambioCobranza = value; }
        }

        public string CLugarCobranza
        {
            get { return this._CLugarCobranza; }
            set { this._CLugarCobranza = value; }
        }

        public string NLugarCobranza
        {
            get { return this._NLugarCobranza; }
            set { this._NLugarCobranza = value; }
        }

        public string ObservacionCobranza
        {
            get { return this._ObservacionCobranza; }
            set { this._ObservacionCobranza = value; }
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
               
        public string CTipoCobranza
        {
            get { return this._CTipoCobranza; }
            set { this._CTipoCobranza = value; }
        }

        public string NTipoCobranza
        {
            get { return this._NTipoCobranza; }
            set { this._NTipoCobranza = value; }
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

        public decimal CuotaPagadaCobranza
        {
            get { return this._CuotaPagadaCobranza; }
            set { this._CuotaPagadaCobranza = value; }
        }

        public decimal MoraPagadaCobranza
        {
            get { return this._MoraPagadaCobranza; }
            set { this._MoraPagadaCobranza = value; }
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



    }
}
