using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Entidades.Adicionales;
using WinControles.ControlesWindows;
using Entidades;
using Negocio;
using Comun;
using Presentacion.Listas;
using Presentacion.Procesos;
using Presentacion.FuncionesGenericas;
using Presentacion.Consultas;
using Entidades.Estructuras;

namespace Presentacion.Procesos
{
    public partial class wCambiarFcLote : Heredados.MiForm8
    {
        public wCambiarFcLote()
        {
            InitializeComponent( );
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();       
        string eTitulo = "Fecha Lote";
       
        #endregion
        
        #region Propietario

        public wProduccionesEncajar wProEnc;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;
            
            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecLotProTer, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtFecVenProTer, this.dtpFecLotProTer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnAceptar , "vvvf" );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnCancelar , "vvvv" );
            xLis.Add( xCtrl );

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana( )
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls( );
            eMas.EjecutarTodosLosEventos( );
            
            //deshabilita propietario
            this.wProEnc.Enabled = false;

            //ver ventana
            this.Show( );
        }

        public void VentanaModificar(LiberacionProTer pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarLiberacionProTer( pObj );             
            eMas.AccionHabilitarControles( 1 );         
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecLotProTer.Focus();
        }
        
        public void AsignarLiberacionProTer(LiberacionProTer pObj)
        {
            pObj.FechaLote = Fecha.ObtenerDiaMesAno(this.dtpFecLotProTer.Text);
            pObj.FechaVcto = this.txtFecVenProTer.Text.Trim();
            pObj.ClaveLiberacion = Dgv.ObtenerValorCelda(this.wProEnc.dgvLibProTer, LiberacionProTer.ClaLib);         
        }

        public void MostrarLiberacionProTer(LiberacionProTer pObj )
        {            
            this.dtpFecLotProTer.Text = pObj.FechaLote;
            this.txtFecVenProTer.Text = pObj.FechaVcto;            
        }
               
        public void Aceptar( )
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //modificar detalle
            this.ModificarLiberacionProTer();

            //volver armar el campo detalle
            this.wProEnc.ArmarCampoDetalleLiberacionProTer();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se modifico el registro", "Detalle");

            //Actualizar propietario
            this.wProEnc.eClaveDgvLibProTer = this.wProEnc.eLisLibProTer[Dgv.ObtenerIndiceRegistroXFranja(this.wProEnc.dgvLibProTer)].ClaveLiberacion;
            this.wProEnc.ActualizarDgvLibProTer();

            //salir de la ventana
            this.Close();
        }

        public void ModificarLiberacionProTer()
        {           
            this.AsignarLiberacionProTer( this.wProEnc.eLisLibProTer[Dgv.ObtenerIndiceRegistroXFranja( this.wProEnc.dgvLibProTer )] );
        }
     
        public void MostrarFechaVcto()
        {
            //asignar parametros
            LiberacionProTer iLibProTer = this.NuevaLiberacionProTerVentana();
            int iNumeroDiasVcto = FormulaDetaRN.ObtenerNumeroDiasVcto(this.wProEnc.wDetEnc.NuevaProduccionProTerVentana());

            //ejecutar metodo
            string iFecha = LiberacionRN.ObtenerFechaVcto(iLibProTer, iNumeroDiasVcto);

            //mostrar en pantalla
            this.txtFecVenProTer.Text = iFecha;
        }

        public LiberacionProTer NuevaLiberacionProTerVentana()
        {
            //asignar parameros
            LiberacionProTer iLibProTer = new LiberacionProTer();
            this.AsignarLiberacionProTer(iLibProTer);

            //devolver
            return iLibProTer;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.eTitulo);
        }

        #endregion


        private void btnCancelar_Click( object sender , EventArgs e )
        {
            this.Cancelar( );
        }

        private void wCambiarFcLote_FormClosing(object sender, FormClosingEventArgs e)
        {           
            this.wProEnc.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }
               
        private void dtpFecLotProTer_Validated(object sender, EventArgs e)
        {
            this.MostrarFechaVcto();
        }

    }
}
