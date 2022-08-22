using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class MovimientoDetaEN
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaMovDet = "ClaveMovimientoDeta";
        public const string ClaMovCab = "ClaveMovimientoCabe";
        public const string CorMovDet = "CorrelativoMovimientoDeta";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string FecMovCab = "FechaMovimientoCabe";
        public const string PerMovCab = "PeriodoMovimientoCabe";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodTipOpe = "CodigoTipoOperacion";
        public const string DesTipOpe = "DescripcionTipoOperacion";
        public const string CClaTipOpe = "CClaseTipoOperacion";
        public const string CCalPrePro = "CCalculaPrecioPromedio";
        public const string CConUni = "CConversionUnidad";
        public const string NumMovCab = "NumeroMovimientoCabe";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string CTipDoc = "CTipoDocumento";
        public const string NTipDoc = "NTipoDocumento";
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string FecDoc = "FechaDocumento";
        public const string CCodMon = "CCodigoMoneda";
        public const string NCodMon = "NCodigoMoneda";
        public const string CodCenCos = "CodigoCentroCosto";
        public const string DesCenCos = "DescripcionCentroCosto";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CEsPro = "CEsProduccion";
        public const string CodTip = "CodigoTipo";
        public const string NomTip = "NombreTipo";
        public const string CEsLot = "CEsLote";
        public const string CEsUniCon = "CEsUnidadConvertida";
        public const string FacCon = "FactorConversion";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CanMovDet = "CantidadMovimientoDeta";
        public const string PreUniMovDet = "PrecioUnitarioMovimientoDeta";
        public const string PreUniDolMovDet = "PrecioUnitarioDolarMovimientoDeta";
        public const string TipCam = "TipoCambio";
        public const string CosMovDet = "CostoMovimientoDeta";
        public const string GloMovDet = "GlosaMovimientoDeta";
        public const string StoAntExi = "StockAnteriorExistencia";
        public const string PreAntExi = "PrecioAnteriorExistencia";
        public const string StoExi = "StockExistencia";
        public const string PreExi = "PrecioExistencia";
        public const string ClaProDet = "ClaveProduccionDeta";
        public const string CTipDes = "CTipoDescarga";
        public const string PreUniPro = "PrecioUnitarioProduccion";
        public const string PreUniCon = "PrecioUnitarioConversion";
        public const string CanCon = "CantidadConversion";
        public const string OrdCom = "OrdenCompra";
        public const string CosFleMovDet = "CostoFleteMovimientoDeta";
        public const string CosFleMovCab = "CostoFleteMovimientoCabe";
        public const string ClaEnc = "ClaveEncajado";
        public const string ClaProProTer = "ClaveProduccionProTer";
        public const string ClaProTerParEmp = "ClaveProduccionProTerParteEmpaquetado";
        public const string CCodAre = "CCodigoArea";
        public const string NCodAre = "NCodigoArea";
        public const string CCodPar = "CCodigoPartida";
        public const string NCodPar = "NCodigoPartida";
        public const string CEstMovDet = "CEstadoMovimientoDeta";
        public const string NEstMovDet = "NEstadoMovimientoDeta";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveMovimientoDeta = string.Empty;
        private string _ClaveMovimientoCabe = string.Empty;
        private string _CorrelativoMovimientoDeta = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _FechaMovimientoCabe = string.Empty;
        private string _PeriodoMovimientoCabe = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoTipoOperacion = string.Empty;
        private string _DescripcionTipoOperacion = string.Empty;
        private string _CClaseTipoOperacion = string.Empty;
        private string _CCalculaPrecioPromedio = string.Empty;
        private string _CConversionUnidad = "0";
        private string _NumeroMovimientoCabe = string.Empty;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _CTipoDocumento = string.Empty;
        private string _NTipoDocumento = string.Empty;
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _FechaDocumento = string.Empty;
        private string _CCodigoMoneda = "0";
        private string _NCodigoMoneda = "Sol";
        private string _CodigoCentroCosto = string.Empty;
        private string _DescripcionCentroCosto = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _CEsProduccion = "0";
        private string _CodigoTipo = string.Empty;
        private string _NombreTipo = string.Empty;
        private string _CEsLote = "0";
        private string _CEsUnidadConvertida = "0";
        private decimal _FactorConversion = 0;
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private decimal _CantidadMovimientoDeta = 0;
        private decimal _PrecioUnitarioMovimientoDeta = 0;
        private decimal _PrecioUnitarioDolarMovimientoDeta = 0;
        private decimal _TipoCambio = 1;
        private decimal _CostoMovimientoDeta = 0;
        private string _GlosaMovimientoDeta = string.Empty;
        private decimal _StockAnteriorExistencia = 0;
        private decimal _PrecioAnteriorExistencia = 0;
        private decimal _StockExistencia = 0;
        private decimal _PrecioExistencia = 0;
        private string _ClaveProduccionDeta = string.Empty;
        private string _CTipoDescarga = string.Empty;
        private decimal _PrecioUnitarioProduccion = 0;
        private decimal _PrecioUnitarioConversion = 0;
        private decimal _CantidadConversion = 0;
        private string _OrdenCompra = string.Empty;
        private decimal _CostoFleteMovimientoDeta = 0;
        private decimal _CostoFleteMovimientoCabe = 0;
        private string _ClaveEncajado = string.Empty;
        private string _ClaveProduccionProTer = string.Empty;
        private string _ClaveProduccionProTerParteEmpaquetado = string.Empty;
        private string _CCodigoArea = string.Empty;
        private string _NCodigoArea = string.Empty;
        private string _CCodigoPartida = string.Empty;
        private string _NCodigoPartida = string.Empty;
        private string _CEstadoMovimientoDeta = "1";
        private string _NEstadoMovimientoDeta = "Activado";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();
        


        //propiedades
        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveMovimientoDeta
        {
            get { return _ClaveMovimientoDeta; }
            set { _ClaveMovimientoDeta = value; }
        }

        public string ClaveMovimientoCabe
        {
            get { return _ClaveMovimientoCabe; }
            set { _ClaveMovimientoCabe = value; }
        }

        public string CorrelativoMovimientoDeta
        {
            get { return _CorrelativoMovimientoDeta; }
            set { _CorrelativoMovimientoDeta = value; }
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

        public string FechaMovimientoCabe
        {
            get { return _FechaMovimientoCabe; }
            set { _FechaMovimientoCabe = value; }
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

        public string CodigoCentroCosto
        {
            get { return _CodigoCentroCosto; }
            set { _CodigoCentroCosto = value; }
        }

        public string DescripcionCentroCosto
        {
            get { return _DescripcionCentroCosto; }
            set { _DescripcionCentroCosto = value; }
        }

        public string CodigoExistencia
        {
            get { return _CodigoExistencia; }
            set { _CodigoExistencia = value; }
        }

        public string DescripcionExistencia
        {
            get { return _DescripcionExistencia; }
            set { _DescripcionExistencia = value; }
        }

        public string CEsProduccion
        {
            get { return _CEsProduccion; }
            set { _CEsProduccion = value; }
        }

        public string CodigoTipo
        {
            get { return _CodigoTipo; }
            set { _CodigoTipo = value; }
        }

        public string NombreTipo
        {
            get { return _NombreTipo; }
            set { _NombreTipo = value; }
        }

        public string CEsLote
        {
            get { return _CEsLote; }
            set { _CEsLote = value; }
        }

        public string CEsUnidadConvertida
        {
            get { return _CEsUnidadConvertida; }
            set { _CEsUnidadConvertida = value; }
        }

        public decimal FactorConversion
        {
            get { return _FactorConversion; }
            set { _FactorConversion = value; }
        }

        public string CodigoUnidadMedida
        {
            get { return _CodigoUnidadMedida; }
            set { _CodigoUnidadMedida = value; }
        }

        public string NombreUnidadMedida
        {
            get { return _NombreUnidadMedida; }
            set { _NombreUnidadMedida = value; }
        }

        public decimal CantidadMovimientoDeta
        {
            get { return _CantidadMovimientoDeta; }
            set { _CantidadMovimientoDeta = value; }
        }

        public decimal PrecioUnitarioMovimientoDeta
        {
            get { return _PrecioUnitarioMovimientoDeta; }
            set { _PrecioUnitarioMovimientoDeta = value; }
        }
        public decimal PrecioUnitarioDolarMovimientoDeta
        {
            get { return _PrecioUnitarioDolarMovimientoDeta; }
            set { _PrecioUnitarioDolarMovimientoDeta = value; }
        }
        public decimal TipoCambio
        {
            get { return _TipoCambio; }
            set { _TipoCambio = value; }
        }

        public decimal CostoMovimientoDeta
        {
            get { return _CostoMovimientoDeta; }
            set { _CostoMovimientoDeta = value; }
        }

        public string GlosaMovimientoDeta
        {
            get { return _GlosaMovimientoDeta; }
            set { _GlosaMovimientoDeta = value; }
        }

        public decimal StockAnteriorExistencia
        {
            get { return _StockAnteriorExistencia; }
            set { _StockAnteriorExistencia = value; }
        }

        public decimal PrecioAnteriorExistencia
        {
            get { return _PrecioAnteriorExistencia; }
            set { _PrecioAnteriorExistencia = value; }
        }

        public decimal StockExistencia
        {
            get { return _StockExistencia; }
            set { _StockExistencia = value; }
        }

        public decimal PrecioExistencia
        {
            get { return _PrecioExistencia; }
            set { _PrecioExistencia = value; }
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

        public decimal PrecioUnitarioProduccion
        {
            get { return _PrecioUnitarioProduccion; }
            set { _PrecioUnitarioProduccion = value; }
        }

        public decimal PrecioUnitarioConversion
        {
            get { return _PrecioUnitarioConversion; }
            set { _PrecioUnitarioConversion = value; }
        }

        public decimal CantidadConversion
        {
            get { return _CantidadConversion; }
            set { _CantidadConversion = value; }
        }

        public string OrdenCompra
        {
            get { return _OrdenCompra; }
            set { _OrdenCompra = value; }
        }

        public decimal CostoFleteMovimientoDeta
        {
            get { return _CostoFleteMovimientoDeta; }
            set { _CostoFleteMovimientoDeta = value; }
        }

        public decimal CostoFleteMovimientoCabe
        {
            get { return _CostoFleteMovimientoCabe; }
            set { _CostoFleteMovimientoCabe = value; }
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

        public string ClaveProduccionProTerParteEmpaquetado
        {
            get { return _ClaveProduccionProTerParteEmpaquetado; }
            set { _ClaveProduccionProTerParteEmpaquetado = value; }
        }

        public string CCodigoArea
        {
            get { return _CCodigoArea; }
            set { _CCodigoArea = value; }
        }

        public string NCodigoArea
        {
            get { return _NCodigoArea; }
            set { _NCodigoArea = value; }
        }

        public string CCodigoPartida
        {
            get { return _CCodigoPartida; }
            set { _CCodigoPartida = value; }
        }

        public string NCodigoPartida
        {
            get { return _NCodigoPartida; }
            set { _NCodigoPartida = value; }
        }

        public string CEstadoMovimientoDeta
        {
            get { return _CEstadoMovimientoDeta; }
            set { _CEstadoMovimientoDeta = value; }
        }

        public string NEstadoMovimientoDeta
        {
            get { return _NEstadoMovimientoDeta; }
            set { _NEstadoMovimientoDeta = value; }
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



    }
}
