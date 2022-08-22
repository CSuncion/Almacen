using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class FactorCIFEN
    {

        //campos nombres   
        public const string ClaObj = "ClaveObjeto";
        public const string ClaFacCif = "ClaveFactorCif";
        public const string CodFacCif = "CodigoFactorCif";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string AnoFacCif = "AnoFactorCif";
        public const string CMesFacCif = "CMesFactorCif";
        public const string NMesFacCif = "NMesFactorCif";
        public const string GasFacCif = "GasFactorCif";
        public const string EleFacCif = "ElectricidadFactorCif";
        public const string AguFacCif = "AguaFactorCif";
        public const string AlqFacCif = "AlquilerFactorCif";
        public const string DepFacCif = "DepreciacionFactorCif";
        public const string RemMoiFacCif = "RemuneracionMOIFactorCif";
        public const string SumPlaFacCif = "SuministrosPlantaFactorCif";
        public const string ManMaqFacCif = "MantenimientoMaquinariaFactorCif";
        public const string CalFacCif = "CalidadFactorCif";
        public const string EquiProPerFacCif = "EquipoProteccionPersonalFactorCif";
        public const string CanKilFacCif = "CantidadKilosFactorCif";
        public const string FacCif = "FactorCif";
        public const string CEstFacCif = "CEstadoFactorCif";
        public const string NEstFacCif = "NEstadoFactorCif";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveFactorCif = string.Empty;
        private string _CodigoFactorCif = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _AnoFactorCif = string.Empty;
        private string _CMesFactorCif = "01";
        private string _NMesFactorCif = string.Empty;
        private decimal _GasFactorCif = 0;
        private decimal _ElectricidadFactorCif = 0;
        private decimal _AguaFactorCif = 0;
        private decimal _AlquilerFactorCif = 0;
        private decimal _DepreciacionFactorCif = 0;
        private decimal _RemuneracionMOIFactorCif = 0;
        private decimal _SuministrosPlantaFactorCif = 0;
        private decimal _MantenimientoMaquinariaFactorCif = 0;
        private decimal _CalidadFactorCif = 0;
        private decimal _EquipoProteccionPersonalFactorCif = 0;
        private decimal _CantidadKilosFactorCif = 0;
        private decimal _FactorCif = 0;
        private string _CEstadoFactorCif = "1";
        private string _NEstadoFactorCif = "Activado";
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

        public string ClaveFactorCif
        {
            get { return _ClaveFactorCif; }
            set { _ClaveFactorCif = value; }
        }

        public string CodigoFactorCif
        {
            get { return _CodigoFactorCif; }
            set { _CodigoFactorCif = value; }
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

        public string AnoFactorCif
        {
            get { return _AnoFactorCif; }
            set { _AnoFactorCif = value; }
        }

        public string CMesFactorCif
        {
            get { return _CMesFactorCif; }
            set { _CMesFactorCif = value; }
        }

        public string NMesFactorCif
        {
            get { return _NMesFactorCif; }
            set { _NMesFactorCif = value; }
        }

        public decimal GasFactorCif
        {
            get { return _GasFactorCif; }
            set { _GasFactorCif = value; }
        }

        public decimal ElectricidadFactorCif
        {
            get { return _ElectricidadFactorCif; }
            set { _ElectricidadFactorCif = value; }
        }

        public decimal AguaFactorCif
        {
            get { return _AguaFactorCif; }
            set { _AguaFactorCif = value; }
        }

        public decimal AlquilerFactorCif
        {
            get { return _AlquilerFactorCif; }
            set { _AlquilerFactorCif = value; }
        }

        public decimal DepreciacionFactorCif
        {
            get { return _DepreciacionFactorCif; }
            set { _DepreciacionFactorCif = value; }
        }

        public decimal RemuneracionMOIFactorCif
        {
            get { return _RemuneracionMOIFactorCif; }
            set { _RemuneracionMOIFactorCif = value; }
        }

        public decimal SuministrosPlantaFactorCif
        {
            get { return _SuministrosPlantaFactorCif; }
            set { _SuministrosPlantaFactorCif = value; }
        }

        public decimal MantenimientoMaquinariaFactorCif
        {
            get { return _MantenimientoMaquinariaFactorCif; }
            set { _MantenimientoMaquinariaFactorCif = value; }
        }

        public decimal CalidadFactorCif
        {
            get { return _CalidadFactorCif; }
            set { _CalidadFactorCif = value; }
        }

        public decimal EquipoProteccionpersonalFactorCif
        {
            get { return _EquipoProteccionPersonalFactorCif; }
            set { _EquipoProteccionPersonalFactorCif = value; }
        }

        public decimal CantidadKilosFactorCif
        {
            get { return _CantidadKilosFactorCif; }
            set { _CantidadKilosFactorCif = value; }
        }

        public decimal FactorCif
        {
            get { return _FactorCif; }
            set { _FactorCif = value; }
        }

        public string CEstadoFactorCif
        {
            get { return _CEstadoFactorCif; }
            set { _CEstadoFactorCif = value; }
        }

        public string NEstadoFactorCif
        {
            get { return _NEstadoFactorCif; }
            set { _NEstadoFactorCif = value; }
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
