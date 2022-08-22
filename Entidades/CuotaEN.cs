using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class CuotaEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaCuo = "ClaveCuota";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodPro = "CodigoProyecto";
        public const string NomPro = "NombreProyecto";
        public const string CodUrbPro = "CodigoUrbanizacionProyecto";
        public const string NomUrbPro = "NombreUrbanizacionProyecto";
        public const string EtaLot = "EtapaLote";
        public const string MzaLot = "ManzanaLote";
        public const string NumLot = "NumeroLote";
        public const string CodCon = "CodigoConcepto";
        public const string DesCon = "DescripcionConcepto";
        public const string CodCli = "CodigoCliente";
        public const string NomCli = "NombreCliente";
        public const string NumDocCli = "NumeroDocumentoCliente";
        public const string TelCli = "TelefonoCliente";
        public const string DirCli = "DireccionCliente";
        public const string NumCon = "NumeroContrato";
        public const string AnoCuo = "AnoCuota";
        public const string CMesCuo = "CMesCuota";
        public const string MonCuo = "MontoCuota";
        public const string MonPenCuo = "MontoPendienteCuota";
        public const string CMonCuo = "CMonedaCuota";
        public const string NMonCuo = "NMonedaCuota";
        public const string AbrMonCuo = "AbreviaturaMonedaCuota";
        public const string FecEmiCuo = "FechaEmisionCuota";
        public const string FecVenCuo = "FechaVencimientoCuota";
        public const string FecPagCuo = "FechaPagoCuota";
        public const string FecCobCuo = "FechaCobranzaCuota";
        public const string CEstCuo = "CEstadoCuota";
        public const string NEstCuo = "NEstadoCuota";
        public const string PerCuo = "PeriodoCuota";
        public const string CEstPen = "CEstadoPenalidad";
        public const string NEstPen = "NEstadoPenalidad";
        public const string ClaLot = "ClaveLote";
        public const string NumRec = "NumeroRecibo";    
        public const string EnvCorRec = "EnvioCorreoRecibo";
        public const string EmaCli = "EmailCliente";
        public const string MonMor = "MontoMora";
        public const string MonMorPen = "MontoMoraPendiente";
        public const string CGenMorFij = "CGeneroMoraFija";
        public const string NGenMorFij = "NGeneroMoraFija";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveCuota = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoProyecto = string.Empty;
        private string _NombreProyecto = string.Empty;
        private string _CodigoUrbanizacionProyecto = string.Empty;
        private string _NombreUrbanizacionProyecto = string.Empty;
        private string _EtapaLote = string.Empty;
        private string _ManzanaLote = string.Empty;
        private string _NumeroLote = string.Empty;
        private string _CodigoConcepto = string.Empty;
        private string _DescripcionConcepto = string.Empty;
        private string _CodigoCliente = string.Empty;
        private string _NombreCliente = string.Empty;
        private string _NumeroDocumentoCliente = string.Empty;
        private string _TelefonoCliente = string.Empty;
        private string _DireccionCliente = string.Empty;
        private string _NumeroContrato = string.Empty;
        private string _AnoCuota = string.Empty;
        private string _CMesCuota = string.Empty;
        private decimal _MontoCuota = 0;
        private decimal _MontoPendienteCuota = 0;
        private string _CMonedaCuota = string.Empty;
        private string _NMonedaCuota = string.Empty;
        private string _AbreviaturaMonedaCuota = string.Empty;
        private string _FechaEmisionCuota = string.Empty;
        private string _FechaVencimientoCuota = string.Empty;
        private string _FechaPagoCuota = string.Empty;
        private string _FechaCobranzaCuota = string.Empty;
        private string _CEstadoCuota = "1";
        private string _NEstadoCuota = "Pendiente";
        private string _CEstadoPenalidad = "1";
        private string _NEstadoPenalidad = "Si";
        private string _PeriodoCuota = string.Empty;
        private string _ClaveLote = string.Empty;
        private string _NumeroRecibo = string.Empty;
        private string _EnvioCorreoRecibo = "0";//no
        private string _EmailCliente = string.Empty;
        private decimal _MontoCobradoCuota = 0;
        private decimal _MontoMora = 0;
        private decimal _MontoMoraPendiente = 0;
        private string _CGeneroMoraFija = "0";
        private string _NGeneroMoraFija = "No";
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
        
        public string ClaveCuota
        {
            get { return this._ClaveCuota; }
            set { this._ClaveCuota = value; }
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

        public string EtapaLote
        {
            get { return this._EtapaLote; }
            set { this._EtapaLote = value; }
        }

        public string ManzanaLote
        {
            get { return this._ManzanaLote; }
            set { this._ManzanaLote = value; }
        }

        public string NumeroLote
        {
            get { return this._NumeroLote; }
            set { this._NumeroLote = value; }
        }

        public string CodigoConcepto
        {
            get { return this._CodigoConcepto; }
            set { this._CodigoConcepto = value; }
        }

        public string DescripcionConcepto
        {
            get { return this._DescripcionConcepto; }
            set { this._DescripcionConcepto = value; }
        }

        public string CodigoCliente
        {
            get { return this._CodigoCliente; }
            set { this._CodigoCliente = value; }
        }

        public string NombreCliente
        {
            get { return this._NombreCliente; }
            set { this._NombreCliente = value; }
        }

        public string NumeroDocumentoCliente
        {
            get { return this._NumeroDocumentoCliente; }
            set { this._NumeroDocumentoCliente = value; }
        }

        public string TelefonoCliente
        {
            get { return this._TelefonoCliente; }
            set { this._TelefonoCliente = value; }
        }       

        public string DireccionCliente
        {
            get { return this._DireccionCliente; }
            set { this._DireccionCliente = value; }
        }

        public string NumeroContrato
        {
            get { return this._NumeroContrato; }
            set { this._NumeroContrato = value; }
        }

        public string AnoCuota
        {
            get { return this._AnoCuota; }
            set { this._AnoCuota = value; }
        }

        public string CMesCuota
        {
            get { return this._CMesCuota; }
            set { this._CMesCuota = value; }
        }   

        public decimal MontoCuota
        {
            get { return this._MontoCuota; }
            set { this._MontoCuota = value; }
        }

        public decimal MontoPendienteCuota
        {
            get { return this._MontoPendienteCuota; }
            set { this._MontoPendienteCuota = value; }
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

        public string AbreviaturaMonedaCuota
        {
            get { return this._AbreviaturaMonedaCuota; }
            set { this._AbreviaturaMonedaCuota = value; }
        }

        public string FechaEmisionCuota
        {
            get { return this._FechaEmisionCuota; }
            set { this._FechaEmisionCuota = value; }
        }
        
        public string FechaVencimientoCuota
        {
            get { return this._FechaVencimientoCuota; }
            set { this._FechaVencimientoCuota = value; }
        }

        public string FechaPagoCuota
        {
            get { return this._FechaPagoCuota; }
            set { this._FechaPagoCuota = value; }
        }

        public string FechaCobranzaCuota
        {
            get { return this._FechaCobranzaCuota; }
            set { this._FechaCobranzaCuota = value; }
        }

        public string CEstadoCuota
        {
            get { return this._CEstadoCuota; }
            set { this._CEstadoCuota = value; }
        }
        
        public string NEstadoCuota
        {
            get { return this._NEstadoCuota; }
            set { this._NEstadoCuota = value; }
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

        public string PeriodoCuota
        {
            get { return this._PeriodoCuota; }
            set { this._PeriodoCuota = value; }
        }

        public string ClaveLote
        {
            get { return this._ClaveLote; }
            set { this._ClaveLote = value; }
        }

        public string NumeroRecibo
        {
            get { return this._NumeroRecibo; }
            set { this._NumeroRecibo = value; }
        }

        public string EnvioCorreoRecibo
        {
            get { return this._EnvioCorreoRecibo; }
            set { this._EnvioCorreoRecibo = value; }
        }

        public string EmailCliente
        {
            get { return this._EmailCliente; }
            set { this._EmailCliente = value; }
        }

        public decimal MontoCobradoCuota
        {
            get { return this._MontoCobradoCuota; }
            set { this._MontoCobradoCuota = value; }
        }

        public decimal MontoMora
        {
            get { return this._MontoMora; }
            set { this._MontoMora = value; }
        }

        public decimal MontoMoraPendiente
        {
            get { return this._MontoMoraPendiente; }
            set { this._MontoMoraPendiente = value; }
        }

        public string CGeneroMoraFija
        {
            get { return this._CGeneroMoraFija; }
            set { this._CGeneroMoraFija = value; }
        }

        public string NGeneroMoraFija
        {
            get { return this._NGeneroMoraFija; }
            set { this._NGeneroMoraFija = value; }
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
