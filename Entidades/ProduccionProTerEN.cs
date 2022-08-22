using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class ProduccionProTerEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaProProTer = "ClaveProduccionProTer";
        public const string ClaProDet = "ClaveProduccionDeta";
        public const string PerProDet = "PeriodoProduccionDeta";
        public const string ClaProCab = "ClaveProduccionCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CorProProTer = "CorrelativoProduccionProTer";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string UniPorEmp = "UnidadesPorEmpaque";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";       
        public const string NumCaj = "NumeroCajas";        
        public const string CosEmpPri = "CostoEmpaquetadoPrincipal";
        public const string CosEmpAdi = "CostoEmpaquetadoAdicional";
        public const string CosEmpDev = "CostoEmpaquetadoDevolucion";
        public const string CosEmpTot = "CostoEmpaquetadoTotal";       
        public const string CosUniEmpProTer = "CostoUnidadEmpaquetado";       
        public const string CosUniSemPro = "CostoUnidadSemiProducto";
        public const string CosIns = "CostoInsumos";
        public const string CosManObr = "CostoManoObra";
        public const string CosGasInd = "CostoGastoIndirecto";
        public const string CosOtr = "CostoOtros";
        public const string CosTotPro = "CostoTotalProducto";
        public const string UniDesEmp = "UnidadesDesechaEmpaquetado";
        public const string UniDevEmp = "UnidadesDevueltaEmpaquetado";
        public const string FacProProTer = "FactorProduccionProTer";
        public const string RatProProTer = "RatioProduccionProTer";
        public const string HorHom = "HorasHombre";
        public const string CosTotManObr = "CostoTotalManoObra";
        public const string ClaEnc = "ClaveEncajado";
        public const string CorEnc = "CorrelativoEncajado";
        public const string PerEnc = "PeriodoEncajado";
        public const string FecEnc = "FechaEncajado";
        public const string ClaSalFasEmp = "ClaveSalidaFaseEmpaquetado";
        public const string ClaSalUniEmp = "ClaveSalidaUnidadesEmpacar";
        public const string ClaIngProTer = "ClaveIngresoProductoTerminado";
        public const string CEstEnc = "CEstadoEncajado";
        public const string CanUniProTer = "CantidadUnidadesProTer";
        public const string DetCanSemPro = "DetalleCantidadesSemiProducto";
        public const string FecLotProTer = "FechaLoteProTer";
        public const string FecVenProTer = "FechaVctoProTer";
        public const string ObsProTer = "ObservacionProTer";
        public const string PriEnc = "PrioridadEncajado";
        public const string CanUniReaEnc = "CantidadUnidadesRealEncajado";
        public const string CanCajReaEnc = "CantidadCajasRealEncajado";
        public const string CanDevEnc = "CantidadDevueltaEncajado";
        public const string PorUniRan = "PorcentajeUnidadesRango";
        public const string CanUniRan = "CantidadUnidadesRango";
        public const string PorCajRan = "PorcentajeCajasRango";
        public const string CanCajRan = "CantidadCajasRango";
        public const string FacCifProTer = "FactorCifProTer";
        public const string CosGasIndFij = "CostoGastoIndirectoFijo";
        public const string CosGasIndVar = "CostoGastoIndirectoVariable";
        public const string FacCIFFij = "FactorCIFFijo";
        public const string CosCIFFij = "CostoCIFFijo";
        public const string FacCIFVar = "FactorCIFVariable";
        public const string CosCIFVar = "CostoCIFVariable";
        public const string UniAprLot = "UnidadesAprobadasLote";
        public const string UniEncLot = "UnidadesEncajadasLote";
        public const string PorEncLot = "PorcentajeEncajadoLote";
        public const string PorEncAcu = "PorcentajeEncajadoAcumulado";
        public const string CosTotVar = "CostoTotalVariable";
        public const string CosTotEnc = "CostoTotalEncajado";
        public const string CosUniEncFij = "CostoUnitarioEncajadoFijo";
        public const string CosUniEncVar = "CostoUnitarioEncajadoVariable";
        public const string CosUniEnvFij = "CostoUnitarioEnvasadoFijo";
        public const string CEleSegLib = "CEleccionSegundaLiberacion";
        public const string NEleSegLib = "NEleccionSegundaLiberacion";
        public const string ClaSalEtiSegLib = "ClaveSalidaEtiquetaSegundaLiberacion";
        public const string ClaIngSemProSegLib = "ClaveIngresoSemiProductoSegundaLiberacion";
        public const string CosEmpSegLib = "CostoEmpaquetadoSegundaLiberacion";
        public const string CEstProProTer = "CEstadoProduccionProTer";
        public const string NEstProProTer = "NEstadoProduccionProTer";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveProduccionProTer = string.Empty;
        private string _ClaveProduccionDeta = string.Empty;
        private string _PeriodoProduccionDeta = string.Empty;
        private string _ClaveProduccionCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;       
        private string _CorrelativoProduccionProTer = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _UnidadesPorEmpaque = 0;
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private string _ClaveIngresoProTer = string.Empty;       
        private decimal _NumeroCajas = 0;
        private decimal _CostoEmpaquetadoPrincipal = 0;
        private decimal _CostoEmpaquetadoAdicional = 0;
        private decimal _CostoEmpaquetadoDevolucion = 0;
        private decimal _CostoEmpaquetadoTotal = 0;      
        private decimal _CostoUnidadEmpaquetado = 0;       
        private decimal _CostoInsumos = 0;
        private decimal _CostoUnidadSemiProducto = 0;
        private decimal _CostoManoObra = 0;
        private decimal _CostoGastoIndirecto = 0;
        private decimal _CostoOtros = 0;
        private decimal _CostoTotalProducto = 0;
        private decimal _UnidadesDesechaEmpaquetado = 0;
        private decimal _UnidadesDevueltaEmpaquetado = 0;
        private decimal _FactorProduccionProTer = 0;
        private decimal _RatioProduccionProTer = 0;
        private decimal _HorasHombre = 0;
        private decimal _CostoTotalManoObra = 0;
        private string _ClaveEncajado = string.Empty;
        private string _CorrelativoEncajado = string.Empty;
        private string _PeriodoEncajado = string.Empty;
        private string _FechaEncajado = string.Empty;
        private string _ClaveSalidaFaseEmpaquetado = string.Empty;
        private string _ClaveSalidaUnidadesEmpacar = string.Empty;
        private string _ClaveIngresoProductoTerminado = string.Empty;
        private string _CEstadoEncajado = string.Empty;
        private decimal _CantidadUnidadesProTer = 0;
        private string _DetalleCantidadesSemiProducto = string.Empty;
        private string _FechaLoteProTer = string.Empty;
        private string _FechaVctoProTer = string.Empty;
        private string _ObservacionProTer = string.Empty;
        private decimal _PrioridadEncajado = 0;
        private decimal _CantidadUnidadesRealEncajado = 0;
        private decimal _CantidadCajasRealEncajado = 0;
        private decimal _CantidadDevueltaEncajado = 0;
        private decimal _PorcentajeUnidadesRango = 0;
        private decimal _CantidadUnidadesRango = 0;
        private decimal _PorcentajeCajasRango = 0;
        private decimal _CantidadCajasRango = 0;
        private decimal _FactorCifProTer = 0;
        private decimal _CostoGastoIndirectoFijo = 0;
        private decimal _CostoGastoIndirectoVariable = 0;
        private decimal _FactorCIFFijo = 0;
        private decimal _CostoCIFFijo = 0;
        private decimal _FactorCIFVariable = 0;
        private decimal _CostoCIFVariable = 0;
        private decimal _UnidadesAprobadasLote = 0;
        private decimal _UnidadesEncajadasLote = 0;
        private decimal _PorcentajeEncajadoLote = 0;
        private decimal _PorcentajeEncajadoAcumulado = 0;
        private decimal _CostoTotalVariable = 0;
        private decimal _CostoTotalEncajado = 0;
        private decimal _CostoUnitarioEncajadoFijo = 0;
        private decimal _CostoUnitarioEncajadoVariable = 0;
        private decimal _CostoUnitarioEnvasadoFijo = 0;
        private string _CEleccionSegundaLiberacion = "0";
        private string _NEleccionSegundaLiberacion = "Ninguna Accion";
        private string _ClaveSalidaEtiquetaSegundaLiberacion = string.Empty;
        private string _ClaveIngresoSemiProductoSegundaLiberacion = string.Empty;
        private decimal _CostoEmpaquetadoSegundaLiberacion = 0;
        private string _CEstadoProduccionProTer = "1";
        private string _NEstadoProduccionProTer = "Activado";
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
        
        public string ClaveProduccionProTer
        {
            get { return this._ClaveProduccionProTer; }
            set { this._ClaveProduccionProTer = value; }
        }

        public string ClaveProduccionDeta
        {
            get { return this._ClaveProduccionDeta; }
            set { this._ClaveProduccionDeta = value; }
        }

        public string PeriodoProduccionDeta
        {
            get { return this._PeriodoProduccionDeta; }
            set { this._PeriodoProduccionDeta = value; }
        }

        public string ClaveProduccionCabe
        {
            get { return this._ClaveProduccionCabe; }
            set { this._ClaveProduccionCabe = value; }
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
        
        public string CorrelativoProduccionProTer
        {
            get { return this._CorrelativoProduccionProTer; }
            set { this._CorrelativoProduccionProTer = value; }
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

        public decimal UnidadesPorEmpaque
        {
            get { return this._UnidadesPorEmpaque; }
            set { this._UnidadesPorEmpaque = value; }
        }

        public string CodigoUnidadMedida
        {
            get { return this._CodigoUnidadMedida; }
            set { this._CodigoUnidadMedida = value; }
        }

        public string NombreUnidadMedida
        {
            get { return this._NombreUnidadMedida; }
            set { this._NombreUnidadMedida = value; }
        }
        
        public string ClaveIngresoProTer
        {
            get { return this._ClaveIngresoProTer; }
            set { this._ClaveIngresoProTer = value; }
        }
       
        public decimal NumeroCajas
        {
            get { return this._NumeroCajas; }
            set { this._NumeroCajas = value; }
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

        public decimal CostoUnidadSemiProducto
        {
            get { return this._CostoUnidadSemiProducto; }
            set { this._CostoUnidadSemiProducto = value; }
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

        public decimal CostoGastoIndirecto
        {
            get { return this._CostoGastoIndirecto; }
            set { this._CostoGastoIndirecto = value; }
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

        public decimal UnidadesDesechaEmpaquetado
        {
            get { return this._UnidadesDesechaEmpaquetado; }
            set { this._UnidadesDesechaEmpaquetado = value; }
        }

        public decimal UnidadesDevueltaEmpaquetado
        {
            get { return this._UnidadesDevueltaEmpaquetado; }
            set { this._UnidadesDevueltaEmpaquetado = value; }
        }

        public decimal FactorProduccionProTer
        {
            get { return this._FactorProduccionProTer; }
            set { this._FactorProduccionProTer = value; }
        }

        public decimal RatioProduccionProTer
        {
            get { return this._RatioProduccionProTer; }
            set { this._RatioProduccionProTer = value; }
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

        public string PeriodoEncajado
        {
            get { return this._PeriodoEncajado; }
            set { this._PeriodoEncajado = value; }
        }

        public string FechaEncajado
        {
            get { return this._FechaEncajado; }
            set { this._FechaEncajado = value; }
        }

        public string ClaveSalidaFaseEmpaquetado
        {
            get { return this._ClaveSalidaFaseEmpaquetado; }
            set { this._ClaveSalidaFaseEmpaquetado = value; }
        }

        public string ClaveSalidaUnidadesEmpacar
        {
            get { return this._ClaveSalidaUnidadesEmpacar; }
            set { this._ClaveSalidaUnidadesEmpacar = value; }
        }

        public string ClaveIngresoProductoTerminado
        {
            get { return this._ClaveIngresoProductoTerminado; }
            set { this._ClaveIngresoProductoTerminado = value; }
        }

        public string CEstadoEncajado
        {
            get { return this._CEstadoEncajado; }
            set { this._CEstadoEncajado = value; }
        }

        public decimal CantidadUnidadesProTer
        {
            get { return this._CantidadUnidadesProTer; }
            set { this._CantidadUnidadesProTer = value; }
        }

        public string DetalleCantidadesSemiProducto
        {
            get { return this._DetalleCantidadesSemiProducto; }
            set { this._DetalleCantidadesSemiProducto = value; }
        }

        public string FechaLoteProTer
        {
            get { return this._FechaLoteProTer; }
            set { this._FechaLoteProTer = value; }
        }

        public string FechaVctoProTer
        {
            get { return this._FechaVctoProTer; }
            set { this._FechaVctoProTer = value; }
        }

        public string ObservacionProTer
        {
            get { return this._ObservacionProTer; }
            set { this._ObservacionProTer = value; }
        }

        public decimal PrioridadEncajado
        {
            get { return this._PrioridadEncajado; }
            set { this._PrioridadEncajado = value; }
        }

        public decimal CantidadUnidadesRealEncajado
        {
            get { return this._CantidadUnidadesRealEncajado; }
            set { this._CantidadUnidadesRealEncajado = value; }
        }

        public decimal CantidadCajasRealEncajado
        {
            get { return this._CantidadCajasRealEncajado; }
            set { this._CantidadCajasRealEncajado = value; }
        }

        public decimal CantidadDevueltaEncajado
        {
            get { return this._CantidadDevueltaEncajado; }
            set { this._CantidadDevueltaEncajado = value; }
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

        public decimal FactorCifProTer
        {
            get { return this._FactorCifProTer; }
            set { this._FactorCifProTer = value; }
        }

        public decimal CostoGastoIndirectoFijo
        {
            get { return this._CostoGastoIndirectoFijo; }
            set { this._CostoGastoIndirectoFijo = value; }
        }

        public decimal CostoGastoIndirectoVariable
        {
            get { return this._CostoGastoIndirectoVariable; }
            set { this._CostoGastoIndirectoVariable = value; }
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

        public decimal UnidadesAprobadasLote
        {
            get { return this._UnidadesAprobadasLote; }
            set { this._UnidadesAprobadasLote = value; }
        }

        public decimal UnidadesEncajadasLote
        {
            get { return this._UnidadesEncajadasLote; }
            set { this._UnidadesEncajadasLote = value; }
        }

        public decimal PorcentajeEncajadoLote
        {
            get { return this._PorcentajeEncajadoLote; }
            set { this._PorcentajeEncajadoLote = value; }
        }

        public decimal PorcentajeEncajadoAcumulado
        {
            get { return this._PorcentajeEncajadoAcumulado; }
            set { this._PorcentajeEncajadoAcumulado = value; }
        }

        public decimal CostoTotalVariable
        {
            get { return this._CostoTotalVariable; }
            set { this._CostoTotalVariable = value; }
        }

        public decimal CostoTotalEncajado
        {
            get { return this._CostoTotalEncajado; }
            set { this._CostoTotalEncajado = value; }
        }

        public decimal CostoUnitarioEncajadoFijo
        {
            get { return this._CostoUnitarioEncajadoFijo; }
            set { this._CostoUnitarioEncajadoFijo = value; }
        }

        public decimal CostoUnitarioEncajadoVariable
        {
            get { return this._CostoUnitarioEncajadoVariable; }
            set { this._CostoUnitarioEncajadoVariable = value; }
        }

        public decimal CostoUnitarioEnvasadoFijo
        {
            get { return this._CostoUnitarioEnvasadoFijo; }
            set { this._CostoUnitarioEnvasadoFijo = value; }
        }

        public string CEleccionSegundaLiberacion
        {
            get
            {
                return _CEleccionSegundaLiberacion;
            }

            set
            {
                _CEleccionSegundaLiberacion = value;
            }
        }

        public string NEleccionSegundaLiberacion
        {
            get
            {
                return _NEleccionSegundaLiberacion;
            }

            set
            {
                _NEleccionSegundaLiberacion = value;
            }
        }

        public string ClaveSalidaEtiquetaSegundaLiberacion
        {
            get
            {
                return _ClaveSalidaEtiquetaSegundaLiberacion;
            }

            set
            {
                _ClaveSalidaEtiquetaSegundaLiberacion = value;
            }
        }

        public string ClaveIngresoSemiProductoSegundaLiberacion
        {
            get
            {
                return _ClaveIngresoSemiProductoSegundaLiberacion;
            }

            set
            {
                _ClaveIngresoSemiProductoSegundaLiberacion = value;
            }
        }

        public decimal CostoEmpaquetadoSegundaLiberacion
        {
            get { return this._CostoEmpaquetadoSegundaLiberacion; }
            set { this._CostoEmpaquetadoSegundaLiberacion = value; }
        }

        public string CEstadoProduccionProTer
        {
            get { return this._CEstadoProduccionProTer; }
            set { this._CEstadoProduccionProTer = value; }
        }

        public string NEstadoProduccionProTer
        {
            get { return this._NEstadoProduccionProTer; }
            set { this._NEstadoProduccionProTer = value; }
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
