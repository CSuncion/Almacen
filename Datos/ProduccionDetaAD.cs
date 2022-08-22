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
    public class ProduccionDetaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<ProduccionDetaEN> xLista = new List<ProduccionDetaEN>();
        private ProduccionDetaEN xObj = new ProduccionDetaEN();
        private string xTabla = "ProduccionDeta";
        private string xVista = "VsProduccionDeta";

        #endregion
        
        #region Metodos privados

        private ProduccionDetaEN Objeto(IDataReader iDr)
        {
            ProduccionDetaEN xObjEnc = new ProduccionDetaEN();
            xObjEnc.ClaveProduccionDeta = iDr[ProduccionDetaEN.ClaProDet].ToString();
            xObjEnc.ClaveProduccionCabe = iDr[ProduccionDetaEN.ClaProCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[ProduccionDetaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[ProduccionDetaEN.NomEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[ProduccionDetaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[ProduccionDetaEN.DesAlm].ToString();
            xObjEnc.CorrelativoProduccionCabe = iDr[ProduccionDetaEN.CorProCab].ToString();
            xObjEnc.CorrelativoProduccionDeta = iDr[ProduccionDetaEN.CorProDet].ToString();
            xObjEnc.CodigoExistencia = iDr[ProduccionDetaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[ProduccionDetaEN.DesExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[ProduccionDetaEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[ProduccionDetaEN.NomUniMed].ToString();
            xObjEnc.CodigoTipoOperacion = iDr[ProduccionDetaEN.CodTipOpe].ToString();
            xObjEnc.DescripcionTipoOperacion = iDr[ProduccionDetaEN.DesTipOpe].ToString();
            xObjEnc.FechaProduccionDeta = Fecha.ObtenerDiaMesAno(iDr[ProduccionDetaEN.FecProDet]);
            xObjEnc.PeriodoProduccionDeta = iDr[ProduccionDetaEN.PerProDet].ToString();
            xObjEnc.FechaSalidaFaseMasa = Fecha.ObtenerDiaMesAno(iDr[ProduccionDetaEN.FecSalFasMas]);
            xObjEnc.FechaSalidaFaseControlCalidad = Fecha.ObtenerDiaMesAno(iDr[ProduccionDetaEN.FecSalFasConCal]);
            xObjEnc.FechaSalidaFaseEmpaquetado = Fecha.ObtenerDiaMesAno(iDr[ProduccionDetaEN.FecSalFasEmp]);
            xObjEnc.FechaIngresoAlmacen = Fecha.ObtenerDiaMesAno(iDr[ProduccionDetaEN.FecIngAlm]);
            xObjEnc.SaldoProduccionCabe = Convert.ToDecimal(iDr[ProduccionDetaEN.SalProCab].ToString());
            xObjEnc.CantidadProduccionDeta = Convert.ToDecimal(iDr[ProduccionDetaEN.CanProDet].ToString());
            xObjEnc.CantidadRealProduccion = Convert.ToDecimal(iDr[ProduccionDetaEN.CanReaPro].ToString());
            xObjEnc.ObservacionProduccionDeta = iDr[ProduccionDetaEN.ObsProDet].ToString();
            xObjEnc.ClaveSalidaFaseMasa = iDr[ProduccionDetaEN.ClaSalFasMas].ToString();
            xObjEnc.ClaveSalidaFaseControlCalidad = iDr[ProduccionDetaEN.ClaSalFasConCal].ToString();
            xObjEnc.ClaveSalidaFaseEmpaquetado = iDr[ProduccionDetaEN.ClaSalFasEmp].ToString();
            xObjEnc.ClaveIngresoMovimientoCabe = iDr[ProduccionDetaEN.ClaIngMovCab].ToString();
            xObjEnc.CodigoMercaderia = iDr[ProduccionDetaEN.CodMer].ToString();
            xObjEnc.CodigoAlmacenSemiProducto = iDr[ProduccionDetaEN.CodAlmSemPro].ToString();
            xObjEnc.CodigoSemiProducto = iDr[ProduccionDetaEN.CodSemPro].ToString();
            xObjEnc.DescripcionSemiProducto = iDr[ProduccionDetaEN.DesSemPro].ToString();
            xObjEnc.CodigoAlmacenEmpaquetado = iDr[ProduccionDetaEN.CodAlmEmp].ToString();
            xObjEnc.DescripcionAlmacenEmpaquetado = iDr[ProduccionDetaEN.DesAlmEmp].ToString();
            xObjEnc.RatioFormulaCabe = Convert.ToDecimal(iDr[ProduccionDetaEN.RatForCab].ToString());
            xObjEnc.CEsExacto = iDr[ProduccionDetaEN.CEsExa].ToString();
            xObjEnc.CostoTotalProducto = Convert.ToDecimal(iDr[ProduccionDetaEN.CosTotPro].ToString());
            xObjEnc.CostoMasaPrincipal = Convert.ToDecimal(iDr[ProduccionDetaEN.CosMasPri].ToString());
            xObjEnc.CostoMasaAdicional = Convert.ToDecimal(iDr[ProduccionDetaEN.CosMasAdi].ToString());
            xObjEnc.CostoMasaDevolucion = Convert.ToDecimal(iDr[ProduccionDetaEN.CosMasDev].ToString());
            xObjEnc.CostoMasaTotal = Convert.ToDecimal(iDr[ProduccionDetaEN.CosMasTot].ToString());
            xObjEnc.MasaProducida = Convert.ToDecimal(iDr[ProduccionDetaEN.MasPro].ToString());
            xObjEnc.MasaUnidad = Convert.ToDecimal(iDr[ProduccionDetaEN.MasUni].ToString());
            xObjEnc.NumeroUnidadesMasa = Convert.ToDecimal(iDr[ProduccionDetaEN.NumUniMas].ToString());
            xObjEnc.CostoUnidadMasa = Convert.ToDecimal(iDr[ProduccionDetaEN.CosUniMas].ToString());
            xObjEnc.MasaPerdida = Convert.ToDecimal(iDr[ProduccionDetaEN.MasPer].ToString());
            xObjEnc.CostoMasaPerdida = Convert.ToDecimal(iDr[ProduccionDetaEN.CosMasPer].ToString());      
            xObjEnc.CostoConCalPrincipal = Convert.ToDecimal(iDr[ProduccionDetaEN.CosConCalPri].ToString());
            xObjEnc.CostoConCalAdicional = Convert.ToDecimal(iDr[ProduccionDetaEN.CosConCalAdi].ToString());
            xObjEnc.CostoConCalDevolucion = Convert.ToDecimal(iDr[ProduccionDetaEN.CosConCalDev].ToString());
            xObjEnc.CostoConCalTotal = Convert.ToDecimal(iDr[ProduccionDetaEN.CosConCalTot].ToString());
            xObjEnc.NumeroUnidadesConCal = Convert.ToDecimal(iDr[ProduccionDetaEN.NumUniConCal].ToString());
            xObjEnc.NumeroUnidadesNoPasanConCal = Convert.ToDecimal(iDr[ProduccionDetaEN.NumUniNoPasConCal].ToString());
            xObjEnc.CostoUnidadConCal = Convert.ToDecimal(iDr[ProduccionDetaEN.CosUniConCal].ToString());
            xObjEnc.NumeroUnidadesProduccionAnterior = Convert.ToDecimal(iDr[ProduccionDetaEN.NumUniProAnt].ToString());
            xObjEnc.ClaveSalidaUnidadesEmpacar = iDr[ProduccionDetaEN.ClaSalUniEmp].ToString();
            xObjEnc.ClaveSalidaNoPasan = iDr[ProduccionDetaEN.ClaSalNoPas].ToString();
            xObjEnc.ClaveIngresoNoPasan = iDr[ProduccionDetaEN.ClaIngNoPas].ToString();
            xObjEnc.UnidadesPorCaja = Convert.ToDecimal(iDr[ProduccionDetaEN.UniPorCaj].ToString());
            xObjEnc.NumeroCajas = Convert.ToDecimal(iDr[ProduccionDetaEN.NumCaj].ToString());
            xObjEnc.NumeroUnidadesSueltas = Convert.ToDecimal(iDr[ProduccionDetaEN.NumUniSue].ToString());
            xObjEnc.ClaveIngresoSemiElaborado = iDr[ProduccionDetaEN.ClaIngSemEla].ToString();
            xObjEnc.CostoEmpaquetadoSemElaPrincipal = Convert.ToDecimal(iDr[ProduccionDetaEN.CosEmpSemElaPri].ToString());
            xObjEnc.CostoEmpaquetadoSemElaAdicional = Convert.ToDecimal(iDr[ProduccionDetaEN.CosEmpSemElaAdi].ToString());
            xObjEnc.CostoEmpaquetadoSemElaDevolucion = Convert.ToDecimal(iDr[ProduccionDetaEN.CosEmpSemElaDev].ToString());
            xObjEnc.CostoEmpaquetadoSemElaTotal = Convert.ToDecimal(iDr[ProduccionDetaEN.CosEmpSemElaTot].ToString());
            xObjEnc.CostoUnidadEmpaquetadoSemEla = Convert.ToDecimal(iDr[ProduccionDetaEN.CosUniEmpSemEla].ToString());
            xObjEnc.CostoUnidadEmpaquetadoProTer = Convert.ToDecimal(iDr[ProduccionDetaEN.CosUniEmpProTer].ToString());
            xObjEnc.CostoUnidadTotalSemEla = Convert.ToDecimal(iDr[ProduccionDetaEN.CosUniTotSemEla].ToString());            
            xObjEnc.NumeroUnidadesAEmpaquetar = Convert.ToDecimal(iDr[ProduccionDetaEN.NumUniAEmp].ToString());
            xObjEnc.CostoInsumos = Convert.ToDecimal(iDr[ProduccionDetaEN.CosIns].ToString());
            xObjEnc.CostoManoObra = Convert.ToDecimal(iDr[ProduccionDetaEN.CosManObr].ToString());
            xObjEnc.CostoOtros = Convert.ToDecimal(iDr[ProduccionDetaEN.CosOtr].ToString());
            xObjEnc.UnidadesDesechaEmpaquetado = Convert.ToDecimal(iDr[ProduccionDetaEN.UniDesEmp].ToString());
            xObjEnc.UnidadesDevueltaEmpaquetado = Convert.ToDecimal(iDr[ProduccionDetaEN.UniDevEmp].ToString());
            xObjEnc.ObservacionMasaPerdida = iDr[ProduccionDetaEN.ObsMasPer].ToString();
            xObjEnc.UnidadesReproceso = Convert.ToDecimal(iDr[ProduccionDetaEN.UniRep].ToString());
            xObjEnc.CostoUnidadesReproceso = Convert.ToDecimal(iDr[ProduccionDetaEN.CosUniRep].ToString());
            xObjEnc.ClaveSalidaUnidadesReproceso = iDr[ProduccionDetaEN.ClaSalUniRep].ToString();
            xObjEnc.UnidadesParaReproceso = Convert.ToDecimal(iDr[ProduccionDetaEN.UniParRep].ToString());
            xObjEnc.NumeroUnidadesSemiElaborado = Convert.ToDecimal(iDr[ProduccionDetaEN.NumUniSemEla].ToString());
            xObjEnc.NumeroTransferenciaAutomatica = iDr[ProduccionDetaEN.NumTraAut].ToString();
            xObjEnc.ClaveSalidaTransferenciaReproceso = iDr[ProduccionDetaEN.ClaSalTraRep].ToString();
            xObjEnc.ClaveIngresoTransferenciaReproceso = iDr[ProduccionDetaEN.ClaIngTraRep].ToString();
            xObjEnc.CTurno = iDr[ProduccionDetaEN.CTur].ToString();
            xObjEnc.NTurno = iDr[ProduccionDetaEN.NTur].ToString();
            xObjEnc.SaldoUnidadesAEmpacar = Convert.ToDecimal(iDr[ProduccionDetaEN.SalUniAEmp].ToString());
            xObjEnc.UnidadesDonacion = Convert.ToDecimal(iDr[ProduccionDetaEN.UniDon].ToString());
            xObjEnc.ClaveSalidaTransferenciaDonacion = iDr[ProduccionDetaEN.ClaSalTraDon].ToString();
            xObjEnc.ClaveIngresoTransferenciaDonacion = iDr[ProduccionDetaEN.ClaIngTraDon].ToString();
            xObjEnc.SaldoLiberacion = Convert.ToDecimal(iDr[ProduccionDetaEN.SalLib].ToString());
            xObjEnc.UnidadesAprobadasLiberacion = Convert.ToDecimal(iDr[ProduccionDetaEN.UniAprLib].ToString());
            xObjEnc.UnidadesSaldoLiberacion = Convert.ToDecimal(iDr[ProduccionDetaEN.UniSalLib].ToString());
            xObjEnc.UnidadesObservadasLiberacion = Convert.ToDecimal(iDr[ProduccionDetaEN.UniObsLib].ToString());
            xObjEnc.UnidadesReprocesoLiberacion = Convert.ToDecimal(iDr[ProduccionDetaEN.UniRepLib].ToString());
            xObjEnc.UnidadesDonacionLiberacion = Convert.ToDecimal(iDr[ProduccionDetaEN.UniDonLib].ToString());
            xObjEnc.UnidadesMuestraLiberacion = Convert.ToDecimal(iDr[ProduccionDetaEN.UniMueLib].ToString());
            xObjEnc.UnidadesDesechasLiberacion = Convert.ToDecimal(iDr[ProduccionDetaEN.UniDesLib].ToString());
            xObjEnc.PorcentajeRango = Convert.ToDecimal(iDr[ProduccionDetaEN.PorRan].ToString());
            xObjEnc.CantidadRango = Convert.ToDecimal(iDr[ProduccionDetaEN.CanRan].ToString());
            xObjEnc.ClaveIngresoDesmedroEnvasado = iDr[ProduccionDetaEN.ClaIngDesEnv].ToString();
            xObjEnc.FactorProduccionProDet = Convert.ToDecimal(iDr[ProduccionDetaEN.FacProProDet].ToString());
            xObjEnc.RatioProduccionProDet = Convert.ToDecimal(iDr[ProduccionDetaEN.RatProProDet].ToString());
            xObjEnc.HorasHombre = Convert.ToDecimal(iDr[ProduccionDetaEN.HorHom].ToString());
            xObjEnc.CostoTotalManoObra = Convert.ToDecimal(iDr[ProduccionDetaEN.CosTotManObr].ToString());
            xObjEnc.FactorCIFFijo = Convert.ToDecimal(iDr[ProduccionDetaEN.FacCIFFij].ToString());
            xObjEnc.CostoCIFFijo = Convert.ToDecimal(iDr[ProduccionDetaEN.CosCIFFij].ToString());
            xObjEnc.FactorCIFVariable = Convert.ToDecimal(iDr[ProduccionDetaEN.FacCIFVar].ToString());
            xObjEnc.CostoCIFVariable = Convert.ToDecimal(iDr[ProduccionDetaEN.CosCIFVar].ToString());
            xObjEnc.CantidadSinceradoProduccionDeta = Convert.ToDecimal(iDr[ProduccionDetaEN.CanSinProDet].ToString());
            xObjEnc.PorcentajeSinceradoRango = Convert.ToDecimal(iDr[ProduccionDetaEN.PorSinRan].ToString());
            xObjEnc.CantidadSinceradoRango = Convert.ToDecimal(iDr[ProduccionDetaEN.CanSinRan].ToString());
            xObjEnc.DetalleMotivoSincerado = iDr[ProduccionDetaEN.DetMotSin].ToString();
            xObjEnc.ClavesTransferenciaSincerado = iDr[ProduccionDetaEN.ClaTraSin].ToString();
            xObjEnc.CantidadEncajonar = Convert.ToDecimal(iDr[ProduccionDetaEN.CanEnc].ToString());
            xObjEnc.CantidadBloquear = Convert.ToDecimal(iDr[ProduccionDetaEN.CanBlo].ToString());
            xObjEnc.SaldoLiberacionBloqueadas = Convert.ToDecimal(iDr[ProduccionDetaEN.SalLibBlo].ToString());
            xObjEnc.ClaveIngresoSemElaBloqueadas = iDr[ProduccionDetaEN.ClaIngSemElaBlo].ToString();
            xObjEnc.CantidadContraMuestra = Convert.ToDecimal(iDr[ProduccionDetaEN.CanConMue].ToString());
            xObjEnc.ClaveIngresoSemElaContraMuestra = iDr[ProduccionDetaEN.ClaIngSemElaConMue].ToString();
            xObjEnc.CantidadCuarentenaQali = Convert.ToDecimal(iDr[ProduccionDetaEN.CanCuaQal].ToString());
            xObjEnc.CantidadReprocesoQali = Convert.ToDecimal(iDr[ProduccionDetaEN.CanRepQal].ToString());
            xObjEnc.CantidadMuestraQali = Convert.ToDecimal(iDr[ProduccionDetaEN.CanMueQal].ToString());
            xObjEnc.CantidadDesechoQali = Convert.ToDecimal(iDr[ProduccionDetaEN.CanDesQal].ToString());
            xObjEnc.SaldoLiberacionCuarentenaQali = Convert.ToDecimal(iDr[ProduccionDetaEN.SalLibCuaQal].ToString());
            xObjEnc.ClaveIngresoCuarentenaQali = iDr[ProduccionDetaEN.ClaIngCuaQal].ToString();
            xObjEnc.ClaveIngresoReprocesoQali = iDr[ProduccionDetaEN.ClaIngRepQal].ToString();
            xObjEnc.ClaveIngresoMuestraQali = iDr[ProduccionDetaEN.ClaIngMueQal].ToString();
            xObjEnc.ClaveIngresoDesechoQali = iDr[ProduccionDetaEN.ClaIngDesQal].ToString();
            xObjEnc.ClaveSalidaEtiquetaQali = iDr[ProduccionDetaEN.ClaSalEtiQal].ToString();
            xObjEnc.CManejaCuarentena = iDr[ProduccionDetaEN.CManCua].ToString();
            xObjEnc.DetalleMotivoReprocesoQali = iDr[ProduccionDetaEN.DetMovRepQal].ToString();
            xObjEnc.DetalleMotivoMuestraQali = iDr[ProduccionDetaEN.DetMovMueQal].ToString();
            xObjEnc.DetalleMotivoDesechoQali = iDr[ProduccionDetaEN.DetMovDesQal].ToString();
            xObjEnc.DetalleMotivoMuestraPreLiberacion = iDr[ProduccionDetaEN.DetMovMuePreLib].ToString();
            xObjEnc.DetalleMotivoBloqueadosPreLiberacion = iDr[ProduccionDetaEN.DetMovBloPreLib].ToString();
            xObjEnc.CantidadUnidadesPackingAdicionalesBlo = Convert.ToDecimal(iDr[ProduccionDetaEN.CanUniPacAdiBlo].ToString());
            xObjEnc.SaldoLiberacionObservadas = Convert.ToDecimal(iDr[ProduccionDetaEN.SalLibObs].ToString());
            xObjEnc.CantidadUnidadesPackingAdicionalesObs = Convert.ToDecimal(iDr[ProduccionDetaEN.CanUniPacAdiObs].ToString());
            xObjEnc.CantidadMuestraProduccion = Convert.ToDecimal(iDr[ProduccionDetaEN.CanMuePro].ToString());
            xObjEnc.DetalleMotivoMuestraProduccion = iDr[ProduccionDetaEN.DetMovMuePro].ToString();
            xObjEnc.ClaveIngresoSemElaMuestraProduccion = iDr[ProduccionDetaEN.ClaIngSemElaMuePro].ToString();
            xObjEnc.CEstadoProduccionDeta = iDr[ProduccionDetaEN.CEstProDet].ToString();
            xObjEnc.NEstadoProduccionDeta = iDr[ProduccionDetaEN.NEstProDet].ToString();
            xObjEnc.UsuarioAgrega = iDr[ProduccionDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ProduccionDetaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[ProduccionDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ProduccionDetaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveProduccionDeta;
            return xObjEnc;
        }

        private List<ProduccionDetaEN> ListarObjetos(string pScript)
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

        private ProduccionDetaEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, ProduccionDetaEN.CorProDet);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CorProCab, SqlSelect.Operador.Igual, pObj.CorrelativoProduccionCabe);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumnaNumeroTransferenciaAutomatica()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, ProduccionDetaEN.NumTraAut);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AdicionarProduccionDeta(ProduccionDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(ProduccionDetaEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(ProduccionDetaEN.ClaProCab, pObj.ClaveProduccionCabe);
            xIns.AsignarParametro(ProduccionDetaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(ProduccionDetaEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(ProduccionDetaEN.CorProCab, pObj.CorrelativoProduccionCabe);
            xIns.AsignarParametro(ProduccionDetaEN.CorProDet, pObj.CorrelativoProduccionDeta);
            xIns.AsignarParametro(ProduccionDetaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(ProduccionDetaEN.CodUniMed, pObj.CodigoUnidadMedida);
            xIns.AsignarParametro(ProduccionDetaEN.CodTipOpe, pObj.CodigoTipoOperacion);
            xIns.AsignarParametro(ProduccionDetaEN.FecProDet, Fecha.ObtenerAnoMesDia(pObj.FechaProduccionDeta));
            xIns.AsignarParametro(ProduccionDetaEN.PerProDet, pObj.PeriodoProduccionDeta);
            xIns.AsignarParametro(ProduccionDetaEN.FecSalFasMas, Fecha.ObtenerAnoMesDia(pObj.FechaSalidaFaseMasa));
            xIns.AsignarParametro(ProduccionDetaEN.FecSalFasConCal, Fecha.ObtenerAnoMesDia(pObj.FechaSalidaFaseControlCalidad));
            xIns.AsignarParametro(ProduccionDetaEN.FecSalFasEmp, Fecha.ObtenerAnoMesDia(pObj.FechaSalidaFaseEmpaquetado));
            xIns.AsignarParametro(ProduccionDetaEN.FecIngAlm, Fecha.ObtenerAnoMesDia(pObj.FechaIngresoAlmacen));
            xIns.AsignarParametro(ProduccionDetaEN.SalProCab, pObj.SaldoProduccionCabe.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanProDet,  pObj.CantidadProduccionDeta.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanReaPro, pObj.CantidadRealProduccion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ObsProDet, pObj.ObservacionProduccionDeta);
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalFasMas, pObj.ClaveSalidaFaseMasa);
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalFasConCal, pObj.ClaveSalidaFaseControlCalidad);
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalFasEmp, pObj.ClaveSalidaFaseEmpaquetado);
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngMovCab, pObj.ClaveIngresoMovimientoCabe);
            xIns.AsignarParametro(ProduccionDetaEN.CodMer, pObj.CodigoMercaderia);
            xIns.AsignarParametro(ProduccionDetaEN.CEsExa, pObj.CEsExacto);
            xIns.AsignarParametro(ProduccionDetaEN.CosTotPro, pObj.CostoTotalProducto.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosMasPri, pObj.CostoMasaPrincipal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosMasAdi, pObj.CostoMasaAdicional.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosMasDev, pObj.CostoMasaDevolucion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosMasTot, pObj.CostoMasaTotal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.MasPro, pObj.MasaProducida.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.MasUni, pObj.MasaUnidad.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.NumUniMas, pObj.NumeroUnidadesMasa.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosUniMas, pObj.CostoUnidadMasa.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.MasPer, pObj.MasaPerdida.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosMasPer, pObj.CostoMasaPerdida.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosConCalPri, pObj.CostoConCalPrincipal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosConCalAdi, pObj.CostoConCalAdicional.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosConCalDev, pObj.CostoConCalDevolucion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosConCalTot, pObj.CostoConCalTotal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.NumUniConCal, pObj.NumeroUnidadesConCal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.NumUniNoPasConCal, pObj.NumeroUnidadesNoPasanConCal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosUniConCal, pObj.CostoUnidadConCal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.NumUniProAnt, pObj.NumeroUnidadesProduccionAnterior.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalUniEmp, pObj.ClaveSalidaUnidadesEmpacar);
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalNoPas, pObj.ClaveSalidaNoPasan);
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngNoPas, pObj.ClaveIngresoNoPasan);
            xIns.AsignarParametro(ProduccionDetaEN.UniPorCaj, pObj.UnidadesPorCaja.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.NumCaj, pObj.NumeroCajas.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.NumUniSue, pObj.NumeroUnidadesSueltas.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngSemEla, pObj.ClaveIngresoSemiElaborado);
            xIns.AsignarParametro(ProduccionDetaEN.CosEmpSemElaPri, pObj.CostoEmpaquetadoSemElaPrincipal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosEmpSemElaAdi, pObj.CostoEmpaquetadoSemElaAdicional.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosEmpSemElaDev, pObj.CostoEmpaquetadoSemElaDevolucion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosEmpSemElaTot, pObj.CostoEmpaquetadoSemElaTotal.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosUniEmpSemEla, pObj.CostoUnidadEmpaquetadoSemEla.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosUniEmpProTer, pObj.CostoUnidadEmpaquetadoProTer.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosUniTotSemEla, pObj.CostoUnidadTotalSemEla.ToString());           
            xIns.AsignarParametro(ProduccionDetaEN.NumUniAEmp, pObj.NumeroUnidadesAEmpaquetar.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosIns, pObj.CostoInsumos.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosManObr, pObj.CostoManoObra.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosOtr, pObj.CostoOtros.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniDesEmp, pObj.UnidadesDesechaEmpaquetado.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniDevEmp, pObj.UnidadesDevueltaEmpaquetado.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ObsMasPer, pObj.ObservacionMasaPerdida);
            xIns.AsignarParametro(ProduccionDetaEN.UniRep, pObj.UnidadesReproceso.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosUniRep, pObj.CostoUnidadesReproceso.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalUniRep, pObj.ClaveSalidaUnidadesReproceso);
            xIns.AsignarParametro(ProduccionDetaEN.UniParRep, pObj.UnidadesParaReproceso.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.NumUniSemEla, pObj.NumeroUnidadesSemiElaborado.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.NumTraAut, pObj.NumeroTransferenciaAutomatica);
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalTraRep, pObj.ClaveSalidaTransferenciaReproceso);
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngTraRep, pObj.ClaveIngresoTransferenciaReproceso);
            xIns.AsignarParametro(ProduccionDetaEN.CTur, pObj.CTurno);
            xIns.AsignarParametro(ProduccionDetaEN.SalUniAEmp, pObj.SaldoUnidadesAEmpacar.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniDon, pObj.UnidadesDonacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalTraDon, pObj.ClaveSalidaTransferenciaDonacion);
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngTraDon, pObj.ClaveIngresoTransferenciaDonacion);
            xIns.AsignarParametro(ProduccionDetaEN.SalLib, pObj.SaldoLiberacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniAprLib, pObj.UnidadesAprobadasLiberacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniSalLib, pObj.UnidadesSaldoLiberacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniObsLib, pObj.UnidadesObservadasLiberacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniRepLib, pObj.UnidadesReprocesoLiberacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniDonLib, pObj.UnidadesDonacionLiberacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniMueLib, pObj.UnidadesMuestraLiberacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.UniDesLib, pObj.UnidadesDesechasLiberacion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.PorRan, pObj.PorcentajeRango.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanRan, pObj.CantidadRango.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngDesEnv, pObj.ClaveIngresoDesmedroEnvasado);
            xIns.AsignarParametro(ProduccionDetaEN.FacProProDet, pObj.FactorProduccionProDet.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.RatProProDet, pObj.RatioProduccionProDet.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.HorHom, pObj.HorasHombre.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosTotManObr, pObj.CostoTotalManoObra.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.FacCIFFij, pObj.FactorCIFFijo.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosCIFFij, pObj.CostoCIFFijo.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.FacCIFVar, pObj.FactorCIFVariable.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CosCIFVar, pObj.CostoCIFVariable.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanSinProDet, pObj.CantidadSinceradoProduccionDeta.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.PorSinRan, pObj.PorcentajeSinceradoRango.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanSinRan, pObj.CantidadSinceradoRango.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.DetMotSin, pObj.DetalleMotivoSincerado);
            xIns.AsignarParametro(ProduccionDetaEN.ClaTraSin, pObj.ClavesTransferenciaSincerado);
            xIns.AsignarParametro(ProduccionDetaEN.CanEnc, pObj.CantidadEncajonar.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanBlo, pObj.CantidadBloquear.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.SalLibBlo, pObj.SaldoLiberacionBloqueadas.ToString());            
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngSemElaBlo, pObj.ClaveIngresoSemElaBloqueadas);
            xIns.AsignarParametro(ProduccionDetaEN.CanConMue, pObj.CantidadContraMuestra.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngSemElaConMue, pObj.ClaveIngresoSemElaContraMuestra);
            xIns.AsignarParametro(ProduccionDetaEN.CanCuaQal, pObj.CantidadCuarentenaQali.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanRepQal, pObj.CantidadReprocesoQali.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanMueQal, pObj.CantidadMuestraQali.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanDesQal, pObj.CantidadDesechoQali.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.SalLibCuaQal, pObj.SaldoLiberacionCuarentenaQali.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngCuaQal, pObj.ClaveIngresoCuarentenaQali);
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngRepQal, pObj.ClaveIngresoReprocesoQali);
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngMueQal, pObj.ClaveIngresoMuestraQali);
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngDesQal, pObj.ClaveIngresoDesechoQali);
            xIns.AsignarParametro(ProduccionDetaEN.ClaSalEtiQal, pObj.ClaveSalidaEtiquetaQali);
            xIns.AsignarParametro(ProduccionDetaEN.DetMovRepQal, pObj.DetalleMotivoReprocesoQali);
            xIns.AsignarParametro(ProduccionDetaEN.DetMovMueQal, pObj.DetalleMotivoMuestraQali);
            xIns.AsignarParametro(ProduccionDetaEN.DetMovDesQal, pObj.DetalleMotivoDesechoQali);
            xIns.AsignarParametro(ProduccionDetaEN.DetMovMuePreLib, pObj.DetalleMotivoMuestraPreLiberacion);
            xIns.AsignarParametro(ProduccionDetaEN.DetMovBloPreLib, pObj.DetalleMotivoBloqueadosPreLiberacion);
            xIns.AsignarParametro(ProduccionDetaEN.CanUniPacAdiBlo, pObj.CantidadUnidadesPackingAdicionalesBlo.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.SalLibObs, pObj.SaldoLiberacionObservadas.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanUniPacAdiObs, pObj.CantidadUnidadesPackingAdicionalesObs.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.CanMuePro, pObj.CantidadMuestraProduccion.ToString());
            xIns.AsignarParametro(ProduccionDetaEN.DetMovMuePro, pObj.DetalleMotivoMuestraProduccion);
            xIns.AsignarParametro(ProduccionDetaEN.ClaIngSemElaMuePro, pObj.ClaveIngresoSemElaMuestraProduccion);
            xIns.AsignarParametro(ProduccionDetaEN.CEstProDet, pObj.CEstadoProduccionDeta);
            xIns.AsignarParametro(ProduccionDetaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ProduccionDetaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(ProduccionDetaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ProduccionDetaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarProduccionDeta(List<ProduccionDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(ProduccionDetaEN.ClaProDet, xProDet.ClaveProduccionDeta);
                xIns.AsignarParametro(ProduccionDetaEN.ClaProCab, xProDet.ClaveProduccionCabe);
                xIns.AsignarParametro(ProduccionDetaEN.CodEmp, xProDet.CodigoEmpresa);
                xIns.AsignarParametro(ProduccionDetaEN.CodAlm, xProDet.CodigoAlmacen);
                xIns.AsignarParametro(ProduccionDetaEN.CorProCab, xProDet.CorrelativoProduccionCabe);
                xIns.AsignarParametro(ProduccionDetaEN.CorProDet, xProDet.CorrelativoProduccionDeta);
                xIns.AsignarParametro(ProduccionDetaEN.CodExi, xProDet.CodigoExistencia);
                xIns.AsignarParametro(ProduccionDetaEN.CodUniMed, xProDet.CodigoUnidadMedida);
                xIns.AsignarParametro(ProduccionDetaEN.CodTipOpe, xProDet.CodigoTipoOperacion);
                xIns.AsignarParametro(ProduccionDetaEN.FecProDet, Fecha.ObtenerAnoMesDia(xProDet.FechaProduccionDeta));
                xIns.AsignarParametro(ProduccionDetaEN.PerProDet, xProDet.PeriodoProduccionDeta);
                xIns.AsignarParametro(ProduccionDetaEN.FecSalFasMas, Fecha.ObtenerAnoMesDia(xProDet.FechaSalidaFaseMasa));
                xIns.AsignarParametro(ProduccionDetaEN.FecSalFasConCal, Fecha.ObtenerAnoMesDia(xProDet.FechaSalidaFaseControlCalidad));
                xIns.AsignarParametro(ProduccionDetaEN.FecSalFasEmp, Fecha.ObtenerAnoMesDia(xProDet.FechaSalidaFaseEmpaquetado));
                xIns.AsignarParametro(ProduccionDetaEN.FecIngAlm, Fecha.ObtenerAnoMesDia(xProDet.FechaIngresoAlmacen));
                xIns.AsignarParametro(ProduccionDetaEN.SalProCab, xProDet.SaldoProduccionCabe.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanProDet, xProDet.CantidadProduccionDeta.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanReaPro, xProDet.CantidadRealProduccion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ObsProDet, xProDet.ObservacionProduccionDeta);
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalFasMas, xProDet.ClaveSalidaFaseMasa);
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalFasConCal, xProDet.ClaveSalidaFaseControlCalidad);
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalFasEmp, xProDet.ClaveSalidaFaseEmpaquetado);
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngMovCab, xProDet.ClaveIngresoMovimientoCabe);
                xIns.AsignarParametro(ProduccionDetaEN.CodMer, xProDet.CodigoMercaderia);
                xIns.AsignarParametro(ProduccionDetaEN.CEsExa, xProDet.CEsExacto);
                xIns.AsignarParametro(ProduccionDetaEN.CosTotPro, xProDet.CostoTotalProducto.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosMasPri, xProDet.CostoMasaPrincipal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosMasAdi, xProDet.CostoMasaAdicional.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosMasDev, xProDet.CostoMasaDevolucion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosMasTot, xProDet.CostoMasaTotal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.MasPro, xProDet.MasaProducida.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.MasUni, xProDet.MasaUnidad.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumUniMas, xProDet.NumeroUnidadesMasa.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosUniMas, xProDet.CostoUnidadMasa.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.MasPer, xProDet.MasaPerdida.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosMasPer, xProDet.CostoMasaPerdida.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosConCalPri, xProDet.CostoConCalPrincipal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosConCalAdi, xProDet.CostoConCalAdicional.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosConCalDev, xProDet.CostoConCalDevolucion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosConCalTot, xProDet.CostoConCalTotal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumUniConCal, xProDet.NumeroUnidadesConCal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumUniNoPasConCal, xProDet.NumeroUnidadesNoPasanConCal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosUniConCal, xProDet.CostoUnidadConCal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumUniProAnt, xProDet.NumeroUnidadesProduccionAnterior.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalUniEmp, xProDet.ClaveSalidaUnidadesEmpacar);
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalNoPas, xProDet.ClaveSalidaNoPasan);
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngNoPas, xProDet.ClaveIngresoNoPasan);
                xIns.AsignarParametro(ProduccionDetaEN.UniPorCaj, xProDet.UnidadesPorCaja.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumCaj, xProDet.NumeroCajas.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumUniSue, xProDet.NumeroUnidadesSueltas.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngSemEla, xProDet.ClaveIngresoSemiElaborado);
                xIns.AsignarParametro(ProduccionDetaEN.CosEmpSemElaPri, xProDet.CostoEmpaquetadoSemElaPrincipal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosEmpSemElaAdi, xProDet.CostoEmpaquetadoSemElaAdicional.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosEmpSemElaDev, xProDet.CostoEmpaquetadoSemElaDevolucion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosEmpSemElaTot, xProDet.CostoEmpaquetadoSemElaTotal.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosUniEmpSemEla, xProDet.CostoUnidadEmpaquetadoSemEla.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosUniEmpProTer, xProDet.CostoUnidadEmpaquetadoProTer.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosUniTotSemEla, xProDet.CostoUnidadTotalSemEla.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumUniAEmp, xProDet.NumeroUnidadesAEmpaquetar.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosIns, xProDet.CostoInsumos.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosManObr, xProDet.CostoManoObra.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosOtr, xProDet.CostoOtros.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniDesEmp, xProDet.UnidadesDesechaEmpaquetado.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniDevEmp, xProDet.UnidadesDevueltaEmpaquetado.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ObsMasPer, xProDet.ObservacionMasaPerdida);
                xIns.AsignarParametro(ProduccionDetaEN.UniRep, xProDet.UnidadesReproceso.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosUniRep, xProDet.CostoUnidadesReproceso.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalUniRep, xProDet.ClaveSalidaUnidadesReproceso);
                xIns.AsignarParametro(ProduccionDetaEN.UniParRep, xProDet.UnidadesParaReproceso.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumUniSemEla, xProDet.NumeroUnidadesSemiElaborado.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.NumTraAut, xProDet.NumeroTransferenciaAutomatica);
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalTraRep, xProDet.ClaveSalidaTransferenciaReproceso);
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngTraRep, xProDet.ClaveIngresoTransferenciaReproceso);
                xIns.AsignarParametro(ProduccionDetaEN.CTur, xProDet.CTurno);
                xIns.AsignarParametro(ProduccionDetaEN.SalUniAEmp, xProDet.SaldoUnidadesAEmpacar.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniDon, xProDet.UnidadesDonacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalTraDon, xProDet.ClaveSalidaTransferenciaDonacion);
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngTraDon, xProDet.ClaveIngresoTransferenciaDonacion);
                xIns.AsignarParametro(ProduccionDetaEN.SalLib, xProDet.SaldoLiberacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniAprLib, xProDet.UnidadesAprobadasLiberacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniSalLib, xProDet.UnidadesSaldoLiberacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniObsLib, xProDet.UnidadesObservadasLiberacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniRepLib, xProDet.UnidadesReprocesoLiberacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniDonLib, xProDet.UnidadesDonacionLiberacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniMueLib, xProDet.UnidadesMuestraLiberacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.UniDesLib, xProDet.UnidadesDesechasLiberacion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.PorRan, xProDet.PorcentajeRango.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanRan, xProDet.CantidadRango.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngDesEnv, xProDet.ClaveIngresoDesmedroEnvasado);
                xIns.AsignarParametro(ProduccionDetaEN.FacProProDet, xProDet.FactorProduccionProDet.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.RatProProDet, xProDet.RatioProduccionProDet.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.HorHom, xProDet.HorasHombre.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosTotManObr, xProDet.CostoTotalManoObra.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.FacCIFFij, xProDet.FactorCIFFijo.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosCIFFij, xProDet.CostoCIFFijo.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.FacCIFVar, xProDet.FactorCIFVariable.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CosCIFVar, xProDet.CostoCIFVariable.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanSinProDet, xProDet.CantidadSinceradoProduccionDeta.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.PorSinRan, xProDet.PorcentajeSinceradoRango.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanSinRan, xProDet.CantidadSinceradoRango.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.DetMotSin, xProDet.DetalleMotivoSincerado);
                xIns.AsignarParametro(ProduccionDetaEN.ClaTraSin, xProDet.ClavesTransferenciaSincerado);
                xIns.AsignarParametro(ProduccionDetaEN.CanEnc, xProDet.CantidadEncajonar.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanBlo, xProDet.CantidadBloquear.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.SalLibBlo, xProDet.SaldoLiberacionBloqueadas.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngSemElaBlo, xProDet.ClaveIngresoSemElaBloqueadas);
                xIns.AsignarParametro(ProduccionDetaEN.CanConMue, xProDet.CantidadContraMuestra.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngSemElaConMue, xProDet.ClaveIngresoSemElaContraMuestra);
                xIns.AsignarParametro(ProduccionDetaEN.CanCuaQal, xProDet.CantidadCuarentenaQali.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanRepQal, xProDet.CantidadReprocesoQali.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanMueQal, xProDet.CantidadMuestraQali.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanDesQal, xProDet.CantidadDesechoQali.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.SalLibCuaQal, xProDet.SaldoLiberacionCuarentenaQali.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngCuaQal, xProDet.ClaveIngresoCuarentenaQali);
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngRepQal, xProDet.ClaveIngresoReprocesoQali);
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngMueQal, xProDet.ClaveIngresoMuestraQali);
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngDesQal, xProDet.ClaveIngresoDesechoQali);
                xIns.AsignarParametro(ProduccionDetaEN.ClaSalEtiQal, xProDet.ClaveSalidaEtiquetaQali);
                xIns.AsignarParametro(ProduccionDetaEN.DetMovRepQal, xProDet.DetalleMotivoReprocesoQali);
                xIns.AsignarParametro(ProduccionDetaEN.DetMovDesQal, xProDet.DetalleMotivoDesechoQali);
                xIns.AsignarParametro(ProduccionDetaEN.DetMovMuePreLib, xProDet.DetalleMotivoMuestraPreLiberacion);
                xIns.AsignarParametro(ProduccionDetaEN.DetMovBloPreLib, xProDet.DetalleMotivoBloqueadosPreLiberacion);
                xIns.AsignarParametro(ProduccionDetaEN.CanUniPacAdiBlo, xProDet.CantidadUnidadesPackingAdicionalesBlo.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.SalLibObs, xProDet.SaldoLiberacionObservadas.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanUniPacAdiObs, xProDet.CantidadUnidadesPackingAdicionalesObs.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.CanMuePro, xProDet.CantidadMuestraProduccion.ToString());
                xIns.AsignarParametro(ProduccionDetaEN.DetMovMuePro, xProDet.DetalleMotivoMuestraProduccion);
                xIns.AsignarParametro(ProduccionDetaEN.ClaIngSemElaMuePro, xProDet.ClaveIngresoSemElaMuestraProduccion);
                xIns.AsignarParametro(ProduccionDetaEN.CEstProDet, xProDet.CEstadoProduccionDeta);
                xIns.AsignarParametro(ProduccionDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ProduccionDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(ProduccionDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ProduccionDetaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarProduccionDeta(ProduccionDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);           
            xUpd.AsignarParametro(ProduccionDetaEN.CanProDet, pObj.CantidadProduccionDeta.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanReaPro, pObj.CantidadRealProduccion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.FecProDet, Fecha.ObtenerAnoMesDia(pObj.FechaProduccionDeta));
            xUpd.AsignarParametro(ProduccionDetaEN.PerProDet, pObj.PeriodoProduccionDeta);
            xUpd.AsignarParametro(ProduccionDetaEN.FecSalFasMas, Fecha.ObtenerAnoMesDia(pObj.FechaSalidaFaseMasa));
            xUpd.AsignarParametro(ProduccionDetaEN.FecSalFasConCal, Fecha.ObtenerAnoMesDia(pObj.FechaSalidaFaseControlCalidad));
            xUpd.AsignarParametro(ProduccionDetaEN.FecSalFasEmp, Fecha.ObtenerAnoMesDia(pObj.FechaSalidaFaseEmpaquetado));
            xUpd.AsignarParametro(ProduccionDetaEN.FecIngAlm, Fecha.ObtenerAnoMesDia(pObj.FechaIngresoAlmacen));
            xUpd.AsignarParametro(ProduccionDetaEN.ObsProDet, pObj.ObservacionProduccionDeta);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalFasMas, pObj.ClaveSalidaFaseMasa);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalFasConCal, pObj.ClaveSalidaFaseControlCalidad);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalFasEmp, pObj.ClaveSalidaFaseEmpaquetado);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngMovCab, pObj.ClaveIngresoMovimientoCabe);
            xUpd.AsignarParametro(ProduccionDetaEN.CodMer, pObj.CodigoMercaderia);
            xUpd.AsignarParametro(ProduccionDetaEN.CEsExa, pObj.CEsExacto);
            xUpd.AsignarParametro(ProduccionDetaEN.CosTotPro, pObj.CostoTotalProducto.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosMasPri, pObj.CostoMasaPrincipal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosMasAdi, pObj.CostoMasaAdicional.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosMasDev, pObj.CostoMasaDevolucion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosMasTot, pObj.CostoMasaTotal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.MasPro, pObj.MasaProducida.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.MasUni, pObj.MasaUnidad.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumUniMas, pObj.NumeroUnidadesMasa.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosUniMas, pObj.CostoUnidadMasa.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.MasPer, pObj.MasaPerdida.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosMasPer, pObj.CostoMasaPerdida.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosConCalPri, pObj.CostoConCalPrincipal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosConCalAdi, pObj.CostoConCalAdicional.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosConCalDev, pObj.CostoConCalDevolucion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosConCalTot, pObj.CostoConCalTotal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumUniConCal, pObj.NumeroUnidadesConCal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumUniNoPasConCal, pObj.NumeroUnidadesNoPasanConCal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosUniConCal, pObj.CostoUnidadConCal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumUniProAnt, pObj.NumeroUnidadesProduccionAnterior.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalUniEmp, pObj.ClaveSalidaUnidadesEmpacar);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalNoPas, pObj.ClaveSalidaNoPasan);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngNoPas, pObj.ClaveIngresoNoPasan);
            xUpd.AsignarParametro(ProduccionDetaEN.UniPorCaj, pObj.UnidadesPorCaja.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumCaj, pObj.NumeroCajas.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumUniSue, pObj.NumeroUnidadesSueltas.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngSemEla, pObj.ClaveIngresoSemiElaborado);
            xUpd.AsignarParametro(ProduccionDetaEN.CosEmpSemElaPri, pObj.CostoEmpaquetadoSemElaPrincipal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosEmpSemElaAdi, pObj.CostoEmpaquetadoSemElaAdicional.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosEmpSemElaDev, pObj.CostoEmpaquetadoSemElaDevolucion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosEmpSemElaTot, pObj.CostoEmpaquetadoSemElaTotal.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosUniEmpSemEla, pObj.CostoUnidadEmpaquetadoSemEla.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosUniEmpProTer, pObj.CostoUnidadEmpaquetadoProTer.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosUniTotSemEla, pObj.CostoUnidadTotalSemEla.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumUniAEmp, pObj.NumeroUnidadesAEmpaquetar.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosIns, pObj.CostoInsumos.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosManObr, pObj.CostoManoObra.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosOtr, pObj.CostoOtros.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniDesEmp, pObj.UnidadesDesechaEmpaquetado.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniDevEmp, pObj.UnidadesDevueltaEmpaquetado.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniRep, pObj.UnidadesReproceso.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosUniRep, pObj.CostoUnidadesReproceso.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalUniRep, pObj.ClaveSalidaUnidadesReproceso);
            xUpd.AsignarParametro(ProduccionDetaEN.ObsMasPer, pObj.ObservacionMasaPerdida);
            xUpd.AsignarParametro(ProduccionDetaEN.UniParRep, pObj.UnidadesParaReproceso.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumUniSemEla, pObj.NumeroUnidadesSemiElaborado.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.NumTraAut, pObj.NumeroTransferenciaAutomatica);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalTraRep, pObj.ClaveSalidaTransferenciaReproceso);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngTraRep, pObj.ClaveIngresoTransferenciaReproceso);
            xUpd.AsignarParametro(ProduccionDetaEN.SalUniAEmp, pObj.SaldoUnidadesAEmpacar.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniDon, pObj.UnidadesDonacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalTraDon, pObj.ClaveSalidaTransferenciaDonacion);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngTraDon, pObj.ClaveIngresoTransferenciaDonacion);
            xUpd.AsignarParametro(ProduccionDetaEN.SalLib, pObj.SaldoLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniAprLib, pObj.UnidadesAprobadasLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniSalLib, pObj.UnidadesSaldoLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniObsLib, pObj.UnidadesObservadasLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniRepLib, pObj.UnidadesReprocesoLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniDonLib, pObj.UnidadesDonacionLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniMueLib, pObj.UnidadesMuestraLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.UniDesLib, pObj.UnidadesDesechasLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.PorRan, pObj.PorcentajeRango.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanRan, pObj.CantidadRango.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngDesEnv, pObj.ClaveIngresoDesmedroEnvasado);
            xUpd.AsignarParametro(ProduccionDetaEN.FacProProDet, pObj.FactorProduccionProDet.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.RatProProDet, pObj.RatioProduccionProDet.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.HorHom, pObj.HorasHombre.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosTotManObr, pObj.CostoTotalManoObra.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.FacCIFFij, pObj.FactorCIFFijo.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosCIFFij, pObj.CostoCIFFijo.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.FacCIFVar, pObj.FactorCIFVariable.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CosCIFVar, pObj.CostoCIFVariable.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanSinProDet, pObj.CantidadSinceradoProduccionDeta.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.PorSinRan, pObj.PorcentajeSinceradoRango.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanSinRan, pObj.CantidadSinceradoRango.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.DetMotSin, pObj.DetalleMotivoSincerado);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaTraSin, pObj.ClavesTransferenciaSincerado);
            xUpd.AsignarParametro(ProduccionDetaEN.CanEnc, pObj.CantidadEncajonar.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanBlo, pObj.CantidadBloquear.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.SalLibBlo, pObj.SaldoLiberacionBloqueadas.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngSemElaBlo, pObj.ClaveIngresoSemElaBloqueadas);
            xUpd.AsignarParametro(ProduccionDetaEN.CanConMue, pObj.CantidadContraMuestra.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngSemElaConMue, pObj.ClaveIngresoSemElaContraMuestra);
            xUpd.AsignarParametro(ProduccionDetaEN.CanCuaQal, pObj.CantidadCuarentenaQali.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanRepQal, pObj.CantidadReprocesoQali.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanMueQal, pObj.CantidadMuestraQali.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanDesQal, pObj.CantidadDesechoQali.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.SalLibCuaQal, pObj.SaldoLiberacionCuarentenaQali.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngCuaQal, pObj.ClaveIngresoCuarentenaQali);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngRepQal, pObj.ClaveIngresoReprocesoQali);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngMueQal, pObj.ClaveIngresoMuestraQali);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngDesQal, pObj.ClaveIngresoDesechoQali);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalEtiQal, pObj.ClaveSalidaEtiquetaQali);
            xUpd.AsignarParametro(ProduccionDetaEN.DetMovRepQal, pObj.DetalleMotivoReprocesoQali);
            xUpd.AsignarParametro(ProduccionDetaEN.DetMovMueQal, pObj.DetalleMotivoMuestraQali);
            xUpd.AsignarParametro(ProduccionDetaEN.DetMovDesQal, pObj.DetalleMotivoDesechoQali);
            xUpd.AsignarParametro(ProduccionDetaEN.DetMovMuePreLib, pObj.DetalleMotivoMuestraPreLiberacion);
            xUpd.AsignarParametro(ProduccionDetaEN.DetMovBloPreLib, pObj.DetalleMotivoBloqueadosPreLiberacion);
            xUpd.AsignarParametro(ProduccionDetaEN.CanUniPacAdiBlo, pObj.CantidadUnidadesPackingAdicionalesBlo.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.SalLibObs, pObj.SaldoLiberacionObservadas.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanUniPacAdiObs, pObj.CantidadUnidadesPackingAdicionalesObs.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.CanMuePro, pObj.CantidadMuestraProduccion.ToString());
            xUpd.AsignarParametro(ProduccionDetaEN.DetMovMuePro, pObj.DetalleMotivoMuestraProduccion);
            xUpd.AsignarParametro(ProduccionDetaEN.ClaIngSemElaMuePro, pObj.ClaveIngresoSemElaMuestraProduccion);
            xUpd.AsignarParametro(ProduccionDetaEN.CEstProDet, pObj.CEstadoProduccionDeta);
            xUpd.AsignarParametro(ProduccionDetaEN.CTur, pObj.CTurno);
            xUpd.AsignarParametro(ProduccionDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ProduccionDetaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar comando
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarProduccionDeta(List<ProduccionDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ProduccionDetaEN xProDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(ProduccionDetaEN.CanProDet, xProDet.CantidadProduccionDeta.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanReaPro, xProDet.CantidadRealProduccion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.FecProDet, Fecha.ObtenerAnoMesDia(xProDet.FechaProduccionDeta));
                xUpd.AsignarParametro(ProduccionDetaEN.PerProDet, xProDet.PeriodoProduccionDeta);
                xUpd.AsignarParametro(ProduccionDetaEN.FecSalFasMas, Fecha.ObtenerAnoMesDia(xProDet.FechaSalidaFaseMasa));
                xUpd.AsignarParametro(ProduccionDetaEN.FecSalFasConCal, Fecha.ObtenerAnoMesDia(xProDet.FechaSalidaFaseControlCalidad));
                xUpd.AsignarParametro(ProduccionDetaEN.FecSalFasEmp, Fecha.ObtenerAnoMesDia(xProDet.FechaSalidaFaseEmpaquetado));
                xUpd.AsignarParametro(ProduccionDetaEN.FecIngAlm, Fecha.ObtenerAnoMesDia(xProDet.FechaIngresoAlmacen));
                xUpd.AsignarParametro(ProduccionDetaEN.ObsProDet, xProDet.ObservacionProduccionDeta);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalFasMas, xProDet.ClaveSalidaFaseMasa);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalFasConCal, xProDet.ClaveSalidaFaseControlCalidad);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalFasEmp, xProDet.ClaveSalidaFaseEmpaquetado);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngMovCab, xProDet.ClaveIngresoMovimientoCabe);
                xUpd.AsignarParametro(ProduccionDetaEN.CodMer, xProDet.CodigoMercaderia);
                xUpd.AsignarParametro(ProduccionDetaEN.CEsExa, xProDet.CEsExacto);
                xUpd.AsignarParametro(ProduccionDetaEN.CosTotPro, xProDet.CostoTotalProducto.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosMasPri, xProDet.CostoMasaPrincipal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosMasAdi, xProDet.CostoMasaAdicional.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosMasDev, xProDet.CostoMasaDevolucion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosMasTot, xProDet.CostoMasaTotal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.MasPro, xProDet.MasaProducida.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.MasUni, xProDet.MasaUnidad.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumUniMas, xProDet.NumeroUnidadesMasa.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosUniMas, xProDet.CostoUnidadMasa.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.MasPer, xProDet.MasaPerdida.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosMasPer, xProDet.CostoMasaPerdida.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosConCalPri, xProDet.CostoConCalPrincipal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosConCalAdi, xProDet.CostoConCalAdicional.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosConCalDev, xProDet.CostoConCalDevolucion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosConCalTot, xProDet.CostoConCalTotal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumUniConCal, xProDet.NumeroUnidadesConCal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumUniNoPasConCal, xProDet.NumeroUnidadesNoPasanConCal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosUniConCal, xProDet.CostoUnidadConCal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumUniProAnt, xProDet.NumeroUnidadesProduccionAnterior.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalUniEmp, xProDet.ClaveSalidaUnidadesEmpacar);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalNoPas, xProDet.ClaveSalidaNoPasan);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngNoPas, xProDet.ClaveIngresoNoPasan);
                xUpd.AsignarParametro(ProduccionDetaEN.UniPorCaj, xProDet.UnidadesPorCaja.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumCaj, xProDet.NumeroCajas.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumUniSue, xProDet.NumeroUnidadesSueltas.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngSemEla, xProDet.ClaveIngresoSemiElaborado);
                xUpd.AsignarParametro(ProduccionDetaEN.CosEmpSemElaPri, xProDet.CostoEmpaquetadoSemElaPrincipal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosEmpSemElaAdi, xProDet.CostoEmpaquetadoSemElaAdicional.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosEmpSemElaDev, xProDet.CostoEmpaquetadoSemElaDevolucion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosEmpSemElaTot, xProDet.CostoEmpaquetadoSemElaTotal.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosUniEmpSemEla, xProDet.CostoUnidadEmpaquetadoSemEla.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosUniEmpProTer, xProDet.CostoUnidadEmpaquetadoProTer.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosUniTotSemEla, xProDet.CostoUnidadTotalSemEla.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumUniAEmp, xProDet.NumeroUnidadesAEmpaquetar.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosIns, xProDet.CostoInsumos.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosManObr, xProDet.CostoManoObra.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosOtr, xProDet.CostoOtros.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniDesEmp, xProDet.UnidadesDesechaEmpaquetado.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniDevEmp, xProDet.UnidadesDevueltaEmpaquetado.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniRep, xProDet.UnidadesReproceso.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosUniRep, xProDet.CostoUnidadesReproceso.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalUniRep, xProDet.ClaveSalidaUnidadesReproceso);
                xUpd.AsignarParametro(ProduccionDetaEN.ObsMasPer, xProDet.ObservacionMasaPerdida);
                xUpd.AsignarParametro(ProduccionDetaEN.UniParRep, xProDet.UnidadesParaReproceso.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumUniSemEla, xProDet.NumeroUnidadesSemiElaborado.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.NumTraAut, xProDet.NumeroTransferenciaAutomatica);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalTraRep, xProDet.ClaveSalidaTransferenciaReproceso);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngTraRep, xProDet.ClaveIngresoTransferenciaReproceso);
                xUpd.AsignarParametro(ProduccionDetaEN.SalUniAEmp, xProDet.SaldoUnidadesAEmpacar.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniDon, xProDet.UnidadesDonacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalTraDon, xProDet.ClaveSalidaTransferenciaDonacion);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngTraDon, xProDet.ClaveIngresoTransferenciaDonacion);
                xUpd.AsignarParametro(ProduccionDetaEN.SalLib, xProDet.SaldoLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniAprLib, xProDet.UnidadesAprobadasLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniSalLib, xProDet.UnidadesSaldoLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniObsLib, xProDet.UnidadesObservadasLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniRepLib, xProDet.UnidadesReprocesoLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniDonLib, xProDet.UnidadesDonacionLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniMueLib, xProDet.UnidadesMuestraLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.UniDesLib, xProDet.UnidadesDesechasLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.PorRan, xProDet.PorcentajeRango.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanRan, xProDet.CantidadRango.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngDesEnv, xProDet.ClaveIngresoDesmedroEnvasado);
                xUpd.AsignarParametro(ProduccionDetaEN.FacProProDet, xProDet.FactorProduccionProDet.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.RatProProDet, xProDet.RatioProduccionProDet.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.HorHom, xProDet.HorasHombre.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosTotManObr, xProDet.CostoTotalManoObra.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.FacCIFFij, xProDet.FactorCIFFijo.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosCIFFij, xProDet.CostoCIFFijo.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.FacCIFVar, xProDet.FactorCIFVariable.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CosCIFVar, xProDet.CostoCIFVariable.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanSinProDet, xProDet.CantidadSinceradoProduccionDeta.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.PorSinRan, xProDet.PorcentajeSinceradoRango.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanSinRan, xProDet.CantidadSinceradoRango.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.DetMotSin, xProDet.DetalleMotivoSincerado);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaTraSin, xProDet.ClavesTransferenciaSincerado);
                xUpd.AsignarParametro(ProduccionDetaEN.CanEnc, xProDet.CantidadEncajonar.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanBlo, xProDet.CantidadBloquear.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.SalLibBlo, xProDet.SaldoLiberacionBloqueadas.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngSemElaBlo, xProDet.ClaveIngresoSemElaBloqueadas);
                xUpd.AsignarParametro(ProduccionDetaEN.CanConMue, xProDet.CantidadContraMuestra.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngSemElaConMue, xProDet.ClaveIngresoSemElaContraMuestra);
                xUpd.AsignarParametro(ProduccionDetaEN.CanCuaQal, xProDet.CantidadCuarentenaQali.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanRepQal, xProDet.CantidadReprocesoQali.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanMueQal, xProDet.CantidadMuestraQali.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanDesQal, xProDet.CantidadDesechoQali.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.SalLibCuaQal, xProDet.SaldoLiberacionCuarentenaQali.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngCuaQal, xProDet.ClaveIngresoCuarentenaQali);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngRepQal, xProDet.ClaveIngresoReprocesoQali);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngMueQal, xProDet.ClaveIngresoMuestraQali);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngDesQal, xProDet.ClaveIngresoDesechoQali);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaSalEtiQal, xProDet.ClaveSalidaEtiquetaQali);
                xUpd.AsignarParametro(ProduccionDetaEN.DetMovRepQal, xProDet.DetalleMotivoReprocesoQali);
                xUpd.AsignarParametro(ProduccionDetaEN.DetMovMueQal, xProDet.DetalleMotivoMuestraQali);
                xUpd.AsignarParametro(ProduccionDetaEN.DetMovDesQal, xProDet.DetalleMotivoDesechoQali);
                xUpd.AsignarParametro(ProduccionDetaEN.DetMovMuePreLib, xProDet.DetalleMotivoMuestraPreLiberacion);
                xUpd.AsignarParametro(ProduccionDetaEN.DetMovBloPreLib, xProDet.DetalleMotivoBloqueadosPreLiberacion);
                xUpd.AsignarParametro(ProduccionDetaEN.CanUniPacAdiBlo, xProDet.CantidadUnidadesPackingAdicionalesBlo.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.SalLibObs, xProDet.SaldoLiberacionObservadas.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanUniPacAdiObs, xProDet.CantidadUnidadesPackingAdicionalesObs.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.CanMuePro, xProDet.CantidadMuestraProduccion.ToString());
                xUpd.AsignarParametro(ProduccionDetaEN.DetMovMuePro, xProDet.DetalleMotivoMuestraProduccion);
                xUpd.AsignarParametro(ProduccionDetaEN.ClaIngSemElaMuePro, xProDet.ClaveIngresoSemElaMuestraProduccion);
                xUpd.AsignarParametro(ProduccionDetaEN.CEstProDet, xProDet.CEstadoProduccionDeta);
                xUpd.AsignarParametro(ProduccionDetaEN.CTur, xProDet.CTurno);
                xUpd.AsignarParametro(ProduccionDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(ProduccionDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.ClaProDet, SqlSelect.Operador.Igual, xProDet.ClaveProduccionDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar comando
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();

            }
            
            xObjCon.Desconectar();
        }

        public void ModificarProduccionDetaParaRegenerar(string pCodigoPeriodo)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);            
            xUpd.AsignarParametro(ProduccionDetaEN.FecSalFasMas, string.Empty);            
            xUpd.AsignarParametro(ProduccionDetaEN.ClaSalFasMas, string.Empty);           
            xUpd.AsignarParametro(ProduccionDetaEN.NumTraAut, string.Empty);           
            xUpd.AsignarParametro(ProduccionDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ProduccionDetaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.PerProDet, SqlSelect.Operador.Igual, pCodigoPeriodo);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar comando
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarProduccionDeta(ProduccionDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }    

        public ProduccionDetaEN BuscarProduccionDetaXClave(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());       
        }

        public List<ProduccionDetaEN> ListarProduccionDetaXEstado(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (pObj.CEstadoProduccionDeta != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CEstProDet, SqlSelect.Operador.Igual, pObj.CEstadoProduccionDeta);
            }            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaParaProduccionAnterior(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.ClaSalUniEmp, SqlSelect.Operador.Igual, string.Empty);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CodSemPro, SqlSelect.Operador.Igual, pObj.CodigoSemiProducto);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.NumUniSue, SqlSelect.Operador.Diferente, "0");            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public ProduccionDetaEN BuscarProduccionDetaParaCostoUnidadesReproceso(ProduccionDetaEN pObj)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select top(1) * From VsProduccionDeta";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CodigoExistencia='" + pObj.CodigoExistencia + "'";            
            iScript += " And ClaveProduccionDeta<'" + pObj.ClaveProduccionDeta + "'";
            iScript += " Order By " + ProduccionDetaEN.ClaProDet+ " desc";

            //resultado
            return this.BuscarObjeto(iScript);
        }

        public List<ProduccionDetaEN> ListarProduccionDetaXRangoFechaProduccion(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, ProduccionDetaEN.FecProDet, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                   , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaParaTransferirInsumos()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.NumTraAut, SqlSelect.Operador.Igual, string.Empty);
            xSel.Ordenar(ProduccionDetaEN.FecProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
                
        public List<ProduccionDetaEN> ListarProduccionDetaQueFaltanReprocesar(string pCodExiSemEla)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CodSemPro, SqlSelect.Operador.Igual, pCodExiSemEla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.UniRep, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.ClaSalUniRep, SqlSelect.Operador.Igual, string.Empty);
            xSel.Ordenar(ProduccionDetaEN.CorProCab, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaParaRecalculoManoObra(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.PerProDet, SqlSelect.Operador.Igual, pObj.PeriodoProduccionDeta);           
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaParaEmpaquetar()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.NumUniConCal, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.SalUniAEmp, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(ProduccionDetaEN.ClaProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaParaEmpaquetarXCodigoSemiProducto(string pCodigoSemiProducto)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CodSemPro, SqlSelect.Operador.Igual, pCodigoSemiProducto);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.NumUniConCal, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.SalUniAEmp, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(ProduccionDetaEN.ClaProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaConTransferenciaMateriaPrimaSinLlevarACocina()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);            
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.NumTraAut, SqlSelect.Operador.Diferente, "");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.ClaSalFasMas, SqlSelect.Operador.Igual, "");
            xSel.Ordenar(ProduccionDetaEN.ClaProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaPorClavesLiberacion(string pClavesLiberacion)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsProduccionDeta";
            iScript += " Where ClaveProduccionDeta IN(Select ClaveProduccionDeta From Liberacion Where ClaveLiberacion IN(" + pClavesLiberacion + "))";            
            iScript += " Order By " + ProduccionDetaEN.ClaProDet;

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ProduccionDetaEN> ListarProduccionDetaParaReporteCostoLoteFaseEnvasado(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, ProduccionDetaEN.FecProDet, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                   , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            if (pObj.CodigoSemiProducto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CodSemPro, SqlSelect.Operador.Igual, pObj.CodigoSemiProducto);
            }
            xSel.Ordenar(ProduccionDetaEN.FecProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaParaConsultaProductoTerminado(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, ProduccionDetaEN.FecProDet, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                   , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            if (pObj.CodigoExistencia != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            }
            xSel.Ordenar(ProduccionDetaEN.FecProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaConSaldoLiberacion()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.SalLib, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.PerProDet, SqlSelect.Operador.Mayor, "2021-00");
            xSel.Ordenar(ProduccionDetaEN.CodSemPro + "," + ProduccionDetaEN.FecProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaConSaldoLiberacionNew(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.SalLib, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.PerProDet, SqlSelect.Operador.Mayor, "2021-00");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaConSaldoLiberacion(string pCodigoSemiProducto)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CodSemPro, SqlSelect.Operador.Igual, pCodigoSemiProducto);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.SalLib, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.PerProDet, SqlSelect.Operador.Mayor, "2021-00");
            xSel.Ordenar(ProduccionDetaEN.CodSemPro + "," + ProduccionDetaEN.FecProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaSinLiberacion()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CanReaPro, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CanEnc, SqlSelect.Operador.Igual, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.PerProDet, SqlSelect.Operador.Mayor, "2021-00");
            xSel.Ordenar(ProduccionDetaEN.CodSemPro + "," + ProduccionDetaEN.FecProDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionDetaEN> ListarProduccionDetaSinLiberacionNew(ProduccionDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CanReaPro, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.CanEnc, SqlSelect.Operador.Igual, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionDetaEN.PerProDet, SqlSelect.Operador.Mayor, "2021-00");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }       

    }
}
