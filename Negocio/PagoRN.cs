using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;
//using System.Windows.Forms;
using System.Windows.Forms;

namespace Negocio
{
    public class PagoRN
    {

        public static PagoEN EnBlanco()
        {
            PagoEN iCobEN = new PagoEN();
            return iCobEN;
        }

        public static void AdicionarPago(PagoEN pObj)
        {
            PagoAD iPagAD = new PagoAD();
            pObj.AnoPago = Fecha.ObtenerAño(pObj.FechaPago);
            pObj.CMesPago = Fecha.ObtenerMes(pObj.FechaPago);
            //validar si es descuento o mora
            if (pObj.MontoDescuentoPago < 0) { pObj.MontoMoraPago = 0; }
            if (pObj.MontoDescuentoPago > 0) { pObj.MontoDescuentoPago = 0; }
            iPagAD.AdicionarPago(pObj);
        }

        public static void AdicionarPagoMasivo(List<PagoEN> pLista)
        {
            PagoAD iCobAD = new PagoAD();
            iCobAD.AdicionarPagoMasivo(pLista);
        }

        public static void ModificarPago(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            iCobAD.ModificarPago(pObj);
        }

        public static void ModificarPago(List<PagoEN> pLista)
        {
            PagoAD iCobAD = new PagoAD();
            iCobAD.ModificarPago(pLista);
        }

        public static void EliminarPagoXCorrelativo(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            iCobAD.EliminarPagoXCorrelativo(pObj);
        }

        public static void EliminarPagoMasiva(List<PagoEN> pLista)
        {
            PagoAD iCobAD = new PagoAD();
            iCobAD.EliminarPagoMasiva(pLista);
        }

        public static PagoEN BuscarPagoXCorrelativo(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            return iCobAD.BuscarPagoXCorrelativo(pObj);
        }

        public static List<PagoEN> ListarPagosXContrato(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            return iCobAD.ListarPagosXContrato(pObj);
        }

        //public static void AdicionarPagoDeRecepcion(DetalleRecepcionRecEN pDetRec, RecepcionRecEN pRec)
        //{
        //    //si no se aplico entonces no hay Pago
        //    if (pDetRec.CFlagDetalleRecepcion == "0") { return; }

        //    //sino encuentra a la cuota no genera Pago
        //    if (pDetRec.Cuota.ClaveCuota == string.Empty) { return; }

