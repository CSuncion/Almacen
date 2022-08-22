using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presentacion.Procesos;
using Entidades;
using Presentacion.Principal;
using Negocio;
using Comun;
using WinControles.ControlesWindows;
using WinControles;
using Entidades.Adicionales;
using Presentacion.Listas;
using System.IO;


namespace Presentacion.Varios
{
    public partial class wParametrosGenerales : Heredados.MiForm8
    {
        public wParametrosGenerales()
        {
            InitializeComponent();
        }

        //variables      
        Masivo eMas = new Masivo();
         
        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeTraIng, true, "Tip.Ope Transferencia Ingreso", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeTraSal, true, "Tip.Ope Transferencia Salida", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeProIng, true, "Tip.Ope Produccion Ingreso", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeProSal, true, "Tip.Ope Produccion Salida", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCenCosPro, true, "Centro Costo Produccion", "vvvv", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeIngAju, true, "Tip.Ope Ajuste Ingreso", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeSalAju, true, "Tip.Ope Ajuste Salida", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeDevPro, true, "Tip.Ope Ingreso Devolucion Produccion", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeSalNoPas, true, "Tip.Ope Salida Desechos", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeComMig, true, "Tip.Ope Compras", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeImpMig, true, "Tip.Ope Importaciones", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeIngMig, true, "Tip.Ope Ingreso", "vvvv", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtTipOpeSalMig, true, "Tip.Ope Salida", "vvvv", 3);
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
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarParametro();          
        }

        public void MostrarParametro()
        {
            //traemos al parametro de la b.d
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //mostar datos        
            this.txtRutLog.Text = iParEN.RutaLogoEmpresa;
            this.txtRutExi.Text = iParEN.RutaImagenExistencia;
            this.txtTipOpeTraIng.Text = iParEN.TipoOperacionTransferenciaIngreso;         
            this.txtTipOpeTraSal.Text = iParEN.TipoOperacionTransferenciaSalida;
            this.txtTipOpeProSal.Text = iParEN.TipoOperacionProduccionSalida;
            this.txtTipOpeProIng.Text = iParEN.TipoOperacionProduccionIngreso;
            this.txtCenCosPro.Text = iParEN.CentroCostoProduccion;
            this.txtTipOpeComMig.Text = iParEN.TipoOperacionCompraMigracion;
            this.txtTipOpeImpMig.Text = iParEN.TipoOperacionImportacionMigracion;
            this.txtTipOpeIngMig.Text = iParEN.TipoOperacionIngresoMigracion;
            this.txtTipOpeSalMig.Text = iParEN.TipoOperacionSalidaMigracion;
            this.txtTipOpeIngAju.Text = iParEN.TipoOperacionIngresoAjuste;
            this.txtTipOpeSalAju.Text = iParEN.TipoOperacionSalidaAjuste;
            this.txtTipOpeDevPro.Text = iParEN.TipoOperacionIngresoDevolucionProduccion;
            this.txtTipOpeSalNoPas.Text = iParEN.TipoOperacionSalidaNoPasan;
            this.txtCorEnv.Text = iParEN.CorreoEnvio;
            this.txtClaCorEnv.Text = iParEN.ClaveCorreoEnvio;
            this.txtHosCorEnv.Text = iParEN.HostCorreoEnvio;
            this.txtPueCorEnv.Text = iParEN.PuertoCorreoEnvio;
            this.txtRutCarPla.Text = iParEN.RutaCarpetaPlantillas;
        }

        public void SeleccionarUbicacion(TextBox pTextBox)
        {
            FolderBrowserDialog iBuscarRuta = new FolderBrowserDialog();
            if (iBuscarRuta.ShowDialog() == DialogResult.OK)
            {
                pTextBox.Text = iBuscarRuta.SelectedPath;
            }
        }

        //public void SeleccionarUbicacion(TextBox pTextBox)
        //{
        //    FolderBrowserDialog iBuscarRuta = new FolderBrowserDialog();
        //    if (iBuscarRuta.ShowDialog() == DialogResult.OK)
        //    {
        //        pTextBox.Text = iBuscarRuta.SelectedPath;
        //    }
        //}

        public void MensajeDeConfirmacion()
        {
            MessageBox.Show("El parametro se modifico Correctamente", "Parametro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ModificarCampo(string pCampo, string pValor)
        {
            ParametroRN.ModificarCampoParametro(pCampo, pValor);
            this.MensajeDeConfirmacion();
        }

        public void BuscarArchivoWord(TextBox pTextBox, string pRutaCarpetaDestino)
        {
            //llamar al cuadro de dialogo para buscar una imagen
            OpenFileDialog iBuscarImagen = new OpenFileDialog();
            iBuscarImagen.Filter = "Archivos de documentos word|*.docx";
            iBuscarImagen.FileName = string.Empty;
            iBuscarImagen.Title = "Buscar docuemnto word";
            iBuscarImagen.InitialDirectory = pRutaCarpetaDestino;

            if (iBuscarImagen.ShowDialog() == DialogResult.OK)
            {

                //informacion del archivo
                FileInfo info = new FileInfo(iBuscarImagen.FileName);
                string iNombreArchivo = info.Name;
                string iDirectorioOrigen = info.DirectoryName;
                string iOrigenArchivo = Path.Combine(iDirectorioOrigen, iNombreArchivo);
                string iDestinoArchivo = Path.Combine(pRutaCarpetaDestino, iNombreArchivo);
                if (pRutaCarpetaDestino != iDirectorioOrigen)
                {
                    File.Copy(iOrigenArchivo, iDestinoArchivo, true);
                }
                pTextBox.Text = iDestinoArchivo;
            }
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteParametros, null);
        }

   
        #endregion
            
        private void btnCancelar_Click(object sender, EventArgs e)
        {        
            this.Close( );
        }
        
        private void wParametrosGenerales_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();     
        }
              
        private void btnBusLog_Click(object sender, EventArgs e)
        {
            this.SeleccionarUbicacion(this.txtRutLog);
        }

        private void btnActRutLog_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.RutLogEmp, this.txtRutLog.Text);
        }

        private void btnTipOpeTraIng_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeTraIng, this.txtTipOpeTraIng.Text);
        }

        private void btnTipOpeTraSal_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeTraSal, this.txtTipOpeTraSal.Text);
        }

        private void btnTipOpeProSal_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeProSal, this.txtTipOpeProSal.Text);
        }

        private void btnTipOpeProIng_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeProIng, this.txtTipOpeProIng.Text);
        }

        private void btnCenCosPro_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.CenCosPro, this.txtCenCosPro.Text);
        }

        private void btnTipOpeComMig_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeComMig, this.txtTipOpeComMig.Text);
        }

        private void btnTipOpeIngMig_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeIngMig, this.txtTipOpeIngMig.Text);
        }

        private void btnTipOpeSalMig_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeSalMig, this.txtTipOpeSalMig.Text);
        }

        private void btnTipOpeIngAju_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeIngAju, this.txtTipOpeIngAju.Text);
        }

        private void btnTipOpeSalAju_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeSalAju, this.txtTipOpeSalAju.Text);
        }

        private void btnTipOpeImpMig_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeImpMig, this.txtTipOpeImpMig.Text);
        }

        private void btnBusExi_Click(object sender, EventArgs e)
        {
            this.SeleccionarUbicacion(this.txtRutExi);
        }

        private void btnActRutaExi_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.RutImaExi, this.txtRutExi.Text);
        }

        private void btnTipOpeDevPro_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeIngDevPro, this.txtTipOpeDevPro.Text);
        }

        private void btnTipOpeSalNoPas_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.TipOpeSalNoPas, this.txtTipOpeSalNoPas.Text);
        }

        private void btnActCorEnv_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.CorEnv, this.txtCorEnv.Text);
        }

        private void btnActClaCorEnv_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.ClaCorEnv, this.txtClaCorEnv.Text);
        }

        private void btnActHosCorEnv_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.HostCorEnv, this.txtHosCorEnv.Text);
        }

        private void btnActPueCorEnv_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.PueCorEnv, this.txtPueCorEnv.Text);
        }

        private void btnActPlaRec_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.RutPlaRec, this.txtRutPlaRec.Text);
        }

        private void btnActPlaEstCue_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.RutPlaEstCue, this.txtRutPlaEstCue.Text);
        }

        private void btnBusPlaRec_Click(object sender, EventArgs e)
        {
            this.BuscarArchivoWord(this.txtRutPlaRec, this.txtRutCarPla.Text);
        }

        private void btnBusPlaEstCue_Click(object sender, EventArgs e)
        {
            this.BuscarArchivoWord(this.txtRutPlaEstCue, this.txtRutCarPla.Text);
        }

        private void btnBusRutCarPla_Click(object sender, EventArgs e)
        {
            this.SeleccionarUbicacion(this.txtRutCarPla);
        }

        private void btnActRutCarPla_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(ParametroEN.RutCarPla, this.txtRutCarPla.Text);
        }
    }
}
