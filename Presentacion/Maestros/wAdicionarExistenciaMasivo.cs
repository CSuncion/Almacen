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
using Entidades;
using Negocio;
using Presentacion.Listas;

namespace Presentacion.Maestros
{
    public partial class wAdicionarExistenciaMasivo : Heredados.MiForm8
    {
        public wAdicionarExistenciaMasivo()
        {
            InitializeComponent();
        }

        #region Atributos

        //public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<ExistenciaEN> eLisExi = new List<ExistenciaEN>();

        #endregion  
     
        #region Propietario

        public wExistencia wExi;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm1, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm1, this.txtCodAlm1, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodAlm2, true, "Almacen", "vfff", 3);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesAlm2, this.txtCodAlm2, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnFiltrarExistencia, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnMarcarTodas, "vvvf");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Btn(this.btnDesmarcarTodas, "vvvf");
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
         
            //Deshabilitar al propietario de esta ventana
            this.wExi.Enabled = false;
                     
            //Mostrar ventana
            this.Show();            
        }                

        public void NuevaVentana()
        {
            this.InicializaVentana();            
            this.ActualizarListaExistenciasParaBD();
            this.ActualizarDgvExi();
            this.txtCodAlm1.Focus();
        }

        public void ActualizarDgvExi()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvExi;
            List<ExistenciaEN> iFuenteDatos = eLisExi;
            Dgv.Franja iCondicionFranja = Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvExi();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public List<DataGridViewColumn> ListarColumnasDgvExi()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaCheckBox(ExistenciaEN.VerFal, "Seleccionar", 85));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.CodExi, "Codigo", 70));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.DesExi, "Descripcion", 200));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(ExistenciaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }

        public void ActualizarListaExistenciasParaBD()
        {
            eLisExi = this.ListarExistenciasParaCopiaAAlmacen();
        }

        public List<ExistenciaEN> ListarExistenciasParaCopiaAAlmacen()
        {
            //Asignar parametros
            string iCodigoAlmacenCopia = this.txtCodAlm1.Text.Trim();
            string iCodigoAlmacenGuarda = this.txtCodAlm2.Text.Trim();

            //ejecutar metodo
            return ExistenciaRN.ListarExistenciasParaCopiarAAlmacen(iCodigoAlmacenCopia, iCodigoAlmacenGuarda);
        }

        public void ModificarExistencia()
        {
            //asignar parametros
            ExistenciaEN iCuoEN = new ExistenciaEN();
            iCuoEN.ClaveExistencia = Dgv.ObtenerValorCelda(this.DgvExi, ExistenciaEN.ClaObj);
            iCuoEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvExi, VentanaBotonEN.VerFal);

            //ejecutar metodo
            ExistenciaRN.ModificarVerdadFalsoExistencia(iCuoEN, this.eLisExi);
        }
        
        public void Aceptar()
        {
            //validar campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //validar si hay Existencias marcadas
            if (this.HayMarcados() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Existencias") == false) { return; }

            //agregar las Existencias marcadas
            this.AgregarExistencias();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se agregaron las existencias correctamente", "Existencias");

            //actualizar ventana propietario
            this.wExi.ActualizarVentana();

            //cerrar
            this.Close();
        }
               
        public bool HayMarcados()
        {
            ExistenciaEN iCuoMarEN = ExistenciaRN.HayObjetosMarcados(eLisExi);
            if (iCuoMarEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iCuoMarEN.Adicionales.Mensaje, this.wExi.eTitulo);               
            }
            return iCuoMarEN.Adicionales.EsVerdad;  
        }

        public void AgregarExistencias()
        { 
            //asignar parametros
            List<ExistenciaEN> iLisExiMar = ExistenciaRN.ListarExistenciasSoloMarcadas(this.eLisExi);
            List<ExistenciaEN> iLisExiVal = this.ListarExistenciasParaCopiaAAlmacen();
            string iCodigoAlmacenGuarda = this.txtCodAlm2.Text.Trim();

            //ejecutar metodo
            ExistenciaRN.AdicionarExistenciasPorCopia(iCodigoAlmacenGuarda, iLisExiMar, iLisExiVal);
        }

        public void ListarAlmacenes1()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm1.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm1;
            win.eCtrlFoco = this.txtCodAlm2;
            win.eAlmEN.CodigoAlmacen = this.txtCodAlm2.Text.Trim();
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesExceptoUno;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacen1Valido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm1.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm1.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            string iCodigoAlmacenExcepcion = this.txtCodAlm2.Text.Trim();
            iAlmEN = AlmacenRN.EsAlmacenValido(iAlmEN, iCodigoAlmacenExcepcion);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wExi.eTitulo);
                this.txtCodAlm1.Focus();
            }

            //mostrar datos
            this.txtCodAlm1.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm1.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void ListarAlmacenes2()
        {
            //si es de lectura , entonces no lista
            if (this.txtCodAlm2.ReadOnly == true) { return; }

            //instanciar
            wLisAlm win = new wLisAlm();
            win.eVentana = this;
            win.eTituloVentana = "Almacenes";
            win.eCtrlValor = this.txtCodAlm2;
            win.eCtrlFoco = this.btnFiltrarExistencia;
            win.eAlmEN.CodigoAlmacen = this.txtCodAlm1.Text.Trim();
            win.eCondicionLista = Listas.wLisAlm.Condicion.AlmacenesExceptoUno;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsAlmacen2Valido()
        {
            //si es de lectura , entonces no lista
            if (txtCodAlm2.ReadOnly == true) { return true; }

            //validar el numerocontrato del lote
            AlmacenEN iAlmEN = new AlmacenEN();
            iAlmEN.CodigoAlmacen = this.txtCodAlm2.Text.Trim();
            iAlmEN.ClaveAlmacen = AlmacenRN.ObtenerClaveAlmacen(iAlmEN);
            string iCodigoAlmacenExcepcion = this.txtCodAlm1.Text.Trim();
            iAlmEN = AlmacenRN.EsAlmacenValido(iAlmEN, iCodigoAlmacenExcepcion);
            if (iAlmEN.Adicionales.EsVerdad == false)
            {
                Mensaje.OperacionDenegada(iAlmEN.Adicionales.Mensaje, this.wExi.eTitulo);
                this.txtCodAlm2.Focus();
            }

            //mostrar datos
            this.txtCodAlm2.Text = iAlmEN.CodigoAlmacen;
            this.txtDesAlm2.Text = iAlmEN.DescripcionAlmacen;

            //devolver
            return iAlmEN.Adicionales.EsVerdad;
        }

        public void Filtrar()
        {
            //valida campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //validar que los campos almacen no sean iguales
            if (this.EsAlmacen2Valido() == false) { return; }

            //actualizar la grillaa
            this.ActualizarListaExistenciasParaBD();
            this.ActualizarDgvExi();
        }

        public void MarcarTodos()
        {
            ExistenciaRN.MarcarTodos(this.eLisExi, true);
            this.ActualizarDgvExi();
        }

        public void DesmarcarTodos()
        {
            ExistenciaRN.MarcarTodos(this.eLisExi, false);
            this.ActualizarDgvExi();
        }

        #endregion

        private void wAdicionarExistenciaMasivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wExi.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvExi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarExistencia();
        }

        private void txtCodAlm1_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacen1Valido();
        }

        private void txtCodAlm1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes1(); }
        }

        private void txtCodAlm1_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes1();
        }

        private void txtCodAlm2_Validating(object sender, CancelEventArgs e)
        {
            this.EsAlmacen2Valido();
        }

        private void txtCodAlm2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarAlmacenes2(); }
        }

        private void txtCodAlm2_DoubleClick(object sender, EventArgs e)
        {
            this.ListarAlmacenes2();
        }

        private void btnFiltrarExistencia_Click(object sender, EventArgs e)
        {
            this.Filtrar();
        }

        private void btnMarcarTodas_Click(object sender, EventArgs e)
        {
            this.MarcarTodos();
        }

        private void btnDesmarcarTodas_Click(object sender, EventArgs e)
        {
            this.DesmarcarTodos();
        }
    }
}
