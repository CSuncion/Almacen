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
using Entidades.Adicionales;
using Entidades;
using Negocio;
using Entidades.Estructuras;
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;
using Presentacion.FuncionesGenericas;

namespace Presentacion.Procesos
{
    public partial class wElegirParaTransferir : Heredados.MiForm8
    {
        public wElegirParaTransferir()
        {
            InitializeComponent();
        }

        #region Variables

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<ProduccionDetaEN> eLisProDet = new List<ProduccionDetaEN>();
        
        #endregion
        
        #region Propietario

        //public wParteTrabajo wParTra;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;                                  

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
            //this.wParTra.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }                

        public void VentanaAgregar()
        {
            this.InicializaVentana();     
            this.ActualizarDgvParTra();
            this.btnAceptar.Focus();
        }

        public void ActualizarDgvParTra()
        {
            //segun agregar o quitar
            eLisProDet = ProduccionDetaRN.ListarProduccionDetaParaTransferirInsumos();

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvBot;
            iDgv.RefrescarDatosGrilla(eLisProDet);
            //asignar columnas
            iDgv.AsignarColumnaCheckBox(ProduccionDetaEN.VerFal, "Agregar", 57);
            iDgv.AsignarColumnaTextCadena(ProduccionDetaEN.CorProCab, "Numero", 70);
            iDgv.AsignarColumnaTextCadena(ProduccionDetaEN.FecProDet, "Fecha", 70);
            iDgv.AsignarColumnaTextCadena(ProduccionDetaEN.DesExi, "Formula", 250);
            iDgv.AsignarColumnaTextCadena(ProduccionDetaEN.NTur, "Turno", 50);
            iDgv.AsignarColumnaTextCadena(ProduccionDetaEN.ClaObj, "ClaveObjeto", 10, false);
        }

