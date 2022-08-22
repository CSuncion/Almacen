using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class LicitacionEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaLic = "ClaveLicitacion";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string CodLic = "CodigoLicitacion";
        public const string DesLic = "DescripcionLicitacion";
        public const string FecLic = "FechaLicitacion";
        public const string PerLic = "PeriodoLicitacion";
        public const string CEstLic = "CEstadoLicitacion";
        public const string NEstLic = "NEstadoLicitacion";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveLicitacion = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _CodigoLicitacion = string.Empty;
        private string _DescripcionLicitacion = string.Empty;
        private string _FechaLicitacion = string.Empty;
        private string _PeriodoLicitacion = string.Empty;
        private string _CEstadoLicitacion = "1";
        private string _NEstadoLicitacion = "Activo";
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

        public string ClaveLicitacion
        {
            get { return this._ClaveLicitacion; }
            set { this._ClaveLicitacion = value; }
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

        public string CodigoAuxiliar
        {
            get { return this._CodigoAuxiliar; }
            set { this._CodigoAuxiliar = value; }
        }
        
        public string DescripcionAuxiliar
        {
            get { return this._DescripcionAuxiliar; }
            set { this._DescripcionAuxiliar = value; }
        }

        public string CodigoLicitacion
        {
            get { return this._CodigoLicitacion; }
            set { this._CodigoLicitacion = value; }
        }

        public string DescripcionLicitacion
        {
            get { return this._DescripcionLicitacion; }
            set { this._DescripcionLicitacion = value; }
        }

        public string FechaLicitacion
        {
            get { return this._FechaLicitacion; }
            set { this._FechaLicitacion = value; }
        }

        public string PeriodoLicitacion
        {
            get { return this._PeriodoLicitacion; }
            set { this._PeriodoLicitacion = value; }
        }

        public string CEstadoLicitacion
        {
            get { return this._CEstadoLicitacion; }
            set { this._CEstadoLicitacion = value; }
        }
        
        public string NEstadoLicitacion
        {
            get { return this._NEstadoLicitacion; }
            set { this._NEstadoLicitacion = value; }
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
