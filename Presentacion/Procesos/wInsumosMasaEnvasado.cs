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
using Entidades.Estructuras;
using Presentacion.FuncionesGenericas;

namespace Presentacion.Procesos
{
    public partial class wInsumosMasaEnvasado : Heredados.MiForm8
    {
        public wInsumosMasaEnvasado()
        {
            InitializeComponent();
        }

        #region Atributos

        List<FormulaDetaEN> eLisForDet = new List<FormulaDetaEN>();

        #endregion

        #region Propietario

        //public wProduccion wPro;

        #endregion

        #region General


        public void InicializaVentana()
        {
            // Deshabilitar al propietario de esta ventana
            //this.wPro.Enabled = false;
                     
            // Mostrar ventana
            this.Show();            
        }

        public void NuevaVentana(ProduccionCabeEN pObj)
        {
            this.InicializaVentana();
            this.ActualizarListaFormulaDeta(pObj);       
            this.ActualizarDgvMot();  
            this.btnSalir.Focus();
        }

        public void ActualizarDgvMot()
        {
            //asignar parametros
            DataGridView iGrilla = this.DgvBot;
            List<FormulaDetaEN> iFuenteDatos = ListaG.Refrescar<FormulaDetaEN>(this.eLisForDet);
            Dgv.Franja iCondicionFranja =  Dgv.Franja.PorIndice;
            string iClaveBusqueda = string.Empty;            
            List<DataGridViewColumn> iListaColumnas = this.ListarColumnasDgvForDet();

            //ejecutar metodo
            Dgv.RefrescarGrilla(iGrilla, iFuenteDatos, iCondicionFranja, iClaveBusqueda, iListaColumnas);
        }

        public void ActualizarListaFormulaDeta(ProduccionCabeEN pObj)
        {
            this.eLisForDet = FormulaDetaRN.ListarFormulasDetaUsadasEnProduccion(pObj);
        }

        public List<DataGridViewColumn> ListarColumnasDgvForDet()
        {
            //lista resultado
            List<DataGridViewColumn> iLisRes = new List<DataGridViewColumn>();

            //agregando las columnas
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormulaDetaEN.CodExi, "Codigo", 75));
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormulaDetaEN.DesExi, "Descripcion", 300));            
            iLisRes.Add(Dgv.NuevaColumnaTextCadena(FormulaDetaEN.ClaObj, "Clave", 50, false));

            //devolver
            return iLisRes;
        }
        
        #endregion

        private void wInsumosMasaEnvasado_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.wPro.Enabled = true;           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
