using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class DetalleEnvioRecEN
    {

        //campos nombres     	        
        public const string ClaObj = "ClaveObjeto";
        public const string ClaDetEnvRec = "ClaveDetalleEnvioRec";
        public const string ClaEnvRec = "ClaveEnvioRec";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodPro = "CodigoProyecto";
        public const string NomPro = "NombreProyecto";
        public const string CodUrbPro = "CodigoUrbanizacionProyecto";
        public const string NomUrbPro = "NombreUrbanizacionProyecto";
        public const string CMonCuo = "CMonedaCuota";
        public const string NMonCuo = "NMonedaCuota";
        public const string ClaCuo = "ClaveCuota";        
        public const string NumCon = "NumeroContrato";
        public const string CodCli = "CodigoCliente";
        public const string ApePatCli = "ApellidoPaternoCliente";
        public const string ApeMatCli = "ApellidoMaternoCliente";
        public const string PriNomCli = "PrimerNombreCliente";
        public const string SegNomCli = "SegundoNombreCliente";
        public const string NomCli = "NombreCliente";
        public const string CTipDocCli = "CTipoDocumentoCliente";
        public const string NumDocCli = "NumeroDocumentoCliente";
        public const string NomParBanCli = "NombreParaBancoCliente";
        public const string MonPenCuo = "MontoPendienteCuota";
        public const string MonMorPen = "MontoMoraPendiente";
        public const string FecVenCuo = "FechaVencimientoCuota";
        public const string CodCon = "CodigoConcepto";
        public const string CEstPen = "CEstadoPenalidad";
        public const string NEstPen = "NEstadoPenalidad";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveDetalleEnvioRec = string.Empty;
        private string _ClaveEnvioRec = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoProyecto = string.Empty;
        private string _NombreProyecto = string.Empty;
        private string _CodigoUrbanizacionProyecto = string.Empty;
        private string _NombreUrbanizacionProyecto = string.Empty;
        private string _CMonedaCuota = string.Empty;
        private string _NMonedaCuota = string.Empty;
        private string _ClaveCuota = string.Empty;
        private string _NumeroContrato = string.Empty;
        private string _CodigoCliente = string.Empty;
        private string _ApellidoPaternoCliente = string.Empty;
        private string _ApellidoMaternoCliente = string.Empty;
        private string _PrimerNombreCliente = string.Empty;
        private string _SegundoNombreCliente = string.Empty;
        private string _NombreCliente = string.Empty;
        private string _CTipoDocumentoCliente = string.Empty;
        private string _NumeroDocumentoCliente = string.Empty;
        private string _NombreParaBancoCliente = string.Empty;
        private Decimal _MontoPendienteCuota = 0;
        private Decimal _MontoMoraPendiente = 0;
        private string _FechaVencimientoCuota = string.Empty;
        private string _CodigoConcepto = string.Empty;
        private string _CEstadoPenalidad = "1";
        private string _NEstadoPenalidad = "Si";
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
        
        public string ClaveDetalleEnvioRec 
        {
            get { return this._ClaveDetalleEnvioRec; }
            set { this._ClaveDetalleEnvioRec = value; }
        }

        public string ClaveEnvioRec
        {
            get { return this._ClaveEnvioRec; }
            set { this._ClaveEnvioRec = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }
        
        public string NombreEmpresa
        {
            get { return this._NombreEmpresa; }
            set { this._NombreEmpresa = value; }
        }
        
        public string CodigoProyecto
        {
            get { return this._CodigoProyecto; }
            set { this._CodigoProyecto = value; }
        }

        public string NombreProyecto
        {
            get { return this._NombreProyecto; }
            set { this._NombreProyecto = value; }
        }
        
        public string CodigoUrbanizacionProyecto
        {
            get { return this._CodigoUrbanizacionProyecto; }
            set { this._CodigoUrbanizacionProyecto = value; }
        }

        public string NombreUrbanizacionProyecto
        {
            get { return this._NombreUrbanizacionProyecto; }
            set { this._NombreUrbanizacionProyecto = value; }
        }

        public string CMonedaCuota
        {
            get { return this._CMonedaCuota; }
            set { this._CMonedaCuota = value; }
        }

        public string NMonedaCuota
        {
            get { return this._NMonedaCuota; }
            set { this._NMonedaCuota = value; }
        }

        public string ClaveCuota
        {
            get { return this._ClaveCuota; }
            set { this._ClaveCuota = value; }
        }
           
        public string NumeroContrato 
        {
            get { return this._NumeroContrato; }
            set { this._NumeroContrato = value; }
        }

        public string CodigoCliente 
        {
            get { return this._CodigoCliente; }
            set { this._CodigoCliente = value; }
        }

        public string ApellidoPaternoCliente
        {
            get { return this._ApellidoPaternoCliente; }
            set { this._ApellidoPaternoCliente = value; }
        }

        public string ApellidoMaternoCliente
        {
            get { return this._ApellidoMaternoCliente; }
            set { this._ApellidoMaternoCliente = value; }
        }

        public string PrimerNombreCliente
        {
            get { return this._PrimerNombreCliente; }
            set { this._PrimerNombreCliente = value; }
        }

        public string SegundoNombreCliente
        {
            get { return this._SegundoNombreCliente; }
            set { this._SegundoNombreCliente = value; }
        }

        public string NombreCliente 
        {
            get { return this._NombreCliente; }
            set { this._NombreCliente = value; }
        }

        public string CTipoDocumentoCliente
        {
            get { return this._CTipoDocumentoCliente; }
            set { this._CTipoDocumentoCliente = value; }
        }

        public string NumeroDocumentoCliente
        {
            get { return this._NumeroDocumentoCliente; }
            set { this._NumeroDocumentoCliente = value; }
        }

        public string NombreParaBancoCliente
        {
            get { return this._NombreParaBancoCliente; }
            set { this._NombreParaBancoCliente = value; }
        }
               
        public decimal  MontoPendienteCuota
        {
            get { return this._MontoPendienteCuota; }
            set { this._MontoPendienteCuota = value; }
        }

        public decimal MontoMoraPendiente
        {
            get { return this._MontoMoraPendiente; }
            set { this._MontoMoraPendiente = value; }
        }
      
        public string  FechaVencimientoCuota
        {
            get { return this._FechaVencimientoCuota; }
            set { this._FechaVencimientoCuota = value; }
        }

        public string CodigoConcepto
        {
            get { return this._CodigoConcepto; }
            set { this._CodigoConcepto = value; }
        }

        public string CEstadoPenalidad
        {
            get { return this._CEstadoPenalidad; }
            set { this._CEstadoPenalidad = value; }
        }

        public string NEstadoPenalidad
        {
            get { return this._NEstadoPenalidad; }
            set { this._NEstadoPenalidad = value; }
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
