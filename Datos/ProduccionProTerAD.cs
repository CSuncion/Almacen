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
using System.Windows.Forms;

namespace Datos
{
    public class ProduccionProTerAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<ProduccionProTerEN> xLista = new List<ProduccionProTerEN>();
        private ProduccionProTerEN xObj = new ProduccionProTerEN();
        private string xTabla = "ProduccionProTer";
        private string xVista = "VsProduccionProTer";

        #endregion
        
        #region Metodos privados

        private ProduccionProTerEN Objeto(IDataReader iDr)
        {
            ProduccionProTerEN xObjEnc = new ProduccionProTerEN();
            xObjEnc.ClaveProduccionProTer = iDr[ProduccionProTerEN.ClaProProTer].ToString();
            xObjEnc.ClaveProduccionDeta = iDr[ProduccionProTerEN.ClaProDet].ToString();
            xObjEnc.PeriodoProduccionDeta = iDr[ProduccionProTerEN.PerProDet].ToString();
            xObjEnc.ClaveProduccionCabe = iDr[ProduccionProTerEN.ClaProCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[ProduccionProTerEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[ProduccionProTerEN.NomEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[ProduccionProTerEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[ProduccionProTerEN.DesAlm].ToString();
            xObjEnc.CorrelativoProduccionProTer = iDr[ProduccionProTerEN.CorProProTer].ToString();
            xObjEnc.CodigoExistencia = iDr[ProduccionProTerEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[ProduccionProTerEN.DesExi].ToString();
            xObjEnc.UnidadesPorEmpaque = Convert.ToDecimal(iDr[ProduccionProTerEN.UniPorEmp].ToString());
            xObjEnc.CodigoUnidadMedida = iDr[ProduccionProTerEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[ProduccionProTerEN.NomUniMed].ToString();            
            xObjEnc.NumeroCajas = Convert.ToDecimal(iDr[ProduccionProTerEN.NumCaj].ToString());
            xObjEnc.CostoEmpaquetadoPrincipal = Convert.ToDecimal(iDr[ProduccionProTerEN.CosEmpPri].ToString());
            xObjEnc.CostoEmpaquetadoAdicional = Convert.ToDecimal(iDr[ProduccionProTerEN.CosEmpAdi].ToString());
            xObjEnc.CostoEmpaquetadoDevolucion = Convert.ToDecimal(iDr[ProduccionProTerEN.CosEmpDev].ToString());
            xObjEnc.CostoEmpaquetadoTotal = Convert.ToDecimal(iDr[ProduccionProTerEN.CosEmpTot].ToString());
            xObjEnc.CostoUnidadEmpaquetado = Convert.ToDecimal(iDr[ProduccionProTerEN.CosUniEmpProTer].ToString());
            xObjEnc.CostoUnidadSemiProducto = Convert.ToDecimal(iDr[ProduccionProTerEN.CosUniSemPro].ToString());
            xObjEnc.CostoInsumos = Convert.ToDecimal(iDr[ProduccionProTerEN.CosIns].ToString());
            xObjEnc.CostoManoObra = Convert.ToDecimal(iDr[ProduccionProTerEN.CosManObr].ToString());
            xObjEnc.CostoGastoIndirecto = Convert.ToDecimal(iDr[ProduccionProTerEN.CosGasInd].ToString());
            xObjEnc.CostoOtros = Convert.ToDecimal(iDr[ProduccionProTerEN.CosOtr].ToString());
            xObjEnc.CostoTotalProducto = Convert.ToDecimal(iDr[ProduccionProTerEN.CosTotPro].ToString());
            xObjEnc.UnidadesDesechaEmpaquetado = Convert.ToDecimal(iDr[ProduccionProTerEN.UniDesEmp].ToString());
            xObjEnc.UnidadesDevueltaEmpaquetado = Convert.ToDecimal(iDr[ProduccionProTerEN.UniDevEmp].ToString());
            xObjEnc.FactorProduccionProTer = Convert.ToDecimal(iDr[ProduccionProTerEN.FacProProTer].ToString());
            xObjEnc.RatioProduccionProTer = Convert.ToDecimal(iDr[ProduccionProTerEN.RatProProTer].ToString());
            xObjEnc.HorasHombre = Convert.ToDecimal(iDr[ProduccionProTerEN.HorHom].ToString());
            xObjEnc.CostoTotalManoObra = Convert.ToDecimal(iDr[ProduccionProTerEN.CosTotManObr].ToString());
            xObjEnc.ClaveEncajado = iDr[ProduccionProTerEN.ClaEnc].ToString();
            xObjEnc.CorrelativoEncajado = iDr[ProduccionProTerEN.CorEnc].ToString();
            xObjEnc.PeriodoEncajado = iDr[ProduccionProTerEN.PerEnc].ToString();
            xObjEnc.FechaEncajado = Fecha.ObtenerDiaMesAno(iDr[ProduccionProTerEN.FecEnc].ToString());
            xObjEnc.ClaveSalidaFaseEmpaquetado = iDr[ProduccionProTerEN.ClaSalFasEmp].ToString();
            xObjEnc.ClaveSalidaUnidadesEmpacar = iDr[ProduccionProTerEN.ClaSalUniEmp].ToString();
            xObjEnc.ClaveIngresoProductoTerminado = iDr[ProduccionProTerEN.ClaIngProTer].ToString();
            xObjEnc.CEstadoEncajado = iDr[ProduccionProTerEN.CEstEnc].ToString();
            xObjEnc.CantidadUnidadesProTer = Convert.ToDecimal(iDr[ProduccionProTerEN.CanUniProTer].ToString());
            xObjEnc.DetalleCantidadesSemiProducto = iDr[ProduccionProTerEN.DetCanSemPro].ToString();
            xObjEnc.FechaLoteProTer = Fecha.ObtenerDiaMesAno(iDr[ProduccionProTerEN.FecLotProTer].ToString());
            xObjEnc.FechaVctoProTer = Fecha.ObtenerDiaMesAno(iDr[ProduccionProTerEN.FecVenProTer].ToString());
            xObjEnc.ObservacionProTer = iDr[ProduccionProTerEN.ObsProTer].ToString();
            xObjEnc.PrioridadEncajado = Convert.ToDecimal(iDr[ProduccionProTerEN.PriEnc].ToString());
            xObjEnc.CantidadUnidadesRealEncajado = Convert.ToDecimal(iDr[ProduccionProTerEN.CanUniReaEnc].ToString());
            xObjEnc.CantidadCajasRealEncajado = Convert.ToDecimal(iDr[ProduccionProTerEN.CanCajReaEnc].ToString());
            xObjEnc.CantidadDevueltaEncajado = Convert.ToDecimal(iDr[ProduccionProTerEN.CanDevEnc].ToString());
            xObjEnc.PorcentajeUnidadesRango = Convert.ToDecimal(iDr[ProduccionProTerEN.PorUniRan].ToString());
            xObjEnc.CantidadUnidadesRango = Convert.ToDecimal(iDr[ProduccionProTerEN.CanUniRan].ToString());
            xObjEnc.PorcentajeCajasRango = Convert.ToDecimal(iDr[ProduccionProTerEN.PorCajRan].ToString());
            xObjEnc.CantidadCajasRango = Convert.ToDecimal(iDr[ProduccionProTerEN.CanCajRan].ToString());
            xObjEnc.FactorCifProTer = Convert.ToDecimal(iDr[ProduccionProTerEN.FacCifProTer].ToString());
            xObjEnc.FactorCIFFijo = Convert.ToDecimal(iDr[ProduccionProTerEN.FacCIFFij].ToString());
            xObjEnc.CostoCIFFijo = Convert.ToDecimal(iDr[ProduccionProTerEN.CosCIFFij].ToString());
            xObjEnc.FactorCIFVariable = Convert.ToDecimal(iDr[ProduccionProTerEN.FacCIFVar].ToString());
            xObjEnc.CostoCIFVariable = Convert.ToDecimal(iDr[ProduccionProTerEN.CosCIFVar].ToString());
            xObjEnc.CEleccionSegundaLiberacion = iDr[ProduccionProTerEN.CEleSegLib].ToString();
            xObjEnc.NEleccionSegundaLiberacion = iDr[ProduccionProTerEN.NEleSegLib].ToString();
            xObjEnc.ClaveSalidaEtiquetaSegundaLiberacion = iDr[ProduccionProTerEN.ClaSalEtiSegLib].ToString();
            xObjEnc.ClaveIngresoSemiProductoSegundaLiberacion = iDr[ProduccionProTerEN.ClaIngSemProSegLib].ToString();
            xObjEnc.CostoEmpaquetadoSegundaLiberacion = Convert.ToDecimal(iDr[ProduccionProTerEN.CosEmpSegLib].ToString());
            xObjEnc.CEstadoProduccionProTer = iDr[ProduccionProTerEN.CEstProProTer].ToString();
            xObjEnc.NEstadoProduccionProTer = iDr[ProduccionProTerEN.NEstProProTer].ToString();
            xObjEnc.UsuarioAgrega = iDr[ProduccionProTerEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ProduccionProTerEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[ProduccionProTerEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ProduccionProTerEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveProduccionProTer;
            return xObjEnc;
        }

        private List<ProduccionProTerEN> ListarObjetos(string pScript)
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

        private ProduccionProTerEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, ProduccionProTerEN.CorProProTer);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AdicionarProduccionProTer(ProduccionProTerEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(ProduccionProTerEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xIns.AsignarParametro(ProduccionProTerEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(ProduccionProTerEN.ClaProCab, pObj.ClaveProduccionCabe);
            xIns.AsignarParametro(ProduccionProTerEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(ProduccionProTerEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(ProduccionProTerEN.CorProProTer, pObj.CorrelativoProduccionProTer);
            xIns.AsignarParametro(ProduccionProTerEN.CodExi, pObj.CodigoExistencia);            
            xIns.AsignarParametro(ProduccionProTerEN.NumCaj, pObj.NumeroCajas.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosEmpPri, pObj.CostoEmpaquetadoPrincipal.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosEmpAdi, pObj.CostoEmpaquetadoAdicional.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosEmpDev, pObj.CostoEmpaquetadoDevolucion.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosEmpTot, pObj.CostoEmpaquetadoTotal.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosUniEmpProTer, pObj.CostoUnidadEmpaquetado.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosUniSemPro, pObj.CostoUnidadSemiProducto.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosIns, pObj.CostoInsumos.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosManObr, pObj.CostoManoObra.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosGasInd, pObj.CostoGastoIndirecto.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosOtr, pObj.CostoOtros.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosTotPro, pObj.CostoTotalProducto.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.UniDesEmp, pObj.UnidadesDesechaEmpaquetado.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.UniDevEmp, pObj.UnidadesDevueltaEmpaquetado.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.FacProProTer, pObj.FactorProduccionProTer.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.RatProProTer, pObj.RatioProduccionProTer.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.HorHom, pObj.HorasHombre.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosTotManObr, pObj.CostoTotalManoObra.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.ClaEnc, pObj.ClaveEncajado);           
            xIns.AsignarParametro(ProduccionProTerEN.CanUniProTer, pObj.CantidadUnidadesProTer.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.DetCanSemPro, pObj.DetalleCantidadesSemiProducto);
            xIns.AsignarParametro(ProduccionProTerEN.FecLotProTer, Fecha.ObtenerAnoMesDia(pObj.FechaLoteProTer));
            xIns.AsignarParametro(ProduccionProTerEN.FecVenProTer, Fecha.ObtenerAnoMesDia(pObj.FechaVctoProTer));
            xIns.AsignarParametro(ProduccionProTerEN.ObsProTer, pObj.ObservacionProTer);
            xIns.AsignarParametro(ProduccionProTerEN.PriEnc, pObj.PrioridadEncajado.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CanUniReaEnc, pObj.CantidadUnidadesRealEncajado.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CanCajReaEnc, pObj.CantidadCajasRealEncajado.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CanDevEnc, pObj.CantidadDevueltaEncajado.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.PorUniRan, pObj.PorcentajeUnidadesRango.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CanUniRan, pObj.CantidadUnidadesRango.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.PorCajRan, pObj.PorcentajeCajasRango.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CanCajRan, pObj.CantidadCajasRango.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.FacCifProTer, pObj.FactorCifProTer.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.FacCIFFij, pObj.FactorCIFFijo.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosCIFFij, pObj.CostoCIFFijo.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.FacCIFVar, pObj.FactorCIFVariable.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CosCIFVar, pObj.CostoCIFVariable.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CEleSegLib, pObj.CEleccionSegundaLiberacion);
            xIns.AsignarParametro(ProduccionProTerEN.ClaSalEtiSegLib, pObj.ClaveSalidaEtiquetaSegundaLiberacion);
            xIns.AsignarParametro(ProduccionProTerEN.ClaIngSemProSegLib, pObj.ClaveIngresoSemiProductoSegundaLiberacion);
            xIns.AsignarParametro(ProduccionProTerEN.CosEmpSegLib, pObj.CostoEmpaquetadoSegundaLiberacion.ToString());
            xIns.AsignarParametro(ProduccionProTerEN.CEstProProTer, pObj.CEstadoProduccionProTer);
            xIns.AsignarParametro(ProduccionProTerEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ProduccionProTerEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(ProduccionProTerEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ProduccionProTerEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarProduccionProTer(List<ProduccionProTerEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(ProduccionProTerEN.ClaProProTer, xProProTer.ClaveProduccionProTer);
                xIns.AsignarParametro(ProduccionProTerEN.ClaProDet, xProProTer.ClaveProduccionDeta);
                xIns.AsignarParametro(ProduccionProTerEN.ClaProCab, xProProTer.ClaveProduccionCabe);
                xIns.AsignarParametro(ProduccionProTerEN.CodEmp, xProProTer.CodigoEmpresa);
                xIns.AsignarParametro(ProduccionProTerEN.CodAlm, xProProTer.CodigoAlmacen);
                xIns.AsignarParametro(ProduccionProTerEN.CorProProTer, xProProTer.CorrelativoProduccionProTer);
                xIns.AsignarParametro(ProduccionProTerEN.CodExi, xProProTer.CodigoExistencia);                
                xIns.AsignarParametro(ProduccionProTerEN.NumCaj, xProProTer.NumeroCajas.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosEmpPri, xProProTer.CostoEmpaquetadoPrincipal.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosEmpAdi, xProProTer.CostoEmpaquetadoAdicional.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosEmpDev, xProProTer.CostoEmpaquetadoDevolucion.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosEmpTot, xProProTer.CostoEmpaquetadoTotal.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosUniEmpProTer, xProProTer.CostoUnidadEmpaquetado.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosUniSemPro, xProProTer.CostoUnidadSemiProducto.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosIns, xProProTer.CostoInsumos.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosManObr, xProProTer.CostoManoObra.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosOtr, xProProTer.CostoOtros.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosTotPro, xProProTer.CostoTotalProducto.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.UniDesEmp, xProProTer.UnidadesDesechaEmpaquetado.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.UniDevEmp, xProProTer.UnidadesDevueltaEmpaquetado.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.FacProProTer, xProProTer.FactorProduccionProTer.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.RatProProTer, xProProTer.RatioProduccionProTer.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.HorHom, xProProTer.HorasHombre.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosTotManObr, xProProTer.CostoTotalManoObra.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosGasInd, xProProTer.CostoGastoIndirecto.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.ClaEnc, xProProTer.ClaveEncajado);               
                xIns.AsignarParametro(ProduccionProTerEN.CanUniProTer, xProProTer.CantidadUnidadesProTer.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.DetCanSemPro, xProProTer.DetalleCantidadesSemiProducto);
                xIns.AsignarParametro(ProduccionProTerEN.FecLotProTer, Fecha.ObtenerAnoMesDia(xProProTer.FechaLoteProTer));
                xIns.AsignarParametro(ProduccionProTerEN.FecVenProTer, Fecha.ObtenerAnoMesDia(xProProTer.FechaVctoProTer));
                xIns.AsignarParametro(ProduccionProTerEN.ObsProTer, xProProTer.ObservacionProTer);
                xIns.AsignarParametro(ProduccionProTerEN.PriEnc, xProProTer.PrioridadEncajado.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CanUniReaEnc, xProProTer.CantidadUnidadesRealEncajado.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CanCajReaEnc, xProProTer.CantidadCajasRealEncajado.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CanDevEnc, xProProTer.CantidadDevueltaEncajado.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.PorUniRan, xProProTer.PorcentajeUnidadesRango.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CanUniRan, xProProTer.CantidadUnidadesRango.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.PorCajRan, xProProTer.PorcentajeCajasRango.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CanCajRan, xProProTer.CantidadCajasRango.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.FacCifProTer, xProProTer.FactorCifProTer.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.FacCIFFij, xProProTer.FactorCIFFijo.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosCIFFij, xProProTer.CostoCIFFijo.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.FacCIFVar, xProProTer.FactorCIFVariable.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CosCIFVar, xProProTer.CostoCIFVariable.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CEleSegLib, xProProTer.CEleccionSegundaLiberacion);
                xIns.AsignarParametro(ProduccionProTerEN.ClaSalEtiSegLib, xProProTer.ClaveSalidaEtiquetaSegundaLiberacion);
                xIns.AsignarParametro(ProduccionProTerEN.ClaIngSemProSegLib, xProProTer.ClaveIngresoSemiProductoSegundaLiberacion);
                xIns.AsignarParametro(ProduccionProTerEN.CosEmpSegLib, xProProTer.CostoEmpaquetadoSegundaLiberacion.ToString());
                xIns.AsignarParametro(ProduccionProTerEN.CEstProProTer, xProProTer.CEstadoProduccionProTer);
                xIns.AsignarParametro(ProduccionProTerEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ProduccionProTerEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(ProduccionProTerEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ProduccionProTerEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }
        
        public void ModificarProduccionProTer(ProduccionProTerEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(ProduccionProTerEN.CodAlm, pObj.CodigoAlmacen);
            xUpd.AsignarParametro(ProduccionProTerEN.CorProProTer, pObj.CorrelativoProduccionProTer);
            xUpd.AsignarParametro(ProduccionProTerEN.CodExi, pObj.CodigoExistencia);           
            xUpd.AsignarParametro(ProduccionProTerEN.NumCaj, pObj.NumeroCajas.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosEmpPri, pObj.CostoEmpaquetadoPrincipal.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosEmpAdi, pObj.CostoEmpaquetadoAdicional.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosEmpDev, pObj.CostoEmpaquetadoDevolucion.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosEmpTot, pObj.CostoEmpaquetadoTotal.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosUniEmpProTer, pObj.CostoUnidadEmpaquetado.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosUniSemPro, pObj.CostoUnidadSemiProducto.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosIns, pObj.CostoInsumos.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosManObr, pObj.CostoManoObra.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosGasInd, pObj.CostoGastoIndirecto.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosOtr, pObj.CostoOtros.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosTotPro, pObj.CostoTotalProducto.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.UniDesEmp, pObj.UnidadesDesechaEmpaquetado.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.UniDevEmp, pObj.UnidadesDevueltaEmpaquetado.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.FacProProTer, pObj.FactorProduccionProTer.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.RatProProTer, pObj.RatioProduccionProTer.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.HorHom, pObj.HorasHombre.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosTotManObr, pObj.CostoTotalManoObra.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.ClaEnc, pObj.ClaveEncajado);
            xUpd.AsignarParametro(ProduccionProTerEN.CanUniProTer, pObj.CantidadUnidadesProTer.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.DetCanSemPro, pObj.DetalleCantidadesSemiProducto);
            xUpd.AsignarParametro(ProduccionProTerEN.FecLotProTer, Fecha.ObtenerAnoMesDia(pObj.FechaLoteProTer));
            xUpd.AsignarParametro(ProduccionProTerEN.FecVenProTer, Fecha.ObtenerAnoMesDia(pObj.FechaVctoProTer));
            xUpd.AsignarParametro(ProduccionProTerEN.ObsProTer, pObj.ObservacionProTer);
            xUpd.AsignarParametro(ProduccionProTerEN.PriEnc, pObj.PrioridadEncajado.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CanUniReaEnc, pObj.CantidadUnidadesRealEncajado.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CanCajReaEnc, pObj.CantidadCajasRealEncajado.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CanDevEnc, pObj.CantidadDevueltaEncajado.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.PorUniRan, pObj.PorcentajeUnidadesRango.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CanUniRan, pObj.CantidadUnidadesRango.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.PorCajRan, pObj.PorcentajeCajasRango.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CanCajRan, pObj.CantidadCajasRango.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.FacCifProTer, pObj.FactorCifProTer.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.FacCIFFij, pObj.FactorCIFFijo.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosCIFFij, pObj.CostoCIFFijo.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.FacCIFVar, pObj.FactorCIFVariable.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CosCIFVar, pObj.CostoCIFVariable.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CEleSegLib, pObj.CEleccionSegundaLiberacion);
            xUpd.AsignarParametro(ProduccionProTerEN.ClaSalEtiSegLib, pObj.ClaveSalidaEtiquetaSegundaLiberacion);
            xUpd.AsignarParametro(ProduccionProTerEN.ClaIngSemProSegLib, pObj.ClaveIngresoSemiProductoSegundaLiberacion);
            xUpd.AsignarParametro(ProduccionProTerEN.CosEmpSegLib, pObj.CostoEmpaquetadoSegundaLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionProTerEN.CEstProProTer, pObj.CEstadoProduccionProTer);
            xUpd.AsignarParametro(ProduccionProTerEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ProduccionProTerEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar comando
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarProduccionProTer(List<ProduccionProTerEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(ProduccionProTerEN.CodAlm, xProProTer.CodigoAlmacen);
                xUpd.AsignarParametro(ProduccionProTerEN.CorProProTer, xProProTer.CorrelativoProduccionProTer);
                xUpd.AsignarParametro(ProduccionProTerEN.CodExi, xProProTer.CodigoExistencia);                
                xUpd.AsignarParametro(ProduccionProTerEN.NumCaj, xProProTer.NumeroCajas.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosEmpPri, xProProTer.CostoEmpaquetadoPrincipal.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosEmpAdi, xProProTer.CostoEmpaquetadoAdicional.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosEmpDev, xProProTer.CostoEmpaquetadoDevolucion.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosEmpTot, xProProTer.CostoEmpaquetadoTotal.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosUniEmpProTer, xProProTer.CostoUnidadEmpaquetado.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosUniSemPro, xProProTer.CostoUnidadSemiProducto.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosIns, xProProTer.CostoInsumos.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosManObr, xProProTer.CostoManoObra.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosGasInd, xProProTer.CostoGastoIndirecto.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosOtr, xProProTer.CostoOtros.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosTotPro, xProProTer.CostoTotalProducto.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.UniDesEmp, xProProTer.UnidadesDesechaEmpaquetado.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.UniDevEmp, xProProTer.UnidadesDevueltaEmpaquetado.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.FacProProTer, xProProTer.FactorProduccionProTer.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.RatProProTer, xProProTer.RatioProduccionProTer.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.HorHom, xProProTer.HorasHombre.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosTotManObr, xProProTer.CostoTotalManoObra.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.ClaEnc, xProProTer.ClaveEncajado);
                xUpd.AsignarParametro(ProduccionProTerEN.CanUniProTer, xProProTer.CantidadUnidadesProTer.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.DetCanSemPro, xProProTer.DetalleCantidadesSemiProducto);
                xUpd.AsignarParametro(ProduccionProTerEN.FecLotProTer, Fecha.ObtenerAnoMesDia(xProProTer.FechaLoteProTer));
                xUpd.AsignarParametro(ProduccionProTerEN.FecVenProTer, Fecha.ObtenerAnoMesDia(xProProTer.FechaVctoProTer));
                xUpd.AsignarParametro(ProduccionProTerEN.ObsProTer, xProProTer.ObservacionProTer);
                xUpd.AsignarParametro(ProduccionProTerEN.PriEnc, xProProTer.PrioridadEncajado.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CanUniReaEnc, xProProTer.CantidadUnidadesRealEncajado.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CanCajReaEnc, xProProTer.CantidadCajasRealEncajado.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CanDevEnc, xProProTer.CantidadDevueltaEncajado.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.PorUniRan, xProProTer.PorcentajeUnidadesRango.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CanUniRan, xProProTer.CantidadUnidadesRango.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.PorCajRan, xProProTer.PorcentajeCajasRango.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CanCajRan, xProProTer.CantidadCajasRango.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.FacCifProTer, xProProTer.FactorCifProTer.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.FacCIFFij, xProProTer.FactorCIFFijo.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosCIFFij, xProProTer.CostoCIFFijo.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.FacCIFVar, xProProTer.FactorCIFVariable.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CosCIFVar, xProProTer.CostoCIFVariable.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CEleSegLib, xProProTer.CEleccionSegundaLiberacion);
                xUpd.AsignarParametro(ProduccionProTerEN.ClaSalEtiSegLib, xProProTer.ClaveSalidaEtiquetaSegundaLiberacion);
                xUpd.AsignarParametro(ProduccionProTerEN.ClaIngSemProSegLib, xProProTer.ClaveIngresoSemiProductoSegundaLiberacion);
                xUpd.AsignarParametro(ProduccionProTerEN.CosEmpSegLib, xProProTer.CostoEmpaquetadoSegundaLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionProTerEN.CEstProProTer, xProProTer.CEstadoProduccionProTer);
                xUpd.AsignarParametro(ProduccionProTerEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(ProduccionProTerEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaProProTer, SqlSelect.Operador.Igual, xProProTer.ClaveProduccionProTer);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar comando
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();

            }
           
            xObjCon.Desconectar();
        }

        public void EliminarProduccionProTer(ProduccionProTerEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarProduccionProTerXClaveEncajado(ProduccionProTerEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public ProduccionProTerEN BuscarProduccionProTerXClave(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            return this.BuscarObjeto(xSel.ObtenerScript());       
        }

        public List<ProduccionProTerEN> ListarProduccionProTer()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(ProduccionProTerEN.ClaProProTer, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        
        public List<ProduccionProTerEN> ListarProduccionProTerXProduccionDeta(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerXProduccionDetaYConNumeroCajas(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.NumCaj, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public ProduccionProTerEN BuscarProduccionProTerXClaveProduccionDetaYCodigoExistencia(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerXRangoFechaProduccion(ProduccionDetaEN pObj)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsProduccionProTer";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And ClaveProduccionDeta In(Select ClaveProduccionDeta From VsProduccionDeta Where";
            iScript += " FechaProduccionDeta between '" + Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1) + "'";
            iScript += " And '" + Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1) + "')";
          
            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ProduccionProTerEN> ListarProduccionProTerXPeriodoProduccionDeta(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.PerProDet, SqlSelect.Operador.Igual, pObj.PeriodoProduccionDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerParaRecalculoManoObra(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.PerEnc, SqlSelect.Operador.Igual, pObj.PeriodoEncajado);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CanUniProTer, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerXClaveEncajado(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerParaPlanificacionEncajado()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CEstEnc, SqlSelect.Operador.Igual, "0");//pendiente
            xSel.Ordenar(ProduccionProTerEN.FecEnc + "," + ProduccionProTerEN.CorProProTer, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerXPeriodoEncajado(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.PerEnc, SqlSelect.Operador.Igual, pObj.PeriodoEncajado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerDeAlmacenYExistencia(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerParaReporteCostoUnitarioPorFechas(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);            
            xSel.CondicionBetween(SqlSelect.Reservada.Y, ProduccionProTerEN.FecEnc, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1)
                   , Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            if (pObj.CodigoExistencia != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            }
            xSel.Ordenar(ProduccionProTerEN.FecEnc + "," + ProduccionProTerEN.CodExi, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerAnteriorParaReporteCostoLoteEtapaEncajado(List<LiberacionEN> pLista, string pFechaAnterior)
        {
            //si la lista esta vacia,retorna lista vacia
            if (pLista.Count == 0) { return xLista; }

            //script manual
            string iScript = string.Empty;

            //recorrer cada objeto
            foreach (LiberacionEN xLib in pLista)
            {
                //armando la primera consulta
                iScript += "Select * From VsProduccionProTer";
                iScript += " Where DetalleCantidadesSemiProducto like '%" + xLib.CorrelativoProduccionCabe + "%'";
                iScript += " And FechaEncajado<'" + Fecha.ObtenerAnoMesDia(pFechaAnterior) + "'";
                iScript += " Union ";
            }

            //quitar el ultimo union
            iScript = Cadena.CortarCadena(iScript, iScript.Length - 6, Cadena.Direccion.Izquierda);

            //ordenar
            iScript += " Order by FechaEncajado";

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ProduccionProTerEN> ListarProduccionProTerConCantidadRealXClaveEncajado(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CanUniReaEnc, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionProTerEN> ListarProduccionProTerXClaveLiberacion(ProduccionProTerEN pObj)
        {
            //si el valor esta vacio
            if (pObj.DetalleCantidadesSemiProducto == string.Empty)
            {
                return new List<ProduccionProTerEN>();
            }
            else
            {
                SqlSelect xSel = new SqlSelect();
                xSel.SeleccionaVista(this.xVista);
                xSel.CondicionLike(SqlSelect.Reservada.Cuando, ProduccionProTerEN.DetCanSemPro, pObj.DetalleCantidadesSemiProducto,
                    SqlSelect.Lugar.CualquierLugar);
                xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
                return this.ListarObjetos(xSel.ObtenerScript());
            }

        }

        public List<ProduccionProTerEN> ListarProduccionProTerParaIngresoProductoTerminado(ProduccionProTerEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionProTerEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CanUniReaEnc, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionProTerEN.CEleSegLib, SqlSelect.Operador.Diferente, "2");//devolucion total de unidades
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

    }
}
