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
using Entidades.Contabilidad;
using Comun;

namespace Datos
{

    public class RegContabDeta_Cont_AD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<RegContabDeta_Cont_EN> xLista = new List<RegContabDeta_Cont_EN>();
        private RegContabDeta_Cont_EN xObj = new RegContabDeta_Cont_EN();
        //private string xTabla = "RegContabDeta";
        private string xVista = "VsRegContabDeta";
        private string xTabla = "RegContabDeta";

        #endregion

        #region Metodos privados

        private RegContabDeta_Cont_EN Objeto(IDataReader iDr)
        {
            RegContabDeta_Cont_EN xObjEnc = new RegContabDeta_Cont_EN();
            xObjEnc.ClaveRegContabCabe = iDr[RegContabDeta_Cont_EN.ClaRegConCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[RegContabDeta_Cont_EN.CodEmp].ToString();
            xObjEnc.RazonSocialEmpresa = iDr[RegContabDeta_Cont_EN.RazSocEmp].ToString();
            xObjEnc.PeriodoRegContabCabe = iDr[RegContabDeta_Cont_EN.PerRegConCab].ToString();
            xObjEnc.CodigoOrigen = iDr[RegContabDeta_Cont_EN.CodOri].ToString();
            xObjEnc.NombreOrigen = iDr[RegContabDeta_Cont_EN.NomOri].ToString();
            xObjEnc.CodigoFile = iDr[RegContabDeta_Cont_EN.CodFil].ToString();
            xObjEnc.NombreFile = iDr[RegContabDeta_Cont_EN.NomFil].ToString();
            xObjEnc.FechaVoucherRegContabCabe = Fecha.ObtenerDiaMesAno(iDr[RegContabDeta_Cont_EN.FecVouRegConCab].ToString());
            xObjEnc.CodigoAuxiliar = iDr[RegContabDeta_Cont_EN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[RegContabDeta_Cont_EN.DesAux].ToString();
            xObjEnc.TipoDocumento = iDr[RegContabDeta_Cont_EN.TipDoc].ToString();
            xObjEnc.NombreDocumento = iDr[RegContabDeta_Cont_EN.NomDoc].ToString();
            xObjEnc.SerieDocumento = iDr[RegContabDeta_Cont_EN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[RegContabDeta_Cont_EN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[RegContabDeta_Cont_EN.FecDoc].ToString());
            xObjEnc.DebeHaberRegContabDeta = iDr[RegContabDeta_Cont_EN.DebHabRegConDet].ToString();
            xObjEnc.ImporteSRegContabDeta = Convert.ToDecimal(iDr[RegContabDeta_Cont_EN.ImpSRegConDet].ToString());
            xObjEnc.Almacen = iDr[RegContabDeta_Cont_EN.Alm].ToString();
            xObjEnc.CodigoGastoReparable = iDr[RegContabDeta_Cont_EN.CodGasRep].ToString();
            xObjEnc.NombreGastoReparable = iDr[RegContabDeta_Cont_EN.NomGasRep].ToString();
            xObjEnc.Unidad = iDr[RegContabDeta_Cont_EN.Uni].ToString();
            xObjEnc.Cantidad = Convert.ToDecimal(iDr[RegContabDeta_Cont_EN.Can].ToString());
            xObjEnc.PrecioUnitario = Convert.ToDecimal(iDr[RegContabDeta_Cont_EN.PreUni].ToString());
            xObjEnc.GlosaRegContabDeta = iDr[RegContabDeta_Cont_EN.GloRegConDet].ToString();
            xObjEnc.DescripcionRegContabCabe = iDr[RegContabDeta_Cont_EN.DesRegConCab].ToString();
            xObjEnc.CodigoCentroCosto = iDr[RegContabDeta_Cont_EN.CodCenCos].ToString();
            xObjEnc.NombreCentroCosto = iDr[RegContabDeta_Cont_EN.NomCenCos].ToString();

            xObjEnc.ClaveRegContabDeta = iDr[RegContabDeta_Cont_EN._ClaveRegContabDeta].ToString();
            xObjEnc.COrigen = iDr[RegContabDeta_Cont_EN._COrigen].ToString();
            xObjEnc.CFile = iDr[RegContabDeta_Cont_EN._CFile].ToString();
            xObjEnc.NumeroVoucherRegContabCabe = iDr[RegContabDeta_Cont_EN._NumeroVoucherRegContabCabe].ToString();
            xObjEnc.CorrelativoRegContabDeta = iDr[RegContabDeta_Cont_EN._CorrelativoRegContabDeta].ToString();
            xObjEnc.CTipoDocumento = iDr[RegContabDeta_Cont_EN._CTipoDocumento].ToString();
            xObjEnc.FechaVctoDocumento = iDr[RegContabDeta_Cont_EN._FechaVctoDocumento].ToString();
            xObjEnc.CMonedaDocumento = iDr[RegContabDeta_Cont_EN._CMonedaDocumento].ToString();
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[RegContabDeta_Cont_EN._VentaTipoCambio]);
            xObjEnc.CodigoCuenta = iDr[RegContabDeta_Cont_EN._CodigoCuenta].ToString();
            xObjEnc.CDebeHaber = iDr[RegContabDeta_Cont_EN._CDebeHaber].ToString();
            xObjEnc.ImporteSolRegContabDeta = Convert.ToDecimal(iDr[RegContabDeta_Cont_EN._ImporteSolRegContabDeta]);
            xObjEnc.ImporteMonedaRegContabDeta = Convert.ToDecimal(iDr[RegContabDeta_Cont_EN._ImporteMonedaRegContabDeta]);
            xObjEnc.CIngresoEgreso = iDr[RegContabDeta_Cont_EN._CIngresoEgreso].ToString();
            xObjEnc.CCentroCosto = iDr[RegContabDeta_Cont_EN._CCentroCosto].ToString();
            xObjEnc.CArea = iDr[RegContabDeta_Cont_EN._CArea].ToString();
            xObjEnc.CFlujoCaja = iDr[RegContabDeta_Cont_EN._CFlujoCaja].ToString();
            xObjEnc.CodigoAlmacen = iDr[RegContabDeta_Cont_EN._CodigoAlmacen].ToString();
            xObjEnc.CodigoItemAlmacen = iDr[RegContabDeta_Cont_EN._CodigoItemAlmacen].ToString();
            xObjEnc.CantidadItemAlmacen = Convert.ToDecimal(iDr[RegContabDeta_Cont_EN._CantidadItemAlmacen]);
            xObjEnc.CTipoLineaAsiento = iDr[RegContabDeta_Cont_EN._CTipoLineaAsiento].ToString();
            xObjEnc.CEstadoRegContabDeta = iDr[RegContabDeta_Cont_EN._CEstadoRegContabDeta].ToString();
            xObjEnc.UsuarioAgrega = iDr[RegContabDeta_Cont_EN._UsuarioAgrega].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RegContabDeta_Cont_EN._FechaAgrega]);
            xObjEnc.UsuarioModifica = iDr[RegContabDeta_Cont_EN._UsuarioModifica].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RegContabDeta_Cont_EN._FechaModifica]);


            xObjEnc.ClaveObjeto = xObjEnc.ClaveRegContabCabe;
            return xObjEnc;
        }

        private List<RegContabDeta_Cont_EN> ListarObjetos(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
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

        private RegContabDeta_Cont_EN BuscarObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
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
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
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
        private string ObtenerValor(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
            xObjCon.ComandoTexto(pScript);
            string iValor = xObjCon.ObtenerValor();
            xObjCon.Desconectar();
            return iValor;
        }
        #endregion

        #region Metodos publicos

        public List<List<RegContabDeta_Cont_EN>> ListarRegContabDetasParaImportar(string pCodigoPeriodo)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDeta_Cont_EN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDeta_Cont_EN.PerRegConCab, SqlSelect.Operador.Igual, pCodigoPeriodo);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDeta_Cont_EN.CodGasRep, SqlSelect.Operador.Diferente, string.Empty);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDeta_Cont_EN.Can, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(RegContabDeta_Cont_EN.ClaRegConCab, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<RegContabDeta_Cont_EN>> iLisRes = new List<List<RegContabDeta_Cont_EN>>();

            //variables
            string iClave = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                RegContabDeta_Cont_EN iRegConCabEN = new RegContabDeta_Cont_EN();
                iRegConCabEN = this.Objeto(xIdr);

                //preguntamos si es un contrato diferente
                if (iRegConCabEN.ClaveRegContabCabe != iClave)
                {
                    List<RegContabDeta_Cont_EN> iLisRegConCab = new List<RegContabDeta_Cont_EN>();
                    iLisRegConCab.Add(iRegConCabEN);
                    iLisRes.Add(iLisRegConCab);
                    iIndice++;
                    iClave = iRegConCabEN.ClaveRegContabCabe;
                }
                else
                {
                    iLisRes[iIndice].Add(iRegConCabEN);
                }
            }
            xObjCon.Desconectar();
            return iLisRes;
        }
        public void AgregarRegContaDeta(RegContabDeta_Cont_EN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);

            xIns.AsignarParametro(RegContabDeta_Cont_EN.ClaRegConCab, pObj.ClaveRegContabCabe.ToString());

            xIns.AsignarParametro(RegContabDeta_Cont_EN.CodAux, pObj.CodigoAuxiliar.ToString());
            xIns.AsignarParametro(RegContabDeta_Cont_EN.SerDoc, pObj.SerieDocumento.ToString());
            xIns.AsignarParametro(RegContabDeta_Cont_EN.NumDoc, pObj.NumeroDocumento.ToString());
            xIns.AsignarParametro(RegContabDeta_Cont_EN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xIns.AsignarParametro(RegContabDeta_Cont_EN.GloRegConDet, pObj.GlosaRegContabDeta.ToString());
            xIns.AsignarParametro(RegContabDeta_Cont_EN._ClaveRegContabDeta, pObj.ClaveRegContabDeta);


            xIns.AsignarParametro(RegContabDeta_Cont_EN._CorrelativoRegContabDeta, pObj.CorrelativoRegContabDeta);
            xIns.AsignarParametro(RegContabDeta_Cont_EN._CTipoDocumento, pObj.CTipoDocumento);


            xIns.AsignarParametro(RegContabDeta_Cont_EN._VentaTipoCambio, pObj.VentaTipoCambio.ToString());
            xIns.AsignarParametro(RegContabDeta_Cont_EN._CodigoCuenta, pObj.CodigoCuenta);
            xIns.AsignarParametro(RegContabDeta_Cont_EN._CDebeHaber, pObj.CDebeHaber);
            xIns.AsignarParametro(RegContabDeta_Cont_EN._ImporteSolRegContabDeta, pObj.ImporteSolRegContabDeta.ToString());
            xIns.AsignarParametro(RegContabDeta_Cont_EN._ImporteMonedaRegContabDeta, pObj.ImporteMonedaRegContabDeta.ToString());
            xIns.AsignarParametro(RegContabDeta_Cont_EN._CIngresoEgreso, pObj.CIngresoEgreso);
            xIns.AsignarParametro(RegContabDeta_Cont_EN._CCentroCosto, pObj.CCentroCosto);



            xIns.AsignarParametro(RegContabDeta_Cont_EN._CodigoItemAlmacen, pObj.CodigoItemAlmacen);


            xIns.AsignarParametro(RegContabDeta_Cont_EN._CEstadoRegContabDeta, pObj.CEstadoRegContabDeta);
            xIns.AsignarParametro(RegContabDeta_Cont_EN._UsuarioAgrega, pObj.UsuarioAgrega);
            xIns.AsignarParametro(RegContabDeta_Cont_EN._FechaAgrega, "FECHAHORA");
            xIns.AsignarParametro(RegContabDeta_Cont_EN._UsuarioModifica, pObj.UsuarioModifica);
            xIns.AsignarParametro(RegContabDeta_Cont_EN._FechaModifica, "FECHAHORA");



            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        public string ObtenerMaximoValorEnColumna(RegContabDeta_Cont_EN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, RegContabDeta_Cont_EN._CorrelativoRegContabDeta);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabDeta_Cont_EN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDeta_Cont_EN.PerRegConCab, SqlSelect.Operador.Igual, pObj.PeriodoRegContabCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDeta_Cont_EN._COrigen, SqlSelect.Operador.Igual, pObj.COrigen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDeta_Cont_EN._CFile, SqlSelect.Operador.Igual, pObj.CFile);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabDeta_Cont_EN._NumeroVoucherRegContabCabe, SqlSelect.Operador.Igual, pObj.NumeroVoucherRegContabCabe);
            return this.ObtenerValor(xSel.ObtenerScript());
        }
        #endregion

    }
}
