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
    public partial class wRecalculoProduccion : Heredados.MiForm8
    {
        public wRecalculoProduccion()
        {
            InitializeComponent();
        }

        //atributos      
        Masivo eMas = new Masivo();
        public string eTitulo = "Recalculo Producciones";

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
          
            //ejecutar metodos
            ProduccionDetaRN.RecalcularProducciones(iAño, iCodigoMes);                        
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteRecalculoProduccion, wMen.tsbRecalculo);
        }

        #endregion

        private void wRecalculoProduccion_FormClosing(object sender, FormClosingEventArgs e)
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
