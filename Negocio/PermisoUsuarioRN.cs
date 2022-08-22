using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;
using Entidades.Adicionales;
using System.Collections;

namespace Negocio
{
    public class PermisoUsuarioRN
    {
        public static PermisoUsuarioEN EnBlanco()
        {
            PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
            return iPerUsuEN;
        }

        public static void AdicionarPermisoUsuario(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            iPerUsuAD.AgregarPermisoUsuario(pObj);
        }

        public static void AdicionarPermisoUsuarioMasivo(List<PermisoUsuarioEN> pLista)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            iPerUsuAD.AgregarPermisoUsuarioMasivo(pLista);
        }

        public static void ModificarPermisoUsuario(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            iPerUsuAD.ModificarPermisoUsuario(pObj);
        }

        public static void ModificarPermisoUsuario(PermisoUsuarioEN pObj, List<PermisoUsuarioEN> pLista)
        {
            //lista actualizada
            List<PermisoUsuarioEN> iLisPerUsu = new List<PermisoUsuarioEN>();

            //buscamos el objeto en la lista pLista
            foreach (PermisoUsuarioEN xPerUsu in pLista)
            {
                if (xPerUsu.ClavePermisoUsuario == pObj.ClavePermisoUsuario)
                {
                    xPerUsu.VerdadFalso = pObj.VerdadFalso;
                    xPerUsu.CPermitir = Conversion.BooleanACadena(pObj.VerdadFalso, "");
                }
                iLisPerUsu.Add(xPerUsu);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisPerUsu);
        }

