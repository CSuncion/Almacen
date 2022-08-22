using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class AlmacenEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaAlm = "ClaveAlmacen";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string DirAlm = "DireccionAlmacen";
        public const string CodPer = "CodigoPersonal";
        public const string NomPer = "NombrePersonal";
        public const string CEstAlm = "CEstadoAlmacen";
        public const string NEstAlm = "NEstadoAlmacen";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveAlmacen = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _DireccionAlmacen = string.Empty;
        private string _CodigoPersonal = string.Empty;
        private string _NombrePersonal = string.Empty;
        private string _CEstadoAlmacen = "1";
        private string _NEstadoAlmacen = "Activo";
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

        public string ClaveAlmacen
        {
            get { return this._ClaveAlmacen; }
            set { this._ClaveAlmacen = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string CodigoAlmacen
        {
            get { return this._CodigoAlmacen; }
            set { this._CodigoAlmacen = value; }
        }
        
        public string DescripcionAlmacen
        {
            get { return this._DescripcionAlmacen; }
            set { this._DescripcionAlmacen = value; }
        }

        public string DireccionAlmacen
        {
            get { return this._DireccionAlmacen; }
            set { this._DireccionAlmacen = value; }
        }

        public string CodigoPersonal
        {
            get { return _CodigoPersonal; }
            set { _CodigoPersonal = value; }
        }

        public string NombrePersonal
        {
            get { return _NombrePersonal; }
            set { _NombrePersonal = value; }
        }

        public string CEstadoAlmacen
        {
            get { return this._CEstadoAlmacen; }
            set { this._CEstadoAlmacen = value; }
        }
        
        public string NEstadoAlmacen
        {
            get { return this._NEstadoAlmacen; }
            set { this._NEstadoAlmacen = value; }
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
