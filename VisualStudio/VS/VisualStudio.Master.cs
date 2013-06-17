using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.Entidad;
using VisualStudio.VS.Servicio;
using System.Data;



namespace VisualStudio.VS
{
    public partial class VisualStudio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Log_Click(object sender, EventArgs e)
        {
            
            TiendaServicio tiendaServicio = new TiendaServicio();
            string email = txtEmail.Text;
            int validador = tiendaServicio.loginTienda(email);
            if (validador==1)
            {
                Tienda userTienda = new Tienda();
                DataTable tabla = new DataTable();
                
                tabla = tiendaServicio.obtener(txtEmail.Text);

                userTienda.Password = Convert.ToString(tabla.Rows[0]["Password"]);
                userTienda.Id = Convert.ToInt32(tabla.Rows[0]["Id"]);
                userTienda.Email = Convert.ToString(tabla.Rows[0]["Email"]);
                userTienda.RazonSocial = Convert.ToString(tabla.Rows[0]["RazonSocial"]);
                userTienda.CUIT = Convert.ToString(tabla.Rows[0]["CUIT"]);
                userTienda.Estado = Convert.ToString(tabla.Rows[0]["Estado"]);

                Session["TiendaOnline"] = userTienda;
                
            }

            //TiendaServicio servicioTienda = new TiendaServicio();
            //Tienda userLog = new Tienda();
            //userLog = servicioTienda.login(txtEmail.Text,txtPassword.Text);
            //if (userLog != null)
            //{
            //    Session["userLog"] = userLog;
            //}
            //else {
            //    lblMsjLog.Text = "Acceso Denegado";
            //}
        }
    }
}