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
using Entidades.Estructuras;

namespace Presentacion.Procesos
{
    public partial class wAprobarSolicitud : Heredados.MiForm8
    {
        public wAprobarSolicitud()
        {
            InitializeComponent();
        }

        //variables     
        Masivo eMas = new Masivo();
               
        #region Propietario

        //public wProduccion wVen;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnSalir, "vvvv");
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
            //this.wVen.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();           
            this.ActualizarDgvSol();
            this.btnAgregar.Focus();
        }

        public void ActualizarDgvSol()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvBot;
            List<ProduccionCabeEN> iFuenteDatos = ProduccionCabeRN.ListarProduccionCabeEstadoCompra();
            Dgv.Franja iCondicionFranja =  Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvProCab();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvProCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionCabeEN.CorProCab, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionCabeEN.FecProCab, "Fecha", 70));                   
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionCabeEN.DesExi, "Formula", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionCabeEN.CanProCab, "Cant.Producir", 90, 0));                  
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionCabeEN.NEstProCab, "Estado", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void AccionAgregarSolicitudes()
        {
            wAgregarSolicitudes win = new wAgregarSolicitudes();
            win.wAprSol = this;
            win.eOperacion = Universal.Opera.Adicionar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAgregar();
        }

        public void AccionQuitarSolicitudes()
        {
            wAgregarSolicitudes win = new wAgregarSolicitudes();
            win.wAprSol = this;
            win.eOperacion = Universal.Opera.Eliminar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaQuitar();
        }

        public void AccionCompras()
        {
            //valida cuando grilla esta vacia
            if (Dgv.ValidaCuandoGrillaEstaVacia(this.DgvBot) == false) { return; }

            //valida cuando no hay nada que comprar
            this.ValidaCuandoHayInsumosSuficientes();
        }
        
        public bool ValidaCuandoHayInsumosSuficientes()
        {
            //listar existencias que no completan el stock para esta compra
            List<InsumoFaltante> iLisInsFal = ProduccionCabeRN.ListarInsumosFaltantesAComprar();

            //si hay elementos en la lista, entonces invoca la ventana
            if (iLisInsFal.Count != 0)
            {
                //instanciar
                wInsumosFaltantesCompra win = new wInsumosFaltantesCompra();
                win.eVentanaPropietario = this;
                win.eLisInsFal = iLisInsFal;
                TabCtrl.InsertarVentana(this, win);
                win.NuevaVentana();

                //devolver
                return false;
            }
            else
            {
                Mensaje.OperacionSatisfactoria("Estas solicitudes tienen stock suficiente para produccion", "Almacenes");
                return true;
            }
        }

        public void AccionAprobar()
        {
            //valida cuando grilla esta vacia
            if (Dgv.ValidaCuandoGrillaEstaVacia(this.DgvBot) == false) { return; }

            //listar existencias que no completan el stock para esta compra
            List<InsumoFaltante> iLisInsFal = ProduccionCabeRN.ListarInsumosFaltantesAComprar();

            //si hay elementos en la lista, entonces invoca la ventana
            if (iLisInsFal.Count == 0)
            {
                //mensaje si desea realizar la operacion
                if(Mensaje.DeseasRealizarOperacion("Esta accion aprobara las solicitudes que estan en pantalla","Solicitud") == false)
                { return; }

                //aprobar solicitudes
                ProduccionCabeRN.AprobarSolicitudesDeCompra();

                //mensaje satisfactorio
                Mensaje.OperacionSatisfactoria("Se aprobaron las solicitudes", "Solicitud");

                //actualizar ventana
                this.ActualizarDgvSol();

                //actualizar al propietario
                //this.wVen.ActualizarVentana();
            }
            else
            {
                Mensaje.OperacionSatisfactoria("Hay insumos que comprar", "Almacenes");               
            }
        }

        public void AccionDesaprobar()
        {
            wAgregarSolicitudes win = new wAgregarSolicitudes();
            win.wAprSol = this;
            win.eOperacion = Universal.Opera.Modificar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaDesaprobar();
        }

        #endregion

        private void wAprobarSolicitud_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wVen.Enabled = true;           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarSolicitudes();
          
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarSolicitudes();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            this.AccionCompras();
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            this.AccionAprobar();
        }

        private void btnDesaprobar_Click(object sender, EventArgs e)
        {
            this.AccionDesaprobar();
        }
    }
}
