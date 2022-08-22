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
    public class InventarioDetaRN
    {

        public static InventarioDetaEN EnBlanco()
        {
            InventarioDetaEN iPerEN = new InventarioDetaEN();
            return iPerEN;
        }

        public static void AdicionarInventarioDeta(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            iPerAD.AgregarInventarioDeta(pObj);
        }

        public static void AdicionarInventarioDeta(List<InventarioDetaEN> pLista)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            iPerAD.AgregarInventarioDeta(pLista);
        }

        public static void ModificarInventarioDeta(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            iPerAD.ModificarInventarioDeta(pObj);
        }

        public static void EliminarInventarioDeta(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            iPerAD.EliminarInventarioDeta(pObj);
        }

        public static void EliminarInventarioDetaXClaveInventarioCabe(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            iPerAD.EliminarInventarioDetaXClaveInventarioCabe(pObj);
        }

        public static List<InventarioDetaEN> ListarInventarioDetas(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ListarInventarioDetas(pObj);
        }

        public static InventarioDetaEN BuscarInventarioDetaXClave(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.BuscarInventarioDetaXClave(pObj);
        }

        public static InventarioDetaEN EsInventarioDetaExistente(InventarioDetaEN pObj)
        {
            //objeto resultado
            InventarioDetaEN iPerEN = new InventarioDetaEN();

            //validar si existe en b.d
            iPerEN = InventarioDetaRN.BuscarInventarioDetaXClave(pObj);
            if (iPerEN.ClaveInventarioDeta == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "La existencia " + pObj.CodigoExistencia + " no existe";
                return iPerEN;
            }

            //ok        
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(InventarioDetaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case InventarioDetaEN.ClaObj: return pObj.ClaveObjeto;
                case InventarioDetaEN.ClaInvDet: return pObj.ClaveInventarioDeta;
                case InventarioDetaEN.ClaInvCab: return pObj.ClaveInventarioCabe;
                case InventarioDetaEN.CodAlm: return pObj.CodigoAlmacen;
                case InventarioDetaEN.CodEmp: return pObj.CodigoEmpresa;
                case InventarioDetaEN.DesAlm: return pObj.DescripcionAlmacen;
                case InventarioDetaEN.CorInvCab: return pObj.CorrelativoInventarioCabe;
                case InventarioDetaEN.CodExi: return pObj.CodigoExistencia;
                case InventarioDetaEN.DesExi: return pObj.DescripcionExistencia;
                case InventarioDetaEN.CodUniMed: return pObj.CodigoUnidadMedida;
                case InventarioDetaEN.UbiExi: return pObj.UbicacionExistencia;
                case InventarioDetaEN.StoFis: return pObj.StockFisico.ToString();
                case InventarioDetaEN.StoTeo: return pObj.StockTeorico.ToString();
                case InventarioDetaEN.DifSto: return pObj.DiferenciaStock.ToString();
                case InventarioDetaEN.CEstInvDet: return pObj.CEstadoInventarioDeta;
                case InventarioDetaEN.NEstInvDet: return pObj.NEstadoInventarioDeta;
                case InventarioDetaEN.UsuAgr: return pObj.UsuarioAgrega;
                case InventarioDetaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case InventarioDetaEN.UsuMod: return pObj.UsuarioModifica;
                case InventarioDetaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<InventarioDetaEN> FiltrarInventarioDetasXTextoEnCualquierPosicion(List<InventarioDetaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<InventarioDetaEN> iLisRes = new List<InventarioDetaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (InventarioDetaEN xPer in pLista)
            {
                string iTexto = InventarioDetaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<InventarioDetaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<InventarioDetaEN> pListaInventarioDetas)
        {
            //lista resultado
            List<InventarioDetaEN> iLisRes = new List<InventarioDetaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaInventarioDetas; }

            //filtar la lista
            iLisRes = InventarioDetaRN.FiltrarInventarioDetasXTextoEnCualquierPosicion(pListaInventarioDetas, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveInventarioDeta(InventarioDetaEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += pPer.ClaveInventarioCabe + "-";
            iClave += pPer.CodigoExistencia;

            //retornar
            return iClave;
        }

        public static InventarioDetaEN EsActoModificarInventarioDeta(InventarioDetaEN pObj)
        {
            //objeto resultado
            InventarioDetaEN iAlmEN = new InventarioDetaEN();

            //validar si existe
            iAlmEN = InventarioDetaRN.EsInventarioDetaExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //ok            
            return iAlmEN;
        }
             
        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static List<InventarioDetaEN> ListarInventarioDetasXClaveInventarioCabe(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ListarInventarioDetasXClaveInventarioCabe(pObj);
        }

        public static InventarioDetaEN BuscarInventarioDeta(string pCampoBusqueda, string pValorBusqueda, List<InventarioDetaEN> pListaBusqueda)
        {
            //objeto resultado
            InventarioDetaEN iInvCabEN = new InventarioDetaEN();

            //recorrer cada objeto
            foreach (InventarioDetaEN xInvCab in pListaBusqueda)
            {
                if (InventarioDetaRN.ObtenerValorDeCampo(xInvCab, pCampoBusqueda) == pValorBusqueda)
                {
                    iInvCabEN = xInvCab;
                    return iInvCabEN;
                }
            }

            //devolver
            return iInvCabEN;
        }

        public static void AdicionarInventariosDetaParaInventarioCabe(InventarioCabeEN pObj)
        {
            //lista a grabar
            List<InventarioDetaEN> iLisInvDetAdi = new List<InventarioDetaEN>();

            //traer a todas las existencias del almacen elegido
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistenciasActivasDeAlmacen(pObj.CodigoAlmacen);

            //recorrer cada objeto existencia
            foreach (ExistenciaEN xExi in iLisExi)
            {
                //convertir esta existencia en InventarioDeta
                InventarioDetaEN iInvDetEN = InventarioDetaRN.ConvertirExistencia(xExi, pObj);

                //adicionamos a la lista a grabar
                iLisInvDetAdi.Add(iInvDetEN);
            }

            //adicion masiva
            InventarioDetaRN.AdicionarInventarioDeta(iLisInvDetAdi);
        }

        public static InventarioDetaEN ConvertirExistencia(ExistenciaEN pExi, InventarioCabeEN pInvCab)
        {
            //objeto resultado
            InventarioDetaEN iInvDetEN = new InventarioDetaEN();

            //pasamos datos
            iInvDetEN.ClaveInventarioCabe = pInvCab.ClaveInventarioCabe;
            iInvDetEN.CodigoExistencia = pExi.CodigoExistencia;
            iInvDetEN.ClaveInventarioDeta = InventarioDetaRN.ObtenerClaveInventarioDeta(iInvDetEN);
            iInvDetEN.CodigoEmpresa = pExi.CodigoEmpresa;
            iInvDetEN.CodigoAlmacen = pExi.CodigoAlmacen;
            iInvDetEN.CorrelativoInventarioCabe = pInvCab.CorrelativoInventarioCabe;
            iInvDetEN.StockTeorico = pExi.StockActualExistencia;
            iInvDetEN.DiferenciaStock = -iInvDetEN.StockTeorico;

            //devolver
            return iInvDetEN;
        }

        public static List<string> ListarItemsOrden()
        {
            //lista resultado
            List<string> iLisRes = new List<string>();

            //adicionar los items
            iLisRes.Add("Codigo");
            iLisRes.Add("Descripcion");
            iLisRes.Add("Unidad");
            iLisRes.Add("Ubicacion");

            //devolver
            return iLisRes;
        }

        public static string HomologarItemOrden(string pItemOrden)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun pItemOrden
            switch (pItemOrden)
            {
                case "Codigo": { iValor = InventarioDetaEN.CodExi; break; }
                case "Descripcion": { iValor = InventarioDetaEN.DesExi; break; }
                case "Unidad": { iValor = InventarioDetaEN.CodUniMed; break; }
                case "Ubicacion": { iValor = InventarioDetaEN.UbiExi; break; }
            }

            //devolver
            return iValor;
        }

        public static List<InventarioDetaEN> ListarInventarioDetasAStockFisicoCeroXClaveInventarioCabe(InventarioDetaEN pObj)
        {            
            //listar todos los InventariosDeta de ClaveInventarioCabe
            List<InventarioDetaEN> iLisInvDet = InventarioDetaRN.ListarInventarioDetasXClaveInventarioCabe(pObj);

            //recorrer cada objeto
            foreach (InventarioDetaEN xInvDet in iLisInvDet)
            {
                //ponemos a cero su stockfisico
                xInvDet.StockFisico = 0;
            }

            //devolver
            return iLisInvDet;
        }

        public static List<InventarioDetaEN> ListarInventarioDetasParaTomaInventario(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ListarInventarioDetasParaTomaInventario(pObj);
        }

        public static void ModificarStockFisicoInventarioDeta(InventarioDetaEN pObj)
        {
            //traer al objeto de la b.d
            InventarioDetaEN iInvDetEN = InventarioDetaRN.BuscarInventarioDetaXClave(pObj);

            //actualizamos el dato
            iInvDetEN.StockFisico = pObj.StockFisico;
            iInvDetEN.DiferenciaStock = iInvDetEN.StockFisico - iInvDetEN.StockTeorico;

            //modificar en b.d
            InventarioDetaRN.ModificarInventarioDeta(iInvDetEN);
        }

        public static List<InventarioDetaEN> ListarInventarioDetasParaDiferenciaStock(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ListarInventarioDetasParaDiferenciaStock(pObj);
        }

        public static List<InventarioDetaEN> ListarInventarioDetasParaAjusteIngreso(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ListarInventarioDetasParaAjusteIngreso(pObj);
        }

        public static List<InventarioDetaEN> ListarInventarioDetasParaAjusteSalida(InventarioDetaEN pObj)
        {
            InventarioDetaAD iPerAD = new InventarioDetaAD();
            return iPerAD.ListarInventarioDetasParaAjusteSalida(pObj);
        }

        public static List<InventarioDetaEN> ListarInventarioDetasParaAjusteIngreso(string pClaveInventarioCabe)
        {
            //asignar parametros
            InventarioDetaEN iInvDetEN = new InventarioDetaEN();
            iInvDetEN.ClaveInventarioCabe = pClaveInventarioCabe;
            iInvDetEN.Adicionales.CampoOrden = InventarioDetaEN.CodExi;

            //ejecutar metodo
            return InventarioDetaRN.ListarInventarioDetasParaAjusteIngreso(iInvDetEN);
        }

        public static List<InventarioDetaEN> ListarInventarioDetasParaAjusteSalida(string pClaveInventarioCabe)
        {
            //asignar parametros
            InventarioDetaEN iInvDetEN = new InventarioDetaEN();
            iInvDetEN.ClaveInventarioCabe = pClaveInventarioCabe;
            iInvDetEN.Adicionales.CampoOrden = InventarioDetaEN.CodExi;

            //ejecutar metodo
            return InventarioDetaRN.ListarInventarioDetasParaAjusteSalida(iInvDetEN);
        }

        public static string ObtenerClaveExistencia(InventarioDetaEN pObj)
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

       
    }
}
