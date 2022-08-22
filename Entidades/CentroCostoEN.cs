using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class CentroCostoEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaCeCo = "ClaveCentroCosto";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodCeCo = "CodigoCentroCosto";
        public const string DesCeCo = "DescripcionCentroCosto";
        public const string CEstCeCo = "CEstadoCentroCosto";
        public const string NEstCeCo = "NEstadoCentroCosto";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveCentroCosto = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoCentroCosto = string.Empty;
        private string _DescripcionCentroCosto = string.Empty;
        private string _CEstadoCentroCosto = "1";
        private string _NEstadoCentroCosto = "Activo";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveCentroCosto
        {
            get { return this._ClaveCentroCosto; }
            set { this._ClaveCentroCosto = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string CodigoCentroCosto
        {
            get { return this._CodigoCentroCosto; }
            set { this._CodigoCentroCosto = value; }
        }
        
        public string DescripcionCentroCosto
        {
            get { return this._DescripcionCentroCosto; }
            set { this._DescripcionCentroCosto = value; }
        }

        public string CEstadoCentroCosto
        {
            get { return this._CEstadoCentroCosto; }
            set { this._CEstadoCentroCosto = value; }
        }
        
        public string NEstadoCentroCosto
        {
            get { return this._NEstadoCentroCosto; }
            set { this._NEstadoCentroCosto = value; }
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
