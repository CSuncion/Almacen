using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;



namespace Negocio
{
    public class FormulaDetaRN
    {

        public static FormulaDetaEN EnBlanco()
        {
            FormulaDetaEN iExiEN = new FormulaDetaEN();
            return iExiEN;
        }

        public static void AdicionarFormulaDeta(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            iPerAD.AgregarFormulaDeta(pObj);
        }

        public static void AdicionarFormulaDeta(List< FormulaDetaEN> pLista)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            iPerAD.AgregarFormulaDeta(pLista);
        }

        public static void ModificarFormulaDeta(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            iPerAD.ModificarFormulaDeta(pObj);
        }

        public static void ModificarFormulaDeta(List< FormulaDetaEN> pLista)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            iPerAD.ModificarFormulaDeta(pLista);
        }

        public static void EliminarFormulaDeta(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            iPerAD.EliminarFormulaDeta(pObj);
        }

        public static void EliminarFormulaDetaXFormulaCabe(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            iPerAD.EliminarFormulaDetaXFormulaCabe(pObj);
        }

        public static List<FormulaDetaEN> ListarFormulaDetas(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ListarFormulaDetas(pObj);
        }

        public static FormulaDetaEN BuscarFormulaDetaXClave(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.BuscarFormulaDetaXClave(pObj);
        }

        public static FormulaDetaEN EsFormulaDetaExistente(FormulaDetaEN pObj)
        {
            //objeto resultado
            FormulaDetaEN iExiEN = new FormulaDetaEN();

            //validar si existe en b.d
            iExiEN = FormulaDetaRN.BuscarFormulaDetaXClave(pObj);
            if (iExiEN.ClaveFormulaDeta == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "La FormulaDeta " + pObj.ClaveFormulaDeta  + " no existe";
                return iExiEN;
            }

            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(FormulaDetaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case FormulaDetaEN.ClaObj: return pObj.ClaveObjeto;
                case FormulaDetaEN.ClaForDet: return pObj.ClaveFormulaDeta;
                case FormulaDetaEN.ClaForCab: return pObj.ClaveFormulaCabe;
                case FormulaDetaEN.CorForDet: return pObj.CorrelativoFormulaDeta;
                case FormulaDetaEN.CodEmp: return pObj.CodigoEmpresa;
                case FormulaDetaEN.NomEmp: return pObj.NombreEmpresa;
                case FormulaDetaEN.CodAlm: return pObj.CodigoAlmacen;
                case FormulaDetaEN.DesAlm: return pObj.DescripcionAlmacen;                      
                case FormulaDetaEN.CodExi: return pObj.CodigoExistencia;
                case FormulaDetaEN.DesExi: return pObj.DescripcionExistencia;
                case FormulaDetaEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case FormulaDetaEN.NomUniMed: return pObj.NombreUnidadMedida;
                case FormulaDetaEN.CanForDet: return pObj.CantidadFormulaDeta.ToString();
                case FormulaDetaEN.CTipDes: return pObj.CTipoDescarga;
                case FormulaDetaEN.NTipDes: return pObj.NTipoDescarga;
                case FormulaDetaEN.CEstForDet: return pObj.CEstadoFormulaDeta;
                case FormulaDetaEN.NEstForDet: return pObj.NEstadoFormulaDeta;
                case FormulaDetaEN.UsuAgr: return pObj.UsuarioAgrega;
                case FormulaDetaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case FormulaDetaEN.UsuMod: return pObj.UsuarioModifica;
                case FormulaDetaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<FormulaDetaEN> FiltrarFormulaDetasXTextoEnCualquierPosicion(List<FormulaDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<FormulaDetaEN> iLisRes = new List<FormulaDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (FormulaDetaEN xPer in pLista)
            {
                string iTexto = FormulaDetaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<FormulaDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<FormulaDetaEN> pListaFormulaDetas)
        {
            //lista resultado
            List<FormulaDetaEN> iLisRes = new List<FormulaDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaFormulaDetas; }

            //filtar la lista
            iLisRes = FormulaDetaRN.FiltrarFormulaDetasXTextoEnCualquierPosicion(pListaFormulaDetas, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveFormulaDeta(FormulaDetaEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave            
            iClave += pPer.ClaveFormulaCabe + "-";
            iClave += pPer.CorrelativoFormulaDeta;

            //retornar
            return iClave;
        }

        public static FormulaDetaEN EsActoEliminarFormulaDeta(FormulaDetaEN pPer)
        {
            //objeto resultado
            FormulaDetaEN iExiEN = new FormulaDetaEN();

            //validar si existe
            iExiEN = FormulaDetaRN.EsFormulaDetaExistente(pPer);
            if (iExiEN.Adicionales.EsVerdad == false) { return iExiEN; }

      
            //ok
            iExiEN.Adicionales.EsVerdad = true;
            return iExiEN;
        }

        public static void AdicionarFormulaDeta(List<FormulaDetaEN> pLis, FormulaDetaEN pObj)
        {
            //obtener siguiente correlativo
            pObj.CorrelativoFormulaDeta = FormulaDetaRN.ObtenerSiguienteCorrelativo(pLis);
            pObj.ClaveObjeto = FormulaDetaRN.ObtenerClaveFormulaDeta(pObj);
            pLis.Add(pObj);
        }

        public static string ObtenerSiguienteCorrelativo(List<FormulaDetaEN> pLis)
        {
            //obtener el ultimo correlativo de la lista
            string iUltimoCorrelativo = "0000";

            //solo si hay objetos
            if (pLis.Count != 0)
            {
                iUltimoCorrelativo = pLis[pLis.Count - 1].CorrelativoFormulaDeta;
            }

            //obtener el siguiente correlativo
            return Numero.IncrementarCorrelativoNumerico(iUltimoCorrelativo);
        }

        public static List<FormulaDetaEN> RefrescarListaFormulaDeta(List<FormulaDetaEN> pLis)
        {
            List<FormulaDetaEN> iLisRes = new List<FormulaDetaEN>();
            foreach (FormulaDetaEN xMovDet in pLis)
            {
                iLisRes.Add(xMovDet);
            }
            return iLisRes;
        }

        public static List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabe(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ListarFormulasDetaXClaveFormulaCabe(pObj);
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
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static List<ExistenciaEN> ListarExistenciasReferenciadasEnFormulasDeta(List<FormulaDetaEN> pLisMovDet)
        {
            //lista resultado
            List<ExistenciaEN> iLisRes = new List<ExistenciaEN>();

            //traer a todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //recorrer cada objeto
            foreach (FormulaDetaEN xMovDet in pLisMovDet)
            {
                //obtener la clave de la existencia en el xMovDet
                string iClaveExistencia = FormulaDetaRN.ObtenerClaveExistencia(xMovDet);

                //buscar la existencia de xMovDet en iLisExiEmp
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiEmp);
                if (iExiEN.ClaveExistencia != string.Empty)
                {
                    iLisRes.Add(iExiEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerClaveExistencia(FormulaDetaEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CodigoExistencia;

            //retornar
            return iClave;
        }
        
        public static FormulaDetaEN BuscarFormulaDeta(string pCampo, string pValor, List<FormulaDetaEN> pLista)
        {
            //objeto resultaddo
            FormulaDetaEN iMovDetEN = new FormulaDetaEN();

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in pLista)
            {
                if (FormulaDetaRN.ObtenerValorDeCampo(xForDet, pCampo) == pValor)
                {
                    return xForDet;
                }
            }

            //devolver
            return iMovDetEN;
        }

        public static bool HayTipoDescargaFija(List<FormulaDetaEN> pLista)
        {
            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in pLista)
            {
                if (xForDet.CTipoDescarga == "0")
                {
                    return true;
                }
            }

            //devolver
            return false;
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

        public static FormulaDetaEN BuscarFormulaDetaXProductoTerminadoRE(RetiquetadoEN pObj)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.CodigoAlmacenProTer = pObj.CodigoAlmacenRE;
            iForDetEN.CodigoExistenciaProTer = pObj.CodigoExistenciaRE;

            //ejecutar metodo
            return FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(iForDetEN);
        }

        public static void ModificarFormulasDetaDeIgualCodigoExistencia(List<FormulaDetaEN> pLis)
        {
            //lista a modificar
            List<FormulaDetaEN> iLisForDetMod = new List<FormulaDetaEN>();

            //obtener todos los codigos de existencias en formato IN para bd
            string iCodExi = ListaG.ArmarCadenaParaIN<FormulaDetaEN>(pLis, FormulaDetaEN.CodExi);

            //traer estos codigos de la bd
            List<FormulaDetaEN> iLisForDetExi = ListarFormulasDetaDeCodigosExistencia(iCodExi);

            //recorrer cada objeto de pLis
            foreach (FormulaDetaEN xForDet in pLis)
            {
                //listar los de codigo existencia de xForDet
                List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(iLisForDetExi, FormulaDetaEN.CodExi, xForDet.CodigoExistencia);

                //recorrer cada objeto de iLisForDet
                foreach (FormulaDetaEN xForDetExi in iLisForDet)
                {
                    //actualizar los datos de los almacen de compras y transferencia
                    xForDetExi.CodigoAlmacenOrigen = xForDet.CodigoAlmacenOrigen;
                    xForDetExi.CodigoAlmacenCompra = xForDet.CodigoAlmacenCompra;

                    //agregar a la lista a modificar en bd
                    iLisForDetMod.Add(xForDetExi);
                }
            }

            //modificar en bd
            ModificarFormulaDeta(iLisForDetMod);
        }

        public static List<FormulaDetaEN> ListarFormulasDetaDeCodigosExistencia(string pCodExi)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ListarFormulasDetaDeCodigosExistencia(pCodExi);
        }

        public static List<FormulaDetaEN> ListarFormulasDetaDeCodigoExistenciaProTerYDiferenteClaveFormulaCabe(FormulaDetaEN pObj)
        {
            FormulaDetaAD iPerAD = new FormulaDetaAD();
            return iPerAD.ListarFormulasDetaDeCodigoExistenciaProTerYDiferenteClaveFormulaCabe(pObj);
        }

        public static FormulaDetaEN ValidaCuandoProductoTerminadoEstaEnOtraFormula(FormulaDetaEN pObj)
        {
            //objeto resultado
            FormulaDetaEN iForDetEN = new FormulaDetaEN();

            //listar formulas con este producto terminado
            List<FormulaDetaEN> iLisForDetProTer = ListarFormulasDetaDeCodigoExistenciaProTerYDiferenteClaveFormulaCabe(pObj);

            //valida
            if (iLisForDetProTer.Count != 0)
            {
                iForDetEN.Adicionales.EsVerdad = false;
                iForDetEN.Adicionales.Mensaje = "Este producto terminado ya esta registrado en otra formula, no se puede realizar la operacion";
            }

            //devolver
            return iForDetEN;
        }

        public static List<FormulaDetaEN> ListarFormulasDetaUsadasEnProduccion(ProduccionCabeEN pObj)
        {
            //lista resultado
            List<FormulaDetaEN> iLisRes = new List<FormulaDetaEN>();

            //convertir el campo detalle formula deta a lista formula deta(esta lista solo contiene objetos formula deta
            //con el unico dato que es el codigo existencia)
            List<FormulaDetaEN> iLisForDetPro = ProduccionCabeRN.ConvertirCampoDetalleFormulasDetaALista(pObj.DetalleFormulasDeta);

            //traer a las formulas deta de esta produccion de bd
            List<FormulaDetaEN> iLisForDetBD = ListarFormulasDetaXClaveFormulaCabe(ProduccionCabeRN.ObtenerClaveFormulaCabe(pObj));

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDetPro in iLisForDetPro)
            {
                //buscar en la otra lista esta formula
                FormulaDetaEN iForDetBusEN = ListaG.Buscar<FormulaDetaEN>(iLisForDetBD, FormulaDetaEN.CodExi, xForDetPro.CodigoExistencia);

                //le pasamos el dato de la descripcion
                xForDetPro.DescripcionExistencia = iForDetBusEN.DescripcionExistencia;

                //agregar a la lista resultado
                iLisRes.Add(xForDetPro);
            }

            //devolver
            return iLisRes;
        }

        public static FormulaDetaEN BuscarFormulaDetaConProTer(string pClaveFormulaCabe)
        {
            //valor resultado
            FormulaDetaEN iForDetEN = new FormulaDetaEN();

            //traer la lista de de formulasDeta 
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(pClaveFormulaCabe);

            //
            iLisForDet = ListaG.FiltrarExcepto<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExiProTer, string.Empty);

            //si la lista esta vacia
            if (iLisForDet.Count == 0) { return iForDetEN; }

            //devolver
            return iLisForDet[0];
        }

        public static List<FormulaDetaEN> ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(string pClaveFormulaCabe,string pCTipoDescarga,
            string pOrdenLista)
        {
            //asignar parametros
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = pClaveFormulaCabe;
            iForDetEN.CTipoDescarga = pCTipoDescarga;
            iForDetEN.Adicionales.CampoOrden = pOrdenLista;

            //ejecutar metodo
            return ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(iForDetEN);
        }





    }
}
