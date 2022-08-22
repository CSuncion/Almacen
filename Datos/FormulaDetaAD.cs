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

    public class FormulaDetaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<FormulaDetaEN> xLista = new List<FormulaDetaEN>();
        private FormulaDetaEN xObj = new FormulaDetaEN();
        private string xTabla = "FormulaDeta";
        private string xVista = "VsFormulaDeta";

        #endregion
        
        #region Metodos privados

        private FormulaDetaEN Objeto(IDataReader iDr)
        {
            FormulaDetaEN xObjEnc = new FormulaDetaEN();
            xObjEnc.ClaveFormulaDeta = iDr[FormulaDetaEN.ClaForDet].ToString();
            xObjEnc.ClaveFormulaCabe = iDr[FormulaDetaEN.ClaForCab].ToString();
            xObjEnc.CodigoExistenciaFormula = iDr[FormulaDetaEN.CodExiFor].ToString();
            xObjEnc.DescripcionExistenciaFormula = iDr[FormulaDetaEN.DesExiFor].ToString();
            xObjEnc.CodigoAlmacenSemiProducto = iDr[FormulaDetaEN.CodAlmSemPro].ToString();
            xObjEnc.CodigoSemiProducto = iDr[FormulaDetaEN.CodSemPro].ToString();
            xObjEnc.RatioFormulaCabe = Convert.ToDecimal(iDr[FormulaDetaEN.RatForCab].ToString());
            xObjEnc.NumeroDiasVctoFormulaCabe = Convert.ToDecimal(iDr[FormulaDetaEN.NumDiaVctoForCab].ToString());
            xObjEnc.MasaUnidad = Convert.ToDecimal(iDr[FormulaDetaEN.MasUni].ToString());
            xObjEnc.CorrelativoFormulaDeta = iDr[FormulaDetaEN.CorForDet].ToString();
            xObjEnc.CodigoEmpresa = iDr[FormulaDetaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[FormulaDetaEN.NomEmp].ToString();          
            xObjEnc.CodigoAlmacen = iDr[FormulaDetaEN.CodAlm].ToString();
            xObjEnc.DescripcionAlmacen = iDr[FormulaDetaEN.DesAlm].ToString();                  
            xObjEnc.CodigoExistencia = iDr[FormulaDetaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[FormulaDetaEN.DesExi].ToString();
            xObjEnc.PrecioPromedioExistencia = Convert.ToDecimal(iDr[FormulaDetaEN.PreProExi].ToString());
            xObjEnc.CodigoUnidadMedida = iDr[FormulaDetaEN.CodUniMed].ToString();
            xObjEnc.NombreUnidadMedida = iDr[FormulaDetaEN.NomUniMed].ToString();
            xObjEnc.CantidadFormulaDeta = Convert.ToDecimal(iDr[FormulaDetaEN.CanForDet].ToString());
            xObjEnc.CantidadCajaFormulaDeta = Convert.ToDecimal(iDr[FormulaDetaEN.CanCajForDet].ToString());
            xObjEnc.CTipoDescarga = iDr[FormulaDetaEN.CTipDes].ToString();
            xObjEnc.NTipoDescarga = iDr[FormulaDetaEN.NTipDes].ToString();
            xObjEnc.CTipoFactor = iDr[FormulaDetaEN.CTipFac].ToString();
            xObjEnc.NTipoFactor = iDr[FormulaDetaEN.NTipFac].ToString();
            xObjEnc.CodigoAlmacenProTer = iDr[FormulaDetaEN.CodAlmProTer].ToString();
            xObjEnc.DescripcionAlmacenProTer = iDr[FormulaDetaEN.DesAlmProTer].ToString();
            xObjEnc.CodigoExistenciaProTer = iDr[FormulaDetaEN.CodExiProTer].ToString();
            xObjEnc.DescripcionExistenciaProTer = iDr[FormulaDetaEN.DesExiProTer].ToString();
            xObjEnc.CodigoUnidadMedidaProTer = iDr[FormulaDetaEN.CodUniMedProTer].ToString();
            xObjEnc.NombreUnidadMedidaProTer = iDr[FormulaDetaEN.NomUniMedProTer].ToString();
            xObjEnc.CodigoAlmacenOrigen = iDr[FormulaDetaEN.CodAlmOri].ToString();
            xObjEnc.DescripcionAlmacenOrigen = iDr[FormulaDetaEN.DesAlmOri].ToString();
            xObjEnc.CodigoAlmacenCompra = iDr[FormulaDetaEN.CodAlmCom].ToString();
            xObjEnc.DescripcionAlmacenCompra = iDr[FormulaDetaEN.DesAlmCom].ToString();
            xObjEnc.CPrimeraLiberacion = iDr[FormulaDetaEN.CPriLib].ToString();
            xObjEnc.NPrimeraLiberacion = iDr[FormulaDetaEN.NPriLib].ToString();
            xObjEnc.CSegundaLiberacion = iDr[FormulaDetaEN.CSegLib].ToString();
            xObjEnc.NSegundaLiberacion = iDr[FormulaDetaEN.NSegLib].ToString();
            xObjEnc.CEstadoFormulaDeta = iDr[FormulaDetaEN.CEstForDet].ToString();
            xObjEnc.NEstadoFormulaDeta = iDr[FormulaDetaEN.NEstForDet].ToString();
            xObjEnc.UsuarioAgrega = iDr[FormulaDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[FormulaDetaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[FormulaDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[FormulaDetaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveFormulaDeta;
            return xObjEnc;
        }
        
        private List<FormulaDetaEN> ListarObjetos(string pScript)
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
        
        private FormulaDetaEN BuscarObjeto(string pScript)
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

        public void AgregarFormulaDeta(FormulaDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(FormulaDetaEN.ClaForDet, pObj.ClaveFormulaDeta);
            xIns.AsignarParametro(FormulaDetaEN.ClaForCab, pObj.ClaveFormulaCabe);
            xIns.AsignarParametro(FormulaDetaEN.CorForDet, pObj.CorrelativoFormulaDeta);
            xIns.AsignarParametro(FormulaDetaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(FormulaDetaEN.CodAlm, pObj.CodigoAlmacen);         
            xIns.AsignarParametro(FormulaDetaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(FormulaDetaEN.CanForDet, pObj.CantidadFormulaDeta.ToString());
            xIns.AsignarParametro(FormulaDetaEN.CanCajForDet, pObj.CantidadCajaFormulaDeta.ToString());
            xIns.AsignarParametro(FormulaDetaEN.CTipDes, pObj.CTipoDescarga);
            xIns.AsignarParametro(FormulaDetaEN.CTipFac, pObj.CTipoFactor);
            xIns.AsignarParametro(FormulaDetaEN.CodAlmProTer, pObj.CodigoAlmacenProTer);
            xIns.AsignarParametro(FormulaDetaEN.CodExiProTer, pObj.CodigoExistenciaProTer);
            xIns.AsignarParametro(FormulaDetaEN.CodAlmOri, pObj.CodigoAlmacenOrigen);
            xIns.AsignarParametro(FormulaDetaEN.CodAlmCom, pObj.CodigoAlmacenCompra);
            xIns.AsignarParametro(FormulaDetaEN.CPriLib, pObj.CPrimeraLiberacion);
            xIns.AsignarParametro(FormulaDetaEN.CSegLib, pObj.CSegundaLiberacion);
            xIns.AsignarParametro(FormulaDetaEN.CEstForDet, pObj.CEstadoFormulaDeta);
            xIns.AsignarParametro(FormulaDetaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(FormulaDetaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(FormulaDetaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(FormulaDetaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarFormulaDeta(List< FormulaDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(FormulaDetaEN.ClaForDet, xForDet.ClaveFormulaDeta);
                xIns.AsignarParametro(FormulaDetaEN.ClaForCab, xForDet.ClaveFormulaCabe);
                xIns.AsignarParametro(FormulaDetaEN.CorForDet, xForDet.CorrelativoFormulaDeta);
                xIns.AsignarParametro(FormulaDetaEN.CodEmp, xForDet.CodigoEmpresa);
                xIns.AsignarParametro(FormulaDetaEN.CodAlm, xForDet.CodigoAlmacen);               
                xIns.AsignarParametro(FormulaDetaEN.CodExi, xForDet.CodigoExistencia);
                xIns.AsignarParametro(FormulaDetaEN.CanForDet, xForDet.CantidadFormulaDeta.ToString());
                xIns.AsignarParametro(FormulaDetaEN.CanCajForDet, xForDet.CantidadCajaFormulaDeta.ToString());
                xIns.AsignarParametro(FormulaDetaEN.CTipDes, xForDet.CTipoDescarga);
                xIns.AsignarParametro(FormulaDetaEN.CTipFac, xForDet.CTipoFactor);
                xIns.AsignarParametro(FormulaDetaEN.CodAlmProTer, xForDet.CodigoAlmacenProTer);
                xIns.AsignarParametro(FormulaDetaEN.CodExiProTer, xForDet.CodigoExistenciaProTer);
                xIns.AsignarParametro(FormulaDetaEN.CodAlmOri, xForDet.CodigoAlmacenOrigen);
                xIns.AsignarParametro(FormulaDetaEN.CodAlmCom, xForDet.CodigoAlmacenCompra);
                xIns.AsignarParametro(FormulaDetaEN.CPriLib, xForDet.CPrimeraLiberacion);
                xIns.AsignarParametro(FormulaDetaEN.CSegLib, xForDet.CSegundaLiberacion);
                xIns.AsignarParametro(FormulaDetaEN.CEstForDet, xForDet.CEstadoFormulaDeta);
                xIns.AsignarParametro(FormulaDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(FormulaDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(FormulaDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(FormulaDetaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }            
            xObjCon.Desconectar();
        }

        public void ModificarFormulaDeta(FormulaDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);           
            xUpd.AsignarParametro(FormulaDetaEN.CodExi, pObj.CodigoExistencia);           
            xUpd.AsignarParametro(FormulaDetaEN.CanForDet, pObj.CantidadFormulaDeta.ToString());
            xUpd.AsignarParametro(FormulaDetaEN.CanCajForDet, pObj.CantidadCajaFormulaDeta.ToString());
            xUpd.AsignarParametro(FormulaDetaEN.CTipDes, pObj.CTipoDescarga);
            xUpd.AsignarParametro(FormulaDetaEN.CTipFac, pObj.CTipoFactor);
            xUpd.AsignarParametro(FormulaDetaEN.CodAlmProTer, pObj.CodigoAlmacenProTer);
            xUpd.AsignarParametro(FormulaDetaEN.CodExiProTer, pObj.CodigoExistenciaProTer);
            xUpd.AsignarParametro(FormulaDetaEN.CodAlmOri, pObj.CodigoAlmacenOrigen);
            xUpd.AsignarParametro(FormulaDetaEN.CodAlmCom, pObj.CodigoAlmacenCompra);
            xUpd.AsignarParametro(FormulaDetaEN.CPriLib, pObj.CPrimeraLiberacion);
            xUpd.AsignarParametro(FormulaDetaEN.CSegLib, pObj.CSegundaLiberacion);
            xUpd.AsignarParametro(FormulaDetaEN.CEstForDet, pObj.CEstadoFormulaDeta);
            xUpd.AsignarParametro(FormulaDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(FormulaDetaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForDet, SqlSelect.Operador.Igual, pObj.ClaveFormulaDeta);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarFormulaDeta(List< FormulaDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(FormulaDetaEN.CodExi, xForDet.CodigoExistencia);               
                xUpd.AsignarParametro(FormulaDetaEN.CanForDet, xForDet.CantidadFormulaDeta.ToString());
                xUpd.AsignarParametro(FormulaDetaEN.CanCajForDet, xForDet.CantidadCajaFormulaDeta.ToString());
                xUpd.AsignarParametro(FormulaDetaEN.CTipDes, xForDet.CTipoDescarga);
                xUpd.AsignarParametro(FormulaDetaEN.CTipFac, xForDet.CTipoFactor);
                xUpd.AsignarParametro(FormulaDetaEN.CodAlmProTer, xForDet.CodigoAlmacenProTer);
                xUpd.AsignarParametro(FormulaDetaEN.CodExiProTer, xForDet.CodigoExistenciaProTer);
                xUpd.AsignarParametro(FormulaDetaEN.CodAlmOri, xForDet.CodigoAlmacenOrigen);
                xUpd.AsignarParametro(FormulaDetaEN.CodAlmCom, xForDet.CodigoAlmacenCompra);
                xUpd.AsignarParametro(FormulaDetaEN.CPriLib, xForDet.CPrimeraLiberacion);
                xUpd.AsignarParametro(FormulaDetaEN.CSegLib, xForDet.CSegundaLiberacion);
                xUpd.AsignarParametro(FormulaDetaEN.CEstForDet, xForDet.CEstadoFormulaDeta);
                xUpd.AsignarParametro(FormulaDetaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(FormulaDetaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForDet, SqlSelect.Operador.Igual, xForDet.ClaveFormulaDeta);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void EliminarFormulaDeta(FormulaDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForDet, SqlSelect.Operador.Igual, pObj.ClaveFormulaDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarFormulaDetaXFormulaCabe(FormulaDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<FormulaDetaEN> ListarFormulaDetas(FormulaDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public FormulaDetaEN BuscarFormulaDetaXClave(FormulaDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForDet, SqlSelect.Operador.Igual, pObj.ClaveFormulaDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabe(FormulaDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(FormulaDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CTipDes, SqlSelect.Operador.Igual, pObj.CTipoDescarga);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public FormulaDetaEN BuscarFormulaDetaXClaveFormulaCabeYCodigoExistencia(FormulaDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CodExi, SqlSelect.Operador.Igual, pObj.CodigoExistencia);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public FormulaDetaEN BuscarFormulaDetaXProductoTerminado(FormulaDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CodAlmProTer, SqlSelect.Operador.Igual, pObj.CodigoAlmacenProTer);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CodExiProTer, SqlSelect.Operador.Igual, pObj.CodigoExistenciaProTer);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<FormulaDetaEN> ListarFormulasDetaConCodigoExistenciaProTer()
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CodExiProTer, SqlSelect.Operador.Diferente, string.Empty);
            xSel.Ordenar(FormulaDetaEN.ClaForDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabeYEstado(FormulaDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.ClaForCab, SqlSelect.Operador.Igual, pObj.ClaveFormulaCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CEstForDet, SqlSelect.Operador.Igual, pObj.CEstadoFormulaDeta);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormulaDetaEN> ListarFormulasDetaDeCodigosExistencia(string pCodExi)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionINx(SqlSelect.Reservada.Y, FormulaDetaEN.CodExi, pCodExi);
            xSel.Ordenar(FormulaDetaEN.ClaForDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<FormulaDetaEN> ListarFormulasDetaDeCodigoExistenciaProTerYDiferenteClaveFormulaCabe(FormulaDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, FormulaDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.ClaForCab, SqlSelect.Operador.Diferente, pObj.ClaveFormulaCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, FormulaDetaEN.CodExiProTer, SqlSelect.Operador.Igual, pObj.CodigoExistenciaProTer);
            xSel.Ordenar(FormulaDetaEN.ClaForDet, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
