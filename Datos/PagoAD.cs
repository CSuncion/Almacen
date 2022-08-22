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
    public class PagoAD
    {
        //variables de trabajo
        private SqlDatos xObjCon = new SqlDatos();
        private List<PagoEN> xLista = new List<PagoEN>();
        private PagoEN xObj = new PagoEN();
        private string xTabla = "Pago";
        private string xVista = "VsPago";


        #region Metodos privados

        private PagoEN Objeto(IDataReader iDr)
        {
            PagoEN xObjEnc = new PagoEN();
            xObjEnc.CorrelativoPago = iDr[PagoEN.CorPag].ToString();
            xObjEnc.FechaPagoCuota = Fecha.ObtenerDiaMesAno(iDr[PagoEN.FecPagCuo].ToString());
            xObjEnc.FechaPago = Fecha.ObtenerDiaMesAno(iDr[PagoEN.FecPag]);
            xObjEnc.AnoPago = iDr[PagoEN.AnoPag].ToString();
            xObjEnc.CMesPago = iDr[PagoEN.CMesPag].ToString();
            xObjEnc.NMesPago = iDr[PagoEN.NMesPag].ToString();
            xObjEnc.ClaveCuota = iDr[PagoEN.ClaCuo].ToString();
            xObjEnc.NumeroContrato = iDr[PagoEN.NumCon].ToString();
            xObjEnc.CodigoEmpresa = iDr[PagoEN.CodEmp].ToString();
            xObjEnc.NombreEmpresa = iDr[PagoEN.NomEmp].ToString();
            xObjEnc.CodigoProyecto = iDr[PagoEN.CodPro].ToString();
            xObjEnc.FechaVencimientoCuota = Fecha.ObtenerDiaMesAno(iDr[PagoEN.FecVenCuo]);
            xObjEnc.MontoCuota = Convert.ToDecimal(iDr[PagoEN.MonCuo].ToString());
            xObjEnc.FechaDepositoPago = Fecha.ObtenerDiaMesAno(iDr[PagoEN.FecDepPag]);
            xObjEnc.ImportePago = Convert.ToDecimal(iDr[PagoEN.ImpPag].ToString());
            xObjEnc.MontoDescuentoPago = Convert.ToDecimal(iDr[PagoEN.MonDesPag].ToString());
            xObjEnc.MontoMoraPago = Convert.ToDecimal(iDr[PagoEN.MonMorPag].ToString());
            xObjEnc.MontoProtestoPago = Convert.ToDecimal(iDr[PagoEN.MonProPag].ToString());
            xObjEnc.MontoOtrosPago = Convert.ToDecimal(iDr[PagoEN.MonOtrPag].ToString());
            xObjEnc.MontoaCobrarPago = Convert.ToDecimal(iDr[PagoEN.MonaCobPag].ToString());
            xObjEnc.MontoCobradoPago = Convert.ToDecimal(iDr[PagoEN.MonCobPag].ToString());
            xObjEnc.CFormaCobroPago = iDr[PagoEN.CForCobPag].ToString();
            xObjEnc.NFormaCobroPago = iDr[PagoEN.NForCobPag].ToString();
            xObjEnc.CModoCobroPago = iDr[PagoEN.CModCobPag].ToString();
            xObjEnc.NModoCobroPago = iDr[PagoEN.NModCobPag].ToString();
            xObjEnc.MontoDolaresPago = Convert.ToDecimal(iDr[PagoEN.MonDolPag].ToString());
            xObjEnc.MontoSolesPago = Convert.ToDecimal(iDr[PagoEN.MonSolPag].ToString());
            xObjEnc.MontoComisionBcoPago = Convert.ToDecimal(iDr[PagoEN.MonComBcoPag].ToString());
            xObjEnc.TipoCambioPago = Convert.ToDecimal(iDr[PagoEN.TipCamPag].ToString());
            xObjEnc.CLugarPago = iDr[PagoEN.CLugPag].ToString();
            xObjEnc.NLugarPago = iDr[PagoEN.NLugPag].ToString();
            xObjEnc.ObservacionPago = iDr[PagoEN.ObsPag].ToString();
            xObjEnc.ClaveComprobante = iDr[PagoEN.ClaCom].ToString();
            xObjEnc.ClaveComprobanteRetLet = iDr[PagoEN.ClaComRetLet].ToString();
            xObjEnc.ClaveCuentaBanco = iDr[PagoEN.ClaCtaBco].ToString();
            xObjEnc.AgenciaCuentaBanco = iDr[PagoEN.AgeCtaBco].ToString();
            xObjEnc.NumeroCuentaBanco = iDr[PagoEN.NumCtaBco].ToString();
            xObjEnc.CodigoCuentaBanco = iDr[PagoEN.CodCueBco].ToString();
            xObjEnc.CodigoBanco = iDr[PagoEN.CodBco].ToString();
            xObjEnc.NombreBanco = iDr[PagoEN.NomBco].ToString();
            xObjEnc.NMonedaCuentaBanco = iDr[PagoEN.NMonCtaBco].ToString();
            xObjEnc.CTipoPago = iDr[PagoEN.CTipPag].ToString();
            xObjEnc.NTipoPago = iDr[PagoEN.NTipPag].ToString();
            xObjEnc.CFormaPagoLetra = iDr[PagoEN.CForPagLet].ToString();
            xObjEnc.NFormaPagoLetra = iDr[PagoEN.NForPagLet].ToString();
            xObjEnc.EtapaLote = iDr[PagoEN.EtaLot].ToString();
            xObjEnc.ManzanaLote = iDr[PagoEN.MzaLot].ToString();
            xObjEnc.NumeroLote = iDr[PagoEN.NumLot].ToString();
            xObjEnc.ClaveNoIdentificado = iDr[PagoEN.ClaNoIde].ToString();
            xObjEnc.ClaveVoucher = iDr[PagoEN.ClaVou].ToString();
            //xObjEnc.CorrelativoVoucher = iDr[PagoEN.CorVou].ToString();
            //xObjEnc.MontoVoucher =Convert.ToDecimal( iDr[PagoEN.MonVou].ToString());
            xObjEnc.CuotaPagadaPago = Convert.ToDecimal(iDr[PagoEN.CuoPagPag].ToString());
            xObjEnc.MoraPagadaPago = Convert.ToDecimal(iDr[PagoEN.MorPagPag].ToString());
            xObjEnc.CuotaPendienteAnterior = Convert.ToDecimal(iDr[PagoEN.CuoPenAnt].ToString());
            xObjEnc.MoraAnterior = Convert.ToDecimal(iDr[PagoEN.MorAnt].ToString());
            xObjEnc.MoraPendienteAnterior = Convert.ToDecimal(iDr[PagoEN.MorPenAnt].ToString());
            xObjEnc.CGeneroMoraFijaAnterior = iDr[PagoEN.CGenMorFijAnt].ToString();
            xObjEnc.NGeneroMoraFijaAnterior = iDr[PagoEN.NGenMorFijAnt].ToString();
            xObjEnc.UsuarioAgrega = iDr[PagoEN.UsuAgr].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[PagoEN.FecAgr]);
            xObjEnc.UsuarioModifica = iDr[PagoEN.UsuMod].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[PagoEN.FecMod]);
            xObjEnc.CodigoAuxiliar = iDr[PagoEN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[PagoEN.DesAux].ToString();
            xObjEnc.ClaveObjeto = xObjEnc.CorrelativoPago;
            return xObjEnc;
        }

        private List<PagoEN> ListarObjetos(string pScript)
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

        private PagoEN BuscarObjeto(string pScript)
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

        public void AdicionarPago(PagoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(PagoEN.CodEmp, pObj.CodigoEmpresa);
            xIns.AsignarParametro(PagoEN.CodPro, pObj.CodigoProyecto);
            xIns.AsignarParametro(PagoEN.CorPag, pObj.CorrelativoPago);
            xIns.AsignarParametro(PagoEN.FecPagCuo, Fecha.ObtenerAnoMesDia(pObj.FechaPagoCuota));
            xIns.AsignarParametro(PagoEN.FecPag, Fecha.ObtenerAnoMesDia(pObj.FechaPago));
            xIns.AsignarParametro(PagoEN.AnoPag, pObj.AnoPago);
            xIns.AsignarParametro(PagoEN.CMesPag, pObj.CMesPago);
            xIns.AsignarParametro(PagoEN.ClaCuo, pObj.ClaveCuota);
            xIns.AsignarParametro(PagoEN.NumCon, pObj.NumeroContrato);
            xIns.AsignarParametro(PagoEN.FecVenCuo, Fecha.ObtenerAnoMesDia(pObj.FechaVencimientoCuota));
            xIns.AsignarParametro(PagoEN.MonCuo, pObj.MontoCuota.ToString());
            xIns.AsignarParametro(PagoEN.FecDepPag, Fecha.ObtenerAnoMesDia(pObj.FechaDepositoPago));
            xIns.AsignarParametro(PagoEN.ImpPag, pObj.ImportePago.ToString());
            xIns.AsignarParametro(PagoEN.MonDesPag, pObj.MontoDescuentoPago.ToString());
            xIns.AsignarParametro(PagoEN.MonMorPag, pObj.MontoMoraPago.ToString());
            xIns.AsignarParametro(PagoEN.MonProPag, pObj.MontoProtestoPago.ToString());
            xIns.AsignarParametro(PagoEN.MonOtrPag, pObj.MontoOtrosPago.ToString());
            xIns.AsignarParametro(PagoEN.MonaCobPag, pObj.MontoaCobrarPago.ToString());
            xIns.AsignarParametro(PagoEN.MonCobPag, pObj.MontoCobradoPago.ToString());
            xIns.AsignarParametro(PagoEN.CForCobPag, pObj.CFormaCobroPago);
            xIns.AsignarParametro(PagoEN.CModCobPag, pObj.CModoCobroPago);
            xIns.AsignarParametro(PagoEN.MonDolPag, pObj.MontoDolaresPago.ToString());
            xIns.AsignarParametro(PagoEN.MonSolPag, pObj.MontoSolesPago.ToString());
            xIns.AsignarParametro(PagoEN.MonComBcoPag, pObj.MontoComisionBcoPago.ToString());
            xIns.AsignarParametro(PagoEN.TipCamPag, pObj.TipoCambioPago.ToString());
            xIns.AsignarParametro(PagoEN.CLugPag, pObj.CLugarPago);
            xIns.AsignarParametro(PagoEN.ObsPag, pObj.ObservacionPago);
            xIns.AsignarParametro(PagoEN.ClaCom, pObj.ClaveComprobante);
            xIns.AsignarParametro(PagoEN.ClaComRetLet, pObj.ClaveComprobanteRetLet);
            xIns.AsignarParametro(PagoEN.ClaCtaBco, pObj.ClaveCuentaBanco);
            xIns.AsignarParametro(PagoEN.CTipPag, pObj.CTipoPago);
            xIns.AsignarParametro(PagoEN.CForPagLet, pObj.CFormaPagoLetra);
            xIns.AsignarParametro(PagoEN.EtaLot, pObj.EtapaLote);
            xIns.AsignarParametro(PagoEN.MzaLot, pObj.ManzanaLote);
            xIns.AsignarParametro(PagoEN.ClaNoIde, pObj.ClaveNoIdentificado);
            xIns.AsignarParametro(PagoEN.NumLot, pObj.NumeroLote);
            xIns.AsignarParametro(PagoEN.ClaVou, pObj.ClaveVoucher);
            xIns.AsignarParametro(PagoEN.CuoPagPag, pObj.CuotaPagadaPago.ToString());
            xIns.AsignarParametro(PagoEN.MorPagPag, pObj.MoraPagadaPago.ToString());
            xIns.AsignarParametro(PagoEN.CuoPenAnt, pObj.CuotaPendienteAnterior.ToString());
            xIns.AsignarParametro(PagoEN.MorAnt, pObj.MoraAnterior.ToString());
            xIns.AsignarParametro(PagoEN.MorPenAnt, pObj.MoraPendienteAnterior.ToString());
            xIns.AsignarParametro(PagoEN.CGenMorFijAnt, pObj.CGeneroMoraFijaAnterior);
            xIns.AsignarParametro(PagoEN.CodAux, pObj.CodigoAuxiliar);
            xIns.AsignarParametro(PagoEN.UsuAgr, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PagoEN.FecAgr, "FECHAHORA");
            xIns.AsignarParametro(PagoEN.UsuMod, Universal.gCodigoUsuario);
            xIns.AsignarParametro(PagoEN.FecMod, "FECHAHORA");
            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void AdicionarPagoMasivo(List<PagoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //insertar cada objeto
            foreach (PagoEN xCob in pLista)
            {
                //armando escript para insertar
                SqlInsert xIns = new SqlInsert();
                xIns.Tabla(this.xTabla);
                xIns.AsignarParametro(PagoEN.CodEmp, xCob.CodigoEmpresa);
                xIns.AsignarParametro(PagoEN.CodPro, xCob.CodigoProyecto);
                xIns.AsignarParametro(PagoEN.CorPag, xCob.CorrelativoPago);
                xIns.AsignarParametro(PagoEN.FecPagCuo, Fecha.ObtenerAnoMesDia(xCob.FechaPagoCuota));
                xIns.AsignarParametro(PagoEN.FecPag, Fecha.ObtenerAnoMesDia(xCob.FechaPago));
                xIns.AsignarParametro(PagoEN.AnoPag, xCob.AnoPago);
                xIns.AsignarParametro(PagoEN.CMesPag, xCob.CMesPago);
                xIns.AsignarParametro(PagoEN.ClaCuo, xCob.ClaveCuota);
                xIns.AsignarParametro(PagoEN.NumCon, xCob.NumeroContrato);
                xIns.AsignarParametro(PagoEN.FecVenCuo, Fecha.ObtenerAnoMesDia(xCob.FechaVencimientoCuota));
                xIns.AsignarParametro(PagoEN.MonCuo, xCob.MontoCuota.ToString());
                xIns.AsignarParametro(PagoEN.FecDepPag, Fecha.ObtenerAnoMesDia(xCob.FechaDepositoPago));
                xIns.AsignarParametro(PagoEN.ImpPag, xCob.ImportePago.ToString());
                xIns.AsignarParametro(PagoEN.MonDesPag, xCob.MontoDescuentoPago.ToString());
                xIns.AsignarParametro(PagoEN.MonMorPag, xCob.MontoMoraPago.ToString());
                xIns.AsignarParametro(PagoEN.MonProPag, xCob.MontoProtestoPago.ToString());
                xIns.AsignarParametro(PagoEN.MonOtrPag, xCob.MontoOtrosPago.ToString());
                xIns.AsignarParametro(PagoEN.MonaCobPag, xCob.MontoaCobrarPago.ToString());
                xIns.AsignarParametro(PagoEN.MonCobPag, xCob.MontoCobradoPago.ToString());
                xIns.AsignarParametro(PagoEN.CForCobPag, xCob.CFormaCobroPago);
                xIns.AsignarParametro(PagoEN.CModCobPag, xCob.CModoCobroPago);
                xIns.AsignarParametro(PagoEN.MonDolPag, xCob.MontoDolaresPago.ToString());
                xIns.AsignarParametro(PagoEN.MonSolPag, xCob.MontoSolesPago.ToString());
                xIns.AsignarParametro(PagoEN.MonComBcoPag, xCob.MontoComisionBcoPago.ToString());
                xIns.AsignarParametro(PagoEN.TipCamPag, xCob.TipoCambioPago.ToString());
                xIns.AsignarParametro(PagoEN.CLugPag, xCob.CLugarPago);
                xIns.AsignarParametro(PagoEN.ObsPag, xCob.ObservacionPago);
                xIns.AsignarParametro(PagoEN.ClaCom, xCob.ClaveComprobante);
                xIns.AsignarParametro(PagoEN.ClaComRetLet, xCob.ClaveComprobanteRetLet);
                xIns.AsignarParametro(PagoEN.ClaCtaBco, xCob.ClaveCuentaBanco);
                xIns.AsignarParametro(PagoEN.CTipPag, xCob.CTipoPago);
                xIns.AsignarParametro(PagoEN.CForPagLet, xCob.CFormaPagoLetra);
                xIns.AsignarParametro(PagoEN.EtaLot, xCob.EtapaLote);
                xIns.AsignarParametro(PagoEN.MzaLot, xCob.ManzanaLote);
                xIns.AsignarParametro(PagoEN.ClaNoIde, xCob.ClaveNoIdentificado);
                xIns.AsignarParametro(PagoEN.NumLot, xCob.NumeroLote);
                xIns.AsignarParametro(PagoEN.ClaVou, xCob.ClaveVoucher);
                xIns.AsignarParametro(PagoEN.CuoPagPag, xCob.CuotaPagadaPago.ToString());
                xIns.AsignarParametro(PagoEN.MorPagPag, xCob.MoraPagadaPago.ToString());
                xIns.AsignarParametro(PagoEN.CuoPenAnt, xCob.CuotaPendienteAnterior.ToString());
                xIns.AsignarParametro(PagoEN.MorAnt, xCob.MoraAnterior.ToString());
                xIns.AsignarParametro(PagoEN.MorPenAnt, xCob.MoraPendienteAnterior.ToString());
                xIns.AsignarParametro(PagoEN.CGenMorFijAnt, xCob.CGeneroMoraFijaAnterior);
                xIns.AsignarParametro(PagoEN.UsuAgr, Universal.gCodigoUsuario);
                xIns.AsignarParametro(PagoEN.FecAgr, "FECHAHORA");
                xIns.AsignarParametro(PagoEN.UsuMod, Universal.gCodigoUsuario);
                xIns.AsignarParametro(PagoEN.FecMod, "FECHAHORA");
                xIns.AsignarParametro(PagoEN.CodAux, xCob.CodigoAuxiliar);
                xIns.FinParametros();

                xObjCon.ComandoTexto(xIns.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void ModificarPago(PagoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para actualizar
            SqlUpdate xUpd = new SqlUpdate();
            xUpd.Tabla(this.xTabla);

            xUpd.AsignarParametro(PagoEN.FecDepPag, Fecha.ObtenerAnoMesDia(pObj.FechaDepositoPago));
            xUpd.AsignarParametro(PagoEN.ObsPag, pObj.ObservacionPago);
            xUpd.AsignarParametro(PagoEN.ClaCtaBco, pObj.ClaveCuentaBanco);
            xUpd.AsignarParametro(PagoEN.CForPagLet, pObj.CFormaPagoLetra);
            xUpd.AsignarParametro(PagoEN.ClaVou, pObj.ClaveVoucher);
            xUpd.AsignarParametro(PagoEN.ClaCom, pObj.ClaveComprobante);
            xUpd.AsignarParametro(PagoEN.ClaComRetLet, pObj.ClaveComprobanteRetLet);
            xUpd.AsignarParametro(PagoEN.UsuMod, Universal.gCodigoUsuario);
            xUpd.AsignarParametro(PagoEN.FecMod, "FECHAHORA");
            xUpd.FinParametros();

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CorPag, SqlSelect.Operador.Igual, pObj.CorrelativoPago);
            xUpd.CondicionUpdate(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xUpd.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void ModificarPago(List<PagoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //recorrer cada objeto
            foreach (PagoEN xCob in pLista)
            {
                //armando escript para actualizar
                SqlUpdate xUpd = new SqlUpdate();
                xUpd.Tabla(this.xTabla);

                xUpd.AsignarParametro(PagoEN.FecDepPag, Fecha.ObtenerAnoMesDia(xCob.FechaDepositoPago));
                xUpd.AsignarParametro(PagoEN.ObsPag, xCob.ObservacionPago);
                xUpd.AsignarParametro(PagoEN.ClaCtaBco, xCob.ClaveCuentaBanco);
                xUpd.AsignarParametro(PagoEN.CForPagLet, xCob.CFormaPagoLetra);
                xUpd.AsignarParametro(PagoEN.ClaVou, xCob.ClaveVoucher);
                xUpd.AsignarParametro(PagoEN.ClaCom, xCob.ClaveComprobante);
                xUpd.AsignarParametro(PagoEN.ClaComRetLet, xCob.ClaveComprobanteRetLet);
                xUpd.AsignarParametro(PagoEN.UsuMod, Universal.gCodigoUsuario);
                xUpd.AsignarParametro(PagoEN.FecMod, "FECHAHORA");
                xUpd.FinParametros();

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CorPag, SqlSelect.Operador.Igual, xCob.CorrelativoPago);
                xUpd.CondicionUpdate(xSel.ObtenerScript());

                //ejecutar
                xObjCon.ComandoTexto(xUpd.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public void EliminarPagoXCorrelativo(PagoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CorPag, SqlSelect.Operador.Igual, pObj.CorrelativoPago);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPagoDeCuota(PagoEN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);
            //armando escript para eliminar
            SqlDelete xDel = new SqlDelete();
            xDel.Tabla(this.xTabla);

            //condicion
            SqlSelect xSel = new SqlSelect();
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.ClaCuo, SqlSelect.Operador.Igual, pObj.ClaveCuota);
            xDel.CondicionDelete(xSel.ObtenerScript());

            xObjCon.ComandoTexto(xDel.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }

        public void EliminarPagoMasiva(List<PagoEN> pLista)
        {
            xObjCon.Conectar(SqlDatos.Bd.Almacen_Produccion);

            //eliminar cada objeto
            foreach (PagoEN xCob in pLista)
            {
                //armando escript para eliminar
                SqlDelete xDel = new SqlDelete();
                xDel.Tabla(this.xTabla);

                //condicion
                SqlSelect xSel = new SqlSelect();
                xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CorPag, SqlSelect.Operador.Igual, xCob.CorrelativoPago);
                xDel.CondicionDelete(xSel.ObtenerScript());

                xObjCon.ComandoTexto(xDel.ObtenerScript());
                xObjCon.EjecutarSinResultado();
            }

            xObjCon.Desconectar();
        }

        public List<PagoEN> ListarPagosXAnoYMes(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.AnoPag, SqlSelect.Operador.Igual, pObj.AnoPago);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PagoEN.CMesPag, SqlSelect.Operador.Igual, pObj.CMesPago);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PagoEN> ListarPagosXFecha(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.FecPag, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaPago));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PagoEN> ListarPagosXLetra(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.ClaCuo, SqlSelect.Operador.Igual, pObj.ClaveCuota);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public PagoEN BuscarPagoXCorrelativo(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CorPag, SqlSelect.Operador.Igual, pObj.CorrelativoPago);
            return this.BuscarObjeto(xSel.ObtenerScript());
        }

        public List<PagoEN> ListarPagosXContrato(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PagoEN.NumCon, SqlSelect.Operador.Igual, pObj.NumeroContrato);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PagoEN> ListarPagosGeneradasDeRecepcionRec(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionINx(SqlSelect.Reservada.Cuando, PagoEN.CorPag, pObj.CorrelativoPago);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PagoEN> ListarPagoXFiltro(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);

            //filtro empresa
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);

            //filtro proyecto
            if (pObj.CodigoProyecto != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, PagoEN.CodPro, SqlSelect.Operador.Igual, pObj.CodigoProyecto);
            }

            //Filtro Usuario
            if (pObj.UsuarioAgrega != string.Empty)
            {
                xSel.CondicionCV(SqlSelect.Reservada.Y, PagoEN.UsuAgr, SqlSelect.Operador.Igual, pObj.UsuarioAgrega);
            }

            //filtro fecha 
            xSel.CondicionCV(SqlSelect.Reservada.Y, PagoEN.FecPag, SqlSelect.Operador.Igual, Fecha.ObtenerAnoMesDia(pObj.FechaPago));


            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PagoEN> ListarPagosXRangoFechaPago(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionBetween(SqlSelect.Reservada.Y, PagoEN.FecPag, Fecha.ObtenerAnoMesDia(pObj.Adicionales.Desde1), Fecha.ObtenerAnoMesDia(pObj.Adicionales.Hasta1));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PagoEN> ListarPagosXComprobante(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.ClaCom, SqlSelect.Operador.Igual, pObj.ClaveComprobante);
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }

        public List<PagoEN> ListarPagosParaSaldosAMes(PagoEN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.SeleccionaVista(this.xVista);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, PagoEN.CodEmp, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, PagoEN.FecPag, SqlSelect.Operador.MayorIgual, Fecha.ObtenerAnoMesDia(pObj.FechaPago));
            xSel.Ordenar(pObj.Adicionales.CampoOrden, SqlSelect.Orden.Asc);
            return this.ListarObjetos(xSel.ObtenerScript());
        }


    }
}
