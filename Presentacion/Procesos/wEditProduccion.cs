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
using Presentacion.Procesos;
using Presentacion.FuncionesGenericas;

 


namespace Presentacion.Procesos
{
    public partial class wEditProduccion : Heredados.MiForm8
    {
        public wEditProduccion()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();             

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
            xCtrl.txtNoFoco(this.txtCorProCab, this.dtpFecProCab, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecProCab, "vvfff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, txtCodAlm, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExi, true, "Formula", "vvfff", 16);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNUniMed, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPorRan, this.txtCodExi, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanProCab, true, "Cantidad estimada (Uni)", "vvfff", 0, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtUniRep, false, "Unidades reproceso (Uni)", "vvfff", 0, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroPositivoConDecimales(this.txtCanRan, false, "Unidades rango (Envasado)", "vvfff", 0, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanReaPro, this.dtpFecProCab, "fffff");
            xLis.Add(xCtrl);                       

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbTur, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAux, false, "Cliente", "vvfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAux, this.txtCodAux,  "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodLic, false, "Licitacion", "vvfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesLic, this.txtCodLic, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtObsProCab, false, "Observación", "vvfff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNEstProCab, this.dtpFecProCab, "fffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvfv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnCancelar, "vvvvv");
            xLis.Add(xCtrl);

            return xLis;
        }

        #endregion

        #region General


