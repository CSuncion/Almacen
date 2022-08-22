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
using Entidades;
using Negocio;


namespace Presentacion.Procesos
{
    public partial class wAgregarParteFaseEmpaquetado : Heredados.MiForm8
    {
        public wAgregarParteFaseEmpaquetado()
        {
            InitializeComponent();
        }

        #region Variables

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<ProduccionExisEN> eLisProExi = new List<ProduccionExisEN>();
        
        #endregion
        
        #region Propietario

        public wEditSalidaParteFaseEmpaquetado wEdiSalParFasEmp;

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
         
            // Deshabilitar al propietario de esta ventana
            this.wEdiSalParFasEmp.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }                

        public void VentanaAgregar()
        {
            this.InicializaVentana();
            this.Text = "Agregar Items";
            this.lblTit.Text = "Items para agregar a la ventana";         
            this.ActualizarDgvSol(true);
            this.btnAceptar.Focus();
        }

        public void ActualizarDgvSol(bool pBaseDatos)
        {
            //solo si va a base de datos entra
            if (pBaseDatos == true)
            {
                eLisProExi = this.ListarProduccionExiParaMarcar();
            }
            
            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvBot;
            iDgv.RefrescarDatosGrilla(eLisProExi);
            //asignar columnas
            iDgv.AsignarColumnaCheckBox(ProduccionExisEN.VerFal, "Agregar", 57);
            iDgv.AsignarColumnaTextCadena(ProduccionExisEN.CodExi, "Codigo", 70);            
            iDgv.AsignarColumnaTextCadena(ProduccionExisEN.DesExi, "Descripcion", 220);
            iDgv.AsignarColumnaTextNumerico(ProduccionExisEN.CanProExi, "Cantidad", 90, 3);
            iDgv.AsignarColumnaTextCadena(ProduccionExisEN.ClaObj, "ClaveObjeto", 10, false);
        }

        public List<ProduccionExisEN> ListarProduccionExiParaMarcar()
        {
            //asignar parametros
            string pClaveProduccionProTer = Dgv.ObtenerValorCelda(this.wEdiSalParFasEmp.wSalParFasEmp.wProTerFasEmp.DgvProProTer,
                ProduccionProTerEN.ClaObj);

            //ejecutar metodo
            return ProduccionExisRN.ListarProduccionExisParaAgregarParteFaseEmpaquetado(pClaveProduccionProTer, this.wEdiSalParFasEmp.eLisMovDet);
        }

        public void ModificarProduccionExis()
        {
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionExis = Dgv.ObtenerValorCelda(this.DgvBot, ProduccionExisEN.ClaObj);
            iProExiEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvBot, ProduccionCabeEN.VerFal);
            ProduccionExisRN.ModificarProduccionExis(iProExiEN, this.eLisProExi);
        }
        
        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Agregar(); break; }                
                default: break;
            }
        }

        public void Agregar()
        { 
            //sacar solo los que marco el usuario
            List<ProduccionExisEN> iLisObjMar = this.SacarSoloMarcados();                    

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Items") == false) { return; }

            //convertir a movimientos deta
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.TransformarAMovimientosDeta(iLisObjMar, 
                this.wEdiSalParFasEmp.NuevoMovimientoCabeDeVentana());

            //agregar a la lista del propietario
            this.wEdiSalParFasEmp.eLisMovDet.AddRange(iLisMovDet);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agrego el(los) item(s)", "Item");

            //actualizar ventana propietario
            this.wEdiSalParFasEmp.MostrarMovimientosDeta();
            
            //cerrar
            this.Close();
        }             
    
        public void MarcarTodos()
        {
            ProduccionExisRN.MarcarTodos(this.eLisProExi, true);
            this.ActualizarDgvSol(false);
        }

        public void DesmarcarTodos()
        {
            ProduccionExisRN.MarcarTodos(this.eLisProExi, false);
            this.ActualizarDgvSol(false);
        }

        public List<ProduccionExisEN> SacarSoloMarcados()
        {
            //esta operacion actualiza a la lista eLisVenBot,obteniendo solo
            //los objetos marcados por el usuario
            return ProduccionExisRN.ListarVentanaProduccionExisSoloMarcadas(this.eLisProExi);
        }

        public bool HayMarcados(List<ProduccionExisEN> pLista)
        {
           //ver si hay marcados
            if (pLista.Count == 0)
            {
                Mensaje.OperacionDenegada("Debes marcar al menos un item, no se puede realizar la operacion","Items");
                return false;
            }
            return true;           
        }
     
        #endregion

        private void wAgregarParteFaseEmpaquetado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wEdiSalParFasEmp.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvBot_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarProduccionExis();
        }

        private void btnMarcarTodas_Click(object sender, EventArgs e)
        {
            this.MarcarTodos();
        }

        private void btnDesmarcarTodas_Click(object sender, EventArgs e)
        {
            this.DesmarcarTodos();
        }
    }
}
