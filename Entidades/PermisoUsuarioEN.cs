using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class PermisoUsuarioEN
    {
        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaPerUsu = "ClavePermisoUsuario";
        public const string CodSubMen = "CodigoSubMenu";
        public const string NomSubMen = "NombreSubMenu";
        public const string CodVen = "CodigoVentana";
        public const string NomVen = "NombreVentana";
        public const string NomConVen = "NombreControlVentana";
        public const string CodBot = "CodigoBoton";
        public const string NomBot = "NombreBoton";
        public const string NomCon = "NombreControl";
        public const string CValGri = "CValidaGrilla";
        public const string CodUsu = "CodigoUsuario";
        public const string NomUsu = "NombreUsuario";
        public const string CPer = "CPermitir";
        public const string VerFal = "VerdadFalso";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClavePermisoUsuario = string.Empty;
        private string _CodigoSubMenu = string.Empty;
        private string _NombreSubMenu = string.Empty;
        private string _CodigoVentana = string.Empty;
        private string _NombreVentana = string.Empty;
        private string _NombreControlVentana = string.Empty;
        private string _CodigoBoton = string.Empty;
        private string _NombreBoton = string.Empty;
        private string _NombreControl = string.Empty;
        private string _CValidaGrilla = "1";
        private string _CodigoUsuario = string.Empty;
        private string _NombreUsuario = string.Empty;
        private string _CPermitir = "1";
        private bool _VerdadFalso = false;        
        private Adicional _Adicionales = new Adicional();

        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }        
        }

        public string ClavePermisoUsuario
        {
            get { return this._ClavePermisoUsuario; }
            set { this._ClavePermisoUsuario = value; }
        }

        public string CodigoSubMenu 
        {
            get { return this._CodigoSubMenu; }
            set { this._CodigoSubMenu = value; }
        }

        public string NombreSubMenu
        {
            get { return this._NombreSubMenu; }
            set { this._NombreSubMenu = value; }
        }

        public string CodigoVentana
        {
            get { return this._CodigoVentana; }
            set { this._CodigoVentana = value; }
        }

        public string NombreVentana
        {
            get { return this._NombreVentana; }
            set { this._NombreVentana = value; }
        }

        public string NombreControlVentana
        {
            get { return this._NombreControlVentana; }
            set { this._NombreControlVentana = value; }
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

        public string CodigoUsuario
        {
            get { return this._CodigoUsuario; }
            set { this._CodigoUsuario = value; }
        }

        public string NombreUsuario
        {
            get { return this._NombreUsuario; }
            set { this._NombreUsuario = value; }
        }

        public string CPermitir
        {
            get { return this._CPermitir; }
            set { this._CPermitir = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }
        
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
