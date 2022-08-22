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
    public class BatchRN
    {

        public static BatchEN EnBlanco()
        {
            BatchEN iExiEN = new BatchEN();
            return iExiEN;
        }

        public static void AdicionarBatch(BatchEN pObj)
        {
            BatchAD iPerAD = new BatchAD();
            iPerAD.AgregarBatch(pObj);
        }

        public static void AdicionarBatch(List< BatchEN> pLista)
        {
            BatchAD iPerAD = new BatchAD();
            iPerAD.AgregarBatch(pLista);
        }

        public static void ModificarBatch(BatchEN pObj)
        {
            BatchAD iPerAD = new BatchAD();
            iPerAD.ModificarBatch(pObj);
        }

        public static void ModificarBatch(List<BatchEN> pLista)
        {
            BatchAD iPerAD = new BatchAD();
            iPerAD.ModificarBatch(pLista);
        }

        public static void EliminarBatch(BatchEN pObj)
        {
            BatchAD iPerAD = new BatchAD();
            iPerAD.EliminarBatch(pObj);
        }

        public static void EliminarBatch(List< BatchEN> pLista)
        {
            BatchAD iPerAD = new BatchAD();
            iPerAD.EliminarBatch(pLista);
        }

        public static void EliminarBatchXClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            BatchAD iPerAD = new BatchAD();
            iPerAD.EliminarBatchXClaveMovimientoCabe(pClaveMovimientoCabe);
        }

        public static List<BatchEN> ListarBatchs(BatchEN pObj)
        {
            BatchAD iPerAD = new BatchAD();
            return iPerAD.ListarBatchs(pObj);
        }

        public static List<BatchEN> ListarBatchs()
        {
            //asignar parametros
            BatchEN iExiEN = new BatchEN();
            iExiEN.Adicionales.CampoOrden = BatchEN.ClaBat;

            //ejecutar metodo
            return BatchRN.ListarBatchs(iExiEN);
        }

        public static BatchEN BuscarBatchXClave(BatchEN pObj)
        {
            BatchAD iPerAD = new BatchAD();
            return iPerAD.BuscarBatchXClave(pObj);
        }

        public static BatchEN EsBatchExistente(BatchEN pObj)
        {
            //objeto resultado
            BatchEN iExiEN = new BatchEN();

            //validar si existe en b.d
            iExiEN = BatchRN.BuscarBatchXClave(pObj);
            if (iExiEN.ClaveBatch == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El Batch " + pObj.CodigoBatch + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static BatchEN EsCodigoBatchDisponible(BatchEN pObj)
        {
            //objeto resultado
            BatchEN iExiEN = new BatchEN();

            //valida cuando esta vacio
            if (pObj.CodigoBatch == string.Empty) { return iExiEN; }

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iExiEN; }

            //validar que los dos campos esten llenos
            iExiEN = BatchRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok           
            return iExiEN;
        }

        public static BatchEN ValidaCuandoCodigoYaExiste(BatchEN pObj)
        {
            //objeto resultado
            BatchEN iExiEN = new BatchEN();

            //validar     
            iExiEN = BatchRN.BuscarBatchXClave(pObj);
            if (iExiEN.CodigoBatch != string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo Batch " + pObj.CodigoBatch + " ya existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static List<BatchEN> FiltrarBatchsXTextoEnCualquierPosicion(List<BatchEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<BatchEN> iLisRes = new List<BatchEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (BatchEN xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<BatchEN>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<BatchEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<BatchEN> pListaBatchs)
        {
            //lista resultado
            List<BatchEN> iLisRes = new List<BatchEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaBatchs; }

            //filtar la lista
            iLisRes = BatchRN.FiltrarBatchsXTextoEnCualquierPosicion(pListaBatchs, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveBatch(BatchEN pObj)
        {
            //asignar parametros
            List<string> iLista = new List<string>();
            iLista.Add(Universal.gCodigoEmpresa);
            iLista.Add(pObj.PeriodoBatch);
            iLista.Add(pObj.CorrelativoBatch);            
            string iCaracterSeparador = "-";

            //ejecutar metodo
            return Cadena.ConcatenarTexto(iLista, iCaracterSeparador);            
        }

        public static BatchEN EsActoModificarBatch(BatchEN pObj)
        {
            //objeto resultado
            BatchEN iExiEN = new BatchEN();

            //validar si existe
            iExiEN = BatchRN.EsBatchExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }
            
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static BatchEN EsActoEliminarBatch(BatchEN pObj)
        {
            //objeto resultado
            BatchEN iExiEN = new BatchEN();

            //validar si existe
            iExiEN = BatchRN.EsBatchExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok            
            return iExiEN;
        }

        public static BatchEN EsBatchValido(BatchEN pObj)
        {
            //objeto resultado
            BatchEN iExiEN = new BatchEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoBatch == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = BatchRN.EsBatchExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok           
            return iExiEN;
        }

        public static void ModificarVerdadFalsoBatch(BatchEN pObj, List<BatchEN> pLista)
        {
            //lista actualizada
            List<BatchEN> iLisExi = new List<BatchEN>();

            //buscamos el objeto en la lista pLista
            foreach (BatchEN xExi in pLista)
            {
                if (xExi.ClaveBatch == pObj.ClaveBatch)
                {
                    xExi.VerdadFalso = pObj.VerdadFalso;
                }
                iLisExi.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisExi);
        }

        public static List<BatchEN> ListarBatchsSoloMarcadas(List<BatchEN> pLista)
        {
            //lista resultado
            List<BatchEN> iLisRes = new List<BatchEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (BatchEN xExi in pLista)
            {
                if (xExi.VerdadFalso == true)
                {
                    iLisRes.Add(xExi);
                }
            }
            return iLisRes;
        }

        public static BatchEN HayObjetosMarcados(List<BatchEN> pLista)
        {
            //objeto resultado
            BatchEN iExiEN = new BatchEN();

            //sacar las cuotas solo marcadas
            List<BatchEN> iLisExiMar = BatchRN.ListarBatchsSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisExiMar.Count == 0)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "No hay Batchs marcados, no se puede realizar la operacion";
                return iExiEN;
            }
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static bool ExisteCodigoBatchEnLista(string pCodigoBatch,List<BatchEN> pLista)
        {
            //recorrer cada objeto
            foreach (BatchEN xExi in pLista)
            {
                if (pCodigoBatch == xExi.CodigoBatch)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static void MarcarTodos( List<BatchEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<BatchEN> iLisExi = new List<BatchEN>();

            //buscamos el objeto en la lista pLista
            foreach (BatchEN xExi in pLista)
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
            BatchAD iPerAD = new BatchAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            BatchAD iPerAD = new BatchAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            BatchAD iPerAD = new BatchAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteClaveBatchEnLista(string pClaveBatch, List<BatchEN> pLista)
        {
            //recorrer cada objeto
            foreach (BatchEN xExi in pLista)
            {
                if (pClaveBatch == xExi.ClaveBatch)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static BatchEN BuscarBatchXClave(string pClaveBatch, List<BatchEN> pLista)
        {
            //objeto resultaddo
            BatchEN iExiEN = new BatchEN();

            //recorrer cada objeto
            foreach (BatchEN xExi in pLista)
            {
                if (pClaveBatch == xExi.ClaveBatch)
                {
                    return xExi;
                }
            }

            //devolver
            return iExiEN;
        }

        public static List<BatchEN> ObtenerAInterseccionB(List<BatchEN> pLisExiA, List<BatchEN> pLisExiB)
        {
            //lista resultado
            List<BatchEN> iLisRes = new List<BatchEN>();

            //recorrer cada objeto
            foreach (BatchEN xExiA in pLisExiA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (BatchEN xExiB in pLisExiB)
                {
                    if (xExiA.CodigoBatch == xExiB.CodigoBatch)
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
           
        public static BatchEN ValidaCuandoEstaDesactivada(BatchEN pObj)
        {
            //objeto resultado
            BatchEN iExiEN = new BatchEN();

            //validar                 
            if (pObj.CEstadoBatch == "0")//desactivado
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "La Batch esta desactivada";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void AdicionarBatch(List<BatchEN> pLis, BatchEN pObj)
        {
            //obtener siguiente correlativo          
            pObj.ClaveObjeto = BatchRN.ObtenerClaveBatch(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<BatchEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "0000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoBatch;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }
               
        public static string ObtenerMaximoValorEnColumna(BatchEN pObj)
        {
            BatchAD iCliAD = new BatchAD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoCodigoBatchAutogenerado(BatchEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = BatchRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static string ObtenerMaximoValorEnColumna(string pCodigoAlmacen,string pCodigoExistencia)
        {
            //asignar parametros
            BatchEN iBatchN = new BatchEN();
            iBatchN.CodigoAlmacen = pCodigoAlmacen;
            iBatchN.CodigoExistencia = pCodigoExistencia;

            //ejecutar metodo
            return BatchRN.ObtenerMaximoValorEnColumna(iBatchN);
        }

        public static string ObtenerNuevoCodigoBatchAutogenerado(BatchEN pObj, List<BatchEN> pLista)
        {
            //---------------------------
            //esta funcion primero busca el ultimo codigoBatch en la lista, sino hay entonces pasa a buscar
            //en la b.d
            //---------------------------

            //filtrar esta lista con solo los Batchs de la existencia que se esta operando
            List<BatchEN> iLisBatchxi = ListaG.Filtrar<BatchEN>(pLista, BatchEN.CodExi, pObj.CodigoExistencia);

            //si la lista esta vacia entonces se busca el codigoBatch en b.d
            if (iLisBatchxi.Count == 0)
            {
                return BatchRN.ObtenerNuevoCodigoBatchAutogenerado(pObj);
            }
            else
            {
                return BatchRN.ObtenerSiguienteCorrelativo(iLisBatchxi);
            }
        }

        public static void ModificarBatch(List<BatchEN> pLis, BatchEN pObj)
        {
            //recorrer cada objeto
            foreach (BatchEN xLot in pLis)
            {
                if (xLot.ClaveBatch == pObj.ClaveBatch)
                {
                    xLot.FechaVencimientoBatch = pObj.FechaVencimientoBatch;
                    xLot.StockBatch = pObj.StockBatch;
                    xLot.StockSaldoBatch = pObj.StockBatch;
                }
            }
        }

        public static void EliminarBatch(List<BatchEN> pLis, BatchEN pObj)
        {
            //lista sin el objeto a eliminar
            List<BatchEN> iLisBatchli = new List<BatchEN>();

            //recorrer cada objeto
            foreach (BatchEN xLot in pLis)
            {
                if (xLot.ClaveBatch != pObj.ClaveBatch)
                {
                    iLisBatchli.Add(xLot);
                }
            }

            //limpiar la lista original
            pLis.Clear();

            //pasar la lista actualizada
            pLis.AddRange(iLisBatchli);
        }

        public static void EliminarBatch(List<BatchEN> pLis, string pCodigoExistencia)
        {
            //lista sin el objeto a eliminar
            List<BatchEN> iLisBatchli = new List<BatchEN>();

            //recorrer cada objeto
            foreach (BatchEN xLot in pLis)
            {
                if (xLot.CodigoExistencia != pCodigoExistencia)
                {
                    iLisBatchli.Add(xLot);
                }
            }

            //limpiar la lista original
            pLis.Clear();

            //pasar la lista actualizada
            pLis.AddRange(iLisBatchli);
        }

    


    }
}
