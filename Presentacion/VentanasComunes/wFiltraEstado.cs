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
using Negocio;
using Entidades;
using Comun;
using Presentacion.Procesos;

namespace Presentacion.VentanasComunes
{
    public partial class wFiltraEstado : Heredados.MiForm8
    {
        public wFiltraEstado()
        {
            InitializeComponent();
        }

        #region Enumeraciones

        public enum Ventana
        {
            wSolicitudesProduccion = 0,
            wPartesTrabajo,
            wLicitacion,
            wPlanEncajado,
            wRetiquetado       
        }

        #endregion

        #region Atributos
           
        Masivo eMas = new Masivo();
        public Ventana eVentana;
                    
        #endregion

        #region Propietarios

        //public wProduccion wPro;
        //public wParteTrabajo wParTra;
        //public wLicitacion wLic;
        public wPlanEncajado wEnc;
        public wRetiquetado wRet;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.Dtp(this.cmbEst, "vvff");
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
            //titulo ventana
            this.MostrarTitulo();

            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls();
            eMas.EjecutarTodosLosEventos();

            //Deshabilitar al propietario de esta ventana
            this.HabilitarPropietario(false);

            //cargar combo
            this.CargarCombo();

            //Mostrar ventana        
            this.Show();
        }

        public void MostrarTitulo()
        {
            switch (eVentana)
            {
                case Ventana.wSolicitudesProduccion:
                    { 
                        this.Text = "Estados Solicitud Produccion";
                        break;
                    }
                case Ventana.wPartesTrabajo:
                    {
                        this.Text = "Estados Parte Trabajo";
                        break;
                    }
                case Ventana.wLicitacion:
                    {
                        this.Text = "Estados Licitacion";
                        break;
                    }
                case Ventana.wPlanEncajado:
                    {
                        this.Text = "Estados Plan Encajado";
                        break;
                    }
                case Ventana.wRetiquetado:
                    {
                        this.Text = "Estados Retiquetados";
                        break;
                    }
            }            
        }

        public void CargarCombo()
        {
            //codigo table
            string iTabla = string.Empty;

            switch (eVentana)
            {
                case Ventana.wSolicitudesProduccion:
                    {
                        iTabla = "EsSoPr";
                        break;
                    }
                case Ventana.wPartesTrabajo:
                    {
                        iTabla = "EsPaTr";
                        break;
                    }
                case Ventana.wLicitacion:
                    {
                        iTabla = "EstReg";
                        break;
                    }
                case Ventana.wPlanEncajado:
                    {
                        iTabla = "EstEnc";
                        break;
                    }
                case Ventana.wRetiquetado:
                    {
                        iTabla = "EstRet";
                        break;
                    }
            }         

            //llenar el combo
            Cmb.Cargar(cmbEst, ItemGRN.ListarItemsGMasItemTodos(iTabla), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void MostrarDatos()
        {
            switch (eVentana)
            {
                case Ventana.wSolicitudesProduccion:
                    {
                        //Cmb.SeleccionarValorItem(cmbEst, this.wPro.tslCodFil.Text);
                        break;
                    }
                case Ventana.wPartesTrabajo:
                    {
                        //Cmb.SeleccionarValorItem(cmbEst, this.wParTra.tslCodFil.Text);
                        break;
                    }
                case Ventana.wLicitacion:
                    {
                        //Cmb.SeleccionarValorItem(cmbEst, this.wLic.tslCodFil.Text);
                        break;
                    }
                case Ventana.wPlanEncajado:
                    {
                        Cmb.SeleccionarValorItem(cmbEst, this.wEnc.tslCodFil.Text);
                        break;
                    }
                case Ventana.wRetiquetado:
                    {
                        Cmb.SeleccionarValorItem(cmbEst, this.wRet.tslCodFil.Text);
                        break;
                    }
            }                 
        }

        public void HabilitarPropietario(bool pValor)
        {
            switch (eVentana)
            {
                case Ventana.wSolicitudesProduccion:
                    {
                        //this.wPro.Enabled = pValor;
                        break;
                    }
                case Ventana.wPartesTrabajo:
                    {
                        //this.wParTra.Enabled = pValor;
                        break;
                    }
                case Ventana.wLicitacion:
                    {
                        //this.wLic.Enabled = pValor;
                        break;
                    }
                case Ventana.wPlanEncajado:
                    {
                        this.wEnc.Enabled = pValor;
                        break;
                    }
                case Ventana.wRetiquetado:
                    {
                        this.wRet.Enabled = pValor;
                        break;
                    }
            }                 
        }

        public void NuevaVentana()
        {
            this.InicializaVentana();
            this.MostrarDatos();
            this.cmbEst.Focus();
        }
                        
        public void Aceptar()
        {  
            //actualizar propietario
            this.ActualizarPropietario();

            //cerrar
            this.Close();
        }

        public void ActualizarPropietario()
        {
            switch (eVentana)
            {
                case Ventana.wSolicitudesProduccion:
                    {
                        //this.wPro.tslCodFil.Text = Cmb.ObtenerValor(cmbEst, "");
                        //this.wPro.tslNomFil.Text = cmbEst.Text;
                        //this.wPro.ActualizarVentana();
                        this.HabilitarPropietario(true);
                        break;
                    }
                case Ventana.wPartesTrabajo:
                    {
                        //this.wParTra.tslCodFil.Text = Cmb.ObtenerValor(cmbEst, "");
                        //this.wParTra.tslNomFil.Text = cmbEst.Text;
                        //this.wParTra.ActualizarVentana();
                        this.HabilitarPropietario(true);
                        break;
                    }
                case Ventana.wLicitacion:
                    {
                        //this.wLic.tslCodFil.Text = Cmb.ObtenerValor(cmbEst, "");
                        //this.wLic.tslNomFil.Text = cmbEst.Text;
                        //this.wLic.ActualizarVentana();
                        this.HabilitarPropietario(true);
                        break;
                    }
                case Ventana.wPlanEncajado:
                    {
                        this.wEnc.tslCodFil.Text = Cmb.ObtenerValor(cmbEst, "");
                        this.wEnc.tslNomFil.Text = cmbEst.Text;
                        this.wEnc.ActualizarVentana();
                        this.HabilitarPropietario(true);
                        break;
                    }
                case Ventana.wRetiquetado:
                    {
                        this.wRet.tslCodFil.Text = Cmb.ObtenerValor(cmbEst, "");
                        this.wRet.tslNomFil.Text = cmbEst.Text;
                        this.wRet.ActualizarVentana();
                        this.HabilitarPropietario(true);
                        break;
                    }
            }        
           
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wCambiarEstado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.HabilitarPropietario(true);
        }

    }
}
