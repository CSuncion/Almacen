using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptBD;
using Entidades;
using Entidades.Adicionales;
using Datos.Config;
using System.Data;
using Comun;


namespace Datos
{
    public class TipoCambioAD
    {

        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<TipoCambioEN> xLista = new List<TipoCambioEN>();
        private TipoCambioEN xObj = new TipoCambioEN();
        private string xTabla = "TipoCambio";
        private string xVista = "VsTipoCambio";


        #region Metodos privados

        private TipoCambioEN Objeto(IDataReader iDr)
        {
            TipoCambioEN xObjEnc = new TipoCambioEN();
            xObjEnc.FechaTipoCambio = Fecha.ObtenerDiaMesAno(iDr[TipoCambioEN.FecTipCam].ToString());
            xObjEnc.CompraTipoCambio = Convert.ToDecimal(iDr[TipoCambioEN.ComTipCam]);
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[TipoCambioEN.VtaTipCam]);
            xObjEnc.PeriodoTipoCambio = iDr[TipoCambioEN.PerTipCam].ToString();
            xObjEnc.CEstadoTipoCambio = iDr[TipoCambioEN.CEstTipCam].ToString();
            xObjEnc.NEstadoTipoCambio = iDr[TipoCambioEN.NEstTipCam].ToString();
            xObjEnc.UsuarioAgrega = iDr[TipoCambioEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[TipoCambioEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[TipoCambioEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[TipoCambioEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.FechaTipoCambio;
            return xObjEnc;
        }


        private List<TipoCambioEN> ListarObjetos(string pScript)
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


        private TipoCambioEN BuscarObjeto(string pScript)
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


        public void AgregarTipoCambio(TipoCambioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(TipoCambioEN.FecTipCam, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            xIns.AsignarParametro(TipoCambioEN.ComTipCam, pObj.CompraTipoCambio.ToString());
            xIns.AsignarParametro(TipoCambioEN.VtaTipCam, pObj.VentaTipoCambio.ToString());
            xIns.AsignarParametro(TipoCambioEN.PerTipCam, pObj.PeriodoTipoCambio);
            xIns.AsignarParametro(TipoCambioEN.CEstTipCam, pObj.CEstadoTipoCambio);
            xIns.AsignarParametro(TipoCambioEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(TipoCambioEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(TipoCambioEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(TipoCambioEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void ModificarTipoCambio(TipoCambioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(TipoCambioEN.ComTipCam, pObj.CompraTipoCambio.ToString());
            xUpd.AsignarParametro(TipoCambioEN.VtaTipCam, pObj.VentaTipoCambio.ToString());
            xUpd.AsignarParametro(TipoCambioEN.PerTipCam, pObj.PeriodoTipoCambio);
            xUpd.AsignarParametro(TipoCambioEN.CEstTipCam, pObj.CEstadoTipoCambio);
            xUpd.AsignarParametro(TipoCambioEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(TipoCambioEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoCambioEN.FecTipCam, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void EliminarTipoCambio(TipoCambioEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoCambioEN.FecTipCam, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public List<TipoCambioEN> ListarTipoCambio(TipoCambioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            //   xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Desc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


        public List<TipoCambioEN> ListarDiasActivos(TipoCambioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoCambioEN.CEstTipCam, SqlSelect.Operador.Igual, "1");//abierto
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public TipoCambioEN BuscarTipoCambioXFecha(TipoCambioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoCambioEN.FecTipCam, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public TipoCambioEN BuscarTipoCambioXCodigo(TipoCambioEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, TipoCambioEN.FecTipCam, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaTipoCambio));
            return this.BuscarObjeto(xSel.ObtenerScript());
        }








    }
}
