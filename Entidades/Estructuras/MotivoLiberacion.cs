using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class MotivoLiberacion
    {

        public const string ClaMotLib = "ClaveMotivoLiberacion";
        public const string TipMotLib = "TipoMotivoLiberacion";
        public const string CodMotLib = "CodigoMotivoLiberacion";
        public const string DesMotLib = "DescripcionMotivoLiberacion";
        public const string CanMotLib = "CantidadMotivoLiberacion";
        public const string ClaObj = "ClaveObjeto";

        //atributos    
        private string _ClaveMotivoLiberacion = string.Empty;
        private string _TipoMotivoLiberacion = string.Empty;
        private string _CodigoMotivoLiberacion = string.Empty;
        private string _DescripcionMotivoLiberacion = string.Empty;
        private decimal _CantidadMotivoLiberacion = 0;
        private string _ClaveObjeto = string.Empty;

        //propiedades

        public string ClaveMotivoLiberacion
        {
            get { return this._ClaveMotivoLiberacion; }
            set { this._ClaveMotivoLiberacion = value; }
        }

        public string TipoMotivoLiberacion
        {
            get { return this._TipoMotivoLiberacion; }
            set { this._TipoMotivoLiberacion = value; }
        }

        public string CodigoMotivoLiberacion
        {
            get { return this._CodigoMotivoLiberacion; }
            set { this._CodigoMotivoLiberacion = value; }
        }

        public string DescripcionMotivoLiberacion
        {
            get { return this._DescripcionMotivoLiberacion; }
            set { this._DescripcionMotivoLiberacion = value; }
        }

        public decimal CantidadMotivoLiberacion
        {
            get { return this._CantidadMotivoLiberacion; }
            set { this._CantidadMotivoLiberacion = value; }
        }

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }
    }
}
