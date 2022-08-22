using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;
using Comun;
using Entidades.Adicionales;


namespace Negocio
{
    public class BancoRN
    {

        public static BancoEN EnBlanco()
        {
            BancoEN iBcoEN = new BancoEN();
            return iBcoEN;
        }
        
        public static void AdicionarBanco(BancoEN pObj)
        {
            BancoAD iBcoAD = new BancoAD();
            iBcoAD.AdicionarBanco(pObj);
        }
        
        public static void ModificarBanco(BancoEN pObj)
        {
            BancoAD iBcoAD = new BancoAD();
            iBcoAD.ModificarBanco(pObj);
        }
        
        public static void EliminarBancoXCodigo(BancoEN pObj)
        {
            BancoAD iBcoAD = new BancoAD();
            iBcoAD.EliminarBancoXCodigo(pObj);
        }

        public static List<BancoEN> ListarBancosActivos(BancoEN pObj)
        {
            BancoAD iBcoAD = new BancoAD();
            return iBcoAD.ListarBancosActivos(pObj);
        }
                     
        public static BancoEN EsBancoValido(BancoEN pObj)
        {
            BancoEN iBcoEN = new BancoEN();

            //validar que no esta vacio codigo
            if (pObj.CodigoBanco != string.Empty)
            {
                //validar si existe banco
                iBcoEN = BancoRN.BuscarBancoXCodigo(pObj);
                if (iBcoEN.CodigoBanco == string.Empty)
                {
                    iBcoEN.Adicionales.EsVerdad = false;
                    iBcoEN.Adicionales.Mensaje = "El banco" + Cadena.Espacios(1) + pObj.CodigoBanco + Cadena.Espacios(1) + "no existe";
                    return iBcoEN;
                }

                //validar si esta activado
                if (iBcoEN.CEstadoBanco == "0") //desactivado
                {
                    iBcoEN = BancoRN.EnBlanco();
                    iBcoEN.Adicionales.EsVerdad = false;
                    iBcoEN.Adicionales.Mensaje = "El Banco" + Cadena.Espacios(1) + pObj.CodigoBanco + Cadena.Espacios(1) + "esta desactivado";
                    return iBcoEN;
                }

            }
          
            //ok
            iBcoEN.Adicionales.EsVerdad = true;
            return iBcoEN;
        }
        
        public static BancoEN EsBancoExistente(BancoEN pObj)
        {
            BancoEN iBcoEN = new BancoEN();
            iBcoEN = BancoRN.BuscarBancoXCodigo(pObj);
            if (iBcoEN.CodigoBanco == string.Empty)
            {
                iBcoEN.Adicionales.EsVerdad = false;
                iBcoEN.Adicionales.Mensaje = "El Banco " + pObj.CodigoBanco +  " no existe";
            }
            else
            {
                iBcoEN.Adicionales.EsVerdad = true;
            }
            return iBcoEN;
        }
        
        public static BancoEN EsCodigoBancoDisponible(BancoEN pObj, bool pVacio)
        {
            //objeto resultado
            BancoEN iBcoEN = new BancoEN();

            if (pVacio == true)
            {
                if (pObj.CodigoBanco == string.Empty)
                {
                    iBcoEN.Adicionales.EsVerdad = false;
                    iBcoEN.Adicionales.Mensaje = "Debes ingresar un codigo Banco";
                    return iBcoEN;
                }

            }
            else
            {
                if (pObj.CodigoBanco == string.Empty)
                {
                    iBcoEN.Adicionales.EsVerdad = true;
                    iBcoEN.Adicionales.Mensaje = "";
                    return iBcoEN;
                }

            }

            iBcoEN = BancoRN.BuscarBancoXCodigo(pObj);
            if (iBcoEN.CodigoBanco == string.Empty)
            {
                iBcoEN.Adicionales.EsVerdad = true;
            }
            else
            {
                iBcoEN.Adicionales.EsVerdad = false;
                iBcoEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoBanco + " ya le pertenece a otro Banco";
            }
            return iBcoEN;
        }

        public static List<BancoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<BancoEN> pListaBancos)
        {
            //lista resultado
            List<BancoEN> iLisRes = new List<BancoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaBancos; }

            //filtar la lista
            iLisRes = BancoRN.FiltrarBancosXTextoEnCualquierPosicion(pListaBancos, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<BancoEN> FiltrarBancosXTextoEnCualquierPosicion(List<BancoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<BancoEN> iLisRes = new List<BancoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (BancoEN xBco in pLista)
            {
                string iTexto = BancoRN.ObtenerValorDeCampo(xBco, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xBco);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(BancoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case BancoEN.ClaObj: return pObj.ClaveObjeto;
                case BancoEN.CodBco: return pObj.CodigoBanco;
                case BancoEN.NomBco: return pObj.NombreBanco;
                case BancoEN.CodSun: return pObj.CodigoSunat;
                case BancoEN.NEstBco: return pObj.NEstadoBanco;
                case BancoEN.UsuAgr: return pObj.UsuarioAgrega;
                case BancoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case BancoEN.UsuMod: return pObj.UsuarioModifica;
                case BancoEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static BancoEN BuscarBancoXCodigo(BancoEN pObj)
        {
            BancoAD iBcoAD = new BancoAD();
            return iBcoAD.BuscarBancoXCodigo(pObj);
        }

        public static List<BancoEN> ListarBancos(BancoEN pObj) 
        {
            BancoAD iBcoAD = new BancoAD();
            return iBcoAD.ListarBancos(pObj);
        }

        public static BancoEN EsActoEliminarBanco(BancoEN pObj)
        {
            //objeto resultado
            BancoEN iBanEN = new BancoEN();

            //validar si existe
            iBanEN = BancoRN.EsBancoExistente(pObj);
            if (iBanEN.Adicionales.EsVerdad == false) { return iBanEN; }

            //validar si este objeto esta referenciado a una cuota           
            if (CuentaBancoRN.ExisteValorEnColumna(BancoEN.CodBco, iBanEN.CodigoBanco) == true)
            {
                iBanEN.Adicionales.EsVerdad = false;
                iBanEN.Adicionales.Mensaje = "El Banco " + pObj.CodigoBanco + " Esta referenciado en cuentas bancarias";
                return iBanEN;
            }

            //ok
            iBanEN.Adicionales.EsVerdad = true;
            return iBanEN;
        }

    }
}
