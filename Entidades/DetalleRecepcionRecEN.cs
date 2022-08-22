using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class DetalleRecepcionRecEN
    {

        //campos nombres     	        
        public const string ClaObj = "ClaveObjeto";
        public const string ClaDetRecRec = "ClaveDetalleRecepcionRec";
        public const string ClaRecRec = "ClaveRecepcionRec";
        public const string CorDetRecRec = "CorrelativoDetalleRecepcionRec";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodPro = "CodigoProyecto";
        public const string NumCon = "NumeroContrato";
        public const string ClaLot = "ClaveLote";     
        public const string MonPag = "MonedaPago";
        public const string CodCli = "CodigoCliente";
        public const string NomCli = "NombreCliente";       
        public const string FecCob = "FechaCobranza";
        public const string FecVenCuo = "FechaVencimientoCuota";
        public const string ImpCob = "ImporteCobrado";
        public const string ImpMor = "ImporteMora";
        public const string ImpTot = "ImporteTotal";
        public const string CFlaDetRec = "CFlagDetalleRecepcion";
        public const string NFlaDetRec = "NFlagDetalleRecepcion";
        public const string ClaCom = "ClaveComprobante";
        public const string CTipCom = "CTipoComprobante";        
        public const string SerComCab = "SerieComprobanteCabe";
        public const string NumComCab = "NumeroComprobanteCabe";
        public const string MotDetRec = "MotivoDetalleRecepcionRec";
        public const string CorCob = "CorrelativoCobranza";
        public const string ClaCuo = "ClaveCuota";
        public const string ClaCon = "ClaveContrato";       
        public const string CTipDocRef = "CTipoDocumentoReferencia";
        public const string CodCon = "CodigoConcepto";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveDetalleRecepcionRec = string.Empty;
        private string _ClaveRecepcionRec = string.Empty;
        private string _CorrelativoDetalleRecepcionRec = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoProyecto = string.Empty;
        private string _NumeroContrato = string.Empty;
        private string _ClaveLote = string.Empty;       
        private string _MonedaPago = string.Empty;
        private string _CodigoCliente = string.Empty;
        private string _NombreCliente = string.Empty;
        private string _FechaCobranza = string.Empty;
        private string _FechaVencimientoCuota = string.Empty;      
        private Decimal _ImporteCobrado = 0;
        private Decimal _ImporteMora = 0;
        private Decimal _ImporteTotal = 0;
        private string _CFlagDetalleRecepcion = string.Empty;
        private string _NFlagDetalleRecepcion = string.Empty;
        private string _ClaveComprobante = string.Empty;
        private string _CTipoComprobante = string.Empty;       
        private string _SerieComprobanteCabe = string.Empty;
        private string _NumeroComprobanteCabe = string.Empty;
        private string _MotivoDetalleRecepcionRec = string.Empty;
        private string _CorrelativoCobranza = string.Empty;
        private string _ClaveCuota = string.Empty;
        private string _ClaveContrato = string.Empty;      
        private string _CTipoDocumentoReferencia = string.Empty;
        private string _CodigoConcepto = string.Empty;
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();
        private CuotaEN _Cuota = new CuotaEN();

        //propiedades


        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }
        
        public string ClaveDetalleRecepcionRec 
        {
            get { return this._ClaveDetalleRecepcionRec; }
            set { this._ClaveDetalleRecepcionRec = value; }
        }

        public string ClaveRecepcionRec
        {
            get { return this._ClaveRecepcionRec; }
            set { this._ClaveRecepcionRec = value; }
        }

        public string CorrelativoDetalleRecepcionRec
        {
            get { return this._CorrelativoDetalleRecepcionRec; }
            set { this._CorrelativoDetalleRecepcionRec = value; }
        }
        
        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }
        
        public string CodigoProyecto
        {
            get { return this._CodigoProyecto; }
            set { this._CodigoProyecto = value; }
        }

        public string NumeroContrato 
        {
            get { return this._NumeroContrato; }
            set { this._NumeroContrato = value; }
        }

        public string ClaveLote
        {
            get { return this._ClaveLote; }
            set { this._ClaveLote = value; }
        }
             
        public string MonedaPago 
        {
            get { return this._MonedaPago; }
            set { this._MonedaPago = value; }
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

        public string FechaCobranza
        {
            get { return this._FechaCobranza; }
            set { this._FechaCobranza = value; }
        }

        public string FechaVencimientoCuota
        {
            get { return this._FechaVencimientoCuota; }
            set { this._FechaVencimientoCuota = value; }
        }
                       
        public decimal  ImporteCobrado 
        {
            get { return this._ImporteCobrado; }
            set { this._ImporteCobrado = value; }
        }

        public decimal ImporteMora
        {
            get { return this._ImporteMora; }
            set { this._ImporteMora = value; }
        }

        public decimal ImporteTotal
        {
            get { return this._ImporteTotal; }
            set { this._ImporteTotal = value; }
        }

        public string CFlagDetalleRecepcion
        {
            get { return this._CFlagDetalleRecepcion; }
            set { this._CFlagDetalleRecepcion = value; }
        }

        public string NFlagDetalleRecepcion
        {
            get { return this._NFlagDetalleRecepcion; }
            set { this._NFlagDetalleRecepcion = value; }
        }

        public string ClaveComprobante
        {
            get { return this._ClaveComprobante; }
            set { this._ClaveComprobante = value; }
        }

        public string CTipoComprobante
        {
            get { return this._CTipoComprobante; }
            set { this._CTipoComprobante = value; }
        }

        public string SerieComprobanteCabe
        {
            get { return this._SerieComprobanteCabe; }
            set { this._SerieComprobanteCabe = value; }
        }
        
        public string NumeroComprobanteCabe
        {
            get { return this._NumeroComprobanteCabe; }
            set { this._NumeroComprobanteCabe = value; }
        }

        public string MotivoDetalleRecepcionRec
        {
            get { return this._MotivoDetalleRecepcionRec; }
            set { this._MotivoDetalleRecepcionRec = value; }
        }

        public string CorrelativoCobranza
        {
            get { return this._CorrelativoCobranza; }
            set { this._CorrelativoCobranza = value; }
        }

        public string ClaveCuota
        {
            get { return this._ClaveCuota; }
            set { this._ClaveCuota = value; }
        }

        public string ClaveContrato
        {
            get { return this._ClaveContrato; }
            set { this._ClaveContrato = value; }
        }

        public string CTipoDocumentoReferencia
        {
            get { return this._CTipoDocumentoReferencia; }
            set { this._CTipoDocumentoReferencia = value; }
        }

        public string CodigoConcepto
        {
            get { return this._CodigoConcepto; }
            set { this._CodigoConcepto = value; }
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

        public CuotaEN Cuota
        {
            get { return this._Cuota; }
            set { this._Cuota = value; }
        }

    }
}
