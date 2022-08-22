using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class InventarioDetaEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaInvDet = "ClaveInventarioDeta";
        public const string ClaInvCab = "ClaveInventarioCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CorInvCab = "CorrelativoInventarioCabe";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string UbiExi = "UbicacionExistencia";
        public const string StoFis = "StockFisico";
        public const string StoTeo = "StockTeorico";
        public const string DifSto = "DiferenciaStock";
        public const string CEstInvDet = "CEstadoInventarioDeta";
        public const string NEstInvDet = "NEstadoInventarioDeta";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveInventarioDeta = string.Empty;
        private string _ClaveInventarioCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CorrelativoInventarioCabe = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _CodigoUnidadMedida = string.Empty;
        private string _UbicacionExistencia = string.Empty;
        private decimal _StockFisico = 0;
        private decimal _StockTeorico = 0;
        private decimal _DiferenciaStock = 0;
        private string _CEstadoInventarioDeta = "1";
        private string _NEstadoInventarioDeta = "Activo";
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

        public string ClaveInventarioDeta
        {
            get { return this._ClaveInventarioDeta; }
            set { this._ClaveInventarioDeta = value; }
        }

        public string ClaveInventarioCabe
        {
            get { return this._ClaveInventarioCabe; }
            set { this._ClaveInventarioCabe = value; }
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

        public string CorrelativoInventarioCabe
        {
            get { return this._CorrelativoInventarioCabe; }
            set { this._CorrelativoInventarioCabe = value; }
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

        public string CodigoUnidadMedida
        {
            get { return _CodigoUnidadMedida; }
            set { _CodigoUnidadMedida = value; }
        }

        public string UbicacionExistencia
        {
            get { return _UbicacionExistencia; }
            set { _UbicacionExistencia = value; }
        }

        public decimal StockFisico
        {
            get { return _StockFisico; }
            set { _StockFisico = value; }
        }

        public decimal StockTeorico
        {
            get { return _StockTeorico; }
            set { _StockTeorico = value; }
        }

        public decimal DiferenciaStock
        {
            get { return _DiferenciaStock; }
            set { _DiferenciaStock = value; }
        }

        public string CEstadoInventarioDeta
        {
            get { return this._CEstadoInventarioDeta; }
            set { this._CEstadoInventarioDeta = value; }
        }
        
        public string NEstadoInventarioDeta
        {
            get { return this._NEstadoInventarioDeta; }
            set { this._NEstadoInventarioDeta = value; }
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
