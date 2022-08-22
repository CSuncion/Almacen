using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class DesmedroPT
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string Pro = "Produccion";
        public const string FecPro = "FechaProduccion";
        public const string Cod = "Codigo";
        public const string Des = "Descripcion";
        public const string Pes = "Peso";
        public const string CanPro = "CantidadProducida";
        public const string TotDes = "TotalDesmedro";
        public const string SumRep1 = "Suma1Reproceso";
        public const string SumRep2 = "Suma2Reproceso";
        public const string CanRepTot = "CantidadReprocesoTotal";
        public const string TotNivDes = "TotalNivelDesmedro";
        public const string PorDesTot = "PorcentajeDesmedroTotal";
        public const string CanProKg = "CantidadProducidaKg";
        public const string TotKgRep = "TotalKgReproceso";
        public const string TotKgDes = "TotalKgDesmedro";
        public const string TotKgDesPT = "TotalKgDesmedroPT";
        public const string PorDesPTTot = "PorcentajeDesmedroPTTotal";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _Produccion = string.Empty;
        private string _FechaProduccion = string.Empty;
        private string _Codigo = string.Empty;
        private string _Descripcion = string.Empty;
        private decimal _Peso = 0;
        private decimal _CantidadProducida = 0;
        private decimal _TotalDesmedro = 0;
        private decimal _Suma1Reproceso = 0;
        private decimal _Suma2Reproceso = 0;
        private decimal _CantidadReprocesoTotal = 0;
        private decimal _TotalNivelDesmedro = 0;
        private decimal _PorcentajeDesmedroTotal = 0;
        private decimal _CantidadProducidaKg = 0;
        private decimal _TotalKgReproceso = 0;
        private decimal _TotalKgDesmedro = 0;
        private decimal _TotalKgDesmedroPT = 0;
        private decimal _PorcentajeDesmedroPTTotal = 0;
       
        #endregion

        #region Propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string Produccion
        {
            get { return this._Produccion; }
            set { this._Produccion = value; }
        }

        public string FechaProduccion
        {
            get { return this._FechaProduccion; }
            set { this._FechaProduccion = value; }
        }

        public string Codigo
        {
            get { return this._Codigo; }
            set { this._Codigo = value; }
        }

        public string Descripcion
        {
            get { return this._Descripcion; }
            set { this._Descripcion = value; }
        }

        public decimal Peso
        {
            get { return this._Peso; }
            set { this._Peso = value; }
        }

        public decimal CantidadProducida
        {
            get { return this._CantidadProducida; }
            set { this._CantidadProducida = value; }
        }

        public decimal TotalDesmedro
        {
            get { return this._TotalDesmedro; }
            set { this._TotalDesmedro = value; }
        }

        public decimal Suma1Reproceso
        {
            get { return this._Suma1Reproceso; }
            set { this._Suma1Reproceso = value; }
        }

        public decimal Suma2Reproceso
        {
            get { return this._Suma2Reproceso; }
            set { this._Suma2Reproceso = value; }
        }

        public decimal CantidadReprocesoTotal
        {
            get { return this._CantidadReprocesoTotal; }
            set { this._CantidadReprocesoTotal = value; }
        }

        public decimal TotalNivelDesmedro
        {
            get { return this._TotalNivelDesmedro; }
            set { this._TotalNivelDesmedro = value; }
        }

        public decimal PorcentajeDesmedroTotal
        {
            get { return this._PorcentajeDesmedroTotal; }
            set { this._PorcentajeDesmedroTotal = value; }
        }

        public decimal CantidadProducidaKg
        {
            get { return this._CantidadProducidaKg; }
            set { this._CantidadProducidaKg = value; }
        }

        public decimal TotalKgReproceso
        {
            get { return this._TotalKgReproceso; }
            set { this._TotalKgReproceso = value; }
        }

        public decimal TotalKgDesmedro
        {
            get { return this._TotalKgDesmedro; }
            set { this._TotalKgDesmedro = value; }
        }

        public decimal TotalKgDesmedroPT
        {
            get { return this._TotalKgDesmedroPT; }
            set { this._TotalKgDesmedroPT = value; }
        }

        public decimal PorcentajeDesmedroPTTotal
        {
            get { return this._PorcentajeDesmedroPTTotal; }
            set { this._PorcentajeDesmedroPTTotal = value; }
        }
        
        #endregion


    }
}
