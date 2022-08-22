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
    public class ProduccionExisAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<ProduccionExisEN> xLista = new List<ProduccionExisEN>();
        private ProduccionExisEN xObj = new ProduccionExisEN();
        private string xTabla = "ProduccionExis";
        private string xVista = "VsProduccionExis";

        #endregion
        
        #region Metodos privados

        private ProduccionExisEN Objeto(IDataReader iDr)
        {
            ProduccionExisEN xObjEnc = new ProduccionExisEN();
            xObjEnc.ClaveProduccionExis = iDr[ProduccionExisEN.ClaProExi].ToString();
            xObjEnc.ClaveProduccionDeta = iDr[ProduccionExisEN.ClaProDet].ToString();
            xObjEnc.FechaProduccionDeta = Fecha.ObtenerDiaMesAno(iDr[ProduccionExisEN.FecProDet].ToString());
            xObjEnc.ClaveProduccionCabe = iDr[ProduccionExisEN.ClaProCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[ProduccionExisEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[ProduccionExisEN.NomEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[ProduccionExisEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[ProduccionExisEN.DesAlm].ToString();
            xObjEnc.CodigoPersonal = iDr[ProduccionExisEN.CodPer].ToString();
            xObjEnc.CorrelativoProduccionCabe = iDr[ProduccionExisEN.CorProCab].ToString();
            xObjEnc.CorrelativoProduccionDeta = iDr[ProduccionExisEN.CorProDet].ToString();
            xObjEnc.CorrelativoProduccionExis = iDr[ProduccionExisEN.CorProExi].ToString();
            xObjEnc.CodigoExistencia = iDr[ProduccionExisEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[ProduccionExisEN.DesExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[ProduccionExisEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[ProduccionExisEN.NomUniMed].ToString();            
            xObjEnc.CantidadProduccionExis = Convert.ToDecimal(iDr[ProduccionExisEN.CanProExi].ToString());
            xObjEnc.CantidadGr = Convert.ToDecimal(iDr[ProduccionExisEN.CanGr].ToString());
            xObjEnc.CantidadKg = Convert.ToDecimal(iDr[ProduccionExisEN.CanKg].ToString());
            xObjEnc.PrecioUnitario = Convert.ToDecimal(iDr[ProduccionExisEN.PreUni].ToString());
            xObjEnc.CantidadFormula = Convert.ToDecimal(iDr[ProduccionExisEN.CanFor].ToString());
            xObjEnc.CantidadGrFormula = Convert.ToDecimal(iDr[ProduccionExisEN.CanGrFor].ToString());
            xObjEnc.CantidadKgFormula = Convert.ToDecimal(iDr[ProduccionExisEN.CanKgFor].ToString());
            xObjEnc.CTipoDescarga = iDr[ProduccionExisEN.CTipDes].ToString();
            xObjEnc.NTipoDescarga = iDr[ProduccionExisEN.NTipDes].ToString();
            xObjEnc.CTipoFactor = iDr[ProduccionExisEN.CTipFac].ToString();
            xObjEnc.CodigoAlmacenProTer = iDr[ProduccionExisEN.CodAlmProTer].ToString();
            xObjEnc.CodigoExistenciaProTer = iDr[ProduccionExisEN.CodExiProTer].ToString();
            xObjEnc.CodigoAlmacenOrigen = iDr[ProduccionExisEN.CodAlmOri].ToString();
            xObjEnc.DescripcionAlmacenOrigen = iDr[ProduccionExisEN.DesAlmOri].ToString();
            xObjEnc.CodigoPersonalOrigen = iDr[ProduccionExisEN.CodPerOri].ToString();
            xObjEnc.ClaveProduccionProTer = iDr[ProduccionExisEN.ClaProProTer].ToString();
            xObjEnc.ClaveEncajado = iDr[ProduccionExisEN.ClaEnc].ToString();
            xObjEnc.PeriodoEncajado = iDr[ProduccionExisEN.PerEnc].ToString();
            xObjEnc.ClaveFormulaCabe = iDr[ProduccionExisEN.ClaForCab].ToString();
            xObjEnc.CodigoFormula = iDr[ProduccionExisEN.CodFor].ToString();
            xObjEnc.DescripcionFormula = iDr[ProduccionExisEN.DesFor].ToString();
            xObjEnc.PeriodoProduccionDeta = iDr[ProduccionExisEN.PerProDet].ToString();
            xObjEnc.ClaveRetiquetado = iDr[ProduccionExisEN.ClaRet].ToString();
            xObjEnc.PeriodoRetiquetado = iDr[ProduccionExisEN.PerRet].ToString();
            xObjEnc.DetalleMotivoDesmedro = iDr[ProduccionExisEN.DetMotDes].ToString();
            xObjEnc.CantidadDesmedro = Convert.ToDecimal(iDr[ProduccionExisEN.CanDes].ToString());
            xObjEnc.CEstadoDesmedro = iDr[ProduccionExisEN.CEstDes].ToString();
            xObjEnc.NEstadoDesmedro = iDr[ProduccionExisEN.NEstDes].ToString();
            xObjEnc.CantidadDevueltaProduccionExis = Convert.ToDecimal(iDr[ProduccionExisEN.CanDevProExi].ToString());
            xObjEnc.CodigoAlmacenCompra = iDr[ProduccionExisEN.CodAlmCom].ToString();
            xObjEnc.CSegundaLiberacion = iDr[ProduccionExisEN.CSegLib].ToString();
            xObjEnc.CantidadSegundaLiberacion = Convert.ToDecimal(iDr[ProduccionExisEN.CanSegLib].ToString());
            xObjEnc.CEstadoSegundaLiberacion = iDr[ProduccionExisEN.CEstSegLib].ToString();
            xObjEnc.NEstadoSegundaLiberacion = iDr[ProduccionExisEN.NEstSegLib].ToString();
            xObjEnc.CEstadoProduccionExis = iDr[ProduccionExisEN.CEstProExi].ToString();
            xObjEnc.NEstadoProduccionExis = iDr[ProduccionExisEN.NEstProExi].ToString();
            xObjEnc.UsuarioAgrega = iDr[ProduccionExisEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ProduccionExisEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[ProduccionExisEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ProduccionExisEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveProduccionExis;
            return xObjEnc;
        }

        private List<ProduccionExisEN> ListarObjetos(string pScript)
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

        private ProduccionExisEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, ProduccionExisEN.CorProDet);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionExisEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionExisEN.CorProCab, SqlSelect.Operador.Igual, pObj.CorrelativoProduccionCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionExisEN.CorProDet, SqlSelect.Operador.Igual, pObj.CorrelativoProduccionDeta);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AdicionarProduccionExis(ProduccionExisEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(ProduccionExisEN.ClaProExi, pObj.ClaveProduccionExis);
            xIns.AsignarParametro(ProduccionExisEN.ClaProDet, pObj.ClaveProduccionDeta);
            xIns.AsignarParametro(ProduccionExisEN.ClaProCab, pObj.ClaveProduccionCabe);
            xIns.AsignarParametro(ProduccionExisEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(ProduccionExisEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(ProduccionExisEN.CorProCab, pObj.CorrelativoProduccionCabe);
            xIns.AsignarParametro(ProduccionExisEN.CorProDet, pObj.CorrelativoProduccionDeta);
            xIns.AsignarParametro(ProduccionExisEN.CorProExi, pObj.CorrelativoProduccionExis);
            xIns.AsignarParametro(ProduccionExisEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(ProduccionExisEN.CodUniMed, pObj.CodigoUnidadMedida);
            xIns.AsignarParametro(ProduccionExisEN.CanProExi,  pObj.CantidadProduccionExis.ToString());
            xIns.AsignarParametro(ProduccionExisEN.CanGr, pObj.CantidadGr.ToString());
            xIns.AsignarParametro(ProduccionExisEN.CanKg, pObj.CantidadKg.ToString());
            xIns.AsignarParametro(ProduccionExisEN.PreUni, pObj.PrecioUnitario.ToString());
            xIns.AsignarParametro(ProduccionExisEN.CanFor, pObj.CantidadFormula.ToString());
            xIns.AsignarParametro(ProduccionExisEN.CanGrFor, pObj.CantidadGrFormula.ToString());
            xIns.AsignarParametro(ProduccionExisEN.CanKgFor, pObj.CantidadKgFormula.ToString());
            xIns.AsignarParametro(ProduccionExisEN.CTipDes, pObj.CTipoDescarga);
            xIns.AsignarParametro(ProduccionExisEN.CTipFac, pObj.CTipoFactor);
            xIns.AsignarParametro(ProduccionExisEN.CodAlmProTer, pObj.CodigoAlmacenProTer);
            xIns.AsignarParametro(ProduccionExisEN.CodExiProTer, pObj.CodigoExistenciaProTer);
            xIns.AsignarParametro(ProduccionExisEN.CodAlmOri, pObj.CodigoAlmacenOrigen);
            xIns.AsignarParametro(ProduccionExisEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xIns.AsignarParametro(ProduccionExisEN.ClaEnc, pObj.ClaveEncajado);
            xIns.AsignarParametro(ProduccionExisEN.ClaForCab, pObj.ClaveFormulaCabe);
            xIns.AsignarParametro(ProduccionExisEN.ClaRet, pObj.ClaveRetiquetado);
            xIns.AsignarParametro(ProduccionExisEN.CanDes, pObj.CantidadDesmedro.ToString());
            xIns.AsignarParametro(ProduccionExisEN.DetMotDes, pObj.DetalleMotivoDesmedro);
            xIns.AsignarParametro(ProduccionExisEN.CEstDes, pObj.CEstadoDesmedro);
            xIns.AsignarParametro(ProduccionExisEN.CanDevProExi, pObj.CantidadDevueltaProduccionExis.ToString());
            xIns.AsignarParametro(ProduccionExisEN.CodAlmCom, pObj.CodigoAlmacenCompra);
            xIns.AsignarParametro(ProduccionExisEN.CSegLib, pObj.CSegundaLiberacion);
            xIns.AsignarParametro(ProduccionExisEN.CanSegLib, pObj.CantidadSegundaLiberacion.ToString());
            xIns.AsignarParametro(ProduccionExisEN.CEstSegLib, pObj.CEstadoSegundaLiberacion);
            xIns.AsignarParametro(ProduccionExisEN.CEstProExi, pObj.CEstadoProduccionExis);
            xIns.AsignarParametro(ProduccionExisEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ProduccionExisEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(ProduccionExisEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ProduccionExisEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarProduccionExis(List< ProduccionExisEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(ProduccionExisEN.ClaProExi, xProExi.ClaveProduccionExis);
                xIns.AsignarParametro(ProduccionExisEN.ClaProDet, xProExi.ClaveProduccionDeta);
                xIns.AsignarParametro(ProduccionExisEN.ClaProCab, xProExi.ClaveProduccionCabe);
                xIns.AsignarParametro(ProduccionExisEN.CodEmp, xProExi.CodigoEmpresa);
                xIns.AsignarParametro(ProduccionExisEN.CodAlm, xProExi.CodigoAlmacen);
                xIns.AsignarParametro(ProduccionExisEN.CorProCab, xProExi.CorrelativoProduccionCabe);
                xIns.AsignarParametro(ProduccionExisEN.CorProDet, xProExi.CorrelativoProduccionDeta);
                xIns.AsignarParametro(ProduccionExisEN.CorProExi, xProExi.CorrelativoProduccionExis);
                xIns.AsignarParametro(ProduccionExisEN.CodExi, xProExi.CodigoExistencia);
                xIns.AsignarParametro(ProduccionExisEN.CodUniMed, xProExi.CodigoUnidadMedida);
                xIns.AsignarParametro(ProduccionExisEN.CanProExi, xProExi.CantidadProduccionExis.ToString());
                xIns.AsignarParametro(ProduccionExisEN.CanGr, xProExi.CantidadGr.ToString());
                xIns.AsignarParametro(ProduccionExisEN.CanKg, xProExi.CantidadKg.ToString());
                xIns.AsignarParametro(ProduccionExisEN.PreUni, xProExi.PrecioUnitario.ToString());
                xIns.AsignarParametro(ProduccionExisEN.CanFor,  xProExi.CantidadFormula.ToString());
                xIns.AsignarParametro(ProduccionExisEN.CanGrFor,  xProExi.CantidadGrFormula.ToString());
                xIns.AsignarParametro(ProduccionExisEN.CanKgFor,  xProExi.CantidadKgFormula.ToString());
                xIns.AsignarParametro(ProduccionExisEN.CTipDes, xProExi.CTipoDescarga);
                xIns.AsignarParametro(ProduccionExisEN.CTipFac, xProExi.CTipoFactor);
                xIns.AsignarParametro(ProduccionExisEN.CodAlmProTer, xProExi.CodigoAlmacenProTer);
                xIns.AsignarParametro(ProduccionExisEN.CodExiProTer, xProExi.CodigoExistenciaProTer);
                xIns.AsignarParametro(ProduccionExisEN.CodAlmOri, xProExi.CodigoAlmacenOrigen);
                xIns.AsignarParametro(ProduccionExisEN.ClaProProTer, xProExi.ClaveProduccionProTer);
                xIns.AsignarParametro(ProduccionExisEN.ClaEnc, xProExi.ClaveEncajado);
                xIns.AsignarParametro(ProduccionExisEN.ClaForCab, xProExi.ClaveFormulaCabe);
                xIns.AsignarParametro(ProduccionExisEN.ClaRet, xProExi.ClaveRetiquetado);
                xIns.AsignarParametro(ProduccionExisEN.CanDes, xProExi.CantidadDesmedro.ToString());
                xIns.AsignarParametro(ProduccionExisEN.DetMotDes, xProExi.DetalleMotivoDesmedro);
                xIns.AsignarParametro(ProduccionExisEN.CEstDes, xProExi.CEstadoDesmedro);
                xIns.AsignarParametro(ProduccionExisEN.CanDevProExi, xProExi.CantidadDevueltaProduccionExis.ToString());
                xIns.AsignarParametro(ProduccionExisEN.CodAlmCom, xProExi.CodigoAlmacenCompra);
                xIns.AsignarParametro(ProduccionExisEN.CSegLib, xProExi.CSegundaLiberacion);
                xIns.AsignarParametro(ProduccionExisEN.CanSegLib, xProExi.CantidadSegundaLiberacion.ToString());
                xIns.AsignarParametro(ProduccionExisEN.CEstSegLib, xProExi.CEstadoSegundaLiberacion);
                xIns.AsignarParametro(ProduccionExisEN.CEstProExi, xProExi.CEstadoProduccionExis);
                xIns.AsignarParametro(ProduccionExisEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ProduccionExisEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(ProduccionExisEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(ProduccionExisEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarProduccionExis(ProduccionExisEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);           
            xUpd.AsignarParametro(ProduccionExisEN.CanProExi, pObj.CantidadProduccionExis.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.CanGr, pObj.CantidadGr.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.CanKg, pObj.CantidadKg.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.PreUni, pObj.PrecioUnitario.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.CanFor, pObj.CantidadFormula.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.CanGrFor, pObj.CantidadGrFormula.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.CanKgFor, pObj.CantidadKgFormula.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.CTipDes, pObj.CTipoDescarga);
            xUpd.AsignarParametro(ProduccionExisEN.CTipFac, pObj.CTipoFactor);
            xUpd.AsignarParametro(ProduccionExisEN.CodAlmProTer, pObj.CodigoAlmacenProTer);
            xUpd.AsignarParametro(ProduccionExisEN.CodExiProTer, pObj.CodigoExistenciaProTer);
            xUpd.AsignarParametro(ProduccionExisEN.CodAlmOri, pObj.CodigoAlmacenOrigen);
            xUpd.AsignarParametro(ProduccionExisEN.ClaProProTer, pObj.ClaveProduccionProTer);
            xUpd.AsignarParametro(ProduccionExisEN.ClaEnc, pObj.ClaveEncajado);
            xUpd.AsignarParametro(ProduccionExisEN.ClaForCab, pObj.ClaveFormulaCabe);
            xUpd.AsignarParametro(ProduccionExisEN.ClaRet, pObj.ClaveRetiquetado);
            xUpd.AsignarParametro(ProduccionExisEN.CanDes, pObj.CantidadDesmedro.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.DetMotDes, pObj.DetalleMotivoDesmedro);
            xUpd.AsignarParametro(ProduccionExisEN.CEstDes, pObj.CEstadoDesmedro);
            xUpd.AsignarParametro(ProduccionExisEN.CanDevProExi, pObj.CantidadDevueltaProduccionExis.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.CodAlmCom, pObj.CodigoAlmacenCompra);
            xUpd.AsignarParametro(ProduccionExisEN.CSegLib, pObj.CSegundaLiberacion);
            xUpd.AsignarParametro(ProduccionExisEN.CanSegLib, pObj.CantidadSegundaLiberacion.ToString());
            xUpd.AsignarParametro(ProduccionExisEN.CEstSegLib, pObj.CEstadoSegundaLiberacion);
            xUpd.AsignarParametro(ProduccionExisEN.CEstProExi, pObj.CEstadoProduccionExis);
            xUpd.AsignarParametro(ProduccionExisEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ProduccionExisEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProExi, SqlSelect.Operador.Igual, pObj.ClaveProduccionExis);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar comando
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarProduccionExis(List<ProduccionExisEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(ProduccionExisEN.CanProExi, xProExi.CantidadProduccionExis.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.CanGr, xProExi.CantidadGr.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.CanKg, xProExi.CantidadKg.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.PreUni, xProExi.PrecioUnitario.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.CanFor, xProExi.CantidadFormula.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.CanGrFor, xProExi.CantidadGrFormula.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.CanKgFor, xProExi.CantidadKgFormula.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.CTipDes, xProExi.CTipoDescarga);
                xUpd.AsignarParametro(ProduccionExisEN.CTipFac, xProExi.CTipoFactor);
                xUpd.AsignarParametro(ProduccionExisEN.CodAlmProTer, xProExi.CodigoAlmacenProTer);
                xUpd.AsignarParametro(ProduccionExisEN.CodExiProTer, xProExi.CodigoExistenciaProTer);
                xUpd.AsignarParametro(ProduccionExisEN.CodAlmOri, xProExi.CodigoAlmacenOrigen);
                xUpd.AsignarParametro(ProduccionExisEN.ClaProProTer, xProExi.ClaveProduccionProTer);
                xUpd.AsignarParametro(ProduccionExisEN.ClaEnc, xProExi.ClaveEncajado);
                xUpd.AsignarParametro(ProduccionExisEN.ClaForCab, xProExi.ClaveFormulaCabe);
                xUpd.AsignarParametro(ProduccionExisEN.ClaRet, xProExi.ClaveRetiquetado);
                xUpd.AsignarParametro(ProduccionExisEN.CanDes, xProExi.CantidadDesmedro.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.DetMotDes, xProExi.DetalleMotivoDesmedro);
                xUpd.AsignarParametro(ProduccionExisEN.CEstDes, xProExi.CEstadoDesmedro);
                xUpd.AsignarParametro(ProduccionExisEN.CanDevProExi, xProExi.CantidadDevueltaProduccionExis.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.CodAlmCom, xProExi.CodigoAlmacenCompra);
                xUpd.AsignarParametro(ProduccionExisEN.CSegLib, xProExi.CSegundaLiberacion);
                xUpd.AsignarParametro(ProduccionExisEN.CanSegLib, xProExi.CantidadSegundaLiberacion.ToString());
                xUpd.AsignarParametro(ProduccionExisEN.CEstSegLib, xProExi.CEstadoSegundaLiberacion);
                xUpd.AsignarParametro(ProduccionExisEN.CEstProExi, xProExi.CEstadoProduccionExis);
                xUpd.AsignarParametro(ProduccionExisEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(ProduccionExisEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProExi, SqlSelect.Operador.Igual, xProExi.ClaveProduccionExis);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar comando
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
           
            xObjCon.Desconectar();
        }

        public void EliminarProduccionExis(ProduccionExisEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProExi, SqlSelect.Operador.Igual, pObj.ClaveProduccionExis);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarProduccionExisXClaveProduccionDeta(ProduccionExisEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarProduccionExisXClaveProduccionDetaYCTipoDescarga(ProduccionExisEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionExisEN.CTipDes, SqlSelect.Operador.Igual, pObj.CTipoDescarga);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarProduccionExisXClaveEncajado(ProduccionExisEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarProduccionExisXClaveRetiquetado(ProduccionExisEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaRet, SqlSelect.Operador.Igual, pObj.ClaveRetiquetado);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public ProduccionExisEN BuscarProduccionExisXClave(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProExi, SqlSelect.Operador.Igual, pObj.ClaveProduccionExis);
            return this.BuscarObjeto(xSel.ObtenerScript());       
        }

        public List<ProduccionExisEN> ListarProduccionExisXClaveProduccionDeta(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionExisEN> ListarProduccionExisXClaveProduccionDetaYTipoDescarga(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionExisEN.CTipDes, SqlSelect.Operador.Igual, pObj.CTipoDescarga);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionExisEN> ListarProduccionExisXClaveProduccionDetaYTiposDescarga(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProDet, SqlSelect.Operador.Igual, pObj.ClaveProduccionDeta);
            xSel.CondicionINx(SqlSelect.Reservada.Y, ProduccionExisEN.CTipDes, pObj.CTipoDescarga);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionExisEN> ListarProduccionExisDetalladoParaTransferirAProduccion()
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsProduccionExis";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CTipoDescarga In('0','1')";//solo materia prima y envasado
            iScript += " And ClaveProduccionDeta In(Select ClaveProduccionDeta From VsProduccionDeta Where ClaveSalidaFaseMasa='')";
            iScript += " Order By " + ProduccionExisEN.CodAlmOri + "," + ProduccionExisEN.CodExi;

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ProduccionExisEN> ListarProduccionExisDetalladoParaTransferirAProduccion(string pClavesProduccionDeta)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsProduccionExis";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CTipoDescarga In('0','1')";//solo materia prima y embasado
            iScript += " And ClaveProduccionDeta In(" + pClavesProduccionDeta + ")";
            iScript += " Order By " + ProduccionExisEN.ClaProDet + "," + ProduccionExisEN.CodAlmOri + "," + ProduccionExisEN.CodExi;

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ProduccionExisEN> ListarProduccionExisXClaveEncajado(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionExisEN> ListarProduccionExisXClaveProduccionProTer(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionExisEN> ListarProduccionExisParaTransferirAProduccion(string pClavesProduccionDeta)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsProduccionExis";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CTipoDescarga In('0','1')";//solo materia prima y embasado
            iScript += " And ClaveProduccionDeta In(" + pClavesProduccionDeta + ")";
            iScript += " Order By "  + ProduccionExisEN.CodAlmOri + "," + ProduccionExisEN.CodExi;

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ProduccionExisEN> ListarProduccionExisParaCompraEncajado()
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsProduccionExis";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CTipoDescarga='2'";//solo empaquetado
            iScript += " And ClaveEncajado In(Select ClaveEncajado From Encajado Where ClaveSalidaFaseEmpaquetado='')";
            iScript += " Order By " + ProduccionExisEN.ClaEnc + "," + ProduccionExisEN.ClaProProTer;

            //resultado
            return this.ListarObjetos(iScript);
        }

        public List<ProduccionExisEN> ListarProduccionExisParaRecalculoProducciones(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionExisEN.PerProDet, SqlSelect.Operador.Igual, pObj.PeriodoProduccionDeta);
            xSel.CondicionCV(SqlSelect.Reservada.O, ProduccionExisEN.PerEnc, SqlSelect.Operador.Igual, pObj.PeriodoEncajado);
            xSel.CondicionCV(SqlSelect.Reservada.O, ProduccionExisEN.PerRet, SqlSelect.Operador.Igual, pObj.PeriodoRetiquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionExisEN> ListarProduccionExisXClaveRetiquetado(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaRet, SqlSelect.Operador.Igual, pObj.ClaveRetiquetado);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ProduccionExisEN> ListarProduccionExisXClaveProduccionProTerYSegundaLiberacion(ProduccionExisEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ProduccionExisEN.ClaProProTer, SqlSelect.Operador.Igual, pObj.ClaveProduccionProTer);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ProduccionExisEN.CSegLib, SqlSelect.Operador.Igual, "1");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

    }
}
