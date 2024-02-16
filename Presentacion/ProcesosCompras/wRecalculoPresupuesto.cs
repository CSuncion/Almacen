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
using System.Linq;

namespace Presentacion.ProcesosCompras
{
    public partial class wRecalculoPresupuesto : Heredados.MiForm8
    {
        public wRecalculoPresupuesto()
        {
            InitializeComponent();
        }

        //atributos      
        Masivo eMas = new Masivo();
        public string eTitulo = "Recalculo";

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtAñoSal, true, "Año", "vfff", 4);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMesSal, "vvff");
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

            //llenar combos        
            this.CargarMeses();

            // Mostrar ventana
            this.Show();
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            MiControl.MostrarPeriodoActual(this.txtAñoSal, this.cmbMesSal);
            this.txtAñoSal.Focus();
        }

        public void CargarMeses()
        {
            Cmb.Cargar(this.cmbMesSal, ItemGRN.ListarItemsG("Mes"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //recalcular
            this.Recalcular();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El recalculo se realizo correctamente", this.eTitulo);

            //limpiar controles         
            this.cmbMesSal.Focus();
        }

        public void Recalcular()
        {
            //asignar parametro
            string iAño = this.txtAñoSal.Text.Trim();
            string iCodigoMes = Cmb.ObtenerValor(this.cmbMesSal, "");
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            // Lista movimiento por periodo
            List<MovimientoOCDetaEN> lMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            foreach (MovimientoOCDetaEN movDet in lMovDet)
            {
                decimal costo = lMovDet.Where(x => x.CodigoCentroCosto == movDet.CodigoCentroCosto).Sum(s => s.CostoMovimientoDeta);
                //ejecutar metodos                    
                PresupuestoRN.RecalcularPresupuesto(iAño, iCodigoMes, movDet.CodigoCentroCosto, costo);
            }

            List<PresupuestoEN> lPresupuesto = PresupuestoRN.ListarPresupuestos();

            foreach (PresupuestoEN presupuesto in lPresupuesto)
            {
                if (!lMovDet.Exists(x => x.CodigoCentroCosto == presupuesto.CCentroCosto && x.PeriodoMovimientoCabe == presupuesto.CodigoPresupuesto)
                    && iPeriodo == presupuesto.CodigoPresupuesto)
                {
                    PresupuestoRN.RecalcularPresupuestoSinMovimiento(iAño, iCodigoMes, presupuesto.CCentroCosto);
                }
            }
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.iteRecalculoPresupuesto, null);
        }

        #endregion

        private void wRecalculoPresupuesto_FormClosing(object sender, FormClosingEventArgs e)
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
