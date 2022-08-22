using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class LoteDetaEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaLotDet = "ClaveLoteDeta";
        public const string ClaLot = "ClaveLote";
        public const string FecProLot = "FechaProduccionLote";
        public const string FecVenLot = "FechaVencimientoLote";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CodLot = "CodigoLote";
        public const string CorLotDet = "CorrelativoLoteDeta";       
        public const string CanLotDet = "CantidadLoteDeta";
        public const string StoAntLot = "StockAnteriorLote";
        public const string ClaMovDet = "ClaveMovimientoDeta";
        public const string ClaMovCab = "ClaveMovimientoCabe";
        public const string VerFal = "VerdadFalso";  
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveLoteDeta = string.Empty;
        private string _ClaveLote = string.Empty;
        private string _FechaProduccionLote = string.Empty;
        private string _FechaVencimientoLote = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _CodigoUnidadMedida = "NIU";
        private string _NombreUnidadMedida = string.Empty;
        private string _CodigoLote = string.Empty;
        private string _CorrelativoLoteDeta = string.Empty;       
        private decimal _CantidadLoteDeta = 0;
        private decimal _StockAnteriorLote = 0;
        private string _ClaveMovimientoDeta = string.Empty;
        private string _ClaveMovimientoCabe = string.Empty;
        private bool _VerdadFalso = false;                
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
        
        public string ClaveLoteDeta
        {
            get { return this._ClaveLoteDeta; }
            set { this._ClaveLoteDeta = value; }
        }

        public string ClaveLote
        {
            get { return this._ClaveLote; }
            set { this._ClaveLote = value; }
        }

        public string FechaProduccionLote
        {
            get { return this._FechaProduccionLote; }
            set { this._FechaProduccionLote = value; }
        }

        public string FechaVencimientoLote
        {
            get { return this._FechaVencimientoLote; }
            set { this._FechaVencimientoLote = value; }
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

        public string CodigoLote
        {
            get { return this._CodigoLote; }
            set { this._CodigoLote = value; }
        }

        public string CorrelativoLoteDeta
        {
            get { return this._CorrelativoLoteDeta; }
            set { this._CorrelativoLoteDeta = value; }
        }
        
        public decimal CantidadLoteDeta
        {
            get { return this._CantidadLoteDeta; }
            set { this._CantidadLoteDeta = value; }
        }

        public decimal StockAnteriorLote
        {
            get { return this._StockAnteriorLote; }
            set { this._StockAnteriorLote = value; }
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

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
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
