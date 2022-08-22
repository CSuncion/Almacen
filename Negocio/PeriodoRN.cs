using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;


namespace Negocio
{
    public class PeriodoRN
    {

        public static PeriodoEN EnBlanco()
        {
            PeriodoEN iPerEN = new PeriodoEN();
            return iPerEN;
        }

        public static void AdicionarPeriodo(PeriodoEN pObj)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            iPerAD.AgregarPeriodo(pObj);
        }

        public static void ModificarPeriodo(PeriodoEN pObj)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            iPerAD.ModificarPeriodo(pObj);
        }

        public static void ModificarEstadoPeriodoDeAño(PeriodoEN pObj)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            iPerAD.ModificarEstadoPeriodoDeAño(pObj);
        }

        public static void EliminarPeriodo(PeriodoEN pObj)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            iPerAD.EliminarPeriodo(pObj);
        }

        public static List<PeriodoEN> ListarPeriodos(PeriodoEN pObj)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            return iPerAD.ListarPeriodos(pObj);
        }

        public static List<PeriodoEN> ListarPeriodos()
        {
            //asignar parametros
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.Adicionales.CampoOrden = PeriodoEN.ClaPer;

            //ejecutar metodo
            return PeriodoRN.ListarPeriodos(iPerEN);
        }

        public static List<PeriodoEN> ListarPeriodosXEstado(PeriodoEN pObj)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            return iPerAD.ListarPeriodosXEstado(pObj);
        }

        public static PeriodoEN BuscarPeriodoXClave(PeriodoEN pObj)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            return iPerAD.BuscarPeriodoXClave(pObj);
        }

        public static PeriodoEN BuscarPeriodoXCodigo(PeriodoEN pObj)
        {       
            //ejecutar metodo
            return PeriodoRN.BuscarPeriodoXCodigo(pObj.CodigoPeriodo);
        }

        public static PeriodoEN BuscarPeriodoXCodigo(string pCodigoPeriodo)
        {
            //asignar parametros
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pCodigoPeriodo;
            iPerEN.ClavePeriodo = PeriodoRN.ObtenerClavePeriodo(iPerEN);

            //ejecutar metodo
            return PeriodoRN.BuscarPeriodoXClave(iPerEN);
        }

        public static PeriodoEN EsPeriodoExistente(PeriodoEN pObj)
        {           
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //validar si existe en b.d           
            pObj.AnoPeriodo = AñoMes.ObtenerAñoPeriodo(pObj.CodigoPeriodo);
            pObj.CMesPeriodo = AñoMes.ObtenerCMesPeriodo(pObj.CodigoPeriodo);
            pObj.ClavePeriodo = PeriodoRN.ObtenerClavePeriodo(pObj);
            iPerEN = PeriodoRN.BuscarPeriodoXClave(pObj);
            if (iPerEN.ClavePeriodo == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Periodo " + pObj.AnoPeriodo + " - " + Fecha.ObtenerMesEnNombre(pObj.CMesPeriodo) + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;            
            return iPerEN;
        }

        public static PeriodoEN EsPeriodoDisponible(PeriodoEN pObj)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //validar que los dos campos esten llenos
            if (pObj.AnoPeriodo != string.Empty && pObj.CMesPeriodo != string.Empty)
            {
                //buscar por clave periodo
                iPerEN = PeriodoRN.BuscarPeriodoXClave(pObj);
                if (iPerEN.ClavePeriodo != string.Empty)
                {
                    iPerEN.Adicionales.EsVerdad = false;
                    iPerEN.Adicionales.Mensaje = "El periodo " + pObj.AnoPeriodo + " - " + pObj.NMesPeriodo + " ya esta registrado";
                    return iPerEN;
                }
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(PeriodoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case PeriodoEN.ClaObj: return pObj.ClaveObjeto;
                case PeriodoEN.ClaPer: return pObj.ClavePeriodo;
                case PeriodoEN.CodPer: return pObj.CodigoPeriodo;
                case PeriodoEN.CodEmp: return pObj.CodigoEmpresa;
                case PeriodoEN.NomEmp: return pObj.NombreEmpresa;
                case PeriodoEN.AnoPer: return pObj.AnoPeriodo;
                case PeriodoEN.CMesPer: return pObj.CMesPeriodo;
                case PeriodoEN.NMesPer: return pObj.NMesPeriodo;
                case PeriodoEN.CEstPer: return pObj.CEstadoPeriodo;
                case PeriodoEN.NEstPer: return pObj.NEstadoPeriodo;
                case PeriodoEN.UsuAgr: return pObj.UsuarioAgrega;
                case PeriodoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case PeriodoEN.UsuMod: return pObj.UsuarioModifica;
                case PeriodoEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<PeriodoEN> FiltrarPeriodosXTextoEnCualquierPosicion(List<PeriodoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<PeriodoEN> iLisRes = new List<PeriodoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (PeriodoEN xPer in pLista)
            {
                string iTexto = PeriodoRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<PeriodoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<PeriodoEN> pListaPeriodos)
        {
            //lista resultado
            List<PeriodoEN> iLisRes = new List<PeriodoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaPeriodos; }

            //filtar la lista
            iLisRes = PeriodoRN.FiltrarPeriodosXTextoEnCualquierPosicion(pListaPeriodos, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClavePeriodo(PeriodoEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.AnoPeriodo + "-";
            iClave += pPer.CMesPeriodo;

            //retornar
            return iClave;
        }

        public static string ObtenerClavePeriodo(string pAño, string pCMes)
        {
            //asignar parametros
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.AnoPeriodo = pAño;
            iPerEN.CMesPeriodo = pCMes;

            //ejecutar metodo
            return PeriodoRN.ObtenerClavePeriodo(iPerEN);
        }

        public static PeriodoEN EsActoEliminarPeriodo(PeriodoEN pPer)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //validar si existe
            iPerEN = PeriodoRN.EsPeriodoExistente(pPer);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe este periodo en movimientocabe
            PeriodoEN iPerMovCabExiEN = PeriodoRN.ValidaCuandoCodigoPeriodoEstaEnMovimientoCabe(iPerEN);
            if (iPerMovCabExiEN.Adicionales.EsVerdad == false) { return iPerMovCabExiEN; }

            //ok            
            return iPerEN;
        }

        public static PeriodoEN ValidaCuandoCodigoPeriodoEstaEnMovimientoCabe(PeriodoEN pObj)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //valida
            bool iExisten = MovimientoCabeRN.ExisteValorEnColumnaConEmpresa(MovimientoCabeEN.PerMovCab, pObj.CodigoPeriodo);
            if (iExisten == true)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Hay movimientos de Ingresos y/o Egresos registrados en este periodo, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            return iPerEN;
        }

        public static PeriodoEN EsActoRegistrarEnEstePeriodo(PeriodoEN pPer)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //valida cuando el periodo esta vacio
            iPerEN = PeriodoRN.ValidaCuandoPeriodoEstaVacio(pPer.CodigoPeriodo);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe
            iPerEN = PeriodoRN.EsPeriodoExistente(pPer);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si esta cerrado
            PeriodoEN iPerCerEN = PeriodoRN.ValidaPeriodoCerrado(iPerEN);
            if (iPerCerEN.Adicionales.EsVerdad == false) { return iPerCerEN; }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PeriodoEN ValidaPeriodoCerrado(PeriodoEN pPer)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //valida
            if (pPer.CEstadoPeriodo == "0")//cerrado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El periodo " + pPer.AnoPeriodo + " : " + pPer.NMesPeriodo +
                                                " esta cerrado, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerClavePeriodo(string pFecha)
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

        public static PeriodoEN ValidaCuandoPeriodoEstaVacio(string pCodigoPeriodo)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //validar
            if (pCodigoPeriodo == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Debes Elegir un periodo, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PeriodoEN ExistePeriodoDeFecha(string pFecha,string pNombreFecha)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //-------
            //validar
            //-------
            iPerEN.ClavePeriodo = PeriodoRN.ObtenerClavePeriodo(pFecha);
            iPerEN = PeriodoRN.BuscarPeriodoXClave(iPerEN);
            if (iPerEN.ClavePeriodo == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Periodo de la fecha " + pNombreFecha + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PeriodoEN BuscarPeriodoDeFecha(string pFecha)
        {
            //asignar parametros
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.ClavePeriodo = PeriodoRN.ObtenerClavePeriodo(pFecha);

            //ejecutar metodo
            return PeriodoRN.BuscarPeriodoXClave(iPerEN);
        }

        public static PeriodoEN EsActoRegistrarEnPeriodoDeEstaFecha(string pFecha,string pNombreFecha)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //valida si existe
            iPerEN = PeriodoRN.ExistePeriodoDeFecha(pFecha, pNombreFecha);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si esta cerrado
            PeriodoEN iPerCerEN = PeriodoRN.ValidaPeriodoCerrado(iPerEN,pNombreFecha);
            if (iPerCerEN.Adicionales.EsVerdad == false) { return iPerCerEN; }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PeriodoEN ValidaPeriodoCerrado(PeriodoEN pPer, string pNombreFecha)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //valida
            if (pPer.CEstadoPeriodo == "0")//cerrado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El periodo de la fecha " + pNombreFecha + " esta cerrado, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static List<PeriodoEN> ListarPeriodosXAñoYEstado(PeriodoEN pObj)
        {
            PeriodoAD iPerAD = new PeriodoAD();
            return iPerAD.ListarPeriodosXAñoYEstado(pObj);
        }

        public static PeriodoEN HayPeriodosDeAñoYActivos(string pAñoPeriodo)
        {
            //objeto resultado
            PeriodoEN iPerEN = new PeriodoEN();

            //validar
            iPerEN.AnoPeriodo = pAñoPeriodo;
            iPerEN.CEstadoPeriodo = "1";//activos
            iPerEN.Adicionales.CampoOrden = PeriodoEN.ClaPer;
            List<PeriodoEN> iLisPer = PeriodoRN.ListarPeriodosXAñoYEstado(iPerEN);
            if (iLisPer.Count == 0)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "No hay periodos activos en este año";
            }

            return iPerEN;
        }

        public static List<string> ListarAñosPeriodos()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traemos todos los periodos que existen en la empresa actual(estan ordenados por su clave)
            List<PeriodoEN> iLisPer = PeriodoRN.ListarPeriodos();

            //variables
            string iAño = string.Empty;

            //recorrer cada objeto
            foreach (PeriodoEN xPer in iLisPer)
            {
                if (xPer.AnoPeriodo != iAño)
                {
                    iLisRes.Add(xPer.AnoPeriodo);
                    iAño = xPer.AnoPeriodo;
                }
            }

            //devolver
            return iLisRes;
        }



    }
}
