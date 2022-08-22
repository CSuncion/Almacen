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


namespace Presentacion.Desarrollador
{
    public partial class wAgregarBotones : Heredados.MiForm4
    {
        public wAgregarBotones()
        {
            InitializeComponent();
        }

        //variables     
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<VentanaBotonEN> eLisVenBot = new List<VentanaBotonEN>();
               
        #region Propietario

        public wBotonesVentana wBotVen;

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
            this.wBotVen.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }                

        public void VentanaAgregar()
        {
            this.InicializaVentana();
            this.Text = "Agregar Botones";
            this.lblTit.Text = "Botones para agregar a la ventana";         
            this.ActualizarDgvBot();
            this.btnAceptar.Focus();
        }

        public void VentanaQuitar()
        {
            this.InicializaVentana();
            this.Text = "Quitar Botones";
            this.lblTit.Text = "Botones para quitar a la ventana";
            this.ActualizarDgvBot();
            this.btnAceptar.Focus();
        }

        public void ActualizarDgvBot()
        {          
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();           
            iVenBotEN.CodigoVentana = this.wBotVen.txtCodVen.Text.Trim();
            iVenBotEN.Adicionales.CampoOrden = VentanaBotonEN.CodBot;

            //segun agregar o quitar
            if (this.eOperacion == Universal.Opera.Adicionar)
            {
                eLisVenBot = VentanaBotonRN.ListarVentanaBotonesParaAgregarAVentana(iVenBotEN);
            }
            else
            {
                eLisVenBot = VentanaBotonRN.ListarVentanaBotonesXVentana(iVenBotEN);
            }            

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvBot;
            iDgv.RefrescarDatosGrilla(eLisVenBot);
            //asignar columnas
            iDgv.AsignarColumnaCheckBox(VentanaBotonEN.VerFal, "Agregar", 57);
            iDgv.AsignarColumnaTextCadena(VentanaBotonEN.NomBot, "Nombre", 187);
            iDgv.AsignarColumnaTextCadena(VentanaBotonEN.ClaObj, "ClaveObjeto", 10, false);
        }

        public void ModificarVentanaBoton()
        {           
            VentanaBotonEN iVenBotEN = new VentanaBotonEN();
            iVenBotEN.ClaveVentanaBoton = Dgv.ObtenerValorCelda(this.DgvBot, VentanaBotonEN.ClaObj);
            iVenBotEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvBot, VentanaBotonEN.VerFal);
            VentanaBotonRN.ModificarVentanaBoton(iVenBotEN, this.eLisVenBot);
        }
        
        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Agregar(); break; }         
                case Universal.Opera.Eliminar: { this.Quitar(); break; }
                default: break;
            }
        }

        public void Agregar()
        { 
            //sacar solo los que marco el usuario
            List<VentanaBotonEN> iLisObjMar = this.SacarSoloMarcados();                    

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Botones") == false) { return; }

            //agregar los botones a la ventana
            VentanaBotonRN.AdicionarVentanaBotonMasivo(iLisObjMar);

            //agregar a permisos usuario
            PermisoUsuarioRN.AdicionarPermisosUsuarioXVentanaBoton(iLisObjMar);

            //agregar a permisos perfiles
            PermisoPerfilRN.AdicionarPermisosPerfilXVentanaBoton(iLisObjMar);

            //actualizar ventana propietario
            this.wBotVen.ActualizarDgvBot();

            //cerrar
            this.Close();

        }             
    
        public void Quitar()
        {
            //sacar solo los que marco el usuario
            List<VentanaBotonEN> iLisObjMar = this.SacarSoloMarcados();

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Quitar Botones") == false) { return; }

            //quitar los botones a la ventana
            this.QuitarVentanaBotones(iLisObjMar);

            //quitar a permisos usuario
            this.QuitarPermisosUsuario(iLisObjMar);

            //quitar a permisos perfiles
            this.QuitarPermisosPerfil(iLisObjMar);

            //actualizar ventana propietario
            this.wBotVen.ActualizarDgvBot();

            //cerrar
            this.Close();

        }

        public void QuitarVentanaBotones(List<VentanaBotonEN> pLista)
        {
            VentanaBotonRN.EliminarVentanaBotonMasivo(pLista);
        }

        public void QuitarPermisosUsuario(List<VentanaBotonEN> pLista)
        {
            PermisoUsuarioRN.EliminarPermisosUsuarioXVentanaBoton(pLista);
        }

        public void QuitarPermisosPerfil(List<VentanaBotonEN> pLista)
        {
            PermisoPerfilRN.EliminarPermisosPerfilXVentanaBoton(pLista);
        }

        public List<VentanaBotonEN> SacarSoloMarcados()
        {
            //esta operacion actualiza a la lista eLisVenBot,obteniendo solo
            //los objetos marcados por el usuario
            return VentanaBotonRN.ListarVentanaBotonesSoloMarcadas(this.eLisVenBot);
        }

        public bool HayMarcados(List<VentanaBotonEN> pLista)
        {
           //ver si hay marcados
            if (pLista.Count == 0)
            {
                Mensaje.OperacionDenegada("Debes marcar al menos un boton, no se puede realizar la operacion","Botones");
                return false;
            }
            return true;           
        }
     
        #endregion

        private void wAgregarBotones_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wBotVen.Enabled = true;           
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
            this.ModificarVentanaBoton();
        }
               
      
                
    }
}
