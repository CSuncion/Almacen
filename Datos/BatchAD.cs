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

    public class BatchAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<BatchEN> xLista = new List<BatchEN>();
        private BatchEN xObj = new BatchEN();
        private string xTabla = "Batch";
        private string xVista = "VsBatch";

        #endregion
        
        #region Metodos privados

        private BatchEN Objeto(IDataReader iDr)
        {
            BatchEN xObjEnc = new BatchEN();
            xObjEnc.ClaveBatch = iDr[BatchEN.ClaBat].ToString();           
            xObjEnc.CodigoEmpresa = iDr[BatchEN.CodEmp].ToString();
            xObjEnc.PeriodoBatch = iDr[BatchEN.PerBat].ToString();
            xObjEnc.CorrelativoBatch = iDr[BatchEN.CorBat].ToString();
            //xObjEnc.CodigoAlmacen = iDr[BatchEN.CodAlm].ToString();
            //xObjEnc.DescripcionAlmacen = iDr[BatchEN.DesAlm].ToString();
            //xObjEnc.CodigoExistencia = iDr[BatchEN.CodExi].ToString();
            //xObjEnc.DescripcionExistencia = iDr[BatchEN.DesExi].ToString();
            //xObjEnc.CodigoUnidadMedida = iDr[BatchEN.CodUniMed].ToString();
            //xObjEnc.NombreUnidadMedida = iDr[BatchEN.NomUniMed].ToString();
            xObjEnc.CodigoBatch = iDr[BatchEN.CodBat].ToString();
            //xObjEnc.FechaVencimientoBatch = Fecha.ObtenerDiaMesAno( iDr[BatchEN.FecVenLot]);           
            xObjEnc.StockBatch = Convert.ToDecimal(iDr[BatchEN.StoBat].ToString());
            xObjEnc.StockSaldoBatch = Convert.ToDecimal(iDr[BatchEN.StoSalBat].ToString());
            xObjEnc.ClaveLote = iDr[BatchEN.ClaLot].ToString();
            //xObjEnc.ClaveMovimientoDeta = iDr[BatchEN.ClaMovDet].ToString();
            //xObjEnc.ClaveMovimientoCabe = iDr[BatchEN.ClaMovCab].ToString();
            //xObjEnc.UltimoCorrelativoBatchDeta = iDr[BatchEN.UltCorLotDet].ToString();
            xObjEnc.CEstadoBatch = iDr[BatchEN.CEstBat].ToString();
            xObjEnc.NEstadoBatch = iDr[BatchEN.NEstBat].ToString();
            xObjEnc.UsuarioAgrega = iDr[BatchEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[BatchEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[BatchEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[BatchEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveBatch;
            return xObjEnc;
        }
        
        private List<BatchEN> ListarObjetos(string pScript)
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
        
        private BatchEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(BatchEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, BatchEN.CorBat);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, BatchEN.PerBat, SqlSelect.Operador.Igual, pObj.PeriodoBatch);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarBatch(BatchEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(BatchEN.ClaBat, pObj.ClaveBatch);
            xIns.AsignarParametro(BatchEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(BatchEN.PerBat, pObj.PeriodoBatch);
            xIns.AsignarParametro(BatchEN.CorBat, pObj.CorrelativoBatch);           
            xIns.AsignarParametro(BatchEN.CodBat, pObj.CodigoBatch);                  
            xIns.AsignarParametro(BatchEN.StoBat, pObj.StockBatch.ToString());
            xIns.AsignarParametro(BatchEN.StoSalBat, pObj.StockSaldoBatch.ToString());
            xIns.AsignarParametro(BatchEN.ClaLot, pObj.ClaveLote);            
            xIns.AsignarParametro(BatchEN.CEstBat, pObj.CEstadoBatch);
            xIns.AsignarParametro(BatchEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(BatchEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(BatchEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(BatchEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarBatch(List< BatchEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (BatchEN xExi in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(BatchEN.ClaBat, xExi.ClaveBatch);
                xIns.AsignarParametro(BatchEN.CodEmp, xExi.CodigoEmpresa);
                xIns.AsignarParametro(BatchEN.PerBat, xExi.PeriodoBatch);
                xIns.AsignarParametro(BatchEN.CorBat, xExi.CorrelativoBatch);
                xIns.AsignarParametro(BatchEN.CodBat, xExi.CodigoBatch);
                xIns.AsignarParametro(BatchEN.StoBat, xExi.StockBatch.ToString());
                xIns.AsignarParametro(BatchEN.StoSalBat, xExi.StockSaldoBatch.ToString());
                xIns.AsignarParametro(BatchEN.ClaLot, xExi.ClaveLote);
                xIns.AsignarParametro(BatchEN.CEstBat, xExi.CEstadoBatch);
                xIns.AsignarParametro(BatchEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(BatchEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(BatchEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(BatchEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarBatch(BatchEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);                
            xUpd.AsignarParametro(BatchEN.StoBat, pObj.StockBatch.ToString());
            xUpd.AsignarParametro(BatchEN.StoSalBat, pObj.StockSaldoBatch.ToString());
            xUpd.AsignarParametro(BatchEN.ClaLot, pObj.ClaveLote);            
            xUpd.AsignarParametro(BatchEN.CEstBat, pObj.CEstadoBatch);
            xUpd.AsignarParametro(BatchEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(BatchEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.ClaBat, SqlSelect.Operador.Igual, pObj.ClaveBatch);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarBatch(List<BatchEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (BatchEN xExi in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(BatchEN.StoBat, xExi.StockBatch.ToString());
                xUpd.AsignarParametro(BatchEN.StoSalBat, xExi.StockSaldoBatch.ToString());
                xUpd.AsignarParametro(BatchEN.ClaLot, xExi.ClaveLote);
                xUpd.AsignarParametro(BatchEN.CEstBat, xExi.CEstadoBatch);
                xUpd.AsignarParametro(BatchEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(BatchEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.ClaBat, SqlSelect.Operador.Igual, xExi.ClaveBatch);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
           
            xObjCon.Desconectar();
        }

        public void EliminarBatch(BatchEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.ClaBat, SqlSelect.Operador.Igual, pObj.ClaveBatch);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarBatch(List< BatchEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (BatchEN xExi in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.ClaBat, SqlSelect.Operador.Igual, xExi.ClaveBatch);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void EliminarBatchXClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.ClaMovCab, SqlSelect.Operador.Igual, pClaveMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<BatchEN> ListarBatchs(BatchEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public BatchEN BuscarBatchXClave(BatchEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BatchEN.ClaBat, SqlSelect.Operador.Igual, pObj.ClaveBatch);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }
     
        #endregion

    }
}
