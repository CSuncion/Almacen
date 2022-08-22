using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;

namespace Negocio
{
    public class VentanaBotonRN
    {
        public static VentanaBotonEN EnBlanco()
        {
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();
            return iVenBotEN;
        }

        public static void AdicionarVentanaBoton(VentanaBotonEN pObj)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            iVenBotAD.AgregarVentanaBoton(pObj);
        }

        public static void AdicionarVentanaBotonMasivo(List<VentanaBotonEN> pLista)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            iVenBotAD.AgregarVentanaBotonMasivo(pLista);
        }

        public static void ModificarVentanaBoton(VentanaBotonEN pObj)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            iVenBotAD.ModificarVentanaBoton(pObj);
        }

        public static void EliminarVentanaBoton(VentanaBotonEN pObj)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            iVenBotAD.EliminarVentanaBoton(pObj);
        }

        public static void EliminarVentanaBotonXVentana(VentanaBotonEN pObj)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            iVenBotAD.EliminarVentanaBotonXVentana(pObj);
        }

        public static void EliminarVentanaBotonMasivo(List<VentanaBotonEN> pLista)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            iVenBotAD.EliminarVentanaBotonMasivo(pLista);
        }

        public static VentanaBotonEN BuscarVentanaBotonXClave(VentanaBotonEN pObj)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            return iVenBotAD.BuscarVentanaBotonXClave(pObj);
        }

        public static List<VentanaBotonEN> ListarVentanaBotones(VentanaBotonEN pObj)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            return iVenBotAD.ListarVentanaBotones(pObj);
        }

        public static List<VentanaBotonEN> ListarVentanaBotonesParaAgregarAVentana(VentanaBotonEN pObj)
        {
            //lista resultados
            List<VentanaBotonEN> iLisRes = new List<VentanaBotonEN>();

            //traer todos los Botones que hay
            BotonEN iBotEN = new BotonEN();
            iBotEN.Adicionales.CampoOrden = BotonEN.CodBot;
            List<BotonEN> iLisBot = BotonRN.ListarBotones(iBotEN);

            //traer todos los botones asignados a esta ventana
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();
            iVenBotEN.CodigoVentana = pObj.CodigoVentana;
            iVenBotEN.Adicionales.CampoOrden = VentanaBotonEN.CodBot;
            List<VentanaBotonEN> iLisVenBot = VentanaBotonRN.ListarVentanaBotonesXVentana(iVenBotEN);

            //en la lista de resultados poner todos los botones excepto los que ya estan asignados
            //a esta ventana
            foreach (BotonEN xBot in iLisBot)
            {
                int iEncontrado = 0;
                foreach (VentanaBotonEN xVenBot in iLisVenBot)
                {
                    if (xBot.CodigoBoton == xVenBot.CodigoBoton)
                    {
                        iEncontrado = 1;
                    }
                }
                //si el boton no fue encontrado en los botones de la ventana
                //entonces lo agregamos a la lista de resultados
                if (iEncontrado == 0)
                {
                    VentanaBotonEN iVeBoEN = new VentanaBotonEN();
                    iVeBoEN.CodigoBoton = xBot.CodigoBoton;
                    iVeBoEN.NombreBoton = xBot.NombreBoton;
                    iVeBoEN.CodigoVentana = pObj.CodigoVentana;
                    iVeBoEN.ClaveVentanaBoton = VentanaBotonRN.ObtenerClaveVentanaBoton(iVeBoEN);
                    iVeBoEN.ClaveObjeto = iVeBoEN.ClaveVentanaBoton;
                    iVeBoEN.VerdadFalso = false;
                    iLisRes.Add(iVeBoEN);
                }
                iEncontrado = 0;
            }
            return iLisRes;
        }

        public static string ObtenerClaveVentanaBoton(VentanaBotonEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoVentana + "-";
            iClave += pObj.CodigoBoton;
            return iClave;
        }

        public static void ModificarVentanaBoton(VentanaBotonEN pObj, List<VentanaBotonEN> pLista)
        {
            //lista actualizada
            List<VentanaBotonEN> iLisVenBot = new List<VentanaBotonEN>();

            //buscamos el objeto en la lista pLista
            foreach (VentanaBotonEN xVenBot in pLista)
            {
                if (xVenBot.ClaveVentanaBoton == pObj.ClaveVentanaBoton)
                {
                    xVenBot.VerdadFalso = pObj.VerdadFalso;
                }
                iLisVenBot.Add(xVenBot);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisVenBot);
        }

        public static List<VentanaBotonEN> ListarVentanaBotonesSoloMarcadas(List<VentanaBotonEN> pLista)
        {
            //lista resultado
            List<VentanaBotonEN> iLisRes = new List<VentanaBotonEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (VentanaBotonEN xVenBot in pLista)
            {
                if (xVenBot.VerdadFalso == true)
                {
                    iLisRes.Add(xVenBot);
                }
            }
            return iLisRes;
        }

        public static VentanaBotonEN HayObjetosMarcados(List<VentanaBotonEN> pLista)
        {
            //oibjeto resultado
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();

            //si la lista esta vacia entonces no hay marcados
            if (pLista.Count == 0)
            {
                iVenBotEN.Adicionales.EsVerdad = false;
                iVenBotEN.Adicionales.Mensaje = "No hay botones marcados, no se puede realizar la operacion";
                return iVenBotEN;
            }
            //ok
            iVenBotEN.Adicionales.EsVerdad = true;
            return iVenBotEN;
        }

        public static List<VentanaBotonEN> ListarVentanaBotonesXVentana(VentanaBotonEN pObj)
        {
            VentanaBotonAD iVenBotAD = new VentanaBotonAD();
            return iVenBotAD.ListarVentanaBotonesXVentana(pObj);
        }

    }
}