        public void InicializaVentana()
        {
            //titulo ventana
            //this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wPro.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //llenar combos      
            this.CargarTurnos();

            //Deshabilitar al propietario de esta ventana
            //this.wPro.Enabled = false;

            //Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto()
        {
            this.ValoresXDefectoAlmacen();
            this.ValoresXDefectoAuxiliar();
        }

        public void ValoresXDefectoAlmacen()
        {
            //traer al alamcen de produccion
            AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacenXCodigo("A10");

            //mostrar datos en pantalla
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
        }

        public void ValoresXDefectoAuxiliar()
        {
            //traer al auxiliar x defecto
            AuxiliarEN iAuxEN = AuxiliarRN.BuscarAuxiliarXCodigo("100100100");

            //mostrar valores en pantalla
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarProduccionCabe(ProduccionCabeRN.EnBlanco());
            this.ValoresXDefecto();         
            eMas.AccionHabilitarControles(0);           
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecProCab.Focus();         
        }

        public void VentanaModificar(ProduccionCabeEN pPro)
        {
            this.InicializaVentana();
            this.MostrarProduccionCabe(pPro);           
            eMas.AccionHabilitarControles(1);           
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecProCab.Focus();
        }

        public void VentanaEliminar(ProduccionCabeEN pPro)
        {
            this.InicializaVentana();
            this.MostrarProduccionCabe(pPro);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaAnular(ProduccionCabeEN pPro)
        {
            this.InicializaVentana();
            this.MostrarProduccionCabe(pPro);
            eMas.AccionHabilitarControles(4);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(ProduccionCabeEN pPro)
        {
            this.InicializaVentana();
            this.MostrarProduccionCabe(pPro);           
            eMas.AccionHabilitarControles(3);
            this.btnAceptar.Focus();
        }

        public void CargarTurnos()
        {
            Cmb.Cargar(this.cmbTur, ItemGRN.ListarItemsG("Turno"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void AsignarProduccionCabe(ProduccionCabeEN pPro)
        {
            pPro.CodigoEmpresa = Universal.gCodigoEmpresa;
            pPro.CorrelativoProduccionCabe = this.txtCorProCab.Text.Trim();
            pPro.FechaProduccionCabe = this.dtpFecProCab.Text;
            pPro.PeriodoProduccionCabe = Fecha.ObtenerPeriodo(pPro.FechaProduccionCabe, "-");
            pPro.CodigoAlmacen = this.txtCodAlm.Text.Trim();            
            pPro.CodigoExistencia = this.txtCodExi.Text.Trim();
            pPro.CodigoUnidadMedida = this.txtCUniMed.Text.Trim();
            pPro.CodigoMercaderia = this.txtCodMer.Text.Trim();
            pPro.CEsExacto = this.txtCEsExa.Text.Trim();
            pPro.CantidadFormula = Conversion.ADecimal(this.txtCanForCab.Text, 0); 
            pPro.PorcentajeRango = Conversion.ADecimal(this.txtPorRan.Text, 0);
            pPro.CantidadProduccionCabe = Conversion.ADecimal(this.txtCanProCab.Text, 0); 
            pPro.UnidadesReproceso = Conversion.ADecimal(this.txtUniRep.Text, 0); 
            pPro.CantidadRango = Conversion.ADecimal(this.txtCanRan.Text, 0);
            pPro.SaldoProduccionCabe = ProduccionCabeRN.ObtenerSaldoProduccionCabe(pPro);
            pPro.CTurno = Cmb.ObtenerValor(this.cmbTur, string.Empty);
            pPro.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            pPro.CodigoLicitacion = this.txtCodLic.Text.Trim();
            pPro.ObservacionProduccionCabe = this.txtObsProCab.Text.Trim();
            pPro.PorcentajeSinceradoRango = Conversion.ADecimal(this.txtPorRan.Text, 0);
            pPro.CantidadSinceradoProduccionCabe = Conversion.ADecimal(this.txtCanProCab.Text, 0);            
            pPro.CantidadSinceradoRango = Conversion.ADecimal(this.txtCanRan.Text, 0);
            pPro.ClaveProduccionCabe = ProduccionCabeRN.ObtenerClaveProduccionCabe(pPro);            
        }

        public void MostrarProduccionCabe(ProduccionCabeEN pPro)
        {
            this.txtCorProCab.Text = pPro.CorrelativoProduccionCabe;
            this.dtpFecProCab.Text = pPro.FechaProduccionCabe;
            this.txtCodAlm.Text = pPro.CodigoAlmacen;
            this.txtDesAlm.Text = pPro.DescripcionAlmacen;
            this.txtCodExi.Text = pPro.CodigoExistencia;
            this.txtDesExi.Text = pPro.DescripcionExistencia;            
            this.txtCUniMed.Text = pPro.CodigoUnidadMedida;
            this.txtNUniMed.Text = pPro.NombreUnidadMedida;
            this.txtCodMer.Text = pPro.CodigoMercaderia;
            this.txtCEsExa.Text = pPro.CEsExacto;     
            this.txtCanForCab.Text = pPro.CantidadFormula.ToString();
            this.txtPorRan.Text = Formato.NumeroDecimal(pPro.PorcentajeRango, 2);
            this.txtCanProCab.Text = Formato.NumeroDecimal(pPro.CantidadProduccionCabe, 0);
            this.txtUniRep.Text = Formato.NumeroDecimal(pPro.UnidadesReproceso, 0);
            this.txtCanRan.Text = Formato.NumeroDecimal(pPro.CantidadRango, 2);
            this.txtCanReaPro.Text = Formato.NumeroDecimal(pPro.CantidadRealProduccion, 0);
            Cmb.SeleccionarValorItem(this.cmbTur, pPro.CTurno);
            this.txtCodAux.Text = pPro.CodigoAuxiliar;
            this.txtDesAux.Text = pPro.DescripcionAuxiliar;
            this.txtCodLic.Text = pPro.CodigoLicitacion;
            this.txtDesLic.Text = pPro.DescripcionLicitacion;
            this.txtObsProCab.Text = pPro.ObservacionProduccionCabe;
            this.txtNEstProCab.Text = pPro.NEstadoProduccionCabe;
        }

        public void MostrarNuevoCorrelativo()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = ProduccionCabeRN.ObtenerNuevoNumeroProduccionCabeAutogenerado(iProCabEN);

            //mostrar en pantalla
            this.txtCorProCab.Text = iNuevoNumero;
        }

        public ProduccionCabeEN NuevaProduccionCabeDeVentana()
        {
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            this.AsignarProduccionCabe(iProCabEN);
            return iProCabEN;
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                case Universal.Opera.Anular: { this.Anular(); break; }
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }

            //valida formula
            if (this.ValidaCuandoHayFormulasDetaConCantidadCero() == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wPro.eTitulo) == false) { return; }

            //Mostrar el nuevo correlativo en pantalla
            this.MostrarNuevoCorrelativo();

            //adicionando el registro
            this.AdicionarProduccionCabe();

            //mensaje satisfactorio
           ///* Mensaje.Ope*/racionSatisfactoria("Se agrego la solicitud correctamente", this.wPro.eTitulo);

            //actualizar al wLot
            ProduccionCabeEN iIteAlmEN = this.NuevaProduccionCabeDeVentana();
            //this.wPro.eClaveDgvProCab = iIteAlmEN.ClaveProduccionCabe;
            //this.wPro.ActualizarVentana();

            //limpiar controles
            this.MostrarProduccionCabe(this.ObtenerObjetoConValoresPersistentes());
            eMas.AccionPasarTextoPrincipal();
            this.txtCodExi.Focus();
        }

        public ProduccionCabeEN ObtenerObjetoConValoresPersistentes()
        {
            //objeto resultado
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();

            //capturar datos persistentes
            iProCabEN.FechaProduccionCabe = this.dtpFecProCab.Text;
            iProCabEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iProCabEN.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            iProCabEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iProCabEN.DescripcionAuxiliar = this.txtDesAux.Text.Trim();

            //devolver
            return iProCabEN;
        }

        public bool EsFechaValida()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            this.AsignarProduccionCabe(iProCabEN);

            //ejecutar metodo
            iProCabEN = ProduccionCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iProCabEN);

            //mostrar mensaje error
            Generico.MostrarMensajeError(iProCabEN.Adicionales, this.dtpFecProCab);

            //devolver
            return iProCabEN.Adicionales.EsVerdad;
        }
        
        public bool ValidaCuandoHayFormulasDetaConCantidadCero()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            iProCabEN = ProduccionCabeRN.EsFormulaCorrecta(iProCabEN);

            //mostrar mensaje error
            Generico.MostrarMensajeError(iProCabEN.Adicionales, this.txtCodExi);

            //devolver
            return iProCabEN.Adicionales.EsVerdad;
        }
        
