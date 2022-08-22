using Negocio;
using Presentacion.Principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;

namespace Presentacion.Desarrollador
{
    public partial class wDoctor : Heredados.MiForm8
    {
        public wDoctor()
        {
            InitializeComponent();
        }

        #region Metodos Generales

        public void NuevaVentana()
        {
            this.Show();
        }

        public void RegenerarMovimientosTransferenciaYFaseMasa()
        {
            MovimientoCabeRN.RegenerarMovimientosTransferenciaYFaseMasa();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "Regenerar");
        }

        public void RegenerarMovimientosDetalleIngresosSemiProductos()
        {
            MovimientoCabeRN.RegenerarMovimientosDetalleIngresosSemiProductos();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "Regenerar");
        }

        public void RegenerarMovimientosDetalleSalidaTransferenciaSemiProductos()
        {
            MovimientoCabeRN.RegenerarMovimientosDetalleSalidaTransferenciaSemiProductos();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "Regenerar");
        }

        public void RegenerarMovimientosDetalleSalidasSemiProductos()
        {
            MovimientoCabeRN.RegenerarMovimientosDetalleSalidasSemiProductos();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "Regenerar");
        }

        public void RegenerarMovimientosDetalleIngresosProductosTerminados()
        {
            MovimientoCabeRN.RegenerarMovimientosDetalleIngresosProductosTerminados();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "Regenerar");
        }

        public void RegenerarCamposDetallesLiberacionProTer()
        {
            MovimientoCabeRN.RegenerarCamposDetallesLiberacionProTer();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "Regenerar");
        }

        public void CambiarMovimientosAlmacenReprocesos()
        {
           ProduccionDetaRN.CambiarMovimientosAlmacenReprocesos();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "cambiar");
        }

        public void ActualizarAcumuladosLiberacion()
        {
            ProduccionDetaRN.ActualizarAcumuladosLiberacion();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "cambiar");
        }

        public void AgregarFechaProduccionACampoDetalleCantidadesSemiProducto()
        {
            ProduccionProTerRN.AgregarFechaProduccionACampoDetalleCantidadesSemiProducto();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "cambiar");
        }

        public void ActualizarAlmacenCompraEnProduccionesExis()
        {
            ProduccionExisRN.ActualizarAlmacenCompraEnProduccionesExis();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "cambiar");
        }

        public void ActualizarSaldosYTotalesLiberacion()
        {
            ProduccionDetaRN.ActualizarSaldosYTotalesLiberacion();
            Mensaje.OperacionSatisfactoria("Proceso Terminado", "cambiar");
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteDoctor, null);
        }

        #endregion

        private void wDoctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Mensaje.DeseasRealizarOperacion("") == false) { return; }
            //desactivar ventana
            this.Enabled = false;
            Thread iHilo = new Thread(new ThreadStart(this.RegenerarMovimientosTransferenciaYFaseMasa));
            iHilo.Start();
            this.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Mensaje.DeseasRealizarOperacion("") == false) { return; }
            //desactivar ventana
            this.Enabled = false;
            Thread iHilo = new Thread(new ThreadStart(this.RegenerarMovimientosDetalleIngresosSemiProductos));
            iHilo.Start();
            this.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Mensaje.DeseasRealizarOperacion("") == false) { return; }
            //desactivar ventana
            this.Enabled = false;
            Thread iHilo = new Thread(new ThreadStart(this.RegenerarMovimientosDetalleSalidaTransferenciaSemiProductos));
            iHilo.Start();
            this.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Mensaje.DeseasRealizarOperacion("") == false) { return; }
            //desactivar ventana
            this.Enabled = false;
            Thread iHilo = new Thread(new ThreadStart(this.RegenerarMovimientosDetalleSalidasSemiProductos));
            iHilo.Start();
            this.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Mensaje.DeseasRealizarOperacion("") == false) { return; }
            //desactivar ventana
            this.Enabled = false;
            Thread iHilo = new Thread(new ThreadStart(this.RegenerarMovimientosDetalleIngresosProductosTerminados));
            iHilo.Start();
            this.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Mensaje.DeseasRealizarOperacion("") == false) { return; }
            //desactivar ventana
            this.Enabled = false;
            Thread iHilo = new Thread(new ThreadStart(this.RegenerarCamposDetallesLiberacionProTer));
            iHilo.Start();
            this.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.CambiarMovimientosAlmacenReprocesos();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ActualizarAcumuladosLiberacion();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AgregarFechaProduccionACampoDetalleCantidadesSemiProducto();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ActualizarAlmacenCompraEnProduccionesExis();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ActualizarSaldosYTotalesLiberacion();
        }
    }
}
