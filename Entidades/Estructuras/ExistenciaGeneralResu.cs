using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class ExistenciaGeneralResu
    {

        //campos nombres      
        public const string CodTip = "CodigoTipo";
        public const string NomTip = "NombreTipo";     
        public const string Can = "Cantidad";        
        public const string Imp = "Importe";
        public const string NumIte = "NumeroItem";

        //atributos        
        private string _CodigoTipo = string.Empty;
        private string _NombreTipo = string.Empty;        
        private decimal _Cantidad = 0;        
        private decimal _Importe = 0;
        private int _NumeroItem = 0;

        //propiedades
      
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
        
        public decimal Cantidad
        {
            get { return this._Cantidad; }
            set { this._Cantidad = value; }
        }

        public decimal Importe
        {
            get { return this._Importe; }
            set { this._Importe = value; }
        }

        public int NumeroItem
        {
            get { return this._NumeroItem; }
            set { this._NumeroItem = value; }
        }

    }
}
