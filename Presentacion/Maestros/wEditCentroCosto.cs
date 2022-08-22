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


namespace Presentacion.Maestros
{
    public partial class wEditCentroCosto : Heredados.MiForm8
    {
        public wEditCentroCosto()
        {
            InitializeComponent();
        }

        //atributos
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
       

        #region Propietario

        public wCentroCosto wCenCos;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodCenCos, true, "Codigo", "vfff",6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesCenCos, true, "Descripcion", "vvff",100);
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstCenCos, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wCenCos.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos        
            this.CargarEstadosCentroCosto();

            // Deshabilitar al propietario
            this.wCenCos.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarCentroCosto(CentroCostoRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodCenCos.Focus();
        }

        public void VentanaModificar(CentroCostoEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarCentroCosto(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDesCenCos.Focus();
        }

        public void VentanaEliminar(CentroCostoEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarCentroCosto(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(CentroCostoEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarCentroCosto(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void CargarEstadosCentroCosto()
        {
            Cmb.Cargar(this.cmbEstCenCos, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarCentroCosto(CentroCostoEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoCentroCosto = this.txtCodCenCos.Text.Trim();
            pObj.DescripcionCentroCosto = this.txtDesCenCos.Text.Trim();
            pObj.CEstadoCentroCosto = Cmb.ObtenerValor(this.cmbEstCenCos, string.Empty);
            pObj.ClaveCentroCosto = CentroCostoRN.ObtenerClaveCentroCosto(pObj);
        }

        public void MostrarCentroCosto(CentroCostoEN pObj)
        {
            this.txtCodCenCos.Text = pObj.CodigoCentroCosto;
            this.txtDesCenCos.Text = pObj.DescripcionCentroCosto;
            this.cmbEstCenCos.SelectedValue = pObj.CEstadoCentroCosto;
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

            //el codigo de usuario ya existe?
            if (this.EsCodigoCentroCostoDisponible() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCenCos.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarCentroCosto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Centro Costo se adiciono correctamente", this.wCenCos.eTitulo);
                     
            //actualizar al propietario
            this.wCenCos.eClaveDgvCeCo = this.ObtenerClaveCentroCosto();
            this.wCenCos.ActualizarVentana();

            //limpiar controles
            this.MostrarCentroCosto(CentroCostoRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();         
            this.txtCodCenCos.Focus();
        }
        
        public void AdicionarCentroCosto()
        {
            CentroCostoEN iPerEN = new CentroCostoEN();
            this.AsignarCentroCosto(iPerEN);
            CentroCostoRN.AdicionarCentroCosto(iPerEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wCenCos.EsActoModificarCentroCosto().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCenCos.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarCentroCosto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Centro Costo se modifico correctamente", this.wCenCos.eTitulo);

            //actualizar al wUsu
            this.wCenCos.eClaveDgvCeCo = this.ObtenerClaveCentroCosto();
            this.wCenCos.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarCentroCosto()
        {
            CentroCostoEN iPerEN = new CentroCostoEN();
            this.AsignarCentroCosto(iPerEN);
            iPerEN = CentroCostoRN.BuscarCentroCostoXClave(iPerEN);
            this.AsignarCentroCosto(iPerEN);
            CentroCostoRN.ModificarCentroCosto(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wCenCos.EsActoEliminarCentroCosto().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wCenCos.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarCentroCosto();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Centro Costo se elimino correctamente", this.wCenCos.eTitulo);

            //actualizar al propietario           
            this.wCenCos.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarCentroCosto()
        {
            CentroCostoEN iPerEN = new CentroCostoEN();
            this.AsignarCentroCosto(iPerEN);
            CentroCostoRN.EliminarCentroCosto(iPerEN);
        }
                
        public bool EsCodigoCentroCostoDisponible()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            CentroCostoEN iPerEN = new CentroCostoEN();
            this.AsignarCentroCosto(iPerEN);
            iPerEN = CentroCostoRN.EsCodigoCentroCostoDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wCenCos.eTitulo);
                this.txtCodCenCos.Clear();
                this.txtCodCenCos.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }
             
        public string ObtenerClaveCentroCosto()
        {
            CentroCostoEN iCenCosEN = new CentroCostoEN();
            this.AsignarCentroCosto(iCenCosEN);
            return iCenCosEN.ClaveCentroCosto;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wCenCos.eTitulo);
        }
        
        #endregion

        private void wEditCentroCosto_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCenCos.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodCenCos_Validated(object sender, EventArgs e)
        {
            this.EsCodigoCentroCostoDisponible();
        }
        
    }
}
