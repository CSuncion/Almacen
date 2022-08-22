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

    public class LoteDetaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<LoteDetaEN> xLista = new List<LoteDetaEN>();
        private LoteDetaEN xObj = new LoteDetaEN();
        private string xTabla = "LoteDeta";
        private string xVista = "VsLoteDeta";

        #endregion
        
        #region Metodos privados

        private LoteDetaEN Objeto(IDataReader iDr)
        {
            LoteDetaEN xObjEnc = new LoteDetaEN();
            xObjEnc.ClaveLoteDeta = iDr[LoteDetaEN.ClaLotDet].ToString();
            xObjEnc.ClaveLote = iDr[LoteDetaEN.ClaLot].ToString();
            xObjEnc.FechaProduccionLote = Fecha.ObtenerDiaMesAno(iDr[LoteDetaEN.FecProLot]);
            xObjEnc.FechaVencimientoLote = Fecha.ObtenerDiaMesAno(iDr[LoteDetaEN.FecVenLot]);
            xObjEnc.CodigoEmpresa = iDr[LoteDetaEN.CodEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[LoteDetaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[LoteDetaEN.DesAlm].ToString();
            xObjEnc.CodigoExistencia = iDr[LoteDetaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[LoteDetaEN.DesExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[LoteDetaEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[LoteDetaEN.NomUniMed].ToString();
            xObjEnc.CodigoLote = iDr[LoteDetaEN.CodLot].ToString();
            xObjEnc.CorrelativoLoteDeta = iDr[LoteDetaEN.CorLotDet].ToString();
            xObjEnc.CantidadLoteDeta = Convert.ToDecimal(iDr[LoteDetaEN.CanLotDet].ToString());
            xObjEnc.StockAnteriorLote = Convert.ToDecimal(iDr[LoteDetaEN.StoAntLot].ToString());
            xObjEnc.ClaveMovimientoDeta = iDr[LoteDetaEN.ClaMovDet].ToString();
            xObjEnc.ClaveMovimientoCabe = iDr[LoteDetaEN.ClaMovCab].ToString();           
            xObjEnc.UsuarioAgrega = iDr[LoteDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[LoteDetaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[LoteDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[LoteDetaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveLote;
            return xObjEnc;
        }
        
        private List<LoteDetaEN> ListarObjetos(string pScript)
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
        
        private LoteDetaEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(LoteDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, LoteDetaEN.CodLot);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LoteDetaEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LoteDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);            
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarLoteDeta(LoteDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(LoteDetaEN.ClaLotDet, pObj.ClaveLoteDeta);
            xIns.AsignarParametro(LoteDetaEN.ClaLot, pObj.ClaveLote);
            xIns.AsignarParametro(LoteDetaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(LoteDetaEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(LoteDetaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(LoteDetaEN.CodLot, pObj.CodigoLote);
            xIns.AsignarParametro(LoteDetaEN.CorLotDet, pObj.CorrelativoLoteDeta);           
            xIns.AsignarParametro(LoteDetaEN.CanLotDet, pObj.CantidadLoteDeta.ToString());
            xIns.AsignarParametro(LoteDetaEN.StoAntLot, pObj.StockAnteriorLote.ToString());
            xIns.AsignarParametro(LoteDetaEN.ClaMovDet, pObj.ClaveMovimientoDeta);
            xIns.AsignarParametro(LoteDetaEN.ClaMovCab, pObj.ClaveMovimientoCabe);
            xIns.AsignarParametro(LoteDetaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(LoteDetaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(LoteDetaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(LoteDetaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarLoteDeta(List< LoteDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LoteDetaEN xExi in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(LoteDetaEN.ClaLotDet, xExi.ClaveLoteDeta);
                xIns.AsignarParametro(LoteDetaEN.ClaLot, xExi.ClaveLote);
                xIns.AsignarParametro(LoteDetaEN.CodEmp, xExi.CodigoEmpresa);
                xIns.AsignarParametro(LoteDetaEN.CodAlm, xExi.CodigoAlmacen);
                xIns.AsignarParametro(LoteDetaEN.CodExi, xExi.CodigoExistencia);
                xIns.AsignarParametro(LoteDetaEN.CodLot, xExi.CodigoLote);
                xIns.AsignarParametro(LoteDetaEN.CorLotDet, xExi.CorrelativoLoteDeta);
                xIns.AsignarParametro(LoteDetaEN.CanLotDet, xExi.CantidadLoteDeta.ToString());
                xIns.AsignarParametro(LoteDetaEN.StoAntLot, xExi.StockAnteriorLote.ToString());
                xIns.AsignarParametro(LoteDetaEN.ClaMovDet, xExi.ClaveMovimientoDeta);
                xIns.AsignarParametro(LoteDetaEN.ClaMovCab, xExi.ClaveMovimientoCabe);               
                xIns.AsignarParametro(LoteDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(LoteDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(LoteDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(LoteDetaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarLoteDeta(LoteDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);                 
            xUpd.AsignarParametro(LoteDetaEN.CanLotDet, pObj.CantidadLoteDeta.ToString());
            xUpd.AsignarParametro(LoteDetaEN.ClaMovDet, pObj.ClaveMovimientoDeta);
            xUpd.AsignarParametro(LoteDetaEN.ClaMovCab, pObj.ClaveMovimientoCabe);
            xUpd.AsignarParametro(LoteDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(LoteDetaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.ClaLotDet, SqlSelect.Operador.Igual, pObj.ClaveLoteDeta);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarLoteDeta(List<LoteDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LoteDetaEN xExi in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(LoteDetaEN.CanLotDet, xExi.CantidadLoteDeta.ToString());
                xUpd.AsignarParametro(LoteDetaEN.StoAntLot, xExi.StockAnteriorLote.ToString());
                xUpd.AsignarParametro(LoteDetaEN.ClaMovDet, xExi.ClaveMovimientoDeta);
                xUpd.AsignarParametro(LoteDetaEN.ClaMovCab, xExi.ClaveMovimientoCabe);
                xUpd.AsignarParametro(LoteDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(LoteDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.ClaLotDet, SqlSelect.Operador.Igual, xExi.ClaveLoteDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
           
            xObjCon.Desconectar();
        }

        public void EliminarLoteDeta(LoteDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.ClaLotDet, SqlSelect.Operador.Igual, pObj.ClaveLoteDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarLoteDeta(List< LoteDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (LoteDetaEN xExi in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.ClaLotDet, SqlSelect.Operador.Igual, xExi.ClaveLoteDeta);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void EliminarLoteDetaXClaveMovimientoCabe(string pClaveMovimientoCabe)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.ClaMovCab, SqlSelect.Operador.Igual, pClaveMovimientoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<LoteDetaEN> ListarLotesDeta(LoteDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public LoteDetaEN BuscarLoteDetaXClave(LoteDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.ClaLotDet, SqlSelect.Operador.Igual, pObj.ClaveLoteDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<LoteDetaEN> ListarLotesDetaDeClaveMovimientoCabe(LoteDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LoteDetaEN.ClaMovCab, SqlSelect.Operador.Igual, pObj.ClaveMovimientoCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LoteDetaEN> ListarLotesDetaParaRecalculo(string pStrEmpresaPeriodo)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsLoteDeta";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                iScript += " And CodigoAlmacen in(" + Universal.gStrPermisosAlmacen + ")";
            }
            iScript += " And ClaveLote in(Select ClaveLote from VsLoteDeta where ClaveMovimientoCabe Like '";
            iScript += pStrEmpresaPeriodo + "%')";
            iScript += " Order By " + LoteDetaEN.ClaLotDet;

            //resultado
            return this.ListarObjetos(iScript);
        }


        #endregion

    }
}
