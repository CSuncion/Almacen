﻿using System;
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
    public partial class wEditIngresoDevolucionEncajado : Heredados.MiForm8
    {
        public wEditIngresoDevolucionEncajado()
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

        public wIngresosDevolucionEncajado wIngDevEnc;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumMovCab, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodTipOpe, true, "Tipo Operacion", "ffff", 3);
            xLis.Add(xCtrl);
        
            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesTipOpe, this.txtCodTipOpe, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm, true, "Almacen", "ffff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm, this.txtCodAlm, "ffff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wIngDevEnc.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();                   

            // Deshabilitar al propietario de esta ventana
            this.wIngDevEnc.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto(ProduccionProTerEN pObj)
        {
            this.dtpFecMovCab.Text = pObj.FechaEncajado;
            this.txtCorProDet.Text = pObj.CorrelativoProduccionProTer;
            this.txtCodAlm.Text = "A09";
            this.txtDesAlm.Text = "ALMACEN DE ENVASES Y EMBALAJES";
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
            this.txtCodPer.Text = iAlmEN.CodigoPersonal;
            this.txtNomPer.Text = iAlmEN.NombrePersonal;
        }

        public void MostrarTipoOperacioneIngresoInsumos()
        {
            //traemos los codigos de tipos de operacion para la transferencia
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionIngresoDevolucionProduccion);

            //mostrar los datos
            this.txtCodTipOpe.Text = iTipOpeEN.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = iTipOpeEN.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = iTipOpeEN.CCalculaPrecioPromedio;
        }

        public void VentanaAdicionar(ProduccionProTerEN pObj)
        {
            this.InicializaVentana();
            this.MostrarMovimientoCabe(MovimientoCabeRN.EnBlanco());
            this.ValoresXDefecto(pObj);           
            this.MostrarTipoOperacioneIngresoInsumos();
            this.MostrarDatosPersonalDeAlmacen();            
            this.MostrarMovimientosDeta();      
            eMas.AccionHabilitarControles(0);         
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void VentanaModificar(MovimientoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.ValoresXDefecto(this.wIngDevEnc.wCanAdiEnc.EsProduccionProTerExistente());
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();      
            eMas.AccionHabilitarControles(1);          
            eMas.AccionPasarTextoPrincipal();        
            this.dtpFecMovCab.Focus();
        }

        public void VentanaEliminar(MovimientoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.ValoresXDefecto(this.wIngDevEnc.wCanAdiEnc.EsProduccionProTerExistente());
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
            eMas.AccionHabilitarControles(2);         
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(MovimientoCabeEN pMovCab)
        {
            this.InicializaVentana();
            this.ValoresXDefecto(this.wIngDevEnc.wCanAdiEnc.EsProduccionProTerExistente());
            this.MostrarMovimientoCabe(pMovCab);
            this.LLenarMovimientoDetaDeBaseDatos(pMovCab);
            this.MostrarMovimientosDeta();
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
            pMovCab.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            pMovCab.CodigoPersonal = this.txtCodPer.Text.Trim();           
            pMovCab.GlosaMovimientoCabe = this.txtGloMovCab.Text;
            pMovCab.COrigenVentanaCreacion = "4";//produccion  
            pMovCab.ClaveEncajado = Dgv.ObtenerValorCelda(this.wIngDevEnc.wCanAdiEnc.DgvProProTer, ProduccionProTerEN.ClaEnc);
            pMovCab.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wIngDevEnc.wCanAdiEnc.DgvProProTer, ProduccionDetaEN.ClaObj);
            pMovCab.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }

        public void MostrarMovimientoCabe(MovimientoCabeEN pMovCab)
        {
            this.txtNumMovCab.Text = pMovCab.NumeroMovimientoCabe;
            this.dtpFecMovCab.Text = pMovCab.FechaMovimientoCabe;
            this.txtCodTipOpe.Text = pMovCab.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = pMovCab.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = pMovCab.CCalculaPrecioPromedio;
            this.txtCodAlm.Text = pMovCab.CodigoAlmacen;
            this.txtDesAlm.Text = pMovCab.DescripcionAlmacen;
            this.txtCodPer.Text = pMovCab.CodigoPersonal;
            this.txtNomPer.Text = pMovCab.NombrePersonal;
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;          
        }

        public void MostrarMovimientosDeta()
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
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CanMovDet, "Cant", 60, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.PreUniMovDet, "P/U", 85, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoDetaEN.CosMovDet, "Costo", 90, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarMovimientoDetaDeBaseDatos(MovimientoCabeEN pObj)
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
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

            //valida el periodo para este movimiento
            if (this.ValidaFechaMovimientoCabeAlAdicionar() == false) { return; }

            //valida el almacen
            //if (this.EsAlmacenValido() == false) { return; }

            //volver a preguntar si es acto adicionar
            //if(this.wSalAdi.EsActoAdicionarMovimientoCabe().Adicionales.EsVerdad== false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wIngDevEnc.eTitulo) == false) { return; }

            //mostrar numero movimientoCabe
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarMovimientoCabe();
            
            //adicionando detalles
            this.AdicionarMovimientosDeta();

            //actualizar las existencias referenciadas
            this.ActualizarExistenciasPorAdicion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la ingreso correctamente", this.wIngDevEnc.eTitulo);

            //actualizar al propietario           
            this.wIngDevEnc.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
            this.wIngDevEnc.ActualizarVentana();

            //imprimir la nota
            this.wIngDevEnc.AccionImprimirNota();

            //limpiar controles
            this.MostrarMovimientoCabeSegundaEdicion(MovimientoCabeRN.EnBlanco());            
            this.eLisMovDet.Clear();
            this.MostrarMovimientosDeta();
            //this.CambiarSoloLecturaACodigoAlmacen();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void MostrarMovimientoCabeSegundaEdicion(MovimientoCabeEN pMovCab)
        {
            this.txtNumMovCab.Text = pMovCab.NumeroMovimientoCabe;                 
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;
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
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
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
                xMovDet.ClaveEncajado = Dgv.ObtenerValorCelda(this.wIngDevEnc.wCanAdiEnc.DgvProProTer, ProduccionProTerEN.ClaEnc);
                xMovDet.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wIngDevEnc.wCanAdiEnc.DgvProProTer, ProduccionProTerEN.ClaObj);
                xMovDet.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(xMovDet);
            }

            //adicion masiva
            MovimientoDetaRN.AdicionarMovimientoDeta(this.eLisMovDet);
        }

        public void ActualizarExistenciasPorAdicion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.eLisMovDet;

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //valida el periodo para este movimiento
            if (this.ValidaFechaMovimientoCabeAlModificar() == false) { return; }

            //valida el almacen
            //if (this.EsAlmacenValido() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            //if (this.wSalAdi.EsMovimientoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wIngDevEnc.eTitulo) == false) { return; }

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
            
            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la salida correctamente", this.wIngDevEnc.eTitulo);

            //actualizar al wLot          
            this.wIngDevEnc.eClaveDgvMovCab = this.ObtenerClaveMovimientoCabe();
            this.wIngDevEnc.ActualizarVentana();

            //imprimir la nota
            this.wIngDevEnc.AccionImprimirNota();

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

        public void EliminarAntiguosMovimientosDeta()
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public void ActualizarExistenciasPorEliminacion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDeta();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorEliminacionMovimientosDeta(iLisMovDet);
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

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wIngDevEnc.EsMovimientoCabeExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wIngDevEnc.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarMovimientoCabe();

            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar antiguo detalle
            this.EliminarAntiguosMovimientosDeta();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el ingreso correctamente", this.wIngDevEnc.eTitulo);

            //actualizar al wLot           
            this.wIngDevEnc.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarMovimientoCabe()
        {
            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            MovimientoCabeRN.EliminarMovimientoCabe(iCuoEN);
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
            win.eCtrlFoco = this.txtCodPer;
            //win.eProDetEN = this.wIngDevEnc.wCanAdiEnc.EsProduccionProTerExistente();
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivosParaProduccion;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            ProduccionProTerEN iProDetEN = this.wIngDevEnc.wCanAdiEnc.EsProduccionProTerExistente();
            //iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN, iProDetEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, "Almacen");
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
            win.eCondicionLista = Listas.wLisPer.Condicion.PersonalesActivos;
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
            iPerEN = PersonalRN.EsPersonalActivoValido(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wIngDevEnc.eTitulo);
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

        public void AccionAgregarItem()
        {
            //valida cuando no hay almacen
            if (this.ElegirAlmacenAntesDeLlenarGrilla() == false) { return; }

            //valida el almacen
            if (this.EsAlmacenValido() == false) { return; }

            //instanciar
            wDetalleIngresoDevolucionEncajado win = new wDetalleIngresoDevolucionEncajado();
            win.wEditIngDev = this;
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

            //valida el almacen
            if (this.EsAlmacenValido() == false) { return; }

            wDetalleIngresoDevolucionEncajado win = new wDetalleIngresoDevolucionEncajado();
            win.wEditIngDev = this;
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

            wDetalleIngresoDevolucionEncajado win = new wDetalleIngresoDevolucionEncajado();
            win.wEditIngDev = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovDet = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja(this.dgvMovDet)]);
        }

        public bool ValidaFechaMovimientoCabeAlAdicionar()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //validar
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.wIngDevEnc.eTitulo);
                this.dtpFecMovCab.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public bool ValidaFechaMovimientoCabeAlModificar()
        {
            //validar solo cuando adiciona y modifica
            if (MiForm.VerdaderoCuandoAdicionaYModifica((int)this.eOperacion) == false) { return true; }

            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.wIngDevEnc.EsMovimientoCabeExistente();
            iMovCabEN.FechaMovimientoCabe = this.dtpFecMovCab.Text;

            //validar
            iMovCabEN = MovimientoCabeRN.ValidaCuandoFechaNoEsDelPeriodoElegido(iMovCabEN);
            if (iMovCabEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iMovCabEN.Adicionales.Mensaje, this.wIngDevEnc.eTitulo);
                this.dtpFecMovCab.Focus();
            }

            //devolver
            return iMovCabEN.Adicionales.EsVerdad;
        }

        public void CambiarSoloLecturaACodigoAlmacen()
        {
            //valida cuando no es adicionar
            if (this.eOperacion != Universal.Opera.Adicionar) { return; }

            //obtener valor de verdad
            bool iValor = Cadena.CompararDosValores(this.eLisMovDet.Count, 0, false, true);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtCodAlm, iValor);
        }

        public bool ElegirAlmacenAntesDeLlenarGrilla()
        {
            if (this.txtCodAlm.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes elegir primero un almacen", "Almacen");
                this.txtCodAlm.Focus();
                return false;
            }
            return true;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wIngDevEnc.eTitulo);
        }
            

        #endregion
                

        private void wEditIngresoDevolucion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wIngDevEnc.Enabled = true;
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
            //this.ValidaFechaMovimientoCabe();
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
    }
}
