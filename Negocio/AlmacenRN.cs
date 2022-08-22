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
    public class AlmacenRN
    {

        public static AlmacenEN EnBlanco()
        {
            AlmacenEN iPerEN = new AlmacenEN();
            return iPerEN;
        }

        public static void AdicionarAlmacen(AlmacenEN pObj)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            iPerAD.AgregarAlmacen(pObj);
        }

        public static void ModificarAlmacen(AlmacenEN pObj)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            iPerAD.ModificarAlmacen(pObj);
        }

        public static void EliminarAlmacen(AlmacenEN pObj)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            iPerAD.EliminarAlmacen(pObj);
        }

        public static List<AlmacenEN> ListarAlmacenes(AlmacenEN pObj)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            return iPerAD.ListarAlmacenes(pObj);
        }

        public static AlmacenEN BuscarAlmacenXClave(AlmacenEN pObj)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            return iPerAD.BuscarAlmacenXClave(pObj);
        }

        public static AlmacenEN EsAlmacenExistente(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iPerEN = new AlmacenEN();

            //validar si existe en b.d
            iPerEN = AlmacenRN.BuscarAlmacenXClave(pObj);
            if (iPerEN.ClaveAlmacen == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Almacen " + pObj.CodigoAlmacen + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static AlmacenEN EsCodigoAlmacenDisponible(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iPerEN = new AlmacenEN();

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iPerEN; }

            //validar que los dos campos esten llenos
            iPerEN = AlmacenRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok           
            return iPerEN;
        }

        public static AlmacenEN ValidaCuandoCodigoYaExiste(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iPerEN = new AlmacenEN();

            //validar     
            iPerEN = AlmacenRN.BuscarAlmacenXClave(pObj);
            if (iPerEN.CodigoAlmacen != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoAlmacen + " ya existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(AlmacenEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case AlmacenEN.ClaObj: return pObj.ClaveObjeto;
                case AlmacenEN.ClaAlm: return pObj.ClaveAlmacen;
                case AlmacenEN.CodAlm: return pObj.CodigoAlmacen;
                case AlmacenEN.CodEmp: return pObj.CodigoEmpresa;
                case AlmacenEN.DesAlm: return pObj.DescripcionAlmacen;
                case AlmacenEN.DirAlm: return pObj.DireccionAlmacen;
                case AlmacenEN.CodPer: return pObj.CodigoPersonal;
                case AlmacenEN.NomPer: return pObj.NombrePersonal;
                case AlmacenEN.CEstAlm: return pObj.CEstadoAlmacen;
                case AlmacenEN.NEstAlm: return pObj.NEstadoAlmacen;
                case AlmacenEN.UsuAgr: return pObj.UsuarioAgrega;
                case AlmacenEN.FecAgr: return pObj.FechaAgrega.ToString();
                case AlmacenEN.UsuMod: return pObj.UsuarioModifica;
                case AlmacenEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<AlmacenEN> FiltrarAlmacensXTextoEnCualquierPosicion(List<AlmacenEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<AlmacenEN> iLisRes = new List<AlmacenEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (AlmacenEN xPer in pLista)
            {
                string iTexto = AlmacenRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<AlmacenEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<AlmacenEN> pListaAlmacens)
        {
            //lista resultado
            List<AlmacenEN> iLisRes = new List<AlmacenEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaAlmacens; }

            //filtar la lista
            iLisRes = AlmacenRN.FiltrarAlmacensXTextoEnCualquierPosicion(pListaAlmacens, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveAlmacen(AlmacenEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.CodigoAlmacen;

            //retornar
            return iClave;
        }

        public static AlmacenEN EsAlmacenValido(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iAlmEN; }

            //valida cuando el codigo no existe
            iAlmEN = AlmacenRN.EsAlmacenExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //valida cuando no tiene permiso a este almacen
            AlmacenEN iAlmPerEN = AlmacenRN.ValidaCuandoAlmacenNoEsAutorizado(iAlmEN);
            if (iAlmPerEN.Adicionales.EsVerdad == false) { return iAlmPerEN; }

            //ok           
            return iAlmEN;
        }

        public static AlmacenEN ValidaCuandoAlmacenNoEsAutorizado(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida       
            //cuando esta en blanco es "Administrador"     
            if (Universal.gStrPermisosAlmacen == string.Empty) { return iAlmEN; }

            //cuando es 'x' ,quiere decir que no tiene ningun permiso
            if (Universal.gStrPermisosAlmacen == "'x'")
            {
                iAlmEN.Adicionales.EsVerdad = false;
                iAlmEN.Adicionales.Mensaje = "Tu usuario no tiene permiso a ningun almacen, no se puede realizar la operacion";
                return iAlmEN;
            }

            //cuando hay codigos Almacen permitido
            //dar forma al codigoAlmacen seleccionado por el usuario
            string iCodigoUsuario = "'" + pObj.CodigoAlmacen + "'";

            //buscar si existe en la cadena de codigosAlmacen
            if (Cadena.ExisteValorEnConjuntoDeValores(iCodigoUsuario, Universal.gStrPermisosAlmacen) == false)
            {
                iAlmEN.Adicionales.EsVerdad = false;
                iAlmEN.Adicionales.Mensaje = "Este Almacen no esta permitido a tu usuario, no se puede realizar la operacion";
                return iAlmEN;
            }
            
            //ok
            return iAlmEN;
        }

        public static AlmacenEN EsActoModificarAlmacen(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //validar si existe
            iAlmEN = AlmacenRN.EsAlmacenExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //ok            
            return iAlmEN;
        }

        public static AlmacenEN EsActoEliminarAlmacen(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //validar si existe
            iAlmEN = AlmacenRN.EsAlmacenExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //valida si existe este Almacen en existencia
            AlmacenEN iAlmExiEN = AlmacenRN.ValidaCuandoCodigoAlmacenEstaEnExistencia(iAlmEN);
            if (iAlmExiEN.Adicionales.EsVerdad == false) { return iAlmExiEN; }

            //ok            
            return iAlmEN;
        }

        public static AlmacenEN ValidaCuandoCodigoAlmacenEstaEnExistencia(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida
            bool iExisten = ExistenciaRN.ExisteValorEnColumnaConEmpresa(ExistenciaEN.CodAlm, pObj.CodigoAlmacen);
            if (iExisten == true)
            {
                iAlmEN.Adicionales.EsVerdad = false;
                iAlmEN.Adicionales.Mensaje = "Este Almacen tiene existencias registradas, no se puede realizar la operacion";
                return iAlmEN;
            }

            //ok
            return iAlmEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static List<AlmacenEN> ListarAlmacenesExceptoUno(AlmacenEN pObj)
        {
            //lista resultado
            List<AlmacenEN> iLisRes = new List<AlmacenEN>();

            //traemos todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes(pObj);

            //recorrer cada objeto
            foreach (AlmacenEN xAlm in iLisAlm)
            {
                //si el almacen es diferente del almacen que no debe pasar,entonces se agrega a la lista
                if (xAlm.CodigoAlmacen != pObj.CodigoAlmacen)
                {
                    iLisRes.Add(xAlm);
                }
            }

            //devolver
            return iLisRes;
        }

        public static AlmacenEN EsAlmacenValido(AlmacenEN pObj, string pCodigoAlmacenExcepcion)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iAlmEN; }

            //valida cuando el codigo no existe
            iAlmEN = AlmacenRN.EsAlmacenExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //valida cuando sea el codigo almacen de excepcion
            AlmacenEN iAlmExcEN = AlmacenRN.ValidaCuandoCodigoAlmacenEsIgualACodigoExcepcion(iAlmEN, pCodigoAlmacenExcepcion);
            if (iAlmExcEN.Adicionales.EsVerdad == false) { return iAlmExcEN; }

            //ok           
            return iAlmEN;
        }

        public static AlmacenEN ValidaCuandoCodigoAlmacenEsIgualACodigoExcepcion(AlmacenEN pObj, string pCodigoAlmacenExcepcion)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida            
            if (pCodigoAlmacenExcepcion != string.Empty && pObj.CodigoAlmacen == pCodigoAlmacenExcepcion)
            {
                iAlmEN.Adicionales.EsVerdad = false;
                iAlmEN.Adicionales.Mensaje = "Debes elegir otro almacen, no se puede realizar la operacion";
                return iAlmEN;
            }

            //ok
            return iAlmEN;
        }

        public static AlmacenEN EsAlmacenActivoValido(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iAlmEN; }

            //valida cuando el codigo no existe
            iAlmEN = AlmacenRN.EsAlmacenExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //valida cuando esta desactivado
            AlmacenEN iAlmDesEN = AlmacenRN.ValidaCuandoAlmacenEstaDesactivado(iAlmEN);
            if (iAlmDesEN.Adicionales.EsVerdad == false) { return iAlmDesEN; }

            //valida cuando no tiene permiso a este almacen
            AlmacenEN iAlmPerEN = AlmacenRN.ValidaCuandoAlmacenNoEsAutorizado(iAlmEN);
            if (iAlmPerEN.Adicionales.EsVerdad == false) { return iAlmPerEN; }

            //ok           
            return iAlmEN;
        }

        public static AlmacenEN ValidaCuandoAlmacenEstaDesactivado(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida            
            if (pObj.CEstadoAlmacen == "0")//desactivado
            {
                iAlmEN.Adicionales.EsVerdad = false;
                iAlmEN.Adicionales.Mensaje = "El Almacen " + pObj.CodigoAlmacen + " esta desactivado";
                return iAlmEN;
            }

            //ok
            return iAlmEN;
        }

        public static List<AlmacenEN> ListarAlmacenesActivos(AlmacenEN pObj)
        {
            AlmacenAD iPerAD = new AlmacenAD();
            return iPerAD.ListarAlmacenesActivos(pObj);
        }

        public static List<AlmacenEN> ListarAlmacenesActivosExceptoUno(AlmacenEN pObj)
        {
            //lista resultado
            List<AlmacenEN> iLisRes = new List<AlmacenEN>();

            //traemos todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenesActivos(pObj);

            //recorrer cada objeto
            foreach (AlmacenEN xAlm in iLisAlm)
            {
                //si el almacen es diferente del almacen que no debe pasar,entonces se agrega a la lista
                if (xAlm.CodigoAlmacen != pObj.CodigoAlmacen)
                {
                    iLisRes.Add(xAlm);
                }
            }

            //devolver
            return iLisRes;
        }

        public static AlmacenEN EsAlmacenActivoValido(AlmacenEN pObj, string pCodigoAlmacenExcepcion)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iAlmEN; }

            //valida cuando el codigo no existe
            iAlmEN = AlmacenRN.EsAlmacenExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //valida cuando sea el codigo almacen de excepcion
            AlmacenEN iAlmExcEN = AlmacenRN.ValidaCuandoCodigoAlmacenEsIgualACodigoExcepcion(iAlmEN, pCodigoAlmacenExcepcion);
            if (iAlmExcEN.Adicionales.EsVerdad == false) { return iAlmExcEN; }

            //valida cuando esta desactivado
            AlmacenEN iAlmDesEN = AlmacenRN.ValidaCuandoAlmacenEstaDesactivado(iAlmEN);
            if (iAlmDesEN.Adicionales.EsVerdad == false) { return iAlmDesEN; }

            //valida cuando no tiene permiso a este almacen
            AlmacenEN iAlmPerEN = AlmacenRN.ValidaCuandoAlmacenNoEsAutorizado(iAlmEN);
            if (iAlmPerEN.Adicionales.EsVerdad == false) { return iAlmPerEN; }

            //ok           
            return iAlmEN;
        }

        public static List<AlmacenEN> ListarAlmacenes()
        {
            //asignar parametros
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.Adicionales.CampoOrden = AlmacenEN.CodAlm;

            //ejecutar metodo
            return AlmacenRN.ListarAlmacenes(iAlmEN);
        }

        public static AlmacenEN BuscarAlmacen(string pCampoBusqueda, string pValorBusqueda, List<AlmacenEN> pListaBusqueda)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //recorrer cada objeto
            foreach (AlmacenEN xAlm in pListaBusqueda)
            {
                if (AlmacenRN.ObtenerValorDeCampo(xAlm, pCampoBusqueda) == pValorBusqueda)
                {
                    iAlmEN = xAlm;
                    return iAlmEN;
                }
            }

            //devolver
            return iAlmEN;
        }

        public static List<AlmacenEN> ListarAlmacenesActivosParaProduccion(AlmacenEN pObj,ProduccionDetaEN pProDet)
        {
            //lista resultado
            List<AlmacenEN> iLisRes = new List<AlmacenEN>();

            //traer la lista de almacenes activos permitidos a este usuario
            List<AlmacenEN> iLisAlmPer = AlmacenRN.ListarAlmacenesActivos(pObj);

            //obtener los almacenes de produccion ,en formato separado por comas
            string iAlmacenesProduccion = ProduccionDetaRN.ObtenerStrCodigosAlmacenes(pProDet);

            //filtrar solo estos almacenes
            iLisRes = ListaG.FiltrarPorConjuntoValores<AlmacenEN>(iLisAlmPer, AlmacenEN.CodAlm, iAlmacenesProduccion);

            //devolver
            return iLisRes;
        }

        public static AlmacenEN EsAlmacenActivoValido(AlmacenEN pObj,ProduccionDetaEN pProDet)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iAlmEN; }

            //valida cuando el codigo no existe
            iAlmEN = AlmacenRN.EsAlmacenExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //valida cuando esta desactivado
            AlmacenEN iAlmDesEN = AlmacenRN.ValidaCuandoAlmacenEstaDesactivado(iAlmEN);
            if (iAlmDesEN.Adicionales.EsVerdad == false) { return iAlmDesEN; }

            //valida cuando no tiene permiso a este almacen
            AlmacenEN iAlmPerEN = AlmacenRN.ValidaCuandoAlmacenNoEsAutorizado(iAlmEN);
            if (iAlmPerEN.Adicionales.EsVerdad == false) { return iAlmPerEN; }

            //valida cuando no es de produccion
            AlmacenEN iAlmProEN = AlmacenRN.ValidaCuandoAlmacenNoEsDeProduccion(iAlmEN,pProDet);
            if (iAlmProEN.Adicionales.EsVerdad == false) { return iAlmProEN; }

            //ok           
            return iAlmEN;
        }

        public static AlmacenEN ValidaCuandoAlmacenNoEsDeProduccion(AlmacenEN pObj, ProduccionDetaEN pProDet)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida            
            //obtener los almacenes de produccion ,en formato separado por comas
            string iAlmacenesProduccion = ProduccionDetaRN.ObtenerStrCodigosAlmacenes(pProDet);
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CodigoAlmacen, iAlmacenesProduccion) == false)
            {
                iAlmEN.Adicionales.EsVerdad = false;
                iAlmEN.Adicionales.Mensaje = "El Almacen " + pObj.CodigoAlmacen + " no es de produccion";
                return iAlmEN;
            }

            //ok
            return iAlmEN;
        }

        public static List<string> ListarCodigosAlmacenes()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traer a todos los almacenes de la empresa de acceso
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //obtener la lista de valores de codigos de almacen
            iLisRes = ListaG.ListarValoresDeCampo<AlmacenEN>(iLisAlm, AlmacenEN.CodAlm);

            //devolver
            return iLisRes;
        }

        public static AlmacenEN BuscarAlmacenXCodigo(string pCodigoAlmacen)
        {
            //asignar parametros
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = pCodigoAlmacen;
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);

            //ejecutar metodo
            return AlmacenRN.BuscarAlmacenXClave(iAlmEN);
        }

        public static List<AlmacenEN> ListarAlmacenesActivosParaAdicionalesEncajado(AlmacenEN pObj)
        {
            //lista resultado
            List<AlmacenEN> iLisRes = new List<AlmacenEN>();

            //traer la lista de almacenes activos permitidos a este usuario
            List<AlmacenEN> iLisAlmPer = AlmacenRN.ListarAlmacenesActivos(pObj);

            //obtener los almacenes para adicionales encajado ,en formato separado por comas
            string iAlmacenesEncajado = ObtenerStrCodigosAlmacenesParaAdicionalesEncajado();

            //filtrar solo estos almacenes
            iLisRes = ListaG.FiltrarPorConjuntoValores<AlmacenEN>(iLisAlmPer, AlmacenEN.CodAlm, iAlmacenesEncajado);

            //devolver
            return iLisRes;
        }

        public static string ObtenerStrCodigosAlmacenesParaAdicionalesEncajado()
        {
            //asignar parametros
            List<string> iLisStrCodAlm = new List<string>() { "A09", "A11" };

            //concatenar y devolver
            return Cadena.ConcatenarTexto(iLisStrCodAlm, ",");
        }

        public static AlmacenEN EsAlmacenParaEncajadoActivoValido(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iAlmEN; }

            //valida cuando el codigo no existe
            iAlmEN = AlmacenRN.EsAlmacenExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //valida cuando esta desactivado
            AlmacenEN iAlmDesEN = AlmacenRN.ValidaCuandoAlmacenEstaDesactivado(iAlmEN);
            if (iAlmDesEN.Adicionales.EsVerdad == false) { return iAlmDesEN; }

            //valida cuando no tiene permiso a este almacen
            AlmacenEN iAlmPerEN = AlmacenRN.ValidaCuandoAlmacenNoEsAutorizado(iAlmEN);
            if (iAlmPerEN.Adicionales.EsVerdad == false) { return iAlmPerEN; }

            //valida cuando no es de produccion
            AlmacenEN iAlmProEN = AlmacenRN.ValidaCuandoAlmacenNoEsDeEncajado(iAlmEN);
            if (iAlmProEN.Adicionales.EsVerdad == false) { return iAlmProEN; }

            //ok           
            return iAlmEN;
        }

        public static AlmacenEN ValidaCuandoAlmacenNoEsDeEncajado(AlmacenEN pObj)
        {
            //objeto resultado
            AlmacenEN iAlmEN = new AlmacenEN();

            //valida            
            //obtener los almacenes para encajado ,en formato separado por comas
            string iAlmacenesEncajado = ObtenerStrCodigosAlmacenesParaAdicionalesEncajado();
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CodigoAlmacen, iAlmacenesEncajado) == false)
            {
                iAlmEN.Adicionales.EsVerdad = false;
                iAlmEN.Adicionales.Mensaje = "El Almacen " + pObj.CodigoAlmacen + " no es de encajado";
                return iAlmEN;
            }

            //ok
            return iAlmEN;
        }


    }
}
