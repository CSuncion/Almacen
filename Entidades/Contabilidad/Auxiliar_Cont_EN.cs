using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Contabilidad
{
    public class Auxiliar_Cont_EN
    {

        //campos nombres
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string DirAux = "DireccionAuxiliar";
        public const string TelAux = "TelefonoAuxiliar";
        public const string CelAux = "CelularAuxiliar";
        public const string CorAux = "CorreoAuxiliar";
        public const string RefAux = "ReferenciaAuxiliar";
        public const string TipAux = "TipoAuxiliar";
        public const string TipDocAux = "TipoDocumentoAuxiliar";
        public const string EstAux = "EstadoAuxiliar";

        //Atributos
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _DireccionAuxiliar = string.Empty;
        private string _TelefonoAuxiliar = string.Empty;
        private string _CelularAuxiliar = string.Empty;
        private string _CorreoAuxiliar = string.Empty;
        private string _ReferenciaAuxiliar = string.Empty;
        private string _TipoAuxiliar = string.Empty;
        private string _TipoDocumentoAuxiliar = string.Empty;
        private string _EstadoAuxiliar = string.Empty;
        private Adicional _Adicionales = new Adicional();

        //Propiedades
        public string CodigoAuxiliar
        {
            get { return this._CodigoAuxiliar; }
            set { this._CodigoAuxiliar = value; }
        }

        public string DescripcionAuxiliar
        {
            get { return this._DescripcionAuxiliar; }
            set { this._DescripcionAuxiliar = value; }
        }

        public string DireccionAuxiliar
        {
            get { return this._DireccionAuxiliar; }
            set { this._DireccionAuxiliar = value; }
        }

        public string TelefonoAuxiliar
        {
            get { return this._TelefonoAuxiliar; }
            set { this._TelefonoAuxiliar = value; }
        }

        public string CelularAuxiliar
        {
            get { return this._CelularAuxiliar; }
            set { this._CelularAuxiliar = value; }
        }

        public string CorreoAuxiliar
        {
            get { return this._CorreoAuxiliar; }
            set { this._CorreoAuxiliar = value; }
        }

        public string ReferenciaAuxiliar
        {
            get { return this._ReferenciaAuxiliar; }
            set { this._ReferenciaAuxiliar = value; }
        }

        public string TipoAuxiliar
        {
            get { return this._TipoAuxiliar; }
            set { this._TipoAuxiliar = value; }
        }

        public string TipoDocumentoAuxiliar
        {
            get { return this._TipoDocumentoAuxiliar; }
            set { this._TipoDocumentoAuxiliar = value; }
        }

        public string EstadoAuxiliar
        {
            get { return this._EstadoAuxiliar; }
            set { this._EstadoAuxiliar = value; }
        }

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }

    }
}
