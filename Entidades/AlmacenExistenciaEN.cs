using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class AlmacenExistenciaEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaAlmExi = "ClaveAlmacenExistencia";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string StoTomAlmExi = "StockTomaAlmacenExistencia";
        public const string StoIniAlmExi = "StockInicialAlmacenExistencia";
        public const string StoActAlmExi = "StockActualAlmacenExistencia";
        public const string PreIniAlmExi = "PrecioInicialAlmacenExistencia";
        public const string PreProAlmExi = "PrecioPromedioAlmacenExistencia";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveAlmacenExistencia = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _StockTomaAlmacenExistencia = 0;
        private decimal _StockInicialAlmacenExistencia = 0;
        private decimal _StockActualAlmacenExistencia = 0;
        private decimal _PrecioInicialAlmacenExistencia = 0;
        private decimal _PrecioPromedioAlmacenExistencia = 0;
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

        public string ClaveAlmacenExistencia
        {
            get { return this._ClaveAlmacenExistencia; }
            set { this._ClaveAlmacenExistencia = value; }
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

        public string CodigoExistencia
        {
            get { return this._CodigoExistencia; }
            set { this._CodigoExistencia = value; }
        }

        public string DescripcionExistencia
        {
            get { return this._DescripcionExistencia; }
            set { this._DescripcionExistencia = value; }
        }

        public decimal StockTomaAlmacenExistencia
        {
            get { return this._StockTomaAlmacenExistencia; }
            set { this._StockTomaAlmacenExistencia = value; }
        }

        public decimal StockInicialAlmacenExistencia
        {
            get { return this._StockInicialAlmacenExistencia; }
            set { this._StockInicialAlmacenExistencia = value; }
        }

        public decimal StockActualAlmacenExistencia
        {
            get { return this._StockActualAlmacenExistencia; }
            set { this._StockActualAlmacenExistencia = value; }
        }

        public decimal PrecioInicialAlmacenExistencia
        {
            get { return this._PrecioInicialAlmacenExistencia; }
            set { this._PrecioInicialAlmacenExistencia = value; }
        }

        public decimal PrecioPromedioAlmacenExistencia
        {
            get { return this._PrecioPromedioAlmacenExistencia; }
            set { this._PrecioPromedioAlmacenExistencia = value; }
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
