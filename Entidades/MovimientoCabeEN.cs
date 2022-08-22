using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class MovimientoCabeEN
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
        public const string FlagCalFle = "FlagCalculadoFlete";

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
        private string _NCodigoMoneda = "Sol";
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
        private bool _FlagCalculadoFlete = false;
        private string _CPermitir = "1";

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

        public bool FlagCalculadoFlete
        {
            get { return _FlagCalculadoFlete; }
            set { _FlagCalculadoFlete = value; }
        }
    }
}
