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
    public partial class wEditParteTrabajo : Heredados.MiForm8
    {
        public wEditParteTrabajo()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
       
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
            xCtrl.txtNoFoco(this.txtCorProDet, this.dtpFecProDet, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecProDet, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCorProCab, true, "Solicitud", "vfff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodExi, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);
           
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNUniMed, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPorRan, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanSalCab, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanSinProDet, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanProDet, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPorSin, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUniRep, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanSin, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanRan, this.txtCorProCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanReaPro, this.dtpFecProDet, "fffff");
            xLis.Add(xCtrl);            

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtObsProDet, false, "Observación", "vvff", 150);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNEstProDet, this.dtpFecProDet, "ffff");
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
            //this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wParTra.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();                   

            //Deshabilitar al propietario de esta ventana
            //this.wParTra.Enabled = false;

            //Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto()
        {
            //traer al alamcen de produccion
            AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacenXCodigo("A10");

            //mostrar datos en pantalla
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(ProduccionDetaRN.EnBlanco());
            this.ValoresXDefecto();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.txtCorProCab.Focus();           
        }

        public void VentanaModificar(ProduccionDetaEN pPro)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pPro);           
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.txtObsProDet.Focus();
        }

        public void VentanaEliminar(ProduccionDetaEN pPro)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pPro);           
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(ProduccionDetaEN pPro)
        {
            this.InicializaVentana();
            this.MostrarProduccionDeta(pPro);           
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();         
        }

        public void AsignarProduccionDeta(ProduccionDetaEN pPro)
        {
            pPro.CodigoEmpresa = Universal.gCodigoEmpresa;
            pPro.CorrelativoProduccionDeta = this.txtCorProDet.Text.Trim();
            pPro.FechaProduccionDeta = this.dtpFecProDet.Text;
            pPro.PeriodoProduccionDeta = Fecha.ObtenerPeriodo(pPro.FechaProduccionDeta, "-");
            pPro.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pPro.CorrelativoProduccionCabe = this.txtCorProCab.Text.Trim();
            pPro.CodigoExistencia = this.txtCodExi.Text.Trim();
            pPro.CodigoUnidadMedida = this.txtCUniMed.Text.Trim();
            pPro.CodigoMercaderia = this.txtCodMer.Text.Trim();
            pPro.CEsExacto = this.txtCEsExa.Text.Trim();
            pPro.PorcentajeRango = Conversion.ADecimal(this.txtPorRan.Text.Trim(), 0);
            pPro.SaldoProduccionCabe = Convert.ToDecimal( this.txtCanSalCab.Text.Trim());           
            pPro.CantidadProduccionDeta = Conversion.ADecimal(this.txtCanProDet.Text.Trim(), 0);
            pPro.UnidadesReproceso = Conversion.ADecimal(this.txtUniRep.Text.Trim(), 0);
            pPro.CostoUnidadesReproceso = Conversion.ADecimal(this.txtCosUniRep.Text.Trim(), 0);
            pPro.CantidadRango = Conversion.ADecimal(this.txtCanRan.Text.Trim(), 0);
            pPro.ObservacionProduccionDeta = this.txtObsProDet.Text.Trim();          
            pPro.ClaveProduccionCabe = this.ObtenerClaveProduccionCabe();
            pPro.CantidadSinceradoProduccionDeta = Conversion.ADecimal(this.txtCanSinProDet.Text.Trim(), 0);            
            pPro.PorcentajeSinceradoRango = Conversion.ADecimal(this.txtPorSin.Text.Trim(), 0);
            pPro.CantidadSinceradoRango = Conversion.ADecimal(this.txtCanSin.Text.Trim(), 0);
            pPro.DetalleMotivoSincerado = this.txtDetMotSin.Text.Trim();
            pPro.CTurno = this.txtCTur.Text;
            pPro.ClaveProduccionDeta = ProduccionDetaRN.ObtenerClaveProduccionDeta(pPro);            
        }

        public void MostrarProduccionDeta(ProduccionDetaEN pPro)
        {
            this.txtCorProDet.Text = pPro.CorrelativoProduccionDeta;
            this.dtpFecProDet.Text = pPro.FechaProduccionDeta;
            this.txtCodAlm.Text = pPro.CodigoAlmacen;
            this.txtDesAlm.Text = pPro.DescripcionAlmacen;
            this.txtCorProCab.Text = pPro.CorrelativoProduccionCabe;
            this.txtCodExi.Text = pPro.CodigoExistencia;
            this.txtDesExi.Text = pPro.DescripcionExistencia;
            this.txtCUniMed.Text = pPro.CodigoUnidadMedida;
            this.txtNUniMed.Text = pPro.NombreUnidadMedida;
            this.txtCodMer.Text = pPro.CodigoMercaderia;
            this.txtCEsExa.Text = pPro.CEsExacto;
            this.txtPorRan.Text = Formato.NumeroDecimal(pPro.PorcentajeRango, 2);
            this.txtCanSalCab.Text = Formato.NumeroDecimal(pPro.SaldoProduccionCabe, 0);
            this.txtCanProDet.Text = Formato.NumeroDecimal(pPro.CantidadProduccionDeta, 0);
            this.txtCanProDetAnt.Text = Formato.NumeroDecimal(pPro.CantidadProduccionDeta, 0);
            this.txtCanReaPro.Text = Formato.NumeroDecimal(pPro.CantidadRealProduccion, 0);
            this.txtUniRep.Text = Formato.NumeroDecimal(pPro.UnidadesReproceso, 0);
            this.txtCosUniRep.Text = Formato.NumeroDecimal(pPro.CostoUnidadesReproceso, 0);
            this.txtCanRan.Text = Formato.NumeroDecimal(pPro.CantidadRango, 0);
            this.txtObsProDet.Text = pPro.ObservacionProduccionDeta;
            this.txtNEstProDet.Text = pPro.NEstadoProduccionDeta;
            this.txtCTur.Text = pPro.CTurno;
            this.txtCanSinProDet.Text = Formato.NumeroDecimal(pPro.CantidadSinceradoProduccionDeta, 0);
            this.txtPorSin.Text = Formato.NumeroDecimal(pPro.PorcentajeSinceradoRango, 0);
            this.txtCanSin.Text = Formato.NumeroDecimal(pPro.CantidadSinceradoRango, 0);
            this.txtDetMotSin.Text = pPro.DetalleMotivoSincerado;
        }

        public void MostrarNuevoCorrelativo()
        {
            //asignar parametros
            ProduccionDetaEN iProCabEN = this.NuevaProduccionDetaDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = ProduccionDetaRN.ObtenerNuevoNumeroProduccionDetaAutogenerado(iProCabEN);

            //mostrar en pantalla
            this.txtCorProDet.Text = iNuevoNumero;
        }

        public ProduccionDetaEN NuevaProduccionDetaDeVentana()
        {
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();
            this.AsignarProduccionDeta(iProCabEN);
            return iProCabEN;
        }

        public string ObtenerClaveProduccionDeta()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();

            //devolver
            return iProDetEN.ClaveProduccionDeta;
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

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wParTra.eTitulo) == false) { return; }

            //Mostrar el nuevo correlativo en pantalla
            this.MostrarNuevoCorrelativo();  

            //adicionando el registro
            this.AdicionarProduccionDeta();

            //adicionando las ProduccionExis
            this.AdicionarProduccionExis();

            //modificar la solicitud
            this.ModificarProduccionCabeAlAdicionar();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se agrego el parte trabajo correctamente", this.wParTra.eTitulo);

            ////actualizar al wLot          
            //this.wParTra.eClaveDgvProDet = this.ObtenerClaveProduccionDeta();
            //this.wParTra.ActualizarVentana();

            //limpiar controles
            this.MostrarProduccionDeta(this.ObtenerObjetoConValoresPersistentes());
            eMas.AccionPasarTextoPrincipal();          
            this.txtCorProCab.Focus();          
        }

        public ProduccionDetaEN ObtenerObjetoConValoresPersistentes()
        {
            //objeto resultado
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

            //capturar datos persistentes
            iProDetEN.FechaProduccionDeta = this.dtpFecProDet.Text;
            iProDetEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iProDetEN.DescripcionAlmacen = this.txtDesAlm.Text.Trim();

            //devolver
            return iProDetEN;
        }

        public bool EsFechaValida()
        {
            //asignar parametros
            ProduccionDetaEN iProCabEN = new ProduccionDetaEN();
            this.AsignarProduccionDeta(iProCabEN);

            //ejecutar metodo
            iProCabEN = ProduccionDetaRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iProCabEN);

            //mostrar mensaje error
            Generico.MostrarMensajeError(iProCabEN.Adicionales, this.dtpFecProDet);

            //devolver
            return iProCabEN.Adicionales.EsVerdad;
        }

        public void AdicionarProduccionDeta()
        {
            ProduccionDetaEN iProEN = new ProduccionDetaEN();
            this.AsignarProduccionDeta(iProEN);
            ProduccionDetaRN.AdicionarProduccionDeta(iProEN);
        }

        public void AdicionarProduccionExis()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();
            ProduccionCabeEN iProCabEN = ProduccionCabeRN.BuscarProduccionCabeXClave(iProDetEN.ClaveProduccionCabe);

            //ejecutar metodos
            ProduccionExisRN.AdicionarProduccionesExisFaseMasa(iProDetEN, iProCabEN.DetalleFormulasDeta );
            ProduccionExisRN.AdicionarProduccionesExisFaseControlCalidad(iProDetEN, iProCabEN.DetalleFormulasDeta);
        }

        public void ModificarProduccionCabeAlAdicionar()
        {
            //asignar parametros            
            string iClaveProduccionCabe = this.ObtenerClaveProduccionCabe();
            decimal iCantidadProduccionDeta= Conversion.ADecimal(this.txtCanProDet.Text.Trim(), 0);

            //ejecutar metodo
            ProduccionCabeRN.ModificarProduccionCabeAlAdicionarParteTrabajo(iClaveProduccionCabe, iCantidadProduccionDeta);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wParTra.EsActoModificarProduccionDeta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wParTra.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarProduccionDeta();

            //eliminar ProduccionExis anterior
            this.EliminarProduccionExis();

            //adicionando las ProduccionExis
            this.AdicionarProduccionExis();

            //modificar la solicitud
            this.ModificarProduccionCabeAlModificar();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se modifico el parte trabajo correctamente", this.wParTra.eTitulo);

            ////actualizar al wLot        
            //this.wParTra.eClaveDgvProDet = this.ObtenerClaveProduccionDeta();
            //this.wParTra.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }

        public void ModificarProduccionDeta()
        {
            ProduccionDetaEN iProEN = new ProduccionDetaEN();
            this.AsignarProduccionDeta(iProEN);
            iProEN = ProduccionDetaRN.BuscarProduccionDetaXClave(iProEN);
            this.AsignarProduccionDeta(iProEN);
            iProEN.UnidadesParaReproceso = ProduccionDetaRN.ObtenerNuevaCantidadParaReprocesar(iProEN);
            ProduccionDetaRN.ModificarProduccionDeta(iProEN);
        }

        public void EliminarProduccionExis()
        {
            //asignar parametros
            string iClaveProduccionDeta = this.ObtenerClaveProduccionDeta();

            //ejecutar metodo
            ProduccionExisRN.EliminarProduccionExisXClaveProduccionDeta(iClaveProduccionDeta);
        }

        public void ModificarProduccionCabeAlModificar()
        {
            //asignar parametros            
            string iClaveProduccionCabe = this.ObtenerClaveProduccionCabe();
            decimal iCantidadProduccionDeta = Conversion.ADecimal(this.txtCanProDet.Text.Trim(), 0);
            decimal iCantidadProduccionDetaAnterior = Conversion.ADecimal(this.txtCanProDetAnt.Text.Trim(), 0);

            //ejecutar metodo
            ProduccionCabeRN.ModificarProduccionCabeAlModificarParteTrabajo(iClaveProduccionCabe, iCantidadProduccionDeta, iCantidadProduccionDetaAnterior);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wParTra.EsActoEliminarProduccionDeta().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wParTra.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarProduccionDeta();

            //eliminar ProduccionExis anterior
            this.EliminarProduccionExis();

            //modificar solicitud
            this.ModificarProduccionCabeAlEliminar();

            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se elimino el parte trabajo correctamente", this.wParTra.eTitulo);

            ////actualizar al wLot           
            //this.wParTra.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarProduccionDeta()
        {
            ProduccionDetaEN iProEN = new ProduccionDetaEN();
            this.AsignarProduccionDeta(iProEN);
            ProduccionDetaRN.EliminarProduccionDeta(iProEN);
        }

        public void ModificarProduccionCabeAlEliminar()
        {
            //asignar parametros            
            string iClaveProduccionCabe = this.ObtenerClaveProduccionCabe();
            decimal iCantidadProduccionDeta = Conversion.ADecimal(this.txtCanProDet.Text.Trim(), 0);

            //ejecutar metodo
            ProduccionCabeRN.ModificarProduccionCabeAlEliminarParteTrabajo(iClaveProduccionCabe, iCantidadProduccionDeta);
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
                //Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wParTra.eTitulo);
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
            win.eCtrlFoco = this.txtCorProCab;
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsSolicitudValido()
        {
            //si es de lectura , entonces no lista
            if (this.txtCorProCab.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iProCabEN.CorrelativoProduccionCabe = this.txtCorProCab.Text.Trim();
            iProCabEN.ClaveProduccionCabe = ProduccionCabeRN.ObtenerClaveProduccionCabe(iProCabEN);
            iProCabEN = ProduccionCabeRN.EsProduccionCabeAprobadaValido(iProCabEN);
            if (iProCabEN.Adicionales.EsVerdad == false)
            {
                //Mensaje.OperacionDenegada(iProCabEN.Adicionales.Mensaje, this.wParTra.eTitulo);
                this.txtCorProCab.Focus();
            }

            //mostrar datos
            this.txtCorProCab.Text = iProCabEN.CorrelativoProduccionCabe;
            this.dtpFecProDet.Text = iProCabEN.FechaProduccionCabe;
            this.txtCodExi.Text = iProCabEN.CodigoExistencia;
            this.txtDesExi.Text = iProCabEN.DescripcionExistencia;
            this.txtCUniMed.Text = iProCabEN.CodigoUnidadMedida;
            this.txtNUniMed.Text = iProCabEN.NombreUnidadMedida;
            this.txtCodMer.Text = iProCabEN.CodigoMercaderia;
            this.txtCEsExa.Text = iProCabEN.CEsExacto;
            this.txtPorRan.Text = Formato.NumeroDecimal(iProCabEN.PorcentajeRango, 0);
            this.txtCanSalCab.Text = Formato.NumeroDecimal(iProCabEN.SaldoProduccionCabe, 0);
            this.txtCanProDet.Text = Formato.NumeroDecimal(iProCabEN.SaldoProduccionCabe, 0);
            this.txtCanProDetAnt.Text = Formato.NumeroDecimal(iProCabEN.SaldoProduccionCabe, 0);
            this.txtUniRep.Text= Formato.NumeroDecimal(iProCabEN.UnidadesReproceso, 0);
            this.txtCanRan.Text = Formato.NumeroDecimal(iProCabEN.CantidadRango, 0);
            this.txtCTur.Text = iProCabEN.CTurno;
            this.txtCanSinProDet.Text = Formato.NumeroDecimal(iProCabEN.CantidadSinceradoProduccionCabe, 0);
            this.txtPorSin.Text = Formato.NumeroDecimal(iProCabEN.PorcentajeSinceradoRango, 0);
            this.txtCanSin.Text = Formato.NumeroDecimal(iProCabEN.CantidadSinceradoRango, 0);
            this.txtDetMotSin.Text = iProCabEN.DetalleMotivoSincerado;

            //devolver
            return iProCabEN.Adicionales.EsVerdad;
        }

        public void ListarSolicitudes()
        {
            //solo si el control no esta de solo lectura
            if (this.txtCorProCab.ReadOnly == true) { return; }

            //instanciar
            wLisSolPro win = new wLisSolPro();
            win.eVentana = this;
            win.eTituloVentana = "Solicitudes pendientes";
            win.eCtrlValor = this.txtCorProCab;
            win.eCtrlFoco = this.txtObsProDet;
            win.eProCabEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            win.eCondicionLista = Listas.wLisSolPro.Condicion.SolicitudesAprobadasDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public string ObtenerClaveProduccionCabe()
        {
            //asignar parametros
            ProduccionCabeEN iProCabEN = new ProduccionCabeEN();
            iProCabEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iProCabEN.CorrelativoProduccionCabe = this.txtCorProCab.Text.Trim();

            //ejecutar metodo
            return ProduccionCabeRN.ObtenerClaveProduccionCabe(iProCabEN);
        }

        public bool EsCantidadCorrecta()
        {
            //asignar parametro
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();

            //ejecutar metodo
            iProDetEN = ProduccionDetaRN.EsCantidadProduccionDetaCorrecta(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, this.txtCanProDet);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public bool EsCantidadReprocesoCorrecta()
        {
            //asignar parametro
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();

            //ejecutar metodo
            iProDetEN = ProduccionDetaRN.EsCantidadReprocesoCorrecta(iProDetEN);

            //mensaje error
            Generico.MostrarMensajeError(iProDetEN.Adicionales, this.txtUniRep);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public void AccionEditaCantidadReproceso()
        {
            //valida si es correcta la cantidad digitada
            if (this.EsCantidadReprocesoCorrecta() == false) { return; }

            //mostrar el costo total de las unidades de reproceso
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();

            //ejecutar metodo
            decimal iCosto = ProduccionDetaRN.ObtenerCostoUnidadesReproceso(iProDetEN);

            //mostrar en pantalla
            this.txtCosUniRep.Text = Formato.NumeroDecimal(iCosto, 2);
        }

        public void MostrarCantidadReproceso()
        {
            //asignar parametros
            ProduccionDetaEN iProDetEN = this.NuevaProduccionDetaDeVentana();

            //ejecutar metodo
            decimal iValor = ProduccionDetaRN.ObtenerCantidadSugeridaParaReprocesar(iProDetEN);

            //mostrar en pantalla
            this.txtUniRep.Text = Formato.NumeroDecimal(iValor, 0);
        }
        
        public void Cancelar()
        {
            //Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wParTra.eTitulo);
        }


            

        #endregion
                

        private void wEditParteTrabajo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wParTra.Enabled = true;
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

        private void txtCorProCab_Validating(object sender, CancelEventArgs e)
        {
            this.EsSolicitudValido();
        }

        private void txtCorProCab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarSolicitudes(); }
        }

        private void txtCorProCab_DoubleClick(object sender, EventArgs e)
        {
            this.ListarSolicitudes();
        }

        private void txtCanProDet_Validated(object sender, EventArgs e)
        {
            //this.EsCantidadCorrecta();
        }

        private void txtUniRep_Validated(object sender, EventArgs e)
        {
            //this.EsCantidadReprocesoCorrecta();
        }
    }
}
