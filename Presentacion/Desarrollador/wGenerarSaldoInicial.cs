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
using Entidades.Adicionales;
using Entidades;
using Negocio;
using Presentacion.Principal;
using System.Data.OleDb;
using Comun;

namespace Presentacion.Desarrollador
{
    public partial class wGenerarSaldoInicial : Heredados.MiForm4
    {
        public wGenerarSaldoInicial()
        {
            InitializeComponent();
        }

        //variables
        string sheetNo;
        List<MovimientoDetaEN> eLisMovDetAdi = new List<MovimientoDetaEN>();
        MovimientoCabeEN eMovCabAdi = new MovimientoCabeEN();

        #region General


        public void NuevaVentana()
        {
            this.Show();              
        }

        private void CargarHojasDeExcel()
        {
            //asignar parametro
            OpenFileDialog iWin = new OpenFileDialog();
            TextBox iTxt = this.txtLoad;
            ComboBox iCmb = this.cmbHojas;

            //ejecutar metodo
            MiControl.MostrarRutaYHojasExcel(iWin, iTxt, iCmb);
        }

        public void LoadExcel(DataGridView pDgv, string pBook, string pSheet)
        {         
            string Cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pBook + @";Extended Properties=""Excel 12.0 Xml;;HDR=YES;""";
            try
            {
                OleDbConnection Cn = new OleDbConnection(Cs);
                if (!System.IO.File.Exists(pBook))
                {
                    Mensaje.OperacionDenegada("No se encontro el libro " + pBook, "Libro Excel");
                    this.DgvImportar.Rows.Clear();
                    this.dgvExcel.DataSource = null;
                    return;
                }

                //seleccionamos todos los registros que contiene la hoja del excel
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from [" + pSheet + "]", Cs);
                DataSet ds = new DataSet();
                da.Fill(ds);
                this.dgvExcel.DataSource = ds.Tables[0];
                this.DgvImportar.Rows.Clear();
                this.DgvImportar.DataSource = ds.Tables[0];
                //habilitar botones

            }
            catch (Exception ex)
            {
                Mensaje.OperacionDenegada(ex.Message, "Hoja excel");
                this.dgvExcel.DataSource = null;
                this.DgvImportar.Rows.Clear();          
            }

        }

        public string ObtenerCodigoUnidadMedida(string pUnidadMedidaExcel)
        {
            //codigo unidad medida
            string iCodigo = pUnidadMedidaExcel.ToUpper();

            //segun codigo concepto excel
            switch (iCodigo)
            {
                case "1": return "1";
                case "26": return "26";
                case "CON": return "CON";
                case "FAM": return "FAM";
                case "JGO": return "JGO";
                case "JGS": return "JGS";
                case "KG": return "KG";
                case "KGM": return "KGM";
                case "KGS": return "KGS";
                case "KLG": return "KLG";
                case "MET": return "MET";
                case "MTR": return "MTR";
                case "MTS": return "MTS";
                case "PAQ": return "PAQ";
                case "PAR": return "PAR";
                case "UND": return "UND";
                case "UNI": return "UND";
                case "VAR": return "VAR";
                default: return string.Empty;
            }

        }