        //    //pasar datos
        //    PagoEN iCobEN = new PagoEN();
        //    iCobEN.CodigoEmpresa = pDetRec.Cuota.CodigoEmpresa;
        //    iCobEN.CodigoProyecto = pDetRec.Cuota.CodigoProyecto;
        //    iCobEN.FechaPagoCuota = pDetRec.Cuota.FechaPagoCuota;
        //    iCobEN.FechaPagoCuota = pDetRec.Cuota.FechaPagoCuota;
        //    iCobEN.FechaPago = DateTime.Now.ToShortDateString();
        //    iCobEN.ClaveCuota = pDetRec.Cuota.ClaveCuota;
        //    iCobEN.NumeroContrato = pDetRec.Cuota.NumeroContrato;
        //    iCobEN.FechaVencimientoCuota = pDetRec.Cuota.FechaVencimientoCuota;
        //    iCobEN.EtapaLote = pDetRec.Cuota.EtapaLote;
        //    iCobEN.ManzanaLote = pDetRec.Cuota.ManzanaLote;
        //    iCobEN.NumeroLote = pDetRec.Cuota.NumeroLote;
        //    iCobEN.CodigoCliente = pDetRec.Cuota.CodigoCliente;
        //    iCobEN.MontoCuota = pDetRec.Cuota.MontoCuota;
        //    iCobEN.FechaDepositoPago = pDetRec.FechaPago;
        //    iCobEN.CuotaPendienteAnterior = pDetRec.Cuota.MontoPendienteCuota;
        //    iCobEN.MoraAnterior = pDetRec.Cuota.MontoMora;
        //    iCobEN.MoraPendienteAnterior = pDetRec.Cuota.MontoMoraPendiente;
        //    iCobEN.ImportePago = iCobEN.CuotaPendienteAnterior + iCobEN.MoraPendienteAnterior;
        //    iCobEN.MontoDescuentoPago = 0;
        //    iCobEN.MontoMoraPago = pDetRec.ImporteMora;
        //    iCobEN.MontoProtestoPago = 0;
        //    iCobEN.MontoOtrosPago = 0;
        //    iCobEN.MontoaCobrarPago = pDetRec.ImporteTotal;
        //    iCobEN.CuotaPagadaPago = pDetRec.Cuota.MontoPendienteCuota;
        //    iCobEN.MoraPagadaPago = pDetRec.ImporteMora;
        //    iCobEN.MontoCobradoPago = pDetRec.ImporteTotal;
        //    iCobEN.CFormaCobroPago = "0";//total
        //    iCobEN.CModoCobroPago = pDetRec.MonedaPago;
        //    iCobEN.MontoDolaresPago = Cadena.CompararDosValores(pDetRec.MonedaPago, "0", 0, pDetRec.ImporteTotal);
        //    iCobEN.MontoSolesPago = Cadena.CompararDosValores(pDetRec.MonedaPago, "0", pDetRec.ImporteTotal, 0);            
        //    iCobEN.TipoCambioPago = 1;
        //    iCobEN.CLugarPago = "0";
        //    iCobEN.ObservacionPago = "Recaudacion de la cuenta N°: " + pRec.NumeroCuentaBanco;
        //    iCobEN.ClaveCuentaBanco = pRec.ClaveCuentaBanco;
        //    iCobEN.CTipoPago = "0";
        //    iCobEN.ClaveComprobante = pDetRec.ClaveComprobante;
        //    iCobEN.CorrelativoPago = PagoRN.ObtenerCorrelativoPago(iCobEN);
        //    iCobEN.CGeneroMoraFijaAnterior = pDetRec.Cuota.CGeneroMoraFija;

        //    //adicionar en b.d
        //    PagoRN.AdicionarPago(iCobEN);

        //    //actualizamos el campo correlativoPago del detalleRec 
        //    pDetRec.CorrelativoPago = iCobEN.CorrelativoPago;
        //}

        public static string ObtenerCorrelativoPago(PagoEN pCob)
        {
            //el nuevo correlativo
            string iNuevoNumero;

            //traer una lista de todas las Pagos de un contrato
            List<PagoEN> iLisCob = new List<PagoEN>();
            pCob.Adicionales.CampoOrden = PagoEN.CorPag;
            iLisCob = PagoRN.ListarPagosXContrato(pCob);

            //la estructura del correlativo Pago sera:
            //ClaveContrato + correlativo
            //si la lista esta vacia se crea el primer correlativo      
            int iNumeroPagos = iLisCob.Count;
            if (iNumeroPagos == 0)
            {
                iNuevoNumero = Universal.gCodigoEmpresa + "-" + pCob.NumeroContrato + "-" + "0001";
            }
            else
            {
                string iUltimoCorrelativo = iLisCob[iNumeroPagos - 1].CorrelativoPago;
                int iLongitudCorrelativo = iUltimoCorrelativo.Length;
                int iIndicePartida = iLongitudCorrelativo - 4;
                int iCorrelativo = Convert.ToInt32(iUltimoCorrelativo.Substring(iIndicePartida));
                iCorrelativo++;
                iNuevoNumero = Universal.gCodigoEmpresa + "-" + pCob.NumeroContrato + "-" + iCorrelativo.ToString().PadLeft(4, Convert.ToChar("0"));
            }
            return iNuevoNumero;
        }

        //public static string ObtenerTodosLosCorrelativosPago(List<DetalleRecepcionRecEN> pLisDetRec)
        //{
        //    //cadena resultado
        //    string iStr = string.Empty;

        //    //recorremos cada objeto
        //    foreach (DetalleRecepcionRecEN xDetRec in pLisDetRec)
        //    {
        //        if (xDetRec.CorrelativoPago != string.Empty)
        //        {
        //            iStr += "'" + xDetRec.CorrelativoPago + "'" + ",";
        //        }
        //    }

