using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Comun;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Datos.Config;

namespace Datos
{

    public class PermisoEmpresaAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<PermisoEmpresaEN> xLista = new List<PermisoEmpresaEN>();
        private PermisoEmpresaEN xObj = new PermisoEmpresaEN();
        private string xTabla = "PermisoEmpresa";
        private string xVista = "VsPermisoEmpresa";


        #region Metodos privados

        private PermisoEmpresaEN Objeto(IDataReader iDr)
        {
            PermisoEmpresaEN xObjEnc = new PermisoEmpresaEN();
            xObjEnc.ClavePermisoEmpresa = iDr[PermisoEmpresaEN.ClaPerEmp].ToString();
            xObjEnc.CodigoUsuario = iDr[PermisoEmpresaEN.CodUsu].ToString();
            xObjEnc.NombreUsuario = iDr[PermisoEmpresaEN.NomUsu].ToString();
            xObjEnc.CodigoPerfil = iDr[PermisoEmpresaEN.CodPer].ToString();
            xObjEnc.NombrePerfil = iDr[PermisoEmpresaEN.NomPer].ToString();
            xObjEnc.CodigoEmpresa = iDr[PermisoEmpresaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[PermisoEmpresaEN.NomEmp].ToString();            
            xObjEnc.CEstadoEmpresa = iDr[PermisoEmpresaEN.CEstEmp].ToString();
            xObjEnc.NEstadoEmpresa = iDr[PermisoEmpresaEN.NEstEmp].ToString();            
            xObjEnc.CPermitir = iDr[PermisoEmpresaEN.CPerm].ToString();
            xObjEnc.NPermitir = iDr[PermisoEmpresaEN.NPerm].ToString();
            xObjEnc.VerdadFalso = Conversion.CadenaABoolean(xObjEnc.CPermitir, false);
            xObjEnc.UsuarioAgrega = iDr[PermisoEmpresaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[PermisoEmpresaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[PermisoEmpresaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[PermisoEmpresaEN.FecMod]);
            return xObjEnc;
        }


        private List<PermisoEmpresaEN> ListarObjetos(string pScript)
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


        private PermisoEmpresaEN BuscarObjeto(string pScript)
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


        public bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumna, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumna, SqlSelect.Operador.Igual, pValor);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }


        public void AdicionarPermisoEmpresa(PermisoEmpresaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PermisoEmpresaEN.ClaPerEmp, pObj.ClavePermisoEmpresa);
            xIns.AsignarParametro(PermisoEmpresaEN.CodUsu, pObj.CodigoUsuario);
            xIns.AsignarParametro(PermisoEmpresaEN.CodEmp, pObj.CodigoEmpresa);            
            xIns.AsignarParametro(PermisoEmpresaEN.CPerm, pObj.CPermitir);            
            xIns.AsignarParametro(PermisoEmpresaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PermisoEmpresaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(PermisoEmpresaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PermisoEmpresaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void AdicionarPermisoEmpresaMasivo( List< PermisoEmpresaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (PermisoEmpresaEN xPerEmp in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(PermisoEmpresaEN.ClaPerEmp, xPerEmp.ClavePermisoEmpresa);
                xIns.AsignarParametro(PermisoEmpresaEN.CodUsu, xPerEmp.CodigoUsuario);
                xIns.AsignarParametro(PermisoEmpresaEN.CodEmp, xPerEmp.CodigoEmpresa);
                xIns.AsignarParametro(PermisoEmpresaEN.CPerm, xPerEmp.CPermitir);
                xIns.AsignarParametro(PermisoEmpresaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(PermisoEmpresaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(PermisoEmpresaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(PermisoEmpresaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
                
            }            
            xObjCon.Desconectar();
        }


        public void ModificarPermisoEmpresa(PermisoEmpresaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PermisoEmpresaEN.CPerm, pObj.CPermitir);            
            xUpd.AsignarParametro(PermisoEmpresaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(PermisoEmpresaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.ClaPerEmp, SqlSelect.Operador.Igual, pObj.ClavePermisoEmpresa);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPermisoEmpresaMasivo(List<PermisoEmpresaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (PermisoEmpresaEN xPerEmp in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);               
                xUpd.AsignarParametro(PermisoEmpresaEN.CPerm, xPerEmp.CPermitir);               
                xUpd.AsignarParametro(PermisoEmpresaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(PermisoEmpresaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.ClaPerEmp, SqlSelect.Operador.Igual, xPerEmp.ClavePermisoEmpresa);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            xObjCon.Desconectar();
        }


        public void EliminarPermisoEmpresa(PermisoEmpresaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.ClaPerEmp, SqlSelect.Operador.Igual, pObj.ClavePermisoEmpresa);            
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void EliminarPermisosEmpresaXUsuario(PermisoEmpresaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, pObj.CodigoUsuario);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void EliminarPermisosEmpresaXEmpresa(PermisoEmpresaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodEmp, SqlSelect.Operador.Igual, pObj.CodigoEmpresa);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public List<PermisoEmpresaEN> ListarPermisosEmpresaAbiertasXUsuario(PermisoEmpresaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CEstEmp, SqlSelect.Operador.Igual, "1"); //abierta
            xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, pObj.CodigoUsuario);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
                

        public List<PermisoEmpresaEN> ListarPermisosEmpresaActivasXUsuarioYAutorizadas(PermisoEmpresaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, pObj.CodigoUsuario);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CEstEmp, SqlSelect.Operador.Igual, "1"); //abierta
            if (pObj.CodigoPerfil != "01")
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CPerm, SqlSelect.Operador.Igual, "1");//autorizada
            }            
            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
                

        public PermisoEmpresaEN BuscarPermisoEmpresaXClave(PermisoEmpresaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.ClaPerEmp, SqlSelect.Operador.Igual, pObj.ClavePermisoEmpresa);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }
                
    }
}
