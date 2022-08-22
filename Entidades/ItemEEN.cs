using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class ItemEEN
    {

        //campo nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaIteE = "ClaveItemE";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodTab = "CodigoTabla";
        public const string NomTab = "NombreTabla";
        public const string CodIteE = "CodigoItemE";
        public const string NomIteE = "NombreItemE";
        public const string AbrIteE = "AbreviaItemE";
        public const string CEstIteE = "CEstadoItemE";
        public const string NEstIteE = "NEstadoItemE";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
    
        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveItemE = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoTabla = string.Empty;
        private string _NombreTabla = string.Empty;
        private string _CodigoItemE = string.Empty;
        private string _NombreItemE = string.Empty;
        private string _AbreviaItemE = string.Empty;
        private string _CEstadoItemE = "1";//activado
        private string _NEstadoItemE = string.Empty;
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional( );

        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveItemE
        {
            get { return this._ClaveItemE; }
            set { this._ClaveItemE = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string NombreEmpresa
        {
            get { return this._NombreEmpresa; }
            set { this._NombreEmpresa = value; }
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
        
        public string CodigoItemE
        {
            get { return this._CodigoItemE; }
            set { this._CodigoItemE = value; }
        }
        
        public string NombreItemE
        {
            get { return this._NombreItemE; }
            set { this._NombreItemE = value; }
        }
        
        public string AbreviaItemE
        {
            get { return this._AbreviaItemE; }
            set { this._AbreviaItemE = value; }
        }
        
        public string CEstadoItemE
        {
            get { return this._CEstadoItemE; }
            set { this._CEstadoItemE = value; }
        }
        
        public string NEstadoItemE
        {
            get { return this._NEstadoItemE; }
            set { this._NEstadoItemE = value; }
        }
        
        public string UsuarioAgrega
        {
            get { return this._UsuarioAgrega; }
            set { this._UsuarioAgrega = value; }
        }
        
        public DateTime FechaAgrega
        {
            get { return this._FechaAgrega; }
            set { this._FechaAgrega = value; }
        }
        
        public string UsuarioModifica
        {
            get { return this._UsuarioModifica; }
            set { this._UsuarioModifica = value; }
        }
        
        public DateTime FechaModifica
        {
            get { return this._FechaModifica; }
            set { this._FechaModifica = value; }
        }
        
        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }


    }
}
