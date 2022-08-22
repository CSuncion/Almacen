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
    public partial class wEleccionSegundaLiberacion : Heredados.MiForm8
    {
        public wEleccionSegundaLiberacion()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string eTitulo = "Estado";
        
        #endregion

        #region Propietario

        public wSegundaLiberacion wSegLib;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodExi, this.cmbEstSegLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.cmbEstSegLib, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstSegLib, "vvvf");
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

            //cargar combos
            this.CargarEstadosSegundaLiberacion();

            //deshabilitar propietario
            this.wSegLib.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void CargarEstadosSegundaLiberacion()
        {
            Cmb.Cargar(this.cmbEstSegLib, ItemGRN.ListarItemsG("ElSeLi"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }
        
        public void VentanaModificar(ProduccionProTerEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionProTer(pObj);            
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.cmbEstSegLib.Focus();
        }
        
        public void AsignarProduccionProTer(ProduccionProTerEN pObj)
        {
            pObj.CEleccionSegundaLiberacion = Cmb.ObtenerValor(this.cmbEstSegLib, "");            
            pObj.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);                    
        }

        public void MostrarProduccionProTer(ProduccionProTerEN pObj)
        {
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;
            Cmb.SeleccionarValorItem(this.cmbEstSegLib, pObj.CEleccionSegundaLiberacion);                 
        }

        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }
            
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wSegLib.eTitulo) == false) { return; }
            
            //modificar el registro ProduccionProTer    
            this.ModificarProduccionProTer();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la ProduccionProTer correctamente", this.wSegLib.eTitulo);

            //actualizar al propietario wProduccionProTer         
            this.wSegLib.eClaveDgvProProTer = this.ObtenerClaveProduccionProTer();
            this.wSegLib.ActualizarVentana();
            
            //salir de la ventana
            this.Close();
        }

        public void ModificarProduccionProTer()
        {
            //traer al ProduccionProTer de b.d
            ProduccionProTerEN iProDetEN = this.wSegLib.EsProduccionProTerExistente();

            //modificar datos
            this.AsignarProduccionProTer(iProDetEN);

            //ejecutar metodo
            ProduccionProTerRN.ModificarProduccionProTer(iProDetEN);
        }
        
        public ProduccionProTerEN NuevoProduccionProTerDeVentana()
        {
            ProduccionProTerEN iProDetEN = new ProduccionProTerEN();
            this.AsignarProduccionProTer(iProDetEN);
            return iProDetEN;
        }

        public string ObtenerClaveProduccionProTer()
        {
            //asignar parametros
            ProduccionProTerEN iLebEN = this.NuevoProduccionProTerDeVentana();

            //devolver
            return iLebEN.ClaveProduccionProTer;
        }
     
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wSegLib.eTitulo);
        }

        #endregion

        private void wEleccionSegundaLiberacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wSegLib.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
         

    }
}
