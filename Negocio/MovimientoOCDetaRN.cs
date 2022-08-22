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
    public class MovimientoOCDetaRN
    {
       
        public static MovimientoOCDetaEN EnBlanco()
        {
            MovimientoOCDetaEN iExiEN = new MovimientoOCDetaEN();
            return iExiEN;
        }

        public static void AdicionarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.AgregarMovimientoDeta(pObj);
        }

        public static void AdicionarMovimientoDeta(List< MovimientoOCDetaEN> pLista)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.AgregarMovimientoDeta(pLista);
        }

        public static void ModificarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.ModificarMovimientoDeta(pObj);
        }

        public static void ModificarMovimientoDeta(List< MovimientoOCDetaEN> pLista)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.ModificarMovimientoDeta(pLista);
        }

        public static void ModificarMovimientoDetaParaRecalculo(List<MovimientoOCDetaEN> pLista)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.ModificarMovimientoDetaParaRecalculo(pLista);
        }

        public static void EliminarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.EliminarMovimientoDeta(pObj);
        }

        public static void EliminarMovimientoDetaXMovimientoCabe(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.EliminarMovimientoDetaXMovimientoCabe(pObj);
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetas(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientoDetas(pObj);
        }

        public static MovimientoOCDetaEN BuscarMovimientoDetaXClave(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.BuscarMovimientoDetaXClave(pObj);
        }

        public static MovimientoOCDetaEN EsMovimientoDetaExistente(MovimientoOCDetaEN pObj)
        {
            //objeto resultado
            MovimientoOCDetaEN iExiEN = new MovimientoOCDetaEN();

            //validar si existe en b.d
            iExiEN = MovimientoOCDetaRN.BuscarMovimientoDetaXClave(pObj);
            if (iExiEN.ClaveMovimientoDeta == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "La MovimientoDeta " + pObj.ClaveMovimientoDeta  + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(MovimientoOCDetaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case MovimientoOCDetaEN.ClaObj: return pObj.ClaveObjeto;
                case MovimientoOCDetaEN.ClaMovDet: return pObj.ClaveMovimientoDeta;
                case MovimientoOCDetaEN.ClaMovCab: return pObj.ClaveMovimientoCabe;
                case MovimientoOCDetaEN.CorMovDet: return pObj.CorrelativoMovimientoDeta;
                case MovimientoOCDetaEN.CodEmp: return pObj.CodigoEmpresa;
                case MovimientoOCDetaEN.NomEmp: return pObj.NombreEmpresa;
                case MovimientoOCDetaEN.FecMovCab: return pObj.FechaMovimientoCabe;
                case MovimientoOCDetaEN.PerMovCab: return pObj.PeriodoMovimientoCabe;
                case MovimientoOCDetaEN.CodAlm: return pObj.CodigoAlmacen;
                case MovimientoOCDetaEN.DesAlm: return pObj.DescripcionAlmacen;
                case MovimientoOCDetaEN.CodTipOpe: return pObj.CodigoTipoOperacion;
                case MovimientoOCDetaEN.DesTipOpe: return pObj.DescripcionTipoOperacion;
                case MovimientoOCDetaEN.CClaTipOpe: return pObj.CClaseTipoOperacion;
                case MovimientoOCDetaEN.CCalPrePro: return pObj.CCalculaPrecioPromedio;
                case MovimientoOCDetaEN.NumMovCab: return pObj.NumeroMovimientoCabe;               
                case MovimientoOCDetaEN.CodAux: return pObj.CodigoAuxiliar;
                case MovimientoOCDetaEN.DesAux: return pObj.DescripcionAuxiliar;               
                case MovimientoOCDetaEN.CTipDoc: return pObj.CTipoDocumento;
                case MovimientoOCDetaEN.NTipDoc: return pObj.NTipoDocumento;
                case MovimientoOCDetaEN.SerDoc: return pObj.SerieDocumento;
                case MovimientoOCDetaEN.NumDoc: return pObj.NumeroDocumento;
                case MovimientoOCDetaEN.FecDoc: return pObj.FechaDocumento;
                case MovimientoOCDetaEN.CodCenCos: return pObj.CodigoCentroCosto;
                case MovimientoOCDetaEN.DesCenCos: return pObj.DescripcionCentroCosto;
                case MovimientoOCDetaEN.CodExi: return pObj.CodigoExistencia;
                case MovimientoOCDetaEN.DesExi: return pObj.DescripcionExistencia;
                case MovimientoOCDetaEN.CodTip: return pObj.CodigoTipo;
                case MovimientoOCDetaEN.NomTip: return pObj.NombreTipo;
                case MovimientoOCDetaEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case MovimientoOCDetaEN.NomUniMed: return pObj.NombreUnidadMedida;
                case MovimientoOCDetaEN.CanMovDet: return pObj.CantidadMovimientoDeta.ToString();
                case MovimientoOCDetaEN.PreUniMovDet: return pObj.PrecioUnitarioMovimientoDeta.ToString();
                case MovimientoOCDetaEN.CosMovDet: return pObj.CostoMovimientoDeta.ToString();
                case MovimientoOCDetaEN.GloMovDet: return pObj.GlosaMovimientoDeta;
                case MovimientoOCDetaEN.StoAntExi: return pObj.StockAnteriorExistencia.ToString();
                case MovimientoOCDetaEN.PreAntExi: return pObj.PrecioAnteriorExistencia.ToString();
                case MovimientoOCDetaEN.StoExi: return pObj.StockExistencia.ToString();
                case MovimientoOCDetaEN.PreExi: return pObj.PrecioExistencia.ToString();
                case MovimientoOCDetaEN.CEstMovDet: return pObj.CEstadoMovimientoDeta;
                case MovimientoOCDetaEN.NEstMovDet: return pObj.NEstadoMovimientoDeta;
                case MovimientoOCDetaEN.UsuAgr: return pObj.UsuarioAgrega;
                case MovimientoOCDetaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case MovimientoOCDetaEN.UsuMod: return pObj.UsuarioModifica;
                case MovimientoOCDetaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<MovimientoOCDetaEN> FiltrarMovimientoDetasXTextoEnCualquierPosicion(List<MovimientoOCDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xPer in pLista)
            {
                string iTexto = MovimientoOCDetaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<MovimientoOCDetaEN> pListaMovimientoDetas)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaMovimientoDetas; }

            //filtar la lista
            iLisRes = MovimientoOCDetaRN.FiltrarMovimientoDetasXTextoEnCualquierPosicion(pListaMovimientoDetas, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveMovimientoDeta(MovimientoOCDetaEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave            
            iClave += pPer.ClaveMovimientoCabe + "-";
            iClave += pPer.CorrelativoMovimientoDeta;

            //retornar
            return iClave;
        }

        public static MovimientoOCDetaEN EsActoEliminarMovimientoDeta(MovimientoOCDetaEN pPer)
        {
            //objeto resultado
            MovimientoOCDetaEN iExiEN = new MovimientoOCDetaEN();

            //validar si existe
            iExiEN = MovimientoOCDetaRN.EsMovimientoDetaExistente(pPer);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

      
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void AdicionarMovimientoDeta(List<MovimientoOCDetaEN> pLis, MovimientoOCDetaEN pObj)
        {
            //obtener siguiente correlativo
            pObj.CorrelativoMovimientoDeta = MovimientoOCDetaRN.ObtenerSiguienteCorrelativo(pLis);
            pObj.ClaveObjeto = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<MovimientoOCDetaEN> pLis)
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

        public static decimal ObtenerCosto(MovimientoOCDetaEN pObj)
        {
            //valor resultado
            decimal iImporte = 0;

            //calcular
            iImporte = pObj.PrecioUnitarioMovimientoDeta * pObj.CantidadMovimientoDeta;

            //retornar
            return iImporte;
        }

        public static List<MovimientoOCDetaEN> RefrescarListaMovimientoDeta(List<MovimientoOCDetaEN> pLis)
        {
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();
            foreach (MovimientoOCDetaEN xMovDet in pLis)
            {
                iLisRes.Add(xMovDet);
            }
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveMovimientoCabe(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientosDetaXClaveMovimientoCabe(pObj);
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
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

        public static decimal ObtenerNuevoStockPorAdicion(MovimientoOCDetaEN pMovDet)
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

        public static decimal ObtenerNuevoPrecioPromedio(MovimientoOCDetaEN pMovDet)
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
                iPrecio = Operador.DivisionDecimal(iDividendo , iDivisor);
                //MessageBox.Show(iPrecio.ToString(), "Ver");
            }

            //devolver
            return iPrecio;
        }

        public static List<ExistenciaEN> ListarExistenciasReferenciadasEnMovimientosDeta(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = MovimientoOCDetaRN.ObtenerClaveExistencia(xMovDet);

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

        public static string ObtenerClaveExistencia(MovimientoOCDetaEN pObj)
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

        public static List<ExistenciaEN> ListarExistenciasActualizadasPorAdicionMovimientosDeta(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a las existencias que estan referenciadas en esta lista pLisMovDet
            List<ExistenciaEN> iLisExiMovDet = MovimientoOCDetaRN.ListarExistenciasReferenciadasEnMovimientosDeta(pLisMovDet);

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = MovimientoOCDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiMovDet);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iExiEN, xMovDet);
                
                //agregamos a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerNuevoPrecioPromedio(ExistenciaEN pExi, MovimientoOCDetaEN pMovDet)
        {
            //valor resultado
            decimal iPrecio = 0;

            //actualizar los datos del movimientoDeta
            pMovDet.PrecioAnteriorExistencia = pExi.PrecioPromedioExistencia;
            pMovDet.StockAnteriorExistencia = pExi.StockActualExistencia;

            //calcula
            iPrecio = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(pMovDet);

            //devolver
            return iPrecio;
        }

        public static decimal ObtenerNuevoStockPorAdicion(ExistenciaEN pExi, MovimientoOCDetaEN pMovDet)
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

        public static MovimientoOCDetaEN BuscarMovimientoDeta(string pCampo, string pValor, List<MovimientoOCDetaEN> pLista)
        {
            //objeto resultaddo
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLista)
            {
                if (MovimientoOCDetaRN.ObtenerValorDeCampo(xMovDet, pCampo) == pValor)
                {
                    return xMovDet;
                }
            }

            //devolver
            return iMovDetEN;
        }

        public static List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaRecalculo(string pCodigoPeriodo)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarListasDeMovimientoDetasParaRecalculo(pCodigoPeriodo);
        }

        public static List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaRecalculo(string pAño, string pCodigoMes)
        {
            //asignar parametros
            string iCodigoPeriodo = Formato.UnionDosTextos(pAño, pCodigoMes, "-");

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaRecalculo(iCodigoPeriodo);
        }

        public static void Recalcular(string pAño, string pCodigoMes)
        {            
            //traer todo el movimiento deta del periodo elegido, para el recalculo
            string iCodigoPeriodo = pAño + "-" + pCodigoMes;
            List<List<MovimientoOCDetaEN>> iLisLisMovDetExi = MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaRecalculo(iCodigoPeriodo);
            
            //traer todos los saldos del año que tiene el periodo elegido
            List<SaldoEN> iLisSalAño = SaldoRN.ListarSaldosDeAño(pAño);
            
            //le bajamos una unidad al codigoMes,este codigo sirve para obtener el stock y precio anterior
            //al mes que se esta procesando
            string iCodigoMesAnterior = Numero.DisminuirCorrelativoNumerico(pCodigoMes);

            //listas para grabar
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();
            List<MovimientoOCDetaEN> iLisMovDetMod = new List<MovimientoOCDetaEN>();
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
                List<MovimientoOCDetaEN> iLisMovDetExi = MovimientoOCDetaRN.ListarMovimientosDetaXExistencia(iExiEncEN, iLisLisMovDetExi);

                //recorrer cada objeto movimiento deta de la existencia
                foreach (MovimientoOCDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del movimiento deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio
                    xMovDet.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    xMovDet.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;
                    xMovDet.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(xMovDet);
                    xMovDet.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(xMovDet);
                    xMovDet.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    xMovDet.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

                    //ahora pasamos el nuevo stock y precio promedio a la existencia
                    iExiEncEN.StockActualExistencia = xMovDet.StockExistencia;
                    iExiEncEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;

                    //vamos acumulando los ingresos o salidas en el objeto saldo(iSalEncEN)
                    iIngresoAcumulado += MovimientoOCDetaRN.ObtenerCantidadIngresada(xMovDet);
                    iSalidaAcumulado += MovimientoOCDetaRN.ObtenerCantidadSalida(xMovDet);

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
            MovimientoOCDetaRN.ModificarMovimientoDetaParaRecalculo(iLisMovDetMod);
           
            //modificar saldos masivo
            SaldoRN.ModificarSaldoParaRecalculo(iLisSalMod);
           
            //modificar existencia masivo
            ExistenciaRN.ModificarExistenciaPorRecalculo(iLisExiMod);            
        }

        public static decimal ObtenerCantidadIngresada(MovimientoOCDetaEN pMovDet)
        {
            //valor resultado
            decimal iCantidad = 0;

            //calcula
            if (pMovDet.CClaseTipoOperacion == "1")//ingreso
            {
                iCantidad =  pMovDet.CantidadMovimientoDeta;
            }
            else
            {
                //salida
                iCantidad = 0;
            }

            //devolver
            return iCantidad;
        }

        public static decimal ObtenerCantidadSalida(MovimientoOCDetaEN pMovDet)
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

        public static decimal ObtenerPrecioUnitarioPorRecalculo(MovimientoOCDetaEN pMovDet)
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

        public static MovimientoOCDetaEN TransformarAMovimientoDeta(ProduccionExisEN pProExi, MovimientoOCCabeEN pMovCab,ExistenciaEN pExi,
            ParametroEN pPar)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetEN);
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> TransformarAMovimientosDeta(List<ProduccionExisEN> pLisProExi, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

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
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.TransformarAMovimientoDeta(xProExi, pMovCab, iExiEncEN, iParEN);
                
                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static void AdicionarMovimientoDetaPorSalidaInsumos(List<ProduccionExisEN> pLisProExi, MovimientoOCCabeEN pMovCab)
        {
            //actualizar la clase de operacion
            pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a MovimientoDeta
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.TransformarAMovimientosDeta(pLisProExi, pMovCab);

            //adicionar masivo
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public static List<ExistenciaEN> ListarExistenciasActualizadasPorEliminacionMovimientosDeta(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a las existencias que estan referenciadas en esta lista pLisMovDet
            List<ExistenciaEN> iLisExiMovDet = MovimientoOCDetaRN.ListarExistenciasReferenciadasEnMovimientosDeta(pLisMovDet);

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = MovimientoOCDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiMovDet);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorEliminacion(xMovDet, iExiEN);
                
                //agregamos a la lista resultado
                iLisRes.Add(iExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerNuevoStockPorEliminacion(MovimientoOCDetaEN pMovDet,ExistenciaEN pExi)
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

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoMercaderia(ProduccionProTerEN pProProTer, MovimientoOCCabeEN pMovCab,
            ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoMercaderia(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

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
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoMercaderia(xProProTer, pMovCab, iCenCosEN);

                //aumentamos el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo, 4);

                //actualizar el objeto movimientoDeta
                iMovDetEN.CorrelativoMovimientoDeta = iCorrelativo;
                iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }
            
            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaPorClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pClaveMovimientoCabe;
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public static void EliminarMovimientoDetaXMovimientoCabe(string pClaveMovimientoCabe)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pClaveMovimientoCabe;

            //ejecutar metodo
            MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public static decimal ObtenerStockAnteriorExistenciaPorDigitacion(ExistenciaEN pExiBD, MovimientoOCDetaEN pMovDetGrilla, Universal.Opera pOperacionVentana)
        {
            //valor resultado
            decimal iValor = 0;

            //si no hay existencia, entonces devuelve cero
            if (pExiBD.CodigoExistencia == string.Empty) { return iValor; }

            //si la operacion es adicionar, entonces devuelve el dato del objeto existencia de bd
            if(pOperacionVentana== Universal.Opera.Adicionar) { return pExiBD.StockActualExistencia; }

            //si los codigos son iguales , entonces devuelve el dato del objeto movimientoDeta de la grilla
            if (pExiBD.CodigoExistencia == pMovDetGrilla.CodigoExistencia) { return pMovDetGrilla.StockAnteriorExistencia; }

            //aqui retorna el valor de la b.d
            return pExiBD.StockActualExistencia;
        }

        public static decimal ObtenerPrecioAnteriorExistenciaPorDigitacion(ExistenciaEN pExiBD, MovimientoOCDetaEN pMovDetGrilla, Universal.Opera pOperacionVentana)
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
            List<List<MovimientoOCDetaEN>> iLisLisMovDetKar = MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaKardex(pAño, pCodigoMes,
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
                List<MovimientoOCDetaEN> iLisMovDetExi =MovimientoOCDetaRN.ObtenerListaDeMovimientosDetaDeExistencia(xSal.CodigoExistencia, iLisLisMovDetKar);

                //armar la lista de KardexValorizados, que se pueden obtener del objeto saldo y su lista movimientosDeta
                List<KardexValorizado> iLisKarValSal = MovimientoOCDetaRN.ArmarListaKardexValorizadoDeSaldoYMovimientosDeta(xSal,pCodigoMes,
                    iCodigoMesAnterior, iLisMovDetExi);

                //agregamos a la lista resultado
                iLisRes.AddRange(iLisKarValSal);
            }

            //retornar
            return iLisRes;
        }

        public static List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaKardex(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarListasDeMovimientoDetasParaKardex(pObj);
        }

        public static List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaKardex(string pAño, string pCodigoMes, string pCodigoAlmacen,
            string pCTipoExistencia, string pCodigoExistenciaDesde, string pCodigoExistenciaHasta)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.PeriodoMovimientoCabe = pAño + "-" + pCodigoMes;
            iMovDetEN.CodigoAlmacen = pCodigoAlmacen;
            iMovDetEN.CodigoTipo = pCTipoExistencia;
            iMovDetEN.Adicionales.Desde1 = pCodigoExistenciaDesde;
            iMovDetEN.Adicionales.Hasta1 = pCodigoExistenciaHasta;

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaKardex(iMovDetEN);
        }

        public static List<MovimientoOCDetaEN> ObtenerListaDeMovimientosDetaDeExistencia(string pCodigoExistencia, List<List<MovimientoOCDetaEN>> pLisLisMovDetAlm)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //buscar la lista que contiene el codigo de existencia, ¡solo vienen listas de movimientos
            //de existencias de un almacen especifico!

            //recorrer cada objeto
            foreach (List<MovimientoOCDetaEN> xLisMovDet in pLisLisMovDetAlm)
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

        public static List<KardexValorizado> ArmarListaKardexValorizadoDeSaldoYMovimientosDeta(SaldoEN pSal, string pCodigoMesProceso, string pCodigoMesAnterior, List<MovimientoOCDetaEN> pLisMovDetExi)
        {
            //lista resultado
            List<KardexValorizado> iLisRes = new List<KardexValorizado>();

            //si la lista esta vacia, entonces armamos un KardexValorizado solo con el objeto saldo
            if (pLisMovDetExi.Count == 0)
            {
                KardexValorizado iKarVal = SaldoRN.ArmarKardexValorizadoDeSoloSaldo(pSal,pCodigoMesProceso, pCodigoMesAnterior);
                iLisRes.Add(iKarVal);
            }
            else
            {
                //aqui hay movimientos deta para la existencia que esta en el objeto saldo
                //recorrer cada objeto
                foreach (MovimientoOCDetaEN xMovDet in pLisMovDetExi)
                {
                    //obtener el KardexValorizado completo
                    KardexValorizado iKarVal = MovimientoOCDetaRN.ArmarKardexValorizadoDeSaldoYMovimientoDeta(pSal,pCodigoMesProceso,
                        pCodigoMesAnterior, xMovDet);

                    //agregamos a la lista resultado
                    iLisRes.Add(iKarVal);
                }
            }

            //devolver
            return iLisRes;
        }

        public static KardexValorizado ArmarKardexValorizadoDeSaldoYMovimientoDeta(SaldoEN iSal, string pCodigoMesProceso,
            string pCodigoMesAnterior, MovimientoOCDetaEN pMovDet)
        {
            //objeto resultado
            //pasamos primero los datos que tendra del objeto saldo
            KardexValorizado iKarVal = SaldoRN.ArmarKardexValorizadoDeSoloSaldo(iSal,pCodigoMesProceso, pCodigoMesAnterior);

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

        public static MovimientoOCDetaEN HayStockSuficiente(MovimientoOCDetaEN pMovDet)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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

        public static MovimientoOCDetaEN ArmarAMovimientoDeta(InventarioDetaEN pInvDet, MovimientoOCCabeEN pMovCab, ExistenciaEN pExi,
         ParametroEN pPar,string pCorrelativoDeta)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetEN);
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ArmarAMovimientosDeta(List<InventarioDetaEN> pLisInvDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

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
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.ArmarAMovimientoDeta(xInvDet, pMovCab, iExiEncEN, iParEN, iCorrelativoDeta);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaDocumentosEmitidos(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarListasDeMovimientoDetasParaDocumentosEmitidos(pObj);
        }

        public static List<MovimientoOCDetaEN> ObtenerReporteDocumentosEmitidosResumen(MovimientoOCDetaEN pObj)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer la lista de listas de movimientosDeta para este reporte
            List<List<MovimientoOCDetaEN>> iLisLisMovDet = MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaDocumentosEmitidos(pObj);

            //recorrer cada lista
            foreach (List<MovimientoOCDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //creamos un nuevo objeto para el reporte
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.ArmarMovimientoDetaParaDocumentoEmitidoResumen(xLisMovDet);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN ArmarMovimientoDetaParaDocumentoEmitidoResumen(List<MovimientoOCDetaEN> pLisMovDetExi)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //pasamos datos
            iMovDetEN.CodigoTipo = pLisMovDetExi[0].CodigoTipo;
            iMovDetEN.NombreTipo = pLisMovDetExi[0].NombreTipo;
            iMovDetEN.CodigoExistencia = pLisMovDetExi[0].CodigoExistencia;
            iMovDetEN.DescripcionExistencia = pLisMovDetExi[0].DescripcionExistencia;

            //obtenemos los valores acumulados(Cantidad y costo)
            MovimientoOCDetaRN.AcumularCamposNumericos(iMovDetEN, pLisMovDetExi);

            //obtener el precio promedio para este objeto
            iMovDetEN.PrecioExistencia = Operador.DivisionDecimal(iMovDetEN.CostoMovimientoDeta, iMovDetEN.CantidadMovimientoDeta);
            iMovDetEN.PrecioExistencia = Math.Round(iMovDetEN.PrecioExistencia, 2);

            //devolver
            return iMovDetEN;
        }

        public static void AcumularCamposNumericos(MovimientoOCDetaEN pObj, List<MovimientoOCDetaEN> pLista)
        {
            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLista)
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

        public static List<MovimientoOCDetaEN> ObtenerReporteDocumentosEmitidosDetalle(MovimientoOCDetaEN pObj)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer la lista de listas de movimientosDeta para este reporte
            List<List<MovimientoOCDetaEN>> iLisLisMovDet = MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaDocumentosEmitidos(pObj);

            //recorrer cada lista
            foreach (List<MovimientoOCDetaEN> xLisMovDet in iLisLisMovDet)
            {                
                //adicionamos a la lista resultado
                iLisRes.AddRange(xLisMovDet);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ObtenerReporteRecordsExistencia(MovimientoOCDetaEN pObj)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer la lista de listas de movimientosDeta para este reporte
            List<List<MovimientoOCDetaEN>> iLisLisMovDet = MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaRecordsExistencia(pObj);

            //recorrer cada lista
            foreach (List<MovimientoOCDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //creamos un nuevo objeto para el reporte
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.ArmarMovimientoDetaParaRecordsExistencia(xLisMovDet);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //ordenar de mayor a menor cantidad      
            iLisRes.Sort((x, y) => y.CantidadMovimientoDeta.CompareTo(x.CantidadMovimientoDeta));

            //devolver
            return iLisRes;
        }

        public static List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaRecordsExistencia(MovimientoOCDetaEN pObj)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.CClaseTipoOperacion = "2";//salida
            iMovDetEN.CodigoTipoOperacion = string.Empty;
            iMovDetEN.Adicionales.Desde1 = pObj.Adicionales.Desde1;
            iMovDetEN.Adicionales.Hasta1 = pObj.Adicionales.Hasta1;
            iMovDetEN.CodigoAlmacen = pObj.CodigoAlmacen;

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaDocumentosEmitidos(iMovDetEN);
        }

        public static MovimientoOCDetaEN ArmarMovimientoDetaParaRecordsExistencia(List<MovimientoOCDetaEN> pLisMovDetExi)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //pasamos datos            
            iMovDetEN.CodigoExistencia = pLisMovDetExi[0].CodigoExistencia;
            iMovDetEN.DescripcionExistencia = pLisMovDetExi[0].DescripcionExistencia;
            iMovDetEN.CodigoUnidadMedida = pLisMovDetExi[0].CodigoUnidadMedida;

            //obtenemos los valores acumulados(Cantidad y costo)
            MovimientoOCDetaRN.AcumularCamposNumericos(iMovDetEN, pLisMovDetExi);

            //obtener el precio promedio para este objeto
            iMovDetEN.PrecioExistencia = Operador.DivisionDecimal(iMovDetEN.CostoMovimientoDeta, iMovDetEN.CantidadMovimientoDeta);
            iMovDetEN.PrecioExistencia = Math.Round(iMovDetEN.PrecioExistencia, 2);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaParaSalidasXCeCoDetalle(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientosDetaParaSalidasXCeCoDetalle(pObj);
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaParaControlMovimientosISDetalle(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientosDetaParaControlMovimientosISDetalle(pObj);
        }

        public static void EliminarMovimientoDetaXPeriodoYOrigen(MovimientoOCCabeEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.EliminarMovimientoDetaXPeriodoYOrigen(pObj);
        }

        public static void EliminarMovimientosDetaDeImportacion(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            MovimientoOCDetaRN.EliminarMovimientoDetaXPeriodoYOrigen(iMovCabEN);
        }

        public static void EliminarMovimientoDetaXPeriodoXOrigenYClase(MovimientoOCCabeEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.EliminarMovimientoDetaXPeriodoXOrigenYClase(pObj);
        }

        public static void EliminarMovimientosDetaDeImportacionIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "1";//ingreso
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            MovimientoOCDetaRN.EliminarMovimientoDetaXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static void EliminarMovimientosDetaDeImportacionSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "2";//salida
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion contabilidad

            //ejecutar metodo
            MovimientoOCDetaRN.EliminarMovimientoDetaXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXExistencia(ExistenciaEN pObj, List<List<MovimientoOCDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //recorrer cada objeto
            foreach (List<MovimientoOCDetaEN> xLisMovDet in pLisLisMovDet)
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

        public static List<MovimientoOCDetaEN> FiltrarMovimientoDeta(List<MovimientoOCDetaEN> pLista, string pCampoFiltro, string pValorFiltro)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorFiltro.ToUpper();

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xPer in pLista)
            {
                string iTexto = MovimientoOCDetaRN.ObtenerValorDeCampo(xPer, pCampoFiltro).ToUpper();
                if (iTexto == iValor)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string CadenaCodigosExistenciasParaIN(List<MovimientoOCDetaEN> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLista)
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

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaEmpaquetar(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaEmpaquetar(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaEmpaquetar(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoSemiElaborado(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoSemiElaborado(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoSemiElaborado(pProDet, pMovCab, iCenCosEN);

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

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionDeta(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientosDetaXClaveProduccionDeta(pObj);
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionDeta(string pClaveProduccionDeta)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarMovimientosDetaXClaveProduccionDeta(iMovDetEN);
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionDeta(ProduccionDetaEN pObj)
        {
            //asignar parametros          
            string iClaveProduccionDeta = pObj.ClaveProduccionDeta;
            
            //ejecutar metodo
            return MovimientoOCDetaRN.ListarMovimientosDetaXClaveProduccionDeta(iClaveProduccionDeta);
        }

        public static bool EsActoDigitarPrecioUnitarioConversion(MovimientoOCDetaEN pObj)
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

        public static bool EsActoDigitarPrecioUnitario(MovimientoOCDetaEN pObj)
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

        public static bool EsActoDigitarCantidadConversion(MovimientoOCDetaEN pObj)
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

        public static bool EsActoDigitarCantidad(MovimientoOCDetaEN pObj)
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

        public static decimal ObtenerPrecioUnitarioConvertidoSugerido(MovimientoOCDetaEN pObj)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = MovimientoOCDetaRN.EsActoDigitarPrecioUnitarioConversion(pObj);

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

        public static decimal ObtenerPrecioUnitarioSugerido(MovimientoOCDetaEN pMocDet)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = MovimientoOCDetaRN.EsActoDigitarPrecioUnitario(pMocDet);

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

        public static decimal ObtenerCantidadConvertidoSugerido(MovimientoOCDetaEN pObj)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = MovimientoOCDetaRN.EsActoDigitarCantidadConversion(pObj);

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

        public static decimal ObtenerCantidadSugerido(MovimientoOCDetaEN pMocDet, List<LoteEN> pLisLotExi)
        {
            //valor resultado
            decimal ivalor = 0;

            //preguntar si se puede editar en este campo
            bool iEsDigitable = MovimientoOCDetaRN.EsActoDigitarCantidad(pMocDet);

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

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaNoPasan(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaNoPasan(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaNoPasan(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaUnidadesReproceso(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaUnidadesReproceso(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaUnidadesReproceso(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobrante(MovimientoOCDetaEN pObj, string pCodigoAlmacenIngresoTransferencia)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //validar
            //listar las existencias que estan separadas con las cantidades de unidades que le sobran
            List<ExistenciaEN> iLisExiSob = ExistenciaRN.ListarExistenciasSobrantesOC(pObj, pCodigoAlmacenIngresoTransferencia);

            //validando
            iMovDetEN = MovimientoOCDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, iLisExiSob);

            //ok
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN EsCantidadMovimientoDetaCorrecta(MovimientoOCDetaEN pObj)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadMovimientoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            MovimientoOCDetaEN iMovDetStoEN = MovimientoOCDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de compras para produccion           
            if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            //valida cuando la cantidad a sacar es mayor a las permitidas
            MovimientoOCDetaEN iMovDetCanSacEN = MovimientoOCDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, string.Empty);
            if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN EsCantidadTransferenciaMovimientoDetaCorrecta(MovimientoOCDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadMovimientoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            MovimientoOCDetaEN iMovDetStoEN = MovimientoOCDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de compras para produccion           
            if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            //valida cuando la existencia no es almacen de produccion           
            if (FormulaDetaRN.EsAlmacenDeProduccion(pCodigoAlmacenProduccion) == false) { return iMovDetEN; }

            //valida cuando la cantidad a transferir es diferente a lo que pide la produccion actual
            MovimientoOCDetaEN iMovDetCanDifEN = MovimientoOCDetaRN.ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(pObj,
                pCodigoAlmacenProduccion);
            if (iMovDetCanDifEN.Adicionales.EsVerdad == false) { return iMovDetCanDifEN; }

            //valida cuando la cantidad a sacar es mayor a las permitidas
            MovimientoOCDetaEN iMovDetCanSacEN = MovimientoOCDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj,
                pCodigoAlmacenProduccion);
            if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN EsCantidadTransferenciaMovimientoDetaCorrectaNew(MovimientoOCDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadMovimientoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            MovimientoOCDetaEN iMovDetStoEN = MovimientoOCDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            ////valida cuando la existencia no es almacen de compras para produccion           
            //if (FormulaDetaRN.EsAlmacenDeCompra(pObj.CodigoAlmacen) == false) { return iMovDetEN; }

            ////valida cuando la existencia no es almacen de produccion           
            //if (FormulaDetaRN.EsAlmacenDeProduccion(pCodigoAlmacenProduccion) == false) { return iMovDetEN; }

            ////valida cuando la cantidad a transferir es diferente a lo que pide la produccion actual
            //MovimientoOCDetaEN iMovDetCanDifEN = MovimientoOCDetaRN.ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(pObj,
            //    pCodigoAlmacenProduccion);
            //if (iMovDetCanDifEN.Adicionales.EsVerdad == false) { return iMovDetCanDifEN; }

            ////valida cuando la cantidad a sacar es mayor a las permitidas
            //MovimientoOCDetaEN iMovDetCanSacEN = MovimientoOCDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj,
            //    pCodigoAlmacenProduccion);
            //if (iMovDetCanSacEN.Adicionales.EsVerdad == false) { return iMovDetCanSacEN; }

            //devolver
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN ValidaCuandoCantidadTransferenciaEsDiferenteAProduccion(MovimientoOCDetaEN pObj,
             string pCodigoAlmacenProduccion)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //validar
            //obtener la cantidad que se necesita para produccion(solo partes de trabajo)
            decimal iCantidadProduccion = ProduccionExisRN.ObtenerCantidadNecesariaParaProducirOC(pObj, pCodigoAlmacenProduccion);

            //si hay cantidad produccion
            if (iCantidadProduccion != 0 && iCantidadProduccion != pObj.CantidadMovimientoDeta)
            {
                iMovDetEN.Adicionales.EsVerdad = false;
                iMovDetEN.Adicionales.Mensaje = "Te falta transferir de almacen de produccion a cocina la cantidad de:" + iCantidadProduccion.ToString();                         
            }
           
            //ok
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN EsCantidadAdicionalMovimientoDetaCorrecta(MovimientoOCDetaEN pObj)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //valida cuando la cantidad es cero
            if (pObj.CantidadMovimientoDeta == 0) { return iMovDetEN; }

            //valida cuando no hay la cantidad en stock 
            MovimientoOCDetaEN iMovDetStoEN = MovimientoOCDetaRN.HayStockSuficiente(pObj);
            if (iMovDetStoEN.Adicionales.EsVerdad == false) { return iMovDetStoEN; }

            //valida cuando la existencia no es almacen de produccion           
            if (FormulaDetaRN.EsAlmacenDeProduccion(pObj.CodigoAlmacen) == false) { return iMovDetEN; }
            
            //valida cuando la cantidad a sacar es mayor a las permitidas
            MovimientoOCDetaEN iMovDetCanSacEN = MovimientoOCDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobranteOC(pObj);
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

        public static MovimientoOCDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobranteOC(MovimientoOCDetaEN pObj)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //validar
            //listar las existencias que estan separadas con las cantidades de unidades que le sobran
            List<ExistenciaEN> iLisExiSob = ExistenciaRN.ListarExistenciasSobrantesOC(pObj);

            //validando
            iMovDetEN = MovimientoOCDetaRN.ValidaCuandoCantidadASacarEsMayorACantidadSobrante(pObj, iLisExiSob);

            //ok
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN ValidaCuandoCantidadASacarEsMayorACantidadSobrante(MovimientoOCDetaEN pObj,
            List<ExistenciaEN>  pListaExistenciasSobrantes)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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

        public static List<List<MovimientoOCDetaEN>> ListarListasMovimientosDetaParaImportar(List<MovimientoOCDetaEN> pLista)
        {
            //asignar parametros
            List<string> iLisCam = new List<string>();
            iLisCam.Add(MovimientoOCDetaEN.FecMovCab);
            iLisCam.Add(MovimientoOCDetaEN.OrdCom);
            iLisCam.Add(MovimientoOCDetaEN.CodAlm);

            //ejecutar metodo
            return ListaG.ListarListas<MovimientoOCDetaEN>(pLista, iLisCam);
        }

        public static decimal ObtenerPrecioUnitarioConvertido(MovimientoOCDetaEN pObj, decimal pPrecioUnitarioImportadoExcel)
        {
            //asignar parametros
            pObj.PrecioUnitarioConversion = pPrecioUnitarioImportadoExcel;

            //ejecutar metodo
            return ObtenerPrecioUnitarioConvertidoSugerido(pObj);
        }

        public static decimal ObtenerPrecioUnitario(MovimientoOCDetaEN pObj, decimal pPrecioUnitarioImportadoExcel)
        {
            //asignar parametros
            pObj.PrecioUnitarioMovimientoDeta = pPrecioUnitarioImportadoExcel;

            //ejecutar metodo
            return ObtenerPrecioUnitarioSugerido(pObj);
        }

        public static decimal ObtenerCantidadConvertido(MovimientoOCDetaEN pObj, decimal pCantidadImportadoExcel)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = ObjetoG.Clonar<MovimientoOCDetaEN>(pObj);
            iMovDetEN.CEsLote = "0";
            iMovDetEN.CantidadConversion = pCantidadImportadoExcel;

            //ejecutar metodo
            return ObtenerCantidadConvertidoSugerido(iMovDetEN);
        }

        public static decimal ObtenerCantidad(MovimientoOCDetaEN pObj, decimal pCantidadImportadoExcel)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = ObjetoG.Clonar<MovimientoOCDetaEN>(pObj);
            iMovDetEN.CEsLote = "0";
            iMovDetEN.CantidadMovimientoDeta = pCantidadImportadoExcel;
            List<LoteEN> iLisLot = new List<LoteEN>();

            //ejecutar metodo
            return ObtenerCantidadSugerido(iMovDetEN, iLisLot);
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoUnidadesReproceso(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoUnidadesReproceso(LiberacionEN pLib, 
            MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesReproceso(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaEmpaquetar(ProduccionProTerEN pProProTer, MovimientoOCCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaEmpaquetar(EncajadoEN pEnc, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaEmpaquetar(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadMovimientoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }
            
            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoMercaderia(EncajadoEN pEnc, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

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
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoMercaderia(xProProTer, pMovCab, iCenCosEN);

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaParaSaldosXExistencia(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientosDetaParaSaldosXExistencia(pObj);
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoUnidadesDonacion(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoUnidadesDonacion(LiberacionEN pLib, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesDonacion(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoUnidadesDesechos(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoUnidadesDesechas(LiberacionEN pLib, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesDesechos(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void Recalcular(string pAño, string pCodigoMes,List<ExistenciaEN> pLisExi,List<SaldoEN> pLisSal,
            List<List< MovimientoOCDetaEN>> pLisLisMovDet)
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
                List<MovimientoOCDetaEN> iLisMovDetExi = MovimientoOCDetaRN.ListarMovimientosDetaXExistencia(iExiEncEN, pLisLisMovDet);

                //recorrer cada objeto movimiento deta de la existencia
                foreach (MovimientoOCDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del movimiento deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio
                    xMovDet.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    xMovDet.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;
                    xMovDet.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(xMovDet);
                    xMovDet.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(xMovDet);
                    xMovDet.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    xMovDet.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

                    //ahora pasamos el nuevo stock y precio promedio a la existencia
                    iExiEncEN.StockActualExistencia = xMovDet.StockExistencia;
                    iExiEncEN.PrecioPromedioExistencia = xMovDet.PrecioExistencia;

                    //vamos acumulando los ingresos o salidas en el objeto saldo(iSalEncEN)
                    iIngresoAcumulado += MovimientoOCDetaRN.ObtenerCantidadIngresada(xMovDet);
                    iSalidaAcumulado += MovimientoOCDetaRN.ObtenerCantidadSalida(xMovDet);

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

        public static List<List<MovimientoOCDetaEN>> FiltrarPorFechaMenorOIgualQue(List<List<MovimientoOCDetaEN>> pLisLis, string pFechaCompara)
        {
            //lista resultado
            List<List<MovimientoOCDetaEN>> iLisRes = new List<List<MovimientoOCDetaEN>>();

            //recorrer cada lista
            foreach (List<MovimientoOCDetaEN> xLisMovDet in pLisLis)
            {
                //creamos la nueva lista filtrada
                List<MovimientoOCDetaEN> iLisMovDet = new List<MovimientoOCDetaEN>();

                //recorrer cada objeto
                foreach (MovimientoOCDetaEN xMovDet in xLisMovDet)
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

        public static void EliminarMovimientoDetaXPeriodoYAlmacen(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.EliminarMovimientoDetaXPeriodoYAlmacen(pObj);
        }

        public static void EliminarMovimientosDetaAlmacenProduccionParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovDetEN.CodigoAlmacen = "A10";//almacen de produccion

            //ejecutar metodo
            MovimientoOCDetaRN.EliminarMovimientoDetaXPeriodoYAlmacen(iMovDetEN);
        }

        public static void EliminarMovimientoDetaAlmacenesCompraParaRegenerar(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.EliminarMovimientoDetaAlmacenesCompraParaRegenerar(pObj);
        }

        public static void EliminarMovimientosDetaAlmacenesCompraParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            
            //ejecutar metodo
            MovimientoOCDetaRN.EliminarMovimientoDetaAlmacenesCompraParaRegenerar(iMovDetEN);
        }

        public static void ExistenciasActualizadasPorAdicionMovimientosDeta(List<MovimientoOCDetaEN> pLisMovDet,List<ExistenciaEN> pLisExi)
        {
            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = MovimientoOCDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //actualizar datos
                iExiEN.PrecioPromedioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iExiEN, xMovDet);
                iExiEN.StockActualExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iExiEN, xMovDet);
                
                //modificar el cambio en existencia
                ListaG.Modificar<ExistenciaEN>(pLisExi, iExiEN, ExistenciaEN.ClaExi, iExiEN.ClaveExistencia);
            }
        }

        public static List<List<MovimientoOCDetaEN>> ListaListasMovimientosDetaPorFechaMenorOIgualQue(string pCodigoPeriodo, string pfechaCompara)
        {
            //traer todo el movimiento deta del periodo elegido, para el recalculo          
            List<List<MovimientoOCDetaEN>> iLisLisMovDetExi = MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaRecalculo(pCodigoPeriodo);

            return MovimientoOCDetaRN.FiltrarPorFechaMenorOIgualQue(iLisLisMovDetExi, pfechaCompara);
        }

        public static List<MovimientoOCDetaEN> TransformarAMovimientosDeta(List<ProduccionExisEN> pLisProExi, MovimientoOCCabeEN pMovCab,List<ExistenciaEN> pLisExi)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();
            
            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la existencia en proceso
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //creamos un objeto movimientoDeta desde xProExi
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.TransformarAMovimientoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static void AdicionarMovimientoDetaPorSalidaInsumos(List<ProduccionExisEN> pLisProExi, MovimientoOCCabeEN pMovCab, List<ExistenciaEN> pLisExi)
        {
            //actualizar clase operacion
            pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a MovimientoDeta
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.TransformarAMovimientosDeta(pLisProExi, pMovCab, pLisExi);

            //adicionar masivo
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public static List<MovimientoOCDetaEN> ObtenerMovimientoDetaRecalculada(string pAño, string pCodigoMes, List<ExistenciaEN> pLisExi, List<SaldoEN> pLisSal,
           List<List<MovimientoOCDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

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
                List<MovimientoOCDetaEN> iLisMovDetExi = MovimientoOCDetaRN.ListarMovimientosDetaXExistencia(iExiEncEN, pLisLisMovDet);

                //recorrer cada objeto movimiento deta de la existencia
                foreach (MovimientoOCDetaEN xMovDet in iLisMovDetExi)
                {
                    //actualizamos los datos del movimiento deta con los datos de la existencia                
                    //actualizar el precio unitario, ya que este puede estar mal solo en caso
                    //de que no calcula precio promedio
                    xMovDet.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    xMovDet.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;
                    xMovDet.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(xMovDet);
                    xMovDet.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(xMovDet);
                    xMovDet.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(xMovDet);
                    xMovDet.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);

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

        public static List<MovimientoOCDetaEN> ObtenerMovimientoDetaRecalculada(string pAño, string pCodigoMes)
        {
            //asignar parametros
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();
            List<SaldoEN> iLisSalAño = SaldoRN.ListarSaldosDeAño(pAño);
            List<List<MovimientoOCDetaEN>> iLisLisMovDetExi = MovimientoOCDetaRN.ListarListasDeMovimientoDetasParaRecalculo(pAño, pCodigoMes);

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerMovimientoDetaRecalculada(pAño, pCodigoMes, iLisExiEmp, iLisSalAño, iLisLisMovDetExi);
        }

        public static List<List<MovimientoOCDetaEN>> ListarListasMovimientosDetaReprocesoParaRecalculo(List<MovimientoOCDetaEN> pLisMovDet)
        {
            //asignar parametros
            List<MovimientoOCDetaEN> iLisMovDet = ListaG.Filtrar<MovimientoOCDetaEN>(pLisMovDet, MovimientoOCDetaEN.CodAlm, "A18");//solo almacen reproceso(A18)
            List<string> iLisCamposClave = new List<string>() { MovimientoOCDetaEN.CodExi, MovimientoOCDetaEN.FecMovCab };            

            //ejecutar metodo
            return ListaG.ListarListas<MovimientoOCDetaEN>(iLisMovDet, iLisCamposClave);
        }

        public static decimal ObtenerPrecioUnitarioPorRecalculoReproceso(MovimientoOCDetaEN pMovDet, List<LiberacionEN> pLisLib)
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
                iValor = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(pMovDet);
            }

            //devolver
            return iValor;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXPeriodo(string pCodigoPeriodo)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientosDetaXPeriodo(pCodigoPeriodo);
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaEmpaquetarRE(RetiquetadoEN pRet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaEmpaquetarRE(RetiquetadoEN pRet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaEmpaquetarRE(pRet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoMercaderiaRE(RetiquetadoEN pRet, MovimientoOCCabeEN pMovCab,   ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoMercaderiaRE(RetiquetadoEN pRet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoMercaderiaRE(pRet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void AdicionarMovimientoDetaPorIngresoInsumos(List<ProduccionExisEN> pLisProExi, MovimientoOCCabeEN pMovCab)
        {
            //actualizar clase operacion
            pMovCab.CClaseTipoOperacion = "1";//ingreso

            //transformar la lista de ProduccionExis a MovimientoDeta
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.TransformarAMovimientosDetaDesmedro(pLisProExi, pMovCab);

            //adicionar masivo
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public static List<MovimientoOCDetaEN> TransformarAMovimientosDetaDesmedro(List<ProduccionExisEN> pLisProExi, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

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
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.TransformarAMovimientoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoUnidadesMuestra(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoUnidadesMuestra(LiberacionEN pLib, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesMuestra(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerPrecioUnitarioConFlete(MovimientoOCDetaEN pObj, decimal pCostoFleteUnitario)
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

        public static decimal ObtenerPrecioUnitarioSinFlete(MovimientoOCDetaEN pObj)
        {
            //valor resultado
            decimal iValor = pObj.PrecioUnitarioMovimientoDeta;

            //primero restamos el flete unitario anterior
            iValor -= pObj.CostoFleteMovimientoDeta;
            
            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoSinFlete(MovimientoOCDetaEN pObj)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.PrecioUnitarioMovimientoDeta= ObtenerPrecioUnitarioSinFlete(pObj);
            iMovDetEN.CantidadMovimientoDeta = pObj.CantidadMovimientoDeta;

            //ejecutar metodo
            return ObtenerCosto(iMovDetEN);
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaParaActualizarCostosProduccionExis(List<ProduccionExisEN> pLisProExi, List<List<MovimientoOCDetaEN>> pLisLisMovDet)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //recorrer cada objeto ProduccionExis
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar a la lista de la existencia de compras para este xProExi
                List<MovimientoOCDetaEN> iLisMovDetExi = ListaG.Buscar<MovimientoOCDetaEN>(pLisLisMovDet, MovimientoOCDetaEN.CodAlm, xProExi.CodigoAlmacenCompra,
                    MovimientoOCDetaEN.CodExi, xProExi.CodigoExistencia);

                //lista de movimientos a lo mas iguales a la fecha de produccionDeta
                MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

                //recorrer cada objeto
                foreach (MovimientoOCDetaEN xMovDet in iLisMovDetExi)
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

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoSemElaObservadas(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoSemElaMuestraProduccion(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoSemElaContraMuestra(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoSemElaObservadas(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoSemElaObservadas(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoSemElaMuestraProduccion(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoSemElaMuestraProduccion(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoSemElaContraMuestra(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoSemElaContraMuestra(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaEmpaquetarObservado(ProduccionProTerEN pProProTer, MovimientoOCCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaEmpaquetarObservados(EncajadoEN pEnc, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaEmpaquetarObservado(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadMovimientoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoUnidadesObservados(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoUnidadesSaldo(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoUnidadesObservados(LiberacionEN pLib,
            MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesObservados(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoUnidadesSaldo(LiberacionEN pLib,
           MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesSaldo(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionProTer(string pClaveProduccionProTer)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveProduccionProTer = pClaveProduccionProTer;
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarMovimientosDetaXClaveProduccionProTer(iMovDetEN);
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionProTer(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientosDetaXClaveProduccionProTer(pObj);
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoCuarentenaQali(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoCuarentenaQali(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoCuarentenaQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoReprocesoQali(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoMuestraQali(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoReprocesoQali(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoReprocesoQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoMuestraQali(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoMuestraQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoDesechoQali(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab,
           ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoDesechoQali(ProduccionDetaEN pProDet, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoDesechoQali(pProDet, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaEmpaquetarCuarentena(ProduccionProTerEN pProProTer, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaEmpaquetarCuarentena(EncajadoEN pEnc, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listar los ProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pEnc.ClaveEncajado);

            //recorrer cada objeto ProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //crear el unico objeto para esta lista
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaEmpaquetarCuarentena(xProProTer, pMovCab, iCenCosEN);

                //si la cantidad es cero no pasa
                if (iMovDetEN.CantidadMovimientoDeta == 0) { continue; }

                //adicionamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaSalidasAdicionalesProduccionProTer(string pClaveProduccionProTer)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer todos los movimientos deta de esta ProduccionProTer de bd
            iLisRes = ListarMovimientosDetaXClaveProduccionProTer(pClaveProduccionProTer);

            //filtrar que solo sean salidas y almacen "A11"
            iLisRes = ListaG.Filtrar<MovimientoOCDetaEN>(iLisRes, MovimientoOCDetaEN.CClaTipOpe, "2", MovimientoOCDetaEN.CodAlm, "A11");

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(string pClaveProduccionProTerParteEmpaquetado)
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveProduccionProTerParteEmpaquetado = pClaveProduccionProTerParteEmpaquetado;
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(iMovDetEN);
        }

        public static List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            return iPerAD.ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(pObj);
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaTransferenciaUnidadesReproceso(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaTransferenciaUnidadesReproceso(LiberacionEN pLib,
            MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaTransferenciaUnidadesReproceso(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaTransferenciaUnidadesDonacion(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaTransferenciaUnidadesDonacion(LiberacionEN pLib, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaTransferenciaUnidadesDonacion(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaTransferenciaUnidadesDesecha(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
          ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaTransferenciaUnidadesDesechas(LiberacionEN pLib, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaTransferenciaUnidadesDesecha(pLib, pMovCab, iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaSalidaTransferenciaUnidadesPacking(LiberacionEN pLib, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaSalidaTransferenciaUnidadesPacking(LiberacionEN pLib,
            MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaTransferenciaUnidadesPacking(pLib, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static void AdicionarMovimientoDetaPorSalidaEtiquetaSegundaLiberacion(List<ProduccionExisEN> pLisProExi, MovimientoOCCabeEN pMovCab)
        {
            //actualizar clase operacion
            pMovCab.CClaseTipoOperacion = "2";//salida

            //transformar la lista de ProduccionExis a MovimientoDeta
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.TransformarAMovimientosDetaSalidaEtiquetaSegundaLiberacion(pLisProExi, pMovCab);

            //adicionar masivo
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public static List<MovimientoOCDetaEN> TransformarAMovimientosDetaSalidaEtiquetaSegundaLiberacion(List<ProduccionExisEN> pLisProExi, MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

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
                MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.TransformarAMovimientoDeta(xProExi, pMovCab, iExiEncEN, iParEN);

                //agregamos a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCDetaEN> ListarMovimientoDetaParaIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pProProTer,
           MovimientoOCCabeEN pMovCab)
        {
            //lista resultado
            List<MovimientoOCDetaEN> iLisRes = new List<MovimientoOCDetaEN>();

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //crear el unico objeto para esta lista
            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesSegundaLiberacion(pProProTer, pMovCab,
                iCenCosEN);

            //adicionamos a la lista resultado
            iLisRes.Add(iMovDetEN);

            //devolver
            return iLisRes;
        }

        public static MovimientoOCDetaEN CrearMovimientoDetaParaIngresoUnidadesSegundaLiberacion(ProduccionProTerEN pProProTer, MovimientoOCCabeEN pMovCab,
         ItemEEN pCenCos)
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

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
            iMovDetEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetEN);
            iMovDetEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
            iMovDetEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);
            iMovDetEN.ClaveMovimientoCabe = pMovCab.ClaveMovimientoCabe;
            iMovDetEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

            //devolver
            return iMovDetEN;
        }

        public static void ActualizarCantidadRecibidayPendiente(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.ActualizarCantidadRecibidayPendiente(pObj);
        }

        public static void ActualizarCantidadRecibidayClaveMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            MovimientoOCDetaAD iPerAD = new MovimientoOCDetaAD();
            iPerAD.ActualizarCantidadRecibidayClaveMovimientoDeta(pObj);
        }

    }
}
