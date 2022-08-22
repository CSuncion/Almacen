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
using Presentacion.Maestros;
using Presentacion.FuncionesGenericas;
using Microsoft.Office.Interop.Excel;
using WinControles.Entidades;
using System.Threading;
 


namespace Presentacion.Desarrollador
{
    public partial class wMigrarProduccion : Heredados.MiForm8
    {
        public wMigrarProduccion()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Movimiento Ingreso";
        List<MovimientoDetaEN> eLisMovDet = new List<MovimientoDetaEN>();
        List<ProduccionDetaEN> eLisProDet = new List<ProduccionDetaEN>();
        List<ErrorCeldaExcel> eLisErr = new List<ErrorCeldaExcel>();

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnBusArcExc, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbHoj, "Hoja", "vfff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnValidar, "vvvf");
            xLis.Add(xCtrl);

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
            
            //Mostrar ventana        
            this.Show();
        }
             
        public void NuevaVentana()
        {
            this.InicializaVentana();           
            this.btnBusArcExc.Focus();
        }
      
        public void BuscarExcel()
        {
            //asignar parametros
            OpenFileDialog win = new OpenFileDialog();
            System.Windows.Forms.TextBox iControlRuta = txtArcExc;
            ComboBox iControlHojas = cmbHoj;
            
            //ejecutar metodo
            MiControl.MostrarRutaYHojasExcel(win, iControlRuta, iControlHojas);
        }

        public void BuscarExcel1()
        {
            //asignar parametros
            OpenFileDialog win = new OpenFileDialog();
            System.Windows.Forms.TextBox iControlRuta = txtArcExc1;
            ComboBox iControlHojas = cmbHoj1;

            //ejecutar metodo
            MiControl.MostrarRutaYHojasExcel(win, iControlRuta, iControlHojas);
        }

        public void Validar()
        {
            //campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }
                       
            //actualizar la lista de registros a importar
            this.ActualizarListaMovimientosDetaAImportar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria(this.eLisMovDet.Count.ToString(), "excel");

            this.dataGridView1.DataSource = this.eLisMovDet;       
        }

        public void Validar1()
        {
            //campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //actualizar la lista de registros a importar
            this.ActualizarListaProduccionDetaAImportar();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("ok", "excel");

            this.dataGridView1.DataSource = this.eLisProDet;
        }

        public void Aceptar()
        {
            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Importar") == false) { return; }

            //importar
            ProduccionDetaRN.MigrarProduccion(eLisMovDet, eLisProDet);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se importaron los registros correctamente", this.eTitulo);

            //cerrar esta ventana
            this.Close();
        }

        public void ActualizarListaMovimientosDetaAImportar()
        {
            //asignar parametro
            List<MovimientoDetaEN> iLisMovDet = this.TransformarExcelAListaMovimientosDeta();

            //ejecutar metodo
            //AuxiliarRN.ActualizarAuxiliaresImportacionExcelParaGrabar(iLisMovDet);

            //pasar a la lista externa
            this.eLisMovDet = iLisMovDet;
        }

