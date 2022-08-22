using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class ProduccionCabeEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaProCab = "ClaveProduccionCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CorProCab = "CorrelativoProduccionCabe";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string FecProCab = "FechaProduccionCabe";
        public const string PerProCab = "PeriodoProduccionCabe";
        public const string CanFor = "CantidadFormula";
        public const string CanProCab = "CantidadProduccionCabe";
        public const string CanProProCab = "CantidadProducidaProduccionCabe";
        public const string SalProCab = "SaldoProduccionCabe";
        public const string CanReaPro = "CantidadRealProduccion";
        public const string CodLic = "CodigoLicitacion";
        public const string DesLic = "DescripcionLicitacion";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string ObsProCab = "ObservacionProduccionCabe";
        public const string CodMer = "CodigoMercaderia";
        public const string CEsExa = "CEsExacto";
        public const string CTur = "CTurno";
        public const string NTur = "NTurno";
        public const string CodAlmSemPro = "CodigoAlmacenSemiProducto";
        public const string CodSemPro = "CodigoSemiProducto";
        public const string DesSemPro = "DescripcionSemiProducto";
        public const string UniRep = "UnidadesReproceso";
        public const string CosUniRep = "CostoUnidadesReproceso";
        public const string DetForDet = "DetalleFormulasDeta";
        public const string PorRan = "PorcentajeRango";
        public const string CanRan = "CantidadRango";
        public const string CanSinProCab = "CantidadSinceradoProduccionCabe";
        public const string PorSinRan = "PorcentajeSinceradoRango";
        public const string CanSinRan = "CantidadSinceradoRango";
        public const string DetMotSin = "DetalleMotivoSincerado";
        public const string VerFal = "VerdadFalso";
        public const string CEstProCab = "CEstadoProduccionCabe";
        public const string NEstProCab = "NEstadoProduccionCabe";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveProduccionCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CorrelativoProduccionCabe = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty; 
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private string _FechaProduccionCabe = string.Empty;
        private string _PeriodoProduccionCabe = string.Empty;
        private decimal _CantidadFormula = 0;
        private decimal _CantidadProduccionCabe = 0;
        private decimal _CantidadProducidaProduccionCabe = 0;
        private decimal _SaldoProduccionCabe = 0;
        private decimal _CantidadRealProduccion = 0;
        private string _CodigoLicitacion = string.Empty;
        private string _DescripcionLicitacion = string.Empty;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _ObservacionProduccionCabe = string.Empty;
        private string _CodigoMercaderia = string.Empty;
        private string _CEsExacto = "1";//si
        private string _CTurno = "0";//Dia
        private string _NTurno = "DIA";//si
        private string _CodigoAlmacenSemiProducto = string.Empty;
        private string _CodigoSemiProducto = string.Empty;
        private string _DescripcionSemiProducto = string.Empty;
        private decimal _UnidadesReproceso = 0;
        private decimal _CostoUnidadesReproceso = 0;
        private string _DetalleFormulasDeta = string.Empty;
        private decimal _PorcentajeRango = 0;
        private decimal _CantidadRango = 0;
        private decimal _CantidadSinceradoProduccionCabe = 0;
        private decimal _PorcentajeSinceradoRango = 0;
        private decimal _CantidadSinceradoRango = 0;
        private string _DetalleMotivoSincerado = string.Empty;        
        private bool _VerdadFalso = false;
        private string _CEstadoProduccionCabe = "0";  
        private string _NEstadoProduccionCabe = "Planificada";
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

        public string FechaProduccionCabe
        {
            get { return this._FechaProduccionCabe; }
            set { this._FechaProduccionCabe = value; }
        }

        public string PeriodoProduccionCabe
        {
            get { return this._PeriodoProduccionCabe; }
            set { this._PeriodoProduccionCabe = value; }
        }

        public decimal CantidadFormula
        {
            get { return this._CantidadFormula; }
            set { this._CantidadFormula = value; }
        }

        public decimal CantidadProduccionCabe
        {
            get { return this._CantidadProduccionCabe; }
            set { this._CantidadProduccionCabe = value; }
        }

        public decimal CantidadProducidaProduccionCabe
        {
            get { return this._CantidadProducidaProduccionCabe; }
            set { this._CantidadProducidaProduccionCabe = value; }
        }

        public decimal SaldoProduccionCabe
        {
            get { return this._SaldoProduccionCabe; }
            set { this._SaldoProduccionCabe = value; }
        }

        public decimal CantidadRealProduccion
        {
            get { return this._CantidadRealProduccion; }
            set { this._CantidadRealProduccion = value; }
        }

        public string CodigoLicitacion
        {
            get { return this._CodigoLicitacion; }
            set { this._CodigoLicitacion = value; }
        }

        public string DescripcionLicitacion
        {
            get { return this._DescripcionLicitacion; }
            set { this._DescripcionLicitacion = value; }
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

        public string ObservacionProduccionCabe
        {
            get { return this._ObservacionProduccionCabe; }
            set { this._ObservacionProduccionCabe = value; }
        }

        public string CodigoMercaderia
        {
            get { return this._CodigoMercaderia; }
            set { this._CodigoMercaderia = value; }
        }

        public string CEsExacto
        {
            get { return this._CEsExacto; }
            set { this._CEsExacto = value; }
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

        public string DetalleFormulasDeta
        {
            get { return this._DetalleFormulasDeta; }
            set { this._DetalleFormulasDeta = value; }
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

        public decimal CantidadSinceradoProduccionCabe
        {
            get { return this._CantidadSinceradoProduccionCabe; }
            set { this._CantidadSinceradoProduccionCabe = value; }
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
        
        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }

        public string CEstadoProduccionCabe
        {
            get { return this._CEstadoProduccionCabe; }
            set { this._CEstadoProduccionCabe = value; }
        }

        public string NEstadoProduccionCabe
        {
            get { return this._NEstadoProduccionCabe; }
            set { this._NEstadoProduccionCabe = value; }
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
