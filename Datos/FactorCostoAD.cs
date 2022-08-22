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
    public class FactorCostoAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<FactorCostoEN> xLista = new List<FactorCostoEN>();
        private FactorCostoEN xObj = new FactorCostoEN();
        private string xTabla = "FactorCosto";
        private string xVista = "VsFactorCosto";

        #endregion
      
        #region Metodos privados

        private FactorCostoEN Objeto(IDataReader iDr)
        {
            FactorCostoEN xObjEnc = new FactorCostoEN();
            xObjEnc.ClaveFactorCosto = iDr[FactorCostoEN.ClaFacCos].ToString();
            xObjEnc.CodigoFactorCosto = iDr[FactorCostoEN.CodFacCos].ToString();
            xObjEnc.CodigoEmpresa = iDr[FactorCostoEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[FactorCostoEN.NomEmp].ToString();
            xObjEnc.AnoFactorCosto = iDr[FactorCostoEN.AnoFacCos].ToString();
            xObjEnc.CMesFactorCosto = iDr[FactorCostoEN.CMesFacCos].ToString();
            xObjEnc.NMesFactorCosto = iDr[FactorCostoEN.NMesFacCos].ToString();
            xObjEnc.HorasLaboradas = Convert.ToDecimal(iDr[FactorCostoEN.HosLab].ToString());
            xObjEnc.NumeroDias = Convert.ToDecimal(iDr[FactorCostoEN.NumDia].ToString());
            xObjEnc.CostoLaboral = Convert.ToDecimal(iDr[FactorCostoEN.CosLab].ToString());
            xObjEnc.Factor = Convert.ToDecimal(iDr[FactorCostoEN.Fac].ToString());
            xObjEnc.CEstadoFactorCosto = iDr[FactorCostoEN.CEstFacCos].ToString();
            xObjEnc.NEstadoFactorCosto = iDr[FactorCostoEN.NEstFacCos].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveFactorCosto;
            return xObjEnc;
        }

        private List<FactorCostoEN> ListarObjetos(string pScript)
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

        private FactorCostoEN BuscarObjeto(string pScript)
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

        public void AgregarFactorCosto(FactorCostoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(FactorCostoEN.ClaFacCos, pObj.ClaveFactorCosto);
            xIns.AsignarParametro(FactorCostoEN.CodFacCos, pObj.CodigoFactorCosto);
            xIns.AsignarParametro(FactorCostoEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(FactorCostoEN.AnoFacCos, pObj.AnoFactorCosto);
            xIns.AsignarParametro(FactorCostoEN.CMesFacCos, pObj.CMesFactorCosto);
            xIns.AsignarParametro(FactorCostoEN.HosLab, pObj.HorasLaboradas.ToString());
            xIns.AsignarParametro(FactorCostoEN.NumDia, pObj.NumeroDias.ToString());
            xIns.AsignarParametro(FactorCostoEN.CosLab, pObj.CostoLaboral.ToString());
            xIns.AsignarParametro(FactorCostoEN.Fac, pObj.Factor.ToString());
            xIns.AsignarParametro(FactorCostoEN.CEstFacCos, pObj.CEstadoFactorCosto);
            xIns.AsignarParametro(FactorCostoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(FactorCostoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(FactorCostoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(FactorCostoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarFactorCosto(FactorCostoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(FactorCostoEN.CEstFacCos, pObj.CEstadoFactorCosto);
            xUpd.AsignarParametro(FactorCostoEN.HosLab, pObj.HorasLaboradas.ToString());
            xUpd.AsignarParametro(FactorCostoEN.NumDia, pObj.NumeroDias.ToString());
            xUpd.AsignarParametro(FactorCostoEN.CosLab, pObj.CostoLaboral.ToString());
            xUpd.AsignarParametro(FactorCostoEN.Fac, pObj.Factor.ToString());
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCostoEN.ClaFacCos, SqlSelect.Operador.Igual, pObj.ClaveFactorCosto);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarEstadoFactorCostoDeAño(FactorCostoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(FactorCostoEN.CEstFacCos, pObj.CEstadoFactorCosto);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCostoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FactorCostoEN.AnoFacCos, SqlSelect.Operador.Igual, pObj.AnoFactorCosto);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarFactorCosto(FactorCostoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCostoEN.ClaFacCos, SqlSelect.Operador.Igual, pObj.ClaveFactorCosto);
            xDel.CondicionDelete(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<FactorCostoEN> ListarFactorCostos(FactorCostoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCostoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public FactorCostoEN BuscarFactorCostoXClave(FactorCostoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCostoEN.ClaFacCos, SqlSelect.Operador.Igual, pObj.ClaveFactorCosto);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<FactorCostoEN> ListarFactorCostosXEstado(FactorCostoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCostoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FactorCostoEN.CEstFacCos, SqlSelect.Operador.Igual, pObj.CEstadoFactorCosto);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FactorCostoEN> ListarFactorCostosXAñoYEstado(FactorCostoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCostoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FactorCostoEN.AnoFacCos, SqlSelect.Operador.Igual, pObj.AnoFactorCosto);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FactorCostoEN.CEstFacCos, SqlSelect.Operador.Igual, pObj.CEstadoFactorCosto);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
    }
}
