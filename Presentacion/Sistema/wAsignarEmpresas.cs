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
    public partial class wAsignarEmpresas : Heredados.MiForm8
    {
        public wAsignarEmpresas()
        {
            InitializeComponent();
        }

        //variables     
        Masivo eMas = new Masivo();
        List<PermisoEmpresaEN> eLisPem = new List<PermisoEmpresaEN>();
        
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
            PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
            iPemEN.CodigoUsuario = this.txtCodUsu.Text.Trim();
            iPemEN.Adicionales.CampoOrden = PermisoEmpresaEN.CodEmp;
            this.eLisPem = PermisoEmpresaRN.ListarPermisosEmpresaAbiertasXUsuario(iPemEN);

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvPer;
            iDgv.RefrescarDatosGrilla(this.eLisPem);

            //asignar columnas
            iDgv.AsignarColumnaCheckBox(PermisoEmpresaEN.VerFal , "Permitir", 60);
            iDgv.AsignarColumnaTextCadena(PermisoEmpresaEN.NomEmp, "Empresa", 245);            
            iDgv.AsignarColumnaTextCadena(PermisoEmpresaEN.ClaPerEmp, "ClaveObjeto", 10, false);
        }
                        
        public void Aceptar()
        {
            this.ModificarPermisosEmpresa();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Permisos modificados", "Asignar Empresas");
        
            //cerrar ventana
            this.Close();

        }

        public void ModificarPermisoEmpresa(int pFilaChequeada, int pColumnaChequeada)
        {
             //solo debe actuar cuando la columna sea "0" y la fila diferente de "-1"
            if (pColumnaChequeada == 0 && pFilaChequeada != -1)
            {
                PermisoEmpresaEN iPemEN = new PermisoEmpresaEN();
                iPemEN.ClavePermisoEmpresa = Dgv.ObtenerValorCelda(this.DgvPer, PermisoEmpresaEN.ClaPerEmp);
                iPemEN.VerdadFalso = !this.eLisPem[pFilaChequeada].VerdadFalso;
                PermisoEmpresaRN.ModificarPermisoEmpresa(iPemEN, this.eLisPem);        
            }            
        }

        public void ModificarPermisosEmpresa()
        {
            PermisoEmpresaRN.ModificarPermisoEmpresaMasivo(this.eLisPem);        
        }
                
        #endregion

        private void wAsignarEmpresas_FormClosing(object sender, FormClosingEventArgs e)
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
            this.ModificarPermisoEmpresa(e.RowIndex, e.ColumnIndex);
        }

        private void DgvPer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarPermisoEmpresa(e.RowIndex, e.ColumnIndex);
        }
       
    }
}
