using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;

namespace Negocio
{
    public class PermisoEmpresaRN
    {

        public static PermisoEmpresaEN EnBlanco()
        {
            PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
            return iPemEN;
        }
        
        public static void AdicionarPermisoEmpresa(PermisoEmpresaEN pObj)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            iPemAD.AdicionarPermisoEmpresa(pObj);
        }

        public static void AdicionarPermisoEmpresaMasivo(List<PermisoEmpresaEN> pLista)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            iPemAD.AdicionarPermisoEmpresaMasivo(pLista);
        }
        
        public static void ModificarPermisoEmpresa(PermisoEmpresaEN pObj)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            iPemAD.ModificarPermisoEmpresa(pObj);
        }

        public static void ModificarPermisoEmpresa(PermisoEmpresaEN pObj, List<PermisoEmpresaEN> pLista)
        {
            //lista actualizada
            List<PermisoEmpresaEN> iLisPem = new List<PermisoEmpresaEN>();

            //buscamos el objeto en la lista pLista
            foreach (PermisoEmpresaEN xPem in pLista)
            {
                if (xPem.ClavePermisoEmpresa == pObj.ClavePermisoEmpresa)
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

        public static void ModificarPermisoEmpresaMasivo(List<PermisoEmpresaEN> pLista)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            iPemAD.ModificarPermisoEmpresaMasivo(pLista);
        }

        public static void EliminarPermisosEmpresaXUsuario(PermisoEmpresaEN pObj)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            iPemAD.EliminarPermisosEmpresaXUsuario(pObj);
        }

        public static void EliminarPermisosEmpresaXEmpresa(PermisoEmpresaEN pObj)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            iPemAD.EliminarPermisosEmpresaXEmpresa(pObj);
        }

        public static PermisoEmpresaEN BuscarPermisoEmpresaXClave(PermisoEmpresaEN pObj)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            return iPemAD.BuscarPermisoEmpresaXClave(pObj);
        }
        
        public static List<PermisoEmpresaEN> ListarPermisosEmpresaAbiertasXUsuario(PermisoEmpresaEN pObj)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            return iPemAD.ListarPermisosEmpresaAbiertasXUsuario(pObj);
        }

        public static List<PermisoEmpresaEN> ListarPermisosEmpresaActivasXUsuarioYAutorizadas(PermisoEmpresaEN pObj)
        {
            PermisoEmpresaAD iPemAD = new PermisoEmpresaAD();
            return iPemAD.ListarPermisosEmpresaActivasXUsuarioYAutorizadas(pObj);
        }

        public static void AdicionarPermisosEmpresaXUsuario(PermisoEmpresaEN pObj)
        {
            //Traer todas las empresas del sistema
            EmpresaEN iEmpEN = new EmpresaEN();
            List<EmpresaEN> iLisEmp = new List<EmpresaEN>();
            iEmpEN.Adicionales.CampoOrden = EmpresaEN.CodEmp;
            iLisEmp = EmpresaRN.ListarEmpresas(iEmpEN);

            //armar la lista de los nuevos permisos para este usuario
            List<PermisoEmpresaEN> iLisPerEmp = new List<PermisoEmpresaEN>();
            foreach (EmpresaEN xObj in iLisEmp)
            {
                PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
                iPemEN.CodigoUsuario = pObj.CodigoUsuario;   //el nuevo usuario del sistema
                iPemEN.CodigoEmpresa = xObj.CodigoEmpresa;
                iPemEN.ClavePermisoEmpresa = PermisoEmpresaRN.ObtenerClavePermisoEmpresa(iPemEN);
                if (pObj.CodigoPerfil == "01")
                {
                    iPemEN.CPermitir = "1"; //si
                }
                else
                {
                    iPemEN.CPermitir = "0"; //no
                }
                iLisPerEmp.Add(iPemEN);
            }
            //grabamos la lista
            PermisoEmpresaRN.AdicionarPermisoEmpresaMasivo(iLisPerEmp);
        }

        public static void AdicionarPermisosEmpresaXEmpresa(PermisoEmpresaEN pObj)
        {
            //Traer todos los usuarios del sistema          
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.Adicionales.CampoOrden = UsuarioEN.CodUsu;
            List<UsuarioEN> iLisUsu = UsuarioRN.ListarUsuarios(iUsuEN);

            //lista de los nuevos permisos para este usuario
            List<PermisoEmpresaEN> iLisPerEmp = new List<PermisoEmpresaEN>();
            
            //recorrer cada usuario
            foreach (UsuarioEN xObj in iLisUsu)
            {
                PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
                iPemEN.CodigoUsuario = xObj.CodigoUsuario;
                iPemEN.CodigoEmpresa = pObj.CodigoEmpresa;//la nueva empresa del sistema
                iPemEN.ClavePermisoEmpresa = PermisoEmpresaRN.ObtenerClavePermisoEmpresa(iPemEN);
                iPemEN.CPermitir = "0"; //no permitir                
                iLisPerEmp.Add(iPemEN);
            }

            //grabamos la lista
            PermisoEmpresaRN.AdicionarPermisoEmpresaMasivo(iLisPerEmp);
        }

        public static string ObtenerClavePermisoEmpresa(PermisoEmpresaEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoEmpresa + "-";
            iClave += pObj.CodigoUsuario;
            return iClave;
        }

        public static PermisoEmpresaEN EsEmpresaDeUsuario(PermisoEmpresaEN pObj)
        {
            PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();

            //si no se digito la empresa entonces es true
            if (pObj.CodigoEmpresa == string.Empty)
            {
                iPemEN.Adicionales.EsVerdad = true;
                iPemEN.Adicionales.Mensaje = string.Empty;
                return iPemEN;
            }

            //verificar que se aya escrito el usuario
            if (pObj.CodigoUsuario == string.Empty)
            {
                iPemEN.Adicionales.EsVerdad = false;
                iPemEN.Adicionales.Mensaje = "Primero debes elegir al usuario";
                return iPemEN;
            }

            //si CodigoEmpresa no esta vacio y hay usuario
            iPemEN = PermisoEmpresaRN.BuscarPermisoEmpresaXClave(pObj);
            if (iPemEN.CodigoEmpresa == string.Empty)
            {
                iPemEN.Adicionales.EsVerdad = false;
                iPemEN.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.CodigoEmpresa + Cadena.Espacios(1) + "no existe";
                return iPemEN;
            }
            else
            {
                //verificar que la empresa este desactivada
                if (iPemEN.CEstadoEmpresa == "0") //desactivada
                {
                    iPemEN = PermisoEmpresaRN.EnBlanco();
                    iPemEN.Adicionales.EsVerdad = false;
                    iPemEN.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.CodigoEmpresa + Cadena.Espacios(1) + "esta desactivada";
                    return iPemEN;
                }
                if (iPemEN.CodigoPerfil != "01")
                {
                    if (iPemEN.CPermitir == "0") //no tiene permiso
                    {
                        iPemEN = PermisoEmpresaRN.EnBlanco();
                        iPemEN.Adicionales.EsVerdad = false;
                        iPemEN.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.CodigoEmpresa + Cadena.Espacios(1) + "no esta autorizada para este usuario";
                        return iPemEN;
                    }
                }
            }
            //si llega hasta aqui entonces si tiene permiso
            iPemEN.Adicionales.EsVerdad = true;
            return iPemEN;

        }



    }
}
