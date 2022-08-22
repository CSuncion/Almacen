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
    public class PersonalRecibenRN
    {

        public static PersonalRecibenEN EnBlanco()
        {
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();
            return iPerEN;
        }

        public static void AdicionarPersonal(PersonalRecibenEN pObj)
        {
            PersonalRecibenAD iPerAD = new PersonalRecibenAD();
            iPerAD.AgregarPersonal(pObj);
        }

        public static void ModificarPersonal(PersonalRecibenEN pObj)
        {
            PersonalRecibenAD iPerAD = new PersonalRecibenAD();
            iPerAD.ModificarPersonal(pObj);
        }

        public static void EliminarPersonal(PersonalRecibenEN pObj)
        {
            PersonalRecibenAD iPerAD = new PersonalRecibenAD();
            iPerAD.EliminarPersonal(pObj);
        }

        public static List<PersonalRecibenEN> ListarPersonales(PersonalRecibenEN pObj)
        {
            PersonalRecibenAD iPerAD = new PersonalRecibenAD();
            return iPerAD.ListarPersonales(pObj);
        }

        public static PersonalRecibenEN BuscarPersonalXClave(PersonalRecibenEN pObj)
        {
            PersonalRecibenAD iPerAD = new PersonalRecibenAD();
            return iPerAD.BuscarPersonalXClave(pObj);
        }

        public static PersonalRecibenEN EsPersonalExistente(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //validar
            pObj.ClavePersonalRecibe = PersonalRecibenRN.ObtenerClavePersonal(pObj);
            iPerEN = PersonalRecibenRN.BuscarPersonalXClave(pObj);
            if (iPerEN.CodigoPersonalRecibe == string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El personal " + pObj.CodigoPersonalRecibe + " no existe";
                return iPerEN;
            }

            //ok         
            return iPerEN;
        }

        public static PersonalRecibenEN EsCodigoPersonalDisponible(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonalRecibe == string.Empty) { return iPerEN; }

            //valida cuando existe el codigo
            iPerEN = PersonalRecibenRN.ValidaCuandoCodigoYaExiste(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok          
            return iPerEN;
        }

        public static PersonalRecibenEN ValidaCuandoCodigoYaExiste(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //validar    
            pObj.ClavePersonalRecibe = PersonalRecibenRN.ObtenerClavePersonal(pObj);
            iPerEN = PersonalRecibenRN.BuscarPersonalXClave(pObj);
            if (iPerEN.CodigoPersonalRecibe != string.Empty)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoPersonalRecibe + " ya existe";
                return iPerEN;
            }

            //ok
            iPerEN.Adicionales.EsVerdad = true;
            return iPerEN;
        }
        
        public static string ObtenerValorDeCampo(PersonalRecibenEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case PersonalRecibenEN.ClaObj: return pObj.ClaveObjeto;
                case PersonalRecibenEN.ClaPerRec: return pObj.ClavePersonalRecibe;
                case PersonalRecibenEN.CodEmp: return pObj.CodigoEmpresa;
                case PersonalRecibenEN.NomEmp: return pObj.NombreEmpresa;
                case PersonalRecibenEN.CodPerRec: return pObj.CodigoPersonalRecibe;
                case PersonalRecibenEN.NomPerRec: return pObj.NombrePersonalRecibe;
                case PersonalRecibenEN.CEstPerRec: return pObj.CEstadoPersonalRecibe;
                case PersonalRecibenEN.NEstPerRec: return pObj.NEstadoPersonalRecibe;
                case PersonalRecibenEN.UsuAgr: return pObj.UsuarioAgrega;
                case PersonalRecibenEN.FecAgr: return pObj.FechaAgrega.ToString();
                case PersonalRecibenEN.UsuMod: return pObj.UsuarioModifica;
                case PersonalRecibenEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<PersonalRecibenEN> FiltrarPersonalesXTextoEnCualquierPosicion(List<PersonalRecibenEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<PersonalRecibenEN> iLisRes = new List<PersonalRecibenEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (PersonalRecibenEN xPer in pLista)
            {
                string iTexto = PersonalRecibenRN.ObtenerValorDeCampo(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<PersonalRecibenEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<PersonalRecibenEN> pListaPersonales)
        {
            //lista resultado
            List<PersonalRecibenEN> iLisRes = new List<PersonalRecibenEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaPersonales; }

            //filtar la lista
            iLisRes = PersonalRecibenRN.FiltrarPersonalesXTextoEnCualquierPosicion(pListaPersonales, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static PersonalRecibenEN EsPersonalValido(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonalRecibe == string.Empty) { return iPerEN; }

            //valida cuando el codigo no existe
            iPerEN = PersonalRecibenRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok
            return iPerEN;
        }

        public static PersonalRecibenEN EsActoModificarPersonal(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //validar si existe
            iPerEN = PersonalRecibenRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //ok            
            return iPerEN;
        }

        public static PersonalRecibenEN EsActoEliminarPersonal(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //validar si existe
            iPerEN = PersonalRecibenRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida si existe este Personal en MovimientoCabe
            PersonalRecibenEN iPerExiEN = PersonalRecibenRN.ValidaCuandoCodigoPersonalEstaEnMovimientoCabe(iPerEN);
            if (iPerExiEN.Adicionales.EsVerdad == false) { return iPerExiEN; }

            //ok            
            return iPerEN;
        }

        public static PersonalRecibenEN ValidaCuandoCodigoPersonalEstaEnMovimientoCabe(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //valida
            bool iExisten = MovimientoCabeRN.ExisteValorEnColumnaConEmpresa(MovimientoCabeEN.CodPer, pObj.CodigoPersonalRecibe);
            if (iExisten == true)
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Este personal tiene movimientos de Ingreso y/o Egresos, no se puede realizar la operacion";
                return iPerEN;
            }

            //ok
            return iPerEN;
        }

        public static string ObtenerClavePersonal(PersonalRecibenEN pObj)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pObj.CodigoPersonalRecibe;

            //retornar
            return iClave;
        }

        public static List<PersonalRecibenEN> ListarPersonalesActivos(PersonalRecibenEN pObj)
        {
            PersonalRecibenAD iPerAD = new PersonalRecibenAD();
            return iPerAD.ListarPersonalesActivos(pObj);
        }

        public static PersonalRecibenEN EsPersonalActivoValido(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //valida cuando el codigo esta vacio
            if (pObj.CodigoPersonalRecibe == string.Empty) { return iPerEN; }

            //valida cuando el codigo no existe
            iPerEN = PersonalRecibenRN.EsPersonalExistente(pObj);
            if (iPerEN.Adicionales.EsVerdad == false) { return iPerEN; }

            //valida cuando esta desactivado
            PersonalRecibenEN iPerDesEN = PersonalRecibenRN.ValidaCuandoEstaDesactivado(iPerEN);
            if (iPerDesEN.Adicionales.EsVerdad == false) { return iPerDesEN; }

            //ok
            return iPerEN;
        }

        public static PersonalRecibenEN ValidaCuandoEstaDesactivado(PersonalRecibenEN pObj)
        {
            //objeto resultado
            PersonalRecibenEN iPerEN = new PersonalRecibenEN();

            //valida            
            if (pObj.CEstadoPersonalRecibe == "0")//desactivado
            {
                iPerEN.Adicionales.EsVerdad = false;
                iPerEN.Adicionales.Mensaje = "Este personal " + pObj.CodigoPersonalRecibe + " esta desactivado";
                return iPerEN;
            }

            //ok
            return iPerEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            PersonalRecibenAD iPerAD = new PersonalRecibenAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

    }
}
