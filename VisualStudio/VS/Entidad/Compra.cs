using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualStudio.Entidad
{
    public class Compra
    {
        long Id { set; get; }
        string Email { set; get; }
        DateTime FechaTransaction { set; get; }
        IList<Producto> productos;
    }
}