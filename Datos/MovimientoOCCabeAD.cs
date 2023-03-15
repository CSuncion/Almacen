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

    public class MovimientoOCCabeAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<MovimientoOCCabeEN> xLista = new List<MovimientoOCCabeEN>();
        private MovimientoOCCabeEN xObj = new MovimientoOCCabeEN();
        private string xTabla = "MovimientoOCCabe";
        private string xVista = "VsMovimientoOCCabe";

        #endregion

        #region Metodos privados

        private MovimientoOCCabeEN Objeto(IDataReader iDr)
        {
            MovimientoOCCabeEN xObjEnc = new MovimientoOCCabeEN();
            xObjEnc.ClaveMovimientoCabe = iDr[MovimientoOCCabeEN.ClaMovCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[MovimientoOCCabeEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[MovimientoOCCabeEN.NomEmp].ToString();
            xObjEnc.PeriodoMovimientoCabe = iDr[MovimientoOCCabeEN.PerMovCab].ToString();
            xObjEnc.CodigoAlmacen = iDr[MovimientoOCCabeEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[MovimientoOCCabeEN.DesAlm].ToString();
            xObjEnc.CodigoTipoOperacion = iDr[MovimientoOCCabeEN.CodTipOpe].ToString();
            xObjEnc.DescripcionTipoOperacion = iDr[MovimientoOCCabeEN.DesTipOpe].ToString();
            xObjEnc.CClaseTipoOperacion = iDr[MovimientoOCCabeEN.CClaTipOpe].ToString();
            xObjEnc.NClaseTipoOperacion = iDr[MovimientoOCCabeEN.NClaTipOpe].ToString();
            xObjEnc.CCalculaPrecioPromedio = iDr[MovimientoOCCabeEN.CCalPrePro].ToString();
            xObjEnc.CConversionUnidad = iDr[MovimientoOCCabeEN.CConUni].ToString();
            xObjEnc.NumeroMovimientoCabe = iDr[MovimientoOCCabeEN.NumMovCab].ToString();
            xObjEnc.FechaMovimientoCabe = Fecha.ObtenerDiaMesAno(iDr[MovimientoOCCabeEN.FecMovCab].ToString());
            xObjEnc.CodigoAuxiliar = iDr[MovimientoOCCabeEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[MovimientoOCCabeEN.DesAux].ToString();
            xObjEnc.CodigoPersonal = iDr[MovimientoOCCabeEN.CodPer].ToString();
            xObjEnc.NombrePersonal = iDr[MovimientoOCCabeEN.NomPer].ToString();
            xObjEnc.CodigoPersonalAutoriza = iDr[MovimientoOCCabeEN.CodPerAut].ToString();
            xObjEnc.NombrePersonalAutoriza = iDr[MovimientoOCCabeEN.NomPerAut].ToString();
            xObjEnc.CodigoPersonalRecibe = iDr[MovimientoOCCabeEN.CodPerRec].ToString();
            xObjEnc.NombrePersonalRecibe = iDr[MovimientoOCCabeEN.NomPerRec].ToString();
            xObjEnc.OrdenCompra = iDr[MovimientoOCCabeEN.OrdCom].ToString();
            xObjEnc.GuiaRemision = iDr[MovimientoOCCabeEN.GuiRem].ToString();
            xObjEnc.CTipoDocumento = iDr[MovimientoOCCabeEN.CTipDoc].ToString();
            xObjEnc.NTipoDocumento = iDr[MovimientoOCCabeEN.NTipDoc].ToString();
            xObjEnc.SerieDocumento = iDr[MovimientoOCCabeEN.SerDoc].ToString();
            xObjEnc.NumeroDocumento = iDr[MovimientoOCCabeEN.NumDoc].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[MovimientoOCCabeEN.FecDoc].ToString());
            xObjEnc.IgvPorcentaje = Convert.ToDecimal(iDr[MovimientoOCCabeEN.IgvPor].ToString());
            xObjEnc.ValorVtaMovimientoCabe = Convert.ToDecimal(iDr[MovimientoOCCabeEN.ValVtaMovCab].ToString());
            xObjEnc.IgvMovimientoCabe = Convert.ToDecimal(iDr[MovimientoOCCabeEN.IgvMovCab].ToString());
            xObjEnc.ExoneradoMovimientoCabe = Convert.ToDecimal(iDr[MovimientoOCCabeEN.ExoMovCab].ToString());
            xObjEnc.PrecioVtaMovimientoCabe = Convert.ToDecimal(iDr[MovimientoOCCabeEN.PreVtaMovCab].ToString());
            xObjEnc.MontoTotalMovimientoCabe = Convert.ToDecimal(iDr[MovimientoOCCabeEN.MonTotMovCab].ToString());
            xObjEnc.GlosaMovimientoCabe = iDr[MovimientoOCCabeEN.GloMovCab].ToString();
            xObjEnc.ClaveIngresoMovimientoCabe = iDr[MovimientoOCCabeEN.ClaIngMovCab].ToString();
            xObjEnc.ClaveProduccionDeta = iDr[MovimientoOCCabeEN.ClaProDet].ToString();
            xObjEnc.CTipoDescarga = iDr[MovimientoOCCabeEN.CTipDes].ToString();
            xObjEnc.COrigenVentanaCreacion = iDr[MovimientoOCCabeEN.COriVenCre].ToString();
            xObjEnc.NOrigenVentanaCreacion = iDr[MovimientoOCCabeEN.NOriVenCre].ToString();
            xObjEnc.CostoFleteMovimientoCabe = Convert.ToDecimal(iDr[MovimientoOCCabeEN.CosFleMovCab].ToString());
            xObjEnc.CCodigoMoneda = iDr[MovimientoOCCabeEN.CCodMon].ToString();
            xObjEnc.NCodigoMoneda = iDr[MovimientoOCCabeEN.NCodMon].ToString();
            xObjEnc.ClaveEncajado = iDr[MovimientoOCCabeEN.ClaEnc].ToString();
            xObjEnc.ClaveProduccionProTer = iDr[MovimientoOCCabeEN.ClaProProTer].ToString();
            xObjEnc.DetalleProduccionDetaAdicional = iDr[MovimientoOCCabeEN.DetProDetAdi].ToString();
            xObjEnc.ClaveProduccionProTerParteEmpaquetado = iDr[MovimientoOCCabeEN.ClaProTerParEmp].ToString();
            xObjEnc.TipoCambio = Convert.ToDecimal(iDr[MovimientoOCCabeEN.TipCam].ToString());
            xObjEnc.CEstadoMovimientoCabe = iDr[MovimientoOCCabeEN.CEstMovCab].ToString();
            xObjEnc.NEstadoMovimientoCabe = iDr[MovimientoOCCabeEN.NEstMovCab].ToString();
            xObjEnc.UsuarioAgrega = iDr[MovimientoOCCabeEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[MovimientoOCCabeEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[MovimientoOCCabeEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[MovimientoOCCabeEN.FecMod]);
            xObjEnc.FlagEnviadoMovimientoCabe = Convert.ToBoolean(iDr[MovimientoOCCabeEN.FlagEnvMov].ToString());
            xObjEnc.CorreoAuxiliar = iDr[MovimientoOCCabeEN.CorreoAux].ToString();
            xObjEnc.EstadoPago = iDr[MovimientoOCCabeEN.EstPag].ToString();
            xObjEnc.DireccionAuxiliar = iDr[MovimientoOCCabeEN.DirAux].ToString();
            xObjEnc.NEstadoPago = iDr[MovimientoOCCabeEN.NEstPag].ToString();
            xObjEnc.MontoTotal = Convert.ToDecimal(iDr[MovimientoOCCabeEN.MonTot].ToString());
            xObjEnc.MontoPendiente = Convert.ToDecimal(iDr[MovimientoOCCabeEN.MonPen].ToString());
            xObjEnc.FlagCreadoxSolicitud = Convert.ToInt32(iDr[MovimientoOCCabeEN.FlgCrdSol].ToString());
            xObjEnc.ClaveSolicitudPedidoCabe = iDr[MovimientoOCCabeEN.ClaSolCabPed].ToString();
            xObjEnc.CTipoServicio = iDr[MovimientoOCCabeEN.xCTipoServicio].ToString();
            xObjEnc.NTipoServicio = iDr[MovimientoOCCabeEN.xNTipoServicio].ToString();
            xObjEnc.PlazoEntrega = iDr[MovimientoOCCabeEN.xPlazoEntrega].ToString();
            xObjEnc.Condiciones = iDr[MovimientoOCCabeEN.xCondiciones].ToString();
            xObjEnc.Garantia = Convert.ToInt32(iDr[MovimientoOCCabeEN.xGarantia].ToString());
            xObjEnc.CGarantia = iDr[MovimientoOCCabeEN.xCGarantia].ToString();
            xObjEnc.NGarantia = iDr[MovimientoOCCabeEN.xNGarantia].ToString();
            xObjEnc.ValidezCotizacion = Convert.ToInt32(iDr[MovimientoOCCabeEN.xValidezCotizacion].ToString());
            xObjEnc.FechaValidezCotizacion = iDr[MovimientoOCCabeEN.xFechaValidezCotizacion].ToString();
            xObjEnc.PrecioMaterialAccesorioOrdenServicio = Convert.ToDecimal(iDr[MovimientoOCCabeEN.xPrecioMaterialAccesorioOrdenServicio].ToString());
            xObjEnc.CFormaPago = iDr[MovimientoOCCabeEN.xCFormaPago].ToString();
            xObjEnc.NFormaPago = iDr[MovimientoOCCabeEN.xNFormaPago].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveMovimientoCabe;
            return xObjEnc;
        }

        private List<MovimientoOCCabeEN> ListarObjetos(string pScript)
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

        private MovimientoOCCabeEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, MovimientoOCCabeEN.NumMovCab);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(MovimientoOCCabeEN.ClaMovCab, pObj.ClaveMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCCabeEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(MovimientoOCCabeEN.PerMovCab, pObj.PeriodoMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCCabeEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(MovimientoOCCabeEN.CodTipOpe, pObj.CodigoTipoOperacion);
            xIns.AsignarParametro(MovimientoOCCabeEN.NumMovCab, pObj.NumeroMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaMovimientoCabe));
            xIns.AsignarParametro(MovimientoOCCabeEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(MovimientoOCCabeEN.CodPer, pObj.CodigoPersonal);
            xIns.AsignarParametro(MovimientoOCCabeEN.CodPerAut, pObj.CodigoPersonalAutoriza);
            xIns.AsignarParametro(MovimientoOCCabeEN.CodPerRec, pObj.CodigoPersonalRecibe);
            xIns.AsignarParametro(MovimientoOCCabeEN.OrdCom, pObj.OrdenCompra);
            xIns.AsignarParametro(MovimientoOCCabeEN.GuiRem, pObj.GuiaRemision);
            xIns.AsignarParametro(MovimientoOCCabeEN.CTipDoc, pObj.CTipoDocumento);
            xIns.AsignarParametro(MovimientoOCCabeEN.SerDoc, pObj.SerieDocumento);
            xIns.AsignarParametro(MovimientoOCCabeEN.NumDoc, pObj.NumeroDocumento);
            xIns.AsignarParametro(MovimientoOCCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xIns.AsignarParametro(MovimientoOCCabeEN.IgvPor, pObj.IgvPorcentaje.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.ValVtaMovCab, pObj.ValorVtaMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.IgvMovCab, pObj.IgvMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.ExoMovCab, pObj.ExoneradoMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.PreVtaMovCab, pObj.PrecioVtaMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.MonTotMovCab, pObj.MontoTotalMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.GloMovCab, pObj.GlosaMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCCabeEN.ClaIngMovCab, pObj.ClaveIngresoMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCCabeEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(MovimientoOCCabeEN.CTipDes, pObj.CTipoDescarga);
            xIns.AsignarParametro(MovimientoOCCabeEN.COriVenCre, pObj.COrigenVentanaCreacion);
            xIns.AsignarParametro(MovimientoOCCabeEN.CosFleMovCab, pObj.CostoFleteMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.CCodMon, pObj.CCodigoMoneda);
            xIns.AsignarParametro(MovimientoOCCabeEN.ClaEnc, pObj.ClaveEncajado);
            xIns.AsignarParametro(MovimientoOCCabeEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xIns.AsignarParametro(MovimientoOCCabeEN.DetProDetAdi, pObj.DetalleProduccionDetaAdicional);
            xIns.AsignarParametro(MovimientoOCCabeEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xIns.AsignarParametro(MovimientoOCCabeEN.TipCam, pObj.TipoCambio.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.CEstMovCab, pObj.CEstadoMovimientoCabe);
            xIns.AsignarParametro(MovimientoOCCabeEN.FlagEnvMov, pObj.FlagEnviadoMovimientoCabe.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.MonPen, pObj.MontoPendiente.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.FlgCrdSol, pObj.FlagCreadoxSolicitud.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(MovimientoOCCabeEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(MovimientoOCCabeEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(MovimientoOCCabeEN.FecMod, "FECHAHORA");
            xIns.AsignarParametro(MovimientoOCCabeEN.EstPag, "0");
            xIns.AsignarParametro(MovimientoOCCabeEN.xCTipoServicio, pObj.CTipoServicio);
            xIns.AsignarParametro(MovimientoOCCabeEN.xPlazoEntrega, pObj.PlazoEntrega);
            xIns.AsignarParametro(MovimientoOCCabeEN.xCondiciones, pObj.Condiciones);
            xIns.AsignarParametro(MovimientoOCCabeEN.xGarantia, pObj.Garantia.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.xCGarantia, pObj.CGarantia);
            xIns.AsignarParametro(MovimientoOCCabeEN.xValidezCotizacion, pObj.ValidezCotizacion.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.xFechaValidezCotizacion, pObj.FechaValidezCotizacion.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.xPrecioMaterialAccesorioOrdenServicio, pObj.PrecioMaterialAccesorioOrdenServicio.ToString());
            xIns.AsignarParametro(MovimientoOCCabeEN.xCFormaPago, pObj.CFormaPago);
            xIns.AsignarParametro(MovimientoOCCabeEN.ClaSolCabPed, pObj.ClaveSolicitudPedidoCabe.ToString());
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarMovimientoCabe(List<MovimientoOCCabeEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (MovimientoOCCabeEN xMovCab in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(MovimientoOCCabeEN.ClaMovCab, xMovCab.ClaveMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCCabeEN.CodEmp, xMovCab.CodigoEmpresa);
                xIns.AsignarParametro(MovimientoOCCabeEN.PerMovCab, xMovCab.PeriodoMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCCabeEN.CodAlm, xMovCab.CodigoAlmacen);
                xIns.AsignarParametro(MovimientoOCCabeEN.CodTipOpe, xMovCab.CodigoTipoOperacion);
                xIns.AsignarParametro(MovimientoOCCabeEN.NumMovCab, xMovCab.NumeroMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovCab.FechaMovimientoCabe));
                xIns.AsignarParametro(MovimientoOCCabeEN.CodAux, xMovCab.CodigoAuxiliar);
                xIns.AsignarParametro(MovimientoOCCabeEN.CodPer, xMovCab.CodigoPersonal);
                xIns.AsignarParametro(MovimientoOCCabeEN.CodPerAut, xMovCab.CodigoPersonalAutoriza);
                xIns.AsignarParametro(MovimientoOCCabeEN.CodPerRec, xMovCab.CodigoPersonalRecibe);
                xIns.AsignarParametro(MovimientoOCCabeEN.OrdCom, xMovCab.OrdenCompra);
                xIns.AsignarParametro(MovimientoOCCabeEN.GuiRem, xMovCab.GuiaRemision);
                xIns.AsignarParametro(MovimientoOCCabeEN.CTipDoc, xMovCab.CTipoDocumento);
                xIns.AsignarParametro(MovimientoOCCabeEN.SerDoc, xMovCab.SerieDocumento);
                xIns.AsignarParametro(MovimientoOCCabeEN.NumDoc, xMovCab.NumeroDocumento);
                xIns.AsignarParametro(MovimientoOCCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovCab.FechaDocumento));
                xIns.AsignarParametro(MovimientoOCCabeEN.IgvPor, xMovCab.IgvPorcentaje.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.ValVtaMovCab, xMovCab.ValorVtaMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.IgvMovCab, xMovCab.IgvMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.ExoMovCab, xMovCab.ExoneradoMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.PreVtaMovCab, xMovCab.PrecioVtaMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.MonTotMovCab, xMovCab.MontoTotalMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.GloMovCab, xMovCab.GlosaMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCCabeEN.ClaIngMovCab, xMovCab.ClaveIngresoMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCCabeEN.ClaProDet, xMovCab.ClaveProduccionDeta);
                xIns.AsignarParametro(MovimientoOCCabeEN.CTipDes, xMovCab.CTipoDescarga);
                xIns.AsignarParametro(MovimientoOCCabeEN.CosFleMovCab, xMovCab.CostoFleteMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.CCodMon, xMovCab.CCodigoMoneda);
                xIns.AsignarParametro(MovimientoOCCabeEN.COriVenCre, xMovCab.COrigenVentanaCreacion);
                xIns.AsignarParametro(MovimientoOCCabeEN.ClaEnc, xMovCab.ClaveEncajado);
                xIns.AsignarParametro(MovimientoOCCabeEN.ClaProProTer, xMovCab.ClaveProduccionProTer);
                xIns.AsignarParametro(MovimientoOCCabeEN.DetProDetAdi, xMovCab.DetalleProduccionDetaAdicional);
                xIns.AsignarParametro(MovimientoOCCabeEN.ClaProTerParEmp, xMovCab.ClaveProduccionProTerParteEmpaquetado);
                xIns.AsignarParametro(MovimientoOCCabeEN.TipCam, xMovCab.TipoCambio.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.CEstMovCab, xMovCab.CEstadoMovimientoCabe);
                xIns.AsignarParametro(MovimientoOCCabeEN.FlagEnvMov, xMovCab.FlagEnviadoMovimientoCabe.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.MonPen, xMovCab.MontoPendiente.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.FlgCrdSol, xMovCab.FlagCreadoxSolicitud.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(MovimientoOCCabeEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(MovimientoOCCabeEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(MovimientoOCCabeEN.FecMod, "FECHAHORA");
                xIns.AsignarParametro(MovimientoOCCabeEN.EstPag, "0");
                xIns.AsignarParametro(MovimientoOCCabeEN.xCTipoServicio, xMovCab.CTipoServicio);
                xIns.AsignarParametro(MovimientoOCCabeEN.xPlazoEntrega, xMovCab.PlazoEntrega);
                xIns.AsignarParametro(MovimientoOCCabeEN.xCondiciones, xMovCab.Condiciones);
                xIns.AsignarParametro(MovimientoOCCabeEN.xGarantia, xMovCab.Garantia.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.xCGarantia, xMovCab.CGarantia);
                xIns.AsignarParametro(MovimientoOCCabeEN.xValidezCotizacion, xMovCab.ValidezCotizacion.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.xFechaValidezCotizacion, xMovCab.FechaValidezCotizacion.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.xPrecioMaterialAccesorioOrdenServicio, xMovCab.PrecioMaterialAccesorioOrdenServicio.ToString());
                xIns.AsignarParametro(MovimientoOCCabeEN.xCFormaPago, xMovCab.CFormaPago);
                xIns.AsignarParametro(MovimientoOCCabeEN.ClaSolCabPed, xMovCab.ClaveSolicitudPedidoCabe.ToString());
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(MovimientoOCCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaMovimientoCabe));
            xUpd.AsignarParametro(MovimientoOCCabeEN.CodAux, pObj.CodigoAuxiliar);
            xUpd.AsignarParametro(MovimientoOCCabeEN.CodPer, pObj.CodigoPersonal);
            xUpd.AsignarParametro(MovimientoOCCabeEN.CodPerAut, pObj.CodigoPersonalAutoriza);
            xUpd.AsignarParametro(MovimientoOCCabeEN.CodPerRec, pObj.CodigoPersonalRecibe);
            xUpd.AsignarParametro(MovimientoOCCabeEN.OrdCom, pObj.OrdenCompra);
            xUpd.AsignarParametro(MovimientoOCCabeEN.GuiRem, pObj.GuiaRemision);
            xUpd.AsignarParametro(MovimientoOCCabeEN.CTipDoc, pObj.CTipoDocumento);
            xUpd.AsignarParametro(MovimientoOCCabeEN.SerDoc, pObj.SerieDocumento);
            xUpd.AsignarParametro(MovimientoOCCabeEN.NumDoc, pObj.NumeroDocumento);
            xUpd.AsignarParametro(MovimientoOCCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xUpd.AsignarParametro(MovimientoOCCabeEN.IgvPor, pObj.IgvPorcentaje.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.ValVtaMovCab, pObj.ValorVtaMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.IgvMovCab, pObj.IgvMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.ExoMovCab, pObj.ExoneradoMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.PreVtaMovCab, pObj.PrecioVtaMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.MonTotMovCab, pObj.MontoTotalMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.GloMovCab, pObj.GlosaMovimientoCabe);
            xUpd.AsignarParametro(MovimientoOCCabeEN.ClaIngMovCab, pObj.ClaveIngresoMovimientoCabe);
            xUpd.AsignarParametro(MovimientoOCCabeEN.ClaProDet, pObj.ClaveProduccionDeta);
            xUpd.AsignarParametro(MovimientoOCCabeEN.CTipDes, pObj.CTipoDescarga);
            xUpd.AsignarParametro(MovimientoOCCabeEN.CosFleMovCab, pObj.CostoFleteMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.CCodMon, pObj.CCodigoMoneda);
            xUpd.AsignarParametro(MovimientoOCCabeEN.COriVenCre, pObj.COrigenVentanaCreacion);
            xUpd.AsignarParametro(MovimientoOCCabeEN.ClaEnc, pObj.ClaveEncajado);
            xUpd.AsignarParametro(MovimientoOCCabeEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xUpd.AsignarParametro(MovimientoOCCabeEN.DetProDetAdi, pObj.DetalleProduccionDetaAdicional);
            xUpd.AsignarParametro(MovimientoOCCabeEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xUpd.AsignarParametro(MovimientoOCCabeEN.TipCam, pObj.TipoCambio.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.CEstMovCab, pObj.CEstadoMovimientoCabe);
            xUpd.AsignarParametro(MovimientoOCCabeEN.FlagEnvMov, pObj.FlagEnviadoMovimientoCabe.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.MonPen, pObj.MontoPendiente.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.FlgCrdSol, pObj.FlagCreadoxSolicitud.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(MovimientoOCCabeEN.FecMod, "FECHAHORA");
            xUpd.AsignarParametro(MovimientoOCCabeEN.EstPag, "0");
            xUpd.AsignarParametro(MovimientoOCCabeEN.xCTipoServicio, pObj.CTipoServicio);
            xUpd.AsignarParametro(MovimientoOCCabeEN.xPlazoEntrega, pObj.PlazoEntrega);
            xUpd.AsignarParametro(MovimientoOCCabeEN.xCondiciones, pObj.Condiciones);
            xUpd.AsignarParametro(MovimientoOCCabeEN.xGarantia, pObj.Garantia.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.xCGarantia, pObj.CGarantia);
            xUpd.AsignarParametro(MovimientoOCCabeEN.xValidezCotizacion, pObj.ValidezCotizacion.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.xFechaValidezCotizacion, pObj.FechaValidezCotizacion.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.xPrecioMaterialAccesorioOrdenServicio, pObj.PrecioMaterialAccesorioOrdenServicio.ToString());
            xUpd.AsignarParametro(MovimientoOCCabeEN.xCFormaPago, pObj.CFormaPago);
            xUpd.AsignarParametro(MovimientoOCCabeEN.ClaSolCabPed, pObj.ClaveSolicitudPedidoCabe.ToString());
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarMovimientoCabe(List<MovimientoOCCabeEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (MovimientoOCCabeEN xMovCab in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(MovimientoOCCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovCab.FechaMovimientoCabe));
                xUpd.AsignarParametro(MovimientoOCCabeEN.PerMovCab, xMovCab.PeriodoMovimientoCabe);
                xUpd.AsignarParametro(MovimientoOCCabeEN.CodAux, xMovCab.CodigoAuxiliar);
                xUpd.AsignarParametro(MovimientoOCCabeEN.CodPer, xMovCab.CodigoPersonal);
                xUpd.AsignarParametro(MovimientoOCCabeEN.CodPerAut, xMovCab.CodigoPersonalAutoriza);
                xUpd.AsignarParametro(MovimientoOCCabeEN.CodPerRec, xMovCab.CodigoPersonalRecibe);
                xUpd.AsignarParametro(MovimientoOCCabeEN.OrdCom, xMovCab.OrdenCompra);
                xUpd.AsignarParametro(MovimientoOCCabeEN.GuiRem, xMovCab.GuiaRemision);
                xUpd.AsignarParametro(MovimientoOCCabeEN.CTipDoc, xMovCab.CTipoDocumento);
                xUpd.AsignarParametro(MovimientoOCCabeEN.SerDoc, xMovCab.SerieDocumento);
                xUpd.AsignarParametro(MovimientoOCCabeEN.NumDoc, xMovCab.NumeroDocumento);
                xUpd.AsignarParametro(MovimientoOCCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovCab.FechaDocumento));
                xUpd.AsignarParametro(MovimientoOCCabeEN.IgvPor, xMovCab.IgvPorcentaje.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.ValVtaMovCab, xMovCab.ValorVtaMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.IgvMovCab, xMovCab.IgvMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.ExoMovCab, xMovCab.ExoneradoMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.PreVtaMovCab, xMovCab.PrecioVtaMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.MonTotMovCab, xMovCab.MontoTotalMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.GloMovCab, xMovCab.GlosaMovimientoCabe);
                xUpd.AsignarParametro(MovimientoOCCabeEN.ClaIngMovCab, xMovCab.ClaveIngresoMovimientoCabe);
                xUpd.AsignarParametro(MovimientoOCCabeEN.ClaProDet, xMovCab.ClaveProduccionDeta);
                xUpd.AsignarParametro(MovimientoOCCabeEN.CTipDes, xMovCab.CTipoDescarga);
                xUpd.AsignarParametro(MovimientoOCCabeEN.COriVenCre, xMovCab.COrigenVentanaCreacion);
                xUpd.AsignarParametro(MovimientoOCCabeEN.CosFleMovCab, xMovCab.CostoFleteMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.CCodMon, xMovCab.CCodigoMoneda);
                xUpd.AsignarParametro(MovimientoOCCabeEN.ClaEnc, xMovCab.ClaveEncajado);
                xUpd.AsignarParametro(MovimientoOCCabeEN.ClaProProTer, xMovCab.ClaveProduccionProTer);
                xUpd.AsignarParametro(MovimientoOCCabeEN.DetProDetAdi, xMovCab.DetalleProduccionDetaAdicional);
                xUpd.AsignarParametro(MovimientoOCCabeEN.ClaProTerParEmp, xMovCab.ClaveProduccionProTerParteEmpaquetado);
                xUpd.AsignarParametro(MovimientoOCCabeEN.TipCam, xMovCab.TipoCambio.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.CEstMovCab, xMovCab.CEstadoMovimientoCabe);
                xUpd.AsignarParametro(MovimientoOCCabeEN.FlagEnvMov, xMovCab.FlagEnviadoMovimientoCabe.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.MonPen, xMovCab.MontoPendiente.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.FlgCrdSol, xMovCab.FlagCreadoxSolicitud.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(MovimientoOCCabeEN.FecMod, "FECHAHORA");
                xUpd.AsignarParametro(MovimientoOCCabeEN.EstPag, "0");
                xUpd.AsignarParametro(MovimientoOCCabeEN.xCTipoServicio, xMovCab.CTipoServicio);
                xUpd.AsignarParametro(MovimientoOCCabeEN.xPlazoEntrega, xMovCab.PlazoEntrega);
                xUpd.AsignarParametro(MovimientoOCCabeEN.xCondiciones, xMovCab.Condiciones);
                xUpd.AsignarParametro(MovimientoOCCabeEN.xGarantia, xMovCab.Garantia.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.xCGarantia, xMovCab.CGarantia);
                xUpd.AsignarParametro(MovimientoOCCabeEN.xValidezCotizacion, xMovCab.ValidezCotizacion.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.xFechaValidezCotizacion, xMovCab.FechaValidezCotizacion.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.xPrecioMaterialAccesorioOrdenServicio, xMovCab.PrecioMaterialAccesorioOrdenServicio.ToString());
                xUpd.AsignarParametro(MovimientoOCCabeEN.xCFormaPago, xMovCab.CFormaPago);
                xUpd.AsignarParametro(MovimientoOCCabeEN.ClaSolCabPed, xMovCab.ClaveSolicitudPedidoCabe.ToString());
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.ClaMovCab, SqlSelect.Operador.Igual, xMovCab.ClaveMovimientoCabe);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();

            }

            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabeXPeriodoYOrigen(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.COriVenCre, SqlSelect.Operador.Igual, pObj.COrigenVentanaCreacion);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabeXPeriodoXOrigenYClase(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoOCCabe";
            iScript += " Where ClaveMovimientoCabe in(Select ClaveMovimientoCabe From VsMovimientoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And CClaseTipoOperacion='" + pObj.CClaseTipoOperacion + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabeXPeriodoYAlmacen(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarMovimientoCabeAlmacenesCompraParaRegenerar(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From MovimientoOCCabe";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And CodigoTipoOperacion='11' And SUBSTRING( ClaveIngresoMovimientoCabe,13,3)='A10'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabes(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public MovimientoOCCabeEN BuscarMovimientoCabeXClave(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesXPeriodoYClaseOperacion(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesParaGrillaTransferencia(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.COriVenCre, SqlSelect.Operador.Igual, "3");//transferencia
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesParaGrillaIngresos(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.COriVenCre, SqlSelect.Operador.Igual, "1");//ingreso
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "1");//ingreso
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesParaGrillaSalidas(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.COriVenCre, SqlSelect.Operador.Igual, "2");//salida
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesXPeriodo(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesXClaveProduccionDetaYClaseOperacion(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesImportados(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.COriVenCre, SqlSelect.Operador.Igual, "5");//importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesNoImportados(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoMovimientoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.COriVenCre, SqlSelect.Operador.Diferente, "5");//no importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesXClaveProduccionProTerYClaseOperacion(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> ListarMovimientoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.ClaProTerParEmp, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTerParteEmpaquetado);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public void EnviadoMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoOCCabe set CEstadoMovimientoCabe = 3, FlagEnviadoMovimientoCabe = 1";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And ClaveMovimientoCabe ='" + pObj.ClaveMovimientoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void CerrarMovimientoOCCabe(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoOCCabe set CEstadoMovimientoCabe = 4";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And ClaveMovimientoCabe ='" + pObj.ClaveMovimientoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        public List<MovimientoOCCabeEN> ListarMovimientoCabesAuxiliarXEstadoPago(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoOCCabeEN.EstPag, SqlSelect.Operador.Igual, pObj.EstadoPago);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<MovimientoOCCabeEN> BuscarMovimientoCabeXAuxiliar(MovimientoOCCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoOCCabeEN.CodAux, SqlSelect.Operador.Igual, pObj.CodigoAuxiliar);
            xSel.CondicionIN(SqlSelect.Reservada.Y, MovimientoOCCabeEN.EstPag, pObj.EstadoPago);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        public void CambiarEstadoPagoMovimientoOCCabe(MovimientoOCCabeEN pObj, string estado)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoOCCabe set EstadoPago = '" + estado + "' ";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And ClaveMovimientoCabe ='" + pObj.ClaveMovimientoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ActualizarCostoTotalMovimientoOCCabe(string periodo, string clavemovimientocabe, decimal montototal, decimal igvMovimientoCabe, decimal ValorVtaMovimientoCabe)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoOCCabe set MontoTotalMovimientoCabe = " + montototal + ", ";
            iScript += " MontoTotalPendientePago = " + montototal + ", ";
            iScript += " IgvMovimientoCabe = " + igvMovimientoCabe + ", ";
            iScript += " ValorVtaMovimientoCabe = " + ValorVtaMovimientoCabe;
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + periodo + "'";
            iScript += " And ClaveMovimientoCabe ='" + clavemovimientocabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ActualizarCostoTotalMovimientoOSCabe(string periodo, string clavemovimientocabe, decimal montototal)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoOCCabe set MontoTotalMovimientoCabe = " + montototal + ", ";
            iScript += " MontoTotalPendientePago = " + montototal;
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + periodo + "'";
            iScript += " And ClaveMovimientoCabe ='" + clavemovimientocabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ActualizarMontoPendienteMovimientoOCCabe(string periodo, string clavemovimientocabe, decimal montopendiente)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoOCCabe set MontoTotalPendientePago = " + montopendiente;
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + periodo + "'";
            iScript += " And ClaveMovimientoCabe ='" + clavemovimientocabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AprobarMovimientoOCCabe(MovimientoOCCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update MovimientoOCCabe set CEstadoMovimientoCabe = 2";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoMovimientoCabe='" + pObj.PeriodoMovimientoCabe + "'";
            iScript += " And ClaveMovimientoCabe ='" + pObj.ClaveMovimientoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        #endregion

    }
}
