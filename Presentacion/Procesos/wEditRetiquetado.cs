using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.FuncionesGenericas;
using Presentacion.Listas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace Presentacion.Procesos
{
    public partial class wEditRetiquetado : Heredados.MiForm8
    {
        public wEditRetiquetado()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<RetiquetadoProTerEN> eLisRetProTer = new List<RetiquetadoProTerEN>();
        public string eClaveDgvRetProTer = string.Empty;
        Dgv.Franja eFranjaDgvRetProTer = Dgv.Franja.PorIndice;

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
            xCtrl.txtNoFoco(this.txtCorRet, this.dtpFecRet, "ffff");
            xLis.Add(xCtrl);
           
            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecRet, "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlmPT, true, "Almacen PT", "vvff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlmPT, this.txtDesAlmPT, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExiPT, true, "Existencia PT", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExiPT, this.txtDesExiPT, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlmRE, true, "Almacen RE", "vvff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlmRE, this.txtDesAlmRE, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodExiRE, true, "Existencia RE", "vvff", 20);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExiRE, this.txtDesExiRE, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUniPorEmp, this.dtpFecRet, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanUniRet, this.dtpFecRet, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCanCajRet, this.dtpFecRet, "ffff");           
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wRet.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            
            //deshabilitar al propietario
            this.wRet.Enabled = false;

            //mostrar ventana
            this.Show();
        }

        public void ValoresXDefecto()
        {
            //traer al alamcen de productos terminados
            AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacenXCodigo("A13");

            //mostrar datos en pantalla
            this.txtCodAlmPT.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlmPT.Text = iAlmEN.DescripcionAlmacen;
            this.txtCodAlmRE.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlmRE.Text = iAlmEN.DescripcionAlmacen;
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarRetiquetado(RetiquetadoRN.EnBlanco());
            this.ValoresXDefecto();
            this.MostrarRetiquetadosProTer();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecRet.Focus();
        }

        public void VentanaModificar(RetiquetadoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarRetiquetado(pObj);
            this.LLenarRetiquetadoProTerDeBaseDatos(pObj);
            this.MostrarRetiquetadosProTer();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecRet.Focus();
        }

        public void VentanaEliminar(RetiquetadoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarRetiquetado(pObj);
            this.LLenarRetiquetadoProTerDeBaseDatos(pObj);
            this.MostrarRetiquetadosProTer();
            eMas.AccionHabilitarControles(2);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(RetiquetadoEN pObj)
        {
            this.InicializaVentana();
            this.MostrarRetiquetado(pObj);
            this.LLenarRetiquetadoProTerDeBaseDatos(pObj);
            this.MostrarRetiquetadosProTer();
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void AsignarRetiquetado(RetiquetadoEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CorrelativoRetiquetado = this.txtCorRet.Text.Trim();
            pObj.FechaRetiquetado = this.dtpFecRet.Text;
            pObj.PeriodoRetiquetado = Fecha.ObtenerPeriodo(pObj.FechaRetiquetado, "-");
            pObj.CodigoAlmacenPT = this.txtCodAlmPT.Text.Trim();
            pObj.CodigoExistenciaPT = this.txtCodExiPT.Text.Trim();
            pObj.CodigoAlmacenRE = this.txtCodAlmRE.Text.Trim();
            pObj.CodigoExistenciaRE = this.txtCodExiRE.Text.Trim();
            pObj.UnidadesPorEmpaqueRE = Conversion.ADecimal(this.txtUniPorEmp.Text, 0);
            pObj.CantidadUnidadesRetiquetado = Conversion.ADecimal(this.txtCanUniRet.Text, 0);
            pObj.CantidadCajasRetiquetado = Conversion.ADecimal(this.txtCanCajRet.Text, 0);
            pObj.ClaveRetiquetado = RetiquetadoRN.ObtenerClaveRetiquetado(pObj);
        }

        public void MostrarRetiquetado(RetiquetadoEN pObj)
        {
            this.txtCorRet.Text = pObj.CorrelativoRetiquetado;
            this.dtpFecRet.Text = pObj.FechaRetiquetado;
            this.txtCodAlmPT.Text = pObj.CodigoAlmacenPT;
            this.txtDesAlmPT.Text = pObj.DescripcionAlmacenPT;
            this.txtCodExiPT.Text = pObj.CodigoExistenciaPT;
            this.txtDesExiPT.Text = pObj.DescripcionExistenciaPT;
            this.txtCodAlmRE.Text = pObj.CodigoAlmacenRE;
            this.txtDesAlmRE.Text = pObj.DescripcionAlmacenRE;
            this.txtCodExiRE.Text = pObj.CodigoExistenciaRE;
            this.txtDesExiRE.Text = pObj.DescripcionExistenciaRE;
            this.txtUniPorEmp.Text = Formato.NumeroDecimal(pObj.UnidadesPorEmpaqueRE, 0);
            this.txtCanUniRet.Text = Formato.NumeroDecimal(pObj.CantidadUnidadesRetiquetado, 0);
            this.txtCanCajRet.Text = Formato.NumeroDecimal(pObj.CantidadCajasRetiquetado, 2);
        }

        public void MostrarRetiquetadosProTer()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvRetProTer;
            List<RetiquetadoProTerEN> iFuenteDatos = ListaG.Refrescar<RetiquetadoProTerEN>(this.eLisRetProTer);
            Dgv.Franja iCondicionFranja = eFranjaDgvRetProTer;
            string iClaveBusqueda = eClaveDgvRetProTer;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoProTerEN.CorEnc, "Encajado", 60));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoProTerEN.DesExi, "Descripcion", 300));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(RetiquetadoProTerEN.CosTotPro, "Precio.Uni", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(RetiquetadoProTerEN.CanRetProTer, "Cant.Uni", 90, 0));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoProTerEN.UsuAgr, "UsuarioAgrega", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoProTerEN.ClaProProTer, "ClaveProProTer", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(RetiquetadoProTerEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarRetiquetadoProTerDeBaseDatos(RetiquetadoEN pObj)
        {
            RetiquetadoProTerEN iRetProTerEN = new RetiquetadoProTerEN();
            iRetProTerEN.ClaveRetiquetado = pObj.ClaveRetiquetado;
            iRetProTerEN.Adicionales.CampoOrden = RetiquetadoProTerEN.ClaRetProTer;
            this.eLisRetProTer = RetiquetadoProTerRN.ListarRetiquetadoProTerXClaveRetiquetado(iRetProTerEN);
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
            if (Mensaje.DeseasRealizarOperacion(this.wRet.eTitulo) == false) { return; }

            //mostrar numero retiquetado
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarRetiquetado();

            //adicionando detalles
            this.AdicionarRetiquetadosProTer();

            //adicionando producciones exis
            this.AdicionarProduccionExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Retiquetado se adiciono correctamente", this.wRet.eTitulo);

            //actualizar al propietario
            this.wRet.eClaveDgvRet = this.ObtenerClaveRetiquetado();
            this.wRet.ActualizarVentana();

            //limpiar controles
            this.MostrarRetiquetado(this.ObtenerObjetoConValoresPersistentes());
            this.eLisRetProTer.Clear();
            this.MostrarRetiquetadosProTer();
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecRet.Focus();
        }

        public RetiquetadoEN ObtenerObjetoConValoresPersistentes()
        {
            //objeto resultado
            RetiquetadoEN iRetEN = new RetiquetadoEN();

            //capturar datos persistentes
            iRetEN.FechaRetiquetado = this.dtpFecRet.Text;
            iRetEN.CodigoAlmacenPT = this.txtCodAlmPT.Text.Trim();
            iRetEN.DescripcionAlmacenPT = this.txtDesAlmPT.Text.Trim();
            iRetEN.CodigoAlmacenRE = this.txtCodAlmRE.Text.Trim();
            iRetEN.DescripcionAlmacenRE = this.txtDesAlmRE.Text.Trim();

            //devolver
            return iRetEN;
        }

        public void MostrarNuevoNumero()
        {
            //obtener el nuevo numero
            string iNuevoNumero = RetiquetadoRN.ObtenerNuevoNumeroRetiquetadoAutogenerado();

            //mostrar en pantalla
            this.txtCorRet.Text = iNuevoNumero;
        }

        public void AdicionarRetiquetado()
        {
            //asignar parametros
            RetiquetadoEN iRetEN = this.NuevoRetiquetadoVentana();

            //actualizar campos porcentajes y cantidades rango
            RetiquetadoRN.ActualizarPorcentajesYCantidadesRango(iRetEN);

            //ejecutar metodo
            RetiquetadoRN.AdicionarRetiquetado(iRetEN);
        }

        public void AdicionarRetiquetadosProTer()
        {
            //variables
            string iClaveRetiquetado = this.ObtenerClaveRetiquetado();
            string iCorrelativo = "00";

            //recorrer cada objeto
            foreach (RetiquetadoProTerEN xRetProTer in this.eLisRetProTer)
            {
                //incrementar el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

                //actualizar algunos datos antes de grabar              
                xRetProTer.ClaveRetiquetado = iClaveRetiquetado;
                xRetProTer.CorrelativoRetiquetado = this.txtCorRet.Text.Trim();
                xRetProTer.CorrelativoRetiquetadoProTer = iCorrelativo;
                xRetProTer.ClaveRetiquetadoProTer = RetiquetadoProTerRN.ObtenerClaveRetiquetadoProTer(xRetProTer);
            }

            //adicion masiva
            RetiquetadoProTerRN.AdicionarRetiquetadoProTer(this.eLisRetProTer);
        }

        public void AdicionarProduccionExis()
        {
            //asignar parametros
            RetiquetadoEN iRetEN = this.NuevoRetiquetadoVentana();

            //buscar en bd el nuevo registro
            iRetEN = RetiquetadoRN.BuscarRetiquetadoXClave(iRetEN);

            //ejecutar metodo
            ProduccionExisRN.AdicionarProduccionExisFaseEmpaquetadoRE(iRetEN);
        }

        public RetiquetadoEN NuevoRetiquetadoVentana()
        {
            RetiquetadoEN iObjEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iObjEN);
            return iObjEN;
        }

        public string ObtenerClaveRetiquetado()
        {
            RetiquetadoEN iObjEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iObjEN);
            return iObjEN.ClaveRetiquetado;
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //volver a preguntar si es acto
            if (this.wRet.EsActoModificarRetiquetado().Adicionales.EsVerdad == false) { return; }

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wRet.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarRetiquetado();

            //eliminar produccionesProTer anterior
            this.EliminarAntiguosRetiquetadosProTer();

            //adicionando nuevos ProduccionProTer
            this.AdicionarRetiquetadosProTer();

            //eliminar producciones exis anterior
            this.EliminarProduccionesExis();

            //adicionando producciones exis
            this.AdicionarProduccionExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Retiquetado se modifico correctamente", this.wRet.eTitulo);

            //actualizar al wUsu
            this.wRet.eClaveDgvRet = this.ObtenerClaveRetiquetado();
            this.wRet.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void ModificarRetiquetado()
        {
            RetiquetadoEN iObjEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iObjEN);
            iObjEN = RetiquetadoRN.BuscarRetiquetadoXClave(iObjEN);
            this.AsignarRetiquetado(iObjEN);
            //actualizar campos porcentajes y cantidades rango
            RetiquetadoRN.ActualizarPorcentajesYCantidadesRango(iObjEN);
            RetiquetadoRN.ModificarRetiquetado(iObjEN);
        }

        public void EliminarAntiguosRetiquetadosProTer()
        {
            RetiquetadoProTerEN iRetProTerEN = new RetiquetadoProTerEN();
            iRetProTerEN.ClaveRetiquetado = this.ObtenerClaveRetiquetado();
            RetiquetadoProTerRN.EliminarRetiquetadoProTerXClaveRetiquetado(iRetProTerEN);
        }

        public void EliminarProduccionesExis()
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveRetiquetado = this.ObtenerClaveRetiquetado();

            //ejecutar metodo
            ProduccionExisRN.EliminarProduccionExisXClaveRetiquetado(iProExiEN);
        }

        public void Eliminar()
        {
            //volver a preguntar si es acto
            if (this.wRet.EsActoEliminarRetiquetado().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wRet.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarRetiquetado();

            //eliminar produccionesProTer anterior
            this.EliminarAntiguosRetiquetadosProTer();

            //eliminar producciones exis anterior
            this.EliminarProduccionesExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("El Retiquetado se elimino correctamente", this.wRet.eTitulo);

            //actualizar al propietario           
            this.wRet.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }

        public void EliminarRetiquetado()
        {
            RetiquetadoEN iObjEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iObjEN);
            RetiquetadoRN.EliminarRetiquetado(iObjEN);
        }

        public void AccionAgregarItem()
        {
            //instanciar
            wDetalleRetiquetado win = new wDetalleRetiquetado();
            win.wEditRet = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvRetProTer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.eLisRetProTer.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleRetiquetado win = new wDetalleRetiquetado();
            win.wEditRet = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvRetProTer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisRetProTer[Dgv.ObtenerIndiceRegistroXFranja(this.dgvRetProTer)]);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisRetProTer.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleRetiquetado win = new wDetalleRetiquetado();
            win.wEditRet = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvRetProTer = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisRetProTer[Dgv.ObtenerIndiceRegistroXFranja(this.dgvRetProTer)]);
        }

        public bool EsFechaValida()
        {
            //asignar parametros
            RetiquetadoEN iRetEN = new RetiquetadoEN();
            this.AsignarRetiquetado(iRetEN);

            //ejecutar metodo
            iRetEN = RetiquetadoRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iRetEN);

            //mostrar mensaje error
            Generico.MostrarMensajeError(iRetEN.Adicionales, this.dtpFecRet);

            //devolver
            return iRetEN.Adicionales.EsVerdad;
        }

        public void ListarAlmacenesPT()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlmPT.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlmPT;
            win.eCtrlFoco = this.txtCodExiPT;
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValidoPT()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlmPT.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlmPT.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, "Almacen PT");
                this.txtCodAlmPT.Focus();
            }

            //mostrar datos
            this.txtCodAlmPT.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlmPT.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarExistenciasPT()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExiPT.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias PT";
            win.eCtrlValor = this.txtCodExiPT;
            win.eCtrlFoco = this.txtCodAlmRE;
            win.eExiEN.CodigoAlmacen = this.txtCodAlmPT.Text.Trim();            
            win.eCondicionLista = wLisExi.Condicion.ListarExistenciasProductosTerminadosActivosDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValidoPT()
        {
            //solo si esta habilitado el control
            if (this.txtCodExiPT.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = this.NuevaExistenciaVentanaPT();
            
            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaProductoTerminadoActivoValido(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia PT");
                this.txtCodExiPT.Focus();
            }

            //pasar datos
            this.txtCodExiPT.Text = iExiEN.CodigoExistencia;
            this.txtDesExiPT.Text = iExiEN.DescripcionExistencia;
            
            //devolver
            return iExiEN.Adicionales.EsVerdad;
        }

        public ExistenciaEN NuevaExistenciaVentanaPT()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.txtCodAlmPT.Text.Trim();
            iExiEN.DescripcionAlmacen = this.txtDesAlmPT.Text.Trim();
            iExiEN.CodigoExistencia = this.txtCodExiPT.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public void ListarAlmacenesRE()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlmRE.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlmRE;
            win.eCtrlFoco = this.txtCodExiRE;
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacenValidoRE()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlmRE.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlmRE.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            iAlmEN = AlmacenRN.EsAlmacenActivoValido(iAlmEN);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, "Almacen PT");
                this.txtCodAlmRE.Focus();
            }

            //mostrar datos
            this.txtCodAlmRE.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlmRE.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarExistenciasRE()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodExiRE.ReadOnly == true) { return; }

            //instanciar lista
            wLisExi win = new wLisExi();
            win.eVentana = this;
            win.eTituloVentana = "Existencias RE";
            win.eCtrlValor = this.txtCodExiRE;
            win.eCtrlFoco = this.btnAgregar;
            win.eExiEN.CodigoAlmacen = this.txtCodAlmRE.Text.Trim();
            win.eCondicionLista = wLisExi.Condicion.ListarExistenciasProductosTerminadosActivosDeAlmacen;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoExistenciaValidoRE()
        {
            //solo si esta habilitado el control
            if (this.txtCodExiRE.ReadOnly == true) { return true; }

            //validar 
            //asignar parametros       
            ExistenciaEN iExiEN = this.NuevaExistenciaVentanaRE();

            //ejecutar metodo
            iExiEN = ExistenciaRN.EsExistenciaProductoTerminadoActivoValido(iExiEN);
            if (iExiEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iExiEN.Adicionales.Mensaje, "Existencia PT");
                this.txtCodExiRE.Focus();
            }

            //pasar datos
            this.txtCodExiRE.Text = iExiEN.CodigoExistencia;
            this.txtDesExiRE.Text = iExiEN.DescripcionExistencia;
            this.txtUniPorEmp.Text = Formato.NumeroDecimal(iExiEN.UnidadesPorEmpaque, 0);
            this.MostrarCantidadCajasRE();

            //devolver
            return iExiEN.Adicionales.EsVerdad;
        }

        public ExistenciaEN NuevaExistenciaVentanaRE()
        {
            //crear un nuevo objeto
            ExistenciaEN iExiEN = new ExistenciaEN();

            //pasamos datos desde las ventanas
            iExiEN.CodigoAlmacen = this.txtCodAlmRE.Text.Trim();
            iExiEN.DescripcionAlmacen = this.txtDesAlmRE.Text.Trim();
            iExiEN.CodigoExistencia = this.txtCodExiRE.Text.Trim();
            iExiEN.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(iExiEN);

            //devolver
            return iExiEN;
        }

        public void MostrarUnidadesRE()
        {
            //ejecutar metodo
            decimal iValor = Dgv.SumarColumna(this.dgvRetProTer, RetiquetadoProTerEN.CanRetProTer);

            //mostrar en pantalla
            this.txtCanUniRet.Text = Formato.NumeroDecimal(iValor, 0);
        }

        public void MostrarCantidadCajasRE()
        {
            //asignar parametros
            RetiquetadoEN iRetEN = this.NuevoRetiquetadoVentana();

            //ejecutar metodos          
            decimal iNumeroCajas = RetiquetadoRN.CalcularNumeroCajas(iRetEN);

            //mostrar en pantalla
            this.txtCanCajRet.Text = Formato.NumeroDecimal(iNumeroCajas, 2);
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wRet.eTitulo);
        }

        #endregion

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void wEditRetiquetado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wRet.Enabled = true;
        }

        private void txtCodAlmPT_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValidoPT();
        }

        private void txtCodAlmPT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenesPT(); }
        }

        private void txtCodAlmPT_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenesPT();
        }

        private void txtCodExiPT_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValidoPT();
        }

        private void txtCodExiPT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistenciasPT(); }
        }

        private void txtCodExiPT_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistenciasPT();
        }

        private void txtCodAlmRE_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacenValidoRE();
        }

        private void txtCodAlmRE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenesRE(); }
        }

        private void txtCodAlmRE_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenesRE();
        }

        private void txtCodExiRE_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoExistenciaValidoRE();
        }

        private void txtCodExiRE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarExistenciasRE(); }
        }

        private void txtCodExiRE_DoubleClick(object sender, EventArgs e)
        {
            this.ListarExistenciasRE();
        }
    }
}
