using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using VisualStudio.Entidad;

namespace VisualStudio.VS.Datos
{
    public class AccesoADatos
    {
        SqlConnection sqlconn;
        Object resultado;

        protected void Page_Load(object sender, EventArgs e)
        {
            conectar();
        }

        //Conexion a BD
        public bool conectar()
        {
            string conexion = cadenaDeConexion();
            sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            return (sqlconn.State == ConnectionState.Open);
        }

        public String cadenaDeConexion()
        {
            SqlConnectionStringBuilder miConexion = new SqlConnectionStringBuilder();
            miConexion.DataSource = "MAXI-HP";  //Nombre del servidor
            miConexion.InitialCatalog = "VirtualShop";            //Nombre de Base de Datos
            miConexion.IntegratedSecurity = true;
            return miConexion.ConnectionString;
        }

        //Insertar a BD
        public void insertarNuevaTienda(Tienda tienda)
        {
            if (conectar())
            {
                List<SqlParameter> lista = new List<SqlParameter>();

                SqlParameter paramRazonSocial = new SqlParameter("@RAZONSOCIAL",tienda.RazonSocial); //Envio el paramerto a insertar
                SqlParameter paramEmail = new SqlParameter("@EMAIL", tienda.Email);
                SqlParameter paramPassword = new SqlParameter("@PASSWORD", tienda.Password);
                SqlParameter paramCUIT = new SqlParameter("@CUIT", tienda.CUIT);
                SqlParameter paramEstado = new SqlParameter("@ESTADO", tienda.Estado);
                
               
                
                lista.Add(paramRazonSocial);

                SqlCommand miComando = new SqlCommand("p_CrearTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramRazonSocial);
                
                miComando.Parameters.Add(paramPassword);
                miComando.Parameters.Add(paramCUIT);
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramEstado);
                miComando.ExecuteNonQuery();
            }
            sqlconn.Close();
        }

        public DataTable obtenerEmpresa()
        {
            if (conectar())
            {
                DataTable MiTabla = new DataTable();
                SqlDataAdapter Comando = new SqlDataAdapter("SELECT * FROM Empresa", sqlconn);
                Comando.Fill(MiTabla);
                return MiTabla;
                
            }
            else return null;

        }

        public void UpdateEmpresa(string name)
        {
            if (conectar())
            {
                
            }
        }

        //Listar Provincias
       /* public DataSet mostrarProvincias()
        {
            if (conectar())
            {
                DataSet ds = new DataSet();
                string consulta = "SELECT * FROM Provincia"; //Consulta q lista todas las Provincias
                SqlDataAdapter data = new SqlDataAdapter(consulta, sqlconn);
                data.Fill(ds);
                return ds;
            }
            else return null;
        }*/



        public void editarEmpresa(Tienda tienda)
        {
            if (conectar())
            {

                SqlParameter paramRazonSocial = new SqlParameter("@RAZONSOCIAL",tienda.RazonSocial); //Envio el paramerto a insertar
                SqlParameter paramEmail = new SqlParameter("@EMAIL", tienda.Email);
                SqlParameter paramPassword = new SqlParameter("@PASSWORD", tienda.Password);
                SqlParameter paramCUIT = new SqlParameter("@CUIT", tienda.CUIT);
                SqlParameter paramEstado = new SqlParameter("@ESTADO", tienda.Estado);


                SqlCommand miComando = new SqlCommand("p_ModificarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramRazonSocial);
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramPassword);
                miComando.Parameters.Add(paramCUIT);
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramEstado);
                miComando.ExecuteNonQuery();
            sqlconn.Close();
        }
        }

        internal void eliminarTienda(string Email)
        {
            if (conectar())
            {
                SqlParameter paramEmail = new SqlParameter("@EMAIL", Email);

                SqlCommand miComando = new SqlCommand("p_EliminarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramEmail);
                miComando.ExecuteNonQuery();
            }
           
        }

        public int buscarTienda(string nombreTienda)
        {
                
                if (conectar())
                {

                    SqlParameter paramRazonSocial = new SqlParameter("@RAZONSOCIAL", nombreTienda);
                    SqlParameter paramValidador = new SqlParameter("@VALIDADOR", SqlDbType.Int, 1);
                    paramValidador.Direction = ParameterDirection.Output;

                    SqlCommand miComando = new SqlCommand("BuscarEmpresa", sqlconn); //ejecuto la StoreProcedure en la BD
                    miComando.CommandType = CommandType.StoredProcedure;
                    miComando.Parameters.Add(paramRazonSocial);
                    miComando.Parameters.Add(paramValidador);


                    miComando.ExecuteNonQuery();

                    resultado = miComando.Parameters["@VALIDADOR"].Value;
                    
                }
            
                sqlconn.Close();
                int returnValor = Convert.ToInt32(resultado);
                return returnValor;
        }

        public void activarTienda(string modo, string nombreTienda)
        {
            if (conectar())
            {

                SqlParameter paramRazonSocial = new SqlParameter("@RAZONSOCIAL", nombreTienda); //Envio el paramerto a insertar
                SqlParameter paramEstado = new SqlParameter("@MODO", modo);
                SqlCommand miComando = new SqlCommand("ActivarEmpresa", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramRazonSocial);
                miComando.Parameters.Add(paramEstado);
                miComando.ExecuteNonQuery();
            }
            sqlconn.Close();
        }
    }
}
