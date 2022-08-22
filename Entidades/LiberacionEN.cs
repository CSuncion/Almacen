using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class LiberacionEN
    {

        #region Nombre Campos

        public const string ClaObj = "ClaveObjeto";
        public const string ClaLib = "ClaveLiberacion";
        public const string ClaProDet = "ClaveProduccionDeta";
        public const string CorProCab = "CorrelativoProduccionCabe";
        public const string FecProDet = "FechaProduccionDeta";
        public const string CosIns = "CostoInsumos";
        public const string CosTotPro = "CostoTotalProducto";
        public const string CanReaPro = "CantidadRealProduccion";
        public const string CodLib = "CodigoLiberacion";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodAlmSemPro = "CodigoAlmacenSemiProducto";
        public const string CodSemPro = "CodigoSemiProducto";
        public const string DesSemPro = "DescripcionSemiProducto";
        public const string FecLib = "FechaLiberacion";
        public const string PerLib = "PeriodoLiberacion";
        public const string SalLib = "SaldoLiberacion";
        public const string CanLib = "CantidadLiberacion";
        public const string UniPas = "UnidadesPasan";
        public const string UniParRep = "UnidadesParaReproceso";
        public const string UniParMue = "UnidadesParaMuestra";
        public const string UniParDon = "UnidadesParaDonacion";
        public const string UniDes = "UnidadesDesechas";
        public const string UniObs = "UnidadesObservadas";
        public const string UniSal = "UnidadesSaldo";
        public const string ClaSalTraDes = "ClaveSalidaTransferenciaDesechas";
        public const string ClaIngTraDes = "ClaveIngresoTransferenciaDesechas";
        public const string ClaSalTraRep = "ClaveSalidaTransferenciaReproceso";
        public const string ClaIngTraRep = "ClaveIngresoTransferenciaReproceso";
        public const string ClaSalTraDon = "ClaveSalidaTransferenciaDonacion";
        public const string ClaSalTraMue = "ClaveSalidaTransferenciaMuestra";
        public const string ClaIngTraMue = "ClaveIngresoTransferenciaMuestra";
        public const string ClaIngTraDon = "ClaveIngresoTransferenciaDonacion";
        public const string ClaIngObs = "ClaveIngresoObservadas";
        public const string ClaIngSal = "ClaveIngresoSaldo";
        public const string SalUniAEmp = "SaldoUnidadesAEmpacar";
        public const string DetMovRep = "DetalleMotivoReproceso";
        public const string DetMovDon = "DetalleMotivoDonacion";
        public const string DetMovMue = "DetalleMotivoMuestra";
        public const string DetMovDes = "DetalleMotivoDesecho";
        public const string PorLot = "PorcentajeLote";
        public const string PorAcu = "PorcentajeAcumulado";
        public const string CosUniPas = "CostoUnidadesPasan";
        public const string CosUniParRep = "CostoUnidadesParaReproceso";        
        public const string CosUniParDon = "CostoUnidadesParaDonacion";
        public const string CosUniDes = "CostoUnidadesDesechas";
        public const string UniAprLib = "UnidadesAprobadasLiberacion";
        public const string CosCifFij = "CostoCIFFijo";
        public const string CosUniMas = "CostoUnidadMasa";
        public const string CosUniConCal = "CostoUnidadConCal";
        public const string CosManObr = "CostoManoObra";
        public const string CosCIFVar = "CostoCIFVariable";
        public const string CAlmLib = "CAlmacenLiberacion";
        public const string ClaSalTraPack = "ClaveSalidaTransferenciaPacking";
        public const string ClaIngTraPack = "ClaveIngresoTransferenciaPacking";
        public const string CosMasPri = "CostoMasaPrincipal";
        public const string CosConCalPri = "CostoConCalPrincipal";
        public const string CosUniRep = "CostoUnidadesReproceso";
        public const string CanSinProDet = "CantidadSinceradoProduccionDeta";
        public const string CanEnc = "CantidadEncajonar";
        public const string CanUniPacAdiBlo = "CantidadUnidadesPackingAdicionalesBlo";
        public const string CosTotEnv = "CostoTotalEnvasado";
        public const string CosUniMue = "CostoUnidadesMuestra";
        public const string CosUniObs = "CostoUnidadesObservada";
        public const string CosUniSal = "CostoUnidadesSaldo";
        public const string UniRepLib = "UnidadesReprocesoLiberacion";
        public const string UniObsLib = "UnidadesObservadasLiberacion";
        public const string UniDesLib = "UnidadesDesechasLiberacion";
        public const string CEstLib = "CEstadoLiberacion";
        public const string NEstLib = "NEstadoLiberacion";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        #endregion

        #region Atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveLiberacion = string.Empty;
        private string _ClaveProduccionDeta = string.Empty;
        private string _CorrelativoProduccionCabe = string.Empty;
        private string _FechaProduccionDeta = string.Empty;
        private decimal _CostoInsumos = 0;
        private decimal _CostoTotalProducto = 0;
        private decimal _CantidadRealProduccion = 0;
        private string _CodigoLiberacion = string.Empty;
        private string _CodigoEmpresa = string.Empty;        
        private string _CodigoAlmacenSemiProducto = string.Empty;       
        private string _CodigoSemiProducto = string.Empty;
        private string _DescripcionSemiProducto = string.Empty;
        private string _FechaLiberacion = string.Empty;
        private string _PeriodoLiberacion = string.Empty;
        private decimal _SaldoLiberacion = 0;
        private decimal _CantidadLiberacion = 0;
        private decimal _UnidadesPasan = 0;
        private decimal _UnidadesParaReproceso = 0;
        private decimal _UnidadesParaDonacion = 0;
        private decimal _UnidadesParaMuestra = 0;
        private decimal _UnidadesDesechas = 0;
        private decimal _UnidadesObservadas = 0;
        private decimal _UnidadesSaldo = 0;
        private string _ClaveSalidaTransferenciaDesechas = string.Empty;
        private string _ClaveIngresoTransferenciaDesechas = string.Empty;
        private string _ClaveSalidaTransferenciaReproceso = string.Empty;
        private string _ClaveIngresoTransferenciaReproceso = string.Empty;
        private string _ClaveSalidaTransferenciaDonacion = string.Empty;
        private string _ClaveIngresoTransferenciaDonacion = string.Empty;
        private string _ClaveSalidaTransferenciaMuestra = string.Empty;
        private string _ClaveIngresoTransferenciaMuestra = string.Empty;
        private string _ClaveIngresoObservadas = string.Empty;
        private string _ClaveIngresoSaldo = string.Empty;
        private decimal _SaldoUnidadesAEmpacar = 0;
        private string _DetalleMotivoReproceso = string.Empty;
        private string _DetalleMotivoDonacion = string.Empty;
        private string _DetalleMotivoMuestra = string.Empty;
        private string _DetalleMotivoDesecho = string.Empty;
        private decimal? _PorcentajeLote = 0;
        private decimal _PorcentajeAcumulado = 0;
        private decimal _CostoUnidadesPasan = 0;
        private decimal _CostoUnidadesParaReproceso = 0;
        private decimal _CostoUnidadesParaDonacion = 0;
        private decimal _CostoUnidadesDesechas = 0;
        private decimal _UnidadesAprobadasLiberacion = 0;
        private decimal _CostoCIFFijo = 0;
        private decimal _CostoUnidadMasa = 0;
        private decimal _CostoUnidadConCal = 0;
        private decimal _CostoManoObra = 0;
        private decimal _CostoCIFVariable = 0;
        private string _CAlmacenLiberacion = "0";
        private string _ClaveSalidaTransferenciaPacking = string.Empty;
        private string _ClaveIngresoTransferenciaPacking = string.Empty;
        private decimal _CostoMasaPrincipal = 0;
        private decimal _CostoConCalPrincipal = 0;
        private decimal _CostoUnidadesReproceso = 0;
        private decimal _CantidadSinceradoProduccionDeta = 0;
        private decimal _CantidadEncajonar = 0;
        private decimal _CantidadUnidadesPackingAdicionalesBlo = 0;
        private decimal _CostoTotalEnvasado = 0;
        private decimal _CostoUnidadesMuestra = 0;
        private decimal _CostoUnidadesObservada = 0;
        private decimal _CostoUnidadesSaldo = 0;
        private decimal _UnidadesReprocesoLiberacion = 0;
        private decimal _UnidadesObservadasLiberacion = 0;
        private decimal _UnidadesDesechasLiberacion = 0;
        private string _CEstadoLiberacion = "1";
        private string _NEstadoLiberacion = "Activado";
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

        public string ClaveLiberacion
        {
            get { return this._ClaveLiberacion; }
            set { this._ClaveLiberacion = value; }
        }

        public string ClaveProduccionDeta
        {
            get { return this._ClaveProduccionDeta; }
            set { this._ClaveProduccionDeta = value; }
        }

        public string CorrelativoProduccionCabe
        {
            get { return this._CorrelativoProduccionCabe; }
            set { this._CorrelativoProduccionCabe = value; }
        }

        public string FechaProduccionDeta
        {
            get { return this._FechaProduccionDeta; }
            set { this._FechaProduccionDeta = value; }
        }

        public decimal CostoInsumos
        {
            get { return this._CostoInsumos; }
            set { this._CostoInsumos = value; }
        }

        public decimal CostoTotalProducto
        {
            get { return this._CostoTotalProducto; }
            set { this._CostoTotalProducto = value; }
        }

        public decimal CantidadRealProduccion
        {
            get { return this._CantidadRealProduccion; }
            set { this._CantidadRealProduccion = value; }
        }

        public string CodigoLiberacion
        {
            get { return this._CodigoLiberacion; }
            set { this._CodigoLiberacion = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
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

        public string FechaLiberacion
        {
            get { return this._FechaLiberacion; }
            set { this._FechaLiberacion = value; }
        }

        public string PeriodoLiberacion
        {
            get { return this._PeriodoLiberacion; }
            set { this._PeriodoLiberacion = value; }
        }

        public decimal SaldoLiberacion
        {
            get { return this._SaldoLiberacion; }
            set { this._SaldoLiberacion = value; }
        }

        public decimal CantidadLiberacion
        {
            get { return this._CantidadLiberacion; }
            set { this._CantidadLiberacion = value; }
        }

        public decimal UnidadesPasan
        {
            get { return this._UnidadesPasan; }
            set { this._UnidadesPasan = value; }
        }

        public decimal UnidadesParaReproceso
        {
            get { return this._UnidadesParaReproceso; }
            set { this._UnidadesParaReproceso = value; }
        }

        public decimal UnidadesParaDonacion
        {
            get { return this._UnidadesParaDonacion; }
            set { this._UnidadesParaDonacion = value; }
        }

        public decimal UnidadesParaMuestra
        {
            get { return this._UnidadesParaMuestra; }
            set { this._UnidadesParaMuestra = value; }
        }
        
        public decimal UnidadesDesechas
        {
            get { return this._UnidadesDesechas; }
            set { this._UnidadesDesechas = value; }
        }

        public decimal UnidadesObservadas
        {
            get { return this._UnidadesObservadas; }
            set { this._UnidadesObservadas = value; }
        }

        public decimal UnidadesSaldo
        {
            get { return this._UnidadesSaldo; }
            set { this._UnidadesSaldo = value; }
        }

        public string ClaveSalidaTransferenciaDesechas
        {
            get { return this._ClaveSalidaTransferenciaDesechas; }
            set { this._ClaveSalidaTransferenciaDesechas = value; }
        }

        public string ClaveIngresoTransferenciaDesechas
        {
            get { return this._ClaveIngresoTransferenciaDesechas; }
            set { this._ClaveIngresoTransferenciaDesechas = value; }
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

        public string ClaveSalidaTransferenciaMuestra
        {
            get { return this._ClaveSalidaTransferenciaMuestra; }
            set { this._ClaveSalidaTransferenciaMuestra = value; }
        }

        public string ClaveIngresoTransferenciaMuestra
        {
            get { return this._ClaveIngresoTransferenciaMuestra; }
            set { this._ClaveIngresoTransferenciaMuestra = value; }
        }

        public string ClaveIngresoObservadas
        {
            get { return this._ClaveIngresoObservadas; }
            set { this._ClaveIngresoObservadas = value; }
        }

        public string ClaveIngresoSaldo
        {
            get { return this._ClaveIngresoSaldo; }
            set { this._ClaveIngresoSaldo = value; }
        }

        public decimal SaldoUnidadesAEmpacar
        {
            get { return this._SaldoUnidadesAEmpacar; }
            set { this._SaldoUnidadesAEmpacar = value; }
        }

        public string DetalleMotivoReproceso
        {
            get { return this._DetalleMotivoReproceso; }
            set { this._DetalleMotivoReproceso = value; }
        }

        public string DetalleMotivoDonacion
        {
            get { return this._DetalleMotivoDonacion; }
            set { this._DetalleMotivoDonacion = value; }
        }

        public string DetalleMotivoMuestra
        {
            get { return this._DetalleMotivoMuestra; }
            set { this._DetalleMotivoMuestra = value; }
        }

        public string DetalleMotivoDesecho
        {
            get { return this._DetalleMotivoDesecho; }
            set { this._DetalleMotivoDesecho = value; }
        }

        public decimal? PorcentajeLote
        {
            get { return this._PorcentajeLote; }
            set { this._PorcentajeLote = value; }
        }

        public decimal PorcentajeAcumulado
        {
            get { return this._PorcentajeAcumulado; }
            set { this._PorcentajeAcumulado = value; }
        }
        
        public decimal CostoUnidadesPasan
        {
            get { return this._CostoUnidadesPasan; }
            set { this._CostoUnidadesPasan = value; }
        }

        public decimal CostoUnidadesParaReproceso
        {
            get { return this._CostoUnidadesParaReproceso; }
            set { this._CostoUnidadesParaReproceso = value; }
        }

        public decimal CostoUnidadesParaDonacion
        {
            get { return this._CostoUnidadesParaDonacion; }
            set { this._CostoUnidadesParaDonacion = value; }
        }

        public decimal CostoUnidadesDesechas
        {
            get { return this._CostoUnidadesDesechas; }
            set { this._CostoUnidadesDesechas = value; }
        }

        public decimal UnidadesAprobadasLiberacion
        {
            get { return this._UnidadesAprobadasLiberacion; }
            set { this._UnidadesAprobadasLiberacion = value; }
        }

        public decimal CostoCIFFijo
        {
            get { return this._CostoCIFFijo; }
            set { this._CostoCIFFijo = value; }
        }

        public decimal CostoUnidadMasa
        {
            get { return this._CostoUnidadMasa; }
            set { this._CostoUnidadMasa = value; }
        }

        public decimal CostoUnidadConCal
        {
            get { return this._CostoUnidadConCal; }
            set { this._CostoUnidadConCal = value; }
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

        public string CAlmacenLiberacion
        {
            get { return this._CAlmacenLiberacion; }
            set { this._CAlmacenLiberacion = value; }
        }

        public string ClaveSalidaTransferenciaPacking
        {
            get { return this._ClaveSalidaTransferenciaPacking; }
            set { this._ClaveSalidaTransferenciaPacking = value; }
        }

        public string ClaveIngresoTransferenciaPacking
        {
            get { return this._ClaveIngresoTransferenciaPacking; }
            set { this._ClaveIngresoTransferenciaPacking = value; }
        }

        public decimal CostoMasaPrincipal
        {
            get
            {
                return _CostoMasaPrincipal;
            }

            set
            {
                _CostoMasaPrincipal = value;
            }
        }

        public decimal CostoConCalPrincipal
        {
            get
            {
                return _CostoConCalPrincipal;
            }

            set
            {
                _CostoConCalPrincipal = value;
            }
        }

        public decimal CostoUnidadesReproceso
        {
            get
            {
                return _CostoUnidadesReproceso;
            }

            set
            {
                _CostoUnidadesReproceso = value;
            }
        }

        public decimal CantidadSinceradoProduccionDeta
        {
            get
            {
                return _CantidadSinceradoProduccionDeta;
            }

            set
            {
                _CantidadSinceradoProduccionDeta = value;
            }
        }

        public decimal CantidadEncajonar
        {
            get
            {
                return _CantidadEncajonar;
            }

            set
            {
                _CantidadEncajonar = value;
            }
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
        
        public decimal CostoTotalEnvasado
        {
            get
            {
                return _CostoTotalEnvasado;
            }

            set
            {
                _CostoTotalEnvasado = value;
            }
        }

        public decimal CostoUnidadesMuestra
        {
            get
            {
                return _CostoUnidadesMuestra;
            }

            set
            {
                _CostoUnidadesMuestra = value;
            }
        }

        public decimal CostoUnidadesObservada
        {
            get
            {
                return _CostoUnidadesObservada;
            }

            set
            {
                _CostoUnidadesObservada = value;
            }
        }

        public decimal CostoUnidadesSaldo
        {
            get
            {
                return _CostoUnidadesSaldo;
            }

            set
            {
                _CostoUnidadesSaldo = value;
            }
        }

        public decimal UnidadesReprocesoLiberacion
        {
            get
            {
                return _UnidadesReprocesoLiberacion;
            }

            set
            {
                _UnidadesReprocesoLiberacion = value;
            }
        }

        public decimal UnidadesObservadasLiberacion
        {
            get
            {
                return _UnidadesObservadasLiberacion;
            }

            set
            {
                _UnidadesObservadasLiberacion = value;
            }
        }

        public decimal UnidadesDesechasLiberacion
        {
            get
            {
                return _UnidadesDesechasLiberacion;
            }

            set
            {
                _UnidadesDesechasLiberacion = value;
            }
        }

        public string CEstadoLiberacion
        {
            get { return this._CEstadoLiberacion; }
            set { this._CEstadoLiberacion = value; }
        }

        public string NEstadoLiberacion
        {
            get { return this._NEstadoLiberacion; }
            set { this._NEstadoLiberacion = value; }
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
