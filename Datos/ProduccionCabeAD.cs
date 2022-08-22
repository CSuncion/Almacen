using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptBD;
using Entidades.Adicionales;
using Datos.Config;
using System.Data;
using Comun;
using Entidades;




namespace Datos
{
    public class ProduccionCabeAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<ProduccionCabeEN> xLista = new List<ProduccionCabeEN>();
        private ProduccionCabeEN xObj = new ProduccionCabeEN();
        private string xTabla = "ProduccionCabe";
        private string xVista = "VsProduccionCabe";

        #endregion
        
        #region Metodos privados

        private ProduccionCabeEN Objeto(IDataReader iDr)
        {
            ProduccionCabeEN xObjEnc = new ProduccionCabeEN();
            xObjEnc.ClaveProduccionCabe = iDr[ProduccionCabeEN.ClaProCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[ProduccionCabeEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[ProduccionCabeEN.NomEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[ProduccionCabeEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[ProduccionCabeEN.DesAlm].ToString();
            xObjEnc.CorrelativoProduccionCabe = iDr[ProduccionCabeEN.CorProCab].ToString();
            xObjEnc.CodigoExistencia = iDr[ProduccionCabeEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[ProduccionCabeEN.DesExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[ProduccionCabeEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[ProduccionCabeEN.NomUniMed].ToString();
            xObjEnc.FechaProduccionCabe = Fecha.ObtenerDiaMesAno(iDr[ProduccionCabeEN.FecProCab]);
            xObjEnc.PeriodoProduccionCabe = iDr[ProduccionCabeEN.PerProCab].ToString();
            xObjEnc.CantidadFormula = Convert.ToDecimal(iDr[ProduccionCabeEN.CanFor].ToString());
            xObjEnc.CantidadProduccionCabe = Convert.ToDecimal(iDr[ProduccionCabeEN.CanProCab].ToString());
            xObjEnc.CantidadProducidaProduccionCabe = Convert.ToDecimal(iDr[ProduccionCabeEN.CanProProCab].ToString());
            xObjEnc.SaldoProduccionCabe = Convert.ToDecimal(iDr[ProduccionCabeEN.SalProCab].ToString());
            xObjEnc.CantidadRealProduccion = Convert.ToDecimal(iDr[ProduccionCabeEN.CanReaPro].ToString());
            xObjEnc.CodigoLicitacion = iDr[ProduccionCabeEN.CodLic].ToString();
            xObjEnc.DescripcionLicitacion = iDr[ProduccionCabeEN.DesLic].ToString();
            xObjEnc.CodigoAuxiliar = iDr[ProduccionCabeEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[ProduccionCabeEN.DesAux].ToString();
            xObjEnc.ObservacionProduccionCabe = iDr[ProduccionCabeEN.ObsProCab].ToString();
            xObjEnc.CodigoMercaderia = iDr[ProduccionCabeEN.CodMer].ToString();
            xObjEnc.CEsExacto = iDr[ProduccionCabeEN.CEsExa].ToString();            
            xObjEnc.CTurno = iDr[ProduccionCabeEN.CTur].ToString();
            xObjEnc.NTurno = iDr[ProduccionCabeEN.NTur].ToString();
            xObjEnc.CodigoAlmacenSemiProducto = iDr[ProduccionCabeEN.CodAlmSemPro].ToString();
            xObjEnc.CodigoSemiProducto = iDr[ProduccionCabeEN.CodSemPro].ToString();
            xObjEnc.DescripcionSemiProducto = iDr[ProduccionCabeEN.DesSemPro].ToString();
            xObjEnc.UnidadesReproceso = Convert.ToDecimal(iDr[ProduccionCabeEN.UniRep].ToString());
            xObjEnc.CostoUnidadesReproceso = Convert.ToDecimal(iDr[ProduccionCabeEN.CosUniRep].ToString());
            xObjEnc.DetalleFormulasDeta = iDr[ProduccionCabeEN.DetForDet].ToString();
            xObjEnc.PorcentajeRango = Convert.ToDecimal(iDr[ProduccionCabeEN.PorRan].ToString());
            xObjEnc.CantidadRango = Convert.ToDecimal(iDr[ProduccionCabeEN.CanRan].ToString());
            xObjEnc.CantidadSinceradoProduccionCabe = Convert.ToDecimal(iDr[ProduccionCabeEN.CanSinProCab].ToString());
            xObjEnc.PorcentajeSinceradoRango = Convert.ToDecimal(iDr[ProduccionCabeEN.PorSinRan].ToString());
            xObjEnc.CantidadSinceradoRango = Convert.ToDecimal(iDr[ProduccionCabeEN.CanSinRan].ToString());
            xObjEnc.DetalleMotivoSincerado = iDr[ProduccionCabeEN.DetMotSin].ToString();
            xObjEnc.CEstadoProduccionCabe = iDr[ProduccionCabeEN.CEstProCab].ToString();
            xObjEnc.NEstadoProduccionCabe = iDr[ProduccionCabeEN.NEstProCab].ToString();
            xObjEnc.UsuarioAgrega = iDr[ProduccionCabeEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ProduccionCabeEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[ProduccionCabeEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ProduccionCabeEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveProduccionCabe;
            return xObjEnc;
        }

        private List<ProduccionCabeEN> ListarObjetos(string pScript)
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

        private ProduccionCabeEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(ProduccionCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, ProduccionCabeEN.CorProCab);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AdicionarProduccionCabe(ProduccionCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(ProduccionCabeEN.ClaProCab, pObj.ClaveProduccionCabe);
            xIns.AsignarParametro(ProduccionCabeEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(ProduccionCabeEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(ProduccionCabeEN.CorProCab, pObj.CorrelativoProduccionCabe);
            xIns.AsignarParametro(ProduccionCabeEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(ProduccionCabeEN.CodUniMed, pObj.CodigoUnidadMedida);
            xIns.AsignarParametro(ProduccionCabeEN.CanFor, pObj.CantidadFormula.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.CanProCab,  pObj.CantidadProduccionCabe.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.CanProProCab, pObj.CantidadProducidaProduccionCabe.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.SalProCab, pObj.SaldoProduccionCabe.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.CanReaPro, pObj.CantidadRealProduccion.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.CodLic, pObj.CodigoLicitacion);
            xIns.AsignarParametro(ProduccionCabeEN.PerProCab, pObj.PeriodoProduccionCabe);
            xIns.AsignarParametro(ProduccionCabeEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(ProduccionCabeEN.FecProCab, Fecha.ObtenerAnoMesDia( pObj.FechaProduccionCabe));
            xIns.AsignarParametro(ProduccionCabeEN.ObsProCab, pObj.ObservacionProduccionCabe);
            xIns.AsignarParametro(ProduccionCabeEN.CodMer, pObj.CodigoMercaderia);
            xIns.AsignarParametro(ProduccionCabeEN.CEsExa, pObj.CEsExacto);
            xIns.AsignarParametro(ProduccionCabeEN.CTur, pObj.CTurno);
            xIns.AsignarParametro(ProduccionCabeEN.UniRep, pObj.UnidadesReproceso.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.CosUniRep, pObj.CostoUnidadesReproceso.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.DetForDet, pObj.DetalleFormulasDeta);
            xIns.AsignarParametro(ProduccionCabeEN.PorRan, pObj.PorcentajeRango.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.CanRan, pObj.CantidadRango.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.CanSinProCab, pObj.CantidadSinceradoProduccionCabe.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.PorSinRan, pObj.PorcentajeSinceradoRango.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.CanSinRan, pObj.CantidadSinceradoRango.ToString());
            xIns.AsignarParametro(ProduccionCabeEN.DetMotSin, pObj.DetalleMotivoSincerado);
            xIns.AsignarParametro(ProduccionCabeEN.CEstProCab, pObj.CEstadoProduccionCabe);
            xIns.AsignarParametro(ProduccionCabeEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ProduccionCabeEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(ProduccionCabeEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ProduccionCabeEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarProduccionCabe(List<ProduccionCabeEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ProduccionCabeEN xProCab in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(ProduccionCabeEN.ClaProCab, xProCab.ClaveProduccionCabe);
                xIns.AsignarParametro(ProduccionCabeEN.CodEmp, xProCab.CodigoEmpresa);
                xIns.AsignarParametro(ProduccionCabeEN.CodAlm, xProCab.CodigoAlmacen);
                xIns.AsignarParametro(ProduccionCabeEN.CorProCab, xProCab.CorrelativoProduccionCabe);
                xIns.AsignarParametro(ProduccionCabeEN.CodExi, xProCab.CodigoExistencia);
                xIns.AsignarParametro(ProduccionCabeEN.CodUniMed, xProCab.CodigoUnidadMedida);
                xIns.AsignarParametro(ProduccionCabeEN.CanFor, xProCab.CantidadFormula.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.CanProCab, xProCab.CantidadProduccionCabe.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.CanProProCab, xProCab.CantidadProducidaProduccionCabe.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.SalProCab, xProCab.SaldoProduccionCabe.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.CanReaPro, xProCab.CantidadRealProduccion.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.CodLic, xProCab.CodigoLicitacion);
                xIns.AsignarParametro(ProduccionCabeEN.PerProCab, xProCab.PeriodoProduccionCabe);
                xIns.AsignarParametro(ProduccionCabeEN.CodAux, xProCab.CodigoAuxiliar);
                xIns.AsignarParametro(ProduccionCabeEN.FecProCab, Fecha.ObtenerAnoMesDia(xProCab.FechaProduccionCabe));
                xIns.AsignarParametro(ProduccionCabeEN.ObsProCab, xProCab.ObservacionProduccionCabe);
                xIns.AsignarParametro(ProduccionCabeEN.CodMer, xProCab.CodigoMercaderia);
                xIns.AsignarParametro(ProduccionCabeEN.CEsExa, xProCab.CEsExacto);
                xIns.AsignarParametro(ProduccionCabeEN.CTur, xProCab.CTurno);
                xIns.AsignarParametro(ProduccionCabeEN.UniRep, xProCab.UnidadesReproceso.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.CosUniRep, xProCab.CostoUnidadesReproceso.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.DetForDet, xProCab.DetalleFormulasDeta);
                xIns.AsignarParametro(ProduccionCabeEN.PorRan, xProCab.PorcentajeRango.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.CanRan, xProCab.CantidadRango.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.CanSinProCab, xProCab.CantidadSinceradoProduccionCabe.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.PorSinRan, xProCab.PorcentajeSinceradoRango.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.CanSinRan, xProCab.CantidadSinceradoRango.ToString());
                xIns.AsignarParametro(ProduccionCabeEN.DetMotSin, xProCab.DetalleMotivoSincerado);
                xIns.AsignarParametro(ProduccionCabeEN.CEstProCab, xProCab.CEstadoProduccionCabe);
                xIns.AsignarParametro(ProduccionCabeEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ProduccionCabeEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(ProduccionCabeEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ProduccionCabeEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarProduccionCabe(ProduccionCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(ProduccionCabeEN.CodExi, pObj.CodigoExistencia);
            xUpd.AsignarParametro(ProduccionCabeEN.CodUniMed, pObj.CodigoUnidadMedida);
            xUpd.AsignarParametro(ProduccionCabeEN.CanFor, pObj.CantidadFormula.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.CanProCab, pObj.CantidadProduccionCabe.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.CanProProCab, pObj.CantidadProducidaProduccionCabe.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.SalProCab, pObj.SaldoProduccionCabe.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.CanReaPro, pObj.CantidadRealProduccion.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.CodAux, pObj.CodigoAuxiliar);
            xUpd.AsignarParametro(ProduccionCabeEN.FecProCab, Fecha.ObtenerAnoMesDia(pObj.FechaProduccionCabe));
            xUpd.AsignarParametro(ProduccionCabeEN.PerProCab, pObj.PeriodoProduccionCabe);
            xUpd.AsignarParametro(ProduccionCabeEN.CodLic, pObj.CodigoLicitacion);          
            xUpd.AsignarParametro(ProduccionCabeEN.ObsProCab, pObj.ObservacionProduccionCabe);
            xUpd.AsignarParametro(ProduccionCabeEN.CodMer, pObj.CodigoMercaderia);
            xUpd.AsignarParametro(ProduccionCabeEN.CEsExa, pObj.CEsExacto);
            xUpd.AsignarParametro(ProduccionCabeEN.CTur, pObj.CTurno);
            xUpd.AsignarParametro(ProduccionCabeEN.UniRep, pObj.UnidadesReproceso.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.CosUniRep, pObj.CostoUnidadesReproceso.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.DetForDet, pObj.DetalleFormulasDeta);
            xUpd.AsignarParametro(ProduccionCabeEN.PorRan, pObj.PorcentajeRango.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.CanRan, pObj.CantidadRango.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.CanSinProCab, pObj.CantidadSinceradoProduccionCabe.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.PorSinRan, pObj.PorcentajeSinceradoRango.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.CanSinRan, pObj.CantidadSinceradoRango.ToString());
            xUpd.AsignarParametro(ProduccionCabeEN.DetMotSin, pObj.DetalleMotivoSincerado);
            xUpd.AsignarParametro(ProduccionCabeEN.CEstProCab, pObj.CEstadoProduccionCabe);
            xUpd.AsignarParametro(ProduccionCabeEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ProduccionCabeEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.ClaProCab, SqlSelect.Operador.Igual, pObj.ClaveProduccionCabe);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar comando
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarProduccionCabe(List<ProduccionCabeEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ProduccionCabeEN xProCab in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(ProduccionCabeEN.CodExi, xProCab.CodigoExistencia);
                xUpd.AsignarParametro(ProduccionCabeEN.CodUniMed, xProCab.CodigoUnidadMedida);
                xUpd.AsignarParametro(ProduccionCabeEN.CanFor, xProCab.CantidadFormula.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.CanProCab, xProCab.CantidadProduccionCabe.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.CanProProCab, xProCab.CantidadProducidaProduccionCabe.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.SalProCab, xProCab.SaldoProduccionCabe.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.CanReaPro, xProCab.CantidadRealProduccion.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.CodAux, xProCab.CodigoAuxiliar);
                xUpd.AsignarParametro(ProduccionCabeEN.FecProCab, Fecha.ObtenerAnoMesDia(xProCab.FechaProduccionCabe));
                xUpd.AsignarParametro(ProduccionCabeEN.PerProCab, xProCab.PeriodoProduccionCabe);
                xUpd.AsignarParametro(ProduccionCabeEN.CodLic, xProCab.CodigoLicitacion);
                xUpd.AsignarParametro(ProduccionCabeEN.ObsProCab, xProCab.ObservacionProduccionCabe);
                xUpd.AsignarParametro(ProduccionCabeEN.CodMer, xProCab.CodigoMercaderia);
                xUpd.AsignarParametro(ProduccionCabeEN.CEsExa, xProCab.CEsExacto);
                xUpd.AsignarParametro(ProduccionCabeEN.CTur, xProCab.CTurno);
                xUpd.AsignarParametro(ProduccionCabeEN.UniRep, xProCab.UnidadesReproceso.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.CosUniRep, xProCab.CostoUnidadesReproceso.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.DetForDet, xProCab.DetalleFormulasDeta);
                xUpd.AsignarParametro(ProduccionCabeEN.PorRan, xProCab.PorcentajeRango.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.CanRan, xProCab.CantidadRango.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.CanSinProCab, xProCab.CantidadSinceradoProduccionCabe.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.PorSinRan, xProCab.PorcentajeSinceradoRango.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.CanSinRan, xProCab.CantidadSinceradoRango.ToString());
                xUpd.AsignarParametro(ProduccionCabeEN.DetMotSin, xProCab.DetalleMotivoSincerado);
                xUpd.AsignarParametro(ProduccionCabeEN.CEstProCab, xProCab.CEstadoProduccionCabe);
                xUpd.AsignarParametro(ProduccionCabeEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(ProduccionCabeEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.ClaProCab, SqlSelect.Operador.Igual, xProCab.ClaveProduccionCabe);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar comando
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
           
            xObjCon.Desconectar();
        }

        public void EliminarProduccionCabe(ProduccionCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.ClaProCab, SqlSelect.Operador.Igual, pObj.ClaveProduccionCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }    

        public ProduccionCabeEN BuscarProduccionCabeXClave(ProduccionCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.ClaProCab, SqlSelect.Operador.Igual, pObj.ClaveProduccionCabe);
            return this.BuscarObjeto(xSel.ObtenerScript());       
        }

        public List<ProduccionCabeEN> ListarProduccionCabeActivos(ProduccionCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CEstProCab, SqlSelect.Operador.Igual, "1"); //activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionCabeEN> ListarProduccionCabeXPeriodo(ProduccionCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.PerProCab, SqlSelect.Operador.Igual, pObj.PeriodoProduccionCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionCabeEN> ListarProduccionCabeXEstado(ProduccionCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (pObj.CEstadoProduccionCabe != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CEstProCab, SqlSelect.Operador.Igual, pObj.CEstadoProduccionCabe);
            }            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionCabeEN> ListarProduccionCabePendientesDeAlmacen(ProduccionCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CEstProCab, SqlSelect.Operador.Igual, "0");//pendiente
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionCabeEN> ListarProduccionCabeAprobadasDeAlmacen(ProduccionCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CEstProCab, SqlSelect.Operador.Igual, "2");//aprobada
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionCabeEN> ListarProduccionCabeTerminadosYSinDescargaInsumos()
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsProduccionCabe";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And ClaveProduccionCabe In(Select ClaveProduccionCabe From VsProduccionDeta Where ClaveSalidaFaseMasa='')";
            iScript += " Order By " + ProduccionCabeEN.ClaProCab;

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ProduccionCabeEN> ListarProduccionCabeParaCalculoUnidadesReprocesar(string pCodExiSemEla)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CodSemPro, SqlSelect.Operador.Igual, pCodExiSemEla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.UniRep, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionINx(SqlSelect.Reservada.Y, ProduccionCabeEN.CEstProCab, "'0','1','2'");
            xSel.Ordenar(ProduccionDetaEN.CorProCab, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionCabeEN> ListarProduccionCabesParaGenerarPartesTrabajo()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CEstProCab, SqlSelect.Operador.Igual, "2");//aprobado
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionCabeEN.CanProProCab, SqlSelect.Operador.Igual, "0");
            xSel.Ordenar(ProduccionCabeEN.CorProCab, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

    }
}
