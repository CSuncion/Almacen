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
    public  class CobranzaAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<CobranzaEN> xLista = new List<CobranzaEN>();
        private CobranzaEN xObj = new CobranzaEN();
        private string xTabla = "Cobranza";
        private string xVista = "VsCobranza";
       

        #region Metodos privados

        private CobranzaEN Objeto(IDataReader iDr)
        {
            CobranzaEN xObjEnc = new CobranzaEN();
            xObjEnc.CorrelativoCobranza = iDr[CobranzaEN.CorCob].ToString();
            xObjEnc.FechaPagoCuota = Fecha.ObtenerDiaMesAno(iDr[CobranzaEN.FecPagCuo].ToString());
            xObjEnc.FechaCobranzaCuota = Fecha.ObtenerDiaMesAno(iDr[CobranzaEN.FecCobCuo].ToString());
            xObjEnc.FechaCobranza =Fecha.ObtenerDiaMesAno(iDr[CobranzaEN.FecCob]);
            xObjEnc.AnoCobranza = iDr[CobranzaEN.AnoCob].ToString();
            xObjEnc.CMesCobranza = iDr[CobranzaEN.CMesCob].ToString();
            xObjEnc.NMesCobranza = iDr[CobranzaEN.NMesCob].ToString();
            xObjEnc.ClaveCuota = iDr[CobranzaEN.ClaCuo].ToString();
            xObjEnc.NumeroContrato = iDr[CobranzaEN.NumCon].ToString();
            xObjEnc.CodigoEmpresa = iDr[CobranzaEN.CodEmp].ToString( );
            xObjEnc.NombreEmpresa = iDr[CobranzaEN.NomEmp].ToString( );
            xObjEnc.CodigoProyecto = iDr[CobranzaEN.CodPro].ToString( );
            xObjEnc.NombreProyecto = iDr[CobranzaEN.NomPro].ToString( );
            xObjEnc.CodigoUrbanizacionProyecto = iDr[CobranzaEN.CodUrbPro].ToString( );
            xObjEnc.NombreUrbanizacionProyecto = iDr[CobranzaEN.NomUrbPro].ToString( );
            xObjEnc.FechaVencimientoCuota =Fecha.ObtenerDiaMesAno(iDr[CobranzaEN.FecVenCuo]);
            xObjEnc.CodigoCliente = iDr[CobranzaEN.CodCli].ToString();
            xObjEnc.NombreCliente = iDr[CobranzaEN.NomCli].ToString();
            xObjEnc.MontoCuota = Convert.ToDecimal(iDr[CobranzaEN.MonCuo].ToString());
            xObjEnc.FechaDepositoCobranza = Fecha.ObtenerDiaMesAno(iDr[CobranzaEN.FecDepCob]);
            xObjEnc.ImporteCobranza = Convert.ToDecimal(iDr[CobranzaEN.ImpCob].ToString());
            xObjEnc.MontoDescuentoCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonDesCob].ToString());
            xObjEnc.MontoMoraCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonMorCob].ToString());
            xObjEnc.MontoProtestoCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonProCob].ToString());
            xObjEnc.MontoOtrosCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonOtrCob].ToString());
            xObjEnc.MontoaCobrarCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonaCobCob].ToString());
            xObjEnc.MontoCobradoCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonCobCob].ToString());
            xObjEnc.CFormaCobroCobranza = iDr[CobranzaEN.CForCobCob].ToString();
            xObjEnc.NFormaCobroCobranza = iDr[CobranzaEN.NForCobCob].ToString();
            xObjEnc.CModoCobroCobranza = iDr[CobranzaEN.CModCobCob].ToString();
            xObjEnc.NModoCobroCobranza = iDr[CobranzaEN.NModCobCob].ToString();
            xObjEnc.MontoDolaresCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonDolCob].ToString());
            xObjEnc.MontoSolesCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonSolCob].ToString());
            xObjEnc.MontoComisionBcoCobranza = Convert.ToDecimal(iDr[CobranzaEN.MonComBcoCob].ToString());
            xObjEnc.TipoCambioCobranza = Convert.ToDecimal(iDr[CobranzaEN.TipCamCob].ToString());
            xObjEnc.CLugarCobranza = iDr[CobranzaEN.CLugCob].ToString();
            xObjEnc.NLugarCobranza = iDr[CobranzaEN.NLugCob].ToString();
            xObjEnc.ObservacionCobranza = iDr[CobranzaEN.ObsCob].ToString();
            xObjEnc.ClaveComprobante = iDr[CobranzaEN.ClaCom].ToString();
            xObjEnc.ClaveComprobanteRetLet = iDr[CobranzaEN.ClaComRetLet].ToString();
            xObjEnc.ClaveCuentaBanco = iDr[CobranzaEN.ClaCtaBco].ToString();
            xObjEnc.AgenciaCuentaBanco = iDr[CobranzaEN.AgeCtaBco].ToString();
            xObjEnc.NumeroCuentaBanco = iDr[CobranzaEN.NumCtaBco].ToString();
            xObjEnc.CodigoCuentaBanco = iDr[CobranzaEN.CodCueBco].ToString();
            xObjEnc.CodigoBanco = iDr[CobranzaEN.CodBco].ToString();
            xObjEnc.NombreBanco = iDr[CobranzaEN.NomBco].ToString();
            xObjEnc.NMonedaCuentaBanco = iDr[CobranzaEN.NMonCtaBco].ToString();
            xObjEnc.CTipoCobranza = iDr[CobranzaEN.CTipCob].ToString();
            xObjEnc.NTipoCobranza = iDr[CobranzaEN.NTipCob].ToString();
            xObjEnc.CFormaPagoLetra = iDr[CobranzaEN.CForPagLet].ToString( );
            xObjEnc.NFormaPagoLetra = iDr[CobranzaEN.NForPagLet].ToString( );
            xObjEnc.EtapaLote = iDr[CobranzaEN.EtaLot].ToString();
            xObjEnc.ManzanaLote = iDr[CobranzaEN.MzaLot].ToString();
            xObjEnc.NumeroLote = iDr[CobranzaEN.NumLot].ToString();
            xObjEnc.ClaveNoIdentificado = iDr[CobranzaEN.ClaNoIde].ToString();
            xObjEnc.ClaveVoucher = iDr[CobranzaEN.ClaVou].ToString();
            //xObjEnc.CorrelativoVoucher = iDr[CobranzaEN.CorVou].ToString();
            //xObjEnc.MontoVoucher =Convert.ToDecimal( iDr[CobranzaEN.MonVou].ToString());
            xObjEnc.CuotaPagadaCobranza = Convert.ToDecimal(iDr[CobranzaEN.CuoPagCob].ToString());
            xObjEnc.MoraPagadaCobranza = Convert.ToDecimal(iDr[CobranzaEN.MorPagCob].ToString());
            xObjEnc.CuotaPendienteAnterior = Convert.ToDecimal(iDr[CobranzaEN.CuoPenAnt].ToString());
            xObjEnc.MoraAnterior = Convert.ToDecimal(iDr[CobranzaEN.MorAnt].ToString());
            xObjEnc.MoraPendienteAnterior = Convert.ToDecimal(iDr[CobranzaEN.MorPenAnt].ToString());
            xObjEnc.CGeneroMoraFijaAnterior = iDr[CobranzaEN.CGenMorFijAnt].ToString();
            xObjEnc.NGeneroMoraFijaAnterior = iDr[CobranzaEN.NGenMorFijAnt].ToString();
            xObjEnc.UsuarioAgrega = iDr[CobranzaEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[CobranzaEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[CobranzaEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[CobranzaEN.FecMod]);
            xObjEnc.ClaveObjeto = xObjEnc.CorrelativoCobranza;
            return xObjEnc;
        }
        
        private List<CobranzaEN> ListarObjetos(string pScript)
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
        
        private CobranzaEN BuscarObjeto(string pScript)
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
        
        public void AdicionarCobranza(CobranzaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(CobranzaEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(CobranzaEN.CodPro, pObj.CodigoProyecto);
            xIns.AsignarParametro(CobranzaEN.CorCob, pObj.CorrelativoCobranza);
            xIns.AsignarParametro(CobranzaEN.FecPagCuo, Fecha.ObtenerAnoMesDia(pObj.FechaPagoCuota));
            xIns.AsignarParametro(CobranzaEN.FecCobCuo, Fecha.ObtenerAnoMesDia(pObj.FechaCobranzaCuota));
            xIns.AsignarParametro(CobranzaEN.FecCob, Fecha.ObtenerAnoMesDia(pObj.FechaCobranza));
            xIns.AsignarParametro(CobranzaEN.AnoCob, pObj.AnoCobranza);
            xIns.AsignarParametro(CobranzaEN.CMesCob, pObj.CMesCobranza);
            xIns.AsignarParametro(CobranzaEN.ClaCuo, pObj.ClaveCuota);
            xIns.AsignarParametro(CobranzaEN.NumCon, pObj.NumeroContrato);
            xIns.AsignarParametro(CobranzaEN.FecVenCuo, Fecha.ObtenerAnoMesDia(pObj.FechaVencimientoCuota));
            xIns.AsignarParametro(CobranzaEN.CodCli, pObj.CodigoCliente);
            xIns.AsignarParametro(CobranzaEN.MonCuo, pObj.MontoCuota.ToString());
            xIns.AsignarParametro(CobranzaEN.FecDepCob, Fecha.ObtenerAnoMesDia(pObj.FechaDepositoCobranza));            
            xIns.AsignarParametro(CobranzaEN.ImpCob, pObj.ImporteCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MonDesCob, pObj.MontoDescuentoCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MonMorCob, pObj.MontoMoraCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MonProCob, pObj.MontoProtestoCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MonOtrCob, pObj.MontoOtrosCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MonaCobCob, pObj.MontoaCobrarCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MonCobCob, pObj.MontoCobradoCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.CForCobCob, pObj.CFormaCobroCobranza);
            xIns.AsignarParametro(CobranzaEN.CModCobCob, pObj.CModoCobroCobranza);
            xIns.AsignarParametro(CobranzaEN.MonDolCob, pObj.MontoDolaresCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MonSolCob, pObj.MontoSolesCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MonComBcoCob, pObj.MontoComisionBcoCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.TipCamCob, pObj.TipoCambioCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.CLugCob, pObj.CLugarCobranza);
            xIns.AsignarParametro(CobranzaEN.ObsCob, pObj.ObservacionCobranza);
            xIns.AsignarParametro(CobranzaEN.ClaCom, pObj.ClaveComprobante);
            xIns.AsignarParametro(CobranzaEN.ClaComRetLet, pObj.ClaveComprobanteRetLet);
            xIns.AsignarParametro(CobranzaEN.ClaCtaBco, pObj.ClaveCuentaBanco);
            xIns.AsignarParametro(CobranzaEN.CTipCob, pObj.CTipoCobranza);
            xIns.AsignarParametro( CobranzaEN.CForPagLet , pObj.CFormaPagoLetra );
            xIns.AsignarParametro(CobranzaEN.EtaLot, pObj.EtapaLote);
            xIns.AsignarParametro(CobranzaEN.MzaLot, pObj.ManzanaLote);
            xIns.AsignarParametro(CobranzaEN.ClaNoIde, pObj.ClaveNoIdentificado);
            xIns.AsignarParametro(CobranzaEN.NumLot, pObj.NumeroLote);
            xIns.AsignarParametro(CobranzaEN.ClaVou, pObj.ClaveVoucher);
            xIns.AsignarParametro(CobranzaEN.CuoPagCob, pObj.CuotaPagadaCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.MorPagCob, pObj.MoraPagadaCobranza.ToString());
            xIns.AsignarParametro(CobranzaEN.CuoPenAnt, pObj.CuotaPendienteAnterior.ToString());
            xIns.AsignarParametro(CobranzaEN.MorAnt, pObj.MoraAnterior.ToString());
            xIns.AsignarParametro(CobranzaEN.MorPenAnt, pObj.MoraPendienteAnterior.ToString());
            xIns.AsignarParametro(CobranzaEN.CGenMorFijAnt, pObj.CGeneroMoraFijaAnterior);
            xIns.AsignarParametro(CobranzaEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CobranzaEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(CobranzaEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(CobranzaEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarCobranzaMasivo(List< CobranzaEN> pLista )
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //insertar cada objeto
            foreach (CobranzaEN xCob in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(CobranzaEN.CodEmp, xCob.CodigoEmpresa);
                xIns.AsignarParametro(CobranzaEN.CodPro, xCob.CodigoProyecto);
                xIns.AsignarParametro(CobranzaEN.CorCob, xCob.CorrelativoCobranza);
                xIns.AsignarParametro(CobranzaEN.FecPagCuo, Fecha.ObtenerAnoMesDia(xCob.FechaPagoCuota));
                xIns.AsignarParametro(CobranzaEN.FecCobCuo, Fecha.ObtenerAnoMesDia(xCob.FechaCobranzaCuota));
                xIns.AsignarParametro(CobranzaEN.FecCob, Fecha.ObtenerAnoMesDia(xCob.FechaCobranza));
                xIns.AsignarParametro(CobranzaEN.AnoCob, xCob.AnoCobranza);
                xIns.AsignarParametro(CobranzaEN.CMesCob, xCob.CMesCobranza);
                xIns.AsignarParametro(CobranzaEN.ClaCuo, xCob.ClaveCuota);
                xIns.AsignarParametro(CobranzaEN.NumCon, xCob.NumeroContrato);
                xIns.AsignarParametro(CobranzaEN.FecVenCuo, Fecha.ObtenerAnoMesDia(xCob.FechaVencimientoCuota));
                xIns.AsignarParametro(CobranzaEN.CodCli, xCob.CodigoCliente);
                xIns.AsignarParametro(CobranzaEN.MonCuo, xCob.MontoCuota.ToString());
                xIns.AsignarParametro(CobranzaEN.FecDepCob, Fecha.ObtenerAnoMesDia(xCob.FechaDepositoCobranza));
                xIns.AsignarParametro(CobranzaEN.ImpCob, xCob.ImporteCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MonDesCob, xCob.MontoDescuentoCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MonMorCob, xCob.MontoMoraCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MonProCob, xCob.MontoProtestoCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MonOtrCob, xCob.MontoOtrosCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MonaCobCob, xCob.MontoaCobrarCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MonCobCob, xCob.MontoCobradoCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.CForCobCob, xCob.CFormaCobroCobranza);
                xIns.AsignarParametro(CobranzaEN.CModCobCob, xCob.CModoCobroCobranza);
                xIns.AsignarParametro(CobranzaEN.MonDolCob, xCob.MontoDolaresCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MonSolCob, xCob.MontoSolesCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MonComBcoCob, xCob.MontoComisionBcoCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.TipCamCob, xCob.TipoCambioCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.CLugCob, xCob.CLugarCobranza);
                xIns.AsignarParametro(CobranzaEN.ObsCob, xCob.ObservacionCobranza);
                xIns.AsignarParametro(CobranzaEN.ClaCom, xCob.ClaveComprobante);
                xIns.AsignarParametro(CobranzaEN.ClaComRetLet, xCob.ClaveComprobanteRetLet);
                xIns.AsignarParametro(CobranzaEN.ClaCtaBco, xCob.ClaveCuentaBanco);
                xIns.AsignarParametro(CobranzaEN.CTipCob, xCob.CTipoCobranza);
                xIns.AsignarParametro(CobranzaEN.CForPagLet, xCob.CFormaPagoLetra);
                xIns.AsignarParametro(CobranzaEN.EtaLot, xCob.EtapaLote);
                xIns.AsignarParametro(CobranzaEN.MzaLot, xCob.ManzanaLote);
                xIns.AsignarParametro(CobranzaEN.ClaNoIde, xCob.ClaveNoIdentificado);
                xIns.AsignarParametro(CobranzaEN.NumLot, xCob.NumeroLote);
                xIns.AsignarParametro(CobranzaEN.ClaVou, xCob.ClaveVoucher);
                xIns.AsignarParametro(CobranzaEN.CuoPagCob, xCob.CuotaPagadaCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.MorPagCob, xCob.MoraPagadaCobranza.ToString());
                xIns.AsignarParametro(CobranzaEN.CuoPenAnt, xCob.CuotaPendienteAnterior.ToString());
                xIns.AsignarParametro(CobranzaEN.MorAnt, xCob.MoraAnterior.ToString());
                xIns.AsignarParametro(CobranzaEN.MorPenAnt, xCob.MoraPendienteAnterior.ToString());
                xIns.AsignarParametro(CobranzaEN.CGenMorFijAnt, xCob.CGeneroMoraFijaAnterior);
                xIns.AsignarParametro(CobranzaEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(CobranzaEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(CobranzaEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(CobranzaEN.FecMod, "FECHAHORA");
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();    
            }
            
            xObjCon.Desconectar();
        }

        public void ModificarCobranza(CobranzaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);

            xUpd.AsignarParametro(CobranzaEN.FecDepCob, Fecha.ObtenerAnoMesDia(pObj.FechaDepositoCobranza));
            xUpd.AsignarParametro(CobranzaEN.ObsCob, pObj.ObservacionCobranza);
            xUpd.AsignarParametro(CobranzaEN.ClaCtaBco, pObj.ClaveCuentaBanco);
            xUpd.AsignarParametro(CobranzaEN.CForPagLet, pObj.CFormaPagoLetra);
            xUpd.AsignarParametro(CobranzaEN.ClaVou, pObj.ClaveVoucher);
            xUpd.AsignarParametro(CobranzaEN.ClaCom, pObj.ClaveComprobante);
            xUpd.AsignarParametro(CobranzaEN.ClaComRetLet, pObj.ClaveComprobanteRetLet);
            xUpd.AsignarParametro(CobranzaEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(CobranzaEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CorCob, SqlSelect.Operador.Igual, pObj.CorrelativoCobranza);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarCobranza(List< CobranzaEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (CobranzaEN xCob in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);

                xUpd.AsignarParametro(CobranzaEN.FecDepCob, Fecha.ObtenerAnoMesDia(xCob.FechaDepositoCobranza));
                xUpd.AsignarParametro(CobranzaEN.ObsCob, xCob.ObservacionCobranza);
                xUpd.AsignarParametro(CobranzaEN.ClaCtaBco, xCob.ClaveCuentaBanco);
                xUpd.AsignarParametro(CobranzaEN.CForPagLet, xCob.CFormaPagoLetra);
                xUpd.AsignarParametro(CobranzaEN.ClaVou, xCob.ClaveVoucher);
                xUpd.AsignarParametro(CobranzaEN.ClaCom, xCob.ClaveComprobante);
                xUpd.AsignarParametro(CobranzaEN.ClaComRetLet, xCob.ClaveComprobanteRetLet);
                xUpd.AsignarParametro(CobranzaEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(CobranzaEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CorCob, SqlSelect.Operador.Igual, xCob.CorrelativoCobranza);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();    
            }
            
            xObjCon.Desconectar();
        }
              
        public void EliminarCobranzaXCorrelativo(CobranzaEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CorCob, SqlSelect.Operador.Igual, pObj.CorrelativoCobranza);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        
        public void EliminarCobranzaDeCuota( CobranzaEN pObj )
        {
            xObjCon.Conectar( SqlDatos.Bd.Almacen_Produccion );
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete( );
            xDel.Tabla( this.xTabla );

            //condicion
            SqlSelect xSel = new SqlSelect( );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , CobranzaEN.ClaCuo , SqlSelect.Operador.Igual , pObj.ClaveCuota );          
            xDel.CondicionDelete( xSel.ObtenerScript( ) );

            xObjCon.ComandoTexto( xDel.ObtenerScript( ) );
            xObjCon.EjecutarSinResultado( );
            xObjCon.Desconectar( );
        }

        public void EliminarCobranzaMasiva(List< CobranzaEN> pLista )
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //eliminar cada objeto
            foreach (CobranzaEN xCob in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CorCob, SqlSelect.Operador.Igual, xCob.CorrelativoCobranza);                
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();    
            }
            
            xObjCon.Desconectar();
        }
                  
        public List<CobranzaEN> ListarCobranzasXAnoYMes(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.AnoCob, SqlSelect.Operador.Igual, pObj.AnoCobranza);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CobranzaEN.CMesCob, SqlSelect.Operador.Igual, pObj.CMesCobranza);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
      
        public List<CobranzaEN> ListarCobranzasXFecha(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.FecCob, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaCobranza));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }
       
        public List<CobranzaEN> ListarCobranzasXLetra( CobranzaEN pObj )
        {
            SqlSelect xSel = new SqlSelect( );
            xSel.SeleccionaVista( this.xVista );
            xSel.CondicionCV( SqlSelect.Reservada.Cuando , CobranzaEN.ClaCuo , SqlSelect.Operador.Igual , pObj.ClaveCuota );          
            xSel.Ordenar( pObj.Adicionales.CampoOrden , SqlSelect.Orden.Asc );
            return this.ListarObjetos( xSel.ObtenerScript( ) );
        }
        
        public CobranzaEN BuscarCobranzaXCorrelativo(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CorCob, SqlSelect.Operador.Igual, pObj.CorrelativoCobranza);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<CobranzaEN> ListarCobranzasXContrato(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CobranzaEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CobranzaEN> ListarCobranzasGeneradasDeRecepcionRec(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionINx(SqlSelect.Reservada.Cuando, CobranzaEN.CorCob, pObj.CorrelativoCobranza);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CobranzaEN> ListarCobranzaXFiltro(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);

            //filtro empresa
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);

            //filtro proyecto
            if (pObj.CodigoProyecto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, CobranzaEN.CodPro, SqlSelect.Operador.Igual, pObj.CodigoProyecto);
            }
         
            //Filtro Usuario
            if (pObj.UsuarioAgrega != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, CobranzaEN.UsuAgr, SqlSelect.Operador.Igual, pObj.UsuarioAgrega);
            }

            //filtro fecha 
            xSel.CondicionCV(SqlSelect.Reservada.Y, CobranzaEN.FecCob, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaCobranza));


            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CobranzaEN> ListarCobranzasXRangoFechaCobranza(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, CobranzaEN.FecCob, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1), Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CobranzaEN> ListarCobranzasXCuota(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.ClaCuo, SqlSelect.Operador.Igual, pObj.ClaveCuota);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<CobranzaEN> ListarCobranzasParaSaldosAMes(CobranzaEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, CobranzaEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, CobranzaEN.FecCob, SqlSelect.Operador.MayorIgual, Fecha.ObtenerAnoMesDia(pObj.FechaCobranza));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


    }
}
