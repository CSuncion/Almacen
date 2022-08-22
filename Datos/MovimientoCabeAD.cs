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

    public class MovimientoCabeAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<MovimientoCabeEN> xLista = new List<MovimientoCabeEN>();
        private MovimientoCabeEN xObj = new MovimientoCabeEN();
        private string xTabla = "MovimientoCabe";
        private string xVista = "VsMovimientoCabe";

        #endregion

        #region Metodos privados

        private MovimientoCabeEN Objeto(IDataReader iDr)
        {
            MovimientoCabeEN xObjEnc = new MovimientoCabeEN();
            xObjEnc.ClaveMovimientoCabe = iDr[MovimientoCabeEN.ClaMovCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[MovimientoCabeEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[MovimientoCabeEN.NomEmp].ToString();
            xObjEnc.PeriodoMovimientoCabe = iDr[MovimientoCabeEN.PerMovCab].ToString();
            xObjEnc.CodigoAlmacen = iDr[MovimientoCabeEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[MovimientoCabeEN.DesAlm].ToString();
            xObjEnc.CodigoTipoOperacion = iDr[MovimientoCabeEN.CodTipOpe].ToString();
            xObjEnc.DescripcionTipoOperacion = iDr[MovimientoCabeEN.DesTipOpe].ToString();
            xObjEnc.CClaseTipoOperacion = iDr[MovimientoCabeEN.CClaTipOpe].ToString();
            xObjEnc.NClaseTipoOperacion = iDr[MovimientoCabeEN.NClaTipOpe].ToString();
            xObjEnc.CCalculaPrecioPromedio = iDr[MovimientoCabeEN.CCalPrePro].ToString();
            xObjEnc.CConversionUnidad = iDr[MovimientoCabeEN.CConUni].ToString();
            xObjEnc.NumeroMovimientoCabe = iDr[MovimientoCabeEN.NumMovCab].ToString();
            xObjEnc.FechaMovimientoCabe = Fecha.ObtenerDiaMesAno(iDr[MovimientoCabeEN.FecMovCab].ToString());
            xObjEnc.CodigoAuxiliar = iDr[MovimientoCabeEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[MovimientoCabeEN.DesAux].ToString();
            xObjEnc.CodigoPersonal = iDr[MovimientoCabeEN.CodPer].ToString();
            xObjEnc.NombrePersonal = iDr[MovimientoCabeEN.NomPer].ToString();
            xObjEnc.CodigoPersonalAutoriza = iDr[MovimientoCabeEN.CodPerAut].ToString();
            xObjEnc.NombrePersonalAutoriza = iDr[MovimientoCabeEN.NomPerAut].ToString();
            xObjEnc.CodigoPersonalRecibe = iDr[MovimientoCabeEN.CodPerRec].ToString();
            xObjEnc.NombrePersonalRecibe = iDr[MovimientoCabeEN.NomPerRec].ToString();
            xObjEnc.OrdenCompra = iDr[MovimientoCabeEN.OrdCom].ToString();
            xObjEnc.GuiaRemision = iDr[MovimientoCabeEN.GuiRem].ToString();
            xObjEnc.CTipoDocumento = iDr[MovimientoCabeEN.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[MovimientoCabeEN.NTipDoc].ToString();
            xObjEnc.SerieDocumento = iDr[MovimientoCabeEN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[MovimientoCabeEN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[MovimientoCabeEN.FecDoc].ToString());
            xObjEnc.IgvPorcentaje = Convert.ToDecimal(iDr[MovimientoCabeEN.IgvPor].ToString());
            xObjEnc.ValorVtaMovimientoCabe = Convert.ToDecimal(iDr[MovimientoCabeEN.ValVtaMovCab].ToString());
            xObjEnc.IgvMovimientoCabe = Convert.ToDecimal(iDr[MovimientoCabeEN.IgvMovCab].ToString());
            xObjEnc.ExoneradoMovimientoCabe = Convert.ToDecimal(iDr[MovimientoCabeEN.ExoMovCab].ToString());
            xObjEnc.PrecioVtaMovimientoCabe = Convert.ToDecimal(iDr[MovimientoCabeEN.PreVtaMovCab].ToString());
            xObjEnc.MontoTotalMovimientoCabe = Convert.ToDecimal(iDr[MovimientoCabeEN.MonTotMovCab].ToString());
            xObjEnc.GlosaMovimientoCabe = iDr[MovimientoCabeEN.GloMovCab].ToString();
            xObjEnc.ClaveIngresoMovimientoCabe = iDr[MovimientoCabeEN.ClaIngMovCab].ToString();
            xObjEnc.ClaveProduccionDeta = iDr[MovimientoCabeEN.ClaProDet].ToString();
            xObjEnc.CTipoDescarga = iDr[MovimientoCabeEN.CTipDes].ToString();
            xObjEnc.COrigenVentanaCreacion = iDr[MovimientoCabeEN.COriVenCre].ToString();
            xObjEnc.NOrigenVentanaCreacion = iDr[MovimientoCabeEN.NOriVenCre].ToString();
            xObjEnc.CostoFleteMovimientoCabe = Convert.ToDecimal(iDr[MovimientoCabeEN.CosFleMovCab].ToString());
            xObjEnc.CCodigoMoneda = iDr[MovimientoCabeEN.CCodMon].ToString();
            xObjEnc.NCodigoMoneda = iDr[MovimientoCabeEN.NCodMon].ToString();
            xObjEnc.ClaveEncajado = iDr[MovimientoCabeEN.ClaEnc].ToString();
            xObjEnc.ClaveProduccionProTer = iDr[MovimientoCabeEN.ClaProProTer].ToString();
            xObjEnc.DetalleProduccionDetaAdicional = iDr[MovimientoCabeEN.DetProDetAdi].ToString();
            xObjEnc.ClaveProduccionProTerParteEmpaquetado = iDr[MovimientoCabeEN.ClaProTerParEmp].ToString();
            xObjEnc.TipoCambio = Convert.ToDecimal(iDr[MovimientoCabeEN.TipCam].ToString());
            xObjEnc.CEstadoMovimientoCabe = iDr[MovimientoCabeEN.CEstMovCab].ToString();
            xObjEnc.NEstadoMovimientoCabe = iDr[MovimientoCabeEN.NEstMovCab].ToString();
            xObjEnc.UsuarioAgrega = iDr[MovimientoCabeEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[MovimientoCabeEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[MovimientoCabeEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[MovimientoCabeEN.FecMod]);
            xObjEnc.FlagCalculadoFlete = Convert.ToBoolean(iDr[MovimientoCabeEN.FlagCalFle].ToString());
            xObjEnc.CorreoAuxiliar = iDr[MovimientoCabeEN.CorreoAux].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveMovimientoCabe;
            return xObjEnc;
        }

        private List<MovimientoCabeEN> ListarObjetos(string pScript)
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

        private MovimientoCabeEN BuscarObjeto(string pScript)
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

        private string ObtenerValor(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            string iValor = xObjCon.ObtenerValor();
            xObjCon.Desconectar();
            return iValor;
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, MovimientoCabeEN.NumMovCab);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarMovimientoCabe(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(MovimientoCabeEN.ClaMovCab, pObj.ClaveMovimientoCabe);
            xIns.AsignarParametro(MovimientoCabeEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(MovimientoCabeEN.PerMovCab, pObj.PeriodoMovimientoCabe);
            xIns.AsignarParametro(MovimientoCabeEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(MovimientoCabeEN.CodTipOpe, pObj.CodigoTipoOperacion);
            xIns.AsignarParametro(MovimientoCabeEN.NumMovCab, pObj.NumeroMovimientoCabe);
            xIns.AsignarParametro(MovimientoCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaMovimientoCabe));
            xIns.AsignarParametro(MovimientoCabeEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(MovimientoCabeEN.CodPer, pObj.CodigoPersonal);
            xIns.AsignarParametro(MovimientoCabeEN.CodPerAut, pObj.CodigoPersonalAutoriza);
            xIns.AsignarParametro(MovimientoCabeEN.CodPerRec, pObj.CodigoPersonalRecibe);
            xIns.AsignarParametro(MovimientoCabeEN.OrdCom, pObj.OrdenCompra);
            xIns.AsignarParametro(MovimientoCabeEN.GuiRem, pObj.GuiaRemision);
            xIns.AsignarParametro(MovimientoCabeEN.CTipDoc, pObj.CTipoDocumento);
            xIns.AsignarParametro(MovimientoCabeEN.SerDoc, pObj.SerieDocumento);
            xIns.AsignarParametro(MovimientoCabeEN.NumDoc, pObj.NumeroDocumento);
            xIns.AsignarParametro(MovimientoCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xIns.AsignarParametro(MovimientoCabeEN.IgvPor, pObj.IgvPorcentaje.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.ValVtaMovCab, pObj.ValorVtaMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.IgvMovCab, pObj.IgvMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.ExoMovCab, pObj.ExoneradoMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.PreVtaMovCab, pObj.PrecioVtaMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.MonTotMovCab, pObj.MontoTotalMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.GloMovCab, pObj.GlosaMovimientoCabe);
            xIns.AsignarParametro(MovimientoCabeEN.ClaIngMovCab, pObj.ClaveIngresoMovimientoCabe);
            xIns.AsignarParametro(MovimientoCabeEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(MovimientoCabeEN.CTipDes, pObj.CTipoDescarga);
            xIns.AsignarParametro(MovimientoCabeEN.COriVenCre, pObj.COrigenVentanaCreacion);
            xIns.AsignarParametro(MovimientoCabeEN.CosFleMovCab, pObj.CostoFleteMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.CCodMon, pObj.CCodigoMoneda);
            xIns.AsignarParametro(MovimientoCabeEN.ClaEnc, pObj.ClaveEncajado);
            xIns.AsignarParametro(MovimientoCabeEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xIns.AsignarParametro(MovimientoCabeEN.DetProDetAdi, pObj.DetalleProduccionDetaAdicional);
            xIns.AsignarParametro(MovimientoCabeEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xIns.AsignarParametro(MovimientoCabeEN.TipCam, pObj.TipoCambio.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.CEstMovCab, pObj.CEstadoMovimientoCabe);
            xIns.AsignarParametro(MovimientoCabeEN.FlagCalFle, pObj.FlagCalculadoFlete.ToString());
            xIns.AsignarParametro(MovimientoCabeEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(MovimientoCabeEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(MovimientoCabeEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(MovimientoCabeEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarMovimientoCabe(List<MovimientoCabeEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (MovimientoCabeEN xMovCab in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(MovimientoCabeEN.ClaMovCab, xMovCab.ClaveMovimientoCabe);
                xIns.AsignarParametro(MovimientoCabeEN.CodEmp, xMovCab.CodigoEmpresa);
                xIns.AsignarParametro(MovimientoCabeEN.PerMovCab, xMovCab.PeriodoMovimientoCabe);
                xIns.AsignarParametro(MovimientoCabeEN.CodAlm, xMovCab.CodigoAlmacen);
                xIns.AsignarParametro(MovimientoCabeEN.CodTipOpe, xMovCab.CodigoTipoOperacion);
                xIns.AsignarParametro(MovimientoCabeEN.NumMovCab, xMovCab.NumeroMovimientoCabe);
                xIns.AsignarParametro(MovimientoCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovCab.FechaMovimientoCabe));
                xIns.AsignarParametro(MovimientoCabeEN.CodAux, xMovCab.CodigoAuxiliar);
                xIns.AsignarParametro(MovimientoCabeEN.CodPer, xMovCab.CodigoPersonal);
                xIns.AsignarParametro(MovimientoCabeEN.CodPerAut, xMovCab.CodigoPersonalAutoriza);
                xIns.AsignarParametro(MovimientoCabeEN.CodPerRec, xMovCab.CodigoPersonalRecibe);
                xIns.AsignarParametro(MovimientoCabeEN.OrdCom, xMovCab.OrdenCompra);
                xIns.AsignarParametro(MovimientoCabeEN.GuiRem, xMovCab.GuiaRemision);
                xIns.AsignarParametro(MovimientoCabeEN.CTipDoc, xMovCab.CTipoDocumento);
                xIns.AsignarParametro(MovimientoCabeEN.SerDoc, xMovCab.SerieDocumento);
                xIns.AsignarParametro(MovimientoCabeEN.NumDoc, xMovCab.NumeroDocumento);
                xIns.AsignarParametro(MovimientoCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovCab.FechaDocumento));
                xIns.AsignarParametro(MovimientoCabeEN.IgvPor, xMovCab.IgvPorcentaje.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.ValVtaMovCab, xMovCab.ValorVtaMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.IgvMovCab, xMovCab.IgvMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.ExoMovCab, xMovCab.ExoneradoMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.PreVtaMovCab, xMovCab.PrecioVtaMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.MonTotMovCab, xMovCab.MontoTotalMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.GloMovCab, xMovCab.GlosaMovimientoCabe);
                xIns.AsignarParametro(MovimientoCabeEN.ClaIngMovCab, xMovCab.ClaveIngresoMovimientoCabe);
                xIns.AsignarParametro(MovimientoCabeEN.ClaProDet, xMovCab.ClaveProduccionDeta);
                xIns.AsignarParametro(MovimientoCabeEN.CTipDes, xMovCab.CTipoDescarga);
                xIns.AsignarParametro(MovimientoCabeEN.CosFleMovCab, xMovCab.CostoFleteMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.CCodMon, xMovCab.CCodigoMoneda);
                xIns.AsignarParametro(MovimientoCabeEN.COriVenCre, xMovCab.COrigenVentanaCreacion);
                xIns.AsignarParametro(MovimientoCabeEN.ClaEnc, xMovCab.ClaveEncajado);
                xIns.AsignarParametro(MovimientoCabeEN.ClaProProTer, xMovCab.ClaveProduccionProTer);
                xIns.AsignarParametro(MovimientoCabeEN.DetProDetAdi, xMovCab.DetalleProduccionDetaAdicional);
                xIns.AsignarParametro(MovimientoCabeEN.ClaProTerParEmp, xMovCab.ClaveProduccionProTerParteEmpaquetado);
                xIns.AsignarParametro(MovimientoCabeEN.TipCam, xMovCab.TipoCambio.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.CEstMovCab, xMovCab.CEstadoMovimientoCabe);
                xIns.AsignarParametro(MovimientoCabeEN.FlagCalFle, xMovCab.FlagCalculadoFlete.ToString());
                xIns.AsignarParametro(MovimientoCabeEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(MovimientoCabeEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(MovimientoCabeEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(MovimientoCabeEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarMovimientoCabe(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(MovimientoCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaMovimientoCabe));
            xUpd.AsignarParametro(MovimientoCabeEN.CodAux, pObj.CodigoAuxiliar);
            xUpd.AsignarParametro(MovimientoCabeEN.CodPer, pObj.CodigoPersonal);
            xUpd.AsignarParametro(MovimientoCabeEN.CodPerAut, pObj.CodigoPersonalAutoriza);
            xUpd.AsignarParametro(MovimientoCabeEN.CodPerRec, pObj.CodigoPersonalRecibe);
            xUpd.AsignarParametro(MovimientoCabeEN.OrdCom, pObj.OrdenCompra);
            xUpd.AsignarParametro(MovimientoCabeEN.GuiRem, pObj.GuiaRemision);
            xUpd.AsignarParametro(MovimientoCabeEN.CTipDoc, pObj.CTipoDocumento);
            xUpd.AsignarParametro(MovimientoCabeEN.SerDoc, pObj.SerieDocumento);
            xUpd.AsignarParametro(MovimientoCabeEN.NumDoc, pObj.NumeroDocumento);
            xUpd.AsignarParametro(MovimientoCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xUpd.AsignarParametro(MovimientoCabeEN.IgvPor, pObj.IgvPorcentaje.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.ValVtaMovCab, pObj.ValorVtaMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.IgvMovCab, pObj.IgvMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.ExoMovCab, pObj.ExoneradoMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.PreVtaMovCab, pObj.PrecioVtaMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.MonTotMovCab, pObj.MontoTotalMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.GloMovCab, pObj.GlosaMovimientoCabe);
            xUpd.AsignarParametro(MovimientoCabeEN.ClaIngMovCab, pObj.ClaveIngresoMovimientoCabe);
            xUpd.AsignarParametro(MovimientoCabeEN.ClaProDet, pObj.ClaveProduccionDeta);
            xUpd.AsignarParametro(MovimientoCabeEN.CTipDes, pObj.CTipoDescarga);
            xUpd.AsignarParametro(MovimientoCabeEN.CosFleMovCab, pObj.CostoFleteMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.CCodMon, pObj.CCodigoMoneda);
            xUpd.AsignarParametro(MovimientoCabeEN.COriVenCre, pObj.COrigenVentanaCreacion);
            xUpd.AsignarParametro(MovimientoCabeEN.ClaEnc, pObj.ClaveEncajado);
            xUpd.AsignarParametro(MovimientoCabeEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xUpd.AsignarParametro(MovimientoCabeEN.DetProDetAdi, pObj.DetalleProduccionDetaAdicional);
            xUpd.AsignarParametro(MovimientoCabeEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xUpd.AsignarParametro(MovimientoCabeEN.TipCam, pObj.TipoCambio.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.CEstMovCab, pObj.CEstadoMovimientoCabe);
            xUpd.AsignarParametro(MovimientoCabeEN.FlagCalFle, pObj.FlagCalculadoFlete.ToString());
            xUpd.AsignarParametro(MovimientoCabeEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(MovimientoCabeEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarMovimientoCabe(List<MovimientoCabeEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (MovimientoCabeEN xMovCab in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(MovimientoCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovCab.FechaMovimientoCabe));
                xUpd.AsignarParametro(MovimientoCabeEN.PerMovCab, xMovCab.PeriodoMovimientoCabe);
                xUpd.AsignarParametro(MovimientoCabeEN.CodAux, xMovCab.CodigoAuxiliar);
                xUpd.AsignarParametro(MovimientoCabeEN.CodPer, xMovCab.CodigoPersonal);
                xUpd.AsignarParametro(MovimientoCabeEN.CodPerAut, xMovCab.CodigoPersonalAutoriza);
                xUpd.AsignarParametro(MovimientoCabeEN.CodPerRec, xMovCab.CodigoPersonalRecibe);
                xUpd.AsignarParametro(MovimientoCabeEN.OrdCom, xMovCab.OrdenCompra);
                xUpd.AsignarParametro(MovimientoCabeEN.GuiRem, xMovCab.GuiaRemision);
                xUpd.AsignarParametro(MovimientoCabeEN.CTipDoc, xMovCab.CTipoDocumento);
                xUpd.AsignarParametro(MovimientoCabeEN.SerDoc, xMovCab.SerieDocumento);
                xUpd.AsignarParametro(MovimientoCabeEN.NumDoc, xMovCab.NumeroDocumento);
                xUpd.AsignarParametro(MovimientoCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovCab.FechaDocumento));
                xUpd.AsignarParametro(MovimientoCabeEN.IgvPor, xMovCab.IgvPorcentaje.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.ValVtaMovCab, xMovCab.ValorVtaMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.IgvMovCab, xMovCab.IgvMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.ExoMovCab, xMovCab.ExoneradoMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.PreVtaMovCab, xMovCab.PrecioVtaMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.MonTotMovCab, xMovCab.MontoTotalMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.GloMovCab, xMovCab.GlosaMovimientoCabe);
                xUpd.AsignarParametro(MovimientoCabeEN.ClaIngMovCab, xMovCab.ClaveIngresoMovimientoCabe);
                xUpd.AsignarParametro(MovimientoCabeEN.ClaProDet, xMovCab.ClaveProduccionDeta);
                xUpd.AsignarParametro(MovimientoCabeEN.CTipDes, xMovCab.CTipoDescarga);
                xUpd.AsignarParametro(MovimientoCabeEN.COriVenCre, xMovCab.COrigenVentanaCreacion);
                xUpd.AsignarParametro(MovimientoCabeEN.CosFleMovCab, xMovCab.CostoFleteMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.CCodMon, xMovCab.CCodigoMoneda);
                xUpd.AsignarParametro(MovimientoCabeEN.ClaEnc, xMovCab.ClaveEncajado);
                xUpd.AsignarParametro(MovimientoCabeEN.ClaProProTer, xMovCab.ClaveProduccionProTer);
                xUpd.AsignarParametro(MovimientoCabeEN.DetProDetAdi, xMovCab.DetalleProduccionDetaAdicional);
                xUpd.AsignarParametro(MovimientoCabeEN.ClaProTerParEmp, xMovCab.ClaveProduccionProTerParteEmpaquetado);
                xUpd.AsignarParametro(MovimientoCabeEN.TipCam, xMovCab.TipoCambio.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.CEstMovCab, xMovCab.CEstadoMovimientoCabe);
                xUpd.AsignarParametro(MovimientoCabeEN.FlagCalFle, xMovCab.FlagCalculadoFlete.ToString());
                xUpd.AsignarParametro(MovimientoCabeEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(MovimientoCabeEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.ClaMovCab, SqlSelect.Operador.Igual, xMovCab.ClaveMovimientoCabe);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();

            }

            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabe(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabeXPeriodoYOrigen(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.COriVenCre, SqlSelect.Operador.Igual, pObj.COrigenVentanaCreacion);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabeXPeriodoXOrigenYClase(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoCabe";
            iScript += " Where ClaveMovimientoCabe in(Select ClaveMovimientoCabe From VsMovimientoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And CClaseTipoOperacion='" + pObj.CClaseTipoOperacion + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabeXPeriodoYAlmacen(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabeAlmacenesCompraParaRegenerar(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoCabe";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And CodigoTipoOperacion='11' And SUBSTRING( ClaveIngresoMovimientoCabe,13,3)='A10'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<MovimientoCabeEN> ListarMovimientoCabes(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public MovimientoCabeEN BuscarMovimientoCabeXClave(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesXPeriodoYClaseOperacion(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.COriVenCre, SqlSelect.Operador.Diferente, pObj.COrigenVentanaCreacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesXPeriodoYClaseOperacionOrdenCompra(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.COriVenCre, SqlSelect.Operador.Igual, pObj.COrigenVentanaCreacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesParaGrillaTransferencia(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.COriVenCre, SqlSelect.Operador.Igual, "3");//transferencia
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesParaGrillaIngresos(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.COriVenCre, SqlSelect.Operador.Igual, "1");//ingreso
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "1");//ingreso
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesParaGrillaSalidas(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.COriVenCre, SqlSelect.Operador.Igual, "2");//salida
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesXPeriodo(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesXClaveProduccionDetaYClaseOperacion(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesImportados(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.COriVenCre, SqlSelect.Operador.Igual, "5");//importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesNoImportados(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.COriVenCre, SqlSelect.Operador.Diferente, "5");//no importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesXClaveProduccionProTerYClaseOperacion(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoCabeEN> ListarMovimientoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(MovimientoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoCabeEN.ClaProTerParEmp, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTerParteEmpaquetado);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public void EnviadoMovimientoCabe(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoCabe set CEstadoMovimientoCabe = 3, FlagEnviadoMovimientoCabe = 1";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And ClaveMovimientoCabe ='" + pObj.ClaveMovimientoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ActualizaCostoFletexMovimientoCabe(MovimientoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoCabe set CostoFleteMovimientoCabe = " + pObj.CostoFleteMovimientoCabe + ", ";
            iScript += " FlagCalculadoFlete = '1' ";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CodigoAlmacen ='" + pObj.CodigoAlmacen + "'";
            iScript += " And PeriodoMovimientoCabe ='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And ClaveMovimientoCabe='" + pObj.ClaveMovimientoCabe + "' ";

            iScript += " Update MovimientoDeta set CostoFleteMovimientoCabe = " + pObj.CostoFleteMovimientoCabe + " ";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CodigoAlmacen ='" + pObj.CodigoAlmacen + "'";
            iScript += " And PeriodoMovimientoCabe ='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And ClaveMovimientoCabe='" + pObj.ClaveMovimientoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        #endregion

    }
}
