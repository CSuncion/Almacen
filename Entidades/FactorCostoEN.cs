using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class FactorCostoEN
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaFacCos = "ClaveFactorCosto";
        public const string CodFacCos = "CodigoFactorCosto";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string AnoFacCos = "AnoFactorCosto";
        public const string CMesFacCos = "CMesFactorCosto";
        public const string NMesFacCos = "NMesFactorCosto";
        public const string HosLab = "HorasLaboradas";
        public const string NumDia = "NumeroDias";
        public const string CosLab = "CostoLaboral";
        public const string Fac = "Factor";
        public const string CEstFacCos = "CEstadoFactorCosto";
        public const string NEstFacCos = "NEstadoFactorCosto";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveFactorCosto = string.Empty;
        private string _CodigoFactorCosto = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _AnoFactorCosto = string.Empty;
        private string _CMesFactorCosto = "01";
        private string _NMesFactorCosto = string.Empty;
        private decimal _HorasLaboradas = 0;
        private decimal _NumeroDias = 0;
        private decimal _CostoLaboral = 0;
        private decimal _Factor = 0;
        private string _CEstadoFactorCosto = "1";
        private string _NEstadoFactorCosto = "Activado";
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

        public string ClaveFactorCosto
        {
            get { return _ClaveFactorCosto; }
            set { _ClaveFactorCosto = value; }
        }

        public string CodigoFactorCosto
        {
            get { return _CodigoFactorCosto; }
            set { _CodigoFactorCosto = value; }
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

        public string AnoFactorCosto
        {
            get { return _AnoFactorCosto; }
            set { _AnoFactorCosto = value; }
        }

        public string CMesFactorCosto
        {
            get { return _CMesFactorCosto; }
            set { _CMesFactorCosto = value; }
        }

        public string NMesFactorCosto
        {
            get { return _NMesFactorCosto; }
            set { _NMesFactorCosto = value; }
        }

        public decimal HorasLaboradas
        {
            get { return _HorasLaboradas; }
            set { _HorasLaboradas = value; }
        }

        public decimal NumeroDias
        {
            get { return _NumeroDias; }
            set { _NumeroDias = value; }
        }

        public decimal CostoLaboral
        {
            get { return _CostoLaboral; }
            set { _CostoLaboral = value; }
        }

        public decimal Factor
        {
            get { return _Factor; }
            set { _Factor = value; }
        }

        public string CEstadoFactorCosto
        {
            get { return _CEstadoFactorCosto; }
            set { _CEstadoFactorCosto = value; }
        }

        public string NEstadoFactorCosto
        {
            get { return _NEstadoFactorCosto; }
            set { _NEstadoFactorCosto = value; }
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
