using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using Entidades.Estructuras;

namespace Negocio
{
    public class RetiquetadoProTerRN
    {
        public static RetiquetadoProTerEN EnBlanco()
        {
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();
            return iObjEN;
        }

        public static void AdicionarRetiquetadoProTer(List<RetiquetadoProTerEN> pLista)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            iObjAD.AdicionarRetiquetadoProTer(pLista);
        }

        public static void AdicionarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            //Asignar parametros
            List<RetiquetadoProTerEN> iLisObj = new List<RetiquetadoProTerEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RetiquetadoProTerRN.AdicionarRetiquetadoProTer(iLisObj);
        }

        public static void ModificarRetiquetadoProTer(List<RetiquetadoProTerEN> pLista)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            iObjAD.ModificarRetiquetadoProTer(pLista);
        }

        public static void ModificarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            //Asignar parametros
            List<RetiquetadoProTerEN> iLisObj = new List<RetiquetadoProTerEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RetiquetadoProTerRN.ModificarRetiquetadoProTer(iLisObj);
        }

        public static void EliminarRetiquetadoProTer(List<RetiquetadoProTerEN> pLista)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            iObjAD.EliminarRetiquetadoProTer(pLista);
        }

        public static void EliminarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            //Asignar parametros
            List<RetiquetadoProTerEN> iLisObj = new List<RetiquetadoProTerEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RetiquetadoProTerRN.EliminarRetiquetadoProTer(iLisObj);
        }

        public static void EliminarRetiquetadoProTerXClaveRetiquetado(RetiquetadoProTerEN pObj)
        {
            RetiquetadoProTerAD iProAD = new RetiquetadoProTerAD();
            iProAD.EliminarRetiquetadoProTerXClaveRetiquetado(pObj);
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.ListarRetiquetadoProTer(pObj);
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTer()
        {
            //asignar parametros
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();
            iObjEN.Adicionales.CampoOrden = RetiquetadoProTerEN.ClaRetProTer;

            //ejecutar metodo
            return RetiquetadoProTerRN.ListarRetiquetadoProTer(iObjEN);
        }

        public static RetiquetadoProTerEN BuscarRetiquetadoProTerXClave(RetiquetadoProTerEN pObj)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.BuscarRetiquetadoProTerXClave(pObj);
        }

        public static RetiquetadoProTerEN EsRetiquetadoProTerExistente(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //validar si existe en b.d
            iObjEN = RetiquetadoProTerRN.BuscarRetiquetadoProTerXClave(pObj);
            if (iObjEN.ClaveRetiquetadoProTer == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static RetiquetadoProTerEN EsCodigoRetiquetadoProTerDisponible(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //valida cuando esta vacio
            if (pObj.ClaveRetiquetado == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRetiquetadoProTer == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = RetiquetadoProTerRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RetiquetadoProTerEN ValidaCuandoCodigoYaExiste(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //validar
            iObjEN = RetiquetadoProTerRN.BuscarRetiquetadoProTerXClave(pObj);
            if (iObjEN.ClaveRetiquetadoProTer != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(RetiquetadoProTerEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case RetiquetadoProTerEN.ClaObj: return pObj.ClaveObjeto;
                case RetiquetadoProTerEN.ClaRetProTer: return pObj.ClaveRetiquetadoProTer;
                case RetiquetadoProTerEN.ClaRet: return pObj.ClaveRetiquetado;
                case RetiquetadoProTerEN.CodEmp: return pObj.CodigoEmpresa;
                case RetiquetadoProTerEN.CorRet: return pObj.CorrelativoRetiquetado;
                case RetiquetadoProTerEN.CorRetProTer: return pObj.CorrelativoRetiquetadoProTer;
                case RetiquetadoProTerEN.ClaProProTer: return pObj.ClaveProduccionProTer;
                case RetiquetadoProTerEN.CodAlm: return pObj.CodigoAlmacen;
                case RetiquetadoProTerEN.CodExi: return pObj.CodigoExistencia;
                case RetiquetadoProTerEN.DesExi: return pObj.DescripcionExistencia;
                case RetiquetadoProTerEN.CanRetProTer: return pObj.CantidadRetiquetadoProTer.ToString();
                case RetiquetadoProTerEN.CEstRetProTer: return pObj.CEstadoRetiquetadoProTer;
                case RetiquetadoProTerEN.NEstRetProTer: return pObj.NEstadoRetiquetadoProTer;
                case RetiquetadoProTerEN.UsuAgr: return pObj.UsuarioAgrega;
                case RetiquetadoProTerEN.FecAgr: return pObj.FechaAgrega.ToString();
                case RetiquetadoProTerEN.UsuMod: return pObj.UsuarioModifica;
                case RetiquetadoProTerEN.FecMod: return pObj.FechaModifica.ToString();

            }

            //retorna
            return iValor;
        }

        public static List<RetiquetadoProTerEN> FiltrarRetiquetadoProTerXTextoEnCualquierPosicion(List<RetiquetadoProTerEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<RetiquetadoProTerEN> iLisRes = new List<RetiquetadoProTerEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (RetiquetadoProTerEN xObj in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<RetiquetadoProTerEN>(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<RetiquetadoProTerEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<RetiquetadoProTerEN> pLista)
        {
            //lista resultado
            List<RetiquetadoProTerEN> iLisRes = new List<RetiquetadoProTerEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = RetiquetadoProTerRN.FiltrarRetiquetadoProTerXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += pObj.ClaveRetiquetado + "-";
            iClave += pObj.CorrelativoRetiquetadoProTer;

            //retornar
            return iClave;
        }

        public static RetiquetadoProTerEN EsRetiquetadoProTerValido(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //valida cuando esta vacio
            if (pObj.ClaveRetiquetado == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRetiquetadoProTer == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = RetiquetadoProTerRN.EsRetiquetadoProTerExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RetiquetadoProTerEN EsRetiquetadoProTerActivoValido(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //valida cuando esta vacio
            if (pObj.ClaveRetiquetado == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CorrelativoRetiquetadoProTer == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = RetiquetadoProTerRN.EsRetiquetadoProTerExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            RetiquetadoProTerEN iObjDesEN = RetiquetadoProTerRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static RetiquetadoProTerEN ValidaCuandoEstaDesactivada(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //validar                 
            if (pObj.CEstadoRetiquetadoProTer == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) RetiquetadoProTer esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroRetiquetadoProTerAutogenerado(RetiquetadoProTerEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = RetiquetadoProTerRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static RetiquetadoProTerEN EsActoAdicionarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //ok          
            return iObjEN;
        }

        public static RetiquetadoProTerEN EsActoModificarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //valida cuando el codigo no existe
            iObjEN = RetiquetadoProTerRN.EsRetiquetadoProTerExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static RetiquetadoProTerEN EsActoEliminarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            //objeto resultado
            RetiquetadoProTerEN iObjEN = new RetiquetadoProTerEN();

            //valida cuando el codigo no existe
            iObjEN = RetiquetadoProTerRN.EsRetiquetadoProTerExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTerXClaveRetiquetado(RetiquetadoProTerEN pObj)
        {
            RetiquetadoProTerAD iObjAD = new RetiquetadoProTerAD();
            return iObjAD.ListarRetiquetadoProTerXClaveRetiquetado(pObj);
        }

        public static void AdicionarRetiquetadoProTer(List<RetiquetadoProTerEN> pLis, RetiquetadoProTerEN pObj)
        {
            //obtener siguiente correlativo
            pObj.CorrelativoRetiquetadoProTer = RetiquetadoProTerRN.ObtenerSiguienteCorrelativo(pLis);
            pObj.ClaveObjeto = RetiquetadoProTerRN.ObtenerClaveRetiquetadoProTer(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<RetiquetadoProTerEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "00";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoRetiquetadoProTer;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTerXClaveRetiquetado(string pClaveRetiquetado)
        {
            //asignar parametros
            RetiquetadoProTerEN iRetProTerEN = new RetiquetadoProTerEN();
            iRetProTerEN.ClaveRetiquetado = pClaveRetiquetado;
            iRetProTerEN.Adicionales.CampoOrden = RetiquetadoProTerEN.ClaRetProTer;

            //ejecutar metodo
            return ListarRetiquetadoProTerXClaveRetiquetado(iRetProTerEN);
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTerXPeriodoRetiquetado(RetiquetadoProTerEN pObj)
        {
            RetiquetadoProTerAD iProAD = new RetiquetadoProTerAD();
            return iProAD.ListarRetiquetadoProTerXPeriodoRetiquetado(pObj);
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTerXPeriodoRetiquetado(string pAño, string pCodigoMes)
        {
            //asignar parametros
            RetiquetadoProTerEN iRetEN = new RetiquetadoProTerEN();
            iRetEN.PeriodoRetiquetado = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iRetEN.Adicionales.CampoOrden = RetiquetadoProTerEN.ClaRetProTer;

            //ejecutar metodo
            return ListarRetiquetadoProTerXPeriodoRetiquetado(iRetEN);
        }

        public static List<LoteRetiquetado> ConvertirCampoDetalleCantidadesLoteALista(string pDetalleCantidadesLote)
        {
            //lista resultado
            List<LoteRetiquetado> iLisRes = new List<LoteRetiquetado>();

            //---------
            //convertir
            //---------

            //obtener la lista de cadenas que corresponden a cada liberacionProTer
            List<string> iLisLibProTer = Cadena.ListarPalabrasDeTexto(pDetalleCantidadesLote, "|");

            //recorrer cada cadena
            foreach (string xStr in iLisLibProTer)
            {
                //si la cadena esta vacia,termino el proceso
                if (xStr.Trim() == string.Empty) { break; }

                //de esta cadena, tambien sacar la lista de cadenas qque corresponden a los campos de LiberacionProTer
                List<string> iLisCamLibProTer = Cadena.ListarPalabrasDeTexto(xStr, ";");

                //creamos un nuevo objeto LiberacionProTer
                LoteRetiquetado iLotRet = new LoteRetiquetado();

                //pasamos sus datos
                iLotRet.ClaveLiberacion = iLisCamLibProTer[0];
                iLotRet.FechaLote = iLisCamLibProTer[1];
                iLotRet.FechaVcto = iLisCamLibProTer[2];
                iLotRet.Cantidad = Conversion.ADecimal(iLisCamLibProTer[3], 0);
                iLotRet.CostoTotalProducto = Conversion.ADecimal(iLisCamLibProTer[4], 0);
                if (iLisCamLibProTer.Count == 6)
                {
                    iLotRet.FechaProduccionDeta = iLisCamLibProTer[5];
                }                
                iLotRet.CorrelativoProduccionCabe = LiberacionRN.ObtenerCorrelativoProduccionCabe(iLotRet.ClaveLiberacion);

                //agregar a lista resultado
                iLisRes.Add(iLotRet);
            }

            //devolver
            return iLisRes;
        }

        public static string ConvertirListaACampoDetalleCantidadesLote(List<LoteRetiquetado> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //---------
            //convertir
            //---------

            //recorrer cada objeto
            foreach (LoteRetiquetado xLotRet in pLista)
            {
                iValor += xLotRet.ClaveLiberacion + ";";
                iValor += xLotRet.FechaLote + ";";
                iValor += xLotRet.FechaVcto + ";";
                iValor += Formato.NumeroDecimal(xLotRet.Cantidad, 2) + ";";
                iValor += Formato.NumeroDecimal(xLotRet.CostoTotalProducto, 2) + ";";
                iValor += xLotRet.FechaProduccionDeta + "|";
            }

            //devolver
            return iValor;
        }

        public static void AdicionarLoteRetiquetado(List<LoteRetiquetado> pLis, LoteRetiquetado pObj)
        {
            //pasar datos
            pObj.ClaveObjeto = pObj.ClaveLiberacion;

            //obtener siguiente correlativo            
            pLis.Add(pObj);
        }

        public static List<LiberacionProTer> ListarLiberacionesProTerDiferentesDeLoteRetiquetado(List<LiberacionProTer> pLisLibProTer,
            List<LoteRetiquetado> pLisLotRet)
        {
            //lista resultado
            List<LiberacionProTer> iLisRes = new List<LiberacionProTer>();

            //recorrer cada objeto LiberacionProTer
            foreach (LiberacionProTer xLibProTer in pLisLibProTer)
            {
                //buscar en la lista pLisLotRet
                bool iExiste = ListaG.Existe<LoteRetiquetado>(pLisLotRet, LoteRetiquetado.ClaLib, xLibProTer.ClaveLiberacion);
                if (iExiste == false)
                {
                    iLisRes.Add(xLibProTer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<LiberacionProTer> FiltrarEncajadosXTextoEnCualquierPosicion(List<LiberacionProTer> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<LiberacionProTer> iLisRes = new List<LiberacionProTer>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (LiberacionProTer xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<LiberacionProTer>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<LiberacionProTer> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<LiberacionProTer> pListaEncajados)
        {
            //lista resultado
            List<LiberacionProTer> iLisRes = new List<LiberacionProTer>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaEncajados; }

            //filtar la lista
            iLisRes = FiltrarEncajadosXTextoEnCualquierPosicion(pListaEncajados, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTerParaReporteCostoLoteEtapaRetiquetado(RetiquetadoProTerEN pObj)
        {
            RetiquetadoProTerAD iProAD = new RetiquetadoProTerAD();
            return iProAD.ListarRetiquetadoProTerParaReporteCostoLoteEtapaRetiquetado(pObj);
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTerParaReporteCostoLoteEtapaRetiquetado(RetiquetadoEN pObj)
        {
            //asignar parametros
            RetiquetadoProTerEN iRetProTerEN = new RetiquetadoProTerEN();
            iRetProTerEN.Adicionales.Desde1 = pObj.Adicionales.Desde1;
            iRetProTerEN.Adicionales.Hasta1 = pObj.Adicionales.Hasta1;
            iRetProTerEN.CodigoExistenciaRE = pObj.CodigoExistenciaRE;

            //ejecutar metodo
            return ListarRetiquetadoProTerParaReporteCostoLoteEtapaRetiquetado(iRetProTerEN);
        }

        public static List<LoteRetiquetado> ConvertirCamposDetalleCantidadesLoteRetiquetadoALista(List<RetiquetadoProTerEN> pLista)
        {
            //lista resultado
            List<LoteRetiquetado> iLisRes = new List<LoteRetiquetado>();

            //recorrer cada objeto
            foreach (RetiquetadoProTerEN xProProTer in pLista)
            {
                List<LoteRetiquetado> iLisLibProTer = ConvertirCampoDetalleCantidadesLoteALista(xProProTer.DetalleCantidadesLote);
                iLisRes.AddRange(iLisLibProTer);
            }

            //devolver
            return iLisRes;
        }

        public static List<RetiquetadoProTerEN> ListarRetiquetadoProTerDeCorrelativosProduccionCabe(List<ProduccionDetaEN> pLista)
        {
            RetiquetadoProTerAD iProAD = new RetiquetadoProTerAD();
            return iProAD.ListarRetiquetadoProTerDeCorrelativosProduccionCabe(pLista);
        }


    }
}
