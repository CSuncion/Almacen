using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class PersonalRecibenEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaPerRec = "ClavePersonalRecibe";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodPerRec = "CodigoPersonalRecibe";
        public const string NomPerRec = "NombrePersonalRecibe";
        public const string CEstPerRec = "CEstadoPersonalRecibe";
        public const string NEstPerRec = "NEstadoPersonalRecibe";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClavePersonalRecibe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoPersonalRecibe = string.Empty;
        private string _NombrePersonalRecibe = string.Empty;
        private string _CEstadoPersonalRecibe = "1";
        private string _NEstadoPersonalRecibe = "Activo";
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

        public string ClavePersonalRecibe
        {
            get { return this._ClavePersonalRecibe; }
            set { this._ClavePersonalRecibe = value; }
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
        public string CodigoPersonalRecibe
        {
            get { return this._CodigoPersonalRecibe; }
            set { this._CodigoPersonalRecibe = value; }
        }
        
        public string NombrePersonalRecibe
        {
            get { return this._NombrePersonalRecibe; }
            set { this._NombrePersonalRecibe = value; }
        }

        public string CEstadoPersonalRecibe
        {
            get { return this._CEstadoPersonalRecibe; }
            set { this._CEstadoPersonalRecibe = value; }
        }
        
        public string NEstadoPersonalRecibe
        {
            get { return this._NEstadoPersonalRecibe; }
            set { this._NEstadoPersonalRecibe = value; }
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
