using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Comun;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Negocio;
using Entidades;
using Presentacion.FuncionesGenericas;
using Presentacion.Principal;

namespace Presentacion.Procesos
{
    public partial class wEditLiberacion : Heredados.MiForm8
    {
        public wEditLiberacion()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string eTitulo = "Cantidad";
                        
        #endregion

        #region Propietario

        //public wLiberacion wLib;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodLib, this.dtpFecLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecLib, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtSalLib, this.dtpFecLib, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanLib, true, "Cantidad", "vvff", 0, 18);
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
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
            //titulo ventana
            //this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wLib.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            
            //deshabilitar propietario
            //this.wLib.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void MostrarSaldoActualLiberacion()
        {
            //ejecutar metodo
            //ProduccionDetaEN iProDetEN = this.wLib.wParTra.EsProduccionDetaExistente();

            ////mostrar en pantalla
            //if (this.wLib.eAlmacenLiberacion == "0")
            //{
            //    this.txtSalLib.Text = Formato.NumeroDecimal(iProDetEN.SaldoLiberacion, 0);
            //}
            //else
            //{
            //    if (this.wLib.eAlmacenLiberacion == "1")
            //    {
            //        this.txtSalLib.Text = Formato.NumeroDecimal(iProDetEN.SaldoLiberacionBloqueadas, 0);
            //    }
            //    else
            //    {
            //        this.txtSalLib.Text = Formato.NumeroDecimal(iProDetEN.SaldoLiberacionCuarentenaQali, 0);
            //    }
            //}            
            //this.dtpFecLib.Text = iProDetEN.FechaProduccionDeta;
        }

        public void VentanaAdicionar()
        {           
            this.InicializaVentana();
            this.MostrarLiberacion(LiberacionRN.EnBlanco());
            this.MostrarSaldoActualLiberacion();           
            eMas.AccionHabilitarControles(0);            
            eMas.AccionPasarTextoPrincipal();           
            this.dtpFecLib.Focus();
        }

        public void VentanaModificar(LiberacionEN pObj)
        {
            this.InicializaVentana();
            this.MostrarLiberacion(pObj);            
            eMas.AccionHabilitarControles(1);           
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecLib.Focus();
        }

        public void VentanaEliminar(LiberacionEN pObj)
        {
            this.InicializaVentana();
            this.MostrarLiberacion(pObj);
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }
        
        public void VentanaVisualizar(LiberacionEN pObj)
        {
            this.InicializaVentana();
            this.MostrarLiberacion(pObj);           
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarLiberacion(LiberacionEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            //pObj.FechaProduccionDeta = Dgv.ObtenerValorCelda(this.wLib.wParTra.DgvProDet, LiberacionEN.FecProDet);
            pObj.CodigoLiberacion = this.txtCodLib.Text.Trim();
            pObj.FechaLiberacion = this.dtpFecLib.Text;
            pObj.PeriodoLiberacion = Fecha.ObtenerPeriodo(pObj.FechaLiberacion, "-");
            pObj.SaldoLiberacion = Conversion.ADecimal(this.txtSalLib.Text, 0);
            pObj.CantidadLiberacion = Conversion.ADecimal(this.txtCanLib.Text, 0);            
            pObj.SaldoUnidadesAEmpacar = pObj.CantidadLiberacion;            
            //pObj.ClaveProduccionDeta = Dgv.ObtenerValorCelda(this.wLib.wParTra.DgvProDet, ProduccionDetaEN.ClaObj);
            pObj.ClaveLiberacion = LiberacionRN.ObtenerClaveLiberacion(pObj);
            //pObj.CAlmacenLiberacion = this.wLib.eAlmacenLiberacion;          
        }

        public void MostrarLiberacion(LiberacionEN pObj)
        {
            this.txtCodLib.Text = pObj.CodigoLiberacion;
            this.dtpFecLib.Text = pObj.FechaLiberacion;
            this.txtSalLib.Text = Formato.NumeroDecimal(pObj.SaldoLiberacion, 0);
            this.txtCanLib.Text = Formato.NumeroDecimal(pObj.CantidadLiberacion, 0);      
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }
            
            //es fecha valida
            if (this.EsFechaValida() == false) { return; }

            //es fecha valida
            if (this.EsValidaFechaLiberacion() == false) { return; }
            
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //mostrar nuevo codigo
            this.MostrarNuevoCodigo();

            //adicionar el registro liberacion
            this.AdicionarLiberacion();

            //modificar el registro ProduccionDeta
            this.ModificarProduccionDetaAlAdicionar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la liberacion correctamente", this.eTitulo);

            //actualizar al propietario wLiberacion         
            //this.wLib.eClaveDgvLib = this.ObtenerClaveLiberacion();
            //this.wLib.ActualizarVentana();

            ////actualizar al propietario wParteTrabajo
            //this.wLib.wParTra.eClaveDgvProDet = this.ObtenerClaveProduccionDeta();
            //this.wLib.wParTra.ActualizarVentana();

            //limpiar controles
            this.MostrarLiberacion(LiberacionRN.EnBlanco());          
            this.MostrarSaldoActualLiberacion();             
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecLib.Focus();
        }

