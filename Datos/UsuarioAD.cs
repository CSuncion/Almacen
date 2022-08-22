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
using System.IO;

namespace Datos
{
    public class UsuarioAD
    {

        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<UsuarioEN> xLista = new List<UsuarioEN>( );
        private UsuarioEN xObj = new UsuarioEN( );
        private string xTabla = "Usuario";
        private string xVista = "VsUsuario";


      #region Metodos privados

        private UsuarioEN Objeto( IDataReader iDr )
        {
            UsuarioEN xObjEnc = new UsuarioEN( );           
            xObjEnc.CodigoUsuario = iDr[UsuarioEN.CodUsu].ToString( );
            xObjEnc.NombreUsuario = iDr[UsuarioEN.NomUsu].ToString( );
            xObjEnc.ClaveUsuario = iDr[UsuarioEN.ClaUsu].ToString( );
            xObjEnc.DireccionUsuario = iDr[UsuarioEN.DirUsu].ToString( );
            xObjEnc.FotoUsuario = iDr[UsuarioEN.FotUsu].ToString( );
            xObjEnc.CorreoUsuario = iDr[UsuarioEN.CorUsu].ToString( );
            xObjEnc.CodigoPerfil = iDr[UsuarioEN.CodPer].ToString( );
            xObjEnc.NombrePerfil = iDr[UsuarioEN.NomPer].ToString( );
            xObjEnc.CEstadoUsuario = iDr[UsuarioEN.CEstUsu].ToString( );
            xObjEnc.NEstadoUsuario = iDr[UsuarioEN.NEstUsu].ToString( );
            xObjEnc.TelFijoUsuario = iDr[UsuarioEN.TelFijUsu].ToString();
            xObjEnc.TelCelularUsuario = iDr[UsuarioEN.TelCelUsu].ToString();
            xObjEnc.CodigoPersonal = iDr[UsuarioEN.CodPrs].ToString();
            xObjEnc.UsuarioAgrega = iDr[UsuarioEN.UsuAgr].ToString( );
            xObjEnc.FechaAgrega = Convert.ToDateTime( iDr[UsuarioEN.FecAgr] );
            xObjEnc.UsuarioModifica = iDr[UsuarioEN.UsuMod].ToString( );
            xObjEnc.FechaModifica = Convert.ToDateTime( iDr[UsuarioEN.FecMod] );
            xObjEnc.ClaveObjeto = iDr[UsuarioEN.CodUsu].ToString( );
            return xObjEnc;                                    
        }


        private List<UsuarioEN> ListarObjetos( string pScript )
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
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


        private UsuarioEN BuscarObjeto( string pScript )
        {
            xObjCon.Conectar( SqlDatos.Bd.Almacen_Produccion );
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
            xObjCon.Conectar( SqlDatos.Bd.Almacen_Produccion );
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

      
        public UsuarioEN EsAccesibleSistema( UsuarioEN pObj )
        {
            UsuarioEN xUsuEN = new UsuarioEN( );
            try
            {
                xUsuEN = this.BuscarUsuarioXCodigo( pObj );
                //si no hay error entonces mandamos el objeto
                xUsuEN.Adicionales.EsVerdad = true;
                return xUsuEN;
            }
            catch ( Exception ex )
            {

                xUsuEN.Adicionales.EsVerdad = false;
                xUsuEN.Adicionales.Mensaje = ex.Message;
                return xUsuEN;
            }
            finally
            {
                xObjCon.Desconectar( );
            }

        }
        
        public bool ExisteValorEnColumna( string pColumna , string pValor )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.BuscarOcurrencia( this.xTabla , pColumna , "Busqueda" );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , pColumna , SqlSelect.Operador.Igual , pValor );
            return this.ExisteObjeto( xSel.ObtenerScript() );
        }
        
        public void AgregarUsuario( UsuarioEN pObj )
        {
            xObjCon.Conectar( SqlDatos.Bd.Almacen_Produccion );
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert( );
            xIns.Tabla( this.xTabla );
            xIns.AsignarParametro( UsuarioEN.CodUsu , pObj.CodigoUsuario );
            xIns.AsignarParametro( UsuarioEN.NomUsu , pObj.NombreUsuario );
            xIns.AsignarParametro( UsuarioEN.ClaUsu , pObj.ClaveUsuario );
            xIns.AsignarParametro( UsuarioEN.DirUsu , pObj.DireccionUsuario );
            xIns.AsignarParametro( UsuarioEN.FotUsu , pObj.FotoUsuario );
            xIns.AsignarParametro( UsuarioEN.CorUsu , pObj.CorreoUsuario );
            xIns.AsignarParametro( UsuarioEN.CodPer , pObj.CodigoPerfil );                       
            xIns.AsignarParametro( UsuarioEN.CEstUsu , pObj.CEstadoUsuario );
            xIns.AsignarParametro( UsuarioEN.TelFijUsu, pObj.TelFijoUsuario);
            xIns.AsignarParametro( UsuarioEN.TelCelUsu, pObj.TelCelularUsuario);
            xIns.AsignarParametro( UsuarioEN.CodPrs, pObj.CodigoPersonal);
            xIns.AsignarParametro( UsuarioEN.UsuAgr , Universal.gCodigoUsuario );
            xIns.AsignarParametro( UsuarioEN.FecAgr , "FECHAHORA" );
            xIns.AsignarParametro( UsuarioEN.UsuMod , Universal.gCodigoUsuario );
            xIns.AsignarParametro( UsuarioEN.FecMod , "FECHAHORA" );
            xIns.FinParametros( );

            xObjCon.ComandoTexto( xIns.ObtenerScript( ) );
            xObjCon.EjecutarSinResultado( );
            xObjCon.Desconectar( );
        }
        
