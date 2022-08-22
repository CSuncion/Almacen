using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class VentanaEN
    {
        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string CodVen = "CodigoVentana";
        public const string NomVen = "NombreVentana";
        public const string NomConVen = "NombreControlVentana";
        public const string CodSubMen = "CodigoSubMenu";
        public const string NomSubMen = "NombreSubMenu";
        public const string CEstVen = "CEstadoVentana";
        public const string NEstVen = "NEstadoVentana";       
        
        //atributos
        private string _ClaveObjeto = string.Empty;      
        private string _CodigoVentana = string.Empty;
        private string _NombreVentana = string.Empty;
        private string _NombreControlVentana = string.Empty;
        private string _CodigoSubMenu = string.Empty;
        private string _NombreSubMen = string.Empty;
        private string _CEstadoVentana = "1";
        private string _NEstadoVentana = "ACTIVADO";      
        private Adicional _Adicionales = new Adicional();

        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }        
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

        public string CodigoSubMenu
        {
            get { return this._CodigoSubMenu; }
            set { this._CodigoSubMenu = value; }
        }

        public string NombreSubMenu
        {
            get { return this._NombreSubMen; }
            set { this._NombreSubMen = value; }
        }

        public string CEstadoVentana
        {
            get { return this._CEstadoVentana; }
            set { this._CEstadoVentana = value; }
        }

        public string NEstadoVentana
        {
            get { return this._NEstadoVentana; }
            set { this._NEstadoVentana = value; }
        }
        
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }
    }
}
