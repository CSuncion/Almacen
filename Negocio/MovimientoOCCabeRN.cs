using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using Comun;
using Entidades.Adicionales;
using Entidades.Contabilidad;
using Negocio.Contabilidad;
using Entidades.Estructuras;
using System.Windows.Forms;


namespace Negocio
{
    public class MovimientoOCCabeRN
    {

        public static MovimientoOCCabeEN EnBlanco()
        {
            MovimientoOCCabeEN iExiEN = new MovimientoOCCabeEN();
            return iExiEN;
        }

        public static void AdicionarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.AgregarMovimientoCabe(pObj);
        }

        public static void AdicionarMovimientoCabe(List<MovimientoOCCabeEN> pLista)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.AgregarMovimientoCabe(pLista);
        }

        public static void ModificarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.ModificarMovimientoCabe(pObj);
        }

        public static void ModificarMovimientoCabe(List<MovimientoOCCabeEN> pLista)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.ModificarMovimientoCabe(pLista);
        }

        public static void EliminarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.EliminarMovimientoCabe(pObj);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabes(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabes(pObj);
        }

        public static MovimientoOCCabeEN BuscarMovimientoCabeXClave(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.BuscarMovimientoCabeXClave(pObj);
        }

        public static MovimientoOCCabeEN BuscarMovimientoCabeXClave(string pClaveMovimientoCabe)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pClaveMovimientoCabe;

            //ejecutar metodo
            return MovimientoOCCabeRN.BuscarMovimientoCabeXClave(iMovCabEN);
        }

        public static MovimientoOCCabeEN EsMovimientoCabeExistente(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iExiEN = new MovimientoOCCabeEN();

            //validar si existe en b.d
            iExiEN = MovimientoOCCabeRN.BuscarMovimientoCabeXClave(pObj);
            if (iExiEN.ClaveMovimientoCabe == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El registro no existe";
                return iExiEN;
            }

            //ok        
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(MovimientoOCCabeEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case MovimientoOCCabeEN.ClaObj: return pObj.ClaveObjeto;
                case MovimientoOCCabeEN.ClaMovCab: return pObj.ClaveMovimientoCabe;
                case MovimientoOCCabeEN.CodEmp: return pObj.CodigoEmpresa;
                case MovimientoOCCabeEN.NomEmp: return pObj.NombreEmpresa;
                case MovimientoOCCabeEN.PerMovCab: return pObj.PeriodoMovimientoCabe;
                case MovimientoOCCabeEN.CodAlm: return pObj.CodigoAlmacen;
                case MovimientoOCCabeEN.DesAlm: return pObj.DescripcionAlmacen;
                case MovimientoOCCabeEN.CodTipOpe: return pObj.CodigoTipoOperacion;
                case MovimientoOCCabeEN.DesTipOpe: return pObj.DescripcionTipoOperacion;
                case MovimientoOCCabeEN.CClaTipOpe: return pObj.CClaseTipoOperacion;
                case MovimientoOCCabeEN.NClaTipOpe: return pObj.NClaseTipoOperacion;
                case MovimientoOCCabeEN.CCalPrePro: return pObj.CCalculaPrecioPromedio;
                case MovimientoOCCabeEN.NumMovCab: return pObj.NumeroMovimientoCabe;
                case MovimientoOCCabeEN.FecMovCab: return pObj.FechaMovimientoCabe;
                case MovimientoOCCabeEN.CodAux: return pObj.CodigoAuxiliar;
                case MovimientoOCCabeEN.DesAux: return pObj.DescripcionAuxiliar;
                case MovimientoOCCabeEN.CodPer: return pObj.CodigoPersonal;
                case MovimientoOCCabeEN.NomPer: return pObj.NombrePersonal;
                case MovimientoOCCabeEN.OrdCom: return pObj.OrdenCompra;
                case MovimientoOCCabeEN.GuiRem: return pObj.GuiaRemision;
                case MovimientoOCCabeEN.CTipDoc: return pObj.CTipoDocumento;
                case MovimientoOCCabeEN.NTipDoc: return pObj.NTipoDocumento;
                case MovimientoOCCabeEN.SerDoc: return pObj.SerieDocumento;
                case MovimientoOCCabeEN.NumDoc: return pObj.NumeroDocumento;
                case MovimientoOCCabeEN.FecDoc: return pObj.FechaDocumento;
                case MovimientoOCCabeEN.IgvPor: return pObj.IgvPorcentaje.ToString();
                case MovimientoOCCabeEN.ValVtaMovCab: return pObj.ValorVtaMovimientoCabe.ToString();
                case MovimientoOCCabeEN.IgvMovCab: return pObj.IgvMovimientoCabe.ToString();
                case MovimientoOCCabeEN.ExoMovCab: return pObj.ExoneradoMovimientoCabe.ToString();
                case MovimientoOCCabeEN.PreVtaMovCab: return pObj.PrecioVtaMovimientoCabe.ToString();
                case MovimientoOCCabeEN.MonTotMovCab: return pObj.MontoTotalMovimientoCabe.ToString();
                case MovimientoOCCabeEN.GloMovCab: return pObj.GlosaMovimientoCabe;
                case MovimientoOCCabeEN.ClaIngMovCab: return pObj.ClaveIngresoMovimientoCabe;
                case MovimientoOCCabeEN.COriVenCre: return pObj.COrigenVentanaCreacion;
                case MovimientoOCCabeEN.NOriVenCre: return pObj.NOrigenVentanaCreacion;
                case MovimientoOCCabeEN.CEstMovCab: return pObj.CEstadoMovimientoCabe;
                case MovimientoOCCabeEN.NEstMovCab: return pObj.NEstadoMovimientoCabe;
                case MovimientoOCCabeEN.UsuAgr: return pObj.UsuarioAgrega;
                case MovimientoOCCabeEN.FecAgr: return pObj.FechaAgrega.ToString();
                case MovimientoOCCabeEN.UsuMod: return pObj.UsuarioModifica;
                case MovimientoOCCabeEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<MovimientoOCCabeEN> FiltrarMovimientoCabesXTextoEnCualquierPosicion(List<MovimientoOCCabeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<MovimientoOCCabeEN> iLisRes = new List<MovimientoOCCabeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (MovimientoOCCabeEN xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<MovimientoOCCabeEN>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoOCCabeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<MovimientoOCCabeEN> pListaMovimientoCabes)
        {
            //lista resultado
            List<MovimientoOCCabeEN> iLisRes = new List<MovimientoOCCabeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaMovimientoCabes; }

            //filtar la lista
            iLisRes = MovimientoOCCabeRN.FiltrarMovimientoCabesXTextoEnCualquierPosicion(pListaMovimientoCabes, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveMovimientoCabe(MovimientoOCCabeEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.PeriodoMovimientoCabe + "-";
            iClave += pPer.CodigoAlmacen + "-";
            iClave += pPer.CodigoTipoOperacion + "-";
            iClave += pPer.NumeroMovimientoCabe;

            //retornar
            return iClave;
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesXPeriodoYClaseOperacion(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesXPeriodoYClaseOperacion(pObj);
        }

        public static string ObtenerMaximoValorEnColumna(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iCliAD = new MovimientoOCCabeAD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(MovimientoOCCabeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = MovimientoOCCabeRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static MovimientoOCCabeEN EsActoAdicionarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //ok          
            return iMovCabEN;
        }

        public static MovimientoOCCabeEN ValidaCuandoNoEsActoRegistrarEnPeriodo(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pObj.PeriodoMovimientoCabe;
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iMovCabEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iMovCabEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iMovCabEN;
        }

        public static MovimientoOCCabeEN ValidaCuandoFechaNoEsDelPeriodoElegido(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //validar
            bool iEsVerdad = Periodo.EsFechaDePeriodo(pObj.FechaMovimientoCabe, pObj.PeriodoMovimientoCabe);
            if (iEsVerdad == false)
            {
                iMovCabEN.Adicionales.EsVerdad = false;
                iMovCabEN.Adicionales.Mensaje = "La fecha " + pObj.FechaMovimientoCabe + " debe ser del periodo " +
                                                Periodo.FormatoAñoYNombreMes(pObj.PeriodoMovimientoCabe);
                return iMovCabEN;
            }

            //ok
            return iMovCabEN;
        }

        public static MovimientoOCCabeEN EsActoModificarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida si existe
            iMovCabEN = MovimientoOCCabeRN.EsMovimientoCabeExistente(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            MovimientoOCCabeEN iMovCabVenEN = MovimientoOCCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iMovCabEN, pObj.COrigenVentanaCreacion);
            if (iMovCabVenEN.Adicionales.EsVerdad == false) { return iMovCabVenEN; }

            //ok          
            return iMovCabEN;
        }

        public static MovimientoOCCabeEN ValidaCuandoRegistroNofueCreadoPorVentanaProceso(MovimientoOCCabeEN pObj, string pCodigoVentanaProceso)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //validar           
            if (pObj.COrigenVentanaCreacion != pCodigoVentanaProceso)
            {
                iMovCabEN.Adicionales.EsVerdad = false;
                iMovCabEN.Adicionales.Mensaje = "Este registro no fue creado por esta ventana, no se puede realizar la operacion";
                return iMovCabEN;
            }

            //ok
            return iMovCabEN;
        }

        public static MovimientoOCCabeEN EsActoEliminarMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida si existe
            iMovCabEN = MovimientoOCCabeRN.EsMovimientoCabeExistente(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            MovimientoOCCabeEN iMovCabVenEN = MovimientoOCCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iMovCabEN, pObj.COrigenVentanaCreacion);
            if (iMovCabVenEN.Adicionales.EsVerdad == false) { return iMovCabVenEN; }

            //ok          
            return iMovCabEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerFechaMovimientoCabeSugerido(string pPeriodoRegistro, string pFechaMovimientoCabeDtp)
        {
            //si la fecha movimiento dtp pertenece al periodo registro, entonces se devuleve esta misma fecha
            if (Periodo.EsFechaDePeriodo(pFechaMovimientoCabeDtp, pPeriodoRegistro) == true) { return pFechaMovimientoCabeDtp; }

            //aqui la fecha es de otro periodo, entonces formamos una fecha con el periodo parametro
            return Periodo.ObtenerFecha("01", pPeriodoRegistro);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesParaGrillaTransferencia(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesParaGrillaTransferencia(pObj);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesParaGrillaIngresos(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesParaGrillaIngresos(pObj);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesParaGrillaSalidas(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesParaGrillaSalidas(pObj);
        }

        public static void EliminarMovimientoCabeYDeta(MovimientoOCCabeEN pObj)
        {
            //eliminar primero la cabecera
            MovimientoOCCabeRN.EliminarMovimientoCabe(pObj);

            //eliminar el detalle
            MovimientoOCDetaEN iMovDetEN = new MovimientoOCDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
            MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public static void EliminarMovimientoCabe(string pClaveMovimientoCabe)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pClaveMovimientoCabe;

            //ejecutar metodo
            MovimientoOCCabeRN.EliminarMovimientoCabe(iMovCabEN);
        }

        public static void ImportarDeContabilidad(string pCodigoPeriodo)
        {
            //obtener el Periodo para contabilidad
            string iPeriodoContabilidad = RegContabDeta_Cont_RN.TransformarAPeriodoContable(pCodigoPeriodo);

            //traer una lista de listas de RegContabDeta de contabilidad para importar.
            //cada lista es un voucher en contabilidad
            List<List<RegContabDeta_Cont_EN>> iLisLisRegConDet = RegContabDeta_Cont_RN.ListarRegContabDetasParaImportar(iPeriodoContabilidad);

            //traer a los auxiliares de contabilidad que intervienen en el RegContabDeta de este periodo elegido
            List<Auxiliar_Cont_EN> iLisAuxCont = Auxiliar_Cont_RN.ListarAuxiliarsParaImportar(iPeriodoContabilidad);

            //traer a los auxiliares de almacen, pero solo los de iLisAuxCont
            List<AuxiliarEN> iLisAuxAlm = AuxiliarRN.ListarAuxiliaresPorCodigosAuxiliar(iLisAuxCont);

            //traer al obejto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //listas para adicionar los nuevos objetos
            List<MovimientoOCCabeEN> iLisMovCabAdi = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();
            List<AuxiliarEN> iLisAuxMod = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<RegContabDeta_Cont_EN> xLisRegConDet in iLisLisRegConDet)
            {
                //obtener al primer objeto de la lista
                RegContabDeta_Cont_EN iRegConDetEN = xLisRegConDet[0];

                //obtener al objeto almacen para este movimiento
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iRegConDetEN.Almacen, iLisAlm);

                //creamos un nuevo movimientoCabe
                MovimientoOCCabeEN iMovCabNueEN = new MovimientoOCCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoMovimientoCabe = pCodigoPeriodo;
                iMovCabNueEN.CodigoAlmacen = iRegConDetEN.Almacen;
                iMovCabNueEN.CodigoTipoOperacion = MovimientoOCCabeRN.ObtenerCodigoTipoOperacion(iRegConDetEN, iParEN);
                iMovCabNueEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi);
                iMovCabNueEN.FechaMovimientoCabe = iRegConDetEN.FechaVoucherRegContabCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iRegConDetEN.CodigoAuxiliar;
                iMovCabNueEN.CTipoDocumento = iRegConDetEN.TipoDocumento;
                iMovCabNueEN.SerieDocumento = iRegConDetEN.SerieDocumento;
                iMovCabNueEN.NumeroDocumento = iRegConDetEN.NumeroDocumento;
                iMovCabNueEN.FechaDocumento = iRegConDetEN.FechaDocumento;
                iMovCabNueEN.GlosaMovimientoCabe = iRegConDetEN.DescripcionRegContabCabe;
                iMovCabNueEN.COrigenVentanaCreacion = "5";//Importado Contabilidad
                iMovCabNueEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabNueEN);

                //adicionamos a la lista de MovimientoCabe para adicionar
                iLisMovCabAdi.Add(iMovCabNueEN);

                //correlativo para los MovimientosDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (RegContabDeta_Cont_EN xRegConDet in xLisRegConDet)
                {
                    //incrementar el correlativo
                    iCorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoMovimientoDeta);

                    //creamos un nuevo objeto MovimientoDeta
                    MovimientoOCDetaEN iMovDetNueEN = new MovimientoOCDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroMovimientoCabe = iMovCabNueEN.NumeroMovimientoCabe;
                    iMovDetNueEN.ClaveMovimientoCabe = iMovCabNueEN.ClaveMovimientoCabe;
                    iMovDetNueEN.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                    iMovDetNueEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetNueEN);
                    iMovDetNueEN.CodigoEmpresa = iMovCabNueEN.CodigoEmpresa;
                    iMovDetNueEN.FechaMovimientoCabe = iMovCabNueEN.FechaMovimientoCabe;
                    iMovDetNueEN.PeriodoMovimientoCabe = iMovCabNueEN.PeriodoMovimientoCabe;
                    iMovDetNueEN.CodigoAlmacen = iMovCabNueEN.CodigoAlmacen;
                    iMovDetNueEN.CodigoTipoOperacion = iMovCabNueEN.CodigoTipoOperacion;
                    iMovDetNueEN.CodigoAuxiliar = iMovCabNueEN.CodigoAuxiliar;
                    iMovDetNueEN.CTipoDocumento = iMovCabNueEN.CTipoDocumento;
                    iMovDetNueEN.SerieDocumento = iMovCabNueEN.SerieDocumento;
                    iMovDetNueEN.NumeroDocumento = iMovCabNueEN.NumeroDocumento;
                    iMovDetNueEN.FechaDocumento = iMovCabNueEN.FechaDocumento;
                    iMovDetNueEN.CodigoCentroCosto = xRegConDet.CodigoCentroCosto;
                    iMovDetNueEN.CodigoExistencia = xRegConDet.CodigoGastoReparable;
                    iMovDetNueEN.CodigoUnidadMedida = xRegConDet.Unidad;
                    iMovDetNueEN.PrecioUnitarioMovimientoDeta = xRegConDet.PrecioUnitario;
                    iMovDetNueEN.CantidadMovimientoDeta = xRegConDet.Cantidad;
                    iMovDetNueEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetNueEN);
                    iMovDetNueEN.GlosaMovimientoDeta = xRegConDet.GlosaRegContabDeta;

                    //adicionamos a la lista de MovimientoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicionYModificacion(iLisAuxAdi, iLisAuxMod, iLisAuxAlm, iLisAuxCont);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            MovimientoOCCabeRN.EliminarAntesDeImportar(pCodigoPeriodo);

            //grabaciones masivas
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
            AuxiliarRN.ModificarAuxiliar(iLisAuxMod);

        }

        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(MovimientoOCCabeEN pObj, List<MovimientoOCCabeEN> pLista)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la lista
            string iUltimoCodigo = MovimientoOCCabeRN.ObtenerMaximoValorEnColumna(pObj, pLista);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static string ObtenerMaximoValorEnColumna(MovimientoOCCabeEN pObj, List<MovimientoOCCabeEN> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //recorrer cada objeto
            foreach (MovimientoOCCabeEN xMovCab in pLista)
            {
                if (pObj.PeriodoMovimientoCabe != xMovCab.PeriodoMovimientoCabe) { continue; }
                if (pObj.CodigoAlmacen != xMovCab.CodigoAlmacen) { continue; }
                if (pObj.CodigoTipoOperacion != xMovCab.CodigoTipoOperacion) { continue; }

                //obtener su numero movimientoCabe
                iValor = xMovCab.NumeroMovimientoCabe;
            }

            //devolver
            return iValor;
        }

        public static string ObtenerCodigoTipoOperacion(RegContabDeta_Cont_EN pObj, ParametroEN pPar)
        {
            //valor resultado
            string iValor = string.Empty;

            //si el objeto es de origen 4, entonces sera de tipo operacion compra
            if (pObj.CodigoOrigen == "4")
            {
                if (RegContabDeta_Cont_RN.EsCompraNacional(pObj) == true)
                {
                    iValor = pPar.TipoOperacionCompraMigracion;
                }
                else
                {
                    iValor = pPar.TipoOperacionImportacionMigracion;
                }
            }
            else
            {
                //si es haber entonces tipo operacion ingreso
                if (pObj.DebeHaberRegContabDeta == "0")
                {
                    iValor = pPar.TipoOperacionIngresoMigracion;
                }
                else
                {
                    iValor = pPar.TipoOperacionSalidaMigracion;
                }
            }

            //devolver
            return iValor;
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesXPeriodo(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesXPeriodo(pObj);
        }

        public static MovimientoOCCabeEN ArmarMovimientoCabeAjuste(InventarioCabeEN pInvCab, TipoOperacionEN pTipOpe, string pFechaGenera)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasamos datos
            iMovCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(pFechaGenera, "-");
            iMovCabEN.FechaMovimientoCabe = pFechaGenera;
            iMovCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iMovCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iMovCabEN.CClaseTipoOperacion = pTipOpe.CClaseTipoOperacion;
            iMovCabEN.CodigoAlmacen = pInvCab.CodigoAlmacen;
            iMovCabEN.CodigoPersonal = pInvCab.CodigoPersonal;
            iMovCabEN.GlosaMovimientoCabe = "Ajuste Inventario";
            iMovCabEN.COrigenVentanaCreacion = "6";//inventario
            iMovCabEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //devolver
            return iMovCabEN;
        }

        public static void EliminarAntesDeImportar(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar movimiento deta
            MovimientoOCDetaRN.EliminarMovimientosDetaDeImportacion(pCodigoPeriodo);

            //eliminar movimiento cabe
            MovimientoOCCabeRN.EliminarMovimientosCabeDeImportacion(pCodigoPeriodo);
        }

        public static void EliminarAntesDeImportarIngreso(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar movimiento deta
            MovimientoOCDetaRN.EliminarMovimientosDetaDeImportacionIngreso(pCodigoPeriodo);

            //eliminar movimiento cabe
            MovimientoOCCabeRN.EliminarMovimientosCabeDeImportacionIngreso(pCodigoPeriodo);
        }

        public static void EliminarAntesDeImportarSalida(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar movimiento deta
            MovimientoOCDetaRN.EliminarMovimientosDetaDeImportacionSalida(pCodigoPeriodo);

            //eliminar movimiento cabe
            MovimientoOCCabeRN.EliminarMovimientosCabeDeImportacionSalida(pCodigoPeriodo);
        }

        public static void EliminarMovimientoCabeXPeriodoYOrigen(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.EliminarMovimientoCabeXPeriodoYOrigen(pObj);
        }

        public static void EliminarMovimientoCabeXPeriodoXOrigenYClase(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.EliminarMovimientoCabeXPeriodoXOrigenYClase(pObj);
        }

        public static void EliminarMovimientosCabeDeImportacion(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            MovimientoOCCabeRN.EliminarMovimientoCabeXPeriodoYOrigen(iMovCabEN);
        }

        public static void EliminarMovimientosCabeDeImportacionIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "1";//ingreso
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            MovimientoOCCabeRN.EliminarMovimientoCabeXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static void EliminarMovimientosCabeDeImportacionSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "2";//salida
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            MovimientoOCCabeRN.EliminarMovimientoCabeXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesXClaveProduccionDetaYClaseOperacion(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesXClaveProduccionDetaYClaseOperacion(pObj);
        }

        public static void GenerarTransferenciasAutomaticasAProduccion(List<InsumoFaltante> pLisInsTra)
        {
            //separar en listas los insumos por almacen
            List<List<InsumoFaltante>> iLisLisInsTraAlm = ListaG.ListarListas<InsumoFaltante>(pLisInsTra, InsumoFaltante.CodAlm);

            //obtener la fecha para estos movimientos de transferencia(este dato sale de la fecha de produccion de estos insumos)
            string iFechaMovimientoCabe = ListaG.ObtenerPrimerValor<InsumoFaltante>(pLisInsTra, InsumoFaltante.FecPro);

            //traemos al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeSalEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaSalida);

            //traemos al tipo de operacion de transferencia ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaIngreso);

            //traer la lista de existencias de la empresa actual
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistencias();

            //listas para adicionar y modificar en b.d
            List<MovimientoOCCabeEN> iLisMovCabAdi = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero movimiento para el ingreso
            string iNumeroMovimientoCabeIngreso = string.Empty;

            //recorrer cada lista
            foreach (List<InsumoFaltante> xLisInsFal in iLisLisInsTraAlm)
            {
                //obtener al primer objeto de la lista
                InsumoFaltante iInsFal = xLisInsFal[0];

                //creamos el objeto MovimientoCabe de salida transferencia
                MovimientoOCCabeEN iMovCabSalEN = new MovimientoOCCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabSalEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iInsFal.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iInsFal.CodigoPersonal;
                iMovCabSalEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabSalEN);
                iMovCabSalEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabSalEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoOCDetaEN> iLisMovDetSal = new List<MovimientoOCDetaEN>();

                //variable para los correlativos de cada movimientoDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (InsumoFaltante xInsFal in xLisInsFal)
                {
                    //buscar a la existencia para este xInsFal
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExi, ExistenciaEN.CodAlm, xInsFal.CodigoAlmacen,
                        ExistenciaEN.CodExi, xInsFal.CodigoExistencia);

                    //creamos un objeto MovimientoDeta
                    MovimientoOCDetaEN iMovDetSalEN = new MovimientoOCDetaEN();

                    //pasar datos
                    iMovDetSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetSalEN.FechaMovimientoCabe = iMovCabSalEN.FechaMovimientoCabe;
                    iMovDetSalEN.PeriodoMovimientoCabe = iMovCabSalEN.PeriodoMovimientoCabe;
                    iMovDetSalEN.CodigoAlmacen = iMovCabSalEN.CodigoAlmacen;
                    iMovDetSalEN.CodigoTipoOperacion = iMovCabSalEN.CodigoTipoOperacion;
                    iMovDetSalEN.CCalculaPrecioPromedio = iTipOpeSalEN.CCalculaPrecioPromedio;
                    iMovDetSalEN.CClaseTipoOperacion = "2";//salida
                    iMovDetSalEN.NumeroMovimientoCabe = iMovCabSalEN.NumeroMovimientoCabe;
                    iMovDetSalEN.CodigoCentroCosto = string.Empty;
                    iMovDetSalEN.DescripcionCentroCosto = string.Empty;
                    iMovDetSalEN.CodigoExistencia = xInsFal.CodigoExistencia;
                    iMovDetSalEN.DescripcionExistencia = xInsFal.DescripcionExistencia;
                    iMovDetSalEN.CodigoUnidadMedida = xInsFal.CUnidadMedida;
                    iMovDetSalEN.NombreUnidadMedida = xInsFal.NUnidadMedida;
                    iMovDetSalEN.StockAnteriorExistencia = iExiBusEN.StockActualExistencia;
                    iMovDetSalEN.PrecioAnteriorExistencia = iExiBusEN.PrecioPromedioExistencia;
                    iMovDetSalEN.PrecioUnitarioMovimientoDeta = iExiBusEN.PrecioPromedioExistencia;
                    iMovDetSalEN.CantidadMovimientoDeta = xInsFal.CantidadFaltante;
                    iMovDetSalEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetSalEN);
                    iMovDetSalEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetSalEN);
                    iMovDetSalEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetSalEN);
                    iMovDetSalEN.GlosaMovimientoDeta = iMovCabSalEN.GlosaMovimientoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveMovimientoCabe = iMovCabSalEN.ClaveMovimientoCabe;
                    iMovDetSalEN.CorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoMovimientoDeta);
                    iMovDetSalEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetSalEN);

                    //adicionar a la lista de movimientoDeta de este MovimientoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //grabar lotesdeta
                LoteDetaRN.AdicionarLoteDetaOC(iLisMovDetSal);

                //creamos el objeto MovimientoCabe de ingreso transferencia
                MovimientoOCCabeEN iMovCabIngEN = new MovimientoOCCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabIngEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iInsFal.CodigoAlmacenProduccion;
                iMovCabIngEN.CodigoPersonal = iInsFal.CodigoPersonalProduccion;
                iMovCabIngEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(ref
                    iNumeroMovimientoCabeIngreso, iMovCabIngEN);
                iMovCabIngEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabIngEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoOCDetaEN> iLisMovDetIng = new List<MovimientoOCDetaEN>();

                //recorrer cada objeto MovimientoDetaSalida
                foreach (MovimientoOCDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto movimientoDeta
                    MovimientoOCDetaEN iMovDetIngEN = new MovimientoOCDetaEN();

                    //pasamos datos               
                    iMovDetIngEN.ClaveMovimientoCabe = iMovCabIngEN.ClaveMovimientoCabe;
                    iMovDetIngEN.CorrelativoMovimientoDeta = xMovDetSal.CorrelativoMovimientoDeta;
                    iMovDetIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetIngEN.FechaMovimientoCabe = iMovCabIngEN.FechaMovimientoCabe;
                    iMovDetIngEN.PeriodoMovimientoCabe = iMovCabIngEN.PeriodoMovimientoCabe;
                    iMovDetIngEN.CodigoAlmacen = iMovCabIngEN.CodigoAlmacen;
                    iMovDetIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                    iMovDetIngEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetIngEN.CCalculaPrecioPromedio = iTipOpeIngEN.CCalculaPrecioPromedio;
                    iMovDetIngEN.NumeroMovimientoCabe = iMovCabIngEN.NumeroMovimientoCabe;
                    iMovDetIngEN.CodigoCentroCosto = string.Empty;
                    iMovDetIngEN.CodigoExistencia = xMovDetSal.CodigoExistencia;
                    iMovDetIngEN.CodigoUnidadMedida = xMovDetSal.CodigoUnidadMedida;
                    iMovDetIngEN.CantidadMovimientoDeta = xMovDetSal.CantidadMovimientoDeta;
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = xMovDetSal.PrecioUnitarioMovimientoDeta;
                    iMovDetIngEN.GlosaMovimientoDeta = iMovCabIngEN.GlosaMovimientoCabe;
                    iMovDetIngEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = MovimientoOCDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExi);

                    //actualizar los datos anteriores de la existencia en el MovimientoDeta
                    iMovDetIngEN.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    iMovDetIngEN.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;

                    //actualizar calculos
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetIngEN);
                    iMovDetIngEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetIngEN);
                    iMovDetIngEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetIngEN);
                    iMovDetIngEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetIngEN);

                    //agregamos a la lista 
                    iLisMovDetIng.Add(iMovDetIngEN);
                }

                //actualizar al MovimientoCabeSalida con el ultimo dato
                iMovCabSalEN.ClaveIngresoMovimientoCabe = iMovCabIngEN.ClaveMovimientoCabe;

                //adicionamos a la lista de Movimientos Cabe a adicionar
                iLisMovCabAdi.Add(iMovCabSalEN);
                iLisMovCabAdi.Add(iMovCabIngEN);

                //adicionamos a la lista de movimientos deta a adicionar
                iLisMovDetAdi.AddRange(iLisMovDetSal);
                iLisMovDetAdi.AddRange(iLisMovDetIng);

                //traer la lista de existencias actualizadas por estos movimientos
                List<ExistenciaEN> iLisExiSalMod = MovimientoOCDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetSal);
                List<ExistenciaEN> iLisExiIngMod = MovimientoOCDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetIng);

                //adicionamos a la lista de existencias a modificar
                iLisExiMod.AddRange(iLisExiSalMod);
                iLisExiMod.AddRange(iLisExiIngMod);
            }

            //grabar en b.d
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            ExistenciaRN.ModificarExistencia(iLisExiMod);
        }

        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(ref string pNumeroMovimientoCabe, MovimientoOCCabeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //si este valor esta vacio,entonces traemos de la b.d
            if (pNumeroMovimientoCabe == string.Empty)
            {
                iNumero = ObtenerNuevoNumeroMovimientoCabeAutogenerado(pObj);
            }
            else
            {
                iNumero = Numero.IncrementarCorrelativoNumerico(pNumeroMovimientoCabe, 6);
            }

            //actualizamos al parametro pNumeroMovimientoCabe
            pNumeroMovimientoCabe = iNumero;

            //devuelve
            return iNumero;
        }

        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(MovimientoOCCabeEN pObj, List<MovimientoOCCabeEN> pLista,
            List<MovimientoOCCabeEN> pListaNumerosExcepcion)
        {
            //obtener el nuevo codigo para la lista
            string iNumero = ObtenerNuevoNumeroMovimientoCabeAutogenerado(pObj, pLista);

            //recorrer cada objeto
            foreach (MovimientoOCCabeEN xMovCab in pListaNumerosExcepcion)
            {
                if (xMovCab.CodigoAlmacen == pObj.CodigoAlmacen && xMovCab.CodigoTipoOperacion == pObj.CodigoTipoOperacion &&
                    xMovCab.NumeroMovimientoCabe == iNumero)
                {
                    //obtener el siguiente codigo
                    iNumero = Numero.IncrementarCorrelativoNumerico(iNumero, 6);
                }
            }

            //devuelve
            return iNumero;
        }

        public static void ImportarIngresosDeExcel(List<MovimientoOCDetaEN> pListaMovimientoDetaExcel)
        {
            //obtener una lista de listas de movimientos deta,donde cada uno sera un movimiento Ingreso
            List<List<MovimientoOCDetaEN>> iLisLisMovDet = MovimientoOCDetaRN.ListarListasMovimientosDetaParaImportar(pListaMovimientoDetaExcel);

            //obtener una lista de movimientos deta pero de los auxiliares distintos que hay en la lista pListaMovimientoDetaExcel
            List<MovimientoOCDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<MovimientoOCDetaEN>(pListaMovimientoDetaExcel,
                MovimientoOCDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //traer lista de movimientos cabe que no se pueden eliminar al importar
            List<MovimientoOCCabeEN> iLisMovCabNoImp = ListarMovimientoCabesNoImportadosIngreso(ListaG.ObtenerPrimerValor<MovimientoOCDetaEN>(
                pListaMovimientoDetaExcel, MovimientoOCDetaEN.PerMovCab));

            //listas para adicionar los nuevos objetos
            List<MovimientoOCCabeEN> iLisMovCabAdi = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<MovimientoOCDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                MovimientoOCDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este movimiento
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo movimientoCabe
                MovimientoOCCabeEN iMovCabNueEN = new MovimientoOCCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoMovimientoCabe = iMovDetEN.PeriodoMovimientoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi, iLisMovCabNoImp);
                iMovCabNueEN.FechaMovimientoCabe = iMovDetEN.FechaMovimientoCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iMovDetEN.CodigoAuxiliar;
                iMovCabNueEN.OrdenCompra = iMovDetEN.OrdenCompra;
                iMovCabNueEN.CTipoDocumento = iMovDetEN.CTipoDocumento;
                iMovCabNueEN.SerieDocumento = iMovDetEN.SerieDocumento;
                iMovCabNueEN.NumeroDocumento = iMovDetEN.NumeroDocumento;
                iMovCabNueEN.FechaDocumento = iMovDetEN.FechaDocumento;
                iMovCabNueEN.GlosaMovimientoCabe = iMovDetEN.GlosaMovimientoDeta;
                iMovCabNueEN.COrigenVentanaCreacion = "5";//Importado excel
                iMovCabNueEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabNueEN);

                //adicionamos a la lista de MovimientoCabe para adicionar
                iLisMovCabAdi.Add(iMovCabNueEN);

                //buscar al tipo de operacion para este movimiento
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe,
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los MovimientosDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (MovimientoOCDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoMovimientoDeta);

                    //buscar a la existencia de este movimiento
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        MovimientoOCDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto MovimientoDeta
                    MovimientoOCDetaEN iMovDetNueEN = new MovimientoOCDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroMovimientoCabe = iMovCabNueEN.NumeroMovimientoCabe;
                    iMovDetNueEN.ClaveMovimientoCabe = iMovCabNueEN.ClaveMovimientoCabe;
                    iMovDetNueEN.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                    iMovDetNueEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetNueEN);
                    iMovDetNueEN.CodigoEmpresa = iMovCabNueEN.CodigoEmpresa;
                    iMovDetNueEN.FechaMovimientoCabe = iMovCabNueEN.FechaMovimientoCabe;
                    iMovDetNueEN.PeriodoMovimientoCabe = iMovCabNueEN.PeriodoMovimientoCabe;
                    iMovDetNueEN.CodigoAlmacen = iMovCabNueEN.CodigoAlmacen;
                    iMovDetNueEN.CodigoTipoOperacion = iMovCabNueEN.CodigoTipoOperacion;
                    iMovDetNueEN.CCalculaPrecioPromedio = iTipOpeEN.CCalculaPrecioPromedio;
                    iMovDetNueEN.CConversionUnidad = iTipOpeEN.CConversionUnidad;
                    iMovDetNueEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetNueEN.CodigoAuxiliar = iMovCabNueEN.CodigoAuxiliar;
                    iMovDetNueEN.CTipoDocumento = iMovCabNueEN.CTipoDocumento;
                    iMovDetNueEN.SerieDocumento = iMovCabNueEN.SerieDocumento;
                    iMovDetNueEN.NumeroDocumento = iMovCabNueEN.NumeroDocumento;
                    iMovDetNueEN.FechaDocumento = iMovCabNueEN.FechaDocumento;
                    iMovDetNueEN.CodigoCentroCosto = xMovDet.CodigoCentroCosto;
                    iMovDetNueEN.CodigoExistencia = xMovDet.CodigoExistencia;
                    iMovDetNueEN.CodigoUnidadMedida = iExiBusEN.CodigoUnidadMedida;
                    iMovDetNueEN.CodigoTipo = iExiBusEN.CodigoTipo;
                    iMovDetNueEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetNueEN.CEsUnidadConvertida = iExiBusEN.CEsUnidadConvertida;
                    iMovDetNueEN.FactorConversion = iExiBusEN.FactorConversion;
                    iMovDetNueEN.PrecioUnitarioConversion = MovimientoOCDetaRN.ObtenerPrecioUnitarioConvertido(iMovDetNueEN, xMovDet.PrecioUnitarioMovimientoDeta);
                    iMovDetNueEN.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitario(iMovDetNueEN,
                        xMovDet.PrecioUnitarioMovimientoDeta);
                    iMovDetNueEN.CantidadConversion = MovimientoOCDetaRN.ObtenerCantidadConvertido(iMovDetNueEN,
                        xMovDet.CantidadMovimientoDeta);
                    iMovDetNueEN.CantidadMovimientoDeta = MovimientoOCDetaRN.ObtenerCantidad(iMovDetNueEN,
                        xMovDet.CantidadMovimientoDeta);
                    iMovDetNueEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetNueEN);
                    iMovDetNueEN.GlosaMovimientoDeta = xMovDet.GlosaMovimientoDeta;

                    //adicionamos a la lista de MovimientoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicionOC(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            string iCodigoPeriodo = ListaG.ObtenerPrimerValor<MovimientoOCDetaEN>(pListaMovimientoDetaExcel, MovimientoOCDetaEN.PerMovCab);
            MovimientoOCCabeRN.EliminarAntesDeImportarIngreso(iCodigoPeriodo);

            //grabaciones masivas
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static void ImportarIngresosDeExcel1(List<MovimientoOCDetaEN> pListaMovimientoDetaExcel)
        {
            //obtener una lista de listas de movimientos deta,donde cada uno sera un movimiento Ingreso
            List<List<MovimientoOCDetaEN>> iLisLisMovDet = MovimientoOCDetaRN.ListarListasMovimientosDetaParaImportar(pListaMovimientoDetaExcel);

            //obtener una lista de movimientos deta pero de los auxiliares distintos que hay en la lista pListaMovimientoDetaExcel
            List<MovimientoOCDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<MovimientoOCDetaEN>(pListaMovimientoDetaExcel,
                MovimientoOCDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //listas para adicionar los nuevos objetos
            //List<MovimientoOCCabeEN> iLisMovCabAdi = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<MovimientoOCDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                MovimientoOCDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este movimiento
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo movimientoCabe
                MovimientoOCCabeEN iMovCabNueEN = new MovimientoOCCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoMovimientoCabe = iMovDetEN.PeriodoMovimientoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabNueEN);
                iMovCabNueEN.FechaMovimientoCabe = iMovDetEN.FechaMovimientoCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iMovDetEN.CodigoAuxiliar;
                iMovCabNueEN.OrdenCompra = iMovDetEN.OrdenCompra;
                iMovCabNueEN.CTipoDocumento = iMovDetEN.CTipoDocumento;
                iMovCabNueEN.SerieDocumento = iMovDetEN.SerieDocumento;
                iMovCabNueEN.NumeroDocumento = iMovDetEN.NumeroDocumento;
                iMovCabNueEN.FechaDocumento = iMovDetEN.FechaDocumento;
                iMovCabNueEN.GlosaMovimientoCabe = iMovDetEN.GlosaMovimientoDeta;
                iMovCabNueEN.COrigenVentanaCreacion = "9";//Importado excel
                iMovCabNueEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabNueEN);

                //adicionamos a la lista de MovimientoCabe para adicionar
                //iLisMovCabAdi.Add(iMovCabNueEN);

                //adicionar en b.d
                MovimientoOCCabeRN.AdicionarMovimientoCabe(iMovCabNueEN);

                //buscar al tipo de operacion para este movimiento
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe,
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los MovimientosDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (MovimientoOCDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoMovimientoDeta);

                    //buscar a la existencia de este movimiento
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        MovimientoOCDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto MovimientoDeta
                    MovimientoOCDetaEN iMovDetNueEN = new MovimientoOCDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroMovimientoCabe = iMovCabNueEN.NumeroMovimientoCabe;
                    iMovDetNueEN.ClaveMovimientoCabe = iMovCabNueEN.ClaveMovimientoCabe;
                    iMovDetNueEN.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                    iMovDetNueEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetNueEN);
                    iMovDetNueEN.CodigoEmpresa = iMovCabNueEN.CodigoEmpresa;
                    iMovDetNueEN.FechaMovimientoCabe = iMovCabNueEN.FechaMovimientoCabe;
                    iMovDetNueEN.PeriodoMovimientoCabe = iMovCabNueEN.PeriodoMovimientoCabe;
                    iMovDetNueEN.CodigoAlmacen = iMovCabNueEN.CodigoAlmacen;
                    iMovDetNueEN.CodigoTipoOperacion = iMovCabNueEN.CodigoTipoOperacion;
                    iMovDetNueEN.CCalculaPrecioPromedio = iTipOpeEN.CCalculaPrecioPromedio;
                    iMovDetNueEN.CConversionUnidad = iTipOpeEN.CConversionUnidad;
                    iMovDetNueEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetNueEN.CodigoAuxiliar = iMovCabNueEN.CodigoAuxiliar;
                    iMovDetNueEN.CTipoDocumento = iMovCabNueEN.CTipoDocumento;
                    iMovDetNueEN.SerieDocumento = iMovCabNueEN.SerieDocumento;
                    iMovDetNueEN.NumeroDocumento = iMovCabNueEN.NumeroDocumento;
                    iMovDetNueEN.FechaDocumento = iMovCabNueEN.FechaDocumento;
                    iMovDetNueEN.CodigoCentroCosto = xMovDet.CodigoCentroCosto;
                    iMovDetNueEN.CodigoExistencia = xMovDet.CodigoExistencia;
                    iMovDetNueEN.CodigoUnidadMedida = iExiBusEN.CodigoUnidadMedida;
                    iMovDetNueEN.CodigoTipo = iExiBusEN.CodigoTipo;
                    iMovDetNueEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetNueEN.CEsUnidadConvertida = iExiBusEN.CEsUnidadConvertida;
                    iMovDetNueEN.FactorConversion = iExiBusEN.FactorConversion;
                    iMovDetNueEN.PrecioUnitarioConversion = MovimientoOCDetaRN.ObtenerPrecioUnitarioConvertido(iMovDetNueEN,
                        xMovDet.PrecioUnitarioMovimientoDeta);
                    iMovDetNueEN.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitario(iMovDetNueEN,
                        xMovDet.PrecioUnitarioMovimientoDeta);
                    iMovDetNueEN.CantidadConversion = MovimientoOCDetaRN.ObtenerCantidadConvertido(iMovDetNueEN,
                        xMovDet.CantidadMovimientoDeta);
                    iMovDetNueEN.CantidadMovimientoDeta = MovimientoOCDetaRN.ObtenerCantidad(iMovDetNueEN,
                        xMovDet.CantidadMovimientoDeta);
                    iMovDetNueEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetNueEN);
                    iMovDetNueEN.GlosaMovimientoDeta = xMovDet.GlosaMovimientoDeta;

                    //adicionamos a la lista de MovimientoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicionOC(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);

            //grabaciones masivas
            //MovimientoOCCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static MovimientoOCCabeEN EsActoEliminarImportacionMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando no hay auxiliares importados
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoHayMovimientoCabesImportados(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //ok            
            return iMovCabEN;
        }

        public static MovimientoOCCabeEN EsActoEliminarImportacionMovimientoCabeIngreso(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando no hay auxiliares importados
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoHayMovimientoCabesImportadosIngresos(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //ok            
            return iMovCabEN;
        }

        public static MovimientoOCCabeEN EsActoEliminarImportacionMovimientoCabeSalida(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando no hay auxiliares importados
            iMovCabEN = MovimientoOCCabeRN.ValidaCuandoNoHayMovimientoCabesImportadosSalidas(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //ok            
            return iMovCabEN;
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesImportados(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesImportados(pObj);
        }

        public static MovimientoOCCabeEN ValidaCuandoNoHayMovimientoCabesImportados(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iAuxEN = new MovimientoOCCabeEN();

            //validar
            pObj.Adicionales.CampoOrden = MovimientoOCCabeEN.ClaMovCab;
            List<MovimientoOCCabeEN> iLisAuxImp = MovimientoOCCabeRN.ListarMovimientoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay Movimientos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static MovimientoOCCabeEN ValidaCuandoNoHayMovimientoCabesImportadosIngresos(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iAuxEN = new MovimientoOCCabeEN();

            //validar
            pObj.CClaseTipoOperacion = "1";//ingreso
            pObj.Adicionales.CampoOrden = MovimientoOCCabeEN.ClaMovCab;
            List<MovimientoOCCabeEN> iLisAuxImp = MovimientoOCCabeRN.ListarMovimientoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay Movimientos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static MovimientoOCCabeEN ValidaCuandoNoHayMovimientoCabesImportadosSalidas(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iAuxEN = new MovimientoOCCabeEN();

            //validar
            pObj.CClaseTipoOperacion = "2";//salida
            pObj.Adicionales.CampoOrden = MovimientoOCCabeEN.ClaMovCab;
            List<MovimientoOCCabeEN> iLisAuxImp = MovimientoOCCabeRN.ListarMovimientoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay Movimientos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static void GenerarMovimientoSalidaMasaYEnvasadoPorMigracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe)
        {
            //objeto cabe
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasar datos
            iMovCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovCabEN.FechaMovimientoCabe = pObj.FechaProduccionDeta;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iMovCabEN.FechaMovimientoCabe, "-");
            iMovCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iMovCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iMovCabEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iMovCabEN.CodigoPersonal = string.Empty;
            iMovCabEN.GlosaMovimientoCabe = "MIGRACION FASE MASA Y ENVASADO 2019";
            iMovCabEN.COrigenVentanaCreacion = "4";//produccion   
            iMovCabEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iProExiEN.CTipoDescarga = "'0','1'";//fase masa y control calidad
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(iProExiEN);

            //grabar movimientos deta
            MovimientoOCDetaRN.AdicionarMovimientoDetaPorSalidaInsumos(iLisProExi, iMovCabEN);

            //listar al movimientodeta
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iMovCabEN.ClaveMovimientoCabe);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDetaOC(iLisMovDet);

            //actualizar los precios unitarios                    
            ProduccionExisRN.ActualizarPreciosUnitariosDesdeExistencias(iLisProExi);

            //modificar produccionDeta
            pObj.FechaSalidaFaseMasa = pObj.FechaProduccionDeta;
            pObj.ClaveSalidaFaseMasa = iMovCabEN.ClaveMovimientoCabe;
            ProduccionDetaRN.ModificarPorSalidaInsumosFaseMasa(pObj);
        }

        public static void GenerarMovimientoIngresoUnidadesSelladasPorMigracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar a la produccion en bd
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj);

            //objeto cabe
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasar datos
            iMovCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovCabEN.FechaMovimientoCabe = iProDetEN.FechaProduccionDeta;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iMovCabEN.FechaMovimientoCabe, "-");
            iMovCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iMovCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iMovCabEN.CodigoAlmacen = iProDetEN.CodigoAlmacenSemiProducto;
            iMovCabEN.CodigoPersonal = string.Empty;
            iMovCabEN.GlosaMovimientoCabe = "MIGRACION INGRESO UNIDADES SELLADAS 2019";
            iMovCabEN.COrigenVentanaCreacion = "4";//produccion   
            iMovCabEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta                      
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientoDetaParaIngresoSemiElaborado(iProDetEN, iMovCabEN);

            //grabar movimientos deta
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDet);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDetaOC(iLisMovDet);

            //modificar produccionDeta           
            iProDetEN.ClaveIngresoSemiElaborado = iMovCabEN.ClaveMovimientoCabe;
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void GenerarMovimientoSalidaUnidadesAEmpaquetarPorMigracion(EncajadoEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar al encajado en bd
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //objeto cabe
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasar datos
            iMovCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovCabEN.FechaMovimientoCabe = iEncEN.FechaEncajado;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iMovCabEN.FechaMovimientoCabe, "-");
            iMovCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iMovCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iMovCabEN.CodigoAlmacen = "A11";
            iMovCabEN.CodigoPersonal = string.Empty;
            iMovCabEN.GlosaMovimientoCabe = "MIGRACION SALIDA UNIDADES A EMPAQUETAR 2019";
            iMovCabEN.COrigenVentanaCreacion = "4";//produccion   
            iMovCabEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta           
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientoDetaParaSalidaEmpaquetar(iEncEN, iMovCabEN);

            //grabar movimientos deta
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDet);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDetaOC(iLisMovDet);

            //actualizar el costo insumo de semi productos
            ProduccionProTerRN.ModificarCostoInsumoSemiProductoOC(iEncEN, iLisMovDet);

            //descontar producciones deta
            ProduccionDetaRN.DescontarUnidadesPorEmpaquetadoOC(iLisMovDet);

            //modificar Encajado           
            iEncEN.ClaveSalidaUnidadesEmpacar = iMovCabEN.ClaveMovimientoCabe;
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void GenerarMovimientoSalidaUnidadesNoPasanPorMigracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe)
        {
            //si no hay unidades desechas, entonces termina el proceso
            if (pObj.NumeroUnidadesNoPasanConCal == 0) { return; }

            //buscar a la produccion en bd
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj);

            //objeto cabe
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasar datos
            iMovCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovCabEN.FechaMovimientoCabe = iProDetEN.FechaProduccionDeta;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iMovCabEN.FechaMovimientoCabe, "-");
            iMovCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iMovCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iMovCabEN.CodigoAlmacen = iProDetEN.CodigoAlmacenSemiProducto;
            iMovCabEN.CodigoPersonal = string.Empty;
            iMovCabEN.GlosaMovimientoCabe = "MIGRACION SALIDA UNIDADES DESECHAS 2019";
            iMovCabEN.COrigenVentanaCreacion = "4";//produccion   
            iMovCabEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta           
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientoDetaParaSalidaNoPasan(iProDetEN, iMovCabEN);

            //grabar movimientos deta
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDet);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDetaOC(iLisMovDet);

            //modificar produccionDeta           
            iProDetEN.ClaveSalidaNoPasan = iMovCabEN.ClaveMovimientoCabe;
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void GenerarMovimientoSalidaEmpaquetadoPorMigracion(EncajadoEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar al encajado en bd
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //objeto cabe
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasar datos
            iMovCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovCabEN.FechaMovimientoCabe = iEncEN.FechaEncajado;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iMovCabEN.FechaMovimientoCabe, "-");
            iMovCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iMovCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iMovCabEN.CodigoAlmacen = "A09";
            iMovCabEN.CodigoPersonal = string.Empty;
            iMovCabEN.GlosaMovimientoCabe = "MIGRACION FASE EMPAQUETADO 2019";
            iMovCabEN.COrigenVentanaCreacion = "4";//produccion   
            iMovCabEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveEncajado = iEncEN.ClaveEncajado;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisAcumuladoXClaveEncajado(iProExiEN);

            //grabar movimientos deta
            MovimientoOCDetaRN.AdicionarMovimientoDetaPorSalidaInsumos(iLisProExi, iMovCabEN);

            //listar al movimientodeta
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iMovCabEN.ClaveMovimientoCabe);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDetaOC(iLisMovDet);

            //actualizar los costos de empaquetado
            ProduccionExisRN.ActualizarPreciosUnitariosDesdeExistencias(iLisProExi);

            //modificar encajado
            iEncEN.ClaveSalidaFaseEmpaquetado = iMovCabEN.ClaveMovimientoCabe;
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void GenerarMovimientoIngresoProductoTerminadoPorMigracion(EncajadoEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar al encajado en bd
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //objeto cabe
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasar datos
            iMovCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovCabEN.FechaMovimientoCabe = iEncEN.FechaEncajado;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iMovCabEN.FechaMovimientoCabe, "-");
            iMovCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iMovCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iMovCabEN.CodigoAlmacen = "A13";
            iMovCabEN.CodigoPersonal = string.Empty;
            iMovCabEN.GlosaMovimientoCabe = "MIGRACION INGRESO PRODUCTO TERMINADO 2019";
            iMovCabEN.COrigenVentanaCreacion = "4";//produccion   
            iMovCabEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta           
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientoDetaParaIngresoMercaderia(iEncEN, iMovCabEN);

            //grabar movimientos deta
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDet);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDetaOC(iLisMovDet);

            //modificar encajado    
            iEncEN.ClaveIngresoProductoTerminado = iMovCabEN.ClaveMovimientoCabe;
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void ImportarSalidasDeExcel(List<MovimientoOCDetaEN> pListaMovimientoDetaExcel)
        {
            //obtener una lista de listas de movimientos deta,donde cada uno sera un movimiento Salida
            List<List<MovimientoOCDetaEN>> iLisLisMovDet = MovimientoOCDetaRN.ListarListasMovimientosDetaParaImportar(pListaMovimientoDetaExcel);

            //obtener una lista de movimientos deta pero de los auxiliares distintos que hay en la lista pListaMovimientoDetaExcel
            List<MovimientoOCDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<MovimientoOCDetaEN>(pListaMovimientoDetaExcel,
                MovimientoOCDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //traer lista de movimientos cabe que no se pueden eliminar al importar
            List<MovimientoOCCabeEN> iLisMovCabNoImp = ListarMovimientoCabesNoImportadosSalida(ListaG.ObtenerPrimerValor<MovimientoOCDetaEN>(
                pListaMovimientoDetaExcel, MovimientoOCDetaEN.PerMovCab));

            //listas para adicionar los nuevos objetos
            List<MovimientoOCCabeEN> iLisMovCabAdi = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<MovimientoOCDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                MovimientoOCDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este movimiento
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo movimientoCabe
                MovimientoOCCabeEN iMovCabNueEN = new MovimientoOCCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoMovimientoCabe = iMovDetEN.PeriodoMovimientoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi, iLisMovCabNoImp);
                iMovCabNueEN.FechaMovimientoCabe = iMovDetEN.FechaMovimientoCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iMovDetEN.CodigoAuxiliar;
                iMovCabNueEN.OrdenCompra = iMovDetEN.OrdenCompra;
                iMovCabNueEN.CTipoDocumento = iMovDetEN.CTipoDocumento;
                iMovCabNueEN.SerieDocumento = iMovDetEN.SerieDocumento;
                iMovCabNueEN.NumeroDocumento = iMovDetEN.NumeroDocumento;
                iMovCabNueEN.FechaDocumento = iMovDetEN.FechaDocumento;
                iMovCabNueEN.GlosaMovimientoCabe = iMovDetEN.GlosaMovimientoDeta;
                iMovCabNueEN.COrigenVentanaCreacion = "5";//Importado excel
                iMovCabNueEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabNueEN);

                //adicionamos a la lista de MovimientoCabe para adicionar
                iLisMovCabAdi.Add(iMovCabNueEN);

                //buscar al tipo de operacion para este movimiento
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe,
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los MovimientosDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (MovimientoOCDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoMovimientoDeta);

                    //buscar a la existencia de este movimiento
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        MovimientoOCDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto MovimientoDeta
                    MovimientoOCDetaEN iMovDetNueEN = new MovimientoOCDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroMovimientoCabe = iMovCabNueEN.NumeroMovimientoCabe;
                    iMovDetNueEN.ClaveMovimientoCabe = iMovCabNueEN.ClaveMovimientoCabe;
                    iMovDetNueEN.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                    iMovDetNueEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetNueEN);
                    iMovDetNueEN.CodigoEmpresa = iMovCabNueEN.CodigoEmpresa;
                    iMovDetNueEN.FechaMovimientoCabe = iMovCabNueEN.FechaMovimientoCabe;
                    iMovDetNueEN.PeriodoMovimientoCabe = iMovCabNueEN.PeriodoMovimientoCabe;
                    iMovDetNueEN.CodigoAlmacen = iMovCabNueEN.CodigoAlmacen;
                    iMovDetNueEN.CodigoTipoOperacion = iMovCabNueEN.CodigoTipoOperacion;
                    iMovDetNueEN.CCalculaPrecioPromedio = iTipOpeEN.CCalculaPrecioPromedio;
                    iMovDetNueEN.CConversionUnidad = iTipOpeEN.CConversionUnidad;
                    iMovDetNueEN.CClaseTipoOperacion = "2";//salida
                    iMovDetNueEN.CodigoAuxiliar = iMovCabNueEN.CodigoAuxiliar;
                    iMovDetNueEN.CTipoDocumento = iMovCabNueEN.CTipoDocumento;
                    iMovDetNueEN.SerieDocumento = iMovCabNueEN.SerieDocumento;
                    iMovDetNueEN.NumeroDocumento = iMovCabNueEN.NumeroDocumento;
                    iMovDetNueEN.FechaDocumento = iMovCabNueEN.FechaDocumento;
                    iMovDetNueEN.CodigoCentroCosto = xMovDet.CodigoCentroCosto;
                    iMovDetNueEN.CodigoExistencia = xMovDet.CodigoExistencia;
                    iMovDetNueEN.CodigoUnidadMedida = iExiBusEN.CodigoUnidadMedida;
                    iMovDetNueEN.CodigoTipo = iExiBusEN.CodigoTipo;
                    iMovDetNueEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetNueEN.CEsUnidadConvertida = iExiBusEN.CEsUnidadConvertida;
                    iMovDetNueEN.FactorConversion = iExiBusEN.FactorConversion;
                    iMovDetNueEN.CantidadMovimientoDeta = xMovDet.CantidadMovimientoDeta;
                    iMovDetNueEN.PrecioUnitarioMovimientoDeta = xMovDet.PrecioUnitarioMovimientoDeta;
                    iMovDetNueEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetNueEN);
                    iMovDetNueEN.GlosaMovimientoDeta = xMovDet.GlosaMovimientoDeta;

                    //adicionamos a la lista de MovimientoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicionOC(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            string iCodigoPeriodo = ListaG.ObtenerPrimerValor<MovimientoOCDetaEN>(pListaMovimientoDetaExcel, MovimientoOCDetaEN.PerMovCab);
            MovimientoOCCabeRN.EliminarAntesDeImportarSalida(iCodigoPeriodo);

            //grabaciones masivas
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static void RegenerarMovimientosTransferenciaYFaseMasa()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //eliminar los movimientos de transferencia de ingreso y salida al almacen de produccion
            MovimientoOCCabeRN.EliminarAntesDeRegenerar(iPeriodo);

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer una lista de listas de produccionesDeta por dia(cada lista son producciones de un solo dia)
            List<List<ProduccionDetaEN>> iLisLisProDetDia = ProduccionDetaRN.ListarProduccionDetaParaRecalculoProduccion(iAño, iCodigoMes);

            //traer todos los saldos del año que tiene el periodo elegido
            List<SaldoEN> iLisSalAño = SaldoRN.ListarSaldosDeAño(iAño);

            //objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de salida de produccion
            TipoOperacionEN iTipOpeSalEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionProduccionSalida);

            //recorrer cada lista
            foreach (List<ProduccionDetaEN> xLisProDet in iLisLisProDetDia)
            {
                //traer una lista de listas de movimientos deta hasta el dia de las producciones deta
                List<List<MovimientoOCDetaEN>> iLisLisMovDetDia = MovimientoOCDetaRN.ListaListasMovimientosDetaPorFechaMenorOIgualQue(iPeriodo,
                    xLisProDet[0].FechaProduccionDeta);

                //recalcular(actualiza a la lista existencia con su nuevo saldo y precio promedio)
                MovimientoOCDetaRN.Recalcular(iAño, iCodigoMes, iLisExiEmp, iLisSalAño, iLisLisMovDetDia);

                //listar los insumos para transferir
                List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosParaTransferirAProducccion(xLisProDet, iLisExiEmp);

                //generar las transferencias
                MovimientoOCCabeRN.GenerarTransferenciasAutomaticasAProduccion(iLisInsFal, iLisExiEmp);

                //modificar por transferencias automatocas
                ProduccionDetaRN.ModificarPorTransferenciaAutomatica(xLisProDet);

                //generar los movimientos de salida fase masa y envasado               
                //recorrer cada objeto produccionDeta
                foreach (ProduccionDetaEN xProDet in xLisProDet)
                {
                    //generar la salida de masa y envasado
                    MovimientoOCCabeRN.GenerarMovimientoSalidaMasaYEnvasadoPorRegeneracion(xProDet, iTipOpeSalEN, iLisExiEmp);
                }


            }

        }

        public static void EliminarAntesDeRegenerar(string pCodigoPeriodo)
        {
            MovimientoOCDetaRN.EliminarMovimientosDetaAlmacenProduccionParaRegenerar(pCodigoPeriodo);
            MovimientoOCCabeRN.EliminarMovimientosCabeAlmacenProduccionParaRegenerar(pCodigoPeriodo);
            MovimientoOCDetaRN.EliminarMovimientosDetaAlmacenesCompraParaRegenerar(pCodigoPeriodo);
            MovimientoOCCabeRN.EliminarMovimientosCabeAlmacenesCompraParaRegenerar(pCodigoPeriodo);
            ProduccionDetaRN.ModificarProduccionDetaParaRegenerar(pCodigoPeriodo);
        }

        public static void EliminarMovimientoCabeXPeriodoYAlmacen(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.EliminarMovimientoCabeXPeriodoYAlmacen(pObj);
        }

        public static void EliminarMovimientosCabeAlmacenProduccionParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CodigoAlmacen = "A10";//almacen de produccion

            //ejecutar metodo
            MovimientoOCCabeRN.EliminarMovimientoCabeXPeriodoYAlmacen(iMovCabEN);
        }

        public static void EliminarMovimientoCabeAlmacenesCompraParaRegenerar(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.EliminarMovimientoCabeAlmacenesCompraParaRegenerar(pObj);
        }

        public static void EliminarMovimientosCabeAlmacenesCompraParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovDetEN = new MovimientoOCCabeEN();
            iMovDetEN.PeriodoMovimientoCabe = pCodigoPeriodo;

            //ejecutar metodo
            MovimientoOCCabeRN.EliminarMovimientoCabeAlmacenesCompraParaRegenerar(iMovDetEN);
        }

        public static void GenerarTransferenciasAutomaticasAProduccion(List<InsumoFaltante> pLisInsTra, List<ExistenciaEN> pLisExi)
        {
            //separar en listas los insumos por almacen
            List<List<InsumoFaltante>> iLisLisInsTraAlm = ListaG.ListarListas<InsumoFaltante>(pLisInsTra, InsumoFaltante.CodAlm);

            //obtener la fecha para estos movimientos de transferencia(este dato sale de la fecha de produccion de estos insumos)
            string iFechaMovimientoCabe = ListaG.ObtenerPrimerValor<InsumoFaltante>(pLisInsTra, InsumoFaltante.FecPro);

            //traemos al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeSalEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaSalida);

            //traemos al tipo de operacion de transferencia ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaIngreso);

            //listas para adicionar y modificar en b.d
            List<MovimientoOCCabeEN> iLisMovCabAdi = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero movimiento para el ingreso
            string iNumeroMovimientoCabeIngreso = string.Empty;

            //recorrer cada lista
            foreach (List<InsumoFaltante> xLisInsFal in iLisLisInsTraAlm)
            {
                //obtener al primer objeto de la lista
                InsumoFaltante iInsFal = xLisInsFal[0];

                //creamos el objeto MovimientoCabe de salida transferencia
                MovimientoOCCabeEN iMovCabSalEN = new MovimientoOCCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabSalEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iInsFal.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iInsFal.CodigoPersonal;
                iMovCabSalEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabSalEN);
                iMovCabSalEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabSalEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoOCDetaEN> iLisMovDetSal = new List<MovimientoOCDetaEN>();

                //variable para los correlativos de cada movimientoDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (InsumoFaltante xInsFal in xLisInsFal)
                {
                    //buscar a la existencia para este xInsFal
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(pLisExi, ExistenciaEN.CodAlm, xInsFal.CodigoAlmacen,
                        ExistenciaEN.CodExi, xInsFal.CodigoExistencia);

                    //creamos un objeto MovimientoDeta
                    MovimientoOCDetaEN iMovDetSalEN = new MovimientoOCDetaEN();

                    //pasar datos
                    iMovDetSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetSalEN.FechaMovimientoCabe = iMovCabSalEN.FechaMovimientoCabe;
                    iMovDetSalEN.PeriodoMovimientoCabe = iMovCabSalEN.PeriodoMovimientoCabe;
                    iMovDetSalEN.CodigoAlmacen = iMovCabSalEN.CodigoAlmacen;
                    iMovDetSalEN.CodigoTipoOperacion = iMovCabSalEN.CodigoTipoOperacion;
                    iMovDetSalEN.CCalculaPrecioPromedio = iTipOpeSalEN.CCalculaPrecioPromedio;
                    iMovDetSalEN.CClaseTipoOperacion = "2";//salida
                    iMovDetSalEN.NumeroMovimientoCabe = iMovCabSalEN.NumeroMovimientoCabe;
                    iMovDetSalEN.CodigoCentroCosto = string.Empty;
                    iMovDetSalEN.DescripcionCentroCosto = string.Empty;
                    iMovDetSalEN.CodigoExistencia = xInsFal.CodigoExistencia;
                    iMovDetSalEN.DescripcionExistencia = xInsFal.DescripcionExistencia;
                    iMovDetSalEN.CodigoUnidadMedida = xInsFal.CUnidadMedida;
                    iMovDetSalEN.NombreUnidadMedida = xInsFal.NUnidadMedida;
                    iMovDetSalEN.StockAnteriorExistencia = iExiBusEN.StockActualExistencia;
                    iMovDetSalEN.PrecioAnteriorExistencia = iExiBusEN.PrecioPromedioExistencia;
                    iMovDetSalEN.PrecioUnitarioMovimientoDeta = iExiBusEN.PrecioPromedioExistencia;
                    iMovDetSalEN.CantidadMovimientoDeta = xInsFal.CantidadFaltante;
                    iMovDetSalEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetSalEN);
                    iMovDetSalEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetSalEN);
                    iMovDetSalEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetSalEN);
                    iMovDetSalEN.GlosaMovimientoDeta = iMovCabSalEN.GlosaMovimientoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveMovimientoCabe = iMovCabSalEN.ClaveMovimientoCabe;
                    iMovDetSalEN.CorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoMovimientoDeta);
                    iMovDetSalEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetSalEN);

                    //adicionar a la lista de movimientoDeta de este MovimientoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //creamos el objeto MovimientoCabe de ingreso transferencia
                MovimientoOCCabeEN iMovCabIngEN = new MovimientoOCCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabIngEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iInsFal.CodigoAlmacenProduccion;
                iMovCabIngEN.CodigoPersonal = iInsFal.CodigoPersonalProduccion;
                iMovCabIngEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(ref
                    iNumeroMovimientoCabeIngreso, iMovCabIngEN);
                iMovCabIngEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabIngEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoOCDetaEN> iLisMovDetIng = new List<MovimientoOCDetaEN>();

                //recorrer cada objeto MovimientoDetaSalida
                foreach (MovimientoOCDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto movimientoDeta
                    MovimientoOCDetaEN iMovDetIngEN = new MovimientoOCDetaEN();

                    //pasamos datos               
                    iMovDetIngEN.ClaveMovimientoCabe = iMovCabIngEN.ClaveMovimientoCabe;
                    iMovDetIngEN.CorrelativoMovimientoDeta = xMovDetSal.CorrelativoMovimientoDeta;
                    iMovDetIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetIngEN.FechaMovimientoCabe = iMovCabIngEN.FechaMovimientoCabe;
                    iMovDetIngEN.PeriodoMovimientoCabe = iMovCabIngEN.PeriodoMovimientoCabe;
                    iMovDetIngEN.CodigoAlmacen = iMovCabIngEN.CodigoAlmacen;
                    iMovDetIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                    iMovDetIngEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetIngEN.CCalculaPrecioPromedio = iTipOpeIngEN.CCalculaPrecioPromedio;
                    iMovDetIngEN.NumeroMovimientoCabe = iMovCabIngEN.NumeroMovimientoCabe;
                    iMovDetIngEN.CodigoCentroCosto = string.Empty;
                    iMovDetIngEN.CodigoExistencia = xMovDetSal.CodigoExistencia;
                    iMovDetIngEN.CodigoUnidadMedida = xMovDetSal.CodigoUnidadMedida;
                    iMovDetIngEN.CantidadMovimientoDeta = xMovDetSal.CantidadMovimientoDeta;
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = xMovDetSal.PrecioUnitarioMovimientoDeta;
                    iMovDetIngEN.GlosaMovimientoDeta = iMovCabIngEN.GlosaMovimientoCabe;
                    iMovDetIngEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = MovimientoOCDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                    //actualizar los datos anteriores de la existencia en el MovimientoDeta
                    iMovDetIngEN.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    iMovDetIngEN.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;

                    //actualizar calculos
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetIngEN);
                    iMovDetIngEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetIngEN);
                    iMovDetIngEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetIngEN);
                    iMovDetIngEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetIngEN);

                    //agregamos a la lista 
                    iLisMovDetIng.Add(iMovDetIngEN);
                }

                //actualizar al MovimientoCabeSalida con el ultimo dato
                iMovCabSalEN.ClaveIngresoMovimientoCabe = iMovCabIngEN.ClaveMovimientoCabe;

                //adicionamos a la lista de Movimientos Cabe a adicionar
                iLisMovCabAdi.Add(iMovCabSalEN);
                iLisMovCabAdi.Add(iMovCabIngEN);

                //adicionamos a la lista de movimientos deta a adicionar
                iLisMovDetAdi.AddRange(iLisMovDetSal);
                iLisMovDetAdi.AddRange(iLisMovDetIng);

                //traer la lista de existencias actualizadas por estos movimientos
                MovimientoOCDetaRN.ExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetSal, pLisExi);
                MovimientoOCDetaRN.ExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetIng, pLisExi);
            }

            //grabar en b.d
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
        }

        public static void GenerarMovimientoSalidaMasaYEnvasadoPorRegeneracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe, List<ExistenciaEN> pLisExi)
        {
            //objeto cabe
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //pasar datos
            iMovCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iMovCabEN.FechaMovimientoCabe = pObj.FechaProduccionDeta;
            iMovCabEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iMovCabEN.FechaMovimientoCabe, "-");
            iMovCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iMovCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iMovCabEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iMovCabEN.CodigoPersonal = string.Empty;
            iMovCabEN.GlosaMovimientoCabe = string.Empty;
            iMovCabEN.COrigenVentanaCreacion = "4";//produccion   
            iMovCabEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iProExiEN.CTipoDescarga = "'0','1'";//fase masa y control calidad
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(iProExiEN);

            //grabar movimientos deta
            MovimientoOCDetaRN.AdicionarMovimientoDetaPorSalidaInsumos(iLisProExi, iMovCabEN, pLisExi);

            //listar al movimientodeta
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iMovCabEN.ClaveMovimientoCabe);

            //actualizar existencias por adicion de movimiento
            MovimientoOCDetaRN.ExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDet, pLisExi);

            //modificar produccionDeta
            pObj.FechaSalidaFaseMasa = pObj.FechaProduccionDeta;
            pObj.ClaveSalidaFaseMasa = iMovCabEN.ClaveMovimientoCabe;
            ProduccionDetaRN.ModificarPorSalidaInsumosFaseMasa(pObj);
        }

        public static void RegenerarMovimientosDetalleIngresosSemiProductos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas las producciones deta del periodo en proceso
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaParaRecalculoManoObra(iAño, iCodigoMes);

            //traer todo el movimientoCabe del periodo en proceso
            List<MovimientoOCCabeEN> iLisMovCab = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoOCCabeEN> iLisMovCabMod = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<MovimientoOCDetaEN> iLisMovDetMod = new List<MovimientoOCDetaEN>();

            //recorrer cada produccion deta
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //operacion para agregar el detalle que le falta a los movimientos ingreso al almacen de semi productos
                if (xProDet.ClaveIngresoSemiElaborado != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoOCCabeEN iMovCabEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, xProDet.ClaveIngresoSemiElaborado);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = xProDet.FechaProduccionDeta;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //segun si existe en movimientodeta en bd
                    MovimientoOCDetaEN iMovDetBus = ListaG.Buscar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab, iMovCabEN.ClaveMovimientoCabe);
                    if (iMovDetBus.ClaveMovimientoDeta != string.Empty)
                    {
                        //actualizar datos
                        iMovDetBus.FechaMovimientoCabe = xProDet.FechaProduccionDeta;

                        //agregar a la lista resultado
                        iLisMovDetMod.Add(iMovDetBus);
                    }
                    else
                    {
                        //crear su movimientodeta                   
                        MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoSemiElaborado(xProDet, iMovCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }
                }
            }

            //grabar masivo
            MovimientoOCCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            MovimientoOCDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesXPeriodo(string pAño, string pCodigoMes)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iMovCabEN.Adicionales.CampoOrden = MovimientoOCCabeEN.ClaMovCab;

            //ejecutar metodo
            return MovimientoOCCabeRN.ListarMovimientoCabesXPeriodo(iMovCabEN);
        }

        public static void RegenerarMovimientosDetalleSalidaTransferenciaSemiProductos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas liberaciones del periodo en proceso
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoCabe del periodo en proceso
            List<MovimientoOCCabeEN> iLisMovCab = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoOCCabeEN> iLisMovCabMod = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<MovimientoOCDetaEN> iLisMovDetMod = new List<MovimientoOCDetaEN>();
            List<LiberacionEN> iLisLibMod = new List<LiberacionEN>();

            //recorrer cada liberacion
            foreach (LiberacionEN xLib in iLisLib)
            {
                //actualizar a la fecha de liberacion cuando esta sea igual o menor a la fechaProduccion
                if (Fecha.EsMayorQue(xLib.FechaLiberacion, xLib.FechaProduccionDeta) == false)
                {
                    //la nueva fecha de liberacion sera un dia mas al dia de produccion
                    xLib.FechaLiberacion = Fecha.ObtenerFechaFinal(xLib.FechaProduccionDeta, 1);

                    //agregar a la lista a modificar
                    iLisLibMod.Add(xLib);
                }

                //operacion para agregar el detalle que le falta a los movimientos salida transferencia del almacen de semi productos
                if (xLib.ClaveSalidaTransferenciaDesechas != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoOCCabeEN iMovCabEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaDesechas);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //segun si existe en movimientodeta en bd
                    MovimientoOCDetaEN iMovDetBus = ListaG.Buscar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab, iMovCabEN.ClaveMovimientoCabe);
                    if (iMovDetBus.ClaveMovimientoDeta != string.Empty)
                    {
                        //actualizar datos
                        iMovDetBus.FechaMovimientoCabe = xLib.FechaLiberacion;

                        //agregar a la lista resultado
                        iLisMovDetMod.Add(iMovDetBus);
                    }
                    else
                    {
                        //crear su movimientodeta                   
                        MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesDesechos(xLib, iMovCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al movimiento ingreso transferencia
                    MovimientoOCCabeEN iMovCabIngTraEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovCabIngTraEN.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    MovimientoOCDetaEN iMovDetIngBus = ListaG.Buscar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovDetIngBus.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }

                //operacion para agregar el detalle que le falta a los movimientos salida transferencia del almacen de semi productos
                if (xLib.ClaveSalidaTransferenciaReproceso != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoOCCabeEN iMovCabEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaReproceso);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //segun si existe en movimientodeta en bd
                    MovimientoOCDetaEN iMovDetBus = ListaG.Buscar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab, iMovCabEN.ClaveMovimientoCabe);
                    if (iMovDetBus.ClaveMovimientoDeta != string.Empty)
                    {
                        //actualizar datos
                        iMovDetBus.FechaMovimientoCabe = xLib.FechaLiberacion;

                        //agregar a la lista resultado
                        iLisMovDetMod.Add(iMovDetBus);
                    }
                    else
                    {
                        //crear su movimientodeta                   
                        MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesReproceso(xLib, iMovCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al movimiento ingreso transferencia
                    MovimientoOCCabeEN iMovCabIngTraEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovCabIngTraEN.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    MovimientoOCDetaEN iMovDetIngBus = ListaG.Buscar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovDetIngBus.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }

                //operacion para agregar el detalle que le falta a los movimientos salida transferencia del almacen de semi productos
                if (xLib.ClaveSalidaTransferenciaDonacion != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoOCCabeEN iMovCabEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaDonacion);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //segun si existe en movimientodeta en bd
                    MovimientoOCDetaEN iMovDetBus = ListaG.Buscar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab, iMovCabEN.ClaveMovimientoCabe);
                    if (iMovDetBus.ClaveMovimientoDeta != string.Empty)
                    {
                        //actualizar datos
                        iMovDetBus.FechaMovimientoCabe = xLib.FechaLiberacion;

                        //agregar a la lista resultado
                        iLisMovDetMod.Add(iMovDetBus);
                    }
                    else
                    {
                        //crear su movimientodeta                   
                        MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoUnidadesDonacion(xLib, iMovCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al movimiento ingreso transferencia
                    MovimientoOCCabeEN iMovCabIngTraEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovCabIngTraEN.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    MovimientoOCDetaEN iMovDetIngBus = ListaG.Buscar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovDetIngBus.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }
            }

            //grabar masivo
            LiberacionRN.ModificarLiberacion(iLisLibMod);
            MovimientoOCCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            MovimientoOCDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
        }

        public static void RegenerarMovimientosDetalleSalidasSemiProductos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas las producciones deta del periodo en proceso
            List<List<ProduccionProTerEN>> iLisLisProProTer = ProduccionProTerRN.ListarListasProduccionProTerPorClaveEncajado(iAño, iCodigoMes);

            //traer todo el movimientoCabe del periodo en proceso
            List<MovimientoOCCabeEN> iLisMovCab = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoOCCabeEN> iLisMovCabMod = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();

            //recorrer cada produccion deta
            foreach (List<ProduccionProTerEN> xLisProProTer in iLisLisProProTer)
            {
                //obtener el primer objeto de la lista
                ProduccionProTerEN iProProTerEN = xLisProProTer[0];

                //operacion para agregar el detalle que le falta a los movimientos ingreso al almacen de semi productos
                if (iProProTerEN.ClaveSalidaUnidadesEmpacar != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoOCCabeEN iMovCabEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, iProProTerEN.ClaveSalidaUnidadesEmpacar);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = iProProTerEN.FechaEncajado;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //preguntar si hay detalle
                    List<MovimientoOCDetaEN> iLisMovDetEnc = ListaG.Filtrar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab,
                        iProProTerEN.ClaveSalidaUnidadesEmpacar);
                    if (iLisMovDetEnc.Count == 0)
                    {
                        //recorrer cada objeto ProduccionProTer
                        foreach (ProduccionProTerEN xProProTer in xLisProProTer)
                        {
                            //crear su movimientodeta                   
                            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaSalidaEmpaquetar(xProProTer, iMovCabEN, iCenCosEN);

                            //agregar a la lista resultado
                            iLisMovDetAdi.Add(iMovDetEN);
                        }
                    }
                }
            }

            //grabar masivo
            MovimientoOCCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
        }

        public static void RegenerarMovimientosDetalleIngresosProductosTerminados()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas las producciones deta del periodo en proceso
            List<List<ProduccionProTerEN>> iLisLisProProTer = ProduccionProTerRN.ListarListasProduccionProTerPorClaveEncajado(iAño, iCodigoMes);

            //traer todo el movimientoCabe del periodo en proceso
            List<MovimientoOCCabeEN> iLisMovCab = MovimientoOCCabeRN.ListarMovimientoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoOCCabeEN> iLisMovCabMod = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();

            //recorrer cada produccion deta
            foreach (List<ProduccionProTerEN> xLisProProTer in iLisLisProProTer)
            {
                //obtener el primer objeto de la lista
                ProduccionProTerEN iProProTerEN = xLisProProTer[0];

                //operacion para agregar el detalle que le falta a los movimientos ingreso al almacen de semi productos
                if (iProProTerEN.ClaveIngresoProductoTerminado != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoOCCabeEN iMovCabEN = ListaG.Buscar<MovimientoOCCabeEN>(iLisMovCab, MovimientoOCCabeEN.ClaMovCab, iProProTerEN.ClaveIngresoProductoTerminado);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = iProProTerEN.FechaEncajado;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //preguntar si hay detalle
                    List<MovimientoOCDetaEN> iLisMovDetEnc = ListaG.Filtrar<MovimientoOCDetaEN>(iLisMovDet, MovimientoOCDetaEN.ClaMovCab,
                        iProProTerEN.ClaveIngresoProductoTerminado);
                    if (iLisMovDetEnc.Count == 0)
                    {
                        //recorrer cada objeto ProduccionProTer
                        foreach (ProduccionProTerEN xProProTer in xLisProProTer)
                        {
                            //crear su movimientodeta                   
                            MovimientoOCDetaEN iMovDetEN = MovimientoOCDetaRN.CrearMovimientoDetaParaIngresoMercaderia(xProProTer, iMovCabEN, iCenCosEN);

                            //agregar a la lista resultado
                            iLisMovDetAdi.Add(iMovDetEN);
                        }
                    }
                }
            }

            //grabar masivo
            MovimientoOCCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
        }

        public static void RegenerarCamposDetallesLiberacionProTer()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //modificar los saldos unidades a empacar
            LiberacionRN.ModificarSaldoUnidadesAEmpacarInicial(iAño, iCodigoMes);

            //traer todas las producciones proter del periodo en proceso
            List<List<ProduccionProTerEN>> iLisLisProProTer = ProduccionProTerRN.ListarListasProduccionProTerParaRegenerarCamposDetalleProTer(iAño, iCodigoMes);

            //listas a grabar en bd
            List<ProduccionProTerEN> iLisProProTerMod = new List<ProduccionProTerEN>();

            //recorrer cada lista
            foreach (List<ProduccionProTerEN> xLisProProTer in iLisLisProProTer)
            {
                //recorrer cada objeto
                foreach (ProduccionProTerEN xProProTer in xLisProProTer)
                {
                    //traer a las liberaciones para este proter
                    List<LiberacionEN> iLisLibProTer = LiberacionRN.ListarLiberacionParaEmpaquetarXCodigoSemiProducto(xProProTer);

                    //obtener la liberacion distribucion             
                    List<LiberacionProTer> iLisLibProTerDis = LiberacionRN.ListarLiberacionesDistribucion(iLisLibProTer, xProProTer.CantidadUnidadesProTer,
                        FormulaDetaRN.ObtenerNumeroDiasVcto(xProProTer));

                    //actualizar el campo detalle liberacion proter
                    xProProTer.DetalleCantidadesSemiProducto = ProduccionProTerRN.ConvertirListaACampoDetalleCantidadesSemiProducto(iLisLibProTerDis);

                    //creamos una lista con solo este objeto en proceso
                    List<ProduccionProTerEN> iLisProProTer = new List<ProduccionProTerEN>() { xProProTer };

                    //actualizamos el saldo liberacion
                    ProduccionProTerRN.ModificarSaldoLiberacionAlAdicionar(iLisProProTer);

                    //agregar a la lista resultado
                    iLisProProTerMod.Add(xProProTer);
                }
            }

            //grabar masivo
            ProduccionProTerRN.ModificarProduccionProTer(iLisProProTerMod);
        }

        public static void EliminarMovimientosTransferenciasGeneradas(LiberacionEN pLib)
        {
            //traer al objeto liberacion de bd
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pLib);

            //eliminar movimientos transferencia reproceso,si se llego a generar este movimiento
            if (iLibEN.ClaveSalidaTransferenciaReproceso != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveSalidaTransferenciaReproceso);
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveIngresoTransferenciaReproceso);
                EliminarMovimientoCabe(iLibEN.ClaveSalidaTransferenciaReproceso);
                EliminarMovimientoCabe(iLibEN.ClaveIngresoTransferenciaReproceso);
            }

            //eliminar movimientos transferencia desecho,si se llego a generar este movimiento
            if (iLibEN.ClaveSalidaTransferenciaDesechas != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveSalidaTransferenciaDesechas);
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveIngresoTransferenciaDesechas);
                EliminarMovimientoCabe(iLibEN.ClaveSalidaTransferenciaDesechas);
                EliminarMovimientoCabe(iLibEN.ClaveIngresoTransferenciaDesechas);
            }

            //eliminar movimientos transferencia donacion,si se llego a generar este movimiento
            if (iLibEN.ClaveSalidaTransferenciaDonacion != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveSalidaTransferenciaDonacion);
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveIngresoTransferenciaDonacion);
                EliminarMovimientoCabe(iLibEN.ClaveSalidaTransferenciaDonacion);
                EliminarMovimientoCabe(iLibEN.ClaveIngresoTransferenciaDonacion);
            }

            //eliminar movimientos transferencia muestra,si se llego a generar este movimiento
            if (iLibEN.ClaveSalidaTransferenciaMuestra != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveSalidaTransferenciaMuestra);
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveIngresoTransferenciaMuestra);
                EliminarMovimientoCabe(iLibEN.ClaveSalidaTransferenciaMuestra);
                EliminarMovimientoCabe(iLibEN.ClaveIngresoTransferenciaMuestra);
            }
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesNoImportados(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesNoImportados(pObj);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesNoImportadosIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "1";//ingreso
            iMovCabEN.Adicionales.CampoOrden = MovimientoOCCabeEN.ClaMovCab;

            //ejecutar metodo
            return ListarMovimientoCabesNoImportados(iMovCabEN);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesNoImportadosSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "2";//salida
            iMovCabEN.Adicionales.CampoOrden = MovimientoOCCabeEN.ClaMovCab;

            //ejecutar metodo
            return ListarMovimientoCabesNoImportados(iMovCabEN);
        }

        public static void RegenerarLotesYLotesDetaAMovimientos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoOCDetaEN> iLisMovDet = MovimientoOCDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoOCCabeEN> iLisMovCabMod = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();



            //grabar masivo
            MovimientoOCCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
        }

        public static void GenerarTransferenciasAutomaticasPorSincerado(ProduccionDetaEN pObj)
        {
            //segun si ya genero los movimientos de transferencia
            if (pObj.ClavesTransferenciaSincerado == string.Empty)
            {
                GenerarTransferenciasAutomaticasAlAdicionarPorSincerado(pObj);
            }
            else
            {
                GenerarTransferenciasAutomaticasAlModificarPorSincerado(pObj);
            }
        }

        public static void GenerarTransferenciasAutomaticasAlAdicionarPorSincerado(ProduccionDetaEN pObj)
        {
            //traer la lista de produciones exis de este pObj
            List<List<ProduccionExisEN>> iLisLisProExi = ProduccionExisRN.ListarListasProduccionExiParaTransferenciaSincerado(pObj.ClaveProduccionDeta);

            //obtener la fecha para estos movimientos de transferencia(este dato sale de la fecha de produccion de estos insumos)
            string iFechaMovimientoCabe = pObj.FechaProduccionDeta;

            //traemos al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeSalEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaSalida);

            //traemos al tipo de operacion de transferencia ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaIngreso);

            //traer la lista de existencias de la empresa actual
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistencias();

            //listas para adicionar y modificar en b.d
            List<MovimientoOCCabeEN> iLisMovCabAdi = new List<MovimientoOCCabeEN>();
            List<MovimientoOCDetaEN> iLisMovDetAdi = new List<MovimientoOCDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero movimiento para la salida
            string iNumeroMovimientoCabeSalida = string.Empty;

            //recorrer cada lista
            foreach (List<ProduccionExisEN> xLisProExi in iLisLisProExi)
            {
                //obtener al primer objeto de la lista
                ProduccionExisEN iProExi = xLisProExi[0];

                //creamos el objeto MovimientoCabe de salida transferencia
                MovimientoOCCabeEN iMovCabSalEN = new MovimientoOCCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabSalEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iProExi.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iProExi.CodigoPersonal;
                iMovCabSalEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA DE PRODUCCION SINCERADO";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(ref iNumeroMovimientoCabeSalida, iMovCabSalEN);
                iMovCabSalEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabSalEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoOCDetaEN> iLisMovDetSal = new List<MovimientoOCDetaEN>();

                //variable para los correlativos de cada movimientoDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (ProduccionExisEN xProExi in xLisProExi)
                {
                    //buscar a la existencia para este xProExi
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExi, ExistenciaEN.CodAlm, xProExi.CodigoAlmacen,
                        ExistenciaEN.CodExi, xProExi.CodigoExistencia);

                    //creamos un objeto MovimientoDeta
                    MovimientoOCDetaEN iMovDetSalEN = new MovimientoOCDetaEN();

                    //pasar datos
                    iMovDetSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetSalEN.FechaMovimientoCabe = iMovCabSalEN.FechaMovimientoCabe;
                    iMovDetSalEN.PeriodoMovimientoCabe = iMovCabSalEN.PeriodoMovimientoCabe;
                    iMovDetSalEN.CodigoAlmacen = iMovCabSalEN.CodigoAlmacen;
                    iMovDetSalEN.CodigoTipoOperacion = iMovCabSalEN.CodigoTipoOperacion;
                    iMovDetSalEN.CCalculaPrecioPromedio = iTipOpeSalEN.CCalculaPrecioPromedio;
                    iMovDetSalEN.CClaseTipoOperacion = "2";//salida
                    iMovDetSalEN.NumeroMovimientoCabe = iMovCabSalEN.NumeroMovimientoCabe;
                    iMovDetSalEN.CodigoCentroCosto = string.Empty;
                    iMovDetSalEN.DescripcionCentroCosto = string.Empty;
                    iMovDetSalEN.CodigoExistencia = xProExi.CodigoExistencia;
                    iMovDetSalEN.DescripcionExistencia = xProExi.DescripcionExistencia;
                    iMovDetSalEN.CodigoUnidadMedida = xProExi.CodigoUnidadMedida;
                    iMovDetSalEN.NombreUnidadMedida = xProExi.NombreUnidadMedida;
                    iMovDetSalEN.StockAnteriorExistencia = iExiBusEN.StockActualExistencia;
                    iMovDetSalEN.PrecioAnteriorExistencia = iExiBusEN.PrecioPromedioExistencia;
                    iMovDetSalEN.PrecioUnitarioMovimientoDeta = iExiBusEN.PrecioPromedioExistencia;
                    iMovDetSalEN.CantidadMovimientoDeta = xProExi.CantidadDevueltaProduccionExis;
                    iMovDetSalEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetSalEN);
                    iMovDetSalEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetSalEN);
                    iMovDetSalEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetSalEN);
                    iMovDetSalEN.GlosaMovimientoDeta = iMovCabSalEN.GlosaMovimientoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveMovimientoCabe = iMovCabSalEN.ClaveMovimientoCabe;
                    iMovDetSalEN.CorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoMovimientoDeta);
                    iMovDetSalEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetSalEN);

                    //adicionar a la lista de movimientoDeta de este MovimientoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //grabar lotesdeta
                LoteDetaRN.AdicionarLoteDetaOC(iLisMovDetSal);

                //creamos el objeto MovimientoCabe de ingreso transferencia
                MovimientoOCCabeEN iMovCabIngEN = new MovimientoOCCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabIngEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iProExi.CodigoAlmacenOrigen;
                iMovCabIngEN.CodigoPersonal = iProExi.CodigoPersonalOrigen;
                iMovCabIngEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA DE PRODUCCION SINCERADO";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroMovimientoCabe = MovimientoOCCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabIngEN);
                iMovCabIngEN.ClaveMovimientoCabe = MovimientoOCCabeRN.ObtenerClaveMovimientoCabe(iMovCabIngEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoOCDetaEN> iLisMovDetIng = new List<MovimientoOCDetaEN>();

                //recorrer cada objeto MovimientoDetaSalida
                foreach (MovimientoOCDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto movimientoDeta
                    MovimientoOCDetaEN iMovDetIngEN = new MovimientoOCDetaEN();

                    //pasamos datos               
                    iMovDetIngEN.ClaveMovimientoCabe = iMovCabIngEN.ClaveMovimientoCabe;
                    iMovDetIngEN.CorrelativoMovimientoDeta = xMovDetSal.CorrelativoMovimientoDeta;
                    iMovDetIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetIngEN.FechaMovimientoCabe = iMovCabIngEN.FechaMovimientoCabe;
                    iMovDetIngEN.PeriodoMovimientoCabe = iMovCabIngEN.PeriodoMovimientoCabe;
                    iMovDetIngEN.CodigoAlmacen = iMovCabIngEN.CodigoAlmacen;
                    iMovDetIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                    iMovDetIngEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetIngEN.CCalculaPrecioPromedio = iTipOpeIngEN.CCalculaPrecioPromedio;
                    iMovDetIngEN.NumeroMovimientoCabe = iMovCabIngEN.NumeroMovimientoCabe;
                    iMovDetIngEN.CodigoCentroCosto = string.Empty;
                    iMovDetIngEN.CodigoExistencia = xMovDetSal.CodigoExistencia;
                    iMovDetIngEN.CodigoUnidadMedida = xMovDetSal.CodigoUnidadMedida;
                    iMovDetIngEN.CantidadMovimientoDeta = xMovDetSal.CantidadMovimientoDeta;
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = xMovDetSal.PrecioUnitarioMovimientoDeta;
                    iMovDetIngEN.GlosaMovimientoDeta = iMovCabIngEN.GlosaMovimientoCabe;
                    iMovDetIngEN.ClaveMovimientoDeta = MovimientoOCDetaRN.ObtenerClaveMovimientoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = MovimientoOCDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExi);

                    //actualizar los datos anteriores de la existencia en el MovimientoDeta
                    iMovDetIngEN.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    iMovDetIngEN.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;

                    //actualizar calculos
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = MovimientoOCDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetIngEN);
                    iMovDetIngEN.CostoMovimientoDeta = MovimientoOCDetaRN.ObtenerCosto(iMovDetIngEN);
                    iMovDetIngEN.StockExistencia = MovimientoOCDetaRN.ObtenerNuevoStockPorAdicion(iMovDetIngEN);
                    iMovDetIngEN.PrecioExistencia = MovimientoOCDetaRN.ObtenerNuevoPrecioPromedio(iMovDetIngEN);

                    //agregamos a la lista 
                    iLisMovDetIng.Add(iMovDetIngEN);
                }

                //actualizar al MovimientoCabeSalida con el ultimo dato
                iMovCabSalEN.ClaveIngresoMovimientoCabe = iMovCabIngEN.ClaveMovimientoCabe;

                //adicionamos a la lista de Movimientos Cabe a adicionar
                iLisMovCabAdi.Add(iMovCabSalEN);
                iLisMovCabAdi.Add(iMovCabIngEN);

                //adicionamos a la lista de movimientos deta a adicionar
                iLisMovDetAdi.AddRange(iLisMovDetSal);
                iLisMovDetAdi.AddRange(iLisMovDetIng);

                //traer la lista de existencias actualizadas por estos movimientos
                List<ExistenciaEN> iLisExiSalMod = MovimientoOCDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetSal);
                List<ExistenciaEN> iLisExiIngMod = MovimientoOCDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetIng);

                //adicionamos a la lista de existencias a modificar
                iLisExiMod.AddRange(iLisExiSalMod);
                iLisExiMod.AddRange(iLisExiIngMod);
            }

            //guardando cada clave de movimiento salida en el objeto produccionDeta
            pObj.ClavesTransferenciaSincerado = ListaG.ArmarCadenaDeValores<MovimientoOCCabeEN>(iLisMovCabAdi, MovimientoOCCabeEN.ClaMovCab, ";");

            //grabar en b.d
            MovimientoOCCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoOCDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            ExistenciaRN.ModificarExistencia(iLisExiMod);
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static void GenerarTransferenciasAutomaticasAlModificarPorSincerado(ProduccionDetaEN pObj)
        {
            //obtener una lista de claves movimiento cabe
            List<string> iLisClaMovCab = Cadena.ListarPalabrasDeTexto(pObj.ClavesTransferenciaSincerado, ";");

            //recorrer cada claveMovimientoCabe
            foreach (string xStrCla in iLisClaMovCab)
            {
                //eliminar al movimiento cabe
                EliminarMovimientoCabe(xStrCla);

                //eliminar al movimiento deta
                MovimientoOCDetaRN.EliminarMovimientoDetaXMovimientoCabe(xStrCla);
            }

            //volver a generar la transferencia automatica
            GenerarTransferenciasAutomaticasAlAdicionarPorSincerado(pObj);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesXClaveProduccionProTerYClaseOperacion(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesXClaveProduccionProTerYClaseOperacion(pObj);
        }

        public static string ObtenerStrProduccionesDetaUsadasParaAdicionales(List<MovimientoOCDetaEN> pLisMovDet, ProduccionProTerEN pProProTer)
        {
            //valor resultado
            string iValor = string.Empty;

            //valida cuando no hay objeto en la lista
            if (pLisMovDet.Count == 0) { return iValor; }

            //obtener al unico objeto de la lista
            MovimientoOCDetaEN iMovDetEN = pLisMovDet[0];

            //valida cuando el objeto no es del almacen "A11"
            if (iMovDetEN.CodigoAlmacen != "A11") { return iValor; }

            //traer a todas las Producciones deta para este encajado
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaConSaldoLiberacion(iForDetEN.CodigoSemiProducto);

            //cantidad a salir
            decimal iCantidadASalir = iMovDetEN.CantidadMovimientoDeta;

            //recorrer cada objeto Liberacion
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //si la cantidad a salir es cero, entonces salir del foreach
                if (iCantidadASalir == 0) { break; }

                //armar el str
                iValor += xProDet.ClaveProduccionDeta;

                //si la cantidad a salir es menor,entonces termina la salida de los lotes
                if (iCantidadASalir < xProDet.SaldoLiberacion)
                {
                    iValor += ";" + iCantidadASalir + "|";

                    //ya no hay cantidad a salir
                    iCantidadASalir = 0;
                }
                else
                {
                    iValor += ";" + xProDet.SaldoLiberacion + "|";

                    //restamos
                    iCantidadASalir -= xProDet.SaldoLiberacion;
                }
            }

            //devolver                
            return iValor;
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(pObj);
        }

        public static MovimientoOCCabeEN ValidaCuandoFechaEsMenorAFechaEncajado(MovimientoOCCabeEN pObj, string pFechaEncajado)
        {
            //objeto resultado
            MovimientoOCCabeEN iMovCabEN = new MovimientoOCCabeEN();

            //validar           
            string iFechaMovimientoCabe = Fecha.ObtenerDiaMesAno(pObj.FechaMovimientoCabe);
            if (Fecha.EsMayorOIgualQue(iFechaMovimientoCabe, pFechaEncajado) == false)
            {
                iMovCabEN.Adicionales.EsVerdad = false;
                iMovCabEN.Adicionales.Mensaje = "La fecha " + pObj.FechaMovimientoCabe + " no debe ser menor a la fecha de encajado " +
                                                pFechaEncajado;
            }

            //ok
            return iMovCabEN;
        }

        public static void EnviadoMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.EnviadoMovimientoCabe(pObj);
        }
        public static void ExportadoMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.ExportadoMovimientoCabe(pObj);
        }

        public static void NoEnviadoMovimientoCabe(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.NoEnviadoMovimientoCabe(pObj);
        }

        public static void AsignarOrdenCompraEnviada(MovimientoOCCabeEN pObj, List<MovimientoOCCabeEN> pLista)
        {
            //lista actualizada
            List<MovimientoOCCabeEN> iLisSol = new List<MovimientoOCCabeEN>();

            //buscamos el objeto en la lista pLista
            foreach (MovimientoOCCabeEN xPem in pLista)
            {
                if (xPem.NumeroMovimientoCabe == pObj.NumeroMovimientoCabe)
                {
                    xPem.VerdadFalso = pObj.VerdadFalso;
                    xPem.CPermitir = Conversion.BooleanACadena(pObj.VerdadFalso, "");
                }
                iLisSol.Add(xPem);
            }
            //actualizamos a la lista principal
            pLista.Clear();
            pLista.AddRange(iLisSol);
        }

        public static void CerrarMovimientoOCCabe(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.CerrarMovimientoOCCabe(pObj);
        }

        public static List<MovimientoOCCabeEN> ListarMovimientoCabesAuxiliarXEstadoPago(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.ListarMovimientoCabesAuxiliarXEstadoPago(pObj);
        }

        public static List<MovimientoOCCabeEN> BuscarMovimientoCabeXAuxiliar(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            return iPerAD.BuscarMovimientoCabeXAuxiliar(pObj);
        }

        public static void CambiarEstadoPagoMovimientoOCCabe(MovimientoOCCabeEN pObj, string estado)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.CambiarEstadoPagoMovimientoOCCabe(pObj, estado);
        }

        public static void ActualizarCostoTotalMovimientoOCCabe(string periodo, string clavemovimientocabe, decimal montototal, decimal igvMovimientoCabe, decimal ValorVtaMovimientoCabe)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.ActualizarCostoTotalMovimientoOCCabe(periodo, clavemovimientocabe, montototal, igvMovimientoCabe, ValorVtaMovimientoCabe);
        }

        public static void ActualizarCostoTotalMovimientoOSCabe(string periodo, string clavemovimientocabe, decimal montototal)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.ActualizarCostoTotalMovimientoOSCabe(periodo, clavemovimientocabe, montototal);
        }

        public static void ActualizarMontoPendienteMovimientoOCCabe(string periodo, string clavemovimientocabe, decimal montopendiente)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.ActualizarMontoPendienteMovimientoOCCabe(periodo, clavemovimientocabe, montopendiente);
        }

        public static MovimientoOCCabeEN EsActoAprobarMovimientoOCCabe(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iSolPedidoCabEN = new MovimientoOCCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iSolPedidoCabEN = MovimientoOCCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida si existe
            iSolPedidoCabEN = MovimientoOCCabeRN.EsMovmientoOCCabeExistente(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            MovimientoOCCabeEN iMovCabVenEN = MovimientoOCCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iSolPedidoCabEN, pObj.COrigenVentanaCreacion);
            if (iMovCabVenEN.Adicionales.EsVerdad == false) { return iMovCabVenEN; }

            //ok          
            return iSolPedidoCabEN;
        }

        public static MovimientoOCCabeEN EsMovmientoOCCabeExistente(MovimientoOCCabeEN pObj)
        {
            //objeto resultado
            MovimientoOCCabeEN iExiEN = new MovimientoOCCabeEN();

            //validar si existe en b.d
            iExiEN = MovimientoOCCabeRN.BuscarMovimientoCabeXClave(pObj);
            if (iExiEN.ClaveMovimientoCabe == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El registro no existe";
                return iExiEN;
            }

            //ok        
            return iExiEN;
        }
        public static void AprobarMovimientoOCCabe(MovimientoOCCabeEN pObj)
        {
            MovimientoOCCabeAD iPerAD = new MovimientoOCCabeAD();
            iPerAD.AprobarMovimientoOCCabe(pObj);
        }
    }
}
