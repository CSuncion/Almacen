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
    public partial class wMasaPerdida : Heredados.MiForm8
    {
        public wMasaPerdida()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
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
            xCtrl.TxtNumeroPositivoConDecimales(this.txtMasPer, false, "Masa perdida", "vvff", 0, 18);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtObsMasPer, false, "Observacion", "vvfff", 150);
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
            //actualizar a eOperacion al ingresar a la ventana
            this.ActualizareOperacion(pObj);

            //segun eOperacion
            switch (this.eOperacion)
            {                
                case Universal.Opera.Modificar: { this.VentanaModificar(pObj); break; }
                case Universal.Opera.Visualizar: { this.VentanaVisualizar(pObj); break; }
                default: break;
            }           
        }

        public void VentanaModificar(ProduccionDetaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pObj);        
            eMas.AccionHabilitarControles(1);
            this.txtMasPer.Focus();
        }

        public void VentanaVisualizar(ProduccionDetaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pObj);
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void ActualizareOperacion(ProduccionDetaEN pObj)
        {
            if (pObj.NumeroUnidadesConCal == 0)
            {
                this.eOperacion = Universal.Opera.Modificar;
            }
            else
            {
                this.eOperacion = Universal.Opera.Visualizar;
            }
        }

        public void AsignarProduccionDeta(ProduccionDetaEN pObj)
        {           
            pObj.MasaPerdida = Conversion.ADecimal(this.txtMasPer.Text, 0);
            pObj.ObservacionMasaPerdida = this.txtObsMasPer.Text.Trim();       
        }

        public void MostrarProduccionDeta(ProduccionDetaEN pObj)
        {
            this.txtMasPer.Text = Formato.NumeroDecimal(pObj.MasaPerdida, 0);
            this.txtObsMasPer.Text = pObj.ObservacionMasaPerdida;
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
            Mensaje.OperacionSatisfactoria("Se modifico la cantidad", this.eTitulo);

            //cerrar esta ventana         
            this.Close();
        }

        public void ModificarProduccionDeta()
        {
            //traer al ProduccionDeta de b.d
            //ProduccionDetaEN iProDetEN = this.wParTra.EsProduccionDetaExistente();

            //modificar datos
            //this.AsignarProduccionDeta(iProDetEN);

            ////actualizar costo fase masa
            //ProduccionDetaRN.ActualizarCostosFaseMasa(iProDetEN);

            ////ejecutar metodo
            //ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        #endregion

        private void wMasaPerdida_FormClosing(object sender, FormClosingEventArgs e)
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
