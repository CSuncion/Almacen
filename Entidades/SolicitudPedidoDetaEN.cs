using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SolicitudPedidoDetaEN
    {
        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaMovDet = "ClaveSolicitudPedidoDeta";
        public const string ClaMovCab = "ClaveSolicitudPedidoCabe";
        public const string CorMovDet = "CorrelativoSolicitudPedidoDeta";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string FecMovCab = "FechaSolicitudPedidoCabe";
        public const string PerMovCab = "PeriodoSolicitudPedidoCabe";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodTipOpe = "CodigoTipoOperacion";
        public const string DesTipOpe = "DescripcionTipoOperacion";
        public const string CClaTipOpe = "CClaseTipoOperacion";
        public const string CCalPrePro = "CCalculaPrecioPromedio";
        public const string CConUni = "CConversionUnidad";
        public const string NumMovCab = "NumeroSolicitudPedidoCabe";
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
        public const string CanMovDet = "CantidadSolicitudPedidoDeta";
        public const string TipCam = "TipoCambio";
        public const string GloMovDet = "GlosaSolicitudPedidoDeta";
        public const string ClaProDet = "ClaveProduccionDeta";
        public const string CTipDes = "CTipoDescarga";
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
        public const string CEstMovDet = "CEstadoSolicitudPedidoDeta";
        public const string NEstMovDet = "NEstadoSolicitudPedidoDeta";
        public const string FlgChkIt = "FlagCheckItem";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
        public const string PreUltCom = "PrecioUltimaCompra";
        public const string FecUltCom = "FechaUltimaCompra";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveSolicitudPedidoDeta = string.Empty;
        private string _ClaveSolicitudPedidoCabe = string.Empty;
        private string _CorrelativoSolicitudPedidoDeta = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _FechaSolicitudPedidoCabe = string.Empty;
        private string _PeriodoSolicitudPedidoCabe = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoTipoOperacion = string.Empty;
        private string _DescripcionTipoOperacion = string.Empty;
        private string _CClaseTipoOperacion = string.Empty;
        private string _CCalculaPrecioPromedio = string.Empty;
        private string _CConversionUnidad = "0";
        private string _NumeroSolicitudPedidoCabe = string.Empty;
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
        private decimal _CantidadSolicitudPedidoDeta = 0;
        private decimal _TipoCambio = 1;
        private string _GlosaSolicitudPedidoDeta = string.Empty;
        private string _ClaveProduccionDeta = string.Empty;
        private string _CTipoDescarga = string.Empty;
        private decimal _CantidadConversion = 0;
        private string _OrdenCompra = string.Empty;
        private decimal _CostoFleteSolicitudPedidoDeta = 0;
        private decimal _CostoFleteSolicitudPedidoCabe = 0;
        private string _ClaveEncajado = string.Empty;
        private string _ClaveProduccionProTer = string.Empty;
        private string _ClaveProduccionProTerParteEmpaquetado = string.Empty;
        private string _CCodigoArea = string.Empty;
        private string _NCodigoArea = string.Empty;
        private string _CCodigoPartida = string.Empty;
        private string _NCodigoPartida = string.Empty;
        private string _CEstadoSolicitudPedidoDeta = "1";
        private string _NEstadoSolicitudPedidoDeta = "Activado";
        private bool _FlagCheckItem = false;
        private bool _VerdadFalso = false;
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private decimal _PrecioUltimaCompra = 0;
        private string _FechaUltimaCompra;
        private decimal _NuevoPresupuesto;
        private Adicional _Adicionales = new Adicional();


        //propiedades
        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveSolicitudPedidoDeta
        {
            get { return _ClaveSolicitudPedidoDeta; }
            set { _ClaveSolicitudPedidoDeta = value; }
        }

        public string ClaveSolicitudPedidoCabe
        {
            get { return _ClaveSolicitudPedidoCabe; }
            set { _ClaveSolicitudPedidoCabe = value; }
        }

        public string CorrelativoSolicitudPedidoDeta
        {
            get { return _CorrelativoSolicitudPedidoDeta; }
            set { _CorrelativoSolicitudPedidoDeta = value; }
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

        public string FechaSolicitudPedidoCabe
        {
            get { return _FechaSolicitudPedidoCabe; }
            set { _FechaSolicitudPedidoCabe = value; }
        }

        public string PeriodoSolicitudPedidoCabe
        {
            get { return _PeriodoSolicitudPedidoCabe; }
            set { _PeriodoSolicitudPedidoCabe = value; }
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

        public string NumeroSolicitudPedidoCabe
        {
            get { return _NumeroSolicitudPedidoCabe; }
            set { _NumeroSolicitudPedidoCabe = value; }
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

        public decimal CantidadSolicitudPedidoDeta
        {
            get { return _CantidadSolicitudPedidoDeta; }
            set { _CantidadSolicitudPedidoDeta = value; }
        }

        public decimal TipoCambio
        {
            get { return _TipoCambio; }
            set { _TipoCambio = value; }
        }

        public string GlosaSolicitudPedidoDeta
        {
            get { return _GlosaSolicitudPedidoDeta; }
            set { _GlosaSolicitudPedidoDeta = value; }
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

        public decimal CostoFleteSolicitudPedidoDeta
        {
            get { return _CostoFleteSolicitudPedidoDeta; }
            set { _CostoFleteSolicitudPedidoDeta = value; }
        }

        public decimal CostoFleteSolicitudPedidoCabe
        {
            get { return _CostoFleteSolicitudPedidoCabe; }
            set { _CostoFleteSolicitudPedidoCabe = value; }
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

        public string CEstadoSolicitudPedidoDeta
        {
            get { return _CEstadoSolicitudPedidoDeta; }
            set { _CEstadoSolicitudPedidoDeta = value; }
        }

        public string NEstadoSolicitudPedidoDeta
        {
            get { return _NEstadoSolicitudPedidoDeta; }
            set { _NEstadoSolicitudPedidoDeta = value; }
        }
        public bool FlagCheckItem
        {
            get { return _FlagCheckItem; }
            set { _FlagCheckItem = value; }
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

        public decimal PrecioUltimaCompra
        {
            get { return this._PrecioUltimaCompra; }
            set { this._PrecioUltimaCompra = value; }
        }

        public string FechaUltimaCompra
        {
            get { return this._FechaUltimaCompra; }
            set { this._FechaUltimaCompra = value; }
        }

        public decimal NuevoPresupuesto
        {
            get { return this._NuevoPresupuesto; }
            set { this._NuevoPresupuesto = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }
        public Adicional Adicionales
        {
            get { return _Adicionales; }
            set { _Adicionales = value; }
        }


    }
}
