using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Estructuras
{
    public class CostoUnitarioProTer
    {

        //campos nombres      
        public const string CodEmp = "CodigoEmpresa";
        public const string FecProTer = "FechaProTer";
        public const string FecLot = "FechaLote";
        public const string CorProCab = "CorrelativoProCab";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string MatPri = "MateriaPrima";        
        public const string Env = "Envase";
        public const string Emb = "Embalaje";
        public const string ManObr = "ManoObra";
        public const string CosCif = "CostoCif";
        public const string CosTot = "CostoTotal";
        public const string MatPriUni = "MateriaPrimaUnitario";
        public const string EnvUni = "EnvaseUnitario";
        public const string EmbUni = "EmbalajeUnitario";
        public const string ManObrUni = "ManoObraUnitario";        
        public const string CosCifUni = "CostoCifUnitario";
        public const string CosUni = "CostoUnitario";
        public const string UniPro = "UnidadesProducidas";
        public const string TipOpe = "TipoOperacion";
        public const string CorOpe = "CorrelativoOperacion";
        public const string ClaReg = "ClaveRegistro";
        public const string UniReaEnc = "UnidadesRealesEncajadas";
        public const string CosCifFijUni = "CostoCifFijoUnitario";
        public const string CosCifVarUni = "CostoCifVariableUnitario";
        public const string MatPriUniPla = "MateriaPrimaUnitarioPlanificada";
        public const string EnvUniPla = "EnvaseUnitarioPlanificada";
        public const string EmbUniPla = "EmbalajeUnitarioPlanificada";
        public const string ManObrUniPla = "ManoObraUnitarioPlanificada";
        public const string CosCifUniPla = "CostoCifUnitarioPlanificada";
        public const string EmbUniEnc = "EmbalajeUnitarioEncajado";
        public const string EmbUniRet = "EmbalajeUnitarioRetiquetado";
        public const string ManObrUniEnv = "ManoObraUnitarioEnvasado";
        public const string ManObrUniEnc = "ManoObraUnitarioEncajado";
        public const string ManObrUniRet = "ManoObraUnitarioRetiquetado";
        public const string CosCifFijUniEnv = "CostoCifFijoUnitarioEnvasado";
        public const string CosCifVarUniEnv = "CostoCifVariableUnitarioEnvasado";
        public const string CosCifFijUniEnc = "CostoCifFijoUnitarioEncajado";
        public const string CosCifVarUniEnc = "CostoCifVariableUnitarioEncajado";
        public const string CosCifFijUniRet = "CostoCifFijoUnitarioRetiquetado";
        public const string CosCifVarUniRet = "CostoCifVariableUnitarioRetiquetado";
        public const string EmbUniEncPla = "EmbalajeUnitarioEncajadoPlanificada";
        public const string EmbUniRetPla = "EmbalajeUnitarioRetiquetadoPlanificada";
        public const string ManObrUniEnvPla = "ManoObraUnitarioEnvasadoPlanificada";
        public const string ManObrUniEncPla = "ManoObraUnitarioEncajadoPlanificada";
        public const string ManObrUniRetPla = "ManoObraUnitarioRetiquetadoPlanificada";
        public const string CosCifFijUniEnvPla = "CostoCifFijoUnitarioEnvasadoPlanificada";
        public const string CosCifVarUniEnvPla = "CostoCifVariableUnitarioEnvasadoPlanificada";
        public const string CosCifFijUniEncPla = "CostoCifFijoUnitarioEncajadoPlanificada";
        public const string CosCifVarUniEncPla = "CostoCifVariableUnitarioEncajadoPlanificada";
        public const string CosCifFijUniRetPla = "CostoCifFijoUnitarioRetiquetadoPlanificada";
        public const string CosCifVarUniRetPla = "CostoCifVariableUnitarioRetiquetadoPlanificada";

        public const string CosCifFij = "CostoCifFijo";
        public const string CosCifVar = "CostoCifVariable";
        public const string MatPriPla = "MateriaPrimaPlanificada";
        public const string EnvPla = "EnvasePlanificada";
        public const string EmbPla = "EmbalajePlanificada";
        public const string ManObrPla = "ManoObraPlanificada";
        public const string CosCifPla = "CostoCifPlanificada";
        public const string EmbEnc = "EmbalajeEncajado";
        public const string EmbRet = "EmbalajeRetiquetado";
        public const string ManObrEnv = "ManoObraEnvasado";
        public const string ManObrEnc = "ManoObraEncajado";
        public const string ManObrRet = "ManoObraRetiquetado";
        public const string CosCifFijEnv = "CostoCifFijoEnvasado";
        public const string CosCifVarEnv = "CostoCifVariableEnvasado";
        public const string CosCifFijEnc = "CostoCifFijoEncajado";
        public const string CosCifVarEnc = "CostoCifVariableEncajado";
        public const string CosCifFijRet = "CostoCifFijoRetiquetado";
        public const string CosCifVarRet = "CostoCifVariableRetiquetado";
        public const string EmbEncPla = "EmbalajeEncajadoPlanificada";
        public const string EmbRetPla = "EmbalajeRetiquetadoPlanificada";
        public const string ManObrEnvPla = "ManoObraEnvasadoPlanificada";
        public const string ManObrEncPla = "ManoObraEncajadoPlanificada";
        public const string ManObrRetPla = "ManoObraRetiquetadoPlanificada";
        public const string CosCifFijEnvPla = "CostoCifFijoEnvasadoPlanificada";
        public const string CosCifVarEnvPla = "CostoCifVariableEnvasadoPlanificada";
        public const string CosCifFijEncPla = "CostoCifFijoEncajadoPlanificada";
        public const string CosCifVarEncPla = "CostoCifVariableEncajadoPlanificada";
        public const string CosCifFijRetPla = "CostoCifFijoRetiquetadoPlanificada";
        public const string CosCifVarRetPla = "CostoCifVariableRetiquetadoPlanificada";

        //atributos        
        private string _CodigoEmpresa = string.Empty;
        private string _FechaProTer = string.Empty;
        private string _FechaLote = string.Empty;
        private string _CorrelativoProCab = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _MateriaPrima = 0;        
        private decimal _Envase = 0;
        private decimal _Embalaje = 0;
        private decimal _ManoObra = 0;
        private decimal _CostoCif = 0;
        private decimal _CostoTotal = 0;
        private decimal _MateriaPrimaUnitario = 0;
        private decimal _EnvaseUnitario = 0;
        private decimal _EmbalajeUnitario = 0;
        private decimal _ManoObraUnitario = 0;
        private decimal _CostoCifUnitario = 0;
        private decimal _CostoUnitario = 0;
        private decimal _UnidadesProducidas = 0;
        private string _TipoOperacion = string.Empty;
        private string _CorrelativoOperacion = string.Empty;
        private string _ClaveRegistro = string.Empty;
        private decimal _UnidadesRealesEncajadas = 0;
        private decimal _CostoCifFijoUnitario = 0;
        private decimal _CostoCifVariableUnitario = 0;
        private decimal _MateriaPrimaUnitarioPlanificada = 0;
        private decimal _EnvaseUnitarioPlanificada = 0;
        private decimal _EmbalajeUnitarioPlanificada = 0;
        private decimal _ManoObraUnitarioPlanificada = 0;
        private decimal _CostoCifUnitarioPlanificada = 0;
        private decimal _EmbalajeUnitarioEncajado = 0;
        private decimal _EmbalajeUnitarioRetiquetado = 0;
        private decimal _ManoObraUnitarioEnvasado = 0;
        private decimal _ManoObraUnitarioEncajado = 0;
        private decimal _ManoObraUnitarioRetiquetado = 0;
        private decimal _CostoCifFijoUnitarioEnvasado = 0;
        private decimal _CostoCifVariableUnitarioEnvasado = 0;
        private decimal _CostoCifFijoUnitarioEncajado = 0;
        private decimal _CostoCifVariableUnitarioEncajado = 0;
        private decimal _CostoCifFijoUnitarioRetiquetado = 0;
        private decimal _CostoCifVariableUnitarioRetiquetado = 0;
        private decimal _EmbalajeUnitarioEncajadoPlanificada = 0;
        private decimal _EmbalajeUnitarioRetiquetadoPlanificada = 0;
        private decimal _ManoObraUnitarioEnvasadoPlanificada = 0;
        private decimal _ManoObraUnitarioEncajadoPlanificada = 0;
        private decimal _ManoObraUnitarioRetiquetadoPlanificada = 0;
        private decimal _CostoCifFijoUnitarioEnvasadoPlanificada = 0;
        private decimal _CostoCifVariableUnitarioEnvasadoPlanificada = 0;
        private decimal _CostoCifFijoUnitarioEncajadoPlanificada = 0;
        private decimal _CostoCifVariableUnitarioEncajadoPlanificada = 0;
        private decimal _CostoCifFijoUnitarioRetiquetadoPlanificada = 0;
        private decimal _CostoCifVariableUnitarioRetiquetadoPlanificada = 0;
        private decimal _CostoCifFijo = 0;
        private decimal _CostoCifVariable = 0;
        private decimal _MateriaPrimaPlanificada = 0;
        private decimal _EnvasePlanificada = 0;
        private decimal _EmbalajePlanificada = 0;
        private decimal _ManoObraPlanificada = 0;
        private decimal _CostoCifPlanificada = 0;
        private decimal _EmbalajeEncajado = 0;
        private decimal _EmbalajeRetiquetado = 0;
        private decimal _ManoObraEnvasado = 0;
        private decimal _ManoObraEncajado = 0;
        private decimal _ManoObraRetiquetado = 0;
        private decimal _CostoCifFijoEnvasado = 0;
        private decimal _CostoCifVariableEnvasado = 0;
        private decimal _CostoCifFijoEncajado = 0;
        private decimal _CostoCifVariableEncajado = 0;
        private decimal _CostoCifFijoRetiquetado = 0;
        private decimal _CostoCifVariableRetiquetado = 0;
        private decimal _EmbalajeEncajadoPlanificada = 0;
        private decimal _EmbalajeRetiquetadoPlanificada = 0;
        private decimal _ManoObraEnvasadoPlanificada = 0;
        private decimal _ManoObraEncajadoPlanificada = 0;
        private decimal _ManoObraRetiquetadoPlanificada = 0;
        private decimal _CostoCifFijoEnvasadoPlanificada = 0;
        private decimal _CostoCifVariableEnvasadoPlanificada = 0;
        private decimal _CostoCifFijoEncajadoPlanificada = 0;
        private decimal _CostoCifVariableEncajadoPlanificada = 0;
        private decimal _CostoCifFijoRetiquetadoPlanificada = 0;
        private decimal _CostoCifVariableRetiquetadoPlanificada = 0;

        //propiedades
        public string CodigoEmpresa
        {
            get
            {
                return _CodigoEmpresa;
            }

            set
            {
                _CodigoEmpresa = value;
            }
        }

        public string FechaProTer
        {
            get
            {
                return _FechaProTer;
            }

            set
            {
                _FechaProTer = value;
            }
        }
        
        public string FechaLote
        {
            get
            {
                return _FechaLote;
            }

            set
            {
                _FechaLote = value;
            }
        }

        public string CorrelativoProCab
        {
            get
            {
                return _CorrelativoProCab;
            }

            set
            {
                _CorrelativoProCab = value;
            }
        }

        public string CodigoExistencia
        {
            get
            {
                return _CodigoExistencia;
            }

            set
            {
                _CodigoExistencia = value;
            }
        }

        public string DescripcionExistencia
        {
            get
            {
                return _DescripcionExistencia;
            }

            set
            {
                _DescripcionExistencia = value;
            }
        }

        public decimal MateriaPrima
        {
            get
            {
                return _MateriaPrima;
            }

            set
            {
                _MateriaPrima = value;
            }
        }

        public decimal Envase
        {
            get
            {
                return _Envase;
            }

            set
            {
                _Envase = value;
            }
        }

        public decimal Embalaje
        {
            get
            {
                return _Embalaje;
            }

            set
            {
                _Embalaje = value;
            }
        }

        public decimal ManoObra
        {
            get
            {
                return _ManoObra;
            }

            set
            {
                _ManoObra = value;
            }
        }

        public decimal CostoCif
        {
            get
            {
                return _CostoCif;
            }

            set
            {
                _CostoCif = value;
            }
        }

        public decimal CostoTotal
        {
            get
            {
                return _CostoTotal;
            }

            set
            {
                _CostoTotal = value;
            }
        }

        public decimal MateriaPrimaUnitario
        {
            get
            {
                return _MateriaPrimaUnitario;
            }

            set
            {
                _MateriaPrimaUnitario = value;
            }
        }

        public decimal EnvaseUnitario
        {
            get
            {
                return _EnvaseUnitario;
            }

            set
            {
                _EnvaseUnitario = value;
            }
        }

        public decimal EmbalajeUnitario
        {
            get
            {
                return _EmbalajeUnitario;
            }

            set
            {
                _EmbalajeUnitario = value;
            }
        }

        public decimal ManoObraUnitario
        {
            get
            {
                return _ManoObraUnitario;
            }

            set
            {
                _ManoObraUnitario = value;
            }
        }

        public decimal CostoCifUnitario
        {
            get
            {
                return _CostoCifUnitario;
            }

            set
            {
                _CostoCifUnitario = value;
            }
        }

        public decimal CostoUnitario
        {
            get
            {
                return _CostoUnitario;
            }

            set
            {
                _CostoUnitario = value;
            }
        }

        public decimal UnidadesProducidas
        {
            get
            {
                return _UnidadesProducidas;
            }

            set
            {
                _UnidadesProducidas = value;
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

        public string ClaveRegistro
        {
            get
            {
                return _ClaveRegistro;
            }

            set
            {
                _ClaveRegistro = value;
            }
        }

        public decimal UnidadesRealesEncajadas
        {
            get
            {
                return _UnidadesRealesEncajadas;
            }

            set
            {
                _UnidadesRealesEncajadas = value;
            }
        }

        public decimal CostoCifFijoUnitario
        {
            get
            {
                return _CostoCifFijoUnitario;
            }

            set
            {
                _CostoCifFijoUnitario = value;
            }
        }

        public decimal CostoCifVariableUnitario
        {
            get
            {
                return _CostoCifVariableUnitario;
            }

            set
            {
                _CostoCifVariableUnitario = value;
            }
        }

        public decimal MateriaPrimaUnitarioPlanificada
        {
            get
            {
                return _MateriaPrimaUnitarioPlanificada;
            }

            set
            {
                _MateriaPrimaUnitarioPlanificada = value;
            }
        }

        public decimal EnvaseUnitarioPlanificada
        {
            get
            {
                return _EnvaseUnitarioPlanificada;
            }

            set
            {
                _EnvaseUnitarioPlanificada = value;
            }
        }

        public decimal EmbalajeUnitarioPlanificada
        {
            get
            {
                return _EmbalajeUnitarioPlanificada;
            }

            set
            {
                _EmbalajeUnitarioPlanificada = value;
            }
        }

        public decimal ManoObraUnitarioPlanificada
        {
            get
            {
                return _ManoObraUnitarioPlanificada;
            }

            set
            {
                _ManoObraUnitarioPlanificada = value;
            }
        }

        public decimal CostoCifUnitarioPlanificada
        {
            get
            {
                return _CostoCifUnitarioPlanificada;
            }

            set
            {
                _CostoCifUnitarioPlanificada = value;
            }
        }

        public decimal EmbalajeUnitarioEncajado
        {
            get
            {
                return _EmbalajeUnitarioEncajado;
            }

            set
            {
                _EmbalajeUnitarioEncajado = value;
            }
        }

        public decimal EmbalajeUnitarioRetiquetado
        {
            get
            {
                return _EmbalajeUnitarioRetiquetado;
            }

            set
            {
                _EmbalajeUnitarioRetiquetado = value;
            }
        }

        public decimal ManoObraUnitarioEnvasado
        {
            get
            {
                return _ManoObraUnitarioEnvasado;
            }

            set
            {
                _ManoObraUnitarioEnvasado = value;
            }
        }

        public decimal ManoObraUnitarioEncajado
        {
            get
            {
                return _ManoObraUnitarioEncajado;
            }

            set
            {
                _ManoObraUnitarioEncajado = value;
            }
        }

        public decimal ManoObraUnitarioRetiquetado
        {
            get
            {
                return _ManoObraUnitarioRetiquetado;
            }

            set
            {
                _ManoObraUnitarioRetiquetado = value;
            }
        }

        public decimal CostoCifFijoUnitarioEnvasado
        {
            get
            {
                return _CostoCifFijoUnitarioEnvasado;
            }

            set
            {
                _CostoCifFijoUnitarioEnvasado = value;
            }
        }

        public decimal CostoCifVariableUnitarioEnvasado
        {
            get
            {
                return _CostoCifVariableUnitarioEnvasado;
            }

            set
            {
                _CostoCifVariableUnitarioEnvasado = value;
            }
        }

        public decimal CostoCifFijoUnitarioEncajado
        {
            get
            {
                return _CostoCifFijoUnitarioEncajado;
            }

            set
            {
                _CostoCifFijoUnitarioEncajado = value;
            }
        }

        public decimal CostoCifVariableUnitarioEncajado
        {
            get
            {
                return _CostoCifVariableUnitarioEncajado;
            }

            set
            {
                _CostoCifVariableUnitarioEncajado = value;
            }
        }

        public decimal CostoCifFijoUnitarioRetiquetado
        {
            get
            {
                return _CostoCifFijoUnitarioRetiquetado;
            }

            set
            {
                _CostoCifFijoUnitarioRetiquetado = value;
            }
        }

        public decimal CostoCifVariableUnitarioRetiquetado
        {
            get
            {
                return _CostoCifVariableUnitarioRetiquetado;
            }

            set
            {
                _CostoCifVariableUnitarioRetiquetado = value;
            }
        }

        public decimal EmbalajeUnitarioEncajadoPlanificada
        {
            get
            {
                return _EmbalajeUnitarioEncajadoPlanificada;
            }

            set
            {
                _EmbalajeUnitarioEncajadoPlanificada = value;
            }
        }

        public decimal EmbalajeUnitarioRetiquetadoPlanificada
        {
            get
            {
                return _EmbalajeUnitarioRetiquetadoPlanificada;
            }

            set
            {
                _EmbalajeUnitarioRetiquetadoPlanificada = value;
            }
        }

        public decimal ManoObraUnitarioEnvasadoPlanificada
        {
            get
            {
                return _ManoObraUnitarioEnvasadoPlanificada;
            }

            set
            {
                _ManoObraUnitarioEnvasadoPlanificada = value;
            }
        }

        public decimal ManoObraUnitarioEncajadoPlanificada
        {
            get
            {
                return _ManoObraUnitarioEncajadoPlanificada;
            }

            set
            {
                _ManoObraUnitarioEncajadoPlanificada = value;
            }
        }

        public decimal ManoObraUnitarioRetiquetadoPlanificada
        {
            get
            {
                return _ManoObraUnitarioRetiquetadoPlanificada;
            }

            set
            {
                _ManoObraUnitarioRetiquetadoPlanificada = value;
            }
        }

        public decimal CostoCifFijoUnitarioEnvasadoPlanificada
        {
            get
            {
                return _CostoCifFijoUnitarioEnvasadoPlanificada;
            }

            set
            {
                _CostoCifFijoUnitarioEnvasadoPlanificada = value;
            }
        }

        public decimal CostoCifVariableUnitarioEnvasadoPlanificada
        {
            get
            {
                return _CostoCifVariableUnitarioEnvasadoPlanificada;
            }

            set
            {
                _CostoCifVariableUnitarioEnvasadoPlanificada = value;
            }
        }

        public decimal CostoCifFijoUnitarioEncajadoPlanificada
        {
            get
            {
                return _CostoCifFijoUnitarioEncajadoPlanificada;
            }

            set
            {
                _CostoCifFijoUnitarioEncajadoPlanificada = value;
            }
        }

        public decimal CostoCifVariableUnitarioEncajadoPlanificada
        {
            get
            {
                return _CostoCifVariableUnitarioEncajadoPlanificada;
            }

            set
            {
                _CostoCifVariableUnitarioEncajadoPlanificada = value;
            }
        }

        public decimal CostoCifFijoUnitarioRetiquetadoPlanificada
        {
            get
            {
                return _CostoCifFijoUnitarioRetiquetadoPlanificada;
            }

            set
            {
                _CostoCifFijoUnitarioRetiquetadoPlanificada = value;
            }
        }

        public decimal CostoCifVariableUnitarioRetiquetadoPlanificada
        {
            get
            {
                return _CostoCifVariableUnitarioRetiquetadoPlanificada;
            }

            set
            {
                _CostoCifVariableUnitarioRetiquetadoPlanificada = value;
            }
        }

        public decimal CostoCifFijo
        {
            get
            {
                return _CostoCifFijo;
            }

            set
            {
                _CostoCifFijo = value;
            }
        }

        public decimal CostoCifVariable
        {
            get
            {
                return _CostoCifVariable;
            }

            set
            {
                _CostoCifVariable = value;
            }
        }

        public decimal MateriaPrimaPlanificada
        {
            get
            {
                return _MateriaPrimaPlanificada;
            }

            set
            {
                _MateriaPrimaPlanificada = value;
            }
        }

        public decimal EnvasePlanificada
        {
            get
            {
                return _EnvasePlanificada;
            }

            set
            {
                _EnvasePlanificada = value;
            }
        }

        public decimal EmbalajePlanificada
        {
            get
            {
                return _EmbalajePlanificada;
            }

            set
            {
                _EmbalajePlanificada = value;
            }
        }

        public decimal ManoObraPlanificada
        {
            get
            {
                return _ManoObraPlanificada;
            }

            set
            {
                _ManoObraPlanificada = value;
            }
        }

        public decimal CostoCifPlanificada
        {
            get
            {
                return _CostoCifPlanificada;
            }

            set
            {
                _CostoCifPlanificada = value;
            }
        }

        public decimal EmbalajeEncajado
        {
            get
            {
                return _EmbalajeEncajado;
            }

            set
            {
                _EmbalajeEncajado = value;
            }
        }

        public decimal EmbalajeRetiquetado
        {
            get
            {
                return _EmbalajeRetiquetado;
            }

            set
            {
                _EmbalajeRetiquetado = value;
            }
        }

        public decimal ManoObraEnvasado
        {
            get
            {
                return _ManoObraEnvasado;
            }

            set
            {
                _ManoObraEnvasado = value;
            }
        }

        public decimal ManoObraEncajado
        {
            get
            {
                return _ManoObraEncajado;
            }

            set
            {
                _ManoObraEncajado = value;
            }
        }

        public decimal ManoObraRetiquetado
        {
            get
            {
                return _ManoObraRetiquetado;
            }

            set
            {
                _ManoObraRetiquetado = value;
            }
        }

        public decimal CostoCifFijoEnvasado
        {
            get
            {
                return _CostoCifFijoEnvasado;
            }

            set
            {
                _CostoCifFijoEnvasado = value;
            }
        }

        public decimal CostoCifVariableEnvasado
        {
            get
            {
                return _CostoCifVariableEnvasado;
            }

            set
            {
                _CostoCifVariableEnvasado = value;
            }
        }

        public decimal CostoCifFijoEncajado
        {
            get
            {
                return _CostoCifFijoEncajado;
            }

            set
            {
                _CostoCifFijoEncajado = value;
            }
        }

        public decimal CostoCifVariableEncajado
        {
            get
            {
                return _CostoCifVariableEncajado;
            }

            set
            {
                _CostoCifVariableEncajado = value;
            }
        }

        public decimal CostoCifFijoRetiquetado
        {
            get
            {
                return _CostoCifFijoRetiquetado;
            }

            set
            {
                _CostoCifFijoRetiquetado = value;
            }
        }

        public decimal CostoCifVariableRetiquetado
        {
            get
            {
                return _CostoCifVariableRetiquetado;
            }

            set
            {
                _CostoCifVariableRetiquetado = value;
            }
        }

        public decimal EmbalajeEncajadoPlanificada
        {
            get
            {
                return _EmbalajeEncajadoPlanificada;
            }

            set
            {
                _EmbalajeEncajadoPlanificada = value;
            }
        }

        public decimal EmbalajeRetiquetadoPlanificada
        {
            get
            {
                return _EmbalajeRetiquetadoPlanificada;
            }

            set
            {
                _EmbalajeRetiquetadoPlanificada = value;
            }
        }

        public decimal ManoObraEnvasadoPlanificada
        {
            get
            {
                return _ManoObraEnvasadoPlanificada;
            }

            set
            {
                _ManoObraEnvasadoPlanificada = value;
            }
        }

        public decimal ManoObraEncajadoPlanificada
        {
            get
            {
                return _ManoObraEncajadoPlanificada;
            }

            set
            {
                _ManoObraEncajadoPlanificada = value;
            }
        }

        public decimal ManoObraRetiquetadoPlanificada
        {
            get
            {
                return _ManoObraRetiquetadoPlanificada;
            }

            set
            {
                _ManoObraRetiquetadoPlanificada = value;
            }
        }

        public decimal CostoCifFijoEnvasadoPlanificada
        {
            get
            {
                return _CostoCifFijoEnvasadoPlanificada;
            }

            set
            {
                _CostoCifFijoEnvasadoPlanificada = value;
            }
        }

        public decimal CostoCifVariableEnvasadoPlanificada
        {
            get
            {
                return _CostoCifVariableEnvasadoPlanificada;
            }

            set
            {
                _CostoCifVariableEnvasadoPlanificada = value;
            }
        }

        public decimal CostoCifFijoEncajadoPlanificada
        {
            get
            {
                return _CostoCifFijoEncajadoPlanificada;
            }

            set
            {
                _CostoCifFijoEncajadoPlanificada = value;
            }
        }

        public decimal CostoCifVariableEncajadoPlanificada
        {
            get
            {
                return _CostoCifVariableEncajadoPlanificada;
            }

            set
            {
                _CostoCifVariableEncajadoPlanificada = value;
            }
        }

        public decimal CostoCifFijoRetiquetadoPlanificada
        {
            get
            {
                return _CostoCifFijoRetiquetadoPlanificada;
            }

            set
            {
                _CostoCifFijoRetiquetadoPlanificada = value;
            }
        }

        public decimal CostoCifVariableRetiquetadoPlanificada
        {
            get
            {
                return _CostoCifVariableRetiquetadoPlanificada;
            }

            set
            {
                _CostoCifVariableRetiquetadoPlanificada = value;
            }
        }
    }
}
