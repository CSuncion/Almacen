using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class ProduccionExisEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaProExi = "ClaveProduccionExis";
        public const string ClaProDet = "ClaveProduccionDeta";
        public const string ClaProCab = "ClaveProduccionCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodPer = "CodigoPersonal";
        public const string CorProCab = "CorrelativoProduccionCabe";
        public const string CorProDet = "CorrelativoProduccionDeta";
        public const string CorProExi = "CorrelativoProduccionExis";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";        
        public const string CanProExi = "CantidadProduccionExis";
        public const string CanGr = "CantidadGr";
        public const string CanKg = "CantidadKg";
        public const string PreUni = "PrecioUnitario";
        public const string CanFor = "CantidadFormula";
        public const string CanGrFor = "CantidadGrFormula";
        public const string CanKgFor = "CantidadKgFormula";
        public const string CTipDes = "CTipoDescarga";
        public const string NTipDes = "NTipoDescarga";
        public const string CTipFac = "CTipoFactor";
        public const string CodAlmProTer = "CodigoAlmacenProTer";
        public const string CodExiProTer = "CodigoExistenciaProTer";
        public const string CodAlmOri = "CodigoAlmacenOrigen";
        public const string DesAlmOri = "DescripcionAlmacenOrigen";
        public const string CodPerOri = "CodigoPersonalOrigen";
        public const string CodSol = "CodigoSolicitud";
        public const string FecProDet = "FechaProduccionDeta";
        public const string CodFor = "CodigoFormula";
        public const string DesFor = "DescripcionFormula";
        public const string CTur = "CTurno";
        public const string CanProDet = "CantidadProduccionDeta";
        public const string ClaProProTer = "ClaveProduccionProTer";
        public const string ClaEnc = "ClaveEncajado";
        public const string PerEnc = "PeriodoEncajado";
        public const string ClaForCab = "ClaveFormulaCabe";
        public const string PerProDet = "PeriodoProduccionDeta";
        public const string ClaRet = "ClaveRetiquetado";
        public const string PerRet = "PeriodoRetiquetado";
        public const string CanDes = "CantidadDesmedro";
        public const string DetMotDes = "DetalleMotivoDesmedro";
        public const string CEstDes = "CEstadoDesmedro";
        public const string NEstDes = "NEstadoDesmedro";
        public const string CanDevProExi = "CantidadDevueltaProduccionExis";
        public const string CodAlmCom = "CodigoAlmacenCompra";
        public const string CSegLib = "CSegundaLiberacion";
        public const string CanSegLib = "CantidadSegundaLiberacion";
        public const string CEstSegLib = "CEstadoSegundaLiberacion";
        public const string NEstSegLib = "NEstadoSegundaLiberacion";
        public const string VerFal = "VerdadFalso";
        public const string CEstProExi = "CEstadoProduccionExis";
        public const string NEstProExi = "NEstadoProduccionExis";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveProduccionExis = string.Empty;
        private string _ClaveProduccionDeta = string.Empty;
        private string _ClaveProduccionCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoPersonal = string.Empty;
        private string _CorrelativoProduccionCabe = string.Empty;
        private string _CorrelativoProduccionDeta = string.Empty;
        private string _CorrelativoProduccionExis = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty; 
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;        
        private decimal _CantidadProduccionExis = 0;
        private decimal _CantidadGr = 0;
        private decimal _CantidadKg = 0;
        private decimal _PrecioUnitario = 0;
        private decimal _CantidadFormula = 0;
        private decimal _CantidadGrFormula = 0;
        private decimal _CantidadKgFormula = 0;
        private string _CTipoDescarga = "1";
        private string _NTipoDescarga = "CALCULADA";
        private string _CTipoFactor = "0";
        private string _CodigoAlmacenProTer = string.Empty;
        private string _CodigoExistenciaProTer = string.Empty;
        private string _CodigoAlmacenOrigen = string.Empty;
        private string _DescripcionAlmacenOrigen = string.Empty;
        private string _CodigoPersonalOrigen = string.Empty;
        private string _CodigoSolicitud = string.Empty;
        private string _FechaProduccionDeta = string.Empty;
        private string _CodigoFormula = string.Empty;
        private string _DescripcionFormula = string.Empty;
        private string _CTurno = string.Empty;
        private decimal _CantidadProduccionDeta = 0;
        private string _ClaveProduccionProTer = string.Empty;
        private string _ClaveEncajado = string.Empty;
        private string _PeriodoEncajado = string.Empty;
        private string _ClaveFormulaCabe = string.Empty;
        private string _PeriodoProduccionDeta = string.Empty;
        private string _ClaveRetiquetado = string.Empty;
        private string _PeriodoRetiquetado = string.Empty;
        private decimal _CantidadDesmedro = 0;
        private string _DetalleMotivoDesmedro = string.Empty;       
        private string _CEstadoDesmedro = "1";
        private string _NEstadoDesmedro = "Activo";
        private decimal _CantidadDevueltaProduccionExis = 0;
        private string _CodigoAlmacenCompra = string.Empty;
        private string _CSegundaLiberacion = "0";
        private decimal _CantidadSegundaLiberacion = 0;
        private string _CEstadoSegundaLiberacion = "1";
        private string _NEstadoSegundaLiberacion = "Activo";
        private bool _VerdadFalso = false;
        private string _CEstadoProduccionExis = "1";  
        private string _NEstadoProduccionExis = "Activo";
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

        public string ClaveProduccionExis
        {
            get { return this._ClaveProduccionExis; }
            set { this._ClaveProduccionExis = value; }
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

        public string CodigoPersonal
        {
            get { return this._CodigoPersonal; }
            set { this._CodigoPersonal = value; }
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

        public string CorrelativoProduccionExis
        {
            get { return this._CorrelativoProduccionExis; }
            set { this._CorrelativoProduccionExis = value; }
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

        public decimal CantidadProduccionExis
        {
            get { return this._CantidadProduccionExis; }
            set { this._CantidadProduccionExis = value; }
        }

        public decimal CantidadGr
        {
            get { return this._CantidadGr; }
            set { this._CantidadGr = value; }
        }

        public decimal CantidadKg
        {
            get { return this._CantidadKg; }
            set { this._CantidadKg = value; }
        }

        public decimal PrecioUnitario
        {
            get { return this._PrecioUnitario; }
            set { this._PrecioUnitario = value; }
        }

        public decimal CantidadFormula
        {
            get { return this._CantidadFormula; }
            set { this._CantidadFormula = value; }
        }

        public decimal CantidadGrFormula
        {
            get { return this._CantidadGrFormula; }
            set { this._CantidadGrFormula = value; }
        }

        public decimal CantidadKgFormula
        {
            get { return this._CantidadKgFormula; }
            set { this._CantidadKgFormula = value; }
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

        public string CodigoAlmacenProTer
        {
            get { return this._CodigoAlmacenProTer; }
            set { this._CodigoAlmacenProTer = value; }
        }

        public string CodigoExistenciaProTer
        {
            get { return this._CodigoExistenciaProTer; }
            set { this._CodigoExistenciaProTer = value; }
        }

        public string CodigoAlmacenOrigen
        {
            get { return this._CodigoAlmacenOrigen; }
            set { this._CodigoAlmacenOrigen = value; }
        }

        public string DescripcionAlmacenOrigen
        {
            get { return this._DescripcionAlmacenOrigen; }
            set { this._DescripcionAlmacenOrigen = value; }
        }

        public string CodigoPersonalOrigen
        {
            get { return this._CodigoPersonalOrigen; }
            set { this._CodigoPersonalOrigen = value; }
        }

        public string CodigoSolicitud
        {
            get { return this._CodigoSolicitud; }
            set { this._CodigoSolicitud = value; }
        }

        public string FechaProduccionDeta
        {
            get { return this._FechaProduccionDeta; }
            set { this._FechaProduccionDeta = value; }
        }

        public string CodigoFormula
        {
            get { return this._CodigoFormula; }
            set { this._CodigoFormula = value; }
        }

        public string DescripcionFormula
        {
            get { return this._DescripcionFormula; }
            set { this._DescripcionFormula = value; }
        }

        public string CTurno
        {
            get { return this._CTurno; }
            set { this._CTurno = value; }
        }

        public decimal CantidadProduccionDeta
        {
            get { return this._CantidadProduccionDeta; }
            set { this._CantidadProduccionDeta = value; }
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

        public string PeriodoEncajado
        {
            get { return this._PeriodoEncajado; }
            set { this._PeriodoEncajado = value; }
        }

        public string ClaveFormulaCabe
        {
            get { return this._ClaveFormulaCabe; }
            set { this._ClaveFormulaCabe = value; }
        }

        public string PeriodoProduccionDeta
        {
            get { return this._PeriodoProduccionDeta; }
            set { this._PeriodoProduccionDeta = value; }
        }

        public string ClaveRetiquetado
        {
            get { return this._ClaveRetiquetado; }
            set { this._ClaveRetiquetado = value; }
        }

        public string PeriodoRetiquetado
        {
            get { return this._PeriodoRetiquetado; }
            set { this._PeriodoRetiquetado = value; }
        }

        public decimal CantidadDesmedro
        {
            get { return this._CantidadDesmedro; }
            set { this._CantidadDesmedro = value; }
        }

        public string DetalleMotivoDesmedro
        {
            get { return this._DetalleMotivoDesmedro; }
            set { this._DetalleMotivoDesmedro = value; }
        }

        public string CEstadoDesmedro
        {
            get { return this._CEstadoDesmedro; }
            set { this._CEstadoDesmedro = value; }
        }

        public string NEstadoDesmedro
        {
            get { return this._NEstadoDesmedro; }
            set { this._NEstadoDesmedro = value; }
        }

        public decimal CantidadDevueltaProduccionExis
        {
            get { return this._CantidadDevueltaProduccionExis; }
            set { this._CantidadDevueltaProduccionExis = value; }
        }

        public string CodigoAlmacenCompra
        {
            get { return this._CodigoAlmacenCompra; }
            set { this._CodigoAlmacenCompra = value; }
        }

        public string CSegundaLiberacion
        {
            get
            {
                return _CSegundaLiberacion;
            }

            set
            {
                _CSegundaLiberacion = value;
            }
        }

        public decimal CantidadSegundaLiberacion
        {
            get
            {
                return _CantidadSegundaLiberacion;
            }

            set
            {
                _CantidadSegundaLiberacion = value;
            }
        }

        public string CEstadoSegundaLiberacion
        {
            get
            {
                return _CEstadoSegundaLiberacion;
            }

            set
            {
                _CEstadoSegundaLiberacion = value;
            }
        }

        public string NEstadoSegundaLiberacion
        {
            get
            {
                return _NEstadoSegundaLiberacion;
            }

            set
            {
                _NEstadoSegundaLiberacion = value;
            }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }

        public string CEstadoProduccionExis
        {
            get { return this._CEstadoProduccionExis; }
            set { this._CEstadoProduccionExis = value; }
        }

        public string NEstadoProduccionExis
        {
            get { return this._NEstadoProduccionExis; }
            set { this._NEstadoProduccionExis = value; }
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
