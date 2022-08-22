using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class AcumuladoProceso
    {

        //campos nombres       
        public const string Ele = "Elemento";
        public const string Pro = "Produccion";
        public const string Lib = "Liberacion";
        public const string Enc = "Encajado";
        public const string Cos = "Costo";
        public const string CodExi = "CodigoExistencia";
        public const string EnvPpto = "EnvasadoPpto";
        public const string EncPpto = "EncajadoPpto";
        public const string RetPpto = "RetiquetadoPpto";
        public const string CosTotPpto = "CostoTotalPpto";
        public const string EnvRea = "EnvasadoRea";
        public const string EncRea = "EncajadoRea";
        public const string RetRea = "RetiquetadoRea";
        public const string CosTotRea = "CostoTotalRea";
        public const string EnvDif = "EnvasadoDif";
        public const string EncDif = "EncajadoDif";
        public const string RetDif = "RetiquetadoDif";
        public const string CosTotDif = "CostoTotalDif";

        //atributos      
        private string _Elemento = string.Empty;
        private decimal _Produccion = 0;
        private decimal _Liberacion = 0;
        private decimal _Encajado = 0;
        private decimal _Costo = 0;
        private string _CodigoExistencia = string.Empty;
        private decimal _EnvasadoPpto = 0;
        private decimal _EncajadoPpto = 0;
        private decimal _RetiquetadoPpto = 0;
        private decimal _CostoTotalPpto = 0;
        private decimal _EnvasadoRea = 0;
        private decimal _EncajadoRea = 0;
        private decimal _RetiquetadoRea = 0;
        private decimal _CostoTotalRea = 0;
        private decimal _EnvasadoDif = 0;
        private decimal _EncajadoDif = 0;
        private decimal _RetiquetadoDif = 0;
        private decimal _CostoTotalDif = 0;

        //propiedades
        public string Elemento
        {
            get { return this._Elemento; }
            set { this._Elemento = value; }
        }

        public decimal Produccion
        {
            get { return this._Produccion; }
            set { this._Produccion = value; }
        }

        public decimal Liberacion
        {
            get { return this._Liberacion; }
            set { this._Liberacion = value; }
        }

        public decimal Encajado
        {
            get { return this._Encajado; }
            set { this._Encajado = value; }
        }

        public decimal Costo
        {
            get { return this._Costo; }
            set { this._Costo = value; }
        }

        public string CodigoExistencia
        {
            get { return this._CodigoExistencia; }
            set { this._CodigoExistencia = value; }
        }

        public decimal EnvasadoPpto
        {
            get
            {
                return _EnvasadoPpto;
            }

            set
            {
                _EnvasadoPpto = value;
            }
        }

        public decimal EncajadoPpto
        {
            get
            {
                return _EncajadoPpto;
            }

            set
            {
                _EncajadoPpto = value;
            }
        }

        public decimal RetiquetadoPpto
        {
            get
            {
                return _RetiquetadoPpto;
            }

            set
            {
                _RetiquetadoPpto = value;
            }
        }

        public decimal CostoTotalPpto
        {
            get
            {
                return _CostoTotalPpto;
            }

            set
            {
                _CostoTotalPpto = value;
            }
        }

        public decimal EnvasadoRea
        {
            get
            {
                return _EnvasadoRea;
            }

            set
            {
                _EnvasadoRea = value;
            }
        }

        public decimal EncajadoRea
        {
            get
            {
                return _EncajadoRea;
            }

            set
            {
                _EncajadoRea = value;
            }
        }

        public decimal RetiquetadoRea
        {
            get
            {
                return _RetiquetadoRea;
            }

            set
            {
                _RetiquetadoRea = value;
            }
        }

        public decimal CostoTotalRea
        {
            get
            {
                return _CostoTotalRea;
            }

            set
            {
                _CostoTotalRea = value;
            }
        }

        public decimal EnvasadoDif
        {
            get
            {
                return _EnvasadoDif;
            }

            set
            {
                _EnvasadoDif = value;
            }
        }

        public decimal EncajadoDif
        {
            get
            {
                return _EncajadoDif;
            }

            set
            {
                _EncajadoDif = value;
            }
        }

        public decimal RetiquetadoDif
        {
            get
            {
                return _RetiquetadoDif;
            }

            set
            {
                _RetiquetadoDif = value;
            }
        }

        public decimal CostoTotalDif
        {
            get
            {
                return _CostoTotalDif;
            }

            set
            {
                _CostoTotalDif = value;
            }
        }


    }
}
