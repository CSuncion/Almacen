using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using Entidades.Contabilidad;

namespace Negocio
{
    public class RegContabDeta_Cont_RN
    {

        public static RegContabDeta_Cont_EN EnBlanco()
        {
            RegContabDeta_Cont_EN iPerEN = new RegContabDeta_Cont_EN();
            return iPerEN;
        }

        public static List<List< RegContabDeta_Cont_EN>> ListarRegContabDetasParaImportar(string pCodigoPeriodo)
        {
            RegContabDeta_Cont_AD iPerAD = new RegContabDeta_Cont_AD();
            return iPerAD.ListarRegContabDetasParaImportar(pCodigoPeriodo);
        }

        public static string ObtenerValorDeCampo(RegContabDeta_Cont_EN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case RegContabDeta_Cont_EN.ClaObj: return pObj.ClaveObjeto;
                case RegContabDeta_Cont_EN.ClaRegConCab: return pObj.ClaveRegContabCabe;
                case RegContabDeta_Cont_EN.CodEmp: return pObj.CodigoEmpresa;
                case RegContabDeta_Cont_EN.RazSocEmp: return pObj.RazonSocialEmpresa;
                case RegContabDeta_Cont_EN.PerRegConCab: return pObj.PeriodoRegContabCabe;
                case RegContabDeta_Cont_EN.CodOri: return pObj.CodigoOrigen;
                case RegContabDeta_Cont_EN.NomOri: return pObj.NombreOrigen;
                case RegContabDeta_Cont_EN.CodFil: return pObj.CodigoFile;
                case RegContabDeta_Cont_EN.NomFil: return pObj.NombreFile;
                case RegContabDeta_Cont_EN.FecVouRegConCab: return pObj.FechaVoucherRegContabCabe;
                case RegContabDeta_Cont_EN.CodAux: return pObj.CodigoAuxiliar;
                case RegContabDeta_Cont_EN.DesAux: return pObj.DescripcionAuxiliar;
                case RegContabDeta_Cont_EN.TipDoc: return pObj.TipoDocumento;
                case RegContabDeta_Cont_EN.NomDoc: return pObj.NombreDocumento;
                case RegContabDeta_Cont_EN.SerDoc: return pObj.SerieDocumento;
                case RegContabDeta_Cont_EN.NumDoc: return pObj.NumeroDocumento;
                case RegContabDeta_Cont_EN.FecDoc: return pObj.FechaDocumento;
                case RegContabDeta_Cont_EN.DebHabRegConDet: return pObj.DebeHaberRegContabDeta;
                case RegContabDeta_Cont_EN.ImpSRegConDet: return pObj.ImporteSRegContabDeta.ToString();
                case RegContabDeta_Cont_EN.Alm: return pObj.Almacen;
                case RegContabDeta_Cont_EN.CodGasRep: return pObj.CodigoGastoReparable;
                case RegContabDeta_Cont_EN.NomGasRep: return pObj.NombreGastoReparable;
                case RegContabDeta_Cont_EN.Uni: return pObj.Unidad;
                case RegContabDeta_Cont_EN.Can: return pObj.Cantidad.ToString();
                case RegContabDeta_Cont_EN.PreUni: return pObj.PrecioUnitario.ToString();
                case RegContabDeta_Cont_EN.GloRegConDet: return pObj.GlosaRegContabDeta;
                case RegContabDeta_Cont_EN.DesRegConCab: return pObj.DescripcionRegContabCabe;
                case RegContabDeta_Cont_EN.CodCenCos: return pObj.CodigoCentroCosto;
                case RegContabDeta_Cont_EN.NomCenCos: return pObj.NombreCentroCosto;
            }

            //retorna
            return iValor;
        }

        public static List<RegContabDeta_Cont_EN> FiltrarRegContabDeta_Cont_sXTextoEnCualquierPosicion(List<RegContabDeta_Cont_EN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<RegContabDeta_Cont_EN> iLisRes = new List<RegContabDeta_Cont_EN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (RegContabDeta_Cont_EN xPer in pLista)
            {
                string iTexto = RegContabDeta_Cont_RN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<RegContabDeta_Cont_EN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<RegContabDeta_Cont_EN> pListaRegContabDeta_Cont_s)
        {
            //lista resultado
            List<RegContabDeta_Cont_EN> iLisRes = new List<RegContabDeta_Cont_EN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaRegContabDeta_Cont_s; }

            //filtar la lista
            iLisRes = RegContabDeta_Cont_RN.FiltrarRegContabDeta_Cont_sXTextoEnCualquierPosicion(pListaRegContabDeta_Cont_s, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string TransformarAPeriodoContable(string pCodigoPeriodoAlmacen)
        {
            //valor resulatdo
            string iValor = string.Empty;

            //operar
            iValor = pCodigoPeriodoAlmacen.Replace("-", "");

            //devolver
            return iValor;
        }

        public static bool EsCompraNacional(RegContabDeta_Cont_EN pObj)
        {
            //validar por el tipo documento
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.TipoDocumento, "00,46,51,52,53,91,97,98") == true)
            {
                //seria importacion por lotanto devuelve false
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
