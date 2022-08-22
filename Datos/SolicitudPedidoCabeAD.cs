using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Config;
using Entidades;
using System.Data;
using Comun;
using ScriptBD;
using Entidades.Adicionales;

namespace Datos
{
    public class SolicitudPedidoCabeAD
    {
        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<SolicitudPedidoCabeEN> xLista = new List<SolicitudPedidoCabeEN>();
        private SolicitudPedidoCabeEN xObj = new SolicitudPedidoCabeEN();
        private string xTabla = "SolicitudPedidoCabe";
        private string xVista = "VsSolicitudPedidoCabe";

        #endregion

        #region Metodos privados

        private SolicitudPedidoCabeEN Objeto(IDataReader iDr)
        {
            SolicitudPedidoCabeEN xObjEnc = new SolicitudPedidoCabeEN();
            xObjEnc.ClaveSolicitudPedidoCabe = iDr[SolicitudPedidoCabeEN.ClaMovCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[SolicitudPedidoCabeEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[SolicitudPedidoCabeEN.NomEmp].ToString();
            xObjEnc.PeriodoSolicitudPedidoCabe = iDr[SolicitudPedidoCabeEN.PerMovCab].ToString();
            xObjEnc.CodigoAlmacen = iDr[SolicitudPedidoCabeEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[SolicitudPedidoCabeEN.DesAlm].ToString();
            //xObjEnc.CConversionUnidad = iDr[SolicitudPedidoCabeEN.CConUni].ToString();
            xObjEnc.NumeroSolicitudPedidoCabe = iDr[SolicitudPedidoCabeEN.NumMovCab].ToString();
            xObjEnc.FechaSolicitudPedidoCabe = Fecha.ObtenerDiaMesAno(iDr[SolicitudPedidoCabeEN.FecMovCab].ToString());
            xObjEnc.FechaSolicitudPedidoFinCabe = Fecha.ObtenerDiaMesAno(iDr[SolicitudPedidoCabeEN.FecMovFinCab].ToString());
            xObjEnc.CodigoAuxiliar = iDr[SolicitudPedidoCabeEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[SolicitudPedidoCabeEN.DesAux].ToString();
            xObjEnc.CodigoPersonal = iDr[SolicitudPedidoCabeEN.CodPer].ToString();
            xObjEnc.NombrePersonal = iDr[SolicitudPedidoCabeEN.NomPer].ToString();
            xObjEnc.CodigoPersonalAutoriza = iDr[SolicitudPedidoCabeEN.CodPerAut].ToString();
            xObjEnc.NombrePersonalAutoriza = iDr[SolicitudPedidoCabeEN.NomPerAut].ToString();
            xObjEnc.FechaDocumento = Fecha.ObtenerDiaMesAno(iDr[SolicitudPedidoCabeEN.FecDoc].ToString());
            xObjEnc.ClaveProduccionDeta = iDr[SolicitudPedidoCabeEN.ClaProDet].ToString();
            xObjEnc.COrigenVentanaCreacion = iDr[SolicitudPedidoCabeEN.COriVenCre].ToString();
            xObjEnc.NOrigenVentanaCreacion = iDr[SolicitudPedidoCabeEN.NOriVenCre].ToString();
            xObjEnc.CCodigoMoneda = iDr[SolicitudPedidoCabeEN.CCodMon].ToString();
            xObjEnc.NCodigoMoneda = iDr[SolicitudPedidoCabeEN.NCodMon].ToString();
            xObjEnc.ClaveEncajado = iDr[SolicitudPedidoCabeEN.ClaEnc].ToString();
            xObjEnc.ClaveProduccionProTer = iDr[SolicitudPedidoCabeEN.ClaProProTer].ToString();
            xObjEnc.DetalleProduccionDetaAdicional = iDr[SolicitudPedidoCabeEN.DetProDetAdi].ToString();
            xObjEnc.GlosaSolicitudPedidoCabe = iDr[SolicitudPedidoCabeEN.GloMovCab].ToString();
            xObjEnc.ClaveProduccionProTerParteEmpaquetado = iDr[SolicitudPedidoCabeEN.ClaProTerParEmp].ToString();
            xObjEnc.TipoCambio = Convert.ToDecimal(iDr[SolicitudPedidoCabeEN.TipCam].ToString());
            xObjEnc.CEstadoSolicitudPedidoCabe = iDr[SolicitudPedidoCabeEN.CEstMovCab].ToString();
            xObjEnc.NEstadoSolicitudPedidoCabe = iDr[SolicitudPedidoCabeEN.NEstMovCab].ToString();
            xObjEnc.CostoFleteSolicitudPedidoCabe = Convert.ToDecimal(iDr[SolicitudPedidoCabeEN.CosFleMovCab].ToString());
            xObjEnc.UsuarioAgrega = iDr[SolicitudPedidoCabeEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[SolicitudPedidoCabeEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[SolicitudPedidoCabeEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[SolicitudPedidoCabeEN.FecMod]);
            xObjEnc.MasivoSolicitudPedidoCabe = Convert.ToBoolean(iDr[SolicitudPedidoCabeEN.MasSolPed].ToString());
            xObjEnc.FlagEnviadoSolicitudPedido = Convert.ToBoolean(iDr[SolicitudPedidoCabeEN.FlagEnvSolPed].ToString());
            xObjEnc.CCopiaSolicitudPedidoCabe = iDr[SolicitudPedidoCabeEN.CCopiaSolPed].ToString();
            xObjEnc.NCopiaSolicitudPedidoCabe = iDr[SolicitudPedidoCabeEN.NCopiaSolPed].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveSolicitudPedidoCabe;
            xObjEnc.CorreoAuxiliar = iDr[SolicitudPedidoCabeEN.CorreoAux].ToString();
            return xObjEnc;
        }

        private List<SolicitudPedidoCabeEN> ListarObjetos(string pScript)
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

        private SolicitudPedidoCabeEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, SolicitudPedidoCabeEN.NumMovCab);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaMovCab, pObj.ClaveSolicitudPedidoCabe);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.PerMovCab, pObj.PeriodoSolicitudPedidoCabe);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.NumMovCab, pObj.NumeroSolicitudPedidoCabe);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaSolicitudPedidoCabe));
            xIns.AsignarParametro(SolicitudPedidoCabeEN.FecMovFinCab, Fecha.ObtenerAnoMesDia(pObj.FechaSolicitudPedidoFinCabe));
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CodPer, pObj.CodigoPersonal);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CodPerAut, pObj.CodigoPersonalAutoriza);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xIns.AsignarParametro(SolicitudPedidoCabeEN.GloMovCab, pObj.GlosaSolicitudPedidoCabe);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.COriVenCre, pObj.COrigenVentanaCreacion);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CCodMon, pObj.CCodigoMoneda);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaEnc, pObj.ClaveEncajado);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.DetProDetAdi, pObj.DetalleProduccionDetaAdicional);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CosFleMovCab, pObj.CostoFleteSolicitudPedidoCabe.ToString());
            xIns.AsignarParametro(SolicitudPedidoCabeEN.TipCam, pObj.TipoCambio.ToString());
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CEstMovCab, pObj.CEstadoSolicitudPedidoCabe);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(SolicitudPedidoCabeEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(SolicitudPedidoCabeEN.FecMod, "FECHAHORA");
            xIns.AsignarParametro(SolicitudPedidoCabeEN.MasSolPed, pObj.MasivoSolicitudPedidoCabe.ToString());
            xIns.AsignarParametro(SolicitudPedidoCabeEN.FlagEnvSolPed, pObj.FlagEnviadoSolicitudPedido.ToString());
            xIns.AsignarParametro(SolicitudPedidoCabeEN.CCopiaSolPed, pObj.CCopiaSolicitudPedidoCabe.ToString());
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarSolicitudPedidoCabe(List<SolicitudPedidoCabeEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (SolicitudPedidoCabeEN xMovCab in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaMovCab, xMovCab.ClaveSolicitudPedidoCabe);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CodEmp, xMovCab.CodigoEmpresa);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.PerMovCab, xMovCab.PeriodoSolicitudPedidoCabe);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CodAlm, xMovCab.CodigoAlmacen);
                //xIns.AsignarParametro(SolicitudPedidoCabeEN.CodTipOpe, xMovCab.CodigoTipoOperacion);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.NumMovCab, xMovCab.NumeroSolicitudPedidoCabe);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovCab.FechaSolicitudPedidoCabe));
                xIns.AsignarParametro(SolicitudPedidoCabeEN.FecMovFinCab, Fecha.ObtenerAnoMesDia(xMovCab.FechaSolicitudPedidoFinCabe));
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CodAux, xMovCab.CodigoAuxiliar);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CodPer, xMovCab.CodigoPersonal);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CodPerAut, xMovCab.CodigoPersonalAutoriza);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovCab.FechaDocumento));
                xIns.AsignarParametro(SolicitudPedidoCabeEN.GloMovCab, xMovCab.GlosaSolicitudPedidoCabe);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaProDet, xMovCab.ClaveProduccionDeta);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CCodMon, xMovCab.CCodigoMoneda);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.COriVenCre, xMovCab.COrigenVentanaCreacion);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CosFleMovCab, xMovCab.CostoFleteSolicitudPedidoCabe.ToString());
                xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaEnc, xMovCab.ClaveEncajado);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaProProTer, xMovCab.ClaveProduccionProTer);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.DetProDetAdi, xMovCab.DetalleProduccionDetaAdicional);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.ClaProTerParEmp, xMovCab.ClaveProduccionProTerParteEmpaquetado);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.TipCam, xMovCab.TipoCambio.ToString());
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CEstMovCab, xMovCab.CEstadoSolicitudPedidoCabe);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(SolicitudPedidoCabeEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(SolicitudPedidoCabeEN.FecMod, "FECHAHORA");
                xIns.AsignarParametro(SolicitudPedidoCabeEN.MasSolPed, xMovCab.MasivoSolicitudPedidoCabe.ToString());
                xIns.AsignarParametro(SolicitudPedidoCabeEN.FlagEnvSolPed, xMovCab.FlagEnviadoSolicitudPedido.ToString());
                xIns.AsignarParametro(SolicitudPedidoCabeEN.CCopiaSolPed, xMovCab.CCopiaSolicitudPedidoCabe.ToString());
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(pObj.FechaSolicitudPedidoCabe));
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.FecMovFinCab, Fecha.ObtenerAnoMesDia(pObj.FechaSolicitudPedidoFinCabe));
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.CodAux, pObj.CodigoAuxiliar);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.CodPer, pObj.CodigoPersonal);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.CodPerAut, pObj.CodigoPersonalAutoriza);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.GloMovCab, pObj.GlosaSolicitudPedidoCabe);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.ClaProDet, pObj.ClaveProduccionDeta);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.CCodMon, pObj.CCodigoMoneda);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.COriVenCre, pObj.COrigenVentanaCreacion);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.ClaEnc, pObj.ClaveEncajado);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.DetProDetAdi, pObj.DetalleProduccionDetaAdicional);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.CosFleMovCab, pObj.CostoFleteSolicitudPedidoCabe.ToString());
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.ClaProTerParEmp, pObj.ClaveProduccionProTerParteEmpaquetado);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.TipCam, pObj.TipoCambio.ToString());
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.CEstMovCab, pObj.CEstadoSolicitudPedidoCabe);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.FecMod, "FECHAHORA");
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.MasSolPed, pObj.MasivoSolicitudPedidoCabe.ToString());
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.FlagEnvSolPed, pObj.FlagEnviadoSolicitudPedido.ToString());
            xUpd.AsignarParametro(SolicitudPedidoCabeEN.CCopiaSolPed, pObj.CCopiaSolicitudPedidoCabe.ToString());
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveSolicitudPedidoCabe);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarSolicitudPedidoCabe(List<SolicitudPedidoCabeEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (SolicitudPedidoCabeEN xMovCab in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.FecMovCab, Fecha.ObtenerAnoMesDia(xMovCab.FechaSolicitudPedidoCabe));
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.FecMovFinCab, Fecha.ObtenerAnoMesDia(xMovCab.FechaSolicitudPedidoFinCabe));
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.PerMovCab, xMovCab.PeriodoSolicitudPedidoCabe);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.CodAux, xMovCab.CodigoAuxiliar);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.CodPer, xMovCab.CodigoPersonal);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.CodPerAut, xMovCab.CodigoPersonalAutoriza);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.FecDoc, Fecha.ObtenerAnoMesDia(xMovCab.FechaDocumento));
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.GloMovCab, xMovCab.GlosaSolicitudPedidoCabe);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.ClaProDet, xMovCab.ClaveProduccionDeta);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.COriVenCre, xMovCab.COrigenVentanaCreacion);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.CCodMon, xMovCab.CCodigoMoneda);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.ClaEnc, xMovCab.ClaveEncajado);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.ClaProProTer, xMovCab.ClaveProduccionProTer);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.DetProDetAdi, xMovCab.DetalleProduccionDetaAdicional);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.ClaProTerParEmp, xMovCab.ClaveProduccionProTerParteEmpaquetado);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.CosFleMovCab, xMovCab.CostoFleteSolicitudPedidoCabe.ToString());
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.TipCam, xMovCab.TipoCambio.ToString());
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.CEstMovCab, xMovCab.CEstadoSolicitudPedidoCabe);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.FecMod, "FECHAHORA");
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.MasSolPed, xMovCab.MasivoSolicitudPedidoCabe.ToString());
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.FlagEnvSolPed, xMovCab.FlagEnviadoSolicitudPedido.ToString());
                xUpd.AsignarParametro(SolicitudPedidoCabeEN.CCopiaSolPed, xMovCab.CCopiaSolicitudPedidoCabe.ToString());
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.ClaMovCab, SqlSelect.Operador.Igual, xMovCab.ClaveSolicitudPedidoCabe);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();

            }

            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveSolicitudPedidoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoCabeXPeriodoYOrigen(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.COriVenCre, SqlSelect.Operador.Igual, pObj.COrigenVentanaCreacion);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoCabeXPeriodoXOrigenYClase(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From SolicitudPedidoCabe";
            iScript += " Where ClaveSolicitudPedidoCabe in(Select ClaveSolicitudPedidoCabe From VsSolicitudPedidoCabe Where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            //iScript += " And CClaseTipoOperacion='" + pObj.CClaseTipoOperacion + "'";
            iScript += " And COrigenVentanaCreacion='" + pObj.COrigenVentanaCreacion + "')";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoCabeXPeriodoYAlmacen(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarSolicitudPedidoCabeAlmacenesCompraParaRegenerar(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Delete From SolicitudPedidoCabe";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            iScript += " And CodigoTipoOperacion='11' And SUBSTRING( ClaveIngresoSolicitudPedidoCabe,13,3)='A10'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AprobarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update SolicitudPedidoCabe set CEstadoSolicitudPedidoCabe = 2";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            iScript += " And ClaveSolicitudPedidoCabe ='" + pObj.ClaveSolicitudPedidoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void DesaprobarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update SolicitudPedidoCabe set CEstadoSolicitudPedidoCabe = 5";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            iScript += " And ClaveSolicitudPedidoCabe ='" + pObj.ClaveSolicitudPedidoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EnviadoSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update SolicitudPedidoCabe set CEstadoSolicitudPedidoCabe = 3, FlagEnviadoSolicitudPedido = 1";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            iScript += " And ClaveSolicitudPedidoCabe ='" + pObj.ClaveSolicitudPedidoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void CerrarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update SolicitudPedidoCabe set CEstadoSolicitudPedidoCabe = 4";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And PeriodoSolicitudPedidoCabe='" + pObj.PeriodoSolicitudPedidoCabe + "'";
            iScript += " And ClaveSolicitudPedidoCabe ='" + pObj.ClaveSolicitudPedidoCabe + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabes(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public SolicitudPedidoCabeEN BuscarSolicitudPedidoCabeXClave(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveSolicitudPedidoCabe);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXPeriodoYClaseOperacion(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesParaGrillaTransferencia(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.COriVenCre, SqlSelect.Operador.Igual, "3");//transferencia
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesParaGrillaIngresos(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.COriVenCre, SqlSelect.Operador.Igual, "1");//ingreso
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "1");//ingreso
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesParaGrillaSalidas(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.COriVenCre, SqlSelect.Operador.Igual, "2");//salida
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, "2");//salida
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXPeriodo(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXClaveProduccionDetaYClaseOperacion(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesImportados(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.COriVenCre, SqlSelect.Operador.Igual, "5");//importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesNoImportados(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.PerMovCab, SqlSelect.Operador.Igual, pObj.PeriodoSolicitudPedidoCabe);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.COriVenCre, SqlSelect.Operador.Diferente, "5");//no importacion excel
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXClaveProduccionProTerYClaseOperacion(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(SolicitudPedidoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, SolicitudPedidoCabeEN.ClaProTerParEmp, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTerParteEmpaquetado);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, SolicitudPedidoCabeEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion


    }
}
