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
    public class FormulaCabeRN
    {

        public static FormulaCabeEN EnBlanco()
        {
            FormulaCabeEN iProCabEN = new FormulaCabeEN();
            return iProCabEN;
        }

        public static void AdicionarFormulaCabe(FormulaCabeEN pObj)
        {
            FormulaCabeAD iProCabAD = new FormulaCabeAD();
            iProCabAD.AdicionarFormulaCabe(pObj);
        }

        public static void ModificarFormulaCabe(FormulaCabeEN pObj)
        {
            FormulaCabeAD iProCabAD = new FormulaCabeAD();
            iProCabAD.ModificarFormulaCabe(pObj);
        }

        public static void EliminarFormulaCabe(FormulaCabeEN pObj)
        {
            FormulaCabeAD iProCabAD = new FormulaCabeAD();
            iProCabAD.EliminarFormulaCabe(pObj);
        }

        public static FormulaCabeEN BuscarFormulaCabeXClave(FormulaCabeEN pObj)
        {
            FormulaCabeAD iProCabAD = new FormulaCabeAD();
            return iProCabAD.BuscarFormulaCabeXClave(pObj);
        }

        public static FormulaCabeEN BuscarFormulaCabeXClave(string pClaveFormulaCabe)
        {
            //asignar parametros
            FormulaCabeEN iForCabEN = new FormulaCabeEN();
            iForCabEN.ClaveFormulaCabe = pClaveFormulaCabe;

            //ejecutar metodo
            return FormulaCabeRN.BuscarFormulaCabeXClave(iForCabEN);
        }

        public static FormulaCabeEN BuscarFormulaCabeXCodigoSemiProducto(FormulaCabeEN pObj)
        {
            FormulaCabeAD iProCabAD = new FormulaCabeAD();
            return iProCabAD.BuscarFormulaCabeXCodigoSemiProducto(pObj);
        }

        //public static FormulaCabeEN BuscarFormulaCabeXCodigoSemiProducto(string pClaveFormulaCabe)
        //{
        //    //asignar parametros
        //    FormulaCabeEN iForCabEN = new FormulaCabeEN();
        //    iForCabEN.ClaveFormulaCabe = pClaveFormulaCabe;

        //    //ejecutar metodo
        //    return FormulaCabeRN.BuscarFormulaCabeXCodigoSemiProducto(iForCabEN);
        //}

        public static List<FormulaCabeEN> ListarFormulaCabe(FormulaCabeEN pObj)
        {
            FormulaCabeAD iProCabAD = new FormulaCabeAD();
            return iProCabAD.ListarFormulaCabe(pObj);
        }

        public static List<FormulaCabeEN> ListarFormulaCabe()
        {
            //asignar parametros
            FormulaCabeEN iForCabEN = new FormulaCabeEN();
            iForCabEN.Adicionales.CampoOrden = FormulaCabeEN.ClaForCab;

            //ejecutar metodo
            return FormulaCabeRN.ListarFormulaCabe(iForCabEN);
        }

        public static string ObtenerClaveFormulaCabe(FormulaCabeEN pObj)
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

        public static FormulaCabeEN EsFormulaCabeExistente(FormulaCabeEN pObj)
        {
            FormulaCabeEN iProCabEN = new FormulaCabeEN();
            iProCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(pObj);
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
              
        public static List<FormulaCabeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<FormulaCabeEN> pListaFormulaCabe)
        {
            //lista resultado
            List<FormulaCabeEN> iLisRes = new List<FormulaCabeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaFormulaCabe; }

            //filtar la lista
            iLisRes = FormulaCabeRN.FiltrarFormulaCabeEnCualquierPosicion(pListaFormulaCabe, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<FormulaCabeEN> FiltrarFormulaCabeEnCualquierPosicion(List<FormulaCabeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<FormulaCabeEN> iLisRes = new List<FormulaCabeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (FormulaCabeEN xPro in pLista)
            {
                string iTexto = FormulaCabeRN.ObtenerValorDeCampo(xPro, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPro);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(FormulaCabeEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case FormulaCabeEN.ClaObj: return pObj.ClaveObjeto;
                case FormulaCabeEN.CodEmp: return pObj.CodigoEmpresa;
                case FormulaCabeEN.CodAlm: return pObj.CodigoAlmacen;
                case FormulaCabeEN.DesAlm: return pObj.DescripcionAlmacen;
                case FormulaCabeEN.CodExi: return pObj.CodigoExistencia;
                case FormulaCabeEN.DesExi: return pObj.DescripcionExistencia;
                case FormulaCabeEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case FormulaCabeEN.NomUniMed: return pObj.NombreUnidadMedida;               
                case FormulaCabeEN.Coment: return pObj.Comentario;               
                case FormulaCabeEN.MasUni: return pObj.MasaUnidad.ToString();               
                case FormulaCabeEN.RatForCab: return pObj.RatioFormulaCabe.ToString();
                case FormulaCabeEN.CodAlmSemPro: return pObj.CodigoAlmacenSemiProducto;
                case FormulaCabeEN.DesAlmSemPro: return pObj.DescripcionAlmacenSemiProducto;
                case FormulaCabeEN.CodSemPro: return pObj.CodigoSemiProducto;
                case FormulaCabeEN.DesExiSemPro: return pObj.DescripcionExistenciaSemiProducto;
                case FormulaCabeEN.CodUniMedSemPro: return pObj.CodigoUnidadMedidaSemiProducto;
                case FormulaCabeEN.NomUniMedSemPro: return pObj.NombreUnidadMedidaSemiProducto;
                case FormulaCabeEN.CEstForCab: return pObj.CEstadoFormulaCabe;
                case FormulaCabeEN.NEstForCab: return pObj.NEstadoFormulaCabe;
                case FormulaCabeEN.UsuAgr: return pObj.UsuarioAgrega;
                case FormulaCabeEN.FecAgr: return pObj.FechaAgrega.ToString();
                case FormulaCabeEN.UsuMod: return pObj.UsuarioModifica;
                case FormulaCabeEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<FormulaCabeEN> ListarFormulaCabeEnAlmacen(FormulaCabeEN pObj)
        {
            FormulaCabeAD iProCabAD = new FormulaCabeAD();
            return iProCabAD.ListarFormulaCabeEnAlmacen(pObj);
        }

        public static List<FormulaCabeEN> ListarFormulaCabeEnAlmacen(string pCodigoAlmacen)
        {
            //asignar parametros
            FormulaCabeEN iForCabEN = new FormulaCabeEN();
            iForCabEN.CodigoAlmacen = pCodigoAlmacen;
            iForCabEN.Adicionales.CampoOrden = FormulaCabeEN.ClaForCab;

            //ejecutar metodo
            return FormulaCabeRN.ListarFormulaCabeEnAlmacen(iForCabEN);
        }

        public static FormulaCabeEN EsFormulaCabeValido(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iForCabEN; }

            //valida cuando el codigo no existe
            iForCabEN = FormulaCabeRN.EsFormulaCabeExistente(pObj);
            if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            //ok           
            return iForCabEN;
        }

        public static FormulaCabeEN ValidaCuandoExistenciaNoEsDeProduccion(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //-------
            //validar
            //-------      
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iExiEN.DescripcionAlmacen = pObj.DescripcionAlmacen;
            iExiEN.CodigoExistencia = pObj.CodigoExistencia;
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
            iExiEN = ExistenciaRN.EsExistenciaDeProduccionValido(iExiEN);

            //este resultado lo pasamos al objeto resultado
            iForCabEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iForCabEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iForCabEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iForCabEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iForCabEN.Adicionales = iExiEN.Adicionales;

            //devolver
            return iForCabEN;
        }

        public static FormulaCabeEN ValidaCuandoExistenciaEsDeProduccion(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //-------
            //validar
            //-------      
            ExistenciaEN iExiEN = new ExistenciaEN();
            //iExiEN.CodigoAlmacen = pObj.CodigoAlmacenMercaderia;
            //iExiEN.DescripcionAlmacen = pObj.DescripcionAlmacenMercaderia;
            //iExiEN.CodigoExistencia = pObj.CodigoMercaderia;
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
            iExiEN = ExistenciaRN.EsExistenciaDeNoProduccionValido(iExiEN);

            //este resultado lo pasamos al objeto resultado
            iForCabEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iForCabEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iForCabEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iForCabEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iForCabEN.Adicionales = iExiEN.Adicionales;

            //devolver
            return iForCabEN;
        }
        
        public static FormulaCabeEN ValidaCuandoNoEsDeAlmacen(FormulaCabeEN pObj,string pCodigoAlmacen)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //valida 
            if (pObj.CodigoAlmacen != pCodigoAlmacen)
            {
                iForCabEN.Adicionales.EsVerdad = false;
                iForCabEN.Adicionales.Mensaje = "Esta formula no es del almacen elegido";
                return iForCabEN;
            }

            //ok           
            return iForCabEN;
        }

        public static FormulaCabeEN EsActoEliminarFormulaCabe(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //validar si existe
            iForCabEN = FormulaCabeRN.EsFormulaCabeExistente(pObj);
            if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            //valida si existen esta existencia en MovimientoDeta
            FormulaCabeEN iExiExiEN = FormulaCabeRN.ValidaCuandoCodigoExistenciaEstaEnProduccionCabe(iForCabEN);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //ok            
            return iForCabEN;
        }

        public static FormulaCabeEN ValidaCuandoCodigoExistenciaEstaEnProduccionCabe(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

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

        public static List<FormulaCabeEN> ListarFormulaCabeActivasEnAlmacen(FormulaCabeEN pObj)
        {
            FormulaCabeAD iProCabAD = new FormulaCabeAD();
            return iProCabAD.ListarFormulaCabeActivasEnAlmacen(pObj);
        }

        public static List<FormulaCabeEN> ListarFormulaCabeActivasEnAlmacen(string pCodigoAlmacen)
        {
            //asignar parametros
            FormulaCabeEN iForCabEN = new FormulaCabeEN();
            iForCabEN.CodigoAlmacen = pCodigoAlmacen;
            iForCabEN.Adicionales.CampoOrden = FormulaCabeEN.ClaForCab;

            //ejecutar metodo
            return FormulaCabeRN.ListarFormulaCabeActivasEnAlmacen(iForCabEN);
        }

        public static FormulaCabeEN EsFormulaCabeActivoValido(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iForCabEN; }

            //valida cuando el codigo no existe
            iForCabEN = FormulaCabeRN.EsFormulaCabeExistente(pObj);
            if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            //valida cuando esta desactivada
            FormulaCabeEN iForCabDesEN = FormulaCabeRN.ValidaCuandoEstaDesactivado(iForCabEN);
            if (iForCabDesEN.Adicionales.EsVerdad == false) { return iForCabDesEN; }

            //ok           
            return iForCabEN;
        }

        public static FormulaCabeEN ValidaCuandoEstaDesactivado(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //valida 
            if (pObj.CEstadoFormulaCabe == "0")//desactivado
            {
                iForCabEN.Adicionales.EsVerdad = false;
                iForCabEN.Adicionales.Mensaje = "La formula " + pObj.CodigoExistencia + " esta desactivada";
                return iForCabEN;
            }

            //ok           
            return iForCabEN;
        }

        public static FormulaCabeEN EsFormulaCabeDisponible(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iForCabEN; }

            //validar cuando la existencia no es de produccion
            iForCabEN = FormulaCabeRN.ValidaCuandoExistenciaNoEsDeProduccion(pObj);
            if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            //valida cuando el codigo no existe
            FormulaCabeEN iForCabExiEN = FormulaCabeRN.ValidaCuandoExiste(pObj);
            if (iForCabExiEN.Adicionales.EsVerdad == false) { return iForCabExiEN; }

            //ok           
            return iForCabEN;
        }

        public static FormulaCabeEN ValidaCuandoExiste(FormulaCabeEN pObj)
        {
            FormulaCabeEN iProCabEN = new FormulaCabeEN();
            iProCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(pObj);
            if (iProCabEN.CodigoExistencia != string.Empty)
            {
                iProCabEN.Adicionales.EsVerdad = false;
                iProCabEN.Adicionales.Mensaje = "La formula " + pObj.CodigoExistencia + " ya existe";
            }
            else
            {
                iProCabEN.Adicionales.EsVerdad = true;
            }
            return iProCabEN;
        }
        
        public static FormulaCabeEN ValidaCuandoSemiProductoExiste(FormulaCabeEN pObj, Universal.Opera pOperacion)
        {
            FormulaCabeEN iProCabEN = new FormulaCabeEN();
            iProCabEN = FormulaCabeRN.BuscarFormulaCabeXCodigoSemiProducto(pObj);
            if (iProCabEN.CodigoExistencia != string.Empty)
            {
                //segun operacion
                if (pOperacion == Universal.Opera.Modificar && iProCabEN.CodigoSemiProducto == pObj.CodigoSemiProducto)
                {
                    iProCabEN = FormulaCabeRN.EnBlanco();
                }
                else
                {
                    iProCabEN = FormulaCabeRN.EnBlanco();
                    iProCabEN.Adicionales.EsVerdad = false;
                    iProCabEN.Adicionales.Mensaje = "El codigo de semiproducto " + pObj.CodigoSemiProducto + " ya existe";
                }
            }
            else
            {
                iProCabEN.Adicionales.EsVerdad = true;
            }
            return iProCabEN;
        }
        
        public static FormulaCabeEN EsFormulaCabeSemiProductoDisponible(FormulaCabeEN pObj, Universal.Opera pOperacion)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoSemiProducto == string.Empty) { return iForCabEN; }

            //validar cuando la existencia no es de produccion
            iForCabEN = FormulaCabeRN.ValidaCuandoExistenciaSemiProductoEsDeProduccion(pObj);
            if (iForCabEN.Adicionales.EsVerdad == false) { return iForCabEN; }

            ////valida cuando el codigo no existe
            //FormulaCabeEN iForCabExiEN = FormulaCabeRN.ValidaCuandoSemiProductoExiste(pObj, pOperacion);
            //if (iForCabExiEN.Adicionales.EsVerdad == false) { return iForCabExiEN; }

            //ok           
            return iForCabEN;
        }

        public static FormulaCabeEN ValidaCuandoExistenciaSemiProductoEsDeProduccion(FormulaCabeEN pObj)
        {
            //objeto resultado
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //-------
            //validar
            //-------      
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pObj.CodigoAlmacenSemiProducto;
            iExiEN.DescripcionAlmacen = pObj.DescripcionAlmacenSemiProducto;
            iExiEN.CodigoExistencia = pObj.CodigoSemiProducto;
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
            iExiEN = ExistenciaRN.EsExistenciaActivaDeNoProduccionValido(iExiEN);

            //este resultado lo pasamos al objeto resultado
            iForCabEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iForCabEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iForCabEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iForCabEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iForCabEN.Adicionales = iExiEN.Adicionales;

            //devolver
            return iForCabEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            FormulaCabeAD iPerAD = new FormulaCabeAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            FormulaCabeAD iPerAD = new FormulaCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            FormulaCabeAD iPerAD = new FormulaCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerClaveExistenciaSemiProducto(FormulaCabeEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacenSemiProducto + "-";
            iClave += pObj.CodigoSemiProducto;

            //devolver
            return iClave;
        }

    }
}
