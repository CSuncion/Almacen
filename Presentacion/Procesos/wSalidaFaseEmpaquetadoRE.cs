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
    public partial class wSalidaFaseEmpaquetadoRE : Heredados.MiForm8
    {
        public wSalidaFaseEmpaquetadoRE()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<ProduccionExisEN> eLisProExi = new List<ProduccionExisEN>();
        public string eTitulo = "Salida insumos";
               
        #endregion

        #region Propietario

        public wRetiquetado wRet;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCorRet, this.dtpFecMovCab, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNumMovCab, this.dtpFecMovCab, "ffff");
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
            xCtrl.Btn(this.btnEliminar, "vvff");
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


        public void InicializaVentana(RetiquetadoEN pObj)
        {           
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();                   

            //valores x defecto
            this.ValoresXDefecto(pObj);

            // Deshabilitar al propietario de esta ventana
            this.wRet.Enabled = false;

            // Mostrar ventana        
            this.Show();
        }

        public void ValoresXDefecto(RetiquetadoEN pObj)
        {
            this.txtCorRet.Text = pObj.CorrelativoRetiquetado;
            this.txtCodAlm.Text = "A09";
            this.dtpFecMovCab.Text = pObj.FechaRetiquetado;       
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

        public MovimientoCabeEN ObtenerMovimientoCabeSalidaBD(RetiquetadoEN pObj)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pObj.ClaveSalidaFaseEmpaquetado;

            //ejecutar metodo
            return MovimientoCabeRN.BuscarMovimientoCabeXClave(iMovCabEN);
        }

        public void NuevaVentana(RetiquetadoEN pObj)
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

        public void ActualizareOperacion(RetiquetadoEN pObj)
        {
            if (pObj.ClaveSalidaFaseEmpaquetado == string.Empty)
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

        public void VentanaAdicionar(RetiquetadoEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarMovimientoCabe(MovimientoCabeRN.EnBlanco());
            this.dtpFecMovCab.Text = pObj.FechaRetiquetado;
            this.MostrarTipoOperacioneSalidaInsumos();
            this.MostrarDatosPersonalDeAlmacen();
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExis();                 
            eMas.AccionHabilitarControles(0);         
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecMovCab.Focus();
        }

        public void VentanaModificar(RetiquetadoEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeSalidaBD(pObj));
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExis();      
            eMas.AccionHabilitarControles(1);          
            eMas.AccionPasarTextoPrincipal();        
            this.dtpFecMovCab.Focus();
        }

        public void VentanaVisualizar(RetiquetadoEN pObj)
        {
            this.InicializaVentana(pObj);
            this.MostrarMovimientoCabe(this.ObtenerMovimientoCabeSalidaBD(pObj));
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExisSoloLectura();
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

        public void MostrarProduccionExis()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvProExi;
            List<ProduccionExisEN> iFuenteDatos = ProduccionExisRN.RefrescarListaProduccionExis(this.eLisProExi); ;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);

            //pintamos las dos columnas digitables            
            Dgv.PintarSoloColumna(iGrilla, ProduccionExisEN.CanProExi);
        }

        public void MostrarProduccionExisSoloLectura()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvProExi;
            List<ProduccionExisEN> iFuenteDatos = ProduccionExisRN.RefrescarListaProduccionExis(this.eLisProExi); ;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;          
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvComSoloLectura();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.DesExi, "Descripcion", 220));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.NomUniMed, "Uni.Med", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumericoEditable(ProduccionExisEN.CanProExi, "Cant", 100, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public List<DataGridViewColumn> ListarColumnasDgvComSoloLectura()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.DesExi, "Descripcion", 220));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.NomUniMed, "Uni.Med", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionExisEN.CanProExi, "Cant", 100, 5));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionExisEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarProduccionExisDeBaseDatos()
        {
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveRetiquetado = Dgv.ObtenerValorCelda(this.wRet.DgvRet, RetiquetadoEN.ClaObj);
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            this.eLisProExi = ProduccionExisRN.ListarProduccionExisXClaveRetiquetado(iProExiEN);
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

            //modificar el retiquetado
            this.ModificarRetiquetado();

            //modificar produccionesExis
            this.ModificarProducionExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego la salida correctamente", this.eTitulo);

            //actualizar al propietario           
            this.wRet.eClaveDgvRet = Dgv.ObtenerValorCelda(this.wRet.DgvRet, RetiquetadoEN.ClaObj);
            this.wRet.ActualizarVentana();

            //imprimir la nota
            //this.wEnc.AccionImprimirSalidasFaseEmpaquetado();

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
            List<ProduccionExisEN> iLisProExi = this.eLisProExi;
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana();

            //ejecutar metodo
            MovimientoDetaRN.AdicionarMovimientoDetaPorSalidaInsumos(iLisProExi, iMovCabEN);
        }

        public void ActualizarExistenciasPorAdicion()
        {
            //asignar parametros
            List<MovimientoDetaEN> iLisMovDet = this.ListarMovimientosDeta();

            //ejecutar metodo
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);
        }

        public void ModificarRetiquetado()
        {
            //asignar parametros
            RetiquetadoEN iEncEN = new RetiquetadoEN();
            iEncEN.ClaveRetiquetado = Dgv.ObtenerValorCelda(this.wRet.DgvRet, RetiquetadoEN.ClaObj);            
            iEncEN.ClaveSalidaFaseEmpaquetado = this.ObtenerClaveMovimientoCabe();

            //ejecutar metodo
            RetiquetadoRN.ModificarPorSalidaInsumosFaseEmpaquetado(iEncEN);            
        }

        public void ModificarProducionExis()
        {
            //asignar parametros
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveRetiquetado(Dgv.ObtenerValorCelda(this.wRet.DgvRet,
                ProduccionExisEN.ClaObj));
            
            //ejecutar metodo
            ProduccionExisRN.ActualizarPreciosUnitariosDesdeExistencias(iLisProExi);
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

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wRet.eTitulo) == false) { return; }

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

            //modificar el retiquetado
            this.ModificarRetiquetado();

            //modificar produccionesExis
            this.ModificarProducionExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la salida correctamente", this.wRet.eTitulo);

            //actualizar al wLot          
            this.wRet.eClaveDgvRet = Dgv.ObtenerValorCelda(this.wRet.DgvRet, RetiquetadoEN.ClaObj);
            this.wRet.ActualizarVentana();

            //imprimir la nota
            //this.wEnc.AccionImprimirSalidasFaseEmpaquetado();

            //salir de la ventana
            this.Close();
        }

        public bool HayStockExistenciasParaParteTrabajo()
        {
            //listar existencias que no completan el stock para esta parte de trabajo
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosFaltantesParaParteTrabajo(this.eLisProExi);

            //si hay elementos en la lista, entonces invoca la ventana
            if (iLisInsFal.Count != 0)
            {
                //instanciar
                wInsumosFaltantesRetiquetado win = new wInsumosFaltantesRetiquetado();
                win.eVentanaPropietario = this;
                win.eLisInsFal = iLisInsFal;                       
                TabCtrl.InsertarVentana(this, win);
                win.NuevaVentana(this.wRet.EsRetiquetadoExistente());

                //devolver
                return false;
            }

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
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, this.wRet.eTitulo);
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

        public void ModificarProduccionExisDigitado(int pIndiceColumna)
        {
            //asignar parametro
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionExis = Dgv.ObtenerValorCelda(this.dgvProExi, ProduccionExisEN.ClaObj);
            iProExiEN.CantidadProduccionExis = Conversion.ADecimal(Dgv.ObtenerValorCelda(this.dgvProExi, ProduccionExisEN.CanProExi), 5);

            //ejecutar metodo
            ProduccionExisRN.ModificarPorCantidadDigitada(iProExiEN);
        }

        public void ValidarFormatoDecimal(DataGridViewCellValidatingEventArgs pE, string pNombreColumna, string pEncabezadoColumna)
        {
            //asignar parametros
            int iIndiceColumna = this.dgvProExi.Columns[pNombreColumna].Index;
            string iEncabezadoColumna = pEncabezadoColumna;
            DataGridViewCellValidatingEventArgs iE = pE;

            //ejecutar metodo
            ValidarCeldaDgv.vNumerosDecimalesPositivos(iIndiceColumna, iEncabezadoColumna, iE);
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

        public void EliminarItem()
        {
            //valida grilla vacia
            if (Dgv.ValidaCuandoGrillaEstaVacia(this.dgvProExi) == false) { return; }

            //desea realizar la operacion
            if(Mensaje.DeseasRealizarOperacion("Eliminar Item") == false) { return; }

            //eliminar el item
            this.EliminarProduccionExi();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el item", "Item");

            //actualizar grilla
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExis();
        }

        public void EliminarProduccionExi()
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionExis = Dgv.ObtenerValorCelda(this.dgvProExi, ProduccionExisEN.ClaObj);

            //ejecutar metodo
            ProduccionExisRN.EliminarProduccionExis(iProExiEN);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wRet.eTitulo);
        }
            

        #endregion
                

        private void wSalidaFaseEmpaquetadoRE_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wRet.Enabled = true;
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
            this.dgvProExi.BeginEdit(true);
        }

        private void dgvProExi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarProduccionExisDigitado(e.ColumnIndex);
            this.LLenarProduccionExisDeBaseDatos();
            this.MostrarProduccionExis();
            Dgv.EditarEnCeldaDeFilaSeleccionada(this.dgvProExi, e.ColumnIndex);
        }

        private void dgvProExi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            this.ValidarFormatoDecimal(e, ProduccionExisEN.CanProExi, "Cantidad");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.EliminarItem();
        }
    }
}
