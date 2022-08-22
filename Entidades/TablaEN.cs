using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class TablaEN
    {
        //nombre campos
        public const string ClaObj = "ClaveObjeto";
        public const string CodTab = "CodigoTabla";
        public const string NomTab = "NombreTabla";
        public const string CatTab = "CategoriaTabla";
        public const string CEstTab = "CEstadoTabla";
        public const string NEstTab = "NEstadoTabla";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CodigoTabla = string.Empty;
        private string _NombreTabla = string.Empty;
        private string _CategoriaTabla = string.Empty;
        private string _CEstadoTabla = "1";
        private string _NEstadoTabla = "ACTIVADO";
        private Adicional _Adicionales = new Adicional();


        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string CodigoTabla
        {
            get { return this._CodigoTabla; }
            set { this._CodigoTabla = value; }
        }


        public string NombreTabla
        {
            get { return this._NombreTabla; }
            set { this._NombreTabla = value; }
        }


        public string CategoriaTabla
        {
            get { return this._CategoriaTabla; }
            set { this._CategoriaTabla = value; }
        }

        public string CEstadoTabla
        {
            get { return this._CEstadoTabla; }
            set { this._CEstadoTabla = value; }
        }

        public string NEstadoTabla
        {
            get { return this._NEstadoTabla; }
            set { this._NEstadoTabla = value; }
        }

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }

    }
}
