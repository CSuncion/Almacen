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

    public class PersonalAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<PersonalEN> xLista = new List<PersonalEN>();
        private PersonalEN xObj = new PersonalEN();
        private string xTabla = "Personal";
        private string xVista = "VsPersonal";

        #endregion
        
        #region Metodos privados

        private PersonalEN Objeto(IDataReader iDr)
        {
            PersonalEN xObjEnc = new PersonalEN();
            xObjEnc.ClavePersonal = iDr[PersonalEN.ClaPer].ToString();
            xObjEnc.CodigoEmpresa = iDr[PersonalEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[PersonalEN.NomEmp].ToString();
            xObjEnc.CodigoPersonal = iDr[PersonalEN.CodPer].ToString();           
            xObjEnc.NombrePersonal = iDr[PersonalEN.NomPer].ToString();
            xObjEnc.CEstadoPersonal = iDr[PersonalEN.CEstPer].ToString();
            xObjEnc.NEstadoPersonal = iDr[PersonalEN.NEstPer].ToString();
            xObjEnc.UsuarioAgrega = iDr[PersonalEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[PersonalEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[PersonalEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[PersonalEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClavePersonal;
            return xObjEnc;
        }
        
        private List<PersonalEN> ListarObjetos(string pScript)
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
        
        private PersonalEN BuscarObjeto(string pScript)
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

        public void AgregarPersonal(PersonalEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PersonalEN.ClaPer, pObj.ClavePersonal);
            xIns.AsignarParametro(PersonalEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(PersonalEN.CodPer, pObj.CodigoPersonal);
            xIns.AsignarParametro(PersonalEN.NomPer, pObj.NombrePersonal);
            xIns.AsignarParametro(PersonalEN.CEstPer, pObj.CEstadoPersonal);
            xIns.AsignarParametro(PersonalEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PersonalEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(PersonalEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PersonalEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPersonal(PersonalEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PersonalEN.NomPer, pObj.NombrePersonal);
            xUpd.AsignarParametro(PersonalEN.CEstPer, pObj.CEstadoPersonal);
            xUpd.AsignarParametro(PersonalEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(PersonalEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalEN.ClaPer, SqlSelect.Operador.Igual, pObj.ClavePersonal);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPersonal(PersonalEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalEN.ClaPer, SqlSelect.Operador.Igual, pObj.ClavePersonal);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<PersonalEN> ListarPersonales(PersonalEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PersonalEN BuscarPersonalXClave(PersonalEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalEN.ClaPer, SqlSelect.Operador.Igual, pObj.ClavePersonal);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<PersonalEN> ListarPersonalesActivos(PersonalEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PersonalEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PersonalEN.CEstPer, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
