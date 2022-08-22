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
using Presentacion.ModuloMaestros;
using Presentacion.Maestros;



namespace Presentacion.ModuloMaestros
{
    public partial class wEditBancos : Heredados.MiForm4
    {
        public wEditBancos()
        {
            InitializeComponent();
        }

        //variables
        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Banco";

        // Regla de Negocio
        ItemGRN eIteRN = new ItemGRN();

        #region Propietario
        
        public wBancos wBco ;

        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls()
        {
            List<ControlEditar> xLis = new List<ControlEditar>();
            ControlEditar xCtrl;

            //xCtrl = new ControlEditar();
            //xCtrl.txtNoFoco(this.txtCodEmp, this.txtCodPro, "ffff");           
            //xLis.Add(xCtrl);

            //xCtrl = new ControlEditar();
            //xCtrl.txtNoFoco( this.txtNomEmp , this.txtCodPro , "ffff" );         
            //xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.TxtNumeroSinEspacion( this.txtCodBco ,true, "Codigo" , "vfff" );
            xLis.Add( xCtrl );         

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo( this.txtNomBco , true, "Nombre" , "VVFF" );          
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroSinEspacion( this.txtCodSun , true, "Cuenta" , "VVff" );          
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.Cmb(this.cmbEstBco, "vvff");
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

            //llenar combos
            this.CargarEstadosBanco();

            // Deshabilitar al propietario de esta ventana
            this.wBco.Enabled = false;
                                
            // Mostrar ventana        
            this.Show();
        }
        
        public void CargarEstadosBanco()
        {
            Cmb.Cargar(this.cmbEstBco, ItemGRN.ListarItemsG("EstReg"), ItemGEN.CodIteG, ItemGEN.NomIteG);
        }

        public void VentanaAdicionar()
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Adicionar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarBanco(BancoRN.EnBlanco());
            this.txtCodBco.Focus();
            eMas.AccionHabilitarControles(0);
            eMas.AccionPasarTextoPrincipal();
        }
        
