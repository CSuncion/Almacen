using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Adicionales;

namespace Entidades
{
    public class ExistenciaEN
    {

        //campos nombres
        public const string ClaObj = "ClaveObjeto";
        public const string ClaExi = "ClaveExistencia";
        public const string CodEmp = "CodigoEmpresa";
        public const string CodAlm = "CodigoAlmacen";
        public const string DesAlm = "DescripcionAlmacen";
        public const string CodExi = "CodigoExistencia";
        public const string DesExi = "DescripcionExistencia";
        public const string DesSecExi = "DescripcionSecundariaExistencia";
        public const string DesGenExi = "DescripcionGeneralExistencia";
        public const string DesCorExi = "DescripcionCortaExistencia";
        public const string CodUniMed = "CodigoUnidadMedida";
        public const string NomUniMed = "NombreUnidadMedida";
        public const string CCodUbi = "CCodigoUbicacion";
        public const string NCodUbi = "NCodigoUbicacion";
        public const string CodTip = "CodigoTipo";
        public const string NomTip = "NombreTipo";
        public const string CodGru = "CodigoGrupo";
        public const string NomGru = "NombreGrupo";
        public const string CClaExi = "CClaseExistencia";
        public const string NClaExi = "NClaseExistencia";
        public const string CSubClaExi = "CSubClaseExistencia";
        public const string NSubClaExi = "NSubClaseExistencia";
        public const string CEsPro = "CEsProduccion";
        public const string NEsPro = "NEsProduccion";
        public const string ConExi = "ContableExistencia";
        public const string CodAre = "CodigoArea";
        public const string NomAre = "NombreArea";
        public const string CCenCto = "CCentroCosto";
        public const string NCenCto = "NCentroCosto";
        public const string AmbExi = "AmbienteExistencia";
        public const string CodMar = "CodigoMarca";
        public const string NomMar = "NombreMarca";
        public const string ModExi = "ModeloExistencia";
        public const string SerExi = "SerieExistencia";
        public const string MedExi = "MedidasExistencia";
        public const string CodCol = "CodigoColor";
        public const string NomCol = "NombreColor";
        public const string StoMinExi = "StockMinimoExistencia";
        public const string StoAleExi = "StockAlertaExistencia";
        public const string StoTomExi = "StockTomaExistencia";
        public const string StoIniExi = "StockInicialExistencia";
        public const string StoActExi = "StockActualExistencia";
        public const string PreIniExi = "PrecioInicialExistencia";
        public const string PreProExi = "PrecioPromedioExistencia";
        public const string PesExi = "PesoExistencia";
        public const string VerFal = "VerdadFalso";
        public const string CodCat = "CodigoCatalogo";
        public const string NomCat = "NombreCatalogo";
        public const string FotExi = "FotoExistencia";
        public const string FecVctExi = "FechaVctoExistencia";
        public const string LotProExi = "LoteProduccionExistencia";
        public const string CEsLot = "CEsLote";
        public const string NEsLot = "NEsLote";
        public const string CEsUndCon = "CEsUnidadConvertida";
        public const string NEsUndCon = "NEsUnidadConvertida";
        public const string FacCon = "FactorConversion";
        public const string CEstExi = "CEstadoExistencia";
        public const string NEstExi = "NEstadoExistencia";
        public const string UniXEmp = "UnidadesPorEmpaque";
        public const string UsuAgr = "UsuarioAgrega";
        public const string FecAgr = "FechaAgrega";
        public const string UsuMod = "UsuarioModifica";
        public const string FecMod = "FechaModifica";
        public const string PreUltCom = "PrecioUltimaCompra";
        public const string FecUltCom = "FechaUltimaCompra";
        public const string CAfeIgv = "CAfectoIgv";
        public const string NAfeIgv = "NAfectoIgv";

