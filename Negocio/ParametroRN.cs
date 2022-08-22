using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comun;
using Entidades;
using Datos;
using System.IO;

namespace Negocio
{
    public class ParametroRN
    {

        public static void ModificarParametro(ParametroEN pObj)
        {
            ParametroAD iParAD = new ParametroAD();
            iParAD.ModificarParametro(pObj);
        }

        public static ParametroEN BuscarParametro()
        {
            ParametroAD iIteAD = new ParametroAD();
            return iIteAD.BuscarParametro();
        }

        public static void ModificarCampoParametro(string pCampo, string pValor)
        {
            //traer al objeto parametro
            ParametroEN iParEN = new ParametroEN();
            iParEN = ParametroRN.BuscarParametro();

            //modificar solo el campo que biene como parametro
            //desde la ventana
            switch (pCampo)
            {
                case ParametroEN.RutLogEmp: { iParEN.RutaLogoEmpresa = pValor; break; }
                case ParametroEN.RutImaExi: { iParEN.RutaImagenExistencia = pValor; break; }
                case ParametroEN.PorIgv: { iParEN.PorcentajeIgv = Convert.ToDecimal(pValor); break; }
                case ParametroEN.NomSol: { iParEN.NombreSoles = pValor; break; }
                case ParametroEN.NomDol: { iParEN.NombreDolares = pValor; break; }
                case ParametroEN.TipOpeTraIng: { iParEN.TipoOperacionTransferenciaIngreso = pValor; break; }
                case ParametroEN.TipOpeTraSal: { iParEN.TipoOperacionTransferenciaSalida = pValor; break; }
                case ParametroEN.TipOpeProSal: { iParEN.TipoOperacionProduccionSalida = pValor; break; }
                case ParametroEN.TipOpeProIng: { iParEN.TipoOperacionProduccionIngreso = pValor; break; }
                case ParametroEN.CenCosPro: { iParEN.CentroCostoProduccion = pValor; break; }
                case ParametroEN.TipOpeComMig: { iParEN.TipoOperacionCompraMigracion = pValor; break; }
                case ParametroEN.TipOpeImpMig: { iParEN.TipoOperacionImportacionMigracion = pValor; break; }
                case ParametroEN.TipOpeIngMig: { iParEN.TipoOperacionIngresoMigracion = pValor; break; }
                case ParametroEN.TipOpeSalMig: { iParEN.TipoOperacionSalidaMigracion = pValor; break; }
                case ParametroEN.TipOpeIngAju: { iParEN.TipoOperacionIngresoAjuste = pValor; break; }
                case ParametroEN.TipOpeSalAju: { iParEN.TipoOperacionSalidaAjuste = pValor; break; }
                case ParametroEN.TipOpeIngDevPro: { iParEN.TipoOperacionIngresoDevolucionProduccion = pValor; break; }
                case ParametroEN.TipOpeSalNoPas: { iParEN.TipoOperacionSalidaNoPasan = pValor; break; }
                case ParametroEN.CorEnv: { iParEN.CorreoEnvio = pValor; break; }
                case ParametroEN.ClaCorEnv: { iParEN.ClaveCorreoEnvio = pValor; break; }
                case ParametroEN.HostCorEnv: { iParEN.HostCorreoEnvio = pValor; break; }
                case ParametroEN.PueCorEnv: { iParEN.PuertoCorreoEnvio = pValor; break; }
                case ParametroEN.RutCarPla: { iParEN.RutaCarpetaPlantillas = pValor; break; }
                case ParametroEN.RutRec: { iParEN.RutaRecibos = pValor; break; }
                case ParametroEN.RutPlaRec: { iParEN.RutaPlantillaRecibo = pValor; break; }
            }

            //modificar su valor
            ParametroRN.ModificarParametro(iParEN);
        }

    }
}
