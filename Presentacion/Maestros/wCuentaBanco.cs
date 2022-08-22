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
    public partial class wCuentaBanco : Heredados.MiForm4
    {
        public wCuentaBanco()
        {
            InitializeComponent();
        }

        //Atributos
        string eNombreColumnaDgvCta = CuentaBancoEN.CodCtaBco;
        string eEncabezadoColumnaDgvCta = "Codigo";
        public string eClaveDgvCta = string.Empty;
        Dgv.Franja eFranjaDgvCta = Dgv.Franja.PorIndice;
        public List<CuentaBancoEN> eLisCta = new List<CuentaBancoEN>();

        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.ActualizarVentana();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaCuentaBancoDeBaseDatos();
            this.ActualizarDgvCta();
            Dgv.HabilitarDesplazadores(this.DgvCta, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvCta, this.sst1);
           
        }

        public void ActualizarDgvCta()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvCta;
            List<CuentaBancoEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvCta;
            string iClaveBusqueda = eClaveDgvCta;
            string iColumnaPintura = eNombreColumnaDgvCta;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvCta();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvCta()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.CodCtaBco, "Codigo", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.AgeCtaBco, "Agencia", 240));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.NomBco, "Nombre", 240));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.CtaCon, "Contable", 120));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.NEstCtaBco, "Estado", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(CuentaBancoEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaCuentaBancoDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty) { return; }

            //ir a la bd
            CuentaBancoEN iCtaEN = new CuentaBancoEN();
            iCtaEN.Adicionales.CampoOrden = eNombreColumnaDgvCta;
            this.eLisCta = CuentaBancoRN.ListarCuentaBancoXEmpresa(iCtaEN);
        }

        public List<CuentaBancoEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvCta;
            List<CuentaBancoEN> iListaCuentaBanco = eLisCta;

            //ejecutar y retornar
            return CuentaBancoRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaCuentaBanco);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            int iNumeroRegistrosGrilla = this.DgvCta.Rows.Count;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("001", iNumeroRegistrosGrilla);
          
            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iLisPer);
        }

        public void AsignarCuentaBanco(CuentaBancoEN pCta)
        {
            pCta.ClaveCuentaBanco = Dgv.ObtenerValorCelda(this.DgvCta, CuentaBancoEN.ClaObj);
            pCta.CodigoCuentaBanco = Dgv.ObtenerValorCelda(this.DgvCta, CuentaBancoEN.CodCtaBco);
        }

        public void AccionAdicionar()
        {
            wEditCuentaBanco win = new wEditCuentaBanco();
            win.wCtaBco = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvCta = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            CuentaBancoEN iCtaEN = this.EsCuentaBancoExistente();
            if (iCtaEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCuentaBanco win = new wEditCuentaBanco();
            win.wCtaBco = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvCta = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iCtaEN);
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
            CuentaBancoEN iCtaEN = this.EsActoEliminarCuentaBanco();
            if (iCtaEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCuentaBanco win = new wEditCuentaBanco();
            win.wCtaBco = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvCta = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iCtaEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            CuentaBancoEN iCtaEN = this.EsCuentaBancoExistente();
            if (iCtaEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditCuentaBanco win = new wEditCuentaBanco();
            win.wCtaBco = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCtaEN);
        }

        public CuentaBancoEN EsCuentaBancoExistente()
        {
            CuentaBancoEN iCtaEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iCtaEN);
            iCtaEN = CuentaBancoRN.EsCuentaBancoExistente(iCtaEN);
            if (iCtaEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCtaEN.Adicionales.Mensaje, "Cuenta Bancaria");
            }
            return iCtaEN;
        }

        public CuentaBancoEN EsActoEliminarCuentaBanco()
        {
            CuentaBancoEN iCtaEN = new CuentaBancoEN();
            this.AsignarCuentaBanco(iCtaEN);
            iCtaEN = CuentaBancoRN.EsActoEliminarCuentaBanco(iCtaEN);
            if (iCtaEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCtaEN.Adicionales.Mensaje, "Cuenta Bancaria");
            }
            return iCtaEN;
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteCuentaBancos, null);
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvCta = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvCta = this.DgvCta.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvCta = this.DgvCta.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCta, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCta, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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


        private void wCuentaBanco_FormClosing(object sender, FormClosingEventArgs e)
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
            this.eFranjaDgvCta = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvCta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvCta, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvCta, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCta, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCta, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCta, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvCta, Dgv.Desplazar.Ultimo);
        }

        private void DgvCta_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvCta_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }


    }
}
