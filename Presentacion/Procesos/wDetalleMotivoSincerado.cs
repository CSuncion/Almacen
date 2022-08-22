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
    public partial class wDetalleMotivoSincerado : Heredados.MiForm8
    {
        public wDetalleMotivoSincerado()
        {
            InitializeComponent( );
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();       
        string eTitulo = "Item";
        public int eFlagVentana;//0:wMotivoSincerado,1:wMotivoSinceradoParTra
        public string eTipoMotivo = "MotSin";

        #endregion

        #region Propietario

        public wMotivoSincerado wMotSin;
        public wMotivoSinceradoParTra wMotSinParTra;


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
            this.HabilitarPropietario(false);

            //ver ventana
            this.Show( );
        }

        public void HabilitarPropietario(bool pValor)
        {
            switch (this.eFlagVentana)
            {
                case 0: { this.wMotSin.Enabled = pValor; break; }
                case 1: { this.wMotSinParTra.Enabled = pValor; break; }
            }
        }

        public void VentanaAdicionar( )
        {
            this.InicializaVentana( );
            this.Text = Universal.Opera.Adicionar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMotivoLiberacion( LiberacionRN.EnBlancoMotivoLiberacion() );                             
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
            pObj.TipoMotivoLiberacion = this.eTipoMotivo;           
            pObj.CodigoMotivoLiberacion = this.txtCodMotLib.Text.Trim();
            pObj.DescripcionMotivoLiberacion = this.txtDesMotLib.Text.Trim();        
            pObj.ClaveMotivoLiberacion = LiberacionRN.ObtenerClaveMotivoLiberacion(pObj);
            pObj.ClaveObjeto = pObj.ClaveMotivoLiberacion;
        }

        public void MostrarMotivoLiberacion( MotivoLiberacion pObj )
        {            
            this.txtCodMotLib.Text = pObj.CodigoMotivoLiberacion;
            this.txtDesMotLib.Text = pObj.DescripcionMotivoLiberacion;                                   
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
            this.AdicionarMotivoSincerado( );
                        
            //actualizar el campo detalle
            this.ActualizarCampoDetalleMotivo();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se adiciono el registro" , "Detalle" );

            //actualizar propietario
            this.ActualizarPropietarioAlAdicionar();
                        
            //limpiar controles
            eMas.AccionHabilitarControles(0);
            this.MostrarMotivoLiberacion( LiberacionRN.EnBlancoMotivoLiberacion() );            
            eMas.AccionPasarTextoPrincipal( );            
            this.txtCodMotLib.Focus( );                       
        }

        public void ActualizarPropietarioAlAdicionar()
        {
            switch (this.eFlagVentana)
            {
                case 0:
                    {
                        this.wMotSin.eClaveDgvMotLib = this.wMotSin.eLisMotDes[this.wMotSin.eLisMotDes.Count - 1].ClaveObjeto;
                        this.wMotSin.ActualizarDgvMot();
                        break;
                    }
                case 1:
                    {
                        this.wMotSinParTra.eClaveDgvMotLib = this.wMotSinParTra.eLisMotDes[this.wMotSinParTra.eLisMotDes.Count - 1].ClaveObjeto;
                        this.wMotSinParTra.ActualizarDgvMot();
                        break;
                    }
            }
        }
        
        public void AdicionarMotivoSincerado()
        {
            MotivoLiberacion iMotLibEN = new MotivoLiberacion();
            this.AsignarMotivoLiberacion(iMotLibEN);

            switch (this.eFlagVentana)
            {
                case 0:
                    {
                        //adicionar detalle
                        this.wMotSin.eLisMotDes.Add(iMotLibEN);
                        break;
                    }
                case 1:
                    {
                        //adicionar detalle
                        this.wMotSinParTra.eLisMotDes.Add(iMotLibEN);
                        break;
                    }
            }          
        }

        public void ActualizarCampoDetalleMotivo()
        {
            switch (this.eFlagVentana)
            {
                case 0:
                    {
                        //asignar parametro
                        string iCampoDetalleMotivo = LiberacionRN.ConvertirListaACampoDetalleMotivo(this.wMotSin.eLisMotDes);

                        //ejecutar metodo
                        this.wMotSin.eDetalleMotivo = iCampoDetalleMotivo;
                        break;
                    }
                case 1:
                    {
                        //asignar parametro
                        string iCampoDetalleMotivo = LiberacionRN.ConvertirListaACampoDetalleMotivo(this.wMotSinParTra.eLisMotDes);

                        //ejecutar metodo
                        this.wMotSinParTra.eDetalleMotivo = iCampoDetalleMotivo;
                        break;
                    }
            }
            
        }

        public void Modificar( )
        {
            //validar los campos obligatorios
            if( eMas.CamposObligatorios( ) == false ) { return; }
                       
            //modificar detalle
            this.ModificarMotivoDesmedro();

            //actualizar el campo detalle
            this.ActualizarCampoDetalleMotivo();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wMotSin.eClaveDgvMotLib = this.wMotSin.eLisMotDes[Dgv.ObtenerIndiceRegistroXFranja(this.wMotSin.DgvBot)].ClaveObjeto;
            this.wMotSin.ActualizarDgvMot( );
            
            //salir de la ventana
            this.Close( );

        }
        
        public void ModificarMotivoDesmedro()
        {
            //obtener el objeto de la lista
            MotivoLiberacion iProProTerEN = this.wMotSin.eLisMotDes[Dgv.ObtenerIndiceRegistroXFranja(this.wMotSin.DgvBot)];
            this.AsignarMotivoLiberacion(iProProTerEN);
            
            //modificar el objeto en la lista
            ListaG.Modificar<MotivoLiberacion>(this.wMotSin.eLisMotDes, iProProTerEN, MotivoLiberacion.CodMotLib, iProProTerEN.CodigoMotivoLiberacion);            
        }
              
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarMotivoSincerado( );

            //actualizar el campo detalle
            this.ActualizarCampoDetalleMotivo();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //mostra detalle comprobante           
            this.ActualizarPropietarioAlEliminar( );
            
            //salir de la ventana
            this.Close( );
        }

        public void ActualizarPropietarioAlEliminar()
        {
            switch (this.eFlagVentana)
            {
                case 0:
                    {                        
                        this.wMotSin.ActualizarDgvMot();
                        break;
                    }
                case 1:
                    {                       
                        this.wMotSinParTra.ActualizarDgvMot();
                        break;
                    }
            }
        }

        public void EliminarMotivoSincerado()
        {
            switch (this.eFlagVentana)
            {
                case 0:
                    {
                        this.wMotSin.eLisMotDes.RemoveAt(Dgv.ObtenerIndiceRegistroXFranja(this.wMotSin.DgvBot));
                        break;
                    }
                case 1:
                    {
                        this.wMotSinParTra.eLisMotDes.RemoveAt(Dgv.ObtenerIndiceRegistroXFranja(this.wMotSinParTra.DgvBot));
                        break;
                    }
            }
            
        }
      
        public ItemGEN NuevoItemGVentana()
        {
            //asignar parameros
            ItemGEN iIteGEN = new ItemGEN();
            iIteGEN.CodigoTabla = this.eTipoMotivo;
            iIteGEN.CodigoItemG = this.txtCodMotLib.Text.Trim();
            iIteGEN.ClaveItemG = ItemGRN.ObtenerClaveItemG(iIteGEN);

            //devolver
            return iIteGEN;
        }

        public bool EsMotivoValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodMotLib.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ItemGEN iIteGEN = this.NuevoItemGVentana();
            string iCodigoItemGFranjaGrilla = this.ObtenerCodigoItemGFranjaGrilla();
            List<MotivoLiberacion> iLisMotLibGrilla = this.ObtenerListaMotivoLiberacion();
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

        public string ObtenerCodigoItemGFranjaGrilla()
        {
            switch (this.eFlagVentana)
            {
                case 0:
                    {
                        return Dgv.ObtenerValorCelda(this.wMotSin.DgvBot, MotivoLiberacion.CodMotLib);                        
                    }
                case 1:
                    {
                        return Dgv.ObtenerValorCelda(this.wMotSinParTra.DgvBot, MotivoLiberacion.CodMotLib);                        
                    }
            }
            return string.Empty;
        }

        public List<MotivoLiberacion> ObtenerListaMotivoLiberacion()
        {
            List<MotivoLiberacion> iLisRes = new List<MotivoLiberacion>();
            switch (this.eFlagVentana)
            {
                case 0:
                    {
                        return this.wMotSin.eLisMotDes;
                    }
                case 1:
                    {
                        return this.wMotSinParTra.eLisMotDes;
                    }
            }
            return iLisRes;
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
            win.eCtrlFoco = this.btnAceptar;
            win.eIteEN.CodigoTabla = this.eTipoMotivo;
            win.eLisMotLib = this.ObtenerListaMotivoLiberacion();
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTablaNoSeleccionadasEnGrillaMotivos;
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

        private void wDetalleMotivoSincerado_FormClosing(object sender, FormClosingEventArgs e)
        {           
            this.HabilitarPropietario(true);
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
     
       
    }
}
