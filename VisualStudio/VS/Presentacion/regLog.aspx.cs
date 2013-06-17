using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using VisualStudio.VS;
using VisualStudio.VS.Servicio;
using VisualStudio.Entidad;

namespace VisualStudio.VS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string captchacode = Session["captchacode"].ToString();
            if (captchacode == txtbxCaptcha.Text)
            {


                Tienda tienda = new Tienda();
                tienda.RazonSocial = txtbxRazonSocial.Text;
                tienda.Email = txtbxMail.Text;
                tienda.Password = txtbxContrasena.Text;
                tienda.CUIT = txtbxCUIT.Text;
                
                TiendaServicio tiendaServicio = new TiendaServicio();
                tiendaServicio.insertar(tienda);

               
            }
        }

        //        TiendaService servicioTienda = new TiendaService();
        //        Tienda nuevaTienda = new Tienda();

        //        nuevaTienda.Email = txtbxMail.Text;
        //        nuevaTienda.RazonSocial = txtbxRazonSocial.Text;
        //        nuevaTienda.Estado = "P";

        //        if (txtbxCUIT.Text == null)
        //            nuevaTienda.CUIT = "";
        //        else
        //            nuevaTienda.CUIT = txtbxCUIT.Text;

        //        nuevaTienda.Password = txtbxContrasena.Text;

        //        if (servicioTienda.Add(nuevaTienda))
        //        {

        //            if (!servicioTienda.SendMail(nuevaTienda.Email))
        //            {
        //                lblmessage.Text = "Ha ocurrido un error al enviar el mail a " + nuevaTienda.Email;
        //            }
        //            else
        //            {
        //                lblmessage.Text = "Se ha enviado un mail a " + nuevaTienda.Email;
        //            }


        //        }
        //        else
        //        {
        //            lblmessage.Text = "Ha ocurrido un error al dar de alta la nueva tienda";
        //        }

        //        //response.Redirect("default.aspx");
        //    }
        //    else
        //    {
        //        lblmessage.Text = "El código es incorrecto.";
        //    }
        //}
    }
}