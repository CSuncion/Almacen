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
using Entidades;
using Negocio;
using Entidades.Adicionales;
using Comun;
using Presentacion.Principal;
using System.Collections;
using Presentacion.ModuloMaestros;


namespace Presentacion.Maestros
{
    public partial class wBancos : Heredados.MiForm4
    {
        public wBancos()
        {
            InitializeComponent();
        }
      

        //Atributos
        string eNombreColumnaDgvBco = BancoEN.CodBco;
        string eEncabezadoColumnaDgvBco = "Codigo";
        public string eClaveDgvBco = string.Empty;
        Dgv.Franja eFranjaDgvBco = Dgv.Franja.PorIndice;
        public List<BancoEN> eLisBco = new List<BancoEN>();

        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.ActualizarVentana();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaBancosDeBaseDatos();
            this.ActualizarDgvBco();
            Dgv.HabilitarDesplazadores(this.DgvBco, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvBco, this.sst1);
           
        }

        public void ActualizarDgvBco()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvBco;
            List<BancoEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvBco;
            string iClaveBusqueda = eClaveDgvBco;
            string iColumnaPintura = eNombreColumnaDgvBco;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvBco();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvBco()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(BancoEN.CodBco, "Codigo", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(BancoEN.NomBco, "Nombre", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(BancoEN.CodSun, "CodigoSunat", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(BancoEN.NEstBco, "Estado", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(BancoEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaBancosDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty) { return; }

            //ir a la bd
            BancoEN iBcoEN = new BancoEN();
            iBcoEN.Adicionales.CampoOrden = eNombreColumnaDgvBco;
            this.eLisBco = BancoRN.ListarBancos(iBcoEN);
        }

        public List<BancoEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvBco;
            List<BancoEN> iListaBancos = eLisBco;

            //ejecutar y retornar
            return BancoRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaBancos);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            int iNumeroRegistrosGrilla = this.DgvBco.Rows.Count;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("001", iNumeroRegistrosGrilla);
          
            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iLisPer);
        }

        public void AsignarBanco(BancoEN pBco)
        {
            pBco.CodigoBanco = Dgv.ObtenerValorCelda(this.DgvBco, BancoEN.ClaObj);
        }

        public void AccionAdicionar()
        {
            wEditBancos win = new wEditBancos();
            win.wBco = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvBco = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            BancoEN iBcoEN = this.EsBancoExistente();
            if (iBcoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditBancos win = new wEditBancos();
            win.wBco = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvBco = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iBcoEN);

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
            BancoEN iBcoEN = this.EsActoEliminarBanco();
            if (iBcoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditBancos win = new wEditBancos();
            win.wBco = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvBco = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iBcoEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            BancoEN iBcoEN = this.EsBancoExistente();
            if (iBcoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditBancos win = new wEditBancos();
            win.wBco = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iBcoEN);
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteBancos, null);
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvBco = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvBco = this.DgvBco.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvBco = this.DgvBco.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBco, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBco, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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

        public BancoEN EsBancoExistente()
        {
            BancoEN iBcoEN = new BancoEN();
            this.AsignarBanco(iBcoEN);
            iBcoEN = BancoRN.EsBancoExistente(iBcoEN);
            if (iBcoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iBcoEN.Adicionales.Mensaje, "Banco");
            }
            return iBcoEN;
        }

        public BancoEN EsActoEliminarBanco()
        {
            BancoEN iBcoEN = new BancoEN();
            this.AsignarBanco(iBcoEN);
            iBcoEN = BancoRN.EsActoEliminarBanco(iBcoEN);
            if (iBcoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iBcoEN.Adicionales.Mensaje, "Banco");
            }
            return iBcoEN;
        }

        #endregion

        
        private void wProyecto_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvBco = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvBco_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvBco, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvBco, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBco, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBco, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBco, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvBco, Dgv.Desplazar.Ultimo);
        }

        private void DgvBco_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvBco_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }


    }
}
