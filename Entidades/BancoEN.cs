using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class BancoEN
    {

        //campos nombres     	        
        public const string ClaObj = "ClaveObjeto";
        public const string CodBco = "CodigoBanco";
        public const string NomBco = "NombreBanco";
        public const string CodSun = "CodigoSunat";
        public const string CEstBco = "CEstadoBanco";
        public const string NEstBco = "NEstadoBanco";
        public const string CRecBco = "CRecaudaBanco";
        public const string NRecBco = "NRecaudaBanco";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos

        private string _ClaveObjeto = string.Empty;
        private string _CodigoBanco = string.Empty;
        private string _NombreBanco = string.Empty;
        private string _CodigoSunat = string.Empty;
        private string _CEstadoBanco = "1";
        private string _NEstadoBanco = "Activo";
        private string _CRecaudaBanco = "0";
        private string _NRecaudaBanco = "No";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        //propiedades


        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }


        public string CodigoBanco 
        {
            get { return this._CodigoBanco; }
            set { this._CodigoBanco = value; }
        }

        public string NombreBanco 
        {
            get { return this._NombreBanco; }
            set { this._NombreBanco = value; }
        }

        public string CodigoSunat 
        {
            get { return this._CodigoSunat; }
            set { this._CodigoSunat = value; }
        }


        public string CEstadoBanco 
        {
            get { return this._CEstadoBanco; }
            set { this._CEstadoBanco = value; }
        }

        public string NEstadoBanco
        {
            get { return this._NEstadoBanco; }
            set { this._NEstadoBanco = value; }
        }

        public string CRecaudaBanco
        {
            get { return this._CRecaudaBanco; }
            set { this._CRecaudaBanco = value; }
        }

        public string NRecaudaBanco
        {
            get { return this._NRecaudaBanco; }
            set { this._NRecaudaBanco = value; }
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
