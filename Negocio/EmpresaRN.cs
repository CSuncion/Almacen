using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;
using Entidades.Adicionales;

namespace Negocio
{
    public class EmpresaRN
    {
        public static EmpresaEN EnBlanco()
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            return iEmpEN;
        }
        
        public static void AdicionarEmpresa(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            iEmpAD.AgregarEmpresa(pObj);
        }
        
        public static void ModificarEmpresa(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            iEmpAD.ModificarEmpresa(pObj);
        }
        
        public static void EliminarEmpresa(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            iEmpAD.EliminarEmpresa(pObj);
        }
        
        public static EmpresaEN BuscarEmpresaXCodigo(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            return iEmpAD.BuscarEmpresaXCodigo(pObj);
        }

        public static EmpresaEN BuscarEmpresaXCodigo(string pCodigoEmpresa)
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = pCodigoEmpresa;
            return EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);
        }

        public static List<EmpresaEN> ListarEmpresas(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            return iEmpAD.ListarEmpresas(pObj);
        }
        
        public static EmpresaEN EsEmpresaExistente(EmpresaEN pObj)
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(pObj);
            if (iEmpEN.CodigoEmpresa == string.Empty)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "La Empresa " + pObj.CodigoEmpresa + " : " + pObj.NombreEmpresa + " no existe";
            }
            else
            {
                iEmpEN.Adicionales.EsVerdad = true;
            }
            return iEmpEN;
        }
        
        public static EmpresaEN EsCodigoEmpresaDisponible(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //validar solo cuando hay codigo editado
            if (pObj.CodigoEmpresa != string.Empty)
            {
                //buscar en b.d si hay una empresa con este codigo
                iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(pObj);

                //validar si ya esta registrado este codigo
                if (iEmpEN.CodigoEmpresa != string.Empty)
                {
                    iEmpEN.Adicionales.EsVerdad = false;
                    iEmpEN.Adicionales.Mensaje = "El codigo " + iEmpEN.CodigoEmpresa + " ya le pertenece a otra Empresa";
                    return iEmpEN;
                }
            }
           
            //ok
            iEmpEN.Adicionales.EsVerdad = true;
            return iEmpEN;
        }

        public  static EmpresaEN EsEmpresaValido(EmpresaEN pObj)
        {
            EmpresaEN iEmpEN = new EmpresaEN();

            //si el codigo esta vacio pasa true
            if (pObj.CodigoEmpresa == string.Empty)
            {
                iEmpEN.Adicionales.EsVerdad = true;
                iEmpEN.Adicionales.Mensaje = "";
                return iEmpEN;
            }

            //si Codigo no esta vacio
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(pObj);
            if (iEmpEN.CodigoEmpresa == string.Empty)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "La empresa" + Cadena.Espacios(1) + pObj.CodigoEmpresa + Cadena.Espacios(1) + "no existe";
                return iEmpEN;
            }
            //ok
            iEmpEN.Adicionales.EsVerdad = true;
            return iEmpEN;
        }

        public static List<EmpresaEN> ListarEmpresasExceptoLaActual(EmpresaEN pObj)
        {
            EmpresaAD iEmpAD = new EmpresaAD();
            return iEmpAD.ListarEmpresasExceptoLaActual(pObj);
        }

        public static EmpresaEN EsActoEliminarEmpresa(EmpresaEN pObj)
        {
            //objeto de retorno
            EmpresaEN iEmpEN = new EmpresaEN();

            //validar si la empresa existe
            iEmpEN = EmpresaRN.EsEmpresaExistente(pObj);
            if (iEmpEN.Adicionales.EsVerdad == false) { return iEmpEN; }

            //validar cuando se quiere eliminar a la empresa de acceso
            EmpresaEN iEmpAccEN = EmpresaRN.ValidaCuandoEliminaEmpresaAcceso(iEmpEN);
            if (iEmpAccEN.Adicionales.EsVerdad == false) { return iEmpAccEN; }

            //valida si existe este empresa en centro de costo
            EmpresaEN iEmpCenCosExiEN = EmpresaRN.ValidaCuandoCodigoEmpresaEstaEnCentroCosto(iEmpEN);
            if (iEmpCenCosExiEN.Adicionales.EsVerdad == false) { return iEmpCenCosExiEN; }

            //valida si existe esta empresa en almacen
            EmpresaEN iEmpAlmExiEN = EmpresaRN.ValidaCuandoCodigoEmpresaEstaEnAlmacen(iEmpEN);
            if (iEmpAlmExiEN.Adicionales.EsVerdad == false) { return iEmpAlmExiEN; }

            //valida si existe esta empresa en auxiliar
            EmpresaEN iEmpAuxExiEN = EmpresaRN.ValidaCuandoCodigoEmpresaEstaEnAuxiliar(iEmpEN);
            if (iEmpAuxExiEN.Adicionales.EsVerdad == false) { return iEmpAuxExiEN; }

            //valida si existe esta empresa en personal
            EmpresaEN iEmpPerExiEN = EmpresaRN.ValidaCuandoCodigoEmpresaEstaEnPersonal(iEmpEN);
            if (iEmpPerExiEN.Adicionales.EsVerdad == false) { return iEmpPerExiEN; }

            //valida si existe esta empresa en periodo
            EmpresaEN iEmpPeriExiEN = EmpresaRN.ValidaCuandoCodigoEmpresaEstaEnPeriodo(iEmpEN);
            if (iEmpPeriExiEN.Adicionales.EsVerdad == false) { return iEmpPeriExiEN; }

            //ok            
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoEliminaEmpresaAcceso(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida
            if (pObj.CodigoEmpresa == Universal.gCodigoEmpresa)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "No se puede eliminar la empresa de acceso";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoCodigoEmpresaEstaEnCentroCosto(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida
            bool iExisten = ItemERN.ExisteValorEnColumnaSinEmpresa(ItemEEN.CodEmp, pObj.CodigoEmpresa);
            if (iExisten == true)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Hay centros de costos generados en esta empresa, no se puede realizar la operacion";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoCodigoEmpresaEstaEnAlmacen(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida
            bool iExisten = AlmacenRN.ExisteValorEnColumnaSinEmpresa(AlmacenEN.CodEmp, pObj.CodigoEmpresa);
            if (iExisten == true)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Hay almacenes generados en esta empresa, no se puede realizar la operacion";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoCodigoEmpresaEstaEnAuxiliar(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida
            bool iExisten = AuxiliarRN.ExisteValorEnColumnaSinEmpresa(AuxiliarEN.CodEmp, pObj.CodigoEmpresa);
            if (iExisten == true)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Hay auxiliares generados en esta empresa, no se puede realizar la operacion";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoCodigoEmpresaEstaEnPersonal(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida
            bool iExisten = PersonalRN.ExisteValorEnColumnaSinEmpresa(Entidades.PersonalEN.CodEmp, pObj.CodigoEmpresa);
            if (iExisten == true)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Hay personales generados en esta empresa, no se puede realizar la operacion";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static EmpresaEN ValidaCuandoCodigoEmpresaEstaEnPeriodo(EmpresaEN pObj)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //valida
            bool iExisten = PeriodoRN.ExisteValorEnColumnaSinEmpresa(PeriodoEN.CodEmp, pObj.CodigoEmpresa);
            if (iExisten == true)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "Hay periodos generados en esta empresa, no se puede realizar la operacion";
                return iEmpEN;
            }

            //ok
            return iEmpEN;
        }

        public static void ModificarCampoParametro(string pCampo, string pValor,string pCodigoEmpresa)
        {
            //traer al objeto Empresa
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = pCodigoEmpresa;
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);

            //modificar solo el campo que biene como parametro
            //desde la ventana
            switch (pCampo)
            {
                case EmpresaEN.ConCuoOrd: { iEmpEN.ConceptoCuotaOrdinaria = pValor; break; }
                case EmpresaEN.PorMor: { iEmpEN.PorcentajeMora =Convert.ToDecimal( pValor); break; }
                case EmpresaEN.LogEmp: { iEmpEN.LogoEmpresa = pValor; break; }
                case EmpresaEN.ConCuoLuz: { iEmpEN.ConceptoCuotaLuz = pValor; break; }
                case EmpresaEN.ConCuoAgu: { iEmpEN.ConceptoCuotaAgua = pValor; break; }
                case EmpresaEN.ConCuoMor: { iEmpEN.ConceptoCuotaMora = pValor; break; }
            }

            //modificar su valor
            EmpresaRN.ModificarEmpresa(iEmpEN);
        }

        public static EmpresaEN EsNumeroDocumentoAutogeneradoCorrecto(EmpresaEN pEmp)
        { 
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //traemos a la empresa
            pEmp = EmpresaRN.BuscarEmpresaXCodigo(pEmp);

            //obtener el numero documento actual
            string iNumeroDocumento = pEmp.NumeroDocumento;

            //le sumamos uno
            iNumeroDocumento = Numero.IncrementarCorrelativoNumerico(iNumeroDocumento, 7);

            //si este numero sobrepaso los 7 digitos
            if (iNumeroDocumento.Length > 7)
            {
                iEmpEN.Adicionales.EsVerdad = false;
                iEmpEN.Adicionales.Mensaje = "El numero no puede sobrepasar a: 9999999, No se puede realizar la operacion";
            }
            else
            {
                //aqui  el numero si es correcto entonces modificamos a la empresa
                pEmp.NumeroDocumento = iNumeroDocumento;
                EmpresaRN.ModificarEmpresa(pEmp);

                //pasamos el nuevo numero
                iEmpEN.NumeroDocumento = iNumeroDocumento;
                iEmpEN.Adicionales.EsVerdad = true;
            }
            return iEmpEN;
        }

        public static string ObtenerValorDeCampo(EmpresaEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case EmpresaEN.ClaObj: return pObj.ClaveObjeto;
                case EmpresaEN.CodEmp: return pObj.CodigoEmpresa;
                case EmpresaEN.NomEmp: return pObj.NombreEmpresa;
                case EmpresaEN.DirEmp: return pObj.DireccionEmpresa;
                case EmpresaEN.RucEmp: return pObj.RucEmpresa;
                case EmpresaEN.TelFijEmp: return pObj.TelFijoEmpresa;
                case EmpresaEN.TelCelEmp: return pObj.TelCelularEmpresa;
                case EmpresaEN.CorEmp: return pObj.CorreoEmpresa;
                case EmpresaEN.NEstEmp: return pObj.NEstadoEmpresa;
                case EmpresaEN.UsuAgr: return pObj.UsuarioAgrega;
                case EmpresaEN.FecAgr: return pObj.FechaAgrega.ToString();
                case EmpresaEN.UsuMod: return pObj.UsuarioModifica;
                case EmpresaEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<EmpresaEN> FiltrarEmpresasXTextoEnCualquierPosicion(List<EmpresaEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<EmpresaEN> iLisRes = new List<EmpresaEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (EmpresaEN xEmp in pLista)
            {
                string iTexto = EmpresaRN.ObtenerValorDeCampo(xEmp, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xEmp);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<EmpresaEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<EmpresaEN> pListaEmpresas)
        {
            //lista resultado
            List<EmpresaEN> iLisRes = new List<EmpresaEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaEmpresas; }

            //filtar la lista
            iLisRes = EmpresaRN.FiltrarEmpresasXTextoEnCualquierPosicion(pListaEmpresas, pCampoBusqueda, pValorBusqueda);
        
            //retornar
            return iLisRes;
        }

        public static EmpresaEN BuscarEmpresaXCodigo(EmpresaEN pObj, List<EmpresaEN> pLista)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //recorrer cada objeto
            foreach (EmpresaEN xEmp in pLista)
            {
                if (xEmp.CodigoEmpresa == pObj.CodigoEmpresa)
                {
                    iEmpEN = xEmp;
                    return iEmpEN;
                }
            }

            //devolver no encontrado
            return iEmpEN;
        }

        public static EmpresaEN EsActoModificarEmpresa(EmpresaEN pEmp)
        {
            //objeto resultado
            EmpresaEN iEmpEN = new EmpresaEN();

            //validar si existe
            iEmpEN = EmpresaRN.EsEmpresaExistente(pEmp);
            if (iEmpEN.Adicionales.EsVerdad == false) { return iEmpEN; }

            //validar que no se pueda desactivar la empresa de acceso
            if (pEmp.CEstadoEmpresa == "0")//desactivada
            {
                if (iEmpEN.CodigoEmpresa == Universal.gCodigoEmpresa)
                {
                    iEmpEN.Adicionales.EsVerdad = false;
                    iEmpEN.Adicionales.Mensaje = "No se puede desactivar la empresa de acceso";
                    return iEmpEN;
                }
            }

            //ok
            iEmpEN.Adicionales.EsVerdad = true;
            return iEmpEN;
        }

        public static EmpresaEN BuscarEmpresaDeAcceso()
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            return EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);
        }

        public static string ObtenerRucEmpresaDeAcceso()
        {
            //traer a la empresa de acceso
            EmpresaEN iEmpEN = EmpresaRN.BuscarEmpresaDeAcceso();

            //devolver
            return iEmpEN.RucEmpresa;
        }


    }
}
