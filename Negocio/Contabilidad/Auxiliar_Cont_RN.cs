using Datos;
using Datos.Contabilidad;
using Entidades.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contabilidad
{
    public class Auxiliar_Cont_RN
    {

        public static Auxiliar_Cont_EN EnBlanco()
        {
            Auxiliar_Cont_EN iPerEN = new Auxiliar_Cont_EN();
            return iPerEN;
        }

        public static List<Auxiliar_Cont_EN> ListarAuxiliarsParaImportar(string pCodigoPeriodo)
        {
            Auxiliar_Cont_AD iPerAD = new Auxiliar_Cont_AD();
            return iPerAD.ListarAuxiliarsParaImportar(pCodigoPeriodo);
        }

        public static string ObtenerValorDeCampo(Auxiliar_Cont_EN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case Auxiliar_Cont_EN.CodAux: return pObj.CodigoAuxiliar;
                case Auxiliar_Cont_EN.DesAux: return pObj.DescripcionAuxiliar;
                case Auxiliar_Cont_EN.DirAux: return pObj.DireccionAuxiliar;
                case Auxiliar_Cont_EN.TelAux: return pObj.TelefonoAuxiliar;
                case Auxiliar_Cont_EN.CelAux: return pObj.CelularAuxiliar;
                case Auxiliar_Cont_EN.CorAux: return pObj.CorreoAuxiliar;
                case Auxiliar_Cont_EN.RefAux: return pObj.ReferenciaAuxiliar;
                case Auxiliar_Cont_EN.TipAux: return pObj.TipoAuxiliar;
                case Auxiliar_Cont_EN.TipDocAux: return pObj.TipoDocumentoAuxiliar;
                case Auxiliar_Cont_EN.EstAux: return pObj.EstadoAuxiliar;                
            }

            //retorna
            return iValor;
        }

        public static List<Auxiliar_Cont_EN> FiltrarAuxiliar_Cont_sXTextoEnCualquierPosicion(List<Auxiliar_Cont_EN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<Auxiliar_Cont_EN> iLisRes = new List<Auxiliar_Cont_EN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (Auxiliar_Cont_EN xPer in pLista)
            {
                string iTexto = Auxiliar_Cont_RN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<Auxiliar_Cont_EN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<Auxiliar_Cont_EN> pListaAuxiliar_Cont_s)
        {
            //lista resultado
            List<Auxiliar_Cont_EN> iLisRes = new List<Auxiliar_Cont_EN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaAuxiliar_Cont_s; }

            //filtar la lista
            iLisRes = Auxiliar_Cont_RN.FiltrarAuxiliar_Cont_sXTextoEnCualquierPosicion(pListaAuxiliar_Cont_s, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static Auxiliar_Cont_EN BuscarAuxiliar(string pCampoBusqueda, string pValorBusqueda, List<Auxiliar_Cont_EN> pListaBusqueda)
        {
            //objeto resultado
            Auxiliar_Cont_EN iAuxEN = new Auxiliar_Cont_EN();

            //recorrer cada objeto
            foreach (Auxiliar_Cont_EN xAux in pListaBusqueda)
            {
                if (Auxiliar_Cont_RN.ObtenerValorDeCampo(xAux, pCampoBusqueda) == pValorBusqueda)
                {
                    iAuxEN = xAux;
                    return iAuxEN;
                }
            }

            //devolver
            return iAuxEN;
        }

    }
}