        public void MostrarNuevoCodigo()
        {
            //asignar parametros
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = LiberacionRN.ObtenerNuevoNumeroLiberacionAutogenerado(iLibEN);

            //mostrar en pantalla
            this.txtCodLib.Text = iNuevoNumero;
        }

        public void AdicionarLiberacion()
        {
            //asignar parametros
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();
            
            //ejecutar metodo
            LiberacionRN.AdicionarLiberacion(iLibEN);
        }

        public void ModificarProduccionDetaAlAdicionar()
        {
            //asignar parametros            
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            ProduccionDetaRN.ModificarProduccionDetaAlAdicionarPorLiberacion(iLibEN);
        }
        
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }

            //es fecha valida
            if (this.EsValidaFechaLiberacion() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wLib.EsActoModificarLiberacion().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wLib.eTitulo) == false) { return; }

            //modificar el registro ProduccionDeta
            this.ModificarProduccionDetaAlEliminar();

            //modificar el registro liberacion    
            this.ModificarLiberacion();

            //modificar el registro ProduccionDeta
            this.ModificarProduccionDetaAlAdicionar();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se modifico la liberacion correctamente", this.wLib.eTitulo);

            ////actualizar al propietario wLiberacion         
            //this.wLib.eClaveDgvLib = this.ObtenerClaveLiberacion();
            //this.wLib.ActualizarVentana();

            ////actualizar al propietario wParteTrabajo
            //this.wLib.wParTra.eClaveDgvProDet = this.ObtenerClaveProduccionDeta();
            //this.wLib.wParTra.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void ModificarLiberacion()
        {
            //traer al Liberacion de b.d
            //LiberacionEN iLibEN = this.wLib.EsLiberacionExistente();

            //modificar datos
            //this.AsignarLiberacion(iLibEN);

            ////actualizamos los detalles,en caso se digito cero pero ya se habian registrado los motivos
            //LiberacionRN.ActualizarCamposDetallePorMontosCeros(iLibEN);

            ////ejecutar metodo
            //LiberacionRN.ModificarLiberacion(iLibEN);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wLib.EsActoEliminarLiberacion().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wLib.eTitulo) == false) { return; }

            //modificar el registro ProduccionDeta
            this.ModificarProduccionDetaAlEliminar();

            //eliminar movimientos transferencias generadas
            this.EliminarMovimientosTransferenciasGeneradas();

            //eliminar el registro liberacion
            this.EliminarLiberacion();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se elimino la liberacion correctamente", this.wLib.eTitulo);

            ////actualizar al propietario wLiberacion
            //this.wLib.ActualizarVentana();

            ////actualizar al propietario wParteTrabajo            
            //this.wLib.wParTra.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarLiberacion()
        {
            //asignar parametros
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            LiberacionRN.EliminarLiberacion(iLibEN);
        }
        
        public void EliminarMovimientosTransferenciasGeneradas()
        {
            //asignar parametros            
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            MovimientoCabeRN.EliminarMovimientosTransferenciasGeneradas(iLibEN);
        }
        
        public void ModificarProduccionDetaAlEliminar()
        {
            //asignar parametros            
            LiberacionEN iLibEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            ProduccionDetaRN.ModificarProduccionDetaAlEliminarPorLiberacion(iLibEN);
        }

        public LiberacionEN NuevoLiberacionDeVentana()
        {
            LiberacionEN iProDetEN = new LiberacionEN();
            this.AsignarLiberacion(iProDetEN);
            return iProDetEN;
        }

        public string ObtenerClaveLiberacion()
        {
            //asignar parametros
            LiberacionEN iLebEN = this.NuevoLiberacionDeVentana();

            //devolver
            return iLebEN.ClaveLiberacion;
        }

        public string ObtenerClaveProduccionDeta()
        {
            //asignar parametros
            LiberacionEN iLebEN = this.NuevoLiberacionDeVentana();

            //devolver
            return iLebEN.ClaveProduccionDeta;
        }
        
        public bool EsFechaValida()
        {
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            this.AsignarLiberacion(iLibEN);

            //ejecutar metodo
            iLibEN = LiberacionRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iLibEN);

            //mostrar mensaje error
            Generico.MostrarMensajeError(iLibEN.Adicionales, this.dtpFecLib);

            //devolver
            return iLibEN.Adicionales.EsVerdad;
        }

        public bool EsValidaCantidadLiberada()
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            iProDetEN = LiberacionRN.EsValidaCantidadLiberada(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, this.txtCanLib);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public bool EsValidaFechaLiberacion()
        {
            //asignar parametros
            LiberacionEN iProDetEN = this.NuevoLiberacionDeVentana();

            //ejecutar metodo
            iProDetEN = LiberacionRN.EsValidaFechaLiberacion(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, this.dtpFecLib);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }
        
        public void Cancelar()
        {
            //Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wLib.eTitulo);
        }

        #endregion

        private void wEditLiberacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wLib.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
        
        private void txtCanLib_Validated(object sender, EventArgs e)
        {
            this.EsValidaCantidadLiberada();
        }
        
    }
}
