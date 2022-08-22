using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades.Adicionales;
using WinControles;
using Entidades;
using Negocio;
using WinControles.ControlesWindows;
using Comun;
using Presentacion.Listas;
using System.IO;
using Presentacion.Principal;
using Presentacion.FuncionesGenericas;

namespace Presentacion.Sistema
{
    public partial class wParametroEmpresa : Heredados.MiForm8
    {
        public wParametroEmpresa()
        {
            InitializeComponent( );
        }

        //variables      
        Masivo eMas = new Masivo( );
          
        #region Propietario

        public wEmpresa wEmp;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;
            
            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnCancelar , "vvvv" );
            xLis.Add( xCtrl );

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana()
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //deshabilitar propietario
            this.wEmp.Enabled = false;

            //ver
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarParametroEmpresa();
            this.btnAgregar.Focus();
        }

        public void MostrarParametroEmpresa()
        {
            EmpresaEN iEmpEN = new EmpresaEN();
            iEmpEN.CodigoEmpresa = Dgv.ObtenerValorCelda(wEmp.DgvEmp, EmpresaEN.CodEmp);
            iEmpEN = EmpresaRN.BuscarEmpresaXCodigo(iEmpEN);

            //mostar datos            
            this.pbImaLog.ImageLocation = iEmpEN.LogoEmpresa;
            this.lblRutLog.Text = iEmpEN.LogoEmpresa;
        }

        public void MensajeDeConfirmacion()
        {
            MessageBox.Show("El parametro se modifico Correctamente", "Parametro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ModificarCampo(string pCampo, string pValor)
        {
            string iCodigoEmpresa = Dgv.ObtenerValorCelda(wEmp.DgvEmp, EmpresaEN.CodEmp);
            EmpresaRN.ModificarCampoParametro(pCampo, pValor, iCodigoEmpresa);
            this.MensajeDeConfirmacion();
        }

        public void BuscarImagenLogo()
        {
            
        }

       #endregion


        private void btnCancelar_Click( object sender , EventArgs e )
        {
            this.Close( );
        }

        private void wParametroEmpresa_FormClosing( object sender , FormClosingEventArgs e )
        {
            this.wEmp.Enabled = true;
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.BuscarImagenLogo();
        }

        private void btnActLogEmp_Click(object sender, EventArgs e)
        {
            this.ModificarCampo(EmpresaEN.LogEmp, this.lblRutLog.Text);
        }

      

      
    }
}
