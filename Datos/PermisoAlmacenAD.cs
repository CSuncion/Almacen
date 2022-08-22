using System;
using System.Collections.Generic;
using System.Data;
using ScriptBD;
using Entidades.Adicionales;
using Datos.Config;
using Comun;
using Entidades;

namespace Datos
{

    public class PermisoAlmacenAD
    {

        #region Atributos

        private SqlDatos eObjCon = new SqlDatos();
        private List<PermisoAlmacenEN> eLista = new List<PermisoAlmacenEN>();
        private PermisoAlmacenEN eObj = new PermisoAlmacenEN();
        private string eTabla = "PermisoAlmacen";
        private string eVista = "VsPermisoAlmacen";

        #endregion

        #region Metodos privados

        private PermisoAlmacenEN Objeto(IDataReader iDr)
        {
            PermisoAlmacenEN xObjEnc = new PermisoAlmacenEN();
            xObjEnc.ClavePermisoAlmacen = iDr[PermisoAlmacenEN.ClaPerAlm].ToString();
            xObjEnc.CodigoEmpresa = iDr[PermisoAlmacenEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[PermisoAlmacenEN.NomEmp].ToString();           
            xObjEnc.CodigoAlmacen = iDr[PermisoAlmacenEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[PermisoAlmacenEN.DesAlm].ToString();
            xObjEnc.CEstadoAlmacen = iDr[PermisoAlmacenEN.CEstAlm].ToString();
            xObjEnc.CodigoUsuario = iDr[PermisoAlmacenEN.CodUsu].ToString();
            xObjEnc.NombreUsuario = iDr[PermisoAlmacenEN.NomUsu].ToString();
            xObjEnc.CodigoPerfil = iDr[PermisoAlmacenEN.CodPer].ToString();
            xObjEnc.CPermitir = iDr[PermisoAlmacenEN.CPer].ToString();
            xObjEnc.VerdadFalso = Conversion.CadenaABoolean(xObjEnc.CPermitir, false);
            xObjEnc.UsuarioAgrega = iDr[PermisoAlmacenEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[PermisoAlmacenEN.FecAgr].ToString());
            xObjEnc.UsuarioModifica = iDr[PermisoAlmacenEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[PermisoAlmacenEN.FecMod].ToString());
            xObjEnc.ClaveObjeto = xObjEnc.ClavePermisoAlmacen;
            return xObjEnc;
        }

        private List<PermisoAlmacenEN> ListarObjetos(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.eLista.Add(this.Objeto(xIdr));
            }
            eObjCon.Desconectar();
            return eLista;
        }

        private PermisoAlmacenEN BuscarObjeto(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.eObj = this.Objeto(xIdr);
            }
            eObjCon.Desconectar();
            return eObj;
        }

        private bool ExisteObjeto(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            eObjCon.ComandoTexto(pScript);
            IDataReader xIdr = eObjCon.ObtenerIdr();
            bool xResultado = false;
            while (xIdr.Read())
            {
                string xTxt = xIdr["Busqueda"].ToString();
                if (xTxt != string.Empty)
                {
                    xResultado = true;
                }
            }
            eObjCon.Desconectar();
            return xResultado;
        }

        private string ObtenerValor(string pScript)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            eObjCon.ComandoTexto(pScript);
            string iValor = eObjCon.ObtenerValor();
            eObjCon.Desconectar();
            return iValor;
        }

        #endregion

