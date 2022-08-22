using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class KpiDesmedro
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string FecProTer = "FechaProductoTerminado";
        public const string FecPro = "FechaProceso";
        public const string FecEnc = "FechaEncajado";
        public const string Lot = "Lote";
        public const string Pro = "Produccion";
        public const string Cod = "Codigo";
        public const string Des = "Descripcion";
        public const string CanPro = "CantidadProducida";
        public const string RepClaProUni = "ReprocesoClaProUni";
        public const string ObsClaProUni = "ObservacionClaProUni";
        public const string DesClaProUni = "DesmedroClaProUni";
        public const string AprClaEncUni = "AprobadoClaEncUni";
        public const string RepClaEncUni = "ReprocesoClaEncUni";
        public const string ObsClaEncUni = "ObservacionClaEncUni";
        public const string DesClaEncUni = "DesmedroClaEncUni";
        public const string TotDesUni = "TotalDesmedroUni";
        public const string RepClaProPor = "ReprocesoClaProPor";
        public const string ObsClaProPor = "ObservacionClaProPor";
        public const string DesClaProPor = "DesmedroClaProPor";
        public const string AprClaEncPor = "AprobadoClaEncPor";
        public const string RepClaEncPor = "ReprocesoClaEncPor";
        public const string ObsClaEncPor = "ObservacionClaEncPor";
        public const string DesClaEncPor = "DesmedroClaEncPor";
        public const string TotDesPor = "TotalDesmedroPor";
        public const string CanPla = "CantidadPlanificada";
        public const string AprClaProUni = "AprobadoClaProUni";
        public const string AprClaProPor = "AprobadoClaProPor";
        public const string DonaClaProUni = "DonacionClaProUni";
        public const string DeseClaProUni = "DesechoClaProUni";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _FechaProductoTerminado = string.Empty;
        private string _FechaProceso = string.Empty;
        private string _FechaEncajado = string.Empty;
        private string _Lote = string.Empty;
        private string _Produccion = string.Empty;
        private string _Codigo = string.Empty;
        private string _Descripcion = string.Empty;
        private decimal _CantidadProducida = 0;
        private decimal _ReprocesoClaProUni = 0;
        private decimal _ObservacionClaProUni = 0;
        private decimal _DesmedroClaProUni = 0;
        private decimal _AprobadoClaEncUni = 0;
        private decimal _ReprocesoClaEncUni = 0;
        private decimal _ObservacionClaEncUni = 0;
        private decimal _DesmedroClaEncUni = 0;
        private decimal _TotalDesmedroUni = 0;
        private decimal _ReprocesoClaProPor = 0;
        private decimal _ObservacionClaProPor = 0;
        private decimal _DesmedroClaProPor = 0;
        private decimal _AprobadoClaEncPor = 0;
        private decimal _ReprocesoClaEncPor = 0;
        private decimal _ObservacionClaEncPor = 0;
        private decimal _DesmedroClaEncPor = 0;
        private decimal _TotalDesmedroPor = 0;
        private decimal _CantidadPlanificada = 0;
        private decimal _AprobadoClaProUni = 0;
        private decimal _AprobadoClaProPor = 0;
        private decimal _DonacionClaProUni = 0;
        private decimal _DesechoClaProUni = 0;


        #endregion

        #region Propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string FechaProductoTerminado
        {
            get { return this._FechaProductoTerminado; }
            set { this._FechaProductoTerminado = value; }
        }

        public string FechaProceso
        {
            get { return this._FechaProceso; }
            set { this._FechaProceso = value; }
        }

        public string FechaEncajado
        {
            get { return this._FechaEncajado; }
            set { this._FechaEncajado = value; }
        }

        public string Lote
        {
            get { return this._Lote; }
            set { this._Lote = value; }
        }

        public string Produccion
        {
            get { return this._Produccion; }
            set { this._Produccion = value; }
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

        public decimal CantidadProducida
        {
            get { return this._CantidadProducida; }
            set { this._CantidadProducida = value; }
        }

        public decimal ReprocesoClaProUni
        {
            get { return this._ReprocesoClaProUni; }
            set { this._ReprocesoClaProUni = value; }
        }

        public decimal ObservacionClaProUni
        {
            get { return this._ObservacionClaProUni; }
            set { this._ObservacionClaProUni = value; }
        }

        public decimal DesmedroClaProUni
        {
            get { return this._DesmedroClaProUni; }
            set { this._DesmedroClaProUni = value; }
        }

        public decimal AprobadoClaEncUni
        {
            get { return this._AprobadoClaEncUni; }
            set { this._AprobadoClaEncUni = value; }
        }

        public decimal ReprocesoClaEncUni
        {
            get { return this._ReprocesoClaEncUni; }
            set { this._ReprocesoClaEncUni = value; }
        }

        public decimal ObservacionClaEncUni
        {
            get { return this._ObservacionClaEncUni; }
            set { this._ObservacionClaEncUni = value; }
        }

        public decimal DesmedroClaEncUni
        {
            get { return this._DesmedroClaEncUni; }
            set { this._DesmedroClaEncUni = value; }
        }

        public decimal TotalDesmedroUni
        {
            get { return this._TotalDesmedroUni; }
            set { this._TotalDesmedroUni = value; }
        }

        public decimal ReprocesoClaProPor
        {
            get { return this._ReprocesoClaProPor; }
            set { this._ReprocesoClaProPor = value; }
        }

        public decimal ObservacionClaProPor
        {
            get { return this._ObservacionClaProPor; }
            set { this._ObservacionClaProPor = value; }
        }

        public decimal DesmedroClaProPor
        {
            get { return this._DesmedroClaProPor; }
            set { this._DesmedroClaProPor = value; }
        }

        public decimal AprobadoClaEncPor
        {
            get { return this._AprobadoClaEncPor; }
            set { this._AprobadoClaEncPor = value; }
        }

        public decimal ReprocesoClaEncPor
        {
            get { return this._ReprocesoClaEncPor; }
            set { this._ReprocesoClaEncPor = value; }
        }

        public decimal ObservacionClaEncPor
        {
            get { return this._ObservacionClaEncPor; }
            set { this._ObservacionClaEncPor = value; }
        }

        public decimal DesmedroClaEncPor
        {
            get { return this._DesmedroClaEncPor; }
            set { this._DesmedroClaEncPor = value; }
        }

        public decimal TotalDesmedroPor
        {
            get { return this._TotalDesmedroPor; }
            set { this._TotalDesmedroPor = value; }
        }

        public decimal CantidadPlanificada
        {
            get { return this._CantidadPlanificada; }
            set { this._CantidadPlanificada = value; }
        }

        public decimal AprobadoClaProUni
        {
            get { return this._AprobadoClaProUni; }
            set { this._AprobadoClaProUni = value; }
        }

        public decimal AprobadoClaProPor
        {
            get { return this._AprobadoClaProPor; }
            set { this._AprobadoClaProPor = value; }
        }

        public decimal DonacionClaProUni
        {
            get { return this._DonacionClaProUni; }
            set { this._DonacionClaProUni = value; }
        }

        public decimal DesechoClaProUni
        {
            get { return this._DesechoClaProUni; }
            set { this._DesechoClaProUni = value; }
        }

        #endregion

    }
}
