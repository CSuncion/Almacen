using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptBD;
using Entidades.Adicionales;
using Datos.Config;
using System.Data;
using Comun;
using Entidades;




namespace Datos
{
    public class EnvioRecAD
    {


        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<EnvioRecEN> xLista = new List<EnvioRecEN>();
        private EnvioRecEN xObj = new EnvioRecEN();
        private string xTabla = "EnvioRec";
        private string xVista = "VsEnvioRec";


        #region Metodos privados

        private EnvioRecEN Objeto(IDataReader iDr)
        {
            EnvioRecEN xObjEnc = new EnvioRecEN();
            xObjEnc.ClaveEnvioRec = iDr[EnvioRecEN.ClaEnvRec].ToString();
            xObjEnc.CodigoEmpresa = iDr[EnvioRecEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[EnvioRecEN.NomEmp].ToString();
            xObjEnc.RucEmpresa = iDr[EnvioRecEN.RucEmp].ToString( );
            xObjEnc.CorrelativoEnvioRec = iDr[EnvioRecEN.CorEnvRec].ToString();
            xObjEnc.ClaveCuentaBanco = iDr[EnvioRecEN.ClaCtaBco].ToString();
            xObjEnc.CodigoBanco = iDr[EnvioRecEN.CodBco].ToString();
            xObjEnc.NombreBanco = iDr[EnvioRecEN.NomBco].ToString();
            xObjEnc.NumeroCuentaBanco = iDr[EnvioRecEN.NumCtaBco].ToString();
            xObjEnc.ClaveCuentaBancaria = iDr[EnvioRecEN.ClaCtaBan].ToString();
            xObjEnc.NumeroCuentaBancaria = iDr[EnvioRecEN.NumCtaBan].ToString();
            xObjEnc.NMonedaCuentaBanco = iDr[EnvioRecEN.NMonCtaBco].ToString();
            xObjEnc.FechaEnvioRec = iDr[EnvioRecEN.FecEnvRec].ToString();
            xObjEnc.FlagEnvioRec = iDr[EnvioRecEN.FlaEnvRec].ToString();
            xObjEnc.CEstadoEnvioRec = iDr[EnvioRecEN.CEstEnvRec].ToString();
            xObjEnc.NEstadoEnvioRec = iDr[EnvioRecEN.NEstEnvRec].ToString();
            //xObjEnc.CuentaScotiaCuentaBanco = iDr[EnvioRecEN.CtaScoCtaBco].ToString();
            //xObjEnc.ConceptoEnvio = iDr[EnvioRecEN.ConEnv].ToString();
            xObjEnc.UsuarioAgrega = iDr[EnvioRecEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[EnvioRecEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[EnvioRecEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[EnvioRecEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveEnvioRec;
            return xObjEnc;
        }
        
        private List<EnvioRecEN> ListarObjetos(string pScript)
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
        
        private EnvioRecEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EnvioRecEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumna, SqlSelect.Operador.Igual, pValor);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }
        
        public void AdicionarEnvioRec(EnvioRecEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(EnvioRecEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(EnvioRecEN.CorEnvRec, pObj.CorrelativoEnvioRec);
            xIns.AsignarParametro(EnvioRecEN.ClaEnvRec, pObj.ClaveEnvioRec);
            xIns.AsignarParametro(EnvioRecEN.ClaCtaBco, pObj.ClaveCuentaBanco);
            xIns.AsignarParametro(EnvioRecEN.FecEnvRec, pObj.FechaEnvioRec);
            xIns.AsignarParametro(EnvioRecEN.FlaEnvRec, pObj.FlagEnvioRec);
            xIns.AsignarParametro(EnvioRecEN.CEstEnvRec, pObj.CEstadoEnvioRec);
            xIns.AsignarParametro(EnvioRecEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(EnvioRecEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(EnvioRecEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(EnvioRecEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
            
        }
        
        public void ModificarEnvioRec(EnvioRecEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);

            xUpd.AsignarParametro(EnvioRecEN.ClaCtaBco, pObj.ClaveCuentaBanco);
            xUpd.AsignarParametro(EnvioRecEN.FecEnvRec, pObj.FechaEnvioRec);
            xUpd.AsignarParametro(EnvioRecEN.FlaEnvRec, pObj.FlagEnvioRec);
            xUpd.AsignarParametro(EnvioRecEN.CEstEnvRec, pObj.CEstadoEnvioRec);
            xUpd.AsignarParametro(EnvioRecEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(EnvioRecEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);

            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        
        public void EliminarEnvioRecXClave(EnvioRecEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        
        public List<EnvioRecEN> ListarEnvioRec(EnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EnvioRecEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, EnvioRecEN.CEstEnvRec, SqlSelect.Operador.Igual, pObj.CEstadoEnvioRec);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
              
        public List<EnvioRecEN> ListarEnvioRecXEstado( EnvioRecEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando, EnvioRecEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa );
            xSel.CondicionCV( SqlSelect.Reservada.Y, EnvioRecEN.CEstEnvRec, SqlSelect.Operador.Igual, pObj.CEstadoEnvioRec );
            xSel.Ordenar( pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );
        }
        
        public EnvioRecEN BuscarEnvioRecXClave(EnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<EnvioRecEN> ListarEnvioRecActivos(EnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, EnvioRecEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, EnvioRecEN.CEstEnvRec, SqlSelect.Operador.Igual, "1"); //activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

            
    
    }
}
