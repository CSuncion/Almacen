using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;


namespace Negocio
{
    public class RangoCabeRN
    {

        public static RangoCabeEN EnBlanco()
        {
            RangoCabeEN iRanCabEN = new RangoCabeEN();
            return iRanCabEN;
        }

        public static void AdicionarRangoCabe(RangoCabeEN pObj)
        {
            RangoCabeAD iRanCabAD = new RangoCabeAD();
            iRanCabAD.AdicionarRangoCabe(pObj);
        }

        public static void ModificarRangoCabe(RangoCabeEN pObj)
        {
            RangoCabeAD iRanCabAD = new RangoCabeAD();
            iRanCabAD.ModificarRangoCabe(pObj);
        }

        public static void EliminarRangoCabe(RangoCabeEN pObj)
        {
            RangoCabeAD iRanCabAD = new RangoCabeAD();
            iRanCabAD.EliminarRangoCabe(pObj);
        }

        public static RangoCabeEN BuscarRangoCabeXClave(RangoCabeEN pObj)
        {
            RangoCabeAD iRanCabAD = new RangoCabeAD();
            return iRanCabAD.BuscarRangoCabeXClave(pObj);
        }

        public static RangoCabeEN BuscarRangoCabeXClave(string pClaveRangoCabe)
        {
            //asignar parametros
            RangoCabeEN iRanCabEN = new RangoCabeEN();
            iRanCabEN.ClaveRangoCabe = pClaveRangoCabe;

            //ejecutar metodo
            return RangoCabeRN.BuscarRangoCabeXClave(iRanCabEN);
        }

        //public static FormulaCabeEN BuscarRangoCabeXCodigoSemiProducto(FormulaCabeEN pObj)
        //{
        //    FormulaCabeAD iProCabAD = new FormulaCabeAD();
        //    return iProCabAD.BuscarFormulaCabeXCodigoSemiProducto(pObj);
        //}

        //public static FormulaCabeEN BuscarFormulaCabeXCodigoSemiProducto(string pClaveFormulaCabe)
        //{
        //    //asignar parametros
        //    FormulaCabeEN iForCabEN = new FormulaCabeEN();
        //    iForCabEN.ClaveFormulaCabe = pClaveFormulaCabe;

        //    //ejecutar metodo
        //    return FormulaCabeRN.BuscarFormulaCabeXCodigoSemiProducto(iForCabEN);
        //}

        public static List<RangoCabeEN> ListarRangoCabe(RangoCabeEN pObj)
        {
            RangoCabeAD iRanCabAD = new RangoCabeAD();
            return iRanCabAD.ListarRangoCabe(pObj);
        }

        public static List<RangoCabeEN> ListarRangoCabe()
        {
            //asignar parametros
            RangoCabeEN iRanCabEN = new RangoCabeEN();
            iRanCabEN.Adicionales.CampoOrden = RangoCabeEN.ClaRanCab;

            //ejecutar metodo
            return RangoCabeRN.ListarRangoCabe(iRanCabEN);
        }

        public static string ObtenerClaveRangoCabe(RangoCabeEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoExistencia;

            //devolver
            return iClave;
        }

        public static RangoCabeEN EsRangoCabeExistente(RangoCabeEN pObj)
        {
            RangoCabeEN iProCabEN = new RangoCabeEN();
            iProCabEN = RangoCabeRN.BuscarRangoCabeXClave(pObj);
            if (iProCabEN.CodigoExistencia == string.Empty)
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La formula " + pObj.CodigoExistencia + " no existe";
            }
            else
            {
                iProCabEN.Adicionales.EsVerdad = true;
            }
            return iProCabEN;
        }
              
