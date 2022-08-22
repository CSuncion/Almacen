using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Datos.Config;
using Comun;
using Entidades.Adicionales;

namespace Datos
{
    public class RetiquetadoProTerAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<RetiquetadoProTerEN> eLista = new List<RetiquetadoProTerEN>();
        private RetiquetadoProTerEN eObj = new RetiquetadoProTerEN();
        private string eTabla = "RetiquetadoProTer";
        private string eVista = "VsRetiquetadoProTer";

        #endregion

        #region Metodos privados

        private RetiquetadoProTerEN Objeto(IDataReader iDr)
        {
            RetiquetadoProTerEN xObjEnc = new RetiquetadoProTerEN();
            xObjEnc.ClaveRetiquetadoProTer = iDr[RetiquetadoProTerEN.ClaRetProTer].ToString();
            xObjEnc.ClaveRetiquetado = iDr[RetiquetadoProTerEN.ClaRet].ToString();
            xObjEnc.CodigoEmpresa = iDr[RetiquetadoProTerEN.CodEmp].ToString();
            xObjEnc.CorrelativoRetiquetado = iDr[RetiquetadoProTerEN.CorRet].ToString();
            xObjEnc.FechaRetiquetado = Fecha.ObtenerDiaMesAno(iDr[RetiquetadoProTerEN.FecRet].ToString());
            xObjEnc.CodigoExistenciaRE = iDr[RetiquetadoProTerEN.CodExiRE].ToString();
            xObjEnc.CorrelativoRetiquetadoProTer = iDr[RetiquetadoProTerEN.CorRetProTer].ToString();
            xObjEnc.ClaveProduccionProTer = iDr[RetiquetadoProTerEN.ClaProProTer].ToString();
            xObjEnc.ClaveEncajado = iDr[RetiquetadoProTerEN.ClaEnc].ToString();
            xObjEnc.CorrelativoEncajado = iDr[RetiquetadoProTerEN.CorEnc].ToString();
            xObjEnc.FechaEncajado = Fecha.ObtenerDiaMesAno(iDr[RetiquetadoProTerEN.FecEnc].ToString());
            xObjEnc.CodigoAlmacen = iDr[RetiquetadoProTerEN.CodAlm].ToString();
            xObjEnc.CodigoExistencia = iDr[RetiquetadoProTerEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[RetiquetadoProTerEN.DesExi].ToString();
            xObjEnc.CostoTotalProducto = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CosTotPro].ToString());
            xObjEnc.DetalleCantidadesSemiproducto = iDr[RetiquetadoProTerEN.DetCanSemPro].ToString();
            xObjEnc.CantidadRetiquetadoProTer = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CanRetProTer].ToString());
            xObjEnc.DetalleCantidadesLote = iDr[RetiquetadoProTerEN.DetCanLot].ToString();
            xObjEnc.CostoUnidadSemiProducto = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CosUniSemPro].ToString());
            xObjEnc.CostoCIFFijo = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CosCifFij].ToString());
            xObjEnc.CostoManoObra = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CosManObr].ToString());
            xObjEnc.CostoCIFVariable = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CosCifVar].ToString());
            xObjEnc.CostoUnidadEmpaquetado = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CosUniEmp].ToString());
            xObjEnc.CostoEmpaquetadoPrincipal = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CosEmpPri].ToString());
            xObjEnc.CantidadUnidadesProTer = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CanUniProTer].ToString());
            xObjEnc.CantidadUnidadesRealEncajado = Convert.ToDecimal(iDr[RetiquetadoProTerEN.CanUniReaEnc].ToString());
            xObjEnc.CEstadoRetiquetadoProTer = iDr[RetiquetadoProTerEN.CEstRetProTer].ToString();
            xObjEnc.NEstadoRetiquetadoProTer = iDr[RetiquetadoProTerEN.NEstRetProTer].ToString();
            xObjEnc.UsuarioAgrega = iDr[RetiquetadoProTerEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RetiquetadoProTerEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[RetiquetadoProTerEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RetiquetadoProTerEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRetiquetadoProTer;
            return xObjEnc;
        }

        private List<RetiquetadoProTerEN> ListarObjetos(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.eLista.Add(this.Objeto(xIdr));
            }
            eObjCon.Desconectar();
            return eLista;
        }

        private RetiquetadoProTerEN BuscarObjeto(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.eObj = this.Objeto(xIdr);
            }
            eObjCon.Desconectar();
            return eObj;
        }

        private bool ExisteObjeto(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            bool xResultado = false;
            while (xIdr.Read())
            {
                string xTxt = xIdr["Busqueda"].ToString();
                if (xTxt != string.Empty)
                {
                    xResultado = true;
                }
            }
            eObjCon.Desconectar();
            return xResultado;
        }

        private string ObtenerValor(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            eObjCon.ComandoTexto(pScript);
            string iValor = eObjCon.ObtenerValor();
            eObjCon.Desconectar();
            return iValor;
        }

        #endregion

        #region Metodos publicos

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion2, SqlSelect.Operador.Igual, pValorCondicion2);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion2, SqlSelect.Operador.Igual, pValorCondicion2);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AdicionarRetiquetadoProTer(List<RetiquetadoProTerEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (RetiquetadoProTerEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(RetiquetadoProTerEN.ClaRetProTer, xObj.ClaveRetiquetadoProTer);
                xIns.AsignarParametro(RetiquetadoProTerEN.ClaRet, xObj.ClaveRetiquetado);
                xIns.AsignarParametro(RetiquetadoProTerEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(RetiquetadoProTerEN.CorRet, xObj.CorrelativoRetiquetado);
                xIns.AsignarParametro(RetiquetadoProTerEN.CorRetProTer, xObj.CorrelativoRetiquetadoProTer);
                xIns.AsignarParametro(RetiquetadoProTerEN.ClaProProTer, xObj.ClaveProduccionProTer);
                xIns.AsignarParametro(RetiquetadoProTerEN.CanRetProTer, xObj.CantidadRetiquetadoProTer.ToString());
                xIns.AsignarParametro(RetiquetadoProTerEN.DetCanLot, xObj.DetalleCantidadesLote);
                xIns.AsignarParametro(RetiquetadoProTerEN.CEstRetProTer, xObj.CEstadoRetiquetadoProTer);
                xIns.AsignarParametro(RetiquetadoProTerEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RetiquetadoProTerEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(RetiquetadoProTerEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RetiquetadoProTerEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarRetiquetadoProTer(List<RetiquetadoProTerEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (RetiquetadoProTerEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(RetiquetadoProTerEN.ClaRetProTer, xObj.ClaveRetiquetadoProTer);
                xUpd.AsignarParametro(RetiquetadoProTerEN.ClaRet, xObj.ClaveRetiquetado);
                xUpd.AsignarParametro(RetiquetadoProTerEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(RetiquetadoProTerEN.CorRet, xObj.CorrelativoRetiquetado);
                xUpd.AsignarParametro(RetiquetadoProTerEN.CorRetProTer, xObj.CorrelativoRetiquetadoProTer);
                xUpd.AsignarParametro(RetiquetadoProTerEN.ClaProProTer, xObj.ClaveProduccionProTer);
                xUpd.AsignarParametro(RetiquetadoProTerEN.CanRetProTer, xObj.CantidadRetiquetadoProTer.ToString());
                xUpd.AsignarParametro(RetiquetadoProTerEN.DetCanLot, xObj.DetalleCantidadesLote);
                xUpd.AsignarParametro(RetiquetadoProTerEN.CEstRetProTer, xObj.CEstadoRetiquetadoProTer);
                xUpd.AsignarParametro(RetiquetadoProTerEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(RetiquetadoProTerEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoProTerEN.ClaRetProTer, SqlSelect.Operador.Igual, xObj.ClaveRetiquetadoProTer);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarRetiquetadoProTer(List<RetiquetadoProTerEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (RetiquetadoProTerEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoProTerEN.ClaRetProTer, SqlSelect.Operador.Igual, xObj.ClaveRetiquetadoProTer);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarRetiquetadoProTerXClaveRetiquetado(RetiquetadoProTerEN pObj)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.eTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoProTerEN.ClaRet, SqlSelect.Operador.Igual, pObj.ClaveRetiquetado);
            xDel.CondicionDelete(xSel.ObtenerScript());

            eObjCon.ComandoTexto(xDel.ObtenerScript());
            eObjCon.EjecutarSinResultado();
            eObjCon.Desconectar();
        }

        public List<RetiquetadoProTerEN> ListarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public RetiquetadoProTerEN BuscarRetiquetadoProTerXClave(RetiquetadoProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoProTerEN.ClaRetProTer, SqlSelect.Operador.Igual, pObj.ClaveRetiquetadoProTer);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<RetiquetadoProTerEN> ListarRetiquetadoProTerXClaveRetiquetado(RetiquetadoProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoProTerEN.ClaRet, SqlSelect.Operador.Igual, pObj.ClaveRetiquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RetiquetadoProTerEN> ListarRetiquetadoProTerXPeriodoRetiquetado(RetiquetadoProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RetiquetadoProTerEN.PerRet, SqlSelect.Operador.Igual, pObj.PeriodoRetiquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RetiquetadoProTerEN> ListarRetiquetadoProTerParaReporteCostoLoteEtapaRetiquetado(RetiquetadoProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, RetiquetadoProTerEN.FecRet, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                   , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            if (pObj.CodigoExistenciaRE != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, RetiquetadoProTerEN.CodExiRE, SqlSelect.Operador.Igual, pObj.CodigoExistenciaRE);
            }
            xSel.Ordenar(RetiquetadoProTerEN.FecRet + "," + RetiquetadoProTerEN.FecEnc, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RetiquetadoProTerEN> ListarRetiquetadoProTerDeCorrelativosProduccionCabe(List<ProduccionDetaEN> pLista)
        {
            //si la lista esta vacia,retorna lista vacia
            if (pLista.Count == 0) { return eLista; }

            //script manual
            string iScript = string.Empty;

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in pLista)
            {
                //armando la primera consulta
                iScript += "Select * From VsRetiquetadoProTer";
                iScript += " Where DetalleCantidadesLote like '%" + xProDet.CorrelativoProduccionCabe + "%'";
                iScript += " Union ";
            }

            //quitar el ultimo union
            iScript = Cadena.CortarCadena(iScript, iScript.Length - 6, Cadena.Direccion.Izquierda);

            //ordenar
            iScript += " Order by ClaveRetiquetadoProTer";

            //resultado
            return this.ListarObjetos(iScript);
        }


        #endregion


    }
}
