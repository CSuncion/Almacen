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
    public class PermisoAlmacenRN
    {

        public static PermisoAlmacenEN EnBlanco()
        {
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();
            return iObjEN;
        }

        public static void AdicionarPermisoAlmacen(List<PermisoAlmacenEN> pLista)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            iObjAD.AdicionarPermisoAlmacen(pLista);
        }

        public static void AdicionarPermisoAlmacen(PermisoAlmacenEN pObj)
        {
            //Asignar parametros
            List<PermisoAlmacenEN> iLisObj = new List<PermisoAlmacenEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            PermisoAlmacenRN.AdicionarPermisoAlmacen(iLisObj);
        }

        public static void ModificarPermisoAlmacen(List<PermisoAlmacenEN> pLista)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            iObjAD.ModificarPermisoAlmacen(pLista);
        }

        public static void ModificarPermisoAlmacen(PermisoAlmacenEN pObj)
        {
            //Asignar parametros
            List<PermisoAlmacenEN> iLisObj = new List<PermisoAlmacenEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            PermisoAlmacenRN.ModificarPermisoAlmacen(iLisObj);
        }

        public static void EliminarPermisoAlmacen(List<PermisoAlmacenEN> pLista)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            iObjAD.EliminarPermisoAlmacen(pLista);
        }

        public static void EliminarPermisoAlmacenXUsuario(string pCodigoUsuario)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            iObjAD.EliminarPermisoAlmacenXUsuario(pCodigoUsuario);
        }

        public static void EliminarPermisoAlmacenXAlmacen(string pCodigoAlmacen)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            iObjAD.EliminarPermisoAlmacenXAlmacen(pCodigoAlmacen);
        }

        public static void EliminarPermisoAlmacen(PermisoAlmacenEN pObj)
        {
            //Asignar parametros
            List<PermisoAlmacenEN> iLisObj = new List<PermisoAlmacenEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            PermisoAlmacenRN.EliminarPermisoAlmacen(iLisObj);
        }

        public static List<PermisoAlmacenEN> ListarPermisoAlmacen(PermisoAlmacenEN pObj)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ListarPermisoAlmacen(pObj);
        }

        public static List<PermisoAlmacenEN> ListarPermisoAlmacen()
        {
            //asignar parametros
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();
            iObjEN.Adicionales.CampoOrden = PermisoAlmacenEN.ClaPerAlm;

            //ejecutar metodo
            return PermisoAlmacenRN.ListarPermisoAlmacen(iObjEN);
        }

        public static PermisoAlmacenEN BuscarPermisoAlmacenXClave(PermisoAlmacenEN pObj)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.BuscarPermisoAlmacenXClave(pObj);
        }

        public static PermisoAlmacenEN EsPermisoAlmacenExistente(PermisoAlmacenEN pObj)
        {
            //objeto resultado
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();

            //validar si existe en b.d
            iObjEN = PermisoAlmacenRN.BuscarPermisoAlmacenXClave(pObj);
            if (iObjEN.ClavePermisoAlmacen == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static PermisoAlmacenEN EsCodigoPermisoAlmacenDisponible(PermisoAlmacenEN pObj)
        {
            //objeto resultado
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoUsuario == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = PermisoAlmacenRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static PermisoAlmacenEN ValidaCuandoCodigoYaExiste(PermisoAlmacenEN pObj)
        {
            //objeto resultado
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();

            //validar
            iObjEN = PermisoAlmacenRN.BuscarPermisoAlmacenXClave(pObj);
            if (iObjEN.ClavePermisoAlmacen != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static List<PermisoAlmacenEN> FiltrarPermisoAlmacenXTextoEnCualquierPosicion(List<PermisoAlmacenEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<PermisoAlmacenEN> iLisRes = new List<PermisoAlmacenEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (PermisoAlmacenEN xObj in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<PermisoAlmacenEN>(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<PermisoAlmacenEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<PermisoAlmacenEN> pLista)
        {
            //lista resultado
            List<PermisoAlmacenEN> iLisRes = new List<PermisoAlmacenEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = PermisoAlmacenRN.FiltrarPermisoAlmacenXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClavePermisoAlmacen(PermisoAlmacenEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";           
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoUsuario;

            //retornar
            return iClave;
        }

        public static PermisoAlmacenEN EsPermisoAlmacenValido(PermisoAlmacenEN pObj)
        {
            //objeto resultado
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoUsuario == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = PermisoAlmacenRN.EsPermisoAlmacenExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }
               
        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroPermisoAlmacenAutogenerado(PermisoAlmacenEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = PermisoAlmacenRN.ObtenerMaximoValorEnColumna("CampoDondeBuscar");

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static PermisoAlmacenEN EsActoAdicionarPermisoAlmacen(PermisoAlmacenEN pObj)
        {
            //objeto resultado
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();

            //ok          
            return iObjEN;
        }

        public static PermisoAlmacenEN EsActoModificarPermisoAlmacen(PermisoAlmacenEN pObj)
        {
            //objeto resultado
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();

            //valida cuando el codigo no existe
            iObjEN = PermisoAlmacenRN.EsPermisoAlmacenExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static PermisoAlmacenEN EsActoEliminarPermisoAlmacen(PermisoAlmacenEN pObj)
        {
            //objeto resultado
            PermisoAlmacenEN iObjEN = new PermisoAlmacenEN();

            //valida cuando el codigo no existe
            iObjEN = PermisoAlmacenRN.EsPermisoAlmacenExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static List<PermisoAlmacenEN> ListarPermisosAlmacenAbiertasXUsuario(PermisoAlmacenEN pObj)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ListarPermisosAlmacenAbiertasXUsuario(pObj);
        }

        public static List<PermisoAlmacenEN> ListarPermisosAlmacenAbiertasXUsuario(string pCodigoUsuario)
        {
            //asignar parametros
            PermisoAlmacenEN iPerPlaEN = new PermisoAlmacenEN();
            iPerPlaEN.CodigoUsuario = pCodigoUsuario;
            iPerPlaEN.Adicionales.CampoOrden = PermisoAlmacenEN.CodAlm;

            //ejecutar metodo
            return PermisoAlmacenRN.ListarPermisosAlmacenAbiertasXUsuario(iPerPlaEN);
        }

        public static List<PermisoAlmacenEN> ListarPermisosAlmacenAbiertasAutorizadasXUsuario(PermisoAlmacenEN pObj)
        {
            PermisoAlmacenAD iObjAD = new PermisoAlmacenAD();
            return iObjAD.ListarPermisosAlmacenAbiertasAutorizadasXUsuario(pObj);
        }

        public static List<PermisoAlmacenEN> ListarPermisosAlmacenAbiertasAutorizadasXUsuario(string pCodigoUsuario)
        {
            //asignar parametros
            PermisoAlmacenEN iPerPlaEN = new PermisoAlmacenEN();
            iPerPlaEN.CodigoUsuario = pCodigoUsuario;
            iPerPlaEN.Adicionales.CampoOrden = PermisoAlmacenEN.CodAlm;

            //ejecutar metodo
            return PermisoAlmacenRN.ListarPermisosAlmacenAbiertasAutorizadasXUsuario(iPerPlaEN);
        }

        public static void ModificarPermisoAlmacen(PermisoAlmacenEN pObj, List<PermisoAlmacenEN> pLista)
        {
            //lista actualizada
            List<PermisoAlmacenEN> iLisPem = new List<PermisoAlmacenEN>();

            //buscamos el objeto en la lista pLista
            foreach (PermisoAlmacenEN xPem in pLista)
            {
                if (xPem.ClavePermisoAlmacen == pObj.ClavePermisoAlmacen)
                {
                    xPem.VerdadFalso = pObj.VerdadFalso;
                    xPem.CPermitir = Conversion.BooleanACadena(pObj.VerdadFalso, "");
                }
                iLisPem.Add(xPem);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisPem);
        }

        public static void AdicionarPermisosAlmacenXUsuario(UsuarioEN pUsu)
        {
            //Traer todas las Almacens del sistema
            List<AlmacenEN> iLisPlaSis = AlmacenRN.ListarAlmacenes();

            //armar la lista de los nuevos permisos para este usuario
            List<PermisoAlmacenEN> iLisPerPla = PermisoAlmacenRN.ArmarListaNuevosPermisosAlmacenDeUsuario(iLisPlaSis, pUsu);

            //grabamos la lista
            PermisoAlmacenRN.AdicionarPermisoAlmacen(iLisPerPla);
        }

        public static void PasarDatosIdenticosAPermisoAlmacen(PermisoAlmacenEN pPerPla, AlmacenEN pPla)
        {
            pPerPla.CodigoEmpresa = pPla.CodigoEmpresa;
            pPerPla.NombreEmpresa = pPerPla.NombreEmpresa;           
            pPerPla.CodigoAlmacen = pPla.CodigoAlmacen;
            pPerPla.DescripcionAlmacen = pPla.DescripcionAlmacen;
            pPerPla.CEstadoAlmacen = pPla.CEstadoAlmacen;
        }

        public static void PasarDatosIdenticosAPermisoAlmacen(PermisoAlmacenEN pPerPla, UsuarioEN pUsu)
        {
            pPerPla.CodigoUsuario = pUsu.CodigoUsuario;
            pPerPla.NombreUsuario = pPerPla.NombreUsuario;
            pPerPla.CodigoPerfil = pUsu.CodigoPerfil;            
        }

        public static List<PermisoAlmacenEN> ArmarListaNuevosPermisosAlmacenDeUsuario(List<AlmacenEN> pListaAlmacens, UsuarioEN pUsu)
        {
            //lista resultados
            List<PermisoAlmacenEN> iLisRes = new List<PermisoAlmacenEN>();

            //recorrer cada objeto "Almacen"
            foreach (AlmacenEN xPla in pListaAlmacens)
            {
                //creamos un nuevo objeto
                PermisoAlmacenEN iPerPlaEN = PermisoAlmacenRN.ArmarNuevoPermisoAlmacen(xPla, pUsu);

                //insertamos a la lista resultados
                iLisRes.Add(iPerPlaEN);
            }

            //devolver
            return iLisRes;
        }
        
        public static PermisoAlmacenEN ArmarNuevoPermisoAlmacen(AlmacenEN pPla, UsuarioEN pUsu)
        {
            //objeto resultado
            PermisoAlmacenEN iPerPlaEN = new PermisoAlmacenEN();

            //pasamos datos
            PermisoAlmacenRN.PasarDatosIdenticosAPermisoAlmacen(iPerPlaEN, pPla);
            PermisoAlmacenRN.PasarDatosIdenticosAPermisoAlmacen(iPerPlaEN, pUsu);
            iPerPlaEN.ClavePermisoAlmacen = PermisoAlmacenRN.ObtenerClavePermisoAlmacen(iPerPlaEN);
            iPerPlaEN.CPermitir = "0";//no

            //devolver
            return iPerPlaEN;
        }

        public static void AdicionarPermisosAlmacenXAlmacen(AlmacenEN pPla)
        {
            //Traer todos los usuarios del sistema
            List<UsuarioEN> iLisUsuSis = UsuarioRN.ListarUsuarios();

            //armar la lista de los nuevos permisos para esta Almacen
            List<PermisoAlmacenEN> iLisPerPla = PermisoAlmacenRN.ArmarListaNuevosPermisosAlmacenDeAlmacen(iLisUsuSis, pPla);

            //grabamos la lista
            PermisoAlmacenRN.AdicionarPermisoAlmacen(iLisPerPla);
        }

        public static List<PermisoAlmacenEN> ArmarListaNuevosPermisosAlmacenDeAlmacen(List<UsuarioEN> pListaUsuarios, AlmacenEN pPla)
        {
            //lista resultados
            List<PermisoAlmacenEN> iLisRes = new List<PermisoAlmacenEN>();

            //recorrer cada objeto "Almacen"
            foreach (UsuarioEN xUsu in pListaUsuarios)
            {
                //creamos un nuevo objeto
                PermisoAlmacenEN iPerPlaEN = PermisoAlmacenRN.ArmarNuevoPermisoAlmacen(pPla, xUsu);

                //insertamos a la lista resultados
                iLisRes.Add(iPerPlaEN);
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerStrPermisosAlmacen()
        {
            //si es administrador o desarrollador , devuelve vacio(accesa a todas las Almacens)
            if (Cadena.ExisteValorEnConjuntoDeValores(Universal.gCodigoPerfil, "01") == true) { return string.Empty; }

            //aqui hay que traer a los permisos Almacen de este usuario actual
            List<PermisoAlmacenEN> iLisPerPla = PermisoAlmacenRN.ListarPermisosAlmacenAbiertasAutorizadasXUsuario(Universal.gCodigoUsuario);

            //si el usuario no tiene ningun permiso autorizado,entonces le pasamos un dato erroneo
            if (iLisPerPla.Count == 0) { return "'x'"; }

            //aqui le sacamos el valor de la lista (esta cadena es para el "AD" funcion IN)
            return PermisoAlmacenRN.ObtenerStrParaIN(PermisoAlmacenEN.CodAlm, iLisPerPla);
        }

        public static string ObtenerStrParaIN(string pNombreColumna, List<PermisoAlmacenEN> pListaPermisoAlmacen)
        {
            //valor resultado
            string iValor = string.Empty;

            //obtener
            foreach (PermisoAlmacenEN xPerPla in pListaPermisoAlmacen)
            {
                iValor += "'" + ObjetoG.ObtenerTexto<PermisoAlmacenEN>(xPerPla, pNombreColumna) + "',";
            }

            //si iValor esta vacio , entonces le ponemos ''
            if (iValor == string.Empty) { return "''"; }

            //aqui si hay dato, entonces quitamos el ultimo caracter(que es la ultima coma)
            iValor = iValor.Remove(iValor.Length - 1);

            //devolver
            return iValor;
        }

    }
}
