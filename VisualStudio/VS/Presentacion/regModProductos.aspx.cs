using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.VS.Servicio;
using VisualStudio.Entidad;
using System.IO;

namespace VisualStudio.VS
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void create_Click(object sender, EventArgs e)
        {
            ProductoServicio productoServicio = new ProductoServicio();
            Producto producto = new Producto();
            producto.Nombre= txtbxNombre.Text;
            producto.Descripcion= txtbxDescripcion.Text;
            producto.Precio= Convert.ToInt32(txtbxPrecio.Text);
            producto.Stock = Convert.ToInt32(txtbxStock.Text);
            
            productoServicio.insertar(producto);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            Tienda tiendaLog = new Tienda();
          //  tiendaLog = (Tienda)Session["tiendaLog"]; -- La idea es levantar la tienda de la session...
            tiendaLog.Email = "sergio_areco@hotmail.com";
            if (fuTiendaImg.HasFile) {

                if (
                   (fuTiendaImg.PostedFile.ContentType == "image/jpeg") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/x-png") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/bmp") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/jpg") ||
                   (fuTiendaImg.PostedFile.ContentType == "image/gif"))
                {
                    if (Convert.ToInt64(fuTiendaImg.PostedFile.ContentLength) < 100000000)
                    {
                        // Esto debería cambiarse porque tiene el dir de mi PC.
                        String photoFolder = Path.Combine(@"C:\Users\Sergio\Desktop\Programacion Web III\Trabajo Practico\ProgWeb3\VisualStudio\VS\photos", tiendaLog.Email);
                        if (!Directory.Exists(photoFolder))
                        {
                            Directory.CreateDirectory(photoFolder);
                            String extension = Path.GetExtension(fuTiendaImg.FileName);
                            String uniqueFileName = Path.ChangeExtension(fuTiendaImg.FileName, DateTime.Now.Ticks.ToString());

                            fuTiendaImg.SaveAs(Path.Combine(photoFolder, uniqueFileName + extension));
                            lblStatus.Text = "El archivo " + fuTiendaImg.FileName + " fue subido correctamente.";
                        }
                    }
                    else
                        lblStatus.Text = "El archivo debe ser menor a 10MB.";
                }
                else
                    lblStatus.Text = "El archivo debe ser una imagen.";
  
            }
            else
                lblStatus.Text = "No se seleccionó ningún archivo.";


        }
    }
}