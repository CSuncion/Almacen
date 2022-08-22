using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class CumplimientoProduccion
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string Sem = "Semana";
        public const string CTur = "CTurno";
        public const string NTur = "NTurno";
        public const string CodSemPro = "CodigoSemiProducto";
        public const string DesSemPro = "DescripcionSemiProducto";
        public const string FecPro = "FechaProduccion";
        public const string CodMes = "CodigoMes";
        public const string NomMes = "NombreMes";
        public const string CFam = "CFamilia";
        public const string NFam = "NFamilia";
        public const string KgIte = "KgItem";
        public const string CanPla = "CantidadPlanificada";
        public const string CanSin = "CantidadSincerada";
        public const string KgPla = "KgPlanificada";
        public const string KgSin = "KgSincerado";
        public const string CanPro = "CantidadProducido";
        public const string CanLib = "CantidadLiberado";
        public const string KgPro = "KgProducido";
        public const string KgLib = "KgLiberado";
        public const string re = "resultado";
        public const string re2 = "resultado2";
        public const string PorCum = "PorcentajeCumplimiento";
        public const string PorCumBru = "PorcentajeCumplimientoBruto";
        public const string PorCumNet = "PorcentajeCumplimientoNeto";
        public const string Obs = "Observacion";
        public const string CorProCab = "CorrelativoProduccionCabe";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _Semana = string.Empty;
        private string _CTurno = string.Empty;
        private string _NTurno = string.Empty;
        private string _CodigoSemiProducto = string.Empty;
        private string _DescripcionSemiProducto = string.Empty;
        private string _FechaProduccion = string.Empty;
        private string _CodigoMes = string.Empty;
        private string _NombreMes = string.Empty;
        private string _CFamilia = string.Empty;
        private string _NFamilia = string.Empty;
        private decimal _KgItem = 0;
        private decimal _CantidadPlanificada = 0;
        private decimal _CantidadSincerada = 0;
        private decimal _KgPlanificada = 0;
        private decimal _KgSincerado = 0;
        private decimal _CantidadProducido = 0;
        private decimal _CantidadLiberado = 0;
        private decimal _KgProducido = 0;
        private decimal _KgLiberado = 0;
        private decimal _resultado = 0;
        private decimal _resultado2 = 0;
        private decimal _PorcentajeCumplimiento = 0;
        private decimal _PorcentajeCumplimientoBruto = 0;
        private decimal _PorcentajeCumplimientoNeto = 0;
        private string _Observacion = string.Empty;
        private string _CorrelativoProduccionCabe = string.Empty;

        #endregion

        #region Propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string Semana
        {
            get { return this._Semana; }
            set { this._Semana = value; }
        }

        public string CTurno
        {
            get { return this._CTurno; }
            set { this._CTurno = value; }
        }

        public string NTurno
        {
            get { return this._NTurno; }
            set { this._NTurno = value; }
        }

        public string CodigoSemiProducto
        {
            get { return this._CodigoSemiProducto; }
            set { this._CodigoSemiProducto = value; }
        }

        public string DescripcionSemiProducto
        {
            get { return this._DescripcionSemiProducto; }
            set { this._DescripcionSemiProducto = value; }
        }

        public string FechaProduccion
        {
            get { return this._FechaProduccion; }
            set { this._FechaProduccion = value; }
        }

        public string CodigoMes
        {
            get { return this._CodigoMes; }
            set { this._CodigoMes = value; }
        }

        public string NombreMes
        {
            get { return this._NombreMes; }
            set { this._NombreMes = value; }
        }

        public string CFamilia
        {
            get { return this._CFamilia; }
            set { this._CFamilia = value; }
        }

        public string NFamilia
        {
            get { return this._NFamilia; }
            set { this._NFamilia = value; }
        }

        public decimal KgItem
        {
            get { return this._KgItem; }
            set { this._KgItem = value; }
        }

        public decimal CantidadPlanificada
        {
            get { return this._CantidadPlanificada; }
            set { this._CantidadPlanificada = value; }
        }

        public decimal CantidadSincerada
        {
            get { return this._CantidadSincerada; }
            set { this._CantidadSincerada = value; }
        }

        public decimal KgPlanificada
        {
            get { return this._KgPlanificada; }
            set { this._KgPlanificada = value; }
        }

        public decimal KgSincerado
        {
            get { return this._KgSincerado; }
            set { this._KgSincerado = value; }
        }

        public decimal CantidadProducido
        {
            get { return this._CantidadProducido; }
            set { this._CantidadProducido = value; }
        }

        public decimal CantidadLiberado
        {
            get { return this._CantidadLiberado; }
            set { this._CantidadLiberado = value; }
        }

        public decimal KgProducido
        {
            get { return this._KgProducido; }
            set { this._KgProducido = value; }
        }

        public decimal KgLiberado
        {
            get { return this._KgLiberado; }
            set { this._KgLiberado = value; }
        }

        public decimal resultado
        {
            get { return this._resultado; }
            set { this._resultado = value; }
        }

        public decimal resultado2
        {
            get { return this._resultado2; }
            set { this._resultado2 = value; }
        }

        public decimal PorcentajeCumplimiento
        {
            get { return this._PorcentajeCumplimiento; }
            set { this._PorcentajeCumplimiento = value; }
        }

        public decimal PorcentajeCumplimientoBruto
        {
            get { return this._PorcentajeCumplimientoBruto; }
            set { this._PorcentajeCumplimientoBruto = value; }
        }

        public decimal PorcentajeCumplimientoNeto
        {
            get { return this._PorcentajeCumplimientoNeto; }
            set { this._PorcentajeCumplimientoNeto = value; }
        }

        public string Observacion
        {
            get { return this._Observacion; }
            set { this._Observacion = value; }
        }

        public string CorrelativoProduccionCabe
        {
            get { return this._CorrelativoProduccionCabe; }
            set { this._CorrelativoProduccionCabe = value; }
        }

        #endregion



    }
}
