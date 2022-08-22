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
    public class PresupuestoRN
    {

        public static PresupuestoEN EnBlanco()
        {
            PresupuestoEN iPerEN = new PresupuestoEN();
            return iPerEN;
        }

        public static void AdicionarPresupuesto(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            iPerAD.AgregarPresupuesto(pObj);
        }

        public static void ModificarPresupuesto(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            iPerAD.ModificarPresupuesto(pObj);
        }

        public static void ModificarEstadoPresupuestoDeAño(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            iPerAD.ModificarEstadoPresupuestoDeAño(pObj);
        }

        public static void EliminarPresupuesto(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            iPerAD.EliminarPresupuesto(pObj);
        }

        public static List<PresupuestoEN> ListarPresupuestos(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            return iPerAD.ListarPresupuestos(pObj);
        }

        public static List<PresupuestoEN> ListarPresupuestos()
        {
            //asignar parametros
            PresupuestoEN iPerEN = new PresupuestoEN();
            iPerEN.Adicionales.CampoOrden = PresupuestoEN.ClaPre;

            //ejecutar metodo
            return PresupuestoRN.ListarPresupuestos(iPerEN);
        }

        public static List<PresupuestoEN> ListarPresupuestosXEstado(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            return iPerAD.ListarPresupuestosXEstado(pObj);
        }

        public static PresupuestoEN BuscarPresupuestoXClave(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            return iPerAD.BuscarPresupuestoXClave(pObj);
        }

        public static PresupuestoEN BuscarPresupuestoXCodigo(PresupuestoEN pObj)
        {
            //ejecutar metodo
            return PresupuestoRN.BuscarPresupuestoXCodigo(pObj.CodigoPresupuesto);
        }

        public static PresupuestoEN BuscarPresupuestoXCodigo(string pCodigoPresupuesto)
        {
            //asignar parametros
            PresupuestoEN iPerEN = new PresupuestoEN();
            iPerEN.CodigoPresupuesto = pCodigoPresupuesto;
            iPerEN.ClavePresupuesto = PresupuestoRN.ObtenerClavePresupuesto(iPerEN);

            //ejecutar metodo
            return PresupuestoRN.BuscarPresupuestoXClave(iPerEN);
        }

        public static PresupuestoEN EsPresupuestoExistente(PresupuestoEN pObj)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //validar si existe en b.d           
            pObj.AnoPresupuesto = AñoMes.ObtenerAñoPeriodo(pObj.CodigoPresupuesto);
            pObj.CMesPresupuesto = AñoMes.ObtenerCMesPeriodo(pObj.CodigoPresupuesto);
            pObj.CCentroCosto = pObj.CCentroCosto;
            pObj.ClavePresupuesto = PresupuestoRN.ObtenerClavePresupuesto(pObj);
            iPerEN = PresupuestoRN.BuscarPresupuestoXClave(pObj);
            if (iPerEN.ClavePresupuesto == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Presupuesto " + pObj.AnoPresupuesto + " - " + Fecha.ObtenerMesEnNombre(pObj.CMesPresupuesto) + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PresupuestoEN EsPresupuestoDisponible(PresupuestoEN pObj)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //validar que los dos campos esten llenos
            if (pObj.AnoPresupuesto != string.Empty && pObj.CMesPresupuesto != string.Empty)
            {
                //buscar por clave periodo
                iPerEN = PresupuestoRN.BuscarPresupuestoXClave(pObj);
                if (iPerEN.ClavePresupuesto != string.Empty)
                {
                    iPerEN.Adicionales.EsVerdad = false;
                    iPerEN.Adicionales.Mensaje = "El presupuesto " + pObj.AnoPresupuesto + " - " + pObj.NMesPresupuesto + " ya esta registrado";
                    return iPerEN;
                }
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(PresupuestoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case PresupuestoEN.ClaObj: return pObj.ClaveObjeto;
                case PresupuestoEN.ClaPre: return pObj.ClavePresupuesto;
                case PresupuestoEN.CodPre: return pObj.CodigoPresupuesto;
                case PresupuestoEN.CodEmp: return pObj.CodigoEmpresa;
                case PresupuestoEN.NomEmp: return pObj.NombreEmpresa;
                case PresupuestoEN.AnoPre: return pObj.AnoPresupuesto;
                case PresupuestoEN.CMesPre: return pObj.CMesPresupuesto;
                case PresupuestoEN.NMesPre: return pObj.NMesPresupuesto;
                case PresupuestoEN.CEstPre: return pObj.CEstadoPresupuesto;
                case PresupuestoEN.NEstPre: return pObj.NEstadoPresupuesto;
                case PresupuestoEN.UsuAgr: return pObj.UsuarioAgrega;
                case PresupuestoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case PresupuestoEN.UsuMod: return pObj.UsuarioModifica;
                case PresupuestoEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<PresupuestoEN> FiltrarPresupuestosXTextoEnCualquierPosicion(List<PresupuestoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<PresupuestoEN> iLisRes = new List<PresupuestoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (PresupuestoEN xPer in pLista)
            {
                string iTexto = PresupuestoRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<PresupuestoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<PresupuestoEN> pListaPresupuestos)
        {
            //lista resultado
            List<PresupuestoEN> iLisRes = new List<PresupuestoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaPresupuestos; }

            //filtar la lista
            iLisRes = PresupuestoRN.FiltrarPresupuestosXTextoEnCualquierPosicion(pListaPresupuestos, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClavePresupuesto(PresupuestoEN pPre)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPre.AnoPresupuesto + "-";
            iClave += pPre.CMesPresupuesto + "-";
            iClave += pPre.CCentroCosto;

            //retornar
            return iClave;
        }

        public static string ObtenerClavePresupuesto(string pAño, string pCMes, string pCcto)
        {
            //asignar parametros
            PresupuestoEN iPerEN = new PresupuestoEN();
            iPerEN.AnoPresupuesto = pAño;
            iPerEN.CMesPresupuesto = pCMes;
            iPerEN.CCentroCosto = pCcto;

            //ejecutar metodo
            return PresupuestoRN.ObtenerClavePresupuesto(iPerEN);
        }

        public static PresupuestoEN EsActoEliminarPresupuesto(PresupuestoEN pPer)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //validar si existe
            iPerEN = PresupuestoRN.EsPresupuestoExistente(pPer);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe este periodo en movimientocabe
            PresupuestoEN iPerMovCabExiEN = PresupuestoRN.ValidaCuandoCodigoPeriodoEstaEnMovimientoCabe(iPerEN);
            if (iPerMovCabExiEN.Adicionales.EsVerdad == false) { return iPerMovCabExiEN; }

            //ok            
            return iPerEN;
        }

        public static PresupuestoEN ValidaCuandoCodigoPeriodoEstaEnMovimientoCabe(PresupuestoEN pObj)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //valida
            bool iExisten = MovimientoCabeRN.ExisteValorEnColumnaConEmpresa(MovimientoCabeEN.PerMovCab, pObj.CodigoPresupuesto);
            if (iExisten == true)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Hay movimientos de Ingresos y/o Egresos registrados en este periodo, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            return iPerEN;
        }

        public static PresupuestoEN EsActoRegistrarEnEstePresupuesto(PresupuestoEN pPer)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //valida cuando el periodo esta vacio
            iPerEN = PresupuestoRN.ValidaCuandoPresupuestoEstaVacio(pPer.CodigoPresupuesto);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe
            iPerEN = PresupuestoRN.EsPresupuestoExistente(pPer);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si esta cerrado
            PresupuestoEN iPerCerEN = PresupuestoRN.ValidaPresupuestoCerrado(iPerEN);
            if (iPerCerEN.Adicionales.EsVerdad == false) { return iPerCerEN; }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PresupuestoEN ValidaPresupuestoCerrado(PresupuestoEN pPer)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //valida
            if (pPer.CEstadoPresupuesto == "0")//cerrado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El presupuesto " + pPer.AnoPresupuesto + " : " + pPer.NMesPresupuesto +
                                                " esta cerrado, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerClavePresupuesto(string pFecha)
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

        public static PresupuestoEN ValidaCuandoPresupuestoEstaVacio(string pCodigoPresupuesto)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //validar
            if (pCodigoPresupuesto == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Debes Elegir un Presupuesto, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PresupuestoEN ExistePresupuestoDeFecha(string pFecha, string pNombreFecha)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //-------
            //validar
            //-------
            iPerEN.ClavePresupuesto = PresupuestoRN.ObtenerClavePresupuesto(pFecha);
            iPerEN = PresupuestoRN.BuscarPresupuestoXClave(iPerEN);
            if (iPerEN.ClavePresupuesto == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Presupuesto de la fecha " + pNombreFecha + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PresupuestoEN BuscarPresupuestoDeFecha(string pFecha)
        {
            //asignar parametros
            PresupuestoEN iPerEN = new PresupuestoEN();
            iPerEN.ClavePresupuesto = PresupuestoRN.ObtenerClavePresupuesto(pFecha);

            //ejecutar metodo
            return PresupuestoRN.BuscarPresupuestoXClave(iPerEN);
        }

        public static PresupuestoEN EsActoRegistrarEnPresupuestoDeEstaFecha(string pFecha, string pNombreFecha)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //valida si existe
            iPerEN = PresupuestoRN.ExistePresupuestoDeFecha(pFecha, pNombreFecha);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si esta cerrado
            PresupuestoEN iPerCerEN = PresupuestoRN.ValidaPresupuestoCerrado(iPerEN, pNombreFecha);
            if (iPerCerEN.Adicionales.EsVerdad == false) { return iPerCerEN; }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PresupuestoEN ValidaPresupuestoCerrado(PresupuestoEN pPer, string pNombreFecha)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //valida
            if (pPer.CEstadoPresupuesto == "0")//cerrado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El presupuesto de la fecha " + pNombreFecha + " esta cerrado, no se puede realizar la operacion";
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

        public static List<PresupuestoEN> ListarPresupuestosXAñoYEstado(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            return iPerAD.ListarPresupuestosXAñoYEstado(pObj);
        }

        public static PresupuestoEN HayPresupuestosDeAñoYActivos(string pAñoPresupuesto)
        {
            //objeto resultado
            PresupuestoEN iPerEN = new PresupuestoEN();

            //validar
            iPerEN.AnoPresupuesto = pAñoPresupuesto;
            iPerEN.CEstadoPresupuesto = "1";//activos
            iPerEN.Adicionales.CampoOrden = PeriodoEN.ClaPer;
            List<PresupuestoEN> iLisPer = PresupuestoRN.ListarPresupuestosXAñoYEstado(iPerEN);
            if (iLisPer.Count == 0)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "No hay Presupuesto activos en este año";
            }

            return iPerEN;
        }

        public static List<string> ListarAñosPresupuestos()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traemos todos los periodos que existen en la empresa actual(estan ordenados por su clave)
            List<PresupuestoEN> iLisPer = PresupuestoRN.ListarPresupuestos();

            //variables
            string iAño = string.Empty;

            //recorrer cada objeto
            foreach (PresupuestoEN xPer in iLisPer)
            {
                if (xPer.AnoPresupuesto != iAño)
                {
                    iLisRes.Add(xPer.AnoPresupuesto);
                    iAño = xPer.AnoPresupuesto;
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarPresupuestoTemporal(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            iPerAD.ModificarPresupuestoTemporal(pObj);
        }

        public static void ModificarPresupuestoActual(PresupuestoEN pObj)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            iPerAD.ModificarPresupuestoActual(pObj);
        }

        public static void RecalcularPresupuesto(string iAno, string iMes, string codCosto, decimal costoMovimiento)
        {
            PresupuestoAD iPerAD = new PresupuestoAD();
            iPerAD.RecalcularPresupuesto(iAno, iMes, codCosto, costoMovimiento);
        }
    }
}
