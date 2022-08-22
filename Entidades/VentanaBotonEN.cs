using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class VentanaBotonEN
    {
        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaVenBot = "ClaveVentanaBoton";
        public const string CodSubMen = "CodigoSubMenu";
        public const string NomSubMen = "NombreSubMenu";
        public const string CodVen = "CodigoVentana";
        public const string NomVen = "NombreVentana";
        public const string CodBot = "CodigoBoton";
        public const string NomBot = "NombreBoton";
        public const string CEstVenBot = "CEstadoVentanaBoton";
        public const string NEstVenBot = "NEstadoVentanaBoton";
        public const string VerFal = "VerdadFalso";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveVentanaBoton = string.Empty;
        private string _CodigoSubMenu = string.Empty;
        private string _NombreSubMenu = string.Empty;
        private string _CodigoVentana = string.Empty;
        private string _NombreVentana = string.Empty;
        private string _CodigoBoton = string.Empty;
        private string _NombreBoton = string.Empty;
        private string _CEstadoVentanaBoton = "1";
        private string _NEstadoVentanaBoton = "ACTIVADO";
        private bool _VerdadFalso = false;        
        private Adicional _Adicionales = new Adicional();

        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }        
        }

        public string ClaveVentanaBoton
        {
            get { return this._ClaveVentanaBoton; }
            set { this._ClaveVentanaBoton = value; }
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

        public string CEstadoVentanaBoton
        {
            get { return this._CEstadoVentanaBoton; }
            set { this._CEstadoVentanaBoton = value; }
        }

        public string NEstadoVentanaBoton
        {
            get { return this._NEstadoVentanaBoton; }
            set { this._NEstadoVentanaBoton = value; }
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
