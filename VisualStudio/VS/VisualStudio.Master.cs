using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.Entidad;
using VisualStudio.VS.Servicio;



namespace VisualStudio.VS
{
    public partial class VisualStudio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Log_Click(object sender, EventArgs e)
        {
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