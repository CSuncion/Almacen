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
    public class LicitacionRN
    {

        public static LicitacionEN EnBlanco()
        {
            LicitacionEN iPerEN = new LicitacionEN();
            return iPerEN;
        }

        public static void AdicionarLicitacion(LicitacionEN pObj)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            iPerAD.AgregarLicitacion(pObj);
        }

        public static void ModificarLicitacion(LicitacionEN pObj)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            iPerAD.ModificarLicitacion(pObj);
        }

        public static void EliminarLicitacion(LicitacionEN pObj)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            iPerAD.EliminarLicitacion(pObj);
        }

        public static List<LicitacionEN> ListarLicitaciones(LicitacionEN pObj)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            return iPerAD.ListarLicitaciones(pObj);
        }

        public static LicitacionEN BuscarLicitacionXClave(LicitacionEN pObj)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            return iPerAD.BuscarLicitacionXClave(pObj);
        }

        public static LicitacionEN EsLicitacionExistente(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iPerEN = new LicitacionEN();

            //validar si existe en b.d
            iPerEN = LicitacionRN.BuscarLicitacionXClave(pObj);
            if (iPerEN.ClaveLicitacion == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El Licitacion " + pObj.CodigoLicitacion + " no existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static LicitacionEN EsCodigoLicitacionDisponible(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iPerEN = new LicitacionEN();

            //valida cuando esta vacio
            if (pObj.CodigoLicitacion == string.Empty) { return iPerEN; }

            //validar que los dos campos esten llenos
            iPerEN = LicitacionRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok           
            return iPerEN;
        }

        public static LicitacionEN ValidaCuandoCodigoYaExiste(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iPerEN = new LicitacionEN();

            //validar     
            iPerEN = LicitacionRN.BuscarLicitacionXClave(pObj);
            if (iPerEN.CodigoLicitacion != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoLicitacion + " ya existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }

        public static string ObtenerValorDeCampo(LicitacionEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case LicitacionEN.ClaObj: return pObj.ClaveObjeto;
                case LicitacionEN.ClaLic: return pObj.ClaveLicitacion;
                case LicitacionEN.CodEmp: return pObj.CodigoEmpresa;
                case LicitacionEN.NomEmp: return pObj.NombreEmpresa;
                case LicitacionEN.CodAux: return pObj.CodigoAuxiliar;                
                case LicitacionEN.DesAux: return pObj.DescripcionAuxiliar;
                case LicitacionEN.CodLic: return pObj.CodigoLicitacion;
                case LicitacionEN.DesLic: return pObj.DescripcionLicitacion;
                case LicitacionEN.FecLic: return pObj.FechaLicitacion;
                case LicitacionEN.PerLic: return pObj.PeriodoLicitacion;
                case LicitacionEN.CEstLic: return pObj.CEstadoLicitacion;
                case LicitacionEN.NEstLic: return pObj.NEstadoLicitacion;
                case LicitacionEN.UsuAgr: return pObj.UsuarioAgrega;
                case LicitacionEN.FecAgr: return pObj.FechaAgrega.ToString();
                case LicitacionEN.UsuMod: return pObj.UsuarioModifica;
                case LicitacionEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<LicitacionEN> FiltrarLicitacionsXTextoEnCualquierPosicion(List<LicitacionEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<LicitacionEN> iLisRes = new List<LicitacionEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (LicitacionEN xPer in pLista)
            {
                string iTexto = LicitacionRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<LicitacionEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<LicitacionEN> pListaLicitacions)
        {
            //lista resultado
            List<LicitacionEN> iLisRes = new List<LicitacionEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaLicitacions; }

            //filtar la lista
            iLisRes = LicitacionRN.FiltrarLicitacionsXTextoEnCualquierPosicion(pListaLicitacions, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveLicitacion(LicitacionEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.CodigoAuxiliar + "-";
            iClave += pPer.CodigoLicitacion;

            //retornar
            return iClave;
        }

        public static LicitacionEN EsLicitacionValido(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iLicEN = new LicitacionEN();

            //valida cuando el codigo cliente esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iLicEN; }

            //valida cuando el codigo esta vacio
            if (pObj.CodigoLicitacion == string.Empty) { return iLicEN; }

            //valida cuando el codigo no existe
            iLicEN = LicitacionRN.EsLicitacionExistente(pObj);
            if (iLicEN.Adicionales.EsVerdad == false) { return iLicEN; }

            //ok           
            return iLicEN;
        }

        public static LicitacionEN EsActoModificarLicitacion(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iAlmEN = new LicitacionEN();

            //validar si existe
            iAlmEN = LicitacionRN.EsLicitacionExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            //ok            
            return iAlmEN;
        }

        public static LicitacionEN EsActoEliminarLicitacion(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iAlmEN = new LicitacionEN();

            //validar si existe
            iAlmEN = LicitacionRN.EsLicitacionExistente(pObj);
            if (iAlmEN.Adicionales.EsVerdad == false) { return iAlmEN; }

            ////valida si existe este Licitacion en existencia
            //LicitacionEN iAlmExiEN = LicitacionRN.ValidaCuandoCodigoLicitacionEstaEnExistencia(iAlmEN);
            //if (iAlmExiEN.Adicionales.EsVerdad == false) { return iAlmExiEN; }

            //ok            
            return iAlmEN;
        }

        public static LicitacionEN ValidaCuandoCodigoLicitacionEstaEnExistencia(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iAlmEN = new LicitacionEN();

            //valida
            bool iExisten = ExistenciaRN.ExisteValorEnColumnaConEmpresa(ExistenciaEN.CodAlm, pObj.CodigoLicitacion);
            if (iExisten == true)
            {
                iAlmEN.Adicionales.EsVerdad = false;
                iAlmEN.Adicionales.Mensaje = "Este Licitacion tiene existencias registradas, no se puede realizar la operacion";
                return iAlmEN;
            }

            //ok
            return iAlmEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static List<LicitacionEN> ListarLicitacionesXEstado(LicitacionEN pObj)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            return iPerAD.ListarLicitacionesXEstado(pObj);
        }

        public static List<LicitacionEN> ListarLicitacionesActivasDeCliente(LicitacionEN pObj)
        {
            LicitacionAD iPerAD = new LicitacionAD();
            return iPerAD.ListarLicitacionesActivasDeCliente(pObj);
        }

        public static LicitacionEN EsLicitacionActivaValido(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iLicEN = new LicitacionEN();

            //valida cuando el codigo cliente esta vacio
            if (pObj.CodigoAuxiliar == string.Empty) { return iLicEN; }

            //valida cuando el codigo esta vacio
            if (pObj.CodigoLicitacion == string.Empty) { return iLicEN; }

            //valida cuando el codigo no existe
            iLicEN = LicitacionRN.EsLicitacionExistente(pObj);
            if (iLicEN.Adicionales.EsVerdad == false) { return iLicEN; }

            //valida cuando esta desactivada
            LicitacionEN iLicDesEN = LicitacionRN.ValidaCuandoEstaDesactivada(iLicEN);
            if (iLicDesEN.Adicionales.EsVerdad == false) { return iLicDesEN; }

            //ok           
            return iLicEN;
        }

        public static LicitacionEN ValidaCuandoEstaDesactivada(LicitacionEN pObj)
        {
            //objeto resultado
            LicitacionEN iLicEN = new LicitacionEN();

            //valida            
            if (pObj.CEstadoLicitacion == "0")//desactivada
            {
                iLicEN.Adicionales.EsVerdad = false;
                iLicEN.Adicionales.Mensaje = "Este Licitacion esta desactivada, no se puede realizar la operacion";
                return iLicEN;
            }

            //ok
            return iLicEN;
        }

        public static List<LiberacionEN> ListarLiberacionParaEmpaquetar()
        {
            LiberacionAD iObjAD = new LiberacionAD();
            return iObjAD.ListarLiberacionParaEmpaquetar();
        }

        public static void DescontarUnidadesPorEmpaquetado(List<MovimientoDetaEN> pLisMovDet)
        {
            //listar a todas las liberaciones que se pueden empaquetar
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionParaEmpaquetar();

            //lista de Liberaciones a modificar
            List<LiberacionEN> iLisLibMod = new List<LiberacionEN>();

            //recorrer cada objeto MovimientoDeta
            foreach (MovimientoDetaEN xMovDet in pLisMovDet)
            {
                //listar solo Liberaciones de la existencia del xMovDet
                List<LiberacionEN> iLisLibExi = ListaG.Filtrar<LiberacionEN>(iLisLib, LiberacionEN.CodSemPro, xMovDet.CodigoExistencia);

                //cantidad a salir
                decimal iCantidadASalir = xMovDet.CantidadMovimientoDeta;

                //recorrer cada liberacion
                foreach (LiberacionEN xLib in iLisLibExi)
                {
                    //si la cantidad a salir es cero, entonces salir del foreach
                    if (iCantidadASalir == 0) { break; }

                    //si la cantidad a salir es menor,entonces termina la salida de los lotes
                    if (iCantidadASalir < xLib.SaldoUnidadesAEmpacar)
                    {
                        //actualizamos el lote
                        xLib.SaldoUnidadesAEmpacar -= iCantidadASalir;

                        //ya no hay cantidad a salir
                        iCantidadASalir = 0;
                    }
                    else
                    {
                        //restamos
                        iCantidadASalir -= xLib.SaldoUnidadesAEmpacar;

                        //actualizamos el lote
                        xLib.SaldoUnidadesAEmpacar = 0;
                    }

                    //adicionar a las listas                  
                    iLisLibMod.Add(xLib);
                }
            }

            //actualizar masivo
            LiberacionRN.ModificarLiberacion(iLisLibMod);
        }



    }
}
