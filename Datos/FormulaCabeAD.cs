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
    public class FormulaCabeAD
    {
        
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<FormulaCabeEN> xLista = new List<FormulaCabeEN>();
        private FormulaCabeEN xObj = new FormulaCabeEN();
        private string xTabla = "FormulaCabe";
        private string xVista = "VsFormulaCabe";


        #region Metodos privados

        private FormulaCabeEN Objeto(IDataReader iDr)
        {
            FormulaCabeEN xObjEnc = new FormulaCabeEN();
            xObjEnc.ClaveFormulaCabe = iDr[FormulaCabeEN.ClaForCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[FormulaCabeEN.CodEmp].ToString();          
            xObjEnc.CodigoAlmacen = iDr[FormulaCabeEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[FormulaCabeEN.DesAlm].ToString();
            xObjEnc.CodigoExistencia = iDr[FormulaCabeEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[FormulaCabeEN.DesExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[FormulaCabeEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[FormulaCabeEN.NomUniMed].ToString();           
            xObjEnc.Comentario = iDr[FormulaCabeEN.Coment].ToString();           
            xObjEnc.MasaUnidad = Convert.ToDecimal(iDr[FormulaCabeEN.MasUni].ToString());           
            xObjEnc.RatioFormulaCabe = Convert.ToDecimal(iDr[FormulaCabeEN.RatForCab].ToString());            
            xObjEnc.CodigoAlmacenSemiProducto = iDr[FormulaCabeEN.CodAlmSemPro].ToString();
            xObjEnc.DescripcionAlmacenSemiProducto = iDr[FormulaCabeEN.DesAlmSemPro].ToString();
            xObjEnc.CodigoSemiProducto = iDr[FormulaCabeEN.CodSemPro].ToString();
            xObjEnc.DescripcionExistenciaSemiProducto = iDr[FormulaCabeEN.DesExiSemPro].ToString();
            xObjEnc.CodigoUnidadMedidaSemiProducto = iDr[FormulaCabeEN.CodUniMedSemPro].ToString();
            xObjEnc.NombreUnidadMedidaSemiProducto = iDr[FormulaCabeEN.NomUniMedSemPro].ToString();
            xObjEnc.CodigoAlmacenEmpaquetado = iDr[FormulaCabeEN.CodAlmEmp].ToString();
            xObjEnc.DescripcionAlmacenEmpaquetado = iDr[FormulaCabeEN.DesAlmEmp].ToString();
            xObjEnc.NumeroDiasVctoFormulaCabe = Convert.ToDecimal(iDr[FormulaCabeEN.NumDiaVctoForCab].ToString());
            xObjEnc.CManejaCuarentena = iDr[FormulaCabeEN.CManCua].ToString();
            xObjEnc.NManejaCuarentena = iDr[FormulaCabeEN.NManCua].ToString();
            xObjEnc.CEstadoFormulaCabe = iDr[FormulaCabeEN.CEstForCab].ToString();
            xObjEnc.NEstadoFormulaCabe = iDr[FormulaCabeEN.NEstForCab].ToString();
            xObjEnc.UsuarioAgrega = iDr[FormulaCabeEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[FormulaCabeEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[FormulaCabeEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[FormulaCabeEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveFormulaCabe;
            return xObjEnc;
        }

        private List<FormulaCabeEN> ListarObjetos(string pScript)
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

        private FormulaCabeEN BuscarObjeto(string pScript)
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

        public void AdicionarFormulaCabe(FormulaCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(FormulaCabeEN.ClaForCab, pObj.ClaveFormulaCabe);
            xIns.AsignarParametro(FormulaCabeEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(FormulaCabeEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(FormulaCabeEN.CodExi, pObj.CodigoExistencia);            
            xIns.AsignarParametro(FormulaCabeEN.Coment, pObj.Comentario);            
            xIns.AsignarParametro(FormulaCabeEN.MasUni, pObj.MasaUnidad.ToString());           
            xIns.AsignarParametro(FormulaCabeEN.RatForCab, pObj.RatioFormulaCabe.ToString());           
            xIns.AsignarParametro(FormulaCabeEN.CodAlmSemPro, pObj.CodigoAlmacenSemiProducto);
            xIns.AsignarParametro(FormulaCabeEN.CodSemPro, pObj.CodigoSemiProducto);
            xIns.AsignarParametro(FormulaCabeEN.CodAlmEmp, pObj.CodigoAlmacenEmpaquetado);
            xIns.AsignarParametro(FormulaCabeEN.NumDiaVctoForCab, pObj.NumeroDiasVctoFormulaCabe.ToString());
            xIns.AsignarParametro(FormulaCabeEN.CManCua, pObj.CManejaCuarentena);
            xIns.AsignarParametro(FormulaCabeEN.CEstForCab, pObj.CEstadoFormulaCabe);
            xIns.AsignarParametro(FormulaCabeEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(FormulaCabeEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(FormulaCabeEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(FormulaCabeEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarFormulaCabe(FormulaCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);              
            xUpd.AsignarParametro(FormulaCabeEN.Coment, pObj.Comentario);
            xUpd.AsignarParametro(FormulaCabeEN.MasUni, pObj.MasaUnidad.ToString());            
            xUpd.AsignarParametro(FormulaCabeEN.RatForCab, pObj.RatioFormulaCabe.ToString());
            xUpd.AsignarParametro(FormulaCabeEN.CodAlmSemPro, pObj.CodigoAlmacenSemiProducto);
            xUpd.AsignarParametro(FormulaCabeEN.CodSemPro, pObj.CodigoSemiProducto);
            xUpd.AsignarParametro(FormulaCabeEN.CodAlmEmp, pObj.CodigoAlmacenEmpaquetado);           
            xUpd.AsignarParametro(FormulaCabeEN.NumDiaVctoForCab, pObj.NumeroDiasVctoFormulaCabe.ToString());
            xUpd.AsignarParametro(FormulaCabeEN.CManCua, pObj.CManejaCuarentena);
            xUpd.AsignarParametro(FormulaCabeEN.CEstForCab, pObj.CEstadoFormulaCabe);
            xUpd.AsignarParametro(FormulaCabeEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(FormulaCabeEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaCabeEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            //ejecutar comando
            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarFormulaCabe(FormulaCabeEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaCabeEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }    

        public FormulaCabeEN BuscarFormulaCabeXClave(FormulaCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaCabeEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            return this.BuscarObjeto(xSel.ObtenerScript());          
        }

        public List<FormulaCabeEN> ListarFormulaCabe(FormulaCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormulaCabeEN> ListarFormulaCabeEnAlmacen(FormulaCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormulaCabeEN> ListarFormulaCabeActivasEnAlmacen(FormulaCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaCabeEN.CodAlm, SqlSelect.Operador.Igual, pObj.CodigoAlmacen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaCabeEN.CEstForCab, SqlSelect.Operador.Igual, "1");//activo
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public FormulaCabeEN BuscarFormulaCabeXCodigoSemiProducto(FormulaCabeEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaCabeEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaCabeEN.CodAlmSemPro, SqlSelect.Operador.Igual, pObj.CodigoAlmacenSemiProducto);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaCabeEN.CodSemPro, SqlSelect.Operador.Igual, pObj.CodigoSemiProducto);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

    }
}
