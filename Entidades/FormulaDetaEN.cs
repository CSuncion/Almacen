using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class FormulaDetaEN
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaForDet = "ClaveFormulaDeta";
        public const string ClaForCab = "ClaveFormulaCabe";
        public const string CodExiFor = "CodigoExistenciaFormula";
        public const string DesExiFor = "DescripcionExistenciaFormula";
        public const string CodAlmSemPro = "CodigoAlmacenSemiProducto";
        public const string CodSemPro = "CodigoSemiProducto";
        public const string RatForCab = "RatioFormulaCabe";
        public const string NumDiaVctoForCab = "NumeroDiasVctoFormulaCabe";
        public const string MasUni = "MasaUnidad";
        public const string CorForDet = "CorrelativoFormulaDeta";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";     
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";     
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string PreProExi = "PrecioPromedioExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CanForDet = "CantidadFormulaDeta";
        public const string CanCajForDet = "CantidadCajaFormulaDeta";
        public const string CTipDes = "CTipoDescarga";
        public const string NTipDes = "NTipoDescarga";
        public const string CTipFac = "CTipoFactor";
        public const string NTipFac = "NTipoFactor";
        public const string CodAlmProTer = "CodigoAlmacenProTer";
        public const string DesAlmProTer = "DescripcionAlmacenProTer";
        public const string CodExiProTer = "CodigoExistenciaProTer";
        public const string DesExiProTer = "DescripcionExistenciaProTer";
        public const string CodUniMedProTer = "CodigoUnidadMedidaProTer";
        public const string NomUniMedProTer = "NombreUnidadMedidaProTer";
        public const string CodAlmOri = "CodigoAlmacenOrigen";
        public const string DesAlmOri = "DescripcionAlmacenOrigen";
        public const string CodAlmCom = "CodigoAlmacenCompra";
        public const string DesAlmCom = "DescripcionAlmacenCompra";
        public const string CPriLib = "CPrimeraLiberacion";
        public const string NPriLib = "NPrimeraLiberacion";
        public const string CSegLib = "CSegundaLiberacion";
        public const string NSegLib = "NSegundaLiberacion";
        public const string CEstForDet = "CEstadoFormulaDeta";
        public const string NEstForDet = "NEstadoFormulaDeta";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveFormulaDeta = string.Empty;
        private string _ClaveFormulaCabe = string.Empty;
        private string _CodigoExistenciaFormula = string.Empty;
        private string _DescripcionExistenciaFormula = string.Empty;
        private string _CodigoAlmacenSemiProducto = string.Empty;      
        private string _CodigoSemiProducto = string.Empty;
        private decimal _RatioFormulaCabe = 0;
        private decimal _NumeroDiasVctoFormulaCabe = 0;
        private decimal _MasaUnidad = 0;
        private string _CorrelativoFormulaDeta = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;     
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private decimal _PrecioPromedioExistencia = 0;
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private decimal _CantidadFormulaDeta = 0;
        private decimal _CantidadCajaFormulaDeta = 0;
        private string _CTipoDescarga = "1";
        private string _NTipoDescarga = "CALCULADA";
        private string _CTipoFactor = "0";
        private string _NTipoFactor = "Gramos";
        private string _CodigoAlmacenProTer = string.Empty;
        private string _DescripcionAlmacenProTer = string.Empty;
        private string _CodigoExistenciaProTer = string.Empty;
        private string _DescripcionExistenciaProTer = string.Empty;
        private string _CodigoUnidadMedidaProTer = string.Empty;
        private string _NombreUnidadMedidaProTer = string.Empty;
        private string _CodigoAlmacenOrigen = string.Empty;
        private string _DescripcionAlmacenOrigen = string.Empty;
        private string _CodigoAlmacenCompra = string.Empty;
        private string _DescripcionAlmacenCompra = string.Empty;
        private string _CPrimeraLiberacion = "0";
        private string _NPrimeraLiberacion = "No";
        private string _CSegundaLiberacion = "0";
        private string _NSegundaLiberacion = "No";
        private string _CEstadoFormulaDeta = "1";
        private string _NEstadoFormulaDeta = "Activado";
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

        public string ClaveFormulaDeta
        {
            get { return _ClaveFormulaDeta; }
            set { _ClaveFormulaDeta = value; }
        }

        public string ClaveFormulaCabe
        {
            get { return _ClaveFormulaCabe; }
            set { _ClaveFormulaCabe = value; }
        }

        public string CodigoExistenciaFormula
        {
            get { return _CodigoExistenciaFormula; }
            set { _CodigoExistenciaFormula = value; }
        }

        public string DescripcionExistenciaFormula
        {
            get { return _DescripcionExistenciaFormula; }
            set { _DescripcionExistenciaFormula = value; }
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

        public decimal RatioFormulaCabe
        {
            get { return _RatioFormulaCabe; }
            set { _RatioFormulaCabe = value; }
        }

        public decimal NumeroDiasVctoFormulaCabe
        {
            get { return this._NumeroDiasVctoFormulaCabe; }
            set { this._NumeroDiasVctoFormulaCabe = value; }
        }

        public decimal MasaUnidad
        {
            get { return _MasaUnidad; }
            set { _MasaUnidad = value; }
        }

        public string CorrelativoFormulaDeta
        {
            get { return _CorrelativoFormulaDeta; }
            set { _CorrelativoFormulaDeta = value; }
        }

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

        public decimal CantidadFormulaDeta
        {
            get { return _CantidadFormulaDeta; }
            set { _CantidadFormulaDeta = value; }
        }

        public decimal CantidadCajaFormulaDeta
        {
            get { return _CantidadCajaFormulaDeta; }
            set { _CantidadCajaFormulaDeta = value; }
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

        public string CodigoAlmacenProTer
        {
            get { return _CodigoAlmacenProTer; }
            set { _CodigoAlmacenProTer = value; }
        }

        public string DescripcionAlmacenProTer
        {
            get { return _DescripcionAlmacenProTer; }
            set { _DescripcionAlmacenProTer = value; }
        }

        public string CodigoExistenciaProTer
        {
            get { return _CodigoExistenciaProTer; }
            set { _CodigoExistenciaProTer = value; }
        }

        public string DescripcionExistenciaProTer
        {
            get { return _DescripcionExistenciaProTer; }
            set { _DescripcionExistenciaProTer = value; }
        }
                
        public string CodigoUnidadMedidaProTer
        {
            get { return _CodigoUnidadMedidaProTer; }
            set { _CodigoUnidadMedidaProTer = value; }
        }

        public string NombreUnidadMedidaProTer
        {
            get { return _NombreUnidadMedidaProTer; }
            set { _NombreUnidadMedidaProTer = value; }
        }

        public string CodigoAlmacenOrigen
        {
            get { return _CodigoAlmacenOrigen; }
            set { _CodigoAlmacenOrigen = value; }
        }

        public string DescripcionAlmacenOrigen
        {
            get { return _DescripcionAlmacenOrigen; }
            set { _DescripcionAlmacenOrigen = value; }
        }

        public string CodigoAlmacenCompra
        {
            get { return _CodigoAlmacenCompra; }
            set { _CodigoAlmacenCompra = value; }
        }

        public string DescripcionAlmacenCompra
        {
            get { return _DescripcionAlmacenCompra; }
            set { _DescripcionAlmacenCompra = value; }
        }

        public string CPrimeraLiberacion
        {
            get { return _CPrimeraLiberacion; }
            set { _CPrimeraLiberacion = value; }
        }

        public string NPrimeraLiberacion
        {
            get { return _NPrimeraLiberacion; }
            set { _NPrimeraLiberacion = value; }
        }

        public string CSegundaLiberacion
        {
            get { return _CSegundaLiberacion; }
            set { _CSegundaLiberacion = value; }
        }

        public string NSegundaLiberacion
        {
            get { return _NSegundaLiberacion; }
            set { _NSegundaLiberacion = value; }
        }

        public string CEstadoFormulaDeta
        {
            get { return _CEstadoFormulaDeta; }
            set { _CEstadoFormulaDeta = value; }
        }

        public string NEstadoFormulaDeta
        {
            get { return _NEstadoFormulaDeta; }
            set { _NEstadoFormulaDeta = value; }
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
