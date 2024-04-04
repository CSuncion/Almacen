using Comun;
using Datos.Config;
using Entidades;
using Entidades.Adicionales;
using ScriptBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class SolicitudPedidoDetaAD
    {
        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<SolicitudPedidoDetaEN> xLista = new List<SolicitudPedidoDetaEN>();
        private SolicitudPedidoDetaEN xObj = new SolicitudPedidoDetaEN();
        private string xTabla = "SolicitudPedidoDeta";
        private string xVista = "VsSolicitudPedidoDeta";

        #endregion

        #region Metodos privados

        private SolicitudPedidoDetaEN Objeto(IDataReader iDr)
        {
            SolicitudPedidoDetaEN xObjEnc = new SolicitudPedidoDetaEN();
            xObjEnc.ClaveSolicitudPedidoDeta = iDr[SolicitudPedidoDetaEN.ClaMovDet].ToString();
            xObjEnc.ClaveSolicitudPedidoCabe = iDr[SolicitudPedidoDetaEN.ClaMovCab].ToString();
            xObjEnc.CorrelativoSolicitudPedidoDeta = iDr[SolicitudPedidoDetaEN.CorMovDet].ToString();
            xObjEnc.CodigoEmpresa = iDr[SolicitudPedidoDetaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[SolicitudPedidoDetaEN.NomEmp].ToString();
            xObjEnc.FechaSolicitudPedidoCabe = Fecha.ObtenerDiaMesAno(iDr[SolicitudPedidoDetaEN.FecMovCab].ToString());
            xObjEnc.PeriodoSolicitudPedidoCabe = iDr[SolicitudPedidoDetaEN.PerMovCab].ToString();
            xObjEnc.CodigoAlmacen = iDr[SolicitudPedidoDetaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[SolicitudPedidoDetaEN.DesAlm].ToString();
            xObjEnc.CodigoTipoOperacion = iDr[SolicitudPedidoDetaEN.CodTipOpe].ToString();
            xObjEnc.DescripcionTipoOperacion = iDr[SolicitudPedidoDetaEN.DesTipOpe].ToString();
            xObjEnc.CClaseTipoOperacion = iDr[SolicitudPedidoDetaEN.CClaTipOpe].ToString();
            xObjEnc.CCalculaPrecioPromedio = iDr[SolicitudPedidoDetaEN.CCalPrePro].ToString();
            xObjEnc.CConversionUnidad = iDr[SolicitudPedidoDetaEN.CConUni].ToString();
            xObjEnc.NumeroSolicitudPedidoCabe = iDr[SolicitudPedidoDetaEN.NumMovCab].ToString();
            xObjEnc.CodigoAuxiliar = iDr[SolicitudPedidoDetaEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[SolicitudPedidoDetaEN.DesAux].ToString();
            xObjEnc.CTipoDocumento = iDr[SolicitudPedidoDetaEN.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[SolicitudPedidoDetaEN.NTipDoc].ToString();
            xObjEnc.SerieDocumento = iDr[SolicitudPedidoDetaEN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[SolicitudPedidoDetaEN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[SolicitudPedidoDetaEN.FecDoc].ToString());
            xObjEnc.CCodigoMoneda = iDr[SolicitudPedidoDetaEN.CCodMon].ToString();
            xObjEnc.NCodigoMoneda = iDr[SolicitudPedidoDetaEN.NCodMon].ToString();
            xObjEnc.CodigoCentroCosto = iDr[SolicitudPedidoDetaEN.CodCenCos].ToString();
            xObjEnc.DescripcionCentroCosto = iDr[SolicitudPedidoDetaEN.DesCenCos].ToString();
            xObjEnc.CodigoExistencia = iDr[SolicitudPedidoDetaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[SolicitudPedidoDetaEN.DesExi].ToString();
            xObjEnc.CodigoTipo = iDr[SolicitudPedidoDetaEN.CodTip].ToString();
            xObjEnc.NombreTipo = iDr[SolicitudPedidoDetaEN.NomTip].ToString();
            xObjEnc.CEsLote = iDr[SolicitudPedidoDetaEN.CEsLot].ToString();
            xObjEnc.CEsUnidadConvertida = iDr[SolicitudPedidoDetaEN.CEsUniCon].ToString();
            xObjEnc.FactorConversion = Convert.ToDecimal(iDr[SolicitudPedidoDetaEN.FacCon].ToString());
            xObjEnc.CodigoUnidadMedida = iDr[SolicitudPedidoDetaEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[SolicitudPedidoDetaEN.NomUniMed].ToString();
            xObjEnc.CantidadSolicitudPedidoDeta = Convert.ToDecimal(iDr[SolicitudPedidoDetaEN.CanMovDet].ToString());
            xObjEnc.TipoCambio = Convert.ToDecimal(iDr[SolicitudPedidoDetaEN.TipCam].ToString());
            xObjEnc.GlosaSolicitudPedidoDeta = iDr[SolicitudPedidoDetaEN.GloMovDet].ToString();
            xObjEnc.ClaveProduccionDeta = iDr[SolicitudPedidoDetaEN.ClaProDet].ToString();
            xObjEnc.CTipoDescarga = iDr[SolicitudPedidoDetaEN.CTipDes].ToString();
            xObjEnc.CantidadConversion = Convert.ToDecimal(iDr[SolicitudPedidoDetaEN.CanCon].ToString());
            xObjEnc.ClaveEncajado = iDr[SolicitudPedidoDetaEN.ClaEnc].ToString();
            xObjEnc.ClaveProduccionProTer = iDr[SolicitudPedidoDetaEN.ClaProProTer].ToString();
            xObjEnc.ClaveProduccionProTerParteEmpaquetado = iDr[SolicitudPedidoDetaEN.ClaProTerParEmp].ToString();
            xObjEnc.CCodigoArea = iDr[SolicitudPedidoDetaEN.CCodAre].ToString();
            xObjEnc.NCodigoArea = iDr[SolicitudPedidoDetaEN.NCodAre].ToString();
            xObjEnc.CCodigoPartida = iDr[SolicitudPedidoDetaEN.CCodPar].ToString();
            xObjEnc.NCodigoPartida = iDr[SolicitudPedidoDetaEN.NCodPar].ToString();
            xObjEnc.CEstadoSolicitudPedidoDeta = iDr[SolicitudPedidoDetaEN.CEstMovDet].ToString();
            xObjEnc.NEstadoSolicitudPedidoDeta = iDr[SolicitudPedidoDetaEN.NEstMovDet].ToString();
            xObjEnc.UsuarioAgrega = iDr[SolicitudPedidoDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[SolicitudPedidoDetaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[SolicitudPedidoDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[SolicitudPedidoDetaEN.FecMod]);
            xObjEnc.PrecioUltimaCompra = Convert.ToDecimal(iDr[SolicitudPedidoDetaEN.PreUltCom]);
            xObjEnc.FechaUltimaCompra = Fecha.ObtenerDiaMesAno(iDr[SolicitudPedidoDetaEN.FecUltCom]);
            xObjEnc.FlagCheckItem = Convert.ToBoolean(iDr[SolicitudPedidoDetaEN.FlgChkIt]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveSolicitudPedidoDeta;
            return xObjEnc;
        }

        private List<SolicitudPedidoDetaEN> ListarObjetos(string pScript)
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

        private SolicitudPedidoDetaEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarSolicitudPedidoDeta(SolicitudPedidoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaMovDet, pObj.ClaveSolicitudPedidoDeta);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaMovCab, pObj.ClaveSolicitudPedidoCabe);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CorMovDet, pObj.CorrelativoSolicitudPedidoDeta);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaSolicitudPedidoCabe));
            xIns.AsignarParametro(SolicitudPedidoDetaEN.PerMovCab, pObj.PeriodoSolicitudPedidoCabe);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CodTipOpe, pObj.CodigoTipoOperacion);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.NumMovCab, pObj.NumeroSolicitudPedidoCabe);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CTipDoc, pObj.CTipoDocumento);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.SerDoc, pObj.SerieDocumento);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.NumDoc, pObj.NumeroDocumento);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CCodMon, pObj.CCodigoMoneda);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CodCenCos, pObj.CodigoCentroCosto);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CanMovDet, pObj.CantidadSolicitudPedidoDeta.ToString());
            xIns.AsignarParametro(SolicitudPedidoDetaEN.TipCam, pObj.TipoCambio.ToString());
            xIns.AsignarParametro(SolicitudPedidoDetaEN.GloMovDet, pObj.GlosaSolicitudPedidoDeta);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CTipDes, pObj.CTipoDescarga);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CanCon, pObj.CantidadConversion.ToString());
            xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaEnc, pObj.ClaveEncajado);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CCodAre, pObj.CCodigoArea);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CCodPar, pObj.CCodigoPartida);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.CEstMovDet, pObj.CEstadoSolicitudPedidoDeta);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(SolicitudPedidoDetaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(SolicitudPedidoDetaEN.FecMod, "FECHAHORA");
            xIns.AsignarParametro(SolicitudPedidoDetaEN.PreUltCom, Formato.NumeroDecimal(pObj.PrecioUltimaCompra, 3));
            xIns.AsignarParametro(SolicitudPedidoDetaEN.FecUltCom, Fecha.ObtenerAnoMesDia(pObj.FechaUltimaCompra));
            xIns.AsignarParametro(SolicitudPedidoDetaEN.FlgChkIt, Convert.ToString(pObj.FlagCheckItem));
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarSolicitudPedidoDeta(List<SolicitudPedidoDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaMovDet, xMovDet.ClaveSolicitudPedidoDeta);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaMovCab, xMovDet.ClaveSolicitudPedidoCabe);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CorMovDet, xMovDet.CorrelativoSolicitudPedidoDeta);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CodEmp, xMovDet.CodigoEmpresa);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovDet.FechaSolicitudPedidoCabe));
                xIns.AsignarParametro(SolicitudPedidoDetaEN.PerMovCab, xMovDet.PeriodoSolicitudPedidoCabe);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CodAlm, xMovDet.CodigoAlmacen);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CodTipOpe, xMovDet.CodigoTipoOperacion);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.NumMovCab, xMovDet.NumeroSolicitudPedidoCabe);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CodAux, xMovDet.CodigoAuxiliar);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CTipDoc, xMovDet.CTipoDocumento);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.SerDoc, xMovDet.SerieDocumento);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.NumDoc, xMovDet.NumeroDocumento);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovDet.FechaDocumento));
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CCodMon, xMovDet.CCodigoMoneda);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CodCenCos, xMovDet.CodigoCentroCosto);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CodExi, xMovDet.CodigoExistencia);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CodUniMed, xMovDet.CodigoUnidadMedida);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CanMovDet, xMovDet.CantidadSolicitudPedidoDeta.ToString());
                xIns.AsignarParametro(SolicitudPedidoDetaEN.TipCam, xMovDet.TipoCambio.ToString());
                xIns.AsignarParametro(SolicitudPedidoDetaEN.GloMovDet, xMovDet.GlosaSolicitudPedidoDeta);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaProDet, xMovDet.ClaveProduccionDeta);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CTipDes, xMovDet.CTipoDescarga);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CanCon, xMovDet.CantidadConversion.ToString());
                xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaEnc, xMovDet.ClaveEncajado);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaProProTer, xMovDet.ClaveProduccionProTer);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.ClaProTerParEmp, xMovDet.ClaveProduccionProTerParteEmpaquetado);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CCodAre, xMovDet.CCodigoArea);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CCodPar, xMovDet.CCodigoPartida);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.CEstMovDet, xMovDet.CEstadoSolicitudPedidoDeta);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(SolicitudPedidoDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SolicitudPedidoDetaEN.FecMod, "FECHAHORA");
                xIns.AsignarParametro(SolicitudPedidoDetaEN.PreUltCom, Formato.NumeroDecimal(xMovDet.PrecioUltimaCompra, 3));
                xIns.AsignarParametro(SolicitudPedidoDetaEN.FecUltCom, Fecha.ObtenerAnoMesDia(xMovDet.FechaUltimaCompra));
                xIns.AsignarParametro(SolicitudPedidoDetaEN.FlgChkIt, Convert.ToString(xMovDet.FlagCheckItem));
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarSolicitudPedidoDeta(SolicitudPedidoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CCodMon, pObj.CCodigoMoneda);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CodCenCos, pObj.CodigoCentroCosto);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CodExi, pObj.CodigoExistencia);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CanMovDet, pObj.CantidadSolicitudPedidoDeta.ToString());
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.TipCam, pObj.TipoCambio.ToString());
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.GloMovDet, pObj.GlosaSolicitudPedidoDeta);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.ClaProDet, pObj.ClaveProduccionDeta);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CTipDes, pObj.CTipoDescarga);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CanCon, pObj.CantidadConversion.ToString());
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.ClaEnc, pObj.ClaveEncajado);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CCodAre, pObj.CCodigoArea);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CCodPar, pObj.CCodigoPartida);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.CEstMovDet, pObj.CEstadoSolicitudPedidoDeta);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.FecMod, "FECHAHORA");
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.PreUltCom, Formato.NumeroDecimal(pObj.PrecioUltimaCompra, 3));
            xUpd.AsignarParametro(SolicitudPedidoDetaEN.FecUltCom, Fecha.ObtenerAnoMesDia(pObj.FechaUltimaCompra));
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveSolicitudPedidoDeta);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarSolicitudPedidoDeta(List<SolicitudPedidoDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovDet.FechaSolicitudPedidoCabe));
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CCodMon, xMovDet.CCodigoMoneda);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CodCenCos, xMovDet.CodigoCentroCosto);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CodExi, xMovDet.CodigoExistencia);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CodUniMed, xMovDet.CodigoUnidadMedida);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CanMovDet, xMovDet.CantidadSolicitudPedidoDeta.ToString());
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.TipCam, xMovDet.TipoCambio.ToString());
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.GloMovDet, xMovDet.GlosaSolicitudPedidoDeta);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.ClaProDet, xMovDet.ClaveProduccionDeta);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CTipDes, xMovDet.CTipoDescarga);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CanCon, xMovDet.CantidadConversion.ToString());
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.ClaEnc, xMovDet.ClaveEncajado);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.ClaProProTer, xMovDet.ClaveProduccionProTer);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.ClaProTerParEmp, xMovDet.ClaveProduccionProTerParteEmpaquetado);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CCodAre, xMovDet.CCodigoArea);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CCodPar, xMovDet.CCodigoPartida);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CEstMovDet, xMovDet.CEstadoSolicitudPedidoDeta);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.FecMod, "FECHAHORA");
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.PreUltCom, Formato.NumeroDecimal(xMovDet.PrecioUltimaCompra, 3));
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.FecUltCom, Fecha.ObtenerAnoMesDia(xMovDet.FechaUltimaCompra));
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, xMovDet.ClaveSolicitudPedidoDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarSolicitudPedidoDetaParaRecalculo(List<SolicitudPedidoDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.IniciaTransaccion();

            //recorrer cada objeto
            foreach (SolicitudPedidoDetaEN xMovDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.CanMovDet, xMovDet.CantidadSolicitudPedidoDeta.ToString());
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(SolicitudPedidoDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, xMovDet.ClaveSolicitudPedidoDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTextoTransaccion(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.CerrarTransaccion();
            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoDeta(SolicitudPedidoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveSolicitudPedidoDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(SolicitudPedidoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveSolicitudPedidoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoDetaXPeriodoYOrigen(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From SolicitudPedidoDeta";
            iScript += " Where ClaveSolicitudPedidoCabe in(Select ClaveSolicitudPedidoCabe From VsSolicitudPedidoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }

        public void EliminarSolicitudPedidoDetaXPeriodoXOrigenYClase(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From SolicitudPedidoDeta";
            iScript += " Where ClaveSolicitudPedidoCabe in(Select ClaveSolicitudPedidoCabe From VsSolicitudPedidoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            //iScript += " And CClaseTipoOperacion='" + pObj.CClaseTipoOperacion + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();

        }

        public void EliminarSolicitudPedidoDetaXPeriodoYAlmacen(SolicitudPedidoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoDetaAlmacenesCompraParaRegenerar(SolicitudPedidoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From SolicitudPedidoDeta";
            iScript += " Where ClaveSolicitudPedidoCabe in(Select ClaveSolicitudPedidoCabe From VsSolicitudPedidoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            iScript += " And CodigoTipoOperacion='11' And SUBSTRING( ClaveIngresoSolicitudPedidoCabe,13,3)='A10')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidoDetas(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public SolicitudPedidoDetaEN BuscarSolicitudPedidoDetaXClave(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaMovDet, SqlSelect.Operador.Igual, pObj.ClaveSolicitudPedidoDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveSolicitudPedidoCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaRecalculo(string pCodigoPeriodo)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pCodigoPeriodo);
            xSel.Ordenar(SolicitudPedidoDetaEN.CodAlm + "," + SolicitudPedidoDetaEN.CodExi + "," + SolicitudPedidoDetaEN.FecMovCab + "," +
                            SolicitudPedidoDetaEN.CClaTipOpe + "," + SolicitudPedidoCabeEN.FecAgr, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<SolicitudPedidoDetaEN>> iLisRes = new List<List<SolicitudPedidoDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoAlmacen + iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<SolicitudPedidoDetaEN> iLisMovDet = new List<SolicitudPedidoDetaEN>();
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

        public List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaKardex(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            if (pObj.CodigoTipo != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodTip, SqlSelect.Operador.Igual, pObj.CodigoTipo);
            }
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodExi, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.Ordenar(SolicitudPedidoDetaEN.CodAlm + "," + SolicitudPedidoDetaEN.CodExi + "," + SolicitudPedidoDetaEN.FecMovCab + "," +
                            SolicitudPedidoDetaEN.CClaTipOpe + "," + SolicitudPedidoCabeEN.FecAgr, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<SolicitudPedidoDetaEN>> iLisRes = new List<List<SolicitudPedidoDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoAlmacen + iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<SolicitudPedidoDetaEN> iLisMovDet = new List<SolicitudPedidoDetaEN>();
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

        public List<List<SolicitudPedidoDetaEN>> ListarListasDeSolicitudPedidoDetasParaDocumentosEmitidos(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.CodigoTipoOperacion != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));

            xSel.Ordenar(SolicitudPedidoDetaEN.CodExi, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<SolicitudPedidoDetaEN>> iLisRes = new List<List<SolicitudPedidoDetaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
                iMovDetEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iMovDetEN.CodigoExistencia != iExistencia)
                {
                    List<SolicitudPedidoDetaEN> iLisMovDet = new List<SolicitudPedidoDetaEN>();
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

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaParaSalidasXCeCoDetalle(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.Adicionales.Desde3 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodCenCos, pObj.Adicionales.Desde3, pObj.Adicionales.Hasta3);
            }
            if (pObj.Adicionales.Desde2 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodExi, pObj.Adicionales.Desde2, pObj.Adicionales.Hasta2);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaParaControlSolicitudPedidosISDetalle(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.Adicionales.Desde2 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodExi, pObj.Adicionales.Desde2, pObj.Adicionales.Hasta2);
            }
            xSel.CondicionBetween(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                    , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionDeta(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaParaSaldosXExistencia(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.Ordenar(SolicitudPedidoDetaEN.FecMovCab + "," + SolicitudPedidoDetaEN.CClaTipOpe + "," + SolicitudPedidoCabeEN.FecAgr, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXPeriodo(string pCodigoPeriodo)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoDetaEN.PerMovCab, SqlSelect.Operador.Igual, pCodigoPeriodo);
            xSel.Ordenar(SolicitudPedidoDetaEN.ClaMovDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionProTer(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoDetaEN> ListarSolicitudPedidosDetaXClaveProduccionProTerParteEmpaquetado(SolicitudPedidoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoDetaEN.ClaProTerParEmp, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTerParteEmpaquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        public void ActualizarFlagCheckItem(SolicitudPedidoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update SolicitudPedidoDeta set FlagCheckItem = " + (pObj.FlagCheckItem ? 1 : 0).ToString();
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            iScript += " And ClaveSolicitudPedidoDeta ='" + pObj.ClaveSolicitudPedidoDeta + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        #endregion
    }
}
