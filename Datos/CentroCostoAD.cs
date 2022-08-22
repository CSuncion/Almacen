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

namespace Datos
{

    public class CentroCostoAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<CentroCostoEN> xLista = new List<CentroCostoEN>();
        private CentroCostoEN xObj = new CentroCostoEN();
        private string xTabla = "CentroCosto";
        private string xVista = "VsCentroCosto";

        #endregion
        
        #region Metodos privados

        private CentroCostoEN Objeto(IDataReader iDr)
        {
            CentroCostoEN xObjEnc = new CentroCostoEN();
            xObjEnc.ClaveCentroCosto = iDr[CentroCostoEN.ClaCeCo].ToString();
            xObjEnc.CodigoEmpresa = iDr[CentroCostoEN.CodEmp].ToString();
            xObjEnc.CodigoCentroCosto = iDr[CentroCostoEN.CodCeCo].ToString();           
            xObjEnc.DescripcionCentroCosto = iDr[CentroCostoEN.DesCeCo].ToString();
            xObjEnc.CEstadoCentroCosto = iDr[CentroCostoEN.CEstCeCo].ToString();
            xObjEnc.NEstadoCentroCosto = iDr[CentroCostoEN.NEstCeCo].ToString();
            xObjEnc.UsuarioAgrega = iDr[CentroCostoEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[CentroCostoEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[CentroCostoEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[CentroCostoEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveCentroCosto;
            return xObjEnc;
        }
        
        private List<CentroCostoEN> ListarObjetos(string pScript)
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
        
        private CentroCostoEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CentroCostoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CentroCostoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }
        
        public void AgregarCentroCosto(CentroCostoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(CentroCostoEN.ClaCeCo, pObj.ClaveCentroCosto);
            xIns.AsignarParametro(CentroCostoEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(CentroCostoEN.CodCeCo, pObj.CodigoCentroCosto);
            xIns.AsignarParametro(CentroCostoEN.DesCeCo, pObj.DescripcionCentroCosto);
            xIns.AsignarParametro(CentroCostoEN.CEstCeCo, pObj.CEstadoCentroCosto);
            xIns.AsignarParametro(CentroCostoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CentroCostoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(CentroCostoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CentroCostoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarCentroCosto(CentroCostoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(CentroCostoEN.DesCeCo, pObj.DescripcionCentroCosto);
            xUpd.AsignarParametro(CentroCostoEN.CEstCeCo, pObj.CEstadoCentroCosto);
            xUpd.AsignarParametro(CentroCostoEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(CentroCostoEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CentroCostoEN.ClaCeCo, SqlSelect.Operador.Igual, pObj.ClaveCentroCosto);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarCentroCosto(CentroCostoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CentroCostoEN.ClaCeCo, SqlSelect.Operador.Igual, pObj.ClaveCentroCosto);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<CentroCostoEN> ListarCentroCostos(CentroCostoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CentroCostoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public CentroCostoEN BuscarCentroCostoXClave(CentroCostoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CentroCostoEN.ClaCeCo, SqlSelect.Operador.Igual, pObj.ClaveCentroCosto);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        #endregion

    }
}
