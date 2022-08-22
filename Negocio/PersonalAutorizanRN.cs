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
    public class PersonalAutorizanRN
    {

        public static PersonalAutorizanEN EnBlanco()
        {
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();
            return iPerEN;
        }

        public static void AdicionarPersonal(PersonalAutorizanEN pObj)
        {
            PersonalAutorizanAD iPerAD = new PersonalAutorizanAD();
            iPerAD.AgregarPersonal(pObj);
        }

        public static void ModificarPersonal(PersonalAutorizanEN pObj)
        {
            PersonalAutorizanAD iPerAD = new PersonalAutorizanAD();
            iPerAD.ModificarPersonal(pObj);
        }

        public static void EliminarPersonal(PersonalAutorizanEN pObj)
        {
            PersonalAutorizanAD iPerAD = new PersonalAutorizanAD();
            iPerAD.EliminarPersonal(pObj);
        }

        public static List<PersonalAutorizanEN> ListarPersonales(PersonalAutorizanEN pObj)
        {
            PersonalAutorizanAD iPerAD = new PersonalAutorizanAD();
            return iPerAD.ListarPersonales(pObj);
        }

        public static PersonalAutorizanEN BuscarPersonalXClave(PersonalAutorizanEN pObj)
        {
            PersonalAutorizanAD iPerAD = new PersonalAutorizanAD();
            return iPerAD.BuscarPersonalXClave(pObj);
        }

        public static PersonalAutorizanEN EsPersonalExistente(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //validar
            pObj.ClavePersonalAutoriza = PersonalAutorizanRN.ObtenerClavePersonal(pObj);
            iPerEN = PersonalAutorizanRN.BuscarPersonalXClave(pObj);
            if (iPerEN.CodigoPersonalAutoriza == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El personal " + pObj.CodigoPersonalAutoriza + " no existe";
                return iPerEN;
            }

            //ok         
            return iPerEN;
        }

        public static PersonalAutorizanEN EsCodigoPersonalDisponible(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonalAutoriza == string.Empty) { return iPerEN; }

            //valida cuando existe el codigo
            iPerEN = PersonalAutorizanRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok          
            return iPerEN;
        }

        public static PersonalAutorizanEN ValidaCuandoCodigoYaExiste(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //validar    
            pObj.ClavePersonalAutoriza = PersonalAutorizanRN.ObtenerClavePersonal(pObj);
            iPerEN = PersonalAutorizanRN.BuscarPersonalXClave(pObj);
            if (iPerEN.CodigoPersonalAutoriza != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoPersonalAutoriza + " ya existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }
        
        public static string ObtenerValorDeCampo(PersonalAutorizanEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case PersonalAutorizanEN.ClaObj: return pObj.ClaveObjeto;
                case PersonalAutorizanEN.ClaPerAut: return pObj.ClavePersonalAutoriza;
                case PersonalAutorizanEN.CodEmp: return pObj.CodigoEmpresa;
                case PersonalAutorizanEN.NomEmp: return pObj.NombreEmpresa;
                case PersonalAutorizanEN.CodPerAut: return pObj.CodigoPersonalAutoriza;
                case PersonalAutorizanEN.NomPerAut: return pObj.NombrePersonalAutoriza;
                case PersonalAutorizanEN.CEstPerAut: return pObj.CEstadoPersonalAutoriza;
                case PersonalAutorizanEN.NEstPerAut: return pObj.NEstadoPersonalAutoriza;
                case PersonalAutorizanEN.UsuAgr: return pObj.UsuarioAgrega;
                case PersonalAutorizanEN.FecAgr: return pObj.FechaAgrega.ToString();
                case PersonalAutorizanEN.UsuMod: return pObj.UsuarioModifica;
                case PersonalAutorizanEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<PersonalAutorizanEN> FiltrarPersonalesXTextoEnCualquierPosicion(List<PersonalAutorizanEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<PersonalAutorizanEN> iLisRes = new List<PersonalAutorizanEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (PersonalAutorizanEN xPer in pLista)
            {
                string iTexto = PersonalAutorizanRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<PersonalAutorizanEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<PersonalAutorizanEN> pListaPersonales)
        {
            //lista resultado
            List<PersonalAutorizanEN> iLisRes = new List<PersonalAutorizanEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaPersonales; }

            //filtar la lista
            iLisRes = PersonalAutorizanRN.FiltrarPersonalesXTextoEnCualquierPosicion(pListaPersonales, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static PersonalAutorizanEN EsPersonalValido(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonalAutoriza == string.Empty) { return iPerEN; }

            //valida cuando el codigo no existe
            iPerEN = PersonalAutorizanRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok
            return iPerEN;
        }

        public static PersonalAutorizanEN EsActoModificarPersonal(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //validar si existe
            iPerEN = PersonalAutorizanRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }

        public static PersonalAutorizanEN EsActoEliminarPersonal(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //validar si existe
            iPerEN = PersonalAutorizanRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe este Personal en MovimientoCabe
            PersonalAutorizanEN iPerExiEN = PersonalAutorizanRN.ValidaCuandoCodigoPersonalEstaEnMovimientoCabe(iPerEN);
            if (iPerExiEN.Adicionales.EsVerdad == false) { return iPerExiEN; }

            //ok            
            return iPerEN;
        }

        public static PersonalAutorizanEN ValidaCuandoCodigoPersonalEstaEnMovimientoCabe(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //valida
            bool iExisten = MovimientoCabeRN.ExisteValorEnColumnaConEmpresa(MovimientoCabeEN.CodPer, pObj.CodigoPersonalAutoriza);
            if (iExisten == true)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Este personal tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            return iPerEN;
        }

        public static string ObtenerClavePersonal(PersonalAutorizanEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoPersonalAutoriza;

            //retornar
            return iClave;
        }

        public static List<PersonalAutorizanEN> ListarPersonalesActivos(PersonalAutorizanEN pObj)
        {
            PersonalAutorizanAD iPerAD = new PersonalAutorizanAD();
            return iPerAD.ListarPersonalesActivos(pObj);
        }

        public static PersonalAutorizanEN EsPersonalActivoValido(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonalAutoriza == string.Empty) { return iPerEN; }

            //valida cuando el codigo no existe
            iPerEN = PersonalAutorizanRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida cuando esta desactivado
            PersonalAutorizanEN iPerDesEN = PersonalAutorizanRN.ValidaCuandoEstaDesactivado(iPerEN);
            if (iPerDesEN.Adicionales.EsVerdad == false) { return iPerDesEN; }

            //ok
            return iPerEN;
        }

        public static PersonalAutorizanEN ValidaCuandoEstaDesactivado(PersonalAutorizanEN pObj)
        {
            //objeto resultado
            PersonalAutorizanEN iPerEN = new PersonalAutorizanEN();

            //valida            
            if (pObj.CEstadoPersonalAutoriza == "0")//desactivado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Este personal " + pObj.CodigoPersonalAutoriza + " esta desactivado";
                return iPerEN;
            }

            //ok
            return iPerEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            PersonalAutorizanAD iPerAD = new PersonalAutorizanAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

    }
}
