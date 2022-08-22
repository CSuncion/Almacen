using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;
using Entidades.Estructuras;
using System.Windows.Forms;

namespace Negocio
{
    public class ProduccionCabeRN
    {

        public static ProduccionCabeEN EnBlanco()
        {
            ProduccionCabeEN iProEN = new ProduccionCabeEN();
            return iProEN;
        }

        public static void AdicionarProduccionCabe(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            iProAD.AdicionarProduccionCabe(pObj);
        }

        public static void AdicionarProduccionCabe(List<ProduccionCabeEN> pLista)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            iProAD.AdicionarProduccionCabe(pLista);
        }

        public static void ModificarProduccionCabe(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            iProAD.ModificarProduccionCabe(pObj);
        }

        public static void ModificarProduccionCabe(List<ProduccionCabeEN> pLista)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            iProAD.ModificarProduccionCabe(pLista);
        }

        public static void EliminarProduccionCabe(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            iProAD.EliminarProduccionCabe(pObj);
        }

        public static ProduccionCabeEN BuscarProduccionCabeXClave(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.BuscarProduccionCabeXClave(pObj);
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeActivos(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.ListarProduccionCabeActivos(pObj);
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeXPeriodo(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.ListarProduccionCabeXPeriodo(pObj);
        }

        public static string ObtenerClaveProduccionCabe(ProduccionCabeEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CorrelativoProduccionCabe;

            //devolver
            return iClave;
        }

        public static ProduccionCabeEN EsProduccionCabeExistente(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProEN = new ProduccionCabeEN();

            //valida
            iProEN = ProduccionCabeRN.BuscarProduccionCabeXClave(pObj);
            if (iProEN.CorrelativoProduccionCabe == string.Empty)
            {
                iProEN.Adicionales.EsVerdad = false;
                iProEN.Adicionales.Mensaje = "La Solicitud " + pObj.CorrelativoProduccionCabe + " no existe";
                return iProEN;
            }

            //ok
            return iProEN;
        }

        public static List<ProduccionCabeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<ProduccionCabeEN> pListaProduccionCabe)
        {
            //lista resultado
            List<ProduccionCabeEN> iLisRes = new List<ProduccionCabeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaProduccionCabe; }

            //filtar la lista
            iLisRes = ProduccionCabeRN.FiltrarProduccionCabeEnCualquierPosicion(pListaProduccionCabe, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<ProduccionCabeEN> FiltrarProduccionCabeEnCualquierPosicion(List<ProduccionCabeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<ProduccionCabeEN> iLisRes = new List<ProduccionCabeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (ProduccionCabeEN xPro in pLista)
            {
                string iTexto = ProduccionCabeRN.ObtenerValorDeCampo(xPro, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPro);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(ProduccionCabeEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case ProduccionCabeEN.ClaObj: return pObj.ClaveObjeto;
                case ProduccionCabeEN.ClaProCab: return pObj.ClaveProduccionCabe;
                case ProduccionCabeEN.CodEmp: return pObj.CodigoEmpresa;
                case ProduccionCabeEN.NomEmp: return pObj.NombreEmpresa;
                case ProduccionCabeEN.CodAlm: return pObj.CodigoAlmacen;
                case ProduccionCabeEN.DesAlm: return pObj.DescripcionAlmacen;
                case ProduccionCabeEN.CorProCab: return pObj.CorrelativoProduccionCabe;
                case ProduccionCabeEN.CodExi: return pObj.CodigoExistencia;
                case ProduccionCabeEN.DesExi: return pObj.DescripcionExistencia;
                case ProduccionCabeEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case ProduccionCabeEN.NomUniMed: return pObj.NombreUnidadMedida;
                case ProduccionCabeEN.FecProCab: return pObj.FechaProduccionCabe;
                case ProduccionCabeEN.PerProCab: return pObj.PeriodoProduccionCabe;
                case ProduccionCabeEN.CanFor: return pObj.CantidadFormula.ToString();
                case ProduccionCabeEN.CanProCab: return pObj.CantidadProduccionCabe.ToString();
                case ProduccionCabeEN.CanProProCab: return pObj.CantidadProducidaProduccionCabe.ToString();
                case ProduccionCabeEN.SalProCab: return pObj.SaldoProduccionCabe.ToString();
                case ProduccionCabeEN.CodLic: return pObj.CodigoLicitacion;
                case ProduccionCabeEN.DesLic: return pObj.DescripcionLicitacion;
                case ProduccionCabeEN.CodAux: return pObj.CodigoAuxiliar;
                case ProduccionCabeEN.DesAux: return pObj.DescripcionAuxiliar;
                case ProduccionCabeEN.ObsProCab: return pObj.ObservacionProduccionCabe;
                case ProduccionCabeEN.CodMer: return pObj.CodigoMercaderia;
                case ProduccionCabeEN.CEstProCab: return pObj.CEstadoProduccionCabe;
                case ProduccionCabeEN.NEstProCab: return pObj.NEstadoProduccionCabe;
                case ProduccionCabeEN.UsuAgr: return pObj.UsuarioAgrega;
                case ProduccionCabeEN.FecAgr: return pObj.FechaAgrega.ToString();
                case ProduccionCabeEN.UsuMod: return pObj.UsuarioModifica;
                case ProduccionCabeEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static ProduccionCabeEN EsActoAdicionarProduccionCabe(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iProCabEN = ProduccionCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //ok          
            return iProCabEN;
        }

        public static ProduccionCabeEN ValidaCuandoNoEsActoRegistrarEnPeriodo(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pObj.PeriodoProduccionCabe;
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iProCabEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iProCabEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iProCabEN;
        }

        public static ProduccionCabeEN EsActoEliminarProduccionCabe(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iProCabEN = ProduccionCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //validar si existe
            iProCabEN = ProduccionCabeRN.EsProduccionCabeExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no esta planificada
            ProduccionCabeEN iProCabAnuEN = ProduccionCabeRN.ValidaCuandoNoEstaEnPlanificada(iProCabEN);
            if (iProCabAnuEN.Adicionales.EsVerdad == false) { return iProCabAnuEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionCabeEN EsActoModificarProduccionCabe(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iProCabEN = ProduccionCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //validar si existe
            iProCabEN = ProduccionCabeRN.EsProduccionCabeExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no esta planificada
            ProduccionCabeEN iProCabAnuEN = ProduccionCabeRN.ValidaCuandoNoEstaEnPlanificada(iProCabEN);
            if (iProCabAnuEN.Adicionales.EsVerdad == false) { return iProCabAnuEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionCabeEN ValidaCuandoNoEstaEnPlanificada(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida 
            if (pObj.CEstadoProduccionCabe != "0")//planificada
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "Esta accion es solo para solicitudes en estado Planificada, no se puede realizar la operacion";
                return iProCabEN;
            }

            //ok           
            return iProCabEN;
        }

        public static string ObtenerMaximoValorEnColumna(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProCabAD = new ProduccionCabeAD();
            return iProCabAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoNumeroProduccionCabeAutogenerado(ProduccionCabeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = ProduccionCabeRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static string ObtenerNuevoNumeroProduccionCabeAutogenerado(string pCodigoAlmacen)
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CodigoAlmacen = pCodigoAlmacen;

            //ejecutar metodo
            return ObtenerNuevoNumeroProduccionCabeAutogenerado(iProCabEN);
        }

        public static string ObtenerNuevoNumeroProduccionCabeAutogenerado()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CodigoAlmacen = "A10";

            //ejecutar metodo
            return ObtenerNuevoNumeroProduccionCabeAutogenerado(iProCabEN);
        }

        public static decimal ObtenerSaldoProduccionCabe(ProduccionCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = pObj.CantidadProduccionCabe - pObj.CantidadProducidaProduccionCabe;

            //devolver
            return iValor;
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeXEstado(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.ListarProduccionCabeXEstado(pObj);
        }

        public static List<ProduccionCabeEN> ListarProduccionCabePendientesDeAlmacen(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.ListarProduccionCabePendientesDeAlmacen(pObj);
        }

        public static ProduccionCabeEN EsProduccionCabePendienteValido(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CorrelativoProduccionCabe == string.Empty) { return iProCabEN; }

            //valida cuando el codigo no existe
            iProCabEN = ProduccionCabeRN.EsProduccionCabeExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no esta pendiente
            ProduccionCabeEN iProCabPenEN = ProduccionCabeRN.ValidaCuandoNoEstaPendiente(iProCabEN);
            if (iProCabPenEN.Adicionales.EsVerdad == false) { return iProCabPenEN; }

            //ok           
            return iProCabEN;
        }

        public static ProduccionCabeEN ValidaCuandoNoEstaPendiente(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida 
            if (pObj.CEstadoProduccionCabe != "0")//pendiente
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La solicitud debe estar pendiente";
                return iProCabEN;
            }

            //ok           
            return iProCabEN;
        }

        public static void ModificarProduccionCabeAlAdicionarParteTrabajo(string pClaveProduccionCabe, decimal pCantidadProduccionDeta)
        {
            //traer a la ProduccionCabe de la b.d
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.ClaveProduccionCabe = pClaveProduccionCabe;
            iProCabEN = ProduccionCabeRN.BuscarProduccionCabeXClave(iProCabEN);

            //primero actualizamos el objeto 
            ProduccionCabeRN.ActualizarProduccionCabeAlAdicionarParteTrabajo(iProCabEN, pCantidadProduccionDeta);

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionCabeRN.ModificarProduccionCabe(iProCabEN);
        }

        public static void ModificarProduccionCabeAlEliminarParteTrabajo(string pClaveProduccionCabe, decimal pCantidadProduccionDeta)
        {
            //traer a la ProduccionCabe de la b.d
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.ClaveProduccionCabe = pClaveProduccionCabe;
            iProCabEN = ProduccionCabeRN.BuscarProduccionCabeXClave(iProCabEN);

            //primero actualizamos el objeto 
            ProduccionCabeRN.ActualizarProduccionCabeAlEliminarParteTrabajo(iProCabEN, pCantidadProduccionDeta);

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionCabeRN.ModificarProduccionCabe(iProCabEN);
        }

        public static void ModificarProduccionCabeAlModificarParteTrabajo(string pClaveProduccionCabe, decimal pCantidadProduccionDeta,
            decimal pCantidadProduccionDetaAnterior)
        {
            //traer a la ProduccionCabe de la b.d
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.ClaveProduccionCabe = pClaveProduccionCabe;
            iProCabEN = ProduccionCabeRN.BuscarProduccionCabeXClave(iProCabEN);

            //primero actualizamos por eliminacion 
            ProduccionCabeRN.ActualizarProduccionCabeAlEliminarParteTrabajo(iProCabEN, pCantidadProduccionDetaAnterior);

            //ahora actualizamos por adicion  
            ProduccionCabeRN.ActualizarProduccionCabeAlAdicionarParteTrabajo(iProCabEN, pCantidadProduccionDeta);

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionCabeRN.ModificarProduccionCabe(iProCabEN);
        }

        public static decimal ObtenerCantidadProducidaProduccionCabe(ProduccionCabeEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = pObj.CantidadProduccionCabe - pObj.SaldoProduccionCabe;

            //devolver
            return iValor;
        }

        public static void ActualizarProduccionCabeAlAdicionarParteTrabajo(ProduccionCabeEN pObj, decimal pCantidadProduccionDeta)
        {
            //actualizamos con la nueva cantidad de la parte de trabajo
            pObj.CantidadProducidaProduccionCabe += pCantidadProduccionDeta;

            //ahora actualizamos el nuevo saldo
            pObj.SaldoProduccionCabe = ProduccionCabeRN.ObtenerSaldoProduccionCabe(pObj);

            //actualizar el estado
            pObj.CEstadoProduccionCabe = ProduccionCabeRN.ObtenerCEstadoProduccionCabe(pObj);
        }

        public static void ActualizarProduccionCabeAlEliminarParteTrabajo(ProduccionCabeEN pObj, decimal pCantidadProduccionDeta)
        {
            //actualizamos con la nueva cantidad de la parte de trabajo
            pObj.CantidadProducidaProduccionCabe -= pCantidadProduccionDeta;

            //ahora actualizamos el nuevo saldo
            pObj.SaldoProduccionCabe = ProduccionCabeRN.ObtenerSaldoProduccionCabe(pObj);

            //actualizar el estado
            pObj.CEstadoProduccionCabe = ProduccionCabeRN.ObtenerCEstadoProduccionCabe(pObj);
        }

        public static string ObtenerCEstadoProduccionCabe(ProduccionCabeEN pObj)
        {
            //valor resultado
            string iEstado = string.Empty;

            //validar
            if (pObj.SaldoProduccionCabe == 0)
            {
                iEstado = "3";//terminado
            }
            else
            {
                iEstado = "2";//aprobada
            }

            //devolver
            return iEstado;
        }

        public static ProduccionCabeEN EsActoAnularProduccionCabe(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iProCabEN = ProduccionCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //validar si existe
            iProCabEN = ProduccionCabeRN.EsProduccionCabeExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando esta anulada
            ProduccionCabeEN iProCabAnuEN = ProduccionCabeRN.ValidaCuandoEstaAnulada(iProCabEN);
            if (iProCabAnuEN.Adicionales.EsVerdad == false) { return iProCabAnuEN; }

            //valida cuando tiene parte de trabajo 
            ProduccionCabeEN iProCabParTraEN = ProduccionCabeRN.ValidaCuandoTieneParteTrabajo(iProCabEN);
            if (iProCabParTraEN.Adicionales.EsVerdad == false) { return iProCabParTraEN; }

            //ok            
            return iProCabEN;
        }

        public static void AnularProduccionCabe(ProduccionCabeEN pObj)
        {
            //traer a la produccionCabe de b.d
            ProduccionCabeEN iProCabEN = ProduccionCabeRN.BuscarProduccionCabeXClave(pObj);

            //actualizamos el estado
            iProCabEN.CEstadoProduccionCabe = "2";//anulado

            //modificamos en b.d
            ProduccionCabeRN.ModificarProduccionCabe(iProCabEN);
        }

        public static ProduccionCabeEN ValidaCuandoTieneParteTrabajo(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida 
            if (pObj.CantidadProducidaProduccionCabe != 0)
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La solicitud ya tiene Partes de trabajo, no se puede realizar la operacion";
                return iProCabEN;
            }

            //ok           
            return iProCabEN;
        }

        public static ProduccionCabeEN ValidaCuandoEstaAnulada(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida 
            if (pObj.CEstadoProduccionCabe == "4")//anulada
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La solicitud esta Anulada, no se puede realizar la operacion";
                return iProCabEN;
            }

            //ok           
            return iProCabEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            ProduccionCabeAD iPerAD = new ProduccionCabeAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            ProduccionCabeAD iPerAD = new ProduccionCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            ProduccionCabeAD iPerAD = new ProduccionCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeEstadoCompra()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CEstadoProduccionCabe = "1";//compra
            iProCabEN.Adicionales.CampoOrden = ProduccionCabeEN.CorProCab;

            //ejecutar metodo
            return ProduccionCabeRN.ListarProduccionCabeXEstado(iProCabEN);
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeEstadoPlanificacion()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CEstadoProduccionCabe = "0";//planificacion
            iProCabEN.Adicionales.CampoOrden = ProduccionCabeEN.CorProCab;

            //ejecutar metodo
            return ProduccionCabeRN.ListarProduccionCabeXEstado(iProCabEN);
        }

        public static void ModificarProduccionCabe(ProduccionCabeEN pObj, List<ProduccionCabeEN> pLista)
        {
            //lista actualizada
            List<ProduccionCabeEN> iLisProCab = new List<ProduccionCabeEN>();

            //buscamos el objeto en la lista pLista
            foreach (ProduccionCabeEN xProCab in pLista)
            {
                if (xProCab.ClaveProduccionCabe == pObj.ClaveProduccionCabe)
                {
                    xProCab.VerdadFalso = pObj.VerdadFalso;
                }
                iLisProCab.Add(xProCab);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisProCab);
        }

        public static List<ProduccionCabeEN> ListarVentanaProduccionCabeSoloMarcadas(List<ProduccionCabeEN> pLista)
        {
            //lista resultado
            List<ProduccionCabeEN> iLisRes = new List<ProduccionCabeEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (ProduccionCabeEN xVenBot in pLista)
            {
                if (xVenBot.VerdadFalso == true)
                {
                    iLisRes.Add(xVenBot);
                }
            }
            return iLisRes;
        }

        public static void ModificarProduccionCabeAEstadoCompra(List<ProduccionCabeEN> pLista)
        {
            //recorrer cada objeto
            foreach (ProduccionCabeEN xProCab in pLista)
            {
                xProCab.CEstadoProduccionCabe = "1";//compra
            }

            //modificar
            ProduccionCabeRN.ModificarProduccionCabe(pLista);
        }

        public static void ModificarProduccionCabeAEstadoPlanificacion(List<ProduccionCabeEN> pLista)
        {
            //recorrer cada objeto
            foreach (ProduccionCabeEN xProCab in pLista)
            {
                xProCab.CEstadoProduccionCabe = "0";//planificacion
            }

            //modificar
            ProduccionCabeRN.ModificarProduccionCabe(pLista);
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesAComprar()
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //lista de todas las solicitudes que intervienen para desccarga del almacen
            List<ProduccionCabeEN> iLisProCabTot = new List<ProduccionCabeEN>();

            //agregar las solicitudes que estan en estado terminado pero que su orden de 
            //trabajo no ha descargado sus insumos
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeTerminadosYSinDescargaInsumos());
           
            //agregar las solicitudes que estan en estado "aprobado"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoAprobado());
           
            //agregar las solicitudes que estan en estado "Compra"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoCompra());
           
            //obtener la lista de todas las produccionesExis en con montos acumulados de estas solicitudes
            List<ProduccionExisEN> iLisProExiAcu = ProduccionExisRN.ListarProduccionExisAcumulados(iLisProCabTot);
           
            //obtener la lista de solo los insumos que no completan lo que pide las solicitudes
            iLisRes = ProduccionExisRN.ListarInsumosFaltantesParaCompra(iLisProExiAcu);
          
            //devolver
            return iLisRes;
        }

        public static void AprobarSolicitudesDeCompra()
        {
            //traer a las solicitudes que estan en estado "Compra"
            List<ProduccionCabeEN> iLisProCabCom = ProduccionCabeRN.ListarProduccionCabeEstadoCompra();

            //recorrer cada objeto
            foreach (ProduccionCabeEN xProCab in iLisProCabCom)
            {
                xProCab.CEstadoProduccionCabe = "2";//aprobado
            }

            //modificar masivo
            ProduccionCabeRN.ModificarProduccionCabe(iLisProCabCom);
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeEstadoAprobado()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CEstadoProduccionCabe = "2";//aprobado
            iProCabEN.Adicionales.CampoOrden = ProduccionCabeEN.CorProCab;

            //ejecutar metodo
            return ProduccionCabeRN.ListarProduccionCabeXEstado(iProCabEN);
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeAprobadasDeAlmacen(ProduccionCabeEN pObj)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.ListarProduccionCabeAprobadasDeAlmacen(pObj);
        }

        public static ProduccionCabeEN EsProduccionCabeAprobadaValido(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CorrelativoProduccionCabe == string.Empty) { return iProCabEN; }

            //valida cuando el codigo no existe
            iProCabEN = ProduccionCabeRN.EsProduccionCabeExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no esta pendiente
            ProduccionCabeEN iProCabAprEN = ProduccionCabeRN.ValidaCuandoNoEstaAprobada(iProCabEN);
            if (iProCabAprEN.Adicionales.EsVerdad == false) { return iProCabAprEN; }

            //ok           
            return iProCabEN;
        }

        public static ProduccionCabeEN ValidaCuandoNoEstaAprobada(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida 
            if (pObj.CEstadoProduccionCabe != "2")//pendiente
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La solicitud debe estar aprobada";
                return iProCabEN;
            }

            //ok           
            return iProCabEN;
        }
                
        public static List<ProduccionCabeEN> ListarProduccionCabeTerminadosYSinDescargaInsumos()
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.ListarProduccionCabeTerminadosYSinDescargaInsumos();
        }

        public static List<InsumoFaltante> ListarInsumosPlanificacion()
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //lista de todas las solicitudes que intervienen para descarga del almacen
            List<ProduccionCabeEN> iLisProCabTot = new List<ProduccionCabeEN>();

            //agregar las solicitudes que estan en estado terminado pero que su orden de 
            //trabajo no ha descargado sus insumos
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeTerminadosYSinDescargaInsumos());

            //agregar las solicitudes que estan en estado "aprobado"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoAprobado());

            //agregar las solicitudes que estan en estado "Compra"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoCompra());

            //agregar las solicitudes que estan en estado "Planificado"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoPlanificado());

            //obtener la lista de todas las produccionesExis de estas solicitudes
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExis(iLisProCabTot);

            //obtener la lista de solo los insumos que pide las solicitudes
            iLisRes = ProduccionExisRN.ListarInsumosPlanificacion(iLisProExi);

            //devolver
            return iLisRes;
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeEstadoPlanificado()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CEstadoProduccionCabe = "0";//planificado
            iProCabEN.Adicionales.CampoOrden = ProduccionCabeEN.CorProCab;

            //ejecutar metodo
            return ProduccionCabeRN.ListarProduccionCabeXEstado(iProCabEN);
        }

        public static ProduccionCabeEN CrearProduccionCabeParaMigracion(string pCorrelativoProCab, ProduccionDetaEN pObjExcel)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //pasar datos
            iProCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iProCabEN.CorrelativoProduccionCabe = pCorrelativoProCab;
            iProCabEN.FechaProduccionCabe = pObjExcel.FechaProduccionDeta;
            iProCabEN.PeriodoProduccionCabe = Fecha.ObtenerPeriodo(iProCabEN.FechaProduccionCabe, "-");
            iProCabEN.CodigoAlmacen = pObjExcel.CodigoAlmacen;
            iProCabEN.CodigoExistencia = pObjExcel.CodigoExistencia;
            iProCabEN.CodigoUnidadMedida = "";//xxxxxxxxxxxxx
            iProCabEN.CodigoMercaderia = pObjExcel.CodigoMercaderia;
            iProCabEN.CEsExacto = "1";
            iProCabEN.CantidadFormula = 0;
            iProCabEN.CantidadProduccionCabe = pObjExcel.CantidadProduccionDeta;
            iProCabEN.CantidadProducidaProduccionCabe = pObjExcel.CantidadProduccionDeta;
            iProCabEN.SaldoProduccionCabe = 0;
            iProCabEN.CantidadRealProduccion = pObjExcel.CantidadRealProduccion;
            iProCabEN.CTurno = pObjExcel.CTurno;
            iProCabEN.ObservacionProduccionCabe = "MIGRACION PRODUCCION 2019";
            iProCabEN.CEstadoProduccionCabe = "3";//terminado
            iProCabEN.ClaveProduccionCabe = ProduccionCabeRN.ObtenerClaveProduccionCabe(iProCabEN);

            //devolver
            return iProCabEN;
        }

        public static void MarcarTodos(List<ProduccionCabeEN> pLista, bool pPermitir)
        {
            //lista actualizada
            List<ProduccionCabeEN> iLisProCab = new List<ProduccionCabeEN>();

            //buscamos el objeto en la lista pLista
            foreach (ProduccionCabeEN xProCab in pLista)
            {
                xProCab.VerdadFalso = pPermitir;               
                iLisProCab.Add(xProCab);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisProCab);
        }

        public static decimal ObtenerCantidadSugeridaParaReprocesar(ProduccionCabeEN pObj)
        {
            //obtener el objeto formula
            FormulaCabeEN iForCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(ProduccionCabeRN.ObtenerClaveFormulaCabe(pObj));

            //traer el saldo de unidades para reproceso
            decimal iSaldo = ProduccionCabeRN.ObtenerSaldoUnidadesParaReprocesar("A18", iForCabEN.CodigoSemiProducto);

            //si el objeto produccion esta creado en bd
            if (pObj.UsuarioAgrega != string.Empty)
            {
                //traer al objeto de bd
                ProduccionCabeEN iProCabEN = ProduccionCabeRN.BuscarProduccionCabeXClave(pObj);

                //le volvemos a sumar este monto
                iSaldo += iProCabEN.UnidadesReproceso;
            }

            //devolver
            return iSaldo;
        }

        public static string ObtenerClaveFormulaCabe(ProduccionCabeEN pObj)
        {
            //asignar parametros
            FormulaCabeEN iForCabEN = new FormulaCabeEN();
            iForCabEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iForCabEN.CodigoExistencia = pObj.CodigoExistencia;

            //ejecutar metodo
            return FormulaCabeRN.ObtenerClaveFormulaCabe(iForCabEN);            
        }

        public static decimal ObtenerSaldoUnidadesParaReprocesar(ExistenciaEN pExiUniParRep, List<ProduccionDetaEN> pLisProDetPenRep,
            List<ProduccionCabeEN> pLisProCabCalRep)
        {
            //de la lista de ProduccionesDeta que tienen una cantidad para reprocesar pero que aun no han 
            //generado la salida de la existencia de reproceso,debemos obtener la cantidad total de unidades
            //pendientes
            decimal iCantidadPendienteReproceso = ListaG.Sumar<ProduccionDetaEN>(pLisProDetPenRep, ProduccionDetaEN.UniRep);

            //sacar de la lista de solicitudes las unidades que tienen para reprocesar
            decimal iCantidadSolicitudReproceso = ListaG.Sumar<ProduccionCabeEN>(pLisProCabCalRep, ProduccionDetaEN.UniRep);

            //restamos la cantidad que hay en la existencia con esta cantidad pendiente
            decimal iSaldo = pExiUniParRep.StockActualExistencia - iCantidadPendienteReproceso - iCantidadSolicitudReproceso;

            //devolver
            return iSaldo;
        }

        public static decimal ObtenerSaldoUnidadesParaReprocesar(string pCodAlmRep, string pCodExiSemEla)
        {
            //asignar parametros
            //obtener a la existencia del almacen de reproceso
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pCodAlmRep, pCodExiSemEla);

            //obtener la lista de Produccionesdeta que tienen para reprocesar pero aun no lo reprocesan
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaQueFaltanReprocesar(pCodExiSemEla);

            //obtener la lista de ProduccionesCabe de este semiElaborado para calculo de saldo unidades a reprocesar
            List<ProduccionCabeEN> iLisProCab = ProduccionCabeRN.ListarProduccionCabeParaCalculoUnidadesReprocesar(pCodExiSemEla);

            //ejecutar metodo
            return ProduccionCabeRN.ObtenerSaldoUnidadesParaReprocesar(iExiEN, iLisProDet, iLisProCab);
        }

        public static List<ProduccionCabeEN> ListarProduccionCabeParaCalculoUnidadesReprocesar(string pCodExiSemEla)
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.ListarProduccionCabeParaCalculoUnidadesReprocesar(pCodExiSemEla);
        }

        public static ProduccionCabeEN EsCantidadReprocesoCorrecta(ProduccionCabeEN pObj)
        {
            //valor resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida cuando codigoExistencia esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iProCabEN; }

            //valida cuando la cantidad digitado es mayor a la cantidad que tiene para reprocesar
            ProduccionCabeEN iProCabMayEN = ProduccionCabeRN.ValidaCuandoCantidadReprocesoDigitadoEsMayorACantidadParaReprocesarAnterior(pObj);
            if (iProCabMayEN.Adicionales.EsVerdad == false) { return iProCabMayEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionCabeEN ValidaCuandoCantidadReprocesoDigitadoEsMayorACantidadParaReprocesarAnterior(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //validar            
            decimal iSaldoReproceso = ProduccionCabeRN.ObtenerCantidadSugeridaParaReprocesar(pObj);

            //validando
            if (iSaldoReproceso < pObj.UnidadesReproceso)
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La cantidad de unidades a reprocesar no puede ser mayor a " + iSaldoReproceso.ToString();
            }

            //devolver
            return iProCabEN;
        }

        public static List<ProduccionCabeEN> ListarProduccionCabesParaGenerarPartesTrabajo()
        {
            ProduccionCabeAD iProAD = new ProduccionCabeAD();
            return iProAD.ListarProduccionCabesParaGenerarPartesTrabajo();
        }

        public static ProduccionCabeEN ValidaCuandoHayFormulasDetaConCantidadCero(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida 
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(ObtenerClaveFormulaCabe(pObj));
            iLisForDet = ListaG.Filtrar<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CanForDet, "0.00000");
            if (iLisForDet.Count != 0)
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La formula elegida contiene cantidades en cero";                
            }

            //ok           
            return iProCabEN;
        }

        public static ProduccionCabeEN ValidaCuandoHayFormulasDetaConElementosRepetidos(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida 
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(ObtenerClaveFormulaCabe(pObj));
            List<FormulaDetaEN> iLisForDetSinRep = ListaG.FiltrarObjetosSinRepetir<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExi);
            if (iLisForDet.Count != iLisForDetSinRep.Count)
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La formula elegida contiene elementos con existencias repetidas";
            }

            //ok           
            return iProCabEN;
        }

        public static ProduccionCabeEN EsFormulaCorrecta(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //valida cuando hay ceros
            //iProCabEN = ValidaCuandoHayFormulasDetaConCantidadCero(pObj);
            //if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando hay elementos repetidos
            iProCabEN = ValidaCuandoHayFormulasDetaConElementosRepetidos(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //ok
            return iProCabEN;
        }

        public static string ConvertirListaACampoDetalleFormulasDeta(List<FormulaDetaEN> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //---------
            //convertir
            //---------

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in pLista)
            {
                iValor += xForDet.CodigoExistencia + "|";
            }

            //devolver
            return iValor;
        }

        public static string ArmarCampoDetalleFormulasDeta(ProduccionCabeEN pObj)
        {
            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaParaDetalleFormulasDeta(ObtenerClaveFormulaCabe(pObj));

            //ejecutar metodo
            return ConvertirListaACampoDetalleFormulasDeta(iLisForDet);
        }

        public static List<FormulaDetaEN> ConvertirCampoDetalleFormulasDetaALista(string pDetalleFormulasDeta)
        {
            //lista resultado
            List<FormulaDetaEN> iLisRes = new List<FormulaDetaEN>();

            //---------
            //convertir
            //---------

            //obtener la lista de cadenas que corresponden a cada liberacionProTer
            List<string> iLisForDet = Cadena.ListarPalabrasDeTexto(pDetalleFormulasDeta, "|");

            //recorrer cada cadena
            foreach (string xStr in iLisForDet)
            {
                //si la cadena esta vacia,termino el proceso
                if (xStr.Trim() == string.Empty) { break; }

                //creamos un nuevo objeto LiberacionProTer
                FormulaDetaEN iForDet = new FormulaDetaEN();

                //pasamos sus datos
                iForDet.CodigoExistencia = xStr;
                
                //agregar a lista resultado
                iLisRes.Add(iForDet);
            }

            //devolver
            return iLisRes;
        }

        public static ProduccionCabeEN BuscarProduccionCabeXClave(string pClaveProduccionCabe)
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.ClaveProduccionCabe = pClaveProduccionCabe;

            //ejecutar metodo
            return BuscarProduccionCabeXClave(iProCabEN);
        }

        public static decimal ObtenerPorcentajeRango(ProduccionCabeEN pObj)
        {
            //asignar parametros
            decimal iCantidad = pObj.CantidadProduccionCabe + pObj.UnidadesReproceso;
            List<RangoDetaEN> iLisRanDetFasEnv = RangoDetaRN.ListarRangosDeta(pObj);

            //ejecutar metodo
            return RangoDetaRN.ObtenerPorcentajeRangoDetaDeCantidad(iCantidad, iLisRanDetFasEnv);
        }

        public static decimal ObtenerCantidadRango(ProduccionCabeEN pObj)
        {
            return ((pObj.CantidadProduccionCabe + pObj.UnidadesReproceso) * pObj.PorcentajeRango) / 100;
        }

        public static decimal ObtenerPorcentajeRangoSincerado(ProduccionCabeEN pObj)
        {
            //asignar parametros
            pObj.CantidadProduccionCabe = pObj.CantidadSinceradoProduccionCabe;

            //ejecutar metodo
            return ObtenerPorcentajeRango(pObj);
        }

        public static decimal ObtenerCantidadRangoSincerado(ProduccionCabeEN pObj)
        {
            //asignar parametros
            pObj.CantidadProduccionCabe = pObj.CantidadSinceradoProduccionCabe;
            pObj.PorcentajeRango = pObj.PorcentajeSinceradoRango;

            //ejecutar metodo

            return ObtenerCantidadRango(pObj);
        }

        public static ProduccionCabeEN EsValidoCantidadSincerado(ProduccionCabeEN pObj)
        {
            //valor resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //validar
            if (pObj.CantidadSinceradoProduccionCabe > pObj.CantidadProduccionCabe)
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La cantidad sincerada no puede ser mayor que la cantidad original";
            }
            
            //ok
            return iProCabEN;
        }

    }
}
