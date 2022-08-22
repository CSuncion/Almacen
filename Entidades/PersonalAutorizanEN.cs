using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class PersonalAutorizanEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaPerAut = "ClavePersonalAutoriza";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodPerAut = "CodigoPersonalAutoriza";
        public const string NomPerAut = "NombrePersonalAutoriza";
        public const string CEstPerAut = "CEstadoPersonalAutoriza";
        public const string NEstPerAut = "NEstadoPersonalAutoriza";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClavePersonalAutoriza = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoPersonalAutoriza = string.Empty;
        private string _NombrePersonalAutoriza = string.Empty;
        private string _CEstadoPersonalAutoriza = "1";
        private string _NEstadoPersonalAutoriza = "Activo";
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

        public string ClavePersonalAutoriza
        {
            get { return this._ClavePersonalAutoriza; }
            set { this._ClavePersonalAutoriza = value; }
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
        public string CodigoPersonalAutoriza
        {
            get { return this._CodigoPersonalAutoriza; }
            set { this._CodigoPersonalAutoriza = value; }
        }
        
        public string NombrePersonalAutoriza
        {
            get { return this._NombrePersonalAutoriza; }
            set { this._NombrePersonalAutoriza = value; }
        }

        public string CEstadoPersonalAutoriza
        {
            get { return this._CEstadoPersonalAutoriza; }
            set { this._CEstadoPersonalAutoriza = value; }
        }
        
        public string NEstadoPersonalAutoriza
        {
            get { return this._NEstadoPersonalAutoriza; }
            set { this._NEstadoPersonalAutoriza = value; }
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
