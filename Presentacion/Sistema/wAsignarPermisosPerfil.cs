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
using Entidades;
using Negocio;


namespace Presentacion.Sistema
{
    public partial class wAsignarPermisosPerfil : Heredados.MiForm8
    {
        public wAsignarPermisosPerfil()
        {
            InitializeComponent();
        }

        //variables     
        Masivo eMas = new Masivo();
        List<PermisoPerfilEN> eLisPerPer = new List<PermisoPerfilEN>();
        
        #region Propietario

        public wPerfil wPer;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPer, this.btnAceptar , "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMarcarTodas, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnDesmarcarTodas, "vvvv");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnAceptar, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnSalir, "vvvv");
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
         
            //Deshabilitar al propietario de esta ventana
            this.wPer.Enabled = false;

            //Mostrar ventana
            this.Show();            
        }

        public void ValoresXDefecto(PerfilEN pObj)
        {
            this.txtCodPer.Text = pObj.CodigoPerfil;
            this.txtPer.Text = pObj.CodigoPerfil + " : " + pObj.NombrePerfil;
        }

        public void NuevaVentana(PerfilEN pObj)
        {
            this.InicializaVentana();
            this.ValoresXDefecto(pObj);
            this.ActualizarVentana();
            this.btnAceptar.Focus();
        }

        public void MostrarTituloPermisos()
        {
            this.lblTitPer.Text = "Botones de la Ventana : " + Dgv.ObtenerValorCelda(this.DgvVen, VentanaEN.NomVen);
        }

        public void ActualizarVentana()
        {           
            this.ActualizarDgvVen();
            this.MostrarTituloPermisos();
            this.ActualizarDgvPer(true);
        }

        public void ActualizarDgvVen()
        {
            VentanaEN iVenEN = new VentanaEN();         
            iVenEN.Adicionales.CampoOrden = VentanaEN.CodVen;
            List<VentanaEN> iLisVen = VentanaRN.ListarVentanas(iVenEN);

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvVen;
            iDgv.RefrescarDatosGrilla(iLisVen);

            //asignar columnas 
            iDgv.AsignarColumnaTextCadena(VentanaEN.NomVen, "Ventana", 320);         
            iDgv.AsignarColumnaTextCadena(VentanaEN.CodVen, "CodigoVentana", 10, false);
        }
        
        public void ActualizarDgvPer(bool pBaseDatos)
        {
            PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
            iPerPerEN.CodigoPerfil = this.txtCodPer.Text.Trim();            
            iPerPerEN.CodigoVentana = Dgv.ObtenerValorCelda(this.DgvVen, PermisoPerfilEN.CodVen);
            iPerPerEN.Adicionales.CampoOrden = PermisoPerfilEN.CodBot;
            if (pBaseDatos == true)
            {
                this.eLisPerPer = PermisoPerfilRN.ListarPermisosPerfilDeVentana(iPerPerEN);
            }            

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvPer;
            iDgv.RefrescarDatosGrilla(this.eLisPerPer);

            //asignar columnas
            iDgv.AsignarColumnaCheckBox(PermisoPerfilEN.VerFal, "Permitir", 60);
            iDgv.AsignarColumnaTextCadena(PermisoPerfilEN.NomBot, "Boton", 260);
            iDgv.AsignarColumnaTextCadena(PermisoPerfilEN.ClaPerPer, "ClaveObjeto", 10, false);
        }
                        
        public void Aceptar()
        {
            this.ModificarPermisosPerfil();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Permisos modificados", "Asignar Permisos");        
        }

        public void ModificarPermisoPerfil(int pFilaChequeada, int pColumnaChequeada)
        {
              //solo debe actuar cuando la columna sea "0" y la fila diferente de "-1"
            if (pColumnaChequeada == 0 && pFilaChequeada != -1)
            {
                PermisoPerfilEN iPerPerEN = new PermisoPerfilEN();
                iPerPerEN.ClavePermisoPerfil = Dgv.ObtenerValorCelda(this.DgvPer, PermisoPerfilEN.ClaPerPer);
                iPerPerEN.VerdadFalso = !this.eLisPerPer[pFilaChequeada].VerdadFalso;
                PermisoPerfilRN.ModificarPermisoPerfil(iPerPerEN, this.eLisPerPer);        
            }            
        }

        public void ModificarPermisosPerfil()
        {
            PermisoPerfilRN.ModificarPermisoPerfilMasivo(this.eLisPerPer);        
        }

        public void MarcarTodos()
        {
            PermisoPerfilRN.MarcarTodos(this.eLisPerPer, true);
            this.ActualizarDgvPer(false);
        }

        public void DesmarcarTodos()
        {
            PermisoPerfilRN.MarcarTodos(this.eLisPerPer, false);
            this.ActualizarDgvPer(false);
        }

        #endregion

        private void wAsignarPermisosPerfil_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPer.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void cmbMod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.ActualizarVentana();
        }

        private void cmbMod_DropDownClosed(object sender, EventArgs e)
        {
            this.ActualizarVentana();
        }

        private void DgvVen_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.MostrarTituloPermisos();
            this.ActualizarDgvPer(true);
        }

        private void btnMarcarTodas_Click(object sender, EventArgs e)
        {
            this.MarcarTodos();
        }

        private void btnDesmarcarTodas_Click(object sender, EventArgs e)
        {
            this.DesmarcarTodos();
        }

        private void DgvPer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarPermisoPerfil(e.RowIndex, e.ColumnIndex);
        }

        private void DgvPer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarPermisoPerfil(e.RowIndex, e.ColumnIndex);
        }

       

                
    }
}
