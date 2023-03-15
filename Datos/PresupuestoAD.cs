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
    public class PresupuestoAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<PresupuestoEN> xLista = new List<PresupuestoEN>();
        private PresupuestoEN xObj = new PresupuestoEN();
        private string xTabla = "Presupuesto";
        private string xVista = "VsPresupuesto";

        #endregion

        #region Metodos privados

        private PresupuestoEN Objeto(IDataReader iDr)
        {
            PresupuestoEN xObjEnc = new PresupuestoEN();
            xObjEnc.ClavePresupuesto = iDr[PresupuestoEN.ClaPre].ToString();
            xObjEnc.CodigoPresupuesto = iDr[PresupuestoEN.CodPre].ToString();
            xObjEnc.CodigoEmpresa = iDr[PresupuestoEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[PresupuestoEN.NomEmp].ToString();
            xObjEnc.AnoPresupuesto = iDr[PresupuestoEN.AnoPre].ToString();
            xObjEnc.CMesPresupuesto = iDr[PresupuestoEN.CMesPre].ToString();
            xObjEnc.NMesPresupuesto = iDr[PresupuestoEN.NMesPre].ToString();
            xObjEnc.CCentroCosto = iDr[PresupuestoEN.CCenCto].ToString();
            xObjEnc.NCentroCosto = iDr[PresupuestoEN.NCenCto].ToString();
            xObjEnc.ImportePresupuesto = Convert.ToDecimal(iDr[PresupuestoEN.ImpPre].ToString());
            xObjEnc.ImporteAdicionalPresupuesto = Convert.ToDecimal(iDr[PresupuestoEN.ImpAdiPre].ToString());
            xObjEnc.SaldoPresupuesto = Convert.ToDecimal(iDr[PresupuestoEN.SalPre].ToString());
            xObjEnc.SaldoPresupuestoTemporal = Convert.ToDecimal(iDr[PresupuestoEN.SalPreTem].ToString());
            xObjEnc.CEstadoPresupuesto = iDr[PresupuestoEN.CEstPre].ToString();
            xObjEnc.NEstadoPresupuesto = iDr[PresupuestoEN.NEstPre].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClavePresupuesto;
            return xObjEnc;
        }

        private List<PresupuestoEN> ListarObjetos(string pScript)
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

        private PresupuestoEN BuscarObjeto(string pScript)
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

        public void AgregarPresupuesto(PresupuestoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PresupuestoEN.ClaPre, pObj.ClavePresupuesto);
            xIns.AsignarParametro(PresupuestoEN.CodPre, pObj.CodigoPresupuesto);
            xIns.AsignarParametro(PresupuestoEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(PresupuestoEN.AnoPre, pObj.AnoPresupuesto);
            xIns.AsignarParametro(PresupuestoEN.CMesPre, pObj.CMesPresupuesto);
            xIns.AsignarParametro(PresupuestoEN.CCenCto, pObj.CCentroCosto);
            xIns.AsignarParametro(PresupuestoEN.ImpPre, pObj.ImportePresupuesto.ToString());
            xIns.AsignarParametro(PresupuestoEN.ImpAdiPre, pObj.ImporteAdicionalPresupuesto.ToString());
            xIns.AsignarParametro(PresupuestoEN.SalPre, pObj.SaldoPresupuesto.ToString());
            xIns.AsignarParametro(PresupuestoEN.SalPreTem, pObj.SaldoPresupuestoTemporal.ToString());
            xIns.AsignarParametro(PresupuestoEN.CEstPre, pObj.CEstadoPresupuesto);
            xIns.AsignarParametro(PresupuestoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PresupuestoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(PresupuestoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PresupuestoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPresupuesto(PresupuestoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PresupuestoEN.ImpPre, pObj.ImportePresupuesto.ToString());
            xUpd.AsignarParametro(PresupuestoEN.ImpAdiPre, pObj.ImporteAdicionalPresupuesto.ToString());
            xUpd.AsignarParametro(PresupuestoEN.SalPre, pObj.SaldoPresupuesto.ToString());
            xUpd.AsignarParametro(PresupuestoEN.SalPreTem, pObj.SaldoPresupuestoTemporal.ToString());
            xUpd.AsignarParametro(PresupuestoEN.CEstPre, pObj.CEstadoPresupuesto);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PresupuestoEN.ClaPre, SqlSelect.Operador.Igual, pObj.ClavePresupuesto);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarEstadoPresupuestoDeAño(PresupuestoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PresupuestoEN.CEstPre, pObj.CEstadoPresupuesto);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PresupuestoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PresupuestoEN.AnoPre, SqlSelect.Operador.Igual, pObj.AnoPresupuesto);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPresupuesto(PresupuestoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PresupuestoEN.ClaPre, SqlSelect.Operador.Igual, pObj.ClavePresupuesto);
            xDel.CondicionDelete(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<PresupuestoEN> ListarPresupuestos(PresupuestoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PresupuestoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PresupuestoEN BuscarPresupuestoXClave(PresupuestoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PresupuestoEN.ClaPre, SqlSelect.Operador.Igual, pObj.ClavePresupuesto);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<PresupuestoEN> ListarPresupuestosXEstado(PresupuestoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PresupuestoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PresupuestoEN.CEstPre, SqlSelect.Operador.Igual, pObj.CEstadoPresupuesto);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PresupuestoEN> ListarPresupuestosXAñoYEstado(PresupuestoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PresupuestoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PresupuestoEN.AnoPre, SqlSelect.Operador.Igual, pObj.AnoPresupuesto);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PresupuestoEN.CEstPre, SqlSelect.Operador.Igual, pObj.CEstadoPresupuesto);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public void ModificarPresupuestoTemporal(PresupuestoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update Presupuesto set SaldoPresupuestoTemporal = " + pObj.NuevoSaldoPresupuesto;
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CodigoPresupuesto ='" + pObj.CodigoPresupuesto + "'";
            iScript += " And CCentroCosto ='" + pObj.CCentroCosto + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPresupuestoActual(PresupuestoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update Presupuesto set SaldoPresupuesto = " + pObj.NuevoSaldoPresupuesto;
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And CodigoPresupuesto ='" + pObj.CodigoPresupuesto + "'";
            iScript += " And CCentroCosto ='" + pObj.CCentroCosto + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void RecalcularPresupuesto(string iAno, string iMes, string codCosto, decimal costoMovimiento)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //actualizando la solicitud de pedido
            iScript += "Update Presupuesto set SaldoPresupuestotemporal = (ImportePresupuesto + ImporteAdicionalPresupuesto) - " + costoMovimiento + ",";
            iScript += " SaldoPresupuesto = (ImportePresupuesto + ImporteAdicionalPresupuesto) - " + costoMovimiento + "";
            iScript += " Where CodigoEmpresa='" + Universal.gCodigoEmpresa + "'";
            iScript += " And AnoPresupuesto ='" + iAno + "'";
            iScript += " And CMesPresupuesto ='" + iMes + "'";
            iScript += " And CCentroCosto ='" + codCosto + "'";

            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
    }
}
