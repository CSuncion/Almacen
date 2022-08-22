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
    public class MovimientoCabeRN
    {

        public static MovimientoCabeEN EnBlanco()
        {
            MovimientoCabeEN iExiEN = new MovimientoCabeEN();
            return iExiEN;
        }

        public static void AdicionarMovimientoCabe(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.AgregarMovimientoCabe(pObj);
        }

        public static void AdicionarMovimientoCabe(List<MovimientoCabeEN> pLista)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.AgregarMovimientoCabe(pLista);
        }

        public static void ModificarMovimientoCabe(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.ModificarMovimientoCabe(pObj);
        }

        public static void ModificarMovimientoCabe(List<MovimientoCabeEN> pLista)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.ModificarMovimientoCabe(pLista);
        }

        public static void EliminarMovimientoCabe(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.EliminarMovimientoCabe(pObj);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabes(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabes(pObj);
        }

        public static MovimientoCabeEN BuscarMovimientoCabeXClave(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.BuscarMovimientoCabeXClave(pObj);
        }

        public static MovimientoCabeEN BuscarMovimientoCabeXClave(string pClaveMovimientoCabe)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pClaveMovimientoCabe;

            //ejecutar metodo
            return MovimientoCabeRN.BuscarMovimientoCabeXClave(iMovCabEN);
        }

        public static MovimientoCabeEN EsMovimientoCabeExistente(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iExiEN = new MovimientoCabeEN();

            //validar si existe en b.d
            iExiEN = MovimientoCabeRN.BuscarMovimientoCabeXClave(pObj);
            if (iExiEN.ClaveMovimientoCabe == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El registro no existe";
                return iExiEN;
            }

            //ok        
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(MovimientoCabeEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case MovimientoCabeEN.ClaObj: return pObj.ClaveObjeto;
                case MovimientoCabeEN.ClaMovCab: return pObj.ClaveMovimientoCabe;
                case MovimientoCabeEN.CodEmp: return pObj.CodigoEmpresa;
                case MovimientoCabeEN.NomEmp: return pObj.NombreEmpresa;
                case MovimientoCabeEN.PerMovCab: return pObj.PeriodoMovimientoCabe;
                case MovimientoCabeEN.CodAlm: return pObj.CodigoAlmacen;
                case MovimientoCabeEN.DesAlm: return pObj.DescripcionAlmacen;
                case MovimientoCabeEN.CodTipOpe: return pObj.CodigoTipoOperacion;
                case MovimientoCabeEN.DesTipOpe: return pObj.DescripcionTipoOperacion;
                case MovimientoCabeEN.CClaTipOpe: return pObj.CClaseTipoOperacion;
                case MovimientoCabeEN.NClaTipOpe: return pObj.NClaseTipoOperacion;
                case MovimientoCabeEN.CCalPrePro: return pObj.CCalculaPrecioPromedio;
                case MovimientoCabeEN.NumMovCab: return pObj.NumeroMovimientoCabe;              
                case MovimientoCabeEN.FecMovCab: return pObj.FechaMovimientoCabe;
                case MovimientoCabeEN.CodAux: return pObj.CodigoAuxiliar;
                case MovimientoCabeEN.DesAux: return pObj.DescripcionAuxiliar;
                case MovimientoCabeEN.CodPer: return pObj.CodigoPersonal;
                case MovimientoCabeEN.NomPer: return pObj.NombrePersonal;
                case MovimientoCabeEN.OrdCom: return pObj.OrdenCompra;
                case MovimientoCabeEN.GuiRem: return pObj.GuiaRemision;
                case MovimientoCabeEN.CTipDoc: return pObj.CTipoDocumento;
                case MovimientoCabeEN.NTipDoc: return pObj.NTipoDocumento;
                case MovimientoCabeEN.SerDoc: return pObj.SerieDocumento;
                case MovimientoCabeEN.NumDoc: return pObj.NumeroDocumento;
                case MovimientoCabeEN.FecDoc: return pObj.FechaDocumento;
                case MovimientoCabeEN.IgvPor: return pObj.IgvPorcentaje.ToString();
                case MovimientoCabeEN.ValVtaMovCab: return pObj.ValorVtaMovimientoCabe.ToString();
                case MovimientoCabeEN.IgvMovCab: return pObj.IgvMovimientoCabe.ToString();
                case MovimientoCabeEN.ExoMovCab: return pObj.ExoneradoMovimientoCabe.ToString();
                case MovimientoCabeEN.PreVtaMovCab: return pObj.PrecioVtaMovimientoCabe.ToString();
                case MovimientoCabeEN.MonTotMovCab: return pObj.MontoTotalMovimientoCabe.ToString();
                case MovimientoCabeEN.GloMovCab: return pObj.GlosaMovimientoCabe;
                case MovimientoCabeEN.ClaIngMovCab: return pObj.ClaveIngresoMovimientoCabe;
                case MovimientoCabeEN.COriVenCre: return pObj.COrigenVentanaCreacion;
                case MovimientoCabeEN.NOriVenCre: return pObj.NOrigenVentanaCreacion;
                case MovimientoCabeEN.CEstMovCab: return pObj.CEstadoMovimientoCabe;
                case MovimientoCabeEN.NEstMovCab: return pObj.NEstadoMovimientoCabe;
                case MovimientoCabeEN.UsuAgr: return pObj.UsuarioAgrega;
                case MovimientoCabeEN.FecAgr: return pObj.FechaAgrega.ToString();
                case MovimientoCabeEN.UsuMod: return pObj.UsuarioModifica;
                case MovimientoCabeEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<MovimientoCabeEN> FiltrarMovimientoCabesXTextoEnCualquierPosicion(List<MovimientoCabeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<MovimientoCabeEN> iLisRes = new List<MovimientoCabeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (MovimientoCabeEN xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<MovimientoCabeEN>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<MovimientoCabeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<MovimientoCabeEN> pListaMovimientoCabes)
        {
            //lista resultado
            List<MovimientoCabeEN> iLisRes = new List<MovimientoCabeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaMovimientoCabes; }

            //filtar la lista
            iLisRes = MovimientoCabeRN.FiltrarMovimientoCabesXTextoEnCualquierPosicion(pListaMovimientoCabes, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveMovimientoCabe(MovimientoCabeEN pPer)
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

        public static List<MovimientoCabeEN> ListarMovimientoCabesXPeriodoYClaseOperacion(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesXPeriodoYClaseOperacion(pObj);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesXPeriodoYClaseOperacionOrdenCompra(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesXPeriodoYClaseOperacionOrdenCompra(pObj);
        }

        public static string ObtenerMaximoValorEnColumna(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iCliAD = new MovimientoCabeAD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(MovimientoCabeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = MovimientoCabeRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static MovimientoCabeEN EsActoAdicionarMovimientoCabe(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }
          
            //ok          
            return iMovCabEN;
        }

        public static MovimientoCabeEN ValidaCuandoNoEsActoRegistrarEnPeriodo(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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

        public static MovimientoCabeEN ValidaCuandoFechaNoEsDelPeriodoElegido(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //validar
            bool iEsVerdad = Periodo.EsFechaDePeriodo(pObj.FechaMovimientoCabe, pObj.PeriodoMovimientoCabe);
            if(iEsVerdad==false)
            {
                iMovCabEN.Adicionales.EsVerdad = false;
                iMovCabEN.Adicionales.Mensaje = "La fecha " + pObj.FechaMovimientoCabe + " debe ser del periodo " +
                                                Periodo.FormatoAñoYNombreMes(pObj.PeriodoMovimientoCabe);
                return iMovCabEN;
            }

            //ok
            return iMovCabEN;
        }

        public static MovimientoCabeEN EsActoModificarMovimientoCabe(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida si existe
            iMovCabEN = MovimientoCabeRN.EsMovimientoCabeExistente(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            MovimientoCabeEN iMovCabVenEN = MovimientoCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iMovCabEN, pObj.COrigenVentanaCreacion);
            if (iMovCabVenEN.Adicionales.EsVerdad == false) { return iMovCabVenEN; }

            //ok          
            return iMovCabEN;
        }

        public static MovimientoCabeEN ValidaCuandoRegistroNofueCreadoPorVentanaProceso(MovimientoCabeEN pObj, string pCodigoVentanaProceso)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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

        public static MovimientoCabeEN EsActoEliminarMovimientoCabe(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida si existe
            iMovCabEN = MovimientoCabeRN.EsMovimientoCabeExistente(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            MovimientoCabeEN iMovCabVenEN = MovimientoCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iMovCabEN, pObj.COrigenVentanaCreacion);
            if (iMovCabVenEN.Adicionales.EsVerdad == false) { return iMovCabVenEN; }

            //ok          
            return iMovCabEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerFechaMovimientoCabeSugerido(string pPeriodoRegistro, string pFechaMovimientoCabeDtp)
        {
            //si la fecha movimiento dtp pertenece al periodo registro, entonces se devuleve esta misma fecha
            if (Periodo.EsFechaDePeriodo(pFechaMovimientoCabeDtp, pPeriodoRegistro) == true) { return pFechaMovimientoCabeDtp; }

            //aqui la fecha es de otro periodo, entonces formamos una fecha con el periodo parametro
            return Periodo.ObtenerFecha("01", pPeriodoRegistro);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesParaGrillaTransferencia(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesParaGrillaTransferencia(pObj);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesParaGrillaIngresos(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesParaGrillaIngresos(pObj);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesParaGrillaSalidas(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesParaGrillaSalidas(pObj);
        }

        public static void EliminarMovimientoCabeYDeta(MovimientoCabeEN pObj)
        {
            //eliminar primero la cabecera
            MovimientoCabeRN.EliminarMovimientoCabe(pObj);

            //eliminar el detalle
            MovimientoDetaEN iMovDetEN = new MovimientoDetaEN();
            iMovDetEN.ClaveMovimientoCabe = pObj.ClaveMovimientoCabe;
            MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iMovDetEN);
        }

        public static void EliminarMovimientoCabe(string pClaveMovimientoCabe)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.ClaveMovimientoCabe = pClaveMovimientoCabe;

            //ejecutar metodo
            MovimientoCabeRN.EliminarMovimientoCabe(iMovCabEN);
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
            List<MovimientoCabeEN> iLisMovCabAdi = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
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
                MovimientoCabeEN iMovCabNueEN = new MovimientoCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoMovimientoCabe = pCodigoPeriodo;
                iMovCabNueEN.CodigoAlmacen = iRegConDetEN.Almacen;
                iMovCabNueEN.CodigoTipoOperacion = MovimientoCabeRN.ObtenerCodigoTipoOperacion(iRegConDetEN, iParEN);
                iMovCabNueEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi);
                iMovCabNueEN.FechaMovimientoCabe = iRegConDetEN.FechaVoucherRegContabCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iRegConDetEN.CodigoAuxiliar;
                iMovCabNueEN.CTipoDocumento = iRegConDetEN.TipoDocumento;
                iMovCabNueEN.SerieDocumento = iRegConDetEN.SerieDocumento;
                iMovCabNueEN.NumeroDocumento = iRegConDetEN.NumeroDocumento;
                iMovCabNueEN.FechaDocumento = iRegConDetEN.FechaDocumento;
                iMovCabNueEN.GlosaMovimientoCabe = iRegConDetEN.DescripcionRegContabCabe;
                iMovCabNueEN.COrigenVentanaCreacion = "5";//Importado Contabilidad
                iMovCabNueEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabNueEN);

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
                    MovimientoDetaEN iMovDetNueEN = new MovimientoDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroMovimientoCabe = iMovCabNueEN.NumeroMovimientoCabe;
                    iMovDetNueEN.ClaveMovimientoCabe = iMovCabNueEN.ClaveMovimientoCabe;
                    iMovDetNueEN.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                    iMovDetNueEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetNueEN);
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
                    iMovDetNueEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetNueEN);
                    iMovDetNueEN.GlosaMovimientoDeta = xRegConDet.GlosaRegContabDeta;

                    //adicionamos a la lista de MovimientoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }                               
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicionYModificacion(iLisAuxAdi, iLisAuxMod, iLisAuxAlm, iLisAuxCont);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            MovimientoCabeRN.EliminarAntesDeImportar(pCodigoPeriodo);

            //grabaciones masivas
            MovimientoCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
            AuxiliarRN.ModificarAuxiliar(iLisAuxMod);

        }

        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(MovimientoCabeEN pObj, List<MovimientoCabeEN> pLista)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la lista
            string iUltimoCodigo = MovimientoCabeRN.ObtenerMaximoValorEnColumna(pObj, pLista);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }
        
        public static string ObtenerMaximoValorEnColumna(MovimientoCabeEN pObj, List<MovimientoCabeEN> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //recorrer cada objeto
            foreach (MovimientoCabeEN xMovCab in pLista)
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

        public static string ObtenerCodigoTipoOperacion(RegContabDeta_Cont_EN pObj,ParametroEN pPar)
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

        public static List<MovimientoCabeEN> ListarMovimientoCabesXPeriodo(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesXPeriodo(pObj);
        }

        public static MovimientoCabeEN ArmarMovimientoCabeAjuste(InventarioCabeEN pInvCab, TipoOperacionEN pTipOpe,string pFechaGenera)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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
            iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //devolver
            return iMovCabEN;
        }

        public static void EliminarAntesDeImportar(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar movimiento deta
            MovimientoDetaRN.EliminarMovimientosDetaDeImportacion(pCodigoPeriodo);

            //eliminar movimiento cabe
            MovimientoCabeRN.EliminarMovimientosCabeDeImportacion(pCodigoPeriodo);
        }

        public static void EliminarAntesDeImportarIngreso(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar movimiento deta
            MovimientoDetaRN.EliminarMovimientosDetaDeImportacionIngreso(pCodigoPeriodo);

            //eliminar movimiento cabe
            MovimientoCabeRN.EliminarMovimientosCabeDeImportacionIngreso(pCodigoPeriodo);
        }

        public static void EliminarAntesDeImportarSalida(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar movimiento deta
            MovimientoDetaRN.EliminarMovimientosDetaDeImportacionSalida(pCodigoPeriodo);

            //eliminar movimiento cabe
            MovimientoCabeRN.EliminarMovimientosCabeDeImportacionSalida(pCodigoPeriodo);
        }

        public static void EliminarMovimientoCabeXPeriodoYOrigen(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.EliminarMovimientoCabeXPeriodoYOrigen(pObj);
        }

        public static void EliminarMovimientoCabeXPeriodoXOrigenYClase(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.EliminarMovimientoCabeXPeriodoXOrigenYClase(pObj);
        }

        public static void EliminarMovimientosCabeDeImportacion(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            MovimientoCabeRN.EliminarMovimientoCabeXPeriodoYOrigen(iMovCabEN);
        }

        public static void EliminarMovimientosCabeDeImportacionIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "1";//ingreso
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            MovimientoCabeRN.EliminarMovimientoCabeXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static void EliminarMovimientosCabeDeImportacionSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "2";//salida
            iMovCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            MovimientoCabeRN.EliminarMovimientoCabeXPeriodoXOrigenYClase(iMovCabEN);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesXClaveProduccionDetaYClaseOperacion(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
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
            List<MovimientoCabeEN> iLisMovCabAdi = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero movimiento para el ingreso
            string iNumeroMovimientoCabeIngreso = string.Empty;

            //recorrer cada lista
            foreach (List<InsumoFaltante> xLisInsFal in iLisLisInsTraAlm)
            {
                //obtener al primer objeto de la lista
                InsumoFaltante iInsFal = xLisInsFal[0];

                //creamos el objeto MovimientoCabe de salida transferencia
                MovimientoCabeEN iMovCabSalEN = new MovimientoCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabSalEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");         
                iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iInsFal.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iInsFal.CodigoPersonal;
                iMovCabSalEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabSalEN);                
                iMovCabSalEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabSalEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoDetaEN> iLisMovDetSal = new List<MovimientoDetaEN>();

                //variable para los correlativos de cada movimientoDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (InsumoFaltante xInsFal in xLisInsFal)
                {
                    //buscar a la existencia para este xInsFal
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExi, ExistenciaEN.CodAlm, xInsFal.CodigoAlmacen,
                        ExistenciaEN.CodExi, xInsFal.CodigoExistencia);
                        
                    //creamos un objeto MovimientoDeta
                    MovimientoDetaEN iMovDetSalEN = new MovimientoDetaEN();

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
                    iMovDetSalEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetSalEN);
                    iMovDetSalEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetSalEN);
                    iMovDetSalEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetSalEN);
                    iMovDetSalEN.GlosaMovimientoDeta = iMovCabSalEN.GlosaMovimientoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveMovimientoCabe = iMovCabSalEN.ClaveMovimientoCabe;                    
                    iMovDetSalEN.CorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoMovimientoDeta);
                    iMovDetSalEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetSalEN);

                    //adicionar a la lista de movimientoDeta de este MovimientoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //grabar lotesdeta
                LoteDetaRN.AdicionarLoteDeta(iLisMovDetSal);

                //creamos el objeto MovimientoCabe de ingreso transferencia
                MovimientoCabeEN iMovCabIngEN = new MovimientoCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabIngEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iInsFal.CodigoAlmacenProduccion;
                iMovCabIngEN.CodigoPersonal = iInsFal.CodigoPersonalProduccion;
                iMovCabIngEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(ref
                    iNumeroMovimientoCabeIngreso, iMovCabIngEN);
                iMovCabIngEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabIngEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoDetaEN> iLisMovDetIng = new List<MovimientoDetaEN>();

                //recorrer cada objeto MovimientoDetaSalida
                foreach (MovimientoDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto movimientoDeta
                    MovimientoDetaEN iMovDetIngEN = new MovimientoDetaEN();

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
                    iMovDetIngEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExi);

                    //actualizar los datos anteriores de la existencia en el MovimientoDeta
                    iMovDetIngEN.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    iMovDetIngEN.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;

                    //actualizar calculos
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetIngEN);
                    iMovDetIngEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetIngEN);
                    iMovDetIngEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetIngEN);
                    iMovDetIngEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetIngEN);

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
                List<ExistenciaEN> iLisExiSalMod = MovimientoDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetSal);
                List<ExistenciaEN> iLisExiIngMod = MovimientoDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetIng);

                //adicionamos a la lista de existencias a modificar
                iLisExiMod.AddRange(iLisExiSalMod);
                iLisExiMod.AddRange(iLisExiIngMod);
            }

            //grabar en b.d
            MovimientoCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            ExistenciaRN.ModificarExistencia(iLisExiMod);
        }

        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(ref string pNumeroMovimientoCabe, MovimientoCabeEN pObj)
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

        public static string ObtenerNuevoNumeroMovimientoCabeAutogenerado(MovimientoCabeEN pObj, List<MovimientoCabeEN> pLista,
            List<MovimientoCabeEN> pListaNumerosExcepcion)
        {
            //obtener el nuevo codigo para la lista
            string iNumero = ObtenerNuevoNumeroMovimientoCabeAutogenerado(pObj, pLista);
            
            //recorrer cada objeto
            foreach (MovimientoCabeEN xMovCab in pListaNumerosExcepcion)
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

        public static void ImportarIngresosDeExcel(List<MovimientoDetaEN> pListaMovimientoDetaExcel)
        {
            //obtener una lista de listas de movimientos deta,donde cada uno sera un movimiento Ingreso
            List<List<MovimientoDetaEN>> iLisLisMovDet = MovimientoDetaRN.ListarListasMovimientosDetaParaImportar(pListaMovimientoDetaExcel);

            //obtener una lista de movimientos deta pero de los auxiliares distintos que hay en la lista pListaMovimientoDetaExcel
            List<MovimientoDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<MovimientoDetaEN>(pListaMovimientoDetaExcel,
                MovimientoDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //traer lista de movimientos cabe que no se pueden eliminar al importar
            List<MovimientoCabeEN> iLisMovCabNoImp = ListarMovimientoCabesNoImportadosIngreso(ListaG.ObtenerPrimerValor<MovimientoDetaEN>(
                pListaMovimientoDetaExcel, MovimientoDetaEN.PerMovCab));

            //listas para adicionar los nuevos objetos
            List<MovimientoCabeEN> iLisMovCabAdi = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();
           
            //recorrer cada lista
            foreach (List<MovimientoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                MovimientoDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este movimiento
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo movimientoCabe
                MovimientoCabeEN iMovCabNueEN = new MovimientoCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoMovimientoCabe = iMovDetEN.PeriodoMovimientoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi, iLisMovCabNoImp);
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
                iMovCabNueEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabNueEN);

                //adicionamos a la lista de MovimientoCabe para adicionar
                iLisMovCabAdi.Add(iMovCabNueEN);

                //buscar al tipo de operacion para este movimiento
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe, 
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los MovimientosDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (MovimientoDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoMovimientoDeta);

                    //buscar a la existencia de este movimiento
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        MovimientoDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto MovimientoDeta
                    MovimientoDetaEN iMovDetNueEN = new MovimientoDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroMovimientoCabe = iMovCabNueEN.NumeroMovimientoCabe;
                    iMovDetNueEN.ClaveMovimientoCabe = iMovCabNueEN.ClaveMovimientoCabe;
                    iMovDetNueEN.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                    iMovDetNueEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetNueEN);
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
                    iMovDetNueEN.PrecioUnitarioConversion = MovimientoDetaRN.ObtenerPrecioUnitarioConvertido(iMovDetNueEN, xMovDet.PrecioUnitarioMovimientoDeta);
                    iMovDetNueEN.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitario(iMovDetNueEN,
                        xMovDet.PrecioUnitarioMovimientoDeta);
                    iMovDetNueEN.CantidadConversion = MovimientoDetaRN.ObtenerCantidadConvertido(iMovDetNueEN,
                        xMovDet.CantidadMovimientoDeta);
                    iMovDetNueEN.CantidadMovimientoDeta = MovimientoDetaRN.ObtenerCantidad(iMovDetNueEN,
                        xMovDet.CantidadMovimientoDeta);
                    iMovDetNueEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetNueEN);
                    iMovDetNueEN.GlosaMovimientoDeta = xMovDet.GlosaMovimientoDeta;

                    //adicionamos a la lista de MovimientoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicion(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            string iCodigoPeriodo = ListaG.ObtenerPrimerValor<MovimientoDetaEN>(pListaMovimientoDetaExcel, MovimientoDetaEN.PerMovCab);
            MovimientoCabeRN.EliminarAntesDeImportarIngreso(iCodigoPeriodo);

            //grabaciones masivas
            MovimientoCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static void ImportarIngresosDeExcel1(List<MovimientoDetaEN> pListaMovimientoDetaExcel)
        {
            //obtener una lista de listas de movimientos deta,donde cada uno sera un movimiento Ingreso
            List<List<MovimientoDetaEN>> iLisLisMovDet = MovimientoDetaRN.ListarListasMovimientosDetaParaImportar(pListaMovimientoDetaExcel);

            //obtener una lista de movimientos deta pero de los auxiliares distintos que hay en la lista pListaMovimientoDetaExcel
            List<MovimientoDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<MovimientoDetaEN>(pListaMovimientoDetaExcel,
                MovimientoDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //listas para adicionar los nuevos objetos
            //List<MovimientoCabeEN> iLisMovCabAdi = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<MovimientoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                MovimientoDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este movimiento
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo movimientoCabe
                MovimientoCabeEN iMovCabNueEN = new MovimientoCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoMovimientoCabe = iMovDetEN.PeriodoMovimientoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabNueEN);
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
                iMovCabNueEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabNueEN);

                //adicionamos a la lista de MovimientoCabe para adicionar
                //iLisMovCabAdi.Add(iMovCabNueEN);

                //adicionar en b.d
                MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabNueEN);

                //buscar al tipo de operacion para este movimiento
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe,
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los MovimientosDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (MovimientoDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoMovimientoDeta);

                    //buscar a la existencia de este movimiento
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        MovimientoDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto MovimientoDeta
                    MovimientoDetaEN iMovDetNueEN = new MovimientoDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroMovimientoCabe = iMovCabNueEN.NumeroMovimientoCabe;
                    iMovDetNueEN.ClaveMovimientoCabe = iMovCabNueEN.ClaveMovimientoCabe;
                    iMovDetNueEN.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                    iMovDetNueEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetNueEN);
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
                    iMovDetNueEN.PrecioUnitarioConversion = MovimientoDetaRN.ObtenerPrecioUnitarioConvertido(iMovDetNueEN,
                        xMovDet.PrecioUnitarioMovimientoDeta);
                    iMovDetNueEN.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitario(iMovDetNueEN,
                        xMovDet.PrecioUnitarioMovimientoDeta);
                    iMovDetNueEN.CantidadConversion = MovimientoDetaRN.ObtenerCantidadConvertido(iMovDetNueEN,
                        xMovDet.CantidadMovimientoDeta);
                    iMovDetNueEN.CantidadMovimientoDeta = MovimientoDetaRN.ObtenerCantidad(iMovDetNueEN,
                        xMovDet.CantidadMovimientoDeta);
                    iMovDetNueEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetNueEN);
                    iMovDetNueEN.GlosaMovimientoDeta = xMovDet.GlosaMovimientoDeta;

                    //adicionamos a la lista de MovimientoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicion(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);
            
            //grabaciones masivas
            //MovimientoCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static MovimientoCabeEN EsActoEliminarImportacionMovimientoCabe(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando no hay auxiliares importados
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoHayMovimientoCabesImportados(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }
            
            //ok            
            return iMovCabEN;
        }

        public static MovimientoCabeEN EsActoEliminarImportacionMovimientoCabeIngreso(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando no hay auxiliares importados
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoHayMovimientoCabesImportadosIngresos(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //ok            
            return iMovCabEN;
        }

        public static MovimientoCabeEN EsActoEliminarImportacionMovimientoCabeSalida(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //valida cuando no hay auxiliares importados
            iMovCabEN = MovimientoCabeRN.ValidaCuandoNoHayMovimientoCabesImportadosSalidas(pObj);
            if (iMovCabEN.Adicionales.EsVerdad == false) { return iMovCabEN; }

            //ok            
            return iMovCabEN;
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesImportados(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesImportados(pObj);
        }
        
        public static MovimientoCabeEN ValidaCuandoNoHayMovimientoCabesImportados(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iAuxEN = new MovimientoCabeEN();
            
            //validar
            pObj.Adicionales.CampoOrden = MovimientoCabeEN.ClaMovCab;
            List<MovimientoCabeEN> iLisAuxImp = MovimientoCabeRN.ListarMovimientoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay Movimientos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static MovimientoCabeEN ValidaCuandoNoHayMovimientoCabesImportadosIngresos(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iAuxEN = new MovimientoCabeEN();

            //validar
            pObj.CClaseTipoOperacion = "1";//ingreso
            pObj.Adicionales.CampoOrden = MovimientoCabeEN.ClaMovCab;
            List<MovimientoCabeEN> iLisAuxImp = MovimientoCabeRN.ListarMovimientoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay Movimientos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static MovimientoCabeEN ValidaCuandoNoHayMovimientoCabesImportadosSalidas(MovimientoCabeEN pObj)
        {
            //objeto resultado
            MovimientoCabeEN iAuxEN = new MovimientoCabeEN();

            //validar
            pObj.CClaseTipoOperacion = "2";//salida
            pObj.Adicionales.CampoOrden = MovimientoCabeEN.ClaMovCab;
            List<MovimientoCabeEN> iLisAuxImp = MovimientoCabeRN.ListarMovimientoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay Movimientos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static void GenerarMovimientoSalidaMasaYEnvasadoPorMigracion(ProduccionDetaEN pObj,TipoOperacionEN pTipOpe)
        {
            //objeto cabe
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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
            iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iProExiEN.CTipoDescarga = "'0','1'";//fase masa y control calidad
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(iProExiEN);

            //grabar movimientos deta
            MovimientoDetaRN.AdicionarMovimientoDetaPorSalidaInsumos(iLisProExi, iMovCabEN);

            //listar al movimientodeta
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iMovCabEN.ClaveMovimientoCabe);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

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
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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
            iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta                      
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientoDetaParaIngresoSemiElaborado(iProDetEN, iMovCabEN);

            //grabar movimientos deta
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //modificar produccionDeta           
            iProDetEN.ClaveIngresoSemiElaborado = iMovCabEN.ClaveMovimientoCabe;
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void GenerarMovimientoSalidaUnidadesAEmpaquetarPorMigracion(EncajadoEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar al encajado en bd
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //objeto cabe
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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
            iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta           
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientoDetaParaSalidaEmpaquetar(iEncEN, iMovCabEN);

            //grabar movimientos deta
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //actualizar el costo insumo de semi productos
            ProduccionProTerRN.ModificarCostoInsumoSemiProducto(iEncEN, iLisMovDet);

            //descontar producciones deta
            ProduccionDetaRN.DescontarUnidadesPorEmpaquetado(iLisMovDet);

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
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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
            iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta           
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientoDetaParaSalidaNoPasan(iProDetEN, iMovCabEN);

            //grabar movimientos deta
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //modificar produccionDeta           
            iProDetEN.ClaveSalidaNoPasan = iMovCabEN.ClaveMovimientoCabe;
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void GenerarMovimientoSalidaEmpaquetadoPorMigracion(EncajadoEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar al encajado en bd
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //objeto cabe
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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
            iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveEncajado = iEncEN.ClaveEncajado;            
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisAcumuladoXClaveEncajado(iProExiEN);

            //grabar movimientos deta
            MovimientoDetaRN.AdicionarMovimientoDetaPorSalidaInsumos(iLisProExi, iMovCabEN);

            //listar al movimientodeta
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iMovCabEN.ClaveMovimientoCabe);

            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

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
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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
            iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta           
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientoDetaParaIngresoMercaderia(iEncEN, iMovCabEN);

            //grabar movimientos deta
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDet);
            
            //actualizar existencias por adicion de movimiento
            ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);
            
            //modificar encajado    
            iEncEN.ClaveIngresoProductoTerminado = iMovCabEN.ClaveMovimientoCabe;
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void ImportarSalidasDeExcel(List<MovimientoDetaEN> pListaMovimientoDetaExcel)
        {
            //obtener una lista de listas de movimientos deta,donde cada uno sera un movimiento Salida
            List<List<MovimientoDetaEN>> iLisLisMovDet = MovimientoDetaRN.ListarListasMovimientosDetaParaImportar(pListaMovimientoDetaExcel);            

            //obtener una lista de movimientos deta pero de los auxiliares distintos que hay en la lista pListaMovimientoDetaExcel
            List<MovimientoDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<MovimientoDetaEN>(pListaMovimientoDetaExcel,
                MovimientoDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();            

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();            

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();            

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //traer lista de movimientos cabe que no se pueden eliminar al importar
            List<MovimientoCabeEN> iLisMovCabNoImp = ListarMovimientoCabesNoImportadosSalida(ListaG.ObtenerPrimerValor<MovimientoDetaEN>(
                pListaMovimientoDetaExcel, MovimientoDetaEN.PerMovCab));

            //listas para adicionar los nuevos objetos
            List<MovimientoCabeEN> iLisMovCabAdi = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();          

            //recorrer cada lista
            foreach (List<MovimientoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                MovimientoDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este movimiento
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo movimientoCabe
                MovimientoCabeEN iMovCabNueEN = new MovimientoCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoMovimientoCabe = iMovDetEN.PeriodoMovimientoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi, iLisMovCabNoImp);
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
                iMovCabNueEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabNueEN);

                //adicionamos a la lista de MovimientoCabe para adicionar
                iLisMovCabAdi.Add(iMovCabNueEN);

                //buscar al tipo de operacion para este movimiento
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe,
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los MovimientosDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (MovimientoDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoMovimientoDeta);

                    //buscar a la existencia de este movimiento
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        MovimientoDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto MovimientoDeta
                    MovimientoDetaEN iMovDetNueEN = new MovimientoDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroMovimientoCabe = iMovCabNueEN.NumeroMovimientoCabe;
                    iMovDetNueEN.ClaveMovimientoCabe = iMovCabNueEN.ClaveMovimientoCabe;
                    iMovDetNueEN.CorrelativoMovimientoDeta = iCorrelativoMovimientoDeta;
                    iMovDetNueEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetNueEN);
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
                    iMovDetNueEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetNueEN);
                    iMovDetNueEN.GlosaMovimientoDeta = xMovDet.GlosaMovimientoDeta;

                    //adicionamos a la lista de MovimientoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicion(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            string iCodigoPeriodo = ListaG.ObtenerPrimerValor<MovimientoDetaEN>(pListaMovimientoDetaExcel, MovimientoDetaEN.PerMovCab);
            MovimientoCabeRN.EliminarAntesDeImportarSalida(iCodigoPeriodo);

            //grabaciones masivas
            MovimientoCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static void RegenerarMovimientosTransferenciaYFaseMasa()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //eliminar los movimientos de transferencia de ingreso y salida al almacen de produccion
            MovimientoCabeRN.EliminarAntesDeRegenerar(iPeriodo);

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
                List<List<MovimientoDetaEN>> iLisLisMovDetDia = MovimientoDetaRN.ListaListasMovimientosDetaPorFechaMenorOIgualQue(iPeriodo,
                    xLisProDet[0].FechaProduccionDeta);

                //recalcular(actualiza a la lista existencia con su nuevo saldo y precio promedio)
                MovimientoDetaRN.Recalcular(iAño, iCodigoMes, iLisExiEmp, iLisSalAño, iLisLisMovDetDia);

                //listar los insumos para transferir
                List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosParaTransferirAProducccion(xLisProDet, iLisExiEmp);

                //generar las transferencias
                MovimientoCabeRN.GenerarTransferenciasAutomaticasAProduccion(iLisInsFal, iLisExiEmp);

                //modificar por transferencias automatocas
                ProduccionDetaRN.ModificarPorTransferenciaAutomatica(xLisProDet);

                //generar los movimientos de salida fase masa y envasado               
                //recorrer cada objeto produccionDeta
                foreach (ProduccionDetaEN xProDet in xLisProDet)
                {
                    //generar la salida de masa y envasado
                    MovimientoCabeRN.GenerarMovimientoSalidaMasaYEnvasadoPorRegeneracion(xProDet, iTipOpeSalEN, iLisExiEmp);
                }


            }

        }

        public static void EliminarAntesDeRegenerar(string pCodigoPeriodo)
        {
            MovimientoDetaRN.EliminarMovimientosDetaAlmacenProduccionParaRegenerar(pCodigoPeriodo);
            MovimientoCabeRN.EliminarMovimientosCabeAlmacenProduccionParaRegenerar(pCodigoPeriodo);
            MovimientoDetaRN.EliminarMovimientosDetaAlmacenesCompraParaRegenerar(pCodigoPeriodo);
            MovimientoCabeRN.EliminarMovimientosCabeAlmacenesCompraParaRegenerar(pCodigoPeriodo);
            ProduccionDetaRN.ModificarProduccionDetaParaRegenerar(pCodigoPeriodo);
        }

        public static void EliminarMovimientoCabeXPeriodoYAlmacen(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.EliminarMovimientoCabeXPeriodoYAlmacen(pObj);
        }

        public static void EliminarMovimientosCabeAlmacenProduccionParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CodigoAlmacen = "A10";//almacen de produccion

            //ejecutar metodo
            MovimientoCabeRN.EliminarMovimientoCabeXPeriodoYAlmacen(iMovCabEN);
        }

        public static void EliminarMovimientoCabeAlmacenesCompraParaRegenerar(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.EliminarMovimientoCabeAlmacenesCompraParaRegenerar(pObj);
        }

        public static void EliminarMovimientosCabeAlmacenesCompraParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovDetEN = new MovimientoCabeEN();
            iMovDetEN.PeriodoMovimientoCabe = pCodigoPeriodo;

            //ejecutar metodo
            MovimientoCabeRN.EliminarMovimientoCabeAlmacenesCompraParaRegenerar(iMovDetEN);
        }

        public static void GenerarTransferenciasAutomaticasAProduccion(List<InsumoFaltante> pLisInsTra,List<ExistenciaEN> pLisExi)
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
            List<MovimientoCabeEN> iLisMovCabAdi = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero movimiento para el ingreso
            string iNumeroMovimientoCabeIngreso = string.Empty;

            //recorrer cada lista
            foreach (List<InsumoFaltante> xLisInsFal in iLisLisInsTraAlm)
            {
                //obtener al primer objeto de la lista
                InsumoFaltante iInsFal = xLisInsFal[0];

                //creamos el objeto MovimientoCabe de salida transferencia
                MovimientoCabeEN iMovCabSalEN = new MovimientoCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabSalEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iInsFal.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iInsFal.CodigoPersonal;
                iMovCabSalEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabSalEN);
                iMovCabSalEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabSalEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoDetaEN> iLisMovDetSal = new List<MovimientoDetaEN>();

                //variable para los correlativos de cada movimientoDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (InsumoFaltante xInsFal in xLisInsFal)
                {
                    //buscar a la existencia para este xInsFal
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(pLisExi, ExistenciaEN.CodAlm, xInsFal.CodigoAlmacen,
                        ExistenciaEN.CodExi, xInsFal.CodigoExistencia);

                    //creamos un objeto MovimientoDeta
                    MovimientoDetaEN iMovDetSalEN = new MovimientoDetaEN();

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
                    iMovDetSalEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetSalEN);
                    iMovDetSalEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetSalEN);
                    iMovDetSalEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetSalEN);
                    iMovDetSalEN.GlosaMovimientoDeta = iMovCabSalEN.GlosaMovimientoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveMovimientoCabe = iMovCabSalEN.ClaveMovimientoCabe;
                    iMovDetSalEN.CorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoMovimientoDeta);
                    iMovDetSalEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetSalEN);

                    //adicionar a la lista de movimientoDeta de este MovimientoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //creamos el objeto MovimientoCabe de ingreso transferencia
                MovimientoCabeEN iMovCabIngEN = new MovimientoCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabIngEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iInsFal.CodigoAlmacenProduccion;
                iMovCabIngEN.CodigoPersonal = iInsFal.CodigoPersonalProduccion;
                iMovCabIngEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(ref
                    iNumeroMovimientoCabeIngreso, iMovCabIngEN);
                iMovCabIngEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabIngEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoDetaEN> iLisMovDetIng = new List<MovimientoDetaEN>();

                //recorrer cada objeto MovimientoDetaSalida
                foreach (MovimientoDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto movimientoDeta
                    MovimientoDetaEN iMovDetIngEN = new MovimientoDetaEN();

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
                    iMovDetIngEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                    //actualizar los datos anteriores de la existencia en el MovimientoDeta
                    iMovDetIngEN.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    iMovDetIngEN.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;

                    //actualizar calculos
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetIngEN);
                    iMovDetIngEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetIngEN);
                    iMovDetIngEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetIngEN);
                    iMovDetIngEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetIngEN);

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
                MovimientoDetaRN.ExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetSal,pLisExi);
                MovimientoDetaRN.ExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetIng, pLisExi);                
            }

            //grabar en b.d
            MovimientoCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);          
        }

        public static void GenerarMovimientoSalidaMasaYEnvasadoPorRegeneracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe, List<ExistenciaEN> pLisExi)
        {
            //objeto cabe
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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
            iMovCabEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabEN);
            iMovCabEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabEN);

            //grabar movimiento cabe
            MovimientoCabeRN.AdicionarMovimientoCabe(iMovCabEN);

            //lista movimientos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iProExiEN.CTipoDescarga = "'0','1'";//fase masa y control calidad
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(iProExiEN);

            //grabar movimientos deta
            MovimientoDetaRN.AdicionarMovimientoDetaPorSalidaInsumos(iLisProExi, iMovCabEN, pLisExi);

            //listar al movimientodeta
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaPorClaveMovimientoCabe(iMovCabEN.ClaveMovimientoCabe);

            //actualizar existencias por adicion de movimiento
            MovimientoDetaRN.ExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDet, pLisExi);
            
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
            List<MovimientoCabeEN> iLisMovCab = MovimientoCabeRN.ListarMovimientoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoCabeEN> iLisMovCabMod = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
            List<MovimientoDetaEN> iLisMovDetMod = new List<MovimientoDetaEN>();

            //recorrer cada produccion deta
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //operacion para agregar el detalle que le falta a los movimientos ingreso al almacen de semi productos
                if (xProDet.ClaveIngresoSemiElaborado != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoCabeEN iMovCabEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, xProDet.ClaveIngresoSemiElaborado);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = xProDet.FechaProduccionDeta;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //segun si existe en movimientodeta en bd
                    MovimientoDetaEN iMovDetBus = ListaG.Buscar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab, iMovCabEN.ClaveMovimientoCabe);
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
                        MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoSemiElaborado(xProDet, iMovCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }                    
                }
            }

            //grabar masivo
            MovimientoCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            MovimientoDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesXPeriodo(string pAño, string pCodigoMes)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iMovCabEN.Adicionales.CampoOrden = MovimientoCabeEN.ClaMovCab;

            //ejecutar metodo
            return MovimientoCabeRN.ListarMovimientoCabesXPeriodo(iMovCabEN);
        }

        public static void RegenerarMovimientosDetalleSalidaTransferenciaSemiProductos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas liberaciones del periodo en proceso
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoCabe del periodo en proceso
            List<MovimientoCabeEN> iLisMovCab = MovimientoCabeRN.ListarMovimientoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoCabeEN> iLisMovCabMod = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
            List<MovimientoDetaEN> iLisMovDetMod = new List<MovimientoDetaEN>();
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
                    MovimientoCabeEN iMovCabEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaDesechas);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //segun si existe en movimientodeta en bd
                    MovimientoDetaEN iMovDetBus = ListaG.Buscar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab, iMovCabEN.ClaveMovimientoCabe);
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
                        MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesDesechos(xLib, iMovCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al movimiento ingreso transferencia
                    MovimientoCabeEN iMovCabIngTraEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovCabIngTraEN.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    MovimientoDetaEN iMovDetIngBus = ListaG.Buscar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovDetIngBus.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }

                //operacion para agregar el detalle que le falta a los movimientos salida transferencia del almacen de semi productos
                if (xLib.ClaveSalidaTransferenciaReproceso != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoCabeEN iMovCabEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaReproceso);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //segun si existe en movimientodeta en bd
                    MovimientoDetaEN iMovDetBus = ListaG.Buscar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab, iMovCabEN.ClaveMovimientoCabe);
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
                        MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesReproceso(xLib, iMovCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al movimiento ingreso transferencia
                    MovimientoCabeEN iMovCabIngTraEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovCabIngTraEN.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    MovimientoDetaEN iMovDetIngBus = ListaG.Buscar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovDetIngBus.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }

                //operacion para agregar el detalle que le falta a los movimientos salida transferencia del almacen de semi productos
                if (xLib.ClaveSalidaTransferenciaDonacion != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoCabeEN iMovCabEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaDonacion);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //segun si existe en movimientodeta en bd
                    MovimientoDetaEN iMovDetBus = ListaG.Buscar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab, iMovCabEN.ClaveMovimientoCabe);
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
                        MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoUnidadesDonacion(xLib, iMovCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al movimiento ingreso transferencia
                    MovimientoCabeEN iMovCabIngTraEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovCabIngTraEN.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    MovimientoDetaEN iMovDetIngBus = ListaG.Buscar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab, iMovCabEN.ClaveIngresoMovimientoCabe);

                    //actualizar datos
                    iMovDetIngBus.FechaMovimientoCabe = iMovCabEN.FechaMovimientoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }
            }

            //grabar masivo
            LiberacionRN.ModificarLiberacion(iLisLibMod);
            MovimientoCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
            MovimientoDetaRN.ModificarMovimientoDeta(iLisMovDetMod);
        }

        public static void RegenerarMovimientosDetalleSalidasSemiProductos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas las producciones deta del periodo en proceso
            List<List<ProduccionProTerEN>> iLisLisProProTer = ProduccionProTerRN.ListarListasProduccionProTerPorClaveEncajado(iAño, iCodigoMes);

            //traer todo el movimientoCabe del periodo en proceso
            List<MovimientoCabeEN> iLisMovCab = MovimientoCabeRN.ListarMovimientoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoCabeEN> iLisMovCabMod = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
           
            //recorrer cada produccion deta
            foreach (List<ProduccionProTerEN> xLisProProTer in iLisLisProProTer)
            {
                //obtener el primer objeto de la lista
                ProduccionProTerEN iProProTerEN = xLisProProTer[0];

                //operacion para agregar el detalle que le falta a los movimientos ingreso al almacen de semi productos
                if (iProProTerEN.ClaveSalidaUnidadesEmpacar != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoCabeEN iMovCabEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, iProProTerEN.ClaveSalidaUnidadesEmpacar);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = iProProTerEN.FechaEncajado;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //preguntar si hay detalle
                    List<MovimientoDetaEN> iLisMovDetEnc = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab,
                        iProProTerEN.ClaveSalidaUnidadesEmpacar);
                    if (iLisMovDetEnc.Count == 0)
                    {
                        //recorrer cada objeto ProduccionProTer
                        foreach (ProduccionProTerEN xProProTer in xLisProProTer)
                        {
                            //crear su movimientodeta                   
                            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaSalidaEmpaquetar(xProProTer, iMovCabEN, iCenCosEN);

                            //agregar a la lista resultado
                            iLisMovDetAdi.Add(iMovDetEN);
                        }
                    }                    
                }
            }

            //grabar masivo
            MovimientoCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);            
        }

        public static void RegenerarMovimientosDetalleIngresosProductosTerminados()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas las producciones deta del periodo en proceso
            List<List<ProduccionProTerEN>> iLisLisProProTer = ProduccionProTerRN.ListarListasProduccionProTerPorClaveEncajado(iAño, iCodigoMes);

            //traer todo el movimientoCabe del periodo en proceso
            List<MovimientoCabeEN> iLisMovCab = MovimientoCabeRN.ListarMovimientoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoCabeEN> iLisMovCabMod = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();

            //recorrer cada produccion deta
            foreach (List<ProduccionProTerEN> xLisProProTer in iLisLisProProTer)
            {
                //obtener el primer objeto de la lista
                ProduccionProTerEN iProProTerEN = xLisProProTer[0];

                //operacion para agregar el detalle que le falta a los movimientos ingreso al almacen de semi productos
                if (iProProTerEN.ClaveIngresoProductoTerminado != string.Empty)
                {
                    //traer al MovimientoCabe
                    MovimientoCabeEN iMovCabEN = ListaG.Buscar<MovimientoCabeEN>(iLisMovCab, MovimientoCabeEN.ClaMovCab, iProProTerEN.ClaveIngresoProductoTerminado);

                    //actualizar datos
                    iMovCabEN.FechaMovimientoCabe = iProProTerEN.FechaEncajado;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabEN);

                    //preguntar si hay detalle
                    List<MovimientoDetaEN> iLisMovDetEnc = ListaG.Filtrar<MovimientoDetaEN>(iLisMovDet, MovimientoDetaEN.ClaMovCab,
                        iProProTerEN.ClaveIngresoProductoTerminado);
                    if (iLisMovDetEnc.Count == 0)
                    {
                        //recorrer cada objeto ProduccionProTer
                        foreach (ProduccionProTerEN xProProTer in xLisProProTer)
                        {
                            //crear su movimientodeta                   
                            MovimientoDetaEN iMovDetEN = MovimientoDetaRN.CrearMovimientoDetaParaIngresoMercaderia(xProProTer, iMovCabEN, iCenCosEN);

                            //agregar a la lista resultado
                            iLisMovDetAdi.Add(iMovDetEN);
                        }
                    }
                }
            }

            //grabar masivo
            MovimientoCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
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
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveSalidaTransferenciaReproceso);
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveIngresoTransferenciaReproceso);
                EliminarMovimientoCabe(iLibEN.ClaveSalidaTransferenciaReproceso);
                EliminarMovimientoCabe(iLibEN.ClaveIngresoTransferenciaReproceso);
            }

            //eliminar movimientos transferencia desecho,si se llego a generar este movimiento
            if (iLibEN.ClaveSalidaTransferenciaDesechas != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveSalidaTransferenciaDesechas);
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveIngresoTransferenciaDesechas);
                EliminarMovimientoCabe(iLibEN.ClaveSalidaTransferenciaDesechas);
                EliminarMovimientoCabe(iLibEN.ClaveIngresoTransferenciaDesechas);
            }

            //eliminar movimientos transferencia donacion,si se llego a generar este movimiento
            if (iLibEN.ClaveSalidaTransferenciaDonacion != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveSalidaTransferenciaDonacion);
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveIngresoTransferenciaDonacion);
                EliminarMovimientoCabe(iLibEN.ClaveSalidaTransferenciaDonacion);
                EliminarMovimientoCabe(iLibEN.ClaveIngresoTransferenciaDonacion);
            }

            //eliminar movimientos transferencia muestra,si se llego a generar este movimiento
            if (iLibEN.ClaveSalidaTransferenciaMuestra != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveSalidaTransferenciaMuestra);
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(iLibEN.ClaveIngresoTransferenciaMuestra);
                EliminarMovimientoCabe(iLibEN.ClaveSalidaTransferenciaMuestra);
                EliminarMovimientoCabe(iLibEN.ClaveIngresoTransferenciaMuestra);
            }
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesNoImportados(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesNoImportados(pObj);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesNoImportadosIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "1";//ingreso
            iMovCabEN.Adicionales.CampoOrden = MovimientoCabeEN.ClaMovCab;

            //ejecutar metodo
            return ListarMovimientoCabesNoImportados(iMovCabEN);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesNoImportadosSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();
            iMovCabEN.PeriodoMovimientoCabe = pCodigoPeriodo;
            iMovCabEN.CClaseTipoOperacion = "2";//salida
            iMovCabEN.Adicionales.CampoOrden = MovimientoCabeEN.ClaMovCab;

            //ejecutar metodo
            return ListarMovimientoCabesNoImportados(iMovCabEN);
        }

        public static void RegenerarLotesYLotesDetaAMovimientos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");
           
            //traer todo el movimientoDeta del periodo en proceso
            List<MovimientoDetaEN> iLisMovDet = MovimientoDetaRN.ListarMovimientosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<MovimientoCabeEN> iLisMovCabMod = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();

           

            //grabar masivo
            MovimientoCabeRN.ModificarMovimientoCabe(iLisMovCabMod);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
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
            List<MovimientoCabeEN> iLisMovCabAdi = new List<MovimientoCabeEN>();
            List<MovimientoDetaEN> iLisMovDetAdi = new List<MovimientoDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero movimiento para la salida
            string iNumeroMovimientoCabeSalida = string.Empty;

            //recorrer cada lista
            foreach (List<ProduccionExisEN> xLisProExi in iLisLisProExi)
            {
                //obtener al primer objeto de la lista
                ProduccionExisEN iProExi = xLisProExi[0];

                //creamos el objeto MovimientoCabe de salida transferencia
                MovimientoCabeEN iMovCabSalEN = new MovimientoCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabSalEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iProExi.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iProExi.CodigoPersonal;
                iMovCabSalEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA DE PRODUCCION SINCERADO";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(ref iNumeroMovimientoCabeSalida, iMovCabSalEN);
                iMovCabSalEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabSalEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoDetaEN> iLisMovDetSal = new List<MovimientoDetaEN>();

                //variable para los correlativos de cada movimientoDeta
                string iCorrelativoMovimientoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (ProduccionExisEN xProExi in xLisProExi)
                {
                    //buscar a la existencia para este xProExi
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExi, ExistenciaEN.CodAlm, xProExi.CodigoAlmacen,
                        ExistenciaEN.CodExi, xProExi.CodigoExistencia);

                    //creamos un objeto MovimientoDeta
                    MovimientoDetaEN iMovDetSalEN = new MovimientoDetaEN();

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
                    iMovDetSalEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetSalEN);
                    iMovDetSalEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetSalEN);
                    iMovDetSalEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetSalEN);
                    iMovDetSalEN.GlosaMovimientoDeta = iMovCabSalEN.GlosaMovimientoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveMovimientoCabe = iMovCabSalEN.ClaveMovimientoCabe;
                    iMovDetSalEN.CorrelativoMovimientoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoMovimientoDeta);
                    iMovDetSalEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetSalEN);

                    //adicionar a la lista de movimientoDeta de este MovimientoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //grabar lotesdeta
                LoteDetaRN.AdicionarLoteDeta(iLisMovDetSal);

                //creamos el objeto MovimientoCabe de ingreso transferencia
                MovimientoCabeEN iMovCabIngEN = new MovimientoCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaMovimientoCabe = iFechaMovimientoCabe;
                iMovCabIngEN.PeriodoMovimientoCabe = Fecha.ObtenerPeriodo(iFechaMovimientoCabe, "-");
                iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iProExi.CodigoAlmacenOrigen;
                iMovCabIngEN.CodigoPersonal = iProExi.CodigoPersonalOrigen;
                iMovCabIngEN.GlosaMovimientoCabe = "TRANSFERENCIA AUTOMATICA DE PRODUCCION SINCERADO";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroMovimientoCabe = MovimientoCabeRN.ObtenerNuevoNumeroMovimientoCabeAutogenerado(iMovCabIngEN);
                iMovCabIngEN.ClaveMovimientoCabe = MovimientoCabeRN.ObtenerClaveMovimientoCabe(iMovCabIngEN);

                //creamos la lista de MovimientoDeta de salida transferencia
                List<MovimientoDetaEN> iLisMovDetIng = new List<MovimientoDetaEN>();

                //recorrer cada objeto MovimientoDetaSalida
                foreach (MovimientoDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto movimientoDeta
                    MovimientoDetaEN iMovDetIngEN = new MovimientoDetaEN();

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
                    iMovDetIngEN.ClaveMovimientoDeta = MovimientoDetaRN.ObtenerClaveMovimientoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = MovimientoDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExi);

                    //actualizar los datos anteriores de la existencia en el MovimientoDeta
                    iMovDetIngEN.StockAnteriorExistencia = iExiEncEN.StockActualExistencia;
                    iMovDetIngEN.PrecioAnteriorExistencia = iExiEncEN.PrecioPromedioExistencia;

                    //actualizar calculos
                    iMovDetIngEN.PrecioUnitarioMovimientoDeta = MovimientoDetaRN.ObtenerPrecioUnitarioPorRecalculo(iMovDetIngEN);
                    iMovDetIngEN.CostoMovimientoDeta = MovimientoDetaRN.ObtenerCosto(iMovDetIngEN);
                    iMovDetIngEN.StockExistencia = MovimientoDetaRN.ObtenerNuevoStockPorAdicion(iMovDetIngEN);
                    iMovDetIngEN.PrecioExistencia = MovimientoDetaRN.ObtenerNuevoPrecioPromedio(iMovDetIngEN);

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
                List<ExistenciaEN> iLisExiSalMod = MovimientoDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetSal);
                List<ExistenciaEN> iLisExiIngMod = MovimientoDetaRN.ListarExistenciasActualizadasPorAdicionMovimientosDeta(iLisMovDetIng);

                //adicionamos a la lista de existencias a modificar
                iLisExiMod.AddRange(iLisExiSalMod);
                iLisExiMod.AddRange(iLisExiIngMod);
            }

            //guardando cada clave de movimiento salida en el objeto produccionDeta
            pObj.ClavesTransferenciaSincerado = ListaG.ArmarCadenaDeValores<MovimientoCabeEN>(iLisMovCabAdi, MovimientoCabeEN.ClaMovCab, ";");

            //grabar en b.d
            MovimientoCabeRN.AdicionarMovimientoCabe(iLisMovCabAdi);
            MovimientoDetaRN.AdicionarMovimientoDeta(iLisMovDetAdi);
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
                MovimientoDetaRN.EliminarMovimientoDetaXMovimientoCabe(xStrCla);
            }

            //volver a generar la transferencia automatica
            GenerarTransferenciasAutomaticasAlAdicionarPorSincerado(pObj);
        }

        public static List<MovimientoCabeEN> ListarMovimientoCabesXClaveProduccionProTerYClaseOperacion(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesXClaveProduccionProTerYClaseOperacion(pObj);
        }

        public static string ObtenerStrProduccionesDetaUsadasParaAdicionales(List<MovimientoDetaEN> pLisMovDet, ProduccionProTerEN pProProTer)
        {
            //valor resultado
            string iValor = string.Empty;

            //valida cuando no hay objeto en la lista
            if (pLisMovDet.Count == 0) { return iValor; }

            //obtener al unico objeto de la lista
            MovimientoDetaEN iMovDetEN = pLisMovDet[0];

            //valida cuando el objeto no es del almacen "A11"
            if (iMovDetEN.CodigoAlmacen != "A11"){ return iValor; }

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

        public static List<MovimientoCabeEN> ListarMovimientoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            return iPerAD.ListarMovimientoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(pObj);
        }

        public static MovimientoCabeEN ValidaCuandoFechaEsMenorAFechaEncajado(MovimientoCabeEN pObj,string pFechaEncajado)
        {
            //objeto resultado
            MovimientoCabeEN iMovCabEN = new MovimientoCabeEN();

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

        public static void EnviadoMovimientoCabe(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.EnviadoMovimientoCabe(pObj);
        }

        public static void AsignarCalcularFlete(MovimientoCabeEN pObj, List<MovimientoCabeEN> pLista)
        {
            //lista actualizada
            List<MovimientoCabeEN> iLisSol = new List<MovimientoCabeEN>();

            //buscamos el objeto en la lista pLista
            foreach (MovimientoCabeEN xPem in pLista)
            {
                if (xPem.ClaveMovimientoCabe == pObj.ClaveMovimientoCabe)
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

        public static void ActualizaCostoFletexMovimientoCabe(MovimientoCabeEN pObj)
        {
            MovimientoCabeAD iPerAD = new MovimientoCabeAD();
            iPerAD.ActualizaCostoFletexMovimientoCabe(pObj);
        }

    }
}
