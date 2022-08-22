using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Adicionales;
using WinControles;
using Entidades;
using Negocio;
using Comun;
using WinControles.ControlesWindows;

namespace Presentacion.FuncionesGenericas
{
    public class Generico
    {

        public static void CancelarVentanaEditar(Form pVentana, Universal.Opera pOperacionVentana, Masivo pObjetoMasivo, string pTituloVentana)
        {
            if (pOperacionVentana == Universal.Opera.Visualizar || pOperacionVentana == Universal.Opera.Eliminar || pOperacionVentana == Universal.Opera.Anular)
            {
                pVentana.Close();
                return;
            }

            //solo para adicionar y modificar
            if (pObjetoMasivo.SonTextosIguales() == false)
            {
                if (Mensaje.DeseasCancelarOperacion(pTituloVentana) == false)
                {
                    return;
                }
                else
                {
                    pVentana.Close();
                }
            }
            else
            {
                pVentana.Close();
            }
        }

        public static void CambiandoDia(Universal.Opera pOperacionVentana,DateTimePicker pObjetoFecha, TextBox pObjetoTipoCambio)
        {
            ////cuando la operacion es diferente del adicionar o modificar entonces termina el proceso
            //if (pOperacionVentana != Universal.Opera.Adicionar && pOperacionVentana != Universal.Opera.Modificar) { return; }

            ////mostra el dia cada vez que va cambiando la fecha en el datapicker
            //DiaEN iDiaEN = new DiaEN();
            //iDiaEN.FechaDia = pObjetoFecha.Value.Date;
            //MessageBox.Show("1");
            //iDiaEN = DiaRN.HayTipoCambioVentaDeDia(iDiaEN);
            //MessageBox.Show("2");
            //if (iDiaEN.Adicionales.EsVerdad == false)
            //{
            //    Mensaje.OperacionDenegada(iDiaEN.Adicionales.Mensaje, "Dia");
            //}
            //pObjetoTipoCambio.Text = Formato.NumeroDecimal(iDiaEN.TipoCambioVentaDia.ToString(), 3);
        }

        public static bool EsCodigoItemGValido(string pCodigoTabla, TextBox pControlCodigoTabla, TextBox pControlNombreTabla, string pTituloTabla)
        {
            //si el control es de solo lectura entonces devuelve true
            if (pControlCodigoTabla.ReadOnly == true) { return true; }

            //ejecutar
            ItemGEN iIteGEN = new ItemGEN();
            iIteGEN.CodigoTabla = pCodigoTabla;
            iIteGEN.CodigoItemG = pControlCodigoTabla.Text.Trim();
            iIteGEN = ItemGRN.EsItemGValido(iIteGEN);
            if (iIteGEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIteGEN.Adicionales.Mensaje, pTituloTabla);
                pControlCodigoTabla.Focus();
            }

            //mostrar datos
            pControlCodigoTabla.Text = iIteGEN.CodigoItemG;
            pControlNombreTabla.Text = iIteGEN.NombreItemG;

            //devolver
            return iIteGEN.Adicionales.EsVerdad;
        }

        public static bool EsPeriodoValido(string pPeriodo)
        {
            //esta dato aparte de ser un periodo real , puede estar vacio
            if (pPeriodo == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir un periodo, no se puede realizar la operacion", "Periodo");
                return false;
            }
        
            //ok
            return true;
        }

        public static void MostrarMensajeError(Adicional pObjMenErr)
        {
            if (pObjMenErr.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(pObjMenErr.Mensaje, "Operacion Denegada");
            }
        }

        public static void MostrarMensajeError(Adicional pObjMenErr,Control pControlFoco)
        {
            if (pObjMenErr.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(pObjMenErr.Mensaje, "Operacion Denegada");
                pControlFoco.Focus();
            }
        }

        public static void MostrarMensajeError(Adicional pObjMenErr, TextBox pControlTxt)
        {
            if (pObjMenErr.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(pObjMenErr.Mensaje, "Operacion Denegada");
                pControlTxt.Clear();
                pControlTxt.Focus();                
            }
        }

        public static bool EsCodigoItemEValido(string pCodigoTabla, TextBox pControlCodigoTabla, TextBox pControlNombreTabla, string pTituloTabla)
        {
            //si el control es de solo lectura entonces devuelve true
            if (pControlCodigoTabla.ReadOnly == true) { return true; }

            //ejecutar
            ItemEEN iIteEEN = new ItemEEN();
            iIteEEN.CodigoTabla = pCodigoTabla;
            iIteEEN.CodigoItemE = pControlCodigoTabla.Text.Trim();
            iIteEEN.ClaveItemE = ItemERN.ObtenerClaveItemE(iIteEEN);
            iIteEEN = ItemERN.EsItemEValido(iIteEEN);
            if (iIteEEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIteEEN.Adicionales.Mensaje, pTituloTabla);
                pControlCodigoTabla.Focus();
            }

            //mostrar datos
            pControlCodigoTabla.Text = iIteEEN.CodigoItemE;
            pControlNombreTabla.Text = iIteEEN.NombreItemE;

            //devolver
            return iIteEEN.Adicionales.EsVerdad;
        }

        public static bool EsCodigoItemEActivoValido(string pCodigoTabla, TextBox pControlCodigoTabla, TextBox pControlNombreTabla, string pTituloTabla)
        {
            //si el control es de solo lectura entonces devuelve true
            if (pControlCodigoTabla.ReadOnly == true) { return true; }

            //ejecutar
            ItemEEN iIteEEN = new ItemEEN();
            iIteEEN.CodigoTabla = pCodigoTabla;
            iIteEEN.CodigoItemE = pControlCodigoTabla.Text.Trim();
            iIteEEN.ClaveItemE = ItemERN.ObtenerClaveItemE(iIteEEN);
            iIteEEN = ItemERN.EsItemEActivoValido(iIteEEN);
            if (iIteEEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIteEEN.Adicionales.Mensaje, pTituloTabla);
                pControlCodigoTabla.Focus();
            }

            //mostrar datos
            pControlCodigoTabla.Text = iIteEEN.CodigoItemE;
            pControlNombreTabla.Text = iIteEEN.NombreItemE;

            //devolver
            return iIteEEN.Adicionales.EsVerdad;
        }


    }
}
