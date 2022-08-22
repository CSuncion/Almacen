using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptBD;
using Entidades;
using Entidades.Adicionales;
using Datos.Config;
using System.Data;
using Comun;

namespace Datos
{
    public class CuotaAD
    {

        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<CuotaEN> xLista = new List<CuotaEN>();
        private CuotaEN xObj = new CuotaEN();
        private string xTabla = "Cuota";
        private string xVista = "VsCuota";


        #region Metodos privados

        private CuotaEN Objeto(IDataReader iDr)
        {
            CuotaEN xObjEnc = new CuotaEN();
            xObjEnc.ClaveCuota = iDr[CuotaEN.ClaCuo].ToString();
            xObjEnc.ClaveLote = iDr[CuotaEN.ClaLot].ToString();
            xObjEnc.CodigoEmpresa = iDr[CuotaEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[CuotaEN.NomEmp].ToString();
            xObjEnc.CodigoProyecto = iDr[CuotaEN.CodPro].ToString();
            xObjEnc.NombreProyecto = iDr[CuotaEN.NomPro].ToString();
            xObjEnc.CodigoUrbanizacionProyecto = iDr[CuotaEN.CodUrbPro].ToString();
            xObjEnc.NombreUrbanizacionProyecto = iDr[CuotaEN.NomUrbPro].ToString();
            xObjEnc.EtapaLote = iDr[CuotaEN.EtaLot].ToString();
            xObjEnc.ManzanaLote = iDr[CuotaEN.MzaLot].ToString();
            xObjEnc.NumeroLote = iDr[CuotaEN.NumLot].ToString();
            xObjEnc.CodigoConcepto = iDr[CuotaEN.CodCon].ToString();
            xObjEnc.DescripcionConcepto = iDr[CuotaEN.DesCon].ToString();
            xObjEnc.CodigoCliente = iDr[CuotaEN.CodCli].ToString();
            xObjEnc.NombreCliente = iDr[CuotaEN.NomCli].ToString();
            xObjEnc.NumeroDocumentoCliente = iDr[CuotaEN.NumDocCli].ToString();
            xObjEnc.TelefonoCliente = iDr[CuotaEN.TelCli].ToString();
            xObjEnc.DireccionCliente = iDr[CuotaEN.DirCli].ToString();
            xObjEnc.NumeroDocumentoCliente = iDr[CuotaEN.NumDocCli].ToString();
            xObjEnc.NumeroContrato = iDr[CuotaEN.NumCon].ToString();
            xObjEnc.AnoCuota = iDr[CuotaEN.AnoCuo].ToString();
            xObjEnc.CMesCuota = iDr[CuotaEN.CMesCuo].ToString();
            xObjEnc.MontoCuota = Convert.ToDecimal(iDr[CuotaEN.MonCuo].ToString());
            xObjEnc.MontoPendienteCuota = Convert.ToDecimal(iDr[CuotaEN.MonPenCuo].ToString());
            xObjEnc.CMonedaCuota = iDr[CuotaEN.CMonCuo].ToString();
            xObjEnc.NMonedaCuota = iDr[CuotaEN.NMonCuo].ToString();
            xObjEnc.AbreviaturaMonedaCuota = iDr[CuotaEN.AbrMonCuo].ToString();
            xObjEnc.FechaEmisionCuota =Fecha.ObtenerDiaMesAno( iDr[CuotaEN.FecEmiCuo].ToString());
            xObjEnc.FechaVencimientoCuota =Fecha.ObtenerDiaMesAno( iDr[CuotaEN.FecVenCuo].ToString());
            xObjEnc.FechaPagoCuota =Fecha.ObtenerDiaMesAno( iDr[CuotaEN.FecPagCuo].ToString());
            xObjEnc.FechaCobranzaCuota = Fecha.ObtenerDiaMesAno(iDr[CuotaEN.FecCobCuo].ToString());
            xObjEnc.CEstadoCuota = iDr[CuotaEN.CEstCuo].ToString();
            xObjEnc.NEstadoCuota = iDr[CuotaEN.NEstCuo].ToString();
            xObjEnc.PeriodoCuota = iDr[CuotaEN.PerCuo].ToString();
            xObjEnc.NumeroRecibo = iDr[CuotaEN.NumRec].ToString();
            xObjEnc.EnvioCorreoRecibo = iDr[CuotaEN.EnvCorRec].ToString();
            xObjEnc.EmailCliente = iDr[CuotaEN.EmaCli].ToString();
            xObjEnc.CEstadoPenalidad = iDr[CuotaEN.CEstPen].ToString();
            xObjEnc.NEstadoPenalidad = iDr[CuotaEN.NEstPen].ToString();
            xObjEnc.MontoMora = Convert.ToDecimal(iDr[CuotaEN.MonMor].ToString());
            xObjEnc.MontoMoraPendiente = Convert.ToDecimal(iDr[CuotaEN.MonMorPen].ToString());
            xObjEnc.CGeneroMoraFija = iDr[CuotaEN.CGenMorFij].ToString();
            xObjEnc.NGeneroMoraFija = iDr[CuotaEN.NGenMorFij].ToString();
            xObjEnc.UsuarioAgrega = iDr[CuotaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[CuotaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[CuotaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[CuotaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveCuota;
            return xObjEnc;
        }
        
        private List<CuotaEN> ListarObjetos(string pScript)
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
        
        private CuotaEN BuscarObjeto(string pScript)
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
        
        public void AdicionarCuota(CuotaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(CuotaEN.ClaCuo, pObj.ClaveCuota);
            xIns.AsignarParametro(CuotaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(CuotaEN.CodPro, pObj.CodigoProyecto);
            xIns.AsignarParametro(CuotaEN.EtaLot, pObj.EtapaLote);
            xIns.AsignarParametro(CuotaEN.MzaLot, pObj.ManzanaLote);
            xIns.AsignarParametro(CuotaEN.NumLot, pObj.NumeroLote);
            xIns.AsignarParametro(CuotaEN.CodCon, pObj.CodigoConcepto);
            xIns.AsignarParametro(CuotaEN.CodCli, pObj.CodigoCliente);
            xIns.AsignarParametro(CuotaEN.NumCon, pObj.NumeroContrato);
            xIns.AsignarParametro(CuotaEN.AnoCuo, pObj.AnoCuota);
            xIns.AsignarParametro(CuotaEN.CMesCuo, pObj.CMesCuota);
            xIns.AsignarParametro(CuotaEN.MonCuo, pObj.MontoCuota.ToString());
            xIns.AsignarParametro(CuotaEN.MonPenCuo, pObj.MontoPendienteCuota.ToString());
            xIns.AsignarParametro(CuotaEN.CMonCuo, pObj.CMonedaCuota);
            xIns.AsignarParametro(CuotaEN.FecEmiCuo,Fecha.ObtenerAnoMesDia( pObj.FechaEmisionCuota));
            xIns.AsignarParametro(CuotaEN.FecVenCuo, Fecha.ObtenerAnoMesDia(pObj.FechaVencimientoCuota));
            xIns.AsignarParametro(CuotaEN.FecPagCuo, Fecha.ObtenerAnoMesDia(pObj.FechaPagoCuota));
            xIns.AsignarParametro(CuotaEN.FecCobCuo, Fecha.ObtenerAnoMesDia(pObj.FechaCobranzaCuota));
            xIns.AsignarParametro(CuotaEN.CEstCuo, pObj.CEstadoCuota);
            xIns.AsignarParametro(CuotaEN.PerCuo, pObj.PeriodoCuota);
            xIns.AsignarParametro(CuotaEN.ClaLot, pObj.ClaveLote);
            xIns.AsignarParametro(CuotaEN.NumRec, pObj.NumeroRecibo);
            xIns.AsignarParametro(CuotaEN.EnvCorRec, pObj.EnvioCorreoRecibo);
            xIns.AsignarParametro(CuotaEN.CEstPen, pObj.CEstadoPenalidad);
            xIns.AsignarParametro(CuotaEN.MonMor, pObj.MontoMora.ToString());
            xIns.AsignarParametro(CuotaEN.MonMorPen, pObj.MontoMoraPendiente.ToString());
            xIns.AsignarParametro(CuotaEN.CGenMorFij, pObj.CGeneroMoraFija);
            xIns.AsignarParametro(CuotaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CuotaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(CuotaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CuotaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarCuota(List<CuotaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(CuotaEN.ClaCuo, xCuo.ClaveCuota);
                xIns.AsignarParametro(CuotaEN.CodEmp, xCuo.CodigoEmpresa);
                xIns.AsignarParametro(CuotaEN.CodPro, xCuo.CodigoProyecto);
                xIns.AsignarParametro(CuotaEN.EtaLot, xCuo.EtapaLote);
                xIns.AsignarParametro(CuotaEN.MzaLot, xCuo.ManzanaLote);
                xIns.AsignarParametro(CuotaEN.NumLot, xCuo.NumeroLote);
                xIns.AsignarParametro(CuotaEN.CodCon, xCuo.CodigoConcepto);
                xIns.AsignarParametro(CuotaEN.CodCli, xCuo.CodigoCliente);
                xIns.AsignarParametro(CuotaEN.NumCon, xCuo.NumeroContrato);
                xIns.AsignarParametro(CuotaEN.AnoCuo, xCuo.AnoCuota);
                xIns.AsignarParametro(CuotaEN.CMesCuo, xCuo.CMesCuota);
                xIns.AsignarParametro(CuotaEN.MonCuo, xCuo.MontoCuota.ToString());
                xIns.AsignarParametro(CuotaEN.MonPenCuo, xCuo.MontoPendienteCuota.ToString());
                xIns.AsignarParametro(CuotaEN.CMonCuo, xCuo.CMonedaCuota);
                xIns.AsignarParametro(CuotaEN.FecEmiCuo, Fecha.ObtenerAnoMesDia(xCuo.FechaEmisionCuota));
                xIns.AsignarParametro(CuotaEN.FecVenCuo, Fecha.ObtenerAnoMesDia(xCuo.FechaVencimientoCuota));
                xIns.AsignarParametro(CuotaEN.FecPagCuo, Fecha.ObtenerAnoMesDia(xCuo.FechaPagoCuota));
                xIns.AsignarParametro(CuotaEN.FecCobCuo, Fecha.ObtenerAnoMesDia(xCuo.FechaCobranzaCuota));
                xIns.AsignarParametro(CuotaEN.CEstCuo, xCuo.CEstadoCuota);
                xIns.AsignarParametro(CuotaEN.PerCuo, xCuo.PeriodoCuota);
                xIns.AsignarParametro(CuotaEN.ClaLot, xCuo.ClaveLote);
                xIns.AsignarParametro(CuotaEN.NumRec, xCuo.NumeroRecibo);
                xIns.AsignarParametro(CuotaEN.EnvCorRec, xCuo.EnvioCorreoRecibo);
                xIns.AsignarParametro(CuotaEN.CEstPen, xCuo.CEstadoPenalidad);
                xIns.AsignarParametro(CuotaEN.MonMor, xCuo.MontoMora.ToString());
                xIns.AsignarParametro(CuotaEN.MonMorPen, xCuo.MontoMoraPendiente.ToString());
                xIns.AsignarParametro(CuotaEN.CGenMorFij, xCuo.CGeneroMoraFija);
                xIns.AsignarParametro(CuotaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(CuotaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(CuotaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(CuotaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                //ejecutar comando
                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            //desconectar
            xObjCon.Desconectar();
        }

        public void ModificarCuota(CuotaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);
            xUpd.AsignarParametro(CuotaEN.CMonCuo, pObj.CMonedaCuota.ToString());
            xUpd.AsignarParametro(CuotaEN.MonCuo, pObj.MontoCuota.ToString());
            xUpd.AsignarParametro(CuotaEN.MonPenCuo, pObj.MontoPendienteCuota.ToString());
            xUpd.AsignarParametro(CuotaEN.NumCon, pObj.NumeroContrato);
            xUpd.AsignarParametro(CuotaEN.CodCli, pObj.CodigoCliente);
            xUpd.AsignarParametro(CuotaEN.FecEmiCuo, Fecha.ObtenerAnoMesDia(pObj.FechaEmisionCuota));
            xUpd.AsignarParametro(CuotaEN.FecVenCuo, Fecha.ObtenerAnoMesDia(pObj.FechaVencimientoCuota));
            xUpd.AsignarParametro(CuotaEN.FecPagCuo, Fecha.ObtenerAnoMesDia(pObj.FechaPagoCuota));
            xUpd.AsignarParametro(CuotaEN.FecCobCuo, Fecha.ObtenerAnoMesDia(pObj.FechaCobranzaCuota));
            xUpd.AsignarParametro(CuotaEN.CEstCuo, pObj.CEstadoCuota);
            xUpd.AsignarParametro(CuotaEN.NumRec, pObj.NumeroRecibo);
            xUpd.AsignarParametro(CuotaEN.EnvCorRec, pObj.EnvioCorreoRecibo);
            xUpd.AsignarParametro(CuotaEN.CEstPen, pObj.CEstadoPenalidad);
            xUpd.AsignarParametro(CuotaEN.MonMor, pObj.MontoMora.ToString());
            xUpd.AsignarParametro(CuotaEN.MonMorPen, pObj.MontoMoraPendiente.ToString());
            xUpd.AsignarParametro(CuotaEN.CGenMorFij, pObj.CGeneroMoraFija);
            xUpd.AsignarParametro(CuotaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(CuotaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.ClaCuo, SqlSelect.Operador.Igual, pObj.ClaveCuota);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarCuota(List<CuotaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                //armando escript para insertar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                xUpd.AsignarParametro(CuotaEN.ClaCuo, xCuo.ClaveCuota);
                xUpd.AsignarParametro(CuotaEN.CodEmp, xCuo.CodigoEmpresa);
                xUpd.AsignarParametro(CuotaEN.CodPro, xCuo.CodigoProyecto);
                xUpd.AsignarParametro(CuotaEN.EtaLot, xCuo.EtapaLote);
                xUpd.AsignarParametro(CuotaEN.MzaLot, xCuo.ManzanaLote);
                xUpd.AsignarParametro(CuotaEN.NumLot, xCuo.NumeroLote);
                xUpd.AsignarParametro(CuotaEN.CodCon, xCuo.CodigoConcepto);
                xUpd.AsignarParametro(CuotaEN.CodCli, xCuo.CodigoCliente);
                xUpd.AsignarParametro(CuotaEN.NumCon, xCuo.NumeroContrato);
                xUpd.AsignarParametro(CuotaEN.AnoCuo, xCuo.AnoCuota);
                xUpd.AsignarParametro(CuotaEN.CMesCuo, xCuo.CMesCuota);
                xUpd.AsignarParametro(CuotaEN.MonCuo, xCuo.MontoCuota.ToString());
                xUpd.AsignarParametro(CuotaEN.MonPenCuo, xCuo.MontoPendienteCuota.ToString());
                xUpd.AsignarParametro(CuotaEN.CMonCuo, xCuo.CMonedaCuota);
                xUpd.AsignarParametro(CuotaEN.FecEmiCuo, Fecha.ObtenerAnoMesDia(xCuo.FechaEmisionCuota));
                xUpd.AsignarParametro(CuotaEN.FecVenCuo, Fecha.ObtenerAnoMesDia(xCuo.FechaVencimientoCuota));
                xUpd.AsignarParametro(CuotaEN.FecPagCuo, Fecha.ObtenerAnoMesDia(xCuo.FechaPagoCuota));
                xUpd.AsignarParametro(CuotaEN.FecCobCuo, Fecha.ObtenerAnoMesDia(xCuo.FechaCobranzaCuota));
                xUpd.AsignarParametro(CuotaEN.CEstCuo, xCuo.CEstadoCuota);
                xUpd.AsignarParametro(CuotaEN.PerCuo, xCuo.PeriodoCuota);
                xUpd.AsignarParametro(CuotaEN.NumRec, xCuo.NumeroRecibo);
                xUpd.AsignarParametro(CuotaEN.EnvCorRec, xCuo.EnvioCorreoRecibo);
                xUpd.AsignarParametro(CuotaEN.CEstPen, xCuo.CEstadoPenalidad);
                xUpd.AsignarParametro(CuotaEN.MonMor, xCuo.MontoMora.ToString());
                xUpd.AsignarParametro(CuotaEN.MonMorPen, xCuo.MontoMoraPendiente.ToString());
                xUpd.AsignarParametro(CuotaEN.CGenMorFij, xCuo.CGeneroMoraFija);
                xUpd.AsignarParametro(CuotaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(CuotaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.ClaCuo, SqlSelect.Operador.Igual, xCuo.ClaveCuota);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar comando
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            //desconectar
            xObjCon.Desconectar();
        }

        public void ModificarEstadoCuota(List<CuotaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);
                //xUpd.AsignarParametro(CuotaEN.CEstCuo);
                xUpd.AsignarParametro(CuotaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(CuotaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.ClaCuo, SqlSelect.Operador.Igual, xCuo.ClaveCuota);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar comando
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();                
            }            
            xObjCon.Desconectar();
        }

        public void EliminarCuotaXClave(CuotaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.ClaCuo, SqlSelect.Operador.Igual, pObj.ClaveCuota);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarCuotaXClave(List<CuotaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (CuotaEN xCuo in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.ClaCuo, SqlSelect.Operador.Igual, xCuo.ClaveCuota);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();                
            }
           
            xObjCon.Desconectar();
        }

        public void EliminarCuotasSinPagoXPeriodo(CuotaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.Igual, pObj.PeriodoCuota);
            xSel.CondicionCC(SqlSelect.Reservada.Y, CuotaEN.MonCuo, SqlSelect.Operador.Igual, CuotaEN.MonPenCuo);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarCuotasSinPagoXContrato(CuotaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.CondicionCC(SqlSelect.Reservada.Y, CuotaEN.MonCuo, SqlSelect.Operador.Igual, CuotaEN.MonPenCuo);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarCuotasSinPagoXContratoYMayorOIgualAPeriodo(CuotaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.MayorIgual, pObj.PeriodoCuota);
            xSel.CondicionCC(SqlSelect.Reservada.Y, CuotaEN.MonCuo, SqlSelect.Operador.Igual, CuotaEN.MonPenCuo);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<CuotaEN> ListarCuotas(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasConPagoXPeriodo(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.Igual,pObj.PeriodoCuota);
            xSel.CondicionCC(SqlSelect.Reservada.Y, CuotaEN.MonCuo, SqlSelect.Operador.Diferente, CuotaEN.MonPenCuo);
            xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );
        }
        
        public CuotaEN BuscarCuotaXClave(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.ClaCuo, SqlSelect.Operador.Igual, pObj.ClaveCuota);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasConPagoMayorOIgualVctoDeContrato(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.FecVenCuo, SqlSelect.Operador.MayorIgual,Fecha.ObtenerAnoMesDia( pObj.FechaVencimientoCuota));
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.CondicionCC(SqlSelect.Reservada.Y, CuotaEN.MonCuo, SqlSelect.Operador.Diferente, CuotaEN.MonPenCuo);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasParaEnvioRec(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);

            //segun condicion
            switch (pObj.Adicionales.Desde1)
            {
                case "Vencidas":
                    {
                        xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.FecVenCuo, SqlSelect.Operador.MenorIgual, Fecha.ObtenerAnoMesDia(DateTime.Now));
                        break;
                    }
                case "Vencidas mas 30 dias":
                    {
                        xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CGenMorFij, SqlSelect.Operador.Igual,  "1");//si
                        break;
                    }
                case "Todas menos la de mas 30 dias":
                    {
                        xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.FecVenCuo, SqlSelect.Operador.Mayor, Fecha.ObtenerAnoMesDia(DateTime.Now.AddDays(-30)));
                        xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CGenMorFij, SqlSelect.Operador.Igual, "0");//no
                        break;
                    }
                case "Por vencer":
                    {
                        xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.FecVenCuo, SqlSelect.Operador.MayorIgual, Fecha.ObtenerAnoMesDia(DateTime.Now));
                        break;
                    }
                case "Por rango fecha":
                    {
                        xSel.CondicionBetween(SqlSelect.Reservada.Y, CuotaEN.FecVenCuo, Fecha.ObtenerAnoMesDia(pObj.Adicionales.FechaDesde),
                                                Fecha.ObtenerAnoMesDia(pObj.Adicionales.FechaHasta));
                        break;
                    }
            }

           // xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.MonPenCuo, SqlSelect.Operador.Diferente, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CEstCuo, SqlSelect.Operador.Igual, "0");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasXContrato(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);           
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public CuotaEN BuscarCuotaXNumeroContratoYVcto(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual,Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.FecVenCuo, SqlSelect.Operador.Igual,Fecha.ObtenerAnoMesDia( pObj.FechaVencimientoCuota));
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public CuotaEN BuscarCuotaXNumeroContratoYPendientes(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CEstCuo, SqlSelect.Operador.Igual, "0");
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasGeneradosDeRecepcionRec(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionINx(SqlSelect.Reservada.Cuando, CuotaEN.ClaCuo, pObj.ClaveCuota);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasXProyectoYPeriodo(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            if (pObj.CodigoProyecto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CodPro, SqlSelect.Operador.Igual, pObj.CodigoProyecto);
            }
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.Igual, pObj.PeriodoCuota);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasPendientes(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CEstCuo, SqlSelect.Operador.Igual, "0");
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasPendientesXContrato(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CEstCuo, SqlSelect.Operador.Igual, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual,pObj.NumeroContrato);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasPendientesXVcto(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CEstCuo, SqlSelect.Operador.Igual, "0");
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.MayorIgual, pObj.PeriodoCuota);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.MenorIgual, pObj.Adicionales.Desde1);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasCanceladasXContrato(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CEstCuo, SqlSelect.Operador.Igual, "1"); //Cuotas Canceladas           
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public void EliminarCuotasSinPagoXContratoXConceptoYMayorOIgualAPeriodo(CuotaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CodCon, SqlSelect.Operador.Igual, pObj.CodigoConcepto);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.MayorIgual, pObj.PeriodoCuota);
            xSel.CondicionCC(SqlSelect.Reservada.Y, CuotaEN.MonCuo, SqlSelect.Operador.Igual, CuotaEN.MonPenCuo);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public List<CuotaEN> ListarCuotasPendientesParaSaldosAMes(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.MenorIgual, pObj.PeriodoCuota);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CEstCuo, SqlSelect.Operador.Igual, "0");//pendiente
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasCanceladasParaSaldosAMes(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.MenorIgual, pObj.PeriodoCuota);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.FecCobCuo, SqlSelect.Operador.MayorIgual, Fecha.ObtenerAnoMesDia(pObj.FechaCobranzaCuota));
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.CEstCuo, SqlSelect.Operador.Igual, "1");//canceladas
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasDeNumerosContratos(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionINx(SqlSelect.Reservada.Y, CuotaEN.NumCon, pObj.NumeroContrato);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CuotaEN> ListarCuotasCobradasXContrato(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.FecPagCuo, SqlSelect.Operador.Diferente, ""); //Cuotas Cobradas
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<List<CuotaEN>> ListarListasCuotasPorContratoEnPeriodo(CuotaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CuotaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CuotaEN.PerCuo, SqlSelect.Operador.Igual, pObj.PeriodoCuota);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            xObjCon.ComandoTexto(xSel.ObtenerScript());

            //lista resultado
            List<List<CuotaEN>> iLisRes = new List<List<CuotaEN>>();

            //variables
            string iClave = string.Empty;
            int iIndice = -1;

            //recorrer cada registro del xIdr
            IDataReader xIdr = xObjCon.ObtenerIdr();

            //leer
            while (xIdr.Read())
            {
                //creamos un nuevo objeto
                CuotaEN iCuoEN = new CuotaEN();
                iCuoEN = this.Objeto(xIdr);

                //preguntamos si es un contrato es diferente
                if (iCuoEN.NumeroContrato != iClave)
                {
                    List<CuotaEN> iLisCuo = new List<CuotaEN>();
                    iLisCuo.Add(iCuoEN);
                    iLisRes.Add(iLisCuo);
                    iIndice++;
                    iClave = iCuoEN.NumeroContrato;
                }
                else
                {
                    iLisRes[iIndice].Add(iCuoEN);
                }
            }
            xObjCon.Desconectar();
            return iLisRes;
        }




    }
}