        #region Metodos publicos

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumna(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.eTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion2, SqlSelect.Operador.Igual, pValorCondicion2);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1, string pColumnaCondicion2, string pValorCondicion2)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.eVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion2, SqlSelect.Operador.Igual, pValorCondicion2);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AdicionarPermisoAlmacen(List<PermisoAlmacenEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (PermisoAlmacenEN xObj in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.eTabla);
                xIns.AsignarParametro(PermisoAlmacenEN.ClaPerAlm, xObj.ClavePermisoAlmacen);
                xIns.AsignarParametro(PermisoAlmacenEN.CodEmp, xObj.CodigoEmpresa);                
                xIns.AsignarParametro(PermisoAlmacenEN.CodAlm, xObj.CodigoAlmacen);
                xIns.AsignarParametro(PermisoAlmacenEN.CodUsu, xObj.CodigoUsuario);
                xIns.AsignarParametro(PermisoAlmacenEN.CPer, xObj.CPermitir);
                xIns.AsignarParametro(PermisoAlmacenEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(PermisoAlmacenEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(PermisoAlmacenEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(PermisoAlmacenEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                eObjCon.ComandoTexto(xIns.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void ModificarPermisoAlmacen(List<PermisoAlmacenEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (PermisoAlmacenEN xObj in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.eTabla);
                xUpd.AsignarParametro(PermisoAlmacenEN.ClaPerAlm, xObj.ClavePermisoAlmacen);
                xUpd.AsignarParametro(PermisoAlmacenEN.CodEmp, xObj.CodigoEmpresa);               
                xUpd.AsignarParametro(PermisoAlmacenEN.CodAlm, xObj.CodigoAlmacen);
                xUpd.AsignarParametro(PermisoAlmacenEN.CodUsu, xObj.CodigoUsuario);
                xUpd.AsignarParametro(PermisoAlmacenEN.CPer, xObj.CPermitir);
                xUpd.AsignarParametro(PermisoAlmacenEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(PermisoAlmacenEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoAlmacenEN.ClaPerAlm, SqlSelect.Operador.Igual, xObj.ClavePermisoAlmacen);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xUpd.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarPermisoAlmacen(List<PermisoAlmacenEN> pLista)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (PermisoAlmacenEN xObj in pLista)
            {
                //armando escript para insertar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.eTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoAlmacenEN.ClaPerAlm, SqlSelect.Operador.Igual, xObj.ClavePermisoAlmacen);
                xDel.CondicionDelete(xSel.ObtenerScript());

                eObjCon.ComandoTexto(xDel.ObtenerScript());
                eObjCon.EjecutarSinResultado();
            }
            eObjCon.Desconectar();
        }

        public void EliminarPermisoAlmacenXUsuario(string pCodigoUsuario)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para insertar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.eTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoAlmacenEN.CodUsu, SqlSelect.Operador.Igual, pCodigoUsuario);
            xDel.CondicionDelete(xSel.ObtenerScript());

            eObjCon.ComandoTexto(xDel.ObtenerScript());
            eObjCon.EjecutarSinResultado();
            eObjCon.Desconectar();
        }

        public void EliminarPermisoAlmacenXAlmacen(string pCodigoAlmacen)
        {
            eObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para insertar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.eTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoAlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoAlmacenEN.CodAlm, SqlSelect.Operador.Igual, pCodigoAlmacen);
            xDel.CondicionDelete(xSel.ObtenerScript());
           
            eObjCon.ComandoTexto(xDel.ObtenerScript());
            eObjCon.EjecutarSinResultado();
            eObjCon.Desconectar();
        }

        public List<PermisoAlmacenEN> ListarPermisoAlmacen(PermisoAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoAlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PermisoAlmacenEN BuscarPermisoAlmacenXClave(PermisoAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoAlmacenEN.ClaPerAlm, SqlSelect.Operador.Igual, pObj.ClavePermisoAlmacen);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<PermisoAlmacenEN> ListarPermisosAlmacenAbiertasXUsuario(PermisoAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoAlmacenEN.CEstAlm, SqlSelect.Operador.Igual, "1"); //abierta
            xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoAlmacenEN.CodUsu, SqlSelect.Operador.Igual, pObj.CodigoUsuario);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PermisoAlmacenEN> ListarPermisosAlmacenAbiertasAutorizadasXUsuario(PermisoAlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.eVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoAlmacenEN.CEstAlm, SqlSelect.Operador.Igual, "1"); //abierta
            xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoAlmacenEN.CodUsu, SqlSelect.Operador.Igual, pObj.CodigoUsuario);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoAlmacenEN.CPer, SqlSelect.Operador.Igual, "1");//si
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
