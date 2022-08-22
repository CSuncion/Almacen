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
using Entidades.Estructuras;

namespace Presentacion.Procesos
{
    public partial class wTransferenciaDesechasAnaBloq : Heredados.MiForm8
    {
        public wTransferenciaDesechasAnaBloq()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<MovimientoDetaEN> eLisMovDet = new List<MovimientoDetaEN>();
        public string eTitulo = "Salida Unidades Desechas";
               
        #endregion

        #region Propietario

        //public wAnalisisBloqueados wAnaBlo;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCorProDet, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumMovCab, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodTipOpe, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipOpe, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodAlm, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer, true, "Personal", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer, this.txtCodPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumMovCab1, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodTipOpe1, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipOpe1, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodAlm1, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm1, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodPer1, true, "Personal", "vvff", 6);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNomPer1, this.txtCodPer, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtGloMovCab, false, "Glosa", "vvff", 100);
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


        public void InicializaVentana(LiberacionEN pObj)
        {           
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();                   

            //valores x defecto
            this.ValoresXDefecto(pObj);

            // Deshabilitar al propietario de esta ventana
            //this.wAnaBlo.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto(LiberacionEN pObj)
        {
            this.txtCorProDet.Text = pObj.CodigoLiberacion;
            this.txtCodAlm.Text = LiberacionRN.ObtenerCodigoAlmacenSalidaSegunAlmacenLiberacion(pObj);
        }

        public void MostrarDatosPersonalDeAlmacenSalida()
        {
            //asignar parametro
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);

            //ejecutar metodo
            iAlmEN = AlmacenRN.BuscarAlmacenXClave(iAlmEN);

            //mostrar datos personal en ventana
            this.txtCodPer.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer.Text = iAlmEN.NombrePersonal;
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
        }

        public void MostrarDatosPersonalDeAlmacenIngreso()
        {
            //asignar parametro
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = "A14";//almacen de desechos
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);

            //ejecutar metodo
            iAlmEN = AlmacenRN.BuscarAlmacenXClave(iAlmEN);

            //mostrar datos personal en ventana
            this.txtCodPer1.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer1.Text = iAlmEN.NombrePersonal;
            this.txtCodAlm1.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm1.Text = iAlmEN.DescripcionAlmacen;
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

        public MovimientoCabeEN ObtenerMovimientoCabeSalidaBD(LiberacionEN pObj)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pObj.ClaveSalidaTransferenciaDesechas;

            //ejecutar metodo
            return MovimientoCabeRN.BuscarMovimientoCabeXClave(iMovCabEN);
        }

        public MovimientoCabeEN ObtenerMovimientoCabeIngresoBD(LiberacionEN pObj)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pObj.ClaveIngresoTransferenciaDesechas;

