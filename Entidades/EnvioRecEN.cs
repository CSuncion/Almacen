using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class EnvioRecEN
    {

        //campos nombres     	        
        public const string ClaObj = "ClaveObjeto";
        public const string ClaEnvRec = "ClaveEnvioRec";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string RucEmp = "RucEmpresa";
        public const string CorEnvRec = "CorrelativoEnvioRec";
        public const string CodCtaBco = "CodigoCuentaBanco";
        public const string ClaCtaBco = "ClaveCuentaBanco";
        public const string CodBco = "CodigoBanco";
        public const string NomBco = "NombreBanco";
        public const string NumCtaBco = "NumeroCuentaBanco";
        public const string ClaCtaBan = "ClaveCuentaBancaria";
        public const string NumCtaBan = "NumeroCuentaBancaria";
        public const string NMonCtaBco = "NMonedaCuentaBanco";
        public const string ConEnv = "ConceptoEnvio";
        public const string FecEnvRec = "FechaEnvioRec";
        public const string FlaEnvRec = "FlagEnvioRec";
        public const string CEstEnvRec = "CEstadoEnvioRec";
        public const string NEstEnvRec = "NEstadoEnvioRec";
        public const string CtaScoCtaBco = "CuentaScotiaCuentaBanco";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveEnvioRec = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _RucEmpresa = string.Empty;
        private string _CorrelativoEnvioRec = string.Empty;
        private string _CodigoCuentaBanco = string.Empty;
        private string _ClaveCuentaBanco = string.Empty;
        private string _CodigoBanco = string.Empty;
        private string _NombreBanco = string.Empty;
        private string _NumeroCuentaBanco = string.Empty;
        private string _ClaveCuentaBancaria = string.Empty;
        private string _NumeroCuentaBancaria = string.Empty;
        private string _NMonedaCuentaBanco = string.Empty;
        private string _ConceptoEnvio = string.Empty;
        private string _FechaEnvioRec = string.Empty;
        private string _FlagEnvioRec = string.Empty;
        private string _CEstadoEnvioRec = "0";
        private string _NEstadoEnvioRec = "Preparando";
        private string _CuentaScotiaCuentaBanco = string.Empty;
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
        
        public string ClaveEnvioRec 
        {
            get { return this._ClaveEnvioRec; }
            set { this._ClaveEnvioRec = value; }
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

        public string RucEmpresa
        {
            get { return this._RucEmpresa; }
            set { this._RucEmpresa = value; }
        }

        public string CorrelativoEnvioRec
        {
            get { return this._CorrelativoEnvioRec; }
            set { this._CorrelativoEnvioRec = value; }
        }

        public string CodigoCuentaBanco
        {
            get { return this._CodigoCuentaBanco; }
            set { this._CodigoCuentaBanco = value; }
        }

        public string ClaveCuentaBanco
        {
            get { return this._ClaveCuentaBanco; }
            set { this._ClaveCuentaBanco = value; }
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

        public string NumeroCuentaBanco 
        {
            get { return this._NumeroCuentaBanco; }
            set { this._NumeroCuentaBanco = value; }
        }

        public string ClaveCuentaBancaria
        {
            get { return this._ClaveCuentaBancaria; }
            set { this._ClaveCuentaBancaria = value; }
        }

        public string NumeroCuentaBancaria
        {
            get { return this._NumeroCuentaBancaria; }
            set { this._NumeroCuentaBancaria = value; }
        }

        public string NMonedaCuentaBanco
        {
            get { return this._NMonedaCuentaBanco; }
            set { this._NMonedaCuentaBanco = value; }
        }

        public string ConceptoEnvio
        {
            get { return this._ConceptoEnvio; }
            set { this._ConceptoEnvio = value; }
        }

        public string FechaEnvioRec 
        {
            get { return this._FechaEnvioRec; }
            set { this._FechaEnvioRec = value; }
        }

        public string FlagEnvioRec 
        {
            get { return this._FlagEnvioRec; }
            set { this._FlagEnvioRec = value; }
        }
                       
        public string CEstadoEnvioRec 
        {
            get { return this._CEstadoEnvioRec; }
            set { this._CEstadoEnvioRec = value; }
        }

        public string NEstadoEnvioRec
        {
            get { return this._NEstadoEnvioRec; }
            set { this._NEstadoEnvioRec = value; }
        }

        public string CuentaScotiaCuentaBanco
        {
            get { return this._CuentaScotiaCuentaBanco; }
            set { this._CuentaScotiaCuentaBanco = value; }
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
