using Entidades.Adicionales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Contabilidad
{
    public class RegContabDeta_Cont_EN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaRegConCab = "ClaveRegContabCabe";
        public const string CodEmp = "CodigoEmpresa";
        public const string RazSocEmp = "RazonSocialEmpresa";
        public const string PerRegConCab = "PeriodoRegContabCabe";
        public const string CodOri = "CodigoOrigen";
        public const string NomOri = "NombreOrigen";
        public const string CodFil = "CodigoFile";
        public const string NomFil = "NombreFile";
        public const string FecVouRegConCab = "FechaVoucherRegContabCabe";
        public const string CodAux = "CodigoAuxiliar";
        public const string DesAux = "DescripcionAuxiliar";
        public const string TipDoc = "TipoDocumento";
        public const string NomDoc = "NombreDocumento";
        public const string SerDoc = "SerieDocumento";
        public const string NumDoc = "NumeroDocumento";
        public const string FecDoc = "FechaDocumento";
        public const string DebHabRegConDet = "DebeHaberRegContabDeta";
        public const string ImpSRegConDet = "ImporteSRegContabDeta";
        public const string Alm = "Almacen";
        public const string CodGasRep = "CodigoGastoReparable";
        public const string NomGasRep = "NombreGastoReparable";
        public const string Uni = "Unidad";
        public const string Can = "Cantidad";
        public const string PreUni = "PrecioUnitario";
        public const string GloRegConDet = "GlosaRegContabDeta";
        public const string DesRegConCab = "DescripcionRegContabCabe";
        public const string CodCenCos = "CodigoCentroCosto";
        public const string NomCenCos = "NombreCentroCosto";

        //Atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveRegContabCabe = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _RazonSocialEmpresa = string.Empty;
        private string _PeriodoRegContabCabe = string.Empty;
        private string _CodigoOrigen = string.Empty;
        private string _NombreOrigen = string.Empty;
        private string _CodigoFile = string.Empty;
        private string _NombreFile = string.Empty;
        private string _FechaVoucherRegContabCabe = string.Empty;
        private string _CodigoAuxiliar = string.Empty;
        private string _DescripcionAuxiliar = string.Empty;
        private string _TipoDocumento = string.Empty;
        private string _NombreDocumento = string.Empty;
        private string _SerieDocumento = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private string _FechaDocumento = string.Empty;
        private string _DebeHaberRegContabDeta = string.Empty;
        private decimal _ImporteSRegContabDeta = 0;
        private string _Almacen = string.Empty;
        private string _CodigoGastoReparable = string.Empty;
        private string _NombreGastoReparable = string.Empty;
        private string _Unidad = string.Empty;
        private decimal _Cantidad = 0;
        private decimal _PrecioUnitario = 0;
        private string _GlosaRegContabDeta = string.Empty;
        private string _DescripcionRegContabCabe = string.Empty;
        private string _CodigoCentroCosto = string.Empty;
        private string _NombreCentroCosto = string.Empty;
        private Adicional _Adicionales = new Adicional();

        //propiedades
        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveRegContabCabe
        {
            get { return this._ClaveRegContabCabe; }
            set { this._ClaveRegContabCabe = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string RazonSocialEmpresa
        {
            get { return this._RazonSocialEmpresa; }
            set { this._RazonSocialEmpresa = value; }
        }

        public string PeriodoRegContabCabe
        {
            get { return this._PeriodoRegContabCabe; }
            set { this._PeriodoRegContabCabe = value; }
        }

        public string CodigoOrigen
        {
            get { return this._CodigoOrigen; }
            set { this._CodigoOrigen = value; }
        }

        public string NombreOrigen
        {
            get { return this._NombreOrigen; }
            set { this._NombreOrigen = value; }
        }

        public string CodigoFile
        {
            get { return this._CodigoFile; }
            set { this._CodigoFile = value; }
        }

        public string NombreFile
        {
            get { return this._NombreFile; }
            set { this._NombreFile = value; }
        }

        public string FechaVoucherRegContabCabe
        {
            get { return this._FechaVoucherRegContabCabe; }
            set { this._FechaVoucherRegContabCabe = value; }
        }

        public string CodigoAuxiliar
        {
            get { return this._CodigoAuxiliar; }
            set { this._CodigoAuxiliar = value; }
        }

        public string DescripcionAuxiliar
        {
            get { return this._DescripcionAuxiliar; }
            set { this._DescripcionAuxiliar = value; }
        }

        public string TipoDocumento
        {
            get { return this._TipoDocumento; }
            set { this._TipoDocumento = value; }
        }

        public string NombreDocumento
        {
            get { return this._NombreDocumento; }
            set { this._NombreDocumento = value; }
        }

        public string SerieDocumento
        {
            get { return this._SerieDocumento; }
            set { this._SerieDocumento = value; }
        }

        public string NumeroDocumento
        {
            get { return this._NumeroDocumento; }
            set { this._NumeroDocumento = value; }
        }

        public string FechaDocumento
        {
            get { return this._FechaDocumento; }
            set { this._FechaDocumento = value; }
        }

        public string DebeHaberRegContabDeta
        {
            get { return this._DebeHaberRegContabDeta; }
            set { this._DebeHaberRegContabDeta = value; }
        }

        public decimal ImporteSRegContabDeta
        {
            get { return this._ImporteSRegContabDeta; }
            set { this._ImporteSRegContabDeta = value; }
        }

        public string Almacen
        {
            get { return this._Almacen; }
            set { this._Almacen = value; }
        }

        public string CodigoGastoReparable
        {
            get { return this._CodigoGastoReparable; }
            set { this._CodigoGastoReparable = value; }
        }

        public string NombreGastoReparable
        {
            get { return this._NombreGastoReparable; }
            set { this._NombreGastoReparable = value; }
        }

        public string Unidad
        {
            get { return this._Unidad; }
            set { this._Unidad = value; }
        }

        public decimal Cantidad
        {
            get { return this._Cantidad; }
            set { this._Cantidad = value; }
        }

        public decimal PrecioUnitario
        {
            get { return this._PrecioUnitario; }
            set { this._PrecioUnitario = value; }
        }

        public string GlosaRegContabDeta
        {
            get { return this._GlosaRegContabDeta; }
            set { this._GlosaRegContabDeta = value; }
        }

        public string DescripcionRegContabCabe
        {
            get { return this._DescripcionRegContabCabe; }
            set { this._DescripcionRegContabCabe = value; }
        }

        public string CodigoCentroCosto
        {
            get { return this._CodigoCentroCosto; }
            set { this._CodigoCentroCosto = value; }
        }

        public string NombreCentroCosto
        {
            get { return this._NombreCentroCosto; }
            set { this._NombreCentroCosto = value; }
        }

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }

    }
}
