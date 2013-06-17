using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisualStudio.VS.Datos;
using VisualStudio.Entidad;
using System.Data;
using System.IO;
using System.Drawing;

namespace VisualStudio.VS.Servicio
{
    public class ProductoServicio
    {
        AccesoADatos nuevo = new AccesoADatos();

        public void insertar(Producto producto)
        {
            nuevo.insertarNuevoProducto(producto);
        }

        //public DataTable listar()
        //{
        //    return nuevo.obtenerEmpresa();
        //}

        public void editar(Producto producto)
        {
            nuevo.editarProducto(producto);
        }

        public void eliminar(int id)
        {
            nuevo.eliminarProducto(id);
        }

        public int buscar(string nombreProducto)
        {
            return nuevo.buscarProducto(nombreProducto);
        }

        //public void activarProducto(string modo, string nombreTienda)
        //{
        //    nuevo.activar(modo, nombreTienda);
        //}
    }
}