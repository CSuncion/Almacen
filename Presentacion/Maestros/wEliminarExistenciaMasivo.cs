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
    public partial class wEliminarExistenciaMasivo : Heredados.MiForm8
    {
        public wEliminarExistenciaMasivo()
        {
            InitializeComponent();
        }

        #region Atributos

        public Universal.Opera eOperacion;
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
            this.ActualizarListaExistenciasParaEliminarBD();
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

        public void ActualizarListaExistenciasParaEliminarBD()
        {
            eLisExi = this.ListarExistenciasParaEliminarDeAlmacen();
        }

        public List<ExistenciaEN> ListarExistenciasParaEliminarDeAlmacen()
        {
            //Asignar parametros
            string iCodigoAlmacenCopia = this.txtCodAlm1.Text.Trim();
          
            //ejecutar metodo
            return ExistenciaRN.ListarExistenciasParaEliminarDeAlmacen(iCodigoAlmacenCopia);
          
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
            //validar si hay Existencias marcadas
            if (this.HayMarcados() == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Eliminar Existencias") == false) { return; }

            //agregar las Existencias marcadas
            this.EliminarExistencias();

            //mensaje satisfactorio
            Mensaje.OperacionSatisfactoria("Se eliminaron las existencias correctamente", "Existencias");

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

        public void EliminarExistencias()
        { 
            //asignar parametros
            List<ExistenciaEN> iLisExiMar = ExistenciaRN.ListarExistenciasSoloMarcadas(this.eLisExi);
            List<ExistenciaEN> iLisExiVal = this.ListarExistenciasParaEliminarDeAlmacen();
          
            //ejecutar metodo
            ExistenciaRN.EliminarExistenciasDeAlmacen( iLisExiMar, iLisExiVal);
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
            win.eCtrlFoco = this.btnFiltrarExistencia;
            win.eCondicionLista = Listas.wLisAlm.Condicion.Almacenes;
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
            iAlmEN = AlmacenRN.EsAlmacenValido(iAlmEN);
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

        public void Filtrar()
        {
            //valida campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //actualizar la grilla
            this.ActualizarListaExistenciasParaEliminarBD();
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

        private void wEliminarExistenciaMasivo_FormClosing(object sender, FormClosingEventArgs e)
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
