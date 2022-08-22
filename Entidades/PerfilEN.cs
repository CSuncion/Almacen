using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class PerfilEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string CodPer = "CodigoPerfil";
        public const string NomPer = "NombrePerfil";
        public const string DesPer = "DescripcionPerfil";
        public const string CEstPer = "CEstadoPerfil";
        public const string NEstPer = "NEstadoPerfil";
        public const string EliPer = "EliminablePerfil";        
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CodigoPerfil = string.Empty;
        private string _NombrePerfil = string.Empty;
        private string _DescripcionPerfil = string.Empty;
        private string _CEstadoPerfil = "1";
        private string _NEstadoPerfil = "PERSONALIZADO";
        private string _EliminablePerfil = "1";//si        
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


        public string CodigoPerfil
        {
            get { return this._CodigoPerfil; }
            set { this._CodigoPerfil = value; }
        }


        public string NombrePerfil
        {
            get { return this._NombrePerfil; }
            set { this._NombrePerfil = value; }
        }


        public string DescripcionPerfil
        {
            get { return this._DescripcionPerfil; }
            set { this._DescripcionPerfil = value; }
        }


        public string CEstadoPerfil
        {
            get { return this._CEstadoPerfil; }
            set { this._CEstadoPerfil = value; }
        }


        public string NEstadoPerfil
        {
            get { return this._NEstadoPerfil; }
            set { this._NEstadoPerfil = value; }
        }


        public string EliminablePerfil
        {
            get { return this._EliminablePerfil; }
            set { this._EliminablePerfil = value; }
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
