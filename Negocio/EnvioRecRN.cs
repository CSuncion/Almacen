using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;


namespace Negocio
{
    public class EnvioRecRN
    {

        public static EnvioRecEN EnBlanco()
        {
            EnvioRecEN iEnvEN = new EnvioRecEN();
            return iEnvEN;
        }
        
        public static void AdicionarEnvioRec(EnvioRecEN pObj)
        {
            EnvioRecAD iEnvAD = new EnvioRecAD();
            iEnvAD.AdicionarEnvioRec(pObj);
        }
        
        public static void ModificarEnvioRec(EnvioRecEN pObj)
        {
            EnvioRecAD iEnvAD = new EnvioRecAD();
            iEnvAD.ModificarEnvioRec(pObj);
        }

        public static void EliminarEnvioRecXClave(EnvioRecEN pObj)
        {
            EnvioRecAD iEnvAD = new EnvioRecAD();
            iEnvAD.EliminarEnvioRecXClave(pObj);
        }

        public static EnvioRecEN BuscarEnvioRecXClave(EnvioRecEN pObj)
        {
            EnvioRecAD iEnvAD = new EnvioRecAD();
            return iEnvAD.BuscarEnvioRecXClave(pObj);
        }

        public static List<EnvioRecEN> ListarEnvioRec(EnvioRecEN pObj)
        {
            EnvioRecAD iEnvAD = new EnvioRecAD();
            return iEnvAD.ListarEnvioRec(pObj);
        }

        public static List<EnvioRecEN> ListarEnvioRecActivos(EnvioRecEN pObj)
        {
            EnvioRecAD iEnvAD = new EnvioRecAD();
            return iEnvAD.ListarEnvioRecActivos(pObj);
        }
        
        public static List<EnvioRecEN> ListarEnvioRecXEstado(EnvioRecEN pObj)
        {
            EnvioRecAD iEnvAD = new EnvioRecAD();
            return iEnvAD.ListarEnvioRecXEstado( pObj );
        }

        public static EnvioRecEN EsEnvioRecExistente(EnvioRecEN pObj)
        {
            //valor resultado
            EnvioRecEN iEnvEN = new EnvioRecEN();
            iEnvEN = EnvioRecRN.BuscarEnvioRecXClave(pObj);
            if (iEnvEN.ClaveEnvioRec == string.Empty)
            {
                iEnvEN.Adicionales.EsVerdad = false;
                iEnvEN.Adicionales.Mensaje = "El EnvioRec " + pObj.ClaveEnvioRec + " no existe";
                return iEnvEN;
            }
            
            //ok
            iEnvEN.Adicionales.EsVerdad = true;
            return iEnvEN;
        }

        public static string ObtenerCorrelativoEnvioRec(EnvioRecEN pObj)
        {
            //el nuevo correlativo
            string iNuevoNumero;

            //traer una lista de todas los mensajes de este cliente
            //pero solo de una empresa
            List<EnvioRecEN> iLisEnv = new List<EnvioRecEN>();
            pObj.Adicionales.CampoOrden = EnvioRecEN.ClaEnvRec;
            iLisEnv = EnvioRecRN.ListarEnvioRec(pObj);


            //la estructura del correlativo sera:
            //CodigoEmpresa + Correlativo
            //si la lista esta vacia se crea el primer correlativo      
            int iNumeroMensajes = iLisEnv.Count;
            if (iNumeroMensajes == 0)
            {              
                iNuevoNumero = "000001";
            }
            else
            {
                string iUltimoCorrelativo = iLisEnv[iNumeroMensajes - 1].CorrelativoEnvioRec;
                int iCorrelativo = Convert.ToInt32(iUltimoCorrelativo);
                iCorrelativo++;
                iNuevoNumero = iCorrelativo.ToString().PadLeft(6, Convert.ToChar("0"));
            }
            return iNuevoNumero;
        }

        public static EnvioRecEN EsEnvioRecModificable(EnvioRecEN pObj)
        {
            //preguntar si el envio rec existe en b.d
            EnvioRecEN iEnvEN = EnvioRecRN.EsDetalleEnvioRecModificable(pObj);
            if (iEnvEN.Adicionales.EsVerdad == false) { return iEnvEN; }

            ////preguntar si este envio tiene letras seleccionadas , si fuiera asi entonces
            ////ya no se puede moficar el envio
            //DetalleEnvioRecRN iDeEnvRN = new DetalleEnvioRecRN();
            //DetalleEnvioRecEN iDeEnvEN = new DetalleEnvioRecEN();
            //iDeEnvEN.ClaveEnvioRec = iEnvEN.ClaveEnvioRec;
            //iDeEnvEN.Adicionales.CampoOrden = DetalleEnvioRecEN.ClaLet;
            //List<DetalleEnvioRecEN> iLisDeEnv = iDeEnvRN.ListarDetalleEnvioRecXClave(iDeEnvEN);
            //if (iLisDeEnv.Count != 0)
            //{
            //    //aqui significva que hay letras para este envio
            //    iEnvEN.Adicionales.EsVerdad = false;
            //    iEnvEN.Adicionales.Mensaje = "Este envio ya tiene letras seleccionadas , no puede realizar la operacion";
            //    return iEnvEN;
            //}

            //ok
            iEnvEN.Adicionales.EsVerdad = true;
            iEnvEN.Adicionales.Mensaje = string.Empty;
            return iEnvEN;
        }

