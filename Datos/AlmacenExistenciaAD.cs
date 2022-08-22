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

    public class AlmacenExistenciaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<AlmacenExistenciaEN> xLista = new List<AlmacenExistenciaEN>();
        private AlmacenExistenciaEN xObj = new AlmacenExistenciaEN();
        private string xTabla = "AlmacenExistencia";
        private string xVista = "VsAlmacenExistencia";

        #endregion
        
        #region Metodos privados

        private AlmacenExistenciaEN Objeto(IDataReader iDr)
        {
            AlmacenExistenciaEN xObjEnc = new AlmacenExistenciaEN();
            xObjEnc.ClaveAlmacenExistencia = iDr[AlmacenExistenciaEN.ClaAlmExi].ToString();
            xObjEnc.CodigoEmpresa = iDr[AlmacenExistenciaEN.CodEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[AlmacenExistenciaEN.CodAlm].ToString();           
            xObjEnc.DescripcionAlmacen = iDr[AlmacenExistenciaEN.DesAlm].ToString();
            xObjEnc.CodigoExistencia = iDr[AlmacenExistenciaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[AlmacenExistenciaEN.DesExi].ToString();
            xObjEnc.StockInicialAlmacenExistencia = Convert.ToDecimal(iDr[AlmacenExistenciaEN.StoIniAlmExi].ToString());
            xObjEnc.StockTomaAlmacenExistencia = Convert.ToDecimal(iDr[AlmacenExistenciaEN.StoTomAlmExi].ToString());
            xObjEnc.StockActualAlmacenExistencia = Convert.ToDecimal(iDr[AlmacenExistenciaEN.StoActAlmExi].ToString());
            xObjEnc.PrecioInicialAlmacenExistencia = Convert.ToDecimal(iDr[AlmacenExistenciaEN.PreIniAlmExi].ToString());
            xObjEnc.PrecioPromedioAlmacenExistencia = Convert.ToDecimal(iDr[AlmacenExistenciaEN.PreProAlmExi].ToString());
            xObjEnc.UsuarioAgrega = iDr[AlmacenExistenciaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[AlmacenExistenciaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[AlmacenExistenciaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[AlmacenExistenciaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveAlmacenExistencia;
            return xObjEnc;
        }
        
        private List<AlmacenExistenciaEN> ListarObjetos(string pScript)
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
        
        private AlmacenExistenciaEN BuscarObjeto(string pScript)
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

        public bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumna, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumna, SqlSelect.Operador.Igual, pValor);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarAlmacenExistencia(AlmacenExistenciaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(AlmacenExistenciaEN.ClaAlmExi, pObj.ClaveAlmacenExistencia);
            xIns.AsignarParametro(AlmacenExistenciaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(AlmacenExistenciaEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(AlmacenExistenciaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(AlmacenExistenciaEN.StoTomAlmExi, pObj.StockTomaAlmacenExistencia.ToString());
            xIns.AsignarParametro(AlmacenExistenciaEN.StoIniAlmExi, pObj.StockInicialAlmacenExistencia.ToString());
            xIns.AsignarParametro(AlmacenExistenciaEN.StoActAlmExi, pObj.StockActualAlmacenExistencia.ToString());
            xIns.AsignarParametro(AlmacenExistenciaEN.PreIniAlmExi, pObj.PrecioInicialAlmacenExistencia.ToString());
            xIns.AsignarParametro(AlmacenExistenciaEN.PreProAlmExi, pObj.PrecioPromedioAlmacenExistencia.ToString());
            xIns.AsignarParametro(AlmacenExistenciaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(AlmacenExistenciaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(AlmacenExistenciaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(AlmacenExistenciaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarAlmacenExistencia(AlmacenExistenciaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(AlmacenExistenciaEN.StoTomAlmExi, pObj.StockTomaAlmacenExistencia.ToString());
            xUpd.AsignarParametro(AlmacenExistenciaEN.StoIniAlmExi, pObj.StockInicialAlmacenExistencia.ToString());
            xUpd.AsignarParametro(AlmacenExistenciaEN.StoActAlmExi, pObj.StockActualAlmacenExistencia.ToString());
            xUpd.AsignarParametro(AlmacenExistenciaEN.PreIniAlmExi, pObj.PrecioInicialAlmacenExistencia.ToString());
            xUpd.AsignarParametro(AlmacenExistenciaEN.PreProAlmExi, pObj.PrecioPromedioAlmacenExistencia.ToString());
            xUpd.AsignarParametro(AlmacenExistenciaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(AlmacenExistenciaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenExistenciaEN.ClaAlmExi, SqlSelect.Operador.Igual, pObj.ClaveAlmacenExistencia);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarAlmacenExistencia(AlmacenExistenciaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenExistenciaEN.ClaAlmExi, SqlSelect.Operador.Igual, pObj.ClaveAlmacenExistencia);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<AlmacenExistenciaEN> ListarAlmacenExistencias(AlmacenExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public AlmacenExistenciaEN BuscarAlmacenExistenciaXClave(AlmacenExistenciaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, AlmacenExistenciaEN.ClaAlmExi, SqlSelect.Operador.Igual, pObj.ClaveAlmacenExistencia);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        #endregion

    }
}
