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
    public partial class wDetalleRetiquetado : Heredados.MiForm8
    {
        public wDetalleRetiquetado()
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

        public wEditRetiquetado wEditRet;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCorRetProTer, this.txtClaProProTer, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtClaProProTer, true, "Existencia", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtClaProProTer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPreUni, this.txtClaProProTer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanUniProTer, true, "Cantidad", "ffff", 0, 12);
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
            this.wEditRet.Enabled = false;

            //ver ventana
            this.Show( );
        }

        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Adicionar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarRetiquetadoProTer( RetiquetadoProTerRN.EnBlanco( ) );                       
            eMas.AccionHabilitarControles( 0 );           
            eMas.AccionPasarTextoPrincipal();                          
            this.txtClaProProTer.Focus();
        }
        
        public void VentanaModificar( RetiquetadoProTerEN pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarRetiquetadoProTer( pObj );             
            eMas.AccionHabilitarControles( 1 );         
            eMas.AccionPasarTextoPrincipal();
            this.txtCanUniProTer.Focus();
        }
        
        public void VentanaEliminar( RetiquetadoProTerEN pObj )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Eliminar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarRetiquetadoProTer(pObj);           
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void AsignarRetiquetadoProTer(RetiquetadoProTerEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CorrelativoRetiquetadoProTer = this.txtCorRetProTer.Text.Trim();         
            pObj.ClaveProduccionProTer = this.txtClaProProTer.Text.Trim();
            pObj.CorrelativoEncajado = this.txtCodEnc.Text.Trim();
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.CostoTotalProducto = Conversion.ADecimal(this.txtPreUni.Text, 0);
            pObj.DetalleCantidadesSemiproducto = this.txtDetCanSemPro.Text.Trim();
            pObj.CantidadRetiquetadoProTer = Conversion.ADecimal(this.txtCanUniProTer.Text, 0);            
            pObj.ClaveRetiquetado = this.wEditRet.ObtenerClaveRetiquetado();
            pObj.DetalleCantidadesLote = this.eLoteRetiquetado;
        }

        public void MostrarRetiquetadoProTer( RetiquetadoProTerEN pObj )
        {
            this.txtCorRetProTer.Text = pObj.CorrelativoRetiquetadoProTer;            
            this.txtClaProProTer.Text = pObj.ClaveProduccionProTer;
            this.txtCodEnc.Text = pObj.CorrelativoEncajado;
            this.txtDesExi.Text = pObj.DescripcionExistencia;   
            this.txtPreUni.Text= Formato.NumeroDecimal(pObj.CostoTotalProducto, 2);
            this.txtDetCanSemPro.Text = pObj.DetalleCantidadesSemiproducto;
            this.txtCanUniProTer.Text = Formato.NumeroDecimal(pObj.CantidadRetiquetadoProTer.ToString(), 0);
            this.eLoteRetiquetado = pObj.DetalleCantidadesLote;                  
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
            this.AdicionarRetiquetadoProTer( );
            
            //mensaje
            Mensaje.OperacionSatisfactoria( "Se adiciono el registro" , "Detalle" );

            //actualizar propietario
            this.wEditRet.eClaveDgvRetProTer = this.wEditRet.eLisRetProTer[this.wEditRet.eLisRetProTer.Count - 1].ClaveObjeto;
            this.wEditRet.MostrarRetiquetadosProTer( );
            this.wEditRet.MostrarUnidadesRE();
            this.wEditRet.MostrarCantidadCajasRE();

            //limpiar controles
            eMas.AccionHabilitarControles(0);
            this.MostrarRetiquetadoProTer( RetiquetadoProTerRN.EnBlanco( ) );                 
            eMas.AccionPasarTextoPrincipal( );            
            this.txtClaProProTer.Focus( );                       
        }
        
        public void AdicionarRetiquetadoProTer()
        {         
            RetiquetadoProTerEN iRetProTerEN = new RetiquetadoProTerEN( );
            this.AsignarRetiquetadoProTer(iRetProTerEN);

            //adicionar detalle
            RetiquetadoProTerRN.AdicionarRetiquetadoProTer(this.wEditRet.eLisRetProTer, iRetProTerEN); 
        }

        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }

            //valida cantidad de unidades
            if (this.ValidaCantidadUnidades() == false) { return; }

            //modificar detalle
            this.ModificarRetiquetadoProTer();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wEditRet.eClaveDgvRetProTer = this.wEditRet.eLisRetProTer[Dgv.ObtenerIndiceRegistroXFranja(this.wEditRet.dgvRetProTer)].ClaveObjeto;
            this.wEditRet.MostrarRetiquetadosProTer( );
            this.wEditRet.MostrarUnidadesRE();
            this.wEditRet.MostrarCantidadCajasRE();

            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarRetiquetadoProTer()
        {
            //obtener el objeto de la lista
            RetiquetadoProTerEN iProProTerEN = this.wEditRet.eLisRetProTer[Dgv.ObtenerIndiceRegistroXFranja(this.wEditRet.dgvRetProTer)];
            this.AsignarRetiquetadoProTer(iProProTerEN);
            
            //modificar el objeto en la lista
            ListaG.Modificar<RetiquetadoProTerEN>(this.wEditRet.eLisRetProTer, iProProTerEN, RetiquetadoProTerEN.ClaEnc, iProProTerEN.ClaveEncajado);            
        }
              
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarRetiquetadoProTer( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //actualizar propietario
            this.wEditRet.MostrarRetiquetadosProTer( );
            this.wEditRet.MostrarUnidadesRE();
            this.wEditRet.MostrarCantidadCajasRE();

            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarRetiquetadoProTer()
        {
            this.wEditRet.eLisRetProTer.RemoveAt( Dgv.ObtenerIndiceRegistroXFranja( this.wEditRet.dgvRetProTer ) );
        }
      
        public RetiquetadoProTerEN NuevaRetiquetadoProTerVentana()
        {
            //asignar parameros
            RetiquetadoProTerEN iProProTerEN = new RetiquetadoProTerEN();
            this.AsignarRetiquetadoProTer(iProProTerEN);

            //devolver
            return iProProTerEN;
        }

        public bool ValidaUnidadesPorEmpaque()
        {
            decimal iValor = Conversion.ADecimal(this.txtPreUni.Text, 0);
            if (iValor == 0)
            {
                Mensaje.OperacionDenegada("Las unidades por empaque no puede ser cero, debe actualizar ese dato en la existencia", "Existencia");
                return false;
            }
            return true;
        }

        public bool ValidaCantidadUnidades()
        {
            decimal iValor = Conversion.ADecimal(this.txtCanUniProTer.Text, 0);
            if (iValor == 0)
            {
                Mensaje.OperacionDenegada("La cantidad de unidades no puede ser cero", "Cantidad");
                return false;
            }
            return true;
        }

        public bool EsProduccionProTerValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtClaProProTer.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.ClaveProduccionProTer = this.txtClaProProTer.Text.Trim();
            string iClaveProduccionProTerFranjaGrilla = Dgv.ObtenerValorCelda(this.wEditRet.dgvRetProTer, RetiquetadoProTerEN.ClaProProTer);
            List<RetiquetadoProTerEN> iLisRetProTerGrilla = this.wEditRet.eLisRetProTer;
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iProProTerEN = ProduccionProTerRN.EsProduccionProTerValido(iProProTerEN, iOperacionVentana, iClaveProduccionProTerFranjaGrilla, iLisRetProTerGrilla);            
            if (iProProTerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iProProTerEN.Adicionales.Mensaje, "Encajado");
                this.txtClaProProTer.Focus();
            }

            //mostrar datos
            this.txtClaProProTer.Text = iProProTerEN.ClaveProduccionProTer;
            this.txtCodEnc.Text = iProProTerEN.CorrelativoEncajado;
            this.txtDesExi.Text = iProProTerEN.DescripcionExistencia;           
            this.txtPreUni.Text = Formato.NumeroDecimal(iProProTerEN.CostoTotalProducto, 2);
            this.txtDetCanSemPro.Text = iProProTerEN.DetalleCantidadesSemiProducto;

            //devolver
            return iProProTerEN.Adicionales.EsVerdad;
        }

        public void ListarProduccionesProTer()
        {
            //solo si el control no esta de solo lectura
            if (this.txtClaProProTer.ReadOnly == true) { return; }

            //instanciar
            wLisProTer win = new wLisProTer();
            win.eVentana = this;
            win.eTituloVentana = "Encajados";
            win.eCtrlValor = this.txtClaProProTer;
            win.eCtrlFoco = this.txtCanUniProTer;
            win.eProProTerEN.CodigoAlmacen = this.wEditRet.txtCodAlmPT.Text.Trim();
            win.eProProTerEN.CodigoExistencia = this.wEditRet.txtCodExiPT.Text.Trim();
            win.eLisRetProTer = this.wEditRet.eLisRetProTer;
            win.eCondicionLista = Listas.wLisProTer.Condicion.ProduccionesProTerDeAlmacenYExistenciaNoSeleccionadasEnGrillaRetiquetadoProTer;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AdicionarLotesRetiquetado()
        {
            //valida existencia vacio
            if (Txt.ValidarCampoVacio(this.txtClaProProTer, "Encajado") == false) { return; }

            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }
                        
            //instanciar
            wLoteRetiquetado win = new wLoteRetiquetado();
            win.wDetRet = this;            
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
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

        private void wDetalleRetiquetado_FormClosing(object sender, FormClosingEventArgs e)
        {           
            this.wEditRet.Enabled = true;
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

        private void btnProducciones_Click(object sender, EventArgs e)
        {
            this.AdicionarLotesRetiquetado();
        }
    }
}
