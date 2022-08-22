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
using Comun;

namespace Datos
{

    public class EncajadoAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<EncajadoEN> xLista = new List<EncajadoEN>();
        private EncajadoEN xObj = new EncajadoEN();
        private string xTabla = "Encajado";
        private string xVista = "VsEncajado";

        #endregion
        
        #region Metodos privados

        private EncajadoEN Objeto(IDataReader iDr)
        {
            EncajadoEN xObjEnc = new EncajadoEN();
            xObjEnc.ClaveEncajado = iDr[EncajadoEN.ClaEnc].ToString();           
            xObjEnc.CodigoEmpresa = iDr[EncajadoEN.CodEmp].ToString();           
            xObjEnc.CorrelativoEncajado = iDr[EncajadoEN.CorEnc].ToString();            
            xObjEnc.FechaEncajado = Fecha.ObtenerDiaMesAno( iDr[EncajadoEN.FecEnc]);
            xObjEnc.PeriodoEncajado = iDr[EncajadoEN.PerEnc].ToString();
            xObjEnc.DescripcionEncajado = iDr[EncajadoEN.DesEnc].ToString();
            xObjEnc.ClaveSalidaFaseEmpaquetado = iDr[EncajadoEN.ClaSalFasEmp].ToString();
            xObjEnc.ClaveSalidaUnidadesEmpacar = iDr[EncajadoEN.ClaSalUniEmp].ToString();
            xObjEnc.ClaveIngresoProductoTerminado = iDr[EncajadoEN.ClaIngProTer].ToString();
            xObjEnc.ClaveSalidaUnidadesEmpacarObservados = iDr[EncajadoEN.ClaSalUniEmpObs].ToString();
            xObjEnc.ClaveSalidaUnidadesEmpacarCuarentena = iDr[EncajadoEN.ClaSalUniEmpCua].ToString();
            xObjEnc.CEstadoEncajado = iDr[EncajadoEN.CEstEnc].ToString();
            xObjEnc.NEstadoEncajado = iDr[EncajadoEN.NEstEnc].ToString();
            xObjEnc.UsuarioAgrega = iDr[EncajadoEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[EncajadoEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[EncajadoEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[EncajadoEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveEncajado;
            return xObjEnc;
        }
        
        private List<EncajadoEN> ListarObjetos(string pScript)
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
        
        private EncajadoEN BuscarObjeto(string pScript)
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

        private DataTable ObtenerTabla(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            DataTable iTabla = xObjCon.ObtenerTablaRegistro();
            xObjCon.Desconectar();
            return iTabla;
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, EncajadoEN.CorEnc);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);           
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarEncajado(EncajadoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(EncajadoEN.ClaEnc, pObj.ClaveEncajado);
            xIns.AsignarParametro(EncajadoEN.CodEmp, pObj.CodigoEmpresa);           
            xIns.AsignarParametro(EncajadoEN.CorEnc, pObj.CorrelativoEncajado);
            xIns.AsignarParametro(EncajadoEN.FecEnc, Fecha.ObtenerAnoMesDia(pObj.FechaEncajado));                  
            xIns.AsignarParametro(EncajadoEN.PerEnc, pObj.PeriodoEncajado);
            xIns.AsignarParametro(EncajadoEN.DesEnc, pObj.DescripcionEncajado);
            xIns.AsignarParametro(EncajadoEN.ClaSalFasEmp, pObj.ClaveSalidaFaseEmpaquetado);
            xIns.AsignarParametro(EncajadoEN.ClaSalUniEmp, pObj.ClaveSalidaUnidadesEmpacar);
            xIns.AsignarParametro(EncajadoEN.ClaIngProTer, pObj.ClaveIngresoProductoTerminado);
            xIns.AsignarParametro(EncajadoEN.ClaSalUniEmpObs, pObj.ClaveSalidaUnidadesEmpacarObservados);
            xIns.AsignarParametro(EncajadoEN.ClaSalUniEmpCua, pObj.ClaveSalidaUnidadesEmpacarCuarentena);
            xIns.AsignarParametro(EncajadoEN.CEstEnc, pObj.CEstadoEncajado);
            xIns.AsignarParametro(EncajadoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(EncajadoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(EncajadoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(EncajadoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarEncajado(List< EncajadoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (EncajadoEN xExi in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(EncajadoEN.ClaEnc, xExi.ClaveEncajado);
                xIns.AsignarParametro(EncajadoEN.CodEmp, xExi.CodigoEmpresa);
                xIns.AsignarParametro(EncajadoEN.CorEnc, xExi.CorrelativoEncajado);
                xIns.AsignarParametro(EncajadoEN.FecEnc, Fecha.ObtenerAnoMesDia(xExi.FechaEncajado));
                xIns.AsignarParametro(EncajadoEN.PerEnc, xExi.PeriodoEncajado);
                xIns.AsignarParametro(EncajadoEN.DesEnc, xExi.DescripcionEncajado);
                xIns.AsignarParametro(EncajadoEN.ClaSalFasEmp, xExi.ClaveSalidaFaseEmpaquetado);
                xIns.AsignarParametro(EncajadoEN.ClaSalUniEmp, xExi.ClaveSalidaUnidadesEmpacar);
                xIns.AsignarParametro(EncajadoEN.ClaIngProTer, xExi.ClaveIngresoProductoTerminado);
                xIns.AsignarParametro(EncajadoEN.ClaSalUniEmpObs, xExi.ClaveSalidaUnidadesEmpacarObservados);
                xIns.AsignarParametro(EncajadoEN.ClaSalUniEmpCua, xExi.ClaveSalidaUnidadesEmpacarCuarentena);
                xIns.AsignarParametro(EncajadoEN.CEstEnc, xExi.CEstadoEncajado);
                xIns.AsignarParametro(EncajadoEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(EncajadoEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(EncajadoEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(EncajadoEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarEncajado(EncajadoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(EncajadoEN.FecEnc, Fecha.ObtenerAnoMesDia(pObj.FechaEncajado));
            xUpd.AsignarParametro(EncajadoEN.PerEnc, pObj.PeriodoEncajado);
            xUpd.AsignarParametro(EncajadoEN.DesEnc, pObj.DescripcionEncajado);
            xUpd.AsignarParametro(EncajadoEN.ClaSalFasEmp, pObj.ClaveSalidaFaseEmpaquetado);
            xUpd.AsignarParametro(EncajadoEN.ClaSalUniEmp, pObj.ClaveSalidaUnidadesEmpacar);
            xUpd.AsignarParametro(EncajadoEN.ClaIngProTer, pObj.ClaveIngresoProductoTerminado);
            xUpd.AsignarParametro(EncajadoEN.ClaSalUniEmpObs, pObj.ClaveSalidaUnidadesEmpacarObservados);
            xUpd.AsignarParametro(EncajadoEN.ClaSalUniEmpCua, pObj.ClaveSalidaUnidadesEmpacarCuarentena);
            xUpd.AsignarParametro(EncajadoEN.CEstEnc, pObj.CEstadoEncajado);
            xUpd.AsignarParametro(EncajadoEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(EncajadoEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarEncajado(List<EncajadoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (EncajadoEN xExi in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(EncajadoEN.FecEnc, Fecha.ObtenerAnoMesDia(xExi.FechaEncajado));
                xUpd.AsignarParametro(EncajadoEN.PerEnc, xExi.PeriodoEncajado);
                xUpd.AsignarParametro(EncajadoEN.DesEnc, xExi.DescripcionEncajado);
                xUpd.AsignarParametro(EncajadoEN.ClaSalFasEmp, xExi.ClaveSalidaFaseEmpaquetado);
                xUpd.AsignarParametro(EncajadoEN.ClaSalUniEmp, xExi.ClaveSalidaUnidadesEmpacar);
                xUpd.AsignarParametro(EncajadoEN.ClaIngProTer, xExi.ClaveIngresoProductoTerminado);
                xUpd.AsignarParametro(EncajadoEN.ClaSalUniEmpObs, xExi.ClaveSalidaUnidadesEmpacarObservados);
                xUpd.AsignarParametro(EncajadoEN.ClaSalUniEmpCua, xExi.ClaveSalidaUnidadesEmpacarCuarentena);
                xUpd.AsignarParametro(EncajadoEN.CEstEnc, xExi.CEstadoEncajado);
                xUpd.AsignarParametro(EncajadoEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(EncajadoEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.ClaEnc, SqlSelect.Operador.Igual, xExi.ClaveEncajado);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }           
            xObjCon.Desconectar();
        }

        public void EliminarEncajado(EncajadoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarEncajado(List< EncajadoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (EncajadoEN xExi in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.ClaEnc, SqlSelect.Operador.Igual, xExi.ClaveEncajado);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public List<EncajadoEN> ListarEncajados(EncajadoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public EncajadoEN BuscarEncajadoXClave(EncajadoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.ClaEnc, SqlSelect.Operador.Igual, pObj.ClaveEncajado);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<EncajadoEN> ListarEncajadoXEstado(EncajadoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EncajadoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (pObj.CEstadoEncajado != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, EncajadoEN.CEstEnc, SqlSelect.Operador.Igual, pObj.CEstadoEncajado);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        
        #endregion

    }
}
