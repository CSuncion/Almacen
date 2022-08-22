using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class LiberacionProTer
    {

        public const string ClaLib = "ClaveLiberacion";
        public const string FecLot = "FechaLote";
        public const string FecVcto = "FechaVcto";
        public const string Can = "Cantidad";
        public const string CosIns = "CostoInsumos";
        public const string CosTotPro = "CostoTotalProducto";
        public const string FecProDet = "FechaProduccionDeta";

        //atributos    
        private string _ClaveLiberacion = string.Empty;
        private string _FechaLote = string.Empty;
        private string _FechaVcto = string.Empty;
        private decimal _Cantidad = 0;
        private decimal _CostoInsumos = 0;
        private decimal _CostoTotalProducto = 0;
        private string _FechaProduccionDeta = string.Empty;

        //propiedades

        public string ClaveLiberacion
        {
            get { return this._ClaveLiberacion; }
            set { this._ClaveLiberacion = value; }
        }

        public string FechaLote
        {
            get { return this._FechaLote; }
            set { this._FechaLote = value; }
        }

        public string FechaVcto
        {
            get { return this._FechaVcto; }
            set { this._FechaVcto = value; }
        }

        public decimal Cantidad
        {
            get { return this._Cantidad; }
            set { this._Cantidad = value; }
        }

        public decimal CostoInsumos
        {
            get { return this._CostoInsumos; }
            set { this._CostoInsumos = value; }
        }

        public decimal CostoTotalProducto
        {
            get { return this._CostoTotalProducto; }
            set { this._CostoTotalProducto = value; }
        }

        public string FechaProduccionDeta
        {
            get { return this._FechaProduccionDeta; }
            set { this._FechaProduccionDeta = value; }
        }

    }
}
