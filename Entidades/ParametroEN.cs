using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class ParametroEN
    {
        //campo nombres     
        public const string RutLogEmp = "RutaLogoEmpresa";
        public const string RutImaExi = "RutaImagenExistencia";
        public const string PorIgv = "PorcentajeIgv";       
        public const string NomSol = "NombreSoles";
        public const string NomDol = "NombreDolares";
        public const string TipOpeTraIng = "TipoOperacionTransferenciaIngreso";
        public const string TipOpeTraSal = "TipoOperacionTransferenciaSalida";
        public const string TipOpeProSal = "TipoOperacionProduccionSalida";
        public const string TipOpeProIng = "TipoOperacionProduccionIngreso";
        public const string CenCosPro = "CentroCostoProduccion";
        public const string TipOpeComMig = "TipoOperacionCompraMigracion";
        public const string TipOpeImpMig = "TipoOperacionImportacionMigracion";
        public const string TipOpeIngMig = "TipoOperacionIngresoMigracion";
        public const string TipOpeSalMig = "TipoOperacionSalidaMigracion";
        public const string TipOpeIngAju = "TipoOperacionIngresoAjuste";
        public const string TipOpeSalAju = "TipoOperacionSalidaAjuste";
        public const string TipOpeIngDevPro = "TipoOperacionIngresoDevolucionProduccion";
        public const string TipOpeSalNoPas = "TipoOperacionSalidaNoPasan";
        public const string CorEnv = "CorreoEnvio";
        public const string ClaCorEnv = "ClaveCorreoEnvio";
        public const string HostCorEnv = "HostCorreoEnvio";
        public const string PueCorEnv = "PuertoCorreoEnvio";
        public const string RutCarPla = "RutaCarpetaPlantillas";
        public const string RutPlaRec = "RutaPlantillaRecibo";
        public const string RutPlaEstCue = "RutaPlantillaEstadoCuenta";
        public const string RutRec = "RutaRecibos";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos      
        private string _RutaLogoEmpresa = string.Empty;
        private string _RutaImagenExistencia = string.Empty;
        private decimal _PorcentajeIgv = 0;       
        private string _NombreSoles = string.Empty;
        private string _NombreDolares = string.Empty;
        private string _TipoOperacionTransferenciaIngreso = string.Empty;
        private string _TipoOperacionTransferenciaSalida = string.Empty;
        private string _TipoOperacionProduccionSalida = string.Empty;
        private string _TipoOperacionProduccionIngreso = string.Empty;
        private string _CentroCostoProduccion = string.Empty;
        private string _TipoOperacionCompraMigracion = string.Empty;
        private string _TipoOperacionImportacionMigracion = string.Empty;
        private string _TipoOperacionIngresoMigracion = string.Empty;
        private string _TipoOperacionSalidaMigracion = string.Empty;
        private string _TipoOperacionIngresoAjuste = string.Empty;
        private string _TipoOperacionSalidaAjuste = string.Empty;
        private string _TipoOperacionIngresoDevolucionProduccion = string.Empty;
        private string _TipoOperacionSalidaNoPasan = string.Empty;
        private string _CorreoEnvio = string.Empty;
        private string _ClaveCorreoEnvio = string.Empty;
        private string _HostCorreoEnvio = string.Empty;
        private string _PuertoCorreoEnvio = string.Empty;
        private string _RutaPlantillaRecibo = string.Empty;
        private string _RutaRecibos = string.Empty;
        private string _RutaPlantillaEstadoCuenta = string.Empty;
        private string _RutaCarpetaPlantillas = string.Empty;
        private string _UsuarioAgrega;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        //propiedades
      
        public string RutaLogoEmpresa
        {
            get { return this._RutaLogoEmpresa; }
            set { this._RutaLogoEmpresa = value; }
        }
        public string RutaImagenExistencia
        {
            get { return this._RutaImagenExistencia; }
            set { this._RutaImagenExistencia = value; }
        }

        public decimal PorcentajeIgv
        {
            get { return this._PorcentajeIgv; }
            set { this._PorcentajeIgv = value; }
        }

        public string NombreSoles
        {
            get { return this._NombreSoles; }
            set { this._NombreSoles = value; }
        }

        public string NombreDolares
        {
            get { return this._NombreDolares; }
            set { this._NombreDolares = value; }
        }

        public string TipoOperacionTransferenciaIngreso
        {
            get { return this._TipoOperacionTransferenciaIngreso; }
            set { this._TipoOperacionTransferenciaIngreso = value; }
        }

        public string TipoOperacionTransferenciaSalida
        {
            get { return this._TipoOperacionTransferenciaSalida; }
            set { this._TipoOperacionTransferenciaSalida = value; }
        }

        public string TipoOperacionProduccionSalida
        {
            get { return this._TipoOperacionProduccionSalida; }
            set { this._TipoOperacionProduccionSalida = value; }
        }

        public string TipoOperacionProduccionIngreso
        {
            get { return this._TipoOperacionProduccionIngreso; }
            set { this._TipoOperacionProduccionIngreso = value; }
        }

        public string CentroCostoProduccion
        {
            get { return this._CentroCostoProduccion; }
            set { this._CentroCostoProduccion = value; }
        }

        public string TipoOperacionCompraMigracion
        {
            get { return this._TipoOperacionCompraMigracion; }
            set { this._TipoOperacionCompraMigracion = value; }
        }

        public string TipoOperacionImportacionMigracion
        {
            get { return this._TipoOperacionImportacionMigracion; }
            set { this._TipoOperacionImportacionMigracion = value; }
        }

        public string TipoOperacionIngresoMigracion
        {
            get { return this._TipoOperacionIngresoMigracion; }
            set { this._TipoOperacionIngresoMigracion = value; }
        }

        public string TipoOperacionSalidaMigracion
        {
            get { return this._TipoOperacionSalidaMigracion; }
            set { this._TipoOperacionSalidaMigracion = value; }
        }

        public string TipoOperacionIngresoAjuste
        {
            get { return this._TipoOperacionIngresoAjuste; }
            set { this._TipoOperacionIngresoAjuste = value; }
        }

        public string TipoOperacionSalidaAjuste
        {
            get { return this._TipoOperacionSalidaAjuste; }
            set { this._TipoOperacionSalidaAjuste = value; }
        }

        public string TipoOperacionIngresoDevolucionProduccion
        {
            get { return this._TipoOperacionIngresoDevolucionProduccion; }
            set { this._TipoOperacionIngresoDevolucionProduccion = value; }
        }

        public string TipoOperacionSalidaNoPasan
        {
            get { return this._TipoOperacionSalidaNoPasan; }
            set { this._TipoOperacionSalidaNoPasan = value; }
        }

        public string CorreoEnvio
        {
            get { return this._CorreoEnvio; }
            set { this._CorreoEnvio = value; }
        }

        public string ClaveCorreoEnvio
        {
            get { return this._ClaveCorreoEnvio; }
            set { this._ClaveCorreoEnvio = value; }
        }

        public string HostCorreoEnvio
        {
            get { return this._HostCorreoEnvio; }
            set { this._HostCorreoEnvio = value; }
        }

        public string PuertoCorreoEnvio
        {
            get { return this._PuertoCorreoEnvio; }
            set { this._PuertoCorreoEnvio = value; }
        }

        public string RutaPlantillaRecibo
        {
            get { return this._RutaPlantillaRecibo; }
            set { this._RutaPlantillaRecibo = value; }
        }

        public string RutaPlantillaEstadoCuenta
        {
            get { return this._RutaPlantillaEstadoCuenta; }
            set { this._RutaPlantillaEstadoCuenta = value; }
        }

        public string RutaCarpetaPlantillas
        {
            get { return this._RutaCarpetaPlantillas; }
            set { this._RutaCarpetaPlantillas = value; }
        }

        public string RutaRecibos
        {
            get { return this._RutaRecibos; }
            set { this._RutaRecibos = value; }
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
