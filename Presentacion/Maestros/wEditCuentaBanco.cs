using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.Listas;
using Presentacion.Principal;
using Presentacion.Maestros;
using System.IO;
using Presentacion.FuncionesGenericas;


namespace Presentacion
{
    public partial class wEditCuentaBanco : Heredados.MiForm4
    {
        public wEditCuentaBanco()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Cuenta Banco";

        #endregion

        #region Propietario

        public wCuentaBanco wCtaBco;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodCtaBco, true, "Codigo Cuenta Banco", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCodBco, true, "Codigo Banco", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomBco, this.txtCodBco, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.TxtAgeCb, true, "Alias", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumCtaBco, true, "N°.Cuenta Banco", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtClaCtaBco, true, "Sucursal", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCtaSco, false, "Cuenta Scotibank", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtNumeroCtaBanco, true, "Numero", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMonCtaBco, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTipoCtaBco, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.TxtSaldo, false, "Saldo", "ffff", 2);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion(this.txtCtaCon, true, "Cuenta Contable", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtConEnv, false, "Concepto Envio", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstCtaBco, "vvff");
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

            // llenar combos
            this.CargarMonedaCtaBco();
            this.CargarTipoCtaBco();
            this.CargarEstadoCtaBco();

            //deshabilita propietario
            this.wCtaBco.Enabled = false;

