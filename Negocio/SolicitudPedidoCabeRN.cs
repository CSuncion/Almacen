using Comun;
using Datos;
using Entidades;
using Entidades.Adicionales;
using Entidades.Contabilidad;
using Entidades.Estructuras;
using Negocio.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SolicitudPedidoCabeRN
    {
        public static SolicitudPedidoCabeEN EnBlanco()
        {
            SolicitudPedidoCabeEN iExiEN = new SolicitudPedidoCabeEN();
            return iExiEN;
        }

        public static void AdicionarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.AgregarSolicitudPedidoCabe(pObj);
        }

        public static void AdicionarSolicitudPedidoCabe(List<SolicitudPedidoCabeEN> pLista)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.AgregarSolicitudPedidoCabe(pLista);
        }

        public static void ModificarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.ModificarSolicitudPedidoCabe(pObj);
        }

        public static void ModificarSolicitudPedidoCabe(List<SolicitudPedidoCabeEN> pLista)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.ModificarSolicitudPedidoCabe(pLista);
        }

        public static void EliminarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.EliminarSolicitudPedidoCabe(pObj);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabes(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabes(pObj);
        }

        public static SolicitudPedidoCabeEN BuscarSolicitudPedidoCabeXClave(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.BuscarSolicitudPedidoCabeXClave(pObj);
        }

        public static SolicitudPedidoCabeEN BuscarSolicitudPedidoCabeXClave(string pClaveSolicitudPedidoCabe)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = pClaveSolicitudPedidoCabe;

            //ejecutar metodo
            return SolicitudPedidoCabeRN.BuscarSolicitudPedidoCabeXClave(iSolPedidoCabEN);
        }

        public static SolicitudPedidoCabeEN EsSolicitudPedidoCabeExistente(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iExiEN = new SolicitudPedidoCabeEN();

            //validar si existe en b.d
            iExiEN = SolicitudPedidoCabeRN.BuscarSolicitudPedidoCabeXClave(pObj);
            if (iExiEN.ClaveSolicitudPedidoCabe == string.Empty)
            {
                iExiEN.Adicionales.EsVerdad = false;
                iExiEN.Adicionales.Mensaje = "El registro no existe";
                return iExiEN;
            }

            //ok        
            return iExiEN;
        }

        public static string ObtenerValorDeCampo(SolicitudPedidoCabeEN pObj, string pNombreCampo)
        {
            //valor resultado
            string iValor = string.Empty;

            //segun nombre campo
            switch (pNombreCampo)
            {
                case SolicitudPedidoCabeEN.ClaObj: return pObj.ClaveObjeto;
                case SolicitudPedidoCabeEN.ClaMovCab: return pObj.ClaveSolicitudPedidoCabe;
                case SolicitudPedidoCabeEN.CodEmp: return pObj.CodigoEmpresa;
                case SolicitudPedidoCabeEN.NomEmp: return pObj.NombreEmpresa;
                case SolicitudPedidoCabeEN.PerMovCab: return pObj.PeriodoSolicitudPedidoCabe;
                case SolicitudPedidoCabeEN.CodAlm: return pObj.CodigoAlmacen;
                case SolicitudPedidoCabeEN.DesAlm: return pObj.DescripcionAlmacen;
                //case SolicitudPedidoCabeEN.CodTipOpe: return pObj.CodigoTipoOperacion;
                //case SolicitudPedidoCabeEN.DesTipOpe: return pObj.DescripcionTipoOperacion;
                //case SolicitudPedidoCabeEN.CClaTipOpe: return pObj.CClaseTipoOperacion;
                //case SolicitudPedidoCabeEN.NClaTipOpe: return pObj.NClaseTipoOperacion;
                case SolicitudPedidoCabeEN.CCalPrePro: return pObj.CCalculaPrecioPromedio;
                case SolicitudPedidoCabeEN.NumMovCab: return pObj.NumeroSolicitudPedidoCabe;
                case SolicitudPedidoCabeEN.FecMovCab: return pObj.FechaSolicitudPedidoCabe;
                case SolicitudPedidoCabeEN.CodAux: return pObj.CodigoAuxiliar;
                case SolicitudPedidoCabeEN.DesAux: return pObj.DescripcionAuxiliar;
                case SolicitudPedidoCabeEN.CodPer: return pObj.CodigoPersonal;
                case SolicitudPedidoCabeEN.NomPer: return pObj.NombrePersonal;
                case SolicitudPedidoCabeEN.FecDoc: return pObj.FechaDocumento;
                case SolicitudPedidoCabeEN.GloMovCab: return pObj.GlosaSolicitudPedidoCabe;
                case SolicitudPedidoCabeEN.COriVenCre: return pObj.COrigenVentanaCreacion;
                case SolicitudPedidoCabeEN.NOriVenCre: return pObj.NOrigenVentanaCreacion;
                case SolicitudPedidoCabeEN.CEstMovCab: return pObj.CEstadoSolicitudPedidoCabe;
                case SolicitudPedidoCabeEN.NEstMovCab: return pObj.NEstadoSolicitudPedidoCabe;
                case SolicitudPedidoCabeEN.UsuAgr: return pObj.UsuarioAgrega;
                case SolicitudPedidoCabeEN.FecAgr: return pObj.FechaAgrega.ToString();
                case SolicitudPedidoCabeEN.UsuMod: return pObj.UsuarioModifica;
                case SolicitudPedidoCabeEN.FecMod: return pObj.FechaModifica.ToString();
            }

            //retorna
            return iValor;
        }

        public static List<SolicitudPedidoCabeEN> FiltrarSolicitudPedidoCabesXTextoEnCualquierPosicion(List<SolicitudPedidoCabeEN> pLista, string pCampoBusqueda, string pValorBusqueda)
        {
            //lista resultado
            List<SolicitudPedidoCabeEN> iLisRes = new List<SolicitudPedidoCabeEN>();

            //valor busqueda en mayuscula
            string iValor = pValorBusqueda.ToUpper();

            //recorrer cada objeto
            foreach (SolicitudPedidoCabeEN xPer in pLista)
            {
                string iTexto = ObjetoG.ObtenerTexto<SolicitudPedidoCabeEN>(xPer, pCampoBusqueda).ToUpper();
                if (iTexto.IndexOf(iValor) != -1)
                {
                    iLisRes.Add(xPer);
                }
            }

            //devolver
            return iLisRes;
        }

        public static List<SolicitudPedidoCabeEN> ListarDatosParaGrillaPrincipal(string pValorBusqueda, string pCampoBusqueda, List<SolicitudPedidoCabeEN> pListaSolicitudPedidoCabes)
        {
            //lista resultado
            List<SolicitudPedidoCabeEN> iLisRes = new List<SolicitudPedidoCabeEN>();

            //si el valor filtro esta vacio entonces devuelve toda la lista del parametro
            if (pValorBusqueda == string.Empty) { return pListaSolicitudPedidoCabes; }

            //filtar la lista
            iLisRes = SolicitudPedidoCabeRN.FiltrarSolicitudPedidoCabesXTextoEnCualquierPosicion(pListaSolicitudPedidoCabes, pCampoBusqueda, pValorBusqueda);

            //retornar
            return iLisRes;
        }

        public static string ObtenerClaveSolicitudPedidoCabe(SolicitudPedidoCabeEN pPer)
        {
            //valor resultado
            string iClave = string.Empty;

            //armar clave
            iClave += Universal.gCodigoEmpresa + "-";
            iClave += pPer.PeriodoSolicitudPedidoCabe + "-";
            iClave += pPer.CodigoAlmacen + "-";
            //iClave += pPer.CodigoTipoOperacion + "-";
            iClave += pPer.NumeroSolicitudPedidoCabe;

            //retornar
            return iClave;
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXPeriodoYClaseOperacion(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesXPeriodoYClaseOperacion(pObj);
        }

        public static string ObtenerMaximoValorEnColumna(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iCliAD = new SolicitudPedidoCabeAD();
            return iCliAD.ObtenerMaximoValorEnColumna(pObj);
        }

        public static string ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(SolicitudPedidoCabeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la b.d
            string iUltimoCodigo = SolicitudPedidoCabeRN.ObtenerMaximoValorEnColumna(pObj);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static SolicitudPedidoCabeEN EsActoAdicionarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //ok          
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN ValidaCuandoNoEsActoRegistrarEnPeriodo(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //validar
            PeriodoEN iPerEN = new PeriodoEN();
            iPerEN.CodigoPeriodo = pObj.PeriodoSolicitudPedidoCabe;
            iPerEN = PeriodoRN.EsActoRegistrarEnEstePeriodo(iPerEN);

            //pasamos datos de la validacion
            iSolPedidoCabEN.Adicionales.EsVerdad = iPerEN.Adicionales.EsVerdad;
            iSolPedidoCabEN.Adicionales.Mensaje = iPerEN.Adicionales.Mensaje;

            //devolver
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN ValidaCuandoFechaNoEsDelPeriodoElegido(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //validar
            bool iEsVerdad = Periodo.EsFechaDePeriodo(pObj.FechaSolicitudPedidoCabe, pObj.PeriodoSolicitudPedidoCabe);
            if (iEsVerdad == false)
            {
                iSolPedidoCabEN.Adicionales.EsVerdad = false;
                iSolPedidoCabEN.Adicionales.Mensaje = "La fecha " + pObj.FechaSolicitudPedidoCabe + " debe ser del periodo " +
                                                Periodo.FormatoAñoYNombreMes(pObj.PeriodoSolicitudPedidoCabe);
                return iSolPedidoCabEN;
            }

            //ok
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN EsActoModificarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida si existe
            iSolPedidoCabEN = SolicitudPedidoCabeRN.EsSolicitudPedidoCabeExistente(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            SolicitudPedidoCabeEN iSolPedidoCabVenEN = SolicitudPedidoCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iSolPedidoCabEN, pObj.COrigenVentanaCreacion);
            if (iSolPedidoCabVenEN.Adicionales.EsVerdad == false) { return iSolPedidoCabVenEN; }

            //ok          
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN EsActoAgregarVariasSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida si existe
            iSolPedidoCabEN = SolicitudPedidoCabeRN.EsSolicitudPedidoCabeExistente(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            SolicitudPedidoCabeEN iSolPedidoCabVenEN = SolicitudPedidoCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iSolPedidoCabEN, pObj.COrigenVentanaCreacion);
            if (iSolPedidoCabVenEN.Adicionales.EsVerdad == false) { return iSolPedidoCabVenEN; }

            //ok          
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN EsActoGenerarOrdenCompra(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto registrar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida si existe
            iSolPedidoCabEN = SolicitudPedidoCabeRN.EsSolicitudPedidoCabeExistente(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            SolicitudPedidoCabeEN iSolPedidoCabVenEN = SolicitudPedidoCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iSolPedidoCabEN, pObj.COrigenVentanaCreacion);
            if (iSolPedidoCabVenEN.Adicionales.EsVerdad == false) { return iSolPedidoCabVenEN; }

            //ok          
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN ValidaCuandoRegistroNofueCreadoPorVentanaProceso(SolicitudPedidoCabeEN pObj, string pCodigoVentanaProceso)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //validar           
            if (pObj.COrigenVentanaCreacion != pCodigoVentanaProceso)
            {
                iSolPedidoCabEN.Adicionales.EsVerdad = false;
                iSolPedidoCabEN.Adicionales.Mensaje = "Este registro no fue creado por esta ventana, no se puede realizar la operacion";
                return iSolPedidoCabEN;
            }

            //ok
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN EsActoEliminarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida si existe
            iSolPedidoCabEN = SolicitudPedidoCabeRN.EsSolicitudPedidoCabeExistente(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            SolicitudPedidoCabeEN iMovCabVenEN = SolicitudPedidoCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iSolPedidoCabEN, pObj.COrigenVentanaCreacion);
            if (iMovCabVenEN.Adicionales.EsVerdad == false) { return iMovCabVenEN; }

            //ok          
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN EsActoAprobarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida si existe
            iSolPedidoCabEN = SolicitudPedidoCabeRN.EsSolicitudPedidoCabeExistente(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando este registro no ha sido creado por la ventana en proceso
            SolicitudPedidoCabeEN iMovCabVenEN = SolicitudPedidoCabeRN.ValidaCuandoRegistroNofueCreadoPorVentanaProceso(iSolPedidoCabEN, pObj.COrigenVentanaCreacion);
            if (iMovCabVenEN.Adicionales.EsVerdad == false) { return iMovCabVenEN; }

            //ok          
            return iSolPedidoCabEN;
        }

        public static bool ExisteValorEnColumnaSinEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ExisteValorEnColumnaSinEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda);
        }

        public static bool ExisteValorEnColumnaConEmpresa(string pColumnaBusqueda, string pValorBusqueda, string pColumnaCondicion1, string pValorCondicion1)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ExisteValorEnColumnaConEmpresa(pColumnaBusqueda, pValorBusqueda, pColumnaCondicion1, pValorCondicion1);
        }

        public static string ObtenerFechaSolicitudPedidoCabeSugerido(string pPeriodoRegistro, string pFechaSolicitudPedidoCabeDtp)
        {
            //si la fecha SolicitudPedido dtp pertenece al periodo registro, entonces se devuleve esta misma fecha
            if (Periodo.EsFechaDePeriodo(pFechaSolicitudPedidoCabeDtp, pPeriodoRegistro) == true) { return pFechaSolicitudPedidoCabeDtp; }

            //aqui la fecha es de otro periodo, entonces formamos una fecha con el periodo parametro
            return Periodo.ObtenerFecha("01", pPeriodoRegistro);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesParaGrillaTransferencia(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesParaGrillaTransferencia(pObj);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesParaGrillaIngresos(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesParaGrillaIngresos(pObj);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesParaGrillaSalidas(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesParaGrillaSalidas(pObj);
        }

        public static void EliminarSolicitudPedidoCabeYDeta(SolicitudPedidoCabeEN pObj)
        {
            //eliminar primero la cabecera
            SolicitudPedidoCabeRN.EliminarSolicitudPedidoCabe(pObj);

            //eliminar el detalle
            SolicitudPedidoDetaEN iMovDetEN = new SolicitudPedidoDetaEN();
            iMovDetEN.ClaveSolicitudPedidoCabe = pObj.ClaveSolicitudPedidoCabe;
            SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iMovDetEN);
        }

        public static void EliminarSolicitudPedidoCabe(string pClaveSolicitudPedidoCabe)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = pClaveSolicitudPedidoCabe;

            //ejecutar metodo
            SolicitudPedidoCabeRN.EliminarSolicitudPedidoCabe(iSolPedidoCabEN);
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
            List<SolicitudPedidoCabeEN> iLisMovCabAdi = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();
            List<AuxiliarEN> iLisAuxMod = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<RegContabDeta_Cont_EN> xLisRegConDet in iLisLisRegConDet)
            {
                //obtener al primer objeto de la lista
                RegContabDeta_Cont_EN iRegConDetEN = xLisRegConDet[0];

                //obtener al objeto almacen para este SolicitudPedido
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iRegConDetEN.Almacen, iLisAlm);

                //creamos un nuevo SolicitudPedidoCabe
                SolicitudPedidoCabeEN iMovCabNueEN = new SolicitudPedidoCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
                iMovCabNueEN.CodigoAlmacen = iRegConDetEN.Almacen;
                //iMovCabNueEN.CodigoTipoOperacion = SolicitudPedidoCabeRN.ObtenerCodigoTipoOperacion(iRegConDetEN, iParEN);
                iMovCabNueEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi);
                iMovCabNueEN.FechaSolicitudPedidoCabe = iRegConDetEN.FechaVoucherRegContabCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iRegConDetEN.CodigoAuxiliar;
                iMovCabNueEN.FechaDocumento = iRegConDetEN.FechaDocumento;
                iMovCabNueEN.GlosaSolicitudPedidoCabe = iRegConDetEN.DescripcionRegContabCabe;
                iMovCabNueEN.COrigenVentanaCreacion = "5";//Importado Contabilidad
                iMovCabNueEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabNueEN);

                //adicionamos a la lista de SolicitudPedidoCabe para adicionar
                iLisMovCabAdi.Add(iMovCabNueEN);

                //correlativo para los SolicitudPedidosDeta
                string iCorrelativoSolicitudPedidoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (RegContabDeta_Cont_EN xRegConDet in xLisRegConDet)
                {
                    //incrementar el correlativo
                    iCorrelativoSolicitudPedidoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoSolicitudPedidoDeta);

                    //creamos un nuevo objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetNueEN = new SolicitudPedidoDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroSolicitudPedidoCabe = iMovCabNueEN.NumeroSolicitudPedidoCabe;
                    iMovDetNueEN.ClaveSolicitudPedidoCabe = iMovCabNueEN.ClaveSolicitudPedidoCabe;
                    iMovDetNueEN.CorrelativoSolicitudPedidoDeta = iCorrelativoSolicitudPedidoDeta;
                    iMovDetNueEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetNueEN);
                    iMovDetNueEN.CodigoEmpresa = iMovCabNueEN.CodigoEmpresa;
                    iMovDetNueEN.FechaSolicitudPedidoCabe = iMovCabNueEN.FechaSolicitudPedidoCabe;
                    iMovDetNueEN.PeriodoSolicitudPedidoCabe = iMovCabNueEN.PeriodoSolicitudPedidoCabe;
                    iMovDetNueEN.CodigoAlmacen = iMovCabNueEN.CodigoAlmacen;
                    //iMovDetNueEN.CodigoTipoOperacion = iMovCabNueEN.CodigoTipoOperacion;
                    iMovDetNueEN.CodigoAuxiliar = iMovCabNueEN.CodigoAuxiliar;
                    iMovDetNueEN.FechaDocumento = iMovCabNueEN.FechaDocumento;
                    iMovDetNueEN.CodigoCentroCosto = xRegConDet.CodigoCentroCosto;
                    iMovDetNueEN.CodigoExistencia = xRegConDet.CodigoGastoReparable;
                    iMovDetNueEN.CodigoUnidadMedida = xRegConDet.Unidad;
                    iMovDetNueEN.CantidadSolicitudPedidoDeta = xRegConDet.Cantidad;
                    iMovDetNueEN.GlosaSolicitudPedidoDeta = xRegConDet.GlosaRegContabDeta;

                    //adicionamos a la lista de SolicitudPedidoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            AuxiliarRN.LlenarListaAdicionYModificacion(iLisAuxAdi, iLisAuxMod, iLisAuxAlm, iLisAuxCont);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            SolicitudPedidoCabeRN.EliminarAntesDeImportar(pCodigoPeriodo);

            //grabaciones masivas
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iLisMovCabAdi);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
            AuxiliarRN.ModificarAuxiliar(iLisAuxMod);

        }

        public static string ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(SolicitudPedidoCabeEN pObj, List<SolicitudPedidoCabeEN> pLista)
        {
            //valor resultado
            string iNumero = string.Empty;

            //obtener el ultimo codigo que hay en la lista
            string iUltimoCodigo = SolicitudPedidoCabeRN.ObtenerMaximoValorEnColumna(pObj, pLista);

            //obtener el siguiente codigo
            iNumero = Numero.IncrementarCorrelativoNumerico(iUltimoCodigo, 6);

            //devuelve
            return iNumero;
        }

        public static string ObtenerMaximoValorEnColumna(SolicitudPedidoCabeEN pObj, List<SolicitudPedidoCabeEN> pLista)
        {
            //valor resultado
            string iValor = string.Empty;

            //recorrer cada objeto
            foreach (SolicitudPedidoCabeEN xMovCab in pLista)
            {
                if (pObj.PeriodoSolicitudPedidoCabe != xMovCab.PeriodoSolicitudPedidoCabe) { continue; }
                if (pObj.CodigoAlmacen != xMovCab.CodigoAlmacen) { continue; }
                //if (pObj.CodigoTipoOperacion != xMovCab.CodigoTipoOperacion) { continue; }

                //obtener su numero SolicitudPedidoCabe
                iValor = xMovCab.NumeroSolicitudPedidoCabe;
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

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXPeriodo(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesXPeriodo(pObj);
        }

        public static SolicitudPedidoCabeEN ArmarSolicitudPedidoCabeAjuste(InventarioCabeEN pInvCab, TipoOperacionEN pTipOpe, string pFechaGenera)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //pasamos datos
            iSolPedidoCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(pFechaGenera, "-");
            iSolPedidoCabEN.FechaSolicitudPedidoCabe = pFechaGenera;
            //iSolPedidoCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            //iSolPedidoCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            //iSolPedidoCabEN.CClaseTipoOperacion = pTipOpe.CClaseTipoOperacion;
            iSolPedidoCabEN.CodigoAlmacen = pInvCab.CodigoAlmacen;
            iSolPedidoCabEN.CodigoPersonal = pInvCab.CodigoPersonal;
            iSolPedidoCabEN.GlosaSolicitudPedidoCabe = "Ajuste Inventario";
            iSolPedidoCabEN.COrigenVentanaCreacion = "6";//inventario
            iSolPedidoCabEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iSolPedidoCabEN);
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iSolPedidoCabEN);

            //devolver
            return iSolPedidoCabEN;
        }

        public static void EliminarAntesDeImportar(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar SolicitudPedido deta
            SolicitudPedidoDetaRN.EliminarSolicitudPedidosDetaDeImportacion(pCodigoPeriodo);

            //eliminar SolicitudPedido cabe
            SolicitudPedidoCabeRN.EliminarSolicitudPedidosCabeDeImportacion(pCodigoPeriodo);
        }

        public static void EliminarAntesDeImportarIngreso(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar SolicitudPedido deta
            SolicitudPedidoDetaRN.EliminarSolicitudPedidosDetaDeImportacionIngreso(pCodigoPeriodo);

            //eliminar SolicitudPedido cabe
            SolicitudPedidoCabeRN.EliminarSolicitudPedidosCabeDeImportacionIngreso(pCodigoPeriodo);
        }

        public static void EliminarAntesDeImportarSalida(string pCodigoPeriodo)
        {
            //eliminar todo el periodo pero solo lo que se importo
            //eliminar SolicitudPedido deta
            SolicitudPedidoDetaRN.EliminarSolicitudPedidosDetaDeImportacionSalida(pCodigoPeriodo);

            //eliminar SolicitudPedido cabe
            SolicitudPedidoCabeRN.EliminarSolicitudPedidosCabeDeImportacionSalida(pCodigoPeriodo);
        }

        public static void EliminarSolicitudPedidoCabeXPeriodoYOrigen(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.EliminarSolicitudPedidoCabeXPeriodoYOrigen(pObj);
        }

        public static void EliminarSolicitudPedidoCabeXPeriodoXOrigenYClase(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.EliminarSolicitudPedidoCabeXPeriodoXOrigenYClase(pObj);
        }

        public static void EliminarSolicitudPedidosCabeDeImportacion(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            iSolPedidoCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            SolicitudPedidoCabeRN.EliminarSolicitudPedidoCabeXPeriodoYOrigen(iSolPedidoCabEN);
        }

        public static void EliminarSolicitudPedidosCabeDeImportacionIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            //iSolPedidoCabEN.CClaseTipoOperacion = "1";//ingreso
            iSolPedidoCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            SolicitudPedidoCabeRN.EliminarSolicitudPedidoCabeXPeriodoXOrigenYClase(iSolPedidoCabEN);
        }

        public static void EliminarSolicitudPedidosCabeDeImportacionSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            //iSolPedidoCabEN.CClaseTipoOperacion = "2";//salida
            iSolPedidoCabEN.COrigenVentanaCreacion = "5";//importacion excel

            //ejecutar metodo
            SolicitudPedidoCabeRN.EliminarSolicitudPedidoCabeXPeriodoXOrigenYClase(iSolPedidoCabEN);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXClaveProduccionDetaYClaseOperacion(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesXClaveProduccionDetaYClaseOperacion(pObj);
        }

        public static void GenerarTransferenciasAutomaticasAProduccion(List<InsumoFaltante> pLisInsTra)
        {
            //separar en listas los insumos por almacen
            List<List<InsumoFaltante>> iLisLisInsTraAlm = ListaG.ListarListas<InsumoFaltante>(pLisInsTra, InsumoFaltante.CodAlm);

            //obtener la fecha para estos SolicitudPedidos de transferencia(este dato sale de la fecha de produccion de estos insumos)
            string iFechaSolicitudPedidoCabe = ListaG.ObtenerPrimerValor<InsumoFaltante>(pLisInsTra, InsumoFaltante.FecPro);

            //traemos al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeSalEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaSalida);

            //traemos al tipo de operacion de transferencia ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaIngreso);

            //traer la lista de existencias de la empresa actual
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistencias();

            //listas para adicionar y modificar en b.d
            List<SolicitudPedidoCabeEN> iLisMovCabAdi = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero SolicitudPedido para el ingreso
            string iNumeroSolicitudPedidoCabeIngreso = string.Empty;

            //recorrer cada lista
            foreach (List<InsumoFaltante> xLisInsFal in iLisLisInsTraAlm)
            {
                //obtener al primer objeto de la lista
                InsumoFaltante iInsFal = xLisInsFal[0];

                //creamos el objeto SolicitudPedidoCabe de salida transferencia
                SolicitudPedidoCabeEN iMovCabSalEN = new SolicitudPedidoCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaSolicitudPedidoCabe = iFechaSolicitudPedidoCabe;
                iMovCabSalEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iFechaSolicitudPedidoCabe, "-");
                //iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iInsFal.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iInsFal.CodigoPersonal;
                iMovCabSalEN.GlosaSolicitudPedidoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iMovCabSalEN);
                iMovCabSalEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabSalEN);

                //creamos la lista de SolicitudPedidoDeta de salida transferencia
                List<SolicitudPedidoDetaEN> iLisMovDetSal = new List<SolicitudPedidoDetaEN>();

                //variable para los correlativos de cada SolicitudPedidoDeta
                string iCorrelativoSolicitudPedidoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (InsumoFaltante xInsFal in xLisInsFal)
                {
                    //buscar a la existencia para este xInsFal
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExi, ExistenciaEN.CodAlm, xInsFal.CodigoAlmacen,
                        ExistenciaEN.CodExi, xInsFal.CodigoExistencia);

                    //creamos un objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetSalEN = new SolicitudPedidoDetaEN();

                    //pasar datos
                    iMovDetSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetSalEN.FechaSolicitudPedidoCabe = iMovCabSalEN.FechaSolicitudPedidoCabe;
                    iMovDetSalEN.PeriodoSolicitudPedidoCabe = iMovCabSalEN.PeriodoSolicitudPedidoCabe;
                    iMovDetSalEN.CodigoAlmacen = iMovCabSalEN.CodigoAlmacen;
                    //iMovDetSalEN.CodigoTipoOperacion = iMovCabSalEN.CodigoTipoOperacion;
                    iMovDetSalEN.CCalculaPrecioPromedio = iTipOpeSalEN.CCalculaPrecioPromedio;
                    iMovDetSalEN.CClaseTipoOperacion = "2";//salida
                    iMovDetSalEN.NumeroSolicitudPedidoCabe = iMovCabSalEN.NumeroSolicitudPedidoCabe;
                    iMovDetSalEN.CodigoCentroCosto = string.Empty;
                    iMovDetSalEN.DescripcionCentroCosto = string.Empty;
                    iMovDetSalEN.CodigoExistencia = xInsFal.CodigoExistencia;
                    iMovDetSalEN.DescripcionExistencia = xInsFal.DescripcionExistencia;
                    iMovDetSalEN.CodigoUnidadMedida = xInsFal.CUnidadMedida;
                    iMovDetSalEN.NombreUnidadMedida = xInsFal.NUnidadMedida;
                    iMovDetSalEN.CantidadSolicitudPedidoDeta = xInsFal.CantidadFaltante;
                    iMovDetSalEN.GlosaSolicitudPedidoDeta = iMovCabSalEN.GlosaSolicitudPedidoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveSolicitudPedidoCabe = iMovCabSalEN.ClaveSolicitudPedidoCabe;
                    iMovDetSalEN.CorrelativoSolicitudPedidoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoSolicitudPedidoDeta);
                    iMovDetSalEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetSalEN);

                    //adicionar a la lista de SolicitudPedidoDeta de este SolicitudPedidoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //grabar lotesdeta
                //LoteDetaRN.AdicionarLoteDeta(iLisMovDetSal);

                //creamos el objeto SolicitudPedidoCabe de ingreso transferencia
                SolicitudPedidoCabeEN iMovCabIngEN = new SolicitudPedidoCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaSolicitudPedidoCabe = iFechaSolicitudPedidoCabe;
                iMovCabIngEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iFechaSolicitudPedidoCabe, "-");
                //iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iInsFal.CodigoAlmacenProduccion;
                iMovCabIngEN.CodigoPersonal = iInsFal.CodigoPersonalProduccion;
                iMovCabIngEN.GlosaSolicitudPedidoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(ref
                    iNumeroSolicitudPedidoCabeIngreso, iMovCabIngEN);
                iMovCabIngEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabIngEN);

                //creamos la lista de SolicitudPedidoDeta de salida transferencia
                List<SolicitudPedidoDetaEN> iLisMovDetIng = new List<SolicitudPedidoDetaEN>();

                //recorrer cada objeto SolicitudPedidoDetaSalida
                foreach (SolicitudPedidoDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetIngEN = new SolicitudPedidoDetaEN();

                    //pasamos datos               
                    iMovDetIngEN.ClaveSolicitudPedidoCabe = iMovCabIngEN.ClaveSolicitudPedidoCabe;
                    iMovDetIngEN.CorrelativoSolicitudPedidoDeta = xMovDetSal.CorrelativoSolicitudPedidoDeta;
                    iMovDetIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetIngEN.FechaSolicitudPedidoCabe = iMovCabIngEN.FechaSolicitudPedidoCabe;
                    iMovDetIngEN.PeriodoSolicitudPedidoCabe = iMovCabIngEN.PeriodoSolicitudPedidoCabe;
                    iMovDetIngEN.CodigoAlmacen = iMovCabIngEN.CodigoAlmacen;
                    iMovDetIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                    iMovDetIngEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetIngEN.CCalculaPrecioPromedio = iTipOpeIngEN.CCalculaPrecioPromedio;
                    iMovDetIngEN.NumeroSolicitudPedidoCabe = iMovCabIngEN.NumeroSolicitudPedidoCabe;
                    iMovDetIngEN.CodigoCentroCosto = string.Empty;
                    iMovDetIngEN.CodigoExistencia = xMovDetSal.CodigoExistencia;
                    iMovDetIngEN.CodigoUnidadMedida = xMovDetSal.CodigoUnidadMedida;
                    iMovDetIngEN.CantidadSolicitudPedidoDeta = xMovDetSal.CantidadSolicitudPedidoDeta;
                    iMovDetIngEN.GlosaSolicitudPedidoDeta = iMovCabIngEN.GlosaSolicitudPedidoCabe;
                    iMovDetIngEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = SolicitudPedidoDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExi);


                    //agregamos a la lista 
                    iLisMovDetIng.Add(iMovDetIngEN);
                }

                //actualizar al SolicitudPedidoCabeSalida con el ultimo dato

                //adicionamos a la lista de SolicitudPedidos Cabe a adicionar
                iLisMovCabAdi.Add(iMovCabSalEN);
                iLisMovCabAdi.Add(iMovCabIngEN);

                //adicionamos a la lista de SolicitudPedidos deta a adicionar
                iLisMovDetAdi.AddRange(iLisMovDetSal);
                iLisMovDetAdi.AddRange(iLisMovDetIng);

                //traer la lista de existencias actualizadas por estos SolicitudPedidos
                List<ExistenciaEN> iLisExiSalMod = SolicitudPedidoDetaRN.ListarExistenciasActualizadasPorAdicionSolicitudPedidosDeta(iLisMovDetSal);
                List<ExistenciaEN> iLisExiIngMod = SolicitudPedidoDetaRN.ListarExistenciasActualizadasPorAdicionSolicitudPedidosDeta(iLisMovDetIng);

                //adicionamos a la lista de existencias a modificar
                iLisExiMod.AddRange(iLisExiSalMod);
                iLisExiMod.AddRange(iLisExiIngMod);
            }

            //grabar en b.d
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iLisMovCabAdi);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
            ExistenciaRN.ModificarExistencia(iLisExiMod);
        }

        public static string ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(ref string pNumeroSolicitudPedidoCabe, SolicitudPedidoCabeEN pObj)
        {
            //valor resultado
            string iNumero = string.Empty;

            //si este valor esta vacio,entonces traemos de la b.d
            if (pNumeroSolicitudPedidoCabe == string.Empty)
            {
                iNumero = ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(pObj);
            }
            else
            {
                iNumero = Numero.IncrementarCorrelativoNumerico(pNumeroSolicitudPedidoCabe, 6);
            }

            //actualizamos al parametro pNumeroSolicitudPedidoCabe
            pNumeroSolicitudPedidoCabe = iNumero;

            //devuelve
            return iNumero;
        }

        public static string ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(SolicitudPedidoCabeEN pObj, List<SolicitudPedidoCabeEN> pLista,
            List<SolicitudPedidoCabeEN> pListaNumerosExcepcion)
        {
            //obtener el nuevo codigo para la lista
            string iNumero = ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(pObj, pLista);

            //recorrer cada objeto
            foreach (SolicitudPedidoCabeEN xMovCab in pListaNumerosExcepcion)
            {
                if (xMovCab.CodigoAlmacen == pObj.CodigoAlmacen &&
                    xMovCab.NumeroSolicitudPedidoCabe == iNumero)
                {
                    //obtener el siguiente codigo
                    iNumero = Numero.IncrementarCorrelativoNumerico(iNumero, 6);
                }
            }

            //devuelve
            return iNumero;
        }

        public static void ImportarIngresosDeExcel(List<SolicitudPedidoDetaEN> pListaSolicitudPedidoDetaExcel)
        {
            //obtener una lista de listas de SolicitudPedidos deta,donde cada uno sera un SolicitudPedido Ingreso
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDet = SolicitudPedidoDetaRN.ListarListasSolicitudPedidosDetaParaImportar(pListaSolicitudPedidoDetaExcel);

            //obtener una lista de SolicitudPedidos deta pero de los auxiliares distintos que hay en la lista pListaSolicitudPedidoDetaExcel
            List<SolicitudPedidoDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<SolicitudPedidoDetaEN>(pListaSolicitudPedidoDetaExcel,
                SolicitudPedidoDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //traer lista de SolicitudPedidos cabe que no se pueden eliminar al importar
            List<SolicitudPedidoCabeEN> iLisMovCabNoImp = ListarSolicitudPedidoCabesNoImportadosIngreso(ListaG.ObtenerPrimerValor<SolicitudPedidoDetaEN>(
                pListaSolicitudPedidoDetaExcel, SolicitudPedidoDetaEN.PerMovCab));

            //listas para adicionar los nuevos objetos
            List<SolicitudPedidoCabeEN> iLisMovCabAdi = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                SolicitudPedidoDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este SolicitudPedido
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo SolicitudPedidoCabe
                SolicitudPedidoCabeEN iMovCabNueEN = new SolicitudPedidoCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoSolicitudPedidoCabe = iMovDetEN.PeriodoSolicitudPedidoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                //iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi, iLisMovCabNoImp);
                iMovCabNueEN.FechaSolicitudPedidoCabe = iMovDetEN.FechaSolicitudPedidoCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iMovDetEN.CodigoAuxiliar;
                iMovCabNueEN.FechaDocumento = iMovDetEN.FechaDocumento;
                iMovCabNueEN.GlosaSolicitudPedidoCabe = iMovDetEN.GlosaSolicitudPedidoDeta;
                iMovCabNueEN.COrigenVentanaCreacion = "5";//Importado excel
                iMovCabNueEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabNueEN);

                //adicionamos a la lista de SolicitudPedidoCabe para adicionar
                iLisMovCabAdi.Add(iMovCabNueEN);

                //buscar al tipo de operacion para este SolicitudPedido
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe,
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los SolicitudPedidosDeta
                string iCorrelativoSolicitudPedidoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (SolicitudPedidoDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoSolicitudPedidoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoSolicitudPedidoDeta);

                    //buscar a la existencia de este SolicitudPedido
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        SolicitudPedidoDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetNueEN = new SolicitudPedidoDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroSolicitudPedidoCabe = iMovCabNueEN.NumeroSolicitudPedidoCabe;
                    iMovDetNueEN.ClaveSolicitudPedidoCabe = iMovCabNueEN.ClaveSolicitudPedidoCabe;
                    iMovDetNueEN.CorrelativoSolicitudPedidoDeta = iCorrelativoSolicitudPedidoDeta;
                    iMovDetNueEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetNueEN);
                    iMovDetNueEN.CodigoEmpresa = iMovCabNueEN.CodigoEmpresa;
                    iMovDetNueEN.FechaSolicitudPedidoCabe = iMovCabNueEN.FechaSolicitudPedidoCabe;
                    iMovDetNueEN.PeriodoSolicitudPedidoCabe = iMovCabNueEN.PeriodoSolicitudPedidoCabe;
                    iMovDetNueEN.CodigoAlmacen = iMovCabNueEN.CodigoAlmacen;
                    //iMovDetNueEN.CodigoTipoOperacion = iMovCabNueEN.CodigoTipoOperacion;
                    iMovDetNueEN.CCalculaPrecioPromedio = iTipOpeEN.CCalculaPrecioPromedio;
                    iMovDetNueEN.CConversionUnidad = iTipOpeEN.CConversionUnidad;
                    iMovDetNueEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetNueEN.CodigoAuxiliar = iMovCabNueEN.CodigoAuxiliar;
                    iMovDetNueEN.FechaDocumento = iMovCabNueEN.FechaDocumento;
                    iMovDetNueEN.CodigoCentroCosto = xMovDet.CodigoCentroCosto;
                    iMovDetNueEN.CodigoExistencia = xMovDet.CodigoExistencia;
                    iMovDetNueEN.CodigoUnidadMedida = iExiBusEN.CodigoUnidadMedida;
                    iMovDetNueEN.CodigoTipo = iExiBusEN.CodigoTipo;
                    iMovDetNueEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetNueEN.CEsUnidadConvertida = iExiBusEN.CEsUnidadConvertida;
                    iMovDetNueEN.FactorConversion = iExiBusEN.FactorConversion;
                              iMovDetNueEN.CantidadConversion = SolicitudPedidoDetaRN.ObtenerCantidadConvertido(iMovDetNueEN,
                        xMovDet.CantidadSolicitudPedidoDeta);
                    iMovDetNueEN.CantidadSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerCantidad(iMovDetNueEN,
                        xMovDet.CantidadSolicitudPedidoDeta);
                    iMovDetNueEN.GlosaSolicitudPedidoDeta = xMovDet.GlosaSolicitudPedidoDeta;

                    //adicionamos a la lista de SolicitudPedidoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            //AuxiliarRN.LlenarListaAdicion(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            string iCodigoPeriodo = ListaG.ObtenerPrimerValor<SolicitudPedidoDetaEN>(pListaSolicitudPedidoDetaExcel, SolicitudPedidoDetaEN.PerMovCab);
            SolicitudPedidoCabeRN.EliminarAntesDeImportarIngreso(iCodigoPeriodo);

            //grabaciones masivas
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iLisMovCabAdi);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static void ImportarIngresosDeExcel1(List<SolicitudPedidoDetaEN> pListaSolicitudPedidoDetaExcel)
        {
            //obtener una lista de listas de SolicitudPedidos deta,donde cada uno sera un SolicitudPedido Ingreso
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDet = SolicitudPedidoDetaRN.ListarListasSolicitudPedidosDetaParaImportar(pListaSolicitudPedidoDetaExcel);

            //obtener una lista de SolicitudPedidos deta pero de los auxiliares distintos que hay en la lista pListaSolicitudPedidoDetaExcel
            List<SolicitudPedidoDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<SolicitudPedidoDetaEN>(pListaSolicitudPedidoDetaExcel,
                SolicitudPedidoDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //listas para adicionar los nuevos objetos
            //List<SolicitudPedidoCabeEN> iLisMovCabAdi = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                SolicitudPedidoDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este SolicitudPedido
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo SolicitudPedidoCabe
                SolicitudPedidoCabeEN iMovCabNueEN = new SolicitudPedidoCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoSolicitudPedidoCabe = iMovDetEN.PeriodoSolicitudPedidoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                //iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iMovCabNueEN);
                iMovCabNueEN.FechaSolicitudPedidoCabe = iMovDetEN.FechaSolicitudPedidoCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iMovDetEN.CodigoAuxiliar;
                iMovCabNueEN.FechaDocumento = iMovDetEN.FechaDocumento;
                iMovCabNueEN.GlosaSolicitudPedidoCabe = iMovDetEN.GlosaSolicitudPedidoDeta;
                iMovCabNueEN.COrigenVentanaCreacion = "9";//Importado excel
                iMovCabNueEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabNueEN);

                //adicionamos a la lista de SolicitudPedidoCabe para adicionar
                //iLisMovCabAdi.Add(iMovCabNueEN);

                //adicionar en b.d
                SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iMovCabNueEN);

                //buscar al tipo de operacion para este SolicitudPedido
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe,
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los SolicitudPedidosDeta
                string iCorrelativoSolicitudPedidoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (SolicitudPedidoDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoSolicitudPedidoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoSolicitudPedidoDeta);

                    //buscar a la existencia de este SolicitudPedido
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        SolicitudPedidoDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetNueEN = new SolicitudPedidoDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroSolicitudPedidoCabe = iMovCabNueEN.NumeroSolicitudPedidoCabe;
                    iMovDetNueEN.ClaveSolicitudPedidoCabe = iMovCabNueEN.ClaveSolicitudPedidoCabe;
                    iMovDetNueEN.CorrelativoSolicitudPedidoDeta = iCorrelativoSolicitudPedidoDeta;
                    iMovDetNueEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetNueEN);
                    iMovDetNueEN.CodigoEmpresa = iMovCabNueEN.CodigoEmpresa;
                    iMovDetNueEN.FechaSolicitudPedidoCabe = iMovCabNueEN.FechaSolicitudPedidoCabe;
                    iMovDetNueEN.PeriodoSolicitudPedidoCabe = iMovCabNueEN.PeriodoSolicitudPedidoCabe;
                    iMovDetNueEN.CodigoAlmacen = iMovCabNueEN.CodigoAlmacen;
                    //iMovDetNueEN.CodigoTipoOperacion = iMovCabNueEN.CodigoTipoOperacion;
                    iMovDetNueEN.CCalculaPrecioPromedio = iTipOpeEN.CCalculaPrecioPromedio;
                    iMovDetNueEN.CConversionUnidad = iTipOpeEN.CConversionUnidad;
                    iMovDetNueEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetNueEN.CodigoAuxiliar = iMovCabNueEN.CodigoAuxiliar;
                    iMovDetNueEN.FechaDocumento = iMovCabNueEN.FechaDocumento;
                    iMovDetNueEN.CodigoCentroCosto = xMovDet.CodigoCentroCosto;
                    iMovDetNueEN.CodigoExistencia = xMovDet.CodigoExistencia;
                    iMovDetNueEN.CodigoUnidadMedida = iExiBusEN.CodigoUnidadMedida;
                    iMovDetNueEN.CodigoTipo = iExiBusEN.CodigoTipo;
                    iMovDetNueEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetNueEN.CEsUnidadConvertida = iExiBusEN.CEsUnidadConvertida;
                    iMovDetNueEN.FactorConversion = iExiBusEN.FactorConversion;
                     iMovDetNueEN.CantidadConversion = SolicitudPedidoDetaRN.ObtenerCantidadConvertido(iMovDetNueEN,
                        xMovDet.CantidadSolicitudPedidoDeta);
                    iMovDetNueEN.CantidadSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerCantidad(iMovDetNueEN,
                        xMovDet.CantidadSolicitudPedidoDeta);
                    iMovDetNueEN.GlosaSolicitudPedidoDeta = xMovDet.GlosaSolicitudPedidoDeta;

                    //adicionamos a la lista de SolicitudPedidoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            //AuxiliarRN.LlenarListaAdicion(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);

            //grabaciones masivas
            //SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iLisMovCabAdi);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static SolicitudPedidoCabeEN EsActoEliminarImportacionSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando no hay auxiliares importados
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoHaySolicitudPedidoCabesImportados(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //ok            
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN EsActoEliminarImportacionSolicitudPedidoCabeIngreso(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando no hay auxiliares importados
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoHaySolicitudPedidoCabesImportadosIngresos(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //ok            
            return iSolPedidoCabEN;
        }

        public static SolicitudPedidoCabeEN EsActoEliminarImportacionSolicitudPedidoCabeSalida(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //valida cuando es no es acto eliminar en este periodo
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoEsActoRegistrarEnPeriodo(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //valida cuando no hay auxiliares importados
            iSolPedidoCabEN = SolicitudPedidoCabeRN.ValidaCuandoNoHaySolicitudPedidoCabesImportadosSalidas(pObj);
            if (iSolPedidoCabEN.Adicionales.EsVerdad == false) { return iSolPedidoCabEN; }

            //ok            
            return iSolPedidoCabEN;
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesImportados(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesImportados(pObj);
        }

        public static SolicitudPedidoCabeEN ValidaCuandoNoHaySolicitudPedidoCabesImportados(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iAuxEN = new SolicitudPedidoCabeEN();

            //validar
            pObj.Adicionales.CampoOrden = SolicitudPedidoCabeEN.ClaMovCab;
            List<SolicitudPedidoCabeEN> iLisAuxImp = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay SolicitudPedidos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static SolicitudPedidoCabeEN ValidaCuandoNoHaySolicitudPedidoCabesImportadosIngresos(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iAuxEN = new SolicitudPedidoCabeEN();

            //validar
            //pObj.CClaseTipoOperacion = "1";//ingreso
            pObj.Adicionales.CampoOrden = SolicitudPedidoCabeEN.ClaMovCab;
            List<SolicitudPedidoCabeEN> iLisAuxImp = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay SolicitudPedidos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static SolicitudPedidoCabeEN ValidaCuandoNoHaySolicitudPedidoCabesImportadosSalidas(SolicitudPedidoCabeEN pObj)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iAuxEN = new SolicitudPedidoCabeEN();

            //validar
            //pObj.CClaseTipoOperacion = "2";//salida
            pObj.Adicionales.CampoOrden = SolicitudPedidoCabeEN.ClaMovCab;
            List<SolicitudPedidoCabeEN> iLisAuxImp = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesImportados(pObj);
            if (iLisAuxImp.Count == 0)
            {
                iAuxEN.Adicionales.EsVerdad = false;
                iAuxEN.Adicionales.Mensaje = "No hay SolicitudPedidos importados en este periodo";
                return iAuxEN;
            }

            //ok
            return iAuxEN;
        }

        public static void GenerarSolicitudPedidoSalidaMasaYEnvasadoPorMigracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe)
        {
            //objeto cabe
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //pasar datos
            iSolPedidoCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSolPedidoCabEN.FechaSolicitudPedidoCabe = pObj.FechaProduccionDeta;
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iSolPedidoCabEN.FechaSolicitudPedidoCabe, "-");
            //iSolPedidoCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iSolPedidoCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iSolPedidoCabEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iSolPedidoCabEN.CodigoPersonal = string.Empty;
            iSolPedidoCabEN.GlosaSolicitudPedidoCabe = "MIGRACION FASE MASA Y ENVASADO 2019";
            iSolPedidoCabEN.COrigenVentanaCreacion = "4";//produccion   
            iSolPedidoCabEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iSolPedidoCabEN);
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iSolPedidoCabEN);

            //grabar SolicitudPedido cabe
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iSolPedidoCabEN);

            //lista SolicitudPedidos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iProExiEN.CTipoDescarga = "'0','1'";//fase masa y control calidad
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(iProExiEN);

            //grabar SolicitudPedidos deta
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDetaPorSalidaInsumos(iLisProExi, iSolPedidoCabEN);

            //listar al SolicitudPedidodeta
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaPorClaveSolicitudPedidoCabe(iSolPedidoCabEN.ClaveSolicitudPedidoCabe);

            //actualizar existencias por adicion de SolicitudPedido
            //ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //actualizar los precios unitarios                    
            ProduccionExisRN.ActualizarPreciosUnitariosDesdeExistencias(iLisProExi);

            //modificar produccionDeta
            pObj.FechaSalidaFaseMasa = pObj.FechaProduccionDeta;
            pObj.ClaveSalidaFaseMasa = iSolPedidoCabEN.ClaveSolicitudPedidoCabe;
            ProduccionDetaRN.ModificarPorSalidaInsumosFaseMasa(pObj);
        }

        public static void GenerarSolicitudPedidoIngresoUnidadesSelladasPorMigracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar a la produccion en bd
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj);

            //objeto cabe
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //pasar datos
            iSolPedidoCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSolPedidoCabEN.FechaSolicitudPedidoCabe = iProDetEN.FechaProduccionDeta;
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iSolPedidoCabEN.FechaSolicitudPedidoCabe, "-");
            //iSolPedidoCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iSolPedidoCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iSolPedidoCabEN.CodigoAlmacen = iProDetEN.CodigoAlmacenSemiProducto;
            iSolPedidoCabEN.CodigoPersonal = string.Empty;
            iSolPedidoCabEN.GlosaSolicitudPedidoCabe = "MIGRACION INGRESO UNIDADES SELLADAS 2019";
            iSolPedidoCabEN.COrigenVentanaCreacion = "4";//produccion   
            iSolPedidoCabEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iSolPedidoCabEN);
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iSolPedidoCabEN);

            //grabar SolicitudPedido cabe
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iSolPedidoCabEN);

            //lista SolicitudPedidos deta                      
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidoDetaParaIngresoSemiElaborado(iProDetEN, iSolPedidoCabEN);

            //grabar SolicitudPedidos deta
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDet);

            //actualizar existencias por adicion de SolicitudPedido
            //ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //modificar produccionDeta           
            iProDetEN.ClaveIngresoSemiElaborado = iSolPedidoCabEN.ClaveSolicitudPedidoCabe;
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void GenerarSolicitudPedidoSalidaUnidadesAEmpaquetarPorMigracion(EncajadoEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar al encajado en bd
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //objeto cabe
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //pasar datos
            iSolPedidoCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSolPedidoCabEN.FechaSolicitudPedidoCabe = iEncEN.FechaEncajado;
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iSolPedidoCabEN.FechaSolicitudPedidoCabe, "-");
            //iSolPedidoCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iSolPedidoCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iSolPedidoCabEN.CodigoAlmacen = "A11";
            iSolPedidoCabEN.CodigoPersonal = string.Empty;
            iSolPedidoCabEN.GlosaSolicitudPedidoCabe = "MIGRACION SALIDA UNIDADES A EMPAQUETAR 2019";
            iSolPedidoCabEN.COrigenVentanaCreacion = "4";//produccion   
            iSolPedidoCabEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iSolPedidoCabEN);
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iSolPedidoCabEN);

            //grabar SolicitudPedido cabe
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iSolPedidoCabEN);

            //lista SolicitudPedidos deta           
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidoDetaParaSalidaEmpaquetar(iEncEN, iSolPedidoCabEN);

            //grabar SolicitudPedidos deta
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDet);

            //actualizar existencias por adicion de SolicitudPedido
            //ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //actualizar el costo insumo de semi productos
            //ProduccionProTerRN.ModificarCostoInsumoSemiProducto(iEncEN, iLisMovDet);

            //descontar producciones deta
            //ProduccionDetaRN.DescontarUnidadesPorEmpaquetado(iLisMovDet);

            //modificar Encajado           
            iEncEN.ClaveSalidaUnidadesEmpacar = iSolPedidoCabEN.ClaveSolicitudPedidoCabe;
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void GenerarSolicitudPedidoSalidaUnidadesNoPasanPorMigracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe)
        {
            //si no hay unidades desechas, entonces termina el proceso
            if (pObj.NumeroUnidadesNoPasanConCal == 0) { return; }

            //buscar a la produccion en bd
            ProduccionDetaEN iProDetEN = ProduccionDetaRN.BuscarProduccionDetaXClave(pObj);

            //objeto cabe
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //pasar datos
            iSolPedidoCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSolPedidoCabEN.FechaSolicitudPedidoCabe = iProDetEN.FechaProduccionDeta;
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iSolPedidoCabEN.FechaSolicitudPedidoCabe, "-");
            //iSolPedidoCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iSolPedidoCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iSolPedidoCabEN.CodigoAlmacen = iProDetEN.CodigoAlmacenSemiProducto;
            iSolPedidoCabEN.CodigoPersonal = string.Empty;
            iSolPedidoCabEN.GlosaSolicitudPedidoCabe = "MIGRACION SALIDA UNIDADES DESECHAS 2019";
            iSolPedidoCabEN.COrigenVentanaCreacion = "4";//produccion   
            iSolPedidoCabEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iSolPedidoCabEN);
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iSolPedidoCabEN);

            //grabar SolicitudPedido cabe
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iSolPedidoCabEN);

            //lista SolicitudPedidos deta           
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidoDetaParaSalidaNoPasan(iProDetEN, iSolPedidoCabEN);

            //grabar SolicitudPedidos deta
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDet);

            //actualizar existencias por adicion de SolicitudPedido
            //ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //modificar produccionDeta           
            iProDetEN.ClaveSalidaNoPasan = iSolPedidoCabEN.ClaveSolicitudPedidoCabe;
            ProduccionDetaRN.ModificarProduccionDeta(iProDetEN);
        }

        public static void GenerarSolicitudPedidoSalidaEmpaquetadoPorMigracion(EncajadoEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar al encajado en bd
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //objeto cabe
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //pasar datos
            iSolPedidoCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSolPedidoCabEN.FechaSolicitudPedidoCabe = iEncEN.FechaEncajado;
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iSolPedidoCabEN.FechaSolicitudPedidoCabe, "-");
            //iSolPedidoCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iSolPedidoCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iSolPedidoCabEN.CodigoAlmacen = "A09";
            iSolPedidoCabEN.CodigoPersonal = string.Empty;
            iSolPedidoCabEN.GlosaSolicitudPedidoCabe = "MIGRACION FASE EMPAQUETADO 2019";
            iSolPedidoCabEN.COrigenVentanaCreacion = "4";//produccion   
            iSolPedidoCabEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iSolPedidoCabEN);
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iSolPedidoCabEN);

            //grabar SolicitudPedido cabe
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iSolPedidoCabEN);

            //lista SolicitudPedidos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveEncajado = iEncEN.ClaveEncajado;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisAcumuladoXClaveEncajado(iProExiEN);

            //grabar SolicitudPedidos deta
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDetaPorSalidaInsumos(iLisProExi, iSolPedidoCabEN);

            //listar al SolicitudPedidodeta
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaPorClaveSolicitudPedidoCabe(iSolPedidoCabEN.ClaveSolicitudPedidoCabe);

            //actualizar existencias por adicion de SolicitudPedido
            //ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //actualizar los costos de empaquetado
            ProduccionExisRN.ActualizarPreciosUnitariosDesdeExistencias(iLisProExi);

            //modificar encajado
            iEncEN.ClaveSalidaFaseEmpaquetado = iSolPedidoCabEN.ClaveSolicitudPedidoCabe;
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void GenerarSolicitudPedidoIngresoProductoTerminadoPorMigracion(EncajadoEN pObj, TipoOperacionEN pTipOpe)
        {
            //buscar al encajado en bd
            EncajadoEN iEncEN = EncajadoRN.BuscarEncajadoXClave(pObj);

            //objeto cabe
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //pasar datos
            iSolPedidoCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSolPedidoCabEN.FechaSolicitudPedidoCabe = iEncEN.FechaEncajado;
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iSolPedidoCabEN.FechaSolicitudPedidoCabe, "-");
            //iSolPedidoCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iSolPedidoCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iSolPedidoCabEN.CodigoAlmacen = "A13";
            iSolPedidoCabEN.CodigoPersonal = string.Empty;
            iSolPedidoCabEN.GlosaSolicitudPedidoCabe = "MIGRACION INGRESO PRODUCTO TERMINADO 2019";
            iSolPedidoCabEN.COrigenVentanaCreacion = "4";//produccion   
            iSolPedidoCabEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iSolPedidoCabEN);
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iSolPedidoCabEN);

            //grabar SolicitudPedido cabe
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iSolPedidoCabEN);

            //lista SolicitudPedidos deta           
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidoDetaParaIngresoMercaderia(iEncEN, iSolPedidoCabEN);

            //grabar SolicitudPedidos deta
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDet);

            //actualizar existencias por adicion de SolicitudPedido
            //ExistenciaRN.ActualizarExistenciasPorAdicionMovimientosDeta(iLisMovDet);

            //modificar encajado    
            iEncEN.ClaveIngresoProductoTerminado = iSolPedidoCabEN.ClaveSolicitudPedidoCabe;
            EncajadoRN.ModificarEncajado(iEncEN);
        }

        public static void ImportarSalidasDeExcel(List<SolicitudPedidoDetaEN> pListaSolicitudPedidoDetaExcel)
        {
            //obtener una lista de listas de SolicitudPedidos deta,donde cada uno sera un SolicitudPedido Salida
            List<List<SolicitudPedidoDetaEN>> iLisLisMovDet = SolicitudPedidoDetaRN.ListarListasSolicitudPedidosDetaParaImportar(pListaSolicitudPedidoDetaExcel);

            //obtener una lista de SolicitudPedidos deta pero de los auxiliares distintos que hay en la lista pListaSolicitudPedidoDetaExcel
            List<SolicitudPedidoDetaEN> iLisMovDetAux = ListaG.FiltrarObjetosSinRepetir<SolicitudPedidoDetaEN>(pListaSolicitudPedidoDetaExcel,
                SolicitudPedidoDetaEN.CodAux);

            //traer a los auxiliares de la empresa actual
            List<AuxiliarEN> iLisAuxEmp = AuxiliarRN.ListarAuxiliares();

            //traer a todos los almacenes de la empresa
            List<AlmacenEN> iLisAlm = AlmacenRN.ListarAlmacenes();

            //traer a todas las existencias de la empresa actual
            List<ExistenciaEN> iLisExiEmp = ExistenciaRN.ListarExistencias();

            //traer a todos los tipos de operaciones
            List<TipoOperacionEN> iLisTipOpe = TipoOperacionRN.ListarTipoOperaciones();

            //traer lista de SolicitudPedidos cabe que no se pueden eliminar al importar
            List<SolicitudPedidoCabeEN> iLisMovCabNoImp = ListarSolicitudPedidoCabesNoImportadosSalida(ListaG.ObtenerPrimerValor<SolicitudPedidoDetaEN>(
                pListaSolicitudPedidoDetaExcel, SolicitudPedidoDetaEN.PerMovCab));

            //listas para adicionar los nuevos objetos
            List<SolicitudPedidoCabeEN> iLisMovCabAdi = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<AuxiliarEN> iLisAuxAdi = new List<AuxiliarEN>();

            //recorrer cada lista
            foreach (List<SolicitudPedidoDetaEN> xLisMovDet in iLisLisMovDet)
            {
                //obtener al primer objeto de la lista
                SolicitudPedidoDetaEN iMovDetEN = xLisMovDet[0];

                //obtener al objeto almacen para este SolicitudPedido
                AlmacenEN iAlmEN = AlmacenRN.BuscarAlmacen(AlmacenEN.CodAlm, iMovDetEN.CodigoAlmacen, iLisAlm);

                //creamos un nuevo SolicitudPedidoCabe
                SolicitudPedidoCabeEN iMovCabNueEN = new SolicitudPedidoCabeEN();

                //actualizando sus datos
                iMovCabNueEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabNueEN.PeriodoSolicitudPedidoCabe = iMovDetEN.PeriodoSolicitudPedidoCabe;
                iMovCabNueEN.CodigoAlmacen = iMovDetEN.CodigoAlmacen;
                //iMovCabNueEN.CodigoTipoOperacion = iMovDetEN.CodigoTipoOperacion;
                iMovCabNueEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iMovCabNueEN, iLisMovCabAdi, iLisMovCabNoImp);
                iMovCabNueEN.FechaSolicitudPedidoCabe = iMovDetEN.FechaSolicitudPedidoCabe;
                iMovCabNueEN.CodigoPersonal = iAlmEN.CodigoPersonal;
                iMovCabNueEN.CodigoAuxiliar = iMovDetEN.CodigoAuxiliar;
                iMovCabNueEN.FechaDocumento = iMovDetEN.FechaDocumento;
                iMovCabNueEN.GlosaSolicitudPedidoCabe = iMovDetEN.GlosaSolicitudPedidoDeta;
                iMovCabNueEN.COrigenVentanaCreacion = "5";//Importado excel
                iMovCabNueEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabNueEN);

                //adicionamos a la lista de SolicitudPedidoCabe para adicionar
                iLisMovCabAdi.Add(iMovCabNueEN);

                //buscar al tipo de operacion para este SolicitudPedido
                TipoOperacionEN iTipOpeEN = ListaG.Buscar<TipoOperacionEN>(iLisTipOpe, TipoOperacionEN.CodTipOpe,
                    iMovDetEN.CodigoTipoOperacion);

                //correlativo para los SolicitudPedidosDeta
                string iCorrelativoSolicitudPedidoDeta = "0000";

                //recorrer cada RegContabDeta
                foreach (SolicitudPedidoDetaEN xMovDet in xLisMovDet)
                {
                    //incrementar el correlativo
                    iCorrelativoSolicitudPedidoDeta = Numero.IncrementarCorrelativoNumerico(iCorrelativoSolicitudPedidoDeta);

                    //buscar a la existencia de este SolicitudPedido
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExiEmp, ExistenciaEN.ClaExi,
                        SolicitudPedidoDetaRN.ObtenerClaveExistencia(xMovDet));

                    //creamos un nuevo objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetNueEN = new SolicitudPedidoDetaEN();

                    //actualizando sus datos
                    iMovDetNueEN.NumeroSolicitudPedidoCabe = iMovCabNueEN.NumeroSolicitudPedidoCabe;
                    iMovDetNueEN.ClaveSolicitudPedidoCabe = iMovCabNueEN.ClaveSolicitudPedidoCabe;
                    iMovDetNueEN.CorrelativoSolicitudPedidoDeta = iCorrelativoSolicitudPedidoDeta;
                    iMovDetNueEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetNueEN);
                    iMovDetNueEN.CodigoEmpresa = iMovCabNueEN.CodigoEmpresa;
                    iMovDetNueEN.FechaSolicitudPedidoCabe = iMovCabNueEN.FechaSolicitudPedidoCabe;
                    iMovDetNueEN.PeriodoSolicitudPedidoCabe = iMovCabNueEN.PeriodoSolicitudPedidoCabe;
                    iMovDetNueEN.CodigoAlmacen = iMovCabNueEN.CodigoAlmacen;
                    //iMovDetNueEN.CodigoTipoOperacion = iMovCabNueEN.CodigoTipoOperacion;
                    iMovDetNueEN.CCalculaPrecioPromedio = iTipOpeEN.CCalculaPrecioPromedio;
                    iMovDetNueEN.CConversionUnidad = iTipOpeEN.CConversionUnidad;
                    iMovDetNueEN.CClaseTipoOperacion = "2";//salida
                    iMovDetNueEN.CodigoAuxiliar = iMovCabNueEN.CodigoAuxiliar;
                    iMovDetNueEN.FechaDocumento = iMovCabNueEN.FechaDocumento;
                    iMovDetNueEN.CodigoCentroCosto = xMovDet.CodigoCentroCosto;
                    iMovDetNueEN.CodigoExistencia = xMovDet.CodigoExistencia;
                    iMovDetNueEN.CodigoUnidadMedida = iExiBusEN.CodigoUnidadMedida;
                    iMovDetNueEN.CodigoTipo = iExiBusEN.CodigoTipo;
                    iMovDetNueEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetNueEN.CEsUnidadConvertida = iExiBusEN.CEsUnidadConvertida;
                    iMovDetNueEN.FactorConversion = iExiBusEN.FactorConversion;
                    iMovDetNueEN.CantidadSolicitudPedidoDeta = xMovDet.CantidadSolicitudPedidoDeta;
                    iMovDetNueEN.GlosaSolicitudPedidoDeta = xMovDet.GlosaSolicitudPedidoDeta;

                    //adicionamos a la lista de SolicitudPedidoDeta para adicionar
                    iLisMovDetAdi.Add(iMovDetNueEN);
                }
            }

            //cargamos a los nuevos auxiliares y tambien a los auxiliares que se van a modificar su CTipoAuxiliar
            //AuxiliarRN.LlenarListaAdicion(iLisAuxAdi, iLisAuxEmp, iLisMovDetAux);

            //eliminamos a los anteriores importaciones que se hayan hecho en este periodo
            string iCodigoPeriodo = ListaG.ObtenerPrimerValor<SolicitudPedidoDetaEN>(pListaSolicitudPedidoDetaExcel, SolicitudPedidoDetaEN.PerMovCab);
            SolicitudPedidoCabeRN.EliminarAntesDeImportarSalida(iCodigoPeriodo);

            //grabaciones masivas
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iLisMovCabAdi);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
            AuxiliarRN.AdicionarAuxiliar(iLisAuxAdi);
        }

        public static void RegenerarSolicitudPedidosTransferenciaYFaseMasa()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //eliminar los SolicitudPedidos de transferencia de ingreso y salida al almacen de produccion
            SolicitudPedidoCabeRN.EliminarAntesDeRegenerar(iPeriodo);

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
                //traer una lista de listas de SolicitudPedidos deta hasta el dia de las producciones deta
                List<List<SolicitudPedidoDetaEN>> iLisLisMovDetDia = SolicitudPedidoDetaRN.ListaListasSolicitudPedidosDetaPorFechaMenorOIgualQue(iPeriodo,
                    xLisProDet[0].FechaProduccionDeta);

                //recalcular(actualiza a la lista existencia con su nuevo saldo y precio promedio)
                SolicitudPedidoDetaRN.Recalcular(iAño, iCodigoMes, iLisExiEmp, iLisSalAño, iLisLisMovDetDia);

                //listar los insumos para transferir
                List<InsumoFaltante> iLisInsFal = ProduccionExisRN.ListarInsumosParaTransferirAProducccion(xLisProDet, iLisExiEmp);

                //generar las transferencias
                SolicitudPedidoCabeRN.GenerarTransferenciasAutomaticasAProduccion(iLisInsFal, iLisExiEmp);

                //modificar por transferencias automatocas
                ProduccionDetaRN.ModificarPorTransferenciaAutomatica(xLisProDet);

                //generar los SolicitudPedidos de salida fase masa y envasado               
                //recorrer cada objeto produccionDeta
                foreach (ProduccionDetaEN xProDet in xLisProDet)
                {
                    //generar la salida de masa y envasado
                    SolicitudPedidoCabeRN.GenerarSolicitudPedidoSalidaMasaYEnvasadoPorRegeneracion(xProDet, iTipOpeSalEN, iLisExiEmp);
                }


            }

        }

        public static void EliminarAntesDeRegenerar(string pCodigoPeriodo)
        {
            SolicitudPedidoDetaRN.EliminarSolicitudPedidosDetaAlmacenProduccionParaRegenerar(pCodigoPeriodo);
            SolicitudPedidoCabeRN.EliminarSolicitudPedidosCabeAlmacenProduccionParaRegenerar(pCodigoPeriodo);
            SolicitudPedidoDetaRN.EliminarSolicitudPedidosDetaAlmacenesCompraParaRegenerar(pCodigoPeriodo);
            SolicitudPedidoCabeRN.EliminarSolicitudPedidosCabeAlmacenesCompraParaRegenerar(pCodigoPeriodo);
            ProduccionDetaRN.ModificarProduccionDetaParaRegenerar(pCodigoPeriodo);
        }

        public static void EliminarSolicitudPedidoCabeXPeriodoYAlmacen(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.EliminarSolicitudPedidoCabeXPeriodoYAlmacen(pObj);
        }

        public static void EliminarSolicitudPedidosCabeAlmacenProduccionParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            iSolPedidoCabEN.CodigoAlmacen = "A10";//almacen de produccion

            //ejecutar metodo
            SolicitudPedidoCabeRN.EliminarSolicitudPedidoCabeXPeriodoYAlmacen(iSolPedidoCabEN);
        }

        public static void EliminarSolicitudPedidoCabeAlmacenesCompraParaRegenerar(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.EliminarSolicitudPedidoCabeAlmacenesCompraParaRegenerar(pObj);
        }

        public static void EliminarSolicitudPedidosCabeAlmacenesCompraParaRegenerar(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iMovDetEN = new SolicitudPedidoCabeEN();
            iMovDetEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;

            //ejecutar metodo
            SolicitudPedidoCabeRN.EliminarSolicitudPedidoCabeAlmacenesCompraParaRegenerar(iMovDetEN);
        }

        public static void AprobarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.AprobarSolicitudPedidoCabe(pObj);
        }

        public static void DesaprobarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.DesaprobarSolicitudPedidoCabe(pObj);
        }

        public static void CerrarSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.CerrarSolicitudPedidoCabe(pObj);
        }

        public static void EnviadoSolicitudPedidoCabe(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            iPerAD.EnviadoSolicitudPedidoCabe(pObj);
        }

        public static void GenerarTransferenciasAutomaticasAProduccion(List<InsumoFaltante> pLisInsTra, List<ExistenciaEN> pLisExi)
        {
            //separar en listas los insumos por almacen
            List<List<InsumoFaltante>> iLisLisInsTraAlm = ListaG.ListarListas<InsumoFaltante>(pLisInsTra, InsumoFaltante.CodAlm);

            //obtener la fecha para estos SolicitudPedidos de transferencia(este dato sale de la fecha de produccion de estos insumos)
            string iFechaSolicitudPedidoCabe = ListaG.ObtenerPrimerValor<InsumoFaltante>(pLisInsTra, InsumoFaltante.FecPro);

            //traemos al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeSalEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaSalida);

            //traemos al tipo de operacion de transferencia ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaIngreso);

            //listas para adicionar y modificar en b.d
            List<SolicitudPedidoCabeEN> iLisMovCabAdi = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero SolicitudPedido para el ingreso
            string iNumeroSolicitudPedidoCabeIngreso = string.Empty;

            //recorrer cada lista
            foreach (List<InsumoFaltante> xLisInsFal in iLisLisInsTraAlm)
            {
                //obtener al primer objeto de la lista
                InsumoFaltante iInsFal = xLisInsFal[0];

                //creamos el objeto SolicitudPedidoCabe de salida transferencia
                SolicitudPedidoCabeEN iMovCabSalEN = new SolicitudPedidoCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaSolicitudPedidoCabe = iFechaSolicitudPedidoCabe;
                iMovCabSalEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iFechaSolicitudPedidoCabe, "-");
                //iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iInsFal.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iInsFal.CodigoPersonal;
                iMovCabSalEN.GlosaSolicitudPedidoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iMovCabSalEN);
                iMovCabSalEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabSalEN);

                //creamos la lista de SolicitudPedidoDeta de salida transferencia
                List<SolicitudPedidoDetaEN> iLisMovDetSal = new List<SolicitudPedidoDetaEN>();

                //variable para los correlativos de cada SolicitudPedidoDeta
                string iCorrelativoSolicitudPedidoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (InsumoFaltante xInsFal in xLisInsFal)
                {
                    //buscar a la existencia para este xInsFal
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(pLisExi, ExistenciaEN.CodAlm, xInsFal.CodigoAlmacen,
                        ExistenciaEN.CodExi, xInsFal.CodigoExistencia);

                    //creamos un objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetSalEN = new SolicitudPedidoDetaEN();

                    //pasar datos
                    iMovDetSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetSalEN.FechaSolicitudPedidoCabe = iMovCabSalEN.FechaSolicitudPedidoCabe;
                    iMovDetSalEN.PeriodoSolicitudPedidoCabe = iMovCabSalEN.PeriodoSolicitudPedidoCabe;
                    iMovDetSalEN.CodigoAlmacen = iMovCabSalEN.CodigoAlmacen;
                    //iMovDetSalEN.CodigoTipoOperacion = iMovCabSalEN.CodigoTipoOperacion;
                    iMovDetSalEN.CCalculaPrecioPromedio = iTipOpeSalEN.CCalculaPrecioPromedio;
                    iMovDetSalEN.CClaseTipoOperacion = "2";//salida
                    iMovDetSalEN.NumeroSolicitudPedidoCabe = iMovCabSalEN.NumeroSolicitudPedidoCabe;
                    iMovDetSalEN.CodigoCentroCosto = string.Empty;
                    iMovDetSalEN.DescripcionCentroCosto = string.Empty;
                    iMovDetSalEN.CodigoExistencia = xInsFal.CodigoExistencia;
                    iMovDetSalEN.DescripcionExistencia = xInsFal.DescripcionExistencia;
                    iMovDetSalEN.CodigoUnidadMedida = xInsFal.CUnidadMedida;
                    iMovDetSalEN.NombreUnidadMedida = xInsFal.NUnidadMedida;
                    iMovDetSalEN.CantidadSolicitudPedidoDeta = xInsFal.CantidadFaltante;
                    iMovDetSalEN.GlosaSolicitudPedidoDeta = iMovCabSalEN.GlosaSolicitudPedidoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveSolicitudPedidoCabe = iMovCabSalEN.ClaveSolicitudPedidoCabe;
                    iMovDetSalEN.CorrelativoSolicitudPedidoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoSolicitudPedidoDeta);
                    iMovDetSalEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetSalEN);

                    //adicionar a la lista de SolicitudPedidoDeta de este SolicitudPedidoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //creamos el objeto SolicitudPedidoCabe de ingreso transferencia
                SolicitudPedidoCabeEN iMovCabIngEN = new SolicitudPedidoCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaSolicitudPedidoCabe = iFechaSolicitudPedidoCabe;
                iMovCabIngEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iFechaSolicitudPedidoCabe, "-");
                //iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iInsFal.CodigoAlmacenProduccion;
                iMovCabIngEN.CodigoPersonal = iInsFal.CodigoPersonalProduccion;
                iMovCabIngEN.GlosaSolicitudPedidoCabe = "TRANSFERENCIA AUTOMATICA A PRODUCCION";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(ref
                    iNumeroSolicitudPedidoCabeIngreso, iMovCabIngEN);
                iMovCabIngEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabIngEN);

                //creamos la lista de SolicitudPedidoDeta de salida transferencia
                List<SolicitudPedidoDetaEN> iLisMovDetIng = new List<SolicitudPedidoDetaEN>();

                //recorrer cada objeto SolicitudPedidoDetaSalida
                foreach (SolicitudPedidoDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetIngEN = new SolicitudPedidoDetaEN();

                    //pasamos datos               
                    iMovDetIngEN.ClaveSolicitudPedidoCabe = iMovCabIngEN.ClaveSolicitudPedidoCabe;
                    iMovDetIngEN.CorrelativoSolicitudPedidoDeta = xMovDetSal.CorrelativoSolicitudPedidoDeta;
                    iMovDetIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetIngEN.FechaSolicitudPedidoCabe = iMovCabIngEN.FechaSolicitudPedidoCabe;
                    iMovDetIngEN.PeriodoSolicitudPedidoCabe = iMovCabIngEN.PeriodoSolicitudPedidoCabe;
                    iMovDetIngEN.CodigoAlmacen = iMovCabIngEN.CodigoAlmacen;
                    //iMovDetIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                    iMovDetIngEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetIngEN.CCalculaPrecioPromedio = iTipOpeIngEN.CCalculaPrecioPromedio;
                    iMovDetIngEN.NumeroSolicitudPedidoCabe = iMovCabIngEN.NumeroSolicitudPedidoCabe;
                    iMovDetIngEN.CodigoCentroCosto = string.Empty;
                    iMovDetIngEN.CodigoExistencia = xMovDetSal.CodigoExistencia;
                    iMovDetIngEN.CodigoUnidadMedida = xMovDetSal.CodigoUnidadMedida;
                    iMovDetIngEN.CantidadSolicitudPedidoDeta = xMovDetSal.CantidadSolicitudPedidoDeta;
                    iMovDetIngEN.GlosaSolicitudPedidoDeta = iMovCabIngEN.GlosaSolicitudPedidoCabe;
                    iMovDetIngEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = SolicitudPedidoDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, pLisExi);

                    //actualizar los datos anteriores de la existencia en el SolicitudPedidoDeta

                    //actualizar calculos

                    //agregamos a la lista 
                    iLisMovDetIng.Add(iMovDetIngEN);
                }

                //actualizar al SolicitudPedidoCabeSalida con el ultimo dato

                //adicionamos a la lista de SolicitudPedidos Cabe a adicionar
                iLisMovCabAdi.Add(iMovCabSalEN);
                iLisMovCabAdi.Add(iMovCabIngEN);

                //adicionamos a la lista de SolicitudPedidos deta a adicionar
                iLisMovDetAdi.AddRange(iLisMovDetSal);
                iLisMovDetAdi.AddRange(iLisMovDetIng);

                //traer la lista de existencias actualizadas por estos SolicitudPedidos
                SolicitudPedidoDetaRN.ExistenciasActualizadasPorAdicionSolicitudPedidosDeta(iLisMovDetSal, pLisExi);
                SolicitudPedidoDetaRN.ExistenciasActualizadasPorAdicionSolicitudPedidosDeta(iLisMovDetIng, pLisExi);
            }

            //grabar en b.d
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iLisMovCabAdi);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
        }

        public static void GenerarSolicitudPedidoSalidaMasaYEnvasadoPorRegeneracion(ProduccionDetaEN pObj, TipoOperacionEN pTipOpe, List<ExistenciaEN> pLisExi)
        {
            //objeto cabe
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //pasar datos
            iSolPedidoCabEN.CodigoEmpresa = Universal.gCodigoEmpresa;
            iSolPedidoCabEN.FechaSolicitudPedidoCabe = pObj.FechaProduccionDeta;
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iSolPedidoCabEN.FechaSolicitudPedidoCabe, "-");
            //iSolPedidoCabEN.CodigoTipoOperacion = pTipOpe.CodigoTipoOperacion;
            iSolPedidoCabEN.CCalculaPrecioPromedio = pTipOpe.CCalculaPrecioPromedio;
            iSolPedidoCabEN.CodigoAlmacen = pObj.CodigoAlmacen;
            iSolPedidoCabEN.CodigoPersonal = string.Empty;
            iSolPedidoCabEN.GlosaSolicitudPedidoCabe = string.Empty;
            iSolPedidoCabEN.COrigenVentanaCreacion = "4";//produccion   
            iSolPedidoCabEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iSolPedidoCabEN);
            iSolPedidoCabEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iSolPedidoCabEN);

            //grabar SolicitudPedido cabe
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iSolPedidoCabEN);

            //lista SolicitudPedidos deta
            ProduccionExisEN iProExiEN = new ProduccionExisEN();
            iProExiEN.ClaveProduccionDeta = pObj.ClaveProduccionDeta;
            iProExiEN.CTipoDescarga = "'0','1'";//fase masa y control calidad
            iProExiEN.Adicionales.CampoOrden = ProduccionExisEN.ClaProExi;
            List<ProduccionExisEN> iLisProExi = ProduccionExisRN.ListarProduccionExisXClaveProduccionDetaYTiposDescarga(iProExiEN);

            //grabar SolicitudPedidos deta
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDetaPorSalidaInsumos(iLisProExi, iSolPedidoCabEN, pLisExi);

            //listar al SolicitudPedidodeta
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaPorClaveSolicitudPedidoCabe(iSolPedidoCabEN.ClaveSolicitudPedidoCabe);

            //actualizar existencias por adicion de SolicitudPedido
            SolicitudPedidoDetaRN.ExistenciasActualizadasPorAdicionSolicitudPedidosDeta(iLisMovDet, pLisExi);

            //modificar produccionDeta
            pObj.FechaSalidaFaseMasa = pObj.FechaProduccionDeta;
            pObj.ClaveSalidaFaseMasa = iSolPedidoCabEN.ClaveSolicitudPedidoCabe;
            ProduccionDetaRN.ModificarPorSalidaInsumosFaseMasa(pObj);
        }

        public static void RegenerarSolicitudPedidosDetalleIngresosSemiProductos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas las producciones deta del periodo en proceso
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaParaRecalculoManoObra(iAño, iCodigoMes);

            //traer todo el SolicitudPedidoCabe del periodo en proceso
            List<SolicitudPedidoCabeEN> iLisMovCab = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el SolicitudPedidoDeta del periodo en proceso
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<SolicitudPedidoCabeEN> iLisMovCabMod = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetMod = new List<SolicitudPedidoDetaEN>();

            //recorrer cada produccion deta
            foreach (ProduccionDetaEN xProDet in iLisProDet)
            {
                //operacion para agregar el detalle que le falta a los SolicitudPedidos ingreso al almacen de semi productos
                if (xProDet.ClaveIngresoSemiElaborado != string.Empty)
                {
                    //traer al SolicitudPedidoCabe
                    SolicitudPedidoCabeEN iSolPedidoCabEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, xProDet.ClaveIngresoSemiElaborado);

                    //actualizar datos
                    iSolPedidoCabEN.FechaSolicitudPedidoCabe = xProDet.FechaProduccionDeta;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iSolPedidoCabEN);

                    //segun si existe en SolicitudPedidodeta en bd
                    SolicitudPedidoDetaEN iMovDetBus = ListaG.Buscar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab, iSolPedidoCabEN.ClaveSolicitudPedidoCabe);
                    if (iMovDetBus.ClaveSolicitudPedidoDeta != string.Empty)
                    {
                        //actualizar datos
                        iMovDetBus.FechaSolicitudPedidoCabe = xProDet.FechaProduccionDeta;

                        //agregar a la lista resultado
                        iLisMovDetMod.Add(iMovDetBus);
                    }
                    else
                    {
                        //crear su SolicitudPedidodeta                   
                        SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoSemiElaborado(xProDet, iSolPedidoCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }
                }
            }

            //grabar masivo
            SolicitudPedidoCabeRN.ModificarSolicitudPedidoCabe(iLisMovCabMod);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
            SolicitudPedidoDetaRN.ModificarSolicitudPedidoDeta(iLisMovDetMod);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXPeriodo(string pAño, string pCodigoMes)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = Formato.UnionDosTextos(pAño, pCodigoMes, "-");
            iSolPedidoCabEN.Adicionales.CampoOrden = SolicitudPedidoCabeEN.ClaMovCab;

            //ejecutar metodo
            return SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesXPeriodo(iSolPedidoCabEN);
        }

        public static void RegenerarSolicitudPedidosDetalleSalidaTransferenciaSemiProductos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas liberaciones del periodo en proceso
            List<LiberacionEN> iLisLib = LiberacionRN.ListarLiberacionXPeriodo(iAño, iCodigoMes);

            //traer todo el SolicitudPedidoCabe del periodo en proceso
            List<SolicitudPedidoCabeEN> iLisMovCab = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el SolicitudPedidoDeta del periodo en proceso
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<SolicitudPedidoCabeEN> iLisMovCabMod = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetMod = new List<SolicitudPedidoDetaEN>();
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

                //operacion para agregar el detalle que le falta a los SolicitudPedidos salida transferencia del almacen de semi productos
                if (xLib.ClaveSalidaTransferenciaDesechas != string.Empty)
                {
                    //traer al SolicitudPedidoCabe
                    SolicitudPedidoCabeEN iSolPedidoCabEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaDesechas);

                    //actualizar datos
                    iSolPedidoCabEN.FechaSolicitudPedidoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iSolPedidoCabEN);

                    //segun si existe en SolicitudPedidodeta en bd
                    SolicitudPedidoDetaEN iMovDetBus = ListaG.Buscar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab, iSolPedidoCabEN.ClaveSolicitudPedidoCabe);
                    if (iMovDetBus.ClaveSolicitudPedidoDeta != string.Empty)
                    {
                        //actualizar datos
                        iMovDetBus.FechaSolicitudPedidoCabe = xLib.FechaLiberacion;

                        //agregar a la lista resultado
                        iLisMovDetMod.Add(iMovDetBus);
                    }
                    else
                    {
                        //crear su SolicitudPedidodeta                   
                        SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesDesechos(xLib, iSolPedidoCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al SolicitudPedido ingreso transferencia
                    SolicitudPedidoCabeEN iMovCabIngTraEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, string.Empty);

                    //actualizar datos
                    iMovCabIngTraEN.FechaSolicitudPedidoCabe = iSolPedidoCabEN.FechaSolicitudPedidoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    SolicitudPedidoDetaEN iMovDetIngBus = ListaG.Buscar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab, string.Empty);

                    //actualizar datos
                    iMovDetIngBus.FechaSolicitudPedidoCabe = iSolPedidoCabEN.FechaSolicitudPedidoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }

                //operacion para agregar el detalle que le falta a los SolicitudPedidos salida transferencia del almacen de semi productos
                if (xLib.ClaveSalidaTransferenciaReproceso != string.Empty)
                {
                    //traer al SolicitudPedidoCabe
                    SolicitudPedidoCabeEN iSolPedidoCabEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaReproceso);

                    //actualizar datos
                    iSolPedidoCabEN.FechaSolicitudPedidoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iSolPedidoCabEN);

                    //segun si existe en SolicitudPedidodeta en bd
                    SolicitudPedidoDetaEN iMovDetBus = ListaG.Buscar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab, iSolPedidoCabEN.ClaveSolicitudPedidoCabe);
                    if (iMovDetBus.ClaveSolicitudPedidoDeta != string.Empty)
                    {
                        //actualizar datos
                        iMovDetBus.FechaSolicitudPedidoCabe = xLib.FechaLiberacion;

                        //agregar a la lista resultado
                        iLisMovDetMod.Add(iMovDetBus);
                    }
                    else
                    {
                        //crear su SolicitudPedidodeta                   
                        SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesReproceso(xLib, iSolPedidoCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al SolicitudPedido ingreso transferencia
                    SolicitudPedidoCabeEN iMovCabIngTraEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, string.Empty);

                    //actualizar datos
                    iMovCabIngTraEN.FechaSolicitudPedidoCabe = iSolPedidoCabEN.FechaSolicitudPedidoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    SolicitudPedidoDetaEN iMovDetIngBus = ListaG.Buscar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab, string.Empty);

                    //actualizar datos
                    iMovDetIngBus.FechaSolicitudPedidoCabe = iSolPedidoCabEN.FechaSolicitudPedidoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }

                //operacion para agregar el detalle que le falta a los SolicitudPedidos salida transferencia del almacen de semi productos
                if (xLib.ClaveSalidaTransferenciaDonacion != string.Empty)
                {
                    //traer al SolicitudPedidoCabe
                    SolicitudPedidoCabeEN iSolPedidoCabEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, xLib.ClaveSalidaTransferenciaDonacion);

                    //actualizar datos
                    iSolPedidoCabEN.FechaSolicitudPedidoCabe = xLib.FechaLiberacion;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iSolPedidoCabEN);

                    //segun si existe en SolicitudPedidodeta en bd
                    SolicitudPedidoDetaEN iMovDetBus = ListaG.Buscar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab, iSolPedidoCabEN.ClaveSolicitudPedidoCabe);
                    if (iMovDetBus.ClaveSolicitudPedidoDeta != string.Empty)
                    {
                        //actualizar datos
                        iMovDetBus.FechaSolicitudPedidoCabe = xLib.FechaLiberacion;

                        //agregar a la lista resultado
                        iLisMovDetMod.Add(iMovDetBus);
                    }
                    else
                    {
                        //crear su SolicitudPedidodeta                   
                        SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoUnidadesDonacion(xLib, iSolPedidoCabEN, iCenCosEN);

                        //agregar a la lista resultado
                        iLisMovDetAdi.Add(iMovDetEN);
                    }

                    //modificar al SolicitudPedido ingreso transferencia
                    SolicitudPedidoCabeEN iMovCabIngTraEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, string.Empty);

                    //actualizar datos
                    iMovCabIngTraEN.FechaSolicitudPedidoCabe = iSolPedidoCabEN.FechaSolicitudPedidoCabe;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iMovCabIngTraEN);

                    //buscar el detalle ingreso transferencia
                    SolicitudPedidoDetaEN iMovDetIngBus = ListaG.Buscar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab, string.Empty);

                    //actualizar datos
                    iMovDetIngBus.FechaSolicitudPedidoCabe = iSolPedidoCabEN.FechaSolicitudPedidoCabe;

                    //agregar a la lista resultado
                    iLisMovDetMod.Add(iMovDetIngBus);
                }
            }

            //grabar masivo
            LiberacionRN.ModificarLiberacion(iLisLibMod);
            SolicitudPedidoCabeRN.ModificarSolicitudPedidoCabe(iLisMovCabMod);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
            SolicitudPedidoDetaRN.ModificarSolicitudPedidoDeta(iLisMovDetMod);
        }

        public static void RegenerarSolicitudPedidosDetalleSalidasSemiProductos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas las producciones deta del periodo en proceso
            List<List<ProduccionProTerEN>> iLisLisProProTer = ProduccionProTerRN.ListarListasProduccionProTerPorClaveEncajado(iAño, iCodigoMes);

            //traer todo el SolicitudPedidoCabe del periodo en proceso
            List<SolicitudPedidoCabeEN> iLisMovCab = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el SolicitudPedidoDeta del periodo en proceso
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<SolicitudPedidoCabeEN> iLisMovCabMod = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();

            //recorrer cada produccion deta
            foreach (List<ProduccionProTerEN> xLisProProTer in iLisLisProProTer)
            {
                //obtener el primer objeto de la lista
                ProduccionProTerEN iProProTerEN = xLisProProTer[0];

                //operacion para agregar el detalle que le falta a los SolicitudPedidos ingreso al almacen de semi productos
                if (iProProTerEN.ClaveSalidaUnidadesEmpacar != string.Empty)
                {
                    //traer al SolicitudPedidoCabe
                    SolicitudPedidoCabeEN iSolPedidoCabEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, iProProTerEN.ClaveSalidaUnidadesEmpacar);

                    //actualizar datos
                    iSolPedidoCabEN.FechaSolicitudPedidoCabe = iProProTerEN.FechaEncajado;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iSolPedidoCabEN);

                    //preguntar si hay detalle
                    List<SolicitudPedidoDetaEN> iLisMovDetEnc = ListaG.Filtrar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab,
                        iProProTerEN.ClaveSalidaUnidadesEmpacar);
                    if (iLisMovDetEnc.Count == 0)
                    {
                        //recorrer cada objeto ProduccionProTer
                        foreach (ProduccionProTerEN xProProTer in xLisProProTer)
                        {
                            //crear su SolicitudPedidodeta                   
                            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaSalidaEmpaquetar(xProProTer, iSolPedidoCabEN, iCenCosEN);

                            //agregar a la lista resultado
                            iLisMovDetAdi.Add(iMovDetEN);
                        }
                    }
                }
            }

            //grabar masivo
            SolicitudPedidoCabeRN.ModificarSolicitudPedidoCabe(iLisMovCabMod);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
        }

        public static void RegenerarSolicitudPedidosDetalleIngresosProductosTerminados()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todas las producciones deta del periodo en proceso
            List<List<ProduccionProTerEN>> iLisLisProProTer = ProduccionProTerRN.ListarListasProduccionProTerPorClaveEncajado(iAño, iCodigoMes);

            //traer todo el SolicitudPedidoCabe del periodo en proceso
            List<SolicitudPedidoCabeEN> iLisMovCab = SolicitudPedidoCabeRN.ListarSolicitudPedidoCabesXPeriodo(iAño, iCodigoMes);

            //traer todo el SolicitudPedidoDeta del periodo en proceso
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<SolicitudPedidoCabeEN> iLisMovCabMod = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();

            //recorrer cada produccion deta
            foreach (List<ProduccionProTerEN> xLisProProTer in iLisLisProProTer)
            {
                //obtener el primer objeto de la lista
                ProduccionProTerEN iProProTerEN = xLisProProTer[0];

                //operacion para agregar el detalle que le falta a los SolicitudPedidos ingreso al almacen de semi productos
                if (iProProTerEN.ClaveIngresoProductoTerminado != string.Empty)
                {
                    //traer al SolicitudPedidoCabe
                    SolicitudPedidoCabeEN iSolPedidoCabEN = ListaG.Buscar<SolicitudPedidoCabeEN>(iLisMovCab, SolicitudPedidoCabeEN.ClaMovCab, iProProTerEN.ClaveIngresoProductoTerminado);

                    //actualizar datos
                    iSolPedidoCabEN.FechaSolicitudPedidoCabe = iProProTerEN.FechaEncajado;

                    //agregamos a la lista resultado a grabar
                    iLisMovCabMod.Add(iSolPedidoCabEN);

                    //preguntar si hay detalle
                    List<SolicitudPedidoDetaEN> iLisMovDetEnc = ListaG.Filtrar<SolicitudPedidoDetaEN>(iLisMovDet, SolicitudPedidoDetaEN.ClaMovCab,
                        iProProTerEN.ClaveIngresoProductoTerminado);
                    if (iLisMovDetEnc.Count == 0)
                    {
                        //recorrer cada objeto ProduccionProTer
                        foreach (ProduccionProTerEN xProProTer in xLisProProTer)
                        {
                            //crear su SolicitudPedidodeta                   
                            SolicitudPedidoDetaEN iMovDetEN = SolicitudPedidoDetaRN.CrearSolicitudPedidoDetaParaIngresoMercaderia(xProProTer, iSolPedidoCabEN, iCenCosEN);

                            //agregar a la lista resultado
                            iLisMovDetAdi.Add(iMovDetEN);
                        }
                    }
                }
            }

            //grabar masivo
            SolicitudPedidoCabeRN.ModificarSolicitudPedidoCabe(iLisMovCabMod);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
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

        public static void EliminarSolicitudPedidosTransferenciasGeneradas(LiberacionEN pLib)
        {
            //traer al objeto liberacion de bd
            LiberacionEN iLibEN = LiberacionRN.BuscarLiberacionXClave(pLib);

            //eliminar SolicitudPedidos transferencia reproceso,si se llego a generar este SolicitudPedido
            if (iLibEN.ClaveSalidaTransferenciaReproceso != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iLibEN.ClaveSalidaTransferenciaReproceso);
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iLibEN.ClaveIngresoTransferenciaReproceso);
                EliminarSolicitudPedidoCabe(iLibEN.ClaveSalidaTransferenciaReproceso);
                EliminarSolicitudPedidoCabe(iLibEN.ClaveIngresoTransferenciaReproceso);
            }

            //eliminar SolicitudPedidos transferencia desecho,si se llego a generar este SolicitudPedido
            if (iLibEN.ClaveSalidaTransferenciaDesechas != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iLibEN.ClaveSalidaTransferenciaDesechas);
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iLibEN.ClaveIngresoTransferenciaDesechas);
                EliminarSolicitudPedidoCabe(iLibEN.ClaveSalidaTransferenciaDesechas);
                EliminarSolicitudPedidoCabe(iLibEN.ClaveIngresoTransferenciaDesechas);
            }

            //eliminar SolicitudPedidos transferencia donacion,si se llego a generar este SolicitudPedido
            if (iLibEN.ClaveSalidaTransferenciaDonacion != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iLibEN.ClaveSalidaTransferenciaDonacion);
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iLibEN.ClaveIngresoTransferenciaDonacion);
                EliminarSolicitudPedidoCabe(iLibEN.ClaveSalidaTransferenciaDonacion);
                EliminarSolicitudPedidoCabe(iLibEN.ClaveIngresoTransferenciaDonacion);
            }

            //eliminar SolicitudPedidos transferencia muestra,si se llego a generar este SolicitudPedido
            if (iLibEN.ClaveSalidaTransferenciaMuestra != string.Empty)
            {
                //eliminar la transferencia ingreso y salida(cabe y deta)
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iLibEN.ClaveSalidaTransferenciaMuestra);
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(iLibEN.ClaveIngresoTransferenciaMuestra);
                EliminarSolicitudPedidoCabe(iLibEN.ClaveSalidaTransferenciaMuestra);
                EliminarSolicitudPedidoCabe(iLibEN.ClaveIngresoTransferenciaMuestra);
            }
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesNoImportados(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesNoImportados(pObj);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesNoImportadosIngreso(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            //iSolPedidoCabEN.CClaseTipoOperacion = "1";//ingreso
            iSolPedidoCabEN.Adicionales.CampoOrden = SolicitudPedidoCabeEN.ClaMovCab;

            //ejecutar metodo
            return ListarSolicitudPedidoCabesNoImportados(iSolPedidoCabEN);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesNoImportadosSalida(string pCodigoPeriodo)
        {
            //asignar parametros
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();
            iSolPedidoCabEN.PeriodoSolicitudPedidoCabe = pCodigoPeriodo;
            //iSolPedidoCabEN.CClaseTipoOperacion = "2";//salida
            iSolPedidoCabEN.Adicionales.CampoOrden = SolicitudPedidoCabeEN.ClaMovCab;

            //ejecutar metodo
            return ListarSolicitudPedidoCabesNoImportados(iSolPedidoCabEN);
        }

        public static void RegenerarLotesYLotesDetaASolicitudPedidos()
        {
            string iAño = "2020";
            string iCodigoMes = "05";
            string iPeriodo = Formato.UnionDosTextos(iAño, iCodigoMes, "-");

            //traer todo el SolicitudPedidoDeta del periodo en proceso
            List<SolicitudPedidoDetaEN> iLisMovDet = SolicitudPedidoDetaRN.ListarSolicitudPedidosDetaXPeriodo(iPeriodo);

            //traer al centro costo de produccion
            ItemEEN iCenCosEN = ItemERN.BuscarCentroCostoProduccion();

            //listas a grabar en bd
            List<SolicitudPedidoCabeEN> iLisMovCabMod = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();



            //grabar masivo
            SolicitudPedidoCabeRN.ModificarSolicitudPedidoCabe(iLisMovCabMod);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
        }

        public static void GenerarTransferenciasAutomaticasPorSincerado(ProduccionDetaEN pObj)
        {
            //segun si ya genero los SolicitudPedidos de transferencia
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

            //obtener la fecha para estos SolicitudPedidos de transferencia(este dato sale de la fecha de produccion de estos insumos)
            string iFechaSolicitudPedidoCabe = pObj.FechaProduccionDeta;

            //traemos al objeto parametro
            ParametroEN iParEN = ParametroRN.BuscarParametro();

            //traemos al tipo de operacion de transferencia salida
            TipoOperacionEN iTipOpeSalEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaSalida);

            //traemos al tipo de operacion de transferencia ingreso
            TipoOperacionEN iTipOpeIngEN = TipoOperacionRN.BuscarTipoOperacionXCodigo(iParEN.TipoOperacionTransferenciaIngreso);

            //traer la lista de existencias de la empresa actual
            List<ExistenciaEN> iLisExi = ExistenciaRN.ListarExistencias();

            //listas para adicionar y modificar en b.d
            List<SolicitudPedidoCabeEN> iLisMovCabAdi = new List<SolicitudPedidoCabeEN>();
            List<SolicitudPedidoDetaEN> iLisMovDetAdi = new List<SolicitudPedidoDetaEN>();
            List<ExistenciaEN> iLisExiMod = new List<ExistenciaEN>();

            //numero SolicitudPedido para la salida
            string iNumeroSolicitudPedidoCabeSalida = string.Empty;

            //recorrer cada lista
            foreach (List<ProduccionExisEN> xLisProExi in iLisLisProExi)
            {
                //obtener al primer objeto de la lista
                ProduccionExisEN iProExi = xLisProExi[0];

                //creamos el objeto SolicitudPedidoCabe de salida transferencia
                SolicitudPedidoCabeEN iMovCabSalEN = new SolicitudPedidoCabeEN();

                //pasar datos
                iMovCabSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabSalEN.FechaSolicitudPedidoCabe = iFechaSolicitudPedidoCabe;
                iMovCabSalEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iFechaSolicitudPedidoCabe, "-");
                //iMovCabSalEN.CodigoTipoOperacion = iTipOpeSalEN.CodigoTipoOperacion;
                iMovCabSalEN.CodigoAlmacen = iProExi.CodigoAlmacen;
                iMovCabSalEN.CodigoPersonal = iProExi.CodigoPersonal;
                iMovCabSalEN.GlosaSolicitudPedidoCabe = "TRANSFERENCIA AUTOMATICA DE PRODUCCION SINCERADO";
                iMovCabSalEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabSalEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(ref iNumeroSolicitudPedidoCabeSalida, iMovCabSalEN);
                iMovCabSalEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabSalEN);

                //creamos la lista de SolicitudPedidoDeta de salida transferencia
                List<SolicitudPedidoDetaEN> iLisMovDetSal = new List<SolicitudPedidoDetaEN>();

                //variable para los correlativos de cada SolicitudPedidoDeta
                string iCorrelativoSolicitudPedidoDeta = "0000";

                //recorrer cada insumoFaltante
                foreach (ProduccionExisEN xProExi in xLisProExi)
                {
                    //buscar a la existencia para este xProExi
                    ExistenciaEN iExiBusEN = ListaG.Buscar<ExistenciaEN>(iLisExi, ExistenciaEN.CodAlm, xProExi.CodigoAlmacen,
                        ExistenciaEN.CodExi, xProExi.CodigoExistencia);

                    //creamos un objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetSalEN = new SolicitudPedidoDetaEN();

                    //pasar datos
                    iMovDetSalEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetSalEN.FechaSolicitudPedidoCabe = iMovCabSalEN.FechaSolicitudPedidoCabe;
                    iMovDetSalEN.PeriodoSolicitudPedidoCabe = iMovCabSalEN.PeriodoSolicitudPedidoCabe;
                    iMovDetSalEN.CodigoAlmacen = iMovCabSalEN.CodigoAlmacen;
                    //iMovDetSalEN.CodigoTipoOperacion = iMovCabSalEN.CodigoTipoOperacion;
                    iMovDetSalEN.CCalculaPrecioPromedio = iTipOpeSalEN.CCalculaPrecioPromedio;
                    iMovDetSalEN.CClaseTipoOperacion = "2";//salida
                    iMovDetSalEN.NumeroSolicitudPedidoCabe = iMovCabSalEN.NumeroSolicitudPedidoCabe;
                    iMovDetSalEN.CodigoCentroCosto = string.Empty;
                    iMovDetSalEN.DescripcionCentroCosto = string.Empty;
                    iMovDetSalEN.CodigoExistencia = xProExi.CodigoExistencia;
                    iMovDetSalEN.DescripcionExistencia = xProExi.DescripcionExistencia;
                    iMovDetSalEN.CodigoUnidadMedida = xProExi.CodigoUnidadMedida;
                    iMovDetSalEN.NombreUnidadMedida = xProExi.NombreUnidadMedida;
                    iMovDetSalEN.CantidadSolicitudPedidoDeta = xProExi.CantidadDevueltaProduccionExis;
                    iMovDetSalEN.GlosaSolicitudPedidoDeta = iMovCabSalEN.GlosaSolicitudPedidoCabe;
                    iMovDetSalEN.CEsLote = iExiBusEN.CEsLote;
                    iMovDetSalEN.ClaveSolicitudPedidoCabe = iMovCabSalEN.ClaveSolicitudPedidoCabe;
                    iMovDetSalEN.CorrelativoSolicitudPedidoDeta = Numero.IncrementarCorrelativoNumerico(ref iCorrelativoSolicitudPedidoDeta);
                    iMovDetSalEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetSalEN);

                    //adicionar a la lista de SolicitudPedidoDeta de este SolicitudPedidoCabe
                    iLisMovDetSal.Add(iMovDetSalEN);
                }

                //grabar lotesdeta
                //LoteDetaRN.AdicionarLoteDeta(iLisMovDetSal);

                //creamos el objeto SolicitudPedidoCabe de ingreso transferencia
                SolicitudPedidoCabeEN iMovCabIngEN = new SolicitudPedidoCabeEN();

                //pasar datos
                iMovCabIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                iMovCabIngEN.FechaSolicitudPedidoCabe = iFechaSolicitudPedidoCabe;
                iMovCabIngEN.PeriodoSolicitudPedidoCabe = Fecha.ObtenerPeriodo(iFechaSolicitudPedidoCabe, "-");
                //iMovCabIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                iMovCabIngEN.CodigoAlmacen = iProExi.CodigoAlmacenOrigen;
                iMovCabIngEN.CodigoPersonal = iProExi.CodigoPersonalOrigen;
                iMovCabIngEN.GlosaSolicitudPedidoCabe = "TRANSFERENCIA AUTOMATICA DE PRODUCCION SINCERADO";
                iMovCabIngEN.COrigenVentanaCreacion = "3";//transferencia
                iMovCabIngEN.NumeroSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerNuevoNumeroSolicitudPedidoCabeAutogenerado(iMovCabIngEN);
                iMovCabIngEN.ClaveSolicitudPedidoCabe = SolicitudPedidoCabeRN.ObtenerClaveSolicitudPedidoCabe(iMovCabIngEN);

                //creamos la lista de SolicitudPedidoDeta de salida transferencia
                List<SolicitudPedidoDetaEN> iLisMovDetIng = new List<SolicitudPedidoDetaEN>();

                //recorrer cada objeto SolicitudPedidoDetaSalida
                foreach (SolicitudPedidoDetaEN xMovDetSal in iLisMovDetSal)
                {
                    //creamos objeto SolicitudPedidoDeta
                    SolicitudPedidoDetaEN iMovDetIngEN = new SolicitudPedidoDetaEN();

                    //pasamos datos               
                    iMovDetIngEN.ClaveSolicitudPedidoCabe = iMovCabIngEN.ClaveSolicitudPedidoCabe;
                    iMovDetIngEN.CorrelativoSolicitudPedidoDeta = xMovDetSal.CorrelativoSolicitudPedidoDeta;
                    iMovDetIngEN.CodigoEmpresa = Universal.gCodigoEmpresa;
                    iMovDetIngEN.FechaSolicitudPedidoCabe = iMovCabIngEN.FechaSolicitudPedidoCabe;
                    iMovDetIngEN.PeriodoSolicitudPedidoCabe = iMovCabIngEN.PeriodoSolicitudPedidoCabe;
                    iMovDetIngEN.CodigoAlmacen = iMovCabIngEN.CodigoAlmacen;
                    //iMovDetIngEN.CodigoTipoOperacion = iTipOpeIngEN.CodigoTipoOperacion;
                    iMovDetIngEN.CClaseTipoOperacion = "1";//ingreso
                    iMovDetIngEN.CCalculaPrecioPromedio = iTipOpeIngEN.CCalculaPrecioPromedio;
                    iMovDetIngEN.NumeroSolicitudPedidoCabe = iMovCabIngEN.NumeroSolicitudPedidoCabe;
                    iMovDetIngEN.CodigoCentroCosto = string.Empty;
                    iMovDetIngEN.CodigoExistencia = xMovDetSal.CodigoExistencia;
                    iMovDetIngEN.CodigoUnidadMedida = xMovDetSal.CodigoUnidadMedida;
                    iMovDetIngEN.CantidadSolicitudPedidoDeta = xMovDetSal.CantidadSolicitudPedidoDeta;
                    iMovDetIngEN.GlosaSolicitudPedidoDeta = iMovCabIngEN.GlosaSolicitudPedidoCabe;
                    iMovDetIngEN.ClaveSolicitudPedidoDeta = SolicitudPedidoDetaRN.ObtenerClaveSolicitudPedidoDeta(iMovDetIngEN);

                    //buscar a la existencia en proceso
                    string iClaveExistencia = SolicitudPedidoDetaRN.ObtenerClaveExistencia(iMovDetIngEN);
                    ExistenciaEN iExiEncEN = ExistenciaRN.BuscarExistenciaXClave(iClaveExistencia, iLisExi);


                    //agregamos a la lista 
                    iLisMovDetIng.Add(iMovDetIngEN);
                }

                //actualizar al SolicitudPedidoCabeSalida con el ultimo dato
                //iMovCabSalEN.ClaveIngresoSolicitudPedidoCabe = iMovCabIngEN.ClaveSolicitudPedidoCabe;

                //adicionamos a la lista de SolicitudPedidos Cabe a adicionar
                iLisMovCabAdi.Add(iMovCabSalEN);
                iLisMovCabAdi.Add(iMovCabIngEN);

                //adicionamos a la lista de SolicitudPedidos deta a adicionar
                iLisMovDetAdi.AddRange(iLisMovDetSal);
                iLisMovDetAdi.AddRange(iLisMovDetIng);

                //traer la lista de existencias actualizadas por estos SolicitudPedidos
                List<ExistenciaEN> iLisExiSalMod = SolicitudPedidoDetaRN.ListarExistenciasActualizadasPorAdicionSolicitudPedidosDeta(iLisMovDetSal);
                List<ExistenciaEN> iLisExiIngMod = SolicitudPedidoDetaRN.ListarExistenciasActualizadasPorAdicionSolicitudPedidosDeta(iLisMovDetIng);

                //adicionamos a la lista de existencias a modificar
                iLisExiMod.AddRange(iLisExiSalMod);
                iLisExiMod.AddRange(iLisExiIngMod);
            }

            //guardando cada clave de SolicitudPedido salida en el objeto produccionDeta
            pObj.ClavesTransferenciaSincerado = ListaG.ArmarCadenaDeValores<SolicitudPedidoCabeEN>(iLisMovCabAdi, SolicitudPedidoCabeEN.ClaMovCab, ";");

            //grabar en b.d
            SolicitudPedidoCabeRN.AdicionarSolicitudPedidoCabe(iLisMovCabAdi);
            SolicitudPedidoDetaRN.AdicionarSolicitudPedidoDeta(iLisMovDetAdi);
            ExistenciaRN.ModificarExistencia(iLisExiMod);
            ProduccionDetaRN.ModificarProduccionDeta(pObj);
        }

        public static void GenerarTransferenciasAutomaticasAlModificarPorSincerado(ProduccionDetaEN pObj)
        {
            //obtener una lista de claves SolicitudPedido cabe
            List<string> iLisClaMovCab = Cadena.ListarPalabrasDeTexto(pObj.ClavesTransferenciaSincerado, ";");

            //recorrer cada claveSolicitudPedidoCabe
            foreach (string xStrCla in iLisClaMovCab)
            {
                //eliminar al SolicitudPedido cabe
                EliminarSolicitudPedidoCabe(xStrCla);

                //eliminar al SolicitudPedido deta
                SolicitudPedidoDetaRN.EliminarSolicitudPedidoDetaXSolicitudPedidoCabe(xStrCla);
            }

            //volver a generar la transferencia automatica
            GenerarTransferenciasAutomaticasAlAdicionarPorSincerado(pObj);
        }

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXClaveProduccionProTerYClaseOperacion(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesXClaveProduccionProTerYClaseOperacion(pObj);
        }

        public static string ObtenerStrProduccionesDetaUsadasParaAdicionales(List<SolicitudPedidoDetaEN> pLisMovDet, ProduccionProTerEN pProProTer)
        {
            //valor resultado
            string iValor = string.Empty;

            //valida cuando no hay objeto en la lista
            if (pLisMovDet.Count == 0) { return iValor; }

            //obtener al unico objeto de la lista
            SolicitudPedidoDetaEN iMovDetEN = pLisMovDet[0];

            //valida cuando el objeto no es del almacen "A11"
            if (iMovDetEN.CodigoAlmacen != "A11") { return iValor; }

            //traer a todas las Producciones deta para este encajado
            FormulaDetaEN iForDetEN = FormulaDetaRN.BuscarFormulaDetaXProductoTerminado(pProProTer);
            List<ProduccionDetaEN> iLisProDet = ProduccionDetaRN.ListarProduccionDetaConSaldoLiberacion(iForDetEN.CodigoSemiProducto);

            //cantidad a salir
            decimal iCantidadASalir = iMovDetEN.CantidadSolicitudPedidoDeta;

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

        public static List<SolicitudPedidoCabeEN> ListarSolicitudPedidoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(SolicitudPedidoCabeEN pObj)
        {
            SolicitudPedidoCabeAD iPerAD = new SolicitudPedidoCabeAD();
            return iPerAD.ListarSolicitudPedidoCabesXClaveProduccionProTerParteEmpaquetadoYClaseOperacion(pObj);
        }

        public static SolicitudPedidoCabeEN ValidaCuandoFechaEsMenorAFechaEncajado(SolicitudPedidoCabeEN pObj, string pFechaEncajado)
        {
            //objeto resultado
            SolicitudPedidoCabeEN iSolPedidoCabEN = new SolicitudPedidoCabeEN();

            //validar           
            string iFechaSolicitudPedidoCabe = Fecha.ObtenerDiaMesAno(pObj.FechaSolicitudPedidoCabe);
            if (Fecha.EsMayorOIgualQue(iFechaSolicitudPedidoCabe, pFechaEncajado) == false)
            {
                iSolPedidoCabEN.Adicionales.EsVerdad = false;
                iSolPedidoCabEN.Adicionales.Mensaje = "La fecha " + pObj.FechaSolicitudPedidoCabe + " no debe ser menor a la fecha de encajado " +
                                                pFechaEncajado;
            }

            //ok
            return iSolPedidoCabEN;
        }

        public static void AsignarSolicitudEnviada(SolicitudPedidoCabeEN pObj, List<SolicitudPedidoCabeEN> pLista)
        {
            //lista actualizada
            List<SolicitudPedidoCabeEN> iLisSol = new List<SolicitudPedidoCabeEN>();

            //buscamos el objeto en la lista pLista
            foreach (SolicitudPedidoCabeEN xPem in pLista)
            {
                if (xPem.ClaveSolicitudPedidoCabe == pObj.ClaveSolicitudPedidoCabe)
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
    }
}
