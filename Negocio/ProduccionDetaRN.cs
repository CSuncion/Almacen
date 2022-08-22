using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;
using Entidades.Estructuras;
using System.Windows.Forms;

namespace Negocio
{
    public class ProduccionDetaRN
    {

        public static ProduccionDetaEN EnBlanco()
        {
            ProduccionDetaEN iProEN = new ProduccionDetaEN();
            return iProEN;
        }

        public static void AdicionarProduccionDeta(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            iProAD.AdicionarProduccionDeta(pObj);
        }

        public static void AdicionarProduccionDeta(List<ProduccionDetaEN> pLista)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            iProAD.AdicionarProduccionDeta(pLista);
        }

        public static void ModificarProduccionDeta(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            iProAD.ModificarProduccionDeta(pObj);
        }

        public static void ModificarProduccionDeta(List<ProduccionDetaEN> pLista)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            iProAD.ModificarProduccionDeta(pLista);
        }

        public static void EliminarProduccionDeta(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            iProAD.EliminarProduccionDeta(pObj);
        }

        public static ProduccionDetaEN BuscarProduccionDetaXClave(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.BuscarProduccionDetaXClave(pObj);
        }

        public static string ObtenerClaveProduccionDeta(ProduccionDetaEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CorrelativoProduccionCabe + "-";
            iClave += pObj.CorrelativoProduccionDeta;

            //devolver
            return iClave;
        }

        public static ProduccionDetaEN EsProduccionDetaExistente(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProEN = new ProduccionDetaEN();

            //valida
            iProEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj);
            if (iProEN.CorrelativoProduccionDeta == string.Empty)
            {
                iProEN.Adicionales.EsVerdad = false;
                iProEN.Adicionales.Mensaje = "El Parte de trabajo " + pObj.CorrelativoProduccionDeta + " no existe";
                return iProEN;
            }

            //ok
            return iProEN;
        }

        public static List<ProduccionDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<ProduccionDetaEN> pListaProduccionDeta)
        {
            //lista resultado
            List<ProduccionDetaEN> iLisRes = new List<ProduccionDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaProduccionDeta; }

            //filtar la lista
            iLisRes = ProduccionDetaRN.FiltrarProduccionDetaEnCualquierPosicion(pListaProduccionDeta, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<ProduccionDetaEN> FiltrarProduccionDetaEnCualquierPosicion(List<ProduccionDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<ProduccionDetaEN> iLisRes = new List<ProduccionDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (ProduccionDetaEN xPro in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<ProduccionDetaEN>(xPro, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPro);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(ProduccionDetaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case ProduccionDetaEN.ClaObj: return pObj.ClaveObjeto;
                case ProduccionDetaEN.ClaProDet: return pObj.ClaveProduccionDeta;
                case ProduccionDetaEN.ClaProCab: return pObj.ClaveProduccionCabe;
                case ProduccionDetaEN.CodEmp: return pObj.CodigoEmpresa;
                case ProduccionDetaEN.NomEmp: return pObj.NombreEmpresa;
                case ProduccionDetaEN.CodAlm: return pObj.CodigoAlmacen;
                case ProduccionDetaEN.DesAlm: return pObj.DescripcionAlmacen;
                case ProduccionDetaEN.CorProCab: return pObj.CorrelativoProduccionCabe;
                case ProduccionDetaEN.CorProDet: return pObj.CorrelativoProduccionDeta;
                case ProduccionDetaEN.CodExi: return pObj.CodigoExistencia;
                case ProduccionDetaEN.DesExi: return pObj.DescripcionExistencia;
                case ProduccionDetaEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case ProduccionDetaEN.NomUniMed: return pObj.NombreUnidadMedida;
                case ProduccionDetaEN.CodTipOpe: return pObj.CodigoTipoOperacion;
                case ProduccionDetaEN.DesTipOpe: return pObj.DescripcionTipoOperacion;
                case ProduccionDetaEN.FecProDet: return pObj.FechaProduccionDeta;
                case ProduccionDetaEN.PerProDet: return pObj.PeriodoProduccionDeta;
                case ProduccionDetaEN.FecSalFasMas: return pObj.FechaSalidaFaseMasa;
                case ProduccionDetaEN.FecIngAlm: return pObj.FechaIngresoAlmacen;
                case ProduccionDetaEN.SalProCab: return pObj.SaldoProduccionCabe.ToString();
                case ProduccionDetaEN.CanProDet: return pObj.CantidadProduccionDeta.ToString();
                case ProduccionDetaEN.ObsProDet: return pObj.ObservacionProduccionDeta;
                case ProduccionDetaEN.ClaSalFasMas: return pObj.ClaveSalidaFaseMasa;
                case ProduccionDetaEN.ClaIngMovCab: return pObj.ClaveIngresoMovimientoCabe;
                case ProduccionDetaEN.CodMer: return pObj.CodigoMercaderia;
                case ProduccionDetaEN.CEstProDet: return pObj.CEstadoProduccionDeta;
                case ProduccionDetaEN.NEstProDet: return pObj.NEstadoProduccionDeta;
                case ProduccionDetaEN.UsuAgr: return pObj.UsuarioAgrega;
                case ProduccionDetaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case ProduccionDetaEN.UsuMod: return pObj.UsuarioModifica;
                case ProduccionDetaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static ProduccionDetaEN EsActoAdicionarProduccionDeta(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //valida cuando es no es acto registrar en este periodo
            iProCabEN = ProduccionDetaRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //ok          
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoEsActoRegistrarEnPeriodo(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pObj.PeriodoProduccionDeta;
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iProCabEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iProCabEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoEliminarProduccionDeta(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //valida cuando es no es acto registrar en este periodo
            iProCabEN = ProduccionDetaRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la transferencia de insumos a produccion
            ProduccionDetaEN iProDetTraInsEN = ProduccionDetaRN.ValidaCuandoGeneroTransferenciaInsumosAProduccion(iProCabEN);
            if (iProDetTraInsEN.Adicionales.EsVerdad == false) { return iProDetTraInsEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoGeneroSalidaInsumos(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoModificarProduccionDeta(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //valida cuando es no es acto registrar en este periodo
            iProCabEN = ProduccionDetaRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la transferencia de insumos a produccion
            ProduccionDetaEN iProDetTraInsEN = ProduccionDetaRN.ValidaCuandoGeneroTransferenciaInsumosAProduccion(iProCabEN);
            if (iProDetTraInsEN.Adicionales.EsVerdad == false) { return iProDetTraInsEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoGeneroSalidaInsumos(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoGeneroTransferenciaInsumosAProduccion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.NumeroTransferenciaAutomatica != string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Ya se transfirio insumos al almacen de produccion para este parte de trabajo, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static string ObtenerMaximoValorEnColumna(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProCabAD = new ProduccionDetaAD();
            return iProCabAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoNumeroProduccionDetaAutogenerado(ProduccionDetaEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = ProduccionDetaRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 2);

            //devuelve
            return iNumero;
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaXEstado(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaXEstado(pObj);
        }

        public static ProduccionDetaEN EsCantidadProduccionDetaCorrecta(ProduccionDetaEN pObj)
        {
            //valor resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //validar
            if (pObj.CantidadProduccionDeta > pObj.SaldoProduccionCabe)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "La cantidad de parte de trabajo no puede ser mayor que la cantidad de la solicitud";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static string ObtenerClaveFormulaCabe(ProduccionDetaEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoExistencia;

            //devolver
            return iClave;
        }

        public static void ModificarPorSalidaInsumosFaseMasa(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.FechaSalidaFaseMasa = pProDet.FechaSalidaFaseMasa;
            iProDetEN.ClaveSalidaFaseMasa = pProDet.ClaveSalidaFaseMasa;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarPorSalidaInsumosFaseControlCalidad(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.FechaSalidaFaseControlCalidad = pProDet.FechaSalidaFaseControlCalidad;
            iProDetEN.ClaveSalidaFaseControlCalidad = pProDet.ClaveSalidaFaseControlCalidad;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarPorIngresoSemiElaborado(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoSemiElaborado = pProDet.ClaveIngresoSemiElaborado;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static ProduccionDetaEN EsActoTerminarProcesoProduccionDeta(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando aun le queda saldo para liberar            
            ProduccionDetaEN iProDetSalLibEN = ProduccionDetaRN.ValidaCuandoAunTieneSaldoALiberar(iProCabEN);
            if (iProDetSalLibEN.Adicionales.EsVerdad == false) { return iProDetSalLibEN; }

            //valida cuando tiene unidades para reprocesar y no tiene el movimiento de transferencia a su almacen de reprocesos
            ProduccionDetaEN iProDetRepTraProEN = ProduccionDetaRN.ValidaCuandoHayUnidadesParaReprocesarSinSuTransferencia(iProCabEN);
            if (iProDetRepTraProEN.Adicionales.EsVerdad == false) { return iProDetRepTraProEN; }

            //valida cuando tiene unidades donacion y no tiene el movimiento de transferencia a su almacen de donacion
            ProduccionDetaEN iProDetDonTraProEN = ProduccionDetaRN.ValidaCuandoHayUnidadesDonacionSinSuTransferencia(iProCabEN);
            if (iProDetDonTraProEN.Adicionales.EsVerdad == false) { return iProDetDonTraProEN; }

            //valida cuando tiene unidades desechas y no tiene el movimiento de transferencia a su almacen de observados
            ProduccionDetaEN iProDetObsTraProEN = ProduccionDetaRN.ValidaCuandoHayUnidadesDesechasSinSuTransferencia(iProCabEN);
            if (iProDetObsTraProEN.Adicionales.EsVerdad == false) { return iProDetObsTraProEN; }

            //valida cuando el proceso ya esta terminado
            ProduccionDetaEN iProDetTerEN = ProduccionDetaRN.ValidaCuandoProcesoYaEstaTerminado(iProCabEN);
            if (iProDetTerEN.Adicionales.EsVerdad == false) { return iProDetTerEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoAunTieneSaldoALiberar(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.SaldoLiberacion != 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun hay saldo para liberar, No se puede realizar la operacion";
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoHayUnidadesParaReprocesarSinSuTransferencia(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            //traer la lista de liberaciones de este parte de trabajo
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClaveProduccionDeta(pObj);

            //recorrer cada objeto liberacion
            foreach (LiberacionEN xLib in iLisLib)
            {
                //validando cada objeto xLib
                LiberacionEN iLibEN = LiberacionRN.ValidaCuandoHayUnidadesParaReprocesarSinSuTransferencia(xLib);
                if (iLibEN.Adicionales.EsVerdad == false)
                {
                    iProDetEN.Adicionales = iLibEN.Adicionales;
                    return iProDetEN;
                }
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoHayUnidadesDesechasSinSuTransferencia(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            //traer la lista de liberaciones de este parte de trabajo
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClaveProduccionDeta(pObj);

            //recorrer cada objeto liberacion
            foreach (LiberacionEN xLib in iLisLib)
            {
                //validando cada objeto xLib
                LiberacionEN iLibEN = LiberacionRN.ValidaCuandoHayUnidadesDesechasSinSuTransferencia(xLib);
                if (iLibEN.Adicionales.EsVerdad == false)
                {
                    iProDetEN.Adicionales = iLibEN.Adicionales;
                    return iProDetEN;
                }
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoHayUnidadesDonacionSinSuTransferencia(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            //traer la lista de liberaciones de este parte de trabajo
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClaveProduccionDeta(pObj);

            //recorrer cada objeto liberacion
            foreach (LiberacionEN xLib in iLisLib)
            {
                //validando cada objeto xLib
                LiberacionEN iLibEN = LiberacionRN.ValidaCuandoHayUnidadesDonacionSinSuTransferencia(xLib);
                if (iLibEN.Adicionales.EsVerdad == false)
                {
                    iProDetEN.Adicionales = iLibEN.Adicionales;
                    return iProDetEN;
                }
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneraIngresoProductoTerminado(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoMovimientoCabe == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el Ingreso de producto terminado, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoProcesoYaEstaTerminado(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CEstadoProduccionDeta == "1")//terminado
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "El proceso ya se encuentra Terminado, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static void CambiarEstadoATerminado(ProduccionDetaEN pObj)
        {
            //actualizamos su estado a terminado
            pObj.CEstadoProduccionDeta = "1";//Terminado

            //modificamos en b.d
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static ProduccionDetaEN ValidaCuandoGeneroSalidaInsumos(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveSalidaFaseMasa != string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Ya salieron insumos para este parte de trabajo, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroSalidaInsumosFaseMasa(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveSalidaFaseMasa == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera la Salida de insumos Fase Masa, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoIngresarMasaPerdida(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetNoSalMatPriEN = ProduccionDetaRN.ValidaCuandoNoHaySalidaInsumosMateriaPrima(iProCabEN);
            if (iProDetNoSalMatPriEN.Adicionales.EsVerdad == false) { return iProDetNoSalMatPriEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalUniRepEN = ProduccionDetaRN.ValidaCuandoNoGeneraUnidadesReproceso(iProCabEN);
            if (iProDetSalUniRepEN.Adicionales.EsVerdad == false) { return iProDetSalUniRepEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneraUnidadesReproceso(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.UnidadesReproceso != 0 && pObj.ClaveSalidaUnidadesReproceso == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Debes generar la salida de unidades para reprocesar, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoIngresarUnidadesSelladas(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetNoSalMatPriEN = ProduccionDetaRN.ValidaCuandoNoHaySalidaInsumosMateriaPrima(iProCabEN);
            if (iProDetNoSalMatPriEN.Adicionales.EsVerdad == false) { return iProDetNoSalMatPriEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalUniRepEN = ProduccionDetaRN.ValidaCuandoNoGeneraUnidadesReproceso(iProCabEN);
            if (iProDetSalUniRepEN.Adicionales.EsVerdad == false) { return iProDetSalUniRepEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoIngresarPreLiberacion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando si es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoSiEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoEditaLasUnidadesSelladas(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.NumeroUnidadesMasa == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Primero debes digitar las unidades procesadas, No se puede realizar la operacion";
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoCambiarAPendienteProduccionDeta(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando el proceso esta pendiente
            ProduccionDetaEN iProDetTerEN = ProduccionDetaRN.ValidaCuandoProcesoEstaPendiente(iProCabEN);
            if (iProDetTerEN.Adicionales.EsVerdad == false) { return iProDetTerEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoProcesoEstaPendiente(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CEstadoProduccionDeta == "0")//pendiente
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "El proceso ya se encuentra Pendiente, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static void CambiarEstadoAPendiente(ProduccionDetaEN pObj)
        {
            //actualizamos su estado a terminado
            pObj.CEstadoProduccionDeta = "0";//Pendiente

            //modificamos en b.d
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static ProduccionDetaEN EsActoEliminarSalidaInsumos(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida cuando no es acto registrar en este periodo
            iProDetEN = ProduccionDetaRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProDetEN.Adicionales.EsVerdad == false) { return iProDetEN; }

            //validar si existe
            iProDetEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProDetEN.Adicionales.EsVerdad == false) { return iProDetEN; }

            //valida cuando no genera la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroSalidaInsumosFaseMasa(iProDetEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //valida cuando ya genero el ingreso de mercaderias
            ProduccionDetaEN iProDetIngInsEN = ProduccionDetaRN.ValidaCuandoGeneroIngresoMercaderia(iProDetEN);
            if (iProDetIngInsEN.Adicionales.EsVerdad == false) { return iProDetIngInsEN; }

            //valida cuando es acto eliminar MovimientoCabe de esta salida de insumos
            ProduccionDetaEN iProDetMovCabEN = ProduccionDetaRN.ValidaCuandoNoSePuedeEliminarEnMovimientoCabe(iProDetEN);
            if (iProDetMovCabEN.Adicionales.EsVerdad == false) { return iProDetMovCabEN; }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoGeneroIngresoMercaderia(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoMovimientoCabe != string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Ya se genero el Ingreso de mercaderias, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoSePuedeEliminarEnMovimientoCabe(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pObj.ClaveSalidaFaseMasa;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(pObj.FechaSalidaFaseMasa, "-");
            iMovCabEN.COrigenVentanaCreacion = "4";//produccion      
            iMovCabEN = MovimientoCabeRN.EsActoEliminarMovimientoCabe(iMovCabEN);

            //pasamos datos de la validacion
            iProDetEN.Adicionales.EsVerdad = iMovCabEN.Adicionales.EsVerdad;
            iProDetEN.Adicionales.Mensaje = iMovCabEN.Adicionales.Mensaje;

            //ok
            return iProDetEN;
        }

        public static void AccionEliminarSalidaInsumosFaseMasa(ProduccionDetaEN pObj)
        {
            //eliminar el MovimientoCabe
            MovimientoCabeRN.EliminarMovimientoCabe(pObj.ClaveSalidaFaseMasa);

            //actualizar las existencias por eliminacion
            ExistenciaRN.ActualizarExistenciasPorEliminacion(pObj.ClaveSalidaFaseMasa);

            //eliminar MovimientosDeta
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(pObj.ClaveSalidaFaseMasa);

            //eliminar lotes deta
            LoteDetaRN.EliminarLoteDeta(pObj.ClaveSalidaFaseMasa);

            //modificar el parte trabajo
            ProduccionDetaRN.ModificarPorEliminacionSalidaInsumos(pObj);
        }

        public static void ModificarPorEliminacionSalidaInsumos(ProduccionDetaEN pObj)
        {
            //actualizamos datos
            pObj.FechaSalidaFaseMasa = string.Empty;
            pObj.ClaveSalidaFaseMasa = string.Empty;
            pObj.NumeroTransferenciaAutomatica = string.Empty;

            //modificamos en b.d
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static ProduccionDetaEN EsActoEliminarIngresoMercaderia(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida cuando no es acto registrar en este periodo
            iProDetEN = ProduccionDetaRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProDetEN.Adicionales.EsVerdad == false) { return iProDetEN; }

            //validar si existe
            iProDetEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProDetEN.Adicionales.EsVerdad == false) { return iProDetEN; }

            //valida cuando no genero ingreso de mercaderia
            ProduccionDetaEN iProDetIngMerEN = ProduccionDetaRN.ValidaCuandoNoGeneraIngresoProductoTerminado(iProDetEN);
            if (iProDetIngMerEN.Adicionales.EsVerdad == false) { return iProDetIngMerEN; }

            //valida cuando el proceso esta terminado
            ProduccionDetaEN iProDetProTerEN = ProduccionDetaRN.ValidaCuandoProcesoYaEstaTerminado(iProDetEN);
            if (iProDetProTerEN.Adicionales.EsVerdad == false) { return iProDetProTerEN; }

            //valida cuando es acto eliminar MovimientoCabe de este ingreso de mercaderia
            ProduccionDetaEN iProDetMovCabEN = ProduccionDetaRN.ValidaCuandoNoSePuedeEliminarEnMovimientoCabe(iProDetEN);
            if (iProDetMovCabEN.Adicionales.EsVerdad == false) { return iProDetMovCabEN; }

            //ok
            return iProDetEN;
        }

        public static void AccionEliminarIngresoMercaderia(ProduccionDetaEN pObj)
        {
            //eliminar el MovimientoCabe
            MovimientoCabeRN.EliminarMovimientoCabe(pObj.ClaveIngresoMovimientoCabe);

            //actualizar las existencias por eliminacion
            ExistenciaRN.ActualizarExistenciasPorEliminacion(pObj.ClaveIngresoMovimientoCabe);

            //eliminar MovimientosDeta
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(pObj.ClaveIngresoMovimientoCabe);

            //modificar el parte trabajo
            ProduccionDetaRN.ModificarPorEliminacionIngresoMercaderia(pObj);
        }

        public static void ModificarPorEliminacionIngresoMercaderia(ProduccionDetaEN pObj)
        {
            //actualizamos datos
            pObj.FechaIngresoAlmacen = string.Empty;
            pObj.ClaveIngresoMovimientoCabe = string.Empty;

            //modificamos en b.d
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static ProduccionDetaEN EsActoImprimirSalidaInsumosFaseMasa(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroSalidaInsumosFaseMasa(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoImprimirIngresoProductoTerminado(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneraIngresoProductoTerminado(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static decimal ObtenerCostoTotalProducto(ProduccionDetaEN pObj)
        {
            return pObj.CostoInsumos + pObj.CostoManoObra + pObj.CostoOtros + pObj.CostoCIFFijo + pObj.CostoCIFVariable;
        }

        public static decimal ObtenerCostoMasaTotal(ProduccionDetaEN pObj)
        {
            return pObj.CostoMasaPrincipal + pObj.CostoMasaAdicional - pObj.CostoMasaDevolucion;
        }

        public static decimal ObtenerCostoMasaUnidad(ProduccionDetaEN pObj)
        {
            //calcular
            //primero obtener el costo de un gramo de esta masa
            decimal iCostoGramo = Operador.DivisionDecimal(pObj.CostoMasaTotal + pObj.CostoUnidadesReproceso,
                pObj.MasaProducida + pObj.MasaPerdida);

            //segundo obtenemos el costo de la unidad de masa
            decimal iCostoUnidadMasa = Math.Round(iCostoGramo * pObj.MasaUnidad, 6, MidpointRounding.ToEven);

            //devolver
            return iCostoUnidadMasa;
        }

        public static decimal ObtenerCostoMasaPerdida(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //valida si la masa perdida es cero
            if (pObj.MasaPerdida == 0) { return iValor; }

            //calcular
            iValor = pObj.CostoMasaTotal - (pObj.CostoUnidadMasa * pObj.NumeroUnidadesMasa);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoControlCalidadTotal(ProduccionDetaEN pObj)
        {
            return pObj.CostoConCalPrincipal + pObj.CostoConCalAdicional - pObj.CostoConCalDevolucion;
        }

        public static decimal ObtenerCostoControlCalidadUnidad(ProduccionDetaEN pObj)
        {
            //calcular
            //primero obtener el costo de una unidad
            decimal iCosto = Operador.DivisionDecimal(pObj.CostoConCalTotal, pObj.NumeroUnidadesMasa);

            //redondear
            iCosto = Math.Round(iCosto, 6);

            //devolver
            return iCosto;
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaParaProduccionAnterior(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaParaProduccionAnterior(pObj);
        }

        public static string ObtenerClaveExistenciaSemiProducto(ProduccionDetaEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacenSemiProducto + "-";
            iClave += pObj.CodigoSemiProducto;

            //devolver
            return iClave;
        }

        public static ProduccionDetaEN EsActoSalidaUnidadesReproceso(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalProAntEN = ProduccionDetaRN.ValidaCuandoNoHayUnidadesReproceso(iProCabEN);
            if (iProDetSalProAntEN.Adicionales.EsVerdad == false) { return iProDetSalProAntEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetNoSalMatPriEN = ProduccionDetaRN.ValidaCuandoNoHaySalidaInsumosMateriaPrima(iProCabEN);
            if (iProDetNoSalMatPriEN.Adicionales.EsVerdad == false) { return iProDetNoSalMatPriEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoHayUnidadesReproceso(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.UnidadesReproceso == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para reprocesar, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoHaySalidaInsumosMateriaPrima(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveSalidaFaseMasa == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Primero deben salir los insumos fase materia prima y envases, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static decimal ObtenerCostoEmpaquetadoTotal(ProduccionDetaEN pObj)
        {
            return pObj.CostoEmpaquetadoSemElaPrincipal + pObj.CostoEmpaquetadoSemElaAdicional - pObj.CostoEmpaquetadoSemElaDevolucion;
        }

        public static decimal ObtenerCostoUnidadEmpaquetadoSemiElaborado(ProduccionDetaEN pObj)
        {
            //dividir entre el numero de unidades que pasaron el control de calidad
            decimal iCostoTotal = Operador.DivisionDecimal(pObj.CostoEmpaquetadoSemElaTotal, pObj.NumeroUnidadesAEmpaquetar -
                pObj.NumeroUnidadesSueltas);

            //redondeo
            iCostoTotal = Math.Round(iCostoTotal, 2);

            //devolver
            return iCostoTotal;
        }

        public static decimal ObtenerCostoEmpaquetadoSemiElaboradoTotal(ProduccionDetaEN pObj)
        {
            return pObj.CostoEmpaquetadoSemElaPrincipal + pObj.CostoEmpaquetadoSemElaAdicional - pObj.CostoEmpaquetadoSemElaDevolucion;
        }

        public static decimal ObtenerNumeroUnidadesProoductosTerminados(ProduccionDetaEN pObj)
        {
            return pObj.NumeroUnidadesConCal + pObj.NumeroUnidadesProduccionAnterior - pObj.NumeroUnidadesSueltas;
        }

        public static decimal ObtenerCostoUnidadEmpaquetadoSoloCaja(ProduccionDetaEN pObj)
        {
            //obtener primero el costo total del empaquetado solo caja
            decimal iCostoEmpaquetadoSoloCaja = ProduccionExisRN.ObtenerCostoTotalFaseEmpaquetadoSoloCaja(pObj.ClaveProduccionDeta);

            //obtener los adicionales de las existencias de empaquetado solo caja
            decimal iCostoAdicional = 0;

            //dobtener las devoluciones de las existencias de empaquetado solo caja
            decimal iCostoDevolucion = 0;

            //costo total
            decimal iCostoTotal = iCostoEmpaquetadoSoloCaja + iCostoAdicional - iCostoDevolucion;

            //dividir entre el numero de unidades que pasaron el control de calidad
            iCostoTotal = Operador.DivisionDecimal(iCostoTotal, pObj.NumeroUnidadesAEmpaquetar) + pObj.CostoUnidadEmpaquetadoSemEla;

            //devolver
            return iCostoTotal;
        }

        public static void ActualizarCostosFaseMasa(ProduccionDetaEN pObj)
        {
            //obtener el costo fase masa principal
            pObj.CostoMasaPrincipal = ProduccionExisRN.ObtenerCostoTotalFaseMasa(pObj.ClaveProduccionDeta);

            //obtener el costo fase masa adicional
            pObj.CostoMasaAdicional = ProduccionDetaRN.ObtenerCostoFaseMasaAdicional(pObj);

            //obtener el costo fase devolucion
            pObj.CostoMasaDevolucion = ProduccionDetaRN.ObtenerCostoFaseMasaDevolucion(pObj);

            //obtener el costo fase masa total
            pObj.CostoMasaTotal = ProduccionDetaRN.ObtenerCostoMasaTotal(pObj);

            //obtener costo de unidad de masa
            pObj.CostoUnidadMasa = ProduccionDetaRN.ObtenerCostoMasaUnidad(pObj);

            //obtener costo masa perdida
            pObj.CostoMasaPerdida = ProduccionDetaRN.ObtenerCostoMasaPerdida(pObj);
        }

        public static void ActualizarCostosFaseControlCalidad(ProduccionDetaEN pObj)
        {
            //obtener el costo fase cc principal
            pObj.CostoConCalPrincipal = ProduccionExisRN.ObtenerCostoTotalFaseControlCalidad(pObj.ClaveProduccionDeta);

            //obtener el costo cc masa adicional
            pObj.CostoConCalAdicional = ProduccionDetaRN.ObtenerCostoFaseConCalAdicional(pObj);

            //obtener el costo cc devolucion
            pObj.CostoConCalDevolucion = ProduccionDetaRN.ObtenerCostoFaseConCalDevolucion(pObj);

            //obtener el costo cc masa total
            pObj.CostoConCalTotal = ProduccionDetaRN.ObtenerCostoControlCalidadTotal(pObj);

            //obtener costo de unidad de masa
            pObj.CostoUnidadConCal = ProduccionDetaRN.ObtenerCostoControlCalidadUnidad(pObj);

            //obtener el costo unidad insumos total de un semi elaborado
            pObj.CostoInsumos = ProduccionDetaRN.ObtenerCostoUnidadInsumosSemiElaborado(pObj);

            //obtener el costo total del semi elaborado
            pObj.CostoTotalProducto = ProduccionDetaRN.ObtenerCostoUnidadSemiElaborado(pObj);
        }

        public static void ActualizarCostosFaseEmpaquetadoSemiElaborado(ProduccionDetaEN pObj)
        {
            //obtener el costo fase empaquetado semiEla principal
            pObj.CostoEmpaquetadoSemElaPrincipal = ProduccionExisRN.ObtenerCostoTotalFaseEmpaquetadoSinCaja(pObj.ClaveProduccionDeta);

            //obtener el costo cc masa adicional
            pObj.CostoEmpaquetadoSemElaAdicional = ProduccionDetaRN.ObtenerCostoFaseEmpaquetadoSemElaAdicional(pObj);

            //obtener el costo cc devolucion
            pObj.CostoEmpaquetadoSemElaDevolucion = ProduccionDetaRN.ObtenerCostoFaseEmpaquetadoSemElaDevolucion(pObj);

            //obtener el costo cc masa total
            pObj.CostoEmpaquetadoSemElaTotal = ProduccionDetaRN.ObtenerCostoEmpaquetadoSemiElaboradoTotal(pObj);

            //obtener costo de unidad de masa
            pObj.CostoUnidadEmpaquetadoSemEla = ProduccionDetaRN.ObtenerCostoUnidadEmpaquetadoSemiElaborado(pObj);

            //obtener el costo unidad insumos total de un semi elaborado
            pObj.CostoInsumos = ProduccionDetaRN.ObtenerCostoUnidadInsumosSemiElaborado(pObj);

            //obtener el costo total del semi elaborado
            pObj.CostoTotalProducto = ProduccionDetaRN.ObtenerCostoUnidadSemiElaborado(pObj);
        }

        public static decimal ObtenerCostoUnidadInsumosSemiElaborado(ProduccionDetaEN pProDet)
        {
            //valor resultado
            decimal iValor = 0;

            //--------
            //calcular
            //--------
            iValor = pProDet.CostoUnidadMasa + pProDet.CostoUnidadConCal + pProDet.CostoUnidadEmpaquetadoSemEla;

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoUnidadSemiElaborado(ProduccionDetaEN pProDet)
        {
            //valor resultado
            decimal iValor = 0;

            //--------
            //calcular
            //--------
            iValor = pProDet.CostoInsumos + pProDet.CostoManoObra + pProDet.CostoOtros + pProDet.CostoCIFFijo + pProDet.CostoCIFVariable;

            //devolver
            return iValor;
        }

        public static void ModificarCostosFaseEmpaquetadoSemiElaborado(ProduccionDetaEN pObj)
        {
            //actualizamos los datos de empaquetado
            ProduccionDetaRN.ActualizarCostosFaseEmpaquetadoSemiElaborado(pObj);

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static string ObtenerClaveFormulaCabe(string pClaveProduccionDeta)
        {
            //valor resultado
            string iValor = string.Empty;

            //traer al objeto produccionDeta
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pClaveProduccionDeta);

            //obtener su clave
            iValor = ProduccionDetaRN.ObtenerClaveFormulaCabe(iProDetEN);

            //devolver
            return iValor;
        }

        public static ProduccionDetaEN BuscarProduccionDetaXClave(string pClaveProduccionDeta)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.ClaveProduccionDeta = pClaveProduccionDeta;

            //ejecutar metodo
            return ProduccionDetaRN.BuscarProduccionDetaXClave(iProDetEN);
        }

        public static decimal ObtenerCostoFaseMasaAdicional(List<FormulaDetaEN> pLisForDet, List<MovimientoDetaEN> pLisMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //obtener solo las formulasDeta de fase masa
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CTipDes, "0");

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

        public static decimal ObtenerCostoFaseMasaAdicional(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(pObj);
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //ejecutar metodo
            iValor = ProduccionDetaRN.ObtenerCostoFaseMasaAdicional(iLisForDet, iLisMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseMasaDevolucion(List<FormulaDetaEN> pLisForDet, List<MovimientoDetaEN> pLisMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //obtener solo las formulasDeta de fase masa
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CTipDes, "0");

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

        public static decimal ObtenerCostoFaseMasaDevolucion(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(pObj);
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //ejecutar metodo
            iValor = ProduccionDetaRN.ObtenerCostoFaseMasaDevolucion(iLisForDet, iLisMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseConCalAdicional(List<FormulaDetaEN> pLisForDet, List<MovimientoDetaEN> pLisMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //obtener solo las formulasDeta de fase control calidad
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CTipDes, "1");

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

        public static decimal ObtenerCostoFaseConCalAdicional(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(pObj);
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //ejecutar metodo
            iValor = ProduccionDetaRN.ObtenerCostoFaseConCalAdicional(iLisForDet, iLisMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseConCalDevolucion(List<FormulaDetaEN> pLisForDet, List<MovimientoDetaEN> pLisMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //obtener solo las formulasDeta de fase control calidad
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CTipDes, "1");

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

        public static decimal ObtenerCostoFaseConCalDevolucion(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(pObj);
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //ejecutar metodo
            iValor = ProduccionDetaRN.ObtenerCostoFaseConCalDevolucion(iLisForDet, iLisMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseEmpaquetadoSemElaAdicional(List<FormulaDetaEN> pLisForDet, List<MovimientoDetaEN> pLisMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //obtener solo las formulasDeta de fase empaquetado semi elaborado
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CTipDes, "2",
                FormulaDetaEN.CTipFac, "1");

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

        public static decimal ObtenerCostoFaseEmpaquetadoSemElaAdicional(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(pObj);
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //ejecutar metodo
            iValor = ProduccionDetaRN.ObtenerCostoFaseEmpaquetadoSemElaAdicional(iLisForDet, iLisMovDet);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoFaseEmpaquetadoSemElaDevolucion(List<FormulaDetaEN> pLisForDet, List<MovimientoDetaEN> pLisMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //obtener solo las formulasDeta de fase empaquetado semi elaborado
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CTipDes, "2",
                FormulaDetaEN.CTipFac, "1");

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

        public static decimal ObtenerCostoFaseEmpaquetadoSemElaDevolucion(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //asignar parametros
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(pObj);
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pObj);

            //ejecutar metodo
            iValor = ProduccionDetaRN.ObtenerCostoFaseEmpaquetadoSemElaDevolucion(iLisForDet, iLisMovDet);

            //devolver
            return iValor;
        }

        public static ProduccionDetaEN EsActoImprimirSalidaInsumosFaseConCal(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroSalidaInsumosFaseConCal(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroSalidaInsumosFaseConCal(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveSalidaFaseControlCalidad == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera la Salida de insumos Fase Control Calidad, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoImprimirSalidaUnidadesProduccionAnterior(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroSalidaUnidadesProduccionAnterior(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroSalidaUnidadesProduccionAnterior(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveSalidaUnidadesEmpacar == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera la Salida de unidades de produccion anterior, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoImprimirSalidaInsumosFaseEmpaquetado(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroSalidaInsumosFaseEmpaquetado(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroSalidaInsumosFaseEmpaquetado(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveSalidaFaseEmpaquetado == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera la Salida de Insumos fase empaquetado, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoImprimirIngresoProductoSemiElaborado(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroIngresoProductoSemiElaborado(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroIngresoProductoSemiElaborado(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoSemiElaborado == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el ingreso del producto semi elaborado, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static decimal ObtenerMasaProducida(ProduccionDetaEN pObj)
        {
            return pObj.NumeroUnidadesMasa * pObj.MasaUnidad;
        }

        public static void ModificarPorSalidaNoPasan(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos            
            iProDetEN.ClaveSalidaNoPasan = pProDet.ClaveSalidaNoPasan;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarUnidadesSemiElaboradaPorEmpaquetado(ProduccionDetaEN pObj, List<ProduccionProTerEN> pLista)
        {
            //actualizamos los datos de empaquetado
            ProduccionDetaRN.ActualizarUnidadesSemiElaboradaPorEmpaquetado(pObj, pLista);

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static void ActualizarUnidadesSemiElaboradaPorEmpaquetado(ProduccionDetaEN pObj, List<ProduccionProTerEN> pLista)
        {
            //calcular unidades desechas en el proceso de empaquetar
            pObj.UnidadesDesechaEmpaquetado = ListaG.Sumar<ProduccionProTerEN>(pLista, ProduccionProTerEN.UniDesEmp);

            //calcular unidades devueltas en el proceso de empaquetar
            pObj.UnidadesDevueltaEmpaquetado = ListaG.Sumar<ProduccionProTerEN>(pLista, ProduccionProTerEN.UniDevEmp);
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

        public static string ObtenerStrCodigosAlmacenes(ProduccionDetaEN pObj)
        {
            //asignar parametros
            List<string> iLisStr = new List<string>();
            iLisStr.Add(pObj.CodigoAlmacen);
            iLisStr.Add(pObj.CodigoAlmacenSemiProducto);
            iLisStr.Add(pObj.CodigoAlmacenEmpaquetado);
            string iCararcterSeparador = ",";

            //ejecutar metodo
            return Cadena.ConcatenarTexto(iLisStr, iCararcterSeparador);
        }

        public static ProduccionDetaEN EsCantidadReprocesoCorrecta(ProduccionDetaEN pObj)
        {
            //valor resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida cuando codigoExistencia esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iProDetEN; }

            //valida cuando la cantidad digitado es mayor a la cantidad que tiene para reprocesar
            ProduccionDetaEN iProDetMayEN = ProduccionDetaRN.ValidaCuandoCantidadReprocesoDigitadoEsMayorACantidadParaReprocesarAnterior(pObj);
            if (iProDetMayEN.Adicionales.EsVerdad == false) { return iProDetMayEN; }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoCantidadReprocesoDigitadoEsMayorACantidadParaReprocesarAnterior(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //validar            
            decimal iSaldoReproceso = ProduccionDetaRN.ObtenerCantidadSugeridaParaReprocesar(pObj);

            //validando
            if (iSaldoReproceso < pObj.UnidadesReproceso)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "La cantidad de unidades a reprocesar no puede ser mayor a " + iSaldoReproceso.ToString();
            }

            //devolver
            return iProDetEN;
        }

        public static decimal ObtenerCostoUnidadesReproceso(ProduccionDetaEN pObj)
        {
            //traer al objeto produccionDeta de donde se saca su costo de unidades de reproceso
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaParaCostoUnidadesReproceso(pObj);

            //calcular
            return pObj.UnidadesReproceso * (iProDetEN.CostoTotalProducto);
        }

        public static ProduccionDetaEN BuscarProduccionDetaParaCostoUnidadesReproceso(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.BuscarProduccionDetaParaCostoUnidadesReproceso(pObj);
        }

        public static ProduccionDetaEN EsActoImprimirSalidaUnidadesReproceso(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroSalidaUnidadesReproceso(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroSalidaUnidadesReproceso(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveSalidaUnidadesReproceso == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera la Salida de unidades de reproceso, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN CrearProduccionDetaParaCompra(ProduccionCabeEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //pasar datos
            iProDetEN.CodigoEmpresa = pObj.CodigoEmpresa;
            iProDetEN.CorrelativoProduccionDeta = "01";
            iProDetEN.CorrelativoProduccionCabe = pObj.CorrelativoProduccionCabe;
            iProDetEN.FechaProduccionDeta = pObj.FechaProduccionCabe;
            iProDetEN.PeriodoProduccionDeta = Fecha.ObtenerPeriodo(iProDetEN.FechaProduccionDeta, "-");
            iProDetEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iProDetEN.CodigoExistencia = pObj.CodigoExistencia;
            iProDetEN.DescripcionExistencia = pObj.DescripcionExistencia;
            iProDetEN.CodigoUnidadMedida = pObj.CodigoUnidadMedida;
            iProDetEN.CodigoMercaderia = pObj.CodigoMercaderia;
            iProDetEN.CEsExacto = pObj.CEsExacto;
            iProDetEN.SaldoProduccionCabe = pObj.SaldoProduccionCabe;
            iProDetEN.CantidadProduccionDeta = pObj.CantidadProduccionCabe;
            iProDetEN.UnidadesReproceso = pObj.UnidadesReproceso;
            iProDetEN.CTurno = pObj.CTurno;
            iProDetEN.PorcentajeRango = pObj.PorcentajeRango;
            iProDetEN.CantidadRango = pObj.CantidadRango;
            iProDetEN.CantidadSinceradoProduccionDeta = pObj.CantidadSinceradoProduccionCabe;
            iProDetEN.PorcentajeSinceradoRango = pObj.PorcentajeSinceradoRango;
            iProDetEN.CantidadSinceradoRango = pObj.CantidadSinceradoRango;
            iProDetEN.DetalleMotivoSincerado = pObj.DetalleMotivoSincerado;
            iProDetEN.ClaveProduccionCabe = pObj.ClaveProduccionCabe;
            iProDetEN.ClaveProduccionDeta = ProduccionDetaRN.ObtenerClaveProduccionDeta(iProDetEN);

            //devolver
            return iProDetEN;
        }

        public static void MigrarProduccion(List<MovimientoDetaEN> pLisMovDet, List<ProduccionDetaEN> pLisProDet)
        {
            //fecha de partida
            DateTime iFechaPartida = Convert.ToDateTime("31/12/2018");

            //fecha fin
            DateTime iFechaFin = Convert.ToDateTime("01/01/2020");

            //operar
            while (iFechaPartida < iFechaFin)
            {
                //sumamos un dia a la fecha de partida
                iFechaPartida = iFechaPartida.AddDays(1);

                //obtener una lista del dia
                List<MovimientoDetaEN> iLisMovDetDia = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.FecMovCab,
                    iFechaPartida.ToShortDateString());

                //importar las compras del dia y recalcular este mes ,si hay movimientos del dia     
                if (iLisMovDetDia.Count != 0)
                {
                    MovimientoCabeRN.ImportarIngresosDeExcel1(iLisMovDetDia);
                    MovimientoDetaRN.Recalcular(Fecha.ObtenerAño(iFechaPartida), Fecha.ObtenerNumeroMes(iFechaPartida));
                }

                //obtener una lista del dia de iFechaPartida
                List<ProduccionDetaEN> iLisProDetDia = ListaG.Filtrar<ProduccionDetaEN>(pLisProDet, ProduccionDetaEN.FecProDet,
                    iFechaPartida.ToShortDateString());

                //quitar los que tienen cantidad real igual a cero
                iLisProDetDia = ListaG.FiltrarExcepto<ProduccionDetaEN>(iLisProDetDia, ProduccionDetaEN.CanReaPro, "0");

                //importar las producciones del dia, si hay producciones del dia
                if (iLisProDetDia.Count != 0) { ImportarProduccionDeExcel(iLisProDetDia); }
            }
        }

        public static void ImportarProduccionDeExcel(List<ProduccionDetaEN> pListaProduccionDetaExcel)
        {
            //listas para grabar
            List<ProduccionCabeEN> iLisProCabAdi = new List<ProduccionCabeEN>();

            //correlativo ProduccionCabe
            string iCorrelativoProCab = ProduccionCabeRN.ObtenerNuevoNumeroProduccionCabeAutogenerado();

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in pListaProduccionDetaExcel)
            {
                //creamos el objeto ProduccionCabe apartir del produccionDeta
                ProduccionCabeEN iProCabEN = ProduccionCabeRN.CrearProduccionCabeParaMigracion(iCorrelativoProCab, xProDet);

                //agregar a la lista para adicionar
                iLisProCabAdi.Add(iProCabEN);

                //completar los datos al obtejo ProduccionDeta
                xProDet.PeriodoProduccionDeta = Fecha.ObtenerPeriodo(xProDet.FechaProduccionDeta, "-");
                xProDet.CorrelativoProduccionCabe = iProCabEN.CorrelativoProduccionCabe;
                xProDet.ClaveProduccionCabe = iProCabEN.ClaveProduccionCabe;
                xProDet.CorrelativoProduccionDeta = "01";
                xProDet.ClaveProduccionDeta = ProduccionDetaRN.ObtenerClaveProduccionDeta(xProDet);

                //incrementar el correlativo
                Numero.IncrementarCorrelativoNumerico(ref iCorrelativoProCab);
            }

            //adicionar masivos
            ProduccionCabeRN.AdicionarProduccionCabe(iLisProCabAdi);
            ProduccionDetaRN.AdicionarProduccionDeta(pListaProduccionDetaExcel);

            //generar ProduccionExis para todas las producciones
            foreach (ProduccionDetaEN xProDet in pListaProduccionDetaExcel)
            {
                //generar los ProduccionExis fase masa y envasado
                ProduccionExisRN.AdicionarProduccionesExisFaseMasa(xProDet);
                ProduccionExisRN.AdicionarProduccionesExisFaseControlCalidad(xProDet);
            }

            //transferir de los almacenes de compras al almacen de produccion               
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosParaTransferirAProducccion();
            MovimientoCabeRN.GenerarTransferenciasAutomaticasAProduccion(iLisInsFal);

            //objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de salida de produccion
            TipoOperacionEN iTipOpeSalEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionProduccionSalida);

            //traemos al tipo de operacion de ingreso a produccion
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionProduccionIngreso);

            //recorrer cada objeto ProduccionDeta
            foreach (ProduccionDetaEN xProDet in pListaProduccionDetaExcel)
            {
                //generar la salida de masa y envasado
                MovimientoCabeRN.GenerarMovimientoSalidaMasaYEnvasadoPorMigracion(xProDet, iTipOpeSalEN);

                //actualizar produccionDeta por unidades selladas
                ProduccionDetaRN.ActualizarPorUnidadesSelladasPorMigracion(xProDet);

                //generar el ingreso de unidades selladas
                MovimientoCabeRN.GenerarMovimientoIngresoUnidadesSelladasPorMigracion(xProDet, iTipOpeIngEN);

                //actualizar produccionDeta Por unidades producidas
                ProduccionDetaRN.ActualizarPorUnidadesProducidasPorMigracion(xProDet);

                //generar la salida de unidades desechas
                MovimientoCabeRN.GenerarMovimientoSalidaUnidadesNoPasanPorMigracion(xProDet, iTipOpeSalEN);
            }

            //----------------
            //plan de encajado
            //----------------

            //obtener al primer objeto de ProduccionDetaExcel
            ProduccionDetaEN iProDetEN = pListaProduccionDetaExcel[0];

            //crear el objeto Encajado por esta migracion
            EncajadoEN iEncEN = EncajadoRN.CrearEncajadoPorMigracion(iProDetEN);

            //grabar el encajado en b.d
            EncajadoRN.AdicionarEncajado(iEncEN);

            //generar sus producto terminado para este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionesProTerParaMigracion(iEncEN, pListaProduccionDetaExcel);

            //grabar en b.d
            ProduccionProTerRN.AdicionarProduccionProTer(iLisProProTer);

            //grabar las ProduccionesExis de estos proter
            ProduccionExisRN.AdicionarProduccionExisFaseEmpaquetado(iLisProProTer);

            //generar la salida de empaquetado y actualiza costo fase empaquetado
            MovimientoCabeRN.GenerarMovimientoSalidaEmpaquetadoPorMigracion(iEncEN, iTipOpeSalEN);

            //generar la salida de unidades a empaquetar
            MovimientoCabeRN.GenerarMovimientoSalidaUnidadesAEmpaquetarPorMigracion(iEncEN, iTipOpeSalEN);

            //actualizar costos fase empaquetado 
            ProduccionProTerRN.ModificarCostosFaseEmpaquetadoProTer(iEncEN);
            //ProduccionProTerRN.ModificarCostosManoObraProTer(iEncEN);

            //generar el ingreso de los productos terminados           
            MovimientoCabeRN.GenerarMovimientoIngresoProductoTerminadoPorMigracion(iEncEN, iTipOpeIngEN);
        }

        public static void ActualizarPorUnidadesSelladasPorMigracion(ProduccionDetaEN pProDet)
        {
            //traer al objeto de la bd
            ProduccionDetaEN iProDetEN = BuscarProduccionDetaXClave(pProDet);

            //actualizar datos
            iProDetEN.NumeroUnidadesMasa = pProDet.CantidadRealProduccion;
            iProDetEN.MasaUnidad = ObtenerMasaUnidad(iProDetEN);
            iProDetEN.MasaProducida = ObtenerMasaProducida(iProDetEN);
            ProduccionDetaRN.ActualizarCostosFaseMasa(iProDetEN);
            ProduccionDetaRN.ActualizarCostosFaseControlCalidad(iProDetEN);

            //modificar
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static decimal ObtenerMasaUnidad(ProduccionDetaEN pObj)
        {
            //asignar parametros
            string iClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj);

            //ejecutar metodo
            FormulaCabeEN iForCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(iClaveFormulaCabe);

            //devolver
            return iForCabEN.MasaUnidad;
        }

        public static void ActualizarPorUnidadesProducidasPorMigracion(ProduccionDetaEN pProDet)
        {
            //traer al objeto de la bd
            ProduccionDetaEN iProDetEN = BuscarProduccionDetaXClave(pProDet);

            //actualizar datos    
            iProDetEN.NumeroUnidadesMasa = iProDetEN.CantidadRealProduccion;
            iProDetEN.NumeroUnidadesConCal = ProduccionDetaRN.ObtenerNumeroUnidadesPasan(iProDetEN);
            iProDetEN.NumeroUnidadesAEmpaquetar = iProDetEN.NumeroUnidadesConCal;
            iProDetEN.SaldoUnidadesAEmpacar = iProDetEN.NumeroUnidadesConCal;

            //modificar
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static decimal ObtenerNumeroUnidadesPasan(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = pObj.NumeroUnidadesMasa - pObj.UnidadesParaReproceso - pObj.NumeroUnidadesNoPasanConCal;

            //devolver
            return iValor;
        }

        public static List<ProduccionDetaEN> ObtenerReporteProduccionRangoFecha(string pFechaProduccionDesde, string pFechaProduccionHasta, string pTipoUnidad)
        {
            //armar reporte
            //traer la produccionDeta del rango elegido
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaXRangoFechaProduccion(pFechaProduccionDesde,
                pFechaProduccionHasta);

            //cuando sea en "KG"
            if (pTipoUnidad.ToUpper() == "KG")
            {
                ActualizarCantidadesEnKilogramos(iLisProDet);
            }
            else
            {
                ActualizarSoloMasaUnidadEnKilogramos(iLisProDet);
            }

            //devolver
            return iLisProDet;
        }

        public static void ActualizarSoloMasaUnidadEnKilogramos(List<ProduccionDetaEN> pLista)
        {
            foreach (ProduccionDetaEN xProDet in pLista)
            {
                ActualizarSoloMasaUnidadEnKilogramos(xProDet);
            }
        }

        public static void ActualizarSoloMasaUnidadEnKilogramos(ProduccionDetaEN pObj)
        {
            //actualizar a kg
            pObj.MasaUnidad = Conversion.GramosAKilogramos(pObj.MasaUnidad, 5);
            pObj.TotalEnvasesDesmedro = ObtenerTotalEnvasesDesmedro(pObj);
            pObj.PorcentajeEnvasesDesmedro = Operador.Porcentaje(pObj.TotalEnvasesDesmedro, pObj.CantidadRealProduccion);
        }

        public static void ActualizarCantidadesEnKilogramos(ProduccionDetaEN pObj)
        {
            //obtener la cantidad en kg(la MasaUnidad esta en gramos)
            decimal iCantidadKg = Math.Round(pObj.MasaUnidad / 1000, 5);

            //actualizar a kg
            pObj.MasaUnidad = iCantidadKg;
            pObj.CantidadProduccionDeta = pObj.CantidadProduccionDeta * iCantidadKg;
            pObj.CantidadRealProduccion = pObj.CantidadRealProduccion * iCantidadKg;
            pObj.SaldoLiberacion = pObj.SaldoLiberacion * iCantidadKg;
            pObj.UnidadesAprobadasLiberacion = pObj.UnidadesAprobadasLiberacion * iCantidadKg;
            pObj.UnidadesReprocesoLiberacion = pObj.UnidadesReprocesoLiberacion * iCantidadKg;
            pObj.UnidadesDonacionLiberacion = pObj.UnidadesDonacionLiberacion * iCantidadKg;
            pObj.UnidadesMuestraLiberacion = pObj.UnidadesMuestraLiberacion * iCantidadKg;
            pObj.UnidadesDesechasLiberacion = pObj.UnidadesDesechasLiberacion * iCantidadKg;
            pObj.TotalEnvasesDesmedro = ObtenerTotalEnvasesDesmedro(pObj);
            pObj.PorcentajeEnvasesDesmedro = Operador.Porcentaje(pObj.TotalEnvasesDesmedro, pObj.CantidadRealProduccion);
        }

        public static decimal ObtenerTotalEnvasesDesmedro(ProduccionDetaEN pObj)
        {
            return pObj.UnidadesReprocesoLiberacion + pObj.UnidadesDonacionLiberacion + pObj.UnidadesDesechasLiberacion;
        }

        public static void ActualizarCantidadesEnKilogramos(List<ProduccionDetaEN> pLista)
        {
            foreach (ProduccionDetaEN xProDet in pLista)
            {
                ActualizarCantidadesEnKilogramos(xProDet);
            }
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaXRangoFechaProduccion(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaXRangoFechaProduccion(pObj);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaXRangoFechaProduccion(string pFechaProduccionDesde,
            string pFechaProduccionHasta)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.Adicionales.Desde1 = pFechaProduccionDesde;
            iProDetEN.Adicionales.Hasta1 = pFechaProduccionHasta;
            iProDetEN.Adicionales.CampoOrden = ProduccionDetaEN.FecProDet + "," + ProduccionDetaEN.CorProCab;

            //ejecutar metodo
            return ProduccionDetaRN.ListarProduccionDetaXRangoFechaProduccion(iProDetEN);
        }

        public static decimal ObtenerCantidadSugeridaParaReprocesar(ProduccionDetaEN pObj)
        {
            //obtener el objeto formula
            FormulaCabeEN iForCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj));

            //traer el saldo de unidades para reproceso
            decimal iSaldo = ProduccionDetaRN.ObtenerSaldoUnidadesParaReprocesar("A18", iForCabEN.CodigoSemiProducto);

            //si el objeto produccion esta creado en bd
            if (pObj.UsuarioAgrega != string.Empty)
            {
                //traer al objeto de bd
                ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj);

                //le volvemos a sumar este monto
                iSaldo += iProDetEN.UnidadesReproceso;
            }

            //devolver
            return iSaldo;
        }

        public static decimal ObtenerNuevaCantidadParaReprocesar(ProduccionDetaEN pObj)
        {
            //traer al objeto anterior a esta ProduccionDeta
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaParaCostoUnidadesReproceso(pObj);

            //calcular
            decimal iValor = iProDetEN.UnidadesParaReproceso - pObj.UnidadesReproceso;

            //devolver
            return iValor;
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaParaTransferirInsumos()
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaParaTransferirInsumos();
        }

        public static void ModificarProduccionDeta(ProduccionDetaEN pObj, List<ProduccionDetaEN> pLista)
        {
            //lista actualizada
            List<ProduccionDetaEN> iLisProDet = new List<ProduccionDetaEN>();

            //buscamos el objeto en la lista pLista
            foreach (ProduccionDetaEN xProDet in pLista)
            {
                if (xProDet.ClaveProduccionCabe == pObj.ClaveProduccionCabe)
                {
                    xProDet.VerdadFalso = pObj.VerdadFalso;
                }
                iLisProDet.Add(xProDet);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisProDet);
        }

        public static List<ProduccionDetaEN> ListarVentanaProduccionDetaSoloMarcadas(List<ProduccionDetaEN> pLista)
        {
            //lista resultado
            List<ProduccionDetaEN> iLisRes = new List<ProduccionDetaEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (ProduccionDetaEN xVenBot in pLista)
            {
                if (xVenBot.VerdadFalso == true)
                {
                    iLisRes.Add(xVenBot);
                }
            }
            return iLisRes;
        }

        public static void ModificarPorTransferenciaAutomatica(List<ProduccionDetaEN> pLista)
        {
            //traer el nuevo numero transferencia automatica
            string iNumeroTransferenciaAutomatica = ProduccionDetaRN.ObtenerNuevoNumeroTransferenciaAutomaticaAutogenerado();

            //recorrer cada objeto produccionDeta
            foreach (ProduccionDetaEN xProDet in pLista)
            {
                //actualizar el dato
                xProDet.NumeroTransferenciaAutomatica = iNumeroTransferenciaAutomatica;
                xProDet.FechaIngresoAlmacen = xProDet.FechaProduccionDeta;               

                //modificar en bd
                ProduccionDetaRN.ModificarProduccionDeta(xProDet);
            }
        }

        public static string ObtenerMaximoValorEnColumnaNumeroTransferenciaAutomatica()
        {
            ProduccionDetaAD iProCabAD = new ProduccionDetaAD();
            return iProCabAD.ObtenerMaximoValorEnColumnaNumeroTransferenciaAutomatica();
        }

        public static string ObtenerNuevoNumeroTransferenciaAutomaticaAutogenerado()
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = ProduccionDetaRN.ObtenerMaximoValorEnColumnaNumeroTransferenciaAutomatica();

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static decimal ObtenerSaldoUnidadesParaReprocesar(ExistenciaEN pExiUniParRep, List<ProduccionDetaEN> pLisProDetPenRep)
        {
            //de la lista de ProduccionesDeta que tienen una cantidad para reprocesar pero que aun no han 
            //generado la salida de la existencia de reproceso,debemos obtener la cantidad total de unidades
            //pendientes
            decimal iCantidadPendienteReproceso = ListaG.Sumar<ProduccionDetaEN>(pLisProDetPenRep, ProduccionDetaEN.UniRep);

            //restamos la cantidad que hay en la existencia con esta cantidad pendiente
            decimal iSaldo = pExiUniParRep.StockActualExistencia - iCantidadPendienteReproceso;

            //devolver
            return iSaldo;
        }

        public static decimal ObtenerSaldoUnidadesParaReprocesar(string pCodAlmRep, string pCodExiSemEla)
        {
            //asignar parametros
            //obtener a la existencia del almacen de reproceso
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pCodAlmRep, pCodExiSemEla);

            //obtener la lista de Produccionesdeta que tienen para reprocesar pero aun no lo reprocesan
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaQueFaltanReprocesar(pCodExiSemEla);

            //ejecutar metodo
            return ProduccionDetaRN.ObtenerSaldoUnidadesParaReprocesar(iExiEN, iLisProDet);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaQueFaltanReprocesar(string pCodExiSemEla)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaQueFaltanReprocesar(pCodExiSemEla);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaParaRecalculoManoObra(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaParaRecalculoManoObra(pObj);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaParaRecalculoManoObra(string pAño, string pCodigoMes)
        {
            //asignar parametros
            ProduccionDetaEN iProProTerEN = new ProduccionDetaEN();
            iProProTerEN.PeriodoProduccionDeta = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iProProTerEN.Adicionales.CampoOrden = ProduccionDetaEN.ClaProDet;

            //ejecutar metodo
            return ProduccionDetaRN.ListarProduccionDetaParaRecalculoManoObra(iProProTerEN);
        }

        public static ProduccionDetaEN ObtenerProduccionDetaParaOperarFaseEmpaquetado(ProduccionProTerEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //obtener a la FormulaDeta de este ProTer
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pObj);

            //pasar los datos necesarios
            iProDetEN.CodigoAlmacen = iForDetEN.CodigoAlmacen;
            iProDetEN.CodigoExistencia = iForDetEN.CodigoExistenciaFormula;

            //devolver
            return iProDetEN;
        }

        public static List<ProduccionDetaEN> ListarProduccionParaEmpaquetar()
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaParaEmpaquetar();
        }

        public static void DescontarUnidadesPorEmpaquetado(List<MovimientoDetaEN> pLisMovDet)
        {
            //listar a todas las producciones que se pueden empaquetar
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionParaEmpaquetar();

            //lista de producciones a modificar
            List<ProduccionDetaEN> iLisProDetMod = new List<ProduccionDetaEN>();

            //recorrer cada objeto MovimientoDeta
            foreach (MovimientoDetaEN xMovDet in pLisMovDet)
            {
                //listar solo producciones de la existencia del xMovDet
                List<ProduccionDetaEN> iLisProDetExi = ListaG.Filtrar<ProduccionDetaEN>(iLisProDet, ProduccionDetaEN.CodSemPro, xMovDet.CodigoExistencia);

                //cantidad a salir
                decimal iCantidadASalir = xMovDet.CantidadMovimientoDeta;

                //recorrer cada produccion
                foreach (ProduccionDetaEN xProDet in iLisProDetExi)
                {
                    //si la cantidad a salir es cero, entonces salir del foreach
                    if (iCantidadASalir == 0) { break; }

                    //si la cantidad a salir es menor,entonces termina la salida de los lotes
                    if (iCantidadASalir < xProDet.SaldoUnidadesAEmpacar)
                    {
                        //actualizamos el lote
                        xProDet.SaldoUnidadesAEmpacar -= iCantidadASalir;

                        //ya no hay cantidad a salir
                        iCantidadASalir = 0;
                    }
                    else
                    {
                        //restamos
                        iCantidadASalir -= xProDet.SaldoUnidadesAEmpacar;

                        //actualizamos el lote
                        xProDet.SaldoUnidadesAEmpacar = 0;
                    }

                    //adicionar a las listas                  
                    iLisProDetMod.Add(xProDet);
                }
            }

            //actualizar masivo
            ProduccionDetaRN.ModificarProduccionDeta(iLisProDetMod);
        }

        public static void DescontarUnidadesPorEmpaquetadoOC(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //listar a todas las producciones que se pueden empaquetar
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionParaEmpaquetar();

            //lista de producciones a modificar
            List<ProduccionDetaEN> iLisProDetMod = new List<ProduccionDetaEN>();

            //recorrer cada objeto MovimientoDeta
            foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
            {
                //listar solo producciones de la existencia del xMovDet
                List<ProduccionDetaEN> iLisProDetExi = ListaG.Filtrar<ProduccionDetaEN>(iLisProDet, ProduccionDetaEN.CodSemPro, xMovDet.CodigoExistencia);

                //cantidad a salir
                decimal iCantidadASalir = xMovDet.CantidadMovimientoDeta;

                //recorrer cada produccion
                foreach (ProduccionDetaEN xProDet in iLisProDetExi)
                {
                    //si la cantidad a salir es cero, entonces salir del foreach
                    if (iCantidadASalir == 0) { break; }

                    //si la cantidad a salir es menor,entonces termina la salida de los lotes
                    if (iCantidadASalir < xProDet.SaldoUnidadesAEmpacar)
                    {
                        //actualizamos el lote
                        xProDet.SaldoUnidadesAEmpacar -= iCantidadASalir;

                        //ya no hay cantidad a salir
                        iCantidadASalir = 0;
                    }
                    else
                    {
                        //restamos
                        iCantidadASalir -= xProDet.SaldoUnidadesAEmpacar;

                        //actualizamos el lote
                        xProDet.SaldoUnidadesAEmpacar = 0;
                    }

                    //adicionar a las listas                  
                    iLisProDetMod.Add(xProDet);
                }
            }

            //actualizar masivo
            ProduccionDetaRN.ModificarProduccionDeta(iLisProDetMod);
        }

        public static List<ProduccionDetaEN> ListarProduccionProTerAcumuladosPorCodigoExistencia(List<ProduccionDetaEN> pLisProDet)
        {
            //lista resultado
            List<ProduccionDetaEN> iLisRes = new List<ProduccionDetaEN>();

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in pLisProDet)
            {
                //variable de encontrado
                int iEncontrado = 0;

                //buscar
                foreach (ProduccionDetaEN xProDetBus in iLisRes)
                {
                    if (xProDet.CodigoExistencia == xProDetBus.CodigoExistencia)
                    {
                        xProDetBus.NumeroCajas += xProDet.NumeroCajas;
                        xProDetBus.SaldoUnidadesAEmpacar += xProDet.SaldoUnidadesAEmpacar;
                        iEncontrado = 1;
                        continue;
                    }
                }

                //sino lo encontro agrega este objeto a la lista resultado
                if (iEncontrado == 0)
                {
                    iLisRes.Add(xProDet);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaParaEmpaquetarXCodigoSemiProducto(string pCodigoSemiProducto)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaParaEmpaquetarXCodigoSemiProducto(pCodigoSemiProducto);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaParaEmpaquetarXCodigoSemiProducto(ProduccionProTerEN pObj)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pObj);

            //ejecutar metodo
            return ProduccionDetaRN.ListarProduccionDetaParaEmpaquetarXCodigoSemiProducto(iForDetEN.CodigoSemiProducto);
        }

        public static void ModificarPorSalidaReproceso(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos            
            iProDetEN.ClaveSalidaUnidadesReproceso = pProDet.ClaveSalidaUnidadesReproceso;
            iProDetEN.CostoUnidadesReproceso = pProDet.CostoUnidadesReproceso;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaAcumuladosParaMigracion(List<ProduccionDetaEN> pLisProDetExc)
        {
            //lista resultado
            List<ProduccionDetaEN> iLisRes = new List<ProduccionDetaEN>();

            //traer a todas producciones deta para empaquetar
            List<ProduccionDetaEN> iLisProDetEmpBD = ProduccionDetaRN.ListarProduccionParaEmpaquetar();

            //obtener una lista de objetos no repetidos
            List<ProduccionDetaEN> iLisProDetNoRep = ListaG.FiltrarObjetosSinRepetir<ProduccionDetaEN>(pLisProDetExc, ProduccionDetaEN.CodExi);

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in iLisProDetNoRep)
            {
                //obtener la lista de objetos de xProDet
                List<ProduccionDetaEN> iLisProDetFil = ListaG.Filtrar<ProduccionDetaEN>(iLisProDetEmpBD, ProduccionDetaEN.CodExi, xProDet.CodigoExistencia);

                //agregar a la lista resultado
                iLisRes.AddRange(iLisProDetFil);
            }

            //devolver
            return ProduccionDetaRN.ListarProduccionProTerAcumuladosPorCodigoExistencia(iLisRes);
        }

        public static ProduccionDetaEN EsActoIngresarUnidadesSemiElaboradas(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaEncajar(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaEncajar(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CantidadEncajonar == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para encajar, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesSelladas(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.NumeroUnidadesMasa == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Debes digitar las unidades selladas, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoDigitarUnidadesProducidas(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoGeneraIngresoSemiElaboradas(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneraIngresoSemiElaboradas(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoSemiElaborado == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Debes generar el ingreso de las unidades semi elaboradas, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoTransferirUnidadesParaReproceso(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoHayUnidadesParaReprocesar(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoHayUnidadesParaReprocesar(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.UnidadesParaReproceso == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para transferir al almacen de reproceso, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoTransferirUnidadesNoPasan(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoHayUnidadesNoPasan(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoHayUnidadesNoPasan(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.NumeroUnidadesNoPasanConCal == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para transferir al almacen de observados, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoTransferirUnidadesDonacion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoHayUnidadesDonacion(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoHayUnidadesDonacion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.UnidadesDonacion == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para transferir al almacen de donacion, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static void GenerarProduccionesDetas(List<ProduccionCabeEN> pLista)
        {
            //listas a grabar en b.d
            List<ProduccionDetaEN> iLisProDetAdi = new List<ProduccionDetaEN>();
            List<ProduccionExisEN> iLisProExiAdi = new List<ProduccionExisEN>();

            //recorrer cada objeto ProduccionCabe(solicitud)
            foreach (ProduccionCabeEN xProCab in pLista)
            {
                //crear un nuevo objeto ProduccionDeta a partir de la ProduccionCabe
                ProduccionDetaEN iProDetEN = ProduccionDetaRN.CrearProduccionDetaParaCompra(xProCab);
                iLisProDetAdi.Add(iProDetEN);

                //crear una lista de produccionesExis para esta ProduccionDeta
                iLisProExiAdi.AddRange(ProduccionExisRN.ArmarListaProduccionesExisFaseMasaYCalidad(iProDetEN, xProCab));

                //actualizar al objeto ProduccionCabe
                ProduccionCabeRN.ActualizarProduccionCabeAlAdicionarParteTrabajo(xProCab, xProCab.SaldoProduccionCabe);
            }

            //grabar masivo
            ProduccionDetaRN.AdicionarProduccionDeta(iLisProDetAdi);
            ProduccionExisRN.AdicionarProduccionExis(iLisProExiAdi);
            ProduccionCabeRN.ModificarProduccionCabe(pLista);
        }

        public static ProduccionDetaEN ValidaCuandoHayMateriaPrimaSinTransferirACocina()
        {
            //-----------------------------------------------------------------------------------------------------
            //esta funcion va a detener al usuario a no transferir materia prima al almacen de produccion,si es que
            //hay partes de trabajo que se le transfirio su materia prima y no han registrado la salida a cocina
            //-----------------------------------------------------------------------------------------------------

            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //traer la lista de partes de trabajo que ya se transfirio su materia prima y no llevan a la cocina
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaConTransferenciaMateriaPrimaSinLlevarACocina();

            //validar
            if (iLisProDet.Count != 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Hay Partes de trabajo con transferencia de materia prima y que no se han llevado a la cocina";
            }

            //devolver
            return iProDetEN;
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaConTransferenciaMateriaPrimaSinLlevarACocina()
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaConTransferenciaMateriaPrimaSinLlevarACocina();
        }

        public static void ModificarProduccionDetaAlAdicionarPorLiberacion(LiberacionEN pObj)
        {
            //traer a la ProduccionDeta de la b.d           
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj.ClaveProduccionDeta);

            //actualizar el saldo de unidades para packing,quitandole las nuevas unidades
            iProDetEN.SaldoLiberacion = iProDetEN.SaldoLiberacion - pObj.CantidadLiberacion + pObj.UnidadesSaldo;

            //actualizar el saldo unidades observadas,adicionando las nuevas unidades
            iProDetEN.SaldoLiberacionObservadas += pObj.UnidadesObservadas;

            //actualizar totales liberacion
            iProDetEN.UnidadesAprobadasLiberacion += pObj.UnidadesPasan;
            iProDetEN.UnidadesReprocesoLiberacion += pObj.UnidadesParaReproceso;
            iProDetEN.UnidadesDonacionLiberacion += pObj.UnidadesParaDonacion;
            iProDetEN.UnidadesMuestraLiberacion += pObj.UnidadesParaMuestra;
            iProDetEN.UnidadesDesechasLiberacion += pObj.UnidadesDesechas;
            iProDetEN.UnidadesObservadasLiberacion += pObj.UnidadesObservadas;
            iProDetEN.UnidadesSaldoLiberacion += pObj.UnidadesSaldo;

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarProduccionDetaAlEliminarPorLiberacion(LiberacionEN pObj)
        {
            //traer a la ProduccionDeta de la b.d           
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj.ClaveProduccionDeta);

            //traer a la liberacion de la b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pObj);

            //actualizar el saldo de unidades para packing,devolviendo las unidades que tenia
            iProDetEN.SaldoLiberacion = iProDetEN.SaldoLiberacion + iLibEN.CantidadLiberacion - iLibEN.UnidadesSaldo;

            //actualizar el saldo unidades observadas,devolviendo las unidades que tenia
            iProDetEN.SaldoLiberacionObservadas -= iLibEN.UnidadesObservadas;

            //actualizar totales liberacion
            iProDetEN.UnidadesAprobadasLiberacion -= iLibEN.UnidadesPasan;
            iProDetEN.UnidadesReprocesoLiberacion -= iLibEN.UnidadesParaReproceso;
            iProDetEN.UnidadesDonacionLiberacion -= iLibEN.UnidadesParaDonacion;
            iProDetEN.UnidadesMuestraLiberacion -= iLibEN.UnidadesParaMuestra;
            iProDetEN.UnidadesDesechasLiberacion -= iLibEN.UnidadesDesechas;
            iProDetEN.UnidadesObservadasLiberacion -= iLibEN.UnidadesObservadas;
            iProDetEN.UnidadesSaldoLiberacion -= iLibEN.UnidadesSaldo;

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void RecalcularProducciones(string pAño, string pCodigoMes)
        {
            //traer a todas las produccionesdeta de este proceso(periodo)
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaParaRecalculoManoObra(pAño, pCodigoMes);

            //traer a todas las produccionesExis de todas las produccionesDeta del proceso
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisParaRecalculoProducciones(pAño, pCodigoMes);

            //de las produccionesExis de todo el mes,filtrar solo los del mes de proceso pero del campo PeriodoEncajado
            List<ProduccionExisEN> iLisProExiEnc = ListaG.Filtrar<ProduccionExisEN>(iLisProExi, ProduccionExisEN.PerEnc, Formato.UnionDosTextos(pAño, pCodigoMes, "-"));

            //de las produccionesExis de todo el mes,filtrar solo los del mes de proceso pero del campo PeriodoRetiquetado
            List<ProduccionExisEN> iLisProExiRet = ListaG.Filtrar<ProduccionExisEN>(iLisProExi, ProduccionExisEN.PerRet, Formato.UnionDosTextos(pAño, pCodigoMes, "-"));

            //obtener todo el movimientoDeta de este proceso recalculado
            List<MovimientoDetaEN> iLisMovDetRec = MovimientoDetaRN.ObtenerMovimientoDetaRecalculada(pAño, pCodigoMes);

            //listar las liberaciones de ese proceso(periodo)
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXPeriodo(pAño, pCodigoMes);

            //listar todas las producciones ProTer de este proceso
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXPeriodoEncajado(pAño, pCodigoMes);

            //listar todos los retiquetados de este proceso
            List<RetiquetadoEN> iLisRet = RetiquetadoRN.ListarRetiquetadoXPeriodoRetiquetado(pAño, pCodigoMes);

            //listar todas las FormulasDetas con codigoexistencia ProTer
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaConCodigoExistenciaProTer();

            //obtener el factor para este periodo
            decimal iFactorCosto = FactorCostoRN.ObtenerFactorCostoParaRecalculoManoObra(pAño, pCodigoMes);

            //obtener objeto factor costo cif
            FactorCIFEN iFacCifEN = FactorCIFRN.BuscarFactorCosto(pAño, pCodigoMes);

            //actualizar por recalculo fase masa y envasado
            ActualizarPorRecalculoFaseMasaYEnvasado(iLisProDet, iLisMovDetRec, iLisLib, iLisProExi);

            //actualizar por recalculo mano de obra y cif en semielaborados
            ActualizarPorRecalculoManoObraYCIFSemiProductos(iLisProDet, iLisForDet, iFactorCosto, iFacCifEN);

            //actualizar por recalculo unidades reproceso
            ActualizarPorRecalculoUnidadesReproceso(iLisProDet, iLisMovDetRec, iLisLib, iLisProExi);

            //actualizar por recalculo fase encajado
            ProduccionProTerRN.ActualizarPorRecalculoEncajado(iLisProProTer, iLisMovDetRec, iLisProExiEnc, iLisForDet, iFactorCosto, iFacCifEN);

            //listar todos los retiquetados ProTer de este proceso
            List<RetiquetadoProTerEN> iLisRetProTer = RetiquetadoProTerRN.ListarRetiquetadoProTerXPeriodoRetiquetado(pAño, pCodigoMes);

            //actualizar por recalculo retiquetado
            RetiquetadoRN.ActualizarPorRecalculoRetiquetado(iLisRet, iLisRetProTer, iLisMovDetRec, iLisProExiRet, iLisForDet, iFactorCosto, iFacCifEN);
        }

        public static void ActualizarPorRecalculoManoObraYCIFSemiProductos(List<ProduccionDetaEN> pLisProDet, List<FormulaDetaEN> pLisForDet,
            decimal pFactorManObr, FactorCIFEN pFacCif)
        {
            //recorrer cada producciondeta
            foreach (ProduccionDetaEN xProDet in pLisProDet)
            {
                //buscar a formuladeta por su codigoformula
                FormulaDetaEN iForDetEN = ListaG.Buscar<FormulaDetaEN>(pLisForDet, FormulaDetaEN.CodExiFor, xProDet.CodigoExistencia);

                //actualizar mano de obra
                ActualizarCostosManoObraProDet(xProDet, iForDetEN.RatioFormulaCabe, pFactorManObr);

                //actualizar el cif
                ActualizarCostosGastoIndirectoProDet(xProDet, pFacCif);
            }
        }

        public static List<List<ProduccionDetaEN>> ListarProduccionDetaParaRecalculoProduccion(string pAño, string pCodigoMes)
        {
            //traer a todas las produccionesdeta de este proceso(periodo)
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaParaRecalculoManoObra(pAño, pCodigoMes);

            //lo agrupamos en lista por dia
            return ListaG.ListarListas<ProduccionDetaEN>(iLisProDet, ProduccionDetaEN.FecProDet);
        }

        public static void ModificarProduccionDetaParaRegenerar(string pCodigoPeriodo)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            iProAD.ModificarProduccionDetaParaRegenerar(pCodigoPeriodo);
        }

        public static ProduccionDetaEN EsActoTransferirProduccionesChequeadas(List<ProduccionDetaEN> pLisProDetCheck, List<ProduccionDetaEN> pLisProDetTra)
        {
            //-----------------------------------------------------------------------------------------------------
            //esta funcion va a detener al usuario a no transferir materia prima al almacen de produccion,si es que
            //hay partes de trabajo chequeadas que son de diferente fecha o no son de la fecha mas antigua
            //-----------------------------------------------------------------------------------------------------

            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //obtener la fecha de produccion del primer objeto de la lista(es la fecha mas antigua)
            string iFechaMasAntigua = ListaG.ObtenerPrimerValor<ProduccionDetaEN>(pLisProDetTra, ProduccionDetaEN.FecProDet);

            //filtrar por esta fecha en la lista de producciones chequeadas por el usuario
            List<ProduccionDetaEN> iLisProDetNoFec = ListaG.FiltrarExcepto<ProduccionDetaEN>(pLisProDetCheck, ProduccionDetaEN.FecProDet, iFechaMasAntigua);

            //si la lista filtrada resulta como minimo un objeto,significa que hay producciones con otra fecha distinta a la fecha mas antigua
            if (iLisProDetNoFec.Count != 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Solo puedes seleccionar producciones de la fecha mas antigua";
            }

            //devolver
            return iProDetEN;
        }

        //public static void ActualizarPorRecalculoFaseMasaYEnvasado(List<ProduccionDetaEN> pLisProDet, List<MovimientoDetaEN> pLisMovDet,
        //    List<LiberacionEN> pLisLib,List<ProduccionExisEN> pLisProExi)
        //{
        //    //listas a grabar en bd
        //    List<ProduccionExisEN> iLisProExiMod = new List<ProduccionExisEN>();

        //    //lista de lista de movimientos por dia
        //    List<List<MovimientoDetaEN>> iLisLisMovDetDia = ListaG.ListarListas<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.FecMovCab);

        //    //recorrer cada lista produccionDeta
        //    foreach (ProduccionDetaEN xProDet in pLisProDet)
        //    {
        //        //pones cero al costo de reprocesos, este dato se actualizara en el recalculo unidades reproceso
        //        xProDet.CostoUnidadesReproceso = 0;

        //        //obtener solo la lista de produccionesExis solo de la fase masa y envasado de esta producciondeta
        //        List<ProduccionExisEN> iLisProExiFasMasEnv = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaProDet, xProDet.ClaveProduccionDeta);

        //        //obtener los movimientosDeta de la fase masa y envasado de esta produccionDeta
        //        //List<MovimientoDetaEN> iLisMovDetFasMas = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProDet.ClaveSalidaFaseMasa);

        //        //listar solo movimientos del dia de la produccion
        //        List<MovimientoDetaEN> iLisMovDetDia = ListaG.Buscar<MovimientoDetaEN>(iLisLisMovDetDia, MovimientoDetaEN.FecMovCab, xProDet.FechaProduccionDeta);

        //        //obtener otra lista de movimientos pero de los almacenes origen de cada existencia y que sean salida
        //        //(solo uno por cada existencia)
        //        iLisMovDetDia = MovimientoDetaRN.ListarMovimientosDetaParaActualizarCostosProduccionExis(iLisProExiFasMasEnv, iLisMovDetDia);

        //        //actualizar los precios unitarios de las ProduccionesExis
        //        ProduccionExisRN.ActualizarPreciosUnitariosDesdeMovimientosDeta(iLisProExiFasMasEnv, iLisMovDetDia);

        //        //actualizar costos fase masa                
        //        List<ProduccionExisEN> iLisProExiProDet = ListaG.Filtrar<ProduccionExisEN>(iLisProExiFasMasEnv, ProduccionExisEN.CTipDes, "0");
        //        List<MovimientoDetaEN> iLisMovDetPro = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDetDia, MovimientoDetaEN.ClaProDet, xProDet.ClaveProduccionDeta);
        //        ProduccionDetaRN.ActualizarCostosFaseMasa(xProDet, iLisProExiProDet, iLisMovDetPro);

        //        //actualizar costos fase envasado
        //        iLisProExiProDet = ListaG.Filtrar<ProduccionExisEN>(iLisProExiFasMasEnv, ProduccionExisEN.CTipDes, "1");
        //        ProduccionDetaRN.ActualizarCostosFaseControlCalidad(xProDet, iLisProExiProDet, iLisMovDetPro);

        //        //agregamos a la lista resultado a modificar en b.d
        //        iLisProExiMod.AddRange(iLisProExiFasMasEnv);

        //        //modificar a todas las liberaciones que se halla generado con esta produccionDeta
        //        ListaG.Modificar<LiberacionEN>(pLisLib, LiberacionEN.ClaProDet, xProDet.ClaveProduccionDeta, LiberacionEN.CosTotPro, xProDet.CostoTotalProducto);
        //    }

        //    //actualizar la lista pLisProExi con los nuevos datos obtenidos
        //    pLisProExi.Clear();
        //    pLisProExi.AddRange(iLisProExiMod);

        //    //grabaciones masivas en bd
        //    ProduccionExisRN.ModificarProduccionExis(iLisProExiMod);
        //}

        public static void ActualizarPorRecalculoFaseMasaYEnvasado(List<ProduccionDetaEN> pLisProDet, List<MovimientoDetaEN> pLisMovDet,
             List<LiberacionEN> pLisLib, List<ProduccionExisEN> pLisProExi)
        {
            //listas a grabar en bd
            List<ProduccionExisEN> iLisProExiMod = new List<ProduccionExisEN>();

            //lista de lista de movimientos por existencia
            List<List<MovimientoDetaEN>> iLisLisMovDetExi = ListaG.ListarListas<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodAlm, MovimientoDetaEN.CodExi);

            //recorrer cada lista produccionDeta
            foreach (ProduccionDetaEN xProDet in pLisProDet)
            {
                //pones cero al costo de reprocesos, este dato se actualizara en el recalculo unidades reproceso
                xProDet.CostoUnidadesReproceso = 0;

                //obtener solo la lista de produccionesExis solo de la fase masa y envasado de esta producciondeta
                List<ProduccionExisEN> iLisProExiFasMasEnv = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaProDet, xProDet.ClaveProduccionDeta);

                //obtener los movimientosDeta de la fase masa y envasado de esta produccionDeta
                //List<MovimientoDetaEN> iLisMovDetFasMas = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProDet.ClaveSalidaFaseMasa);

                //listar solo movimientos del dia de la produccion
                //List<MovimientoDetaEN> iLisMovDetDia = ListaG.Buscar<MovimientoDetaEN>(iLisLisMovDetDia, MovimientoDetaEN.FecMovCab, xProDet.FechaProduccionDeta);
                //List<MovimientoDetaEN> iLisMovDetDia = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.FecMovCab, xProDet.FechaProduccionDeta);

                //obtener otra lista de movimientos pero de los almacenes origen de cada existencia y que sean salida
                //(solo uno por cada existencia)
                List<MovimientoDetaEN> iLisMovDetDiaActCos = MovimientoDetaRN.ListarMovimientosDetaParaActualizarCostosProduccionExis(iLisProExiFasMasEnv, iLisLisMovDetExi);

                //actualizar los precios unitarios de las ProduccionesExis
                ProduccionExisRN.ActualizarPreciosUnitariosDesdeMovimientosDeta(iLisProExiFasMasEnv, iLisMovDetDiaActCos);

                //actualizar costos fase masa                
                List<ProduccionExisEN> iLisProExiProDet = ListaG.Filtrar<ProduccionExisEN>(iLisProExiFasMasEnv, ProduccionExisEN.CTipDes, "0");
                List<MovimientoDetaEN> iLisMovDetPro = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaProDet, xProDet.ClaveProduccionDeta);
                ProduccionDetaRN.ActualizarCostosFaseMasa(xProDet, iLisProExiProDet, iLisMovDetPro);

                //actualizar costos fase envasado
                iLisProExiProDet = ListaG.Filtrar<ProduccionExisEN>(iLisProExiFasMasEnv, ProduccionExisEN.CTipDes, "1");
                ProduccionDetaRN.ActualizarCostosFaseControlCalidad(xProDet, iLisProExiProDet, iLisMovDetPro);

                //agregamos a la lista resultado a modificar en b.d
                iLisProExiMod.AddRange(iLisProExiFasMasEnv);

                //modificar a todas las liberaciones que se halla generado con esta produccionDeta
                ListaG.Modificar<LiberacionEN>(pLisLib, LiberacionEN.ClaProDet, xProDet.ClaveProduccionDeta, LiberacionEN.CosTotPro, xProDet.CostoTotalProducto);
            }

            //actualizar la lista pLisProExi con los nuevos datos obtenidos
            pLisProExi.Clear();
            pLisProExi.AddRange(iLisProExiMod);

            //grabaciones masivas en bd
            ProduccionExisRN.ModificarProduccionExis(iLisProExiMod);
        }


        //public static void ActualizarPorRecalculoUnidadesReproceso(List<ProduccionDetaEN> pLisProDet, List<MovimientoDetaEN> pLisMovDet,
        //    List<LiberacionEN> pLisLib,List<ProduccionExisEN> pLisProExi)
        //{
        //    //obtener listas de listas por dia y existencia(solo almacen de reprocesos)
        //    List<List<MovimientoDetaEN>> iLisLisMovDetRepExiDia = MovimientoDetaRN.ListarListasMovimientosDetaReprocesoParaRecalculo(pLisMovDet);

        //    //lista de existencias para controlar el precio promedio
        //    List<ExistenciaEN> iLisExiPrePro = ExistenciaRN.ListarExistenciasParaRecalculoReprocesos(pLisMovDet);

        //    //listas para grabar en bd
        //    List<MovimientoDetaEN> iLisMovDetMod = new List<MovimientoDetaEN>();

        //    //recorrer cada lista
        //    foreach (List<MovimientoDetaEN> xLisMovDet in iLisLisMovDetRepExiDia)
        //    {
        //        //buscar a la existencia en la lista de control de precio promedio
        //        ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiPrePro, ExistenciaEN.CodExi, xLisMovDet[0].CodigoExistencia);

        //        //recorrer cada movimientodeta
        //        foreach (MovimientoDetaEN xMovDet in xLisMovDet)
        //        {
        //            //actualizamos los datos del movimiento deta con los datos de la existencia                
        //            //actualizar el precio unitario, ya que este puede estar mal solo en caso
        //            //de que no calcula precio promedio                   
        //            xMovDet.StockAnteriorExistencia = iExiBusEN.StockActualExistencia;
        //            xMovDet.PrecioAnteriorExistencia = iExiBusEN.PrecioPromedioExistencia;
        //            xMovDet.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculoReproceso(xMovDet, pLisLib);
        //            xMovDet.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(xMovDet);
        //            xMovDet.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
        //            xMovDet.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

        //            //ahora pasamos el nuevo stock y precio promedio a la existencia
        //            iExiBusEN.StockActualExistencia = xMovDet.StockExistencia;
        //            iExiBusEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;
        //        }

        //        //modificar a la existencia
        //        ListaG.Modificar<ExistenciaEN>(iLisExiPrePro, iExiBusEN, ExistenciaEN.CodExi, iExiBusEN.CodigoExistencia);

        //        //agregar a la lista resultado
        //        iLisMovDetMod.AddRange(xLisMovDet);

        //        //filtrar de la lista de movimientos deta solo los que son salidas
        //        List<MovimientoDetaEN> iLisMovDetExiDia = ListaG.Filtrar<MovimientoDetaEN>(xLisMovDet, MovimientoDetaEN.CClaTipOpe, "2");

        //        //recorrer cada produccion deta para actualizar los costos del reproceso
        //        foreach (MovimientoDetaEN xMovDetExiDia in iLisMovDetExiDia)
        //        {
        //            //buscar la producciondeta
        //            ProduccionDetaEN iProDetEN = ListaG.Buscar<ProduccionDetaEN>(pLisProDet, ProduccionDetaEN.ClaSalUniRep, xMovDetExiDia.ClaveMovimientoCabe);

        //            //actualizar el costo unidades reproceso
        //            iProDetEN.CostoUnidadesReproceso = xMovDetExiDia.CostoMovimientoDeta;

        //            //actualizar costos fase masa
        //            List<ProduccionExisEN> iLisProExiProDet = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaProDet, iProDetEN.ClaveProduccionDeta,
        //                ProduccionExisEN.CTipDes, "0");
        //            ProduccionDetaRN.ActualizarCostosFaseMasa(iProDetEN, iLisProExiProDet);

        //            //actualizar costos fase envasado
        //            iLisProExiProDet = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaProDet, iProDetEN.ClaveProduccionDeta,
        //                ProduccionExisEN.CTipDes, "1");
        //            ProduccionDetaRN.ActualizarCostosFaseControlCalidad(iProDetEN, iLisProExiProDet);

        //            //modificar a todas las liberaciones que se halla generado con esta produccionDeta
        //            ListaG.Modificar<LiberacionEN>(pLisLib, LiberacionEN.ClaProDet, iProDetEN.ClaveProduccionDeta, LiberacionEN.CosTotPro, iProDetEN.CostoTotalProducto);

        //            //modificar la produccionDeta
        //            ListaG.Modificar<ProduccionDetaEN>(pLisProDet, iProDetEN, ProduccionDetaEN.ClaProDet, iProDetEN.ClaveProduccionDeta);                
        //        }
        //    }

        //    //actualizar los precios unitarios de los movimientos deta de ingreso de semiproductos
        //    foreach (ProduccionDetaEN xProDet in pLisProDet)
        //    {
        //        //modificar el movimientoDta de ingreso al almacen de semiElaborado
        //        if (xProDet.ClaveIngresoSemiElaborado != string.Empty)
        //        {
        //            //buscar su movimientoDeta de ingreso al almacen de semiElaborado
        //            MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProDet.ClaveIngresoSemiElaborado);

        //            //actualizar el dato precio promedio
        //            iMovDetBusEN.PrecioUnitarioMovimientoDeta = xProDet.CostoTotalProducto;

        //            //agregar a la lista resultado
        //            iLisMovDetMod.Add(iMovDetBusEN);
        //        }
        //    }

        //    //modificar masivo en bd
        //    ProduccionDetaRN.ModificarProduccionDeta(pLisProDet);
        //    MovimientoDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
        //}

        public static void ActualizarPorRecalculoUnidadesReproceso(List<ProduccionDetaEN> pLisProDet, List<MovimientoDetaEN> pLisMovDet,
        List<LiberacionEN> pLisLib, List<ProduccionExisEN> pLisProExi)
        {
            //obtener listas de listas por dia y existencia(solo almacen de reprocesos)
            List<List<MovimientoDetaEN>> iLisLisMovDetRepExiDia = MovimientoDetaRN.ListarListasMovimientosDetaReprocesoParaRecalculo(pLisMovDet);

            //lista de existencias para controlar el precio promedio
            List<ExistenciaEN> iLisExiPrePro = ExistenciaRN.ListarExistenciasParaRecalculoReprocesos(pLisMovDet);

            //listas para grabar en bd
            List<MovimientoDetaEN> iLisMovDetMod = new List<MovimientoDetaEN>();

            //recorrer cada lista
            foreach (List<MovimientoDetaEN> xLisMovDet in iLisLisMovDetRepExiDia)
            {
                //buscar a la existencia en la lista de control de precio promedio
                ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiPrePro, ExistenciaEN.CodExi, xLisMovDet[0].CodigoExistencia);

                //recorrer cada movimientodeta
                foreach (MovimientoDetaEN xMovDet in xLisMovDet)
                {
                    //actualizamos los datos del movimiento deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio                   
                    xMovDet.StockAnteriorExistencia = iExiBusEN.StockActualExistencia;
                    xMovDet.PrecioAnteriorExistencia = iExiBusEN.PrecioPromedioExistencia;
                    xMovDet.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculoReproceso(xMovDet, pLisLib);
                    xMovDet.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(xMovDet);
                    xMovDet.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    xMovDet.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

                    //ahora pasamos el nuevo stock y precio promedio a la existencia
                    iExiBusEN.StockActualExistencia = xMovDet.StockExistencia;
                    iExiBusEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;
                }

                //modificar a la existencia
                ListaG.Modificar<ExistenciaEN>(iLisExiPrePro, iExiBusEN, ExistenciaEN.CodExi, iExiBusEN.CodigoExistencia);

                //agregar a la lista resultado
                iLisMovDetMod.AddRange(xLisMovDet);

                //filtrar de la lista de movimientos deta solo los que son salidas
                List<MovimientoDetaEN> iLisMovDetExiDia = ListaG.Filtrar<MovimientoDetaEN>(xLisMovDet, MovimientoDetaEN.CClaTipOpe, "2");

                //recorrer cada produccion deta para actualizar los costos del reproceso
                foreach (MovimientoDetaEN xMovDetExiDia in iLisMovDetExiDia)
                {
                    //buscar la producciondeta
                    ProduccionDetaEN iProDetEN = ListaG.Buscar<ProduccionDetaEN>(pLisProDet, ProduccionDetaEN.ClaSalUniRep, xMovDetExiDia.ClaveMovimientoCabe);

                    //actualizar el costo unidades reproceso
                    iProDetEN.CostoUnidadesReproceso = xMovDetExiDia.CostoMovimientoDeta;

                    //actualizar costos fase masa
                    List<ProduccionExisEN> iLisProExiProDet = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaProDet, iProDetEN.ClaveProduccionDeta,
                        ProduccionExisEN.CTipDes, "0");
                    ProduccionDetaRN.ActualizarCostosFaseMasa(iProDetEN, iLisProExiProDet);

                    //actualizar costos fase envasado
                    iLisProExiProDet = ListaG.Filtrar<ProduccionExisEN>(pLisProExi, ProduccionExisEN.ClaProDet, iProDetEN.ClaveProduccionDeta,
                        ProduccionExisEN.CTipDes, "1");
                    ProduccionDetaRN.ActualizarCostosFaseControlCalidad(iProDetEN, iLisProExiProDet);

                    //modificar a todas las liberaciones que se halla generado con esta produccionDeta
                    ListaG.Modificar<LiberacionEN>(pLisLib, LiberacionEN.ClaProDet, iProDetEN.ClaveProduccionDeta, LiberacionEN.CosTotPro, iProDetEN.CostoTotalProducto);

                    //modificar la produccionDeta
                    ListaG.Modificar<ProduccionDetaEN>(pLisProDet, iProDetEN, ProduccionDetaEN.ClaProDet, iProDetEN.ClaveProduccionDeta);
                }
            }

            //actualizar los precios unitarios de los movimientos deta de ingreso de semiproductos
            foreach (ProduccionDetaEN xProDet in pLisProDet)
            {
                //modificar el movimientoDta de ingreso al almacen de semiElaborado
                if (xProDet.ClaveIngresoSemiElaborado != string.Empty)
                {
                    //buscar su movimientoDeta de ingreso al almacen de semiElaborado
                    MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProDet.ClaveIngresoSemiElaborado);

                    //actualizar el dato precio promedio
                    iMovDetBusEN.PrecioUnitarioMovimientoDeta = xProDet.CostoTotalProducto;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetBusEN);
                }

                //modificar el movimientoDta de ingreso al almacen de bloqueadas
                if (xProDet.ClaveIngresoSemElaBloqueadas != string.Empty)
                {
                    //buscar su movimientoDeta de ingreso al almacen de semiElaborado
                    MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.ClaMovCab, xProDet.ClaveIngresoSemElaBloqueadas);

                    //actualizar el dato precio promedio
                    iMovDetBusEN.PrecioUnitarioMovimientoDeta = xProDet.CostoTotalProducto;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetBusEN);
                }
            }

            //modificar masivo en bd
            ProduccionDetaRN.ModificarProduccionDeta(pLisProDet);
            MovimientoDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
        }

        public static void ActualizarCostosFaseMasa(ProduccionDetaEN pObj, List<ProduccionExisEN> pLisProExi)
        {
            //obtener el costo fase masa principal
            pObj.CostoMasaPrincipal = ProduccionExisRN.ObtenerCostoTotal(pLisProExi);

            ////obtener el costo fase masa adicional
            //pObj.CostoMasaAdicional = ProduccionDetaRN.ObtenerCostoFaseMasaAdicional(pObj);

            ////obtener el costo fase devolucion
            //pObj.CostoMasaDevolucion = ProduccionDetaRN.ObtenerCostoFaseMasaDevolucion(pObj);

            //obtener el costo fase masa total
            pObj.CostoMasaTotal = ProduccionDetaRN.ObtenerCostoMasaTotal(pObj);

            //obtener costo de unidad de masa
            pObj.CostoUnidadMasa = ProduccionDetaRN.ObtenerCostoMasaUnidad(pObj);

            //obtener costo masa perdida
            pObj.CostoMasaPerdida = ProduccionDetaRN.ObtenerCostoMasaPerdida(pObj);
        }

        public static void ActualizarCostosFaseControlCalidad(ProduccionDetaEN pObj, List<ProduccionExisEN> pLisProExi)
        {
            //obtener el costo fase cc principal
            pObj.CostoConCalPrincipal = ProduccionExisRN.ObtenerCostoTotal(pLisProExi);

            ////obtener el costo cc masa adicional
            //pObj.CostoConCalAdicional = ProduccionDetaRN.ObtenerCostoFaseConCalAdicional(pObj);

            ////obtener el costo cc devolucion
            //pObj.CostoConCalDevolucion = ProduccionDetaRN.ObtenerCostoFaseConCalDevolucion(pObj);

            //obtener el costo cc masa total
            pObj.CostoConCalTotal = ProduccionDetaRN.ObtenerCostoControlCalidadTotal(pObj);

            //obtener costo de unidad de masa
            pObj.CostoUnidadConCal = ProduccionDetaRN.ObtenerCostoControlCalidadUnidad(pObj);

            //obtener el costo unidad insumos total de un semi elaborado
            pObj.CostoInsumos = ProduccionDetaRN.ObtenerCostoUnidadInsumosSemiElaborado(pObj);

            //obtener el costo total del semi elaborado
            pObj.CostoTotalProducto = ProduccionDetaRN.ObtenerCostoTotalProducto(pObj);
        }

        public static ProduccionDetaEN ObtenerProduccionDetaParaOperarFaseEmpaquetado(RetiquetadoEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.CodigoAlmacen = pObj.CodigoAlmacenRE;
            iProProTerEN.CodigoExistencia = pObj.CodigoExistenciaRE;

            //ejecutar metodo
            return ObtenerProduccionDetaParaOperarFaseEmpaquetado(iProProTerEN);
        }

        public static void ModificarPorIngresoInsumosDesmedroEnvasado(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoDesmedroEnvasado = pProDet.ClaveIngresoDesmedroEnvasado;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void CambiarMovimientosAlmacenReprocesos()
        {
            //traer la produccionDeta del rango elegido
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaXRangoFechaProduccion("01/05/2020", "01/10/2020");

            //recorrer cada objeto ProduccionDeta
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //si la produccion no genero movimiento de reprocesos, entonces pasa al siguiente objeto
                if (xProDet.ClaveSalidaUnidadesReproceso == string.Empty) { continue; }

                //traer al movimiento cabe
                MovimientoCabeEN iMovCabEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(xProDet.ClaveSalidaUnidadesReproceso);

                //actualizar datos
                iMovCabEN.CodigoAlmacen = "A18";//almacen de reprocesos
                iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
                iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

                //grabar en bd
                MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabEN);

                //traer los movimientos deta
                List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(xProDet.ClaveSalidaUnidadesReproceso);

                //recorrer cada objeto movimiento deta
                foreach (MovimientoDetaEN xMovDet in iLisMovDet)
                {
                    //actualizar datos
                    xMovDet.CodigoAlmacen = iMovCabEN.CodigoAlmacen;
                    xMovDet.NumeroMovimientoCabe = iMovCabEN.NumeroMovimientoCabe;
                    xMovDet.ClaveMovimientoCabe = iMovCabEN.ClaveMovimientoCabe;
                    xMovDet.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(xMovDet);

                    //grabar en bd
                    MovimientoDetaRN.AdicionarMovimientoDeta(xMovDet);
                }

                //eliminar el antiguo movimiento cabe
                MovimientoCabeRN.EliminarMovimientoCabe(xProDet.ClaveSalidaUnidadesReproceso);

                //eliminar el antiguo movimiento deta
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(xProDet.ClaveSalidaUnidadesReproceso);

                //modificar a la produccion
                xProDet.ClaveSalidaUnidadesReproceso = iMovCabEN.ClaveMovimientoCabe;

                //grabar en bd
                ModificarProduccionDeta(xProDet);
            }
        }

        public static List<ProduccionDetaEN> ListarProduccionesDetaReferenciadasEnProduccionProTer(List<ProduccionProTerEN> pLista)
        {
            //lista resultado
            List<ProduccionDetaEN> iLisRes = new List<ProduccionDetaEN>();

            //obtener todas las liberacionesProTer
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCamposDetalleCantidadesSemiProductoALista(pLista);

            //obtener claves liberacion para IN
            string iClaveLiberacion = ListaG.ArmarCadenaParaIN<LiberacionProTer>(iLisLibProTer, LiberacionProTer.ClaLib);

            //obtener la lista
            iLisRes = ListarProduccionDetaPorClavesLiberacion(iClaveLiberacion);

            //devolver
            return iLisRes;
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaPorClavesLiberacion(string pClavesLiberacion)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaPorClavesLiberacion(pClavesLiberacion);
        }

        public static decimal ObtenerCostoMasaUnidadTeorica(ProduccionDetaEN pObj)
        {
            //calcular            
            decimal iCostoUnidad = Math.Round(Operador.DivisionDecimal(pObj.CostoMasaPrincipal, pObj.CantidadSinceradoProduccionDeta), 2);

            //devolver
            return iCostoUnidad;
        }

        public static decimal ObtenerCostoEnvasadoUnidadTeorica(ProduccionDetaEN pObj)
        {
            //calcular            
            decimal iCostoUnidad = Math.Round(Operador.DivisionDecimal(pObj.CostoConCalPrincipal, pObj.CantidadSinceradoProduccionDeta), 2);

            //devolver
            return iCostoUnidad;
        }

        public static decimal ObtenerCostoReprocesoUnidadTeorica(ProduccionDetaEN pObj)
        {
            //calcular            
            decimal iCostoUnidad = Math.Round(Operador.DivisionDecimal(pObj.CostoUnidadesReproceso, pObj.CantidadSinceradoProduccionDeta), 2);

            //devolver
            return iCostoUnidad;
        }

        public static decimal ObtenerCostoUnidadTeorica(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor += ObtenerCostoMasaUnidadTeorica(pObj);
            iValor += ObtenerCostoEnvasadoUnidadTeorica(pObj);
            iValor += ObtenerCostoReprocesoUnidadTeorica(pObj);

            //devolver
            return iValor;
        }

        public static List<ProduccionDetaEN> ListarProduccionesDetaReferenciadasEnProduccionProTer(ProduccionProTerEN pProProTer, List<ProduccionDetaEN> pLista)
        {
            //lista resultado
            List<ProduccionDetaEN> iLisRes = new List<ProduccionDetaEN>();

            //listar las Liberaciones ProTer
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(pProProTer.DetalleCantidadesSemiProducto);

            //recorrer cada objeto
            foreach (LiberacionProTer xLibProTer in iLisLibProTer)
            {
                //buscar por claveProduccionDeta
                string iClaveProduccionDeta = ProduccionProTerRN.ObtenerClaveProduccionDeta(xLibProTer.ClaveLiberacion);
                ProduccionDetaEN iProDetEN = ListaG.Buscar<ProduccionDetaEN>(pLista, ProduccionDetaEN.ClaProDet, iClaveProduccionDeta);

                //agregar a la lista resultado
                iLisRes.Add(iProDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarCostosManoObraProDet(ProduccionDetaEN pObj)
        {
            //obtener la formulacabe de esta produccion
            FormulaCabeEN iForCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(ObtenerClaveFormulaCabe(pObj));

            //obtener el factor para esta produccion
            decimal iFactorCosto = FactorCostoRN.ObtenerFactorCosto(pObj);

            //actualizamos los datos de empaquetado
            ActualizarCostosManoObraProDet(pObj, iForCabEN.RatioFormulaCabe, iFactorCosto);

            //modificar en bd
            ModificarProduccionDeta(pObj);
        }

        public static void ActualizarCostosManoObraProDet(ProduccionDetaEN pObj, decimal pRatio, decimal pFactor)
        {
            //actualizar datos
            pObj.FactorProduccionProDet = pFactor;
            pObj.RatioProduccionProDet = pRatio;
            pObj.HorasHombre = ProduccionProTerRN.CalcularHorasHombre(pObj.RatioProduccionProDet, pObj.CantidadRealProduccion);
            pObj.CostoTotalManoObra = ProduccionProTerRN.CalcularCostoTotalManoObra(pObj.HorasHombre, pFactor);
            pObj.CostoManoObra = ProduccionProTerRN.CalcularCostoUnitarioManoObra(pObj.CostoTotalManoObra, pObj.CantidadRealProduccion);

            //obtener el costo unidad total del producto
            pObj.CostoTotalProducto = ProduccionDetaRN.ObtenerCostoTotalProducto(pObj);
        }

        public static void ModificarCostosIngresoIndirectoProDet(ProduccionDetaEN pObj)
        {
            //obtener el objeto factor para esta produccion
            FactorCIFEN iFacCifEN = FactorCIFRN.BuscarFactorCosto(pObj);

            //actualizamos los datos de empaquetado
            ActualizarCostosGastoIndirectoProDet(pObj, iFacCifEN);

            //modificar en bd
            ModificarProduccionDeta(pObj);
        }

        public static void ActualizarCostosGastoIndirectoProDet(ProduccionDetaEN pObj, FactorCIFEN pFac)
        {
            //actualizar datos
            pObj.FactorCIFFijo = FactorCIFRN.ObtenerFactorCIFFijo(pFac);
            pObj.CostoCIFFijo = ProduccionProTerRN.CalcularCostoUnitarioGastoIndirecto(pObj.FactorCIFFijo, pObj.MasaUnidad);
            pObj.FactorCIFVariable = FactorCIFRN.ObtenerFactorCIFVariable(pFac);
            pObj.CostoCIFVariable = ProduccionProTerRN.CalcularCostoUnitarioGastoIndirecto(pObj.FactorCIFVariable, pObj.MasaUnidad);

            //obtener el costo unidad total del producto
            pObj.CostoTotalProducto = ObtenerCostoTotalProducto(pObj);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaParaReporteCostoLoteFaseEnvasado(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaParaReporteCostoLoteFaseEnvasado(pObj);
        }

        public static List<ProduccionDetaEN> ObtenerReporteCostoLoteFaseEnvasado(ProduccionDetaEN pObj)
        {
            //traer la lista para el reporte
            List<ProduccionDetaEN> iLisRes = ListarProduccionDetaParaReporteCostoLoteFaseEnvasado(pObj);

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in iLisRes)
            {
                //actualizar campos
                xProDet.CostoCIFVariable = ObtenerCostoTotalCIFVariable(xProDet);
                xProDet.CostoTotalVariable = ObtenerCostoTotalVariable(xProDet);
                xProDet.CostoCIFFijo = ObtenerCostoTotalCIFFijo(xProDet);
                xProDet.CostoTotalEnvasado = ObtenerCostoTotalEnvasado(xProDet);
                xProDet.CostoUnidadesAprobadasLiberacion = ObtenerCostoUnidadesAprobadas(xProDet);
                xProDet.CostoUnidadesReprocesoLiberacion = ObtenerCostoUnidadesReprocesos(xProDet);
                xProDet.CostoUnidadesDesechasLiberacion = ObtenerCostoUnidadesDesechadas(xProDet);
                xProDet.CostoUnidadesDonacionLiberacion = ObtenerCostoUnidadesDonadas(xProDet);
                xProDet.CostoUnidadesObservadasLiberacion = ObtenerCostoUnidadesObservadas(xProDet);
                xProDet.CostoUnidadesMuestraLiberacion = ObtenerCostoUnidadesMuestras(xProDet);
                xProDet.CostoUnidadesPorLiberarLiberacion = ObtenerCostoUnidadesPorLiberar(xProDet);
                xProDet.CostoUnidadesPorDesbloquearLiberacion = ObtenerCostoUnidadesPorDesbloquear(xProDet);
                xProDet.PorcentajeUnidadesDesechasLiberacion = ObtenerPorcentajeDesmedro(xProDet);
            }

            //obtener objeto totales
            ProduccionDetaEN iProDetTot = ObtenerObjetoTotalesReporteCostosLoteFaseEnvasado(iLisRes);

            //agregar a la lista resultado
            iLisRes.Add(iProDetTot);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCostoTotalCIFVariable(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.CostoCIFVariable * pObj.CantidadRealProduccion, 2);
        }

        public static decimal ObtenerCostoTotalCIFFijo(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.CostoCIFFijo * pObj.CantidadRealProduccion, 2);
        }

        public static decimal ObtenerCostoTotalVariable(ProduccionDetaEN pObj)
        {
            return pObj.CostoMasaTotal + pObj.CostoConCalTotal + pObj.CostoUnidadesReproceso + pObj.CostoTotalManoObra + pObj.CostoCIFVariable;
        }

        public static decimal ObtenerCostoTotalEnvasado(ProduccionDetaEN pObj)
        {
            return pObj.CostoTotalVariable + pObj.CostoCIFFijo;
        }

        public static decimal ObtenerCostoUnidadesAprobadas(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.UnidadesAprobadasLiberacion * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesReprocesos(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.UnidadesReprocesoLiberacion * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesDesechadas(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.UnidadesDesechasLiberacion * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesDonadas(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.UnidadesDonacionLiberacion * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesMuestras(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.UnidadesMuestraLiberacion * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesObservadas(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.UnidadesObservadasLiberacion * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesPorLiberar(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.SaldoLiberacion * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesPorDesbloquear(ProduccionDetaEN pObj)
        {
            return Math.Round(pObj.SaldoLiberacionBloqueadas * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerPorcentajeDesmedro(ProduccionDetaEN pObj)
        {
            return Operador.Porcentaje(pObj.UnidadesDesechasLiberacion, pObj.CantidadRealProduccion, 3);
        }

        public static ProduccionDetaEN ObtenerObjetoTotalesReporteCostosLoteFaseEnvasado(List<ProduccionDetaEN> pLista)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //obtener la lista acumulada de pLista            
            List<ProduccionDetaEN> iLisProProTerAcu = ListaG.Acumular<ProduccionDetaEN>(pLista, ProduccionDetaEN.CodEmp,
                ObtenerListaCamposAAcumularReporteCostosLoteFaseEnvasado());

            //si la lista esta vacia
            if (iLisProProTerAcu.Count != 0)
            {
                iProDetEN = ObjetoG.Clonar<ProduccionDetaEN>(iLisProProTerAcu[0]);
            }

            //actualizar datos a este objeto
            iProDetEN.FechaProduccionDeta = string.Empty;
            iProDetEN.CorrelativoProduccionCabe = string.Empty;
            iProDetEN.CodigoSemiProducto = string.Empty;
            iProDetEN.DescripcionSemiProducto = "TOTALES";
            iProDetEN.CantidadRealProduccion = 0;
            iProDetEN.CostoTotalProducto = 0;

            //devolver
            return iProDetEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostosLoteFaseEnvasado()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(ProduccionDetaEN.CosMasTot);
            iLisRes.Add(ProduccionDetaEN.CosUniRep);
            iLisRes.Add(ProduccionDetaEN.CosConCalTot);
            iLisRes.Add(ProduccionDetaEN.CosTotManObr);
            iLisRes.Add(ProduccionDetaEN.CosCIFVar);
            iLisRes.Add(ProduccionDetaEN.CosTotVar);
            iLisRes.Add(ProduccionDetaEN.CosCIFFij);
            iLisRes.Add(ProduccionDetaEN.CosTotEnv);
            iLisRes.Add(ProduccionDetaEN.UniAprLib);
            iLisRes.Add(ProduccionDetaEN.UniRepLib);
            iLisRes.Add(ProduccionDetaEN.UniDesLib);
            iLisRes.Add(ProduccionDetaEN.CosUniAprLib);
            iLisRes.Add(ProduccionDetaEN.CosUniRepLib);
            iLisRes.Add(ProduccionDetaEN.CosUniDesLib);

            //devolver
            return iLisRes;
        }

        public static void ActualizarAcumuladosLiberacion()
        {
            //traer la produccionDeta del rango elegido
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaXRangoFechaProduccion("01/05/2020", "01/10/2020");

            //traer todas las liberaciones de bd
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacion();

            //acumular vpor ClaveProduccionDeta
            List<string> iLisCol = new List<string> { LiberacionEN.UniPas, LiberacionEN.UniParRep, LiberacionEN.UniParDon, LiberacionEN.UniParMue, LiberacionEN.UniDes };
            List<LiberacionEN> iLisLibAcu = ListaG.Acumular<LiberacionEN>(iLisLib, LiberacionEN.ClaProDet, iLisCol);

            //recorrer cada objeto ProduccionDeta
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //buscar en liberacion
                LiberacionEN iLibBusEN = ListaG.Buscar<LiberacionEN>(iLisLibAcu, LiberacionEN.ClaProDet, xProDet.ClaveProduccionDeta);

                //actualizar datos
                xProDet.UnidadesAprobadasLiberacion = iLibBusEN.UnidadesPasan;
                xProDet.UnidadesReprocesoLiberacion = iLibBusEN.UnidadesParaReproceso;
                xProDet.UnidadesDonacionLiberacion = iLibBusEN.UnidadesParaDonacion;
                xProDet.UnidadesMuestraLiberacion = iLibBusEN.UnidadesParaMuestra;
                xProDet.UnidadesDesechasLiberacion = iLibBusEN.UnidadesDesechas;
            }

            //modificacion masiva
            ProduccionDetaRN.ModificarProduccionDeta(iLisProDet);
        }

        public static ProduccionDetaEN EsActoEliminarSalidaUnidadesAReprocesar(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida cuando no es acto registrar en este periodo
            iProDetEN = ProduccionDetaRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iProDetEN.Adicionales.EsVerdad == false) { return iProDetEN; }

            //validar si existe
            iProDetEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProDetEN.Adicionales.EsVerdad == false) { return iProDetEN; }

            //valida cuando no genera la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroSalidaUnidadesAReprocesar(iProDetEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //valida cuando ya genero el ingreso de mercaderias
            ProduccionDetaEN iProDetIngInsEN = ProduccionDetaRN.ValidaCuandoGeneroIngresoDesmedro(iProDetEN);
            if (iProDetIngInsEN.Adicionales.EsVerdad == false) { return iProDetIngInsEN; }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroSalidaUnidadesAReprocesar(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveSalidaUnidadesReproceso == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera la Salida de Unidades a reprocesar, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoGeneroIngresoDesmedro(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoDesmedroEnvasado != string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Ya se genero el Ingreso de desmedro, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static void AccionEliminarSalidaUnidadesAReprocesar(ProduccionDetaEN pObj)
        {
            //eliminar el MovimientoCabe
            MovimientoCabeRN.EliminarMovimientoCabe(pObj.ClaveSalidaUnidadesReproceso);

            //actualizar las existencias por eliminacion
            ExistenciaRN.ActualizarExistenciasPorEliminacion(pObj.ClaveSalidaUnidadesReproceso);

            //eliminar MovimientosDeta
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(pObj.ClaveSalidaUnidadesReproceso);

            //eliminar lotes deta
            LoteDetaRN.EliminarLoteDeta(pObj.ClaveSalidaUnidadesReproceso);

            //modificar el parte trabajo
            ProduccionDetaRN.ModificarPorEliminacionSalidaUnidadesAReprocesar(pObj);
        }

        public static void ModificarPorEliminacionSalidaUnidadesAReprocesar(ProduccionDetaEN pObj)
        {
            //actualizamos datos            
            pObj.ClaveSalidaUnidadesReproceso = string.Empty;

            //modificamos en b.d
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static decimal ObtenerPorcentajeRangoSincerado(ProduccionDetaEN pObj)
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iProCabEN.CodigoExistencia = pObj.CodigoExistencia;
            iProCabEN.CantidadProduccionCabe = pObj.CantidadSinceradoProduccionDeta;
            iProCabEN.UnidadesReproceso = pObj.UnidadesReproceso;

            //ejecutar metodo
            return ProduccionCabeRN.ObtenerPorcentajeRango(iProCabEN);
        }

        public static decimal ObtenerCantidadRangoSincerado(ProduccionDetaEN pObj)
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CantidadProduccionCabe = pObj.CantidadSinceradoProduccionDeta;
            iProCabEN.UnidadesReproceso = pObj.UnidadesReproceso;
            iProCabEN.PorcentajeRango = pObj.PorcentajeSinceradoRango;

            //ejecutar metodo

            return ProduccionCabeRN.ObtenerCantidadRango(iProCabEN);
        }

        public static List<CumplimientoProduccion> ObtenerReportePorcentajeCumplimientoProduccion(string pAño, string pCodigoMes)
        {
            //lista resultado
            List<CumplimientoProduccion> iLisRes = new List<CumplimientoProduccion>();

            //traer la produccion del mes
            List<ProduccionDetaEN> iLisProDet = ListarProduccionDetaParaRecalculoManoObra(pAño, pCodigoMes);

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //crear un nuevo objeto cumplimiento produccion
                CumplimientoProduccion iCumPro = new CumplimientoProduccion();

                //actualizar sus datos
                iCumPro.Semana = "SEM" + Fecha.ObtenerSemanaDelAño(xProDet.FechaProduccionDeta);
                iCumPro.NTurno = xProDet.NTurno;
                iCumPro.CorrelativoProduccionCabe = xProDet.CorrelativoProduccionCabe;
                iCumPro.CodigoSemiProducto = xProDet.CodigoSemiProducto;
                iCumPro.DescripcionSemiProducto = xProDet.DescripcionSemiProducto;
                iCumPro.FechaProduccion = xProDet.FechaProduccionDeta;
                iCumPro.NombreMes = Fecha.ObtenerMesNombre(xProDet.FechaProduccionDeta);
                iCumPro.KgItem = Math.Round(xProDet.MasaUnidad / 1000, 5);
                iCumPro.CantidadPlanificada = xProDet.CantidadProduccionDeta;
                iCumPro.CantidadSincerada = xProDet.CantidadSinceradoProduccionDeta;
                iCumPro.KgPlanificada = Math.Round(iCumPro.KgItem * iCumPro.CantidadPlanificada, 2);
                iCumPro.KgSincerado = Math.Round(iCumPro.KgItem * iCumPro.CantidadSincerada, 2);
                iCumPro.CantidadProducido = xProDet.CantidadRealProduccion;
                iCumPro.CantidadLiberado = xProDet.UnidadesAprobadasLiberacion;
                iCumPro.KgProducido = Math.Round(iCumPro.KgItem * iCumPro.CantidadProducido, 2);
                iCumPro.KgLiberado = Math.Round(iCumPro.KgItem * iCumPro.CantidadLiberado, 2);
                iCumPro.resultado = iCumPro.CantidadSincerada - iCumPro.CantidadLiberado;
                iCumPro.resultado2 = iCumPro.KgLiberado - iCumPro.KgSincerado;
                iCumPro.PorcentajeCumplimientoBruto = ObtenerPorcentajeCumplimientoBruto(iCumPro);
                iCumPro.PorcentajeCumplimientoNeto = ObtenerPorcentajeCumplimientoNeto(iCumPro);

                //agregar a la lista resultado
                iLisRes.Add(iCumPro);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerPorcentajeCumplimientoBruto(CumplimientoProduccion pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular cociente
            decimal iCociente = Operador.DivisionDecimal(pObj.KgProducido, pObj.KgSincerado);

            //condicion
            if (iCociente < 1)
            {
                iValor = Math.Round(iCociente * 100, 2);
            }
            else
            {
                iValor = 100;
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerPorcentajeCumplimientoNeto(CumplimientoProduccion pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular cociente
            decimal iCociente = Operador.DivisionDecimal(pObj.KgLiberado, pObj.KgSincerado);

            //condicion
            if (iCociente < 1)
            {
                iValor = Math.Round(iCociente * 100, 2);
            }
            else
            {
                iValor = 100;
            }

            //devolver
            return iValor;
        }

        public static ProduccionDetaEN EsValidoCantidadSincerado(ProduccionDetaEN pObj)
        {
            //valor resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //validar
            ProduccionCabeEN iProCabEN = ProduccionCabeRN.BuscarProduccionCabeXClave(pObj.ClaveProduccionCabe);
            if (pObj.CantidadSinceradoProduccionDeta > iProCabEN.CantidadSinceradoProduccionCabe)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "La cantidad sincerada no puede ser mayor que la cantidad Sincerada en la solicitud";
            }

            //ok
            return iProDetEN;
        }

        public static void ActualizarCostosFaseMasa(ProduccionDetaEN pObj, List<ProduccionExisEN> pLisProExi, List<MovimientoDetaEN> pLisMovDetPro)
        {
            //obtener el costo fase masa principal
            pObj.CostoMasaPrincipal = ProduccionExisRN.ObtenerCostoTotal(pLisProExi);

            //obtener el costo fase masa adicional
            pObj.CostoMasaAdicional = ProduccionDetaRN.ObtenerCostoAdicional(pLisProExi, pLisMovDetPro);

            //obtener el costo fase devolucion
            pObj.CostoMasaDevolucion = ProduccionDetaRN.ObtenerCostoDevolucion(pLisProExi, pLisMovDetPro);

            //obtener el costo fase masa total
            pObj.CostoMasaTotal = ProduccionDetaRN.ObtenerCostoMasaTotal(pObj);

            //obtener costo de unidad de masa
            pObj.CostoUnidadMasa = ProduccionDetaRN.ObtenerCostoMasaUnidad(pObj);

            //obtener costo masa perdida
            pObj.CostoMasaPerdida = ProduccionDetaRN.ObtenerCostoMasaPerdida(pObj);
        }

        public static decimal ObtenerCostoAdicional(List<ProduccionExisEN> pLisProExiMas, List<MovimientoDetaEN> pLisMovDetPro)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular            
            //armar una cadena con todos los codigos de existencia
            string iCodigosExistencia = ListaG.ArmarCadenaDeValores<ProduccionExisEN>(pLisProExiMas, ProduccionExisEN.CodExi, ",");

            //filtrar los movimientosDeta de solo estos codigosexistencias
            List<MovimientoDetaEN> iLisMovDet = ListaG.FiltrarPorConjuntoValores<MovimientoDetaEN>(pLisMovDetPro, MovimientoDetaEN.CodExi,
                iCodigosExistencia);

            //filtrar solo movimientosDeta de tipo "salida"
            iLisMovDet = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CClaTipOpe, "2");

            //recorrer cada objeto produccionexis
            foreach (MovimientoDetaEN xMovDet in iLisMovDet)
            {
                //buscar la existencia en la lista produccionExis
                ProduccionExisEN iProExiEN = ListaG.Buscar<ProduccionExisEN>(pLisProExiMas, ProduccionExisEN.CodExi, xMovDet.CodigoExistencia);

                //calcular
                iValor += iProExiEN.PrecioUnitario * xMovDet.CantidadMovimientoDeta;
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoDevolucion(List<ProduccionExisEN> pLisProExiMas, List<MovimientoDetaEN> pLisMovDetPro)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular           
            //armar una cadena con todos los codigos de existencia
            string iCodigosExistencia = ListaG.ArmarCadenaDeValores<ProduccionExisEN>(pLisProExiMas, ProduccionExisEN.CodExi, ",");

            //filtrar los movimientosDeta de solo estos codigosexistencias
            List<MovimientoDetaEN> iLisMovDet = ListaG.FiltrarPorConjuntoValores<MovimientoDetaEN>(pLisMovDetPro, MovimientoDetaEN.CodExi,
                iCodigosExistencia);

            //filtrar solo movimientosDeta de tipo "ingreso"
            iLisMovDet = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CClaTipOpe, "1");

            //recorrer cada objeto produccionexis
            foreach (MovimientoDetaEN xMovDet in iLisMovDet)
            {
                //buscar la existencia en la lista produccionExis
                ProduccionExisEN iProExiEN = ListaG.Buscar<ProduccionExisEN>(pLisProExiMas, ProduccionExisEN.CodExi, xMovDet.CodigoExistencia);

                //calcular
                iValor += iProExiEN.PrecioUnitario * xMovDet.CantidadMovimientoDeta;
            }

            //devolver
            return iValor;
        }

        public static void ActualizarCostosFaseControlCalidad(ProduccionDetaEN pObj, List<ProduccionExisEN> pLisProExi, List<MovimientoDetaEN> pLisMovDetPro)
        {
            //obtener el costo fase cc principal
            pObj.CostoConCalPrincipal = ProduccionExisRN.ObtenerCostoTotal(pLisProExi);

            //obtener el costo cc masa adicional
            pObj.CostoConCalAdicional = ProduccionDetaRN.ObtenerCostoAdicional(pLisProExi, pLisMovDetPro);

            //obtener el costo fase devolucion
            pObj.CostoConCalDevolucion = ProduccionDetaRN.ObtenerCostoDevolucion(pLisProExi, pLisMovDetPro);

            //obtener el costo cc masa total
            pObj.CostoConCalTotal = ProduccionDetaRN.ObtenerCostoControlCalidadTotal(pObj);

            //obtener costo de unidad de masa
            pObj.CostoUnidadConCal = ProduccionDetaRN.ObtenerCostoControlCalidadUnidad(pObj);

            //obtener el costo unidad insumos total de un semi elaborado
            pObj.CostoInsumos = ProduccionDetaRN.ObtenerCostoUnidadInsumosSemiElaborado(pObj);

            //obtener el costo total del semi elaborado
            pObj.CostoTotalProducto = ProduccionDetaRN.ObtenerCostoTotalProducto(pObj);
        }

        public static decimal ObtenerCantidadObservadas(ProduccionDetaEN pObj)
        {
            return pObj.NumeroUnidadesMasa - pObj.CantidadEncajonar - pObj.CantidadContraMuestra - pObj.CantidadMuestraProduccion;
        }

        public static void ModificarPorIngresoSemElaObservadas(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoSemElaBloqueadas = pProDet.ClaveIngresoSemElaBloqueadas;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarPorIngresoSemElaContraMuestra(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoSemElaContraMuestra = pProDet.ClaveIngresoSemElaContraMuestra;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarPorIngresoSemElaMuestraProduccion(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoSemElaMuestraProduccion = pProDet.ClaveIngresoSemElaMuestraProduccion;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static ProduccionDetaEN EsActoIngresarUnidadesSemElaObservadas(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaBloquear(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoIngresarUnidadesSemElaMuestraProduccion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaMuestraProduccion(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoIngresarUnidadesSemElaContraMuestra(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaContraMuestra(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaBloquear(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CantidadBloquear == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para Bloqueados, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaMuestraProduccion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CantidadMuestraProduccion == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para Muestra, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaContraMuestra(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CantidadContraMuestra == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para Contra Muestra, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoImprimirIngresoProductoSemiElaboradoObservados(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroIngresoProductoSemiElaboradoObservados(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoImprimirIngresoProductoSemiElaboradoContraMuestra(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos            
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroIngresoProductoSemiElaboradoContraMuestra(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoImprimirIngresoProductoSemiElaboradoMuestraProduccion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos            
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroIngresoProductoSemiElaboradoMuestraProduccion(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroIngresoProductoSemiElaboradoObservados(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoSemElaBloqueadas == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el ingreso del producto semi elaborado a observados, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroIngresoProductoSemiElaboradoContraMuestra(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoSemElaContraMuestra == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el ingreso del producto semi elaborado a contra muestra, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroIngresoProductoSemiElaboradoMuestraProduccion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoSemElaMuestraProduccion == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el ingreso del producto semi elaborado a muestras, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static void ModificarProduccionDetaAlAdicionarPorLiberacionDist(LiberacionEN pObj)
        {
            //traer a la ProduccionDeta de la b.d           
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj.ClaveProduccionDeta);

            //primero actualizamos el objeto 
            if (pObj.CAlmacenLiberacion == "0")
            {
                iProDetEN.SaldoLiberacion -= pObj.CantidadLiberacion;
            }
            else
            {
                iProDetEN.SaldoLiberacionBloqueadas -= pObj.CantidadLiberacion;
            }

            iProDetEN.UnidadesAprobadasLiberacion += pObj.UnidadesPasan;
            iProDetEN.UnidadesReprocesoLiberacion += pObj.UnidadesParaReproceso;
            iProDetEN.UnidadesDonacionLiberacion += pObj.UnidadesParaDonacion;
            iProDetEN.UnidadesMuestraLiberacion += pObj.UnidadesParaMuestra;
            iProDetEN.UnidadesDesechasLiberacion += pObj.UnidadesDesechas;

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static ProduccionDetaEN ValidaCuandoUnidadesObservadasEstanEnNegativo(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //validar            
            if (pObj.CantidadBloquear < 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "La cantidad de unidades observadas no pueden ser negativo ";
            }

            //devolver
            return iProDetEN;
        }

        public static decimal ObtenerCantidadDesechasQali(ProduccionDetaEN pObj)
        {
            return pObj.NumeroUnidadesMasa - pObj.CantidadCuarentenaQali - pObj.CantidadMuestraQali - pObj.CantidadReprocesoQali;
        }

        public static ProduccionDetaEN ValidaCuandoUnidadesDesechasQaliEstanEnNegativo(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //validar            
            if (pObj.CantidadDesechoQali < 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "La cantidad de unidades desechas no pueden ser negativo ";
            }

            //devolver
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoIngresarPrimeraLiberacion(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoEsDeCuarentena(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //validar            
            if (pObj.CManejaCuarentena == "0")
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No es produccion con cuarentena";
            }

            //devolver
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoSiEsDeCuarentena(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //validar            
            if (pObj.CManejaCuarentena == "1")
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Esta es produccion con cuarentena";
            }

            //devolver
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoModificarUnidadesSelladas(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //validar            
            if (pObj.CantidadEncajonar != pObj.SaldoLiberacion || pObj.CantidadBloquear != pObj.SaldoLiberacionBloqueadas ||
                pObj.CantidadCuarentenaQali != pObj.SaldoLiberacionCuarentenaQali)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No se puede modificar";
            }

            //devolver
            return iProDetEN;
        }

        public static void ActualizarDatosSugeridosPorEditarUnidadesSelladas(ProduccionDetaEN pObj)
        {
            //segun que tipo de formula es,si es con cuarentena o no
            if (pObj.CManejaCuarentena == "0")//no
            {
                //pObj.CantidadEncajonar = pObj.NumeroUnidadesMasa;
                //pObj.SaldoLiberacion = pObj.NumeroUnidadesMasa;
                pObj.CantidadBloquear = 0;
                pObj.SaldoLiberacionBloqueadas = 0;
                pObj.CantidadCuarentenaQali = 0;
                pObj.SaldoLiberacionCuarentenaQali = 0;
            }
            else
            {
                //pObj.CantidadCuarentenaQali = pObj.NumeroUnidadesMasa;
                //pObj.SaldoLiberacionCuarentenaQali = pObj.NumeroUnidadesMasa;
                pObj.CantidadEncajonar = 0;
                pObj.SaldoLiberacion = 0;
                pObj.CantidadBloquear = 0;
                pObj.SaldoLiberacionBloqueadas = 0;
            }
        }

        public static void ModificarPorIngresoCuarentenaQali(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoCuarentenaQali = pProDet.ClaveIngresoCuarentenaQali;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static ProduccionDetaEN EsActoImprimirIngresoCuarentenaQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroIngresoCuarentenaQali(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroIngresoCuarentenaQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoCuarentenaQali == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el ingreso del producto semi elaborado a Cuarentena, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoIngresoCuarentenaQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetDigCua = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaCuarentenaQali(iProCabEN);
            if (iProDetDigCua.Adicionales.EsVerdad == false) { return iProDetDigCua; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaCuarentenaQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CantidadCuarentenaQali == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para cuarentena, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoImprimirIngresoReprocesoQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroIngresoReprocesoQali(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoImprimirIngresoMuestraQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroIngresoMuestraQali(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroIngresoReprocesoQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoReprocesoQali == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el ingreso del producto semi elaborado a Reproceso, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroIngresoMuestraQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoMuestraQali == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el ingreso del producto semi elaborado a muestra, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static void ModificarPorIngresoReprocesoQali(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoReprocesoQali = pProDet.ClaveIngresoReprocesoQali;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarPorIngresoMuestraQali(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoMuestraQali = pProDet.ClaveIngresoMuestraQali;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static ProduccionDetaEN EsActoIngresoReprocesoQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniRep = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaReprocesoQali(iProCabEN);
            if (iProDetUniRep.Adicionales.EsVerdad == false) { return iProDetUniRep; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoIngresoMuestraQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniMue = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaMuestraQali(iProCabEN);
            if (iProDetUniMue.Adicionales.EsVerdad == false) { return iProDetUniMue; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaReprocesoQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CantidadReprocesoQali == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para reprocesar, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaMuestraQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CantidadMuestraQali == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para muestra, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoImprimirIngresoDesechoQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetSalInsEN = ProduccionDetaRN.ValidaCuandoNoGeneroIngresoDesechoQali(iProCabEN);
            if (iProDetSalInsEN.Adicionales.EsVerdad == false) { return iProDetSalInsEN; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneroIngresoDesechoQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoDesechoQali == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Aun no genera el ingreso del producto semi elaborado a Desecho, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static void ModificarPorIngresoDesechoQali(ProduccionDetaEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pProDet);

            //actualizamos los datos
            iProDetEN.ClaveIngresoDesechoQali = pProDet.ClaveIngresoDesechoQali;

            //modificar en bd
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static ProduccionDetaEN EsActoIngresoDesechoQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniSell = ProduccionDetaRN.ValidaCuandoNoEditaLasUnidadesSelladas(iProCabEN);
            if (iProDetUniSell.Adicionales.EsVerdad == false) { return iProDetUniSell; }

            //valida cuando no es de primera liberacion
            ProduccionDetaEN iProDetCua = ProduccionDetaRN.ValidaCuandoNoEsDeCuarentena(iProCabEN);
            if (iProDetCua.Adicionales.EsVerdad == false) { return iProDetCua; }

            //valida cuando no genera la salida de insumos fase materia prima
            ProduccionDetaEN iProDetUniRep = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaDesechoQali(iProCabEN);
            if (iProDetUniRep.Adicionales.EsVerdad == false) { return iProDetUniRep; }

            //ok            
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaDesechoQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.CantidadDesechoQali == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para Desecho, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoLiberarEncajados(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetDigEN = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaEncajar(iProCabEN);
            if (iProDetDigEN.Adicionales.EsVerdad == false) { return iProDetDigEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoGeneraIngresoSemiElaboradas(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN EsActoAnalizarBloqueados(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetDigEN = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaBloquear(iProCabEN);
            if (iProDetDigEN.Adicionales.EsVerdad == false) { return iProDetDigEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoGeneraIngresoSemiElaboradasBloqueados(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneraIngresoSemiElaboradasBloqueados(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoSemElaBloqueadas == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Debes generar el ingreso de las unidades semi elaboradas Bloqueados, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN EsActoLiberarCuarentena(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetDigEN = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaCuarentenaQali(iProCabEN);
            if (iProDetDigEN.Adicionales.EsVerdad == false) { return iProDetDigEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoGeneraIngresoCuarentenaQali(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneraIngresoCuarentenaQali(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.ClaveIngresoCuarentenaQali == string.Empty)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "Debes generar el ingreso de las unidades semi elaboradas cuarentena, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoUnidadesReprocesoNoTieneIgualCantidadUnidadesMotivos(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iLibEN = new ProduccionDetaEN();

            //validar            
            List<ItemGEN> iLisIteG = new List<ItemGEN>();
            List<MotivoLiberacion> iLisMotLib = LiberacionRN.ConvertirCampoDetalleMotivoALista(pObj.DetalleMotivoReprocesoQali, iLisIteG);
            decimal iCantidadSugerida = LiberacionRN.CantidadMotivoLiberacionSugerida(pObj.CantidadReprocesoQali, iLisMotLib);
            if (pObj.CantidadReprocesoQali != 0 && iCantidadSugerida != 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Las cantidades en los motivos no suman la cantidad para reprocesar";
            }

            //devolver
            return iLibEN;
        }

        public static ProduccionDetaEN ValidaCuandoUnidadesMuestraNoTieneIgualCantidadUnidadesMotivos(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iLibEN = new ProduccionDetaEN();

            //validar            
            List<ItemGEN> iLisIteG = new List<ItemGEN>();
            List<MotivoLiberacion> iLisMotLib = LiberacionRN.ConvertirCampoDetalleMotivoALista(pObj.DetalleMotivoMuestraQali, iLisIteG);
            decimal iCantidadSugerida = LiberacionRN.CantidadMotivoLiberacionSugerida(pObj.CantidadMuestraQali, iLisMotLib);
            if (pObj.CantidadMuestraQali != 0 && iCantidadSugerida != 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Las cantidades en los motivos no suman la cantidad para muestra";
            }

            //devolver
            return iLibEN;
        }

        public static ProduccionDetaEN ValidaCuandoUnidadesDesechaNoTieneIgualCantidadUnidadesMotivos(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iLibEN = new ProduccionDetaEN();

            //validar            
            List<ItemGEN> iLisIteG = new List<ItemGEN>();
            List<MotivoLiberacion> iLisMotLib = LiberacionRN.ConvertirCampoDetalleMotivoALista(pObj.DetalleMotivoDesechoQali, iLisIteG);
            decimal iCantidadSugerida = LiberacionRN.CantidadMotivoLiberacionSugerida(pObj.CantidadDesechoQali, iLisMotLib);
            if (pObj.CantidadDesechoQali != 0 && iCantidadSugerida != 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Las cantidades en los motivos no suman la cantidad para reprocesar";
            }

            //devolver
            return iLibEN;
        }

        public static void ActualizarCamposDetallePorMontosCeros(ProduccionDetaEN pObj)
        {
            if (pObj.CantidadContraMuestra == 0) { pObj.DetalleMotivoMuestraPreLiberacion = string.Empty; }
            if (pObj.CantidadBloquear == 0) { pObj.DetalleMotivoBloqueadosPreLiberacion = string.Empty; }
        }

        public static void ActualizarCamposAcumuladosPorPrimeraLiberacion(ProduccionDetaEN pObj)
        {
            //traer todas las liberaciones de esta produccion deta
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClaveProduccionDeta(pObj);

            //actualizar los campos acumulados
            pObj.UnidadesReprocesoLiberacion = ListaG.Sumar<LiberacionEN>(iLisLib, LiberacionEN.UniParRep) + pObj.CantidadReprocesoQali;
            pObj.UnidadesDesechasLiberacion = ListaG.Sumar<LiberacionEN>(iLisLib, LiberacionEN.UniDes) + pObj.CantidadDesechoQali;
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaParaConsultaProductoTerminado(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaParaConsultaProductoTerminado(pObj);
        }

        public static void ModificarProduccionDetaPorSalidaAdicionalEncajadoAlAdicionar(string pClaveMovimientoCabe)
        {
            //traer al movimiento cabe de bd
            MovimientoCabeEN iMovDetEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(pClaveMovimientoCabe);

            //desdoblar el campo detalle
            List<string> iLisStrProDet = Cadena.ListarPalabrasDeTexto(iMovDetEN.DetalleProduccionDetaAdicional, "|");

            //recorrer cada cadena
            foreach (string xStrProTer in iLisStrProDet)
            {
                //si la cadena esta vacia,termino el proceso
                if (xStrProTer.Trim() == string.Empty) { break; }

                //desdoblar al texto
                List<string> iLisStr = Cadena.ListarPalabrasDeTexto(xStrProTer, ";");

                //buscar al produccionDeta en bd
                ProduccionDetaEN iProDetEN = BuscarProduccionDetaXClave(iLisStr[0]);

                //actualizar a este objeto,quitandole la cantidad adicional
                iProDetEN.SaldoLiberacion -= Conversion.ADecimal(iLisStr[1], 0);

                //modificaar en bd
                ModificarProduccionDeta(iProDetEN);
            }
        }

        public static void ModificarProduccionDetaPorSalidaAdicionalEncajadoAlEliminar(string pClaveMovimientoCabe)
        {
            //traer al movimiento cabe de bd
            MovimientoCabeEN iMovDetEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(pClaveMovimientoCabe);

            //desdoblar el campo detalle
            List<string> iLisStrProDet = Cadena.ListarPalabrasDeTexto(iMovDetEN.DetalleProduccionDetaAdicional, "|");

            //recorrer cada cadena
            foreach (string xStrProTer in iLisStrProDet)
            {
                //si la cadena esta vacia,termino el proceso
                if (xStrProTer.Trim() == string.Empty) { break; }

                //desdoblar al texto
                List<string> iLisStr = Cadena.ListarPalabrasDeTexto(xStrProTer, ";");

                //buscar al produccionDeta en bd
                ProduccionDetaEN iProDetEN = BuscarProduccionDetaXClave(iLisStr[0]);

                //actualizar a este objeto,quitandole la cantidad adicional
                iProDetEN.SaldoLiberacion += Conversion.ADecimal(iLisStr[1], 0);

                //modificaar en bd
                ModificarProduccionDeta(iProDetEN);
            }
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaConSaldoLiberacion()
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaConSaldoLiberacion();
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaConSaldoLiberacionNew(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaConSaldoLiberacionNew(pObj);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaConSaldoLiberacion(string pCodigoSemiProducto)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaConSaldoLiberacion(pCodigoSemiProducto);
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaSinLiberacion()
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaSinLiberacion();
        }

        public static List<ProduccionDetaEN> ListarProduccionDetaSinLiberacionNew(ProduccionDetaEN pObj)
        {
            ProduccionDetaAD iProAD = new ProduccionDetaAD();
            return iProAD.ListarProduccionDetaSinLiberacionNew(pObj);
        }

        public static void ModificarProduccionDetaAlAdicionarPorAnalisisBloqueado(LiberacionEN pObj)
        {
            //traer a la ProduccionDeta de la b.d           
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj.ClaveProduccionDeta);

            //actualizamos el saldo de unidades bloqueadas,restandolo lo que se esta sacando
            //en este analisis 
            iProDetEN.SaldoLiberacionBloqueadas = iProDetEN.SaldoLiberacionBloqueadas - pObj.CantidadLiberacion;

            //actualizamos el saldo de unidades a packing,sumandola las unidades que se estan
            //aprobando para packing en este analisis
            iProDetEN.SaldoLiberacion = iProDetEN.SaldoLiberacion + pObj.UnidadesPasan;

            //actualizamos la cantidad de unidades para packing que se esta aprobando en este analisis
            //este campo sumara la cantidad de todos los analisis que se creen
            iProDetEN.CantidadUnidadesPackingAdicionalesBlo += pObj.UnidadesPasan;

            //actualizando los totales por produccion
            //iProDetEN.UnidadesAprobadasLiberacion += pObj.UnidadesPasan;
            iProDetEN.UnidadesReprocesoLiberacion += pObj.UnidadesParaReproceso;
            iProDetEN.UnidadesDonacionLiberacion += pObj.UnidadesParaDonacion;
            iProDetEN.UnidadesMuestraLiberacion += pObj.UnidadesParaMuestra;
            iProDetEN.UnidadesDesechasLiberacion += pObj.UnidadesDesechas;
            iProDetEN.UnidadesObservadasLiberacion += pObj.UnidadesObservadas;
            iProDetEN.UnidadesSaldoLiberacion += pObj.UnidadesSaldo;

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarProduccionDetaAlEliminarPorAnalisisBloqueado(LiberacionEN pObj)
        {
            //traer a la ProduccionDeta de la b.d           
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj.ClaveProduccionDeta);

            //traer a la liberacion de la b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pObj);

            //actualizamos el saldo de unidades bloqueadas,sumandolo lo que tiene la liberacion
            //antes de este cambio
            iProDetEN.SaldoLiberacionBloqueadas = iProDetEN.SaldoLiberacionBloqueadas + iLibEN.CantidadLiberacion;

            //actualizamos el saldo de unidades a packing,restandolo lo que tiene la liberacion
            //antes de este cambio
            iProDetEN.SaldoLiberacion = iProDetEN.SaldoLiberacion - iLibEN.UnidadesPasan;

            //actualizamos la cantidad de unidades para packing ,restandolo lo que tiene la liberacion
            //antes de este cambio
            iProDetEN.CantidadUnidadesPackingAdicionalesBlo -= iLibEN.UnidadesPasan;

            //actualizando los totales por produccion
            //iProDetEN.UnidadesAprobadasLiberacion -= iLibEN.UnidadesPasan;
            iProDetEN.UnidadesReprocesoLiberacion -= iLibEN.UnidadesParaReproceso;
            iProDetEN.UnidadesDonacionLiberacion -= iLibEN.UnidadesParaDonacion;
            iProDetEN.UnidadesMuestraLiberacion -= iLibEN.UnidadesParaMuestra;
            iProDetEN.UnidadesDesechasLiberacion -= iLibEN.UnidadesDesechas;
            iProDetEN.UnidadesObservadasLiberacion -= iLibEN.UnidadesObservadas;
            iProDetEN.UnidadesSaldoLiberacion -= iLibEN.UnidadesSaldo;

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ActualizarSaldosYTotalesLiberacion()
        {
            //traer la produccionDeta del rango elegido
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaXRangoFechaProduccion("01/01/2021", "01/01/2022");

            //traer todas las liberaciones de la empresa
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacion();

            //lista liberaciones a modificar en bd
            List<LiberacionEN> iLisLibMod = new List<LiberacionEN>();

            //recorrer cada objeto ProduccionDeta
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //obtener total unidades procesadas
                decimal iUnidadesProcesadas = xProDet.CantidadEncajonar + xProDet.CantidadBloquear + xProDet.CantidadContraMuestra;

                //si sale cero es porque no se distribuye esas cantidades o es una produccion qaliwarma,entonces no se 
                //hace nada a esta produccion
                if (iUnidadesProcesadas == 0) { continue; }

                //limpiar antes de actualizar
                xProDet.SaldoLiberacion = xProDet.CantidadEncajonar;
                xProDet.SaldoLiberacionBloqueadas = xProDet.CantidadBloquear;
                xProDet.CantidadUnidadesPackingAdicionalesBlo = 0;                
                xProDet.UnidadesAprobadasLiberacion = 0;
                xProDet.UnidadesDesechasLiberacion = 0;
                xProDet.UnidadesDonacionLiberacion = 0;
                xProDet.UnidadesMuestraLiberacion = xProDet.CantidadContraMuestra;
                xProDet.UnidadesObservadasLiberacion = 0;
                xProDet.UnidadesReprocesoLiberacion = 0;
                xProDet.UnidadesSaldoLiberacion = 0;
                xProDet.SaldoLiberacionObservadas = 0;
                xProDet.CantidadUnidadesPackingAdicionalesObs = 0;

                //filtrar liberaciones del almacen de semiproductos
                List<LiberacionEN> iLisLibProDet = ListaG.Filtrar<LiberacionEN>(iLisLib, LiberacionEN.ClaProDet, xProDet.ClaveProduccionDeta);

                //listas liberaciones para modificar sus saldos liberacion
                List<LiberacionEN> iLisLibLib = new List<LiberacionEN>();
                List<LiberacionEN> iLisAnaBlo = new List<LiberacionEN>();
                List<LiberacionEN> iLisAnaObs = new List<LiberacionEN>();

                //recorrer cada objeto liberacion
                foreach (LiberacionEN xLib in iLisLibProDet)
                {
                    
                    //si es liberacion de bloqueadas
                    if (xLib.CAlmacenLiberacion == "1")//bloqueadas(observadas)
                    {
                        //liberacion bloqueadas
                        xProDet.SaldoLiberacionBloqueadas -= xLib.CantidadLiberacion;

                        //en las liberaciones de bloqueadas,este campo "UnidadesPasan" son las unidades que pasan a 
                        //packing
                        xProDet.SaldoLiberacion += xLib.UnidadesPasan;

                        //actualizamos el campo que tiene el total de unidades para packing adicionales
                        //que bienen de los analisis bloqueado
                        xProDet.CantidadUnidadesPackingAdicionalesBlo += xLib.UnidadesPasan;

                        //adicionamos analisis bloqueadas
                        iLisAnaBlo.Add(xLib);
                    }
                    else
                    {
                        //observadas(waliwarma)
                        if (xLib.CAlmacenLiberacion == "2")
                        {
                            //liberacion observadas
                            xProDet.SaldoLiberacionObservadas -= xLib.CantidadLiberacion;

                            //en las liberaciones de observadas,este campo "UnidadesPasan" son las unidades que pasan a 
                            //packing
                            xProDet.SaldoLiberacion += xLib.UnidadesPasan;

                            //actualizamos el campo que tiene el total de unidades para packing adicionales
                            //que bienen de los analisis observados
                            xProDet.CantidadUnidadesPackingAdicionalesObs += xLib.UnidadesPasan;

                            //adicionamos analisis observados
                            iLisAnaObs.Add(xLib);
                        }
                        else
                        {
                            //liberaciones packing
                            xProDet.SaldoLiberacion = xProDet.SaldoLiberacion - xLib.CantidadLiberacion + xLib.UnidadesSaldo;

                            //acumular a los totales liberacion
                            xProDet.UnidadesAprobadasLiberacion += xLib.UnidadesPasan;

                            //acumular al saldo liberacion observadas,estan cantidades solo nacen en las
                            //liberaciones de tipo liberacion packing
                            xProDet.SaldoLiberacionObservadas += xLib.UnidadesObservadas;

                            //adicionamos liberaciones
                            iLisLibLib.Add(xLib);
                        }                        
                    }

                    //acumular a los totales liberacion                    
                    xProDet.UnidadesReprocesoLiberacion += xLib.UnidadesParaReproceso;
                    xProDet.UnidadesDonacionLiberacion += xLib.UnidadesParaDonacion;
                    xProDet.UnidadesMuestraLiberacion += xLib.UnidadesParaMuestra;
                    xProDet.UnidadesDesechasLiberacion += xLib.UnidadesDesechas;
                    xProDet.UnidadesObservadasLiberacion += xLib.UnidadesObservadas;
                    xProDet.UnidadesSaldoLiberacion += xLib.UnidadesSaldo;
                }

                //actualizar los saldos liberaciones de estas liberaciones
                LiberacionRN.ActualizarSaldosLiberacion(iLisAnaBlo, xProDet.CantidadBloquear);
                LiberacionRN.ActualizarSaldosLiberacion(iLisAnaObs, xProDet.UnidadesObservadasLiberacion);
                LiberacionRN.ActualizarSaldosLiberacion(iLisLibLib, xProDet.CantidadEncajonar + xProDet.CantidadUnidadesPackingAdicionalesBlo +
                    xProDet.CantidadUnidadesPackingAdicionalesObs);

                //agregar a lista de liberaciones a modificar en bd
                iLisLibMod.AddRange(iLisAnaBlo);
                iLisLibMod.AddRange(iLisAnaObs);
                iLisLibMod.AddRange(iLisLibLib);
            }

            //modificacion masiva
            ProduccionDetaRN.ModificarProduccionDeta(iLisProDet);
            LiberacionRN.ModificarLiberacion(iLisLibMod);
        }

        public static decimal ObtenerCostoMateriaPrimaUnidadTeorica(LiberacionEN pObj)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.CostoMasaPrincipal = pObj.CostoMasaPrincipal;
            iProDetEN.CostoUnidadesReproceso = pObj.CostoUnidadesReproceso;
            iProDetEN.CantidadSinceradoProduccionDeta = pObj.CantidadSinceradoProduccionDeta;

            //calcular
            decimal iCostoUnidad = ObtenerCostoMasaUnidadTeorica(iProDetEN) + ObtenerCostoReprocesoUnidadTeorica(iProDetEN);

            //devolver
            return iCostoUnidad;
        }

        public static decimal ObtenerCostoEnvasadoUnidadTeorica(LiberacionEN pObj)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.CostoConCalPrincipal = pObj.CostoConCalPrincipal;
            iProDetEN.CantidadSinceradoProduccionDeta = pObj.CantidadSinceradoProduccionDeta;

            //calcular
            decimal iCostoUnidad = ObtenerCostoEnvasadoUnidadTeorica(iProDetEN);

            //devolver
            return iCostoUnidad;
        }

        public static decimal ObtenerCostoManoObraUnidadTeorica(LiberacionEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = pObj.CostoManoObra * pObj.CantidadRealProduccion;
            iValor = Operador.DivisionDecimal(iValor, pObj.CantidadSinceradoProduccionDeta);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifUnidadTeorica(LiberacionEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = ObtenerCostoCifFijoUnidadTeorica(pObj) + ObtenerCostoCifVariableUnidadTeorica(pObj);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifFijoUnidadTeorica(LiberacionEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = (pObj.CostoCIFFijo) * pObj.CantidadRealProduccion;
            iValor = Operador.DivisionDecimal(iValor, pObj.CantidadSinceradoProduccionDeta);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoCifVariableUnidadTeorica(LiberacionEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = (pObj.CostoCIFVariable) * pObj.CantidadRealProduccion;
            iValor = Operador.DivisionDecimal(iValor, pObj.CantidadSinceradoProduccionDeta);
            iValor = Math.Round(iValor, 6);

            //devolver
            return iValor;
        }

        public static List<KpiVersus> ObtenerReporteKpiVersus(ProduccionDetaEN pObj)
        {
            //lista resultado
            List<KpiVersus> iLisRes = new List<KpiVersus>();

            //traer la lista para el reporte
            List<ProduccionDetaEN> iLisProDet = ListarProduccionDetaParaReporteCostoLoteFaseEnvasado(pObj);

            //traer los RetiquetadosProTer que tengan referenciados a las Producciones de iLisProTer
            List<RetiquetadoProTerEN> iLisProProTer = RetiquetadoProTerRN.ListarRetiquetadoProTerDeCorrelativosProduccionCabe(iLisProDet);

            //obtener la lista de todos los LoteRetiquetados de iLisProProTer
            List<LoteRetiquetado> iLisLotRet = RetiquetadoProTerRN.ConvertirCamposDetalleCantidadesLoteRetiquetadoALista(iLisProProTer);

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //filtrar solo los LoteRetiquetados de este CorrelativoProCab
                List<LoteRetiquetado> iLisLotRetPro = ListaG.Filtrar<LoteRetiquetado>(iLisLotRet, LoteRetiquetado.CorProCab, xProDet.CorrelativoProduccionCabe);

                //creamos un nuevo objeto
                KpiVersus iKpiVer = new KpiVersus();

                //actualizar campos
                iKpiVer.FechaProductoTerminado = xProDet.FechaProduccionDeta;
                iKpiVer.FechaProceso = xProDet.FechaProduccionDeta;
                iKpiVer.Lote = xProDet.FechaProduccionDeta;
                iKpiVer.Produccion = xProDet.CorrelativoProduccionCabe;
                iKpiVer.Codigo = xProDet.CodigoSemiProducto;
                iKpiVer.Descripcion = xProDet.DescripcionSemiProducto;
                iKpiVer.EnvasadoUniPla = xProDet.CantidadSinceradoProduccionDeta;
                iKpiVer.EnvasadoUniRea = xProDet.CantidadRealProduccion;
                iKpiVer.EnvasadoDif = iKpiVer.EnvasadoUniPla - iKpiVer.EnvasadoUniRea;
                iKpiVer.EnvasadoPor = Operador.Porcentaje(iKpiVer.EnvasadoUniRea, iKpiVer.EnvasadoUniPla, 2);
                iKpiVer.EncajadoUniPla = ObtenerCantidadTotalEncajadoPlanificado(xProDet);
                iKpiVer.EncajadoUniRea = xProDet.UnidadesAprobadasLiberacion;
                iKpiVer.EncajadoDif = iKpiVer.EncajadoUniPla - iKpiVer.EncajadoUniRea;
                iKpiVer.EncajadoPor = Operador.Porcentaje(iKpiVer.EncajadoUniRea, iKpiVer.EncajadoUniPla, 2);
                iKpiVer.RetiquetadoUniPla = ListaG.Sumar<LoteRetiquetado>(iLisLotRetPro, LoteRetiquetado.Can);
                iKpiVer.RetiquetadoUniRea = iKpiVer.RetiquetadoUniPla;
                iKpiVer.RetiquetadoDif = iKpiVer.RetiquetadoUniPla - iKpiVer.RetiquetadoUniRea;
                iKpiVer.RetiquetadoPor = Operador.Porcentaje(iKpiVer.RetiquetadoUniRea, iKpiVer.RetiquetadoUniPla, 2);

                //agregar a la lista resultado
                iLisRes.Add(iKpiVer);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCantidadTotalEncajadoPlanificado(ProduccionDetaEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //primero obtener la cantidad total que puede liberar esta produccion
            decimal iTotalALiberar = pObj.CantidadEncajonar + pObj.CantidadUnidadesPackingAdicionalesBlo;

            //le restamos a esta cantidad total lo que le queda por liberar y sumamos la cantidad devuelta 
            iValor = iTotalALiberar - pObj.SaldoLiberacion + pObj.UnidadesSaldoLiberacion;

            //devolver
            return iValor;
        }

        public static List<DesmedroPT> ObtenerReporteDesmedroPT(ProduccionDetaEN pObj)
        {
            //lista resultado
            List<DesmedroPT> iLisRes = new List<DesmedroPT>();

            //traer la lista para el reporte
            List<ProduccionDetaEN> iLisProDet = ListarProduccionDetaParaReporteCostoLoteFaseEnvasado(pObj);

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //crear un nuevo objeto
                DesmedroPT iDesPT = new DesmedroPT();

                //actualizar campos
                iDesPT.Produccion = xProDet.CorrelativoProduccionCabe;
                iDesPT.FechaProduccion = xProDet.FechaProduccionDeta;
                iDesPT.Descripcion = xProDet.DescripcionSemiProducto;
                iDesPT.Peso = Conversion.GramosAKilogramos(xProDet.MasaUnidad);
                iDesPT.CantidadProducida = xProDet.CantidadRealProduccion;
                iDesPT.TotalDesmedro = xProDet.UnidadesDesechasLiberacion;
                iDesPT.Suma1Reproceso = xProDet.UnidadesReproceso;
                iDesPT.Suma2Reproceso = 0;
                iDesPT.CantidadReprocesoTotal = iDesPT.Suma1Reproceso + iDesPT.Suma2Reproceso;
                iDesPT.TotalNivelDesmedro = iDesPT.TotalDesmedro + iDesPT.CantidadReprocesoTotal;
                iDesPT.PorcentajeDesmedroTotal = Operador.Porcentaje(iDesPT.TotalNivelDesmedro, iDesPT.CantidadProducida);
                iDesPT.CantidadProducidaKg = Math.Round(iDesPT.Peso * iDesPT.CantidadProducida, 2);
                iDesPT.TotalKgReproceso = Math.Round(iDesPT.Peso * iDesPT.CantidadReprocesoTotal, 2);
                iDesPT.TotalKgDesmedro = Math.Round(iDesPT.Peso * iDesPT.TotalDesmedro, 2);
                iDesPT.TotalKgDesmedroPT = Math.Round(iDesPT.Peso * iDesPT.TotalNivelDesmedro, 2);
                iDesPT.PorcentajeDesmedroPTTotal = Operador.Porcentaje(iDesPT.TotalKgDesmedroPT, iDesPT.CantidadProducidaKg);

                //agregar a  la lista resultado
                iLisRes.Add(iDesPT);
            }

            ////obtener objeto totales
            //ProduccionDetaEN iProDetTot = ObtenerObjetoTotalesReporteCostosLoteFaseEnvasado(iLisRes);

            ////agregar a la lista resultado
            //iLisRes.Add(iProDetTot);

            //devolver
            return iLisRes;
        }

        public static void ModificarProduccionDetaAlAdicionarPorAnalisisObservado(LiberacionEN pObj)
        {
            //traer a la ProduccionDeta de la b.d           
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj.ClaveProduccionDeta);

            //actualizamos el saldo de unidades bloqueadas,restandolo lo que se esta sacando
            //en este analisis 
            iProDetEN.SaldoLiberacionObservadas = iProDetEN.SaldoLiberacionObservadas - pObj.CantidadLiberacion;

            //actualizamos el saldo de unidades a packing,sumandola las unidades que se estan
            //aprobando para packing en este analisis
            iProDetEN.SaldoLiberacion = iProDetEN.SaldoLiberacion + pObj.UnidadesPasan;

            //actualizamos la cantidad de unidades para packing que se esta aprobando en este analisis
            //este campo sumara la cantidad de todos los analisis que se creen
            iProDetEN.CantidadUnidadesPackingAdicionalesObs += pObj.UnidadesPasan;

            //actualizando los totales por produccion
            //iProDetEN.UnidadesAprobadasLiberacion += pObj.UnidadesPasan;
            iProDetEN.UnidadesReprocesoLiberacion += pObj.UnidadesParaReproceso;
            iProDetEN.UnidadesDonacionLiberacion += pObj.UnidadesParaDonacion;
            iProDetEN.UnidadesMuestraLiberacion += pObj.UnidadesParaMuestra;
            iProDetEN.UnidadesDesechasLiberacion += pObj.UnidadesDesechas;
            iProDetEN.UnidadesObservadasLiberacion += pObj.UnidadesObservadas;
            iProDetEN.UnidadesSaldoLiberacion += pObj.UnidadesSaldo;

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void ModificarProduccionDetaAlEliminarPorAnalisisObservado(LiberacionEN pObj)
        {
            //traer a la ProduccionDeta de la b.d           
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj.ClaveProduccionDeta);

            //traer a la liberacion de la b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pObj);

            //actualizamos el saldo de unidades bloqueadas,sumandolo lo que tiene la liberacion
            //antes de este cambio
            iProDetEN.SaldoLiberacionObservadas = iProDetEN.SaldoLiberacionObservadas + iLibEN.CantidadLiberacion;

            //actualizamos el saldo de unidades a packing,restandolo lo que tiene la liberacion
            //antes de este cambio
            iProDetEN.SaldoLiberacion = iProDetEN.SaldoLiberacion - iLibEN.UnidadesPasan;

            //actualizamos la cantidad de unidades para packing ,restandolo lo que tiene la liberacion
            //antes de este cambio
            iProDetEN.CantidadUnidadesPackingAdicionalesObs -= iLibEN.UnidadesPasan;

            //actualizando los totales por produccion
            //iProDetEN.UnidadesAprobadasLiberacion -= iLibEN.UnidadesPasan;
            iProDetEN.UnidadesReprocesoLiberacion -= iLibEN.UnidadesParaReproceso;
            iProDetEN.UnidadesDonacionLiberacion -= iLibEN.UnidadesParaDonacion;
            iProDetEN.UnidadesMuestraLiberacion -= iLibEN.UnidadesParaMuestra;
            iProDetEN.UnidadesDesechasLiberacion -= iLibEN.UnidadesDesechas;
            iProDetEN.UnidadesObservadasLiberacion -= iLibEN.UnidadesObservadas;
            iProDetEN.UnidadesSaldoLiberacion -= iLibEN.UnidadesSaldo;

            //ahora el objeto ya esta lista para actualizarse en la b.d
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static ProduccionDetaEN EsActoAnalizarObservados(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();

            //validar si existe
            iProCabEN = ProduccionDetaRN.EsProduccionDetaExistente(pObj);
            if (iProCabEN.Adicionales.EsVerdad == false) { return iProCabEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetDigEN = ProduccionDetaRN.ValidaCuandoNoDigitaUnidadesParaObservar(iProCabEN);
            if (iProDetDigEN.Adicionales.EsVerdad == false) { return iProDetDigEN; }

            //valida cuando genero la salida de insumos
            ProduccionDetaEN iProDetUniSelEN = ProduccionDetaRN.ValidaCuandoNoGeneraIngresosSemiElaboradasObservados(iProCabEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iProCabEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoDigitaUnidadesParaObservar(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            if (pObj.UnidadesObservadasLiberacion == 0)
            {
                iProDetEN.Adicionales.EsVerdad = false;
                iProDetEN.Adicionales.Mensaje = "No hay unidades para Observar, No se puede realizar la operacion";
                return iProDetEN;
            }

            //ok
            return iProDetEN;
        }

        public static ProduccionDetaEN ValidaCuandoNoGeneraIngresosSemiElaboradasObservados(ProduccionDetaEN pObj)
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //valida
            //traer a todas las liberaciones de esta produccion pero solo los del tipo liberacion
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionDeTipoLiberacion(pObj.ClaveProduccionDeta);

            //recorre cada objeto
            foreach (LiberacionEN xLib in iLisLib)
            {
                //si hay una liberacion sin generar el ingreso de unidades observadas al
                //almacen de observadas,entonces detiene la accion
                if (xLib.ClaveIngresoObservadas == string.Empty && xLib.UnidadesObservadas != 0)
                {
                    iProDetEN.Adicionales.EsVerdad = false;
                    iProDetEN.Adicionales.Mensaje = "Debes generar el ingreso de las unidades semi elaboradas Observadas, No se puede realizar la operacion";
                    return iProDetEN;
                }
            }

            //ok
            return iProDetEN;
        }

        public static void ModificarProduccionDetaAlAdicionarIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pObj)
        {
            //traer al proTer de bd
            ProduccionProTerEN iProProTerEN = ProduccionProTerRN.BuscarProduccionProTerXClave(pObj);

            //obtener las liberaciones que estan en este objeto
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(new List<ProduccionProTerEN>{ pObj });
            
            //recorrer cada objeto
            foreach (LiberacionEN xLib in iLisLib)
            {
                //traemos a la produccion de esta liberacion
                ProduccionDetaEN iProDetEN = BuscarProduccionDetaXClave(xLib.ClaveProduccionDeta);

                //incrementamos estas unidades de la liberacion al saldo produccion para que sean tomadas mas adelante
                iProDetEN.SaldoLiberacion += xLib.UnidadesPasan;

                //grabar en bd
                ModificarProduccionDeta(iProDetEN);
            }
        }

        public static void ModificarProduccionDetaAlEliminarIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pObj)
        {
            //traer al proTer de bd
            ProduccionProTerEN iProProTerEN = ProduccionProTerRN.BuscarProduccionProTerXClave(pObj);

            //obtener las liberaciones que estan en este objeto
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionesUsadasEnProduccionesProTer(new List<ProduccionProTerEN> { pObj });

            //recorrer cada objeto
            foreach (LiberacionEN xLib in iLisLib)
            {
                //traemos a la produccion de esta liberacion
                ProduccionDetaEN iProDetEN = BuscarProduccionDetaXClave(xLib.ClaveProduccionDeta);

                //dsecontamos estas unidades de la liberacion al saldo produccion
                iProDetEN.SaldoLiberacion -= xLib.UnidadesPasan;

                //grabar en bd
                ModificarProduccionDeta(iProDetEN);
            }
        }

    }
}
