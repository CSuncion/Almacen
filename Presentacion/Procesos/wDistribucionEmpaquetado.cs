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
    public partial class wDistribucionEmpaquetado : Heredados.MiForm8
    {
        public wDistribucionEmpaquetado()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public string eTitulo = "Cantidad";

        #endregion

        #region Propietario

        //public wParteTrabajo wParTra;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosEmpPri,this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosEmpAdi, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosEmpDev, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosEmpTot, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumUniSemEla, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosUniSemEla, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumUniProTer, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosUniProTer, this.btnAceptar, "fffff");
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
            //this.wParTra.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana(ProduccionDetaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pObj);
            this.MostrarCalculos(pObj);
            this.btnAceptar.Focus();
        }

        public void AsignarProduccionDeta(ProduccionDetaEN pObj)
        {
            pObj.CostoEmpaquetadoSemElaPrincipal = Conversion.ADecimal(this.txtCosEmpPri.Text, 0);
            pObj.CostoEmpaquetadoSemElaAdicional = Conversion.ADecimal(this.txtCosEmpAdi.Text, 0);
            pObj.CostoEmpaquetadoSemElaDevolucion = Conversion.ADecimal(this.txtCosEmpDev.Text, 0);
            pObj.CostoEmpaquetadoSemElaTotal = Conversion.ADecimal(this.txtCosEmpTot.Text, 0);          
            pObj.NumeroUnidadesSueltas = Conversion.ADecimal(this.txtNumUniSemEla.Text, 0);           
            pObj.CostoUnidadEmpaquetadoSemEla = Conversion.ADecimal(this.txtCosUniSemEla.Text, 0);
            pObj.NumeroUnidadesAEmpaquetar = Conversion.ADecimal(this.txtNumUniProTer.Text, 0);
            pObj.CostoUnidadEmpaquetadoProTer = Conversion.ADecimal(this.txtCosUniProTer.Text, 0);
        }

        public void MostrarProduccionDeta(ProduccionDetaEN pObj)
        {
            this.txtCosEmpPri.Text = Formato.NumeroDecimal(pObj.CostoEmpaquetadoSemElaPrincipal,2);
            this.txtCosEmpAdi.Text = Formato.NumeroDecimal(pObj.CostoEmpaquetadoSemElaAdicional, 2);
            this.txtCosEmpDev.Text = Formato.NumeroDecimal(pObj.CostoEmpaquetadoSemElaDevolucion, 2);
            this.txtCosEmpTot.Text = Formato.NumeroDecimal(pObj.CostoEmpaquetadoSemElaTotal, 2);
            this.txtNumUniSemEla.Text = Formato.NumeroDecimal(pObj.NumeroUnidadesSueltas, 0);
            this.txtCosUniSemEla.Text = Formato.NumeroDecimal(pObj.CostoUnidadEmpaquetadoSemEla, 2);
            this.txtNumUniProTer.Text = Formato.NumeroDecimal(pObj.NumeroUnidadesAEmpaquetar, 0);
            this.txtCosUniProTer.Text = Formato.NumeroDecimal(pObj.CostoUnidadEmpaquetadoProTer, 2);
        }

        public ProduccionDetaEN NuevoProduccionDetaDeVentana()
        {
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            this.AsignarProduccionDeta(iProDetEN);
            return iProDetEN;
        }

        public void MostrarCalculos(ProduccionDetaEN pObj)
        {
            this.MostrarCostoEmpaquetadoPrincipal(pObj.ClaveProduccionDeta);
            this.MostrarCostoEmpaquetadoTotal();
            this.MostrarCostoUnidadSemiElaborado(pObj);
            this.MostrarNumeroUnidadesProductosTerminados(pObj);
            this.MostrarCostoUnidadProductoTerminado(pObj);
            
        }

        public void MostrarCostoEmpaquetadoPrincipal(string pClaveProduccionDeta)
        {
            //asignar parametros
            string iClaveProduccionDeta = pClaveProduccionDeta;

            //ejecutar metodo
            decimal iCosto = ProduccionExisRN.ObtenerCostoTotalFaseEmpaquetado(iClaveProduccionDeta);

            //mostrar en pantalla
            this.txtCosEmpPri.Text = Formato.NumeroDecimal(iCosto, 2);
        }

        public void MostrarCostoEmpaquetadoTotal()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevoProduccionDetaDeVentana();

            //ejecutar metodo
            decimal iCosto = ProduccionDetaRN.ObtenerCostoEmpaquetadoTotal(iProDetEN);

            //mostrar en pantalla
            this.txtCosEmpTot.Text = Formato.NumeroDecimal(iCosto, 2);
        }

        public void MostrarCostoUnidadSemiElaborado(ProduccionDetaEN pObj)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = pObj;

            //ejecutar metodo
            decimal iCosto = ProduccionDetaRN.ObtenerCostoUnidadEmpaquetadoSemiElaborado(iProDetEN);

            //mostrar en pantalla
            this.txtCosUniSemEla.Text = Formato.NumeroDecimal(iCosto, 2);
        }

        public void MostrarNumeroUnidadesProductosTerminados(ProduccionDetaEN pObj)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = pObj;

            //ejecutar metodo
            decimal iCantidad = ProduccionDetaRN.ObtenerNumeroUnidadesProoductosTerminados(iProDetEN);

            //mostrar en pantalla
            this.txtNumUniProTer.Text = Formato.NumeroDecimal(iCantidad, 0);
        }

        public void MostrarCostoUnidadProductoTerminado(ProduccionDetaEN pObj)
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = pObj;
            this.AsignarProduccionDeta(pObj);

            //ejecutar metodo
            decimal iCosto = ProduccionDetaRN.ObtenerCostoUnidadEmpaquetadoSoloCaja(iProDetEN);

            //mostrar en pantalla
            this.txtCosUniProTer.Text = Formato.NumeroDecimal(iCosto, 2);
        }
        
        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }
            
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarProduccionDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico el parte de trabajo", this.eTitulo);

            //cerrar esta ventana         
            this.Close();
        }

        public void ModificarProduccionDeta()
        {
            //traer al ProduccionDeta de b.d
            //ProduccionDetaEN iProDetEN = this.wParTra.EsProduccionDetaExistente();

            //modificar datos
            //this.AsignarProduccionDeta(iProDetEN);

            ////ejecutar metodo
            //ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        #endregion

        private void wDistribucionEmpaquetado_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wParTra.Enabled = true;
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
