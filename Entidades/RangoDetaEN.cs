using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class RangoDetaEN
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaRanDet = "ClaveRangoDeta";
        public const string ClaForCab = "ClaveFormulaCabe";
        //public const string DesExi = "DescripcionExistencia";
        //public const string DesExiFor = "DescripcionExistenciaFormula";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string PreProExi = "PrecioPromedioExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CorRanDet = "CorrelativoRangoDeta";
        public const string CTipDes = "CTipoDescarga";
        public const string NTipDes = "NTipoDescarga";
        public const string CTipFac = "CTipoFactor";
        public const string NTipFac = "NTipoFactor";
        public const string NumIniRanDet = "NumeroInicioRangoDeta";
        public const string NumFinRanDet = "NumeroFinalRangoDeta";
        public const string PorRanDet = "PorcentajeRangoDeta";
        public const string CEstRanDet = "CEstadoRangoDeta";
        public const string NEstRanDet = "NEstadoRangoDeta";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveRangoDeta = string.Empty;
        private string _ClaveFormulaCabe = string.Empty;
        //private string _CodigoExistenciaFormula = string.Empty;
        //private string _DescripcionExistenciaFormula = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _PrecioPromedioExistencia = 0;
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private string _CorrelativoRangoDeta = string.Empty;
        private string _CTipoDescarga = "1";
        private string _NTipoDescarga = "CALCULADA";
        private string _CTipoFactor = "0";
        private string _NTipoFactor = "Gramos";
        private decimal _NumeroInicioRangoDeta = 0;
        private decimal _NumeroFinalRangoDeta = 0;
        private decimal _PorcentajeRangoDeta = 0;
        private string _CEstadoRangoDeta = "1";
        private string _NEstadoRangoDeta = "Activado";
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

        public string ClaveRangoDeta
        {
            get { return _ClaveRangoDeta; }
            set { _ClaveRangoDeta = value; }
        }

        public string ClaveFormulaCabe
        {
            get { return _ClaveFormulaCabe; }
            set { _ClaveFormulaCabe = value; }
        }

        //public string CodigoExistenciaFormula
        //{
        //    get { return _CodigoExistenciaFormula; }
        //    set { _CodigoExistenciaFormula = value; }
        //}

        //public string DescripcionExistenciaFormula
        //{
        //    get { return _DescripcionExistenciaFormula; }
        //    set { _DescripcionExistenciaFormula = value; }
        //}

        public string CodigoEmpresa
        {
            get { return _CodigoEmpresa; }
            set { _CodigoEmpresa = value; }
        }

        public string NombreEmpresa
        {
            get { return _NombreEmpresa; }
            set { _NombreEmpresa = value; }
        }

        public string CodigoAlmacen
        {
            get { return _CodigoAlmacen; }
            set { _CodigoAlmacen = value; }
        }

        public string DescripcionAlmacen
        {
            get { return _DescripcionAlmacen; }
            set { _DescripcionAlmacen = value; }
        }

        public string CodigoExistencia
        {
            get { return _CodigoExistencia; }
            set { _CodigoExistencia = value; }
        }

        public string DescripcionExistencia
        {
            get { return _DescripcionExistencia; }
            set { _DescripcionExistencia = value; }
        }

        public decimal PrecioPromedioExistencia
        {
            get { return _PrecioPromedioExistencia; }
            set { _PrecioPromedioExistencia = value; }
        }

        public string CodigoUnidadMedida
        {
            get { return _CodigoUnidadMedida; }
            set { _CodigoUnidadMedida = value; }
        }

        public string NombreUnidadMedida
        {
            get { return _NombreUnidadMedida; }
            set { _NombreUnidadMedida = value; }
        }

        public string CorrelativoRangoDeta
        {
            get { return _CorrelativoRangoDeta; }
            set { _CorrelativoRangoDeta = value; }
        }

        public string CTipoDescarga
        {
            get { return _CTipoDescarga; }
            set { _CTipoDescarga = value; }
        }

        public string NTipoDescarga
        {
            get { return _NTipoDescarga; }
            set { _NTipoDescarga = value; }
        }

        public string CTipoFactor
        {
            get { return _CTipoFactor; }
            set { _CTipoFactor = value; }
        }

        public string NTipoFactor
        {
            get { return _NTipoFactor; }
            set { _NTipoFactor = value; }
        }

        public decimal NumeroInicioRangoDeta
        {
            get { return _NumeroInicioRangoDeta; }
            set { _NumeroInicioRangoDeta = value; }
        }

        public decimal NumeroFinalRangoDeta
        {
            get { return _NumeroFinalRangoDeta; }
            set { _NumeroFinalRangoDeta = value; }
        }

        public decimal PorcentajeRangoDeta
        {
            get { return _PorcentajeRangoDeta; }
            set { _PorcentajeRangoDeta = value; }
        }

        public string CEstadoRangoDeta
        {
            get { return _CEstadoRangoDeta; }
            set { _CEstadoRangoDeta = value; }
        }

        public string NEstadoRangoDeta
        {
            get { return _NEstadoRangoDeta; }
            set { _NEstadoRangoDeta = value; }
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
            get { return _Adicionales; }
            set { _Adicionales = value; }
        }


    }
}
