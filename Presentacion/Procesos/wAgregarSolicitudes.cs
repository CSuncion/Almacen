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
using Entidades;
using Negocio;


namespace Presentacion.Procesos
{
    public partial class wAgregarSolicitudes : Heredados.MiForm8
    {
        public wAgregarSolicitudes()
        {
            InitializeComponent();
        }

        #region Variables

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<ProduccionCabeEN> eLisProCab = new List<ProduccionCabeEN>();
        
        #endregion
        
        #region Propietario

        public wAprobarSolicitud wAprSol;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;                                  

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
         
            // Deshabilitar al propietario de esta ventana
            this.wAprSol.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }                

        public void VentanaAgregar()
        {
            this.InicializaVentana();
            this.Text = "Agregar Solicitudes";
            this.lblTit.Text = "Solicitudes para agregar a la ventana";         
            this.ActualizarDgvSol(true);
            this.btnAceptar.Focus();
        }

        public void VentanaQuitar()
        {
            this.InicializaVentana();
            this.Text = "Quitar Solicitudes";
            this.lblTit.Text = "Solicitudes para quitar a la ventana";
            this.ActualizarDgvSol(true);
            this.btnAceptar.Focus();
        }

        public void VentanaDesaprobar()
        {
            this.InicializaVentana();
            this.Text = "Desaprobar Solicitudes";
            this.lblTit.Text = "Solicitudes para desaprobar a la ventana";
            this.ActualizarDgvSol(true);
            this.btnAceptar.Focus();
        }

        public void ActualizarDgvSol(bool pBaseDatos)
        {
            //solo si va a base de datos entra
            if (pBaseDatos == true)
            {
                //segun agregar o quitar
                if (this.eOperacion == Universal.Opera.Adicionar)
                {
                    eLisProCab = ProduccionCabeRN.ListarProduccionCabeEstadoPlanificacion();
                }
                else
                {
                    if (this.eOperacion == Universal.Opera.Eliminar)
                    {
                        eLisProCab = ProduccionCabeRN.ListarProduccionCabeEstadoCompra();
                    }
                    else
                    {
                        eLisProCab = ProduccionCabeRN.ListarProduccionCabeEstadoAprobado();
                    }
                }
            }                

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvBot;
            iDgv.RefrescarDatosGrilla(eLisProCab);
            //asignar columnas
            iDgv.AsignarColumnaCheckBox(ProduccionCabeEN.VerFal, "Agregar", 57);
            iDgv.AsignarColumnaTextCadena(ProduccionCabeEN.CorProCab, "Numero", 70);
            iDgv.AsignarColumnaTextCadena(ProduccionCabeEN.FecProCab, "Fecha", 70);
            iDgv.AsignarColumnaTextCadena(ProduccionCabeEN.DesExi, "Formula", 250);
            iDgv.AsignarColumnaTextCadena(ProduccionCabeEN.ClaObj, "ClaveObjeto", 10, false);
        }

        public void ModificarProduccionCabe()
        {
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.ClaveProduccionCabe = Dgv.ObtenerValorCelda(this.DgvBot, ProduccionCabeEN.ClaObj);
            iProCabEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvBot, ProduccionCabeEN.VerFal);
            ProduccionCabeRN.ModificarProduccionCabe(iProCabEN, this.eLisProCab);
        }
        
        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Agregar(); break; }
                case Universal.Opera.Modificar: { this.Desaprobar(); break; }
                case Universal.Opera.Eliminar: { this.Quitar(); break; }
                default: break;
            }
        }

        public void Agregar()
        { 
            //sacar solo los que marco el usuario
            List<ProduccionCabeEN> iLisObjMar = this.SacarSoloMarcados();                    

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Solicitudes") == false) { return; }

            //agregar los botones a la ventana
            ProduccionCabeRN.ModificarProduccionCabeAEstadoCompra(iLisObjMar);
                       
            //actualizar ventana propietario
            this.wAprSol.ActualizarDgvSol();
            //this.wAprSol.wVen.ActualizarVentana();

            //cerrar
            this.Close();

        }             
    
        public void Quitar()
        {
            //sacar solo los que marco el usuario
            List<ProduccionCabeEN> iLisObjMar = this.SacarSoloMarcados();

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Quitar Solicitudes") == false) { return; }

            //quitar los botones a la ventana
            ProduccionCabeRN.ModificarProduccionCabeAEstadoPlanificacion(iLisObjMar);

            //actualizar ventana propietario
            this.wAprSol.ActualizarDgvSol();
            //this.wAprSol.wVen.ActualizarVentana();

            //cerrar
            this.Close();

        }

        public void Desaprobar()
        {
            //sacar solo los que marco el usuario
            List<ProduccionCabeEN> iLisObjMar = this.SacarSoloMarcados();

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Desaprobar Solicitudes") == false) { return; }

            //quitar los botones a la ventana
            ProduccionCabeRN.ModificarProduccionCabeAEstadoCompra(iLisObjMar);

            //actualizar ventana propietario
            this.wAprSol.ActualizarDgvSol();
            //this.wAprSol.wVen.ActualizarVentana();

            //cerrar
            this.Close();
        }

        public void MarcarTodos()
        {
            ProduccionCabeRN.MarcarTodos(this.eLisProCab, true);
            this.ActualizarDgvSol(false);
        }

        public void DesmarcarTodos()
        {
            ProduccionCabeRN.MarcarTodos(this.eLisProCab, false);
            this.ActualizarDgvSol(false);
        }

        public List<ProduccionCabeEN> SacarSoloMarcados()
        {
            //esta operacion actualiza a la lista eLisVenBot,obteniendo solo
            //los objetos marcados por el usuario
            return ProduccionCabeRN.ListarVentanaProduccionCabeSoloMarcadas(this.eLisProCab);
        }

        public bool HayMarcados(List<ProduccionCabeEN> pLista)
        {
           //ver si hay marcados
            if (pLista.Count == 0)
            {
                Mensaje.OperacionDenegada("Debes marcar al menos una solicitud, no se puede realizar la operacion","Solicitudes");
                return false;
            }
            return true;           
        }
     
        #endregion

        private void wAgregarSolicitudes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wAprSol.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvBot_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarProduccionCabe();
        }

        private void btnMarcarTodas_Click(object sender, EventArgs e)
        {
            this.MarcarTodos();
        }

        private void btnDesmarcarTodas_Click(object sender, EventArgs e)
        {
            this.DesmarcarTodos();
        }
    }
}