        //    //si el Str esta lleno entonces sacar a la ultima coma
        //    if (iStr.Length != 0)
        //    {
        //        iStr = iStr.Remove(iStr.Length - 1);
        //    }
        //    else
        //    {
        //        iStr = "''";
        //    }
        //    return iStr;
        //}

        public static List<PagoEN> ListarPagosDeRecepcionRec(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            return iCobAD.ListarPagosGeneradasDeRecepcionRec(pObj);
        }

        public static PagoEN buscarPagoXClaveCuota(PagoEN pObj, List<PagoEN> pLista)
        {
            // Objeto resultado
            PagoEN iCobEN = new PagoEN();

            //Buscar en lista
            foreach (PagoEN xCob in pLista)
            {
                if (pObj.ClaveCuota == xCob.ClaveCuota)
                {
                    iCobEN = xCob;
                    return iCobEN;
                }
            }
            return iCobEN;
        }

        public static List<PagoEN> ListarPagosXFiltro(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            return iCobAD.ListarPagoXFiltro(pObj);
        }

        public static string ObtenerCodigoBanco(string pClaveBanco)
        {
            //valor resultado
            string iCodigo = pClaveBanco.Trim();

            //si esta en blanco no ase nada
            if (iCodigo == string.Empty)
            {
                return iCodigo;
            }

            //si es menor a longitud 5
            if (iCodigo.Length < 5)
            {
                return iCodigo;
            }

            //cortar
            iCodigo = iCodigo.Substring(4);

            //devolver
            return iCodigo;
        }

        public static List<PagoEN> ListarPagosXRangoFechaPago(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            return iCobAD.ListarPagosXRangoFechaPago(pObj);
        }

        public static decimal CalculoMontoAPagar(decimal pCuotaAPagar, decimal pMoraAPagar)
        {
            return pCuotaAPagar + pMoraAPagar;
        }

        public static decimal CalculoMontoEnDolares(PagoEN pCob, string pMonedaLetra)
        {
            decimal iDolares = 0;
            switch (pCob.CModoCobroPago)
            {
                case "0":
                case "2":
                    {
                        return iDolares;
                    }

                case "1": //dolares
                    {
                        //de que moneda es la letra
                        switch (pMonedaLetra)
                        {
                            case "0"://soles
                                {
                                    return Conversion.DeSolesADolares(pCob.MontoCobradoPago, pCob.TipoCambioPago);
                                }

                            case "1": // dolares
                                {
                                    return pCob.MontoCobradoPago;
                                }
                        }
                        break;
                    }
            }
            return iDolares;
        }

        public static decimal CalculoMontoEnSoles(PagoEN pCob, string pMonedaLetra)
        {
            decimal iSoles = 0;
            switch (pCob.CModoCobroPago)
            {
                case "0"://soles
                    {
                        //de que moneda es la letra
                        switch (pMonedaLetra)
                        {
                            case "0"://soles
                                {
                                    return pCob.MontoCobradoPago;
                                }

                            case "1": // dolares
                                {
                                    return Conversion.DeDolaresASoles(pCob.MontoCobradoPago, pCob.TipoCambioPago);
                                }
                        }
                        break;
                    }
                case "1": //dolares
                    {
                        return iSoles;
                    }

                case "2": //ambos
                    {
                        //de que moneda es la letra
                        switch (pMonedaLetra)
                        {
                            case "0"://soles
                                {
                                    iSoles = pCob.MontoCobradoPago - pCob.MontoDolaresPago * pCob.TipoCambioPago;
                                    return iSoles;
                                }

                            case "1": // dolares
                                {
                                    iSoles = (pCob.MontoCobradoPago - pCob.MontoDolaresPago) * pCob.TipoCambioPago;
                                    return iSoles;
                                }
                        }
                        break;
                    }
            }

            return iSoles;
        }

