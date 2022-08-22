using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos.Config
{
    public class SqlDatos
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlTransaction tra;

        public enum Bd
        {
            Almacen_Produccion = 0,
            ContabilidadAlfisa
        }


        public void Conectar(SqlDatos.Bd pBaseDatos)
        {
            StringBuilder xCadenaConexion = new System.Text.StringBuilder();
            switch (pBaseDatos)
            {
                case SqlDatos.Bd.Almacen_Produccion:
                    {
                        //xCadenaConexion.Append(" Data Source=LAPTOP-5JT8A13O;");
                        //xCadenaConexion.Append(" Data Source=LAPTOP-0ANI50G4\\Sql2016;");
                        //xCadenaConexion.Append(" Data Source=Lenovo-Pc\\Sql2016;");
                        //xCadenaConexion.Append(" Data Source=javier-Pc\\MSSQLSERVER2012;");
                        //xCadenaConexion.Append(" Data Source=ARES\\MENORCA1;");
                        //xCadenaConexion.Append(" Data Source=LAPTOP-GUDPF7AP\\MSSQLSERVER2014;");
                        //xCadenaConexion.Append(" Data Source=LAPTOP-GUDPF7AP\\MSSQLSERVER2012;");
                        //xCadenaConexion.Append(" Data Source=SERVER-LQ\\SQLEXPRESS;"); 
                        //xCadenaConexion.Append(" Data Source=LAPTOP-GUDPF7AP\\MSSQLSERVER2016;");
                        xCadenaConexion.Append(" Data Source=DESKTOP-VQ0I0E0\\SQLEXPRESS;");
                        //xCadenaConexion.Append(" Data Source=RAM-INDUSTRIAS\\SQLRAMINDUSTRIAS;");
                        //xCadenaConexion.Append(" Data Source=192.168.0.152\\SQLRAMINDUSTRIAS;");
                        xCadenaConexion.Append(" Initial Catalog=" + SqlDatos.Bd.Almacen_Produccion.ToString() + ";");
                        xCadenaConexion.Append(" User Id=sa;");
                        xCadenaConexion.Append(" Password=.;");
                        //xCadenaConexion.Append(" Password=%Dr4am4%%2017S3rv3r;");
                        //xCadenaConexion.Append(" Password=RS461445;");
                        this.cn.ConnectionString = xCadenaConexion.ToString();
                        break;
                    }
                case SqlDatos.Bd.ContabilidadAlfisa:
                    {
                        //xCadenaConexion.Append(" Data Source=LENOVO-PC\\DESARROLLO;");                      
                        //xCadenaConexion.Append(" Initial Catalog=" + SqlDatos.Bd.ContabilidadAlfisa.ToString() + ";");
                        //xCadenaConexion.Append(" User Id=sa;");
                        //xCadenaConexion.Append(" Password=.;");                        
                        this.cn.ConnectionString = xCadenaConexion.ToString();
                        break;
                    }
            }
            //abrir conexion
            this.cn.Open();

        }

        public void ComandoProcedimientoAlmacenado(string pPa)
        {
            this.cmd.Connection = this.cn;
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = pPa;
        }

        public void ComandoTexto(string pTexto)
        {
            this.cmd.Connection = this.cn;
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = pTexto;
        }

        public void AsignarParametro(SqlParameter pPar, object pValor)
        {
            pPar.Value = pValor;
            this.cmd.Parameters.Add(pPar);
        }

        public DataTable ObtenerTablaRegistro()
        {
            DataTable xDt = new DataTable();
            xDt.Load(this.cmd.ExecuteReader());
            return xDt;
        }

        public void EjecutarSinResultado()
        {
            this.cmd.ExecuteNonQuery();
        }

        public IDataReader ObtenerIdr()
        {
            IDataReader xDr;
            xDr = this.cmd.ExecuteReader();
            return xDr;
        }

        public string ObtenerValor()
        {
            string xValor;
            if (this.cmd.ExecuteScalar() == null)
            {
                xValor = string.Empty;
            }
            else
            {
                xValor = this.cmd.ExecuteScalar().ToString();
            }
            return xValor;
        }

        public void Desconectar()
        {
            this.cn.Dispose();
            this.cn.Close();
            this.cmd.Dispose();
        }

        public void IniciaTransaccion()
        {
            tra = cn.BeginTransaction();
        }

        public void ComandoTextoTransaccion(string pTexto)
        {
            this.cmd.Connection = this.cn;
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = pTexto;
            this.cmd.Transaction = tra;
        }

        public void CerrarTransaccion()
        {
            tra.Commit();
        }

    }
}
