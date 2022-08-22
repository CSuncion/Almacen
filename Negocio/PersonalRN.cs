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
    public class PersonalRN
    {

        public static PersonalEN EnBlanco()
        {
            PersonalEN iPerEN = new PersonalEN();
            return iPerEN;
        }

        public static void AdicionarPersonal(PersonalEN pObj)
        {
            PersonalAD iPerAD = new PersonalAD();
            iPerAD.AgregarPersonal(pObj);
        }

        public static void ModificarPersonal(PersonalEN pObj)
        {
            PersonalAD iPerAD = new PersonalAD();
            iPerAD.ModificarPersonal(pObj);
        }

        public static void EliminarPersonal(PersonalEN pObj)
        {
            PersonalAD iPerAD = new PersonalAD();
            iPerAD.EliminarPersonal(pObj);
        }

        public static List<PersonalEN> ListarPersonales(PersonalEN pObj)
        {
            PersonalAD iPerAD = new PersonalAD();
            return iPerAD.ListarPersonales(pObj);
        }

        public static PersonalEN BuscarPersonalXClave(PersonalEN pObj)
        {
            PersonalAD iPerAD = new PersonalAD();
            return iPerAD.BuscarPersonalXClave(pObj);
        }

        public static PersonalEN EsPersonalExistente(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //validar
            pObj.ClavePersonal = PersonalRN.ObtenerClavePersonal(pObj);
            iPerEN = PersonalRN.BuscarPersonalXClave(pObj);
            if (iPerEN.CodigoPersonal == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El personal " + pObj.CodigoPersonal + " no existe";
                return iPerEN;
            }

            //ok         
            return iPerEN;
        }

        public static PersonalEN EsCodigoPersonalDisponible(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonal == string.Empty) { return iPerEN; }

            //valida cuando existe el codigo
            iPerEN = PersonalRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok          
            return iPerEN;
        }

        public static PersonalEN ValidaCuandoCodigoYaExiste(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //validar    
            pObj.ClavePersonal = PersonalRN.ObtenerClavePersonal(pObj);
            iPerEN = PersonalRN.BuscarPersonalXClave(pObj);
            if (iPerEN.CodigoPersonal != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoPersonal + " ya existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }
        
        public static string ObtenerValorDeCampo(PersonalEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case PersonalEN.ClaObj: return pObj.ClaveObjeto;
                case PersonalEN.ClaPer: return pObj.ClavePersonal;
                case PersonalEN.CodEmp: return pObj.CodigoEmpresa;
                case PersonalEN.NomEmp: return pObj.NombreEmpresa;
                case PersonalEN.CodPer: return pObj.CodigoPersonal;
                case PersonalEN.NomPer: return pObj.NombrePersonal;
                case PersonalEN.CEstPer: return pObj.CEstadoPersonal;
                case PersonalEN.NEstPer: return pObj.NEstadoPersonal;
                case PersonalEN.UsuAgr: return pObj.UsuarioAgrega;
                case PersonalEN.FecAgr: return pObj.FechaAgrega.ToString();
                case PersonalEN.UsuMod: return pObj.UsuarioModifica;
                case PersonalEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<PersonalEN> FiltrarPersonalesXTextoEnCualquierPosicion(List<PersonalEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<PersonalEN> iLisRes = new List<PersonalEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (PersonalEN xPer in pLista)
            {
                string iTexto = PersonalRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<PersonalEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<PersonalEN> pListaPersonales)
        {
            //lista resultado
            List<PersonalEN> iLisRes = new List<PersonalEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaPersonales; }

            //filtar la lista
            iLisRes = PersonalRN.FiltrarPersonalesXTextoEnCualquierPosicion(pListaPersonales, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static PersonalEN EsPersonalValido(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonal == string.Empty) { return iPerEN; }

            //valida cuando el codigo no existe
            iPerEN = PersonalRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok
            return iPerEN;
        }

        public static PersonalEN EsActoModificarPersonal(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //validar si existe
            iPerEN = PersonalRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }

        public static PersonalEN EsActoEliminarPersonal(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //validar si existe
            iPerEN = PersonalRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe este Personal en MovimientoCabe
            PersonalEN iPerExiEN = PersonalRN.ValidaCuandoCodigoPersonalEstaEnMovimientoCabe(iPerEN);
            if (iPerExiEN.Adicionales.EsVerdad == false) { return iPerExiEN; }

            //ok            
            return iPerEN;
        }

        public static PersonalEN ValidaCuandoCodigoPersonalEstaEnMovimientoCabe(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //valida
            bool iExisten = MovimientoCabeRN.ExisteValorEnColumnaConEmpresa(MovimientoCabeEN.CodPer, pObj.CodigoPersonal);
            if (iExisten == true)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Este personal tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            return iPerEN;
        }

        public static string ObtenerClavePersonal(PersonalEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoPersonal;

            //retornar
            return iClave;
        }

        public static List<PersonalEN> ListarPersonalesActivos(PersonalEN pObj)
        {
            PersonalAD iPerAD = new PersonalAD();
            return iPerAD.ListarPersonalesActivos(pObj);
        }

        public static PersonalEN EsPersonalActivoValido(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonal == string.Empty) { return iPerEN; }

            //valida cuando el codigo no existe
            iPerEN = PersonalRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida cuando esta desactivado
            PersonalEN iPerDesEN = PersonalRN.ValidaCuandoEstaDesactivado(iPerEN);
            if (iPerDesEN.Adicionales.EsVerdad == false) { return iPerDesEN; }

            //ok
            return iPerEN;
        }

        public static PersonalEN ValidaCuandoEstaDesactivado(PersonalEN pObj)
        {
            //objeto resultado
            PersonalEN iPerEN = new PersonalEN();

            //valida            
            if (pObj.CEstadoPersonal == "0")//desactivado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Este personal " + pObj.CodigoPersonal + " esta desactivado";
                return iPerEN;
            }

            //ok
            return iPerEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            PersonalAD iPerAD = new PersonalAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

    }
}
