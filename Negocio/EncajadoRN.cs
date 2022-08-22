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
    public class EncajadoRN
    {

        public static EncajadoEN EnBlanco()
        {
            EncajadoEN iExiEN = new EncajadoEN();
            return iExiEN;
        }

        public static void AdicionarEncajado(EncajadoEN pObj)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            iPerAD.AgregarEncajado(pObj);
        }

        public static void AdicionarEncajado(List<EncajadoEN> pLista)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            iPerAD.AgregarEncajado(pLista);
        }

        public static void ModificarEncajado(EncajadoEN pObj)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            iPerAD.ModificarEncajado(pObj);
        }

        public static void ModificarEncajado(List<EncajadoEN> pLista)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            iPerAD.ModificarEncajado(pLista);
        }

        public static void EliminarEncajado(EncajadoEN pObj)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            iPerAD.EliminarEncajado(pObj);
        }

        public static void EliminarEncajado(List< EncajadoEN> pLista)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            iPerAD.EliminarEncajado(pLista);
        }

        public static List<EncajadoEN> ListarEncajados(EncajadoEN pObj)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            return iPerAD.ListarEncajados(pObj);
        }

        public static List<EncajadoEN> ListarEncajados()
        {
            //asignar parametros
            EncajadoEN iExiEN = new EncajadoEN();
            iExiEN.Adicionales.CampoOrden = EncajadoEN.ClaEnc;

            //ejecutar metodo
            return EncajadoRN.ListarEncajados(iExiEN);
        }

        public static EncajadoEN BuscarEncajadoXClave(EncajadoEN pObj)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            return iPerAD.BuscarEncajadoXClave(pObj);
        }

        public static EncajadoEN EsEncajadoExistente(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iExiEN = new EncajadoEN();

            //validar si existe en b.d
            iExiEN = EncajadoRN.BuscarEncajadoXClave(pObj);
            if (iExiEN.ClaveEncajado == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El Encajado " + pObj.CorrelativoEncajado + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static EncajadoEN EsCodigoEncajadoDisponible(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iExiEN = new EncajadoEN();

            //validar que los dos campos esten llenos
            iExiEN = EncajadoRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok           
            return iExiEN;
        }

        public static EncajadoEN ValidaCuandoCodigoYaExiste(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iExiEN = new EncajadoEN();

            //validar     
            iExiEN = EncajadoRN.BuscarEncajadoXClave(pObj);
            if (iExiEN.CorrelativoEncajado != string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo Encajado " + pObj.CorrelativoEncajado + " ya existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static List<EncajadoEN> FiltrarEncajadosXTextoEnCualquierPosicion(List<EncajadoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<EncajadoEN> iLisRes = new List<EncajadoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (EncajadoEN xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<EncajadoEN>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<EncajadoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<EncajadoEN> pListaEncajados)
        {
            //lista resultado
            List<EncajadoEN> iLisRes = new List<EncajadoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaEncajados; }

            //filtar la lista
            iLisRes = EncajadoRN.FiltrarEncajadosXTextoEnCualquierPosicion(pListaEncajados, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveEncajado(EncajadoEN pObj)
        {
            //asignar parametros
            List<string> iLista = new List<string>();
            iLista.Add(Universal.gCodigoEmpresa);         
            iLista.Add(pObj.CorrelativoEncajado);            
            string iCaracterSeparador = "-";

            //ejecutar metodo
            return Cadena.ConcatenarTexto(iLista, iCaracterSeparador);            
        }

        public static EncajadoEN EsActoModificarEncajado(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iExiEN = new EncajadoEN();

            //validar si existe
            iExiEN = EncajadoRN.EsEncajadoExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }
            
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static EncajadoEN EsActoEliminarEncajado(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iExiEN = new EncajadoEN();

            //validar si existe
            iExiEN = EncajadoRN.EsEncajadoExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok            
            return iExiEN;
        }

        public static EncajadoEN EsEncajadoValido(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iExiEN = new EncajadoEN();
            
            //valida cuando el codigo no existe
            iExiEN = EncajadoRN.EsEncajadoExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok           
            return iExiEN;
        }

        public static void ModificarVerdadFalsoEncajado(EncajadoEN pObj, List<EncajadoEN> pLista)
        {
            //lista actualizada
            List<EncajadoEN> iLisExi = new List<EncajadoEN>();

            //buscamos el objeto en la lista pLista
            foreach (EncajadoEN xExi in pLista)
            {
                if (xExi.ClaveEncajado == pObj.ClaveEncajado)
                {
                    xExi.VerdadFalso = pObj.VerdadFalso;
                }
                iLisExi.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisExi);
        }

        public static List<EncajadoEN> ListarEncajadosSoloMarcadas(List<EncajadoEN> pLista)
        {
            //lista resultado
            List<EncajadoEN> iLisRes = new List<EncajadoEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (EncajadoEN xExi in pLista)
            {
                if (xExi.VerdadFalso == true)
                {
                    iLisRes.Add(xExi);
                }
            }
            return iLisRes;
        }

        public static EncajadoEN HayObjetosMarcados(List<EncajadoEN> pLista)
        {
            //objeto resultado
            EncajadoEN iExiEN = new EncajadoEN();

            //sacar las cuotas solo marcadas
            List<EncajadoEN> iLisExiMar = EncajadoRN.ListarEncajadosSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisExiMar.Count == 0)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "No hay Encajados marcados, no se puede realizar la operacion";
                return iExiEN;
            }
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void MarcarTodos( List<EncajadoEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<EncajadoEN> iLisExi = new List<EncajadoEN>();

            //buscamos el objeto en la lista pLista
            foreach (EncajadoEN xExi in pLista)
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
            EncajadoAD iPerAD = new EncajadoAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static EncajadoEN ValidaCuandoEstaDesactivada(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iExiEN = new EncajadoEN();

            //validar                 
            if (pObj.CEstadoEncajado == "0")//desactivado
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "La Encajado esta desactivada";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void AdicionarEncajado(List<EncajadoEN> pLis, EncajadoEN pObj)
        {
            //obtener siguiente correlativo          
            pObj.ClaveObjeto = EncajadoRN.ObtenerClaveEncajado(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<EncajadoEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "000000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoEncajado;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }
        
        public static string ObtenerMaximoValorEnColumna()
        {
            EncajadoAD iCliAD = new EncajadoAD();
            return iCliAD.ObtenerMaximoValorEnColumna();
        }

        public static string ObtenerNuevoCodigoEncajadoAutogenerado()
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = EncajadoRN.ObtenerMaximoValorEnColumna();

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static List<EncajadoEN> ListarEncajadoXEstado(EncajadoEN pObj)
        {
            EncajadoAD iPerAD = new EncajadoAD();
            return iPerAD.ListarEncajadoXEstado(pObj);
        }

        public static void ModificarPorSalidaInsumosFaseEmpaquetado(EncajadoEN pObj)
        {
            //traer al Encajado de b.d
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //actualizamos los datos            
            iEncEN.ClaveSalidaFaseEmpaquetado = pObj.ClaveSalidaFaseEmpaquetado;

            //modificar en bd
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void ModificarPorSalidaUnidadesAEmpaquetar(EncajadoEN pObj)
        {
            //traer al Encajado de b.d
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //actualizamos los datos            
            iEncEN.ClaveSalidaUnidadesEmpacar = pObj.ClaveSalidaUnidadesEmpacar;

            //modificar en bd
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void ModificarPorIngresoProductosTerminados(EncajadoEN pObj)
        {
            //traer al Encajado de b.d
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //actualizamos los datos            
            iEncEN.ClaveIngresoProductoTerminado = pObj.ClaveIngresoProductoTerminado;

            //modificar en bd
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static EncajadoEN EsActoTerminarProcesoEncajado(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iProCabEN = new EncajadoEN();

            //validar si existe
            iProCabEN = EncajadoRN.EsEncajadoExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera ingreso de mercaderia
            EncajadoEN iProDetIngMerEN = EncajadoRN.ValidaCuandoNoGeneraIngresoProductoTerminado(iProCabEN);
            if (iProDetIngMerEN.Adicionales.EsVerdad == false) { return iProDetIngMerEN; }

            //valida cuando el proceso ya esta terminado
            EncajadoEN iProDetTerEN = EncajadoRN.ValidaCuandoProcesoYaEstaTerminado(iProCabEN);
            if (iProDetTerEN.Adicionales.EsVerdad == false) { return iProDetTerEN; }

            //ok
            return iProCabEN;
        }

        public static EncajadoEN ValidaCuandoNoGeneraIngresoProductoTerminado(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iProDetEN = new EncajadoEN();

            //valida
            if (pObj.ClaveIngresoProductoTerminado == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el Ingreso de producto terminado, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static EncajadoEN ValidaCuandoProcesoYaEstaTerminado(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iProDetEN = new EncajadoEN();

            //valida
            if (pObj.CEstadoEncajado == "1")//terminado
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "El proceso ya se encuentra Terminado, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static void CambiarEstadoATerminado(EncajadoEN pObj)
        {
            //actualizamos su estado a terminado
            pObj.CEstadoEncajado = "1";//Terminado

            //modificamos en b.d
            EncajadoRN.ModificarEncajado(pObj);
        }

        public static EncajadoEN CrearEncajadoPorMigracion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            EncajadoEN iEncEN = new EncajadoEN();

            //pasar datos
            iEncEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iEncEN.CorrelativoEncajado = EncajadoRN.ObtenerNuevoCodigoEncajadoAutogenerado();
            iEncEN.FechaEncajado = pObj.FechaProduccionDeta;
            iEncEN.PeriodoEncajado = Fecha.ObtenerPeriodo(iEncEN.FechaEncajado, "-");
            iEncEN.DescripcionEncajado = "MIGRACION 2019";
            iEncEN.CEstadoEncajado = "1";//Terminado
            iEncEN.ClaveEncajado = EncajadoRN.ObtenerClaveEncajado(iEncEN);

            //devolver
            return iEncEN;
        }

        public static EncajadoEN EsActoIngresarProductoTerminado(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iProCabEN = new EncajadoEN();

            //validar si existe
            iProCabEN = EncajadoRN.EsEncajadoExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera ingreso de mercaderia
            EncajadoEN iProDetSalFasEmpEN = EncajadoRN.ValidaCuandoNoGeneraSalidaInsumosFaseEmpaquetado(iProCabEN);
            if (iProDetSalFasEmpEN.Adicionales.EsVerdad == false) { return iProDetSalFasEmpEN; }

            //valida cuando no genera ingreso de mercaderia
            EncajadoEN iProDetSalUniEmpEN = EncajadoRN.ValidaCuandoNoGeneraSalidaUnidadesEmpacar(iProCabEN);
            if (iProDetSalUniEmpEN.Adicionales.EsVerdad == false) { return iProDetSalUniEmpEN; }

            //valida cuando no hay produccionProTer con cantidades reales
            EncajadoEN iProDetCanReaEN = EncajadoRN.ValidaCuandoNoHayCantidadesReales(iProCabEN);
            if (iProDetCanReaEN.Adicionales.EsVerdad == false) { return iProDetCanReaEN; }

            //valida cuando no distribuye alguna liberacion de este encajado
            EncajadoEN iProDetLibDisEN = EncajadoRN.ValidaCuandoNoDistribuyeLiberaciones(iProCabEN);
            if (iProDetLibDisEN.Adicionales.EsVerdad == false) { return iProDetLibDisEN; }

            //ok
            return iProCabEN;
        }

        public static EncajadoEN ValidaCuandoNoDistribuyeLiberaciones(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iProDetEN = new EncajadoEN();

            //valida
            //traer a todas las ProduccionesProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pObj.ClaveEncajado);

            //obtener todas las liberaciones de estos ProduccionesProTer
            List<LiberacionEN> iLisLibProTer = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(iLisProProTer);

            //recorrer cada objeto liberacion
            foreach (LiberacionEN xLib in iLisLibProTer)
            {
                //si solo una liberacion esta sin distribuir devuelve falso
                if (LiberacionRN.EsLiberacionDistribuida(xLib) == false)
                {
                    iProDetEN.Adicionales.EsVerdad = false;
                    iProDetEN.Adicionales.Mensaje = "Aun no distribuye liberaciones de este encajado, No se puede realizar la operacion";
                    return iProDetEN;
                }
            }
            
            //ok
            return iProDetEN;
        }

        public static EncajadoEN ValidaCuandoNoHayCantidadesReales(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iProDetEN = new EncajadoEN();

            //valida
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerConCantidadRealXClaveEncajado(pObj.ClaveEncajado);
            if (iLisProProTer.Count == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no digita las cantidades reales para cada producto, No se puede realizar la operacion";
            }

            //ok
            return iProDetEN;
        }

        public static EncajadoEN ValidaCuandoNoGeneraSalidaInsumosFaseEmpaquetado(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iProDetEN = new EncajadoEN();

            //valida
            //traer una lista de produccionesExis que representan los materiales de encajado que faltan sacar
            //par este encajado
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisParaAgregarParteFaseEmpaquetado(pObj.ClaveEncajado);

            //si la lista esta llena con algun objeto,significa que faltan sacar materiales de encajado
            if (iLisProExi.Count != 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no saca todos los Insumos fase epaquetado de este encajado, No se puede realizar la operacion";                
            }

            //ok
            return iProDetEN;
        }

        public static EncajadoEN ValidaCuandoNoGeneraSalidaUnidadesEmpacar(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iProDetEN = new EncajadoEN();

            //valida
            if (pObj.ClaveSalidaUnidadesEmpacar == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera la salida de unidades para empaquetar, No se puede realizar la operacion";
            }

            //ok
            return iProDetEN;
        }

        public static EncajadoEN ValidaCuandoNoEsActoRegistrarEnPeriodo(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iEncEN = new EncajadoEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pObj.PeriodoEncajado;
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iEncEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iEncEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iEncEN;
        }

        public static EncajadoEN EsValidaFechaEncajado(EncajadoEN pObj)
        {
            //objeto resultado
            EncajadoEN iEncEN = new EncajadoEN();

            //validar          
            bool iExiste = ExisteValorEnColumnaConEmpresa(EncajadoEN.FecEnc, Fecha.ObtenerAnoMesDia(pObj.FechaEncajado));
            if (iExiste == true)
            {
                //cuando el usuario esta adicionando
                if (pObj.CorrelativoEncajado == string.Empty)
                {
                    iEncEN.Adicionales.EsVerdad = false;
                    iEncEN.Adicionales.Mensaje = "Ya existen un plan encajado con esta fecha";
                }
                else
                {
                    //aqui esta modificando el registro
                    EncajadoEN iEncModEN = BuscarEncajadoXClave(pObj);
                    if (iEncModEN.FechaEncajado != Fecha.ObtenerDiaMesAno(pObj.FechaEncajado))
                    {
                        iEncEN.Adicionales.EsVerdad = false;
                        iEncEN.Adicionales.Mensaje = "Ya existen un plan encajado con esta fecha";
                    }
                }
            }

            //devolver
            return iEncEN;
        }

        public static void ModificarPorSalidaUnidadesAEmpaquetarObservados(EncajadoEN pObj)
        {
            //traer al Encajado de b.d
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //actualizamos los datos            
            iEncEN.ClaveSalidaUnidadesEmpacarObservados = pObj.ClaveSalidaUnidadesEmpacarObservados;

            //modificar en bd
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void ModificarPorSalidaUnidadesAEmpaquetarCuarentena(EncajadoEN pObj)
        {
            //traer al Encajado de b.d
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //actualizamos los datos            
            iEncEN.ClaveSalidaUnidadesEmpacarCuarentena = pObj.ClaveSalidaUnidadesEmpacarCuarentena;

            //modificar en bd
            EncajadoRN.ModificarEncajado(iEncEN);
        }

    }
}
