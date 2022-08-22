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
using Presentacion.Listas;

namespace Presentacion.Maestros
{
    public partial class wEditExistencia : Heredados.MiForm8
    {
        public wEditExistencia()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string wSupleSiNo = "0";

        #endregion

        #region Propietario

        public wExistencia wExi;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Codigo", "ffff", 20);
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.txtNoFoco(this.txtCodExi, this.txtCodAlm, "ffff");
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesExi, true, "Descripcion", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesSecExi, false, "Descripcion Secundaria", "vvff",100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesCorExi, false, "Descripcion corta", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbUniMedExi, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodUbiExi, false, "Código Ubicación", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomUbiExi, txtCodUbiExi, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTipExi, "vvff");
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Cmb(this.cmbGruExi, "vvff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Cmb(this.cmbEsPro, "vvff");
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbMarExi, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCatExi, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCtaCon, false, "Cuenta Contable", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbCenCto, "vvff");
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Cmb(this.cmbAreExi, "vvff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtAmbExi, false, "Ambiente", "vvff", 6);
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.Cmb(this.cmbMarExi, "vvff");
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtModExi, false, "Modelo", "vvff", 50);
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtSerExi, false, "Serie", "vvff", 30);
            //xLis.Add(xCtrl);           

            //xCtrl = new ControlEditar();
            //xCtrl.TxtTodo(this.txtMedExi, false, "Medidas", "vvff", 20);
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEsLote, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtStoMinExi, false, "Stock Minimo", "vvff", 5, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtStkAleExi, false, "Stock Alerta", "vvff", 5, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbConvUnid, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtFacCon, false, "Factor Conversión", "vvff", 5, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtStoActExi, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.TxtNumeroConDecimales(this.txtStoActExi, false,"Stock Actual", "fvff",5,12);
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPreProExi, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtUniXEmp, false, "Unidades X Empaque", "vvff", 2, 10);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstExi, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvvf");
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
            //titulo ventana
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wExi.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos      
            this.CargarUnidadesMedidaExistencia();
            this.CargarTiposExistencia();
            //this.CargarGruposExistencia();
            //this.CargarEsProduccionExistencia();
            this.CargarAreasExistencia();
            this.CargarMarcasExistencia();
            this.CargarColoresExistencia();
            this.CargarCatalogosExistencia();
            this.CargarEstadoEsLote();
            this.CargarEstadoFactor();
            this.CargarEstadosExistencia();
            this.CargarCenCtoExistencia();

            // Deshabilitar al propietario
            this.wExi.Enabled = false;
            
            // Mostrar ventana
            this.Show();            
        }
        
        public void VentanaAdicionar()
        {
            this.InicializaVentana();           
            this.MostrarExistencia(ExistenciaRN.EnBlanco());          
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCodAlm.Focus();
        }

        public void VentanaModificar(ExistenciaEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarExistencia(pObj);          
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtDesExi.Focus();
        }

        public void VentanaEliminar(ExistenciaEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarExistencia(pObj);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(ExistenciaEN pObj)
        {
            this.InicializaVentana();            
            this.MostrarExistencia(pObj);         
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void CargarUnidadesMedidaExistencia()
        {
            Cmb.Cargar(this.cmbUniMedExi, ItemGRN.ListarItemsG("UniMed"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarTiposExistencia()
        {
            Cmb.Cargar(this.cmbTipExi, ItemGRN.ListarItemsG("TipExi"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        //public void CargarGruposExistencia()
        //{
        //    ItemGRN iIteRN = new ItemGRN();
        //    ItemGEN iIteEN = new ItemGEN();
        //    iIteEN.CodigoTabla = "GruExi";
        //    iIteEN.CodigoItemG = this.cmbTipExi.SelectedValue.ToString();            
        //    Cmb.Cargar(this.cmbGruExi, iIteRN.ListarItemsGActivosXFiltroClaseYSubClase(iIteEN), ItemGEN.CodIteG, ItemGEN.NomIteG);
        //}

        //public void CargarEsProduccionExistencia()
        //{
        //    Cmb.Cargar(this.cmbEsPro, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        //}

        public void CargarAreasExistencia()
        {
            Cmb.Cargar(this.cmbCenCto, ItemERN.ListarItemsG("CodAre"), ItemEEN.CodIteE, ItemEEN.NomIteE);
        }

        public void CargarCenCtoExistencia()
        {
            //Cmb.Cargar(this.cmbCenCto, ItemGRN.ListarItemsG("CenCto"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarMarcasExistencia()
        {
            Cmb.Cargar(this.cmbMarExi, ItemGRN.ListarItemsG("MarExi"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarColoresExistencia()
        {
            //Cmb.Cargar(this.cmbColExi, ItemGRN.ListarItemsG("Color"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarCatalogosExistencia()
        {
            Cmb.Cargar(this.cmbCatExi, ItemGRN.ListarItemsG("CatExi"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadoEsLote()
        {
            Cmb.Cargar(this.cmbEsLote, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadoFactor()
        {
            Cmb.Cargar(this.cmbConvUnid, ItemGRN.ListarItemsG("SiNo"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void CargarEstadosExistencia()
        {
            Cmb.Cargar(this.cmbEstExi, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarExistencia(ExistenciaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();
            pObj.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pObj.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.DescripcionSecundariaExistencia = this.txtDesSecExi.Text.Trim();
            pObj.DescripcionCortaExistencia = this.txtDesCorExi.Text.Trim();
            pObj.CodigoUnidadMedida = Cmb.ObtenerValor(this.cmbUniMedExi, string.Empty);
            pObj.CCodigoUbicacion = this.txtCodUbiExi.Text.Trim();
            pObj.CodigoTipo = Cmb.ObtenerValor(this.cmbTipExi, string.Empty);
            //pObj.CodigoGrupo = Cmb.ObtenerValor(this.cmbGruExi, string.Empty);
            pObj.CClaseExistencia = Cmb.ObtenerValor(this.cmbTipExi, string.Empty);
            //pObj.CSubClaseExistencia = Cmb.ObtenerValor(this.cmbGruExi, string.Empty);
            //pObj.CEsProduccion = Cmb.ObtenerValor(this.cmbEsPro, string.Empty);
            //pObj.CodigoArea = Cmb.ObtenerValor(this.cmbCenCto, string.Empty);
            pObj.CCentroCosto = Cmb.ObtenerValor(this.cmbCenCto, string.Empty);
            pObj.CodigoMarca = Cmb.ObtenerValor(this.cmbMarExi, string.Empty);
            pObj.ContableExistencia = this.txtCodCtaCon.Text.Trim();
            //pObj.SerieExistencia = this.txtSerExi.Text.Trim();
            //pObj.CodigoColor = Cmb.ObtenerValor(this.cmbColExi, string.Empty);
            //pObj.CodigoCatalogo = Cmb.ObtenerValor(this.cmbCatExi, string.Empty);
            //pObj.MedidasExistencia = this.txtMedExi.Text.Trim();
            pObj.StockMinimoExistencia = Conversion.ADecimal(this.txtStoMinExi.Text, 0);
            pObj.StockAlertaExistencia = Conversion.ADecimal(this.txtStkAleExi.Text, 0);
            pObj.StockActualExistencia = Conversion.ADecimal(this.txtStoActExi.Text, 0);
            pObj.CEsLote = Cmb.ObtenerValor(this.cmbEsLote, string.Empty);
            pObj.CEsUnidadConvertida = Cmb.ObtenerValor(this.cmbConvUnid, string.Empty);
            pObj.FactorConversion = Conversion.ADecimal(this.txtFacCon.Text, 0);
            pObj.UnidadesPorEmpaque = Conversion.ADecimal(this.txtUniXEmp.Text, 0);
            pObj.CEstadoExistencia = Cmb.ObtenerValor(this.cmbEstExi, string.Empty);
            pObj.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(pObj);
            pObj.FotoExistencia =  this.ObtenerRutaFotografia();
            
        }

        public void MostrarExistencia(ExistenciaEN pObj)
        {
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtCodAlm.Text = pObj.CodigoAlmacen;
            this.txtDesAlm.Text = pObj.DescripcionAlmacen;
            this.txtDesExi.Text = pObj.DescripcionExistencia;
            this.txtDesSecExi.Text = pObj.DescripcionSecundariaExistencia;
            this.txtDesCorExi.Text = pObj.DescripcionCortaExistencia;
            Cmb.SeleccionarValorItem(this.cmbUniMedExi, pObj.CodigoUnidadMedida);
            this.txtCodUbiExi.Text = pObj.CCodigoUbicacion;
            this.txtNomUbiExi.Text = pObj.NCodigoUbicacion;
            Cmb.SeleccionarValorItem(this.cmbTipExi, pObj.CodigoTipo);
            //this.CargarGruposExistencia();
            //Cmb.SeleccionarValorItem(this.cmbGruExi, pObj.CodigoGrupo);
            //Cmb.SeleccionarValorItem(this.cmbEsPro, pObj.CEsProduccion);
            //Cmb.SeleccionarValorItem(this.cmbCenCto, pObj.CCentroCosto);
            Cmb.SeleccionarValorItem(this.cmbCenCto, pObj.CodigoArea);
            //this.txtAmbExi.Text = pObj.AmbienteExistencia;
            Cmb.SeleccionarValorItem(this.cmbMarExi, pObj.CodigoMarca);
            this.txtCodCtaCon.Text = pObj.ContableExistencia;
            //this.txtSerExi.Text = pObj.SerieExistencia;
            //Cmb.SeleccionarValorItem(this.cmbColExi, pObj.CodigoColor);          
            //this.txtMedExi.Text = pObj.MedidasExistencia;
            Cmb.SeleccionarValorItem(this.cmbCatExi, pObj.CodigoCatalogo);         
            this.txtStoMinExi.Text = Formato.NumeroDecimal(pObj.StockMinimoExistencia, 5);
            this.txtStkAleExi.Text = Formato.NumeroDecimal(pObj.StockAlertaExistencia, 5);
            this.txtStoActExi.Text = Formato.NumeroDecimal(pObj.StockActualExistencia, 5);
            this.txtPreProExi.Text = Formato.NumeroDecimal(pObj.PrecioPromedioExistencia, 2);
            Cmb.SeleccionarValorItem(this.cmbEsLote, pObj.CEsLote);
            Cmb.SeleccionarValorItem(this.cmbConvUnid, pObj.CEsUnidadConvertida);
            this.txtFacCon.Text = Formato.NumeroDecimal(pObj.FactorConversion, 5);           
            this.txtUniXEmp.Text = Formato.NumeroDecimal(pObj.UnidadesPorEmpaque, 2);
            Cmb.SeleccionarValorItem(this.cmbEstExi, pObj.CEstadoExistencia);
            this.pbImaExi.ImageLocation = pObj.FotoExistencia;

            //MessageBox.Show("Ver");
        }        

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }
        
        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            ////el codigo de usuario ya existe?
            if (this.EsCodigoExistenciaDisponibleEnTxtCodExi() == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wExi.eTitulo) == false) { return; }

            //Mostrar nuevo codigo de Existencia
            this.MostrarCorrelativoExistencia();

            //adicionando el registro
            this.AdicionarExistencia();

            //adicionando sus saldos
            this.AdicionarSaldos();

            //agregar la fotografia
            this.CopiarFotografiaACarpetaDeFotografias();


            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Existencia se adiciono correctamente", this.wExi.eTitulo);

            //actualizar al propietario
            this.wExi.eClaveDgvExi = this.ObtenerClaveExistencia(); ;
            this.wExi.ActualizarVentana();

            //limpiar controles    
            this.MostrarExistencia(this.ObtenerExistenciaParaSegundaAdicion());
            eMas.AccionPasarTextoPrincipal();
            //this.CargarGruposExistencia();
            if (this.chbAuto.Checked == true)
            {
                this.txtDesExi.Focus();
            }
            else
            {
                this.txtCodExi.Focus();
            }                
        }

        public ExistenciaEN ObtenerExistenciaParaSegundaAdicion()
        {
            //objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos los datos que queremos persistir para una segundo o mas adiciones
            iExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iExiEN.DescripcionAlmacen = this.txtDesAlm.Text.Trim();

            //devolver
            return iExiEN;
        }

        public void AdicionarExistencia()
        {
            ExistenciaEN iPerEN = new ExistenciaEN();
            this.AsignarExistencia(iPerEN);
            ExistenciaRN.AdicionarExistencia(iPerEN);
        }

        public void AdicionarSaldos()
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            this.AsignarExistencia(iExiEN);

            //ejecutar metodo
            SaldoRN.AdicionarSaldos(iExiEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wExi.EsExistenciaExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wExi.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarExistencia();

            //agregar la fotografia
            this.CopiarFotografiaACarpetaDeFotografias();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Existencia se modifico correctamente", this.wExi.eTitulo);

            //actualizar al wUsu
            this.wExi.eClaveDgvExi = this.ObtenerClaveExistencia();
            this.wExi.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarExistencia()
        {
            ExistenciaEN iPerEN = new ExistenciaEN();
            this.AsignarExistencia(iPerEN);
            iPerEN = ExistenciaRN.BuscarExistenciaXClave(iPerEN);
            this.AsignarExistencia(iPerEN);
            ExistenciaRN.ModificarExistencia(iPerEN);
        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wExi.EsActoEliminarExistencia().Adicionales.EsVerdad == false) { return; }
                       
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wExi.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarExistencia();

            //eliminar los saldos de esta existencia
            this.EliminarSaldos();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La Existencia se elimino correctamente", this.wExi.eTitulo);

            //actualizar al propietario           
            this.wExi.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarExistencia()
        {
            ExistenciaEN iPerEN = new ExistenciaEN();
            this.AsignarExistencia(iPerEN);
            ExistenciaRN.EliminarExistencia(iPerEN);
        }

        public void EliminarSaldos()
        {
            //asignar parametros
            ExistenciaEN iExiEN = new ExistenciaEN();
            this.AsignarExistencia(iExiEN);

            //ejecutar metodo
            SaldoRN.EliminarSaldosDeExistencia(iExiEN);
        }

        public void MostrarCorrelativoExistencia()
        {
            //ExistenciaRN iExiRN = new ExistenciaRN();
            if (this.chbAuto.Checked == true)
            {
                ExistenciaEN iExiEN = new ExistenciaEN();
                this.AsignarExistencia(iExiEN);
                this.txtCodExi.Text = ExistenciaRN.ObtenerNumeroCodigoAutogenerado(iExiEN);
            }            
        }

        public bool EsCodigoExistenciaDisponibleEnTxtCodExi()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            ExistenciaEN iPerEN = new ExistenciaEN();
            this.AsignarExistencia(iPerEN);
            iPerEN = ExistenciaRN.EsCodigoExistenciaDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wExi.eTitulo);
                this.txtCodExi.Clear();
                this.txtCodExi.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }

        public bool EsCodigoExistenciaDisponibleEnTxtCodAlm()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            ExistenciaEN iPerEN = new ExistenciaEN();
            this.AsignarExistencia(iPerEN);
            iPerEN = ExistenciaRN.EsCodigoExistenciaDisponible(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wExi.eTitulo);
                this.txtCodAlm.Clear();
                this.txtDesAlm.Clear();
                this.txtCodAlm.Focus();
            }
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarAlmacenes()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm;
            win.eCtrlFoco = this.txtDesExi;
            win.eCondicionLista = Listas.wLisAlm.Condicion.Almacenes;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void ListarUbicaciones()
        {
            //solo cuando no es de lectura
            if (txtCodUbiExi.ReadOnly == true) { return; }

            //instanciar
            wLisItemG win = new wLisItemG();
            win.eVentana = this;
            win.eTituloVentana = "Codigos Ubicación";
            win.eCtrlValor = this.txtCodUbiExi;
            win.eCtrlFoco = this.cmbTipExi;
            win.eIteEN.CodigoTabla = "CodUbi";
            win.eCondicionLista = Listas.wLisItemG.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoUbicacionValida()
        {
            return Generico.EsCodigoItemGValido("CodUbi", txtCodUbiExi, txtNomUbiExi, "Codigo Ubicacion Existencia");
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el codigo almacen
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wExi.eTitulo);
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public bool EsCantidadDeUnidadesEditable()
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }

            ExistenciaEN iExiEN = new ExistenciaEN();
            this.AsignarExistencia(iExiEN);
            //iExiEN.CodigoTipo = "02";
            if (iExiEN.CodigoTipo == "02")
            {                 
                this.txtUniXEmp.ReadOnly = false;
                
            }
            else
            {
                this.txtUniXEmp.ReadOnly = true;
            }
            return iExiEN.Adicionales.EsVerdad;
        }

        public void CambiarFotografiaExistencia()
        {
            //asignar parametros
            PictureBox iPb = this.pbImaExi;
            string iTituloVentana = "Fotografia";

            //ejecutar metodo
            Pb.MostrarImagen(iPb, iTituloVentana);
            this.btnAceptar.Focus();
        }

        public string ObtenerClaveExistencia()
        {
            ExistenciaEN iExiEN = new ExistenciaEN();
            this.AsignarExistencia(iExiEN);
            return iExiEN.ClaveExistencia;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wExi.eTitulo);
        }

        //public void BuscarImagenLogo()
        //{
        //    //asignar parametros          
        //    string iRutaDestino = ParametroRN.BuscarParametro().RutaLogoEmpresa;

        //    //ejecutar metodo
        //    this.lblRutLog.Text = OpeFilDia.AgregarImagen(iRutaDestino);
        //}

        public void BuscarImagenExistencia()
        {
            //asignar parametros          
            string iRutaDestino = ParametroRN.BuscarParametro().RutaImagenExistencia;

            //ejecutar metodo
            this.lblRutExi.Text = OpeFilDia.AgregarImagen(iRutaDestino);
        }

        public void CopiarFotografiaACarpetaDeFotografias()
        {
            //asignar parametros
            string iRutaArchivo = pbImaExi.ImageLocation;
            string iRutaCarpetaDestino = ParametroRN.BuscarParametro().RutaImagenExistencia;

            //ejecutar metodo
            Archivo.CopiarArchivo(iRutaArchivo, iRutaCarpetaDestino);
        }

        public string ObtenerRutaFotografia()
        {
            //asignar parametros
            string iRutaArchivo = pbImaExi.ImageLocation;
            string iRutaNuevaCarpeta = ParametroRN.BuscarParametro().RutaImagenExistencia;

            //MessageBox.Show(iRutaArchivo + " ==  " + iRutaNuevaCarpeta, "Ver ahora");

            //ejecutar metodo
            return Ruta.ObtenerNuevaRutaArchivo(iRutaArchivo, iRutaNuevaCarpeta);
        }

        public bool EsNumeroContratoSegunAutomatica(bool pVacio)
        {
            bool iAutomatica = this.chbAuto.Checked;
            ExistenciaRN iConRN = new ExistenciaRN();
            ExistenciaEN iConEN = new ExistenciaEN();
            this.AsignarExistencia(iConEN);
            iConEN = iConRN.EsNumeroContratoSegunAutomatica(iConEN, pVacio, iAutomatica);
            if (iConEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iConEN.Adicionales.Mensaje, "Numero contrato");
                this.txtCodExi.Clear();
                this.txtCodExi.Focus();
            }
            return iConEN.Adicionales.EsVerdad;
        }

        public void HabilitarNumeroContratoSegunAutomatico()
        {
            if (this.chbAuto.Checked == true)
            {
                this.txtCodExi.Clear();
                this.txtCodExi.ReadOnly = true;
                this.txtDesExi.Focus();
            }
            else
            {
                this.txtCodExi.ReadOnly = false;
                this.txtCodExi.Focus();
            }
        }



        #endregion

        private void wEditExistencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wExi.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void txtCodExi_Validated(object sender, EventArgs e)
        {
            this.EsCodigoExistenciaDisponibleEnTxtCodExi();
        }

        private void txtCodAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValido();
        }

        private void txtCodAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes(); }
        }

        private void txtCodAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes();
        }

        private void txtCodAlm_Validated(object sender, EventArgs e)
        {
            this.EsCodigoExistenciaDisponibleEnTxtCodAlm();
        }

        private void cmbUniMedExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) { this.CargarUnidadesMedidaExistencia(); }
        }

        private void cmbTipExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) { this.CargarTiposExistencia(); }
        }

        private void cmbGruExi_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5) { this.CargarGruposExistencia(); }
        }

        private void cmbAreExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) { this.CargarAreasExistencia(); }
        }

        private void cmbCatExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) { this.CargarCatalogosExistencia(); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            this.CambiarFotografiaExistencia();
        }

        private void txtCodUbiExi_DoubleClick(object sender, EventArgs e)
        {
            //this.ListarAlmacenes();
            this.ListarUbicaciones();
        }

        private void txtCodUbiExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarUbicaciones(); }
        }

        private void txtCodUbiExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoUbicacionValida();
        }

        private void cmbConvUnid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //string wSupleSiNo = string.Empty;
            wSupleSiNo = Cmb.ObtenerValor(this.cmbConvUnid, string.Empty);
            //MessageBox.Show(wSupleSiNo, "Ver");
            if (wSupleSiNo == "0")   //Sin Suple
            {
                this.txtFacCon.Text = "000.00000";
                this.txtFacCon.ReadOnly = true;
                this.cmbEstExi.Focus();
            }
            else
            {
                this.txtFacCon.Text = "0.00";
                this.txtFacCon.ReadOnly = false;                
                this.txtFacCon.Focus();
            }
        }

        private void cmbTipExi_Validated(object sender, EventArgs e)
        {
            this.EsCantidadDeUnidadesEditable();            
        }

        private void cmbTipExi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.CargarGruposExistencia();
        }

        private void chbAuto_CheckedChanged(object sender, EventArgs e)
        {
            this.HabilitarNumeroContratoSegunAutomatico();
        }
    }
}
