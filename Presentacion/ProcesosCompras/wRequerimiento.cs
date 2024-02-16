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
using System.Net.Mail;
using System.IO;
using Presentacion.Listas;

namespace Presentacion.ProcesosCompras
{
    public partial class wRequerimiento : Heredados.MiForm8
    {
        public wRequerimiento()
        {
            InitializeComponent();
        }

        //Atributos
        string eNombreColumnaDgvMovCab = SolicitudPedidoCabeEN.NumMovCab;
        string eEncabezadoColumnaDgvMovCab = "Numero";
        public string eClaveDgvMovCab = string.Empty;
        Dgv.Franja eFranjaDgvMovCab = Dgv.Franja.PorIndice;
        public List<SolicitudPedidoCabeEN> eLisMovCab = new List<SolicitudPedidoCabeEN>();
        int eVaBD = 1;//0 : no , 1 : si
        public string eTitulo = "Requerimiento";
        string ePeriodo = string.Empty;
        public List<SolicitudPedidoDetaEN> eLisSolDet = new List<SolicitudPedidoDetaEN>();
        public List<MovimientoOCDetaEN> eLisMovDet = new List<MovimientoOCDetaEN>();
        string iNuevoNumero = string.Empty;
        public List<LoteEN> eLisLot = new List<LoteEN>();
        string iCorrelativo = "0000";
        string codAux = string.Empty;

        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.MostrarPersistencia();
        }

        public void ActualizarVentana()
        {
            this.ActualizarListaSolicitudPedidoCabesDeBaseDatos();
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
            List<SolicitudPedidoCabeEN> iFuenteDatos = this.ObtenerDatosParaGrilla();
            Dgv.Franja iCondicionFranja = eFranjaDgvMovCab;
            string iClaveBusqueda = eClaveDgvMovCab;
            string iColumnaPintura = eNombreColumnaDgvMovCab;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvMovCab();
            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iColumnaPintura, iListaColumnas);

