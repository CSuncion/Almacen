using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;
using Entidades.Adicionales;


namespace Negocio
{
    public class UsuarioRN
    {


        public static UsuarioEN EsAccesibleSistema(UsuarioEN pObj)
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            UsuarioAD iUsuAD = new UsuarioAD();
            iUsuEN = iUsuAD.EsAccesibleSistema(pObj);
            //si el objeto xUsuEN trae falso hubo error de conexion o de base de datos
            //el objeto pasa sin ningun cambio
            if (iUsuEN.Adicionales.EsVerdad == true)
            {
                if (iUsuEN.CodigoUsuario == string.Empty)
                {
                    //el usuario no se encontro (esta eliminado)
                    iUsuEN.Adicionales.EsVerdad = false;
                    iUsuEN.Adicionales.Mensaje = "Tu usuario ha sido eliminado del sistema, no puedes realizar ninguna operacion";
                }
                else
                {
                    if (iUsuEN.CEstadoUsuario == "0") //desactivado
                    {
                        iUsuEN.Adicionales.EsVerdad = false;
                        iUsuEN.Adicionales.Mensaje = "Tu usuario ha sido desactivado del sistema, no puedes realizar ninguna operacion";
                    }
                    else
                    {
                        //aqui el usuario no tiene acceso al sistema  preguntar si
                        //fue sacado por motivo de reparacion o trabajos especiales en base de datos
                        if (iUsuEN.CAccesaUsuario == "0")//fue sacado
                        {
                            iUsuEN.Adicionales.EsVerdad = false;
                            iUsuEN.Adicionales.Mensaje = "Tu usuario fue sacado del sistema, no puedes realizar ninguna operacion";
                        }
                        else
                        {
                            iUsuEN.Adicionales.EsVerdad = true;
                            iUsuEN.Adicionales.Mensaje = string.Empty;
                        }
                    }
                }
            }
            return iUsuEN;
        }

