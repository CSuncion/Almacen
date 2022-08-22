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
    public partial class wCierreAnual : Heredados.MiForm8
    {
        public wCierreAnual()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public string eTitulo = "Cierre anual";

        #endregion
        
        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtAñoSal, true, "Año", "vfff", 4);
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
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();          
            this.txtAñoSal.Focus();
        }
      
        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //valida si es acto generar el cierre anual
            if (this.EsActoCierreAnual() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar los saldos nuevos que tenga el nuevo año
            this.EliminarNuevosSaldosPorCierreAnual();

            //generar los nuevos saldos para el siguiente año
            this.AdicionarNuevosSaldosPorCierreAnual();

            //cerrar todos los periodos del año cierre
            this.CerrarPeriodosDeAñoCierre();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Cierre anual se realizo correctamente", this.eTitulo);

            //cerrar esta ventana         
            this.Close();
        }

        public bool EsActoCierreAnual()
        {
            //asignar parametros
            string iAñoCierre = this.txtAñoSal.Text.Trim();

            //ejecutar metodo
            SaldoEN iSalEN = SaldoRN.EsActoGenerarCierreAnual(iAñoCierre);

            //mensaje error
            Generico.MostrarMensajeError(iSalEN.Adicionales, this.txtAñoSal);

            //devolver
            return iSalEN.Adicionales.EsVerdad;
        }

        public void EliminarNuevosSaldosPorCierreAnual()
        {
            //asignar parametros
            string iAñoCierre = this.txtAñoSal.Text.Trim();

            //ejecutar metodo
            SaldoRN.EliminarNuevosSaldosPorCierreAnual(iAñoCierre);
        }

        public void AdicionarNuevosSaldosPorCierreAnual()
        {
            //asignar parametros
            string iAñoCierre = this.txtAñoSal.Text.Trim();

            //ejecutar metodo
            SaldoRN.AdicionarNuevosSaldosPorCierreAnual(iAñoCierre);
        }

        public void CerrarPeriodosDeAñoCierre()
        {
            //asignar parametro
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.AnoPeriodo = this.txtAñoSal.Text.Trim();
            iPerEN.CEstadoPeriodo = "0";//desactivado

            //ejecutar metodo
            PeriodoRN.ModificarEstadoPeriodoDeAño(iPerEN);
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteCierreAnual, null);
        }

        #endregion

        private void wCierreAnual_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();         
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
