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

    public class PerfilAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<PerfilEN> xLista = new List<PerfilEN>();
        private PerfilEN xObj = new PerfilEN();
        private string xTabla = "Perfil";
        private string xVista = "VsPerfil";

        #region Metodos privados

        private PerfilEN Objeto(IDataReader iDr)
        {
            PerfilEN xObjEnc = new PerfilEN();
            xObjEnc.CodigoPerfil = iDr[PerfilEN.CodPer].ToString();
            xObjEnc.NombrePerfil = iDr[PerfilEN.NomPer].ToString();
            xObjEnc.DescripcionPerfil = iDr[PerfilEN.DesPer].ToString();
            xObjEnc.CEstadoPerfil = iDr[PerfilEN.CEstPer].ToString();
            xObjEnc.NEstadoPerfil = iDr[PerfilEN.NEstPer].ToString();
            xObjEnc.EliminablePerfil = iDr[PerfilEN.EliPer].ToString();            
            xObjEnc.UsuarioAgrega = iDr[PerfilEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[PerfilEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[PerfilEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[PerfilEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.CodigoPerfil;
            return xObjEnc;
        }



        private List<PerfilEN> ListarObjetos(string pScript)
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


        private PerfilEN BuscarObjeto(string pScript)
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

        public void AgregarPerfil(PerfilEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PerfilEN.CodPer, pObj.CodigoPerfil);
            xIns.AsignarParametro(PerfilEN.NomPer, pObj.NombrePerfil);
            xIns.AsignarParametro(PerfilEN.DesPer, pObj.DescripcionPerfil);
            xIns.AsignarParametro(PerfilEN.CEstPer, pObj.CEstadoPerfil);
            xIns.AsignarParametro(PerfilEN.EliPer, pObj.EliminablePerfil);
            xIns.AsignarParametro(PerfilEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PerfilEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(PerfilEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PerfilEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPerfil(PerfilEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(PerfilEN.NomPer, pObj.NombrePerfil);
            xUpd.AsignarParametro(PerfilEN.DesPer, pObj.DescripcionPerfil);
            xUpd.AsignarParametro(PerfilEN.CEstPer, pObj.CEstadoPerfil);
            xUpd.AsignarParametro(PerfilEN.EliPer, pObj.EliminablePerfil);
            xUpd.AsignarParametro(PerfilEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(PerfilEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PerfilEN.CodPer, SqlSelect.Operador.Igual, pObj.CodigoPerfil);            
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPerfil(PerfilEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PerfilEN.CodPer, SqlSelect.Operador.Igual, pObj.CodigoPerfil);            
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<PerfilEN> ListarPerfiles(PerfilEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);            
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PerfilEN> ListarPerfilesXEstado(PerfilEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PerfilEN.CEstPer, SqlSelect.Operador.Igual, pObj.CEstadoPerfil);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PerfilEN BuscarPerfilXCodigo(PerfilEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PerfilEN.CodPer, SqlSelect.Operador.Igual, pObj.CodigoPerfil);            
            return this.BuscarObjeto(xSel.ObtenerScript());
        }
    }
}
