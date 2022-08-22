using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Datos.Config;

namespace Datos
{

    public class TablaAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<TablaEN> xLista = new List<TablaEN>();
        private TablaEN xObj = new TablaEN();
        private string xTabla = "Tabla";
        private string xVista = "VsTabla";


        #region Metodos privados

        private TablaEN Objeto(IDataReader iDr)
        {
            TablaEN xObjEnc = new TablaEN();
            xObjEnc.CodigoTabla = iDr[TablaEN.CodTab].ToString();
            xObjEnc.NombreTabla = iDr[TablaEN.NomTab].ToString();
            xObjEnc.CategoriaTabla = iDr[TablaEN.CatTab].ToString();
            xObjEnc.CEstadoTabla = iDr[TablaEN.CEstTab].ToString();
            xObjEnc.NEstadoTabla = iDr[TablaEN.NEstTab].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.CodigoTabla;
            return xObjEnc;
        }


        private List<TablaEN> ListarObjetos(string pScript)
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


        private TablaEN BuscarObjeto(string pScript)
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


        public bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumna, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumna, SqlSelect.Operador.Igual, pValor);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }


        public void AgregarTabla(TablaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(TablaEN.CodTab, pObj.CodigoTabla);
            xIns.AsignarParametro(TablaEN.NomTab, pObj.NombreTabla);
            xIns.AsignarParametro(TablaEN.CatTab, pObj.CategoriaTabla);
            xIns.AsignarParametro(TablaEN.CatTab, pObj.CEstadoTabla);
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void ModificarTabla(TablaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(TablaEN.NomTab, pObj.NombreTabla);
            xUpd.AsignarParametro(TablaEN.CatTab, pObj.CategoriaTabla);
            xUpd.AsignarParametro(TablaEN.CatTab, pObj.CEstadoTabla);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TablaEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void EliminarTabla(TablaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TablaEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public List<TablaEN> ListarTablas(TablaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


        public List<TablaEN> ListarTablasXCategoria(TablaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TablaEN.CatTab, SqlSelect.Operador.Igual, pObj.CategoriaTabla);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


        public TablaEN BuscarTablaXCodigo(TablaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TablaEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

    

    }
}
