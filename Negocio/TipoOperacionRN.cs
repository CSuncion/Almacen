using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;

namespace Negocio
{
    public class TipoOperacionRN
    {

        public static TipoOperacionEN EnBlanco()
        {
            TipoOperacionEN iPerEN = new TipoOperacionEN();
            return iPerEN;
        }

        public static void AdicionarTipoOperacion(TipoOperacionEN pObj)
        {
            TipoOperacionAD iPerAD = new TipoOperacionAD();
            iPerAD.AgregarTipoOperacion(pObj);
        }

        public static void ModificarTipoOperacion(TipoOperacionEN pObj)
        {
            TipoOperacionAD iPerAD = new TipoOperacionAD();
            iPerAD.ModificarTipoOperacion(pObj);
        }

        public static void EliminarTipoOperacion(TipoOperacionEN pObj)
        {
            TipoOperacionAD iPerAD = new TipoOperacionAD();
            iPerAD.EliminarTipoOperacion(pObj);
        }

        public static List<TipoOperacionEN> ListarTipoOperaciones(TipoOperacionEN pObj)
        {
            TipoOperacionAD iPerAD = new TipoOperacionAD();
            return iPerAD.ListarTipoOperaciones(pObj);
        }

        public static List<TipoOperacionEN> ListarTipoOperaciones()
        {
            //asignar parametros
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            iTipOpeEN.Adicionales.CampoOrden = TipoOperacionEN.CodTipOpe;

            //ejecutar metodo
            return ListarTipoOperaciones(iTipOpeEN);
        }

        public static TipoOperacionEN BuscarTipoOperacionXCodigo(TipoOperacionEN pObj)
        {
            TipoOperacionAD iPerAD = new TipoOperacionAD();
            return iPerAD.BuscarTipoOperacionXCodigo(pObj);
        }

        public static TipoOperacionEN EsTipoOperacionExistente(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //validar
            iTipOpeEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(pObj);
            if (iTipOpeEN.CodigoTipoOperacion == string.Empty)
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El Tipo Operacion " + pObj.CodigoTipoOperacion + " no existe";
                return iTipOpeEN;
            }

            //ok         
            return iTipOpeEN;
        }

        public static TipoOperacionEN EsCodigoTipoOperacionDisponible(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoTipoOperacion == string.Empty) { return iTipOpeEN; }

