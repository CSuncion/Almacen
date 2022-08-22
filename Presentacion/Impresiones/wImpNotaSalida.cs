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

namespace Presentacion.Impresiones
{
    public partial class wImpNotaSalida : Heredados.MiForm8
    {
        public wImpNotaSalida()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Ventana
        {
            wSalidas = 0,
            wPartesTrabajo,
            wMovimientos,
            wInventarios,
            wSalidasAdicionales,
            wSalidasAdicionalesEncajado,
            wSalidaParteFaseEmpaquetado,
        }

        #endregion

        #region Atributos
             
        public Ventana eVentana;

        #endregion

        #region Propietario

        public wSalidas wSal;
        //public wParteTrabajo wParTra;
        public wMovimientos wMov;
        public wInventario wInv;
        //public wSalidasAdicionales wSalAdi;
        public wSalidasAdicionalesEncajado wSalAdiEnc;
        public wSalidasParteFaseEmpaquetado wSalParFasEmp;

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
                case Ventana.wSalidas: { TabCtrl.InsertarVentana(this.wSal, this, 94); break; }
                //case Ventana.wPartesTrabajo: { TabCtrl.InsertarVentana(this.wParTra, this, 94); break; }
                case Ventana.wMovimientos: { TabCtrl.InsertarVentana(this.wMov, this, 94); break; }
                case Ventana.wInventarios: { TabCtrl.InsertarVentana(this.wInv, this, 94); break; }
                //case Ventana.wSalidasAdicionales: { TabCtrl.InsertarVentana(this.wSalAdi, this, 94); break; }
                case Ventana.wSalidasAdicionalesEncajado: { TabCtrl.InsertarVentana(this.wSalAdiEnc, this, 94); break; }
                case Ventana.wSalidaParteFaseEmpaquetado: { TabCtrl.InsertarVentana(this.wSalParFasEmp, this, 94); break; }
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
            TextObject txtObjAlm = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjAlm"]);
            txtObjAlm.Text = pObj.CodigoAlmacen + " : " + pObj.DescripcionAlmacen;

            TextObject txtObjTipOpe = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjTipOpe"]);
            txtObjTipOpe.Text = pObj.CodigoTipoOperacion + " : " + pObj.DescripcionTipoOperacion;

            TextObject txtObjCorMovDet = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjCorMovDet"]);
            txtObjCorMovDet.Text = pObj.NumeroMovimientoCabe;

            TextObject txtObjFecMovCab = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjFecMovCab"]);
            txtObjFecMovCab.Text = pObj.FechaMovimientoCabe;

            TextObject txtObjPer = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjPer"]);
            txtObjPer.Text = pObj.CodigoPersonal + " : " + pObj.NombrePersonal;

            TextObject txtObjPerAut = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjPerAut"]);
            txtObjPerAut.Text = pObj.CodigoPersonalAutoriza + " : " + pObj.NombrePersonalAutoriza;

            TextObject txtObjAux = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjAux"]);
            txtObjAux.Text = pObj.DescripcionAuxiliar;

            TextObject txtObjPerRec = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjPerRec"]);
            txtObjPerRec.Text = pObj.CodigoPersonalRecibe + " : " + pObj.NombrePersonalRecibe;

            TextObject txtObjGlo = (TextObject)(this.CrNotaSalida1.Section2.ReportObjects["txtObjGlo"]);
            txtObjGlo.Text = pObj.GlosaMovimientoCabe;

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
                iRow.PrecioUnitarioMovimientoDeta = xObj.PrecioUnitarioMovimientoDeta;
                iRow.NombreArea = xObj.NCodigoArea;
                iRow.NombrePartida = xObj.NCodigoPartida;
                                
                //insertamos en la tabla del dataset
                iDs.MovimientoDeta.Rows.Add(iRow);
            }

            //-----------------------------------
            //visualizar el reporte en la ventana
            //-----------------------------------
            this.CrNotaSalida1.SetDataSource(iDs);
            this.crv1.ReportSource = this.CrNotaSalida1;
        }

        public void ActualizarPropietario(bool pValor)
        {
            switch (eVentana)
            {
                case Ventana.wSalidas: { this.wSal.Enabled = pValor; break; }
                //case Ventana.wPartesTrabajo: { this.wParTra.Enabled = pValor; break; }
                //case Ventana.wSalidasAdicionales: { this.wSalAdi.Enabled = pValor; break; }
                case Ventana.wSalidaParteFaseEmpaquetado: { this.wSalParFasEmp.Enabled = pValor; break; }
            }
        }

        #endregion

        private void wImpNotaSalida_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.ActualizarPropietario(true);
        }

  
    }
}