        public static List<RangoCabeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<RangoCabeEN> pListaRangoCabe)
        {
            //lista resultado
            List<RangoCabeEN> iLisRes = new List<RangoCabeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaRangoCabe; }

            //filtar la lista
            iLisRes = RangoCabeRN.FiltrarRangoCabeEnCualquierPosicion(pListaRangoCabe, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<RangoCabeEN> FiltrarRangoCabeEnCualquierPosicion(List<RangoCabeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<RangoCabeEN> iLisRes = new List<RangoCabeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (RangoCabeEN xPro in pLista)
            {
                string iTexto = RangoCabeRN.ObtenerValorDeCampo(xPro, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPro);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(RangoCabeEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case RangoCabeEN.ClaObj: return pObj.ClaveObjeto;
                case RangoCabeEN.CodEmp: return pObj.CodigoEmpresa;
                case RangoCabeEN.CodAlm: return pObj.CodigoAlmacen;
                case RangoCabeEN.DesAlm: return pObj.DescripcionAlmacen;
                case RangoCabeEN.CodExi: return pObj.CodigoExistencia;
                case RangoCabeEN.DesExi: return pObj.DescripcionExistencia;
                case RangoCabeEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case RangoCabeEN.NomUniMed: return pObj.NombreUnidadMedida;               
                case RangoCabeEN.Coment: return pObj.Comentario;                               
                case RangoCabeEN.CEstRanCab: return pObj.CEstadoRangoCabe;
                case RangoCabeEN.NEstRanCab: return pObj.NEstadoRangoCabe;
                case RangoCabeEN.UsuAgr: return pObj.UsuarioAgrega;
                case RangoCabeEN.FecAgr: return pObj.FechaAgrega.ToString();
                case RangoCabeEN.UsuMod: return pObj.UsuarioModifica;
                case RangoCabeEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<RangoCabeEN> ListarRangoCabeEnAlmacen(RangoCabeEN pObj)
        {
            RangoCabeAD iProCabAD = new RangoCabeAD();
            return iProCabAD.ListarRangoCabeEnAlmacen(pObj);
        }

        public static List<RangoCabeEN> ListarRangoCabeEnAlmacen(string pCodigoAlmacen)
        {
            //asignar parametros
            RangoCabeEN iForCabEN = new RangoCabeEN();
            iForCabEN.CodigoAlmacen = pCodigoAlmacen;
            iForCabEN.Adicionales.CampoOrden = RangoCabeEN.ClaRanCab;

            //ejecutar metodo
            return RangoCabeRN.ListarRangoCabeEnAlmacen(iForCabEN);
        }

        public static RangoCabeEN EsRangoCabeValido(RangoCabeEN pObj)
        {
            //objeto resultado
            RangoCabeEN iForCabEN = new RangoCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iForCabEN; }

            //valida cuando el codigo no existe
            iForCabEN = RangoCabeRN.EsRangoCabeExistente(pObj);
            if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            //ok           
            return iForCabEN;
        }

        //public static FormulaCabeEN ValidaCuandoExistenciaNoEsDeProduccion(FormulaCabeEN pObj)
        //{
        //    //objeto resultado
        //    FormulaCabeEN iForCabEN = new FormulaCabeEN();

        //    //-------
        //    //validar
        //    //-------      
        //    ExistenciaEN iExiEN = new ExistenciaEN();
        //    iExiEN.CodigoAlmacen = pObj.CodigoAlmacen;
        //    iExiEN.DescripcionAlmacen = pObj.DescripcionAlmacen;
        //    iExiEN.CodigoExistencia = pObj.CodigoExistencia;
        //    iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
        //    iExiEN = ExistenciaRN.EsExistenciaDeProduccionValido(iExiEN);

        //    //este resultado lo pasamos al objeto resultado
        //    iForCabEN.CodigoExistencia = iExiEN.CodigoExistencia;
        //    iForCabEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
        //    iForCabEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
        //    iForCabEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
        //    iForCabEN.Adicionales = iExiEN.Adicionales;

        //    //devolver
        //    return iForCabEN;
        //}

        //public static FormulaCabeEN ValidaCuandoExistenciaEsDeProduccion(FormulaCabeEN pObj)
        //{
        //    //objeto resultado
        //    FormulaCabeEN iForCabEN = new FormulaCabeEN();

        //    //-------
        //    //validar
        //    //-------      
        //    ExistenciaEN iExiEN = new ExistenciaEN();
        //    //iExiEN.CodigoAlmacen = pObj.CodigoAlmacenMercaderia;
        //    //iExiEN.DescripcionAlmacen = pObj.DescripcionAlmacenMercaderia;
        //    //iExiEN.CodigoExistencia = pObj.CodigoMercaderia;
        //    iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
        //    iExiEN = ExistenciaRN.EsExistenciaDeNoProduccionValido(iExiEN);

        //    //este resultado lo pasamos al objeto resultado
        //    iForCabEN.CodigoExistencia = iExiEN.CodigoExistencia;
        //    iForCabEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
        //    iForCabEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
        //    iForCabEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
        //    iForCabEN.Adicionales = iExiEN.Adicionales;

        //    //devolver
        //    return iForCabEN;
        //}
        
        //public static FormulaCabeEN ValidaCuandoNoEsDeAlmacen(FormulaCabeEN pObj,string pCodigoAlmacen)
        //{
        //    //objeto resultado
        //    FormulaCabeEN iForCabEN = new FormulaCabeEN();

        //    //valida 
        //    if (pObj.CodigoAlmacen != pCodigoAlmacen)
        //    {
        //        iForCabEN.Adicionales.EsVerdad = false;
        //        iForCabEN.Adicionales.Mensaje = "Esta formula no es del almacen elegido";
        //        return iForCabEN;
        //    }

        //    //ok           
        //    return iForCabEN;
        //}

        public static RangoCabeEN EsActoEliminarRangoCabe(RangoCabeEN pObj)
        {
            //objeto resultado
            RangoCabeEN iForCabEN = new RangoCabeEN();

            //validar si existe
            iForCabEN = RangoCabeRN.EsRangoCabeExistente(pObj);
            if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            //valida si existen esta existencia en MovimientoDeta
            RangoCabeEN iExiExiEN = RangoCabeRN.ValidaCuandoCodigoExistenciaEstaEnProduccionCabe(iForCabEN);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //ok            
            return iForCabEN;
        }

        public static RangoCabeEN ValidaCuandoCodigoExistenciaEstaEnProduccionCabe(RangoCabeEN pObj)
        {
            //objeto resultado
            RangoCabeEN iForCabEN = new RangoCabeEN();

            //valida
            bool iExisten = ProduccionCabeRN.ExisteValorEnColumnaConEmpresa(ProduccionCabeEN.CodExi, pObj.CodigoExistencia,
                                                                    ProduccionCabeEN.CodAlm, pObj.CodigoAlmacen);
            if (iExisten == true)
            {
                iForCabEN.Adicionales.EsVerdad = false;
                iForCabEN.Adicionales.Mensaje = "Esta formula esta referenciada en solicitudes produccion, no se puede realizar la operacion";
                return iForCabEN;
            }

            //ok
            return iForCabEN;
        }

        public static List<RangoCabeEN> ListarRangoCabeActivasEnAlmacen(RangoCabeEN pObj)
        {
            RangoCabeAD iProCabAD = new RangoCabeAD();
            return iProCabAD.ListarRangoCabeActivasEnAlmacen(pObj);
        }

        public static List<RangoCabeEN> ListarRangoCabeActivasEnAlmacen(string pCodigoAlmacen)
        {
            //asignar parametros
            RangoCabeEN iForCabEN = new RangoCabeEN();
            iForCabEN.CodigoAlmacen = pCodigoAlmacen;
            iForCabEN.Adicionales.CampoOrden = RangoCabeEN.ClaRanCab;

            //ejecutar metodo
            return RangoCabeRN.ListarRangoCabeActivasEnAlmacen(iForCabEN);
        }

        public static RangoCabeEN EsRangoCabeActivoValido(RangoCabeEN pObj)
        {
            //objeto resultado
            RangoCabeEN iForCabEN = new RangoCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iForCabEN; }

            //valida cuando el codigo no existe
            iForCabEN = RangoCabeRN.EsRangoCabeExistente(pObj);
            if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            //valida cuando esta desactivada
            RangoCabeEN iForCabDesEN = RangoCabeRN.ValidaCuandoEstaDesactivado(iForCabEN);
            if (iForCabDesEN.Adicionales.EsVerdad == false) { return iForCabDesEN; }

            //ok           
            return iForCabEN;
        }

        public static RangoCabeEN ValidaCuandoEstaDesactivado(RangoCabeEN pObj)
        {
            //objeto resultado
            RangoCabeEN iForCabEN = new RangoCabeEN();

            //valida 
            if (pObj.CEstadoRangoCabe == "0")//desactivado
            {
                iForCabEN.Adicionales.EsVerdad = false;
                iForCabEN.Adicionales.Mensaje = "El Rango " + pObj.CodigoExistencia + " esta desactivada";
                return iForCabEN;
            }

            //ok           
            return iForCabEN;
        }

        public static RangoCabeEN EsRangoCabeDisponible(RangoCabeEN pObj)
        {
            //objeto resultado
            RangoCabeEN iForCabEN = new RangoCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iForCabEN; }

            //validar cuando la existencia no es de produccion
            //iForCabEN = RangoCabeRN.ValidaCuandoExistenciaNoEsDeProduccion(pObj);
            //if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            //valida cuando el codigo no existe
            RangoCabeEN iForCabExiEN = RangoCabeRN.ValidaCuandoExiste(pObj);
            if (iForCabExiEN.Adicionales.EsVerdad == false) { return iForCabExiEN; }

            //ok           
            return iForCabEN;
        }

        public static RangoCabeEN ValidaCuandoExiste(RangoCabeEN pObj)
        {
            RangoCabeEN iProCabEN = new RangoCabeEN();
            iProCabEN = RangoCabeRN.BuscarRangoCabeXClave(pObj);
            if (iProCabEN.CodigoExistencia != string.Empty)
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "El Rango " + pObj.CodigoExistencia + " ya existe";
            }
            else
            {
                iProCabEN.Adicionales.EsVerdad = true;
            }
            return iProCabEN;
        }
        
        //public static FormulaCabeEN ValidaCuandoSemiProductoExiste(FormulaCabeEN pObj, Universal.Opera pOperacion)
        //{
        //    FormulaCabeEN iProCabEN = new FormulaCabeEN();
        //    iProCabEN = FormulaCabeRN.BuscarFormulaCabeXCodigoSemiProducto(pObj);
        //    if (iProCabEN.CodigoExistencia != string.Empty)
        //    {
        //        //segun operacion
        //        if (pOperacion == Universal.Opera.Modificar && iProCabEN.CodigoSemiProducto == pObj.CodigoSemiProducto)
        //        {
        //            iProCabEN = FormulaCabeRN.EnBlanco();
        //        }
        //        else
        //        {
        //            iProCabEN = FormulaCabeRN.EnBlanco();
        //            iProCabEN.Adicionales.EsVerdad = false;
        //            iProCabEN.Adicionales.Mensaje = "El codigo de semiproducto " + pObj.CodigoSemiProducto + " ya existe";
        //        }
        //    }
        //    else
        //    {
        //        iProCabEN.Adicionales.EsVerdad = true;
        //    }
        //    return iProCabEN;
        //}
        
        //public static RangoCabeEN EsFormulaCabeSemiProductoDisponible(FormulaCabeEN pObj, Universal.Opera pOperacion)
        //{
        //    //objeto resultado
        //    FormulaCabeEN iForCabEN = new FormulaCabeEN();

        //    //valida cuando el codigo esta vacio
        //    if (pObj.CodigoSemiProducto == string.Empty) { return iForCabEN; }

        //    //validar cuando la existencia no es de produccion
        //    iForCabEN = FormulaCabeRN.ValidaCuandoExistenciaSemiProductoEsDeProduccion(pObj);
        //    if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

        //    //valida cuando el codigo no existe
        //    FormulaCabeEN iForCabExiEN = FormulaCabeRN.ValidaCuandoSemiProductoExiste(pObj, pOperacion);
        //    if (iForCabExiEN.Adicionales.EsVerdad == false) { return iForCabExiEN; }

        //    //ok           
        //    return iForCabEN;
        //}

        //public static FormulaCabeEN ValidaCuandoExistenciaSemiProductoEsDeProduccion(FormulaCabeEN pObj)
        //{
        //    //objeto resultado
        //    FormulaCabeEN iForCabEN = new FormulaCabeEN();

        //    //-------
        //    //validar
        //    //-------      
        //    ExistenciaEN iExiEN = new ExistenciaEN();
        //    iExiEN.CodigoAlmacen = pObj.CodigoAlmacenSemiProducto;
        //    iExiEN.DescripcionAlmacen = pObj.DescripcionAlmacenSemiProducto;
        //    iExiEN.CodigoExistencia = pObj.CodigoSemiProducto;
        //    iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
        //    iExiEN = ExistenciaRN.EsExistenciaDeNoProduccionValido(iExiEN);

        //    //este resultado lo pasamos al objeto resultado
        //    iForCabEN.CodigoExistencia = iExiEN.CodigoExistencia;
        //    iForCabEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
        //    iForCabEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
        //    iForCabEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
        //    iForCabEN.Adicionales = iExiEN.Adicionales;

        //    //devolver
        //    return iForCabEN;
        //}

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            RangoCabeAD iPerAD = new RangoCabeAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            RangoCabeAD iPerAD = new RangoCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RangoCabeAD iPerAD = new RangoCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        //public static string ObtenerClaveExistenciaSemiProducto(FormulaCabeEN pObj)
        //{
        //    //valor resultado
        //    string iClave = string.Empty;

        //    //armar clave
        //    iClave += Universal.gCodigoEmpresa + "-";
        //    iClave += pObj.CodigoAlmacenSemiProducto + "-";
        //    iClave += pObj.CodigoSemiProducto;

        //    //devolver
        //    return iClave;
        //}

    }
}
