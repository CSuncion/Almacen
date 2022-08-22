using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptBD;
using System.Data;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Datos.Config;


namespace Datos
{

    public class ItemEAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<ItemEEN> xLista = new List<ItemEEN>();
        private ItemEEN xObj = new ItemEEN();
        private string xTabla = "ItemE";
        private string xVista = "VsItemE";

        #endregion
                
        #region Metodos privados

        private ItemEEN Objeto(IDataReader iDr)
        {
            ItemEEN xObjEnc = new ItemEEN();
            xObjEnc.ClaveItemE = iDr[ItemEEN.ClaIteE].ToString();
            xObjEnc.CodigoEmpresa = iDr[ItemEEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[ItemEEN.NomEmp].ToString();
            xObjEnc.CodigoTabla = iDr[ItemEEN.CodTab].ToString();
            xObjEnc.NombreTabla = iDr[ItemEEN.NomTab].ToString();
            xObjEnc.CodigoItemE = iDr[ItemEEN.CodIteE].ToString();
            xObjEnc.NombreItemE = iDr[ItemEEN.NomIteE].ToString();
            xObjEnc.AbreviaItemE = iDr[ItemEEN.AbrIteE].ToString();
            xObjEnc.CEstadoItemE = iDr[ItemEEN.CEstIteE].ToString();
            xObjEnc.NEstadoItemE = iDr[ItemEEN.NEstIteE].ToString();
            xObjEnc.UsuarioAgrega = iDr[ItemEEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ItemEEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[ItemEEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ItemEEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveItemE;
            return xObjEnc;
        }
        
        private List<ItemEEN> ListarObjetos(string pScript)
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
        
        private ItemEEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemEEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarItemE(ItemEEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(ItemEEN.ClaIteE, pObj.ClaveItemE);
            xIns.AsignarParametro(ItemEEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(ItemEEN.CodTab, pObj.CodigoTabla);
            xIns.AsignarParametro(ItemEEN.CodIteE, pObj.CodigoItemE);
            xIns.AsignarParametro(ItemEEN.NomIteE, pObj.NombreItemE);
            xIns.AsignarParametro(ItemEEN.AbrIteE, pObj.AbreviaItemE);
            xIns.AsignarParametro(ItemEEN.CEstIteE, pObj.CEstadoItemE);
            xIns.AsignarParametro(ItemEEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ItemEEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(ItemEEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ItemEEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarItemE(ItemEEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(ItemEEN.NomIteE, pObj.NombreItemE);
            xUpd.AsignarParametro(ItemEEN.AbrIteE, pObj.AbreviaItemE);
            xUpd.AsignarParametro(ItemEEN.CEstIteE, pObj.CEstadoItemE);
            xUpd.AsignarParametro(ItemEEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ItemEEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemEEN.ClaIteE, SqlSelect.Operador.Igual, pObj.ClaveItemE);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarItemE(ItemEEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemEEN.ClaIteE, SqlSelect.Operador.Igual, pObj.ClaveItemE);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<ItemEEN> ListarItemsGXTabla(ItemEEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemEEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemEEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemEEN> ListarItemsGActivosXTabla(ItemEEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemEEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemEEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemEEN.CEstIteE, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemEEN> ListarItemsGActivosXTablaYArea(ItemEEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemEEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemEEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemEEN.CEstIteE, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionLike(SqlSelect.Reservada.Y, ItemEEN.CodIteE, pObj.CodigoItemE);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public ItemEEN BuscarItemEXClave(ItemEEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemEEN.ClaIteE, SqlSelect.Operador.Igual, pObj.ClaveItemE);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<ItemEEN> ListarItemsGActivosXTablaYFiltroCodigo(ItemEEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemEEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemEEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemEEN.CEstIteE, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionLike(SqlSelect.Reservada.Y, ItemEEN.CodIteE, pObj.CodigoItemE);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


        #endregion


    }
}
