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
using Presentacion.Procesos;
using Presentacion.Consultas;
using Presentacion.ProcesosCompras;

namespace Presentacion.Impresiones
{
    public partial class wImpOrdenServicio : Heredados.MiForm8
    {
        public wImpOrdenServicio()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Ventana
        {
            wOrdenServicio
        }

        #endregion

        #region Atributos

        public Ventana eVentana;
        public string wOrigenVentana;

        #endregion

        #region Propietario

        public wOrdenServicio wOrdSer;

        #endregion

        #region General

        public void NuevaVentana(MovimientoOCCabeEN pObj)
        {
            this.Imprimir(pObj);
            this.InsertarVentana();
            this.Show();
        }

        public void InsertarVentana()
        {
            switch (eVentana)
            {
                case Ventana.wOrdenServicio: { TabCtrl.InsertarVentana(this.wOrdSer, this, 94); break; }
            }
        }

        public List<MovimientoOCDetaEN> ObtenerReporte(MovimientoOCCabeEN pObj)
        {
            //asignar parametros
            string iClaveMovimientoCabe = pObj.ClaveMovimientoCabe;

            //ejecutar metodo
            return MovimientoOCDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iClaveMovimientoCabe);
        }

        public void Imprimir(MovimientoOCCabeEN pObj)
        {
            //-----------------
            //imprimir cabecera
            //-----------------
            TextObject txtObjAlm = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = pObj.CodigoAlmacen + " : " + pObj.DescripcionAlmacen;

            TextObject txtObjTipOpe = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjTipOpe"]);
            txtObjTipOpe.Text = pObj.CTipoServicio + " : " + pObj.NTipoServicio;

            TextObject txtObjCorMovDet = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjCorMovDet"]);
            txtObjCorMovDet.Text = pObj.NumeroMovimientoCabe;

            TextObject txtObjFecMovCab = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjFecMovCab"]);
            txtObjFecMovCab.Text = pObj.FechaMovimientoCabe;

            TextObject txtObjPer = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjPer"]);
            txtObjPer.Text = pObj.CodigoPersonal + " : " + pObj.NombrePersonal;

            TextObject txtObjGarantia = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjGarantia"]);
            txtObjGarantia.Text = pObj.Garantia.ToString();

            TextObject txtObjValCotiz = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjValCotiz"]);
            txtObjValCotiz.Text = pObj.ValidezCotizacion.ToString();

            TextObject txtObjPlazo = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjPlazo"]);
            txtObjPlazo.Text = pObj.PlazoEntrega.ToString();

            TextObject txtObjAux = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjAux"]);
            txtObjAux.Text = pObj.DescripcionAuxiliar;

            TextObject txtObjRuc = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjRuc"]);
            txtObjRuc.Text = pObj.CodigoAuxiliar;

            TextObject txtObjGlo = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjGlo"]);
            txtObjGlo.Text = pObj.GlosaMovimientoCabe;

            TextObject txtObjTipoCambio = (TextObject)(this.CrOrdenServicio1.Section2.ReportObjects["txtObjTipoCambio"]);
            txtObjTipoCambio.Text = pObj.TipoCambio.ToString();

            //----------------
            //imprimir detalle
            //----------------

            //creamos el dataset para cargar los datos del detalle
            Impresion iDs = new Impresion();

            //traemos el reporte a mostrar en el detalle
            List<MovimientoOCDetaEN> iLisRep = this.ObtenerReporte(pObj);

            //pasamos los objetos de la lista  a la tabla del reporte
            foreach (MovimientoOCDetaEN xObj in iLisRep)
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
                iRow.PrecioUnitarioMovimientoDeta = xObj.PrecioUnitarioMovimientoDeta - xObj.CostoFleteMovimientoDeta;
                iRow.Flete = xObj.CostoFleteMovimientoDeta;
                iRow.NombreArea = xObj.DescripcionCentroCosto;
                iRow.NombrePartida = xObj.NCodigoPartida;

                //insertamos en la tabla del dataset
                iDs.MovimientoDeta.Rows.Add(iRow);
            }

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.CrOrdenServicio1.SetDataSource(iDs);
            this.crv1.ReportSource = this.CrOrdenServicio1;
        }

        public void ActualizarPropietario(bool pValor)
        {
            switch (eVentana)
            {
                case Ventana.wOrdenServicio: { this.wOrdSer.Enabled = pValor; break; }
            }
        }

        #endregion

        private void wImpOrdenServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.ActualizarPropietario(true);
        }


    }
}
