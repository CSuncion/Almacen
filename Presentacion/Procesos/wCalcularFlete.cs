using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Entidades.Adicionales;
using WinControles.ControlesWindows;
using Entidades;
using Negocio;
using Comun;
using Presentacion.Listas;
using Presentacion.ProcesosCompras;
using Presentacion.FuncionesGenericas;

namespace Presentacion.Procesos
{
    public partial class wCalcularFlete : Heredados.MiForm8
    {
        public wCalcularFlete()
        {
            InitializeComponent();
        }


        //variables
        string eNombreColumnaDgvPer = PresupuestoEN.CodPre;
        public Universal.Opera eOperacion;
        public int wMoneda = 0;
        Masivo eMas = new Masivo();
        public List<LoteEN> eLisLotExi = new List<LoteEN>();
        string eTitulo = "Flete";
        public List<PresupuestoEN> eLisPre = new List<PresupuestoEN>();
        string eCenCos = string.Empty;
        decimal eCan = 0;
        List<MovimientoCabeEN> eListMovCab = new List<MovimientoCabeEN>();
        List<MovimientoDetaEN> eLisMovDet = new List<MovimientoDetaEN>();

        #region Propietario

        public wIngresosOrdenCompra wIng;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtFlete, true, "Recibe", "vvvf", 3, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCalcular, "vvvf");
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

            //deshabilita propietario
            this.wIng.Enabled = false;

