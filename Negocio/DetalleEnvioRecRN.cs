using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;


namespace Negocio
{
    public class DetalleEnvioRecRN
    {

        public static DetalleEnvioRecEN EnBlanco()
        {
            DetalleEnvioRecEN iDetEN = new DetalleEnvioRecEN();
            return iDetEN;
        }

        public static void AdicionarDetalleEnvioRec(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            iDetAD.AdicionarDetalleEnvioRec(pObj);
        }

        public static void AdicionarDetalleEnvioRecMasivo(List<DetalleEnvioRecEN> pLista)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            iDetAD.AdicionarDetalleEnvioRecMasivo(pLista);
        }

        public static void AdicionarDetalleEnvioRecMasivo1(List<DetalleEnvioRecEN> pLista)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            iDetAD.AdicionarDetalleEnvioRecMasivo1(pLista);
        }

        public static void ModificarDetalleEnvioRec(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            iDetAD.ModificarDetalleEnvioRec(pObj);
        }

        public static void EliminarDetalleEnvioRecXClave(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            iDetAD.EliminarDetalleEnvioRecXClave(pObj);
        }

        public static void EliminarDetalleEnvioRecXClaveMasivo(List<DetalleEnvioRecEN> pLista)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            iDetAD.EliminarDetalleEnvioRecXClaveMasivo(pLista);
        }

        public static void EliminarDetalleEnvioRecXClaveMasivo1(List<DetalleEnvioRecEN> pLista)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            iDetAD.EliminarDetalleEnvioRecXClaveMasivo1(pLista);
        }

        public static void EliminarDetalleEnvioRecXEnvio(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            iDetAD.EliminarDetalleEnvioRecXEnvio( pObj );
        }

        public static DetalleEnvioRecEN BuscarDetalleEnvioRecXClave(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iDetAD = new DetalleEnvioRecAD();
            return iDetAD.BuscarDetalleEnvioRecXClave(pObj);
        }

        public static List<DetalleEnvioRecEN> ListarDetalleEnvioRec(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iEnvAD = new DetalleEnvioRecAD( );
            return iEnvAD.ListarDetalleEnvioRec( pObj );
        }

        public static List<DetalleEnvioRecEN> ListarDetalleEnvioRecXClaveEnvioRec(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iEnvAD = new DetalleEnvioRecAD( );
            return iEnvAD.ListarDetalleEnvioRecXClaveEnvioRec( pObj );
        }

        public static List<DetalleEnvioRecEN> ListarLetrasDeEnvioRecXFiltro(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iEnvAD = new DetalleEnvioRecAD();
            return iEnvAD.ListarLetrasDeEnvioRecXFiltro(pObj);
        }

        public static List<DetalleEnvioRecEN> ListarLetrasDeEnvioRecCreditoXFiltro(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iEnvAD = new DetalleEnvioRecAD( );
            return iEnvAD.ListarLetrasDeEnvioRecCreditoXFiltro( pObj );
        }

        public static DetalleEnvioRecEN EsDetalleEnvioRecExistente(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecEN iEnvEN = new DetalleEnvioRecEN();
            iEnvEN = DetalleEnvioRecRN.BuscarDetalleEnvioRecXClave(pObj);
            if (iEnvEN.ClaveDetalleEnvioRec == string.Empty)
            {
                iEnvEN.Adicionales.EsVerdad = false;
                iEnvEN.Adicionales.Mensaje = "El Detalle Envio Rec " + pObj.ClaveDetalleEnvioRec + " no existe";
            }
            else
            {
                iEnvEN.Adicionales.EsVerdad = true;
            }
            return iEnvEN;
        }
              
        public static Decimal ObtenerMontoTotalPorEnvio( List<DetalleEnvioRecEN> pLis )
        {                        
            //variable para sumar cada monto de las letras que hay en este envio
            decimal iSumaTotal = 0;

            foreach( DetalleEnvioRecEN xObj in pLis )
            {
                iSumaTotal += xObj.MontoPendienteCuota;
            }
            return iSumaTotal;
        }

        public static List<List<DetalleEnvioRecEN>> ListarLetrasDeEnvioRecCreditoXFiltro1(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iEnvAD = new DetalleEnvioRecAD();
            return iEnvAD.ListarLetrasDeEnvioRecCreditoXFiltro1(pObj);
        }

        public static List<List<DetalleEnvioRecEN>> ListarLetrasDeEnvioRecXFiltro1(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iEnvAD = new DetalleEnvioRecAD();
            return iEnvAD.ListarLetrasDeEnvioRecXFiltro1(pObj);
        }

        public static string ObtenerNumeroIdClienteDeudor(string pTipoDocumentoCliente)
        {
            //valor resultado
            string iNumeroID = string.Empty;

            //segun tipo documento
            switch (pTipoDocumentoCliente)
            {                
                case "6": { iNumeroID = "R"; break; }
                case "7": { iNumeroID = "P"; break; }
                default: { iNumeroID = "C"; break; }
            }

            //devolver
            return iNumeroID;
        }

        public static string ObtenerClaveDetalleEnvioRec(DetalleEnvioRecEN pDetEnvRec)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave = pDetEnvRec.ClaveEnvioRec + "-";
            iClave += pDetEnvRec.ClaveCuota;
        
            //devolver
            return iClave;
        }

        public static List<DetalleEnvioRecEN> ListarDetallesEnvioRecParaQuitarCuotas(DetalleEnvioRecEN pObj)
        {
            DetalleEnvioRecAD iEnvAD = new DetalleEnvioRecAD();
            return iEnvAD.ListarDetallesEnvioRecParaQuitarCuotas(pObj);
        }


    }
}
