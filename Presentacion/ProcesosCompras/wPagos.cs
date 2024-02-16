using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using WinControles.ControlesWindows;
using Comun;
using Entidades;
using Entidades.Adicionales;
using Negocio;
using Presentacion.Listas;
using Presentacion.Principal;
using Presentacion.Impresiones;
using Presentacion.Procesos;



namespace Presentacion.ProcesosCompras
{
    public partial class wPagos : Heredados.MiForm4
    {
        public wPagos()
        {
            InitializeComponent();
        }


        //Variables     
        string eNombreColumna;
        string eEncabezadoColumna;
        public string eClaveDgvCon = string.Empty;
        public string eClaveDgvPag = string.Empty;
        int eIndiceFilaAnteriorCon;
        int eIndiceFilaAnteriorPag;
        Dgv.Franja eFranjaCon;
#pragma warning disable CS0649 // El campo 'wPagos.eFranjaPag' nunca se asigna y siempre tendrá el valor predeterminado
        Dgv.Franja eFranjaPag;
#pragma warning restore CS0649 // El campo 'wPagos.eFranjaPag' nunca se asigna y siempre tendrá el valor predeterminado
#pragma warning disable CS0414 // El campo 'wPagos.eAplicaEventoCombo' está asignado pero su valor nunca se usa
        int eAplicaEventoCombo = 0;//0 : no aplica evennto , 1 : si aplica evento
#pragma warning restore CS0414 // El campo 'wPagos.eAplicaEventoCombo' está asignado pero su valor nunca se usa

        #region General


        public void NuevaVentana()
        {
            this.Show();
            this.eNombreColumna = MovimientoOCCabeEN.CodAux;
            this.eEncabezadoColumna = "Codigo";
            this.eFranjaCon = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
            this.eAplicaEventoCombo = 1;
        }

        public void ActualizarVentana()
        {
            //actualizar DgvCon
            this.ActualizarDgvAux();

            //habilitar desplazadores segun DgvPro
            Dgv.HabilitarDesplazadores(this.dgvCon, this.btnPrimero, this.btnAnterior, this.btnSiguiente, this.btnUltimo);

            //titulo auxiliar
            this.TituloAux();

            //habilitar acciones segun permisos
            this.HabilitarAccionesSegunPermisos();

            //actualizar Pago
            this.ActualizarDatosDgvPag();

            //titulo Pagos
            this.TituloPagos();

            //preparar para buscar
            //this.AccionBuscar( );
        }

        public void ActualizarDgvAux()
        {
            //obtener el indice fila del DgvPro antes de actualizar los datos
            eIndiceFilaAnteriorCon = Dgv.ObtenerIndiceRegistroXFranja(this.dgvCon);

            //actualizar los datos del DgvCon
            this.ActualizarDatosDgvAux();

            //pintar la columna activa del DgvPro
            Dgv.PintarColumna(this.dgvCon, eNombreColumna);

            //poner franja segun operacion
            Dgv.PosicionarFranja(this.dgvCon, eFranjaCon, eIndiceFilaAnteriorCon, eClaveDgvCon);
        }

        public void ActualizarDatosDgvAux()
        {
            MovimientoOCCabeEN iMovEN = new MovimientoOCCabeEN();
            iMovEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovEN.EstadoPago = "0";
            iMovEN.Adicionales.CampoOrden = eNombreColumna;

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.dgvCon;
            List<MovimientoOCCabeEN> listMov = MovimientoOCCabeRN.ListarMovimientoCabesAuxiliarXEstadoPago(iMovEN);
            List<AuxiliarEN> listAux = new List<AuxiliarEN>();

            foreach (MovimientoOCCabeEN obj in listMov)
            {
                if (listAux.Where(x => x.CodigoAuxiliar == obj.CodigoAuxiliar).Count() == 0)
                {
                    AuxiliarEN oAux = new AuxiliarEN();
                    oAux.CodigoAuxiliar = obj.CodigoAuxiliar;
                    oAux.DescripcionAuxiliar = obj.DescripcionAuxiliar;
                    oAux.CorreoAuxiliar = obj.CorreoAuxiliar;
                    oAux.DireccionAuxiliar = obj.DireccionAuxiliar;
                    listAux.Add(oAux);
                }
            }

            iDgv.RefrescarDatosGrilla(listAux);

            //asignar columnas            
            iDgv.AsignarColumnaTextCadena(AuxiliarEN.CodAux, "Código", 100);
            iDgv.AsignarColumnaTextCadena(AuxiliarEN.DesAux, "Auxiliar", 230);
            iDgv.AsignarColumnaTextCadena(AuxiliarEN.CorAux, "Correo", 230);
            iDgv.AsignarColumnaTextCadena(AuxiliarEN.DirAux, "Dirección", 230);
        }

