using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;
using System.Windows.Forms;
using Entidades.Estructuras;

namespace Negocio
{
    public class ProduccionProTerRN
    {

        public static ProduccionProTerEN EnBlanco()
        {
            ProduccionProTerEN iProEN = new ProduccionProTerEN();
            return iProEN;
        }

        public static void AdicionarProduccionProTer(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            iProAD.AdicionarProduccionProTer(pObj);
        }

        public static void AdicionarProduccionProTer(List<ProduccionProTerEN> pLista)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            iProAD.AdicionarProduccionProTer(pLista);
        }

        public static void ModificarProduccionProTer(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            iProAD.ModificarProduccionProTer(pObj);
        }

        public static void ModificarProduccionProTer(List<ProduccionProTerEN> pLista)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            iProAD.ModificarProduccionProTer(pLista);
        }

        public static void EliminarProduccionProTer(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            iProAD.EliminarProduccionProTer(pObj);
        }

        public static void EliminarProduccionProTerXClaveEncajado(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            iProAD.EliminarProduccionProTerXClaveEncajado(pObj);
        }

        public static ProduccionProTerEN BuscarProduccionProTerXClave(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.BuscarProduccionProTerXClave(pObj);
        }

        public static string ObtenerClaveProduccionProTer(ProduccionProTerEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave            
            iClave += pObj.ClaveEncajado + "-";
            iClave += pObj.CorrelativoProduccionProTer;

            //devolver
            return iClave;
        }

        public static ProduccionProTerEN EsProduccionProTerExistente(ProduccionProTerEN pObj)
        {
            //objeto resultado
            ProduccionProTerEN iProEN = new ProduccionProTerEN();

            //valida
            iProEN = ProduccionProTerRN.BuscarProduccionProTerXClave(pObj);
            if (iProEN.CorrelativoProduccionProTer == string.Empty)
            {
                iProEN.Adicionales.EsVerdad = false;
                iProEN.Adicionales.Mensaje = "El registro " + pObj.CorrelativoProduccionProTer + " no existe";
                return iProEN;
            }

            //ok
            return iProEN;
        }

        public static List<ProduccionProTerEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<ProduccionProTerEN> pListaProduccionProTer)
        {
            //lista resultado
            List<ProduccionProTerEN> iLisRes = new List<ProduccionProTerEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaProduccionProTer; }

            //filtar la lista
            iLisRes = ProduccionProTerRN.FiltrarProduccionProTerENCualquierPosicion(pListaProduccionProTer, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<ProduccionProTerEN> FiltrarProduccionProTerENCualquierPosicion(List<ProduccionProTerEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<ProduccionProTerEN> iLisRes = new List<ProduccionProTerEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (ProduccionProTerEN xPro in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<ProduccionProTerEN>(xPro, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPro);
                }
            }

            //devolver
            return iLisRes;
        }

        public static ProduccionProTerEN EsActoAdicionarProduccionProTer(decimal pUnidadesAEmpacar)
        {
            //objeto resultado
            ProduccionProTerEN iProCabEN = new ProduccionProTerEN();

            //valida cuando no hay unidades a empacar
            iProCabEN = ProduccionProTerRN.ValidaCuandoNoHayUnidadesAEmpacar(pUnidadesAEmpacar);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //ok          
            return iProCabEN;
        }

        public static ProduccionProTerEN ValidaCuandoNoHayUnidadesAEmpacar(decimal pUnidadesAEmpacar)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar
            if (pUnidadesAEmpacar == 0)
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "Debes registrar el numero de unidades a empaquetar";
            }

            //devolver
            return iProProTerEN;
        }

        public static ProduccionProTerEN EsActoEliminarProduccionProTer(ProduccionProTerEN pObj)
        {
            //objeto resultado
            ProduccionProTerEN iProCabEN = new ProduccionProTerEN();

            //validar si existe
            iProCabEN = ProduccionProTerRN.EsProduccionProTerExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionProTerEN EsActoModificarProduccionProTer(ProduccionProTerEN pObj)
        {
            //objeto resultado
            ProduccionProTerEN iProCabEN = new ProduccionProTerEN();

            //validar si existe
            iProCabEN = ProduccionProTerRN.EsProduccionProTerExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //ok            
            return iProCabEN;
        }

        public static string ObtenerMaximoValorEnColumna(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProCabAD = new ProduccionProTerAD();
            return iProCabAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoNumeroProduccionProTerAutogenerado(ProduccionProTerEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = ProduccionProTerRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 2);

            //devuelve
            return iNumero;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXProduccionDeta(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerXProduccionDeta(pObj);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXProduccionDeta(string pClaveProduccionDeta)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iProProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.CorProProTer;

            //ejecutar metodo
            return ProduccionProTerRN.ListarProduccionProTerXProduccionDeta(iProProTerEN);
        }

        public static void GenerarProduccionProTerDeProduccionDeta(ProduccionDetaEN pObj)
        {
            //traer la lista de formulasDeta que tengan codigoExistencia ProTer
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaDeFormulaCabeDeDiferentesProTer(pObj);

            //traer la lista de ProduccionProTer de ProduccionDeta que hay en bd
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXProduccionDeta(pObj.ClaveProduccionDeta);

            //variables
            string iCorrelativoProduccionProTer = ListaG.ObtenerUltimoValor<ProduccionProTerEN>(iLisProProTer,
                ProduccionProTerEN.CorProProTer);

            //recorrer cada objeto formulaDeta
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //valida si ya tiene produccionProTer generado en bd
                bool iEncontrado = ListaG.Existe<ProduccionProTerEN>(iLisProProTer, ProduccionProTerEN.CodExi,
                    xForDet.CodigoExistenciaProTer);

                //si lo encuentra pasa al siguiente objeto del bucle
                if (iEncontrado == true) { continue; }

                //aumentamos el correlativo
                iCorrelativoProduccionProTer = Numero.IncrementarCorrelativoNumerico(iCorrelativoProduccionProTer, 2);

                //aqui generamos un nuevo objeto produccionProTer apartir de un objeto ProduccionDeta y formulaDeta
                ProduccionProTerEN iProProTerNueEN = ProduccionProTerRN.NuevoProduccionProTer(pObj, xForDet, iCorrelativoProduccionProTer);

                //adicion en bd
                ProduccionProTerRN.AdicionarProduccionProTer(iProProTerNueEN);
            }
        }

        public static ProduccionProTerEN NuevoProduccionProTer(ProduccionDetaEN pProDet, FormulaDetaEN pForDet,
            string pCorrelativoProduccionProTer)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //pasar datos
            iProProTerEN.ClaveProduccionDeta = pProDet.ClaveProduccionDeta;
            iProProTerEN.ClaveProduccionCabe = pProDet.ClaveProduccionCabe;
            iProProTerEN.CodigoEmpresa = pProDet.CodigoEmpresa;
            iProProTerEN.CorrelativoProduccionProTer = pCorrelativoProduccionProTer;
            iProProTerEN.CodigoAlmacen = pForDet.CodigoAlmacenProTer;
            iProProTerEN.CodigoExistencia = pForDet.CodigoExistenciaProTer;
            iProProTerEN.ClaveProduccionProTer = ProduccionProTerRN.ObtenerClaveProduccionProTer(iProProTerEN);

            //devolver
            return iProProTerEN;
        }

        public static decimal ObtenerCostoEmpaquetadoTotal(ProduccionProTerEN pObj)
        {
            return pObj.CostoEmpaquetadoPrincipal + pObj.CostoEmpaquetadoAdicional - pObj.CostoEmpaquetadoDevolucion + pObj.CostoEmpaquetadoSegundaLiberacion;
        }

        public static decimal ObtenerCostoUnidadEmpaquetado(ProduccionProTerEN pObj)
        {
            //dividir entre el numero de unidades que pasaron el control de calidad
            decimal iCostoTotal = Operador.DivisionDecimal(pObj.CostoEmpaquetadoTotal, pObj.CantidadUnidadesRealEncajado);

            //redondeo
            iCostoTotal = Math.Round(iCostoTotal, 6);

            //devolver
            return iCostoTotal;
        }

        public static decimal ObtenerCostoUnidadProTerInsumos(ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //--------
            //calcular
            //--------
            iValor = pProProTer.CostoUnidadSemiProducto + pProProTer.CostoUnidadEmpaquetado;

            //devolver
            return iValor;
        }

        public static void ActualizarCostosFaseEmpaquetadoProTer(List<ProduccionProTerEN> pLista, ProduccionDetaEN pProDet)
        {
            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in pLista)
            {
                //obtener el costo fase empaquetado semiEla principal
                xProProTer.CostoEmpaquetadoPrincipal = ProduccionExisRN.ObtenerCostoTotalFaseEmpaquetado(xProProTer);

                ////obtener el costo cc masa adicional
                //xProProTer.CostoEmpaquetadoAdicional = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoAdicional(pProDet, xProProTer);

                ////obtener el costo cc devolucion
                //xProProTer.CostoEmpaquetadoDevolucion = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoDevolucion(pProDet, xProProTer);

                //obtener el costo cc masa total
                xProProTer.CostoEmpaquetadoTotal = ProduccionProTerRN.ObtenerCostoEmpaquetadoTotal(xProProTer);

                //obtener costo de unidad de masa
                xProProTer.CostoUnidadEmpaquetado = ProduccionProTerRN.ObtenerCostoUnidadEmpaquetado(xProProTer);

                //obtener el costo unidad total de insumos
                xProProTer.CostoInsumos = ProduccionProTerRN.ObtenerCostoUnidadProTerInsumos(xProProTer);

                //obtener el costo unidad total del producto
                xProProTer.CostoTotalProducto = ProduccionProTerRN.ObtenerCostoUnidadProTer(xProProTer);
            }
        }

        public static decimal ObtenerCostoUnidadProTer(ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //--------
            //calcular
            //--------
            iValor = pProProTer.CostoInsumos + pProProTer.CostoManoObra + pProProTer.CostoGastoIndirecto + pProProTer.CostoOtros;

            //devolver
            return iValor;
        }

        public static void ModificarCostosFaseEmpaquetadoProTer(ProduccionDetaEN pObj)
        {
            //listar a los ProduccionProTer con numero cajas diferente de cero
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXProduccionDetaYConNumeroCajas(pObj);

            //actualizamos los datos de empaquetado
            ProduccionProTerRN.ActualizarCostosFaseEmpaquetadoProTer(iLisProProTer, pObj);

            //modificar en bd
            ProduccionProTerRN.ModificarProduccionProTer(iLisProProTer);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXProduccionDetaYConNumeroCajas(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerXProduccionDetaYConNumeroCajas(pObj);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXProduccionDetaYConNumeroCajas(ProduccionDetaEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iProProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.CorProProTer;

            //ejecutar metodo
            return ProduccionProTerRN.ListarProduccionProTerXProduccionDetaYConNumeroCajas(iProProTerEN);
        }

        public static string ObtenerClaveExistencia(ProduccionProTerEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += pObj.CodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoExistencia;

            //devolver
            return iClave;
        }

        public static ProduccionProTerEN BuscarProduccionProTerXClaveProduccionDetaYCodigoExistencia(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.BuscarProduccionProTerXClaveProduccionDetaYCodigoExistencia(pObj);
        }

        public static decimal ObtenerCostoFaseEmpaquetadoAdicional(ProduccionProTerEN pProProTer, List<FormulaDetaEN> pLisForDet,
            List<MovimientoDetaEN> pLisMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //obtener solo las formulasDeta de fase empaquetado
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CTipDes, "2",
                FormulaDetaEN.CodExiProTer, pProProTer.CodigoExistencia);

            //armar una cadena con todos los codigos de existencia
            string iCodigosExistencia = ListaG.ArmarCadenaDeValores<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExi, ",");

            //filtrar los movimientosDeta de solo estos codigosexistencias
            List<MovimientoDetaEN> iLisMovDet = ListaG.FiltrarPorConjuntoValores<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodExi,
                iCodigosExistencia);

            //filtrar solo movimientosDeta de tipo "salida"
            iLisMovDet = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CClaTipOpe, "2");

            //sumar
            iValor = ListaG.Sumar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CosMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseEmpaquetadoAdicional(ProduccionDetaEN pObj, ProduccionProTerEN pProPreTer)
        {
            //valor resultado
            decimal iValor = 0;

            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(pObj);
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //ejecutar metodo
            iValor = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoAdicional(pProPreTer, iLisForDet, iLisMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseEmpaquetadoDevolucion(ProduccionProTerEN pProProTer, List<FormulaDetaEN> pLisForDet,
           List<MovimientoDetaEN> pLisMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //obtener solo las formulasDeta de fase empaquetado
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CTipDes, "2",
                FormulaDetaEN.CodExiProTer, pProProTer.CodigoExistencia);

            //armar una cadena con todos los codigos de existencia
            string iCodigosExistencia = ListaG.ArmarCadenaDeValores<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExi, ",");

            //filtrar los movimientosDeta de solo estos codigosexistencias
            List<MovimientoDetaEN> iLisMovDet = ListaG.FiltrarPorConjuntoValores<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodExi,
                iCodigosExistencia);

            //filtrar solo movimientosDeta de tipo "ingreso"
            iLisMovDet = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CClaTipOpe, "1");

            //sumar
            iValor = ListaG.Sumar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CosMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseEmpaquetadoDevolucion(ProduccionDetaEN pObj, ProduccionProTerEN pProPreTer)
        {
            //valor resultado
            decimal iValor = 0;

            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(pObj);
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //ejecutar metodo
            iValor = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoDevolucion(pProPreTer, iLisForDet, iLisMovDet);

            //devolver
            return iValor;
        }

        public static void ModificarUnidadesDevueltasProTerPorEmpaquetado(ProduccionDetaEN pObj)
        {
            //obtener la lista actualizada por accion de empaquetado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProTerUnidadesDevueltasActualizadasPorEmpaquetado(pObj);

            //modificar las unidades por accion de empaquetado pero en produccionDeta
            ProduccionDetaRN.ModificarUnidadesSemiElaboradaPorEmpaquetado(pObj, iLisProProTer);

            //modificar en bd
            ProduccionProTerRN.ModificarProduccionProTer(iLisProProTer);
        }

        public static List<ProduccionProTerEN> ListarProTerUnidadesDevueltasActualizadasPorEmpaquetado(ProduccionDetaEN pObj)
        {
            //lista resultado
            List<ProduccionProTerEN> iLisRes = new List<ProduccionProTerEN>();

            //traer la lista de movimientosDeta que representan salidas y ingresos adicionales de esta produccionDeta           
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //traer la lista de productos terminados con numero de cajas diferente de cero
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXProduccionDetaYConNumeroCajas(pObj);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //sino tiene unidades desechas
                if (xProProTer.UnidadesDesechaEmpaquetado == 0)
                {
                    xProProTer.UnidadesDevueltaEmpaquetado = 0;
                }
                else
                {
                    //calcular unidades devueltas en el proceso de empaquetar
                    xProProTer.UnidadesDevueltaEmpaquetado = ProduccionProTerRN.ObtenerCantidadUnidadesDevueltasEmpaquetado(pObj, iLisMovDet);
                }

                //agregar a la lista resultado
                iLisRes.Add(xProProTer);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCantidadUnidadesDevueltasEmpaquetado(ProduccionDetaEN pObj, List<MovimientoDetaEN> pLisMovDetPro)
        {
            //valor resultado
            decimal iValor = 0;

            //obtener
            //filtrar las que son de ingreso y codigoAlmacen SemiElaborado
            List<MovimientoDetaEN> iLisMovDetProSal = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDetPro, MovimientoDetaEN.CClaTipOpe, "1",
                MovimientoDetaEN.CodAlm, pObj.CodigoAlmacenSemiProducto);

            //sumar por cantidad
            iValor = ListaG.Sumar<MovimientoDetaEN>(iLisMovDetProSal, MovimientoDetaEN.CanMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCantidadUnidadesRealProducida(ProduccionProTerEN pProPreTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //primero obtemos la cantidad teorica, antes del empaquetado
            iValor = pProPreTer.NumeroCajas * pProPreTer.UnidadesPorEmpaque;

            //solo si hay unidades devueltas,se determina el numero real de unidades
            if (pProPreTer.UnidadesDevueltaEmpaquetado == 0)
            {
                if (pProPreTer.UnidadesDesechaEmpaquetado >= pProPreTer.UnidadesPorEmpaque)
                {
                    //obtener el numero en paquetes desechados
                    decimal iNumeroPaquetesDesechados = Operador.DivisionEntera(pProPreTer.UnidadesDesechaEmpaquetado,
                        pProPreTer.UnidadesPorEmpaque);

                    iValor -= iNumeroPaquetesDesechados * pProPreTer.UnidadesPorEmpaque;
                }
            }
            else
            {
                iValor -= pProPreTer.UnidadesDesechaEmpaquetado + pProPreTer.UnidadesDevueltaEmpaquetado;
            }

            //devolver
            return iValor;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXRangoFechaProduccion(ProduccionDetaEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerXRangoFechaProduccion(pObj);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXRangoFechaProduccion(string pFechaProduccionDesde,
            string pFechaProduccionHasta)
        {
            //asignar parametro
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.Adicionales.Desde1 = pFechaProduccionDesde;
            iProDetEN.Adicionales.Hasta1 = pFechaProduccionHasta;

            //ejecutar metodo
            return ProduccionProTerRN.ListarProduccionProTerXRangoFechaProduccion(iProDetEN);
        }

        public static void ActualizarCostosManoObraProTer(ProduccionProTerEN pObj, decimal pRatio, decimal pFactor)
        {
            //sino hay cantidad real,entonces termina proceso
            if (pObj.CantidadUnidadesRealEncajado == 0) { return; }

            //actualizar datos
            pObj.FactorProduccionProTer = pFactor;
            pObj.RatioProduccionProTer = pRatio;
            pObj.HorasHombre = ProduccionProTerRN.CalcularHorasHombre(pObj.RatioProduccionProTer, pObj.CantidadUnidadesRealEncajado);
            pObj.CostoTotalManoObra = ProduccionProTerRN.CalcularCostoTotalManoObra(pObj.HorasHombre, pFactor);
            pObj.CostoManoObra = ProduccionProTerRN.CalcularCostoUnitarioManoObra(pObj.CostoTotalManoObra, pObj.CantidadUnidadesRealEncajado);

            //obtener el costo unidad total del producto
            pObj.CostoTotalProducto = ProduccionProTerRN.ObtenerCostoUnidadProTer(pObj);
        }

        public static decimal CalcularHorasHombre(decimal pRatio, decimal pUnidadesReales)
        {
            return Math.Round(pRatio * pUnidadesReales, 6);
        }

        public static decimal CalcularCostoTotalManoObra(decimal pHorasHombre, decimal pFactor)
        {
            return Math.Round(pHorasHombre * pFactor, 6);
        }

        public static decimal CalcularCostoUnitarioManoObra(decimal pCostoTotalManoObra, decimal pUnidadesReales)
        {
            return Math.Round(Operador.DivisionDecimal(pCostoTotalManoObra, pUnidadesReales), 6);
        }

        public static void RecalcularManoObra(string pAño, string pCodigoMes)
        {
            //listar todas las ProduccionesProTer para este recalculo
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerParaRecalculoManoObra(pAño, pCodigoMes);

            //obtener el factor para este periodo
            decimal iFactorCosto = FactorCostoRN.ObtenerFactorCostoParaRecalculoManoObra(pAño, pCodigoMes);

            //listar todas las FormulasDetas con codigoexistencia ProTer
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaConCodigoExistenciaProTer();

            //actualizar
            ProduccionProTerRN.ActualizarCostosManoObraProTer(iLisProProTer, iLisForDet, iFactorCosto);

            //modificar masivo
            ProduccionProTerRN.ModificarProduccionProTer(iLisProProTer);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXPeriodoProduccionDeta(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerXPeriodoProduccionDeta(pObj);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerParaRecalculoManoObra(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerParaRecalculoManoObra(pObj);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerParaRecalculoManoObra(string pAño, string pCodigoMes)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.PeriodoEncajado = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iProProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.ClaProProTer;

            //ejecutar metodo
            return ProduccionProTerRN.ListarProduccionProTerParaRecalculoManoObra(iProProTerEN);
        }

        public static List<List<ProduccionProTerEN>> ListarListasProduccionProTerParaRecalculoManoObra(string pAño, string pCodigoMes)
        {
            //traemos la lista de produccionesProTer para recalculo mano obra
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerParaRecalculoManoObra(pAño, pCodigoMes);

            //obtener una lista de listas de produccionProTer por Parte de trabajo
            List<List<ProduccionProTerEN>> iLisLisProProTer = ListaG.ListarListas<ProduccionProTerEN>(iLisProProTer,
                ProduccionProTerEN.ClaProDet);

            //devolver
            return iLisLisProProTer;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXClaveEncajado(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerXClaveEncajado(pObj);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXClaveEncajado(string pClaveEncajado)
        {
            //asignar parametros
            ProduccionProTerEN iProTerEN = new ProduccionProTerEN();
            iProTerEN.ClaveEncajado = pClaveEncajado;
            iProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.CorProProTer;

            //ejecutar metodo
            return ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(iProTerEN);
        }

        public static void AdicionarProduccionProTer(List<ProduccionProTerEN> pLis, ProduccionProTerEN pObj)
        {
            //obtener siguiente correlativo
            pObj.CorrelativoProduccionProTer = ProduccionProTerRN.ObtenerSiguienteCorrelativo(pLis);
            pObj.ClaveObjeto = ProduccionProTerRN.ObtenerClaveProduccionProTer(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<ProduccionProTerEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "00";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoProduccionProTer;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static void ModificarCostosFaseEmpaquetadoProTer(EncajadoEN pObj)
        {
            //listar a los ProduccionProTer con numero cajas diferente de cero
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pObj.ClaveEncajado);

            //actualizamos los datos de empaquetado
            ProduccionProTerRN.ActualizarCostosFaseEmpaquetadoProTer(iLisProProTer, pObj.ClaveEncajado);

            //modificar en bd
            ProduccionProTerRN.ModificarProduccionProTer(iLisProProTer);
        }

        //public static void ActualizarCostosFaseEmpaquetadoProTer(List<ProduccionProTerEN> pLista, string pClaveEncajado)
        //{
        //    //traer a todos los produccionesExis de esta lista
        //    List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveEncajado(pClaveEncajado);

        //    //recorrer cada objeto
        //    foreach (ProduccionProTerEN xProProTer in pLista)
        //    {
        //        List<ProduccionExisEN> iLisProExiProTer = ListaG.Filtrar<ProduccionExisEN>(iLisProExi, ProduccionExisEN.ClaProProTer, xProProTer.ClaveProduccionProTer);
        //        ActualizarCostosFaseEmpaquetadoProTer(xProProTer, iLisProExiProTer);
        //    }
        //}

        public static void ActualizarCostosFaseEmpaquetadoProTer(List<ProduccionProTerEN> pLista, string pClaveEncajado)
        {
            //traer a todos los produccionesExis de esta lista
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveEncajado(pClaveEncajado);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in pLista)
            {
                List<ProduccionExisEN> iLisProExiProTer = ListaG.Filtrar<ProduccionExisEN>(iLisProExi, ProduccionExisEN.ClaProProTer, xProProTer.ClaveProduccionProTer);
                List<MovimientoDetaEN> iLisMovDetProTer = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionProTer(xProProTer.ClaveProduccionProTer);
                ActualizarCostosFaseEmpaquetadoProTer(xProProTer, iLisProExiProTer, iLisMovDetProTer);
            }
        }


        public static void ModificarCostosManoObraProTer(EncajadoEN pObj)
        {
            //listar a los ProduccionProTer 
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pObj.ClaveEncajado);

            //listar todas las FormulasDetas con codigoexistencia ProTer
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaConCodigoExistenciaProTer();

            //obtener el factor para esta produccion
            decimal iFactorCosto = FactorCostoRN.ObtenerFactorCosto(pObj);

            //actualizamos los datos de empaquetado
            ProduccionProTerRN.ActualizarCostosManoObraProTer(iLisProProTer, iLisForDet, iFactorCosto);

            //modificar en bd
            ProduccionProTerRN.ModificarProduccionProTer(iLisProProTer);
        }

        public static void ActualizarCostosManoObraProTer(List<ProduccionProTerEN> pLisProProTer, List<FormulaDetaEN> pLisForDet, decimal pFactor)
        {
            //recorrer cada lista
            foreach (ProduccionProTerEN xProProTer in pLisProProTer)
            {
                //buscar al objeto FormulaDeta para esta accion
                FormulaDetaEN iForDetBusEN = ListaG.Buscar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CodExiProTer, xProProTer.CodigoExistencia);

                //actualizar
                ProduccionProTerRN.ActualizarCostosManoObraProTer(xProProTer, iForDetBusEN.RatioFormulaCabe, pFactor);
            }
        }

        public static void ActualizarCostosManoObraProTer(ProduccionProTerEN pProProTer, List<FormulaDetaEN> pLisForDet, decimal pFactor)
        {
            //buscar al objeto FormulaDeta para esta accion
            FormulaDetaEN iForDetBusEN = ListaG.Buscar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CodExiProTer, pProProTer.CodigoExistencia);

            //actualizar
            ProduccionProTerRN.ActualizarCostosManoObraProTer(pProProTer, iForDetBusEN.RatioFormulaCabe, pFactor);
        }

        public static List<ProduccionProTerEN> ListarProduccionesProTerParaMigracion(EncajadoEN pEnc, List<ProduccionDetaEN> pLisProDetExc)
        {
            //lista resultado
            List<ProduccionProTerEN> iLisRes = new List<ProduccionProTerEN>();

            //acumular la lista de excel por #cajas
            List<ProduccionDetaEN> iLisProDetAcu = ProduccionDetaRN.ListarProduccionDetaAcumuladosParaMigracion(pLisProDetExc);

            //correlativo
            string iCorrelativo = "00";

            //recorrer cada objeto ProduccionDeta
            foreach (ProduccionDetaEN xProDet in iLisProDetAcu)
            {
                //nuevo objeto ProduccionProTer
                ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

                //pasar datos
                iProProTerEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iProProTerEN.CodigoAlmacen = "A13";
                iProProTerEN.CodigoExistencia = xProDet.CodigoMercaderia;
                iProProTerEN.UnidadesPorEmpaque = xProDet.UnidadesPorCaja;
                iProProTerEN.NumeroCajas = Operador.DivisionEntera(xProDet.SaldoUnidadesAEmpacar, xProDet.UnidadesPorCaja);
                iProProTerEN.CantidadUnidadesProTer = xProDet.UnidadesPorCaja * iProProTerEN.NumeroCajas;
                iProProTerEN.ClaveEncajado = pEnc.ClaveEncajado;
                iProProTerEN.CorrelativoProduccionProTer = Numero.IncrementarCorrelativoNumerico(ref iCorrelativo);
                iProProTerEN.ClaveProduccionProTer = ProduccionProTerRN.ObtenerClaveProduccionProTer(iProProTerEN);

                //agregar a la lista resultado
                iLisRes.Add(iProProTerEN);
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarCostoInsumoSemiProducto(EncajadoEN pEnc, List<MovimientoDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //ejecutar metodo
            ModificarCostoInsumoSemiProducto(iLisProProTer);
        }

        public static void ModificarCostoInsumoSemiProductoOC(EncajadoEN pEnc, List<MovimientoOCDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //ejecutar metodo
            ModificarCostoInsumoSemiProducto(iLisProProTer);
        }

        public static void ModificarCostoInsumoSemiProducto(List<ProduccionProTerEN> pLisProProTer)
        {
            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in pLisProProTer)
            {
                //actualizar costo insumo
                xProProTer.CostoUnidadSemiProducto = ProduccionProTerRN.ObtenerCostoInsumoSemiProducto(xProProTer);
                xProProTer.CostoInsumos = ProduccionProTerRN.ObtenerCostoUnidadProTerInsumos(xProProTer);
                xProProTer.CostoTotalProducto = ProduccionProTerRN.ObtenerCostoUnidadProTer(xProProTer);
            }

            //modificar masivo
            ProduccionProTerRN.ModificarProduccionProTer(pLisProProTer);
        }

        public static decimal ObtenerCostoInsumoSemiProducto(List<LiberacionProTer> pLisLibProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //variables
            decimal iNumerador = 0;
            decimal iDenominador = 0;

            //calcular
            foreach (LiberacionProTer xLibProTer in pLisLibProTer)
            {
                iNumerador += xLibProTer.CostoTotalProducto * xLibProTer.Cantidad;
                iDenominador += xLibProTer.Cantidad;
            }

            //obtener el promedio ponderado
            iValor = Operador.DivisionDecimal(iNumerador, iDenominador);

            //lo redondeamos a 2 decimales
            iValor = Math.Round(iValor, 2);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoInsumoSemiProducto(ProduccionProTerEN pObj)
        {
            //asignar parametros
            List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(pObj.DetalleCantidadesSemiProducto);

            //ejecutar metodo
            return ObtenerCostoInsumoSemiProducto(iLisLibProTer);
        }

        //public static ProduccionProTerEN EsCantidadUnidadesCorrecta(ProduccionProTerEN pObj, decimal pCantidadSaldosLiberacion)
        //{
        //    //objeto resultado
        //    ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

        //    //valida cuando la cantidad es cero
        //    if (pObj.CantidadUnidadesProTer == 0) { return iProProTerEN; }

        //    //valida cuando el semi producto de este proter no tiene las cantidades pedidas
        //    iProProTerEN = ProduccionProTerRN.ValidaCuandoSemiProductoNoTieneCantidadPedida(pObj, pCantidadSaldosLiberacion);
        //    if (iProProTerEN.Adicionales.EsVerdad == false) { return iProProTerEN; }

        //    //devolver
        //    return iProProTerEN;
        //}

        public static ProduccionProTerEN EsCantidadUnidadesCorrecta(ProduccionProTerEN pObj, decimal pCantidadSaldosLiberacion)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadUnidadesProTer == 0) { return iProProTerEN; }

            //valida cuando el semi producto de este proter no tiene las cantidades pedidas
            iProProTerEN = ProduccionProTerRN.ValidaCuandoSemiProductoNoTieneCantidadPedida(pObj, pCantidadSaldosLiberacion);
            if (iProProTerEN.Adicionales.EsVerdad == false) { return iProProTerEN; }

            //valida cuando el numero de cajas no es entero
            iProProTerEN = ValidaCuandoNumeroCajasPedidaNoEsEntero(pObj);
            if (iProProTerEN.Adicionales.EsVerdad == false) { return iProProTerEN; }

            //devolver
            return iProProTerEN;
        }

        public static ProduccionProTerEN ValidaCuandoSemiProductoNoTieneCantidadPedida(ProduccionProTerEN pObj, decimal pCantidadSaldosLiberacion)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar            
            if (pObj.CantidadUnidadesProTer > pCantidadSaldosLiberacion)
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "La cantidad de unidades del semiProducto para empaquetar es: " + pCantidadSaldosLiberacion;
            }

            //devolver
            return iProProTerEN;
        }

        public static ProduccionProTerEN ValidaCuandoSemiProductoNoTieneCantidadPedida(ProduccionProTerEN pObj)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar
            ExistenciaEN iExiEN = ExistenciaRN.ObtenerExistenciaSemiElaborado(pObj);
            if (iExiEN.StockActualExistencia < pObj.CantidadUnidadesProTer)
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "La cantidad de unidades del semiProducto para empaquetar es: " + iExiEN.StockActualExistencia;
            }

            //devolver
            return iProProTerEN;
        }

        public static ProduccionProTerEN ValidaCuandoNumeroCajasPedidaNoEsEntero(ProduccionProTerEN pObj)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar           
            if (Numero.ObtenerParteDecimal(pObj.NumeroCajas) != 0)
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "La cantidad cajas debe ser un numero entero";
            }

            //devolver
            return iProProTerEN;
        }

        public static string ObtenerDetalleCantidadesSemiProducto(List<ProduccionDetaEN> pLis)
        {
            //valor resultado
            string iValor = string.Empty;

            //obtener
            foreach (ProduccionDetaEN xProDet in pLis)
            {
                iValor += xProDet.ClaveProduccionDeta + "=" + xProDet.NumeroUnidadesAEmpaquetar.ToString() + "|";
            }

            //devolver
            return iValor;
        }

        public static string ObtenerFechaLoteSugerida(ProduccionProTerEN pObj)
        {
            //valor resultado
            string iValor = string.Empty;

            //obtener            
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaParaEmpaquetarXCodigoSemiProducto(pObj);
            iValor = ListaG.ObtenerPrimerValor<ProduccionDetaEN>(iLisProDet, ProduccionDetaEN.FecProDet);

            //devolver
            return iValor;
        }

        public static string ObtenerFechaVcto(ProduccionProTerEN pObj)
        {
            //valor resultado
            string iValor = string.Empty;

            //obtener
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pObj);
            iValor = Fecha.ObtenerFechaFinal(pObj.FechaLoteProTer, (int)iForDetEN.NumeroDiasVctoFormulaCabe);
            iValor = Fecha.ObtenerDiaMesAno(iValor);

            //devolver
            return iValor;
        }

        public static int MoverObjeto(List<ProduccionProTerEN> pLis, int pIndiceObjetoActual, int pAccionBoton)
        {
            //leyenda accion boton
            //0:primero
            //1:anterior
            //2:siguiente
            //3:ultimo

            //variables
            int iUltimoIndice = pLis.Count - 1;

            //clonar al objeto del indice actual(el que se va a mover)
            ProduccionProTerEN iObjInd = ObjetoG.Clonar<ProduccionProTerEN>(pLis[pIndiceObjetoActual]);

            //eliminar a este objeto del pLis
            pLis.RemoveAt(pIndiceObjetoActual);

            //obtener la nueva posicion del indice
            int iNuevoIndice = 0;
            switch (pAccionBoton)
            {
                case 0: { iNuevoIndice = 0; break; }
                case 1: { iNuevoIndice = pIndiceObjetoActual - 1; break; }
                case 2: { iNuevoIndice = pIndiceObjetoActual + 1; break; }
                case 3: { iNuevoIndice = iUltimoIndice; break; }
            }

            //insetar al objeto en la nueva posicion
            pLis.Insert(iNuevoIndice, iObjInd);

            //devolver
            return iNuevoIndice;
        }

        public static void OrdenarCorrelativo(List<ProduccionProTerEN> pLis)
        {
            string iCorrelativo = "00";

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in pLis)
            {
                //incrementar el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

                //actualizar algunos datos antes de grabar          
                xProProTer.CorrelativoProduccionProTer = iCorrelativo;
                xProProTer.ClaveProduccionProTer = ProduccionProTerRN.ObtenerClaveProduccionProTer(xProProTer);
            }
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerParaPlanificacionEncajado()
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerParaPlanificacionEncajado();
        }

        //public static decimal CalcularNumeroCajas(ProduccionProTerEN pObj)
        //{
        //    //valor resultado
        //    decimal iValor = 0;

        //    //valida si unidades por empaque es cero
        //    if (pObj.UnidadesPorEmpaque == 0) { return iValor; }

        //    //--------
        //    //calcular
        //    //--------

        //    //obtener la parte entera de dividir cantidad unidades y unidades por empaque
        //    iValor = Operador.DivisionEntera(pObj.CantidadUnidadesProTer, pObj.UnidadesPorEmpaque);

        //    //obtener el resto de la misma division
        //    decimal iResto = pObj.CantidadUnidadesProTer % pObj.UnidadesPorEmpaque;

        //    //si el resto es cero ,entonces pasa la cantidad sola de division entera
        //    if (iResto == 0) { return iValor; }

        //    //aqui hay resto , entonces sumamos una unidad a la cantidad de division entera
        //    return iValor + 1;
        //}

        public static decimal CalcularNumeroCajas(ProduccionProTerEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //valida si unidades por empaque es cero
            if (pObj.UnidadesPorEmpaque == 0) { return iValor; }

            //--------
            //calcular
            //--------

            //obtener la division cantidad unidades y unidades por empaque
            iValor = Operador.DivisionDecimal(pObj.CantidadUnidadesProTer, pObj.UnidadesPorEmpaque);

            //devolver
            return iValor;
        }


        public static List<LiberacionProTer> ConvertirCampoDetalleCantidadesSemiProductoALista(string pDetalleCantidadesSemiProducto)
        {
            //lista resultado
            List<LiberacionProTer> iLisRes = new List<LiberacionProTer>();

            //---------
            //convertir
            //---------

            //obtener la lista de cadenas que corresponden a cada liberacionProTer
            List<string> iLisLibProTer = Cadena.ListarPalabrasDeTexto(pDetalleCantidadesSemiProducto, "|");

            //recorrer cada cadena
            foreach (string xStr in iLisLibProTer)
            {
                //si la cadena esta vacia,termino el proceso
                if (xStr.Trim() == string.Empty) { break; }

                //de esta cadena, tambien sacar la lista de cadenas qque corresponden a los campos de LiberacionProTer
                List<string> iLisCamLibProTer = Cadena.ListarPalabrasDeTexto(xStr, ";");

                //creamos un nuevo objeto LiberacionProTer
                LiberacionProTer iLibProTer = new LiberacionProTer();

                //pasamos sus datos
                iLibProTer.ClaveLiberacion = iLisCamLibProTer[0];
                iLibProTer.FechaLote = iLisCamLibProTer[1];
                iLibProTer.FechaVcto = iLisCamLibProTer[2];
                iLibProTer.Cantidad = Conversion.ADecimal(iLisCamLibProTer[3], 0);
                iLibProTer.CostoTotalProducto = Conversion.ADecimal(iLisCamLibProTer[4], 0);
                if (iLisCamLibProTer.Count == 6)
                {
                    iLibProTer.FechaProduccionDeta = iLisCamLibProTer[5];
                }

                //agregar a lista resultado
                iLisRes.Add(iLibProTer);
            }

            //devolver
            return iLisRes;
        }

        public static string ConvertirListaACampoDetalleCantidadesSemiProducto(List<LiberacionProTer> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //---------
            //convertir
            //---------

            //recorrer cada objeto
            foreach (LiberacionProTer xLibProTer in pLista)
            {
                iValor += xLibProTer.ClaveLiberacion + ";";
                iValor += xLibProTer.FechaLote + ";";
                iValor += xLibProTer.FechaVcto + ";";
                iValor += Formato.NumeroDecimal(xLibProTer.Cantidad, 2) + ";";
                iValor += Formato.NumeroDecimal(xLibProTer.CostoTotalProducto, 2) + ";";
                iValor += xLibProTer.FechaProduccionDeta + "|";
            }

            //devolver
            return iValor;
        }

        public static void ModificarSaldoLiberacionAlAdicionar(List<ProduccionProTerEN> pLista)
        {
            //lista a grabar en bd
            List<LiberacionEN> iLisLibMod = new List<LiberacionEN>();

            //convertir todos los campos detalle a una lista LiberacionProTer
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCamposDetalleCantidadesSemiProductoALista(pLista);

            //traer a todas las liberaciones que hay en iLisLibProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClavesLiberacion(iLisLibProTer);

            //recorrer cada LiberacionProTer
            foreach (LiberacionProTer xLibProTer in iLisLibProTer)
            {
                //buscar al objeto liberacion
                LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                //actualizar el saldo
                iLibBusEN.SaldoUnidadesAEmpacar -= xLibProTer.Cantidad;

                //agregar a la lista a modificar
                iLisLibMod.Add(iLibBusEN);
            }

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLisLibMod);
        }

        public static List<LiberacionProTer> ConvertirCamposDetalleCantidadesSemiProductoALista(List<ProduccionProTerEN> pLista)
        {
            //lista resultado
            List<LiberacionProTer> iLisRes = new List<LiberacionProTer>();

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in pLista)
            {
                List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(xProProTer.DetalleCantidadesSemiProducto);
                iLisRes.AddRange(iLisLibProTer);
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarSaldoLiberacionAlEliminar(string pClaveEncajado)
        {
            //lista a grabar en bd
            List<LiberacionEN> iLisLibMod = new List<LiberacionEN>();

            //traer a los ProduccionesProTer
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pClaveEncajado);

            //convertir todos los campos detalle a una lista LiberacionProTer
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCamposDetalleCantidadesSemiProductoALista(iLisProProTer);

            //traer a todas las liberaciones que hay en iLisLibProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClavesLiberacion(iLisLibProTer);

            //recorrer cada LiberacionProTer
            foreach (LiberacionProTer xLibProTer in iLisLibProTer)
            {
                //buscar al objeto liberacion
                LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                //actualizar el saldo
                iLibBusEN.SaldoUnidadesAEmpacar += xLibProTer.Cantidad;

                //agregar a la lista a modificar
                iLisLibMod.Add(iLibBusEN);
            }

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLisLibMod);
        }

        public static decimal CalcularNumeroCajasReales(ProduccionProTerEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.UnidadesPorEmpaque = pObj.UnidadesPorEmpaque;
            iProProTerEN.CantidadUnidadesProTer = pObj.CantidadUnidadesRealEncajado;

            //ejecutar metodo
            return ProduccionProTerRN.CalcularNumeroCajas(iProProTerEN);
        }

        public static ProduccionProTerEN EsCantidadUnidadesRealesCorrecta(ProduccionProTerEN pObj)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar
            if (pObj.CantidadUnidadesRealEncajado > pObj.CantidadUnidadesProTer)
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "La cantidad real no puede ser mayor a la cantidad planificada para encajar";
            }

            //devolver
            return iProProTerEN;
        }

        public static decimal CalcularUnidadesDevueltas(ProduccionProTerEN pObj)
        {
            //ejecutar metodo
            return pObj.CantidadUnidadesProTer - pObj.CantidadUnidadesRealEncajado;
        }

        public static List<LiberacionProTer> ListarLiberacionesProTerConDevolucion(ProduccionProTerEN pObj)
        {
            //convertir el campo detalle a lista
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(pObj.DetalleCantidadesSemiProducto);

            //cambiar el orden de esta lista
            iLisLibProTer.Reverse();

            //saldo a rebajar
            decimal iSaldo = pObj.CantidadDevueltaEncajado;

            //recorrer cada objeto
            foreach (LiberacionProTer xLib in iLisLibProTer)
            {
                //si el saldo es cero, entonces salir del foreach
                if (iSaldo == 0) { break; }

                //calcular
                if (iSaldo > xLib.Cantidad)
                {
                    iSaldo -= xLib.Cantidad;
                    xLib.Cantidad = 0;
                }
                else
                {
                    xLib.Cantidad -= iSaldo;
                    iSaldo = 0;
                }
            }

            //cambiar el orden de esta lista
            iLisLibProTer.Reverse();

            //devolver
            return iLisLibProTer;
        }

        public static List<LiberacionProTer> ListarLiberacionesProTerParaGenerarLotesAProductoTerminado(ProduccionProTerEN pObj)
        {
            //lista resultado
            List<LiberacionProTer> iLisRes = new List<LiberacionProTer>();

            //listar a las liberacionesProTer de este objeto pero ya con la devolucion de unidades que no se empaqueto
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ListarLiberacionesProTerConDevolucion(pObj);

            //a esta lista debemos acumular las cantidades con FechaLote iguales
            iLisRes = ListaG.Acumular<LiberacionProTer>(iLisLibProTer, LiberacionProTer.FecLot, LiberacionProTer.Can);

            //devolver
            return iLisRes;
        }

        //public static void ActualizarPorRecalculoEncajado(List<ProduccionProTerEN> pLisProProTer, List<MovimientoDetaEN> pLisMovDet,
        //     List<ProduccionExisEN> pLisProExi, List<FormulaDetaEN> pLisForDet, decimal pFactorCosto, FactorCIFEN pFacCif)
        //{
        //    //listas a grabar en bd
        //    List<ProduccionExisEN> iLisProExiMod = new List<ProduccionExisEN>();
        //    List<MovimientoDetaEN> iLisMovDetMod = new List<MovimientoDetaEN>();

        //    //obtener las liberaciones que se usaron en estas ProduccionesProTer
        //    List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(pLisProProTer);

        //    //recorrer cada objeto produccionProTer
        //    foreach (ProduccionProTerEN xProProTer in pLisProProTer)
        //    {
        //        //obtener solo la lista de produccionesExis solo de este produccionProTer
        //        List<ProduccionExisEN> iLisProExiFasEnc = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaProProTer, xProProTer.ClaveProduccionProTer);

        //        //obtener los movimientosDeta de la fase encajado de esta produccionProTer
        //        List<MovimientoDetaEN> iLisMovDetFasMas = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProProTer.ClaveSalidaFaseEmpaquetado);

        //        //actualizar los precios unitarios de las ProduccionesExis
        //        ProduccionExisRN.ActualizarPreciosUnitariosDesdeMovimientosDeta(iLisProExiFasEnc, iLisMovDetFasMas);

        //        //actualizar el campo detalle de este xProProTer
        //        ActualizarCampoDetalleCantidadesSemiProducto(xProProTer, iLisLib);

        //        //actualizar el costo unidad semiproducto
        //        xProProTer.CostoUnidadSemiProducto = ProduccionProTerRN.ObtenerCostoInsumoSemiProducto(xProProTer);

        //        //actualizar el costo empaquetado
        //        ActualizarCostosFaseEmpaquetadoProTer(xProProTer, iLisProExiFasEnc);

        //        //actualizar costo mano de obra
        //        ActualizarCostosManoObraProTer(xProProTer, pLisForDet, pFactorCosto);

        //        //actualizar costo gastos indirectos
        //        ActualizarCostosGastoIndirectoProTer(xProProTer, pLisForDet, pFacCif);

        //        //actualizar el precioPromedio de su MovimientoDeta
        //        //buscar su movimientoDeta de ingreso al almacen de productos terminados
        //        MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProProTer.ClaveIngresoProductoTerminado,
        //            MovimientoDetaEN.CodExi, xProProTer.CodigoExistencia);

        //        //actualizar el dato precio promedio
        //        iMovDetBusEN.PrecioUnitarioMovimientoDeta = xProProTer.CostoTotalProducto;

        //        //agregar a la lista resultado
        //        iLisMovDetMod.Add(iMovDetBusEN);

        //        //agregamos a la lista resultado a modificar en b.d
        //        iLisProExiMod.AddRange(iLisProExiFasEnc);
        //    }

        //    //grabaciones masivas en bd
        //    ProduccionExisRN.ModificarProduccionExis(iLisProExiMod);
        //    MovimientoDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
        //    ProduccionProTerRN.ModificarProduccionProTer(pLisProProTer);
        //}

        public static void ActualizarPorRecalculoEncajado(List<ProduccionProTerEN> pLisProProTer, List<MovimientoDetaEN> pLisMovDet,
         List<ProduccionExisEN> pLisProExi, List<FormulaDetaEN> pLisForDet, decimal pFactorCosto, FactorCIFEN pFacCif)
        {
            //listas a grabar en bd
            List<ProduccionExisEN> iLisProExiMod = new List<ProduccionExisEN>();
            List<MovimientoDetaEN> iLisMovDetMod = new List<MovimientoDetaEN>();

            //obtener las liberaciones que se usaron en estas ProduccionesProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(pLisProProTer);

            //recorrer cada objeto produccionProTer
            foreach (ProduccionProTerEN xProProTer in pLisProProTer)
            {
                //obtener solo la lista de produccionesExis solo de este produccionProTer
                List<ProduccionExisEN> iLisProExiFasEnc = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaProProTer, xProProTer.ClaveProduccionProTer);

                //obtener los movimientosDeta de la fase encajado de esta produccionProTer
                List<MovimientoDetaEN> iLisMovDetFasMas = new List<MovimientoDetaEN>();
                if (xProProTer.ClaveSalidaFaseEmpaquetado == string.Empty)
                {
                    iLisMovDetFasMas = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaProTerParEmp, xProProTer.ClaveProduccionProTer);
                }
                else
                {
                    iLisMovDetFasMas = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProProTer.ClaveSalidaFaseEmpaquetado);
                }

                //actualizar los precios unitarios de las ProduccionesExis
                ProduccionExisRN.ActualizarPreciosUnitariosDesdeMovimientosDeta(iLisProExiFasEnc, iLisMovDetFasMas);

                //actualizar el campo detalle de este xProProTer
                ActualizarCampoDetalleCantidadesSemiProducto(xProProTer, iLisLib);

                //actualizar el costo unidad semiproducto
                xProProTer.CostoUnidadSemiProducto = ProduccionProTerRN.ObtenerCostoInsumoSemiProducto(xProProTer);

                //actualizar el costo empaquetado
                List<MovimientoDetaEN> iLisMovDetProTer = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaProProTer, xProProTer.ClaveProduccionProTer);
                ActualizarCostosFaseEmpaquetadoProTer(xProProTer, iLisProExiFasEnc, iLisMovDetProTer);

                //actualizar costo mano de obra
                ActualizarCostosManoObraProTer(xProProTer, pLisForDet, pFactorCosto);

                //actualizar costo gastos indirectos
                ActualizarCostosGastoIndirectoProTer(xProProTer, pLisForDet, pFacCif);

                //actualizar el precioPromedio de su MovimientoDeta
                //buscar su movimientoDeta de ingreso al almacen de productos terminados
                MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProProTer.ClaveIngresoProductoTerminado,
                    MovimientoDetaEN.CodExi, xProProTer.CodigoExistencia);

                //actualizar el dato precio promedio
                iMovDetBusEN.PrecioUnitarioMovimientoDeta = xProProTer.CostoTotalProducto;

                //agregar a la lista resultado
                iLisMovDetMod.Add(iMovDetBusEN);

                //agregamos a la lista resultado a modificar en b.d
                iLisProExiMod.AddRange(iLisProExiFasEnc);
            }

            //grabaciones masivas en bd
            ProduccionExisRN.ModificarProduccionExis(iLisProExiMod);
            MovimientoDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
            ProduccionProTerRN.ModificarProduccionProTer(pLisProProTer);
        }


        public static List<ProduccionProTerEN> ListarProduccionProTerXPeriodoEncajado(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerXPeriodoEncajado(pObj);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXPeriodoEncajado(string pAño, string pCodigoMes)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.PeriodoEncajado = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iProProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.ClaProProTer;

            //ejecutar metodo
            return ListarProduccionProTerXPeriodoEncajado(iProProTerEN);
        }

        public static void ActualizarCampoDetalleCantidadesSemiProducto(ProduccionProTerEN pProProTer, List<LiberacionEN> pLisLib)
        {
            //convertir a LiberacionProTer
            List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(pProProTer.DetalleCantidadesSemiProducto);

            //recorrer cada objeto
            foreach (LiberacionProTer xLibProTer in iLisLibProTer)
            {
                //buscar a la liberacion
                LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(pLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                //actualizar datos
                xLibProTer.CostoTotalProducto = iLibBusEN.CostoTotalProducto;
            }

            //modificar el campo detalle
            pProProTer.DetalleCantidadesSemiProducto = ConvertirListaACampoDetalleCantidadesSemiProducto(iLisLibProTer);
        }

        public static void ActualizarCostosFaseEmpaquetadoProTer(ProduccionProTerEN pObjProProTer, List<ProduccionExisEN> pLisProExi)
        {
            //obtener el costo fase empaquetado semiEla principal
            pObjProProTer.CostoEmpaquetadoPrincipal = ProduccionExisRN.ObtenerCostoTotal(pLisProExi);

            ////obtener el costo cc masa adicional
            //xProProTer.CostoEmpaquetadoAdicional = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoAdicional(pProDet, xProProTer);

            ////obtener el costo cc devolucion
            //xProProTer.CostoEmpaquetadoDevolucion = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoDevolucion(pProDet, xProProTer);

            //obtener el costo cc masa total
            pObjProProTer.CostoEmpaquetadoTotal = ProduccionProTerRN.ObtenerCostoEmpaquetadoTotal(pObjProProTer);

            //obtener costo de unidad de masa
            pObjProProTer.CostoUnidadEmpaquetado = ProduccionProTerRN.ObtenerCostoUnidadEmpaquetado(pObjProProTer);

            //obtener el costo unidad total de insumos
            pObjProProTer.CostoInsumos = ProduccionProTerRN.ObtenerCostoUnidadProTerInsumos(pObjProProTer);

            //obtener el costo unidad total del producto
            pObjProProTer.CostoTotalProducto = ProduccionProTerRN.ObtenerCostoUnidadProTer(pObjProProTer);
        }

        public static List<List<ProduccionProTerEN>> ListarListasProduccionProTerPorClaveEncajado(string pAño, string pCodigoMes)
        {
            //traemos la lista de produccionesProTer para recalculo mano obra
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerParaRecalculoManoObra(pAño, pCodigoMes);

            //obtener una lista de listas de produccionProTer por Parte de trabajo
            List<List<ProduccionProTerEN>> iLisLisProProTer = ListaG.ListarListas<ProduccionProTerEN>(iLisProProTer,
                ProduccionProTerEN.ClaEnc);

            //devolver
            return iLisLisProProTer;
        }

        public static List<List<ProduccionProTerEN>> ListarListasProduccionProTerPorCodigoExistencia(string pAño, string pCodigoMes)
        {
            //traemos la lista de produccionesProTer para recalculo mano obra
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerParaRegenerarCamposDetalleProTer(pAño, pCodigoMes);

            //obtener una lista de listas de produccionProTer por Parte de trabajo
            List<List<ProduccionProTerEN>> iLisLisProProTer = ListaG.ListarListas<ProduccionProTerEN>(iLisProProTer,
                ProduccionProTerEN.CodExi);

            //devolver
            return iLisLisProProTer;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerParaRegenerarCamposDetalleProTer(string pAño, string pCodigoMes)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.PeriodoEncajado = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iProProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.CodExi;

            //ejecutar metodo
            return ProduccionProTerRN.ListarProduccionProTerParaRecalculoManoObra(iProProTerEN);
        }

        public static List<List<ProduccionProTerEN>> ListarListasProduccionProTerParaRegenerarCamposDetalleProTer(string pAño, string pCodigoMes)
        {
            //lista resultado
            List<List<ProduccionProTerEN>> iLisRes = new List<List<ProduccionProTerEN>>();

            //traer todas las producciones proter del periodo en proceso
            List<List<ProduccionProTerEN>> iLisLisProProTer = ProduccionProTerRN.ListarListasProduccionProTerPorCodigoExistencia(pAño, pCodigoMes);

            //traer todas liberaciones del periodo en proceso
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXPeriodo(pAño, pCodigoMes);

            //traer todas las formulas deta que tienen proter
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaConCodigoExistenciaProTer();

            //recorrer cada lista
            foreach (List<ProduccionProTerEN> xLisProProTer in iLisLisProProTer)
            {
                //obtener las liberaciones solo de este proter
                FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(xLisProProTer[0]);
                List<LiberacionEN> iLisLibProTer = ListaG.Filtrar<LiberacionEN>(iLisLib, LiberacionEN.CodSemPro, iForDetEN.CodigoSemiProducto);

                //obtener la fecha de la primera liberacion
                string iFechaLiberacion = ListaG.ObtenerPrimerValor<LiberacionEN>(iLisLibProTer, LiberacionEN.FecLib);

                //creamos una lista para los nuevos elementos que cumplan la condicion
                List<ProduccionProTerEN> iLisProProTerNue = new List<ProduccionProTerEN>();

                //recorrer cada objeto
                foreach (ProduccionProTerEN xProProTer in xLisProProTer)
                {
                    if (Fecha.EsMayorQue(xProProTer.FechaEncajado, iFechaLiberacion) == true)
                    {
                        iLisProProTerNue.Add(xProProTer);
                    }
                }

                //si hay elemenos,insertamos a la lista resultado
                if (iLisProProTerNue.Count != 0)
                {
                    iLisRes.Add(iLisProProTerNue);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerClaveFormulaCabe(ProduccionProTerEN pObj)
        {
            //traer a un detalle formula
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pObj);

            //devolver
            return iForDetEN.ClaveFormulaCabe;
        }

        public static void ActualizarPorcentajesYCantidadesRango(ProduccionProTerEN pObj)
        {
            //asignar parametros
            List<RangoDetaEN> iLisRanDetFasEnc = RangoDetaRN.ListarRangosDeta(pObj);

            //ejecutar metodo
            pObj.PorcentajeUnidadesRango = ObtenerPorcentajeUnidadesRango(pObj, iLisRanDetFasEnc);
            pObj.CantidadUnidadesRango = ObtenerCantidadUnidadesRango(pObj);
            pObj.PorcentajeCajasRango = ObtenerPorcentajeCajasRango(pObj, iLisRanDetFasEnc);
            pObj.CantidadCajasRango = ObtenerCantidadCajasRango(pObj);
        }

        public static decimal ObtenerPorcentajeUnidadesRango(ProduccionProTerEN pObj, List<RangoDetaEN> pLisRanDetFasEnc)
        {
            //asignar parametros
            decimal iCantidad = pObj.CantidadUnidadesProTer;
            List<RangoDetaEN> iLisRanDetFasEncUni = ListaG.Filtrar<RangoDetaEN>(pLisRanDetFasEnc, RangoDetaEN.CTipFac, "1");

            //ejecutar metodo
            return RangoDetaRN.ObtenerPorcentajeRangoDetaDeCantidad(iCantidad, iLisRanDetFasEncUni);
        }

        public static decimal ObtenerCantidadUnidadesRango(ProduccionProTerEN pObj)
        {
            return (pObj.CantidadUnidadesProTer * pObj.PorcentajeUnidadesRango) / 100;
        }

        public static decimal ObtenerPorcentajeCajasRango(ProduccionProTerEN pObj, List<RangoDetaEN> pLisRanDetFasEnc)
        {
            //asignar parametros
            decimal iCantidad = pObj.NumeroCajas;
            List<RangoDetaEN> iLisRanDetFasEncCaj = ListaG.Filtrar<RangoDetaEN>(pLisRanDetFasEnc, RangoDetaEN.CTipFac, "2");

            //ejecutar metodo
            return RangoDetaRN.ObtenerPorcentajeRangoDetaDeCantidad(iCantidad, iLisRanDetFasEncCaj);
        }

        public static decimal ObtenerCantidadCajasRango(ProduccionProTerEN pObj)
        {
            return (pObj.NumeroCajas * pObj.PorcentajeCajasRango) / 100;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerParaPlanificacionEncajadoDetalleLiberacion()
        {
            //lista resultado
            List<ProduccionProTerEN> iLisRes = new List<ProduccionProTerEN>();

            //traer la lista para planificacionEncajado
            List<ProduccionProTerEN> iLisProProTer = ListarProduccionProTerParaPlanificacionEncajado();

            //recorrer cada objeto produccionProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //obtener la lista de LiberacionProTer
                List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(xProProTer.DetalleCantidadesSemiProducto);

                //recorrer cada objeto LiberacionProTer
                foreach (LiberacionProTer xLibProTer in iLisLibProTer)
                {
                    //clonar al xProProTer
                    ProduccionProTerEN iProProTerNueEN = ObjetoG.Clonar<ProduccionProTerEN>(xProProTer);

                    //completar datos
                    iProProTerNueEN.FechaLoteProTer = xLibProTer.FechaLote;
                    iProProTerNueEN.FechaVctoProTer = xLibProTer.FechaVcto;
                    iProProTerNueEN.CantidadUnidadesProTer = xLibProTer.Cantidad;
                    //iProProTerNueEN.ClaveProduccionDeta = ObtenerClaveProduccionDeta(xLibProTer.ClaveLiberacion);
                    iProProTerNueEN.ClaveProduccionDeta = ObtenerClaveProduccionDetaSoloParteTrabajo(xLibProTer.ClaveLiberacion);

                    //agregar a la lista resultado
                    iLisRes.Add(iProProTerNueEN);
                }

                //si la lista esta vacia,entonces agregamos al objeto principal
                if (iLisLibProTer.Count == 0)
                {
                    iLisRes.Add(xProProTer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerDeAlmacenYExistencia(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerDeAlmacenYExistencia(pObj);
        }

        public static ProduccionProTerEN EsProduccionProTerValido(ProduccionProTerEN pObj)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //valida cuando esta vacio
            if (pObj.ClaveProduccionProTer == string.Empty) { return iProProTerEN; }

            //valida cuando el codigo no existe
            iProProTerEN = ProduccionProTerRN.EsProduccionProTerExistente(pObj);
            if (iProProTerEN.Adicionales.EsVerdad == false) { return iProProTerEN; }

            //ok           
            return iProProTerEN;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerNoSeleccionadasEnGrilla(ProduccionProTerEN pObj, List<RetiquetadoProTerEN> pLisRetProTerGrilla)
        {
            //lista resultado
            List<ProduccionProTerEN> iLisRes = new List<ProduccionProTerEN>();

            //traer todas las produccionesproter del almacen y existencia indicada de b.d
            List<ProduccionProTerEN> iLisProProTer = ListarProduccionProTerDeAlmacenYExistencia(pObj);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //flag encontrado
                bool iEncontrado = ListaG.Existe<RetiquetadoProTerEN>(pLisRetProTerGrilla, RetiquetadoProTerEN.CorEnc, xProProTer.CorrelativoEncajado);

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == false) { iLisRes.Add(xProProTer); }
            }

            //devolver
            return iLisRes;
        }

        public static ProduccionProTerEN EsProduccionProTerValido(ProduccionProTerEN pObj, Universal.Opera pOperacionVentana,
          string pClaveProduccionProTerFranjaGrilla, List<RetiquetadoProTerEN> pLisRetProTerGrilla)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //valida cuando esta vacio
            if (pObj.ClaveProduccionProTer == string.Empty) { return iProProTerEN; }

            //valida cuando el codigo no existe
            iProProTerEN = ProduccionProTerRN.EsProduccionProTerExistente(pObj);
            if (iProProTerEN.Adicionales.EsVerdad == false) { return iProProTerEN; }

            //valida cuando el codigo ya se registro en la grilla
            ProduccionProTerEN iProProTerExiEN = ValidaCuandoCodigoYaExisteEnGrilla(iProProTerEN, pOperacionVentana, pClaveProduccionProTerFranjaGrilla, pLisRetProTerGrilla);
            if (iProProTerExiEN.Adicionales.EsVerdad == false) { return iProProTerExiEN; }

            //ok           
            return iProProTerEN;
        }

        public static ProduccionProTerEN ValidaCuandoCodigoYaExisteEnGrilla(ProduccionProTerEN pObj, Universal.Opera pOperacionVentana,
           string pClaveProduccionProTerFranjaGrilla, List<RetiquetadoProTerEN> pLisRetProTerGrilla)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar   
            RetiquetadoProTerEN iRetProTerEN = ListaG.Buscar<RetiquetadoProTerEN>(pLisRetProTerGrilla, RetiquetadoProTerEN.ClaProProTer, pObj.ClaveProduccionProTer);
            if (iRetProTerEN.ClaveProduccionProTer != string.Empty)
            {
                if (pOperacionVentana == Universal.Opera.Adicionar || (pOperacionVentana == Universal.Opera.Modificar && iProProTerEN.ClaveProduccionProTer != pClaveProduccionProTerFranjaGrilla))
                {
                    iProProTerEN.Adicionales.EsVerdad = false;
                    iProProTerEN.Adicionales.Mensaje = "Este Encajado ya se registro en la grilla";
                }
            }

            //ok           
            return iProProTerEN;
        }

        public static void ModificarCostosIngresoIndirectoProTer(EncajadoEN pObj)
        {
            //listar a los ProduccionProTer 
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pObj.ClaveEncajado);

            //listar todas las FormulasDetas con codigoexistencia ProTer
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaConCodigoExistenciaProTer();

            //obtener el objeto factor para esta produccion
            FactorCIFEN iFacCifEN = FactorCIFRN.BuscarFactorCosto(pObj);

            //actualizamos los datos de empaquetado
            ActualizarCostosGastoIndirectoProTer(iLisProProTer, iLisForDet, iFacCifEN);

            //modificar en bd
            ProduccionProTerRN.ModificarProduccionProTer(iLisProProTer);
        }

        public static void ActualizarCostosGastoIndirectoProTer(List<ProduccionProTerEN> pLisProProTer, List<FormulaDetaEN> pLisForDet, FactorCIFEN pFac)
        {
            //recorrer cada lista
            foreach (ProduccionProTerEN xProProTer in pLisProProTer)
            {
                //buscar al objeto FormulaDeta para esta accion
                FormulaDetaEN iForDetBusEN = ListaG.Buscar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CodExiProTer, xProProTer.CodigoExistencia);

                //actualizar
                ActualizarCostosGastoIndirectoProTer(xProProTer, iForDetBusEN.MasaUnidad, pFac);
            }
        }

        public static void ActualizarCostosGastoIndirectoProTer(ProduccionProTerEN pObj, decimal pMasaUnidad, FactorCIFEN pFac)
        {
            //sino hay cantidad real,entonces termina proceso
            if (pObj.CantidadUnidadesRealEncajado == 0) { return; }

            //actualizar datos
            pObj.FactorCifProTer = pFac.FactorCif;
            pObj.CostoGastoIndirecto = CalcularCostoUnitarioGastoIndirecto(pFac.FactorCif, pMasaUnidad);
            pObj.FactorCIFFijo = FactorCIFRN.ObtenerFactorCIFFijo(pFac);
            pObj.CostoCIFFijo = ProduccionProTerRN.CalcularCostoUnitarioGastoIndirecto(pObj.FactorCIFFijo, pMasaUnidad);
            pObj.FactorCIFVariable = FactorCIFRN.ObtenerFactorCIFVariable(pFac);
            pObj.CostoCIFVariable = ProduccionProTerRN.CalcularCostoUnitarioGastoIndirecto(pObj.FactorCIFVariable, pMasaUnidad);

            //obtener el costo unidad total del producto
            pObj.CostoTotalProducto = ObtenerCostoUnidadProTer(pObj);
        }

        public static decimal CalcularCostoUnitarioGastoIndirecto(decimal pFactorCif, decimal pMasaUnidad)
        {
            //la masaUnidad esta en gramos, convertir a kg
            decimal iMasaUnidadKg = pMasaUnidad / 1000;

            //calcular
            return Math.Round(pFactorCif * iMasaUnidadKg, 6);
        }

        public static void ActualizarCostosGastoIndirectoProTer(ProduccionProTerEN pProProTer, List<FormulaDetaEN> pLisForDet, FactorCIFEN pFac)
        {
            //buscar al objeto FormulaDeta para esta accion
            FormulaDetaEN iForDetBusEN = ListaG.Buscar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CodExiProTer, pProProTer.CodigoExistencia);

            //actualizar
            ActualizarCostosGastoIndirectoProTer(pProProTer, iForDetBusEN.MasaUnidad, pFac);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerParaReporteCostoUnitarioPorFechas(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);
        }

        public static List<ProduccionProTerEN> ObtenerReporteCostoUnitarioPorFechas(ProduccionProTerEN pObj)
        {
            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisRes = ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisRes)
            {
                //actualizar campo de lotes
                xProProTer.FechaLoteProTer = ObtenerFechasLotesDeProductoTerminado(xProProTer);
            }

            //obtener objeto totales
            ProduccionProTerEN iProProTerTot = ObtenerObjetoTotalesReporteCostosUnitariosPorFecha(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iProProTerTot);

            //devolver
            return iLisRes;
        }

        public static string ObtenerFechasLotesDeProductoTerminado(ProduccionProTerEN pObj)
        {
            //valor resultado
            string iValor = string.Empty;

            //convertir campo detalle
            List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(pObj.DetalleCantidadesSemiProducto);

            //armar campo separado por comas
            iValor = ListaG.ArmarCadenaDeValores<LiberacionProTer>(iLisLibProTer, LiberacionProTer.FecLot, " ,");

            //devolver
            return iValor;
        }

        public static ProduccionProTerEN ObtenerObjetoTotalesReporteCostosUnitariosPorFecha(List<ProduccionProTerEN> pLista)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //obtener la lista acumulada de pLista            
            List<ProduccionProTerEN> iLisProProTerAcu = ListaG.Acumular<ProduccionProTerEN>(pLista, ProduccionProTerEN.CodEmp,
                ObtenerListaCamposAAcumularReporteCostoUnitarioPorFechas());

            //si la lista esta vacia
            if (iLisProProTerAcu.Count != 0)
            {
                iProProTerEN = iLisProProTerAcu[0];
            }

            //actualizar datos a este objeto
            iProProTerEN.FechaEncajado = string.Empty;
            iProProTerEN.CodigoExistencia = string.Empty;
            iProProTerEN.DescripcionExistencia = string.Empty;
            iProProTerEN.FechaLoteProTer = "TOTALES";

            //devolver
            return iProProTerEN;
        }

        public static List<ProduccionProTerEN> ObtenerReporteCostoUnitarioPromedioAcumulado(ProduccionProTerEN pObj)
        {
            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisRes = ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //primero acumulamos por fecha
            iLisRes = ListaG.Acumular<ProduccionProTerEN>(iLisRes, ProduccionProTerEN.FecEnc, ObtenerListaCamposAAcumularReporteCostoUnitarioPorFechas());

            //obtener objeto totales
            ProduccionProTerEN iProProTerTot = ObtenerObjetoTotalesReporteCostosUnitariosPorFecha(iLisRes);
            iProProTerTot.FechaEncajado = "TOTALES";

            //agregar a la lista resultado
            iLisRes.Add(iProProTerTot);

            //devolver
            return iLisRes;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostoUnitarioPorFechas()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(ProduccionProTerEN.CosIns);
            iLisRes.Add(ProduccionProTerEN.CosManObr);
            iLisRes.Add(ProduccionProTerEN.CosGasInd);
            iLisRes.Add(ProduccionProTerEN.CosTotPro);

            //devolver
            return iLisRes;
        }

        public static List<ProduccionProTerEN> ObtenerReporteCostoUnitarioVariabilidadCostos(ProduccionProTerEN pObj)
        {
            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisRes = ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //listar todas las FormulasDetas con codigoexistencia ProTer
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaConCodigoExistenciaProTer();

            //listar los factores cif
            List<FactorCIFEN> iLisFacCif = FactorCIFRN.ListarFactorCostos();

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisRes)
            {
                //buscar al objeto FormulaDeta para esta accion
                FormulaDetaEN iForDetBusEN = ListaG.Buscar<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExiProTer, xProProTer.CodigoExistencia);

                //buscar el factor cif
                FactorCIFEN iFacCifBusEN = ListaG.Buscar<FactorCIFEN>(iLisFacCif, FactorCIFEN.CodFacCif, xProProTer.PeriodoEncajado);

                //obtener el factor para esta produccion
                decimal iFactorCifFijo = FactorCIFRN.ObtenerFactorCIFFijo(iFacCifBusEN);

                //actualizar campo de lotes
                xProProTer.FechaLoteProTer = ObtenerFechasLotesDeProductoTerminado(xProProTer);
                xProProTer.CostoGastoIndirectoFijo = CalcularCostoUnitarioGastoIndirecto(iFactorCifFijo, iForDetBusEN.MasaUnidad);
                xProProTer.CostoGastoIndirectoVariable = xProProTer.CostoGastoIndirecto - xProProTer.CostoGastoIndirectoFijo;
            }

            //obtener objeto totales
            ProduccionProTerEN iProProTerTot = ObtenerObjetoTotalesReporteCostosUnitariosVariabilidadCostos(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iProProTerTot);

            //devolver
            return iLisRes;
        }

        public static ProduccionProTerEN ObtenerObjetoTotalesReporteCostosUnitariosVariabilidadCostos(List<ProduccionProTerEN> pLista)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //obtener la lista acumulada de pLista            
            List<ProduccionProTerEN> iLisProProTerAcu = ListaG.Acumular<ProduccionProTerEN>(pLista, ProduccionProTerEN.CodEmp,
                ObtenerListaCamposAAcumularReporteCostoUnitarioVariabilidadCostos());

            //si la lista esta vacia
            if (iLisProProTerAcu.Count != 0)
            {
                iProProTerEN = iLisProProTerAcu[0];
            }

            //actualizar datos a este objeto
            iProProTerEN.FechaEncajado = string.Empty;
            iProProTerEN.CodigoExistencia = string.Empty;
            iProProTerEN.DescripcionExistencia = string.Empty;
            iProProTerEN.FechaLoteProTer = "TOTALES";

            //devolver
            return iProProTerEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostoUnitarioVariabilidadCostos()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(ProduccionProTerEN.CosGasIndFij);
            iLisRes.Add(ProduccionProTerEN.CosGasIndVar);
            iLisRes.Add(ProduccionProTerEN.CosGasInd);

            //devolver
            return iLisRes;
        }

        public static List<VersusCosto> ObtenerReportePresupuestadoVsRealPorProducto(ProduccionProTerEN pObj)
        {
            //lista resultado
            List<VersusCosto> iLisRes = new List<VersusCosto>();

            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisProTer = ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //traer la lista de producciones deta referenciadas en iLisProTer
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionesDetaReferenciadasEnProduccionProTer(iLisProTer);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProTer)
            {
                //crear objeto versus (materia prima)
                VersusCosto iVerCosMatPri = new VersusCosto();
                iVerCosMatPri.Elemento = "MATERIA PRIMA";
                iVerCosMatPri.Presupuestado = ObtenerCostoPresupuestado(xProProTer, iLisProDet);
                iVerCosMatPri.Real = xProProTer.CostoInsumos;
                iVerCosMatPri.Diferencia = ObtenerDiferenciaVersus(iVerCosMatPri);
                iLisRes.Add(iVerCosMatPri);

                //crear objeto versus (mano obra)
                VersusCosto iVerCosManObr = new VersusCosto();
                iVerCosManObr.Elemento = "MANO DE OBRA";
                iVerCosManObr.Presupuestado = xProProTer.CostoManoObra;
                iVerCosManObr.Real = xProProTer.CostoManoObra;
                iVerCosManObr.Diferencia = ObtenerDiferenciaVersus(iVerCosManObr);
                iLisRes.Add(iVerCosManObr);

                //crear objeto versus (cif)
                VersusCosto iVerCosCIF = new VersusCosto();
                iVerCosCIF.Elemento = "CIF";
                iVerCosCIF.Presupuestado = xProProTer.CostoGastoIndirecto;
                iVerCosCIF.Real = xProProTer.CostoGastoIndirecto;
                iVerCosCIF.Diferencia = ObtenerDiferenciaVersus(iVerCosCIF);
                iLisRes.Add(iVerCosCIF);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerDiferenciaVersus(VersusCosto pObj)
        {
            return pObj.Presupuestado - pObj.Real;
        }

        public static decimal ObtenerCostoPresupuestado(ProduccionProTerEN pProProTer, List<ProduccionDetaEN> pLisProDet)
        {
            //valor resultado
            decimal ivalor = 0;

            //obtener la lista liberacionProTer
            List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(pProProTer.DetalleCantidadesSemiProducto);

            //recorrer cada objeto liberacionProTer
            foreach (LiberacionProTer xLibProTer in iLisLibProTer)
            {
                //buscar al produccionDeta de esta liberacionProTer
                string iClaveProduccionDeta = ObtenerClaveProduccionDeta(xLibProTer.ClaveLiberacion);
                ProduccionDetaEN iProDetEN = ListaG.Buscar<ProduccionDetaEN>(pLisProDet, ProduccionDetaEN.ClaProDet, iClaveProduccionDeta);

                //obtener el costo unitario teorico para esta produccionDeta
                xLibProTer.CostoInsumos = ProduccionDetaRN.ObtenerCostoUnidadTeorica(iProDetEN);
            }

            //obtener el costo promedio unitario semi eleaborado para este producto terminado
            ivalor = ObtenerCostoInsumoSemiProducto(iLisLibProTer);

            //le sumamos el costo unitario empaquetado teorico
            ivalor += ObtenerCostoEncajadoUnidadTeorica(pProProTer);

            //devolver
            return ivalor;
        }

        public static decimal ObtenerCostoEncajadoUnidadTeorica(ProduccionProTerEN pObj)
        {
            //calcular            
            decimal iCostoUnidad = Math.Round(Operador.DivisionDecimal(pObj.CostoEmpaquetadoPrincipal, pObj.CantidadUnidadesProTer), 2);

            //devolver
            return iCostoUnidad;
        }

        public static string ObtenerClaveProduccionDeta(string pClaveLiberacion)
        {
            return Cadena.CortarCadena(pClaveLiberacion, 17);
        }

        public static string ObtenerClaveProduccionDetaSoloParteTrabajo(string pClaveLiberacion)
        {
            pClaveLiberacion = pClaveLiberacion.Substring(8, 6);
            return pClaveLiberacion;             
        }

        public static List<VersusCosto> ObtenerReportePresupuestadoVsRealPorFechas(ProduccionProTerEN pObj)
        {
            //lista resultado
            List<VersusCosto> iLisRes = new List<VersusCosto>();

            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisProTer = ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //traer la lista de producciones deta referenciadas en iLisProTer
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionesDetaReferenciadasEnProduccionProTer(iLisProTer);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProTer)
            {
                //obtener las producciones deta referenciadas en este xProProTer
                List<ProduccionDetaEN> iLisProDetProTer = ProduccionDetaRN.ListarProduccionesDetaReferenciadasEnProduccionProTer(xProProTer, iLisProDet);

                //buscar a la existencia en la lista resultado
                VersusCosto iVerCosBus = ListaG.Buscar<VersusCosto>(iLisRes, VersusCosto.CodExi, xProProTer.CodigoExistencia);
                if (iVerCosBus.CodigoExistencia == string.Empty)
                {
                    //crear objeto versus (materia prima)
                    VersusCosto iVerCosMatPri = new VersusCosto();
                    iVerCosMatPri.CodigoExistencia = xProProTer.CodigoExistencia;
                    iVerCosMatPri.Elemento = "MATERIA PRIMA";
                    iVerCosMatPri.Presupuestado = ObtenerCostoPresupuestado(xProProTer, iLisProDetProTer);
                    iVerCosMatPri.Real = xProProTer.CostoInsumos;
                    iVerCosMatPri.Diferencia = ObtenerDiferenciaVersus(iVerCosMatPri);
                    iLisRes.Add(iVerCosMatPri);

                    //crear objeto versus (mano obra)
                    VersusCosto iVerCosManObr = new VersusCosto();
                    iVerCosManObr.CodigoExistencia = xProProTer.CodigoExistencia;
                    iVerCosManObr.Elemento = "MANO DE OBRA";
                    iVerCosManObr.Presupuestado = xProProTer.CostoManoObra;
                    iVerCosManObr.Real = xProProTer.CostoManoObra;
                    iVerCosManObr.Diferencia = ObtenerDiferenciaVersus(iVerCosManObr);
                    iLisRes.Add(iVerCosManObr);

                    //crear objeto versus (cif)
                    VersusCosto iVerCosCIF = new VersusCosto();
                    iVerCosCIF.CodigoExistencia = xProProTer.CodigoExistencia;
                    iVerCosCIF.Elemento = "CIF";
                    iVerCosCIF.Presupuestado = xProProTer.CostoGastoIndirecto;
                    iVerCosCIF.Real = xProProTer.CostoGastoIndirecto;
                    iVerCosCIF.Diferencia = ObtenerDiferenciaVersus(iVerCosCIF);
                    iLisRes.Add(iVerCosCIF);
                }
                else
                {
                    //buscar al de materia prima
                    VersusCosto iVerCosMatPriBus = ListaG.Buscar<VersusCosto>(iLisRes, VersusCosto.CodExi, xProProTer.CodigoExistencia,
                        VersusCosto.Ele, "MATERIA PRIMA");
                    iVerCosMatPriBus.Presupuestado += ObtenerCostoPresupuestado(xProProTer, iLisProDetProTer);
                    iVerCosMatPriBus.Real += xProProTer.CostoInsumos;
                    iVerCosMatPriBus.Diferencia = ObtenerDiferenciaVersus(iVerCosMatPriBus);
                    ListaG.Modificar<VersusCosto>(iLisRes, iVerCosMatPriBus, VersusCosto.CodExi, xProProTer.CodigoExistencia,
                        VersusCosto.Ele, "MATERIA PRIMA");

                    //buscar al de mano obra
                    VersusCosto iVerCosManObrBus = ListaG.Buscar<VersusCosto>(iLisRes, VersusCosto.CodExi, xProProTer.CodigoExistencia,
                        VersusCosto.Ele, "MANO DE OBRA");
                    iVerCosManObrBus.Presupuestado += xProProTer.CostoInsumos;
                    iVerCosManObrBus.Real += xProProTer.CostoInsumos;
                    iVerCosManObrBus.Diferencia = ObtenerDiferenciaVersus(iVerCosManObrBus);
                    ListaG.Modificar<VersusCosto>(iLisRes, iVerCosManObrBus, VersusCosto.CodExi, xProProTer.CodigoExistencia,
                        VersusCosto.Ele, "MANO DE OBRA");

                    //buscar al de CIF
                    VersusCosto iVerCosCIFBus = ListaG.Buscar<VersusCosto>(iLisRes, VersusCosto.CodExi, xProProTer.CodigoExistencia,
                        VersusCosto.Ele, "CIF");
                    iVerCosCIFBus.Presupuestado += xProProTer.CostoInsumos;
                    iVerCosCIFBus.Real += xProProTer.CostoInsumos;
                    iVerCosCIFBus.Diferencia = ObtenerDiferenciaVersus(iVerCosCIFBus);
                    ListaG.Modificar<VersusCosto>(iLisRes, iVerCosCIFBus, VersusCosto.CodExi, xProProTer.CodigoExistencia,
                        VersusCosto.Ele, "CIF");
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<AcumuladoProceso> ObtenerReporteAcumuladosPorProceso(string pFechaDesde, string pFechaHasta)
        {
            //lista resultado
            List<AcumuladoProceso> iLisRes = new List<AcumuladoProceso>();

            //traer todas las ProduccionesDeta de este rango
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaXRangoFechaProduccion(pFechaDesde, pFechaHasta);

            //traer todas las liberaciones de este rango
            List<LiberacionEN> iLisLib = LiberacionRN.ListarProduccionDetaXRangoFechaLiberacion(pFechaDesde, pFechaHasta);

            //traer todas las ProduccionesProTer de este rango
            List<ProduccionProTerEN> iLisProProTer = ListarProduccionProTerXRangoFechaEncajado(pFechaDesde, pFechaHasta);

            //crear objeto AcumuladoProceso(Materia Prima)
            AcumuladoProceso iAcuProMatPri = new AcumuladoProceso();
            iAcuProMatPri.Elemento = "MATERIA PRIMA";
            iAcuProMatPri.Produccion = ListaG.Sumar<ProduccionDetaEN>(iLisProDet, ProduccionDetaEN.CosIns);
            iAcuProMatPri.Liberacion = ListaG.Sumar<LiberacionEN>(iLisLib, LiberacionEN.CosIns);
            iAcuProMatPri.Encajado = ListaG.Sumar<ProduccionProTerEN>(iLisProProTer, ProduccionProTerEN.CosIns);
            iAcuProMatPri.Costo = ObtenerCostoAcumuladoProceso(iAcuProMatPri);
            iLisRes.Add(iAcuProMatPri);

            //crear objeto AcumuladoProceso(Mano obra)
            AcumuladoProceso iAcuProManObr = new AcumuladoProceso();
            iAcuProManObr.Elemento = "MANO DE OBRA";
            iAcuProManObr.Produccion = 0;
            iAcuProManObr.Liberacion = 0;
            iAcuProManObr.Encajado = ListaG.Sumar<ProduccionProTerEN>(iLisProProTer, ProduccionProTerEN.CosManObr);
            iAcuProManObr.Costo = ObtenerCostoAcumuladoProceso(iAcuProManObr);
            iLisRes.Add(iAcuProManObr);

            //crear objeto AcumuladoProceso(CIF)
            AcumuladoProceso iAcuProCIF = new AcumuladoProceso();
            iAcuProCIF.Elemento = "CIF";
            iAcuProCIF.Produccion = 0;
            iAcuProCIF.Liberacion = 0;
            iAcuProCIF.Encajado = ListaG.Sumar<ProduccionProTerEN>(iLisProProTer, ProduccionProTerEN.CosGasInd);
            iAcuProCIF.Costo = ObtenerCostoAcumuladoProceso(iAcuProCIF);
            iLisRes.Add(iAcuProCIF);

            //crear objeto AcumuladoProceso(TOTALES)
            AcumuladoProceso iAcuProTOT = new AcumuladoProceso();
            iAcuProTOT.Elemento = "TOTALES";
            iAcuProTOT.Produccion = ListaG.Sumar<AcumuladoProceso>(iLisRes, AcumuladoProceso.Pro);
            iAcuProTOT.Liberacion = ListaG.Sumar<AcumuladoProceso>(iLisRes, AcumuladoProceso.Lib);
            iAcuProTOT.Encajado = ListaG.Sumar<AcumuladoProceso>(iLisRes, AcumuladoProceso.Enc);
            iAcuProTOT.Costo = ListaG.Sumar<AcumuladoProceso>(iLisRes, AcumuladoProceso.Cos);
            iLisRes.Add(iAcuProTOT);

            //devolver
            return iLisRes;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXRangoFechaEncajado(string pFechaDesde, string pFechaHasta)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.Adicionales.Desde1 = pFechaDesde;
            iProProTerEN.Adicionales.Hasta1 = pFechaHasta;

            //ejecutar metodo
            return ListarProduccionProTerParaReporteCostoUnitarioPorFechas(iProProTerEN);
        }

        public static decimal ObtenerCostoAcumuladoProceso(AcumuladoProceso pObj)
        {
            return pObj.Produccion + pObj.Liberacion + pObj.Encajado;
        }

        public static List<ProduccionProTerEN> ObtenerReporteCostoLoteFaseEncajado(ProduccionProTerEN pObj)
        {
            //lista resultado
            List<ProduccionProTerEN> iLisRes = new List<ProduccionProTerEN>();

            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisProProTer = ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //listar las liberaciones que intervienen en estas ProduccionesProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(iLisProProTer);

            //listar objetos con montos acumulados aprobados hasta antes de este filtro de fechas
            List<ProduccionProTerEN> iLisProProTerAcu = ListarCantidadesAcumuladasAprobadasParaReporteCostoLoteFaseEncajado(iLisLib, pObj.Adicionales.Desde1);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //obtener la lista LiberacionProTer de este xProProTer
                List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(xProProTer.DetalleCantidadesSemiProducto);

                //recorrer cada objeto LiberacionProTer
                foreach (LiberacionProTer xLibProTer in iLisLibProTer)
                {
                    //buscar a la liberacion este xLibProTer
                    LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                    //clonar al objeto xProProTer
                    ProduccionProTerEN iProProTerNewEN = ObjetoG.Clonar<ProduccionProTerEN>(xProProTer);

                    //actualizar datos                                   
                    iProProTerNewEN.ClaveProduccionDeta = iLibBusEN.ClaveProduccionDeta;
                    iProProTerNewEN.FechaLoteProTer = iLibBusEN.FechaProduccionDeta;//xxxxxxxxxxxx
                    iProProTerNewEN.ClaveProduccionCabe = iLibBusEN.CorrelativoProduccionCabe;
                    //iProProTerNewEN.CodigoExistencia = xProProTer.CodigoExistencia;
                    //iProProTerNewEN.DescripcionExistencia = xProProTer.DescripcionExistencia;
                    iProProTerNewEN.UnidadesAprobadasLote = iLibBusEN.UnidadesAprobadasLiberacion;
                    iProProTerNewEN.UnidadesEncajadasLote = iLibBusEN.UnidadesPasan;
                    iProProTerNewEN.PorcentajeEncajadoLote = ObtenerPorcentajeEncajadoLote(iProProTerNewEN);
                    iProProTerNewEN.PorcentajeEncajadoAcumulado = ObtenerPorcentajeEncajadoAcumulado(iProProTerNewEN, iLisProProTerAcu);
                    iProProTerNewEN.CostoEmpaquetadoTotal = ObtenerCostoEmbalajes(iProProTerNewEN);
                    iProProTerNewEN.CostoTotalManoObra = ObtenerCostoManoObra(iProProTerNewEN);
                    iProProTerNewEN.CostoCIFVariable = ObtenerCostoTotalCIFVariable(iProProTerNewEN);
                    iProProTerNewEN.CostoTotalVariable = ObtenerCostoTotalVariable(iProProTerNewEN);
                    iProProTerNewEN.CostoCIFFijo = ObtenerCostoTotalCIFFijo(iProProTerNewEN);
                    iProProTerNewEN.CostoTotalEncajado = ObtenerCostoTotalEncajado(iProProTerNewEN);
                    iProProTerNewEN.CostoTotalProducto = ObtenerCostoUnitarioEncajado(iProProTerNewEN);
                    iProProTerNewEN.CostoUnitarioEncajadoFijo = ObtenerCostoUnitarioEncajadoFijo(iProProTerNewEN);
                    iProProTerNewEN.CostoUnitarioEncajadoVariable = ObtenerCostoUnitarioEncajadoVariable(iProProTerNewEN);
                    iProProTerNewEN.CostoUnidadSemiProducto = iLibBusEN.CostoTotalProducto;
                    iProProTerNewEN.CostoUnitarioEnvasadoFijo = iLibBusEN.CostoCIFFijo;

                    //agregar a la lista resultado
                    iLisRes.Add(iProProTerNewEN);
                }
            }

            //obtener objeto totales
            ProduccionProTerEN iProProTerTot = ObtenerObjetoTotalesReporteCostoLoteFaseEncajado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iProProTerTot);

            //devolver
            return iLisRes;
        }

        public static ProduccionProTerEN ObtenerObjetoTotalesReporteCostoLoteFaseEncajado(List<ProduccionProTerEN> pLista)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //obtener la lista acumulada de pLista            
            List<ProduccionProTerEN> iLisProProTerAcu = ListaG.Acumular<ProduccionProTerEN>(pLista, ProduccionProTerEN.CodEmp,
                ObtenerListaCamposAAcumularReporteCostoLoteFaseEncajado());

            //si la lista esta vacia
            if (iLisProProTerAcu.Count != 0)
            {
                iProProTerEN = ObjetoG.Clonar<ProduccionProTerEN>(iLisProProTerAcu[0]);
            }

            //actualizar datos a este objeto           
            iProProTerEN.FechaEncajado = string.Empty;
            iProProTerEN.ClaveProduccionCabe = string.Empty;
            iProProTerEN.CodigoExistencia = string.Empty;
            iProProTerEN.DescripcionExistencia = "TOTALES";
            iProProTerEN.UnidadesAprobadasLote = 0;
            iProProTerEN.UnidadesEncajadasLote = 0;
            iProProTerEN.PorcentajeEncajadoLote = 0;
            iProProTerEN.PorcentajeEncajadoAcumulado = 0;
            iProProTerEN.CostoTotalProducto = 0;
            iProProTerEN.CostoUnitarioEncajadoFijo = 0;
            iProProTerEN.CostoUnitarioEncajadoVariable = 0;
            iProProTerEN.FechaLoteProTer = string.Empty;

            //devolver
            return iProProTerEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostoLoteFaseEncajado()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(ProduccionProTerEN.CosEmpTot);
            iLisRes.Add(ProduccionProTerEN.CosTotManObr);
            iLisRes.Add(ProduccionProTerEN.CosCIFVar);
            iLisRes.Add(ProduccionProTerEN.CosTotVar);
            iLisRes.Add(ProduccionProTerEN.CosCIFFij);
            iLisRes.Add(ProduccionProTerEN.CosTotEnc);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerPorcentajeEncajadoLote(ProduccionProTerEN pObj)
        {
            return Math.Round(Operador.DivisionDecimal(pObj.UnidadesEncajadasLote, pObj.UnidadesAprobadasLote) * 100, 2);
        }

        public static decimal ObtenerPorcentajeEncajadoAcumulado(ProduccionProTerEN pObj, List<ProduccionProTerEN> pLisProProTerAcu)
        {
            //buscar al objeto por su claveProduccionDeta
            ProduccionProTerEN iProProTerBusEN = ListaG.Buscar<ProduccionProTerEN>(pLisProProTerAcu, ProduccionProTerEN.ClaProDet, pObj.ClaveProduccionDeta);

            //sumar la cantidad unidades de pObj
            iProProTerBusEN.CantidadUnidadesProTer += pObj.UnidadesEncajadasLote;

            //actualizar la lista acumulado
            ListaG.Modificar<ProduccionProTerEN>(pLisProProTerAcu, iProProTerBusEN, ProduccionProTerEN.ClaProDet, pObj.ClaveProduccionDeta);

            //devolver
            return Math.Round(Operador.DivisionDecimal(iProProTerBusEN.CantidadUnidadesProTer, pObj.UnidadesAprobadasLote) * 100, 2);
        }

        public static decimal ObtenerCostoEmbalajes(ProduccionProTerEN pObj)
        {
            return Math.Round(pObj.UnidadesEncajadasLote * pObj.CostoUnidadEmpaquetado, 2);
        }

        public static decimal ObtenerCostoManoObra(ProduccionProTerEN pObj)
        {
            return Math.Round(pObj.UnidadesEncajadasLote * pObj.CostoManoObra, 2);
        }

        public static decimal ObtenerCostoTotalCIFVariable(ProduccionProTerEN pObj)
        {
            return Math.Round(pObj.UnidadesEncajadasLote * pObj.CostoCIFVariable, 2);
        }

        public static decimal ObtenerCostoTotalVariable(ProduccionProTerEN pObj)
        {
            return pObj.CostoEmpaquetadoTotal + pObj.CostoTotalManoObra + pObj.CostoCIFVariable;
        }

        public static decimal ObtenerCostoTotalCIFFijo(ProduccionProTerEN pObj)
        {
            return Math.Round(pObj.UnidadesEncajadasLote * pObj.CostoCIFFijo, 2);
        }

        public static decimal ObtenerCostoTotalEncajado(ProduccionProTerEN pObj)
        {
            return pObj.CostoTotalVariable + pObj.CostoCIFFijo;
        }

        public static decimal ObtenerCostoUnitarioEncajado(ProduccionProTerEN pObj)
        {
            return Math.Round(Operador.DivisionDecimal(pObj.CostoTotalEncajado, pObj.UnidadesEncajadasLote), 6);
        }

        public static decimal ObtenerCostoUnitarioEncajadoFijo(ProduccionProTerEN pObj)
        {
            return Math.Round(Operador.DivisionDecimal(pObj.CostoCIFFijo, pObj.UnidadesEncajadasLote), 6);
        }

        public static decimal ObtenerCostoUnitarioEncajadoVariable(ProduccionProTerEN pObj)
        {
            return Math.Round(Operador.DivisionDecimal(pObj.CostoTotalVariable, pObj.UnidadesEncajadasLote), 6);
        }

        public static List<ProduccionProTerEN> ListarCantidadesAcumuladasAprobadasParaReporteCostoLoteFaseEncajado(List<LiberacionEN> pLisLibFiltro
            , string pFechaAnterior)
        {
            //lista resultado
            List<ProduccionProTerEN> iLisRes = new List<ProduccionProTerEN>();

            //filtrar sin repetir clave
            List<LiberacionEN> iLisLibProDet = ListaG.FiltrarObjetosSinRepetir<LiberacionEN>(pLisLibFiltro, LiberacionEN.CorProCab);

            //listar produccionesProTer anteriores a la lista filtro
            List<LiberacionEN> iLisLibAnt = LiberacionRN.ListarLiberacionAnteriorParaReporteCostoLoteEtapaEncajado(iLisLibProDet);

            //recorrer cada objeto
            foreach (LiberacionEN xLib in iLisLibAnt)
            {
                //sacar la ClaveProduccionCabe
                string iClaveProduccionDeta = xLib.ClaveProduccionDeta;

                //buscar
                ProduccionProTerEN iProProTerBusEN = ListaG.Buscar<ProduccionProTerEN>(iLisRes, ProduccionProTerEN.ClaProDet, iClaveProduccionDeta);

                //si no esta en la lista resultado,entonces lo agregamos como un nuevo objeto
                if (iProProTerBusEN.ClaveProduccionDeta == string.Empty)
                {
                    //crear un objeto
                    ProduccionProTerEN iProProTerNewEN = new ProduccionProTerEN();
                    iProProTerNewEN.ClaveProduccionDeta = iClaveProduccionDeta;
                    iProProTerNewEN.CantidadUnidadesProTer = xLib.UnidadesPasan;

                    //agregar a lista resultado
                    iLisRes.Add(iProProTerNewEN);
                }
                else
                {
                    //acumular
                    iProProTerBusEN.CantidadUnidadesProTer += xLib.UnidadesPasan;

                    //actualizar la lista resultado
                    ListaG.Modificar<ProduccionProTerEN>(iLisRes, iProProTerBusEN, ProduccionProTerEN.ClaProDet, iClaveProduccionDeta);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerAnteriorParaReporteCostoLoteEtapaEncajado(List<LiberacionEN> pLisLib, string pFechaAnterior)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerAnteriorParaReporteCostoLoteEtapaEncajado(pLisLib, pFechaAnterior);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTer()
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTer();
        }

        public static void AgregarFechaProduccionACampoDetalleCantidadesSemiProducto()
        {
            //lista resultado
            List<ProduccionProTerEN> iLisProProTerMod = new List<ProduccionProTerEN>();

            //traer todas las produccionesProTer
            List<ProduccionProTerEN> iLisProProTer = ListarProduccionProTer();

            //traer todas las liberaciones
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacion();

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                if (xProProTer.DetalleCantidadesSemiProducto != string.Empty)
                {
                    List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(xProProTer.DetalleCantidadesSemiProducto);
                    foreach (LiberacionProTer xLibProTer in iLisLibProTer)
                    {
                        LiberacionEN iLibEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);
                        xLibProTer.FechaProduccionDeta = iLibEN.FechaProduccionDeta;
                    }
                    xProProTer.DetalleCantidadesSemiProducto = ConvertirListaACampoDetalleCantidadesSemiProducto(iLisLibProTer);
                    iLisProProTerMod.Add(xProProTer);
                }
            }

            //modificar masivo
            ModificarProduccionProTer(iLisProProTerMod);
        }

        public static List<ProduccionProTerEN> ObtenerReporteCostoLoteFaseEncajado(RetiquetadoEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.Adicionales.Desde1 = pObj.Adicionales.Desde1;
            iProProTerEN.Adicionales.Hasta1 = pObj.Adicionales.Hasta1;
            iProProTerEN.CodigoExistencia = pObj.CodigoExistenciaRE;

            //ejecutar metodo
            return ObtenerReporteCostoLoteFaseEncajado(iProProTerEN);
        }

        public static List<CostoUnitarioProTer> ObtenerReporteCostoUnitarioPromedioAcumuladoActualizado(ProduccionProTerEN pObj)
        {
            //lista resultado
            List<CostoUnitarioProTer> iLisRes = new List<CostoUnitarioProTer>();

            //-----------------------------
            //obtener reporte fase encajado
            //-----------------------------
            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisProProTer = ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //listar las liberaciones que intervienen en estas ProduccionesProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(iLisProProTer);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //obtener la lista LiberacionProTer de este xProProTer
                List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(xProProTer.DetalleCantidadesSemiProducto);

                //recorrer cada objeto LiberacionProTer
                foreach (LiberacionProTer xLibProTer in iLisLibProTer)
                {
                    //buscar a la liberacion este xLibProTer
                    LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                    //clonar al objeto xProProTer
                    CostoUnitarioProTer iCosProTerNew = new CostoUnitarioProTer();

                    //actualizar datos        
                    iCosProTerNew.CodigoEmpresa = Universal.gCodigoEmpresa;          
                    iCosProTerNew.FechaProTer = xProProTer.FechaEncajado;
                    iCosProTerNew.FechaLote = iLibBusEN.FechaProduccionDeta;
                    iCosProTerNew.CorrelativoProCab = iLibBusEN.CorrelativoProduccionCabe;
                    iCosProTerNew.CodigoExistencia = xProProTer.CodigoExistencia;
                    iCosProTerNew.DescripcionExistencia = xProProTer.DescripcionExistencia;
                    iCosProTerNew.MateriaPrimaUnitario = iLibBusEN.CostoUnidadMasa;//costo fase masa + costo reproceso unitario
                    iCosProTerNew.EnvaseUnitario = iLibBusEN.CostoUnidadConCal;//costo fase envasado
                    iCosProTerNew.ManoObraUnitario = ObtenerCostoManoObraUnitario(iLibBusEN, xProProTer);
                    iCosProTerNew.CostoCifUnitario = ObtenerCostoCifUnitario(iLibBusEN, xProProTer);
                    iCosProTerNew.CostoUnitario = ObtenerCostoUnitario(iCosProTerNew);
                    iCosProTerNew.MateriaPrima = ObtenerCostoMateriaPrima(xLibProTer, iCosProTerNew);
                    iCosProTerNew.Envase = ObtenerCostoEnvases(xLibProTer, iCosProTerNew);
                    iCosProTerNew.ManoObra = ObtenerCostoManoObra(xLibProTer, iCosProTerNew);
                    iCosProTerNew.CostoCif = ObtenerCostoCif(xLibProTer, iCosProTerNew);
                    iCosProTerNew.CostoTotal = ObtenerCostoTotal(iCosProTerNew);

                    //agregar a la lista resultado
                    iLisRes.Add(iCosProTerNew);
                }
            }

            //obtener objeto totales
            CostoUnitarioProTer iCosProTerTot = ObtenerObjetoTotalesReporteCostoUnitarioPromedioAcumuladoActualizado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iCosProTerTot);

            //devolver
            return iLisRes;
        }

        public static CostoUnitarioProTer ObtenerObjetoTotalesReporteCostoUnitarioPromedioAcumuladoActualizado(List<CostoUnitarioProTer> pLista)
        {
            //objeto resultado
            CostoUnitarioProTer iProProTerEN = new CostoUnitarioProTer();

            //obtener la lista acumulada de pLista            
            List<CostoUnitarioProTer> iLisProProTerAcu = ListaG.Acumular<CostoUnitarioProTer>(pLista, CostoUnitarioProTer.CodEmp,
                ObtenerListaCamposAAcumularReporteCostoUnitarioPromedioAcumuladoActualizado());

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
            iProProTerEN.DescripcionExistencia = "TOTALES";
            iProProTerEN.MateriaPrimaUnitario = 0;
            iProProTerEN.EnvaseUnitario = 0;
            iProProTerEN.EmbalajeUnitario = 0;
            iProProTerEN.ManoObraUnitario = 0;
            iProProTerEN.CostoCifUnitario = 0;
            iProProTerEN.CostoUnitario = 0;
            
            //devolver
            return iProProTerEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostoUnitarioPromedioAcumuladoActualizado()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(CostoUnitarioProTer.UniPro);
            iLisRes.Add(CostoUnitarioProTer.MatPri);
            iLisRes.Add(CostoUnitarioProTer.Env);
            iLisRes.Add(CostoUnitarioProTer.Emb);
            iLisRes.Add(CostoUnitarioProTer.ManObr);
            iLisRes.Add(CostoUnitarioProTer.CosCif);
            iLisRes.Add(CostoUnitarioProTer.CosTot);            

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCostoManoObraUnitario(LiberacionEN pLib, ProduccionProTerEN pProProTer)
        {
            return pLib.CostoManoObra + pProProTer.CostoManoObra;
        }

        public static decimal ObtenerCostoCifUnitario(LiberacionEN pLib, ProduccionProTerEN pProProTer)
        {
            return pLib.CostoCIFFijo + pLib.CostoCIFVariable + pProProTer.CostoGastoIndirecto;
        }

        public static decimal ObtenerCostoUnitario(CostoUnitarioProTer pObj)
        {
            return pObj.MateriaPrimaUnitario + pObj.EnvaseUnitario + pObj.EmbalajeUnitario + pObj.ManoObraUnitario + pObj.CostoCifUnitario;
        }

        public static decimal ObtenerCostoManoObra(LiberacionProTer pLibProTer, CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEnvases(LiberacionProTer pLibProTer, CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EnvaseUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEmbalajes(LiberacionProTer pLibProTer, CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EmbalajeUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoMateriaPrima(LiberacionProTer pLibProTer, CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.MateriaPrimaUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCif(LiberacionProTer pLibProTer, CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoTotal(CostoUnitarioProTer pObj)
        {
            return pObj.MateriaPrima + pObj.Envase + pObj.Embalaje + pObj.ManoObra + pObj.CostoCif;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerParaReporteCostoUnitarioPorFechas(RetiquetadoEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.Adicionales.Desde1 = pObj.Adicionales.Desde1;
            iProProTerEN.Adicionales.Hasta1 = pObj.Adicionales.Hasta1;
            iProProTerEN.CodigoExistencia = pObj.CodigoExistenciaRE;

            //ejecutar metodo
            return ListarProduccionProTerParaReporteCostoUnitarioPorFechas(iProProTerEN);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerConCantidadRealXClaveEncajado(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerConCantidadRealXClaveEncajado(pObj);
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerConCantidadRealXClaveEncajado(string pClaveEncajado)
        {
            //asignar parametros
            ProduccionProTerEN iProTerEN = new ProduccionProTerEN();
            iProTerEN.ClaveEncajado = pClaveEncajado;
            iProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.CorProProTer;

            //ejecutar metodo
            return ListarProduccionProTerConCantidadRealXClaveEncajado(iProTerEN);
        }
        
        public static void ModificarPorDistribucionLiberacion(string pClaveProduccionProTer)
        {
            //traer a la produccionProTer de b.d
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.ClaveProduccionProTer = pClaveProduccionProTer;
            iProProTerEN = BuscarProduccionProTerXClave(iProProTerEN);

            //traer las liberaciones de b.d que estan relacionadas en este objeto
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClavesLiberacion(ConvertirCampoDetalleCantidadesSemiProductoALista(
                iProProTerEN.DetalleCantidadesSemiProducto));

            //traer los movimientos deta de esta produccionProTer solo salida y almacen "A11"
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientoDetaSalidasAdicionalesProduccionProTer(pClaveProduccionProTer);

            //calcular cantidad total de unidades encajadas
            iProProTerEN.CantidadUnidadesRealEncajado = ListaG.Sumar<LiberacionEN>(iLisLib, LiberacionEN.UniPas) +
                ListaG.Sumar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CanMovDet);

            //calcular el numero de caja reales
            iProProTerEN.CantidadCajasRealEncajado = CalcularNumeroCajasReales(iProProTerEN);

            //calcular la cantidad devuelta
            iProProTerEN.CantidadDevueltaEncajado = ListaG.Sumar<LiberacionEN>(iLisLib, LiberacionEN.UniObs) +
                ListaG.Sumar<LiberacionEN>(iLisLib, LiberacionEN.UniSal);//xxxxxxxxxxxxxxxxxxxxxxxxx

            //modificar en b.d
            ModificarProduccionProTer(iProProTerEN);
        }

        public static ProduccionProTerEN ValidadCantidadUnidadesParaDistribucion(List<LiberacionEN> pLisLib, decimal pCantidadADistribuir)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //recorre cada objeto
            foreach (LiberacionEN xLib in pLisLib)
            {
                //restamos la cantidad a distibuir
                pCantidadADistribuir -= xLib.SaldoUnidadesAEmpacar;

                //solo si llega a cero,entonces estara bien distribuido
                if (pCantidadADistribuir == 0)
                {
                    return iProProTerEN;
                }
            }

            //aqui no valida
            iProProTerEN.Adicionales.EsVerdad = false;
            iProProTerEN.Adicionales.Mensaje = "Se debe tomar la cantidad total de las liberaciones";
            return iProProTerEN;
        }

        public static void ActualizarCostosFaseEmpaquetadoProTer(ProduccionProTerEN pObjProProTer, List<ProduccionExisEN> pLisProExi,
             List<MovimientoDetaEN> pLisMovDetPro)
        {
            //obtener el costo fase empaquetado semiEla principal
            pObjProProTer.CostoEmpaquetadoPrincipal = ProduccionExisRN.ObtenerCostoTotal(pLisProExi);

            //obtener el costo cc masa adicional
            pObjProProTer.CostoEmpaquetadoAdicional = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoAdicional(pLisProExi, pLisMovDetPro);

            //obtener el costo cc devolucion
            pObjProProTer.CostoEmpaquetadoDevolucion = ProduccionProTerRN.ObtenerCostoFaseEmpaquetadoDevolucion(pLisProExi, pLisMovDetPro);

            //obtener el costo fase empaquetado segunda liberacion
            pObjProProTer.CostoEmpaquetadoSegundaLiberacion = ProduccionExisRN.ObtenerCostoTotalSegundaLiberacion(pLisProExi);

            //obtener el costo cc masa total
            pObjProProTer.CostoEmpaquetadoTotal = ProduccionProTerRN.ObtenerCostoEmpaquetadoTotal(pObjProProTer);

            //obtener costo de unidad de masa
            pObjProProTer.CostoUnidadEmpaquetado = ProduccionProTerRN.ObtenerCostoUnidadEmpaquetado(pObjProProTer);

            //obtener el costo unidad total de insumos
            pObjProProTer.CostoInsumos = ProduccionProTerRN.ObtenerCostoUnidadProTerInsumos(pObjProProTer);

            //obtener el costo unidad total del producto
            pObjProProTer.CostoTotalProducto = ProduccionProTerRN.ObtenerCostoUnidadProTer(pObjProProTer);
        }

        public static decimal ObtenerCostoFaseEmpaquetadoAdicional(List<ProduccionExisEN> pLisProExiEnc, List<MovimientoDetaEN> pLisMovDetEnc)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular            
            //armar una cadena con todos los codigos de existencia
            string iCodigosExistencia = ListaG.ArmarCadenaDeValores<ProduccionExisEN>(pLisProExiEnc, ProduccionExisEN.CodExi, ",");

            //filtrar los movimientosDeta de solo estos codigosexistencias
            List<MovimientoDetaEN> iLisMovDet = ListaG.FiltrarPorConjuntoValores<MovimientoDetaEN>(pLisMovDetEnc, MovimientoDetaEN.CodExi,
                iCodigosExistencia);

            //filtrar solo movimientosDeta de tipo "salida"
            iLisMovDet = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CClaTipOpe, "2");

            //recorrer cada objeto produccionexis
            foreach (MovimientoDetaEN xMovDet in iLisMovDet)
            {
                //buscar la existencia en la lista produccionExis
                ProduccionExisEN iProExiEN = ListaG.Buscar<ProduccionExisEN>(pLisProExiEnc, ProduccionExisEN.CodExi, xMovDet.CodigoExistencia);

                //calcular
                iValor += iProExiEN.PrecioUnitario * xMovDet.CantidadMovimientoDeta;
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseEmpaquetadoDevolucion(List<ProduccionExisEN> pLisProExiEnc, List<MovimientoDetaEN> pLisMovDetEnc)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular            
            //armar una cadena con todos los codigos de existencia
            string iCodigosExistencia = ListaG.ArmarCadenaDeValores<ProduccionExisEN>(pLisProExiEnc, ProduccionExisEN.CodExi, ",");

            //filtrar los movimientosDeta de solo estos codigosexistencias
            List<MovimientoDetaEN> iLisMovDet = ListaG.FiltrarPorConjuntoValores<MovimientoDetaEN>(pLisMovDetEnc, MovimientoDetaEN.CodExi,
                iCodigosExistencia);

            //filtrar solo movimientosDeta de tipo "ingreso"
            iLisMovDet = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CClaTipOpe, "1");

            //recorrer cada objeto produccionexis
            foreach (MovimientoDetaEN xMovDet in iLisMovDet)
            {
                //buscar la existencia en la lista produccionExis
                ProduccionExisEN iProExiEN = ListaG.Buscar<ProduccionExisEN>(pLisProExiEnc, ProduccionExisEN.CodExi, xMovDet.CodigoExistencia);

                //calcular
                iValor += iProExiEN.PrecioUnitario * xMovDet.CantidadMovimientoDeta;
            }

            //devolver
            return iValor;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerXClaveLiberacion(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerXClaveLiberacion(pObj);
        }

        public static decimal ObtenerCostoCifFijoUnitario(LiberacionEN pLib, ProduccionProTerEN pProProTer)
        {
            return pLib.CostoCIFFijo + pProProTer.CostoCIFFijo;
        }

        public static decimal ObtenerCostoCifVariableUnitario(LiberacionEN pLib, ProduccionProTerEN pProProTer)
        {
            return pLib.CostoCIFVariable + pProProTer.CostoCIFVariable;
        }

        public static decimal ObtenerCostoCifUnitario(CostoUnitarioProTer pObj)
        {
            return pObj.CostoCifFijoUnitario + pObj.CostoCifVariableUnitario;
        }

        public static decimal ObtenerCostoManoObraUnitarioTeorico(ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = pProProTer.CostoManoObra * pProProTer.CantidadUnidadesRealEncajado;
            iValor = Operador.DivisionDecimal(iValor, pProProTer.CantidadUnidadesProTer);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoManoObraUnitarioTeorico(RetiquetadoProTerEN pRetProTer)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.CostoManoObra = pRetProTer.CostoManoObra;
            iProProTerEN.CantidadUnidadesRealEncajado = pRetProTer.CantidadUnidadesRealEncajado;

            //ejecutar metodo
            return ObtenerCostoManoObraUnitarioTeorico(iProProTerEN);
        }

        public static decimal ObtenerCostoManoObraUnitarioTeorico(LiberacionEN pLib, ProduccionProTerEN pProProTer)
        {
            return ProduccionDetaRN.ObtenerCostoManoObraUnidadTeorica(pLib) + ObtenerCostoManoObraUnitarioTeorico(pProProTer);
        }

        public static decimal ObtenerCostoCifUnitarioTeorico(ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = ObtenerCostoCifFijoUnitarioTeorico(pProProTer) + ObtenerCostoCifVariableUnitarioTeorico(pProProTer);            
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifFijoUnitarioTeorico(ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = (pProProTer.CostoCIFFijo) * pProProTer.CantidadUnidadesRealEncajado;
            iValor = Operador.DivisionDecimal(iValor, pProProTer.CantidadUnidadesProTer);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifVariableUnitarioTeorico(ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = (pProProTer.CostoCIFVariable) * pProProTer.CantidadUnidadesRealEncajado;
            iValor = Operador.DivisionDecimal(iValor, pProProTer.CantidadUnidadesProTer);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifFijoUnitarioTeorico(RetiquetadoProTerEN pRetProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = (pRetProTer.CostoCIFFijo) * pRetProTer.CantidadUnidadesRealEncajado;
            iValor = Operador.DivisionDecimal(iValor, pRetProTer.CantidadUnidadesProTer);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifVariableUnitarioTeorico(RetiquetadoProTerEN pRetProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = (pRetProTer.CostoCIFVariable) * pRetProTer.CantidadUnidadesRealEncajado;
            iValor = Operador.DivisionDecimal(iValor, pRetProTer.CantidadUnidadesProTer);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifUnitarioTeorico(LiberacionEN pLib, ProduccionProTerEN pProProTer)
        {
            return ProduccionDetaRN.ObtenerCostoCifUnidadTeorica(pLib) + ObtenerCostoCifUnitarioTeorico(pProProTer);
        }

        public static decimal ObtenerPorcentajeVersus(VersusCosto pObj)
        {
            return Operador.Porcentaje(pObj.Real, pObj.Presupuestado, 3);
        }

        public static decimal ObtenerCostoManoObraEnvasado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioEnvasado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraEncajado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioEncajado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijo( CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariable(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitario * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoEnvasado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioEnvasado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableEnvasado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioEnvasado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoEncajado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioEncajado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableEncajado(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioEncajado * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoMateriaPrimaPlanificada( CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.MateriaPrimaUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEnvasesPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EnvaseUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoEmbalajesPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.EmbalajeUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraEnvasadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioEnvasadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoManoObraEncajadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.ManoObraUnitarioEncajadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifUnitarioPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoEnvasadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioEnvasadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableEnvasadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioEnvasadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifFijoEncajadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifFijoUnitarioEncajadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static decimal ObtenerCostoCifVariableEncajadoPlanificada(CostoUnitarioProTer pCosUniProTer)
        {
            return Math.Round(pCosUniProTer.CostoCifVariableUnitarioEncajadoPlanificada * pCosUniProTer.UnidadesProducidas, 2);
        }

        public static List<KpiDesmedro> ObtenerReporteKpiDesmedro(ProduccionProTerEN pObj)
        {
            //lista resultado
            List<KpiDesmedro> iLisRes = new List<KpiDesmedro>();

            //traer la lista para el reporte
            List<ProduccionProTerEN> iLisProProTer = ListarProduccionProTerParaReporteCostoUnitarioPorFechas(pObj);

            //listar las liberaciones que intervienen en estas ProduccionesProTer
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(iLisProProTer);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //obtener la lista LiberacionProTer de este xProProTer
                List<LiberacionProTer> iLisLibProTer = ConvertirCampoDetalleCantidadesSemiProductoALista(xProProTer.DetalleCantidadesSemiProducto);

                //recorrer cada objeto LiberacionProTer
                foreach (LiberacionProTer xLibProTer in iLisLibProTer)
                {
                    //buscar a la liberacion este xLibProTer
                    LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                    //creamos nuevo objeto kpi
                    KpiDesmedro iKipDes = new KpiDesmedro();

                    //actualizar datos            
                    iKipDes.ClaveObjeto = "x";                       
                    iKipDes.FechaProductoTerminado = xProProTer.FechaEncajado;
                    iKipDes.FechaEncajado = xProProTer.FechaEncajado;
                    iKipDes.Lote = iLibBusEN.FechaProduccionDeta;
                    iKipDes.Produccion = iLibBusEN.CorrelativoProduccionCabe;
                    iKipDes.Codigo = xProProTer.CodigoExistencia;
                    iKipDes.Descripcion = xProProTer.DescripcionExistencia;
                    iKipDes.CantidadPlanificada = iLibBusEN.CantidadSinceradoProduccionDeta;
                    iKipDes.CantidadProducida = iLibBusEN.CantidadRealProduccion;
                    iKipDes.AprobadoClaProUni = iLibBusEN.UnidadesAprobadasLiberacion;
                    iKipDes.ReprocesoClaProUni = iLibBusEN.UnidadesReprocesoLiberacion;
                    iKipDes.ObservacionClaProUni = iLibBusEN.UnidadesObservadasLiberacion;
                    iKipDes.DesmedroClaProUni = iLibBusEN.UnidadesDesechasLiberacion;
                    iKipDes.AprobadoClaEncUni = iLibBusEN.UnidadesPasan;
                    iKipDes.ReprocesoClaEncUni = iLibBusEN.UnidadesParaReproceso;
                    iKipDes.ObservacionClaEncUni = iLibBusEN.UnidadesObservadas;
                    iKipDes.DesmedroClaEncUni = iLibBusEN.UnidadesDesechas + iLibBusEN.UnidadesParaDonacion;
                    iKipDes.TotalDesmedroUni = iKipDes.DesmedroClaProUni + iKipDes.DesmedroClaEncUni;
                    iKipDes.AprobadoClaProPor = Operador.Porcentaje(iKipDes.AprobadoClaProUni, iKipDes.CantidadProducida, 2);
                    iKipDes.ReprocesoClaProPor = Operador.Porcentaje(iKipDes.ReprocesoClaProUni, iKipDes.CantidadProducida, 2);                   
                    iKipDes.ObservacionClaProPor = Operador.Porcentaje(iKipDes.ObservacionClaProUni, iKipDes.CantidadProducida, 2);
                    iKipDes.DesmedroClaProPor = Operador.Porcentaje(iKipDes.DesmedroClaProUni, iKipDes.CantidadProducida, 2);
                    iKipDes.AprobadoClaEncPor = Operador.Porcentaje(iKipDes.AprobadoClaEncUni, iKipDes.CantidadProducida, 2);
                    iKipDes.ReprocesoClaEncPor = Operador.Porcentaje(iKipDes.ReprocesoClaEncUni, iKipDes.CantidadProducida, 2);
                    iKipDes.ObservacionClaEncPor = Operador.Porcentaje(iKipDes.ObservacionClaEncUni, iKipDes.CantidadProducida, 2);
                    iKipDes.DesmedroClaEncPor = Operador.Porcentaje(iKipDes.DesmedroClaEncUni, iKipDes.CantidadProducida, 2);
                    iKipDes.TotalDesmedroPor = Operador.Porcentaje(iKipDes.TotalDesmedroUni, iKipDes.CantidadProducida, 2);
                    iKipDes.DesechoClaProUni = iLibBusEN.UnidadesDesechasLiberacion;
                    iKipDes.DonacionClaProUni = iLibBusEN.UnidadesParaDonacion;
                    
                    

                    //agregar a la lista resultado
                    iLisRes.Add(iKipDes);
                }
            }

            //obtener objeto totales
            KpiDesmedro iProProTerTot = ObtenerObjetoTotalesReporteKpiDesmedro(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iProProTerTot);

            //devolver
            return iLisRes;
        }

        public static KpiDesmedro ObtenerObjetoTotalesReporteKpiDesmedro(List<KpiDesmedro> pLista)
        {
            //objeto resultado
            KpiDesmedro iKpiDes = new KpiDesmedro();

            //obtener la lista acumulada de pLista            
            List<KpiDesmedro> iLisProProTerAcu = ListaG.Acumular<KpiDesmedro>(pLista, KpiDesmedro.ClaObj,
                ObtenerListaCamposAAcumularReporteKpiDesmedro());

            //si la lista esta vacia
            if (iLisProProTerAcu.Count != 0)
            {
                iKpiDes = ObjetoG.Clonar<KpiDesmedro>(iLisProProTerAcu[0]);
            }

            //actualizar datos a este objeto           
            iKpiDes.FechaProductoTerminado = string.Empty;
            iKpiDes.FechaEncajado = string.Empty;
            iKpiDes.Lote = string.Empty;
            iKpiDes.Produccion = string.Empty;
            iKpiDes.Codigo = string.Empty;
            iKpiDes.Descripcion = "TOTALES";
            iKpiDes.AprobadoClaProPor = 0;
            iKpiDes.ReprocesoClaProPor = 0;
            iKpiDes.ObservacionClaProPor = 0;
            iKpiDes.DesmedroClaProPor = 0;
            iKpiDes.AprobadoClaEncPor = 0;
            iKpiDes.ReprocesoClaEncPor = 0;
            iKpiDes.ObservacionClaEncPor = 0;
            iKpiDes.DesmedroClaEncPor = 0;
            iKpiDes.TotalDesmedroPor = 0;

            //devolver
            return iKpiDes;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteKpiDesmedro()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(KpiDesmedro.CanPla);
            iLisRes.Add(KpiDesmedro.CanPro);
            iLisRes.Add(KpiDesmedro.AprClaProUni);
            iLisRes.Add(KpiDesmedro.RepClaProUni);
            iLisRes.Add(KpiDesmedro.ObsClaProUni);
            iLisRes.Add(KpiDesmedro.DesClaProUni);
            iLisRes.Add(KpiDesmedro.AprClaEncUni);
            iLisRes.Add(KpiDesmedro.RepClaEncUni);
            iLisRes.Add(KpiDesmedro.ObsClaEncUni);
            iLisRes.Add(KpiDesmedro.DesClaEncUni);
            iLisRes.Add(KpiDesmedro.TotDesUni);

            //devolver
            return iLisRes;
        }

        public static void ModificarPorSalidaEtiquetaSegundaLiberacion(ProduccionProTerEN pProProTer)
        {
            //traer al ProduccionDeta de b.d
            ProduccionProTerEN iProProTerEN = BuscarProduccionProTerXClave(pProProTer);

            //actualizamos los datos
            iProProTerEN.ClaveSalidaEtiquetaSegundaLiberacion = pProProTer.ClaveSalidaEtiquetaSegundaLiberacion;

            //modificar en bd
            ModificarProduccionProTer(iProProTerEN);
        }

        public static void ModificarPorIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pProProTer)
        {
            //traer al ProduccionDeta de b.d
            ProduccionProTerEN iProProTerEN = BuscarProduccionProTerXClave(pProProTer);

            //actualizamos los datos
            iProProTerEN.ClaveIngresoSemiProductoSegundaLiberacion = pProProTer.ClaveIngresoSemiProductoSegundaLiberacion;

            //modificar en bd
            ModificarProduccionProTer(iProProTerEN);
        }

        public static ProduccionProTerEN EsActoEleccionSegundaLiberacion(ProduccionProTerEN pProProTer)
        {
            //objeto resultado
            ProduccionProTerEN iProCabEN = new ProduccionProTerEN();

            //validar si existe
            iProCabEN = EsProduccionProTerExistente(pProProTer);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando ya genero algun movimiento
            ProduccionProTerEN iProProTerMovEN = ValidaCuandoNoYaGeneroUnMovimiento(iProCabEN);
            if (iProProTerMovEN.Adicionales.EsVerdad == false) { return iProProTerMovEN; }

            //ok          
            return iProCabEN;
        }

        public static ProduccionProTerEN ValidaCuandoNoYaGeneroUnMovimiento(ProduccionProTerEN pProProTer)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar
            if (pProProTer.ClaveIngresoSemiProductoSegundaLiberacion != string.Empty )
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "Ya se genero el movimiento de ingreso de las unidades totales";
            }

            if (pProProTer.ClaveSalidaEtiquetaSegundaLiberacion != string.Empty)
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "Ya se genero el movimiento de salida de las etiquetas";
            }

            //devolver
            return iProProTerEN;
        }

        public static ProduccionProTerEN EsActoSalidaEtiquetasSegundaLiberacion(ProduccionProTerEN pProProTer)
        {
            //objeto resultado
            ProduccionProTerEN iProCabEN = new ProduccionProTerEN();

            //validar si existe
            iProCabEN = EsProduccionProTerExistente(pProProTer);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no eligio salida etiqueta
            ProduccionProTerEN iProProTerEtiEN = ValidaCuandoEleccionNoEsSalidaEtiqueta(iProCabEN);
            if (iProProTerEtiEN.Adicionales.EsVerdad == false) { return iProProTerEtiEN; }

            //ok          
            return iProCabEN;
        }

        public static ProduccionProTerEN ValidaCuandoEleccionNoEsSalidaEtiqueta(ProduccionProTerEN pProProTer)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar
            if (pProProTer.CEleccionSegundaLiberacion != "1")//salida etiqueta
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "Solo se ejecuta esta accion si se eligio salida etiquetas";
            }
            
            //devolver
            return iProProTerEN;
        }

        public static ProduccionProTerEN EsActoIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pProProTer)
        {
            //objeto resultado
            ProduccionProTerEN iProCabEN = new ProduccionProTerEN();

            //validar si existe
            iProCabEN = EsProduccionProTerExistente(pProProTer);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no eligio ingreso unidades
            ProduccionProTerEN iProProTerEtiEN = ValidaCuandoEleccionNoEsIngresoUnidades(iProCabEN);
            if (iProProTerEtiEN.Adicionales.EsVerdad == false) { return iProProTerEtiEN; }

            //ok          
            return iProCabEN;
        }

        public static ProduccionProTerEN ValidaCuandoEleccionNoEsIngresoUnidades(ProduccionProTerEN pProProTer)
        {
            //objeto resultado
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();

            //validar
            if (pProProTer.CEleccionSegundaLiberacion != "2")//ingreso unidades
            {
                iProProTerEN.Adicionales.EsVerdad = false;
                iProProTerEN.Adicionales.Mensaje = "Solo se ejecuta esta accion si se eligio ingreso unidades totales";
            }

            //devolver
            return iProProTerEN;
        }

        public static List<ProduccionProTerEN> ListarProduccionProTerParaIngresoProductoTerminado(ProduccionProTerEN pObj)
        {
            ProduccionProTerAD iProAD = new ProduccionProTerAD();
            return iProAD.ListarProduccionProTerParaIngresoProductoTerminado(pObj);
        }

    }
}
