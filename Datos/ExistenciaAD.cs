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

    public class ExistenciaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<ExistenciaEN> xLista = new List<ExistenciaEN>();
        private List<dynamic> xListaDinamico = new List<dynamic>();
        private ExistenciaEN xObj = new ExistenciaEN();
        private string xTabla = "Existencia";
        private string xVista = "VsExistencia";

        #endregion

        #region Metodos privados

        private ExistenciaEN Objeto(IDataReader iDr)
        {
            ExistenciaEN xObjEnc = new ExistenciaEN();
            xObjEnc.ClaveExistencia = iDr[ExistenciaEN.ClaExi].ToString();
            xObjEnc.CodigoEmpresa = iDr[ExistenciaEN.CodEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[ExistenciaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[ExistenciaEN.DesAlm].ToString();
            xObjEnc.CodigoExistencia = iDr[ExistenciaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[ExistenciaEN.DesExi].ToString();
            xObjEnc.DescripcionSecundariaExistencia = iDr[ExistenciaEN.DesSecExi].ToString();
            xObjEnc.DescripcionCortaExistencia = iDr[ExistenciaEN.DesCorExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[ExistenciaEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[ExistenciaEN.NomUniMed].ToString();
            xObjEnc.CCodigoUbicacion = iDr[ExistenciaEN.CCodUbi].ToString();
            xObjEnc.NCodigoUbicacion = iDr[ExistenciaEN.NCodUbi].ToString();
            xObjEnc.CodigoTipo = iDr[ExistenciaEN.CodTip].ToString();
            xObjEnc.NombreTipo = iDr[ExistenciaEN.NomTip].ToString();
            xObjEnc.CodigoGrupo = iDr[ExistenciaEN.CodGru].ToString();
            xObjEnc.NombreGrupo = iDr[ExistenciaEN.NomGru].ToString();
            xObjEnc.CClaseExistencia = iDr[ExistenciaEN.CClaExi].ToString();
            xObjEnc.NClaseExistencia = iDr[ExistenciaEN.NClaExi].ToString();
            xObjEnc.CSubClaseExistencia = iDr[ExistenciaEN.CSubClaExi].ToString();
            xObjEnc.NSubClaseExistencia = iDr[ExistenciaEN.NSubClaExi].ToString();
            xObjEnc.CEsProduccion = iDr[ExistenciaEN.CEsPro].ToString();
            xObjEnc.NEsProduccion = iDr[ExistenciaEN.NEsPro].ToString();
            xObjEnc.ContableExistencia = iDr[ExistenciaEN.ConExi].ToString();
            xObjEnc.CodigoArea = iDr[ExistenciaEN.CodAre].ToString();
            xObjEnc.NombreArea = iDr[ExistenciaEN.NomAre].ToString();
            xObjEnc.CCentroCosto = iDr[ExistenciaEN.CCenCto].ToString();
            //xObjEnc.NCentroCosto = iDr[ExistenciaEN.NCenCto].ToString();
            //xObjEnc.ContableExistencia = iDr[ExistenciaEN.ConExi].ToString();
            xObjEnc.AmbienteExistencia = iDr[ExistenciaEN.AmbExi].ToString();
            xObjEnc.CodigoMarca = iDr[ExistenciaEN.CodMar].ToString();
            xObjEnc.NombreMarca = iDr[ExistenciaEN.NomMar].ToString();
            xObjEnc.ModeloExistencia = iDr[ExistenciaEN.ModExi].ToString();
            xObjEnc.SerieExistencia = iDr[ExistenciaEN.SerExi].ToString();
            xObjEnc.MedidasExistencia = iDr[ExistenciaEN.MedExi].ToString();
            xObjEnc.CodigoColor = iDr[ExistenciaEN.CodCol].ToString();
            xObjEnc.NombreColor = iDr[ExistenciaEN.NomCol].ToString();
            xObjEnc.StockMinimoExistencia = Convert.ToDecimal(iDr[ExistenciaEN.StoMinExi].ToString());
            xObjEnc.StockAlertaExistencia = Convert.ToDecimal(iDr[ExistenciaEN.StoAleExi].ToString());
            xObjEnc.StockInicialExistencia = Convert.ToDecimal(iDr[ExistenciaEN.StoIniExi].ToString());
            xObjEnc.StockTomaExistencia = Convert.ToDecimal(iDr[ExistenciaEN.StoTomExi].ToString());
            xObjEnc.StockActualExistencia = Convert.ToDecimal(iDr[ExistenciaEN.StoActExi].ToString());
            xObjEnc.PrecioInicialExistencia = Convert.ToDecimal(iDr[ExistenciaEN.PreIniExi].ToString());
            xObjEnc.PrecioPromedioExistencia = Convert.ToDecimal(iDr[ExistenciaEN.PreProExi].ToString());
            xObjEnc.PesoExistencia = Convert.ToDecimal(iDr[ExistenciaEN.PesExi].ToString());
            xObjEnc.CodigoCatalogo = iDr[ExistenciaEN.CodCat].ToString();
            xObjEnc.NombreCatalogo = iDr[ExistenciaEN.NomCat].ToString();
            xObjEnc.FotoExistencia = iDr[ExistenciaEN.FotExi].ToString();
            xObjEnc.FechaVctoExistencia = iDr[ExistenciaEN.FecVctExi].ToString();
            xObjEnc.LoteProduccionExistencia = iDr[ExistenciaEN.LotProExi].ToString();
            xObjEnc.CEsLote = iDr[ExistenciaEN.CEsLot].ToString();
            xObjEnc.NEsLote = iDr[ExistenciaEN.NEsLot].ToString();
            xObjEnc.CEsUnidadConvertida = iDr[ExistenciaEN.CEsUndCon].ToString();
            xObjEnc.NEsUnidadConvertida = iDr[ExistenciaEN.NEsUndCon].ToString();
            xObjEnc.FactorConversion = Convert.ToDecimal(iDr[ExistenciaEN.FacCon].ToString());
            xObjEnc.UnidadesPorEmpaque = Convert.ToDecimal(iDr[ExistenciaEN.UniXEmp].ToString());
            xObjEnc.CEstadoExistencia = iDr[ExistenciaEN.CEstExi].ToString();
            xObjEnc.NEstadoExistencia = iDr[ExistenciaEN.NEstExi].ToString();
            xObjEnc.UsuarioAgrega = iDr[ExistenciaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ExistenciaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[ExistenciaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ExistenciaEN.FecMod]);
            xObjEnc.PrecioUltimaCompra = Convert.ToDecimal(iDr[ExistenciaEN.PreUltCom]);
            xObjEnc.FechaUltimaCompra = Fecha.ObtenerDiaMesAno(iDr[SolicitudPedidoDetaEN.FecUltCom]);
            xObjEnc.CAfectoIgv = iDr[ExistenciaEN.CAfeIgv].ToString();
            xObjEnc.NAfectoIgv = iDr[ExistenciaEN.NAfeIgv].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveExistencia;
            return xObjEnc;
        }

        private List<ExistenciaEN> ListarObjetos(string pScript)
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
                    CodigoExistencia = xIdr["CodigoExistencia"].ToString(),
                    DescripcionExistencia = xIdr["DescripcionExistencia"].ToString(),
                    NombreUnidadMedida = xIdr["NombreUnidadMedida"].ToString(),
                    StockActualExistencia = xIdr["StockActualExistencia"].ToString(),
                    CantidadSolicitudPedidoDeta = xIdr["CantidadSolicitudPedidoDeta"].ToString(),
                    CantidadPendiente = xIdr["CantidadPendiente"].ToString(),
                    StockTotal = xIdr["StockTotal"].ToString()
                };
                //adicionando cada objeto a la lista
                this.xListaDinamico.Add(obj);
            }
            xObjCon.Desconectar();
            return xListaDinamico;
        }

        private ExistenciaEN BuscarObjeto(string pScript)
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

        private DataTable ObtenerTabla(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            DataTable iTabla = xObjCon.ObtenerTablaRegistro();
            xObjCon.Desconectar();
            return iTabla;
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarExistencia(ExistenciaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(ExistenciaEN.ClaExi, pObj.ClaveExistencia);
            xIns.AsignarParametro(ExistenciaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(ExistenciaEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(ExistenciaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(ExistenciaEN.DesExi, pObj.DescripcionExistencia);
            xIns.AsignarParametro(ExistenciaEN.DesSecExi, pObj.DescripcionSecundariaExistencia);
            xIns.AsignarParametro(ExistenciaEN.DesCorExi, pObj.DescripcionCortaExistencia);
            xIns.AsignarParametro(ExistenciaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xIns.AsignarParametro(ExistenciaEN.CCodUbi, pObj.CCodigoUbicacion);
            xIns.AsignarParametro(ExistenciaEN.CodTip, pObj.CodigoTipo);
            xIns.AsignarParametro(ExistenciaEN.CodGru, pObj.CodigoGrupo);
            xIns.AsignarParametro(ExistenciaEN.CClaExi, pObj.CClaseExistencia);
            xIns.AsignarParametro(ExistenciaEN.CSubClaExi, pObj.CSubClaseExistencia);
            xIns.AsignarParametro(ExistenciaEN.CEsPro, pObj.CEsProduccion);
            xIns.AsignarParametro(ExistenciaEN.ConExi, pObj.ContableExistencia);
            xIns.AsignarParametro(ExistenciaEN.CodAre, pObj.CodigoArea);
            xIns.AsignarParametro(ExistenciaEN.CCenCto, pObj.CCentroCosto);
            //xIns.AsignarParametro(ExistenciaEN.ConExi, pObj.ContableExistencia);
            xIns.AsignarParametro(ExistenciaEN.AmbExi, pObj.AmbienteExistencia);
            xIns.AsignarParametro(ExistenciaEN.CodMar, pObj.CodigoMarca);
            xIns.AsignarParametro(ExistenciaEN.ModExi, pObj.ModeloExistencia);
            xIns.AsignarParametro(ExistenciaEN.SerExi, pObj.SerieExistencia);
            xIns.AsignarParametro(ExistenciaEN.MedExi, pObj.MedidasExistencia);
            xIns.AsignarParametro(ExistenciaEN.CodCol, pObj.CodigoColor);
            xIns.AsignarParametro(ExistenciaEN.StoMinExi, pObj.StockMinimoExistencia.ToString());
            xIns.AsignarParametro(ExistenciaEN.StoAleExi, pObj.StockAlertaExistencia.ToString());
            xIns.AsignarParametro(ExistenciaEN.StoTomExi, pObj.StockTomaExistencia.ToString());
            xIns.AsignarParametro(ExistenciaEN.StoIniExi, pObj.StockInicialExistencia.ToString());
            xIns.AsignarParametro(ExistenciaEN.StoActExi, pObj.StockActualExistencia.ToString());
            xIns.AsignarParametro(ExistenciaEN.PreIniExi, pObj.PrecioInicialExistencia.ToString());
            xIns.AsignarParametro(ExistenciaEN.PreProExi, pObj.PrecioPromedioExistencia.ToString());
            xIns.AsignarParametro(ExistenciaEN.PesExi, pObj.PesoExistencia.ToString());
            xIns.AsignarParametro(ExistenciaEN.CodCat, pObj.CodigoCatalogo);
            xIns.AsignarParametro(ExistenciaEN.FotExi, pObj.FotoExistencia);
            xIns.AsignarParametro(ExistenciaEN.FecVctExi, pObj.FechaVctoExistencia);
            xIns.AsignarParametro(ExistenciaEN.LotProExi, pObj.LoteProduccionExistencia);
            xIns.AsignarParametro(ExistenciaEN.CEsLot, pObj.CEsLote);
            xIns.AsignarParametro(ExistenciaEN.CEsUndCon, pObj.CEsUnidadConvertida);
            xIns.AsignarParametro(ExistenciaEN.FacCon, pObj.FactorConversion.ToString());
            xIns.AsignarParametro(ExistenciaEN.UniXEmp, pObj.UnidadesPorEmpaque.ToString());
            xIns.AsignarParametro(ExistenciaEN.CEstExi, pObj.CEstadoExistencia);
            xIns.AsignarParametro(ExistenciaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ExistenciaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(ExistenciaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ExistenciaEN.FecMod, "FECHAHORA");
            xIns.AsignarParametro(ExistenciaEN.CAfeIgv, pObj.CAfectoIgv);
            xIns.AsignarParametro(ExistenciaEN.PreUltCom, pObj.PrecioUltimaCompra.ToString());
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarExistencia(List<ExistenciaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(ExistenciaEN.ClaExi, xExi.ClaveExistencia);
                xIns.AsignarParametro(ExistenciaEN.CodEmp, xExi.CodigoEmpresa);
                xIns.AsignarParametro(ExistenciaEN.CodAlm, xExi.CodigoAlmacen);
                xIns.AsignarParametro(ExistenciaEN.CodExi, xExi.CodigoExistencia);
                xIns.AsignarParametro(ExistenciaEN.DesExi, xExi.DescripcionExistencia);
                xIns.AsignarParametro(ExistenciaEN.DesSecExi, xExi.DescripcionSecundariaExistencia);
                xIns.AsignarParametro(ExistenciaEN.DesCorExi, xExi.DescripcionCortaExistencia);
                xIns.AsignarParametro(ExistenciaEN.CodUniMed, xExi.CodigoUnidadMedida);
                xIns.AsignarParametro(ExistenciaEN.CCodUbi, xExi.CCodigoUbicacion);
                xIns.AsignarParametro(ExistenciaEN.CodTip, xExi.CodigoTipo);
                xIns.AsignarParametro(ExistenciaEN.CodGru, xExi.CodigoGrupo);
                xIns.AsignarParametro(ExistenciaEN.CClaExi, xExi.CClaseExistencia);
                xIns.AsignarParametro(ExistenciaEN.CSubClaExi, xExi.CSubClaseExistencia);
                xIns.AsignarParametro(ExistenciaEN.CEsPro, xExi.CEsProduccion);
                xIns.AsignarParametro(ExistenciaEN.ConExi, xExi.ContableExistencia);
                xIns.AsignarParametro(ExistenciaEN.CodAre, xExi.CodigoArea);
                xIns.AsignarParametro(ExistenciaEN.CCenCto, xExi.CCentroCosto);
                xIns.AsignarParametro(ExistenciaEN.AmbExi, xExi.AmbienteExistencia);
                xIns.AsignarParametro(ExistenciaEN.CodMar, xExi.CodigoMarca);
                xIns.AsignarParametro(ExistenciaEN.ModExi, xExi.ModeloExistencia);
                xIns.AsignarParametro(ExistenciaEN.SerExi, xExi.SerieExistencia);
                xIns.AsignarParametro(ExistenciaEN.MedExi, xExi.MedidasExistencia);
                xIns.AsignarParametro(ExistenciaEN.CodCol, xExi.CodigoColor);
                xIns.AsignarParametro(ExistenciaEN.StoMinExi, xExi.StockMinimoExistencia.ToString());
                xIns.AsignarParametro(ExistenciaEN.StoAleExi, xExi.StockAlertaExistencia.ToString());
                xIns.AsignarParametro(ExistenciaEN.StoTomExi, xExi.StockTomaExistencia.ToString());
                xIns.AsignarParametro(ExistenciaEN.StoIniExi, xExi.StockInicialExistencia.ToString());
                xIns.AsignarParametro(ExistenciaEN.StoActExi, xExi.StockActualExistencia.ToString());
                xIns.AsignarParametro(ExistenciaEN.PreIniExi, xExi.PrecioInicialExistencia.ToString());
                xIns.AsignarParametro(ExistenciaEN.PreProExi, xExi.PrecioPromedioExistencia.ToString());
                xIns.AsignarParametro(ExistenciaEN.PesExi, xExi.PesoExistencia.ToString());
                xIns.AsignarParametro(ExistenciaEN.CodCat, xExi.CodigoCatalogo);
                xIns.AsignarParametro(ExistenciaEN.FotExi, xExi.FotoExistencia);
                xIns.AsignarParametro(ExistenciaEN.FecVctExi, xExi.FechaVctoExistencia);
                xIns.AsignarParametro(ExistenciaEN.LotProExi, xExi.LoteProduccionExistencia);
                xIns.AsignarParametro(ExistenciaEN.CEsLot, xExi.CEsLote);
                xIns.AsignarParametro(ExistenciaEN.CEsUndCon, xExi.CEsUnidadConvertida);
                xIns.AsignarParametro(ExistenciaEN.FacCon, xExi.FactorConversion.ToString());
                xIns.AsignarParametro(ExistenciaEN.UniXEmp, xExi.UnidadesPorEmpaque.ToString());
                xIns.AsignarParametro(ExistenciaEN.CEstExi, xExi.CEstadoExistencia);
                xIns.AsignarParametro(ExistenciaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ExistenciaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(ExistenciaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ExistenciaEN.FecMod, "FECHAHORA");
                xIns.AsignarParametro(ExistenciaEN.CAfeIgv, xExi.CAfectoIgv);
                xIns.AsignarParametro(ExistenciaEN.PreUltCom, xExi.PrecioUltimaCompra.ToString());
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarExistencia(ExistenciaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(ExistenciaEN.DesExi, pObj.DescripcionExistencia);
            xUpd.AsignarParametro(ExistenciaEN.DesSecExi, pObj.DescripcionSecundariaExistencia);
            xUpd.AsignarParametro(ExistenciaEN.DesCorExi, pObj.DescripcionCortaExistencia);
            xUpd.AsignarParametro(ExistenciaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xUpd.AsignarParametro(ExistenciaEN.CCodUbi, pObj.CCodigoUbicacion);
            xUpd.AsignarParametro(ExistenciaEN.CodTip, pObj.CodigoTipo);
            xUpd.AsignarParametro(ExistenciaEN.CodGru, pObj.CodigoGrupo);
            xUpd.AsignarParametro(ExistenciaEN.CClaExi, pObj.CClaseExistencia);
            xUpd.AsignarParametro(ExistenciaEN.CSubClaExi, pObj.CSubClaseExistencia);
            xUpd.AsignarParametro(ExistenciaEN.CEsPro, pObj.CEsProduccion);
            xUpd.AsignarParametro(ExistenciaEN.ConExi, pObj.ContableExistencia);
            xUpd.AsignarParametro(ExistenciaEN.CodAre, pObj.CodigoArea);
            xUpd.AsignarParametro(ExistenciaEN.CCenCto, pObj.CCentroCosto);
            xUpd.AsignarParametro(ExistenciaEN.AmbExi, pObj.AmbienteExistencia);
            xUpd.AsignarParametro(ExistenciaEN.CodMar, pObj.CodigoMarca);
            xUpd.AsignarParametro(ExistenciaEN.ModExi, pObj.ModeloExistencia);
            xUpd.AsignarParametro(ExistenciaEN.SerExi, pObj.SerieExistencia);
            xUpd.AsignarParametro(ExistenciaEN.MedExi, pObj.MedidasExistencia);
            xUpd.AsignarParametro(ExistenciaEN.CodCol, pObj.CodigoColor);
            xUpd.AsignarParametro(ExistenciaEN.StoMinExi, pObj.StockMinimoExistencia.ToString());
            xUpd.AsignarParametro(ExistenciaEN.StoAleExi, pObj.StockAlertaExistencia.ToString());
            xUpd.AsignarParametro(ExistenciaEN.StoTomExi, pObj.StockTomaExistencia.ToString());
            xUpd.AsignarParametro(ExistenciaEN.StoIniExi, pObj.StockInicialExistencia.ToString());
            xUpd.AsignarParametro(ExistenciaEN.StoActExi, pObj.StockActualExistencia.ToString());
            xUpd.AsignarParametro(ExistenciaEN.PreIniExi, pObj.PrecioInicialExistencia.ToString());
            xUpd.AsignarParametro(ExistenciaEN.PreProExi, pObj.PrecioPromedioExistencia.ToString());
            xUpd.AsignarParametro(ExistenciaEN.PesExi, pObj.PesoExistencia.ToString());
            xUpd.AsignarParametro(ExistenciaEN.CodCat, pObj.CodigoCatalogo);
            xUpd.AsignarParametro(ExistenciaEN.FotExi, pObj.FotoExistencia);
            xUpd.AsignarParametro(ExistenciaEN.FecVctExi, pObj.FechaVctoExistencia);
            xUpd.AsignarParametro(ExistenciaEN.LotProExi, pObj.LoteProduccionExistencia);
            xUpd.AsignarParametro(ExistenciaEN.CEsLot, pObj.CEsLote);
            xUpd.AsignarParametro(ExistenciaEN.CEsUndCon, pObj.CEsUnidadConvertida);
            xUpd.AsignarParametro(ExistenciaEN.FacCon, pObj.FactorConversion.ToString());
            xUpd.AsignarParametro(ExistenciaEN.UniXEmp, pObj.UnidadesPorEmpaque.ToString());
            xUpd.AsignarParametro(ExistenciaEN.CEstExi, pObj.CEstadoExistencia);
            xUpd.AsignarParametro(ExistenciaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ExistenciaEN.FecMod, "FECHAHORA");
            xUpd.AsignarParametro(ExistenciaEN.CAfeIgv, pObj.CAfectoIgv);
            xUpd.AsignarParametro(ExistenciaEN.PreUltCom, pObj.PrecioUltimaCompra.ToString());
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.ClaExi, SqlSelect.Operador.Igual, pObj.ClaveExistencia);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarExistencia(List<ExistenciaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(ExistenciaEN.DesExi, xExi.DescripcionExistencia);
                xUpd.AsignarParametro(ExistenciaEN.CodUniMed, xExi.CodigoUnidadMedida);
                xUpd.AsignarParametro(ExistenciaEN.CCodUbi, xExi.CCodigoUbicacion);
                xUpd.AsignarParametro(ExistenciaEN.CodTip, xExi.CodigoTipo);
                xUpd.AsignarParametro(ExistenciaEN.CodGru, xExi.CodigoGrupo);
                xUpd.AsignarParametro(ExistenciaEN.CEsPro, xExi.CEsProduccion);
                xUpd.AsignarParametro(ExistenciaEN.ConExi, xExi.ContableExistencia);
                xUpd.AsignarParametro(ExistenciaEN.CodAre, xExi.CodigoArea);
                xUpd.AsignarParametro(ExistenciaEN.CCenCto, xExi.CCentroCosto);
                xUpd.AsignarParametro(ExistenciaEN.AmbExi, xExi.AmbienteExistencia);
                xUpd.AsignarParametro(ExistenciaEN.CodMar, xExi.CodigoMarca);
                xUpd.AsignarParametro(ExistenciaEN.ModExi, xExi.ModeloExistencia);
                xUpd.AsignarParametro(ExistenciaEN.SerExi, xExi.SerieExistencia);
                xUpd.AsignarParametro(ExistenciaEN.MedExi, xExi.MedidasExistencia);
                xUpd.AsignarParametro(ExistenciaEN.CodCol, xExi.CodigoColor);
                xUpd.AsignarParametro(ExistenciaEN.StoMinExi, xExi.StockMinimoExistencia.ToString());
                xUpd.AsignarParametro(ExistenciaEN.StoTomExi, xExi.StockTomaExistencia.ToString());
                xUpd.AsignarParametro(ExistenciaEN.StoIniExi, xExi.StockInicialExistencia.ToString());
                xUpd.AsignarParametro(ExistenciaEN.StoActExi, xExi.StockActualExistencia.ToString());
                xUpd.AsignarParametro(ExistenciaEN.PreIniExi, xExi.PrecioInicialExistencia.ToString());
                xUpd.AsignarParametro(ExistenciaEN.PreProExi, xExi.PrecioPromedioExistencia.ToString());
                xUpd.AsignarParametro(ExistenciaEN.CodCat, xExi.CodigoCatalogo);
                xUpd.AsignarParametro(ExistenciaEN.FotExi, xExi.FotoExistencia);
                xUpd.AsignarParametro(ExistenciaEN.FecVctExi, xExi.FechaVctoExistencia);
                xUpd.AsignarParametro(ExistenciaEN.LotProExi, xExi.LoteProduccionExistencia);
                xUpd.AsignarParametro(ExistenciaEN.CEsLot, xExi.CEsLote);
                xUpd.AsignarParametro(ExistenciaEN.CEsUndCon, xExi.CEsUnidadConvertida);
                xUpd.AsignarParametro(ExistenciaEN.FacCon, xExi.FactorConversion.ToString());
                xUpd.AsignarParametro(ExistenciaEN.UniXEmp, xExi.UnidadesPorEmpaque.ToString());
                xUpd.AsignarParametro(ExistenciaEN.CEstExi, xExi.CEstadoExistencia);
                xUpd.AsignarParametro(ExistenciaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(ExistenciaEN.FecMod, "FECHAHORA");
                xUpd.AsignarParametro(ExistenciaEN.CAfeIgv, xExi.CAfectoIgv);
                xUpd.AsignarParametro(ExistenciaEN.PreUltCom, xExi.PrecioUltimaCompra.ToString());
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.ClaExi, SqlSelect.Operador.Igual, xExi.ClaveExistencia);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }
        public void ModificarExistenciaPorRecalculo(List<ExistenciaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.IniciaTransaccion();

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(ExistenciaEN.StoActExi, xExi.StockActualExistencia.ToString());
                xUpd.AsignarParametro(ExistenciaEN.PreProExi, xExi.PrecioPromedioExistencia.ToString());
                xUpd.AsignarParametro(ExistenciaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(ExistenciaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.ClaExi, SqlSelect.Operador.Igual, xExi.ClaveExistencia);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTextoTransaccion(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            xObjCon.CerrarTransaccion();
            xObjCon.Desconectar();
        }

        public void EliminarExistencia(ExistenciaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.ClaExi, SqlSelect.Operador.Igual, pObj.ClaveExistencia);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarExistencia(List<ExistenciaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ExistenciaEN xExi in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.ClaExi, SqlSelect.Operador.Igual, xExi.ClaveExistencia);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public List<ExistenciaEN> ListarExistencias(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public ExistenciaEN BuscarExistenciaXClave(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.ClaExi, SqlSelect.Operador.Igual, pObj.ClaveExistencia);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<ExistenciaEN> ListarExistenciasDeAlmacen(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public DataTable ListarCodigosExistenciaDeAlmacenUsadosEnMovimientos(ExistenciaEN pObj)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select CodigoExistencia From VsMovimientoDeta";
            iScript += " Group By CodigoAlmacen,CodigoEmpresa,CodigoExistencia";
            iScript += " Having CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CodigoAlmacen='" + pObj.CodigoAlmacen + "'";
            iScript += " And CodigoExistencia in(Select CodigoExistencia from VsExistencia where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And CodigoAlmacen='" + pObj.CodigoAlmacen + "'" + " )";

            //resultado
            return this.ObtenerTabla(iScript);
        }

        public List<ExistenciaEN> ListarExistenciasActivasDeAlmacen(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CEstExi, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ExistenciaEN> ListarExistenciasParaExistenciasGeneralesPorAlmacen(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            if (pObj.CodigoTipo != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodTip, SqlSelect.Operador.Igual, pObj.CodigoTipo);
            }
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, ExistenciaEN.CodExi, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CEstExi, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<List<ExistenciaEN>> ListarExistenciasParaExistenciasGeneralesConsolidado(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            if (pObj.CodigoTipo != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodTip, SqlSelect.Operador.Igual, pObj.CodigoTipo);
            }
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, ExistenciaEN.CodExi, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CEstExi, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<ExistenciaEN>> iLisRes = new List<List<ExistenciaEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                ExistenciaEN iExiEN = new ExistenciaEN();
                iExiEN = this.Objeto(xIdr);

                //preguntamos si es una existencia diferente
                if (iExiEN.CodigoExistencia != iExistencia)
                {
                    List<ExistenciaEN> iLisExi = new List<ExistenciaEN>();
                    iLisExi.Add(iExiEN);
                    iLisRes.Add(iLisExi);
                    iIndice++;
                    iExistencia = iExiEN.CodigoExistencia;
                }
                else
                {
                    iLisRes[iIndice].Add(iExiEN);
                }
            }

            xObjCon.Desconectar();
            return iLisRes;
        }

        public List<ExistenciaEN> ListarExistenciasParaExistenciasGeneralesResumen(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (pObj.CodigoAlmacen != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            }
            else
            {
                if (Universal.gStrPermisosAlmacen != string.Empty)
                {
                    xSel.CondicionINx(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, Universal.gStrPermisosAlmacen);
                }
            }
            if (pObj.CodigoTipo != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodTip, SqlSelect.Operador.Igual, pObj.CodigoTipo);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CEstExi, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ExistenciaEN> ListarExistenciasProductosTerminadosActivosDeAlmacen(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodTip, SqlSelect.Operador.Igual, "PT");//productos terminados
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CEstExi, SqlSelect.Operador.Igual, "1");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ExistenciaEN> ListarExistenciasXEmpresaYAlmacenYTipo(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CSubClaExi, SqlSelect.Operador.Igual, pObj.CSubClaseExistencia);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ExistenciaEN> ListarExistenciasXEmpresaYAlmacen(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ExistenciaEN> ListarExistenciasActivasDeAlmacenYNoProduccion(ExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ExistenciaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CEsPro, SqlSelect.Operador.Igual, "0");//no es produccion
            xSel.CondicionCV(SqlSelect.Reservada.Y, ExistenciaEN.CEstExi, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public void ModificarStockYPrecioDeExistenciaXCodigo(ExistenciaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += " Update Existencia Set StockActualExistencia = " + pObj.StockActualExistencia + ",";
            iScript += " PrecioPromedioExistencia = " + pObj.PrecioPromedioExistencia + ",";
            iScript += " PrecioUltimaCompra = " + pObj.PrecioUltimaCompra + ",";
            iScript += " FechaUltimaCompra = '" + pObj.FechaUltimaCompra + "'";
            iScript += " Where CodigoExistencia = '" + pObj.CodigoExistencia + "'";

            //resultado
            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<dynamic> ObtenerReporteExistenciaStockFisicoProgramado(ExistenciaEN pObj)
        {
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += " select e.CodigoExistencia,";
            iScript += " e.DescripcionExistencia,";
            iScript += " e.NombreUnidadMedida,";
            iScript += " e.StockActualExistencia,";
            iScript += " s.CantidadSolicitudPedidoDeta,";
            iScript += " m.CantidadPendiente,";
            iScript += " e.StockActualExistencia + s.CantidadSolicitudPedidoDeta + m.CantidadPendiente as [StockTotal]";
            iScript += " from vsExistencia e";
            iScript += " inner";
            iScript += " join vsSolicitudPedidoDeta s";
            iScript += " on e.CodigoExistencia = s.CodigoExistencia";
            iScript += " inner";
            iScript += " join vsMovimientoOCDeta m";
            iScript += " on e.CodigoExistencia = m.CodigoExistencia";
            iScript += " Where e.CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            if (pObj.CodigoAlmacen != string.Empty)
            {
                iScript += " And e.CodigoAlmacen in('" + pObj.CodigoAlmacen + "')";
            }
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                iScript += " And e.CodigoExistencia between '" + pObj.Adicionales.Desde1 + "' and '" + pObj.Adicionales.Hasta1 + "' ";
            }

            return this.ListarObjetosDinamicos(iScript);
        }

        #endregion

    }
}
