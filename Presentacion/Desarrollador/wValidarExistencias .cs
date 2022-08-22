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
    public partial class wValidarExistencias : Heredados.MiForm4
    {
        public wValidarExistencias()
        {
            InitializeComponent();
        }

        //variables
        string sheetNo;
        List<ExistenciaEN> eLisExiAdi = new List<ExistenciaEN>();
        List<SaldoEN> eLisSalAdi = new List<SaldoEN>();

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

        public void TransformarAExistencia(ExistenciaEN pObj, DataGridViewRow pRow)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.CodigoExistencia = pRow.Cells[21].Value.ToString();
            pObj.CodigoAlmacen = Cadena.CompletarCadena(pRow.Cells[6].Value.ToString(), 3, "0", Cadena.Direccion.Izquierda);            
            //pObj.DescripcionExistencia = pRow.Cells[3].Value.ToString();
            //pObj.CodigoUnidadMedida = this.ObtenerCodigoUnidadMedida(pRow.Cells[6].Value.ToString());
            //pObj.CCodigoUbicacion = "UBI001"; // pRow.Cells[4].Value.ToString();
            //pObj.CodigoTipo = this.ObtenerCodigoTipoExistencia( Cadena.CortarCadena(pObj.CodigoExistencia, 2, Cadena.Direccion.Izquierda));
            //pObj.CClaseExistencia = pObj.CodigoTipo;
            //pObj.CodigoGrupo = this.ObtenerCodigoGrupoExistencia(Cadena.CortarCadena(pObj.CodigoExistencia, 4, Cadena.Direccion.Izquierda));
            //pObj.CSubClaseExistencia = pObj.CodigoGrupo;
            //pObj.CEsProduccion = Cadena.CompararDosValores(pObj.CodigoTipo, "02", "1", "0");
            //pObj.CodigoArea = "";//xxxxxxxxxxxx
            //pObj.AmbienteExistencia = "";
            //pObj.CodigoMarca = "";
            //pObj.ModeloExistencia = "";
            //pObj.SerieExistencia = "";
            //pObj.CodigoColor = "";
            //pObj.CodigoCatalogo = "";
            //pObj.MedidasExistencia = "";
            //pObj.StockMinimoExistencia = 0;
            //pObj.StockAlertaExistencia = 0;
            //pObj.CEstadoExistencia = "1";//activo
            //pObj.DescripcionSecundariaExistencia = pObj.DescripcionExistencia;
            //pObj.DescripcionCortaExistencia = "...";
            pObj.ClaveExistencia = ExistenciaRN.ObtenerClaveExistencia(pObj);
            string wClave = string.Empty;
            ExistenciaEN iiExiEN = new ExistenciaEN();
            ExistenciaRN iiExiRN = new ExistenciaRN();
            iiExiEN.ClaveExistencia = pObj.ClaveExistencia;

            wClave = iiExiEN.ClaveExistencia;
             
            iiExiEN = ExistenciaRN.BuscarExistenciaXClave(iiExiEN);
            if (iiExiEN.ClaveExistencia != string.Empty)
            {

            }
            else
            {
                MessageBox.Show(wClave,"Ojazo");
            }              
        }

        public string ObtenerCodigoUnidadMedida(string pUnidadMedidaExcel)
        {
            //codigo unidad medida
            //string iCodigo = pUnidadMedidaExcel.ToUpper();
            string iCodigo = pUnidadMedidaExcel;

            //segun codigo concepto excel
            switch (iCodigo)
            {
                case "Kilogramos": return "002";
                case "Unidades": return "003";
                case "Otros (Juego)": return "004";
                case "Otros (Rollo)": return "005";             
                case "VAR": return "VAR";
                default: return string.Empty;
            }

        }

        public string ObtenerCodigoTipoExistencia(string pTipoExistenciaExcel)
        {
            //codigo unidad medida
            string iCodigo = pTipoExistenciaExcel.ToUpper();

            //segun codigo concepto excel
            switch (iCodigo)
            {
                case "PT": return "02";
                case "MP": return "03";
                case "EN": return "04";
                case "SG": return "06";
                case "EM": return "08";
                case "SE": return "09";
                case "IS": return "05";               
                default: return "09";
            }

        }

        public string ObtenerCodigoGrupoExistencia(string pCodigoGrupoExcel)
        {
            //codigo unidad medida
            string iCodigo = pCodigoGrupoExcel.ToUpper();

            //segun codigo concepto excel
            switch (iCodigo)
            {                 
                case "MPAB": return "0301";
                case "MPAD": return "0302";
                case "MPCA": return "0303";
                case "MPCO": return "0304";
                case "MPFR": return "0305";
                case "MPVE": return "0306";
                case "EMCA": return "0801";
                case "EMGE": return "0802";
                case "EMTR": return "0803";
                case "ENBL": return "0401";
                case "ENFL": return "0402";
                case "ENRI": return "0403";
                case "SGCO": return "0601";
                case "SGLI": return "0602";
                case "SGOF": return "0603";
                case "SGPA": return "0604";
                case "SGPU": return "0605";
                case "SEAR": return "0901";
                case "SEBA": return "0902";
                case "SEBS": return "0903";
                case "SEGE": return "0904";
                case "SEME": return "0905";
                case "SEMR": return "0906";
                case "SENA": return "0907";
                case "SEPO": return "0908";
                case "SEPR": return "0909";
                case "SESc": return "0910";
                case "SEWO": return "0911";
                case "PTAR": return "0201";
                case "PTBA": return "0202";
                case "PTBS": return "0203";
                case "PTGE": return "0204";
                case "PTME": return "0205";
                case "PTMR": return "0206";
                case "PTNA": return "0207";
                case "PTPO": return "0208";
                case "PTPR": return "0209";
                case "PTSc": return "0210";
                case "PTWO": return "0211";
                case "ISLI": return "0501";
                default: return "0999";
            }

        }

        public void ListarObjetos()
        {
            //traemos todos los años distintos que hay en periodos de la empresa de acceso
            List<string> iLisAñoPer = PeriodoRN.ListarAñosPeriodos();

            //recorrer cada registro de la grilla
            foreach (DataGridViewRow xRow in this.DgvImportar.Rows)
            {
                //si la primera celda del registro es vacio entonces sale del foreach
                if (xRow.Cells[0].Value == null) { return; }                             

                //transformar registro dgv a objeto
                ExistenciaEN iExiEN = new ExistenciaEN();
                this.TransformarAExistencia(iExiEN, xRow);

                //valida si la Existencia es correcta
                if (this.EsExistenciaCorrecta(iExiEN) == false) { continue; }

                //actualizar la lista que va a grabar las Existencias
                this.eLisExiAdi.Add(iExiEN);

                //lista de saldos a adicionar en bd
                List<SaldoEN> iLisSalAdi = SaldoRN.ListarNuevosSaldosAExistencia(iExiEN, iLisAñoPer);

                //adicionar a la lista resultado de saldo
                this.eLisSalAdi.AddRange(iLisSalAdi);
            }
        }

        public void GrabarObjetos()
        {
            //adicionar las Existencias
            //ExistenciaRN.AdicionarExistencia(eLisExiAdi);
            ExistenciaRN.ModificarExistencia(eLisExiAdi);

            //adicionar los saldos
            //SaldoRN.AdicionarSaldo(this.eLisSalAdi);
        }

        public void Ejecutar()
        {
            //listar objetos
            this.ListarObjetos();

            //grabar
            //this.GrabarObjetos();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("La importacion se realizo con exito", "Existencias");
                 
            ////mostrar en grilla
            //this.DgvDatos.DataSource = eLisExiAdi;

            //cerrar ventana
            //this.Close();
        }

        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteMigracionExistencias, null);   
        }

        public bool EsExistenciaCorrecta(ExistenciaEN pCuo)
        {
            //valor resultado
            bool iValor = true;

            //valida que no tenga importe Existencia
            //if (pCuo.MontoExistencia == 0) { return iValor; }

            ////valida que no tenga pago
            //if (pCuo.FechaPagoExistencia == string.Empty) { return iValor; }
        
            //ok
            return iValor;
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
