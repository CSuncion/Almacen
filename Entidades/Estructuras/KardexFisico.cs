using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class KardexFisico
    {

        //campos nombres
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodTip = "CodigoTipo";
        public const string NomTip = "NombreTipo";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string StoAnt = "StockAnterior";
        public const string Ing = "Ingresos";
        public const string Sal = "Salidas";
        public const string StoAct = "StockActual";
        public const string PreUni = "PrecioUnitario";
        public const string Tot = "Total";

        //atributos
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _CodigoTipo = string.Empty;
        private string _NombreTipo = string.Empty;
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private decimal _StockAnterior = 0;
        private decimal _Ingresos = 0;
        private decimal _Salidas = 0;
        private decimal _StockActual = 0;
        private decimal _PrecioUnitario = 0;
        private decimal _Total = 0;

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

        public string CodigoTipo
        {
            get { return this._CodigoTipo; }
            set { this._CodigoTipo = value; }
        }

        public string NombreTipo
        {
            get { return this._NombreTipo; }
            set { this._NombreTipo = value; }
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

        public string CodigoAlmacen
        {
            get { return this._CodigoAlmacen; }
            set { this._CodigoAlmacen = value; }
        }

        public string DescripcionAlmacen
        {
            get { return this._DescripcionAlmacen; }
            set { this._DescripcionAlmacen = value; }
        }

        public decimal StockAnterior
        {
            get { return this._StockAnterior; }
            set { this._StockAnterior = value; }
        }

        public decimal Ingresos
        {
            get { return this._Ingresos; }
            set { this._Ingresos = value; }
        }

        public decimal Salidas
        {
            get { return this._Salidas; }
            set { this._Salidas = value; }
        }

        public decimal StockActual
        {
            get { return this._StockActual; }
            set { this._StockActual = value; }
        }

        public decimal PrecioUnitario
        {
            get { return this._PrecioUnitario; }
            set { this._PrecioUnitario = value; }
        }

        public decimal Total
        {
            get { return this._Total; }
            set { this._Total = value; }
        }

    }
}
