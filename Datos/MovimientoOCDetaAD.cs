using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Datos.Config;
using Comun;

namespace Datos
{

    public class MovimientoOCDetaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<MovimientoOCDetaEN> xLista = new List<MovimientoOCDetaEN>();
        private MovimientoOCDetaEN xObj = new MovimientoOCDetaEN();
        private string xTabla = "MovimientoOCDeta";
        private string xVista = "VsMovimientoOCDeta";

        #endregion

        #region Metodos privados

        private MovimientoOCDetaEN Objeto(IDataReader iDr)
        {
            MovimientoOCDetaEN xObjEnc = new MovimientoOCDetaEN();
            xObjEnc.ClaveMovimientoDeta = iDr[MovimientoOCDetaEN.ClaMovDet].ToString();
            xObjEnc.ClaveMovimientoCabe = iDr[MovimientoOCDetaEN.ClaMovCab].ToString();
            xObjEnc.CorrelativoMovimientoDeta = iDr[MovimientoOCDetaEN.CorMovDet].ToString();
            xObjEnc.CodigoEmpresa = iDr[MovimientoOCDetaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[MovimientoOCDetaEN.NomEmp].ToString();
            xObjEnc.FechaMovimientoCabe = Fecha.ObtenerDiaMesAno(iDr[MovimientoOCDetaEN.FecMovCab].ToString());
            xObjEnc.PeriodoMovimientoCabe = iDr[MovimientoOCDetaEN.PerMovCab].ToString();
            xObjEnc.CodigoAlmacen = iDr[MovimientoOCDetaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[MovimientoOCDetaEN.DesAlm].ToString();
            xObjEnc.CodigoTipoOperacion = iDr[MovimientoOCDetaEN.CodTipOpe].ToString();
            xObjEnc.DescripcionTipoOperacion = iDr[MovimientoOCDetaEN.DesTipOpe].ToString();
            xObjEnc.CClaseTipoOperacion = iDr[MovimientoOCDetaEN.CClaTipOpe].ToString();
            xObjEnc.CCalculaPrecioPromedio = iDr[MovimientoOCDetaEN.CCalPrePro].ToString();
            xObjEnc.CConversionUnidad = iDr[MovimientoOCDetaEN.CConUni].ToString();
            xObjEnc.NumeroMovimientoCabe = iDr[MovimientoOCDetaEN.NumMovCab].ToString();
            xObjEnc.CodigoAuxiliar = iDr[MovimientoOCDetaEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[MovimientoOCDetaEN.DesAux].ToString();
            xObjEnc.CTipoDocumento = iDr[MovimientoOCDetaEN.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[MovimientoOCDetaEN.NTipDoc].ToString();
            xObjEnc.SerieDocumento = iDr[MovimientoOCDetaEN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[MovimientoOCDetaEN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[MovimientoOCDetaEN.FecDoc].ToString());
            xObjEnc.CCodigoMoneda = iDr[MovimientoOCDetaEN.CCodMon].ToString();
            xObjEnc.NCodigoMoneda = iDr[MovimientoOCDetaEN.NCodMon].ToString();
            xObjEnc.CodigoCentroCosto = iDr[MovimientoOCDetaEN.CodCenCos].ToString();
            xObjEnc.DescripcionCentroCosto = iDr[MovimientoOCDetaEN.DesCenCos].ToString();
            xObjEnc.CodigoExistencia = iDr[MovimientoOCDetaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[MovimientoOCDetaEN.DesExi].ToString();
            xObjEnc.ContableExistencia = iDr[MovimientoOCDetaEN.ConExi].ToString();
            xObjEnc.CodigoTipo = iDr[MovimientoOCDetaEN.CodTip].ToString();
            xObjEnc.NombreTipo = iDr[MovimientoOCDetaEN.NomTip].ToString();
            xObjEnc.CEsLote = iDr[MovimientoOCDetaEN.CEsLot].ToString();
            xObjEnc.CEsUnidadConvertida = iDr[MovimientoOCDetaEN.CEsUniCon].ToString();
            xObjEnc.FactorConversion = Convert.ToDecimal(iDr[MovimientoOCDetaEN.FacCon].ToString());
            xObjEnc.CodigoUnidadMedida = iDr[MovimientoOCDetaEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[MovimientoOCDetaEN.NomUniMed].ToString();
            xObjEnc.CantidadMovimientoDeta = Convert.ToDecimal(iDr[MovimientoOCDetaEN.CanMovDet].ToString());
            xObjEnc.PrecioUnitarioMovimientoDeta = Convert.ToDecimal(iDr[MovimientoOCDetaEN.PreUniMovDet].ToString());
            xObjEnc.PrecioUnitarioDolarMovimientoDeta = Convert.ToDecimal(iDr[MovimientoOCDetaEN.PreUniDolMovDet].ToString());
            xObjEnc.TipoCambio = Convert.ToDecimal(iDr[MovimientoOCDetaEN.TipCam].ToString());
            xObjEnc.CostoMovimientoDeta = Convert.ToDecimal(iDr[MovimientoOCDetaEN.CosMovDet].ToString());
            xObjEnc.GlosaMovimientoDeta = iDr[MovimientoOCDetaEN.GloMovDet].ToString();
            xObjEnc.StockAnteriorExistencia = Convert.ToDecimal(iDr[MovimientoOCDetaEN.StoAntExi].ToString());
            xObjEnc.PrecioAnteriorExistencia = Convert.ToDecimal(iDr[MovimientoOCDetaEN.PreAntExi].ToString());
            xObjEnc.StockExistencia = Convert.ToDecimal(iDr[MovimientoOCDetaEN.StoExi].ToString());
            xObjEnc.PrecioExistencia = Convert.ToDecimal(iDr[MovimientoOCDetaEN.PreExi].ToString());
            xObjEnc.ClaveProduccionDeta = iDr[MovimientoOCDetaEN.ClaProDet].ToString();
            xObjEnc.CTipoDescarga = iDr[MovimientoOCDetaEN.CTipDes].ToString();
            xObjEnc.PrecioUnitarioProduccion = Convert.ToDecimal(iDr[MovimientoOCDetaEN.PreUniPro].ToString());
            xObjEnc.PrecioUnitarioConversion = Convert.ToDecimal(iDr[MovimientoOCDetaEN.PreUniCon].ToString());
            xObjEnc.CantidadConversion = Convert.ToDecimal(iDr[MovimientoOCDetaEN.CanCon].ToString());
            xObjEnc.CostoFleteMovimientoDeta = Convert.ToDecimal(iDr[MovimientoOCDetaEN.CosFleMovDet].ToString());
            xObjEnc.CostoFleteMovimientoCabe = Convert.ToDecimal(iDr[MovimientoOCDetaEN.CosFleMovCab].ToString());
            xObjEnc.ClaveEncajado = iDr[MovimientoOCDetaEN.ClaEnc].ToString();
            xObjEnc.ClaveProduccionProTer = iDr[MovimientoOCDetaEN.ClaProProTer].ToString();
            xObjEnc.ClaveProduccionProTerParteEmpaquetado = iDr[MovimientoOCDetaEN.ClaProTerParEmp].ToString();
            xObjEnc.CCodigoArea = iDr[MovimientoOCDetaEN.CCodAre].ToString();
            xObjEnc.NCodigoArea = iDr[MovimientoOCDetaEN.NCodAre].ToString();
            xObjEnc.CCodigoPartida = iDr[MovimientoOCDetaEN.CCodPar].ToString();
            xObjEnc.NCodigoPartida = iDr[MovimientoOCDetaEN.NCodPar].ToString();
            xObjEnc.CEstadoMovimientoDeta = iDr[MovimientoOCDetaEN.CEstMovDet].ToString();
            xObjEnc.NEstadoMovimientoDeta = iDr[MovimientoOCDetaEN.NEstMovDet].ToString();
            xObjEnc.UsuarioAgrega = iDr[MovimientoOCDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[MovimientoOCDetaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[MovimientoOCDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[MovimientoOCDetaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveMovimientoDeta;
            xObjEnc.CantidadRecibida = Convert.ToDecimal(iDr[MovimientoOCDetaEN.CanRec].ToString());
            xObjEnc.CantidadPendiente = Convert.ToDecimal(iDr[MovimientoOCDetaEN.CanPen].ToString());
            xObjEnc.CantidadRecibidaVarios = iDr[MovimientoOCDetaEN.CanRecVar].ToString();
            xObjEnc.ClaveMovimientoICabe = iDr[MovimientoOCDetaEN.ClaMovICab].ToString();
            return xObjEnc;
        }

        private List<MovimientoOCDetaEN> ListarObjetos(string pScript)
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

        private MovimientoOCDetaEN BuscarObjeto(string pScript)
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

        #region Metodos publicos

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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(MovimientoOCDetaEN.ClaMovDet, pObj.ClaveMovimientoDeta);
            xIns.AsignarParametro(MovimientoOCDetaEN.ClaMovCab, pObj.ClaveMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCDetaEN.CorMovDet, pObj.CorrelativoMovimientoDeta);
            xIns.AsignarParametro(MovimientoOCDetaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(MovimientoOCDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaMovimientoCabe));
            xIns.AsignarParametro(MovimientoOCDetaEN.PerMovCab, pObj.PeriodoMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCDetaEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(MovimientoOCDetaEN.CodTipOpe, pObj.CodigoTipoOperacion);
            xIns.AsignarParametro(MovimientoOCDetaEN.NumMovCab, pObj.NumeroMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCDetaEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(MovimientoOCDetaEN.CTipDoc, pObj.CTipoDocumento);
            xIns.AsignarParametro(MovimientoOCDetaEN.SerDoc, pObj.SerieDocumento);
            xIns.AsignarParametro(MovimientoOCDetaEN.NumDoc, pObj.NumeroDocumento);
            xIns.AsignarParametro(MovimientoOCDetaEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xIns.AsignarParametro(MovimientoOCDetaEN.CCodMon, pObj.CCodigoMoneda);
            xIns.AsignarParametro(MovimientoOCDetaEN.CodCenCos, pObj.CodigoCentroCosto);
            xIns.AsignarParametro(MovimientoOCDetaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(MovimientoOCDetaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xIns.AsignarParametro(MovimientoOCDetaEN.CanMovDet, pObj.CantidadMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.PreUniMovDet, pObj.PrecioUnitarioMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.PreUniDolMovDet, pObj.PrecioUnitarioDolarMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.TipCam, pObj.TipoCambio.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.CosMovDet, pObj.CostoMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.GloMovDet, pObj.GlosaMovimientoDeta);
            xIns.AsignarParametro(MovimientoOCDetaEN.StoAntExi, pObj.StockAnteriorExistencia.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.PreAntExi, pObj.PrecioAnteriorExistencia.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.StoExi, pObj.StockExistencia.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.PreExi, pObj.PrecioExistencia.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(MovimientoOCDetaEN.CTipDes, pObj.CTipoDescarga);
            xIns.AsignarParametro(MovimientoOCDetaEN.PreUniPro, pObj.PrecioUnitarioProduccion.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.PreUniCon, pObj.PrecioUnitarioConversion.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.CanCon, pObj.CantidadConversion.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.CosFleMovDet, pObj.CostoFleteMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.CosFleMovCab, pObj.CostoFleteMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.ClaEnc, pObj.ClaveEncajado);
            xIns.AsignarParametro(MovimientoOCDetaEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xIns.AsignarParametro(MovimientoOCDetaEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xIns.AsignarParametro(MovimientoOCDetaEN.CCodAre, pObj.CCodigoArea);
            xIns.AsignarParametro(MovimientoOCDetaEN.CCodPar, pObj.CCodigoPartida);
            xIns.AsignarParametro(MovimientoOCDetaEN.CEstMovDet, pObj.CEstadoMovimientoDeta);
            xIns.AsignarParametro(MovimientoOCDetaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(MovimientoOCDetaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(MovimientoOCDetaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(MovimientoOCDetaEN.FecMod, "FECHAHORA");
            xIns.AsignarParametro(MovimientoOCDetaEN.CanRec, pObj.CantidadRecibida.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.CanPen, pObj.CantidadPendiente.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.CanRecVar, pObj.CantidadRecibidaVarios.ToString());
            xIns.AsignarParametro(MovimientoOCDetaEN.ClaMovICab, pObj.ClaveMovimientoICabe.ToString());
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarMovimientoDeta(List<MovimientoOCDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(MovimientoOCDetaEN.ClaMovDet, xMovDet.ClaveMovimientoDeta);
                xIns.AsignarParametro(MovimientoOCDetaEN.ClaMovCab, xMovDet.ClaveMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCDetaEN.CorMovDet, xMovDet.CorrelativoMovimientoDeta);
                xIns.AsignarParametro(MovimientoOCDetaEN.CodEmp, xMovDet.CodigoEmpresa);
                xIns.AsignarParametro(MovimientoOCDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovDet.FechaMovimientoCabe));
                xIns.AsignarParametro(MovimientoOCDetaEN.PerMovCab, xMovDet.PeriodoMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCDetaEN.CodAlm, xMovDet.CodigoAlmacen);
                xIns.AsignarParametro(MovimientoOCDetaEN.CodTipOpe, xMovDet.CodigoTipoOperacion);
                xIns.AsignarParametro(MovimientoOCDetaEN.NumMovCab, xMovDet.NumeroMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCDetaEN.CodAux, xMovDet.CodigoAuxiliar);
                xIns.AsignarParametro(MovimientoOCDetaEN.CTipDoc, xMovDet.CTipoDocumento);
                xIns.AsignarParametro(MovimientoOCDetaEN.SerDoc, xMovDet.SerieDocumento);
                xIns.AsignarParametro(MovimientoOCDetaEN.NumDoc, xMovDet.NumeroDocumento);
                xIns.AsignarParametro(MovimientoOCDetaEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovDet.FechaDocumento));
                xIns.AsignarParametro(MovimientoOCDetaEN.CCodMon, xMovDet.CCodigoMoneda);
                xIns.AsignarParametro(MovimientoOCDetaEN.CodCenCos, xMovDet.CodigoCentroCosto);
                xIns.AsignarParametro(MovimientoOCDetaEN.CodExi, xMovDet.CodigoExistencia);
                xIns.AsignarParametro(MovimientoOCDetaEN.CodUniMed, xMovDet.CodigoUnidadMedida);
                xIns.AsignarParametro(MovimientoOCDetaEN.CanMovDet, xMovDet.CantidadMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.PreUniMovDet, xMovDet.PrecioUnitarioMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.PreUniDolMovDet, xMovDet.PrecioUnitarioDolarMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.TipCam, xMovDet.TipoCambio.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.CosMovDet, xMovDet.CostoMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.GloMovDet, xMovDet.GlosaMovimientoDeta);
                xIns.AsignarParametro(MovimientoOCDetaEN.StoAntExi, xMovDet.StockAnteriorExistencia.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.PreAntExi, xMovDet.PrecioAnteriorExistencia.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.StoExi, xMovDet.StockExistencia.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.PreExi, xMovDet.PrecioExistencia.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.ClaProDet, xMovDet.ClaveProduccionDeta);
                xIns.AsignarParametro(MovimientoOCDetaEN.CTipDes, xMovDet.CTipoDescarga);
                xIns.AsignarParametro(MovimientoOCDetaEN.PreUniPro, xMovDet.PrecioUnitarioProduccion.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.PreUniCon, xMovDet.PrecioUnitarioConversion.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.CanCon, xMovDet.CantidadConversion.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.CosFleMovDet, xMovDet.CostoFleteMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.CosFleMovCab, xMovDet.CostoFleteMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.ClaEnc, xMovDet.ClaveEncajado);
                xIns.AsignarParametro(MovimientoOCDetaEN.ClaProProTer, xMovDet.ClaveProduccionProTer);
                xIns.AsignarParametro(MovimientoOCDetaEN.ClaProTerParEmp, xMovDet.ClaveProduccionProTerParteEmpaquetado);
                xIns.AsignarParametro(MovimientoOCDetaEN.CCodAre, xMovDet.CCodigoArea);
                xIns.AsignarParametro(MovimientoOCDetaEN.CCodPar, xMovDet.CCodigoPartida);
                xIns.AsignarParametro(MovimientoOCDetaEN.CEstMovDet, xMovDet.CEstadoMovimientoDeta);
                xIns.AsignarParametro(MovimientoOCDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(MovimientoOCDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(MovimientoOCDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(MovimientoOCDetaEN.FecMod, "FECHAHORA");
                xIns.AsignarParametro(MovimientoOCDetaEN.CanRec, xMovDet.CantidadRecibida.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.CanPen, xMovDet.CantidadPendiente.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.CanRecVar, xMovDet.CantidadRecibidaVarios.ToString());
                xIns.AsignarParametro(MovimientoOCDetaEN.ClaMovICab, xMovDet.ClaveMovimientoICabe.ToString());
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CCodMon, pObj.CCodigoMoneda);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CodCenCos, pObj.CodigoCentroCosto);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CodExi, pObj.CodigoExistencia);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CanMovDet, pObj.CantidadMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniMovDet, pObj.PrecioUnitarioMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniDolMovDet, pObj.PrecioUnitarioDolarMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.TipCam, pObj.TipoCambio.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.CosMovDet, pObj.CostoMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.GloMovDet, pObj.GlosaMovimientoDeta);
            xUpd.AsignarParametro(MovimientoOCDetaEN.StoAntExi, pObj.StockAnteriorExistencia.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.PreAntExi, pObj.PrecioAnteriorExistencia.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.StoExi, pObj.StockExistencia.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.PreExi, pObj.PrecioExistencia.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.ClaProDet, pObj.ClaveProduccionDeta);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CTipDes, pObj.CTipoDescarga);
            xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniPro, pObj.PrecioUnitarioProduccion.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniCon, pObj.PrecioUnitarioConversion.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.CanCon, pObj.CantidadConversion.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.CosFleMovDet, pObj.CostoFleteMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.CosFleMovCab, pObj.CostoFleteMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.ClaEnc, pObj.ClaveEncajado);
            xUpd.AsignarParametro(MovimientoOCDetaEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xUpd.AsignarParametro(MovimientoOCDetaEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CCodAre, pObj.CCodigoArea);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CCodPar, pObj.CCodigoPartida);
            xUpd.AsignarParametro(MovimientoOCDetaEN.CEstMovDet, pObj.CEstadoMovimientoDeta);
            xUpd.AsignarParametro(MovimientoOCDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(MovimientoOCDetaEN.FecMod, "FECHAHORA");
            xUpd.AsignarParametro(MovimientoOCDetaEN.CanRec, pObj.CantidadRecibida.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.CanPen, pObj.CantidadPendiente.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.CanRecVar, pObj.CantidadRecibidaVarios.ToString());
            xUpd.AsignarParametro(MovimientoOCDetaEN.ClaMovICab, pObj.ClaveMovimientoICabe.ToString());
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveMovimientoDeta);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarMovimientoDeta(List<MovimientoOCDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(MovimientoOCDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovDet.FechaMovimientoCabe));
                xUpd.AsignarParametro(MovimientoOCDetaEN.CCodMon, xMovDet.CCodigoMoneda);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CodCenCos, xMovDet.CodigoCentroCosto);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CodExi, xMovDet.CodigoExistencia);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CodUniMed, xMovDet.CodigoUnidadMedida);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CanMovDet, xMovDet.CantidadMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniMovDet, xMovDet.PrecioUnitarioMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniDolMovDet, xMovDet.PrecioUnitarioDolarMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.TipCam, xMovDet.TipoCambio.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CosMovDet, xMovDet.CostoMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.GloMovDet, xMovDet.GlosaMovimientoDeta);
                xUpd.AsignarParametro(MovimientoOCDetaEN.StoAntExi, xMovDet.StockAnteriorExistencia.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreAntExi, xMovDet.PrecioAnteriorExistencia.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.StoExi, xMovDet.StockExistencia.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreExi, xMovDet.PrecioExistencia.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.ClaProDet, xMovDet.ClaveProduccionDeta);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CTipDes, xMovDet.CTipoDescarga);
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniPro, xMovDet.PrecioUnitarioProduccion.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniCon, xMovDet.PrecioUnitarioConversion.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CanCon, xMovDet.CantidadConversion.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CosFleMovDet, xMovDet.CostoFleteMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CosFleMovCab, xMovDet.CostoFleteMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.ClaEnc, xMovDet.ClaveEncajado);
                xUpd.AsignarParametro(MovimientoOCDetaEN.ClaProProTer, xMovDet.ClaveProduccionProTer);
                xUpd.AsignarParametro(MovimientoOCDetaEN.ClaProTerParEmp, xMovDet.ClaveProduccionProTerParteEmpaquetado);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CCodAre, xMovDet.CCodigoArea);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CCodPar, xMovDet.CCodigoPartida);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CEstMovDet, xMovDet.CEstadoMovimientoDeta);
                xUpd.AsignarParametro(MovimientoOCDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(MovimientoOCDetaEN.FecMod, "FECHAHORA");
                xUpd.AsignarParametro(MovimientoOCDetaEN.CanRec, xMovDet.CantidadRecibida.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CanPen, xMovDet.CantidadPendiente.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CanRecVar, xMovDet.CantidadRecibidaVarios.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.ClaMovICab, xMovDet.ClaveMovimientoICabe.ToString());
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaMovDet, SqlSelect.Operador.Igual, xMovDet.ClaveMovimientoDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarMovimientoDetaParaRecalculo(List<MovimientoOCDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.IniciaTransaccion();

            //recorrer cada objeto
            foreach (MovimientoOCDetaEN xMovDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(MovimientoOCDetaEN.CanMovDet, xMovDet.CantidadMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreUniMovDet, xMovDet.PrecioUnitarioMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CosMovDet, xMovDet.CostoMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.StoAntExi, xMovDet.StockAnteriorExistencia.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreAntExi, xMovDet.PrecioAnteriorExistencia.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.StoExi, xMovDet.StockExistencia.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.PreExi, xMovDet.PrecioExistencia.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CosFleMovDet, xMovDet.CostoFleteMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.CosFleMovCab, xMovDet.CostoFleteMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(MovimientoOCDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaMovDet, SqlSelect.Operador.Igual, xMovDet.ClaveMovimientoDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTextoTransaccion(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.CerrarTransaccion();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveMovimientoDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoDetaXMovimientoCabe(MovimientoOCDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoDetaXPeriodoYOrigen(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoOCDeta";
            iScript += " Where ClaveMovimientoCabe in(Select ClaveMovimientoCabe From VsMovimientoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }

        public void EliminarMovimientoDetaXPeriodoXOrigenYClase(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoOCDeta";
            iScript += " Where ClaveMovimientoCabe in(Select ClaveMovimientoCabe From VsMovimientoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And CClaseTipoOperacion='" + pObj.CClaseTipoOperacion + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }

        public void EliminarMovimientoDetaXPeriodoYAlmacen(MovimientoOCDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoDetaAlmacenesCompraParaRegenerar(MovimientoOCDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoOCDeta";
            iScript += " Where ClaveMovimientoCabe in(Select ClaveMovimientoCabe From VsMovimientoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And CodigoTipoOperacion='11' And SUBSTRING( ClaveIngresoMovimientoCabe,13,3)='A10')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<MovimientoOCDetaEN> ListarMovimientoDetas(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public MovimientoOCDetaEN BuscarMovimientoDetaXClave(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveMovimientoDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveMovimientoCabe(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaRecalculo(string pCodigoPeriodo)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.PerMovCab, SqlSelect.Operador.Igual, pCodigoPeriodo);
            xSel.Ordenar(MovimientoOCDetaEN.CodAlm + "," + MovimientoOCDetaEN.CodExi + "," + MovimientoOCDetaEN.FecMovCab + "," +
                            MovimientoOCDetaEN.CClaTipOpe + "," + MovimientoOCCabeEN.FecAgr, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<MovimientoOCDetaEN>> iLisRes = new List<List<MovimientoOCDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoAlmacen + iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<MovimientoOCDetaEN> iLisMovDet = new List<MovimientoOCDetaEN>();
                    iLisMovDet.Add(iMovDetEN);
                    iLisRes.Add(iLisMovDet);
                    iIndice++;
                    iExistencia = iMovDetEN.CodigoAlmacen + iMovDetEN.CodigoExistencia;
                }
                else
                {
                    iLisRes[iIndice].Add(iMovDetEN);
                }
            }
            xObjCon.Desconectar();
            return iLisRes;
        }

        public List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaKardex(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            if (pObj.CodigoTipo != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodTip, SqlSelect.Operador.Igual, pObj.CodigoTipo);
            }
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodExi, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.Ordenar(MovimientoOCDetaEN.CodAlm + "," + MovimientoOCDetaEN.CodExi + "," + MovimientoOCDetaEN.FecMovCab + "," +
                            MovimientoOCDetaEN.CClaTipOpe + "," + MovimientoOCCabeEN.FecAgr, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<MovimientoOCDetaEN>> iLisRes = new List<List<MovimientoOCDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoAlmacen + iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<MovimientoOCDetaEN> iLisMovDet = new List<MovimientoOCDetaEN>();
                    iLisMovDet.Add(iMovDetEN);
                    iLisRes.Add(iLisMovDet);
                    iIndice++;
                    iExistencia = iMovDetEN.CodigoAlmacen + iMovDetEN.CodigoExistencia;
                }
                else
                {
                    iLisRes[iIndice].Add(iMovDetEN);
                }
            }
            xObjCon.Desconectar();
            return iLisRes;
        }

        public List<List<MovimientoOCDetaEN>> ListarListasDeMovimientoDetasParaDocumentosEmitidos(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.CodigoTipoOperacion != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoOCDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));

            xSel.Ordenar(MovimientoOCDetaEN.CodExi, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<MovimientoOCDetaEN>> iLisRes = new List<List<MovimientoOCDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<MovimientoOCDetaEN> iLisMovDet = new List<MovimientoOCDetaEN>();
                    iLisMovDet.Add(iMovDetEN);
                    iLisRes.Add(iLisMovDet);
                    iIndice++;
                    iExistencia = iMovDetEN.CodigoExistencia;
                }
                else
                {
                    iLisRes[iIndice].Add(iMovDetEN);
                }
            }
            xObjCon.Desconectar();
            return iLisRes;
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDetaParaSalidasXCeCoDetalle(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.Adicionales.Desde3 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodCenCos, pObj.Adicionales.Desde3, pObj.Adicionales.Hasta3);
            }
            if (pObj.Adicionales.Desde2 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodExi, pObj.Adicionales.Desde2, pObj.Adicionales.Hasta2);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoOCDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDetaParaControlMovimientosISDetalle(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.Adicionales.Desde2 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodExi, pObj.Adicionales.Desde2, pObj.Adicionales.Hasta2);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoOCDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionDeta(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDetaParaSaldosXExistencia(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.Ordenar(MovimientoOCDetaEN.FecMovCab + "," + MovimientoOCDetaEN.CClaTipOpe + "," + MovimientoOCCabeEN.FecAgr, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDetaXPeriodo(string pCodigoPeriodo)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.PerMovCab, SqlSelect.Operador.Igual, pCodigoPeriodo);
            xSel.Ordenar(MovimientoOCDetaEN.ClaMovDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionProTer(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCDetaEN> ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.ClaProTerParEmp, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTerParteEmpaquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public void ActualizarCantidadRecibidayPendiente(MovimientoOCDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Update MovimientoOCDeta Set CantidadPendiente = " + pObj.CantidadPendiente + ",";
            iScript += " CantidadRecibida = " + pObj.CantidadRecibida + ",";
            iScript += " CantidadRecibidaVarios = CantidadRecibidaVarios + '" + pObj.CantidadRecibidaVarios + ";'";
            iScript += " Where ClaveMovimientoDeta = '" + pObj.ClaveMovimientoDeta + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }

        public void ActualizarCantidadRecibidayClaveMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Update MovimientoOCDeta Set  CantidadRecibidaVarios = '',";
            iScript += " ClaveMovimientoICabe = ClaveMovimientoICabe + '" + pObj.ClaveMovimientoICabe + ";'";
            iScript += " Where ClaveMovimientoDeta = '" + pObj.ClaveMovimientoDeta + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }
        public List<MovimientoOCDetaEN> ListarMovimientosDetaParaOrdenServicioXCeCoDetalle(MovimientoOCDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, "4");//orden servicio
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.CodigoCentroCosto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodCenCos, SqlSelect.Operador.Igual, pObj.CodigoCentroCosto);
            }
            if (pObj.CCodigoPartida != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CCodPar, SqlSelect.Operador.Igual, pObj.CCodigoPartida);
            }
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            if (pObj.CodigoExistencia != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            }

            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoOCDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        #endregion

    }
}
