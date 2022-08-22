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
    public partial class wEditLoteRetiquetado : Heredados.MiForm8
    {
        public wEditLoteRetiquetado()
        {
            InitializeComponent( );
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();       
        string eTitulo = "Item";
        public string eLoteRetiquetado = string.Empty;

        #endregion
        
        #region Propietario

        public wLoteRetiquetado wLotRet;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;
                        
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtClaLib, true, "Existencia", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCorProCab, this.txtClaLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtFecProDet, this.txtClaLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtFecLot, this.txtClaLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtFecVen, this.txtClaLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPreUni, this.txtClaLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanUni, true, "Cantidad", "vvff", 0, 12);
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
            this.wLotRet.Enabled = false;

            //ver ventana
            this.Show( );
        }

        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Adicionar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarLoteRetiquetado( ObjetoG.EnBlanco<LoteRetiquetado>() );                       
            eMas.AccionHabilitarControles( 0 );           
            eMas.AccionPasarTextoPrincipal();                          
            this.txtClaLib.Focus();
        }
        
        public void VentanaModificar( LoteRetiquetado pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarLoteRetiquetado( pObj );             
            eMas.AccionHabilitarControles( 1 );         
            eMas.AccionPasarTextoPrincipal();
            this.txtCanUni.Focus();
        }
        
        public void VentanaEliminar( LoteRetiquetado pObj )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Eliminar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarLoteRetiquetado(pObj);           
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void AsignarLoteRetiquetado(LoteRetiquetado pObj)
        {
            pObj.ClaveLiberacion = this.txtClaLib.Text.Trim();
            pObj.CorrelativoProduccionCabe = this.txtCorProCab.Text.Trim();
            pObj.FechaProduccionDeta = this.txtFecProDet.Text.Trim();
            pObj.FechaLote = this.txtFecLot.Text.Trim();
            pObj.FechaVcto = this.txtFecVen.Text.Trim();
            pObj.CostoTotalProducto = Conversion.ADecimal( this.txtPreUni.Text,0);
            pObj.Cantidad = Conversion.ADecimal(this.txtCanUni.Text, 0);            
        }

        public void MostrarLoteRetiquetado( LoteRetiquetado pObj )
        {
            this.txtClaLib.Text = pObj.ClaveLiberacion;
            this.txtCorProCab.Text = pObj.CorrelativoProduccionCabe;
            this.txtFecProDet.Text = pObj.FechaProduccionDeta;
            this.txtFecLot.Text = pObj.FechaLote;
            this.txtFecVen.Text = pObj.FechaVcto;
            this.txtPreUni.Text = Formato.NumeroDecimal(pObj.CostoTotalProducto, 2);
            this.txtCanUni.Text = Formato.NumeroDecimal(pObj.Cantidad, 0);                                    
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
                        
            //adicionar LoteRetiquetado
            this.AdicionarLoteRetiquetado( );
            
            //mensaje
            Mensaje.OperacionSatisfactoria( "Se adiciono el registro" , "Detalle" );

            //actualizar propietario
            this.wLotRet.eClaveDgvRetProTer = this.txtClaLib.Text;
            this.wLotRet.ActualizarDgvLibProTer( );
            this.MostrarCantidadTotal();
            this.ArmarCampoDetalleLoteRetiquetado();
            
            //limpiar controles
            eMas.AccionHabilitarControles(0);
            this.MostrarLoteRetiquetado(ObjetoG.EnBlanco<LoteRetiquetado>());                 
            eMas.AccionPasarTextoPrincipal( );            
            this.txtClaLib.Focus( );                       
        }
        
        public void AdicionarLoteRetiquetado()
        {         
            LoteRetiquetado iLotRet = new LoteRetiquetado( );
            this.AsignarLoteRetiquetado(iLotRet);

            //adicionar detalle
            RetiquetadoProTerRN.AdicionarLoteRetiquetado(this.wLotRet.eLisLotRet, iLotRet); 
        }

        public void ArmarCampoDetalleLoteRetiquetado()
        {
            //ejecutar metodo
            this.wLotRet.wDetRet.eLoteRetiquetado = RetiquetadoProTerRN.ConvertirListaACampoDetalleCantidadesLote(this.wLotRet.eLisLotRet);
        }

        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }

            //valida cantidad de unidades
            //if (this.ValidaCantidadUnidades() == false) { return; }

            //modificar detalle
            this.ModificarLoteRetiquetado();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wLotRet.eClaveDgvRetProTer = this.txtClaLib.Text;
            this.wLotRet.ActualizarDgvLibProTer( );
            this.MostrarCantidadTotal();
            this.ArmarCampoDetalleLoteRetiquetado();
           
            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarLoteRetiquetado()
        {
            //obtener el objeto de la lista
            LoteRetiquetado iLotRet = this.wLotRet.eLisLotRet[Dgv.ObtenerIndiceRegistroXFranja(this.wLotRet.dgvRetProTer)];
            this.AsignarLoteRetiquetado(iLotRet);
            
            //modificar el objeto en la lista
            ListaG.Modificar<LoteRetiquetado>(this.wLotRet.eLisLotRet, iLotRet, LoteRetiquetado.ClaLib, iLotRet.ClaveLiberacion);            
        }
              
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarLoteRetiquetado( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //actualizar propietario
            this.wLotRet.ActualizarDgvLibProTer( );
            this.MostrarCantidadTotal();
            this.ArmarCampoDetalleLoteRetiquetado();
            
            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarLoteRetiquetado()
        {
            this.wLotRet.eLisLotRet.RemoveAt( Dgv.ObtenerIndiceRegistroXFranja( this.wLotRet.dgvRetProTer ) );
        }

        public bool EsProduccionProTerValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtClaLib.ReadOnly == true) { return true; }

            //valor verdad
            bool iEsVerdad = true;

            //validar el numerocontrato del lote
            //asignar parametros
            List<LiberacionProTer> iLisLibProTerVal = RetiquetadoProTerRN.ListarLiberacionesProTerDiferentesDeLoteRetiquetado(this.wLotRet.eLisLibProTer,
                this.wLotRet.eLisLotRet);
            LiberacionProTer iLibProTer = ListaG.Buscar<LiberacionProTer>(iLisLibProTerVal, LiberacionProTer.ClaLib, this.txtClaLib.Text);
            if (iLibProTer.ClaveLiberacion == string.Empty && this.txtClaLib.Text != string.Empty)
            {
                Mensaje.OperacionDenegada("Esta Liberacion no existe", "Liberaciones");
                this.txtClaLib.Focus();
                iEsVerdad = false;
            }

            //mostrar datos
            this.txtClaLib.Text = iLibProTer.ClaveLiberacion;
            this.txtCorProCab.Text = LiberacionRN.ObtenerCorrelativoProduccionCabe(iLibProTer.ClaveLiberacion);
            this.txtFecProDet.Text = iLibProTer.FechaProduccionDeta;
            this.txtFecLot.Text = iLibProTer.FechaLote;
            this.txtFecVen.Text = iLibProTer.FechaVcto;           
            this.txtPreUni.Text = Formato.NumeroDecimal(iLibProTer.CostoTotalProducto, 2);
            
            //devolver
            return iEsVerdad;
        }

        public void ListarProduccionesProTer()
        {
            //solo si el control no esta de solo lectura
            if (this.txtClaLib.ReadOnly == true) { return; }

            //instanciar
            wLisLibProTer win = new wLisLibProTer();
            win.eVentana = this;
            win.eTituloVentana = "Liberaciones";
            win.eCtrlValor = this.txtClaLib;
            win.eCtrlFoco = this.txtCanUni;
            win.eLisLibProTer = this.wLotRet.eLisLibProTer;            
            win.eLisLotRet = this.wLotRet.eLisLotRet;
            win.eCondicionLista = Listas.wLisLibProTer.Condicion.LiberacionesProTerNoSeleccionadasEnGrillaLoteRetiquetado;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void MostrarCantidadTotal()
        {
            this.wLotRet.wDetRet.txtCanUniProTer.Text = ListaG.Sumar<LoteRetiquetado>(this.wLotRet.eLisLotRet, LoteRetiquetado.Can).ToString();
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

        private void wEditLoteRetiquetado_FormClosing(object sender, FormClosingEventArgs e)
        {           
            this.wLotRet.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarProduccionesProTer(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarProduccionesProTer();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsProduccionProTerValido();
        }
     
        private void txtCanUniProTer_Validated(object sender, EventArgs e)
        {
           
        }
        
       
    }
}
