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

namespace Presentacion.Maestros
{
    public partial class wAlmacen : Heredados.MiForm8
    {
        public wAlmacen()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvAlm = AlmacenEN.CodAlm;
        string eEncabezadoColumnaDgvPer = "Codigo";
        public string eClaveDgvAlm = string.Empty;
        Dgv.Franja eFranjaDgvAlm = Dgv.Franja.PorIndice;
        public List<AlmacenEN> eLisPer = new List<AlmacenEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Almacen";

        #endregion
        
        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaAlmacenesDeBaseDatos();
            this.ActualizarDgvAlm();
            Dgv.HabilitarDesplazadores(this.DgvAlm, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvAlm, this.sst1);         
        }
        
        public void ActualizarDgvAlm()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvAlm;
            List<AlmacenEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvAlm;
            string iClaveBusqueda = eClaveDgvAlm;
            string iColumnaPintura = eNombreColumnaDgvAlm;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAlm();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvAlm()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AlmacenEN.CodAlm, "Codigo", 55));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AlmacenEN.DesAlm, "Descripcion", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AlmacenEN.DirAlm, "Direccion", 300));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AlmacenEN.NomPer, "Personal", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AlmacenEN.NEstAlm, "Estado", 70));           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AlmacenEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaAlmacenesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            AlmacenEN iPerEN = new AlmacenEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvAlm;
            this.eLisPer = AlmacenRN.ListarAlmacenes(iPerEN);
        }

        public List<AlmacenEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvAlm;
            List<AlmacenEN> iLisPer = eLisPer;

            //ejecutar y retornar
            return AlmacenRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("010", DgvAlm.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarAlmacen(AlmacenEN pObj)
        {
            pObj.ClaveAlmacen = Dgv.ObtenerValorCelda(this.DgvAlm, AlmacenEN.ClaObj);
            pObj.CodigoAlmacen = Dgv.ObtenerValorCelda(this.DgvAlm, AlmacenEN.CodAlm);
        }
        
        public void AccionAdicionar()
        {
            wEditAlmacen win = new wEditAlmacen();
            win.wAlm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvAlm = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            AlmacenEN iPerEN = this.EsActoModificarAlmacen();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditAlmacen win = new wEditAlmacen();
            win.wAlm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvAlm = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iPerEN);            
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
            AlmacenEN iPerEN = this.EsActoEliminarAlmacen();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditAlmacen win = new wEditAlmacen();
            win.wAlm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvAlm = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            AlmacenEN iPerEN = this.EsAlmacenExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditAlmacen win = new wEditAlmacen();
            win.wAlm = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);               
        }

        public AlmacenEN EsAlmacenExistente()
        {
            AlmacenEN iPerEN = new AlmacenEN();
            this.AsignarAlmacen(iPerEN);
            iPerEN = AlmacenRN.EsAlmacenExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public AlmacenEN EsActoModificarAlmacen()
        {
            AlmacenEN iPerEN = new AlmacenEN();
            this.AsignarAlmacen(iPerEN);
            iPerEN = AlmacenRN.EsActoModificarAlmacen(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public AlmacenEN EsActoEliminarAlmacen()
        {
            AlmacenEN iPerEN = new AlmacenEN();
            this.AsignarAlmacen(iPerEN);
            iPerEN = AlmacenRN.EsActoEliminarAlmacen(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteAlmacenes, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvAlm = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvAlm = this.DgvAlm.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvPer = this.DgvAlm.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAlm, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAlm, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Left:
                case Keys.Right:
                    {
                        break;
                    }
                default:
                    {
                        if (this.tstBuscar.Text != string.Empty) { eVaBD = 0; }
                        this.ActualizarVentana();
                        eVaBD = 1;
                        break;
                    }
            }
        }

        #endregion
             
        private void wAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvAlm = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvAlm_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvAlm, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvAlm, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAlm, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAlm, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAlm, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAlm, Dgv.Desplazar.Ultimo);
        }

        private void DgvAlm_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvAlm_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
        
        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