        public static int ObtenerDiferenciaDeDias(PagoEN pObj)
        {
            int iDiferencia = 0;
            DateTime iFechaVencimientoCuota = Convert.ToDateTime(pObj.FechaVencimientoCuota).Date;
            DateTime iFechaDepositoPago = Convert.ToDateTime(pObj.FechaDepositoPago).Date;

            if (pObj.FechaPagoCuota == string.Empty)
            {
                iDiferencia = Fecha.DiferenciaDias(iFechaVencimientoCuota, iFechaDepositoPago);
            }
            else
            {
                DateTime iFechaPagoCuota = Convert.ToDateTime(pObj.FechaPagoCuota).Date;
                //en el caso que se pago parte de la letra
                if (iFechaVencimientoCuota > iFechaPagoCuota)
                {
                    iDiferencia = Fecha.DiferenciaDias(iFechaVencimientoCuota, iFechaDepositoPago);
                }
                else
                {
                    iDiferencia = Fecha.DiferenciaDias(iFechaPagoCuota, iFechaDepositoPago);
                }
            }
            return iDiferencia;
        }

        public static PagoEN EsMontoEnDolaresCorrecto(PagoEN pCob)
        {
            PagoEN iCobEN = new PagoEN();
            if (pCob.MontoSolesPago < 0)
            {
                iCobEN.Adicionales.EsVerdad = false;
                iCobEN.Adicionales.Mensaje = "El monto en dolares no puede ser mayor que el monto pagado";
            }
            else
            {
                iCobEN.Adicionales.EsVerdad = true;
                iCobEN.Adicionales.Mensaje = string.Empty;
            }
            return iCobEN;
        }

        public static PagoEN EsMontoPagadoCorrecto(string pCFormaPago, decimal pMontoACobrar, decimal pMontoCobrado)
        {
            //objeto resultado
            PagoEN iCobEN = new PagoEN();

            //validar
            if (pCFormaPago == "1") // A Cuenta
            {
                if (pMontoCobrado >= pMontoACobrar)
                {
                    iCobEN.Adicionales.EsVerdad = false;
                    iCobEN.Adicionales.Mensaje = "El monto pagado no puede ser mayor o igual que el monto a pagar";
                }
                else
                {
                    iCobEN.Adicionales.EsVerdad = true;
                    iCobEN.Adicionales.Mensaje = string.Empty;
                }
            }
            else
            {
                iCobEN.Adicionales.EsVerdad = true;
                iCobEN.Adicionales.Mensaje = string.Empty;
            }

            return iCobEN;
        }

        public static List<PagoEN> ListarPagosXCuota(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            return iCobAD.ListarPagosXComprobante(pObj);
        }

        public static PagoEN EsPagoExistente(PagoEN pObj)
        {
            PagoEN iCobEN = new PagoEN();
            iCobEN = PagoRN.BuscarPagoXCorrelativo(pObj);
            if (iCobEN.CorrelativoPago == string.Empty)
            {
                iCobEN.Adicionales.EsVerdad = false;
                iCobEN.Adicionales.Mensaje = "El Correlativo " + pObj.CorrelativoPago + " : " + pObj.NombreCliente + " no existe";
            }
            else
            {
                iCobEN.Adicionales.EsVerdad = true;
            }
            return iCobEN;
        }

        public static PagoEN EsActoEliminarPago(PagoEN pCob)
        {
            //objeto resultado
            PagoEN iCobEN = new PagoEN();

            //validar si existe
            iCobEN = PagoRN.EsPagoExistente(pCob);
            if (iCobEN.Adicionales.EsVerdad == false) { return iCobEN; }

            //traer todas las Pagos que tenga esta cuota
            iCobEN.Adicionales.CampoOrden = PagoEN.CorPag;
            List<PagoEN> iLisCob = PagoRN.ListarPagosXCuota(iCobEN);

            int iNroPago = iLisCob.Count;
            if (iNroPago == 0)
            {
                iCobEN.Adicionales.EsVerdad = false;
                iCobEN.Adicionales.Mensaje = "No hay Pago que eliminar";
                return iCobEN;
            }

            if (iNroPago > 1)
            {
                if (iCobEN.CorrelativoPago != iLisCob[iNroPago - 1].CorrelativoPago)
                {
                    iCobEN.Adicionales.EsVerdad = false;
                    iCobEN.Adicionales.Mensaje = "Solo se puede eliminar la ultima Pago";
                    return iCobEN;
                }
            }

            //ok
            iCobEN.Adicionales.EsVerdad = true;
            return iCobEN;
        }

