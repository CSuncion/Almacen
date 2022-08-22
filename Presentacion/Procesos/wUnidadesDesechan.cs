using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Comun;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Negocio;
using Entidades;
using Presentacion.FuncionesGenericas;
using Presentacion.Principal;

namespace Presentacion.Procesos
{
    public partial class wUnidadesDesechan : Heredados.MiForm8
    {
        public wUnidadesDesechan()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        public string eTitulo = "Cantidad";
        List<ProduccionProTerEN> eLisProProTer = new List<ProduccionProTerEN>();

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
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();
            
            //deshabilitar propietario
            //this.wParTra.Enabled = false;

            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana(ProduccionDetaEN pObj)
        {
            //actualizar a eOperacion al ingresar a la ventana
            this.ActualizareOperacion(pObj);

            //segun eOperacion
            switch (this.eOperacion)
            {
                case Universal.Opera.Modificar: { this.VentanaModificar(pObj); break; }
                case Universal.Opera.Visualizar: { this.VentanaVisualizar(pObj); break; }
                default: break;
            }            
        }

        public void VentanaModificar(ProduccionDetaEN pObj)
        {
            this.InicializaVentana();         
            this.LLenarProduccionProTerDeBaseDatos(pObj);
            this.MostrarProduccionProTer();          
            eMas.AccionHabilitarControles(1);
            this.btnAceptar.Focus();
        }

        public void VentanaVisualizar(ProduccionDetaEN pObj)
        {
            this.InicializaVentana();         
            this.LLenarProduccionProTerDeBaseDatos(pObj);
            this.MostrarProduccionProTerSoloLectura();
            eMas.AccionHabilitarControles(3);
            this.btnCancelar.Focus();
        }

        public void ActualizareOperacion(ProduccionDetaEN pObj)
        {
            if (pObj.ClaveIngresoMovimientoCabe == string.Empty)
            {
                this.eOperacion = Universal.Opera.Modificar;
            }
            else
            {
                this.eOperacion = Universal.Opera.Visualizar;
            }
        }
        
        public void MostrarProduccionProTer()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvProTer;
            List<ProduccionProTerEN> iFuenteDatos = ListaG.Refrescar<ProduccionProTerEN>(this.eLisProProTer);
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCom();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);

            //pintamos las dos columnas digitables            
            Dgv.PintarSoloColumna(iGrilla, ProduccionProTerEN.UniDesEmp);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCom()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.CodExi, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.DesExi, "Descripcion", 180));            
            iLisRes.Add(Dgv.NuevaColumnaTextNumericoEditable(ProduccionProTerEN.UniDesEmp, "#.Uni.Desechas", 100, 0));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void MostrarProduccionProTerSoloLectura()
        {
            //asignar parametros
            DataGridView iGrilla = this.dgvProTer;
            List<ProduccionProTerEN> iFuenteDatos = ListaG.Refrescar<ProduccionProTerEN>(this.eLisProProTer);
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvComSoloLectura();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);            
        }

        public List<DataGridViewColumn> ListarColumnasDgvComSoloLectura()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.CodExi, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.DesExi, "Descripcion", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(ProduccionProTerEN.UniDesEmp, "#.Uni.Desechas", 100, 0));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void LLenarProduccionProTerDeBaseDatos(ProduccionDetaEN pObj)
        {
            ProduccionProTerEN iProProTerEN = new ProduccionProTerEN();
            iProProTerEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iProProTerEN.Adicionales.CampoOrden = ProduccionProTerEN.CorProProTer;
            this.eLisProProTer = ProduccionProTerRN.ListarProduccionProTerXProduccionDetaYConNumeroCajas(iProProTerEN);
        }
        
        public void Aceptar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }
            
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }
      
            //modificar las ProduccionProTer
            this.ModificarProduccionProTer();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se modifico la cantidad", this.eTitulo);

            //cerrar esta ventana         
            this.Close();
        }
        
        public void ModificarProduccionProTer()
        {
            //asignar parametros
            List<ProduccionProTerEN> iLisProProTer = this.eLisProProTer;

            //ejecutar metodo
            ProduccionProTerRN.ModificarProduccionProTer(iLisProProTer);
        }
        
        public void ValidarFormatoDecimal(DataGridViewCellValidatingEventArgs pE, string pNombreColumna, string pEncabezadoColumna)
        {
            //asignar parametros
            int iIndiceColumna = this.dgvProTer.Columns[pNombreColumna].Index;
            string iEncabezadoColumna = pEncabezadoColumna;
            DataGridViewCellValidatingEventArgs iE = pE;

            //ejecutar metodo
            ValidarCeldaDgv.vNumerosDecimalesPositivos(iIndiceColumna, iEncabezadoColumna, iE);
        }
        
        #endregion

        private void wUnidadesDesechan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wParTra.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProTer_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            this.ValidarFormatoDecimal(e, ProduccionProTerEN.UniDesEmp, "#.Uni.Desechas");
        }

        private void dgvProTer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvProTer.BeginEdit(true);
        }

        private void dgvProTer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {   
            Dgv.EditarEnCeldaDeFilaSeleccionada(this.dgvProTer, e.ColumnIndex);
        }

    }
}
