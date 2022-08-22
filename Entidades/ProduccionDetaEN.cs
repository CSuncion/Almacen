using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class ProduccionDetaEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaProDet = "ClaveProduccionDeta";
        public const string ClaProCab = "ClaveProduccionCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CorProCab = "CorrelativoProduccionCabe";
        public const string CorProDet = "CorrelativoProduccionDeta";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CodTipOpe = "CodigoTipoOperacion";
        public const string DesTipOpe = "DescripcionTipoOperacion";
        public const string FecProDet = "FechaProduccionDeta";
        public const string PerProDet = "PeriodoProduccionDeta";
        public const string FecSalFasMas = "FechaSalidaFaseMasa";
        public const string FecSalFasConCal = "FechaSalidaFaseControlCalidad";
        public const string FecSalFasEmp = "FechaSalidaFaseEmpaquetado";
        public const string FecIngAlm = "FechaIngresoAlmacen";        
        public const string SalProCab = "SaldoProduccionCabe";
        public const string CanProDet = "CantidadProduccionDeta";
        public const string CanReaPro = "CantidadRealProduccion";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string ObsProDet = "ObservacionProduccionDeta";
        public const string ClaSalFasMas = "ClaveSalidaFaseMasa";
        public const string ClaSalFasConCal = "ClaveSalidaFaseControlCalidad";
        public const string ClaSalFasEmp = "ClaveSalidaFaseEmpaquetado";
        public const string ClaIngMovCab = "ClaveIngresoMovimientoCabe";
        public const string CodMer = "CodigoMercaderia";
        public const string CodAlmSemPro = "CodigoAlmacenSemiProducto";
        public const string CodSemPro = "CodigoSemiProducto";
        public const string DesSemPro = "DescripcionSemiProducto";
        public const string CodAlmEmp = "CodigoAlmacenEmpaquetado";
        public const string DesAlmEmp = "DescripcionAlmacenEmpaquetado";
        public const string RatForCab = "RatioFormulaCabe";
        public const string CEsExa = "CEsExacto";
        public const string CosTotPro = "CostoTotalProducto";
        public const string CosMasPri = "CostoMasaPrincipal";
        public const string CosMasAdi = "CostoMasaAdicional";
        public const string CosMasDev = "CostoMasaDevolucion";
        public const string CosMasTot = "CostoMasaTotal";
        public const string MasPro = "MasaProducida";
        public const string MasUni = "MasaUnidad";
        public const string NumUniMas = "NumeroUnidadesMasa";
        public const string CosUniMas = "CostoUnidadMasa";
        public const string MasPer = "MasaPerdida";
        public const string CosMasPer = "CostoMasaPerdida";
        public const string CosConCalPri = "CostoConCalPrincipal";
        public const string CosConCalAdi = "CostoConCalAdicional";
        public const string CosConCalDev = "CostoConCalDevolucion";
        public const string CosConCalTot = "CostoConCalTotal";
        public const string NumUniConCal = "NumeroUnidadesConCal";
        public const string NumUniNoPasConCal = "NumeroUnidadesNoPasanConCal";
        public const string CosUniConCal = "CostoUnidadConCal";
        public const string NumUniProAnt = "NumeroUnidadesProduccionAnterior";
        public const string ClaSalUniEmp = "ClaveSalidaUnidadesEmpacar";
        public const string ClaSalNoPas = "ClaveSalidaNoPasan";
        public const string ClaIngNoPas = "ClaveIngresoNoPasan";
        public const string UniPorCaj = "UnidadesPorCaja";
        public const string NumCaj = "NumeroCajas";
        public const string NumUniSue = "NumeroUnidadesSueltas";
        public const string ClaIngSemEla = "ClaveIngresoSemiElaborado";
        public const string CosEmpSemElaPri = "CostoEmpaquetadoSemElaPrincipal";
        public const string CosEmpSemElaAdi = "CostoEmpaquetadoSemElaAdicional";
        public const string CosEmpSemElaDev = "CostoEmpaquetadoSemElaDevolucion";
        public const string CosEmpSemElaTot = "CostoEmpaquetadoSemElaTotal";
        public const string CosUniEmpSemEla = "CostoUnidadEmpaquetadoSemEla";
        public const string CosUniEmpProTer = "CostoUnidadEmpaquetadoProTer";
        public const string CosUniTotSemEla = "CostoUnidadTotalSemEla";
        public const string NumUniAEmp = "NumeroUnidadesAEmpaquetar";
        public const string CosIns = "CostoInsumos";
        public const string CosManObr = "CostoManoObra";
        public const string CosOtr = "CostoOtros";
        public const string UniDesEmp = "UnidadesDesechaEmpaquetado";
        public const string UniDevEmp = "UnidadesDevueltaEmpaquetado";
        public const string ObsMasPer = "ObservacionMasaPerdida";
        public const string UniRep = "UnidadesReproceso";
        public const string CosUniRep = "CostoUnidadesReproceso";
        public const string ClaSalUniRep = "ClaveSalidaUnidadesReproceso";
        public const string UniParRep = "UnidadesParaReproceso";
        public const string NumUniSemEla = "NumeroUnidadesSemiElaborado";        
        public const string CTur = "CTurno";
        public const string NTur = "NTurno";
        public const string NumTraAut = "NumeroTransferenciaAutomatica";
        public const string VerFal = "VerdadFalso";
        public const string ClaSalTraRep = "ClaveSalidaTransferenciaReproceso";
        public const string ClaIngTraRep = "ClaveIngresoTransferenciaReproceso";
        public const string SalUniAEmp = "SaldoUnidadesAEmpacar";
        public const string UniDon = "UnidadesDonacion";
        public const string ClaSalTraDon = "ClaveSalidaTransferenciaDonacion";
        public const string ClaIngTraDon = "ClaveIngresoTransferenciaDonacion";
        public const string SalLib = "SaldoLiberacion";
        public const string UniAprLib = "UnidadesAprobadasLiberacion";
        public const string UniSalLib = "UnidadesSaldoLiberacion";
        public const string UniObsLib = "UnidadesObservadasLiberacion";
        public const string UniRepLib = "UnidadesReprocesoLiberacion";
        public const string UniDonLib = "UnidadesDonacionLiberacion";
        public const string UniMueLib = "UnidadesMuestraLiberacion";
        public const string UniDesLib = "UnidadesDesechasLiberacion";
        public const string PorRan = "PorcentajeRango";
        public const string CanRan = "CantidadRango";
        public const string ClaIngDesEnv = "ClaveIngresoDesmedroEnvasado";
        public const string FacProProDet = "FactorProduccionProDet";
        public const string RatProProDet = "RatioProduccionProDet";
        public const string HorHom = "HorasHombre";
        public const string CosTotManObr = "CostoTotalManoObra";
        public const string FacCIFFij = "FactorCIFFijo";
        public const string CosCIFFij = "CostoCIFFijo";
        public const string FacCIFVar = "FactorCIFVariable";
        public const string CosCIFVar = "CostoCIFVariable";
        public const string CosTotVar = "CostoTotalVariable";
        public const string CosTotEnv = "CostoTotalEnvasado";
        public const string CosUniAprLib = "CostoUnidadesAprobadasLiberacion";
        public const string CosUniRepLib = "CostoUnidadesReprocesoLiberacion";        
        public const string CosUniDesLib = "CostoUnidadesDesechasLiberacion";
        public const string CosUniDonLib = "CostoUnidadesDonacionLiberacion";
        public const string CosUniMueLib = "CostoUnidadesMuestraLiberacion";
        public const string CosUniObsLib = "CostoUnidadesObservadasLiberacion";
        public const string CosUniPorLibLib = "CostoUnidadesPorLiberarLiberacion";
        public const string CosUniPorDesLib = "CostoUnidadesPorDesbloquearLiberacion";
        public const string PorUniDesLib = "PorcentajeUnidadesDesechasLiberacion";
        public const string CanSinProDet = "CantidadSinceradoProduccionDeta";
        public const string PorSinRan = "PorcentajeSinceradoRango";
        public const string CanSinRan = "CantidadSinceradoRango";
        public const string DetMotSin = "DetalleMotivoSincerado";
        public const string ClaTraSin = "ClavesTransferenciaSincerado";
        public const string CanEnc = "CantidadEncajonar";
        public const string CanBlo = "CantidadBloquear";
        public const string SalLibBlo = "SaldoLiberacionBloqueadas";
        public const string ClaIngSemElaBlo = "ClaveIngresoSemElaBloqueadas";
        public const string CanConMue = "CantidadContraMuestra";
        public const string ClaIngSemElaConMue = "ClaveIngresoSemElaContraMuestra";
        public const string CanCuaQal = "CantidadCuarentenaQali";
        public const string CanRepQal = "CantidadReprocesoQali";
        public const string CanMueQal = "CantidadMuestraQali";
        public const string CanDesQal = "CantidadDesechoQali";
        public const string SalLibCuaQal = "SaldoLiberacionCuarentenaQali";
        public const string ClaIngCuaQal = "ClaveIngresoCuarentenaQali";
        public const string ClaIngRepQal = "ClaveIngresoReprocesoQali";
        public const string ClaIngMueQal = "ClaveIngresoMuestraQali";
        public const string ClaIngDesQal = "ClaveIngresoDesechoQali";
        public const string ClaSalEtiQal = "ClaveSalidaEtiquetaQali";
        public const string CManCua = "CManejaCuarentena";
        public const string DetMovRepQal = "DetalleMotivoReprocesoQali";
        public const string DetMovMueQal = "DetalleMotivoMuestraQali";
        public const string DetMovDesQal = "DetalleMotivoDesechoQali";
        public const string DetMovMuePreLib = "DetalleMotivoMuestraPreLiberacion";
        public const string DetMovBloPreLib = "DetalleMotivoBloqueadosPreLiberacion";
        public const string CanUniPacAdiBlo = "CantidadUnidadesPackingAdicionalesBlo";
        public const string TotEnvDes = "TotalEnvasesDesmedro";
        public const string PorEnvDes = "PorcentajeEnvasesDesmedro";
        public const string SalLibObs = "SaldoLiberacionObservadas";
        public const string CanUniPacAdiObs = "CantidadUnidadesPackingAdicionalesObs";
        public const string CanMuePro = "CantidadMuestraProduccion";
        public const string DetMovMuePro = "DetalleMotivoMuestraProduccion";
        public const string ClaIngSemElaMuePro = "ClaveIngresoSemElaMuestraProduccion";
        public const string CEstProDet = "CEstadoProduccionDeta";
        public const string NEstProDet = "NEstadoProduccionDeta";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveProduccionDeta = string.Empty;
        private string _ClaveProduccionCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CorrelativoProduccionCabe = string.Empty;
        private string _CorrelativoProduccionDeta = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty; 
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private string _CodigoTipoOperacion = string.Empty;
        private string _DescripcionTipoOperacion = string.Empty;
        private string _FechaProduccionDeta = string.Empty;
        private string _PeriodoProduccionDeta = string.Empty;
        private string _FechaSalidaFaseMasa = string.Empty;
        private string _FechaSalidaFaseControlCalidad = string.Empty;
        private string _FechaSalidaFaseEmpaquetado = string.Empty;
        private string _FechaIngresoAlmacen = string.Empty;
        private decimal _SaldoProduccionCabe = 0;
        private decimal _CantidadProduccionDeta = 0;
        private decimal _CantidadRealProduccion = 0;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _ObservacionProduccionDeta = string.Empty;
        private string _ClaveSalidaFaseMasa = string.Empty;
        private string _ClaveSalidaFaseControlCalidad = string.Empty;
        private string _ClaveSalidaFaseEmpaquetado = string.Empty;
        private string _ClaveIngresoMovimientoCabe = string.Empty;
        private string _CodigoMercaderia = string.Empty;
        private string _CodigoAlmacenSemiProducto = string.Empty;
        private string _CodigoSemiProducto = string.Empty;
        private string _DescripcionSemiProducto = string.Empty;
        private string _CodigoAlmacenEmpaquetado = string.Empty;
        private string _DescripcionAlmacenEmpaquetado = string.Empty;
        private decimal _RatioFormulaCabe = 0;
        private string _CEsExacto = "1";//si
        private decimal _CostoTotalProducto = 0;
        private decimal _CostoMasaPrincipal = 0;
        private decimal _CostoMasaAdicional = 0;
        private decimal _CostoMasaDevolucion = 0;
        private decimal _CostoMasaTotal = 0;
        private decimal _MasaProducida = 0;
        private decimal _MasaUnidad = 0;
        private decimal _NumeroUnidadesMasa = 0;
        private decimal _CostoUnidadMasa = 0;
        private decimal _MasaPerdida = 0;
        private decimal _CostoMasaPerdida = 0;
        private decimal _CostoConCalPrincipal = 0;
        private decimal _CostoConCalAdicional = 0;
        private decimal _CostoConCalDevolucion = 0;
        private decimal _CostoConCalTotal = 0;
        private decimal _NumeroUnidadesConCal = 0;
        private decimal _NumeroUnidadesNoPasanConCal = 0;
        private decimal _CostoUnidadConCal = 0;
        private decimal _NumeroUnidadesProduccionAnterior = 0;
        private string _ClaveSalidaUnidadesEmpacar = string.Empty;
        private string _ClaveSalidaNoPasan = string.Empty;
        private string _ClaveIngresoNoPasan = string.Empty;
        private decimal _UnidadesPorCaja = 0;
        private decimal _NumeroCajas = 0;
        private decimal _NumeroUnidadesSueltas = 0;
        private string _ClaveIngresoSemiElaborado = string.Empty;
        private decimal _CostoEmpaquetadoSemElaPrincipal = 0;
        private decimal _CostoEmpaquetadoSemElaAdicional = 0;
        private decimal _CostoEmpaquetadoSemElaDevolucion = 0;
        private decimal _CostoEmpaquetadoSemElaTotal = 0;
        private decimal _CostoUnidadEmpaquetadoSemEla = 0;
        private decimal _CostoUnidadEmpaquetadoProTer = 0;
        private decimal _CostoUnidadTotalSemEla = 0;
        private decimal _NumeroUnidadesAEmpaquetar = 0;
        private decimal _CostoInsumos = 0;
        private decimal _CostoManoObra = 0;
        private decimal _CostoOtros = 0;
        private decimal _UnidadesDesechaEmpaquetado = 0;
        private decimal _UnidadesDevueltaEmpaquetado = 0;
        private string _ObservacionMasaPerdida = string.Empty;
        private decimal _UnidadesReproceso = 0;
        private decimal _CostoUnidadesReproceso = 0;
        private string _ClaveSalidaUnidadesReproceso = string.Empty;
        private decimal _UnidadesParaReproceso = 0;
        private decimal _NumeroUnidadesSemiElaborado = 0;        
        private string _CTurno = "0";//Dia
        private string _NTurno = "DIA";//Dia
        private string _NumeroTransferenciaAutomatica = string.Empty;
        private bool _VerdadFalso = false;
        private string _ClaveSalidaTransferenciaReproceso = string.Empty;
        private string _ClaveIngresoTransferenciaReproceso = string.Empty;
        private decimal _SaldoUnidadesAEmpacar = 0;
        private decimal _UnidadesDonacion = 0;
        private string _ClaveSalidaTransferenciaDonacion = string.Empty;
        private string _ClaveIngresoTransferenciaDonacion = string.Empty;
        private decimal _SaldoLiberacion = 0;
        private decimal _UnidadesAprobadasLiberacion = 0;
        private decimal _UnidadesSaldoLiberacion = 0;
        private decimal _UnidadesObservadasLiberacion = 0;
        private decimal _UnidadesReprocesoLiberacion = 0;
        private decimal _UnidadesDonacionLiberacion = 0;
        private decimal _UnidadesMuestraLiberacion = 0;
        private decimal _UnidadesDesechasLiberacion = 0;
        private decimal _PorcentajeRango = 0;
        private decimal _CantidadRango = 0;
        private string _ClaveIngresoDesmedroEnvasado = string.Empty;
        private decimal _FactorProduccionProDet = 0;
        private decimal _RatioProduccionProDet = 0;
        private decimal _HorasHombre = 0;
        private decimal _CostoTotalManoObra = 0;
        private decimal _FactorCIFFijo = 0;
        private decimal _CostoCIFFijo = 0;
        private decimal _FactorCIFVariable = 0;
        private decimal _CostoCIFVariable = 0;
        private decimal _CostoTotalVariable = 0;
        private decimal _CostoTotalEnvasado = 0;
        private decimal _CostoUnidadesAprobadasLiberacion = 0;
        private decimal _CostoUnidadesReprocesoLiberacion = 0;        
        private decimal _CostoUnidadesDesechasLiberacion = 0;
        private decimal _CostoUnidadesDonacionLiberacion = 0;
        private decimal _CostoUnidadesMuestraLiberacion = 0;
        private decimal _CostoUnidadesObservadasLiberacion = 0;
        private decimal _CostoUnidadesPorLiberarLiberacion = 0;
        private decimal _CostoUnidadesPorDesbloquearLiberacion = 0;
        private decimal _PorcentajeUnidadesDesechasLiberacion = 0;        
        private decimal _CantidadSinceradoProduccionDeta = 0;
        private decimal _PorcentajeSinceradoRango = 0;
        private decimal _CantidadSinceradoRango = 0;
        private string _DetalleMotivoSincerado = string.Empty;
        private string _ClavesTransferenciaSincerado = string.Empty;
        private decimal _CantidadEncajonar = 0;
        private decimal _CantidadBloquear = 0;
        private decimal _SaldoLiberacionBloqueadas = 0;
        private string _ClaveIngresoSemElaBloqueadas = string.Empty;
        private decimal _CantidadContraMuestra = 0;
        private string _ClaveIngresoSemElaContraMuestra = string.Empty;
        private decimal _CantidadCuarentenaQali = 0;
        private decimal _CantidadReprocesoQali = 0;
        private decimal _CantidadMuestraQali = 0;
        private decimal _CantidadDesechoQali = 0;
        private decimal _SaldoLiberacionCuarentenaQali = 0;
        private string _ClaveIngresoCuarentenaQali = string.Empty;
        private string _ClaveIngresoReprocesoQali = string.Empty;
        private string _ClaveIngresoMuestraQali = string.Empty;
        private string _ClaveIngresoDesechoQali = string.Empty;
        private string _ClaveSalidaEtiquetaQali = string.Empty;
        private string _CManejaCuarentena = "0";
        private string _DetalleMotivoReprocesoQali = string.Empty;
        private string _DetalleMotivoMuestraQali = string.Empty;
        private string _DetalleMotivoDesechoQali = string.Empty;
        private string _DetalleMotivoMuestraPreLiberacion = string.Empty;
        private string _DetalleMotivoBloqueadosPreLiberacion = string.Empty;
        private decimal _CantidadUnidadesPackingAdicionalesBlo = 0;
        private decimal _TotalEnvasesDesmedro = 0;
        private decimal _PorcentajeEnvasesDesmedro = 0;
        private decimal _SaldoLiberacionObservadas = 0;
        private decimal _CantidadUnidadesPackingAdicionalesObs = 0;
        private decimal _CantidadMuestraProduccion = 0;
        private string _DetalleMotivoMuestraProduccion = string.Empty;
        private string _ClaveIngresoSemElaMuestraProduccion = string.Empty;
        private string _CEstadoProduccionDeta = "0";  
        private string _NEstadoProduccionDeta = "Pendiente";
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();
       
        //propiedades

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }
        
        public string ClaveProduccionDeta
        {
            get { return this._ClaveProduccionDeta; }
            set { this._ClaveProduccionDeta = value; }
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

        public string CorrelativoProduccionCabe
        {
            get { return this._CorrelativoProduccionCabe; }
            set { this._CorrelativoProduccionCabe = value; }
        }

        public string CorrelativoProduccionDeta
        {
            get { return this._CorrelativoProduccionDeta; }
            set { this._CorrelativoProduccionDeta = value; }
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

        public string FechaProduccionDeta
        {
            get { return this._FechaProduccionDeta; }
            set { this._FechaProduccionDeta = value; }
        }

        public string PeriodoProduccionDeta
        {
            get { return this._PeriodoProduccionDeta; }
            set { this._PeriodoProduccionDeta = value; }
        }

        public string FechaSalidaFaseMasa
        {
            get { return this._FechaSalidaFaseMasa; }
            set { this._FechaSalidaFaseMasa = value; }
        }

        public string FechaSalidaFaseControlCalidad
        {
            get { return this._FechaSalidaFaseControlCalidad; }
            set { this._FechaSalidaFaseControlCalidad = value; }
        }

        public string FechaSalidaFaseEmpaquetado
        {
            get { return this._FechaSalidaFaseEmpaquetado; }
            set { this._FechaSalidaFaseEmpaquetado = value; }
        }

        public string FechaIngresoAlmacen
        {
            get { return this._FechaIngresoAlmacen; }
            set { this._FechaIngresoAlmacen = value; }
        }

        public decimal SaldoProduccionCabe
        {
            get { return this._SaldoProduccionCabe; }
            set { this._SaldoProduccionCabe = value; }
        }

        public decimal CantidadProduccionDeta
        {
            get { return this._CantidadProduccionDeta; }
            set { this._CantidadProduccionDeta = value; }
        }

        public decimal CantidadRealProduccion
        {
            get { return this._CantidadRealProduccion; }
            set { this._CantidadRealProduccion = value; }
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

        public string ObservacionProduccionDeta
        {
            get { return this._ObservacionProduccionDeta; }
            set { this._ObservacionProduccionDeta = value; }
        }

        public string ClaveSalidaFaseMasa
        {
            get { return this._ClaveSalidaFaseMasa; }
            set { this._ClaveSalidaFaseMasa = value; }
        }

        public string ClaveSalidaFaseControlCalidad
        {
            get { return this._ClaveSalidaFaseControlCalidad; }
            set { this._ClaveSalidaFaseControlCalidad = value; }
        }

        public string ClaveSalidaFaseEmpaquetado
        {
            get { return this._ClaveSalidaFaseEmpaquetado; }
            set { this._ClaveSalidaFaseEmpaquetado = value; }
        }

        public string ClaveIngresoMovimientoCabe
        {
            get { return this._ClaveIngresoMovimientoCabe; }
            set { this._ClaveIngresoMovimientoCabe = value; }
        }

        public string CodigoMercaderia
        {
            get { return this._CodigoMercaderia; }
            set { this._CodigoMercaderia = value; }
        }

        public string CodigoAlmacenSemiProducto
        {
            get { return this._CodigoAlmacenSemiProducto; }
            set { this._CodigoAlmacenSemiProducto = value; }
        }

        public string CodigoSemiProducto
        {
            get { return this._CodigoSemiProducto; }
            set { this._CodigoSemiProducto = value; }
        }

        public string DescripcionSemiProducto
        {
            get { return this._DescripcionSemiProducto; }
            set { this._DescripcionSemiProducto = value; }
        }

        public string CodigoAlmacenEmpaquetado
        {
            get { return this._CodigoAlmacenEmpaquetado; }
            set { this._CodigoAlmacenEmpaquetado = value; }
        }

        public string DescripcionAlmacenEmpaquetado
        {
            get { return this._DescripcionAlmacenEmpaquetado; }
            set { this._DescripcionAlmacenEmpaquetado = value; }
        }

        public decimal RatioFormulaCabe
        {
            get { return this._RatioFormulaCabe; }
            set { this._RatioFormulaCabe = value; }
        }

        public string CEsExacto
        {
            get { return this._CEsExacto; }
            set { this._CEsExacto = value; }
        }

        public decimal CostoTotalProducto
        {
            get { return this._CostoTotalProducto; }
            set { this._CostoTotalProducto = value; }
        }

        public decimal CostoMasaPrincipal
        {
            get { return this._CostoMasaPrincipal; }
            set { this._CostoMasaPrincipal = value; }
        }

        public decimal CostoMasaAdicional
        {
            get { return this._CostoMasaAdicional; }
            set { this._CostoMasaAdicional = value; }
        }

        public decimal CostoMasaDevolucion
        {
            get { return this._CostoMasaDevolucion; }
            set { this._CostoMasaDevolucion = value; }
        }

        public decimal CostoMasaTotal
        {
            get { return this._CostoMasaTotal; }
            set { this._CostoMasaTotal = value; }
        }

        public decimal MasaProducida
        {
            get { return this._MasaProducida; }
            set { this._MasaProducida = value; }
        }

        public decimal MasaUnidad
        {
            get { return this._MasaUnidad; }
            set { this._MasaUnidad = value; }
        }

        public decimal NumeroUnidadesMasa
        {
            get { return this._NumeroUnidadesMasa; }
            set { this._NumeroUnidadesMasa = value; }
        }

        public decimal CostoUnidadMasa
        {
            get { return this._CostoUnidadMasa; }
            set { this._CostoUnidadMasa = value; }
        }

        public decimal MasaPerdida
        {
            get { return this._MasaPerdida; }
            set { this._MasaPerdida = value; }
        }

        public decimal CostoMasaPerdida
        {
            get { return this._CostoMasaPerdida; }
            set { this._CostoMasaPerdida = value; }
        }

        public decimal CostoConCalPrincipal
        {
            get { return this._CostoConCalPrincipal; }
            set { this._CostoConCalPrincipal = value; }
        }

        public decimal CostoConCalAdicional
        {
            get { return this._CostoConCalAdicional; }
            set { this._CostoConCalAdicional = value; }
        }

        public decimal CostoConCalDevolucion
        {
            get { return this._CostoConCalDevolucion; }
            set { this._CostoConCalDevolucion = value; }
        }

        public decimal CostoConCalTotal
        {
            get { return this._CostoConCalTotal; }
            set { this._CostoConCalTotal = value; }
        }

        public decimal NumeroUnidadesConCal
        {
            get { return this._NumeroUnidadesConCal; }
            set { this._NumeroUnidadesConCal = value; }
        }

        public decimal NumeroUnidadesNoPasanConCal
        {
            get { return this._NumeroUnidadesNoPasanConCal; }
            set { this._NumeroUnidadesNoPasanConCal = value; }
        }

        public decimal CostoUnidadConCal
        {
            get { return this._CostoUnidadConCal; }
            set { this._CostoUnidadConCal = value; }
        }

        public decimal NumeroUnidadesProduccionAnterior
        {
            get { return this._NumeroUnidadesProduccionAnterior; }
            set { this._NumeroUnidadesProduccionAnterior = value; }
        }

        public string ClaveSalidaUnidadesEmpacar
        {
            get { return this._ClaveSalidaUnidadesEmpacar; }
            set { this._ClaveSalidaUnidadesEmpacar = value; }
        }

        public string ClaveSalidaNoPasan
        {
            get { return this._ClaveSalidaNoPasan; }
            set { this._ClaveSalidaNoPasan = value; }
        }

        public string ClaveIngresoNoPasan
        {
            get { return this._ClaveIngresoNoPasan; }
            set { this._ClaveIngresoNoPasan = value; }
        }

        public decimal UnidadesPorCaja
        {
            get { return this._UnidadesPorCaja; }
            set { this._UnidadesPorCaja = value; }
        }

        public decimal NumeroCajas
        {
            get { return this._NumeroCajas; }
            set { this._NumeroCajas = value; }
        }

        public decimal NumeroUnidadesSueltas
        {
            get { return this._NumeroUnidadesSueltas; }
            set { this._NumeroUnidadesSueltas = value; }
        }

        public string ClaveIngresoSemiElaborado
        {
            get { return this._ClaveIngresoSemiElaborado; }
            set { this._ClaveIngresoSemiElaborado = value; }
        }

        public decimal CostoEmpaquetadoSemElaPrincipal
        {
            get { return this._CostoEmpaquetadoSemElaPrincipal; }
            set { this._CostoEmpaquetadoSemElaPrincipal = value; }
        }

        public decimal CostoEmpaquetadoSemElaAdicional
        {
            get { return this._CostoEmpaquetadoSemElaAdicional; }
            set { this._CostoEmpaquetadoSemElaAdicional = value; }
        }

        public decimal CostoEmpaquetadoSemElaDevolucion
        {
            get { return this._CostoEmpaquetadoSemElaDevolucion; }
            set { this._CostoEmpaquetadoSemElaDevolucion = value; }
        }

        public decimal CostoEmpaquetadoSemElaTotal
        {
            get { return this._CostoEmpaquetadoSemElaTotal; }
            set { this._CostoEmpaquetadoSemElaTotal = value; }
        }

        public decimal CostoUnidadEmpaquetadoSemEla
        {
            get { return this._CostoUnidadEmpaquetadoSemEla; }
            set { this._CostoUnidadEmpaquetadoSemEla = value; }
        }

        public decimal CostoUnidadEmpaquetadoProTer
        {
            get { return this._CostoUnidadEmpaquetadoProTer; }
            set { this._CostoUnidadEmpaquetadoProTer = value; }
        }

        public decimal CostoUnidadTotalSemEla
        {
            get { return this._CostoUnidadTotalSemEla; }
            set { this._CostoUnidadTotalSemEla = value; }
        }

        public decimal NumeroUnidadesAEmpaquetar
        {
            get { return this._NumeroUnidadesAEmpaquetar; }
            set { this._NumeroUnidadesAEmpaquetar = value; }
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

        public string ObservacionMasaPerdida
        {
            get { return this._ObservacionMasaPerdida; }
            set { this._ObservacionMasaPerdida = value; }
        }

        public decimal UnidadesReproceso
        {
            get { return this._UnidadesReproceso; }
            set { this._UnidadesReproceso = value; }
        }

        public decimal CostoUnidadesReproceso
        {
            get { return this._CostoUnidadesReproceso; }
            set { this._CostoUnidadesReproceso = value; }
        }

        public string ClaveSalidaUnidadesReproceso
        {
            get { return this._ClaveSalidaUnidadesReproceso; }
            set { this._ClaveSalidaUnidadesReproceso = value; }
        }

        public decimal UnidadesParaReproceso
        {
            get { return this._UnidadesParaReproceso; }
            set { this._UnidadesParaReproceso = value; }
        }

        public decimal NumeroUnidadesSemiElaborado
        {
            get { return this._NumeroUnidadesSemiElaborado; }
            set { this._NumeroUnidadesSemiElaborado = value; }
        }

        public string CTurno
        {
            get { return this._CTurno; }
            set { this._CTurno = value; }
        }

        public string NTurno
        {
            get { return this._NTurno; }
            set { this._NTurno = value; }
        }

        public string NumeroTransferenciaAutomatica
        {
            get { return this._NumeroTransferenciaAutomatica; }
            set { this._NumeroTransferenciaAutomatica = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }

        public string ClaveSalidaTransferenciaReproceso
        {
            get { return this._ClaveSalidaTransferenciaReproceso; }
            set { this._ClaveSalidaTransferenciaReproceso = value; }
        }

        public string ClaveIngresoTransferenciaReproceso
        {
            get { return this._ClaveIngresoTransferenciaReproceso; }
            set { this._ClaveIngresoTransferenciaReproceso = value; }
        }

        public decimal SaldoUnidadesAEmpacar
        {
            get { return this._SaldoUnidadesAEmpacar; }
            set { this._SaldoUnidadesAEmpacar = value; }
        }

        public decimal UnidadesDonacion
        {
            get { return this._UnidadesDonacion; }
            set { this._UnidadesDonacion = value; }
        }

        public string ClaveSalidaTransferenciaDonacion
        {
            get { return this._ClaveSalidaTransferenciaDonacion; }
            set { this._ClaveSalidaTransferenciaDonacion = value; }
        }

        public string ClaveIngresoTransferenciaDonacion
        {
            get { return this._ClaveIngresoTransferenciaDonacion; }
            set { this._ClaveIngresoTransferenciaDonacion = value; }
        }

        public decimal SaldoLiberacion
        {
            get { return this._SaldoLiberacion; }
            set { this._SaldoLiberacion = value; }
        }

        public decimal UnidadesAprobadasLiberacion
        {
            get { return this._UnidadesAprobadasLiberacion; }
            set { this._UnidadesAprobadasLiberacion = value; }
        }

        public decimal UnidadesSaldoLiberacion
        {
            get { return this._UnidadesSaldoLiberacion; }
            set { this._UnidadesSaldoLiberacion = value; }
        }

        public decimal UnidadesObservadasLiberacion
        {
            get { return this._UnidadesObservadasLiberacion; }
            set { this._UnidadesObservadasLiberacion = value; }
        }

        public decimal UnidadesReprocesoLiberacion
        {
            get { return this._UnidadesReprocesoLiberacion; }
            set { this._UnidadesReprocesoLiberacion = value; }
        }

        public decimal UnidadesDonacionLiberacion
        {
            get { return this._UnidadesDonacionLiberacion; }
            set { this._UnidadesDonacionLiberacion = value; }
        }

        public decimal UnidadesMuestraLiberacion
        {
            get { return this._UnidadesMuestraLiberacion; }
            set { this._UnidadesMuestraLiberacion = value; }
        }

        public decimal UnidadesDesechasLiberacion
        {
            get { return this._UnidadesDesechasLiberacion; }
            set { this._UnidadesDesechasLiberacion = value; }
        }

        public decimal PorcentajeRango
        {
            get { return this._PorcentajeRango; }
            set { this._PorcentajeRango = value; }
        }

        public decimal CantidadRango
        {
            get { return this._CantidadRango; }
            set { this._CantidadRango = value; }
        }

        public string ClaveIngresoDesmedroEnvasado
        {
            get { return this._ClaveIngresoDesmedroEnvasado; }
            set { this._ClaveIngresoDesmedroEnvasado = value; }
        }

        public decimal FactorProduccionProDet
        {
            get { return this._FactorProduccionProDet; }
            set { this._FactorProduccionProDet = value; }
        }

        public decimal RatioProduccionProDet
        {
            get { return this._RatioProduccionProDet; }
            set { this._RatioProduccionProDet = value; }
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

        public decimal CostoTotalVariable
        {
            get { return this._CostoTotalVariable; }
            set { this._CostoTotalVariable = value; }
        }

        public decimal CostoTotalEnvasado
        {
            get { return this._CostoTotalEnvasado; }
            set { this._CostoTotalEnvasado = value; }
        }

        public decimal CostoUnidadesAprobadasLiberacion
        {
            get { return this._CostoUnidadesAprobadasLiberacion; }
            set { this._CostoUnidadesAprobadasLiberacion = value; }
        }

        public decimal CostoUnidadesReprocesoLiberacion
        {
            get { return this._CostoUnidadesReprocesoLiberacion; }
            set { this._CostoUnidadesReprocesoLiberacion = value; }
        }
        
        public decimal CostoUnidadesDesechasLiberacion
        {
            get { return this._CostoUnidadesDesechasLiberacion; }
            set { this._CostoUnidadesDesechasLiberacion = value; }
        }

        public decimal CostoUnidadesDonacionLiberacion
        {
            get
            {
                return _CostoUnidadesDonacionLiberacion;
            }

            set
            {
                _CostoUnidadesDonacionLiberacion = value;
            }
        }

        public decimal CostoUnidadesMuestraLiberacion
        {
            get
            {
                return _CostoUnidadesMuestraLiberacion;
            }

            set
            {
                _CostoUnidadesMuestraLiberacion = value;
            }
        }

        public decimal CostoUnidadesObservadasLiberacion
        {
            get
            {
                return _CostoUnidadesObservadasLiberacion;
            }

            set
            {
                _CostoUnidadesObservadasLiberacion = value;
            }
        }

        public decimal CostoUnidadesPorLiberarLiberacion
        {
            get
            {
                return _CostoUnidadesPorLiberarLiberacion;
            }

            set
            {
                _CostoUnidadesPorLiberarLiberacion = value;
            }
        }

        public decimal CostoUnidadesPorDesbloquearLiberacion
        {
            get
            {
                return _CostoUnidadesPorDesbloquearLiberacion;
            }

            set
            {
                _CostoUnidadesPorDesbloquearLiberacion = value;
            }
        }

        public decimal PorcentajeUnidadesDesechasLiberacion
        {
            get
            {
                return _PorcentajeUnidadesDesechasLiberacion;
            }

            set
            {
                _PorcentajeUnidadesDesechasLiberacion = value;
            }
        }

        public decimal CantidadSinceradoProduccionDeta
        {
            get { return this._CantidadSinceradoProduccionDeta; }
            set { this._CantidadSinceradoProduccionDeta = value; }
        }

        public decimal PorcentajeSinceradoRango
        {
            get { return this._PorcentajeSinceradoRango; }
            set { this._PorcentajeSinceradoRango = value; }
        }

        public decimal CantidadSinceradoRango
        {
            get { return this._CantidadSinceradoRango; }
            set { this._CantidadSinceradoRango = value; }
        }

        public string DetalleMotivoSincerado
        {
            get { return this._DetalleMotivoSincerado; }
            set { this._DetalleMotivoSincerado = value; }
        }

        public string ClavesTransferenciaSincerado
        {
            get { return this._ClavesTransferenciaSincerado; }
            set { this._ClavesTransferenciaSincerado = value; }
        }

        public decimal CantidadEncajonar
        {
            get { return this._CantidadEncajonar; }
            set { this._CantidadEncajonar = value; }
        }

        public decimal CantidadBloquear
        {
            get { return this._CantidadBloquear; }
            set { this._CantidadBloquear = value; }
        }

        public decimal SaldoLiberacionBloqueadas
        {
            get { return this._SaldoLiberacionBloqueadas; }
            set { this._SaldoLiberacionBloqueadas = value; }
        }

        public string ClaveIngresoSemElaBloqueadas
        {
            get { return this._ClaveIngresoSemElaBloqueadas; }
            set { this._ClaveIngresoSemElaBloqueadas = value; }
        }

        public decimal CantidadContraMuestra
        {
            get { return this._CantidadContraMuestra; }
            set { this._CantidadContraMuestra = value; }
        }

        public string ClaveIngresoSemElaContraMuestra
        {
            get { return this._ClaveIngresoSemElaContraMuestra; }
            set { this._ClaveIngresoSemElaContraMuestra = value; }
        }

        public decimal CantidadCuarentenaQali
        {
            get
            {
                return _CantidadCuarentenaQali;
            }

            set
            {
                _CantidadCuarentenaQali = value;
            }
        }

        public decimal CantidadReprocesoQali
        {
            get
            {
                return _CantidadReprocesoQali;
            }

            set
            {
                _CantidadReprocesoQali = value;
            }
        }

        public decimal CantidadMuestraQali
        {
            get
            {
                return _CantidadMuestraQali;
            }

            set
            {
                _CantidadMuestraQali = value;
            }
        }

        public decimal CantidadDesechoQali
        {
            get
            {
                return _CantidadDesechoQali;
            }

            set
            {
                _CantidadDesechoQali = value;
            }
        }

        public decimal SaldoLiberacionCuarentenaQali
        {
            get
            {
                return _SaldoLiberacionCuarentenaQali;
            }

            set
            {
                _SaldoLiberacionCuarentenaQali = value;
            }
        }

        public string ClaveIngresoCuarentenaQali
        {
            get
            {
                return _ClaveIngresoCuarentenaQali;
            }

            set
            {
                _ClaveIngresoCuarentenaQali = value;
            }
        }

        public string ClaveIngresoReprocesoQali
        {
            get
            {
                return _ClaveIngresoReprocesoQali;
            }

            set
            {
                _ClaveIngresoReprocesoQali = value;
            }
        }

        public string ClaveIngresoMuestraQali
        {
            get
            {
                return _ClaveIngresoMuestraQali;
            }

            set
            {
                _ClaveIngresoMuestraQali = value;
            }
        }

        public string ClaveIngresoDesechoQali
        {
            get
            {
                return _ClaveIngresoDesechoQali;
            }

            set
            {
                _ClaveIngresoDesechoQali = value;
            }
        }

        public string ClaveSalidaEtiquetaQali
        {
            get
            {
                return _ClaveSalidaEtiquetaQali;
            }

            set
            {
                _ClaveSalidaEtiquetaQali = value;
            }
        }

        public string CManejaCuarentena
        {
            get { return this._CManejaCuarentena; }
            set { this._CManejaCuarentena = value; }
        }

        public string DetalleMotivoReprocesoQali
        {
            get { return this._DetalleMotivoReprocesoQali; }
            set { this._DetalleMotivoReprocesoQali = value; }
        }

        public string DetalleMotivoMuestraQali
        {
            get { return this._DetalleMotivoMuestraQali; }
            set { this._DetalleMotivoMuestraQali = value; }
        }

        public string DetalleMotivoDesechoQali
        {
            get { return this._DetalleMotivoDesechoQali; }
            set { this._DetalleMotivoDesechoQali = value; }
        }

        public string DetalleMotivoMuestraPreLiberacion
        {
            get { return this._DetalleMotivoMuestraPreLiberacion; }
            set { this._DetalleMotivoMuestraPreLiberacion = value; }
        }

        public string DetalleMotivoBloqueadosPreLiberacion
        {
            get { return this._DetalleMotivoBloqueadosPreLiberacion; }
            set { this._DetalleMotivoBloqueadosPreLiberacion = value; }
        }

        public decimal CantidadUnidadesPackingAdicionalesBlo
        {
            get
            {
                return _CantidadUnidadesPackingAdicionalesBlo;
            }

            set
            {
                _CantidadUnidadesPackingAdicionalesBlo = value;
            }
        }

        public decimal TotalEnvasesDesmedro
        {
            get
            {
                return _TotalEnvasesDesmedro;
            }

            set
            {
                _TotalEnvasesDesmedro = value;
            }
        }

        public decimal PorcentajeEnvasesDesmedro
        {
            get
            {
                return _PorcentajeEnvasesDesmedro;
            }

            set
            {
                _PorcentajeEnvasesDesmedro = value;
            }
        }
        
        public decimal SaldoLiberacionObservadas
        {
            get
            {
                return _SaldoLiberacionObservadas;
            }

            set
            {
                _SaldoLiberacionObservadas = value;
            }
        }

        public decimal CantidadUnidadesPackingAdicionalesObs
        {
            get
            {
                return _CantidadUnidadesPackingAdicionalesObs;
            }

            set
            {
                _CantidadUnidadesPackingAdicionalesObs = value;
            }
        }

        public decimal CantidadMuestraProduccion
        {
            get { return this._CantidadMuestraProduccion; }
            set { this._CantidadMuestraProduccion = value; }
        }

        public string DetalleMotivoMuestraProduccion
        {
            get { return this._DetalleMotivoMuestraProduccion; }
            set { this._DetalleMotivoMuestraProduccion = value; }
        }

        public string ClaveIngresoSemElaMuestraProduccion
        {
            get { return this._ClaveIngresoSemElaMuestraProduccion; }
            set { this._ClaveIngresoSemElaMuestraProduccion = value; }
        }

        public string CEstadoProduccionDeta
        {
            get { return this._CEstadoProduccionDeta; }
            set { this._CEstadoProduccionDeta = value; }
        }

        public string NEstadoProduccionDeta
        {
            get { return this._NEstadoProduccionDeta; }
            set { this._NEstadoProduccionDeta = value; }
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
