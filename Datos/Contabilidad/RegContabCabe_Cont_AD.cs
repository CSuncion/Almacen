using Comun;
using Datos.Config;
using Entidades;
using Entidades.Adicionales;
using Entidades.Contabilidad;
using ScriptBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contabilidad
{
    public class RegContabCabe_Cont_AD
    {
        private SqlDatos xObjCon = new SqlDatos();
        private List<RegContabCabe_Cont_EN> xLista = new List<RegContabCabe_Cont_EN>();
        private RegContabCabe_Cont_EN xObj = new RegContabCabe_Cont_EN();
        //private string xTabla = "RegContabDeta";
        private string xVista = "VsRegContabCabe";
        private string xTabla = "RegContabCabe";
        private RegContabCabe_Cont_EN Objeto(IDataReader iDr)
        {
            RegContabCabe_Cont_EN xObjEnc = new RegContabCabe_Cont_EN();
            xObjEnc.ClaveRegContabCabe = iDr[RegContabCabe_Cont_EN._ClaveRegContabCabe].ToString();
            xObjEnc.CodigoEmpresa = iDr[RegContabCabe_Cont_EN._CodigoEmpresa].ToString();
            xObjEnc.PeriodoRegContabCabe = iDr[RegContabCabe_Cont_EN._PeriodoRegContabCabe].ToString();
            xObjEnc.CodigoOrigen = iDr[RegContabCabe_Cont_EN._CodigoOrigen].ToString();
            xObjEnc.CodigoFile = iDr[RegContabCabe_Cont_EN._CodigoFile].ToString();
            xObjEnc.NumeroVoucherRegContabCabe = iDr[RegContabCabe_Cont_EN._NumeroVoucherRegContabCabe].ToString();
            xObjEnc.FechaVoucherRegContabCabe = iDr[RegContabCabe_Cont_EN._FechaVoucherRegContabCabe].ToString();
            xObjEnc.CodigoAuxiliar = iDr[RegContabCabe_Cont_EN._CodigoAuxiliar].ToString();

            xObjEnc.TipoDocumento = iDr[RegContabCabe_Cont_EN._TipoDocumento].ToString();
            xObjEnc.SerieDocumento = iDr[RegContabCabe_Cont_EN._SerieDocumento].ToString();
            xObjEnc.NumeroDocumento = iDr[RegContabCabe_Cont_EN._NumeroDocumento].ToString();
            xObjEnc.FechaDocumento = iDr[RegContabCabe_Cont_EN._FechaDocumento].ToString();
            xObjEnc.FechaVencimiento = iDr[RegContabCabe_Cont_EN._FechaVencimiento].ToString();
            xObjEnc.MonedaDocumento = iDr[RegContabCabe_Cont_EN._CMonedaDocumento].ToString();
            xObjEnc.TipoDocumento1 = iDr[RegContabCabe_Cont_EN._CTipoDocumentoRef].ToString();
            xObjEnc.SerieDocumento1 = iDr[RegContabCabe_Cont_EN._SerieDocumentoRef].ToString();
            xObjEnc.NumeroDocumento1 = iDr[RegContabCabe_Cont_EN._NumeroDocumentoRef].ToString();
            xObjEnc.FechaDocumento1 = iDr[RegContabCabe_Cont_EN._FechaDocumentoRef].ToString();
            xObjEnc.MonedaDocumento1 = iDr[RegContabCabe_Cont_EN._CMonedaDocumentoRef].ToString();
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._VentaTipoCambio]);
            xObjEnc.IgvPar = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._PorcentajeIgv]);
            xObjEnc.ValorVtaRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ValorVentaRegContabCabe]);
            xObjEnc.IgvRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._IgvRegContabCabe]);
            xObjEnc.ExoneradoRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ExoneradoRegContabCabe]);
            xObjEnc.PrecioVtaRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._PrecioVentaRegContabCabe]);
            xObjEnc.IgvSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._IgvSolRegContabCabe]);
            xObjEnc.ExoneradoSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ExoneradoSolRegContabCabe]);
            xObjEnc.PrecioVtaSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._PrecioVentaSolRegContabCabe]);
            xObjEnc.GlosaRegContabCabe = iDr[RegContabCabe_Cont_EN._GlosaRegContabCabe].ToString();
            xObjEnc.DetraccionRegContabCabe = iDr[RegContabCabe_Cont_EN._CAplicaDetraccion].ToString();
            xObjEnc.NumeroPapeletaRegContabCabe = iDr[RegContabCabe_Cont_EN._NumeroPapeletaDetraccion].ToString();
            xObjEnc.FechaDetraccionRegContabCabe = iDr[RegContabCabe_Cont_EN._FechaDetraccion].ToString();
            xObjEnc.CodigoCuentaBanco = iDr[RegContabCabe_Cont_EN._CodigoCuenta].ToString();
            xObjEnc.RetencionRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._RetencionHonorario]);
            xObjEnc.ImporteRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ImporteRegContabCabe]);
            xObjEnc.ImporteSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ImporteSolRegContabCabe]);
            xObjEnc.CodigoModoPago = iDr[RegContabCabe_Cont_EN._CModoPago].ToString();
            xObjEnc.CartaRegContabCabe = iDr[RegContabCabe_Cont_EN._CartaRegContabCabe].ToString();
            xObjEnc.EstadoRegContabCabe = iDr[RegContabCabe_Cont_EN._EstadoRegContabCabe].ToString();
            xObjEnc.UsuarioAgrega = iDr[RegContabCabe_Cont_EN._UsuarioAgrega].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RegContabCabe_Cont_EN._FechaAgrega]);
            xObjEnc.UsuarioModifica = iDr[RegContabCabe_Cont_EN._UsuarioModifica].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RegContabCabe_Cont_EN._FechaModifica]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRegContabCabe;
            return xObjEnc;
        }

        private List<RegContabCabe_Cont_EN> ListarObjetos(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
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

        private RegContabCabe_Cont_EN BuscarObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
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
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
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
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
            xObjCon.ComandoTexto(pScript);
            string iValor = xObjCon.ObtenerValor();
            xObjCon.Desconectar();
            return iValor;
        }

        public void AgregarRegContaCabe(RegContabCabe_Cont_EN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.contabilidad);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ClaveRegContabCabe, pObj.ClaveRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CodigoEmpresa, pObj.CodigoEmpresa.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._PeriodoRegContabCabe, pObj.PeriodoRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CodigoOrigen, pObj.CodigoOrigen.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CodigoFile, pObj.CodigoFile.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._NumeroVoucherRegContabCabe, pObj.NumeroVoucherRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaVoucherRegContabCabe, Fecha.ObtenerAnoMesDia(pObj.FechaVoucherRegContabCabe));
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CodigoAuxiliar, pObj.CodigoAuxiliar.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._DiaVoucherRegContabCabe, Fecha.ObtenerNumeroDia(Convert.ToDateTime(pObj.FechaVoucherRegContabCabe)));

            xIns.AsignarParametro(RegContabCabe_Cont_EN._TipoDocumento, pObj.TipoDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._SerieDocumento, pObj.SerieDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._NumeroDocumento, pObj.NumeroDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaDocumento, Fecha.ObtenerAnoMesDia(pObj.FechaDocumento));
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaVencimiento, Fecha.ObtenerAnoMesDia(pObj.FechaVencimiento));
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CMonedaDocumento, pObj.MonedaDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CTipoDocumentoRef, pObj.TipoDocumento1.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._SerieDocumentoRef, pObj.SerieDocumento1.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._NumeroDocumentoRef, pObj.NumeroDocumento1.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaDocumentoRef, Fecha.ObtenerDiaMesAno(pObj.FechaDocumento1));
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CMonedaDocumentoRef, pObj.MonedaDocumento1.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._VentaTipoCambio, pObj.VentaTipoCambio.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._PorcentajeIgv, pObj.IgvPar.ToString());


            xIns.AsignarParametro(RegContabCabe_Cont_EN._ValorVentaRegContabCabe, pObj.ValorVtaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._IgvRegContabCabe, pObj.IgvRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ExoneradoRegContabCabe, pObj.ExoneradoRegContabCabe.ToString());

            xIns.AsignarParametro(RegContabCabe_Cont_EN._PrecioVentaRegContabCabe, pObj.PrecioVtaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._IgvSolRegContabCabe, pObj.IgvSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ExoneradoSolRegContabCabe, pObj.ExoneradoSolRegContabCabe.ToString());

            xIns.AsignarParametro(RegContabCabe_Cont_EN._PrecioVentaSolRegContabCabe, pObj.PrecioVtaSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._GlosaRegContabCabe, pObj.GlosaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CAplicaDetraccion, pObj.DetraccionRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._NumeroPapeletaDetraccion, pObj.NumeroPapeletaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaDetraccion, Fecha.ObtenerDiaMesAno(pObj.FechaDetraccionRegContabCabe));
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CodigoCuenta, pObj.CodigoCuentaBanco.ToString());

            xIns.AsignarParametro(RegContabCabe_Cont_EN._RetencionHonorario, pObj.RetencionRegContabCabe.ToString());

            xIns.AsignarParametro(RegContabCabe_Cont_EN._ImporteRegContabCabe, pObj.ImporteRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ImporteSolRegContabCabe, pObj.ImporteSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CModoPago, pObj.CodigoModoPago.ToString());

            xIns.AsignarParametro(RegContabCabe_Cont_EN._CartaRegContabCabe, pObj.CartaRegContabCabe.ToString());

            xIns.AsignarParametro(RegContabCabe_Cont_EN._EstadoRegContabCabe, pObj.EstadoRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._UsuarioAgrega, pObj.UsuarioAgrega.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaAgrega, "FECHAHORA");
            xIns.AsignarParametro(RegContabCabe_Cont_EN._UsuarioModifica, pObj.UsuarioModifica.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaModifica, "FECHAHORA");

            xIns.FinParametros();

            xObjCon.ComandoTexto(xIns.ObtenerScript());
            xObjCon.EjecutarSinResultado();
            xObjCon.Desconectar();
        }
        public string ObtenerMaximoValorEnColumna(RegContabCabe_Cont_EN pObj)
        {
            SqlSelect xSel = new SqlSelect();
            xSel.ObtenerMaximoValor(this.xVista, RegContabCabe_Cont_EN._NumeroVoucherRegContabCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabe_Cont_EN._CodigoEmpresa, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabe_Cont_EN._PeriodoRegContabCabe, SqlSelect.Operador.Igual, pObj.PeriodoRegContabCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabe_Cont_EN._CodigoOrigen, SqlSelect.Operador.Igual, pObj.CodigoOrigen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabe_Cont_EN._CodigoFile, SqlSelect.Operador.Igual, pObj.CodigoFile);
            return this.ObtenerValor(xSel.ObtenerScript());
        }
    }
}