        public void TituloAux()
        {
            int iNumeroContratos = Dgv.ObtenerNumeroRegistros(this.dgvCon);
            this.lblContratos.Text = string.Empty;
            this.lblContratos.Text += "Auxiliares de la empresa : " + Universal.gNombreEmpresa;
            this.lblContratos.Text += " / Nro : " + iNumeroContratos.ToString();
        }

        public void ActualizarDgvPag()
        {
            //obtener el indice fila del DgvRef antes de actualizar los datos
            eIndiceFilaAnteriorPag = Dgv.ObtenerIndiceRegistroXFranja(this.dgvPago);

            //obtener el valor de la clave actual de la franja
            eClaveDgvPag = Dgv.ObtenerValorCelda(this.dgvPago, PagoEN.ClaObj);

            //actualizar los datos del DgvPag
            this.ActualizarDatosDgvPag();

            //poner franja segun operacion
            Dgv.PosicionarFranja(this.dgvPago, eFranjaPag, eIndiceFilaAnteriorPag, eClaveDgvPag);
        }

        public void ActualizarDatosDgvPag()
        {
            PagoEN iCobEN = new PagoEN();
            iCobEN.NumeroContrato = Dgv.ObtenerValorCelda(this.dgvCon, MovimientoOCCabeEN.CodAux);
            iCobEN.Adicionales.CampoOrden = PagoEN.FecVenCuo;

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.dgvPago;
            iDgv.RefrescarDatosGrilla(PagoRN.ListarPagosXContrato(iCobEN));

            //asignar columnas         
            //iDgv.AsignarColumnaTextCadena( PagoEN.NumLet , "Letra" , 70 );
            iDgv.AsignarColumnaTextCadena(PagoEN.FecVenCuo, "Vcto", 68);
            iDgv.AsignarColumnaTextCadena(PagoEN.FecDepPag, "Deposito", 68);
            iDgv.AsignarColumnaTextNumerico(PagoEN.ImpPag, "Mon.Pen", 65, 2);
            iDgv.AsignarColumnaTextNumerico(PagoEN.MonaCobPag, "M.APagar", 65, 2);
            iDgv.AsignarColumnaTextNumerico(PagoEN.MonCobPag, "M.Pagado", 65, 2);
            iDgv.AsignarColumnaTextNumerico(PagoEN.MonDesPag, "Dscto", 55, 2);
            iDgv.AsignarColumnaTextCadena(PagoEN.ObsPag, "Observacion", 280);
            iDgv.AsignarColumnaTextCadena(PagoEN.NumCtaBco, "Cuenta", 140);
            iDgv.AsignarColumnaTextCadena(PagoEN.CodCueBco, "Cod.Cta", 60);
            iDgv.AsignarColumnaTextCadena(PagoEN.NomBco, "Banco", 100);
            iDgv.AsignarColumnaTextCadena(PagoEN.UsuAgr, "Usu.Agrega", 100);
            iDgv.AsignarColumnaTextCadena(PagoEN.FecAgr, "Fec.Agrega", 75);
            iDgv.AsignarColumnaTextCadena(PagoEN.UsuMod, "Usu.Modifica", 100);
            iDgv.AsignarColumnaTextCadena(PagoEN.FecMod, "Fec.Modifica", 75);
            iDgv.AsignarColumnaTextCadena(PagoEN.ClaObj, "ClaveObjeto", 120, false);
        }

        public void TituloPagos()
        {
            string iContratoActual = string.Empty;
            int iNumeroPagos = Dgv.ObtenerNumeroRegistros(this.dgvPago);
            this.lblPagos.Text = string.Empty;
            iContratoActual = Dgv.ObtenerValorCelda(this.dgvCon, MovimientoOCCabeEN.CodAux);
            this.lblPagos.Text += "Pagos del contrato : " + iContratoActual;
            this.lblPagos.Text += " / Nro : " + iNumeroPagos.ToString();

        }

