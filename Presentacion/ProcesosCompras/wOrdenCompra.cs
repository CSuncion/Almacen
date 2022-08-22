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
using Presentacion.Maestros;
using Heredados.VentanasPersonalizadas;
using System.Reflection;
using Presentacion.FuncionesGenericas;
using Presentacion.Impresiones;
using System.IO;

namespace Presentacion.ProcesosCompras
{
    public partial class wOrdenCompra : Heredados.MiForm8
    {
        public wOrdenCompra()
        {
            InitializeComponent();
        }

        //Atributos
        string eNombreColumnaDgvMovCab = MovimientoOCCabeEN.NumMovCab;
        string eEncabezadoColumnaDgvMovCab = "Numero";
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<MovimientoOCCabeEN> eLisMovCab = new List<MovimientoOCCabeEN>();
        public List<MovimientoOCDetaEN> eLisMovDet = new List<MovimientoOCDetaEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Orden de Compra";
        string iNuevoNumero = string.Empty;
        string iCorrelativo = "0000";
        public List<LoteEN> eLisLot = new List<LoteEN>();

        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.MostrarPersistencia();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaMovimientoCabesDeBaseDatos();
            this.ActualizarDgvMovCab();
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            this.HabilitarAcciones();
            Dgv.ActualizarBarraEstado(this.DgvMovCab, this.sst1);
            this.AccionBuscar();
        }

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvMovCab;
            this.tstBuscar.Focus();
        }

        public void ActualizarDgvMovCab()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvMovCab;
            List<MovimientoOCCabeEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvMovCab;
            string iClaveBusqueda = eClaveDgvMovCab;
            string iColumnaPintura = eNombreColumnaDgvMovCab;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMovCab();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);
            this.BloquearCeldaOrdenCompraEnviadas(iGrilla, iFuenteDatos);
        }

        public List<DataGridViewColumn> ListarColumnasDgvMovCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaCheckBox(MovimientoOCCabeEN.FlagEnvMov, "Correo", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NumMovCab, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.FecMovCab, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.PerMovCab, "Periodo", 62));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.CodTipOpe, "T.O", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesTipOpe, "Descripción T.O", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesAlm, "Almacen", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesAux, "Proveedor", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(MovimientoOCCabeEN.CosFleMovCab, "Flete", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NomPer, "Personal", 160));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.GloMovCab, "Glosa", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NOriVenCre, "Origen", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NEstMovCab, "Estado", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NCodMon, "Moneda", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.ClaSolCabPed, "Sol. Pedido", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaMovimientoCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            iCuoEN.PeriodoMovimientoCabe = lblPeriodo.Text;
            iCuoEN.CClaseTipoOperacion = "3";//orden de compra
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvMovCab;
            this.eLisMovCab = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodoYClaseOperacion(iCuoEN);
        }

        public List<MovimientoOCCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvMovCab;
            List<MovimientoOCCabeEN> iListaMovimientoCabes = eLisMovCab;

            //ejecutar y retornar
            return MovimientoOCCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaMovimientoCabes);
        }

        public void HabilitarAcciones()
        {
            //asignar parametros
            ToolStrip iTs1 = tsPrincipal;
            ToolStrip iTs2 = tsSecundario;
            Hashtable iLisPer = PermisoUsuarioRN.ListarPermisosParaVentana("013", DgvMovCab.Rows.Count);

            //ejecutar metodo
            Tst.HabilitarItems(iTs1, iTs2, iLisPer);
        }

        public void AsignarMovimientoCabe(MovimientoOCCabeEN pIng)
        {
            pIng.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoOCCabeEN.ClaObj);
            pIng.PeriodoMovimientoCabe = lblPeriodo.Text;
            pIng.COrigenVentanaCreacion = "1";//ingreso      
        }

        public void AccionAdicionar()
        {
            //validar
            MovimientoOCCabeEN iIngEN = this.EsActoAdicionarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //instanciar
            wEditOrdenCompra win = new wEditOrdenCompra();
            win.wOrdCom = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iIngEN = this.EsActoModificarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }


            if (iIngEN.CEstadoMovimientoCabe == "3")
            {
                Mensaje.OperacionDenegada("La orden de compra ya fue enviada, no se puede modificar.", eTitulo);
                return;
            }

            //si existe
            wEditOrdenCompra win = new wEditOrdenCompra();
            win.wOrdCom = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iIngEN);
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
            MovimientoOCCabeEN iCuoEN = this.EsActoEliminarMovimientoCabe();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            if (iCuoEN.CEstadoMovimientoCabe == "3")
            {
                Mensaje.OperacionDenegada("La orden de compra ya fue enviada, no se puede modificar.", eTitulo);
                return;
            }

            //si existe
            wEditOrdenCompra win = new wEditOrdenCompra();
            win.wOrdCom = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iCuoEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iCuoEN = this.EsMovimientoCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditOrdenCompra win = new wEditOrdenCompra();
            win.wOrdCom = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }

        public void AccionImportarExcel()
        {
            //instanciar
            //wImportarMovimientosIngresos win = new wImportarMovimientosIngresos();
            //win.wIng = this;
            //TabCtrl.InsertarVentana(this, win);
            //win.NuevaVentana();
        }

        public void AccionEliminarImportarExcel()
        {
            //validar
            MovimientoOCCabeEN iMovCabEN = this.EsActoEliminarImportacionMovimientoCabes();
            if (iMovCabEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar importacion") == false) { return; }

            //eliminar copia
            MovimientoOCCabeRN.EliminarAntesDeImportarIngreso(this.lblPeriodo.Text);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la importacion", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionImprimirNota()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iSalEN = this.EsMovimientoCabeExistente();
            if (iSalEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            //wImpNotaIngreso win = new wImpNotaIngreso();
            //win.wIng = this;
            //win.eVentana = wImpNotaIngreso.Ventana.wOrdenCompra;
            //win.NuevaVentana(iSalEN);
        }

        public void AccionSeleccionarPeriodo()
        {
            vSeleccionarPeriodo win = new vSeleccionarPeriodo();
            win.eVentanaInvoca = this;
            win.eControlDevuelveValor = lblPeriodo;
            win.ePeriodoActual = lblPeriodo.Text;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public MovimientoOCCabeEN EsMovimientoCabeExistente()
        {
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iCuoEN);
            iCuoEN = MovimientoOCCabeRN.EsMovimientoCabeExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public MovimientoOCCabeEN EsActoAdicionarMovimientoCabe()
        {
            MovimientoOCCabeEN iIngEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoOCCabeRN.EsActoAdicionarMovimientoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }

            return iIngEN;
        }

        public MovimientoOCCabeEN EsActoModificarMovimientoCabe()
        {
            MovimientoOCCabeEN iIngEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoOCCabeRN.EsActoModificarMovimientoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public MovimientoOCCabeEN EsActoEliminarMovimientoCabe()
        {
            MovimientoOCCabeEN iIngEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoOCCabeRN.EsActoEliminarMovimientoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public MovimientoOCCabeEN EsActoEliminarImportacionMovimientoCabes()
        {
            MovimientoOCCabeEN iIngEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoOCCabeRN.EsActoEliminarImportacionMovimientoCabeIngreso(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public void AccionCambiaPeriodo()
        {
            //poner la descripcion del mes
            lblDescripcionPeriodo.Text = AñoMes.ObtenerDescripcionPeriodo(lblPeriodo.Text);

            //MessageBox.Show(lblDescripcionPeriodo.Text);

            //guardar el nuevo periodo
            Properties.Settings.Default.GuardarPeriodoIngresos = TsL.ModificarValor(Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa, lblPeriodo);
            Properties.Settings.Default.Save();

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void MostrarPersistencia()
        {
            TsL.MostrarValor(lblPeriodo, Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa);
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.iteOrdenCompra, null);
        }

        public void OrdenarPorColumna(int pColumna)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.eNombreColumnaDgvMovCab = this.DgvMovCab.Columns[pColumna].Name;
            this.eEncabezadoColumnaDgvMovCab = this.DgvMovCab.Columns[pColumna].HeaderText;
            this.ActualizarVentana();
        }

        public void ActualizarVentanaAlBuscarValor(KeyEventArgs pE)
        {
            //verificar que tecla pulso el usuario
            switch (pE.KeyCode)
            {
                case Keys.Up:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, WinControles.ControlesWindows.Dgv.Desplazar.Anterior);
                        Txt.CursorAlUltimo(this.tstBuscar); break;
                    }
                case Keys.Down:
                    {
                        Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, WinControles.ControlesWindows.Dgv.Desplazar.Siguiente);
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


        public void Enviar()
        {
            //validar envio
            if (this.EsValidoEnvio() == false) { return; }

            //validar si todas las marcadas tienen correo
            if (this.EsValidaMarcadasConCorreoElectronico() == false) { return; }


            if (this.EsValidaOrdenCompraDetaMonto() == false) { return; }

            //validar que existan todos los pds de las cuotas selecionadas
            if (this.ExistenArchivosExcel() == false) { return; }

            //validar que las orden de compra no hayan sido enviadas
            if (this.EsValidaOrdenCompraEnviada() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            wEnviarOrdenCompra win = new wEnviarOrdenCompra();
            win.wOrdCom = this;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaProgressBar(this.eLisMovCab);
        }

        public bool EsValidoEnvio()
        {
            //valida la grilla vacia
            if (DgvMovCab.Rows.Count == 0)
            {
                Mensaje.OperacionDenegada("no hay registros en la grilla", eTitulo);
                return false;
            }

            //validar cuotas marcadas
            List<int> iLisMar = this.listaSolicitudesEnviadas();
            if (iLisMar.Count == 0)
            {
                Mensaje.OperacionDenegada("Al menos debes chequear un registro", eTitulo);
                return false;
            }

            //ok
            return true;
        }

        public List<int> listaSolicitudesEnviadas()
        {
            List<int> cuentaCheck = new List<int>();
            int cuenta = 0;
            for (int i = 0; i < this.eLisMovCab.Count; i++)
            {
                if (Convert.ToBoolean(this.eLisMovCab[i].VerdadFalso))
                {
                    cuentaCheck.Add(cuenta++);
                }
            }
            return cuentaCheck;
        }

        public bool EsValidaMarcadasConCorreoElectronico()
        {
            //recorrer cada registro
            for (int n = 0; n <= this.eLisMovCab.Count - 1; n++)
            {
                //preguntar si esta chequeado
                bool iValor = Convert.ToBoolean(this.eLisMovCab[n].VerdadFalso);
                if (iValor == true)
                {
                    string iCorreo = this.eLisMovCab[n].CorreoAuxiliar.ToString().Trim();
                    if (iCorreo == string.Empty)
                    {
                        Mensaje.OperacionDenegada("Hay propietarios que no tienen correo electronico", "Contrato");
                        return false;
                    }
                }
            }

            //ok          
            return true;
        }
        public bool ExistenArchivosExcel()
        {
            //obtener a las cuotas marcadas
            List<MovimientoOCCabeEN> iLisMovCab = this.eLisMovCab;

            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //obtener la ruta de la carpeta para el periodo elegido
            string iRutaCarpetaPeriodo = iParEN.RutaCarpetaPlantillas; //wGenerarRecibos.ObtenerRutaCarpetaPeriodo(txtAno.Text, Cmb.ObtenerValor(cmbMes, ""));

            //recorrer cada objeto cuota
            foreach (MovimientoOCCabeEN xMov in iLisMovCab)
            {
                string fileName = "OrdenCompra_" + xMov.ClaveMovimientoCabe + ".xlsx";
                //armar la ruta de su archivo
                //string iRutaArchivo = "RutaArchivo";  
                //wGenerarRecibos.ObtenerNuevaRutaPDF(xCuo, iRutaCarpetaPeriodo);

                string destFile = System.IO.Path.Combine(iRutaCarpetaPeriodo, fileName);
                bool iValor = Convert.ToBoolean(xMov.VerdadFalso);
                if (iValor == true)
                {
                    //ver si existe este archivo
                    if (File.Exists(destFile) == false)
                    {
                        Mensaje.OperacionDenegada("El(los) archivo(s) no existe(n)", "Excel");
                        return false;
                    }
                }

            }

            //ok
            return true;
        }

        public bool EsValidaOrdenCompraEnviada()
        {
            //recorrer cada registro
            for (int n = 0; n <= this.eLisMovCab.Count - 1; n++)
            {
                //preguntar si esta chequeado
                bool iValor = Convert.ToBoolean(this.eLisMovCab[n].VerdadFalso);
                if (iValor)
                {
                    string estadoSolicitud = this.eLisMovCab[n].CEstadoMovimientoCabe.ToString();
                    if (estadoSolicitud == "3")
                    {
                        Mensaje.OperacionDenegada("Hay orden de compra que han sido enviadas.", "Contrato");
                        return false;
                    }
                }
            }

            //ok          
            return true;
        }

        public bool EsValidaOrdenCompraDetaMonto()
        {
            //recorrer cada registro
            for (int n = 0; n <= this.eLisMovCab.Count - 1; n++)
            {
                bool iValor = Convert.ToBoolean(this.eLisMovCab[n].VerdadFalso);
                if (iValor)
                {
                    MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
                    iMovDetEN.ClaveMovimientoCabe = this.eLisMovCab[n].ClaveMovimientoCabe;
                    iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

                    this.eLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);

                    decimal precio = 0;
                    this.eLisMovDet.ForEach((x) =>
                    {
                        if (x.CantidadPendiente > 0)
                        {
                            precio += x.PrecioUnitarioMovimientoDeta;
                        }
                    });

                    if (precio == 0)
                    {
                        Mensaje.OperacionDenegada("Hay ordenes de compra que no se han actualizado su precio en el detalle.", "Contrato");
                        return false;
                    }
                }
            }
            return true;
        }

        public void BloquearCeldaOrdenCompraEnviadas(DataGridView iGrilla, List<MovimientoOCCabeEN> FuenteDatos)
        {
            int n = 0;
            foreach (MovimientoOCCabeEN movCab in FuenteDatos)
            {
                if (movCab.FlagEnviadoMovimientoCabe)
                {
                    if (iGrilla[MovimientoOCCabeEN.NumMovCab, n].Value.ToString() == movCab.NumeroMovimientoCabe.ToString())
                    {
                        iGrilla[MovimientoOCCabeEN.FlagEnvMov, n].ReadOnly = true;
                    }
                }
                n++;
            }
            this.DgvMovCab = iGrilla;
        }

        public void AsignarOrdenCompraEnviar(int pFilaChequeada, int pColumnaChequeada)
        {
            //solo debe actuar cuando la columna sea "0" y la fila diferente de "-1"
            if (pColumnaChequeada == 0 && pFilaChequeada != -1)
            {
                MovimientoOCCabeEN iMovEN = new MovimientoOCCabeEN();
                iMovEN.NumeroMovimientoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoOCCabeEN.NumMovCab);
                iMovEN.VerdadFalso = !this.eLisMovCab[pFilaChequeada].VerdadFalso;
                MovimientoOCCabeRN.AsignarOrdenCompraEnviada(iMovEN, this.eLisMovCab);
            }
        }

        public void GenerarMovimiento()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iIngEN = this.EsActoModificarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            if (iIngEN.CEstadoMovimientoCabe == "4")
            {
                Mensaje.OperacionSatisfactoria("La orden de compra ya fue cerrada, verifica el estado", this.eTitulo);
                return;
            }

            this.MostrarNuevoNumero(iIngEN);

            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iCuoEN);

            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = iIngEN.ClaveMovimientoCabe;
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

            this.eLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);

            decimal pendiente = 0;
            this.eLisMovDet.ForEach((x) =>
            {
                if (x.CantidadPendiente > 0)
                {
                    pendiente += x.CantidadPendiente;
                }
            });

            if (pendiente > 0)
            {
                if (Mensaje.DeseasRealizarOperacion("Hay pendientes por llegar en la orden de compra.", "Orden de compra") == false) { return; }
            }

            string cantidadVarios = string.Empty;
            this.eLisMovDet.ForEach((x) =>
            {
                if (x.CantidadRecibidaVarios != "")
                {
                    cantidadVarios = x.CantidadRecibidaVarios;
                }
            });

            if (cantidadVarios == "")
            {
                Mensaje.OperacionDenegada("No ha ingresado movimiento, no se puede generar el ingreso.", "Orden de compra"); return;
            }

            MovimientoCabeRN.AdicionarMovimientoCabe(iCuoEN);

            iCorrelativo = "0000";
            foreach (MovimientoOCDetaEN objSD in this.eLisMovDet)
            {
                string[] cantidadRecibida = objSD.CantidadRecibidaVarios.TrimEnd(';').Split(';');
                foreach (var can in cantidadRecibida)
                {
                    objSD.CantidadRecibida = Convert.ToDecimal(can);
                    this.AdicionarMovimientosDeta(iIngEN, objSD);
                }
                objSD.ClaveMovimientoICabe = iCuoEN.ClaveMovimientoCabe;
                MovimientoOCDetaRN.ActualizarCantidadRecibidayClaveMovimientoDeta(objSD);
            }

            LoteEN iLotEN = new LoteEN();
            iLotEN.ClaveMovimientoCabe = iIngEN.ClaveMovimientoCabe;
            iLotEN.Adicionales.CampoOrden = LoteEN.CodExi + "," + LoteEN.CodLot;

            //ejecutar metodo
            this.eLisLot = LoteRN.ListarLotesDeClaveMovimientoCabe(iLotEN);
            List<LoteEN> eLote = new List<LoteEN>();

            //recorrer cada objeto
            foreach (LoteEN xLot in this.eLisLot)
            {
                //actualizar con la claveSolicitudPedidoCabe
                LoteEN iObjLot = new LoteEN();
                xLot.CodigoLote = "";
                this.AsignarLote(iObjLot, xLot);
                xLot.ClaveMovimientoCabe = iCuoEN.ClaveMovimientoCabe;
                xLot.CodigoLote = LoteRN.ObtenerNuevoCodigoLoteAutogenerado(iObjLot, eLote);

                this.AsignarLote(iObjLot, xLot);
                xLot.ClaveLote = iObjLot.ClaveLote;
                eLote.Add(xLot);
            }

            LoteRN.AdicionarLote(this.eLisLot);


            ExistenciaEN xObjE = new ExistenciaEN();

            List<ExistenciaEN> eListEx = ExistenciaRN.ListarExistencias();

            foreach (MovimientoOCDetaEN movDeta in this.eLisMovDet)
            {
                xObjE = new ExistenciaEN();
                xObjE.CodigoExistencia = movDeta.CodigoExistencia;
                xObjE.StockActualExistencia = eListEx.Find(x => x.CodigoExistencia == movDeta.CodigoExistencia).StockActualExistencia + movDeta.CantidadRecibida;
                xObjE.PrecioPromedioExistencia = movDeta.PrecioUnitarioMovimientoDeta;
                xObjE.PrecioUltimaCompra = movDeta.PrecioUnitarioMovimientoDeta;
                xObjE.FechaUltimaCompra = Fecha.ObtenerAnoMesDia(DateTime.Now);
                ExistenciaRN.ModificarStockYPrecioDeExistenciaXCodigo(xObjE);
            }


            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se generó el movimiento correctamente", this.eTitulo);


        }

        public void MostrarNuevoNumero(MovimientoOCCabeEN iIngEN)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana(iIngEN);

            //obtener el nuevo numero
            iNuevoNumero = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
        }
        public MovimientoCabeEN NuevoMovimientoCabeDeVentana(MovimientoOCCabeEN iIngEN)
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iMovCabEN);
            return iMovCabEN;
        }

        public void AsignarMovimientoCabe(MovimientoOCCabeEN iIngEN, MovimientoCabeEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCab.PeriodoMovimientoCabe = iIngEN.PeriodoMovimientoCabe;
            pMovCab.NumeroMovimientoCabe = iNuevoNumero;
            pMovCab.FechaMovimientoCabe = Fecha.ObtenerAnoMesDia(DateTime.Now);
            pMovCab.CodigoTipoOperacion = "02";
            pMovCab.DescripcionTipoOperacion = "COMPRAS NACIONAL";
            pMovCab.CodigoAlmacen = iIngEN.CodigoAlmacen;
            pMovCab.DescripcionAlmacen = iIngEN.DescripcionAlmacen;
            pMovCab.CodigoPersonal = iIngEN.CodigoPersonal;
            pMovCab.CodigoPersonalAutoriza = iIngEN.CodigoPersonalAutoriza;
            pMovCab.CodigoPersonalRecibe = string.Empty;
            pMovCab.CostoFleteMovimientoCabe = iIngEN.CostoFleteMovimientoCabe;
            pMovCab.CCodigoMoneda = iIngEN.CCodigoMoneda;
            pMovCab.TipoCambio = iIngEN.TipoCambio;
            pMovCab.CodigoAuxiliar = iIngEN.CodigoAuxiliar;
            pMovCab.DescripcionAuxiliar = iIngEN.DescripcionAuxiliar;
            pMovCab.OrdenCompra = string.Empty;
            pMovCab.CTipoDocumento = string.Empty;
            pMovCab.SerieDocumento = string.Empty;
            pMovCab.NumeroDocumento = string.Empty;
            pMovCab.FechaDocumento = Fecha.ObtenerAnoMesDia(DateTime.Now);
            pMovCab.GlosaMovimientoCabe = iIngEN.GlosaMovimientoCabe;
            pMovCab.COrigenVentanaCreacion = "7";//orden de compra          
            pMovCab.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }
        public void AdicionarMovimientosDeta(MovimientoOCCabeEN iIngEN, MovimientoOCDetaEN iMovDeta)
        {
            MovimientoDetaEN xMovDet = new MovimientoDetaEN();
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe(iIngEN);

            //incrementar el correlativo
            iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

            //actualizar algunos datos antes de grabar
            xMovDet.CodigoEmpresa = iMovDeta.CodigoEmpresa;
            xMovDet.NombreEmpresa = iMovDeta.NombreEmpresa;
            xMovDet.PeriodoMovimientoCabe = iMovDeta.PeriodoMovimientoCabe;
            xMovDet.CodigoAlmacen = iMovDeta.CodigoAlmacen;
            xMovDet.DescripcionAlmacen = iMovDeta.DescripcionAlmacen;
            xMovDet.CodigoTipoOperacion = "02";
            xMovDet.DescripcionTipoOperacion = "COMPRAS NACIONAL";
            xMovDet.CClaseTipoOperacion = "1";
            xMovDet.CodigoAuxiliar = iMovDeta.CodigoAuxiliar;
            xMovDet.DescripcionAuxiliar = iMovDeta.DescripcionAuxiliar;
            xMovDet.CodigoCentroCosto = iMovDeta.CodigoCentroCosto;
            xMovDet.DescripcionCentroCosto = iMovDeta.DescripcionCentroCosto;
            xMovDet.CodigoExistencia = iMovDeta.CodigoExistencia;
            xMovDet.DescripcionExistencia = iMovDeta.DescripcionExistencia;
            xMovDet.CodigoTipo = iMovDeta.CodigoTipo;
            xMovDet.NombreTipo = iMovDeta.NombreTipo;
            xMovDet.CEsLote = iMovDeta.CEsLote;
            xMovDet.CCodigoArea = string.Empty;
            xMovDet.CCodigoPartida = iMovDeta.CCodigoPartida;
            xMovDet.NCodigoPartida = iMovDeta.NCodigoPartida;
            xMovDet.GlosaMovimientoDeta = iMovDeta.GlosaMovimientoDeta;
            xMovDet.FechaMovimientoCabe = iMovDeta.FechaMovimientoCabe;
            xMovDet.CostoFleteMovimientoDeta = iMovDeta.CostoFleteMovimientoDeta;
            xMovDet.FactorConversion = 0;
            xMovDet.CodigoUnidadMedida = iMovDeta.CodigoUnidadMedida;
            xMovDet.NombreUnidadMedida = iMovDeta.NombreUnidadMedida;
            xMovDet.CantidadMovimientoDeta = iMovDeta.CantidadRecibida;
            xMovDet.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerCosto(xMovDet);
            xMovDet.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(xMovDet);
            xMovDet.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);
            xMovDet.NumeroMovimientoCabe = iMovDeta.NumeroMovimientoCabe;
            xMovDet.ClaveMovimientoCabe = iClaveMovimientoCabe;
            xMovDet.CorrelativoMovimientoDeta = iCorrelativo;
            xMovDet.CostoFleteMovimientoCabe = iMovDeta.CostoFleteMovimientoCabe;
            xMovDet.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(xMovDet);
            xMovDet.CCodigoMoneda = iMovDeta.CCodigoMoneda;
            xMovDet.TipoCambio = iMovDeta.TipoCambio;

            //adicion masiva
            MovimientoDetaRN.AdicionarMovimientoDeta(xMovDet);
        }

        public string ObtenerClaveMovimientoCabe(MovimientoOCCabeEN iIngEN)
        {
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public void AsignarLote(LoteEN pObj, LoteEN objLote)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoAlmacen = objLote.CodigoAlmacen;
            pObj.CodigoExistencia = objLote.CodigoExistencia;
            pObj.DescripcionExistencia = objLote.DescripcionExistencia;
            pObj.CodigoLote = objLote.CodigoLote;
            pObj.FechaVencimientoLote = objLote.FechaVencimientoLote;
            pObj.NumeroLote = objLote.NumeroLote;
            pObj.FechaProduccionLote = objLote.FechaProduccionLote;
            pObj.StockConversionLote = objLote.StockConversionLote;
            pObj.StockLote = objLote.StockLote;
            pObj.StockSaldoLote = pObj.StockLote;
            pObj.ClaveLote = LoteRN.ObtenerClaveLote(pObj);
        }

        public void CerrarOrdenCompra()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iIngEN = this.EsActoModificarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }


            if (!iIngEN.FlagEnviadoMovimientoCabe)
            {
                Mensaje.OperacionSatisfactoria("No se puede cerrar la orden de compra, verifica el estado", this.eTitulo);
                return;
            }


            if (iIngEN.CEstadoMovimientoCabe == "4")
            {
                Mensaje.OperacionSatisfactoria("La orden de compra ya fue cerrada, verifica el estado", this.eTitulo);
                return;
            }

            this.MostrarNuevoNumero(iIngEN);

            MovimientoCabeEN iCuoEN = new MovimientoCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iCuoEN);

            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = iIngEN.ClaveMovimientoCabe;
            iMovDetEN.Adicionales.CampoOrden = MovimientoOCDetaEN.ClaMovDet;

            this.eLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXClaveMovimientoCabe(iMovDetEN);

            decimal pendiente = 0;
            this.eLisMovDet.ForEach((x) =>
            {
                if (x.CantidadPendiente > 0)
                {
                    pendiente += x.CantidadPendiente;
                }
            });

            if (pendiente > 0)
            {
                if (Mensaje.DeseasRealizarOperacion("Hay pendientes por llegar en la orden de compra, si se cierra no se podrá generar movimiento.", "Orden de compra") == false) { return; }
            }

            MovimientoOCCabeRN.CerrarMovimientoOCCabe(iIngEN);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se cerró la orden de compra correctamente", this.eTitulo);
            this.ActualizarVentana();
        }

        public void AccionAnularMovimiento()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iIngEN = this.EsActoModificarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }


            if (iIngEN.CEstadoMovimientoCabe == "4")
            {
                Mensaje.OperacionSatisfactoria("La orden de compra ya fue cerrada, verifica el estado", this.eTitulo);
                return;
            }

            //si existe
            wOrdenCompraPorMovimiento win = new wOrdenCompraPorMovimiento();
            win.wOrdCom = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaQuitarMovimiento(iIngEN);
        }
        #endregion


        private void wOrdenCompra_FormClosing(object sender, FormClosingEventArgs e)
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
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void DgvMovCab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
            Dgv.ActualizarBarraEstado(this.DgvMovCab, this.sst1);
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Primero);
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Anterior);
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Siguiente);
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.DgvMovCab, Dgv.Desplazar.Ultimo);
        }

        private void DgvMovCab_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.OrdenarPorColumna(e.ColumnIndex);
        }

        private void DgvMovCab_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            this.ActualizarVentanaAlBuscarValor(e);
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }

        private void tsbImprimirNota_Click(object sender, EventArgs e)
        {
            this.AccionImprimirNota();
        }

        private void IteImportarAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionImportarExcel();
        }

        private void IteImportarEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminarImportarExcel();
        }

        private void tsbEnviar_Click(object sender, EventArgs e)
        {
            this.Enviar();
        }

        private void DgvMovCab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.AsignarOrdenCompraEnviar(e.RowIndex, e.ColumnIndex);
        }

        private void tsbCerrarOC_Click(object sender, EventArgs e)
        {
            this.CerrarOrdenCompra();
        }

        private void tsbGenerarMov_Click(object sender, EventArgs e)
        {
            this.GenerarMovimiento();
        }

        private void tsbAnularMovimiento_Click(object sender, EventArgs e)
        {
            this.AccionAnularMovimiento();
        }
    }
}