        public static void ModificarPermisoUsuarioMasivo(List<PermisoUsuarioEN> pLista)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            iPerUsuAD.ModificarPermisoUsuarioMasivo(pLista);
        }

        public static void EliminarPermisoUsuario(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            iPerUsuAD.EliminarPermisoUsuario(pObj);
        }

        public static void EliminarPermisosUsuarioDeUsuario(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            iPerUsuAD.EliminarPermisosUsuarioDeUsuario(pObj);
        }

        public static void EliminarPermisosUsuarioXVentanaBoton(List<VentanaBotonEN> pLista)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            iPerUsuAD.EliminarPermisosUsuarioXVentanaBoton(pLista);
        }

        public static void EliminarPermisosUsuarioXVentana(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            iPerUsuAD.EliminarPermisosUsuarioXVentana(pObj);
        }

        public static PermisoUsuarioEN BuscarPermisoUsuarioXClave(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            return iPerUsuAD.BuscarPermisoUsuarioXClave(pObj);
        }

        public static List<PermisoUsuarioEN> ListarPermisoUsuario(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            return iPerUsuAD.ListarPermisoUsuario(pObj);
        }

        public static void AdicionarPermisosUsuarioXVentanaBoton(List<VentanaBotonEN> pLista)
        {
            //Traer todos los usuarios del sistema        
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.Adicionales.CampoOrden = UsuarioEN.CodUsu;
            List<UsuarioEN> iLisUsu = UsuarioRN.ListarUsuarios(iUsuEN);

            //armar la lista de los nuevos permisos para este usuario
            List<PermisoUsuarioEN> iLisPerUsu = new List<PermisoUsuarioEN>();
            foreach (UsuarioEN xUsu in iLisUsu)
            {
                foreach (VentanaBotonEN xVenBot in pLista)
                {
                    PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
                    iPerUsuEN.CodigoVentana = xVenBot.CodigoVentana;
                    iPerUsuEN.CodigoBoton = xVenBot.CodigoBoton;
                    iPerUsuEN.CodigoUsuario = xUsu.CodigoUsuario;
                    iPerUsuEN.ClavePermisoUsuario = PermisoUsuarioRN.ObtenerClavePermisoUsuario(iPerUsuEN);
                    iPerUsuEN.CPermitir = "0"; //no permitir                
                    iLisPerUsu.Add(iPerUsuEN);
                }
            }
            //grabamos la lista
            PermisoUsuarioRN.AdicionarPermisoUsuarioMasivo(iLisPerUsu);
        }

        public static string ObtenerClavePermisoUsuario(PermisoUsuarioEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoVentana + "-";
            iClave += pObj.CodigoBoton + "-";
            iClave += pObj.CodigoUsuario;
            return iClave;
        }

        public static List<PermisoUsuarioEN> ListarPermisosUsuarioDeVentana(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            return iPerUsuAD.ListarPermisosUsuarioDeVentana(pObj);
        }

        public static void MarcarTodos(List<PermisoUsuarioEN> pLista, bool pPermitir)
        {
            //lista actualizada
            List<PermisoUsuarioEN> iLisPerUsu = new List<PermisoUsuarioEN>();

            //buscamos el objeto en la lista pLista
            foreach (PermisoUsuarioEN xPerUsu in pLista)
            {
                xPerUsu.VerdadFalso = pPermitir;
                xPerUsu.CPermitir = Conversion.BooleanACadena(xPerUsu.VerdadFalso, "");
                iLisPerUsu.Add(xPerUsu);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisPerUsu);
        }

        public static void AdicionarPermisosUsuarioParaUsuario(PermisoUsuarioEN pObj)
        {
            //Traer todos las VentanasBoton         
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();
            iVenBotEN.Adicionales.CampoOrden = VentanaBotonEN.ClaVenBot;
            List<VentanaBotonEN> iLisVenBot = VentanaBotonRN.ListarVentanaBotones(iVenBotEN);

            //armar la lista de los nuevos permisos para este usuario
            List<PermisoUsuarioEN> iLisPerUsu = new List<PermisoUsuarioEN>();
            foreach (VentanaBotonEN xVenBot in iLisVenBot)
            {
                PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
                iPerUsuEN.CodigoSubMenu = xVenBot.CodigoSubMenu;
                iPerUsuEN.CodigoVentana = xVenBot.CodigoVentana;
                iPerUsuEN.CodigoBoton = xVenBot.CodigoBoton;
                iPerUsuEN.CodigoUsuario = pObj.CodigoUsuario;
                iPerUsuEN.ClavePermisoUsuario = PermisoUsuarioRN.ObtenerClavePermisoUsuario(iPerUsuEN);
                iPerUsuEN.CPermitir = "0"; //no permitir                
                iLisPerUsu.Add(iPerUsuEN);
            }
            //grabamos la lista
            PermisoUsuarioRN.AdicionarPermisoUsuarioMasivo(iLisPerUsu);
        }

        public static List<PermisoUsuarioEN> ListarPermisosUsuarioParaMenuPrincipal()
        {
            //lista resultado
            List<PermisoUsuarioEN> iLisRes = new List<PermisoUsuarioEN>();

            //si el usuario es de perfil personalizado(02),entonces buscamos los permisos
            //en PermisoUsuario
            if (Universal.gCodigoPerfil == "02")
            {
                PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
                iPerUsuEN.CodigoUsuario = Universal.gCodigoUsuario;
                iPerUsuEN.Adicionales.CampoOrden = PermisoUsuarioEN.CodVen;
                return PermisoUsuarioRN.ListarPermisosUsuarioDeUsuario(iPerUsuEN);
            }

            //si el usuario tiene otro perfil diferente a los 2 primeros,entonces buscamos
            //los permisos en PermisoPerfil          
            PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
            iPerPerEN.CodigoPerfil = Universal.gCodigoPerfil;
            iPerPerEN.Adicionales.CampoOrden = PermisoPerfilEN.CodVen;
            List<PermisoPerfilEN> iLisPer = PermisoPerfilRN.ListarPermisosPerfilDePerfil(iPerPerEN);

            //transformar la lista de permisoPerfil a lista PermisUsuario y a la vez retornar esta lista
            return PermisoUsuarioRN.TransformarAListaPermisoUsuario(iLisPer);

        }
             
        public static List<PermisoUsuarioEN> ListarPermisosUsuarioDeUsuario(PermisoUsuarioEN pObj)
        {
            PermisoUsuarioAD iPerUsuAD = new PermisoUsuarioAD();
            return iPerUsuAD.ListarPermisosUsuarioDeUsuario(pObj);
        }

        public static List<PermisoUsuarioEN> ListarPermisosUsuarioParaVentana(string pCodigoVentana)
        {
            //lista resultado
            List<PermisoUsuarioEN> iLisRes = new List<PermisoUsuarioEN>();

            //si el usuario es de perfil personalizado(02),entonces buscamos los permisos
            //en PermisoUsuario
            if (Universal.gCodigoPerfil == "02")
            {
                PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
                iPerUsuEN.CodigoUsuario = Universal.gCodigoUsuario;
                iPerUsuEN.CodigoVentana = pCodigoVentana;
                iPerUsuEN.Adicionales.CampoOrden = PermisoUsuarioEN.CodBot;
                return PermisoUsuarioRN.ListarPermisosUsuarioDeVentana(iPerUsuEN);
            }

            //si el usuario tiene otro perfil diferente de (02) ,entonces buscamos
            //los permisos en PermisoPerfil         
            PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
            iPerPerEN.CodigoPerfil = Universal.gCodigoPerfil;
            iPerPerEN.CodigoVentana = pCodigoVentana;
            iPerPerEN.Adicionales.CampoOrden = PermisoPerfilEN.CodBot;
            List<PermisoPerfilEN> iLisPerPer = PermisoPerfilRN.ListarPermisosPerfilDeVentana(iPerPerEN);

            //transformamos a lista permisoUsuario
            iLisRes = PermisoUsuarioRN.TransformarAListaPermisoUsuario(iLisPerPer);

            //retornar
            return iLisRes;
        }

        public static Hashtable ListarPermisosParaVentana(string pCodigoVentana, int pNroRegistrosGrilla)
        {
            //objeto resultado
            Hashtable iLisRes = new Hashtable();

            //traemos los permisos de la ventana en PermisoUsuario
            List<PermisoUsuarioEN> iLisPerUsu = PermisoUsuarioRN.ListarPermisosUsuarioParaVentana(pCodigoVentana);

            //recorrer cada objeto
            foreach (PermisoUsuarioEN xPerUsu in iLisPerUsu)
            {
                //pasamos datos                 
                string iClave = xPerUsu.NombreControl;
                string iValor = PermisoUsuarioRN.ObtenerPermisoParaBotonVentana(xPerUsu, pNroRegistrosGrilla);

                //agregamos al hashtable
                iLisRes.Add(iClave, iValor);
            }

            //retornar
            return iLisRes;
        }

        public static string ObtenerPermisoParaBotonVentana(PermisoUsuarioEN pPerUsu, int pNumeroRegistrosGrilla)
        {
            //valor resultado
            string iValor = string.Empty;

            //si el permiso no aplica validar la grilla
            if ( pPerUsu.CValidaGrilla == "0")//no
            {
                iValor = pPerUsu.CPermitir;
            }
            else
            {
                //aqui el permiso depende si la grilla esta vacia
                iValor = Cadena.CompararDosValores(pNumeroRegistrosGrilla, 0, "0", pPerUsu.CPermitir);
            }

            //retornar
            return iValor;
        }

        public static PermisoUsuarioEN TransformarAPermisoUsuario(PermisoPerfilEN pPerPer)
        { 
            //objeto resultado
            PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();

            //pasar datos
            iPerUsuEN.CodigoBoton = pPerPer.CodigoBoton;
            iPerUsuEN.NombreBoton = pPerPer.NombreBoton;
            iPerUsuEN.NombreControl = pPerPer.NombreControl;
            iPerUsuEN.CValidaGrilla = pPerPer.CValidaGrilla;
            iPerUsuEN.CodigoVentana = pPerPer.CodigoVentana;
            iPerUsuEN.NombreControlVentana = pPerPer.NombreControlVentana;
            iPerUsuEN.CPermitir = pPerPer.CPermitir;
        
            //retornar
            return iPerUsuEN;
        }

        public static List<PermisoUsuarioEN> TransformarAListaPermisoUsuario(List<PermisoPerfilEN> pLisPerPer)
        {
            //lista resultado
            List<PermisoUsuarioEN> iLisRes = new List<PermisoUsuarioEN>();

            //recorrer cada objeto
            foreach (PermisoPerfilEN xPerPer in pLisPerPer)
            {
                //transformar a permisousuario y adicionar a lista resultado
                iLisRes.Add(PermisoUsuarioRN.TransformarAPermisoUsuario(xPerPer));                
            }
        
            //devolver
            return iLisRes;
        }

        public static Hashtable ListarPermisosParaMenuPrincipal()
        {
            //objeto resultado
            Hashtable iLisRes = new Hashtable();

            //traemos los permisos de la ventana en PermisoUsuario
            List<PermisoUsuarioEN> iLisPerUsu = PermisoUsuarioRN.ListarPermisosUsuarioParaMenuPrincipal();

            //recorrer cada objeto
            foreach (PermisoUsuarioEN xPerUsu in iLisPerUsu)
            {
                //pasamos datos                 
                string iClave = xPerUsu.NombreControlVentana;
                string iValor = xPerUsu.CPermitir;
                
                //si la clave no existe, entonces lo agrega
                if (iLisRes[iClave] == null)
                {
                    //agregamos al hashtable
                    iLisRes.Add(iClave, iValor);    
                }
                else
                {
                    //solo si iValor=1 , entonces se reemplaza
                    if (iValor == "1")
                    {
                        iLisRes[iClave] = iValor;
                    }
                }
            }
        
            //devolver
            return iLisRes;
        }

        public static void CopiarPermisos(string pCodigoUsuarioRecibe, string pCodigoUsuarioDa)
        {
            //traer al usuario da
            UsuarioEN iUsuDaEN = UsuarioRN.BuscarUsuarioXCodigo(pCodigoUsuarioDa);

            //traer la lista de permisosUsuario para copiar del ususario da
            List<PermisoUsuarioEN> iLisPerUsu = PermisoUsuarioRN.ListarPermisosUsuarioParaCopiar(iUsuDaEN);

            //cambiamos de usuario a todos los permisos
            PermisoUsuarioRN.CambiarDeUsuario(iLisPerUsu, pCodigoUsuarioRecibe);

            //adicionar a bd
            PermisoUsuarioRN.ModificarPermisoUsuarioMasivo(iLisPerUsu);
        }

        public static List<PermisoUsuarioEN> ListarPermisosUsuarioParaCopiar(UsuarioEN pObj)
        {
            //lista resultado
            List<PermisoUsuarioEN> iLisRes = new List<PermisoUsuarioEN>();

            //si el usuario es de perfil personalizado(02),entonces buscamos los permisos
            //en PermisoUsuario
            if (pObj.CodigoPerfil == "02")
            {
                PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
                iPerUsuEN.CodigoUsuario = pObj.CodigoUsuario;
                iPerUsuEN.Adicionales.CampoOrden = PermisoUsuarioEN.CodVen;
                return PermisoUsuarioRN.ListarPermisosUsuarioDeUsuario(iPerUsuEN);
            }

            //si el usuario tiene otro perfil diferente a los 2 primeros,entonces buscamos
            //los permisos en PermisoPerfil          
            PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
            iPerPerEN.CodigoPerfil = pObj.CodigoPerfil;
            iPerPerEN.Adicionales.CampoOrden = PermisoPerfilEN.CodVen;
            List<PermisoPerfilEN> iLisPer = PermisoPerfilRN.ListarPermisosPerfilDePerfil(iPerPerEN);

            //transformar la lista de permisoPerfil a lista PermisUsuario y a la vez retornar esta lista
            return PermisoUsuarioRN.TransformarAListaPermisoUsuario(iLisPer);
        }

        public static void CambiarDeUsuario(List<PermisoUsuarioEN> pLista, string pCodigoUsuario)
        {
            //recorrer cada objeto
            foreach (PermisoUsuarioEN xPerUsu in pLista)
            {
                xPerUsu.CodigoUsuario = pCodigoUsuario;
                xPerUsu.ClavePermisoUsuario = PermisoUsuarioRN.ObtenerClavePermisoUsuario(xPerUsu);
            }
        }


    }
}
