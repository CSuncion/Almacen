using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class CuentaBancoEN
    {

        //campos nombres     	        
        public const string ClaObj = "ClaveObjeto";
        public const string ClaCtaBco = "ClaveCuentaBanco";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodCtaBco = "CodigoCuentaBanco";
        public const string CodBco = "CodigoBanco";
        public const string NomBco = "NombreBanco";
        public const string AgeCtaBco = "AgenciaCuentaBanco";
        public const string NumCtaBco = "NumeroCuentaBanco";
        public const string ClaCtaBan = "ClaveCuentaBancaria";
        public const string NumCtaBan = "NumeroCuentaBancaria";
        public const string MonCtaBco = "MonedaCuentaBanco";
        public const string NMonCtaBco = "NMonedaCuentaBanco";
        public const string TipCtaBco = "TipoCuentaBanco";
        public const string SalCtaBco = "SaldoCuentaBanco";
        public const string EstCtaBco = "EstadoCuentaBanco";
        public const string NEstCtaBco = "NEstadoCuentaBanco";
        public const string CtaCon = "CuentaContable";
        public const string ConEnv = "ConceptoEnvio";
        public const string CtaScoCtaBco = "CuentaScotiaCuentaBanco";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
        
        //atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveCuentaBanco = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoCuentaBanco = string.Empty;
        private string _CodigoBanco = string.Empty;
        private string _NombreBanco = string.Empty;
        private string _AgenciaCuentaBanco = string.Empty;
        private string _NumeroCuentaBanco = string.Empty;
        private string _ClaveCuentaBancaria = string.Empty;
        private string _NumeroCuentaBancaria = string.Empty;
        private string _MonedaCuentaBanco = "1";
        private string _NMonedaCuentaBanco = string.Empty;
        private string _TipoCuentaBanco = "1";
        private decimal _SaldoCuentaBanco = 0;
        private string _EstadoCuentaBanco = "1";
        private string _NEstadoCuentaBanco = "1";
        private string _CuentaContable = string.Empty;
        private string _ConceptoEnvio = string.Empty;
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


        public string ClaveCuentaBanco
        {
            get { return this._ClaveCuentaBanco; }
            set { this._ClaveCuentaBanco = value; }
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

        public string CodigoCuentaBanco 
        {
            get { return this._CodigoCuentaBanco; }
            set { this._CodigoCuentaBanco = value; }
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

        public string AgenciaCuentaBanco 
        {
            get { return this._AgenciaCuentaBanco; }
            set { this._AgenciaCuentaBanco = value; }
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
        
        public string MonedaCuentaBanco 
        {
            get { return this._MonedaCuentaBanco; }
            set { this._MonedaCuentaBanco = value; }
        }
        
        public string NMonedaCuentaBanco
        {
            get { return this._NMonedaCuentaBanco; }
            set { this._NMonedaCuentaBanco = value; }
        }
                
        public string TipoCuentaBanco 
        {
            get { return this._TipoCuentaBanco; }
            set { this._TipoCuentaBanco = value; }
        }

        public decimal SaldoCuentaBanco 
        {
            get { return this._SaldoCuentaBanco; }
            set { this._SaldoCuentaBanco = value; }
        }

        public string EstadoCuentaBanco
        {
            get { return this._EstadoCuentaBanco; }
            set { this._EstadoCuentaBanco = value; }
        }

        public string NEstadoCuentaBanco
        {
            get { return this._NEstadoCuentaBanco; }
            set { this._NEstadoCuentaBanco = value; }
        }

        public string CuentaContable
        {
            get { return this._CuentaContable; }
            set { this._CuentaContable = value; }
        }

        public string ConceptoEnvio
        {
            get { return this._ConceptoEnvio; }
            set { this._ConceptoEnvio = value; }
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
