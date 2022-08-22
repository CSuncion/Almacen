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
    public class AlmacenExistenciaRN
    {

        public static AlmacenExistenciaEN EnBlanco()
        {
            AlmacenExistenciaEN iPerEN = new AlmacenExistenciaEN();
            return iPerEN;
        }

        public static void AdicionarAlmacenExistencia(AlmacenExistenciaEN pObj)
        {
            AlmacenExistenciaAD iPerAD = new AlmacenExistenciaAD();
            iPerAD.AgregarAlmacenExistencia(pObj);
        }

        public static void ModificarAlmacenExistencia(AlmacenExistenciaEN pObj)
        {
            AlmacenExistenciaAD iPerAD = new AlmacenExistenciaAD();
            iPerAD.ModificarAlmacenExistencia(pObj);
        }

        public static void EliminarAlmacenExistencia(AlmacenExistenciaEN pObj)
        {
            AlmacenExistenciaAD iPerAD = new AlmacenExistenciaAD();
            iPerAD.EliminarAlmacenExistencia(pObj);
        }

        public static List<AlmacenExistenciaEN> ListarAlmacenExistencias(AlmacenExistenciaEN pObj)
        {
            AlmacenExistenciaAD iPerAD = new AlmacenExistenciaAD();
            return iPerAD.ListarAlmacenExistencias(pObj);
        }

        public static AlmacenExistenciaEN BuscarAlmacenExistenciaXClave(AlmacenExistenciaEN pObj)
        {
            AlmacenExistenciaAD iPerAD = new AlmacenExistenciaAD();
            return iPerAD.BuscarAlmacenExistenciaXClave(pObj);
        }

        public static AlmacenExistenciaEN EsAlmacenExistenciaExistente(AlmacenExistenciaEN pObj)
        {
            //objeto resultado
            AlmacenExistenciaEN iPerEN = new AlmacenExistenciaEN();

            //validar si existe en b.d
            iPerEN = AlmacenExistenciaRN.BuscarAlmacenExistenciaXClave(pObj);
            if (iPerEN.ClaveAlmacenExistencia == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Almacen Existencia " + pObj.CodigoExistencia + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(AlmacenExistenciaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case AlmacenExistenciaEN.ClaObj: return pObj.ClaveObjeto;
                case AlmacenExistenciaEN.ClaAlmExi: return pObj.ClaveAlmacenExistencia;
                case AlmacenExistenciaEN.CodAlm: return pObj.CodigoAlmacen;
                case AlmacenExistenciaEN.CodEmp: return pObj.CodigoEmpresa;
                case AlmacenExistenciaEN.DesAlm: return pObj.DescripcionAlmacen;
                case AlmacenExistenciaEN.CodExi: return pObj.CodigoExistencia;
                case AlmacenExistenciaEN.DesExi: return pObj.DescripcionExistencia;
                case AlmacenExistenciaEN.StoTomAlmExi: return pObj.StockTomaAlmacenExistencia.ToString();
                case AlmacenExistenciaEN.StoIniAlmExi: return pObj.StockInicialAlmacenExistencia.ToString();
                case AlmacenExistenciaEN.StoActAlmExi: return pObj.StockActualAlmacenExistencia.ToString();
                case AlmacenExistenciaEN.PreIniAlmExi: return pObj.PrecioInicialAlmacenExistencia.ToString();
                case AlmacenExistenciaEN.PreProAlmExi: return pObj.PrecioPromedioAlmacenExistencia.ToString();
                case AlmacenExistenciaEN.UsuAgr: return pObj.UsuarioAgrega;
                case AlmacenExistenciaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case AlmacenExistenciaEN.UsuMod: return pObj.UsuarioModifica;
                case AlmacenExistenciaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<AlmacenExistenciaEN> FiltrarAlmacensXTextoEnCualquierPosicion(List<AlmacenExistenciaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<AlmacenExistenciaEN> iLisRes = new List<AlmacenExistenciaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (AlmacenExistenciaEN xPer in pLista)
            {
                string iTexto = AlmacenExistenciaRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<AlmacenExistenciaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<AlmacenExistenciaEN> pListaAlmacens)
        {
            //lista resultado
            List<AlmacenExistenciaEN> iLisRes = new List<AlmacenExistenciaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaAlmacens; }

            //filtar la lista
            iLisRes = AlmacenExistenciaRN.FiltrarAlmacensXTextoEnCualquierPosicion(pListaAlmacens, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveAlmacenExistencia(AlmacenExistenciaEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.CodigoAlmacen + "-";
            iClave += pPer.CodigoExistencia;

            //retornar
            return iClave;
        }



    }
}
