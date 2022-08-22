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
    public class CuentaBancoRN
    {

        public static CuentaBancoEN EnBlanco()
        {
            CuentaBancoEN iCBcoEN = new CuentaBancoEN();
            return iCBcoEN;
        }

        public static void AdicionarCuentaBanco(CuentaBancoEN pObj)
        {
            CuentaBancoAD iCtaBcoAD = new CuentaBancoAD();
            iCtaBcoAD.AdicionarCuentaBanco(pObj);
        }
        
        public static void ModificarCuentaBanco(CuentaBancoEN pObj)
        {
            CuentaBancoAD iCtaBcoAD = new CuentaBancoAD();
            iCtaBcoAD.ModificarCuentaBanco(pObj);
        }
        
        public  static void EliminarCuentaBancoXClave(CuentaBancoEN pObj)
        {
            CuentaBancoAD iCtaBcoAD = new CuentaBancoAD();
            iCtaBcoAD.EliminarCuentaBancoXClave(pObj);
        }

        public static CuentaBancoEN BuscarCuentaBancoXClave(CuentaBancoEN pObj)
        {
            CuentaBancoAD iCBcoAD = new CuentaBancoAD();
            return iCBcoAD.BuscarCuentaBancoXClave(pObj);
        }

        public static CuentaBancoEN BuscarCuentaBancoXNumero( CuentaBancoEN pObj )
        {
            CuentaBancoAD iCBcoAD = new CuentaBancoAD( );
            return iCBcoAD.BuscarCuentaBancoXNumero( pObj );
        }

        public static List<CuentaBancoEN> ListarCuentaBancoActivos(CuentaBancoEN pObj)
        {
            CuentaBancoAD iCBcoAD = new CuentaBancoAD();
            return iCBcoAD.ListarCuentaBancoActivos(pObj);
        }
        
        public static List<CuentaBancoEN> ListarCuentaBancoXEmpresa(CuentaBancoEN pObj)
        {
            CuentaBancoAD iCBcoAD = new CuentaBancoAD();
            return iCBcoAD.ListarCuentaBancoXEmpresa(pObj);
        }
        
        public static CuentaBancoEN EsCuentaBancoValidoXNumero(CuentaBancoEN pObj)
        {
            CuentaBancoEN iCBcoEN = new CuentaBancoEN();
                        
            //validar que si hay codigo
            if (pObj.NumeroCuentaBanco != string.Empty)
            {
                //si CodigoBanco no esta vacio            
                iCBcoEN = CuentaBancoRN.BuscarCuentaBancoXNumero(pObj);
                if (iCBcoEN.NumeroCuentaBanco == string.Empty)
                {
                    iCBcoEN.Adicionales.EsVerdad = false;
                    iCBcoEN.Adicionales.Mensaje = "La Cuenta" + Cadena.Espacios(1) + pObj.NumeroCuentaBanco + Cadena.Espacios(1) + "no existe";
                    return iCBcoEN;
                }

                //validar si esta activo
                if (iCBcoEN.EstadoCuentaBanco == "0") //desactivado
                {
                    iCBcoEN = CuentaBancoRN.EnBlanco();
                    iCBcoEN.Adicionales.EsVerdad = false;
                    iCBcoEN.Adicionales.Mensaje = "La Cuenta" + Cadena.Espacios(1) + pObj.NumeroCuentaBanco + Cadena.Espacios(1) + "esta desactivado";
                    return iCBcoEN;
                }
            }
            
            //ok          
            iCBcoEN.Adicionales.EsVerdad = true;
            return iCBcoEN;
        }
        
        public static CuentaBancoEN EsCuentaBancoExistente(CuentaBancoEN pObj)
        {
            CuentaBancoEN iCBcoEN = new CuentaBancoEN();
            iCBcoEN = CuentaBancoRN.BuscarCuentaBancoXClave(pObj);
            if (iCBcoEN.ClaveCuentaBanco == string.Empty)
            {
                iCBcoEN.Adicionales.EsVerdad = false;
                iCBcoEN.Adicionales.Mensaje = "La CuentaBanco " + pObj.ClaveCuentaBanco + " no existe";
            }
            else
            {
                iCBcoEN.Adicionales.EsVerdad = true;
            }
            return iCBcoEN;
        }
        
        public static CuentaBancoEN EsCuentaBancoDisponible(CuentaBancoEN pObj, bool pVacio)
        {
            CuentaBancoEN iCBcoEN = new CuentaBancoEN();
            
            if (pVacio == true)
            {
                if (pObj.ClaveCuentaBanco == string.Empty)
                {
                    iCBcoEN.Adicionales.EsVerdad = false;
                    iCBcoEN.Adicionales.Mensaje = "Debes ingresar un Cuenta Banco";
                    return iCBcoEN;
                }

            }
            else
            {
                if (pObj.ClaveCuentaBanco == string.Empty)
                {
                    iCBcoEN.Adicionales.EsVerdad = true;
                    iCBcoEN.Adicionales.Mensaje = "";
                    return iCBcoEN;
                }

            }

            iCBcoEN = CuentaBancoRN.BuscarCuentaBancoXClave(pObj);
            if (iCBcoEN.ClaveCuentaBanco == string.Empty)
            {
                iCBcoEN.Adicionales.EsVerdad = true;
            }
            else
            {
                iCBcoEN.Adicionales.EsVerdad = false;
                iCBcoEN.Adicionales.Mensaje = "La Cuenta Banco " + pObj.CodigoCuentaBanco + " ya le pertenece a otra Cuenta Banco";
            }
            return iCBcoEN;
        }

        public static List<CuentaBancoEN> ListarCuentaBanco(CuentaBancoEN pObj)
        {
            CuentaBancoAD iCtaAD = new CuentaBancoAD();
            return iCtaAD.ListarCuentaBancos(pObj);
        }

        public static List<CuentaBancoEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<CuentaBancoEN> pListaCuentaBanco)
        {
            //lista resultado
            List<CuentaBancoEN> iLisRes = new List<CuentaBancoEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaCuentaBanco; }

            //filtar la lista
            iLisRes = CuentaBancoRN.FiltrarCuentaBancoXTextoEnCualquierPosicion(pListaCuentaBanco, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static List<CuentaBancoEN> FiltrarCuentaBancoXTextoEnCualquierPosicion(List<CuentaBancoEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<CuentaBancoEN> iLisRes = new List<CuentaBancoEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (CuentaBancoEN xPro in pLista)
            {
                string iTexto = CuentaBancoRN.ObtenerValorDeCampo(xPro, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPro);
                }
            }

            //devolver
            return iLisRes;
        }

        public static string ObtenerValorDeCampo(CuentaBancoEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case CuentaBancoEN.ClaObj: return pObj.ClaveObjeto;
                case CuentaBancoEN.CodCtaBco: return pObj.CodigoCuentaBanco;
                case CuentaBancoEN.CodBco: return pObj.CodigoBanco;
                case CuentaBancoEN.NomBco: return pObj.NombreBanco;
                case CuentaBancoEN.AgeCtaBco: return pObj.AgenciaCuentaBanco;
                case CuentaBancoEN.CtaCon: return pObj.CuentaContable;
                case CuentaBancoEN.EstCtaBco: return pObj.EstadoCuentaBanco;
                case CuentaBancoEN.NEstCtaBco: return pObj.NEstadoCuentaBanco;
                case CuentaBancoEN.UsuAgr: return pObj.UsuarioAgrega;
                case CuentaBancoEN.FecAgr: return pObj.FechaAgrega.ToString();
                case CuentaBancoEN.UsuMod: return pObj.UsuarioModifica;
                case CuentaBancoEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static CuentaBancoEN EsCodigoCuentaBancoDisponible(CuentaBancoEN pObj, bool pVacio)
        {
            //objeto resultado
            CuentaBancoEN iCtaBcoEN = new CuentaBancoEN();

            if (pVacio == true)
            {
                if (pObj.CodigoCuentaBanco == string.Empty)
                {
                    iCtaBcoEN.Adicionales.EsVerdad = false;
                    iCtaBcoEN.Adicionales.Mensaje = "Debes ingresar un codigo Cuenta Banco";
                    return iCtaBcoEN;
                }

            }
            else
            {
                if (pObj.CodigoCuentaBanco == string.Empty)
                {
                    iCtaBcoEN.Adicionales.EsVerdad = true;
                    iCtaBcoEN.Adicionales.Mensaje = "";
                    return iCtaBcoEN;
                }

            }

            iCtaBcoEN = CuentaBancoRN.BuscarCuentaBancoXClave(pObj);
            if (iCtaBcoEN.CodigoCuentaBanco == string.Empty)
            {
                iCtaBcoEN.Adicionales.EsVerdad = true;
            }
            else
            {
                iCtaBcoEN.Adicionales.EsVerdad = false;
                iCtaBcoEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoCuentaBanco + " ya le pertenece a otra Cuenta Banco";
            }
            return iCtaBcoEN;
        }

        public static string ObtenerClaveCuentaBanco(CuentaBancoEN pCueBan)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave = Universal.gCodigoEmpresa + "-";
            iClave += pCueBan.CodigoCuentaBanco;

            //devolver
            return iClave;
        }

        public static bool ExisteValorEnColumna(string pColumna, string pValor)
        {
            CuentaBancoAD iCueBanAD = new CuentaBancoAD();
            return iCueBanAD.ExisteValorEnColumna(pColumna, pValor);
        }

        public static CuentaBancoEN EsActoEliminarCuentaBanco(CuentaBancoEN pObj)
        {
            //objeto resultado
            CuentaBancoEN iCueBanEN = new CuentaBancoEN();

            //validar si existe
            iCueBanEN = CuentaBancoRN.EsCuentaBancoExistente(pObj);
            if (iCueBanEN.Adicionales.EsVerdad == false) { return iCueBanEN; }

            //validar si este objeto esta referenciado a una cuota           
            if (EnvioRecRN.ExisteValorEnColumna(CuentaBancoEN.ClaCtaBco, iCueBanEN.ClaveCuentaBanco) == true)
            {
                iCueBanEN.Adicionales.EsVerdad = false;
                iCueBanEN.Adicionales.Mensaje = "la cuenta bancaria " + pObj.CodigoCuentaBanco + " Esta referenciado en envios recaudacion";
                return iCueBanEN;
            }

            //ok
            iCueBanEN.Adicionales.EsVerdad = true;
            return iCueBanEN;
        }

    }
}
