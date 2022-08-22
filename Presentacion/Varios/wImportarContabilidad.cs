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

namespace Presentacion.Varios
{
    public partial class wImportarContabilidad : Heredados.MiForm8
    {
        public wImportarContabilidad()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public string eTitulo = "Importacion";

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

            //validar periodo
            if (this.ValidaPeriodo() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }
            
            //importar de contabilidad
            this.Importar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("la importacion se realizo correctamente", this.eTitulo);

            //limpiar controles         
            this.cmbMesSal.Focus();
        }

        public void Importar()
        {
            //asignar parametro
            string iPeriodo = MiControl.ObtenerFormatoPeriodo(this.txtAñoSal, this.cmbMesSal);
                      
            //ejecutar metodo
            MovimientoCabeRN.ImportarDeContabilidad(iPeriodo);
        }

        public bool ValidaPeriodo()
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = MiControl.ObtenerFormatoPeriodo(this.txtAñoSal, this.cmbMesSal);

            //ejecutar metodo
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iMovCabEN);

            //mensaje de error
            Generico.MostrarMensajeError(iMovCabEN.Adicionales, this.cmbMesSal);

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteImpContabilidad, null);
        }

        #endregion

        private void wImportarContabilidad_FormClosing(object sender, FormClosingEventArgs e)
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
