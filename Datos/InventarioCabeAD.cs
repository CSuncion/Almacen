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

    public class InventarioCabeAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<InventarioCabeEN> xLista = new List<InventarioCabeEN>();
        private InventarioCabeEN xObj = new InventarioCabeEN();
        private string xTabla = "InventarioCabe";
        private string xVista = "VsInventarioCabe";

        #endregion
        
        #region Metodos privados

        private InventarioCabeEN Objeto(IDataReader iDr)
        {
            InventarioCabeEN xObjEnc = new InventarioCabeEN();
            xObjEnc.ClaveInventarioCabe = iDr[InventarioCabeEN.ClaInvCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[InventarioCabeEN.CodEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[InventarioCabeEN.CodAlm].ToString();           
            xObjEnc.DescripcionAlmacen = iDr[InventarioCabeEN.DesAlm].ToString();
            xObjEnc.CorrelativoInventarioCabe = iDr[InventarioCabeEN.CorInvCab].ToString();
            xObjEnc.CodigoPersonal = iDr[InventarioCabeEN.CodPer].ToString();
            xObjEnc.NombrePersonal = iDr[InventarioCabeEN.NomPer].ToString();
            xObjEnc.FechaInventarioCabe = Fecha.ObtenerDiaMesAno(iDr[InventarioCabeEN.FecInvCab].ToString());
            xObjEnc.StockFisico = Convert.ToDecimal( iDr[InventarioCabeEN.StoFis].ToString());
            xObjEnc.StockTeorico = Convert.ToDecimal(iDr[InventarioCabeEN.StoTeo].ToString());
            xObjEnc.ObservacionInventarioCabe = iDr[InventarioCabeEN.ObsInvCab].ToString();
            xObjEnc.FechaGenera = Fecha.ObtenerDiaMesAno(iDr[InventarioCabeEN.FecGen].ToString());
            xObjEnc.ClaveMovimientoIngreso =iDr[InventarioCabeEN.ClaMovIng].ToString();
            xObjEnc.ClaveMovimientoSalida = iDr[InventarioCabeEN.ClaMovSal].ToString();
            xObjEnc.CEstadoInventarioCabe = iDr[InventarioCabeEN.CEstInvCab].ToString();
            xObjEnc.NEstadoInventarioCabe = iDr[InventarioCabeEN.NEstInvCab].ToString();
            xObjEnc.UsuarioAgrega = iDr[InventarioCabeEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[InventarioCabeEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[InventarioCabeEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[InventarioCabeEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveInventarioCabe;
            return xObjEnc;
        }
        
        private List<InventarioCabeEN> ListarObjetos(string pScript)
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
        
        private InventarioCabeEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(InventarioCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, InventarioCabeEN.CorInvCab);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, MovimientoCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarInventarioCabe(InventarioCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(InventarioCabeEN.ClaInvCab, pObj.ClaveInventarioCabe);
            xIns.AsignarParametro(InventarioCabeEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(InventarioCabeEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(InventarioCabeEN.CorInvCab, pObj.CorrelativoInventarioCabe);            
            xIns.AsignarParametro(InventarioCabeEN.CodPer, pObj.CodigoPersonal);
            xIns.AsignarParametro(InventarioCabeEN.FecInvCab, Fecha.ObtenerAnoMesDia( pObj.FechaInventarioCabe));
            xIns.AsignarParametro(InventarioCabeEN.StoFis, pObj.StockFisico.ToString());
            xIns.AsignarParametro(InventarioCabeEN.StoTeo, pObj.StockTeorico.ToString());
            xIns.AsignarParametro(InventarioCabeEN.ObsInvCab, pObj.ObservacionInventarioCabe);
            xIns.AsignarParametro(InventarioCabeEN.FecGen, Fecha.ObtenerAnoMesDia(pObj.FechaGenera));
            xIns.AsignarParametro(InventarioCabeEN.ClaMovIng, pObj.ClaveMovimientoIngreso);
            xIns.AsignarParametro(InventarioCabeEN.ClaMovSal, pObj.ClaveMovimientoSalida);
            xIns.AsignarParametro(InventarioCabeEN.CEstInvCab, pObj.CEstadoInventarioCabe);
            xIns.AsignarParametro(InventarioCabeEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(InventarioCabeEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(InventarioCabeEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(InventarioCabeEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarInventarioCabe(InventarioCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);       
            xUpd.AsignarParametro(InventarioCabeEN.CodPer, pObj.CodigoPersonal);
            xUpd.AsignarParametro(InventarioCabeEN.FecInvCab, Fecha.ObtenerAnoMesDia(pObj.FechaInventarioCabe));
            xUpd.AsignarParametro(InventarioCabeEN.StoFis, pObj.StockFisico.ToString());
            xUpd.AsignarParametro(InventarioCabeEN.StoTeo, pObj.StockTeorico.ToString());
            xUpd.AsignarParametro(InventarioCabeEN.ObsInvCab, pObj.ObservacionInventarioCabe);
            xUpd.AsignarParametro(InventarioCabeEN.FecGen, Fecha.ObtenerAnoMesDia(pObj.FechaGenera));
            xUpd.AsignarParametro(InventarioCabeEN.ClaMovIng, pObj.ClaveMovimientoIngreso);
            xUpd.AsignarParametro(InventarioCabeEN.ClaMovSal, pObj.ClaveMovimientoSalida);
            xUpd.AsignarParametro(InventarioCabeEN.CEstInvCab, pObj.CEstadoInventarioCabe);
            xUpd.AsignarParametro(InventarioCabeEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(InventarioCabeEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioCabeEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarInventarioCabe(InventarioCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioCabeEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<InventarioCabeEN> ListarInventarioCabes(InventarioCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (Universal.gStrPermisosAlmacen != string.Empty)
            {
                xSel.CondicionINx(SqlSelect.Reservada.Y, InventarioCabeEN.CodAlm, Universal.gStrPermisosAlmacen);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public InventarioCabeEN BuscarInventarioCabeXClave(InventarioCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioCabeEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<InventarioCabeEN> ListarInventarioCabesActivos(InventarioCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, InventarioCabeEN.CEstInvCab, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
