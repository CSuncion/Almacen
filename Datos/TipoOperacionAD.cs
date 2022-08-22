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

namespace Datos
{

    public class TipoOperacionAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<TipoOperacionEN> xLista = new List<TipoOperacionEN>();
        private TipoOperacionEN xObj = new TipoOperacionEN();
        private string xTabla = "TipoOperacion";
        private string xVista = "VsTipoOperacion";

        #endregion
        
        #region Metodos privados

        private TipoOperacionEN Objeto(IDataReader iDr)
        {
            TipoOperacionEN xObjEnc = new TipoOperacionEN();
            xObjEnc.CodigoTipoOperacion = iDr[TipoOperacionEN.CodTipOpe].ToString();           
            xObjEnc.DescripcionTipoOperacion = iDr[TipoOperacionEN.DesTipOpe].ToString();
            xObjEnc.CClaseTipoOperacion = iDr[TipoOperacionEN.CClaTipOpe].ToString();
            xObjEnc.NClaseTipoOperacion = iDr[TipoOperacionEN.NClaTipOpe].ToString();
            xObjEnc.CCalculaPrecioPromedio = iDr[TipoOperacionEN.CCalPrePro].ToString();
            xObjEnc.NCalculaPrecioPromedio = iDr[TipoOperacionEN.NCalPrePro].ToString();
            xObjEnc.CConversionUnidad = iDr[TipoOperacionEN.CConUni].ToString();
            xObjEnc.NConversionUnidad = iDr[TipoOperacionEN.NConUni].ToString();
            xObjEnc.CEstadoTipoOperacion = iDr[TipoOperacionEN.CEstTipOpe].ToString();
            xObjEnc.NEstadoTipoOperacion = iDr[TipoOperacionEN.NEstTipOpe].ToString();
            xObjEnc.UsuarioAgrega = iDr[TipoOperacionEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[TipoOperacionEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[TipoOperacionEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[TipoOperacionEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.CodigoTipoOperacion;
            return xObjEnc;
        }
        
        private List<TipoOperacionEN> ListarObjetos(string pScript)
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
        
        private TipoOperacionEN BuscarObjeto(string pScript)
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

        #endregion

        #region Metodos publicos

        public bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumna, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumna, SqlSelect.Operador.Igual, pValor);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarTipoOperacion(TipoOperacionEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(TipoOperacionEN.CodTipOpe, pObj.CodigoTipoOperacion);
            xIns.AsignarParametro(TipoOperacionEN.DesTipOpe, pObj.DescripcionTipoOperacion);
            xIns.AsignarParametro(TipoOperacionEN.CClaTipOpe, pObj.CClaseTipoOperacion);
            xIns.AsignarParametro(TipoOperacionEN.CCalPrePro, pObj.CCalculaPrecioPromedio);
            xIns.AsignarParametro(TipoOperacionEN.CConUni, pObj.CConversionUnidad);
            xIns.AsignarParametro(TipoOperacionEN.CEstTipOpe, pObj.CEstadoTipoOperacion);
            xIns.AsignarParametro(TipoOperacionEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(TipoOperacionEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(TipoOperacionEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(TipoOperacionEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarTipoOperacion(TipoOperacionEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(TipoOperacionEN.DesTipOpe, pObj.DescripcionTipoOperacion);
            xUpd.AsignarParametro(TipoOperacionEN.CClaTipOpe, pObj.CClaseTipoOperacion);
            xUpd.AsignarParametro(TipoOperacionEN.CCalPrePro, pObj.CCalculaPrecioPromedio);
            xUpd.AsignarParametro(TipoOperacionEN.CConUni, pObj.CConversionUnidad);
            xUpd.AsignarParametro(TipoOperacionEN.CEstTipOpe, pObj.CEstadoTipoOperacion);
            xUpd.AsignarParametro(TipoOperacionEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(TipoOperacionEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoOperacionEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarTipoOperacion(TipoOperacionEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoOperacionEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<TipoOperacionEN> ListarTipoOperaciones(TipoOperacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public TipoOperacionEN BuscarTipoOperacionXCodigo(TipoOperacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoOperacionEN.CodTipOpe, SqlSelect.Operador.Igual, pObj.CodigoTipoOperacion);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<TipoOperacionEN> ListarTiposOperacionesXClase(TipoOperacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoOperacionEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<TipoOperacionEN> ListarTiposOperacionesXClaseActivos(TipoOperacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoOperacionEN.CClaTipOpe, SqlSelect.Operador.Igual, pObj.CClaseTipoOperacion);
            xSel.CondicionCV(SqlSelect.Reservada.Y, TipoOperacionEN.CEstTipOpe, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
