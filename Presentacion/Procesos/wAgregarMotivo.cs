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


namespace Presentacion.Procesos
{
    public partial class wAgregarMotivo : Heredados.MiForm8
    {
        public wAgregarMotivo()
        {
            InitializeComponent();
        }

        #region Variables

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        List<ItemGEN> eLisIteG = new List<ItemGEN>();
        
        #endregion
        
        #region Propietario

        public wMotivoLiberacion wMotLib;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;                                  

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
         
            // Deshabilitar al propietario de esta ventana
            this.wMotLib.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }                

        public void VentanaAgregar()
        {
            this.InicializaVentana();
            this.Text = "Agregar Motivos";
            this.lblTit.Text = "Motivos para agregar a la ventana";         
            this.ActualizarDgvMot(true);
            this.btnAceptar.Focus();
        }

        public void VentanaQuitar()
        {
            this.InicializaVentana();
            this.Text = "Quitar Motivos";
            this.lblTit.Text = "Motivos para quitar a la ventana";
            this.ActualizarDgvMot(true);
            this.btnAceptar.Focus();
        }

        public void ActualizarDgvMot(bool pBaseDatos)
        {
            //solo si va a base de datos entra
            if (pBaseDatos == true)
            {
                ////segun agregar o quitar
                //if (this.eOperacion == Universal.Opera.Adicionar)
                //{
                //    eLisIteG = ItemGRN.ListarItemsGTablaNoSeleccionadasEnGrilla(this.wMotLib.eTipoMotivo, this.wMotLib.eLisMotLib);
                //}
                //else
                //{
                //    eLisIteG = ListaG.Clonar<ItemGEN>(this.wMotLib.eLisMotLib);
                //}
            }                

            //cargar grilla
            Dgv iDgv = new Dgv();
            iDgv.MiDgv = this.DgvBot;
            iDgv.RefrescarDatosGrilla(ListaG.Refrescar<ItemGEN>(eLisIteG));

            //asignar columnas
            iDgv.AsignarColumnaCheckBox(ItemGEN.VerFal, "Agregar", 57);
            iDgv.AsignarColumnaTextCadena(ItemGEN.CodIteG, "Codigo", 65);
            iDgv.AsignarColumnaTextCadena(ItemGEN.NomIteG, "Descripcion", 310);            
            iDgv.AsignarColumnaTextCadena(ItemGEN.ClaObj, "ClaveObjeto", 10, false);
        }

        public void ModificarItemG()
        {
            ItemGEN iIteGEN = new ItemGEN();
            iIteGEN.ClaveItemG = Dgv.ObtenerValorCelda(this.DgvBot, ItemGEN.ClaObj);
            iIteGEN.VerdadFalso = Dgv.ObtenerValorCeldaCheckBox(this.DgvBot, ItemGEN.VerFal);
            ItemGRN.ModificarItemG(iIteGEN, this.eLisIteG);
        }
        
        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Agregar(); break; }               
                case Universal.Opera.Eliminar: { this.Quitar(); break; }
                default: break;
            }
        }

        public void Agregar()
        { 
            //sacar solo los que marco el usuario
            List<ItemGEN> iLisObjMar = this.SacarSoloMarcados();                    

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Agregar Motivos") == false) { return; }

            //agregar los nuevos motivos marcados
            this.AdicionarItemG(iLisObjMar);

            //actualizar campo del propietario
            this.ActualizarCampoDetalleMotivo();
                       
            //actualizar ventana propietario
            this.wMotLib.ActualizarDgvMot();
            
            //cerrar
            this.Close();
        }

        public void AdicionarItemG(List<ItemGEN> pLista)
        {
            //this.wMotLib.eLisMotLib.AddRange(pLista);
            //ItemGRN.MarcarTodos(pLista, false);
        }

        public void ActualizarCampoDetalleMotivo()
        {
            ////asignar parametro
            //string iCampoDetalleMotivo = LiberacionRN.ConvertirListaACampoDetalleMotivo(this.wMotLib.eLisMotLib);

            ////ejecutar metodo(segun tipoMotivo)
            //switch (this.wMotLib.eTipoMotivo)
            //{
            //    case "MotRep": this.wMotLib.wEdiLib.eLibMotEN.DetalleMotivoReproceso = iCampoDetalleMotivo; break;
            //    case "MotDon": this.wMotLib.wEdiLib.eLibMotEN.DetalleMotivoDonacion = iCampoDetalleMotivo; break;
            //    case "MotMue": this.wMotLib.wEdiLib.eLibMotEN.DetalleMotivoMuestra = iCampoDetalleMotivo; break;
            //    case "MotDes": this.wMotLib.wEdiLib.eLibMotEN.DetalleMotivoDesecho = iCampoDetalleMotivo; break;
            //}
        }

        public void Quitar()
        {
            //sacar solo los que marco el usuario
            List<ItemGEN> iLisObjMar = this.SacarSoloMarcados();

            //hay marcadas
            if (this.HayMarcados(iLisObjMar) == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion("Quitar Motivos") == false) { return; }

            //quitar los motivos
            //ItemGRN.EliminarItemG(this.wMotLib.eLisMotLib, iLisObjMar);

            //actualizar campo del propietario
            this.ActualizarCampoDetalleMotivo();

            //actualizar ventana propietario
            this.wMotLib.ActualizarDgvMot();

            //cerrar
            this.Close();
        }

        public void MarcarTodos()
        {
            ItemGRN.MarcarTodos(this.eLisIteG, true);
            this.ActualizarDgvMot(false);
        }

        public void DesmarcarTodos()
        {
            ItemGRN.MarcarTodos(this.eLisIteG, false);
            this.ActualizarDgvMot(false);
        }

        public List<ItemGEN> SacarSoloMarcados()
        {
            //esta operacion actualiza a la lista eLisVenBot,obteniendo solo
            //los objetos marcados por el usuario
            return ItemGRN.ListarItemGENSoloMarcadas(this.eLisIteG);
        }

        public bool HayMarcados(List<ItemGEN> pLista)
        {
           //ver si hay marcados
            if (pLista.Count == 0)
            {
                Mensaje.OperacionDenegada("Debes marcar al menos un motivo, no se puede realizar la operacion","Motivos");
                return false;
            }
            return true;           
        }
     
        #endregion

        private void wAgregarMotivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wMotLib.Enabled = true;           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvBot_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.ModificarItemG();
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
