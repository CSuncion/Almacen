using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Comun;
using Entidades.Adicionales;
using Entidades;
using Entidades.Estructuras;

namespace Negocio
{
    public class SaldoRN
    {

        
        public static SaldoEN EnBlanco()
        {
            SaldoEN iSalEN = new SaldoEN();
            return iSalEN;
        }

        public static void AdicionarSaldo(SaldoEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.AdicionarSaldo(pObj);
        }

        public static void AdicionarSaldo(List< SaldoEN> pLista)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.AdicionarSaldo(pLista);
        }

        public static void ModificarSaldo(SaldoEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.ModificarSaldo(pObj);
        }

        public static void ModificarSaldo(List< SaldoEN> pLista)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.ModificarSaldo(pLista);
        }

        public static void ModificarSaldoParaRecalculo(List<SaldoEN> pLista)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.ModificarSaldoParaRecalculo(pLista);
        }

        public static void EliminarSaldo(SaldoEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.EliminarSaldo(pObj);
        }

        public static void EliminarSaldo(List< SaldoEN> pLista)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.EliminarSaldo(pLista);
        }

        public static void EliminarSaldosPorAño(string pAñoSaldo)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.EliminarSaldosPorAño(pAñoSaldo);
        }

        public static void EliminarSaldosDeExistencia(ExistenciaEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            iSalAD.EliminarSaldosDeExistencia(pObj);
        }

        public static SaldoEN BuscarSaldoXClave(SaldoEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            return iSalAD.BuscarSaldoXClave(pObj);
        }

        public static List<SaldoEN> ListarSaldo(SaldoEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            return iSalAD.ListarSaldo(pObj);
        }

        public static List<SaldoEN> ListarSaldosDeAño(SaldoEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            return iSalAD.ListarSaldosDeAño(pObj);
        }

        public static List<SaldoEN> ListarSaldosDeAño(string pAño)
        {
            //asignar parametros
            SaldoEN iSalEN = new SaldoEN();
            iSalEN.AñoSaldo = pAño;
            iSalEN.Adicionales.CampoOrden = SaldoEN.ClaSal;

            //ejecutar metodo
            return SaldoRN.ListarSaldosDeAño(iSalEN);
        }

        public static string ObtenerClaveSaldo(SaldoEN pObj)
        { 
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.AñoSaldo + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoExistencia;

            //devolver
            return iClave;
        }

        public static string ObtenerValorDeCampo(SaldoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case SaldoEN.ClaObj: return pObj.ClaveObjeto;
                case SaldoEN.ClaSal: return pObj.ClaveSaldo;
                case SaldoEN.CodEmp: return pObj.CodigoEmpresa;
                case SaldoEN.CodAlm: return pObj.CodigoAlmacen;
                case SaldoEN.DesAlm: return pObj.DescripcionAlmacen;
                case SaldoEN.CodExi: return pObj.CodigoExistencia;
                case SaldoEN.DesExi: return pObj.DescripcionExistencia;
                case SaldoEN.AñoSal: return pObj.AñoSaldo;
                case SaldoEN.StkIni: return pObj.StockInicio.ToString();
                case SaldoEN.ProIni: return pObj.PromedioInicio.ToString();
                case SaldoEN.IngIni: return pObj.IngresosInicio.ToString();
                case SaldoEN.SalIni: return pObj.SalidasInicio.ToString();
                case SaldoEN.StkEne: return pObj.StockEnero.ToString();
                case SaldoEN.ProEne: return pObj.PromedioEnero.ToString();
                case SaldoEN.IngEne: return pObj.IngresosEnero.ToString();
                case SaldoEN.SalEne: return pObj.SalidasEnero.ToString();
                case SaldoEN.StkFeb: return pObj.StockFebrero.ToString();
                case SaldoEN.ProFeb: return pObj.PromedioFebrero.ToString();
                case SaldoEN.IngFeb: return pObj.IngresosFebrero.ToString();
                case SaldoEN.SalFeb: return pObj.SalidasFebrero.ToString();
                case SaldoEN.StkMar: return pObj.StockMarzo.ToString();
                case SaldoEN.ProMar: return pObj.PromedioMarzo.ToString();
                case SaldoEN.IngMar: return pObj.IngresosMarzo.ToString();
                case SaldoEN.SalMar: return pObj.SalidasMarzo.ToString();
                case SaldoEN.StkAbr: return pObj.StockAbril.ToString();
                case SaldoEN.ProAbr: return pObj.PromedioAbril.ToString();
                case SaldoEN.IngAbr: return pObj.IngresosAbril.ToString();
                case SaldoEN.SalAbr: return pObj.SalidasAbril.ToString();
                case SaldoEN.StkMay: return pObj.StockMayo.ToString();
                case SaldoEN.ProMay: return pObj.PromedioMayo.ToString();
                case SaldoEN.IngMay: return pObj.IngresosMayo.ToString();
                case SaldoEN.SalMay: return pObj.SalidasMayo.ToString();
                case SaldoEN.StkJun: return pObj.StockJunio.ToString();
                case SaldoEN.ProJun: return pObj.PromedioJunio.ToString();
                case SaldoEN.IngJun: return pObj.IngresosJunio.ToString();
                case SaldoEN.SalJun: return pObj.SalidasJunio.ToString();
                case SaldoEN.StkJul: return pObj.StockJulio.ToString();
                case SaldoEN.ProJul: return pObj.PromedioJulio.ToString();
                case SaldoEN.IngJul: return pObj.IngresosJulio.ToString();
                case SaldoEN.SalJul: return pObj.SalidasJulio.ToString();
                case SaldoEN.StkAgo: return pObj.StockAgosto.ToString();
                case SaldoEN.ProAgo: return pObj.PromedioAgosto.ToString();
                case SaldoEN.IngAgo: return pObj.IngresosAgosto.ToString();
                case SaldoEN.SalAgo: return pObj.SalidasAgosto.ToString();
                case SaldoEN.StkSet: return pObj.StockSetiembre.ToString();
                case SaldoEN.ProSet: return pObj.PromedioSetiembre.ToString();
                case SaldoEN.IngSet: return pObj.IngresosSetiembre.ToString();
                case SaldoEN.SalSet: return pObj.SalidasSetiembre.ToString();
                case SaldoEN.StkOct: return pObj.StockOctubre.ToString();
                case SaldoEN.ProOct: return pObj.PromedioOctubre.ToString();
                case SaldoEN.IngOct: return pObj.IngresosOctubre.ToString();
                case SaldoEN.SalOct: return pObj.SalidasOctubre.ToString();
                case SaldoEN.StkNov: return pObj.StockNoviembre.ToString();
                case SaldoEN.ProNov: return pObj.PromedioNoviembre.ToString();
                case SaldoEN.IngNov: return pObj.IngresosNoviembre.ToString();
                case SaldoEN.SalNov: return pObj.SalidasNoviembre.ToString();
                case SaldoEN.StkDic: return pObj.StockDiciembre.ToString();
                case SaldoEN.ProDic: return pObj.PromedioDiciembre.ToString();
                case SaldoEN.IngDic: return pObj.IngresosDiciembre.ToString();
                case SaldoEN.SalDic: return pObj.SalidasDiciembre.ToString();
                case SaldoEN.CEstSal: return pObj.CEstadoSaldo;
                case SaldoEN.NEstSal: return pObj.NEstadoSaldo;
                case SaldoEN.UsuAgr: return pObj.UsuarioAgrega;
                case SaldoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case SaldoEN.UsuMod: return pObj.UsuarioModifica;
                case SaldoEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static decimal ObtenerStock(SaldoEN pObj, string pCodigoMes)
        {
            //valor resultado
            decimal iValor = 0;

            switch (pCodigoMes)
            {
                case "00": { iValor = pObj.StockInicio; break; }
                case "01": { iValor = pObj.StockEnero; break; }
                case "02": { iValor = pObj.StockFebrero; break; }
                case "03": { iValor = pObj.StockMarzo; break; }
                case "04": { iValor = pObj.StockAbril; break; }
                case "05": { iValor = pObj.StockMayo; break; }
                case "06": { iValor = pObj.StockJunio; break; }
                case "07": { iValor = pObj.StockJulio; break; }
                case "08": { iValor = pObj.StockAgosto; break; }
                case "09": { iValor = pObj.StockSetiembre; break; }
                case "10": { iValor = pObj.StockOctubre; break; }
                case "11": { iValor = pObj.StockNoviembre; break; }
                case "12": { iValor = pObj.StockDiciembre; break; }
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerPrecioPromedio(SaldoEN pObj, string pCodigoMes)
        {
            //valor resultado
            decimal iValor = 0;

            switch (pCodigoMes)
            {
                case "00": { iValor = pObj.PromedioInicio; break; }
                case "01": { iValor = pObj.PromedioEnero; break; }
                case "02": { iValor = pObj.PromedioFebrero; break; }
                case "03": { iValor = pObj.PromedioMarzo; break; }
                case "04": { iValor = pObj.PromedioAbril; break; }
                case "05": { iValor = pObj.PromedioMayo; break; }
                case "06": { iValor = pObj.PromedioJunio; break; }
                case "07": { iValor = pObj.PromedioJulio; break; }
                case "08": { iValor = pObj.PromedioAgosto; break; }
                case "09": { iValor = pObj.PromedioSetiembre; break; }
                case "10": { iValor = pObj.PromedioOctubre; break; }
                case "11": { iValor = pObj.PromedioNoviembre; break; }
                case "12": { iValor = pObj.PromedioDiciembre; break; }
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerIngresos(SaldoEN pObj, string pCodigoMes)
        {
            //valor resultado
            decimal iValor = 0;

            switch (pCodigoMes)
            {
                case "00": { iValor = pObj.IngresosInicio; break; }
                case "01": { iValor = pObj.IngresosEnero; break; }
                case "02": { iValor = pObj.IngresosFebrero; break; }
                case "03": { iValor = pObj.IngresosMarzo; break; }
                case "04": { iValor = pObj.IngresosAbril; break; }
                case "05": { iValor = pObj.IngresosMayo; break; }
                case "06": { iValor = pObj.IngresosJunio; break; }
                case "07": { iValor = pObj.IngresosJulio; break; }
                case "08": { iValor = pObj.IngresosAgosto; break; }
                case "09": { iValor = pObj.IngresosSetiembre; break; }
                case "10": { iValor = pObj.IngresosOctubre; break; }
                case "11": { iValor = pObj.IngresosNoviembre; break; }
                case "12": { iValor = pObj.IngresosDiciembre; break; }
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerSalidas(SaldoEN pObj, string pCodigoMes)
        {
            //valor resultado
            decimal iValor = 0;

            switch (pCodigoMes)
            {
                case "00": { iValor = pObj.SalidasInicio; break; }
                case "01": { iValor = pObj.SalidasEnero; break; }
                case "02": { iValor = pObj.SalidasFebrero; break; }
                case "03": { iValor = pObj.SalidasMarzo; break; }
                case "04": { iValor = pObj.SalidasAbril; break; }
                case "05": { iValor = pObj.SalidasMayo; break; }
                case "06": { iValor = pObj.SalidasJunio; break; }
                case "07": { iValor = pObj.SalidasJulio; break; }
                case "08": { iValor = pObj.SalidasAgosto; break; }
                case "09": { iValor = pObj.SalidasSetiembre; break; }
                case "10": { iValor = pObj.SalidasOctubre; break; }
                case "11": { iValor = pObj.SalidasNoviembre; break; }
                case "12": { iValor = pObj.SalidasDiciembre; break; }
            }

            //devolver
            return iValor;
        }

        public static void ModificarStock(SaldoEN pObj, string pCodigoMes, decimal pValor)
        {
            switch (pCodigoMes)
            {
                case "00": { pObj.StockInicio = pValor; break; }
                case "01": { pObj.StockEnero = pValor; break; }
                case "02": { pObj.StockFebrero = pValor; break; }
                case "03": { pObj.StockMarzo = pValor; break; }
                case "04": { pObj.StockAbril = pValor; break; }
                case "05": { pObj.StockMayo = pValor; break; }
                case "06": { pObj.StockJunio = pValor; break; }
                case "07": { pObj.StockJulio = pValor; break; }
                case "08": { pObj.StockAgosto = pValor; break; }
                case "09": { pObj.StockSetiembre = pValor; break; }
                case "10": { pObj.StockOctubre = pValor; break; }
                case "11": { pObj.StockNoviembre = pValor; break; }
                case "12": { pObj.StockDiciembre = pValor; break; }
            }
        }

        public static void ModificarPrecioPromedio(SaldoEN pObj, string pCodigoMes, decimal pValor)
        {
            switch (pCodigoMes)
            {
                case "00": { pObj.PromedioInicio = pValor; break; }
                case "01": { pObj.PromedioEnero = pValor; break; }
                case "02": { pObj.PromedioFebrero = pValor; break; }
                case "03": { pObj.PromedioMarzo = pValor; break; }
                case "04": { pObj.PromedioAbril = pValor; break; }
                case "05": { pObj.PromedioMayo = pValor; break; }
                case "06": { pObj.PromedioJunio = pValor; break; }
                case "07": { pObj.PromedioJulio = pValor; break; }
                case "08": { pObj.PromedioAgosto = pValor; break; }
                case "09": { pObj.PromedioSetiembre = pValor; break; }
                case "10": { pObj.PromedioOctubre = pValor; break; }
                case "11": { pObj.PromedioNoviembre = pValor; break; }
                case "12": { pObj.PromedioDiciembre = pValor; break; }
            }
        }

        public static void ModificarIngresos(SaldoEN pObj, string pCodigoMes, decimal pValor)
        {
            switch (pCodigoMes)
            {
                case "00": { pObj.IngresosInicio = pValor; break; }
                case "01": { pObj.IngresosEnero = pValor; break; }
                case "02": { pObj.IngresosFebrero = pValor; break; }
                case "03": { pObj.IngresosMarzo = pValor; break; }
                case "04": { pObj.IngresosAbril = pValor; break; }
                case "05": { pObj.IngresosMayo = pValor; break; }
                case "06": { pObj.IngresosJunio = pValor; break; }
                case "07": { pObj.IngresosJulio = pValor; break; }
                case "08": { pObj.IngresosAgosto = pValor; break; }
                case "09": { pObj.IngresosSetiembre = pValor; break; }
                case "10": { pObj.IngresosOctubre = pValor; break; }
                case "11": { pObj.IngresosNoviembre = pValor; break; }
                case "12": { pObj.IngresosDiciembre = pValor; break; }
            }
        }

        public static void ModificarSalidas(SaldoEN pObj, string pCodigoMes, decimal pValor)
        {
            switch (pCodigoMes)
            {
                case "00": { pObj.SalidasInicio = pValor; break; }
                case "01": { pObj.SalidasEnero = pValor; break; }
                case "02": { pObj.SalidasFebrero = pValor; break; }
                case "03": { pObj.SalidasMarzo = pValor; break; }
                case "04": { pObj.SalidasAbril = pValor; break; }
                case "05": { pObj.SalidasMayo = pValor; break; }
                case "06": { pObj.SalidasJunio = pValor; break; }
                case "07": { pObj.SalidasJulio = pValor; break; }
                case "08": { pObj.SalidasAgosto = pValor; break; }
                case "09": { pObj.SalidasSetiembre = pValor; break; }
                case "10": { pObj.SalidasOctubre = pValor; break; }
                case "11": { pObj.SalidasNoviembre = pValor; break; }
                case "12": { pObj.SalidasDiciembre = pValor; break; }
            }
        }

        public static void PonerCerosEnPeriodo(string pCodigoMes, List<SaldoEN> pLisSal)
        {           
            //recorrer cada objeto
            foreach (SaldoEN xSal in pLisSal)
            {
                SaldoRN.ModificarStock(xSal, pCodigoMes, 0);
                SaldoRN.ModificarPrecioPromedio(xSal, pCodigoMes, 0);
                SaldoRN.ModificarIngresos(xSal, pCodigoMes, 0);
                SaldoRN.ModificarSalidas(xSal, pCodigoMes, 0);
            }                        
        }

        public static void ModificarSaldosAMontoCeroEnMes(string pCodigoMes, List<SaldoEN> pLisSal)
        {
            //actualizamos a cero a los objetos de la lista
            SaldoRN.PonerCerosEnPeriodo(pCodigoMes, pLisSal);

            //actualizar en la b.d
            SaldoRN.ModificarSaldo(pLisSal);
        }

        public static SaldoEN BuscarSaldo(string pCampo, string pValor, List<SaldoEN> pLista)
        {
            //objeto resultaddo
            SaldoEN iSalEN = new SaldoEN();

            //recorrer cada objeto
            foreach (SaldoEN xSal in pLista)
            {
                if (SaldoRN.ObtenerValorDeCampo(xSal, pCampo) == pValor)
                {
                    return xSal;
                }
            }

            //devolver
            return iSalEN;
        }

        public static SaldoEN BuscarSaldo(string pCampo1, string pValor1, string pCampo2, string pValor2, List<SaldoEN> pLista)
        {
            //objeto resultaddo
            SaldoEN iSalEN = new SaldoEN();

            //recorrer cada objeto
            foreach (SaldoEN xSal in pLista)
            {
                if (SaldoRN.ObtenerValorDeCampo(xSal, pCampo1) == pValor1 && SaldoRN.ObtenerValorDeCampo(xSal, pCampo2) == pValor2)
                {
                    return xSal;
                }
            }

            //devolver
            return iSalEN;
        }

        public static void AdicionarSaldo(ExistenciaEN pObj)
        {          
            //se crea su saldo apartir de la existencia
            SaldoEN iSalEN = SaldoRN.CrearSaldoDeExistencia(pObj);

            //adicionar
            SaldoRN.AdicionarSaldo(iSalEN);
        }

        public static SaldoEN CrearSaldoDeExistencia(ExistenciaEN pObj)
        {
            //se crea su saldo apartir de la existencia
            SaldoEN iSalEN = SaldoRN.CrearSaldoDeExistencia(pObj, Fecha.ObtenerAño(DateTime.Now));
            
            //devolver
            return iSalEN;
        }

        public static SaldoEN CrearSaldoDeExistencia(ExistenciaEN pObj,string pAñoSaldo)
        {
            //se crea su saldo apartir de la existencia
            SaldoEN iSalEN = new SaldoEN();

            //pasamos datos
            iSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSalEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iSalEN.CodigoExistencia = pObj.CodigoExistencia;
            iSalEN.AñoSaldo = pAñoSaldo;
            iSalEN.ClaveSaldo = SaldoRN.ObtenerClaveSaldo(iSalEN);

            //devolver
            return iSalEN;
        }

        public static List<SaldoEN> ListarSaldosParaKardex(SaldoEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            return iSalAD.ListarSaldosParaKardex(pObj);
        }

        public static List<SaldoEN> ListarSaldosParaKardex(string pAño, string pCodigoAlmacen,
            string pCTipoExistencia, string pCodigoExistenciaDesde, string pCodigoExistenciaHasta)
        {
            //asignar parametros
            SaldoEN iSalEN = new SaldoEN();
            iSalEN.AñoSaldo = pAño;
            iSalEN.CodigoAlmacen = pCodigoAlmacen;
            iSalEN.CodigoTipo = pCTipoExistencia;
            iSalEN.Adicionales.Desde1 = pCodigoExistenciaDesde;
            iSalEN.Adicionales.Hasta1 = pCodigoExistenciaHasta;
            iSalEN.Adicionales.CampoOrden = SaldoEN.ClaSal;

            //ejecutar metodo
            return SaldoRN.ListarSaldosParaKardex(iSalEN);
        }
        
        public static bool EsSaldoMostrableEnKardex(SaldoEN pObj, string pCodigoMesProceso, string pCodigoMesAnterior)
        {
            //si el mes anterior tiene stock , entonces si se debe mostrar este saldo en el kardex
            if (SaldoRN.ObtenerStock(pObj, pCodigoMesAnterior) != 0) { return true; }

            //si el mes de proceso tiene movimientos , entonces si se debe mostrar este saldo en el kardex
            if (SaldoRN.ObtenerIngresos(pObj, pCodigoMesProceso) != 0 || SaldoRN.ObtenerSalidas(pObj, pCodigoMesProceso) != 0) { return true; }
            
            //aqui no debe salir este saldo en el kardex
            return false;
        }

        public static KardexValorizado ArmarKardexValorizadoDeSoloSaldo(SaldoEN iSal, string pCodigoMesProceso, string pCodigoMesAnterior)
        {
            //objeto resultado
            KardexValorizado iKarVal = new KardexValorizado();

            //pasamos datos
            iKarVal.CodigoExistencia = iSal.CodigoExistencia;
            iKarVal.DescripcionExistencia = iSal.DescripcionExistencia;
            iKarVal.CodigoUnidadMedida = iSal.CodigoUnidadMedida;
            iKarVal.CantidadAnterior = SaldoRN.ObtenerStock(iSal, pCodigoMesAnterior);
            iKarVal.PrecioAnterior = SaldoRN.ObtenerPrecioPromedio(iSal, pCodigoMesAnterior);
            iKarVal.TotalAnterior = iKarVal.CantidadAnterior * iKarVal.PrecioAnterior;           
            iKarVal.CantidadActual = iKarVal.CantidadAnterior;
            iKarVal.PrecioActual = iKarVal.PrecioAnterior;
            iKarVal.TotalActual = iKarVal.TotalAnterior;
            
            //devolver
            return iKarVal;
        }

        public static KardexFisico ArmarKardexFisicoDeSaldo(SaldoEN iSal,string pCodigoMesProceso, string pCodigoMesAnterior)
        {
            //objeto resultado
            KardexFisico iKarFis = new KardexFisico();

            //pasamos datos
            iKarFis.CodigoExistencia = iSal.CodigoExistencia;
            iKarFis.DescripcionExistencia = iSal.DescripcionExistencia;
            iKarFis.CodigoUnidadMedida = iSal.CodigoUnidadMedida;
            iKarFis.CodigoTipo = iSal.CodigoTipo;
            iKarFis.NombreTipo = iSal.NombreTipo;
            iKarFis.StockAnterior = SaldoRN.ObtenerStock(iSal, pCodigoMesAnterior);
            iKarFis.Ingresos = SaldoRN.ObtenerIngresos(iSal, pCodigoMesProceso);
            iKarFis.Salidas = SaldoRN.ObtenerSalidas(iSal, pCodigoMesProceso);
            iKarFis.StockActual = SaldoRN.ObtenerStockActualKardexFisico(iSal, pCodigoMesProceso, pCodigoMesAnterior);
            iKarFis.PrecioUnitario = SaldoRN.ObtenerPrecioUnitarioKardexFisico(iSal, pCodigoMesProceso, pCodigoMesAnterior);
            iKarFis.Total = iKarFis.StockActual * iKarFis.PrecioUnitario;

            //devolver
            return iKarFis;
        }

        public static decimal ObtenerStockActualKardexFisico(SaldoEN iSal, string pCodigoMesProceso, string pCodigoMesAnterior)
        {
            //valor resultado
            decimal iStock = 0;

            //si el mes de proceso tiene movimientos,entoces sale del stock del mes de proceso
            if (SaldoRN.ObtenerIngresos(iSal, pCodigoMesProceso) != 0 || SaldoRN.ObtenerSalidas(iSal, pCodigoMesProceso) != 0)
            {
                iStock = SaldoRN.ObtenerStock(iSal, pCodigoMesProceso);
            }
            else
            {
                iStock = SaldoRN.ObtenerStock(iSal, pCodigoMesAnterior);
            }

            //devolver
            return iStock;
        }

        public static decimal ObtenerPrecioUnitarioKardexFisico(SaldoEN iSal, string pCodigoMesProceso, string pCodigoMesAnterior)
        {
            //valor resultado
            decimal iPrecio = 0;

            //si el mes de proceso tiene movimientos,entoces sale del stock del mes de proceso
            if (SaldoRN.ObtenerIngresos(iSal, pCodigoMesProceso) != 0 || SaldoRN.ObtenerSalidas(iSal, pCodigoMesProceso) != 0)
            {
                iPrecio = SaldoRN.ObtenerPrecioPromedio(iSal, pCodigoMesProceso);
            }
            else
            {
                iPrecio = SaldoRN.ObtenerPrecioPromedio(iSal, pCodigoMesAnterior);
            }

            //devolver
            return iPrecio;
        }

        public static List<SaldosExistencia> ListarParaSaldosExistencia(SaldoEN pObj)
        {
            //lista resultado
            List<SaldosExistencia> iLisRes = new List<SaldosExistencia>();

            //buscar al saldo
            SaldoEN iSalEN = SaldoRN.BuscarSaldoXClave(pObj);

            //creamos la linea para los totales
            SaldosExistencia iSalExiTot = new SaldosExistencia();
            iSalExiTot.NombreMes = "TOTAL";
            
            //recorrer cada mes
            for (int i = 1; i < 13; i++)
            {
                //mes actual
                string iMesActual = Cadena.CompletarCadena(i.ToString(), 2, "0", Cadena.Direccion.Izquierda);

                //mes anterior
                string iMesAnterior = Cadena.CompletarCadena((i - 1).ToString(), 2, "0", Cadena.Direccion.Izquierda);
                
                //creamos un nuevo saldoexistencia
                SaldosExistencia iSalExi = new SaldosExistencia();

                //actualizar datos 
                iSalExi.CodigoMes = iMesActual;              
                iSalExi.NombreMes = Fecha.ObtenerMesEnNombre(iMesActual);
                iSalExi.StockAnterior = SaldoRN.ObtenerStock(iSalEN, iMesAnterior);
                iSalExi.Ingresos = SaldoRN.ObtenerIngresos(iSalEN, iMesActual);
                iSalExi.Salidas = SaldoRN.ObtenerSalidas(iSalEN, iMesActual);
                iSalExi.StockActual = SaldoRN.ObtenerStock(iSalEN, iMesActual);

                //actualizando a la linea totales
                iSalExiTot.Ingresos += iSalExi.Ingresos;
                iSalExiTot.Salidas += iSalExi.Salidas;

                //adicionar a la lista resultado
                iLisRes.Add(iSalExi);
            }

            //obtener la linea total
            iLisRes.Add(iSalExiTot);

            //devolver
            return iLisRes;
        }

        public static List<SaldoEN> ListarSaldosParaResumenTipoExistencia(SaldoEN pObj)
        {
            SaldoAD iSalAD = new SaldoAD();
            return iSalAD.ListarSaldosParaResumenTipoExistencia(pObj);
        }

        public static List<SaldoEN> ListarSaldosParaResumenTipoExistencia(string pAño, string pCodigoAlmacen, string pCodigoTipo)
        {
            //asignar parametros
            SaldoEN iSalEN = new SaldoEN();
            iSalEN.AñoSaldo = pAño;
            iSalEN.CodigoAlmacen = pCodigoAlmacen;            
            iSalEN.CodigoTipo = pCodigoTipo;
            iSalEN.Adicionales.CampoOrden = SaldoEN.CodTip;

            //ejecutar metodo
            return SaldoRN.ListarSaldosParaResumenTipoExistencia(iSalEN);
        }
        
        public static List<KardexFisico> ObtenerReporteResumenTiposExistencia(string pAño, string pCodigoMes, string pCodigoAlmacen,
             string pCodigoTipoExistencia)
        {
            //lista resultado
            List<KardexFisico> iLisRes = new List<KardexFisico>();

            //traer todos los saldos del año que tiene el periodo elegido para el reporte
            List<SaldoEN> iLisSal = SaldoRN.ListarSaldosParaResumenTipoExistencia(pAño, pCodigoAlmacen, pCodigoTipoExistencia);

            //le bajamos una unidad al codigoMes,este codigo sirve para obtener el stock y precio anterior
            //al mes que se esta procesando
            string iCodigoMesAnterior = Numero.DisminuirCorrelativoNumerico(pCodigoMes);

            //variables
            string iCodigoTipo = string.Empty;
            int iIndiceObjeto = -1;

            //recorrer cada objeto saldo
            foreach (SaldoEN xSal in iLisSal)
            {
                //armar KardexFisico que se pueden obtener del objeto saldo,se utiliza esta funcion porque
                //el reporte resumen tipo existencia tiene los mismos campos que obtiene esta funcion
                KardexFisico iKarFis = SaldoRN.ArmarKardexFisicoDeSaldo(xSal, pCodigoMes, iCodigoMesAnterior);

                //si el codigoTipo es diferente, entonces adicionamos este objeto a la lista
                if (xSal.CodigoTipo != iCodigoTipo)
                {
                    //agregar a la lista resultado
                    iLisRes.Add(iKarFis);

                    //actualizar variables
                    iCodigoTipo = xSal.CodigoTipo;
                    iIndiceObjeto++;
                }
                else
                {
                    iLisRes[iIndiceObjeto].StockAnterior += iKarFis.StockAnterior;
                    iLisRes[iIndiceObjeto].Ingresos += iKarFis.Ingresos;
                    iLisRes[iIndiceObjeto].Salidas += iKarFis.Salidas;
                    iLisRes[iIndiceObjeto].StockActual += iKarFis.StockActual;
                }

            }


            //devolver
            return iLisRes;
        }

        public static List<SaldoEN> ListarNuevosSaldosPorCierreAnual(string pAñoCierre)
        {
            //lista resultado
            List<SaldoEN> iLisRes = new List<SaldoEN>();

            //traer todos los saldos del año cierre
            List<SaldoEN> iLisSalCie = SaldoRN.ListarSaldosDeAño(pAñoCierre);
        
            //recorrer cada objeto saldo
            foreach (SaldoEN xSal in iLisSalCie)
            {
                //obtener el nuevo saldo, apartir del saldo anterior
                SaldoEN iSalEN = SaldoRN.ObtenerNuevoSaldoPorCierreAnual(xSal);

                //adicionamos a la lista resultado
                iLisRes.Add(iSalEN);
            }

            //devolver
            return iLisRes;
        }

        public static SaldoEN ObtenerNuevoSaldoPorCierreAnual(SaldoEN pSaldoAñoCierre)
        {
            //objeto resultado
            SaldoEN iSalEN = new SaldoEN();

            //pasamos datos
            iSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSalEN.CodigoAlmacen = pSaldoAñoCierre.CodigoAlmacen;
            iSalEN.CodigoExistencia = pSaldoAñoCierre.CodigoExistencia;
            iSalEN.AñoSaldo = Numero.IncrementarCorrelativoNumerico(pSaldoAñoCierre.AñoSaldo);
            iSalEN.ClaveSaldo = SaldoRN.ObtenerClaveSaldo(iSalEN);

            //pasamos los datos de diciembre del año cierre a Inicial del nuevo año
            iSalEN.StockInicio = pSaldoAñoCierre.StockDiciembre;
            iSalEN.PromedioInicio = pSaldoAñoCierre.PromedioDiciembre;
            iSalEN.SalidasInicio = pSaldoAñoCierre.SalidasDiciembre;
            iSalEN.IngresosInicio = pSaldoAñoCierre.IngresosDiciembre;

            //devolver
            return iSalEN;
        }

        public static void AdicionarNuevosSaldosPorCierreAnual(string pAñoCierre)
        {
            //listar los nuevos saldo para adicionar al siguiente año del cierre
            List<SaldoEN> iLisSalAdi = SaldoRN.ListarNuevosSaldosPorCierreAnual(pAñoCierre);

            //adicionar masivo
            SaldoRN.AdicionarSaldo(iLisSalAdi);
        }

        public static void EliminarNuevosSaldosPorCierreAnual(string pAñoCierre)
        {
            //asignar parametros
            string iAñoSaldo = Numero.IncrementarCorrelativoNumerico(pAñoCierre);

            //ejecutar metodo
            SaldoRN.EliminarSaldosPorAño(iAñoSaldo);
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SaldoAD iPerAD = new SaldoAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SaldoAD iPerAD = new SaldoAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SaldoAD iPerAD = new SaldoAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static SaldoEN EsActoGenerarCierreAnual(string pAñoCierre)
        {
            //objeto resultado            
            SaldoEN iSalEN = new SaldoEN();

            //valida cuando no hay saldo en este año
            iSalEN = SaldoRN.ValidaCuandoNoHaySaldosDeAño(pAñoCierre);
            if (iSalEN.Adicionales.EsVerdad == false) { return iSalEN; }

            //valida cuando no hay ningun periodo abierto en este año de cierre
            iSalEN = SaldoRN.ValidaCuandoNoHayPeriodosDeAñoYActivos(pAñoCierre);
            if (iSalEN.Adicionales.EsVerdad == false) { return iSalEN; }

            //devolver
            return iSalEN;
        }

        public static SaldoEN ValidaCuandoNoHaySaldosDeAño(string pAñoSaldo)
        {
            //objeto resultado
            SaldoEN iSalEN = new SaldoEN();

            //validar
            bool iEsVerdad = SaldoRN.ExisteValorEnColumnaConEmpresa(SaldoEN.AñoSal, pAñoSaldo);
            if (iEsVerdad == false)
            {
                iSalEN.Adicionales.EsVerdad = false;
                iSalEN.Adicionales.Mensaje = "No hay saldos en este año";
            }

            //devolver
            return iSalEN;
        }

        public static SaldoEN ValidaCuandoNoHayPeriodosDeAñoYActivos(string pAñoPeriodo)
        {
            //objeto resultado
            SaldoEN iSalEN = new SaldoEN();

            //validar
            PeriodoEN iPerEN = PeriodoRN.HayPeriodosDeAñoYActivos(pAñoPeriodo);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                iSalEN.Adicionales.EsVerdad = false;
                iSalEN.Adicionales.Mensaje = "Por lo menos se debe tener un periodo activo en este año";
            }

            //devolver
            return iSalEN;
        }

        public static void AdicionarSaldos(ExistenciaEN pObj)
        {            
            //traemos todos los años distintos que hay en periodos de la empresa de acceso
            List<string> iLisAñoPer = PeriodoRN.ListarAñosPeriodos();

            //lista de saldos a adicionar en bd
            List<SaldoEN> iLisSalAdi = SaldoRN.ListarNuevosSaldosAExistencia(pObj, iLisAñoPer);

            //adicionar masivo
            SaldoRN.AdicionarSaldo(iLisSalAdi);
        }

        public static List<SaldoEN> ListarNuevosSaldosAExistencia(ExistenciaEN pObj, List<string> pLisAñoPer)
        {
            //lista de saldos a adicionar en bd
            List<SaldoEN> iLisSalAdi = new List<SaldoEN>();
            
            //recorre cada objeto
            foreach (string xAño in pLisAñoPer)
            {
                //se crea su saldo apartir de la existencia
                SaldoEN iSalEN = SaldoRN.CrearSaldoDeExistencia(pObj, xAño);

                //adicionamos a la lista resultado
                iLisSalAdi.Add(iSalEN);
            }

            //devolver
            return iLisSalAdi;
        }

        public static string ObtenerClaveExistencia(SaldoEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            ExistenciaEN iExiEN = new ExistenciaEN();
            iExiEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iExiEN.CodigoExistencia = pObj.CodigoExistencia;

            iClave = ExistenciaRN.ObtenerClaveExistencia(iExiEN);
           
            //devolver
            return iClave;
        }


    }
}
