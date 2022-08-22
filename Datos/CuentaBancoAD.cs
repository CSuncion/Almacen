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
    public class CuentaBancoAD
    {


        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<CuentaBancoEN> xLista = new List<CuentaBancoEN>();
        private CuentaBancoEN xObj = new CuentaBancoEN();
        private string xTabla = "CuentaBanco";
        private string xVista = "VsCuentaBanco";


        #region Metodos privados

        private CuentaBancoEN Objeto(IDataReader iDr)
        {
            CuentaBancoEN xObjEnc = new CuentaBancoEN();
            xObjEnc.ClaveCuentaBanco = iDr[CuentaBancoEN.ClaCtaBco].ToString();
            xObjEnc.CodigoEmpresa = iDr[CuentaBancoEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[CuentaBancoEN.NomEmp].ToString();
            xObjEnc.CodigoCuentaBanco = iDr[CuentaBancoEN.CodCtaBco].ToString();
            xObjEnc.CodigoBanco = iDr[CuentaBancoEN.CodBco].ToString();
            xObjEnc.NombreBanco = iDr[CuentaBancoEN.NomBco].ToString();
            xObjEnc.AgenciaCuentaBanco = iDr[CuentaBancoEN.AgeCtaBco].ToString();
            xObjEnc.NumeroCuentaBanco = iDr[CuentaBancoEN.NumCtaBco].ToString();
            xObjEnc.ClaveCuentaBancaria = iDr[CuentaBancoEN.ClaCtaBan].ToString();
            xObjEnc.NumeroCuentaBancaria = iDr[CuentaBancoEN.NumCtaBan].ToString();
            xObjEnc.MonedaCuentaBanco = iDr[CuentaBancoEN.MonCtaBco].ToString();
            xObjEnc.NMonedaCuentaBanco = iDr[CuentaBancoEN.NMonCtaBco].ToString();
            xObjEnc.TipoCuentaBanco = iDr[CuentaBancoEN.TipCtaBco].ToString();
            xObjEnc.SaldoCuentaBanco = Convert.ToDecimal(iDr[CuentaBancoEN.SalCtaBco].ToString());
            xObjEnc.EstadoCuentaBanco = iDr[CuentaBancoEN.EstCtaBco].ToString();
            xObjEnc.NEstadoCuentaBanco = iDr[CuentaBancoEN.NEstCtaBco].ToString();
            xObjEnc.CuentaContable = iDr[CuentaBancoEN.CtaCon].ToString();
            xObjEnc.ConceptoEnvio = iDr[CuentaBancoEN.ConEnv].ToString();
            xObjEnc.CuentaScotiaCuentaBanco = iDr[CuentaBancoEN.CtaScoCtaBco].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveCuentaBanco;
            return xObjEnc;
        }
        
        private List<CuentaBancoEN> ListarObjetos(string pScript)
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
        
        private CuentaBancoEN BuscarObjeto(string pScript)
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

        public void AdicionarCuentaBanco(CuentaBancoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(CuentaBancoEN.ClaCtaBco, pObj.ClaveCuentaBanco);
            xIns.AsignarParametro(CuentaBancoEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(CuentaBancoEN.CodCtaBco, pObj.CodigoCuentaBanco);
            xIns.AsignarParametro(CuentaBancoEN.CodBco, pObj.CodigoBanco);
            xIns.AsignarParametro(CuentaBancoEN.AgeCtaBco, pObj.AgenciaCuentaBanco);
            xIns.AsignarParametro(CuentaBancoEN.NumCtaBco, pObj.NumeroCuentaBanco);
            xIns.AsignarParametro(CuentaBancoEN.ClaCtaBan, pObj.ClaveCuentaBancaria);
            xIns.AsignarParametro(CuentaBancoEN.NumCtaBan, pObj.NumeroCuentaBancaria);
            xIns.AsignarParametro(CuentaBancoEN.MonCtaBco, pObj.MonedaCuentaBanco);
            xIns.AsignarParametro(CuentaBancoEN.TipCtaBco, pObj.TipoCuentaBanco);
            xIns.AsignarParametro(CuentaBancoEN.SalCtaBco, pObj.SaldoCuentaBanco.ToString());
            xIns.AsignarParametro(CuentaBancoEN.EstCtaBco, pObj.EstadoCuentaBanco);
            xIns.AsignarParametro(CuentaBancoEN.CtaCon, pObj.CuentaContable);
            xIns.AsignarParametro(CuentaBancoEN.ConEnv, pObj.ConceptoEnvio);
            xIns.AsignarParametro(CuentaBancoEN.CtaScoCtaBco, pObj.CuentaScotiaCuentaBanco);
            xIns.AsignarParametro(CuentaBancoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CuentaBancoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(CuentaBancoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CuentaBancoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarCuentaBanco(CuentaBancoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);

            xUpd.AsignarParametro(CuentaBancoEN.CodBco, pObj.CodigoBanco);
            xUpd.AsignarParametro(CuentaBancoEN.AgeCtaBco, pObj.AgenciaCuentaBanco);
            xUpd.AsignarParametro(CuentaBancoEN.NumCtaBco, pObj.NumeroCuentaBanco);
            xUpd.AsignarParametro(CuentaBancoEN.ClaCtaBan, pObj.ClaveCuentaBancaria);
            xUpd.AsignarParametro(CuentaBancoEN.NumCtaBan, pObj.NumeroCuentaBancaria);            
            xUpd.AsignarParametro(CuentaBancoEN.MonCtaBco, pObj.MonedaCuentaBanco);
            xUpd.AsignarParametro(CuentaBancoEN.TipCtaBco, pObj.TipoCuentaBanco);
            xUpd.AsignarParametro(CuentaBancoEN.SalCtaBco, pObj.SaldoCuentaBanco.ToString());
            xUpd.AsignarParametro(CuentaBancoEN.EstCtaBco, pObj.EstadoCuentaBanco);
            xUpd.AsignarParametro(CuentaBancoEN.CtaCon, pObj.CuentaContable);
            xUpd.AsignarParametro(CuentaBancoEN.ConEnv, pObj.ConceptoEnvio);
            xUpd.AsignarParametro(CuentaBancoEN.CtaScoCtaBco, pObj.CuentaScotiaCuentaBanco);
            xUpd.AsignarParametro(CuentaBancoEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(CuentaBancoEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.ClaCtaBco, SqlSelect.Operador.Igual, pObj.ClaveCuentaBanco);

            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        
        public void EliminarCuentaBancoXClave(CuentaBancoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.ClaCtaBco, SqlSelect.Operador.Igual, pObj.ClaveCuentaBanco);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<CuentaBancoEN> ListarCuentaBancos(CuentaBancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuentaBancoEN> ListarCuentaBancoXEmpresa(CuentaBancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
                
        public CuentaBancoEN BuscarCuentaBancoXClave(CuentaBancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.ClaCtaBco, SqlSelect.Operador.Igual, pObj.ClaveCuentaBanco);

            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public CuentaBancoEN BuscarCuentaBancoXNumero( CuentaBancoEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando, CuentaBancoEN.NumCtaBco, SqlSelect.Operador.Igual, pObj.NumeroCuentaBanco );
            return this.BuscarObjeto( xSel.ObtenerScript( ) );
        }

        public List<CuentaBancoEN> ListarCuentaBancoActivos(CuentaBancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuentaBancoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuentaBancoEN.EstCtaBco, SqlSelect.Operador.Igual, "1"); 
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

            
    
    }
}
