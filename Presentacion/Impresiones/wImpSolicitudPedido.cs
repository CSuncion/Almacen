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
using Negocio;
using Entidades;
using Presentacion.FuncionesGenericas;
using Presentacion.Principal;
using CrystalDecisions.CrystalReports.Engine;
using Presentacion.Impresiones;
using Entidades.Estructuras;
using Presentacion.Listas;
using Presentacion.ProcesosCompras;
using Presentacion.Consultas;

namespace Presentacion.Impresiones
{
    public partial class wImpSolicitudPedido : Heredados.MiForm8
    {
        public wImpSolicitudPedido()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Ventana
        {
            wSolicitudPedido = 0,
            wPartesTrabajo,
            wMovimientos,
            wInventarios,
            wIngresosDevolucion,
            wIngresosDevolucionEncajado,
        }

        #endregion

        #region Atributos

        public Ventana eVentana;

        #endregion

        #region Propietario

        public wSolicitudPedido wSol;
        //public wParteTrabajo wParTra;
        public wMovimientos wMov;
        //public wInventario wInv;
        //public wIngresosDevolucion wIngDev;
        //public wIngresosDevolucionEncajado wIngDevEnc;

        #endregion

        #region General

        public void NuevaVentana(MovimientoCabeEN pObj)
        {
            this.Imprimir(pObj);
            this.InsertarVentana();       
            this.Show();
        }

        public void InsertarVentana()
        {
            switch (eVentana)
            {
                case Ventana.wSolicitudPedido: { TabCtrl.InsertarVentana(this.wSol, this, 94); break; }
                //case Ventana.wPartesTrabajo: { TabCtrl.InsertarVentana(this.wParTra, this, 94); break; }
                case Ventana.wMovimientos: { TabCtrl.InsertarVentana(this.wMov, this, 94); break; }
                //case Ventana.wInventarios: { TabCtrl.InsertarVentana(this.wInv, this, 94); break; }
                //case Ventana.wIngresosDevolucion: { TabCtrl.InsertarVentana(this.wIngDev, this, 94); break; }
                //case Ventana.wIngresosDevolucionEncajado: { TabCtrl.InsertarVentana(this.wIngDevEnc, this, 94); break; }
            }
        }

        public List<MovimientoDetaEN> ObtenerReporte(MovimientoCabeEN pObj)
        {
            //asignar parametros
            string iClaveMovimientoCabe = pObj.ClaveMovimientoCabe;

            //ejecutar metodo
            return MovimientoDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iClaveMovimientoCabe);
        }

        public void Imprimir(MovimientoCabeEN pObj)
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            TextObject txtObjAlm = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = pObj.CodigoAlmacen + " : " + pObj.DescripcionAlmacen;

            TextObject txtObjTipOpe = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjTipOpe"]);
            txtObjTipOpe.Text = pObj.CodigoTipoOperacion + " : " + pObj.DescripcionTipoOperacion;

            TextObject txtObjCorMovDet = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjCorMovDet"]);
            txtObjCorMovDet.Text = pObj.NumeroMovimientoCabe;

            TextObject txtObjFecMovCab = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjFecMovCab"]);
            txtObjFecMovCab.Text = pObj.FechaMovimientoCabe;

            TextObject txtObjPer = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjPer"]);
            txtObjPer.Text = pObj.CodigoPersonal + " : " + pObj.NombrePersonal;

            TextObject txtObjAut = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjAut"]);
            txtObjAut.Text = pObj.CodigoPersonalAutoriza + " : " + pObj.NombrePersonalAutoriza;

            TextObject txtObjAux = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjAux"]);
            txtObjAux.Text = pObj.DescripcionAuxiliar;

            TextObject txtObjRuc = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjRuc"]);
            txtObjRuc.Text = pObj.CodigoAuxiliar;

            TextObject txtObjOC = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjOC"]);
            txtObjOC.Text = pObj.OrdenCompra;

            TextObject txtObjNumFac = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjNumFac"]);
            txtObjNumFac.Text = pObj.NumeroDocumento;

            TextObject txtObjGlo = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjGlo"]);
            txtObjGlo.Text = pObj.GlosaMovimientoCabe;

            TextObject txtObjTipoCambio = (TextObject)(this.CrNotaIngreso1.Section2.ReportObjects["txtObjTipoCambio"]);
            txtObjTipoCambio.Text = pObj.TipoCambio.ToString();

            //----------------
            //imprimir detalle
            //----------------

            //creamos el dataset para cargar los datos del detalle
            Impresion iDs = new Impresion();

            //traemos el reporte a mostrar en el detalle
            List<MovimientoDetaEN> iLisRep = this.ObtenerReporte(pObj);

            //pasamos los objetos de la lista  a la tabla del reporte
            foreach (MovimientoDetaEN xObj in iLisRep)
            {
                //creamos un nuevo registro
                Impresion.MovimientoDetaRow iRow;
                iRow = iDs.MovimientoDeta.NewMovimientoDetaRow();

                //pasamos datos
                iRow.CodigoExistencia = xObj.CodigoExistencia;
                iRow.DescripcionExistencia = xObj.DescripcionExistencia;
                iRow.CodigoUnidadMedida = xObj.NombreUnidadMedida;
                iRow.NombreUnidadMedida = xObj.NombreUnidadMedida;
                iRow.UbicacionExistencia = "";//xxxxxxxxxxxxx
                iRow.CantidadMovimientoDeta = xObj.CantidadMovimientoDeta;
                iRow.PrecioUnitarioMovimientoDeta = xObj.PrecioUnitarioMovimientoDeta-xObj.CostoFleteMovimientoDeta;
                iRow.Flete = xObj.CostoFleteMovimientoDeta;
                iRow.NombreArea = xObj.NCodigoArea;
                iRow.NombrePartida = xObj.NCodigoPartida;
                                
                //insertamos en la tabla del dataset
                iDs.MovimientoDeta.Rows.Add(iRow);
            }

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.CrNotaIngreso1.SetDataSource(iDs);
            this.crv1.ReportSource = this.CrNotaIngreso1;
        }

        public void ActualizarPropietario(bool pValor)
        {
            switch (eVentana)
            {
                case Ventana.wSolicitudPedido: { this.wSol.Enabled = pValor; break; }
                //case Ventana.wPartesTrabajo: { this.wParTra.Enabled = pValor; break; }
                //case Ventana.wIngresosDevolucion: { this.wIngDev.Enabled = pValor; break; }
            }
        }

        #endregion

        private void wImpNotaIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.ActualizarPropietario(true);
        }

  
    }
}