        public void VentanaModificar(BancoEN pBco)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Modificar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarBanco(pBco);
            //this.tbcLote.SelectedTab = this.tbpLinderos;
            this.txtNomBco.Focus();
            eMas.AccionHabilitarControles(1);
            eMas.AccionPasarTextoPrincipal();
        }
        
        public void VentanaEliminar(BancoEN pBco)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Eliminar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarBanco(pBco);
            this.btnAceptar.Focus();
            eMas.AccionHabilitarControles(2);
        }
        
        public void VentanaVisualizar(BancoEN pBco)
        {
            this.InicializaVentana();
            this.Text = Universal.Opera.Visualizar.ToString() + Cadena.Espacios(1) + this.eTitulo;
            this.MostrarBanco(pBco);
            this.btnAceptar.Focus();
            eMas.AccionHabilitarControles(3);
        }
        
        public void AsignarBanco(BancoEN pBco)
        {
            pBco.CodigoBanco = this.txtCodBco.Text.Trim();
            pBco.NombreBanco = this.txtNomBco.Text.Trim();
            pBco.CodigoSunat = this.txtCodSun.Text.Trim();
            pBco.CEstadoBanco = this.cmbEstBco.SelectedValue.ToString();                      
        }
        
        public void MostrarBanco(BancoEN pBco)
        {
            this.txtCodBco.Text = pBco.CodigoBanco;
            this.txtNomBco.Text = pBco.NombreBanco;
            this.txtCodSun.Text = pBco.CodigoSunat;
            this.cmbEstBco.SelectedValue = pBco.CEstadoBanco;
        }
        
        public void Aceptar()
        {
            switch (this.eOperacion)
            {
                case Universal.Opera.Adicionar: { this.Adicionar(); break; }
                case Universal.Opera.Modificar: { this.Modificar(); break; }
                case Universal.Opera.Eliminar: { this.Eliminar(); break; }
                default: break;
            }
        }
        
        public void Adicionar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //la clave de lote aun no se registra?
            if (this.EsCodigoBancoDisponible(true) == false) { return; };

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //adicionando el registro
            this.AdicionarBanco();

            //generar banco ubicaciones para este nuevo banco
            this.GenerarBancoUbicacionesParaNuevoBanco( );

            //actualizar al wBco           
            this.wBco.eClaveDgvBco = this.txtCodBco.Text.Trim( );
            this.wBco.ActualizarVentana();

            //limpiar controles
            this.MostrarBanco(BancoRN.EnBlanco());
            eMas.AccionPasarTextoPrincipal();
            //this.tbcLote.SelectedTab = this.tbpDatosGenerales;
            this.txtCodBco.Focus();
        }
                
        public void AdicionarBanco()
        {
            BancoEN iBcoEN = new BancoEN();
            this.AsignarBanco(iBcoEN);
            BancoRN.AdicionarBanco(iBcoEN);
        }
        
        public void GenerarBancoUbicacionesParaNuevoBanco( )
        {
            //BancoUbicacionRN iBaURN = new BancoUbicacionRN( );
            //BancoUbicacionEN iBaUEN = new BancoUbicacionEN( );
            //iBaUEN.CodigoBanco = this.txtCodBco.Text.Trim( );
            //iBaURN.GenerarBancoUbicacionesParaNuevoBanco( iBaUEN );
        }
                
        public void Modificar()
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wBco.EsBancoExistente().Adicionales.EsVerdad == false) { return; }
                     
            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //modificar el registro    
            this.ModificarBanco();

            //actualizar al wBco           
            this.wBco.eClaveDgvBco = this.txtCodBco.Text.Trim( );
            this.wBco.ActualizarVentana();

            //salir de la ventana
            this.Close();

        }
        
        public void ModificarBanco()
        {
            BancoEN iBcoEN = new BancoEN();
            this.AsignarBanco(iBcoEN);
            iBcoEN = BancoRN.BuscarBancoXCodigo(iBcoEN);
            this.AsignarBanco(iBcoEN);
            BancoRN.ModificarBanco(iBcoEN);

        }
        
        public void Eliminar()
        {
            //preguntar si este objeto fue eliminado mientras estaba activa la ventana
            if (this.wBco.EsBancoExistente().Adicionales.EsVerdad == false) { return; }

            //desea realizar la operacion?
            if (Mensaje.DeseasRealizarOperacion(this.eTitulo) == false) { return; }

            //eliminar el registro
            this.EliminarBanco();

            //actualizar al wBco
            this.wBco.ActualizarVentana();

            //salir de la ventana
            this.Close();
        }
        
        public void EliminarBanco()
        {
            BancoEN iBcoEN = new BancoEN();
            this.AsignarBanco(iBcoEN);
            BancoRN.EliminarBancoXCodigo(iBcoEN);
        }
        
        public bool EsCodigoBancoDisponible(bool pVacio)
        {
            //cuando la operacion es diferente del adicionar entonces retorna verdadero
            if (this.eOperacion != Universal.Opera.Adicionar) { return true; }
            //
            //BancoRN iBcoRN = new BancoRN();
            BancoEN iBcoEN = new BancoEN();
            this.AsignarBanco(iBcoEN);
            iBcoEN = BancoRN.EsCodigoBancoDisponible(iBcoEN, pVacio);
            if (iBcoEN.Adicionales.EsVerdad == true)
            {
                return true;
            }
            else
            {
                MessageBox.Show(iBcoEN.Adicionales.Mensaje, "Banco", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                this.txtNomBco.Focus( );
                return false;
            }
        }
          
        public void Cancelar()
        {
            if (this.eOperacion == Universal.Opera.Visualizar || this.eOperacion == Universal.Opera.Eliminar)
            {
                this.Close();
                return;
            }
            //solo para adicionar y modificar
            if (eMas.SonTextosIguales() == false)
            {
                if (Mensaje.DeseasCancelarOperacion(this.eTitulo) == false)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }


 
        #endregion

                

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }
        
        private void wEditBancos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wBco.Enabled = true;
        }

        private void txtCodBco_TextChanged(object sender, EventArgs e)
        {

        }
               
       
        
        


        







    }
}
