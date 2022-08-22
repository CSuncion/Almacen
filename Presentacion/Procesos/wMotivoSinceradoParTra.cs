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
using Presentacion.FuncionesGenericas;

namespace Presentacion.Procesos
{
    public partial class wMotivoSinceradoParTra : Heredados.MiForm8
    {
        public wMotivoSinceradoParTra()
        {
            InitializeComponent();
        }

        #region Atributos

        Masivo eMas = new Masivo();
        public List<MotivoLiberacion> eLisMotDes = new List<MotivoLiberacion>();        
        public string eDetalleMotivo = string.Empty;
        public string eClaveDgvMotLib = string.Empty;
        Dgv.Franja eFranjaDgvMotLib = Dgv.Franja.PorIndice;
        public string eTipoMotivo = "MotSin";
        public string eTitulo = "Sincerado";

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
            xCtrl.txtNoFoco(this.txtCorProCab, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodAlm, this.btnAceptar, "fffff");            
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodExi, this.btnAceptar, "fffff");            
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNUniMed, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPorRan, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanProCab, false, "Cantidad sincerada (Uni)", "vvfff", 0, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUniRep, this.btnAceptar, "fffff");           
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanRan, false, "Unidades rango (Envasado)", "vvfff", 0, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvv");
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
            //this.wParTra.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana(ProduccionDetaEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pObj);           
            this.ActualizarListaMotivos();         
            this.ActualizarDgvMot();            
            this.HabilitarBotonesAcciones();
            this.txtCanProCab.Focus();
        }

        public void AsignarProduccionDeta(ProduccionDetaEN pPro)
        {
            pPro.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pPro.CodigoExistencia = this.txtCodExi.Text.Trim();
            pPro.PorcentajeSinceradoRango = Conversion.ADecimal(this.txtPorRan.Text, 0);
            pPro.CantidadSinceradoProduccionDeta = Conversion.ADecimal(this.txtCanProCab.Text, 0);
            pPro.UnidadesReproceso = Conversion.ADecimal(this.txtUniRep.Text, 0);
            pPro.CantidadSinceradoRango = Conversion.ADecimal(this.txtCanRan.Text, 0);
            pPro.DetalleMotivoSincerado = this.eDetalleMotivo;
            //pPro.ClaveProduccionCabe = Dgv.ObtenerValorCelda(this.wParTra.DgvProDet, ProduccionDetaEN.ClaProCab); 
        }

        public void MostrarProduccionDeta(ProduccionDetaEN pObj)
        {
            this.txtCorProCab.Text = pObj.CorrelativoProduccionCabe;
            this.txtCodAlm.Text = pObj.CodigoAlmacen;
            this.txtDesAlm.Text = pObj.DescripcionAlmacen;
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;            
            this.txtNUniMed.Text = pObj.NombreUnidadMedida;           
            this.txtPorRan.Text = Formato.NumeroDecimal(pObj.PorcentajeSinceradoRango, 2);
            this.txtCanProCab.Text = Formato.NumeroDecimal(pObj.CantidadSinceradoProduccionDeta, 0);
            this.txtUniRep.Text = Formato.NumeroDecimal(pObj.UnidadesReproceso, 0);
            this.txtCanRan.Text = Formato.NumeroDecimal(pObj.CantidadSinceradoRango, 2);
            this.eDetalleMotivo = pObj.DetalleMotivoSincerado;
        }

        public void HabilitarBotonesAcciones()
        {
            ////obtener valor
            //bool iValor= (this.wPro.eOperacion == Universal.Opera.Visualizar) ? false : true;

            ////ejecutar metodos
            //this.btnAgregar.Enabled = iValor;
            //this.btnModificar.Enabled = iValor;
            //this.btnQuitar.Enabled = iValor;
        }
        
        public void ActualizarDgvMot()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvBot;
            List<MotivoLiberacion> iFuenteDatos = ListaG.Refrescar<MotivoLiberacion>(this.eLisMotDes);
            Dgv.Franja iCondicionFranja =  eFranjaDgvMotLib;
            string iClaveBusqueda = eClaveDgvMotLib;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMot();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMot()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MotivoLiberacion.CodMotLib, "Codigo", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MotivoLiberacion.DesMotLib, "Descripcion", 380));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MotivoLiberacion.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaMotivos()
        {
            //asignar parametros
            List<ItemGEN> iLisMot = ItemGRN.ListarItemsG("MotSin");

            //ejecutar metodo
            this.eLisMotDes = LiberacionRN.ConvertirCampoDetalleMotivoALista(this.eDetalleMotivo, iLisMot);
        }

        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar registro
            this.ModificarProduccionDeta();

            //generar las transferencias por sincerado
            this.GenerarTransferenciaPorSincerado();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la cantidad sincerada correctamente", this.eTitulo);

            //actualizar al propietario           
            //this.wParTra.eClaveDgvProDet = Dgv.ObtenerValorCelda(this.wParTra.DgvProDet, ProduccionDetaEN.ClaObj);
            //this.wParTra.ActualizarVentana();

            //cerrar
            this.Close();
        }

        public void ModificarProduccionDeta()
        {
            //traer al objeto de bd
            //ProduccionDetaEN iProDetEN = this.wParTra.EsProduccionDetaExistente();

            //asignamos los nuevos valores
            //this.AsignarProduccionDeta(iProDetEN);

            ////modificar en bd
            //ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public void GenerarTransferenciaPorSincerado()
        {
            //asignar parametros
            //ProduccionDetaEN iProDetEN = this.wParTra.EsProduccionDetaExistente();

            //ejecutar metodo
            //MovimientoCabeRN.GenerarTransferenciasAutomaticasPorSincerado(iProDetEN);
        }

        public ProduccionDetaEN NuevaProduccionDetaDeVentana()
        {
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            this.AsignarProduccionDeta(iProDetEN);
            return iProDetEN;
        }

        public void MostrarPorcentajeRango()
        {
            //si es de lectura , entonces no lista
            if (txtCanProCab.ReadOnly == true) { return; }

            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();

            //ejecutar metodo
            decimal iPorcentaje = ProduccionDetaRN.ObtenerPorcentajeRangoSincerado(iProDetEN);

            //mostrar en pantalla
            this.txtPorRan.Text = Formato.NumeroDecimal(iPorcentaje, 2);
        }

        public void MostrarCantidadRango()
        {
            //si es de lectura , entonces no lista
            if (txtCanProCab.ReadOnly == true) { return; }

            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();

            //ejecutar metodo
            decimal iPorcentaje = ProduccionDetaRN.ObtenerCantidadRangoSincerado(iProDetEN);

            //mostrar en pantalla
            this.txtCanRan.Text = Formato.NumeroDecimal(iPorcentaje, 2);
        }

        public void AccionAgregarItem()
        {
            //instanciar
            wDetalleMotivoSincerado win = new wDetalleMotivoSincerado();
            win.eFlagVentana = 1;
            win.wMotSinParTra = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMotLib = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisMotDes.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            wDetalleMotivoSincerado win = new wDetalleMotivoSincerado();
            win.eFlagVentana = 1;
            win.wMotSinParTra = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMotLib = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMotDes[Dgv.ObtenerIndiceRegistroXFranja(this.DgvBot)]);
        }

        public void AccionCantidadADevolver()
        {
            //instanciar
            wCantidadDevolver win = new wCantidadDevolver();            
            win.wMotSinParTra = this;          
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsValidoCantidadSincerado()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();

            //ejecutar metodo
            iProDetEN = ProduccionDetaRN.EsValidoCantidadSincerado(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, this.txtCanProCab);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        #endregion

        private void wMotivoSinceradoParTra_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wParTra.Enabled = true;           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarItem();
          
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCanProCab_Validated(object sender, EventArgs e)
        {
            if (this.EsValidoCantidadSincerado() == false) { return; }
            this.MostrarPorcentajeRango();
            this.MostrarCantidadRango();
        }

        private void btnCantidadDev_Click(object sender, EventArgs e)
        {
            this.AccionCantidadADevolver();
        }
    }
}
