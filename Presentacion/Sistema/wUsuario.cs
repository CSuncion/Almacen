using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heredados;
using WinControles;
using WinControles.ControlesWindows;
using Entidades.Adicionales;
using Comun;
using Entidades;
using Negocio;
using Presentacion.Principal;
using System.Collections;

namespace Presentacion.Sistema
{
    public partial class wUsuario : Heredados.MiForm8
    {
        public wUsuario()
        {
            InitializeComponent();
        }

        //atributos
        string eNombreColumnaDgvUsu = UsuarioEN.CodUsu;
        string eEncabezadoColumnaDgvUsu = "Usuario";
        public string eClaveDgvUsu = string.Empty;        
        Dgv.Franja eFranjaDgvUsu = Dgv.Franja.PorIndice;
        public List<UsuarioEN> eLisUsu = new List<UsuarioEN>();

        #region General


        public void NuevaVentana()
        {           
            this.Show();         
            this.ActualizarVentana();          
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaUsuariosDeBaseDatos();
            this.ActualizarDgvUsu();
            Dgv.HabilitarDesplazadores(this.DgvUsu, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvUsu, this.sst1);
        }
        
        public void ActualizarDgvUsu()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvUsu;
            List<UsuarioEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvUsu;
            string iClaveBusqueda = eClaveDgvUsu;
            string iColumnaPintura = eNombreColumnaDgvUsu;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvEmp();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvEmp()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(UsuarioEN.CodUsu, "Usuario", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(UsuarioEN.NomUsu, "Nombres", 260));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(UsuarioEN.NomPer, "Perfil", 140));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(UsuarioEN.NEstUsu, "Estado", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(UsuarioEN.DirUsu, "Direccion", 280));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(UsuarioEN.CorUsu, "Correo", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(UsuarioEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaUsuariosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty) { return; }

            //ir a la bd
            UsuarioEN iUsuEN = new UsuarioEN();
            iUsuEN.Adicionales.CampoOrden = eNombreColumnaDgvUsu;
            this.eLisUsu = UsuarioRN.ListarUsuarios(iUsuEN);
        }

        public List<UsuarioEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvUsu;
            List<UsuarioEN> iListaUsuarios = eLisUsu;

            //ejecutar y retornar
            return UsuarioRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaUsuarios);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("003", DgvUsu.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1,iTs2, iLisPer);
        }
       
        public void AsignarUsuario(UsuarioEN pUsu)
        {
            pUsu.CodigoUsuario = Dgv.ObtenerValorCelda(this.DgvUsu, UsuarioEN.CodUsu);
        }
        
        public void AccionAdicionar()
        {
            wEditUsuario win = new wEditUsuario();
            win.wUsu = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvUsu = Dgv.Franja.PorValor;          
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            UsuarioEN iUsuEN = this.EsUsuarioExistente();
            if (iUsuEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditUsuario win = new wEditUsuario();
            win.wUsu = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvUsu = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iUsuEN);            
        }

        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            if (tsbModificar.Enabled == false)
            {
                Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            }
            else
            {
                this.AccionModificar();
            }
        }

        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            UsuarioEN iUsuEN = this.EsEliminableUsuario();
            if (iUsuEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditUsuario win = new wEditUsuario();
            win.wUsu = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvUsu = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iUsuEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            UsuarioEN iUsuEN = this.EsUsuarioExistente();
            if (iUsuEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditUsuario win = new wEditUsuario();
            win.wUsu = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iUsuEN);    
        }
        
        public void AsignarEmpresas()
        {
            //preguntar si el registro seleccionado existe
            UsuarioEN iUsuEN = this.EsActoAsignarEmpresas();
            if (iUsuEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wAsignarEmpresas win = new wAsignarEmpresas();
            win.wUsu = this;            
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iUsuEN);
        }

        public void AsignarPermisos()
        {
            //preguntar si el registro seleccionado existe
            UsuarioEN iUsuEN = this.EsActoAsignarPermisos();
            if (iUsuEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wAsignarPermisosUsuario win = new wAsignarPermisosUsuario();
            win.wUsu = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iUsuEN);
        }

        public void AsignarAlmacenes()
        {
            //preguntar si el registro seleccionado existe
            UsuarioEN iUsuEN = this.EsActoAsignarAlmacenes();
            if (iUsuEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wAsignarAlmacenes win = new wAsignarAlmacenes();
            win.wUsu = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iUsuEN);
        }

        public void CopiarPermisos()
        {
            //preguntar si el registro seleccionado existe
            UsuarioEN iUsuEN = this.EsActoAsignarPermisos();
            if (iUsuEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wCopiarPermiso win = new wCopiarPermiso();
            win.wUsu = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iUsuEN);
        }

        public UsuarioEN EsUsuarioExistente()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsUsuarioExistente(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
            }
            return iUsuEN;
        }

        public UsuarioEN EsEliminableUsuario()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsEliminableUsuario(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
            }
            return iUsuEN;
        }

        public UsuarioEN EsActoAsignarEmpresas()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsActoModificarPermisosEmpresa(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
            }
            return iUsuEN;
        }

        public UsuarioEN EsActoAsignarPermisos()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsActoModificarPermisosUsuario(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
            }
            return iUsuEN;
        }

        public UsuarioEN EsActoAsignarAlmacenes()
        {
            UsuarioEN iUsuEN = new UsuarioEN();
            this.AsignarUsuario(iUsuEN);
            iUsuEN = UsuarioRN.EsActoModificarPermisosAlmacen(iUsuEN);
            if (iUsuEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iUsuEN.Adicionales.Mensaje, "Usuario");
            }
            return iUsuEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteUsuarios, null);      
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvUsu = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvUsu = this.DgvUsu.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvUsu = this.DgvUsu.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsu, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsu, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        this.ActualizarVentana();
                        break;
                    }
            }
        }

        #endregion


     
        private void wUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvUsu = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvUsu_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvUsu, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvUsu, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsu, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsu, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsu, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvUsu, Dgv.Desplazar.Ultimo);
        }

        private void DgvUsu_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void tsbAsignarEmpresas_Click(object sender, EventArgs e)
        {
            this.AsignarEmpresas();
        }

        private void tsbAsignarPermisos_Click(object sender, EventArgs e)
        {
            this.AsignarPermisos();
        }

        private void DgvUsu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            this.AccionModificar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminar();
        }

        private void tsbVisualizar_Click(object sender, EventArgs e)
        {
            this.AccionVisualizar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbAsiAlm_Click(object sender, EventArgs e)
        {
            this.AsignarAlmacenes();
        }

        private void tsbCopPer_Click(object sender, EventArgs e)
        {
            this.CopiarPermisos();
        }
    }
}
