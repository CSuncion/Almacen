using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;

namespace Negocio
{
    public class TablaRN
    {
        public static TablaEN EnBlanco()
        {
            TablaEN iTabEN = new TablaEN();
            return iTabEN;
        }

        public static void AdicionarTabla(TablaEN pObj)
        {
            TablaAD iTabAD = new TablaAD();
            iTabAD.AgregarTabla(pObj);
        }

        public static void ModificarTabla(TablaEN pObj)
        {
            TablaAD iTabAD = new TablaAD();
            iTabAD.ModificarTabla(pObj);
        }

        public static void EliminarTabla(TablaEN pObj)
        {
            TablaAD iTabAD = new TablaAD();
            iTabAD.EliminarTabla(pObj);
        }

        public static List<TablaEN> ListarTablas(TablaEN pObj)
        {
            TablaAD iTabAD = new TablaAD();
            return iTabAD.ListarTablas(pObj);
        }

        public static List<TablaEN> ListarTablasXCategoria(TablaEN pObj)
        {
            TablaAD iTabAD = new TablaAD();
            return iTabAD.ListarTablasXCategoria(pObj);
        }

        public static TablaEN BuscarTablaXCodigo(TablaEN pObj)
        {
            TablaAD iTabAD = new TablaAD();
            return iTabAD.BuscarTablaXCodigo(pObj);
        }


    }
}
