using Entidades;
using Heredados;
using Negocio;
using Negocio.Contabilidad;
using Presentacion.FuncionesGenericas;
using Presentacion.Principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace Presentacion.ProcesosCompras
{
    public partial class wExportarOrdenCompraAContabilidad : MiForm8
    {

        Masivo eMas = new Masivo();
        public string eTitulo = "Exportaciones";
        public wExportarOrdenCompraAContabilidad()
        {
            InitializeComponent();
        }
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
        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.iteExportarOrdComAConta, null);
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
            RegContabCabe_Cont_RN.ExportarOrdenCompraAContabilidad(iPeriodo);
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wExportarOrdenCompraAContabilidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }
    }
}
