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
    public class CentroCostoRN
    {

        public static CentroCostoEN EnBlanco()
        {
            CentroCostoEN iPerEN = new CentroCostoEN();
            return iPerEN;
        }

        public static void AdicionarCentroCosto(CentroCostoEN pObj)
        {
            CentroCostoAD iPerAD = new CentroCostoAD();
            iPerAD.AgregarCentroCosto(pObj);
        }

        public static void ModificarCentroCosto(CentroCostoEN pObj)
        {
            CentroCostoAD iPerAD = new CentroCostoAD();
            iPerAD.ModificarCentroCosto(pObj);
        }

        public static void EliminarCentroCosto(CentroCostoEN pObj)
        {
            CentroCostoAD iPerAD = new CentroCostoAD();
            iPerAD.EliminarCentroCosto(pObj);
        }

        public static List<CentroCostoEN> ListarCentroCostos(CentroCostoEN pObj)
        {
            CentroCostoAD iPerAD = new CentroCostoAD();
            return iPerAD.ListarCentroCostos(pObj);
        }

        public static CentroCostoEN BuscarCentroCostoXClave(CentroCostoEN pObj)
        {
            CentroCostoAD iPerAD = new CentroCostoAD();
            return iPerAD.BuscarCentroCostoXClave(pObj);
        }

        public static CentroCostoEN EsCentroCostoExistente(CentroCostoEN pObj)
        {
            //objeto resultado
            CentroCostoEN iPerEN = new CentroCostoEN();

            //validar si existe en b.d
            iPerEN = CentroCostoRN.BuscarCentroCostoXClave(pObj);
            if (iPerEN.ClaveCentroCosto == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Centro Costo " + pObj.CodigoCentroCosto  + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static CentroCostoEN EsCodigoCentroCostoDisponible(CentroCostoEN pObj)
        {
            //objeto resultado
            CentroCostoEN iPerEN = new CentroCostoEN();

            //valida cuando esta vacio
            if (pObj.CodigoCentroCosto == string.Empty) { return iPerEN; }

            //validar que los dos campos esten llenos
            iPerEN = CentroCostoRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok           
            return iPerEN;
        }

        public static CentroCostoEN ValidaCuandoCodigoYaExiste(CentroCostoEN pObj)
        {
            //objeto resultado
            CentroCostoEN iPerEN = new CentroCostoEN();

            //validar     
            iPerEN = CentroCostoRN.BuscarCentroCostoXClave(pObj);
            if (iPerEN.CodigoCentroCosto != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoCentroCosto + " ya existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(CentroCostoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CentroCostoEN.ClaObj: return pObj.ClaveObjeto;
                case CentroCostoEN.ClaCeCo: return pObj.ClaveCentroCosto;
                case CentroCostoEN.CodCeCo: return pObj.CodigoCentroCosto;
                case CentroCostoEN.CodEmp: return pObj.CodigoEmpresa;
                case CentroCostoEN.DesCeCo: return pObj.DescripcionCentroCosto;
                case CentroCostoEN.CEstCeCo: return pObj.CEstadoCentroCosto;
                case CentroCostoEN.NEstCeCo: return pObj.NEstadoCentroCosto;
                case CentroCostoEN.UsuAgr: return pObj.UsuarioAgrega;
                case CentroCostoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case CentroCostoEN.UsuMod: return pObj.UsuarioModifica;
                case CentroCostoEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<CentroCostoEN> FiltrarCentroCostosXTextoEnCualquierPosicion(List<CentroCostoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<CentroCostoEN> iLisRes = new List<CentroCostoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (CentroCostoEN xPer in pLista)
            {
                string iTexto = CentroCostoRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<CentroCostoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<CentroCostoEN> pListaCentroCostos)
        {
            //lista resultado
            List<CentroCostoEN> iLisRes = new List<CentroCostoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaCentroCostos; }

            //filtar la lista
            iLisRes = CentroCostoRN.FiltrarCentroCostosXTextoEnCualquierPosicion(pListaCentroCostos, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveCentroCosto(CentroCostoEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.CodigoCentroCosto ;
            
            //retornar
            return iClave;
        }

        public static CentroCostoEN EsCentroCostoValido(CentroCostoEN pObj)
        {
            //objeto resultado
            CentroCostoEN iAlmEN = new CentroCostoEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoCentroCosto == string.Empty) { return iAlmEN; }

            //valida cuando el codigo no existe
            iAlmEN = CentroCostoRN.EsCentroCostoExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }
            
            //ok           
            return iAlmEN;
        }

        public static CentroCostoEN EsActoModificarCentroCosto(CentroCostoEN pObj)
        {
            //objeto resultado
            CentroCostoEN iCenCosEN = new CentroCostoEN();

            //validar si existe
            iCenCosEN = CentroCostoRN.EsCentroCostoExistente(pObj);
            if (iCenCosEN.Adicionales.EsVerdad == false) { return iCenCosEN; }

            //ok            
            return iCenCosEN;
        }

        public static CentroCostoEN EsActoEliminarCentroCosto(CentroCostoEN pObj)
        {
            //objeto resultado
            CentroCostoEN iCenCosEN = new CentroCostoEN();

            //validar si existe
            iCenCosEN = CentroCostoRN.EsCentroCostoExistente(pObj);
            if (iCenCosEN.Adicionales.EsVerdad == false) { return iCenCosEN; }

            //valida si existe este CentroCosto en MovimientoDeta
            CentroCostoEN iCenCosExiEN = CentroCostoRN.ValidaCuandoCodigoCentroCostoEstaEnMovimientoDeta(iCenCosEN);
            if (iCenCosExiEN.Adicionales.EsVerdad == false) { return iCenCosExiEN; }

            //ok            
            return iCenCosEN;
        }

        public static CentroCostoEN ValidaCuandoCodigoCentroCostoEstaEnMovimientoDeta(CentroCostoEN pObj)
        {
            //objeto resultado
            CentroCostoEN iCenCosEN = new CentroCostoEN();

            //valida
            bool iExisten = MovimientoDetaRN.ExisteValorEnColumnaConEmpresa(MovimientoDetaEN.CodCenCos, pObj.CodigoCentroCosto);
            if (iExisten == true)
            {
                iCenCosEN.Adicionales.EsVerdad = false;
                iCenCosEN.Adicionales.Mensaje = "Este centro de costo tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
                return iCenCosEN;
            }

            //ok
            return iCenCosEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            CentroCostoAD iPerAD = new CentroCostoAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            CentroCostoAD iPerAD = new CentroCostoAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            CentroCostoAD iPerAD = new CentroCostoAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static CentroCostoEN BuscarCentroCostoXCodigo(string pCodigoCentroCosto)
        {
            //asignar parametro
            CentroCostoEN iCenCosEN = new CentroCostoEN();
            iCenCosEN.CodigoCentroCosto = pCodigoCentroCosto;
            iCenCosEN.ClaveCentroCosto = CentroCostoRN.ObtenerClaveCentroCosto(iCenCosEN);

            //ejecutar metodo
            return CentroCostoRN.BuscarCentroCostoXClave(iCenCosEN);
        }

        public static CentroCostoEN BuscarCentroCostoProduccion()
        {
            //objeto resultado
            CentroCostoEN iCenCosEN = new CentroCostoEN();

            //traer al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //buscar a al centro costo produccion
            iCenCosEN = CentroCostoRN.BuscarCentroCostoXCodigo(iParEN.CentroCostoProduccion);

            //devolver
            return iCenCosEN;
        }

    }
}
