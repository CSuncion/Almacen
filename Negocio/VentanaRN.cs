using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;

namespace Negocio
{
    public class VentanaRN
    {
        public static VentanaEN EnBlanco()
        {
            VentanaEN iVenEN = new VentanaEN();
            return iVenEN;
        }

        public static void AdicionarVentana(VentanaEN pObj)
        {
            VentanaAD iVenAD = new VentanaAD();
            iVenAD.AgregarVentana(pObj);
        }

        public static void ModificarVentana(VentanaEN pObj)
        {
            VentanaAD iVenAD = new VentanaAD();
            iVenAD.ModificarVentana(pObj);
        }

        public static void EliminarVentana(VentanaEN pObj)
        {
            VentanaAD iVenAD = new VentanaAD();
            iVenAD.EliminarVentana(pObj);
        }

        public static VentanaEN BuscarVentanaXCodigo(VentanaEN pObj)
        {
            VentanaAD iVenAD = new VentanaAD();
            return iVenAD.BuscarVentanaXCodigo(pObj);
        }

        public static List<VentanaEN> ListarVentanas(VentanaEN pObj)
        {
            VentanaAD iVenAD = new VentanaAD();
            return iVenAD.ListarVentanas(pObj);
        }
       
        public static VentanaEN EsVentanaExistente(VentanaEN pObj)
        {
            VentanaEN iVenEN = new VentanaEN();
            iVenEN = VentanaRN.BuscarVentanaXCodigo(pObj);
            if (iVenEN.CodigoVentana == string.Empty)
            {
                iVenEN.Adicionales.EsVerdad = false;
                iVenEN.Adicionales.Mensaje = "Esta Ventana " + pObj.CodigoVentana + " no existe";
            }
            else
            {
                iVenEN.Adicionales.EsVerdad = true;

            }
            return iVenEN;
        }

        public static VentanaEN EsCodigoVentanaDisponible(VentanaEN pObj)
        {
            VentanaEN iVenEN = new VentanaEN();

            //si no hay codigo pasa verdadero
            if (pObj.CodigoVentana == string.Empty)
            {
                iVenEN.Adicionales.EsVerdad = true;
                iVenEN.Adicionales.Mensaje = string.Empty;
                return iVenEN;
            }

            //aqui si hay codigo
            iVenEN = VentanaRN.BuscarVentanaXCodigo(pObj);
            if (iVenEN.CodigoVentana == string.Empty)
            {
                iVenEN.Adicionales.EsVerdad = true;
            }
            else
            {
                iVenEN.Adicionales.EsVerdad = false;
                iVenEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoVentana + " ya le pertenece a una Ventana";
            }
            return iVenEN;
        }

        public static VentanaEN EsCodigoVentanaDisponible(VentanaEN pObj, bool pAutomatica, bool pVacio)
        {
            VentanaEN iVenEN = new VentanaEN();

            //si es automatica entonces pasa verdadero
            if (pAutomatica == true)
            {
                iVenEN.Adicionales.EsVerdad = true;
                return iVenEN;
            }
            else
            {
                //aqui es codigo es digitado por el usuario
                //segun pVacio ,si es true indica que si el codigo viene vacio
                //entonces la respuesta es falso
                if (pVacio == true)
                {
                    if (pObj.CodigoVentana == string.Empty)
                    {
                        iVenEN.Adicionales.EsVerdad = false;
                        iVenEN.Adicionales.Mensaje = "Debes digitar el codigo";
                        return iVenEN;
                    }
                }
                else
                {
                    if (pObj.CodigoVentana == string.Empty)
                    {
                        iVenEN.Adicionales.EsVerdad = true;
                        return iVenEN;
                    }
                }

                //el codigo debe ser numerico de 3 digitos
                if (pObj.CodigoVentana.Length != 3)
                {
                    iVenEN.Adicionales.EsVerdad = false;
                    iVenEN.Adicionales.Mensaje = "El codigo es de 3 digitos";
                    return iVenEN;
                }

                //aqui si hay codigo
                iVenEN = VentanaRN.BuscarVentanaXCodigo(pObj);
                if (iVenEN.CodigoVentana == string.Empty)
                {
                    iVenEN.Adicionales.EsVerdad = true;
                }
                else
                {
                    iVenEN.Adicionales.EsVerdad = false;
                    iVenEN.Adicionales.Mensaje = "El codigo " + pObj.CodigoVentana + " ya le pertenece a una Ventana";
                }
                return iVenEN;
            }

        }

        public static string ObtenerNuevoCodigo(VentanaEN pObj)
        {
            VentanaAD iVenAD = new VentanaAD();
            string iNuevoCodigo = iVenAD.ObtenerMaximoValorEnColumna(pObj);

            //si el valor es vacio entonces se inicia con (001)
            if (iNuevoCodigo == string.Empty)
            {
                iNuevoCodigo = "001";
            }
            else
            {
                iNuevoCodigo = Numero.IncrementarCorrelativoNumerico(iNuevoCodigo);
            }
            return iNuevoCodigo;
        }



    }
}