        public void ListarObjetos()
        {
            //actualizando sus datos(MovimientoCabe)
            eMovCabAdi.CodigoEmpresa = Universal.gCodigoEmpresa;
            eMovCabAdi.PeriodoMovimientoCabe = "2018-01";
            eMovCabAdi.CodigoAlmacen = "001";
            eMovCabAdi.CodigoTipoOperacion = "16";//saldo inicial
            eMovCabAdi.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(eMovCabAdi);
            eMovCabAdi.FechaMovimientoCabe = "01/01/2018";
            eMovCabAdi.CodigoPersonal = "";//xxxxxxxxxxxxxxxxxx
            eMovCabAdi.CodigoAuxiliar = string.Empty;
            eMovCabAdi.CTipoDocumento = string.Empty;
            eMovCabAdi.SerieDocumento = string.Empty;
            eMovCabAdi.NumeroDocumento = string.Empty;
            eMovCabAdi.FechaDocumento = string.Empty;
            eMovCabAdi.GlosaMovimientoCabe = "Saldo Partida";
            eMovCabAdi.COrigenVentanaCreacion = "1";//Ingreso
            eMovCabAdi.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(eMovCabAdi);

            //correlativo para los MovimientosDeta
            string iCorrelativoMovimientoDeta = "0000";

            //recorrer cada registro de la grilla
            foreach (DataGridViewRow xRow in this.DgvImportar.Rows)
            {
                //si la primera celda del registro es vacio entonces sale del foreach
                if (xRow.Cells[0].Value == null) { return; }

                //si el stock es cero, pasa al siguiente registro
                if (Convert.ToDecimal(xRow.Cells[10].Value.ToString()) == 0) { continue; }

                //incrementar el correlativo
                iCorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoMovimientoDeta);

                //transformar registro dgv a objeto
                MovimientoDetaEN iMovDetAdi = new MovimientoDetaEN();

                //actualizando sus datos(MovimientoDeta)
                iMovDetAdi.NumeroMovimientoCabe = eMovCabAdi.NumeroMovimientoCabe;
                iMovDetAdi.ClaveMovimientoCabe = eMovCabAdi.ClaveMovimientoCabe;
                iMovDetAdi.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                iMovDetAdi.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetAdi);
                iMovDetAdi.CodigoEmpresa = eMovCabAdi.CodigoEmpresa;
                iMovDetAdi.FechaMovimientoCabe = eMovCabAdi.FechaMovimientoCabe;
                iMovDetAdi.PeriodoMovimientoCabe = eMovCabAdi.PeriodoMovimientoCabe;
                iMovDetAdi.CodigoAlmacen = eMovCabAdi.CodigoAlmacen;
                iMovDetAdi.CodigoTipoOperacion = eMovCabAdi.CodigoTipoOperacion;
                iMovDetAdi.CodigoAuxiliar = eMovCabAdi.CodigoAuxiliar;
                iMovDetAdi.CTipoDocumento = eMovCabAdi.CTipoDocumento;
                iMovDetAdi.SerieDocumento = eMovCabAdi.SerieDocumento;
                iMovDetAdi.NumeroDocumento = eMovCabAdi.NumeroDocumento;
                iMovDetAdi.FechaDocumento = eMovCabAdi.FechaDocumento;
                iMovDetAdi.CodigoCentroCosto = "";//xxxxxxxxxxxxxxxxx
                iMovDetAdi.CodigoExistencia = xRow.Cells[0].Value.ToString();
                iMovDetAdi.CodigoUnidadMedida = this.ObtenerCodigoUnidadMedida(xRow.Cells[0].Value.ToString());
                iMovDetAdi.PrecioUnitarioMovimientoDeta = Convert.ToDecimal( xRow.Cells[19].Value.ToString());
                iMovDetAdi.CantidadMovimientoDeta = Convert.ToDecimal(xRow.Cells[10].Value.ToString());
                iMovDetAdi.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetAdi);
                iMovDetAdi.GlosaMovimientoDeta = eMovCabAdi.GlosaMovimientoCabe;

                //actualizar la lista que va a grabar
                this.eLisMovDetAdi.Add(iMovDetAdi);                
            }
        }

        public void GrabarObjetos()
        {
            //adicionar el movimientio cabe
            MovimientoCabeRN.AdicionarMovimientoCabe(this.eMovCabAdi);

            //adicionar los movimientos deta
            MovimientoDetaRN.AdicionarMovimientoDeta(this.eLisMovDetAdi);
        }

        public void Ejecutar()
        {
            //listar objetos
            this.ListarObjetos();

            //grabar
            this.GrabarObjetos();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La importacion se realizo con exito", "Existencias");

            ////mostrar en grilla
            //this.DgvDatos.DataSource = eLisMovDetAdi;

            //cerrar ventana
            this.Close();
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteMigracionExistencias, null);   
        }


        #endregion


     
        private void wMigrarExistencias_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {           
            this.CargarHojasDeExcel();
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            if (this.txtLoad.Text.Trim() == string.Empty)
            {
                Mensaje.OperacionDenegada("Debes buscar el archivo Excel", "Excel");
                return;
            }
         
            sheetNo = this.cmbHojas.Text;

            if (sheetNo == string.Empty)
            {
                Mensaje.OperacionDenegada("No hay hoja", "Excel");
                return;
            }

            //aqui cargarmos el dgvExcel que viene hacer como la fuente de datos
            //esta grilla no se ve en pantalla
            this.LoadExcel(this.DgvImportar, this.txtLoad.Text, sheetNo);     
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            this.Ejecutar();
        }
     
       
    }
}
