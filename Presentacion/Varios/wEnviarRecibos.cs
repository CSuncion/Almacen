using System;
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
using Negocio;
using Entidades;
using Presentacion.Principal;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.IO;
using System.Diagnostics;


namespace Presentacion.Varios
{
    public partial class wEnviarRecibos : Heredados.MiForm4
    {
        public wEnviarRecibos()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        string eTitulo = "Cuotas";
        string ePeriodo = string.Empty;
        int eIncrementoBarra = 0;
        string eProcesoActual = string.Empty;
        List<CuotaEN> eLisCuo = new List<CuotaEN>();

        #endregion
                     
        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtAno, true, "Año", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMes, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnEjecutar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMarcarTodos, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnDesmarcarTodos, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnVer, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnEnviar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvv");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General


        public void InicializaVentana()
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
         
            //llenar combos            
            this.CargarMes();

            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();         
            eMas.AccionHabilitarControles(0);       
            this.txtAno.Focus();
        }

        public void CargarMes()
        {
            Cmb.Cargar(this.cmbMes, ItemGRN.ListarItemsG("Mes"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void Ejecutar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }
        
            //actualizar grilla
            this.ActualizarDgvCuo();
        }

        public void ActualizarDgvCuo()
        {         
            CuotaEN iCuoEN = new CuotaEN();
            iCuoEN.AnoCuota = this.txtAno.Text.Trim();
            iCuoEN.CMesCuota = Cmb.ObtenerValor(cmbMes, "");
            iCuoEN.PeriodoCuota = iCuoEN.AnoCuota + "-" + iCuoEN.CMesCuota;
            iCuoEN.Adicionales.CampoOrden = CuotaEN.NumCon;
            List<CuotaEN> iLisCuo = CuotaRN.ListarCuotasXProyectoYPeriodo(iCuoEN);

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvCuo;
            iDgv.RefrescarDatosGrilla(iLisCuo);

            //asignar columnas          
            iDgv.AsignarColumnaCheckBox("Seleccionar", "Seleccionar", 75);
            iDgv.AsignarColumnaTextCadena(CuotaEN.NumCon, "Contrato", 55);
            iDgv.AsignarColumnaTextCadena(CuotaEN.NomCli, "Cliente", 200);
            iDgv.AsignarColumnaTextCadena(CuotaEN.EmaCli, "Correo", 180);
            iDgv.AsignarColumnaTextCadena(CuotaEN.FecVenCuo, "Fc.Vcto", 75);
            iDgv.AsignarColumnaTextNumerico(CuotaEN.MonCuo, "Monto", 80,2);
            iDgv.AsignarColumnaTextCadena(CuotaEN.NumRec, "Recibo", 60);
            iDgv.AsignarColumnaTextCadena(CuotaEN.EnvCorRec, "Enviado", 50);
            iDgv.AsignarColumnaTextCadena(CuotaEN.CodCon, "CodigoConcepto", 90, false);
            iDgv.AsignarColumnaTextCadena(CuotaEN.AnoCuo, "AñoCuota", 90, false);
            iDgv.AsignarColumnaTextCadena(CuotaEN.CMesCuo, "MesCuota", 90, false);
            iDgv.AsignarColumnaTextCadena(CuotaEN.ClaObj, "ClaveObjeto", 90, false);
        }

        public void Enviar()
        {
            //validar envio
            if (this.EsValidoEnvio() == false) { return; }

            //validar si todas las marcadas tienen correo
            if (this.EsValidaMarcadasConCorreoElectronico() == false) { return; }

            //validar que existan todos los pds de las cuotas selecionadas
            if (this.ExistenArchivosPdfs() == false) { return; }
            
            //validar si hay conexion a internet


            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //periodo
            ePeriodo = txtAno.Text + "-" + Cmb.ObtenerValor(cmbMes, "");

            //ejecutar el proceso
            this.Enabled = false;
            this.progressBar1.Value = 0;
            this.eIncrementoBarra = 0;
            this.backgroundWorker1.RunWorkerAsync();
        }

        public bool EsValidoEnvio()
        {
            //valida la grilla vacia
            if (DgvCuo.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("no hay registros en la grilla", eTitulo);
                return false;
            }

            //validar cuotas marcadas
            List<int> iLisMar = Dgv.ListarIndicesMarcadosEnCheckBox(DgvCuo, "Seleccionar");
            if (iLisMar.Count == 0)
            {
                Mensaje.OperacionDenegada("Al menos debes chequear un registro", eTitulo);
                return false;
            }

            //ok
            return true;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteEnviarRecibo, null);
        }

