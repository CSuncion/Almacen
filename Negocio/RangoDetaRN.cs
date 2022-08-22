using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using System.Windows.Forms;

namespace Negocio
{
    public class RangoDetaRN
    {

        public static RangoDetaEN EnBlanco()
        {
            RangoDetaEN iRanDetEN = new RangoDetaEN();
            return iRanDetEN;
        }

        public static void AdicionarRangoDeta(RangoDetaEN pObj)
        {
            RangoDetaAD iRanDetAD = new RangoDetaAD();
            iRanDetAD.AgregarRangoDeta(pObj);
        }

        public static void AdicionarRangoDeta(List<RangoDetaEN> pLista)
        {
            RangoDetaAD iRanDetAD = new RangoDetaAD();
            iRanDetAD.AgregarRangoDeta(pLista);
        }

        public static void ModificarRangoDeta(RangoDetaEN pObj)
        {
            RangoDetaAD iRanDetAD = new RangoDetaAD();
            iRanDetAD.ModificarRangoDeta(pObj);
        }

        public static void ModificarRangoDeta(List<RangoDetaEN> pLista)
        {
            RangoDetaAD iRanDetAD = new RangoDetaAD();
            iRanDetAD.ModificarRangoDeta(pLista);
        }

        public static void EliminarRangoDeta(RangoDetaEN pObj)
        {
            RangoDetaAD iRanDetAD = new RangoDetaAD();
            iRanDetAD.EliminarRangoDeta(pObj);
        }

        public static void EliminarRangoDetaXRangoCabe(RangoDetaEN pObj)
        {
            RangoDetaAD iPerAD = new RangoDetaAD();
            iPerAD.EliminarRangoDetaXRangoCabe(pObj);
        }

        public static List<RangoDetaEN> ListarRangoDetas(RangoDetaEN pObj)
        {
            RangoDetaAD iRanDetAD = new RangoDetaAD();
            return iRanDetAD.ListarRangoDetas(pObj);
        }

        public static RangoDetaEN BuscarRangoDetaXClave(RangoDetaEN pObj)
        {
            RangoDetaAD iRanDetAD = new RangoDetaAD();
            return iRanDetAD.BuscarRangoDetaXClave(pObj);
        }