            //valida cuando existe el codigo
            iTipOpeEN = TipoOperacionRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //ok          
            return iTipOpeEN;
        }

        public static TipoOperacionEN ValidaCuandoCodigoYaExiste(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //validar     
            iTipOpeEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(pObj);
            if (iTipOpeEN.CodigoTipoOperacion != string.Empty)
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoTipoOperacion + " ya existe";
                return iTipOpeEN;
            }

            //ok
            iTipOpeEN.Adicionales.EsVerdad = true;
            return iTipOpeEN;
        }
        
        public static string ObtenerValorDeCampo(TipoOperacionEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case TipoOperacionEN.ClaObj: return pObj.ClaveObjeto;
                case TipoOperacionEN.CodTipOpe: return pObj.CodigoTipoOperacion;
                case TipoOperacionEN.DesTipOpe: return pObj.DescripcionTipoOperacion;
                case TipoOperacionEN.CClaTipOpe: return pObj.CClaseTipoOperacion;
                case TipoOperacionEN.NClaTipOpe: return pObj.NClaseTipoOperacion;
                case TipoOperacionEN.CEstTipOpe: return pObj.CEstadoTipoOperacion;
                case TipoOperacionEN.NEstTipOpe: return pObj.NEstadoTipoOperacion;
                case TipoOperacionEN.UsuAgr: return pObj.UsuarioAgrega;
                case TipoOperacionEN.FecAgr: return pObj.FechaAgrega.ToString();
                case TipoOperacionEN.UsuMod: return pObj.UsuarioModifica;
                case TipoOperacionEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<TipoOperacionEN> FiltrarTipoOperacionesXTextoEnCualquierPosicion(List<TipoOperacionEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<TipoOperacionEN> iLisRes = new List<TipoOperacionEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (TipoOperacionEN xPer in pLista)
            {
                string iTexto = TipoOperacionRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<TipoOperacionEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<TipoOperacionEN> pListaTipoOperaciones)
        {
            //lista resultado
            List<TipoOperacionEN> iLisRes = new List<TipoOperacionEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaTipoOperaciones; }

            //filtar la lista
            iLisRes = TipoOperacionRN.FiltrarTipoOperacionesXTextoEnCualquierPosicion(pListaTipoOperaciones, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static TipoOperacionEN EsTipoOperacionIngresoValido(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoTipoOperacion == string.Empty) { return iTipOpeEN; }

            //valida cuando el codigo no existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida cuando no es de ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.ValidaCuandoNoEsDeIngreso(iTipOpeEN);
            if (iTipOpeIngEN.Adicionales.EsVerdad == false) { return iTipOpeIngEN; }

            //ok           
            return iTipOpeEN;
        }

        public static List<TipoOperacionEN> ListarTiposOperacionesXClase(TipoOperacionEN pObj)
        {
            TipoOperacionAD iPerAD = new TipoOperacionAD();
            return iPerAD.ListarTiposOperacionesXClase(pObj);
        }

        public static TipoOperacionEN ValidaCuandoNoEsDeIngreso(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //validar                 
            if (pObj.CClaseTipoOperacion != "1")
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El tipo operacion " + pObj.CodigoTipoOperacion + " no es de ingreso";
                return iTipOpeEN;
            }

            //ok
            iTipOpeEN.Adicionales.EsVerdad = true;
            return iTipOpeEN;
        }

        public static TipoOperacionEN ValidaCuandoNoEsDeOrdenCompra(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //validar                 
            if (pObj.CClaseTipoOperacion != "3")
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El tipo operacion " + pObj.CodigoTipoOperacion + " no es de orden de compra";
                return iTipOpeEN;
            }

            //ok
            iTipOpeEN.Adicionales.EsVerdad = true;
            return iTipOpeEN;
        }

        public static TipoOperacionEN EsActoModificarTipoOperacion(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //validar si existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //ok            
            return iTipOpeEN;
        }

        public static TipoOperacionEN EsActoEliminarTipoOperacion(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //validar si existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida si existe este tipooperacion en MovimientoCabe
            TipoOperacionEN iTipOpeExiEN = TipoOperacionRN.ValidaCuandoCodigoTipoOperacionEstaEnMovimientoCabe(iTipOpeEN);
            if (iTipOpeExiEN.Adicionales.EsVerdad == false) { return iTipOpeExiEN; }

            //ok            
            return iTipOpeEN;
        }

        public static TipoOperacionEN ValidaCuandoCodigoTipoOperacionEstaEnMovimientoCabe(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida
            bool iExisten = MovimientoCabeRN.ExisteValorEnColumnaSinEmpresa(MovimientoCabeEN.CodTipOpe, pObj.CodigoTipoOperacion);
            if (iExisten == true)
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "Este tipo de operacion tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
                return iTipOpeEN;
            }

            //ok
            return iTipOpeEN;
        }

        public static TipoOperacionEN EsTipoOperacionSalidaValido(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoTipoOperacion == string.Empty) { return iTipOpeEN; }

            //valida cuando el codigo no existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida cuando no es de ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.ValidaCuandoNoEsDeSalida(iTipOpeEN);
            if (iTipOpeIngEN.Adicionales.EsVerdad == false) { return iTipOpeIngEN; }

            //ok           
            return iTipOpeEN;
        }

        public static TipoOperacionEN ValidaCuandoNoEsDeSalida(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //validar                 
            if (pObj.CClaseTipoOperacion != "2")
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El tipo operacion " + pObj.CodigoTipoOperacion + " no es de salida";
                return iTipOpeEN;
            }

            //ok
            iTipOpeEN.Adicionales.EsVerdad = true;
            return iTipOpeEN;
        }

        public static TipoOperacionEN BuscarTipoOperacionXCodigo(string pCodigoTipoOperacion)
        {
            //asignar parametros
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();
            iTipOpeEN.CodigoTipoOperacion = pCodigoTipoOperacion;

            //ejecutar metodo
            return TipoOperacionRN.BuscarTipoOperacionXCodigo(iTipOpeEN);
        }

        public static List<TipoOperacionEN> ListarTiposOperacionesXClaseExceptoParametrizados(TipoOperacionEN pObj)
        {
            //lista resultado
            List<TipoOperacionEN> iLisRes = new List<TipoOperacionEN>();

            //traer la lista de tipos de operacion de la clase elegida
            List<TipoOperacionEN> iLisTipOpeCla = TipoOperacionRN.ListarTiposOperacionesXClase(pObj);

            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //recorrer cada objeto
            foreach (TipoOperacionEN xTipOpe in iLisTipOpeCla)
            {
                //si el tipo es parametrizado, entonces no avanza en el proceso
                if (xTipOpe.CodigoTipoOperacion == iParEN.TipoOperacionTransferenciaSalida) { continue; }
                if (xTipOpe.CodigoTipoOperacion == iParEN.TipoOperacionTransferenciaIngreso) { continue; }
                if (xTipOpe.CodigoTipoOperacion == iParEN.TipoOperacionProduccionSalida) { continue; }
                if (xTipOpe.CodigoTipoOperacion == iParEN.TipoOperacionProduccionIngreso) { continue; }

                //llenar a la lista resultado
                iLisRes.Add(xTipOpe);
            }

            //devolver
            return iLisRes;
        }

        public static TipoOperacionEN EsTipoOperacionSalidaNoParametrizadoValido(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoTipoOperacion == string.Empty) { return iTipOpeEN; }

            //valida cuando el codigo no existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida cuando no es de ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.ValidaCuandoNoEsDeSalida(iTipOpeEN);
            if (iTipOpeIngEN.Adicionales.EsVerdad == false) { return iTipOpeIngEN; }

            //valida que no sea parametrizado
            TipoOperacionEN iTipOpeParEN = TipoOperacionRN.ValidaCuandoEsDeSalidaParametrizado(iTipOpeEN);
            if (iTipOpeParEN.Adicionales.EsVerdad == false) { return iTipOpeParEN; }

            //ok           
            return iTipOpeEN;
        }

        public static TipoOperacionEN ValidaCuandoEsDeSalidaParametrizado(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //trae al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //validar                 
            if (pObj.CodigoTipoOperacion == iParEN.TipoOperacionProduccionSalida || pObj.CodigoTipoOperacion == iParEN.TipoOperacionTransferenciaSalida)
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El tipo operacion " + pObj.CodigoTipoOperacion + " no es puede elegir por esta ventana";
                return iTipOpeEN;
            }

            //ok
            iTipOpeEN.Adicionales.EsVerdad = true;
            return iTipOpeEN;
        }

        public static TipoOperacionEN EsTipoOperacionIngresoNoParametrizadoValido(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoTipoOperacion == string.Empty) { return iTipOpeEN; }

            //valida cuando el codigo no existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida cuando no es de ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.ValidaCuandoNoEsDeIngreso(iTipOpeEN);
            if (iTipOpeIngEN.Adicionales.EsVerdad == false) { return iTipOpeIngEN; }

            //valida que no sea parametrizado
            TipoOperacionEN iTipOpeParEN = TipoOperacionRN.ValidaCuandoEsDeIngresoParametrizado(iTipOpeEN);
            if (iTipOpeParEN.Adicionales.EsVerdad == false) { return iTipOpeParEN; }

            //ok           
            return iTipOpeEN;
        }

        public static TipoOperacionEN ValidaCuandoEsDeIngresoParametrizado(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //trae al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //validar                 
            if (pObj.CodigoTipoOperacion == iParEN.TipoOperacionProduccionIngreso || pObj.CodigoTipoOperacion == iParEN.TipoOperacionTransferenciaIngreso)
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El tipo operacion " + pObj.CodigoTipoOperacion + " no es puede elegir por esta ventana";
                return iTipOpeEN;
            }

            //ok
            iTipOpeEN.Adicionales.EsVerdad = true;
            return iTipOpeEN;
        }

        public static TipoOperacionEN EsTipoOperacionIngresoActivoValido(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoTipoOperacion == string.Empty) { return iTipOpeEN; }

            //valida cuando el codigo no existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida cuando no es de ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.ValidaCuandoNoEsDeIngreso(iTipOpeEN);
            if (iTipOpeIngEN.Adicionales.EsVerdad == false) { return iTipOpeIngEN; }

            //valida que no sea activo
            TipoOperacionEN iTipOpeDesEN = TipoOperacionRN.ValidaCuandoEstaDesactivado(iTipOpeEN);
            if (iTipOpeDesEN.Adicionales.EsVerdad == false) { return iTipOpeDesEN; }

            //ok           
            return iTipOpeEN;
        }

        public static TipoOperacionEN ValidaCuandoEstaDesactivado(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //validar                 
            if (pObj.CEstadoTipoOperacion == "0")//desactivado
            {
                iTipOpeEN.Adicionales.EsVerdad = false;
                iTipOpeEN.Adicionales.Mensaje = "El tipo operacion " + pObj.CodigoTipoOperacion + " esta desactivado";
                return iTipOpeEN;
            }

            //ok
            iTipOpeEN.Adicionales.EsVerdad = true;
            return iTipOpeEN;
        }

        public static List<TipoOperacionEN> ListarTiposOperacionesXClaseActivos(TipoOperacionEN pObj)
        {
            TipoOperacionAD iPerAD = new TipoOperacionAD();
            return iPerAD.ListarTiposOperacionesXClaseActivos(pObj);
        }

        public static TipoOperacionEN EsTipoOperacionSalidaActivoValido(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoTipoOperacion == string.Empty) { return iTipOpeEN; }

            //valida cuando el codigo no existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida cuando no es de ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.ValidaCuandoNoEsDeSalida(iTipOpeEN);
            if (iTipOpeIngEN.Adicionales.EsVerdad == false) { return iTipOpeIngEN; }

            //valida que no sea activo
            TipoOperacionEN iTipOpeDesEN = TipoOperacionRN.ValidaCuandoEstaDesactivado(iTipOpeEN);
            if (iTipOpeDesEN.Adicionales.EsVerdad == false) { return iTipOpeDesEN; }

            //ok           
            return iTipOpeEN;
        }

        public static TipoOperacionEN EsTipoOperacionValido(TipoOperacionEN pObj,string pCClaseTipoOperacion)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //segun clase
            if (pCClaseTipoOperacion == "1")//ingreso
            {
                iTipOpeEN = TipoOperacionRN.EsTipoOperacionIngresoValido(pObj);
            }
            else
            {
                iTipOpeEN = TipoOperacionRN.EsTipoOperacionSalidaValido(pObj);
            }

            //ok           
            return iTipOpeEN;
        }

        public static List<string> ListarCodigosTiposOperacion()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traer a todos los tipos de operacion
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //obtener la lista de valores de codigos de almacen
            iLisRes = ListaG.ListarValoresDeCampo<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe);

            //devolver
            return iLisRes;
        }

        public static TipoOperacionEN EsTipoOperacionOrdenCompraActivoValido(TipoOperacionEN pObj)
        {
            //objeto resultado
            TipoOperacionEN iTipOpeEN = new TipoOperacionEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoTipoOperacion == string.Empty) { return iTipOpeEN; }

            //valida cuando el codigo no existe
            iTipOpeEN = TipoOperacionRN.EsTipoOperacionExistente(pObj);
            if (iTipOpeEN.Adicionales.EsVerdad == false) { return iTipOpeEN; }

            //valida cuando no es de ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.ValidaCuandoNoEsDeOrdenCompra(iTipOpeEN);
            if (iTipOpeIngEN.Adicionales.EsVerdad == false) { return iTipOpeIngEN; }

            //valida que no sea activo
            TipoOperacionEN iTipOpeDesEN = TipoOperacionRN.ValidaCuandoEstaDesactivado(iTipOpeEN);
            if (iTipOpeDesEN.Adicionales.EsVerdad == false) { return iTipOpeDesEN; }

            //ok           
            return iTipOpeEN;
        }

    }
}
