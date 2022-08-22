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
    public partial class wDetalleDesmedroEnvasado : Heredados.MiForm8
    {
        public wDetalleDesmedroEnvasado()
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

        public wIngresoDesmedroEnvasado wIngDesEnv;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodExi, this.txtCanDes, "ffff");
            xLis.Add(xCtrl);
           
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCanDes, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanFor, this.txtCanDes, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanDes, this.txtCanDes, "ffff");            
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMotRep, "vvvv");
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
            this.wIngDesEnv.Enabled = false;

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
            this.btnMotRep.Focus();
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
            this.btnMotRep.Focus();
        }

        public void AsignarProduccionExis(ProduccionExisEN pObj)
        {           
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();            
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.CantidadProduccionExis = Conversion.ADecimal(this.txtCanFor.Text, 0);
            pObj.CantidadDesmedro = Conversion.ADecimal(this.txtCanDes.Text, 0);
            pObj.DetalleMotivoDesmedro = this.eDetalleMotivoDesmedro;         
            //pObj.ClaveRetiquetado = this.wIngDesEnv.ObtenerClaveRetiquetado();
        }

        public void MostrarProduccionExis( ProduccionExisEN pObj )
        {       
            this.txtCodExi.Text = pObj.CodigoExistencia;            
            this.txtDesExi.Text = pObj.DescripcionExistencia;   
            this.txtCanFor.Text= Formato.NumeroDecimal(pObj.CantidadProduccionExis, 2);
            this.txtCanDes.Text = Formato.NumeroDecimal(pObj.CantidadDesmedro.ToString(), 0);
            this.eDetalleMotivoDesmedro = pObj.DetalleMotivoDesmedro;                    
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

            //valida cantidad de unidades
            if (this.ValidaCuandoCantidadDesmedroEsMayorCantidadFormula() == false) { return; }

            //valida motivos
            if (this.EsValidarUnidadesConMotivos() == false) { return; }

            //modificar detalle
            this.ModificarProduccionExis();

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se modifico el registro" , "Detalle" );

            //Actualizar propietario
            this.wIngDesEnv.eClaveDgvRetProTer = Dgv.ObtenerValorCelda(this.wIngDesEnv.dgvProExi, ProduccionExisEN.ClaObj);
            this.wIngDesEnv.MostrarProduccionExis( );
            
            //salir de la ventana
            this.Close( );

        }

        public void ModificarProduccionExis()
        {
            //obtener el objeto de la lista
            ProduccionExisEN iProExiEN = ListaG.Buscar<ProduccionExisEN>(this.wIngDesEnv.eLisProExi, ProduccionExisEN.ClaObj,
                Dgv.ObtenerValorCelda(this.wIngDesEnv.dgvProExi, ProduccionExisEN.ClaObj));
            this.AsignarProduccionExis(iProExiEN);

            //modificar el objeto en la lista
            ListaG.Modificar<ProduccionExisEN>(this.wIngDesEnv.eLisProExi, iProExiEN, ProduccionExisEN.ClaObj, iProExiEN.ClaveObjeto);
        }
              
        public void Eliminar( )
        {
            //eliminar particpante
            this.EliminarProduccionExis( );

            //mensaje
            Mensaje.OperacionSatisfactoria( "Se elimino el registro" , "Detalle" );

            //actualizar propietario
            this.wIngDesEnv.MostrarProduccionExis( );
            
            //salir de la ventana
            this.Close( );
        }
        
        public void EliminarProduccionExis()
        {
            //obtener el objeto de la lista
            ProduccionExisEN iProExiEN = ListaG.Buscar<ProduccionExisEN>(this.wIngDesEnv.eLisProExi, ProduccionExisEN.ClaObj,
                Dgv.ObtenerValorCelda(this.wIngDesEnv.dgvProExi, ProduccionExisEN.ClaObj));

            //actualizar datos
            iProExiEN.CEstadoDesmedro = "0";//desactivar
            iProExiEN.CantidadDesmedro = 0;
            iProExiEN.DetalleMotivoDesmedro = string.Empty;

            //modificar el objeto en la lista
            ListaG.Modificar<ProduccionExisEN>(this.wIngDesEnv.eLisProExi, iProExiEN, ProduccionExisEN.ClaObj, iProExiEN.ClaveObjeto);
        }
      
        public ProduccionExisEN NuevaProduccionExisVentana()
        {
            //asignar parameros
            ProduccionExisEN iProProTerEN = new ProduccionExisEN();
            this.AsignarProduccionExis(iProProTerEN);

            //devolver
            return iProProTerEN;
        }

        public void AccionMotivosDesmedro()
        {
            //valida unidades por empaque
            //if (this.ValidaUnidadesPorEmpaque() == false) { return; }

            //instanciar
            wMotivoDesmedro win = new wMotivoDesmedro();
            win.wDetDesEnv = this;
            win.eTipoMotivo = "MotDmd";
            win.eCantidadMotivo = Conversion.ADecimal(this.txtCanDes.Text, 0);
            win.eDetalleMotivo = this.eDetalleMotivoDesmedro;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsValidarUnidadesConMotivos()
        {
            //asignar parametros
            ProduccionExisEN iLibEN = this.NuevaProduccionExisVentana();

            //valida reproceso
            ProduccionExisEN iLibValEN = ProduccionExisRN.ValidaCuandoUnidadesDesmedroNoTieneIgualCantidadUnidadesMotivos(iLibEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Motivos");
                this.btnMotRep.Focus();
                return false;
            }
                       
            //ok
            return true;
        }

        public bool ValidaCuandoCantidadDesmedroEsMayorCantidadFormula()
        {
            //asignar parametros
            ProduccionExisEN iLibEN = this.NuevaProduccionExisVentana();

            //valida reproceso
            ProduccionExisEN iLibValEN = ProduccionExisRN.ValidaCuandoCantidadDesmedroEsMayorCantidadFormula(iLibEN);
            if (iLibValEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iLibValEN.Adicionales.Mensaje, "Cantidad");
                this.txtCanDes.Focus();
                return false;
            }

            //ok
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

        private void wDetalleDesmedroEnvasado_FormClosing(object sender, FormClosingEventArgs e)
        {           
            this.wIngDesEnv.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }
              
        private void txtCanDes_Validated(object sender, EventArgs e)
        {
           
        }

        private void btnMotRep_Click(object sender, EventArgs e)
        {
            this.AccionMotivosDesmedro();
        }
    }
}
