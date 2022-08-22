using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;

namespace Negocio
{
    public class BotonRN
    {
        public static BotonEN EnBlanco()
        {
            BotonEN iBotEN = new BotonEN();
            return iBotEN;
        }


        public static void AdicionarBoton(BotonEN pObj)
        {
            BotonAD iBotAD = new BotonAD();
            iBotAD.AgregarBoton(pObj);
        }
        
        public static void ModificarBoton(BotonEN pObj)
        {
            BotonAD iBotAD = new BotonAD();
            iBotAD.ModificarBoton(pObj);
        }
        
        public static void EliminarBoton(BotonEN pObj)
        {
            BotonAD iBotAD = new BotonAD();
            iBotAD.EliminarBoton(pObj);
        }
        
        public static BotonEN BuscarBotonXCodigo(BotonEN pObj)
        {
            BotonAD iBotAD = new BotonAD();
            return iBotAD.BuscarBotonXCodigo(pObj);
        }
        
        public static List<BotonEN> ListarBotones(BotonEN pObj)
        {
            BotonAD iBotAD = new BotonAD();
            return iBotAD.ListarBoton(pObj);
        }

        public static BotonEN EsBotonExistente(BotonEN pObj)
        {
            BotonEN iBotEN = new BotonEN();
            iBotEN = BotonRN.BuscarBotonXCodigo(pObj);
            if (iBotEN.CodigoBoton == string.Empty)
            {
                iBotEN.Adicionales.EsVerdad = false;
                iBotEN.Adicionales.Mensaje = "El Boton " + pObj.CodigoBoton + " no existe";
            }
            else
            {
                iBotEN.Adicionales.EsVerdad = true;

            }
            return iBotEN;
        }

        public static BotonEN EsCodigoBotonDisponible(BotonEN pObj)
        {
            BotonEN iBotEN = new BotonEN();

            //si no hay codigo pasa verdadero
            if (pObj.CodigoBoton == string.Empty)
            {
                iBotEN.Adicionales.EsVerdad = true;
                iBotEN.Adicionales.Mensaje = string.Empty;
                return iBotEN;
            }

            //aqui si hay codigo
            iBotEN = BotonRN.BuscarBotonXCodigo(pObj);
            if (iBotEN.CodigoBoton == string.Empty)
            {
                iBotEN.Adicionales.EsVerdad = true;
            }
            else
            {
                iBotEN.Adicionales.EsVerdad = false;
                iBotEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoBoton + " ya le pertenece a un Boton";
            }
            return iBotEN;
        }
    }
}
