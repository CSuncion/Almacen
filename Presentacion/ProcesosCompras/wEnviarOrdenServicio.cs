﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Comun;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Entidades;
using Negocio;
using Presentacion.Principal;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Presentacion.ProcesosCompras
{
    public partial class wEnviarOrdenServicio : Heredados.MiForm8
    {
        public wEnviarOrdenServicio()
        {
            InitializeComponent();
        }

        public wOrdenServicio wOrdCom;
        int eIncrementoBarra = 0;
        string eProcesoActual = string.Empty;
        Masivo eMas = new Masivo();
        List<MovimientoOCCabeEN> listMov = new List<MovimientoOCCabeEN>();
        private bool closePending = true;
        #region General

        public void InicializaVentana()
        {
            //eventos de controles
            eMas.EjecutarTodosLosEventos();

            this.wOrdCom.Enabled = false;
            this.Show();
        }

        public void VentanaProgressBar(List<MovimientoOCCabeEN> pMovCab)
        {
            this.InicializaVentana();

            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.listMov = pMovCab;

            //ejecutar el proceso
            this.Enabled = false;
            this.progressBar1.Value = 0;
            this.eIncrementoBarra = 0;
            this.backgroundWorker1.RunWorkerAsync();
        }


        public void Cerrar()
        {
            //obtener al wMenu
            //wMenu wMen = (wMenu)this.ParentForm;
            //wMen.CerrarVentanaHijo(this, wMen.iteSolicitudPedido, null);
            this.wOrdCom.Enabled = true;
            this.wOrdCom.ActualizarVentana();
            this.Close();
        }

        public void EnviandoCorreos()
        {
            this.eIncrementoBarra = 0;
            this.eProcesoActual = "Generando correos...";
            int iNroObjetos = 0;
            ParametroEN iParEN = ParametroRN.BuscarParametro();
            foreach (MovimientoOCCabeEN movCabe in this.listMov)
            {
                if (movCabe.VerdadFalso)
                    iNroObjetos++;
            }
            if (iNroObjetos == 0)
            {
                eIncrementoBarra = 100;
                this.backgroundWorker1.ReportProgress(1);
            }
            else
            {
                //parametros del avanze del proceso
                int iRazon = Operador.DivisionEntera(iNroObjetos, 70) + 1;
                int iNroVueltas = Operador.DivisionEntera(iNroObjetos, iRazon);
                int iIncrementoFinal = 70 - iNroVueltas;
                int iContadorObjeto = 0;
                int iContadorVueltas = 0;
                foreach (MovimientoOCCabeEN movCabe in this.listMov)
                {
                    if (movCabe.VerdadFalso)
                    {
                        this.EnviarCorreo(movCabe, iParEN);
                        MovimientoOCCabeRN.EnviadoMovimientoCabe(movCabe);
                    }

                    iContadorObjeto++;
                    if ((iContadorObjeto % iRazon) == 0)
                    {
                        iContadorVueltas++;
                        eIncrementoBarra = 1;
                        this.backgroundWorker1.ReportProgress(1);
                    }

                    if (iContadorVueltas == iNroVueltas && iContadorObjeto == iNroObjetos)
                    {
                        eIncrementoBarra = iIncrementoFinal;
                        this.backgroundWorker1.ReportProgress(1);
                        //INICIA NUEVO PROCESO        
                        this.eProcesoActual = "...";
                    }
                }

            }

        }

        public void EnviarCorreo(MovimientoOCCabeEN movCabe, ParametroEN pPar)
        {

            MailMessage pEmail = new MailMessage();
            //pEmail.To.Add(new MailAddress(pCuo.EmailCliente));
            pEmail.To.Add(movCabe.CorreoAuxiliar.Replace(";", ","));
            pEmail.From = new MailAddress(pPar.CorreoEnvio);
            pEmail.Subject = "Orden de Servicio " + movCabe.PeriodoMovimientoCabe;
            pEmail.Body = "";
            pEmail.IsBodyHtml = false;
            pEmail.Priority = MailPriority.Normal;

            //obtener la ruta del pdf recibo
            //string iRutaRecibo = wGenerarRecibos.ObtenerNuevaRutaPDF(pCuo, pPar.RutaRecibos);
            string iRutaRecibo = pPar.RutaCarpetaPlantillas + @"\OrdenServicio_" + movCabe.ClaveMovimientoCabe + ".xlsx";
            Attachment data = new Attachment(iRutaRecibo);
            pEmail.Attachments.Add(data);

            SmtpClient pSmtp = new SmtpClient();
            pSmtp.Host = pPar.HostCorreoEnvio;//(live) parar hotmail
            pSmtp.Port = Conversion.AInt(pPar.PuertoCorreoEnvio, 0);//(25) para hotmail,587
            pSmtp.EnableSsl = true;
            pSmtp.UseDefaultCredentials = false;
            pSmtp.EnableSsl = true;
            pSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            pSmtp.Credentials = new NetworkCredential(pPar.CorreoEnvio, pPar.ClaveCorreoEnvio);
            try
            {
                pSmtp.Send(pEmail);
            }
            catch (Exception e)
            {
                Mensaje.OperacionDenegada(e.Message, "Error");
            }

        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                closePending = true;
                backgroundWorker1.CancelAsync();
                e.Cancel = true;
                this.Hide();
                return;
            }
            base.OnFormClosing(e);
        }

        private void wEnviarOrdenServicio_FormClosing(object sender, FormClosingEventArgs e)
        {

            //closePending = true;
            //backgroundWorker1.CancelAsync();
            //e.Cancel = true;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.EnviandoCorreos();
            this.eIncrementoBarra = 30;
            this.backgroundWorker1.ReportProgress(1);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lblProc.Text = this.eProcesoActual;
            this.progressBar1.Increment(this.eIncrementoBarra);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending)
            {
                Mensaje.OperacionSatisfactoria("Proceso completado", "Envio correo");
                this.Cerrar();
                closePending = false;
            }

        }
    }
}
