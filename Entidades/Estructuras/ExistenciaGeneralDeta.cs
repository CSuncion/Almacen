using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class ExistenciaGeneralDeta
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
        public const string Ubi = "Ubicacion";
        public const string Sto = "Stock";        
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
        private string _Ubicacion = string.Empty;
        private decimal _Stock = 0;        
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

        public string Ubicacion
        {
            get { return this._Ubicacion; }
            set { this._Ubicacion = value; }
        }

        public decimal Stock
        {
            get { return this._Stock; }
            set { this._Stock = value; }
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
