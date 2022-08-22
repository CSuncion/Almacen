using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;

namespace Negocio
{
    public class PerfilRN
    {

        public static PerfilEN EnBlanco()
        {
            PerfilEN iPerEN = new PerfilEN();
            return iPerEN;
        }

        public static void AdicionarPerfil(PerfilEN pObj)
        {
            PerfilAD iPerAD = new PerfilAD();
            iPerAD.AgregarPerfil(pObj);
        }

        public static void ModificarPerfil(PerfilEN pObj)
        {
            PerfilAD iPerAD = new PerfilAD();
            iPerAD.ModificarPerfil(pObj);
        }

        public static void EliminarPerfil(PerfilEN pObj)
        {
            PerfilAD iPerAD = new PerfilAD();
            iPerAD.EliminarPerfil(pObj);
        }

        public static List<PerfilEN> ListarPerfiles(PerfilEN pObj)
        {
            PerfilAD iPerAD = new PerfilAD();
            return iPerAD.ListarPerfiles(pObj);
        }

        public static List<PerfilEN> ListarPerfilesXEstado(PerfilEN pObj)
        {
            PerfilAD iPerAD = new PerfilAD();
            return iPerAD.ListarPerfilesXEstado(pObj);
        }

        public static PerfilEN BuscarPerfilXCodigo(PerfilEN pObj)
        {
            PerfilAD iPerAD = new PerfilAD();
            return iPerAD.BuscarPerfilXCodigo(pObj);
        }

        public static PerfilEN EsPerfilExistente(PerfilEN pObj)
        {
            PerfilEN iPerEN = new PerfilEN();
            iPerEN = PerfilRN.BuscarPerfilXCodigo(pObj);
            if (iPerEN.CodigoPerfil == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Perfil " + pObj.CodigoPerfil + " no existe";
            }
            else
            {
                iPerEN.Adicionales.EsVerdad = true;

            }
            return iPerEN;
        }

        public static PerfilEN EsCodigoPerfilDisponible(PerfilEN pObj)
        {
            PerfilEN iPerEN = new PerfilEN();

            //si no hay codigo pasa verdadero
            if (pObj.CodigoPerfil == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = true;
                iPerEN.Adicionales.Mensaje = string.Empty;
                return iPerEN;
            }

            //aqui si hay codigo
            iPerEN = PerfilRN.BuscarPerfilXCodigo(pObj);
            if (iPerEN.CodigoPerfil == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = true;
            }
            else
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoPerfil + " ya le pertenece a un Perfil";
            }
            return iPerEN;
        }

        public static PerfilEN EsActoModificarPerfil(PerfilEN pObj)
        {
            //objeto resultado
            PerfilEN iPerEN = new PerfilEN();

            //preguntar si existe el perfil
            iPerEN = PerfilRN.EsPerfilExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //preguntar si es modificable el perfil
            if (iPerEN.EliminablePerfil == "0")//no
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Perfil " + pObj.CodigoPerfil + " no es modificable";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PerfilEN EsActoEliminarPerfil(PerfilEN pObj)
        {
            //objeto resultado
            PerfilEN iPerEN = new PerfilEN();

            //preguntar si existe el perfil
            iPerEN = PerfilRN.EsPerfilExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //validar los perfiles no eliminables 
            if (iPerEN.EliminablePerfil == "0")//no
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Perfil " + pObj.CodigoPerfil + " no se puede eliminar";
                return iPerEN;
            }

            //validar si este perfil esta referenciado a un usuario            
            if (UsuarioRN.ExisteValorEnColumna(UsuarioEN.CodPer, pObj.CodigoPerfil) == true)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Perfil " + pObj.CodigoPerfil + " Esta referenciado en Usuario(s)";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static PerfilEN EsActoAsignarPermisos(PerfilEN pObj)
        {
            //objeto resultado
            PerfilEN iPerEN = new PerfilEN();

            //preguntar si existe el perfil
            iPerEN = PerfilRN.EsPerfilExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //preguntar si es el perfil(01 o 02)
            if (Cadena.ExisteValorEnConjuntoDeValores(iPerEN.CodigoPerfil, "01,02") == true)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Al Perfil " + pObj.CodigoPerfil + " no se puede asignar permisos";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(PerfilEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case PerfilEN.ClaObj: return pObj.ClaveObjeto;
                case PerfilEN.CodPer: return pObj.CodigoPerfil;
                case PerfilEN.NomPer: return pObj.NombrePerfil;
                case PerfilEN.DesPer: return pObj.DescripcionPerfil;
                case PerfilEN.CEstPer: return pObj.CEstadoPerfil;
                case PerfilEN.NEstPer: return pObj.NEstadoPerfil;
                case PerfilEN.UsuAgr: return pObj.UsuarioAgrega;
                case PerfilEN.FecAgr: return pObj.FechaAgrega.ToString();
                case PerfilEN.UsuMod: return pObj.UsuarioModifica;
                case PerfilEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<PerfilEN> FiltrarPerfilesXTextoEnCualquierPosicion(List<PerfilEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<PerfilEN> iLisRes = new List<PerfilEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (PerfilEN xPer in pLista)
            {
                string iTexto = PerfilRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<PerfilEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<PerfilEN> pListaPerfiles)
        {
            //lista resultado
            List<PerfilEN> iLisRes = new List<PerfilEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaPerfiles; }

            //filtar la lista
            iLisRes = PerfilRN.FiltrarPerfilesXTextoEnCualquierPosicion(pListaPerfiles, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }



    }
}
