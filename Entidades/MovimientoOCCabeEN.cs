using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class MovimientoOCCabeEN
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaMovCab = "ClaveMovimientoCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string PerMovCab = "PeriodoMovimientoCabe";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodTipOpe = "CodigoTipoOperacion";
        public const string DesTipOpe = "DescripcionTipoOperacion";
        public const string CClaTipOpe = "CClaseTipoOperacion";
        public const string NClaTipOpe = "NClaseTipoOperacion";
        public const string CCalPrePro = "CCalculaPrecioPromedio";
        public const string CConUni = "CConversionUnidad";
        public const string NumMovCab = "NumeroMovimientoCabe";
        public const string FecMovCab = "FechaMovimientoCabe";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string CodPer = "CodigoPersonal";
        public const string NomPer = "NombrePersonal";
        public const string CodPerAut = "CodigoPersonalAutoriza";
        public const string NomPerAut = "NombrePersonalAutoriza";
        public const string CodPerRec = "CodigoPersonalRecibe";
        public const string NomPerRec = "NombrePersonalRecibe";
        public const string OrdCom = "OrdenCompra";
        public const string GuiRem = "GuiaRemision";
        public const string CTipDoc = "CTipoDocumento";
        public const string NTipDoc = "NTipoDocumento";
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string FecDoc = "FechaDocumento";
        public const string IgvPor = "IgvPorcentaje";
        public const string ValVtaMovCab = "ValorVtaMovimientoCabe";
        public const string IgvMovCab = "IgvMovimientoCabe";
        public const string ExoMovCab = "ExoneradoMovimientoCabe";
        public const string PreVtaMovCab = "PrecioVtaMovimientoCabe";
        public const string MonTotMovCab = "MontoTotalMovimientoCabe";
        public const string GloMovCab = "GlosaMovimientoCabe";
        public const string ClaIngMovCab = "ClaveIngresoMovimientoCabe";
        public const string ClaProDet = "ClaveProduccionDeta";
        public const string CTipDes = "CTipoDescarga";
        public const string COriVenCre = "COrigenVentanaCreacion";
        public const string NOriVenCre = "NOrigenVentanaCreacion";
        public const string CosFleMovCab = "CostoFleteMovimientoCabe";
        public const string CCodMon = "CCodigoMoneda";
        public const string NCodMon = "NCodigoMoneda";
        public const string ClaEnc = "ClaveEncajado";
        public const string ClaProProTer = "ClaveProduccionProTer";
        public const string DetProDetAdi = "DetalleProduccionDetaAdicional";
        public const string ClaProTerParEmp = "ClaveProduccionProTerParteEmpaquetado";
        public const string TipCam = "TipoCambio";
        public const string CEstMovCab = "CEstadoMovimientoCabe";
        public const string NEstMovCab = "NEstadoMovimientoCabe";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
        public const string CorreoAux = "CorreoAuxiliar";
        public const string FlagEnvMov = "FlagEnviadoMovimientoCabe";
        public const string EstPag = "EstadoPago";
        public const string NEstPag = "NEstadoPago";
        public const string DirAux = "DireccionAuxiliar";
        public const string MonTot = "MontoTotal";
        public const string MonPen = "MontoTotalPendientePago";
        public const string FlgCrdSol = "FlagCreadoxSolicitud";
        public const string FlgExpCon = "FlagExportadoConta";
        public const string ClaSolCabPed = "ClaveSolicitudPedidoCabe";
        public const string xCTipoServicio = "CTipoServicio";
        public const string xNTipoServicio = "NTipoServicio";
        public const string xPlazoEntrega = "PlazoEntrega";
        public const string xCondiciones = "Condiciones";
        public const string xGarantia = "Garantia";
        public const string xCGarantia = "CGarantia";
        public const string xNGarantia = "NGarantia";
        public const string xValidezCotizacion = "ValidezCotizacion";
        public const string xFechaValidezCotizacion = "FechaValidezCotizacion";
        public const string xPrecioMaterialAccesorioOrdenServicio = "PrecioMaterialAccesorioOrdenServicio";
        public const string xCFormaPago = "CFormaPago";
        public const string xNFormaPago = "NFormaPago";
        public const string xFlagEnviadoMovimientoOCCabe = "FlagEnviadoMovimientoOCCabe";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveMovimientoCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _PeriodoMovimientoCabe = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoTipoOperacion = string.Empty;
        private string _DescripcionTipoOperacion = string.Empty;
        private string _CClaseTipoOperacion = string.Empty;
        private string _NClaseTipoOperacion = string.Empty;
        private string _CCalculaPrecioPromedio = string.Empty;
        private string _CConversionUnidad = "0";
        private string _NumeroMovimientoCabe = string.Empty;
        private string _FechaMovimientoCabe = string.Empty;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _CodigoPersonal = string.Empty;
        private string _NombrePersonal = string.Empty;
        private string _CodigoPersonalAutoriza = string.Empty;
        private string _NombrePersonalAutoriza = string.Empty;
        private string _CodigoPersonalRecibe = string.Empty;
        private string _NombrePersonalRecibe = string.Empty;
        private string _OrdenCompra = string.Empty;
        private string _GuiaRemision = string.Empty;
        private string _CTipoDocumento = string.Empty;
        private string _NTipoDocumento = string.Empty;
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _FechaDocumento = string.Empty;
        private decimal _IgvPorcentaje = 0;
        private decimal _ValorVtaMovimientoCabe = 0;
        private decimal _IgvMovimientoCabe = 0;
        private decimal _ExoneradoMovimientoCabe = 0;
        private decimal _PrecioVtaMovimientoCabe = 0;
        private decimal _MontoTotalMovimientoCabe = 0;
        private string _GlosaMovimientoCabe = string.Empty;
        private string _ClaveIngresoMovimientoCabe = string.Empty;
        private string _ClaveProduccionDeta = string.Empty;
        private string _CTipoDescarga = string.Empty;
        private string _COrigenVentanaCreacion = string.Empty;
        private string _NOrigenVentanaCreacion = string.Empty;
        private decimal _CostoFleteMovimientoCabe = 0;
        private string _CCodigoMoneda = "0";
        private string _NCodigoMoneda = string.Empty;
        private string _ClaveEncajado = string.Empty;
        private string _ClaveProduccionProTer = string.Empty;
        private string _DetalleProduccionDetaAdicional = string.Empty;
        private string _ClaveProduccionProTerParteEmpaquetado = string.Empty;
        private decimal _TipoCambio = 0;
        private string _CEstadoMovimientoCabe = "1";
        private string _NEstadoMovimientoCabe = "Activado";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();
        private bool _VerdadFalso = false;
        private string _CorreoAuxiliar = string.Empty;
        private bool _FlagEnviadoMovimientoCabe = false;
        private string _CPermitir = "1";
        private string _EstadoPago = string.Empty;
        private string _NEstadoPago = string.Empty;
        private string _DireccionAuxiliar = string.Empty;
        private decimal _MontoTotal = 0;
        private decimal _MontoPendiente = 0;
        private int _FlagCreadoxSolicitud = 0;
        private int _FlagExportadoConta = 0;
        private string _ClaveSolicitudPedidoCabe = string.Empty;
        private string _CTipoServicio = string.Empty;
        private string _NTipoServicio = string.Empty;
        private string _PlazoEntrega = string.Empty;
        private string _Condiciones = string.Empty;
        private int _Garantia = 0;
        private string _CGarantia = string.Empty;
        private string _NGarantia = string.Empty;
        private int _ValidezCotizacion = 0;
        private string _FechaValidezCotizacion = string.Empty;
        private decimal _PrecioMaterialAccesorioOrdenServicio = 0;
        private string _CFormaPago = string.Empty;
        private string _NFormaPago = string.Empty;
        private bool _FlagEnviadoMovimientoOCCabe = false;

        //propiedades
        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveMovimientoCabe
        {
            get { return _ClaveMovimientoCabe; }
            set { _ClaveMovimientoCabe = value; }
        }

        public string CodigoEmpresa
        {
            get { return _CodigoEmpresa; }
            set { _CodigoEmpresa = value; }
        }

        public string NombreEmpresa
        {
            get { return _NombreEmpresa; }
            set { _NombreEmpresa = value; }
        }

        public string PeriodoMovimientoCabe
        {
            get { return _PeriodoMovimientoCabe; }
            set { _PeriodoMovimientoCabe = value; }
        }

        public string CodigoAlmacen
        {
            get { return _CodigoAlmacen; }
            set { _CodigoAlmacen = value; }
        }

        public string DescripcionAlmacen
        {
            get { return _DescripcionAlmacen; }
            set { _DescripcionAlmacen = value; }
        }

        public string CodigoTipoOperacion
        {
            get { return _CodigoTipoOperacion; }
            set { _CodigoTipoOperacion = value; }
        }

        public string DescripcionTipoOperacion
        {
            get { return _DescripcionTipoOperacion; }
            set { _DescripcionTipoOperacion = value; }
        }

        public string CClaseTipoOperacion
        {
            get { return _CClaseTipoOperacion; }
            set { _CClaseTipoOperacion = value; }
        }

        public string NClaseTipoOperacion
        {
            get { return _NClaseTipoOperacion; }
            set { _NClaseTipoOperacion = value; }
        }

        public string CCalculaPrecioPromedio
        {
            get { return _CCalculaPrecioPromedio; }
            set { _CCalculaPrecioPromedio = value; }
        }

        public string CConversionUnidad
        {
            get { return _CConversionUnidad; }
            set { _CConversionUnidad = value; }
        }

        public string NumeroMovimientoCabe
        {
            get { return _NumeroMovimientoCabe; }
            set { _NumeroMovimientoCabe = value; }
        }

        public string FechaMovimientoCabe
        {
            get { return _FechaMovimientoCabe; }
            set { _FechaMovimientoCabe = value; }
        }

        public string CodigoAuxiliar
        {
            get { return _CodigoAuxiliar; }
            set { _CodigoAuxiliar = value; }
        }

        public string DescripcionAuxiliar
        {
            get { return _DescripcionAuxiliar; }
            set { _DescripcionAuxiliar = value; }
        }

        public string CodigoPersonal
        {
            get { return _CodigoPersonal; }
            set { _CodigoPersonal = value; }
        }

        public string NombrePersonal
        {
            get { return _NombrePersonal; }
            set { _NombrePersonal = value; }
        }

        public string CodigoPersonalAutoriza
        {
            get { return _CodigoPersonalAutoriza; }
            set { _CodigoPersonalAutoriza = value; }
        }

        public string NombrePersonalAutoriza
        {
            get { return _NombrePersonalAutoriza; }
            set { _NombrePersonalAutoriza = value; }
        }

        public string CodigoPersonalRecibe
        {
            get { return _CodigoPersonalRecibe; }
            set { _CodigoPersonalRecibe = value; }
        }

        public string NombrePersonalRecibe
        {
            get { return _NombrePersonalRecibe; }
            set { _NombrePersonalRecibe = value; }
        }

        public string OrdenCompra
        {
            get { return _OrdenCompra; }
            set { _OrdenCompra = value; }
        }

        public string GuiaRemision
        {
            get { return _GuiaRemision; }
            set { _GuiaRemision = value; }
        }

        public string CTipoDocumento
        {
            get { return _CTipoDocumento; }
            set { _CTipoDocumento = value; }
        }

        public string NTipoDocumento
        {
            get { return _NTipoDocumento; }
            set { _NTipoDocumento = value; }
        }

        public string SerieDocumento
        {
            get { return _SerieDocumento; }
            set { _SerieDocumento = value; }
        }

        public string NumeroDocumento
        {
            get { return _NumeroDocumento; }
            set { _NumeroDocumento = value; }
        }

        public string FechaDocumento
        {
            get { return _FechaDocumento; }
            set { _FechaDocumento = value; }
        }

        public decimal IgvPorcentaje
        {
            get { return _IgvPorcentaje; }
            set { _IgvPorcentaje = value; }
        }

        public decimal ValorVtaMovimientoCabe
        {
            get { return _ValorVtaMovimientoCabe; }
            set { _ValorVtaMovimientoCabe = value; }
        }

        public decimal IgvMovimientoCabe
        {
            get { return _IgvMovimientoCabe; }
            set { _IgvMovimientoCabe = value; }
        }

        public decimal ExoneradoMovimientoCabe
        {
            get { return _ExoneradoMovimientoCabe; }
            set { _ExoneradoMovimientoCabe = value; }
        }

        public decimal PrecioVtaMovimientoCabe
        {
            get { return _PrecioVtaMovimientoCabe; }
            set { _PrecioVtaMovimientoCabe = value; }
        }

        public decimal MontoTotalMovimientoCabe
        {
            get { return _MontoTotalMovimientoCabe; }
            set { _MontoTotalMovimientoCabe = value; }
        }

        public string GlosaMovimientoCabe
        {
            get { return _GlosaMovimientoCabe; }
            set { _GlosaMovimientoCabe = value; }
        }

        public string ClaveIngresoMovimientoCabe
        {
            get { return _ClaveIngresoMovimientoCabe; }
            set { _ClaveIngresoMovimientoCabe = value; }
        }

        public string ClaveProduccionDeta
        {
            get { return _ClaveProduccionDeta; }
            set { _ClaveProduccionDeta = value; }
        }

        public string CTipoDescarga
        {
            get { return _CTipoDescarga; }
            set { _CTipoDescarga = value; }
        }

        public string COrigenVentanaCreacion
        {
            get { return _COrigenVentanaCreacion; }
            set { _COrigenVentanaCreacion = value; }
        }

        public string NOrigenVentanaCreacion
        {
            get { return _NOrigenVentanaCreacion; }
            set { _NOrigenVentanaCreacion = value; }
        }

        public string ClaveEncajado
        {
            get { return _ClaveEncajado; }
            set { _ClaveEncajado = value; }
        }

        public string ClaveProduccionProTer
        {
            get { return _ClaveProduccionProTer; }
            set { _ClaveProduccionProTer = value; }
        }

        public decimal CostoFleteMovimientoCabe
        {
            get { return _CostoFleteMovimientoCabe; }
            set { _CostoFleteMovimientoCabe = value; }
        }

        public string CCodigoMoneda
        {
            get { return _CCodigoMoneda; }
            set { _CCodigoMoneda = value; }
        }

        public string NCodigoMoneda
        {
            get { return _NCodigoMoneda; }
            set { _NCodigoMoneda = value; }
        }

        public string DetalleProduccionDetaAdicional
        {
            get { return _DetalleProduccionDetaAdicional; }
            set { _DetalleProduccionDetaAdicional = value; }
        }

        public string ClaveProduccionProTerParteEmpaquetado
        {
            get { return _ClaveProduccionProTerParteEmpaquetado; }
            set { _ClaveProduccionProTerParteEmpaquetado = value; }
        }
        public decimal TipoCambio
        {
            get { return _TipoCambio; }
            set { _TipoCambio = value; }
        }

        public string CEstadoMovimientoCabe
        {
            get { return _CEstadoMovimientoCabe; }
            set { _CEstadoMovimientoCabe = value; }
        }

        public string NEstadoMovimientoCabe
        {
            get { return _NEstadoMovimientoCabe; }
            set { _NEstadoMovimientoCabe = value; }
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
            get { return _Adicionales; }
            set { _Adicionales = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }

        public string CPermitir
        {
            get { return this._CPermitir; }
            set { this._CPermitir = value; }
        }

        public string CorreoAuxiliar
        {
            get { return _CorreoAuxiliar; }
            set { _CorreoAuxiliar = value; }
        }

        public bool FlagEnviadoMovimientoCabe
        {
            get { return _FlagEnviadoMovimientoCabe; }
            set { _FlagEnviadoMovimientoCabe = value; }
        }

        public string EstadoPago
        {
            get { return _EstadoPago; }
            set { _EstadoPago = value; }
        }

        public string DireccionAuxiliar
        {
            get { return _DireccionAuxiliar; }
            set { _DireccionAuxiliar = value; }
        }

        public string NEstadoPago
        {
            get { return _NEstadoPago; }
            set { _NEstadoPago = value; }
        }

        public decimal MontoTotal
        {
            get { return _MontoTotal; }
            set { _MontoTotal = value; }
        }

        public decimal MontoPendiente
        {
            get { return _MontoPendiente; }
            set { _MontoPendiente = value; }
        }

        public int FlagCreadoxSolicitud
        {
            get { return _FlagCreadoxSolicitud; }
            set { _FlagCreadoxSolicitud = value; }
        }

        public int FlagExportadoConta
        {
            get { return _FlagExportadoConta; }
            set { _FlagExportadoConta = value; }
        }

        public string ClaveSolicitudPedidoCabe
        {
            get { return _ClaveSolicitudPedidoCabe; }
            set { _ClaveSolicitudPedidoCabe = value; }
        }

        public string CTipoServicio
        {
            get { return _CTipoServicio; }
            set { _CTipoServicio = value; }
        }

        public string NTipoServicio
        {
            get { return _NTipoServicio; }
            set { _NTipoServicio = value; }
        }

        public string PlazoEntrega
        {
            get { return _PlazoEntrega; }
            set { _PlazoEntrega = value; }
        }

        public string Condiciones
        {
            get { return _Condiciones; }
            set { _Condiciones = value; }
        }

        public int Garantia
        {
            get { return _Garantia; }
            set { _Garantia = value; }
        }

        public string CGarantia
        {
            get { return _CGarantia; }
            set { _CGarantia = value; }
        }

        public string NGarantia
        {
            get { return _NGarantia; }
            set { _NGarantia = value; }
        }

        public int ValidezCotizacion
        {
            get { return _ValidezCotizacion; }
            set { _ValidezCotizacion = value; }
        }

        public string FechaValidezCotizacion
        {
            get { return _FechaValidezCotizacion; }
            set { _FechaValidezCotizacion = value; }
        }

        public decimal PrecioMaterialAccesorioOrdenServicio
        {
            get { return _PrecioMaterialAccesorioOrdenServicio; }
            set { _PrecioMaterialAccesorioOrdenServicio = value; }
        }

        public string CFormaPago
        {
            get { return _CFormaPago; }
            set { _CFormaPago = value; }
        }

        public string NFormaPago
        {
            get { return _NFormaPago; }
            set { _NFormaPago = value; }
        }

        public bool FlagEnviadoMovimientoOCCabe
        {
            get { return _FlagEnviadoMovimientoOCCabe; }
            set { _FlagEnviadoMovimientoOCCabe = value; }
        }
    }
}