        //atributos
        private string _ClaveObjeto = string.Empty;
        private string _ClaveExistencia = string.Empty;
        private string _CodigoEmpresa = string.Empty;
        private string _CodigoAlmacen = string.Empty;
        private string _DescripcionAlmacen = string.Empty;
        private string _CodigoExistencia = string.Empty;
        private string _DescripcionExistencia = string.Empty;
        private string _DescripcionSecundariaExistencia = string.Empty;
        private string _DescripcionCortaExistencia = string.Empty;
        private string _CodigoUnidadMedida = "NIU";
        private string _NombreUnidadMedida = string.Empty;
        private string _CCodigoUbicacion = string.Empty;
        private string _NCodigoUbicacion = string.Empty;
        private string _CodigoTipo = "03";
        private string _NombreTipo = string.Empty;
        private string _CodigoGrupo = "0301";
        private string _NombreGrupo = string.Empty;
        private string _CClaseExistencia = string.Empty;
        private string _NClaseExistencia = string.Empty;
        private string _CSubClaseExistencia = string.Empty;
        private string _NSubClaseExistencia = string.Empty;
        private string _CEsProduccion = "0";
        private string _NEsProduccion = "No";
        private string _ContableExistencia = string.Empty;
        private string _CodigoArea = string.Empty;
        private string _NombreArea = string.Empty;
        private string _CCentroCosto = string.Empty;
        private string _NCentroCosto = string.Empty;
        private string _AmbienteExistencia = string.Empty;
        private string _CodigoMarca = string.Empty;
        private string _NombreMarca = string.Empty;
        private string _ModeloExistencia = string.Empty;
        private string _SerieExistencia = string.Empty;
        private string _MedidasExistencia = string.Empty;
        private string _CodigoColor = "001";
        private string _NombreColor = string.Empty;
        private decimal _StockMinimoExistencia = 0;
        private decimal _StockAlertaExistencia = 0;
        private decimal _StockTomaExistencia = 0;
        private decimal _StockInicialExistencia = 0;
        private decimal _StockActualExistencia = 0;
        private decimal _PrecioInicialExistencia = 0;
        private decimal _PrecioPromedioExistencia = 0;
        private decimal _PesoExistencia = 0;
        private bool _VerdadFalso = false;
        private string _CodigoCatalogo = "9";
        private string _NombreCatalogo = string.Empty;
        private string _FotoExistencia = string.Empty;
        private string _FechaVctoExistencia = string.Empty;
        private string _LoteProduccionExistencia = string.Empty;
        private string _CEsLote = "0";
        private string _NEsLote = "No";
        private string _CEsUnidadConvertida = "0";
        private string _NEsUnidadConvertida = "No";
        private decimal _FactorConversion = 0;
        private string _CEstadoExistencia = "1";
        private string _NEstadoExistencia = "Activo";
        private decimal _UnidadesPorEmpaque = 0;
        private string _UsuarioAgrega = string.Empty;
        private DateTime _FechaAgrega;
        private string _UsuarioModifica = string.Empty;
        private DateTime _FechaModifica;
        private decimal _PrecioUltimaCompra = 0;
        private string _FechaUltimaCompra;
        private Adicional _Adicionales = new Adicional();
        private string _CAfectoIgv = "1";
        private string _NAfectoIgv = "Si";

        public string ClaveObjeto
        {
            get { return this._ClaveObjeto; }
            set { this._ClaveObjeto = value; }
        }

        public string ClaveExistencia
        {
            get { return this._ClaveExistencia; }
            set { this._ClaveExistencia = value; }
        }