        public List<MovimientoDetaEN> TransformarExcelAListaMovimientosDeta()
        {
            //obtener la hoja de la lectura de agua
            Worksheet iHoja = this.ObtenerHojaExcel();

            //lista de movimientos deta transformadas
            List<MovimientoDetaEN> iLisRes = new List<MovimientoDetaEN>();

            //recorrer cada fila del excel
            for (int i = 2; i < 100000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["A" + i].Value;
                if (iNulo == null) { break; }
                
                //si el indice fila existe en la lista de errores, entonces este registro no se carga
                if(MiExcel.ExisteIndiceFila(this.eLisErr, i.ToString()) == true) { continue; }

                //creamos un nuevo objeto MovimientoDeta
                MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();

                //actualizamos datos
                iMovDetEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovDetEN.FechaMovimientoCabe = iHoja.Range["C" + i].Text;
                iMovDetEN.OrdenCompra = iHoja.Range["D" + i].Text;
                iMovDetEN.PeriodoMovimientoCabe = iHoja.Range["F" + i].Text;
                iMovDetEN.CodigoAlmacen = iHoja.Range["G" + i].Text;
                iMovDetEN.CodigoTipoOperacion = iHoja.Range["I" + i].Text;
                iMovDetEN.CodigoAuxiliar = iHoja.Range["L" + i].Text;
                iMovDetEN.DescripcionAuxiliar = iHoja.Range["M" + i].Text;
                iMovDetEN.CTipoDocumento = iHoja.Range["N" + i].Text;
                iMovDetEN.SerieDocumento = iHoja.Range["P" + i].Text;
                iMovDetEN.NumeroDocumento = iHoja.Range["Q" + i].Text;
                iMovDetEN.FechaDocumento = iHoja.Range["R" + i].Text;
                iMovDetEN.CodigoCentroCosto = iHoja.Range["S" + i].Text;
                iMovDetEN.CodigoExistencia = iHoja.Range["U" + i].Text;
                iMovDetEN.CantidadMovimientoDeta = Convert.ToDecimal(iHoja.Range["X" + i].Value2);               
                iMovDetEN.PrecioUnitarioMovimientoDeta = Convert.ToDecimal(iHoja.Range["Y" + i].Value2);
                iMovDetEN.CostoMovimientoDeta = Convert.ToDecimal(iHoja.Range["Z" + i].Value2);
                iMovDetEN.GlosaMovimientoDeta = iHoja.Range["AA" + i].Text;
                
                //insertar a la lista resultado
                iLisRes.Add(iMovDetEN);
            }

            //destruor ala hoja
            MiExcel.EliminarHojaExcel(iHoja);

            //devolver
            return iLisRes;
        }

        public void ActualizarListaProduccionDetaAImportar()
        {
            //asignar parametro
            List<ProduccionDetaEN> iLisProDet = this.TransformarExcelAListaProduccionDeta();

            //ejecutar metodo
            //AuxiliarRN.ActualizarAuxiliaresImportacionExcelParaGrabar(iLisMovDet);

            //pasar a la lista externa
            this.eLisProDet = iLisProDet;
        }

        public List<ProduccionDetaEN> TransformarExcelAListaProduccionDeta()
        {
            //obtener la hoja de la lectura de agua
            Worksheet iHoja = this.ObtenerHojaExcel1();

            //lista de movimientos deta transformadas
            List<ProduccionDetaEN> iLisRes = new List<ProduccionDetaEN>();

            //recorrer cada fila del excel
            for (int i = 2; i < 100000; i++)
            {
                //si no hay dato en la fila , entonces se termina el bucle
                object iNulo = iHoja.Range["A" + i].Value;
                if (iNulo == null) { break; }

                //si el indice fila existe en la lista de errores, entonces este registro no se carga
                if (MiExcel.ExisteIndiceFila(this.eLisErr, i.ToString()) == true) { continue; }

                //creamos un nuevo objeto MovimientoDeta
                ProduccionDetaEN iProDetEN = new ProduccionDetaEN();

                //actualizamos datos
                iProDetEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iProDetEN.FechaProduccionDeta = iHoja.Range["A" + i].Text;
                iProDetEN.CodigoAlmacen = "A10";//Almacen de produccionxxxxxxxxxxxxxx
                iProDetEN.CodigoExistencia = iHoja.Range["B" + i].Text;
                iProDetEN.CTurno = iHoja.Range["D" + i].Text;
                iProDetEN.CantidadProduccionDeta = Convert.ToDecimal(iHoja.Range["E" + i].Value2);
                iProDetEN.CantidadRealProduccion = Convert.ToDecimal(iHoja.Range["F" + i].Value2);
                iProDetEN.NumeroUnidadesNoPasanConCal = Convert.ToDecimal(iHoja.Range["M" + i].Value2);
                iProDetEN.CodigoMercaderia = iHoja.Range["N" + i].Text;
                iProDetEN.UnidadesPorCaja = Convert.ToDecimal(iHoja.Range["O" + i].Value2);
                iProDetEN.NumeroCajas = Convert.ToDecimal(iHoja.Range["P" + i].Value2);
                iProDetEN.NumeroUnidadesSueltas = Convert.ToDecimal(iHoja.Range["Q" + i].Value2);

                //insertar a la lista resultado
                iLisRes.Add(iProDetEN);
            }

            //destruor ala hoja
            MiExcel.EliminarHojaExcel(iHoja);

            //devolver
            return iLisRes;
        }

