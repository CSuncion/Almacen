using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;


namespace Entidades
{
    public class SaldoEN
    {

        //campos nombres     	        
        public const string ClaObj = "ClaveObjeto";
        public const string ClaSal = "ClaveSaldo";
        public const string CodEmp = "CodigoEmpresa";
        public const string NomEmp = "NombreEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string CodTip = "CodigoTipo";
        public const string NomTip = "NombreTipo";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string AñoSal = "AñoSaldo";
        public const string StkIni = "StockInicio";
        public const string ProIni = "PromedioInicio";
        public const string IngIni = "IngresosInicio";
        public const string SalIni = "SalidasInicio";
        public const string StkEne = "StockEnero";
        public const string ProEne = "PromedioEnero";
        public const string IngEne = "IngresosEnero";
        public const string SalEne = "SalidasEnero";
        public const string StkFeb = "StockFebrero";
        public const string ProFeb = "PromedioFebrero";
        public const string IngFeb = "IngresosFebrero";
        public const string SalFeb = "SalidasFebrero";
        public const string StkMar = "StockMarzo";
        public const string ProMar = "PromedioMarzo";
        public const string IngMar = "IngresosMarzo";
        public const string SalMar = "SalidasMarzo";
        public const string StkAbr = "StockAbril";
        public const string ProAbr = "PromedioAbril";
        public const string IngAbr = "IngresosAbril";
        public const string SalAbr = "SalidasAbril";
        public const string StkMay = "StockMayo";
        public const string ProMay = "PromedioMayo";
        public const string IngMay = "IngresosMayo";
        public const string SalMay = "SalidasMayo";
        public const string StkJun = "StockJunio";
        public const string ProJun = "PromedioJunio";
        public const string IngJun = "IngresosJunio";
        public const string SalJun = "SalidasJunio";
        public const string StkJul = "StockJulio";
        public const string ProJul = "PromedioJulio";
        public const string IngJul = "IngresosJulio";
        public const string SalJul = "SalidasJulio";
        public const string StkAgo = "StockAgosto";
        public const string ProAgo = "PromedioAgosto";
        public const string IngAgo = "IngresosAgosto";
        public const string SalAgo = "SalidasAgosto";
        public const string StkSet = "StockSetiembre";
        public const string ProSet = "PromedioSetiembre";
        public const string IngSet = "IngresosSetiembre";
        public const string SalSet = "SalidasSetiembre";
        public const string StkOct = "StockOctubre";
        public const string ProOct = "PromedioOctubre";
        public const string IngOct = "IngresosOctubre";
        public const string SalOct = "SalidasOctubre";
        public const string StkNov = "StockNoviembre";
        public const string ProNov = "PromedioNoviembre";
        public const string IngNov = "IngresosNoviembre";
        public const string SalNov = "SalidasNoviembre";
        public const string StkDic = "StockDiciembre";
        public const string ProDic = "PromedioDiciembre";
        public const string IngDic = "IngresosDiciembre";
        public const string SalDic = "SalidasDiciembre";
        public const string CEstSal = "CEstadoSaldo";
        public const string NEstSal = "NEstadosaldo";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";

        //atributos

        private string _ClaveObjeto = string.Empty;
        private string _ClaveSaldo = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _NombreEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _CodigoTipo = string.Empty;
        private string _NombreTipo = string.Empty;
        private string _CodigoUnidadMedida = string.Empty;
        private string _NombreUnidadMedida = string.Empty;
        private string _AñoSaldo = string.Empty;
        private decimal _StockInicio = 0;
        private decimal _PromedioInicio = 0;
        private decimal _IngresosInicio = 0;
        private decimal _SalidasInicio = 0;
        private decimal _StockEnero = 0;
        private decimal _PromedioEnero = 0;
        private decimal _IngresosEnero = 0;
        private decimal _SalidasEnero = 0;
        private decimal _StockFebrero = 0;
        private decimal _PromedioFebrero = 0;
        private decimal _IngresosFebrero = 0;
        private decimal _SalidasFebrero = 0;
        private decimal _StockMarzo = 0;
        private decimal _PromedioMarzo = 0;
        private decimal _IngresosMarzo = 0;
        private decimal _SalidasMarzo = 0;
        private decimal _StockAbril = 0;
        private decimal _PromedioAbril = 0;
        private decimal _IngresosAbril = 0;
        private decimal _SalidasAbril = 0;
        private decimal _StockMayo = 0;
        private decimal _PromedioMayo = 0;
        private decimal _IngresosMayo = 0;
        private decimal _SalidasMayo = 0;
        private decimal _StockJunio = 0;
        private decimal _PromedioJunio = 0;
        private decimal _IngresosJunio = 0;
        private decimal _SalidasJunio = 0;
        private decimal _StockJulio = 0;
        private decimal _PromedioJulio = 0;
        private decimal _IngresosJulio = 0;
        private decimal _SalidasJulio = 0;
        private decimal _StockAgosto = 0;
        private decimal _PromedioAgosto = 0;
        private decimal _IngresosAgosto = 0;
        private decimal _SalidasAgosto = 0;
        private decimal _StockSetiembre = 0;
        private decimal _PromedioSetiembre = 0;
        private decimal _IngresosSetiembre = 0;
        private decimal _SalidasSetiembre = 0;
        private decimal _StockOctubre = 0;
        private decimal _PromedioOctubre = 0;
        private decimal _IngresosOctubre = 0;
        private decimal _SalidasOctubre = 0;
        private decimal _StockNoviembre = 0;
        private decimal _PromedioNoviembre = 0;
        private decimal _IngresosNoviembre = 0;
        private decimal _SalidasNoviembre = 0;
        private decimal _StockDiciembre = 0;
        private decimal _PromedioDiciembre = 0;
        private decimal _IngresosDiciembre = 0;
        private decimal _SalidasDiciembre = 0;
        private string _CEstadoSaldo = "1";
        private string _NEstadoSaldo = "";
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

