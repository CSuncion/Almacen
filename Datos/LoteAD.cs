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

    public class LoteAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<LoteEN> xLista = new List<LoteEN>();
        private LoteEN xObj = new LoteEN();
        private string xTabla = "Lote";
        private string xVista = "VsLote";

        #endregion
        
        #region Metodos privados

        private LoteEN Objeto(IDataReader iDr)
        {
            LoteEN xObjEnc = new LoteEN();
            xObjEnc.ClaveLote = iDr[LoteEN.ClaLot].ToString();           
            xObjEnc.CodigoEmpresa = iDr[LoteEN.CodEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[LoteEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[LoteEN.DesAlm].ToString();
            xObjEnc.CodigoExistencia = iDr[LoteEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[LoteEN.DesExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[LoteEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[LoteEN.NomUniMed].ToString();
            xObjEnc.CodigoLote = iDr[LoteEN.CodLot].ToString();
            xObjEnc.FechaVencimientoLote = Fecha.ObtenerDiaMesAno( iDr[LoteEN.FecVenLot]);           
            xObjEnc.StockLote = Convert.ToDecimal(iDr[LoteEN.StoLot].ToString());
            xObjEnc.StockSaldoLote = Convert.ToDecimal(iDr[LoteEN.StoSalLot].ToString());
            xObjEnc.ClaveMovimientoDeta = iDr[LoteEN.ClaMovDet].ToString();
            xObjEnc.ClaveMovimientoCabe = iDr[LoteEN.ClaMovCab].ToString();
            xObjEnc.UltimoCorrelativoLoteDeta = iDr[LoteEN.UltCorLotDet].ToString();
            xObjEnc.NumeroLote = iDr[LoteEN.NumLot].ToString();
            xObjEnc.FechaProduccionLote = Fecha.ObtenerDiaMesAno(iDr[LoteEN.FecProLot]);
            xObjEnc.StockConversionLote = Convert.ToDecimal(iDr[LoteEN.StoConLot].ToString());
            xObjEnc.CEstadoLote = iDr[LoteEN.CEstLot].ToString();
            xObjEnc.NEstadoLote = iDr[LoteEN.NEstLot].ToString();
            xObjEnc.UsuarioAgrega = iDr[LoteEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[LoteEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[LoteEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[LoteEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveLote;
            return xObjEnc;
        }
        
        private List<LoteEN> ListarObjetos(string pScript)
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
        
        private LoteEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(LoteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, LoteEN.CodLot);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LoteEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LoteEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);            
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarLote(LoteEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(LoteEN.ClaLot, pObj.ClaveLote);
            xIns.AsignarParametro(LoteEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(LoteEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(LoteEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(LoteEN.CodLot, pObj.CodigoLote);
            xIns.AsignarParametro(LoteEN.FecVenLot, Fecha.ObtenerAnoMesDia(pObj.FechaVencimientoLote));           
            xIns.AsignarParametro(LoteEN.StoLot, pObj.StockLote.ToString());
            xIns.AsignarParametro(LoteEN.StoSalLot, pObj.StockSaldoLote.ToString());
            xIns.AsignarParametro(LoteEN.ClaMovDet, pObj.ClaveMovimientoDeta);
            xIns.AsignarParametro(LoteEN.ClaMovCab, pObj.ClaveMovimientoCabe);
            xIns.AsignarParametro(LoteEN.UltCorLotDet, pObj.UltimoCorrelativoLoteDeta);
            xIns.AsignarParametro(LoteEN.NumLot, pObj.NumeroLote);
            xIns.AsignarParametro(LoteEN.FecProLot, Fecha.ObtenerAnoMesDia(pObj.FechaProduccionLote));
            xIns.AsignarParametro(LoteEN.StoConLot, pObj.StockConversionLote.ToString());
            xIns.AsignarParametro(LoteEN.CEstLot, pObj.CEstadoLote);
            xIns.AsignarParametro(LoteEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(LoteEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(LoteEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(LoteEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarLote(List< LoteEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LoteEN xExi in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(LoteEN.ClaLot, xExi.ClaveLote);
                xIns.AsignarParametro(LoteEN.CodEmp, xExi.CodigoEmpresa);
                xIns.AsignarParametro(LoteEN.CodAlm, xExi.CodigoAlmacen);
                xIns.AsignarParametro(LoteEN.CodExi, xExi.CodigoExistencia);
                xIns.AsignarParametro(LoteEN.CodLot, xExi.CodigoLote);
                xIns.AsignarParametro(LoteEN.FecVenLot, Fecha.ObtenerAnoMesDia(xExi.FechaVencimientoLote));
                xIns.AsignarParametro(LoteEN.StoLot, xExi.StockLote.ToString());
                xIns.AsignarParametro(LoteEN.StoSalLot, xExi.StockSaldoLote.ToString());
                xIns.AsignarParametro(LoteEN.ClaMovDet, xExi.ClaveMovimientoDeta);
                xIns.AsignarParametro(LoteEN.ClaMovCab, xExi.ClaveMovimientoCabe);
                xIns.AsignarParametro(LoteEN.UltCorLotDet, xExi.UltimoCorrelativoLoteDeta);
                xIns.AsignarParametro(LoteEN.NumLot, xExi.NumeroLote);
                xIns.AsignarParametro(LoteEN.FecProLot, Fecha.ObtenerAnoMesDia(xExi.FechaProduccionLote));
                xIns.AsignarParametro(LoteEN.StoConLot, xExi.StockConversionLote.ToString());
                xIns.AsignarParametro(LoteEN.CEstLot, xExi.CEstadoLote);
                xIns.AsignarParametro(LoteEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(LoteEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(LoteEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(LoteEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarLote(LoteEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(LoteEN.FecVenLot, Fecha.ObtenerAnoMesDia(pObj.FechaVencimientoLote));           
            xUpd.AsignarParametro(LoteEN.StoLot, pObj.StockLote.ToString());
            xUpd.AsignarParametro(LoteEN.StoSalLot, pObj.StockSaldoLote.ToString());
            xUpd.AsignarParametro(LoteEN.ClaMovDet, pObj.ClaveMovimientoDeta);
            xUpd.AsignarParametro(LoteEN.ClaMovCab, pObj.ClaveMovimientoCabe);
            xUpd.AsignarParametro(LoteEN.UltCorLotDet, pObj.UltimoCorrelativoLoteDeta);
            xUpd.AsignarParametro(LoteEN.NumLot, pObj.NumeroLote);
            xUpd.AsignarParametro(LoteEN.FecProLot, Fecha.ObtenerAnoMesDia(pObj.FechaProduccionLote));
            xUpd.AsignarParametro(LoteEN.StoConLot, pObj.StockConversionLote.ToString());
            xUpd.AsignarParametro(LoteEN.CEstLot, pObj.CEstadoLote);
            xUpd.AsignarParametro(LoteEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(LoteEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.ClaLot, SqlSelect.Operador.Igual, pObj.ClaveLote);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarLote(List<LoteEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LoteEN xExi in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(LoteEN.FecVenLot, Fecha.ObtenerAnoMesDia(xExi.FechaVencimientoLote));
                xUpd.AsignarParametro(LoteEN.StoLot, xExi.StockLote.ToString());
                xUpd.AsignarParametro(LoteEN.StoSalLot, xExi.StockSaldoLote.ToString());
                xUpd.AsignarParametro(LoteEN.ClaMovDet, xExi.ClaveMovimientoDeta);
                xUpd.AsignarParametro(LoteEN.ClaMovCab, xExi.ClaveMovimientoCabe);
                xUpd.AsignarParametro(LoteEN.UltCorLotDet, xExi.UltimoCorrelativoLoteDeta);
                xUpd.AsignarParametro(LoteEN.NumLot, xExi.NumeroLote);
                xUpd.AsignarParametro(LoteEN.FecProLot, Fecha.ObtenerAnoMesDia(xExi.FechaProduccionLote));
                xUpd.AsignarParametro(LoteEN.StoConLot, xExi.StockConversionLote.ToString());
                xUpd.AsignarParametro(LoteEN.CEstLot, xExi.CEstadoLote);
                xUpd.AsignarParametro(LoteEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(LoteEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.ClaLot, SqlSelect.Operador.Igual, xExi.ClaveLote);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
           
            xObjCon.Desconectar();
        }

        public void EliminarLote(LoteEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.ClaLot, SqlSelect.Operador.Igual, pObj.ClaveLote);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarLote(List< LoteEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LoteEN xExi in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.ClaLot, SqlSelect.Operador.Igual, xExi.ClaveLote);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void EliminarLoteXClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.ClaMovCab, SqlSelect.Operador.Igual, pClaveMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<LoteEN> ListarLotes(LoteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public LoteEN BuscarLoteXClave(LoteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.ClaLot, SqlSelect.Operador.Igual, pObj.ClaveLote);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<LoteEN> ListarLotesDeAlmacen(LoteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LoteEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LoteEN> ListarLotesDeClaveMovimientoCabe(LoteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<List<LoteEN>> ListarListasDeLotesConSaldoPorExistencia(LoteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LoteEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionINx(SqlSelect.Reservada.Y, LoteEN.CodExi, pObj.CodigoExistencia);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LoteEN.StoSalLot, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(LoteEN.FecVenLot + "," + LoteEN.CodLot, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<LoteEN>> iLisRes = new List<List<LoteEN>>();

            //variables
            string iExistencia = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                LoteEN iLotEN = new LoteEN();
                iLotEN = this.Objeto(xIdr);

                //preguntamos si es una existencia diferente
                if (iLotEN.CodigoExistencia != iExistencia)
                {
                    List<LoteEN> iLisLot = new List<LoteEN>();
                    iLisLot.Add(iLotEN);
                    iLisRes.Add(iLisLot);
                    iIndice++;
                    iExistencia = iLotEN.CodigoExistencia;
                }
                else
                {
                    iLisRes[iIndice].Add(iLotEN);
                }
            }
            xObjCon.Desconectar();
            return iLisRes;
        }

        public List<LoteEN> ListarLotesDeClavesLote(LoteEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionINx(SqlSelect.Reservada.Cuando, LoteEN.ClaLot, pObj.ClaveLote);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LoteEN> ListarLotesParaRecalculo(string pStrEmpresaPeriodo)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsLote";          
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                iScript += " And CodigoAlmacen in(" + Universal.gStrPermisosAlmacen + ")";                
            }            
            iScript += " And ClaveLote in(Select ClaveLote from VsLoteDeta where ClaveMovimientoCabe Like '";
            iScript += pStrEmpresaPeriodo + "%')";

            //resultado
            return this.ListarObjetos(iScript);
        }

        #endregion

    }
}
