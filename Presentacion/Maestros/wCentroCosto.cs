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
    public partial class wCentroCosto : Heredados.MiForm8
    {
        public wCentroCosto()
        {
            InitializeComponent();
        }

        //atributos
        string eNombreColumnaDgvCeCo = CentroCostoEN.CodCeCo;
        string eEncabezadoColumnaDgvCeCo = "Codigo";
        public string eClaveDgvCeCo = string.Empty;
        Dgv.Franja eFranjaDgvCeCo = Dgv.Franja.PorIndice;
        public List<CentroCostoEN> eLisCeCo = new List<CentroCostoEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Centro Costo";
    
        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaCentroCostosDeBaseDatos();
            this.ActualizarDgvCeCo();
            Dgv.HabilitarDesplazadores(this.DgvCeCo, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvCeCo, this.sst1);         
        }
        
        public void ActualizarDgvCeCo()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCeCo;
            List<CentroCostoEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCeCo;
            string iClaveBusqueda = eClaveDgvCeCo;
            string iColumnaPintura = eNombreColumnaDgvCeCo;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCeCo();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvCeCo()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CentroCostoEN.CodCeCo, "Codigo", 45));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CentroCostoEN.DesCeCo, "Descripcion", 276));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CentroCostoEN.NEstCeCo, "Estado", 70));           
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CentroCostoEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaCentroCostosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            CentroCostoEN iPerEN = new CentroCostoEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvCeCo;
            this.eLisCeCo = CentroCostoRN.ListarCentroCostos(iPerEN);
        }

        public List<CentroCostoEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCeCo;
            List<CentroCostoEN> iLisPer = eLisCeCo;

            //ejecutar y retornar
            return CentroCostoRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("007", DgvCeCo.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarCentroCosto(CentroCostoEN pObj)
        {
            pObj.ClaveCentroCosto = Dgv.ObtenerValorCelda(this.DgvCeCo, CentroCostoEN.ClaObj);
            pObj.CodigoCentroCosto = Dgv.ObtenerValorCelda(this.DgvCeCo, CentroCostoEN.CodCeCo);
        }
        
        public void AccionAdicionar()
        {
            wEditCentroCosto win = new wEditCentroCosto();
            win.wCenCos = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCeCo = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            CentroCostoEN iPerEN = this.EsActoModificarCentroCosto();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCentroCosto win = new wEditCentroCosto();
            win.wCenCos = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvCeCo = Dgv.Franja.PorValor;
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
            CentroCostoEN iPerEN = this.EsActoEliminarCentroCosto();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCentroCosto win = new wEditCentroCosto();
            win.wCenCos = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvCeCo = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iPerEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            CentroCostoEN iPerEN = this.EsCentroCostoExistente();
            if (iPerEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCentroCosto win = new wEditCentroCosto();
            win.wCenCos = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iPerEN);               
        }

        public CentroCostoEN EsCentroCostoExistente()
        {
            CentroCostoEN iPerEN = new CentroCostoEN();
            this.AsignarCentroCosto(iPerEN);
            iPerEN = CentroCostoRN.EsCentroCostoExistente(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public CentroCostoEN EsActoModificarCentroCosto()
        {
            CentroCostoEN iPerEN = new CentroCostoEN();
            this.AsignarCentroCosto(iPerEN);
            iPerEN = CentroCostoRN.EsActoModificarCentroCosto(iPerEN);
            if (iPerEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iPerEN.Adicionales.Mensaje, eTitulo);
            }
            return iPerEN;
        }

        public CentroCostoEN EsActoEliminarCentroCosto()
        {
            CentroCostoEN iPerEN = new CentroCostoEN();
            this.AsignarCentroCosto(iPerEN);
            iPerEN = CentroCostoRN.EsActoEliminarCentroCosto(iPerEN);
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
            //wMen.CerrarVentanaHijo(this, wMen.IteCentroCosto, null);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvCeCo = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvCeCo = this.DgvCeCo.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvCeCo = this.DgvCeCo.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCeCo, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCeCo, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
             
        private void wCentroCosto_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvCeCo = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvCeCo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvCeCo, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvCeCo, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCeCo, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCeCo, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCeCo, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCeCo, Dgv.Desplazar.Ultimo);
        }

        private void DgvCeCo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvCeCo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
