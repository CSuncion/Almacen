using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Comun;
using Datos.Config;

namespace Datos
{

    public class PermisoPerfilAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<PermisoPerfilEN> xLista = new List<PermisoPerfilEN>();
        private PermisoPerfilEN xObj = new PermisoPerfilEN();
        private string xTabla = "PermisoPerfil";
        private string xVista = "VsPermisoPerfil";


        #region Metodos privados

        private PermisoPerfilEN Objeto(IDataReader iDr)
        {
            PermisoPerfilEN xObjEnc = new PermisoPerfilEN();
            xObjEnc.ClavePermisoPerfil = iDr[PermisoPerfilEN.ClaPerPer].ToString();

            xObjEnc.CodigoVentana = iDr[PermisoPerfilEN.CodVen].ToString();
            xObjEnc.NombreVentana = iDr[PermisoPerfilEN.NomVen].ToString();
            xObjEnc.NombreControlVentana = iDr[PermisoPerfilEN.NomConVen].ToString();
            xObjEnc.CodigoBoton = iDr[PermisoPerfilEN.CodBot].ToString();
            xObjEnc.NombreBoton = iDr[PermisoPerfilEN.NomBot].ToString();
            xObjEnc.NombreControl = iDr[PermisoPerfilEN.NomCon].ToString();
            xObjEnc.CValidaGrilla = iDr[PermisoPerfilEN.CValGri].ToString();
            xObjEnc.CodigoPerfil = iDr[PermisoPerfilEN.CodPer].ToString();
            xObjEnc.NombrePerfil = iDr[PermisoPerfilEN.NomPer].ToString();
            xObjEnc.CPermitir = iDr[PermisoPerfilEN.CPer].ToString();
            xObjEnc.VerdadFalso = Conversion.CadenaABoolean(xObjEnc.CPermitir, false);
            xObjEnc.ClaveObjeto = xObjEnc.ClavePermisoPerfil;
            return xObjEnc;
        }

        private List<PermisoPerfilEN> ListarObjetos(string pScript)
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

        private PermisoPerfilEN BuscarObjeto(string pScript)
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

        public void AgregarPermisoPerfil(PermisoPerfilEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PermisoPerfilEN.ClaPerPer, pObj.ClavePermisoPerfil);
            xIns.AsignarParametro(PermisoPerfilEN.CodVen, pObj.CodigoVentana);
            xIns.AsignarParametro(PermisoPerfilEN.CodBot, pObj.CodigoBoton);
            xIns.AsignarParametro(PermisoPerfilEN.CodPer, pObj.CodigoPerfil);
            xIns.AsignarParametro(PermisoPerfilEN.CPer, pObj.CPermitir);
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarPermisoPerfilMasivo(List<PermisoPerfilEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (PermisoPerfilEN xPerPer in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(PermisoPerfilEN.ClaPerPer, xPerPer.ClavePermisoPerfil);
                xIns.AsignarParametro(PermisoPerfilEN.CodVen, xPerPer.CodigoVentana);
                xIns.AsignarParametro(PermisoPerfilEN.CodBot, xPerPer.CodigoBoton);
                xIns.AsignarParametro(PermisoPerfilEN.CodPer, xPerPer.CodigoPerfil);
                xIns.AsignarParametro(PermisoPerfilEN.CPer, xPerPer.CPermitir);
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            xObjCon.Desconectar();
        }

        public void ModificarPermisoPerfil(PermisoPerfilEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PermisoPerfilEN.CPer, pObj.CPermitir);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.ClaPerPer, SqlSelect.Operador.Igual, pObj.ClavePermisoPerfil);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPermisoPerfilMasivo(List<PermisoPerfilEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (PermisoPerfilEN xPerPer in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(PermisoPerfilEN.CPer, xPerPer.CPermitir);
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.ClaPerPer, SqlSelect.Operador.Igual, xPerPer.ClavePermisoPerfil);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            xObjCon.Desconectar();
        }

        public void EliminarPermisoPerfil(PermisoPerfilEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.ClaPerPer, SqlSelect.Operador.Igual, pObj.ClavePermisoPerfil);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPermisosPerfilXVentanaBoton(List<VentanaBotonEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (VentanaBotonEN xVenBot in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.CodVen, SqlSelect.Operador.Igual, xVenBot.CodigoVentana);
                xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoPerfilEN.CodBot, SqlSelect.Operador.Igual, xVenBot.CodigoBoton);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public List<PermisoPerfilEN> ListarPermisoPerfil(PermisoPerfilEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PermisoPerfilEN BuscarPermisoPerfilXClave(PermisoPerfilEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.ClaPerPer, SqlSelect.Operador.Igual, pObj.ClavePermisoPerfil);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public void EliminarPermisosPerfilDePerfil(PermisoPerfilEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.CodPer, SqlSelect.Operador.Igual, pObj.CodigoPerfil);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPermisosPerfilXVentana(PermisoPerfilEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();           
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<PermisoPerfilEN> ListarPermisosPerfilDeVentana(PermisoPerfilEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoPerfilEN.CodPer, SqlSelect.Operador.Igual, pObj.CodigoPerfil);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PermisoPerfilEN> ListarPermisosPerfilDePerfil(PermisoPerfilEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoPerfilEN.CodPer, SqlSelect.Operador.Igual, pObj.CodigoPerfil);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
    }
}
