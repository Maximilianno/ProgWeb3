using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.Entidad;

namespace VisualStudio.VS
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Tienda tienda = new Tienda();
                tienda = (Tienda)Session["TiendaOnline"];
                txtbxRazonSocial.Text = tienda.RazonSocial;
                txtbxCUIT.Text = tienda.CUIT;
                txtbxMail.Text = tienda.Email;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        
    }
}