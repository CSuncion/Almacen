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
    public class DetalleEnvioRecAD
    {


        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<DetalleEnvioRecEN> xLista = new List<DetalleEnvioRecEN>();
        private DetalleEnvioRecEN xObj = new DetalleEnvioRecEN();
        private string xTabla = "DetalleEnvioRec";
        private string xVista = "VsDetalleEnvioRec";


        #region Metodos privados

        private DetalleEnvioRecEN Objeto(IDataReader iDr)
        {
            DetalleEnvioRecEN xObjEnc = new DetalleEnvioRecEN();
            xObjEnc.ClaveDetalleEnvioRec = iDr[DetalleEnvioRecEN.ClaDetEnvRec].ToString();
            xObjEnc.ClaveEnvioRec = iDr[DetalleEnvioRecEN.ClaEnvRec].ToString();
            xObjEnc.CodigoEmpresa = iDr[DetalleEnvioRecEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[DetalleEnvioRecEN.NomEmp].ToString();
            xObjEnc.CodigoProyecto = iDr[DetalleEnvioRecEN.CodPro].ToString();
            xObjEnc.NombreProyecto = iDr[DetalleEnvioRecEN.NomPro].ToString();
            xObjEnc.CodigoUrbanizacionProyecto = iDr[DetalleEnvioRecEN.CodPro].ToString();
            xObjEnc.NombreUrbanizacionProyecto = iDr[DetalleEnvioRecEN.NomUrbPro].ToString();
            xObjEnc.CMonedaCuota = iDr[DetalleEnvioRecEN.CMonCuo].ToString();
            xObjEnc.NMonedaCuota = iDr[DetalleEnvioRecEN.NMonCuo].ToString();
            xObjEnc.ClaveCuota = iDr[DetalleEnvioRecEN.ClaCuo].ToString();
            xObjEnc.NumeroContrato = iDr[DetalleEnvioRecEN.NumCon].ToString();
            xObjEnc.CodigoCliente = iDr[DetalleEnvioRecEN.CodCli].ToString();
            xObjEnc.ApellidoPaternoCliente = iDr[DetalleEnvioRecEN.ApePatCli].ToString();
            xObjEnc.ApellidoMaternoCliente = iDr[DetalleEnvioRecEN.ApeMatCli].ToString();
            xObjEnc.PrimerNombreCliente = iDr[DetalleEnvioRecEN.PriNomCli].ToString();
            xObjEnc.SegundoNombreCliente = iDr[DetalleEnvioRecEN.SegNomCli].ToString();
            xObjEnc.NombreCliente = iDr[DetalleEnvioRecEN.NomCli].ToString();
            xObjEnc.CTipoDocumentoCliente = iDr[DetalleEnvioRecEN.CTipDocCli].ToString();
            xObjEnc.NumeroDocumentoCliente = iDr[DetalleEnvioRecEN.NumDocCli].ToString();
            xObjEnc.NombreParaBancoCliente = iDr[DetalleEnvioRecEN.NomParBanCli].ToString();
            xObjEnc.MontoPendienteCuota = Convert.ToDecimal(iDr[DetalleEnvioRecEN.MonPenCuo].ToString());
            xObjEnc.MontoMoraPendiente = Convert.ToDecimal(iDr[DetalleEnvioRecEN.MonMorPen].ToString());
            xObjEnc.FechaVencimientoCuota = Fecha.ObtenerDiaMesAno(iDr[DetalleEnvioRecEN.FecVenCuo]);
            xObjEnc.CodigoConcepto = iDr[DetalleEnvioRecEN.CodCon].ToString();
            xObjEnc.CEstadoPenalidad = iDr[DetalleEnvioRecEN.CEstPen].ToString();
            xObjEnc.NEstadoPenalidad = iDr[DetalleEnvioRecEN.NEstPen].ToString();
            xObjEnc.UsuarioAgrega = iDr[DetalleEnvioRecEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[DetalleEnvioRecEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[DetalleEnvioRecEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[DetalleEnvioRecEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveDetalleEnvioRec;
            return xObjEnc;
        }

        private List<DetalleEnvioRecEN> ListarObjetos(string pScript)
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

        private DetalleEnvioRecEN BuscarObjeto(string pScript)
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

        public void AdicionarDetalleEnvioRec(DetalleEnvioRecEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(DetalleEnvioRecEN.ClaDetEnvRec, pObj.ClaveDetalleEnvioRec);
            xIns.AsignarParametro(DetalleEnvioRecEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(DetalleEnvioRecEN.CodPro, pObj.CodigoProyecto);
            xIns.AsignarParametro(DetalleEnvioRecEN.ClaEnvRec, pObj.ClaveEnvioRec);
            xIns.AsignarParametro(DetalleEnvioRecEN.ClaCuo, pObj.ClaveCuota);
            xIns.AsignarParametro(DetalleEnvioRecEN.NumCon, pObj.NumeroContrato);
            xIns.AsignarParametro(DetalleEnvioRecEN.CodCli, pObj.CodigoCliente);
            xIns.AsignarParametro(DetalleEnvioRecEN.CMonCuo, pObj.CMonedaCuota);
            xIns.AsignarParametro(DetalleEnvioRecEN.FecVenCuo, Fecha.ObtenerAnoMesDia(pObj.FechaVencimientoCuota));
            xIns.AsignarParametro(DetalleEnvioRecEN.MonPenCuo, pObj.MontoPendienteCuota.ToString());
            xIns.AsignarParametro(DetalleEnvioRecEN.MonMorPen, pObj.MontoMoraPendiente.ToString());
            xIns.AsignarParametro(DetalleEnvioRecEN.CodCon, pObj.CodigoConcepto);
            xIns.AsignarParametro(DetalleEnvioRecEN.CEstPen, pObj.CEstadoPenalidad);
            xIns.AsignarParametro(DetalleEnvioRecEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(DetalleEnvioRecEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(DetalleEnvioRecEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(DetalleEnvioRecEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarDetalleEnvioRecMasivo(List<DetalleEnvioRecEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (DetalleEnvioRecEN xDetEnvRec in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(DetalleEnvioRecEN.ClaDetEnvRec, xDetEnvRec.ClaveDetalleEnvioRec);
                xIns.AsignarParametro(DetalleEnvioRecEN.CodEmp, xDetEnvRec.CodigoEmpresa);
                xIns.AsignarParametro(DetalleEnvioRecEN.CodPro, xDetEnvRec.CodigoProyecto);
                xIns.AsignarParametro(DetalleEnvioRecEN.ClaEnvRec, xDetEnvRec.ClaveEnvioRec);
                xIns.AsignarParametro(DetalleEnvioRecEN.ClaCuo, xDetEnvRec.ClaveCuota);
                xIns.AsignarParametro(DetalleEnvioRecEN.NumCon, xDetEnvRec.NumeroContrato);
                xIns.AsignarParametro(DetalleEnvioRecEN.CodCli, xDetEnvRec.CodigoCliente);
                xIns.AsignarParametro(DetalleEnvioRecEN.CMonCuo, xDetEnvRec.CMonedaCuota);
                xIns.AsignarParametro(DetalleEnvioRecEN.FecVenCuo, Fecha.ObtenerAnoMesDia(xDetEnvRec.FechaVencimientoCuota));
                xIns.AsignarParametro(DetalleEnvioRecEN.MonPenCuo, xDetEnvRec.MontoPendienteCuota.ToString());
                xIns.AsignarParametro(DetalleEnvioRecEN.MonMorPen, xDetEnvRec.MontoMoraPendiente.ToString());
                xIns.AsignarParametro(DetalleEnvioRecEN.CodCon, xDetEnvRec.CodigoConcepto);
                xIns.AsignarParametro(DetalleEnvioRecEN.CEstPen, xDetEnvRec.CEstadoPenalidad);
                xIns.AsignarParametro(DetalleEnvioRecEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(DetalleEnvioRecEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(DetalleEnvioRecEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(DetalleEnvioRecEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                //ejecutar comando
                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }
            xObjCon.Desconectar();
        }

        public List<List<DetalleEnvioRecEN>> ListarListasPorBloques(List<DetalleEnvioRecEN> pLista)
        {
            //lista resultado
            List<List<DetalleEnvioRecEN>> iLisRes = new List<List<DetalleEnvioRecEN>>();

            //variables
            int iContadorBloque = 0;
            int iIndiceObjeto = -1;

            //recorrer cada objeto
            foreach (DetalleEnvioRecEN xDetEnv in pLista)
            {
                if (iContadorBloque == 0)
                {
                    List<DetalleEnvioRecEN> iLisDet = new List<DetalleEnvioRecEN>();
                    iLisDet.Add(xDetEnv);
                    iLisRes.Add(iLisDet);
                    iContadorBloque++;
                    iIndiceObjeto++;
                }
                else
                {
                    iContadorBloque++;
                    if (iContadorBloque <= 500)
                    {
                        iLisRes[iIndiceObjeto].Add(xDetEnv);
                        if (iContadorBloque == 500)
                        {
                            iContadorBloque = 0;
                        }
                    }
                }
            }
            return iLisRes;
        }

        public void AdicionarDetalleEnvioRecMasivo1(List<DetalleEnvioRecEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //obtener los bloques
            List<List<DetalleEnvioRecEN>> iLisBlo = this.ListarListasPorBloques(pLista);

            //recorrer cada objeto
            foreach (List<DetalleEnvioRecEN> xLisDetRec in iLisBlo)
            {
                //script total
                StringBuilder iScriptTotal = new StringBuilder();

                //recorrer cada objeto
                foreach (DetalleEnvioRecEN xDetEnvRec in xLisDetRec)
                {
                    //armando escript para insertar
                    SqlInsert xIns = new SqlInsert();
                    xIns.Tabla(this.xTabla);
                    xIns.AsignarParametro(DetalleEnvioRecEN.ClaDetEnvRec, xDetEnvRec.ClaveDetalleEnvioRec);
                    xIns.AsignarParametro(DetalleEnvioRecEN.CodEmp, xDetEnvRec.CodigoEmpresa);
                    xIns.AsignarParametro(DetalleEnvioRecEN.CodPro, xDetEnvRec.CodigoProyecto);
                    xIns.AsignarParametro(DetalleEnvioRecEN.ClaEnvRec, xDetEnvRec.ClaveEnvioRec);
                    xIns.AsignarParametro(DetalleEnvioRecEN.ClaCuo, xDetEnvRec.ClaveCuota);
                    xIns.AsignarParametro(DetalleEnvioRecEN.CodCli, xDetEnvRec.CodigoCliente);
                    xIns.AsignarParametro(DetalleEnvioRecEN.CMonCuo, xDetEnvRec.CMonedaCuota);
                    xIns.AsignarParametro(DetalleEnvioRecEN.FecVenCuo, Fecha.ObtenerAnoMesDia(xDetEnvRec.FechaVencimientoCuota));
                    xIns.AsignarParametro(DetalleEnvioRecEN.MonPenCuo, xDetEnvRec.MontoPendienteCuota.ToString());
                    xIns.AsignarParametro(DetalleEnvioRecEN.MonMorPen, xDetEnvRec.MontoMoraPendiente.ToString());
                    xIns.AsignarParametro(DetalleEnvioRecEN.CodCon, xDetEnvRec.CodigoConcepto);
                    xIns.AsignarParametro(DetalleEnvioRecEN.CEstPen, xDetEnvRec.CEstadoPenalidad);
                    xIns.AsignarParametro(DetalleEnvioRecEN.UsuAgr, Universal.gCodigoUsuario);
                    xIns.AsignarParametro(DetalleEnvioRecEN.FecAgr, "FECHAHORA");
                    xIns.AsignarParametro(DetalleEnvioRecEN.UsuMod, Universal.gCodigoUsuario);
                    xIns.AsignarParametro(DetalleEnvioRecEN.FecMod, "FECHAHORA");
                    xIns.FinParametros();

                    //ir concatenando cada registro              
                    iScriptTotal.AppendLine(xIns.ObtenerScript());
                }
                // Si iScriptTotal esta vacio, entonces sale
                if (iScriptTotal.ToString() != string.Empty)
                {
                    xObjCon.ComandoTexto(iScriptTotal.ToString());
                    xObjCon.EjecutarSinResultado();
                }
            }
            xObjCon.Desconectar();
        }

        public void ModificarDetalleEnvioRec(DetalleEnvioRecEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(DetalleEnvioRecEN.ClaCuo, pObj.ClaveCuota);
            xUpd.AsignarParametro(DetalleEnvioRecEN.CodCli, pObj.CodigoCliente);
            xUpd.AsignarParametro(DetalleEnvioRecEN.MonPenCuo, pObj.MontoPendienteCuota.ToString());
            xUpd.AsignarParametro(DetalleEnvioRecEN.MonMorPen, pObj.MontoMoraPendiente.ToString());
            xUpd.AsignarParametro(DetalleEnvioRecEN.FecVenCuo, Fecha.ObtenerAnoMesDia(pObj.FechaVencimientoCuota));
            xUpd.AsignarParametro(DetalleEnvioRecEN.CEstPen, pObj.CEstadoPenalidad);
            xUpd.AsignarParametro(DetalleEnvioRecEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(DetalleEnvioRecEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaDetEnvRec, SqlSelect.Operador.Igual, pObj.ClaveDetalleEnvioRec);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarDetalleEnvioRecXClave(DetalleEnvioRecEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaDetEnvRec, SqlSelect.Operador.Igual, pObj.ClaveDetalleEnvioRec);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarDetalleEnvioRecXClaveMasivo(List<DetalleEnvioRecEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            foreach (DetalleEnvioRecEN xDetEnvRec in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaDetEnvRec, SqlSelect.Operador.Igual, xDetEnvRec.ClaveDetalleEnvioRec);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void EliminarDetalleEnvioRecXEnvio(DetalleEnvioRecEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            xDel.CondicionDelete(xSel.ObtenerScript());
            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarDetalleEnvioRecXClaveMasivo1(List<DetalleEnvioRecEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //obtener los bloques
            List<List<DetalleEnvioRecEN>> iLisBlo = this.ListarListasPorBloques(pLista);

            //recorrer cada objeto
            foreach (List<DetalleEnvioRecEN> xLisDetRec in iLisBlo)
            {
                //script total
                StringBuilder iScriptTotal = new StringBuilder();

                //recorrer cada objeto
                foreach (DetalleEnvioRecEN xDetEnvRec in xLisDetRec)
                {
                    //armando escript para eliminar
                    SqlDelete xDel = new SqlDelete();
                    xDel.Tabla(this.xTabla);

                    //condicion
                    SqlSelect xSel = new SqlSelect();
                    xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaDetEnvRec, SqlSelect.Operador.Igual, xDetEnvRec.ClaveDetalleEnvioRec);
                    xDel.CondicionDelete(xSel.ObtenerScript());

                    //ir concatenando cada registro              
                    iScriptTotal.AppendLine(xDel.ObtenerScript());
                }
                // Si iScriptTotal esta vacio, entonces sale
                if (iScriptTotal.ToString() != string.Empty)
                {
                    xObjCon.ComandoTexto(iScriptTotal.ToString());
                    xObjCon.EjecutarSinResultado();
                }
            }
            xObjCon.Desconectar();
        }

        public List<DetalleEnvioRecEN> ListarDetalleEnvioRec(DetalleEnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<DetalleEnvioRecEN> ListarDetalleEnvioRecXClaveEnvioRec(DetalleEnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<DetalleEnvioRecEN> ListarLetrasDeEnvioRecXFiltro(DetalleEnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            xSel.CondicionCV(SqlSelect.Reservada.Y, DetalleEnvioRecEN.CodPro, SqlSelect.Operador.Igual, pObj.CodigoProyecto);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, DetalleEnvioRecEN.FecVenCuo, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<DetalleEnvioRecEN> ListarLetrasDeEnvioRecCreditoXFiltro(DetalleEnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            xSel.CondicionCV(SqlSelect.Reservada.Y, DetalleEnvioRecEN.CodPro, SqlSelect.Operador.Igual, pObj.CodigoProyecto);
            if (pObj.Adicionales.Valor1 == "Vencidas")
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, DetalleEnvioRecEN.FecVenCuo, SqlSelect.Operador.MenorIgual, pObj.Adicionales.Hasta1);
            }
            else
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, DetalleEnvioRecEN.FecVenCuo, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public DetalleEnvioRecEN BuscarDetalleEnvioRecXClave(DetalleEnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaDetEnvRec, SqlSelect.Operador.Igual, pObj.ClaveDetalleEnvioRec);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<List<DetalleEnvioRecEN>> ListarLetrasDeEnvioRecCreditoXFiltro1(DetalleEnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            xSel.CondicionCV(SqlSelect.Reservada.Y, DetalleEnvioRecEN.CodPro, SqlSelect.Operador.Igual, pObj.CodigoProyecto);
            if (pObj.Adicionales.Valor1 == "Vencidas")
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, DetalleEnvioRecEN.FecVenCuo, SqlSelect.Operador.MenorIgual, pObj.Adicionales.Hasta1);
            }
            else
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, DetalleEnvioRecEN.FecVenCuo, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            }
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<DetalleEnvioRecEN>> iLisRes = new List<List<DetalleEnvioRecEN>>();

            //variables
            string iClave = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                DetalleEnvioRecEN iDetEnvEN = new DetalleEnvioRecEN();
                iDetEnvEN = this.Objeto(xIdr);

                //preguntamos si es un contrato y ubicacion diferente
                if (iDetEnvEN.NumeroContrato != iClave)
                {
                    List<DetalleEnvioRecEN> iLisLet = new List<DetalleEnvioRecEN>();
                    iLisLet.Add(iDetEnvEN);
                    iLisRes.Add(iLisLet);
                    iIndice++;
                    iClave = iDetEnvEN.NumeroContrato;
                }
                else
                {
                    iLisRes[iIndice].Add(iDetEnvEN);
                }
            }
            xObjCon.Desconectar();
            return iLisRes;
        }

        public List<List<DetalleEnvioRecEN>> ListarLetrasDeEnvioRecXFiltro1(DetalleEnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            xSel.CondicionCV(SqlSelect.Reservada.Y, DetalleEnvioRecEN.CodPro, SqlSelect.Operador.Igual, pObj.CodigoProyecto);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, DetalleEnvioRecEN.FecVenCuo, pObj.Adicionales.Desde1, pObj.Adicionales.Hasta1);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<DetalleEnvioRecEN>> iLisRes = new List<List<DetalleEnvioRecEN>>();

            //variables
            string iClave = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                DetalleEnvioRecEN iDetEnvEN = new DetalleEnvioRecEN();
                iDetEnvEN = this.Objeto(xIdr);

                //preguntamos si es un contrato y ubicacion diferente
                if (iDetEnvEN.NumeroContrato != iClave)
                {
                    List<DetalleEnvioRecEN> iLisLet = new List<DetalleEnvioRecEN>();
                    iLisLet.Add(iDetEnvEN);
                    iLisRes.Add(iLisLet);
                    iIndice++;
                    iClave = iDetEnvEN.NumeroContrato;
                }
                else
                {
                    iLisRes[iIndice].Add(iDetEnvEN);
                }
            }
            xObjCon.Desconectar();
            return iLisRes;
        }

        public List<DetalleEnvioRecEN> ListarDetallesEnvioRecParaQuitarCuotas(DetalleEnvioRecEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, DetalleEnvioRecEN.ClaEnvRec, SqlSelect.Operador.Igual, pObj.ClaveEnvioRec);
            if (pObj.NumeroContrato != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, DetalleEnvioRecEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            }
            if (pObj.CodigoConcepto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, DetalleEnvioRecEN.CodCon, SqlSelect.Operador.Igual, pObj.CodigoConcepto);
            }
            if (pObj.Adicionales.Desde1 != string.Empty)
            {
                xSel.CondicionBetween(SqlSelect.Reservada.Y, DetalleEnvioRecEN.FecVenCuo, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1),
                                      Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            }

            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }




    }
}
