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

    public class PersonalAutorizanAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<PersonalAutorizanEN> xLista = new List<PersonalAutorizanEN>();
        private PersonalAutorizanEN xObj = new PersonalAutorizanEN();
        private string xTabla = "PersonalAutoriza";
        private string xVista = "VsPersonalAutoriza";

        #endregion
        
        #region Metodos privados

        private PersonalAutorizanEN Objeto(IDataReader iDr)
        {
            PersonalAutorizanEN xObjEnc = new PersonalAutorizanEN();
            xObjEnc.ClavePersonalAutoriza = iDr[PersonalAutorizanEN.ClaPerAut].ToString();
            xObjEnc.CodigoEmpresa = iDr[PersonalAutorizanEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[PersonalAutorizanEN.NomEmp].ToString();
            xObjEnc.CodigoPersonalAutoriza = iDr[PersonalAutorizanEN.CodPerAut].ToString();           
            xObjEnc.NombrePersonalAutoriza = iDr[PersonalAutorizanEN.NomPerAut].ToString();
            xObjEnc.CEstadoPersonalAutoriza = iDr[PersonalAutorizanEN.CEstPerAut].ToString();
            xObjEnc.NEstadoPersonalAutoriza = iDr[PersonalAutorizanEN.NEstPerAut].ToString();
            xObjEnc.UsuarioAgrega = iDr[PersonalAutorizanEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[PersonalAutorizanEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[PersonalAutorizanEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[PersonalAutorizanEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClavePersonalAutoriza;
            return xObjEnc;
        }
        
        private List<PersonalAutorizanEN> ListarObjetos(string pScript)
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
        
        private PersonalAutorizanEN BuscarObjeto(string pScript)
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

        public void AgregarPersonal(PersonalAutorizanEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PersonalAutorizanEN.ClaPerAut, pObj.ClavePersonalAutoriza);
            xIns.AsignarParametro(PersonalAutorizanEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(PersonalAutorizanEN.CodPerAut, pObj.CodigoPersonalAutoriza);
            xIns.AsignarParametro(PersonalAutorizanEN.NomPerAut, pObj.NombrePersonalAutoriza);
            xIns.AsignarParametro(PersonalAutorizanEN.CEstPerAut, pObj.CEstadoPersonalAutoriza);
            xIns.AsignarParametro(PersonalAutorizanEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PersonalAutorizanEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(PersonalAutorizanEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PersonalAutorizanEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPersonal(PersonalAutorizanEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PersonalAutorizanEN.NomPerAut, pObj.NombrePersonalAutoriza);
            xUpd.AsignarParametro(PersonalAutorizanEN.CEstPerAut, pObj.CEstadoPersonalAutoriza);
            xUpd.AsignarParametro(PersonalAutorizanEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(PersonalAutorizanEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalAutorizanEN.ClaPerAut, SqlSelect.Operador.Igual, pObj.ClavePersonalAutoriza);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPersonal(PersonalAutorizanEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalAutorizanEN.ClaPerAut, SqlSelect.Operador.Igual, pObj.ClavePersonalAutoriza);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<PersonalAutorizanEN> ListarPersonales(PersonalAutorizanEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalAutorizanEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PersonalAutorizanEN BuscarPersonalXClave(PersonalAutorizanEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalAutorizanEN.ClaPerAut, SqlSelect.Operador.Igual, pObj.ClavePersonalAutoriza);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<PersonalAutorizanEN> ListarPersonalesActivos(PersonalAutorizanEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalAutorizanEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PersonalAutorizanEN.CEstPerAut, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
