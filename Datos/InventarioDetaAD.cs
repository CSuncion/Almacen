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

    public class InventarioDetaAD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<InventarioDetaEN> xLista = new List<InventarioDetaEN>();
        private InventarioDetaEN xObj = new InventarioDetaEN();
        private string xTabla = "InventarioDeta";
        private string xVista = "VsInventarioDeta";

        #endregion
        
        #region Metodos privados

        private InventarioDetaEN Objeto(IDataReader iDr)
        {
            InventarioDetaEN xObjEnc = new InventarioDetaEN();
            xObjEnc.ClaveInventarioDeta = iDr[InventarioDetaEN.ClaInvDet].ToString();
            xObjEnc.ClaveInventarioCabe = iDr[InventarioDetaEN.ClaInvCab].ToString();
            xObjEnc.CodigoEmpresa = iDr[InventarioDetaEN.CodEmp].ToString();
            xObjEnc.CodigoAlmacen = iDr[InventarioDetaEN.CodAlm].ToString();           
            xObjEnc.DescripcionAlmacen = iDr[InventarioDetaEN.DesAlm].ToString();
            xObjEnc.CorrelativoInventarioCabe = iDr[InventarioDetaEN.CorInvCab].ToString();
            xObjEnc.CodigoExistencia = iDr[InventarioDetaEN.CodExi].ToString();
            xObjEnc.DescripcionExistencia = iDr[InventarioDetaEN.DesExi].ToString();
            xObjEnc.CodigoUnidadMedida = iDr[InventarioDetaEN.CodUniMed].ToString();
            //xObjEnc.UbicacionExistencia = iDr[InventarioDetaEN.UbiExi].ToString();
            xObjEnc.StockFisico = Convert.ToDecimal( iDr[InventarioDetaEN.StoFis].ToString());
            xObjEnc.StockTeorico = Convert.ToDecimal(iDr[InventarioDetaEN.StoTeo].ToString());
            xObjEnc.DiferenciaStock = Convert.ToDecimal(iDr[InventarioDetaEN.DifSto].ToString());
            xObjEnc.CEstadoInventarioDeta = iDr[InventarioDetaEN.CEstInvDet].ToString();
            xObjEnc.NEstadoInventarioDeta = iDr[InventarioDetaEN.NEstInvDet].ToString();
            xObjEnc.UsuarioAgrega = iDr[InventarioDetaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[InventarioDetaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[InventarioDetaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[InventarioDetaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveInventarioDeta;
            return xObjEnc;
        }
        
        private List<InventarioDetaEN> ListarObjetos(string pScript)
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
        
        private InventarioDetaEN BuscarObjeto(string pScript)
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
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.BuscarOcurrencia(this.xTabla, pColumnaBusqueda, "Busqueda");
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaCondicion1, SqlSelect.Operador.Igual, pValorCondicion1);
            xSel.CondicionCV(SqlSelect.Reservada.Y, pColumnaBusqueda, SqlSelect.Operador.Igual, pValorBusqueda);
            return this.ExisteObjeto(xSel.ObtenerScript());
        }

        public void AgregarInventarioDeta(InventarioDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(InventarioDetaEN.ClaInvDet, pObj.ClaveInventarioDeta);
            xIns.AsignarParametro(InventarioDetaEN.ClaInvCab, pObj.ClaveInventarioCabe);
            xIns.AsignarParametro(InventarioDetaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(InventarioDetaEN.CodAlm, pObj.CodigoAlmacen);
            xIns.AsignarParametro(InventarioDetaEN.CorInvCab, pObj.CorrelativoInventarioCabe);            
            xIns.AsignarParametro(InventarioDetaEN.CodExi, pObj.CodigoExistencia);
            xIns.AsignarParametro(InventarioDetaEN.StoFis, pObj.StockFisico.ToString());
            xIns.AsignarParametro(InventarioDetaEN.StoTeo, pObj.StockTeorico.ToString());
            xIns.AsignarParametro(InventarioDetaEN.DifSto, pObj.DiferenciaStock.ToString());
            xIns.AsignarParametro(InventarioDetaEN.CEstInvDet, pObj.CEstadoInventarioDeta);
            xIns.AsignarParametro(InventarioDetaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(InventarioDetaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(InventarioDetaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(InventarioDetaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AgregarInventarioDeta(List<InventarioDetaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (InventarioDetaEN xInvDet in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(InventarioDetaEN.ClaInvDet, xInvDet.ClaveInventarioDeta);
                xIns.AsignarParametro(InventarioDetaEN.ClaInvCab, xInvDet.ClaveInventarioCabe);
                xIns.AsignarParametro(InventarioDetaEN.CodEmp, xInvDet.CodigoEmpresa);
                xIns.AsignarParametro(InventarioDetaEN.CodAlm, xInvDet.CodigoAlmacen);
                xIns.AsignarParametro(InventarioDetaEN.CorInvCab, xInvDet.CorrelativoInventarioCabe);
                xIns.AsignarParametro(InventarioDetaEN.CodExi, xInvDet.CodigoExistencia);
                xIns.AsignarParametro(InventarioDetaEN.StoFis, xInvDet.StockFisico.ToString());
                xIns.AsignarParametro(InventarioDetaEN.StoTeo, xInvDet.StockTeorico.ToString());
                xIns.AsignarParametro(InventarioDetaEN.DifSto, xInvDet.DiferenciaStock.ToString());
                xIns.AsignarParametro(InventarioDetaEN.CEstInvDet, xInvDet.CEstadoInventarioDeta);
                xIns.AsignarParametro(InventarioDetaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(InventarioDetaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(InventarioDetaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(InventarioDetaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarInventarioDeta(InventarioDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);              
            xUpd.AsignarParametro(InventarioDetaEN.StoFis, pObj.StockFisico.ToString());
            xUpd.AsignarParametro(InventarioDetaEN.StoTeo, pObj.StockTeorico.ToString());
            xUpd.AsignarParametro(InventarioDetaEN.DifSto, pObj.DiferenciaStock.ToString());
            xUpd.AsignarParametro(InventarioDetaEN.CEstInvDet, pObj.CEstadoInventarioDeta);
            xUpd.AsignarParametro(InventarioDetaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(InventarioDetaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvDet, SqlSelect.Operador.Igual, pObj.ClaveInventarioDeta);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarInventarioDeta(InventarioDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvDet, SqlSelect.Operador.Igual, pObj.ClaveInventarioDeta);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarInventarioDetaXClaveInventarioCabe(InventarioDetaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<InventarioDetaEN> ListarInventarioDetas(InventarioDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public InventarioDetaEN BuscarInventarioDetaXClave(InventarioDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvDet, SqlSelect.Operador.Igual, pObj.ClaveInventarioDeta);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<InventarioDetaEN> ListarInventarioDetasParaTomaInventario(InventarioDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, InventarioDetaEN.CodExi, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<InventarioDetaEN> ListarInventarioDetasXClaveInventarioCabe(InventarioDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<InventarioDetaEN> ListarInventarioDetasParaDiferenciaStock(InventarioDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, InventarioDetaEN.CodExi, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, InventarioDetaEN.DifSto, SqlSelect.Operador.Diferente, "0");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<InventarioDetaEN> ListarInventarioDetasParaAjusteIngreso(InventarioDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, InventarioDetaEN.DifSto, SqlSelect.Operador.Mayor, "0");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<InventarioDetaEN> ListarInventarioDetasParaAjusteSalida(InventarioDetaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, InventarioDetaEN.ClaInvCab, SqlSelect.Operador.Igual, pObj.ClaveInventarioCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, InventarioDetaEN.DifSto, SqlSelect.Operador.Menor, "0");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        #endregion

    }
}
