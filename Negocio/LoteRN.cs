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

namespace Negocio
{
    public class LoteRN
    {

        public static LoteEN EnBlanco()
        {
            LoteEN iExiEN = new LoteEN();
            return iExiEN;
        }

        public static void AdicionarLote(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            iPerAD.AgregarLote(pObj);
        }

        public static void AdicionarLote(List< LoteEN> pLista)
        {
            LoteAD iPerAD = new LoteAD();
            iPerAD.AgregarLote(pLista);
        }

        public static void ModificarLote(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            iPerAD.ModificarLote(pObj);
        }

        public static void ModificarLote(List<LoteEN> pLista)
        {
            LoteAD iPerAD = new LoteAD();
            iPerAD.ModificarLote(pLista);
        }

        public static void EliminarLote(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            iPerAD.EliminarLote(pObj);
        }

        public static void EliminarLote(List< LoteEN> pLista)
        {
            LoteAD iPerAD = new LoteAD();
            iPerAD.EliminarLote(pLista);
        }

        public static void EliminarLoteXClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            LoteAD iPerAD = new LoteAD();
            iPerAD.EliminarLoteXClaveMovimientoCabe(pClaveMovimientoCabe);
        }

        public static List<LoteEN> ListarLotes(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ListarLotes(pObj);
        }

        public static List<LoteEN> ListarLotes()
        {
            //asignar parametros
            LoteEN iExiEN = new LoteEN();
            iExiEN.Adicionales.CampoOrden = LoteEN.ClaLot;

            //ejecutar metodo
            return LoteRN.ListarLotes(iExiEN);
        }

        public static LoteEN BuscarLoteXClave(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.BuscarLoteXClave(pObj);
        }

