using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class TipoOperacionEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string CodTipOpe = "CodigoTipoOperacion";
        public const string DesTipOpe = "DescripcionTipoOperacion";
        public const string CClaTipOpe = "CClaseTipoOperacion";
        public const string NClaTipOpe = "NClaseTipoOperacion";
        public const string CCalPrePro = "CCalculaPrecioPromedio";
        public const string NCalPrePro = "NCalculaPrecioPromedio";
        public const string CConUni = "CConversionUnidad";
        public const string NConUni = "NConversionUnidad";
        public const string CEstTipOpe = "CEstadoTipoOperacion";
        public const string NEstTipOpe = "NEstadoTipoOperacion";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _CodigoTipoOperacion = string.Empty;
        private string _DescripcionTipoOperacion = string.Empty;
        private string _CClaseTipoOperacion = "1";
        private string _NClaseTipoOperacion = "Ingreso";
        private string _CCalculaPrecioPromedio = "0";
        private string _NCalculaPrecioPromedio = "No";
        private string _CConversionUnidad = "0";
        private string _NConversionUnidad = "No";
        private string _CEstadoTipoOperacion = "1";
        private string _NEstadoTipoOperacion = "Activo";
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
        
        public string CodigoTipoOperacion
        {
            get { return this._CodigoTipoOperacion; }
            set { this._CodigoTipoOperacion = value; }
        }
        
        public string DescripcionTipoOperacion
        {
            get { return this._DescripcionTipoOperacion; }
            set { this._DescripcionTipoOperacion = value; }
        }

        public string CClaseTipoOperacion
        {
            get { return this._CClaseTipoOperacion; }
            set { this._CClaseTipoOperacion = value; }
        }

        public string NClaseTipoOperacion
        {
            get { return this._NClaseTipoOperacion; }
            set { this._NClaseTipoOperacion = value; }
        }

        public string CCalculaPrecioPromedio
        {
            get { return this._CCalculaPrecioPromedio; }
            set { this._CCalculaPrecioPromedio = value; }
        }

        public string NCalculaPrecioPromedio
        {
            get { return this._NCalculaPrecioPromedio; }
            set { this._NCalculaPrecioPromedio = value; }
        }

        public string CConversionUnidad
        {
            get { return this._CConversionUnidad; }
            set { this._CConversionUnidad = value; }
        }

        public string NConversionUnidad
        {
            get { return this._NConversionUnidad; }
            set { this._NConversionUnidad = value; }
        }

        public string CEstadoTipoOperacion
        {
            get { return this._CEstadoTipoOperacion; }
            set { this._CEstadoTipoOperacion = value; }
        }
        
        public string NEstadoTipoOperacion
        {
            get { return this._NEstadoTipoOperacion; }
            set { this._NEstadoTipoOperacion = value; }
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
