using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class InventarioCabeEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaInvCab = "ClaveInventarioCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CorInvCab = "CorrelativoInventarioCabe";
        public const string CodPer = "CodigoPersonal";
        public const string NomPer = "NombrePersonal";
        public const string FecInvCab = "FechaInventarioCabe";
        public const string StoFis = "StockFisico";
        public const string StoTeo = "StockTeorico";
        public const string ObsInvCab = "ObservacionInventarioCabe";
        public const string FecGen = "FechaGenera";
        public const string ClaMovIng = "ClaveMovimientoIngreso";
        public const string ClaMovSal = "ClaveMovimientoSalida";
        public const string CEstInvCab = "CEstadoInventarioCabe";
        public const string NEstInvCab = "NEstadoInventarioCabe";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveInventarioCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CorrelativoInventarioCabe = string.Empty;
        private string _CodigoPersonal = string.Empty;
        private string _NombrePersonal = string.Empty;
        private string _FechaInventarioCabe = string.Empty;
        private decimal _StockFisico = 0;
        private decimal _StockTeorico = 0;
        private string _ObservacionInventarioCabe = string.Empty;
        private string _FechaGenera = string.Empty;
        private string _ClaveMovimientoIngreso = string.Empty;
        private string _ClaveMovimientoSalida = string.Empty;
        private string _CEstadoInventarioCabe = "0";
        private string _NEstadoInventarioCabe = "Procesando";
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

        public string CodigoPersonal
        {
            get { return _CodigoPersonal; }
            set { _CodigoPersonal = value; }
        }

        public string NombrePersonal
        {
            get { return _NombrePersonal; }
            set { _NombrePersonal = value; }
        }

        public string FechaInventarioCabe
        {
            get { return _FechaInventarioCabe; }
            set { _FechaInventarioCabe = value; }
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

        public string ObservacionInventarioCabe
        {
            get { return _ObservacionInventarioCabe; }
            set { _ObservacionInventarioCabe = value; }
        }

        public string FechaGenera
        {
            get { return _FechaGenera; }
            set { _FechaGenera = value; }
        }

        public string ClaveMovimientoIngreso
        {
            get { return _ClaveMovimientoIngreso; }
            set { _ClaveMovimientoIngreso = value; }
        }

        public string ClaveMovimientoSalida
        {
            get { return _ClaveMovimientoSalida; }
            set { _ClaveMovimientoSalida = value; }
        }

        public string CEstadoInventarioCabe
        {
            get { return this._CEstadoInventarioCabe; }
            set { this._CEstadoInventarioCabe = value; }
        }
        
        public string NEstadoInventarioCabe
        {
            get { return this._NEstadoInventarioCabe; }
            set { this._NEstadoInventarioCabe = value; }
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
