using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Datos.Config;
using Entidades.Adicionales;

namespace Datos
{
    public class FactorCIFAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<FactorCIFEN> xLista = new List<FactorCIFEN>();
        private FactorCIFEN xObj = new FactorCIFEN();
        private string xTabla = "FactorCIF";
        private string xVista = "VsFactorCIF";

        #endregion
      
        #region Metodos privados

        private FactorCIFEN Objeto(IDataReader iDr)
        {
            FactorCIFEN xObjEnc = new FactorCIFEN();
            xObjEnc.ClaveFactorCif = iDr[FactorCIFEN.ClaFacCif].ToString();
            xObjEnc.CodigoFactorCif = iDr[FactorCIFEN.CodFacCif].ToString();
            xObjEnc.CodigoEmpresa = iDr[FactorCIFEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[FactorCIFEN.NomEmp].ToString();
            xObjEnc.AnoFactorCif = iDr[FactorCIFEN.AnoFacCif].ToString();
            xObjEnc.CMesFactorCif = iDr[FactorCIFEN.CMesFacCif].ToString();
            xObjEnc.NMesFactorCif = iDr[FactorCIFEN.NMesFacCif].ToString();
            xObjEnc.GasFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.GasFacCif].ToString());
            xObjEnc.ElectricidadFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.EleFacCif].ToString());
            xObjEnc.AguaFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.AguFacCif].ToString());
            xObjEnc.AlquilerFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.AlqFacCif].ToString());
            xObjEnc.DepreciacionFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.DepFacCif].ToString());
            xObjEnc.RemuneracionMOIFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.RemMoiFacCif].ToString());
            xObjEnc.SuministrosPlantaFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.SumPlaFacCif].ToString());
            xObjEnc.MantenimientoMaquinariaFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.ManMaqFacCif].ToString());
            xObjEnc.CalidadFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.CalFacCif].ToString());
            xObjEnc.EquipoProteccionpersonalFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.EquiProPerFacCif].ToString());
            xObjEnc.CantidadKilosFactorCif = Convert.ToDecimal(iDr[FactorCIFEN.CanKilFacCif].ToString());
            xObjEnc.FactorCif = Convert.ToDecimal(iDr[FactorCIFEN.FacCif].ToString());
            xObjEnc.CEstadoFactorCif = iDr[FactorCIFEN.CEstFacCif].ToString();
            xObjEnc.NEstadoFactorCif = iDr[FactorCIFEN.NEstFacCif].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveFactorCif;
            return xObjEnc;
        }

        private List<FactorCIFEN> ListarObjetos(string pScript)
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

        private FactorCIFEN BuscarObjeto(string pScript)
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


        public bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarFactorCIF(FactorCIFEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);            

            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(FactorCIFEN.ClaFacCif, pObj.ClaveFactorCif);
            xIns.AsignarParametro(FactorCIFEN.CodFacCif, pObj.CodigoFactorCif);
            xIns.AsignarParametro(FactorCIFEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(FactorCIFEN.AnoFacCif, pObj.AnoFactorCif);
            xIns.AsignarParametro(FactorCIFEN.CMesFacCif, pObj.CMesFactorCif);
            xIns.AsignarParametro(FactorCIFEN.GasFacCif, pObj.GasFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.EleFacCif, pObj.ElectricidadFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.AguFacCif, pObj.AguaFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.AlqFacCif, pObj.AlquilerFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.DepFacCif, pObj.DepreciacionFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.RemMoiFacCif, pObj.RemuneracionMOIFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.SumPlaFacCif, pObj.SuministrosPlantaFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.ManMaqFacCif, pObj.MantenimientoMaquinariaFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.CalFacCif, pObj.CalidadFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.EquiProPerFacCif, pObj.EquipoProteccionpersonalFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.CanKilFacCif, pObj.CantidadKilosFactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.FacCif, pObj.FactorCif.ToString());
            xIns.AsignarParametro(FactorCIFEN.CEstFacCif, pObj.CEstadoFactorCif);
            xIns.AsignarParametro(FactorCIFEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(FactorCIFEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(FactorCIFEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(FactorCIFEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarFactorCIF(FactorCIFEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);            
            xUpd.AsignarParametro(FactorCIFEN.GasFacCif, pObj.GasFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.EleFacCif, pObj.ElectricidadFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.AguFacCif, pObj.AguaFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.AlqFacCif, pObj.AlquilerFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.DepFacCif, pObj.DepreciacionFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.RemMoiFacCif, pObj.RemuneracionMOIFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.SumPlaFacCif, pObj.SuministrosPlantaFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.ManMaqFacCif, pObj.MantenimientoMaquinariaFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.CalFacCif, pObj.CalidadFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.EquiProPerFacCif, pObj.EquipoProteccionpersonalFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.CanKilFacCif, pObj.CantidadKilosFactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.FacCif, pObj.FactorCif.ToString());
            xUpd.AsignarParametro(FactorCIFEN.CEstFacCif, pObj.CEstadoFactorCif);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCIFEN.ClaFacCif, SqlSelect.Operador.Igual, pObj.ClaveFactorCif);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarEstadoFactorCostoDeAño(FactorCostoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(FactorCostoEN.CEstFacCos, pObj.CEstadoFactorCosto);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCostoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FactorCostoEN.AnoFacCos, SqlSelect.Operador.Igual, pObj.AnoFactorCosto);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarFactorCosto(FactorCIFEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCIFEN.ClaFacCif, SqlSelect.Operador.Igual, pObj.ClaveFactorCif);
            xDel.CondicionDelete(xSel.ObtenerScript());

            //ejecutar
            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<FactorCIFEN> ListarFactorCostos(FactorCIFEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCIFEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public FactorCIFEN BuscarFactorCIFXClave(FactorCIFEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCIFEN.ClaFacCif, SqlSelect.Operador.Igual, pObj.ClaveFactorCif);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<FactorCIFEN> ListarFactorCostosXEstado(FactorCIFEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCIFEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FactorCIFEN.CEstFacCif, SqlSelect.Operador.Igual, pObj.CEstadoFactorCif);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FactorCIFEN> ListarFactorCostosXAñoYEstado(FactorCIFEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FactorCIFEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FactorCIFEN.AnoFacCif, SqlSelect.Operador.Igual, pObj.AnoFactorCif);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FactorCIFEN.CEstFacCif, SqlSelect.Operador.Igual, pObj.CEstadoFactorCif);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
    }
}
