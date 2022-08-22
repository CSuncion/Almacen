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

    public class MovimientoDetaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<MovimientoDetaEN> xLista = new List<MovimientoDetaEN>();
        private List<dynamic> xListaDinamico = new List<dynamic>();
        private MovimientoDetaEN xObj = new MovimientoDetaEN();
        private string xTabla = "MovimientoDeta";
        private string xVista = "VsMovimientoDeta";

        #endregion

        #region Metodos privados

        private MovimientoDetaEN Objeto(IDataReader iDr)
        {
            MovimientoDetaEN xObjEnc = new MovimientoDetaEN();
            xObjEnc.ClaveMovimientoDeta = iDr[MovimientoDetaEN.ClaMovDet].ToString();
            xObjEnc.ClaveMovimientoCabe = iDr[MovimientoDetaEN.ClaMovCab].ToString();
            xObjEnc.CorrelativoMovimientoDeta = iDr[MovimientoDetaEN.CorMovDet].ToString();
            xObjEnc.CodigoEmpresa = iDr[MovimientoDetaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[MovimientoDetaEN.NomEmp].ToString();
            xObjEnc.FechaMovimientoCabe = Fecha.ObtenerDiaMesAno(iDr[MovimientoDetaEN.FecMovCab].ToString());
            xObjEnc.PeriodoMovimientoCabe = iDr[MovimientoDetaEN.PerMovCab].ToString();
            xObjEnc.CodigoAlmacen = iDr[MovimientoDetaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[MovimientoDetaEN.DesAlm].ToString();
            xObjEnc.CodigoTipoOperacion = iDr[MovimientoDetaEN.CodTipOpe].ToString();
            xObjEnc.DescripcionTipoOperacion = iDr[MovimientoDetaEN.DesTipOpe].ToString();
            xObjEnc.CClaseTipoOperacion = iDr[MovimientoDetaEN.CClaTipOpe].ToString();
            xObjEnc.CCalculaPrecioPromedio = iDr[MovimientoDetaEN.CCalPrePro].ToString();
            xObjEnc.CConversionUnidad = iDr[MovimientoDetaEN.CConUni].ToString();
            xObjEnc.NumeroMovimientoCabe = iDr[MovimientoDetaEN.NumMovCab].ToString();
            xObjEnc.CodigoAuxiliar = iDr[MovimientoDetaEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[MovimientoDetaEN.DesAux].ToString();
            xObjEnc.CTipoDocumento = iDr[MovimientoDetaEN.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[MovimientoDetaEN.NTipDoc].ToString();
            xObjEnc.SerieDocumento = iDr[MovimientoDetaEN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[MovimientoDetaEN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[MovimientoDetaEN.FecDoc].ToString());
            xObjEnc.CCodigoMoneda = iDr[MovimientoDetaEN.CCodMon].ToString();
            xObjEnc.NCodigoMoneda = iDr[MovimientoDetaEN.NCodMon].ToString();
            xObjEnc.CodigoCentroCosto = iDr[MovimientoDetaEN.CodCenCos].ToString();
            xObjEnc.DescripcionCentroCosto = iDr[MovimientoDetaEN.DesCenCos].ToString();
            xObjEnc.CodigoExistencia = iDr[MovimientoDetaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[MovimientoDetaEN.DesExi].ToString();
            xObjEnc.CodigoTipo = iDr[MovimientoDetaEN.CodTip].ToString();
            xObjEnc.NombreTipo = iDr[MovimientoDetaEN.NomTip].ToString();
            xObjEnc.CEsLote = iDr[MovimientoDetaEN.CEsLot].ToString();
            xObjEnc.CEsUnidadConvertida = iDr[MovimientoDetaEN.CEsUniCon].ToString();
            xObjEnc.FactorConversion = Convert.ToDecimal(iDr[MovimientoDetaEN.FacCon].ToString());
            xObjEnc.CodigoUnidadMedida = iDr[MovimientoDetaEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[MovimientoDetaEN.NomUniMed].ToString();
            xObjEnc.CantidadMovimientoDeta = Convert.ToDecimal(iDr[MovimientoDetaEN.CanMovDet].ToString());
            xObjEnc.PrecioUnitarioMovimientoDeta = Convert.ToDecimal(iDr[MovimientoDetaEN.PreUniMovDet].ToString());
            xObjEnc.PrecioUnitarioDolarMovimientoDeta = Convert.ToDecimal(iDr[MovimientoDetaEN.PreUniDolMovDet].ToString());
            xObjEnc.TipoCambio = Convert.ToDecimal(iDr[MovimientoDetaEN.TipCam].ToString());
            xObjEnc.CostoMovimientoDeta = Convert.ToDecimal(iDr[MovimientoDetaEN.CosMovDet].ToString());
            xObjEnc.GlosaMovimientoDeta = iDr[MovimientoDetaEN.GloMovDet].ToString();
            xObjEnc.StockAnteriorExistencia = Convert.ToDecimal(iDr[MovimientoDetaEN.StoAntExi].ToString());
            xObjEnc.PrecioAnteriorExistencia = Convert.ToDecimal(iDr[MovimientoDetaEN.PreAntExi].ToString());
            xObjEnc.StockExistencia = Convert.ToDecimal(iDr[MovimientoDetaEN.StoExi].ToString());
            xObjEnc.PrecioExistencia = Convert.ToDecimal(iDr[MovimientoDetaEN.PreExi].ToString());
            xObjEnc.ClaveProduccionDeta = iDr[MovimientoDetaEN.ClaProDet].ToString();
            xObjEnc.CTipoDescarga = iDr[MovimientoDetaEN.CTipDes].ToString();
            xObjEnc.PrecioUnitarioProduccion = Convert.ToDecimal(iDr[MovimientoDetaEN.PreUniPro].ToString());
            xObjEnc.PrecioUnitarioConversion = Convert.ToDecimal(iDr[MovimientoDetaEN.PreUniCon].ToString());
            xObjEnc.CantidadConversion = Convert.ToDecimal(iDr[MovimientoDetaEN.CanCon].ToString());
            xObjEnc.CostoFleteMovimientoDeta = Convert.ToDecimal(iDr[MovimientoDetaEN.CosFleMovDet].ToString());
            xObjEnc.CostoFleteMovimientoCabe = Convert.ToDecimal(iDr[MovimientoDetaEN.CosFleMovCab].ToString());
            xObjEnc.ClaveEncajado = iDr[MovimientoDetaEN.ClaEnc].ToString();
            xObjEnc.ClaveProduccionProTer = iDr[MovimientoDetaEN.ClaProProTer].ToString();
            xObjEnc.ClaveProduccionProTerParteEmpaquetado = iDr[MovimientoDetaEN.ClaProTerParEmp].ToString();
            xObjEnc.CCodigoArea = iDr[MovimientoDetaEN.CCodAre].ToString();
            xObjEnc.NCodigoArea = iDr[MovimientoDetaEN.NCodAre].ToString();
            xObjEnc.CCodigoPartida = iDr[MovimientoDetaEN.CCodPar].ToString();
            xObjEnc.NCodigoPartida = iDr[MovimientoDetaEN.NCodPar].ToString();
            xObjEnc.CEstadoMovimientoDeta = iDr[MovimientoDetaEN.CEstMovDet].ToString();
            xObjEnc.NEstadoMovimientoDeta = iDr[MovimientoDetaEN.NEstMovDet].ToString();
            xObjEnc.UsuarioAgrega = iDr[MovimientoDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[MovimientoDetaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[MovimientoDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[MovimientoDetaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveMovimientoDeta;
            return xObjEnc;
        }

        private List<MovimientoDetaEN> ListarObjetos(string pScript)
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

        private List<dynamic> ListarObjetosDinamicos(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr = xObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                dynamic obj = new
                {
                    ClaveMovimientoCabe = xIdr["ClaveMovimientoCabe"].ToString(),
                    CantidadMovimientoDeta = xIdr["CantidadMovimientoDeta"].ToString(),
                };
                //adicionando cada objeto a la lista
                this.xListaDinamico.Add(obj);
            }
            xObjCon.Desconectar();
            return xListaDinamico;
        }

        private MovimientoDetaEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarMovimientoDeta(MovimientoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(MovimientoDetaEN.ClaMovDet, pObj.ClaveMovimientoDeta);
            xIns.AsignarParametro(MovimientoDetaEN.ClaMovCab, pObj.ClaveMovimientoCabe);
            xIns.AsignarParametro(MovimientoDetaEN.CorMovDet, pObj.CorrelativoMovimientoDeta);
            xIns.AsignarParametro(MovimientoDetaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(MovimientoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaMovimientoCabe));
            xIns.AsignarParametro(MovimientoDetaEN.PerMovCab, pObj.PeriodoMovimientoCabe);
            xIns.AsignarParametro(MovimientoDetaEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(MovimientoDetaEN.CodTipOpe, pObj.CodigoTipoOperacion);
            xIns.AsignarParametro(MovimientoDetaEN.NumMovCab, pObj.NumeroMovimientoCabe);
            xIns.AsignarParametro(MovimientoDetaEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(MovimientoDetaEN.CTipDoc, pObj.CTipoDocumento);
            xIns.AsignarParametro(MovimientoDetaEN.SerDoc, pObj.SerieDocumento);
            xIns.AsignarParametro(MovimientoDetaEN.NumDoc, pObj.NumeroDocumento);
            xIns.AsignarParametro(MovimientoDetaEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xIns.AsignarParametro(MovimientoDetaEN.CCodMon, pObj.CCodigoMoneda);
            xIns.AsignarParametro(MovimientoDetaEN.CodCenCos, pObj.CodigoCentroCosto);
            xIns.AsignarParametro(MovimientoDetaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(MovimientoDetaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xIns.AsignarParametro(MovimientoDetaEN.CanMovDet, pObj.CantidadMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.PreUniMovDet, pObj.PrecioUnitarioMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.PreUniDolMovDet, pObj.PrecioUnitarioDolarMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.TipCam, pObj.TipoCambio.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.CosMovDet, pObj.CostoMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.GloMovDet, pObj.GlosaMovimientoDeta);
            xIns.AsignarParametro(MovimientoDetaEN.StoAntExi, pObj.StockAnteriorExistencia.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.PreAntExi, pObj.PrecioAnteriorExistencia.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.StoExi, pObj.StockExistencia.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.PreExi, pObj.PrecioExistencia.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(MovimientoDetaEN.CTipDes, pObj.CTipoDescarga);
            xIns.AsignarParametro(MovimientoDetaEN.PreUniPro, pObj.PrecioUnitarioProduccion.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.PreUniCon, pObj.PrecioUnitarioConversion.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.CanCon, pObj.CantidadConversion.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.CosFleMovDet, pObj.CostoFleteMovimientoDeta.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.CosFleMovCab, pObj.CostoFleteMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoDetaEN.ClaEnc, pObj.ClaveEncajado);
            xIns.AsignarParametro(MovimientoDetaEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xIns.AsignarParametro(MovimientoDetaEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xIns.AsignarParametro(MovimientoDetaEN.CCodAre, pObj.CCodigoArea);
            xIns.AsignarParametro(MovimientoDetaEN.CCodPar, pObj.CCodigoPartida);
            xIns.AsignarParametro(MovimientoDetaEN.CEstMovDet, pObj.CEstadoMovimientoDeta);
            xIns.AsignarParametro(MovimientoDetaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(MovimientoDetaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(MovimientoDetaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(MovimientoDetaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarMovimientoDeta(List<MovimientoDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(MovimientoDetaEN.ClaMovDet, xMovDet.ClaveMovimientoDeta);
                xIns.AsignarParametro(MovimientoDetaEN.ClaMovCab, xMovDet.ClaveMovimientoCabe);
                xIns.AsignarParametro(MovimientoDetaEN.CorMovDet, xMovDet.CorrelativoMovimientoDeta);
                xIns.AsignarParametro(MovimientoDetaEN.CodEmp, xMovDet.CodigoEmpresa);
                xIns.AsignarParametro(MovimientoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovDet.FechaMovimientoCabe));
                xIns.AsignarParametro(MovimientoDetaEN.PerMovCab, xMovDet.PeriodoMovimientoCabe);
                xIns.AsignarParametro(MovimientoDetaEN.CodAlm, xMovDet.CodigoAlmacen);
                xIns.AsignarParametro(MovimientoDetaEN.CodTipOpe, xMovDet.CodigoTipoOperacion);
                xIns.AsignarParametro(MovimientoDetaEN.NumMovCab, xMovDet.NumeroMovimientoCabe);
                xIns.AsignarParametro(MovimientoDetaEN.CodAux, xMovDet.CodigoAuxiliar);
                xIns.AsignarParametro(MovimientoDetaEN.CTipDoc, xMovDet.CTipoDocumento);
                xIns.AsignarParametro(MovimientoDetaEN.SerDoc, xMovDet.SerieDocumento);
                xIns.AsignarParametro(MovimientoDetaEN.NumDoc, xMovDet.NumeroDocumento);
                xIns.AsignarParametro(MovimientoDetaEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovDet.FechaDocumento));
                xIns.AsignarParametro(MovimientoDetaEN.CCodMon, xMovDet.CCodigoMoneda);
                xIns.AsignarParametro(MovimientoDetaEN.CodCenCos, xMovDet.CodigoCentroCosto);
                xIns.AsignarParametro(MovimientoDetaEN.CodExi, xMovDet.CodigoExistencia);
                xIns.AsignarParametro(MovimientoDetaEN.CodUniMed, xMovDet.CodigoUnidadMedida);
                xIns.AsignarParametro(MovimientoDetaEN.CanMovDet, xMovDet.CantidadMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.PreUniMovDet, xMovDet.PrecioUnitarioMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.PreUniDolMovDet, xMovDet.PrecioUnitarioDolarMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.TipCam, xMovDet.TipoCambio.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.CosMovDet, xMovDet.CostoMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.GloMovDet, xMovDet.GlosaMovimientoDeta);
                xIns.AsignarParametro(MovimientoDetaEN.StoAntExi, xMovDet.StockAnteriorExistencia.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.PreAntExi, xMovDet.PrecioAnteriorExistencia.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.StoExi, xMovDet.StockExistencia.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.PreExi, xMovDet.PrecioExistencia.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.ClaProDet, xMovDet.ClaveProduccionDeta);
                xIns.AsignarParametro(MovimientoDetaEN.CTipDes, xMovDet.CTipoDescarga);
                xIns.AsignarParametro(MovimientoDetaEN.PreUniPro, xMovDet.PrecioUnitarioProduccion.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.PreUniCon, xMovDet.PrecioUnitarioConversion.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.CanCon, xMovDet.CantidadConversion.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.CosFleMovDet, xMovDet.CostoFleteMovimientoDeta.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.CosFleMovCab, xMovDet.CostoFleteMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoDetaEN.ClaEnc, xMovDet.ClaveEncajado);
                xIns.AsignarParametro(MovimientoDetaEN.ClaProProTer, xMovDet.ClaveProduccionProTer);
                xIns.AsignarParametro(MovimientoDetaEN.ClaProTerParEmp, xMovDet.ClaveProduccionProTerParteEmpaquetado);
                xIns.AsignarParametro(MovimientoDetaEN.CCodAre, xMovDet.CCodigoArea);
                xIns.AsignarParametro(MovimientoDetaEN.CCodPar, xMovDet.CCodigoPartida);
                xIns.AsignarParametro(MovimientoDetaEN.CEstMovDet, xMovDet.CEstadoMovimientoDeta);
                xIns.AsignarParametro(MovimientoDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(MovimientoDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(MovimientoDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(MovimientoDetaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarMovimientoDeta(MovimientoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(MovimientoDetaEN.CCodMon, pObj.CCodigoMoneda);
            xUpd.AsignarParametro(MovimientoDetaEN.CodCenCos, pObj.CodigoCentroCosto);
            xUpd.AsignarParametro(MovimientoDetaEN.CodExi, pObj.CodigoExistencia);
            xUpd.AsignarParametro(MovimientoDetaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xUpd.AsignarParametro(MovimientoDetaEN.CanMovDet, pObj.CantidadMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.PreUniMovDet, pObj.PrecioUnitarioMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.PreUniDolMovDet, pObj.PrecioUnitarioDolarMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.TipCam, pObj.TipoCambio.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.CosMovDet, pObj.CostoMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.GloMovDet, pObj.GlosaMovimientoDeta);
            xUpd.AsignarParametro(MovimientoDetaEN.StoAntExi, pObj.StockAnteriorExistencia.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.PreAntExi, pObj.PrecioAnteriorExistencia.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.StoExi, pObj.StockExistencia.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.PreExi, pObj.PrecioExistencia.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.ClaProDet, pObj.ClaveProduccionDeta);
            xUpd.AsignarParametro(MovimientoDetaEN.CTipDes, pObj.CTipoDescarga);
            xUpd.AsignarParametro(MovimientoDetaEN.PreUniPro, pObj.PrecioUnitarioProduccion.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.PreUniCon, pObj.PrecioUnitarioConversion.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.CanCon, pObj.CantidadConversion.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.CosFleMovDet, pObj.CostoFleteMovimientoDeta.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.CosFleMovCab, pObj.CostoFleteMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoDetaEN.ClaEnc, pObj.ClaveEncajado);
            xUpd.AsignarParametro(MovimientoDetaEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xUpd.AsignarParametro(MovimientoDetaEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xUpd.AsignarParametro(MovimientoDetaEN.CCodAre, pObj.CCodigoArea);
            xUpd.AsignarParametro(MovimientoDetaEN.CCodPar, pObj.CCodigoPartida);
            xUpd.AsignarParametro(MovimientoDetaEN.CEstMovDet, pObj.CEstadoMovimientoDeta);
            xUpd.AsignarParametro(MovimientoDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(MovimientoDetaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveMovimientoDeta);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarMovimientoDeta(List<MovimientoDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(MovimientoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovDet.FechaMovimientoCabe));
                xUpd.AsignarParametro(MovimientoDetaEN.CCodMon, xMovDet.CCodigoMoneda);
                xUpd.AsignarParametro(MovimientoDetaEN.CodCenCos, xMovDet.CodigoCentroCosto);
                xUpd.AsignarParametro(MovimientoDetaEN.CodExi, xMovDet.CodigoExistencia);
                xUpd.AsignarParametro(MovimientoDetaEN.CodUniMed, xMovDet.CodigoUnidadMedida);
                xUpd.AsignarParametro(MovimientoDetaEN.CanMovDet, xMovDet.CantidadMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.PreUniMovDet, xMovDet.PrecioUnitarioMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.PreUniDolMovDet, xMovDet.PrecioUnitarioDolarMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.TipCam, xMovDet.TipoCambio.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.CosMovDet, xMovDet.CostoMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.GloMovDet, xMovDet.GlosaMovimientoDeta);
                xUpd.AsignarParametro(MovimientoDetaEN.StoAntExi, xMovDet.StockAnteriorExistencia.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.PreAntExi, xMovDet.PrecioAnteriorExistencia.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.StoExi, xMovDet.StockExistencia.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.PreExi, xMovDet.PrecioExistencia.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.ClaProDet, xMovDet.ClaveProduccionDeta);
                xUpd.AsignarParametro(MovimientoDetaEN.CTipDes, xMovDet.CTipoDescarga);
                xUpd.AsignarParametro(MovimientoDetaEN.PreUniPro, xMovDet.PrecioUnitarioProduccion.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.PreUniCon, xMovDet.PrecioUnitarioConversion.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.CanCon, xMovDet.CantidadConversion.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.CosFleMovDet, xMovDet.CostoFleteMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.CosFleMovCab, xMovDet.CostoFleteMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.ClaEnc, xMovDet.ClaveEncajado);
                xUpd.AsignarParametro(MovimientoDetaEN.ClaProProTer, xMovDet.ClaveProduccionProTer);
                xUpd.AsignarParametro(MovimientoDetaEN.ClaProTerParEmp, xMovDet.ClaveProduccionProTerParteEmpaquetado);
                xUpd.AsignarParametro(MovimientoDetaEN.CCodAre, xMovDet.CCodigoArea);
                xUpd.AsignarParametro(MovimientoDetaEN.CCodPar, xMovDet.CCodigoPartida);
                xUpd.AsignarParametro(MovimientoDetaEN.CEstMovDet, xMovDet.CEstadoMovimientoDeta);
                xUpd.AsignarParametro(MovimientoDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(MovimientoDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, xMovDet.ClaveMovimientoDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarMovimientoDetaParaRecalculo(List<MovimientoDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.IniciaTransaccion();

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(MovimientoDetaEN.CanMovDet, xMovDet.CantidadMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.PreUniMovDet, xMovDet.PrecioUnitarioMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.CosMovDet, xMovDet.CostoMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.StoAntExi, xMovDet.StockAnteriorExistencia.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.PreAntExi, xMovDet.PrecioAnteriorExistencia.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.StoExi, xMovDet.StockExistencia.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.PreExi, xMovDet.PrecioExistencia.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.CosFleMovDet, xMovDet.CostoFleteMovimientoDeta.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.CosFleMovCab, xMovDet.CostoFleteMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(MovimientoDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, xMovDet.ClaveMovimientoDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTextoTransaccion(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.CerrarTransaccion();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoDeta(MovimientoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveMovimientoDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoDetaXMovimientoCabe(MovimientoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoDetaXPeriodoYOrigen(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoDeta";
            iScript += " Where ClaveMovimientoCabe in(Select ClaveMovimientoCabe From VsMovimientoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }

        public void EliminarMovimientoDetaXPeriodoXOrigenYClase(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoDeta";
            iScript += " Where ClaveMovimientoCabe in(Select ClaveMovimientoCabe From VsMovimientoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And CClaseTipoOperacion='" + pObj.CClaseTipoOperacion + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }

        public void EliminarMovimientoDetaXPeriodoYAlmacen(MovimientoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoDetaAlmacenesCompraParaRegenerar(MovimientoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoDeta";
            iScript += " Where ClaveMovimientoCabe in(Select ClaveMovimientoCabe From VsMovimientoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And CodigoTipoOperacion='11' And SUBSTRING( ClaveIngresoMovimientoCabe,13,3)='A10')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<MovimientoDetaEN> ListarMovimientoDetas(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public MovimientoDetaEN BuscarMovimientoDetaXClave(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveMovimientoDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaXClaveMovimientoCabe(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaRecalculo(string pCodigoPeriodo)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pCodigoPeriodo);
            xSel.Ordenar(MovimientoDetaEN.CodAlm + "," + MovimientoDetaEN.CodExi + "," + MovimientoDetaEN.FecMovCab + "," +
                            MovimientoDetaEN.CClaTipOpe + "," + MovimientoCabeEN.FecAgr, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<MovimientoDetaEN>> iLisRes = new List<List<MovimientoDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoAlmacen + iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<MovimientoDetaEN> iLisMovDet = new List<MovimientoDetaEN>();
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

        public List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaKardex(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            if (pObj.CodigoTipo != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodTip, SqlSelect.Operador.Igual, pObj.CodigoTipo);
            }
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.CodExi, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.Ordenar(MovimientoDetaEN.CodAlm + "," + MovimientoDetaEN.CodExi + "," + MovimientoDetaEN.FecMovCab + "," +
                            MovimientoDetaEN.CClaTipOpe + "," + MovimientoCabeEN.FecAgr, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<MovimientoDetaEN>> iLisRes = new List<List<MovimientoDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoAlmacen + iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<MovimientoDetaEN> iLisMovDet = new List<MovimientoDetaEN>();
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

        public List<List<MovimientoDetaEN>> ListarListasDeMovimientoDetasParaDocumentosEmitidos(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.CodigoTipoOperacion != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));

            xSel.Ordenar(MovimientoDetaEN.CodExi, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<MovimientoDetaEN>> iLisRes = new List<List<MovimientoDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<MovimientoDetaEN> iLisMovDet = new List<MovimientoDetaEN>();
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

        public List<MovimientoDetaEN> ListarMovimientosDetaParaSalidasXCeCoDetalle(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.Adicionales.Desde3 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.CodCenCos, pObj.Adicionales.Desde3, pObj.Adicionales.Hasta3);
            }
            if (pObj.Adicionales.Desde2 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.CodExi, pObj.Adicionales.Desde2, pObj.Adicionales.Hasta2);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaParaIngresoXCeCoDetalle(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, "1");//salida
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.Adicionales.Desde3 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.CodCenCos, pObj.Adicionales.Desde3, pObj.Adicionales.Hasta3);
            }
            if (pObj.Adicionales.Desde2 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.CodExi, pObj.Adicionales.Desde2, pObj.Adicionales.Hasta2);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaParaIngresoXOrdCompraXCeCoDetalle(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, "1");//salida
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.CodigoCentroCosto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodCenCos, SqlSelect.Operador.Igual, pObj.CodigoCentroCosto);
            }
            if (pObj.CCodigoPartida != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CCodPar, SqlSelect.Operador.Igual, pObj.CCodigoPartida);
            }
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            if (pObj.CodigoExistencia != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            }

            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaParaControlMovimientosISDetalle(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.Adicionales.Desde2 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.CodExi, pObj.Adicionales.Desde2, pObj.Adicionales.Hasta2);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, MovimientoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionDeta(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaParaSaldosXExistencia(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.Ordenar(MovimientoDetaEN.FecMovCab + "," + MovimientoDetaEN.CClaTipOpe + "," + MovimientoCabeEN.FecAgr, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaXPeriodo(string pCodigoPeriodo)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pCodigoPeriodo);
            xSel.Ordenar(MovimientoDetaEN.ClaMovDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionProTer(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.ClaProTerParEmp, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTerParteEmpaquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public void ActualizarCostoFleteDetayClaveMovimientoDeta(MovimientoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += " Update MovimientoDeta Set  CostoFleteMovimientoDeta = " + pObj.CostoFleteMovimientoDeta + ",";
            iScript += " PrecioUnitarioMovimientoDeta = " + pObj.PrecioUnitarioMovimientoDeta + ",";
            iScript += " CostoMovimientoDeta = " + pObj.CostoMovimientoDeta;
            iScript += " Where ClaveMovimientoDeta = '" + pObj.ClaveMovimientoDeta + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }

        public List<MovimientoDetaEN> ListarListasDeMovimientoCompraPorProvedor(MovimientoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);

            if (pObj.CodigoCentroCosto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodCenCos, SqlSelect.Operador.Igual, pObj.CodigoCentroCosto);
            }

            if (pObj.CodigoAuxiliar != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAux, SqlSelect.Operador.Igual, pObj.CodigoAuxiliar);
            }

            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }

            if (pObj.CodigoExistencia != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            }

            xSel.Ordenar(MovimientoDetaEN.CodAlm + "," + MovimientoDetaEN.CodExi + "," + MovimientoDetaEN.FecMovCab + "," +
                            MovimientoDetaEN.CClaTipOpe + "," + MovimientoCabeEN.FecAgr, SqlSelect.Orden.Asc);

            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<dynamic> ObtenerMovimientosPorOrdenCompra(string ClaveMovimiento)
        {
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += " SELECT ";
            iScript += " ClaveMovimientoCabe,";
            iScript += " SUM(CantidadMovimientoDeta) as CantidadMovimientoDeta";
            iScript += " FROM vsMovimientoDeta md";
            iScript += " WHERE md.ClaveMovimientoCabe IN (";
            iScript += " select DATOS FROM[dbo].[Split](";
            iScript += " (select distinct";
            iScript += "          ClaveMovimientoICabe";
            iScript += " from MovimientoOCDeta";
            iScript += " where ClaveMovimientoICabe != ''";
            iScript += " and ClaveMovimientoCabe = '" + ClaveMovimiento + "')";
            iScript += " , ';'";
            iScript += " ))";
            iScript += " and md.CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " GROUP BY ClaveMovimientoCabe";

            return this.ListarObjetosDinamicos(iScript);
        }

        public void ActualizarMovimientoOrdenCompra(string claveMovimientoCabe, MovimientoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += " update MovimientoOCDeta set CantidadRecibida -= " + pObj.CantidadMovimientoDeta + ",";
            iScript += " CantidadPendiente += " + pObj.CantidadMovimientoDeta + "";
            iScript += " Where ClaveMovimientoCabe = '" + claveMovimientoCabe + "'";
            iScript += " And CodigoExistencia = '" + pObj.CodigoExistencia + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        #endregion

    }
}
