using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using Entidades.Contabilidad;

namespace Negocio
{
    public class AuxiliarRN
    {

        public static AuxiliarEN EnBlanco()
        {
            AuxiliarEN iAuxEN = new AuxiliarEN();
            return iAuxEN;
        }

        public static void AdicionarAuxiliar(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.AgregarAuxiliar(pObj);
        }

        public static void AdicionarAuxiliar(List<AuxiliarEN> pLista)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.AgregarAuxiliar(pLista);
        }

        public static void ModificarAuxiliar(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.ModificarAuxiliar(pObj);
        }

        public static void ModificarAuxiliar(List<AuxiliarEN> pLista)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.ModificarAuxiliar(pLista);
        }

        public static void EliminarAuxiliar(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            iPerAD.EliminarAuxiliar(pObj);
        }

        public static List<AuxiliarEN> ListarAuxiliares(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarAuxiliares(pObj);
        }

        public static AuxiliarEN BuscarAuxiliarXClave(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.BuscarAuxiliarXClave(pObj);
        }

        public static AuxiliarEN EsAuxiliarExistente(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar
            pObj.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(pObj);
            iAuxEN = AuxiliarRN.BuscarAuxiliarXClave(pObj);
            if (iAuxEN.CodigoAuxiliar == string.Empty)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El Auxiliar " + pObj.CodigoAuxiliar + " no existe";
                return iAuxEN;
            }

            //ok         
            return iAuxEN;
        }

        public static AuxiliarEN EsCodigoAuxiliarDisponible(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando existe el codigo
            iAuxEN = AuxiliarRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //ok          
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoCodigoYaExiste(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar     
            pObj.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(pObj);
            iAuxEN = AuxiliarRN.BuscarAuxiliarXClave(pObj);
            if (iAuxEN.CodigoAuxiliar != string.Empty)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoAuxiliar + " ya existe";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }
        
        public static string ObtenerValorDeCampo(AuxiliarEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case AuxiliarEN.ClaObj: return pObj.ClaveObjeto;
                case AuxiliarEN.ClaAux: return pObj.ClaveAuxiliar;
                case AuxiliarEN.CodEmp: return pObj.CodigoEmpresa;
                case AuxiliarEN.NomEmp: return pObj.NombreEmpresa;
                case AuxiliarEN.CodAux: return pObj.CodigoAuxiliar;
                case AuxiliarEN.ApePatAux: return pObj.ApellidoPaternoAuxiliar;
                case AuxiliarEN.ApeMatAux: return pObj.ApellidoMaternoAuxiliar;
                case AuxiliarEN.PriNomAux: return pObj.PrimerNombreAuxiliar;
                case AuxiliarEN.SegNomAux: return pObj.SegundoNombreAuxiliar;
                case AuxiliarEN.DesAux: return pObj.DescripcionAuxiliar;
                case AuxiliarEN.DirAux: return pObj.DireccionAuxiliar;
                case AuxiliarEN.TelAux: return pObj.TelefonoAuxiliar;
                case AuxiliarEN.CelAux: return pObj.CelularAuxiliar;
                case AuxiliarEN.CorAux: return pObj.CorreoAuxiliar;
                case AuxiliarEN.RefAux: return pObj.ReferenciaAuxiliar;
                case AuxiliarEN.CTipAux: return pObj.CTipoAuxiliar;
                case AuxiliarEN.NTipAux: return pObj.NTipoAuxiliar;
                case AuxiliarEN.TipDocAux: return pObj.TipoDocumentoAuxiliar;
                case AuxiliarEN.PaiNoDomAux: return pObj.PaisNoDomiciliadoAuxiliar;
                case AuxiliarEN.FecInsSnpAux: return pObj.FechaInscripcionSnpAuxiliar;
                case AuxiliarEN.CEstAux: return pObj.CEstadoAuxiliar;
                case AuxiliarEN.NEstAux: return pObj.NEstadoAuxiliar;
                case AuxiliarEN.UsuAgr: return pObj.UsuarioAgrega;
                case AuxiliarEN.FecAgr: return pObj.FechaAgrega.ToString();
                case AuxiliarEN.UsuMod: return pObj.UsuarioModifica;
                case AuxiliarEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<AuxiliarEN> FiltrarAuxiliaresXTextoEnCualquierPosicion(List<AuxiliarEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<AuxiliarEN> iLisRes = new List<AuxiliarEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (AuxiliarEN xPer in pLista)
            {
                string iTexto = AuxiliarRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<AuxiliarEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<AuxiliarEN> pListaAuxiliares)
        {
            //lista resultado
            List<AuxiliarEN> iLisRes = new List<AuxiliarEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaAuxiliares; }

            //filtar la lista
            iLisRes = AuxiliarRN.FiltrarAuxiliaresXTextoEnCualquierPosicion(pListaAuxiliares, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<AuxiliarEN> ListarProveedores(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarProveedores(pObj);
        }

        public static List<AuxiliarEN> ListarProveedoresSinAuxiliarSolicitudPedido(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarProveedoresSinAuxiliarSolicitudPedido(pObj);
        }

        public static AuxiliarEN EsProveedorValido(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando el codigo no existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida cuando no es proveedor o cliente/proveedor
            AuxiliarEN iAuxProEN = AuxiliarRN.ValidaCuandoNoEsProveedor(iAuxEN);
            if (iAuxProEN.Adicionales.EsVerdad == false) { return iAuxProEN; }

            //ok
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoNoEsProveedor(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar                 
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CTipoAuxiliar,"1,2") == false)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoAuxiliar + " no es de un proveedor";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }

        public static AuxiliarEN EsActoModificarAuxiliar(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar si existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //ok            
            return iAuxEN;
        }

        public static AuxiliarEN EsActoEliminarAuxiliar(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar si existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida si existe este Personal en MovimientoCabe
            AuxiliarEN iAuxExiEN = AuxiliarRN.ValidaCuandoCodigoAuxiliarEstaEnMovimientoCabe(iAuxEN);
            if (iAuxExiEN.Adicionales.EsVerdad == false) { return iAuxExiEN; }

            //ok            
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoCodigoAuxiliarEstaEnMovimientoCabe(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida
            bool iExisten = MovimientoCabeRN.ExisteValorEnColumnaSinEmpresa(MovimientoCabeEN.CodAux, pObj.CodigoAuxiliar);
            if (iExisten == true)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "Este Auxiliar tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static List<AuxiliarEN> ListarClientes(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarClientes(pObj);
        }

        public static AuxiliarEN EsClienteValido(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando el codigo no existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida cuando no es proveedor o cliente/proveedor
            AuxiliarEN iAuxProEN = AuxiliarRN.ValidaCuandoNoEsCliente(iAuxEN);
            if (iAuxProEN.Adicionales.EsVerdad == false) { return iAuxProEN; }

            //ok
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoNoEsCliente(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar                 
            if (Cadena.ExisteValorEnConjuntoDeValores(pObj.CTipoAuxiliar, "0,2") == false)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoAuxiliar + " no es de un cliente";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }

        public static string ObtenerClaveAuxiliar(AuxiliarEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAuxiliar;

            //retornar
            return iClave;
        }

        public static List<AuxiliarEN> ListarProveedoresActivos(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarProveedoresActivos(pObj);
        }

        public static List<AuxiliarEN> ListarClientesActivos(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarClientesActivos(pObj);
        }

        public static AuxiliarEN EsProveedorActivoValido(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando el codigo no existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida cuando no es proveedor o cliente/proveedor
            AuxiliarEN iAuxProEN = AuxiliarRN.ValidaCuandoNoEsProveedor(iAuxEN);
            if (iAuxProEN.Adicionales.EsVerdad == false) { return iAuxProEN; }

            //valida cuando esta desactivado
            AuxiliarEN iAuxDesEN = AuxiliarRN.ValidaCuandoProveedorEstaDesactivado(iAuxEN);
            if (iAuxDesEN.Adicionales.EsVerdad == false) { return iAuxDesEN; }

            //ok
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoProveedorEstaDesactivado(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar                 
            if (pObj.CEstadoAuxiliar == "0")//desactivado
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El proveedor " + pObj.CodigoAuxiliar + " esta desactivado";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }

        public static AuxiliarEN ValidaCuandoClienteEstaDesactivado(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //validar                 
            if (pObj.CEstadoAuxiliar == "0")//desactivado
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "El cliente " + pObj.CodigoAuxiliar + " esta desactivado";
                return iAuxEN;
            }

            //ok
            iAuxEN.Adicionales.EsVerdad = true;
            return iAuxEN;
        }

        public static AuxiliarEN EsClienteActivoValido(AuxiliarEN pObj)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iAuxEN; }

            //valida cuando el codigo no existe
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(pObj);
            if (iAuxEN.Adicionales.EsVerdad == false) { return iAuxEN; }

            //valida cuando no es proveedor o cliente/proveedor
            AuxiliarEN iAuxProEN = AuxiliarRN.ValidaCuandoNoEsCliente(iAuxEN);
            if (iAuxProEN.Adicionales.EsVerdad == false) { return iAuxProEN; }

            //valida cuando esta desactivado
            AuxiliarEN iAuxDesEN = AuxiliarRN.ValidaCuandoClienteEstaDesactivado(iAuxEN);
            if (iAuxDesEN.Adicionales.EsVerdad == false) { return iAuxDesEN; }

            //ok
            return iAuxEN;
        }

        public static List<AuxiliarEN> ListarAuxiliaresPorCodigosAuxiliar(List<Auxiliar_Cont_EN> pLisAuxCont)
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = AuxiliarRN.ObtenerCodigosAuxiliar(pLisAuxCont);
            iAuxEN.Adicionales.CampoOrden = AuxiliarEN.CodAux;

            //ejecutar metodo
            return AuxiliarRN.ListarAuxiliaresPorCodigosAuxiliar(iAuxEN);
        }

        public static string ObtenerCodigosAuxiliar(List<Auxiliar_Cont_EN> pLisAuxCont)
        {
            //valor resultado
            string iCodigos = string.Empty;

            //recorrer cada objeto
            foreach (Auxiliar_Cont_EN xAuxCont in pLisAuxCont)
            {
                iCodigos += "'" + xAuxCont.CodigoAuxiliar + "',";
            }

            //si este valor es diferente del vacio entonces quitamo la ultima coma
            if (iCodigos != string.Empty)
            {
                iCodigos = iCodigos.Remove(iCodigos.Length - 1);
            }
            else
            {
                iCodigos = "''";
            }

            //devolver
            return iCodigos;
        }

        public static List<AuxiliarEN> ListarAuxiliaresPorCodigosAuxiliar(AuxiliarEN pObj)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ListarAuxiliaresPorCodigosAuxiliar(pObj);
        }

        public static AuxiliarEN BuscarAuxiliar(string pCampoBusqueda, string pValorBusqueda, List<AuxiliarEN> pListaBusqueda)
        {
            //objeto resultado
            AuxiliarEN iAuxEN = new AuxiliarEN();

            //recorrer cada objeto
            foreach (AuxiliarEN xAux in pListaBusqueda)
            {
                if (AuxiliarRN.ObtenerValorDeCampo(xAux, pCampoBusqueda) == pValorBusqueda)
                {
                    iAuxEN = xAux;
                    return iAuxEN;
                }
            }

            //devolver
            return iAuxEN;
        }

        public static string ObtenerClaveAuxiliar(string pCodigoAuxiliar)
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = pCodigoAuxiliar;

            //ejecutar metodo
            return AuxiliarRN.ObtenerClaveAuxiliar(iAuxEN);
        }

        public static void LlenarListaAdicionYModificacion(List<AuxiliarEN> pLisAuxAdi, List<AuxiliarEN> pLisAuxMod, List<AuxiliarEN> pLisAuxAlm,
            List<Auxiliar_Cont_EN> pLisAuxCont)
        {
            //esta funcion, cargara a la lista de adicion y/o modificacion de auxiliares que vengan de "Auxiliares de contabilidad"
            //y no esten en "Auxiliares de almacen"

            //recorrer cada auxiliar de contabilidad
            foreach (Auxiliar_Cont_EN xAuxCont in pLisAuxCont)
            {
                //buscar este auxiliar en el modulo almacen
                string iClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(xAuxCont.CodigoAuxiliar);
                AuxiliarEN iAuxEN = AuxiliarRN.BuscarAuxiliar(AuxiliarEN.ClaAux, iClaveAuxiliar, pLisAuxAlm);

                //si no lo encuentra, entonces crea un nuevo auxiliar para el modulo de almacen
                if (iAuxEN.ClaveAuxiliar == string.Empty)
                {
                    //creamos un nuevo auxiliar para el modulo de almacen
                    AuxiliarEN iAuxNueEN = new AuxiliarEN();

                    //pasamos datos
                    iAuxNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iAuxNueEN.CodigoAuxiliar = xAuxCont.CodigoAuxiliar;
                    iAuxNueEN.DescripcionAuxiliar = xAuxCont.DescripcionAuxiliar;
                    iAuxNueEN.DireccionAuxiliar = xAuxCont.DireccionAuxiliar;
                    iAuxNueEN.TelefonoAuxiliar = xAuxCont.TelefonoAuxiliar;
                    iAuxNueEN.CelularAuxiliar = xAuxCont.CelularAuxiliar;
                    iAuxNueEN.CorreoAuxiliar = xAuxCont.CorreoAuxiliar;
                    iAuxNueEN.ReferenciaAuxiliar = xAuxCont.ReferenciaAuxiliar;
                    iAuxNueEN.CTipoAuxiliar = AuxiliarRN.ConvertirACTipoAuxiliarAlmacen(xAuxCont.TipoAuxiliar);
                    iAuxNueEN.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(iAuxNueEN);

                    //adicionamos a la lista de auxiliares a adicionar
                    pLisAuxAdi.Add(iAuxNueEN);
                }
                else
                {
                    //primero debemos saber si se modifico el tipo de auxiliar,esta funcion ya actualiza 
                    //el ctipoauxiliar del objeto iAuxEN
                    bool iModificado = AuxiliarRN.FueModificadoCTipoAuxiliar(iAuxEN, xAuxCont.TipoAuxiliar);

                    //adicionamos a la lista de auxiliares a modificar
                    if (iModificado == true) { pLisAuxMod.Add(iAuxEN); }
                }
            }

        }

        public static string ConvertirACTipoAuxiliarAlmacen(string pCTipoAuxiliarContabilidad)
        {
            //valor resultado
            string iCodigo = string.Empty;

            //segun tipo de contabilidad
            switch (pCTipoAuxiliarContabilidad)
            {
                case "1": { iCodigo = "2"; break; }
                case "2": { iCodigo = "2"; break; }
                case "3": { iCodigo = "0"; break; }
                case "4": { iCodigo = "1"; break; }
            }

            //devolver
            return iCodigo;
        }

        public static bool FueModificadoCTipoAuxiliar(AuxiliarEN pObj, string pCTipoAuxiliarContabilidad)
        {
            //valor resultado
            bool iValor = false;

            //modificar
            //primero convertimos a CtipoAuxiliar para el modulo de almacen
            string iCTipoAuxiliar = AuxiliarRN.ConvertirACTipoAuxiliarAlmacen(pCTipoAuxiliarContabilidad);

            //segun tipo auxiliar
            switch (iCTipoAuxiliar)
            {
                case "0"://cliente
                    {
                        if (pObj.CTipoAuxiliar == "1")//proveedor
                        {
                            pObj.CTipoAuxiliar = "2";//pasa a cliente/proveedor
                            iValor = true;
                        }
                        break;
                    }
                case "1"://proveedor
                    {
                        if (pObj.CTipoAuxiliar == "0")//cliente
                        {
                            pObj.CTipoAuxiliar = "2";//pasa a cliente/proveedor
                            iValor = true;
                        }
                        break;
                    }             
            }

            //devolver
            return iValor;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            AuxiliarAD iPerAD = new AuxiliarAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static List<AuxiliarEN> ListarAuxiliares()
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.Adicionales.CampoOrden = AuxiliarEN.CodAux;

            //ejecutar metodo
            return ListarAuxiliares(iAuxEN);
        }

        public static void LlenarListaAdicion(List<AuxiliarEN> pLisAuxAdi, List<AuxiliarEN> pLisAuxEmp,
            List<MovimientoDetaEN> pLisAuxMovDet)
        {
            //esta funcion, cargara a la lista de adicion de auxiliares que vengan de "Auxiliares de importacion"
            //y no esten en "Auxiliares de empresa"

            //recorrer cada auxiliar de contabilidad
            foreach (MovimientoDetaEN xAuxMovDet in pLisAuxMovDet)
            {
                //buscar este auxiliar en la lista de auxiliares de la empresa
                string iClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(xAuxMovDet.CodigoAuxiliar);
                AuxiliarEN iAuxEN = AuxiliarRN.BuscarAuxiliar(AuxiliarEN.ClaAux, iClaveAuxiliar, pLisAuxEmp);

                //si no lo encuentra, entonces crea un nuevo auxiliar para el modulo de almacen
                if (iAuxEN.ClaveAuxiliar == string.Empty)
                {
                    //creamos un nuevo auxiliar para el modulo de almacen
                    AuxiliarEN iAuxNueEN = new AuxiliarEN();

                    //pasamos datos
                    iAuxNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iAuxNueEN.CodigoAuxiliar = xAuxMovDet.CodigoAuxiliar;
                    iAuxNueEN.DescripcionAuxiliar = xAuxMovDet.DescripcionAuxiliar;                   
                    iAuxNueEN.CTipoAuxiliar = "1";//proveedor
                    iAuxNueEN.TipoDocumentoAuxiliar = "0";//ruc
                    iAuxNueEN.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(iAuxNueEN);

                    //adicionamos a la lista de auxiliares a adicionar
                    pLisAuxAdi.Add(iAuxNueEN);
                }               
            }
        }

        public static void LlenarListaAdicionOC(List<AuxiliarEN> pLisAuxAdi, List<AuxiliarEN> pLisAuxEmp,
            List<MovimientoOCDetaEN> pLisAuxMovDet)
        {
            //esta funcion, cargara a la lista de adicion de auxiliares que vengan de "Auxiliares de importacion"
            //y no esten en "Auxiliares de empresa"

            //recorrer cada auxiliar de contabilidad
            foreach (MovimientoOCDetaEN xAuxMovDet in pLisAuxMovDet)
            {
                //buscar este auxiliar en la lista de auxiliares de la empresa
                string iClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(xAuxMovDet.CodigoAuxiliar);
                AuxiliarEN iAuxEN = AuxiliarRN.BuscarAuxiliar(AuxiliarEN.ClaAux, iClaveAuxiliar, pLisAuxEmp);

                //si no lo encuentra, entonces crea un nuevo auxiliar para el modulo de almacen
                if (iAuxEN.ClaveAuxiliar == string.Empty)
                {
                    //creamos un nuevo auxiliar para el modulo de almacen
                    AuxiliarEN iAuxNueEN = new AuxiliarEN();

                    //pasamos datos
                    iAuxNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iAuxNueEN.CodigoAuxiliar = xAuxMovDet.CodigoAuxiliar;
                    iAuxNueEN.DescripcionAuxiliar = xAuxMovDet.DescripcionAuxiliar;
                    iAuxNueEN.CTipoAuxiliar = "1";//proveedor
                    iAuxNueEN.TipoDocumentoAuxiliar = "0";//ruc
                    iAuxNueEN.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(iAuxNueEN);

                    //adicionamos a la lista de auxiliares a adicionar
                    pLisAuxAdi.Add(iAuxNueEN);
                }
            }
        }

        public static AuxiliarEN BuscarAuxiliarXCodigo(string pCodigoAuxiliar)
        {
            //asignar parametros
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.ClaveAuxiliar = AuxiliarRN.ObtenerClaveAuxiliar(pCodigoAuxiliar);

            //ejecutar metodo
            return AuxiliarRN.BuscarAuxiliarXClave(iAuxEN);
        }

        public static void AsignarAuxiliarPedido(AuxiliarEN pObj, List<AuxiliarEN> pLista)
        {
            //lista actualizada
            List<AuxiliarEN> iLisAux = new List<AuxiliarEN>();

            //buscamos el objeto en la lista pLista
            foreach (AuxiliarEN xPem in pLista)
            {
                if (xPem.ClaveAuxiliar == pObj.ClaveAuxiliar)
                {
                    xPem.VerdadFalso = pObj.VerdadFalso;
                    xPem.CPermitir = Conversion.BooleanACadena(pObj.VerdadFalso, "");
                }
                iLisAux.Add(xPem);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisAux);
        }

    }
}
