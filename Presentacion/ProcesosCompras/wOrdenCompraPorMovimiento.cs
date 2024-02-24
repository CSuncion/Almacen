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
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;
using Presentacion.ProcesosCompras;

namespace Presentacion.ProcesosCompras
{
    public partial class wOrdenCompraPorMovimiento : Heredados.MiForm8
    {
        public wOrdenCompraPorMovimiento()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string eClaveDgvLot = string.Empty;
        Dgv.Franja eFranjaDgvLot = Dgv.Franja.PorIndice;
        public List<dynamic> eLisMovDet = new List<dynamic>();

        #endregion

        #region Propietario

        public wOrdenCompra wOrdCom;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;


            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvff");
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
            this.wOrdCom.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto(MovimientoOCCabeEN pMovCab)
        {
            this.txtClaveOC.Text = pMovCab.ClaveMovimientoCabe;
        }


        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena("ClaveMovimientoCabe", "Clave Movimiento", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena("CantidadMovimientoDeta", "Cantidad", 80));

            //devolver
            return iLisRes;
        }

        public void MostrarCantidadTotal()
        {
            //obtener la suma total
            decimal iSumaTotal = Dgv.SumarColumna(this.dgvMov, "CantidadMovimientoDeta");

            //mostrar en pantalla
            this.txtCanTot.Text = Formato.NumeroDecimal(iSumaTotal, 2);
        }

        public void VentanaQuitarMovimiento(MovimientoOCCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();

            //valores x defecto
            this.ValoresXDefecto(pMovCab);

            this.MostrarCantidadTotal();
            //this.dtpFecMovCab.Focus();
            //this.CargarTipoCambio();
            //this.btnPendiente.Enabled = false;
        }

        public void LLenarMovimientoDetaDeBaseDatos(MovimientoOCCabeEN pObj)
        {
            this.eLisMovDet = MovimientoDetaRN.ObtenerMovimientosPorOrdenCompra(pObj.ClaveMovimientoCabe);
        }

        public void MostrarMovimientosDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMov;
            List<dynamic> iFuenteDatos = this.eLisMovDet;
            Dgv.Franja iCondicionFranja = 0;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public void EliminarMovimientoCabe()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            iCuoEN.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.dgvMov, "ClaveMovimientoCabe");
            MovimientoCabeRN.EliminarMovimientoCabe(iCuoEN);
        }
        public void ActualizarExistenciasPorEliminacion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDeta();

            foreach (MovimientoDetaEN det in iLisMovDet)
            {
                string claveMovimientoCabe = this.txtClaveOC.Text.Trim();
                MovimientoDetaRN.ActualizarMovimientoOrdenCompra(claveMovimientoCabe, det);
            }

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDeta(iLisMovDet);
        }

        public List<MovimientoDetaEN> ListarMovimientosDeta()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.dgvMov, "ClaveMovimientoCabe");
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void EliminarAntiguosMovimientosDeta()
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.dgvMov, "ClaveMovimientoCabe");
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public void EliminarAntiguosLotes()
        {
            //asignar parametros
            string iClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.dgvMov, "ClaveMovimientoCabe");

            //ejecutar metodo
            LoteRN.EliminarLoteXClaveMovimientoCabe(iClaveMovimientoCabe);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.dgvMov.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Movimiento por Orden Compra") == false) { return; }


            //eliminar el registro
            this.EliminarMovimientoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el ingreso correctamente", ("Movimiento por Orden de Compra"));


            //actualizar al wLot           
            this.wOrdCom.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        #endregion


        private void wOrdenCompraPorMovimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wOrdCom.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

    }
}
