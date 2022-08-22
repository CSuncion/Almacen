using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;


namespace Negocio
{
    public class CuotaRN
    {


        public static CuotaEN EnBlanco()
        {
            CuotaEN iCuoEN = new CuotaEN();
            return iCuoEN;
        }

        public static void AdicionarCuota(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.AdicionarCuota(pObj);
        }

        public static void AdicionarCuota(List<CuotaEN> pLista)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.AdicionarCuota(pLista);
        }

        public static void ModificarCuota(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.ModificarCuota(pObj);
        }

        public static void ModificarCuota(List<CuotaEN> pLista)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.ModificarCuota(pLista);
        }

        public static void ModificarEstadoCuota(List<CuotaEN> pLista)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.ModificarEstadoCuota(pLista);
        }

        public static void EliminarCuotaXClave(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.EliminarCuotaXClave(pObj);
        }

        public static void EliminarCuotaXClave(List<CuotaEN> pLista)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.EliminarCuotaXClave(pLista);
        }

        public static CuotaEN BuscarCuotaXClave(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.BuscarCuotaXClave(pObj);
        }

        public static List<CuotaEN> ListarCuotas(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotas(pObj);
        }

        public static List<CuotaEN> ListarCuotasConPagoXPeriodo(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasConPagoXPeriodo(pObj);
        }

        public static CuotaEN EsCuotaExistente(CuotaEN pObj)
        {
            CuotaEN iCuoEN = new CuotaEN();
            iCuoEN = CuotaRN.BuscarCuotaXClave(pObj);
            if (iCuoEN.ClaveCuota == string.Empty)
            {
                iCuoEN.Adicionales.EsVerdad = false;
                iCuoEN.Adicionales.Mensaje = "La Cuota " + pObj.ClaveCuota + " : " + pObj.NombreProyecto + " no existe";
            }
            else
            {
                iCuoEN.Adicionales.EsVerdad = true;

            }
            return iCuoEN;
        }

        public static CuotaEN BuscarCuotaXClave(CuotaEN pObj, List<CuotaEN> pLista)
        {
            //objeto resultado
            CuotaEN iCuoEN = new CuotaEN();

            //buscar en lista
            foreach (CuotaEN xLot in pLista)
            {
                if (pObj.ClaveCuota == xLot.ClaveCuota)
                {
                    iCuoEN = xLot;
                    return iCuoEN;
                }
            }
            return iCuoEN;
        }

        public static string ObtenerClaveCuota(CuotaEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoEmpresa + "-";
            iClave += pObj.NumeroContrato + "-";
            iClave += pObj.AnoCuota + "-";
            iClave += pObj.CMesCuota + "-";
            iClave += pObj.CodigoConcepto;
            return iClave;
        }

        public static void GenerarCuotasOrdinariasMasivas(CuotaEN pCuo)
        {    
            //lista resultado para adicionar las nuevas cuotas
            List<CuotaEN> iLisCuoAdi = CuotaRN.ListarNuevasCuotasOrdinariasMasivasParaGenerar(pCuo);

            //ahora adicionamos estas cuotas masivamente
            CuotaRN.AdicionarCuota(iLisCuoAdi);
        }

        public static List<CuotaEN> ListarNuevasCuotasOrdinariasALotesActivos(CuotaEN pCuo)
        {
            //para listar las nuevas cuotas ordinarias debemos traer a todos los 
            //lotes con estado activos
            LoteEN iLotEN = new LoteEN();
            iLotEN.CEstadoLote = "1";//activados
            iLotEN.Adicionales.CampoOrden = LoteEN.NumLot;
            List<LoteEN> iLisLot = LoteRN.ListarLotesDeAlmacen(iLotEN);

            //traer a la empresa de acceso, para sacar algunos parametro
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);

            //lista resultado para adicionar las nuevas cuotas
            List<CuotaEN> iLisCuoAdi = new List<CuotaEN>();

            //ahora si recorrer cada lote
            foreach (LoteEN xLot in iLisLot)
            {               
                //creamos un nuevo objeto cuota
                CuotaEN iCuoNueEN = new CuotaEN();

                //le pasamos datos
                iCuoNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iCuoNueEN.CodigoProyecto = xLot.CodigoAlmacen;
                iCuoNueEN.EtapaLote = xLot.CodigoLote;
                iCuoNueEN.ManzanaLote = xLot.CodigoAlmacen;
                iCuoNueEN.NumeroLote = xLot.NumeroLote;
                iCuoNueEN.ClaveLote = CuotaRN.ObtenerClaveLote(iCuoNueEN);
                iCuoNueEN.PeriodoCuota = pCuo.PeriodoCuota;
                iCuoNueEN.AnoCuota = pCuo.AnoCuota;
                iCuoNueEN.CMesCuota = pCuo.CMesCuota;
                iCuoNueEN.CodigoConcepto = iEmpEN.ConceptoCuotaOrdinaria;
                iCuoNueEN.CodigoCliente = xLot.CodigoAlmacen;
                iCuoNueEN.NumeroContrato = xLot.NumeroLote;
                iCuoNueEN.MontoCuota = 1000; //CuotaRN.ObtenerMontoCuota(xLot.AreaLote, iEmpEN.FactorLote);
                iCuoNueEN.MontoPendienteCuota = iCuoNueEN.MontoCuota;
                iCuoNueEN.CMonedaCuota = "0";//soles
                iCuoNueEN.FechaEmisionCuota = pCuo.FechaEmisionCuota;
                iCuoNueEN.FechaVencimientoCuota = pCuo.FechaVencimientoCuota;                
                iCuoNueEN.FechaPagoCuota = string.Empty;
                iCuoNueEN.CEstadoCuota = "0";
                iCuoNueEN.ClaveCuota = CuotaRN.ObtenerClaveCuota(iCuoNueEN);

                //adicionamos a la lista resultado
                iLisCuoAdi.Add(iCuoNueEN);
            }

            //devolver
            return iLisCuoAdi;
        }

        public static List<CuotaEN> ListarNuevasCuotasOrdinariasMasivasParaGenerar(CuotaEN pCuo)
        {
            //traer todas las cuotas pagadas de este periodo
            CuotaEN iCuoEN = new CuotaEN();
            iCuoEN.PeriodoCuota = pCuo.PeriodoCuota;
            iCuoEN.Adicionales.CampoOrden = CuotaEN.NumCon;
            List<CuotaEN> iLisCuoPag = CuotaRN.ListarCuotasConPagoXPeriodo(iCuoEN);

            //lista de nuevas cuotas ordinarias de todos los lotes activos
            List<CuotaEN> iLisCuoLotAct = CuotaRN.ListarNuevasCuotasOrdinariasALotesActivos(pCuo);

            //vamos a sacar solo las cuotas que se deben generar
            return CuotaRN.SacarCuotasDe(iLisCuoLotAct, iLisCuoPag);

        }

        public static List<CuotaEN> SacarCuotasDe(List<CuotaEN> pListaASacarCuotas, List<CuotaEN> pListaDeCuotasASacar)
        {           
            //lista resultado
            List<CuotaEN> iLisRes = new List<CuotaEN>();

            //recorrer cada objeto
            foreach (CuotaEN xCuoPri in pListaASacarCuotas)
            {
                //flag de objeto encontrado(1=encontrado)
                int iFlagEncontrado = 0;

                //recorrer cada objeto
                foreach (CuotaEN xCuoSeg in pListaDeCuotasASacar)
                {
                    //buscar xCuoPri en xCuoSeg
                    if (xCuoPri.NumeroContrato + xCuoPri.AnoCuota + xCuoPri.CMesCuota + xCuoPri.CodigoConcepto == xCuoSeg.NumeroContrato + xCuoSeg.AnoCuota + xCuoSeg.CMesCuota + xCuoSeg.CodigoConcepto)
                    {
                        iFlagEncontrado = 1;
                    }
                }

                //preguntar si fue encontrado
                if (iFlagEncontrado == 0)
                {
                    iLisRes.Add(xCuoPri);
                }
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerMontoCuota(decimal pAreaLote, decimal pFactor)
        {
            //valor resultado
            decimal iMonto = 0;

            //calculo
            iMonto = pAreaLote * pFactor;

            //devolver
            return iMonto;
        }

        public static void EliminarCuotasSinPagoXPeriodo(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.EliminarCuotasSinPagoXPeriodo(pObj);
        }

        public static List<CuotaEN> ListarNuevasCuotasOrdinariasAdelantadas(CuotaEN pCuo,int pNumeroCuotas)
        {
            //traer al lote en proceso
            LoteEN iLotEN = new LoteEN();
            iLotEN.NumeroLote = pCuo.NumeroContrato;
            iLotEN = LoteRN.BuscarLoteXClave(iLotEN);   //.BuscarLoteXNumeroContrato(iLotEN);

            //traer a la empresa de acceso, para sacar algunos parametro
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);
        
            //lista resultado para adicionar las nuevas cuotas
            List<CuotaEN> iLisCuoAdi = new List<CuotaEN>();

            //ahora si recorrer cada lote
            for (int i = 0; i < pNumeroCuotas; i++)
            {
                //creamos un nuevo objeto cuota
                CuotaEN iCuoNueEN = new CuotaEN();
                
                //le pasamos datos
                iCuoNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iCuoNueEN.CodigoProyecto = iLotEN.CodigoLote;  
                iCuoNueEN.EtapaLote = iLotEN.CodigoLote;
                iCuoNueEN.ManzanaLote = iLotEN.CodigoLote;
                iCuoNueEN.NumeroLote = iLotEN.NumeroLote;
                iCuoNueEN.ClaveLote = CuotaRN.ObtenerClaveLote(iCuoNueEN);
                iCuoNueEN.PeriodoCuota = Fecha.AumentarPeriodo(pCuo.AnoCuota, pCuo.CMesCuota, "-", i);
                iCuoNueEN.AnoCuota = CuotaRN.ObtenerAnoPeriodo(iCuoNueEN.PeriodoCuota);
                iCuoNueEN.CMesCuota = CuotaRN.ObtenerMesPeriodo(iCuoNueEN.PeriodoCuota);
                iCuoNueEN.CodigoConcepto = iEmpEN.ConceptoCuotaOrdinaria;
                iCuoNueEN.CodigoCliente = iLotEN.CodigoAlmacen;
                iCuoNueEN.NumeroContrato = iLotEN.NumeroLote;
                iCuoNueEN.MontoCuota = 1000; //CuotaRN.ObtenerMontoCuota(iLotEN.AreaLote, iEmpEN.FactorLote);
                iCuoNueEN.MontoPendienteCuota = iCuoNueEN.MontoCuota;
                iCuoNueEN.CMonedaCuota = "0";//soles
                iCuoNueEN.FechaEmisionCuota = pCuo.FechaEmisionCuota;
                iCuoNueEN.FechaVencimientoCuota = Fecha.AumentarMeses(pCuo.FechaVencimientoCuota, i);               
                iCuoNueEN.FechaPagoCuota = string.Empty;
                iCuoNueEN.CEstadoCuota = "0";
                iCuoNueEN.ClaveCuota = CuotaRN.ObtenerClaveCuota(iCuoNueEN);

                //adicionamos a la lista resultado
                iLisCuoAdi.Add(iCuoNueEN);

            }
         
            //devolver
            return iLisCuoAdi;
        }

        public static List<CuotaEN> ListarNuevasCuotasOrdinariasAdelantadasParaGenerar(CuotaEN pCuo, int pNumeroCuotas)
        {
            //traer todas las cuotas pagadas de este lote
            CuotaEN iCuoEN = new CuotaEN();
            iCuoEN.FechaVencimientoCuota = pCuo.FechaVencimientoCuota;
            iCuoEN.NumeroContrato = pCuo.NumeroContrato;
            iCuoEN.Adicionales.CampoOrden = CuotaEN.NumCon;
            List<CuotaEN> iLisCuoPag = CuotaRN.ListarCuotasConPagoMayorOIgualVctoDeContrato(iCuoEN);

            //lista de nuevas cuotas ordinarias del contrato elejido
            List<CuotaEN> iLisCuoConAde = CuotaRN.ListarNuevasCuotasOrdinariasAdelantadas(pCuo,pNumeroCuotas);

            //vamos a sacar solo las cuotas que se deben generar
            return CuotaRN.SacarCuotasDe(iLisCuoConAde, iLisCuoPag);
        }

        public static List<CuotaEN> ListarCuotasConPagoMayorOIgualVctoDeContrato(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasConPagoMayorOIgualVctoDeContrato(pObj);
        }

        public static void GenerarCuotasOrdinariasAdelantadas(CuotaEN pCuo, int pNumeroCuotas)
        {
            //lista resultado para adicionar las nuevas cuotas
            List<CuotaEN> iLisCuoAdi = CuotaRN.ListarNuevasCuotasOrdinariasAdelantadasParaGenerar(pCuo, pNumeroCuotas);

            //ahora adicionamos estas cuotas masivamente
            CuotaRN.AdicionarCuota(iLisCuoAdi);
        }

        public static void EliminarCuotasSinPagoXContrato(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.EliminarCuotasSinPagoXContrato(pObj);
        }

        public static List<CuotaEN> ListarCuotasParaEnvioRec(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasParaEnvioRec(pCuo);           
        }

        public static List<CuotaEN> ListarCuotasValidasParaEnvioRec(CuotaEN pCuo, string pClaveEnvioRec)
        {
            //lista resultado
            List<CuotaEN> iLisRes = new List<CuotaEN>();

            //listar las cuotas para envio rec
            pCuo.Adicionales.CampoOrden = CuotaEN.ClaCuo;
            List<CuotaEN> iLisCuoEnvRec = CuotaRN.ListarCuotasParaEnvioRec(pCuo);

            //listar las cuotas que ya estan en el enviorec
            DetalleEnvioRecEN iDetEnvRecEN = new DetalleEnvioRecEN();
            iDetEnvRecEN.ClaveEnvioRec = pClaveEnvioRec;
            iDetEnvRecEN.Adicionales.CampoOrden = DetalleEnvioRecEN.ClaCuo;
            List<DetalleEnvioRecEN> iLisDetEnvRec = DetalleEnvioRecRN.ListarDetalleEnvioRecXClaveEnvioRec(iDetEnvRecEN);

            //filtrar solo las cuotas que se deben seleccionar
            iLisRes = CuotaRN.ListarCuotasNoSeleccionadasEnEnvioRec(iLisCuoEnvRec, iLisDetEnvRec);
        
            //devolver
            return iLisRes;
        }

        public static List<CuotaEN> ListarCuotasNoSeleccionadasEnEnvioRec(List<CuotaEN> pLisCuo, List<DetalleEnvioRecEN> pLisDetEnv)
        {
            //lista resultado
            List<CuotaEN> iLisRes = new List<CuotaEN>();

            //ahora de la lista de cuotas hay que chequear cuales aun no han sido
            //seleccionadas en este envio
            foreach (CuotaEN xCuo in pLisCuo)
            {
                //lista encontrada
                int iObjetoEncontrada = 0;

                //cada letra que pase hay que ver si se encuentra en la lista iLisDeEnR
                foreach (DetalleEnvioRecEN xDetEnvRec in pLisDetEnv)
                {
                    if (xCuo.ClaveCuota == xDetEnvRec.ClaveCuota)
                    {
                        iObjetoEncontrada = 1;
                        break;
                    }
                }

                //preguntar si encontro al objeto
                if (iObjetoEncontrada == 0)
                {
                    iLisRes.Add(xCuo);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<CuotaEN> ListarCuotasXContrato(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasXContrato(pCuo);
        }

        public static CuotaEN BuscarCuotaXNumeroContratoYVcto(CuotaEN pObj, List<CuotaEN> pLista)
        {
            //valor resultado
            CuotaEN iCuoEN = new CuotaEN();

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                if (xCuo.NumeroContrato == pObj.NumeroContrato && xCuo.FechaVencimientoCuota == pObj.FechaVencimientoCuota)
                {
                    iCuoEN = xCuo;
                    return iCuoEN;
                }
            }

            //aqui no lo encontro
            return iCuoEN;
        }

        public static CuotaEN BuscarCuotaXNumeroContratoYPendientes(CuotaEN pObj, List<CuotaEN> pLista)
        {
            //valor resultado
            CuotaEN iCuoEN = new CuotaEN();

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                if (xCuo.NumeroContrato == pObj.NumeroContrato && xCuo.CEstadoCuota == "0") //0=Pendiente, 1=Cancelada
                {
                    iCuoEN = xCuo;
                    return iCuoEN;
                }
            }

            //aqui no lo encontro
            return iCuoEN;
        }

        public static CuotaEN BuscarCuotaXNumeroContratoYVcto(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.BuscarCuotaXNumeroContratoYVcto(pObj);
        }

        public static CuotaEN BuscarCuotaXNumeroContratoYPendientes(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.BuscarCuotaXNumeroContratoYPendientes(pObj);
        }

        public static void ModificarCuotaPorRecepcion(DetalleRecepcionRecEN pDetRec,EmpresaEN pEmp)
        {
            //si no se aplico entonces no modifica la letra
            if (pDetRec.CFlagDetalleRecepcion == "0") { return; }

            //si el contrato esta vacio ,no ase nada
            if (pDetRec.NumeroContrato == string.Empty) { return; }

            //si modifica
            //pasar los nuevos datos
            pDetRec.Cuota.FechaPagoCuota = pDetRec.FechaCobranza;
            pDetRec.Cuota.FechaCobranzaCuota = DateTime.Now.ToShortDateString();
            pDetRec.Cuota.MontoPendienteCuota = 0;
            pDetRec.Cuota.MontoMoraPendiente = 0;
            pDetRec.Cuota.MontoMora = pDetRec.ImporteMora;
            pDetRec.Cuota.CEstadoCuota = "1";//cancelada
            pDetRec.Cuota.CGeneroMoraFija = CuotaRN.ObtenerCGeneroMoraFija(pDetRec.FechaVencimientoCuota, pDetRec.FechaCobranza, pEmp);
          
            //modificar en b.d
            CuotaRN.ModificarCuota(pDetRec.Cuota);
        }

        public void ModificarCuotasDeRecepcionRec(List<CobranzaEN> pLisCob, List<DetalleRecepcionRecEN> pLisDetRec)
        {
            //pLisDetRec contiene todo el detalle de recepcion de la recepcionRec que se quiere estornar
            //sacar todos los numeros de letras que existen en esta lista
            string iStrCuotas = CuotaRN.ObtenerTodosLasClavesCuota(pLisDetRec);

            //traer las cuotas
            CuotaEN iCuoEN = new CuotaEN();
            iCuoEN.ClaveCuota = iStrCuotas;
            iCuoEN.Adicionales.CampoOrden = CuotaEN.ClaCuo;
            List<CuotaEN> iLisCuo = this.ListarCuotasDeRecepcionRec(iCuoEN);
                      
            //modificar cada letra de la lista
            foreach (CuotaEN xCuo in iLisCuo)
            {
                //buscamos al objeto cobranza de esta letra
                CobranzaEN iCobEN = new CobranzaEN();
                iCobEN.ClaveCuota = xCuo.ClaveCuota;
                iCobEN = CobranzaRN.buscarCobranzaXClaveCuota(iCobEN, pLisCob);

                //solo se modifica la letra si hay cobranza
                if (iCobEN.CorrelativoCobranza != string.Empty)
                {
                    //pasamos sus valores antiguos a la letra
                    xCuo.FechaPagoCuota = iCobEN.FechaPagoCuota;
                    xCuo.FechaCobranzaCuota = iCobEN.FechaCobranzaCuota;
                    xCuo.MontoPendienteCuota = iCobEN.CuotaPendienteAnterior;
                    xCuo.MontoMora = iCobEN.MoraAnterior;
                    xCuo.MontoMoraPendiente = iCobEN.MoraPendienteAnterior;
                    xCuo.CGeneroMoraFija = iCobEN.CGeneroMoraFijaAnterior;                 
                    xCuo.CEstadoCuota = "0";//pendiente
                }
            }

            //modificamos las letras en la b.d
            CuotaRN.ModificarCuota(iLisCuo);
        }

        public static string ObtenerTodosLasClavesCuota(List<DetalleRecepcionRecEN> pLisDetRec)
        {
            //cadena resultado
            string iStr = string.Empty;

            //recorremos cada objeto
            foreach (DetalleRecepcionRecEN xDetRec in pLisDetRec)
            {
                if (xDetRec.ClaveCuota != string.Empty)
                {
                    iStr += "'" + xDetRec.ClaveCuota + "'" + ",";
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

        public List<CuotaEN> ListarCuotasDeRecepcionRec(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasGeneradosDeRecepcionRec(pCuo);
        }

        public static List<CuotaEN> ListarCuotasXProyectoYPeriodo(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasXProyectoYPeriodo(pObj);
        }

        public static List<CuotaEN> ListarCuotasPendientes(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasPendientes(pCuo);
        }

        public static string ObtenerAnoPeriodo(string pPeriodoCuota)
        {
            if (pPeriodoCuota.Trim() == string.Empty) { return string.Empty; }

            return pPeriodoCuota.Substring(0, 4);        
        }

        public static string ObtenerMesPeriodo(string pPeriodoCuota)
        {
            if (pPeriodoCuota.Trim() == string.Empty) { return string.Empty; }

            return pPeriodoCuota.Substring(5);
        }

        public static void EliminarCuotasSinPagoXContratoYMayorOIgualAPeriodo(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.EliminarCuotasSinPagoXContratoYMayorOIgualAPeriodo(pObj);
        }

        public static List<CuotaEN> ListarCuotasPendientesXContrato(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasPendientesXContrato(pCuo);
        }

        public static List<CuotaEN> ListarCuotasPendientesXVcto(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasPendientesXVcto(pCuo);
        }

        public static List<CuotaEN> ListarCuotasCanceladasXContrato(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasCanceladasXContrato(pCuo);
        }

        public static void EliminarCuotasSinPagoXContratoXConceptoYMayorOIgualAPeriodo(CuotaEN pObj)
        {
            CuotaAD iCuoAD = new CuotaAD();
            iCuoAD.EliminarCuotasSinPagoXContratoXConceptoYMayorOIgualAPeriodo(pObj);
        }

        public static void GenerarCuotasXConcepto(CuotaEN pCuo)
        {
            //traer al lote de este contrato
            LoteEN iLotEN = new LoteEN();
            iLotEN.NumeroLote = pCuo.NumeroContrato;
            iLotEN = LoteRN.BuscarLoteXClave(iLotEN);

            //creamos un nuevo objeto cuota
            CuotaEN iCuoNueEN = new CuotaEN();

            //le pasamos datos
            iCuoNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iCuoNueEN.CodigoProyecto = "31"; //iLotEN.CodigoProyecto;
            iCuoNueEN.EtapaLote = "01"; // iLotEN.EtapaLote;
            iCuoNueEN.ManzanaLote = "A1"; // iLotEN.ManzanaLote;
            iCuoNueEN.NumeroLote = iLotEN.NumeroLote;
            iCuoNueEN.ClaveLote = CuotaRN.ObtenerClaveLote(iCuoNueEN);
            iCuoNueEN.PeriodoCuota = pCuo.PeriodoCuota;
            iCuoNueEN.AnoCuota = pCuo.AnoCuota;
            iCuoNueEN.CMesCuota = pCuo.CMesCuota;
            iCuoNueEN.CodigoConcepto = pCuo.CodigoConcepto;
            iCuoNueEN.CodigoCliente = iLotEN.CodigoAlmacen;
            iCuoNueEN.NumeroContrato = iLotEN.NumeroLote;
            iCuoNueEN.MontoCuota = pCuo.MontoCuota;
            iCuoNueEN.MontoPendienteCuota = iCuoNueEN.MontoCuota;
            iCuoNueEN.CMonedaCuota = "0";//soles
            iCuoNueEN.FechaEmisionCuota = pCuo.FechaEmisionCuota;
            iCuoNueEN.FechaVencimientoCuota = pCuo.FechaVencimientoCuota;
            iCuoNueEN.FechaPagoCuota = string.Empty;
            iCuoNueEN.CEstadoCuota = "0";
            iCuoNueEN.ClaveCuota = CuotaRN.ObtenerClaveCuota(iCuoNueEN);

            //adicionar a la b.d
            CuotaRN.AdicionarCuota(iCuoNueEN);
        }

        public static string ObtenerClaveLote(CuotaEN pObj)
        {
            //variavle resulatdo
            string iClave = string.Empty;
            iClave += pObj.CodigoEmpresa + "-";
            iClave += pObj.CodigoProyecto + "-";
            iClave += pObj.EtapaLote + "-";
            iClave += pObj.ManzanaLote + "-";
            iClave += pObj.NumeroLote;
            return iClave;
        }

        public static bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ExisteValorEnColumna(pColumna, pValor);
        }

        public static CuotaEN EsActoGenerarRecibos(CuotaEN pCuo)
        {
            //objeto resultado
            CuotaEN iCuoEN = new CuotaEN();

            //validar si hay cuotas para generar sus recibos
            iCuoEN.PeriodoCuota = pCuo.PeriodoCuota;
            iCuoEN.Adicionales.CampoOrden = CuotaEN.ClaCuo;
            List<CuotaEN> iLisCuoPer = CuotaRN.ListarCuotasXProyectoYPeriodo(iCuoEN);
            if (iLisCuoPer.Count == 0)
            {
                iCuoEN.Adicionales.EsVerdad = false;
                iCuoEN.Adicionales.Mensaje = "Este periodo no tiene cuotas para generar sus recibos";
                return iCuoEN;
            }

            ////validar que sea el ultimo periodo registrado en el sistema
            //iCuoEN.PeriodoCuota = Fecha.ObtenerSiguientePeriodo(pCuo.AnoCuota, pCuo.CMesCuota, "-");
            //List<CuotaEN> iLisCuoMayPer = CuotaRN.ListarCuotasXProyectoYPeriodo(iCuoEN);
            //if (iLisCuoMayPer.Count > 0)
            //{
            //    iCuoEN.Adicionales.EsVerdad = false;
            //    iCuoEN.Adicionales.Mensaje = "Hay periodos mayor a este";
            //    return iCuoEN;
            //}

            //validar que ya hay recibos enviados a propietarios
            List<CuotaEN> iLisEnvCorRec = CuotaRN.ObtenerCuotasConRecibosEnviadosAPropietarios(iLisCuoPer);
            if (iLisEnvCorRec.Count > 0)
            {
                iCuoEN.Adicionales.EsVerdad = false;
                iCuoEN.Adicionales.Mensaje = "Hay recibos generados de este periodo enviados a propietarios";
                return iCuoEN;
            }

            //ok
            iCuoEN.Adicionales.EsVerdad = true;
            return iCuoEN;
        }

        public static List<CuotaEN> ObtenerCuotasConRecibosEnviadosAPropietarios(List<CuotaEN> pListaCuota)
        {
            //lista resultado
            List<CuotaEN> iLisRes = new List<CuotaEN>();

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pListaCuota)
            {
                if (xCuo.EnvioCorreoRecibo == "1")//si
                {
                    iLisRes.Add(xCuo);
                }                
            }

            //devolver
            return iLisRes;
        }

        public static List<CuotaEN> ObtenerReporteSaldosAMes(CuotaEN pCuo)
        { 
            //lista resultado
            List<CuotaEN> iLisRes = new List<CuotaEN>();

            //traer todas las cuotas pendientes menores o iguales al periodo elegido
            pCuo.Adicionales.CampoOrden = CuotaEN.ClaCuo;
            iLisRes.AddRange(CuotaRN.ListarCuotasPendientesParaSaldosAMes(pCuo));

            //traer todas las cuotas canceladas menores o iguales al periodo elegido
            //pero con fecha de cobranza mayor al periodo elegido
            pCuo.FechaCobranzaCuota = Fecha.ObtenerPrimerDiaDelMesSiguiente(pCuo.AnoCuota, pCuo.CMesCuota).ToShortDateString();
            iLisRes.AddRange(CuotaRN.ListarCuotasCanceladasParaSaldosAMes(pCuo));
        
            //traer todas las cobranzas pero con fecha cobranza mayor al periodo elegido
            CobranzaEN iCobEN = new CobranzaEN();
            iCobEN.FechaCobranza = pCuo.FechaCobranzaCuota;
            iCobEN.Adicionales.CampoOrden = CobranzaEN.CorCob;
            List<CobranzaEN> iLisCob = CobranzaRN.ListarCobranzasParaSaldosAMes(iCobEN);

            //recorrer cada objeto cuota
            foreach (CuotaEN xCuo in iLisRes)
            {
                //recorrer cada objeto cobranza
                foreach (CobranzaEN xCob in iLisCob)
                {
                    //buscar las cobranzas de la cuota
                    if (xCob.ClaveCuota == xCuo.ClaveCuota)
                    {
                        //actualizar su monto pendiente
                        xCuo.MontoPendienteCuota = xCuo.MontoPendienteCuota + xCob.MontoCobradoCobranza - xCob.MontoDescuentoCobranza
                                                         - xCob.MontoMoraCobranza - xCob.MontoOtrosCobranza;
                    }                    
                }
                
                //obtener el monto cobrado de la cuota
                xCuo.MontoCobradoCuota = xCuo.MontoCuota - xCuo.MontoPendienteCuota;
            }

            //retornar
            return iLisRes;
        }

        public static List<CuotaEN> ListarCuotasPendientesParaSaldosAMes(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasPendientesParaSaldosAMes(pCuo);
        }

        public static List<CuotaEN> ListarCuotasCanceladasParaSaldosAMes(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasCanceladasParaSaldosAMes(pCuo);
        }

        public static List<CuotaEN> ListarCuotasDeNumerosContratos(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasDeNumerosContratos(pCuo);
        }

        public static List<CuotaEN> ListarCuotasXContrato(string pNumeroContrato, List<CuotaEN> pLista)
        {
            //objeto resultado
            List<CuotaEN> iLisResEN = new List<CuotaEN>();

            //buscar en lista
            foreach (CuotaEN xCuo in pLista)
            {
                if (pNumeroContrato == xCuo.NumeroContrato)
                {
                    iLisResEN.Add(xCuo);
                }
            }

            //devolver
            return iLisResEN;
        }

        public static decimal ObtenerSaldoAFavorEC(string pAnoPeriodo, string pCMesPeriodo, List<CuotaEN> pLista)
        {
            //valor resultado
            decimal iMonto = 0;

            //armar periodo
            string iPeriodo = pAnoPeriodo + "-" + pCMesPeriodo;

            //buscar en lista
            foreach (CuotaEN xCuo in pLista)
            {
                if (xCuo.PeriodoCuota.CompareTo(iPeriodo) == 1)
                {
                    iMonto += xCuo.MontoCuota - xCuo.MontoPendienteCuota;
                }
            }
            
            //devolver
            return iMonto;
        }

        public static decimal ObtenerDeudaVencidaEC(string pAnoPeriodo, string pCMesPeriodo, List<CuotaEN> pLista)
        {
            //valor resultado
            decimal iMonto = 0;

            //armar periodo
            string iPeriodo = pAnoPeriodo + "-" + pCMesPeriodo;

            //buscar en lista
            foreach (CuotaEN xCuo in pLista)
            {
                if (xCuo.PeriodoCuota.CompareTo(iPeriodo) == -1)
                {
                    iMonto += xCuo.MontoPendienteCuota;
                }
            }

            //devolver
            return iMonto;
        }

        public static decimal ObtenerDeudaPorVencerEC(string pAnoPeriodo, string pCMesPeriodo, int pIncrementoDiario, List<CuotaEN> pLista)
        {
            //valor resultado
            decimal iMonto = 0;

            //armar periodo
            string iPeriodo = pAnoPeriodo + "-" + pCMesPeriodo;

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                //suma todas las cuotas que son del periodo
                if (xCuo.PeriodoCuota.CompareTo(iPeriodo) == 0)
                {
                    iMonto += xCuo.MontoPendienteCuota;
                }

                //suma todos los dias pasados de todas las cuotas que son menores al periodo y que este pendiente
                if (xCuo.PeriodoCuota.CompareTo(iPeriodo) == -1 && xCuo.MontoPendienteCuota != 0)
                {
                    //comparar diferencia de dias
                    DateTime iFechaHoy = DateTime.Now;
                    DateTime iFechaCuota = Convert.ToDateTime(xCuo.FechaVencimientoCuota);
                    int iDifDias = Fecha.DiferenciaDias(iFechaCuota, iFechaHoy);
                    iMonto += pIncrementoDiario * iDifDias;
                }
            }

            //devolver
            return iMonto;
        }

        public static List<CuotaEN> ListarDetalleEC(string pAnoPeriodo, string pCMesPeriodo, int pIncrementoDiario, List<CuotaEN> pLista)
        {
            //lista resultado
            List<CuotaEN> iLisRes = new List<CuotaEN>();

            //armar periodo
            string iPeriodo = pAnoPeriodo + "-" + pCMesPeriodo;

            //objeto penalidad
            CuotaEN iCuoPen = new CuotaEN();
            iCuoPen.CodigoConcepto = "Pen";
            iCuoPen.PeriodoCuota = Fecha.AumentarPeriodo(pAnoPeriodo, pCMesPeriodo, "-", -1);

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                //suma todas las cuotas que son del periodo
                if (xCuo.PeriodoCuota.CompareTo(iPeriodo) == 0)
                {
                    iLisRes.Add(xCuo);
                }

                //suma todos los dias pasados de todas las cuotas que son menores al periodo y que estan pendientes
                if (xCuo.PeriodoCuota.CompareTo(iPeriodo) == -1 && xCuo.MontoPendienteCuota != 0)
                {
                    //comparar diferencia de dias
                    DateTime iFechaHoy = DateTime.Now;
                    DateTime iFechaCuota = Convert.ToDateTime(xCuo.FechaVencimientoCuota);
                    int iDifDias = Fecha.DiferenciaDias(iFechaCuota, iFechaHoy);
                    iCuoPen.Adicionales.Numero += iDifDias;
                    iCuoPen.MontoPendienteCuota += pIncrementoDiario * iDifDias;
                }
            }

            //insertamos el objeto penalidad
            iLisRes.Add(iCuoPen);

            //devolver
            return iLisRes;
        }

        public static CuotaEN BuscarCuotaXCodigoConcepto(CuotaEN pObj, List<CuotaEN> pLista)
        {
            //valor resultado
            CuotaEN iCuoEN = new CuotaEN();

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                if (xCuo.CodigoConcepto == pObj.CodigoConcepto)
                {
                    iCuoEN = xCuo;
                    return iCuoEN;
                }
            }

            //aqui no lo encontro
            return iCuoEN;
        }

        public static void ActualizarMorasFijas(DateTime pFechaCalculo, int pDiasMora, decimal pMontoMora)
        {
            //primero traer todas las cuotas pendientes
            CuotaEN iCuoEN = new CuotaEN();
            iCuoEN.Adicionales.CampoOrden = CuotaEN.ClaCuo;
            List<CuotaEN> iLisCuoPen = CuotaRN.ListarCuotasPendientes(iCuoEN);

            //lista que representa solo a las cuotas que se le va a actualizar su mora fija
            List<CuotaEN> iLisCuoMorFij = new List<CuotaEN>();

            //recorrer cada objeto
            foreach (CuotaEN xCuo in iLisCuoPen)
            {
                //si la cuota ya genero mora fija, ya no se ase nada , entonces pasa a la siguiente cuota del foreach 
                if (xCuo.CGeneroMoraFija == "1" ) { continue; }

                //convertir la fecha de vencimiento de la cuota a datetime
                DateTime iFechaVcto = Convert.ToDateTime(xCuo.FechaVencimientoCuota).Date;
                
                //obtener la diferencia de dias que hay entre la fecha de calculo y el vencimiento de la cuota
                //la funcion resta (pFechaCalculo - iFechaVcto)
                int iDiferenciaDias = Fecha.DiferenciaDias(iFechaVcto, pFechaCalculo);

                //si esta diferencia es mayor o igual a pDiasMora, entonces se le aplica su mora fija
                if (iDiferenciaDias >= pDiasMora)
                { 
                    //pasar la mora fija a la cuota
                    xCuo.MontoMoraPendiente = pMontoMora - (xCuo.MontoMora - xCuo.MontoMoraPendiente);
                    xCuo.MontoMora = pMontoMora;
                    xCuo.CGeneroMoraFija = "1";

                    //y luego lo agregamos a la lista que va a modificar en la bd
                    iLisCuoMorFij.Add(xCuo);
                }                
            }

            //modificar cuotas masivamente
            CuotaRN.ModificarCuota(iLisCuoMorFij);

        }

        public static decimal ObtenerMontoMora(decimal pMontoMoraAnterior, decimal pNuevaMora)
        {
            return pMontoMoraAnterior + pNuevaMora;
        }

        public static string ObtenerCEstadoCuota(string pCFormaCobro)
        {
            if (pCFormaCobro == "0")//total
            {
                return "1"; //cancelada
            }
            else
            {
                return "0";//pendiente
            }
        }

        public static string ObtenerCGeneroMoraFija(string pFechaVcto, string pFechaDeposito, EmpresaEN pEmp)
        {
            //obtener las diferencias de dias entre deposito-vcto
            int iDifDias = Fecha.DiferenciaDias(pFechaVcto, pFechaDeposito);

            //si es igual o mayor al dia de parametro para generar mora fija
            //if (iDifDias >= Convert.ToInt32(pEmp.DiasMoraFija))
            //{
            //    return "1";
            //}
            //else
            //{
            //    return "0";
            //}

            return "0";
        }

        public static List<CuotaEN> ListarCuotasCobradasXContrato(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarCuotasCobradasXContrato(pCuo);
        }

        public static decimal ObtenerMoraPagada(CuotaEN pCuo)
        {
            return pCuo.MontoMora - pCuo.MontoMoraPendiente;
        }

        public static List<List<CuotaEN>> ListarListasCuotasPorContratoEnPeriodo(CuotaEN pCuo)
        {
            CuotaAD iCuoAD = new CuotaAD();
            return iCuoAD.ListarListasCuotasPorContratoEnPeriodo(pCuo);
        }

        public static string ObtenerValorDeCampo(CuotaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CuotaEN.ClaObj: return pObj.ClaveObjeto;
                case CuotaEN.CodCli: return pObj.CodigoCliente;
                case CuotaEN.UsuAgr: return pObj.UsuarioAgrega;
                case CuotaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case CuotaEN.UsuMod: return pObj.UsuarioModifica;
                case CuotaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static void AsignarValorDeCampo(CuotaEN pObj, string pNombreCampo, string pValorCampo)
        {
            //segun nombre campo
            switch (pNombreCampo)
            {
                case CuotaEN.ClaObj: pObj.ClaveObjeto = pValorCampo; break;
                case CuotaEN.CodCli: pObj.CodigoCliente = pValorCampo; break;
                case CuotaEN.NumRec: pObj.NumeroRecibo = pValorCampo; break;
            }
        }

        public static void ActualizarValorCampo(string pNombreCampo, string pValorCampo, List<CuotaEN> pListaCuotas)
        {
            foreach (CuotaEN xCuo in pListaCuotas)
            {
                CuotaRN.AsignarValorDeCampo(xCuo, pNombreCampo, pValorCampo);                
            }
        }

        public static List<CuotaEN> ConvertirAUnaLista(List<List<CuotaEN>> pLisLisCuo)
        {
            //lista resultado
            List<CuotaEN> iLisRes = new List<CuotaEN>();

            //recorrer cada objeto
            foreach (List<CuotaEN> xLisCuo in pLisLisCuo)
            {
                iLisRes.AddRange(xLisCuo);                
            }
        
            //devolver
            return iLisRes;
        }

        public static void ModificarCuota(List<List<CuotaEN>> pLisLisCuo)
        {
            //primero convertimos a una solo lista
            List<CuotaEN> iLisCuo = CuotaRN.ConvertirAUnaLista(pLisLisCuo);

            //ahora si modificar masivamente
            CuotaRN.ModificarCuota(iLisCuo);
        }


    }
}
