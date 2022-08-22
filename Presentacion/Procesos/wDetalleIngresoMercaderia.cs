using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinControles;
using Entidades.Adicionales;
using WinControles.ControlesWindows;
using Entidades;
using Negocio;
using Comun;
using Presentacion.Listas;
using Presentacion.Procesos;
using Presentacion.FuncionesGenericas;

namespace Presentacion.Procesos
{
    public partial class wDetalleIngresoMercaderia : Heredados.MiForm8
    {
        public wDetalleIngresoMercaderia()
        {
            InitializeComponent( );
        }


        #region Atributos

        public Universal.Opera eOperacion;
        Masivo eMas = new Masivo();
        string eTitulo = "Item";

        #endregion

        #region Propietario

        public wIngresoMercaderias wIngMer;


        #endregion

        #region Eventos controles

        List<ControlEditar> ListaCtrls( )
        {
            List<ControlEditar> xLis = new List<ControlEditar>( );
            ControlEditar xCtrl;

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCodExi, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesExi, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtNUniMed, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosIns, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCosManObr, false, "Costo Mano Obra", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtCosGasInd, false, "Gastos Indirectos", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtNumeroConDecimales(this.txtOtr, false, "Otros costos", "vvff", 2, 12);
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtPreUniMovDet, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCantMovDet, this.btnAceptar, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtCosMovDet, this.txtCantMovDet, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.TxtTodo(this.txtCodCenCos, false, "Centro Costo", "vvff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar();
            xCtrl.txtNoFoco(this.txtDesCenCos, this.txtCodCenCos, "ffff");
            xLis.Add(xCtrl);

            xCtrl = new ControlEditar( );
            xCtrl.TxtTodo( this.txtGloMovDet , false , "Glosa" , "vvff" );
            xLis.Add( xCtrl );
            
            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnAceptar , "vvvf" );
            xLis.Add( xCtrl );

            xCtrl = new ControlEditar( );
            xCtrl.Btn( this.btnCancelar , "vvvv" );
            xLis.Add( xCtrl );

            return xLis;
        }

        #endregion

        #region General

        public void InicializaVentana( )
        {
            //eventos de controles
            eMas.lisCtrls = this.ListaCtrls( );
            eMas.EjecutarTodosLosEventos( );
            
            //deshabilita propietario
            this.wIngMer.Enabled = false;

            //ver ventana
            this.Show( );
        }
             
        public void VentanaModificar( MovimientoDetaEN pObj )
        {          
            this.InicializaVentana( );
            this.Text = Universal.Opera.Modificar.ToString( ) + Cadena.Espacios( 1 ) + this.eTitulo;
            this.MostrarMovimientoDeta( pObj );
            this.MostrarProduccionProTer();           
            eMas.AccionHabilitarControles( 1 );
            eMas.AccionPasarTextoPrincipal( );         
            this.txtOtr.Focus();
        }
     
        public void AsignarMovimientoDeta(MovimientoDetaEN pObj)
        {
            pObj.CodigoEmpresa = Universal.gCodigoEmpresa;
            pObj.FechaMovimientoCabe = this.wIngMer.dtpFecMovCab.Text;
            pObj.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(pObj.FechaMovimientoCabe, "-");
            pObj.CodigoAlmacen = this.wIngMer.txtCodAlm.Text.Trim();
            pObj.CodigoTipoOperacion = this.wIngMer.txtCodTipOpe.Text.Trim();
            pObj.CCalculaPrecioPromedio = this.wIngMer.txtCCalPrePro.Text.Trim();
            pObj.CClaseTipoOperacion = "1";//ingreso
            pObj.NumeroMovimientoCabe = this.wIngMer.txtNumMovCab.Text.Trim();           
            pObj.CodigoCentroCosto = this.txtCodCenCos.Text.Trim();
            pObj.DescripcionCentroCosto = this.txtDesCenCos.Text.Trim();
            pObj.CodigoExistencia = this.txtCodExi.Text.Trim();
            pObj.DescripcionExistencia = this.txtDesExi.Text.Trim();
            pObj.CodigoUnidadMedida = this.txtCUniMed.Text.Trim();
            pObj.NombreUnidadMedida = this.txtNUniMed.Text.Trim();
            pObj.StockAnteriorExistencia = Convert.ToDecimal(this.txtStoAntExi.Text);
            pObj.PrecioAnteriorExistencia = Convert.ToDecimal(this.txtPreAntExi.Text);
            pObj.PrecioUnitarioMovimientoDeta = Convert.ToDecimal(this.txtPreUniMovDet.Text);
            pObj.CantidadMovimientoDeta = Convert.ToDecimal(this.txtCantMovDet.Text);
            pObj.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(pObj);
            pObj.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(pObj);
            pObj.CostoMovimientoDeta = Convert.ToDecimal(this.txtCosMovDet.Text);
            pObj.GlosaMovimientoDeta = this.txtGloMovDet.Text.Trim();
            pObj.ClaveMovimientoCabe = this.wIngMer.ObtenerClaveMovimientoCabe();
        }

