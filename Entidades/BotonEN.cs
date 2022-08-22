using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class BotonEN
    {
        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string CodBot = "CodigoBoton";
        public const string NomBot = "NombreBoton";
        public const string NomCon = "NombreControl";
        public const string CValGri = "CValidaGrilla";
        public const string CEstBot = "CEstadoBoton";
        public const string NEstBot = "NEstadoBoton";       
      
        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CodigoBoton = string.Empty;
        private string _NombreBoton = string.Empty;
        private string _NombreControl = string.Empty;
        private string _CValidaGrilla = "1";
        private string _CEstadoBoton = "1";
        private string _NEstadoBoton = "ACTIVADO";   
        private Adicional _Adicionales = new Adicional();

        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }        
        }

        public string CodigoBoton
        {
            get { return this._CodigoBoton; }
            set { this._CodigoBoton = value; }
        }

        public string NombreBoton
        {
            get { return this._NombreBoton; }
            set { this._NombreBoton = value; }
        }

        public string NombreControl
        {
            get { return this._NombreControl; }
            set { this._NombreControl = value; }
        }

        public string CValidaGrilla
        {
            get { return this._CValidaGrilla; }
            set { this._CValidaGrilla = value; }
        }

        public string CEstadoBoton
        {
            get { return this._CEstadoBoton; }
            set { this._CEstadoBoton = value; }
        }

        public string NEstadoBoton
        {
            get { return this._NEstadoBoton; }
            set { this._NEstadoBoton = value; }
        }
     
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
