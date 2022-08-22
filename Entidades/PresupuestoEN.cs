using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class PresupuestoEN
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaPre = "ClavePresupuesto";
        public const string CodPre = "CodigoPresupuesto";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string AnoPre = "AnoPresupuesto";
        public const string CMesPre = "CMesPresupuesto";
        public const string NMesPre = "NMesPresupuesto";
        public const string CCenCto = "CCentroCosto";
        public const string NCenCto = "NCentroCosto";
        public const string ImpPre = "ImportePresupuesto";
        public const string ImpAdiPre = "ImporteAdicionalPresupuesto";
        public const string SalPre = "SaldoPresupuesto";
        public const string SalPreTem = "SaldoPresupuestoTemporal";
        public const string CEstPre = "CEstadoPresupuesto";
        public const string NEstPre = "NEstadoPresupuesto";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClavePresupuesto = string.Empty;
        private string _CodigoPresupuesto = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _AnoPresupuesto = string.Empty;
        private string _CMesPresupuesto = "01";
        private string _NMesPresupuesto = string.Empty;
        private string _CCentroCosto = string.Empty;
        private string _NCentroCosto = string.Empty;
        private decimal _ImportePresupuesto = 0;
        private decimal _ImporteAdicionalPresupuesto = 0;
        private decimal _SaldoPresupuesto = 0;
        private decimal _SaldoPresupuestoTemporal = 0;
        private string _CEstadoPresupuesto = "1";
        private string _NEstadoPresupuesto = "Abierto";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();
        private decimal _NuevoSaldoPresupuesto = 0;

        //propiedades
        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClavePresupuesto
        {
            get { return _ClavePresupuesto; }
            set { _ClavePresupuesto = value; }
        }

        public string CodigoPresupuesto
        {
            get { return _CodigoPresupuesto; }
            set { _CodigoPresupuesto = value; }
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

        public string AnoPresupuesto
        {
            get { return _AnoPresupuesto; }
            set { _AnoPresupuesto = value; }
        }

        public string CMesPresupuesto
        {
            get { return _CMesPresupuesto; }
            set { _CMesPresupuesto = value; }
        }

        public string NMesPresupuesto
        {
            get { return _NMesPresupuesto; }
            set { _NMesPresupuesto = value; }
        }
        public string CCentroCosto
        {
            get { return _CCentroCosto; }
            set { _CCentroCosto = value; }
        }

        public string NCentroCosto
        {
            get { return _NCentroCosto; }
            set { _NCentroCosto = value; }
        }

        public decimal ImportePresupuesto
        {
            get { return _ImportePresupuesto; }
            set { _ImportePresupuesto = value; }
        }

        public decimal ImporteAdicionalPresupuesto
        {
            get { return _ImporteAdicionalPresupuesto; }
            set { _ImporteAdicionalPresupuesto = value; }
        }

        public decimal SaldoPresupuesto
        {
            get { return _SaldoPresupuesto; }
            set { _SaldoPresupuesto = value; }
        }

        public decimal SaldoPresupuestoTemporal
        {
            get { return _SaldoPresupuestoTemporal; }
            set { _SaldoPresupuestoTemporal = value; }
        }

        public decimal NuevoSaldoPresupuesto
        {
            get { return _NuevoSaldoPresupuesto; }
            set { _NuevoSaldoPresupuesto = value; }
        }

        public string CEstadoPresupuesto
        {
            get { return _CEstadoPresupuesto; }
            set { _CEstadoPresupuesto = value; }
        }

        public string NEstadoPresupuesto
        {
            get { return _NEstadoPresupuesto; }
            set { _NEstadoPresupuesto = value; }
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
