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
    public partial class wSalidaEtiquetaSegundaLiberacion : Heredados.MiForm8
    {
        public wSalidaEtiquetaSegundaLiberacion()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<ProduccionExisEN> eLisProExi = new List<ProduccionExisEN>();
        public string eClaveDgvRetProTer = string.Empty;
        Dgv.Franja eFranjaDgvRetProTer = Dgv.Franja.PorIndice;
        public string eTitulo = "Salida Etiquetas";
               
        #endregion

        #region Propietario

        public wSegundaLiberacion wSegLib;

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
            xCtrl.TxtTodo(this.txtGloMovCab, false, "Glosa", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnModificar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnEliminar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnVisualizar, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnRegenerar, "vvvf");
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


        public void InicializaVentana(ProduccionProTerEN pObj)
        {           
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();                   

            //valores x defecto
            this.ValoresXDefecto(pObj);

            // Deshabilitar al propietario de esta ventana
            this.wSegLib.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto(ProduccionProTerEN pObj)
        {
            this.txtCorProDet.Text = pObj.CorrelativoEncajado;
            this.txtCodAlm.Text ="A09";//almacen envases y embalaje              
        }

        public void MostrarDatosPersonalDeAlmacen()
        {
            //asignar parametro
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);

            //ejecutar metodo
            iAlmEN = AlmacenRN.BuscarAlmacenXClave(iAlmEN);

            //mostrar datos personal en ventana
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
            this.txtCodPer.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer.Text = iAlmEN.NombrePersonal;
        }

        public void MostrarTipoOperacioneSalidaInsumos()
        {
            //traemos los codigos de tipos de operacion para la transferencia
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionProduccionSalida);

            //mostrar los datos
            this.txtCodTipOpe.Text = iTipOpeEN.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = iTipOpeEN.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = iTipOpeEN.CCalculaPrecioPromedio;            
        }

        public MovimientoCabeEN ObtenerMovimientoCabeSalidaBD(ProduccionProTerEN pObj)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pObj.ClaveSalidaEtiquetaSegundaLiberacion;

            //ejecutar metodo
            return MovimientoCabeRN.BuscarMovimientoCabeXClave(iMovCabEN);
        }

        public void NuevaVentana(ProduccionProTerEN pObj)
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

        public void ActualizareOperacion(ProduccionProTerEN pObj)
        {
            if (pObj.ClaveSalidaEtiquetaSegundaLiberacion == string.Empty)
            {
                this.eOperacion = Universal.Opera.Adicionar;
            }
            else
            {
                if (pObj.ClaveIngresoProductoTerminado == string.Empty)
                {
                    this.eOperacion = Universal.Opera.Modificar;
                }
                else
                {                    
                    this.eOperacion = Universal.Opera.Visualizar;
                }
            }
        }

        public void VentanaAdicionar(ProduccionProTerEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarMovimientoCabe(MovimientoCabeRN.EnBlanco());
            this.dtpFecMovCab.Text = pObj.FechaEncajado;
            this.MostrarTipoOperacioneSalidaInsumos();
            this.MostrarDatosPersonalDeAlmacen();
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExis();      
            eMas.AccionHabilitarControles(0);         
            eMas.AccionPasarTextoPrincipal();            
            this.dtpFecMovCab.Focus();
        }

        public void VentanaModificar(ProduccionProTerEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarDatosPersonalDeAlmacen();
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeSalidaBD(pObj));
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExis();      
            eMas.AccionHabilitarControles(1);          
            eMas.AccionPasarTextoPrincipal();        
            this.dtpFecMovCab.Focus();
        }

        public void VentanaVisualizar(ProduccionProTerEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarDatosPersonalDeAlmacen();
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeSalidaBD(pObj));
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExis();
            eMas.AccionHabilitarControles(3);           
            this.btnCancelar.Focus();
        }

        public void AsignarMovimientoCabe(MovimientoCabeEN pMovCab)
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
            pMovCab.COrigenVentanaCreacion = "4";//produccion   
            pMovCab.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }

        public void MostrarMovimientoCabe(MovimientoCabeEN pMovCab)
        {
            this.txtNumMovCab.Text = pMovCab.NumeroMovimientoCabe;
            this.dtpFecMovCab.Text = pMovCab.FechaMovimientoCabe;
            this.txtCodTipOpe.Text = pMovCab.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = pMovCab.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = pMovCab.CCalculaPrecioPromedio;      
            this.txtCodPer.Text = pMovCab.CodigoPersonal;
            this.txtNomPer.Text = pMovCab.NombrePersonal;          
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;          
        }

        public void MostrarProduccionExis()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvProExi;
            List<ProduccionExisEN> iFuenteDatos = ListaG.Filtrar<ProduccionExisEN>(this.eLisProExi, ProduccionExisEN.CEstSegLib, "1");
            Dgv.Franja iCondicionFranja = eFranjaDgvRetProTer;
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
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.ClaProExi, "Clave", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.DesExi, "Descripcion", 240));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.NomUniMed, "Uni.Med", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionExisEN.CanSegLib, "Cant", 100, 5));
            //iLisRes.Add(Dgv.NuevaColumnaTextNumericoEditable(ProduccionExisEN.CanGr, "Cant.Gr", 100, 5));
            //iLisRes.Add(Dgv.NuevaColumnaTextNumericoEditable(ProduccionExisEN.CanKg, "Cant.Kg", 100, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarProduccionExisDeBaseDatos()
        {
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);           
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            this.eLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionProTerYSegundaLiberacion(iProExiEN);           
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

            //valida cantidades desmedro ceros
            if (this.ValidaCuandoItemsTienenCantidadEtiquetaCero() == false) { return; }

            //valida existencias que no hay en el almacen de desmedro
            //if (this.ValidaCuandoHayExistenciasQueNoEstanRegistradasEnAlmacenDesmedro() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //mostrar numero movimientoCabe
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarMovimientoCabe();
            
            //adicionando detalles
            this.AdicionarMovimientosDeta();

            //actualizar las existencias referenciadas
            this.ActualizarExistenciasPorAdicion();

            //adicionar lotesDeta
            this.AdicionarLotesDeta();

            //modificar el parte trabajo
            this.ModificarProduccionProTer();

            //modificar produccionesExis
            this.ModificarProducionExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la salida correctamente", this.eTitulo);

            //actualizar al propietario           
            this.wSegLib.eClaveDgvProProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);
            this.wSegLib.ActualizarVentana();

            //imprimir la nota
            //this.wParTra.AccionImprimirSalidasFaseMasa();

            //cerrar
            this.Close();
        }

        public void MostrarNuevoNumero()
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //obtener el nuevo numero
            string iNuevoNumero = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);

            //mostrar en pantalla
            this.txtNumMovCab.Text = iNuevoNumero;
        }

        public void AdicionarMovimientoCabe()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            MovimientoCabeRN.AdicionarMovimientoCabe(iCuoEN);
        }

        public void AdicionarMovimientosDeta()
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = ListaG.Filtrar<ProduccionExisEN>(this.eLisProExi, ProduccionExisEN.CEstSegLib, "1");
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //ejecutar metodo
            MovimientoDetaRN.AdicionarMovimientoDetaPorSalidaEtiquetaSegundaLiberacion(iLisProExi, iMovCabEN);
        }

        public void ActualizarExistenciasPorAdicion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDeta();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);
        }

        public void ModificarProduccionProTer()
        {
            //asignar parametros
            ProduccionProTerEN iProDetEN = new ProduccionProTerEN();
            iProDetEN.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);            
            iProDetEN.ClaveSalidaEtiquetaSegundaLiberacion = this.ObtenerClaveMovimientoCabe();

            //ejecutar metodo
            ProduccionProTerRN.ModificarPorSalidaEtiquetaSegundaLiberacion(iProDetEN);
        }

        public void ModificarProducionExis()
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = this.eLisProExi;

            //ejecutar metodo
            ProduccionExisRN.ModificarProduccionExis(iLisProExi);
        }

        public void AdicionarLotesDeta()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDeta();

            //ejecutar metodo
            LoteDetaRN.AdicionarLoteDeta(iLisMovDet);
        }

        public List<MovimientoDetaEN> ListarMovimientosDeta()
        {
            //asignar parametros
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
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

            //valida cantidades desmedro ceros
            if (this.ValidaCuandoItemsTienenCantidadEtiquetaCero() == false) { return; }

            //valida existencias que no hay en el almacen de desmedro
            //if (this.ValidaCuandoHayExistenciasQueNoEstanRegistradasEnAlmacenDesmedro() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wSegLib.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarMovimientoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //adicionando nuevos MovimientoDeta
            this.AdicionarMovimientosDeta();

            //actualizar existencias por adicion
            this.ActualizarExistenciasPorAdicion();

            //eliminar los lotesDeta anterior
            this.EliminarLotesDeta();

            //adicionar los lotes deta
            this.AdicionarLotesDeta();

            //modificar el parte trabajo
            this.ModificarProduccionProTer();

            //modificar produccionesExis
            this.ModificarProducionExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la salida correctamente", this.wSegLib.eTitulo);

            //actualizar al wLot          
            this.wSegLib.eClaveDgvProProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);
            this.wSegLib.ActualizarVentana();

            //imprimir la nota
            //this.wParTra.AccionImprimirSalidasFaseMasa();

            //salir de la ventana
            this.Close();
        }

        public void ModificarMovimientoCabe()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            iCuoEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(iCuoEN);
            this.AsignarMovimientoCabe(iCuoEN);
            MovimientoCabeRN.ModificarMovimientoCabe(iCuoEN);
        }

        public void ActualizarExistenciasPorEliminacion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDeta();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDeta(iLisMovDet);
        }

        public void EliminarAntiguosMovimientosDeta()
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public void EliminarLotesDeta()
        {
            //asignar parametros
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();

            //ejecutar metodo
            LoteDetaRN.EliminarLoteDeta(iClaveMovimientoCabe);
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
            win.eCtrlFoco = this.txtGloMovCab;
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
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wSegLib.eTitulo);
                this.txtCodPer.Focus();
            }

            //mostrar datos
            this.txtCodPer.Text = iPerEN.CodigoPersonal;
            this.txtNomPer.Text = iPerEN.NombrePersonal;

            //devolver
            return iPerEN.Adicionales.EsVerdad;
        }

        public MovimientoCabeEN NuevoMovimientoCabeDeVentana()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN;
        }

        public string ObtenerClaveMovimientoCabe()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }
             
        public bool ValidaFechaMovimientoCabe()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

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

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.dgvProExi.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleSalidaEtiquetaSegLib win = new wDetalleSalidaEtiquetaSegLib();
            win.wSalEtiSegLib = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvRetProTer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(ListaG.Buscar<ProduccionExisEN>(this.eLisProExi, ProduccionExisEN.ClaObj,
                Dgv.ObtenerValorCelda(this.dgvProExi, ProduccionExisEN.ClaObj)));
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.dgvProExi.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleSalidaEtiquetaSegLib win = new wDetalleSalidaEtiquetaSegLib();
            win.wSalEtiSegLib = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvRetProTer = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(ListaG.Buscar<ProduccionExisEN>(this.eLisProExi, ProduccionExisEN.ClaObj,
                Dgv.ObtenerValorCelda(this.dgvProExi, ProduccionExisEN.ClaObj)));
        }

        public void AccionVisualizarItem()
        {
            //ver si hay registro
            if (this.dgvProExi.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro para visualizar", "Detalle");
                return;
            }

            wDetalleSalidaEtiquetaSegLib win = new wDetalleSalidaEtiquetaSegLib();
            win.wSalEtiSegLib = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(ListaG.Buscar<ProduccionExisEN>(this.eLisProExi, ProduccionExisEN.ClaObj,
                Dgv.ObtenerValorCelda(this.dgvProExi, ProduccionExisEN.ClaObj)));
        }

        public void AccionRegenerarItems()
        {
            //filtrar solo los que tienen estado desmedro desactivado
            List<ProduccionExisEN> iLisProExi = ListaG.Filtrar<ProduccionExisEN>(this.eLisProExi, ProduccionExisEN.CEstSegLib, "0");

            //validar si hay para regenerar
            if (iLisProExi.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay items para regenerar", "Items");
                return;
            }

            //regenerar
            ProduccionExisRN.ModificarPorRegenerarSegundaLiberacion(this.eLisProExi);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se regeneraron el(los) items", "Items");

            //actualizar grilla
            this.MostrarProduccionExis();
        }

        public bool ValidaCuandoItemsTienenCantidadEtiquetaCero()
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = ListaG.Filtrar<ProduccionExisEN>(this.eLisProExi, ProduccionExisEN.CEstSegLib, "1");//solo activos

            //ejecutar metodo
            ProduccionExisEN iProExiEN = ProduccionExisRN.ValidaCuandoItemsTienenCantidadEtiquetaCero(iLisProExi);

            //mensaje error
            Generico.MostrarMensajeError(iProExiEN.Adicionales);

            //devolver
            return iProExiEN.Adicionales.EsVerdad;
        }

        public bool ValidaCuandoHayExistenciasQueNoEstanRegistradasEnAlmacenDesmedro()
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = ListaG.Filtrar<ProduccionExisEN>(this.eLisProExi, ProduccionExisEN.CEstDes, "1");//solo activos

            //ejecutar metodo
            ExistenciaEN iExiEN = ExistenciaRN.HayExistenciasQueNoHayEnAlmacen(iLisProExi, "A21");

            //mensaje de error
            Generico.MostrarMensajeError(iExiEN.Adicionales);

            //devolver
            return iExiEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wSegLib.eTitulo);
        }
            

        #endregion
                

        private void wSalidaEtiquetaSegundaLiberacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wSegLib.Enabled = true;
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

        private void dgvProExi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //this.dgvProExi.BeginEdit(true);
        }

        private void dgvProExi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvProExi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //this.ModificarProduccionExisDigitado(e.ColumnIndex);
            //this.LLenarProduccionExisDeBaseDatos();
            //this.MostrarProduccionExis();
            //Dgv.EditarEnCeldaDeFilaSeleccionada(this.dgvProExi, e.ColumnIndex);
        }

        private void dgvProExi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //this.ValidarFormatoDecimal(e, ProduccionExisEN.CanProExi, "Cantidad");
            //this.ValidarFormatoDecimal(e, ProduccionExisEN.CanGr, "Cantidad Gr");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificarItem();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.AccionQuitarItem();
        }

        private void btnRegenerar_Click(object sender, EventArgs e)
        {
            this.AccionRegenerarItems();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizarItem();
        }
    }
}
