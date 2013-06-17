using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisualStudio.VS.Servicio;
using VisualStudio.Entidad;

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
    }
}