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
    public partial class wDetalleEncajado : Heredados.MiForm8
    {
        public wDetalleEncajado()
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

        public wEditEncajado wEditEnc;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPriEnc, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Existencia", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCodExi, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUniXEmp, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanUniProTer, true, "Cantidad", "ffff", 0, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnProducciones, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumCaj, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtObsProTer, false, "Observacion", "vvff");
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
            this.wEditEnc.Enabled = false;

            //ver ventana
            this.Show( );
        }

        public void ValoresXDefecto()
        {
            //traer al alamcen de produccion
            AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacenXCodigo("A13");

            //mostrar datos en pantalla
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
        }

        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Adicionar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarProduccionProTer( ProduccionProTerRN.EnBlanco( ) );                       
            eMas.AccionHabilitarControles( 0 );           
            eMas.AccionPasarTextoPrincipal();
            this.ValoresXDefecto();                    
            this.txtCodExi.Focus();
        }
        
        public void VentanaModificar( ProduccionProTerEN pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarProduccionProTer( pObj );             
            eMas.AccionHabilitarControles( 1 );         
            eMas.AccionPasarTextoPrincipal();
            this.btnProducciones.Focus();
        }
        
        public void VentanaEliminar( ProduccionProTerEN pObj )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Eliminar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarProduccionProTer(pObj);           
            eMas.AccionHabilitarControles( 2 );
            eMas.AccionPasarTextoPrincipal( );
            this.btnAceptar.Focus();
        }

        public void AsignarProduccionProTer(ProduccionProTerEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CorrelativoProduccionProTer = this.txtPriEnc.Text.Trim();         
            pObj.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pObj.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();            
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.UnidadesPorEmpaque = Conversion.ADecimal(this.txtUniXEmp.Text, 0);
            pObj.CantidadUnidadesProTer = Convert.ToDecimal(this.txtCanUniProTer.Text);
            pObj.NumeroCajas = Conversion.ADecimal(this.txtNumCaj.Text, 0);           
            pObj.ObservacionProTer = this.txtObsProTer.Text.Trim();
            pObj.DetalleCantidadesSemiProducto = this.eLiberacionProTer;
            pObj.ClaveEncajado = this.wEditEnc.ObtenerClaveEncajado();
        }

        public void MostrarProduccionProTer( ProduccionProTerEN pObj )
        {
            this.txtPriEnc.Text = pObj.CorrelativoProduccionProTer;
            this.txtCodAlm.Text = pObj.CodigoAlmacen;
            this.txtDesAlm.Text = pObj.DescripcionAlmacen;
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;   
            this.txtUniXEmp.Text= Formato.NumeroDecimal(pObj.UnidadesPorEmpaque, 0);
            this.txtCanUniProTer.Text = Formato.NumeroDecimal(pObj.CantidadUnidadesProTer.ToString(), 0);  
            this.txtNumCaj.Text= Formato.NumeroDecimal(pObj.NumeroCajas, 2);           
            this.txtObsProTer.Text = pObj.ObservacionProTer;
            this.eLiberacionProTer = pObj.DetalleCantidadesSemiProducto;
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

            //valida cantidad de unidades
            if (this.ValidaCantidadUnidades() == false) { return; }

            //adicionar ProduccionProTer
            this.AdicionarProduccionProTer( );
            
            //mensaje
            Mensaje.OperacionSatisfactoria( "Se adiciono el registro" , "Detalle" );

            //actualizar propietario
            this.wEditEnc.eClaveDgvProProTer = this.wEditEnc.eLisProProTer[this.wEditEnc.eLisProProTer.Count - 1].ClaveObjeto;
            this.wEditEnc.MostrarProduccionesProTer( );
            this.wEditEnc.HabilitarDesplazadores();

            //limpiar controles
            eMas.AccionHabilitarControles(0);
            this.MostrarProduccionProTer( ProduccionProTerRN.EnBlanco( ) );
            this.ValoresXDefecto();            
            eMas.AccionPasarTextoPrincipal( );            
            this.txtCodExi.Focus( );                       
        }
        
        public void AdicionarProduccionProTer()
        {         
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN( );
            this.AsignarProduccionProTer(iProProTerEN);

            //actualizar campos porcentajes y cantidades rango
            ProduccionProTerRN.ActualizarPorcentajesYCantidadesRango(iProProTerEN);

            //adicionar detalle
            ProduccionProTerRN.AdicionarProduccionProTer(this.wEditEnc.eLisProProTer, iProProTerEN); 
        }

        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }

            //valida cantidad de unidades
            if (this.ValidaCantidadUnidades() == false) { return; }

            //modificar detalle
            this.ModificarProduccionProTer();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wEditEnc.eClaveDgvProProTer = this.wEditEnc.eLisProProTer[Dgv.ObtenerIndiceRegistroXFranja(this.wEditEnc.dgvProProTer)].ClaveObjeto;
            this.wEditEnc.MostrarProduccionesProTer( );

            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarProduccionProTer()
        {
            //obtener el objeto de la lista
            ProduccionProTerEN iProProTerEN = this.wEditEnc.eLisProProTer[Dgv.ObtenerIndiceRegistroXFranja(this.wEditEnc.dgvProProTer)];
            this.AsignarProduccionProTer(iProProTerEN);

            //actualizar campos porcentajes y cantidades rango
            ProduccionProTerRN.ActualizarPorcentajesYCantidadesRango(iProProTerEN);

            //modificar el objeto en la lista
            ListaG.Modificar<ProduccionProTerEN>(this.wEditEnc.eLisProProTer, iProProTerEN, ProduccionProTerEN.CodExi, iProProTerEN.CodigoExistencia);            
        }
              
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarProduccionProTer( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //mostra detalle comprobante
            ProduccionProTerRN.OrdenarCorrelativo(this.wEditEnc.eLisProProTer);
            this.wEditEnc.MostrarProduccionesProTer( );
            
            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarProduccionProTer()
        {
            this.wEditEnc.eLisProProTer.RemoveAt( Dgv.ObtenerIndiceRegistroXFranja( this.wEditEnc.dgvProProTer ) );
        }
     
        public void ListarAlmacenes()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm;
            win.eCtrlFoco = this.txtCodExi;
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, "Almacen");
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
           
            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarExistencias()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExi.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias";
            win.eCtrlValor = this.txtCodExi;
            win.eCtrlFoco = this.btnProducciones;
            win.eExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            win.eLisProProTer = this.wEditEnc.eLisProProTer;
            win.eCondicionLista = wLisExi.Condicion.ListarExistenciasProductosTerminadosActivosDeAlmacenNoSeleccionadasGrilla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodExi.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = this.NuevaExistenciaVentana();           
            string iCodigoExistenciaFranjaGrilla = Dgv.ObtenerValorCelda(this.wEditEnc.dgvProProTer, ProduccionProTerEN.CodExi);
            List<ProduccionProTerEN> iLisProProTerGrilla = this.wEditEnc.eLisProProTer;
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaProductoTerminadoActivoValido(iExiEN, iOperacionVentana, iCodigoExistenciaFranjaGrilla, iLisProProTerGrilla);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia");
                this.txtCodExi.Focus();
            }

            //pasar datos
            this.txtCodExi.Text = iExiEN.CodigoExistencia;
            this.txtDesExi.Text = iExiEN.DescripcionExistencia;
            this.txtUniXEmp.Text = Formato.NumeroDecimal(iExiEN.UnidadesPorEmpaque, 0);

            //devolver
            return iExiEN.Adicionales.EsVerdad;         
        }

        public ExistenciaEN NuevaExistenciaVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iExiEN.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            iExiEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public void ConsultarProduccionesEncajar()
        {
            //valida almacen vacio
            if (Txt.ValidarCampoVacio(this.txtCodAlm, "Almacen") == false) { return; }

            //valida existencia vacio
            if (Txt.ValidarCampoVacio(this.txtCodExi, "Existencia PT") == false) { return; }

            //valida unidades por empaque
            if (this.ValidaUnidadesPorEmpaque() == false) { return; }
            
            //asignar parametros
            ProduccionProTerEN iProProTerEN = this.NuevaProduccionProTerVentana();

            //MENSAJE TEMPORAL
            iProProTerEN.Adicionales.EsVerdad = Mensaje.DeseasRealizarOperacion("Seleccionar solo liberaciones desde enero hasta abril", "Liberaciones");

            //instanciar
            wProduccionesEncajar win = new wProduccionesEncajar();
            win.wDetEnc = this;
            win.eOperacion = Universal.Opera.Modificar;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iProProTerEN);
        }

        public ProduccionProTerEN NuevaProduccionProTerVentana()
        {
            //asignar parameros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            this.AsignarProduccionProTer(iProProTerEN);

            //devolver
            return iProProTerEN;
        }

        public bool ValidaUnidadesPorEmpaque()
        {
            decimal iValor = Conversion.ADecimal(this.txtUniXEmp.Text, 0);
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

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.eTitulo);
        }

        #endregion


        private void btnCancelar_Click( object sender , EventArgs e )
        {
            this.Cancelar( );
        }

        private void wDetalleEncajado_FormClosing(object sender, FormClosingEventArgs e)
        {           
            this.wEditEnc.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistencias(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistencias();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValido();
        }
        
        private void txtCodAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValido();
        }

        private void txtCodAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes(); }
        }

        private void txtCodAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes();
        }

        private void txtCanUniProTer_Validated(object sender, EventArgs e)
        {
           
        }
        
        private void btnProducciones_Click(object sender, EventArgs e)
        {
            this.ConsultarProduccionesEncajar();
        }
    }
}