        public void AdicionarProduccionCabe()
        {
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            this.AsignarProduccionCabe(iProCabEN);
            iProCabEN.DetalleFormulasDeta = this.ArmarCampoDetalleFormulasDeta();
            ProduccionCabeRN.AdicionarProduccionCabe(iProCabEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }

            //valida formula
            if (this.ValidaCuandoHayFormulasDetaConCantidadCero() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wPro.EsActoModificarProduccionCabe().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wPro.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarProduccionCabe();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se modifico la solicitud correctamente", this.wPro.eTitulo);

            //actualizar al wLot
            ProduccionCabeEN iProEN = this.NuevaProduccionCabeDeVentana();           
            //this.wPro.eClaveDgvProCab = iProEN.ClaveProduccionCabe;
            //this.wPro.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarProduccionCabe()
        {
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            this.AsignarProduccionCabe(iProCabEN);
            iProCabEN = ProduccionCabeRN.BuscarProduccionCabeXClave(iProCabEN);
            this.AsignarProduccionCabe(iProCabEN);
            iProCabEN.DetalleFormulasDeta = this.ArmarCampoDetalleFormulasDeta();
            ProduccionCabeRN.ModificarProduccionCabe(iProCabEN);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wPro.EsActoEliminarProduccionCabe().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wPro.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarProduccionCabe();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se elimino la solicitud correctamente", this.wPro.eTitulo);

            //actualizar al wLot           
            //this.wPro.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarProduccionCabe()
        {
            ProduccionCabeEN iProEN = new ProduccionCabeEN();
            this.AsignarProduccionCabe(iProEN);
            ProduccionCabeRN.EliminarProduccionCabe(iProEN);
        }

        public void Anular()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wPro.EsActoAnularProduccionCabe().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wPro.eTitulo) == false) { return; }

            //eliminar el registro
            this.AnularProduccionCabe();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se anulo la solicitud correctamente", this.wPro.eTitulo);

            //actualizar al wLot           
            //this.wPro.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void AnularProduccionCabe()
        {
            //asignar parametro
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            ProduccionCabeRN.AnularProduccionCabe(iProCabEN);
        }
        
        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                //Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wPro.eTitulo);
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarAlmacenes()
        {
            //solo si el control no esta de solo lectura
            if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm;
            win.eCtrlFoco = this.txtCodExi;
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void ListarFormulas()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExi.ReadOnly == true) { return; }

            //instanciar lista
            wLisFor win = new wLisFor();
            win.eVentana = this;
            win.eTituloVentana = "Formulas";
            win.eCtrlValor = this.txtCodExi;
            win.eCtrlFoco = this.txtCanProCab;
            win.eExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            win.eCondicionLista = wLisFor.Condicion.FormulaCabesActivasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoFormulaValido()
        {
            //solo si esta habilitado el control
            if (this.txtCodExi.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            FormulaCabeEN iForCabEN = this.NuevaFormulaCabeVentana();

            //ejecutar metodo
            iForCabEN = FormulaCabeRN.EsFormulaCabeActivoValido(iForCabEN);

            //mensaje de error
            Generico.MostrarMensajeError(iForCabEN.Adicionales, this.txtCodExi);
            
            //pasar datos
            this.txtCodExi.Text = iForCabEN.CodigoExistencia;
            this.txtDesExi.Text = iForCabEN.DescripcionExistencia;
            this.txtCUniMed.Text = iForCabEN.CodigoUnidadMedida;
            this.txtNUniMed.Text = iForCabEN.NombreUnidadMedida;
            this.MostrarCantidadReproceso();
            this.MostrarPorcentajeRango();
            this.MostrarCantidadRango();
           
            //devolver
            return iForCabEN.Adicionales.EsVerdad;
        }

        public FormulaCabeEN NuevaFormulaCabeVentana()
        {
            //crear un nuevo objeto
            FormulaCabeEN iForCabEN = new FormulaCabeEN();

            //pasamos datos desde las ventanas
            iForCabEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iForCabEN.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            iForCabEN.CodigoExistencia = this.txtCodExi.Text.Trim();
            iForCabEN.ClaveFormulaCabe = FormulaCabeRN.ObtenerClaveFormulaCabe(iForCabEN);

            //devolver
            return iForCabEN;
        }

        public void ListarClientes()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            wLisAux win = new wLisAux();
            win.eVentana = this;
            win.eTituloVentana = "Clientes";
            win.eCtrlValor = this.txtCodAux;
            win.eCtrlFoco = this.txtCodLic;
            win.eCondicionLista = Listas.wLisAux.Condicion.ClientesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsClienteValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAux.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iAuxEN = AuxiliarRN.EsClienteActivoValido(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                //Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.wPro.eTitulo);
                this.txtCodAux.Focus();
            }

            //mostrar datos
            this.txtCodAux.Text = iAuxEN.CodigoAuxiliar;
            this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        public void ListarLicitaciones()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodLic.ReadOnly == true) { return; }

            //instanciar
            wLisLic win = new wLisLic();
            win.eVentana = this;
            win.eTituloVentana = "Licitaciones";
            win.eCtrlValor = this.txtCodLic;
            win.eCtrlFoco = this.txtObsProCab;
            win.eLicEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();//cliente
            win.eCondicionLista = Listas.wLisLic.Condicion.LicitacionesActivasDeCliente;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsLicitacionValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodLic.ReadOnly == true) { return true; }