        public Worksheet ObtenerHojaExcel()
        {
            //asignar parametros
            string iRutaArchivoExcel = txtArcExc.Text.Trim();          
            string iHojaExcel = MiExcel.ObtenerNombreHoja(this.cmbHoj.Text);
           
            //ejecutar metodo
            return MiExcel.ObtenerHojaExcel(iRutaArchivoExcel, iHojaExcel);          
        }

        public Worksheet ObtenerHojaExcel1()
        {
            //asignar parametros
            string iRutaArchivoExcel = txtArcExc1.Text.Trim();
            string iHojaExcel = MiExcel.ObtenerNombreHoja(this.cmbHoj1.Text);

            //ejecutar metodo
            return MiExcel.ObtenerHojaExcel(iRutaArchivoExcel, iHojaExcel);
        }
        
        public void Cerrar()
        {
            //obtener al wMenu
            wMenu wMen = (wMenu)this.ParentForm;
            wMen.CerrarVentanaHijo(this, wMen.IteMigrarProduccion, null);
        }

        public void Migrar()
        {
            ProduccionDetaRN.MigrarProduccion(eLisMovDet, eLisProDet);

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se importaron los registros correctamente", this.eTitulo);

            //cerrar esta ventana
            this.Close();
        }

        public void AceptarHilo()
        {
            //desea realizar la operacion
            if (Mensaje.DeseasRealizarOperacion("Importar") == false) { return; }

            //desactivar ventana
            this.Enabled = false;

            Thread iHilo = new Thread(new ThreadStart(this.Migrar));
            iHilo.Start();
            
        }

        public void Cancelar()
        {
            Generico.CancelarVentanaEditar(this, eOperacion, eMas, eTitulo);
        }

        public void FormulasRepetidasPorDia()
        {
            //listar lista de producciones por dia
            List<List<ProduccionDetaEN>> iLisLisProDet = ListaG.ListarListas<ProduccionDetaEN>(eLisProDet, ProduccionDetaEN.FecProDet);

            //variables
            int iContador = 0;
            List<ProduccionDetaEN> iLisProDet = new List<ProduccionDetaEN>();

            //recorrer cada dia
            foreach (List<ProduccionDetaEN> xLisProDet in iLisLisProDet)
            {
                //cantidad real de objetos
                int iCantidadReal = xLisProDet.Count;

                //obtener una lista con objetos no repetidos de esta lista
                List<ProduccionDetaEN> iLisProDetNoRep = ListaG.FiltrarObjetosSinRepetir<ProduccionDetaEN>(xLisProDet,
                    ProduccionDetaEN.CodExi);

                //cantidad sin repetir formula
                int iCantidadSinRepetir = iLisProDetNoRep.Count;

                //comparar
                if (iCantidadReal != iCantidadSinRepetir)
                {
                    iContador++;
                    iLisProDet.AddRange(xLisProDet);
                }
            }

            MessageBox.Show(iContador.ToString());
            dataGridView1.DataSource = iLisProDet;
        }

        #endregion


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void wImportarAuxiliar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cerrar();
        }

        private void btnBusArcExc_Click(object sender, EventArgs e)
        {
            this.BuscarExcel();         
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.AceptarHilo();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            this.Validar();
        }

        private void btnValidar1_Click(object sender, EventArgs e)
        {
            this.Validar1();
        }

        private void btnBusArcExc1_Click(object sender, EventArgs e)
        {
            this.BuscarExcel1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FormulasRepetidasPorDia();
        }
    }
}
