using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Datos.Config;

namespace Datos
{
    public class BotonAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<BotonEN> xLista = new List<BotonEN>();
        private BotonEN xObj = new BotonEN();
        private string xTabla = "Boton";
        private string xVista = "VsBoton";


        #region Metodos privados

        private BotonEN Objeto(IDataReader iDr)
        {
            BotonEN xObjEnc = new BotonEN();
            xObjEnc.CodigoBoton = iDr[BotonEN.CodBot].ToString();
            xObjEnc.NombreBoton = iDr[BotonEN.NomBot].ToString();
            xObjEnc.NombreControl = iDr[BotonEN.NomCon].ToString();
            xObjEnc.CValidaGrilla = iDr[BotonEN.CValGri].ToString();
            xObjEnc.CEstadoBoton = iDr[BotonEN.CEstBot].ToString();
            xObjEnc.NEstadoBoton = iDr[BotonEN.NEstBot].ToString();          
            xObjEnc.ClaveObjeto = xObjEnc.CodigoBoton;
            return xObjEnc;
        }
        
        private List<BotonEN> ListarObjetos(string pScript)
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
        
        private BotonEN BuscarObjeto(string pScript)
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
        
        public void AgregarBoton(BotonEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(BotonEN.CodBot, pObj.CodigoBoton);
            xIns.AsignarParametro(BotonEN.NomBot, pObj.NombreBoton);
            xIns.AsignarParametro(BotonEN.NomCon, pObj.NombreControl);
            xIns.AsignarParametro(BotonEN.CValGri, pObj.CValidaGrilla);   
            xIns.AsignarParametro(BotonEN.CEstBot, pObj.CEstadoBoton);         
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarBoton(BotonEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(BotonEN.NomBot, pObj.NombreBoton);
            xUpd.AsignarParametro(BotonEN.NomCon, pObj.NombreControl);
            xUpd.AsignarParametro(BotonEN.CValGri, pObj.CValidaGrilla);   
            xUpd.AsignarParametro(BotonEN.CEstBot, pObj.CEstadoBoton);           
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BotonEN.CodBot, SqlSelect.Operador.Igual, pObj.CodigoBoton);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarBoton(BotonEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BotonEN.CodBot, SqlSelect.Operador.Igual, pObj.CodigoBoton);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<BotonEN> ListarBoton(BotonEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        
        public BotonEN BuscarBotonXCodigo(BotonEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, BotonEN.CodBot, SqlSelect.Operador.Igual, pObj.CodigoBoton);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }


    }
}
