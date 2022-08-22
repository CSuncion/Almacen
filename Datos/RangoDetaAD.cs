using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ScriptBD;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Datos.Config;
using Comun;

namespace Datos
{

    public class RangoDetaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<RangoDetaEN> xLista = new List<RangoDetaEN>();
        private RangoDetaEN xObj = new RangoDetaEN();
        private string xTabla = "RangoDeta";
        private string xVista = "VsRangoDeta";

        #endregion
        
        #region Metodos privados

        private RangoDetaEN Objeto(IDataReader iDr)
        {
            RangoDetaEN xObjEnc = new RangoDetaEN();
            xObjEnc.ClaveRangoDeta = iDr[RangoDetaEN.ClaRanDet].ToString();
            xObjEnc.ClaveFormulaCabe = iDr[RangoDetaEN.ClaForCab].ToString();
            //xObjEnc.CodigoExistenciaFormula = iDr[RangoDetaEN.CodExiFor].ToString();
            //xObjEnc.DescripcionExistenciaFormula = iDr[RangoDetaEN.DesExiFor].ToString();           
            xObjEnc.CodigoEmpresa = iDr[RangoDetaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[RangoDetaEN.NomEmp].ToString();          
            xObjEnc.CodigoAlmacen = iDr[RangoDetaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[RangoDetaEN.DesAlm].ToString();                  
            xObjEnc.CodigoExistencia = iDr[RangoDetaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[RangoDetaEN.DesExi].ToString();
            xObjEnc.PrecioPromedioExistencia = Convert.ToDecimal(iDr[RangoDetaEN.PreProExi].ToString());
            xObjEnc.CodigoUnidadMedida = iDr[RangoDetaEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[RangoDetaEN.NomUniMed].ToString();
            xObjEnc.CorrelativoRangoDeta = iDr[RangoDetaEN.CorRanDet].ToString();          
            xObjEnc.CTipoDescarga = iDr[RangoDetaEN.CTipDes].ToString();
            xObjEnc.NTipoDescarga = iDr[RangoDetaEN.NTipDes].ToString();
            xObjEnc.CTipoFactor = iDr[RangoDetaEN.CTipFac].ToString();
            xObjEnc.NTipoFactor = iDr[RangoDetaEN.NTipFac].ToString();
            xObjEnc.NumeroInicioRangoDeta = Convert.ToDecimal(iDr[RangoDetaEN.NumIniRanDet].ToString());
            xObjEnc.NumeroFinalRangoDeta = Convert.ToDecimal(iDr[RangoDetaEN.NumFinRanDet].ToString());
            xObjEnc.PorcentajeRangoDeta = Convert.ToDecimal(iDr[RangoDetaEN.PorRanDet].ToString());
            xObjEnc.CEstadoRangoDeta = iDr[RangoDetaEN.CEstRanDet].ToString();
            xObjEnc.NEstadoRangoDeta = iDr[RangoDetaEN.NEstRanDet].ToString();
            xObjEnc.UsuarioAgrega = iDr[RangoDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RangoDetaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[RangoDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RangoDetaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRangoDeta;
            return xObjEnc;
        }
        
        private List<RangoDetaEN> ListarObjetos(string pScript)
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
        
        private RangoDetaEN BuscarObjeto(string pScript)
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

        #region Metodos publicos

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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarRangoDeta(RangoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(RangoDetaEN.ClaRanDet, pObj.ClaveRangoDeta);
            xIns.AsignarParametro(RangoDetaEN.ClaForCab, pObj.ClaveFormulaCabe);            
            xIns.AsignarParametro(RangoDetaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(RangoDetaEN.CodAlm, pObj.CodigoAlmacen);            
            xIns.AsignarParametro(RangoDetaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(RangoDetaEN.CorRanDet, pObj.CorrelativoRangoDeta);            
            xIns.AsignarParametro(RangoDetaEN.CTipDes, pObj.CTipoDescarga);
            xIns.AsignarParametro(RangoDetaEN.CTipFac, pObj.CTipoFactor);
            xIns.AsignarParametro(RangoDetaEN.NumIniRanDet, pObj.NumeroInicioRangoDeta.ToString());
            xIns.AsignarParametro(RangoDetaEN.NumFinRanDet, pObj.NumeroFinalRangoDeta.ToString());
            xIns.AsignarParametro(RangoDetaEN.PorRanDet, pObj.PorcentajeRangoDeta.ToString());          
            xIns.AsignarParametro(RangoDetaEN.CEstRanDet, pObj.CEstadoRangoDeta);
            xIns.AsignarParametro(RangoDetaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(RangoDetaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(RangoDetaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(RangoDetaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarRangoDeta(List<RangoDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (RangoDetaEN xForDet in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(RangoDetaEN.ClaRanDet, xForDet.ClaveRangoDeta);
                xIns.AsignarParametro(RangoDetaEN.ClaForCab, xForDet.ClaveFormulaCabe);                
                xIns.AsignarParametro(RangoDetaEN.CodEmp, xForDet.CodigoEmpresa);
                xIns.AsignarParametro(RangoDetaEN.CodAlm, xForDet.CodigoAlmacen);               
                xIns.AsignarParametro(RangoDetaEN.CodExi, xForDet.CodigoExistencia);
                xIns.AsignarParametro(RangoDetaEN.CorRanDet, xForDet.CorrelativoRangoDeta);                
                xIns.AsignarParametro(RangoDetaEN.CTipDes, xForDet.CTipoDescarga);
                xIns.AsignarParametro(RangoDetaEN.CTipFac, xForDet.CTipoFactor);
                xIns.AsignarParametro(RangoDetaEN.NumIniRanDet, xForDet.NumeroInicioRangoDeta.ToString());
                xIns.AsignarParametro(RangoDetaEN.NumFinRanDet, xForDet.NumeroFinalRangoDeta.ToString());
                xIns.AsignarParametro(RangoDetaEN.PorRanDet, xForDet.PorcentajeRangoDeta.ToString());
                xIns.AsignarParametro(RangoDetaEN.CEstRanDet, xForDet.CEstadoRangoDeta);
                xIns.AsignarParametro(RangoDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RangoDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(RangoDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(RangoDetaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }            
            xObjCon.Desconectar();
        }

        public void ModificarRangoDeta(RangoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);           
            //xUpd.AsignarParametro(FormulaDetaEN.CodExi, pObj.CodigoExistencia);           
            xUpd.AsignarParametro(RangoDetaEN.NumIniRanDet, pObj.NumeroInicioRangoDeta.ToString());
            xUpd.AsignarParametro(RangoDetaEN.NumFinRanDet, pObj.NumeroFinalRangoDeta.ToString());
            xUpd.AsignarParametro(RangoDetaEN.PorRanDet, pObj.PorcentajeRangoDeta.ToString());
            xUpd.AsignarParametro(RangoDetaEN.CTipDes, pObj.CTipoDescarga);
            xUpd.AsignarParametro(RangoDetaEN.CTipFac, pObj.CTipoFactor);
            xUpd.AsignarParametro(RangoDetaEN.CEstRanDet, pObj.CEstadoRangoDeta);
            xUpd.AsignarParametro(RangoDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(RangoDetaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaRanDet, SqlSelect.Operador.Igual, pObj.ClaveRangoDeta);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarRangoDeta(List<RangoDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (RangoDetaEN xForDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(RangoDetaEN.CodExi, xForDet.CodigoExistencia);               
                xUpd.AsignarParametro(RangoDetaEN.NumIniRanDet, xForDet.NumeroInicioRangoDeta.ToString());
                xUpd.AsignarParametro(RangoDetaEN.NumFinRanDet, xForDet.NumeroFinalRangoDeta.ToString());
                xUpd.AsignarParametro(RangoDetaEN.PorRanDet, xForDet.PorcentajeRangoDeta.ToString());
                xUpd.AsignarParametro(RangoDetaEN.CTipDes, xForDet.CTipoDescarga);
                xUpd.AsignarParametro(RangoDetaEN.CTipFac, xForDet.CTipoFactor);                
                xUpd.AsignarParametro(RangoDetaEN.CEstRanDet, xForDet.CEstadoRangoDeta);
                xUpd.AsignarParametro(RangoDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(RangoDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaRanDet, SqlSelect.Operador.Igual, xForDet.ClaveRangoDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void EliminarRangoDeta(RangoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaRanDet, SqlSelect.Operador.Igual, pObj.ClaveRangoDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarRangoDetaXRangoCabe(RangoDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<RangoDetaEN> ListarRangoDetas(RangoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public RangoDetaEN BuscarRangoDetaXClave(RangoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaRanDet, SqlSelect.Operador.Igual, pObj.ClaveRangoDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<RangoDetaEN> ListarRangosDetaXClaveRangoCabe(RangoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<RangoDetaEN> ListarRangosDetaXClaveRangoCabeYTipoDescarga(RangoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RangoDetaEN.CTipDes, SqlSelect.Operador.Igual, pObj.CTipoDescarga);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public RangoDetaEN BuscarRangoDetaXClaveRangoCabeYCodigoExistencia(RangoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RangoDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public RangoDetaEN BuscarRangoDetaXProductoTerminado(RangoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CodAlmProTer, SqlSelect.Operador.Igual, pObj.CodigoAlmacenProTer);
            //xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CodExiProTer, SqlSelect.Operador.Igual, pObj.CodigoExistenciaProTer);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        //public List<FormulaDetaEN> ListarFormulasDetaConCodigoExistenciaProTer()
        //{
        //    SqlSelect xSel = new SqlSelect();
        //    xSel.SeleccionaVista(this.xVista);
        //    xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
        //    xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CodExiProTer, SqlSelect.Operador.Diferente, string.Empty);
        //    xSel.Ordenar(FormulaDetaEN.ClaForDet, SqlSelect.Orden.Asc);
        //    return this.ListarObjetos(xSel.ObtenerScript());
        //}

        public List<RangoDetaEN> ListarRangosDetaXClaveRangoCabeYEstado(RangoDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RangoDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RangoDetaEN.CEstRanDet, SqlSelect.Operador.Igual, pObj.CEstadoRangoDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, pColumnaBusqueda);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            return this.ObtenerValor(xSel.ObtenerScript());
        }














        #endregion

    }
}
