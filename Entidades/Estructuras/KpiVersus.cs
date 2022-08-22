using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class KpiVersus
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
        public const string EnvUniPla = "EnvasadoUniPla";
        public const string EncUniPla = "EncajadoUniPla";
        public const string RetUniPla = "RetiquetadoUniPla";
        public const string EnvUniRea = "EnvasadoUniRea";
        public const string EncUniRea = "EncajadoUniRea";
        public const string RetUniRea = "RetiquetadoUniRea";
        public const string EnvDif = "EnvasadoDif";
        public const string EncDif = "EncajadoDif";
        public const string RetDif = "RetiquetadoDif";
        public const string EnvPor = "EnvasadoPor";
        public const string EncPor = "EncajadoPor";
        public const string RetPor = "RetiquetadoPor";

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
        private decimal _EnvasadoUniPla = 0;
        private decimal _EncajadoUniPla = 0;
        private decimal _RetiquetadoUniPla = 0;
        private decimal _EnvasadoUniRea = 0;
        private decimal _EncajadoUniRea = 0;
        private decimal _RetiquetadoUniRea = 0;
        private decimal _EnvasadoDif = 0;
        private decimal _EncajadoDif = 0;
        private decimal _RetiquetadoDif = 0;
        private decimal _EnvasadoPor = 0;
        private decimal _EncajadoPor = 0;
        private decimal _RetiquetadoPor = 0;
       
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

        public decimal EnvasadoUniPla
        {
            get { return this._EnvasadoUniPla; }
            set { this._EnvasadoUniPla = value; }
        }

        public decimal EncajadoUniPla
        {
            get { return this._EncajadoUniPla; }
            set { this._EncajadoUniPla = value; }
        }

        public decimal RetiquetadoUniPla
        {
            get { return this._RetiquetadoUniPla; }
            set { this._RetiquetadoUniPla = value; }
        }

        public decimal EnvasadoUniRea
        {
            get { return this._EnvasadoUniRea; }
            set { this._EnvasadoUniRea = value; }
        }

        public decimal EncajadoUniRea
        {
            get { return this._EncajadoUniRea; }
            set { this._EncajadoUniRea = value; }
        }

        public decimal RetiquetadoUniRea
        {
            get { return this._RetiquetadoUniRea; }
            set { this._RetiquetadoUniRea = value; }
        }

        public decimal EnvasadoDif
        {
            get { return this._EnvasadoDif; }
            set { this._EnvasadoDif = value; }
        }

        public decimal EncajadoDif
        {
            get { return this._EncajadoDif; }
            set { this._EncajadoDif = value; }
        }

        public decimal RetiquetadoDif
        {
            get { return this._RetiquetadoDif; }
            set { this._RetiquetadoDif = value; }
        }

        public decimal EnvasadoPor
        {
            get { return this._EnvasadoPor; }
            set { this._EnvasadoPor = value; }
        }

        public decimal EncajadoPor
        {
            get { return this._EncajadoPor; }
            set { this._EncajadoPor = value; }
        }

        public decimal RetiquetadoPor
        {
            get { return this._RetiquetadoPor; }
            set { this._RetiquetadoPor = value; }
        }
        
        #endregion


    }
}
