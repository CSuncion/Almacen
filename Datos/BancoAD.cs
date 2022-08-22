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
    public class BancoAD
    {
        
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<BancoEN> xLista = new List<BancoEN>();
        private BancoEN xObj = new BancoEN();
        private string xTabla = "Banco";
        private string xVista = "VsBanco";


        #region Metodos privados

        private BancoEN Objeto(IDataReader iDr)
        {
            BancoEN xObjEnc = new BancoEN();
            xObjEnc.CodigoBanco = iDr[BancoEN.CodBco].ToString();
            xObjEnc.NombreBanco = iDr[BancoEN.NomBco].ToString();
            xObjEnc.CodigoSunat = iDr[BancoEN.CodSun].ToString();
            xObjEnc.CEstadoBanco = iDr[BancoEN.CEstBco].ToString();
            xObjEnc.NEstadoBanco = iDr[BancoEN.NEstBco].ToString();
            //xObjEnc.CRecaudaBanco = iDr[BancoEN.CRecBco].ToString( );
            //xObjEnc.NRecaudaBanco = iDr[BancoEN.NRecBco].ToString( );
            xObjEnc.UsuarioAgrega = iDr[BancoEN.UsuAgr].ToString( );
            xObjEnc.FechaAgrega = Convert.ToDateTime( iDr[BancoEN.FecAgr] );
            xObjEnc.UsuarioModifica = iDr[BancoEN.UsuMod].ToString( );
            xObjEnc.FechaModifica = Convert.ToDateTime( iDr[BancoEN.FecMod] );
            xObjEnc.ClaveObjeto = xObjEnc.CodigoBanco;
            return xObjEnc;
        }
        
        private List<BancoEN> ListarObjetos(string pScript)
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
        
        private BancoEN BuscarObjeto(string pScript)
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


        public void AdicionarBanco(BancoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(BancoEN.CodBco, pObj.CodigoBanco);
            xIns.AsignarParametro(BancoEN.NomBco, pObj.NombreBanco);
            xIns.AsignarParametro(BancoEN.CodSun, pObj.CodigoSunat);
            xIns.AsignarParametro(BancoEN.CEstBco, pObj.CEstadoBanco);
            xIns.AsignarParametro(BancoEN.CRecBco , pObj.CRecaudaBanco );
            xIns.AsignarParametro(BancoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(BancoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(BancoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(BancoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void ModificarBanco(BancoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);

            xUpd.AsignarParametro(BancoEN.NomBco, pObj.NombreBanco);
            xUpd.AsignarParametro(BancoEN.CodSun, pObj.CodigoSunat);
            xUpd.AsignarParametro(BancoEN.CEstBco, pObj.CEstadoBanco);
            xUpd.AsignarParametro( BancoEN.CRecBco , pObj.CRecaudaBanco );
            xUpd.AsignarParametro(BancoEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(BancoEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BancoEN.CodBco, SqlSelect.Operador.Igual, pObj.CodigoBanco);

            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        public void EliminarBancoXCodigo(BancoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BancoEN.CodBco, SqlSelect.Operador.Igual, pObj.CodigoBanco);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }


        //public List<BancoEN> ListarBancos(BancoEN pObj)
        //{
        //    SqlSelect xSel = new SqlSelect();
        //    xSel.SeleccionaVista(this.xVista);
        //    xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
        //    return this.ListarObjetos(xSel.ObtenerScript());
        //}


        public List<BancoEN> ListarBancoXCodigo(BancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BancoEN.CodBco, SqlSelect.Operador.Igual, pObj.CodigoBanco);
        
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


        public BancoEN BuscarBancoXCodigo(BancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BancoEN.CodBco, SqlSelect.Operador.Igual, pObj.CodigoBanco);

            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<BancoEN> ListarBancosActivos(BancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BancoEN.CEstBco, SqlSelect.Operador.Igual, "1"); //activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


        public List<BancoEN> ListarBancosActivosParaRecaudacion( BancoEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , BancoEN.CEstBco , SqlSelect.Operador.Igual , "1" ); //activo
            xSel.CondicionCV( SqlSelect.Reservada.Y , BancoEN.CRecBco , SqlSelect.Operador.Igual , "1" ); //si es de recaudacion
            xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );
        }

        public List<BancoEN> ListarBancos(BancoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }       
            
    
    }
}