        public static UsuarioEN EnBlanco()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            return iUsuEN;
        }

        public static void AdicionarUsuario(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            iUsuAD.AgregarUsuario(pObj);
        }

        public static void ModificarUsuario(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            iUsuAD.ModificarUsuario(pObj);
        }

        public static void EliminarUsuario(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            iUsuAD.EliminarUsuario(pObj);
        }

        public static UsuarioEN BuscarUsuarioXCodigo(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            return iUsuAD.BuscarUsuarioXCodigo(pObj);
        }

        public static List<UsuarioEN> ListarUsuarios(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            return iUsuAD.ListarUsuarios(pObj);
        }

        public static List<UsuarioEN> ListarUsuariosYNoAdministradores(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            return iUsuAD.ListarUsuariosYNoAdministradores(pObj);
        }

        public static List<UsuarioEN> ListarUsuariosActivos(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            pObj.CEstadoUsuario = "1"; //activo
            return iUsuAD.ListarUsuariosXEstado(pObj);
        }

        public static List<UsuarioEN> ListarUsuariosActivosYNoAdministradores(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            pObj.CEstadoUsuario = "1"; //activo
            return iUsuAD.ListarUsuariosXEstadoYNoAdministradores(pObj);
        }

        public static List<UsuarioEN> ListarUsuariosAdministradoresActivos(UsuarioEN pObj)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            pObj.CEstadoUsuario = "1"; //activo
            pObj.CodigoPerfil = "01"; //administrador
            return iUsuAD.ListarUsuariosXPerfilXEstado(pObj);
        }

        public static UsuarioEN EsUsuarioValido(UsuarioEN pObj)
        {
            UsuarioEN iUsuEN = new UsuarioEN();

            //si no hay codigousuario entonces es true
            if (pObj.CodigoUsuario == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = true;
                iUsuEN.Adicionales.Mensaje = "";
                return iUsuEN;
            }

            //aqui CodigoUsuario no esta vacio
            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.CodigoUsuario == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "No existe usuario con este codigo : " + Cadena.Espacios(1) + pObj.CodigoUsuario;
                return iUsuEN;
            }
            else
            {
                if (iUsuEN.CEstadoUsuario == "0") //desactivado
                {
                    iUsuEN = UsuarioRN.EnBlanco();
                    iUsuEN.Adicionales.EsVerdad = false;
                    iUsuEN.Adicionales.Mensaje = "El usuario" + Cadena.Espacios(1) + pObj.CodigoUsuario + Cadena.Espacios(1) + "esta desactivado";
                    return iUsuEN;
                }
            }
            iUsuEN.Adicionales.EsVerdad = true;
            return iUsuEN;
        }

        public static UsuarioEN EsContrasenaDeUsuario(UsuarioEN pObj)
        {
            UsuarioEN iUsuEN = new UsuarioEN();

            //si no se digito contraseña entonces es true
            if (pObj.ClaveUsuario == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = true;
                iUsuEN.Adicionales.Mensaje = string.Empty;
                return iUsuEN;
            }

            //si CodigoUsuario no esta vacio y clave tampoco
            string xClave = pObj.ClaveUsuario;
            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.ClaveUsuario == xClave)
            {
                iUsuEN.Adicionales.EsVerdad = true;
                iUsuEN.Adicionales.Mensaje = string.Empty;
                return iUsuEN;
            }
            else
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "La clave es Incorrecta";
                return iUsuEN;
            }

        }

        public static UsuarioEN EsCodigoUsuarioDisponible(UsuarioEN pObj, bool pVacio)
        {
            UsuarioEN iUsuEN = new UsuarioEN();

            if (pVacio == true)
            {
                if (pObj.CodigoUsuario == string.Empty)
                {
                    iUsuEN.Adicionales.EsVerdad = false;
                    iUsuEN.Adicionales.Mensaje = "Debes ingresar un codigo Usuario";
                    return iUsuEN;
                }

            }
            else
            {
                if (pObj.CodigoUsuario == string.Empty)
                {
                    iUsuEN.Adicionales.EsVerdad = true;
                    iUsuEN.Adicionales.Mensaje = "";
                    return iUsuEN;
                }

            }

            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.CodigoUsuario == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = true;
            }
            else
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoUsuario + " ya le pertenece a un usuario";
            }
            return iUsuEN;
        }

        public static UsuarioEN EsUsuarioExistente(UsuarioEN pObj)
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.CodigoUsuario == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "El usuario " + pObj.CodigoUsuario + " no existe";
            }
            else
            {
                iUsuEN.Adicionales.EsVerdad = true;

            }
            return iUsuEN;
        }

        public static UsuarioEN EsModificableTipoUsuario(UsuarioEN pObj)
        {
            List<UsuarioEN> iLisUsu = new List<UsuarioEN>();
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(pObj);
            //preguntamos si el usuario es administrador
            //y si esta activo
            if (iUsuEN.CodigoPerfil == "01" && iUsuEN.CEstadoUsuario == "1")
            {
                //si el usuario no cambio el tipo de usuario en la ventana entonces quiere decir que sigue 
                //siendo administrador entonces puede modificar el registro
                if (pObj.CodigoPerfil == "01")
                {
                    iUsuEN.Adicionales.EsVerdad = true;
                }
                else
                {
                    //aqui el usuario es un administrador activo y ademas el usuario
                    //cambio el tipo de usuario osea ya no es administrador
                    //por lo tanto traer la lista de administradores activos del sistema
                    pObj.Adicionales.CampoOrden = UsuarioEN.CodUsu;
                    iLisUsu = UsuarioRN.ListarUsuariosAdministradoresActivos(pObj);
                    //si la lista trae un solo usuario quiere decir que es el unico administrador
                    //por lo tanto no puedes modificar el registro
                    if (iLisUsu.Count == 1)
                    {
                        iUsuEN.Adicionales.EsVerdad = false;
                        iUsuEN.Adicionales.Mensaje = "No puedes modificar el perfil a este usuario por que es el unico administrador activo del sistema";
                    }
                    else
                    {
                        //aqui la lista tiene mas de un administrador activo por lo tanto
                        //si puedes modificar el registro
                        iUsuEN.Adicionales.EsVerdad = true;
                    }
                }
            }
            else
            {
                //aqui el usuario o no es administrador o no esta activo
                //por lo tanto puedes modificar el registro
                iUsuEN.Adicionales.EsVerdad = true;
            }
            //retornamos el objeto
            return iUsuEN;
        }

        public static UsuarioEN EsModificableEstadoUsuario(UsuarioEN pObj)
        {
            List<UsuarioEN> iLisUsu = new List<UsuarioEN>();
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(pObj);

            //validar que no se desactive al usuario de acceso
            if (iUsuEN.CodigoUsuario == Universal.gCodigoUsuario)
            {
                if (pObj.CEstadoUsuario == "0")//desactivado
                {
                    iUsuEN.Adicionales.EsVerdad = false;
                    iUsuEN.Adicionales.Mensaje = "No se pude desactivar al usuario de acceso";
                    return iUsuEN;
                }
            }

            //preguntamos si el usuario es administrador
            //y si esta activo
            if (iUsuEN.CodigoPerfil == "01" && iUsuEN.CEstadoUsuario == "1")
            {
                //si el usuario no cambio el estado de usuario en la ventana entonces quiere decir que sigue 
                //siendo activo entonces puede modificar el registro
                if (pObj.CEstadoUsuario == "1")
                {
                    iUsuEN.Adicionales.EsVerdad = true;
                }
                else
                {
                    //aqui el usuario es un administrador activo y ademas el usuario
                    //cambio el estado de usuario osea ya no esta activo
                    //por lo tanto traer la lista de administradores activos del sistema
                    pObj.Adicionales.CampoOrden = UsuarioEN.CodUsu;
                    iLisUsu = UsuarioRN.ListarUsuariosAdministradoresActivos(pObj);
                    //si la lista trae un solo usuario quiere decir que es el unico administrador activo
                    //por lo tanto no puedes modificar el registro
                    if (iLisUsu.Count == 1)
                    {
                        iUsuEN.Adicionales.EsVerdad = false;
                        iUsuEN.Adicionales.Mensaje = "No puedes modificar el estado a este usuario por que es el unico administrador activo del sistema";
                    }
                    else
                    {
                        //aqui la lista tiene mas de un administrador activo por lo tanto
                        //si puedes modificar el registro
                        iUsuEN.Adicionales.EsVerdad = true;
                    }

                }

            }
            else
            {
                //aqui el usuario o no es administrador o no esta activo
                //por lo tanto puedes modificar el registro
                iUsuEN.Adicionales.EsVerdad = true;
            }
            //retornamos el objeto
            return iUsuEN;
        }

        public static UsuarioEN EsEliminableUsuario(UsuarioEN pObj)
        {
            //objeto resultado
            UsuarioEN iUsuEN = new UsuarioEN();

            //validar si el usuario existe
            iUsuEN = UsuarioRN.EsUsuarioExistente(pObj);
            if (iUsuEN.Adicionales.EsVerdad == false) { return iUsuEN; }

            //validar que no sea el usuario actual
            if (iUsuEN.CodigoUsuario == Universal.gCodigoUsuario)
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "No se puede eliminar al usuario de acceso";
                return iUsuEN;
            }

            //preguntamos si el usuario es administrador
            //y si esta activo
            if (iUsuEN.CodigoPerfil == "01" && iUsuEN.CEstadoUsuario == "1")
            {
                //aqui el usuario es un administrador activo 
                //por lo tanto traer la lista de administradores activos del sistema
                List<UsuarioEN> iLisUsu = new List<UsuarioEN>();
                pObj.Adicionales.CampoOrden = UsuarioEN.CodUsu;
                iLisUsu = UsuarioRN.ListarUsuariosAdministradoresActivos(pObj);
                //si la lista trae un solo usuario quiere decir que es el unico administrador
                //por lo tanto no puedes eliminar el registro
                if (iLisUsu.Count == 1)
                {
                    iUsuEN.Adicionales.EsVerdad = false;
                    iUsuEN.Adicionales.Mensaje = "No puedes eliminar a este usuario por que es el unico administrador activo del sistema";
                }
                else
                {
                    //aqui la lista tiene mas de un administrador activo por lo tanto
                    //si puedes eliminar el registro
                    iUsuEN.Adicionales.EsVerdad = true;
                }
            }
            else
            {
                //aqui el usuario o no es administrador o no esta activo
                //por lo tanto puedes eliminar el registro
                iUsuEN.Adicionales.EsVerdad = true;
            }
            //retornamos el objeto
            return iUsuEN;
        }

        public static void ModificarAccesibilidadUsuarios(string pPoneSaca)
        {
            //obtener el valor de CAccesaUsuario segun lo que biene de pPoneSaca
            string iAccesaUsuario = string.Empty;
            if (pPoneSaca == "Poner")
            {
                iAccesaUsuario = "1";
            }
            else
            {
                iAccesaUsuario = "0";
            }

            //traer lista de usuarios del sistema
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.Adicionales.CampoOrden = UsuarioEN.CodUsu;
            List<UsuarioEN> iLisUsu = UsuarioRN.ListarUsuarios(iUsuEN);

            //recorrer cada objeto usuario para modificar su accesibilidad
            foreach (UsuarioEN xObj in iLisUsu)
            {
                //si el objeto es administrador se le pone accesible=1
                //0:administrador
                if (xObj.CodigoPerfil == "01")
                {
                    //tiene acceso
                    xObj.CAccesaUsuario = "1";
                }
                else
                {
                    //segun lo que chequeo en la ventana
                    xObj.CAccesaUsuario = iAccesaUsuario;
                }
                //modificar
                UsuarioRN.ModificarUsuario(xObj);
            }

        }

        public static bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            return iUsuAD.ExisteValorEnColumna(pColumna, pValor);
        }

        public static UsuarioEN EsActoModificarPermisosEmpresa(UsuarioEN pObj)
        {
            //objeto resultado
            UsuarioEN iUsuEN = new UsuarioEN();

            //validar si el usuario existe
            iUsuEN = UsuarioRN.EsUsuarioExistente(pObj);
            if (iUsuEN.Adicionales.EsVerdad == false) { return iUsuEN; }

            //no es para administrador
            if (iUsuEN.CodigoPerfil == "01")//administrador
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "Esta accion no es para perfil administrador";
                return iUsuEN;
            }

            //retornamos el objeto
            iUsuEN.Adicionales.EsVerdad = true;
            return iUsuEN;
        }

        public static UsuarioEN EsActoModificarPermisosUsuario(UsuarioEN pObj)
        {
            //objeto resultado
            UsuarioEN iUsuEN = new UsuarioEN();

            //validar para administrador
            iUsuEN = UsuarioRN.EsUsuarioExistente(pObj);
            if (iUsuEN.Adicionales.EsVerdad == false) { return iUsuEN; }

            //no es para administrador
            if (iUsuEN.CodigoPerfil != "02")//personalizado
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "Esta accion es solo para perfil Personalizado";
                return iUsuEN;
            }

            //retornamos el objeto
            iUsuEN.Adicionales.EsVerdad = true;
            return iUsuEN;
        }

        public static string ObtenerValorDeCampo(UsuarioEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case UsuarioEN.ClaObj: return pObj.ClaveObjeto;
                case UsuarioEN.CodUsu: return pObj.CodigoUsuario;
                case UsuarioEN.NomUsu: return pObj.NombreUsuario;
                case UsuarioEN.ClaUsu: return pObj.ClaveUsuario;
                case UsuarioEN.DirUsu: return pObj.DireccionUsuario;
                case UsuarioEN.FotUsu: return pObj.FotoUsuario;
                case UsuarioEN.CorUsu: return pObj.CorreoUsuario;
                case UsuarioEN.CodPer: return pObj.CodigoPerfil;
                case UsuarioEN.NomPer: return pObj.NombrePerfil;
                case UsuarioEN.CEstUsu: return pObj.CEstadoUsuario;
                case UsuarioEN.NEstUsu: return pObj.NEstadoUsuario;
                case UsuarioEN.CAccUsu: return pObj.CAccesaUsuario;
                case UsuarioEN.NAccUsu: return pObj.NAccesaUsuario;
                case UsuarioEN.TelFijUsu: return pObj.TelFijoUsuario;
                case UsuarioEN.TelCelUsu: return pObj.TelCelularUsuario;
                case UsuarioEN.CodPrs: return pObj.CodigoPersonal;
                case UsuarioEN.UsuAgr: return pObj.UsuarioAgrega;
                case UsuarioEN.FecAgr: return pObj.FechaAgrega.ToString();
                case UsuarioEN.UsuMod: return pObj.UsuarioModifica;
                case UsuarioEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<UsuarioEN> FiltrarUsuariosXTextoEnCualquierPosicion(List<UsuarioEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<UsuarioEN> iLisRes = new List<UsuarioEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (UsuarioEN xCli in pLista)
            {
                string iTexto = UsuarioRN.ObtenerValorDeCampo(xCli, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xCli);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<UsuarioEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<UsuarioEN> pListaUsuarios)
        {
            //lista resultado
            List<UsuarioEN> iLisRes = new List<UsuarioEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaUsuarios; }

            //filtar la lista
            iLisRes = UsuarioRN.FiltrarUsuariosXTextoEnCualquierPosicion(pListaUsuarios, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public void GenerarCopiaSeguridad(string pNombreBD, string pRutaArchivo)
        {
            UsuarioAD iUsuAD = new UsuarioAD();
            iUsuAD.GenerarCopiaSeguridad(pNombreBD, pRutaArchivo);
        }
        
        public static List<UsuarioEN> ListarUsuarios()
        {
            //asignar parametros
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.Adicionales.CampoOrden = UsuarioEN.CodUsu;

            //ejecutar metodo
            return UsuarioRN.ListarUsuarios(iUsuEN);
        }

        public static UsuarioEN EsActoModificarPermisosAlmacen(UsuarioEN pObj)
        {
            //objeto resultado
            UsuarioEN iUsuEN = new UsuarioEN();

            //validar si el usuario existe
            iUsuEN = UsuarioRN.EsUsuarioExistente(pObj);
            if (iUsuEN.Adicionales.EsVerdad == false) { return iUsuEN; }

            //no es para administrador
            if (iUsuEN.CodigoPerfil == "01")//administrador
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "Esta accion no es para perfil administrador";
                return iUsuEN;
            }

            //retornamos el objeto
            iUsuEN.Adicionales.EsVerdad = true;
            return iUsuEN;
        }

        public static UsuarioEN BuscarUsuarioXCodigo(string pCodigoUsuario)
        {
            //asignar parametros
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.CodigoUsuario = pCodigoUsuario;

            //ejecutar metodo
            return UsuarioRN.BuscarUsuarioXCodigo(iUsuEN);
        }

        public static List<UsuarioEN> ListarUsuariosActivosExceptoUno(UsuarioEN pObj)
        {
            //lista resultado
            List<UsuarioEN> iLisRes = new List<UsuarioEN>();

            //traer a todos los usuarios activos
            List<UsuarioEN> iLisUsuAct = UsuarioRN.ListarUsuariosActivos(pObj);

            //obtener una nueva lista pero sin el usuario de parametro
            iLisRes = ListaG.FiltrarExcepto<UsuarioEN>(iLisUsuAct, UsuarioEN.CodUsu, pObj.CodigoUsuario);

            //devolver
            return iLisRes;
        }

        public static UsuarioEN EsUsuarioValido(UsuarioEN pObj, string pCodigoUsuarioExcepcion)
        {
            UsuarioEN iUsuEN = new UsuarioEN();

            //si no hay codigousuario entonces es true
            if (pObj.CodigoUsuario == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = true;
                iUsuEN.Adicionales.Mensaje = "";
                return iUsuEN;
            }

            //aqui CodigoUsuario no esta vacio
            iUsuEN = UsuarioRN.BuscarUsuarioXCodigo(pObj);
            if (iUsuEN.CodigoUsuario == string.Empty)
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "No existe usuario con este codigo : " + Cadena.Espacios(1) + pObj.CodigoUsuario;
                return iUsuEN;
            }
            else
            {
                if (iUsuEN.CEstadoUsuario == "0") //desactivado
                {
                    iUsuEN = UsuarioRN.EnBlanco();
                    iUsuEN.Adicionales.EsVerdad = false;
                    iUsuEN.Adicionales.Mensaje = "El usuario" + Cadena.Espacios(1) + pObj.CodigoUsuario + Cadena.Espacios(1) + "esta desactivado";
                    return iUsuEN;
                }

                //valida cuando sea el codigo usuario de excepcion
                UsuarioEN iUsuExcEN = UsuarioRN.ValidaCuandoCodigoUsuarioEsIgualACodigoExcepcion(iUsuEN, pCodigoUsuarioExcepcion);
                if (iUsuExcEN.Adicionales.EsVerdad == false) { return iUsuExcEN; }

            }

            //devolver
            iUsuEN.Adicionales.EsVerdad = true;
            return iUsuEN;
        }

        public static UsuarioEN ValidaCuandoCodigoUsuarioEsIgualACodigoExcepcion(UsuarioEN pObj, string pCodigoUsuarioExcepcion)
        {
            //objeto resultado
            UsuarioEN iUsuEN = new UsuarioEN();

            //valida            
            if (pCodigoUsuarioExcepcion != string.Empty && pObj.CodigoUsuario == pCodigoUsuarioExcepcion)
            {
                iUsuEN.Adicionales.EsVerdad = false;
                iUsuEN.Adicionales.Mensaje = "Debes elegir otro usuario, no se puede realizar la operacion";               
            }

            //ok
            return iUsuEN;
        }

    }
}

