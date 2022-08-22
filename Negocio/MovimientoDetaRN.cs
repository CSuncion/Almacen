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
    public class MovimientoDetaRN
    {

        public static MovimientoDetaEN EnBlanco()
        {
            MovimientoDetaEN iExiEN = new MovimientoDetaEN();
            return iExiEN;
        }

        public static void AdicionarMovimientoDeta(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.AgregarMovimientoDeta(pObj);
        }

        public static void AdicionarMovimientoDeta(List<MovimientoDetaEN> pLista)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.AgregarMovimientoDeta(pLista);
        }

        public static void ModificarMovimientoDeta(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.ModificarMovimientoDeta(pObj);
        }

        public static void ModificarMovimientoDeta(List<MovimientoDetaEN> pLista)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.ModificarMovimientoDeta(pLista);
        }

        public static void ModificarMovimientoDetaParaRecalculo(List<MovimientoDetaEN> pLista)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.ModificarMovimientoDetaParaRecalculo(pLista);
        }

        public static void EliminarMovimientoDeta(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.EliminarMovimientoDeta(pObj);
        }

        public static void EliminarMovimientoDetaXMovimientoCabe(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.EliminarMovimientoDetaXMovimientoCabe(pObj);
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetas(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientoDetas(pObj);
        }

        public static MovimientoDetaEN BuscarMovimientoDetaXClave(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.BuscarMovimientoDetaXClave(pObj);
        }

        public static MovimientoDetaEN EsMovimientoDetaExistente(MovimientoDetaEN pObj)
        {
            //objeto resultado
            MovimientoDetaEN iExiEN = new MovimientoDetaEN();

            //validar si existe en b.d
            iExiEN = MovimientoDetaRN.BuscarMovimientoDetaXClave(pObj);
            if (iExiEN.ClaveMovimientoDeta == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "La MovimientoDeta " + pObj.ClaveMovimientoDeta + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(MovimientoDetaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case MovimientoDetaEN.ClaObj: return pObj.ClaveObjeto;
                case MovimientoDetaEN.ClaMovDet: return pObj.ClaveMovimientoDeta;
                case MovimientoDetaEN.ClaMovCab: return pObj.ClaveMovimientoCabe;
                case MovimientoDetaEN.CorMovDet: return pObj.CorrelativoMovimientoDeta;
                case MovimientoDetaEN.CodEmp: return pObj.CodigoEmpresa;
                case MovimientoDetaEN.NomEmp: return pObj.NombreEmpresa;
                case MovimientoDetaEN.FecMovCab: return pObj.FechaMovimientoCabe;
                case MovimientoDetaEN.PerMovCab: return pObj.PeriodoMovimientoCabe;
                case MovimientoDetaEN.CodAlm: return pObj.CodigoAlmacen;
                case MovimientoDetaEN.DesAlm: return pObj.DescripcionAlmacen;
                case MovimientoDetaEN.CodTipOpe: return pObj.CodigoTipoOperacion;
                case MovimientoDetaEN.DesTipOpe: return pObj.DescripcionTipoOperacion;
                case MovimientoDetaEN.CClaTipOpe: return pObj.CClaseTipoOperacion;
                case MovimientoDetaEN.CCalPrePro: return pObj.CCalculaPrecioPromedio;
                case MovimientoDetaEN.NumMovCab: return pObj.NumeroMovimientoCabe;
                case MovimientoDetaEN.CodAux: return pObj.CodigoAuxiliar;
                case MovimientoDetaEN.DesAux: return pObj.DescripcionAuxiliar;
                case MovimientoDetaEN.CTipDoc: return pObj.CTipoDocumento;
                case MovimientoDetaEN.NTipDoc: return pObj.NTipoDocumento;
                case MovimientoDetaEN.SerDoc: return pObj.SerieDocumento;
                case MovimientoDetaEN.NumDoc: return pObj.NumeroDocumento;
                case MovimientoDetaEN.FecDoc: return pObj.FechaDocumento;
                case MovimientoDetaEN.CodCenCos: return pObj.CodigoCentroCosto;
                case MovimientoDetaEN.DesCenCos: return pObj.DescripcionCentroCosto;
                case MovimientoDetaEN.CodExi: return pObj.CodigoExistencia;
                case MovimientoDetaEN.DesExi: return pObj.DescripcionExistencia;
                case MovimientoDetaEN.CodTip: return pObj.CodigoTipo;
                case MovimientoDetaEN.NomTip: return pObj.NombreTipo;
                case MovimientoDetaEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case MovimientoDetaEN.NomUniMed: return pObj.NombreUnidadMedida;
                case MovimientoDetaEN.CanMovDet: return pObj.CantidadMovimientoDeta.ToString();
                case MovimientoDetaEN.PreUniMovDet: return pObj.PrecioUnitarioMovimientoDeta.ToString();
                case MovimientoDetaEN.CosMovDet: return pObj.CostoMovimientoDeta.ToString();
                case MovimientoDetaEN.GloMovDet: return pObj.GlosaMovimientoDeta;
                case MovimientoDetaEN.StoAntExi: return pObj.StockAnteriorExistencia.ToString();
                case MovimientoDetaEN.PreAntExi: return pObj.PrecioAnteriorExistencia.ToString();
                case MovimientoDetaEN.StoExi: return pObj.StockExistencia.ToString();
                case MovimientoDetaEN.PreExi: return pObj.PrecioExistencia.ToString();
                case MovimientoDetaEN.CEstMovDet: return pObj.CEstadoMovimientoDeta;
                case MovimientoDetaEN.NEstMovDet: return pObj.NEstadoMovimientoDeta;
                case MovimientoDetaEN.UsuAgr: return pObj.UsuarioAgrega;
                case MovimientoDetaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case MovimientoDetaEN.UsuMod: return pObj.UsuarioModifica;
                case MovimientoDetaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<MovimientoDetaEN> FiltrarMovimientoDetasXTextoEnCualquierPosicion(List<MovimientoDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (MovimientoDetaEN xPer in pLista)
            {
                string iTexto = MovimientoDetaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<MovimientoDetaEN> pListaMovimientoDetas)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaMovimientoDetas; }

            //filtar la lista
            iLisRes = MovimientoDetaRN.FiltrarMovimientoDetasXTextoEnCualquierPosicion(pListaMovimientoDetas, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveMovimientoDeta(MovimientoDetaEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave            
            iClave += pPer.ClaveMovimientoCabe + "-";
            iClave += pPer.CorrelativoMovimientoDeta;

            //retornar
            return iClave;
        }

        public static MovimientoDetaEN EsActoEliminarMovimientoDeta(MovimientoDetaEN pPer)
        {
            //objeto resultado
            MovimientoDetaEN iExiEN = new MovimientoDetaEN();

            //validar si existe
            iExiEN = MovimientoDetaRN.EsMovimientoDetaExistente(pPer);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }


            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void AdicionarMovimientoDeta(List<MovimientoDetaEN> pLis, MovimientoDetaEN pObj)
        {
            //obtener siguiente correlativo
            pObj.CorrelativoMovimientoDeta = MovimientoDetaRN.ObtenerSiguienteCorrelativo(pLis);
            pObj.ClaveObjeto = MovimientoDetaRN.ObtenerClaveMovimientoDeta(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<MovimientoDetaEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "0000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoMovimientoDeta;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static decimal ObtenerCosto(MovimientoDetaEN pObj)
        {
            decimal iImporte = 0, iIgv = 0;

            ExistenciaEN oExi = new ExistenciaEN();
            oExi = ExistenciaRN.BuscarExistencia(pObj.CodigoAlmacen, pObj.CodigoExistencia);

            //variables
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            iIgv = oExi.CAfectoIgv == "0" ? Convert.ToDecimal(0) : (iParEN.PorcentajeIgv / 100);

            //valor resultado


            //calcular
            iImporte = pObj.PrecioUnitarioMovimientoDeta * pObj.CantidadMovimientoDeta;

            //retornar
            return iImporte - (iImporte * iIgv);
        }

        public static List<MovimientoDetaEN> RefrescarListaMovimientoDeta(List<MovimientoDetaEN> pLis)
        {
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();
            foreach (MovimientoDetaEN xMovDet in pLis)
            {
                iLisRes.Add(xMovDet);
            }
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXClaveMovimientoCabe(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaXClaveMovimientoCabe(pObj);
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
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
                // si pCodigoExistenciaAModificar esta vacio, quiere decir que se esta agregando un nuevo MovimientoDeta
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

        public static decimal ObtenerNuevoStockPorAdicion(MovimientoDetaEN pMovDet)
        {
            //valor resultado
            decimal iStock = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iStock = pMovDet.StockAnteriorExistencia + pMovDet.CantidadMovimientoDeta;
            }
            else
            {
                //salida
                iStock = pMovDet.StockAnteriorExistencia - pMovDet.CantidadMovimientoDeta;
            }

            //devolver
            return iStock;
        }

        public static decimal ObtenerNuevoPrecioPromedio(MovimientoDetaEN pMovDet)
        {
            //valor resultado
            decimal iPrecio = 0;

            //calcula
            if (pMovDet.CCalculaPrecioPromedio == "0")//no
            {
                iPrecio = pMovDet.PrecioAnteriorExistencia;
            }
            else
            {
                //si calcula precio promedio
                decimal iDividendo = (pMovDet.StockAnteriorExistencia * pMovDet.PrecioAnteriorExistencia) + (pMovDet.CantidadMovimientoDeta * pMovDet.PrecioUnitarioMovimientoDeta);
                decimal iDivisor = pMovDet.StockAnteriorExistencia + pMovDet.CantidadMovimientoDeta;
                iPrecio = Operador.DivisionDecimal(iDividendo, iDivisor);
                //MessageBox.Show(iPrecio.ToString(), "Ver");
            }

            //devolver
            return iPrecio;
        }

        public static List<ExistenciaEN> ListarExistenciasReferenciadasEnMovimientosDeta(List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(xMovDet);

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

        public static string ObtenerClaveExistencia(MovimientoDetaEN pObj)
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

        public static List<ExistenciaEN> ListarExistenciasActualizadasPorAdicionMovimientosDeta(List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a las existencias que estan referenciadas en esta lista pLisMovDet
            List<ExistenciaEN> iLisExiMovDet = MovimientoDetaRN.ListarExistenciasReferenciadasEnMovimientosDeta(pLisMovDet);

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiMovDet);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iExiEN, xMovDet);

                //agregamos a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerNuevoPrecioPromedio(ExistenciaEN pExi, MovimientoDetaEN pMovDet)
        {
            //valor resultado
            decimal iPrecio = 0;

            //actualizar los datos del movimientoDeta
            pMovDet.PrecioAnteriorExistencia = pExi.PrecioPromedioExistencia;
            pMovDet.StockAnteriorExistencia = pExi.StockActualExistencia;

            //calcula
            iPrecio = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(pMovDet);

            //devolver
            return iPrecio;
        }

        public static decimal ObtenerNuevoStockPorAdicion(ExistenciaEN pExi, MovimientoDetaEN pMovDet)
        {
            //valor resultado
            decimal iStock = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iStock = pExi.StockActualExistencia + pMovDet.CantidadMovimientoDeta;
            }
            else
            {
                //salida
                iStock = pExi.StockActualExistencia - pMovDet.CantidadMovimientoDeta;
            }

            //devolver
            return iStock;
        }

        public static MovimientoDetaEN BuscarMovimientoDeta(string pCampo, string pValor, List<MovimientoDetaEN> pLista)
        {
            //objeto resultaddo
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLista)
            {
                if (MovimientoDetaRN.ObtenerValorDeCampo(xMovDet, pCampo) == pValor)
                {
                    return xMovDet;
                }
            }

            //devolver
            return iMovDetEN;
        }

        public static List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaRecalculo(string pCodigoPeriodo)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarListasDeMovimientoDetasParaRecalculo(pCodigoPeriodo);
        }

        public static List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaRecalculo(string pAño, string pCodigoMes)
        {
            //asignar parametros
            string iCodigoPeriodo = Formato.UnionDosTextos(pAño, pCodigoMes, "-");

            //ejecutar metodo
            return MovimientoDetaRN.ListarListasDeMovimientoDetasParaRecalculo(iCodigoPeriodo);
        }

        public static void Recalcular(string pAño, string pCodigoMes)
        {
            //traer todo el movimiento deta del periodo elegido, para el recalculo
            string iCodigoPeriodo = pAño + "-" + pCodigoMes;
            List<List<MovimientoDetaEN>> iLisLisMovDetExi = MovimientoDetaRN.ListarListasDeMovimientoDetasParaRecalculo(iCodigoPeriodo);

            //traer todos los saldos del año que tiene el periodo elegido
            List<SaldoEN> iLisSalAño = SaldoRN.ListarSaldosDeAño(pAño);

            //le bajamos una unidad al codigoMes,este codigo sirve para obtener el stock y precio anterior
            //al mes que se esta procesando
            string iCodigoMesAnterior = Numero.DisminuirCorrelativoNumerico(pCodigoMes);

            //listas para grabar
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();
            List<MovimientoDetaEN> iLisMovDetMod = new List<MovimientoDetaEN>();
            List<SaldoEN> iLisSalMod = new List<SaldoEN>();

            //recorrer cada lista de movimiento deta de existencia
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

                //obtener la lista de movimientos deta de esta existencia
                List<MovimientoDetaEN> iLisMovDetExi = MovimientoDetaRN.ListarMovimientosDetaXExistencia(iExiEncEN, iLisLisMovDetExi);

                //recorrer cada objeto movimiento deta de la existencia
                foreach (MovimientoDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del movimiento deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio
                    xMovDet.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    xMovDet.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;
                    xMovDet.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(xMovDet);
                    xMovDet.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(xMovDet);
                    xMovDet.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    xMovDet.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

                    //ahora pasamos el nuevo stock y precio promedio a la existencia
                    iExiEncEN.StockActualExistencia = xMovDet.StockExistencia;
                    iExiEncEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;

                    //vamos acumulando los ingresos o salidas en el objeto saldo(iSalEncEN)
                    iIngresoAcumulado += MovimientoDetaRN.ObtenerCantidadIngresada(xMovDet);
                    iSalidaAcumulado += MovimientoDetaRN.ObtenerCantidadSalida(xMovDet);

                    //adicionamos el movimientoDeta a la lista que va a modificar a los movimientosDeta
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

            //modificar movimientodeta masivo
            MovimientoDetaRN.ModificarMovimientoDetaParaRecalculo(iLisMovDetMod);

            //modificar saldos masivo
            SaldoRN.ModificarSaldoParaRecalculo(iLisSalMod);

            //modificar existencia masivo
            ExistenciaRN.ModificarExistenciaPorRecalculo(iLisExiMod);
        }

        public static decimal ObtenerCantidadIngresada(MovimientoDetaEN pMovDet)
        {
            //valor resultado
            decimal iCantidad = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iCantidad = pMovDet.CantidadMovimientoDeta;
            }
            else
            {
                //salida
                iCantidad = 0;
            }

            //devolver
            return iCantidad;
        }

        public static decimal ObtenerCantidadSalida(MovimientoDetaEN pMovDet)
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
                iCantidad = pMovDet.CantidadMovimientoDeta;
            }

            //devolver
            return iCantidad;
        }

        public static decimal ObtenerPrecioUnitarioPorRecalculo(MovimientoDetaEN pMovDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            if (pMovDet.CCalculaPrecioPromedio == "0")//no
            {
                iValor = pMovDet.PrecioAnteriorExistencia;
            }
            else
            {
                iValor = pMovDet.PrecioUnitarioMovimientoDeta;
            }

            //devolver
            return iValor;
        }

        public static MovimientoDetaEN TransformarAMovimientoDeta(ProduccionExisEN pProExi, MovimientoCabeEN pMovCab, ExistenciaEN pExi,
            ParametroEN pPar)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //pasamos datos
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = pProExi.CorrelativoProduccionExis;
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = pMovCab.CClaseTipoOperacion;
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pPar.CentroCostoProduccion;
            iMovDetEN.CodigoExistencia = pProExi.CodigoExistencia;
            iMovDetEN.CodigoUnidadMedida = pProExi.CodigoUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProExi.CantidadProduccionExis;
            iMovDetEN.StockAnteriorExistencia = pExi.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = pExi.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProExi.PrecioUnitario;
            iMovDetEN.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetEN);
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> TransformarAMovimientosDeta(List<ProduccionExisEN> pLisProExi, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

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

                //creamos un objeto movimientoDeta desde xProExi
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.TransformarAMovimientoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static void AdicionarMovimientoDetaPorSalidaInsumos(List<ProduccionExisEN> pLisProExi, MovimientoCabeEN pMovCab)
        {
            //actualizar la clase de operacion
            pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a MovimientoDeta
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.TransformarAMovimientosDeta(pLisProExi, pMovCab);

            //adicionar masivo
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public static List<ExistenciaEN> ListarExistenciasActualizadasPorEliminacionMovimientosDeta(List<MovimientoDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a las existencias que estan referenciadas en esta lista pLisMovDet
            List<ExistenciaEN> iLisExiMovDet = MovimientoDetaRN.ListarExistenciasReferenciadasEnMovimientosDeta(pLisMovDet);

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiMovDet);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = MovimientoDetaRN.ObtenerNuevoStockPorEliminacion(xMovDet, iExiEN);

                //agregamos a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerNuevoStockPorEliminacion(MovimientoDetaEN pMovDet, ExistenciaEN pExi)
        {
            //valor resultado
            decimal iStock = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iStock = pExi.StockActualExistencia - pMovDet.CantidadMovimientoDeta;
            }
            else
            {
                //salida
                iStock = pExi.StockActualExistencia + pMovDet.CantidadMovimientoDeta;
            }

            //devolver
            return iStock;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoMercaderia(ProduccionProTerEN pProProTer, MovimientoCabeEN pMovCab,
            ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionProTerRN.ObtenerClaveExistencia(pProProTer);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = Cadena.CompletarCadena(pProProTer.CorrelativoProduccionProTer, 4, "0", Cadena.Direccion.Izquierda);
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProProTer.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = pProProTer.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = pProProTer.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = pProProTer.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProProTer.CantidadUnidadesRealEncajado;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProProTer.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoMercaderia(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

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
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoMercaderia(xProProTer, pMovCab, iCenCosEN);

                //aumentamos el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo, 4);

                //actualizar el objeto movimientoDeta
                iMovDetEN.CorrelativoMovimientoDeta = iCorrelativo;
                iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaPorClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pClaveMovimientoCabe;
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public static void EliminarMovimientoDetaXMovimientoCabe(string pClaveMovimientoCabe)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pClaveMovimientoCabe;

            //ejecutar metodo
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public static decimal ObtenerStockAnteriorExistenciaPorDigitacion(ExistenciaEN pExiBD, MovimientoDetaEN pMovDetGrilla, Universal.Opera pOperacionVentana)
        {
            //valor resultado
            decimal iValor = 0;

            //si no hay existencia, entonces devuelve cero
            if (pExiBD.CodigoExistencia == string.Empty) { return iValor; }

            //si la operacion es adicionar, entonces devuelve el dato del objeto existencia de bd
            if (pOperacionVentana == Universal.Opera.Adicionar) { return pExiBD.StockActualExistencia; }

            //si los codigos son iguales , entonces devuelve el dato del objeto movimientoDeta de la grilla
            if (pExiBD.CodigoExistencia == pMovDetGrilla.CodigoExistencia) { return pMovDetGrilla.StockAnteriorExistencia; }

            //aqui retorna el valor de la b.d
            return pExiBD.StockActualExistencia;
        }

        public static decimal ObtenerPrecioAnteriorExistenciaPorDigitacion(ExistenciaEN pExiBD, MovimientoDetaEN pMovDetGrilla, Universal.Opera pOperacionVentana)
        {
            //valor resultado
            decimal iValor = 0;

            //si no hay existencia, entonces devuelve cero
            if (pExiBD.CodigoExistencia == string.Empty) { return iValor; }

            //si la operacion es adicionar, entonces devuelve el dato del objeto existencia de bd
            if (pOperacionVentana == Universal.Opera.Adicionar) { return pExiBD.PrecioPromedioExistencia; }

            //si los codigos son iguales , entonces devuelve el dato del objeto movimientoDeta de la grilla
            if (pExiBD.CodigoExistencia == pMovDetGrilla.CodigoExistencia) { return pMovDetGrilla.PrecioAnteriorExistencia; }

            //aqui retorna el valor de la b.d
            return pExiBD.PrecioPromedioExistencia;
        }

        public static List<KardexValorizado> ObtenerReporteKardexValorizado(string pAño, string pCodigoMes, string pCodigoAlmacen,
            string pCTipoExistencia, string pCodigoExistenciaDesde, string pCodigoExistenciaHasta)
        {
            //lista resultado
            List<KardexValorizado> iLisRes = new List<KardexValorizado>();

            //traer todo el movimiento deta del periodo para el kardex           
            List<List<MovimientoDetaEN>> iLisLisMovDetKar = MovimientoDetaRN.ListarListasDeMovimientoDetasParaKardex(pAño, pCodigoMes,
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

                //traer los movimientos Deta para esta existencia
                List<MovimientoDetaEN> iLisMovDetExi = MovimientoDetaRN.ObtenerListaDeMovimientosDetaDeExistencia(xSal.CodigoExistencia, iLisLisMovDetKar);

                //armar la lista de KardexValorizados, que se pueden obtener del objeto saldo y su lista movimientosDeta
                List<KardexValorizado> iLisKarValSal = MovimientoDetaRN.ArmarListaKardexValorizadoDeSaldoYMovimientosDeta(xSal, pCodigoMes,
                    iCodigoMesAnterior, iLisMovDetExi);

                //agregamos a la lista resultado
                iLisRes.AddRange(iLisKarValSal);
            }

            //retornar
            return iLisRes;
        }

        public static List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaKardex(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarListasDeMovimientoDetasParaKardex(pObj);
        }

        public static List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaKardex(string pAño, string pCodigoMes, string pCodigoAlmacen,
            string pCTipoExistencia, string pCodigoExistenciaDesde, string pCodigoExistenciaHasta)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.PeriodoMovimientoCabe = pAño + "-" + pCodigoMes;
            iMovDetEN.CodigoAlmacen = pCodigoAlmacen;
            iMovDetEN.CodigoTipo = pCTipoExistencia;
            iMovDetEN.Adicionales.Desde1 = pCodigoExistenciaDesde;
            iMovDetEN.Adicionales.Hasta1 = pCodigoExistenciaHasta;

            //ejecutar metodo
            return MovimientoDetaRN.ListarListasDeMovimientoDetasParaKardex(iMovDetEN);
        }

        public static List<MovimientoDetaEN> ObtenerListaDeMovimientosDetaDeExistencia(string pCodigoExistencia, List<List<MovimientoDetaEN>> pLisLisMovDetAlm)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //buscar la lista que contiene el codigo de existencia, ¡solo vienen listas de movimientos
            //de existencias de un almacen especifico!

            //recorrer cada objeto
            foreach (List<MovimientoDetaEN> xLisMovDet in pLisLisMovDetAlm)
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

        public static List<KardexValorizado> ArmarListaKardexValorizadoDeSaldoYMovimientosDeta(SaldoEN pSal, string pCodigoMesProceso, string pCodigoMesAnterior, List<MovimientoDetaEN> pLisMovDetExi)
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
                //aqui hay movimientos deta para la existencia que esta en el objeto saldo
                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in pLisMovDetExi)
                {
                    //obtener el KardexValorizado completo
                    KardexValorizado iKarVal = MovimientoDetaRN.ArmarKardexValorizadoDeSaldoYMovimientoDeta(pSal, pCodigoMesProceso,
                        pCodigoMesAnterior, xMovDet);

                    //agregamos a la lista resultado
                    iLisRes.Add(iKarVal);
                }
            }

            //devolver
            return iLisRes;
        }

        public static KardexValorizado ArmarKardexValorizadoDeSaldoYMovimientoDeta(SaldoEN iSal, string pCodigoMesProceso,
            string pCodigoMesAnterior, MovimientoDetaEN pMovDet)
        {
            //objeto resultado
            //pasamos primero los datos que tendra del objeto saldo
            KardexValorizado iKarVal = SaldoRN.ArmarKardexValorizadoDeSoloSaldo(iSal, pCodigoMesProceso, pCodigoMesAnterior);

            //actualizamos los totales por existencia
            iKarVal.CantidadActual = SaldoRN.ObtenerStock(iSal, pCodigoMesProceso);
            iKarVal.PrecioActual = SaldoRN.ObtenerPrecioPromedio(iSal, pCodigoMesProceso);
            iKarVal.TotalActual = iKarVal.CantidadActual * iKarVal.PrecioActual;

            //ahora completamos los datos del KardexValorizado con el objeto movimientoDeta
            iKarVal.FechaMovimientoCabe = pMovDet.FechaMovimientoCabe;
            iKarVal.CTipoDocumento = pMovDet.CTipoDocumento;
            iKarVal.SerieDocumento = pMovDet.SerieDocumento;
            iKarVal.NumeroDocumento = pMovDet.NumeroDocumento;
            iKarVal.CodigoTipoOperacion = pMovDet.CodigoTipoOperacion;
            iKarVal.NumeroMovimientoCabe = pMovDet.NumeroMovimientoCabe;
            iKarVal.CodigoUnidadMedida1 = pMovDet.CodigoUnidadMedida;

            //segun tipo de movimiento
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iKarVal.CClaseTipoOperacion = "I";
                iKarVal.CantidadIngreso = pMovDet.CantidadMovimientoDeta;
                iKarVal.PrecioIngreso = pMovDet.PrecioUnitarioMovimientoDeta;
                iKarVal.TotalIngreso = iKarVal.CantidadIngreso * iKarVal.PrecioIngreso;
            }
            else
            {
                iKarVal.CClaseTipoOperacion = "S";
                iKarVal.CantidadSalida = pMovDet.CantidadMovimientoDeta;
                iKarVal.PrecioSalida = pMovDet.PrecioUnitarioMovimientoDeta;
                iKarVal.TotalSalida = iKarVal.CantidadSalida * iKarVal.PrecioSalida;
            }

            //completamos los saldos
            iKarVal.CantidadSaldo = pMovDet.StockExistencia;
            iKarVal.PrecioSaldo = pMovDet.PrecioExistencia;
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

        public static MovimientoDetaEN HayStockSuficiente(MovimientoDetaEN pMovDet)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //validar
            //el objeto pMovDet contiene el stock antual de la existencia y tambien la cantidad
            //que se quiere sacar del almacen
            if (pMovDet.CantidadMovimientoDeta > pMovDet.StockAnteriorExistencia)
            {
                iMovDetEN.Adicionales.EsVerdad = false;
                iMovDetEN.Adicionales.Mensaje = "No hay stock suficiente, stock de la existencia = ";
                iMovDetEN.Adicionales.Mensaje += Formato.NumeroDecimal(pMovDet.StockAnteriorExistencia, 5);
            }

            //ok
            return iMovDetEN;
        }

        public static MovimientoDetaEN ArmarAMovimientoDeta(InventarioDetaEN pInvDet, MovimientoCabeEN pMovCab, ExistenciaEN pExi,
         ParametroEN pPar, string pCorrelativoDeta)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //pasamos datos
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = pCorrelativoDeta;
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = pMovCab.CClaseTipoOperacion;
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = string.Empty;//xxxxxxxxxxxx
            iMovDetEN.CodigoExistencia = pInvDet.CodigoExistencia;
            iMovDetEN.CodigoUnidadMedida = pInvDet.CodigoUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = Math.Abs(pInvDet.DiferenciaStock);
            iMovDetEN.StockAnteriorExistencia = pExi.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = pExi.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetEN);
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ArmarAMovimientosDeta(List<InventarioDetaEN> pLisInvDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

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

                //creamos un objeto movimientoDeta desde xProExi
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.ArmarAMovimientoDeta(xInvDet, pMovCab, iExiEncEN, iParEN, iCorrelativoDeta);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaDocumentosEmitidos(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarListasDeMovimientoDetasParaDocumentosEmitidos(pObj);
        }

        public static List<MovimientoDetaEN> ObtenerReporteDocumentosEmitidosResumen(MovimientoDetaEN pObj)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer la lista de listas de movimientosDeta para este reporte
            List<List<MovimientoDetaEN>> iLisLisMovDet = MovimientoDetaRN.ListarListasDeMovimientoDetasParaDocumentosEmitidos(pObj);

            //recorrer cada lista
            foreach (List<MovimientoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //creamos un nuevo objeto para el reporte
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.ArmarMovimientoDetaParaDocumentoEmitidoResumen(xLisMovDet);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN ArmarMovimientoDetaParaDocumentoEmitidoResumen(List<MovimientoDetaEN> pLisMovDetExi)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //pasamos datos
            iMovDetEN.CodigoTipo = pLisMovDetExi[0].CodigoTipo;
            iMovDetEN.NombreTipo = pLisMovDetExi[0].NombreTipo;
            iMovDetEN.CodigoExistencia = pLisMovDetExi[0].CodigoExistencia;
            iMovDetEN.DescripcionExistencia = pLisMovDetExi[0].DescripcionExistencia;

            //obtenemos los valores acumulados(Cantidad y costo)
            MovimientoDetaRN.AcumularCamposNumericos(iMovDetEN, pLisMovDetExi);

            //obtener el precio promedio para este objeto
            iMovDetEN.PrecioExistencia = Operador.DivisionDecimal(iMovDetEN.CostoMovimientoDeta, iMovDetEN.CantidadMovimientoDeta);
            iMovDetEN.PrecioExistencia = Math.Round(iMovDetEN.PrecioExistencia, 2);

            //devolver
            return iMovDetEN;
        }

        public static void AcumularCamposNumericos(MovimientoDetaEN pObj, List<MovimientoDetaEN> pLista)
        {
            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLista)
            {
                //acumulamos solo los campos numericos de este objeto
                pObj.CantidadMovimientoDeta += xMovDet.CantidadMovimientoDeta;
                pObj.PrecioUnitarioMovimientoDeta += xMovDet.PrecioUnitarioMovimientoDeta;
                pObj.CostoMovimientoDeta += xMovDet.CostoMovimientoDeta;
                pObj.StockAnteriorExistencia += xMovDet.StockAnteriorExistencia;
                pObj.PrecioAnteriorExistencia += xMovDet.PrecioAnteriorExistencia;
                pObj.PrecioExistencia += xMovDet.PrecioExistencia;
                pObj.StockExistencia += xMovDet.StockExistencia;
            }
        }

        public static List<MovimientoDetaEN> ObtenerReporteDocumentosEmitidosDetalle(MovimientoDetaEN pObj)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer la lista de listas de movimientosDeta para este reporte
            List<List<MovimientoDetaEN>> iLisLisMovDet = MovimientoDetaRN.ListarListasDeMovimientoDetasParaDocumentosEmitidos(pObj);

            //recorrer cada lista
            foreach (List<MovimientoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //adicionamos a la lista resultado
                iLisRes.AddRange(xLisMovDet);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ObtenerReporteRecordsExistencia(MovimientoDetaEN pObj)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer la lista de listas de movimientosDeta para este reporte
            List<List<MovimientoDetaEN>> iLisLisMovDet = MovimientoDetaRN.ListarListasDeMovimientoDetasParaRecordsExistencia(pObj);

            //recorrer cada lista
            foreach (List<MovimientoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //creamos un nuevo objeto para el reporte
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.ArmarMovimientoDetaParaRecordsExistencia(xLisMovDet);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //ordenar de mayor a menor cantidad      
            iLisRes.Sort((x, y) => y.CantidadMovimientoDeta.CompareTo(x.CantidadMovimientoDeta));

            //devolver
            return iLisRes;
        }

        public static List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaRecordsExistencia(MovimientoDetaEN pObj)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.CodigoTipoOperacion = string.Empty;
            iMovDetEN.Adicionales.Desde1 = pObj.Adicionales.Desde1;
            iMovDetEN.Adicionales.Hasta1 = pObj.Adicionales.Hasta1;
            iMovDetEN.CodigoAlmacen = pObj.CodigoAlmacen;

            //ejecutar metodo
            return MovimientoDetaRN.ListarListasDeMovimientoDetasParaDocumentosEmitidos(iMovDetEN);
        }

        public static MovimientoDetaEN ArmarMovimientoDetaParaRecordsExistencia(List<MovimientoDetaEN> pLisMovDetExi)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //pasamos datos            
            iMovDetEN.CodigoExistencia = pLisMovDetExi[0].CodigoExistencia;
            iMovDetEN.DescripcionExistencia = pLisMovDetExi[0].DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = pLisMovDetExi[0].CodigoUnidadMedida;

            //obtenemos los valores acumulados(Cantidad y costo)
            MovimientoDetaRN.AcumularCamposNumericos(iMovDetEN, pLisMovDetExi);

            //obtener el precio promedio para este objeto
            iMovDetEN.PrecioExistencia = Operador.DivisionDecimal(iMovDetEN.CostoMovimientoDeta, iMovDetEN.CantidadMovimientoDeta);
            iMovDetEN.PrecioExistencia = Math.Round(iMovDetEN.PrecioExistencia, 2);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaParaSalidasXCeCoDetalle(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaParaSalidasXCeCoDetalle(pObj);
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaParaIngresoXCeCoDetalle(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaParaIngresoXCeCoDetalle(pObj);
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaParaIngresoXOrdCompraXCeCoDetalle(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaParaIngresoXOrdCompraXCeCoDetalle(pObj);
        }


        public static List<MovimientoDetaEN> ListarMovimientosDetaParaControlMovimientosISDetalle(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaParaControlMovimientosISDetalle(pObj);
        }

        public static void EliminarMovimientoDetaXPeriodoYOrigen(MovimientoCabeEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.EliminarMovimientoDetaXPeriodoYOrigen(pObj);
        }

        public static void EliminarMovimientosDetaDeImportacion(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            MovimientoDetaRN.EliminarMovimientoDetaXPeriodoYOrigen(iMovCabEN);
        }

        public static void EliminarMovimientoDetaXPeriodoXOrigenYClase(MovimientoCabeEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.EliminarMovimientoDetaXPeriodoXOrigenYClase(pObj);
        }

        public static void EliminarMovimientosDetaDeImportacionIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "1";//ingreso
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            MovimientoDetaRN.EliminarMovimientoDetaXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static void EliminarMovimientosDetaDeImportacionSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "2";//salida
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            MovimientoDetaRN.EliminarMovimientoDetaXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXExistencia(ExistenciaEN pObj, List<List<MovimientoDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //recorrer cada objeto
            foreach (List<MovimientoDetaEN> xLisMovDet in pLisLisMovDet)
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

        public static List<MovimientoDetaEN> FiltrarMovimientoDeta(List<MovimientoDetaEN> pLista, string pCampoFiltro, string pValorFiltro)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorFiltro.ToUpper();

            //recorrer cada objeto
            foreach (MovimientoDetaEN xPer in pLista)
            {
                string iTexto = MovimientoDetaRN.ObtenerValorDeCampo(xPer, pCampoFiltro).ToUpper();
                if (iTexto == iValor)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string CadenaCodigosExistenciasParaIN(List<MovimientoDetaEN> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLista)
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

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaEmpaquetar(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pProDet);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.NumeroUnidadesConCal - pProDet.NumeroUnidadesSueltas;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaEmpaquetar(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaEmpaquetar(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoSemiElaborado(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pProDet);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.CantidadEncajonar;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProDet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoSemiElaborado(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoSemiElaborado(pProDet, pMovCab, iCenCosEN);

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

        public static List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionDeta(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaXClaveProduccionDeta(pObj);
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionDeta(string pClaveProduccionDeta)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(iMovDetEN);
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionDeta(ProduccionDetaEN pObj)
        {
            //asignar parametros          
            string iClaveProduccionDeta = pObj.ClaveProduccionDeta;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(iClaveProduccionDeta);
        }

        public static bool EsActoDigitarPrecioUnitarioConversion(MovimientoDetaEN pObj)
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

        public static bool EsActoDigitarPrecioUnitario(MovimientoDetaEN pObj)
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

        public static bool EsActoDigitarCantidadConversion(MovimientoDetaEN pObj)
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

        public static bool EsActoDigitarCantidad(MovimientoDetaEN pObj)
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

        public static decimal ObtenerPrecioUnitarioConvertidoSugerido(MovimientoDetaEN pObj)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = MovimientoDetaRN.EsActoDigitarPrecioUnitarioConversion(pObj);

            //obtener el valor
            if (iEsDigitable == false)
            {
                ivalor = 0;
            }
            else
            {
                ivalor = pObj.PrecioUnitarioConversion;
            }

            //devolver
            return ivalor;
        }

        public static decimal ObtenerPrecioUnitarioSugerido(MovimientoDetaEN pMocDet)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = MovimientoDetaRN.EsActoDigitarPrecioUnitario(pMocDet);

            //obtener el valor
            if (pMocDet.CCalculaPrecioPromedio == "0")//no
            {
                ivalor = pMocDet.PrecioAnteriorExistencia;
            }
            else
            {
                if (iEsDigitable == false)
                {
                    ivalor = Operador.DivisionDecimal(pMocDet.PrecioUnitarioConversion, pMocDet.FactorConversion);
                }
                else
                {
                    ivalor = pMocDet.PrecioUnitarioMovimientoDeta;
                }
            }

            //devolver
            return ivalor;
        }

        public static decimal ObtenerCantidadConvertidoSugerido(MovimientoDetaEN pObj)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = MovimientoDetaRN.EsActoDigitarCantidadConversion(pObj);

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

        public static decimal ObtenerCantidadSugerido(MovimientoDetaEN pMocDet, List<LoteEN> pLisLotExi)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = MovimientoDetaRN.EsActoDigitarCantidad(pMocDet);

            //obtener el valor
            if (iEsDigitable == false)
            {
                //si esta existencia tiene lotes registrados, entonces se devuelve
                //el mismo valor que tiene 
                if (pLisLotExi.Count != 0)
                {
                    ivalor = pMocDet.CantidadMovimientoDeta;
                }
                else
                {
                    ivalor = pMocDet.CantidadConversion * pMocDet.FactorConversion;
                }
            }
            else
            {
                ivalor = pMocDet.CantidadMovimientoDeta;
            }

            //devolver
            return ivalor;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaNoPasan(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pProDet);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.NumeroUnidadesNoPasanConCal;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaNoPasan(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaNoPasan(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaUnidadesReproceso(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = ProduccionDetaRN.ObtenerClaveExistenciaSemiProducto(pProDet);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.UnidadesReproceso;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaUnidadesReproceso(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaUnidadesReproceso(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobrante(MovimientoDetaEN pObj, string pCodigoAlmacenIngresoTransferencia)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //validar
            //listar las existencias que estan separadas con las cantidades de unidades que le sobran
            List<ExistenciaEN> iLisExiSob = ExistenciaRN.ListarExistenciasSobrantes(pObj, pCodigoAlmacenIngresoTransferencia);

            //validando
            iMovDetEN = MovimientoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, iLisExiSob);

            //ok
            return iMovDetEN;
        }

        public static MovimientoDetaEN EsCantidadMovimientoDetaCorrecta(MovimientoDetaEN pObj)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadMovimientoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            MovimientoDetaEN iMovDetStoEN = MovimientoDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de compras para produccion           
            if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            //valida cuando la cantidad a sacar es mayor a las permitidas
            MovimientoDetaEN iMovDetCanSacEN = MovimientoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, string.Empty);
            if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static MovimientoDetaEN EsCantidadTransferenciaMovimientoDetaCorrecta(MovimientoDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadMovimientoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            MovimientoDetaEN iMovDetStoEN = MovimientoDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de compras para produccion           
            if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            //valida cuando la existencia no es almacen de produccion           
            if (FormulaDetaRN.EsAlmacenDeProduccion(pCodigoAlmacenProduccion) == false) { return iMovDetEN; }

            //valida cuando la cantidad a transferir es diferente a lo que pide la produccion actual
            MovimientoDetaEN iMovDetCanDifEN = MovimientoDetaRN.ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(pObj,
                pCodigoAlmacenProduccion);
            if (iMovDetCanDifEN.Adicionales.EsVerdad == false) { return iMovDetCanDifEN; }

            //valida cuando la cantidad a sacar es mayor a las permitidas
            MovimientoDetaEN iMovDetCanSacEN = MovimientoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj,
                pCodigoAlmacenProduccion);
            if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static MovimientoDetaEN EsCantidadTransferenciaMovimientoDetaCorrectaNew(MovimientoDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadMovimientoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            MovimientoDetaEN iMovDetStoEN = MovimientoDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            ////valida cuando la existencia no es almacen de compras para produccion           
            //if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            ////valida cuando la existencia no es almacen de produccion           
            //if (FormulaDetaRN.EsAlmacenDeProduccion(pCodigoAlmacenProduccion) == false) { return iMovDetEN; }

            ////valida cuando la cantidad a transferir es diferente a lo que pide la produccion actual
            //MovimientoDetaEN iMovDetCanDifEN = MovimientoDetaRN.ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(pObj,
            //    pCodigoAlmacenProduccion);
            //if (iMovDetCanDifEN.Adicionales.EsVerdad == false) { return iMovDetCanDifEN; }

            ////valida cuando la cantidad a sacar es mayor a las permitidas
            //MovimientoDetaEN iMovDetCanSacEN = MovimientoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj,
            //    pCodigoAlmacenProduccion);
            //if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static MovimientoDetaEN ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(MovimientoDetaEN pObj,
             string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //validar
            //obtener la cantidad que se necesita para produccion(solo partes de trabajo)
            decimal iCantidadProduccion = ProduccionExisRN.ObtenerCantidadNecesariaParaProducir(pObj, pCodigoAlmacenProduccion);

            //si hay cantidad produccion
            if (iCantidadProduccion != 0 && iCantidadProduccion != pObj.CantidadMovimientoDeta)
            {
                iMovDetEN.Adicionales.EsVerdad = false;
                iMovDetEN.Adicionales.Mensaje = "Te falta transferir de almacen de produccion a cocina la cantidad de:" + iCantidadProduccion.ToString();
            }

            //ok
            return iMovDetEN;
        }

        public static MovimientoDetaEN EsCantidadAdicionalMovimientoDetaCorrecta(MovimientoDetaEN pObj)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadMovimientoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            MovimientoDetaEN iMovDetStoEN = MovimientoDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de produccion           
            if (FormulaDetaRN.EsAlmacenDeProduccion(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            //valida cuando la cantidad a sacar es mayor a las permitidas
            MovimientoDetaEN iMovDetCanSacEN = MovimientoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj);
            if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static MovimientoDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobrante(MovimientoDetaEN pObj)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //validar
            //listar las existencias que estan separadas con las cantidades de unidades que le sobran
            List<ExistenciaEN> iLisExiSob = ExistenciaRN.ListarExistenciasSobrantes(pObj);

            //validando
            iMovDetEN = MovimientoDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, iLisExiSob);

            //ok
            return iMovDetEN;
        }

        public static MovimientoDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobrante(MovimientoDetaEN pObj,
            List<ExistenciaEN> pListaExistenciasSobrantes)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //validar           
            //buscar la existencia del movimiento en la lista de existencias sobrantes
            ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(pListaExistenciasSobrantes, ExistenciaEN.CodExi, pObj.CodigoExistencia);

            //si lo encontro
            if (iExiBusEN.CodigoExistencia != string.Empty)
            {
                //chequear si la cantidad digitada es menor que las que sobran
                if (pObj.CantidadMovimientoDeta > iExiBusEN.StockActualExistencia)
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

        public static List<List<MovimientoDetaEN>> ListarListasMovimientosDetaParaImportar(List<MovimientoDetaEN> pLista)
        {
            //asignar parametros
            List<string> iLisCam = new List<string>();
            iLisCam.Add(MovimientoDetaEN.FecMovCab);
            iLisCam.Add(MovimientoDetaEN.OrdCom);
            iLisCam.Add(MovimientoDetaEN.CodAlm);

            //ejecutar metodo
            return ListaG.ListarListas<MovimientoDetaEN>(pLista, iLisCam);
        }

        public static decimal ObtenerPrecioUnitarioConvertido(MovimientoDetaEN pObj, decimal pPrecioUnitarioImportadoExcel)
        {
            //asignar parametros
            pObj.PrecioUnitarioConversion = pPrecioUnitarioImportadoExcel;

            //ejecutar metodo
            return ObtenerPrecioUnitarioConvertidoSugerido(pObj);
        }

        public static decimal ObtenerPrecioUnitario(MovimientoDetaEN pObj, decimal pPrecioUnitarioImportadoExcel)
        {
            //asignar parametros
            pObj.PrecioUnitarioMovimientoDeta = pPrecioUnitarioImportadoExcel;

            //ejecutar metodo
            return ObtenerPrecioUnitarioSugerido(pObj);
        }

        public static decimal ObtenerCantidadConvertido(MovimientoDetaEN pObj, decimal pCantidadImportadoExcel)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = ObjetoG.Clonar<MovimientoDetaEN>(pObj);
            iMovDetEN.CEsLote = "0";
            iMovDetEN.CantidadConversion = pCantidadImportadoExcel;

            //ejecutar metodo
            return ObtenerCantidadConvertidoSugerido(iMovDetEN);
        }

        public static decimal ObtenerCantidad(MovimientoDetaEN pObj, decimal pCantidadImportadoExcel)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = ObjetoG.Clonar<MovimientoDetaEN>(pObj);
            iMovDetEN.CEsLote = "0";
            iMovDetEN.CantidadMovimientoDeta = pCantidadImportadoExcel;
            List<LoteEN> iLisLot = new List<LoteEN>();

            //ejecutar metodo
            return ObtenerCantidadSugerido(iMovDetEN, iLisLot);
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoUnidadesReproceso(LiberacionEN pLib, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesParaReproceso;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoUnidadesReproceso(LiberacionEN pLib,
            MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesReproceso(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaEmpaquetar(ProduccionProTerEN pProProTer, MovimientoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.ObtenerExistenciaSemiElaborado(pProProTer);

            //obtener la cantidad a sacar pero solo del almacen de productos en proceso
            decimal iCantidadASacar = LiberacionRN.ObtenerCantidadSoloDeProductosEnProceso(pProProTer);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = Cadena.CompletarCadena(pProProTer.CorrelativoProduccionProTer, 4, "0", Cadena.Direccion.Izquierda);
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = iCantidadASacar;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaEmpaquetar(EncajadoEN pEnc, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaEmpaquetar(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadMovimientoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoMercaderia(EncajadoEN pEnc, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

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
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoMercaderia(xProProTer, pMovCab, iCenCosEN);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaParaSaldosXExistencia(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaParaSaldosXExistencia(pObj);
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoUnidadesDonacion(LiberacionEN pLib, MovimientoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesParaDonacion;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;//xxxxxxxxxx
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoUnidadesDonacion(LiberacionEN pLib, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesDonacion(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoUnidadesDesechos(LiberacionEN pLib, MovimientoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesDesechas;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoUnidadesDesechas(LiberacionEN pLib, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesDesechos(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void Recalcular(string pAño, string pCodigoMes, List<ExistenciaEN> pLisExi, List<SaldoEN> pLisSal,
            List<List<MovimientoDetaEN>> pLisLisMovDet)
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

                //obtener la lista de movimientos deta de esta existencia
                List<MovimientoDetaEN> iLisMovDetExi = MovimientoDetaRN.ListarMovimientosDetaXExistencia(iExiEncEN, pLisLisMovDet);

                //recorrer cada objeto movimiento deta de la existencia
                foreach (MovimientoDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del movimiento deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio
                    xMovDet.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    xMovDet.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;
                    xMovDet.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(xMovDet);
                    xMovDet.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(xMovDet);
                    xMovDet.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    xMovDet.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

                    //ahora pasamos el nuevo stock y precio promedio a la existencia
                    iExiEncEN.StockActualExistencia = xMovDet.StockExistencia;
                    iExiEncEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;

                    //vamos acumulando los ingresos o salidas en el objeto saldo(iSalEncEN)
                    iIngresoAcumulado += MovimientoDetaRN.ObtenerCantidadIngresada(xMovDet);
                    iSalidaAcumulado += MovimientoDetaRN.ObtenerCantidadSalida(xMovDet);

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

        public static List<List<MovimientoDetaEN>> FiltrarPorFechaMenorOIgualQue(List<List<MovimientoDetaEN>> pLisLis, string pFechaCompara)
        {
            //lista resultado
            List<List<MovimientoDetaEN>> iLisRes = new List<List<MovimientoDetaEN>>();

            //recorrer cada lista
            foreach (List<MovimientoDetaEN> xLisMovDet in pLisLis)
            {
                //creamos la nueva lista filtrada
                List<MovimientoDetaEN> iLisMovDet = new List<MovimientoDetaEN>();

                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in xLisMovDet)
                {
                    //comparacion
                    if (Fecha.EsMayorQue(xMovDet.FechaMovimientoCabe, pFechaCompara) == true) { break; }

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

        public static void EliminarMovimientoDetaXPeriodoYAlmacen(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.EliminarMovimientoDetaXPeriodoYAlmacen(pObj);
        }

        public static void EliminarMovimientosDetaAlmacenProduccionParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovDetEN.CodigoAlmacen = "A10";//almacen de produccion

            //ejecutar metodo
            MovimientoDetaRN.EliminarMovimientoDetaXPeriodoYAlmacen(iMovDetEN);
        }

        public static void EliminarMovimientoDetaAlmacenesCompraParaRegenerar(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.EliminarMovimientoDetaAlmacenesCompraParaRegenerar(pObj);
        }

        public static void EliminarMovimientosDetaAlmacenesCompraParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.PeriodoMovimientoCabe = pCodigoPeriodo;

            //ejecutar metodo
            MovimientoDetaRN.EliminarMovimientoDetaAlmacenesCompraParaRegenerar(iMovDetEN);
        }

        public static void ExistenciasActualizadasPorAdicionMovimientosDeta(List<MovimientoDetaEN> pLisMovDet, List<ExistenciaEN> pLisExi)
        {
            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iExiEN, xMovDet);

                //modificar el cambio en existencia
                ListaG.Modificar<ExistenciaEN>(pLisExi, iExiEN, ExistenciaEN.ClaExi, iExiEN.ClaveExistencia);
            }
        }

        public static List<List<MovimientoDetaEN>> ListaListasMovimientosDetaPorFechaMenorOIgualQue(string pCodigoPeriodo, string pfechaCompara)
        {
            //traer todo el movimiento deta del periodo elegido, para el recalculo          
            List<List<MovimientoDetaEN>> iLisLisMovDetExi = MovimientoDetaRN.ListarListasDeMovimientoDetasParaRecalculo(pCodigoPeriodo);

            return MovimientoDetaRN.FiltrarPorFechaMenorOIgualQue(iLisLisMovDetExi, pfechaCompara);
        }

        public static List<MovimientoDetaEN> TransformarAMovimientosDeta(List<ProduccionExisEN> pLisProExi, MovimientoCabeEN pMovCab, List<ExistenciaEN> pLisExi)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //creamos un objeto movimientoDeta desde xProExi
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.TransformarAMovimientoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static void AdicionarMovimientoDetaPorSalidaInsumos(List<ProduccionExisEN> pLisProExi, MovimientoCabeEN pMovCab, List<ExistenciaEN> pLisExi)
        {
            //actualizar clase operacion
            pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a MovimientoDeta
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.TransformarAMovimientosDeta(pLisProExi, pMovCab, pLisExi);

            //adicionar masivo
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public static List<MovimientoDetaEN> ObtenerMovimientoDetaRecalculada(string pAño, string pCodigoMes, List<ExistenciaEN> pLisExi, List<SaldoEN> pLisSal,
           List<List<MovimientoDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

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

                //obtener la lista de movimientos deta de esta existencia
                List<MovimientoDetaEN> iLisMovDetExi = MovimientoDetaRN.ListarMovimientosDetaXExistencia(iExiEncEN, pLisLisMovDet);

                //recorrer cada objeto movimiento deta de la existencia
                foreach (MovimientoDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del movimiento deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio
                    xMovDet.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    xMovDet.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;
                    xMovDet.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(xMovDet);
                    xMovDet.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(xMovDet);
                    xMovDet.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    xMovDet.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

                    //ahora pasamos el nuevo stock y precio promedio a la existencia
                    iExiEncEN.StockActualExistencia = xMovDet.StockExistencia;
                    iExiEncEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;

                    //agregar a la lista resultado
                    iLisRes.Add(xMovDet);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ObtenerMovimientoDetaRecalculada(string pAño, string pCodigoMes)
        {
            //asignar parametros
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();
            List<SaldoEN> iLisSalAño = SaldoRN.ListarSaldosDeAño(pAño);
            List<List<MovimientoDetaEN>> iLisLisMovDetExi = MovimientoDetaRN.ListarListasDeMovimientoDetasParaRecalculo(pAño, pCodigoMes);

            //ejecutar metodo
            return MovimientoDetaRN.ObtenerMovimientoDetaRecalculada(pAño, pCodigoMes, iLisExiEmp, iLisSalAño, iLisLisMovDetExi);
        }

        public static List<List<MovimientoDetaEN>> ListarListasMovimientosDetaReprocesoParaRecalculo(List<MovimientoDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = ListaG.Filtrar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodAlm, "A18");//solo almacen reproceso(A18)
            List<string> iLisCamposClave = new List<string>() { MovimientoDetaEN.CodExi, MovimientoDetaEN.FecMovCab };

            //ejecutar metodo
            return ListaG.ListarListas<MovimientoDetaEN>(iLisMovDet, iLisCamposClave);
        }

        public static decimal ObtenerPrecioUnitarioPorRecalculoReproceso(MovimientoDetaEN pMovDet, List<LiberacionEN> pLisLib)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            if (pMovDet.CClaseTipoOperacion == "1")//movimiento ingreso
            {
                //buscar a la liberacion que provoco este ingreso
                LiberacionEN iLibEN = ListaG.Buscar<LiberacionEN>(pLisLib, LiberacionEN.ClaIngTraRep, pMovDet.ClaveMovimientoCabe);

                //pasamos el dato
                iValor = iLibEN.CostoTotalProducto;
            }
            else
            {
                iValor = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(pMovDet);
            }

            //devolver
            return iValor;
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXPeriodo(string pCodigoPeriodo)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaXPeriodo(pCodigoPeriodo);
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaEmpaquetarRE(RetiquetadoEN pRet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pRet.CodigoAlmacenPT, pRet.CodigoExistenciaPT);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CEsLote = iExiEN.CEsLote;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pRet.CantidadUnidadesRetiquetado;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaEmpaquetarRE(RetiquetadoEN pRet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaEmpaquetarRE(pRet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoMercaderiaRE(RetiquetadoEN pRet, MovimientoCabeEN pMovCab, ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pRet.CodigoAlmacenRE, pRet.CodigoExistenciaRE);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pRet.CantidadUnidadesRetiquetado;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pRet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoMercaderiaRE(RetiquetadoEN pRet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoMercaderiaRE(pRet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void AdicionarMovimientoDetaPorIngresoInsumos(List<ProduccionExisEN> pLisProExi, MovimientoCabeEN pMovCab)
        {
            //actualizar clase operacion
            pMovCab.CClaseTipoOperacion = "1";//ingreso

            //transformar la lista de ProduccionExis a MovimientoDeta
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.TransformarAMovimientosDetaDesmedro(pLisProExi, pMovCab);

            //adicionar masivo
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public static List<MovimientoDetaEN> TransformarAMovimientosDetaDesmedro(List<ProduccionExisEN> pLisProExi, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

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

                //creamos un objeto movimientoDeta desde xProExi
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.TransformarAMovimientoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoUnidadesMuestra(LiberacionEN pLib, MovimientoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesParaMuestra;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoUnidadesMuestra(LiberacionEN pLib, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesMuestra(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerPrecioUnitarioConFlete(MovimientoDetaEN pObj, decimal pCostoFleteUnitario)
        {
            //valor resultado
            decimal iValor = pObj.PrecioUnitarioMovimientoDeta;

            //primero restamos el flete unitario anterior
            iValor -= pObj.CostoFleteMovimientoDeta;

            //agregamos el nuevo flete
            iValor += pCostoFleteUnitario;

            //devolver
            return iValor;
        }

        public static decimal ObtenerPrecioUnitarioSinFlete(MovimientoDetaEN pObj)
        {
            //valor resultado
            decimal iValor = pObj.PrecioUnitarioMovimientoDeta;

            //primero restamos el flete unitario anterior
            iValor -= pObj.CostoFleteMovimientoDeta;

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoSinFlete(MovimientoDetaEN pObj)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.PrecioUnitarioMovimientoDeta = ObtenerPrecioUnitarioSinFlete(pObj);
            iMovDetEN.CantidadMovimientoDeta = pObj.CantidadMovimientoDeta;

            //ejecutar metodo
            return ObtenerCosto(iMovDetEN);
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaParaActualizarCostosProduccionExis(List<ProduccionExisEN> pLisProExi, List<List<MovimientoDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //recorrer cada objeto ProduccionExis
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la lista de la existencia de compras para este xProExi
                List<MovimientoDetaEN> iLisMovDetExi = ListaG.Buscar<MovimientoDetaEN>(pLisLisMovDet, MovimientoDetaEN.CodAlm, xProExi.CodigoAlmacenCompra,
                    MovimientoDetaEN.CodExi, xProExi.CodigoExistencia);

                //lista de movimientos a lo mas iguales a la fecha de produccionDeta
                MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

                //recorrer cada objeto
                foreach (MovimientoDetaEN xMovDet in iLisMovDetExi)
                {
                    if (Fecha.EsMayorOIgualQue(xProExi.FechaProduccionDeta, xMovDet.FechaMovimientoCabe) == true)
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

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoSemElaObservadas(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A22", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = pProDet.DescripcionSemiProducto;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.CantidadBloquear;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProDet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoSemElaMuestraProduccion(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A20", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = pProDet.DescripcionSemiProducto;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.CantidadMuestraProduccion;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProDet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoSemElaContraMuestra(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A20", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = pProDet.DescripcionSemiProducto;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.CantidadContraMuestra;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProDet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoSemElaObservadas(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoSemElaObservadas(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoSemElaMuestraProduccion(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoSemElaMuestraProduccion(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoSemElaContraMuestra(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoSemElaContraMuestra(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaEmpaquetarObservado(ProduccionProTerEN pProProTer, MovimientoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //obtener la formulaDeta al cual pertenece este ProTer
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A22", iForDetEN.CodigoSemiProducto);

            //obtener la cantidad a sacar pero solo del almacen de productos en proceso
            decimal iCantidadASacar = LiberacionRN.ObtenerCantidadSoloDeObservados(pProProTer);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = Cadena.CompletarCadena(pProProTer.CorrelativoProduccionProTer, 4, "0", Cadena.Direccion.Izquierda);
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = iCantidadASacar;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaEmpaquetarObservados(EncajadoEN pEnc, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaEmpaquetarObservado(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadMovimientoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoUnidadesObservados(LiberacionEN pLib, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesObservadas;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoUnidadesSaldo(LiberacionEN pLib, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, pLib.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesSaldo;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoUnidadesObservados(LiberacionEN pLib,
            MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesObservados(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoUnidadesSaldo(LiberacionEN pLib,
           MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesSaldo(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionProTer(string pClaveProduccionProTer)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveProduccionProTer = pClaveProduccionProTer;
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionProTer(iMovDetEN);
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionProTer(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaXClaveProduccionProTer(pObj);
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoCuarentenaQali(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A23", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.CantidadCuarentenaQali;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProDet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoCuarentenaQali(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoCuarentenaQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoReprocesoQali(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A18", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.CantidadReprocesoQali;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProDet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoMuestraQali(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A20", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.CantidadMuestraQali;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProDet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoReprocesoQali(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoReprocesoQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoMuestraQali(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoMuestraQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoDesechoQali(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A14", pProDet.CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = pProDet.CodigoSemiProducto;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProDet.CantidadDesechoQali;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProDet.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoDesechoQali(ProduccionDetaEN pProDet, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoDesechoQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaEmpaquetarCuarentena(ProduccionProTerEN pProProTer, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //obtener la formulaDeta al cual pertenece este ProTer
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia("A23", iForDetEN.CodigoSemiProducto);

            //obtener la cantidad a sacar pero solo del almacen de productos en proceso
            decimal iCantidadASacar = LiberacionRN.ObtenerCantidadSoloDeCuarentena(pProProTer);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = Cadena.CompletarCadena(pProProTer.CorrelativoProduccionProTer, 4, "0", Cadena.Direccion.Izquierda);
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = iCantidadASacar;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaEmpaquetarCuarentena(EncajadoEN pEnc, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaEmpaquetarCuarentena(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadMovimientoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaSalidasAdicionalesProduccionProTer(string pClaveProduccionProTer)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer todos los movimientos deta de esta ProduccionProTer de bd
            iLisRes = ListarMovimientosDetaXClaveProduccionProTer(pClaveProduccionProTer);

            //filtrar que solo sean salidas y almacen "A11"
            iLisRes = ListaG.Filtrar<MovimientoDetaEN>(iLisRes, MovimientoDetaEN.CClaTipOpe, "2", MovimientoDetaEN.CodAlm, "A11");

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(string pClaveProduccionProTerParteEmpaquetado)
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveProduccionProTerParteEmpaquetado = pClaveProduccionProTerParteEmpaquetado;
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(iMovDetEN);
        }

        public static List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(pObj);
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaTransferenciaUnidadesReproceso(LiberacionEN pLib, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = LiberacionRN.ObtenerClaveExistenciaSemiProducto(pLib);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesParaReproceso;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaTransferenciaUnidadesReproceso(LiberacionEN pLib,
            MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaTransferenciaUnidadesReproceso(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaTransferenciaUnidadesDonacion(LiberacionEN pLib, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = LiberacionRN.ObtenerClaveExistenciaSemiProducto(pLib);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesParaDonacion;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;//xxxxxxxxxx
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaTransferenciaUnidadesDonacion(LiberacionEN pLib, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaTransferenciaUnidadesDonacion(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaTransferenciaUnidadesDesecha(LiberacionEN pLib, MovimientoCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = LiberacionRN.ObtenerClaveExistenciaSemiProducto(pLib);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesDesechas;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaTransferenciaUnidadesDesechas(LiberacionEN pLib, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaTransferenciaUnidadesDesecha(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaSalidaTransferenciaUnidadesPacking(LiberacionEN pLib, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.ClaveExistencia = LiberacionRN.ObtenerClaveExistenciaSemiProducto(pLib);
            iExiEN = ExistenciaRN.BuscarExistenciaXClave(iExiEN);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pLib.UnidadesPasan;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pLib.CostoTotalProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaSalidaTransferenciaUnidadesPacking(LiberacionEN pLib,
            MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaTransferenciaUnidadesPacking(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void AdicionarMovimientoDetaPorSalidaEtiquetaSegundaLiberacion(List<ProduccionExisEN> pLisProExi, MovimientoCabeEN pMovCab)
        {
            //actualizar clase operacion
            pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a MovimientoDeta
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.TransformarAMovimientosDetaSalidaEtiquetaSegundaLiberacion(pLisProExi, pMovCab);

            //adicionar masivo
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public static List<MovimientoDetaEN> TransformarAMovimientosDetaSalidaEtiquetaSegundaLiberacion(List<ProduccionExisEN> pLisProExi, MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

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

                //creamos un objeto movimientoDeta desde xProExi
                MovimientoDetaEN iMovDetEN = MovimientoDetaRN.TransformarAMovimientoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoDetaEN> ListarMovimientoDetaParaIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pProProTer,
           MovimientoCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesSegundaLiberacion(pProProTer, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoDetaEN CrearMovimientoDetaParaIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pProProTer, MovimientoCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

            //traer a la existencia 
            ExistenciaEN iExiEN = ExistenciaRN.BuscarExistencia(pMovCab.CodigoAlmacen, FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer).CodigoSemiProducto);

            //pasamos datos         
            iMovDetEN.CodigoEmpresa = pMovCab.CodigoEmpresa;
            iMovDetEN.CorrelativoMovimientoDeta = "0001";
            iMovDetEN.FechaMovimientoCabe = pMovCab.FechaMovimientoCabe;
            iMovDetEN.PeriodoMovimientoCabe = pMovCab.PeriodoMovimientoCabe;
            iMovDetEN.CodigoAlmacen = pMovCab.CodigoAlmacen;
            iMovDetEN.CodigoTipoOperacion = pMovCab.CodigoTipoOperacion;
            iMovDetEN.CCalculaPrecioPromedio = pMovCab.CCalculaPrecioPromedio;
            iMovDetEN.CClaseTipoOperacion = "1";//ingreso
            iMovDetEN.NumeroMovimientoCabe = pMovCab.NumeroMovimientoCabe;
            iMovDetEN.CodigoCentroCosto = pCenCos.CodigoItemE;
            iMovDetEN.DescripcionCentroCosto = pCenCos.NombreItemE;
            iMovDetEN.CodigoExistencia = iExiEN.CodigoExistencia;
            iMovDetEN.DescripcionExistencia = iExiEN.DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = iExiEN.CodigoUnidadMedida;
            iMovDetEN.NombreUnidadMedida = iExiEN.NombreUnidadMedida;
            iMovDetEN.CantidadMovimientoDeta = pProProTer.CantidadUnidadesRealEncajado;
            iMovDetEN.StockAnteriorExistencia = iExiEN.StockActualExistencia;
            iMovDetEN.PrecioAnteriorExistencia = iExiEN.PrecioPromedioExistencia;
            iMovDetEN.PrecioUnitarioMovimientoDeta = pProProTer.CostoUnidadSemiProducto;
            iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static void ActualizarCostoFleteDetayClaveMovimientoDeta(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.ActualizarCostoFleteDetayClaveMovimientoDeta(pObj);
        }

        public static List<MovimientoDetaEN> ListarListasDeMovimientoCompraPorProvedor(MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ListarListasDeMovimientoCompraPorProvedor(pObj);
        }

        public static List<dynamic> ObtenerMovimientosPorOrdenCompra(string ClaveMovimiento)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            return iPerAD.ObtenerMovimientosPorOrdenCompra(ClaveMovimiento);
        }

        public static void ActualizarMovimientoOrdenCompra(string claveMovimientoCabe, MovimientoDetaEN pObj)
        {
            MovimientoDetaAD iPerAD = new MovimientoDetaAD();
            iPerAD.ActualizarMovimientoOrdenCompra(claveMovimientoCabe, pObj);
        }
    }
}
