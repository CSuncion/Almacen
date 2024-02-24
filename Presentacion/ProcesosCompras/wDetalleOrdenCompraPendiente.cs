﻿using System;
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

namespace Presentacion.ProcesosCompras
{
    public partial class wDetalleOrdenCompraPendiente : Heredados.MiForm8
    {
        public wDetalleOrdenCompraPendiente()
        {
            InitializeComponent();
        }


        //variables
        string eNombreColumnaDgvPer = PresupuestoEN.CodPre;
        public Universal.Opera eOperacion;
        public int wMoneda = 0;
        Masivo eMas = new Masivo();
        public List<LoteEN> eLisLotExi = new List<LoteEN>();
        string eTitulo = "Item";
        public List<PresupuestoEN> eLisPre = new List<PresupuestoEN>();
        string eCenCos = string.Empty;
        decimal eCan = 0;
        MovimientoOCDetaEN eMovDet = new MovimientoOCDetaEN();

        #region Propietario

        public wEditOrdenCompra wEditOrdCom;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Existencia", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCodExi, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNUniMed, this.txtCodExi, "ffff");
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCantMovDet, true, "Cantidad", "vvff", 3, 12);
            xLis.Add(xCtrl);


            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCantRecMovDet, true, "Cantidad", "vvff", 3, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanRecibida, true, "Recibe", "vvvf", 3, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCanPendiente, true, "Pendiente", "ffff", 3, 12);
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

            //deshabilita propietario
            this.wEditOrdCom.Enabled = false;

            //ver ventana
            this.Show();
        }

        public void LlenarListaLotesExistencia()
        {
            //asignar parametros
            string iCodigoExistenciaGrilla = Dgv.ObtenerValorCelda(this.wEditOrdCom.dgvMovDet, MovimientoOCDetaEN.CodExi);

            //ejecutar metodo    
            this.eLisLotExi = ListaG.Filtrar<LoteEN>(this.wEditOrdCom.eLisLot, LoteEN.CodExi, iCodigoExistenciaGrilla);
        }

        public void VentanaPendiente(MovimientoOCDetaEN pObj)
        {
            this.eMovDet = pObj;
            this.InicializaVentana();
            this.Text = Universal.Opera.Pendiente.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarMovimientoDeta(pObj);
            this.LlenarListaLotesExistencia();
            eMas.AccionHabilitarControles(2);
            eMas.AccionPasarTextoPrincipal();
            this.btnAceptar.Focus();
        }

        public void AsignarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.FechaMovimientoCabe = this.wEditOrdCom.dtpFecMovCab.Text;
            pObj.PeriodoMovimientoCabe = this.wEditOrdCom.wOrdCom.lblPeriodo.Text;
            pObj.CodigoAlmacen = this.wEditOrdCom.txtCodAlm.Text.Trim();
            pObj.CodigoTipoOperacion = this.wEditOrdCom.txtCodTipOpe.Text.Trim();
            pObj.CCalculaPrecioPromedio = this.wEditOrdCom.txtCCalPrePro.Text.Trim();
            pObj.CConversionUnidad = this.wEditOrdCom.txtCConUni.Text.Trim();
            pObj.CClaseTipoOperacion = "3";//orden de compra
            pObj.NumeroMovimientoCabe = this.wEditOrdCom.txtNumMovCab.Text.Trim();
            pObj.CodigoAuxiliar = this.wEditOrdCom.txtCodAux.Text.Trim();
            pObj.CTipoDocumento = this.wEditOrdCom.txtCTipDoc.Text.Trim();
            pObj.SerieDocumento = this.wEditOrdCom.txtSerDoc.Text.Trim();
            pObj.NumeroDocumento = this.wEditOrdCom.txtNumDoc.Text.Trim();
            pObj.FechaDocumento = this.wEditOrdCom.dtpFecDoc.Text;
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.CodigoUnidadMedida = this.txtCUniMed.Text.Trim();
            pObj.NombreUnidadMedida = this.txtNUniMed.Text.Trim();
            pObj.StockAnteriorExistencia = Convert.ToDecimal(this.txtStoAntExi.Text);
            pObj.PrecioAnteriorExistencia = Convert.ToDecimal(this.txtPreAntExi.Text);
            pObj.CantidadMovimientoDeta = Convert.ToDecimal(this.txtCantMovDet.Text);
            pObj.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(pObj);
            pObj.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(pObj);
            pObj.CodigoTipo = this.txtCodTip.Text.Trim();
            pObj.CEsLote = this.txtCEsLot.Text.Trim();
            pObj.CEsUnidadConvertida = this.txtCEsUniCon.Text.Trim();
            pObj.FactorConversion = Convert.ToDecimal(this.txtFacCon.Text);
            pObj.ClaveMovimientoCabe = this.wEditOrdCom.ObtenerClaveMovimientoCabe();
            pObj.CCodigoMoneda = this.wEditOrdCom.txtCodMonSyD.Text.ToString().Trim();
        }

        public void MostrarMovimientoDeta(MovimientoOCDetaEN pObj)
        {
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;
            this.txtNUniMed.Text = pObj.NombreUnidadMedida;
            this.txtCUniMed.Text = pObj.CodigoUnidadMedida;
            this.txtStoAntExi.Text = Formato.NumeroDecimal(pObj.StockAnteriorExistencia.ToString(), 3);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(pObj.PrecioAnteriorExistencia.ToString(), 5);
            this.txtCantMovDet.Text = Formato.NumeroDecimal(pObj.CantidadMovimientoDeta.ToString(), 3);
            this.txtCantRecMovDet.Text = Formato.NumeroDecimal(pObj.CantidadRecibida.ToString(), 3);
            this.txtCodTip.Text = pObj.CodigoTipo;
            this.txtCEsLot.Text = pObj.CEsLote;
            this.txtCEsUniCon.Text = pObj.CEsUnidadConvertida;
            this.txtFacCon.Text = Formato.NumeroDecimal(pObj.FactorConversion.ToString(), 3);
            //this.txtCanRecibida.Text = Formato.NumeroDecimal(pObj.CantidadRecibida.ToString(), 3);
            this.txtCanPendiente.Text = Formato.NumeroDecimal(pObj.CantidadPendiente.ToString(), 3);
            eCenCos = pObj.CodigoCentroCosto;
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                case Universal.Opera.Pendiente: { this.Pendiente(); break; }
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //adicionar MovimientoDeta
            this.AdicionarMovimientoDeta();

            //adicionar lotes para la existencia
            this.AdicionarLotesExistencia();

            //actualizar presupuesto
            //this.ActualizarPresupuesto();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se adiciono el registro", "Detalle");

            //actualizar propietario
            this.wEditOrdCom.eClaveDgvMovDet = this.wEditOrdCom.eLisMovDet[this.wEditOrdCom.eLisMovDet.Count - 1].ClaveObjeto;
            this.wEditOrdCom.MostrarMovimientosDeta();
            this.wEditOrdCom.CambiarSoloLecturaACodigoAlmacen();
            this.wEditOrdCom.CambiarSoloLecturaACodigoTipoOperacion();

            //limpiar controles
            this.MostrarMovimientoDeta(MovimientoOCDetaRN.EnBlanco());
            //this.HabilitarControlesSegunPropiedadLote("");          
            this.CambiarAtributoSoloLecturaACodigoExistencia();
            this.eLisLotExi.Clear();
            eMas.AccionPasarTextoPrincipal();
            this.txtCodExi.Focus();
        }

        //public void ActualizarPresupuesto()
        //{
        //    PresupuestoEN xObj = new PresupuestoEN();
        //    xObj.CodigoPresupuesto = wEditOrdCom.wOrdCom.lblPeriodo.Text;
        //    xObj.CCentroCosto = this.txtCodAre.Text;
        //    switch (this.eOperacion)
        //    {
        //        case Universal.Opera.Adicionar:
        //            {
        //                xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(this.txtSaldoPresupuesto.Text);
        //                break;
        //            }
        //        case Universal.Opera.Modificar:
        //            {
        //                xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(this.txtSaldoPresupuesto.Text);

        //                break;
        //            }
        //        case Universal.Opera.Eliminar:
        //            {
        //                xObj.NuevoSaldoPresupuesto = Convert.ToDecimal(this.txtPresupuesto.Text); break;
        //            }
        //        default: break;
        //    }
        //    PresupuestoRN.ModificarPresupuestoActual(xObj);
        //}

        public void AdicionarMovimientoDeta()
        {
            MovimientoOCDetaEN iComDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iComDetEN);

            //adicionar detalle
            MovimientoOCDetaRN.AdicionarMovimientoDeta(this.wEditOrdCom.eLisMovDet, iComDetEN);
        }

        public void AdicionarLotesExistencia()
        {
            this.wEditOrdCom.eLisLot.AddRange(this.eLisLotExi);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //modificar detalle
            this.ModificarMovimientoDeta();

            //eliminar lotes anteriores
            this.EliminarLotesExistenciaAnterior();

            //adicionar nuevos lotes
            this.AdicionarLotesExistencia();

            //actualizar presupuesto
            //this.ActualizarPresupuesto();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se modifico el registro", "Detalle");

            //Actualizar propietario
            this.wEditOrdCom.eClaveDgvMovDet = this.wEditOrdCom.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditOrdCom.dgvMovDet)].ClaveObjeto;
            this.wEditOrdCom.MostrarMovimientosDeta();

            //salir de la ventana
            this.Close();

        }

        public void ModificarMovimientoDeta()
        {
            //obtener el objeto de la franja
            MovimientoOCDetaEN iMovDetEN = this.wEditOrdCom.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditOrdCom.dgvMovDet)];

            //asignar los nuevos valores
            this.AsignarMovimientoDeta(iMovDetEN);

            //actualizar a cero el costoflete
            iMovDetEN.CostoFleteMovimientoDeta = 0;

            //actualizar este objeto en la lista
            ListaG.Modificar<MovimientoOCDetaEN>(this.wEditOrdCom.eLisMovDet, iMovDetEN, MovimientoOCDetaEN.CodExi, iMovDetEN.CodigoExistencia);
        }

        public void EliminarLotesExistenciaAnterior()
        {
            //asignar parametros
            string iCodigoExistencia = Dgv.ObtenerValorCelda(this.wEditOrdCom.dgvMovDet, MovimientoOCDetaEN.CodExi);

            //ejecutar metodo           
            ListaG.Eliminar<LoteEN>(this.wEditOrdCom.eLisLot, LoteEN.CodExi, iCodigoExistencia);
        }

        public void Eliminar()
        {
            //eliminar particpante
            this.EliminarMovimientoDeta();

            //eliminar lotes anteriores
            this.EliminarLotesExistenciaAnterior();

            //this.ActualizarPresupuesto();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se elimino el registro", "Detalle");

            //mostra detalle comprobante
            this.wEditOrdCom.MostrarMovimientosDeta();
            this.wEditOrdCom.CambiarSoloLecturaACodigoAlmacen();
            this.wEditOrdCom.CambiarSoloLecturaACodigoTipoOperacion();

            //salir de la ventana
            this.Close();
        }

        public void EliminarMovimientoDeta()
        {
            this.wEditOrdCom.eLisMovDet.RemoveAt(Dgv.ObtenerIndiceRegistroXFranja(this.wEditOrdCom.dgvMovDet));
        }

        public void MostrarCosto()
        {
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);
            //this.txtCosMovDet.Text = Formato.NumeroDecimal(MovimientoOCDetaRN.ObtenerCosto(iMovDetEN).ToString(), 2);
            //this.txtSaldoPresupuesto.Text = Formato.NumeroDecimal(Convert.ToDecimal(Formato.NumeroDecimal(this.txtPresupuesto.Text, 2)) - MovimientoOCDetaRN.ObtenerCosto(iMovDetEN), 2);
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
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExi.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias";
            win.eCtrlValor = this.txtCodExi;
            //if (this.wEditOrdCom.txtCodMonSyD.Text == "1")
            //{
            //    win.eCtrlFoco = this.txtPreUniDol;
            //}
            //else
            //{
            //    win.eCtrlFoco = this.txtPreUniMovDet;
            //}
            win.eExiEN.CodigoAlmacen = this.wEditOrdCom.txtCodAlm.Text.Trim();
            win.eLisMovDetOC = this.wEditOrdCom.eLisMovDet;
            win.eCondicionLista = wLisExi.Condicion.ExistenciasActivasNoProduccionDeAlmacenNoSeleccionadasGrillaOC;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodExi.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = this.NuevaExistenciaVentana();
            string iCodigoExistenciaFranjaGrilla = Dgv.ObtenerValorCelda(this.wEditOrdCom.dgvMovDet, MovimientoOCDetaEN.CodExi);
            List<MovimientoOCDetaEN> iLisMovDetGrilla = this.wEditOrdCom.eLisMovDet;
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaActivoNoProduccionValidoOC(iExiEN, iOperacionVentana, iCodigoExistenciaFranjaGrilla, iLisMovDetGrilla);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia");
                this.txtCodExi.Focus();
            }

            //pasar datos
            this.txtCodExi.Text = iExiEN.CodigoExistencia;
            this.txtDesExi.Text = iExiEN.DescripcionExistencia;
            this.txtCUniMed.Text = iExiEN.CodigoUnidadMedida;
            this.txtNUniMed.Text = iExiEN.NombreUnidadMedida;
            this.txtCodTip.Text = iExiEN.CodigoTipo;
            this.txtCEsLot.Text = iExiEN.CEsLote;
            this.txtCEsUniCon.Text = iExiEN.CEsUnidadConvertida;
            this.txtFacCon.Text = Formato.NumeroDecimal(iExiEN.FactorConversion, 3);
            this.txtStoAntExi.Text = Formato.NumeroDecimal(this.ObtenerStockActualExistencia(iExiEN), 3);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(this.ObtenerPrecioActualExistencia(iExiEN), 2);
            //this.txtPreUniCon.Text = Formato.NumeroDecimal(this.ObtenerPrecioUnitarioConvertido(), 3);
            //this.txtPreUniMovDet.Text = Formato.NumeroDecimal(0, 3);
            //this.txtCanCon.Text = Formato.NumeroDecimal(this.ObtenerCantidadConvertido(), 3);
            this.txtCantMovDet.Text = Formato.NumeroDecimal(this.ObtenerCantidad(), 3);

            //mostrar costo
            this.MostrarCosto();

            //cambiar atributo solo lectura al cambiar existencia
            this.CambiarAtributoSoloLecturaAlCambiarExistencia();

            //poner el foco
            this.PonerFocoAlCambiarExistencia();

            //devolver
            return iExiEN.Adicionales.EsVerdad;
        }

        public MovimientoOCDetaEN ObtenerMovimientoDetaFranjaGrilla()
        {
            //objeto resultado
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();

            //si la grilla esta llena, toma al objeto
            if (this.wEditOrdCom.eLisMovDet.Count != 0)
            {
                iMovDetEN = this.wEditOrdCom.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.wEditOrdCom.dgvMovDet)];
            }

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

        public decimal ObtenerPrecioUnitario()
        {
            //asignar parametros          
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerPrecioUnitarioSugerido(iMovDetEN);
        }

        public decimal ObtenerPrecioUnitarioConvertido()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerPrecioUnitarioConvertidoSugerido(iMovDetEN);
        }

        public void CambiarAtributoSoloLecturaAPrecioUnitario()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoOCDetaRN.EsActoDigitarPrecioUnitario(iMovDetEN);

            //cambiar atributo readOnly
            //Txt.SoloEscritura3(this.txtPreUniMovDet, !iValor);
        }

        public ExistenciaEN NuevaExistenciaVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.wEditOrdCom.txtCodAlm.Text.Trim();
            iExiEN.DescripcionAlmacen = this.wEditOrdCom.txtDesAlm.Text.Trim();
            iExiEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public void HabilitarControlesSegunPropiedadLote(string pCEsLote)
        {
            //obtener el valor de veracidad de este flag
            bool iValor = Conversion.CadenaABoolean(pCEsLote, false);

            //cambiamos el atributo del control
            Txt.SoloEscritura3(this.txtCantMovDet, iValor);
            //this.btnLote.Enabled = iValor;

            //ahora saber si se debe limpiar el valor que tiene "txtCantMovDet" solo si es readonly
            //si la existencia tiene lotes registrados, entonces el valor "txtCantMovDet"
            //no se limpia 
            List<LoteEN> iLisLotExi = LoteRN.FiltrarLotes(this.wEditOrdCom.eLisLot, LoteEN.CodExi, this.txtCodExi.Text);
            if (this.txtCantMovDet.ReadOnly == true && iLisLotExi.Count == 0)
            {
                this.txtCantMovDet.Text = Txt.ObtenerValorXDefecto(this.txtCantMovDet);
            }
        }

        public void InstanciarLotes()
        {
            wLote win = new wLote();
            //win.wDetOrdCom = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void CambiarAtributoSoloLecturaACodigoExistencia()
        {
            if (this.txtCantMovDet.ReadOnly == true && Conversion.ADecimal(this.txtCantMovDet.Text, 0) != 0)
            {
                this.txtCodExi.ReadOnly = true;
            }
            else
            {
                this.txtCodExi.ReadOnly = false;
            }
        }

        public void CambiarAtributoSoloLecturaAPrecioUnitarioConversion()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoOCDetaRN.EsActoDigitarPrecioUnitarioConversion(iMovDetEN);

            //cambiar atributo readOnly
            //Txt.SoloEscritura3(this.txtPreUniCon, !iValor);
        }

        public void CambiarAtributoSoloLecturaACantidadConversion()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoOCDetaRN.EsActoDigitarCantidadConversion(iMovDetEN);

            //cambiar atributo readOnly
            //Txt.SoloEscritura3(this.txtCanCon, !iValor);
        }

        public void CambiarAtributoSoloLecturaACantidad()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            bool iValor = MovimientoOCDetaRN.EsActoDigitarCantidad(iMovDetEN);

            //cambiar atributo readOnly
            Txt.SoloEscritura3(this.txtCantMovDet, !iValor);
        }

        public decimal ObtenerCantidadConvertido()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerCantidadConvertidoSugerido(iMovDetEN);
        }

        public decimal ObtenerCantidad()
        {
            //asignar parametros
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);
            List<LoteEN> iLisLotExi = ListaG.Filtrar<LoteEN>(this.wEditOrdCom.eLisLot, LoteEN.CodExi, this.txtCodExi.Text);

            //ejecutar metodo
            return MovimientoOCDetaRN.ObtenerCantidadSugerido(iMovDetEN, iLisLotExi);
        }

        public void MostrarCantidadCalculado()
        {
            //obtener valor
            decimal iValor = this.ObtenerCantidad();

            //mostrar en pantalla
            this.txtCantMovDet.Text = Formato.NumeroDecimal(iValor, 3);
        }

        public void CambiarAtributoSoloLecturaAlCambiarExistencia()
        {
            this.CambiarAtributoSoloLecturaAPrecioUnitarioConversion();
            this.CambiarAtributoSoloLecturaAPrecioUnitario();
            this.CambiarAtributoSoloLecturaACantidadConversion();
            this.CambiarAtributoSoloLecturaACantidad();
        }


        public void AccionCambiarCantidadConversion()
        {
            this.MostrarCantidadCalculado();
            this.MostrarCosto();
        }

        public void PonerFocoAlCambiarExistencia()
        {
            if (this.txtCodExi.Text.Trim() == string.Empty) { return; }
            if (this.txtCantMovDet.ReadOnly == false) { this.txtCantMovDet.Focus(); return; }
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.eTitulo);
        }

        public void CantidadPendiente()
        {
            decimal canRec = Convert.ToDecimal(this.txtCantRecMovDet.Text);
            decimal canPen = Convert.ToDecimal(this.txtCanPendiente.Text);
            decimal can = Convert.ToDecimal(this.txtCantMovDet.Text);
            decimal canIng = Convert.ToDecimal(this.txtCanRecibida.Text);

            if ((canIng + canRec) > can)
            {
                Mensaje.OperacionDenegada("La cantidad recibida es mayor a la cantidad registrada", "Detalle");
                this.txtCanRecibida.Text = Formato.NumeroDecimal(0, 2);
                return;
            }
            this.txtCantRecMovDet.Text = Convert.ToString(canIng + canRec);
            canRec = Convert.ToDecimal(this.txtCantRecMovDet.Text);
            this.txtCanPendiente.Text = Convert.ToString(can - canRec);
        }

        public void ActualizarCantidad()
        {
            MovimientoOCDetaEN xMovDet = new MovimientoOCDetaEN();
            this.wEditOrdCom.eLisMovDet.Find(x => x.ClaveMovimientoDeta == this.eMovDet.ClaveMovimientoDeta).CantidadRecibida = Convert.ToDecimal(this.txtCantRecMovDet.Text);
            this.wEditOrdCom.eLisMovDet.Find(x => x.ClaveMovimientoDeta == this.eMovDet.ClaveMovimientoDeta).CantidadPendiente = Convert.ToDecimal(this.txtCanPendiente.Text);
            xMovDet.ClaveMovimientoDeta = this.eMovDet.ClaveMovimientoDeta;
            xMovDet.CantidadRecibida = Convert.ToDecimal(this.txtCantRecMovDet.Text);
            xMovDet.CantidadPendiente = Convert.ToDecimal(this.txtCanPendiente.Text);
            xMovDet.CantidadRecibidaVarios = this.txtCanRecibida.Text;
            MovimientoOCDetaRN.ActualizarCantidadRecibidayPendiente(xMovDet);
        }

        public void Pendiente()
        {
            //eliminar particpante
            this.ActualizarCantidad();

            //mensaje
            Mensaje.OperacionSatisfactoria("Se actualizo el registro", "Detalle");

            //mostra detalle comprobante
            this.wEditOrdCom.MostrarMovimientosDeta();
            this.wEditOrdCom.CambiarSoloLecturaACodigoAlmacen();
            this.wEditOrdCom.CambiarSoloLecturaACodigoTipoOperacion();

            //salir de la ventana
            this.Close();
        }
        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void wDetalleOrdenCompraPendiente_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEditOrdCom.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistencias(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistencias();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValido();
        }

        private void txtCant_Validated(object sender, EventArgs e)
        {
            this.MostrarCosto();
        }

        private void btnLote_Click(object sender, EventArgs e)
        {
            this.InstanciarLotes();
        }

        private void txtCanCon_Validated(object sender, EventArgs e)
        {
            this.AccionCambiarCantidadConversion();
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
