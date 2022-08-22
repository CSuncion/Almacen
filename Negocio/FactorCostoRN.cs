using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using System.Windows.Forms;

namespace Negocio
{
    public class FactorCostoRN
    {

        public static FactorCostoEN EnBlanco()
        {
            FactorCostoEN iPerEN = new FactorCostoEN();
            return iPerEN;
        }

        public static void AdicionarFactorCosto(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            iPerAD.AgregarFactorCosto(pObj);
        }

        public static void ModificarFactorCosto(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            iPerAD.ModificarFactorCosto(pObj);
        }

        public static void ModificarEstadoFactorCostoDeAño(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            iPerAD.ModificarEstadoFactorCostoDeAño(pObj);
        }

        public static void EliminarFactorCosto(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            iPerAD.EliminarFactorCosto(pObj);
        }

        public static List<FactorCostoEN> ListarFactorCostos(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            return iPerAD.ListarFactorCostos(pObj);
        }

        public static List<FactorCostoEN> ListarFactorCostos()
        {
            //asignar parametros
            FactorCostoEN iPerEN = new FactorCostoEN();
            iPerEN.Adicionales.CampoOrden = FactorCostoEN.ClaFacCos;

            //ejecutar metodo
            return FactorCostoRN.ListarFactorCostos(iPerEN);
        }

        public static List<FactorCostoEN> ListarFactorCostosXEstado(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            return iPerAD.ListarFactorCostosXEstado(pObj);
        }

        public static FactorCostoEN BuscarFactorCostoXClave(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            return iPerAD.BuscarFactorCostoXClave(pObj);
        }

        public static FactorCostoEN BuscarFactorCostoXCodigo(FactorCostoEN pObj)
        {       
            //ejecutar metodo
            return FactorCostoRN.BuscarFactorCostoXCodigo(pObj.CodigoFactorCosto);
        }

        public static FactorCostoEN BuscarFactorCostoXCodigo(string pCodigoFactorCosto)
        {
            //asignar parametros
            FactorCostoEN iPerEN = new FactorCostoEN();
            iPerEN.AnoFactorCosto = Periodo.ObtenerAñoPeriodo( pCodigoFactorCosto);
            iPerEN.CMesFactorCosto = Periodo.ObtenerCMesPeriodo(pCodigoFactorCosto);
            iPerEN.ClaveFactorCosto = FactorCostoRN.ObtenerClaveFactorCosto(iPerEN);

            //ejecutar metodo
            return FactorCostoRN.BuscarFactorCostoXClave(iPerEN);
        }

