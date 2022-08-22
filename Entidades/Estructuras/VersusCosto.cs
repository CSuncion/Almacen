using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class VersusCosto
    {

        //campos nombres       
        public const string Ele = "Elemento";
        public const string Pre = "Presupuestado";
        public const string Rea = "Real";
        public const string Dif = "Diferencia";
        public const string CodExi = "CodigoExistencia";
        public const string CodEmp = "CodigoEmpresa";
        public const string FecProTer = "FechaProTer";
        public const string FecLot = "FechaLote";
        public const string TipOpe = "TipoOperacion";
        public const string CorOpe = "CorrelativoOperacion";
        public const string ClaReg = "ClaveRegistro";
        public const string Por = "Porcentaje";

        //atributos      
        private string _Elemento = string.Empty;
        private decimal _Presupuestado = 0;
        private decimal _Real = 0;
        private decimal _Diferencia = 0;       
        private string _CodigoExistencia = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _FechaProTer = string.Empty;
        private string _FechaLote = string.Empty;
        private string _TipoOperacion = string.Empty;
        private string _CorrelativoOperacion = string.Empty;
        private string _ClaveRegistro = string.Empty;
        private decimal _Porcentaje = 0;


        //propiedades
        public string Elemento
        {
            get { return this._Elemento; }
            set { this._Elemento = value; }
        }

        public decimal Presupuestado
        {
            get { return this._Presupuestado; }
            set { this._Presupuestado = value; }
        }

        public decimal Real
        {
            get { return this._Real; }
            set { this._Real = value; }
        }

        public decimal Diferencia
        {
            get { return this._Diferencia; }
            set { this._Diferencia = value; }
        }

        public string CodigoExistencia
        {
            get { return this._CodigoExistencia; }
            set { this._CodigoExistencia = value; }
        }

        public string CodigoEmpresa
        {
            get
            {
                return _CodigoEmpresa;
            }

            set
            {
                _CodigoEmpresa = value;
            }
        }

        public string FechaProTer
        {
            get
            {
                return _FechaProTer;
            }

            set
            {
                _FechaProTer = value;
            }
        }

        public string FechaLote
        {
            get
            {
                return _FechaLote;
            }

            set
            {
                _FechaLote = value;
            }
        }

        public string TipoOperacion
        {
            get
            {
                return _TipoOperacion;
            }

            set
            {
                _TipoOperacion = value;
            }
        }

        public string CorrelativoOperacion
        {
            get
            {
                return _CorrelativoOperacion;
            }

            set
            {
                _CorrelativoOperacion = value;
            }
        }

        public string ClaveRegistro
        {
            get
            {
                return _ClaveRegistro;
            }

            set
            {
                _ClaveRegistro = value;
            }
        }

        public decimal Porcentaje
        {
            get
            {
                return _Porcentaje;
            }

            set
            {
                _Porcentaje = value;
            }
        }
    }
}
