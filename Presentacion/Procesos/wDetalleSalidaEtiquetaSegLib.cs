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

namespace Presentacion.Procesos
{
    public partial class wDetalleSalidaEtiquetaSegLib : Heredados.MiForm8
    {
        public wDetalleSalidaEtiquetaSegLib()
        {
            InitializeComponent( );
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();       
        string eTitulo = "Item";
        public string eDetalleMotivoDesmedro = string.Empty;

        #endregion
        
        #region Propietario

        public wSalidaEtiquetaSegundaLiberacion wSalEtiSegLib;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodExi, this.txtCanEti, "ffff");
            xLis.Add(xCtrl);
           
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCanEti, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanFor, this.txtCanEti, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanEti, true, "Cantidad", "vvff", 0, 12);
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
            this.wSalEtiSegLib.Enabled = false;

            //ver ventana
            this.Show( );
        }

        public void VentanaModificar( ProduccionExisEN pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarProduccionExis( pObj );             
            eMas.AccionHabilitarControles( 1 );         
            eMas.AccionPasarTextoPrincipal();
            this.txtCanEti.Focus();
        }
        
        public void VentanaEliminar( ProduccionExisEN pObj )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Eliminar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarProduccionExis(pObj);           
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(ProduccionExisEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Visualizar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarProduccionExis(pObj);
            eMas.AccionHabilitarControles(3);
            eMas.AccionPasarTextoPrincipal();
            this.btnCancelar.Focus();
        }

        public void AsignarProduccionExis(ProduccionExisEN pObj)
        {           
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();            
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.CantidadProduccionExis = Conversion.ADecimal(this.txtCanFor.Text, 0);
            pObj.CantidadSegundaLiberacion = Conversion.ADecimal(this.txtCanEti.Text, 0);
            //pObj.DetalleMotivoDesmedro = this.eDetalleMotivoDesmedro;         
            //pObj.ClaveRetiquetado = this.wIngDesEnv.ObtenerClaveRetiquetado();
        }

        public void MostrarProduccionExis( ProduccionExisEN pObj )
        {       
            this.txtCodExi.Text = pObj.CodigoExistencia;            
            this.txtDesExi.Text = pObj.DescripcionExistencia;   
            this.txtCanFor.Text= Formato.NumeroDecimal(pObj.CantidadProduccionExis, 2);
            this.txtCanEti.Text = Formato.NumeroDecimal(pObj.CantidadSegundaLiberacion.ToString(), 0);
            //this.eDetalleMotivoDesmedro = pObj.DetalleMotivoDesmedro;                    
        }
               
        public void Aceptar( )
        {
            switch ( this.eOperacion )
            {                
                case Universal.Opera.Modificar: { this.Modificar( ); break; }
                case Universal.Opera.Eliminar: { this.Eliminar( ); break; }
                default: break;
            }
        }

        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }
            
            //modificar detalle
            this.ModificarProduccionExis();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wSalEtiSegLib.eClaveDgvRetProTer = Dgv.ObtenerValorCelda(this.wSalEtiSegLib.dgvProExi, ProduccionExisEN.ClaObj);
            this.wSalEtiSegLib.MostrarProduccionExis( );
            
            //salir de la ventana
            this.Close( );

        }

        public void ModificarProduccionExis()
        {
            //obtener el objeto de la lista
            ProduccionExisEN iProExiEN = ListaG.Buscar<ProduccionExisEN>(this.wSalEtiSegLib.eLisProExi, ProduccionExisEN.ClaObj,
                Dgv.ObtenerValorCelda(this.wSalEtiSegLib.dgvProExi, ProduccionExisEN.ClaObj));
            this.AsignarProduccionExis(iProExiEN);

            //modificar el objeto en la lista
            ListaG.Modificar<ProduccionExisEN>(this.wSalEtiSegLib.eLisProExi, iProExiEN, ProduccionExisEN.ClaObj, iProExiEN.ClaveObjeto);
        }
              
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarProduccionExis( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //actualizar propietario
            this.wSalEtiSegLib.MostrarProduccionExis( );
            
            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarProduccionExis()
        {
            //obtener el objeto de la lista
            ProduccionExisEN iProExiEN = ListaG.Buscar<ProduccionExisEN>(this.wSalEtiSegLib.eLisProExi, ProduccionExisEN.ClaObj,
                Dgv.ObtenerValorCelda(this.wSalEtiSegLib.dgvProExi, ProduccionExisEN.ClaObj));

            //actualizar datos
            iProExiEN.CEstadoSegundaLiberacion = "0";//desactivar
            iProExiEN.CantidadSegundaLiberacion = 0;
            
            //modificar el objeto en la lista
            ListaG.Modificar<ProduccionExisEN>(this.wSalEtiSegLib.eLisProExi, iProExiEN, ProduccionExisEN.ClaObj, iProExiEN.ClaveObjeto);
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

        private void wDetalleSalidaEtiquetaSegLib_FormClosing(object sender, FormClosingEventArgs e)
        {           
            this.wSalEtiSegLib.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }
              
        private void txtCanDes_Validated(object sender, EventArgs e)
        {
           
        }
        
    }
}
