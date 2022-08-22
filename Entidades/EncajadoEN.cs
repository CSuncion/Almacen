using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class EncajadoEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaEnc = "ClaveEncajado";
        public const string CodEmp = "CodigoEmpresa";        
        public const string CorEnc = "CorrelativoEncajado";        
        public const string FecEnc = "FechaEncajado";
        public const string PerEnc = "PeriodoEncajado";
        public const string DesEnc = "DescripcionEncajado";
        public const string ClaSalFasEmp = "ClaveSalidaFaseEmpaquetado";
        public const string ClaSalUniEmp = "ClaveSalidaUnidadesEmpacar";
        public const string ClaIngProTer = "ClaveIngresoProductoTerminado";
        public const string ClaSalUniEmpObs = "ClaveSalidaUnidadesEmpacarObservados";
        public const string ClaSalUniEmpCua = "ClaveSalidaUnidadesEmpacarCuarentena";
        public const string VerFal = "VerdadFalso";     
        public const string CEstEnc = "CEstadoEncajado";
        public const string NEstEnc = "NEstadoEncajado";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveEncajado = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CorrelativoEncajado = string.Empty;
        private string _FechaEncajado = string.Empty;
        private string _PeriodoEncajado = string.Empty;
        private string _DescripcionEncajado = string.Empty;
        private string _ClaveSalidaFaseEmpaquetado = string.Empty;
        private string _ClaveSalidaUnidadesEmpacar = string.Empty;
        private string _ClaveIngresoProductoTerminado = string.Empty;
        private string _ClaveSalidaUnidadesEmpacarObservados = string.Empty;
        private string _ClaveSalidaUnidadesEmpacarCuarentena = string.Empty;
        private bool _VerdadFalso = false;        
        private string _CEstadoEncajado = "0";
        private string _NEstadoEncajado = "Pendiente";
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private Adicional _Adicionales = new Adicional();

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }
        
        public string ClaveEncajado
        {
            get { return this._ClaveEncajado; }
            set { this._ClaveEncajado = value; }
        }
        
        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
        }

        public string CorrelativoEncajado
        {
            get { return this._CorrelativoEncajado; }
            set { this._CorrelativoEncajado = value; }
        }
        
        public string FechaEncajado
        {
            get { return this._FechaEncajado; }
            set { this._FechaEncajado = value; }
        }

        public string PeriodoEncajado
        {
            get { return this._PeriodoEncajado; }
            set { this._PeriodoEncajado = value; }
        }

        public string DescripcionEncajado
        {
            get { return _DescripcionEncajado; }
            set { _DescripcionEncajado = value; }
        }

        public string ClaveSalidaFaseEmpaquetado
        {
            get { return _ClaveSalidaFaseEmpaquetado; }
            set { _ClaveSalidaFaseEmpaquetado = value; }
        }

        public string ClaveSalidaUnidadesEmpacar
        {
            get { return _ClaveSalidaUnidadesEmpacar; }
            set { _ClaveSalidaUnidadesEmpacar = value; }
        }

        public string ClaveIngresoProductoTerminado
        {
            get { return _ClaveIngresoProductoTerminado; }
            set { _ClaveIngresoProductoTerminado = value; }
        }

        public string ClaveSalidaUnidadesEmpacarObservados
        {
            get { return _ClaveSalidaUnidadesEmpacarObservados; }
            set { _ClaveSalidaUnidadesEmpacarObservados = value; }
        }

        public string ClaveSalidaUnidadesEmpacarCuarentena
        {
            get { return _ClaveSalidaUnidadesEmpacarCuarentena; }
            set { _ClaveSalidaUnidadesEmpacarCuarentena = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }

        public string CEstadoEncajado
        {
            get { return this._CEstadoEncajado; }
            set { this._CEstadoEncajado = value; }
        }
        
        public string NEstadoEncajado
        {
            get { return this._NEstadoEncajado; }
            set { this._NEstadoEncajado = value; }
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
