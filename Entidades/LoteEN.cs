using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class LoteEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaLot = "ClaveLote";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CodLot = "CodigoLote";
        public const string FecVenLot = "FechaVencimientoLote";       
        public const string StoLot = "StockLote";
        public const string StoSalLot = "StockSaldoLote";
        public const string ClaMovDet = "ClaveMovimientoDeta";
        public const string ClaMovCab = "ClaveMovimientoCabe";
        public const string UltCorLotDet = "UltimoCorrelativoLoteDeta";
        public const string NumLot = "NumeroLote";
        public const string FecProLot = "FechaProduccionLote";
        public const string VerFal = "VerdadFalso";
        public const string StoConLot = "StockConversionLote";
        public const string EmaCli = "EmailCliente";
        public const string CEstLot = "CEstadoLote";
        public const string NEstLot = "NEstadoLote";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveLote = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _CodigoUnidadMedida = "NIU";
        private string _NombreUnidadMedida = string.Empty;
        private string _CodigoLote = string.Empty;
        private string _FechaVencimientoLote = string.Empty;       
        private decimal _StockLote = 0;
        private decimal _StockSaldoLote = 0;
        private string _ClaveMovimientoDeta = string.Empty;
        private string _ClaveMovimientoCabe = string.Empty;
        private string _UltimoCorrelativoLoteDeta = string.Empty;
        private string _NumeroLote = string.Empty;
        private string _FechaProduccionLote = string.Empty;
        private bool _VerdadFalso = false;
        private decimal _StockConversionLote = 0;
        private string _CEstadoLote = "1";
        private string _NEstadoLote = "Activo";
        private string _EmailCliente = string.Empty;
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
        
        public string ClaveLote
        {
            get { return this._ClaveLote; }
            set { this._ClaveLote = value; }
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

        public string FechaVencimientoLote
        {
            get { return this._FechaVencimientoLote; }
            set { this._FechaVencimientoLote = value; }
        }
        
        public decimal StockLote
        {
            get { return this._StockLote; }
            set { this._StockLote = value; }
        }

        public decimal StockSaldoLote
        {
            get { return this._StockSaldoLote; }
            set { this._StockSaldoLote = value; }
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

        public string UltimoCorrelativoLoteDeta
        {
            get { return this._UltimoCorrelativoLoteDeta; }
            set { this._UltimoCorrelativoLoteDeta = value; }
        }

        public string NumeroLote
        {
            get { return this._NumeroLote; }
            set { this._NumeroLote = value; }
        }

        public string FechaProduccionLote
        {
            get { return this._FechaProduccionLote; }
            set { this._FechaProduccionLote = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }
        public decimal StockConversionLote
        {
            get { return this._StockConversionLote; }
            set { this._StockConversionLote = value; }
        }

        public string EmailCliente
        {
            get { return this._EmailCliente; }
            set { this._EmailCliente = value; }
        }



        public string CEstadoLote
        {
            get { return this._CEstadoLote; }
            set { this._CEstadoLote = value; }
        }
        
        public string NEstadoLote
        {
            get { return this._NEstadoLote; }
            set { this._NEstadoLote = value; }
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
