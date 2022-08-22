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
    public class RetiquetadoAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<RetiquetadoEN> eLista = new List<RetiquetadoEN>();
        private RetiquetadoEN eObj = new RetiquetadoEN();
        private string eTabla = "Retiquetado";
        private string eVista = "VsRetiquetado";

        #endregion

        #region Metodos privados

        private RetiquetadoEN Objeto(IDataReader iDr)
        {
            RetiquetadoEN xObjEnc = new RetiquetadoEN();
            xObjEnc.ClaveRetiquetado = iDr[RetiquetadoEN.ClaRet].ToString();
            xObjEnc.CodigoEmpresa = iDr[RetiquetadoEN.CodEmp].ToString();
            xObjEnc.CorrelativoRetiquetado = iDr[RetiquetadoEN.CorRet].ToString();
            xObjEnc.FechaRetiquetado = Fecha.ObtenerDiaMesAno(iDr[RetiquetadoEN.FecRet].ToString());
            xObjEnc.PeriodoRetiquetado = iDr[RetiquetadoEN.PerRet].ToString();
            xObjEnc.CodigoAlmacenPT = iDr[RetiquetadoEN.CodAlmPT].ToString();
            xObjEnc.DescripcionAlmacenPT = iDr[RetiquetadoEN.DesAlmPT].ToString();
            xObjEnc.CodigoExistenciaPT = iDr[RetiquetadoEN.CodExiPT].ToString();
            xObjEnc.DescripcionExistenciaPT = iDr[RetiquetadoEN.DesExiPT].ToString();
            xObjEnc.CodigoAlmacenRE = iDr[RetiquetadoEN.CodAlmRE].ToString();
            xObjEnc.DescripcionAlmacenRE = iDr[RetiquetadoEN.DesAlmRE].ToString();
            xObjEnc.CodigoExistenciaRE = iDr[RetiquetadoEN.CodExiRE].ToString();
            xObjEnc.DescripcionExistenciaRE = iDr[RetiquetadoEN.DesExiRE].ToString();
            xObjEnc.UnidadesPorEmpaqueRE = Convert.ToDecimal(iDr[RetiquetadoEN.UniPorEmpRE].ToString());
            xObjEnc.CantidadUnidadesRetiquetado = Convert.ToDecimal(iDr[RetiquetadoEN.CanUniRet].ToString());
            xObjEnc.CantidadCajasRetiquetado = Convert.ToDecimal(iDr[RetiquetadoEN.CanCajRet].ToString());
            xObjEnc.DetalleRetiquetadoProTer = iDr[RetiquetadoEN.DetRetProTer].ToString();
            xObjEnc.ClaveSalidaUnidadesEmpacar = iDr[RetiquetadoEN.ClaSalUniEmp].ToString();
            xObjEnc.ClaveSalidaFaseEmpaquetado = iDr[RetiquetadoEN.ClaSalFasEmp].ToString();
            xObjEnc.ClaveIngresoProductoTerminado = iDr[RetiquetadoEN.ClaIngProTer].ToString();
            xObjEnc.PorcentajeUnidadesRango = Convert.ToDecimal(iDr[RetiquetadoEN.PorUniRan].ToString());
            xObjEnc.CantidadUnidadesRango = Convert.ToDecimal(iDr[RetiquetadoEN.CanUniRan].ToString());
            xObjEnc.PorcentajeCajasRango = Convert.ToDecimal(iDr[RetiquetadoEN.PorCajRan].ToString());
            xObjEnc.CantidadCajasRango = Convert.ToDecimal(iDr[RetiquetadoEN.CanCajRan].ToString());
            xObjEnc.CostoEmpaquetadoPrincipal = Convert.ToDecimal(iDr[RetiquetadoEN.CosEmpPri].ToString());
            xObjEnc.CostoEmpaquetadoAdicional = Convert.ToDecimal(iDr[RetiquetadoEN.CosEmpAdi].ToString());
            xObjEnc.CostoEmpaquetadoDevolucion = Convert.ToDecimal(iDr[RetiquetadoEN.CosEmpDev].ToString());
            xObjEnc.CostoEmpaquetadoTotal = Convert.ToDecimal(iDr[RetiquetadoEN.CosEmpTot].ToString());
            xObjEnc.CostoUnidadEmpaquetado = Convert.ToDecimal(iDr[RetiquetadoEN.CosUniEmp].ToString());
            xObjEnc.CostoUnidadEncajado = Convert.ToDecimal(iDr[RetiquetadoEN.CosUniEnc].ToString());
            xObjEnc.CostoInsumos = Convert.ToDecimal(iDr[RetiquetadoEN.CosIns].ToString());
            xObjEnc.CostoManoObra = Convert.ToDecimal(iDr[RetiquetadoEN.CosManObr].ToString());
            xObjEnc.CostoOtros = Convert.ToDecimal(iDr[RetiquetadoEN.CosOtr].ToString());
            xObjEnc.CostoTotalProducto = Convert.ToDecimal(iDr[RetiquetadoEN.CosTotPro].ToString());            
            xObjEnc.FactorProduccionRet = Convert.ToDecimal(iDr[RetiquetadoEN.FacProRet].ToString());
            xObjEnc.RatioProduccionRet = Convert.ToDecimal(iDr[RetiquetadoEN.RatProRet].ToString());
            xObjEnc.HorasHombre = Convert.ToDecimal(iDr[RetiquetadoEN.HorHom].ToString());
            xObjEnc.CostoTotalManoObra = Convert.ToDecimal(iDr[RetiquetadoEN.CosTotManObr].ToString());
            xObjEnc.FactorCIFFijo = Convert.ToDecimal(iDr[RetiquetadoEN.FacCIFFij].ToString());
            xObjEnc.CostoCIFFijo = Convert.ToDecimal(iDr[RetiquetadoEN.CosCIFFij].ToString());
            xObjEnc.FactorCIFVariable = Convert.ToDecimal(iDr[RetiquetadoEN.FacCIFVar].ToString());
            xObjEnc.CostoCIFVariable = Convert.ToDecimal(iDr[RetiquetadoEN.CosCIFVar].ToString());
            xObjEnc.CEstadoRetiquetado = iDr[RetiquetadoEN.CEstRet].ToString();
            xObjEnc.NEstadoRetiquetado = iDr[RetiquetadoEN.NEstRet].ToString();
            xObjEnc.UsuarioAgrega = iDr[RetiquetadoEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RetiquetadoEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[RetiquetadoEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RetiquetadoEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRetiquetado;
            return xObjEnc;
        }

        private List<RetiquetadoEN> ListarObjetos(string pScript)
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

        private RetiquetadoEN BuscarObjeto(string pScript)
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

        public void AdicionarRetiquetado(List<RetiquetadoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (RetiquetadoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(RetiquetadoEN.ClaRet, xObj.ClaveRetiquetado);
                xIns.AsignarParametro(RetiquetadoEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(RetiquetadoEN.CorRet, xObj.CorrelativoRetiquetado);
                xIns.AsignarParametro(RetiquetadoEN.FecRet, Fecha.ObtenerAnoMesDia(xObj.FechaRetiquetado));
                xIns.AsignarParametro(RetiquetadoEN.PerRet, xObj.PeriodoRetiquetado);
                xIns.AsignarParametro(RetiquetadoEN.CodAlmPT, xObj.CodigoAlmacenPT);
                xIns.AsignarParametro(RetiquetadoEN.CodExiPT, xObj.CodigoExistenciaPT);
                xIns.AsignarParametro(RetiquetadoEN.CodAlmRE, xObj.CodigoAlmacenRE);
                xIns.AsignarParametro(RetiquetadoEN.CodExiRE, xObj.CodigoExistenciaRE);
                xIns.AsignarParametro(RetiquetadoEN.CanUniRet, xObj.CantidadUnidadesRetiquetado.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CanCajRet, xObj.CantidadCajasRetiquetado.ToString());
                xIns.AsignarParametro(RetiquetadoEN.DetRetProTer, xObj.DetalleRetiquetadoProTer);
                xIns.AsignarParametro(RetiquetadoEN.ClaSalUniEmp, xObj.ClaveSalidaUnidadesEmpacar);
                xIns.AsignarParametro(RetiquetadoEN.ClaSalFasEmp, xObj.ClaveSalidaFaseEmpaquetado);
                xIns.AsignarParametro(RetiquetadoEN.ClaIngProTer, xObj.ClaveIngresoProductoTerminado);
                xIns.AsignarParametro(RetiquetadoEN.PorUniRan, xObj.PorcentajeUnidadesRango.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CanUniRan, xObj.CantidadUnidadesRango.ToString());
                xIns.AsignarParametro(RetiquetadoEN.PorCajRan, xObj.PorcentajeCajasRango.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CanCajRan, xObj.CantidadCajasRango.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosEmpPri, xObj.CostoEmpaquetadoPrincipal.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosEmpAdi, xObj.CostoEmpaquetadoAdicional.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosEmpDev, xObj.CostoEmpaquetadoDevolucion.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosEmpTot, xObj.CostoEmpaquetadoTotal.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosUniEmp, xObj.CostoUnidadEmpaquetado.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosUniEnc, xObj.CostoUnidadEncajado.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosIns, xObj.CostoInsumos.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosManObr, xObj.CostoManoObra.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosOtr, xObj.CostoOtros.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosTotPro, xObj.CostoTotalProducto.ToString());
                xIns.AsignarParametro(RetiquetadoEN.FacProRet, xObj.FactorProduccionRet.ToString());
                xIns.AsignarParametro(RetiquetadoEN.RatProRet, xObj.RatioProduccionRet.ToString());
                xIns.AsignarParametro(RetiquetadoEN.HorHom, xObj.HorasHombre.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosTotManObr, xObj.CostoTotalManoObra.ToString());
                xIns.AsignarParametro(RetiquetadoEN.FacCIFFij, xObj.FactorCIFFijo.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosCIFFij, xObj.CostoCIFFijo.ToString());
                xIns.AsignarParametro(RetiquetadoEN.FacCIFVar, xObj.FactorCIFVariable.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CosCIFVar, xObj.CostoCIFVariable.ToString());
                xIns.AsignarParametro(RetiquetadoEN.CEstRet, xObj.CEstadoRetiquetado);
                xIns.AsignarParametro(RetiquetadoEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RetiquetadoEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(RetiquetadoEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RetiquetadoEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarRetiquetado(List<RetiquetadoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (RetiquetadoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(RetiquetadoEN.ClaRet, xObj.ClaveRetiquetado);
                xUpd.AsignarParametro(RetiquetadoEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(RetiquetadoEN.CorRet, xObj.CorrelativoRetiquetado);
                xUpd.AsignarParametro(RetiquetadoEN.FecRet, Fecha.ObtenerAnoMesDia(xObj.FechaRetiquetado));
                xUpd.AsignarParametro(RetiquetadoEN.PerRet, xObj.PeriodoRetiquetado);
                xUpd.AsignarParametro(RetiquetadoEN.CodAlmPT, xObj.CodigoAlmacenPT);
                xUpd.AsignarParametro(RetiquetadoEN.CodExiPT, xObj.CodigoExistenciaPT);
                xUpd.AsignarParametro(RetiquetadoEN.CodAlmRE, xObj.CodigoAlmacenRE);
                xUpd.AsignarParametro(RetiquetadoEN.CodExiRE, xObj.CodigoExistenciaRE);
                xUpd.AsignarParametro(RetiquetadoEN.CanUniRet, xObj.CantidadUnidadesRetiquetado.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CanCajRet, xObj.CantidadCajasRetiquetado.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.DetRetProTer, xObj.DetalleRetiquetadoProTer);
                xUpd.AsignarParametro(RetiquetadoEN.ClaSalUniEmp, xObj.ClaveSalidaUnidadesEmpacar);
                xUpd.AsignarParametro(RetiquetadoEN.ClaSalFasEmp, xObj.ClaveSalidaFaseEmpaquetado);
                xUpd.AsignarParametro(RetiquetadoEN.ClaIngProTer, xObj.ClaveIngresoProductoTerminado);
                xUpd.AsignarParametro(RetiquetadoEN.PorUniRan, xObj.PorcentajeUnidadesRango.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CanUniRan, xObj.CantidadUnidadesRango.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.PorCajRan, xObj.PorcentajeCajasRango.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CanCajRan, xObj.CantidadCajasRango.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosEmpPri, xObj.CostoEmpaquetadoPrincipal.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosEmpAdi, xObj.CostoEmpaquetadoAdicional.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosEmpDev, xObj.CostoEmpaquetadoDevolucion.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosEmpTot, xObj.CostoEmpaquetadoTotal.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosUniEmp, xObj.CostoUnidadEmpaquetado.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosUniEnc, xObj.CostoUnidadEncajado.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosIns, xObj.CostoInsumos.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosManObr, xObj.CostoManoObra.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosOtr, xObj.CostoOtros.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosTotPro, xObj.CostoTotalProducto.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.FacProRet, xObj.FactorProduccionRet.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.RatProRet, xObj.RatioProduccionRet.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.HorHom, xObj.HorasHombre.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosTotManObr, xObj.CostoTotalManoObra.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.FacCIFFij, xObj.FactorCIFFijo.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosCIFFij, xObj.CostoCIFFijo.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.FacCIFVar, xObj.FactorCIFVariable.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CosCIFVar, xObj.CostoCIFVariable.ToString());
                xUpd.AsignarParametro(RetiquetadoEN.CEstRet, xObj.CEstadoRetiquetado);
                xUpd.AsignarParametro(RetiquetadoEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(RetiquetadoEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoEN.ClaRet, SqlSelect.Operador.Igual, xObj.ClaveRetiquetado);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarRetiquetado(List<RetiquetadoEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (RetiquetadoEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoEN.ClaRet, SqlSelect.Operador.Igual, xObj.ClaveRetiquetado);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<RetiquetadoEN> ListarRetiquetado(RetiquetadoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public RetiquetadoEN BuscarRetiquetadoXClave(RetiquetadoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoEN.ClaRet, SqlSelect.Operador.Igual, pObj.ClaveRetiquetado);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<RetiquetadoEN> ListarRetiquetadoXEstado(RetiquetadoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RetiquetadoEN.CEstRet, SqlSelect.Operador.Igual, pObj.CEstadoRetiquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RetiquetadoEN> ListarRetiquetadoXPeriodoRetiquetado(RetiquetadoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RetiquetadoEN.PerRet, SqlSelect.Operador.Igual, pObj.PeriodoRetiquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RetiquetadoEN> ListarRetiquetadoParaReporteCostoLoteEtapaRetiquetado(RetiquetadoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RetiquetadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, RetiquetadoEN.FecRet, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                   , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            if (pObj.CodigoExistenciaRE != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, RetiquetadoEN.CodExiRE, SqlSelect.Operador.Igual, pObj.CodigoExistenciaRE);
            }
            xSel.Ordenar(RetiquetadoEN.FecRet + "," + RetiquetadoEN.CodExiRE, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion


    }
}
