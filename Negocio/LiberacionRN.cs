using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using System.Data;
using Entidades.Estructuras;
using System.Windows.Forms;

namespace Negocio
{
    public class LiberacionRN
    {

        public static LiberacionEN EnBlanco()
        {
            LiberacionEN iObjEN = new LiberacionEN();
            return iObjEN;
        }

        public static void AdicionarLiberacion(List<LiberacionEN> pLista)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            iObjAD.AdicionarLiberacion(pLista);
        }

        public static void AdicionarLiberacion(LiberacionEN pObj)
        {
            //Asignar parametros
            List<LiberacionEN> iLisObj = new List<LiberacionEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            LiberacionRN.AdicionarLiberacion(iLisObj);
        }

        public static void ModificarLiberacion(List<LiberacionEN> pLista)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            iObjAD.ModificarLiberacion(pLista);
        }

        public static void ModificarLiberacion(LiberacionEN pObj)
        {
            //Asignar parametros
            List<LiberacionEN> iLisObj = new List<LiberacionEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            LiberacionRN.ModificarLiberacion(iLisObj);
        }

        public static void EliminarLiberacion(List<LiberacionEN> pLista)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            iObjAD.EliminarLiberacion(pLista);
        }

        public static void EliminarLiberacion(LiberacionEN pObj)
        {
            //Asignar parametros
            List<LiberacionEN> iLisObj = new List<LiberacionEN>();
            iLisObj.Add(pObj);

            //Ejecutar metodo
            LiberacionRN.EliminarLiberacion(iLisObj);
        }

        public static List<LiberacionEN> ListarLiberacion(LiberacionEN pObj)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacion(pObj);
        }

        public static List<LiberacionEN> ListarLiberacion()
        {
            //asignar parametros
            LiberacionEN iObjEN = new LiberacionEN();
            iObjEN.Adicionales.CampoOrden = LiberacionEN.ClaLib;

            //ejecutar metodo
            return LiberacionRN.ListarLiberacion(iObjEN);
        }

        public static LiberacionEN BuscarLiberacionXClave(LiberacionEN pObj)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.BuscarLiberacionXClave(pObj);
        }

        public static LiberacionEN EsLiberacionExistente(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //validar si existe en b.d
            iObjEN = LiberacionRN.BuscarLiberacionXClave(pObj);
            if (iObjEN.ClaveLiberacion == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static LiberacionEN EsCodigoLiberacionDisponible(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando esta vacio
            if (pObj.ClaveProduccionDeta == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoLiberacion == string.Empty) { return iObjEN; }

            //validar si existe
            iObjEN = LiberacionRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static LiberacionEN ValidaCuandoCodigoYaExiste(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //validar
            iObjEN = LiberacionRN.BuscarLiberacionXClave(pObj);
            if (iObjEN.ClaveLiberacion != string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Este codigo ya existe";
            }

            //ok  
            return iObjEN;
        }

        public static string ObtenerValorDeCampo(LiberacionEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case LiberacionEN.ClaObj: return pObj.ClaveObjeto;
                case LiberacionEN.ClaLib: return pObj.ClaveLiberacion;
                case LiberacionEN.ClaProDet: return pObj.ClaveProduccionDeta;
                case LiberacionEN.CorProCab: return pObj.CorrelativoProduccionCabe;
                case LiberacionEN.FecProDet: return pObj.FechaProduccionDeta;
                case LiberacionEN.CodSemPro: return pObj.CodigoSemiProducto;
                case LiberacionEN.DesSemPro: return pObj.DescripcionSemiProducto;
                case LiberacionEN.CodLib: return pObj.CodigoLiberacion;
                case LiberacionEN.CodEmp: return pObj.CodigoEmpresa;
                case LiberacionEN.FecLib: return pObj.FechaLiberacion;
                case LiberacionEN.PerLib: return pObj.PeriodoLiberacion;
                case LiberacionEN.SalLib: return pObj.SaldoLiberacion.ToString();
                case LiberacionEN.CanLib: return pObj.CantidadLiberacion.ToString();
                case LiberacionEN.UniPas: return pObj.UnidadesPasan.ToString();
                case LiberacionEN.UniParRep: return pObj.UnidadesParaReproceso.ToString();
                case LiberacionEN.UniParDon: return pObj.UnidadesParaDonacion.ToString();
                case LiberacionEN.UniDes: return pObj.UnidadesDesechas.ToString();
                case LiberacionEN.ClaSalTraDes: return pObj.ClaveSalidaTransferenciaDesechas;
                case LiberacionEN.ClaIngTraDes: return pObj.ClaveIngresoTransferenciaDesechas;
                case LiberacionEN.ClaSalTraRep: return pObj.ClaveSalidaTransferenciaReproceso;
                case LiberacionEN.ClaIngTraRep: return pObj.ClaveIngresoTransferenciaReproceso;
                case LiberacionEN.ClaSalTraDon: return pObj.ClaveSalidaTransferenciaDonacion;
                case LiberacionEN.ClaIngTraDon: return pObj.ClaveIngresoTransferenciaDonacion;
                case LiberacionEN.CEstLib: return pObj.CEstadoLiberacion;
                case LiberacionEN.NEstLib: return pObj.NEstadoLiberacion;
                case LiberacionEN.UsuAgr: return pObj.UsuarioAgrega;
                case LiberacionEN.FecAgr: return pObj.FechaAgrega.ToString();
                case LiberacionEN.UsuMod: return pObj.UsuarioModifica;
                case LiberacionEN.FecMod: return pObj.FechaModifica.ToString();

            }

            //retorna
            return iValor;
        }

        public static List<LiberacionEN> FiltrarLiberacionXTextoEnCualquierPosicion(List<LiberacionEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<LiberacionEN> iLisRes = new List<LiberacionEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (LiberacionEN xObj in pLista)
            {
                string iTexto = LiberacionRN.ObtenerValorDeCampo(xObj, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xObj);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<LiberacionEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<LiberacionEN> pLista)
        {
            //lista resultado
            List<LiberacionEN> iLisRes = new List<LiberacionEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pLista; }

            //filtar la lista
            iLisRes = LiberacionRN.FiltrarLiberacionXTextoEnCualquierPosicion(pLista, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveLiberacion(LiberacionEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += pObj.ClaveProduccionDeta + "-";
            iClave += pObj.CodigoLiberacion;

            //retornar
            return iClave;
        }

        public static LiberacionEN EsLiberacionValido(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando esta vacio
            if (pObj.ClaveProduccionDeta == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoLiberacion == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok           
            return iObjEN;
        }

        public static LiberacionEN EsLiberacionActivoValido(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando esta vacio
            if (pObj.ClaveProduccionDeta == string.Empty) { return iObjEN; }

            //valida cuando esta vacio
            if (pObj.CodigoLiberacion == string.Empty) { return iObjEN; }

            //valida cuando el codigo no existe
            iObjEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando esta desactivada
            LiberacionEN iObjDesEN = LiberacionRN.ValidaCuandoEstaDesactivada(iObjEN);
            if (iObjDesEN.Adicionales.EsVerdad == false) { return iObjDesEN; }

            //ok           
            return iObjEN;
        }

        public static LiberacionEN ValidaCuandoEstaDesactivada(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //validar                 
            if (pObj.CEstadoLiberacion == "0")//desactivado
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El(La) Liberacion esta desactivada";
            }

            //ok
            return iObjEN;
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ExisteValorEnColumna(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1, pColumnaCondicion2, pValorCondicion2);
        }

        public static string ObtenerNuevoNumeroLiberacionAutogenerado(LiberacionEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = LiberacionRN.ObtenerMaximoValorEnColumna(LiberacionEN.CodLib, LiberacionEN.ClaProDet, pObj.ClaveProduccionDeta);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 3);

            //devuelve
            return iNumero;
        }

        public static LiberacionEN EsActoAdicionarLiberacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //ok          
            return iObjEN;
        }

        public static LiberacionEN EsActoModificarLiberacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando el codigo no existe
            iObjEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando ya se saco unidades a encajar
            LiberacionEN iLibEmp = ValidaCuandoSeSacoUnidadesAEmpacar(iObjEN);
            if (iLibEmp.Adicionales.EsVerdad == false) { return iLibEmp; }

            //ok          
            return iObjEN;
        }

        public static LiberacionEN ValidaCuandoSeSacoUnidadesAEmpacar(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.CantidadLiberacion != pObj.SaldoUnidadesAEmpacar)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Ya se utilizaron unidades de esta liberacion para empacar ";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN EsActoEliminarLiberacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando el codigo no existe
            iObjEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando ya se saco unidades a encajar
            LiberacionEN iLibEmp = ValidaCuandoSeSacoUnidadesAEmpacar(iObjEN);
            if (iLibEmp.Adicionales.EsVerdad == false) { return iLibEmp; }

            //ok          
            return iObjEN;
        }

        public static LiberacionEN BuscarLiberacion(string pCampo, string pValor, List<LiberacionEN> pLista)
        {
            //objeto resultaddo
            LiberacionEN iObjEN = new LiberacionEN();

            //recorrer cada objeto
            foreach (LiberacionEN xObj in pLista)
            {
                if (LiberacionRN.ObtenerValorDeCampo(xObj, pCampo) == pValor)
                {
                    return xObj;
                }
            }

            //devolver
            return iObjEN;
        }

        public static List<LiberacionEN> ListarLiberacionXClaveProduccionDeta(LiberacionEN pObj)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionXClaveProduccionDeta(pObj);
        }

        public static decimal ObtenerNumeroUnidadesDesecha(LiberacionEN pObj)
        {
            return pObj.CantidadLiberacion - pObj.UnidadesPasan - pObj.UnidadesObservadas - pObj.UnidadesParaReproceso -
                pObj.UnidadesParaDonacion - pObj.UnidadesParaMuestra - pObj.UnidadesSaldo;
        }

        public static LiberacionEN ValidaCuandoUnidadesDesechasEstanEnNegativo(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.UnidadesDesechas < 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "La cantidad de unidades desechas no pueden ser negativo ";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoNoEsActoRegistrarEnPeriodo(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iProCabEN = new LiberacionEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pObj.PeriodoLiberacion;
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iProCabEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iProCabEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iProCabEN;
        }

        public static LiberacionEN EsValidaCantidadLiberada(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.CantidadLiberacion > pObj.SaldoLiberacion)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "La cantidad de unidades a liberar no puede ser mayor al saldo";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN EsActoTransferirUnidadesParaReproceso(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar si existe
            iLibEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iLibEN.Adicionales.EsVerdad == false) { return iLibEN; }

            //valida cuando genero la salida de insumos
            LiberacionEN iLibRepEN = LiberacionRN.ValidaCuandoNoHayUnidadesParaReprocesar(iLibEN);
            if (iLibRepEN.Adicionales.EsVerdad == false) { return iLibRepEN; }

            //ok
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoNoHayUnidadesParaReprocesar(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesParaReproceso == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "No hay unidades para ingresar al almacen de reproceso, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static string ObtenerClaveExistenciaSemiProducto(LiberacionEN pObj)
        {
            //ejecutar metodo y devolver
            return ExistenciaRN.ObtenerClaveExistencia(pObj.CodigoAlmacenSemiProducto, pObj.CodigoSemiProducto);
        }

        public static void ModificarPorTransferenciaReproceso(LiberacionEN pLib)
        {
            //traer al ProduccionDeta de b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pLib);

            //actualizamos los datos            
            iLibEN.ClaveSalidaTransferenciaReproceso = pLib.ClaveSalidaTransferenciaReproceso;
            iLibEN.ClaveIngresoTransferenciaReproceso = pLib.ClaveIngresoTransferenciaReproceso;

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public static LiberacionEN EsActoTransferirUnidadesNoPasan(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar si existe
            iLibEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iLibEN.Adicionales.EsVerdad == false) { return iLibEN; }

            //valida cuando genero la salida de insumos
            LiberacionEN iProDetUniSelEN = LiberacionRN.ValidaCuandoNoHayUnidadesNoPasan(iLibEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoNoHayUnidadesNoPasan(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesDesechas == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "No hay unidades para ingresar al almacen de desechos, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static void ModificarPorTransferenciaObservados(LiberacionEN pLib)
        {
            //traer al ProduccionDeta de b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pLib);

            //actualizamos los datos         
            iLibEN.ClaveIngresoObservadas = pLib.ClaveIngresoObservadas;

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public static void ModificarPorTransferenciaSaldos(LiberacionEN pLib)
        {
            //traer al ProduccionDeta de b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pLib);

            //actualizamos los datos         
            iLibEN.ClaveIngresoSaldo = pLib.ClaveIngresoSaldo;

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public static LiberacionEN EsActoTransferirUnidadesDonacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar si existe
            iLibEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iLibEN.Adicionales.EsVerdad == false) { return iLibEN; }

            //valida cuando genero la salida de insumos
            LiberacionEN iProDetUniSelEN = LiberacionRN.ValidaCuandoNoHayUnidadesDonacion(iLibEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iLibEN;
        }

        public static LiberacionEN EsActoTransferirUnidadesMuestra(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar si existe
            iLibEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iLibEN.Adicionales.EsVerdad == false) { return iLibEN; }

            //valida cuando genero la salida de insumos
            LiberacionEN iProDetUniSelEN = LiberacionRN.ValidaCuandoNoHayUnidadesMuestra(iLibEN);
            if (iProDetUniSelEN.Adicionales.EsVerdad == false) { return iProDetUniSelEN; }

            //ok
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoNoHayUnidadesDonacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesParaDonacion == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "No hay unidades para ingresar al almacen de donacion, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static void ModificarPorTransferenciaDonacion(LiberacionEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pProDet);

            //actualizamos los datos            
            iLibEN.ClaveSalidaTransferenciaDonacion = pProDet.ClaveSalidaTransferenciaDonacion;
            iLibEN.ClaveIngresoTransferenciaDonacion = pProDet.ClaveIngresoTransferenciaDonacion;

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public static void ModificarPorTransferenciaMuestra(LiberacionEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pProDet);

            //actualizamos los datos            
            iLibEN.ClaveSalidaTransferenciaMuestra = pProDet.ClaveSalidaTransferenciaMuestra;
            iLibEN.ClaveIngresoTransferenciaMuestra = pProDet.ClaveIngresoTransferenciaMuestra;

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public static LiberacionEN ValidaCuandoNoHayUnidadesMuestra(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesParaMuestra == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "No hay unidades para ingresar al almacen de muestras, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static List<LiberacionEN> ListarLiberacionParaEmpaquetarXCodigoSemiProducto(string pCodigoSemiProducto, bool pFlagTemporal)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionParaEmpaquetarXCodigoSemiProducto(pCodigoSemiProducto, pFlagTemporal);
        }

        public static List<LiberacionEN> ListarLiberacionParaEmpaquetarXCodigoSemiProducto(ProduccionProTerEN pObj)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pObj);

            //ejecutar metodo
            return LiberacionRN.ListarLiberacionParaEmpaquetarXCodigoSemiProducto(iForDetEN.CodigoSemiProducto, pObj.Adicionales.EsVerdad);
        }

        public static List<LiberacionEN> ListarLiberacionParaEmpaquetar()
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionParaEmpaquetar();
        }

        public static void DescontarUnidadesPorEmpaquetado(List<MovimientoDetaEN> pLisMovDet)
        {
            //listar a todas las liberaciones que se pueden empaquetar
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionParaEmpaquetar();

            //lista de Liberaciones a modificar
            List<LiberacionEN> iLisLibMod = new List<LiberacionEN>();

            //recorrer cada objeto MovimientoDeta
            foreach (MovimientoDetaEN xMovDet in pLisMovDet)
            {
                //listar solo Liberaciones de la existencia del xMovDet
                List<LiberacionEN> iLisLibExi = ListaG.Filtrar<LiberacionEN>(iLisLib, LiberacionEN.CodSemPro, xMovDet.CodigoExistencia);

                //cantidad a salir
                decimal iCantidadASalir = xMovDet.CantidadMovimientoDeta;

                //recorrer cada liberacion
                foreach (LiberacionEN xLib in iLisLibExi)
                {
                    //si la cantidad a salir es cero, entonces salir del foreach
                    if (iCantidadASalir == 0) { break; }

                    //si la cantidad a salir es menor,entonces termina la salida de los lotes
                    if (iCantidadASalir < xLib.SaldoUnidadesAEmpacar)
                    {
                        //actualizamos el lote
                        xLib.SaldoUnidadesAEmpacar -= iCantidadASalir;

                        //ya no hay cantidad a salir
                        iCantidadASalir = 0;
                    }
                    else
                    {
                        //restamos
                        iCantidadASalir -= xLib.SaldoUnidadesAEmpacar;

                        //actualizamos el lote
                        xLib.SaldoUnidadesAEmpacar = 0;
                    }

                    //adicionar a las listas                  
                    iLisLibMod.Add(xLib);
                }
            }

            //actualizar masivo
            LiberacionRN.ModificarLiberacion(iLisLibMod);
        }

        public static List<LiberacionEN> ListarLiberacionXClaveProduccionDeta(ProduccionDetaEN pObj)
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            iLibEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iLibEN.Adicionales.CampoOrden = LiberacionEN.CodLib;

            //ejecutar metodo
            return LiberacionRN.ListarLiberacionXClaveProduccionDeta(iLibEN);
        }

        public static LiberacionEN ValidaCuandoHayUnidadesParaReprocesarSinSuTransferencia(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesParaReproceso != 0 && pObj.ClaveSalidaTransferenciaReproceso == string.Empty)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Debes transferir las unidades para reproceso, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoHayUnidadesDesechasSinSuTransferencia(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesDesechas != 0 && pObj.ClaveSalidaTransferenciaDesechas == string.Empty)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Debes transferir las unidades desechas, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoHayUnidadesDonacionSinSuTransferencia(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesParaDonacion != 0 && pObj.ClaveSalidaTransferenciaDonacion == string.Empty)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Debes transferir las unidades donacion, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static List<LiberacionProTer> ListarLiberacionesDistribucion(List<LiberacionEN> pLisLib, decimal pCantidadADistribuir, int pNumeroDiasVcto)
        {
            //lista de producciones a modificar
            List<LiberacionProTer> iLisRes = new List<LiberacionProTer>();

            //cantidad a salir
            decimal iCantidadASalir = pCantidadADistribuir;

            //recorrer cada objeto Liberacion
            foreach (LiberacionEN xLib in pLisLib)
            {
                //si la cantidad a salir es cero, entonces salir del foreach
                if (iCantidadASalir == 0) { break; }

                //creamos un nuevo objeto
                LiberacionProTer iLibProTer = new LiberacionProTer();

                //pasando datos
                iLibProTer.ClaveLiberacion = xLib.ClaveLiberacion;
                iLibProTer.FechaLote = xLib.FechaProduccionDeta;
                iLibProTer.FechaVcto = LiberacionRN.ObtenerFechaVcto(iLibProTer, pNumeroDiasVcto);
                iLibProTer.CostoTotalProducto = xLib.CostoTotalProducto;
                iLibProTer.FechaProduccionDeta = xLib.FechaProduccionDeta;

                //si la cantidad a salir es menor,entonces termina la salida de los lotes
                if (iCantidadASalir < xLib.SaldoUnidadesAEmpacar)
                {
                    iLibProTer.Cantidad = iCantidadASalir;
                    //xLib.SaldoUnidadesAEmpacar -= iCantidadASalir;

                    //ya no hay cantidad a salir
                    iCantidadASalir = 0;
                }
                else
                {
                    iLibProTer.Cantidad = xLib.SaldoUnidadesAEmpacar;

                    //restamos
                    iCantidadASalir -= xLib.SaldoUnidadesAEmpacar;

                    //actualizamos el lote
                    //xLib.SaldoUnidadesAEmpacar = 0;
                }

                //adicionar a las listas                  
                iLisRes.Add(iLibProTer);
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerFechaVcto(LiberacionProTer pObj, int pNumeroDiasVcto)
        {
            //valor resultado
            string iValor = string.Empty;

            //obtener            
            iValor = Fecha.ObtenerFechaFinal(pObj.FechaLote, pNumeroDiasVcto);
            iValor = Fecha.ObtenerDiaMesAno(iValor);

            //devolver
            return iValor;
        }

        public static List<LiberacionEN> ListarLiberacionXClavesLiberacion(LiberacionEN pObj)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionXClavesLiberacion(pObj);
        }

        public static List<LiberacionEN> ListarLiberacionXClavesLiberacion(List<LiberacionProTer> pLista)
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            iLibEN.ClaveLiberacion = ListaG.ArmarCadenaParaIN<LiberacionProTer>(pLista, LiberacionProTer.ClaLib);
            iLibEN.Adicionales.CampoOrden = LiberacionEN.ClaLib;

            //ejecutar metodo
            return LiberacionRN.ListarLiberacionXClavesLiberacion(iLibEN);
        }

        public static List<LiberacionEN> ListarLiberacionParaEmpaquetarXCodigoSemiProducto(ProduccionProTerEN pObj, bool pAccionAdicionar, List<LiberacionProTer> pLista)
        {
            //si la accion del usuario es una adicion de ProduccionProTer
            if (pAccionAdicionar == true)
            {
                return LiberacionRN.ListarLiberacionParaEmpaquetarXCodigoSemiProducto(pObj);
            }
            else
            {
                //lista resultado
                List<LiberacionEN> iLisRes = new List<LiberacionEN>();

                //cargamos la lista de liberaciones que ya se les bajo el saldo               
                iLisRes.AddRange(LiberacionRN.ListarLiberacionXClavesLiberacion(pLista));

                //cargamos la lista de liberaciones pendientes que hay en bd
                iLisRes.AddRange(LiberacionRN.ListarLiberacionParaEmpaquetarXCodigoSemiProducto(pObj));

                //de esta lista resultados filtramos claves no repetidas
                iLisRes = ListaG.FiltrarObjetosSinRepetir<LiberacionEN>(iLisRes, LiberacionEN.ClaLib);

                //recorrer cada objeto liberacionProTer para ir sumandole otra ves lo que se resto cuando se 
                //adiciono el registro
                foreach (LiberacionEN xLib in iLisRes)
                {
                    //buscamos a su liberacionProTer
                    LiberacionProTer iLibProTerBus = ListaG.Buscar<LiberacionProTer>(pLista, LiberacionProTer.ClaLib, xLib.ClaveLiberacion);

                    //sumamos el saldo
                    xLib.SaldoUnidadesAEmpacar += iLibProTerBus.Cantidad;
                }

                //devolver
                return iLisRes;
            }
        }

        public static void ActualizarSaldosLiberacionPorDevolucionesEncajadoAlAdicionar(ProduccionProTerEN pObj)
        {
            //convertir campo detalle a lista
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(pObj.DetalleCantidadesSemiProducto);

            //traer las liberaciones de esta lista
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClavesLiberacion(iLisLibProTer);

            //cambiar el orden de esta lista
            iLisLib.Reverse();

            //saldo a rebajar
            decimal iSaldo = pObj.CantidadDevueltaEncajado;

            //recorrer cada objeto
            foreach (LiberacionEN xLib in iLisLib)
            {
                //si el saldo es cero, entonces salir del foreach
                if (iSaldo == 0) { break; }

                //buscar a esta liberacion
                LiberacionProTer iLibProTerBus = ListaG.Buscar<LiberacionProTer>(iLisLibProTer, LiberacionProTer.ClaLib, xLib.ClaveLiberacion);

                //calcular
                if (iSaldo > iLibProTerBus.Cantidad)
                {
                    xLib.SaldoUnidadesAEmpacar += iLibProTerBus.Cantidad;
                    iSaldo -= iLibProTerBus.Cantidad;
                }
                else
                {
                    xLib.SaldoUnidadesAEmpacar += iSaldo;
                    iSaldo = 0;
                }
            }

            //modificar masivo
            LiberacionRN.ModificarLiberacion(iLisLib);
        }

        public static void ActualizarSaldosLiberacionPorDevolucionesEncajadoAlEliminar(ProduccionProTerEN pObj)
        {
            //convertir campo detalle a lista
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(pObj.DetalleCantidadesSemiProducto);

            //traer las liberaciones de esta lista
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXClavesLiberacion(iLisLibProTer);

            //traer al ProduccionProTer de bd
            ProduccionProTerEN iProProTerEN = ProduccionProTerRN.BuscarProduccionProTerXClave(pObj);

            //saldo a rebajar
            decimal iSaldo = iProProTerEN.CantidadDevueltaEncajado;

            //recorrer cada objeto
            foreach (LiberacionEN xLib in iLisLib)
            {
                //si el saldo es cero, entonces salir del foreach
                if (iSaldo == 0) { break; }

                //calcular
                if (iSaldo > xLib.SaldoUnidadesAEmpacar)
                {
                    iSaldo -= xLib.SaldoUnidadesAEmpacar;
                    xLib.SaldoUnidadesAEmpacar = 0;

                }
                else
                {
                    xLib.SaldoUnidadesAEmpacar -= iSaldo;
                    iSaldo = 0;
                }
            }

            //modificar masivo
            LiberacionRN.ModificarLiberacion(iLisLib);
        }

        public static void ActualizarSaldosLiberacionPorDevolucionesEncajado(ProduccionProTerEN pObj)
        {
            //primero dejamos toda antes de hacer la modificacion
            LiberacionRN.ActualizarSaldosLiberacionPorDevolucionesEncajadoAlEliminar(pObj);

            //luego volvemos a modificar los saldos
            LiberacionRN.ActualizarSaldosLiberacionPorDevolucionesEncajadoAlAdicionar(pObj);
        }

        public static List<LiberacionEN> ListarLiberacionXPeriodo(LiberacionEN pObj)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionXPeriodo(pObj);
        }

        public static List<LiberacionEN> ListarLiberacionXPeriodo(string pAño, string pCodigoMes)
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            iLibEN.PeriodoLiberacion = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iLibEN.Adicionales.CampoOrden = LiberacionEN.ClaLib;

            //ejecutar metodo
            return LiberacionRN.ListarLiberacionXPeriodo(iLibEN);
        }

        public static LiberacionEN EsValidaFechaLiberacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (Fecha.EsMayorOIgualQue(pObj.FechaLiberacion, pObj.FechaProduccionDeta) == false)
            //if (Fecha.EsMayorQue(pObj.FechaLiberacion, pObj.FechaProduccionDeta) == false)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "La fecha liberacion tiene quer ser igual o mayor a la fecha de produccion";
            }

            //devolver
            return iLibEN;
        }

        public static List<LiberacionEN> ListarLiberacionesUsadasEnProduccionesProTer(List<ProduccionProTerEN> pLista)
        {
            //obtener todas las liberacionesProTer de la pLista
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCamposDetalleCantidadesSemiProductoALista(pLista);

            //filtrar sin repetir clave
            iLisLibProTer = ListaG.FiltrarObjetosSinRepetir<LiberacionProTer>(iLisLibProTer, LiberacionProTer.ClaLib);

            //listar las liberaciones de estas claves
            return ListarLiberacionXClavesLiberacion(iLisLibProTer);
        }

        public static void ModificarSaldoUnidadesAEmpacarInicial(string pAño, string pCodigoMes)
        {
            //traer a todas las liberaciones del mes de proceso
            List<LiberacionEN> iLisLib = ListarLiberacionXPeriodo(pAño, pCodigoMes);

            //recorrer cada objeto
            foreach (LiberacionEN xLib in iLisLib)
            {
                //actualizar el dato
                xLib.SaldoUnidadesAEmpacar = xLib.UnidadesPasan;
            }

            //modificar masivo
            ModificarLiberacion(iLisLib);
        }

        public static List<MotivoLiberacion> ConvertirCampoDetalleMotivoALista(string pDetalleMotivo, List<ItemGEN> pLisMot)
        {
            //lista resultado
            List<MotivoLiberacion> iLisRes = new List<MotivoLiberacion>();

            //---------
            //convertir
            //---------

            //obtener la lista de cadenas que corresponden a cada liberacionProTer
            List<string> iLisForDet = Cadena.ListarPalabrasDeTexto(pDetalleMotivo, "|");

            //recorrer cada cadena
            foreach (string xStr in iLisForDet)
            {
                //si la cadena esta vacia,termino el proceso
                if (xStr.Trim() == string.Empty) { break; }

                //de esta cadena, tambien sacar la lista de cadenas qque corresponden a los campos de MotivoLiberacion
                List<string> iLisCamLibProTer = Cadena.ListarPalabrasDeTexto(xStr, ";");

                //creamos un nuevo objeto LiberacionProTer
                MotivoLiberacion iMotLib = new MotivoLiberacion();

                //pasamos sus datos
                iMotLib.ClaveMotivoLiberacion = iLisCamLibProTer[0];
                if (iLisCamLibProTer.Count == 2)
                {
                    iMotLib.CantidadMotivoLiberacion = Conversion.ADecimal(iLisCamLibProTer[1], 0);
                }


                //creamos un nuevo objeto 
                ItemGEN iIteGEN = ListaG.Buscar<ItemGEN>(pLisMot, ItemGEN.ClaIteG, iMotLib.ClaveMotivoLiberacion);

                //actualizar datos
                iMotLib.CodigoMotivoLiberacion = iIteGEN.CodigoItemG;
                iMotLib.DescripcionMotivoLiberacion = iIteGEN.NombreItemG;
                iMotLib.ClaveObjeto = iMotLib.ClaveMotivoLiberacion;

                //agregar a lista resultado
                iLisRes.Add(iMotLib);
            }

            //devolver
            return iLisRes;
        }

        public static string ConvertirListaACampoDetalleMotivo(List<MotivoLiberacion> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //---------
            //convertir
            //---------

            //recorrer cada objeto
            foreach (MotivoLiberacion xMotLib in pLista)
            {
                iValor += xMotLib.ClaveMotivoLiberacion + ";";
                iValor += xMotLib.CantidadMotivoLiberacion + "|";
            }

            //devolver
            return iValor;
        }

        public static void ActualizarCamposDetallePorMontosCeros(LiberacionEN pObj)
        {
            if (pObj.UnidadesParaReproceso == 0) { pObj.DetalleMotivoReproceso = string.Empty; }
            if (pObj.UnidadesParaDonacion == 0) { pObj.DetalleMotivoDonacion = string.Empty; }
            if (pObj.UnidadesParaMuestra == 0) { pObj.DetalleMotivoMuestra = string.Empty; }
            if (pObj.UnidadesDesechas == 0) { pObj.DetalleMotivoDesecho = string.Empty; }
        }

        public static LiberacionEN ValidaCuandoUnidadesReprocesoNoTieneMotivos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.UnidadesParaReproceso != 0 && pObj.DetalleMotivoReproceso == string.Empty)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Debes registrar los motivos para las unidades a reprocesar";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoUnidadesDonacionNoTieneMotivos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.UnidadesParaDonacion != 0 && pObj.DetalleMotivoDonacion == string.Empty)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Debes registrar los motivos para las unidades a donar";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoUnidadesMuestraNoTieneMotivos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.UnidadesParaMuestra != 0 && pObj.DetalleMotivoMuestra == string.Empty)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Debes registrar los motivos para las unidades a muestra";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoUnidadesDesechaNoTieneMotivos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.UnidadesDesechas != 0 && pObj.DetalleMotivoDesecho == string.Empty)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Debes registrar los motivos para las unidades a desechar";
            }

            //devolver
            return iLibEN;
        }

        public static MotivoLiberacion EnBlancoMotivoLiberacion()
        {
            MotivoLiberacion iObjEN = new MotivoLiberacion();
            return iObjEN;
        }

        public static string ObtenerClaveMotivoLiberacion(MotivoLiberacion pObj)
        {
            //devolver
            return pObj.TipoMotivoLiberacion + "-" + pObj.CodigoMotivoLiberacion;
        }

        public static decimal CantidadMotivoLiberacionSugerida(decimal pCantidadTipoMotivo, List<MotivoLiberacion> pListaMotivosLiberacion)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            decimal iCantidadMotivosSeleccionados = ListaG.Sumar<MotivoLiberacion>(pListaMotivosLiberacion, MotivoLiberacion.CanMotLib);
            iValor = pCantidadTipoMotivo - iCantidadMotivosSeleccionados;

            //devolver
            return iValor;
        }

        public static LiberacionEN ValidaCuandoUnidadesReprocesoNoTieneIgualCantidadUnidadesMotivos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            List<ItemGEN> iLisIteG = new List<ItemGEN>();
            List<MotivoLiberacion> iLisMotLib = ConvertirCampoDetalleMotivoALista(pObj.DetalleMotivoReproceso, iLisIteG);
            decimal iCantidadSugerida = CantidadMotivoLiberacionSugerida(pObj.UnidadesParaReproceso, iLisMotLib);
            if (pObj.UnidadesParaReproceso != 0 && iCantidadSugerida != 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Las cantidades en los motivos no suman la cantidad para reprocesar";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoUnidadesDonacionNoTieneIgualCantidadUnidadesMotivos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            List<ItemGEN> iLisIteG = new List<ItemGEN>();
            List<MotivoLiberacion> iLisMotLib = ConvertirCampoDetalleMotivoALista(pObj.DetalleMotivoDonacion, iLisIteG);
            decimal iCantidadSugerida = CantidadMotivoLiberacionSugerida(pObj.UnidadesParaDonacion, iLisMotLib);
            if (pObj.UnidadesParaDonacion != 0 && iCantidadSugerida != 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Las cantidades en los motivos no suman la cantidad para donacion";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoUnidadesMuestraNoTieneIgualCantidadUnidadesMotivos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            List<ItemGEN> iLisIteG = new List<ItemGEN>();
            List<MotivoLiberacion> iLisMotLib = ConvertirCampoDetalleMotivoALista(pObj.DetalleMotivoMuestra, iLisIteG);
            decimal iCantidadSugerida = CantidadMotivoLiberacionSugerida(pObj.UnidadesParaMuestra, iLisMotLib);
            if (pObj.UnidadesParaMuestra != 0 && iCantidadSugerida != 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Las cantidades en los motivos no suman la cantidad para muestra";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoUnidadesDesechaNoTieneIgualCantidadUnidadesMotivos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            List<ItemGEN> iLisIteG = new List<ItemGEN>();
            List<MotivoLiberacion> iLisMotLib = ConvertirCampoDetalleMotivoALista(pObj.DetalleMotivoDesecho, iLisIteG);
            decimal iCantidadSugerida = CantidadMotivoLiberacionSugerida(pObj.UnidadesDesechas, iLisMotLib);
            if (pObj.UnidadesDesechas != 0 && iCantidadSugerida != 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Las cantidades en los motivos no suman la cantidad para desechos";
            }

            //devolver
            return iLibEN;
        }

        public static List<LiberacionEN> ListarLiberacionesSinMovimientos()
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionesSinMovimientos();
        }

        public static List<LiberacionEN> ListarLiberacionesSinMovimientosNew(LiberacionEN pObj)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionesSinMovimientosNew(pObj);
        }

        public static List<LiberacionEN> ListarProduccionDetaXRangoFechaLiberacion(LiberacionEN pObj)
        {
            LiberacionAD iProAD = new LiberacionAD();
            return iProAD.ListarProduccionDetaXRangoFechaLiberacion(pObj);
        }

        public static List<LiberacionEN> ListarProduccionDetaXRangoFechaLiberacion(string pFechaLiberacionDesde,
            string pFechaLiberacionHasta)
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            iLibEN.Adicionales.Desde1 = pFechaLiberacionDesde;
            iLibEN.Adicionales.Hasta1 = pFechaLiberacionHasta;
            iLibEN.Adicionales.CampoOrden = LiberacionEN.FecLib;

            //ejecutar metodo
            return ListarProduccionDetaXRangoFechaLiberacion(iLibEN);
        }

        public static List<LiberacionEN> ListarProduccionDetaParaReporteCostoLoteClasificacionEncajado(LiberacionEN pObj)
        {
            LiberacionAD iProAD = new LiberacionAD();
            return iProAD.ListarProduccionDetaParaReporteCostoLoteClasificacionEncajado(pObj);
        }

        public static List<LiberacionEN> ObtenerReporteCostoLoteClasificacionEncajado(LiberacionEN pObj)
        {
            //traer la lista para este reporte
            List<LiberacionEN> iLisLib = ListarProduccionDetaParaReporteCostoLoteClasificacionEncajado(pObj);

            //recorrer cada objeto
            foreach (LiberacionEN xLib in iLisLib)
            {
                xLib.CostoTotalEnvasado = ObtenerCostoTotalEnvasado(xLib);
                xLib.PorcentajeLote = ObtenerPorcentajeLote(xLib);
                xLib.PorcentajeAcumulado = ObtenerPorcentajeAcumulado(xLib);
                xLib.CostoUnidadesPasan = ObtenerCostoUnidadesAprobadas(xLib);
                xLib.CostoUnidadesParaReproceso = ObtenerCostoUnidadesReprocesos(xLib);
                xLib.CostoUnidadesDesechas = ObtenerCostoUnidadesDesechadas(xLib);
                xLib.CostoUnidadesParaDonacion = ObtenerCostoUnidadesDonadas(xLib);
                xLib.CostoUnidadesMuestra = ObtenerCostoUnidadesMuestra(xLib);
                xLib.CostoUnidadesObservada = ObtenerCostoUnidadesObservadas(xLib);
                xLib.CostoUnidadesSaldo = ObtenerCostoUnidadesSaldo(xLib);
            }

            //obtener objeto totales
            LiberacionEN iLibTot = ObtenerObjetoTotalesReporteCostosLoteClasificacionEncajado(iLisLib);

            //agregar a la lista resultado
            iLisLib.Add(iLibTot);

            //devolver
            return iLisLib;
        }

        public static decimal ObtenerCostoTotalEnvasado(LiberacionEN pObj)
        {
            return Math.Round(pObj.CostoTotalProducto * pObj.CantidadLiberacion, 2);
        }

        public static decimal ObtenerPorcentajeLote(LiberacionEN pObj)
        {
            //return Math.Round(Operador.DivisionDecimal(pObj.CantidadLiberacion, pObj.CantidadRealProduccion) * 100, 2);
            return Math.Round(Operador.DivisionDecimal(pObj.CantidadLiberacion, pObj.CantidadEncajonar + pObj.CantidadUnidadesPackingAdicionalesBlo) * 100, 2);
        }

        public static decimal ObtenerPorcentajeAcumulado(LiberacionEN pObj)
        {
            //asignar parametros
            //decimal iDividendo = pObj.CantidadRealProduccion - (pObj.SaldoLiberacion - pObj.CantidadLiberacion);
            decimal iDividendo = pObj.CantidadEncajonar + pObj.CantidadUnidadesPackingAdicionalesBlo - (pObj.SaldoLiberacion - pObj.CantidadLiberacion);

            //devolver
            return Math.Round(Operador.DivisionDecimal(iDividendo, pObj.CantidadEncajonar + pObj.CantidadUnidadesPackingAdicionalesBlo) * 100, 2);
        }

        public static decimal ObtenerCostoUnidadesAprobadas(LiberacionEN pObj)
        {
            return Math.Round(pObj.UnidadesPasan * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesReprocesos(LiberacionEN pObj)
        {
            return Math.Round(pObj.UnidadesParaReproceso * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesDesechadas(LiberacionEN pObj)
        {
            return Math.Round(pObj.UnidadesDesechas * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesDonadas(LiberacionEN pObj)
        {
            return Math.Round(pObj.UnidadesParaDonacion * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesMuestra(LiberacionEN pObj)
        {
            return Math.Round(pObj.UnidadesParaMuestra * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesObservadas(LiberacionEN pObj)
        {
            return Math.Round(pObj.UnidadesObservadas * pObj.CostoTotalProducto, 2);
        }

        public static decimal ObtenerCostoUnidadesSaldo(LiberacionEN pObj)
        {
            return Math.Round(pObj.UnidadesSaldo * pObj.CostoTotalProducto, 2);
        }

        public static LiberacionEN ObtenerObjetoTotalesReporteCostosLoteClasificacionEncajado(List<LiberacionEN> pLista)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //obtener la lista acumulada de pLista            
            List<LiberacionEN> iLisProProTerAcu = ListaG.Acumular<LiberacionEN>(pLista, LiberacionEN.CodEmp,
                ObtenerListaCamposAAcumularReporteCostosLoteClasificacionEncajado());

            //si la lista esta vacia
            if (iLisProProTerAcu.Count != 0)
            {
                iLibEN = ObjetoG.Clonar<LiberacionEN>(iLisProProTerAcu[0]);
            }

            //actualizar datos a este objeto
            iLibEN.FechaLiberacion = string.Empty;
            iLibEN.FechaProduccionDeta = string.Empty;
            iLibEN.CorrelativoProduccionCabe = string.Empty;
            iLibEN.CodigoSemiProducto = string.Empty;
            iLibEN.DescripcionSemiProducto = "TOTALES";
            iLibEN.CantidadRealProduccion = 0;
            iLibEN.CantidadLiberacion = 0;
            iLibEN.CantidadEncajonar = 0;
            iLibEN.CantidadUnidadesPackingAdicionalesBlo = 0;
            iLibEN.PorcentajeLote = null;
            iLibEN.PorcentajeAcumulado = 0;
            iLibEN.CostoTotalProducto = 0;
            iLibEN.CostoTotalEnvasado = 0;

            //devolver
            return iLibEN;
        }

        public static List<string> ObtenerListaCamposAAcumularReporteCostosLoteClasificacionEncajado()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //agregar los campos
            iLisRes.Add(LiberacionEN.UniPas);
            iLisRes.Add(LiberacionEN.UniParDon);
            iLisRes.Add(LiberacionEN.UniParRep);
            iLisRes.Add(LiberacionEN.UniDes);
            iLisRes.Add(LiberacionEN.UniParMue);
            iLisRes.Add(LiberacionEN.UniObs);
            iLisRes.Add(LiberacionEN.UniSal);
            iLisRes.Add(LiberacionEN.CosUniPas);
            iLisRes.Add(LiberacionEN.CosUniParDon);
            iLisRes.Add(LiberacionEN.CosUniParRep);
            iLisRes.Add(LiberacionEN.CosUniDes);
            iLisRes.Add(LiberacionEN.CosUniMue);
            iLisRes.Add(LiberacionEN.CosUniObs);
            iLisRes.Add(LiberacionEN.CosUniSal);

            //devolver
            return iLisRes;
        }

        public static string ObtenerCorrelativoProduccionCabe(string pClaveLiberacion)
        {
            return Cadena.ObtenerElemento(pClaveLiberacion, "-", 2);
        }

        public static List<LiberacionEN> ListarLiberacionesUsadasEnRetiquetadosProTer(List<RetiquetadoProTerEN> pLista)
        {
            //obtener todos los RetiquetadosProTer de la pLista
            List<LoteRetiquetado> iLisLibProTer = RetiquetadoProTerRN.ConvertirCamposDetalleCantidadesLoteRetiquetadoALista(pLista);

            //filtrar sin repetir clave
            iLisLibProTer = ListaG.FiltrarObjetosSinRepetir<LoteRetiquetado>(iLisLibProTer, LoteRetiquetado.ClaLib);

            //listar las liberaciones de estas claves
            return ListarLiberacionXClavesLiberacion(iLisLibProTer);
        }

        public static List<LiberacionEN> ListarLiberacionXClavesLiberacion(List<LoteRetiquetado> pLista)
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            iLibEN.ClaveLiberacion = ListaG.ArmarCadenaParaIN<LoteRetiquetado>(pLista, LoteRetiquetado.ClaLib);
            iLibEN.Adicionales.CampoOrden = LiberacionEN.ClaLib;

            //ejecutar metodo
            return LiberacionRN.ListarLiberacionXClavesLiberacion(iLibEN);
        }

        public static List<LiberacionEN> ListarLiberacionXClaveProduccionDetaYCAlmacen(LiberacionEN pObj)
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionXClaveProduccionDetaYCAlmacen(pObj);
        }

        public static decimal ObtenerCantidadSoloDeProductosEnProceso(ProduccionProTerEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //convertir a lista LiberacionProTer
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(pObj.DetalleCantidadesSemiProducto);

            //traer las liberaciones de bd solo de esta lista iLisLibProTer
            List<LiberacionEN> iLisLib = ListarLiberacionesUsadasEnProduccionesProTer(new List<ProduccionProTerEN> { pObj });

            //recorrer cada objeto
            foreach (LiberacionProTer xLibProTer in iLisLibProTer)
            {
                //buscar la liberacion
                LiberacionEN iLibEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                //si es del almacen productos en proceso,entonces suma
                if (iLibEN.CAlmacenLiberacion == "0")
                {
                    iValor += xLibProTer.Cantidad;
                }
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerCantidadSoloDeObservados(ProduccionProTerEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //convertir a lista LiberacionProTer
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(pObj.DetalleCantidadesSemiProducto);

            //traer las liberaciones de bd solo de esta lista iLisLibProTer
            List<LiberacionEN> iLisLib = ListarLiberacionesUsadasEnProduccionesProTer(new List<ProduccionProTerEN> { pObj });

            //recorrer cada objeto
            foreach (LiberacionProTer xLibProTer in iLisLibProTer)
            {
                //buscar la liberacion
                LiberacionEN iLibEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                //si es del almacen de observados,entonces suma
                if (iLibEN.CAlmacenLiberacion == "1")
                {
                    iValor += xLibProTer.Cantidad;
                }
            }

            //devolver
            return iValor;
        }

        public static List<LiberacionEN> ListarLiberacionesDeEncajadoYAlmacenLiberacion(string pCampoDetalleLiberaciones, string pAlmacenLiberacion)
        {
            //lista resultado
            List<LiberacionEN> iLisRes = new List<LiberacionEN>();

            //armar lista de liberaciones ProTer
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(pCampoDetalleLiberaciones);

            //traer la lista de liberaciones de esta lista
            List<LiberacionEN> iLisLib = ListarLiberacionXClavesLiberacion(iLisLibProTer);

            //recorrer cada objeto
            foreach (LiberacionEN xLib in iLisLib)
            {
                if (xLib.CAlmacenLiberacion == pAlmacenLiberacion)
                {
                    iLisRes.Add(xLib);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarPorTransferenciaDesechos(LiberacionEN pLib)
        {
            //traer al ProduccionDeta de b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pLib);

            //actualizamos los datos            
            iLibEN.ClaveSalidaTransferenciaDesechas = pLib.ClaveSalidaTransferenciaDesechas;
            iLibEN.ClaveIngresoTransferenciaDesechas = pLib.ClaveIngresoTransferenciaDesechas;

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public static LiberacionEN EsActoTransferirUnidadesParaObservados(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar si existe
            iLibEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iLibEN.Adicionales.EsVerdad == false) { return iLibEN; }

            //valida cuando genero la salida de insumos
            LiberacionEN iLibRepEN = LiberacionRN.ValidaCuandoNoHayUnidadesParaObservados(iLibEN);
            if (iLibRepEN.Adicionales.EsVerdad == false) { return iLibRepEN; }

            //ok
            return iLibEN;
        }

        public static LiberacionEN EsActoTransferirUnidadesParaSaldos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar si existe
            iLibEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iLibEN.Adicionales.EsVerdad == false) { return iLibEN; }

            //valida cuando genero la salida de insumos
            LiberacionEN iLibRepEN = LiberacionRN.ValidaCuandoNoHayUnidadesParaSaldos(iLibEN);
            if (iLibRepEN.Adicionales.EsVerdad == false) { return iLibRepEN; }

            //ok
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoNoHayUnidadesParaObservados(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesObservadas == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "No hay unidades para ingresar al almacen de observados, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoNoHayUnidadesParaSaldos(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesSaldo == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "No hay unidades para ingresar al almacen de Saldos, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static decimal ObtenerCantidadSoloDeCuarentena(ProduccionProTerEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //convertir a lista LiberacionProTer
            List<LiberacionProTer> iLisLibProTer = ProduccionProTerRN.ConvertirCampoDetalleCantidadesSemiProductoALista(pObj.DetalleCantidadesSemiProducto);

            //traer las liberaciones de bd solo de esta lista iLisLibProTer
            List<LiberacionEN> iLisLib = ListarLiberacionesUsadasEnProduccionesProTer(new List<ProduccionProTerEN> { pObj });

            //recorrer cada objeto
            foreach (LiberacionProTer xLibProTer in iLisLibProTer)
            {
                //buscar la liberacion
                LiberacionEN iLibEN = ListaG.Buscar<LiberacionEN>(iLisLib, LiberacionEN.ClaLib, xLibProTer.ClaveLiberacion);

                //si es del almacen de observados,entonces suma
                if (iLibEN.CAlmacenLiberacion == "2")
                {
                    iValor += xLibProTer.Cantidad;
                }
            }

            //devolver
            return iValor;
        }

        public static string ObtenerCodigoAlmacenParaUnidadesSaldo(LiberacionEN pObj)
        {
            switch (pObj.CAlmacenLiberacion)
            {
                case "0": { return "A11"; }
                case "1": { return "A22"; }
                case "2": { return "A23"; }
                default: { return ""; }
            }
        }

        public static LiberacionEN EsValidaCantidadAAnalizar(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.CantidadLiberacion > pObj.SaldoLiberacion)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "La cantidad de unidades a analizar no puede ser mayor al saldo";
            }

            //devolver
            return iLibEN;
        }

        public static void ModificarPorTransferenciaPacking(LiberacionEN pLib)
        {
            //traer al ProduccionDeta de b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pLib);

            //actualizamos los datos         
            iLibEN.ClaveSalidaTransferenciaPacking = pLib.ClaveSalidaTransferenciaPacking;
            iLibEN.ClaveIngresoTransferenciaPacking = pLib.ClaveIngresoTransferenciaPacking;

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public static LiberacionEN EsActoTransferirUnidadesParaPacking(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar si existe
            iLibEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iLibEN.Adicionales.EsVerdad == false) { return iLibEN; }

            //valida cuando genero la salida de insumos
            LiberacionEN iLibRepEN = LiberacionRN.ValidaCuandoNoHayUnidadesParaPacking(iLibEN);
            if (iLibRepEN.Adicionales.EsVerdad == false) { return iLibRepEN; }

            //ok
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoNoHayUnidadesParaPacking(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //valida
            if (pObj.UnidadesPasan == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "No hay unidades para ingresar al almacen de packing, No se puede realizar la operacion";
            }

            //ok
            return iLibEN;
        }

        public static void ModificarPorTransferenciaDesechas(LiberacionEN pProDet)
        {
            //traer al ProduccionDeta de b.d
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pProDet);

            //actualizamos los datos            
            iLibEN.ClaveSalidaTransferenciaDesechas = pProDet.ClaveSalidaTransferenciaDesechas;
            iLibEN.ClaveIngresoTransferenciaDesechas = pProDet.ClaveIngresoTransferenciaDesechas;

            //modificar en bd
            LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public static LiberacionEN EsActoModificarAnalisisBloqueado(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando el codigo no existe
            iObjEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static LiberacionEN EsActoEliminarAnalisisBloqueado(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando el codigo no existe
            iObjEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }

        public static LiberacionEN EsValidoUnidadesParaPackingAlModificar(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //traer al objeto liberacion de bd
            LiberacionEN iLibEN = BuscarLiberacionXClave(pObj);

            //traer al objeto ProduccionDeta de esta liberacion
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(iLibEN.ClaveProduccionDeta);

            //validar
            //antes de hacer la operacion de modificar el analisis bloqueado,se chequea que saldoLiberacion
            //va a quedar,si este es negativo entonces no se puede realizar la operacion            
            decimal iSaldoLiberacion = iProDetEN.SaldoLiberacion - iLibEN.UnidadesPasan + pObj.UnidadesPasan;
            if (iSaldoLiberacion < 0)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Esta nueva cantidad para packing,hace que el saldo a liberar sea negativo, " + Universal.ErrorMensaje();
            }

            //devolver
            return iObjEN;
        }

        public static LiberacionEN EsValidoSacarUnidadesParaPackingPorEliminacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //traer al objeto liberacion de bd
            LiberacionEN iLibEN = BuscarLiberacionXClave(pObj);
            
            //traer al objeto ProduccionDeta de esta liberacion
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(iLibEN.ClaveProduccionDeta);

            //validar
            //antes de hacer la operacion de eliminar el analisis bloqueado,se chequea que saldoLiberacion
            //va a quedar,si este es negativo entonces no se puede realizar la operacion            
            decimal iSaldoLiberacion = iProDetEN.SaldoLiberacion - iLibEN.UnidadesPasan;
            if (iSaldoLiberacion < 0)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Si eliminas esta cantidad para packing,hace que el saldo a liberar sea negativo, " + Universal.ErrorMensaje();
            }

            //devolver
            return iObjEN;
        }

        public static void ActualizarSaldosLiberacion(List<LiberacionEN> pLista, decimal pCantidadTotal)
        {
            //maneja saldo
            decimal iManejaSaldo = pCantidadTotal;

            //recorrer cada objeto
            foreach (LiberacionEN xLib in pLista)
            {
                xLib.SaldoLiberacion = iManejaSaldo;
                iManejaSaldo = iManejaSaldo - xLib.CantidadLiberacion + xLib.UnidadesSaldo;
            }
        }

        public static List<LiberacionEN> ListarLiberacionAnteriorParaReporteCostoLoteEtapaEncajado(List<LiberacionEN> pLisLib)
        {
            LiberacionAD iProAD = new LiberacionAD();
            return iProAD.ListarLiberacionAnteriorParaReporteCostoLoteEtapaEncajado(pLisLib);
        }

        public static void ModificarSaldosLiberacionPorCambioEnAnalisisBloqueado(LiberacionEN pLibAnaBlo)
        {
            //traer al parte de trabajo
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pLibAnaBlo.ClaveProduccionDeta);

            //traer las liberaciones de este parte de trabajo
            List<LiberacionEN> iLisLib = ListarLiberacionDeTipoLiberacion(iProDetEN.ClaveProduccionDeta);

            //actualizamos el campo saldo liberacion de toda la lista
            ActualizarSaldosLiberacion(iLisLib, iProDetEN.CantidadEncajonar + iProDetEN.CantidadUnidadesPackingAdicionalesBlo +
                iProDetEN.CantidadUnidadesPackingAdicionalesObs);

            //modificar masivo
            ModificarLiberacion(iLisLib);
        }

        public static List<LiberacionEN> ListarLiberacionDeTipoLiberacion(string pClaveProduccionDeta)
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            iLibEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iLibEN.CAlmacenLiberacion = "0";//solo liberacion
            iLibEN.Adicionales.CampoOrden = LiberacionEN.CodLib;

            //ejecutar
            return ListarLiberacionXClaveProduccionDetaYCAlmacen(iLibEN);
        }

        public static bool EsLiberacionDistribuida(LiberacionEN pObj)
        {
            //valor resultado
            bool iValor = true;

            //preguntamos si la suma de cada campo parte es diferente de cero
            decimal iCantidadDist = 0;
            iCantidadDist += pObj.UnidadesPasan;
            iCantidadDist += pObj.UnidadesSaldo;
            iCantidadDist += pObj.UnidadesObservadas;
            iCantidadDist += pObj.UnidadesParaReproceso;
            iCantidadDist += pObj.UnidadesParaDonacion;
            iCantidadDist += pObj.UnidadesParaMuestra;
            iCantidadDist += pObj.UnidadesDesechas;

            //validar
            if (iCantidadDist == 0)
            {
                iValor = false;
            }

            //devolver
            return iValor;
        }

        public static string ObtenerCodigoAlmacenSalidaSegunAlmacenLiberacion(LiberacionEN pObj)
        {
            switch (pObj.CAlmacenLiberacion)
            {
                case "0": { return "A11"; }//ALMACEN SEMIELABORADOS
                case "1": { return "A25"; }//ALMACEN BLOQUEADOS
                case "2": { return "A22"; }//ALMACEN OBSERVADOS
                default: { return ""; }
            }
        }



        public static List<LiberacionEN> ListarLiberacionDeTipoObservadas(string pClaveProduccionDeta)
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            iLibEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iLibEN.CAlmacenLiberacion = "2";//solo observadas
            iLibEN.Adicionales.CampoOrden = LiberacionEN.CodLib;

            //ejecutar
            return ListarLiberacionXClaveProduccionDetaYCAlmacen(iLibEN);
        }

        public static void ModificarSaldoLiberacionDeLiberacionObservadas(string pClaveProduccionDeta)
        {
            //traer al parte de trabajo
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pClaveProduccionDeta);

            //traer a las liberaciones de tipo observadas de esta produccion
            List<LiberacionEN> iLisLib = ListarLiberacionDeTipoObservadas(pClaveProduccionDeta);

            //actualizamos el campo saldo liberacion de toda la lista
            ActualizarSaldosLiberacion(iLisLib, iProDetEN.UnidadesObservadasLiberacion);

            //modificar masivo
            ModificarLiberacion(iLisLib);
        }

        public static LiberacionEN EsValidoUnidadesObservadasAlModificar(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //traer al objeto liberacion de bd
            LiberacionEN iLibEN = BuscarLiberacionXClave(pObj);

            //traer al objeto ProduccionDeta de esta liberacion
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(iLibEN.ClaveProduccionDeta);

            //validar
            //antes de hacer la operacion de modificar la liberacion,se chequea que saldoLiberacionObservadas
            //va a quedar,si este es negativo entonces no se puede realizar la operacion            
            decimal iSaldoLiberacionObservadas = iProDetEN.SaldoLiberacionObservadas - iLibEN.UnidadesObservadas + pObj.UnidadesObservadas;
            if (iSaldoLiberacionObservadas < 0)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Esta nueva cantidad de unidades observadas,hace que el saldo a liberar de observadas sea negativo, " + Universal.ErrorMensaje();
            }

            //devolver
            return iObjEN;
        }

        public static LiberacionEN EsValidoSacarUnidadesObservadasPorEliminacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //traer al objeto liberacion de bd
            LiberacionEN iLibEN = BuscarLiberacionXClave(pObj);

            //traer al objeto ProduccionDeta de esta liberacion
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(iLibEN.ClaveProduccionDeta);

            //validar
            //antes de hacer la operacion de eliminar la liberacion,se chequea que saldoLiberacionObservadas
            //va a quedar,si este es negativo entonces no se puede realizar la operacion            
            decimal iSaldoLiberacionObservadas = iProDetEN.SaldoLiberacionObservadas - iLibEN.UnidadesObservadas;
            if (iSaldoLiberacionObservadas < 0)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "Si eliminas esta cantidad de unidades observadas,hace que el saldo a liberar de observadas sea negativo, " +
                    Universal.ErrorMensaje();
            }

            //devolver
            return iObjEN;
        }




        public static LiberacionEN ValidaCuandoUnidadesObservadasEstanEnNegativo(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar            
            if (pObj.UnidadesObservadas < 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "La cantidad de unidades observadas no pueden ser negativo ";
            }

            //devolver
            return iLibEN;
        }

        public static decimal ObtenerNumeroUnidadesObservadas(LiberacionEN pObj)
        {
            return pObj.CantidadLiberacion - pObj.UnidadesPasan - pObj.UnidadesSaldo;
        }

        public static LiberacionEN EsActoModificarLiberacionPorProduccion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando el codigo no existe
            iObjEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando ya se saco unidades a encajar
            LiberacionEN iLibEmp = ValidaCuandoCalidadYaDistribuyoLaLiberacion(iObjEN);
            if (iLibEmp.Adicionales.EsVerdad == false) { return iLibEmp; }


            //ok          
            return iObjEN;
        }

        public static LiberacionEN ValidaCuandoCalidadYaDistribuyoLaLiberacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar    
            decimal iSuma = pObj.UnidadesParaReproceso + pObj.UnidadesParaMuestra + pObj.UnidadesParaDonacion + pObj.UnidadesDesechas;
            
            //si esta suma da cero,quiere decir que el usuario de calidad no ha distribuido la liberacion        
            if (iSuma != 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "El usuario de calidad ya distribuyo,para poder modificar esta pantalla,el usuario calidad debe ";
                iLibEN.Adicionales.Mensaje += "devolver el #Unidades Observadas como lo dejo el usuario de produccion";
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN EsActoModificarLiberacionPorCalidad(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iObjEN = new LiberacionEN();

            //valida cuando el codigo no existe
            iObjEN = LiberacionRN.EsLiberacionExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //valida cuando produccion no distribuye
            LiberacionEN iLibEmp = ValidaCuandoProduccionNoDistribuyeLaLiberacion(iObjEN);
            if (iLibEmp.Adicionales.EsVerdad == false) { return iLibEmp; }

            //valida cuando no hay nada que distribuir
            LiberacionEN iLibNoDist = ValidaCuandoCalidadNoTieneNadaQueDistribuir(iObjEN);
            if (iLibNoDist.Adicionales.EsVerdad == false) { return iLibNoDist; }

            //ok          
            return iObjEN;
        }

        public static LiberacionEN ValidaCuandoProduccionNoDistribuyeLaLiberacion(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar    
            decimal iSuma = pObj.UnidadesPasan + pObj.UnidadesSaldo + pObj.UnidadesObservadas;

            //si esta suma da cero,quiere decir que el usuario de produccion no ha distribuido la liberacion        
            if (iSuma == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "Primero tiene que distribuir el usuario de produccion";                
            }

            //devolver
            return iLibEN;
        }

        public static LiberacionEN ValidaCuandoCalidadNoTieneNadaQueDistribuir(LiberacionEN pObj)
        {
            //objeto resultado
            LiberacionEN iLibEN = new LiberacionEN();

            //validar          
            if (pObj.UnidadesObservadas == 0)
            {
                iLibEN.Adicionales.EsVerdad = false;
                iLibEN.Adicionales.Mensaje = "No hay unidades para distribuir";
            }

            //devolver
            return iLibEN;
        }



    }
}