        public void MostrarMovimientoDeta( MovimientoDetaEN pObj )
        {
            this.txtCodCenCos.Text = pObj.CodigoCentroCosto;
            this.txtDesCenCos.Text = pObj.DescripcionCentroCosto;
            this.txtCodExi.Text = pObj.CodigoExistencia;
            this.txtDesExi.Text = pObj.DescripcionExistencia;            
            this.txtNUniMed.Text = pObj.NombreUnidadMedida;
            this.txtCUniMed.Text = pObj.CodigoUnidadMedida;
            this.txtStoAntExi.Text = Formato.NumeroDecimal(pObj.StockAnteriorExistencia.ToString(), 5);
            this.txtPreAntExi.Text = Formato.NumeroDecimal(pObj.PrecioAnteriorExistencia.ToString(), 2);
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal( pObj.PrecioUnitarioMovimientoDeta.ToString( ) , 2 );
            this.txtCantMovDet.Text = Formato.NumeroDecimal(pObj.CantidadMovimientoDeta.ToString(), 5);
            this.txtCosMovDet.Text = Formato.NumeroDecimal(pObj.CostoMovimientoDeta.ToString(), 2);
            this.txtGloMovDet.Text = pObj.GlosaMovimientoDeta;            
        }
               
        public void Aceptar( )
        {
            //validar los campos obligatorios
            if (eMas.CamposObligatorios() == false) { return; }

            //modificar detalle
            this.ModificarMovimientoDeta();

            //modificar produccionDeta
            this.ModificarProduccionProTer();
            
            //mensaje
            Mensaje.OperacionSatisfactoria("Se modifico el registro", "Detalle");

            //Actualizar propietario           
            this.wIngMer.MostrarMovimientoDeta();

            //salir de la ventana
            this.Close();
        }
                
        public void ModificarMovimientoDeta()
        {           
            this.AsignarMovimientoDeta( this.wIngMer.eLisMovDet[Dgv.ObtenerIndiceRegistroXFranja( this.wIngMer.dgvProExi )] );
        }

        public void ModificarProduccionProTer()
        {
            //obtener el indice del registro actual de la grilla
            int iIndiceFila = Dgv.ObtenerIndiceRegistroXFranja(this.wIngMer.dgvProExi); 

            //modificar los datos del objeto de este indice
            this.wIngMer.eLisProProTer[iIndiceFila].CostoManoObra = Conversion.ADecimal(this.txtCosManObr.Text, 0);
            this.wIngMer.eLisProProTer[iIndiceFila].CostoGastoIndirecto = Conversion.ADecimal(this.txtCosGasInd.Text, 0);
            this.wIngMer.eLisProProTer[iIndiceFila].CostoOtros = Conversion.ADecimal(this.txtOtr.Text, 0);
            this.wIngMer.eLisProProTer[iIndiceFila].CostoTotalProducto = Conversion.ADecimal(this.txtPreUniMovDet.Text, 0);            
        }

        public void MostrarCosto()
        {
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            this.AsignarMovimientoDeta(iMovDetEN);
            this.txtCosMovDet.Text = Formato.NumeroDecimal(MovimientoDetaRN.ObtenerCosto(iMovDetEN).ToString(), 2);
        }

