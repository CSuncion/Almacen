using Comun;
using Entidades;
using Entidades.Adicionales;
using Heredados.VentanasPersonalizadas;
using Negocio;
using Presentacion.Impresiones;
using Presentacion.Principal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;

namespace Presentacion.ProcesosCompras
{
    public partial class wOrdenServicio : Heredados.MiForm8
    {
        string eNombreColumnaDgvMovCab = MovimientoOCCabeEN.NumMovCab;
        string eEncabezadoColumnaDgvMovCab = "Numero";
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<MovimientoOCCabeEN> eLisMovCab = new List<MovimientoOCCabeEN>();
        public List<MovimientoOCDetaEN> eLisMovDet = new List<MovimientoOCDetaEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Orden de Servicio";
        string iNuevoNumero = string.Empty;
#pragma warning disable CS0414 // El campo 'wOrdenServicio.iCorrelativo' está asignado pero su valor nunca se usa
        string iCorrelativo = "0000";
#pragma warning restore CS0414 // El campo 'wOrdenServicio.iCorrelativo' está asignado pero su valor nunca se usa

        public wOrdenServicio()
        {
            InitializeComponent();
        }

        public void NuevaVentana()
        {
            this.Show();
            this.MostrarPersistencia();
        }

        public void MostrarPersistencia()
        {
            TsL.MostrarValor(lblPeriodo, Properties.Settings.Default.GuardarPeriodoIngresos, Universal.gCodigoEmpresa);
        }

        public void AccionAdicionar()
        {
            //validar
            MovimientoOCCabeEN iIngEN = this.EsActoAdicionarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            ////instanciar
            wEditOrdenServicio win = new wEditOrdenServicio();
            win.wOrdSer = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
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

        public void AsignarMovimientoCabe(MovimientoOCCabeEN pIng)
        {
            pIng.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, MovimientoOCCabeEN.ClaObj);
            pIng.PeriodoMovimientoCabe = lblPeriodo.Text;
            pIng.COrigenVentanaCreacion = "1";//ingreso      
        }

        public void ActualizarListaMovimientoCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            iCuoEN.PeriodoMovimientoCabe = lblPeriodo.Text;
            iCuoEN.CClaseTipoOperacion = "4";//orden de servicio
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvMovCab;
            this.eLisMovCab = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodoYClaseOperacion(iCuoEN);
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

