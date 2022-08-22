using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptBD;
using System.Data;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Datos.Config;
using System.Collections;


namespace Datos
{

    public class ParametroAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<ParametroEN> xLista = new List<ParametroEN>();
        private ParametroEN xObj = new ParametroEN();
        private string xTabla = "Parametro";
        private string xVista = "VsParametro";

        #endregion
        
        #region Metodos privados

        private ParametroEN Objeto(IDataReader iDr)
        {
            ParametroEN xObjEnc = new ParametroEN();         
            xObjEnc.RutaLogoEmpresa = iDr[ParametroEN.RutLogEmp].ToString();
            xObjEnc.RutaImagenExistencia = iDr[ParametroEN.RutImaExi].ToString();
            xObjEnc.PorcentajeIgv = Convert.ToDecimal(iDr[ParametroEN.PorIgv].ToString());            
            xObjEnc.NombreSoles = iDr[ParametroEN.NomSol].ToString();
            xObjEnc.NombreDolares = iDr[ParametroEN.NomDol].ToString();
            xObjEnc.TipoOperacionTransferenciaIngreso = iDr[ParametroEN.TipOpeTraIng].ToString();
            xObjEnc.TipoOperacionTransferenciaSalida = iDr[ParametroEN.TipOpeTraSal].ToString();
            xObjEnc.TipoOperacionProduccionSalida = iDr[ParametroEN.TipOpeProSal].ToString();
            xObjEnc.TipoOperacionProduccionIngreso = iDr[ParametroEN.TipOpeProIng].ToString();
            xObjEnc.CentroCostoProduccion = iDr[ParametroEN.CenCosPro].ToString();
            xObjEnc.TipoOperacionCompraMigracion = iDr[ParametroEN.TipOpeComMig].ToString();
            xObjEnc.TipoOperacionImportacionMigracion = iDr[ParametroEN.TipOpeImpMig].ToString();
            xObjEnc.TipoOperacionIngresoMigracion = iDr[ParametroEN.TipOpeIngMig].ToString();
            xObjEnc.TipoOperacionSalidaMigracion = iDr[ParametroEN.TipOpeSalMig].ToString();
            xObjEnc.TipoOperacionIngresoAjuste = iDr[ParametroEN.TipOpeIngAju].ToString();
            xObjEnc.TipoOperacionSalidaAjuste = iDr[ParametroEN.TipOpeSalAju].ToString();
            xObjEnc.TipoOperacionIngresoDevolucionProduccion = iDr[ParametroEN.TipOpeIngDevPro].ToString();
            xObjEnc.TipoOperacionSalidaNoPasan = iDr[ParametroEN.TipOpeSalNoPas].ToString();
            xObjEnc.CorreoEnvio = iDr[ParametroEN.CorEnv].ToString();
            xObjEnc.ClaveCorreoEnvio = iDr[ParametroEN.ClaCorEnv].ToString();
            xObjEnc.HostCorreoEnvio = iDr[ParametroEN.HostCorEnv].ToString();
            xObjEnc.PuertoCorreoEnvio = iDr[ParametroEN.PueCorEnv].ToString();
            xObjEnc.RutaCarpetaPlantillas = iDr[ParametroEN.RutCarPla].ToString();

            xObjEnc.UsuarioAgrega = iDr[ParametroEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[ParametroEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[ParametroEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[ParametroEN.FecMod]);            
            return xObjEnc;
        }
        
        private List<ParametroEN> ListarObjetos(string pScript)
        {
            xObjCon.Conectar( SqlDatos.Bd.Almacen_Produccion );
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr=xObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xLista.Add(this.Objeto(xIdr));
            }
            xObjCon.Desconectar();
            return xLista;        
        }
        
        private ParametroEN BuscarObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr=xObjCon.ObtenerIdr();
            while (xIdr.Read())
            {
                //adicionando cada objeto a la lista
                this.xObj=this.Objeto(xIdr);
            }
            xObjCon.Desconectar();
            return xObj;        
        }
        
        private bool ExisteObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(pScript);
            IDataReader xIdr=xObjCon.ObtenerIdr();
            bool xResultado=false;
            while (xIdr.Read())
            {
                string xTxt=xIdr["Busqueda"].ToString();
                if(xTxt!=string.Empty)
                {
                    xResultado  = true;
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

        public void ModificarParametro(ParametroEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(ParametroEN.RutLogEmp, pObj.RutaLogoEmpresa);
            xUpd.AsignarParametro(ParametroEN.RutImaExi, pObj.RutaImagenExistencia);
            xUpd.AsignarParametro(ParametroEN.PorIgv, pObj.PorcentajeIgv.ToString());
            xUpd.AsignarParametro(ParametroEN.NomSol, pObj.NombreSoles);
            xUpd.AsignarParametro(ParametroEN.NomDol, pObj.NombreDolares);
            xUpd.AsignarParametro(ParametroEN.TipOpeTraIng, pObj.TipoOperacionTransferenciaIngreso);
            xUpd.AsignarParametro(ParametroEN.TipOpeTraSal, pObj.TipoOperacionTransferenciaSalida);
            xUpd.AsignarParametro(ParametroEN.TipOpeProSal, pObj.TipoOperacionProduccionSalida);
            xUpd.AsignarParametro(ParametroEN.TipOpeProIng, pObj.TipoOperacionProduccionIngreso);
            xUpd.AsignarParametro(ParametroEN.CenCosPro, pObj.CentroCostoProduccion);
            xUpd.AsignarParametro(ParametroEN.TipOpeComMig, pObj.TipoOperacionCompraMigracion);
            xUpd.AsignarParametro(ParametroEN.TipOpeImpMig, pObj.TipoOperacionImportacionMigracion);
            xUpd.AsignarParametro(ParametroEN.TipOpeIngMig, pObj.TipoOperacionIngresoMigracion);
            xUpd.AsignarParametro(ParametroEN.TipOpeSalMig, pObj.TipoOperacionSalidaMigracion);
            xUpd.AsignarParametro(ParametroEN.TipOpeIngAju, pObj.TipoOperacionIngresoAjuste);
            xUpd.AsignarParametro(ParametroEN.TipOpeSalAju, pObj.TipoOperacionSalidaAjuste);
            xUpd.AsignarParametro(ParametroEN.TipOpeIngDevPro, pObj.TipoOperacionIngresoDevolucionProduccion);
            xUpd.AsignarParametro(ParametroEN.TipOpeSalNoPas, pObj.TipoOperacionSalidaNoPasan);
            xUpd.AsignarParametro(ParametroEN.CorEnv, pObj.CorreoEnvio);
            xUpd.AsignarParametro(ParametroEN.ClaCorEnv, pObj.ClaveCorreoEnvio);
            xUpd.AsignarParametro(ParametroEN.HostCorEnv, pObj.HostCorreoEnvio);
            xUpd.AsignarParametro(ParametroEN.PueCorEnv, pObj.PuertoCorreoEnvio);
            xUpd.AsignarParametro(ParametroEN.RutCarPla, pObj.RutaCarpetaPlantillas);
            xUpd.AsignarParametro(ParametroEN.RutRec, pObj.RutaRecibos);
            xUpd.AsignarParametro(ParametroEN.RutPlaRec, pObj.RutaPlantillaRecibo);
            xUpd.AsignarParametro(ParametroEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(ParametroEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public ParametroEN BuscarParametro()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        #endregion





    }
}
