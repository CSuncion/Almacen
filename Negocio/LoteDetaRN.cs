using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using System.Data;
using Entidades.Estructuras;
using System.Windows.Forms;

namespace Negocio
{
    public class LoteDetaRN
    {

        public static LoteDetaEN EnBlanco()
        {
            LoteDetaEN iExiEN = new LoteDetaEN();
            return iExiEN;
        }

        public static void AdicionarLoteDeta(LoteDetaEN pObj)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            iPerAD.AgregarLoteDeta(pObj);
        }

        public static void AdicionarLoteDeta(List< LoteDetaEN> pLista)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            iPerAD.AgregarLoteDeta(pLista);
        }

        public static void ModificarLoteDeta(LoteDetaEN pObj)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            iPerAD.ModificarLoteDeta(pObj);
        }

        public static void ModificarLoteDeta(List<LoteDetaEN> pLista)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            iPerAD.ModificarLoteDeta(pLista);
        }

        public static void EliminarLoteDeta(LoteDetaEN pObj)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            iPerAD.EliminarLoteDeta(pObj);
        }

        public static void EliminarLoteDeta(List< LoteDetaEN> pLista)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            iPerAD.EliminarLoteDeta(pLista);
        }

        public static void EliminarLoteDetaXClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            iPerAD.EliminarLoteDetaXClaveMovimientoCabe(pClaveMovimientoCabe);
        }

        public static List<LoteDetaEN> ListarLotesDeta(LoteDetaEN pObj)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            return iPerAD.ListarLotesDeta(pObj);
        }

        public static LoteDetaEN BuscarLoteDetaXClave(LoteDetaEN pObj)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            return iPerAD.BuscarLoteDetaXClave(pObj);
        }

        public static LoteDetaEN EsLoteDetaExistente(LoteDetaEN pObj)
        {
            //objeto resultado
            LoteDetaEN iExiEN = new LoteDetaEN();

            //validar si existe en b.d
            iExiEN = LoteDetaRN.BuscarLoteDetaXClave(pObj);
            if (iExiEN.ClaveLoteDeta == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El Lote Deta " + pObj.CorrelativoLoteDeta + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(LoteDetaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case LoteDetaEN.ClaObj: return pObj.ClaveObjeto;
                case LoteDetaEN.ClaLot: return pObj.ClaveLoteDeta;
                case LoteDetaEN.CodEmp: return pObj.CodigoEmpresa;
                case LoteDetaEN.CodAlm: return pObj.CodigoAlmacen;
                case LoteDetaEN.DesAlm: return pObj.DescripcionAlmacen;
                case LoteDetaEN.CodExi: return pObj.CodigoExistencia;
                case LoteDetaEN.DesExi: return pObj.DescripcionExistencia;
                case LoteDetaEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case LoteDetaEN.NomUniMed: return pObj.NombreUnidadMedida;
                case LoteDetaEN.CodLot: return pObj.CodigoLote;
                case LoteDetaEN.CorLotDet: return pObj.CorrelativoLoteDeta;
                case LoteDetaEN.CanLotDet: return pObj.CantidadLoteDeta.ToString();               
                case LoteDetaEN.StoAntLot: return pObj.StockAnteriorLote.ToString();
                case LoteDetaEN.ClaMovDet: return pObj.ClaveMovimientoDeta;
                case LoteDetaEN.ClaMovCab: return pObj.ClaveMovimientoCabe;                
                case LoteDetaEN.UsuAgr: return pObj.UsuarioAgrega;
                case LoteDetaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case LoteDetaEN.UsuMod: return pObj.UsuarioModifica;
                case LoteDetaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<LoteDetaEN> FiltrarLoteDetasXTextoEnCualquierPosicion(List<LoteDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<LoteDetaEN> iLisRes = new List<LoteDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (LoteDetaEN xPer in pLista)
            {
                string iTexto = LoteDetaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<LoteDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<LoteDetaEN> pListaLoteDetas)
        {
            //lista resultado
            List<LoteDetaEN> iLisRes = new List<LoteDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaLoteDetas; }

            //filtar la lista
            iLisRes = LoteDetaRN.FiltrarLoteDetasXTextoEnCualquierPosicion(pListaLoteDetas, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveLoteDeta(LoteDetaEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoExistencia + "-";
            iClave += pObj.CodigoLote + "-";
            iClave += pObj.CorrelativoLoteDeta;
            
            //retornar
            return iClave;
        }

        public static LoteDetaEN EsActoModificarLoteDeta(LoteDetaEN pObj)
        {
            //objeto resultado
            LoteDetaEN iExiEN = new LoteDetaEN();

            //validar si existe
            iExiEN = LoteDetaRN.EsLoteDetaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }
            
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static LoteDetaEN EsActoEliminarLoteDeta(LoteDetaEN pObj)
        {
            //objeto resultado
            LoteDetaEN iExiEN = new LoteDetaEN();

            //validar si existe
            iExiEN = LoteDetaRN.EsLoteDetaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok            
            return iExiEN;
        }

        public static List<LoteDetaEN> ListarLotesDetaDeClaveMovimientoCabe(LoteDetaEN pObj)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            return iPerAD.ListarLotesDetaDeClaveMovimientoCabe(pObj);
        }

        public static List<LoteDetaEN> ListarLotesDetaDeClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            //asignar parametros
            LoteDetaEN iLotDetEN = new LoteDetaEN();
            iLotDetEN.ClaveMovimientoCabe = pClaveMovimientoCabe;
            iLotDetEN.Adicionales.CampoOrden = LoteDetaEN.ClaLot;

            //ejecutar metodo
            return LoteDetaRN.ListarLotesDetaDeClaveMovimientoCabe(iLotDetEN);
        }

        public static void ModificarVerdadFalsoLoteDeta(LoteDetaEN pObj, List<LoteDetaEN> pLista)
        {
            //lista actualizada
            List<LoteDetaEN> iLisExi = new List<LoteDetaEN>();

            //buscamos el objeto en la lista pLista
            foreach (LoteDetaEN xExi in pLista)
            {
                if (xExi.ClaveLoteDeta == pObj.ClaveLoteDeta)
                {
                    xExi.VerdadFalso = pObj.VerdadFalso;
                }
                iLisExi.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisExi);
        }

        public static List<LoteDetaEN> ListarLoteDetasSoloMarcadas(List<LoteDetaEN> pLista)
        {
            //lista resultado
            List<LoteDetaEN> iLisRes = new List<LoteDetaEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (LoteDetaEN xExi in pLista)
            {
                if (xExi.VerdadFalso == true)
                {
                    iLisRes.Add(xExi);
                }
            }
            return iLisRes;
        }

        public static LoteDetaEN HayObjetosMarcados(List<LoteDetaEN> pLista)
        {
            //objeto resultado
            LoteDetaEN iExiEN = new LoteDetaEN();

            //sacar las cuotas solo marcadas
            List<LoteDetaEN> iLisExiMar = LoteDetaRN.ListarLoteDetasSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisExiMar.Count == 0)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "No hay LoteDetas marcados, no se puede realizar la operacion";
                return iExiEN;
            }
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static bool ExisteCodigoLoteDetaEnLista(string pCorrelativoLoteDeta,List<LoteDetaEN> pLista)
        {
            //recorrer cada objeto
            foreach (LoteDetaEN xExi in pLista)
            {
                if (pCorrelativoLoteDeta == xExi.CorrelativoLoteDeta)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static void MarcarTodos( List<LoteDetaEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<LoteDetaEN> iLisExi = new List<LoteDetaEN>();

            //buscamos el objeto en la lista pLista
            foreach (LoteDetaEN xExi in pLista)
            {
                xExi.VerdadFalso = pVerdadFalso;
                iLisExi.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisExi);
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteClaveLoteDetaEnLista(string pClaveLoteDeta, List<LoteDetaEN> pLista)
        {
            //recorrer cada objeto
            foreach (LoteDetaEN xExi in pLista)
            {
                if (pClaveLoteDeta == xExi.ClaveLoteDeta)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static LoteDetaEN BuscarLoteDetaXClave(string pClaveLoteDeta, List<LoteDetaEN> pLista)
        {
            //objeto resultaddo
            LoteDetaEN iExiEN = new LoteDetaEN();

            //recorrer cada objeto
            foreach (LoteDetaEN xExi in pLista)
            {
                if (pClaveLoteDeta == xExi.ClaveLoteDeta)
                {
                    return xExi;
                }
            }

            //devolver
            return iExiEN;
        }

        public static List<LoteDetaEN> ObtenerAInterseccionB(List<LoteDetaEN> pLisExiA, List<LoteDetaEN> pLisExiB)
        {
            //lista resultado
            List<LoteDetaEN> iLisRes = new List<LoteDetaEN>();

            //recorrer cada objeto
            foreach (LoteDetaEN xExiA in pLisExiA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (LoteDetaEN xExiB in pLisExiB)
                {
                    if (xExiA.CorrelativoLoteDeta == xExiB.CorrelativoLoteDeta)
                    {
                        iEncontrado = 1;
                    }
                }

                //si no se encontro se agrega a la lista resultado
                if (iEncontrado == 1)
                {
                    iLisRes.Add(xExiA);
                }
            }

            //devolver
            return iLisRes;
        }
               
        public static void AdicionarLoteDeta(List<LoteDetaEN> pLis, LoteDetaEN pObj)
        {
            //obtener siguiente correlativo          
            pObj.ClaveObjeto = LoteDetaRN.ObtenerClaveLoteDeta(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<LoteDetaEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "0000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoLoteDeta;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static List<LoteDetaEN> FiltrarLoteDetas(List<LoteDetaEN> pLista, string pCampoFiltro, string pValorFiltro)
        {
            //lista resultado
            List<LoteDetaEN> iLisRes = new List<LoteDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorFiltro.ToUpper();

            //recorrer cada objeto
            foreach (LoteDetaEN xPer in pLista)
            {
                string iTexto = LoteDetaRN.ObtenerValorDeCampo(xPer, pCampoFiltro).ToUpper();
                if (iTexto == iValor)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerMaximoValorEnColumna(LoteDetaEN pObj)
        {
            LoteDetaAD iCliAD = new LoteDetaAD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoCodigoLoteDetaAutogenerado(LoteDetaEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = LoteDetaRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 4);

            //devuelve
            return iNumero;
        }

        public static string ObtenerNuevoCodigoLoteDetaAutogenerado(LoteDetaEN pObj, List<LoteDetaEN> pLista)
        {
            //---------------------------
            //esta funcion primero busca el ultimo codigoLoteDeta en la lista, sino hay entonces pasa a buscar
            //en la b.d
            //---------------------------

            //filtrar esta lista con solo los LoteDetas de la existencia que se esta operando
            List<LoteDetaEN> iLisLoteDetaxi = LoteDetaRN.FiltrarLoteDetas(pLista, LoteDetaEN.CodExi, pObj.CodigoExistencia);

            //si la lista esta vacia entonces se busca el codigoLoteDeta en b.d
            if (iLisLoteDetaxi.Count == 0)
            {
                return LoteDetaRN.ObtenerNuevoCodigoLoteDetaAutogenerado(pObj);
            }
            else
            {
                return LoteDetaRN.ObtenerSiguienteCorrelativo(iLisLoteDetaxi);
            }
        }

        public static void ModificarLoteDeta(List<LoteDetaEN> pLis, LoteDetaEN pObj)
        {
            //recorrer cada objeto
            foreach (LoteDetaEN xLot in pLis)
            {
                if (xLot.ClaveLoteDeta == pObj.ClaveLoteDeta)
                {
                    xLot.CantidadLoteDeta = pObj.CantidadLoteDeta;                   
                }
            }
        }

        public static void EliminarLoteDeta(List<LoteDetaEN> pLis, LoteDetaEN pObj)
        {
            //lista sin el objeto a eliminar
            List<LoteDetaEN> iLisLoteDetali = new List<LoteDetaEN>();

            //recorrer cada objeto
            foreach (LoteDetaEN xLot in pLis)
            {
                if (xLot.ClaveLoteDeta != pObj.ClaveLoteDeta)
                {
                    iLisLoteDetali.Add(xLot);
                }
            }

            //limpiar la lista original
            pLis.Clear();

            //pasar la lista actualizada
            pLis.AddRange(iLisLoteDetali);
        }

        public static void EliminarLoteDeta(List<LoteDetaEN> pLis, string pCodigoExistencia)
        {
            //lista sin el objeto a eliminar
            List<LoteDetaEN> iLisLoteDetali = new List<LoteDetaEN>();

            //recorrer cada objeto
            foreach (LoteDetaEN xLot in pLis)
            {
                if (xLot.CodigoExistencia != pCodigoExistencia)
                {
                    iLisLoteDetali.Add(xLot);
                }
            }

            //limpiar la lista original
            pLis.Clear();

            //pasar la lista actualizada
            pLis.AddRange(iLisLoteDetali);
        }

        public static void AdicionarLoteDeta(List<MovimientoDetaEN> pLisMovDet)
        {
            //filtramos esta lista de movimientos deta,con solo los que permitan manejo de lotes
            List<MovimientoDetaEN> iLisMovDetLot = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CEsLot, "1");
            
            //valida cuando la lista esta vacia
            if (iLisMovDetLot.Count == 0) { return; }
           
            //listar listas los lotes con saldo de todas las existencias que manejen lotes
            List<List<LoteEN>> iLisLisLot = LoteRN.ListarListasDeLotesConSaldoPorExistencia(iLisMovDetLot);
            
            //listas para adicionar y modificar en bd
            List<LoteEN> iLisLotMod = new List<LoteEN>();
            List<LoteDetaEN> iLisLotAdi = new List<LoteDetaEN>();

            //recorrer cada MovimientoDetaEN
            foreach (MovimientoDetaEN xMovDet in iLisMovDetLot)
            {
                //obtener la lista de lotes para la existencia de este MovimientoDeta
                List<LoteEN> iLisLotExi = ListaG.Buscar<LoteEN>(iLisLisLot, LoteEN.CodExi, xMovDet.CodigoExistencia);

                //cantidad a salir
                decimal iCantidadASalir = xMovDet.CantidadMovimientoDeta;

                //recorrer cada lote
                foreach (LoteEN xLot in iLisLotExi)
                {
                    //si la cantidad a salir es cero, entonces salir del foreach
                    if (iCantidadASalir == 0) { break; }

                    //creamos un nuevo objeto LoteDeta para este lote
                    LoteDetaEN iLotDetNueEN = LoteDetaRN.CrearNuevoLoteDeta(xLot);

                    //si la cantidad a salir es menor,entonces termina la salida de los lotes
                    if (iCantidadASalir < xLot.StockSaldoLote)
                    {
                        //actualizamos la cantidad del nuevo LoteDeta
                        iLotDetNueEN.CantidadLoteDeta = iCantidadASalir;

                        //actualizamos el lote
                        xLot.StockSaldoLote -= iCantidadASalir;
                        
                        //ya no hay cantidad a salir
                        iCantidadASalir = 0;
                    }
                    else
                    {
                        //actualizamos la cantidad del nuevo LoteDeta
                        iLotDetNueEN.CantidadLoteDeta = xLot.StockSaldoLote;

                        //actualizamos el lote
                        xLot.StockSaldoLote = 0;
                        
                        //restamos
                        iCantidadASalir -= iLotDetNueEN.CantidadLoteDeta;
                    }

                    //actualizar el lote
                    xLot.UltimoCorrelativoLoteDeta = iLotDetNueEN.CorrelativoLoteDeta;

                    //actualizar el lotedeta
                    iLotDetNueEN.ClaveMovimientoCabe = xMovDet.ClaveMovimientoCabe;
                    iLotDetNueEN.ClaveMovimientoDeta = xMovDet.ClaveMovimientoDeta;

                    //adicionar a las listas
                    iLisLotAdi.Add(iLotDetNueEN);
                    iLisLotMod.Add(xLot);
                }
            }

            //adicionar masivo
            LoteDetaRN.AdicionarLoteDeta(iLisLotAdi);

            //modificar masivo
            LoteRN.ModificarLote(iLisLotMod);
        }

        public static void AdicionarLoteDetaOC(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //filtramos esta lista de movimientos deta,con solo los que permitan manejo de lotes
            List<MovimientoOCDetaEN> iLisMovDetLot = ListaG.Filtrar<MovimientoOCDetaEN>(pLisMovDet, MovimientoOCDetaEN.CEsLot, "1");

            //valida cuando la lista esta vacia
            if (iLisMovDetLot.Count == 0) { return; }

            //listar listas los lotes con saldo de todas las existencias que manejen lotes
            List<List<LoteEN>> iLisLisLot = LoteRN.ListarListasDeLotesConSaldoPorExistenciaOC(iLisMovDetLot);

            //listas para adicionar y modificar en bd
            List<LoteEN> iLisLotMod = new List<LoteEN>();
            List<LoteDetaEN> iLisLotAdi = new List<LoteDetaEN>();

            //recorrer cada MovimientoDetaEN
            foreach (MovimientoOCDetaEN xMovDet in iLisMovDetLot)
            {
                //obtener la lista de lotes para la existencia de este MovimientoDeta
                List<LoteEN> iLisLotExi = ListaG.Buscar<LoteEN>(iLisLisLot, LoteEN.CodExi, xMovDet.CodigoExistencia);

                //cantidad a salir
                decimal iCantidadASalir = xMovDet.CantidadMovimientoDeta;

                //recorrer cada lote
                foreach (LoteEN xLot in iLisLotExi)
                {
                    //si la cantidad a salir es cero, entonces salir del foreach
                    if (iCantidadASalir == 0) { break; }

                    //creamos un nuevo objeto LoteDeta para este lote
                    LoteDetaEN iLotDetNueEN = LoteDetaRN.CrearNuevoLoteDeta(xLot);

                    //si la cantidad a salir es menor,entonces termina la salida de los lotes
                    if (iCantidadASalir < xLot.StockSaldoLote)
                    {
                        //actualizamos la cantidad del nuevo LoteDeta
                        iLotDetNueEN.CantidadLoteDeta = iCantidadASalir;

                        //actualizamos el lote
                        xLot.StockSaldoLote -= iCantidadASalir;

                        //ya no hay cantidad a salir
                        iCantidadASalir = 0;
                    }
                    else
                    {
                        //actualizamos la cantidad del nuevo LoteDeta
                        iLotDetNueEN.CantidadLoteDeta = xLot.StockSaldoLote;

                        //actualizamos el lote
                        xLot.StockSaldoLote = 0;

                        //restamos
                        iCantidadASalir -= iLotDetNueEN.CantidadLoteDeta;
                    }

                    //actualizar el lote
                    xLot.UltimoCorrelativoLoteDeta = iLotDetNueEN.CorrelativoLoteDeta;

                    //actualizar el lotedeta
                    iLotDetNueEN.ClaveMovimientoCabe = xMovDet.ClaveMovimientoCabe;
                    iLotDetNueEN.ClaveMovimientoDeta = xMovDet.ClaveMovimientoDeta;

                    //adicionar a las listas
                    iLisLotAdi.Add(iLotDetNueEN);
                    iLisLotMod.Add(xLot);
                }
            }

            //adicionar masivo
            LoteDetaRN.AdicionarLoteDeta(iLisLotAdi);

            //modificar masivo
            LoteRN.ModificarLote(iLisLotMod);
        }

        public static LoteDetaEN CrearNuevoLoteDeta(LoteEN pObj)
        {
            //objeto resultado
            LoteDetaEN iLotDetEN = new LoteDetaEN();

            //pasamos datos
            iLotDetEN.ClaveLote = pObj.ClaveLote;
            iLotDetEN.CodigoEmpresa = pObj.CodigoEmpresa;
            iLotDetEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iLotDetEN.CodigoExistencia = pObj.CodigoExistencia;
            iLotDetEN.CodigoLote = pObj.CodigoLote;
            iLotDetEN.CorrelativoLoteDeta = Numero.IncrementarCorrelativoNumerico(pObj.UltimoCorrelativoLoteDeta, 4);
            iLotDetEN.CantidadLoteDeta = pObj.StockSaldoLote;
            iLotDetEN.StockAnteriorLote = pObj.StockSaldoLote;
            iLotDetEN.ClaveLoteDeta = LoteDetaRN.ObtenerClaveLoteDeta(iLotDetEN);

            //devolver
            return iLotDetEN;
        }

        public static void EliminarLoteDeta(string pClaveMovimientoCabe)
        {
            //traer todos los LotesDeta de este movimiento
            List<LoteDetaEN> iLisLotDet = LoteDetaRN.ListarLotesDetaDeClaveMovimientoCabe(pClaveMovimientoCabe);

            //traer a todos los lotes que intervienen en este movimiento
            List<LoteEN> iLisLot = LoteRN.ListarLotes(iLisLotDet);

            //recorrer cada lote
            foreach (LoteEN xLot in iLisLot)
            {
                //buscar el lotedeta de este lote
                LoteDetaEN iLotDetBusEN = ListaG.Buscar<LoteDetaEN>(iLisLotDet, LoteDetaEN.ClaLot, xLot.ClaveLote);

                //actualizar el lote
                xLot.StockSaldoLote = iLotDetBusEN.StockAnteriorLote;
                xLot.UltimoCorrelativoLoteDeta = Numero.DisminuirCorrelativoNumerico(iLotDetBusEN.CorrelativoLoteDeta);
            }

            //eliminar masivo
            LoteDetaRN.EliminarLoteDeta(iLisLotDet);

            //modificar masivo
            LoteRN.ModificarLote(iLisLot);
        }

        public static List<List<LoteDetaEN>> ListarListasLoteDetaDeClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            //asignar parametros
            List<LoteDetaEN> iLisLotDet = LoteDetaRN.ListarLotesDetaDeClaveMovimientoCabe(pClaveMovimientoCabe);

            //ejecutar metodo
            return ListaG.ListarListas<LoteDetaEN>(iLisLotDet, LoteDetaEN.CodExi);
        }

        public static List<LoteDetaEN> ListarLotesDetaParaRecalculo(string pStrEmpresaPeriodo)
        {
            LoteDetaAD iPerAD = new LoteDetaAD();
            return iPerAD.ListarLotesDetaParaRecalculo(pStrEmpresaPeriodo);
        }

    }
}
