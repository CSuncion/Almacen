using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class RetiquetadoProTerEN
    {
        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaRetProTer = "ClaveRetiquetadoProTer";
        public const string ClaRet = "ClaveRetiquetado";
        public const string PerRet = "PeriodoRetiquetado";
        public const string FecRet = "FechaRetiquetado";
        public const string CodExiRE = "CodigoExistenciaRE";
        public const string CodEmp = "CodigoEmpresa";
        public const string CorRet = "CorrelativoRetiquetado";
        public const string CorRetProTer = "CorrelativoRetiquetadoProTer";
        public const string ClaProProTer = "ClaveProduccionProTer";
        public const string ClaEnc = "ClaveEncajado";
        public const string CorEnc = "CorrelativoEncajado";
        public const string FecEnc = "FechaEncajado";
        public const string CodAlm = "CodigoAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CosTotPro = "CostoTotalProducto";
        public const string DetCanSemPro = "DetalleCantidadesSemiproducto";
        public const string CanRetProTer = "CantidadRetiquetadoProTer";        
        public const string DetCanLot = "DetalleCantidadesLote";
        public const string CosUniSemPro = "CostoUnidadSemiProducto";
        public const string CosCifFij = "CostoCIFFijo";
        public const string CosManObr = "CostoManoObra";
        public const string CosCifVar = "CostoCIFVariable";
        public const string CosUniEmp = "CostoUnidadEmpaquetado";
        public const string CosEmpPri = "CostoEmpaquetadoPrincipal";
        public const string CanUniProTer = "CantidadUnidadesProTer";
        public const string CanUniReaEnc = "CantidadUnidadesRealEncajado";
        public const string CEstRetProTer = "CEstadoRetiquetadoProTer";
        public const string NEstRetProTer = "NEstadoRetiquetadoProTer";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveRetiquetadoProTer = string.Empty;
        private string _ClaveRetiquetado = string.Empty;
        private string _FechaRetiquetado = string.Empty;
        private string _PeriodoRetiquetado = string.Empty;
        private string _CodigoExistenciaRE = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CorrelativoRetiquetado = string.Empty;
        private string _CorrelativoRetiquetadoProTer = string.Empty;
        private string _ClaveProduccionProTer = string.Empty;
        private string _ClaveEncajado = string.Empty;
        private string _CorrelativoEncajado = string.Empty;
        private string _FechaEncajado = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _CostoTotalProducto = 0;
        private string _DetalleCantidadesLote = string.Empty;
        private decimal _CantidadRetiquetadoProTer = 0;
        private string _DetalleCantidadesSemiproducto = string.Empty;
        private decimal _CostoUnidadSemiProducto = 0;
        private decimal _CostoCIFFijo = 0;
        private decimal _CostoManoObra = 0;
        private decimal _CostoCIFVariable = 0;
        private decimal _CostoUnidadEmpaquetado = 0;
        private decimal _CostoEmpaquetadoPrincipal = 0;
        private decimal _CantidadUnidadesProTer = 0;
        private decimal _CantidadUnidadesRealEncajado = 0;
        private string _CEstadoRetiquetadoProTer = "1";
        private string _NEstadoRetiquetadoProTer = "Activo";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega = DateTime.Now;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica = DateTime.Now;
        private Adicional _Adicionales = new Adicional();

        #endregion

        #region Propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveRetiquetadoProTer
        {
            get { return this._ClaveRetiquetadoProTer; }
            set { this._ClaveRetiquetadoProTer = value; }
        }

        public string ClaveRetiquetado
        {
            get { return this._ClaveRetiquetado; }
            set { this._ClaveRetiquetado = value; }
        }

        public string FechaRetiquetado
        {
            get { return this._FechaRetiquetado; }
            set { this._FechaRetiquetado = value; }
        }

        public string PeriodoRetiquetado
        {
            get { return this._PeriodoRetiquetado; }
            set { this._PeriodoRetiquetado = value; }
        }

        public string CodigoExistenciaRE
        {
            get { return this._CodigoExistenciaRE; }
            set { this._CodigoExistenciaRE = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string CorrelativoRetiquetado
        {
            get { return this._CorrelativoRetiquetado; }
            set { this._CorrelativoRetiquetado = value; }
        }

        public string CorrelativoRetiquetadoProTer
        {
            get { return this._CorrelativoRetiquetadoProTer; }
            set { this._CorrelativoRetiquetadoProTer = value; }
        }

        public string ClaveProduccionProTer
        {
            get { return this._ClaveProduccionProTer; }
            set { this._ClaveProduccionProTer = value; }
        }

        public string ClaveEncajado
        {
            get { return this._ClaveEncajado; }
            set { this._ClaveEncajado = value; }
        }

        public string CorrelativoEncajado
        {
            get { return this._CorrelativoEncajado; }
            set { this._CorrelativoEncajado = value; }
        }

        public string FechaEncajado
        {
            get { return this._FechaEncajado; }
            set { this._FechaEncajado = value; }
        }

        public string CodigoAlmacen
        {
            get { return this._CodigoAlmacen; }
            set { this._CodigoAlmacen = value; }
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

        public decimal CostoTotalProducto
        {
            get { return this._CostoTotalProducto; }
            set { this._CostoTotalProducto = value; }
        }

        public string DetalleCantidadesSemiproducto
        {
            get { return this._DetalleCantidadesSemiproducto; }
            set { this._DetalleCantidadesSemiproducto = value; }
        }

        public decimal CantidadRetiquetadoProTer
        {
            get { return this._CantidadRetiquetadoProTer; }
            set { this._CantidadRetiquetadoProTer = value; }
        }

        public string DetalleCantidadesLote
        {
            get { return this._DetalleCantidadesLote; }
            set { this._DetalleCantidadesLote = value; }
        }

        public decimal CostoUnidadSemiProducto
        {
            get { return this._CostoUnidadSemiProducto; }
            set { this._CostoUnidadSemiProducto = value; }
        }

        public decimal CostoCIFFijo
        {
            get { return this._CostoCIFFijo; }
            set { this._CostoCIFFijo = value; }
        }

        public decimal CostoManoObra
        {
            get { return this._CostoManoObra; }
            set { this._CostoManoObra = value; }
        }

        public decimal CostoCIFVariable
        {
            get { return this._CostoCIFVariable; }
            set { this._CostoCIFVariable = value; }
        }

        public decimal CostoUnidadEmpaquetado
        {
            get { return this._CostoUnidadEmpaquetado; }
            set { this._CostoUnidadEmpaquetado = value; }
        }

        public decimal CostoEmpaquetadoPrincipal
        {
            get
            {
                return _CostoEmpaquetadoPrincipal;
            }

            set
            {
                _CostoEmpaquetadoPrincipal = value;
            }
        }

        public decimal CantidadUnidadesProTer
        {
            get
            {
                return _CantidadUnidadesProTer;
            }

            set
            {
                _CantidadUnidadesProTer = value;
            }
        }

        public decimal CantidadUnidadesRealEncajado
        {
            get
            {
                return _CantidadUnidadesRealEncajado;
            }

            set
            {
                _CantidadUnidadesRealEncajado = value;
            }
        }

        public string CEstadoRetiquetadoProTer
        {
            get { return this._CEstadoRetiquetadoProTer; }
            set { this._CEstadoRetiquetadoProTer = value; }
        }

        public string NEstadoRetiquetadoProTer
        {
            get { return this._NEstadoRetiquetadoProTer; }
            set { this._NEstadoRetiquetadoProTer = value; }
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

        



        #endregion


    }
}
