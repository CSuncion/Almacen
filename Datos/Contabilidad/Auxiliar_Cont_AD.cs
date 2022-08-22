using Datos.Config;
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
    public class Auxiliar_Cont_AD
    {

        #region Variables

        private SqlDatos xObjCon = new SqlDatos();
        private List<Auxiliar_Cont_EN> xLista = new List<Auxiliar_Cont_EN>();
        private Auxiliar_Cont_EN xObj = new Auxiliar_Cont_EN();
        //private string xTabla = "Auxiliar";
        //private string xVista = "VsAuxiliar";

        #endregion

        #region Metodos privados

        private Auxiliar_Cont_EN Objeto(IDataReader iDr)
        {
            Auxiliar_Cont_EN xObjEnc = new Auxiliar_Cont_EN();
            xObjEnc.CodigoAuxiliar = iDr[Auxiliar_Cont_EN.CodAux].ToString();
            xObjEnc.DescripcionAuxiliar = iDr[Auxiliar_Cont_EN.DesAux].ToString();
            xObjEnc.DireccionAuxiliar = iDr[Auxiliar_Cont_EN.DirAux].ToString();
            xObjEnc.TelefonoAuxiliar = iDr[Auxiliar_Cont_EN.TelAux].ToString();
            xObjEnc.CelularAuxiliar = iDr[Auxiliar_Cont_EN.CelAux].ToString();
            xObjEnc.CorreoAuxiliar = iDr[Auxiliar_Cont_EN.CorAux].ToString();
            xObjEnc.ReferenciaAuxiliar = iDr[Auxiliar_Cont_EN.RefAux].ToString();
            xObjEnc.TipoAuxiliar = iDr[Auxiliar_Cont_EN.TipAux].ToString();
            xObjEnc.TipoDocumentoAuxiliar = iDr[Auxiliar_Cont_EN.TipDocAux].ToString();
            xObjEnc.EstadoAuxiliar = iDr[Auxiliar_Cont_EN.EstAux].ToString();            
            return xObjEnc;
        }

        private List<Auxiliar_Cont_EN> ListarObjetos(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.ContabilidadAlfisa);
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

        private Auxiliar_Cont_EN BuscarObjeto(string pScript)
        {
            xObjCon.Conectar(SqlDatos.Bd.ContabilidadAlfisa);
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
            xObjCon.Conectar(SqlDatos.Bd.ContabilidadAlfisa);
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

        public List<Auxiliar_Cont_EN> ListarAuxiliarsParaImportar(string pCodigoPeriodo)
        {
            //script manual
            string iScript = string.Empty;

            //armando la primera consulta
            iScript += "Select * From VsAuxiliar";            
            iScript += " Where CodigoAuxiliar in(Select CodigoAuxiliar from VsRegContabDeta where CodigoEmpresa='";
            iScript += Universal.gCodigoEmpresa + "' And PeriodoRegContabCabe='" + pCodigoPeriodo + "'";
            iScript += " And CodigoGastoReparable<>'' And Cantidad<>0 )";

            //resultado
            return this.ListarObjetos(iScript);
        }

        #endregion

    }
}