        public string CodigoEmpresa
        {
            get { return this._CodigoEmpresa; }
            set { this._CodigoEmpresa = value; }
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

        public string DescripcionSecundariaExistencia
        {
            get { return this._DescripcionSecundariaExistencia; }
            set { this._DescripcionSecundariaExistencia = value; }
        }

        public string DescripcionCortaExistencia
        {
            get { return this._DescripcionCortaExistencia; }
            set { this._DescripcionCortaExistencia = value; }
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

        public string CCodigoUbicacion
        {
            get { return this._CCodigoUbicacion; }
            set { this._CCodigoUbicacion = value; }
        }

        public string NCodigoUbicacion
        {
            get { return this._NCodigoUbicacion; }
            set { this._NCodigoUbicacion = value; }
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

        public string CodigoGrupo
        {
            get { return this._CodigoGrupo; }
            set { this._CodigoGrupo = value; }
        }

        public string NombreGrupo
        {
            get { return this._NombreGrupo; }
            set { this._NombreGrupo = value; }
        }

        public string CClaseExistencia
        {
            get { return this._CClaseExistencia; }
            set { this._CClaseExistencia = value; }
        }

        public string NClaseExistencia
        {
            get { return this._NClaseExistencia; }
            set { this._NClaseExistencia = value; }
        }

        public string CSubClaseExistencia
        {
            get { return this._CSubClaseExistencia; }
            set { this._CSubClaseExistencia = value; }
        }

        public string NSubClaseExistencia
        {
            get { return this._NSubClaseExistencia; }
            set { this._NSubClaseExistencia = value; }
        }
        public string CEsProduccion
        {
            get { return this._CEsProduccion; }
            set { this._CEsProduccion = value; }
        }

        public string NEsProduccion
        {
            get { return this._NEsProduccion; }
            set { this._NEsProduccion = value; }
        }

        public string ContableExistencia
        {
            get { return this._ContableExistencia; }
            set { this._ContableExistencia = value; }
        }

        public string CodigoArea
        {
            get { return this._CodigoArea; }
            set { this._CodigoArea = value; }
        }

        public string NombreArea
        {
            get { return this._NombreArea; }
            set { this._NombreArea = value; }
        }

        public string CCentroCosto
        {
            get { return this._CCentroCosto; }
            set { this._CCentroCosto = value; }
        }

        public string NCentroCosto
        {
            get { return this._NCentroCosto; }
            set { this._NCentroCosto = value; }
        }

        //public string NombreCentroCosto
        //{
        //    get { return this._NombreCentroCosto; }
        //    set { this._NombreCentroCosto = value; }
        //}

        public string AmbienteExistencia
        {
            get { return this._AmbienteExistencia; }
            set { this._AmbienteExistencia = value; }
        }

        public string CodigoMarca
        {
            get { return this._CodigoMarca; }
            set { this._CodigoMarca = value; }
        }

        public string NombreMarca
        {
            get { return this._NombreMarca; }
            set { this._NombreMarca = value; }
        }

        public string ModeloExistencia
        {
            get { return this._ModeloExistencia; }
            set { this._ModeloExistencia = value; }
        }

        public string SerieExistencia
        {
            get { return this._SerieExistencia; }
            set { this._SerieExistencia = value; }
        }

        public string MedidasExistencia
        {
            get { return this._MedidasExistencia; }
            set { this._MedidasExistencia = value; }
        }

        public string CodigoColor
        {
            get { return this._CodigoColor; }
            set { this._CodigoColor = value; }
        }

        public string NombreColor
        {
            get { return this._NombreColor; }
            set { this._NombreColor = value; }
        }

        public decimal StockMinimoExistencia
        {
            get { return this._StockMinimoExistencia; }
            set { this._StockMinimoExistencia = value; }
        }

        public decimal StockAlertaExistencia
        {
            get { return this._StockAlertaExistencia; }
            set { this._StockAlertaExistencia = value; }
        }

        public decimal StockTomaExistencia
        {
            get { return this._StockTomaExistencia; }
            set { this._StockTomaExistencia = value; }
        }

        public decimal StockInicialExistencia
        {
            get { return this._StockInicialExistencia; }
            set { this._StockInicialExistencia = value; }
        }

        public decimal StockActualExistencia
        {
            get { return this._StockActualExistencia; }
            set { this._StockActualExistencia = value; }
        }

        public decimal PrecioInicialExistencia
        {
            get { return this._PrecioInicialExistencia; }
            set { this._PrecioInicialExistencia = value; }
        }

        public decimal PrecioPromedioExistencia
        {
            get { return this._PrecioPromedioExistencia; }
            set { this._PrecioPromedioExistencia = value; }
        }

        public decimal PesoExistencia
        {
            get { return this._PesoExistencia; }
            set { this._PesoExistencia = value; }
        }

        public bool VerdadFalso
        {
            get { return this._VerdadFalso; }
            set { this._VerdadFalso = value; }
        }

        public string CodigoCatalogo
        {
            get { return this._CodigoCatalogo; }
            set { this._CodigoCatalogo = value; }
        }

        public string NombreCatalogo
        {
            get { return this._NombreCatalogo; }
            set { this._NombreCatalogo = value; }
        }

        public string FotoExistencia
        {
            get { return this._FotoExistencia; }
            set { this._FotoExistencia = value; }
        }

        public string FechaVctoExistencia
        {
            get { return this._FechaVctoExistencia; }
            set { this._FechaVctoExistencia = value; }
        }

        public string LoteProduccionExistencia
        {
            get { return this._LoteProduccionExistencia; }
            set { this._LoteProduccionExistencia = value; }
        }

        public string CEsLote
        {
            get { return this._CEsLote; }
            set { this._CEsLote = value; }
        }

        public string NEsLote
        {
            get { return this._NEsLote; }
            set { this._NEsLote = value; }
        }

        public string CEsUnidadConvertida
        {
            get { return this._CEsUnidadConvertida; }
            set { this._CEsUnidadConvertida = value; }
        }

        public string NEsUnidadConvertida
        {
            get { return this._NEsUnidadConvertida; }
            set { this._NEsUnidadConvertida = value; }
        }
        public decimal FactorConversion
        {
            get { return this._FactorConversion; }
            set { this._FactorConversion = value; }
        }
        public decimal UnidadesPorEmpaque
        {
            get { return this._UnidadesPorEmpaque; }
            set { this._UnidadesPorEmpaque = value; }
        }

        public string CEstadoExistencia
        {
            get { return this._CEstadoExistencia; }
            set { this._CEstadoExistencia = value; }
        }

        public string NEstadoExistencia
        {
            get { return this._NEstadoExistencia; }
            set { this._NEstadoExistencia = value; }
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

        public decimal PrecioUltimaCompra
        {
            get { return this._PrecioUltimaCompra; }
            set { this._PrecioUltimaCompra = value; }
        }

        public string FechaUltimaCompra
        {
            get { return this._FechaUltimaCompra; }
            set { this._FechaUltimaCompra = value; }
        }

        public Adicional Adicionales
        {
            get { return this._Adicionales; }
            set { this._Adicionales = value; }
        }

        public string CAfectoIgv
        {
            get { return this._CAfectoIgv; }
            set { this._CAfectoIgv = value; }
        }

        public string NAfectoIgv
        {
            get { return this._NAfectoIgv; }
            set { this._NAfectoIgv = value; }
        }

    }
}