        public static EnvioRecEN EsDetalleEnvioRecModificable(EnvioRecEN pObj)
        {
            //preguntar si el envio rec existe en b.d
            EnvioRecEN iEnvEN = EnvioRecRN.EsEnvioRecExistente(pObj);
            if( iEnvEN.Adicionales.EsVerdad == false ) { return iEnvEN; }

            //chequear el estado del envio
            if( iEnvEN.CEstadoEnvioRec == "1" )// el envio se encuentra en estado : enviado
            {
                iEnvEN.Adicionales.EsVerdad = false;
                iEnvEN.Adicionales.Mensaje = "Este envio se encuentra en estado : Enviado , no puede realizar la operacion";
                return iEnvEN;
            }

            //ok
            iEnvEN.Adicionales.EsVerdad = true;
            iEnvEN.Adicionales.Mensaje = string.Empty;
            return iEnvEN;
        }

        public static EnvioRecEN EsActoAprobarEnvioRec(EnvioRecEN pObj)
        {
            //preguntar si el envio rec existe en b.d
            EnvioRecEN iEnvEN = EnvioRecRN.EsEnvioRecExistente(pObj);
            if( iEnvEN.Adicionales.EsVerdad == false ) { return iEnvEN; }

            //chequear el estado del envio
            if( iEnvEN.CEstadoEnvioRec == "1" )// el envio se encuentra en estado : enviado
            {
                iEnvEN.Adicionales.EsVerdad = false;
                iEnvEN.Adicionales.Mensaje = "Este envio ya se encuentra en estado : Enviado , no puede realizar la operacion";
                return iEnvEN;
            }

            //ok
            iEnvEN.Adicionales.EsVerdad = true;
            iEnvEN.Adicionales.Mensaje = string.Empty;
            return iEnvEN;
        }
        
        public static EnvioRecEN EsActoDesaprobarEnvioRec( EnvioRecEN pObj )
        {
            //preguntar si el envio rec existe en b.d
            EnvioRecEN iEnvEN = EnvioRecRN.EsEnvioRecExistente(pObj);
            if( iEnvEN.Adicionales.EsVerdad == false ) { return iEnvEN; }

            //chequear el estado del envio
            if( iEnvEN.CEstadoEnvioRec == "0" )// el envio se encuentra en estado : procesando
            {
                iEnvEN.Adicionales.EsVerdad = false;
                iEnvEN.Adicionales.Mensaje = "Este envio ya se encuentra en estado : Procesando , no puede realizar la operacion";
                return iEnvEN;
            }

            //ok
            iEnvEN.Adicionales.EsVerdad = true;
            iEnvEN.Adicionales.Mensaje = string.Empty;
            return iEnvEN;
        }

        public static string ObtenerValorDeCampo(EnvioRecEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case EnvioRecEN.ClaObj: return pObj.ClaveObjeto;
                case EnvioRecEN.ClaEnvRec: return pObj.ClaveEnvioRec;
                case EnvioRecEN.CorEnvRec: return pObj.CorrelativoEnvioRec;
                case EnvioRecEN.FecEnvRec: return pObj.FechaEnvioRec;
                case EnvioRecEN.NEstEnvRec: return pObj.NEstadoEnvioRec;
                case EnvioRecEN.UsuAgr: return pObj.UsuarioAgrega;
                case EnvioRecEN.FecAgr: return pObj.FechaAgrega.ToString();
                case EnvioRecEN.UsuMod: return pObj.UsuarioModifica;
                case EnvioRecEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<EnvioRecEN> FiltrarEnvioRecsXTextoEnCualquierPosicion(List<EnvioRecEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<EnvioRecEN> iLisRes = new List<EnvioRecEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (EnvioRecEN xPro in pLista)
            {
                string iTexto = EnvioRecRN.ObtenerValorDeCampo(xPro, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPro);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<EnvioRecEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<EnvioRecEN> pListaEnvioRecs)
        {
            //lista resultado
            List<EnvioRecEN> iLisRes = new List<EnvioRecEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaEnvioRecs; }

            //filtar la lista
            iLisRes = EnvioRecRN.FiltrarEnvioRecsXTextoEnCualquierPosicion(pListaEnvioRecs, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveEnvioRec(EnvioRecEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CorrelativoEnvioRec;
            return iClave;
        }

        public static bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            EnvioRecAD iEnvRecAD = new EnvioRecAD();
            return iEnvRecAD.ExisteValorEnColumna(pColumna, pValor);
        }

 
    }
}
