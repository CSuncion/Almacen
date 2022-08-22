using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Datos.Config;
using Entidades.Adicionales;

namespace Datos
{
    public class PeriodoAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<PeriodoEN> xLista = new List<PeriodoEN>();
        private PeriodoEN xObj = new PeriodoEN();
        private string xTabla = "Periodo";
        private string xVista = "VsPeriodo";

        #endregion
      
        #region Metodos privados

        private PeriodoEN Objeto(IDataReader iDr)
        {
            PeriodoEN xObjEnc = new PeriodoEN();
            xObjEnc.ClavePeriodo = iDr[PeriodoEN.ClaPer].ToString();
            xObjEnc.CodigoPeriodo = iDr[PeriodoEN.CodPer].ToString();
            xObjEnc.CodigoEmpresa = iDr[PeriodoEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[PeriodoEN.NomEmp].ToString();
            xObjEnc.AnoPeriodo = iDr[PeriodoEN.AnoPer].ToString();
            xObjEnc.CMesPeriodo = iDr[PeriodoEN.CMesPer].ToString();
            xObjEnc.NMesPeriodo = iDr[PeriodoEN.NMesPer].ToString();
            xObjEnc.TipoCambioPeriodo = Convert.ToDecimal(iDr[PeriodoEN.TipCamPer].ToString());
            xObjEnc.CEstadoPeriodo = iDr[PeriodoEN.CEstPer].ToString();
            xObjEnc.NEstadoPeriodo = iDr[PeriodoEN.NEstPer].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClavePeriodo;
            return xObjEnc;
        }

        private List<PeriodoEN> ListarObjetos(string pScript)
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

        private PeriodoEN BuscarObjeto(string pScript)
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


        #endregion


        public bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarPeriodo(PeriodoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PeriodoEN.ClaPer, pObj.ClavePeriodo);
            xIns.AsignarParametro(PeriodoEN.CodPer, pObj.CodigoPeriodo);
            xIns.AsignarParametro(PeriodoEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(PeriodoEN.AnoPer, pObj.AnoPeriodo);
            xIns.AsignarParametro(PeriodoEN.CMesPer, pObj.CMesPeriodo);
            xIns.AsignarParametro(PeriodoEN.TipCamPer, pObj.TipoCambioPeriodo.ToString());
            xIns.AsignarParametro(PeriodoEN.CEstPer, pObj.CEstadoPeriodo);
            xIns.AsignarParametro(PeriodoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PeriodoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(PeriodoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PeriodoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPeriodo(PeriodoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PeriodoEN.TipCamPer, pObj.TipoCambioPeriodo.ToString());
            xUpd.AsignarParametro(PeriodoEN.CEstPer, pObj.CEstadoPeriodo);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PeriodoEN.ClaPer, SqlSelect.Operador.Igual, pObj.ClavePeriodo);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarEstadoPeriodoDeAño(PeriodoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PeriodoEN.CEstPer, pObj.CEstadoPeriodo);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PeriodoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PeriodoEN.AnoPer, SqlSelect.Operador.Igual, pObj.AnoPeriodo);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPeriodo(PeriodoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PeriodoEN.ClaPer, SqlSelect.Operador.Igual, pObj.ClavePeriodo);
            xDel.CondicionDelete(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<PeriodoEN> ListarPeriodos(PeriodoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PeriodoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PeriodoEN BuscarPeriodoXClave(PeriodoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PeriodoEN.ClaPer, SqlSelect.Operador.Igual, pObj.ClavePeriodo);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<PeriodoEN> ListarPeriodosXEstado(PeriodoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PeriodoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PeriodoEN.CEstPer, SqlSelect.Operador.Igual, pObj.CEstadoPeriodo);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PeriodoEN> ListarPeriodosXAñoYEstado(PeriodoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PeriodoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PeriodoEN.AnoPer, SqlSelect.Operador.Igual, pObj.AnoPeriodo);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PeriodoEN.CEstPer, SqlSelect.Operador.Igual, pObj.CEstadoPeriodo);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
    }
}