        public string ClaveSaldo 
        {
            get { return this._ClaveSaldo; }
            set { this._ClaveSaldo = value; }
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

        public string CodigoExistencia 
        {
            get { return this._CodigoExistencia; }
            set { this._CodigoExistencia = value; }
        }

        public string DescripcionExistencia
        {
            get { return this._DescripcionExistencia; }
            set { this._DescripcionExistencia = value; }
        }

        public string CodigoTipo
        {
            get { return this._CodigoTipo; }
            set { this._CodigoTipo = value; }
        }

        public string NombreTipo
        {
            get { return this._NombreTipo; }
            set { this._NombreTipo = value; }
        }

        public string CodigoUnidadMedida
        {
            get { return this._CodigoUnidadMedida; }
            set { this._CodigoUnidadMedida = value; }
        }

        public string NombreUnidadMedida
        {
            get { return this._NombreUnidadMedida; }
            set { this._NombreUnidadMedida = value; }
        }

        public string AñoSaldo
        {
            get { return this._AñoSaldo; }
            set { this._AñoSaldo = value; }
        }

        public decimal StockInicio
        {
            get { return this._StockInicio; }
            set { this._StockInicio = value; }
        }

        public decimal PromedioInicio
        {
            get { return this._PromedioInicio; }
            set { this._PromedioInicio = value; }
        }

        public decimal IngresosInicio
        {
            get { return this._IngresosInicio; }
            set { this._IngresosInicio = value; }
        }

        public decimal SalidasInicio
        {
            get { return this._SalidasInicio; }
            set { this._SalidasInicio = value; }
        }

        public decimal StockEnero
        {
            get { return this._StockEnero; }
            set { this._StockEnero = value; }
        }

        public decimal PromedioEnero
        {
            get { return this._PromedioEnero; }
            set { this._PromedioEnero = value; }
        }

        public decimal IngresosEnero
        {
            get { return this._IngresosEnero; }
            set { this._IngresosEnero = value; }
        }

        public decimal SalidasEnero
        {
            get { return this._SalidasEnero; }
            set { this._SalidasEnero = value; }
        }

        public decimal StockFebrero
        {
            get { return this._StockFebrero; }
            set { this._StockFebrero = value; }
        }

        public decimal PromedioFebrero
        {
            get { return this._PromedioFebrero; }
            set { this._PromedioFebrero = value; }
        }

        public decimal IngresosFebrero
        {
            get { return this._IngresosFebrero; }
            set { this._IngresosFebrero = value; }
        }

        public decimal SalidasFebrero
        {
            get { return this._SalidasFebrero; }
            set { this._SalidasFebrero = value; }
        }

        public decimal StockMarzo
        {
            get { return this._StockMarzo; }
            set { this._StockMarzo = value; }
        }

        public decimal PromedioMarzo
        {
            get { return this._PromedioMarzo; }
            set { this._PromedioMarzo = value; }
        }

        public decimal IngresosMarzo
        {
            get { return this._IngresosMarzo; }
            set { this._IngresosMarzo = value; }
        }

        public decimal SalidasMarzo
        {
            get { return this._SalidasMarzo; }
            set { this._SalidasMarzo = value; }
        }

        public decimal StockAbril
        {
            get { return this._StockAbril; }
            set { this._StockAbril = value; }
        }

        public decimal PromedioAbril
        {
            get { return this._PromedioAbril; }
            set { this._PromedioAbril = value; }
        }

        public decimal IngresosAbril
        {
            get { return this._IngresosAbril; }
            set { this._IngresosAbril = value; }
        }

        public decimal SalidasAbril
        {
            get { return this._SalidasAbril; }
            set { this._SalidasAbril = value; }
        }

        public decimal StockMayo
        {
            get { return this._StockMayo; }
            set { this._StockMayo = value; }
        }

        public decimal PromedioMayo
        {
            get { return this._PromedioMayo; }
            set { this._PromedioMayo = value; }
        }

        public decimal IngresosMayo
        {
            get { return this._IngresosMayo; }
            set { this._IngresosMayo = value; }
        }

        public decimal SalidasMayo
        {
            get { return this._SalidasMayo; }
            set { this._SalidasMayo = value; }
        }

        public decimal StockJunio
        {
            get { return this._StockJunio; }
            set { this._StockJunio = value; }
        }

        public decimal PromedioJunio
        {
            get { return this._PromedioJunio; }
            set { this._PromedioJunio = value; }
        }

        public decimal IngresosJunio
        {
            get { return this._IngresosJunio; }
            set { this._IngresosJunio = value; }
        }

        public decimal SalidasJunio
        {
            get { return this._SalidasJunio; }
            set { this._SalidasJunio = value; }
        }

        public decimal StockJulio
        {
            get { return this._StockJulio; }
            set { this._StockJulio = value; }
        }

        public decimal PromedioJulio
        {
            get { return this._PromedioJulio; }
            set { this._PromedioJulio = value; }
        }

        public decimal IngresosJulio
        {
            get { return this._IngresosJulio; }
            set { this._IngresosJulio = value; }
        }

        public decimal SalidasJulio
        {
            get { return this._SalidasJulio; }
            set { this._SalidasJulio = value; }
        }

        public decimal StockAgosto
        {
            get { return this._StockAgosto; }
            set { this._StockAgosto = value; }
        }

        public decimal PromedioAgosto
        {
            get { return this._PromedioAgosto; }
            set { this._PromedioAgosto = value; }
        }

        public decimal IngresosAgosto
        {
            get { return this._IngresosAgosto; }
            set { this._IngresosAgosto = value; }
        }

        public decimal SalidasAgosto
        {
            get { return this._SalidasAgosto; }
            set { this._SalidasAgosto = value; }
        }

        public decimal StockSetiembre
        {
            get { return this._StockSetiembre; }
            set { this._StockSetiembre = value; }
        }

        public decimal PromedioSetiembre
        {
            get { return this._PromedioSetiembre; }
            set { this._PromedioSetiembre = value; }
        }

        public decimal IngresosSetiembre
        {
            get { return this._IngresosSetiembre; }
            set { this._IngresosSetiembre = value; }
        }

        public decimal SalidasSetiembre
        {
            get { return this._SalidasSetiembre; }
            set { this._SalidasSetiembre = value; }
        }

        public decimal StockOctubre
        {
            get { return this._StockOctubre; }
            set { this._StockOctubre = value; }
        }

        public decimal PromedioOctubre
        {
            get { return this._PromedioOctubre; }
            set { this._PromedioOctubre = value; }
        }

        public decimal IngresosOctubre
        {
            get { return this._IngresosOctubre; }
            set { this._IngresosOctubre = value; }
        }

        public decimal SalidasOctubre
        {
            get { return this._SalidasOctubre; }
            set { this._SalidasOctubre = value; }
        }

        public decimal StockNoviembre
        {
            get { return this._StockNoviembre; }
            set { this._StockNoviembre = value; }
        }

        public decimal PromedioNoviembre
        {
            get { return this._PromedioNoviembre; }
            set { this._PromedioNoviembre = value; }
        }

        public decimal IngresosNoviembre
        {
            get { return this._IngresosNoviembre; }
            set { this._IngresosNoviembre = value; }
        }

        public decimal SalidasNoviembre
        {
            get { return this._SalidasNoviembre; }
            set { this._SalidasNoviembre = value; }
        }

        public decimal StockDiciembre
        {
            get { return this._StockDiciembre; }
            set { this._StockDiciembre = value; }
        }

        public decimal PromedioDiciembre
        {
            get { return this._PromedioDiciembre; }
            set { this._PromedioDiciembre = value; }
        }

        public decimal IngresosDiciembre
        {
            get { return this._IngresosDiciembre; }
            set { this._IngresosDiciembre = value; }
        }

        public decimal SalidasDiciembre
        {
            get { return this._SalidasDiciembre; }
            set { this._SalidasDiciembre = value; }
        }

        public string CEstadoSaldo
        {
            get { return this._CEstadoSaldo; }
            set { this._CEstadoSaldo = value; }
        }

        public string NEstadoSaldo
        {
            get { return this._NEstadoSaldo; }
            set { this._NEstadoSaldo = value; }
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
