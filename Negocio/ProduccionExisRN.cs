using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;
using Entidades.Estructuras;
using System.Windows.Forms;

namespace Negocio
{
    public class ProduccionExisRN
    {

        public static ProduccionExisEN EnBlanco()
        {
            ProduccionExisEN iProEN = new ProduccionExisEN();
            return iProEN;
        }

        public static void AdicionarProduccionExis(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.AdicionarProduccionExis(pObj);
        }

        public static void AdicionarProduccionExis(List<ProduccionExisEN> pLista)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.AdicionarProduccionExis(pLista);
        }

        public static void ModificarProduccionExis(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.ModificarProduccionExis(pObj);
        }

        public static void ModificarProduccionExis(List<ProduccionExisEN> pLista)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.ModificarProduccionExis(pLista);
        }

        public static void EliminarProduccionExis(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.EliminarProduccionExis(pObj);
        }

        public static void EliminarProduccionExisXClaveProduccionDeta(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.EliminarProduccionExisXClaveProduccionDeta(pObj);
        }

        public static void EliminarProduccionExisXClaveProduccionDeta(string pClaveProduccionDeta)
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pClaveProduccionDeta;

            //ejecutar metodo
            ProduccionExisRN.EliminarProduccionExisXClaveProduccionDeta(iProExiEN);
        }

        public static void EliminarProduccionExisXClaveProduccionDetaYCTipoDescarga(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.EliminarProduccionExisXClaveProduccionDetaYCTipoDescarga(pObj);
        }

        public static void EliminarProduccionExisXClaveEncajado(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.EliminarProduccionExisXClaveEncajado(pObj);
        }

        public static void EliminarProduccionExisXClaveRetiquetado(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            iProAD.EliminarProduccionExisXClaveRetiquetado(pObj);
        }

        public static ProduccionExisEN BuscarProduccionExisXClave(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.BuscarProduccionExisXClave(pObj);
        }

        public static string ObtenerClaveProduccionExis(ProduccionExisEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacen + "-";
            iClave += pObj.CorrelativoProduccionCabe + "-";
            iClave += pObj.CorrelativoProduccionDeta + "-";
            iClave += pObj.CorrelativoProduccionExis;

            //devolver
            return iClave;
        }

        public static List<ProduccionExisEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<ProduccionExisEN> pListaProduccionExis)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaProduccionExis; }

            //filtar la lista
            iLisRes = ProduccionExisRN.FiltrarProduccionExisEnCualquierPosicion(pListaProduccionExis, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<ProduccionExisEN> FiltrarProduccionExisEnCualquierPosicion(List<ProduccionExisEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (ProduccionExisEN xPro in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<ProduccionExisEN>(xPro, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPro);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(ProduccionExisEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case ProduccionExisEN.ClaObj: return pObj.ClaveObjeto;
                case ProduccionExisEN.ClaProExi: return pObj.ClaveProduccionExis;
                case ProduccionExisEN.ClaProDet: return pObj.ClaveProduccionDeta;
                case ProduccionExisEN.ClaProCab: return pObj.ClaveProduccionCabe;
                case ProduccionExisEN.CodEmp: return pObj.CodigoEmpresa;
                case ProduccionExisEN.NomEmp: return pObj.NombreEmpresa;
                case ProduccionExisEN.CodAlm: return pObj.CodigoAlmacen;
                case ProduccionExisEN.DesAlm: return pObj.DescripcionAlmacen;
                case ProduccionExisEN.CorProCab: return pObj.CorrelativoProduccionCabe;
                case ProduccionExisEN.CorProDet: return pObj.CorrelativoProduccionDeta;
                case ProduccionExisEN.CorProExi: return pObj.CorrelativoProduccionExis;
                case ProduccionExisEN.CodExi: return pObj.CodigoExistencia;
                case ProduccionExisEN.DesExi: return pObj.DescripcionExistencia;
                case ProduccionExisEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case ProduccionExisEN.NomUniMed: return pObj.NombreUnidadMedida;
                case ProduccionExisEN.CanProExi: return pObj.CantidadProduccionExis.ToString();
                case ProduccionExisEN.CEstProExi: return pObj.CEstadoProduccionExis;
                case ProduccionExisEN.NEstProExi: return pObj.NEstadoProduccionExis;
                case ProduccionExisEN.UsuAgr: return pObj.UsuarioAgrega;
                case ProduccionExisEN.FecAgr: return pObj.FechaAgrega.ToString();
                case ProduccionExisEN.UsuMod: return pObj.UsuarioModifica;
                case ProduccionExisEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static string ObtenerMaximoValorEnColumna(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProCabAD = new ProduccionExisAD();
            return iProCabAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoNumeroProduccionExisAutogenerado(ProduccionExisEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = ProduccionExisRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 4);

            //devuelve
            return iNumero;
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveProduccionDeta(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisXClaveProduccionDeta(pObj);
        }

        public static void AdicionarProduccionesExisDeParteTrabajo(ProduccionDetaEN pObj)
        {
            //lista produccion exi a adicionar
            List<ProduccionExisEN> iLisProExi = new List<ProduccionExisEN>();

            //segun la cantidad de parte de trabajo 
            if (pObj.CantidadProduccionDeta == 0)//listar las fijas
            {
                iLisProExi = ProduccionExisRN.ArmarListaProduccionesExisFijasDeParteTrabajo(pObj);
            }
            else
            {
                iLisProExi = ProduccionExisRN.ArmarListaProduccionesExisCalculadasDeParteTrabajo(pObj);
            }

            //adicionar masivo
            ProduccionExisRN.AdicionarProduccionExis(iLisProExi);
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFijasDeParteTrabajo(ProduccionDetaEN pObj)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj);
            iForDetEN.CTipoDescarga = "0";//Fijas
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.ClaForDet;
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(iForDetEN);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //creamos un objeto ProduccionExis a partir de xForDet(FormulaDeta)
                ProduccionExisEN iProExiEN = ProduccionExisRN.CrearProduccionExis(xForDet, pObj, "0");

                //adicionamos a la lista resultado
                iLisRes.Add(iProExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisCalculadasDeParteTrabajo(ProduccionDetaEN pObj)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj);
            iForDetEN.CTipoDescarga = "1";//Calculada
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.ClaForDet;
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(iForDetEN);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //creamos un objeto ProduccionExis a partir de xForDet(FormulaDeta)
                ProduccionExisEN iProExiEN = ProduccionExisRN.CrearProduccionExis(xForDet, pObj, "1");

                //adicionamos a la lista resultado
                iLisRes.Add(iProExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static ProduccionExisEN CrearProduccionExis(FormulaDetaEN pForDet, ProduccionDetaEN pProDet, string pCTipoDescarga)
        {
            //objeto resultado
            ProduccionExisEN iProExiEN = new ProduccionExisEN();

            //pasando datos
            iProExiEN.ClaveProduccionCabe = pProDet.ClaveProduccionCabe;
            iProExiEN.ClaveProduccionDeta = pProDet.ClaveProduccionDeta;
            iProExiEN.CodigoEmpresa = pProDet.CodigoEmpresa;
            iProExiEN.CodigoAlmacen = pForDet.CodigoAlmacen;
            iProExiEN.CorrelativoProduccionCabe = pProDet.CorrelativoProduccionCabe;
            iProExiEN.CorrelativoProduccionDeta = pProDet.CorrelativoProduccionDeta;
            iProExiEN.CorrelativoProduccionExis = pForDet.CorrelativoFormulaDeta;
            iProExiEN.CodigoExistencia = pForDet.CodigoExistencia;
            iProExiEN.CodigoUnidadMedida = pForDet.CodigoUnidadMedida;
            iProExiEN.NombreUnidadMedida = pForDet.NombreUnidadMedida;
            iProExiEN.CantidadGr = ProduccionExisRN.CalcularCantidadGr(pForDet, pProDet.CantidadSinceradoProduccionDeta);
            iProExiEN.CantidadKg = ProduccionExisRN.CalcularCantidadKg(pForDet, pProDet.CantidadSinceradoProduccionDeta);
            iProExiEN.CantidadProduccionExis = ProduccionExisRN.CalcularCantidadProduccionExis(pForDet, pProDet);
            iProExiEN.PrecioUnitario = pForDet.PrecioPromedioExistencia;
            iProExiEN.CantidadFormula = iProExiEN.CantidadProduccionExis;
            iProExiEN.CantidadGrFormula = iProExiEN.CantidadGr;
            iProExiEN.CantidadKgFormula = iProExiEN.CantidadKg;
            iProExiEN.CTipoDescarga = pCTipoDescarga;
            iProExiEN.CTipoFactor = pForDet.CTipoFactor;
            iProExiEN.CodigoAlmacenProTer = pForDet.CodigoAlmacenProTer;
            iProExiEN.CodigoExistenciaProTer = pForDet.CodigoExistenciaProTer;
            iProExiEN.CodigoAlmacenOrigen = pForDet.CodigoAlmacenOrigen;
            iProExiEN.DescripcionAlmacenOrigen = pForDet.DescripcionAlmacenOrigen;
            iProExiEN.CodigoAlmacenCompra = pForDet.CodigoAlmacenCompra;
            iProExiEN.CodigoSolicitud = pProDet.CorrelativoProduccionCabe;
            iProExiEN.FechaProduccionDeta = pProDet.FechaProduccionDeta;
            iProExiEN.CodigoFormula = pProDet.CodigoExistencia;
            iProExiEN.DescripcionFormula = pProDet.DescripcionExistencia;
            iProExiEN.ClaveProduccionExis = ProduccionExisRN.ObtenerClaveProduccionExis(iProExiEN);
            iProExiEN.CTurno = pProDet.CTurno;
            iProExiEN.CantidadProduccionDeta = pProDet.CantidadProduccionDeta;
            iProExiEN.ClaveFormulaCabe = pForDet.ClaveFormulaCabe;

            //devolver
            return iProExiEN;
        }

        public static decimal CalcularCantidadGr(FormulaDetaEN pForDet, decimal CantidadUnidadesAProducir)
        {
            //valor resultado
            decimal iValor = 0;

            //segun CTipoDescarga
            if (pForDet.CTipoDescarga == "0")
            {
                iValor = Math.Round(pForDet.CantidadFormulaDeta * CantidadUnidadesAProducir, 3);
            }

            //devolver
            return iValor;
        }

        public static decimal CalcularCantidadKg(FormulaDetaEN pForDet, decimal CantidadUnidadesAProducir)
        {
            //valor resultado
            decimal iValor = 0;

            //obtener en gramos
            iValor = ProduccionExisRN.CalcularCantidadGr(pForDet, CantidadUnidadesAProducir);

            //dividir en 1000
            iValor = iValor / 1000;

            //redondear
            iValor = Math.Round(iValor, 3);

            //devolver
            return iValor;
        }

        public static decimal CalcularCantidadProduccionExis(FormulaDetaEN pForDet, ProduccionDetaEN pProDet)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            if (pForDet.CTipoDescarga == "0")//fase masa
            {
                if (pForDet.CodigoUnidadMedida == "006")//gramos
                {
                    iValor = ProduccionExisRN.CalcularCantidadGr(pForDet, pProDet.CantidadSinceradoProduccionDeta);
                }
                else
                {
                    iValor = ProduccionExisRN.CalcularCantidadKg(pForDet, pProDet.CantidadSinceradoProduccionDeta);
                }
            }
            else
            {
                if (pForDet.CTipoDescarga == "1")//fase control de calidad
                {
                    iValor = Math.Round(pForDet.CantidadFormulaDeta * (pProDet.CantidadSinceradoProduccionDeta + pProDet.UnidadesReproceso + pProDet.CantidadSinceradoRango), 3);
                }
                else
                {
                    //fase empaquetado
                    if (pForDet.CTipoFactor == "1")//es caja
                    {
                        iValor = Math.Round(pForDet.CantidadFormulaDeta * pProDet.NumeroCajas, 3);
                    }
                    else
                    {
                        iValor = Math.Round(pForDet.CantidadFormulaDeta * pProDet.NumeroUnidadesConCal, 3);
                    }
                }
            }

            //devolver
            return iValor;
        }

        public static List<ProduccionExisEN> RefrescarListaProduccionExis(List<ProduccionExisEN> pLis)
        {
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();
            foreach (ProduccionExisEN xProExi in pLis)
            {
                iLisRes.Add(xProExi);
            }
            return iLisRes;
        }

        public static string ObtenerClaveExistencia(ProduccionExisEN pObj)
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

        public static List<InsumoFaltante> ListarInsumosFaltantesParaParteTrabajo(List<ProduccionExisEN> pLisProExi)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //obtener la lista insumos faltantes
            iLisRes = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(iLisExiEmp, pLisProExi);

            //devolver
            return iLisRes;
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesParaParteTrabajo(List<ExistenciaEN> pLisExi, List<ProduccionExisEN> pLis)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLis)
            {
                //armar la clave de la existencia
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);                

                //buscar a la existencia
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);                

                //si la cantidad de stock de la existencia es mayor que la de insumo,
                //entonces ya no avanza en el proceso
                if (iExiEN.StockActualExistencia >= xProExi.CantidadProduccionExis) { continue; }                

                //buscar a la existencia del almacen de compras,para comprobar si hay el stock pedido,
                //se guardara lo que le falta a esta existencia
                ExistenciaEN iExiOriEN = ExistenciaRN.BuscarExistencia(xProExi.CodigoAlmacenOrigen, xProExi.CodigoExistencia);                

                //crear un objeto InsumoFaltante
                InsumoFaltante iInsFal = new InsumoFaltante();                

                //pasamos datos
                iInsFal.CodigoLinea = xProExi.CorrelativoProduccionExis;
                iInsFal.CodigoSolicitud = xProExi.CorrelativoProduccionCabe;
                iInsFal.CodigoFormula = xProExi.CodigoFormula;
                iInsFal.DescripcionFormula = xProExi.DescripcionFormula;
                iInsFal.CodigoExistencia = iExiEN.CodigoExistencia;
                iInsFal.DescripcionExistencia = iExiEN.DescripcionExistencia;
                iInsFal.CantidadStockExistencia = iExiEN.StockActualExistencia;
                iInsFal.CantidadParteTrabajo = xProExi.CantidadProduccionExis;
                iInsFal.CantidadFaltante = iInsFal.CantidadParteTrabajo - iInsFal.CantidadStockExistencia;
                iInsFal.CodigoAlmacen = xProExi.CodigoAlmacenOrigen;
                iInsFal.DescripcionAlmacen = xProExi.DescripcionAlmacenOrigen;
                iInsFal.CodigoPersonal = xProExi.CodigoPersonalOrigen;
                iInsFal.CUnidadMedida = xProExi.CodigoUnidadMedida;
                iInsFal.NUnidadMedida = xProExi.NombreUnidadMedida;
                iInsFal.FechaProduccion = xProExi.FechaProduccionDeta;
                iInsFal.CodigoAlmacenProduccion = xProExi.CodigoAlmacen;
                iInsFal.CodigoPersonalProduccion = xProExi.CodigoPersonal;
                iInsFal.CantidadFaltanteOrigen = iExiOriEN.StockActualExistencia - iInsFal.CantidadFaltante;

                //agregamos a la lista resultado
                iLisRes.Add(iInsFal);
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveProduccionDeta(string pClaveProduccionDeta)
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.CodExi;

            //ejecutar metodo
            return ProduccionExisRN.ListarProduccionExisXClaveProduccionDeta(iProExiEN);
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveProduccionDetaYTipoDescarga(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisXClaveProduccionDetaYTipoDescarga(pObj);
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseMasa(ProduccionDetaEN pObj)
        {
            //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj);
            iForDetEN.CTipoDescarga = "0";//fase masa
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.ClaForDet;
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(iForDetEN);

            //devolver
            return ArmarListaProduccionesExisFaseMasa(pObj, iLisForDet); ;
        }

        public static void AdicionarProduccionesExisFaseMasa(ProduccionDetaEN pObj)
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ArmarListaProduccionesExisFaseMasa(pObj);

            //ejecutar metodo
            ProduccionExisRN.AdicionarProduccionExis(iLisProExi);
        }

        public static void ModificarCantidadKg(ProduccionExisEN pObj)
        {
            //traer al objeto de la b.d
            ProduccionExisEN iProExiEN = ProduccionExisRN.BuscarProduccionExisXClave(pObj);

            //actualizamos el dato
            iProExiEN.CantidadKg = pObj.CantidadKg;
            iProExiEN.CantidadGr = pObj.CantidadKg * 1000;
            iProExiEN.CantidadProduccionExis = ProduccionExisRN.ObtenerCantidadProduccionExis(iProExiEN);

            //modificar en b.d
            ProduccionExisRN.ModificarProduccionExis(iProExiEN);
        }

        public static void ModificarCantidadGr(ProduccionExisEN pObj)
        {
            //traer al objeto de la b.d
            ProduccionExisEN iProExiEN = ProduccionExisRN.BuscarProduccionExisXClave(pObj);

            //actualizamos el dato
            iProExiEN.CantidadGr = pObj.CantidadGr;
            iProExiEN.CantidadKg = pObj.CantidadGr / 1000;
            iProExiEN.CantidadProduccionExis = ProduccionExisRN.ObtenerCantidadProduccionExis(iProExiEN);

            //modificar en b.d
            ProduccionExisRN.ModificarProduccionExis(iProExiEN);
        }

        public static decimal ObtenerCantidadProduccionExis(ProduccionExisEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //obtener
            if (pObj.CodigoUnidadMedida == "006")//gramos
            {
                iValor = pObj.CantidadGr;
            }
            else
            {
                iValor = pObj.CantidadKg;
            }

            //devolver
            return iValor;
        }

        public static void ActualizarPreciosUnitariosDesdeExistencias(List<ProduccionExisEN> pLista)
        {
            //traer a todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //recorrer cada objeto 
            foreach (ProduccionExisEN xProExi in pLista)
            {
                //obtener la clave de existencia
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);

                //buscar esta clave en la lista de existencias
                ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi, iClaveExistencia);

                //actualizar el precio unitario
                xProExi.PrecioUnitario = iExiBusEN.PrecioPromedioExistencia;
            }

            //modificacion masiva
            ProduccionExisRN.ModificarProduccionExis(pLista);
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesParaParteTrabajoAlModificar(List<ProduccionExisEN> pLis,
            string pClaveMovimientoCabe)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //traer todos los movimientosdeta de esta claveMovimientoCabe
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(pClaveMovimientoCabe);

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLis)
            {
                //buscar por codigoExistencia
                MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CodExi, xProExi.CodigoExistencia);

                //si la cantidad de stock de la existencia es mayor que la de insumo,
                //entonces ya no avanza en el proceso
                if (iMovDetBusEN.StockAnteriorExistencia >= xProExi.CantidadProduccionExis) { continue; }

                //crear un objeto InsumoFaltante
                InsumoFaltante iInsFal = new InsumoFaltante();

                //pasamos datos
                iInsFal.CodigoLinea = xProExi.CorrelativoProduccionExis;
                iInsFal.CodigoExistencia = xProExi.CodigoExistencia;
                iInsFal.DescripcionExistencia = xProExi.DescripcionExistencia;
                iInsFal.CantidadStockExistencia = iMovDetBusEN.StockAnteriorExistencia;
                iInsFal.CantidadParteTrabajo = xProExi.CantidadProduccionExis;
                iInsFal.CantidadFaltante = iInsFal.CantidadParteTrabajo - iInsFal.CantidadStockExistencia;

                //agregamos a la lista resultado
                iLisRes.Add(iInsFal);
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ListarProduccionExis(string pClaveProduccionDeta, string pCTipoDescarga)
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iProExiEN.CTipoDescarga = pCTipoDescarga;
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.CorProExi;

            //ejecutar metodo
            return ProduccionExisRN.ListarProduccionExisXClaveProduccionDetaYTipoDescarga(iProExiEN);
        }

        public static decimal ObtenerCostoTotal(List<ProduccionExisEN> pLista)
        {
            //valor resultado
            decimal iValor = 0;

            //operar
            foreach (ProduccionExisEN xProExi in pLista)
            {
                iValor += xProExi.CantidadProduccionExis * xProExi.PrecioUnitario;
            }

            //redondear
            iValor = Math.Round(iValor, 2);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoTotalFaseMasa(string pClaveProduccionDeta)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //traer la lista de produccionExis solo fase masa
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExis(pClaveProduccionDeta, "0");

            //obtener el costo total de esta lista
            iValor = ProduccionExisRN.ObtenerCostoTotal(iLisProExi);

            //redondear
            iValor = Math.Round(iValor, 2);

            //devolver
            return iValor;
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseControlCalidad(ProduccionDetaEN pObj)
        {
            //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj);
            iForDetEN.CTipoDescarga = "1";//fase control calidad
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.ClaForDet;
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(iForDetEN);

            //devolver
            return ArmarListaProduccionesExisFaseCalidad(pObj, iLisForDet); ;
        }

        public static void AdicionarProduccionesExisFaseControlCalidad(ProduccionDetaEN pObj)
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ArmarListaProduccionesExisFaseControlCalidad(pObj);

            //ejecutar metodo
            ProduccionExisRN.AdicionarProduccionExis(iLisProExi);
        }

        public static decimal ObtenerCostoTotalFaseControlCalidad(string pClaveProduccionDeta)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //traer la lista de produccionExis solo fase control calidad
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExis(pClaveProduccionDeta, "1");

            //obtener el costo total de esta lista
            iValor = ProduccionExisRN.ObtenerCostoTotal(iLisProExi);

            //redondear
            iValor = Math.Round(iValor, 2);

            //devolver
            return iValor;
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseEmpaquetado(ProduccionDetaEN pObj, List<ProduccionProTerEN> pLisProProTer)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj);
            iForDetEN.CTipoDescarga = "2";//fase empaquetado
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.ClaForDet;
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(iForDetEN);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //solo los activos pasan
                if (xForDet.CEstadoFormulaDeta == "0") { continue; }

                //creamos un objeto ProduccionExis a partir de xForDet(FormulaDeta)
                ProduccionExisEN iProExiEN = ProduccionExisRN.CrearProduccionExis(xForDet, pLisProProTer[0]);

                //adicionamos a la lista resultado
                iLisRes.Add(iProExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static void ActualizarCorrelativoProduccionExis(List<ProduccionExisEN> pLista)
        {
            //correlativo
            string iCorrelativo = "0000";

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLista)
            {
                xProExi.CorrelativoProduccionExis = Numero.IncrementarCorrelativoNumerico(ref iCorrelativo);
                xProExi.ClaveProduccionExis = ProduccionExisRN.ObtenerClaveProduccionExisPT(xProExi);
            }
        }

        public static void AdicionarProduccionesExisFaseEmpaquetado(ProduccionDetaEN pObj, List<ProduccionProTerEN> pLisProProTer)
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ArmarListaProduccionesExisFaseEmpaquetado(pObj, pLisProProTer);

            //ejecutar metodo
            ProduccionExisRN.AdicionarProduccionExis(iLisProExi);
        }

        public static decimal ObtenerCostoTotalFaseEmpaquetado(string pClaveProduccionDeta)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //traer la lista de produccionExis solo fase control calidad
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExis(pClaveProduccionDeta, "2");

            //obtener el costo total de esta lista
            iValor = ProduccionExisRN.ObtenerCostoTotal(iLisProExi);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoTotalFaseEmpaquetadoSinCaja(string pClaveProduccionDeta)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //traer la lista de produccionExis solo fase empaquetado
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExis(pClaveProduccionDeta, "2");

            //filtrar solo los que son unidades y unidades + cajas
            iLisProExi = ListaG.FiltrarPorConjuntoValores<ProduccionExisEN>(iLisProExi, ProduccionExisEN.CTipFac, "1,3");

            //obtener el costo total de esta lista
            iValor = ProduccionExisRN.ObtenerCostoTotal(iLisProExi);

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoTotalFaseEmpaquetadoSoloCaja(string pClaveProduccionDeta)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //traer la lista de produccionExis solo fase control calidad
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExis(pClaveProduccionDeta, "2");

            //filtrar solo los que no son caja
            iLisProExi = ListaG.Filtrar<ProduccionExisEN>(iLisProExi, ProduccionExisEN.CTipFac, "1");

            //obtener el costo total de esta lista
            iValor = ProduccionExisRN.ObtenerCostoTotal(iLisProExi);

            //devolver
            return iValor;
        }

        public static ProduccionExisEN CrearProduccionExis(FormulaDetaEN pForDet, ProduccionProTerEN pProProTer)
        {
            //objeto resultado
            ProduccionExisEN iProExiEN = new ProduccionExisEN();

            //pasando datos           
            iProExiEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iProExiEN.CodigoAlmacen = pForDet.CodigoAlmacenOrigen;
            iProExiEN.CorrelativoProduccionExis = pForDet.CorrelativoFormulaDeta;
            iProExiEN.CodigoExistencia = pForDet.CodigoExistencia;
            iProExiEN.CodigoUnidadMedida = pForDet.CodigoUnidadMedida;
            iProExiEN.NombreUnidadMedida = pForDet.NombreUnidadMedida;
            iProExiEN.CantidadProduccionExis = ProduccionExisRN.CalcularCantidadProduccionExis(pForDet, pProProTer);
            iProExiEN.PrecioUnitario = pForDet.PrecioPromedioExistencia;
            iProExiEN.CantidadFormula = iProExiEN.CantidadProduccionExis;
            iProExiEN.CantidadGrFormula = iProExiEN.CantidadGr;
            iProExiEN.CantidadKgFormula = iProExiEN.CantidadKg;
            iProExiEN.CTipoDescarga = "2";//fase empaquetado
            iProExiEN.CTipoFactor = pForDet.CTipoFactor;
            iProExiEN.CodigoAlmacenProTer = pForDet.CodigoAlmacenProTer;
            iProExiEN.CodigoExistenciaProTer = pForDet.CodigoExistenciaProTer;
            iProExiEN.CodigoAlmacenOrigen = pForDet.CodigoAlmacenOrigen;
            iProExiEN.DescripcionAlmacenOrigen = pForDet.DescripcionAlmacenOrigen;
            iProExiEN.CodigoFormula = pForDet.CodigoExistenciaFormula;
            iProExiEN.DescripcionFormula = pForDet.DescripcionExistenciaFormula;
            iProExiEN.ClaveEncajado = pProProTer.ClaveEncajado;
            iProExiEN.ClaveProduccionProTer = pProProTer.ClaveProduccionProTer;
            iProExiEN.ClaveProduccionExis = ProduccionExisRN.ObtenerClaveProduccionExisPT(iProExiEN);
            iProExiEN.ClaveFormulaCabe = pForDet.ClaveFormulaCabe;
            iProExiEN.CSegundaLiberacion = pForDet.CSegundaLiberacion;

            //devolver
            return iProExiEN;
        }

        public static decimal CalcularCantidadProduccionExis(FormulaDetaEN pForDet, ProduccionDetaEN pProDet, ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //fase empaquetado
            if (pForDet.CTipoFactor == "1")//unidades
            {
                iValor = Math.Round(pForDet.CantidadFormulaDeta * (pProDet.NumeroUnidadesConCal - pProDet.NumeroUnidadesSueltas), 5);
            }
            else
            {
                if (pForDet.CTipoFactor == "3")//unidades + cajas
                {
                    //cantidad por unidad
                    iValor = Math.Round(pForDet.CantidadFormulaDeta * (pProDet.NumeroUnidadesConCal - pProDet.NumeroUnidadesSueltas), 5);

                    //mas cantidad por caja
                    iValor += Math.Round(pForDet.CantidadCajaFormulaDeta * pProDet.NumeroCajas, 5);
                }
                else
                {
                    if (pForDet.CodigoExistenciaProTer == string.Empty)
                    {
                        iValor = Math.Round(pForDet.CantidadFormulaDeta * pProDet.NumeroCajas, 5);
                    }
                    else
                    {
                        iValor = Math.Round(pForDet.CantidadFormulaDeta * pProProTer.NumeroCajas, 5);
                    }
                }
            }

            //devolver
            return iValor;
        }

        public static decimal ObtenerCostoTotalFaseEmpaquetadoSoloCaja(ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //traer la lista de produccionExis solo fase empaquetado
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExis(pProProTer.ClaveProduccionDeta, "2");

            //filtrar solo los que son caja
            iLisProExi = ListaG.Filtrar<ProduccionExisEN>(iLisProExi, ProduccionExisEN.CodExiProTer, pProProTer.CodigoExistencia);

            //obtener el costo total de esta lista
            iValor = ProduccionExisRN.ObtenerCostoTotal(iLisProExi);

            //devolver
            return iValor;
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveProduccionDetaYTiposDescarga(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(pObj);
        }

        public static void ModificarPorCantidadDigitada(ProduccionExisEN pObj)
        {
            //traer al objeto de la b.d
            ProduccionExisEN iProExiEN = ProduccionExisRN.BuscarProduccionExisXClave(pObj);

            //actualizar el dato cantidad digitada en el objeto de bd
            iProExiEN.CantidadProduccionExis = pObj.CantidadProduccionExis;

            //actualizamos al objeto por cantidad digitada
            ProduccionExisRN.ActualizarObjetoPorCantidadDigitada(iProExiEN);

            //modificar en b.d
            ProduccionExisRN.ModificarProduccionExis(iProExiEN);
        }

        public static void ActualizarObjetoPorCantidadDigitada(ProduccionExisEN pObj)
        {
            pObj.CantidadGr = ProduccionExisRN.CalcularCantidadGrPorCantidadDigitada(pObj);
            pObj.CantidadKg = ProduccionExisRN.CalcularCantidadKgPorCantidadDigitada(pObj);
        }

        public static decimal CalcularCantidadGrPorCantidadDigitada(ProduccionExisEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            if (pObj.CTipoDescarga == "0")//fase masa
            {
                if (pObj.CodigoUnidadMedida == "006")//gramos
                {
                    iValor = pObj.CantidadProduccionExis;
                }
                else
                {
                    iValor = pObj.CantidadProduccionExis * 1000;
                }
            }

            //devolver
            return iValor;
        }

        public static decimal CalcularCantidadKgPorCantidadDigitada(ProduccionExisEN pObj)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            if (pObj.CTipoDescarga == "0")//fase masa
            {
                if (pObj.CodigoUnidadMedida == "006")//gramos
                {
                    iValor = Operador.DivisionDecimal(pObj.CantidadProduccionExis, 1000);
                }
                else
                {
                    iValor = pObj.CantidadProduccionExis;
                }
            }

            //devolver
            return iValor;
        }

        public static List<ProduccionExisEN> ListarProduccionExisAcumulados(List<ProduccionCabeEN> pLisProCab)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = ProduccionExisRN.ListarProduccionExis(pLisProCab);

            //acumular las cantidades por codigoexistencia
            iLisRes = ProduccionExisRN.ListarProduccionExisAcumuladosPorCodigoExistencia(iLisRes);

            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ListarProduccionExisAcumuladosPorCodigoExistencia(List<ProduccionExisEN> pLisProExi)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //variable de encontrado
                int iEncontrado = 0;

                //buscar
                foreach (ProduccionExisEN xProExiBus in iLisRes)
                {
                    if (xProExi.CodigoExistencia == xProExiBus.CodigoExistencia)
                    {
                        xProExiBus.CantidadProduccionExis += xProExi.CantidadProduccionExis;
                        iEncontrado = 1;
                        continue;
                    }
                }

                //sino lo encontro agrega este objeto a la lista resultado
                if (iEncontrado == 0)
                {
                    iLisRes.Add(xProExi);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesParaCompra(List<ProduccionExisEN> pLis)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //crear una lista acumulada por codigoExistencia sin contemplar el almacen
            iLisExiEmp = ExistenciaRN.ListarExistenciaAcumuladosPorCodigoExistencia(iLisExiEmp);

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLis)
            {
                //armar la clave de la existencia
                string iClaveExistencia = xProExi.CodigoExistencia;

                //buscar a la existencia
                ExistenciaEN iExiEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.CodExi, iClaveExistencia);

                //si la cantidad de stock de la existencia es mayor que la de insumo,
                //entonces ya no avanza en el proceso
                if (iExiEN.StockActualExistencia >= xProExi.CantidadProduccionExis) { continue; }

                //crear un objeto InsumoFaltante
                InsumoFaltante iInsFal = new InsumoFaltante();

                //pasamos datos
                iInsFal.CodigoLinea = xProExi.CorrelativoProduccionExis;
                iInsFal.CodigoAlmacen = xProExi.CodigoAlmacenOrigen;
                iInsFal.DescripcionAlmacen = xProExi.DescripcionAlmacenOrigen;
                iInsFal.CodigoExistencia = iExiEN.CodigoExistencia;
                iInsFal.DescripcionExistencia = iExiEN.DescripcionExistencia;
                iInsFal.CantidadStockExistencia = iExiEN.StockActualExistencia;
                iInsFal.CantidadParteTrabajo = xProExi.CantidadProduccionExis;
                iInsFal.CantidadFaltante = iInsFal.CantidadParteTrabajo - iInsFal.CantidadStockExistencia;
                iInsFal.CUnidadMedida = xProExi.CodigoUnidadMedida;
                iInsFal.NUnidadMedida = xProExi.NombreUnidadMedida;

                //agregamos a la lista resultado
                iLisRes.Add(iInsFal);
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerClaveExistenciaOriginal(ProduccionExisEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoAlmacenOrigen + "-";
            iClave += pObj.CodigoExistencia;

            //retornar
            return iClave;
        }

        public static List<ProduccionExisEN> ListarProduccionExis(List<ProduccionCabeEN> pLisProCab)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //recorrer cada objeto solicitud
            foreach (ProduccionCabeEN xProCab in pLisProCab)
            {
                //creamos un parte de trabajo apartir de la solicitud
                ProduccionDetaEN iProDetEN = ProduccionDetaRN.CrearProduccionDetaParaCompra(xProCab);

                //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
                List<FormulaDetaEN> iLisForDetPro = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(ProduccionCabeRN.ObtenerClaveFormulaCabe(xProCab));

                //armar las cantidades que necesita esta parte de trabajo(solo fase masa)
                List<ProduccionExisEN> iLisProExiFasMas = ArmarListaProduccionesExisFaseMasa(iProDetEN, iLisForDetPro, xProCab.DetalleFormulasDeta);

                //agregamos a la lista de todos los produccionExis
                iLisRes.AddRange(iLisProExiFasMas);

                //armar las cantidades que necesita esta parte de trabajo(solo fase envasado)
                List<ProduccionExisEN> iLisProExiFasEmb = ArmarListaProduccionesExisFaseControlCalidad(iProDetEN, iLisForDetPro, xProCab.DetalleFormulasDeta);

                //agregamos a la lista de todos los produccionExis
                iLisRes.AddRange(iLisProExiFasEmb);
            }

            //devolver
            return iLisRes;
        }

        public static List<InsumoFaltante> ListarInsumosPlanificacion(List<ProduccionExisEN> pLis)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //crear una lista acumulada por codigoExistencia sin contemplar el almacen
            iLisExiEmp = ExistenciaRN.ListarExistenciaAcumuladosPorCodigoExistencia(iLisExiEmp);

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLis)
            {
                //armar la clave de la existencia
                string iClaveExistencia = xProExi.CodigoExistencia;

                //buscar a la existencia
                ExistenciaEN iExiEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.CodExi, iClaveExistencia);

                //crear un objeto InsumoFaltante
                InsumoFaltante iInsFal = new InsumoFaltante();

                //pasamos datos
                iInsFal.CodigoSolicitud = xProExi.CodigoSolicitud;
                iInsFal.FechaProduccion = xProExi.FechaProduccionDeta;
                iInsFal.CodigoFormula = xProExi.CodigoFormula;
                iInsFal.DescripcionFormula = xProExi.DescripcionFormula;
                iInsFal.CodigoLinea = xProExi.CorrelativoProduccionExis;
                iInsFal.CodigoAlmacen = xProExi.CodigoAlmacenOrigen;
                iInsFal.DescripcionAlmacen = xProExi.DescripcionAlmacenOrigen;
                iInsFal.CodigoExistencia = iExiEN.CodigoExistencia;
                iInsFal.DescripcionExistencia = iExiEN.DescripcionExistencia;
                iInsFal.CantidadStockExistencia = iExiEN.StockActualExistencia;
                iInsFal.CantidadParteTrabajo = xProExi.CantidadProduccionExis;
                iInsFal.CantidadFaltante = ProduccionExisRN.ObtenerCantidadFaltanteInsumosPlanificado(iInsFal);
                iInsFal.CUnidadMedida = xProExi.CodigoUnidadMedida;
                iInsFal.NUnidadMedida = xProExi.NombreUnidadMedida;
                iInsFal.CTurno = xProExi.CTurno;
                iInsFal.CantidadProduccionDeta = xProExi.CantidadProduccionDeta;
                iInsFal.AlmacenesStock = iExiEN.Adicionales.Mensaje;

                //agregamos a la lista resultado
                iLisRes.Add(iInsFal);

                //obtener el nuevo stock de la existencia
                iExiEN.StockActualExistencia = ProduccionExisRN.ObtenerStockExistenciaInsumosPlanificado(iInsFal);

                //modificar este dato en la lista de existencia
                ListaG.Modificar<ExistenciaEN>(iLisExiEmp, iExiEN, ExistenciaEN.CodExi, iExiEN.CodigoExistencia);
            }

            //devolver
            return iLisRes;
        }

        public static decimal ObtenerCantidadFaltanteInsumosPlanificado(InsumoFaltante pObj)
        {
            //calcular
            if (pObj.CantidadStockExistencia >= pObj.CantidadParteTrabajo)
            {
                return 0;
            }
            else
            {
                return pObj.CantidadParteTrabajo - pObj.CantidadStockExistencia;
            }
        }

        public static decimal ObtenerStockExistenciaInsumosPlanificado(InsumoFaltante pObj)
        {
            //calcular
            if (pObj.CantidadStockExistencia >= pObj.CantidadParteTrabajo)
            {
                return pObj.CantidadStockExistencia - pObj.CantidadParteTrabajo;
            }
            else
            {
                return 0;
            }
        }

        public static List<InsumoFaltante> ListarInsumosParaTransferirAProducccion()
        {
            //traer las produccionesExis solo de las partes de trabajo que aun no descargan la fase
            //materia prima y envasado a la mesa de trabajo
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisDetalladoParaTransferirAProduccion();

            //acumular esta lista por codigoexistencia
            iLisProExi = ProduccionExisRN.ListarProduccionExisAcumuladosPorCodigoExistencia(iLisProExi);

            //obtener la lista de insumos faltantes
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(iLisProExi);

            //devolver
            return iLisInsFal;
        }

        public static List<ProduccionExisEN> ListarProduccionExisDetalladoParaTransferirAProduccion()
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisDetalladoParaTransferirAProduccion();
        }

        public static decimal ObtenerCantidadNecesariaParaProducir(MovimientoDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //valor resultado
            decimal iValor = 0;

            //obtener
            //traer la lista de existencias para transferir a produccion(actual)
            List<InsumoFaltante> iLisExiTra = ProduccionExisRN.ListarInsumosParaTransferirAProducccion(pObj, pCodigoAlmacenProduccion);

            //buscar por codigoExistencia en la lista
            InsumoFaltante iInsFal = ListaG.Buscar<InsumoFaltante>(iLisExiTra, InsumoFaltante.CodExi, pObj.CodigoExistencia);

            //pasar el valor
            iValor = iInsFal.CantidadFaltante;

            //devolver
            return iValor;
        }

        public static decimal ObtenerCantidadNecesariaParaProducirOC(MovimientoOCDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //valor resultado
            decimal iValor = 0;

            //obtener
            //traer la lista de existencias para transferir a produccion(actual)
            List<InsumoFaltante> iLisExiTra = ProduccionExisRN.ListarInsumosParaTransferirAProducccionOC(pObj, pCodigoAlmacenProduccion);

            //buscar por codigoExistencia en la lista
            InsumoFaltante iInsFal = ListaG.Buscar<InsumoFaltante>(iLisExiTra, InsumoFaltante.CodExi, pObj.CodigoExistencia);

            //pasar el valor
            iValor = iInsFal.CantidadFaltante;

            //devolver
            return iValor;
        }

        public static List<InsumoFaltante> ListarInsumosParaTransferirAProducccion(MovimientoDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //traer las produccionesExis solo de las partes de trabajo que aun no descargan la fase
            //materia prima y embasado a la mesa de trabajo
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisDetalladoParaTransferirAProduccion();

            //acumular esta lista por codigoexistencia
            iLisProExi = ProduccionExisRN.ListarProduccionExisAcumuladosPorCodigoExistencia(iLisProExi);

            //obtener la lista de insumos faltantes
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(iLisProExi, pObj,
                 pCodigoAlmacenProduccion);

            //devolver
            return iLisInsFal;
        }

        public static List<InsumoFaltante> ListarInsumosParaTransferirAProducccionOC(MovimientoOCDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //traer las produccionesExis solo de las partes de trabajo que aun no descargan la fase
            //materia prima y embasado a la mesa de trabajo
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisDetalladoParaTransferirAProduccion();

            //acumular esta lista por codigoexistencia
            iLisProExi = ProduccionExisRN.ListarProduccionExisAcumuladosPorCodigoExistencia(iLisProExi);

            //obtener la lista de insumos faltantes
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajoOC(iLisProExi, pObj,
                 pCodigoAlmacenProduccion);

            //devolver
            return iLisInsFal;
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesParaParteTrabajo(List<ProduccionExisEN> pLisProExi,
            MovimientoDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //actualizar la existencia de pObj
            ExistenciaRN.ActualizarExistenciaAlModificarMovimientoSalida(iLisExiEmp, pObj, pCodigoAlmacenProduccion);

            //obtener la lista insumos faltantes
            iLisRes = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(iLisExiEmp, pLisProExi);

            //devolver
            return iLisRes;
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesParaParteTrabajoOC(List<ProduccionExisEN> pLisProExi,
    MovimientoOCDetaEN pObj, string pCodigoAlmacenProduccion)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //actualizar la existencia de pObj
            ExistenciaRN.ActualizarExistenciaAlModificarMovimientoSalidaOC(iLisExiEmp, pObj, pCodigoAlmacenProduccion);

            //obtener la lista insumos faltantes
            iLisRes = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(iLisExiEmp, pLisProExi);

            //devolver
            return iLisRes;
        }

        public static List<InsumoFaltante> ListarInsumosDetalladosParaTransferirAProducccion()
        {
            //traer las produccionesExis solo de las partes de trabajo que aun no descargan la fase
            //materia prima y envasado a la mesa de trabajo
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisDetalladoParaTransferirAProduccion();

            //obtener la lista de insumos faltantes
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(iLisProExi);

            //devolver
            return iLisInsFal;
        }

        public static List<InsumoFaltante> ListarInsumosParaTransferirAProducccion(List<ProduccionDetaEN> pLisProDet)
        {
            //obtener las claves ProduccionDeta en formato In
            string iClavesProduccionDeta = ListaG.ArmarCadenaParaIN<ProduccionDetaEN>(pLisProDet, ProduccionDetaEN.ClaProDet);

            //traer las produccionesExis solo de las partes de trabajo de esta lista
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisParaTransferirAProduccion(
                iClavesProduccionDeta);

            //acumular esta lista por codigoexistencia
            iLisProExi = ProduccionExisRN.ListarProduccionExisAcumuladosPorCodigoExistencia(iLisProExi);

            //obtener la lista de insumos faltantes
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(iLisProExi);

            //devolver
            return iLisInsFal;
        }

        public static List<ProduccionExisEN> ListarProduccionExisDetalladoParaTransferirAProduccion(string pClavesProduccionDeta)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisDetalladoParaTransferirAProduccion(pClavesProduccionDeta);
        }

        public static List<ProduccionExisEN> ListarProduccionExisParaTransferirAProduccion(string pClavesProduccionDeta)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisParaTransferirAProduccion(pClavesProduccionDeta);
        }

        public static List<InsumoFaltante> ListarInsumosDetalladoParaTransferirAProducccion(List<ProduccionDetaEN> pLisProDet)
        {
            //obtener las claves ProduccionDeta en formato In
            string iClavesProduccionDeta = ListaG.ArmarCadenaParaIN<ProduccionDetaEN>(pLisProDet, ProduccionDetaEN.ClaProDet);

            //traer las produccionesExis solo de las partes de trabajo de esta lista
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisDetalladoParaTransferirAProduccion(
                iClavesProduccionDeta);

            //obtener la lista de insumos faltantes
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosFaltantesDetalladoParaParteTrabajo(iLisProExi);

            //sacar a los objetos que si tienen insumos 

            //devolver
            return iLisInsFal;
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesDetalladoParaParteTrabajo(List<ProduccionExisEN> pLisProExi)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //obtener la lista insumos faltantes
            iLisRes = ProduccionExisRN.ListarInsumosFaltantesDetalladoParaParteTrabajo(iLisExiEmp, pLisProExi);

            //devolver
            return iLisRes;
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesDetalladoParaParteTrabajo(List<ExistenciaEN> pLisExi, List<ProduccionExisEN> pLis)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLis)
            {
                //armar la clave de la existencia
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);

                //buscar a la existencia
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //crear un objeto InsumoFaltante
                InsumoFaltante iInsFal = new InsumoFaltante();

                //pasamos datos
                iInsFal.CodigoLinea = xProExi.CorrelativoProduccionExis;
                iInsFal.CodigoSolicitud = xProExi.CorrelativoProduccionCabe;
                iInsFal.CodigoFormula = xProExi.CodigoFormula;
                iInsFal.DescripcionFormula = xProExi.DescripcionFormula;
                iInsFal.CodigoExistencia = iExiEN.CodigoExistencia;
                iInsFal.DescripcionExistencia = iExiEN.DescripcionExistencia;
                iInsFal.CantidadStockExistencia = iExiEN.StockActualExistencia;
                iInsFal.CantidadParteTrabajo = xProExi.CantidadProduccionExis;
                iInsFal.CantidadFaltante = ProduccionExisRN.ObtenerCantidadFaltanteInsumosPlanificado(iInsFal);
                iInsFal.CodigoAlmacen = xProExi.CodigoAlmacenOrigen;
                iInsFal.DescripcionAlmacen = xProExi.DescripcionAlmacenOrigen;
                iInsFal.CodigoPersonal = xProExi.CodigoPersonalOrigen;
                iInsFal.CUnidadMedida = xProExi.CodigoUnidadMedida;
                iInsFal.NUnidadMedida = xProExi.NombreUnidadMedida;
                iInsFal.FechaProduccion = xProExi.FechaProduccionDeta;
                iInsFal.CodigoAlmacenProduccion = xProExi.CodigoAlmacen;
                iInsFal.CodigoPersonalProduccion = xProExi.CodigoPersonal;

                //agregamos a la lista resultado
                iLisRes.Add(iInsFal);

                //obtener el nuevo stock de la existencia
                iExiEN.StockActualExistencia = ProduccionExisRN.ObtenerStockExistenciaInsumosPlanificado(iInsFal);

                //modificar este dato en la lista de existencia
                ListaG.Modificar<ExistenciaEN>(pLisExi, iExiEN, ExistenciaEN.CodExi, iExiEN.CodigoExistencia);
            }

            //devolver
            return iLisRes;
        }

        public static void AdicionarProduccionExisFaseEmpaquetado(List<ProduccionProTerEN> pLisProProTer)
        {
            //lista para adicionar
            List<ProduccionExisEN> iLisProExiAdi = new List<ProduccionExisEN>();

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in pLisProProTer)
            {
                //obtener un objeto ProduccionDeta con los parametros necesarios para que opere en el armado
                //de las ProduccionesExis fase empaquetado
                ProduccionDetaEN iProDetEN = ProduccionDetaRN.ObtenerProduccionDetaParaOperarFaseEmpaquetado(xProProTer);

                //agregar en una lista a este ProTer
                List<ProduccionProTerEN> iLisProProTer = new List<ProduccionProTerEN>();
                iLisProProTer.Add(xProProTer);

                //obtener la lista de producciones exis para este proter
                List<ProduccionExisEN> iLisProExi = ArmarListaProduccionesExisFaseEmpaquetado(iProDetEN, iLisProProTer);

                //agregar a la lista resultado
                iLisProExiAdi.AddRange(iLisProExi);
            }

            //reordenar el correlativo ProduccionExis y su clave
            ProduccionExisRN.ActualizarCorrelativoProduccionExis(iLisProExiAdi);

            //adicionar masivo
            ProduccionExisRN.AdicionarProduccionExis(iLisProExiAdi);
        }

        public static decimal CalcularCantidadProduccionExis(FormulaDetaEN pForDet, ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //fase empaquetado
            if (pForDet.CTipoFactor == "1")//unidades
            {
                iValor = Math.Round(pForDet.CantidadFormulaDeta * (pProProTer.CantidadUnidadesProTer + pProProTer.CantidadUnidadesRango), 5);
            }
            else
            {
                if (pForDet.CTipoFactor == "3")//unidades + cajas
                {
                    //cantidad por unidad
                    iValor = Math.Round(pForDet.CantidadFormulaDeta * (pProProTer.CantidadUnidadesProTer + pProProTer.CantidadUnidadesRango), 5);

                    //mas cantidad por caja
                    iValor += Math.Round(pForDet.CantidadCajaFormulaDeta * (pProProTer.NumeroCajas + pProProTer.CantidadCajasRango), 5);
                }
                else
                {
                    iValor = Math.Round(pForDet.CantidadFormulaDeta * (pProProTer.NumeroCajas + pProProTer.CantidadCajasRango), 5);
                }
            }

            //devolver
            return iValor;
        }

        public static string ObtenerClaveProduccionExisPT(ProduccionExisEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave            
            iClave += pObj.ClaveEncajado + "-";
            iClave += pObj.CorrelativoProduccionExis;

            //devolver
            return iClave;
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveEncajado(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisXClaveEncajado(pObj);
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveEncajado(string pClaveEncajado)
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveEncajado = pClaveEncajado;
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;

            //ejecutar metodo
            return ProduccionExisRN.ListarProduccionExisXClaveEncajado(iProExiEN);
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesDetalladoParaEncajado(string pClaveEncajado)
        {
            //listar las ProduccionesExis de este encajado
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveEncajado(pClaveEncajado);

            //ejecutar metodo
            return ProduccionExisRN.ListarInsumosFaltantesDetalladoParaEncajado(iLisProExi);
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesDetalladoParaEncajado(List<ProduccionExisEN> pLisProExi)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //traer todas las existencias de la empresa
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //obtener la lista insumos faltantes
            iLisRes = ProduccionExisRN.ListarInsumosFaltantesDetalladoParaEncajado(iLisExiEmp, pLisProExi);

            //devolver
            return iLisRes;
        }

        public static List<InsumoFaltante> ListarInsumosFaltantesDetalladoParaEncajado(List<ExistenciaEN> pLisExi, List<ProduccionExisEN> pLis)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLis)
            {
                //armar la clave de la existencia
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);

                //buscar a la existencia
                ExistenciaEN iExiEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                //crear un objeto InsumoFaltante
                InsumoFaltante iInsFal = new InsumoFaltante();

                //pasamos datos
                iInsFal.CodigoLinea = xProExi.CorrelativoProduccionExis;
                iInsFal.CodigoSolicitud = xProExi.ClaveEncajado;
                iInsFal.CodigoFormula = xProExi.CodigoFormula;
                iInsFal.DescripcionFormula = xProExi.DescripcionFormula;
                iInsFal.CodigoExistencia = iExiEN.CodigoExistencia;
                iInsFal.DescripcionExistencia = iExiEN.DescripcionExistencia;
                iInsFal.CantidadStockExistencia = iExiEN.StockActualExistencia;
                iInsFal.CantidadParteTrabajo = xProExi.CantidadProduccionExis;
                iInsFal.CantidadFaltante = ProduccionExisRN.ObtenerCantidadFaltanteInsumosPlanificado(iInsFal);
                iInsFal.CodigoAlmacen = xProExi.CodigoAlmacenOrigen;
                iInsFal.DescripcionAlmacen = xProExi.DescripcionAlmacenOrigen;
                iInsFal.CodigoPersonal = xProExi.CodigoPersonalOrigen;
                iInsFal.CUnidadMedida = xProExi.CodigoUnidadMedida;
                iInsFal.NUnidadMedida = xProExi.NombreUnidadMedida;
                iInsFal.FechaProduccion = xProExi.FechaProduccionDeta;
                iInsFal.CodigoAlmacenProduccion = xProExi.CodigoAlmacen;
                iInsFal.CodigoPersonalProduccion = xProExi.CodigoPersonal;

                //agregamos a la lista resultado
                iLisRes.Add(iInsFal);

                //obtener el nuevo stock de la existencia
                iExiEN.StockActualExistencia = ProduccionExisRN.ObtenerStockExistenciaInsumosPlanificado(iInsFal);

                //modificar este dato en la lista de existencia
                ListaG.Modificar<ExistenciaEN>(pLisExi, iExiEN, ExistenciaEN.CodExi, iExiEN.CodigoExistencia);
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ListarProduccionExisAcumuladoXClaveEncajado(ProduccionExisEN pObj)
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveEncajado(pObj.ClaveEncajado);

            //ejecutar metodo
            return ProduccionExisRN.ListarProduccionExisAcumuladosPorCodigoExistencia(iLisProExi);
        }

        public static decimal ObtenerCostoTotalFaseEmpaquetado(ProduccionProTerEN pProProTer)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //traer la lista de produccionExis solo fase empaquetado
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionProTer(pProProTer.ClaveProduccionProTer);

            //obtener el costo total de esta lista
            iValor = ProduccionExisRN.ObtenerCostoTotal(iLisProExi);

            //devolver
            return iValor;
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveProduccionProTer(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisXClaveProduccionProTer(pObj);
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveProduccionProTer(string pClaveProduccionProTer)
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionProTer = pClaveProduccionProTer;
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;

            //ejecutar metodo
            return ProduccionExisRN.ListarProduccionExisXClaveProduccionProTer(iProExiEN);
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseMasaYCalidad(ProduccionDetaEN pProDet, ProduccionCabeEN pProCab)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
            List<FormulaDetaEN> iLisForDetPro = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(ProduccionDetaRN.ObtenerClaveFormulaCabe(pProDet));

            //agregar las listas de fase masa y calidad
            iLisRes.AddRange(ProduccionExisRN.ArmarListaProduccionesExisFaseMasa(pProDet, iLisForDetPro, pProCab.DetalleFormulasDeta));
            iLisRes.AddRange(ProduccionExisRN.ArmarListaProduccionesExisFaseControlCalidad(pProDet, iLisForDetPro, pProCab.DetalleFormulasDeta));

            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseMasa(ProduccionDetaEN pObj, List<FormulaDetaEN> pLisForDetPro)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //filtrar a las FormulasDeta de fase masa            
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDetPro, FormulaDetaEN.CTipDes, "0");

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //creamos un objeto ProduccionExis a partir de xForDet(FormulaDeta)
                ProduccionExisEN iProExiEN = ProduccionExisRN.CrearProduccionExis(xForDet, pObj, "0");

                //adicionamos a la lista resultado
                iLisRes.Add(iProExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseCalidad(ProduccionDetaEN pObj, List<FormulaDetaEN> pLisForDetPro)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //filtrar a las FormulasDeta de fase calidad           
            List<FormulaDetaEN> iLisForDet = ListaG.Filtrar<FormulaDetaEN>(pLisForDetPro, FormulaDetaEN.CTipDes, "1");

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //creamos un objeto ProduccionExis a partir de xForDet(FormulaDeta)
                ProduccionExisEN iProExiEN = ProduccionExisRN.CrearProduccionExis(xForDet, pObj, "1");

                //adicionamos a la lista resultado
                iLisRes.Add(iProExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static List<InsumoFaltante> ListarInsumosDetalladoParaEncajar()
        {
            //asignar parametros           
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisParaCompraEncajado();
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //ejecutar metodo
            return ProduccionExisRN.ListarInsumosFaltantesDetalladoParaEncajado(iLisExiEmp, iLisProExi);
        }

        public static List<ProduccionExisEN> ListarProduccionExisParaCompraEncajado()
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisParaCompraEncajado();
        }

        public static List<ProduccionExisEN> ListarProduccionExisParaRecalculoProducciones(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisParaRecalculoProducciones(pObj);
        }

        public static List<ProduccionExisEN> ListarProduccionExisParaRecalculoProducciones(string pAño, string pCodigoMes)
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.PeriodoProduccionDeta = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iProExiEN.PeriodoEncajado = iProExiEN.PeriodoProduccionDeta;
            iProExiEN.PeriodoRetiquetado = iProExiEN.PeriodoProduccionDeta;
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProDet;

            //ejecutar metodo
            return ProduccionExisRN.ListarProduccionExisParaRecalculoProducciones(iProExiEN);
        }

        public static void ActualizarPreciosUnitariosDesdeExistencias(List<ProduccionExisEN> pLisProExi, List<ExistenciaEN> pLisExi)
        {
            //recorrer cada objeto 
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //obtener la clave de existencia
                string iClaveExistencia = ProduccionExisRN.ObtenerClaveExistencia(xProExi);

                //buscar esta clave en la lista de existencias
                ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(pLisExi, ExistenciaEN.ClaExi, iClaveExistencia);

                //actualizar el precio unitario
                xProExi.PrecioUnitario = iExiBusEN.PrecioPromedioExistencia;
            }
        }

        public static List<InsumoFaltante> ListarInsumosParaTransferirAProducccion(List<ProduccionDetaEN> pLisProDet, List<ExistenciaEN> pLisExi)
        {
            //obtener las claves ProduccionDeta en formato In
            string iClavesProduccionDeta = ListaG.ArmarCadenaParaIN<ProduccionDetaEN>(pLisProDet, ProduccionDetaEN.ClaProDet);

            //traer las produccionesExis solo de las partes de trabajo de esta lista
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisParaTransferirAProduccion(
                iClavesProduccionDeta);

            //acumular esta lista por codigoexistencia
            iLisProExi = ProduccionExisRN.ListarProduccionExisAcumuladosPorCodigoExistencia(iLisProExi);

            //obtener la lista de insumos faltantes
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(pLisExi, iLisProExi);

            //devolver
            return iLisInsFal;
        }

        public static void ActualizarPreciosUnitariosDesdeMovimientosDeta(List<ProduccionExisEN> pLisProExi, List<MovimientoDetaEN> pLisMovDet)
        {
            //recorrer cada objeto 
            foreach (ProduccionExisEN xProExi in pLisProExi)
            {
                //buscar por el codigo existencia
                MovimientoDetaEN iMovDetBusEN = ListaG.Buscar<MovimientoDetaEN>(pLisMovDet, MovimientoDetaEN.CodExi, xProExi.CodigoExistencia);

                //actualizar el precio unitario
                xProExi.PrecioUnitario = iMovDetBusEN.PrecioExistencia;
            }
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseMasa(ProduccionDetaEN pObj, List<FormulaDetaEN> pLisForDetPro, string pDetalleFormulasDeta)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //obtener la lista armada de produccion exis fase masa
            List<ProduccionExisEN> iLisProExi = ArmarListaProduccionesExisFaseMasa(pObj, pLisForDetPro);

            //convertir el campo DetalleFormulasDeta a lista 
            List<FormulaDetaEN> iLisForDet = ProduccionCabeRN.ConvertirCampoDetalleFormulasDetaALista(pDetalleFormulasDeta);

            //recorrer cada objeto formulaDeta
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //buscar si hay una ProduccionExis con esta existencia
                ProduccionExisEN iProExiBusEN = ListaG.Buscar<ProduccionExisEN>(iLisProExi, ProduccionExisEN.CodExi, xForDet.CodigoExistencia);

                //si hay,entra a la lista resultado
                if (iProExiBusEN.CodigoExistencia != string.Empty)
                {
                    iLisRes.Add(iProExiBusEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseControlCalidad(ProduccionDetaEN pObj, List<FormulaDetaEN> pLisForDetPro,
            string pDetalleFormulasDeta)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //obtener la lista armada de produccion exis fase masa
            List<ProduccionExisEN> iLisProExi = ArmarListaProduccionesExisFaseCalidad(pObj, pLisForDetPro);

            //convertir el campo DetalleFormulasDeta a lista 
            List<FormulaDetaEN> iLisForDet = ProduccionCabeRN.ConvertirCampoDetalleFormulasDetaALista(pDetalleFormulasDeta);

            //recorrer cada objeto formulaDeta
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //buscar si hay una ProduccionExis con esta existencia
                ProduccionExisEN iProExiBusEN = ListaG.Buscar<ProduccionExisEN>(iLisProExi, ProduccionExisEN.CodExi, xForDet.CodigoExistencia);

                //si hay,entra a la lista resultado
                if (iProExiBusEN.CodigoExistencia != string.Empty)
                {
                    iLisRes.Add(iProExiBusEN);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void AdicionarProduccionesExisFaseMasa(ProduccionDetaEN pObj, string pDetalleFormulasDeta)
        {
            //asignar parametros
            List<FormulaDetaEN> iLisForDetPro = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj));
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ArmarListaProduccionesExisFaseMasa(pObj, iLisForDetPro, pDetalleFormulasDeta);

            //ejecutar metodo
            ProduccionExisRN.AdicionarProduccionExis(iLisProExi);
        }

        public static void AdicionarProduccionesExisFaseControlCalidad(ProduccionDetaEN pObj, string pDetalleFormulasDeta)
        {
            //asignar parametros
            List<FormulaDetaEN> iLisForDetPro = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj));
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ArmarListaProduccionesExisFaseControlCalidad(pObj, iLisForDetPro, pDetalleFormulasDeta);

            //ejecutar metodo
            ProduccionExisRN.AdicionarProduccionExis(iLisProExi);
        }

        public static void AdicionarProduccionExisFaseEmpaquetadoRE(RetiquetadoEN pObj)
        {
            //lista para adicionar
            List<ProduccionExisEN> iLisProExiAdi = new List<ProduccionExisEN>();

            //obtener un objeto ProduccionDeta con los parametros necesarios para que opere en el armado
            //de las ProduccionesExis fase empaquetado
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.ObtenerProduccionDetaParaOperarFaseEmpaquetado(pObj);

            //obtener la lista de producciones exis para este proter
            List<ProduccionExisEN> iLisProExi = ArmarListaProduccionesExisFaseEmpaquetadoRE(iProDetEN, pObj);

            //agregar a la lista resultado
            iLisProExiAdi.AddRange(iLisProExi);

            //reordenar el correlativo ProduccionExis y su clave
            ProduccionExisRN.ActualizarCorrelativoProduccionExisRE(iLisProExiAdi);

            //adicionar masivo
            ProduccionExisRN.AdicionarProduccionExis(iLisProExiAdi);
        }

        public static List<ProduccionExisEN> ArmarListaProduccionesExisFaseEmpaquetadoRE(ProduccionDetaEN pObjProDet, RetiquetadoEN pObjRet)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
            FormulaDetaEN iForDetEN = new FormulaDetaEN();
            iForDetEN.ClaveFormulaCabe = ProduccionDetaRN.ObtenerClaveFormulaCabe(pObjProDet);
            iForDetEN.CTipoDescarga = "2";//fase empaquetado
            iForDetEN.Adicionales.CampoOrden = FormulaDetaEN.ClaForDet;
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabeYTipoDescarga(iForDetEN);

            //recorrer cada objeto
            foreach (FormulaDetaEN xForDet in iLisForDet)
            {
                //solo los activos pasan
                if (xForDet.CEstadoFormulaDeta == "0") { continue; }

                //creamos un objeto ProduccionExis a partir de xForDet(FormulaDeta)
                ProduccionExisEN iProExiEN = ProduccionExisRN.CrearProduccionExis(xForDet, pObjRet);

                //adicionamos a la lista resultado
                iLisRes.Add(iProExiEN);
            }

            //devolver
            return iLisRes;
        }

        public static ProduccionExisEN CrearProduccionExis(FormulaDetaEN pForDet, RetiquetadoEN pRet)
        {
            //objeto resultado
            ProduccionExisEN iProExiEN = new ProduccionExisEN();

            //pasando datos           
            iProExiEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iProExiEN.CodigoAlmacen = pForDet.CodigoAlmacenOrigen;
            iProExiEN.CorrelativoProduccionExis = pForDet.CorrelativoFormulaDeta;
            iProExiEN.CodigoExistencia = pForDet.CodigoExistencia;
            iProExiEN.CodigoUnidadMedida = pForDet.CodigoUnidadMedida;
            iProExiEN.NombreUnidadMedida = pForDet.NombreUnidadMedida;
            iProExiEN.CantidadProduccionExis = ProduccionExisRN.CalcularCantidadProduccionExis(pForDet, pRet);
            iProExiEN.PrecioUnitario = pForDet.PrecioPromedioExistencia;
            iProExiEN.CantidadFormula = iProExiEN.CantidadProduccionExis;
            iProExiEN.CantidadGrFormula = iProExiEN.CantidadGr;
            iProExiEN.CantidadKgFormula = iProExiEN.CantidadKg;
            iProExiEN.CTipoDescarga = "2";//fase empaquetado
            iProExiEN.CTipoFactor = pForDet.CTipoFactor;
            iProExiEN.CodigoAlmacenProTer = pForDet.CodigoAlmacenProTer;
            iProExiEN.CodigoExistenciaProTer = pForDet.CodigoExistenciaProTer;
            iProExiEN.CodigoAlmacenOrigen = pForDet.CodigoAlmacenOrigen;
            iProExiEN.DescripcionAlmacenOrigen = pForDet.DescripcionAlmacenOrigen;
            iProExiEN.CodigoFormula = pForDet.CodigoExistenciaFormula;
            iProExiEN.DescripcionFormula = pForDet.DescripcionExistenciaFormula;
            iProExiEN.ClaveRetiquetado = pRet.ClaveRetiquetado;
            iProExiEN.ClaveProduccionExis = ProduccionExisRN.ObtenerClaveProduccionExisRE(iProExiEN);
            iProExiEN.ClaveFormulaCabe = pForDet.ClaveFormulaCabe;

            //devolver
            return iProExiEN;
        }

        public static decimal CalcularCantidadProduccionExis(FormulaDetaEN pForDet, RetiquetadoEN pRet)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.CantidadUnidadesProTer = pRet.CantidadUnidadesRetiquetado;
            iProProTerEN.NumeroCajas = pRet.CantidadCajasRetiquetado;
            iProProTerEN.CantidadUnidadesRango = pRet.CantidadUnidadesRango;
            iProProTerEN.CantidadCajasRango = pRet.CantidadCajasRango;

            //ejecutar metodo
            return CalcularCantidadProduccionExis(pForDet, iProProTerEN);
        }

        public static string ObtenerClaveProduccionExisRE(ProduccionExisEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave            
            iClave += pObj.ClaveRetiquetado + "-RE-";
            iClave += pObj.CorrelativoProduccionExis;

            //devolver
            return iClave;
        }

        public static void ActualizarCorrelativoProduccionExisRE(List<ProduccionExisEN> pLista)
        {
            //correlativo
            string iCorrelativo = "0000";

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLista)
            {
                xProExi.CorrelativoProduccionExis = Numero.IncrementarCorrelativoNumerico(ref iCorrelativo);
                xProExi.ClaveProduccionExis = ProduccionExisRN.ObtenerClaveProduccionExisRE(xProExi);
            }
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveRetiquetado(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisXClaveRetiquetado(pObj);
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveRetiquetado(string pClaveRetiquetado)
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveRetiquetado = pClaveRetiquetado;
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;

            //ejecutar metodo
            return ListarProduccionExisXClaveRetiquetado(iProExiEN);
        }

        public static decimal ObtenerCostoTotalFaseEmpaquetadoRE(string pClaveProduccionDeta)
        {
            //valor resultado
            decimal iValor = 0;

            //calcular
            //traer la lista de produccionExis solo fase control calidad
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExis(pClaveProduccionDeta, "2");

            //obtener el costo total de esta lista
            iValor = ProduccionExisRN.ObtenerCostoTotal(iLisProExi);

            //devolver
            return iValor;
        }

        public static ProduccionExisEN ValidaCuandoUnidadesDesmedroNoTieneIgualCantidadUnidadesMotivos(ProduccionExisEN pObj)
        {
            //objeto resultado
            ProduccionExisEN iProExiEN = new ProduccionExisEN();

            //validar            
            List<ItemGEN> iLisIteG = new List<ItemGEN>();
            List<MotivoLiberacion> iLisMotLib = LiberacionRN.ConvertirCampoDetalleMotivoALista(pObj.DetalleMotivoDesmedro, iLisIteG);
            decimal iCantidadSugerida = LiberacionRN.CantidadMotivoLiberacionSugerida(pObj.CantidadDesmedro, iLisMotLib);
            if (pObj.CantidadDesmedro != 0 && iCantidadSugerida != 0)
            {
                iProExiEN.Adicionales.EsVerdad = false;
                iProExiEN.Adicionales.Mensaje = "Las cantidades en los motivos no suman la cantidad desmedro";
            }

            //devolver
            return iProExiEN;
        }

        public static ProduccionExisEN ValidaCuandoItemsTienenCantidadDesmedroCero(List<ProduccionExisEN> pLista)
        {
            //objeto resultado
            ProduccionExisEN iProExiEN = new ProduccionExisEN();

            //validar            
            List<ProduccionExisEN> iLisProExi = ListaG.Filtrar<ProduccionExisEN>(pLista, ProduccionExisEN.CanDes, "0.00000");
            if (iLisProExi.Count != 0)
            {
                iProExiEN.Adicionales.EsVerdad = false;
                iProExiEN.Adicionales.Mensaje = "Las cantidades desmedro no pueden ser cero";
            }

            //devolver
            return iProExiEN;
        }

        public static ProduccionExisEN ValidaCuandoCantidadDesmedroEsMayorCantidadFormula(ProduccionExisEN pObj)
        {
            //objeto resultado
            ProduccionExisEN iProExiEN = new ProduccionExisEN();

            //validar                        
            if (pObj.CantidadDesmedro > pObj.CantidadProduccionExis)
            {
                iProExiEN.Adicionales.EsVerdad = false;
                iProExiEN.Adicionales.Mensaje = "La cantidad desmedro no puede ser mayor a la cantidad formula";
            }

            //devolver
            return iProExiEN;
        }

        public static void ModificarProduccionesExisPorDesactivacionDesmedro(string pClaveProduccionDeta)
        {
            //traer toda la ProduccionExis de la fase envasado
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iProExiEN.CTipoDescarga = "'1'";//fase envasado
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(iProExiEN);

            //lista a grabar en bd
            List<ProduccionExisEN> iLisProExiMod = new List<ProduccionExisEN>();

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in iLisProExi)
            {
                if (xProExi.CEstadoDesmedro == "1" && xProExi.CantidadDesmedro == 0)
                {
                    xProExi.CEstadoDesmedro = "0";//desactivado
                    xProExi.DetalleMotivoDesmedro = string.Empty;
                    iLisProExiMod.Add(xProExi);
                }
            }

            //modificar masivo
            ModificarProduccionExis(iLisProExiMod);
        }

        public static List<InsumoFaltante> FiltrarInsumosFaltantesConCantidadfaltanteOrigenEnNegativos(List<InsumoFaltante> pLista)
        {
            //lista resultado
            List<InsumoFaltante> iLisRes = new List<InsumoFaltante>();

            //recorrer cada objeto
            foreach (InsumoFaltante xInsFal in pLista)
            {
                if (xInsFal.CantidadFaltanteOrigen < 0)
                {
                    xInsFal.CantidadFaltanteOrigen = -xInsFal.CantidadFaltanteOrigen;
                    iLisRes.Add(xInsFal);
                }
            }

            //devolver
            return iLisRes;
        }

        public static void ModificarPorCantidadDigitadaSincerado(ProduccionExisEN pObj)
        {
            //traer al objeto de la b.d
            ProduccionExisEN iProExiEN = ProduccionExisRN.BuscarProduccionExisXClave(pObj);

            //actualizar el dato cantidad digitada en el objeto de bd
            iProExiEN.CantidadDevueltaProduccionExis = pObj.CantidadDevueltaProduccionExis;
            iProExiEN.CantidadProduccionExis = iProExiEN.CantidadFormula - iProExiEN.CantidadDevueltaProduccionExis;

            //actualizamos al objeto por cantidad digitada
            ProduccionExisRN.ActualizarObjetoPorCantidadDigitada(iProExiEN);

            //modificar en b.d
            ProduccionExisRN.ModificarProduccionExis(iProExiEN);
        }

        public static void RecalcularPorSincerado(ProduccionDetaEN pObj)
        {
            //obtener la lista recalculada por sincerado
            List<ProduccionExisEN> iLisProExi = ListarRecalculoPorSincerado(pObj);

            //modificar en b.d
            ModificarProduccionExis(iLisProExi);
        }

        public static List<ProduccionExisEN> ListarRecalculoPorSincerado(ProduccionDetaEN pObj)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer las Producciones Exis de este parte de trabajo
            List<ProduccionExisEN> iLisProExi = ListarProduccionExisXClaveProduccionDeta(pObj.ClaveProduccionDeta);

            //traer todas las FormulasDeta de la FormulaCabe que se encuentra en esta parte de trabajo
            List<FormulaDetaEN> iLisForDetPro = FormulaDetaRN.ListarFormulasDetaXClaveFormulaCabe(ProduccionDetaRN.ObtenerClaveFormulaCabe(pObj));

            //recorrer cada objeto ProduccionExis
            foreach (ProduccionExisEN xProExi in iLisProExi)
            {
                //obtener  a la formulaDeta de este xProExi
                FormulaDetaEN iForDetEN = ListaG.Buscar<FormulaDetaEN>(iLisForDetPro, FormulaDetaEN.CorForDet, xProExi.CorrelativoProduccionExis);

                //actualizar datos
                xProExi.CantidadGr = ProduccionExisRN.CalcularCantidadGr(iForDetEN, pObj.CantidadSinceradoProduccionDeta);
                xProExi.CantidadKg = ProduccionExisRN.CalcularCantidadKg(iForDetEN, pObj.CantidadSinceradoProduccionDeta);
                xProExi.CantidadProduccionExis = ProduccionExisRN.CalcularCantidadProduccionExis(iForDetEN, pObj);
                xProExi.CantidadDevueltaProduccionExis = xProExi.CantidadFormula - xProExi.CantidadProduccionExis;

                //agregar a lista resultado
                iLisRes.Add(xProExi);
            }

            //devolver
            return iLisRes;
        }

        public static List<List<ProduccionExisEN>> ListarListasProduccionExiParaTransferenciaSincerado(string pClaveProduccionDeta)
        {
            //traer las producciones exis de este clave para transferir por devolucion de sincerado
            List<ProduccionExisEN> iLisProExi = ListarProduccionExisParaTransferirAProduccion("'" + pClaveProduccionDeta + "'");

            //devolver
            return ListaG.ListarListas<ProduccionExisEN>(iLisProExi, ProduccionExisEN.CodAlmOri);
        }

        public static void ModificarPorRegenerarDesmedro(List<ProduccionExisEN> pLista)
        {
            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLista)
            {
                if (xProExi.CEstadoDesmedro == "0")
                {
                    xProExi.CEstadoDesmedro = "1";
                }
            }
        }

        public static void ActualizarAlmacenCompraEnProduccionesExis()
        {
            //solo valid para el 2021
            //listar las producciones exis de periodo 2021-01
            List<ProduccionExisEN> iLisProExi = ListarProduccionExisParaRecalculoProducciones("2021", "05");

            //listar todas las formulas deta del sistema
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDetaParaExportar();

            //recorrer cada objeto de iLisProExi
            foreach (ProduccionExisEN xProExi in iLisProExi)
            {
                //buscar a la formula deta para este xProExi
                FormulaDetaEN iForDetEN = ListaG.Buscar<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExi, xProExi.CodigoExistencia);

                //actualizar el dato
                xProExi.CodigoAlmacenCompra = iForDetEN.CodigoAlmacenCompra;
            }

            //modificar en bd
            ModificarProduccionExis(iLisProExi);
        }

        public static List<ProduccionExisEN> ListarProduccionExisParaAgregarParteFaseEmpaquetado(string pClaveProduccionProTer,
            List<MovimientoDetaEN> pListaMovDetGrilla)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer a todos los items de ProduccionExis para este ProTer
            List<ProduccionExisEN> iLisProProTerFasEmp = ListarProduccionExisXClaveProduccionProTer(pClaveProduccionProTer);

            //traer a todos los movimientos deta que se hallan generado por partes fase empaquetado
            List<MovimientoDetaEN> iLisMovDetParEmp = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionProTerParteEmpaquetado(pClaveProduccionProTer);

            //a esta lista adicionamos la lista de la grilla
            iLisMovDetParEmp.AddRange(pListaMovDetGrilla);

            //sacar las producciones exis de codigo existencia que no estan en la lista movdet grilla
            iLisRes = ListaG.ListarAMenosB<ProduccionExisEN, MovimientoDetaEN>(iLisProProTerFasEmp, iLisMovDetParEmp, ProduccionExisEN.CodExi);

            //devolver
            return iLisRes;
        }

        public static void ModificarProduccionExis(ProduccionExisEN pObj, List<ProduccionExisEN> pLista)
        {
            //lista actualizada
            List<ProduccionExisEN> iLisProCab = new List<ProduccionExisEN>();

            //buscamos el objeto en la lista pLista
            foreach (ProduccionExisEN xProCab in pLista)
            {
                if (xProCab.ClaveProduccionExis == pObj.ClaveProduccionExis)
                {
                    xProCab.VerdadFalso = pObj.VerdadFalso;
                }
                iLisProCab.Add(xProCab);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisProCab);
        }

        public static List<ProduccionExisEN> ListarVentanaProduccionExisSoloMarcadas(List<ProduccionExisEN> pLista)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //la lista tiene objetos para agregar y otros no, por eso solo
            //hay que sacar los chequeados
            foreach (ProduccionExisEN xVenBot in pLista)
            {
                if (xVenBot.VerdadFalso == true)
                {
                    iLisRes.Add(xVenBot);
                }
            }
            return iLisRes;
        }

        public static void MarcarTodos(List<ProduccionExisEN> pLista, bool pPermitir)
        {
            //lista actualizada
            List<ProduccionExisEN> iLisProCab = new List<ProduccionExisEN>();

            //buscamos el objeto en la lista pLista
            foreach (ProduccionExisEN xProCab in pLista)
            {
                xProCab.VerdadFalso = pPermitir;
                iLisProCab.Add(xProCab);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisProCab);
        }

        public static List<ProduccionExisEN> ListarProduccionExisParaAgregarParteFaseEmpaquetado(string pClaveEncajado )
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer a todas las ProduccionesProTer de este encajado
            List<ProduccionProTerEN> iLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(pClaveEncajado);

            //creamos una lista de movimientoDeta vacia,este sirva como parametro para la funcion que se ejecuta dentro del foreach
            List<MovimientoDetaEN> iLisMovDetGri = new List<MovimientoDetaEN>();

            //recorrer cada objeto ProduccionProTer
            foreach (ProduccionProTerEN xProProTer in iLisProProTer)
            {
                //agregarmos a la lista resultado,las produccionesExis que falten sacar para encajar
                iLisRes.AddRange(ListarProduccionExisParaAgregarParteFaseEmpaquetado(xProProTer.ClaveProduccionProTer, iLisMovDetGri));
            }
            
            //devolver
            return iLisRes;
        }

        public static List<ProduccionExisEN> ListarProduccionExisXClaveProduccionProTerYSegundaLiberacion(ProduccionExisEN pObj)
        {
            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisXClaveProduccionProTerYSegundaLiberacion(pObj);
        }

        public static ProduccionExisEN ValidaCuandoItemsTienenCantidadEtiquetaCero(List<ProduccionExisEN> pLista)
        {
            //objeto resultado
            ProduccionExisEN iProExiEN = new ProduccionExisEN();

            //validar            
            List<ProduccionExisEN> iLisProExi = ListaG.Filtrar<ProduccionExisEN>(pLista, ProduccionExisEN.CanSegLib, "0.00000");
            if (iLisProExi.Count != 0)
            {
                iProExiEN.Adicionales.EsVerdad = false;
                iProExiEN.Adicionales.Mensaje = "Las cantidades etiquetas no pueden ser cero";
            }

            //devolver
            return iProExiEN;
        }

        public static void ModificarPorRegenerarSegundaLiberacion(List<ProduccionExisEN> pLista)
        {
            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in pLista)
            {
                if (xProExi.CEstadoSegundaLiberacion == "0")
                {
                    xProExi.CEstadoSegundaLiberacion = "1";
                }
            }
        }

        public static decimal ObtenerCostoTotalSegundaLiberacion(List<ProduccionExisEN> pLista)
        {
            //valor resultado
            decimal iValor = 0;

            //operar
            foreach (ProduccionExisEN xProExi in pLista)
            {
                iValor += xProExi.CantidadSegundaLiberacion * xProExi.PrecioUnitario;
            }

            //redondear
            iValor = Math.Round(iValor, 2);

            //devolver
            return iValor;
        }

        //public static List<ProduccionExisEN> ListarProduccionExisPorDesmedroEnvasado(string pClaveProduccionDeta)
        //{
        //    //lista resultado
        //    List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

        //    //traer a todas las produccionesExs de esta produccion solo fase envasado
        //    List<ProduccionExisEN> iLisProExiFasEnv = ListarProduccionExisXClaveProduccionDetaYFaseEnvasado(pClaveProduccionDeta);

        //    //traer a esta produccion
        //    ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pClaveProduccionDeta);

        //    //traer los movimientosDeta de esta producciones(representan los adicionales y devoluciones)
        //    List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pClaveProduccionDeta);

        //    //recorrer cada objeto
        //    foreach (ProduccionExisEN xProExi in iLisProExiFasEnv)
        //    {
        //        //variable que va a contener el cantidad que se desmedro
        //        decimal iDesmedro = 0;

        //        //calcular
        //        iDesmedro = xProExi.CantidadProduccionExis;//esta cantidad es la cantidad real que se uso en la produccion

        //        //filtrar los movimientos solo de esta existencia salidas
        //        List<MovimientoDetaEN> iLisMovDetExiAdi = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CodExi, xProExi.CodigoExistencia,
        //            MovimientoDetaEN.CClaTipOpe, "2");

        //        //obtener cantidades adicionales
        //        iDesmedro += ListaG.Sumar<MovimientoDetaEN>(iLisMovDetExiAdi, MovimientoDetaEN.CanMovDet);

        //        //filtrar los movimientos solo de esta existencia devoluciones
        //        List<MovimientoDetaEN> iLisMovDetExiDev = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CodExi, xProExi.CodigoExistencia,
        //            MovimientoDetaEN.CClaTipOpe, "1");

        //        //obtener cantidades adicionales
        //        iDesmedro -= ListaG.Sumar<MovimientoDetaEN>(iLisMovDetExiDev, MovimientoDetaEN.CanMovDet);

        //        //restamos las unidades reales producidas
        //        iDesmedro -= iProDetEN.CantidadRealProduccion;

        //        //pasamos al campo desmedro
        //        xProExi.CantidadDesmedro = iDesmedro;

        //        //si hay desmedro
        //        if (xProExi.CantidadDesmedro == 0)
        //        {
        //            xProExi.CEstadoDesmedro = "0";
        //            xProExi.DetalleMotivoDesmedro = string.Empty;
        //        }
        //        else
        //        {
        //            xProExi.CEstadoDesmedro = "1";
        //        }

        //        //agregamos a la lista resultado
        //        iLisRes.Add(xProExi);
        //    }            

        //    //devolver
        //    return iLisRes;
        //}

        //public static List<ProduccionExisEN> ListarProduccionExisPorDesmedroEnvasado(string pClaveProduccionDeta)
        //{
        //    //lista resultado
        //    List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

        //    //traer a todas las produccionesExs de esta produccion solo fase envasado
        //    List<ProduccionExisEN> iLisProExiFasEnv = ListarProduccionExisXClaveProduccionDetaYFaseEnvasado(pClaveProduccionDeta);

        //    //traer a esta produccion
        //    ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pClaveProduccionDeta);

        //    //traer los movimientosDeta de esta produccion(representan los adicionales y devoluciones)
        //    List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pClaveProduccionDeta);

        //    //traer a todas las formulasDetas de esta produccion (vienen todos.aunque solo sirven los de envasado)
        //    List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(iProDetEN);

        //    //recorrer cada objeto
        //    foreach (ProduccionExisEN xProExi in iLisProExiFasEnv)
        //    {
        //        //variable que va a contener la cantidad que se desmedro
        //        decimal iDesmedro = 0;

        //        //calcular
        //        //esta cantidad es la cantidad real que se uso en la produccion(sin incluir adicionales/devoluciones pero si sincerada)
        //        iDesmedro = xProExi.CantidadProduccionExis;

        //        //filtrar los movimientos solo de esta existencia salidas
        //        List<MovimientoDetaEN> iLisMovDetExiAdi = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CodExi, xProExi.CodigoExistencia,
        //            MovimientoDetaEN.CClaTipOpe, "2");

        //        //obtener cantidades adicionales
        //        iDesmedro += ListaG.Sumar<MovimientoDetaEN>(iLisMovDetExiAdi, MovimientoDetaEN.CanMovDet);

        //        //filtrar los movimientos solo de esta existencia devoluciones
        //        List<MovimientoDetaEN> iLisMovDetExiDev = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CodExi, xProExi.CodigoExistencia,
        //            MovimientoDetaEN.CClaTipOpe, "1");

        //        //obtener cantidades adicionales
        //        iDesmedro -= ListaG.Sumar<MovimientoDetaEN>(iLisMovDetExiDev, MovimientoDetaEN.CanMovDet);

        //        //restamos las unidades reales producidas(se multiplica por el factor de esta existencia en la formula)
        //        FormulaDetaEN iForDetExiEN = ListaG.Buscar<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExi, xProExi.CodigoExistencia);
        //        iDesmedro -= iProDetEN.CantidadRealProduccion * iForDetExiEN.CantidadFormulaDeta;

        //        //pasamos al campo desmedro
        //        xProExi.CantidadDesmedro = iDesmedro;

        //        //si hay desmedro
        //        if (xProExi.CantidadDesmedro <= 0)
        //        {
        //            xProExi.CEstadoDesmedro = "0";
        //            xProExi.DetalleMotivoDesmedro = string.Empty;
        //        }
        //        else
        //        {
        //            xProExi.CEstadoDesmedro = "1";
        //        }

        //        //agregamos a la lista resultado
        //        iLisRes.Add(xProExi);
        //    }

        //    //devolver
        //    return iLisRes;
        //}

        public static List<ProduccionExisEN> ListarProduccionExisPorDesmedroEnvasado(string pClaveProduccionDeta)
        {
            //lista resultado
            List<ProduccionExisEN> iLisRes = new List<ProduccionExisEN>();

            //traer a todas las produccionesExs de esta produccion solo fase envasado
            List<ProduccionExisEN> iLisProExiFasEnv = ListarProduccionExisXClaveProduccionDetaYFaseEnvasado(pClaveProduccionDeta);

            //traer a esta produccion
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pClaveProduccionDeta);

            //traer los movimientosDeta de esta produccion(representan los adicionales y devoluciones)
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveProduccionDeta(pClaveProduccionDeta);

            //traer a todas las formulasDetas de esta produccion (vienen todos.aunque solo sirven los de envasado)
            List<FormulaDetaEN> iLisForDet = FormulaDetaRN.ListarFormulasDeta(iProDetEN);

            //recorrer cada objeto
            foreach (ProduccionExisEN xProExi in iLisProExiFasEnv)
            {
                //variable que va a contener la cantidad que se desmedro
                decimal iDesmedro = 0;

                //calcular
                //esta cantidad es la cantidad real que se uso en la produccion(sin incluir adicionales/devoluciones pero si sincerada)
                iDesmedro = xProExi.CantidadProduccionExis;

                //filtrar los movimientos solo de esta existencia salidas
                List<MovimientoDetaEN> iLisMovDetExiAdi = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CodExi, xProExi.CodigoExistencia,
                    MovimientoDetaEN.CClaTipOpe, "2");

                //obtener cantidades adicionales
                iDesmedro += ListaG.Sumar<MovimientoDetaEN>(iLisMovDetExiAdi, MovimientoDetaEN.CanMovDet);

                //filtrar los movimientos solo de esta existencia devoluciones
                List<MovimientoDetaEN> iLisMovDetExiDev = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.CodExi, xProExi.CodigoExistencia,
                    MovimientoDetaEN.CClaTipOpe, "1");

                //obtener cantidades adicionales
                iDesmedro -= ListaG.Sumar<MovimientoDetaEN>(iLisMovDetExiDev, MovimientoDetaEN.CanMovDet);

                //restamos las unidades reales producidas(se multiplica por el factor de esta existencia en la formula)
                FormulaDetaEN iForDetExiEN = ListaG.Buscar<FormulaDetaEN>(iLisForDet, FormulaDetaEN.CodExi, xProExi.CodigoExistencia);
                iDesmedro -= iProDetEN.CantidadRealProduccion * iForDetExiEN.CantidadFormulaDeta;

                //pasamos al campo desmedro
                xProExi.CantidadDesmedro = iDesmedro;

                //si hay desmedro
                if (xProExi.CantidadDesmedro <= 0)
                {
                    xProExi.CEstadoDesmedro = "0";
                    xProExi.DetalleMotivoDesmedro = string.Empty;
                }
                else
                {
                    xProExi.CEstadoDesmedro = "1";
                }

                //agregamos a la lista resultado
                iLisRes.Add(xProExi);
            }

            //grabar en b.d
            ModificarProduccionExis(iLisRes);

            //devolver
            return iLisRes;
        }


        public static List<ProduccionExisEN> ListarProduccionExisXClaveProduccionDetaYFaseEnvasado(string pClaveProduccionDeta)
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pClaveProduccionDeta;
            iProExiEN.CTipoDescarga = "'1'";//fase envasado
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;

            ProduccionExisAD iProAD = new ProduccionExisAD();
            return iProAD.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(iProExiEN);
        }


    }
}
