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
    public class CobranzaRN
    {

        public static CobranzaEN EnBlanco()
        {
            CobranzaEN iCobEN = new CobranzaEN();
            return iCobEN;
        }

        public static void AdicionarCobranza(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            pObj.AnoCobranza = Fecha.ObtenerAño(pObj.FechaCobranza);
            pObj.CMesCobranza = Fecha.ObtenerMes(pObj.FechaCobranza);
            //validar si es descuento o mora
            if (pObj.MontoDescuentoCobranza < 0) { pObj.MontoMoraCobranza = 0; }
            if (pObj.MontoDescuentoCobranza > 0) { pObj.MontoDescuentoCobranza = 0; }
            iCobAD.AdicionarCobranza(pObj);
        }

        public static void AdicionarCobranzaMasivo(List<CobranzaEN> pLista)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            iCobAD.AdicionarCobranzaMasivo(pLista);
        }

        public static void ModificarCobranza(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            iCobAD.ModificarCobranza(pObj);
        }

        public static void ModificarCobranza(List< CobranzaEN> pLista)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            iCobAD.ModificarCobranza(pLista);
        }

        public static void EliminarCobranzaXCorrelativo(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            iCobAD.EliminarCobranzaXCorrelativo(pObj);
        }

        public static void EliminarCobranzaMasiva(List<CobranzaEN> pLista)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            iCobAD.EliminarCobranzaMasiva(pLista);
        }

        public static CobranzaEN BuscarCobranzaXCorrelativo(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            return iCobAD.BuscarCobranzaXCorrelativo(pObj);
        }

        public static List<CobranzaEN> ListarCobranzasXContrato(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            return iCobAD.ListarCobranzasXContrato(pObj);
        }

        //public static void AdicionarCobranzaDeRecepcion(DetalleRecepcionRecEN pDetRec, RecepcionRecEN pRec)
        //{
        //    //si no se aplico entonces no hay cobranza
        //    if (pDetRec.CFlagDetalleRecepcion == "0") { return; }

        //    //sino encuentra a la cuota no genera cobranza
        //    if (pDetRec.Cuota.ClaveCuota == string.Empty) { return; }

        //    //pasar datos
        //    CobranzaEN iCobEN = new CobranzaEN();
        //    iCobEN.CodigoEmpresa = pDetRec.Cuota.CodigoEmpresa;
        //    iCobEN.CodigoProyecto = pDetRec.Cuota.CodigoProyecto;
        //    iCobEN.FechaPagoCuota = pDetRec.Cuota.FechaPagoCuota;
        //    iCobEN.FechaCobranzaCuota = pDetRec.Cuota.FechaCobranzaCuota;
        //    iCobEN.FechaCobranza = DateTime.Now.ToShortDateString();
        //    iCobEN.ClaveCuota = pDetRec.Cuota.ClaveCuota;
        //    iCobEN.NumeroContrato = pDetRec.Cuota.NumeroContrato;
        //    iCobEN.FechaVencimientoCuota = pDetRec.Cuota.FechaVencimientoCuota;
        //    iCobEN.EtapaLote = pDetRec.Cuota.EtapaLote;
        //    iCobEN.ManzanaLote = pDetRec.Cuota.ManzanaLote;
        //    iCobEN.NumeroLote = pDetRec.Cuota.NumeroLote;
        //    iCobEN.CodigoCliente = pDetRec.Cuota.CodigoCliente;
        //    iCobEN.MontoCuota = pDetRec.Cuota.MontoCuota;
        //    iCobEN.FechaDepositoCobranza = pDetRec.FechaCobranza;
        //    iCobEN.CuotaPendienteAnterior = pDetRec.Cuota.MontoPendienteCuota;
        //    iCobEN.MoraAnterior = pDetRec.Cuota.MontoMora;
        //    iCobEN.MoraPendienteAnterior = pDetRec.Cuota.MontoMoraPendiente;
        //    iCobEN.ImporteCobranza = iCobEN.CuotaPendienteAnterior + iCobEN.MoraPendienteAnterior;
        //    iCobEN.MontoDescuentoCobranza = 0;
        //    iCobEN.MontoMoraCobranza = pDetRec.ImporteMora;
        //    iCobEN.MontoProtestoCobranza = 0;
        //    iCobEN.MontoOtrosCobranza = 0;
        //    iCobEN.MontoaCobrarCobranza = pDetRec.ImporteTotal;
        //    iCobEN.CuotaPagadaCobranza = pDetRec.Cuota.MontoPendienteCuota;
        //    iCobEN.MoraPagadaCobranza = pDetRec.ImporteMora;
        //    iCobEN.MontoCobradoCobranza = pDetRec.ImporteTotal;
        //    iCobEN.CFormaCobroCobranza = "0";//total
        //    iCobEN.CModoCobroCobranza = pDetRec.MonedaPago;
        //    iCobEN.MontoDolaresCobranza = Cadena.CompararDosValores(pDetRec.MonedaPago, "0", 0, pDetRec.ImporteTotal);
        //    iCobEN.MontoSolesCobranza = Cadena.CompararDosValores(pDetRec.MonedaPago, "0", pDetRec.ImporteTotal, 0);            
        //    iCobEN.TipoCambioCobranza = 1;
        //    iCobEN.CLugarCobranza = "0";
        //    iCobEN.ObservacionCobranza = "Recaudacion de la cuenta N°: " + pRec.NumeroCuentaBanco;
        //    iCobEN.ClaveCuentaBanco = pRec.ClaveCuentaBanco;
        //    iCobEN.CTipoCobranza = "0";
        //    iCobEN.ClaveComprobante = pDetRec.ClaveComprobante;
        //    iCobEN.CorrelativoCobranza = CobranzaRN.ObtenerCorrelativoCobranza(iCobEN);
        //    iCobEN.CGeneroMoraFijaAnterior = pDetRec.Cuota.CGeneroMoraFija;

        //    //adicionar en b.d
        //    CobranzaRN.AdicionarCobranza(iCobEN);

        //    //actualizamos el campo correlativoCobranza del detalleRec 
        //    pDetRec.CorrelativoCobranza = iCobEN.CorrelativoCobranza;
        //}
        
        public static string ObtenerCorrelativoCobranza(CobranzaEN pCob)
        {
            //el nuevo correlativo
            string iNuevoNumero;

            //traer una lista de todas las cobranzas de un contrato
            List<CobranzaEN> iLisCob = new List<CobranzaEN>();
            pCob.Adicionales.CampoOrden = CobranzaEN.CorCob;
            iLisCob = CobranzaRN.ListarCobranzasXContrato(pCob);

            //la estructura del correlativo cobranza sera:
            //ClaveContrato + correlativo
            //si la lista esta vacia se crea el primer correlativo      
            int iNumeroCobranzas = iLisCob.Count;
            if (iNumeroCobranzas == 0)
            {
                iNuevoNumero = Universal.gCodigoEmpresa + "-" + pCob.NumeroContrato + "-" + "0001";
            }
            else
            {
                string iUltimoCorrelativo = iLisCob[iNumeroCobranzas - 1].CorrelativoCobranza;
                int iLongitudCorrelativo = iUltimoCorrelativo.Length;
                int iIndicePartida = iLongitudCorrelativo - 4;
                int iCorrelativo = Convert.ToInt32(iUltimoCorrelativo.Substring(iIndicePartida));
                iCorrelativo++;
                iNuevoNumero = Universal.gCodigoEmpresa + "-" + pCob.NumeroContrato + "-" + iCorrelativo.ToString().PadLeft(4, Convert.ToChar("0"));
            }
            return iNuevoNumero;
        }

        public static string ObtenerTodosLosCorrelativosCobranza(List<DetalleRecepcionRecEN> pLisDetRec)
        {
            //cadena resultado
            string iStr = string.Empty;

            //recorremos cada objeto
            foreach (DetalleRecepcionRecEN xDetRec in pLisDetRec)
            {
                if (xDetRec.CorrelativoCobranza != string.Empty)
                {
                    iStr += "'" + xDetRec.CorrelativoCobranza + "'" + ",";
                }
            }

            //si el Str esta lleno entonces sacar a la ultima coma
            if (iStr.Length != 0)
            {
                iStr = iStr.Remove(iStr.Length - 1);
            }
            else
            {
                iStr = "''";
            }
            return iStr;
        }

        public static List<CobranzaEN> ListarCobranzasDeRecepcionRec(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            return iCobAD.ListarCobranzasGeneradasDeRecepcionRec(pObj);
        }

        public static CobranzaEN buscarCobranzaXClaveCuota(CobranzaEN pObj, List<CobranzaEN> pLista)
        {
            // Objeto resultado
            CobranzaEN iCobEN = new CobranzaEN();

            //Buscar en lista
            foreach (CobranzaEN xCob in pLista)
            {
                if (pObj.ClaveCuota == xCob.ClaveCuota)
                {
                    iCobEN = xCob;
                    return iCobEN;
                }
            }
            return iCobEN;
        }

        public static List<CobranzaEN> ListarCobranzasXFiltro(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            return iCobAD.ListarCobranzaXFiltro(pObj);
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

        public static List<CobranzaEN> ListarCobranzasXRangoFechaCobranza(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            return iCobAD.ListarCobranzasXRangoFechaCobranza(pObj);
        }

        public static decimal CalculoMontoAPagar(decimal pCuotaAPagar, decimal pMoraAPagar)
        {
            return pCuotaAPagar + pMoraAPagar;
        }

        public static decimal CalculoMontoEnDolares(CobranzaEN pCob, string pMonedaLetra)
        {
            decimal iDolares = 0;
            switch (pCob.CModoCobroCobranza)
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
                                    return Conversion.DeSolesADolares(pCob.MontoCobradoCobranza, pCob.TipoCambioCobranza);
                                }

                            case "1": // dolares
                                {
                                    return pCob.MontoCobradoCobranza;
                                }
                        }
                        break;
                    }
            }
            return iDolares;
        }

        public static decimal CalculoMontoEnSoles(CobranzaEN pCob, string pMonedaLetra)
        {
            decimal iSoles = 0;
            switch (pCob.CModoCobroCobranza)
            {
                case "0"://soles
                    {
                        //de que moneda es la letra
                        switch (pMonedaLetra)
                        {
                            case "0"://soles
                                {
                                    return pCob.MontoCobradoCobranza;
                                }

                            case "1": // dolares
                                {
                                    return  Conversion.DeDolaresASoles(pCob.MontoCobradoCobranza, pCob.TipoCambioCobranza);                                    
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
                                    iSoles = pCob.MontoCobradoCobranza - pCob.MontoDolaresCobranza * pCob.TipoCambioCobranza;
                                    return iSoles;
                                }

                            case "1": // dolares
                                {
                                    iSoles = (pCob.MontoCobradoCobranza - pCob.MontoDolaresCobranza) * pCob.TipoCambioCobranza;
                                    return iSoles;
                                }
                        }
                        break;
                    }
            }

            return iSoles;
        }

        public static int ObtenerDiferenciaDeDias(CobranzaEN pObj)
        {
            int iDiferencia = 0;
            DateTime iFechaVencimientoCuota = Convert.ToDateTime(pObj.FechaVencimientoCuota).Date;
            DateTime iFechaDepositoCobranza = Convert.ToDateTime(pObj.FechaDepositoCobranza).Date;           

            if (pObj.FechaPagoCuota == string.Empty)
            {
                iDiferencia = Fecha.DiferenciaDias(iFechaVencimientoCuota, iFechaDepositoCobranza);
            }
            else
            {
                DateTime iFechaPagoCuota = Convert.ToDateTime(pObj.FechaPagoCuota).Date;
                //en el caso que se pago parte de la letra
                if (iFechaVencimientoCuota > iFechaPagoCuota)
                {
                    iDiferencia = Fecha.DiferenciaDias(iFechaVencimientoCuota, iFechaDepositoCobranza);
                }
                else
                {
                    iDiferencia = Fecha.DiferenciaDias(iFechaPagoCuota, iFechaDepositoCobranza);
                }
            }
            return iDiferencia;
        }

        public static CobranzaEN EsMontoEnDolaresCorrecto(CobranzaEN pCob)
        {
            CobranzaEN iCobEN = new CobranzaEN();
            if (pCob.MontoSolesCobranza < 0)
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

        public static CobranzaEN EsMontoPagadoCorrecto(string pCFormaCobro, decimal pMontoACobrar, decimal pMontoCobrado)
        {
            //objeto resultado
            CobranzaEN iCobEN = new CobranzaEN();

            //validar
            if (pCFormaCobro == "1") // A Cuenta
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

        public static List<CobranzaEN> ListarCobranzasXCuota(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            return iCobAD.ListarCobranzasXCuota(pObj);
        }

        public static CobranzaEN EsCobranzaExistente(CobranzaEN pObj)
        {
            CobranzaEN iCobEN = new CobranzaEN();
            iCobEN = CobranzaRN.BuscarCobranzaXCorrelativo(pObj);
            if (iCobEN.CorrelativoCobranza == string.Empty)
            {
                iCobEN.Adicionales.EsVerdad = false;
                iCobEN.Adicionales.Mensaje = "El Correlativo " + pObj.CorrelativoCobranza + " : " + pObj.NombreCliente + " no existe";
            }
            else
            {
                iCobEN.Adicionales.EsVerdad = true;
            }
            return iCobEN;
        }

        public static CobranzaEN EsActoEliminarCobranza(CobranzaEN pCob)
        {
            //objeto resultado
            CobranzaEN iCobEN = new CobranzaEN();

            //validar si existe
            iCobEN = CobranzaRN.EsCobranzaExistente(pCob);
            if (iCobEN.Adicionales.EsVerdad == false) { return iCobEN; }
                      
            //traer todas las cobranzas que tenga esta cuota
            iCobEN.Adicionales.CampoOrden = CobranzaEN.CorCob;
            List<CobranzaEN> iLisCob = CobranzaRN.ListarCobranzasXCuota(iCobEN);

            int iNroCobranza = iLisCob.Count;
            if (iNroCobranza == 0)
            {
                iCobEN.Adicionales.EsVerdad = false;
                iCobEN.Adicionales.Mensaje = "No hay cobranza que eliminar";
                return iCobEN;
            }

            if (iNroCobranza > 1)
            {
                if (iCobEN.CorrelativoCobranza != iLisCob[iNroCobranza - 1].CorrelativoCobranza)
                {
                    iCobEN.Adicionales.EsVerdad = false;
                    iCobEN.Adicionales.Mensaje = "Solo se puede eliminar la ultima cobranza";
                    return iCobEN;
                }
            }
                    
            //ok
            iCobEN.Adicionales.EsVerdad = true;
            return iCobEN;
        }

        public static CobranzaEN ObtenerObjetoTotales(List<CobranzaEN> pListaCobranza)
        {
            //objeto resultado
            CobranzaEN iCobEN = new CobranzaEN();

            //descripcion de totales
            iCobEN.FechaDepositoCobranza = "TOTALES";

            //recorrer cada objeto
            foreach (CobranzaEN xCob in pListaCobranza)
            {
                iCobEN.MontoCuota += xCob.MontoCuota;
                iCobEN.MontoMoraCobranza += xCob.MontoMoraCobranza;
                iCobEN.MontoCobradoCobranza += xCob.MontoCobradoCobranza;
            }

            //devolver
            return iCobEN;
        }

        public static List<CobranzaEN> ListarCobranzasParaSaldosAMes(CobranzaEN pObj)
        {
            CobranzaAD iCobAD = new CobranzaAD();
            return iCobAD.ListarCobranzasParaSaldosAMes(pObj);
        }

        public static decimal CalculoMora(CuotaEN pCuo,string pFechaDeposito,EmpresaEN pEmp)
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
                    //hacer una cobranza parcial con mora
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
                        string iFechaInicial = CobranzaRN.ObtenerFechaInicialParaCalcularMora(pCuo);
                       
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
