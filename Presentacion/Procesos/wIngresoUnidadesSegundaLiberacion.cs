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
using Entidades.Estructuras;

namespace Presentacion.Procesos
{
    public partial class wIngresoUnidadesSegundaLiberacion : Heredados.MiForm8
    {
        public wIngresoUnidadesSegundaLiberacion()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<MovimientoDetaEN> eLisMovDet = new List<MovimientoDetaEN>();
        public string eTitulo = "Ingreso Unidades";
               
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
            this.txtCorProDet.Text = pObj.CorrelativoProduccionProTer;
            this.txtCodAlm.Text = "A11";//almacen productos en proceso
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
            this.txtDesAlm.Text = iAlmEN.DescripcionAlmacen;
        }

        public void MostrarTiposOperacionesIngreso()
        {
            //traemos los codigos de tipos de operacion para la transferencia
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionProduccionIngreso);

            //mostrar los datos
            this.txtCodTipOpe.Text = iTipOpeEN.CodigoTipoOperacion;
            this.txtDesTipOpe.Text = iTipOpeEN.DescripcionTipoOperacion;
            this.txtCCalPrePro.Text = iTipOpeEN.CCalculaPrecioPromedio;
        }

        public MovimientoCabeEN ObtenerMovimientoCabeIngresoBD(ProduccionProTerEN pObj)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pObj.ClaveIngresoSemiProductoSegundaLiberacion;

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
            if (pObj.ClaveIngresoSemiProductoSegundaLiberacion == string.Empty)
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
            this.dtpFecMovCab.Text = pObj.FechaEncajado;
            this.MostrarTiposOperacionesIngreso();           
            this.MostrarDatosPersonalDeAlmacen();
            this.LLenarMovimientoDetaAlAdicionar(pObj);
            this.MostrarMovimientoDeta();      
            eMas.AccionHabilitarControles(0);         
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void VentanaModificar(ProduccionProTerEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeIngresoBD(pObj));            
            this.LLenarMovimientoDetaAlAdicionar(pObj);
            this.MostrarMovimientoDeta();      
            eMas.AccionHabilitarControles(1);          
            eMas.AccionPasarTextoPrincipal();        
            this.dtpFecMovCab.Focus();
        }

        public void VentanaVisualizar(ProduccionProTerEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeIngresoBD(pObj));           
            this.LLenarMovimientoDetaDeBaseDatos(pObj);
            this.MostrarMovimientoDeta();
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
            this.txtDesAlm.Text = pMovCab.DescripcionAlmacen;      
            this.txtGloMovCab.Text = pMovCab.GlosaMovimientoCabe;          
        }

        public void MostrarMovimientoDeta()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvProExi;
            List<MovimientoDetaEN> iFuenteDatos = MovimientoDetaRN.RefrescarListaMovimientoDeta(this.eLisMovDet);
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

        public void LLenarMovimientoDetaDeBaseDatos(ProduccionProTerEN pObj)
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pObj.ClaveIngresoSemiProductoSegundaLiberacion;
            iMovDetEN.Adicionales.CampoOrden = MovimientoDetaEN.ClaMovDet;
            this.eLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);
        }

        public void LLenarMovimientoDetaAlAdicionar(ProduccionProTerEN pObj)
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = pObj;
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //ejecutar metodo
            this.eLisMovDet = MovimientoDetaRN.ListarMovimientoDetaParaIngresoUnidadesSegundaLiberacion(iProProTerEN, iMovCabEN);
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
            //if (this.HayStockExistenciasParaParteTrabajo() == false) { return; }

            //valida la existencia
            if (this.EsCodigoExistenciaValido() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //mostrar numero movimientoCabe salida
            this.MostrarNuevoNumero();

            //adicionando el registro salida
            this.AdicionarMovimientoCabe();
                      
            //adicionando detalles salida
            this.AdicionarMovimientosDeta();

            //actualizar las existencias referenciadas
            this.ActualizarExistenciasPorAdicion();
             
            //modificar el encajado
            this.ModificarProduccionProTer();

            //modificar el parte de trabajo
            this.ModificarProduccionDetaAlAdicionarIngresoUnidadesSegundaLiberacion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego el ingreso de unidades correctamente", this.eTitulo);

            //actualizar al propietario           
            this.wSegLib.eClaveDgvProProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);
            this.wSegLib.ActualizarVentana();

            //imprimir la nota
            //this.wParTra.AccionImprimirSalidasReproceso();

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
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe();
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
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);          
            iProProTerEN.ClaveIngresoSemiProductoSegundaLiberacion = this.ObtenerClaveMovimientoCabe();

            //ejecutar metodo
            ProduccionProTerRN.ModificarPorIngresoUnidadesSegundaLiberacion(iProProTerEN);
        }

        public void ModificarProduccionDetaAlAdicionarIngresoUnidadesSegundaLiberacion()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);

            //ejecutar metodo
            ProduccionDetaRN.ModificarProduccionDetaAlAdicionarIngresoUnidadesSegundaLiberacion(iProProTerEN);
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

        public void ModificarProduccionDetaAlEliminarIngresoUnidadesSegundaLiberacion()
        {
            //asignar parametros
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);

            //ejecutar metodo
            ProduccionDetaRN.ModificarProduccionDetaAlEliminarIngresoUnidadesSegundaLiberacion(iProProTerEN);
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
            if (Mensaje.DeseasRealizarOperacion(this.wSegLib.eTitulo) == false) { return; }

            //modificar el registro salida
            this.ModificarMovimientoCabe();
                      
            //actualizar las existencias por eliminacion
            this.ActualizarExistenciasPorEliminacion();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosMovimientosDeta();

            //adicionando detalles salida
            this.AdicionarMovimientosDeta();

            //actualizar existencias por adicion
            this.ActualizarExistenciasPorAdicion();
            
            //modificar al eliminar ingreso unidades
            this.ModificarProduccionDetaAlEliminarIngresoUnidadesSegundaLiberacion();

            //modificar al adicionar ingreso unidades
            this.ModificarProduccionDetaAlAdicionarIngresoUnidadesSegundaLiberacion();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico el ingreso de unidades correctamente", this.wSegLib.eTitulo);

            //actualizar al wLot          
            this.wSegLib.eClaveDgvProProTer = Dgv.ObtenerValorCelda(this.wSegLib.DgvProProTer, ProduccionProTerEN.ClaObj);
            this.wSegLib.ActualizarVentana();

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

        public string ObtenerClaveMovimientoCabe()
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public ExistenciaEN NuevaExistenciaVentana()
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

        public bool EsCodigoExistenciaValido()
        {
            //validar 
            //asignar parametros       
            ExistenciaEN iExiSalEN = this.NuevaExistenciaVentana();           
            string iCodigoExistenciaFranjaGrilla = string.Empty;
            List<MovimientoDetaEN> iLisMovDetGrilla = new List<MovimientoDetaEN>();
            Universal.Opera iOperacionVentana = this.eOperacion;

            //ejecutar metodo
            iExiSalEN = ExistenciaRN.EsExistenciaActivoValido(iExiSalEN, iOperacionVentana, iCodigoExistenciaFranjaGrilla, iLisMovDetGrilla);
            if (iExiSalEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiSalEN.Adicionales.Mensaje, "Existencia");              
            }
            
            //devolver
            return iExiSalEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wSegLib.eTitulo);
        }
            

        #endregion
                

        private void wIngresoUnidadesSegundaLiberacion_FormClosing(object sender, FormClosingEventArgs e)
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

    }
}
