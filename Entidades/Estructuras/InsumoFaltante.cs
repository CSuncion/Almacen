using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class InsumoFaltante
    {

        //campos nombres
        public const string CodLin = "CodigoLinea";
        public const string CodSol = "CodigoSolicitud";
        public const string FecPro = "FechaProduccion";
        public const string CodFor = "CodigoFormula";
        public const string DesFor = "DescripcionFormula";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodPer = "CodigoPersonal";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CanParTra = "CantidadParteTrabajo";
        public const string CanStoExi = "CantidadStockExistencia";
        public const string CanFal = "CantidadFaltante";
        public const string CUniMed = "CUnidadMedida";
        public const string NUniMed = "NUnidadMedida";
        public const string CodAlmPro = "CodigoAlmacenProduccion";
        public const string CTur = "CTurno";
        public const string CanProDet = "CantidadProduccionDeta";
        public const string AlmSto = "AlmacenesStock";
        public const string CanFalOri = "CantidadFaltanteOrigen";

        //atributos
        private string _CodigoLinea = string.Empty;
        private string _CodigoSolicitud = string.Empty;
        private string _FechaProduccion = string.Empty;
        private string _CodigoFormula = string.Empty;
        private string _DescripcionFormula = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoPersonal = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _CantidadParteTrabajo = 0;
        private decimal _CantidadStockExistencia = 0;
        private decimal _CantidadFaltante = 0;
        private string _CUnidadMedida = string.Empty;
        private string _NUnidadMedida = string.Empty;
        private string _CodigoAlmacenProduccion = string.Empty;
        private string _CodigoPersonalProduccion = string.Empty;
        private string _CTurno = string.Empty;
        private decimal _CantidadProduccionDeta = 0;
        private string _AlmacenesStock = string.Empty;
        private decimal _CantidadFaltanteOrigen = 0;

        //propiedades
        public string CodigoLinea
        {
            get { return this._CodigoLinea; }
            set { this._CodigoLinea = value; }
        }

        public string CodigoSolicitud
        {
            get { return this._CodigoSolicitud; }
            set { this._CodigoSolicitud = value; }
        }

        public string FechaProduccion
        {
            get { return this._FechaProduccion; }
            set { this._FechaProduccion = value; }
        }

        public string CodigoFormula
        {
            get { return this._CodigoFormula; }
            set { this._CodigoFormula = value; }
        }

        public string DescripcionFormula
        {
            get { return this._DescripcionFormula; }
            set { this._DescripcionFormula = value; }
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

        public string CodigoPersonal
        {
            get { return this._CodigoPersonal; }
            set { this._CodigoPersonal = value; }
        }

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

        public decimal CantidadParteTrabajo
        {
            get { return this._CantidadParteTrabajo; }
            set { this._CantidadParteTrabajo = value; }
        }

        public decimal CantidadStockExistencia
        {
            get { return this._CantidadStockExistencia; }
            set { this._CantidadStockExistencia = value; }
        }

        public decimal CantidadFaltante
        {
            get { return this._CantidadFaltante; }
            set { this._CantidadFaltante = value; }
        }

        public string CUnidadMedida
        {
            get { return this._CUnidadMedida; }
            set { this._CUnidadMedida = value; }
        }

        public string NUnidadMedida
        {
            get { return this._NUnidadMedida; }
            set { this._NUnidadMedida = value; }
        }

        public string CodigoAlmacenProduccion
        {
            get { return this._CodigoAlmacenProduccion; }
            set { this._CodigoAlmacenProduccion = value; }
        }

        public string CodigoPersonalProduccion
        {
            get { return this._CodigoPersonalProduccion; }
            set { this._CodigoPersonalProduccion = value; }
        }

        public string CTurno
        {
            get { return this._CTurno; }
            set { this._CTurno = value; }
        }

        public decimal CantidadProduccionDeta
        {
            get { return this._CantidadProduccionDeta; }
            set { this._CantidadProduccionDeta = value; }
        }

        public string AlmacenesStock
        {
            get { return this._AlmacenesStock; }
            set { this._AlmacenesStock = value; }
        }

        public decimal CantidadFaltanteOrigen
        {
            get { return this._CantidadFaltanteOrigen; }
            set { this._CantidadFaltanteOrigen = value; }
        }

    }
}