        public void ListarCentrosCostos()
        {
            //solo cuando el control esta habilitado de escritura
            if (this.txtCodCenCos.ReadOnly == true) { return; }

            //instanciar
            wLisItemE win = new wLisItemE();
            win.eVentana = this;
            win.eTituloVentana = "Centros costo";
            win.eCtrlValor = this.txtCodCenCos;
            win.eCtrlFoco = this.txtGloMovDet;
            win.eIteEN.CodigoTabla = "CenCos";
            win.eCondicionLista = Listas.wLisItemE.Condicion.ItemsActivosXTabla;
            TabCtrl.InsertarVentana(this, win);
            win.NuevaVentana();
        }

        public bool EsCodigoCentroCostoValido()
        {
            return Generico.EsCodigoItemEValido("CenCos", this.txtCodCenCos, this.txtDesCenCos, "Centro costo");
        }

        public void CambiarAtributoSoloLecturaAPrecioUnitario()
        {
            //obtener el flag si debe o no calcular precio promedio
            string iCCalculaPrecioPromedio = this.wIngMer.txtCCalPrePro.Text.Trim();

            //obtener el valor de veracidad de este flag
            bool iValor = Conversion.CadenaABoolean(iCCalculaPrecioPromedio, false);

            //cambiamos el atributo del control
            Txt.SoloEscritura1(this.txtPreUniMovDet, !iValor);
        }

        public void MostrarProduccionProTer()
        {
            //traer al objeto produccionProTer de la lista eLisProProTer
            ProduccionProTerEN iProProTerEN = ListaG.Buscar<ProduccionProTerEN>(this.wIngMer.eLisProProTer, ProduccionProTerEN.CodExi,
                this.txtCodExi.Text.Trim());

            //mostrar datos
            this.txtCosIns.Text = Formato.NumeroDecimal(iProProTerEN.CostoInsumos, 2);
            this.txtCosManObr.Text = Formato.NumeroDecimal(iProProTerEN.CostoManoObra, 2);
            this.txtCosGasInd.Text = Formato.NumeroDecimal(iProProTerEN.CostoGastoIndirecto, 2);
            this.txtOtr.Text = Formato.NumeroDecimal(iProProTerEN.CostoOtros, 2);
        }

        public void MostrarPrecioUnitario()
        {
            //asignar parametros
            ProduccionProTerEN iProDetEN = new ProduccionProTerEN();
            iProDetEN.CostoInsumos = Conversion.ADecimal(this.txtCosIns.Text, 0);
            iProDetEN.CostoManoObra = Conversion.ADecimal(this.txtCosManObr.Text, 0);
            iProDetEN.CostoGastoIndirecto = Conversion.ADecimal(this.txtCosGasInd.Text, 0);
            iProDetEN.CostoOtros = Conversion.ADecimal(this.txtOtr.Text, 0);

            //ejecutar metodo
            decimal iCosto = ProduccionProTerRN.ObtenerCostoUnidadProTer(iProDetEN);

            //mostrar en pantalla
            this.txtPreUniMovDet.Text = Formato.NumeroDecimal(iCosto, 2);
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


        private void btnCancelar_Click( object sender , EventArgs e )
        {
            this.Cancelar( );
        }

        private void wDetalleIngresoMercaderia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.wIngMer.Enabled = true;
        }

        private void btnAceptar_Click( object sender , EventArgs e )
        {
            this.Aceptar( );
        }
    
        private void txtPreUni_Validated(object sender, EventArgs e)
        {
            this.MostrarCosto();
        }

        private void txtCodCenCos_Validating(object sender, CancelEventArgs e)
        {
            this.EsCodigoCentroCostoValido();
        }

        private void txtCodCenCos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { this.ListarCentrosCostos(); }
        }

        private void txtCodCenCos_DoubleClick(object sender, EventArgs e)
        {
            this.ListarCentrosCostos();
        }

        private void txtCosManObr_Validated(object sender, EventArgs e)
        {
            this.MostrarPrecioUnitario();
            this.MostrarCosto();
        }
    }
}
