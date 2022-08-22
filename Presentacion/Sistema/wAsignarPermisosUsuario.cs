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
    public partial class wAsignarPermisosUsuario : Heredados.MiForm8
    {
        public wAsignarPermisosUsuario()
        {
            InitializeComponent();
        }

        //variables     
        Masivo eMas = new Masivo();
        List<PermisoUsuarioEN> eLisPerUsu = new List<PermisoUsuarioEN>();

        #region Propietario

        public wUsuario wUsu;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUsu, this.btnAceptar, "ffff");
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

            // Deshabilitar al propietario de esta ventana
            this.wUsu.Enabled = false;

            // Mostrar ventana
            this.Show();
        }

        public void ValoresXDefecto(UsuarioEN pObj)
        {
            this.txtCodUsu.Text = pObj.CodigoUsuario;
            this.txtUsu.Text = pObj.CodigoUsuario + " : " + pObj.NombreUsuario;
        }

        public void NuevaVentana(UsuarioEN pObj)
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
            PermisoUsuarioEN iPemEN = new PermisoUsuarioEN();
            iPemEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            iPemEN.CodigoVentana = Dgv.ObtenerValorCelda(this.DgvVen, PermisoUsuarioEN.CodVen);
            iPemEN.Adicionales.CampoOrden = PermisoUsuarioEN.CodBot;
            if (pBaseDatos == true)
            {
                this.eLisPerUsu = PermisoUsuarioRN.ListarPermisosUsuarioDeVentana(iPemEN);
            }

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvPer;
            iDgv.RefrescarDatosGrilla(this.eLisPerUsu);

            //asignar columnas
            iDgv.AsignarColumnaCheckBox(PermisoUsuarioEN.VerFal, "Permitir", 60);
            iDgv.AsignarColumnaTextCadena(PermisoUsuarioEN.NomBot, "Boton", 260);
            iDgv.AsignarColumnaTextCadena(PermisoUsuarioEN.ClaPerUsu, "ClaveObjeto", 10, false);
        }

        public void Aceptar()
        {
            this.ModificarPermisosUsuario();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Permisos modificados", "Asignar Permisos");
        }

        public void ModificarPermisoUsuario(int pFilaChequeada, int pColumnaChequeada)
        {
             //solo debe actuar cuando la columna sea "0" y la fila diferente de "-1"
            if (pColumnaChequeada == 0 && pFilaChequeada != -1)
            {
                //aqui si cambiar check
                PermisoUsuarioEN iPerUsuEN = new PermisoUsuarioEN();
                iPerUsuEN.ClavePermisoUsuario = Dgv.ObtenerValorCelda(this.DgvPer, PermisoUsuarioEN.ClaPerUsu);
                iPerUsuEN.VerdadFalso = !this.eLisPerUsu[pFilaChequeada].VerdadFalso;               
                PermisoUsuarioRN.ModificarPermisoUsuario(iPerUsuEN, this.eLisPerUsu);
            }            
        }

        public void ModificarPermisosUsuario()
        {
            PermisoUsuarioRN.ModificarPermisoUsuarioMasivo(this.eLisPerUsu);
        }

        public void MarcarTodos()
        {
            PermisoUsuarioRN.MarcarTodos(this.eLisPerUsu, true);
            this.ActualizarDgvPer(false);
        }

        public void DesmarcarTodos()
        {
            PermisoUsuarioRN.MarcarTodos(this.eLisPerUsu, false);
            this.ActualizarDgvPer(false);
        }

        #endregion

        private void wAsignarPermisosUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wUsu.Enabled = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.ModificarPermisoUsuario(e.RowIndex,e.ColumnIndex);
        }

        private void DgvPer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarPermisoUsuario(e.RowIndex, e.ColumnIndex);
        }




    }
}