        public static RangoDetaEN EsRangoDetaExistente(RangoDetaEN pObj)
        {
            //objeto resultado
            RangoDetaEN iExiEN = new RangoDetaEN();

            //validar si existe en b.d
            iExiEN = RangoDetaRN.BuscarRangoDetaXClave(pObj);
            if (iExiEN.ClaveRangoDeta == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El Rango " + pObj.ClaveRangoDeta + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(RangoDetaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case RangoDetaEN.ClaObj: return pObj.ClaveObjeto;
                case RangoDetaEN.ClaRanDet: return pObj.ClaveRangoDeta;
                case RangoDetaEN.ClaForCab: return pObj.ClaveFormulaCabe;
                case RangoDetaEN.CorRanDet: return pObj.CorrelativoRangoDeta;
                case RangoDetaEN.CodEmp: return pObj.CodigoEmpresa;
                case RangoDetaEN.NomEmp: return pObj.NombreEmpresa;
                case RangoDetaEN.CodAlm: return pObj.CodigoAlmacen;
                case RangoDetaEN.DesAlm: return pObj.DescripcionAlmacen;                      
                case RangoDetaEN.CodExi: return pObj.CodigoExistencia;
                case RangoDetaEN.DesExi: return pObj.DescripcionExistencia;
                //case RangoDetaEN.NumIniRanDet: return pObj.NumeroInicioRangoDeta.ToString();
                //case RangoDetaEN.NomUniMed: return pObj.NombreUnidadMedida;
                case RangoDetaEN.NumIniRanDet: return pObj.NumeroInicioRangoDeta.ToString();
                case RangoDetaEN.NumFinRanDet: return pObj.NumeroFinalRangoDeta.ToString();
                case RangoDetaEN.PorRanDet: return pObj.PorcentajeRangoDeta.ToString();
                case RangoDetaEN.CTipDes: return pObj.CTipoDescarga;
                case RangoDetaEN.NTipDes: return pObj.NTipoDescarga;
                case RangoDetaEN.CEstRanDet: return pObj.CEstadoRangoDeta;
                case RangoDetaEN.NEstRanDet: return pObj.NEstadoRangoDeta;
                case RangoDetaEN.UsuAgr: return pObj.UsuarioAgrega;
                case RangoDetaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case RangoDetaEN.UsuMod: return pObj.UsuarioModifica;
                case RangoDetaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<RangoDetaEN> FiltrarRangoDetasXTextoEnCualquierPosicion(List<RangoDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<RangoDetaEN> iLisRes = new List<RangoDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (RangoDetaEN xPer in pLista)
            {
                string iTexto = RangoDetaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<RangoDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<RangoDetaEN> pListaRangoDetas)
        {
            //lista resultado
            List<RangoDetaEN> iLisRes = new List<RangoDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaRangoDetas; }

            //filtar la lista
            iLisRes = RangoDetaRN.FiltrarRangoDetasXTextoEnCualquierPosicion(pListaRangoDetas, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveRangoDeta(RangoDetaEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave            
            iClave += pPer.ClaveFormulaCabe + "-";
            iClave += pPer.CorrelativoRangoDeta;

            //retornar
            return iClave;
        }

        public static RangoDetaEN EsActoEliminarRangoDeta(RangoDetaEN pPer)
        {
            //objeto resultado
            RangoDetaEN iExiEN = new RangoDetaEN();

            //validar si existe
            iExiEN = RangoDetaRN.EsRangoDetaExistente(pPer);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

      
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void RangoFormulaDeta(List<RangoDetaEN> pLis, RangoDetaEN pObj)
        {
            //obtener siguiente correlativo
            pObj.CorrelativoRangoDeta = RangoDetaRN.ObtenerSiguienteCorrelativo(pLis);
            pObj.ClaveObjeto = RangoDetaRN.ObtenerClaveRangoDeta(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<RangoDetaEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "0000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoRangoDeta;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static List<RangoDetaEN> RefrescarListaRangoDeta(List<RangoDetaEN> pLis)
        {
            List<RangoDetaEN> iLisRes = new List<RangoDetaEN>();
            foreach (RangoDetaEN xMovDet in pLis)
            {
                iLisRes.Add(xMovDet);
            }
            return iLisRes;
        }

        public static List<RangoDetaEN> ListarRangosDetaXClaveRangoCabe(RangoDetaEN pObj)
        {
            RangoDetaAD iPerAD = new RangoDetaAD();
            return iPerAD.ListarRangosDetaXClaveRangoCabe(pObj);
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RangoDetaAD iPerAD = new RangoDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }
        
        public static List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(pObj);
        }

        public static FormulaDetaEN ValidaCuandoElementosFaseMasaNoSuman100(List<FormulaDetaEN> pLista)
        {
            //objeto resultado
            FormulaDetaEN iForDetEN = new FormulaDetaEN();

            //obtener de pLista solo los elementos de fase masa
            List<FormulaDetaEN> iLisForDetFasMas = FormulaDetaRN.FiltrarFormulaDetasXTextoEnCualquierPosicion(pLista,
                FormulaDetaEN.CTipDes, "0");

            //variable que obtiene el total de la suma
            decimal iTotalSuma = 0;

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDetFasMas)
            {
                iTotalSuma += xForDet.CantidadFormulaDeta;
            }

            //si la suma es 100 entonces pasa true
            if (iTotalSuma == 100) { return iForDetEN; }

            //aqui es diferente de 100
            if (iTotalSuma > 100)
            {
                decimal iMontoSobrante = iTotalSuma - 100;
                iForDetEN.Adicionales.Mensaje = "La suma de porcentajes en la fase masa se excedio en " +
                    Formato.NumeroDecimal(iMontoSobrante, 3);
            }
            else
            {
                decimal iMontoFaltante = 100 - iTotalSuma;
                iForDetEN.Adicionales.Mensaje = "La suma de porcentajes en la fase masa no completo el 100% , falta " +
                    Formato.NumeroDecimal(iMontoFaltante, 3);
            }

            iForDetEN.Adicionales.EsVerdad = false;
            return iForDetEN;
        }

        public static List<FormulaDetaEN> ListarFormulasDetaDeFormulaCabeDeDiferentesProTer(FormulaDetaEN pObj)
        {
            //lista resultado
            List<FormulaDetaEN> iLisRes = new List<FormulaDetaEN>();

            //traer a las formulasDeta de la formulaCabe
            pObj.Adicionales.CampoOrden = FormulaDetaEN.CodExiProTer;
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(pObj);

            //filtrar solo las que tienen proter y solo uno por codigo
            iLisRes = ListaG.FiltrarObjetosSinRepetirYNoVacio<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExiProTer);

            //devolver
            return iLisRes;
        }

        public static List<FormulaDetaEN> ListarFormulasDetaDeFormulaCabeDeDiferentesProTer(ProduccionDetaEN pObj)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj);

            //ejecutar metodo
            return FormulaDetaRN.ListarFormulasDetaDeFormulaCabeDeDiferentesProTer(iForDetEN);
        }

        public static string ObtenerCodigoAlmacenProTer(ProduccionDetaEN pObj)
        {
            //valor resultado
            string iValor = string.Empty;

            //traer la lista de de formulasDeta de diferentes productosProTer
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaDeFormulaCabeDeDiferentesProTer(pObj);

            //devolver
            return ListaG.ObtenerPrimerValor<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodAlmProTer);
        }

        public static List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabe(string pClaveFormulaCabe)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = pClaveFormulaCabe;
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.CorForDet;

            //ejecutar metodo
            return FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(iForDetEN);
        }

