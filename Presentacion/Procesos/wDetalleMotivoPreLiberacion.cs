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
    public partial class wDetalleMotivoPreLiberacion : Heredados.MiForm8
    {
        public wDetalleMotivoPreLiberacion()
        {
            InitializeComponent( );
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();       
        string eTitulo = "Item";
        public string eLiberacionProTer = string.Empty;

        #endregion
        
        #region Propietario

        public wMotivoPreLiberacion wMotPreLib;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodMotLib, true, "Motivo", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesMotLib, this.txtCodMotLib, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanMotLib, true, "Cantidad", "vvff", 0, 12);
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
            this.wMotPreLib.Enabled = false;

            //ver ventana
            this.Show( );
        }

        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Adicionar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMotivoLiberacion( LiberacionRN.EnBlancoMotivoLiberacion() );
            this.MostrarCantidadSugerida();                     
            eMas.AccionHabilitarControles( 0 );           
            eMas.AccionPasarTextoPrincipal();                          
            this.txtCodMotLib.Focus();
        }
        
        public void VentanaModificar( MotivoLiberacion pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMotivoLiberacion( pObj );             
            eMas.AccionHabilitarControles( 1 );         
            eMas.AccionPasarTextoPrincipal();
            this.txtCanMotLib.Focus();
        }
        
        public void VentanaEliminar( MotivoLiberacion pObj )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Eliminar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMotivoLiberacion(pObj);           
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void AsignarMotivoLiberacion(MotivoLiberacion pObj)
        {
            pObj.TipoMotivoLiberacion = this.wMotPreLib.eTipoMotivo;           
            pObj.CodigoMotivoLiberacion = this.txtCodMotLib.Text.Trim();
            pObj.DescripcionMotivoLiberacion = this.txtDesMotLib.Text.Trim();            
            pObj.CantidadMotivoLiberacion = Conversion.ADecimal(this.txtCanMotLib.Text, 0);
            pObj.ClaveMotivoLiberacion = LiberacionRN.ObtenerClaveMotivoLiberacion(pObj);
            pObj.ClaveObjeto = pObj.ClaveMotivoLiberacion;             

        }

        public void MostrarMotivoLiberacion( MotivoLiberacion pObj )
        {            
            this.txtCodMotLib.Text = pObj.CodigoMotivoLiberacion;
            this.txtDesMotLib.Text = pObj.DescripcionMotivoLiberacion;               
            this.txtCanMotLib.Text = Formato.NumeroDecimal(pObj.CantidadMotivoLiberacion.ToString(), 0);                          
        }
               
        public void Aceptar( )
        {
            switch ( this.eOperacion )
            {
                case Universal.Opera.Adicionar: { this.Adicionar( ); break; }
                case Universal.Opera.Modificar: { this.Modificar( ); break; }
                case Universal.Opera.Eliminar: { this.Eliminar( ); break; }
                default: break;
            }
        }

        public void Adicionar( )
        {
            //validar los campos obligatorios
            if ( eMas.CamposObligatorios( ) == false ) { return; }
                        
            //adicionar RetiquetadoProTer
            this.AdicionarMotivoLiberacion( );
                        
            //actualizar el campo detalle
            this.ActualizarCampoDetalleMotivo();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se adiciono el registro" , "Detalle" );

            //actualizar propietario
            this.wMotPreLib.eClaveDgvMotLib = this.wMotPreLib.eLisMotLib[this.wMotPreLib.eLisMotLib.Count - 1].ClaveObjeto;
            this.wMotPreLib.ActualizarDgvMot( );
            this.wMotPreLib.MostrarCantidadTotal();
            
            //limpiar controles
            eMas.AccionHabilitarControles(0);
            this.MostrarMotivoLiberacion( LiberacionRN.EnBlancoMotivoLiberacion() );
            this.MostrarCantidadSugerida();
            eMas.AccionPasarTextoPrincipal( );            
            this.txtCodMotLib.Focus( );                       
        }
        
        public void AdicionarMotivoLiberacion()
        {         
            MotivoLiberacion iMotLibEN = new MotivoLiberacion( );
            this.AsignarMotivoLiberacion(iMotLibEN);
            
            //adicionar detalle
            this.wMotPreLib.eLisMotLib.Add(iMotLibEN); 
        }

        public void ActualizarCampoDetalleMotivo()
        {
            //asignar parametro
            string iCampoDetalleMotivo = LiberacionRN.ConvertirListaACampoDetalleMotivo(this.wMotPreLib.eLisMotLib);

            //ejecutar metodo(segun tipoMotivo)
            switch (this.wMotPreLib.eTipoMotivo)
            {
                //case "MotMue": this.wMotPreLib.wPreLib.eLibMotEN.DetalleMotivoReproceso = iCampoDetalleMotivo; break;
                //case "MotCMu": this.wMotPreLib.wPreLib.eLibMotEN.DetalleMotivoMuestra = iCampoDetalleMotivo; break;
                //case "MotObs": this.wMotPreLib.wPreLib.eLibMotEN.DetalleMotivoDesecho = iCampoDetalleMotivo; break;
            }
        }

        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }
                       
            //modificar detalle
            this.ModificarMotivoLiberacion();

            //actualizar el campo detalle
            this.ActualizarCampoDetalleMotivo();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wMotPreLib.eClaveDgvMotLib = this.wMotPreLib.eLisMotLib[Dgv.ObtenerIndiceRegistroXFranja(this.wMotPreLib.DgvBot)].ClaveObjeto;
            this.wMotPreLib.ActualizarDgvMot( );
            this.wMotPreLib.MostrarCantidadTotal();

            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarMotivoLiberacion()
        {
            //obtener el objeto de la lista
            MotivoLiberacion iProProTerEN = this.wMotPreLib.eLisMotLib[Dgv.ObtenerIndiceRegistroXFranja(this.wMotPreLib.DgvBot)];
            this.AsignarMotivoLiberacion(iProProTerEN);
            
            //modificar el objeto en la lista
            ListaG.Modificar<MotivoLiberacion>(this.wMotPreLib.eLisMotLib, iProProTerEN, MotivoLiberacion.CodMotLib, iProProTerEN.CodigoMotivoLiberacion);            
        }
              
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarMotivoLiberacion( );

            //actualizar el campo detalle
            this.ActualizarCampoDetalleMotivo();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //mostra detalle comprobante           
            this.wMotPreLib.ActualizarDgvMot( );
            this.wMotPreLib.MostrarCantidadTotal();

            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarMotivoLiberacion()
        {
            this.wMotPreLib.eLisMotLib.RemoveAt( Dgv.ObtenerIndiceRegistroXFranja( this.wMotPreLib.DgvBot ) );
        }
      
        public ItemGEN NuevoItemGVentana()
        {
            //asignar parameros
            ItemGEN iIteGEN = new ItemGEN();
            iIteGEN.CodigoTabla = this.wMotPreLib.eTipoMotivo;
            iIteGEN.CodigoItemG = this.txtCodMotLib.Text.Trim();
            iIteGEN.ClaveItemG = ItemGRN.ObtenerClaveItemG(iIteGEN);

            //devolver
            return iIteGEN;
        }

        public bool ValidaCantidadUnidades()
        {
            decimal iValor = Conversion.ADecimal(this.txtCanMotLib.Text, 0);
            if (iValor == 0)
            {
                Mensaje.OperacionDenegada("La cantidad de unidades no puede ser cero", "Cantidad");
                return false;
            }
            return true;
        }

        public bool EsMotivoValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodMotLib.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ItemGEN iIteGEN = this.NuevoItemGVentana();
            string iCodigoItemGFranjaGrilla = Dgv.ObtenerValorCelda(this.wMotPreLib.DgvBot, MotivoLiberacion.CodMotLib);
            List<MotivoLiberacion> iLisMotLibGrilla = this.wMotPreLib.eLisMotLib;
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iIteGEN = ItemGRN.EsItemGActivoValido(iIteGEN, iOperacionVentana, iCodigoItemGFranjaGrilla, iLisMotLibGrilla);
            if (iIteGEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIteGEN.Adicionales.Mensaje, "Motivo");
                this.txtCodMotLib.Focus();
            }

            //pasar datos
            this.txtCodMotLib.Text = iIteGEN.CodigoItemG;
            this.txtDesMotLib.Text = iIteGEN.NombreItemG;
            
            //devolver
            return iIteGEN.Adicionales.EsVerdad;
        }

        public void ListarMotivos()
        {
            //solo si el control no esta de solo lectura
            if (this.txtCodMotLib.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Motivos";
            win.eCtrlValor = this.txtCodMotLib;
            win.eCtrlFoco = this.txtCanMotLib;
            win.eIteEN.CodigoTabla = this.wMotPreLib.eTipoMotivo;
            win.eLisMotLib = this.wMotPreLib.eLisMotLib;
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTablaNoSeleccionadasEnGrillaMotivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void MostrarCantidadSugerida()
        {
            //asignar parametros
            decimal iCantidadTipoMotivo = this.wMotPreLib.eCantidadMotivo;
            List<MotivoLiberacion> iLisMotLib = this.wMotPreLib.eLisMotLib;

            //ejecutar metodo
            decimal iCantidadSugerida = LiberacionRN.CantidadMotivoLiberacionSugerida(iCantidadTipoMotivo, iLisMotLib);

            //mostrar en pantalla
            this.txtCanMotLib.Text = Formato.NumeroDecimal(iCantidadSugerida, 0);
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

        private void wDetalleMotivoLiberacion_FormClosing(object sender, FormClosingEventArgs e)
        {           
            this.wMotPreLib.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarMotivos(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarMotivos();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsMotivoValido();
        }
     
        private void txtCanUniProTer_Validated(object sender, EventArgs e)
        {
           
        }
        
       
    }
}
