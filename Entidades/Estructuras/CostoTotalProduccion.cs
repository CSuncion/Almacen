using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class CostoTotalProduccion
    {

        public const string CodEmp = "CodigoEmpresa";
        public const string FecProTer = "FechaProTer";
        public const string FecLot = "FechaLote";
        public const string FecEnc = "FechaEncajado";
        public const string CorProCab = "CorrelativoProduccionCabe";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string UniRet = "UnidadesRetiquetadas";
        public const string UniAprLot = "UnidadesAprobadasLote";
        public const string UniTer = "UnidadesTerminadas";
        public const string PorLotApr = "PorcentajeLoteAprobado";
        public const string PorLotAprAcu = "PorcentajeLoteAprobadoAcumulado";
        public const string CosEnvUni = "CostoEnvasadoUnitario";
        public const string CosEncUni = "CostoEncajadoUnitario";
        public const string CosRetUni = "CostoRetiquetadoUnitario";
        public const string CosTotUni = "CostoTotalUnitario";
        public const string CosEnvTot = "CostoEnvasadoTotal";
        public const string CosEncTot = "CostoEncajadoTotal";
        public const string CosRetTot = "CostoRetiquetadoTotal";
        public const string CosTotTot = "CostoTotalTotal";
        public const string CosFijUni = "CostoFijoUnitario";
        public const string CosVarUni = "CostoVariableUnitario";
        public const string CosTotVarUni = "CostoTotalVariableUnitario";
        public const string CosFijTot = "CostoFijoTotal";
        public const string CosVarTot = "CostoVariableTotal";
        public const string CosTotVarTot = "CostoTotalVariableTotal";
        public const string TipOpe = "TipoOperacion";
        public const string CorOpe = "CorrelativoOperacion";

        //atributos    
        private string _CodigoEmpresa = string.Empty;
        private string _FechaProTer = string.Empty;
        private string _FechaLote = string.Empty;
        private string _FechaEncajado = string.Empty;
        private string _CorrelativoProduccionCabe = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _UnidadesRetiquetadas = 0;
        private decimal _UnidadesAprobadasLote = 0;
        private decimal _UnidadesTerminadas = 0;
        private decimal _PorcentajeLoteAprobado = 0;
        private decimal _PorcentajeLoteAprobadoAcumulado = 0;
        private decimal _CostoEnvasadoUnitario = 0;
        private decimal _CostoEncajadoUnitario = 0;
        private decimal _CostoRetiquetadoUnitario = 0;
        private decimal _CostoTotalUnitario = 0;
        private decimal _CostoEnvasadoTotal = 0;
        private decimal _CostoEncajadoTotal = 0;
        private decimal _CostoRetiquetadoTotal = 0;
        private decimal _CostoTotalTotal = 0;
        private decimal _CostoFijoUnitario = 0;
        private decimal _CostoVariableUnitario = 0;
        private decimal _CostoTotalVariableUnitario = 0;
        private decimal _CostoFijoTotal = 0;
        private decimal _CostoVariableTotal = 0;
        private decimal _CostoTotalVariableTotal = 0;
        private string _TipoOperacion = string.Empty;
        private string _CorrelativoOperacion = string.Empty;

        //propiedades

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string FechaProTer
        {
            get { return this._FechaProTer; }
            set { this._FechaProTer = value; }
        }

        public string FechaLote
        {
            get { return this._FechaLote; }
            set { this._FechaLote = value; }
        }

        public string FechaEncajado
        {
            get { return this._FechaEncajado; }
            set { this._FechaEncajado = value; }
        }

        public string CorrelativoProduccionCabe
        {
            get { return this._CorrelativoProduccionCabe; }
            set { this._CorrelativoProduccionCabe = value; }
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

        public decimal UnidadesRetiquetadas
        {
            get { return this._UnidadesRetiquetadas; }
            set { this._UnidadesRetiquetadas = value; }
        }

        public decimal UnidadesAprobadasLote
        {
            get { return this._UnidadesAprobadasLote; }
            set { this._UnidadesAprobadasLote = value; }
        }

        public decimal UnidadesTerminadas
        {
            get { return this._UnidadesTerminadas; }
            set { this._UnidadesTerminadas = value; }
        }

        public decimal PorcentajeLoteAprobado
        {
            get { return this._PorcentajeLoteAprobado; }
            set { this._PorcentajeLoteAprobado = value; }
        }

        public decimal PorcentajeLoteAprobadoAcumulado
        {
            get
            {
                return _PorcentajeLoteAprobadoAcumulado;
            }

            set
            {
                _PorcentajeLoteAprobadoAcumulado = value;
            }
        }

        public decimal CostoEnvasadoUnitario
        {
            get { return this._CostoEnvasadoUnitario; }
            set { this._CostoEnvasadoUnitario = value; }
        }

        public decimal CostoEncajadoUnitario
        {
            get { return this._CostoEncajadoUnitario; }
            set { this._CostoEncajadoUnitario = value; }
        }

        public decimal CostoRetiquetadoUnitario
        {
            get
            {
                return _CostoRetiquetadoUnitario;
            }

            set
            {
                _CostoRetiquetadoUnitario = value;
            }
        }

        public decimal CostoTotalUnitario
        {
            get
            {
                return _CostoTotalUnitario;
            }

            set
            {
                _CostoTotalUnitario = value;
            }
        }

        public decimal CostoEnvasadoTotal
        {
            get
            {
                return _CostoEnvasadoTotal;
            }

            set
            {
                _CostoEnvasadoTotal = value;
            }
        }

        public decimal CostoEncajadoTotal
        {
            get
            {
                return _CostoEncajadoTotal;
            }

            set
            {
                _CostoEncajadoTotal = value;
            }
        }

        public decimal CostoRetiquetadoTotal
        {
            get
            {
                return _CostoRetiquetadoTotal;
            }

            set
            {
                _CostoRetiquetadoTotal = value;
            }
        }

        public decimal CostoTotalTotal
        {
            get
            {
                return _CostoTotalTotal;
            }

            set
            {
                _CostoTotalTotal = value;
            }
        }

        public decimal CostoFijoUnitario
        {
            get
            {
                return _CostoFijoUnitario;
            }

            set
            {
                _CostoFijoUnitario = value;
            }
        }

        public decimal CostoVariableUnitario
        {
            get
            {
                return _CostoVariableUnitario;
            }

            set
            {
                _CostoVariableUnitario = value;
            }
        }

        public decimal CostoTotalVariableUnitario
        {
            get
            {
                return _CostoTotalVariableUnitario;
            }

            set
            {
                _CostoTotalVariableUnitario = value;
            }
        }

        public decimal CostoFijoTotal
        {
            get
            {
                return _CostoFijoTotal;
            }

            set
            {
                _CostoFijoTotal = value;
            }
        }

        public decimal CostoVariableTotal
        {
            get
            {
                return _CostoVariableTotal;
            }

            set
            {
                _CostoVariableTotal = value;
            }
        }

        public decimal CostoTotalVariableTotal
        {
            get
            {
                return _CostoTotalVariableTotal;
            }

            set
            {
                _CostoTotalVariableTotal = value;
            }
        }

        public string TipoOperacion
        {
            get
            {
                return _TipoOperacion;
            }

            set
            {
                _TipoOperacion = value;
            }
        }

        public string CorrelativoOperacion
        {
            get
            {
                return _CorrelativoOperacion;
            }

            set
            {
                _CorrelativoOperacion = value;
            }
        }

    }
}
