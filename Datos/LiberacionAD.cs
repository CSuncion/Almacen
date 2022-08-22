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
using System.Windows.Forms;


namespace Datos
{

    public class LiberacionAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<LiberacionEN> eLista = new List<LiberacionEN>();
        private LiberacionEN eObj = new LiberacionEN();
        private string eTabla = "Liberacion";
        private string eVista = "VsLiberacion";

        #endregion

        #region Metodos privados

        private LiberacionEN Objeto(IDataReader iDr)
        {
            LiberacionEN xObjEnc = new LiberacionEN();
            xObjEnc.ClaveLiberacion = iDr[LiberacionEN.ClaLib].ToString();
            xObjEnc.ClaveProduccionDeta = iDr[LiberacionEN.ClaProDet].ToString();
            xObjEnc.CorrelativoProduccionCabe = iDr[LiberacionEN.CorProCab].ToString();
            xObjEnc.FechaProduccionDeta = Fecha.ObtenerDiaMesAno(iDr[LiberacionEN.FecProDet].ToString());
            xObjEnc.CostoInsumos = Convert.ToDecimal(iDr[LiberacionEN.CosIns].ToString());
            xObjEnc.CostoTotalProducto = Convert.ToDecimal(iDr[LiberacionEN.CosTotPro].ToString());
            xObjEnc.CantidadRealProduccion = Convert.ToDecimal(iDr[LiberacionEN.CanReaPro].ToString());
            xObjEnc.CodigoLiberacion = iDr[LiberacionEN.CodLib].ToString();
            xObjEnc.CodigoEmpresa = iDr[LiberacionEN.CodEmp].ToString();
            xObjEnc.CodigoAlmacenSemiProducto = iDr[LiberacionEN.CodAlmSemPro].ToString();          
            xObjEnc.CodigoSemiProducto = iDr[LiberacionEN.CodSemPro].ToString();
            xObjEnc.DescripcionSemiProducto = iDr[LiberacionEN.DesSemPro].ToString();
            xObjEnc.FechaLiberacion = Fecha.ObtenerDiaMesAno(iDr[LiberacionEN.FecLib].ToString());
            xObjEnc.PeriodoLiberacion = iDr[LiberacionEN.PerLib].ToString();
            xObjEnc.SaldoLiberacion = Convert.ToDecimal(iDr[LiberacionEN.SalLib].ToString());
            xObjEnc.CantidadLiberacion = Convert.ToDecimal(iDr[LiberacionEN.CanLib].ToString());
            xObjEnc.UnidadesPasan = Convert.ToDecimal(iDr[LiberacionEN.UniPas].ToString());
            xObjEnc.UnidadesParaReproceso = Convert.ToDecimal(iDr[LiberacionEN.UniParRep].ToString());
            xObjEnc.UnidadesParaDonacion = Convert.ToDecimal(iDr[LiberacionEN.UniParDon].ToString());
            xObjEnc.UnidadesParaMuestra = Convert.ToDecimal(iDr[LiberacionEN.UniParMue].ToString());
            xObjEnc.UnidadesDesechas = Convert.ToDecimal(iDr[LiberacionEN.UniDes].ToString());
            xObjEnc.UnidadesObservadas = Convert.ToDecimal(iDr[LiberacionEN.UniObs].ToString());
            xObjEnc.UnidadesSaldo = Convert.ToDecimal(iDr[LiberacionEN.UniSal].ToString());
            xObjEnc.ClaveSalidaTransferenciaDesechas = iDr[LiberacionEN.ClaSalTraDes].ToString();
            xObjEnc.ClaveIngresoTransferenciaDesechas = iDr[LiberacionEN.ClaIngTraDes].ToString();
            xObjEnc.ClaveSalidaTransferenciaReproceso = iDr[LiberacionEN.ClaSalTraRep].ToString();
            xObjEnc.ClaveIngresoTransferenciaReproceso = iDr[LiberacionEN.ClaIngTraRep].ToString();
            xObjEnc.ClaveSalidaTransferenciaDonacion = iDr[LiberacionEN.ClaSalTraDon].ToString();
            xObjEnc.ClaveIngresoTransferenciaDonacion = iDr[LiberacionEN.ClaIngTraDon].ToString();
            xObjEnc.ClaveSalidaTransferenciaMuestra = iDr[LiberacionEN.ClaSalTraMue].ToString();
            xObjEnc.ClaveIngresoTransferenciaMuestra = iDr[LiberacionEN.ClaIngTraMue].ToString();
            xObjEnc.ClaveIngresoObservadas = iDr[LiberacionEN.ClaIngObs].ToString();
            xObjEnc.ClaveIngresoSaldo = iDr[LiberacionEN.ClaIngSal].ToString();
            xObjEnc.SaldoUnidadesAEmpacar = Convert.ToDecimal(iDr[LiberacionEN.SalUniAEmp].ToString());
            xObjEnc.DetalleMotivoReproceso = iDr[LiberacionEN.DetMovRep].ToString();
            xObjEnc.DetalleMotivoDonacion = iDr[LiberacionEN.DetMovDon].ToString();
            xObjEnc.DetalleMotivoMuestra = iDr[LiberacionEN.DetMovMue].ToString();
            xObjEnc.DetalleMotivoDesecho = iDr[LiberacionEN.DetMovDes].ToString();
            xObjEnc.UnidadesAprobadasLiberacion = Convert.ToDecimal(iDr[LiberacionEN.UniAprLib].ToString());
            xObjEnc.CostoCIFFijo = Convert.ToDecimal(iDr[LiberacionEN.CosCifFij].ToString());
            xObjEnc.CostoUnidadMasa = Convert.ToDecimal(iDr[LiberacionEN.CosUniMas].ToString());
            xObjEnc.CostoUnidadConCal = Convert.ToDecimal(iDr[LiberacionEN.CosUniConCal].ToString());
            xObjEnc.CostoManoObra = Convert.ToDecimal(iDr[LiberacionEN.CosManObr].ToString());
            xObjEnc.CostoCIFVariable = Convert.ToDecimal(iDr[LiberacionEN.CosCIFVar].ToString());
            xObjEnc.CAlmacenLiberacion = iDr[LiberacionEN.CAlmLib].ToString();
            xObjEnc.ClaveSalidaTransferenciaPacking = iDr[LiberacionEN.ClaSalTraPack].ToString();
            xObjEnc.ClaveIngresoTransferenciaPacking = iDr[LiberacionEN.ClaIngTraPack].ToString();
            xObjEnc.CostoMasaPrincipal = Convert.ToDecimal(iDr[LiberacionEN.CosMasPri].ToString());
            xObjEnc.CostoConCalPrincipal = Convert.ToDecimal(iDr[LiberacionEN.CosConCalPri].ToString());
            xObjEnc.CostoUnidadesReproceso = Convert.ToDecimal(iDr[LiberacionEN.CosUniRep].ToString());
            xObjEnc.CantidadSinceradoProduccionDeta = Convert.ToDecimal(iDr[LiberacionEN.CanSinProDet].ToString());
            xObjEnc.CantidadEncajonar = Convert.ToDecimal(iDr[LiberacionEN.CanEnc].ToString());
            xObjEnc.CantidadUnidadesPackingAdicionalesBlo = Convert.ToDecimal(iDr[LiberacionEN.CanUniPacAdiBlo].ToString());
            xObjEnc.UnidadesReprocesoLiberacion = Convert.ToDecimal(iDr[LiberacionEN.UniRepLib].ToString());
            xObjEnc.UnidadesObservadasLiberacion = Convert.ToDecimal(iDr[LiberacionEN.UniObsLib].ToString());
            xObjEnc.UnidadesDesechasLiberacion = Convert.ToDecimal(iDr[LiberacionEN.UniDesLib].ToString());
            xObjEnc.CEstadoLiberacion = iDr[LiberacionEN.CEstLib].ToString();
            xObjEnc.NEstadoLiberacion = iDr[LiberacionEN.NEstLib].ToString();
            xObjEnc.UsuarioAgrega = iDr[LiberacionEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[LiberacionEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[LiberacionEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[LiberacionEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClaveLiberacion;
            return xObjEnc;
        }

        private List<LiberacionEN> ListarObjetos(string pScript)
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

        private LiberacionEN BuscarObjeto(string pScript)
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

        public void AdicionarLiberacion(List<LiberacionEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LiberacionEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(LiberacionEN.ClaLib, xObj.ClaveLiberacion);
                xIns.AsignarParametro(LiberacionEN.ClaProDet, xObj.ClaveProduccionDeta);
                xIns.AsignarParametro(LiberacionEN.CodLib, xObj.CodigoLiberacion);
                xIns.AsignarParametro(LiberacionEN.CodEmp, xObj.CodigoEmpresa);
                xIns.AsignarParametro(LiberacionEN.FecLib, Fecha.ObtenerAnoMesDia(xObj.FechaLiberacion));
                xIns.AsignarParametro(LiberacionEN.PerLib, xObj.PeriodoLiberacion);
                xIns.AsignarParametro(LiberacionEN.SalLib, xObj.SaldoLiberacion.ToString());
                xIns.AsignarParametro(LiberacionEN.CanLib, xObj.CantidadLiberacion.ToString());
                xIns.AsignarParametro(LiberacionEN.UniPas, xObj.UnidadesPasan.ToString());
                xIns.AsignarParametro(LiberacionEN.UniParRep, xObj.UnidadesParaReproceso.ToString());
                xIns.AsignarParametro(LiberacionEN.UniParDon, xObj.UnidadesParaDonacion.ToString());
                xIns.AsignarParametro(LiberacionEN.UniParMue, xObj.UnidadesParaMuestra.ToString());
                xIns.AsignarParametro(LiberacionEN.UniDes, xObj.UnidadesDesechas.ToString());
                xIns.AsignarParametro(LiberacionEN.UniObs, xObj.UnidadesObservadas.ToString());
                xIns.AsignarParametro(LiberacionEN.UniSal, xObj.UnidadesSaldo.ToString());
                xIns.AsignarParametro(LiberacionEN.ClaSalTraDes, xObj.ClaveSalidaTransferenciaDesechas);
                xIns.AsignarParametro(LiberacionEN.ClaIngTraDes, xObj.ClaveIngresoTransferenciaDesechas);
                xIns.AsignarParametro(LiberacionEN.ClaSalTraRep, xObj.ClaveSalidaTransferenciaReproceso);
                xIns.AsignarParametro(LiberacionEN.ClaIngTraRep, xObj.ClaveIngresoTransferenciaReproceso);
                xIns.AsignarParametro(LiberacionEN.ClaSalTraDon, xObj.ClaveSalidaTransferenciaDonacion);
                xIns.AsignarParametro(LiberacionEN.ClaIngTraDon, xObj.ClaveIngresoTransferenciaDonacion);
                xIns.AsignarParametro(LiberacionEN.ClaSalTraMue, xObj.ClaveSalidaTransferenciaMuestra);
                xIns.AsignarParametro(LiberacionEN.ClaIngTraMue, xObj.ClaveIngresoTransferenciaMuestra);
                xIns.AsignarParametro(LiberacionEN.ClaIngObs, xObj.ClaveIngresoObservadas);
                xIns.AsignarParametro(LiberacionEN.ClaIngSal, xObj.ClaveIngresoSaldo);
                xIns.AsignarParametro(LiberacionEN.SalUniAEmp, xObj.SaldoUnidadesAEmpacar.ToString());
                xIns.AsignarParametro(LiberacionEN.DetMovRep, xObj.DetalleMotivoReproceso);
                xIns.AsignarParametro(LiberacionEN.DetMovDon, xObj.DetalleMotivoDonacion);
                xIns.AsignarParametro(LiberacionEN.DetMovMue, xObj.DetalleMotivoMuestra);
                xIns.AsignarParametro(LiberacionEN.DetMovDes, xObj.DetalleMotivoDesecho);
                xIns.AsignarParametro(LiberacionEN.CAlmLib, xObj.CAlmacenLiberacion);
                xIns.AsignarParametro(LiberacionEN.ClaSalTraPack, xObj.ClaveSalidaTransferenciaPacking);
                xIns.AsignarParametro(LiberacionEN.ClaIngTraPack, xObj.ClaveIngresoTransferenciaPacking);
                xIns.AsignarParametro(LiberacionEN.CEstLib, xObj.CEstadoLiberacion);
                xIns.AsignarParametro(LiberacionEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(LiberacionEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(LiberacionEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(LiberacionEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarLiberacion(List<LiberacionEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LiberacionEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(LiberacionEN.ClaLib, xObj.ClaveLiberacion);
                xUpd.AsignarParametro(LiberacionEN.ClaProDet, xObj.ClaveProduccionDeta);
                xUpd.AsignarParametro(LiberacionEN.CodLib, xObj.CodigoLiberacion);
                xUpd.AsignarParametro(LiberacionEN.CodEmp, xObj.CodigoEmpresa);
                xUpd.AsignarParametro(LiberacionEN.FecLib, Fecha.ObtenerAnoMesDia(xObj.FechaLiberacion));
                xUpd.AsignarParametro(LiberacionEN.PerLib, xObj.PeriodoLiberacion);
                xUpd.AsignarParametro(LiberacionEN.SalLib, xObj.SaldoLiberacion.ToString());
                xUpd.AsignarParametro(LiberacionEN.CanLib, xObj.CantidadLiberacion.ToString());
                xUpd.AsignarParametro(LiberacionEN.UniPas, xObj.UnidadesPasan.ToString());
                xUpd.AsignarParametro(LiberacionEN.UniParRep, xObj.UnidadesParaReproceso.ToString());
                xUpd.AsignarParametro(LiberacionEN.UniParDon, xObj.UnidadesParaDonacion.ToString());
                xUpd.AsignarParametro(LiberacionEN.UniParMue, xObj.UnidadesParaMuestra.ToString());
                xUpd.AsignarParametro(LiberacionEN.UniDes, xObj.UnidadesDesechas.ToString());
                xUpd.AsignarParametro(LiberacionEN.UniObs, xObj.UnidadesObservadas.ToString());
                xUpd.AsignarParametro(LiberacionEN.UniSal, xObj.UnidadesSaldo.ToString());
                xUpd.AsignarParametro(LiberacionEN.ClaSalTraDes, xObj.ClaveSalidaTransferenciaDesechas);
                xUpd.AsignarParametro(LiberacionEN.ClaIngTraDes, xObj.ClaveIngresoTransferenciaDesechas);
                xUpd.AsignarParametro(LiberacionEN.ClaSalTraRep, xObj.ClaveSalidaTransferenciaReproceso);
                xUpd.AsignarParametro(LiberacionEN.ClaIngTraRep, xObj.ClaveIngresoTransferenciaReproceso);
                xUpd.AsignarParametro(LiberacionEN.ClaSalTraDon, xObj.ClaveSalidaTransferenciaDonacion);
                xUpd.AsignarParametro(LiberacionEN.ClaIngTraDon, xObj.ClaveIngresoTransferenciaDonacion);
                xUpd.AsignarParametro(LiberacionEN.ClaSalTraMue, xObj.ClaveSalidaTransferenciaMuestra);
                xUpd.AsignarParametro(LiberacionEN.ClaIngTraMue, xObj.ClaveIngresoTransferenciaMuestra);
                xUpd.AsignarParametro(LiberacionEN.ClaIngObs, xObj.ClaveIngresoObservadas);
                xUpd.AsignarParametro(LiberacionEN.ClaIngSal, xObj.ClaveIngresoSaldo);
                xUpd.AsignarParametro(LiberacionEN.SalUniAEmp, xObj.SaldoUnidadesAEmpacar.ToString());
                xUpd.AsignarParametro(LiberacionEN.DetMovRep, xObj.DetalleMotivoReproceso);
                xUpd.AsignarParametro(LiberacionEN.DetMovDon, xObj.DetalleMotivoDonacion);
                xUpd.AsignarParametro(LiberacionEN.DetMovMue, xObj.DetalleMotivoMuestra);
                xUpd.AsignarParametro(LiberacionEN.DetMovDes, xObj.DetalleMotivoDesecho);
                xUpd.AsignarParametro(LiberacionEN.CAlmLib, xObj.CAlmacenLiberacion);
                xUpd.AsignarParametro(LiberacionEN.ClaSalTraPack, xObj.ClaveSalidaTransferenciaPacking);
                xUpd.AsignarParametro(LiberacionEN.ClaIngTraPack, xObj.ClaveIngresoTransferenciaPacking);
                xUpd.AsignarParametro(LiberacionEN.CEstLib, xObj.CEstadoLiberacion);               
                xUpd.AsignarParametro(LiberacionEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(LiberacionEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.ClaLib, SqlSelect.Operador.Igual, xObj.ClaveLiberacion);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarLiberacion(List<LiberacionEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LiberacionEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.ClaLib, SqlSelect.Operador.Igual, xObj.ClaveLiberacion);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public List<LiberacionEN> ListarLiberacion(LiberacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public LiberacionEN BuscarLiberacionXClave(LiberacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.ClaLib, SqlSelect.Operador.Igual, pObj.ClaveLiberacion);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarLiberacionXClaveProduccionDeta(LiberacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarLiberacionParaEmpaquetarXCodigoSemiProducto(string pCodigoSemiProducto,bool pFlagTemporal)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.CodSemPro, SqlSelect.Operador.Igual, pCodigoSemiProducto);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.CAlmLib, SqlSelect.Operador.Igual, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.SalUniAEmp, SqlSelect.Operador.Diferente, "0");
            //CONDICION TEMPORAL
            if (pFlagTemporal == true)//solo liberaciones de enero hasta abril
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, LiberacionEN.PerLib, "2020-01", "2020-04");
            }
            else
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.PerLib, SqlSelect.Operador.Mayor, "2020-04");
            }
            xSel.Ordenar(LiberacionEN.FecLib, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarLiberacionParaEmpaquetar()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.UniPas, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.SalUniAEmp, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(LiberacionEN.ClaLib, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarLiberacionXClavesLiberacion(LiberacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionINx(SqlSelect.Reservada.Y, LiberacionEN.ClaLib, pObj.ClaveLiberacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarLiberacionXPeriodo(LiberacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.PerLib, SqlSelect.Operador.Igual, pObj.PeriodoLiberacion);            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarLiberacionesSinMovimientos()
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsLiberacion";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And (UnidadesParaReproceso<>0 and ClaveSalidaTransferenciaReproceso='')";
            iScript += " Or (UnidadesParaDonacion<>0 and ClaveSalidaTransferenciaDonacion='')";
            iScript += " Or (UnidadesParaMuestra<>0 and ClaveSalidaTransferenciaMuestra='')";
            iScript += " Or (UnidadesDesechas<>0 and ClaveSalidaTransferenciaDesechas='')";
            iScript += " Order By " + LiberacionEN.ClaProDet;

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<LiberacionEN> ListarLiberacionesSinMovimientosNew(LiberacionEN pObj)
        {            
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsLiberacion";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And (UnidadesParaReproceso<>0 and ClaveSalidaTransferenciaReproceso='')";
            iScript += " Or (UnidadesParaDonacion<>0 and ClaveSalidaTransferenciaDonacion='')";
            iScript += " Or (UnidadesParaMuestra<>0 and ClaveSalidaTransferenciaMuestra='')";
            iScript += " Or (UnidadesDesechas<>0 and ClaveSalidaTransferenciaDesechas='')";
            iScript += " Order By " + pObj.Adicionales.CampoOrden;

            //MessageBox.Show(iScript);   

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<LiberacionEN> ListarProduccionDetaXRangoFechaLiberacion(LiberacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, LiberacionEN.FecLib, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                   , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarProduccionDetaParaReporteCostoLoteClasificacionEncajado(LiberacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, LiberacionEN.FecLib, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                   , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            if (pObj.CodigoSemiProducto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.CodSemPro, SqlSelect.Operador.Igual, pObj.CodigoSemiProducto);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.CAlmLib, SqlSelect.Operador.Igual, "0");//solo liberaciones
            xSel.Ordenar(LiberacionEN.FecLib, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarLiberacionXClaveProduccionDetaYCAlmacen(LiberacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LiberacionEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LiberacionEN.CAlmLib, SqlSelect.Operador.Igual, pObj.CAlmacenLiberacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LiberacionEN> ListarLiberacionAnteriorParaReporteCostoLoteEtapaEncajado(List<LiberacionEN> pLista)
        {
            //si la lista esta vacia,retorna lista vacia
            if (pLista.Count == 0) { return eLista; }

            //script manual
            string iScript = string.Empty;

            //recorrer cada objeto
            foreach (LiberacionEN xLib in pLista)
            {
                //armando la primera consulta
                iScript += "Select * From VsLiberacion";
                iScript += " Where CorrelativoProduccionCabe='" + xLib.CorrelativoProduccionCabe + "'";
                iScript += " And CodigoLiberacion<'" + xLib.CodigoLiberacion + "'";
                iScript += " Union ";
            }

            //quitar el ultimo union
            iScript = Cadena.CortarCadena(iScript, iScript.Length - 6, Cadena.Direccion.Izquierda);

            //ordenar
            iScript += " Order by ClaveLiberacion";

            //resultado
            return this.ListarObjetos(iScript);
        }
        #endregion

    }
}
