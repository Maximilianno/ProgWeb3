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
            miConexion.DataSource = "SERGIO-HP";  //Nombre del servidor
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
                
                
               
                
                lista.Add(paramRazonSocial);

                SqlCommand miComando = new SqlCommand("p_CrearTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramRazonSocial);
                
                miComando.Parameters.Add(paramPassword);
                miComando.Parameters.Add(paramCUIT);
                miComando.Parameters.Add(paramEmail);
                
                miComando.ExecuteNonQuery();
            }
            sqlconn.Close();
        }

        public DataTable obtenerTienda(String email)
        {
            if (conectar())
            {
                DataTable MiTabla = new DataTable();
                DataRow miFila = MiTabla.NewRow();
                SqlParameter paramEmail = new SqlParameter("@EMAIL", email); //Envio el paramerto a insertar

                SqlCommand miComando = new SqlCommand("p_BuscarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramEmail);

                MiTabla.Load(miComando.ExecuteReader());
                return MiTabla;

                //SqlDataReader reader = miComando.ExecuteReader();


                //miFila.ItemArray[0] = reader[0];//id
                //miFila.ItemArray[1] = reader[1];//email
                //miFila.ItemArray[2] = reader[2];//razon social
                //miFila.ItemArray[3] = reader[3];//cuit
                //miFila.ItemArray[5] = reader[5];//estado
                //return miFila;
                

            }
            else return null;

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



        public void editarTienda(Tienda tienda)
        {
            if (conectar())
            {

                SqlParameter paramEmail = new SqlParameter("@EMAIL",tienda.Email); //Envio el paramerto a insertar
                SqlParameter paramRazonSocial = new SqlParameter("@RAZONSOCIAL", tienda.RazonSocial);
                SqlParameter paramCUIT = new SqlParameter("@CUIT", tienda.CUIT  );
                SqlParameter paramPassword = new SqlParameter("@PASSWORD", tienda.Password);
                SqlParameter paramEstado = new SqlParameter("@ESTADO", tienda.Estado);


                SqlCommand miComando = new SqlCommand("p_ModificarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramRazonSocial);
                miComando.Parameters.Add(paramCUIT);
                miComando.Parameters.Add(paramPassword);
                miComando.Parameters.Add(paramEstado);
                
                miComando.ExecuteNonQuery();
            sqlconn.Close();
        }
        }

        internal void eliminarTienda(int ID)
        {
            if (conectar())
            {
                SqlParameter paramID = new SqlParameter("@ID", ID);

                SqlCommand miComando = new SqlCommand("p_EliminarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramID);
                miComando.ExecuteNonQuery();
            }
           
        }

        public int loginTienda(string email)
        {
                
                if (conectar())
                {

                    SqlParameter paramEmail = new SqlParameter("@EMAIL", email);
                    //SqlParameter parmaPassword = new SqlParameter("@PASSWORD", password);
                    SqlParameter paramValidador = new SqlParameter("@VALIDADOR", SqlDbType.Int, 1);
                    paramValidador.Direction = ParameterDirection.Output;

                    SqlCommand miComando = new SqlCommand("p_Login2", sqlconn); //ejecuto la StoreProcedure en la BD
                    miComando.CommandType = CommandType.StoredProcedure;
                    miComando.Parameters.Add(paramEmail);
                    
                    miComando.Parameters.Add(paramValidador);


                    miComando.ExecuteNonQuery();

                    resultado = miComando.Parameters["@VALIDADOR"].Value;
                    return Convert.ToInt32(resultado);
                    
                }
            
                sqlconn.Close();
                int returnValor = Convert.ToInt32(resultado);
                return returnValor;
        }

        public void activarTiendaPorEmail(string modo, string email)
        {
            if (conectar())
            {

                SqlParameter paramEmail = new SqlParameter("@EMAIL", email); //Envio el paramerto a insertar
                SqlParameter paramEstado = new SqlParameter("@MODO", modo);
                SqlCommand miComando = new SqlCommand("p_ActivarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramEstado);
                miComando.ExecuteNonQuery();
            }
            sqlconn.Close();
        }

        public void insertarNuevoProducto(Producto producto)
        {
            if (conectar())
            {
                List<SqlParameter> lista = new List<SqlParameter>();

                SqlParameter paramIdTienda = new SqlParameter("@IDTIENDA",producto.idTienda); //Envio el paramerto a insertar
                SqlParameter parmaNombre = new SqlParameter("@NOMBRE", producto.Nombre);
                SqlParameter paramDescripcion = new SqlParameter("@DESCRIPCION", producto.Descripcion);
                SqlParameter parmaPrecio = new SqlParameter("@PRECIO", producto.Precio);
                SqlParameter paramStock = new SqlParameter("@STOCK", producto.Stock);
                
                
               
                
                

                SqlCommand miComando = new SqlCommand("p_CrearTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramIdTienda);

                miComando.Parameters.Add(parmaNombre);
                miComando.Parameters.Add(parmaNombre);
                miComando.Parameters.Add(paramDescripcion);
                miComando.Parameters.Add(parmaPrecio);
                miComando.ExecuteNonQuery();
            }
            sqlconn.Close();
        
        }

        

        internal void editarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        internal int buscarProducto(string nombreProducto)
        {
            throw new NotImplementedException();
        }

        internal void eliminarProducto(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
