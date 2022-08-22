using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class SaldosExistencia
    {

        //campos nombres       
        public const string StoAnt = "StockAnterior";
        public const string Ing = "Ingresos";
        public const string Sal = "Salidas";
        public const string StoAct = "StockActual";
        public const string CMes = "CodigoMes";
        public const string NMes = "NombreMes";
       

        //atributos      
        private decimal _StockAnterior = 0;
        private decimal _Ingresos = 0;
        private decimal _Salidas = 0;
        private decimal _StockActual = 0;
        private string _CodigoMes = string.Empty;
        private string _NombreMes = string.Empty;

        //propiedades
    
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

    }
}
