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
 


namespace Presentacion.Procesos
{
    public partial class wEditTransferencia : Heredados.MiForm8
    {
        public wEditTransferencia()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<MovimientoDetaEN> eLisMovDet = new List<MovimientoDetaEN>();
        public string eClaveDgvMovDet = string.Empty;
        Dgv.Franja eFranjaDgvMovDet = Dgv.Franja.PorIndice;
       
        #endregion

        #region Propietario

        public wTransferencias wTra;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPerMovCab, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecMovCab, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodTipOpe, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipOpe, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumMovCab, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen Salida", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer, true, "Personal Salida", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer, this.txtCodPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodTipOpe1, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipOpe1, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumMovCab1, this.txtCodAlm, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm1, true, "Almacen Entrada", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm1, this.txtCodAlm1, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer1, true, "Personal Entrada", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer1, this.txtCodPer1, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGloMovCab, false, "Glosa", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAgregar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnModificar, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnQuitar, "vvff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wTra.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();                   

            //valores x defecto
            this.ValoresXDefecto();

            // Deshabilitar al propietario de esta ventana
            this.wTra.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto()
        {
            txtPerMovCab.Text = wTra.lblDescripcionPeriodo.Text;
        }

        public void MostrarTiposOperacionesTransferencia()
        {
            //traemos los codigos de tipos de operacion para la transferencia
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaSalida);

            //mostrar los datos
            this.txtCodTipOpe.Text = iTipOpeEN.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = iTipOpeEN.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = iTipOpeEN.CCalculaPrecioPromedio;

            //traemos al tipo de operacion de transferencia ingreso
            iTipOpeEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaIngreso);

