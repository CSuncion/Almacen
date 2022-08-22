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
    public class RangoCabeAD
    {
        
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<RangoCabeEN> xLista = new List<RangoCabeEN>();
        private RangoCabeEN xObj = new RangoCabeEN();
        private string xTabla = "RangoCabe";
        private string xVista = "VsRangoCabe";


        #region Metodos privados

        private RangoCabeEN Objeto(IDataReader iDr)
        {
            RangoCabeEN xObjEnc = new RangoCabeEN();
            xObjEnc.ClaveRangoCabe = iDr[RangoCabeEN.ClaRanCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[RangoCabeEN.CodEmp].ToString();          
            xObjEnc.CodigoAlmacen = iDr[RangoCabeEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[RangoCabeEN.DesAlm].ToString();
            xObjEnc.CodigoExistencia = iDr[RangoCabeEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[RangoCabeEN.DesExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[RangoCabeEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[RangoCabeEN.NomUniMed].ToString();           
            xObjEnc.Comentario = iDr[RangoCabeEN.Coment].ToString(); 
            xObjEnc.CEstadoRangoCabe = iDr[RangoCabeEN.CEstRanCab].ToString();
            xObjEnc.NEstadoRangoCabe = iDr[RangoCabeEN.NEstRanCab].ToString();
            xObjEnc.UsuarioAgrega = iDr[RangoCabeEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RangoCabeEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[RangoCabeEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RangoCabeEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRangoCabe;
            return xObjEnc;
        }

        private List<RangoCabeEN> ListarObjetos(string pScript)
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

        private RangoCabeEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, MovimientoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AdicionarRangoCabe(RangoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(RangoCabeEN.ClaRanCab, pObj.ClaveRangoCabe);
            xIns.AsignarParametro(RangoCabeEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(RangoCabeEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(RangoCabeEN.CodExi, pObj.CodigoExistencia);            
            xIns.AsignarParametro(RangoCabeEN.Coment, pObj.Comentario); 
            xIns.AsignarParametro(RangoCabeEN.CEstRanCab, pObj.CEstadoRangoCabe);
            xIns.AsignarParametro(RangoCabeEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(RangoCabeEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(RangoCabeEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(RangoCabeEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarRangoCabe(RangoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);              
            xUpd.AsignarParametro(RangoCabeEN.Coment, pObj.Comentario); 
            xUpd.AsignarParametro(RangoCabeEN.CEstRanCab, pObj.CEstadoRangoCabe);
            xUpd.AsignarParametro(RangoCabeEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(RangoCabeEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoCabeEN.ClaRanCab, SqlSelect.Operador.Igual, pObj.ClaveRangoCabe);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar comando
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarRangoCabe(RangoCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoCabeEN.ClaRanCab, SqlSelect.Operador.Igual, pObj.ClaveRangoCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }    

        public RangoCabeEN BuscarRangoCabeXClave(RangoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoCabeEN.ClaRanCab, SqlSelect.Operador.Igual, pObj.ClaveRangoCabe);
            return this.BuscarObjeto(xSel.ObtenerScript());          
        }

        public List<RangoCabeEN> ListarRangoCabe(RangoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RangoCabeEN> ListarRangoCabeEnAlmacen(RangoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RangoCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RangoCabeEN> ListarRangoCabeActivasEnAlmacen(RangoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RangoCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RangoCabeEN.CEstRanCab, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public RangoCabeEN BuscarRangoCabeXCodigoSemiProducto(RangoCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaCabeEN.CodAlmSemPro, SqlSelect.Operador.Igual, pObj.CodigoAlmacenSemiProducto);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaCabeEN.CodSemPro, SqlSelect.Operador.Igual, pObj.CodigoSemiProducto);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

    }
}