            //validar
            LicitacionEN iLicEN = new LicitacionEN();
            iLicEN.CodigoAuxiliar = this.txtCodAux.Text.Trim();
            iLicEN.CodigoLicitacion = this.txtCodLic.Text.Trim();
            iLicEN.ClaveLicitacion = LicitacionRN.ObtenerClaveLicitacion(iLicEN);
            iLicEN = LicitacionRN.EsLicitacionActivaValido(iLicEN);
            if (iLicEN.Adicionales.EsVerdad == false)
            {
                //Mensaje.OperacionDenegada(iLicEN.Adicionales.Mensaje, this.wPro.eTitulo);
                this.txtCodLic.Focus();
            }

            //mostrar datos
            this.txtCodLic.Text = iLicEN.CodigoLicitacion;
            this.txtDesLic.Text = iLicEN.DescripcionLicitacion;

            //devolver
            return iLicEN.Adicionales.EsVerdad;
        }

        public bool EsCantidadReprocesoCorrecta()
        {
            //si es de lectura , entonces no lista
            if (txtUniRep.ReadOnly == true) { return true; }

            //asignar parametro
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            iProCabEN = ProduccionCabeRN.EsCantidadReprocesoCorrecta(iProCabEN);

            //mensaje error
            Generico.MostrarMensajeError(iProCabEN.Adicionales, this.txtUniRep);

            //devolver
            return iProCabEN.Adicionales.EsVerdad;
        }