        public void MarcarTodos()
        {
            //si la grilla no tiene registros
            if (this.DgvCuo.Rows.Count == 0)
            {
                MessageBox.Show("No hay cuotas que marcar", "Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //si hay registro
            for (int n = 0; n <= this.DgvCuo.Rows.Count - 1; n++)
            {
                this.DgvCuo.Rows[n].Cells["Seleccionar"].Value = true;
            }
        }

        public void DesmarcarTodos()
        {
            //si la grilla no tiene registros
            if (this.DgvCuo.Rows.Count == 0)
            {
                MessageBox.Show("No hay cuotas que desmarcar", "Cuotas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //si hay registro
            for (int n = 0; n <= this.DgvCuo.Rows.Count - 1; n++)
            {
                this.DgvCuo.Rows[n].Cells["Seleccionar"].Value = false;
            }
        }

        public void EnviandoCorreos()
        {
            this.eIncrementoBarra = 0;
            this.eProcesoActual = "Generando correos...";

            //variables
            ParametroEN iParEN = ParametroRN.BuscarParametro();          
            int iNroObjetos = Dgv.ListarIndicesMarcadosEnCheckBox(this.DgvCuo, "Seleccionar").Count;
            if (iNroObjetos == 0)
            {
                eIncrementoBarra = 70;
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

                //traer todas las cuotas del proceso elegido
                CuotaEN iCuoEN = new CuotaEN();
                iCuoEN.PeriodoCuota = ePeriodo;
                iCuoEN.Adicionales.CampoOrden = CuotaEN.NumCon;
                List<CuotaEN> iLisCuo = CuotaRN.ListarCuotasXProyectoYPeriodo(iCuoEN);

                //recorrar cada objeto
                for (int n = 0; n <= this.DgvCuo.Rows.Count - 1; n++)
                {                   
                    //preguntar si esta chequeado
                    bool iValor = Convert.ToBoolean(this.DgvCuo["Seleccionar", n].Value);
                    if (iValor == true)
                    {
                        CuotaEN iCuoBusEN = new CuotaEN();
                        iCuoBusEN.ClaveCuota = this.DgvCuo.Rows[n].Cells[CuotaEN.ClaObj].Value.ToString();
                        iCuoBusEN = CuotaRN.BuscarCuotaXClave(iCuoBusEN, iLisCuo);

                        //generar su correo
                        this.EnviarCorreo(iCuoBusEN, iParEN); 

                        //actualizamos el objeto
                        iCuoBusEN.EnvioCorreoRecibo = "1";//enviado

                        //lo agregamos a la lista de modificacion masiva de cuotas
                        eLisCuo.Add(iCuoBusEN);

                        //aqui se va ejecutando cada objeto de la lista contrato
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
                            this.eProcesoActual = "Grabando Cuotas...";
                        }
                    }
                }
               
            }
        }

        public void EnviarCorreo(CuotaEN pCuo, ParametroEN pPar)
        {

            MailMessage pEmail = new MailMessage();
            //pEmail.To.Add(new MailAddress(pCuo.EmailCliente));
            pEmail.To.Add(pCuo.EmailCliente.Replace(";", ","));
            pEmail.From = new MailAddress(pPar.CorreoEnvio);
            pEmail.Subject = "Recibo del periodo " + pCuo.AnoCuota + "-" + pCuo.CMesCuota;
            pEmail.Body = "";
            pEmail.IsBodyHtml = false;
            pEmail.Priority = MailPriority.Normal;

            //obtener la ruta del pdf recibo
            //string iRutaRecibo = wGenerarRecibos.ObtenerNuevaRutaPDF(pCuo, pPar.RutaRecibos);
            string iRutaRecibo = "\\Rec" + pCuo.NumeroContrato + pCuo.AnoCuota + pCuo.CMesCuota + ".pdf";
            Attachment data = new Attachment(iRutaRecibo);
            pEmail.Attachments.Add(data);

            SmtpClient pSmtp = new SmtpClient();
            pSmtp.Host = pPar.HostCorreoEnvio;//(live) parar hotmail
            pSmtp.Port = Conversion.AInt(pPar.PuertoCorreoEnvio, 0);//(25) para hotmail,587
            pSmtp.EnableSsl = true;
            pSmtp.UseDefaultCredentials = false;
            pSmtp.EnableSsl = true;
            pSmtp.Credentials = new NetworkCredential(pPar.CorreoEnvio, pPar.ClaveCorreoEnvio);
            
            pSmtp.Send(pEmail);

        }

        public void ModificarCuotas()
        {
            //INCREMENTAMOS EL PROCESO
            this.eIncrementoBarra = 30;
            this.backgroundWorker1.ReportProgress(1);

            //modificar las cuotas masivamente
            CuotaRN.ModificarCuota(eLisCuo);
        }

        public void Ver()
        { 
            //validar para ver pdf
            if (this.EsValidoVerPdf() == false) { return; }
        
            //validar si existe el archivo pdf
            if (this.ExisteArchivoPdf() == false) { return; }

            //ver pdf seleccionado
            this.VerPdf();
        }

        public bool EsValidoVerPdf()
        {
            //valida la grilla vacia
            if (DgvCuo.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("no hay registros en la grilla", eTitulo);
                return false;
            }

            //validar cuotas marcadas
            List<int> iLisMar = Dgv.ListarIndicesMarcadosEnCheckBox(DgvCuo, "Seleccionar");
            if (iLisMar.Count != 1)
            {
                Mensaje.OperacionDenegada("Solo debes chequear un registro", eTitulo);
                return false;
            }

            //ok
            return true;
        }

        public bool ExisteArchivoPdf()
        {
            //obtener a la cuota marcada
            CuotaEN iCuoEN = this.ListarCuotasMarcadasDeGrilla()[0];

            //obtener la ruta de la carpeta para el periodo elegido
            string iRutaCarpetaPeriodo = "RutaPeriodo"; //wGenerarRecibos.ObtenerRutaCarpetaPeriodo(txtAno.Text, Cmb.ObtenerValor(cmbMes, ""));


            //armar la ruta de su archivo
            string iRutaArchivo = "RutaArchivo"; //wGenerarRecibos.ObtenerNuevaRutaPDF(iCuoEN, iRutaCarpetaPeriodo);

            //ver si existe este archivo
            if (File.Exists(iRutaArchivo) == false)
            {
                Mensaje.OperacionDenegada("El archivo no existe " + iRutaArchivo, "Pdf");
                return false;
            }
            return true;
        }

        public List<CuotaEN> ListarCuotasMarcadasDeGrilla()
        { 
            //lista resultado
            List<CuotaEN> iLisRes = new List<CuotaEN>();

            //listar los indices de todos los registros marcados
            List<int> iLisIndMar = Dgv.ListarIndicesMarcadosEnCheckBox(DgvCuo, "Seleccionar");

            //recorrer cada indice
            foreach (int xIndiceFila in iLisIndMar)
            {
                //crear un nuevo objeto
                CuotaEN iCuoEN = new CuotaEN();
                iCuoEN.NumeroContrato = DgvCuo.Rows[xIndiceFila].Cells[CuotaEN.NumCon].Value.ToString();
                iCuoEN.CodigoConcepto = DgvCuo.Rows[xIndiceFila].Cells[CuotaEN.CodCon].Value.ToString();
                iCuoEN.AnoCuota = DgvCuo.Rows[xIndiceFila].Cells[CuotaEN.AnoCuo].Value.ToString();
                iCuoEN.CMesCuota = DgvCuo.Rows[xIndiceFila].Cells[CuotaEN.CMesCuo].Value.ToString();
                
                //agregamos a la lista resultado
                iLisRes.Add(iCuoEN);
            }
        
            //devolver
            return iLisRes;
        }

        public void VerPdf()
        {
            //obtener a la cuota marcada
            CuotaEN iCuoEN = this.ListarCuotasMarcadasDeGrilla()[0];

            //obtener la ruta de la carpeta para el periodo elegido
            string iRutaCarpetaPeriodo = "RutaCarpetaPeriodo"; //wGenerarRecibos.ObtenerRutaCarpetaPeriodo(txtAno.Text, Cmb.ObtenerValor(cmbMes, ""));

            //armar la ruta de su archivo
            string iRutaArchivo = "RutaArchivo";  //wGenerarRecibos.ObtenerNuevaRutaPDF(iCuoEN, iRutaCarpetaPeriodo);

            //ejecutar
            Process.Start(iRutaArchivo);
        }

        public bool ExistenArchivosPdfs()
        {
            //obtener a las cuotas marcadas
            List< CuotaEN> iLisCuoMar = this.ListarCuotasMarcadasDeGrilla();

            //obtener la ruta de la carpeta para el periodo elegido
            string iRutaCarpetaPeriodo = "RutaCarpetaPeriodo"; //wGenerarRecibos.ObtenerRutaCarpetaPeriodo(txtAno.Text, Cmb.ObtenerValor(cmbMes, ""));

            //recorrer cada objeto cuota
            foreach (CuotaEN xCuo in iLisCuoMar)
            {
                //armar la ruta de su archivo
                string iRutaArchivo = "RutaArchivo";  //wGenerarRecibos.ObtenerNuevaRutaPDF(xCuo, iRutaCarpetaPeriodo);

                //ver si existe este archivo
                if (File.Exists(iRutaArchivo) == false)
                {
                    Mensaje.OperacionDenegada("El(los) archivo(s) no existe(n)", "Pdf");
                    return false;
                }                
            }
            
            //ok
            return true;
        }

        public bool EsValidaMarcadasConCorreoElectronico()
        {
            //recorrer cada registro
            for (int n = 0; n <= this.DgvCuo.Rows.Count - 1; n++)
            {
                //preguntar si esta chequeado
                bool iValor = Convert.ToBoolean(this.DgvCuo["Seleccionar", n].Value);
                if (iValor == true)
                {
                    string iCorreo = this.DgvCuo[LoteEN.EmaCli, n].Value.ToString().Trim();
                    if (iCorreo == string.Empty)
                    {
                        Mensaje.OperacionDenegada("Hay propietarios que no tienen correo electronico", "Contrato");
                        return false;
                    }
                }
            }

            //ok          
            return true;
        }

        #endregion

        private void wEnviarRecibos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            this.Ejecutar();
        }

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            this.MarcarTodos();
        }

        private void btnDesmarcarTodos_Click(object sender, EventArgs e)
        {
            this.DesmarcarTodos();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.EnviandoCorreos();
            this.ModificarCuotas();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Increment(this.eIncrementoBarra);
            this.lblProc.Text = this.eProcesoActual;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mensaje.OperacionSatisfactoria("Proceso completado", "Envio correo");
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            this.Enviar();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            this.Ver();
        }

      

    }
}
