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
    public class ExistenciaRN
    {

        public static ExistenciaEN EnBlanco()
        {
            ExistenciaEN iExiEN = new ExistenciaEN();
            return iExiEN;
        }

        public static void AdicionarExistencia(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            iPerAD.AgregarExistencia(pObj);
        }

        public static void AdicionarExistencia(List<ExistenciaEN> pLista)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            iPerAD.AgregarExistencia(pLista);
        }

        public static void ModificarExistencia(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            iPerAD.ModificarExistencia(pObj);
        }

        public static void ModificarExistencia(List<ExistenciaEN> pLista)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            iPerAD.ModificarExistencia(pLista);
        }

        public static void ModificarExistenciaPorRecalculo(List<ExistenciaEN> pLista)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            iPerAD.ModificarExistenciaPorRecalculo(pLista);
        }

        public static void EliminarExistencia(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            iPerAD.EliminarExistencia(pObj);
        }

        public static void EliminarExistencia(List<ExistenciaEN> pLista)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            iPerAD.EliminarExistencia(pLista);
        }

        public static List<ExistenciaEN> ListarExistencias(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ListarExistencias(pObj);
        }

        public static List<ExistenciaEN> ListarExistencias()
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.Adicionales.CampoOrden = ExistenciaEN.ClaExi;

            //ejecutar metodo
            return ExistenciaRN.ListarExistencias(iExiEN);
        }

        public static ExistenciaEN BuscarExistenciaXClave(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.BuscarExistenciaXClave(pObj);
        }

        public static ExistenciaEN EsExistenciaExistente(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar si existe en b.d
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(pObj);
            if (iExiEN.ClaveExistencia == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoExistencia + " en el almacen " +
                                            pObj.DescripcionAlmacen + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static ExistenciaEN EsCodigoExistenciaDisponible(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando esta vacio
            if (pObj.CodigoAlmacen == string.Empty) { return iExiEN; }

            //validar que los dos campos esten llenos
            iExiEN = ExistenciaRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoCodigoYaExiste(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar     
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(pObj);
            if (iExiEN.CodigoExistencia != string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoExistencia + " en el almacen " +
                                            pObj.DescripcionAlmacen + " ya existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(ExistenciaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case ExistenciaEN.ClaObj: return pObj.ClaveObjeto;
                case ExistenciaEN.ClaExi: return pObj.ClaveExistencia;
                case ExistenciaEN.CodEmp: return pObj.CodigoEmpresa;
                case ExistenciaEN.CodAlm: return pObj.CodigoAlmacen;
                case ExistenciaEN.DesAlm: return pObj.DescripcionAlmacen;
                case ExistenciaEN.CodExi: return pObj.CodigoExistencia;
                case ExistenciaEN.DesExi: return pObj.DescripcionExistencia;
                case ExistenciaEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case ExistenciaEN.NomUniMed: return pObj.NombreUnidadMedida;
                case ExistenciaEN.CCodUbi: return pObj.CCodigoUbicacion;
                case ExistenciaEN.NCodUbi: return pObj.NCodigoUbicacion;
                case ExistenciaEN.CodTip: return pObj.CodigoTipo;
                case ExistenciaEN.NomTip: return pObj.NombreTipo;
                case ExistenciaEN.CodGru: return pObj.CodigoGrupo;
                case ExistenciaEN.NomGru: return pObj.NombreGrupo;
                case ExistenciaEN.CEsPro: return pObj.CEsProduccion;
                case ExistenciaEN.NEsPro: return pObj.NEsProduccion;
                case ExistenciaEN.ConExi: return pObj.ContableExistencia;
                case ExistenciaEN.CodAre: return pObj.CodigoArea;
                case ExistenciaEN.NomAre: return pObj.NombreArea;
                case ExistenciaEN.AmbExi: return pObj.AmbienteExistencia;
                case ExistenciaEN.CodMar: return pObj.CodigoMarca;
                case ExistenciaEN.NomMar: return pObj.NombreMarca;
                case ExistenciaEN.ModExi: return pObj.ModeloExistencia;
                case ExistenciaEN.SerExi: return pObj.SerieExistencia;
                case ExistenciaEN.MedExi: return pObj.MedidasExistencia;
                case ExistenciaEN.CodCol: return pObj.CodigoColor;
                case ExistenciaEN.NomCol: return pObj.NombreColor;
                case ExistenciaEN.StoMinExi: return pObj.StockMinimoExistencia.ToString();
                case ExistenciaEN.StoTomExi: return pObj.StockTomaExistencia.ToString();
                case ExistenciaEN.StoIniExi: return pObj.StockInicialExistencia.ToString();
                case ExistenciaEN.StoActExi: return pObj.StockActualExistencia.ToString();
                case ExistenciaEN.PreIniExi: return pObj.PrecioInicialExistencia.ToString();
                case ExistenciaEN.PreProExi: return pObj.PrecioPromedioExistencia.ToString();
                case ExistenciaEN.CodCat: return pObj.CodigoCatalogo;
                case ExistenciaEN.NomCat: return pObj.NombreCatalogo;
                case ExistenciaEN.CEstExi: return pObj.CEstadoExistencia;
                case ExistenciaEN.NEstExi: return pObj.CodigoExistencia;
                case ExistenciaEN.UsuAgr: return pObj.UsuarioAgrega;
                case ExistenciaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case ExistenciaEN.UsuMod: return pObj.UsuarioModifica;
                case ExistenciaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<ExistenciaEN> FiltrarExistenciasXTextoEnCualquierPosicion(List<ExistenciaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (ExistenciaEN xPer in pLista)
            {
                string iTexto = ExistenciaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<ExistenciaEN> pListaExistencias)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaExistencias; }

            //filtar la lista
            iLisRes = ExistenciaRN.FiltrarExistenciasXTextoEnCualquierPosicion(pListaExistencias, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveExistencia(ExistenciaEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoExistencia;

            //retornar
            return iClave;
        }

        public static string ObtenerClaveExistencia(string pCodigoAlmacen, string pCodigoExistencia)
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pCodigoAlmacen;
            iExiEN.CodigoExistencia = pCodigoExistencia;

            //retornar
            return ExistenciaRN.ObtenerClaveExistencia(iExiEN);
        }

        public static ExistenciaEN EsActoModificarExistencia(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar si existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static ExistenciaEN EsActoEliminarExistencia(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar si existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida si existen esta existencia en Formula cabe
            ExistenciaEN iExiForCabEN = ExistenciaRN.ValidaCuandoCodigoExistenciaEstaEnFormulaCabe(iExiEN);
            if (iExiForCabEN.Adicionales.EsVerdad == false) { return iExiForCabEN; }

            //valida si existen esta existencia en MovimientoDeta
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoExistenciaEstaEnMovimientoDeta(iExiEN);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //ok            
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoCodigoExistenciaEstaEnMovimientoDeta(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida
            bool iExisten = MovimientoOCDetaRN.ExisteValorEnColumnaConEmpresa(MovimientoOCDetaEN.CodExi, pObj.CodigoExistencia,
                                                                    MovimientoOCDetaEN.CodAlm, pObj.CodigoAlmacen);
            if (iExisten == true)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "Esta Existencia tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
                return iExiEN;
            }

            //ok
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoCodigoExistenciaEstaEnFormulaCabe(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida
            //como este codigo puede encontrarse en dos campos de la tabla FormulaCabe, entonces vamos a validar
            //uno por uno,primero al campo CodigoExistencia
            bool iExisten = FormulaCabeRN.ExisteValorEnColumnaConEmpresa(FormulaCabeEN.CodExi, pObj.CodigoExistencia,
                                                                    FormulaCabeEN.CodAlm, pObj.CodigoAlmacen);

            //segundo al campo CodigoExistenciaSemPro
            bool iExisten1 = FormulaCabeRN.ExisteValorEnColumnaConEmpresa(FormulaCabeEN.CodSemPro, pObj.CodigoExistencia,
                                                                    FormulaCabeEN.CodAlmSemPro, pObj.CodigoAlmacen);

            //si cualquiera de ellos es true ,entonces se ejecuta la validacion
            if (iExisten == true || iExisten1 == true)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "Esta Existencia esta referencia en Formula(s), no se puede realizar la operacion";
                return iExiEN;
            }

            //ok
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasDeAlmacen(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ListarExistenciasDeAlmacen(pObj);
        }

        public static List<ExistenciaEN> ListarExistenciasDeAlmacen(string pCodigoAlmacen)
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pCodigoAlmacen;
            iExiEN.Adicionales.CampoOrden = ExistenciaEN.ClaExi;

            //ejecutar metodo
            return ExistenciaRN.ListarExistenciasDeAlmacen(iExiEN);
        }

        public static ExistenciaEN EsExistenciaValido(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //ok           
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasParaCopiarAAlmacen(string pCodigoAlmacenCopia, string pCodigoAlmacenGuarda)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //listar las existencias del almacen de donde se quiere copiar
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pCodigoAlmacenCopia;
            iExiEN.Adicionales.CampoOrden = ExistenciaEN.CodExi;
            List<ExistenciaEN> iLisExiCop = ExistenciaRN.ListarExistenciasDeAlmacen(iExiEN);

            //listar las existencias del almacen a donde se quiere copiar
            iExiEN.CodigoAlmacen = pCodigoAlmacenGuarda;
            List<ExistenciaEN> iLisExiGua = ExistenciaRN.ListarExistenciasDeAlmacen(iExiEN);

            //obtener las existencias que tiene la lista iLisExiCop que no esten en iLisExiGua
            iLisRes = ExistenciaRN.ObtenerDiferenciaAMenosB(iLisExiCop, iLisExiGua);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ObtenerDiferenciaAMenosB(List<ExistenciaEN> pLisExiA, List<ExistenciaEN> pLisExiB)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //recorrer cada objeto
            foreach (ExistenciaEN xExiA in pLisExiA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (ExistenciaEN xExiB in pLisExiB)
                {
                    if (xExiA.CodigoExistencia == xExiB.CodigoExistencia)
                    {
                        iEncontrado = 1;
                    }
                }

                //si no se encontro se agrega a la lista resultado
                if (iEncontrado == 0)
                {
                    iLisRes.Add(xExiA);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarVerdadFalsoExistencia(ExistenciaEN pObj, List<ExistenciaEN> pLista)
        {
            //lista actualizada
            List<ExistenciaEN> iLisExi = new List<ExistenciaEN>();

            //buscamos el objeto en la lista pLista
            foreach (ExistenciaEN xExi in pLista)
            {
                if (xExi.ClaveExistencia == pObj.ClaveExistencia)
                {
                    xExi.VerdadFalso = pObj.VerdadFalso;
                }
                iLisExi.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisExi);
        }

        public static List<ExistenciaEN> ListarExistenciasSoloMarcadas(List<ExistenciaEN> pLista)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (ExistenciaEN xExi in pLista)
            {
                if (xExi.VerdadFalso == true)
                {
                    iLisRes.Add(xExi);
                }
            }
            return iLisRes;
        }

        public static ExistenciaEN HayObjetosMarcados(List<ExistenciaEN> pLista)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //sacar las cuotas solo marcadas
            List<ExistenciaEN> iLisExiMar = ExistenciaRN.ListarExistenciasSoloMarcadas(pLista);

            //si la lista esta vacia entonces no hay marcados
            if (iLisExiMar.Count == 0)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "No hay existencias marcados, no se puede realizar la operacion";
                return iExiEN;
            }
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void AdicionarExistenciasPorCopia(string pCodigoAlmacenGuarda, List<ExistenciaEN> pLisExiMar, List<ExistenciaEN> pLisExiVal)
        {
            //lista de existencias para adicionar
            List<ExistenciaEN> iLisExiAdi = new List<ExistenciaEN>();

            //lista de saldos para adicionar
            List<SaldoEN> iLisSalAdi = new List<SaldoEN>();

            //traemos todos los años distintos que hay en periodos de la empresa de acceso
            List<string> iLisAñoPer = PeriodoRN.ListarAñosPeriodos();

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLisExiMar)
            {
                //para poder adicionar al objeto xExi, este debe existir en la lista de
                //existencias que son validas a grabar en bd(pLisExiVal)
                bool iExiste = ExistenciaRN.ExisteCodigoExistenciaEnLista(xExi.CodigoExistencia, pLisExiVal);
                if (iExiste == false) { continue; }

                //modificar datos
                xExi.CodigoAlmacen = pCodigoAlmacenGuarda;
                xExi.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(xExi);
                xExi.CCodigoUbicacion = string.Empty;
                xExi.StockMinimoExistencia = 0;
                xExi.StockTomaExistencia = 0;
                xExi.StockInicialExistencia = 0;
                xExi.StockActualExistencia = 0;
                xExi.PrecioInicialExistencia = 0;
                xExi.PrecioPromedioExistencia = 0;

                //agregar a la lista resultado
                iLisExiAdi.Add(xExi);

                //creamos una lista con todos los saldos para esta existencia
                List<SaldoEN> iLisSalExiEN = SaldoRN.ListarNuevosSaldosAExistencia(xExi, iLisAñoPer);

                //agregamos a la lista resultado
                iLisSalAdi.AddRange(iLisSalExiEN);
            }

            //luego adicionamos todas las existencias en bd
            ExistenciaRN.AdicionarExistencia(iLisExiAdi);

            //luego adicionamos todos los saldos en b.d
            SaldoRN.AdicionarSaldo(iLisSalAdi);
        }

        public static bool ExisteCodigoExistenciaEnLista(string pCodigoExistencia, List<ExistenciaEN> pLista)
        {
            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                if (pCodigoExistencia == xExi.CodigoExistencia)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static void MarcarTodos(List<ExistenciaEN> pLista, bool pVerdadFalso)
        {
            //lista actualizada
            List<ExistenciaEN> iLisExi = new List<ExistenciaEN>();

            //buscamos el objeto en la lista pLista
            foreach (ExistenciaEN xExi in pLista)
            {
                xExi.VerdadFalso = pVerdadFalso;
                iLisExi.Add(xExi);
            }

            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisExi);
        }

        public static List<ExistenciaEN> ListarExistenciasParaEliminarDeAlmacen(string pCodigoAlmacen)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //listar las existencias del almacen de donde se quiere eliminar
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pCodigoAlmacen;
            iExiEN.Adicionales.CampoOrden = ExistenciaEN.CodExi;
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistenciasDeAlmacen(iExiEN);

            //obtener en una tabla , todos los codigos de existencias del almacen en proceso
            //que ya tengan movimiento
            DataTable iTblCodExi = ExistenciaRN.ListarCodigosExistenciaDeAlmacenUsadosEnMovimientos(iExiEN);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExi)
            {
                //valida si esta existencia ya tiene movimiento
                bool iExiste = MiDataTable.ExisteValor(iTblCodExi, ExistenciaEN.CodExi, xExi.CodigoExistencia);
                if (iExiste == true) { continue; }

                //adicionar a la lista resultado
                iLisRes.Add(xExi);
            }

            //devolver
            return iLisRes;
        }

        public static DataTable ListarCodigosExistenciaDeAlmacenUsadosEnMovimientos(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ListarCodigosExistenciaDeAlmacenUsadosEnMovimientos(pObj);
        }

        public static void EliminarExistenciasDeAlmacen(List<ExistenciaEN> pLisExiMar, List<ExistenciaEN> pLisExiVal)
        {
            //lista de existencias para eliminar
            List<ExistenciaEN> iLisExiEli = new List<ExistenciaEN>();

            //lista de saldos a eliminar
            List<SaldoEN> iLisSalEli = new List<SaldoEN>();

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLisExiMar)
            {
                //para poder eliminar al objeto xExi, este debe existir en la lista de
                //existencias que son validas a grabar en bd(pLisExiVal)
                bool iExiste = ExistenciaRN.ExisteCodigoExistenciaEnLista(xExi.CodigoExistencia, pLisExiVal);
                if (iExiste == false) { continue; }

                //agregar a la lista resultado
                iLisExiEli.Add(xExi);

                //creamos su objeto saldo para esta existencia
                SaldoEN iSalEN = SaldoRN.CrearSaldoDeExistencia(xExi);

                //agregamos a la lista resultado
                iLisSalEli.Add(iSalEN);
            }

            //luego eliminamos todas las existencias en bd
            ExistenciaRN.EliminarExistencia(iLisExiEli);

            //luego eliminamos todos los saldos en bd
            SaldoRN.EliminarSaldo(iLisSalEli);
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static bool ExisteClaveExistenciaEnLista(string pClaveExistencia, List<ExistenciaEN> pLista)
        {
            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                if (pClaveExistencia == xExi.ClaveExistencia)
                {
                    return true;
                }
            }

            //devolver
            return false;
        }

        public static ExistenciaEN BuscarExistenciaXClave(string pClaveExistencia, List<ExistenciaEN> pLista)
        {
            //objeto resultaddo
            ExistenciaEN iExiEN = new ExistenciaEN();

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                if (pClaveExistencia == xExi.ClaveExistencia)
                {
                    return xExi;
                }
            }

            //devolver
            return iExiEN;
        }

        public static void ActualizarExistenciasPorAdicionMovimientosDeta(List<MovimientoDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<ExistenciaEN> iLisExi = MovimientoDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(pLisMovDet);

            //ejecutar metodo
            ExistenciaRN.ModificarExistencia(iLisExi);
        }

        public static void ActualizarExistenciasPorAdicionMovimientosDetaOC(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<ExistenciaEN> iLisExi = MovimientoOCDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(pLisMovDet);

            //ejecutar metodo
            ExistenciaRN.ModificarExistencia(iLisExi);
        }


        public static List<ExistenciaEN> ListarExistenciasAlmacenNoSeleccionadasEnGrilla(string pCodigoAlmacen, List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasAlmacenNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaValido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
            string pCodigoExistenciaFranjaGrilla, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaValidoOC(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
    string pCodigoExistenciaFranjaGrilla, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaOC(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoCodigoYaExisteEnGrilla(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
            string pCodigoExistenciaFranjaGrilla, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar     
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.BuscarMovimientoDeta(MovimientoDetaEN.CodExi, pObj.CodigoExistencia, pLisMovDetGrilla);
            if (iMovDetEN.CodigoExistencia != string.Empty)
            {
                if (pOperacionVentana == Universal.Opera.Adicionar || (pOperacionVentana == Universal.Opera.Modificar && iMovDetEN.CodigoExistencia != pCodigoExistenciaFranjaGrilla))
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Esta existencia ya se registro en la grilla";
                    return iExiEN;
                }
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoCodigoYaExisteEnGrillaOC(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
    string pCodigoExistenciaFranjaGrilla, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar     
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.BuscarMovimientoDeta(MovimientoOCDetaEN.CodExi, pObj.CodigoExistencia, pLisMovDetGrilla);
            if (iMovDetEN.CodigoExistencia != string.Empty)
            {
                if (pOperacionVentana == Universal.Opera.Adicionar || (pOperacionVentana == Universal.Opera.Modificar && iMovDetEN.CodigoExistencia != pCodigoExistenciaFranjaGrilla))
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Esta existencia ya se registro en la grilla";
                    return iExiEN;
                }
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoCodigoYaExisteEnGrillaSolPedido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
    string pCodigoExistenciaFranjaGrilla, List<SolicitudPedidoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar     
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.BuscarSolicitudPedidoDeta(SolicitudPedidoDetaEN.CodExi, pObj.CodigoExistencia, pLisMovDetGrilla);
            if (iMovDetEN.CodigoExistencia != string.Empty)
            {
                if (pOperacionVentana == Universal.Opera.Adicionar || (pOperacionVentana == Universal.Opera.Modificar && iMovDetEN.CodigoExistencia != pCodigoExistenciaFranjaGrilla))
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Esta existencia ya se registro en la grilla";
                    return iExiEN;
                }
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasNoProduccionDeAlmacenNoSeleccionadasEnGrilla(string pCodigoAlmacen, List<FormulaDetaEN> pLisForDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si es existencia de produccion, entonces no avanza
                if (xExi.CEsProduccion == "1") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (FormulaDetaEN xForDet in pLisForDet)
                {
                    if (xExi.CodigoExistencia == xForDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaValido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
           string pCodigoExistenciaFranjaGrilla, List<FormulaDetaEN> pLisForDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisForDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoExistenciaEsProduccion(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar                 
            if (pObj.CEsProduccion == "1")//si produccion
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo" + pObj.CodigoExistencia + " en el almacen " + pObj.DescripcionAlmacen;
                iExiEN.Adicionales.Mensaje += " es de produccion";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoCodigoYaExisteEnGrilla(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
          string pCodigoExistenciaFranjaGrilla, List<FormulaDetaEN> pLisForDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar     
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDeta(FormulaDetaEN.CodExi, pObj.CodigoExistencia, pLisForDetGrilla);
            if (iForDetEN.CodigoExistencia != string.Empty)
            {
                if (pOperacionVentana == Universal.Opera.Adicionar || (pOperacionVentana == Universal.Opera.Modificar && iForDetEN.CodigoExistencia != pCodigoExistenciaFranjaGrilla))
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Esta existencia ya se registro en la grilla";
                    return iExiEN;
                }
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasParaGrabarAFormula(string pCodigoAlmacen)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacen);

            //traer todas las formulas de b.d en el almacen en proceso
            List<FormulaCabeEN> iLisForCabEN = FormulaCabeRN.ListarFormulaCabeEnAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si no es existencia de produccion, entonces no avanza
                if (xExi.CEsProduccion == "0") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (FormulaCabeEN xForCab in iLisForCabEN)
                {
                    if (xExi.CodigoExistencia == xForCab.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaDeProduccionValido(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia no es de produccion
            ExistenciaEN iExiSiProEN = ExistenciaRN.ValidaCuandoExistenciaNoEsProduccion(iExiEN);
            if (iExiSiProEN.Adicionales.EsVerdad == false) { return iExiSiProEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoExistenciaNoEsProduccion(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar                 
            if (pObj.CEsProduccion == "0")//no produccion
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "La existencia no es de produccion, no se puede realizar la operacion";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasAlmacenNoSeleccionadasEnGrillaTransferencia(string pCodigoAlmacenSalida, string pCodigoAlmacenIngreso, List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen de salida que no estan seleccionadas en la grilla
            List<ExistenciaEN> iLisExiAlmSal = ExistenciaRN.ListarExistenciasAlmacenNoSeleccionadasEnGrilla(pCodigoAlmacenSalida, pLisMovDet);

            //traer todas las existencias del almacen de ingreso
            List<ExistenciaEN> iLisExiAlmIng = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacenIngreso);

            //sacamos solo las existencias que estan en iLisExiAlmSal y en iLisExiAlmIng
            iLisRes = ExistenciaRN.ObtenerAInterseccionB(iLisExiAlmSal, iLisExiAlmIng);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasAlmacenNoSeleccionadasEnGrillaTransferenciaOC(string pCodigoAlmacenSalida, string pCodigoAlmacenIngreso, List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen de salida que no estan seleccionadas en la grilla
            List<ExistenciaEN> iLisExiAlmSal = ExistenciaRN.ListarExistenciasAlmacenNoSeleccionadasEnGrillaOC(pCodigoAlmacenSalida, pLisMovDet);

            //traer todas las existencias del almacen de ingreso
            List<ExistenciaEN> iLisExiAlmIng = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacenIngreso);

            //sacamos solo las existencias que estan en iLisExiAlmSal y en iLisExiAlmIng
            iLisRes = ExistenciaRN.ObtenerAInterseccionB(iLisExiAlmSal, iLisExiAlmIng);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ObtenerAInterseccionB(List<ExistenciaEN> pLisExiA, List<ExistenciaEN> pLisExiB)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //recorrer cada objeto
            foreach (ExistenciaEN xExiA in pLisExiA)
            {
                //flag de encontrado
                int iEncontrado = 0;

                //recorre cada objeto
                foreach (ExistenciaEN xExiB in pLisExiB)
                {
                    if (xExiA.CodigoExistencia == xExiB.CodigoExistencia)
                    {
                        iEncontrado = 1;
                    }
                }

                //si no se encontro se agrega a la lista resultado
                if (iEncontrado == 1)
                {
                    iLisRes.Add(xExiA);
                }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaValido(ExistenciaEN pExiSalida, ExistenciaEN pExiIngreso, Universal.Opera pOperacionVentana,
          string pCodigoExistenciaFranjaGrilla, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pExiSalida.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pExiSalida);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando el codigo de ingreso no existe en el almacen de ingreso
            ExistenciaEN iExiAlmEN = ExistenciaRN.EsExistenciaExistente(pExiIngreso);
            if (iExiAlmEN.Adicionales.EsVerdad == false) { return iExiAlmEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaValidoOC(ExistenciaEN pExiSalida, ExistenciaEN pExiIngreso, Universal.Opera pOperacionVentana,
  string pCodigoExistenciaFranjaGrilla, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pExiSalida.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pExiSalida);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando el codigo de ingreso no existe en el almacen de ingreso
            ExistenciaEN iExiAlmEN = ExistenciaRN.EsExistenciaExistente(pExiIngreso);
            if (iExiAlmEN.Adicionales.EsVerdad == false) { return iExiAlmEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaOC(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //ok           
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasNoProduccionDeAlmacenNoSeleccionadasEnGrilla(string pCodigoAlmacen, List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si es existencia de produccion, entonces no avanza
                if (xExi.CEsProduccion == "1") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasNoProduccionDeAlmacenNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si es existencia de produccion, entonces no avanza
                if (xExi.CEsProduccion == "1") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static void ActualizarExistenciasPorEliminacionMovimientosDeta(List<MovimientoDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<ExistenciaEN> iLisExi = MovimientoDetaRN.ListarExistenciasActualizadasPorEliminacionMovimientosDeta(pLisMovDet);

            //ejecutar metodo
            ExistenciaRN.ModificarExistencia(iLisExi);
        }

        public static void ActualizarExistenciasPorEliminacionMovimientosDetaOC(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<ExistenciaEN> iLisExi = MovimientoOCDetaRN.ListarExistenciasActualizadasPorEliminacionMovimientosDeta(pLisMovDet);

            //ejecutar metodo
            ExistenciaRN.ModificarExistencia(iLisExi);
        }

        public static void ActualizarExistenciasPorEliminacion(string pClaveMovimientoCabe)
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(pClaveMovimientoCabe);

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDeta(iLisMovDet);
        }

        public static void ActualizarExistenciasPorEliminacionOC(string pClaveMovimientoCabe)
        {
            //asignar parametros
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(pClaveMovimientoCabe);

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDetaOC(iLisMovDet);
        }

        public static List<ExistenciaEN> ListarExistenciasActivasDeAlmacen(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ListarExistenciasActivasDeAlmacen(pObj);
        }

        public static List<ExistenciaEN> ListarExistenciasActivasDeAlmacen(string pCodigoAlmacen)
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pCodigoAlmacen;
            iExiEN.Adicionales.CampoOrden = ExistenciaEN.ClaExi;

            //ejecutar metodo
            return ExistenciaRN.ListarExistenciasActivasDeAlmacen(iExiEN);
        }

        public static List<ExistenciaEN> ListarExistenciasActivasDeAlmacen(string pCodigoAlmacen, string pOrdenListado)
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pCodigoAlmacen;
            iExiEN.Adicionales.CampoOrden = pOrdenListado;

            //ejecutar metodo
            return ExistenciaRN.ListarExistenciasActivasDeAlmacen(iExiEN);
        }

        public static List<ExistenciaEN> ListarExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasEnGrilla(string pCodigoAlmacen, List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si es existencia de produccion, entonces no avanza
                if (xExi.CEsProduccion == "1") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si es existencia de produccion, entonces no avanza
                if (xExi.CEsProduccion == "1") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasEnGrillaSolPedido(string pCodigoAlmacen, List<SolicitudPedidoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si es existencia de produccion, entonces no avanza
                if (xExi.CEsProduccion == "1") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (SolicitudPedidoDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaActivoValido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
           string pCodigoExistenciaFranjaGrilla, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaActivoValidoOC(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
   string pCodigoExistenciaFranjaGrilla, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaOC(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoEstaDesactivada(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar                 
            if (pObj.CEstadoExistencia == "0")//desactivado
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoExistencia + " en el almacen " + pObj.DescripcionAlmacen;
                iExiEN.Adicionales.Mensaje += " esta desactivado";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasActivasAlmacenNoSeleccionadasEnGrillaTransferencia(string pCodigoAlmacenSalida, string pCodigoAlmacenIngreso, List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen de salida que no estan seleccionadas en la grilla
            List<ExistenciaEN> iLisExiAlmSal = ExistenciaRN.ListarExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasEnGrilla(pCodigoAlmacenSalida, pLisMovDet);

            //traer todas las existencias del almacen de ingreso
            List<ExistenciaEN> iLisExiAlmIng = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacenIngreso);

            //sacamos solo las existencias que estan en iLisExiAlmSal y en iLisExiAlmIng
            iLisRes = ExistenciaRN.ObtenerAInterseccionB(iLisExiAlmSal, iLisExiAlmIng);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasActivasAlmacenNoSeleccionadasEnGrillaTransferenciaOC(string pCodigoAlmacenSalida, string pCodigoAlmacenIngreso, List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen de salida que no estan seleccionadas en la grilla
            List<ExistenciaEN> iLisExiAlmSal = ExistenciaRN.ListarExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasEnGrillaOC(pCodigoAlmacenSalida, pLisMovDet);

            //traer todas las existencias del almacen de ingreso
            List<ExistenciaEN> iLisExiAlmIng = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacenIngreso);

            //sacamos solo las existencias que estan en iLisExiAlmSal y en iLisExiAlmIng
            iLisRes = ExistenciaRN.ObtenerAInterseccionB(iLisExiAlmSal, iLisExiAlmIng);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasActivasAlmacenNoSeleccionadasEnGrilla(string pCodigoAlmacen, List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }


        public static List<ExistenciaEN> ListarExistenciasActivasAlmacenNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaActivoValido(ExistenciaEN pExiSalida, ExistenciaEN pExiIngreso, Universal.Opera pOperacionVentana,
          string pCodigoExistenciaFranjaGrilla, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pExiSalida.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pExiSalida);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo de ingreso no existe en el almacen de ingreso
            ExistenciaEN iExiAlmEN = ExistenciaRN.EsExistenciaExistente(pExiIngreso);
            if (iExiAlmEN.Adicionales.EsVerdad == false) { return iExiAlmEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesIngEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiAlmEN);
            if (iExiDesIngEN.Adicionales.EsVerdad == false) { return iExiDesIngEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProIngEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiAlmEN);
            if (iExiNoProIngEN.Adicionales.EsVerdad == false) { return iExiNoProIngEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando una de las existencias es de manejo lote y el otro no
            ExistenciaEN iExiManLotEN = ExistenciaRN.ValidaCuandoManejanLote(iExiEN, iExiAlmEN);
            if (iExiManLotEN.Adicionales.EsVerdad == false) { return iExiManLotEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaActivoValidoOC(ExistenciaEN pExiSalida, ExistenciaEN pExiIngreso, Universal.Opera pOperacionVentana,
  string pCodigoExistenciaFranjaGrilla, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pExiSalida.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pExiSalida);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo de ingreso no existe en el almacen de ingreso
            ExistenciaEN iExiAlmEN = ExistenciaRN.EsExistenciaExistente(pExiIngreso);
            if (iExiAlmEN.Adicionales.EsVerdad == false) { return iExiAlmEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesIngEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiAlmEN);
            if (iExiDesIngEN.Adicionales.EsVerdad == false) { return iExiDesIngEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProIngEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiAlmEN);
            if (iExiNoProIngEN.Adicionales.EsVerdad == false) { return iExiNoProIngEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaOC(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando una de las existencias es de manejo lote y el otro no
            ExistenciaEN iExiManLotEN = ExistenciaRN.ValidaCuandoManejanLote(iExiEN, iExiAlmEN);
            if (iExiManLotEN.Adicionales.EsVerdad == false) { return iExiManLotEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoManejanLote(ExistenciaEN pExiSal, ExistenciaEN pExiIng)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar                 
            if (pExiSal.CEsLote == "1" && pExiIng.CEsLote == "0")
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo " + pExiSal.CodigoExistencia + " en el almacen " + pExiSal.DescripcionAlmacen;
                iExiEN.Adicionales.Mensaje += " maneja lote y el codigo " + pExiIng.CodigoExistencia + " en el almacen ";
                iExiEN.Adicionales.Mensaje += pExiIng.DescripcionAlmacen + " no";
                return iExiEN;
            }

            if (pExiSal.CEsLote == "0" && pExiIng.CEsLote == "1")
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo " + pExiIng.CodigoExistencia + " en el almacen " + pExiIng.DescripcionAlmacen;
                iExiEN.Adicionales.Mensaje += " maneja lote y el codigo " + pExiSal.CodigoExistencia + " en el almacen ";
                iExiEN.Adicionales.Mensaje += pExiSal.DescripcionAlmacen + " no";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasParaExistenciasGeneralesPorAlmacen(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ListarExistenciasParaExistenciasGeneralesPorAlmacen(pObj);
        }

        public static List<ExistenciaGeneralDeta> ObtenerReporteExistenciaGeneralDetallePorAlmacen(ExistenciaEN pObj)
        {
            //lista resultado
            List<ExistenciaGeneralDeta> iLisRes = new List<ExistenciaGeneralDeta>();

            //traer la lista para existencias generales
            pObj.Adicionales.CampoOrden = ExistenciaEN.CodExi;
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistenciasParaExistenciasGeneralesPorAlmacen(pObj);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExi)
            {
                //crear un nuevo objeto ExistenciaGeneralDeta
                ExistenciaGeneralDeta iExiGenDet = new ExistenciaGeneralDeta();

                //pasamos datos
                iExiGenDet.CodigoTipo = xExi.CodigoTipo;
                iExiGenDet.NombreTipo = xExi.NombreTipo;
                iExiGenDet.CodigoExistencia = xExi.CodigoExistencia;
                iExiGenDet.DescripcionExistencia = xExi.DescripcionExistencia;
                iExiGenDet.CodigoUnidadMedida = xExi.CodigoUnidadMedida;
                iExiGenDet.NombreUnidadMedida = xExi.NombreUnidadMedida;
                iExiGenDet.Ubicacion = xExi.CCodigoUbicacion;
                iExiGenDet.Stock = xExi.StockActualExistencia;
                iExiGenDet.PrecioUnitario = xExi.PrecioPromedioExistencia;
                iExiGenDet.Total = xExi.StockActualExistencia * xExi.PrecioPromedioExistencia;

                //adicionar a la ista resultado
                iLisRes.Add(iExiGenDet);

            }

            //devolver
            return iLisRes;
        }

        public static List<List<ExistenciaEN>> ListarExistenciasParaExistenciasGeneralesConsolidado(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ListarExistenciasParaExistenciasGeneralesConsolidado(pObj);
        }

        public static List<ExistenciaGeneralDeta> ObtenerReporteExistenciaGeneralDetalleConsolidado(ExistenciaEN pObj)
        {
            //lista resultado
            List<ExistenciaGeneralDeta> iLisRes = new List<ExistenciaGeneralDeta>();

            //traer la lista para existencias generales
            pObj.Adicionales.CampoOrden = ExistenciaEN.CodExi;
            List<List<ExistenciaEN>> iLisLisExi = ExistenciaRN.ListarExistenciasParaExistenciasGeneralesConsolidado(pObj);

            //recorrer cada objeto
            foreach (List<ExistenciaEN> xLisExi in iLisLisExi)
            {
                //obtenemos al primer objeto de la lista
                ExistenciaEN iExiEN = xLisExi[0];

                //creamos un objeto ExistenciaGeneralDeta
                ExistenciaGeneralDeta iExiGenDet = new ExistenciaGeneralDeta();

                //pasamos datos
                iExiGenDet.CodigoTipo = iExiEN.CodigoTipo;
                iExiGenDet.NombreTipo = iExiEN.NombreTipo;
                iExiGenDet.CodigoExistencia = iExiEN.CodigoExistencia;
                iExiGenDet.DescripcionExistencia = iExiEN.DescripcionExistencia;
                iExiGenDet.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
                iExiGenDet.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
                iExiGenDet.Ubicacion = string.Empty;
                iExiGenDet.Stock = ExistenciaRN.SumarStock(xLisExi);
                iExiGenDet.PrecioUnitario = ExistenciaRN.ObtenerPrecioPromedio(xLisExi);
                iExiGenDet.Total = iExiGenDet.Stock * iExiGenDet.PrecioUnitario;

                //adicionar a la ista resultado
                iLisRes.Add(iExiGenDet);
            }

            //devolver
            return iLisRes;
        }

        public static decimal SumarStock(List<ExistenciaEN> pLista)
        {
            //valor resultado
            decimal iValor = 0;

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                iValor += xExi.StockActualExistencia;
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerPrecioPromedio(List<ExistenciaEN> pLista)
        {
            //valor resultado
            decimal iValor = 0;

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                iValor += xExi.StockActualExistencia * xExi.PrecioPromedioExistencia;
            }

            //ahora calcular el precio promedio
            iValor = Operador.DivisionDecimal(iValor, ExistenciaRN.SumarStock(pLista));

            //redondear a 2 decimales
            iValor = Math.Round(iValor, 2);

            //devolver
            return iValor;
        }

        public static List<ExistenciaGeneralDeta> ObtenerReporteExistenciaGeneralDetalle(ExistenciaEN pObj)
        {
            if (pObj.CodigoAlmacen == string.Empty)
            {
                return ExistenciaRN.ObtenerReporteExistenciaGeneralDetalleConsolidado(pObj);
            }
            else
            {
                return ExistenciaRN.ObtenerReporteExistenciaGeneralDetallePorAlmacen(pObj);
            }
        }

        public static List<ExistenciaEN> ListarExistenciasParaExistenciasGeneralesResumen(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ListarExistenciasParaExistenciasGeneralesResumen(pObj);
        }

        public static List<ExistenciaGeneralResu> ObtenerReporteExistenciaGeneralResumen(ExistenciaEN pObj)
        {
            //lista resultado
            List<ExistenciaGeneralResu> iLisRes = new List<ExistenciaGeneralResu>();

            //traer la lista de existencias generales para resusmen
            pObj.Adicionales.CampoOrden = ExistenciaEN.CodTip;
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistenciasParaExistenciasGeneralesResumen(pObj);

            //variables
            string iCodigoTipo = string.Empty;
            int iIndiceObjeto = -1;

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExi)
            {
                if (xExi.CodigoTipo != iCodigoTipo)
                {
                    //creamos un nuevo objeto 
                    ExistenciaGeneralResu iExiGenRes = new ExistenciaGeneralResu();
                    iExiGenRes.CodigoTipo = xExi.CodigoTipo;
                    iExiGenRes.NombreTipo = xExi.NombreTipo;
                    iExiGenRes.Cantidad = xExi.StockActualExistencia;
                    iExiGenRes.Importe = ExistenciaRN.ObtenerImporte(xExi.StockActualExistencia, xExi.PrecioPromedioExistencia);
                    iExiGenRes.NumeroItem = 1;

                    //agregamos a la lista resultado
                    iLisRes.Add(iExiGenRes);

                    //actualizamos variables
                    iCodigoTipo = xExi.CodigoTipo;
                    iIndiceObjeto++;
                }
                else
                {
                    iLisRes[iIndiceObjeto].Cantidad += xExi.StockActualExistencia;
                    iLisRes[iIndiceObjeto].Importe += ExistenciaRN.ObtenerImporte(xExi.StockActualExistencia, xExi.PrecioPromedioExistencia);
                    iLisRes[iIndiceObjeto].NumeroItem++;
                }
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerImporte(decimal pStock, decimal pPrecioPromedio)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            iValor = pStock * pPrecioPromedio;

            //redondear a 2 decimales
            iValor = Math.Round(iValor, 2);

            //devolver
            return iValor;
        }

        public static List<ExistenciaEN> ListarExistenciasActivasDeAlmacenNoSeleccionadasEnGrilla(string pCodigoAlmacen, List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasActivasDeAlmacenNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
                {
                    if (xExi.CodigoExistencia == xMovDet.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaActivoNoProduccionValido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
          string pCodigoExistenciaFranjaGrilla, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaActivoNoProduccionValidoOC(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
  string pCodigoExistenciaFranjaGrilla, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaOC(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaActivoNoProduccionValidoSolPedido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
          string pCodigoExistenciaFranjaGrilla, List<SolicitudPedidoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaSolPedido(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //ok           
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasNoProduccionNoGrabadasEnFormula(string pCodigoAlmacen)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacen);

            //traer todas las formulas de b.d en el almacen en proceso
            List<FormulaCabeEN> iLisForCabEN = FormulaCabeRN.ListarFormulaCabe();

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si es existencia de produccion, entonces no avanza
                if (xExi.CEsProduccion == "1") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (FormulaCabeEN xForCab in iLisForCabEN)
                {
                    if (xExi.CodigoExistencia == xForCab.CodigoSemiProducto)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaDeNoProduccionValido(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia no es de produccion
            ExistenciaEN iExiSiProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiSiProEN.Adicionales.EsVerdad == false) { return iExiSiProEN; }

            //ok           
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasParaAlertaStockMinimo(List<ExistenciaEN> pListaExistenciaEmpresa)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //recorrer a todas las existencias de la empresa
            foreach (ExistenciaEN xExi in pListaExistenciaEmpresa)
            {
                //validar si son existencias de produccion
                if (xExi.CEsProduccion == "1") { continue; }

                //validar si no es existencia para alertar por stock minimo
                if (xExi.StockActualExistencia > xExi.StockMinimoExistencia) { continue; }

                //adicionar a la lista resultado
                iLisRes.Add(xExi);
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasParaAlertaStockMinimo()
        {
            //asignar parametros
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //ejecutar metodo
            return ExistenciaRN.ListarExistenciasParaAlertaStockMinimo(iLisExiEmp);
        }

        public static ExistenciaEN HayExistenciasParaAlarmaStockMinimo()
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistenciasParaAlertaStockMinimo();
            if (iLisExi.Count == 0)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "No hay existencias para alarma de stock minimo";
            }

            //devolver
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasProductosTerminadosActivosDeAlmacen(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ListarExistenciasProductosTerminadosActivosDeAlmacen(pObj);
        }

        public static ExistenciaEN EsExistenciaProductoTerminadoActivoValido(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia no es de produccion
            ExistenciaEN iExiProTerEN = ExistenciaRN.ValidaCuandoExistenciaNoEsProductoTerminado(iExiEN);
            if (iExiProTerEN.Adicionales.EsVerdad == false) { return iExiProTerEN; }

            //valida cuando no es activo
            ExistenciaEN iExiActEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiActEN.Adicionales.EsVerdad == false) { return iExiActEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoExistenciaNoEsProductoTerminado(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar                 
            if (pObj.CodigoTipo != "PT")//producto terminado
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El codigo" + pObj.CodigoExistencia + " en el almacen " + pObj.DescripcionAlmacen;
                iExiEN.Adicionales.Mensaje += " no es un producto terminado";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasDeFormulaNoSeleccionadasEnGrilla(string pCodigoAlmacen, string pClaveFormulaCabe,
            List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen y no esten en la grilla de movimientos
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasAlmacenNoSeleccionadasEnGrilla(pCodigoAlmacen, pLisMovDet);

            //traer a los formulasDeta de esta claveFormulaCabe
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(pClaveFormulaCabe);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //si es de otro almacen, continua al siguiente objeto
                //if (xForDet.CodigoAlmacen != pCodigoAlmacen) { continue; }

                //validar si existe el codigoExistencia de la formula en la lista de existencias
                ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiAlm, ExistenciaEN.CodExi, xForDet.CodigoExistencia);

                //si no fue encontrado ,continua al siguiente objeto
                if (iExiBusEN.CodigoExistencia == string.Empty) { continue; }

                //aqui si lo encontro , adicionamos a la lista resultado
                iLisRes.Add(iExiBusEN);
            }


            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasDeFormulaNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, string pClaveFormulaCabe,
            List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen y no esten en la grilla de movimientos
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasAlmacenNoSeleccionadasEnGrillaOC(pCodigoAlmacen, pLisMovDet);

            //traer a los formulasDeta de esta claveFormulaCabe
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(pClaveFormulaCabe);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //si es de otro almacen, continua al siguiente objeto
                //if (xForDet.CodigoAlmacen != pCodigoAlmacen) { continue; }

                //validar si existe el codigoExistencia de la formula en la lista de existencias
                ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiAlm, ExistenciaEN.CodExi, xForDet.CodigoExistencia);

                //si no fue encontrado ,continua al siguiente objeto
                if (iExiBusEN.CodigoExistencia == string.Empty) { continue; }

                //aqui si lo encontro , adicionamos a la lista resultado
                iLisRes.Add(iExiBusEN);
            }


            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaActivoNoProduccionValido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
         string pCodigoExistenciaFranjaGrilla, string pClaveFormulaCabe, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //valida cuando la existencia no esta en la formula
            ExistenciaEN iExiForEN = ExistenciaRN.ValidaCuandoExistenciaNoEsDeFormula(pClaveFormulaCabe, iExiEN);
            if (iExiForEN.Adicionales.EsVerdad == false) { return iExiForEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaActivoNoProduccionValidoOC(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
   string pCodigoExistenciaFranjaGrilla, string pClaveFormulaCabe, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaOC(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //valida cuando la existencia no esta en la formula
            ExistenciaEN iExiForEN = ExistenciaRN.ValidaCuandoExistenciaNoEsDeFormula(pClaveFormulaCabe, iExiEN);
            if (iExiForEN.Adicionales.EsVerdad == false) { return iExiForEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoExistenciaNoEsDeFormula(string pClaveFormulaCabe, ExistenciaEN pExi)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar
            //traer al objeto formula
            FormulaCabeEN iForCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(pClaveFormulaCabe);

            //comparar con el almacen de filtro para la lista
            if (iForCabEN.CodigoAlmacen == pExi.CodigoAlmacen || iForCabEN.CodigoAlmacenEmpaquetado == pExi.CodigoAlmacen)
            {
                FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXClaveFormulaCabeYCodigoExistencia(pClaveFormulaCabe,
                   pExi.CodigoExistencia);
                if (iForDetEN.ClaveFormulaDeta == string.Empty)
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Solo puedes elegir existencias de la formula de esta produccion";
                }
            }
            else
            {
                if (iForCabEN.CodigoSemiProducto != pExi.CodigoExistencia)
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Solo puedes elegir la existencia del producto SemiElaborado";
                }
            }

            //devolver
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasParaProduccionNoSeleccionadasEnGrilla(string pCodigoAlmacen, string pClaveFormulaCabe,
            List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer al objeto formula
            FormulaCabeEN iForCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(pClaveFormulaCabe);

            //comparar con el almacen de filtro para la lista
            if (iForCabEN.CodigoAlmacen == pCodigoAlmacen || iForCabEN.CodigoAlmacenEmpaquetado == pCodigoAlmacen)
            {
                //almacen de produccion
                iLisRes = ExistenciaRN.ListarExistenciasDeFormulaNoSeleccionadasEnGrilla(pCodigoAlmacen, pClaveFormulaCabe, pLisMovDet);
            }
            else
            {
                //almacen de productos semielaborados
                //buscar si esta en la lista de movimientoDeta
                bool iExiste = ListaG.Existe<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodExi, iForCabEN.CodigoSemiProducto);

                //sino existe pasa a la lista resultado
                if (iExiste == false)
                {
                    //traer a la existencia de producto semielaborado
                    ExistenciaEN iExiEN = new ExistenciaEN();
                    iExiEN.CodigoAlmacen = iForCabEN.CodigoAlmacenSemiProducto;
                    iExiEN.CodigoExistencia = iForCabEN.CodigoSemiProducto;
                    iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
                    iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

                    //agregar a la lista
                    iLisRes.Add(iExiEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasParaProduccionNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, string pClaveFormulaCabe,
    List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer al objeto formula
            FormulaCabeEN iForCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(pClaveFormulaCabe);

            //comparar con el almacen de filtro para la lista
            if (iForCabEN.CodigoAlmacen == pCodigoAlmacen || iForCabEN.CodigoAlmacenEmpaquetado == pCodigoAlmacen)
            {
                //almacen de produccion
                iLisRes = ExistenciaRN.ListarExistenciasDeFormulaNoSeleccionadasEnGrillaOC(pCodigoAlmacen, pClaveFormulaCabe, pLisMovDet);
            }
            else
            {
                //almacen de productos semielaborados
                //buscar si esta en la lista de movimientoDeta
                bool iExiste = ListaG.Existe<MovimientoOCDetaEN>(pLisMovDet, MovimientoOCDetaEN.CodExi, iForCabEN.CodigoSemiProducto);

                //sino existe pasa a la lista resultado
                if (iExiste == false)
                {
                    //traer a la existencia de producto semielaborado
                    ExistenciaEN iExiEN = new ExistenciaEN();
                    iExiEN.CodigoAlmacen = iForCabEN.CodigoAlmacenSemiProducto;
                    iExiEN.CodigoExistencia = iForCabEN.CodigoSemiProducto;
                    iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
                    iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

                    //agregar a la lista
                    iLisRes.Add(iExiEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN BuscarExistenciaDeSemiProducto(ProduccionDetaEN pObj)
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pObj);

            //ejecutar metodo
            return ExistenciaRN.BuscarExistenciaXClave(iExiEN);
        }

        public static ExistenciaEN BuscarExistenciaDeSemiProducto(FormulaCabeEN pObj)
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = FormulaCabeRN.ObtenerClaveExistenciaSemiProducto(pObj);

            //ejecutar metodo
            return ExistenciaRN.BuscarExistenciaXClave(iExiEN);
        }

        public static List<ExistenciaEN> ListarExistenciaAcumuladosPorCodigoExistencia(List<ExistenciaEN> pLisExi)
        {
            //---------------------------------------------------------------------------------------------
            //ademas de acumular los saldos de todos las existencias en todos los almacenes,tambien obtiene
            //los codigos almacenes que acumulo con stock diferente de cero
            //---------------------------------------------------------------------------------------------

            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //quitar de esta lista a las existencias del almacen de desmedros,estas no deben contar
            pLisExi = ListaG.FiltrarExcepto<ExistenciaEN>(pLisExi, ExistenciaEN.CodAlm, "A21");

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLisExi)
            {
                //variable de encontrado
                int iEncontrado = 0;

                //buscar
                foreach (ExistenciaEN xExiBus in iLisRes)
                {
                    if (xExi.CodigoExistencia == xExiBus.CodigoExistencia)
                    {
                        xExiBus.StockActualExistencia += xExi.StockActualExistencia;
                        if (xExi.StockActualExistencia != 0)
                        {
                            xExiBus.Adicionales.Mensaje += "," + xExi.CodigoAlmacen;
                        }
                        iEncontrado = 1;
                        continue;
                    }
                }

                //sino lo encontro agrega este objeto a la lista resultado
                if (iEncontrado == 0)
                {
                    if (xExi.StockActualExistencia != 0)
                    {
                        xExi.Adicionales.Mensaje = xExi.CodigoAlmacen;
                    }
                    iLisRes.Add(xExi);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasParaAlertaStock(List<ExistenciaEN> pListaExistenciaEmpresa)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //recorrer a todas las existencias de la empresa
            foreach (ExistenciaEN xExi in pListaExistenciaEmpresa)
            {
                //validar si son existencias de produccion
                if (xExi.CEsProduccion == "1") { continue; }

                //validar si no es existencia para alertar por stock minimo
                if (xExi.StockActualExistencia > xExi.StockAlertaExistencia) { continue; }

                //adicionar a la lista resultado
                iLisRes.Add(xExi);
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasParaAlertaStock()
        {
            //asignar parametros
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //ejecutar metodo
            return ExistenciaRN.ListarExistenciasParaAlertaStock(iLisExiEmp);
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantes()
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //lista de todas las solicitudes que intervienen para desccarga del almacen
            List<ProduccionCabeEN> iLisProCabTot = new List<ProduccionCabeEN>();

            //agregar las solicitudes que estan en estado terminado pero que su orden de 
            //trabajo no ha descargado sus insumos
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeTerminadosYSinDescargaInsumos());

            //agregar las solicitudes que estan en estado "aprobado"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoAprobado());

            //obtener la lista de todas las produccionesExis en con montos acumulados de estas solicitudes
            List<ProduccionExisEN> iLisProExiAcu = ProduccionExisRN.ListarProduccionExisAcumulados(iLisProCabTot);

            //obtener la lista de solo los insumos que no completan lo que pide las solicitudes
            iLisRes = ExistenciaRN.ListarExistenciasSobrantes(iLisProExiAcu);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantesOC()
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //lista de todas las solicitudes que intervienen para desccarga del almacen
            List<ProduccionCabeEN> iLisProCabTot = new List<ProduccionCabeEN>();

            //agregar las solicitudes que estan en estado terminado pero que su orden de 
            //trabajo no ha descargado sus insumos
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeTerminadosYSinDescargaInsumos());

            //agregar las solicitudes que estan en estado "aprobado"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoAprobado());

            //obtener la lista de todas las produccionesExis en con montos acumulados de estas solicitudes
            List<ProduccionExisEN> iLisProExiAcu = ProduccionExisRN.ListarProduccionExisAcumulados(iLisProCabTot);

            //obtener la lista de solo los insumos que no completan lo que pide las solicitudes
            iLisRes = ExistenciaRN.ListarExistenciasSobrantesOC(iLisProExiAcu);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantes(List<ProduccionExisEN> pLis)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //crear una lista acumulada por codigoExistencia sin contemplar el almacen
            iLisExiEmp = ExistenciaRN.ListarExistenciaAcumuladosPorCodigoExistencia(iLisExiEmp);

            //obtener lista actualizada con stock sin considerar los que ya estan separados
            iLisRes = ExistenciaRN.ActualizarStockActualQuitandoProduccion(iLisExiEmp, pLis);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantesOC(List<ProduccionExisEN> pLis)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //crear una lista acumulada por codigoExistencia sin contemplar el almacen
            iLisExiEmp = ExistenciaRN.ListarExistenciaAcumuladosPorCodigoExistencia(iLisExiEmp);

            //obtener lista actualizada con stock sin considerar los que ya estan separados
            iLisRes = ExistenciaRN.ActualizarStockActualQuitandoProduccion(iLisExiEmp, pLis);

            //devolver
            return iLisRes;
        }

        public static string ObtenerNumeroCodigoAutogenerado(ExistenciaEN pExi)
        {
            //nuevo numero
            string iNuevoNumero;
            //listar os contratos
            pExi.Adicionales.CampoOrden = ExistenciaEN.ClaExi;
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistenciasXEmpresaYAlmacen(pExi);

            //obtener el ultimo numero de Codigo Existencia
            int iNumeroCodigoExistencia = iLisExi.Count;
            if (iNumeroCodigoExistencia == 0)
            {
                iNuevoNumero = pExi.CSubClaseExistencia + "000001";
            }
            else
            {
                //Parte de la clave;
                int iLongitudCharClave = pExi.CSubClaseExistencia.Length;

                int iCorrelativo = Convert.ToInt32(iLisExi[iNumeroCodigoExistencia - 1].CodigoExistencia);
                iCorrelativo++;

                iNuevoNumero = iCorrelativo.ToString().PadLeft(6, Convert.ToChar("0"));

            }
            return iNuevoNumero;
        }

        public static List<ExistenciaEN> ListarExistenciasXEmpresaYAlmacenYTipo(ExistenciaEN pObj)
        {
            ExistenciaAD iExiAD = new ExistenciaAD();
            return iExiAD.ListarExistenciasXEmpresaYAlmacenYTipo(pObj);
        }

        public static List<ExistenciaEN> ListarExistenciasXEmpresaYAlmacen(ExistenciaEN pObj)
        {
            ExistenciaAD iExiAD = new ExistenciaAD();
            return iExiAD.ListarExistenciasXEmpresaYAlmacen(pObj);
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantes(MovimientoDetaEN pObj, string pCodigoAlmacenIngresoTransferencia)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //lista de todas las solicitudes que intervienen para desccarga del almacen
            List<ProduccionCabeEN> iLisProCabTot = new List<ProduccionCabeEN>();

            //agregar las solicitudes que estan en estado terminado pero que su orden de 
            //trabajo no ha descargado sus insumos
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeTerminadosYSinDescargaInsumos());

            //agregar las solicitudes que estan en estado "aprobado"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoAprobado());

            //obtener la lista de todas las produccionesExis en con montos acumulados de estas solicitudes
            List<ProduccionExisEN> iLisProExiAcu = ProduccionExisRN.ListarProduccionExisAcumulados(iLisProCabTot);

            //obtener la lista de solo los insumos que no completan lo que pide las solicitudes
            iLisRes = ExistenciaRN.ListarExistenciasSobrantes(iLisProExiAcu, pObj, pCodigoAlmacenIngresoTransferencia);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantesOC(MovimientoOCDetaEN pObj, string pCodigoAlmacenIngresoTransferencia)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //lista de todas las solicitudes que intervienen para desccarga del almacen
            List<ProduccionCabeEN> iLisProCabTot = new List<ProduccionCabeEN>();

            //agregar las solicitudes que estan en estado terminado pero que su orden de 
            //trabajo no ha descargado sus insumos
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeTerminadosYSinDescargaInsumos());

            //agregar las solicitudes que estan en estado "aprobado"
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeEstadoAprobado());

            //obtener la lista de todas las produccionesExis en con montos acumulados de estas solicitudes
            List<ProduccionExisEN> iLisProExiAcu = ProduccionExisRN.ListarProduccionExisAcumulados(iLisProCabTot);

            //obtener la lista de solo los insumos que no completan lo que pide las solicitudes
            iLisRes = ExistenciaRN.ListarExistenciasSobrantesOC(iLisProExiAcu, pObj, pCodigoAlmacenIngresoTransferencia);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantes(List<ProduccionExisEN> pLis, MovimientoDetaEN pObj,
            string pCodigoAlmacenIngresoTransferencia)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //modificar el stock del objeto de la lista con el que tiene el pObj
            ExistenciaRN.ActualizarExistenciaAlModificarMovimientoSalida(iLisExiEmp, pObj, pCodigoAlmacenIngresoTransferencia);

            //crear una lista acumulada por codigoExistencia sin contemplar el almacen
            iLisExiEmp = ExistenciaRN.ListarExistenciaAcumuladosPorCodigoExistencia(iLisExiEmp);

            //obtener lista actualizada con stock sin considerar los que ya estan separados
            iLisRes = ExistenciaRN.ActualizarStockActualQuitandoProduccion(iLisExiEmp, pLis);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantesOC(List<ProduccionExisEN> pLis, MovimientoOCDetaEN pObj,
           string pCodigoAlmacenIngresoTransferencia)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //modificar el stock del objeto de la lista con el que tiene el pObj
            ExistenciaRN.ActualizarExistenciaAlModificarMovimientoSalidaOC(iLisExiEmp, pObj, pCodigoAlmacenIngresoTransferencia);

            //crear una lista acumulada por codigoExistencia sin contemplar el almacen
            iLisExiEmp = ExistenciaRN.ListarExistenciaAcumuladosPorCodigoExistencia(iLisExiEmp);

            //obtener lista actualizada con stock sin considerar los que ya estan separados
            iLisRes = ExistenciaRN.ActualizarStockActualQuitandoProduccion(iLisExiEmp, pLis);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ActualizarStockActualQuitandoProduccion(List<ExistenciaEN> pLisExi, List<ProduccionExisEN> pLisProExi)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //armar la clave de la existencia
                string iClaveExistencia = xProExi.CodigoExistencia;

                //buscar a la existencia
                ExistenciaEN iExiEN = ListaG.Buscar<ExistenciaEN>(pLisExi, ExistenciaEN.CodExi, iClaveExistencia);

                //obtener el nuevo stock de la existencia
                iExiEN.StockActualExistencia = iExiEN.StockActualExistencia - xProExi.CantidadProduccionExis;

                //agregamos a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static void ActualizarExistenciaAlModificarMovimientoSalida(List<ExistenciaEN> pLista, MovimientoDetaEN pObj,
            string pCodigoAlmacenIngresoTransferencia)
        {
            //validar cuando no es una modificacion del movimiento
            if (pObj.UsuarioAgrega == string.Empty) { return; }

            //actualizar la salida
            string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(pObj);
            ListaG.Modificar<ExistenciaEN>(pLista, ExistenciaEN.ClaExi, iClaveExistencia, ExistenciaEN.StoActExi,
                pObj.StockAnteriorExistencia);

            //si es transferencia,entonces hay que actualizar el ingreso en el otro almacen
            if (pCodigoAlmacenIngresoTransferencia != string.Empty)
            {
                //armar la clave de la existencia de ingreso de transferencia             
                string iClaveExistenciaIngresoTransferencia = ExistenciaRN.ObtenerClaveExistencia(pCodigoAlmacenIngresoTransferencia,
                    pObj.CodigoExistencia);

                //traer al movimiento de la b.d
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.BuscarMovimientoDetaXClave(pObj);

                //buscar la existencia de ingreso
                ExistenciaEN iExiEN = ListaG.Buscar<ExistenciaEN>(pLista, ExistenciaEN.ClaExi, iClaveExistenciaIngresoTransferencia);

                //actualizar su stock actual
                iExiEN.StockActualExistencia -= iMovDetEN.CantidadMovimientoDeta;

                //actualizar el ingreso
                ListaG.Modificar<ExistenciaEN>(pLista, iExiEN, ExistenciaEN.ClaExi, iClaveExistenciaIngresoTransferencia);
            }

        }

        public static void ActualizarExistenciaAlModificarMovimientoSalidaOC(List<ExistenciaEN> pLista, MovimientoOCDetaEN pObj,
    string pCodigoAlmacenIngresoTransferencia)
        {
            //validar cuando no es una modificacion del movimiento
            if (pObj.UsuarioAgrega == string.Empty) { return; }

            //actualizar la salida
            string iClaveExistencia = MovimientoOCDetaRN.ObtenerClaveExistencia(pObj);
            ListaG.Modificar<ExistenciaEN>(pLista, ExistenciaEN.ClaExi, iClaveExistencia, ExistenciaEN.StoActExi,
                pObj.StockAnteriorExistencia);

            //si es transferencia,entonces hay que actualizar el ingreso en el otro almacen
            if (pCodigoAlmacenIngresoTransferencia != string.Empty)
            {
                //armar la clave de la existencia de ingreso de transferencia             
                string iClaveExistenciaIngresoTransferencia = ExistenciaRN.ObtenerClaveExistencia(pCodigoAlmacenIngresoTransferencia,
                    pObj.CodigoExistencia);

                //traer al movimiento de la b.d
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.BuscarMovimientoDetaXClave(pObj);

                //buscar la existencia de ingreso
                ExistenciaEN iExiEN = ListaG.Buscar<ExistenciaEN>(pLista, ExistenciaEN.ClaExi, iClaveExistenciaIngresoTransferencia);

                //actualizar su stock actual
                iExiEN.StockActualExistencia -= iMovDetEN.CantidadMovimientoDeta;

                //actualizar el ingreso
                ListaG.Modificar<ExistenciaEN>(pLista, iExiEN, ExistenciaEN.ClaExi, iClaveExistenciaIngresoTransferencia);
            }

        }

        public static List<ExistenciaEN> ListarExistenciasSobrantes(MovimientoDetaEN pObj)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //lista de todas las solicitudes que intervienen para desccarga del almacen
            List<ProduccionCabeEN> iLisProCabTot = new List<ProduccionCabeEN>();

            //agregar las solicitudes que estan en estado terminado pero que su orden de 
            //trabajo no ha descargado sus insumos
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeTerminadosYSinDescargaInsumos());

            //obtener la lista de todas las produccionesExis en con montos acumulados de estas solicitudes
            List<ProduccionExisEN> iLisProExiAcu = ProduccionExisRN.ListarProduccionExisAcumulados(iLisProCabTot);

            //obtener la lista de solo los insumos que no completan lo que pide las solicitudes
            iLisRes = ExistenciaRN.ListarExistenciasSobrantes(iLisProExiAcu, pObj);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantesOC(MovimientoOCDetaEN pObj)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //lista de todas las solicitudes que intervienen para desccarga del almacen
            List<ProduccionCabeEN> iLisProCabTot = new List<ProduccionCabeEN>();

            //agregar las solicitudes que estan en estado terminado pero que su orden de 
            //trabajo no ha descargado sus insumos
            iLisProCabTot.AddRange(ProduccionCabeRN.ListarProduccionCabeTerminadosYSinDescargaInsumos());

            //obtener la lista de todas las produccionesExis en con montos acumulados de estas solicitudes
            List<ProduccionExisEN> iLisProExiAcu = ProduccionExisRN.ListarProduccionExisAcumulados(iLisProCabTot);

            //obtener la lista de solo los insumos que no completan lo que pide las solicitudes
            iLisRes = ExistenciaRN.ListarExistenciasSobrantesOC(iLisProExiAcu, pObj);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantes(List<ProduccionExisEN> pLis, MovimientoDetaEN pObj)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen indicado
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pObj.CodigoAlmacen);

            //modificar el stock del objeto de la lista con el que tiene el pObj
            ExistenciaRN.ActualizarExistenciaAlModificarMovimientoSalida(iLisExiEmp, pObj, string.Empty);

            //obtener lista actualizada con stock sin considerar los que ya estan separados
            iLisRes = ExistenciaRN.ActualizarStockActualQuitandoProduccion(iLisExiEmp, pLis);

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasSobrantesOC(List<ProduccionExisEN> pLis, MovimientoOCDetaEN pObj)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen indicado
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pObj.CodigoAlmacen);

            //modificar el stock del objeto de la lista con el que tiene el pObj
            ExistenciaRN.ActualizarExistenciaAlModificarMovimientoSalidaOC(iLisExiEmp, pObj, string.Empty);

            //obtener lista actualizada con stock sin considerar los que ya estan separados
            iLisRes = ExistenciaRN.ActualizarStockActualQuitandoProduccion(iLisExiEmp, pLis);

            //devolver
            return iLisRes;
        }

        public static List<string> ListarClavesExistencias()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //traer a todas las existencias de la empresa de acceso
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistencias();

            //obtener la lista de valores de claves de exisstencia
            iLisRes = ListaG.ListarValoresDeCampo<ExistenciaEN>(iLisExi, "-", ExistenciaEN.CodAlm, ExistenciaEN.CodExi);

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN BuscarExistencia(string pCodAlm, string pCodExi)
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pCodAlm;
            iExiEN.CodigoExistencia = pCodExi;
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //ejecutar metodo
            return ExistenciaRN.BuscarExistenciaXClave(iExiEN);
        }

        public static List<ExistenciaEN> ListarExistenciasProductosTerminadosDeAlmacenNoSeleccionadasEnGrilla(string pCodigoAlmacen, List<ProduccionProTerEN> pLisProProTer)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasDeAlmacen(pCodigoAlmacen);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in iLisExiAlm)
            {
                //si no es producto terminado, entonces no avanza
                if (xExi.CodigoTipo != "PT") { continue; }

                //flag encontrado
                int iEncontrado = 0;

                //recorrer cada objeto
                foreach (ProduccionProTerEN xProProTer in pLisProProTer)
                {
                    if (xExi.CodigoExistencia == xProProTer.CodigoExistencia)
                    {
                        iEncontrado = 1;
                        break;
                    }
                }

                //sino lo encontro lo agrega a la lista resultado
                if (iEncontrado == 0) { iLisRes.Add(xExi); }
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaProductoTerminadoActivoValido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
          string pCodigoExistenciaFranjaGrilla, List<ProduccionProTerEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia no es de produccion
            ExistenciaEN iExiProTerEN = ExistenciaRN.ValidaCuandoExistenciaNoEsProductoTerminado(iExiEN);
            if (iExiProTerEN.Adicionales.EsVerdad == false) { return iExiProTerEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoCodigoYaExisteEnGrilla(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
           string pCodigoExistenciaFranjaGrilla, List<ProduccionProTerEN> pLisProProTerGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar   
            ProduccionProTerEN iProProTerEN = ListaG.Buscar<ProduccionProTerEN>(pLisProProTerGrilla, ProduccionProTerEN.CodExi, pObj.CodigoExistencia);
            if (iProProTerEN.CodigoExistencia != string.Empty)
            {
                if (pOperacionVentana == Universal.Opera.Adicionar || (pOperacionVentana == Universal.Opera.Modificar && iProProTerEN.CodigoExistencia != pCodigoExistenciaFranjaGrilla))
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Esta existencia ya se registro en la grilla";
                    return iExiEN;
                }
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static ExistenciaEN ObtenerExistenciaSemiElaborado(ProduccionProTerEN pProProTer)
        {
            //obtener la formulaDeta al cual pertenece este ProTer
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);

            //buscar al objeto en bd
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(iForDetEN.CodigoAlmacenSemiProducto, iForDetEN.CodigoSemiProducto);

            //devolver
            return iExiEN;
        }

        public ExistenciaEN EsNumeroContratoSegunAutomatica(ExistenciaEN pCon, bool pVacio, bool pAutomatica)
        {
            ExistenciaEN iConEN = new ExistenciaEN();
            if (pVacio == false)
            {
                if (pCon.CodigoExistencia == string.Empty)
                {
                    iConEN.Adicionales.EsVerdad = true;
                    iConEN.Adicionales.Mensaje = string.Empty;
                    return iConEN;
                }
            }
            else
            {
                if (pAutomatica == false)
                {
                    if (pCon.CodigoExistencia == string.Empty)
                    {
                        iConEN.Adicionales.EsVerdad = false;
                        iConEN.Adicionales.Mensaje = "Debes digitar un numero contrato";
                        return iConEN;
                    }
                }
                else
                {
                    if (pCon.CodigoExistencia == string.Empty)
                    {
                        iConEN.Adicionales.EsVerdad = true;
                        iConEN.Adicionales.Mensaje = string.Empty;
                        return iConEN;
                    }
                }
            }

            //desde aqui si se digito un numero
            //validando el numero contrato digitado
            //formato del numero contrato(correlativo=4)
            List<string> iLisGru4 = Cadena.ObtenerGruposDe(pCon.CodigoExistencia, 4, Cadena.Direccion.Derecha);

            //si la lista tiene 2 elementos entonces puede ser el formato
            if (iLisGru4.Count == 2)
            {
                //ahora chequear si la parte del proyecto que se digito
                //coincide con el proyecto en el que estas actualmente
                string iCodigoProyecto = iLisGru4[1].ToString();

                //si es diferente entonces sale
                if (iCodigoProyecto != pCon.CodigoExistencia)
                {
                    if (iCodigoProyecto == "C60")
                    {
                        return iConEN;
                    }
                    else
                    {
                        iConEN.Adicionales.EsVerdad = false;
                        iConEN.Adicionales.Mensaje = "El codigo proyecto que digitastes " + iCodigoProyecto + " no es el correcto";
                        return iConEN;
                    }
                    //iConEN.Adicionales.EsVerdad = false;
                    //iConEN.Adicionales.Mensaje = "El codigo proyecto que digitastes " + iCodigoProyecto + " no es el correcto";
                    //return iConEN;
                }

                //ahora el proyecto es el correcto, entonces ver si el correlativo esta
                //en el rango de los correlativos que ya existe 
                //iConEN = this.buscar(pCon);
                if (iConEN.ClaveExistencia == string.Empty)
                {
                    ////si el numero contrato no existe en b.d ,debemos chequear si no existe porque
                    ////esta dentro del rango de contratos o fuera de ella
                    //List<ContratoEN> iLisCon = new List<ContratoEN>( );
                    //pCon.Adicionales.CampoOrden = ContratoEN.ClaCon;
                    //iLisCon = this.ListarContratosXEmpresaYProyecto( pCon );


                    //string iNuevoNumero =  pCon.NumeroContrato;
                    //string iPrimerNumero = pCon.CodigoProyecto + "0000";
                    ////si la lista esta vacia
                    //string iUltimoNumero;
                    //if( iLisCon.Count == 0 )
                    //{
                    //    iUltimoNumero = iPrimerNumero;
                    //}
                    //else
                    //{
                    //    iUltimoNumero = iLisCon[iLisCon.Count - 1].NumeroContrato;
                    //}


                    //if( Cadena.EsLimiteMinimoYMaximoDeValores( iNuevoNumero , iPrimerNumero , iUltimoNumero ) == false )
                    //{
                    //    iConEN.Adicionales.EsVerdad = false;
                    //    iConEN.Adicionales.Mensaje = "El numero contrato que digitastes " + iNuevoNumero + " no esta en los limites";
                    //    return iConEN;
                    //}

                    //si es correcto
                    iConEN.Adicionales.EsVerdad = true;
                    iConEN.Adicionales.Mensaje = string.Empty;
                    return iConEN;
                }
                else
                {
                    //aque el numero contrato que digitastes ya existe
                    iConEN.Adicionales.EsVerdad = false;
                    iConEN.Adicionales.Mensaje = "El numero contrato que digitastes " + pCon.CodigoExistencia + " ya existe";
                    return iConEN;
                }

            }
            else
            {
                iConEN.Adicionales.EsVerdad = false;
                iConEN.Adicionales.Mensaje = "El numero Contrato no tiene el formato correcto, CodigoProyecto + correlativo(4 digitos) . ejemplo 150004";
                return iConEN;
            }

        }

        public static List<ExistenciaEN> ListarExistenciasParaRecalculoReprocesos(List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //filtrar sin repetir la existencia            
            List<MovimientoDetaEN> iLisMovDetSinRep = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodAlm, "A18");//solo almacen reproceso(A18)
            iLisMovDetSinRep = ListaG.FiltrarObjetosSinRepetir<MovimientoDetaEN>(iLisMovDetSinRep, MovimientoDetaEN.CodExi);

            //recorrer cada lista
            foreach (MovimientoDetaEN xMovDet in iLisMovDetSinRep)
            {
                ExistenciaEN iExiNueEN = new ExistenciaEN();
                iExiNueEN.CodigoExistencia = xMovDet.CodigoExistencia;
                iExiNueEN.StockActualExistencia = xMovDet.StockAnteriorExistencia;
                iExiNueEN.PrecioPromedioExistencia = xMovDet.PrecioAnteriorExistencia;

                //adicionar a la lista resultado
                iLisRes.Add(iExiNueEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasParaRecalculoReprocesosOC(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //filtrar sin repetir la existencia            
            List<MovimientoOCDetaEN> iLisMovDetSinRep = ListaG.Filtrar<MovimientoOCDetaEN>(pLisMovDet, MovimientoOCDetaEN.CodAlm, "A18");//solo almacen reproceso(A18)
            iLisMovDetSinRep = ListaG.FiltrarObjetosSinRepetir<MovimientoOCDetaEN>(iLisMovDetSinRep, MovimientoOCDetaEN.CodExi);

            //recorrer cada lista
            foreach (MovimientoOCDetaEN xMovDet in iLisMovDetSinRep)
            {
                ExistenciaEN iExiNueEN = new ExistenciaEN();
                iExiNueEN.CodigoExistencia = xMovDet.CodigoExistencia;
                iExiNueEN.StockActualExistencia = xMovDet.StockAnteriorExistencia;
                iExiNueEN.PrecioPromedioExistencia = xMovDet.PrecioAnteriorExistencia;

                //adicionar a la lista resultado
                iLisRes.Add(iExiNueEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasActivasDeAlmacenYNoProduccion(ExistenciaEN pObj)
        {
            ExistenciaAD iExiAD = new ExistenciaAD();
            return iExiAD.ListarExistenciasActivasDeAlmacenYNoProduccion(pObj);
        }

        public static ExistenciaEN EsExistenciaActivaDeNoProduccionValido(ExistenciaEN pObj)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia no es de produccion
            ExistenciaEN iExiSiProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiSiProEN.Adicionales.EsVerdad == false) { return iExiSiProEN; }

            //valida cuando la existencia esta desactivada
            ExistenciaEN iExiActEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiActEN.Adicionales.EsVerdad == false) { return iExiActEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN HayExistenciasQueNoHayEnAlmacen(List<ProduccionExisEN> pLisProExi, string pCodigoAlmacenBusqueda)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {

                //armar la existencia busqueda y buscar en bd
                ExistenciaEN iExiBusEN = BuscarExistencia(pCodigoAlmacenBusqueda, xProExi.CodigoExistencia);

                //sino existen,armamos el mensaje error
                if (iExiBusEN.CodigoExistencia == string.Empty)
                {
                    iExiEN.Adicionales.Mensaje += xProExi.CodigoExistencia + " : " + xProExi.DescripcionExistencia + Cadena.SaltarLineas(2);
                }
            }

            //si hay existencias que no estan en el almacen de busqueda
            if (iExiEN.Adicionales.Mensaje != string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "Falta registrar esta(as) existencias en el almacen de desmedros " + Cadena.SaltarLineas(2) +
                    iExiEN.Adicionales.Mensaje;
            }

            //devolver
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasFaseEncajadoParaProduccionNoSeleccionadasEnGrilla(string pClaveProduccionProTer,
            List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer las producciones exis de fase de encajado de esta ProduccionProTer
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionProTer(pClaveProduccionProTer);

            //traer la lista de existencias del almacen de envases y embalajes
            List<ExistenciaEN> iLisExi = ListarExistenciasActivasDeAlmacen("A09");

            //sacar solo las produccionesexis que no estan en movimientosDeta
            List<ProduccionExisEN> iLisProExiFin = ListaG.ListarAMenosB<ProduccionExisEN, MovimientoDetaEN>(iLisProExi, pLisMovDet, ProduccionExisEN.CodExi);

            //recorrer cada objeto 
            foreach (ProduccionExisEN xProExi in iLisProExiFin)
            {
                //buscar en la lista de existencias
                ExistenciaEN iExiEN = ListaG.Buscar<ExistenciaEN>(iLisExi, ExistenciaEN.CodExi, xProExi.CodigoExistencia);

                //agregar a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasFaseEncajadoParaProduccionNoSeleccionadasEnGrillaOC(string pClaveProduccionProTer,
           List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer las producciones exis de fase de encajado de esta ProduccionProTer
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionProTer(pClaveProduccionProTer);

            //traer la lista de existencias del almacen de envases y embalajes
            List<ExistenciaEN> iLisExi = ListarExistenciasActivasDeAlmacen("A09");

            //sacar solo las produccionesexis que no estan en movimientosDeta
            List<ProduccionExisEN> iLisProExiFin = ListaG.ListarAMenosB<ProduccionExisEN, MovimientoOCDetaEN>(iLisProExi, pLisMovDet, ProduccionExisEN.CodExi);

            //recorrer cada objeto 
            foreach (ProduccionExisEN xProExi in iLisProExiFin)
            {
                //buscar en la lista de existencias
                ExistenciaEN iExiEN = ListaG.Buscar<ExistenciaEN>(iLisExi, ExistenciaEN.CodExi, xProExi.CodigoExistencia);

                //agregar a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaActivoParaEncajadoValido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
         string pCodigoExistenciaFranjaGrilla, string pClaveProduccionProTer, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //valida cuando la existencia no esta en la formula
            ExistenciaEN iExiForEN = ExistenciaRN.ValidaCuandoExistenciaNoEsDeProduccionExiDeEncajado(pClaveProduccionProTer, iExiEN);
            if (iExiForEN.Adicionales.EsVerdad == false) { return iExiForEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaActivoParaEncajadoValidoOC(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
 string pCodigoExistenciaFranjaGrilla, string pClaveProduccionProTer, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaOC(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //valida cuando la existencia no esta en la formula
            ExistenciaEN iExiForEN = ExistenciaRN.ValidaCuandoExistenciaNoEsDeProduccionExiDeEncajado(pClaveProduccionProTer, iExiEN);
            if (iExiForEN.Adicionales.EsVerdad == false) { return iExiForEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoExistenciaNoEsDeProduccionExiDeEncajado(string pClaveProduccionProTer, ExistenciaEN pExi)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar
            //traer las producciones exis de fase de encajado de esta ProduccionProTer
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionProTer(pClaveProduccionProTer);

            //buscar si no existe esta existencia
            bool iExiste = ListaG.Existe<ProduccionExisEN>(iLisProExi, ProduccionExisEN.CodExi, pExi.CodigoExistencia);
            if (iExiste == false)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "No es una existencia de fase encajado";
            }

            //devolver
            return iExiEN;
        }

        public static List<ExistenciaEN> ListarExistenciasParaEncajadoNoSeleccionadasEnGrilla(string pCodigoAlmacen, ProduccionProTerEN pProProTer,
           List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer al objeto formulaDeta           
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);

            //comparar con el almacen de filtro para la lista
            if (pCodigoAlmacen == "A09")
            {
                //almacen de produccion
                iLisRes = ExistenciaRN.ListarExistenciasDeFormulaFaseEncajadoNoSeleccionadasEnGrilla(pCodigoAlmacen, iForDetEN.ClaveFormulaCabe,
                    pLisMovDet);
            }
            else
            {
                //almacen de productos semielaborados
                //buscar si esta en la lista de movimientoDeta
                bool iExiste = ListaG.Existe<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodExi, iForDetEN.CodigoSemiProducto);

                //sino existe pasa a la lista resultado
                if (iExiste == false)
                {
                    //traer a la existencia de producto semielaborado
                    ExistenciaEN iExiEN = new ExistenciaEN();
                    iExiEN.CodigoAlmacen = iForDetEN.CodigoAlmacenSemiProducto;
                    iExiEN.CodigoExistencia = iForDetEN.CodigoSemiProducto;
                    iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
                    iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

                    //agregar a la lista
                    iLisRes.Add(iExiEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasParaEncajadoNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, ProduccionProTerEN pProProTer,
   List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer al objeto formulaDeta           
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);

            //comparar con el almacen de filtro para la lista
            if (pCodigoAlmacen == "A09")
            {
                //almacen de produccion
                iLisRes = ExistenciaRN.ListarExistenciasDeFormulaFaseEncajadoNoSeleccionadasEnGrillaOC(pCodigoAlmacen, iForDetEN.ClaveFormulaCabe,
                    pLisMovDet);
            }
            else
            {
                //almacen de productos semielaborados
                //buscar si esta en la lista de movimientoDeta
                bool iExiste = ListaG.Existe<MovimientoOCDetaEN>(pLisMovDet, MovimientoOCDetaEN.CodExi, iForDetEN.CodigoSemiProducto);

                //sino existe pasa a la lista resultado
                if (iExiste == false)
                {
                    //traer a la existencia de producto semielaborado
                    ExistenciaEN iExiEN = new ExistenciaEN();
                    iExiEN.CodigoAlmacen = iForDetEN.CodigoAlmacenSemiProducto;
                    iExiEN.CodigoExistencia = iForDetEN.CodigoSemiProducto;
                    iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
                    iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

                    //agregar a la lista
                    iLisRes.Add(iExiEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasDeFormulaFaseEncajadoNoSeleccionadasEnGrilla(string pCodigoAlmacen, string pClaveFormulaCabe,
            List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen y no esten en la grilla de movimientos
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasAlmacenNoSeleccionadasEnGrilla(pCodigoAlmacen, pLisMovDet);

            //traer a los formulasDeta de esta claveFormulaCabe
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(pClaveFormulaCabe, "2", FormulaDetaEN.CorForDet);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //si es de otro almacen, continua al siguiente objeto
                //if (xForDet.CodigoAlmacen != pCodigoAlmacen) { continue; }

                //validar si existe el codigoExistencia de la formula en la lista de existencias
                ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiAlm, ExistenciaEN.CodExi, xForDet.CodigoExistencia);

                //si no fue encontrado ,continua al siguiente objeto
                if (iExiBusEN.CodigoExistencia == string.Empty) { continue; }

                //aqui si lo encontro , adicionamos a la lista resultado
                iLisRes.Add(iExiBusEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<ExistenciaEN> ListarExistenciasDeFormulaFaseEncajadoNoSeleccionadasEnGrillaOC(string pCodigoAlmacen, string pClaveFormulaCabe,
          List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer todas las existencias del almacen y no esten en la grilla de movimientos
            List<ExistenciaEN> iLisExiAlm = ExistenciaRN.ListarExistenciasActivasAlmacenNoSeleccionadasEnGrillaOC(pCodigoAlmacen, pLisMovDet);

            //traer a los formulasDeta de esta claveFormulaCabe
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(pClaveFormulaCabe, "2", FormulaDetaEN.CorForDet);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //si es de otro almacen, continua al siguiente objeto
                //if (xForDet.CodigoAlmacen != pCodigoAlmacen) { continue; }

                //validar si existe el codigoExistencia de la formula en la lista de existencias
                ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiAlm, ExistenciaEN.CodExi, xForDet.CodigoExistencia);

                //si no fue encontrado ,continua al siguiente objeto
                if (iExiBusEN.CodigoExistencia == string.Empty) { continue; }

                //aqui si lo encontro , adicionamos a la lista resultado
                iLisRes.Add(iExiBusEN);
            }

            //devolver
            return iLisRes;
        }

        public static ExistenciaEN EsExistenciaActivoParaEncajadoValido(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
         string pCodigoExistenciaFranjaGrilla, ProduccionProTerEN pProProTer, List<MovimientoDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrilla(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //valida cuando la existencia no esta en la formula
            ExistenciaEN iExiForEN = ExistenciaRN.ValidaCuandoExistenciaNoEsDeFormulaFaseEncajado(pProProTer, iExiEN);
            if (iExiForEN.Adicionales.EsVerdad == false) { return iExiForEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN EsExistenciaActivoParaEncajadoValidoOC(ExistenciaEN pObj, Universal.Opera pOperacionVentana,
 string pCodigoExistenciaFranjaGrilla, ProduccionProTerEN pProProTer, List<MovimientoOCDetaEN> pLisMovDetGrilla)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoExistencia == string.Empty) { return iExiEN; }

            //valida cuando el codigo no existe
            iExiEN = ExistenciaRN.EsExistenciaExistente(pObj);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

            //valida cuando la existencia es de produccion
            ExistenciaEN iExiNoProEN = ExistenciaRN.ValidaCuandoExistenciaEsProduccion(iExiEN);
            if (iExiNoProEN.Adicionales.EsVerdad == false) { return iExiNoProEN; }

            //valida cuando el codigo ya se registro en la grilla
            ExistenciaEN iExiExiEN = ExistenciaRN.ValidaCuandoCodigoYaExisteEnGrillaOC(iExiEN, pOperacionVentana, pCodigoExistenciaFranjaGrilla, pLisMovDetGrilla);
            if (iExiExiEN.Adicionales.EsVerdad == false) { return iExiExiEN; }

            //valida cuando esta desactivada
            ExistenciaEN iExiDesEN = ExistenciaRN.ValidaCuandoEstaDesactivada(iExiEN);
            if (iExiDesEN.Adicionales.EsVerdad == false) { return iExiDesEN; }

            //valida cuando la existencia no esta en la formula
            ExistenciaEN iExiForEN = ExistenciaRN.ValidaCuandoExistenciaNoEsDeFormulaFaseEncajado(pProProTer, iExiEN);
            if (iExiForEN.Adicionales.EsVerdad == false) { return iExiForEN; }

            //ok           
            return iExiEN;
        }

        public static ExistenciaEN ValidaCuandoExistenciaNoEsDeFormulaFaseEncajado(ProduccionProTerEN pProProTer, ExistenciaEN pExi)
        {
            //objeto resultado
            ExistenciaEN iExiEN = new ExistenciaEN();

            //validar
            //traer al objeto formula
            FormulaCabeEN iForCabEN = FormulaCabeRN.BuscarFormulaCabeXClave(ProduccionProTerRN.ObtenerClaveFormulaCabe(pProProTer));

            //comparar con el almacen de filtro para la lista
            if (pExi.CodigoAlmacen == "A09")
            {
                FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXClaveFormulaCabeYCodigoExistencia(iForCabEN.ClaveFormulaCabe,
                   pExi.CodigoExistencia);
                if (iForDetEN.ClaveFormulaDeta == string.Empty || iForDetEN.CTipoDescarga != "2")
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Solo puedes elegir existencias de la formula fase embalajes";
                }
            }
            else
            {
                if (iForCabEN.CodigoSemiProducto != pExi.CodigoExistencia)
                {
                    iExiEN.Adicionales.EsVerdad = false;
                    iExiEN.Adicionales.Mensaje = "Solo puedes elegir la existencia del producto SemiElaborado";
                }
            }

            //devolver
            return iExiEN;
        }

        public static void ModificarStockYPrecioDeExistenciaXCodigo(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            iPerAD.ModificarStockYPrecioDeExistenciaXCodigo(pObj);
        }

        public static List<dynamic> ObtenerReporteExistenciaStockFisicoProgramado(ExistenciaEN pObj)
        {
            ExistenciaAD iPerAD = new ExistenciaAD();
            return iPerAD.ObtenerReporteExistenciaStockFisicoProgramado(pObj);
        }

    }
}
