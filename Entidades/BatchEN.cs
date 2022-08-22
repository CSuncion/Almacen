using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class BatchEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaBat = "ClaveBatch";
        public const string CodEmp = "CodigoEmpresa";
        public const string PerBat = "PeriodoBatch";
        public const string CorBat = "CorrelativoBatch";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CodBat = "CodigoBatch";
        public const string FecVenLot = "FechaVencimientoBatch";       
        public const string StoBat = "StockBatch";
        public const string StoSalBat = "StockSaldoBatch";
        public const string ClaLot = "ClaveLote";
        public const string ClaMovDet = "ClaveMovimientoDeta";
        public const string ClaMovCab = "ClaveMovimientoCabe";
        public const string UltCorLotDet = "UltimoCorrelativoBatchDeta";
        public const string VerFal = "VerdadFalso";     
        public const string CEstBat = "CEstadoBatch";
        public const string NEstBat = "NEstadoBatch";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveBatch = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _PeriodoBatch = string.Empty;
        private string _CorrelativoBatch = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _CodigoUnidadMedida = "NIU";
        private string _NombreUnidadMedida = string.Empty;
        private string _CodigoBatch = string.Empty;
        private string _FechaVencimientoBatch = string.Empty;       
        private decimal _StockBatch = 0;
        private decimal _StockSaldoBatch = 0;
        private string _ClaveLote = string.Empty;
        private string _ClaveMovimientoDeta = string.Empty;
        private string _ClaveMovimientoCabe = string.Empty;
        private string _UltimoCorrelativoBatchDeta = string.Empty;
        private bool _VerdadFalso = false;        
        private string _CEstadoBatch = "1";
        private string _NEstadoBatch = "Activo";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }
        
        public string ClaveBatch
        {
            get { return this._ClaveBatch; }
            set { this._ClaveBatch = value; }
        }
        
        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string PeriodoBatch
        {
            get { return this._PeriodoBatch; }
            set { this._PeriodoBatch = value; }
        }

        public string CorrelativoBatch
        {
            get { return this._CorrelativoBatch; }
            set { this._CorrelativoBatch = value; }
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

        public string CodigoBatch
        {
            get { return this._CodigoBatch; }
            set { this._CodigoBatch = value; }
        }

        public string FechaVencimientoBatch
        {
            get { return this._FechaVencimientoBatch; }
            set { this._FechaVencimientoBatch = value; }
        }
        
        public decimal StockBatch
        {
            get { return this._StockBatch; }
            set { this._StockBatch = value; }
        }

        public decimal StockSaldoBatch
        {
            get { return this._StockSaldoBatch; }
            set { this._StockSaldoBatch = value; }
        }

        public string ClaveLote
        {
            get { return _ClaveLote; }
            set { _ClaveLote = value; }
        }

        public string ClaveMovimientoDeta
        {
            get { return _ClaveMovimientoDeta; }
            set { _ClaveMovimientoDeta = value; }
        }

        public string ClaveMovimientoCabe
        {
            get { return _ClaveMovimientoCabe; }
            set { _ClaveMovimientoCabe = value; }
        }

        public string UltimoCorrelativoBatchDeta
        {
            get { return this._UltimoCorrelativoBatchDeta; }
            set { this._UltimoCorrelativoBatchDeta = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }

        public string CEstadoBatch
        {
            get { return this._CEstadoBatch; }
            set { this._CEstadoBatch = value; }
        }
        
        public string NEstadoBatch
        {
            get { return this._NEstadoBatch; }
            set { this._NEstadoBatch = value; }
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
