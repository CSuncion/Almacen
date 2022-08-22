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
    public class FactorCIFRN
    {

        public static FactorCIFEN EnBlanco()
        {
            FactorCIFEN iFacCifEN = new FactorCIFEN();
            return iFacCifEN;
        }

        public static void AdicionarFactorCIF(FactorCIFEN pObj)
        {
            FactorCIFAD iFacCifAD = new FactorCIFAD();
            iFacCifAD.AgregarFactorCIF(pObj);
        }

        public static void ModificarFactorCIF(FactorCIFEN pObj)
        {
            FactorCIFAD iPerAD = new FactorCIFAD();
            iPerAD.ModificarFactorCIF(pObj);
        }

        public static void ModificarEstadoFactorCostoDeAño(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            iPerAD.ModificarEstadoFactorCostoDeAño(pObj);
        }

        public static void EliminarFactorCosto(FactorCIFEN pObj)
        {
            FactorCIFAD iPerAD = new FactorCIFAD();
            iPerAD.EliminarFactorCosto(pObj);
        }

        public static List<FactorCIFEN> ListarFactorCostos(FactorCIFEN pObj)
        {
            FactorCIFAD iPerAD = new FactorCIFAD();
            return iPerAD.ListarFactorCostos(pObj);
        }

        public static List<FactorCIFEN> ListarFactorCostos()
        {
            //asignar parametros
            FactorCIFEN iPerEN = new FactorCIFEN();
            iPerEN.Adicionales.CampoOrden = FactorCIFEN.ClaFacCif;

            //ejecutar metodo
            return FactorCIFRN.ListarFactorCostos(iPerEN);
        }

        public static List<FactorCostoEN> ListarFactorCostosXEstado(FactorCostoEN pObj)
        {
            FactorCostoAD iPerAD = new FactorCostoAD();
            return iPerAD.ListarFactorCostosXEstado(pObj);
        }

        public static FactorCIFEN BuscarFactorCIFXClave(FactorCIFEN pObj)
        {
            FactorCIFAD iPerAD = new FactorCIFAD();
            return iPerAD.BuscarFactorCIFXClave(pObj);
        }

        public static FactorCIFEN BuscarFactorCostoXCodigo(string pCodigoFactorCosto)
        {
            //asignar parametros
            FactorCIFEN iPerEN = new FactorCIFEN();
            iPerEN.AnoFactorCif = Periodo.ObtenerAñoPeriodo( pCodigoFactorCosto);
            iPerEN.CMesFactorCif = Periodo.ObtenerCMesPeriodo(pCodigoFactorCosto);
            iPerEN.ClaveFactorCif = ObtenerClaveFactorCosto(iPerEN);

            //ejecutar metodo
            return BuscarFactorCIFXClave(iPerEN);
        }

        public static FactorCIFEN EsFactorCostoExistente(FactorCIFEN pObj)
        {
            //objeto resultado
            FactorCIFEN iPerEN = new FactorCIFEN();

            //validar si existe en b.d           
            pObj.AnoFactorCif = AñoMes.ObtenerAñoPeriodo(pObj.CodigoFactorCif);
            pObj.CMesFactorCif = AñoMes.ObtenerCMesPeriodo(pObj.CodigoFactorCif);
            pObj.ClaveFactorCif = FactorCIFRN.ObtenerClaveFactorCosto(pObj);
            iPerEN = FactorCIFRN.BuscarFactorCIFXClave(pObj);
            if (iPerEN.ClaveFactorCif == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El FactorCIF " + pObj.AnoFactorCif + " - " + Fecha.ObtenerMesEnNombre(pObj.CMesFactorCif) + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static FactorCIFEN EsFactorCostoDisponible(FactorCIFEN pObj)
        {
            //objeto resultado
            FactorCIFEN iPerEN = new FactorCIFEN();

            //validar que los dos campos esten llenos
            if (pObj.AnoFactorCif != string.Empty && pObj.CMesFactorCif != string.Empty)
            {
                //buscar por clave FactorCosto
                iPerEN = FactorCIFRN.BuscarFactorCIFXClave(pObj);
                if (iPerEN.ClaveFactorCif != string.Empty)
                {
                    iPerEN.Adicionales.EsVerdad = false;
                    iPerEN.Adicionales.Mensaje = "El FactorCif " + pObj.AnoFactorCif + " - " + pObj.NMesFactorCif + " ya esta registrado";
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

        public static List<FactorCIFEN> FiltrarFactorCostosXTextoEnCualquierPosicion(List<FactorCIFEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<FactorCIFEN> iLisRes = new List<FactorCIFEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (FactorCIFEN xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<FactorCIFEN>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<FactorCIFEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<FactorCIFEN> pListaFactorCostos)
        {
            //lista resultado
            List<FactorCIFEN> iLisRes = new List<FactorCIFEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaFactorCostos; }

            //filtar la lista
            iLisRes = FactorCIFRN.FiltrarFactorCostosXTextoEnCualquierPosicion(pListaFactorCostos, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveFactorCosto(FactorCIFEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;
            
            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.AnoFactorCif + "-";
            iClave += pPer.CMesFactorCif;

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

        public static FactorCIFEN EsActoEliminarFactorCosto(FactorCIFEN pPer)
        {
            //objeto resultado
            FactorCIFEN iPerEN = new FactorCIFEN();

            //validar si existe
            iPerEN = FactorCIFRN.EsFactorCostoExistente(pPer);
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

        public static FactorCIFEN BuscarFactorCosto(EncajadoEN pObj)
        {
            //buscar este factor en bd
            return BuscarFactorCostoXCodigo(pObj.PeriodoEncajado);
        }

        public static FactorCIFEN BuscarFactorCosto(ProduccionDetaEN pObj)
        {
            //buscar este factor en bd
            return BuscarFactorCostoXCodigo(pObj.PeriodoProduccionDeta);
        }

        public static decimal ObtenerFactorCostoCifParaRecalculoGastosIndirectos(string pAño, string pCodigoMes)
        {
            //asignar parametros
            EncajadoEN iEncEN = new EncajadoEN();
            iEncEN.PeriodoEncajado = Formato.UnionDosTextos(pAño, pCodigoMes, "-");

            //ejecutar metodo
            return ObtenerFactorCIF(iEncEN);
        }

        public static decimal ObtenerFactorCIF(EncajadoEN pObj)
        {
            //asignar parametros
            FactorCIFEN iFacCifEN = BuscarFactorCosto(pObj);

            //devolver
            return iFacCifEN.FactorCif;
        }

        public static decimal ObtenerFactorCIFFijo(FactorCIFEN pObj)
        {            
            return Math.Round( Operador.DivisionDecimal(pObj.DepreciacionFactorCif + pObj.AlquilerFactorCif, pObj.CantidadKilosFactorCif),2);
        }

        public static decimal ObtenerFactorCIFVariable(FactorCIFEN pObj)
        {
            return pObj.FactorCif - ObtenerFactorCIFFijo(pObj);
        }

        public static FactorCIFEN BuscarFactorCosto(string pAño, string pCodigoMes)
        {
            //asignar parametros
            EncajadoEN iEncEN = new EncajadoEN();
            iEncEN.PeriodoEncajado = Formato.UnionDosTextos(pAño, pCodigoMes, "-");

            //ejecutar metodo
            return BuscarFactorCosto(iEncEN);
        }

        public static FactorCIFEN BuscarFactorCosto(RetiquetadoEN pObj)
        {
            //buscar este factor en bd
            return BuscarFactorCostoXCodigo(pObj.PeriodoRetiquetado);
        }


    }
}