            //ejecutar metodo
            return MovimientoCabeRN.BuscarMovimientoCabeXClave(iMovCabEN);
        }

        public void NuevaVentana(LiberacionEN pObj)
        {
            //actualizar a eOperacion al ingresar a la ventana
            this.ActualizareOperacion(pObj);

            //segun eOperacion
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.VentanaAdicionar(pObj); break; }
                case Universal.Opera.Modificar: { this.VentanaModificar(pObj); break; }
                case Universal.Opera.Visualizar: { this.VentanaVisualizar(pObj); break; }
                default: break;
            }
        }
        
        public void ActualizareOperacion(LiberacionEN pObj)
        {
            if (pObj.ClaveSalidaTransferenciaDesechas == string.Empty)
            {
                this.eOperacion = Universal.Opera.Adicionar;
            }
            else
            {
                this.eOperacion = Universal.Opera.Modificar;
            }
        }

        public void VentanaAdicionar(LiberacionEN pObj)
        {
            this.InicializaVentana(pObj);
            this.dtpFecMovCab.Text = pObj.FechaLiberacion;
            this.MostrarTiposOperacionesTransferencia();            
            this.MostrarDatosPersonalDeAlmacenSalida();
            this.MostrarDatosPersonalDeAlmacenIngreso();
            this.LLenarMovimientoDetaAlAdicionar(pObj);
            this.MostrarMovimientoDeta();      
            eMas.AccionHabilitarControles(0);         
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void VentanaModificar(LiberacionEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarMovimientoCabeSalida(this.ObtenerMovimientoCabeSalidaBD(pObj));
            this.MostrarMovimientoCabeIngreso(this.ObtenerMovimientoCabeIngresoBD(pObj));
            this.LLenarMovimientoDetaAlAdicionar(pObj);
            this.MostrarMovimientoDeta();      
            eMas.AccionHabilitarControles(1);          
            eMas.AccionPasarTextoPrincipal();        
            this.dtpFecMovCab.Focus();
        }

        public void VentanaVisualizar(LiberacionEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarMovimientoCabeSalida(this.ObtenerMovimientoCabeSalidaBD(pObj));
            this.MostrarMovimientoCabeIngreso(this.ObtenerMovimientoCabeIngresoBD(pObj));
            this.LLenarMovimientoDetaDeBaseDatos(pObj);
            this.MostrarMovimientoDeta();
            eMas.AccionHabilitarControles(3);           
            this.btnCancelar.Focus();
        }

        public void AsignarMovimientoCabeSalida(MovimientoCabeEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCab.FechaMovimientoCabe = dtpFecMovCab.Text;
            pMovCab.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(pMovCab.FechaMovimientoCabe, "-");
            pMovCab.NumeroMovimientoCabe = this.txtNumMovCab.Text.Trim();           
            pMovCab.CodigoTipoOperacion = this.txtCodTipOpe.Text.Trim();
            pMovCab.CCalculaPrecioPromedio = this.txtCCalPrePro.Text.Trim();
            pMovCab.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pMovCab.CodigoPersonal = this.txtCodPer.Text.Trim();
            pMovCab.GlosaMovimientoCabe = this.txtGloMovCab.Text;
            pMovCab.COrigenVentanaCreacion = "3";//transferencia 
            pMovCab.ClaveIngresoMovimientoCabe = this.ObtenerClaveMovimientoCabeIngreso();
            pMovCab.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }

        public void AsignarMovimientoCabeIngreso(MovimientoCabeEN pMovCabIng)
        {
            pMovCabIng.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCabIng.FechaMovimientoCabe = dtpFecMovCab.Text;
            pMovCabIng.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(pMovCabIng.FechaMovimientoCabe, "-");
            pMovCabIng.NumeroMovimientoCabe = this.txtNumMovCab1.Text.Trim();           
            pMovCabIng.CodigoTipoOperacion = this.txtCodTipOpe1.Text.Trim();
            pMovCabIng.CodigoAlmacen = this.txtCodAlm1.Text.Trim();
            pMovCabIng.CodigoPersonal = this.txtCodPer1.Text.Trim();
            pMovCabIng.GlosaMovimientoCabe = this.txtGloMovCab.Text;
            pMovCabIng.COrigenVentanaCreacion = "3";//transferencia
            pMovCabIng.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(pMovCabIng);
        }

        public void MostrarMovimientoCabeSalida(MovimientoCabeEN pMovCab)
        {
            this.txtNumMovCab.Text = pMovCab.NumeroMovimientoCabe;
            this.dtpFecMovCab.Text = pMovCab.FechaMovimientoCabe;
            this.txtCodTipOpe.Text = pMovCab.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = pMovCab.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = pMovCab.CCalculaPrecioPromedio;      
            this.txtCodPer.Text = pMovCab.CodigoPersonal;
            this.txtNomPer.Text = pMovCab.NombrePersonal;
            this.txtDesAlm.Text = pMovCab.DescripcionAlmacen;      
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;          
        }

        public void MostrarMovimientoCabeIngreso(MovimientoCabeEN pMovCabIng)
        {           
            this.txtCodTipOpe1.Text = pMovCabIng.CodigoTipoOperacion;
            this.txtDesTipOpe1.Text = pMovCabIng.DescripcionTipoOperacion;
            this.txtCCalPrePro1.Text = pMovCabIng.CCalculaPrecioPromedio;
            this.txtNumMovCab1.Text = pMovCabIng.NumeroMovimientoCabe;
            this.txtCodAlm1.Text = pMovCabIng.CodigoAlmacen;
            this.txtDesAlm1.Text = pMovCabIng.DescripcionAlmacen;
            this.txtCodPer1.Text = pMovCabIng.CodigoPersonal;
            this.txtNomPer1.Text = pMovCabIng.NombrePersonal;
        }

        public void MostrarMovimientoDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvProExi;
            List<MovimientoDetaEN> iFuenteDatos = MovimientoDetaRN.RefrescarListaMovimientoDeta(this.eLisMovDet); ;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
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
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CanMovDet, "Cant", 60, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.PreUniMovDet, "P/U", 85, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CosMovDet, "Costo", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarMovimientoDetaDeBaseDatos(LiberacionEN pObj)
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pObj.ClaveSalidaTransferenciaDesechas;
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;
            this.eLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void LLenarMovimientoDetaAlAdicionar(LiberacionEN pObj)
        {
            //asignar parametros
            LiberacionEN iLibEN = pObj;
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeSalidaDeVentana();

            //ejecutar metodo
            this.eLisMovDet = MovimientoDetaRN.ListarMovimientoDetaParaSalidaTransferenciaUnidadesDesechas(iLibEN, iMovCabEN);
        }

        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }              
                default: break;
            }
        }

        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //valida el periodo para este movimiento
            if (this.ValidaFechaMovimientoCabe() == false) { return; }

            //valida si tiene permiso a este almacen
            if (this.EsAlmacenValido() == false) { return; }

            //validar si las existencias no cumplen con el stock requerido
            if (this.HayStockExistenciasParaParteTrabajo() == false) { return; }

            //valida la existencia
            if (this.EsCodigoExistenciaValido() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

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

            //actualizar las existencias referenciadas
            this.ActualizarExistenciasSalidaPorAdicion();

            //adicionando detalle ingreso
            this.AdicionarMovimientosDetaIngreso();

            //actualizar las existencias ingreso referenciadas
            this.ActualizarExistenciasIngresoPorAdicion();

            //modificar el parte trabajo
            this.ModificarLiberacion();
            
            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la transferencia de unidades para desechos correctamente", this.eTitulo);

            //actualizar al propietario           
            //this.wAnaBlo.eClaveDgvLib = Dgv.ObtenerValorCelda(this.wAnaBlo.DgvLib, ProduccionDetaEN.ClaObj);
            //this.wAnaBlo.ActualizarVentana();

            //imprimir la nota
            //this.wParTra.AccionImprimirSalidasReproceso();

            //cerrar
            this.Close();
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
                iMovDetEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iMovDetEN.FechaMovimientoCabe, "-");
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
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDetaSalida();

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

        public void ModificarLiberacion()
        {            
            //asignar parametros
            LiberacionEN iLibEN = new LiberacionEN();
            //iLibEN.ClaveLiberacion = Dgv.ObtenerValorCelda(this.wAnaBlo.DgvLib, LiberacionEN.ClaObj);
            iLibEN.ClaveIngresoTransferenciaDesechas = this.ObtenerClaveMovimientoCabeIngreso();
            iLibEN.ClaveSalidaTransferenciaDesechas = this.ObtenerClaveMovimientoCabeSalida();

            //ejecutar metodo
            LiberacionRN.ModificarPorTransferenciaDesechas(iLibEN);
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

        public List<MovimientoDetaEN> ListarMovimientosDetaIngreso()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabeIngreso();
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //valida el periodo para este movimiento
            if (this.ValidaFechaMovimientoCabe() == false) { return; }

            //valida si tiene permiso a este almacen
            if (this.EsAlmacenValido() == false) { return; }

            //valida la existencia
            if (this.EsCodigoExistenciaValido() == false) { return; }

            //desea realizar la operacion?
            //if (Mensaje.DeseasRealizarOperacion(this.wAnaBlo.eTitulo) == false) { return; }

            //modificar el registro salida
            this.ModificarMovimientoCabeSalida();

            //modificar el registro ingreso
            this.ModificarMovimientoCabeIngreso();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasSalidaPorEliminacion();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDetaSalida();

            //actualizar las existencias ingreso por eliminacion
            this.ActualizarExistenciasIngresoPorEliminacion();

            //eliminar antiguo detalle ingreso
            this.EliminarAntiguosMovimientosDetaIngreso();

            //adicionando detalles salida
            this.AdicionarMovimientosDetaSalida();

            //actualizar existencias por adicion
            this.ActualizarExistenciasSalidaPorAdicion();

            //adicionando detalle ingreso
            this.AdicionarMovimientosDetaIngreso();

            //actualizar las existencias ingreso referenciadas
            this.ActualizarExistenciasIngresoPorAdicion();

            //modificar el parte trabajo
            this.ModificarLiberacion();
            
            //mensaje satisfactorio
            //Mensaje.OperacionSatisfactoria("Se modifico la transferencia de unidades para desechos correctamente", this.wAnaBlo.eTitulo);

            ////actualizar al wLot          
            //this.wAnaBlo.eClaveDgvLib = Dgv.ObtenerValorCelda(this.wAnaBlo.DgvLib, ProduccionDetaEN.ClaObj);
            //this.wAnaBlo.ActualizarVentana();

            //imprimir la nota
            //this.wParTra.AccionImprimirSalidasReproceso();

            //salir de la ventana
            this.Close();
        }

        public bool HayStockExistenciasParaParteTrabajo()
        {
            //ok
            return true;
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

        public void ListarPersonales()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer.ReadOnly == true) { return; }

            //instanciar
            wLisPer win = new wLisPer();
            win.eVentana = this;
            win.eTituloVentana = "Personales";
            win.eCtrlValor = this.txtCodPer;
            win.eCtrlFoco = this.txtCodPer1;
            win.eCondicionLista = Listas.wLisPer.Condicion.Personales;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodPer.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            Entidades.PersonalEN iPerEN = new Entidades.PersonalEN();
            iPerEN.CodigoPersonal = this.txtCodPer.Text.Trim();            
            iPerEN = PersonalRN.EsPersonalValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                //Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wAnaBlo.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPer.Text = iPerEN.CodigoPersonal;
            this.txtNomPer.Text = iPerEN.NombrePersonal;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public void ListarPersonales1()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodPer1.ReadOnly == true) { return; }

            //instanciar
            wLisPer win = new wLisPer();
            win.eVentana = this;
            win.eTituloVentana = "Personales";
            win.eCtrlValor = this.txtCodPer1;
            win.eCtrlFoco = this.txtGloMovCab;
            win.eCondicionLista = Listas.wLisPer.Condicion.Personales;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsPersonalValido1()
        {
            //si es de lectura , entonces no lista
            if (txtCodPer1.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            Entidades.PersonalEN iPerEN = new Entidades.PersonalEN();
            iPerEN.CodigoPersonal = this.txtCodPer1.Text.Trim();
            iPerEN = PersonalRN.EsPersonalValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                //Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wAnaBlo.eTitulo);
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

        public bool ValidaFechaMovimientoCabe()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeSalidaDeVentana();

            //validar
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.eTitulo);
                this.dtpFecMovCab.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public bool EsAlmacenValido()
        {
            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, "Almacen");
            }

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
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

        public ExistenciaEN NuevaExistenciaSalidaVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iExiEN.DescripcionAlmacen = this.txtDesAlm.Text.Trim();
            iExiEN.CodigoExistencia = ListaG.ObtenerUltimoValor<MovimientoDetaEN>(this.eLisMovDet, MovimientoDetaEN.CodExi);
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public ExistenciaEN NuevaExistenciaIngresoVentana()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.txtCodAlm1.Text.Trim();
            iExiEN.DescripcionAlmacen = this.txtDesAlm1.Text.Trim();
            iExiEN.CodigoExistencia = ListaG.ObtenerUltimoValor<MovimientoDetaEN>(this.eLisMovDet, MovimientoDetaEN.CodExi);
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public bool EsCodigoExistenciaValido()
        {
            //validar 
            //asignar parametros       
            ExistenciaEN iExiSalEN = this.NuevaExistenciaSalidaVentana();
            ExistenciaEN iExiIngEN = this.NuevaExistenciaIngresoVentana();
            string iCodigoExistenciaFranjaGrilla = string.Empty;
            List<MovimientoDetaEN> iLisMovDetGrilla = new List<MovimientoDetaEN>();
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iExiSalEN = ExistenciaRN.EsExistenciaActivoValido(iExiSalEN, iExiIngEN, iOperacionVentana, iCodigoExistenciaFranjaGrilla, iLisMovDetGrilla);
            if (iExiSalEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiSalEN.Adicionales.Mensaje, "Existencia");
            }

            //devolver
            return iExiSalEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            //Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wAnaBlo.eTitulo);
        }
            

        #endregion
                

        private void wTransferenciaDesechasAnaBloq_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wAnaBlo.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
     
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }
     
        private void txtCodPer_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalValido();
        }

        private void txtCodPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonales(); }
        }

        private void txtCodPer_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonales();
        }

        private void txtCodPer1_Validating(object sender, CancelEventArgs e)
        {
            this.EsPersonalValido1();
        }

        private void txtCodPer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarPersonales1(); }
        }

        private void txtCodPer1_DoubleClick(object sender, EventArgs e)
        {
            this.ListarPersonales1();
        }
    }
}
