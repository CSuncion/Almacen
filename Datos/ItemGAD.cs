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

    public class ItemGAD
    {

        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<ItemGEN> xLista = new List<ItemGEN>();
        private ItemGEN xObj = new ItemGEN();
        private string xTabla = "ItemG";
        private string xVista = "VsItemG";


        #region Metodos privados

        private ItemGEN Objeto(IDataReader iDr)
        {
            ItemGEN xObjEnc = new ItemGEN();
            xObjEnc.ClaveItemG = iDr[ItemGEN.ClaIteG].ToString();
            xObjEnc.CodigoTabla = iDr[ItemGEN.CodTab].ToString();
            xObjEnc.NombreTabla = iDr[ItemGEN.NomTab].ToString();
            xObjEnc.CodigoItemG = iDr[ItemGEN.CodIteG].ToString();
            xObjEnc.NombreItemG = iDr[ItemGEN.NomIteG].ToString();
            xObjEnc.AbreviaItemG = iDr[ItemGEN.AbrIteG].ToString();
            xObjEnc.CEstadoItemG = iDr[ItemGEN.CEstIteG].ToString();
            xObjEnc.NEstadoItemG = iDr[ItemGEN.NEstIteG].ToString();
            xObjEnc.UsuarioAgrega = iDr[ItemGEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ItemGEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[ItemGEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ItemGEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveItemG;
            return xObjEnc;
        }



        private List<ItemGEN> ListarObjetos(string pScript)
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


        private ItemGEN BuscarObjeto(string pScript)
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
        
        public void AgregarItemG(ItemGEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(ItemGEN.ClaIteG, pObj.ClaveItemG);
            xIns.AsignarParametro(ItemGEN.CodTab, pObj.CodigoTabla);
            xIns.AsignarParametro(ItemGEN.CodIteG, pObj.CodigoItemG);
            xIns.AsignarParametro(ItemGEN.NomIteG, pObj.NombreItemG);
            xIns.AsignarParametro(ItemGEN.AbrIteG, pObj.AbreviaItemG);
            xIns.AsignarParametro(ItemGEN.CEstIteG, pObj.CEstadoItemG);
            xIns.AsignarParametro(ItemGEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ItemGEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(ItemGEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(ItemGEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarItemG(ItemGEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(ItemGEN.NomIteG, pObj.NombreItemG);
            xUpd.AsignarParametro(ItemGEN.AbrIteG, pObj.AbreviaItemG);
            xUpd.AsignarParametro(ItemGEN.CEstIteG, pObj.CEstadoItemG);
            xUpd.AsignarParametro(ItemGEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ItemGEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.ClaIteG, SqlSelect.Operador.Igual, pObj.ClaveItemG);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarItemG(ItemGEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.ClaIteG, SqlSelect.Operador.Igual, pObj.ClaveItemG);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<ItemGEN> ListarItemsGXTabla(ItemGEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemGEN> ListarItemsGActivosXTabla(ItemGEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CEstIteG, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemGEN> ListarItemsGActivosXTablaYClase(ItemGEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CEstIteG, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionLike(SqlSelect.Reservada.Y, ItemGEN.CodIteG, pObj.CodigoItemG);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public ItemGEN BuscarItemGXClave(ItemGEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.ClaIteG, SqlSelect.Operador.Igual, pObj.ClaveItemG);

            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<ItemGEN> ListarItemsGActivosXTablaYFiltroCodigo(ItemGEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CEstIteG, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionLike(SqlSelect.Reservada.Y, ItemGEN.CodIteG, pObj.CodigoItemG);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemGEN> ListarEstadosProformaParaSeparar()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, "EsProf");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CEstIteG, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionIN(SqlSelect.Reservada.Y, ItemGEN.CodIteG, "0,1");
            xSel.Ordenar(ItemGEN.CodIteG, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemGEN> ListarEstadosProformaParaVender()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, "EsProf");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CEstIteG, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionIN(SqlSelect.Reservada.Y, ItemGEN.CodIteG, "1,2");
            xSel.Ordenar(ItemGEN.CodIteG, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemGEN> ListarItemsSoloNotas()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, "Cdp");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CEstIteG, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionIN(SqlSelect.Reservada.Y, ItemGEN.CodIteG, "07,08"); //ACTIVOS
            xSel.Ordenar(ItemGEN.CodIteG, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemGEN> ListarItemsMonedaPagoSinAmbos()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, "MonPag");
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CEstIteG, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CodIteG, SqlSelect.Operador.Diferente, "2");
            xSel.Ordenar(ItemGEN.CodIteG, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<ItemGEN> ListarItemsGActivosXFiltroClaseYSubClase(ItemGEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            //xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, "GruExi");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, ItemGEN.CodTab, SqlSelect.Operador.Igual, pObj.CodigoTabla);
            xSel.CondicionCV(SqlSelect.Reservada.Y, ItemGEN.CEstIteG, SqlSelect.Operador.Igual, "1"); //ACTIVOS
            xSel.CondicionLike(SqlSelect.Reservada.Y, ItemGEN.CodIteG, pObj.CodigoItemG);
            xSel.Ordenar(ItemGEN.CodIteG, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


    }
}
