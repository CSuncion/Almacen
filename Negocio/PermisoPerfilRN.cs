using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;

namespace Negocio
{
    public class PermisoPerfilRN
    {
        public static PermisoPerfilEN EnBlanco()
        {
            PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
            return iPerPerEN;
        }

        public static void AdicionarPermisoPerfil(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerUsuAD = new PermisoPerfilAD();
            iPerUsuAD.AgregarPermisoPerfil(pObj);
        }

        public static void AdicionarPermisoPerfilMasivo(List<PermisoPerfilEN> pLista)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            iPerPerAD.AgregarPermisoPerfilMasivo(pLista);
        }

        public static void ModificarPermisoPerfil(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            iPerPerAD.ModificarPermisoPerfil(pObj);
        }

        public static void ModificarPermisoPerfilMasivo(List<PermisoPerfilEN> pLista)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            iPerPerAD.ModificarPermisoPerfilMasivo(pLista);
        }

        public static void EliminarPermisoPerfil(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            iPerPerAD.EliminarPermisoPerfil(pObj);
        }

        public static void EliminarPermisosPerfilXVentanaBoton(List<VentanaBotonEN> pLista)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            iPerPerAD.EliminarPermisosPerfilXVentanaBoton(pLista);
        }

        public static PermisoPerfilEN BuscarPermisoPerfilXClave(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            return iPerPerAD.BuscarPermisoPerfilXClave(pObj);
        }

        public static List<PermisoPerfilEN> ListarPermisoPerfil(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            return iPerPerAD.ListarPermisoPerfil(pObj);
        }

        public static void AdicionarPermisosPerfilXVentanaBoton(List<VentanaBotonEN> pLista)
        {
            //Traer todos los Perfiles del sistema         
            PerfilEN iPerEN = new PerfilEN();
            iPerEN.Adicionales.CampoOrden = PerfilEN.CodPer;
            List<PerfilEN> iLisPer = PerfilRN.ListarPerfiles(iPerEN);

            //armar la lista de los nuevos permisos para estos perfiles
            List<PermisoPerfilEN> iLisPerPer = new List<PermisoPerfilEN>();
            foreach (PerfilEN xPer in iLisPer)
            {
                foreach (VentanaBotonEN xVenBot in pLista)
                {
                    PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
                    iPerPerEN.CodigoVentana = xVenBot.CodigoVentana;
                    iPerPerEN.CodigoBoton = xVenBot.CodigoBoton;
                    iPerPerEN.CodigoPerfil = xPer.CodigoPerfil;
                    iPerPerEN.ClavePermisoPerfil = PermisoPerfilRN.ObtenerClavePermisoPerfil(iPerPerEN);
                    if (iPerPerEN.CodigoPerfil == "01")//administrador
                    {
                        iPerPerEN.CPermitir = "1"; //si permitir
                    }
                    else
                    {
                        iPerPerEN.CPermitir = "0"; //no permitir
                    }
                    iLisPerPer.Add(iPerPerEN);
                }
            }
            //grabamos la lista
            PermisoPerfilRN.AdicionarPermisoPerfilMasivo(iLisPerPer);
        }

        public static string ObtenerClavePermisoPerfil(PermisoPerfilEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoVentana + "-";
            iClave += pObj.CodigoBoton + "-";
            iClave += pObj.CodigoPerfil;
            return iClave;
        }

        public static void AdicionarPermisosPerfilParaNuevoPerfil(PermisoPerfilEN pObj)
        {
            //lista para guardar los PermisosPerfil
            List<PermisoPerfilEN> iLisPerPer = new List<PermisoPerfilEN>();

            //traer la lista de todas las VentanasBoton         
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();
            iVenBotEN.Adicionales.CampoOrden = VentanaBotonEN.ClaVenBot;
            List<VentanaBotonEN> iLisVenBot = VentanaBotonRN.ListarVentanaBotones(iVenBotEN);

            //recorre cada objeto de la lista
            foreach (VentanaBotonEN xVenBot in iLisVenBot)
            {
                //creando un PermisoPerfil
                PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
                iPerPerEN.CodigoSubMenu = xVenBot.CodigoSubMenu;
                iPerPerEN.CodigoVentana = xVenBot.CodigoVentana;
                iPerPerEN.CodigoBoton = xVenBot.CodigoBoton;
                iPerPerEN.CodigoPerfil = pObj.CodigoPerfil;
                iPerPerEN.CPermitir = "0";//no permitir
                iPerPerEN.ClavePermisoPerfil = PermisoPerfilRN.ObtenerClavePermisoPerfil(iPerPerEN);

                //insertamos a la lista
                iLisPerPer.Add(iPerPerEN);
            }

            //ahora adicionamos todos estos PermisosPerfiles a la B.D
            PermisoPerfilRN.AdicionarPermisoPerfilMasivo(iLisPerPer);
        }

        public static void EliminarPermisosPerfilDePerfil(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            iPerPerAD.EliminarPermisosPerfilDePerfil(pObj);
        }

        public static void EliminarPermisosPerfilXVentana(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            iPerPerAD.EliminarPermisosPerfilXVentana(pObj);
        }

        public static List<PermisoPerfilEN> ListarPermisosPerfilDeVentana(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            return iPerPerAD.ListarPermisosPerfilDeVentana(pObj);
        }

        public static void ModificarPermisoPerfil(PermisoPerfilEN pObj, List<PermisoPerfilEN> pLista)
        {
            //lista actualizada
            List<PermisoPerfilEN> iLisPerPer = new List<PermisoPerfilEN>();

            //buscamos el objeto en la lista pLista
            foreach (PermisoPerfilEN xPerPer in pLista)
            {
                if (xPerPer.ClavePermisoPerfil == pObj.ClavePermisoPerfil)
                {
                    xPerPer.VerdadFalso = pObj.VerdadFalso;
                    xPerPer.CPermitir = Conversion.BooleanACadena(pObj.VerdadFalso, "");
                }
                iLisPerPer.Add(xPerPer);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisPerPer);
        }

        public static void MarcarTodos(List<PermisoPerfilEN> pLista, bool pPermitir)
        {
            //lista actualizada
            List<PermisoPerfilEN> iLisPerPer = new List<PermisoPerfilEN>();

            //buscamos el objeto en la lista pLista
            foreach (PermisoPerfilEN xPerPer in pLista)
            {
                xPerPer.VerdadFalso = pPermitir;
                xPerPer.CPermitir = Conversion.BooleanACadena(xPerPer.VerdadFalso, "");
                iLisPerPer.Add(xPerPer);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisPerPer);
        }

        public static List<PermisoUsuarioEN> ListarPermisosVentanaDePerfil(PermisoPerfilEN pObj)
        {
            //lista resultado
            List<PermisoUsuarioEN> iLisRes = new List<PermisoUsuarioEN>();

            //traer todos los PermisoPerfil del modulo y del usuario
            List<PermisoPerfilEN> iLisPerPer = PermisoPerfilRN.ListarPermisosPerfilDePerfil(pObj);

            //variables para el calculo
            string iVentana = string.Empty;
            int iIndiceObjeto = -1;

            //recorremos cada objeto de iLisPerUsu
            foreach (PermisoPerfilEN xPerPer in iLisPerPer)
            {
                //si es una nueva ventana entonces creamos un nuevo objeto PermisoUsuario
                if (xPerPer.CodigoSubMenu + xPerPer.CodigoVentana != iVentana)
                {
                    //creamos el objeto para esta ventana
                    PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
                    iPerUsuEN.CodigoSubMenu = xPerPer.CodigoSubMenu;
                    iPerUsuEN.CodigoVentana = xPerPer.CodigoVentana;
                    iPerUsuEN.CPermitir = xPerPer.CPermitir;

                    //insertamos a la lista resultado
                    iLisRes.Add(iPerUsuEN);

                    //actualizamos variables calculo
                    iVentana = xPerPer.CodigoSubMenu + xPerPer.CodigoVentana;
                    iIndiceObjeto++;
                }
                else
                {
                    //aqui es la misma ventana entonces acumulamos la suma en CPermitir
                    iLisRes[iIndiceObjeto].CPermitir = (Convert.ToInt32(iLisRes[iIndiceObjeto].CPermitir) +
                                                        Convert.ToInt32(xPerPer.CPermitir)).ToString();
                }
            }
            return iLisRes;
        }

        public static List<PermisoPerfilEN> ListarPermisosPerfilDePerfil(PermisoPerfilEN pObj)
        {
            PermisoPerfilAD iPerPerAD = new PermisoPerfilAD();
            return iPerPerAD.ListarPermisosPerfilDePerfil(pObj);
        }


    }
}

