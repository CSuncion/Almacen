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
    public class InventarioCabeRN
    {

        public static InventarioCabeEN EnBlanco()
        {
            InventarioCabeEN iPerEN = new InventarioCabeEN();
            return iPerEN;
        }

        public static void AdicionarInventarioCabe(InventarioCabeEN pObj)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            iPerAD.AgregarInventarioCabe(pObj);
        }

        public static void ModificarInventarioCabe(InventarioCabeEN pObj)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            iPerAD.ModificarInventarioCabe(pObj);
        }

        public static void EliminarInventarioCabe(InventarioCabeEN pObj)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            iPerAD.EliminarInventarioCabe(pObj);
        }

        public static List<InventarioCabeEN> ListarInventarioCabes(InventarioCabeEN pObj)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            return iPerAD.ListarInventarioCabes(pObj);
        }

        public static InventarioCabeEN BuscarInventarioCabeXClave(InventarioCabeEN pObj)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            return iPerAD.BuscarInventarioCabeXClave(pObj);
        }

        public static InventarioCabeEN EsInventarioCabeExistente(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iPerEN = new InventarioCabeEN();

            //validar si existe en b.d
            iPerEN = InventarioCabeRN.BuscarInventarioCabeXClave(pObj);
            if (iPerEN.ClaveInventarioCabe == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Inventario " + pObj.CorrelativoInventarioCabe + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static InventarioCabeEN ValidaCuandoCodigoYaExiste(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iPerEN = new InventarioCabeEN();

            //validar     
            iPerEN = InventarioCabeRN.BuscarInventarioCabeXClave(pObj);
            if (iPerEN.CorrelativoInventarioCabe != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El inventario " + pObj.CorrelativoInventarioCabe + " ya existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(InventarioCabeEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case InventarioCabeEN.ClaObj: return pObj.ClaveObjeto;
                case InventarioCabeEN.ClaInvCab: return pObj.ClaveInventarioCabe;
                case InventarioCabeEN.CodAlm: return pObj.CodigoAlmacen;
                case InventarioCabeEN.CodEmp: return pObj.CodigoEmpresa;
                case InventarioCabeEN.DesAlm: return pObj.DescripcionAlmacen;
                case InventarioCabeEN.CorInvCab: return pObj.CorrelativoInventarioCabe;
                case InventarioCabeEN.CodPer: return pObj.CodigoPersonal;
                case InventarioCabeEN.NomPer: return pObj.NombrePersonal;
                case InventarioCabeEN.FecInvCab: return pObj.FechaInventarioCabe;
                case InventarioCabeEN.StoFis: return pObj.StockFisico.ToString();
                case InventarioCabeEN.StoTeo: return pObj.StockTeorico.ToString();
                case InventarioCabeEN.ObsInvCab: return pObj.ObservacionInventarioCabe;
                case InventarioCabeEN.FecGen: return pObj.FechaGenera;
                case InventarioCabeEN.ClaMovIng: return pObj.ClaveMovimientoIngreso;
                case InventarioCabeEN.ClaMovSal: return pObj.ClaveMovimientoSalida;
                case InventarioCabeEN.CEstInvCab: return pObj.CEstadoInventarioCabe;
                case InventarioCabeEN.NEstInvCab: return pObj.NEstadoInventarioCabe;
                case InventarioCabeEN.UsuAgr: return pObj.UsuarioAgrega;
                case InventarioCabeEN.FecAgr: return pObj.FechaAgrega.ToString();
                case InventarioCabeEN.UsuMod: return pObj.UsuarioModifica;
                case InventarioCabeEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<InventarioCabeEN> FiltrarInventarioCabesXTextoEnCualquierPosicion(List<InventarioCabeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<InventarioCabeEN> iLisRes = new List<InventarioCabeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (InventarioCabeEN xPer in pLista)
            {
                string iTexto = InventarioCabeRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<InventarioCabeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<InventarioCabeEN> pListaInventarioCabes)
        {
            //lista resultado
            List<InventarioCabeEN> iLisRes = new List<InventarioCabeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaInventarioCabes; }

            //filtar la lista
            iLisRes = InventarioCabeRN.FiltrarInventarioCabesXTextoEnCualquierPosicion(pListaInventarioCabes, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveInventarioCabe(InventarioCabeEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.CodigoAlmacen + "-";
            iClave += pPer.CorrelativoInventarioCabe;

            //retornar
            return iClave;
        }

        public static InventarioCabeEN EsActoModificarInventarioCabe(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar si existe
            iInvCabEN = InventarioCabeRN.EsInventarioCabeExistente(pObj);
            if (iInvCabEN.Adicionales.EsVerdad == false) { return iInvCabEN; }

            //valida cuando ya genero movimientos ajuste
            InventarioCabeEN iInvCabGenEN = InventarioCabeRN.ValidaCuandoYaGeneroMovimientosAjuste(iInvCabEN);
            if (iInvCabGenEN.Adicionales.EsVerdad == false) { return iInvCabGenEN; }

            //ok            
            return iInvCabEN;
        }

        public static InventarioCabeEN EsActoEliminarInventarioCabe(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar si existe
            iInvCabEN = InventarioCabeRN.EsInventarioCabeExistente(pObj);
            if (iInvCabEN.Adicionales.EsVerdad == false) { return iInvCabEN; }

            //valida cuando ya genero movimientos ajuste
            InventarioCabeEN iInvCabGenEN = InventarioCabeRN.ValidaCuandoYaGeneroMovimientosAjuste(iInvCabEN);
            if (iInvCabGenEN.Adicionales.EsVerdad == false) { return iInvCabGenEN; }

            //ok            
            return iInvCabEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static List<InventarioCabeEN> ListarInventarioCabesActivos(InventarioCabeEN pObj)
        {
            InventarioCabeAD iPerAD = new InventarioCabeAD();
            return iPerAD.ListarInventarioCabesActivos(pObj);
        }

        public static List<InventarioCabeEN> ListarInventarioCabes()
        {
            //asignar parametros
            InventarioCabeEN iAlmEN = new InventarioCabeEN();
            iAlmEN.Adicionales.CampoOrden = InventarioCabeEN.CodAlm;

            //ejecutar metodo
            return InventarioCabeRN.ListarInventarioCabes(iAlmEN);
        }

        public static InventarioCabeEN BuscarInventarioCabe(string pCampoBusqueda, string pValorBusqueda, List<InventarioCabeEN> pListaBusqueda)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //recorrer cada objeto
            foreach (InventarioCabeEN xInvCab in pListaBusqueda)
            {
                if (InventarioCabeRN.ObtenerValorDeCampo(xInvCab, pCampoBusqueda) == pValorBusqueda)
                {
                    iInvCabEN = xInvCab;
                    return iInvCabEN;
                }
            }

            //devolver
            return iInvCabEN;
        }

        public static string ObtenerMaximoValorEnColumna(InventarioCabeEN pObj)
        {
            InventarioCabeAD iCliAD = new InventarioCabeAD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoCorrelativoInventarioCabeAutogenerado(InventarioCabeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = InventarioCabeRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 3);

            //devuelve
            return iNumero;
        }

        public static InventarioCabeEN EsActoGenerarMovimientosAjustes(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar si existe
            iInvCabEN = InventarioCabeRN.EsInventarioCabeExistente(pObj);
            if (iInvCabEN.Adicionales.EsVerdad == false) { return iInvCabEN; }

            //validar cuando esta cerrado
            InventarioCabeEN iInvCanTerEN = InventarioCabeRN.ValidaCuandoEstaTerminado(iInvCabEN);
            if (iInvCanTerEN.Adicionales.EsVerdad == false) { return iInvCanTerEN; }

            //validar cuando ya genero movimientos de ajuste
            InventarioCabeEN iInvCanAjuEN = InventarioCabeRN.ValidaCuandoYaGeneroMovimientosAjuste(iInvCabEN);
            if (iInvCanAjuEN.Adicionales.EsVerdad == false) { return iInvCanAjuEN; }

            //validar cuando no hay diferencias de stock
            InventarioCabeEN iInvCabStoEN = InventarioCabeRN.ValidaCuandoNoHayDiferenciasStock(iInvCabEN);
            if (iInvCabStoEN.Adicionales.EsVerdad == false) { return iInvCabStoEN; }

            //validar cuando no hay parametros de tipo de operacion ajuste
            InventarioCabeEN iInvCabParEN = InventarioCabeRN.ValidaCuandoNoHayParametrosAjuste();
            if (iInvCabParEN.Adicionales.EsVerdad == false) { return iInvCabParEN; }

            //ok            
            return iInvCabEN;
        }

        public static InventarioCabeEN ValidaCuandoEstaTerminado(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iPerEN = new InventarioCabeEN();

            //validar              
            if (pObj.CEstadoInventarioCabe == "1")//terminado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El inventario esta terminado, " + Universal.ErrorMensaje();
                return iPerEN;
            }

            //ok          
            return iPerEN;
        }

        public static InventarioCabeEN ValidaCuandoYaGeneroMovimientosAjuste(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iPerEN = new InventarioCabeEN();

            //validar              
            if (pObj.FechaGenera != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El inventario ya genero los movimientos de ajuste, " + Universal.ErrorMensaje();
                return iPerEN;
            }

            //ok          
            return iPerEN;
        }

        public static InventarioCabeEN ValidaCuandoNoHayDiferenciasStock(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iPerEN = new InventarioCabeEN();

            //validar              
            InventarioDetaEN iInvDetEN = new InventarioDetaEN();
            iInvDetEN.ClaveInventarioCabe = pObj.ClaveInventarioCabe;
            iInvDetEN.Adicionales.CampoOrden = InventarioDetaEN.ClaInvDet;
            List<InventarioDetaEN> iLisInvDet = InventarioDetaRN.ListarInventarioDetasParaDiferenciaStock(iInvDetEN);
            if (iLisInvDet.Count == 0)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El inventario no tiene existencias con diferencia de stock, " + Universal.ErrorMensaje();
                return iPerEN;
            }

            //ok          
            return iPerEN;
        }

        public static InventarioCabeEN ValidaCuandoNoHayParametrosAjuste()
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar              
            ParametroEN iParEN = ParametroRN.BuscarParametro();
            if (iParEN.TipoOperacionIngresoAjuste == string.Empty || iParEN.TipoOperacionSalidaAjuste==string.Empty)
            {
                iInvCabEN.Adicionales.EsVerdad = false;
                iInvCabEN.Adicionales.Mensaje = "Tienes que indicar los tipos de operacion de ajuste en la ventana de Parametros Generales, ";
                iInvCabEN.Adicionales.Mensaje += Universal.ErrorMensaje();
                return iInvCabEN;
            }

            //ok           
            return iInvCabEN;
        }

        public static void GenerarAjusteInventario(InventarioCabeEN pObj)
        {
            //-----------------------------------------------
            //cargar todos los objetos necesarios para operar
            //-----------------------------------------------

            //traer al objeto InventarioCabe de la b.d
            InventarioCabeEN iInvCabEN = InventarioCabeRN.BuscarInventarioCabeXClave(pObj);

            //traer al objeto parametro,para sacar los codigos de tipos de operacion para este proceso
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traer al tipo de operacion ajuste ingreso
            TipoOperacionEN iTipOpeIng = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionIngresoAjuste);

            //traer al tipo de operacion ajuste ingreso
            TipoOperacionEN iTipOpeSal = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionSalidaAjuste);

            //traer la lista de InventariosDeta solo para Ingreso
            List<InventarioDetaEN> iLisInvDetIng = InventarioDetaRN.ListarInventarioDetasParaAjusteIngreso(pObj.ClaveInventarioCabe);

            //traer la lista de InventariosDeta solo para Salida
            List<InventarioDetaEN> iLisInvDetSal = InventarioDetaRN.ListarInventarioDetasParaAjusteSalida(pObj.ClaveInventarioCabe);

            //-------------------------
            //objetos y listas a grabar
            //-------------------------

            MovimientoCabeEN iMovCabIngEN = new MovimientoCabeEN();
            MovimientoCabeEN iMovCabSalEN = new MovimientoCabeEN();
            List<MovimientoDetaEN> iLisMovDetIng = new List<MovimientoDetaEN>();
            List<MovimientoDetaEN> iLisMovDetSal = new List<MovimientoDetaEN>();

            //--------
            //operando
            //--------

            //preguntamos si se va a generar movimiento ajuste para ingreso
            if (iLisInvDetIng.Count != 0)
            {
                //armar objeto MovimientoCabe ajuste ingreso
                iMovCabIngEN = MovimientoCabeRN.ArmarMovimientoCabeAjuste(iInvCabEN, iTipOpeIng, pObj.FechaGenera);

                //armar la lista de MovimientosDeta desde la lista InventariosDeta
                iLisMovDetIng = MovimientoDetaRN.ArmarAMovimientosDeta(iLisInvDetIng, iMovCabIngEN);
            }

            //preguntamos si se va a generar movimiento ajuste para salida
            if (iLisInvDetSal.Count != 0)
            {
                //armar objeto MovimientoCabe ajuste salida
                iMovCabSalEN = MovimientoCabeRN.ArmarMovimientoCabeAjuste(iInvCabEN, iTipOpeSal, pObj.FechaGenera);

                //armar la lista de MovimientosDeta desde la lista InventariosDeta
                iLisMovDetSal = MovimientoDetaRN.ArmarAMovimientosDeta(iLisInvDetSal, iMovCabSalEN);
            }

            //actualizando datos para el InventarioCabe final
            iInvCabEN.FechaGenera = pObj.FechaGenera;
            iInvCabEN.ClaveMovimientoIngreso = iMovCabIngEN.ClaveMovimientoCabe;
            iInvCabEN.ClaveMovimientoSalida = iMovCabSalEN.ClaveMovimientoCabe;

            //--------------
            //grabando todos
            //--------------

            if (iMovCabIngEN.ClaveMovimientoCabe != string.Empty)
            {
                MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabIngEN);
                MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetIng);
                ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDetIng);
            }

            if (iMovCabSalEN.ClaveMovimientoCabe != string.Empty)
            {
                MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabSalEN);
                MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetSal);
                ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDetSal);
            }
            
            InventarioCabeRN.ModificarInventarioCabe(iInvCabEN);
            
        }

        public static InventarioCabeEN EsActoTerminarProceso(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar si existe
            iInvCabEN = InventarioCabeRN.EsInventarioCabeExistente(pObj);
            if (iInvCabEN.Adicionales.EsVerdad == false) { return iInvCabEN; }

            //validar cuando esta cerrado
            InventarioCabeEN iInvCanTerEN = InventarioCabeRN.ValidaCuandoEstaTerminado(iInvCabEN);
            if (iInvCanTerEN.Adicionales.EsVerdad == false) { return iInvCanTerEN; }

            //validar cuando aun no genera movimientos de ajuste
            InventarioCabeEN iInvCanAjuEN = InventarioCabeRN.ValidaCuandoNoGeneraMovimientosAjuste(iInvCabEN);
            if (iInvCanAjuEN.Adicionales.EsVerdad == false) { return iInvCanAjuEN; }
                     
            //ok            
            return iInvCabEN;
        }

        public static InventarioCabeEN ValidaCuandoNoGeneraMovimientosAjuste(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iPerEN = new InventarioCabeEN();

            //validar              
            if (pObj.FechaGenera == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El inventario aun no genera los movimientos de ajuste, " + Universal.ErrorMensaje();
                return iPerEN;
            }

            //ok          
            return iPerEN;
        }

        public static void CambiarEstadoATerminado(InventarioCabeEN pObj)
        {
            //actualizamos su estado a terminado
            pObj.CEstadoInventarioCabe = "1";//Terminado

            //modificamos en b.d
            InventarioCabeRN.ModificarInventarioCabe(pObj);
        }

        public static InventarioCabeEN EsActoCambiarAProcesando(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar si existe
            iInvCabEN = InventarioCabeRN.EsInventarioCabeExistente(pObj);
            if (iInvCabEN.Adicionales.EsVerdad == false) { return iInvCabEN; }

            //validar cuando esta en procesando
            InventarioCabeEN iInvCanProEN = InventarioCabeRN.ValidaCuandoEstaEnProcesando(iInvCabEN);
            if (iInvCanProEN.Adicionales.EsVerdad == false) { return iInvCanProEN; }

            //ok            
            return iInvCabEN;
        }

        public static InventarioCabeEN ValidaCuandoEstaEnProcesando(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iPerEN = new InventarioCabeEN();

            //validar              
            if (pObj.CEstadoInventarioCabe == "0")//procesando
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El inventario esta en Procesando, " + Universal.ErrorMensaje();
                return iPerEN;
            }

            //ok          
            return iPerEN;
        }

        public static void CambiarEstadoAProcesando(InventarioCabeEN pObj)
        {
            //actualizamos su estado a procesando
            pObj.CEstadoInventarioCabe = "0";//procesando

            //modificamos en b.d
            InventarioCabeRN.ModificarInventarioCabe(pObj);
        }

        public static InventarioCabeEN EsActoEliminarMovimientosAjuste(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar si existe
            iInvCabEN = InventarioCabeRN.EsInventarioCabeExistente(pObj);
            if (iInvCabEN.Adicionales.EsVerdad == false) { return iInvCabEN; }

            //validar cuando esta cerrado
            InventarioCabeEN iInvCanTerEN = InventarioCabeRN.ValidaCuandoEstaTerminado(iInvCabEN);
            if (iInvCanTerEN.Adicionales.EsVerdad == false) { return iInvCanTerEN; }

            //validar cuando aun no genera movimientos de ajuste
            InventarioCabeEN iInvCanAjuEN = InventarioCabeRN.ValidaCuandoNoGeneraMovimientosAjuste(iInvCabEN);
            if (iInvCanAjuEN.Adicionales.EsVerdad == false) { return iInvCanAjuEN; }

            //valida cuando no es acto registrar en este periodo
            InventarioCabeEN iInvCanPerEN = InventarioCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iInvCabEN);
            if (iInvCanPerEN.Adicionales.EsVerdad == false) { return iInvCanPerEN; }
                       
            //ok
            return iInvCabEN;
        }

        public static InventarioCabeEN ValidaCuandoNoEsActoRegistrarEnPeriodo(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = Fecha.ObtenerPeriodo(pObj.FechaGenera, "-");
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iInvCabEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iInvCabEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iInvCabEN;
        }

        public static void AccionEliminarMovimientosAjuste(InventarioCabeEN pObj)
        {
            //eliminar el MovimientoCabe salida
            MovimientoCabeRN.EliminarMovimientoCabe(pObj.ClaveMovimientoSalida);

            //actualizar las existencias por eliminacion salida
            ExistenciaRN.ActualizarExistenciasPorEliminacion(pObj.ClaveMovimientoSalida);

            //eliminar MovimientosDeta salida
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(pObj.ClaveMovimientoSalida);

            //eliminar el MovimientoCabe ingreso
            MovimientoCabeRN.EliminarMovimientoCabe(pObj.ClaveMovimientoIngreso);

            //actualizar las existencias por eliminacion ingreso
            ExistenciaRN.ActualizarExistenciasPorEliminacion(pObj.ClaveMovimientoIngreso);

            //eliminar MovimientosDeta ingreso
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(pObj.ClaveMovimientoIngreso);

            //modificar el inventarioCabe
            InventarioCabeRN.ModificarPorEliminacionMovimientosAjuste(pObj);
        }

        public static void ModificarPorEliminacionMovimientosAjuste(InventarioCabeEN pObj)
        {
            //actualizamos datos
            pObj.FechaGenera = string.Empty;
            pObj.ClaveMovimientoIngreso = string.Empty;
            pObj.ClaveMovimientoSalida = string.Empty;

            //modificamos en b.d
            InventarioCabeRN.ModificarInventarioCabe(pObj);
        }

        public static InventarioCabeEN EsActoActualizarCantidad(InventarioCabeEN pObj)
        {
            //objeto resultado
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();

            //validar si existe
            iInvCabEN = InventarioCabeRN.EsInventarioCabeExistente(pObj);
            if (iInvCabEN.Adicionales.EsVerdad == false) { return iInvCabEN; }

            //valida cuando ya genero movimientos ajuste
            InventarioCabeEN iInvCabGenEN = InventarioCabeRN.ValidaCuandoYaGeneroMovimientosAjuste(iInvCabEN);
            if (iInvCabGenEN.Adicionales.EsVerdad == false) { return iInvCabGenEN; }

            //ok            
            return iInvCabEN;
        }

    }
}