        public static LoteEN EsLoteExistente(LoteEN pObj)
        {
            //objeto resultado
            LoteEN iExiEN = new LoteEN();

            //validar si existe en b.d
            iExiEN = LoteRN.BuscarLoteXClave(pObj);
            if (iExiEN.ClaveLote == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El lote " + pObj.CodigoLote + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static LoteEN EsCodigoLoteDisponible(LoteEN pObj)
        {
            //objeto resultado
            LoteEN iExiEN = new LoteEN();

            //valida cuando esta vacio
            if (pObj.CodigoLote == string.Empty) { return iExiEN; }

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iExiEN; }

            //validar que los dos campos esten llenos
            iExiEN = LoteRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok           
            return iExiEN;
        }

        public static LoteEN ValidaCuandoCodigoYaExiste(LoteEN pObj)
        {
            //objeto resultado
            LoteEN iExiEN = new LoteEN();

            //validar     
            iExiEN = LoteRN.BuscarLoteXClave(pObj);
            if (iExiEN.CodigoLote != string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo lote " + pObj.CodigoLote + " ya existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(LoteEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case LoteEN.ClaObj: return pObj.ClaveObjeto;
                case LoteEN.ClaLot: return pObj.ClaveLote;
                case LoteEN.CodEmp: return pObj.CodigoEmpresa;
                case LoteEN.CodAlm: return pObj.CodigoAlmacen;
                case LoteEN.DesAlm: return pObj.DescripcionAlmacen;
                case LoteEN.CodExi: return pObj.CodigoExistencia;
                case LoteEN.DesExi: return pObj.DescripcionExistencia;
                case LoteEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case LoteEN.NomUniMed: return pObj.NombreUnidadMedida;
                case LoteEN.CodLot: return pObj.CodigoLote;
                case LoteEN.FecVenLot: return pObj.FechaVencimientoLote;               
                case LoteEN.StoLot: return pObj.StockLote.ToString();
                case LoteEN.StoSalLot: return pObj.StockSaldoLote.ToString();
                case LoteEN.ClaMovDet: return pObj.ClaveMovimientoDeta;
                case LoteEN.ClaMovCab: return pObj.ClaveMovimientoCabe;
                case LoteEN.CEstLot: return pObj.CEstadoLote;
                case LoteEN.NEstLot: return pObj.CodigoLote;
                case LoteEN.UsuAgr: return pObj.UsuarioAgrega;
                case LoteEN.FecAgr: return pObj.FechaAgrega.ToString();
                case LoteEN.UsuMod: return pObj.UsuarioModifica;
                case LoteEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<LoteEN> FiltrarLotesXTextoEnCualquierPosicion(List<LoteEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<LoteEN> iLisRes = new List<LoteEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (LoteEN xPer in pLista)
            {
                string iTexto = LoteRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<LoteEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<LoteEN> pListaLotes)
        {
            //lista resultado
            List<LoteEN> iLisRes = new List<LoteEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaLotes; }

            //filtar la lista
            iLisRes = LoteRN.FiltrarLotesXTextoEnCualquierPosicion(pListaLotes, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveLote(LoteEN pObj)
        {
            //asignar parametros
            List<string> iLista = new List<string>();
            iLista.Add(Universal.gCodigoEmpresa);
            iLista.Add(pObj.CodigoAlmacen);
            iLista.Add(pObj.CodigoExistencia);
            iLista.Add(pObj.CodigoLote);
            string iCaracterSeparador = "-";

            //ejecutar metodo
            return Cadena.ConcatenarTexto(iLista, iCaracterSeparador);            
        }

        public static LoteEN EsActoModificarLote(LoteEN pObj)
        {
            //objeto resultado
            LoteEN iExiEN = new LoteEN();

            //validar si existe
            iExiEN = LoteRN.EsLoteExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }
            
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static LoteEN EsActoEliminarLote(LoteEN pObj)
        {
            //objeto resultado
            LoteEN iExiEN = new LoteEN();

            //validar si existe
            iExiEN = LoteRN.EsLoteExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok            
            return iExiEN;
        }

        public static List<LoteEN> ListarLotesDeAlmacen(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ListarLotesDeAlmacen(pObj);
        }

        public static List<LoteEN> ListarLotesDeAlmacen(string pCodigoAlmacen)
        {
            //asignar parametros
            LoteEN iExiEN = new LoteEN();
            iExiEN.CodigoAlmacen = pCodigoAlmacen;
            iExiEN.Adicionales.CampoOrden = LoteEN.ClaLot;

            //ejecutar metodo
            return LoteRN.ListarLotesDeAlmacen(iExiEN);
        }

        public static LoteEN EsLoteValido(LoteEN pObj)
        {
            //objeto resultado
            LoteEN iExiEN = new LoteEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoLote == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = LoteRN.EsLoteExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok           
            return iExiEN;
        }

        public static void ModificarVerdadFalsoLote(LoteEN pObj, List<LoteEN> pLista)
        {
            //lista actualizada
            List<LoteEN> iLisExi = new List<LoteEN>();

            //buscamos el objeto en la lista pLista
            foreach (LoteEN xExi in pLista)
            {
                if (xExi.ClaveLote == pObj.ClaveLote)
                {
                    xExi.VerdadFalso = pObj.VerdadFalso;
                }
                iLisExi.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisExi);
        }

        public static List<LoteEN> ListarLotesSoloMarcadas(List<LoteEN> pLista)
        {
            //lista resultado
            List<LoteEN> iLisRes = new List<LoteEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (LoteEN xExi in pLista)
            {
                if (xExi.VerdadFalso == true)
                {
                    iLisRes.Add(xExi);
                }
            }
            return iLisRes;
        }

        public static LoteEN HayObjetosMarcados(List<LoteEN> pLista)
        {
            //objeto resultado
            LoteEN iExiEN = new LoteEN();

            //sacar las cuotas solo marcadas
            List<LoteEN> iLisExiMar = LoteRN.ListarLotesSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisExiMar.Count == 0)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "No hay Lotes marcados, no se puede realizar la operacion";
                return iExiEN;
            }
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static bool ExisteCodigoLoteEnLista(string pCodigoLote,List<LoteEN> pLista)
        {
            //recorrer cada objeto
            foreach (LoteEN xExi in pLista)
            {
                if (pCodigoLote == xExi.CodigoLote)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static void MarcarTodos( List<LoteEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<LoteEN> iLisExi = new List<LoteEN>();

            //buscamos el objeto en la lista pLista
            foreach (LoteEN xExi in pLista)
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
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteClaveLoteEnLista(string pClaveLote, List<LoteEN> pLista)
        {
            //recorrer cada objeto
            foreach (LoteEN xExi in pLista)
            {
                if (pClaveLote == xExi.ClaveLote)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static LoteEN BuscarLoteXClave(string pClaveLote, List<LoteEN> pLista)
        {
            //objeto resultaddo
            LoteEN iExiEN = new LoteEN();

            //recorrer cada objeto
            foreach (LoteEN xExi in pLista)
            {
                if (pClaveLote == xExi.ClaveLote)
                {
                    return xExi;
                }
            }

            //devolver
            return iExiEN;
        }

        public static List<LoteEN> ObtenerAInterseccionB(List<LoteEN> pLisExiA, List<LoteEN> pLisExiB)
        {
            //lista resultado
            List<LoteEN> iLisRes = new List<LoteEN>();

            //recorrer cada objeto
            foreach (LoteEN xExiA in pLisExiA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (LoteEN xExiB in pLisExiB)
                {
                    if (xExiA.CodigoLote == xExiB.CodigoLote)
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
           
        public static LoteEN ValidaCuandoEstaDesactivada(LoteEN pObj)
        {
            //objeto resultado
            LoteEN iExiEN = new LoteEN();

            //validar                 
            if (pObj.CEstadoLote == "0")//desactivado
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "La Lote esta desactivada";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void AdicionarLote(List<LoteEN> pLis, LoteEN pObj)
        {
            //obtener siguiente correlativo          
            pObj.ClaveObjeto = LoteRN.ObtenerClaveLote(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<LoteEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "000000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CodigoLote;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static List<LoteEN> FiltrarLotes(List<LoteEN> pLista, string pCampoFiltro, string pValorFiltro)
        {
            //lista resultado
            List<LoteEN> iLisRes = new List<LoteEN>();

            //valor busqueda en mayuscula
            string iValor = pValorFiltro.ToUpper();

            //recorrer cada objeto
            foreach (LoteEN xPer in pLista)
            {
                string iTexto = LoteRN.ObtenerValorDeCampo(xPer, pCampoFiltro).ToUpper();
                if (iTexto == iValor)
                {
                    iLisRes.Add(LoteRN.Clonar(xPer));
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerMaximoValorEnColumna(LoteEN pObj)
        {
            LoteAD iCliAD = new LoteAD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoCodigoLoteAutogenerado(LoteEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = LoteRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static string ObtenerMaximoValorEnColumna(string pCodigoAlmacen,string pCodigoExistencia)
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            iLotEN.CodigoAlmacen = pCodigoAlmacen;
            iLotEN.CodigoExistencia = pCodigoExistencia;

            //ejecutar metodo
            return LoteRN.ObtenerMaximoValorEnColumna(iLotEN);
        }

        public static string ObtenerNuevoCodigoLoteAutogenerado(LoteEN pObj, List<LoteEN> pLista)
        {
            //---------------------------
            //esta funcion primero busca el ultimo codigoLote en la lista, sino hay entonces pasa a buscar
            //en la b.d
            //---------------------------

            //filtrar esta lista con solo los lotes de la existencia que se esta operando
            List<LoteEN> iLisLotExi = LoteRN.FiltrarLotes(pLista, LoteEN.CodExi, pObj.CodigoExistencia);

            //si la lista esta vacia entonces se busca el codigoLote en b.d
            if (iLisLotExi.Count == 0)
            {
                return LoteRN.ObtenerNuevoCodigoLoteAutogenerado(pObj);
            }
            else
            {
                return LoteRN.ObtenerSiguienteCorrelativo(iLisLotExi);
            }
        }

        public static void ModificarLote(List<LoteEN> pLis, LoteEN pObj)
        {
            //recorrer cada objeto
            foreach (LoteEN xLot in pLis)
            {
                if (xLot.ClaveLote == pObj.ClaveLote)
                {
                    xLot.FechaVencimientoLote = pObj.FechaVencimientoLote;
                    xLot.FechaProduccionLote = pObj.FechaProduccionLote;
                    xLot.NumeroLote = pObj.NumeroLote;
                    xLot.StockLote = pObj.StockLote;
                    xLot.StockSaldoLote = pObj.StockLote;
                }
            }
        }

        public static void EliminarLote(List<LoteEN> pLis, LoteEN pObj)
        {
            //lista sin el objeto a eliminar
            List<LoteEN> iLisLotEli = new List<LoteEN>();

            //recorrer cada objeto
            foreach (LoteEN xLot in pLis)
            {
                if (xLot.ClaveLote != pObj.ClaveLote)
                {
                    iLisLotEli.Add(xLot);
                }
            }

            //limpiar la lista original
            pLis.Clear();

            //pasar la lista actualizada
            pLis.AddRange(iLisLotEli);
        }

        public static void EliminarLote(List<LoteEN> pLis, string pCodigoExistencia)
        {
            //lista sin el objeto a eliminar
            List<LoteEN> iLisLotEli = new List<LoteEN>();

            //recorrer cada objeto
            foreach (LoteEN xLot in pLis)
            {
                if (xLot.CodigoExistencia != pCodigoExistencia)
                {
                    iLisLotEli.Add(xLot);
                }
            }

            //limpiar la lista original
            pLis.Clear();

            //pasar la lista actualizada
            pLis.AddRange(iLisLotEli);
        }

        public static List<LoteEN> ListarLotesDeClaveMovimientoCabe(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ListarLotesDeClaveMovimientoCabe(pObj);
        }

        public static List<List<LoteEN>> ListarListasDeLotesConSaldoPorExistencia(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ListarListasDeLotesConSaldoPorExistencia(pObj);
        }

        public static List<List<LoteEN>> ListarListasDeLotesConSaldoPorExistencia(List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<List<LoteEN>> iLisRes = new List<List<LoteEN>>();

            //valida cuando la lista esta vacia
            if (pLisMovDet.Count == 0) { return iLisRes; }

            //valida que no hay existencias que manejen lotes
            List<MovimientoDetaEN> iLisMovDetLot = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CEsLot, "1");
            if (iLisMovDetLot.Count == 0) { return iLisRes; }
                        
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            iLotEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iLotEN.CodigoAlmacen = iLisMovDetLot[0].CodigoAlmacen;
            iLotEN.CodigoExistencia = MovimientoDetaRN.CadenaCodigosExistenciasParaIN(iLisMovDetLot);

            //ejecutar metodo
            iLisRes = LoteRN.ListarListasDeLotesConSaldoPorExistencia(iLotEN);

            //devolver
            return iLisRes;
        }

        public static List<List<LoteEN>> ListarListasDeLotesConSaldoPorExistenciaOC(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<List<LoteEN>> iLisRes = new List<List<LoteEN>>();

            //valida cuando la lista esta vacia
            if (pLisMovDet.Count == 0) { return iLisRes; }

            //valida que no hay existencias que manejen lotes
            List<MovimientoOCDetaEN> iLisMovDetLot = ListaG.Filtrar<MovimientoOCDetaEN>(pLisMovDet, MovimientoOCDetaEN.CEsLot, "1");
            if (iLisMovDetLot.Count == 0) { return iLisRes; }

            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            iLotEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iLotEN.CodigoAlmacen = iLisMovDetLot[0].CodigoAlmacen;
            iLotEN.CodigoExistencia = MovimientoOCDetaRN.CadenaCodigosExistenciasParaIN(iLisMovDetLot);

            //ejecutar metodo
            iLisRes = LoteRN.ListarListasDeLotesConSaldoPorExistencia(iLotEN);

            //devolver
            return iLisRes;
        }

        public static List<LoteEN> ListarLotesDeClavesLote(LoteEN pObj)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ListarLotesDeClavesLote(pObj);
        }

        public static List<LoteEN> ListarLotes(List<LoteDetaEN> pLisLotDet)
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            iLotEN.ClaveLote = ListaG.ArmarCadenaParaIN<LoteDetaEN>(pLisLotDet, LoteDetaEN.ClaLot);
            iLotEN.Adicionales.CampoOrden = LoteEN.ClaLot;

            //ejecutar metodo
            return LoteRN.ListarLotesDeClavesLote(iLotEN);
        }

        public static void AdicionarLotes(string pCodigoAlmacenIngreso, string pClaveMovimientoCabeIngreso, string pClaveMovimientoCabeSalida)
        {
            //esta funcion se usa por transferencia de almacenes
            //traemos a todos los lotesDeta que se crearon en el movimiento de salida
            List<List<LoteDetaEN>> iLisLisLotDet = LoteDetaRN.ListarListasLoteDetaDeClaveMovimientoCabe(pClaveMovimientoCabeSalida);

            //lista para adicionar
            List<LoteEN> iLisLotAdi = new List<LoteEN>();

            //recorrer cada lista
            foreach (List<LoteDetaEN> xLisLotDet in iLisLisLotDet)
            {
                //obtener el ultimo codigoLote que hay en b.d para esta existencia
                string iUltimoCodigoLote = LoteRN.ObtenerMaximoValorEnColumna(pCodigoAlmacenIngreso, xLisLotDet[0].CodigoExistencia);

                //recorrer cada objeto
                foreach (LoteDetaEN xLotDet in xLisLotDet)
                {
                    //aumentar el codigolote
                    iUltimoCodigoLote = Numero.IncrementarCorrelativoNumerico(iUltimoCodigoLote, 6);

                    //creamos un nuevo lote apartir de loteDeta
                    LoteEN iLotEN = new LoteEN();

                    //pasamos datos
                    iLotEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iLotEN.CodigoAlmacen = pCodigoAlmacenIngreso;
                    iLotEN.CodigoExistencia = xLotDet.CodigoExistencia;                   
                    iLotEN.CodigoLote = iUltimoCodigoLote;
                    iLotEN.FechaVencimientoLote = xLotDet.FechaVencimientoLote;
                    iLotEN.StockLote = xLotDet.CantidadLoteDeta;
                    iLotEN.StockSaldoLote = xLotDet.CantidadLoteDeta;
                    iLotEN.ClaveMovimientoCabe = pClaveMovimientoCabeIngreso;
                    iLotEN.ClaveLote = LoteRN.ObtenerClaveLote(iLotEN);

                    //agregar a la lista
                    iLisLotAdi.Add(iLotEN);
                }
            }

            //adicionar masivo
            LoteRN.AdicionarLote(iLisLotAdi);
        }

        public static void EliminarLotesAlCerrarVentanaMovimientoDeta(MovimientoDetaEN pMovDet, List<MovimientoDetaEN> pLisMovDet,
            List<LoteEN> pLisLot)
        {
            //si no hay existencia digitada,entonces termina el proceso
            if (pMovDet.CodigoExistencia == string.Empty) { return; }
            
            //buscar que la existencia digitada en la ventana, no se encuentre en la lista de movimientosDeta
            bool iExiste = ListaG.Existe<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodExi, pMovDet.CodigoExistencia);

            //si no existe, entonces eliminamos todos los lotes de esta existencia
            if (iExiste == false)
            {
                //aqui la lista solo se filtra quitando a los lotes que tienen el codigo existencia digitado
                pLisLot = ListaG.FiltrarExcepto<LoteEN>(pLisLot, LoteEN.CodExi, pMovDet.CodigoExistencia);
            }
            else
            {
                //buscar el movimientoDeta en la lista pLisMovDet
                MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodExi,
                    pMovDet.CodigoExistencia);

                //lista lotes solo de la existencia en proceso
                List<LoteEN> iLisLotExi = ListaG.Filtrar<LoteEN>(pLisLot, LoteEN.CodExi, pMovDet.CodigoExistencia);



                //lista actualizada
                List<LoteEN> iLisLotAct = new List<LoteEN>();


                //recorrer cada objeto lote
                foreach (LoteEN xLot in pLisLot)
                {
                    if (iMovDetBusEN.CodigoExistencia == xLot.CodigoExistencia)
                    {
                        if (iMovDetBusEN.CantidadMovimientoDeta > 0)
                        {
                            iLisLotAct.Add(xLot);
                            iMovDetBusEN.CantidadMovimientoDeta -= xLot.StockLote;
                        }                        
                    }
                    else
                    {
                        iLisLotAct.Add(xLot);
                    }
                }

                //limpiar la lista principal
                pLisLot.Clear();

                //pasar la lista actualizada
                pLisLot.AddRange(iLisLotAct);
            }
        }

        public static LoteEN Clonar(LoteEN pObj)
        {
            //valor resultado
            LoteEN iLotEN = new LoteEN();

            //pasar datos
            iLotEN.ClaveLote = pObj.ClaveLote;
            iLotEN.CodigoEmpresa = pObj.CodigoEmpresa;
            iLotEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iLotEN.DescripcionAlmacen = pObj.DescripcionAlmacen;
            iLotEN.CodigoExistencia = pObj.CodigoExistencia;
            iLotEN.DescripcionExistencia = pObj.DescripcionExistencia;
            iLotEN.CodigoUnidadMedida = pObj.CodigoUnidadMedida;
            iLotEN.NombreUnidadMedida = pObj.NombreUnidadMedida;
            iLotEN.CodigoLote = pObj.CodigoLote;
            iLotEN.FechaVencimientoLote = pObj.FechaVencimientoLote;
            iLotEN.StockLote = pObj.StockLote;
            iLotEN.StockSaldoLote = pObj.StockSaldoLote;
            iLotEN.ClaveMovimientoDeta = pObj.ClaveMovimientoDeta;
            iLotEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
            iLotEN.UltimoCorrelativoLoteDeta = pObj.UltimoCorrelativoLoteDeta;
            iLotEN.CEstadoLote = pObj.CEstadoLote;
            iLotEN.NEstadoLote = pObj.NEstadoLote;
            iLotEN.UsuarioAgrega = pObj.UsuarioAgrega;
            iLotEN.FechaAgrega = pObj.FechaAgrega;
            iLotEN.UsuarioModifica = pObj.UsuarioModifica;
            iLotEN.FechaModifica = pObj.FechaModifica;
            iLotEN.ClaveObjeto = pObj.ClaveObjeto;

            //devolver
            return iLotEN;
        }

        public static List<LoteEN> ListarLotesParaRecalculo(string pStrEmpresaPeriodo)
        {
            LoteAD iPerAD = new LoteAD();
            return iPerAD.ListarLotesParaRecalculo(pStrEmpresaPeriodo);
        }

        public static void Recalcular(string pAño, string pCodigoMes)
        {
            //armar una cadena empresa + periodo(es la estructura de una clave de PeriodoEN)
            string iStrEmpresaPeriodo = PeriodoRN.ObtenerClavePeriodo(pAño, pCodigoMes);

            //traer a todos los lotes que se van a recalcular
            List<LoteEN> iLisLot = LoteRN.ListarLotesParaRecalculo(iStrEmpresaPeriodo);

            //traer a todos los lotes deta que se van a recalcular
            List<LoteDetaEN> iLisLotDet = LoteDetaRN.ListarLotesDetaParaRecalculo(iStrEmpresaPeriodo);

            //listas para actualizar a bd
            List<LoteEN> iLisLotMod = new List<LoteEN>();
            List<LoteDetaEN> iLisLotDetMod = new List<LoteDetaEN>();

            //recorrer cada objeto
            foreach (LoteEN xLot in iLisLot)
            {
                //actualizamos el lote para iniciar el recalculo
                LoteRN.ActualizarLoteParaIniciarRecalculo(xLot);

                //obtener la lista de lotes deta del lote en proceso
                List<LoteDetaEN> iLisLotDetLot = ListaG.Filtrar<LoteDetaEN>(iLisLotDet, LoteDetaEN.ClaLot, xLot.ClaveLote);

                //recorrer cada objeto
                foreach (LoteDetaEN xLotDetLot in iLisLotDetLot)
                {
                    //pasamos el stock anterior a lotedeta
                    xLotDetLot.StockAnteriorLote = xLot.StockSaldoLote;

                    //restamos al saldo del lote
                    xLot.StockSaldoLote -= xLotDetLot.CantidadLoteDeta;

                    //obtenemos el ultimo correlativo para este lote
                    xLot.UltimoCorrelativoLoteDeta = xLotDetLot.CorrelativoLoteDeta;
                }

                //agregamos el lote ya actualizado a la lista a modificar
                iLisLotMod.Add(xLot);

                //agregamos la lista lotes deta ya actualizada a la lista a modificar
                iLisLotDetMod.AddRange(iLisLotDetLot);
            }

            //actualizar en b.d
            LoteRN.ModificarLote(iLisLotMod);
            LoteDetaRN.ModificarLoteDeta(iLisLotDetMod);
        }

        public static void ActualizarLoteParaIniciarRecalculo(LoteEN pObj)
        {
            //igualamos el saldo stock a la stock lote
            pObj.StockSaldoLote = pObj.StockLote;

            //limpiamos el ultimo correlativo
            pObj.UltimoCorrelativoLoteDeta = string.Empty;
        }

        public static string ObtenerNuevoCodigoLoteAutogenerado(string pCodigoAlmacen,string pCodigoExistencia)
        {
            //asignar parametros
            LoteEN iLotEN = new LoteEN();
            iLotEN.CodigoAlmacen = pCodigoAlmacen;
            iLotEN.CodigoExistencia = pCodigoExistencia;

            //ejecutar metodo
            return LoteRN.ObtenerNuevoCodigoLoteAutogenerado(iLotEN);
        }



    }
}