            //ver ventana
            this.Show();
        }


        public void VentanaCalcularFlete(List<MovimientoCabeEN> pMovCabj)
        {
            this.eListMovCab = pMovCabj;
            this.InicializaVentana();
            this.Text = Universal.Opera.Modificar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            //this.MostrarMovimientoDeta(pObj);
            eMas.AccionHabilitarControles(2);
            eMas.AccionPasarTextoPrincipal();
            this.btnCalcular.Focus();
        }


        public void Calcular()
        {
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            decimal cantidad = 0, fleteUni = 0, precDet = 0, fleteTotal = 0;
            for (int n = 0; n <= this.eListMovCab.Count - 1; n++)
            {
                bool iValor = Convert.ToBoolean(this.eListMovCab[n].VerdadFalso);
                if (iValor)
                {
                    MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
                    iMovDetEN.ClaveMovimientoCabe = this.eListMovCab[n].ClaveMovimientoCabe;
                    iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

                    this.eLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);

                    this.eLisMovDet.ForEach((x) =>
                    {
                        if (x.CantidadMovimientoDeta > 0)
                        {
                            cantidad += x.CantidadMovimientoDeta;
                        }
                    });
                }
            }

            fleteUni = Convert.ToDecimal(txtFlete.Text) / cantidad;

            for (int n = 0; n <= this.eListMovCab.Count - 1; n++)
            {
                fleteTotal = 0;
                bool iValor = Convert.ToBoolean(this.eListMovCab[n].VerdadFalso);
                if (iValor)
                {
                    MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
                    iMovDetEN.ClaveMovimientoCabe = this.eListMovCab[n].ClaveMovimientoCabe;
                    iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

                    this.eLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);

                    this.eLisMovDet.ForEach((x) =>
                    {
                        if (x.CantidadMovimientoDeta > 0)
                        {
                            precDet = x.CantidadMovimientoDeta * Convert.ToDecimal(Formato.NumeroDecimal(fleteUni, 2));
                            fleteTotal += precDet;
                            x.PrecioUnitarioMovimientoDeta = x.PrecioUnitarioMovimientoDeta + Convert.ToDecimal(Formato.NumeroDecimal(fleteUni, 2));
                            x.CostoFleteMovimientoDeta = Convert.ToDecimal(Formato.NumeroDecimal(fleteUni, 2));
                            x.CostoMovimientoDeta = x.PrecioUnitarioMovimientoDeta * x.CantidadMovimientoDeta;
                            MovimientoDetaRN.ActualizarCostoFleteDetayClaveMovimientoDeta(x);
                        }
                    });
                    this.eListMovCab[n].CostoFleteMovimientoCabe = Convert.ToDecimal(Formato.NumeroDecimal(fleteTotal, 2));
                    MovimientoCabeRN.ActualizaCostoFletexMovimientoCabe(this.eListMovCab[n]);
                }
            }

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se actualizo el flete del ingreso correctamente", this.wIng.eTitulo);
            this.wIng.ActualizarVentana();
            this.wIng.Enabled = true;
            this.Close();
        }



        public bool EsValidaDetallePresupuestoxCC()
        {
            //decimal precio = Convert.ToDecimal(Formato.NumeroDecimal(this.txtCosMovDet.Text, 2));
            //decimal presupuesto = Convert.ToDecimal(Formato.NumeroDecimal(this.txtPresupuesto.Text, 2));

            //if (precio >= presupuesto)
            //{
            //    Mensaje.OperacionDenegada("La cantidad solicitada por el precio de la ultima compra supera al presupuesto por centro de costo.", eTitulo);
            //    return false;
            //}

            //ok          
            return true;
        }

        public void ListarCentrosCostos()
        {
            //solo cuando el control esta habilitado de escritura
            //if (this.txtCodPar.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            //win.eCtrlValor = this.txtCodPar;
            //win.eCtrlFoco = this.txtGloMovDet;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void ListarAreas()
        {
            //solo cuando el control esta habilitado de escritura
            //if (this.txtCodAre.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centro de Costo";
            //win.eCtrlValor = this.txtCodAre;
            //win.eCtrlFoco = this.txtCodPar;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void ListarPartidas()
        {
            //solo cuando el control esta habilitado de escritura
            //if (this.txtCodAre.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Partidas";
            //win.eCtrlValor = this.txtCodPar;
            //win.eCtrlFoco = this.txtGloMovDet;
            win.eIteEN.CodigoTabla = "CodPar";
            //win.eIteEN.CodigoItemE = this.txtCodAre.Text.Trim();
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTablaYArea;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void ListarExistencias()
        {


            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias";
            win.eCtrlValor = this.txtFlete;
            //if (this.wEditOrdCom.txtCodMonSyD.Text == "1")
            //{
            //    win.eCtrlFoco = this.txtPreUniDol;
            //}
            //else
            //{
            //    win.eCtrlFoco = this.txtPreUniMovDet;
            //}

            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaOC;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }



        public MovimientoOCDetaEN ObtenerMovimientoDetaFranjaGrilla()
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //si la grilla esta llena, toma al objeto


            //retornar
            return iMovDetEN;
        }

        public decimal ObtenerStockActualExistencia(ExistenciaEN pObj)
        {
            //asignar parametros
            ExistenciaEN iExiBDEN = pObj;
            MovimientoOCDetaEN iMovDetGriEN = this.ObtenerMovimientoDetaFranjaGrilla();
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerStockAnteriorExistenciaPorDigitacion(iExiBDEN, iMovDetGriEN, iOperacionVentana);
        }

        public decimal ObtenerPrecioActualExistencia(ExistenciaEN pObj)
        {
            //asignar parametros
            ExistenciaEN iExiBDEN = pObj;
            MovimientoOCDetaEN iMovDetGriEN = this.ObtenerMovimientoDetaFranjaGrilla();
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerPrecioAnteriorExistenciaPorDigitacion(iExiBDEN, iMovDetGriEN, iOperacionVentana);
        }


        public ExistenciaEN NuevaExistenciaVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas

            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public void HabilitarControlesSegunPropiedadLote(string pCEsLote)
        {
            //obtener el valor de veracidad de este flag
            bool iValor = Conversion.CadenaABoolean(pCEsLote, false);

            //cambiamos el atributo del control

            //this.btnLote.Enabled = iValor;

            //ahora saber si se debe limpiar el valor que tiene "txtCantMovDet" solo si es readonly
            //si la existencia tiene lotes registrados, entonces el valor "txtCantMovDet"
            //no se limpia 

        }

        public void InstanciarLotes()
        {
            wLote win = new wLote();
            //win.wDetOrdCom = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }






        public void CambiarAtributoSoloLecturaACantidad()
        {
            //asignar parametros

        }



        public void MostrarCantidadCalculado()
        {
            //obtener valor


            //mostrar en pantalla;
        }



        public void PonerFocoAlCambiarExistencia()
        {

        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.eTitulo);
            this.wIng.Enabled = true;
        }

        public void CantidadPendiente()
        {

        }

        public void ActualizarCantidad()
        {
            MovimientoOCDetaEN xMovDet = new MovimientoOCDetaEN();

            //xMovDet.ClaveMovimientoDeta = this.eMovDet.ClaveMovimientoDeta;

            xMovDet.CantidadRecibidaVarios = this.txtFlete.Text;
            MovimientoOCDetaRN.ActualizarCantidadRecibidayPendiente(xMovDet);
        }

        public void Pendiente()
        {
            //eliminar particpante
            this.ActualizarCantidad();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se actualizo el registro", "Detalle");

            //mostra detalle comprobante


            //salir de la ventana
            this.Close();
        }
        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void wCalcularFlete_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            this.Calcular();
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistencias(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistencias();
        }


        private void btnLote_Click(object sender, EventArgs e)
        {
            this.InstanciarLotes();
        }


        private void txtCodAre_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAreas();
        }

        private void txtCodAre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAreas(); }
        }


        private void txtCodPar_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPartidas();
        }

        private void txtCodPar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPartidas(); }
        }

        private void txtCanRecibe_Validating(object sender, CancelEventArgs e)
        {
            this.CantidadPendiente();
        }
    }
}
