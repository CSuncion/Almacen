﻿using System;
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
using Presentacion.Maestros;
using Heredados.VentanasPersonalizadas;
using System.Reflection;
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;

namespace Presentacion.Procesos
{
    public partial class wSegundaLiberacion : Heredados.MiForm8
    {
        public wSegundaLiberacion()
        {
            InitializeComponent();
        }

        #region Atributos

        string eNombreColumnaDgvProProTer = ProduccionProTerEN.CodExi;
        string eEncabezadoColumnaDgvProProTer = "Codigo";
        public string eClaveDgvProProTer = string.Empty;
        Dgv.Franja eFranjaDgvProProTer = Dgv.Franja.PorIndice;
        public List<ProduccionProTerEN> eLisProProTer = new List<ProduccionProTerEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "ProduccionProTer";

        #endregion
       
        #region Propietario

        public wPlanEncajado wPlaEnc;

        #endregion

        #region General


        public void NuevaVentana()
        {
            this.wPlaEnc.Enabled = false;
            this.Show();
            this.ActualizarVentana();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaProduccionProTersDeBaseDatos();
            this.ActualizarDgvProProTer();
            Dgv.HabilitarDesplazadores(this.DgvProProTer, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();    
            Dgv.ActualizarBarraEstado(this.DgvProProTer, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvProProTer;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvProProTer()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvProProTer;
            List<ProduccionProTerEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvProProTer;
            string iClaveBusqueda = eClaveDgvProProTer;
            string iColumnaPintura = eNombreColumnaDgvProProTer;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvProProTer();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvProProTer()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.CodExi, "Codigo", 75));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.DesExi, "Descripcion", 170));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.NEleSegLib, "Eleccion", 170));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.ClaSalEtiSegLib, "Salida.Etiqueta", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.ClaIngSemProSegLib, "Ingreso.Unidades", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.DetCanSemPro, "DetalleCampo", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ProduccionProTerEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaProduccionProTersDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            ProduccionProTerEN iLibEN = new ProduccionProTerEN();
            iLibEN.ClaveEncajado = Dgv.ObtenerValorCelda(this.wPlaEnc.DgvProCab, ProduccionDetaEN.ClaObj);            
            iLibEN.Adicionales.CampoOrden = eNombreColumnaDgvProProTer;
            this.eLisProProTer = ProduccionProTerRN.ListarProduccionProTerXClaveEncajado(iLibEN);
        }

        public List<ProduccionProTerEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvProProTer;
            List<ProduccionProTerEN> iListaProduccionProTers = eLisProProTer;

            //ejecutar y retornar
            return ProduccionProTerRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaProduccionProTers);
        }

        public void HabilitarAcciones()
        {
           
        }

        public void AsignarProduccionProTer(ProduccionProTerEN pIng)
        {
            pIng.ClaveProduccionProTer = Dgv.ObtenerValorCelda(this.DgvProProTer, ProduccionProTerEN.ClaObj);         
        }

        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            //preguntar si este usuario tiene acceso a la accion modificar
            //basta con ver si el boton modificar esta habilitado o no
            if (tsbEleccionSegLib.Enabled == false)
            {
                Mensaje.OperacionDenegada("Tu usuario no tiene permiso para modificar este registro", "Modificar");
            }
            else
            {
                this.AccionEleccionSegundaLiberacion();
            }
        }
      
        public ProduccionProTerEN EsProduccionProTerExistente()
        {
            ProduccionProTerEN iCuoEN = new ProduccionProTerEN();
            this.AsignarProduccionProTer(iCuoEN);
            iCuoEN = ProduccionProTerRN.EsProduccionProTerExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public void AccionEleccionSegundaLiberacion()
        {
            //preguntar si el registro seleccionado existe
            ProduccionProTerEN iIngEN = this.EsActoEleccionSegundaLiberacion();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEleccionSegundaLiberacion win = new wEleccionSegundaLiberacion();
            win.wSegLib = this;            
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iIngEN);
        }

        public void AccionSalidaEtiquetasSegundaLiberacion()
        {
            //preguntar si el registro seleccionado existe
            ProduccionProTerEN iIngEN = this.EsActoSalidaEtiquetasSegundaLiberacion();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wSalidaEtiquetaSegundaLiberacion win = new wSalidaEtiquetaSegundaLiberacion();
            win.wSegLib = this;            
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iIngEN);
        }

        public void AccionIngresoUnidadesSegundaLiberacion()
        {
            //preguntar si el registro seleccionado existe
            ProduccionProTerEN iIngEN = this.EsActoIngresoUnidadesSegundaLiberacion();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wIngresoUnidadesSegundaLiberacion win = new wIngresoUnidadesSegundaLiberacion();
            win.wSegLib = this;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iIngEN);
        }

        public ProduccionProTerEN EsActoEleccionSegundaLiberacion()
        {
            ProduccionProTerEN iCuoEN = new ProduccionProTerEN();
            this.AsignarProduccionProTer(iCuoEN);
            iCuoEN = ProduccionProTerRN.EsActoEleccionSegundaLiberacion(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public ProduccionProTerEN EsActoSalidaEtiquetasSegundaLiberacion()
        {
            ProduccionProTerEN iCuoEN = new ProduccionProTerEN();
            this.AsignarProduccionProTer(iCuoEN);
            iCuoEN = ProduccionProTerRN.EsActoSalidaEtiquetasSegundaLiberacion(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public ProduccionProTerEN EsActoIngresoUnidadesSegundaLiberacion()
        {
            ProduccionProTerEN iCuoEN = new ProduccionProTerEN();
            this.AsignarProduccionProTer(iCuoEN);
            iCuoEN = ProduccionProTerRN.EsActoIngresoUnidadesSegundaLiberacion(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvProProTer = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvProProTer = this.DgvProProTer.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvProProTer = this.DgvProProTer.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProProTer, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProProTer, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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

        
        private void wSegundaLiberacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wPlaEnc.Enabled = true;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvProProTer = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvProProTer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvProProTer, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvProProTer, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProProTer, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProProTer, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProProTer, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvProProTer, Dgv.Desplazar.Ultimo);
        }

        private void DgvProProTer_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvProProTer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void tsbEleccionSegLib_Click(object sender, EventArgs e)
        {
            this.AccionEleccionSegundaLiberacion();
        }

        private void tsbSalidaEtiquetaSegLib_Click(object sender, EventArgs e)
        {
            this.AccionSalidaEtiquetasSegundaLiberacion();
        }

        private void tsbIngresoUnidadesSegLib_Click(object sender, EventArgs e)
        {
            this.AccionIngresoUnidadesSegundaLiberacion();
        }
    }
}
