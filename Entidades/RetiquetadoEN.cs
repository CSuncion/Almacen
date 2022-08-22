using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class RetiquetadoEN
    {
        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaRet = "ClaveRetiquetado";
        public const string CodEmp = "CodigoEmpresa";
        public const string CorRet = "CorrelativoRetiquetado";
        public const string FecRet = "FechaRetiquetado";
        public const string PerRet = "PeriodoRetiquetado";
        public const string CodAlmPT = "CodigoAlmacenPT";
        public const string DesAlmPT = "DescripcionAlmacenPT";
        public const string CodExiPT = "CodigoExistenciaPT";
        public const string DesExiPT = "DescripcionExistenciaPT";
        public const string CodAlmRE = "CodigoAlmacenRE";
        public const string DesAlmRE = "DescripcionAlmacenRE";
        public const string CodExiRE = "CodigoExistenciaRE";
        public const string DesExiRE = "DescripcionExistenciaRE";
        public const string UniPorEmpRE = "UnidadesPorEmpaqueRE";
        public const string CanUniRet = "CantidadUnidadesRetiquetado";
        public const string CanCajRet = "CantidadCajasRetiquetado";
        public const string DetRetProTer = "DetalleRetiquetadoProTer";
        public const string ClaSalUniEmp = "ClaveSalidaUnidadesEmpacar";
        public const string ClaSalFasEmp = "ClaveSalidaFaseEmpaquetado";
        public const string ClaIngProTer = "ClaveIngresoProductoTerminado";
        public const string PorUniRan = "PorcentajeUnidadesRango";
        public const string CanUniRan = "CantidadUnidadesRango";
        public const string PorCajRan = "PorcentajeCajasRango";
        public const string CanCajRan = "CantidadCajasRango";
        public const string CosEmpPri = "CostoEmpaquetadoPrincipal";
        public const string CosEmpAdi = "CostoEmpaquetadoAdicional";
        public const string CosEmpDev = "CostoEmpaquetadoDevolucion";
        public const string CosEmpTot = "CostoEmpaquetadoTotal";
        public const string CosUniEmp = "CostoUnidadEmpaquetado";
        public const string CosUniEnc = "CostoUnidadEncajado";
        public const string CosIns = "CostoInsumos";
        public const string CosManObr = "CostoManoObra";
        public const string CosOtr = "CostoOtros";
        public const string CosTotPro = "CostoTotalProducto";        
        public const string FacProRet = "FactorProduccionRet";
        public const string RatProRet = "RatioProduccionRet";
        public const string HorHom = "HorasHombre";
        public const string CosTotManObr = "CostoTotalManoObra";
        public const string FacCIFFij = "FactorCIFFijo";
        public const string CosCIFFij = "CostoCIFFijo";
        public const string FacCIFVar = "FactorCIFVariable";
        public const string CosCIFVar = "CostoCIFVariable";
        public const string FecEnc = "FechaEncajado";
        public const string FecLotProTer = "FechaLoteProTer";
        public const string UniEnvRet = "UnidadesEnviadasRetiquetado";
        public const string UniRet = "UnidadesRetiquetada";
        public const string PorRetLot = "PorcentajeRetiquetadoLote";
        public const string PorRetAcu = "PorcentajeRetiquetadoAcumulado";
        public const string CosTotRet = "CostoTotalRetiquetado";
        public const string CosUniRetFij = "CostoUnitarioRetiquetadoFijo";
        public const string CosUniRetVar = "CostoUnitarioRetiquetadoVariable";
        public const string CorProCab = "CorrelativoProduccionCabe";
        public const string CosTotVar = "CostoTotalVariable";
        public const string CosUniSemPro = "CostoUnidadSemiProducto";
        public const string CosUniEnvFij = "CostoUnitarioEnvasadoFijo";
        public const string CosUniLotEnc = "CostoUnidadLoteEncajado";
        public const string CosUniLotEncFij = "CostoUnitarioLoteEncajadoFijo";
        public const string CEstRet = "CEstadoRetiquetado";
        public const string NEstRet = "NEstadoRetiquetado";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveRetiquetado = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CorrelativoRetiquetado = string.Empty;
        private string _FechaRetiquetado = string.Empty;
        private string _PeriodoRetiquetado = string.Empty;
        private string _CodigoAlmacenPT = string.Empty;
        private string _DescripcionAlmacenPT = string.Empty;
        private string _CodigoExistenciaPT = string.Empty;
        private string _DescripcionExistenciaPT = string.Empty;
        private string _CodigoAlmacenRE = string.Empty;
        private string _DescripcionAlmacenRE = string.Empty;
        private string _CodigoExistenciaRE = string.Empty;
        private string _DescripcionExistenciaRE = string.Empty;
        private decimal _UnidadesPorEmpaqueRE = 0;
        private decimal _CantidadUnidadesRetiquetado = 0;
        private decimal _CantidadCajasRetiquetado = 0;
        private string _DetalleRetiquetadoProTer = string.Empty;
        private string _ClaveSalidaUnidadesEmpacar = string.Empty;
        private string _ClaveSalidaFaseEmpaquetado = string.Empty;
        private string _ClaveIngresoProductoTerminado = string.Empty;
        private decimal _PorcentajeUnidadesRango = 0;
        private decimal _CantidadUnidadesRango = 0;
        private decimal _PorcentajeCajasRango = 0;
        private decimal _CantidadCajasRango = 0;
        private decimal _CostoEmpaquetadoPrincipal = 0;
        private decimal _CostoEmpaquetadoAdicional = 0;
        private decimal _CostoEmpaquetadoDevolucion = 0;
        private decimal _CostoEmpaquetadoTotal = 0;
        private decimal _CostoUnidadEmpaquetado = 0;
        private decimal _CostoInsumos = 0;
        private decimal _CostoUnidadEncajado = 0;
        private decimal _CostoManoObra = 0;
        private decimal _CostoOtros = 0;
        private decimal _CostoTotalProducto = 0;       
        private decimal _FactorProduccionRet = 0;
        private decimal _RatioProduccionRet = 0;
        private decimal _HorasHombre = 0;
        private decimal _CostoTotalManoObra = 0;
        private decimal _FactorCIFFijo = 0;
        private decimal _CostoCIFFijo = 0;
        private decimal _FactorCIFVariable = 0;
        private decimal _CostoCIFVariable = 0;
        private string _FechaEncajado = string.Empty;
        private string _FechaLoteProTer = string.Empty;
        private decimal _UnidadesEnviadasRetiquetado = 0;
        private decimal _UnidadesRetiquetada = 0;
        private decimal _PorcentajeRetiquetadoLote = 0;
        private decimal _PorcentajeRetiquetadoAcumulado = 0;
        private decimal _CostoTotalRetiquetado = 0;
        private decimal _CostoUnitarioRetiquetadoFijo = 0;
        private decimal _CostoUnitarioRetiquetadoVariable = 0;
        private string _CorrelativoProduccionCabe = string.Empty;
        private decimal _CostoTotalVariable = 0;
        private decimal _CostoUnidadSemiProducto = 0;
        private decimal _CostoUnitarioEnvasadoFijo = 0;
        private decimal _CostoUnidadLoteEncajado = 0;
        private decimal _CostoUnitarioLoteEncajadoFijo = 0;
        private string _CEstadoRetiquetado = "0";
        private string _NEstadoRetiquetado = "Pendiente";
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

        public string ClaveRetiquetado
        {
            get { return this._ClaveRetiquetado; }
            set { this._ClaveRetiquetado = value; }
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

        public string CodigoAlmacenPT
        {
            get { return this._CodigoAlmacenPT; }
            set { this._CodigoAlmacenPT = value; }
        }

        public string DescripcionAlmacenPT
        {
            get { return this._DescripcionAlmacenPT; }
            set { this._DescripcionAlmacenPT = value; }
        }

        public string CodigoExistenciaPT
        {
            get { return this._CodigoExistenciaPT; }
            set { this._CodigoExistenciaPT = value; }
        }

        public string DescripcionExistenciaPT
        {
            get { return this._DescripcionExistenciaPT; }
            set { this._DescripcionExistenciaPT = value; }
        }

        public string CodigoAlmacenRE
        {
            get { return this._CodigoAlmacenRE; }
            set { this._CodigoAlmacenRE = value; }
        }

        public string DescripcionAlmacenRE
        {
            get { return this._DescripcionAlmacenRE; }
            set { this._DescripcionAlmacenRE = value; }
        }

        public string CodigoExistenciaRE
        {
            get { return this._CodigoExistenciaRE; }
            set { this._CodigoExistenciaRE = value; }
        }

        public string DescripcionExistenciaRE
        {
            get { return this._DescripcionExistenciaRE; }
            set { this._DescripcionExistenciaRE = value; }
        }

        public decimal UnidadesPorEmpaqueRE
        {
            get { return this._UnidadesPorEmpaqueRE; }
            set { this._UnidadesPorEmpaqueRE = value; }
        }

        public decimal CantidadUnidadesRetiquetado
        {
            get { return this._CantidadUnidadesRetiquetado; }
            set { this._CantidadUnidadesRetiquetado = value; }
        }

        public decimal CantidadCajasRetiquetado
        {
            get { return this._CantidadCajasRetiquetado; }
            set { this._CantidadCajasRetiquetado = value; }
        }

        public string DetalleRetiquetadoProTer
        {
            get { return this._DetalleRetiquetadoProTer; }
            set { this._DetalleRetiquetadoProTer = value; }
        }

        public string ClaveSalidaUnidadesEmpacar
        {
            get { return this._ClaveSalidaUnidadesEmpacar; }
            set { this._ClaveSalidaUnidadesEmpacar = value; }
        }

        public string ClaveSalidaFaseEmpaquetado
        {
            get { return this._ClaveSalidaFaseEmpaquetado; }
            set { this._ClaveSalidaFaseEmpaquetado = value; }
        }

        public string ClaveIngresoProductoTerminado
        {
            get { return this._ClaveIngresoProductoTerminado; }
            set { this._ClaveIngresoProductoTerminado = value; }
        }

        public decimal PorcentajeUnidadesRango
        {
            get { return this._PorcentajeUnidadesRango; }
            set { this._PorcentajeUnidadesRango = value; }
        }

        public decimal CantidadUnidadesRango
        {
            get { return this._CantidadUnidadesRango; }
            set { this._CantidadUnidadesRango = value; }
        }

        public decimal PorcentajeCajasRango
        {
            get { return this._PorcentajeCajasRango; }
            set { this._PorcentajeCajasRango = value; }
        }

        public decimal CantidadCajasRango
        {
            get { return this._CantidadCajasRango; }
            set { this._CantidadCajasRango = value; }
        }

        public decimal CostoEmpaquetadoPrincipal
        {
            get { return this._CostoEmpaquetadoPrincipal; }
            set { this._CostoEmpaquetadoPrincipal = value; }
        }

        public decimal CostoEmpaquetadoAdicional
        {
            get { return this._CostoEmpaquetadoAdicional; }
            set { this._CostoEmpaquetadoAdicional = value; }
        }

        public decimal CostoEmpaquetadoDevolucion
        {
            get { return this._CostoEmpaquetadoDevolucion; }
            set { this._CostoEmpaquetadoDevolucion = value; }
        }

        public decimal CostoEmpaquetadoTotal
        {
            get { return this._CostoEmpaquetadoTotal; }
            set { this._CostoEmpaquetadoTotal = value; }
        }

        public decimal CostoUnidadEmpaquetado
        {
            get { return this._CostoUnidadEmpaquetado; }
            set { this._CostoUnidadEmpaquetado = value; }
        }

        public decimal CostoUnidadEncajado
        {
            get { return this._CostoUnidadEncajado; }
            set { this._CostoUnidadEncajado = value; }
        }

        public decimal CostoInsumos
        {
            get { return this._CostoInsumos; }
            set { this._CostoInsumos = value; }
        }

        public decimal CostoManoObra
        {
            get { return this._CostoManoObra; }
            set { this._CostoManoObra = value; }
        }

        public decimal CostoOtros
        {
            get { return this._CostoOtros; }
            set { this._CostoOtros = value; }
        }

        public decimal CostoTotalProducto
        {
            get { return this._CostoTotalProducto; }
            set { this._CostoTotalProducto = value; }
        }

        public decimal FactorProduccionRet
        {
            get { return this._FactorProduccionRet; }
            set { this._FactorProduccionRet = value; }
        }

        public decimal RatioProduccionRet
        {
            get { return this._RatioProduccionRet; }
            set { this._RatioProduccionRet = value; }
        }

        public decimal HorasHombre
        {
            get { return this._HorasHombre; }
            set { this._HorasHombre = value; }
        }

        public decimal CostoTotalManoObra
        {
            get { return this._CostoTotalManoObra; }
            set { this._CostoTotalManoObra = value; }
        }

        public decimal FactorCIFFijo
        {
            get { return this._FactorCIFFijo; }
            set { this._FactorCIFFijo = value; }
        }

        public decimal CostoCIFFijo
        {
            get { return this._CostoCIFFijo; }
            set { this._CostoCIFFijo = value; }
        }

        public decimal FactorCIFVariable
        {
            get { return this._FactorCIFVariable; }
            set { this._FactorCIFVariable = value; }
        }

        public decimal CostoCIFVariable
        {
            get { return this._CostoCIFVariable; }
            set { this._CostoCIFVariable = value; }
        }

        public string FechaEncajado
        {
            get { return this._FechaEncajado; }
            set { this._FechaEncajado = value; }
        }

        public string FechaLoteProTer
        {
            get { return this._FechaLoteProTer; }
            set { this._FechaLoteProTer = value; }
        }

        public decimal UnidadesEnviadasRetiquetado
        {
            get { return this._UnidadesEnviadasRetiquetado; }
            set { this._UnidadesEnviadasRetiquetado = value; }
        }

        public decimal UnidadesRetiquetada
        {
            get { return this._UnidadesRetiquetada; }
            set { this._UnidadesRetiquetada = value; }
        }

        public decimal PorcentajeRetiquetadoLote
        {
            get { return this._PorcentajeRetiquetadoLote; }
            set { this._PorcentajeRetiquetadoLote = value; }
        }

        public decimal PorcentajeRetiquetadoAcumulado
        {
            get { return this._PorcentajeRetiquetadoAcumulado; }
            set { this._PorcentajeRetiquetadoAcumulado = value; }
        }

        public decimal CostoTotalRetiquetado
        {
            get { return this._CostoTotalRetiquetado; }
            set { this._CostoTotalRetiquetado = value; }
        }

        public decimal CostoUnitarioRetiquetadoFijo
        {
            get { return this._CostoUnitarioRetiquetadoFijo; }
            set { this._CostoUnitarioRetiquetadoFijo = value; }
        }

        public decimal CostoUnitarioRetiquetadoVariable
        {
            get { return this._CostoUnitarioRetiquetadoVariable; }
            set { this._CostoUnitarioRetiquetadoVariable = value; }
        }

        public string CorrelativoProduccionCabe
        {
            get { return this._CorrelativoProduccionCabe; }
            set { this._CorrelativoProduccionCabe = value; }
        }

        public decimal CostoTotalVariable
        {
            get { return this._CostoTotalVariable; }
            set { this._CostoTotalVariable = value; }
        }

        public decimal CostoUnidadSemiProducto
        {
            get { return this._CostoUnidadSemiProducto; }
            set { this._CostoUnidadSemiProducto = value; }
        }

        public decimal CostoUnitarioEnvasadoFijo
        {
            get { return this._CostoUnitarioEnvasadoFijo; }
            set { this._CostoUnitarioEnvasadoFijo = value; }
        }
        
        public decimal CostoUnidadLoteEncajado
        {
            get { return this._CostoUnidadLoteEncajado; }
            set { this._CostoUnidadLoteEncajado = value; }
        }

        public decimal CostoUnitarioLoteEncajadoFijo
        {
            get { return this._CostoUnitarioLoteEncajadoFijo; }
            set { this._CostoUnitarioLoteEncajadoFijo = value; }
        }

        public string CEstadoRetiquetado
        {
            get { return this._CEstadoRetiquetado; }
            set { this._CEstadoRetiquetado = value; }
        }

        public string NEstadoRetiquetado
        {
            get { return this._NEstadoRetiquetado; }
            set { this._NEstadoRetiquetado = value; }
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
