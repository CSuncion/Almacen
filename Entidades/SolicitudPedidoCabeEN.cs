using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Adicionales;

namespace Entidades
{
    public class SolicitudPedidoCabeEN
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaMovCab = "ClaveSolicitudPedidoCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string PerMovCab = "PeriodoSolicitudPedidoCabe";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CCalPrePro = "CCalculaPrecioPromedio";
        public const string CConUni = "CConversionUnidad";
        public const string NumMovCab = "NumeroSolicitudPedidoCabe";
        public const string FecMovCab = "FechaSolicitudPedidoCabe";
        public const string FecMovFinCab = "FechaSolicitudPedidofINCabe";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string CodPer = "CodigoPersonal";
        public const string NomPer = "NombrePersonal";
        public const string CodPerAut = "CodigoPersonalAutoriza";
        public const string NomPerAut = "NombrePersonalAutoriza";
        public const string FecDoc = "FechaDocumento";
        public const string GloMovCab = "GlosaSolicitudPedidoCabe";
        public const string ClaProDet = "ClaveProduccionDeta";
        public const string COriVenCre = "COrigenVentanaCreacion";
        public const string NOriVenCre = "NOrigenVentanaCreacion";
        public const string CosFleMovCab = "CostoFleteSolicitudPedidoCabe";
        public const string CCodMon = "CCodigoMoneda";
        public const string NCodMon = "NCodigoMoneda";
        public const string ClaEnc = "ClaveEncajado";
        public const string ClaProProTer = "ClaveProduccionProTer";
        public const string DetProDetAdi = "DetalleProduccionDetaAdicional";
        public const string ClaProTerParEmp = "ClaveProduccionProTerParteEmpaquetado";
        public const string CEstMovCab = "CEstadoSolicitudPedidoCabe";
        public const string NEstMovCab = "NEstadoSolicitudPedidoCabe";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
        public const string TipCam = "TipoCambio";
        public const string MasSolPed = "MasivoSolicitudPedidoCabe";
        public const string FlagEnvSolPed = "FlagEnviadoSolicitudPedido";
        public const string CorreoAux = "CorreoAuxiliar";
        public const string CCopiaSolPed = "CCopiaSolicitudPedidoCabe";
        public const string NCopiaSolPed = "NCopiaSolicitudPedidoCabe";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveSolicitudPedidoCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _PeriodoSolicitudPedidoCabe = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoTipoOperacion = string.Empty;
        private string _DescripcionTipoOperacion = string.Empty;
        private string _CClaseTipoOperacion = string.Empty;
        private string _NClaseTipoOperacion = string.Empty;
        private string _CCalculaPrecioPromedio = string.Empty;
        private string _CConversionUnidad = "0";
        private string _NumeroSolicitudPedidoCabe = string.Empty;
        private string _FechaSolicitudPedidoCabe = string.Empty;
        private string _FechaSolicitudPedidoFinCabe = string.Empty;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _CorreoAuxiliar = string.Empty;
        private string _CodigoPersonal = string.Empty;
        private string _NombrePersonal = string.Empty;
        private string _CodigoPersonalAutoriza = string.Empty;
        private string _NombrePersonalAutoriza = string.Empty;
        private string _FechaDocumento = string.Empty;
        private string _GlosaSolicitudPedidoCabe = string.Empty;
        private string _ClaveProduccionDeta = string.Empty;
        private string _COrigenVentanaCreacion = string.Empty;
        private string _NOrigenVentanaCreacion = string.Empty;
        private string _CCodigoMoneda = "0";
        private string _NCodigoMoneda = "Sol";
        private string _ClaveEncajado = string.Empty;
        private string _ClaveProduccionProTer = string.Empty;
        private string _DetalleProduccionDetaAdicional = string.Empty;
        private string _ClaveProduccionProTerParteEmpaquetado = string.Empty;
        private decimal _TipoCambio = 0;
        private string _CEstadoSolicitudPedidoCabe = "1";
        private string _NEstadoSolicitudPedidoCabe = "Activado";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();
        private decimal _CostoFleteMovimientoCabe = 0;
        private bool _MasivoSolicitudPedidoCabe = false;
        private bool _FlagEnviadoSolicitudPedido = false;
        private bool _VerdadFalso = false;
        private string _CPermitir = "1";
        private string _CCopiaSolicitudPedidoCabe = "0";
        private string _NCopiaSolicitudPedidoCabe = string.Empty;

        //propiedades
        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveSolicitudPedidoCabe
        {
            get { return _ClaveSolicitudPedidoCabe; }
            set { _ClaveSolicitudPedidoCabe = value; }
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

        public string FechaSolicitudPedidoCabe
        {
            get { return _FechaSolicitudPedidoCabe; }
            set { _FechaSolicitudPedidoCabe = value; }
        }

        public string FechaSolicitudPedidoFinCabe
        {
            get { return _FechaSolicitudPedidoFinCabe; }
            set { _FechaSolicitudPedidoFinCabe = value; }
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

        public string CorreoAuxiliar
        {
            get { return _CorreoAuxiliar; }
            set { _CorreoAuxiliar = value; }
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


        public string FechaDocumento
        {
            get { return _FechaDocumento; }
            set { _FechaDocumento = value; }
        }

        public string GlosaSolicitudPedidoCabe
        {
            get { return _GlosaSolicitudPedidoCabe; }
            set { _GlosaSolicitudPedidoCabe = value; }
        }


        public string ClaveProduccionDeta
        {
            get { return _ClaveProduccionDeta; }
            set { _ClaveProduccionDeta = value; }
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

        public string CEstadoSolicitudPedidoCabe
        {
            get { return _CEstadoSolicitudPedidoCabe; }
            set { _CEstadoSolicitudPedidoCabe = value; }
        }

        public string NEstadoSolicitudPedidoCabe
        {
            get { return _NEstadoSolicitudPedidoCabe; }
            set { _NEstadoSolicitudPedidoCabe = value; }
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

        public decimal CostoFleteSolicitudPedidoCabe
        {
            get { return _CostoFleteMovimientoCabe; }
            set { _CostoFleteMovimientoCabe = value; }
        }

        public bool MasivoSolicitudPedidoCabe
        {
            get { return _MasivoSolicitudPedidoCabe; }
            set { _MasivoSolicitudPedidoCabe = value; }
        }
        public bool FlagEnviadoSolicitudPedido
        {
            get { return _FlagEnviadoSolicitudPedido; }
            set { _FlagEnviadoSolicitudPedido = value; }
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


        public string CCopiaSolicitudPedidoCabe
        {
            get { return this._CCopiaSolicitudPedidoCabe; }
            set { this._CCopiaSolicitudPedidoCabe = value; }
        }


        public string NCopiaSolicitudPedidoCabe
        {
            get { return _NCopiaSolicitudPedidoCabe; }
            set { _NCopiaSolicitudPedidoCabe = value; }
        }

    }
}