            //ver ventana
            this.Show();
        }

        public void CargarMonedaCtaBco()
        {
            Cmb.Cargar(this.cmbMonCtaBco, ItemGRN.ListarItemsG("Moneda"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarTipoCtaBco()
        {
            Cmb.Cargar(this.cmbTipoCtaBco, ItemGRN.ListarItemsG("TipCta"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadoCtaBco()
        {
            Cmb.Cargar(this.cmbEstCtaBco, ItemGRN.ListarItemsG("EstCte"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Adicionar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarCuentaBanco(CuentaBancoRN.EnBlanco());
            this.txtCodCtaBco.Focus();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();

        }

        public void VentanaModificar(CuentaBancoEN pCtaBco)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Modificar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarCuentaBanco(pCtaBco);
            this.txtCodBco.Focus();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
        }

        public void VentanaEliminar(CuentaBancoEN pCtaBco)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Eliminar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarCuentaBanco(pCtaBco);
            this.btnAceptar.Focus();
            eMas.AccionHabilitarControles(2);
            eMas.AccionPasarTextoPrincipal();
        }

        public void VentanaVisualizar(CuentaBancoEN pCtaBco)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Visualizar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarCuentaBanco(pCtaBco);
            this.btnAceptar.Focus();
            eMas.AccionHabilitarControles(3);
            eMas.AccionPasarTextoPrincipal();
        }

        public void MostrarCuentaBanco(CuentaBancoEN pCtaBco)
        {
            this.txtCodCtaBco.Text = pCtaBco.CodigoCuentaBanco;
            this.txtCodBco.Text = pCtaBco.CodigoBanco;
            this.txtNomBco.Text = pCtaBco.NombreBanco;
            this.txtNumCtaBco.Text = pCtaBco.NumeroCuentaBanco;
            this.TxtAgeCb.Text = pCtaBco.AgenciaCuentaBanco;
            this.txtClaCtaBco.Text = pCtaBco.ClaveCuentaBancaria;
            this.txtNumeroCtaBanco.Text = pCtaBco.NumeroCuentaBancaria;
            this.TxtSaldo.Text = pCtaBco.SaldoCuentaBanco.ToString();
            this.cmbMonCtaBco.SelectedValue = pCtaBco.MonedaCuentaBanco;
            this.cmbTipoCtaBco.SelectedValue = pCtaBco.TipoCuentaBanco;
            this.TxtSaldo.Text = pCtaBco.SaldoCuentaBanco.ToString();
            this.txtCtaCon.Text = pCtaBco.CuentaContable;
            this.txtConEnv.Text = pCtaBco.ConceptoEnvio;
            this.txtCtaSco.Text = pCtaBco.CuentaScotiaCuentaBanco;
            this.cmbEstCtaBco.SelectedValue = pCtaBco.EstadoCuentaBanco;
        }

        public void AsignarCuentaBanco(CuentaBancoEN pCtaBco)
        {
            pCtaBco.CodigoCuentaBanco = this.txtCodCtaBco.Text.Trim();
            pCtaBco.CodigoEmpresa = Universal.gCodigoEmpresa;
            pCtaBco.CodigoBanco = this.txtCodBco.Text.Trim();
            pCtaBco.NombreBanco = this.txtNomBco.Text.Trim();
            pCtaBco.AgenciaCuentaBanco = this.TxtAgeCb.Text.Trim();
            pCtaBco.NumeroCuentaBanco = this.txtNumCtaBco.Text.Trim();
            pCtaBco.ClaveCuentaBancaria = this.txtClaCtaBco.Text.Trim();
            pCtaBco.NumeroCuentaBancaria = this.txtNumeroCtaBanco.Text.Trim();
            pCtaBco.MonedaCuentaBanco = this.cmbMonCtaBco.SelectedValue.ToString();
            pCtaBco.EstadoCuentaBanco = this.cmbEstCtaBco.SelectedValue.ToString();
            pCtaBco.TipoCuentaBanco = this.cmbTipoCtaBco.SelectedValue.ToString();
            pCtaBco.SaldoCuentaBanco = Convert.ToDecimal(this.TxtSaldo.Text);
            pCtaBco.CuentaContable = this.txtCtaCon.Text.Trim();
            pCtaBco.ConceptoEnvio = this.txtConEnv.Text.Trim();
            pCtaBco.CuentaScotiaCuentaBanco = this.txtCtaSco.Text.Trim();
            pCtaBco.ClaveCuentaBanco = CuentaBancoRN.ObtenerClaveCuentaBanco(pCtaBco);
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

            //validar el numero documento que no existe en otro cliente         
            if (this.EsCuentaBancoDisponible(true) == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionar mensaje
            this.AdicionarCuentaBanco();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La cuenta bancaria se adiciono correctamente", "Cuenta Bancaria");

            //actualizar al wCte       
            CuentaBancoEN iCueBanEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iCueBanEN);
            this.wCtaBco.eClaveDgvCta = iCueBanEN.ClaveCuentaBanco;
            this.wCtaBco.ActualizarVentana();

            //limpiar controles
            this.MostrarCuentaBanco(CuentaBancoRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodCtaBco.Focus();
        }

        public void AdicionarCuentaBanco()
        {
            CuentaBancoEN iCtaBcoEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iCtaBcoEN);
            CuentaBancoRN.AdicionarCuentaBanco(iCtaBcoEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si el participante existe
            if (this.wCtaBco.EsCuentaBancoExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar participante
            this.ModificarCuentaBanco();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La cuenta bancaria se modifico correctamente", "Cuenta Bancaria");

            //actualizar al wCte           
            CuentaBancoEN iCueBanEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iCueBanEN);
            this.wCtaBco.eClaveDgvCta = iCueBanEN.ClaveCuentaBanco;
            this.wCtaBco.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarCuentaBanco()
        {
            CuentaBancoEN iCtaBcoEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iCtaBcoEN);
            iCtaBcoEN = CuentaBancoRN.BuscarCuentaBancoXClave(iCtaBcoEN);
            this.AsignarCuentaBanco(iCtaBcoEN);
            CuentaBancoRN.ModificarCuentaBanco(iCtaBcoEN);
        }

        public void Eliminar()
        {
            //preguntar si el mensaje existe
            if (this.wCtaBco.EsCuentaBancoExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar particpante
            this.EliminarCuentaBanco();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La cuenta bancaria se elimino correctamente", "Cuenta Bancaria");

            //actualizar al wCte           
            this.wCtaBco.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarCuentaBanco()
        {
            CuentaBancoEN iCtaBcoEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iCtaBcoEN);
            CuentaBancoRN.EliminarCuentaBancoXClave(iCtaBcoEN);
        }

        public bool EsCuentaBancoDisponible(bool pVacio)
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }
            //
            CuentaBancoEN iCtaBcoEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iCtaBcoEN);
            iCtaBcoEN = CuentaBancoRN.EsCodigoCuentaBancoDisponible(iCtaBcoEN, pVacio);
            if (iCtaBcoEN.Adicionales.EsVerdad == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show(iCtaBcoEN.Adicionales.Mensaje, "Cuenta Banco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCodBco.Clear();
                this.txtCodBco.Focus();
                return false;
            }
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }

        public void ListarBancos()
        {
            //solo cuando adiciona
            if (this.eOperacion != Universal.Opera.Adicionar && this.eOperacion != Universal.Opera.Modificar) { return; }

            //instanciar
            wLisBco win = new wLisBco();
            win.eVentana = this;
            win.eTituloVentana = "Bancos";
            win.eCtrlValor = this.txtCodBco;
            win.eCtrlFoco = this.TxtAgeCb;
            win.eCondicionLista = Listas.wLisBco.Condicion.Bancos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsBancoValido()
        {
            //solo se ejecuta cuando adiciona
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            //validar el codigo proyecto
            BancoEN iBanEN = new BancoEN();
            iBanEN.CodigoBanco = this.txtCodBco.Text.Trim();
            iBanEN = BancoRN.EsBancoValido(iBanEN);
            if (iBanEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iBanEN.Adicionales.Mensaje, "Banco");
                this.txtCodBco.Focus();
            }

            //mostrar datos
            this.txtCodBco.Text = iBanEN.CodigoBanco;
            this.txtNomBco.Text = iBanEN.NombreBanco;

            //devolver
            return iBanEN.Adicionales.EsVerdad;
        }

        #endregion



        private void wEditCuentaBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wCtaBco.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodOcu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.ListarBancos();
            }
        }

        private void txtCodOcu_DoubleClick(object sender, EventArgs e)
        {
            this.ListarBancos();
        }

        private void txtCodBco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.ListarBancos();
            }
        }

        private void txtCodBco_DoubleClick(object sender, EventArgs e)
        {
            this.ListarBancos();
        }

        private void txtCodBco_Validating(object sender, CancelEventArgs e)
        {
            this.EsBancoValido();
        }

        private void txtCodCtaBco_Validating(object sender, CancelEventArgs e)
        {
            this.EsCuentaBancoDisponible(false);
        }


    }
}
