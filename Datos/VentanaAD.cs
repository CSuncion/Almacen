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
    public class VentanaAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<VentanaEN> xLista = new List<VentanaEN>();
        private VentanaEN xObj = new VentanaEN();
        private string xTabla = "Ventana";
        private string xVista = "VsVentana";


        #region Metodos privados

        private VentanaEN Objeto(IDataReader iDr)
        {
            VentanaEN xObjEnc = new VentanaEN();
            xObjEnc.CodigoVentana = iDr[VentanaEN.CodVen].ToString();
            xObjEnc.NombreVentana = iDr[VentanaEN.NomVen].ToString();
            xObjEnc.NombreControlVentana = iDr[VentanaEN.NomConVen].ToString();
            xObjEnc.CEstadoVentana = iDr[VentanaEN.CEstVen].ToString();
            xObjEnc.NEstadoVentana = iDr[VentanaEN.NEstVen].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.CodigoVentana;
            return xObjEnc;
        }

        private List<VentanaEN> ListarObjetos(string pScript)
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

        private VentanaEN BuscarObjeto(string pScript)
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


        public bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumna, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumna, SqlSelect.Operador.Igual, pValor);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(VentanaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, VentanaEN.CodVen);          
            return this.ObtenerValor(xSel.ObtenerScript());
        }

        public void AgregarVentana(VentanaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(VentanaEN.CodVen, pObj.CodigoVentana);
            xIns.AsignarParametro(VentanaEN.NomVen, pObj.NombreVentana);
            xIns.AsignarParametro(VentanaEN.NomConVen, pObj.NombreControlVentana);
            xIns.AsignarParametro(VentanaEN.CEstVen, pObj.CEstadoVentana);
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarVentana(VentanaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(VentanaEN.NomVen, pObj.NombreVentana);
            xUpd.AsignarParametro(VentanaEN.NomConVen, pObj.NombreControlVentana);
            xUpd.AsignarParametro(VentanaEN.CEstVen, pObj.CEstadoVentana);
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarVentana(VentanaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<VentanaEN> ListarVentanas(VentanaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public VentanaEN BuscarVentanaXCodigo(VentanaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, VentanaEN.CodVen, SqlSelect.Operador.Igual, pObj.CodigoVentana);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }


    }
}
