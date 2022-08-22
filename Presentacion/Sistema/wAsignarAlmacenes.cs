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
    public partial class wAsignarAlmacenes : Heredados.MiForm8
    {
        public wAsignarAlmacenes()
        {
            InitializeComponent();
        }

        //variables     
        Masivo eMas = new Masivo();
        List<PermisoAlmacenEN> eLisPem = new List<PermisoAlmacenEN>();
        
        #region Propietario

        public wUsuario wUsu;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtUsu, this.btnAceptar , "ffff");
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
            this.ActualizarDgvPer();
            this.btnAceptar.Focus();
        }

        public void ActualizarDgvPer()
        {
            PermisoAlmacenEN iPemEN = new PermisoAlmacenEN();
            iPemEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            iPemEN.Adicionales.CampoOrden = PermisoAlmacenEN.CodAlm;
            this.eLisPem = PermisoAlmacenRN.ListarPermisosAlmacenAbiertasXUsuario(iPemEN);

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvPer;
            iDgv.RefrescarDatosGrilla(this.eLisPem);

            //asignar columnas
            iDgv.AsignarColumnaCheckBox(PermisoAlmacenEN.VerFal , "Permitir", 60);
            iDgv.AsignarColumnaTextCadena(PermisoAlmacenEN.DesAlm, "Almacen", 130);            
            iDgv.AsignarColumnaTextCadena(PermisoAlmacenEN.NomEmp, "Empresa", 120);
            iDgv.AsignarColumnaTextCadena(PermisoAlmacenEN.ClaPerAlm, "ClaveObjeto", 10, false);
        }
                        
        public void Aceptar()
        {
            this.ModificarPermisosEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Permisos modificados", "Asignar Almacenes");
        
            //cerrar ventana
            this.Close();

        }

        public void ModificarPermisoAlmacen(int pFilaChequeada, int pColumnaChequeada)
        {
             //solo debe actuar cuando la columna sea "0" y la fila diferente de "-1"
            if (pColumnaChequeada == 0 && pFilaChequeada != -1)
            {
                PermisoAlmacenEN iPemEN = new PermisoAlmacenEN();
                iPemEN.ClavePermisoAlmacen = Dgv.ObtenerValorCelda(this.DgvPer, PermisoAlmacenEN.ClaPerAlm);
                iPemEN.VerdadFalso = !this.eLisPem[pFilaChequeada].VerdadFalso;
                PermisoAlmacenRN.ModificarPermisoAlmacen(iPemEN, this.eLisPem);        
            }            
        }

        public void ModificarPermisosEmpresa()
        {
            PermisoAlmacenRN.ModificarPermisoAlmacen(this.eLisPem);        
        }

        #endregion

        private void wAsignarPlantas_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DgvPer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarPermisoAlmacen(e.RowIndex, e.ColumnIndex);
        }

        private void DgvPer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarPermisoAlmacen(e.RowIndex, e.ColumnIndex);
        }

       
    }
}
