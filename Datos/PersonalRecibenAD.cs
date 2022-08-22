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

    public class PersonalRecibenAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<PersonalRecibenEN> xLista = new List<PersonalRecibenEN>();
        private PersonalRecibenEN xObj = new PersonalRecibenEN();
        private string xTabla = "PersonalRecibe";
        private string xVista = "VsPersonalRecibe";

        #endregion
        
        #region Metodos privados

        private PersonalRecibenEN Objeto(IDataReader iDr)
        {
            PersonalRecibenEN xObjEnc = new PersonalRecibenEN();
            xObjEnc.ClavePersonalRecibe = iDr[PersonalRecibenEN.ClaPerRec].ToString();
            xObjEnc.CodigoEmpresa = iDr[PersonalRecibenEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[PersonalRecibenEN.NomEmp].ToString();
            xObjEnc.CodigoPersonalRecibe = iDr[PersonalRecibenEN.CodPerRec].ToString();           
            xObjEnc.NombrePersonalRecibe = iDr[PersonalRecibenEN.NomPerRec].ToString();
            xObjEnc.CEstadoPersonalRecibe = iDr[PersonalRecibenEN.CEstPerRec].ToString();
            xObjEnc.NEstadoPersonalRecibe = iDr[PersonalRecibenEN.NEstPerRec].ToString();
            xObjEnc.UsuarioAgrega = iDr[PersonalRecibenEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[PersonalRecibenEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[PersonalRecibenEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[PersonalRecibenEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClavePersonalRecibe;
            return xObjEnc;
        }
        
        private List<PersonalRecibenEN> ListarObjetos(string pScript)
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
        
        private PersonalRecibenEN BuscarObjeto(string pScript)
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

        public void AgregarPersonal(PersonalRecibenEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PersonalRecibenEN.ClaPerRec, pObj.ClavePersonalRecibe);
            xIns.AsignarParametro(PersonalRecibenEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(PersonalRecibenEN.CodPerRec, pObj.CodigoPersonalRecibe);
            xIns.AsignarParametro(PersonalRecibenEN.NomPerRec, pObj.NombrePersonalRecibe);
            xIns.AsignarParametro(PersonalRecibenEN.CEstPerRec, pObj.CEstadoPersonalRecibe);
            xIns.AsignarParametro(PersonalRecibenEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PersonalRecibenEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(PersonalRecibenEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PersonalRecibenEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPersonal(PersonalRecibenEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PersonalRecibenEN.NomPerRec, pObj.NombrePersonalRecibe);
            xUpd.AsignarParametro(PersonalRecibenEN.CEstPerRec, pObj.CEstadoPersonalRecibe);
            xUpd.AsignarParametro(PersonalRecibenEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(PersonalRecibenEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalRecibenEN.ClaPerRec, SqlSelect.Operador.Igual, pObj.ClavePersonalRecibe);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPersonal(PersonalRecibenEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalRecibenEN.ClaPerRec, SqlSelect.Operador.Igual, pObj.ClavePersonalRecibe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<PersonalRecibenEN> ListarPersonales(PersonalRecibenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalRecibenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PersonalRecibenEN BuscarPersonalXClave(PersonalRecibenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalRecibenEN.ClaPerRec, SqlSelect.Operador.Igual, pObj.ClavePersonalRecibe);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<PersonalRecibenEN> ListarPersonalesActivos(PersonalRecibenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalRecibenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PersonalRecibenEN.CEstPerRec, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