        public static FormulaDetaEN BuscarFormulaDetaXClaveFormulaCabeYCodigoExistencia(FormulaDetaEN pObj)
        {
            FormulaDetaAD iForDetAD = new FormulaDetaAD();
            return iForDetAD.BuscarFormulaDetaXClaveFormulaCabeYCodigoExistencia(pObj);
        }

        public static FormulaDetaEN BuscarFormulaDetaXClaveFormulaCabeYCodigoExistencia(string pClaveFormulaCabe, string pCodigoExistencia)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = pClaveFormulaCabe;
            iForDetEN.CodigoExistencia = pCodigoExistencia;

            //ejecutar metodo
            return FormulaDetaRN.BuscarFormulaDetaXClaveFormulaCabeYCodigoExistencia(iForDetEN);
        }

        public static List<FormulaDetaEN> ListarFormulasDeta(ProduccionDetaEN pObj)
        {
            //asignar parametros
            string iClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj);

            //ejecutar metodo
            return FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(iClaveFormulaCabe);
        }

        public static bool EsAlmacenDeCompra(string pCodigoAlmacen)
        {
            //validar
            //se debe buscar este almacen en el campo AlmacenOrigen,este almacen representa al amacen de compras
            bool iExiste = FormulaDetaRN.ExisteValorEnColumnaConEmpresa(FormulaDetaEN.CodAlmOri, pCodigoAlmacen);
            return iExiste;
        }

        public static bool EsAlmacenDeProduccion(string pCodigoAlmacen)
        {
            //validar
            //se debe buscar este almacen en el campo Almacen,este almacen representa al amacen de produccion
            bool iExiste = FormulaDetaRN.ExisteValorEnColumnaConEmpresa(FormulaDetaEN.CodAlm, pCodigoAlmacen);
            return iExiste;
        }

        public static FormulaDetaEN BuscarFormulaDetaXProductoTerminado(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.BuscarFormulaDetaXProductoTerminado(pObj);
        }

        public static FormulaDetaEN BuscarFormulaDetaXProductoTerminado(ProduccionProTerEN pObj)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.CodigoAlmacenProTer = pObj.CodigoAlmacen;
            iForDetEN.CodigoExistenciaProTer = pObj.CodigoExistencia;

            //ejecutar metodo
            return FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(iForDetEN);
        }

        public static List<FormulaDetaEN> ListarFormulasDetaParaExportar()
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.ClaForCab + "," + FormulaDetaEN.ClaForDet;

            //ejecutar metodo
            return FormulaDetaRN.ListarFormulaDetas(iForDetEN);
        }

        public static int ObtenerNumeroDiasVcto(ProduccionProTerEN pObj)
        {
            //traer a la formuladeta
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pObj);

            //devolver
            return (int)iForDetEN.NumeroDiasVctoFormulaCabe;
        }

        public static List<FormulaDetaEN> ListarFormulasDetaConCodigoExistenciaProTer()
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ListarFormulasDetaConCodigoExistenciaProTer();
        }

        public static List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabeYEstado(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ListarFormulasDetaXClaveFormulaCabeYEstado(pObj);
        }

        public static List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabeYActivos(string pClaveFormulaCabe)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = pClaveFormulaCabe;
            iForDetEN.CEstadoFormulaDeta = "1";//activos
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.ClaForCab;

            //ejecutar metodo
            return FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYEstado(iForDetEN);
        }

        public static List<FormulaDetaEN> ListarFormulasDetaParaDetalleFormulasDeta(string pClaveFormulaCabe)
        {
            //traer la lista de formulas deta de esta formula cabe y activos
            List<FormulaDetaEN> iLisForDet = ListarFormulasDetaXClaveFormulaCabeYActivos(pClaveFormulaCabe);

            //ahora filtramos solo fase masa y envasado
            iLisForDet = ListaG.FiltrarPorConjuntoValores<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CTipDes, "0,1");

            //devolver
            return iLisForDet;
        }











        public static List<RangoDetaEN> ListarRangosDetaXClaveRangoCabeYTipoDescarga(RangoDetaEN pObj)
        {
            RangoDetaAD iPerAD = new RangoDetaAD();
            return iPerAD.ListarRangosDetaXClaveRangoCabeYTipoDescarga(pObj);
        }

        public static List<RangoDetaEN> ListarRangosDetaXClaveRangoCabeYTipoDescarga(string pClaveRangoCabe,string pCTipoDescarga)
        {
            //asignar parametros
            RangoDetaEN iRanDetEN = new RangoDetaEN();
            iRanDetEN.ClaveFormulaCabe = pClaveRangoCabe;
            iRanDetEN.CTipoDescarga = pCTipoDescarga;
            iRanDetEN.Adicionales.CampoOrden = RangoDetaEN.ClaRanDet;

            //ejecutar metodo
            return ListarRangosDetaXClaveRangoCabeYTipoDescarga(iRanDetEN);
        }

        public static List<RangoDetaEN> ListarRangosDeta(ProduccionCabeEN pObj)
        {
            //asignar parametros
            string pClaveRangoCabe = ProduccionCabeRN.ObtenerClaveFormulaCabe(pObj);
            string pCTipoDescarga = "1";//fase envasado
            
            //ejecutar metodo
            return ListarRangosDetaXClaveRangoCabeYTipoDescarga(pClaveRangoCabe, pCTipoDescarga);
        }

        public static List<RangoDetaEN> ListarRangosDeta(ProduccionProTerEN pObj)
        {
            //asignar parametros
            string pClaveRangoCabe = ProduccionProTerRN.ObtenerClaveFormulaCabe(pObj);
            string pCTipoDescarga = "2";//fase encajado

            //ejecutar metodo
            return ListarRangosDetaXClaveRangoCabeYTipoDescarga(pClaveRangoCabe, pCTipoDescarga);
        }
              
        public static decimal ObtenerPorcentajeRangoDetaDeCantidad(decimal pCantidad, List<RangoDetaEN> pLisRanDet)
        {
            //recorrer cada objeto rango
            foreach (RangoDetaEN xRanDet in pLisRanDet)
            {
                if (Numero.EsValorEntreLimites(pCantidad, xRanDet.NumeroInicioRangoDeta, xRanDet.NumeroFinalRangoDeta) == true)
                {
                    return xRanDet.PorcentajeRangoDeta;
                }
            }

            //devolver
            return 0;
        }

        public static string ObtenerNuevoNumeroLiberacionAutogenerado(RangoDetaEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = RangoDetaRN.ObtenerMaximoValorEnColumna(RangoDetaEN.CorRanDet, RangoDetaEN.ClaForCab, pObj.ClaveFormulaCabe);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 3);

            //devuelve
            return iNumero;
        }

        public static string ObtenerMaximoValorEnColumna(string pColumnaBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            RangoDetaAD iObjAD = new RangoDetaAD();
            return iObjAD.ObtenerMaximoValorEnColumna(pColumnaBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static RangoDetaEN EsLiberacionExistente(RangoDetaEN pObj)
        {
            //objeto resultado
            RangoDetaEN iObjEN = new RangoDetaEN();

            //validar si existe en b.d
            iObjEN = RangoDetaRN.BuscarRangoDetaXClave(pObj);
            if (iObjEN.ClaveRangoDeta == string.Empty)
            {
                iObjEN.Adicionales.EsVerdad = false;
                iObjEN.Adicionales.Mensaje = "El Registro seleccionado no existe";
            }

            //ok  
            return iObjEN;
        }

        public static RangoDetaEN EsActoAdicionarRangoDeta(RangoDetaEN pObj)
        {
            //objeto resultado
            RangoDetaEN iObjEN = new RangoDetaEN();

            //ok          
            return iObjEN;
        }

        public static RangoDetaEN EsActoModificarRangoDeta(RangoDetaEN pObj)
        {
            //objeto resultado
            RangoDetaEN iObjEN = new RangoDetaEN();

            //valida cuando el codigo no existe
            iObjEN = RangoDetaRN.EsRangoDetaExistente(pObj);
            if (iObjEN.Adicionales.EsVerdad == false) { return iObjEN; }

            //ok          
            return iObjEN;
        }



    }
}