        public void MostrarCantidadReproceso()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            decimal iValor = ProduccionCabeRN.ObtenerCantidadSugeridaParaReprocesar(iProCabEN);

            //mostrar en pantalla
            this.txtUniRep.Text = Formato.NumeroDecimal(iValor, 0);
        }

        public string ArmarCampoDetalleFormulasDeta()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            return ProduccionCabeRN.ArmarCampoDetalleFormulasDeta(iProCabEN);
        }

        public void MostrarPorcentajeRango()
        {
            //si es de lectura , entonces no lista
            if (txtCanProCab.ReadOnly == true) { return; }

            //asignar parametros
            ProduccionCabeEN iProCabEN = this.NuevaProduccionCabeDeVentana();

            //ejecutar metodo
            decimal iPorcentaje = ProduccionCabeRN.ObtenerPorcentajeRango(iProCabEN);

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
            decimal iPorcentaje = ProduccionCabeRN.ObtenerCantidadRango(iProCabEN);

            //mostrar en pantalla
            this.txtCanRan.Text = Formato.NumeroDecimal(iPorcentaje, 2);
        }

        public void Cancelar()
        {
            //Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wPro.eTitulo);
        }


            

        #endregion
                

        private void wEditProduccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wPro.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
       
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCodAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes();
        }

        private void txtCodAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes(); }
        }

        private void txtCodAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValido();
        }
              
        private void txtCodAux_Validating(object sender, CancelEventArgs e)
        {
            this.EsClienteValido();
        }

        private void txtCodAux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarClientes(); }
        }

        private void txtCodAux_DoubleClick(object sender, EventArgs e)
        {
            this.ListarClientes();
        }

        private void txtCodExi_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoFormulaValido();
        }

        private void txtCodExi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarFormulas(); }
        }

        private void txtCodExi_DoubleClick(object sender, EventArgs e)
        {
            this.ListarFormulas();
        }

        private void txtCodLic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarLicitaciones(); }
        }

        private void txtCodLic_DoubleClick(object sender, EventArgs e)
        {
            this.ListarLicitaciones();
        }

        private void txtCodLic_Validating(object sender, CancelEventArgs e)
        {
            this.EsLicitacionValido();
        }

        private void dtpFecProCab_Validated(object sender, EventArgs e)
        {
            

        }

        private void txtUniRep_Validated(object sender, EventArgs e)
        {
            this.EsCantidadReprocesoCorrecta();
            this.MostrarPorcentajeRango();
            this.MostrarCantidadRango();
        }

        private void txtCanProCab_Validated(object sender, EventArgs e)
        {
            this.MostrarPorcentajeRango();
            this.MostrarCantidadRango();
        }
    }
}
