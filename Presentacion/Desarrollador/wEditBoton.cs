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



namespace Presentacion.Desarrollador
{
    public partial class wEditBoton : Heredados.MiForm8
    {
        public wEditBoton()
        {
            InitializeComponent();
        }

        //variables
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Boton";

        #region Propietario

        public wBoton wBot;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodBot, true, "Codigo", "vfff",3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomBot, true, "Nombre", "vvff",80);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNomCon, true, "Control", "vvff", 300);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCValGri, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstBot, "vvff");
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
         
            //Deshabilitar al propietario de esta ventana
            this.wBot.Enabled = false;
            
            //llenar combos
            this.CargarValidaGrilla();
            this.CargarEstadosBotones();
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Adicionar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarBoton(BotonRN.EnBlanco());            
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodBot.Focus();
        }

        public void VentanaModificar(BotonEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Modificar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarBoton(pObj);        
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtNomBot.Focus();
        }

        public void VentanaEliminar(BotonEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Eliminar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarBoton(pObj);          
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(BotonEN pObj)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Visualizar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarBoton(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnAceptar.Focus();
        }

        public void CargarValidaGrilla()
        {
            Cmb.Cargar(this.cmbCValGri, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadosBotones()
        {
            Cmb.Cargar(this.cmbEstBot, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarBoton(BotonEN pObj)
        {
            pObj.CodigoBoton = this.txtCodBot.Text.Trim();
            pObj.NombreBoton = this.txtNomBot.Text.Trim();
            pObj.NombreControl = this.txtNomCon.Text.Trim();
            pObj.CValidaGrilla = this.cmbCValGri.SelectedValue.ToString();
            pObj.CEstadoBoton = this.cmbEstBot.SelectedValue.ToString();            
        }

        public void MostrarBoton(BotonEN pObj)
        {
            this.txtCodBot.Text = pObj.CodigoBoton;
            this.txtNomBot.Text = pObj.NombreBoton;
            this.txtNomCon.Text = pObj.NombreControl;
            this.cmbCValGri.SelectedValue = pObj.CValidaGrilla;
            this.cmbEstBot.SelectedValue = pObj.CEstadoBoton; 
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

            //el codigo ya existe?
            if (this.EsCodigoBotonDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarBoton();
                     
            //actualizar al wBot
            this.wBot.eClaveDgvBot = this.txtCodBot.Text.Trim();
            this.wBot.ActualizarVentana();

            //limpiar controles
            this.MostrarBoton(BotonRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodBot.Focus();
        }
        
        public void AdicionarBoton()
        {
            BotonEN iBotEN = new BotonEN();
            this.AsignarBoton(iBotEN);
            BotonRN.AdicionarBoton(iBotEN);
        }
                
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wBot.EsBotonExistente().Adicionales.EsVerdad == false) { return; }                       

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarBoton();

            //actualizar al wUsu
            this.wBot.eClaveDgvBot = this.txtCodBot.Text.Trim();
            this.wBot.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarBoton()
        {
            BotonEN iBotEN = new BotonEN();
            this.AsignarBoton(iBotEN);
            iBotEN = BotonRN.BuscarBotonXCodigo(iBotEN);
            this.AsignarBoton(iBotEN);
            BotonRN.ModificarBoton(iBotEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wBot.EsBotonExistente().Adicionales.EsVerdad == false) { return; }                       

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarBoton();
            
            //actualizar al wUsu           
            this.wBot.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarBoton()
        {
            BotonEN iBotEN = new BotonEN();
            this.AsignarBoton(iBotEN);
            BotonRN.EliminarBoton(iBotEN);
        }

        public bool EsCodigoBotonDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            //validar
            BotonEN iBotEN = new BotonEN();
            this.AsignarBoton(iBotEN);
            iBotEN = BotonRN.EsCodigoBotonDisponible(iBotEN);
            if (iBotEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iBotEN.Adicionales.Mensaje, this.eTitulo);
                this.txtCodBot.Clear();
                this.txtCodBot.Focus();
            }
            return iBotEN.Adicionales.EsVerdad;
        }       
        
        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }
        
        #endregion

        private void wEditBoton_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wBot.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodBot_Validated(object sender, EventArgs e)
        {
            this.EsCodigoBotonDisponible();
        }
        
    }
}
