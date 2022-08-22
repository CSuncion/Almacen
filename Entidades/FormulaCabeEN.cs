using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class FormulaCabeEN
    {
        
        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaForCab = "ClaveFormulaCabe";
        public const string CodEmp = "CodigoEmpresa";       
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";       
        public const string Coment = "Comentario";        
        public const string MasUni = "MasaUnidad";       
        public const string RatForCab = "RatioFormulaCabe";       
        public const string CodAlmSemPro = "CodigoAlmacenSemiProducto";
        public const string DesAlmSemPro = "DescripcionAlmacenSemiProducto";
        public const string CodSemPro = "CodigoSemiProducto";
        public const string DesExiSemPro = "DescripcionExistenciaSemiProducto";
        public const string CodUniMedSemPro = "CodigoUnidadMedidaSemiProducto";
        public const string NomUniMedSemPro = "NombreUnidadMedidaSemiProducto";
        public const string CodAlmEmp = "CodigoAlmacenEmpaquetado";
        public const string DesAlmEmp = "DescripcionAlmacenEmpaquetado";
        public const string NumDiaVctoForCab = "NumeroDiasVctoFormulaCabe";
        public const string CManCua = "CManejaCuarentena";
        public const string NManCua = "NManejaCuarentena";
        public const string CEstForCab = "CEstadoFormulaCabe";
        public const string NEstForCab = "NEstadoFormulaCabe";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveFormulaCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty; 
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;        
        private string _Comentario = string.Empty;       
        private decimal _MasaUnidad = 0;      
        private decimal _RatioFormulaCabe = 0;        
        private string _CodigoAlmacenSemiProducto = string.Empty;
        private string _DescripcionAlmacenSemiProducto = string.Empty;
        private string _CodigoSemiProducto = string.Empty;
        private string _DescripcionExistenciaSemiProducto = string.Empty;
        private string _CodigoUnidadMedidaSemiProducto = string.Empty;
        private string _NombreUnidadMedidaSemiProducto = string.Empty;
        private string _CodigoAlmacenEmpaquetado = string.Empty;
        private string _DescripcionAlmacenEmpaquetado = string.Empty;
        private decimal _NumeroDiasVctoFormulaCabe = 0;
        private string _CManejaCuarentena = "0";
        private string _NManejaCuarentena = "No";
        private string _CEstadoFormulaCabe = "1";  
        private string _NEstadoFormulaCabe = "Activo";
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
        
        public string ClaveFormulaCabe 
        {
            get { return this._ClaveFormulaCabe; }
            set { this._ClaveFormulaCabe = value; }
        }

        public string CodigoEmpresa 
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
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

        public string Comentario
        {
            get { return this._Comentario; }
            set { this._Comentario = value; }
        }

        public decimal MasaUnidad
        {
            get { return this._MasaUnidad; }
            set { this._MasaUnidad = value; }
        }

        public decimal RatioFormulaCabe
        {
            get { return this._RatioFormulaCabe; }
            set { this._RatioFormulaCabe = value; }
        }

        public string CodigoAlmacenSemiProducto
        {
            get { return this._CodigoAlmacenSemiProducto; }
            set { this._CodigoAlmacenSemiProducto = value; }
        }

        public string DescripcionAlmacenSemiProducto
        {
            get { return this._DescripcionAlmacenSemiProducto; }
            set { this._DescripcionAlmacenSemiProducto = value; }
        }

        public string CodigoSemiProducto
        {
            get { return this._CodigoSemiProducto; }
            set { this._CodigoSemiProducto = value; }
        }

        public string DescripcionExistenciaSemiProducto
        {
            get { return this._DescripcionExistenciaSemiProducto; }
            set { this._DescripcionExistenciaSemiProducto = value; }
        }

        public string CodigoUnidadMedidaSemiProducto
        {
            get { return this._CodigoUnidadMedidaSemiProducto; }
            set { this._CodigoUnidadMedidaSemiProducto = value; }
        }

        public string NombreUnidadMedidaSemiProducto
        {
            get { return this._NombreUnidadMedidaSemiProducto; }
            set { this._NombreUnidadMedidaSemiProducto = value; }
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

        public decimal NumeroDiasVctoFormulaCabe
        {
            get { return this._NumeroDiasVctoFormulaCabe; }
            set { this._NumeroDiasVctoFormulaCabe = value; }
        }

        public string CManejaCuarentena
        {
            get { return this._CManejaCuarentena; }
            set { this._CManejaCuarentena = value; }
        }

        public string NManejaCuarentena
        {
            get { return this._NManejaCuarentena; }
            set { this._NManejaCuarentena = value; }
        }

        public string CEstadoFormulaCabe
        {
            get { return this._CEstadoFormulaCabe; }
            set { this._CEstadoFormulaCabe = value; }
        }

        public string NEstadoFormulaCabe
        {
            get { return this._NEstadoFormulaCabe; }
            set { this._NEstadoFormulaCabe = value; }
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
