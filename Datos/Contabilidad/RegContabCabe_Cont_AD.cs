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
            xObjEnc.COrigen = iDr[RegContabCabe_Cont_EN._COrigen].ToString();
            xObjEnc.CFile = iDr[RegContabCabe_Cont_EN._CFile].ToString();
            xObjEnc.CorrelativoRegContabCabe = iDr[RegContabCabe_Cont_EN._CorrelativoRegContabCabe].ToString();
            xObjEnc.FechaRegContabCabe = iDr[RegContabCabe_Cont_EN._FechaRegContabCabe].ToString();
            xObjEnc.CodigoAuxiliar = iDr[RegContabCabe_Cont_EN._CodigoAuxiliar].ToString();
            xObjEnc.CModoCompra = iDr[RegContabCabe_Cont_EN._CModoCompra].ToString();
            xObjEnc.CTipoCompra = iDr[RegContabCabe_Cont_EN._CTipoCompra].ToString();
            xObjEnc.CTipoDocumento = iDr[RegContabCabe_Cont_EN._CTipoDocumento].ToString();
            xObjEnc.SerieDocumento = iDr[RegContabCabe_Cont_EN._SerieDocumento].ToString();
            xObjEnc.NumeroDocumento = iDr[RegContabCabe_Cont_EN._NumeroDocumento].ToString();
            xObjEnc.FechaDocumento = iDr[RegContabCabe_Cont_EN._FechaDocumento].ToString();
            xObjEnc.FechaVctoDocumento = iDr[RegContabCabe_Cont_EN._FechaVctoDocumento].ToString();
            xObjEnc.CMonedaDocumento = iDr[RegContabCabe_Cont_EN._CMonedaDocumento].ToString();
            xObjEnc.CTipoDocumentoRef = iDr[RegContabCabe_Cont_EN._CTipoDocumentoRef].ToString();
            xObjEnc.SerieDocumentoRef = iDr[RegContabCabe_Cont_EN._SerieDocumentoRef].ToString();
            xObjEnc.NumeroDocumentoRef = iDr[RegContabCabe_Cont_EN._NumeroDocumentoRef].ToString();
            xObjEnc.FechaDocumentoRef = iDr[RegContabCabe_Cont_EN._FechaDocumentoRef].ToString();
            xObjEnc.FechaVctoDocumentoRef = iDr[RegContabCabe_Cont_EN._FechaVctoDocumentoRef].ToString();
            xObjEnc.CMonedaDocumentoRef = iDr[RegContabCabe_Cont_EN._CMonedaDocumentoRef].ToString();
            xObjEnc.VentaTipoCambio = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._VentaTipoCambio]);
            xObjEnc.PorcentajeIgv = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._PorcentajeIgv]);
            xObjEnc.CAplicaIgv = iDr[RegContabCabe_Cont_EN._CAplicaIgv].ToString();
            xObjEnc.CAplicaInafecto = iDr[RegContabCabe_Cont_EN._CAplicaInafecto].ToString();
            xObjEnc.ValorVentaRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ValorVentaRegContabCabe]);
            xObjEnc.IgvRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._IgvRegContabCabe]);
            xObjEnc.ExoneradoRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ExoneradoRegContabCabe]);
            xObjEnc.InafectoRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._InafectoRegContabCabe]);
            xObjEnc.PrecioVentaRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._PrecioVentaRegContabCabe]);
            xObjEnc.ValorVentaSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ValorVentaSolRegContabCabe]);
            xObjEnc.IgvSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._IgvSolRegContabCabe]);
            xObjEnc.ExoneradoSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ExoneradoSolRegContabCabe]);
            xObjEnc.InafectoSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._InafectoSolRegContabCabe]);
            xObjEnc.PrecioVentaSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._PrecioVentaSolRegContabCabe]);
            xObjEnc.GlosaRegContabCabe = iDr[RegContabCabe_Cont_EN._GlosaRegContabCabe].ToString();
            xObjEnc.CAplicaDetraccion = iDr[RegContabCabe_Cont_EN._CAplicaDetraccion].ToString();
            xObjEnc.NumeroPapeletaDetraccion = iDr[RegContabCabe_Cont_EN._NumeroPapeletaDetraccion].ToString();
            xObjEnc.FechaDetraccion = iDr[RegContabCabe_Cont_EN._FechaDetraccion].ToString();
            xObjEnc.CodigoCuenta = iDr[RegContabCabe_Cont_EN._CodigoCuenta].ToString();
            xObjEnc.CAplicaRetencion = iDr[RegContabCabe_Cont_EN._CAplicaRetencion].ToString();
            xObjEnc.TotalHonorario = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._TotalHonorario]);
            xObjEnc.RetencionHonorario = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._RetencionHonorario]);
            xObjEnc.PagoHonorario = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._PagoHonorario]);
            xObjEnc.ImporteRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ImporteRegContabCabe]);
            xObjEnc.ImporteSolRegContabCabe = Convert.ToDecimal(iDr[RegContabCabe_Cont_EN._ImporteSolRegContabCabe]);
            xObjEnc.CModoPago = iDr[RegContabCabe_Cont_EN._CModoPago].ToString();
            xObjEnc.GiradoPagoRegContabCabe = iDr[RegContabCabe_Cont_EN._GiradoPagoRegContabCabe].ToString();
            xObjEnc.CartaRegContabCabe = iDr[RegContabCabe_Cont_EN._CartaRegContabCabe].ToString();
            xObjEnc.ClaveIngresoRegContabCabe = iDr[RegContabCabe_Cont_EN._ClaveIngresoRegContabCabe].ToString();
            xObjEnc.CEstadoRegContabCabe = iDr[RegContabCabe_Cont_EN._CEstadoRegContabCabe].ToString();
            xObjEnc.UsuarioAgrega = iDr[RegContabCabe_Cont_EN._UsuarioAgrega].ToString();
            xObjEnc.FechaAgrega = Convert.ToDateTime(iDr[RegContabCabe_Cont_EN._FechaAgrega]);
            xObjEnc.UsuarioModifica = iDr[RegContabCabe_Cont_EN._UsuarioModifica].ToString();
            xObjEnc.FechaModifica = Convert.ToDateTime(iDr[RegContabCabe_Cont_EN._FechaModifica]);
            xObjEnc.ClaveObjeto = xObjEnc.ClaveRegContabCabe;
            return xObjEnc;
        }

        private List<RegContabCabe_Cont_EN> ListarObjetos(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
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
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
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
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
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
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            xObjCon.ComandoTexto(pScript);
            string iValor = xObjCon.ObtenerValor();
            xObjCon.Desconectar();
            return iValor;
        }

        public void AgregarRegContaCabe(RegContabCabe_Cont_EN pObj)
        {
            xObjCon.Conectar(SqlDatos.Bd.Alfisa_Contabilidad);
            //armando escript para insertar
            SqlInsert xIns = new SqlInsert();
            xIns.Tabla(this.xTabla);
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ClaveRegContabCabe, pObj.ClaveRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CodigoEmpresa, pObj.CodigoEmpresa.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._PeriodoRegContabCabe, pObj.PeriodoRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._COrigen, pObj.COrigen.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CFile, pObj.CFile.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CorrelativoRegContabCabe, pObj.CorrelativoRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaRegContabCabe, pObj.FechaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CodigoAuxiliar, pObj.CodigoAuxiliar.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CModoCompra, pObj.CModoCompra.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CTipoCompra, pObj.CTipoCompra.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CTipoDocumento, pObj.CTipoDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._SerieDocumento, pObj.SerieDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._NumeroDocumento, pObj.NumeroDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaDocumento, pObj.FechaDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaVctoDocumento, pObj.FechaVctoDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CMonedaDocumento, pObj.CMonedaDocumento.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CTipoDocumentoRef, pObj.CTipoDocumentoRef.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._SerieDocumentoRef, pObj.SerieDocumentoRef.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._NumeroDocumentoRef, pObj.NumeroDocumentoRef.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaDocumentoRef, pObj.FechaDocumentoRef.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaVctoDocumentoRef, pObj.FechaVctoDocumentoRef.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CMonedaDocumentoRef, pObj.CMonedaDocumentoRef.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._VentaTipoCambio, pObj.VentaTipoCambio.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._PorcentajeIgv, pObj.PorcentajeIgv.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CAplicaIgv, pObj.CAplicaIgv.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CAplicaInafecto, pObj.CAplicaInafecto.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ValorVentaRegContabCabe, pObj.ValorVentaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._IgvRegContabCabe, pObj.IgvRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ExoneradoRegContabCabe, pObj.ExoneradoRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._InafectoRegContabCabe, pObj.InafectoRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._PrecioVentaRegContabCabe, pObj.PrecioVentaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ValorVentaSolRegContabCabe, pObj.ValorVentaSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._IgvSolRegContabCabe, pObj.IgvSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ExoneradoSolRegContabCabe, pObj.ExoneradoSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._InafectoSolRegContabCabe, pObj.InafectoSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._PrecioVentaSolRegContabCabe, pObj.PrecioVentaSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._GlosaRegContabCabe, pObj.GlosaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CAplicaDetraccion, pObj.CAplicaDetraccion.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._NumeroPapeletaDetraccion, pObj.NumeroPapeletaDetraccion.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._FechaDetraccion, pObj.FechaDetraccion.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CodigoCuenta, pObj.CodigoCuenta.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CAplicaRetencion, pObj.CAplicaRetencion.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._TotalHonorario, pObj.TotalHonorario.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._RetencionHonorario, pObj.RetencionHonorario.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._PagoHonorario, pObj.PagoHonorario.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ImporteRegContabCabe, pObj.ImporteRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ImporteSolRegContabCabe, pObj.ImporteSolRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CModoPago, pObj.CModoPago.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._GiradoPagoRegContabCabe, pObj.GiradoPagoRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CartaRegContabCabe, pObj.CartaRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._ClaveIngresoRegContabCabe, pObj.ClaveIngresoRegContabCabe.ToString());
            xIns.AsignarParametro(RegContabCabe_Cont_EN._CEstadoRegContabCabe, pObj.CEstadoRegContabCabe.ToString());
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
            xSel.ObtenerMaximoValor(this.xVista, RegContabCabe_Cont_EN._CorrelativoRegContabCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Cuando, RegContabCabe_Cont_EN._CodigoEmpresa, SqlSelect.Operador.Igual, Universal.gCodigoEmpresa);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabe_Cont_EN._PeriodoRegContabCabe, SqlSelect.Operador.Igual, pObj.PeriodoRegContabCabe);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabe_Cont_EN._COrigen, SqlSelect.Operador.Igual, pObj.COrigen);
            xSel.CondicionCV(SqlSelect.Reservada.Y, RegContabCabe_Cont_EN._CFile, SqlSelect.Operador.Igual, pObj.CFile);
            return this.ObtenerValor(xSel.ObtenerScript());
        }
    }
}
