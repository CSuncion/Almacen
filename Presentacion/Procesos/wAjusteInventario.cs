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
    public partial class wAjusteInventario : Heredados.MiForm8
    {
        public wAjusteInventario()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public string eTitulo = "Ajustes";

        #endregion
        
        #region Propietario

        public wInventario wInv;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecGen, "vvff");
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

            //deshabilitar propietario
            this.wInv.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.dtpFecGen.Focus();
        }
       
        public void Aceptar()
        {
            //volver a preguntar si es acto generar movimientos ajuste
            if (this.wInv.EsActoGenerarMovimientosAjuste().Adicionales.EsVerdad == false) { return; }

            //valida el periodo para este movimiento
            if (this.ValidaFechaGenera() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //generar
            this.GenerarMovimientos();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Los movimientos de ajustes se generaron correctamente", this.eTitulo);

            //actualizar propietario
            this.wInv.eClaveDgvInv = Dgv.ObtenerValorCelda(this.wInv.DgvInv, InventarioCabeEN.ClaObj);
            this.wInv.ActualizarVentana();

            //limpiar controles         
            this.Close();
        }

        public bool ValidaFechaGenera()
        {
            
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(this.dtpFecGen.Value, "-");

            //validar
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.eTitulo);
                this.dtpFecGen.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public void GenerarMovimientos()
        {
            //asignar parametro
            InventarioCabeEN iInvCabEN = new InventarioCabeEN();
            iInvCabEN.ClaveInventarioCabe = Dgv.ObtenerValorCelda(this.wInv.DgvInv, InventarioCabeEN.ClaObj);
            iInvCabEN.FechaGenera = this.dtpFecGen.Text;

            //ejecutar metodo
            InventarioCabeRN.GenerarAjusteInventario(iInvCabEN);
        }

        #endregion

        private void wAjusteInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wInv.Enabled = true;
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