        public void ModificarUsuario( UsuarioEN pObj )
        {
            xObjCon.Conectar( SqlDatos.Bd.Almacen_Produccion );
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate( );
            xUpd.Tabla( this.xTabla );
            xUpd.AsignarParametro( UsuarioEN.NomUsu , pObj.NombreUsuario );
            xUpd.AsignarParametro( UsuarioEN.ClaUsu , pObj.ClaveUsuario );
            xUpd.AsignarParametro( UsuarioEN.DirUsu , pObj.DireccionUsuario );
            xUpd.AsignarParametro( UsuarioEN.FotUsu , pObj.FotoUsuario );
            xUpd.AsignarParametro( UsuarioEN.CorUsu , pObj.CorreoUsuario );
            xUpd.AsignarParametro( UsuarioEN.CodPer , pObj.CodigoPerfil );            
            xUpd.AsignarParametro( UsuarioEN.CEstUsu , pObj.CEstadoUsuario );           
            xUpd.AsignarParametro( UsuarioEN.TelFijUsu , pObj.TelFijoUsuario );
            xUpd.AsignarParametro( UsuarioEN.TelCelUsu , pObj.TelCelularUsuario );
            xUpd.AsignarParametro( UsuarioEN.CodPrs, pObj.CodigoPersonal);
            xUpd.AsignarParametro( UsuarioEN.UsuMod , Universal.gCodigoUsuario );
            xUpd.AsignarParametro( UsuarioEN.FecMod , "FECHAHORA" );
            xUpd.FinParametros( );

            //condicion
            SqlSelect xSel=new SqlSelect();
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , UsuarioEN.CodUsu , SqlSelect.Operador.Igual , pObj.CodigoUsuario );
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        
        public void EliminarUsuario( UsuarioEN pObj )
        {
            xObjCon.Conectar( SqlDatos.Bd.Almacen_Produccion );
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete( );
            xDel.Tabla( this.xTabla );

            //condicion
            SqlSelect xSel = new SqlSelect( );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , UsuarioEN.CodUsu , SqlSelect.Operador.Igual , pObj.CodigoUsuario );
            xDel.CondicionDelete( xSel.ObtenerScript( ) );
            
            xObjCon.ComandoTexto( xDel.ObtenerScript( ) );
            xObjCon.EjecutarSinResultado( );
            xObjCon.Desconectar( );
        }
        
        public List<UsuarioEN> ListarUsuarios( UsuarioEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );        
        }
        
        public List<UsuarioEN> ListarUsuariosXEstado( UsuarioEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , UsuarioEN.CEstUsu , SqlSelect.Operador.Igual , pObj.CEstadoUsuario );
            xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );
        }
        
        public List<UsuarioEN> ListarUsuariosXEstadoYNoAdministradores( UsuarioEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , UsuarioEN.CEstUsu , SqlSelect.Operador.Igual , pObj.CEstadoUsuario );
            xSel.CondicionCV( SqlSelect.Reservada.Y , UsuarioEN.CodPer , SqlSelect.Operador.Diferente , "01" ); //01 : es administrador
            xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );
        }
        
        public List<UsuarioEN> ListarUsuariosYNoAdministradores( UsuarioEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );            
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , UsuarioEN.CodPer , SqlSelect.Operador.Diferente , "01" ); //01 : es administrador
            xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );
        }
        
        public List<UsuarioEN> ListarUsuariosXPerfilXEstado( UsuarioEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , UsuarioEN.CEstUsu , SqlSelect.Operador.Igual , pObj.CEstadoUsuario );
            xSel.CondicionCV( SqlSelect.Reservada.Y , UsuarioEN.CodPer , SqlSelect.Operador.Igual , pObj.CodigoPerfil );
            xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );
        }
        
        public UsuarioEN BuscarUsuarioXCodigo( UsuarioEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , UsuarioEN.CodUsu , SqlSelect.Operador.Igual , pObj.CodigoUsuario );
            return this.BuscarObjeto( xSel.ObtenerScript( ) );
        }
        
        public UsuarioEN BuscarUsuarioXCodigoXEstado( UsuarioEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , UsuarioEN.CodUsu , SqlSelect.Operador.Igual , pObj.CodigoUsuario );
            xSel.CondicionCV( SqlSelect.Reservada.Y , UsuarioEN.CEstUsu , SqlSelect.Operador.Igual , pObj.CEstadoUsuario );
            return this.BuscarObjeto( xSel.ObtenerScript( ) );
        }
        
        public void GenerarCopiaSeguridad(string pNombreBD, string pRutaArchivo)
        {
            //Cadena 
            string wCadena = "BackUp_" + DateTime.Today.Year.ToString() + "_" + DateTime.Today.Month.ToString() + "_" + DateTime.Today.Day.ToString();

            //conectar bd master
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //script manual
            string iScript = string.Empty;

            //armando el comando
            iScript += "Backup DataBase " + pNombreBD;
            iScript += " To Disk ='" + Path.Combine(pRutaArchivo, pNombreBD) + "_" + wCadena;
            iScript += ".Bak'";

            //ejecutar el comando
            xObjCon.ComandoTexto(iScript);
            xObjCon.EjecutarSinResultado();

            //desconecta
            xObjCon.Desconectar();
        }


    }
}