        public void AccionSeleccionarPeriodo()
        {
            vSeleccionarPeriodo win = new vSeleccionarPeriodo();
            win.eVentanaInvoca = this;
            win.eControlDevuelveValor = lblPeriodo;
            win.ePeriodoActual = lblPeriodo.Text;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
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

        public void AccionBuscar()
        {
            //this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumnaDgvMovCab;
            this.tstBuscar.Focus();
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

        public List<DataGridViewColumn> ListarColumnasDgvMovCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaCheckBox(MovimientoOCCabeEN.xFlagEnviadoMovimientoOCCabe, "Correo", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NumMovCab, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.FecMovCab, "Fecha", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.PerMovCab, "Periodo", 62));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.CodTipOpe, "T.O", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesTipOpe, "Descripción T.O", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesAlm, "Tipo Servicio", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.DesAux, "Proveedor", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xPlazoEntrega, "P. Entrega", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NomPer, "Personal", 160));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.GloMovCab, "Glosa", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NOriVenCre, "Origen", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NEstMovCab, "Estado", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.NCodMon, "Moneda", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xCondiciones, "Condiciones", 150));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xGarantia, "Garantia", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xValidezCotizacion, "V. Cot.", 80));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.xNFormaPago, "Forma Pago", 100));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(MovimientoOCCabeEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iIngEN = this.EsActoModificarMovimientoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditOrdenServicio win = new wEditOrdenServicio();
            win.wOrdSer = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iIngEN);
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

        public void AccionEliminar()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iCuoEN = this.EsActoEliminarMovimientoCabe();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }


            //si existe
            wEditOrdenServicio win = new wEditOrdenServicio();
            win.wOrdSer = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iCuoEN);
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

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iCuoEN = this.EsMovimientoCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditOrdenServicio win = new wEditOrdenServicio();
            win.wOrdSer = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
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

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.iteOrdenServicio, null);
        }

        public void AccionImprimirOrdenServicio()
        {
            //preguntar si el registro seleccionado existe
            MovimientoOCCabeEN iSalEN = this.EsMovimientoCabeExistente();
            if (iSalEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wImpOrdenServicio win = new wImpOrdenServicio();
            win.wOrdSer = this;
            win.eVentana = wImpOrdenServicio.Ventana.wOrdenServicio;
            win.NuevaVentana(iSalEN);
        }

        public void Enviar()
        {
            //validar envio
            if (this.EsValidoEnvio() == false) { return; }

            //validar si todas las marcadas tienen correo
            if (this.EsValidaMarcadasConCorreoElectronico() == false) { return; }

            //validar que existan todos los pds de las cuotas selecionadas
            if (this.ExistenArchivosExcel() == false) { return; }

            //validar que las orden de compra no hayan sido enviadas
            if (this.EsValidaOrdenCompraEnviada() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            wEnviarOrdenServicio win = new wEnviarOrdenServicio();
            win.wOrdCom = this;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaProgressBar(this.eLisMovCab);
        }

        public void AsignarMovimientoOrdenServicioEnviar(int pFilaChequeada, int pColumnaChequeada)
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
                        Mensaje.OperacionDenegada("Hay ordenes de servicio que no se han actualizado su precio en el detalle.", "Contrato");
                        return false;
                    }
                }
            }
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
                string fileName = "OrdenServicio_" + xMov.ClaveMovimientoCabe + ".xlsx";
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
                        Mensaje.OperacionDenegada("Hay orden de servicio que han sido enviadas.", "Contrato");
                        return false;
                    }
                }
            }

            //ok          
            return true;
        }

        public void AprobarOrdenServicio()
        {
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            MovimientoOCCabeEN iIngEN = this.EsActoAprobarOrdenServicioCabe();

            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            if (iIngEN.CEstadoMovimientoCabe == "2")
            {
                Mensaje.OperacionDenegada("La orden de servicio ya fue aprobada, se puede realizar el envio al proveedor.", eTitulo);
                return;
            }

            if (iIngEN.CEstadoMovimientoCabe == "3")
            {
                Mensaje.OperacionDenegada("La solicitud ya fue enviada.", eTitulo);
                return;
            }


            MovimientoOCCabeRN.AprobarMovimientoOCCabe(iIngEN);

            Mensaje.OperacionSatisfactoria("Se aprobó la orden de servicio correctamente", this.eTitulo);
            this.ActualizarVentana();
        }

        public MovimientoOCCabeEN EsActoAprobarOrdenServicioCabe()
        {
            MovimientoOCCabeEN iIngEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN);
            iIngEN = MovimientoOCCabeRN.EsActoAprobarMovimientoOCCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public void AbrirArchivo()
        {
            try
            {
                MovimientoOCCabeEN iIngEN = new MovimientoOCCabeEN();
                this.AsignarMovimientoCabe(iIngEN);
                ParametroEN iParEN = ParametroRN.BuscarParametro();
                string targetPath = iParEN.RutaCarpetaPlantillas;
                targetPath = targetPath + @"\" + iIngEN.ClaveMovimientoCabe;
                System.Diagnostics.Process.Start(targetPath);
            }
            catch (Exception)
            {
                Mensaje.OperacionDenegada("No encuentra la ruta de la orden de servicio", eTitulo);
            }

        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            this.AccionSeleccionarPeriodo();
        }

        private void lblPeriodo_TextChanged(object sender, EventArgs e)
        {
            this.AccionCambiaPeriodo();
        }

        private void tsbAdicionar_Click(object sender, EventArgs e)
        {
            this.AccionAdicionar();
        }

        private void tsbActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
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

        private void IteImportarAdicionar_Click(object sender, EventArgs e)
        {
            //this.AccionImportarExcel();
        }

        private void IteImportarEliminar_Click(object sender, EventArgs e)
        {
            //this.AccionEliminarImportarExcel();
        }

        private void wOrdenServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbImprimirNota_Click(object sender, EventArgs e)
        {
            this.AccionImprimirOrdenServicio();
        }

        private void tsbAprobar_Click(object sender, EventArgs e)
        {
            this.AprobarOrdenServicio();
        }

        private void tsbEnviar_Click(object sender, EventArgs e)
        {
            this.Enviar();
        }

        private void DgvMovCab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.AsignarMovimientoOrdenServicioEnviar(e.RowIndex, e.ColumnIndex);
        }

        private void tsbAbrirCarpeta_Click(object sender, EventArgs e)
        {
            this.AbrirArchivo();
        }
    }
}
