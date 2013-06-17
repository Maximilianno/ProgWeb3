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
                DataRow miTienda = tabla.NewRow();
                miTienda = tiendaServicio.obtener(txtEmail.Text);
                userTienda.Id = Convert.ToInt32(miTienda[0]);
                userTienda.Email = Convert.ToString(miTienda[1]);
                userTienda.RazonSocial = Convert.ToString(miTienda[2]);
                userTienda.CUIT = Convert.ToString(miTienda[3]);
                userTienda.Estado = Convert.ToString(miTienda[5]);

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