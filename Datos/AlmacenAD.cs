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

    public class AlmacenAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<AlmacenEN> xLista = new List<AlmacenEN>();
        private AlmacenEN xObj = new AlmacenEN();
        private string xTabla = "Almacen";
        private string xVista = "VsAlmacen";

        #endregion
        
        #region Metodos privados

        private AlmacenEN Objeto(IDataReader iDr)
        {
            AlmacenEN xObjEnc = new AlmacenEN();
            xObjEnc.ClaveAlmacen = iDr[AlmacenEN.ClaAlm].ToString();
            xObjEnc.CodigoEmpresa = iDr[AlmacenEN.CodEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[AlmacenEN.CodAlm].ToString();           
            xObjEnc.DescripcionAlmacen = iDr[AlmacenEN.DesAlm].ToString();
            xObjEnc.DireccionAlmacen = iDr[AlmacenEN.DirAlm].ToString();
            xObjEnc.CodigoPersonal = iDr[AlmacenEN.CodPer].ToString();
            xObjEnc.NombrePersonal = iDr[AlmacenEN.NomPer].ToString();
            xObjEnc.CEstadoAlmacen = iDr[AlmacenEN.CEstAlm].ToString();
            xObjEnc.NEstadoAlmacen = iDr[AlmacenEN.NEstAlm].ToString();
            xObjEnc.UsuarioAgrega = iDr[AlmacenEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[AlmacenEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[AlmacenEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[AlmacenEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveAlmacen;
            return xObjEnc;
        }
        
        private List<AlmacenEN> ListarObjetos(string pScript)
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
        
        private AlmacenEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }
        
        public void AgregarAlmacen(AlmacenEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(AlmacenEN.ClaAlm, pObj.ClaveAlmacen);
            xIns.AsignarParametro(AlmacenEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(AlmacenEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(AlmacenEN.DesAlm, pObj.DescripcionAlmacen);
            xIns.AsignarParametro(AlmacenEN.DirAlm, pObj.DireccionAlmacen);
            xIns.AsignarParametro(AlmacenEN.CodPer, pObj.CodigoPersonal);
            xIns.AsignarParametro(AlmacenEN.CEstAlm, pObj.CEstadoAlmacen);
            xIns.AsignarParametro(AlmacenEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(AlmacenEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(AlmacenEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(AlmacenEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarAlmacen(AlmacenEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(AlmacenEN.DesAlm, pObj.DescripcionAlmacen);
            xUpd.AsignarParametro(AlmacenEN.DirAlm, pObj.DireccionAlmacen);
            xUpd.AsignarParametro(AlmacenEN.CodPer, pObj.CodigoPersonal);
            xUpd.AsignarParametro(AlmacenEN.CEstAlm, pObj.CEstadoAlmacen);
            xUpd.AsignarParametro(AlmacenEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(AlmacenEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenEN.ClaAlm, SqlSelect.Operador.Igual, pObj.ClaveAlmacen);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarAlmacen(AlmacenEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenEN.ClaAlm, SqlSelect.Operador.Igual, pObj.ClaveAlmacen);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<AlmacenEN> ListarAlmacenes(AlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, AlmacenEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public AlmacenEN BuscarAlmacenXClave(AlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenEN.ClaAlm, SqlSelect.Operador.Igual, pObj.ClaveAlmacen);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<AlmacenEN> ListarAlmacenesActivos(AlmacenEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, AlmacenEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, AlmacenEN.CEstAlm, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
