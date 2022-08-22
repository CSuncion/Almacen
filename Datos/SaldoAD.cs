using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptBD;
using Entidades.Adicionales;
using Datos.Config;
using System.Data;
using Comun;
using Entidades;

namespace Datos
{
    public class SaldoAD
    {
        
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<SaldoEN> xLista = new List<SaldoEN>();
        private SaldoEN xObj = new SaldoEN();
        private string xTabla = "Saldo";
        private string xVista = "VsSaldo";


        #region Metodos privados

        private SaldoEN Objeto(IDataReader iDr)
        {
            SaldoEN xObjEnc = new SaldoEN();
            xObjEnc.ClaveSaldo = iDr[SaldoEN.ClaSal].ToString();
            xObjEnc.CodigoEmpresa = iDr[SaldoEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[SaldoEN.NomEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[SaldoEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[SaldoEN.DesAlm].ToString();
            xObjEnc.CodigoExistencia = iDr[SaldoEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[SaldoEN.DesExi].ToString();
            xObjEnc.CodigoTipo = iDr[SaldoEN.CodTip].ToString();
            xObjEnc.NombreTipo = iDr[SaldoEN.NomTip].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[SaldoEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[SaldoEN.NomUniMed].ToString();
            xObjEnc.AñoSaldo = iDr[SaldoEN.AñoSal].ToString();           
            xObjEnc.StockInicio = Convert.ToDecimal(iDr[SaldoEN.StkIni].ToString());
            xObjEnc.PromedioInicio = Convert.ToDecimal(iDr[SaldoEN.ProIni].ToString());
            xObjEnc.IngresosInicio = Convert.ToDecimal(iDr[SaldoEN.IngIni].ToString());
            xObjEnc.SalidasInicio = Convert.ToDecimal(iDr[SaldoEN.SalIni].ToString());
            xObjEnc.StockEnero = Convert.ToDecimal(iDr[SaldoEN.StkEne].ToString());
            xObjEnc.PromedioEnero = Convert.ToDecimal(iDr[SaldoEN.ProEne].ToString());
            xObjEnc.IngresosEnero = Convert.ToDecimal(iDr[SaldoEN.IngEne].ToString());
            xObjEnc.SalidasEnero = Convert.ToDecimal(iDr[SaldoEN.SalEne].ToString());            
            xObjEnc.StockFebrero = Convert.ToDecimal(iDr[SaldoEN.StkFeb].ToString());
            xObjEnc.PromedioFebrero = Convert.ToDecimal(iDr[SaldoEN.ProFeb].ToString());
            xObjEnc.IngresosFebrero = Convert.ToDecimal(iDr[SaldoEN.IngFeb].ToString());
            xObjEnc.SalidasFebrero = Convert.ToDecimal(iDr[SaldoEN.SalFeb].ToString());            
            xObjEnc.StockMarzo = Convert.ToDecimal(iDr[SaldoEN.StkMar].ToString());
            xObjEnc.PromedioMarzo = Convert.ToDecimal(iDr[SaldoEN.ProMar].ToString());
            xObjEnc.IngresosMarzo = Convert.ToDecimal(iDr[SaldoEN.IngMar].ToString());
            xObjEnc.SalidasMarzo = Convert.ToDecimal(iDr[SaldoEN.SalMar].ToString());            
            xObjEnc.StockAbril = Convert.ToDecimal(iDr[SaldoEN.StkAbr].ToString());
            xObjEnc.PromedioAbril = Convert.ToDecimal(iDr[SaldoEN.ProAbr].ToString());
            xObjEnc.IngresosAbril = Convert.ToDecimal(iDr[SaldoEN.IngAbr].ToString());
            xObjEnc.SalidasAbril = Convert.ToDecimal(iDr[SaldoEN.SalAbr].ToString());
            xObjEnc.StockMayo = Convert.ToDecimal(iDr[SaldoEN.StkMay].ToString());
            xObjEnc.PromedioMayo = Convert.ToDecimal(iDr[SaldoEN.ProMay].ToString());
            xObjEnc.IngresosMayo = Convert.ToDecimal(iDr[SaldoEN.IngMay].ToString());
            xObjEnc.SalidasMayo = Convert.ToDecimal(iDr[SaldoEN.SalMay].ToString());
            xObjEnc.StockJunio = Convert.ToDecimal(iDr[SaldoEN.StkJun].ToString());
            xObjEnc.PromedioJunio = Convert.ToDecimal(iDr[SaldoEN.ProJun].ToString());
            xObjEnc.IngresosJunio = Convert.ToDecimal(iDr[SaldoEN.IngJun].ToString());
            xObjEnc.SalidasJunio = Convert.ToDecimal(iDr[SaldoEN.SalJun].ToString());
            xObjEnc.StockJulio = Convert.ToDecimal(iDr[SaldoEN.StkJul].ToString());
            xObjEnc.PromedioJulio = Convert.ToDecimal(iDr[SaldoEN.ProJul].ToString());
            xObjEnc.IngresosJulio = Convert.ToDecimal(iDr[SaldoEN.IngJul].ToString());
            xObjEnc.SalidasJulio = Convert.ToDecimal(iDr[SaldoEN.SalJul].ToString());
            xObjEnc.StockAgosto = Convert.ToDecimal(iDr[SaldoEN.StkAgo].ToString());
            xObjEnc.PromedioAgosto = Convert.ToDecimal(iDr[SaldoEN.ProAgo].ToString());
            xObjEnc.IngresosAgosto = Convert.ToDecimal(iDr[SaldoEN.IngAgo].ToString());
            xObjEnc.SalidasAgosto = Convert.ToDecimal(iDr[SaldoEN.SalAgo].ToString());
            xObjEnc.StockSetiembre = Convert.ToDecimal(iDr[SaldoEN.StkSet].ToString());
            xObjEnc.PromedioSetiembre = Convert.ToDecimal(iDr[SaldoEN.ProSet].ToString());
            xObjEnc.IngresosSetiembre = Convert.ToDecimal(iDr[SaldoEN.IngSet].ToString());
            xObjEnc.SalidasSetiembre = Convert.ToDecimal(iDr[SaldoEN.SalSet].ToString());
            xObjEnc.StockOctubre = Convert.ToDecimal(iDr[SaldoEN.StkOct].ToString());
            xObjEnc.PromedioOctubre = Convert.ToDecimal(iDr[SaldoEN.ProOct].ToString());
            xObjEnc.IngresosOctubre = Convert.ToDecimal(iDr[SaldoEN.IngOct].ToString());
            xObjEnc.SalidasOctubre = Convert.ToDecimal(iDr[SaldoEN.SalOct].ToString());
            xObjEnc.StockNoviembre = Convert.ToDecimal(iDr[SaldoEN.StkNov].ToString());
            xObjEnc.PromedioNoviembre = Convert.ToDecimal(iDr[SaldoEN.ProNov].ToString());
            xObjEnc.IngresosNoviembre = Convert.ToDecimal(iDr[SaldoEN.IngNov].ToString());
            xObjEnc.SalidasNoviembre = Convert.ToDecimal(iDr[SaldoEN.SalNov].ToString());
            xObjEnc.StockDiciembre = Convert.ToDecimal(iDr[SaldoEN.StkDic].ToString());
            xObjEnc.PromedioDiciembre = Convert.ToDecimal(iDr[SaldoEN.ProDic].ToString());
            xObjEnc.IngresosDiciembre = Convert.ToDecimal(iDr[SaldoEN.IngDic].ToString());
            xObjEnc.SalidasDiciembre = Convert.ToDecimal(iDr[SaldoEN.SalDic].ToString());
            xObjEnc.CEstadoSaldo= iDr[SaldoEN.CEstSal].ToString();
            xObjEnc.NEstadoSaldo = iDr[SaldoEN.NEstSal].ToString();
            xObjEnc.UsuarioAgrega = iDr[SaldoEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[SaldoEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[SaldoEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[SaldoEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveSaldo;
            return xObjEnc;
        }

        private List<SaldoEN> ListarObjetos(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr = xObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.Objeto(xIdr));
            }
            xObjCon.Desconectar();
            return xLista;
        }

        private SaldoEN BuscarObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr = xObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObj = this.Objeto(xIdr);
            }
            xObjCon.Desconectar();
            return xObj;
        }
        
        private bool ExisteObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr = xObjCon.ObtenerIdr();
            bool xResultado = false;
            while (xIdr.Read())
            {
                string xTxt = xIdr["Busqueda"].ToString();
                if (xTxt != string.Empty)
                {
                    xResultado = true;
                }
            }
            xObjCon.Desconectar();
            return xResultado;
        }


        #endregion


        public bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }
        
        public void AdicionarSaldo(SaldoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(SaldoEN.ClaSal, pObj.ClaveSaldo);
            xIns.AsignarParametro(SaldoEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(SaldoEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(SaldoEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(SaldoEN.AñoSal, pObj.AñoSaldo);
            xIns.AsignarParametro(SaldoEN.StkIni, pObj.StockInicio.ToString());
            xIns.AsignarParametro(SaldoEN.ProIni, pObj.PromedioInicio.ToString());
            xIns.AsignarParametro(SaldoEN.IngIni, pObj.IngresosInicio.ToString());
            xIns.AsignarParametro(SaldoEN.SalIni, pObj.SalidasInicio.ToString()); 
            xIns.AsignarParametro(SaldoEN.StkEne, pObj.StockEnero.ToString());
            xIns.AsignarParametro(SaldoEN.ProEne, pObj.PromedioEnero.ToString());
            xIns.AsignarParametro(SaldoEN.IngEne, pObj.IngresosEnero.ToString());
            xIns.AsignarParametro(SaldoEN.SalEne, pObj.SalidasEnero.ToString());
            xIns.AsignarParametro(SaldoEN.StkFeb, pObj.StockFebrero.ToString());
            xIns.AsignarParametro(SaldoEN.ProFeb, pObj.PromedioFebrero.ToString());
            xIns.AsignarParametro(SaldoEN.IngFeb, pObj.IngresosFebrero.ToString());
            xIns.AsignarParametro(SaldoEN.SalFeb, pObj.SalidasFebrero.ToString());
            xIns.AsignarParametro(SaldoEN.StkMar, pObj.StockMarzo.ToString());
            xIns.AsignarParametro(SaldoEN.ProMar, pObj.PromedioMarzo.ToString());
            xIns.AsignarParametro(SaldoEN.IngMar, pObj.IngresosMarzo.ToString());
            xIns.AsignarParametro(SaldoEN.SalMar, pObj.SalidasMarzo.ToString());
            xIns.AsignarParametro(SaldoEN.StkAbr, pObj.StockAbril.ToString());
            xIns.AsignarParametro(SaldoEN.ProAbr, pObj.PromedioAbril.ToString());
            xIns.AsignarParametro(SaldoEN.IngAbr, pObj.IngresosAbril.ToString());
            xIns.AsignarParametro(SaldoEN.SalAbr, pObj.SalidasAbril.ToString());
            xIns.AsignarParametro(SaldoEN.StkMay, pObj.StockMayo.ToString());
            xIns.AsignarParametro(SaldoEN.ProMay, pObj.PromedioMayo.ToString());
            xIns.AsignarParametro(SaldoEN.IngMay, pObj.IngresosMayo.ToString());
            xIns.AsignarParametro(SaldoEN.SalMay, pObj.SalidasMayo.ToString());
            xIns.AsignarParametro(SaldoEN.StkJun, pObj.StockJunio.ToString());
            xIns.AsignarParametro(SaldoEN.ProJun, pObj.PromedioJunio.ToString());
            xIns.AsignarParametro(SaldoEN.IngJun, pObj.IngresosJunio.ToString());
            xIns.AsignarParametro(SaldoEN.SalJun, pObj.SalidasJunio.ToString());
            xIns.AsignarParametro(SaldoEN.StkJul, pObj.StockJulio.ToString());
            xIns.AsignarParametro(SaldoEN.ProJul, pObj.PromedioJulio.ToString());
            xIns.AsignarParametro(SaldoEN.IngJul, pObj.IngresosJulio.ToString());
            xIns.AsignarParametro(SaldoEN.SalJul, pObj.SalidasJulio.ToString());
            xIns.AsignarParametro(SaldoEN.StkAgo, pObj.StockAgosto.ToString());
            xIns.AsignarParametro(SaldoEN.ProAgo, pObj.PromedioAgosto.ToString());
            xIns.AsignarParametro(SaldoEN.IngAgo, pObj.IngresosAgosto.ToString());
            xIns.AsignarParametro(SaldoEN.SalAgo, pObj.SalidasAgosto.ToString());
            xIns.AsignarParametro(SaldoEN.StkSet, pObj.StockSetiembre.ToString());
            xIns.AsignarParametro(SaldoEN.ProSet, pObj.PromedioSetiembre.ToString());
            xIns.AsignarParametro(SaldoEN.IngSet, pObj.IngresosSetiembre.ToString());
            xIns.AsignarParametro(SaldoEN.SalSet, pObj.SalidasSetiembre.ToString());
            xIns.AsignarParametro(SaldoEN.StkOct, pObj.StockOctubre.ToString());
            xIns.AsignarParametro(SaldoEN.ProOct, pObj.PromedioOctubre.ToString());
            xIns.AsignarParametro(SaldoEN.IngOct, pObj.IngresosOctubre.ToString());
            xIns.AsignarParametro(SaldoEN.SalOct, pObj.SalidasOctubre.ToString());
            xIns.AsignarParametro(SaldoEN.StkNov, pObj.StockNoviembre.ToString());
            xIns.AsignarParametro(SaldoEN.ProNov, pObj.PromedioNoviembre.ToString());
            xIns.AsignarParametro(SaldoEN.IngNov, pObj.IngresosNoviembre.ToString());
            xIns.AsignarParametro(SaldoEN.SalNov, pObj.SalidasNoviembre.ToString());
            xIns.AsignarParametro(SaldoEN.StkDic, pObj.StockDiciembre.ToString());
            xIns.AsignarParametro(SaldoEN.ProDic, pObj.PromedioDiciembre.ToString());
            xIns.AsignarParametro(SaldoEN.IngDic, pObj.IngresosDiciembre.ToString());
            xIns.AsignarParametro(SaldoEN.SalDic, pObj.SalidasDiciembre.ToString());            
            xIns.AsignarParametro(SaldoEN.CEstSal, pObj.CEstadoSaldo);
            xIns.AsignarParametro(SaldoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(SaldoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(SaldoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(SaldoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarSaldo(List< SaldoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (SaldoEN xSal in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(SaldoEN.ClaSal, xSal.ClaveSaldo);
                xIns.AsignarParametro(SaldoEN.CodEmp, xSal.CodigoEmpresa);
                xIns.AsignarParametro(SaldoEN.CodAlm, xSal.CodigoAlmacen);
                xIns.AsignarParametro(SaldoEN.CodExi, xSal.CodigoExistencia);
                xIns.AsignarParametro(SaldoEN.AñoSal, xSal.AñoSaldo);
                xIns.AsignarParametro(SaldoEN.StkIni, xSal.StockInicio.ToString());
                xIns.AsignarParametro(SaldoEN.ProIni, xSal.PromedioInicio.ToString());
                xIns.AsignarParametro(SaldoEN.IngIni, xSal.IngresosInicio.ToString());
                xIns.AsignarParametro(SaldoEN.SalIni, xSal.SalidasInicio.ToString());
                xIns.AsignarParametro(SaldoEN.StkEne, xSal.StockEnero.ToString());
                xIns.AsignarParametro(SaldoEN.ProEne, xSal.PromedioEnero.ToString());
                xIns.AsignarParametro(SaldoEN.IngEne, xSal.IngresosEnero.ToString());
                xIns.AsignarParametro(SaldoEN.SalEne, xSal.SalidasEnero.ToString());
                xIns.AsignarParametro(SaldoEN.StkFeb, xSal.StockFebrero.ToString());
                xIns.AsignarParametro(SaldoEN.ProFeb, xSal.PromedioFebrero.ToString());
                xIns.AsignarParametro(SaldoEN.IngFeb, xSal.IngresosFebrero.ToString());
                xIns.AsignarParametro(SaldoEN.SalFeb, xSal.SalidasFebrero.ToString());
                xIns.AsignarParametro(SaldoEN.StkMar, xSal.StockMarzo.ToString());
                xIns.AsignarParametro(SaldoEN.ProMar, xSal.PromedioMarzo.ToString());
                xIns.AsignarParametro(SaldoEN.IngMar, xSal.IngresosMarzo.ToString());
                xIns.AsignarParametro(SaldoEN.SalMar, xSal.SalidasMarzo.ToString());
                xIns.AsignarParametro(SaldoEN.StkAbr, xSal.StockAbril.ToString());
                xIns.AsignarParametro(SaldoEN.ProAbr, xSal.PromedioAbril.ToString());
                xIns.AsignarParametro(SaldoEN.IngAbr, xSal.IngresosAbril.ToString());
                xIns.AsignarParametro(SaldoEN.SalAbr, xSal.SalidasAbril.ToString());
                xIns.AsignarParametro(SaldoEN.StkMay, xSal.StockMayo.ToString());
                xIns.AsignarParametro(SaldoEN.ProMay, xSal.PromedioMayo.ToString());
                xIns.AsignarParametro(SaldoEN.IngMay, xSal.IngresosMayo.ToString());
                xIns.AsignarParametro(SaldoEN.SalMay, xSal.SalidasMayo.ToString());
                xIns.AsignarParametro(SaldoEN.StkJun, xSal.StockJunio.ToString());
                xIns.AsignarParametro(SaldoEN.ProJun, xSal.PromedioJunio.ToString());
                xIns.AsignarParametro(SaldoEN.IngJun, xSal.IngresosJunio.ToString());
                xIns.AsignarParametro(SaldoEN.SalJun, xSal.SalidasJunio.ToString());
                xIns.AsignarParametro(SaldoEN.StkJul, xSal.StockJulio.ToString());
                xIns.AsignarParametro(SaldoEN.ProJul, xSal.PromedioJulio.ToString());
                xIns.AsignarParametro(SaldoEN.IngJul, xSal.IngresosJulio.ToString());
                xIns.AsignarParametro(SaldoEN.SalJul, xSal.SalidasJulio.ToString());
                xIns.AsignarParametro(SaldoEN.StkAgo, xSal.StockAgosto.ToString());
                xIns.AsignarParametro(SaldoEN.ProAgo, xSal.PromedioAgosto.ToString());
                xIns.AsignarParametro(SaldoEN.IngAgo, xSal.IngresosAgosto.ToString());
                xIns.AsignarParametro(SaldoEN.SalAgo, xSal.SalidasAgosto.ToString());
                xIns.AsignarParametro(SaldoEN.StkSet, xSal.StockSetiembre.ToString());
                xIns.AsignarParametro(SaldoEN.ProSet, xSal.PromedioSetiembre.ToString());
                xIns.AsignarParametro(SaldoEN.IngSet, xSal.IngresosSetiembre.ToString());
                xIns.AsignarParametro(SaldoEN.SalSet, xSal.SalidasSetiembre.ToString());
                xIns.AsignarParametro(SaldoEN.StkOct, xSal.StockOctubre.ToString());
                xIns.AsignarParametro(SaldoEN.ProOct, xSal.PromedioOctubre.ToString());
                xIns.AsignarParametro(SaldoEN.IngOct, xSal.IngresosOctubre.ToString());
                xIns.AsignarParametro(SaldoEN.SalOct, xSal.SalidasOctubre.ToString());
                xIns.AsignarParametro(SaldoEN.StkNov, xSal.StockNoviembre.ToString());
                xIns.AsignarParametro(SaldoEN.ProNov, xSal.PromedioNoviembre.ToString());
                xIns.AsignarParametro(SaldoEN.IngNov, xSal.IngresosNoviembre.ToString());
                xIns.AsignarParametro(SaldoEN.SalNov, xSal.SalidasNoviembre.ToString());
                xIns.AsignarParametro(SaldoEN.StkDic, xSal.StockDiciembre.ToString());
                xIns.AsignarParametro(SaldoEN.ProDic, xSal.PromedioDiciembre.ToString());
                xIns.AsignarParametro(SaldoEN.IngDic, xSal.IngresosDiciembre.ToString());
                xIns.AsignarParametro(SaldoEN.SalDic, xSal.SalidasDiciembre.ToString());
                xIns.AsignarParametro(SaldoEN.CEstSal, xSal.CEstadoSaldo);
                xIns.AsignarParametro(SaldoEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SaldoEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(SaldoEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SaldoEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarSaldo(SaldoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(SaldoEN.StkIni, pObj.StockInicio.ToString());
            xUpd.AsignarParametro(SaldoEN.ProIni, pObj.PromedioInicio.ToString());
            xUpd.AsignarParametro(SaldoEN.IngIni, pObj.IngresosInicio.ToString());
            xUpd.AsignarParametro(SaldoEN.SalIni, pObj.SalidasInicio.ToString());
            xUpd.AsignarParametro(SaldoEN.StkEne, pObj.StockEnero.ToString());
            xUpd.AsignarParametro(SaldoEN.ProEne, pObj.PromedioEnero.ToString());
            xUpd.AsignarParametro(SaldoEN.IngEne, pObj.IngresosEnero.ToString());
            xUpd.AsignarParametro(SaldoEN.SalEne, pObj.SalidasEnero.ToString());
            xUpd.AsignarParametro(SaldoEN.StkFeb, pObj.StockFebrero.ToString());
            xUpd.AsignarParametro(SaldoEN.ProFeb, pObj.PromedioFebrero.ToString());
            xUpd.AsignarParametro(SaldoEN.IngFeb, pObj.IngresosFebrero.ToString());
            xUpd.AsignarParametro(SaldoEN.SalFeb, pObj.SalidasFebrero.ToString());
            xUpd.AsignarParametro(SaldoEN.StkMar, pObj.StockMarzo.ToString());
            xUpd.AsignarParametro(SaldoEN.ProMar, pObj.PromedioMarzo.ToString());
            xUpd.AsignarParametro(SaldoEN.IngMar, pObj.IngresosMarzo.ToString());
            xUpd.AsignarParametro(SaldoEN.SalMar, pObj.SalidasMarzo.ToString());
            xUpd.AsignarParametro(SaldoEN.StkAbr, pObj.StockAbril.ToString());
            xUpd.AsignarParametro(SaldoEN.ProAbr, pObj.PromedioAbril.ToString());
            xUpd.AsignarParametro(SaldoEN.IngAbr, pObj.IngresosAbril.ToString());
            xUpd.AsignarParametro(SaldoEN.SalAbr, pObj.SalidasAbril.ToString());
            xUpd.AsignarParametro(SaldoEN.StkMay, pObj.StockMayo.ToString());
            xUpd.AsignarParametro(SaldoEN.ProMay, pObj.PromedioMayo.ToString());
            xUpd.AsignarParametro(SaldoEN.IngMay, pObj.IngresosMayo.ToString());
            xUpd.AsignarParametro(SaldoEN.SalMay, pObj.SalidasMayo.ToString());
            xUpd.AsignarParametro(SaldoEN.StkJun, pObj.StockJunio.ToString());
            xUpd.AsignarParametro(SaldoEN.ProJun, pObj.PromedioJunio.ToString());
            xUpd.AsignarParametro(SaldoEN.IngJun, pObj.IngresosJunio.ToString());
            xUpd.AsignarParametro(SaldoEN.SalJun, pObj.SalidasJunio.ToString());                        
            xUpd.AsignarParametro(SaldoEN.StkJul, pObj.StockJulio.ToString());
            xUpd.AsignarParametro(SaldoEN.ProJul, pObj.PromedioJulio.ToString());
            xUpd.AsignarParametro(SaldoEN.IngJul, pObj.IngresosJulio.ToString());
            xUpd.AsignarParametro(SaldoEN.SalJul, pObj.SalidasJulio.ToString());
            xUpd.AsignarParametro(SaldoEN.StkAgo, pObj.StockAgosto.ToString());
            xUpd.AsignarParametro(SaldoEN.ProAgo, pObj.PromedioAgosto.ToString());
            xUpd.AsignarParametro(SaldoEN.IngAgo, pObj.IngresosAgosto.ToString());
            xUpd.AsignarParametro(SaldoEN.SalAgo, pObj.SalidasAgosto.ToString());
            xUpd.AsignarParametro(SaldoEN.StkSet, pObj.StockSetiembre.ToString());
            xUpd.AsignarParametro(SaldoEN.ProSet, pObj.PromedioSetiembre.ToString());
            xUpd.AsignarParametro(SaldoEN.IngSet, pObj.IngresosSetiembre.ToString());
            xUpd.AsignarParametro(SaldoEN.SalSet, pObj.SalidasSetiembre.ToString());
            xUpd.AsignarParametro(SaldoEN.StkOct, pObj.StockOctubre.ToString());
            xUpd.AsignarParametro(SaldoEN.ProOct, pObj.PromedioOctubre.ToString());
            xUpd.AsignarParametro(SaldoEN.IngOct, pObj.IngresosOctubre.ToString());
            xUpd.AsignarParametro(SaldoEN.SalOct, pObj.SalidasOctubre.ToString());
            xUpd.AsignarParametro(SaldoEN.StkNov, pObj.StockNoviembre.ToString());
            xUpd.AsignarParametro(SaldoEN.ProNov, pObj.PromedioNoviembre.ToString());
            xUpd.AsignarParametro(SaldoEN.IngNov, pObj.IngresosNoviembre.ToString());
            xUpd.AsignarParametro(SaldoEN.SalNov, pObj.SalidasNoviembre.ToString());
            xUpd.AsignarParametro(SaldoEN.StkDic, pObj.StockDiciembre.ToString());
            xUpd.AsignarParametro(SaldoEN.ProDic, pObj.PromedioDiciembre.ToString());
            xUpd.AsignarParametro(SaldoEN.IngDic, pObj.IngresosDiciembre.ToString());
            xUpd.AsignarParametro(SaldoEN.SalDic, pObj.SalidasDiciembre.ToString());
            xUpd.AsignarParametro(SaldoEN.CEstSal, pObj.CEstadoSaldo);
            xUpd.AsignarParametro(SaldoEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(SaldoEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.ClaSal, SqlSelect.Operador.Igual, pObj.ClaveSaldo);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar comando
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarSaldo(List< SaldoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
         
            //recorrer cada objeto
            foreach (SaldoEN xSal in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(SaldoEN.StkIni, xSal.StockInicio.ToString());
                xUpd.AsignarParametro(SaldoEN.ProIni, xSal.PromedioInicio.ToString());
                xUpd.AsignarParametro(SaldoEN.IngIni, xSal.IngresosInicio.ToString());
                xUpd.AsignarParametro(SaldoEN.SalIni, xSal.SalidasInicio.ToString());
                xUpd.AsignarParametro(SaldoEN.StkEne, xSal.StockEnero.ToString());
                xUpd.AsignarParametro(SaldoEN.ProEne, xSal.PromedioEnero.ToString());
                xUpd.AsignarParametro(SaldoEN.IngEne, xSal.IngresosEnero.ToString());
                xUpd.AsignarParametro(SaldoEN.SalEne, xSal.SalidasEnero.ToString());
                xUpd.AsignarParametro(SaldoEN.StkFeb, xSal.StockFebrero.ToString());
                xUpd.AsignarParametro(SaldoEN.ProFeb, xSal.PromedioFebrero.ToString());
                xUpd.AsignarParametro(SaldoEN.IngFeb, xSal.IngresosFebrero.ToString());
                xUpd.AsignarParametro(SaldoEN.SalFeb, xSal.SalidasFebrero.ToString());
                xUpd.AsignarParametro(SaldoEN.StkMar, xSal.StockMarzo.ToString());
                xUpd.AsignarParametro(SaldoEN.ProMar, xSal.PromedioMarzo.ToString());
                xUpd.AsignarParametro(SaldoEN.IngMar, xSal.IngresosMarzo.ToString());
                xUpd.AsignarParametro(SaldoEN.SalMar, xSal.SalidasMarzo.ToString());
                xUpd.AsignarParametro(SaldoEN.StkAbr, xSal.StockAbril.ToString());
                xUpd.AsignarParametro(SaldoEN.ProAbr, xSal.PromedioAbril.ToString());
                xUpd.AsignarParametro(SaldoEN.IngAbr, xSal.IngresosAbril.ToString());
                xUpd.AsignarParametro(SaldoEN.SalAbr, xSal.SalidasAbril.ToString());
                xUpd.AsignarParametro(SaldoEN.StkMay, xSal.StockMayo.ToString());
                xUpd.AsignarParametro(SaldoEN.ProMay, xSal.PromedioMayo.ToString());
                xUpd.AsignarParametro(SaldoEN.IngMay, xSal.IngresosMayo.ToString());
                xUpd.AsignarParametro(SaldoEN.SalMay, xSal.SalidasMayo.ToString());
                xUpd.AsignarParametro(SaldoEN.StkJun, xSal.StockJunio.ToString());
                xUpd.AsignarParametro(SaldoEN.ProJun, xSal.PromedioJunio.ToString());
                xUpd.AsignarParametro(SaldoEN.IngJun, xSal.IngresosJunio.ToString());
                xUpd.AsignarParametro(SaldoEN.SalJun, xSal.SalidasJunio.ToString());
                xUpd.AsignarParametro(SaldoEN.StkJul, xSal.StockJulio.ToString());
                xUpd.AsignarParametro(SaldoEN.ProJul, xSal.PromedioJulio.ToString());
                xUpd.AsignarParametro(SaldoEN.IngJul, xSal.IngresosJulio.ToString());
                xUpd.AsignarParametro(SaldoEN.SalJul, xSal.SalidasJulio.ToString());
                xUpd.AsignarParametro(SaldoEN.StkAgo, xSal.StockAgosto.ToString());
                xUpd.AsignarParametro(SaldoEN.ProAgo, xSal.PromedioAgosto.ToString());
                xUpd.AsignarParametro(SaldoEN.IngAgo, xSal.IngresosAgosto.ToString());
                xUpd.AsignarParametro(SaldoEN.SalAgo, xSal.SalidasAgosto.ToString());
                xUpd.AsignarParametro(SaldoEN.StkSet, xSal.StockSetiembre.ToString());
                xUpd.AsignarParametro(SaldoEN.ProSet, xSal.PromedioSetiembre.ToString());
                xUpd.AsignarParametro(SaldoEN.IngSet, xSal.IngresosSetiembre.ToString());
                xUpd.AsignarParametro(SaldoEN.SalSet, xSal.SalidasSetiembre.ToString());
                xUpd.AsignarParametro(SaldoEN.StkOct, xSal.StockOctubre.ToString());
                xUpd.AsignarParametro(SaldoEN.ProOct, xSal.PromedioOctubre.ToString());
                xUpd.AsignarParametro(SaldoEN.IngOct, xSal.IngresosOctubre.ToString());
                xUpd.AsignarParametro(SaldoEN.SalOct, xSal.SalidasOctubre.ToString());
                xUpd.AsignarParametro(SaldoEN.StkNov, xSal.StockNoviembre.ToString());
                xUpd.AsignarParametro(SaldoEN.ProNov, xSal.PromedioNoviembre.ToString());
                xUpd.AsignarParametro(SaldoEN.IngNov, xSal.IngresosNoviembre.ToString());
                xUpd.AsignarParametro(SaldoEN.SalNov, xSal.SalidasNoviembre.ToString());
                xUpd.AsignarParametro(SaldoEN.StkDic, xSal.StockDiciembre.ToString());
                xUpd.AsignarParametro(SaldoEN.ProDic, xSal.PromedioDiciembre.ToString());
                xUpd.AsignarParametro(SaldoEN.IngDic, xSal.IngresosDiciembre.ToString());
                xUpd.AsignarParametro(SaldoEN.SalDic, xSal.SalidasDiciembre.ToString());
                xUpd.AsignarParametro(SaldoEN.CEstSal, xSal.CEstadoSaldo);
                xUpd.AsignarParametro(SaldoEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(SaldoEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.ClaSal, SqlSelect.Operador.Igual, xSal.ClaveSaldo);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar comando
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
          
            xObjCon.Desconectar();
        }

        public void ModificarSaldoParaRecalculo(List<SaldoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.IniciaTransaccion();

            //recorrer cada objeto
            foreach (SaldoEN xSal in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(SaldoEN.StkIni, xSal.StockInicio.ToString());
                xUpd.AsignarParametro(SaldoEN.ProIni, xSal.PromedioInicio.ToString());
                xUpd.AsignarParametro(SaldoEN.IngIni, xSal.IngresosInicio.ToString());
                xUpd.AsignarParametro(SaldoEN.SalIni, xSal.SalidasInicio.ToString());
                xUpd.AsignarParametro(SaldoEN.StkEne, xSal.StockEnero.ToString());
                xUpd.AsignarParametro(SaldoEN.ProEne, xSal.PromedioEnero.ToString());
                xUpd.AsignarParametro(SaldoEN.IngEne, xSal.IngresosEnero.ToString());
                xUpd.AsignarParametro(SaldoEN.SalEne, xSal.SalidasEnero.ToString());
                xUpd.AsignarParametro(SaldoEN.StkFeb, xSal.StockFebrero.ToString());
                xUpd.AsignarParametro(SaldoEN.ProFeb, xSal.PromedioFebrero.ToString());
                xUpd.AsignarParametro(SaldoEN.IngFeb, xSal.IngresosFebrero.ToString());
                xUpd.AsignarParametro(SaldoEN.SalFeb, xSal.SalidasFebrero.ToString());
                xUpd.AsignarParametro(SaldoEN.StkMar, xSal.StockMarzo.ToString());
                xUpd.AsignarParametro(SaldoEN.ProMar, xSal.PromedioMarzo.ToString());
                xUpd.AsignarParametro(SaldoEN.IngMar, xSal.IngresosMarzo.ToString());
                xUpd.AsignarParametro(SaldoEN.SalMar, xSal.SalidasMarzo.ToString());
                xUpd.AsignarParametro(SaldoEN.StkAbr, xSal.StockAbril.ToString());
                xUpd.AsignarParametro(SaldoEN.ProAbr, xSal.PromedioAbril.ToString());
                xUpd.AsignarParametro(SaldoEN.IngAbr, xSal.IngresosAbril.ToString());
                xUpd.AsignarParametro(SaldoEN.SalAbr, xSal.SalidasAbril.ToString());
                xUpd.AsignarParametro(SaldoEN.StkMay, xSal.StockMayo.ToString());
                xUpd.AsignarParametro(SaldoEN.ProMay, xSal.PromedioMayo.ToString());
                xUpd.AsignarParametro(SaldoEN.IngMay, xSal.IngresosMayo.ToString());
                xUpd.AsignarParametro(SaldoEN.SalMay, xSal.SalidasMayo.ToString());
                xUpd.AsignarParametro(SaldoEN.StkJun, xSal.StockJunio.ToString());
                xUpd.AsignarParametro(SaldoEN.ProJun, xSal.PromedioJunio.ToString());
                xUpd.AsignarParametro(SaldoEN.IngJun, xSal.IngresosJunio.ToString());
                xUpd.AsignarParametro(SaldoEN.SalJun, xSal.SalidasJunio.ToString());
                xUpd.AsignarParametro(SaldoEN.StkJul, xSal.StockJulio.ToString());
                xUpd.AsignarParametro(SaldoEN.ProJul, xSal.PromedioJulio.ToString());
                xUpd.AsignarParametro(SaldoEN.IngJul, xSal.IngresosJulio.ToString());
                xUpd.AsignarParametro(SaldoEN.SalJul, xSal.SalidasJulio.ToString());
                xUpd.AsignarParametro(SaldoEN.StkAgo, xSal.StockAgosto.ToString());
                xUpd.AsignarParametro(SaldoEN.ProAgo, xSal.PromedioAgosto.ToString());
                xUpd.AsignarParametro(SaldoEN.IngAgo, xSal.IngresosAgosto.ToString());
                xUpd.AsignarParametro(SaldoEN.SalAgo, xSal.SalidasAgosto.ToString());
                xUpd.AsignarParametro(SaldoEN.StkSet, xSal.StockSetiembre.ToString());
                xUpd.AsignarParametro(SaldoEN.ProSet, xSal.PromedioSetiembre.ToString());
                xUpd.AsignarParametro(SaldoEN.IngSet, xSal.IngresosSetiembre.ToString());
                xUpd.AsignarParametro(SaldoEN.SalSet, xSal.SalidasSetiembre.ToString());
                xUpd.AsignarParametro(SaldoEN.StkOct, xSal.StockOctubre.ToString());
                xUpd.AsignarParametro(SaldoEN.ProOct, xSal.PromedioOctubre.ToString());
                xUpd.AsignarParametro(SaldoEN.IngOct, xSal.IngresosOctubre.ToString());
                xUpd.AsignarParametro(SaldoEN.SalOct, xSal.SalidasOctubre.ToString());
                xUpd.AsignarParametro(SaldoEN.StkNov, xSal.StockNoviembre.ToString());
                xUpd.AsignarParametro(SaldoEN.ProNov, xSal.PromedioNoviembre.ToString());
                xUpd.AsignarParametro(SaldoEN.IngNov, xSal.IngresosNoviembre.ToString());
                xUpd.AsignarParametro(SaldoEN.SalNov, xSal.SalidasNoviembre.ToString());
                xUpd.AsignarParametro(SaldoEN.StkDic, xSal.StockDiciembre.ToString());
                xUpd.AsignarParametro(SaldoEN.ProDic, xSal.PromedioDiciembre.ToString());
                xUpd.AsignarParametro(SaldoEN.IngDic, xSal.IngresosDiciembre.ToString());
                xUpd.AsignarParametro(SaldoEN.SalDic, xSal.SalidasDiciembre.ToString());
                xUpd.AsignarParametro(SaldoEN.CEstSal, xSal.CEstadoSaldo);
                xUpd.AsignarParametro(SaldoEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(SaldoEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.ClaSal, SqlSelect.Operador.Igual, xSal.ClaveSaldo);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar comando
                xObjCon.ComandoTextoTransaccion(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            xObjCon.CerrarTransaccion();
            xObjCon.Desconectar();
        }

        public void EliminarSaldo(SaldoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.ClaSal, SqlSelect.Operador.Igual, pObj.ClaveSaldo);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSaldo(List< SaldoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (SaldoEN xSal in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.ClaSal, SqlSelect.Operador.Igual, xSal.ClaveSaldo);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void EliminarSaldosPorAño(string pAñoSaldo)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, SaldoEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.AñoSal, SqlSelect.Operador.Igual, pAñoSaldo);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSaldosDeExistencia(ExistenciaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<SaldoEN> ListarSaldo(SaldoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public SaldoEN BuscarSaldoXClave(SaldoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.ClaSal, SqlSelect.Operador.Igual, pObj.ClaveSaldo);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<SaldoEN> ListarSaldosDeAño(SaldoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, SaldoEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.AñoSal, SqlSelect.Operador.Igual, pObj.AñoSaldo);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SaldoEN> ListarSaldosParaKardex(SaldoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.AñoSal, SqlSelect.Operador.Igual, pObj.AñoSaldo);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            if (pObj.CodigoTipo != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.CodTip, SqlSelect.Operador.Igual, pObj.CodigoTipo);
            }
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, SaldoEN.CodExi, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SaldoEN> ListarSaldosDeAñoYExistencia(SaldoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.AñoSal, SqlSelect.Operador.Igual, pObj.AñoSaldo);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SaldoEN> ListarSaldosParaResumenTipoExistencia(SaldoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SaldoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.AñoSal, SqlSelect.Operador.Igual, pObj.AñoSaldo);           
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, SaldoEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.CodigoTipo != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, SaldoEN.CodTip, SqlSelect.Operador.Igual, pObj.CodigoTipo);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

    }
}