        public void HabilitarAccionesSegunDgvCon()
        {
            int iNumeroRegistros = this.dgvCon.Rows.Count;
            bool iVerdadFalso = true;
            if (iNumeroRegistros == 0) { iVerdadFalso = false; }
            this.btnPagos.Enabled = iVerdadFalso;
            this.btnEliminarPago.Enabled = iVerdadFalso;
        }

        public void HabilitarAccionesSegunPermisos()
        {

        }

        public void AccionBuscar()
        {
            this.tstBuscar.Clear();
            this.tstBuscar.ToolTipText = "Ingrese " + this.eEncabezadoColumna;
            this.tstBuscar.Focus();
        }

        public void AsignarAuxliar(AuxiliarEN pMov)
        {
            pMov.CodigoAuxiliar = Dgv.ObtenerValorCelda(this.dgvCon, AuxiliarEN.CodAux);
            pMov.DescripcionAuxiliar = Dgv.ObtenerValorCelda(this.dgvCon, AuxiliarEN.DesAux);
            //pMov.ClaveMovimientoCabe = Dgv.ObtenerValorCelda(this.dgvCon, AuxiliarEN.ClaMovCab);
        }

        public void AccionPagar()
        {
            //verificar si el contrato esta pendiente para cobrar
            AuxiliarEN iAuxEN = this.EsContratoExistente();
            if (iAuxEN.Adicionales.EsVerdad == false) { return; }

            //instanciar letras pendientes de Pago
            wPagosLetras win = new wPagosLetras();
            win.wPag = this;
            win.eAuxEN = iAuxEN;
            win.eTipoVentana = 0;
            win.eOperacion = Universal.Opera.Adicionar;
            this.eFranjaCon = Dgv.Franja.PorIndice;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionEliminarPago()
        {
            //instanciar letras pendientes de Pago
            wEliminarPagos win = new wEliminarPagos();
            win.wPag = this;
            this.eFranjaCon = Dgv.Franja.PorValor;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public void AccionModificarDatosPago()
        {
            //es acto modificar la Pago
            PagoEN iCobEN = this.EsPagoExistente();
            if (iCobEN.Adicionales.EsVerdad == false) { return; }

            //instanciar ventana
            wModificarPagos win = new wModificarPagos();
            win.wCob = this;
            this.eFranjaCon = Dgv.Franja.PorValor;
            win.eOperacion = Universal.Opera.Modificar;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana(iCobEN);
        }

        public PagoEN EsPagoExistente()
        {
            PagoEN iCobEN = new PagoEN();
            iCobEN.CorrelativoPago = Dgv.ObtenerValorCelda(this.dgvPago, PagoEN.ClaObj);
            iCobEN = PagoRN.EsPagoExistente(iCobEN);
            if (iCobEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCobEN.Adicionales.Mensaje, "Pago");
            }
            return iCobEN;
        }

        public AuxiliarEN EsContratoExistente()
        {
            AuxiliarEN iAux = new AuxiliarEN();
            this.AsignarAuxliar(iAux);
            iAux = AuxiliarRN.EsAuxiliarExistente(iAux);
            if (iAux.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAux.Adicionales.Mensaje, "Contrato");
            }
            return iAux;
        }

        public PagoEN EsActoModificarPago()
        {
            PagoRN iCobRN = new PagoRN();
            PagoEN iCobEN = new PagoEN();
            iCobEN.CorrelativoPago = Dgv.ObtenerValorCelda(this.dgvPago, PagoEN.ClaObj);
            //iCobEN = iCobRN.EsActoModificarPago(iCobEN);
            if (iCobEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCobEN.Adicionales.Mensaje, "Pago");
            }
            return iCobEN;
        }

        public void AccionModificarAlHacerDobleClick(int pColumna, int pFila)
        {
            //no debe pasar cuando la fila o columna sea -1
            if (pColumna == -1 || pFila == -1) { return; }

            this.AccionPagar();
        }

