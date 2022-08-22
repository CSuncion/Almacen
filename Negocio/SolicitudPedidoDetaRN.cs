using Comun;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Entidades.Estructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SolicitudPedidoDetaRN
    {

        public static SolicitudPedidoDetaEN EnBlanco()
        {
            SolicitudPedidoDetaEN iExiEN = new SolicitudPedidoDetaEN();
            return iExiEN;
        }

        public static void AdicionarSolicitudPedidoDeta(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.AgregarSolicitudPedidoDeta(pObj);
        }

        public static void AdicionarSolicitudPedidoDeta(List<SolicitudPedidoDetaEN> pLista)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.AgregarSolicitudPedidoDeta(pLista);
        }

        public static void ModificarSolicitudPedidoDeta(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.ModificarSolicitudPedidoDeta(pObj);
        }

        public static void ModificarSolicitudPedidoDeta(List<SolicitudPedidoDetaEN> pLista)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.ModificarSolicitudPedidoDeta(pLista);
        }

        public static void ModificarSolicitudPedidoDetaParaRecalculo(List<SolicitudPedidoDetaEN> pLista)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.ModificarSolicitudPedidoDetaParaRecalculo(pLista);
        }

        public static void EliminarSolicitudPedidoDeta(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.EliminarSolicitudPedidoDeta(pObj);
        }

        public static void EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(pObj);
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetas(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidoDetas(pObj);
        }

        public static SolicitudPedidoDetaEN BuscarSolicitudPedidoDetaXClave(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.BuscarSolicitudPedidoDetaXClave(pObj);
        }

        public static SolicitudPedidoDetaEN EsSolicitudPedidoDetaExistente(SolicitudPedidoDetaEN pObj)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iExiEN = new SolicitudPedidoDetaEN();

            //validar si existe en b.d
            iExiEN = SolicitudPedidoDetaRN.BuscarSolicitudPedidoDetaXClave(pObj);
            if (iExiEN.ClaveSolicitudPedidoDeta == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "La SolicitudPedidoDeta " + pObj.ClaveSolicitudPedidoDeta + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(SolicitudPedidoDetaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case SolicitudPedidoDetaEN.ClaObj: return pObj.ClaveObjeto;
                case SolicitudPedidoDetaEN.ClaMovDet: return pObj.ClaveSolicitudPedidoDeta;
                case SolicitudPedidoDetaEN.ClaMovCab: return pObj.ClaveSolicitudPedidoCabe;
                case SolicitudPedidoDetaEN.CorMovDet: return pObj.CorrelativoSolicitudPedidoDeta;
                case SolicitudPedidoDetaEN.CodEmp: return pObj.CodigoEmpresa;
                case SolicitudPedidoDetaEN.NomEmp: return pObj.NombreEmpresa;
                case SolicitudPedidoDetaEN.FecMovCab: return pObj.FechaSolicitudPedidoCabe;
                case SolicitudPedidoDetaEN.PerMovCab: return pObj.PeriodoSolicitudPedidoCabe;
                case SolicitudPedidoDetaEN.CodAlm: return pObj.CodigoAlmacen;
                case SolicitudPedidoDetaEN.DesAlm: return pObj.DescripcionAlmacen;
                case SolicitudPedidoDetaEN.CodTipOpe: return pObj.CodigoTipoOperacion;
                case SolicitudPedidoDetaEN.DesTipOpe: return pObj.DescripcionTipoOperacion;
                case SolicitudPedidoDetaEN.CClaTipOpe: return pObj.CClaseTipoOperacion;
                case SolicitudPedidoDetaEN.CCalPrePro: return pObj.CCalculaPrecioPromedio;
                case SolicitudPedidoDetaEN.NumMovCab: return pObj.NumeroSolicitudPedidoCabe;
                case SolicitudPedidoDetaEN.CodAux: return pObj.CodigoAuxiliar;
                case SolicitudPedidoDetaEN.DesAux: return pObj.DescripcionAuxiliar;
                case SolicitudPedidoDetaEN.CTipDoc: return pObj.CTipoDocumento;
                case SolicitudPedidoDetaEN.NTipDoc: return pObj.NTipoDocumento;
                case SolicitudPedidoDetaEN.SerDoc: return pObj.SerieDocumento;
                case SolicitudPedidoDetaEN.NumDoc: return pObj.NumeroDocumento;
                case SolicitudPedidoDetaEN.FecDoc: return pObj.FechaDocumento;
                case SolicitudPedidoDetaEN.CodCenCos: return pObj.CodigoCentroCosto;
                case SolicitudPedidoDetaEN.DesCenCos: return pObj.DescripcionCentroCosto;
                case SolicitudPedidoDetaEN.CodExi: return pObj.CodigoExistencia;
                case SolicitudPedidoDetaEN.DesExi: return pObj.DescripcionExistencia;
                case SolicitudPedidoDetaEN.CodTip: return pObj.CodigoTipo;
                case SolicitudPedidoDetaEN.NomTip: return pObj.NombreTipo;
                case SolicitudPedidoDetaEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case SolicitudPedidoDetaEN.NomUniMed: return pObj.NombreUnidadMedida;
                case SolicitudPedidoDetaEN.CanMovDet: return pObj.CantidadSolicitudPedidoDeta.ToString();
                case SolicitudPedidoDetaEN.GloMovDet: return pObj.GlosaSolicitudPedidoDeta;
                case SolicitudPedidoDetaEN.CEstMovDet: return pObj.CEstadoSolicitudPedidoDeta;
                case SolicitudPedidoDetaEN.NEstMovDet: return pObj.NEstadoSolicitudPedidoDeta;
                case SolicitudPedidoDetaEN.UsuAgr: return pObj.UsuarioAgrega;
                case SolicitudPedidoDetaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case SolicitudPedidoDetaEN.UsuMod: return pObj.UsuarioModifica;
                case SolicitudPedidoDetaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<SolicitudPedidoDetaEN> FiltrarSolicitudPedidoDetasXTextoEnCualquierPosicion(List<SolicitudPedidoDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xPer in pLista)
            {
                string iTexto = SolicitudPedidoDetaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<SolicitudPedidoDetaEN> pListaSolicitudPedidoDetas)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaSolicitudPedidoDetas; }

            //filtar la lista
            iLisRes = SolicitudPedidoDetaRN.FiltrarSolicitudPedidoDetasXTextoEnCualquierPosicion(pListaSolicitudPedidoDetas, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveSolicitudPedidoDeta(SolicitudPedidoDetaEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave            
            iClave += pPer.ClaveSolicitudPedidoCabe + "-";
            iClave += pPer.CorrelativoSolicitudPedidoDeta;

            //retornar
            return iClave;
        }

        public static SolicitudPedidoDetaEN EsActoEliminarSolicitudPedidoDeta(SolicitudPedidoDetaEN pPer)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iExiEN = new SolicitudPedidoDetaEN();

            //validar si existe
            iExiEN = SolicitudPedidoDetaRN.EsSolicitudPedidoDetaExistente(pPer);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }


            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void AdicionarSolicitudPedidoDeta(List<SolicitudPedidoDetaEN> pLis, SolicitudPedidoDetaEN pObj)
        {
            //obtener siguiente correlativo
            pObj.CorrelativoSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerSiguienteCorrelativo(pLis);
            pObj.ClaveObjeto = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<SolicitudPedidoDetaEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "0000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoSolicitudPedidoDeta;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static decimal ObtenerCosto(SolicitudPedidoDetaEN pObj)
        {
            //valor resultado
            decimal iImporte = 0;

            //calcular
            //iImporte = pObj.PrecioUnitarioSolicitudPedidoDeta * pObj.CantidadSolicitudPedidoDeta;

            //retornar
            return iImporte;
        }

        public static List<SolicitudPedidoDetaEN> RefrescarListaSolicitudPedidoDeta(List<SolicitudPedidoDetaEN> pLis)
        {
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();
            foreach (SolicitudPedidoDetaEN xMovDet in pLis)
            {
                iLisRes.Add(xMovDet);
            }
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(pObj);
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static decimal ObtenerPrecioUnitarioSugerido(decimal pPrecioPromedioExistencia, string pCCalculaPrecioPromedio,
            string pCodigoExistenciaAModificar, string pCodigoExistenciaActual, decimal pPrecioUnitarioAnterior)
        {
            //si no se debe calcular el precio promedio, entonces se pone el precio promedio de la existencia
            if (pCCalculaPrecioPromedio == "0")//no
            {
                return pPrecioPromedioExistencia;
            }
            else
            {
                // si pCodigoExistenciaAModificar esta vacio, quiere decir que se esta agregando un nuevo SolicitudPedidoDeta
                if (pCodigoExistenciaAModificar == string.Empty)
                {
                    //si el usuario ya digito precio unitario, entonces persiste este valor
                    if (pPrecioUnitarioAnterior != 0)
                    {
                        return pPrecioUnitarioAnterior;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    //aqui se esta modificando un regsitro de la grilla
                    if (pCodigoExistenciaActual == pCodigoExistenciaAModificar)
                    {
                        return pPrecioUnitarioAnterior;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public static decimal ObtenerNuevoStockPorAdicion(SolicitudPedidoDetaEN pMovDet)
        {
            //valor resultado
            decimal iStock = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                //iStock = pMovDet.StockAnteriorExistencia + pMovDet.CantidadSolicitudPedidoDeta;
            }
            else
            {
                //salida
                //iStock = pMovDet.StockAnteriorExistencia - pMovDet.CantidadSolicitudPedidoDeta;
            }

            //devolver
            return iStock;
        }

        public static decimal ObtenerNuevoPrecioPromedio(SolicitudPedidoDetaEN pMovDet)
        {
            //valor resultado
            decimal iPrecio = 0;

            //calcula
            if (pMovDet.CCalculaPrecioPromedio == "0")//no
            {
                //iPrecio = pMovDet.PrecioAnteriorExistencia;
            }
            else
            {
                //si calcula precio promedio
                //decimal iDividendo = (pMovDet.StockAnteriorExistencia * pMovDet.PrecioAnteriorExistencia) + (pMovDet.CantidadSolicitudPedidoDeta * pMovDet.PrecioUnitarioSolicitudPedidoDeta);
                //decimal iDivisor = pMovDet.StockAnteriorExistencia + pMovDet.CantidadSolicitudPedidoDeta;
                //iPrecio = Operador.DivisionDecimal(iDividendo, iDivisor);
                //MessageBox.Show(iPrecio.ToString(), "Ver");
            }

            //devolver
            return iPrecio;
        }

        public static List<ExistenciaEN> ListarExistenciasReferenciadasEnSolicitudPedidosDeta(List<SolicitudPedidoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = SolicitudPedidoDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiEmp);
                if (iExiEN.ClaveExistencia != string.Empty)
                {
                    iLisRes.Add(iExiEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerClaveExistencia(SolicitudPedidoDetaEN pObj)
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

        public static List<ExistenciaEN> ListarExistenciasActualizadasPorAdicionSolicitudPedidosDeta(List<SolicitudPedidoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a las existencias que estan referenciadas en esta lista pLisMovDet
            List<ExistenciaEN> iLisExiMovDet = SolicitudPedidoDetaRN.ListarExistenciasReferenciadasEnSolicitudPedidosDeta(pLisMovDet);

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = SolicitudPedidoDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiMovDet);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = SolicitudPedidoDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = SolicitudPedidoDetaRN.ObtenerNuevoStockPorAdicion(iExiEN, xMovDet);

                //agregamos a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerNuevoPrecioPromedio(ExistenciaEN pExi, SolicitudPedidoDetaEN pMovDet)
        {
            //valor resultado
            decimal iPrecio = 0;

            //actualizar los datos del SolicitudPedidoDeta
            //pMovDet.PrecioAnteriorExistencia = pExi.PrecioPromedioExistencia;
            //pMovDet.StockAnteriorExistencia = pExi.StockActualExistencia;

            //calcula
            iPrecio = SolicitudPedidoDetaRN.ObtenerNuevoPrecioPromedio(pMovDet);

            //devolver
            return iPrecio;
        }

        public static decimal ObtenerNuevoStockPorAdicion(ExistenciaEN pExi, SolicitudPedidoDetaEN pMovDet)
        {
            //valor resultado
            decimal iStock = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iStock = pExi.StockActualExistencia + pMovDet.CantidadSolicitudPedidoDeta;
            }
            else
            {
                //salida
                iStock = pExi.StockActualExistencia - pMovDet.CantidadSolicitudPedidoDeta;
            }

            //devolver
            return iStock;
        }

        public static SolicitudPedidoDetaEN BuscarSolicitudPedidoDeta(string pCampo, string pValor, List<SolicitudPedidoDetaEN> pLista)
        {
            //objeto resultaddo
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLista)
            {
                if (SolicitudPedidoDetaRN.ObtenerValorDeCampo(xMovDet, pCampo) == pValor)
                {
                    return xMovDet;
                }
            }

            //devolver
            return iMovDetEN;
        }

        public static List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaRecalculo(string pCodigoPeriodo)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarListasDeSolicitudPedidoDetasParaRecalculo(pCodigoPeriodo);
        }

        public static List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaRecalculo(string pAño, string pCodigoMes)
        {
            //asignar parametros
            string iCodigoPeriodo = Formato.UnionDosTextos(pAño, pCodigoMes, "-");

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaRecalculo(iCodigoPeriodo);
        }

        public static void Recalcular(string pAño, string pCodigoMes)
        {
            //traer todo el SolicitudPedido deta del periodo elegido, para el recalculo
            string iCodigoPeriodo = pAño + "-" + pCodigoMes;
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDetExi = SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaRecalculo(iCodigoPeriodo);

            //traer todos los saldos del año que tiene el periodo elegido
            List<SaldoEN> iLisSalAño = SaldoRN.ListarSaldosDeAño(pAño);

            //le bajamos una unidad al codigoMes,este codigo sirve para obtener el stock y precio anterior
            //al mes que se esta procesando
            string iCodigoMesAnterior = Numero.DisminuirCorrelativoNumerico(pCodigoMes);

            //listas para grabar
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetMod = new List<SolicitudPedidoDetaEN>();
            List<SaldoEN> iLisSalMod = new List<SaldoEN>();

            //recorrer cada lista de SolicitudPedido deta de existencia
            foreach (SaldoEN xSal in iLisSalAño)
            {
                //buscar a la existencia en proceso                
                ExistenciaEN iExiEncEN = new ExistenciaEN();
                iExiEncEN.CodigoAlmacen = xSal.CodigoAlmacen;
                iExiEncEN.CodigoExistencia = xSal.CodigoExistencia;
                iExiEncEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEncEN);

                //obtener el stock y precio promedio anterior a este mes de proceso,(punto de inicio)
                iExiEncEN.StockActualExistencia = SaldoRN.ObtenerStock(xSal, iCodigoMesAnterior);
                iExiEncEN.PrecioPromedioExistencia = SaldoRN.ObtenerPrecioPromedio(xSal, iCodigoMesAnterior);

                //variables que acumulan ingreso y egresos en este saldo
                decimal iIngresoAcumulado = 0;
                decimal iSalidaAcumulado = 0;

                //obtener la lista de SolicitudPedidos deta de esta existencia
                List<SolicitudPedidoDetaEN> iLisMovDetExi = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXExistencia(iExiEncEN, iLisLisMovDetExi);

                //recorrer cada objeto SolicitudPedido deta de la existencia
                foreach (SolicitudPedidoDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del SolicitudPedido deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio


                    //ahora pasamos el nuevo stock y precio promedio a la existencia


                    //vamos acumulando los ingresos o salidas en el objeto saldo(iSalEncEN)
                    iIngresoAcumulado += SolicitudPedidoDetaRN.ObtenerCantidadIngresada(xMovDet);
                    iSalidaAcumulado += SolicitudPedidoDetaRN.ObtenerCantidadSalida(xMovDet);

                    //adicionamos el SolicitudPedidoDeta a la lista que va a modificar a los SolicitudPedidosDeta
                    iLisMovDetMod.Add(xMovDet);
                }

                //adicionamos la existencia a la lista que va a modificar las existencias
                iLisExiMod.Add(iExiEncEN);

                //actualizamos al objeto saldo con sus datos finales
                SaldoRN.ModificarStock(xSal, pCodigoMes, iExiEncEN.StockActualExistencia);
                SaldoRN.ModificarPrecioPromedio(xSal, pCodigoMes, iExiEncEN.PrecioPromedioExistencia);
                SaldoRN.ModificarIngresos(xSal, pCodigoMes, iIngresoAcumulado);
                SaldoRN.ModificarSalidas(xSal, pCodigoMes, iSalidaAcumulado);

                //adicionamos a la lista de saldos que se van a modificar en b.d
                iLisSalMod.Add(xSal);
            }

            //modificar SolicitudPedidodeta masivo
            SolicitudPedidoDetaRN.ModificarSolicitudPedidoDetaParaRecalculo(iLisMovDetMod);

            //modificar saldos masivo
            SaldoRN.ModificarSaldoParaRecalculo(iLisSalMod);

            //modificar existencia masivo
            ExistenciaRN.ModificarExistenciaPorRecalculo(iLisExiMod);
        }

        public static decimal ObtenerCantidadIngresada(SolicitudPedidoDetaEN pMovDet)
        {
            //valor resultado
            decimal iCantidad = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iCantidad = pMovDet.CantidadSolicitudPedidoDeta;
            }
            else
            {
                //salida
                iCantidad = 0;
            }

            //devolver
            return iCantidad;
        }

        public static decimal ObtenerCantidadSalida(SolicitudPedidoDetaEN pMovDet)
        {
            //valor resultado
            decimal iCantidad = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iCantidad = 0;
            }
            else
            {
                //salida
                iCantidad = pMovDet.CantidadSolicitudPedidoDeta;
            }

            //devolver
            return iCantidad;
        }

        public static decimal ObtenerPrecioUnitarioPorRecalculo(SolicitudPedidoDetaEN pMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            if (pMovDet.CCalculaPrecioPromedio == "0")//no
            {
                //iValor = pMovDet.PrecioAnteriorExistencia;
            }
            else
            {
                //iValor = pMovDet.PrecioUnitarioSolicitudPedidoDeta;
            }

            //devolver
            return iValor;
        }

        public static SolicitudPedidoDetaEN TransformarASolicitudPedidoDeta(ProduccionExisEN pProExi, SolicitudPedidoCabeEN pMovCab, ExistenciaEN pExi,
            ParametroEN pPar)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //pasamos datos
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = pProExi.CorrelativoProduccionExis;
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pPar.CentroCostoProduccion;
            iMovDetEN.CodigoExistencia = pProExi.CodigoExistencia;
            iMovDetEN.CodigoUnidadMedida = pProExi.CodigoUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProExi.CantidadProduccionExis;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> TransformarASolicitudPedidosDeta(List<ProduccionExisEN> pLisProExi, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiEmp);

                //creamos un objeto SolicitudPedidoDeta desde xProExi
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.TransformarASolicitudPedidoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static void AdicionarSolicitudPedidoDetaPorSalidaInsumos(List<ProduccionExisEN> pLisProExi, SolicitudPedidoCabeEN pMovCab)
        {
            //actualizar la clase de operacion
            //pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a SolicitudPedidoDeta
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.TransformarASolicitudPedidosDeta(pLisProExi, pMovCab);

            //adicionar masivo
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDet);
        }

        public static List<ExistenciaEN> ListarExistenciasActualizadasPorEliminacionSolicitudPedidosDeta(List<SolicitudPedidoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a las existencias que estan referenciadas en esta lista pLisMovDet
            List<ExistenciaEN> iLisExiMovDet = SolicitudPedidoDetaRN.ListarExistenciasReferenciadasEnSolicitudPedidosDeta(pLisMovDet);

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = SolicitudPedidoDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiMovDet);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = SolicitudPedidoDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = SolicitudPedidoDetaRN.ObtenerNuevoStockPorEliminacion(xMovDet, iExiEN);

                //agregamos a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerNuevoStockPorEliminacion(SolicitudPedidoDetaEN pMovDet, ExistenciaEN pExi)
        {
            //valor resultado
            decimal iStock = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iStock = pExi.StockActualExistencia - pMovDet.CantidadSolicitudPedidoDeta;
            }
            else
            {
                //salida
                iStock = pExi.StockActualExistencia + pMovDet.CantidadSolicitudPedidoDeta;
            }

            //devolver
            return iStock;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoMercaderia(ProduccionProTerEN pProProTer, SolicitudPedidoCabeEN pMovCab,
            ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionProTerRN.ObtenerClaveExistencia(pProProTer);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = Cadena.CompletarCadena(pProProTer.CorrelativoProduccionProTer, 4, "0", Cadena.Direccion.Izquierda);
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProProTer.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = pProProTer.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = pProProTer.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = pProProTer.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProProTer.CantidadUnidadesRealEncajado;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoMercaderia(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar a los ProduccionProTer con numero de cajas
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXProduccionDetaYConNumeroCajas(pProDet);

            //variables
            string iCorrelativo = "0000";

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear  objeto para esta lista
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoMercaderia(xProProTer, pMovCab, iCenCosEN);

                //aumentamos el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo, 4);

                //actualizar el objeto SolicitudPedidoDeta
                iMovDetEN.CorrelativoSolicitudPedidoDeta = iCorrelativo;
                iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaPorClaveSolicitudPedidoCabe(string pClaveSolicitudPedidoCabe)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveSolicitudPedidoCabe = pClaveSolicitudPedidoCabe;
            iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(iMovDetEN);
        }

        public static void EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(string pClaveSolicitudPedidoCabe)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveSolicitudPedidoCabe = pClaveSolicitudPedidoCabe;

            //ejecutar metodo
            SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iMovDetEN);
        }

        public static decimal ObtenerStockAnteriorExistenciaPorDigitacion(ExistenciaEN pExiBD, SolicitudPedidoDetaEN pMovDetGrilla, Universal.Opera pOperacionVentana)
        {
            //valor resultado
            decimal iValor = 0;

            //si no hay existencia, entonces devuelve cero
            if (pExiBD.CodigoExistencia == string.Empty) { return iValor; }

            //si la operacion es adicionar, entonces devuelve el dato del objeto existencia de bd
            if (pOperacionVentana == Universal.Opera.Adicionar) { return pExiBD.StockActualExistencia; }

            //si los codigos son iguales , entonces devuelve el dato del objeto SolicitudPedidoDeta de la grilla
            //if (pExiBD.CodigoExistencia == pMovDetGrilla.CodigoExistencia) { return pMovDetGrilla.StockAnteriorExistencia; }

            //aqui retorna el valor de la b.d
            return pExiBD.StockActualExistencia;
        }

        public static decimal ObtenerPrecioAnteriorExistenciaPorDigitacion(ExistenciaEN pExiBD, SolicitudPedidoDetaEN pMovDetGrilla, Universal.Opera pOperacionVentana)
        {
            //valor resultado
            decimal iValor = 0;

            //si no hay existencia, entonces devuelve cero
            if (pExiBD.CodigoExistencia == string.Empty) { return iValor; }

            //si la operacion es adicionar, entonces devuelve el dato del objeto existencia de bd
            if (pOperacionVentana == Universal.Opera.Adicionar) { return pExiBD.PrecioPromedioExistencia; }

            //si los codigos son iguales , entonces devuelve el dato del objeto SolicitudPedidoDeta de la grilla
            //if (pExiBD.CodigoExistencia == pMovDetGrilla.CodigoExistencia) { return pMovDetGrilla.PrecioAnteriorExistencia; }

            //aqui retorna el valor de la b.d
            return pExiBD.PrecioPromedioExistencia;
        }

        public static List<KardexValorizado> ObtenerReporteKardexValorizado(string pAño, string pCodigoMes, string pCodigoAlmacen,
            string pCTipoExistencia, string pCodigoExistenciaDesde, string pCodigoExistenciaHasta)
        {
            //lista resultado
            List<KardexValorizado> iLisRes = new List<KardexValorizado>();

            //traer todo el SolicitudPedido deta del periodo para el kardex           
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDetKar = SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaKardex(pAño, pCodigoMes,
                pCodigoAlmacen, pCTipoExistencia, pCodigoExistenciaDesde, pCodigoExistenciaHasta);

            //traer todos los saldos del año que tiene el periodo elegido para el kardex
            List<SaldoEN> iLisSalKar = SaldoRN.ListarSaldosParaKardex(pAño, pCodigoAlmacen, pCTipoExistencia, pCodigoExistenciaDesde,
                pCodigoExistenciaHasta);

            //le bajamos una unidad al codigoMes,este codigo sirve para obtener el stock y precio anterior
            //al mes que se esta procesando
            string iCodigoMesAnterior = Numero.DisminuirCorrelativoNumerico(pCodigoMes);

            //recorrer cada objeto saldo
            foreach (SaldoEN xSal in iLisSalKar)
            {
                //validar si este saldo debe salir en el kardex
                bool iSalMosKar = SaldoRN.EsSaldoMostrableEnKardex(xSal, pCodigoMes, iCodigoMesAnterior);
                if (iSalMosKar == false) { continue; }

                //traer los SolicitudPedidos Deta para esta existencia
                List<SolicitudPedidoDetaEN> iLisMovDetExi = SolicitudPedidoDetaRN.ObtenerListaDeSolicitudPedidosDetaDeExistencia(xSal.CodigoExistencia, iLisLisMovDetKar);

                //armar la lista de KardexValorizados, que se pueden obtener del objeto saldo y su lista SolicitudPedidosDeta
                List<KardexValorizado> iLisKarValSal = SolicitudPedidoDetaRN.ArmarListaKardexValorizadoDeSaldoYSolicitudPedidosDeta(xSal, pCodigoMes,
                    iCodigoMesAnterior, iLisMovDetExi);

                //agregamos a la lista resultado
                iLisRes.AddRange(iLisKarValSal);
            }

            //retornar
            return iLisRes;
        }

        public static List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaKardex(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarListasDeSolicitudPedidoDetasParaKardex(pObj);
        }

        public static List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaKardex(string pAño, string pCodigoMes, string pCodigoAlmacen,
            string pCTipoExistencia, string pCodigoExistenciaDesde, string pCodigoExistenciaHasta)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.PeriodoSolicitudPedidoCabe = pAño + "-" + pCodigoMes;
            iMovDetEN.CodigoAlmacen = pCodigoAlmacen;
            iMovDetEN.CodigoTipo = pCTipoExistencia;
            iMovDetEN.Adicionales.Desde1 = pCodigoExistenciaDesde;
            iMovDetEN.Adicionales.Hasta1 = pCodigoExistenciaHasta;

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaKardex(iMovDetEN);
        }

        public static List<SolicitudPedidoDetaEN> ObtenerListaDeSolicitudPedidosDetaDeExistencia(string pCodigoExistencia, List<List<SolicitudPedidoDetaEN>> pLisLisMovDetAlm)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //buscar la lista que contiene el codigo de existencia, ¡solo vienen listas de SolicitudPedidos
            //de existencias de un almacen especifico!

            //recorrer cada objeto
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in pLisLisMovDetAlm)
            {
                if (pCodigoExistencia == xLisMovDet[0].CodigoExistencia)
                {
                    iLisRes = xLisMovDet;
                    return iLisRes;
                }
            }

            //aqui no encontro la lista, entonces devuleve lista vacia
            return iLisRes;
        }

        public static List<KardexValorizado> ArmarListaKardexValorizadoDeSaldoYSolicitudPedidosDeta(SaldoEN pSal, string pCodigoMesProceso, string pCodigoMesAnterior, List<SolicitudPedidoDetaEN> pLisMovDetExi)
        {
            //lista resultado
            List<KardexValorizado> iLisRes = new List<KardexValorizado>();

            //si la lista esta vacia, entonces armamos un KardexValorizado solo con el objeto saldo
            if (pLisMovDetExi.Count == 0)
            {
                KardexValorizado iKarVal = SaldoRN.ArmarKardexValorizadoDeSoloSaldo(pSal, pCodigoMesProceso, pCodigoMesAnterior);
                iLisRes.Add(iKarVal);
            }
            else
            {
                //aqui hay SolicitudPedidos deta para la existencia que esta en el objeto saldo
                //recorrer cada objeto
                foreach (SolicitudPedidoDetaEN xMovDet in pLisMovDetExi)
                {
                    //obtener el KardexValorizado completo
                    KardexValorizado iKarVal = SolicitudPedidoDetaRN.ArmarKardexValorizadoDeSaldoYSolicitudPedidoDeta(pSal, pCodigoMesProceso,
                        pCodigoMesAnterior, xMovDet);

                    //agregamos a la lista resultado
                    iLisRes.Add(iKarVal);
                }
            }

            //devolver
            return iLisRes;
        }

        public static KardexValorizado ArmarKardexValorizadoDeSaldoYSolicitudPedidoDeta(SaldoEN iSal, string pCodigoMesProceso,
            string pCodigoMesAnterior, SolicitudPedidoDetaEN pMovDet)
        {
            //objeto resultado
            //pasamos primero los datos que tendra del objeto saldo
            KardexValorizado iKarVal = SaldoRN.ArmarKardexValorizadoDeSoloSaldo(iSal, pCodigoMesProceso, pCodigoMesAnterior);

            //actualizamos los totales por existencia
            iKarVal.CantidadActual = SaldoRN.ObtenerStock(iSal, pCodigoMesProceso);
            iKarVal.PrecioActual = SaldoRN.ObtenerPrecioPromedio(iSal, pCodigoMesProceso);
            iKarVal.TotalActual = iKarVal.CantidadActual * iKarVal.PrecioActual;

            //ahora completamos los datos del KardexValorizado con el objeto SolicitudPedidoDeta
            //iKarVal.FechaSolicitudPedidoCabe = pMovDet.FechaSolicitudPedidoCabe;
            iKarVal.CTipoDocumento = pMovDet.CTipoDocumento;
            iKarVal.SerieDocumento = pMovDet.SerieDocumento;
            iKarVal.NumeroDocumento = pMovDet.NumeroDocumento;
            iKarVal.CodigoTipoOperacion = pMovDet.CodigoTipoOperacion;
            //iKarVal.NumeroSolicitudPedidoCabe = pMovDet.NumeroSolicitudPedidoCabe;
            iKarVal.CodigoUnidadMedida1 = pMovDet.CodigoUnidadMedida;

            //segun tipo de SolicitudPedido
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iKarVal.CClaseTipoOperacion = "I";
                iKarVal.CantidadIngreso = pMovDet.CantidadSolicitudPedidoDeta;
                //iKarVal.PrecioIngreso = pMovDet.PrecioUnitarioSolicitudPedidoDeta;
                iKarVal.TotalIngreso = iKarVal.CantidadIngreso * iKarVal.PrecioIngreso;
            }
            else
            {
                iKarVal.CClaseTipoOperacion = "S";
                iKarVal.CantidadSalida = pMovDet.CantidadSolicitudPedidoDeta;
                //iKarVal.PrecioSalida = pMovDet.PrecioUnitarioSolicitudPedidoDeta;
                iKarVal.TotalSalida = iKarVal.CantidadSalida * iKarVal.PrecioSalida;
            }

            //completamos los saldos
            //iKarVal.CantidadSaldo = pMovDet.StockExistencia;
            //iKarVal.PrecioSaldo = pMovDet.PrecioExistencia;
            iKarVal.TotalSaldo = iKarVal.CantidadSaldo * iKarVal.PrecioSaldo;

            //devolver
            return iKarVal;
        }

        public static List<KardexFisico> ObtenerReporteKardexFisico(string pAño, string pCodigoMes, string pCodigoAlmacen,
           string pCTipoExistencia, string pCodigoExistenciaDesde, string pCodigoExistenciaHasta)
        {
            //lista resultado
            List<KardexFisico> iLisRes = new List<KardexFisico>();

            //traer todos los saldos del año que tiene el periodo elegido para el kardex
            List<SaldoEN> iLisSalKar = SaldoRN.ListarSaldosParaKardex(pAño, pCodigoAlmacen, pCTipoExistencia, pCodigoExistenciaDesde,
                pCodigoExistenciaHasta);

            //le bajamos una unidad al codigoMes,este codigo sirve para obtener el stock y precio anterior
            //al mes que se esta procesando
            string iCodigoMesAnterior = Numero.DisminuirCorrelativoNumerico(pCodigoMes);

            //recorrer cada objeto saldo
            foreach (SaldoEN xSal in iLisSalKar)
            {
                //validar si este saldo debe salir en el kardex
                bool iSalMosKar = SaldoRN.EsSaldoMostrableEnKardex(xSal, pCodigoMes, iCodigoMesAnterior);
                if (iSalMosKar == false) { continue; }

                //armar KardexFisico que se pueden obtener del objeto saldo
                KardexFisico iKarFis = SaldoRN.ArmarKardexFisicoDeSaldo(xSal, pCodigoMes, iCodigoMesAnterior);

                //agregamos a la lista resultado
                iLisRes.Add(iKarFis);
            }

            //retornar
            return iLisRes;
        }

        public static decimal ObtenerTotalKardexValorizado(List<KardexValorizado> pLisKarVal)
        {
            //valor resultado
            decimal iTotal = 0;

            //existencia
            string iCodigoExistencia = string.Empty;

            //recorrer cada objeto
            foreach (KardexValorizado xKarVal in pLisKarVal)
            {
                //si la existencia es diferente entonces se acumula su totalActual
                if (xKarVal.CodigoExistencia != iCodigoExistencia)
                {
                    iTotal += xKarVal.TotalActual;
                    iCodigoExistencia = xKarVal.CodigoExistencia;
                }
            }

            //devolver
            return iTotal;
        }

        public static SolicitudPedidoDetaEN HayStockSuficiente(SolicitudPedidoDetaEN pMovDet)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //validar
            //el objeto pMovDet contiene el stock antual de la existencia y tambien la cantidad
            //que se quiere sacar del almacen
            //if (pMovDet.CantidadSolicitudPedidoDeta > pMovDet.StockAnteriorExistencia)
            //{
            //    iMovDetEN.Adicionales.EsVerdad = false;
            //    iMovDetEN.Adicionales.Mensaje = "No hay stock suficiente, stock de la existencia = ";
            //    iMovDetEN.Adicionales.Mensaje += Formato.NumeroDecimal(pMovDet.StockAnteriorExistencia, 5);
            //}

            //ok
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN ArmarASolicitudPedidoDeta(InventarioDetaEN pInvDet, SolicitudPedidoCabeEN pMovCab, ExistenciaEN pExi,
         ParametroEN pPar, string pCorrelativoDeta)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //pasamos datos
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = pCorrelativoDeta;
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = string.Empty;//xxxxxxxxxxxx
            iMovDetEN.CodigoExistencia = pInvDet.CodigoExistencia;
            iMovDetEN.CodigoUnidadMedida = pInvDet.CodigoUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = Math.Abs(pInvDet.DiferenciaStock);
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ArmarASolicitudPedidosDeta(List<InventarioDetaEN> pLisInvDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //correlativo deta
            string iCorrelativoDeta = "0000";

            //recorrer cada objeto
            foreach (InventarioDetaEN xInvDet in pLisInvDet)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = InventarioDetaRN.ObtenerClaveExistencia(xInvDet);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiEmp);

                //aumentar el correlativo
                iCorrelativoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoDeta);

                //creamos un objeto SolicitudPedidoDeta desde xProExi
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.ArmarASolicitudPedidoDeta(xInvDet, pMovCab, iExiEncEN, iParEN, iCorrelativoDeta);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaDocumentosEmitidos(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarListasDeSolicitudPedidoDetasParaDocumentosEmitidos(pObj);
        }

        public static List<SolicitudPedidoDetaEN> ObtenerReporteDocumentosEmitidosResumen(SolicitudPedidoDetaEN pObj)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer la lista de listas de SolicitudPedidosDeta para este reporte
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDet = SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaDocumentosEmitidos(pObj);

            //recorrer cada lista
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //creamos un nuevo objeto para el reporte
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.ArmarSolicitudPedidoDetaParaDocumentoEmitidoResumen(xLisMovDet);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN ArmarSolicitudPedidoDetaParaDocumentoEmitidoResumen(List<SolicitudPedidoDetaEN> pLisMovDetExi)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //pasamos datos
            iMovDetEN.CodigoTipo = pLisMovDetExi[0].CodigoTipo;
            iMovDetEN.NombreTipo = pLisMovDetExi[0].NombreTipo;
            iMovDetEN.CodigoExistencia = pLisMovDetExi[0].CodigoExistencia;
            iMovDetEN.DescripcionExistencia = pLisMovDetExi[0].DescripcionExistencia;

            //obtenemos los valores acumulados(Cantidad y costo)
            SolicitudPedidoDetaRN.AcumularCamposNumericos(iMovDetEN, pLisMovDetExi);

            //obtener el precio promedio para este objeto
            //iMovDetEN.PrecioExistencia = Operador.DivisionDecimal(iMovDetEN.CostoSolicitudPedidoDeta, iMovDetEN.CantidadSolicitudPedidoDeta);
            //iMovDetEN.PrecioExistencia = Math.Round(iMovDetEN.PrecioExistencia, 2);

            //devolver
            return iMovDetEN;
        }

        public static void AcumularCamposNumericos(SolicitudPedidoDetaEN pObj, List<SolicitudPedidoDetaEN> pLista)
        {
            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLista)
            {
                //acumulamos solo los campos numericos de este objeto
                pObj.CantidadSolicitudPedidoDeta += xMovDet.CantidadSolicitudPedidoDeta;
                //pObj.PrecioUnitarioSolicitudPedidoDeta += xMovDet.PrecioUnitarioSolicitudPedidoDeta;
                //pObj.CostoSolicitudPedidoDeta += xMovDet.CostoSolicitudPedidoDeta;
                //pObj.StockAnteriorExistencia += xMovDet.StockAnteriorExistencia;
                //pObj.PrecioAnteriorExistencia += xMovDet.PrecioAnteriorExistencia;
                //pObj.PrecioExistencia += xMovDet.PrecioExistencia;
                //pObj.StockExistencia += xMovDet.StockExistencia;
            }
        }

        public static List<SolicitudPedidoDetaEN> ObtenerReporteDocumentosEmitidosDetalle(SolicitudPedidoDetaEN pObj)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer la lista de listas de SolicitudPedidosDeta para este reporte
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDet = SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaDocumentosEmitidos(pObj);

            //recorrer cada lista
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //adicionamos a la lista resultado
                iLisRes.AddRange(xLisMovDet);
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ObtenerReporteRecordsExistencia(SolicitudPedidoDetaEN pObj)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer la lista de listas de SolicitudPedidosDeta para este reporte
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDet = SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaRecordsExistencia(pObj);

            //recorrer cada lista
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //creamos un nuevo objeto para el reporte
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.ArmarSolicitudPedidoDetaParaRecordsExistencia(xLisMovDet);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //ordenar de mayor a menor cantidad      
            iLisRes.Sort((x, y) => y.CantidadSolicitudPedidoDeta.CompareTo(x.CantidadSolicitudPedidoDeta));

            //devolver
            return iLisRes;
        }

        public static List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaRecordsExistencia(SolicitudPedidoDetaEN pObj)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.CodigoTipoOperacion = string.Empty;
            iMovDetEN.Adicionales.Desde1 = pObj.Adicionales.Desde1;
            iMovDetEN.Adicionales.Hasta1 = pObj.Adicionales.Hasta1;
            iMovDetEN.CodigoAlmacen = pObj.CodigoAlmacen;

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaDocumentosEmitidos(iMovDetEN);
        }

        public static SolicitudPedidoDetaEN ArmarSolicitudPedidoDetaParaRecordsExistencia(List<SolicitudPedidoDetaEN> pLisMovDetExi)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //pasamos datos            
            iMovDetEN.CodigoExistencia = pLisMovDetExi[0].CodigoExistencia;
            iMovDetEN.DescripcionExistencia = pLisMovDetExi[0].DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = pLisMovDetExi[0].CodigoUnidadMedida;

            //obtenemos los valores acumulados(Cantidad y costo)
            SolicitudPedidoDetaRN.AcumularCamposNumericos(iMovDetEN, pLisMovDetExi);

            //obtener el precio promedio para este objeto
            //iMovDetEN.PrecioExistencia = Operador.DivisionDecimal(iMovDetEN.CostoSolicitudPedidoDeta, iMovDetEN.CantidadSolicitudPedidoDeta);
            //iMovDetEN.PrecioExistencia = Math.Round(iMovDetEN.PrecioExistencia, 2);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaParaSalidasXCeCoDetalle(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidosDetaParaSalidasXCeCoDetalle(pObj);
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaParaControlSolicitudPedidosISDetalle(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidosDetaParaControlSolicitudPedidosISDetalle(pObj);
        }

        public static void EliminarSolicitudPedidoDetaXPeriodoYOrigen(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.EliminarSolicitudPedidoDetaXPeriodoYOrigen(pObj);
        }

        public static void EliminarSolicitudPedidosDetaDeImportacion(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iMovCabEN = new SolicitudPedidoCabeEN();
            iMovCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXPeriodoYOrigen(iMovCabEN);
        }

        public static void EliminarSolicitudPedidoDetaXPeriodoXOrigenYClase(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.EliminarSolicitudPedidoDetaXPeriodoXOrigenYClase(pObj);
        }

        public static void EliminarSolicitudPedidosDetaDeImportacionIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iMovCabEN = new SolicitudPedidoCabeEN();
            iMovCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            //iMovCabEN.CClaseTipoOperacion = "1";//ingreso
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static void EliminarSolicitudPedidosDetaDeImportacionSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iMovCabEN = new SolicitudPedidoCabeEN();
            iMovCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            //iMovCabEN.CClaseTipoOperacion = "2";//salida
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXExistencia(ExistenciaEN pObj, List<List<SolicitudPedidoDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //recorrer cada objeto
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in pLisLisMovDet)
            {
                if (pObj.CodigoAlmacen + pObj.CodigoExistencia == xLisMovDet[0].CodigoAlmacen + xLisMovDet[0].CodigoExistencia)
                {
                    return xLisMovDet;
                }
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerPrecioUnitarioProductoDeProduccion(ProduccionDetaEN pProDet)
        {
            //valor resultado
            decimal iValor = 0;

            //--------
            //calcular
            //--------
            //obtener los insumos para esta orden de trabajo
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDeta(pProDet.ClaveProduccionDeta);

            //traer a todos las existencias de la empresa actual
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistencias();

            //recorrer cada insumo
            foreach (ProduccionExisEN xProExi in iLisProExi)
            {
                //buscar a la existencia
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExi);

                //operando
                iValor += xProExi.CantidadProduccionExis * iExiEN.PrecioPromedioExistencia;
            }

            //dividir entre la cantidad de productos
            iValor = Operador.DivisionDecimal(iValor, pProDet.CantidadProduccionDeta);

            //devolver
            return iValor;
        }

        public static List<SolicitudPedidoDetaEN> FiltrarSolicitudPedidoDeta(List<SolicitudPedidoDetaEN> pLista, string pCampoFiltro, string pValorFiltro)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorFiltro.ToUpper();

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xPer in pLista)
            {
                string iTexto = SolicitudPedidoDetaRN.ObtenerValorDeCampo(xPer, pCampoFiltro).ToUpper();
                if (iTexto == iValor)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string CadenaCodigosExistenciasParaIN(List<SolicitudPedidoDetaEN> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLista)
            {
                iValor += "'" + xMovDet.CodigoExistencia.Replace("'", "''") + "',";
            }

            //valida cuando esta vacio
            if (iValor == string.Empty) { return "''"; }

            //aqui si hay codigos, entonces cortamos a la ultima coma
            iValor = iValor.Remove(iValor.Length - 1);

            //devolver
            return iValor;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaEmpaquetar(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pProDet);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.NumeroUnidadesConCal - pProDet.NumeroUnidadesSueltas;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaEmpaquetar(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaEmpaquetar(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoSemiElaborado(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pProDet);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.CantidadEncajonar;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoSemiElaborado(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoSemiElaborado(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerPrecioUnitarioSemiElaboradoDeProduccion(ProduccionDetaEN pProDet)
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

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionDeta(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidosDetaXClaveProduccionDeta(pObj);
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionDeta(string pClaveProduccionDeta)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveProduccionDeta(iMovDetEN);
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionDeta(ProduccionDetaEN pObj)
        {
            //asignar parametros          
            string iClaveProduccionDeta = pObj.ClaveProduccionDeta;

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveProduccionDeta(iClaveProduccionDeta);
        }

        public static bool EsActoDigitarPrecioUnitarioConversion(SolicitudPedidoDetaEN pObj)
        {
            //valor resultado
            bool iValor = true;

            //validar
            if (pObj.CCalculaPrecioPromedio == "0")
            {
                iValor = false;
            }
            else
            {
                if (pObj.CConversionUnidad == "1" && pObj.CEsUnidadConvertida == "1")
                {
                    iValor = true;
                }
                else
                {
                    iValor = false;
                }
            }

            //devolver
            return iValor;
        }

        public static bool EsActoDigitarPrecioUnitario(SolicitudPedidoDetaEN pObj)
        {
            //valor resultado
            bool iValor = true;

            //validar
            if (pObj.CCalculaPrecioPromedio == "0")
            {
                iValor = false;
            }
            else
            {
                if (pObj.CConversionUnidad == "1" && pObj.CEsUnidadConvertida == "1")
                {
                    iValor = false;
                }
                else
                {
                    iValor = true;
                }
            }

            //devolver
            return iValor;
        }

        public static bool EsActoDigitarCantidadConversion(SolicitudPedidoDetaEN pObj)
        {
            //valor resultado
            bool iValor = true;

            //validar
            if (pObj.CEsLote == "1")
            {
                iValor = false;
            }
            else
            {
                if (pObj.CConversionUnidad == "1" && pObj.CEsUnidadConvertida == "1")
                {
                    iValor = true;
                }
                else
                {
                    iValor = false;
                }
            }

            //devolver
            return iValor;
        }

        public static bool EsActoDigitarCantidad(SolicitudPedidoDetaEN pObj)
        {
            //valor resultado
            bool iValor = true;

            //validar
            if (pObj.CEsLote == "1")
            {
                iValor = false;
            }
            else
            {
                if (pObj.CConversionUnidad == "1" && pObj.CEsUnidadConvertida == "1")
                {
                    iValor = false;
                }
                else
                {
                    iValor = true;
                }
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerPrecioUnitarioConvertidoSugerido(SolicitudPedidoDetaEN pObj)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = SolicitudPedidoDetaRN.EsActoDigitarPrecioUnitarioConversion(pObj);

            //obtener el valor
            if (iEsDigitable == false)
            {
                ivalor = 0;
            }
            else
            {
                //ivalor = pObj.PrecioUnitarioConversion;
            }

            //devolver
            return ivalor;
        }

        public static decimal ObtenerPrecioUnitarioSugerido(SolicitudPedidoDetaEN pMocDet)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = SolicitudPedidoDetaRN.EsActoDigitarPrecioUnitario(pMocDet);

            //obtener el valor
            if (pMocDet.CCalculaPrecioPromedio == "0")//no
            {
                //ivalor = pMocDet.PrecioAnteriorExistencia;
            }
            else
            {
                if (iEsDigitable == false)
                {
                    //ivalor = Operador.DivisionDecimal(pMocDet.PrecioUnitarioConversion, pMocDet.FactorConversion);
                }
                else
                {
                    //ivalor = pMocDet.PrecioUnitarioSolicitudPedidoDeta;
                }
            }

            //devolver
            return ivalor;
        }

        public static decimal ObtenerCantidadConvertidoSugerido(SolicitudPedidoDetaEN pObj)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = SolicitudPedidoDetaRN.EsActoDigitarCantidadConversion(pObj);

            //obtener el valor
            if (iEsDigitable == false)
            {
                ivalor = 0;
            }
            else
            {
                ivalor = pObj.CantidadConversion;
            }

            //devolver
            return ivalor;
        }

        public static decimal ObtenerCantidadSugerido(SolicitudPedidoDetaEN pMocDet, List<LoteEN> pLisLotExi)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = SolicitudPedidoDetaRN.EsActoDigitarCantidad(pMocDet);

            //obtener el valor
            if (iEsDigitable == false)
            {
                //si esta existencia tiene lotes registrados, entonces se devuelve
                //el mismo valor que tiene 
                if (pLisLotExi.Count != 0)
                {
                    ivalor = pMocDet.CantidadSolicitudPedidoDeta;
                }
                else
                {
                    ivalor = pMocDet.CantidadConversion * pMocDet.FactorConversion;
                }
            }
            else
            {
                ivalor = pMocDet.CantidadSolicitudPedidoDeta;
            }

            //devolver
            return ivalor;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaNoPasan(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pProDet);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.NumeroUnidadesNoPasanConCal;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaNoPasan(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaNoPasan(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaUnidadesReproceso(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pProDet);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.UnidadesReproceso;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaUnidadesReproceso(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaUnidadesReproceso(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobrante(SolicitudPedidoDetaEN pObj, string pCodigoAlmacenIngresoTransferencia)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //validar
            //listar las existencias que estan separadas con las cantidades de unidades que le sobran
            //List<ExistenciaEN> iLisExiSob = ExistenciaRN.ListarExistenciasSobrantes(pObj, pCodigoAlmacenIngresoTransferencia);

            //validando
            //iMovDetEN = SolicitudPedidoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, iLisExiSob);

            //ok
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN EsCantidadSolicitudPedidoDetaCorrecta(SolicitudPedidoDetaEN pObj)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadSolicitudPedidoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            SolicitudPedidoDetaEN iMovDetStoEN = SolicitudPedidoDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de compras para produccion           
            if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            //valida cuando la cantidad a sacar es mayor a las permitidas
            SolicitudPedidoDetaEN iMovDetCanSacEN = SolicitudPedidoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, string.Empty);
            if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN EsCantidadTransferenciaSolicitudPedidoDetaCorrecta(SolicitudPedidoDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadSolicitudPedidoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            SolicitudPedidoDetaEN iMovDetStoEN = SolicitudPedidoDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de compras para produccion           
            if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            //valida cuando la existencia no es almacen de produccion           
            if (FormulaDetaRN.EsAlmacenDeProduccion(pCodigoAlmacenProduccion) == false) { return iMovDetEN; }

            //valida cuando la cantidad a transferir es diferente a lo que pide la produccion actual
            SolicitudPedidoDetaEN iMovDetCanDifEN = SolicitudPedidoDetaRN.ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(pObj,
                pCodigoAlmacenProduccion);
            if (iMovDetCanDifEN.Adicionales.EsVerdad == false) { return iMovDetCanDifEN; }

            //valida cuando la cantidad a sacar es mayor a las permitidas
            SolicitudPedidoDetaEN iMovDetCanSacEN = SolicitudPedidoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj,
                pCodigoAlmacenProduccion);
            if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN EsCantidadTransferenciaSolicitudPedidoDetaCorrectaNew(SolicitudPedidoDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadSolicitudPedidoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            SolicitudPedidoDetaEN iMovDetStoEN = SolicitudPedidoDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            ////valida cuando la existencia no es almacen de compras para produccion           
            //if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            ////valida cuando la existencia no es almacen de produccion           
            //if (FormulaDetaRN.EsAlmacenDeProduccion(pCodigoAlmacenProduccion) == false) { return iMovDetEN; }

            ////valida cuando la cantidad a transferir es diferente a lo que pide la produccion actual
            //SolicitudPedidoDetaEN iMovDetCanDifEN = SolicitudPedidoDetaRN.ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(pObj,
            //    pCodigoAlmacenProduccion);
            //if (iMovDetCanDifEN.Adicionales.EsVerdad == false) { return iMovDetCanDifEN; }

            ////valida cuando la cantidad a sacar es mayor a las permitidas
            //SolicitudPedidoDetaEN iMovDetCanSacEN = SolicitudPedidoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj,
            //    pCodigoAlmacenProduccion);
            //if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(SolicitudPedidoDetaEN pObj,
             string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //validar
            //obtener la cantidad que se necesita para produccion(solo partes de trabajo)
            //decimal iCantidadProduccion = ProduccionExisRN.ObtenerCantidadNecesariaParaProducir(pObj, pCodigoAlmacenProduccion);

            //si hay cantidad produccion
            //if (iCantidadProduccion != 0 && iCantidadProduccion != pObj.CantidadSolicitudPedidoDeta)
            //{
            //    iMovDetEN.Adicionales.EsVerdad = false;
            //    iMovDetEN.Adicionales.Mensaje = "Te falta transferir de almacen de produccion a cocina la cantidad de:" + iCantidadProduccion.ToString();
            //}

            //ok
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN EsCantidadAdicionalSolicitudPedidoDetaCorrecta(SolicitudPedidoDetaEN pObj)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadSolicitudPedidoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            SolicitudPedidoDetaEN iMovDetStoEN = SolicitudPedidoDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de produccion           
            if (FormulaDetaRN.EsAlmacenDeProduccion(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            //valida cuando la cantidad a sacar es mayor a las permitidas
            SolicitudPedidoDetaEN iMovDetCanSacEN = SolicitudPedidoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj);
            if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobrante(SolicitudPedidoDetaEN pObj)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //validar
            //listar las existencias que estan separadas con las cantidades de unidades que le sobran
            //List<ExistenciaEN> iLisExiSob = ExistenciaRN.ListarExistenciasSobrantes(pObj);

            //validando
            //iMovDetEN = SolicitudPedidoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, iLisExiSob);

            //ok
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobrante(SolicitudPedidoDetaEN pObj,
            List<ExistenciaEN> pListaExistenciasSobrantes)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //validar           
            //buscar la existencia del SolicitudPedido en la lista de existencias sobrantes
            ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(pListaExistenciasSobrantes, ExistenciaEN.CodExi, pObj.CodigoExistencia);

            //si lo encontro
            if (iExiBusEN.CodigoExistencia != string.Empty)
            {
                //chequear si la cantidad digitada es menor que las que sobran
                if (pObj.CantidadSolicitudPedidoDeta > iExiBusEN.StockActualExistencia)
                {
                    iMovDetEN.Adicionales.EsVerdad = false;
                    iMovDetEN.Adicionales.Mensaje = "Esta cantidad no se puede sacar del almacen,";
                    iMovDetEN.Adicionales.Mensaje += " porque estan reservadas para produccion. ";
                    if (iExiBusEN.StockActualExistencia != 0)
                    {
                        iMovDetEN.Adicionales.Mensaje += "Solo estan disponibles " + iExiBusEN.StockActualExistencia.ToString();
                    }
                }
            }

            //ok
            return iMovDetEN;
        }

        public static List<List<SolicitudPedidoDetaEN>> ListarListasSolicitudPedidosDetaParaImportar(List<SolicitudPedidoDetaEN> pLista)
        {
            //asignar parametros
            List<string> iLisCam = new List<string>();
            iLisCam.Add(SolicitudPedidoDetaEN.FecMovCab);
            iLisCam.Add(SolicitudPedidoDetaEN.OrdCom);
            iLisCam.Add(SolicitudPedidoDetaEN.CodAlm);

            //ejecutar metodo
            return ListaG.ListarListas<SolicitudPedidoDetaEN>(pLista, iLisCam);
        }

        public static decimal ObtenerPrecioUnitarioConvertido(SolicitudPedidoDetaEN pObj, decimal pPrecioUnitarioImportadoExcel)
        {
            //asignar parametros
            //pObj.PrecioUnitarioConversion = pPrecioUnitarioImportadoExcel;

            //ejecutar metodo
            return ObtenerPrecioUnitarioConvertidoSugerido(pObj);
        }

        public static decimal ObtenerPrecioUnitario(SolicitudPedidoDetaEN pObj, decimal pPrecioUnitarioImportadoExcel)
        {
            //asignar parametros
            //pObj.PrecioUnitarioSolicitudPedidoDeta = pPrecioUnitarioImportadoExcel;

            //ejecutar metodo
            return ObtenerPrecioUnitarioSugerido(pObj);
        }

        public static decimal ObtenerCantidadConvertido(SolicitudPedidoDetaEN pObj, decimal pCantidadImportadoExcel)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = ObjetoG.Clonar<SolicitudPedidoDetaEN>(pObj);
            iMovDetEN.CEsLote = "0";
            iMovDetEN.CantidadConversion = pCantidadImportadoExcel;

            //ejecutar metodo
            return ObtenerCantidadConvertidoSugerido(iMovDetEN);
        }

        public static decimal ObtenerCantidad(SolicitudPedidoDetaEN pObj, decimal pCantidadImportadoExcel)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = ObjetoG.Clonar<SolicitudPedidoDetaEN>(pObj);
            iMovDetEN.CEsLote = "0";
            iMovDetEN.CantidadSolicitudPedidoDeta = pCantidadImportadoExcel;
            List<LoteEN> iLisLot = new List<LoteEN>();

            //ejecutar metodo
            return ObtenerCantidadSugerido(iMovDetEN, iLisLot);
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoUnidadesReproceso(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesParaReproceso;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoUnidadesReproceso(LiberacionEN pLib,
            SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesReproceso(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaEmpaquetar(ProduccionProTerEN pProProTer, SolicitudPedidoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.ObtenerExistenciaSemiElaborado(pProProTer);

            //obtener la cantidad a sacar pero solo del almacen de productos en proceso
            decimal iCantidadASacar = LiberacionRN.ObtenerCantidadSoloDeProductosEnProceso(pProProTer);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = Cadena.CompletarCadena(pProProTer.CorrelativoProduccionProTer, 4, "0", Cadena.Direccion.Izquierda);
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = iCantidadASacar;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaEmpaquetar(EncajadoEN pEnc, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaEmpaquetar(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadSolicitudPedidoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoMercaderia(EncajadoEN pEnc, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar a los ProduccionProTer con numero de cajas
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //si es de eleccion "reingreso unidades totales" entonces pasa al siguiente objeto
                if (xProProTer.CEleccionSegundaLiberacion == "2") { continue; }

                //crear  objeto para esta lista
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoMercaderia(xProProTer, pMovCab, iCenCosEN);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaParaSaldosXExistencia(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidosDetaParaSaldosXExistencia(pObj);
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoUnidadesDonacion(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesParaDonacion;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoUnidadesDonacion(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesDonacion(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoUnidadesDesechos(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesDesechas;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoUnidadesDesechas(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesDesechos(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void Recalcular(string pAño, string pCodigoMes, List<ExistenciaEN> pLisExi, List<SaldoEN> pLisSal,
            List<List<SolicitudPedidoDetaEN>> pLisLisMovDet)
        {
            //ponemos los datos a cero en el mes de proceso
            SaldoRN.PonerCerosEnPeriodo(pCodigoMes, pLisSal);

            //le bajamos una unidad al codigoMes,este codigo sirve para obtener el stock y precio anterior
            //al mes que se esta procesando
            string iCodigoMesAnterior = Numero.DisminuirCorrelativoNumerico(pCodigoMes);

            //recorrer cada objeto saldo
            foreach (SaldoEN xSal in pLisSal)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = SaldoRN.ObtenerClaveExistencia(xSal);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //obtener el stock y precio promedio anterior a este mes de proceso,(punto de inicio)
                iExiEncEN.StockActualExistencia = SaldoRN.ObtenerStock(xSal, iCodigoMesAnterior);
                iExiEncEN.PrecioPromedioExistencia = SaldoRN.ObtenerPrecioPromedio(xSal, iCodigoMesAnterior);

                //variables que acumulan ingreso y egresos en este saldo
                decimal iIngresoAcumulado = 0;
                decimal iSalidaAcumulado = 0;

                //obtener la lista de SolicitudPedidos deta de esta existencia
                List<SolicitudPedidoDetaEN> iLisMovDetExi = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXExistencia(iExiEncEN, pLisLisMovDet);

                //recorrer cada objeto SolicitudPedido deta de la existencia
                foreach (SolicitudPedidoDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del SolicitudPedido deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio
                    //xMovDet.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    //xMovDet.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;
                    //xMovDet.PrecioUnitarioSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerPrecioUnitarioPorRecalculo(xMovDet);
                    //xMovDet.CostoSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerCosto(xMovDet);
                    //xMovDet.StockExistencia = SolicitudPedidoDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    //xMovDet.PrecioExistencia = SolicitudPedidoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

                    //ahora pasamos el nuevo stock y precio promedio a la existencia
                    //iExiEncEN.StockActualExistencia = xMovDet.StockExistencia;
                    //iExiEncEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;

                    //vamos acumulando los ingresos o salidas en el objeto saldo(iSalEncEN)
                    iIngresoAcumulado += SolicitudPedidoDetaRN.ObtenerCantidadIngresada(xMovDet);
                    iSalidaAcumulado += SolicitudPedidoDetaRN.ObtenerCantidadSalida(xMovDet);

                }

                //modificar el cambio en existencia
                ListaG.Modificar<ExistenciaEN>(pLisExi, iExiEncEN, ExistenciaEN.ClaExi, iExiEncEN.ClaveExistencia);

                //actualizamos al objeto saldo con sus datos finales
                SaldoRN.ModificarStock(xSal, pCodigoMes, iExiEncEN.StockActualExistencia);
                SaldoRN.ModificarPrecioPromedio(xSal, pCodigoMes, iExiEncEN.PrecioPromedioExistencia);
                SaldoRN.ModificarIngresos(xSal, pCodigoMes, iIngresoAcumulado);
                SaldoRN.ModificarSalidas(xSal, pCodigoMes, iSalidaAcumulado);
            }
        }

        public static List<List<SolicitudPedidoDetaEN>> FiltrarPorFechaMenorOIgualQue(List<List<SolicitudPedidoDetaEN>> pLisLis, string pFechaCompara)
        {
            //lista resultado
            List<List<SolicitudPedidoDetaEN>> iLisRes = new List<List<SolicitudPedidoDetaEN>>();

            //recorrer cada lista
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in pLisLis)
            {
                //creamos la nueva lista filtrada
                List<SolicitudPedidoDetaEN> iLisMovDet = new List<SolicitudPedidoDetaEN>();

                //recorrer cada objeto
                foreach (SolicitudPedidoDetaEN xMovDet in xLisMovDet)
                {
                    //comparacion
                    if (Fecha.EsMayorQue(xMovDet.FechaSolicitudPedidoCabe, pFechaCompara) == true) { break; }

                    //agregar a la lista
                    iLisMovDet.Add(xMovDet);
                }

                //si la lista esta vacia, no avanza el proceso
                if (iLisMovDet.Count == 0) { continue; }

                //agregamos a la lista resultado
                iLisRes.Add(iLisMovDet);
            }

            //devolver
            return iLisRes;
        }

        public static void EliminarSolicitudPedidoDetaXPeriodoYAlmacen(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.EliminarSolicitudPedidoDetaXPeriodoYAlmacen(pObj);
        }

        public static void EliminarSolicitudPedidosDetaAlmacenProduccionParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            iMovDetEN.CodigoAlmacen = "A10";//almacen de produccion

            //ejecutar metodo
            SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXPeriodoYAlmacen(iMovDetEN);
        }

        public static void EliminarSolicitudPedidoDetaAlmacenesCompraParaRegenerar(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            iPerAD.EliminarSolicitudPedidoDetaAlmacenesCompraParaRegenerar(pObj);
        }

        public static void EliminarSolicitudPedidosDetaAlmacenesCompraParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;

            //ejecutar metodo
            SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaAlmacenesCompraParaRegenerar(iMovDetEN);
        }

        public static void ExistenciasActualizadasPorAdicionSolicitudPedidosDeta(List<SolicitudPedidoDetaEN> pLisMovDet, List<ExistenciaEN> pLisExi)
        {
            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = SolicitudPedidoDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = SolicitudPedidoDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = SolicitudPedidoDetaRN.ObtenerNuevoStockPorAdicion(iExiEN, xMovDet);

                //modificar el cambio en existencia
                ListaG.Modificar<ExistenciaEN>(pLisExi, iExiEN, ExistenciaEN.ClaExi, iExiEN.ClaveExistencia);
            }
        }

        public static List<List<SolicitudPedidoDetaEN>> ListaListasSolicitudPedidosDetaPorFechaMenorOIgualQue(string pCodigoPeriodo, string pfechaCompara)
        {
            //traer todo el SolicitudPedido deta del periodo elegido, para el recalculo          
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDetExi = SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaRecalculo(pCodigoPeriodo);

            return SolicitudPedidoDetaRN.FiltrarPorFechaMenorOIgualQue(iLisLisMovDetExi, pfechaCompara);
        }

        public static List<SolicitudPedidoDetaEN> TransformarASolicitudPedidosDeta(List<ProduccionExisEN> pLisProExi, SolicitudPedidoCabeEN pMovCab, List<ExistenciaEN> pLisExi)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //creamos un objeto SolicitudPedidoDeta desde xProExi
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.TransformarASolicitudPedidoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static void AdicionarSolicitudPedidoDetaPorSalidaInsumos(List<ProduccionExisEN> pLisProExi, SolicitudPedidoCabeEN pMovCab, List<ExistenciaEN> pLisExi)
        {
            //actualizar clase operacion
            //pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a SolicitudPedidoDeta
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.TransformarASolicitudPedidosDeta(pLisProExi, pMovCab, pLisExi);

            //adicionar masivo
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDet);
        }

        public static List<SolicitudPedidoDetaEN> ObtenerSolicitudPedidoDetaRecalculada(string pAño, string pCodigoMes, List<ExistenciaEN> pLisExi, List<SaldoEN> pLisSal,
           List<List<SolicitudPedidoDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //ponemos los datos a cero en el mes de proceso
            SaldoRN.PonerCerosEnPeriodo(pCodigoMes, pLisSal);

            //le bajamos una unidad al codigoMes,este codigo sirve para obtener el stock y precio anterior
            //al mes que se esta procesando
            string iCodigoMesAnterior = Numero.DisminuirCorrelativoNumerico(pCodigoMes);

            //recorrer cada objeto saldo
            foreach (SaldoEN xSal in pLisSal)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = SaldoRN.ObtenerClaveExistencia(xSal);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //obtener el stock y precio promedio anterior a este mes de proceso,(punto de inicio)
                iExiEncEN.StockActualExistencia = SaldoRN.ObtenerStock(xSal, iCodigoMesAnterior);
                iExiEncEN.PrecioPromedioExistencia = SaldoRN.ObtenerPrecioPromedio(xSal, iCodigoMesAnterior);

                //obtener la lista de SolicitudPedidos deta de esta existencia
                List<SolicitudPedidoDetaEN> iLisMovDetExi = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXExistencia(iExiEncEN, pLisLisMovDet);

                //recorrer cada objeto SolicitudPedido deta de la existencia
                foreach (SolicitudPedidoDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del SolicitudPedido deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio
                    //xMovDet.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    //xMovDet.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;
                    //xMovDet.PrecioUnitarioSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerPrecioUnitarioPorRecalculo(xMovDet);
                    //xMovDet.CostoSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerCosto(xMovDet);
                    //xMovDet.StockExistencia = SolicitudPedidoDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    //xMovDet.PrecioExistencia = SolicitudPedidoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

                    //ahora pasamos el nuevo stock y precio promedio a la existencia
                    //iExiEncEN.StockActualExistencia = xMovDet.StockExistencia;
                    //iExiEncEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;

                    //agregar a la lista resultado
                    iLisRes.Add(xMovDet);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ObtenerSolicitudPedidoDetaRecalculada(string pAño, string pCodigoMes)
        {
            //asignar parametros
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();
            List<SaldoEN> iLisSalAño = SaldoRN.ListarSaldosDeAño(pAño);
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDetExi = SolicitudPedidoDetaRN.ListarListasDeSolicitudPedidoDetasParaRecalculo(pAño, pCodigoMes);

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ObtenerSolicitudPedidoDetaRecalculada(pAño, pCodigoMes, iLisExiEmp, iLisSalAño, iLisLisMovDetExi);
        }

        public static List<List<SolicitudPedidoDetaEN>> ListarListasSolicitudPedidosDetaReprocesoParaRecalculo(List<SolicitudPedidoDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<SolicitudPedidoDetaEN> iLisMovDet = ListaG.Filtrar<SolicitudPedidoDetaEN>(pLisMovDet, SolicitudPedidoDetaEN.CodAlm, "A18");//solo almacen reproceso(A18)
            List<string> iLisCamposClave = new List<string>() { SolicitudPedidoDetaEN.CodExi, SolicitudPedidoDetaEN.FecMovCab };

            //ejecutar metodo
            return ListaG.ListarListas<SolicitudPedidoDetaEN>(iLisMovDet, iLisCamposClave);
        }

        public static decimal ObtenerPrecioUnitarioPorRecalculoReproceso(SolicitudPedidoDetaEN pMovDet, List<LiberacionEN> pLisLib)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            if (pMovDet.CClaseTipoOperacion == "1")//SolicitudPedido ingreso
            {
                //buscar a la liberacion que provoco este ingreso
                LiberacionEN iLibEN = ListaG.Buscar<LiberacionEN>(pLisLib, LiberacionEN.ClaIngTraRep, pMovDet.ClaveSolicitudPedidoCabe);

                //pasamos el dato
                iValor = iLibEN.CostoTotalProducto;
            }
            else
            {
                iValor = SolicitudPedidoDetaRN.ObtenerPrecioUnitarioPorRecalculo(pMovDet);
            }

            //devolver
            return iValor;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXPeriodo(string pCodigoPeriodo)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidosDetaXPeriodo(pCodigoPeriodo);
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaEmpaquetarRE(RetiquetadoEN pRet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pRet.CodigoAlmacenPT, pRet.CodigoExistenciaPT);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CEsLote = iExiEN.CEsLote;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pRet.CantidadUnidadesRetiquetado;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaEmpaquetarRE(RetiquetadoEN pRet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaEmpaquetarRE(pRet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoMercaderiaRE(RetiquetadoEN pRet, SolicitudPedidoCabeEN pMovCab, ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pRet.CodigoAlmacenRE, pRet.CodigoExistenciaRE);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pRet.CantidadUnidadesRetiquetado;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoMercaderiaRE(RetiquetadoEN pRet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoMercaderiaRE(pRet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void AdicionarSolicitudPedidoDetaPorIngresoInsumos(List<ProduccionExisEN> pLisProExi, SolicitudPedidoCabeEN pMovCab)
        {
            //actualizar clase operacion
            //pMovCab.CClaseTipoOperacion = "1";//ingreso

            //transformar la lista de ProduccionExis a SolicitudPedidoDeta
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.TransformarASolicitudPedidosDetaDesmedro(pLisProExi, pMovCab);

            //adicionar masivo
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDet);
        }

        public static List<SolicitudPedidoDetaEN> TransformarASolicitudPedidosDetaDesmedro(List<ProduccionExisEN> pLisProExi, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = ExistenciaRN.ObtenerClaveExistencia("A21", xProExi.CodigoExistencia);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiEmp);

                //actualizando dato
                xProExi.CantidadProduccionExis = xProExi.CantidadDesmedro;

                //creamos un objeto SolicitudPedidoDeta desde xProExi
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.TransformarASolicitudPedidoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoUnidadesMuestra(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            ////iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            ////iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesParaMuestra;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoUnidadesMuestra(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesMuestra(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerPrecioUnitarioConFlete(SolicitudPedidoDetaEN pObj, decimal pCostoFleteUnitario)
        {
            //valor resultado
            //decimal iValor = pObj.PrecioUnitarioSolicitudPedidoDeta;
            decimal iValor = 0;
            //primero restamos el flete unitario anterior
            //iValor -= pObj.CostoFleteSolicitudPedidoDeta;

            //agregamos el nuevo flete
            //iValor += pCostoFleteUnitario;

            //devolver
            return iValor;
        }

        public static decimal ObtenerPrecioUnitarioSinFlete(SolicitudPedidoDetaEN pObj)
        {
            //valor resultado
            //decimal iValor = pObj.PrecioUnitarioSolicitudPedidoDeta;
            decimal iValor = 0;
            //primero restamos el flete unitario anterior
            //iValor -= pObj.CostoFleteSolicitudPedidoDeta;

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoSinFlete(SolicitudPedidoDetaEN pObj)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            //iMovDetEN.PrecioUnitarioSolicitudPedidoDeta = ObtenerPrecioUnitarioSinFlete(pObj);
            iMovDetEN.CantidadSolicitudPedidoDeta = pObj.CantidadSolicitudPedidoDeta;

            //ejecutar metodo
            return ObtenerCosto(iMovDetEN);
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaParaActualizarCostosProduccionExis(List<ProduccionExisEN> pLisProExi, List<List<SolicitudPedidoDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //recorrer cada objeto ProduccionExis
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la lista de la existencia de compras para este xProExi
                List<SolicitudPedidoDetaEN> iLisMovDetExi = ListaG.Buscar<SolicitudPedidoDetaEN>(pLisLisMovDet, SolicitudPedidoDetaEN.CodAlm, xProExi.CodigoAlmacenCompra,
                    SolicitudPedidoDetaEN.CodExi, xProExi.CodigoExistencia);

                //lista de SolicitudPedidos a lo mas iguales a la fecha de produccionDeta
                SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

                //recorrer cada objeto
                foreach (SolicitudPedidoDetaEN xMovDet in iLisMovDetExi)
                {
                    if (Fecha.EsMayorOIgualQue(xProExi.FechaProduccionDeta, xMovDet.FechaSolicitudPedidoCabe) == true)
                    {
                        iMovDetEN = xMovDet;
                    }
                    else
                    {
                        break;
                    }
                }

                //agregar a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoSemElaObservadas(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A22", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = pProDet.DescripcionSemiProducto;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.CantidadBloquear;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoSemElaMuestraProduccion(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A20", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = pProDet.DescripcionSemiProducto;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.CantidadMuestraProduccion;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoSemElaContraMuestra(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A20", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = pProDet.DescripcionSemiProducto;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.CantidadContraMuestra;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoSemElaObservadas(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoSemElaObservadas(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoSemElaMuestraProduccion(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoSemElaMuestraProduccion(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoSemElaContraMuestra(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoSemElaContraMuestra(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaEmpaquetarObservado(ProduccionProTerEN pProProTer, SolicitudPedidoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //obtener la formulaDeta al cual pertenece este ProTer
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A22", iForDetEN.CodigoSemiProducto);

            //obtener la cantidad a sacar pero solo del almacen de productos en proceso
            decimal iCantidadASacar = LiberacionRN.ObtenerCantidadSoloDeObservados(pProProTer);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = Cadena.CompletarCadena(pProProTer.CorrelativoProduccionProTer, 4, "0", Cadena.Direccion.Izquierda);
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = iCantidadASacar;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaEmpaquetarObservados(EncajadoEN pEnc, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaEmpaquetarObservado(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadSolicitudPedidoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoUnidadesObservados(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesObservadas;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoUnidadesSaldo(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesSaldo;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoUnidadesObservados(LiberacionEN pLib,
            SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesObservados(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoUnidadesSaldo(LiberacionEN pLib,
           SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesSaldo(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionProTer(string pClaveProduccionProTer)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveProduccionProTer = pClaveProduccionProTer;
            iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveProduccionProTer(iMovDetEN);
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionProTer(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidosDetaXClaveProduccionProTer(pObj);
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoCuarentenaQali(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A23", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.CantidadCuarentenaQali;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoCuarentenaQali(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoCuarentenaQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoReprocesoQali(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A18", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.CantidadReprocesoQali;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoMuestraQali(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A20", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.CantidadMuestraQali;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoReprocesoQali(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoReprocesoQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoMuestraQali(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoMuestraQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoDesechoQali(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A14", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProDet.CantidadDesechoQali;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoDesechoQali(ProduccionDetaEN pProDet, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoDesechoQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaEmpaquetarCuarentena(ProduccionProTerEN pProProTer, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //obtener la formulaDeta al cual pertenece este ProTer
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A23", iForDetEN.CodigoSemiProducto);

            //obtener la cantidad a sacar pero solo del almacen de productos en proceso
            decimal iCantidadASacar = LiberacionRN.ObtenerCantidadSoloDeCuarentena(pProProTer);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = Cadena.CompletarCadena(pProProTer.CorrelativoProduccionProTer, 4, "0", Cadena.Direccion.Izquierda);
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = iCantidadASacar;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaEmpaquetarCuarentena(EncajadoEN pEnc, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaEmpaquetarCuarentena(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadSolicitudPedidoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaSalidasAdicionalesProduccionProTer(string pClaveProduccionProTer)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer todos los SolicitudPedidos deta de esta ProduccionProTer de bd
            iLisRes = ListarSolicitudPedidosDetaXClaveProduccionProTer(pClaveProduccionProTer);

            //filtrar que solo sean salidas y almacen "A11"
            iLisRes = ListaG.Filtrar<SolicitudPedidoDetaEN>(iLisRes, SolicitudPedidoDetaEN.CClaTipOpe, "2", SolicitudPedidoDetaEN.CodAlm, "A11");

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionProTerParteEmpaquetado(string pClaveProduccionProTerParteEmpaquetado)
        {
            //asignar parametros
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveProduccionProTerParteEmpaquetado = pClaveProduccionProTerParteEmpaquetado;
            iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;

            //ejecutar metodo
            return SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveProduccionProTerParteEmpaquetado(iMovDetEN);
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionProTerParteEmpaquetado(SolicitudPedidoDetaEN pObj)
        {
            SolicitudPedidoDetaAD iPerAD = new SolicitudPedidoDetaAD();
            return iPerAD.ListarSolicitudPedidosDetaXClaveProduccionProTerParteEmpaquetado(pObj);
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaTransferenciaUnidadesReproceso(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = LiberacionRN.ObtenerClaveExistenciaSemiProducto(pLib);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesParaReproceso;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaTransferenciaUnidadesReproceso(LiberacionEN pLib,
            SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaTransferenciaUnidadesReproceso(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaTransferenciaUnidadesDonacion(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = LiberacionRN.ObtenerClaveExistenciaSemiProducto(pLib);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesParaDonacion;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaTransferenciaUnidadesDonacion(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaTransferenciaUnidadesDonacion(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaTransferenciaUnidadesDesecha(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = LiberacionRN.ObtenerClaveExistenciaSemiProducto(pLib);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesDesechas;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaTransferenciaUnidadesDesechas(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaTransferenciaUnidadesDesecha(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaSalidaTransferenciaUnidadesPacking(LiberacionEN pLib, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = LiberacionRN.ObtenerClaveExistenciaSemiProducto(pLib);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pLib.UnidadesPasan;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaSalidaTransferenciaUnidadesPacking(LiberacionEN pLib,
            SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaTransferenciaUnidadesPacking(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void AdicionarSolicitudPedidoDetaPorSalidaEtiquetaSegundaLiberacion(List<ProduccionExisEN> pLisProExi, SolicitudPedidoCabeEN pMovCab)
        {
            //actualizar clase operacion
            //pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a SolicitudPedidoDeta
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.TransformarASolicitudPedidosDetaSalidaEtiquetaSegundaLiberacion(pLisProExi, pMovCab);

            //adicionar masivo
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDet);
        }

        public static List<SolicitudPedidoDetaEN> TransformarASolicitudPedidosDetaSalidaEtiquetaSegundaLiberacion(List<ProduccionExisEN> pLisProExi, SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(pMovCab.CodigoAlmacen, xProExi.CodigoExistencia);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiEmp);

                //actualizando dato
                xProExi.CantidadProduccionExis = xProExi.CantidadSegundaLiberacion;

                //creamos un objeto SolicitudPedidoDeta desde xProExi
                SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.TransformarASolicitudPedidoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetaParaIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pProProTer,
           SolicitudPedidoCabeEN pMovCab)
        {
            //lista resultado
            List<SolicitudPedidoDetaEN> iLisRes = new List<SolicitudPedidoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesSegundaLiberacion(pProProTer, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static SolicitudPedidoDetaEN CrearSolicitudPedidoDetaParaIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pProProTer, SolicitudPedidoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer).CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoSolicitudPedidoDeta = "0001";
            iMovDetEN.FechaSolicitudPedidoCabe = pMovCab.FechaSolicitudPedidoCabe;
            iMovDetEN.PeriodoSolicitudPedidoCabe = pMovCab.PeriodoSolicitudPedidoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            //iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            //iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroSolicitudPedidoCabe = pMovCab.NumeroSolicitudPedidoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadSolicitudPedidoDeta = pProProTer.CantidadUnidadesRealEncajado;
            iMovDetEN.ClaveSolicitudPedidoCabe = pMovCab.ClaveSolicitudPedidoCabe;
            iMovDetEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

    }
}
