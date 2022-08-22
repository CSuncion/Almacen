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
    public partial class wMotivoSincerado : Heredados.MiForm8
    {
        public wMotivoSincerado()
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

        //public wProduccion wPro;

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
            xCtrl.txtNoFoco(this.txtCanOri, this.btnAceptar, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanProCab, true, "Cantidad sincerada (Uni)", "vvfff", 0, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPorRan, this.btnAceptar, "fffff");
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
            //this.wPro.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana(ProduccionCabeEN pObj)
        {
            this.InicializaVentana();
            this.MostrarProduccionCabe(pObj);           
            this.ActualizarListaMotivos();         
            this.ActualizarDgvMot();            
            this.HabilitarBotonesAcciones();
            this.txtCanProCab.Focus();
        }

        public void AsignarProduccionCabe(ProduccionCabeEN pPro)
        {
            pPro.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pPro.CodigoExistencia = this.txtCodExi.Text.Trim();
            pPro.PorcentajeSinceradoRango = Conversion.ADecimal(this.txtPorRan.Text, 0);
            pPro.CantidadSinceradoProduccionCabe = Conversion.ADecimal(this.txtCanProCab.Text, 0);
            pPro.UnidadesReproceso = Conversion.ADecimal(this.txtUniRep.Text, 0);
            pPro.CantidadSinceradoRango = Conversion.ADecimal(this.txtCanRan.Text, 0);
            pPro.DetalleMotivoSincerado = this.eDetalleMotivo;
            pPro.CantidadProduccionCabe = Conversion.ADecimal(this.txtCanOri.Text, 0);
        }

        public void MostrarProduccionCabe(ProduccionCabeEN pObj)
        {
            this.txtCorProCab.Text = pObj.CorrelativoProduccionCabe;
            this.txtCodAlm.Text = pObj.CodigoAlmacen;
            this.txtDesAlm.Text = pObj.DescripcionAlmacen;
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;            
            this.txtNUniMed.Text = pObj.NombreUnidadMedida;           
            this.txtPorRan.Text = Formato.NumeroDecimal(pObj.PorcentajeSinceradoRango, 2);
            this.txtCanProCab.Text = Formato.NumeroDecimal(pObj.CantidadSinceradoProduccionCabe, 0);
            this.txtUniRep.Text = Formato.NumeroDecimal(pObj.UnidadesReproceso, 0);
            this.txtCanRan.Text = Formato.NumeroDecimal(pObj.CantidadSinceradoRango, 2);
            this.eDetalleMotivo = pObj.DetalleMotivoSincerado;
            this.txtCanOri.Text = Formato.NumeroDecimal(pObj.CantidadProduccionCabe, 0);
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
            this.ModificarProduccionCabe();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la cantidad sincerada correctamente", this.eTitulo);

            //actualizar al propietario           
            //this.wPro.eClaveDgvProCab = Dgv.ObtenerValorCelda(this.wPro.DgvProCab, ProduccionCabeEN.ClaObj);
            //this.wPro.ActualizarVentana();

            //cerrar
            this.Close();
        }

        public void ModificarProduccionCabe()
        {
            //traer al objeto de bd
            //ProduccionCabeEN iProCabEN = this.wPro.EsProduccionCabeExistente();

            //asignamos los nuevos valores
            //this.AsignarProduccionCabe(iProCabEN);

            //modificar en bd
            //ProduccionCabeRN.ModificarProduccionCabe(iProCabEN);
        }

        public ProduccionCabeEN NuevaProduccionCabeDeVentana()
        {
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            this.AsignarProduccionCabe(iProCabEN);
            return iProCabEN;
        }

        public void MostrarPorcentajeRango()
        {
            //si es de lectura , entonces no lista
            if (txtCanProCab.ReadOnly == true) { return; }

            //asignar parametros
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            decimal iPorcentaje = ProduccionCabeRN.ObtenerPorcentajeRangoSincerado(iProCabEN);

            //mostrar en pantalla
            this.txtPorRan.Text = Formato.NumeroDecimal(iPorcentaje, 2);
        }

        public void MostrarCantidadRango()
        {
            //si es de lectura , entonces no lista
            if (txtCanProCab.ReadOnly == true) { return; }

            //asignar parametros
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            decimal iPorcentaje = ProduccionCabeRN.ObtenerCantidadRangoSincerado(iProCabEN);

            //mostrar en pantalla
            this.txtCanRan.Text = Formato.NumeroDecimal(iPorcentaje, 2);
        }

        public void AccionAgregarItem()
        {
            //instanciar
            wDetalleMotivoSincerado win = new wDetalleMotivoSincerado();
            win.eFlagVentana = 0;
            win.wMotSin = this;
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
            win.eFlagVentana = 0;
            win.wMotSin = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMotLib = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMotDes[Dgv.ObtenerIndiceRegistroXFranja(this.DgvBot)]);
        }

        public bool EsValidoCantidadSincerado()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            iProCabEN = ProduccionCabeRN.EsValidoCantidadSincerado(iProCabEN);

            //mensaje error
            Generico.MostrarMensajeError(iProCabEN.Adicionales, this.txtCanProCab);

            //devolver
            return iProCabEN.Adicionales.EsVerdad;
        }
        
        #endregion

        private void wMotivoSincerado_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wPro.Enabled = true;           
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
    }
}
