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
    public partial class wAuxiliar : Heredados.MiForm8
    {
        public wAuxiliar()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvAux = AuxiliarEN.CodAux;
        string eEncabezadoColumnaDgvAux = "Codigo";
        public string eClaveDgvAux = string.Empty;
        Dgv.Franja eFranjaDgvAux = Dgv.Franja.PorIndice;
        public List<AuxiliarEN> eLisPer = new List<AuxiliarEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Auxiliar";

        #endregion
        
        #region General


        public void NuevaVentana()
        {
            this.Show();       
            this.ActualizarVentana();          
        }
        
        public void ActualizarVentana()
        {
            this.ActualizarListaAuxiliaresDeBaseDatos();
            this.ActualizarDgvAux();
            Dgv.HabilitarDesplazadores(this.DgvAux, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvAux, this.sst1);         
        }
        
        public void ActualizarDgvAux()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvAux;
            List<AuxiliarEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvAux;
            string iClaveBusqueda = eClaveDgvAux;
            string iColumnaPintura = eNombreColumnaDgvAux;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvAux();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }
        
        public List<DataGridViewColumn> ListarColumnasDgvAux()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CodAux, "Codigo", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.DesAux, "Nombre", 276));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.DirAux, "Direccion", 256));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.TelAux, "Telefono", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CelAux, "Celular", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.CorAux, "Email", 90));
            //iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.RefAux, "Referencia", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.NTipAux, "Tipo", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.NEstAux, "Estado", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(AuxiliarEN.ClaObj, "Clave", 90, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaAuxiliaresDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            AuxiliarEN iPerEN = new AuxiliarEN();
            iPerEN.Adicionales.CampoOrden = eNombreColumnaDgvAux;
            this.eLisPer = AuxiliarRN.ListarAuxiliares(iPerEN);
        }

        public List<AuxiliarEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvAux;
            List<AuxiliarEN> iLisPer = eLisPer;

            //ejecutar y retornar
            return AuxiliarRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iLisPer);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("009", DgvAux.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }
             
        public void AsignarAuxiliar(AuxiliarEN pObj)
        {
            pObj.CodigoAuxiliar = Dgv.ObtenerValorCelda(this.DgvAux, AuxiliarEN.CodAux);
        }
        
        public void AccionAdicionar()
        {
            wEditAuxiliar win = new wEditAuxiliar();
            win.wAux = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvAux = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }
        
        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            AuxiliarEN iAuxEN = this.EsActoModificarAuxiliar();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditAuxiliar win = new wEditAuxiliar();
            win.wAux = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvAux = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iAuxEN);            
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
            AuxiliarEN iAuxEN = this.EsActoEliminarAuxiliar();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditAuxiliar win = new wEditAuxiliar();
            win.wAux = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvAux = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iAuxEN);    
        }
        
        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            AuxiliarEN iAuxEN = this.EsAuxiliarExistente();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditAuxiliar win = new wEditAuxiliar();
            win.wAux = this;
            win.eOperacion = Universal.Opera.Visualizar;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iAuxEN);               
        }

        public AuxiliarEN EsAuxiliarExistente()
        {
            AuxiliarEN iAuxEN = new AuxiliarEN();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = AuxiliarRN.EsAuxiliarExistente(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public AuxiliarEN EsActoModificarAuxiliar()
        {
            AuxiliarEN iAuxEN = new AuxiliarEN();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = AuxiliarRN.EsActoModificarAuxiliar(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public AuxiliarEN EsActoEliminarAuxiliar()
        {
            AuxiliarEN iAuxEN = new AuxiliarEN();
            this.AsignarAuxiliar(iAuxEN);
            iAuxEN = AuxiliarRN.EsActoEliminarAuxiliar(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, eTitulo);
            }
            return iAuxEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteAuxiliares, wMen.tsbAuxiliares);        
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvAux = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvAux = this.DgvAux.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvAux = this.DgvAux.Columns[pColumna].HeaderText;
            this.ActualizarVentana();     
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {

                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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
             
        private void wAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvAux = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvAux_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvAux, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvAux, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvAux, Dgv.Desplazar.Ultimo);
        }

        private void DgvAux_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvAux_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
