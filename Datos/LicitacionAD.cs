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

    public class LicitacionAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<LicitacionEN> xLista = new List<LicitacionEN>();
        private LicitacionEN xObj = new LicitacionEN();
        private string xTabla = "Licitacion";
        private string xVista = "VsLicitacion";

        #endregion
        
        #region Metodos privados

        private LicitacionEN Objeto(IDataReader iDr)
        {
            LicitacionEN xObjEnc = new LicitacionEN();
            xObjEnc.ClaveLicitacion = iDr[LicitacionEN.ClaLic].ToString();
            xObjEnc.CodigoEmpresa = iDr[LicitacionEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[LicitacionEN.NomEmp].ToString();           
            xObjEnc.CodigoAuxiliar = iDr[LicitacionEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[LicitacionEN.DesAux].ToString();
            xObjEnc.CodigoLicitacion = iDr[LicitacionEN.CodLic].ToString();
            xObjEnc.DescripcionLicitacion = iDr[LicitacionEN.DesLic].ToString();
            xObjEnc.FechaLicitacion = iDr[LicitacionEN.FecLic].ToString();
            xObjEnc.PeriodoLicitacion = iDr[LicitacionEN.PerLic].ToString();
            xObjEnc.CEstadoLicitacion = iDr[LicitacionEN.CEstLic].ToString();
            xObjEnc.NEstadoLicitacion = iDr[LicitacionEN.NEstLic].ToString();
            xObjEnc.UsuarioAgrega = iDr[LicitacionEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[LicitacionEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[LicitacionEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[LicitacionEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveLicitacion;
            return xObjEnc;
        }
        
        private List<LicitacionEN> ListarObjetos(string pScript)
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
        
        private LicitacionEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LicitacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LicitacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }
        
        public void AgregarLicitacion(LicitacionEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(LicitacionEN.ClaLic, pObj.ClaveLicitacion);
            xIns.AsignarParametro(LicitacionEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(LicitacionEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(LicitacionEN.CodLic, pObj.CodigoLicitacion);
            xIns.AsignarParametro(LicitacionEN.DesLic, pObj.DescripcionLicitacion);
            xIns.AsignarParametro(LicitacionEN.FecLic, Fecha.ObtenerAnoMesDia(pObj.FechaLicitacion));
            xIns.AsignarParametro(LicitacionEN.PerLic, pObj.PeriodoLicitacion);
            xIns.AsignarParametro(LicitacionEN.CEstLic, pObj.CEstadoLicitacion);
            xIns.AsignarParametro(LicitacionEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(LicitacionEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(LicitacionEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(LicitacionEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarLicitacion(LicitacionEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(LicitacionEN.DesLic, pObj.DescripcionLicitacion);
            xUpd.AsignarParametro(LicitacionEN.FecLic, Fecha.ObtenerAnoMesDia(pObj.FechaLicitacion));
            xUpd.AsignarParametro(LicitacionEN.PerLic, pObj.PeriodoLicitacion);
            xUpd.AsignarParametro(LicitacionEN.CEstLic, pObj.CEstadoLicitacion);
            xUpd.AsignarParametro(LicitacionEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(LicitacionEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LicitacionEN.ClaLic, SqlSelect.Operador.Igual, pObj.ClaveLicitacion);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarLicitacion(LicitacionEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LicitacionEN.ClaLic, SqlSelect.Operador.Igual, pObj.ClaveLicitacion);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<LicitacionEN> ListarLicitaciones(LicitacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LicitacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public LicitacionEN BuscarLicitacionXClave(LicitacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LicitacionEN.ClaLic, SqlSelect.Operador.Igual, pObj.ClaveLicitacion);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<LicitacionEN> ListarLicitacionesXEstado(LicitacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LicitacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (pObj.CEstadoLicitacion != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, LicitacionEN.CEstLic, SqlSelect.Operador.Igual, pObj.CEstadoLicitacion);
            }            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<LicitacionEN> ListarLicitacionesActivasDeCliente(LicitacionEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, LicitacionEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LicitacionEN.CodAux, SqlSelect.Operador.Igual, pObj.CodigoAuxiliar);
            xSel.CondicionCV(SqlSelect.Reservada.Y, LicitacionEN.CEstLic, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