        public void ModificarProduccionDeta()
        {
            ProduccionDetaEN iProDetEN = new ProduccionDetaEN();
            iProDetEN.ClaveProduccionDeta = Dgv.ObtenerValorCelda(this.DgvBot, ProduccionDetaEN.ClaObj);
            iProDetEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvBot, ProduccionDetaEN.VerFal);
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN, this.eLisProDet);
        }
      
        public void Aceptar()
        {
            //valida cuando hay partes de trabajo que se transfirio su materia prima ,pero aun no va a la cocina
            if (this.ValidaCuandoHayMateriaPrimaSinTransferirACocina() == false) { return; }

            //valida cuando cuando las marcadas no son de la fecha mas antigua o son de diferentes fechas
            if (this.EsActoTransferirProduccionesChequeadas() == false) { return; }

            //sacar solo los que marco el usuario
            List<ProduccionDetaEN> iLisObjMar = this.SacarSoloMarcados();                    

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //listar los insumos para transferir
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosParaTransferirAProducccion(iLisObjMar);

            //validar cuando la lista esta vacia
            if (iLisInsFal.Count == 0) { Mensaje.OperacionDenegada("No hay nada para transferir", "Almacenes"); return; }

            //valida si falta stock en los almacenes de origen
            if (this.HayStockExistenciasParaTransferir(iLisInsFal) == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Transferir insumos Materias primas y envasados", "Transferir") == false) { return; }

            //generar las transferencias
            MovimientoCabeRN.GenerarTransferenciasAutomaticasAProduccion(iLisInsFal);

            //actualizar a los ProduccionDeta marcados            
            ProduccionDetaRN.ModificarPorTransferenciaAutomatica(iLisObjMar);

            //operacion satisfactoria
            Mensaje.OperacionSatisfactoria("Se realizo la transferencia al almacen de produccion", "Almacenes");

            //actualizar ventana propietario
            //this.wParTra.ActualizarVentana();

            //cerrar
            this.Close();
        }             
    
        public List<ProduccionDetaEN> SacarSoloMarcados()
        {
            //esta operacion actualiza a la lista eLisVenBot,obteniendo solo
            //los objetos marcados por el usuario
            return ProduccionDetaRN.ListarVentanaProduccionDetaSoloMarcadas(this.eLisProDet);
        }

        public bool HayMarcados(List<ProduccionDetaEN> pLista)
        {
           //ver si hay marcados
            if (pLista.Count == 0)
            {
                Mensaje.OperacionDenegada("Debes marcar al menos un Parte de Trabajo, no se puede realizar la operacion","Partes Trabajo");
                return false;
            }
            return true;           
        }

        public void GenerarExcel()
        {
            //sacar solo los que marco el usuario
            List<ProduccionDetaEN> iLisObjMar = this.SacarSoloMarcados();

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //listar los insumos para transferir
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosDetalladoParaTransferirAProducccion(iLisObjMar);

            //validar cuando la lista esta vacia
            if (iLisInsFal.Count == 0) { Mensaje.OperacionDenegada("No hay nada para transferir", "Almacenes"); return; }

            //declarar objetos de excel         
            Microsoft.Office.Interop.Excel.Application iAplicacion;
            Workbook iLibro;
            Worksheet iHoja;

            //creamos una nueva aplicacion excel
            iAplicacion = new Microsoft.Office.Interop.Excel.Application();

            //adicionamos el libro a la aplicacion
            iLibro = iAplicacion.Workbooks.Add();

            //obtener la hoja 1 del libro
            iHoja = iLibro.Worksheets["Hoja1"];

            //dando el zoom predeterminado a la hoja
            iAplicacion.ActiveWindow.Zoom = 73;

            try
            {

                //-----------------
                //llenando cabecera
                //-----------------

                iHoja.Cells.Item[1, 1] = "Transferir Para Almacen de Produccion";

                //---------------------------------------
                //obtener la cabecera del detalle reporte
                //---------------------------------------

                //armar las columnas
                List<ColumnaExcel> iListaColumnas = new List<ColumnaExcel>();
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Solicitud", 9));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Fc.Produccion", 15));               
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Linea", 7));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Almacen", 12));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Codigo", 13));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Descripcion", 45));
                iListaColumnas.Add(MiExcel.NuevaColumnaCadena("Unidad", 14));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Insumos", 14, 3));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Stock", 14, 3));
                iListaColumnas.Add(MiExcel.NuevaColumnaDecimal("C.Faltante", 14, 3));

                //objeto que armara todas las columnas en el excel
                EncabezadosExcel iEncExc = new EncabezadosExcel();
                iEncExc.Hoja = iHoja;
                iEncExc.Niveles = 1;
                iEncExc.IndiceColumnaPartida = 1;
                iEncExc.IndiceFilaPartida = 2;
                iEncExc.Color = Color.LightSteelBlue;
                iEncExc.NumeroRegistros = iLisInsFal.Count;
                iEncExc.ListaColumnas = iListaColumnas;
                MiExcel.ArmarEstructuraEncabezados(iEncExc);

                //----------------------
                //llenando datos detalle
                //----------------------

                //indice para cada fila
                int iIndiceFila = 2;

                //recorrer cada objeto
                foreach (InsumoFaltante xInsFal in iLisInsFal)
                {
                    iIndiceFila++;
                    iHoja.Cells.Item[iIndiceFila, 1] = xInsFal.CodigoSolicitud;
                    iHoja.Cells.Item[iIndiceFila, 2] = xInsFal.FechaProduccion;                   
                    iHoja.Cells.Item[iIndiceFila, 3] = xInsFal.CodigoLinea;
                    iHoja.Cells.Item[iIndiceFila, 4] = xInsFal.CodigoAlmacen;
                    iHoja.Cells.Item[iIndiceFila, 5] = xInsFal.CodigoExistencia;
                    iHoja.Cells.Item[iIndiceFila, 6] = xInsFal.DescripcionExistencia;
                    iHoja.Cells.Item[iIndiceFila, 7] = xInsFal.NUnidadMedida;
                    iHoja.Cells.Item[iIndiceFila, 8] = xInsFal.CantidadParteTrabajo;
                    iHoja.Cells.Item[iIndiceFila, 9] = xInsFal.CantidadStockExistencia;
                    iHoja.Cells.Item[iIndiceFila, 10] = xInsFal.CantidadFaltante;
                }

                //ver el excel
                iAplicacion.Application.Visible = true;

            }
            catch (Exception ex)
            {
                Mensaje.OperacionDenegada(ex.Message, "Error");
            }
            finally
            {
                //liberamos recursos
                MiExcel.LiberarObjetoCom(iAplicacion);
                MiExcel.LiberarObjetoCom(iLibro);
                MiExcel.LiberarObjetoCom(iHoja);
            }
        }

        public bool ValidaCuandoHayMateriaPrimaSinTransferirACocina()
        {
            //ejecutar metodo
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.ValidaCuandoHayMateriaPrimaSinTransferirACocina();

            //valida
            Generico.MostrarMensajeError(iProDetEN.Adicionales);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public bool EsActoTransferirProduccionesChequeadas()
        {
            //asignar parametros
            List<ProduccionDetaEN> iLisObjMar = this.SacarSoloMarcados();

            //ejecutar metodo
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.EsActoTransferirProduccionesChequeadas(iLisObjMar,this.eLisProDet);

            //valida
            Generico.MostrarMensajeError(iProDetEN.Adicionales);

            //devolver
            return iProDetEN.Adicionales.EsVerdad;
        }

        public bool HayStockExistenciasParaTransferir(List<InsumoFaltante> pLista)
        {
            //listar existencias que no completan el stock para esta parte de trabajo
            List<InsumoFaltante> iLisInsFal = ProduccionExisRN.FiltrarInsumosFaltantesConCantidadfaltanteOrigenEnNegativos(pLista);

            //si hay elementos en la lista, entonces invoca la ventana
            if (iLisInsFal.Count != 0)
            {
                //instanciar
                wInsumosFaltantesTransferir win = new wInsumosFaltantesTransferir();
                win.eVentanaPropietario = this;
                win.eLisInsFal = iLisInsFal;
                TabCtrl.InsertarVentana(this, win);
                win.NuevaVentana();

                //devolver
                return false;
            }

            //ok
            return true;
        }

        
        #endregion

        private void wElegirParaTransferir_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wParTra.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvBot_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarProduccionDeta();
        }

        private void btnExc_Click(object sender, EventArgs e)
        {
            this.GenerarExcel();
        }
    }
}