        public static PagoEN ObtenerObjetoTotales(List<PagoEN> pListaPago)
        {
            //objeto resultado
            PagoEN iCobEN = new PagoEN();

            //descripcion de totales
            iCobEN.FechaDepositoPago = "TOTALES";

            //recorrer cada objeto
            foreach (PagoEN xCob in pListaPago)
            {
                iCobEN.MontoCuota += xCob.MontoCuota;
                iCobEN.MontoMoraPago += xCob.MontoMoraPago;
                iCobEN.MontoCobradoPago += xCob.MontoCobradoPago;
            }

            //devolver
            return iCobEN;
        }

        public static List<PagoEN> ListarPagosParaSaldosAMes(PagoEN pObj)
        {
            PagoAD iCobAD = new PagoAD();
            return iCobAD.ListarPagosParaSaldosAMes(pObj);
        }

        public static decimal CalculoMora(CuotaEN pCuo, string pFechaDeposito, EmpresaEN pEmp)
        {
            decimal Monto = 0;
            //si ya se genero la mora fija a esta cuota, entonces ya no calcula nueva mora
            if (pCuo.CGeneroMoraFija == "1")//si
            {
                return 0;
            }
            else
            {
                string Dias = string.Empty;

                //obtener el numero de dias que hay entre el nuevo deposito y la fecha vencimiento de la cuota
                int iDiferenciaDiasVcto = Fecha.DiferenciaDias(pCuo.FechaVencimientoCuota, pFechaDeposito);

                //si esta diferencia de dias es mayor o igual a los numero de dias para mora fija entonces se aplica
                //la mora fija
                if (iDiferenciaDiasVcto >= Convert.ToInt32(Dias))
                {
                    //se resta el monto mora fijo(actual:180) con el montoMora de la cuota, porque talvez se guardo una mora al
                    //hacer una Pago parcial con mora
                    //return pEmp.MontoMoraFija - pCuo.MontoMora;
                    return Monto;
                }
                else
                {
                    //validar que la diferencia de dias sea positiva
                    if (iDiferenciaDiasVcto > 0)
                    {
                        //aqui la diferencia de dias es menor al del parametro para mora fija, entonces hay que calcular la mora diaria
                        //obtener la fecha inicial para el calcula de la mora
                        string iFechaInicial = PagoRN.ObtenerFechaInicialParaCalcularMora(pCuo);

                        //obtener diferencia de dias
                        int iDiferenciaDiasMora = Fecha.DiferenciaDias(iFechaInicial, pFechaDeposito);

                        //devolver
                        //return pEmp.ImporteMoraDiaria * iDiferenciaDiasMora;
                        return Monto;
                    }
                    else
                    {
                        //aqui la cuota se paga adelantado, entonces la mora es cero
                        return 0;
                    }
                }
            }
        }

        public static decimal ObtenerMoraAPagar(decimal pMoraPendienteAnterior, decimal pNuevaMora)
        {
            return pMoraPendienteAnterior + pNuevaMora;
        }

        public static decimal ObtenerMontoPagado(decimal pCuotaPagada, decimal pMoraPagada)
        {
            return pCuotaPagada + pMoraPagada;
        }

        public static string ObtenerFechaInicialParaCalcularMora(CuotaEN pCuo)
        {
            //si la fecha pago de la cuota esta vacia entonces se toma la fecha de vencimiento de la cuota
            if (pCuo.FechaPagoCuota == string.Empty) { return pCuo.FechaVencimientoCuota; }

            //aqui si hay fecha pago de la cuota, entonces si esta fecha es menor al vencimiento
            //va la fecha vencimiento sino va la fecha pago
            if (Fecha.EsMayorQue(pCuo.FechaVencimientoCuota, pCuo.FechaPagoCuota) == true)
            {
                return pCuo.FechaVencimientoCuota;
            }
            else
            {
                return pCuo.FechaPagoCuota;
            }
        }


    }
}
