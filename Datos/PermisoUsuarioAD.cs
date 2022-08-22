using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Comun;
using Datos;
using Entidades;
using Datos.Config;

namespace Datos
{
    public class PermisoUsuarioAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<PermisoUsuarioEN> xLista = new List<PermisoUsuarioEN>();
        private PermisoUsuarioEN xObj = new PermisoUsuarioEN();
        private string xTabla = "PermisoUsuario";
        private string xVista = "VsPermisoUsuario";


        #region Metodos privados

        private PermisoUsuarioEN Objeto(IDataReader iDr)
        {
            PermisoUsuarioEN xObjEnc = new PermisoUsuarioEN();
            xObjEnc.ClavePermisoUsuario = iDr[PermisoUsuarioEN.ClaPerUsu].ToString();          
            xObjEnc.CodigoVentana = iDr[PermisoUsuarioEN.CodVen].ToString();
            xObjEnc.NombreVentana = iDr[PermisoUsuarioEN.NomVen].ToString();
            xObjEnc.NombreControlVentana = iDr[PermisoUsuarioEN.NomConVen].ToString();
            xObjEnc.CodigoBoton = iDr[PermisoUsuarioEN.CodBot].ToString();
            xObjEnc.NombreBoton = iDr[PermisoUsuarioEN.NomBot].ToString();
            xObjEnc.NombreControl = iDr[PermisoUsuarioEN.NomCon].ToString();
            xObjEnc.CValidaGrilla = iDr[PermisoUsuarioEN.CValGri].ToString();
            xObjEnc.CodigoUsuario = iDr[PermisoUsuarioEN.CodUsu].ToString();
            xObjEnc.NombreUsuario = iDr[PermisoUsuarioEN.NomUsu].ToString();
            xObjEnc.CPermitir = iDr[PermisoUsuarioEN.CPer].ToString();
            xObjEnc.VerdadFalso = Conversion.CadenaABoolean(xObjEnc.CPermitir, false);
            xObjEnc.ClaveObjeto = xObjEnc.ClavePermisoUsuario;
            return xObjEnc;
        }
        
        private List<PermisoUsuarioEN> ListarObjetos(string pScript)
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
        
        private PermisoUsuarioEN BuscarObjeto(string pScript)
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
        
        public void AgregarPermisoUsuario(PermisoUsuarioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PermisoUsuarioEN.ClaPerUsu, pObj.ClavePermisoUsuario);           
            xIns.AsignarParametro(PermisoUsuarioEN.CodVen, pObj.CodigoVentana);
            xIns.AsignarParametro(PermisoUsuarioEN.CodBot, pObj.CodigoBoton);
            xIns.AsignarParametro(PermisoUsuarioEN.CodUsu, pObj.CodigoUsuario);
            xIns.AsignarParametro(PermisoUsuarioEN.CPer, pObj.CPermitir);            
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarPermisoUsuarioMasivo(List<PermisoUsuarioEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (PermisoUsuarioEN xPerUsu in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(PermisoUsuarioEN.ClaPerUsu, xPerUsu.ClavePermisoUsuario);               
                xIns.AsignarParametro(PermisoUsuarioEN.CodVen, xPerUsu.CodigoVentana);
                xIns.AsignarParametro(PermisoUsuarioEN.CodBot, xPerUsu.CodigoBoton);
                xIns.AsignarParametro(PermisoUsuarioEN.CodUsu, xPerUsu.CodigoUsuario);
                xIns.AsignarParametro(PermisoUsuarioEN.CPer, xPerUsu.CPermitir);
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();    
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarPermisoUsuario(PermisoUsuarioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PermisoUsuarioEN.CPer, pObj.CPermitir);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.ClaPerUsu, SqlSelect.Operador.Igual, pObj.ClavePermisoUsuario);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPermisoUsuarioMasivo(List<PermisoUsuarioEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (PermisoUsuarioEN xPerUsu in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(PermisoUsuarioEN.CPer, xPerUsu.CPermitir);
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.ClaPerUsu, SqlSelect.Operador.Igual, xPerUsu.ClavePermisoUsuario);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();    
            }            
            xObjCon.Desconectar();
        }

        public void EliminarPermisoUsuario(PermisoUsuarioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.ClaPerUsu, SqlSelect.Operador.Igual, pObj.ClavePermisoUsuario);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPermisosUsuarioDeUsuario(PermisoUsuarioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.CodUsu, SqlSelect.Operador.Igual, pObj.CodigoUsuario);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPermisosUsuarioXVentanaBoton(List<VentanaBotonEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (VentanaBotonEN xVenBot in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();               
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.CodVen, SqlSelect.Operador.Igual, xVenBot.CodigoVentana);
                xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoUsuarioEN.CodBot, SqlSelect.Operador.Igual, xVenBot.CodigoBoton);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();    
            }
            
            xObjCon.Desconectar();
        }

        public void EliminarPermisosUsuarioXVentana(PermisoUsuarioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();           
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<PermisoUsuarioEN> ListarPermisoUsuario(PermisoUsuarioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PermisoUsuarioEN> ListarPermisosUsuarioDeVentana(PermisoUsuarioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoUsuarioEN.CodUsu, SqlSelect.Operador.Igual, pObj.CodigoUsuario);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PermisoUsuarioEN BuscarPermisoUsuarioXClave(PermisoUsuarioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.ClaPerUsu, SqlSelect.Operador.Igual, pObj.ClavePermisoUsuario);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<PermisoUsuarioEN> ListarPermisosUsuarioDeUsuario(PermisoUsuarioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoUsuarioEN.CodUsu, SqlSelect.Operador.Igual, pObj.CodigoUsuario);            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

    }
}
