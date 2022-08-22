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
using Presentacion.Impresiones;

namespace Presentacion.Procesos
{
    public partial class wEditEncajado : Heredados.MiForm8
    {
        public wEditEncajado()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public List<ProduccionProTerEN> eLisProProTer = new List<ProduccionProTerEN>();       
        public string eClaveDgvProProTer = string.Empty;
        Dgv.Franja eFranjaDgvProProTer = Dgv.Franja.PorIndice;
             
        #endregion

        #region Propietario

        public wPlanEncajado wEnc;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCorEnc, this.dtpFecEnc, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.dtpFecEnc, "vvff");
            xLis.Add(xCtrl);
            
            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtDesEnc, false, "Glosa", "vvff", 100);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtEstEnc, this.dtpFecEnc, "ffff");
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
            this.Text = this.eOperacion.ToString() + Cadena.Espacios(1) + this.wEnc.eTitulo;

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            // Deshabilitar al propietario de esta ventana
            this.wEnc.Enabled = false;

            // Mostrar ventana
            this.Show();
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.MostrarEncajado(EncajadoRN.EnBlanco());        
            this.MostrarProduccionesProTer();
            this.HabilitarDesplazadores();
            eMas.AccionHabilitarControles(0);         
            eMas.AccionPasarTextoPrincipal();
            this.dtpFecEnc.Focus();
        }

        public void VentanaModificar(EncajadoEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarEncajado(pMovCab);
            this.LLenarProduccionProTerDeBaseDatos(pMovCab);          
            this.MostrarProduccionesProTer();
            this.HabilitarDesplazadores();
            eMas.AccionHabilitarControles(1);          
            eMas.AccionPasarTextoPrincipal();        
            this.dtpFecEnc.Focus();
        }

        public void VentanaEliminar(EncajadoEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarEncajado(pMovCab);
            this.LLenarProduccionProTerDeBaseDatos(pMovCab);          
            this.MostrarProduccionesProTer();
            eMas.AccionHabilitarControles(2);
            this.tsSecundario.Enabled = false;       
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(EncajadoEN pMovCab)
        {
            this.InicializaVentana();
            this.MostrarEncajado(pMovCab);
            this.LLenarProduccionProTerDeBaseDatos(pMovCab);          
            this.MostrarProduccionesProTer();
            eMas.AccionHabilitarControles(3);
            this.tsSecundario.Enabled = false;
            this.btnCancelar.Focus();
        }

        public void AsignarEncajado(EncajadoEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;          
            pMovCab.CorrelativoEncajado = this.txtCorEnc.Text.Trim();
            pMovCab.FechaEncajado = dtpFecEnc.Text;
            pMovCab.PeriodoEncajado = Fecha.ObtenerPeriodo(pMovCab.FechaEncajado, "-");
            pMovCab.DescripcionEncajado = this.txtDesEnc.Text;
            pMovCab.NEstadoEncajado =this.txtEstEnc.Text;          
            pMovCab.ClaveEncajado = EncajadoRN.ObtenerClaveEncajado(pMovCab);
        }

        public void MostrarEncajado(EncajadoEN pMovCab)
        {
            this.txtCorEnc.Text = pMovCab.CorrelativoEncajado;
            this.dtpFecEnc.Text = pMovCab.FechaEncajado;            
            this.txtDesEnc.Text = pMovCab.DescripcionEncajado;
            this.txtEstEnc.Text = pMovCab.NEstadoEncajado;          
        }

        public void MostrarProduccionesProTer()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvProProTer;
            List<ProduccionProTerEN> iFuenteDatos = ListaG.Refrescar<ProduccionProTerEN>(this.eLisProProTer);
            Dgv.Franja iCondicionFranja = eFranjaDgvProProTer;
            string iClaveBusqueda = eClaveDgvProProTer;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.CorProProTer, "Orden", 60));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.CodExi, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.DesExi, "Descripcion", 250));            
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionProTerEN.CanUniProTer, "Cant.Uni", 90, 0));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionProTerEN.NumCaj, "Cant.Caj", 90, 0));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.UsuAgr, "UsuarioAgrega", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarProduccionProTerDeBaseDatos(EncajadoEN pObj)
        {
            ProduccionProTerEN iMovDetEN = new ProduccionProTerEN();
            iMovDetEN.ClaveEncajado = pObj.ClaveEncajado;
            iMovDetEN.Adicionales.CampoOrden = ProduccionProTerEN.ClaProProTer;
            this.eLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(iMovDetEN);
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

            //es fecha valida
            if (this.EsValidaFechaEncajado() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wEnc.eTitulo) == false) { return; }

            //mostrar numero Encajado
            this.MostrarNuevoNumero();

            //adicionando el registro
            this.AdicionarEncajado();
            
            //adicionando detalles
            this.AdicionarProduccionesProTer();
                        
            //adicionando produccionExis
            this.AdicionarProduccionExis();

            //modificar saldo liberacion
            this.ModificarSaldosLiberacionesAlAdicionar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego el registro correctamente", this.wEnc.eTitulo);

            //actualizar al propietario           
            this.wEnc.eClaveDgvProCab = this.ObtenerClaveEncajado();
            this.wEnc.ActualizarVentana();

            //limpiar controles
            this.MostrarEncajado(this.ObtenerEncajadoParaSegundaAdicion());           
            this.eLisProProTer.Clear();
            this.MostrarProduccionesProTer();
            this.HabilitarDesplazadores();
            eMas.AccionPasarTextoPrincipal();           
            this.dtpFecEnc.Focus();
        }

        public EncajadoEN ObtenerEncajadoParaSegundaAdicion()
        {
            //objeto
            EncajadoEN iEncEN = new EncajadoEN();

            //pasamos los datos que queremos persistir para una segundo o mas adiciones
            iEncEN.FechaEncajado = Fecha.ObtenerFechaFinal(this.dtpFecEnc.Text, 1);
            
            //devolver
            return iEncEN;
        }

        public void MostrarNuevoNumero()
        {
            //obtener el nuevo numero
            string iNuevoNumero = EncajadoRN.ObtenerNuevoCodigoEncajadoAutogenerado();

            //mostrar en pantalla
            this.txtCorEnc.Text = iNuevoNumero;
        }

        public void AdicionarEncajado()
        {
            EncajadoEN iCuoEN = new EncajadoEN();
            this.AsignarEncajado(iCuoEN);
            EncajadoRN.AdicionarEncajado(iCuoEN);
        }

        public void AdicionarProduccionesProTer()
        {
            //variables
            string iClaveEncajado = this.ObtenerClaveEncajado();
            string iCorrelativo = "00";

            //recorrer cada objeto
            foreach (ProduccionProTerEN xProProTer in this.eLisProProTer)
            {
                //incrementar el correlativo
                iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

                //actualizar algunos datos antes de grabar              
                xProProTer.ClaveEncajado = iClaveEncajado;
                xProProTer.CorrelativoProduccionProTer = iCorrelativo;
                xProProTer.ClaveProduccionProTer = ProduccionProTerRN.ObtenerClaveProduccionProTer(xProProTer);
            }

            //adicion masiva
            ProduccionProTerRN.AdicionarProduccionProTer(this.eLisProProTer);
        }

        public void AdicionarProduccionExis()
        {            
            ProduccionExisRN.AdicionarProduccionExisFaseEmpaquetado(this.eLisProProTer);
        }

        public void ModificarSaldosLiberacionesAlAdicionar()
        {
            ProduccionProTerRN.ModificarSaldoLiberacionAlAdicionar(this.eLisProProTer);
        }

        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wEnc.EsEncajadoExistente().Adicionales.EsVerdad == false) { return; }

            //es fecha valida
            if (this.EsFechaValida() == false) { return; }

            //es fecha valida
            if (this.EsValidaFechaEncajado() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wEnc.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarEncajado();

            //modificar liberaciones al eliminar
            this.ModificarSaldosLiberacionesAlEliminar();
           
            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosProduccionesProTer();

            //adicionando nuevos ProduccionProTer
            this.AdicionarProduccionesProTer();

            //modificar liberaciones al adicionar
            this.ModificarSaldosLiberacionesAlAdicionar();
           
            //eliminar produccionExis anterior
            this.EliminarProduccionesExis();

            //adicionar produccionExis
            this.AdicionarProduccionExis();
                        
            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico el registro correctamente", this.wEnc.eTitulo);

            //actualizar al wLot          
            this.wEnc.eClaveDgvProCab = this.ObtenerClaveEncajado();
            this.wEnc.ActualizarVentana();
            
            //salir de la ventana
            this.Close();
        }

        public void ModificarEncajado()
        {
            EncajadoEN iCuoEN = new EncajadoEN();
            this.AsignarEncajado(iCuoEN);
            iCuoEN = EncajadoRN.BuscarEncajadoXClave(iCuoEN);
            this.AsignarEncajado(iCuoEN);
            EncajadoRN.ModificarEncajado(iCuoEN);
        }

        public void EliminarAntiguosProduccionesProTer()
        {
            ProduccionProTerEN iMovDetEN = new ProduccionProTerEN();
            iMovDetEN.ClaveEncajado = this.ObtenerClaveEncajado();
            ProduccionProTerRN.EliminarProduccionProTerXClaveEncajado(iMovDetEN);
        }

        public void EliminarProduccionesExis()
        {
            //asignar parametros
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveEncajado = this.ObtenerClaveEncajado();

            //ejecutar metodo
            ProduccionExisRN.EliminarProduccionExisXClaveEncajado(iProExiEN);
        }

        public void ModificarSaldosLiberacionesAlEliminar()
        {
            ProduccionProTerRN.ModificarSaldoLiberacionAlEliminar(Dgv.ObtenerValorCelda(this.wEnc.DgvProCab, EncajadoEN.ClaObj));
        }

        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wEnc.EsEncajadoExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.wEnc.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarEncajado();

            //modificar liberaciones al eliminar
            this.ModificarSaldosLiberacionesAlEliminar();

            //eliminar MovimientosDeta anterior
            this.EliminarAntiguosProduccionesProTer();

            //eliminar produccionExis anterior
            this.EliminarProduccionesExis();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino el registro correctamente", this.wEnc.eTitulo);

            //actualizar al wLot           
            this.wEnc.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarEncajado()
        {
            EncajadoEN iCuoEN = new EncajadoEN();
            this.AsignarEncajado(iCuoEN);
            EncajadoRN.EliminarEncajado(iCuoEN);
        }
     
        public EncajadoEN NuevoEncajadoDeVentana()
        {
            EncajadoEN iMovCabEN = new EncajadoEN();
            this.AsignarEncajado(iMovCabEN);
            return iMovCabEN;
        }

        public string ObtenerClaveEncajado()
        {
            EncajadoEN iMovCabEN = new EncajadoEN();
            this.AsignarEncajado(iMovCabEN);
            return iMovCabEN.ClaveEncajado;
        }

        public void AccionAgregarItem()
        {           
            //instanciar
            wDetalleEncajado win = new wDetalleEncajado();
            win.wEditEnc = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvProProTer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificarItem()
        {
            //ver si hay registro
            if (this.eLisProProTer.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que modificar", "Detalle");
                return;
            }

            wDetalleEncajado win = new wDetalleEncajado();
            win.wEditEnc = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvProProTer = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(this.eLisProProTer[Dgv.ObtenerIndiceRegistroXFranja(this.dgvProProTer)]);
        }

        public void AccionQuitarItem()
        {
            //ver si hay registro
            if (this.eLisProProTer.Count == 0)
            {
                Mensaje.OperacionDenegada("No hay registro que quitar", "Detalle");
                return;
            }

            wDetalleEncajado win = new wDetalleEncajado();
            win.wEditEnc = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvProProTer = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(this.eLisProProTer[Dgv.ObtenerIndiceRegistroXFranja(this.dgvProProTer)]);
        }

        public void OrdenarObjetos(int pAccionBoton)
        {
            int iNuevoIndice = ProduccionProTerRN.MoverObjeto(this.eLisProProTer, Dgv.ObtenerIndiceRegistroXFranja(this.dgvProProTer), pAccionBoton);
            ProduccionProTerRN.OrdenarCorrelativo(this.eLisProProTer);
            this.MostrarProduccionesProTer();
            Dgv.PosicionarFranja(this.dgvProProTer, Dgv.Franja.PorIndice, iNuevoIndice, "");
            this.HabilitarDesplazadores();
        }

        public void HabilitarDesplazadores()
        {
            Dgv.HabilitarDesplazadores(this.dgvProProTer, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
        }

        public bool EsFechaValida()
        {
            //asignar parametros
            EncajadoEN iEncEN = new EncajadoEN();
            this.AsignarEncajado(iEncEN);

            //ejecutar metodo
            iEncEN = EncajadoRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(iEncEN);

            //mostrar mensaje error
            Generico.MostrarMensajeError(iEncEN.Adicionales, this.dtpFecEnc);

            //devolver
            return iEncEN.Adicionales.EsVerdad;
        }

        public bool EsValidaFechaEncajado()
        {
            //asignar parametros
            EncajadoEN iEncEN = this.NuevoEncajadoDeVentana();

            //ejecutar metodo
            iEncEN = EncajadoRN.EsValidaFechaEncajado(iEncEN);

            //mensaje error
            Generico.MostrarMensajeError(iEncEN.Adicionales, this.dtpFecEnc);

            //devolver
            return iEncEN.Adicionales.EsVerdad;
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, this.wEnc.eTitulo);
        }
            

        #endregion
                

        private void wEditEncajado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEnc.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
     
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
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

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            this.OrdenarObjetos(0);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            this.OrdenarObjetos(1);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            this.OrdenarObjetos(2);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            this.OrdenarObjetos(3);
        }

        private void dgvProProTer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.HabilitarDesplazadores();
        }
    }
}