            this.BloquearCeldaSolicitudEnviadas(iGrilla, iFuenteDatos);
        }

        public void BloquearCeldaSolicitudEnviadas(DataGridView iGrilla, List<SolicitudPedidoCabeEN> FuenteDatos)
        {
            int n = 0;
            foreach (SolicitudPedidoCabeEN solPed in FuenteDatos)
            {
                if (solPed.FlagEnviadoSolicitudPedido)
                {
                    if (iGrilla[SolicitudPedidoCabeEN.NumMovCab, n].Value.ToString() == solPed.NumeroSolicitudPedidoCabe.ToString())
                    {
                        iGrilla[SolicitudPedidoCabeEN.FlagEnvSolPed, n].ReadOnly = true;
                    }
                }
                n++;
            }
            this.DgvMovCab = iGrilla;
        }

        public List<DataGridViewColumn> ListarColumnasDgvMovCab()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas

            iLisRes.Add(Dgv.NuevaColumnaCheckBox(SolicitudPedidoCabeEN.FlagEnvSolPed, "OC", 50));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.NumMovCab, "Numero", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.FecMovCab, "Fecha", 65));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.PerMovCab, "Periodo", 62));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.DesAlm, "Almacen", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.DesAux, "Proveedor", 250));
            iLisRes.Add(Dgv.NuevaColumnaTextNumerico(SolicitudPedidoCabeEN.CosFleMovCab, "Flete", 90, 2));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.NomPer, "Personal", 160));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.GloMovCab, "Glosa", 180));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.NOriVenCre, "Origen", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.NEstMovCab, "Estado", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.NCodMon, "Moneda", 90));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.ClaObj, "Clave", 50, false));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(SolicitudPedidoCabeEN.FlagEnvSolPed, "FlagEnvSolPed", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaSolicitudPedidoCabesDeBaseDatos()
        {
            //validar si es acto ir a la bd
            if (tstBuscar.Text.Trim() != string.Empty && eVaBD == 0) { return; }

            //ir a la bd
            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            iCuoEN.PeriodoSolicitudPedidoCabe = lblPeriodo.Text;
            //iCuoEN.CClaseTipoOperacion = "1";//ingreso
            iCuoEN.Adicionales.CampoOrden = eNombreColumnaDgvMovCab;
            this.eLisMovCab = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesXPeriodoYClaseOperacion(iCuoEN);
        }

        public List<SolicitudPedidoCabeEN> ObtenerDatosParaGrilla()
        {
            //asignar parametros
            string iValorBusqueda = tstBuscar.Text.Trim();
            string iCampoBusqueda = eNombreColumnaDgvMovCab;
            List<SolicitudPedidoCabeEN> iListaSolicitudPedidoCabes = eLisMovCab;

            //ejecutar y retornar
            return SolicitudPedidoCabeRN.ListarDatosParaGrillaPrincipal(iValorBusqueda, iCampoBusqueda, iListaSolicitudPedidoCabes);
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

        public void AsignarSolicitudPedidoCabe(SolicitudPedidoCabeEN pIng)
        {
            pIng.ClaveSolicitudPedidoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, SolicitudPedidoCabeEN.ClaObj);
            pIng.PeriodoSolicitudPedidoCabe = this.lblPeriodo.Text;
            pIng.COrigenVentanaCreacion = "1";//ingreso      
        }

        public void AccionAdicionar()
        {
            //validar
            SolicitudPedidoCabeEN iIngEN = this.EsActoAdicionarSolicitudPedidoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //instanciar
            wEditRequerimiento win = new wEditRequerimiento();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaAdicionar();
        }

        public void AccionModificar()
        {
            //preguntar si el registro seleccionado existe
            SolicitudPedidoCabeEN iIngEN = this.EsActoModificarSolicitudPedidoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            if (iIngEN.CEstadoSolicitudPedidoCabe == "2")
            {
                Mensaje.OperacionDenegada("La solicitud ya fue aprobada, no se puede modificar.", eTitulo);
                return;
            }

            if (iIngEN.CEstadoSolicitudPedidoCabe == "3")
            {
                Mensaje.OperacionDenegada("La solicitud ya fue enviada, no se puede modificar.", eTitulo);
                return;
            }

            //si existe
            wEditRequerimiento win = new wEditRequerimiento();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Modificar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaModificar(iIngEN);
        }

        public void AccionGenerarVariasSolicitudes()
        {
            //preguntar si el registro seleccionado existe
            SolicitudPedidoCabeEN iIngEN = this.EsActoAgregarVariasSolicitudPedidoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            if (iIngEN.CEstadoSolicitudPedidoCabe == "5")
            {
                Mensaje.OperacionDenegada("La solicitud ha sido desaprobada, no se puede eliminar.", eTitulo);
                return;
            }

            //si existe
            wSelAux win = new wSelAux();
            win.wFrm = this;
            win.eTituloVentana = "Proveedores";
            win.eOperacion = Universal.Opera.AgregarVarios;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            if (!iIngEN.MasivoSolicitudPedidoCabe)
            {
                Mensaje.OperacionSatisfactoria("La solicitud de pedido no es masivo.", this.eTitulo);
                return;
            }
            else
                win.VentanaAgregarVarios(iIngEN);
        }

        public void SeleccionarEsAuxiliar()
        {
            //preguntar si el registro seleccionado existe
            SolicitudPedidoCabeEN iIngEN = this.EsActoAgregarVariasSolicitudPedidoCabe();
            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            if (iIngEN.CEstadoSolicitudPedidoCabe == "5")
            {
                Mensaje.OperacionDenegada("La solicitud ha sido desaprobada, no se puede eliminar.", eTitulo);
                return;
            }

            //si existe
            wSelAux win = new wSelAux();
            win.wFrm = this;
            win.eTituloVentana = "Proveedores";
            win.eOperacion = Universal.Opera.AgregarVarios;
            this.eFranjaDgvMovCab = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            //if (!iIngEN.MasivoSolicitudPedidoCabe)
            //{
            //    Mensaje.OperacionSatisfactoria("La solicitud de pedido no es masivo.", this.eTitulo);
            //    return;
            //}
            //else
            win.VentanaAgregarVarios(iIngEN);
        }


        public SolicitudPedidoCabeEN EsActoAgregarVariasSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iIngEN);
            iIngEN = SolicitudPedidoCabeRN.EsActoAgregarVariasSolicitudPedidoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public SolicitudPedidoCabeEN EsActoGenerarOrdenCompra()
        {
            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iIngEN);
            iIngEN = SolicitudPedidoCabeRN.EsActoGenerarOrdenCompra(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
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
            SolicitudPedidoCabeEN iCuoEN = this.EsActoEliminarSolicitudPedidoCabe();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            if (iCuoEN.CEstadoSolicitudPedidoCabe == "2")
            {
                Mensaje.OperacionDenegada("La solicitud ya fue aprobada, no se puede eliminar.", eTitulo);
                return;
            }

            if (iCuoEN.CEstadoSolicitudPedidoCabe == "3")
            {
                Mensaje.OperacionDenegada("La solicitud ya fue enviada, no se puede eliminar.", eTitulo);
                return;
            }

            //si existe
            wEditRequerimiento win = new wEditRequerimiento();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Eliminar;
            this.eFranjaDgvMovCab = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaEliminar(iCuoEN);
        }

        public void AccionVisualizar()
        {
            //preguntar si el registro seleccionado existe
            SolicitudPedidoCabeEN iCuoEN = this.EsSolicitudPedidoCabeExistente();
            if (iCuoEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wEditRequerimiento win = new wEditRequerimiento();
            win.wFrm = this;
            win.eOperacion = Universal.Opera.Visualizar;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaVisualizar(iCuoEN);
        }

        //public void AccionImportarExcel()
        //{
        //    //instanciar
        //    wImportarSolicitudPedidosIngresos win = new wImportarSolicitudPedidosIngresos();
        //    win.wIng = this;
        //    TabCtrl.InsertarVentana(this, win);
        //    win.NuevaVentana();
        //}

        public void AccionEliminarImportarExcel()
        {
            //validar
            SolicitudPedidoCabeEN iMovCabEN = this.EsActoEliminarImportacionSolicitudPedidoCabes();
            if (iMovCabEN.Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Eliminar importacion") == false) { return; }

            //eliminar copia
            SolicitudPedidoCabeRN.EliminarAntesDeImportarIngreso(this.lblPeriodo.Text);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se elimino la importacion", this.eTitulo);

            //actualizar ventana
            this.ActualizarVentana();
        }

        public void AccionImprimirNota()
        {
            //preguntar si el registro seleccionado existe
            SolicitudPedidoCabeEN iSalEN = this.EsSolicitudPedidoCabeExistente();
            if (iSalEN.Adicionales.EsVerdad == false) { return; }

            //si existe
            wImpSolicitudPedido win = new wImpSolicitudPedido();
            win.wFrm = this;
            win.eVentana = wImpSolicitudPedido.Ventana.wSolicitudPedido;
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

        public SolicitudPedidoCabeEN EsSolicitudPedidoCabeExistente()
        {
            SolicitudPedidoCabeEN iCuoEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iCuoEN);
            iCuoEN = SolicitudPedidoCabeRN.EsSolicitudPedidoCabeExistente(iCuoEN);
            if (iCuoEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iCuoEN;
        }

        public SolicitudPedidoCabeEN EsActoAdicionarSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iIngEN);
            iIngEN = SolicitudPedidoCabeRN.EsActoAdicionarSolicitudPedidoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }

            return iIngEN;
        }

        public SolicitudPedidoCabeEN EsActoModificarSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iIngEN);
            iIngEN = SolicitudPedidoCabeRN.EsActoModificarSolicitudPedidoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public SolicitudPedidoCabeEN EsActoEliminarSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iIngEN);
            iIngEN = SolicitudPedidoCabeRN.EsActoEliminarSolicitudPedidoCabe(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public SolicitudPedidoCabeEN EsActoEliminarImportacionSolicitudPedidoCabes()
        {
            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iIngEN);
            iIngEN = SolicitudPedidoCabeRN.EsActoEliminarImportacionSolicitudPedidoCabeIngreso(iIngEN);
            if (iIngEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iIngEN.Adicionales.Mensaje, this.eTitulo);
            }
            return iIngEN;
        }

        public SolicitudPedidoCabeEN EsActoAprobarSolicitudPedidoCabe()
        {
            SolicitudPedidoCabeEN iIngEN = new SolicitudPedidoCabeEN();
            this.AsignarSolicitudPedidoCabe(iIngEN);
            iIngEN = SolicitudPedidoCabeRN.EsActoAprobarSolicitudPedidoCabe(iIngEN);
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
            wMen.CerrarVentanaHijo(this, wMen.iteRequerimiento, null);
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

        public void GenerarOrdenCompraPorRequerimiento()
        {
            if (this.EsValidoEnvio() == false) { return; }
            if (this.EsValidaSolicitudPedidoAprobado() == false) { return; }
            this.ListarProveedores();
            this.ActualizarVentana();
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

        public bool EsValidaFechaFinSolicitudPedido()
        {
            //recorrer cada registro
            for (int n = 0; n <= this.eLisMovCab.Count - 1; n++)
            {
                //preguntar si esta chequeado
                bool iValor = Convert.ToBoolean(this.eLisMovCab[n].VerdadFalso);
                if (iValor == true)
                {
                    DateTime iFechaFin = Convert.ToDateTime(this.eLisMovCab[n].FechaSolicitudPedidoFinCabe.ToString());
                    if (DateTime.Now.Date > iFechaFin)
                    {
                        Mensaje.OperacionDenegada("Hay solicitudes que ya caducaron segun la fecha fin.", "Contrato");
                        return false;
                    }
                }
            }

            //ok          
            return true;
        }

        public bool EsValidaSolicitudPedidoAprobado()
        {
            //recorrer cada registro
            for (int n = 0; n <= this.eLisMovCab.Count - 1; n++)
            {
                //preguntar si esta chequeado
                bool iValor = Convert.ToBoolean(this.eLisMovCab[n].VerdadFalso);
                if (iValor == true)
                {
                    string estadoSolicitud = this.eLisMovCab[n].CEstadoSolicitudPedidoCabe.ToString();
                    if (estadoSolicitud == "1")
                    {
                        Mensaje.OperacionDenegada("Hay solicitudes que no han sido aprobadas.", "Contrato");
                        return false;
                    }
                }
            }

            //ok          
            return true;
        }

        public bool EsValidaSolicitudPedidoDesaprobado()
        {
            //recorrer cada registro
            for (int n = 0; n <= this.eLisMovCab.Count - 1; n++)
            {
                //preguntar si esta chequeado
                bool iValor = Convert.ToBoolean(this.eLisMovCab[n].VerdadFalso);
                if (iValor == true)
                {
                    string estadoSolicitud = this.eLisMovCab[n].CEstadoSolicitudPedidoCabe.ToString();
                    if (estadoSolicitud == "5")
                    {
                        Mensaje.OperacionDenegada("Hay solicitudes que han sido desaprobadas.", "Contrato");
                        return false;
                    }
                }
            }

            //ok          
            return true;
        }

        public bool EsValidaSolicitudPedidoEnviada()
        {
            //recorrer cada registro
            for (int n = 0; n <= this.eLisMovCab.Count - 1; n++)
            {
                //preguntar si esta chequeado
                bool iValor = Convert.ToBoolean(this.eLisMovCab[n].VerdadFalso);
                if (iValor == true)
                {
                    string estadoSolicitud = this.eLisMovCab[n].CEstadoSolicitudPedidoCabe.ToString();
                    if (estadoSolicitud == "3")
                    {
                        Mensaje.OperacionDenegada("Hay solicitud de pedido que han sido enviadas.", "Contrato");
                        return false;
                    }
                }
            }

            //ok          
            return true;
        }

        public void Enviar()
        {
            //validar envio
            if (this.EsValidoEnvio() == false) { return; }

            //validar si todas las marcadas tienen correo
            if (this.EsValidaMarcadasConCorreoElectronico() == false) { return; }

            //validar si la fecha fin ya caduco de las solicitudes marcadas
            if (this.EsValidaFechaFinSolicitudPedido() == false) { return; }

            //validar si la solicitud ha sido aprobada
            if (this.EsValidaSolicitudPedidoAprobado() == false) { return; }

            //validar si la solicitud ha sido desaprobado
            if (this.EsValidaSolicitudPedidoDesaprobado() == false) { return; }

            //validar que las solicitud de pedido no hayan sido enviadas
            if (this.EsValidaSolicitudPedidoEnviada() == false) { return; }

            //validar que existan todos los pds de las cuotas selecionadas
            if (this.ExistenArchivosExcel() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            wEnviarSolicitudPedido win = new wEnviarSolicitudPedido();
            win.wFrm = this;
            TabCtrl.InsertarVentana(this, win);
            win.VentanaProgressBar(this.eLisMovCab);
        }

        public bool ExistenArchivosExcel()
        {
            //obtener a las cuotas marcadas
            List<SolicitudPedidoCabeEN> iLisSolPed = this.eLisMovCab;

            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //obtener la ruta de la carpeta para el periodo elegido
            string iRutaCarpetaPeriodo = iParEN.RutaCarpetaPlantillas; //wGenerarRecibos.ObtenerRutaCarpetaPeriodo(txtAno.Text, Cmb.ObtenerValor(cmbMes, ""));

            //recorrer cada objeto cuota
            foreach (SolicitudPedidoCabeEN xSol in iLisSolPed)
            {
                string fileName = "SolicitudPedido_" + xSol.ClaveSolicitudPedidoCabe + ".xlsx";
                //armar la ruta de su archivo
                //string iRutaArchivo = "RutaArchivo";  
                //wGenerarRecibos.ObtenerNuevaRutaPDF(xCuo, iRutaCarpetaPeriodo);

                string destFile = System.IO.Path.Combine(iRutaCarpetaPeriodo, fileName);
                bool iValor = Convert.ToBoolean(xSol.VerdadFalso);
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

        public void AsignarSolicitudEnviar(int pFilaChequeada, int pColumnaChequeada)
        {
            //solo debe actuar cuando la columna sea "0" y la fila diferente de "-1"
            if (pColumnaChequeada == 0 && pFilaChequeada != -1)
            {
                SolicitudPedidoCabeEN iSolEN = new SolicitudPedidoCabeEN();
                iSolEN.ClaveSolicitudPedidoCabe = Dgv.ObtenerValorCelda(this.DgvMovCab, SolicitudPedidoCabeEN.ClaObj);
                bool flagEnviado = Convert.ToBoolean(Dgv.ObtenerValorCelda(this.DgvMovCab, SolicitudPedidoCabeEN.FlagEnvSolPed));
                if (!flagEnviado)
                    iSolEN.VerdadFalso = !this.eLisMovCab[pFilaChequeada].VerdadFalso;
                SolicitudPedidoCabeRN.AsignarSolicitudEnviada(iSolEN, this.eLisMovCab);
            }
        }

        public void AprobarSolicitudPedido()
        {
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            SolicitudPedidoCabeEN iIngEN = this.EsActoAprobarSolicitudPedidoCabe();

            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //validar si la fecha fin ya caduco de las solicitudes marcadas
            if (this.EsValidaFechaFinSolicitudPedido() == false) { return; }

            if (iIngEN.CEstadoSolicitudPedidoCabe == "2")
            {
                Mensaje.OperacionDenegada("La solicitud ya fue aprobada, se puede realizar el envio al proveedor.", eTitulo);
                return;
            }

            if (iIngEN.CEstadoSolicitudPedidoCabe == "3")
            {
                Mensaje.OperacionDenegada("La solicitud ya fue enviada.", eTitulo);
                return;
            }


            SolicitudPedidoCabeRN.AprobarSolicitudPedidoCabe(iIngEN);

            Mensaje.OperacionSatisfactoria("Se aprobó la solicitud de pedido correctamente", this.eTitulo);
            this.ActualizarVentana();
        }
        public void GenerarOrdenCompra(string codAux)
        {
            if (codAux == string.Empty) { Mensaje.OperacionDenegada("Debe seleccionar un proveedor.", this.eTitulo); return; }

            //preguntar si el registro seleccionado existe
            SolicitudPedidoCabeEN iIngEN = this.EsActoGenerarOrdenCompra();

            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            if (iIngEN.CEstadoSolicitudPedidoCabe == "5")
            {
                Mensaje.OperacionDenegada("La solicitud ha sido desaprobada, no se puede eliminar.", eTitulo);
                return;
            }

            this.MostrarNuevoNumero(iIngEN);

            MovimientoOCCabeEN iCuoEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iCuoEN);
            iCuoEN.CodigoAuxiliar = codAux;
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iCuoEN);

            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveSolicitudPedidoCabe = iIngEN.ClaveSolicitudPedidoCabe;
            iMovDetEN.Adicionales.CampoOrden = SolicitudPedidoDetaEN.ClaMovDet;

            this.eLisSolDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXClaveSolicitudPedidoCabe(iMovDetEN);
            iCorrelativo = "0000";
            foreach (SolicitudPedidoDetaEN objSD in this.eLisSolDet)
            {
                this.AdicionarMovimientosDeta(iIngEN, objSD);
            }

            LoteEN iLotEN = new LoteEN();
            iLotEN.ClaveMovimientoCabe = iIngEN.ClaveSolicitudPedidoCabe;
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

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se genero la orden de compra correctamente", this.eTitulo);

            SolicitudPedidoCabeRN.CerrarSolicitudPedidoCabe(iIngEN);
            this.ActualizarVentana();
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

        public void MostrarNuevoNumero(SolicitudPedidoCabeEN iIngEN)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = this.NuevoMovimientoCabeDeVentana(iIngEN);

            //obtener el nuevo numero
            iNuevoNumero = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
        }

        public MovimientoOCCabeEN NuevoMovimientoCabeDeVentana(SolicitudPedidoCabeEN iIngEN)
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iMovCabEN);
            return iMovCabEN;
        }

        public void AsignarMovimientoCabe(SolicitudPedidoCabeEN iIngEN, MovimientoOCCabeEN pMovCab)
        {
            pMovCab.CodigoEmpresa = Universal.gCodigoEmpresa;
            pMovCab.PeriodoMovimientoCabe = iIngEN.PeriodoSolicitudPedidoCabe;
            pMovCab.NumeroMovimientoCabe = iNuevoNumero;
            pMovCab.FechaMovimientoCabe = Fecha.ObtenerAnoMesDia(DateTime.Now);
            pMovCab.CodigoTipoOperacion = "41";
            pMovCab.DescripcionTipoOperacion = "COMPRAS LOCALES";
            pMovCab.CodigoAlmacen = iIngEN.CodigoAlmacen;
            pMovCab.DescripcionAlmacen = iIngEN.DescripcionAlmacen;
            pMovCab.CodigoPersonal = iIngEN.CodigoPersonal;
            pMovCab.CodigoPersonalAutoriza = iIngEN.CodigoPersonalAutoriza;
            pMovCab.CodigoPersonalRecibe = string.Empty;
            pMovCab.CostoFleteMovimientoCabe = iIngEN.CostoFleteSolicitudPedidoCabe;
            pMovCab.CCodigoMoneda = iIngEN.CCodigoMoneda;
            pMovCab.TipoCambio = iIngEN.TipoCambio;
            pMovCab.CodigoAuxiliar = iIngEN.CodigoAuxiliar;
            pMovCab.DescripcionAuxiliar = iIngEN.DescripcionAuxiliar;
            pMovCab.OrdenCompra = string.Empty;
            pMovCab.CTipoDocumento = string.Empty;
            pMovCab.SerieDocumento = string.Empty;
            pMovCab.NumeroDocumento = string.Empty;
            pMovCab.FechaDocumento = Fecha.ObtenerAnoMesDia(DateTime.Now);
            pMovCab.GlosaMovimientoCabe = iIngEN.GlosaSolicitudPedidoCabe;
            pMovCab.COrigenVentanaCreacion = "1";//ingreso     
            pMovCab.FlagCreadoxSolicitud = 1;
            pMovCab.ClaveSolicitudPedidoCabe = iIngEN.ClaveSolicitudPedidoCabe;
            pMovCab.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(pMovCab);
        }

        public void AdicionarMovimientosDeta(SolicitudPedidoCabeEN iIngEN, SolicitudPedidoDetaEN iSolDet)
        {
            MovimientoOCDetaEN xMovDet = new MovimientoOCDetaEN();
            //variables
            string iClaveMovimientoCabe = this.ObtenerClaveMovimientoCabe(iIngEN);

            //incrementar el correlativo
            iCorrelativo = Numero.IncrementarCorrelativoNumerico(iCorrelativo);

            //actualizar algunos datos antes de grabar
            xMovDet.CodigoEmpresa = iSolDet.CodigoEmpresa;
            xMovDet.NombreEmpresa = iSolDet.NombreEmpresa;
            xMovDet.PeriodoMovimientoCabe = iSolDet.PeriodoSolicitudPedidoCabe;
            xMovDet.CodigoAlmacen = iSolDet.CodigoAlmacen;
            xMovDet.DescripcionAlmacen = iSolDet.DescripcionAlmacen;
            xMovDet.CodigoTipoOperacion = "41";
            xMovDet.DescripcionTipoOperacion = "COMPRAS LOCALES";
            xMovDet.CClaseTipoOperacion = "1";
            xMovDet.CodigoAuxiliar = iSolDet.CodigoAuxiliar;
            xMovDet.DescripcionAuxiliar = iSolDet.DescripcionAuxiliar;
            xMovDet.CodigoCentroCosto = iSolDet.CodigoCentroCosto;
            xMovDet.DescripcionCentroCosto = iSolDet.DescripcionCentroCosto;
            xMovDet.CodigoExistencia = iSolDet.CodigoExistencia;
            xMovDet.DescripcionExistencia = iSolDet.DescripcionExistencia;
            xMovDet.CodigoTipo = iSolDet.CodigoTipo;
            xMovDet.NombreTipo = iSolDet.NombreTipo;
            xMovDet.CEsLote = iSolDet.CEsLote;
            xMovDet.CCodigoPartida = iSolDet.CCodigoPartida;
            xMovDet.NCodigoPartida = iSolDet.NCodigoPartida;
            xMovDet.GlosaMovimientoDeta = iSolDet.GlosaSolicitudPedidoDeta;
            xMovDet.FechaMovimientoCabe = iSolDet.FechaSolicitudPedidoCabe;
            xMovDet.PrecioUnitarioMovimientoDeta = 0;
            xMovDet.CostoFleteMovimientoDeta = 0;
            xMovDet.FactorConversion = 0;
            xMovDet.CodigoUnidadMedida = iSolDet.CodigoUnidadMedida;
            xMovDet.NombreUnidadMedida = iSolDet.NombreUnidadMedida;
            xMovDet.CantidadMovimientoDeta = iSolDet.CantidadSolicitudPedidoDeta;
            xMovDet.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(xMovDet);
            xMovDet.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(xMovDet);
            xMovDet.NumeroMovimientoCabe = iSolDet.NumeroSolicitudPedidoCabe;
            xMovDet.ClaveMovimientoCabe = iClaveMovimientoCabe;
            xMovDet.CorrelativoMovimientoDeta = iCorrelativo;
            xMovDet.CostoFleteMovimientoCabe = iSolDet.CostoFleteSolicitudPedidoCabe;
            xMovDet.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(xMovDet);
            xMovDet.CCodigoMoneda = iSolDet.CCodigoMoneda;

            //adicion masiva
            MovimientoOCDetaRN.AdicionarMovimientoDeta(xMovDet);
        }

        public string ObtenerClaveMovimientoCabe(SolicitudPedidoCabeEN iIngEN)
        {
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            this.AsignarMovimientoCabe(iIngEN, iMovCabEN);
            return iMovCabEN.ClaveMovimientoCabe;
        }

        public void DesaprobarSolicitudPedido()
        {
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            SolicitudPedidoCabeEN iIngEN = this.EsActoAprobarSolicitudPedidoCabe();

            if (iIngEN.Adicionales.EsVerdad == false) { return; }

            //validar si la fecha fin ya caduco de las solicitudes marcadas
            if (this.EsValidaFechaFinSolicitudPedido() == false) { return; }

            if (iIngEN.CEstadoSolicitudPedidoCabe == "3")
            {
                Mensaje.OperacionDenegada("La solicitud ya fue enviada.", eTitulo);
                return;
            }


            SolicitudPedidoCabeRN.DesaprobarSolicitudPedidoCabe(iIngEN);

            Mensaje.OperacionSatisfactoria("Se desaprobó la solicitud de pedido correctamente", this.eTitulo);
            this.ActualizarVentana();
        }
        public void EscogerRequerimientosParaOrdenDeCompra()
        {

        }
        public void ListarProveedores()
        {
            //si es de lectura , entonces no lista
            //if (this.txtCodAux.ReadOnly == true) { return; }

            //instanciar
            wLisAuxGenerarCompra win = new wLisAuxGenerarCompra();
            win.eVentana = this;
            win.eTituloVentana = "Proveedores";
            //win.eCtrlValor = this.codAux;
            win.codAux = this.codAux;
            //win.eCtrlFoco = this.tstBuscar;
            win.eCondicionLista = wLisAuxGenerarCompra.Condicion.ProveedoresActivos;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(this.eLisMovCab);
        }

        public bool EsProveedorValido()
        {
            //si es de lectura , entonces no lista
            //if (txtCodAux.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AuxiliarEN iAuxEN = new AuxiliarEN();
            iAuxEN.CodigoAuxiliar = this.codAux;
            iAuxEN = AuxiliarRN.EsProveedorActivoValido(iAuxEN);
            if (iAuxEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAuxEN.Adicionales.Mensaje, this.eTitulo);
                //this.txtCodAux.Focus();
            }

            //mostrar datos
            this.codAux = iAuxEN.CodigoAuxiliar;
            //this.txtDesAux.Text = iAuxEN.DescripcionAuxiliar;

            //devolver
            return iAuxEN.Adicionales.EsVerdad;
        }

        #endregion


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
            try
            {
                Dgv.HabilitarDesplazadores(this.DgvMovCab, this.tsbPrimero, this.tsbAnterior, this.tsbSiguiente, this.tsbUltimo);
                Dgv.ActualizarBarraEstado(this.DgvMovCab, this.sst1);
            }
            catch (Exception)
            {

                throw;
            }
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
            //this.AccionImportarExcel();
        }

        private void IteImportarEliminar_Click(object sender, EventArgs e)
        {
            this.AccionEliminarImportarExcel();
        }

        private void wSolicitudPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbCopiar_Click(object sender, EventArgs e)
        {
            this.AccionGenerarVariasSolicitudes();
        }

        private void tsbEnviar_Click(object sender, EventArgs e)
        {
            this.Enviar();
        }

        private void DgvMovCab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.AsignarSolicitudEnviar(e.RowIndex, e.ColumnIndex);
        }

        private void tsbAprobar_Click(object sender, EventArgs e)
        {
            this.AprobarSolicitudPedido();
        }

        private void tsbGenerarOC_Click(object sender, EventArgs e)
        {
            this.GenerarOrdenCompraPorRequerimiento();
        }

        private void tsbDesaprobar_Click(object sender, EventArgs e)
        {
            this.DesaprobarSolicitudPedido();
        }

        private void tstBuscar_Validating(object sender, CancelEventArgs e)
        {
            //this.GenerarOrdenCompra(this.codAux );
        }
    }
}