            //mostrar los datos
            this.txtCodTipOpe1.Text = iTipOpeEN.CodigoTipoOperacion;
            this.txtDesTipOpe1.Text = iTipOpeEN.DescripcionTipoOperacion;
            this.txtCCalPrePro1.Text = iTipOpeEN.CCalculaPrecioPromedio;
        }

        public MovimientoCabeEN ObtenerMovimientoCabeIngresoBD(MovimientoCabeEN pMovCabSal)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pMovCabSal.ClaveIngresoMovimientoCabe;

            //ejecutar metodo
            return MovimientoCabeRN.BuscarMovimientoCabeXClave(iMovCabEN);
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabeSalida(MovimientoCabeRN.EnBlanco());
            this.MostrarMovimientoCabeIngreso(MovimientoCabeRN.EnBlanco());
            this.MostrarFechaIngresoSugerida();
            this.MostrarTiposOperacionesTransferencia();
            this.MostrarMovimientosDetaSalida();      
            eMas.AccionHabilitarControles(0);         
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void VentanaModificar(MovimientoCabeEN pMovCabSal)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabeSalida(pMovCabSal);
            this.MostrarMovimientoCabeIngreso(this.ObtenerMovimientoCabeIngresoBD(pMovCabSal));
            this.LLenarMovimientoDetaSalidaDeBaseDatos(pMovCabSal);
            this.MostrarMovimientosDetaSalida();      
            eMas.AccionHabilitarControles(1);          
            eMas.AccionPasarTextoPrincipal();        
            this.dtpFecMovCab.Focus();
        }

        public void VentanaEliminar(MovimientoCabeEN pMovCabSal)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabeSalida(pMovCabSal);
            this.MostrarMovimientoCabeIngreso(this.ObtenerMovimientoCabeIngresoBD(pMovCabSal));
            this.LLenarMovimientoDetaSalidaDeBaseDatos(pMovCabSal);
            this.MostrarMovimientosDetaSalida();
            eMas.AccionHabilitarControles(2);         
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(MovimientoCabeEN pMovCabSal)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabeSalida(pMovCabSal);
            this.MostrarMovimientoCabeIngreso(this.ObtenerMovimientoCabeIngresoBD(pMovCabSal));
            this.LLenarMovimientoDetaSalidaDeBaseDatos(pMovCabSal);
            this.MostrarMovimientosDetaSalida();
            eMas.AccionHabilitarControles(3);           
            this.btnCancelar.Focus();
        }

        public void AsignarMovimientoCabeSalida(MovimientoCabeEN pMovCabSal)
        {
            pMovCabSal.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCabSal.PeriodoMovimientoCabe = wTra.lblPeriodo.Text;
            pMovCabSal.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();
            pMovCabSal.FechaMovimientoCabe = dtpFecMovCab.Text;
            pMovCabSal.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            pMovCabSal.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pMovCabSal.CodigoPersonal = this.txtCodPer.Text.Trim();           
            pMovCabSal.GlosaMovimientoCabe = this.txtGloMovCab.Text;
            pMovCabSal.COrigenVentanaCreacion = "3";//transferencia
            pMovCabSal.ClaveIngresoMovimientoCabe = this.ObtenerClaveMovimientoCabeIngreso();      
            pMovCabSal.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(pMovCabSal);
        }

        public void AsignarMovimientoCabeIngreso(MovimientoCabeEN pMovCabIng)
        {
            pMovCabIng.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCabIng.PeriodoMovimientoCabe = wTra.lblPeriodo.Text;
            pMovCabIng.NumeroMovimientoCabe = this.txtNumMovCab1.Text.Trim();
            pMovCabIng.FechaMovimientoCabe = dtpFecMovCab.Text;
            pMovCabIng.CodigoTipoOperacion = this.txtCodTipOpe1.Text.Trim();
            pMovCabIng.CodigoAlmacen = this.txtCodAlm1.Text.Trim();
            pMovCabIng.CodigoPersonal = this.txtCodPer1.Text.Trim();
            pMovCabIng.GlosaMovimientoCabe = this.txtGloMovCab.Text;
            pMovCabIng.COrigenVentanaCreacion = "3";//transferencia
            pMovCabIng.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(pMovCabIng);
        }

        public void MostrarMovimientoCabeSalida(MovimientoCabeEN pMovCabSal)
        {
            this.dtpFecMovCab.Text = pMovCabSal.FechaMovimientoCabe;
            this.txtCodTipOpe.Text = pMovCabSal.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = pMovCabSal.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = pMovCabSal.CCalculaPrecioPromedio;
            this.txtNumMovCab.Text = pMovCabSal.NumeroMovimientoCabe;         
            this.txtCodAlm.Text = pMovCabSal.CodigoAlmacen;
            this.txtDesAlm.Text = pMovCabSal.DescripcionAlmacen;
            this.txtCodPer.Text = pMovCabSal.CodigoPersonal;
            this.txtNomPer.Text = pMovCabSal.NombrePersonal;          
            this.txtGloMovCab.Text = pMovCabSal.GlosaMovimientoCabe;          
        }

        public void MostrarMovimientoCabeIngreso(MovimientoCabeEN pMovCabIng)
        {
            this.dtpFecMovCab.Text = pMovCabIng.FechaMovimientoCabe;          
            this.txtCodTipOpe1.Text = pMovCabIng.CodigoTipoOperacion;
            this.txtDesTipOpe1.Text = pMovCabIng.DescripcionTipoOperacion;
            this.txtCCalPrePro1.Text = pMovCabIng.CCalculaPrecioPromedio;
            this.txtNumMovCab1.Text = pMovCabIng.NumeroMovimientoCabe;
            this.txtCodAlm1.Text = pMovCabIng.CodigoAlmacen;
            this.txtDesAlm1.Text = pMovCabIng.DescripcionAlmacen;
            this.txtCodPer1.Text = pMovCabIng.CodigoPersonal;
            this.txtNomPer1.Text = pMovCabIng.NombrePersonal;            
        }

        public void MostrarMovimientosDetaSalida()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvMovDet;
            List<MovimientoDetaEN> iFuenteDatos = MovimientoDetaRN.RefrescarListaMovimientoDeta(this.eLisMovDet); ;
            Dgv.Franja iCondicionFranja = eFranjaDgvMovDet;
            string iClaveBusqueda = eClaveDgvMovDet;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas         
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CorMovDet, "Linea", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.DesExi, "Descripcion", 190));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.DesCenCos, "Centro Costo", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CanMovDet, "Cant", 60, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.PreUniMovDet, "P/U", 85, 3));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CosMovDet, "Costo", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarMovimientoDetaSalidaDeBaseDatos(MovimientoCabeEN pMovCabSal)
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pMovCabSal.ClaveMovimientoCabe;
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;
            this.eLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
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

            //volver a preguntar si es acto adicionar
            if(this.wTra.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad== false) { return; }
                        
            //validar el almacen ingreso
            if (this.EsAlmacenValidoIngreso() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTra.eTitulo) == false) { return; }

            //mostrar numero movimientoCabe salida
            this.MostrarNuevoNumeroSalida();

            //mostrar numero movimientoCabe ingreso
            this.MostrarNuevoNumeroIngreso();

            //adicionando el registro salida
            this.AdicionarMovimientoCabeSalida();

            //adicionando el registro ingreso
            this.AdicionarMovimientoCabeIngreso();
            
            //adicionando detalles salida
            this.AdicionarMovimientosDetaSalida();

            //actualizar las existencias salida referenciadas
            this.ActualizarExistenciasSalidaPorAdicion();

            //adicionando detalle ingreso
            this.AdicionarMovimientosDetaIngreso();

            //actualizar las existencias ingreso referenciadas
            this.ActualizarExistenciasIngresoPorAdicion();

            //adiconar lotesDeta para las salidas
            this.AdicionarLotesDeta();

            //adicionar lotes para los ingresos
            this.AdicionarLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la transferencia correctamente", this.wTra.eTitulo);

            //actualizar al propietario           
            this.wTra.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabeSalida();
            this.wTra.ActualizarVentana();

            //limpiar controles
            this.MostrarMovimientoCabeSalida(this.ObtenerMovimientoCabeSalidaParaSegundaAdicion());
            this.MostrarMovimientoCabeIngreso(this.ObtenerMovimientoCabeIngresoParaSegundaAdicion());           
            this.MostrarTiposOperacionesTransferencia();
            this.eLisMovDet.Clear();
            this.MostrarMovimientosDetaSalida();          
            this.CambiarSoloLecturaACodigoAlmacenSalida();       
            this.CambiarSoloLecturaACodigoAlmacenIngreso();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public MovimientoCabeEN ObtenerMovimientoCabeSalidaParaSegundaAdicion()
        {
            //objeto
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //pasamos los datos que queremos persistir para una segundo o mas adiciones
            iMovCabEN.FechaMovimientoCabe = this.dtpFecMovCab.Text;

            //devolver
            return iMovCabEN;
        }

        public MovimientoCabeEN ObtenerMovimientoCabeIngresoParaSegundaAdicion()
        {
            //objeto
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //pasamos los datos que queremos persistir para una segundo o mas adiciones
            iMovCabEN.FechaMovimientoCabe = this.dtpFecMovCab.Text;

            //devolver
            return iMovCabEN;
        }

        public void MostrarNuevoNumeroSalida()
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeSalidaDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);

            //mostrar en pantalla
            this.txtNumMovCab.Text = iNuevoNumero;
        }

        public void MostrarNuevoNumeroIngreso()
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeIngresoDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);

            //mostrar en pantalla
            this.txtNumMovCab1.Text = iNuevoNumero;
        }

        public void AdicionarMovimientoCabeSalida()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeSalida(iCuoEN);
            MovimientoCabeRN.AdicionarMovimientoCabe(iCuoEN);
        }

        public void AdicionarMovimientoCabeIngreso()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeIngreso(iCuoEN);
            MovimientoCabeRN.AdicionarMovimientoCabe(iCuoEN);
        }

        public void AdicionarMovimientosDetaSalida()
        {
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeSalida();
            string iCorrelativo = "0000";

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in this.eLisMovDet)
            {
                //incrementar el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

                //actualizar algunos datos antes de grabar
                xMovDet.FechaMovimientoCabe = this.dtpFecMovCab.Text;
                xMovDet.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();
                xMovDet.ClaveMovimientoCabe = iClaveMovimientoCabe;
                xMovDet.CorrelativoMovimientoDeta = iCorrelativo;
                xMovDet.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(xMovDet);
            }

            //adicion masiva
            MovimientoDetaRN.AdicionarMovimientoDeta(this.eLisMovDet);
        }

        public void AdicionarMovimientosDetaIngreso()
        {
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeIngreso();
            string iCorrelativo = "0000";

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //lista para grabar los detalles ingreso
            List<MovimientoDetaEN> iLisMovDet = new List<MovimientoDetaEN>();

            //recorrer cada objeto
            foreach (MovimientoDetaEN xMovDet in this.eLisMovDet)
            {
                //incrementar el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);                             

                //creamos objeto movimientoDeta
                MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

                //pasamos datos               
                iMovDetEN.ClaveMovimientoCabe = iClaveMovimientoCabe;
                iMovDetEN.CorrelativoMovimientoDeta = iCorrelativo;
                iMovDetEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovDetEN.FechaMovimientoCabe = this.dtpFecMovCab.Text;
                iMovDetEN.PeriodoMovimientoCabe = this.wTra.lblPeriodo.Text;
                iMovDetEN.CodigoAlmacen = this.txtCodAlm1.Text.Trim();
                iMovDetEN.CodigoTipoOperacion = this.txtCodTipOpe1.Text.Trim();
                iMovDetEN.CClaseTipoOperacion = "1";//ingreso
                iMovDetEN.CCalculaPrecioPromedio = this.txtCCalPrePro1.Text.Trim();
                iMovDetEN.NumeroMovimientoCabe = this.txtNumMovCab1.Text.Trim();
                iMovDetEN.CodigoCentroCosto = xMovDet.CodigoCentroCosto;
                iMovDetEN.CodigoExistencia = xMovDet.CodigoExistencia;
                iMovDetEN.CodigoUnidadMedida = xMovDet.CodigoUnidadMedida;
                iMovDetEN.CantidadMovimientoDeta = xMovDet.CantidadMovimientoDeta;
                iMovDetEN.PrecioUnitarioMovimientoDeta = xMovDet.PrecioUnitarioMovimientoDeta;
                iMovDetEN.GlosaMovimientoDeta = xMovDet.GlosaMovimientoDeta;
                iMovDetEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetEN);

                //buscar a la existencia en proceso
                string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(iMovDetEN);
                ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExiEmp);

                //actualizar los datos anteriores de la existencia en el MovimientoDeta
                iMovDetEN.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                iMovDetEN.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;

                //actualizar calculos
                iMovDetEN.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetEN);
                iMovDetEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetEN);
                iMovDetEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetEN);
                iMovDetEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetEN);

                //agregamos a la lista 
                iLisMovDet.Add(iMovDetEN);
            }

            //adicion masiva
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);
        }

        public void ActualizarExistenciasSalidaPorAdicion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.eLisMovDet;

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);
        }

        public void ActualizarExistenciasIngresoPorAdicion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDetaIngreso();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);
        }

        public void AdicionarLotesDeta()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.eLisMovDet;

            //ejecutar metodo
            LoteDetaRN.AdicionarLoteDeta(iLisMovDet);
        }

        public void AdicionarLotes()
        {
            //asignar parametros
            string iCodigoAlmacenIngreso = this.txtCodAlm1.Text.Trim();
            string iClaveMovimientoCabeSalida = this.ObtenerClaveMovimientoCabeSalida();
            string iClaveMovimientoCabeIngreso = this.ObtenerClaveMovimientoCabeIngreso();

            //ejecutar metodo
            LoteRN.AdicionarLotes(iCodigoAlmacenIngreso, iClaveMovimientoCabeIngreso, iClaveMovimientoCabeSalida);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTra.EsMovimientoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTra.eTitulo) == false) { return; }

            //modificar el registro salida
            this.ModificarMovimientoCabeSalida();

            //modificar el registro ingreso
            this.ModificarMovimientoCabeIngreso();

            //actualizar las existencias salida por eliminacion
            this.ActualizarExistenciasSalidaPorEliminacion();

            //eliminar antiguo detalle salida
            this.EliminarAntiguosMovimientosDetaSalida();
          
            //actualizar las existencias ingreso por eliminacion
            this.ActualizarExistenciasIngresoPorEliminacion();
         
            //eliminar antiguo detalle ingreso
            this.EliminarAntiguosMovimientosDetaIngreso();
          
            //adicionando detalles salida
            this.AdicionarMovimientosDetaSalida();

            //actualizar las existencias salida referenciadas
            this.ActualizarExistenciasSalidaPorAdicion();

            //adicionando detalle ingreso
            this.AdicionarMovimientosDetaIngreso();
        
            //actualizar las existencias ingreso referenciadas
            this.ActualizarExistenciasIngresoPorAdicion();

            //eliminar lotesdeta anterior
            this.EliminarLotesDeta();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //adiconar lotesDeta para las salidas
            this.AdicionarLotesDeta();

            //adicionar lotes para los ingresos
            this.AdicionarLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la transferencia correctamente", this.wTra.eTitulo);

            //actualizar al wLot          
            this.wTra.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabeSalida();
            this.wTra.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarMovimientoCabeSalida()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeSalida(iCuoEN);
            iCuoEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(iCuoEN);
            this.AsignarMovimientoCabeSalida(iCuoEN);
            MovimientoCabeRN.ModificarMovimientoCabe(iCuoEN);
        }

        public void ModificarMovimientoCabeIngreso()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeIngreso(iCuoEN);
            iCuoEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(iCuoEN);
            this.AsignarMovimientoCabeIngreso(iCuoEN);
            MovimientoCabeRN.ModificarMovimientoCabe(iCuoEN);
        }

        public void ActualizarExistenciasSalidaPorEliminacion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDetaSalida();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDeta(iLisMovDet);
        }

        public void EliminarAntiguosMovimientosDetaSalida()
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeSalida();
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public void ActualizarExistenciasIngresoPorEliminacion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDetaIngreso();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDeta(iLisMovDet);
        }

        public void EliminarAntiguosMovimientosDetaIngreso()
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeIngreso();
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public void EliminarLotesDeta()
        {
            //asignar parametros
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeSalida();

            //ejecutar metodo
            LoteDetaRN.EliminarLoteDeta(iClaveMovimientoCabe);
        }

        public void EliminarAntiguosLotes()
        {
            //asignar parametros
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeIngreso();

            //ejecutar metodo
            LoteRN.EliminarLoteXClaveMovimientoCabe(iClaveMovimientoCabe);
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wTra.EsMovimientoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wTra.eTitulo) == false) { return; }

            //eliminar el registro salida
            this.EliminarMovimientoCabeSalida();

            //eliminar el registro ingreso
            this.EliminarMovimientoCabeIngreso();

            //actualizar las existencias salida por eliminacion
            this.ActualizarExistenciasSalidaPorEliminacion();

            //eliminar antiguo detalle salida
            this.EliminarAntiguosMovimientosDetaSalida();

            //actualizar las existencias ingreso por eliminacion
            this.ActualizarExistenciasIngresoPorEliminacion();

            //eliminar antiguo detalle ingreso
            this.EliminarAntiguosMovimientosDetaIngreso();

            //eliminar lotesdeta anterior
            this.EliminarLotesDeta();

            //eliminar lotes anterior
            this.EliminarAntiguosLotes();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la transferencia correctamente", this.wTra.eTitulo);

            //actualizar al wLot           
            this.wTra.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarMovimientoCabeSalida()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeSalida(iCuoEN);
            MovimientoCabeRN.EliminarMovimientoCabe(iCuoEN);
        }

        public void EliminarMovimientoCabeIngreso()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeIngreso(iCuoEN);
            MovimientoCabeRN.EliminarMovimientoCabe(iCuoEN);
        }

        public void ListarAlmacenesSalida()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm;
            win.eCtrlFoco = this.txtCodPer;
            win.eAlmEN.CodigoAlmacen = this.txtCodAlm1.Text.Trim();//almacen que no debe listar
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivosExceptoUno;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValidoSalida()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            string iCodigoAlmacenExcepcion = this.txtCodAlm1.Text.Trim();
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN, iCodigoAlmacenExcepcion);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wTra.eTitulo);
                this.txtCodAlm.Focus();
            }

            //mostrar datos
            this.txtCodAlm.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
            this.txtCodPer.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer.Text = iAlmEN.NombrePersonal;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarPersonalesSalida()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer.ReadOnly == true) { return; }

            //instanciar
            wLisPer win = new wLisPer();
            win.eVentana = this;
            win.eTituloVentana = "Personales";
            win.eCtrlValor = this.txtCodPer;
            win.eCtrlFoco = this.txtCodAlm1;
            win.eCondicionLista = Listas.wLisPer.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalValidoSalida()
        {
            //si es de lectura , entonces no lista
            if (txtCodPer.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            Entidades.PersonalEN iPerEN = new Entidades.PersonalEN();
            iPerEN.CodigoPersonal = this.txtCodPer.Text.Trim();            
            iPerEN = PersonalRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wTra.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPer.Text = iPerEN.CodigoPersonal;
            this.txtNomPer.Text = iPerEN.NombrePersonal;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarAlmacenesIngreso()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm1.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm1;
            win.eCtrlFoco = this.txtCodPer1;
            win.eAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();//almacen que no debe listar
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivosExceptoUno;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValidoIngreso()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm1.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm1.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            string iCodigoAlmacenExcepcion = this.txtCodAlm.Text.Trim();
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN, iCodigoAlmacenExcepcion);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wTra.eTitulo);
                this.txtCodAlm1.Focus();
            }

            //mostrar datos
            this.txtCodAlm1.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm1.Text = iAlmEN.DescripcionAlmacen;
            this.txtCodPer1.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer1.Text = iAlmEN.NombrePersonal;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarPersonalesIngreso()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer1.ReadOnly == true) { return; }

            //instanciar
            wLisPer win = new wLisPer();
            win.eVentana = this;
            win.eTituloVentana = "Personales";
            win.eCtrlValor = this.txtCodPer1;
            win.eCtrlFoco = this.txtGloMovCab;
            win.eCondicionLista = Listas.wLisPer.Condicion.PersonalesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalValidoIngreso()
        {
            //si es de lectura , entonces no lista
            if (txtCodPer1.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            Entidades.PersonalEN iPerEN = new Entidades.PersonalEN();
            iPerEN.CodigoPersonal = this.txtCodPer1.Text.Trim();
            iPerEN = PersonalRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wTra.eTitulo);
                this.txtCodPer1.Focus();
            }

            //mostrar datos
            this.txtCodPer1.Text = iPerEN.CodigoPersonal;
            this.txtNomPer1.Text = iPerEN.NombrePersonal;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public MovimientoCabeEN NuevoMovimientoCabeSalidaDeVentana()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeSalida(iMovCabEN);
            return iMovCabEN;
        }

        public MovimientoCabeEN NuevoMovimientoCabeIngresoDeVentana()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeIngreso(iMovCabEN);
            return iMovCabEN;
        }

        public string ObtenerClaveMovimientoCabeSalida()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeSalida(iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public string ObtenerClaveMovimientoCabeIngreso()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabeIngreso(iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public void AccionAgregarItem()
        {
            //valida cuando no hay tipo operacion salida
            if (this.ElegirTipoOperacionSalidaAntesDeLlenarGrilla() == false) { return; }

            //valida cuando no hay almacen salida
            if (this.ElegirAlmacenSalidaAntesDeLlenarGrilla() == false) { return; }

            //valida cuando no hay tipo operacion ingreso
            if (this.ElegirTipoOperacionIngresoAntesDeLlenarGrilla() == false) { return; }

            //valida cuando no hay almacen ingreso
            if (this.ElegirAlmacenIngresoAntesDeLlenarGrilla() == false) { return; }

            //validar el almacen ingreso
            if (this.EsAlmacenValidoIngreso() == false) { return; }

            //instanciar
            wDetalleTransferencia win = new wDetalleTransferencia();
            win.wEditTra = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleTransferencia win = new wDetalleTransferencia();
            win.wEditTra = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisMovDet.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            wDetalleTransferencia win = new wDetalleTransferencia();
            win.wEditTra = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public bool ElegirTipoOperacionSalidaAntesDeLlenarGrilla()
        {
            if (this.txtCodTipOpe.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un tipo de operacion salida", "Tipo operacion");
                this.txtCodTipOpe.Focus();
                return false;
            }
            return true;
        }

        public bool ElegirAlmacenSalidaAntesDeLlenarGrilla()
        {            
            if (this.txtCodAlm.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un almacen salida", "Almacen");
                this.txtCodAlm.Focus();
                return false;
            }
            return true;
        }

        public bool ElegirTipoOperacionIngresoAntesDeLlenarGrilla()
        {
            if (this.txtCodTipOpe1.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un tipo de operacion ingreso", "Tipo operacion");
                this.txtCodTipOpe1.Focus();
                return false;
            }
            return true;
        }

        public bool ElegirAlmacenIngresoAntesDeLlenarGrilla()
        {
            if (this.txtCodAlm1.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un almacen ingreso", "Almacen");
                this.txtCodAlm1.Focus();
                return false;
            }
            return true;
        }

        public bool ValidaFechaMovimientoCabe()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeSalidaDeVentana();

            //validar
            iMovCabEN = MovimientoCabeRN.ValidaCuandoFechaNoEsDelPeriodoElegido(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.wTra.eTitulo);
                this.dtpFecMovCab.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public void CambiarSoloLecturaACodigoAlmacenSalida()
        {
            //valida cuando no es adicionar
            if(this.eOperacion!= Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtCodAlm, iValor);
        }

        public void CambiarSoloLecturaACodigoTipoOperacionSalida()
        {
            //valida cuando no es adicionar
            if (this.eOperacion != Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtCodTipOpe, iValor);
        }

        public void CambiarSoloLecturaACodigoAlmacenIngreso()
        {
            //valida cuando no es adicionar
            if (this.eOperacion != Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtCodAlm1, iValor);
        }

        public void CambiarSoloLecturaACodigoTipoOperacionIngreso()
        {
            //valida cuando no es adicionar
            if (this.eOperacion != Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtCodTipOpe1, iValor);
        }

        public void MostrarFechaIngresoSugerida()
        {
            //asignar parametros
            string iPeriodoRegistro = this.wTra.lblPeriodo.Text;
            string iFechaMovimientoCabeDtp = Fecha.ObtenerDiaMesAno(this.dtpFecMovCab.Value);

            //ejecutar metodo
            this.dtpFecMovCab.Text = MovimientoCabeRN.ObtenerFechaMovimientoCabeSugerido(iPeriodoRegistro, iFechaMovimientoCabeDtp);
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaIngreso()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeIngreso();
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public List<MovimientoDetaEN> ListarMovimientosDetaSalida()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeSalida();
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wTra.eTitulo);
        }
            

        #endregion
                

        private void wEditTransferencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wTra.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
     
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void txtCodAlm_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValidoSalida();
        }

        private void txtCodAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenesSalida(); }
        }

        private void txtCodAlm_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenesSalida();
        }

        private void txtCodPer_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalValidoSalida();
        }

        private void txtCodPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonalesSalida(); }
        }

        private void txtCodPer_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonalesSalida();
        }
              
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AccionAgregarItem();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificarItem();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

        private void dtpFecMovCab_Validated(object sender, EventArgs e)
        {
            this.ValidaFechaMovimientoCabe();
        }

        private void txtCodPer1_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalValidoIngreso();
        }

        private void txtCodPer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonalesIngreso(); }
        }

        private void txtCodPer1_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonalesIngreso();
        }

        private void txtCodAlm1_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValidoIngreso();
        }

        private void txtCodAlm1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenesIngreso(); }
        }

        private void txtCodAlm1_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenesIngreso();
        }
    }
}
