using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using Entidades.Estructuras;
using System.Windows.Forms;

namespace Negocio
{
    public class RetiquetadoRN
    {

        public static RetiquetadoEN EnBlanco()
        {
            RetiquetadoEN iObjEN = new RetiquetadoEN();
            return iObjEN;
        }

        public static void AdicionarRetiquetado(List<RetiquetadoEN> pLista)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            iObjAD.AdicionarRetiquetado(pLista);
        }

        public static void AdicionarRetiquetado(RetiquetadoEN pObj)
        {
            //Asignar parametros
            List<RetiquetadoEN> iLisObj = new List<RetiquetadoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RetiquetadoRN.AdicionarRetiquetado(iLisObj);
        }

        public static void ModificarRetiquetado(List<RetiquetadoEN> pLista)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            iObjAD.ModificarRetiquetado(pLista);
        }

        public static void ModificarRetiquetado(RetiquetadoEN pObj)
        {
            //Asignar parametros
            List<RetiquetadoEN> iLisObj = new List<RetiquetadoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RetiquetadoRN.ModificarRetiquetado(iLisObj);
        }

        public static void EliminarRetiquetado(List<RetiquetadoEN> pLista)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            iObjAD.EliminarRetiquetado(pLista);
        }

        public static void EliminarRetiquetado(RetiquetadoEN pObj)
        {
            //Asignar parametros
            List<RetiquetadoEN> iLisObj = new List<RetiquetadoEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            RetiquetadoRN.EliminarRetiquetado(iLisObj);
        }

        public static List<RetiquetadoEN> ListarRetiquetado(RetiquetadoEN pObj)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.ListarRetiquetado(pObj);
        }

        public static List<RetiquetadoEN> ListarRetiquetado()
        {
            //asignar parametros
            RetiquetadoEN iObjEN = new RetiquetadoEN();
            iObjEN.Adicionales.CampoOrden = RetiquetadoEN.ClaRet;

            //ejecutar metodo
            return RetiquetadoRN.ListarRetiquetado(iObjEN);
        }

        public static RetiquetadoEN BuscarRetiquetadoXClave(RetiquetadoEN pObj)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.BuscarRetiquetadoXClave(pObj);
        }

        public static RetiquetadoEN EsRetiquetadoExistente(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //validar si existe en b.d
            iObjEN = RetiquetadoRN.BuscarRetiquetadoXClave(pObj);
            if (iObjEN.ClaveRetiquetado == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static RetiquetadoEN EsCodigoRetiquetadoDisponible(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //valida cuando esta vacio
            if (pObj.CorrelativoRetiquetado == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = RetiquetadoRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RetiquetadoEN ValidaCuandoCodigoYaExiste(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //validar
            iObjEN = RetiquetadoRN.BuscarRetiquetadoXClave(pObj);
            if (iObjEN.ClaveRetiquetado != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(RetiquetadoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case RetiquetadoEN.ClaObj: return pObj.ClaveObjeto;
                case RetiquetadoEN.ClaRet: return pObj.ClaveRetiquetado;
                case RetiquetadoEN.CodEmp: return pObj.CodigoEmpresa;
                case RetiquetadoEN.CorRet: return pObj.CorrelativoRetiquetado;
                case RetiquetadoEN.FecRet: return pObj.FechaRetiquetado;
                case RetiquetadoEN.PerRet: return pObj.PeriodoRetiquetado;
                case RetiquetadoEN.CodAlmPT: return pObj.CodigoAlmacenPT;
                case RetiquetadoEN.DesAlmPT: return pObj.DescripcionAlmacenPT;
                case RetiquetadoEN.CodExiPT: return pObj.CodigoExistenciaPT;
                case RetiquetadoEN.DesExiPT: return pObj.DescripcionExistenciaPT;
                case RetiquetadoEN.CodAlmRE: return pObj.CodigoAlmacenRE;
                case RetiquetadoEN.DesAlmRE: return pObj.DescripcionAlmacenRE;
                case RetiquetadoEN.CodExiRE: return pObj.CodigoExistenciaRE;
                case RetiquetadoEN.DesExiRE: return pObj.DescripcionExistenciaRE;
                case RetiquetadoEN.CanUniRet: return pObj.CantidadUnidadesRetiquetado.ToString();
                case RetiquetadoEN.CanCajRet: return pObj.CantidadCajasRetiquetado.ToString();
                case RetiquetadoEN.DetRetProTer: return pObj.DetalleRetiquetadoProTer;
                case RetiquetadoEN.ClaSalUniEmp: return pObj.ClaveSalidaUnidadesEmpacar;
                case RetiquetadoEN.ClaSalFasEmp: return pObj.ClaveSalidaFaseEmpaquetado;
                case RetiquetadoEN.ClaIngProTer: return pObj.ClaveIngresoProductoTerminado;
                case RetiquetadoEN.CEstRet: return pObj.CEstadoRetiquetado;
                case RetiquetadoEN.NEstRet: return pObj.NEstadoRetiquetado;
                case RetiquetadoEN.UsuAgr: return pObj.UsuarioAgrega;
                case RetiquetadoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case RetiquetadoEN.UsuMod: return pObj.UsuarioModifica;
                case RetiquetadoEN.FecMod: return pObj.FechaModifica.ToString();

            }

            //retorna
            return iValor;
        }

        public static List<RetiquetadoEN> FiltrarRetiquetadoXTextoEnCualquierPosicion(List<RetiquetadoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<RetiquetadoEN> iLisRes = new List<RetiquetadoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (RetiquetadoEN xObj in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<RetiquetadoEN>(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<RetiquetadoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<RetiquetadoEN> pLista)
        {
            //lista resultado
            List<RetiquetadoEN> iLisRes = new List<RetiquetadoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = RetiquetadoRN.FiltrarRetiquetadoXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveRetiquetado(RetiquetadoEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CorrelativoRetiquetado;

            //retornar
            return iClave;
        }

        public static RetiquetadoEN EsRetiquetadoValido(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //valida cuando esta vacio
            if (pObj.CorrelativoRetiquetado == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = RetiquetadoRN.EsRetiquetadoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static RetiquetadoEN EsRetiquetadoActivoValido(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //valida cuando esta vacio
            if (pObj.CorrelativoRetiquetado == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = RetiquetadoRN.EsRetiquetadoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            RetiquetadoEN iObjDesEN = RetiquetadoRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static RetiquetadoEN ValidaCuandoEstaDesactivada(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //validar                 
            if (pObj.CEstadoRetiquetado == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) Retiquetado esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroRetiquetadoAutogenerado()
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = RetiquetadoRN.ObtenerMaximoValorEnColumna(RetiquetadoEN.CorRet, RetiquetadoEN.CodEmp, Universal.gCodigoEmpresa);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static RetiquetadoEN EsActoAdicionarRetiquetado(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //ok          
            return iObjEN;
        }

        public static RetiquetadoEN EsActoModificarRetiquetado(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //valida cuando el codigo no existe
            iObjEN = RetiquetadoRN.EsRetiquetadoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static RetiquetadoEN EsActoEliminarRetiquetado(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iObjEN = new RetiquetadoEN();

            //valida cuando el codigo no existe
            iObjEN = RetiquetadoRN.EsRetiquetadoExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static List<RetiquetadoEN> ListarRetiquetadoXEstado(RetiquetadoEN pObj)
        {
            RetiquetadoAD iObjAD = new RetiquetadoAD();
            return iObjAD.ListarRetiquetadoXEstado(pObj);
        }

        public static RetiquetadoEN ValidaCuandoNoEsActoRegistrarEnPeriodo(RetiquetadoEN pObj)
        {
            //objeto resultado
            RetiquetadoEN iRetEN = new RetiquetadoEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pObj.PeriodoRetiquetado;
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iRetEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iRetEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iRetEN;
        }

        public static decimal CalcularNumeroCajas(RetiquetadoEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTer = new ProduccionProTerEN();
            iProProTer.UnidadesPorEmpaque = pObj.UnidadesPorEmpaqueRE;
            iProProTer.CantidadUnidadesProTer = pObj.CantidadUnidadesRetiquetado;

            //ejecutar metodo
            return ProduccionProTerRN.CalcularNumeroCajas(iProProTer);
        }

        public static void ActualizarPorcentajesYCantidadesRango(RetiquetadoEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.CodigoAlmacen = pObj.CodigoAlmacenRE;
            iProProTerEN.CodigoExistencia = pObj.CodigoExistenciaRE;
            iProProTerEN.CantidadUnidadesProTer = pObj.CantidadUnidadesRetiquetado;
            iProProTerEN.NumeroCajas = pObj.CantidadCajasRetiquetado;

            //ejecutar metodo
            ProduccionProTerRN.ActualizarPorcentajesYCantidadesRango(iProProTerEN);

            //pasar datos al objeto retiquetado
            pObj.PorcentajeUnidadesRango = iProProTerEN.PorcentajeUnidadesRango;
            pObj.CantidadUnidadesRango = iProProTerEN.CantidadUnidadesRango;
            pObj.PorcentajeCajasRango = iProProTerEN.PorcentajeCajasRango;
            pObj.CantidadCajasRango = iProProTerEN.CantidadCajasRango;
        }

        public static void ModificarPorSalidaInsumosFaseEmpaquetado(RetiquetadoEN pObj)
        {
            //traer al Encajado de b.d
            RetiquetadoEN iRetEN = BuscarRetiquetadoXClave(pObj);

            //actualizamos los datos            
            iRetEN.ClaveSalidaFaseEmpaquetado = pObj.ClaveSalidaFaseEmpaquetado;

            //modificar en bd
            ModificarRetiquetado(iRetEN);
        }

        public static void ModificarPorSalidaUnidadesAEmpaquetar(RetiquetadoEN pObj)
        {
            //traer al Encajado de b.d
            RetiquetadoEN iRetEN = BuscarRetiquetadoXClave(pObj);

            //actualizamos los datos            
            iRetEN.ClaveSalidaUnidadesEmpacar = pObj.ClaveSalidaUnidadesEmpacar;

            //modificar en bd
            ModificarRetiquetado(iRetEN);
        }

        public static void ActualizarCostoUnidadEncajado(RetiquetadoEN pRet)
        {
            //actualizar costo insumo
            pRet.CostoUnidadEncajado = ObtenerCostoUnidadEncajado(pRet);
            pRet.CostoInsumos = ObtenerCostoInsumos(pRet);
            pRet.CostoTotalProducto = ObtenerCostoTotalProducto(pRet);
        }

        public static void ModificarCostoUnidadEncajado(RetiquetadoEN pRet)
        {
            //actualizamos los datos en el objeto
            ActualizarCostoUnidadEncajado(pRet);

            //modificar en bd
            ModificarRetiquetado(pRet);
        }

        public static decimal ObtenerCostoUnidadEncajado(List<RetiquetadoProTerEN> pLisRetProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //variables
            decimal iNumerador = 0;
            decimal iDenominador = 0;

            //calcular
            foreach (RetiquetadoProTerEN xRetProTer in pLisRetProTer)
            {
                iNumerador += xRetProTer.CostoTotalProducto * xRetProTer.CantidadRetiquetadoProTer;
                iDenominador += xRetProTer.CantidadRetiquetadoProTer;
            }

            //obtener el promedio ponderado
            iValor = Operador.DivisionDecimal(iNumerador, iDenominador);

            //lo redondeamos a 2 decimales
            iValor = Math.Round(iValor, 2);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoUnidadEncajado(RetiquetadoEN pRet)
        {
            //asignar parametros
            List<RetiquetadoProTerEN> iLisRetProTer = RetiquetadoProTerRN.ListarRetiquetadoProTerXClaveRetiquetado(pRet.ClaveRetiquetado);

            //ejecutar metodo
            return ObtenerCostoUnidadEncajado(iLisRetProTer);
        }

        public static decimal ObtenerCostoInsumos(RetiquetadoEN pRet)
        {
            //valor resultado
            decimal iValor = 0;

            //--------
            //calcular
            //--------
            iValor = pRet.CostoUnidadEncajado + pRet.CostoUnidadEmpaquetado;

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoTotalProducto(RetiquetadoEN pRet)
        {
            //valor resultado
            decimal iValor = 0;

            //--------
            //calcular
            //--------
            iValor = pRet.CostoInsumos + pRet.CostoManoObra + pRet.CostoOtros + pRet.CostoCIFFijo + pRet.CostoCIFVariable;

            //devolver
            return iValor;
        }

        public static void ModificarCostosFaseEmpaquetado(RetiquetadoEN pObj)
        {
            //actualizamos los datos de empaquetado
            ActualizarCostosFaseEmpaquetado(pObj);

            //modificar en bd
            ModificarRetiquetado(pObj);
        }

        public static void ActualizarCostosFaseEmpaquetado(RetiquetadoEN pObj)
        {
            //traer a todos los produccionesExis de este retiquetado
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveRetiquetado(pObj.ClaveRetiquetado);

            //actualizar datos
            ActualizarCostosFaseEmpaquetado(pObj, iLisProExi);
        }

        public static void ActualizarCostosFaseEmpaquetado(RetiquetadoEN pObj, List<ProduccionExisEN> pLisProExi)
        {
            //obtener el costo fase empaquetado semiEla principal
            pObj.CostoEmpaquetadoPrincipal = ProduccionExisRN.ObtenerCostoTotal(pLisProExi);

            ////obtener el costo cc masa adicional
            //xProProTer.CostoEmpaquetadoAdicional = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoAdicional(pProDet, xProProTer);

            ////obtener el costo cc devolucion
            //xProProTer.CostoEmpaquetadoDevolucion = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoDevolucion(pProDet, xProProTer);

            //obtener el costo cc masa total
            pObj.CostoEmpaquetadoTotal = ObtenerCostoEmpaquetadoTotal(pObj);

            //obtener costo de unidad de masa
            pObj.CostoUnidadEmpaquetado = ObtenerCostoUnidadEmpaquetado(pObj);

            //obtener el costo unidad total de insumos
            pObj.CostoInsumos = ObtenerCostoInsumos(pObj);

            //obtener el costo unidad total del producto
            pObj.CostoTotalProducto = ObtenerCostoTotalProducto(pObj);
        }

        public static decimal ObtenerCostoEmpaquetadoTotal(RetiquetadoEN pObj)
        {
            return pObj.CostoEmpaquetadoPrincipal + pObj.CostoEmpaquetadoAdicional - pObj.CostoEmpaquetadoDevolucion;
        }

        public static decimal ObtenerCostoUnidadEmpaquetado(RetiquetadoEN pObj)
        {
            //dividir entre el numero de unidades que pasaron el control de calidad
            decimal iCostoTotal = Operador.DivisionDecimal(pObj.CostoEmpaquetadoTotal, pObj.CantidadUnidadesRetiquetado);

            //redondeo
            iCostoTotal = Math.Round(iCostoTotal, 2);

            //devolver
            return iCostoTotal;
        }

        public static void ModificarPorIngresoProductosTerminados(RetiquetadoEN pObj)
        {
            //traer al Encajado de b.d
            RetiquetadoEN iRetEN = BuscarRetiquetadoXClave(pObj);

            //actualizamos los datos            
            iRetEN.ClaveIngresoProductoTerminado = pObj.ClaveIngresoProductoTerminado;

            //modificar en bd
            ModificarRetiquetado(iRetEN);
        }

        public static void ModificarCostosManoObraProTer(RetiquetadoEN pObj)
        {
            //listar todas las FormulasDetas con codigoexistencia ProTer
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminadoRE(pObj);

            //obtener el factor para esta produccion
            decimal iFactorCosto = FactorCostoRN.ObtenerFactorCosto(pObj);

            //actualizamos los datos de empaquetado
            ActualizarCostosManoObraProTer(pObj, iForDetEN.RatioFormulaCabe, iFactorCosto);

            //modificar en bd
            ModificarRetiquetado(pObj);
        }

        public static void ActualizarCostosManoObraProTer(RetiquetadoEN pObj, decimal pRatio, decimal pFactor)
        {
            //actualizar datos
            pObj.FactorProduccionRet = pFactor;
            pObj.RatioProduccionRet = pRatio;
            pObj.HorasHombre = ProduccionProTerRN.CalcularHorasHombre(pObj.RatioProduccionRet, pObj.CantidadUnidadesRetiquetado);
            pObj.CostoTotalManoObra = ProduccionProTerRN.CalcularCostoTotalManoObra(pObj.HorasHombre, pFactor);
            pObj.CostoManoObra = ProduccionProTerRN.CalcularCostoUnitarioManoObra(pObj.CostoTotalManoObra, pObj.CantidadUnidadesRetiquetado);

            //obtener el costo unidad total del producto
            pObj.CostoTotalProducto = ObtenerCostoTotalProducto(pObj);
        }

        public static List<RetiquetadoEN> ListarRetiquetadoXPeriodoRetiquetado(RetiquetadoEN pObj)
        {
            RetiquetadoAD iProAD = new RetiquetadoAD();
            return iProAD.ListarRetiquetadoXPeriodoRetiquetado(pObj);
        }

        public static List<RetiquetadoEN> ListarRetiquetadoXPeriodoRetiquetado(string pAño, string pCodigoMes)
        {
            //asignar parametros
            RetiquetadoEN iRetEN = new RetiquetadoEN();
            iRetEN.PeriodoRetiquetado = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iRetEN.Adicionales.CampoOrden = RetiquetadoEN.ClaRet;

            //ejecutar metodo
            return ListarRetiquetadoXPeriodoRetiquetado(iRetEN);
        }

        public static void ActualizarPorRecalculoRetiquetado(List<RetiquetadoEN> pLisRet, List<RetiquetadoProTerEN> pLisRetProTer, List<MovimientoDetaEN> pLisMovDet,
             List<ProduccionExisEN> pLisProExi,List<FormulaDetaEN> pLisForDet,decimal pFactorManObr,FactorCIFEN pFacCif)
        {
            //listas a grabar en bd
            List<ProduccionExisEN> iLisProExiMod = new List<ProduccionExisEN>();
            List<MovimientoDetaEN> iLisMovDetMod = new List<MovimientoDetaEN>();
            
            //recorrer cada objeto retiquetado
            foreach (RetiquetadoEN xRet in pLisRet)
            {
                //obtener solo la lista de produccionesExis solo de este retiquetado
                List<ProduccionExisEN> iLisProExiFasEnc = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaRet, xRet.ClaveRetiquetado);

                //obtener el movimientosDeta de fase encajado de este retiquetado
                List<MovimientoDetaEN> iLisMovDetFasEnc = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xRet.ClaveSalidaFaseEmpaquetado);

                //actualizar los precios unitarios de las ProduccionesExis
                ProduccionExisRN.ActualizarPreciosUnitariosDesdeMovimientosDeta(iLisProExiFasEnc, iLisMovDetFasEnc);

                //obtener la lista de RetiquetadosProTer solo de xRet
                List<RetiquetadoProTerEN> iLisRetProTer = ListaG.Filtrar<RetiquetadoProTerEN>(pLisRetProTer, RetiquetadoProTerEN.ClaRet, xRet.ClaveRetiquetado);

                //actualizar el costo unidad encajado
                xRet.CostoUnidadEncajado = ObtenerCostoUnidadEncajado(iLisRetProTer);

                //actualizar el costo empaquetado
                ActualizarCostosFaseEmpaquetado(xRet, iLisProExiFasEnc);

                //buscar a formuladeta por su codigoformula
                FormulaDetaEN iForDetEN = ListaG.Buscar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CodExiProTer, xRet.CodigoExistenciaRE);
               
                //actualizar costo mano de obra
                ActualizarCostosManoObraProTer(xRet, iForDetEN.RatioFormulaCabe, pFactorManObr);

                //actualizar costo gastos indirectos
                ActualizarCostosGastoIndirectoProDet(xRet, iForDetEN.MasaUnidad, pFacCif);
               
                //actualizar el precioPromedio de su MovimientoDeta
                //buscar su movimientoDeta de ingreso al almacen de productos terminados
                MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xRet.ClaveIngresoProductoTerminado,
                    MovimientoDetaEN.CodExi, xRet.CodigoExistenciaPT);

                //actualizar el dato precio promedio
                iMovDetBusEN.PrecioUnitarioMovimientoDeta = xRet.CostoTotalProducto;

                //agregar a la lista resultado
                iLisMovDetMod.Add(iMovDetBusEN);

                //agregamos a la lista resultado a modificar en b.d
                iLisProExiMod.AddRange(iLisProExiFasEnc);
            }

            //grabaciones masivas en bd
            ProduccionExisRN.ModificarProduccionExis(iLisProExiMod);
            MovimientoDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
            ModificarRetiquetado(pLisRet);
        }

        public static void ModificarCostosIngresoIndirectoProDet(RetiquetadoEN pObj)
        {
            //obtener el objeto factor para esta produccion
            FactorCIFEN iFacCifEN = FactorCIFRN.BuscarFactorCosto(pObj);

            //obtener una FormulaDeta para este retiquetado
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminadoRE(pObj);

            //actualizamos los datos de empaquetado
            ActualizarCostosGastoIndirectoProDet(pObj,iForDetEN.MasaUnidad, iFacCifEN);
            
            //modificar en bd
            ModificarRetiquetado(pObj);
        }

        public static void ActualizarCostosGastoIndirectoProDet(RetiquetadoEN pObj,decimal pMasaUnidad, FactorCIFEN pFac)
        {
            //actualizar datos
            pObj.FactorCIFFijo = FactorCIFRN.ObtenerFactorCIFFijo(pFac);
            pObj.CostoCIFFijo = ProduccionProTerRN.CalcularCostoUnitarioGastoIndirecto(pObj.FactorCIFFijo, pMasaUnidad);
            pObj.FactorCIFVariable = FactorCIFRN.ObtenerFactorCIFVariable(pFac);
            pObj.CostoCIFVariable = ProduccionProTerRN.CalcularCostoUnitarioGastoIndirecto(pObj.FactorCIFVariable, pMasaUnidad);

            //obtener el costo unidad total del producto
            pObj.CostoTotalProducto = ObtenerCostoTotalProducto(pObj);
        }

        public static List<RetiquetadoEN> ObtenerReporteCostoLoteFaseRetiquetado(RetiquetadoEN pObj)
        {
            //lista resultado
            List<RetiquetadoEN> iLisRes = new List<RetiquetadoEN>();
            
            //traer la lista para el reporte
            List<RetiquetadoEN> iLisRet = ListarRetiquetadoParaReporteCostoLoteEtapaRetiquetado(pObj);
            
            //traer la lista para el reporte
            List<RetiquetadoProTerEN> iLisRetProTer = RetiquetadoProTerRN.ListarRetiquetadoProTerParaReporteCostoLoteEtapaRetiquetado(pObj);

            //listar las liberaciones que intervienen en estas ProduccionesProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnRetiquetadosProTer(iLisRetProTer);

            ////listar objetos con montos acumulados aprobados hasta antes de este filtro de fechas
            //List<ProduccionProTerEN> iLisProProTerAcu = ListarCantidadesAcumuladasAprobadasParaReporteCostoLoteFaseEncajado(iLisLib, pObj.Adicionales.Desde1);

            //recorrer cada objeto
            foreach (RetiquetadoEN xRet in iLisRet)
            {
                //obtener la lista RetiquetadoProTer de este xRet
                List<RetiquetadoProTerEN> iLisRetProTerRet = ListaG.Filtrar<RetiquetadoProTerEN>(iLisRetProTer, RetiquetadoProTerEN.ClaRet, xRet.ClaveRetiquetado);

                //recorrer cada objeto
                foreach (RetiquetadoProTerEN xRetProTer in iLisRetProTerRet)
                {
                    //obtener los lotes de este retiquetado ProTer
                    List<LoteRetiquetado> iLisLotRet = RetiquetadoProTerRN.ConvertirCampoDetalleCantidadesLoteALista(xRetProTer.DetalleCantidadesLote);

                    //recorrer cada objeto LiberacionProTer
                    foreach (LoteRetiquetado xLotRet in iLisLotRet)
                    {
                        //buscar a la liberacion este xLibProTer
                        LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLotRet.ClaveLiberacion);

                        //clonar al objeto xProProTer
                        RetiquetadoEN iRetNewEN = ObjetoG.Clonar<RetiquetadoEN>(xRet);

                        //actualizar datos                  
                        //iRetNewEN.ClaveProduccionDeta = iLibBusEN.ClaveProduccionDeta;
                        iRetNewEN.FechaEncajado = xRetProTer.FechaEncajado;
                        iRetNewEN.FechaLoteProTer = xLotRet.FechaProduccionDeta;
                        iRetNewEN.CorrelativoProduccionCabe = LiberacionRN.ObtenerCorrelativoProduccionCabe(xLotRet.ClaveLiberacion);
                        iRetNewEN.CodigoExistenciaRE = xRet.CodigoExistenciaRE;
                        iRetNewEN.DescripcionExistenciaRE = xRet.DescripcionExistenciaRE;
                        iRetNewEN.UnidadesEnviadasRetiquetado = 0;//xxxxxxxxxxxxxxxx
                        iRetNewEN.UnidadesRetiquetada = xLotRet.Cantidad;
                        iRetNewEN.PorcentajeRetiquetadoLote = 0;//xxxxxxxxxxxxx
                        iRetNewEN.PorcentajeRetiquetadoAcumulado = 0;//xxxxxxxxxxxxx
                        iRetNewEN.CostoEmpaquetadoTotal = ObtenerCostoEmbalajes(iRetNewEN);
                        iRetNewEN.CostoTotalManoObra = ObtenerCostoManoObra(iRetNewEN);
                        iRetNewEN.CostoCIFVariable = ObtenerCostoTotalCIFVariable(iRetNewEN);
                        iRetNewEN.CostoTotalVariable = ObtenerCostoTotalVariable(iRetNewEN);
                        iRetNewEN.CostoCIFFijo = ObtenerCostoTotalCIFFijo(iRetNewEN);
                        iRetNewEN.CostoTotalRetiquetado = ObtenerCostoTotalRetiquetado(iRetNewEN);
                        iRetNewEN.CostoTotalProducto = ObtenerCostoUnitarioRetiquetado(iRetNewEN);
                        iRetNewEN.CostoUnitarioRetiquetadoFijo = ObtenerCostoUnitarioRetiquetadoFijo(iRetNewEN);
                        iRetNewEN.CostoUnitarioRetiquetadoVariable = ObtenerCostoUnitarioRetiquetadoVariable(iRetNewEN);
                        iRetNewEN.CostoUnidadSemiProducto = iLibBusEN.CostoTotalProducto;
                        iRetNewEN.CostoUnitarioEnvasadoFijo = iLibBusEN.CostoCIFFijo;
                        iRetNewEN.CostoUnidadLoteEncajado = ObtenerCostoUnidadLoteEncajado(xRetProTer);
                        iRetNewEN.CostoUnitarioLoteEncajadoFijo = xRetProTer.CostoCIFFijo;

                        //agregar a la lista resultado
                        iLisRes.Add(iRetNewEN);
                    }
                }               
            }

            //obtener objeto totales
            RetiquetadoEN iRet = ObtenerObjetoTotalesReporteCostoLoteFaseRetiquetado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iRet);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCostoUnidadLoteEncajado(RetiquetadoProTerEN pObj)
        {
            return pObj.CostoTotalProducto - pObj.CostoUnidadSemiProducto;
        }

        public static RetiquetadoEN ObtenerObjetoTotalesReporteCostoLoteFaseRetiquetado(List<RetiquetadoEN> pLista)
        {
            //objeto resultado
            RetiquetadoEN iRetEN = new RetiquetadoEN();

            //obtener la lista acumulada de pLista            
            List<RetiquetadoEN> iLisRetAcu = ListaG.Acumular<RetiquetadoEN>(pLista, RetiquetadoEN.CodEmp,
                ObtenerListaCamposAAcumularReporteCostoLoteFaseRetiquetado());

            //si la lista esta vacia
            if (iLisRetAcu.Count != 0)
            {
                iRetEN = ObjetoG.Clonar<RetiquetadoEN>(iLisRetAcu[0]);
            }

            //actualizar datos a este objeto    
            iRetEN.FechaRetiquetado = string.Empty;       
            iRetEN.FechaEncajado = string.Empty;
            iRetEN.FechaLoteProTer = string.Empty;
            iRetEN.CorrelativoProduccionCabe = string.Empty;
            iRetEN.CodigoExistenciaRE = string.Empty;
            iRetEN.DescripcionExistenciaRE = "TOTALES";
            iRetEN.UnidadesRetiquetada = 0;
            iRetEN.UnidadesEnviadasRetiquetado = 0;
            iRetEN.PorcentajeRetiquetadoLote = 0;
            iRetEN.PorcentajeRetiquetadoAcumulado = 0;
            iRetEN.CostoTotalProducto = 0;
            iRetEN.CostoUnitarioRetiquetadoFijo = 0;
            iRetEN.CostoUnitarioRetiquetadoVariable = 0;
            
            //devolver
            return iRetEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostoLoteFaseRetiquetado()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(RetiquetadoEN.CosEmpTot);
            iLisRes.Add(RetiquetadoEN.CosTotManObr);
            iLisRes.Add(RetiquetadoEN.CosCIFVar);
            iLisRes.Add(RetiquetadoEN.CosTotVar);
            iLisRes.Add(RetiquetadoEN.CosCIFFij);
            iLisRes.Add(RetiquetadoEN.CosTotRet);

            //devolver
            return iLisRes;
        }

        public static List<RetiquetadoEN> ListarRetiquetadoParaReporteCostoLoteEtapaRetiquetado(RetiquetadoEN pObj)
        {
            RetiquetadoAD iProAD = new RetiquetadoAD();
            return iProAD.ListarRetiquetadoParaReporteCostoLoteEtapaRetiquetado(pObj);
        }

        public static decimal ObtenerCostoEmbalajes(RetiquetadoEN pObj)
        {
            return Math.Round(pObj.UnidadesRetiquetada * pObj.CostoUnidadEmpaquetado, 2);
        }

        public static decimal ObtenerCostoManoObra(RetiquetadoEN pObj)
        {
            return Math.Round(pObj.UnidadesRetiquetada * pObj.CostoManoObra, 2);
        }

        public static decimal ObtenerCostoTotalCIFVariable(RetiquetadoEN pObj)
        {
            return Math.Round(pObj.UnidadesRetiquetada * pObj.CostoCIFVariable, 2);
        }

        public static decimal ObtenerCostoTotalVariable(RetiquetadoEN pObj)
        {
            return pObj.CostoEmpaquetadoTotal + pObj.CostoTotalManoObra + pObj.CostoCIFVariable;
        }

        public static decimal ObtenerCostoTotalCIFFijo(RetiquetadoEN pObj)
        {
            return Math.Round(pObj.UnidadesRetiquetada * pObj.CostoCIFFijo, 2);
        }

        public static decimal ObtenerCostoTotalRetiquetado(RetiquetadoEN pObj)
        {
            return pObj.CostoTotalVariable + pObj.CostoCIFFijo;
        }

        public static decimal ObtenerCostoUnitarioRetiquetado(RetiquetadoEN pObj)
        {
            return Math.Round(Operador.DivisionDecimal(pObj.CostoTotalRetiquetado, pObj.UnidadesRetiquetada), 6);
        }

        public static decimal ObtenerCostoUnitarioRetiquetadoFijo(RetiquetadoEN pObj)
        {
            return Math.Round(Operador.DivisionDecimal(pObj.CostoCIFFijo, pObj.UnidadesRetiquetada), 6);
        }

        public static decimal ObtenerCostoUnitarioRetiquetadoVariable(RetiquetadoEN pObj)
        {
            return Math.Round(Operador.DivisionDecimal(pObj.CostoTotalVariable, pObj.UnidadesRetiquetada), 6);
        }

        public static List<CostoTotalProduccion> ObtenerReporteCostoTotalProduccion(RetiquetadoEN pObj)
        {
            //lista resultado
            List<CostoTotalProduccion> iLisRes = new List<CostoTotalProduccion>();

            //-------------------------------------------
            //obtener el reporte costo lote fase encajado
            //-------------------------------------------
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ObtenerReporteCostoLoteFaseEncajado(pObj);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //sacar el totales
                if(xProProTer.DescripcionExistencia == "TOTALES") { continue; }

                //creamos un nuevo objeto
                CostoTotalProduccion iCosTotPro = new CostoTotalProduccion();
                iCosTotPro.TipoOperacion = "ENCAJADO";
                iCosTotPro.CorrelativoOperacion = xProProTer.CorrelativoEncajado;
                iCosTotPro.CodigoEmpresa = Universal.gCodigoEmpresa;
                iCosTotPro.FechaProTer = xProProTer.FechaEncajado;
                iCosTotPro.FechaEncajado = xProProTer.FechaEncajado;
                iCosTotPro.FechaLote = xProProTer.FechaLoteProTer;
                iCosTotPro.CorrelativoProduccionCabe = xProProTer.ClaveProduccionCabe;
                iCosTotPro.CodigoExistencia = xProProTer.CodigoExistencia;
                iCosTotPro.DescripcionExistencia = xProProTer.DescripcionExistencia;
                iCosTotPro.UnidadesRetiquetadas = 0;
                iCosTotPro.UnidadesAprobadasLote = xProProTer.UnidadesAprobadasLote;
                iCosTotPro.UnidadesTerminadas = xProProTer.UnidadesEncajadasLote;
                iCosTotPro.PorcentajeLoteAprobado = xProProTer.PorcentajeEncajadoLote;
                iCosTotPro.PorcentajeLoteAprobadoAcumulado = xProProTer.PorcentajeEncajadoAcumulado;
                iCosTotPro.CostoEnvasadoUnitario = xProProTer.CostoUnidadSemiProducto;
                iCosTotPro.CostoEncajadoUnitario= xProProTer.CostoTotalProducto;
                iCosTotPro.CostoRetiquetadoUnitario = 0;
                iCosTotPro.CostoTotalUnitario = ObtenerCostoTotalUnitario(iCosTotPro);
                iCosTotPro.CostoEnvasadoTotal = ObtenerCostoEnvasadoTotal(iCosTotPro);
                iCosTotPro.CostoEncajadoTotal = ObtenerCostoEncajadoTotal(iCosTotPro);
                iCosTotPro.CostoRetiquetadoTotal = ObtenerCostoRetiquetadoTotal(iCosTotPro);
                iCosTotPro.CostoTotalTotal = ObtenerCostoTotalTotal(iCosTotPro);
                iCosTotPro.CostoFijoUnitario = ObtenerCostoFijoUnitario(xProProTer);
                iCosTotPro.CostoVariableUnitario = ObtenerCostoVariableUnitario(xProProTer);
                iCosTotPro.CostoTotalVariableUnitario = ObtenerCostoTotalVariableUnitario(iCosTotPro);
                iCosTotPro.CostoFijoTotal = ObtenerCostoFijoTotal(iCosTotPro);
                iCosTotPro.CostoVariableTotal = ObtenerCostoVariableTotal(iCosTotPro);
                iCosTotPro.CostoTotalVariableTotal = ObtenerCostoTotalVariableTotal(iCosTotPro);

                //agregar a lista resultado
                iLisRes.Add(iCosTotPro);
            }

            //----------------------------------------------
            //obtener el reporte costo lote fase retiquetado
            //----------------------------------------------
            List<RetiquetadoEN> iLisRet = ObtenerReporteCostoLoteFaseRetiquetado(pObj);

            //recorrer cada objeto
            foreach (RetiquetadoEN xRet in iLisRet)
            {
                //sacar el totales
                if (xRet.DescripcionExistenciaRE == "TOTALES") { continue; }

                //creamos un nuevo objeto
                CostoTotalProduccion iCosTotPro = new CostoTotalProduccion();
                iCosTotPro.TipoOperacion = "REETIQUETADO";
                iCosTotPro.CorrelativoOperacion = xRet.CorrelativoRetiquetado;
                iCosTotPro.CodigoEmpresa = Universal.gCodigoEmpresa;
                iCosTotPro.FechaProTer = xRet.FechaRetiquetado;
                iCosTotPro.FechaEncajado = xRet.FechaEncajado;
                iCosTotPro.FechaLote = xRet.FechaLoteProTer;
                iCosTotPro.CorrelativoProduccionCabe = xRet.CorrelativoProduccionCabe;
                iCosTotPro.CodigoExistencia = xRet.CodigoExistenciaRE;
                iCosTotPro.DescripcionExistencia = xRet.DescripcionExistenciaRE;
                iCosTotPro.UnidadesRetiquetadas = xRet.UnidadesRetiquetada;
                iCosTotPro.UnidadesAprobadasLote = 0;
                iCosTotPro.UnidadesTerminadas = xRet.UnidadesRetiquetada;
                iCosTotPro.PorcentajeLoteAprobado = 0;
                iCosTotPro.PorcentajeLoteAprobadoAcumulado = 0;
                iCosTotPro.CostoEnvasadoUnitario = xRet.CostoUnidadSemiProducto;
                iCosTotPro.CostoEncajadoUnitario = xRet.CostoUnidadLoteEncajado;
                iCosTotPro.CostoRetiquetadoUnitario = xRet.CostoTotalProducto;
                iCosTotPro.CostoTotalUnitario = ObtenerCostoTotalUnitario(iCosTotPro);
                iCosTotPro.CostoEnvasadoTotal = ObtenerCostoEnvasadoTotal(iCosTotPro);
                iCosTotPro.CostoEncajadoTotal = ObtenerCostoEncajadoTotal(iCosTotPro);
                iCosTotPro.CostoRetiquetadoTotal = ObtenerCostoRetiquetadoTotal(iCosTotPro);
                iCosTotPro.CostoTotalTotal = ObtenerCostoTotalTotal(iCosTotPro);
                iCosTotPro.CostoFijoUnitario = ObtenerCostoFijoUnitario(xRet);
                iCosTotPro.CostoVariableUnitario = ObtenerCostoVariableUnitario(xRet);
                iCosTotPro.CostoTotalVariableUnitario = ObtenerCostoTotalVariableUnitario(iCosTotPro);
                iCosTotPro.CostoFijoTotal = ObtenerCostoFijoTotal(iCosTotPro);
                iCosTotPro.CostoVariableTotal = ObtenerCostoVariableTotal(iCosTotPro);
                iCosTotPro.CostoTotalVariableTotal = ObtenerCostoTotalVariableTotal(iCosTotPro);

                //agregar a lista resultado
                iLisRes.Add(iCosTotPro);
            }

            //obtener objeto totales
            CostoTotalProduccion iRet = ObtenerObjetoTotalesReporteCostoLoteTotalProduccion(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iRet);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCostoTotalUnitario(CostoTotalProduccion pObj)
        {
            return pObj.CostoEnvasadoUnitario + pObj.CostoEncajadoUnitario + pObj.CostoRetiquetadoUnitario;
        }

        public static decimal ObtenerCostoEnvasadoTotal(CostoTotalProduccion pObj)
        {
            return Math.Round(pObj.CostoEnvasadoUnitario * pObj.UnidadesTerminadas, 2);
        }

        public static decimal ObtenerCostoEncajadoTotal(CostoTotalProduccion pObj)
        {
            return Math.Round(pObj.CostoEncajadoUnitario * pObj.UnidadesTerminadas, 2);
        }

        public static decimal ObtenerCostoRetiquetadoTotal(CostoTotalProduccion pObj)
        {
            return Math.Round(pObj.CostoRetiquetadoUnitario * pObj.UnidadesTerminadas, 2);
        }

        public static decimal ObtenerCostoTotalTotal(CostoTotalProduccion pObj)
        {
            return pObj.CostoEnvasadoTotal + pObj.CostoEncajadoTotal + pObj.CostoRetiquetadoTotal;
        }

        public static decimal ObtenerCostoFijoUnitario(ProduccionProTerEN pObj)
        {
            return pObj.CostoUnitarioEnvasadoFijo + pObj.CostoUnitarioEncajadoFijo;
        }

        public static decimal ObtenerCostoVariableUnitario(ProduccionProTerEN pObj)
        {
            return pObj.CostoUnidadSemiProducto - pObj.CostoUnitarioEnvasadoFijo + pObj.CostoUnitarioEncajadoVariable;
        }

        public static decimal ObtenerCostoTotalVariableUnitario(CostoTotalProduccion pObj)
        {
            return pObj.CostoFijoUnitario + pObj.CostoVariableUnitario;
        }

        public static decimal ObtenerCostoFijoTotal(CostoTotalProduccion pObj)
        {
            return Math.Round(pObj.CostoFijoUnitario * pObj.UnidadesTerminadas, 2);
        }

        public static decimal ObtenerCostoVariableTotal(CostoTotalProduccion pObj)
        {
            return Math.Round(pObj.CostoVariableUnitario * pObj.UnidadesTerminadas, 2);
        }

        public static decimal ObtenerCostoTotalVariableTotal(CostoTotalProduccion pObj)
        {
            return pObj.CostoFijoTotal + pObj.CostoVariableTotal;
        }

        public static decimal ObtenerCostoFijoUnitario(RetiquetadoEN pObj)
        {
            return pObj.CostoUnitarioEnvasadoFijo + pObj.CostoUnitarioLoteEncajadoFijo + pObj.CostoUnitarioRetiquetadoFijo;
        }

        public static decimal ObtenerCostoVariableUnitario(RetiquetadoEN pObj)
        {
            return pObj.CostoUnidadSemiProducto - pObj.CostoUnitarioEnvasadoFijo + pObj.CostoUnidadLoteEncajado - pObj.CostoUnitarioLoteEncajadoFijo +
                pObj.CostoUnitarioRetiquetadoVariable;
        }

        public static CostoTotalProduccion ObtenerObjetoTotalesReporteCostoLoteTotalProduccion(List<CostoTotalProduccion> pLista)
        {
            //objeto resultado
            CostoTotalProduccion iCosTotProEN = new CostoTotalProduccion();

            //obtener la lista acumulada de pLista            
            List<CostoTotalProduccion> iLisRetAcu = ListaG.Acumular<CostoTotalProduccion>(pLista, CostoTotalProduccion.CodEmp,
                ObtenerListaCamposAAcumularReporteCostoLoteTotalProduccion());

            //si la lista esta vacia
            if (iLisRetAcu.Count != 0)
            {
                iCosTotProEN = ObjetoG.Clonar<CostoTotalProduccion>( iLisRetAcu[0]);
            }

            //actualizar datos a este objeto    
            iCosTotProEN.TipoOperacion = string.Empty;
            iCosTotProEN.CorrelativoOperacion = string.Empty;
            iCosTotProEN.FechaProTer = string.Empty;
            iCosTotProEN.FechaEncajado = string.Empty;
            iCosTotProEN.FechaLote = string.Empty;
            iCosTotProEN.CorrelativoProduccionCabe = string.Empty;
            iCosTotProEN.CodigoExistencia = string.Empty;
            iCosTotProEN.DescripcionExistencia = "TOTALES";
            iCosTotProEN.UnidadesRetiquetadas = 0;
            iCosTotProEN.UnidadesAprobadasLote = 0;
            iCosTotProEN.UnidadesTerminadas = 0;
            iCosTotProEN.PorcentajeLoteAprobado = 0;
            iCosTotProEN.PorcentajeLoteAprobadoAcumulado = 0;
            iCosTotProEN.CostoEnvasadoUnitario = 0;
            iCosTotProEN.CostoEncajadoUnitario = 0;
            iCosTotProEN.CostoRetiquetadoUnitario =0;
            iCosTotProEN.CostoTotalUnitario = 0;
            iCosTotProEN.CostoFijoUnitario = 0;
            iCosTotProEN.CostoVariableUnitario = 0;
            iCosTotProEN.CostoTotalVariableUnitario = 0;

            //devolver
            return iCosTotProEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostoLoteTotalProduccion()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(CostoTotalProduccion.CosEnvTot);
            iLisRes.Add(CostoTotalProduccion.CosEncTot);
            iLisRes.Add(CostoTotalProduccion.CosRetTot);
            iLisRes.Add(CostoTotalProduccion.CosTotTot);
            iLisRes.Add(CostoTotalProduccion.CosFijTot);
            iLisRes.Add(CostoTotalProduccion.CosVarTot);
            iLisRes.Add(CostoTotalProduccion.CosTotVarTot);

            //devolver
            return iLisRes;
        }

        public static List<AcumuladoProceso> ObtenerReporteAcumuladosPorProcesoActualizado(RetiquetadoEN pObj)
        {
            //lista resultado
            List<AcumuladoProceso> iLisRes = new List<AcumuladoProceso>();

            //objetos elementos
            AcumuladoProceso iAcuProMatPri = new AcumuladoProceso() { Elemento = "MATERIA PRIMA", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProEnv = new AcumuladoProceso() { Elemento = "ENVASES" , CodigoExistencia = "x" };
            AcumuladoProceso iAcuProManObrEnv = new AcumuladoProceso() { Elemento = "MANO OBRA ENVASADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifVarEnv = new AcumuladoProceso() { Elemento = "CIF VARIABLE ENVASADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifFijEnv = new AcumuladoProceso() { Elemento = "CIF FIJO ENVASADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProEmbEnc = new AcumuladoProceso() { Elemento = "EMBALAJES ENCAJADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProManObrEnc = new AcumuladoProceso() { Elemento = "MANO OBRA ENCAJADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifVarEnc = new AcumuladoProceso() { Elemento = "CIF VARIABLE ENCAJADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifFijEnc = new AcumuladoProceso() { Elemento = "CIF FIJO ENCAJADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProEmbRet = new AcumuladoProceso() { Elemento = "EMBALAJES REETIQUETADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProManObrRet = new AcumuladoProceso() { Elemento = "MANO OBRA REETIQUETADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifVarRet = new AcumuladoProceso() { Elemento = "CIF VARIABLE REETIQUETADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifFijRet = new AcumuladoProceso() { Elemento = "CIF FIJO REETIQUETADO", CodigoExistencia = "x" };

            //-------------------------------------------
            //obtener el reporte costo lote fase encajado
            //-------------------------------------------
            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //listar las liberaciones que intervienen en estas ProduccionesProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(iLisProProTer);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //obtener la lista LiberacionProTer de este xProProTer
                List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(xProProTer.DetalleCantidadesSemiProducto);

                //recorrer cada objeto LiberacionProTer
                foreach (LiberacionProTer xLibProTer in iLisLibProTer)
                {
                    //buscar a la liberacion este xLibProTer
                    LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                    //actualizando materia prima
                    iAcuProMatPri.EnvasadoRea += ObtenerCostoMateriaPrima(iLibBusEN, xLibProTer);

                    //actualizando envasado
                    iAcuProEnv.EnvasadoRea += ObtenerCostoEnvasado(iLibBusEN, xLibProTer);

                    //actualizando mano obra envasado
                    iAcuProManObrEnv.EnvasadoRea += ObtenerCostoManoObraEnvasado(iLibBusEN, xLibProTer);

                    //actualizando cif variable envasado
                    iAcuProCifVarEnv.EnvasadoRea += ObtenerCostoCifVariableEnvasado(iLibBusEN, xLibProTer);

                    //actualizando cif fijo envasado
                    iAcuProCifVarEnv.EnvasadoRea += ObtenerCostoCifFijoEnvasado(iLibBusEN, xLibProTer);
                }

                //actualizando embalaje encajado
                iAcuProEmbEnc.EncajadoRea += xProProTer.CostoEmpaquetadoTotal;

                //actualizando mano obra encajado
                iAcuProManObrEnc.EncajadoRea += xProProTer.CostoTotalManoObra;

                //actualizando cif variable encajado
                iAcuProCifVarEnc.EncajadoRea += ObtenerCostoCifVariableEncajado(xProProTer);

                //actualizando cif fijo encajado
                iAcuProCifFijEnc.EncajadoRea += ObtenerCostoCifFijoEncajado(xProProTer);
            }

            //----------------------------------------------
            //obtener el reporte costo lote fase retiquetado
            //----------------------------------------------
            //traer la lista para el reporte
            List<RetiquetadoEN> iLisRet = ListarRetiquetadoParaReporteCostoLoteEtapaRetiquetado(pObj);

            //traer la lista para el reporte
            List<RetiquetadoProTerEN> iLisRetProTer = RetiquetadoProTerRN.ListarRetiquetadoProTerParaReporteCostoLoteEtapaRetiquetado(pObj);

            //listar las liberaciones que intervienen en estas ProduccionesProTer
            iLisLib = LiberacionRN.ListarLiberacionesUsadasEnRetiquetadosProTer(iLisRetProTer);

            //recorrer cada objeto
            foreach (RetiquetadoEN xRet in iLisRet)
            {
                //obtener la lista RetiquetadoProTer de este xRet
                List<RetiquetadoProTerEN> iLisRetProTerRet = ListaG.Filtrar<RetiquetadoProTerEN>(iLisRetProTer, RetiquetadoProTerEN.ClaRet, xRet.ClaveRetiquetado);

                //recorrer cada objeto
                foreach (RetiquetadoProTerEN xRetProTer in iLisRetProTerRet)
                {
                    //obtener los lotes de este retiquetado ProTer
                    List<LoteRetiquetado> iLisLotRet = RetiquetadoProTerRN.ConvertirCampoDetalleCantidadesLoteALista(xRetProTer.DetalleCantidadesLote);

                    //recorrer cada objeto LiberacionProTer
                    foreach (LoteRetiquetado xLotRet in iLisLotRet)
                    {
                        //buscar a la liberacion este xLibProTer
                        LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLotRet.ClaveLiberacion);

                        //actualizando materia prima
                        iAcuProMatPri.EnvasadoRea += ObtenerCostoMateriaPrima(iLibBusEN, xLotRet);

                        //actualizando envasado
                        iAcuProEnv.EnvasadoRea += ObtenerCostoEnvasado(iLibBusEN, xLotRet);

                        //actualizando mano obra envasado
                        iAcuProManObrEnv.EnvasadoRea += ObtenerCostoManoObraEnvasado(iLibBusEN, xLotRet);

                        //actualizando cif variable envasado
                        iAcuProCifVarEnv.EnvasadoRea += ObtenerCostoCifVariableEnvasado(iLibBusEN, xLotRet);

                        //actualizando cif fijo envasado
                        iAcuProCifVarEnv.EnvasadoRea += ObtenerCostoCifFijoEnvasado(iLibBusEN, xLotRet);
                    }

                    //actualizando embalaje encajado
                    iAcuProEmbEnc.EncajadoRea += ObtenerCostoEmbalaje(xRetProTer);

                    //actualizando mano obra encajado
                    iAcuProManObrEnc.EncajadoRea += ObtenerCostoManoObra(xRetProTer);

                    //actualizando cif variable encajado
                    iAcuProCifVarEnc.EncajadoRea += ObtenerCostoCifVariable(xRetProTer);

                    //actualizando cif fijo encajado
                    iAcuProCifFijEnc.EncajadoRea += ObtenerCostoCifFijo(xRetProTer);
                }

                //actualizando embalaje encajado
                iAcuProEmbRet.RetiquetadoRea += xRet.CostoEmpaquetadoTotal;

                //actualizando mano obra encajado
                iAcuProManObrRet.RetiquetadoRea += xRet.CostoTotalManoObra;

                //actualizando cif variable encajado
                iAcuProCifVarRet.RetiquetadoRea += ObtenerCostoCifVariableRetiquetado(xRet);

                //actualizando cif fijo encajado
                iAcuProCifFijRet.RetiquetadoRea += ObtenerCostoCifFijoRetiquetado(xRet);
            }

            //actualizar diferencias
            ObtenerDiferenciaPptoReal(iAcuProMatPri);
            ObtenerDiferenciaPptoReal(iAcuProEnv);
            ObtenerDiferenciaPptoReal(iAcuProManObrEnv);
            ObtenerDiferenciaPptoReal(iAcuProCifVarEnv);
            ObtenerDiferenciaPptoReal(iAcuProCifFijEnv);
            ObtenerDiferenciaPptoReal(iAcuProEmbEnc);
            ObtenerDiferenciaPptoReal(iAcuProManObrEnc);
            ObtenerDiferenciaPptoReal(iAcuProCifVarEnc);
            ObtenerDiferenciaPptoReal(iAcuProCifFijEnc);
            ObtenerDiferenciaPptoReal(iAcuProEmbRet);
            ObtenerDiferenciaPptoReal(iAcuProManObrRet);
            ObtenerDiferenciaPptoReal(iAcuProCifVarRet);
            ObtenerDiferenciaPptoReal(iAcuProCifFijRet);

            //agregar a lista resultado
            iLisRes.Add(iAcuProMatPri);
            iLisRes.Add(iAcuProEnv);
            iLisRes.Add(iAcuProManObrEnv);
            iLisRes.Add(iAcuProCifVarEnv);
            iLisRes.Add(iAcuProCifFijEnv);
            iLisRes.Add(iAcuProEmbEnc);
            iLisRes.Add(iAcuProManObrEnc);
            iLisRes.Add(iAcuProCifVarEnc);
            iLisRes.Add(iAcuProCifFijEnc);
            iLisRes.Add(iAcuProEmbRet);
            iLisRes.Add(iAcuProManObrRet);
            iLisRes.Add(iAcuProCifVarRet);
            iLisRes.Add(iAcuProCifFijRet);

            //obtener objeto totales
            AcumuladoProceso iRet = ObtenerObjetoTotalesReporteAcumuladosPorProcesoActualizado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iRet);

            //devolver
            return iLisRes;
        }

        public static AcumuladoProceso ObtenerObjetoTotalesReporteAcumuladosPorProcesoActualizado(List<AcumuladoProceso> pLista)
        {
            //objeto resultado
            AcumuladoProceso iRetEN = new AcumuladoProceso();

            //obtener la lista acumulada de pLista            
            List<AcumuladoProceso> iLisRetAcu = ListaG.Acumular<AcumuladoProceso>(pLista, AcumuladoProceso.CodExi,
                ObtenerListaCamposAAcumularReporteAcumuladosPorProcesoActualizado());

            //si la lista esta vacia
            if (iLisRetAcu.Count != 0)
            {
                iRetEN = ObjetoG.Clonar<AcumuladoProceso>( iLisRetAcu[0]);
            }

            //actualizar datos a este objeto                
            iRetEN.Elemento = "TOTALES";
            
            //devolver
            return iRetEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteAcumuladosPorProcesoActualizado()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(AcumuladoProceso.EnvPpto);
            iLisRes.Add(AcumuladoProceso.EncPpto);
            iLisRes.Add(AcumuladoProceso.RetPpto);
            iLisRes.Add(AcumuladoProceso.CosTotPpto);
            iLisRes.Add(AcumuladoProceso.EnvRea);
            iLisRes.Add(AcumuladoProceso.EncRea);
            iLisRes.Add(AcumuladoProceso.RetRea);
            iLisRes.Add(AcumuladoProceso.CosTotRea);
            iLisRes.Add(AcumuladoProceso.EnvDif);
            iLisRes.Add(AcumuladoProceso.EncDif);
            iLisRes.Add(AcumuladoProceso.RetDif);
            iLisRes.Add(AcumuladoProceso.CosTotDif);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCostoMateriaPrima(LiberacionEN pLib, LiberacionProTer pLibProTer)
        {
            return Math.Round(pLib.CostoUnidadMasa * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoEnvasado(LiberacionEN pLib, LiberacionProTer pLibProTer)
        {
            return Math.Round(pLib.CostoUnidadConCal * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoManoObraEnvasado(LiberacionEN pLib, LiberacionProTer pLibProTer)
        {
            return Math.Round(pLib.CostoManoObra * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoCifVariableEnvasado(LiberacionEN pLib, LiberacionProTer pLibProTer)
        {
            return Math.Round(pLib.CostoCIFVariable * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoCifFijoEnvasado(LiberacionEN pLib, LiberacionProTer pLibProTer)
        {
            return Math.Round(pLib.CostoCIFFijo * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoCifVariableEncajado(ProduccionProTerEN pProProTer)
        {
            return Math.Round(pProProTer.CostoCIFVariable * pProProTer.CantidadUnidadesRealEncajado, 2);
        }

        public static decimal ObtenerCostoCifFijoEncajado(ProduccionProTerEN pProProTer)
        {
            return Math.Round(pProProTer.CostoCIFFijo * pProProTer.CantidadUnidadesRealEncajado, 2);
        }

        public static decimal ObtenerCostoMateriaPrima(LiberacionEN pLib, LoteRetiquetado pLibProTer)
        {
            return Math.Round(pLib.CostoUnidadMasa * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoEnvasado(LiberacionEN pLib, LoteRetiquetado pLibProTer)
        {
            return Math.Round(pLib.CostoUnidadConCal * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoManoObraEnvasado(LiberacionEN pLib, LoteRetiquetado pLibProTer)
        {
            return Math.Round(pLib.CostoManoObra * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoCifVariableEnvasado(LiberacionEN pLib, LoteRetiquetado pLibProTer)
        {
            return Math.Round(pLib.CostoCIFVariable * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoCifFijoEnvasado(LiberacionEN pLib, LoteRetiquetado pLibProTer)
        {
            return Math.Round(pLib.CostoCIFFijo * pLibProTer.Cantidad, 2);
        }

        public static decimal ObtenerCostoEmbalaje(RetiquetadoProTerEN pRetProTer)
        {
            return Math.Round(pRetProTer.CostoUnidadEmpaquetado * pRetProTer.CantidadRetiquetadoProTer, 2);
        }

        public static decimal ObtenerCostoManoObra(RetiquetadoProTerEN pRetProTer)
        {
            return Math.Round(pRetProTer.CostoManoObra * pRetProTer.CantidadRetiquetadoProTer, 2);
        }

        public static decimal ObtenerCostoCifVariable(RetiquetadoProTerEN pRetProTer)
        {
            return Math.Round(pRetProTer.CostoCIFVariable * pRetProTer.CantidadRetiquetadoProTer, 2);
        }

        public static decimal ObtenerCostoCifFijo(RetiquetadoProTerEN pRetProTer)
        {
            return Math.Round(pRetProTer.CostoCIFFijo * pRetProTer.CantidadRetiquetadoProTer, 2);
        }

        public static decimal ObtenerCostoCifVariableRetiquetado(RetiquetadoEN pProProTer)
        {
            return Math.Round(pProProTer.CostoCIFVariable * pProProTer.CantidadUnidadesRetiquetado, 2);
        }

        public static decimal ObtenerCostoCifFijoRetiquetado(RetiquetadoEN pProProTer)
        {
            return Math.Round(pProProTer.CostoCIFFijo * pProProTer.CantidadUnidadesRetiquetado, 2);
        }

        public static void ObtenerDiferenciaPptoReal(AcumuladoProceso pObj)
        {
            pObj.EnvasadoDif = pObj.EnvasadoPpto - pObj.EnvasadoRea;
            pObj.EncajadoDif = pObj.EncajadoPpto - pObj.EncajadoRea;
            pObj.RetiquetadoDif = pObj.RetiquetadoPpto - pObj.RetiquetadoRea;
            pObj.CostoTotalDif = pObj.CostoTotalPpto - pObj.CostoTotalRea;
        }

        public static List<CostoUnitarioProTer> ObtenerReporteCostoUnitarioPromedioAcumuladoActualizado(RetiquetadoEN pObj)
        {
            //lista resultado
            List<CostoUnitarioProTer> iLisRes = new List<CostoUnitarioProTer>();

            //-----------------------------
            //obtener reporte fase encajado
            //-----------------------------
            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //listar las liberaciones que intervienen en estas ProduccionesProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(iLisProProTer);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //obtener la lista LiberacionProTer de este xProProTer
                List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(xProProTer.DetalleCantidadesSemiProducto);

                //recorrer cada objeto LiberacionProTer
                foreach (LiberacionProTer xLibProTer in iLisLibProTer)
                {
                    //buscar a la liberacion este xLibProTer
                    LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                    //clonar al objeto xProProTer
                    CostoUnitarioProTer iCosProTerNew = new CostoUnitarioProTer();

                    //actualizar datos        
                    iCosProTerNew.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iCosProTerNew.TipoOperacion = "ENCAJADO";
                    iCosProTerNew.CorrelativoOperacion = xProProTer.CorrelativoEncajado;                                       
                    iCosProTerNew.FechaProTer = xProProTer.FechaEncajado;
                    iCosProTerNew.FechaLote = iLibBusEN.FechaProduccionDeta;
                    iCosProTerNew.CorrelativoProCab = iLibBusEN.CorrelativoProduccionCabe;
                    iCosProTerNew.CodigoExistencia = xProProTer.CodigoExistencia;
                    iCosProTerNew.DescripcionExistencia = xProProTer.DescripcionExistencia;
                    iCosProTerNew.UnidadesProducidas = iLibBusEN.UnidadesPasan;//las unidades que se encajaron de esta liberacion
                    iCosProTerNew.UnidadesRealesEncajadas = xProProTer.CantidadUnidadesRealEncajado;//unidades totales encajonadas de este proceso

                    //costos unitarios reales
                    iCosProTerNew.MateriaPrimaUnitario = iLibBusEN.CostoUnidadMasa ;//costo fase masa + costo reproceso unitario
                    iCosProTerNew.EnvaseUnitario = iLibBusEN.CostoUnidadConCal;//costo fase envasado
                    iCosProTerNew.EmbalajeUnitario = xProProTer.CostoUnidadEmpaquetado;
                    iCosProTerNew.EmbalajeUnitarioEncajado= xProProTer.CostoUnidadEmpaquetado;
                    iCosProTerNew.ManoObraUnitario = ProduccionProTerRN.ObtenerCostoManoObraUnitario(iLibBusEN, xProProTer);
                    iCosProTerNew.ManoObraUnitarioEnvasado = iLibBusEN.CostoManoObra;
                    iCosProTerNew.ManoObraUnitarioEncajado = xProProTer.CostoManoObra;                    
                    iCosProTerNew.CostoCifUnitario = ProduccionProTerRN.ObtenerCostoCifUnitario(iLibBusEN, xProProTer);
                    iCosProTerNew.CostoCifFijoUnitario = ProduccionProTerRN.ObtenerCostoCifFijoUnitario(iLibBusEN, xProProTer);
                    iCosProTerNew.CostoCifVariableUnitario = ProduccionProTerRN.ObtenerCostoCifVariableUnitario(iLibBusEN, xProProTer);
                    iCosProTerNew.CostoCifFijoUnitarioEnvasado = iLibBusEN.CostoCIFFijo;
                    iCosProTerNew.CostoCifVariableUnitarioEnvasado = iLibBusEN.CostoCIFVariable;
                    iCosProTerNew.CostoCifFijoUnitarioEncajado = xProProTer.CostoCIFFijo;
                    iCosProTerNew.CostoCifVariableUnitarioEncajado = xProProTer.CostoCIFVariable;
                    iCosProTerNew.CostoUnitario = ProduccionProTerRN.ObtenerCostoUnitario(iCosProTerNew);

                    //costos unitarios planificados
                    iCosProTerNew.MateriaPrimaUnitarioPlanificada = ProduccionDetaRN.ObtenerCostoMateriaPrimaUnidadTeorica(iLibBusEN);
                    iCosProTerNew.EnvaseUnitarioPlanificada = ProduccionDetaRN.ObtenerCostoEnvasadoUnidadTeorica(iLibBusEN);
                    iCosProTerNew.EmbalajeUnitarioPlanificada = ProduccionProTerRN.ObtenerCostoEncajadoUnidadTeorica(xProProTer);
                    iCosProTerNew.EmbalajeUnitarioEncajadoPlanificada = iCosProTerNew.EmbalajeUnitarioPlanificada;
                    iCosProTerNew.ManoObraUnitarioPlanificada = ProduccionProTerRN.ObtenerCostoManoObraUnitarioTeorico(iLibBusEN, xProProTer);
                    iCosProTerNew.ManoObraUnitarioEnvasadoPlanificada = ProduccionDetaRN.ObtenerCostoManoObraUnidadTeorica(iLibBusEN);
                    iCosProTerNew.ManoObraUnitarioEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoManoObraUnitarioTeorico(xProProTer);
                    iCosProTerNew.CostoCifUnitarioPlanificada = ProduccionProTerRN.ObtenerCostoCifUnitarioTeorico(iLibBusEN, xProProTer);
                    iCosProTerNew.CostoCifFijoUnitarioEnvasadoPlanificada = ProduccionDetaRN.ObtenerCostoCifFijoUnidadTeorica(iLibBusEN);
                    iCosProTerNew.CostoCifVariableUnitarioEnvasadoPlanificada = ProduccionDetaRN.ObtenerCostoCifVariableUnidadTeorica(iLibBusEN);
                    iCosProTerNew.CostoCifFijoUnitarioEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoCifFijoUnitarioTeorico(xProProTer);
                    iCosProTerNew.CostoCifVariableUnitarioEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoCifVariableUnitarioTeorico(xProProTer);

                    //costos totales reales
                    iCosProTerNew.MateriaPrima = ProduccionProTerRN.ObtenerCostoMateriaPrima(xLibProTer, iCosProTerNew);
                    iCosProTerNew.Envase = ProduccionProTerRN.ObtenerCostoEnvases(xLibProTer, iCosProTerNew);
                    iCosProTerNew.Embalaje = ProduccionProTerRN.ObtenerCostoEmbalajes(xLibProTer, iCosProTerNew);
                    iCosProTerNew.EmbalajeEncajado = iCosProTerNew.Embalaje;
                    iCosProTerNew.ManoObra = ProduccionProTerRN.ObtenerCostoManoObra(xLibProTer, iCosProTerNew);
                    iCosProTerNew.ManoObraEnvasado = ProduccionProTerRN.ObtenerCostoManoObraEnvasado( iCosProTerNew);
                    iCosProTerNew.ManoObraEncajado = ProduccionProTerRN.ObtenerCostoManoObraEncajado(iCosProTerNew);
                    iCosProTerNew.CostoCif = ProduccionProTerRN.ObtenerCostoCif(xLibProTer, iCosProTerNew);
                    iCosProTerNew.CostoCifFijo = ProduccionProTerRN.ObtenerCostoCifFijo(iCosProTerNew);
                    iCosProTerNew.CostoCifVariable = ProduccionProTerRN.ObtenerCostoCifVariable(iCosProTerNew);
                    iCosProTerNew.CostoCifFijoEnvasado = ProduccionProTerRN.ObtenerCostoCifFijoEnvasado(iCosProTerNew);
                    iCosProTerNew.CostoCifVariableEnvasado = ProduccionProTerRN.ObtenerCostoCifVariableEnvasado(iCosProTerNew);
                    iCosProTerNew.CostoCifFijoEncajado = ProduccionProTerRN.ObtenerCostoCifFijoEncajado(iCosProTerNew);
                    iCosProTerNew.CostoCifVariableEncajado = ProduccionProTerRN.ObtenerCostoCifVariableEncajado(iCosProTerNew);
                    iCosProTerNew.CostoTotal = ProduccionProTerRN.ObtenerCostoTotal(iCosProTerNew);

                    //costos totales planificados
                    iCosProTerNew.MateriaPrimaPlanificada = ProduccionProTerRN.ObtenerCostoMateriaPrimaPlanificada(iCosProTerNew);
                    iCosProTerNew.EnvasePlanificada = ProduccionProTerRN.ObtenerCostoEnvasesPlanificada(iCosProTerNew);
                    iCosProTerNew.EmbalajePlanificada = ProduccionProTerRN.ObtenerCostoEmbalajesPlanificada(iCosProTerNew);
                    iCosProTerNew.EmbalajeEncajadoPlanificada = iCosProTerNew.EmbalajePlanificada;
                    iCosProTerNew.ManoObraPlanificada = ProduccionProTerRN.ObtenerCostoManoObraPlanificada(iCosProTerNew);
                    iCosProTerNew.ManoObraEnvasadoPlanificada = ProduccionProTerRN.ObtenerCostoManoObraEnvasadoPlanificada(iCosProTerNew);
                    iCosProTerNew.ManoObraEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoManoObraEncajadoPlanificada(iCosProTerNew);
                    iCosProTerNew.CostoCifPlanificada = ProduccionProTerRN.ObtenerCostoCifPlanificada(iCosProTerNew);
                    //iCosProTerNew.CostoCifFijoPlanificada = ProduccionProTerRN.ObtenerCostoCifFijo(iCosProTerNew);
                    //iCosProTerNew.CostoCifVariablePlanificada = ProduccionProTerRN.ObtenerCostoCifVariable(iCosProTerNew);
                    iCosProTerNew.CostoCifFijoEnvasadoPlanificada = ProduccionProTerRN.ObtenerCostoCifFijoEnvasadoPlanificada(iCosProTerNew);
                    iCosProTerNew.CostoCifVariableEnvasadoPlanificada = ProduccionProTerRN.ObtenerCostoCifVariableEnvasadoPlanificada(iCosProTerNew);
                    iCosProTerNew.CostoCifFijoEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoCifFijoEncajadoPlanificada(iCosProTerNew);
                    iCosProTerNew.CostoCifVariableEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoCifVariableEncajadoPlanificada(iCosProTerNew);

                    //clave registro
                    iCosProTerNew.ClaveRegistro = iCosProTerNew.TipoOperacion + iCosProTerNew.CorrelativoOperacion + iCosProTerNew.CodigoExistencia;

                    //actualizar datos en caso no hay unidades encajadas
                    ActualizarCuandoUnidadesEncajadasEsCero(iCosProTerNew);

                    //agregar a la lista resultado
                    iLisRes.Add(iCosProTerNew);
                }
            }

            //--------------------------------
            //obtener reporte fase retiquetado
            //--------------------------------
            //traer la lista para el reporte
            List<RetiquetadoEN> iLisRet = RetiquetadoRN.ListarRetiquetadoParaReporteCostoLoteEtapaRetiquetado(pObj);

            //traer la lista para el reporte
            List<RetiquetadoProTerEN> iLisRetProTer = RetiquetadoProTerRN.ListarRetiquetadoProTerParaReporteCostoLoteEtapaRetiquetado(pObj);

            //listar las liberaciones que intervienen en estas ProduccionesProTer
            iLisLib = LiberacionRN.ListarLiberacionesUsadasEnRetiquetadosProTer(iLisRetProTer);

            //recorrer cada objeto
            foreach (RetiquetadoEN xRet in iLisRet)
            {
                //obtener la lista RetiquetadoProTer de este xRet
                List<RetiquetadoProTerEN> iLisRetProTerRet = ListaG.Filtrar<RetiquetadoProTerEN>(iLisRetProTer, RetiquetadoProTerEN.ClaRet, xRet.ClaveRetiquetado);

                //recorrer cada objeto
                foreach (RetiquetadoProTerEN xRetProTer in iLisRetProTerRet)
                {
                    //obtener los lotes de este retiquetado ProTer
                    List<LoteRetiquetado> iLisLotRet = RetiquetadoProTerRN.ConvertirCampoDetalleCantidadesLoteALista(xRetProTer.DetalleCantidadesLote);

                    //recorrer cada objeto LiberacionProTer
                    foreach (LoteRetiquetado xLotRet in iLisLotRet)
                    {
                        //buscar a la liberacion este xLibProTer
                        LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLotRet.ClaveLiberacion);

                        //clonar al objeto xProProTer
                        CostoUnitarioProTer iCosProTerNew = new CostoUnitarioProTer();

                        //actualizar datos        
                        iCosProTerNew.CodigoEmpresa = Universal.gCodigoEmpresa;
                        iCosProTerNew.TipoOperacion = "RETIQUETADO";
                        iCosProTerNew.CorrelativoOperacion = xRetProTer.CorrelativoRetiquetado;                                             
                        iCosProTerNew.FechaProTer = xRetProTer.FechaEncajado;
                        iCosProTerNew.FechaLote = iLibBusEN.FechaProduccionDeta;
                        iCosProTerNew.CorrelativoProCab = iLibBusEN.CorrelativoProduccionCabe;
                        iCosProTerNew.CodigoExistencia = xRet.CodigoExistenciaRE;
                        iCosProTerNew.DescripcionExistencia = xRet.DescripcionExistenciaRE;
                        iCosProTerNew.UnidadesProducidas = xLotRet.Cantidad;

                        //costos unitarios reales
                        iCosProTerNew.MateriaPrimaUnitario = iLibBusEN.CostoUnidadMasa;//costo fase masa + costo reproceso unitario
                        iCosProTerNew.EnvaseUnitario = iLibBusEN.CostoUnidadConCal;//costo fase envasado
                        iCosProTerNew.EmbalajeUnitario = ObtenerCostoEmbalajeUnitario(xRetProTer, xRet);
                        iCosProTerNew.EmbalajeUnitarioEncajado = xRetProTer.CostoUnidadEmpaquetado;
                        iCosProTerNew.EmbalajeUnitarioRetiquetado = xRet.CostoUnidadEmpaquetado;
                        iCosProTerNew.ManoObraUnitario = ObtenerCostoManoObraUnitario(iLibBusEN, xRetProTer, xRet);
                        iCosProTerNew.ManoObraUnitarioEnvasado = iLibBusEN.CostoManoObra;
                        iCosProTerNew.ManoObraUnitarioEncajado = xRetProTer.CostoManoObra;
                        iCosProTerNew.ManoObraUnitarioRetiquetado = xRet.CostoManoObra;
                        iCosProTerNew.CostoCifUnitario = ObtenerCostoCifUnitario(iLibBusEN, xRetProTer, xRet);
                        iCosProTerNew.CostoCifFijoUnitario = ObtenerCostoCifFijoUnitario(iLibBusEN, xRetProTer, xRet);
                        iCosProTerNew.CostoCifVariableUnitario = ObtenerCostoCifVariableUnitario(iLibBusEN, xRetProTer, xRet);
                        iCosProTerNew.CostoCifFijoUnitarioEnvasado = iLibBusEN.CostoCIFFijo;
                        iCosProTerNew.CostoCifVariableUnitarioEnvasado = iLibBusEN.CostoCIFVariable;
                        iCosProTerNew.CostoCifFijoUnitarioEncajado = xRetProTer.CostoCIFFijo;
                        iCosProTerNew.CostoCifVariableUnitarioEncajado = xRetProTer.CostoCIFVariable;
                        iCosProTerNew.CostoCifFijoUnitarioRetiquetado = xRet.CostoCIFFijo;
                        iCosProTerNew.CostoCifVariableUnitarioRetiquetado = xRet.CostoCIFVariable;
                        iCosProTerNew.CostoUnitario = ProduccionProTerRN.ObtenerCostoUnitario(iCosProTerNew);

                        //costos unitarios planificados
                        iCosProTerNew.MateriaPrimaUnitarioPlanificada = ProduccionDetaRN.ObtenerCostoMateriaPrimaUnidadTeorica(iLibBusEN);
                        iCosProTerNew.EnvaseUnitarioPlanificada = ProduccionDetaRN.ObtenerCostoEnvasadoUnidadTeorica(iLibBusEN);
                        iCosProTerNew.EmbalajeUnitarioPlanificada = ObtenerCostoEncajadoUnidadTeorica(xRetProTer,xRet);
                        iCosProTerNew.EmbalajeUnitarioEncajadoPlanificada = ObtenerCostoEncajadoUnidadEncajadoTeorica(xRetProTer);
                        iCosProTerNew.EmbalajeUnitarioRetiquetadoPlanificada = ObtenerCostoEncajadoUnidadRetiquetadoTeorica(xRet);
                        iCosProTerNew.ManoObraUnitarioPlanificada = ObtenerCostoManoObraUnitarioTeorico(iLibBusEN, xRetProTer, xRet);
                        iCosProTerNew.ManoObraUnitarioEnvasadoPlanificada = ProduccionDetaRN.ObtenerCostoManoObraUnidadTeorica(iLibBusEN);
                        iCosProTerNew.ManoObraUnitarioEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoManoObraUnitarioTeorico(xRetProTer);
                        iCosProTerNew.ManoObraUnitarioRetiquetadoPlanificada = ObtenerCostoManoObraUnidadRetiquetadoTeorica(xRet);
                        iCosProTerNew.CostoCifUnitarioPlanificada = ObtenerCostoCifUnitarioTeorico(iLibBusEN, xRetProTer, xRet);
                        iCosProTerNew.CostoCifFijoUnitarioEncajado = ObtenerCostoCifFijoUnitarioTeorico(iLibBusEN, xRetProTer, xRet);
                        iCosProTerNew.CostoCifVariableUnitarioEncajado = ObtenerCostoCifVariableUnitarioTeorico(iLibBusEN, xRetProTer, xRet);
                        iCosProTerNew.CostoCifFijoUnitarioEnvasadoPlanificada = ProduccionDetaRN.ObtenerCostoCifFijoUnidadTeorica(iLibBusEN);
                        iCosProTerNew.CostoCifVariableUnitarioEnvasadoPlanificada = ProduccionDetaRN.ObtenerCostoCifVariableUnidadTeorica(iLibBusEN);
                        iCosProTerNew.CostoCifFijoUnitarioEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoCifFijoUnitarioTeorico(xRetProTer);
                        iCosProTerNew.CostoCifVariableUnitarioEncajadoPlanificada = ProduccionProTerRN.ObtenerCostoCifVariableUnitarioTeorico(xRetProTer);
                        iCosProTerNew.CostoCifFijoUnitarioRetiquetadoPlanificada = ObtenerCostoCifFijoUnitarioTeorico(xRet);
                        iCosProTerNew.CostoCifVariableUnitarioRetiquetadoPlanificada = ObtenerCostoCifVariableUnitarioTeorico(xRet);
                        
                        //costos totales reales                        
                        iCosProTerNew.MateriaPrima = ObtenerCostoMateriaPrima( iCosProTerNew);
                        iCosProTerNew.Envase = ObtenerCostoEnvases(iCosProTerNew);
                        iCosProTerNew.Embalaje = ObtenerCostoEmbalaje(iCosProTerNew);
                        iCosProTerNew.EmbalajeEncajado = ObtenerCostoEmbalajeEncajado(iCosProTerNew);
                        iCosProTerNew.EmbalajeRetiquetado = ObtenerCostoEmbalajeRetiquetado(iCosProTerNew);
                        iCosProTerNew.ManoObra = ObtenerCostoManoObra(iCosProTerNew);
                        iCosProTerNew.ManoObraEnvasado = ObtenerCostoManoObraEnvasado(iCosProTerNew);
                        iCosProTerNew.ManoObraEncajado = ObtenerCostoManoObraEncajado(iCosProTerNew);
                        iCosProTerNew.ManoObraRetiquetado = ObtenerCostoManoObraRetiquetado(iCosProTerNew);
                        iCosProTerNew.CostoCif = ObtenerCostoCif(iCosProTerNew);
                        iCosProTerNew.CostoCifFijo = ObtenerCostoCifFijo(iCosProTerNew);
                        iCosProTerNew.CostoCifVariable = ObtenerCostoCifVariable(iCosProTerNew);
                        iCosProTerNew.CostoCifFijoEnvasado = ObtenerCostoCifFijoEnvasado(iCosProTerNew);
                        iCosProTerNew.CostoCifVariableEnvasado = ObtenerCostoCifVariableEnvasado(iCosProTerNew);
                        iCosProTerNew.CostoCifFijoEncajado = ObtenerCostoCifFijoEncajado(iCosProTerNew);
                        iCosProTerNew.CostoCifVariableEncajado = ObtenerCostoCifVariableEncajado(iCosProTerNew);
                        iCosProTerNew.CostoCifFijoRetiquetado = ObtenerCostoCifFijoRetiquetado(iCosProTerNew);
                        iCosProTerNew.CostoCifVariableRetiquetado = ObtenerCostoCifVariableRetiquetado(iCosProTerNew);
                        iCosProTerNew.CostoTotal = ProduccionProTerRN.ObtenerCostoTotal(iCosProTerNew);

                        //costos totales planificados
                        iCosProTerNew.MateriaPrima = ObtenerCostoMateriaPrimaPlanificada(iCosProTerNew);
                        iCosProTerNew.Envase = ObtenerCostoEnvasesPlanificada(iCosProTerNew);
                        iCosProTerNew.Embalaje = ObtenerCostoEmbalajePlanificada(iCosProTerNew);
                        iCosProTerNew.EmbalajeEncajado = ObtenerCostoEmbalajeEncajadoPlanificada(iCosProTerNew);
                        iCosProTerNew.EmbalajeRetiquetado = ObtenerCostoEmbalajeRetiquetadoPlanificada(iCosProTerNew);
                        iCosProTerNew.ManoObra = ObtenerCostoManoObraPlanificada(iCosProTerNew);
                        iCosProTerNew.ManoObraEnvasado = ObtenerCostoManoObraEnvasadoPlanificada(iCosProTerNew);
                        iCosProTerNew.ManoObraEncajado = ObtenerCostoManoObraEncajadoPlanificada(iCosProTerNew);
                        iCosProTerNew.ManoObraRetiquetado = ObtenerCostoManoObraRetiquetadoPlanificada(iCosProTerNew);
                        iCosProTerNew.CostoCif = ObtenerCostoCifPlanificada(iCosProTerNew);
                        iCosProTerNew.CostoCifFijo = ObtenerCostoCifFijo(iCosProTerNew);
                        iCosProTerNew.CostoCifVariable = ObtenerCostoCifVariable(iCosProTerNew);
                        iCosProTerNew.CostoCifFijoEnvasadoPlanificada = ObtenerCostoCifFijoEnvasadoPlanificada(iCosProTerNew);
                        iCosProTerNew.CostoCifVariableEnvasadoPlanificada = ObtenerCostoCifVariableEnvasadoPlanificada(iCosProTerNew);
                        iCosProTerNew.CostoCifFijoEncajadoPlanificada = ObtenerCostoCifFijoEncajadoPlanificada(iCosProTerNew);
                        iCosProTerNew.CostoCifVariableEncajadoPlanificada = ObtenerCostoCifVariableEncajadoPlanificada(iCosProTerNew);
                        iCosProTerNew.CostoCifFijoRetiquetadoPlanificada = ObtenerCostoCifFijoRetiquetadoPlanificada(iCosProTerNew);
                        iCosProTerNew.CostoCifVariableRetiquetadoPlanificada = ObtenerCostoCifVariableRetiquetadoPlanificada(iCosProTerNew);
                        iCosProTerNew.CostoTotal = ProduccionProTerRN.ObtenerCostoTotal(iCosProTerNew);

                        //clave registro
                        iCosProTerNew.ClaveRegistro = iCosProTerNew.TipoOperacion + iCosProTerNew.CorrelativoOperacion + iCosProTerNew.CodigoExistencia;

                        //actualizar datos en caso no hay unidades encajadas
                        ActualizarCuandoUnidadesEncajadasEsCero(iCosProTerNew);

                        //agregar a la lista resultado
                        iLisRes.Add(iCosProTerNew);                        
                    }
                }
            }

            ////obtener objeto totales
            CostoUnitarioProTer iCosProTerTot = ProduccionProTerRN.ObtenerObjetoTotalesReporteCostoUnitarioPromedioAcumuladoActualizado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iCosProTerTot);

            //devolver
            return iLisRes;
        }
        
        public static decimal ObtenerCostoCifFijoEnvasado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioEnvasado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoEnvasadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioEnvasadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableEnvasado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioEnvasado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableEnvasadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioEnvasadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoEncajado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioEncajado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoEncajadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioEncajadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableEncajado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioEncajado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableEncajadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioEncajadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoRetiquetado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioRetiquetado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoRetiquetadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioRetiquetadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableRetiquetado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioRetiquetado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableRetiquetadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioRetiquetadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijo(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }
        
        public static decimal ObtenerCostoCifVariable(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }
        
        public static decimal ObtenerCostoManoObraEnvasado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioEnvasado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraEnvasadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioEnvasadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraEncajado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioEncajado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraEncajadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioEncajadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraRetiquetado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioRetiquetado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraRetiquetadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioRetiquetadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEmbalajeEncajado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EmbalajeUnitarioEncajado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEmbalajeEncajadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EmbalajeUnitarioEncajadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEmbalajeRetiquetado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EmbalajeUnitarioRetiquetado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEmbalajeRetiquetadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EmbalajeUnitarioRetiquetadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEmbalaje(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EmbalajeUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEmbalajePlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EmbalajeUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifUnitarioTeorico(LiberacionEN pLib, RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            return ObtenerCostoCifFijoUnitarioTeorico(pLib,pRetProTer,pRet) +
                ObtenerCostoCifVariableUnitarioTeorico(pLib, pRetProTer, pRet);
        }

        public static decimal ObtenerCostoCifFijoUnitarioTeorico(LiberacionEN pLib, RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            return ProduccionDetaRN.ObtenerCostoCifFijoUnidadTeorica(pLib) +
                ProduccionProTerRN.ObtenerCostoCifFijoUnitarioTeorico(pRetProTer) +
                ObtenerCostoCifFijoUnitarioTeorico(pRet);
        }

        public static decimal ObtenerCostoCifVariableUnitarioTeorico(LiberacionEN pLib, RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            return ProduccionDetaRN.ObtenerCostoCifVariableUnidadTeorica(pLib) +
                ProduccionProTerRN.ObtenerCostoCifVariableUnitarioTeorico(pRetProTer) +
                ObtenerCostoCifVariableUnitarioTeorico(pRet);
        }

        public static decimal ObtenerCostoCifFijoUnitarioTeorico(RetiquetadoEN pRetProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = (pRetProTer.CostoCIFFijo) * pRetProTer.CantidadUnidadesRetiquetado;
            iValor = Operador.DivisionDecimal(iValor, pRetProTer.CantidadUnidadesRetiquetado);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifVariableUnitarioTeorico(RetiquetadoEN pRetProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = (pRetProTer.CostoCIFVariable) * pRetProTer.CantidadUnidadesRetiquetado;
            iValor = Operador.DivisionDecimal(iValor, pRetProTer.CantidadUnidadesRetiquetado);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoManoObraUnitarioTeorico(LiberacionEN pLib, RetiquetadoProTerEN pRetProTer,RetiquetadoEN pRet)
        {
            return ProduccionDetaRN.ObtenerCostoManoObraUnidadTeorica(pLib) + 
                ProduccionProTerRN.ObtenerCostoManoObraUnitarioTeorico(pRetProTer)+
                ObtenerCostoManoObraUnidadRetiquetadoTeorica(pRet);
        }

        public static decimal ObtenerCostoEncajadoUnidadEncajadoTeorica(RetiquetadoProTerEN pObj)
        {
            //calcular                     
            decimal iCostoUnidad = Math.Round(Operador.DivisionDecimal(pObj.CostoEmpaquetadoPrincipal, pObj.CantidadUnidadesProTer), 2);

            //devolver
            return iCostoUnidad;
        }

        public static decimal ObtenerCostoEncajadoUnidadRetiquetadoTeorica(RetiquetadoEN pObj)
        {
            //calcular                     
            decimal iCostoUnidad = Math.Round(Operador.DivisionDecimal(pObj.CostoEmpaquetadoPrincipal, pObj.CantidadUnidadesRetiquetado), 2);

            //devolver
            return iCostoUnidad;
        }

        public static decimal ObtenerCostoManoObraUnidadRetiquetadoTeorica(RetiquetadoEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = pObj.CostoManoObra * pObj.CantidadUnidadesRetiquetado;
            iValor = Operador.DivisionDecimal(iValor, pObj.CantidadUnidadesRetiquetado);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoEncajadoUnidadTeorica(RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            //devolver
            return ObtenerCostoEncajadoUnidadEncajadoTeorica(pRetProTer) + ObtenerCostoEncajadoUnidadRetiquetadoTeorica(pRet);
        }

        public static void ActualizarCuandoUnidadesEncajadasEsCero(CostoUnitarioProTer pCosUniProTer)
        {
            if (pCosUniProTer.UnidadesProducidas == 0)
            {
                pCosUniProTer.MateriaPrimaUnitario = 0;
                pCosUniProTer.EnvaseUnitario = 0;
                pCosUniProTer.EmbalajeUnitario = 0;
                pCosUniProTer.ManoObraUnitario = 0;
                pCosUniProTer.CostoCifUnitario = 0;
                pCosUniProTer.CostoUnitario = 0;
                pCosUniProTer.MateriaPrima = 0;
                pCosUniProTer.Envase = 0;
                pCosUniProTer.ManoObra = 0;
                pCosUniProTer.CostoCif = 0;
                pCosUniProTer.CostoTotal = 0;
                pCosUniProTer.CostoCifFijoUnitario = 0;
                pCosUniProTer.CostoCifVariableUnitario = 0;
            }
        }

        public static decimal ObtenerCostoEmbalajeUnitario(RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            return pRetProTer.CostoUnidadEmpaquetado + pRet.CostoUnidadEmpaquetado;
        }

        public static decimal ObtenerCostoManoObraUnitario(LiberacionEN pLib, RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            return pLib.CostoManoObra + pRetProTer.CostoManoObra + pRet.CostoManoObra;
        }

        public static decimal ObtenerCostoCifUnitario(LiberacionEN pLib, RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            return pLib.CostoCIFFijo + pLib.CostoCIFVariable + pRetProTer.CostoCIFFijo+ pRetProTer.CostoCIFVariable + pRet.CostoCIFFijo + pRet.CostoCIFVariable;
        }

        public static decimal ObtenerCostoManoObra(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEnvases(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EnvaseUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEnvasesPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EnvaseUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoMateriaPrima( CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.MateriaPrimaUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoMateriaPrimaPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.MateriaPrimaUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCif(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static List<CostoUnitarioProTer> ObtenerReporteCostoUnitarioPorFechasActualizado(RetiquetadoEN pObj)
        {
            //lista resultado
            List<CostoUnitarioProTer> iLisRes = new List<CostoUnitarioProTer>();

            //obtenemos el reporte detallado por liberaciones
            List<CostoUnitarioProTer> iLisCosUni = ObtenerReporteCostoUnitarioPromedioAcumuladoActualizado(pObj);

            //quitamos al ultimo objeto de esta lista que es el de totales
            iLisCosUni.RemoveAt(iLisCosUni.Count - 1);

            //obtener listas de listas por ClaveRegistro
            List<List<CostoUnitarioProTer>> iLisLisCosUni = ListaG.ListarListas<CostoUnitarioProTer>(iLisCosUni, CostoUnitarioProTer.ClaReg);

            //recorrer cada lista
            foreach (List<CostoUnitarioProTer> xLisCosUni in iLisLisCosUni)
            {
                //obtenemos al primer objeto de esta lista
                CostoUnitarioProTer iCosUni = xLisCosUni[0];

                //creamos un nuevo objeto costoUnitarioProTer
                CostoUnitarioProTer iCosProTerNew = new CostoUnitarioProTer();

                //actualizar datos   
                iCosProTerNew.CodigoEmpresa = iCosUni.CodigoEmpresa;
                iCosProTerNew.TipoOperacion = iCosUni.TipoOperacion;
                iCosProTerNew.CorrelativoOperacion = iCosUni.CorrelativoOperacion;
                iCosProTerNew.ClaveRegistro = iCosUni.ClaveRegistro;
                iCosProTerNew.FechaProTer = iCosUni.FechaProTer;
                iCosProTerNew.FechaLote = ListaG.ArmarCadenaDeValores<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.FecLot, ",");
                iCosProTerNew.CorrelativoProCab = iCosUni.CorrelativoProCab;
                iCosProTerNew.CodigoExistencia = iCosUni.CodigoExistencia;
                iCosProTerNew.DescripcionExistencia = iCosUni.DescripcionExistencia;
                iCosProTerNew.UnidadesProducidas = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.UniPro);

                //costos unitarios reales
                iCosProTerNew.MateriaPrimaUnitario = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.MatPriUni,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.EnvaseUnitario = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EnvUni,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.EmbalajeUnitario = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbUni,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.EmbalajeUnitarioEncajado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbUniEnc,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.EmbalajeUnitarioRetiquetado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbUniRet,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.ManoObraUnitario = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrUni,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.ManoObraUnitarioEnvasado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrUniEnv,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.ManoObraUnitarioEncajado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrUniEnc,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.ManoObraUnitarioRetiquetado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrUniRet,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifUnitario = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifUni,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifFijoUnitarioEnvasado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijUniEnv,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifVariableUnitarioEnvasado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarUniEnv,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifFijoUnitarioEncajado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijUniEnc,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifVariableUnitarioEncajado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarUniEnc,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifFijoUnitarioRetiquetado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijUniRet,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifVariableUnitarioRetiquetado = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarUniRet,
                    CostoUnitarioProTer.UniPro, 6);

                //costos unitarios planificados
                iCosProTerNew.MateriaPrimaUnitarioPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.MatPriUniPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.EnvaseUnitarioPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EnvUniPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.EmbalajeUnitarioPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbUniPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.EmbalajeUnitarioEncajadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbUniEncPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.EmbalajeUnitarioRetiquetadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbUniRetPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.ManoObraUnitarioPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrUniPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.ManoObraUnitarioEnvasadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrUniEnvPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.ManoObraUnitarioEncajadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrUniEncPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.ManoObraUnitarioRetiquetadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrUniRetPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifUnitarioPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifUniPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifFijoUnitarioEnvasadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijUniEnvPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifVariableUnitarioEnvasadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarUniEnvPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifFijoUnitarioEncajadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijUniEncPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifVariableUnitarioEncajadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarUniEncPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifFijoUnitarioRetiquetadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijUniRetPla,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifVariableUnitarioRetiquetadoPlanificada = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarUniRetPla,
                    CostoUnitarioProTer.UniPro, 6);                
                iCosProTerNew.CostoUnitario = ProduccionProTerRN.ObtenerCostoUnitario(iCosProTerNew);

                //costos totales reales
                iCosProTerNew.MateriaPrima = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.MatPri);
                iCosProTerNew.Envase = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.Env);
                iCosProTerNew.Embalaje = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.Emb);
                iCosProTerNew.EmbalajeEncajado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbEnc);
                iCosProTerNew.EmbalajeRetiquetado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbRet);
                iCosProTerNew.ManoObra = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObr);
                iCosProTerNew.ManoObraEnvasado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrEnv);
                iCosProTerNew.ManoObraEncajado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrEnc);
                iCosProTerNew.ManoObraRetiquetado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrRet);
                iCosProTerNew.CostoCif = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCif);
                iCosProTerNew.CostoCifFijoEnvasado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijEnv);
                iCosProTerNew.CostoCifVariableEnvasado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarEnv);
                iCosProTerNew.CostoCifFijoEncajado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijEnc);
                iCosProTerNew.CostoCifVariableEncajado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarEnc);
                iCosProTerNew.CostoCifFijoRetiquetado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijRet);
                iCosProTerNew.CostoCifVariableRetiquetado = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarRet);

                //costos totales reales
                iCosProTerNew.MateriaPrimaPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.MatPriPla);
                iCosProTerNew.EnvasePlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EnvPla);
                iCosProTerNew.EmbalajePlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbPla);
                iCosProTerNew.EmbalajeEncajadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbEncPla);
                iCosProTerNew.EmbalajeRetiquetadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.EmbRetPla);
                iCosProTerNew.ManoObraPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrPla);
                iCosProTerNew.ManoObraEnvasadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrEnvPla);
                iCosProTerNew.ManoObraEncajadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrEncPla);
                iCosProTerNew.ManoObraRetiquetadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.ManObrRetPla);
                iCosProTerNew.CostoCifPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifPla);
                iCosProTerNew.CostoCifFijoEnvasadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijEnvPla);
                iCosProTerNew.CostoCifVariableEnvasadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarEnvPla);
                iCosProTerNew.CostoCifFijoEncajadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijEncPla);
                iCosProTerNew.CostoCifVariableEncajadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarEncPla);
                iCosProTerNew.CostoCifFijoRetiquetadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijRetPla);
                iCosProTerNew.CostoCifVariableRetiquetadoPlanificada = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarRetPla);

                //agregar a la lista resultado
                iLisRes.Add(iCosProTerNew);
            }

            //obtener objeto totales
            CostoUnitarioProTer iCosProTerTot = ObtenerObjetoTotalesReporteCostoUnitarioPorFechasActualizado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iCosProTerTot);

            //devolver
            return iLisRes;
        }

        public static CostoUnitarioProTer ObtenerObjetoTotalesReporteCostoUnitarioPorFechasActualizado(List<CostoUnitarioProTer> pLista)
        {
            //objeto resultado
            CostoUnitarioProTer iProProTerEN = new CostoUnitarioProTer();

            //obtener la lista acumulada de pLista            
            List<CostoUnitarioProTer> iLisProProTerAcu = ListaG.Acumular<CostoUnitarioProTer>(pLista, CostoUnitarioProTer.CodEmp,
                ObtenerListaCamposAAcumularReporteCostoUnitarioPorFechasActualizado());

            //si la lista esta vacia
            if (iLisProProTerAcu.Count != 0)
            {
                iProProTerEN = ObjetoG.Clonar<CostoUnitarioProTer>(iLisProProTerAcu[0]);
            }

            //actualizar datos a este objeto   
            iProProTerEN.TipoOperacion = string.Empty;
            iProProTerEN.CorrelativoOperacion = string.Empty;
            iProProTerEN.FechaProTer = string.Empty;
            iProProTerEN.FechaLote = string.Empty;
            iProProTerEN.CorrelativoProCab = string.Empty;
            iProProTerEN.CodigoExistencia = string.Empty;
            iProProTerEN.DescripcionExistencia = string.Empty;
            iProProTerEN.FechaLote = "TOTALES";

            //devolver
            return iProProTerEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostoUnitarioPorFechasActualizado()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(CostoUnitarioProTer.UniPro);
            iLisRes.Add(CostoUnitarioProTer.MatPriUni);
            iLisRes.Add(CostoUnitarioProTer.EnvUni);
            iLisRes.Add(CostoUnitarioProTer.EmbUni);
            iLisRes.Add(CostoUnitarioProTer.ManObrUni);
            iLisRes.Add(CostoUnitarioProTer.CosCifUni);
            iLisRes.Add(CostoUnitarioProTer.CosUni);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCostoCifFijoUnitario(LiberacionEN pLib, RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            return pLib.CostoCIFFijo + pRetProTer.CostoCIFFijo + pRet.CostoCIFFijo;
        }

        public static decimal ObtenerCostoCifVariableUnitario(LiberacionEN pLib, RetiquetadoProTerEN pRetProTer, RetiquetadoEN pRet)
        {
            return  pLib.CostoCIFVariable + pRetProTer.CostoCIFVariable+ pRet.CostoCIFVariable;
        }

        public static List<CostoUnitarioProTer> ObtenerReporteCostoUnitarioVariabilidadCostosActualizado(RetiquetadoEN pObj)
        {
            //lista resultado
            List<CostoUnitarioProTer> iLisRes = new List<CostoUnitarioProTer>();

            //obtenemos el reporte detallado por liberaciones
            List<CostoUnitarioProTer> iLisCosUni = ObtenerReporteCostoUnitarioPromedioAcumuladoActualizado(pObj);

            //quitamos al ultimo objeto de esta lista que es el de totales
            iLisCosUni.RemoveAt(iLisCosUni.Count - 1);

            //obtener listas de listas por ClaveRegistro
            List<List<CostoUnitarioProTer>> iLisLisCosUni = ListaG.ListarListas<CostoUnitarioProTer>(iLisCosUni, CostoUnitarioProTer.ClaReg);

            //recorrer cada lista
            foreach (List<CostoUnitarioProTer> xLisCosUni in iLisLisCosUni)
            {
                //obtenemos al primer objeto de esta lista
                CostoUnitarioProTer iCosUni = xLisCosUni[0];

                //creamos un nuevo objeto costoUnitarioProTer
                CostoUnitarioProTer iCosProTerNew = new CostoUnitarioProTer();

                //actualizar datos   
                iCosProTerNew.CodigoEmpresa = iCosUni.CodigoEmpresa;
                iCosProTerNew.TipoOperacion = iCosUni.TipoOperacion;
                iCosProTerNew.CorrelativoOperacion = iCosUni.CorrelativoOperacion;
                iCosProTerNew.ClaveRegistro = iCosUni.ClaveRegistro;
                iCosProTerNew.FechaProTer = iCosUni.FechaProTer;
                iCosProTerNew.FechaLote = ListaG.ArmarCadenaDeValores<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.FecLot, ",");
                iCosProTerNew.CorrelativoProCab = iCosUni.CorrelativoProCab;
                iCosProTerNew.CodigoExistencia = iCosUni.CodigoExistencia;
                iCosProTerNew.DescripcionExistencia = iCosUni.DescripcionExistencia;
                iCosProTerNew.UnidadesProducidas = ListaG.Sumar<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.UniPro);                
                iCosProTerNew.CostoCifFijoUnitario = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifFijUni,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoCifVariableUnitario = ListaG.CalcularPromedioPonderado<CostoUnitarioProTer>(xLisCosUni, CostoUnitarioProTer.CosCifVarUni,
                    CostoUnitarioProTer.UniPro, 6);
                iCosProTerNew.CostoUnitario = ProduccionProTerRN.ObtenerCostoCifUnitario(iCosProTerNew);

                //agregar a la lista resultado
                iLisRes.Add(iCosProTerNew);
            }

            //obtener objeto totales
            CostoUnitarioProTer iCosProTerTot = ObtenerObjetoTotalesReporteCostoUnitarioVariabilidadCostosActualizado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iCosProTerTot);

            //devolver
            return iLisRes;
        }

        public static CostoUnitarioProTer ObtenerObjetoTotalesReporteCostoUnitarioVariabilidadCostosActualizado(List<CostoUnitarioProTer> pLista)
        {
            //objeto resultado
            CostoUnitarioProTer iProProTerEN = new CostoUnitarioProTer();

            //obtener la lista acumulada de pLista            
            List<CostoUnitarioProTer> iLisProProTerAcu = ListaG.Acumular<CostoUnitarioProTer>(pLista, CostoUnitarioProTer.CodEmp,
                ObtenerListaCamposAAcumularReporteCostoUnitarioVariabilidadCostosActualizado());

            //si la lista esta vacia
            if (iLisProProTerAcu.Count != 0)
            {
                iProProTerEN = ObjetoG.Clonar<CostoUnitarioProTer>(iLisProProTerAcu[0]);
            }

            //actualizar datos a este objeto   
            iProProTerEN.TipoOperacion = string.Empty;
            iProProTerEN.CorrelativoOperacion = string.Empty;
            iProProTerEN.FechaProTer = string.Empty;
            iProProTerEN.FechaLote = string.Empty;
            iProProTerEN.CorrelativoProCab = string.Empty;
            iProProTerEN.CodigoExistencia = string.Empty;
            iProProTerEN.DescripcionExistencia = string.Empty;
            iProProTerEN.FechaLote = "TOTALES";

            //devolver
            return iProProTerEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostoUnitarioVariabilidadCostosActualizado()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(CostoUnitarioProTer.UniPro);            
            iLisRes.Add(CostoUnitarioProTer.CosCifFijUni);
            iLisRes.Add(CostoUnitarioProTer.CosCifVarUni);
            iLisRes.Add(CostoUnitarioProTer.CosUni);

            //devolver
            return iLisRes;
        }
        
        public static List<VersusCosto> ObtenerReportePresupuestadoVsRealPorFechasActualizado(RetiquetadoEN pObj)
        {
            //lista resultado
            List<VersusCosto> iLisRes = new List<VersusCosto>();

            //obtenemos el reporte detallado por liberaciones
            List<CostoUnitarioProTer> iLisCosUni = ObtenerReporteCostoUnitarioPorFechasActualizado(pObj);

            //quitamos al ultimo objeto de esta lista que es el de totales
            iLisCosUni.RemoveAt(iLisCosUni.Count - 1);

            //acumular costos            
            iLisCosUni = ListaG.Acumular<CostoUnitarioProTer>(iLisCosUni, CostoUnitarioProTer.CodExi, ObtenerListaCamposAcumulaReportePresupuestadoVsReal());

            //recorrer cada lista
            foreach (CostoUnitarioProTer xCosUni in iLisCosUni)
            {
                //objeto raiz
                VersusCosto iVerCos;

                //crear objeto versus (materia prima)
                iVerCos = new VersusCosto();
                iVerCos.CodigoEmpresa = xCosUni.CodigoEmpresa;
                iVerCos.TipoOperacion = xCosUni.TipoOperacion;
                iVerCos.CorrelativoOperacion = xCosUni.CorrelativoOperacion;
                iVerCos.ClaveRegistro = xCosUni.ClaveRegistro;
                iVerCos.FechaProTer = xCosUni.FechaProTer;
                iVerCos.CodigoExistencia = xCosUni.CodigoExistencia;
                iVerCos.Elemento = "MATERIA PRIMA";
                iVerCos.Presupuestado = xCosUni.MateriaPrimaPlanificada;                   
                iVerCos.Real = xCosUni.MateriaPrima;
                iVerCos.Diferencia = ProduccionProTerRN.ObtenerDiferenciaVersus(iVerCos);
                iVerCos.Porcentaje = ProduccionProTerRN.ObtenerPorcentajeVersus(iVerCos);
                iLisRes.Add(iVerCos);

                //crear objeto versus (Envase)
                iVerCos = new VersusCosto();
                iVerCos.CodigoEmpresa = xCosUni.CodigoEmpresa;
                iVerCos.TipoOperacion = xCosUni.TipoOperacion;
                iVerCos.CorrelativoOperacion = xCosUni.CorrelativoOperacion;
                iVerCos.ClaveRegistro = xCosUni.ClaveRegistro;
                iVerCos.FechaProTer = xCosUni.FechaProTer;
                iVerCos.CodigoExistencia = xCosUni.CodigoExistencia;
                iVerCos.Elemento = "ENVASES";
                iVerCos.Presupuestado = xCosUni.EnvasePlanificada;
                iVerCos.Real = xCosUni.Envase;
                iVerCos.Diferencia = ProduccionProTerRN.ObtenerDiferenciaVersus(iVerCos);
                iVerCos.Porcentaje = ProduccionProTerRN.ObtenerPorcentajeVersus(iVerCos);
                iLisRes.Add(iVerCos);

                //crear objeto versus (Embalajes)
                iVerCos = new VersusCosto();
                iVerCos.CodigoEmpresa = xCosUni.CodigoEmpresa;
                iVerCos.TipoOperacion = xCosUni.TipoOperacion;
                iVerCos.CorrelativoOperacion = xCosUni.CorrelativoOperacion;
                iVerCos.ClaveRegistro = xCosUni.ClaveRegistro;
                iVerCos.FechaProTer = xCosUni.FechaProTer;
                iVerCos.CodigoExistencia = xCosUni.CodigoExistencia;
                iVerCos.Elemento = "EMBALAJES";
                iVerCos.Presupuestado = xCosUni.EmbalajePlanificada;
                iVerCos.Real = xCosUni.Embalaje;
                iVerCos.Diferencia = ProduccionProTerRN.ObtenerDiferenciaVersus(iVerCos);
                iVerCos.Porcentaje = ProduccionProTerRN.ObtenerPorcentajeVersus(iVerCos);
                iLisRes.Add(iVerCos);

                //crear objeto versus (Mano de Obra)
                iVerCos = new VersusCosto();
                iVerCos.CodigoEmpresa = xCosUni.CodigoEmpresa;
                iVerCos.TipoOperacion = xCosUni.TipoOperacion;
                iVerCos.CorrelativoOperacion = xCosUni.CorrelativoOperacion;
                iVerCos.ClaveRegistro = xCosUni.ClaveRegistro;
                iVerCos.FechaProTer = xCosUni.FechaProTer;
                iVerCos.CodigoExistencia = xCosUni.CodigoExistencia;
                iVerCos.Elemento = "MANO DE OBRA";
                iVerCos.Presupuestado = xCosUni.ManoObraPlanificada;
                iVerCos.Real = xCosUni.ManoObra;
                iVerCos.Diferencia = ProduccionProTerRN.ObtenerDiferenciaVersus(iVerCos);
                iVerCos.Porcentaje = ProduccionProTerRN.ObtenerPorcentajeVersus(iVerCos);
                iLisRes.Add(iVerCos);

                //crear objeto versus (Cif)
                iVerCos = new VersusCosto();
                iVerCos.CodigoEmpresa = xCosUni.CodigoEmpresa;
                iVerCos.TipoOperacion = xCosUni.TipoOperacion;
                iVerCos.CorrelativoOperacion = xCosUni.CorrelativoOperacion;
                iVerCos.ClaveRegistro = xCosUni.ClaveRegistro;
                iVerCos.FechaProTer = xCosUni.FechaProTer;
                iVerCos.CodigoExistencia = xCosUni.CodigoExistencia;
                iVerCos.Elemento = "CIF";
                iVerCos.Presupuestado = xCosUni.CostoCifPlanificada;
                iVerCos.Real = xCosUni.CostoCif;
                iVerCos.Diferencia = ProduccionProTerRN.ObtenerDiferenciaVersus(iVerCos);
                iVerCos.Porcentaje = ProduccionProTerRN.ObtenerPorcentajeVersus(iVerCos);
                iLisRes.Add(iVerCos);
            }

            //devolver
            return iLisRes;
        }

        public static List<string> ObtenerListaCamposAcumulaReportePresupuestadoVsReal()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(CostoUnitarioProTer.MatPriPla);
            iLisRes.Add(CostoUnitarioProTer.MatPri);
            iLisRes.Add(CostoUnitarioProTer.EnvPla);
            iLisRes.Add(CostoUnitarioProTer.Env);
            iLisRes.Add(CostoUnitarioProTer.EmbPla);
            iLisRes.Add(CostoUnitarioProTer.Emb);
            iLisRes.Add(CostoUnitarioProTer.ManObrPla);
            iLisRes.Add(CostoUnitarioProTer.ManObr);
            iLisRes.Add(CostoUnitarioProTer.CosCifPla);
            iLisRes.Add(CostoUnitarioProTer.CosCif);

            //devolver
            return iLisRes;            
        }

        public static List<AcumuladoProceso> ObtenerReporteAcumuladosPorProcesoActualizadoNuevo(RetiquetadoEN pObj)
        {
            //lista resultado
            List<AcumuladoProceso> iLisRes = new List<AcumuladoProceso>();

            //objetos elementos
            AcumuladoProceso iAcuProMatPri = new AcumuladoProceso() { Elemento = "MATERIA PRIMA", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProEnv = new AcumuladoProceso() { Elemento = "ENVASES", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProManObrEnv = new AcumuladoProceso() { Elemento = "MANO OBRA ENVASADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifVarEnv = new AcumuladoProceso() { Elemento = "CIF VARIABLE ENVASADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifFijEnv = new AcumuladoProceso() { Elemento = "CIF FIJO ENVASADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProEmbEnc = new AcumuladoProceso() { Elemento = "EMBALAJES ENCAJADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProManObrEnc = new AcumuladoProceso() { Elemento = "MANO OBRA ENCAJADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifVarEnc = new AcumuladoProceso() { Elemento = "CIF VARIABLE ENCAJADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifFijEnc = new AcumuladoProceso() { Elemento = "CIF FIJO ENCAJADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProEmbRet = new AcumuladoProceso() { Elemento = "EMBALAJES REETIQUETADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProManObrRet = new AcumuladoProceso() { Elemento = "MANO OBRA REETIQUETADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifVarRet = new AcumuladoProceso() { Elemento = "CIF VARIABLE REETIQUETADO", CodigoExistencia = "x" };
            AcumuladoProceso iAcuProCifFijRet = new AcumuladoProceso() { Elemento = "CIF FIJO REETIQUETADO", CodigoExistencia = "x" };

            //obtenemos el reporte detallado por liberaciones
            List<CostoUnitarioProTer> iLisCosUni = ObtenerReporteCostoUnitarioPorFechasActualizado(pObj);

            //quitamos al ultimo objeto de esta lista que es el de totales
            iLisCosUni.RemoveAt(iLisCosUni.Count - 1);

            //acumular costos            
            CostoUnitarioProTer iCosUniProTerSum = ListaG.Sumar<CostoUnitarioProTer>(iLisCosUni, ObtenerListaCamposAcumulaReporteAcumuladosPorProceso());

            //actualizando cada objeto del reporte
            iAcuProMatPri.EnvasadoPpto = iCosUniProTerSum.MateriaPrimaPlanificada;
            iAcuProMatPri.CostoTotalPpto = iAcuProMatPri.EnvasadoPpto;
            iAcuProMatPri.EnvasadoRea = iCosUniProTerSum.MateriaPrima;
            iAcuProMatPri.CostoTotalRea = iAcuProMatPri.EnvasadoRea;
            iAcuProMatPri.EnvasadoDif = iAcuProMatPri.EnvasadoPpto - iAcuProMatPri.EnvasadoRea;
            iAcuProMatPri.CostoTotalDif = iAcuProMatPri.EnvasadoDif;
            iLisRes.Add(iAcuProMatPri);

            iAcuProEnv.EnvasadoPpto = iCosUniProTerSum.EnvasePlanificada;
            iAcuProEnv.CostoTotalPpto = iAcuProEnv.EnvasadoPpto;
            iAcuProEnv.EnvasadoRea = iCosUniProTerSum.Envase;
            iAcuProEnv.CostoTotalRea = iAcuProEnv.EnvasadoRea;
            iAcuProEnv.EnvasadoDif = iAcuProEnv.EnvasadoPpto - iAcuProEnv.EnvasadoRea;
            iAcuProEnv.CostoTotalDif = iAcuProEnv.EnvasadoDif;
            iLisRes.Add(iAcuProEnv);

            iAcuProManObrEnv.EnvasadoPpto = iCosUniProTerSum.ManoObraEnvasadoPlanificada;
            iAcuProManObrEnv.CostoTotalPpto = iAcuProManObrEnv.EnvasadoPpto;
            iAcuProManObrEnv.EnvasadoRea = iCosUniProTerSum.ManoObraEnvasado;
            iAcuProManObrEnv.CostoTotalRea = iAcuProManObrEnv.EnvasadoRea;
            iAcuProManObrEnv.EnvasadoDif = iAcuProManObrEnv.EnvasadoPpto - iAcuProManObrEnv.EnvasadoRea;
            iAcuProManObrEnv.CostoTotalDif = iAcuProManObrEnv.EnvasadoDif;
            iLisRes.Add(iAcuProManObrEnv);

            iAcuProCifVarEnv.EnvasadoPpto = iCosUniProTerSum.CostoCifVariableEnvasadoPlanificada;
            iAcuProCifVarEnv.CostoTotalPpto = iAcuProCifVarEnv.EnvasadoPpto;
            iAcuProCifVarEnv.EnvasadoRea = iCosUniProTerSum.CostoCifVariableEnvasado;
            iAcuProCifVarEnv.CostoTotalRea = iAcuProCifVarEnv.EnvasadoRea;
            iAcuProCifVarEnv.EnvasadoDif = iAcuProCifVarEnv.EnvasadoPpto - iAcuProCifVarEnv.EnvasadoRea;
            iAcuProCifVarEnv.CostoTotalDif = iAcuProCifVarEnv.EnvasadoDif;
            iLisRes.Add(iAcuProCifVarEnv);

            iAcuProCifFijEnv.EnvasadoPpto = iCosUniProTerSum.CostoCifFijoEnvasadoPlanificada;
            iAcuProCifFijEnv.CostoTotalPpto = iAcuProCifFijEnv.EnvasadoPpto;
            iAcuProCifFijEnv.EnvasadoRea = iCosUniProTerSum.CostoCifFijoEnvasado;
            iAcuProCifFijEnv.CostoTotalRea = iAcuProCifFijEnv.EnvasadoRea;
            iAcuProCifFijEnv.EnvasadoDif = iAcuProCifFijEnv.EnvasadoPpto - iAcuProCifFijEnv.EnvasadoRea;
            iAcuProCifFijEnv.CostoTotalDif = iAcuProCifFijEnv.EnvasadoDif;
            iLisRes.Add(iAcuProCifFijEnv);

            iAcuProEmbEnc.EncajadoPpto = iCosUniProTerSum.EmbalajeEncajadoPlanificada;
            iAcuProEmbEnc.CostoTotalPpto = iAcuProEmbEnc.EncajadoPpto;
            iAcuProEmbEnc.EncajadoRea = iCosUniProTerSum.EmbalajeEncajado;
            iAcuProEmbEnc.CostoTotalRea = iAcuProEmbEnc.EncajadoRea;
            iAcuProEmbEnc.EncajadoDif = iAcuProEmbEnc.EncajadoPpto - iAcuProEmbEnc.EncajadoRea;
            iAcuProEmbEnc.CostoTotalDif = iAcuProEmbEnc.EnvasadoDif;
            iLisRes.Add(iAcuProEmbEnc);

            iAcuProManObrEnc.EncajadoPpto = iCosUniProTerSum.ManoObraEncajadoPlanificada;
            iAcuProManObrEnc.CostoTotalPpto = iAcuProManObrEnc.EncajadoPpto;
            iAcuProManObrEnc.EncajadoRea = iCosUniProTerSum.ManoObraEncajado;
            iAcuProManObrEnc.CostoTotalRea = iAcuProManObrEnc.EncajadoRea;
            iAcuProManObrEnc.EnvasadoDif = iAcuProManObrEnc.EnvasadoPpto - iAcuProManObrEnc.EnvasadoRea;
            iAcuProManObrEnc.CostoTotalDif = iAcuProManObrEnc.EnvasadoDif;
            iLisRes.Add(iAcuProManObrEnc);

            iAcuProCifVarEnc.EncajadoPpto = iCosUniProTerSum.CostoCifVariableEncajadoPlanificada;
            iAcuProCifVarEnc.CostoTotalPpto = iAcuProCifVarEnc.EncajadoPpto;
            iAcuProCifVarEnc.EncajadoRea = iCosUniProTerSum.CostoCifVariableEncajado;
            iAcuProCifVarEnc.CostoTotalRea = iAcuProCifVarEnc.EncajadoRea;
            iAcuProCifVarEnc.EnvasadoDif = iAcuProCifVarEnc.EnvasadoPpto - iAcuProCifVarEnc.EnvasadoRea;
            iAcuProCifVarEnc.CostoTotalDif = iAcuProCifVarEnc.EnvasadoDif;
            iLisRes.Add(iAcuProCifVarEnc);

            iAcuProCifFijEnc.EncajadoPpto = iCosUniProTerSum.CostoCifFijoEncajadoPlanificada;
            iAcuProCifFijEnc.CostoTotalPpto = iAcuProCifFijEnc.EncajadoPpto;
            iAcuProCifFijEnc.EncajadoRea = iCosUniProTerSum.CostoCifFijoEncajado;
            iAcuProCifFijEnc.CostoTotalRea = iAcuProCifFijEnc.EncajadoRea;
            iAcuProCifFijEnc.EnvasadoDif = iAcuProCifFijEnc.EnvasadoPpto - iAcuProCifFijEnc.EnvasadoRea;
            iAcuProCifFijEnc.CostoTotalDif = iAcuProCifFijEnc.EnvasadoDif;
            iLisRes.Add(iAcuProCifFijEnc);

            iAcuProEmbRet.RetiquetadoPpto = iCosUniProTerSum.EmbalajeRetiquetadoPlanificada;
            iAcuProEmbRet.CostoTotalPpto = iAcuProEmbRet.RetiquetadoPpto;
            iAcuProEmbRet.RetiquetadoRea = iCosUniProTerSum.EmbalajeRetiquetado;
            iAcuProEmbRet.CostoTotalRea = iAcuProEmbRet.RetiquetadoRea;
            iAcuProEmbRet.RetiquetadoDif = iAcuProEmbRet.RetiquetadoPpto - iAcuProEmbRet.RetiquetadoRea;
            iAcuProEmbRet.CostoTotalDif = iAcuProEmbRet.RetiquetadoDif;
            iLisRes.Add(iAcuProEmbRet);

            iAcuProManObrRet.RetiquetadoPpto = iCosUniProTerSum.ManoObraRetiquetadoPlanificada;
            iAcuProManObrRet.CostoTotalPpto = iAcuProManObrRet.RetiquetadoPpto;
            iAcuProManObrRet.RetiquetadoRea = iCosUniProTerSum.ManoObraRetiquetado;
            iAcuProManObrRet.CostoTotalRea = iAcuProManObrRet.RetiquetadoRea;
            iAcuProManObrRet.RetiquetadoDif = iAcuProManObrRet.RetiquetadoPpto - iAcuProManObrRet.RetiquetadoRea;
            iAcuProManObrRet.CostoTotalDif = iAcuProManObrRet.RetiquetadoDif;
            iLisRes.Add(iAcuProManObrRet);

            iAcuProCifVarRet.RetiquetadoPpto = iCosUniProTerSum.CostoCifVariableRetiquetadoPlanificada;
            iAcuProCifVarRet.CostoTotalPpto = iAcuProCifVarRet.RetiquetadoPpto;
            iAcuProCifVarRet.RetiquetadoRea = iCosUniProTerSum.CostoCifVariableRetiquetado;
            iAcuProCifVarRet.CostoTotalRea = iAcuProCifVarRet.RetiquetadoRea;
            iAcuProCifVarRet.RetiquetadoDif = iAcuProCifVarRet.RetiquetadoPpto - iAcuProCifVarRet.RetiquetadoRea;
            iAcuProCifVarRet.CostoTotalDif = iAcuProCifVarRet.RetiquetadoDif;
            iLisRes.Add(iAcuProCifVarRet);

            iAcuProCifFijRet.RetiquetadoPpto = iCosUniProTerSum.CostoCifFijoRetiquetadoPlanificada;
            iAcuProCifFijRet.CostoTotalPpto = iAcuProCifFijRet.RetiquetadoPpto;
            iAcuProCifFijRet.RetiquetadoRea = iCosUniProTerSum.CostoCifFijoRetiquetado;
            iAcuProCifFijRet.CostoTotalRea = iAcuProCifFijRet.RetiquetadoRea;
            iAcuProCifFijRet.RetiquetadoDif = iAcuProCifFijRet.RetiquetadoPpto - iAcuProCifFijRet.RetiquetadoRea;
            iAcuProCifFijRet.CostoTotalDif = iAcuProCifFijRet.RetiquetadoDif;
            iLisRes.Add(iAcuProCifFijRet);

            //obtener objeto totales
            AcumuladoProceso iRet = ObtenerObjetoTotalesReporteAcumuladosPorProcesoActualizado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iRet);

            //devolver
            return iLisRes;
        }

        public static List<string> ObtenerListaCamposAcumulaReporteAcumuladosPorProceso()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(CostoUnitarioProTer.MatPriPla);
            iLisRes.Add(CostoUnitarioProTer.MatPri);
            iLisRes.Add(CostoUnitarioProTer.EnvPla);
            iLisRes.Add(CostoUnitarioProTer.Env);
            iLisRes.Add(CostoUnitarioProTer.EmbEncPla);
            iLisRes.Add(CostoUnitarioProTer.EmbRetPla);
            iLisRes.Add(CostoUnitarioProTer.EmbEnc);
            iLisRes.Add(CostoUnitarioProTer.EmbRet);
            iLisRes.Add(CostoUnitarioProTer.ManObrEnvPla);
            iLisRes.Add(CostoUnitarioProTer.ManObrEncPla);
            iLisRes.Add(CostoUnitarioProTer.ManObrRetPla);
            iLisRes.Add(CostoUnitarioProTer.ManObrEnv);
            iLisRes.Add(CostoUnitarioProTer.ManObrEnc);
            iLisRes.Add(CostoUnitarioProTer.ManObrRet);            
            iLisRes.Add(CostoUnitarioProTer.CosCifFijEnvPla);
            iLisRes.Add(CostoUnitarioProTer.CosCifVarEnvPla);
            iLisRes.Add(CostoUnitarioProTer.CosCifFijEncPla);
            iLisRes.Add(CostoUnitarioProTer.CosCifVarEncPla);
            iLisRes.Add(CostoUnitarioProTer.CosCifFijRetPla);
            iLisRes.Add(CostoUnitarioProTer.CosCifVarRetPla);
            iLisRes.Add(CostoUnitarioProTer.CosCifFijEnv);
            iLisRes.Add(CostoUnitarioProTer.CosCifVarEnv);
            iLisRes.Add(CostoUnitarioProTer.CosCifFijEnc);
            iLisRes.Add(CostoUnitarioProTer.CosCifVarEnc);
            iLisRes.Add(CostoUnitarioProTer.CosCifFijRet);
            iLisRes.Add(CostoUnitarioProTer.CosCifVarRet);

            //devolver
            return iLisRes;
        }
        

    }
}