        public static FactorCostoEN EsFactorCostoExistente(FactorCostoEN pObj)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //validar si existe en b.d           
            pObj.AnoFactorCosto = AñoMes.ObtenerAñoPeriodo(pObj.CodigoFactorCosto);
            pObj.CMesFactorCosto = AñoMes.ObtenerCMesPeriodo(pObj.CodigoFactorCosto);
            pObj.ClaveFactorCosto = FactorCostoRN.ObtenerClaveFactorCosto(pObj);
            iPerEN = FactorCostoRN.BuscarFactorCostoXClave(pObj);
            if (iPerEN.ClaveFactorCosto == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El FactorCosto " + pObj.AnoFactorCosto + " - " + Fecha.ObtenerMesEnNombre(pObj.CMesFactorCosto) + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static FactorCostoEN EsFactorCostoDisponible(FactorCostoEN pObj)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //validar que los dos campos esten llenos
            if (pObj.AnoFactorCosto != string.Empty && pObj.CMesFactorCosto != string.Empty)
            {
                //buscar por clave FactorCosto
                iPerEN = FactorCostoRN.BuscarFactorCostoXClave(pObj);
                if (iPerEN.ClaveFactorCosto != string.Empty)
                {
                    iPerEN.Adicionales.EsVerdad = false;
                    iPerEN.Adicionales.Mensaje = "El FactorCosto " + pObj.AnoFactorCosto + " - " + pObj.NMesFactorCosto + " ya esta registrado";
                    return iPerEN;
                }
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(FactorCostoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case FactorCostoEN.ClaObj: return pObj.ClaveObjeto;
                case FactorCostoEN.ClaFacCos: return pObj.ClaveFactorCosto;
                case FactorCostoEN.CodFacCos: return pObj.CodigoFactorCosto;
                case FactorCostoEN.CodEmp: return pObj.CodigoEmpresa;
                case FactorCostoEN.NomEmp: return pObj.NombreEmpresa;
                case FactorCostoEN.AnoFacCos: return pObj.AnoFactorCosto;
                case FactorCostoEN.CMesFacCos: return pObj.CMesFactorCosto;
                case FactorCostoEN.NMesFacCos: return pObj.NMesFactorCosto;
                case FactorCostoEN.CEstFacCos: return pObj.CEstadoFactorCosto;
                case FactorCostoEN.NEstFacCos: return pObj.NEstadoFactorCosto;
                case FactorCostoEN.UsuAgr: return pObj.UsuarioAgrega;
                case FactorCostoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case FactorCostoEN.UsuMod: return pObj.UsuarioModifica;
                case FactorCostoEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<FactorCostoEN> FiltrarFactorCostosXTextoEnCualquierPosicion(List<FactorCostoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<FactorCostoEN> iLisRes = new List<FactorCostoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (FactorCostoEN xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<FactorCostoEN>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<FactorCostoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<FactorCostoEN> pListaFactorCostos)
        {
            //lista resultado
            List<FactorCostoEN> iLisRes = new List<FactorCostoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaFactorCostos; }

            //filtar la lista
            iLisRes = FactorCostoRN.FiltrarFactorCostosXTextoEnCualquierPosicion(pListaFactorCostos, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveFactorCosto(FactorCostoEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;
            
            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.AnoFactorCosto + "-";
            iClave += pPer.CMesFactorCosto;

            //retornar
            return iClave;
        }

        public static string ObtenerClaveFactorCosto(string pAño, string pCMes)
        {
            //asignar parametros
            FactorCostoEN iPerEN = new FactorCostoEN();
            iPerEN.AnoFactorCosto = pAño;
            iPerEN.CMesFactorCosto = pCMes;

            //ejecutar metodo
            return FactorCostoRN.ObtenerClaveFactorCosto(iPerEN);
        }

        public static FactorCostoEN EsActoEliminarFactorCosto(FactorCostoEN pPer)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //validar si existe
            iPerEN = FactorCostoRN.EsFactorCostoExistente(pPer);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }

        public static FactorCostoEN EsActoRegistrarEnEsteFactorCosto(FactorCostoEN pPer)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //valida cuando el FactorCosto esta vacio
            iPerEN = FactorCostoRN.ValidaCuandoFactorCostoEstaVacio(pPer.CodigoFactorCosto);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe
            iPerEN = FactorCostoRN.EsFactorCostoExistente(pPer);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si esta cerrado
            FactorCostoEN iPerCerEN = FactorCostoRN.ValidaFactorCostoCerrado(iPerEN);
            if (iPerCerEN.Adicionales.EsVerdad == false) { return iPerCerEN; }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static FactorCostoEN ValidaFactorCostoCerrado(FactorCostoEN pPer)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //valida
            if (pPer.CEstadoFactorCosto == "0")//cerrado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El FactorCosto " + pPer.AnoFactorCosto + " : " + pPer.NMesFactorCosto +
                                                " esta cerrado, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerClaveFactorCosto(string pFecha)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += Fecha.ObtenerAño(pFecha) + "-";
            iClave += Fecha.ObtenerMes(pFecha);

            //retornar
            return iClave;
        }

        public static FactorCostoEN ValidaCuandoFactorCostoEstaVacio(string pCodigoFactorCosto)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //validar
            if (pCodigoFactorCosto == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Debes Elegir un FactorCosto, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static FactorCostoEN ExisteFactorCostoDeFecha(string pFecha,string pNombreFecha)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //-------
            //validar
            //-------
            iPerEN.ClaveFactorCosto = FactorCostoRN.ObtenerClaveFactorCosto(pFecha);
            iPerEN = FactorCostoRN.BuscarFactorCostoXClave(iPerEN);
            if (iPerEN.ClaveFactorCosto == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El FactorCosto de la fecha " + pNombreFecha + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static FactorCostoEN BuscarFactorCostoDeFecha(string pFecha)
        {
            //asignar parametros
            FactorCostoEN iPerEN = new FactorCostoEN();
            iPerEN.ClaveFactorCosto = FactorCostoRN.ObtenerClaveFactorCosto(pFecha);

            //ejecutar metodo
            return FactorCostoRN.BuscarFactorCostoXClave(iPerEN);
        }

        public static FactorCostoEN EsActoRegistrarEnFactorCostoDeEstaFecha(string pFecha,string pNombreFecha)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //valida si existe
            iPerEN = FactorCostoRN.ExisteFactorCostoDeFecha(pFecha, pNombreFecha);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si esta cerrado
            FactorCostoEN iPerCerEN = FactorCostoRN.ValidaFactorCostoCerrado(iPerEN,pNombreFecha);
            if (iPerCerEN.Adicionales.EsVerdad == false) { return iPerCerEN; }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static FactorCostoEN ValidaFactorCostoCerrado(FactorCostoEN pPer, string pNombreFecha)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //valida
            if (pPer.CEstadoFactorCosto == "0")//cerrado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El FactorCosto de la fecha " + pNombreFecha + " esta cerrado, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static List<FactorCostoEN> ListarFactorCostosXAñoYEstado(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            return iPerAD.ListarFactorCostosXAñoYEstado(pObj);
        }

        public static FactorCostoEN HayFactorCostosDeAñoYActivos(string pAñoFactorCosto)
        {
            //objeto resultado
            FactorCostoEN iPerEN = new FactorCostoEN();

            //validar
            iPerEN.AnoFactorCosto = pAñoFactorCosto;
            iPerEN.CEstadoFactorCosto = "1";//activos
            iPerEN.Adicionales.CampoOrden = FactorCostoEN.ClaFacCos;
            List<FactorCostoEN> iLisPer = FactorCostoRN.ListarFactorCostosXAñoYEstado(iPerEN);
            if (iLisPer.Count == 0)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "No hay FactorCostos activos en este año";
            }

            return iPerEN;
        }

        public static List<string> ListarAñosFactorCostos()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traemos todos los FactorCostos que existen en la empresa actual(estan ordenados por su clave)
            List<FactorCostoEN> iLisPer = FactorCostoRN.ListarFactorCostos();

            //variables
            string iAño = string.Empty;

            //recorrer cada objeto
            foreach (FactorCostoEN xPer in iLisPer)
            {
                if (xPer.AnoFactorCosto != iAño)
                {
                    iLisRes.Add(xPer.AnoFactorCosto);
                    iAño = xPer.AnoFactorCosto;
                }
            }

            //devolver
            return iLisRes;
        }

        public static FactorCostoEN BuscarFactorCosto(ProduccionDetaEN pObj)
        {
            //obtener el periodo anterior de esta parte de trabajo
            string iCodigoPeriodoAnt = pObj.PeriodoProduccionDeta;
            
            //buscar este factor en bd
            return FactorCostoRN.BuscarFactorCostoXCodigo(iCodigoPeriodoAnt);
        }

        public static decimal ObtenerFactorCosto(ProduccionDetaEN pObj)
        {
            //asignar parametros
            FactorCostoEN iFacCosEN = FactorCostoRN.BuscarFactorCosto(pObj);

            //devolver
            return iFacCosEN.Factor;
        }

        public static decimal ObtenerFactorCostoParaRecalculoManoObra(string pAño, string pCodigoMes)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.PeriodoProduccionDeta = Formato.UnionDosTextos(pAño, pCodigoMes, "-");

            //ejecutar metodo
            return FactorCostoRN.ObtenerFactorCosto(iProDetEN);
        }

        public static decimal ObtenerFactorCosto(EncajadoEN pObj)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.PeriodoProduccionDeta = pObj.PeriodoEncajado;

            //devolver
            return FactorCostoRN.ObtenerFactorCosto(iProDetEN);
        }

        public static decimal ObtenerFactorCosto(RetiquetadoEN pObj)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.PeriodoProduccionDeta = pObj.PeriodoRetiquetado;

            //devolver
            return FactorCostoRN.ObtenerFactorCosto(iProDetEN);
        }

    }
}
