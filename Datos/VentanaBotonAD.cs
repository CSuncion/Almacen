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
    public class VentanaBotonAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<VentanaBotonEN> xLista = new List<VentanaBotonEN>();
        private VentanaBotonEN xObj = new VentanaBotonEN();
        private string xTabla = "VentanaBoton";
        private string xVista = "VsVentanaBoton";


        #region Metodos privados

        private VentanaBotonEN Objeto(IDataReader iDr)
        {
            VentanaBotonEN xObjEnc = new VentanaBotonEN();
            xObjEnc.ClaveVentanaBoton = iDr[VentanaBotonEN.ClaVenBot].ToString();          
            xObjEnc.CodigoVentana = iDr[VentanaBotonEN.CodVen].ToString();
            xObjEnc.NombreVentana = iDr[VentanaBotonEN.NomVen].ToString();
            xObjEnc.CodigoBoton = iDr[VentanaBotonEN.CodBot].ToString();
            xObjEnc.NombreBoton = iDr[VentanaBotonEN.NomBot].ToString();
            xObjEnc.CEstadoVentanaBoton = iDr[VentanaBotonEN.CEstVenBot].ToString();
            xObjEnc.NEstadoVentanaBoton = iDr[VentanaBotonEN.NEstVenBot].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.ClaveVentanaBoton;
            return xObjEnc;
        }
        
        private List<VentanaBotonEN> ListarObjetos(string pScript)
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
        
        private VentanaBotonEN BuscarObjeto(string pScript)
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
        
        public void AgregarVentanaBoton(VentanaBotonEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(VentanaBotonEN.ClaVenBot, pObj.ClaveVentanaBoton);          
            xIns.AsignarParametro(VentanaBotonEN.CodVen, pObj.CodigoVentana);
            xIns.AsignarParametro(VentanaBotonEN.CodBot, pObj.CodigoBoton);
            xIns.AsignarParametro(VentanaBotonEN.CEstVenBot, pObj.CEstadoVentanaBoton);            
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarVentanaBotonMasivo( List<VentanaBotonEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (VentanaBotonEN xVenBot in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(VentanaBotonEN.ClaVenBot, xVenBot.ClaveVentanaBoton );                
                xIns.AsignarParametro(VentanaBotonEN.CodVen, xVenBot.CodigoVentana);
                xIns.AsignarParametro(VentanaBotonEN.CodBot, xVenBot.CodigoBoton);
                xIns.AsignarParametro(VentanaBotonEN.CEstVenBot, xVenBot.CEstadoVentanaBoton);
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();                
            }            
            xObjCon.Desconectar();
        }

        public void ModificarVentanaBoton(VentanaBotonEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(VentanaBotonEN.CEstVenBot, pObj.CEstadoVentanaBoton);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaBotonEN.ClaVenBot, SqlSelect.Operador.Igual, pObj.ClaveVentanaBoton);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarVentanaBoton(VentanaBotonEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaBotonEN.ClaVenBot, SqlSelect.Operador.Igual, pObj.ClaveVentanaBoton);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarVentanaBotonXVentana(VentanaBotonEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();           
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaBotonEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarVentanaBotonMasivo( List<VentanaBotonEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (VentanaBotonEN xVenBot in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaBotonEN.ClaVenBot, SqlSelect.Operador.Igual, xVenBot.ClaveVentanaBoton);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();                
            }            
            xObjCon.Desconectar();
        }

        public List<VentanaBotonEN> ListarVentanaBotones(VentanaBotonEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<VentanaBotonEN> ListarVentanaBotonesXVentana(VentanaBotonEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaBotonEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
        
        public VentanaBotonEN BuscarVentanaBotonXClave(VentanaBotonEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaBotonEN.ClaVenBot, SqlSelect.Operador.Igual, pObj.ClaveVentanaBoton);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }


    }
}