        public void ExportarAExcel()
        {
            PagoEN iCobEN = new PagoEN();
            iCobEN.NumeroContrato = Dgv.ObtenerValorCelda(this.dgvCon, MovimientoOCCabeEN.CodAux);
            iCobEN.Adicionales.CampoOrden = PagoEN.CorPag;
            List<PagoEN> iLisCob = PagoRN.ListarPagosXContrato(iCobEN);

            //Numero de objetos
            int iNroPagos = iLisCob.Count + 1;

            MiExcel iExcel = new MiExcel();

            try
            {
                iExcel.NuevoExcel(iNroPagos);

                //escribiendo las columnas en la fila 1 del excel
                iExcel.AgregarColumna("Proyecto", "@", 10);
                iExcel.AgregarColumna("Contrato", "@", 12);
                iExcel.AgregarColumna("Fc.Vcto", "@", 13);
                iExcel.AgregarColumna("Deposito", "@", 13);
                iExcel.AgregarColumna("Mon.Pen", "0.00", 13);
                iExcel.AgregarColumna("M.ACobrar", "0.00", 13);
                iExcel.AgregarColumna("M.Pagado", "0.00", 13);
                iExcel.AgregarColumna("Dscto", "0.00", 8);
                iExcel.AgregarColumna("Mora", "0.00", 8);
                iExcel.AgregarColumna("Ret.lets", "0.00", 8);
                iExcel.AgregarColumna("Observacion", "@", 45);
                iExcel.AgregarColumna("Cuenta", "@", 18);
                iExcel.AgregarColumna("Cod.Cta", "@", 10);
                iExcel.AgregarColumna("Banco", "@", 18);

                //escribiendo cada letra de la planilla
                foreach (PagoEN xCob in iLisCob)
                {
                    iExcel.AgregarNuevaLinea();
                    iExcel.AgregandoDato(xCob.CodigoProyecto);
                    iExcel.AgregandoDato(xCob.NumeroContrato);
                    iExcel.AgregandoDato(xCob.FechaVencimientoCuota);
                    iExcel.AgregandoDato(xCob.FechaDepositoPago);
                    iExcel.AgregandoDato(xCob.ImportePago.ToString());
                    iExcel.AgregandoDato(xCob.MontoaCobrarPago.ToString());
                    iExcel.AgregandoDato(xCob.MontoCobradoPago.ToString());
                    iExcel.AgregandoDato(xCob.MontoDescuentoPago.ToString());
                    iExcel.AgregandoDato(xCob.MontoMoraPago.ToString());
                    iExcel.AgregandoDato(xCob.MontoOtrosPago.ToString());
                    iExcel.AgregandoDato(xCob.ObservacionPago);
                    iExcel.AgregandoDato(xCob.NumeroCuentaBanco);
                    iExcel.AgregandoDato(xCob.CodigoCuentaBanco);
                    iExcel.AgregandoDato(xCob.NombreBanco);
                }
                iExcel.MostrarExcel();
            }
            catch (Exception ex)
            {
                Mensaje.OperacionDenegada(ex.Message, "Error");
                iExcel.MostrarExcel();
            }
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.itePagosPorOrdenCompra, null);
        }

        #endregion


        private void wPagos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            this.eFranjaCon = Dgv.Franja.PorIndice;
            this.ActualizarVentana();
        }

        private void dgvCon_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Enabled == true)
            {
                Dgv.HabilitarDesplazadores(this.dgvCon, this.btnPrimero, this.btnAnterior, this.btnSiguiente, this.btnUltimo);
                this.ActualizarDgvPag();
                this.TituloPagos();
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvCon, Dgv.Desplazar.Primero);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvCon, Dgv.Desplazar.Anterior);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvCon, Dgv.Desplazar.Siguiente);

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            Dgv.SeleccionarRegistroXDesplazamiento(this.dgvCon, Dgv.Desplazar.Ultimo);
        }

        private void dgvCon_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.eFranjaCon = Dgv.Franja.PorIndice;
            this.eNombreColumna = this.dgvCon.Columns[e.ColumnIndex].Name;
            this.eEncabezadoColumna = this.dgvCon.Columns[e.ColumnIndex].HeaderText;
            this.ActualizarVentana();
        }

        private void tstBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Dgv.BusquedaInteligenteEnColumna(this.dgvCon, this.eNombreColumna, this.tstBuscar, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.AccionModificarAlHacerDobleClick(e.ColumnIndex, e.RowIndex);
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            this.AccionPagar();
        }

        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            this.AccionEliminarPago();
        }

        private void btnExportarPago_Click(object sender, EventArgs e)
        {
            this.ExportarAExcel();
        }
        private void dgvPagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) { this.AccionModificarDatosPago(); }
        }

    }
}
