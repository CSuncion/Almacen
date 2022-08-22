using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class KardexValorizado
    {

        //campos nombres
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CodUniMed1 = "CodigoUnidadMedida1";
        public const string CanAnt = "CantidadAnterior";
        public const string PreAnt = "PrecioAnterior";
        public const string TotAnt = "TotalAnterior";
        public const string CanAct = "CantidadActual";
        public const string PreAct = "PrecioActual";
        public const string TotAct = "TotalActual";
        public const string FecMovCab = "FechaMovimientoCabe";
        public const string NumMovCab = "NumeroMovimientoCabe";
        public const string CTipDoc = "CTipoDocumento";
        public const string NTipDoc = "NTipoDocumento";
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string CodTipOpe = "CodigoTipoOperacion";
        public const string DesTipOpe = "DescripcionTipoOperacion";
        public const string CClaTipOpe = "CClaseTipoOperacion";
        public const string CanIng = "CantidadIngreso";
        public const string PreIng = "PrecioIngreso";
        public const string TotIng = "TotalIngreso";
        public const string CanSal = "CantidadSalida";
        public const string PreSal = "PrecioSalida";
        public const string TotSal = "TotalSalida";
        public const string CanSald = "CantidadSaldo";
        public const string PreSald = "PrecioSaldo";
        public const string TotSald = "TotalSaldo";

        //atributos
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private string _CodigoUnidadMedida1 = string.Empty;
        private decimal _CantidadAnterior = 0;
        private decimal _PrecioAnterior = 0;
        private decimal _TotalAnterior = 0;
        private decimal _CantidadActual = 0;
        private decimal _PrecioActual = 0;
        private decimal _TotalActual = 0;
        private string _FechaMovimientoCabe = string.Empty;
        private string _NumeroMovimientoCabe = string.Empty;
        private string _CTipoDocumento = string.Empty;
        private string _NTipoDocumento = string.Empty;
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _CodigoTipoOperacion = string.Empty;
        private string _DescripcionTipoOperacion = string.Empty;
        private string _CClaseTipoOperacion = string.Empty;
        private decimal _CantidadIngreso = 0;
        private decimal _PrecioIngreso = 0;
        private decimal _TotalIngreso = 0;
        private decimal _CantidadSalida = 0;
        private decimal _PrecioSalida = 0;
        private decimal _TotalSalida = 0;
        private decimal _CantidadSaldo = 0;
        private decimal _PrecioSaldo = 0;
        private decimal _TotalSaldo = 0;

        //propiedades
        public string CodigoExistencia
        {
            get { return this._CodigoExistencia; }
            set { this._CodigoExistencia = value; }
        }

        public string DescripcionExistencia
        {
            get { return this._DescripcionExistencia; }
            set { this._DescripcionExistencia = value; }
        }

        public string CodigoUnidadMedida
        {
            get { return this._CodigoUnidadMedida; }
            set { this._CodigoUnidadMedida = value; }
        }

        public string NombreUnidadMedida
        {
            get { return this._NombreUnidadMedida; }
            set { this._NombreUnidadMedida = value; }
        }

        public string CodigoUnidadMedida1
        {
            get { return this._CodigoUnidadMedida1; }
            set { this._CodigoUnidadMedida1 = value; }
        }

        public decimal CantidadAnterior
        {
            get { return this._CantidadAnterior; }
            set { this._CantidadAnterior = value; }
        }

        public decimal PrecioAnterior
        {
            get { return this._PrecioAnterior; }
            set { this._PrecioAnterior = value; }
        }

        public decimal TotalAnterior
        {
            get { return this._TotalAnterior; }
            set { this._TotalAnterior = value; }
        }

        public decimal CantidadActual
        {
            get { return this._CantidadActual; }
            set { this._CantidadActual = value; }
        }

        public decimal PrecioActual
        {
            get { return this._PrecioActual; }
            set { this._PrecioActual = value; }
        }

        public decimal TotalActual
        {
            get { return this._TotalActual; }
            set { this._TotalActual = value; }
        }

        public string FechaMovimientoCabe
        {
            get { return _FechaMovimientoCabe; }
            set { _FechaMovimientoCabe = value; }
        }

        public string NumeroMovimientoCabe
        {
            get { return _NumeroMovimientoCabe; }
            set { _NumeroMovimientoCabe = value; }
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

        public decimal CantidadIngreso
        {
            get { return this._CantidadIngreso; }
            set { this._CantidadIngreso = value; }
        }

        public decimal PrecioIngreso
        {
            get { return this._PrecioIngreso; }
            set { this._PrecioIngreso = value; }
        }

        public decimal TotalIngreso
        {
            get { return this._TotalIngreso; }
            set { this._TotalIngreso = value; }
        }

        public decimal CantidadSalida
        {
            get { return this._CantidadSalida; }
            set { this._CantidadSalida = value; }
        }

        public decimal PrecioSalida
        {
            get { return this._PrecioSalida; }
            set { this._PrecioSalida = value; }
        }

        public decimal TotalSalida
        {
            get { return this._TotalSalida; }
            set { this._TotalSalida = value; }
        }

        public decimal CantidadSaldo
        {
            get { return this._CantidadSaldo; }
            set { this._CantidadSaldo = value; }
        }

        public decimal PrecioSaldo
        {
            get { return this._PrecioSaldo; }
            set { this._PrecioSaldo = value; }
        }

        public decimal TotalSaldo
        {
            get { return this._TotalSaldo; }
            set { this._TotalSaldo = value; }
        }

    }
}
