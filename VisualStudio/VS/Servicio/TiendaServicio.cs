using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisualStudio.VS.Datos;
using System.Data;
using VisualStudio.Entidad;

namespace VisualStudio.VS.Servicio
{
    public class TiendaServicio
    {
        
        AccesoADatos nuevo = new AccesoADatos();
        
        public void insertar(Tienda tienda)
        {
            nuevo.insertarNuevaTienda(tienda);          
        }

        public DataTable listar()
        {
            return nuevo.obtenerEmpresa();
        }

        public void editar(Tienda tienda)
        {
            nuevo.editarEmpresa(tienda);
        }

        public void eliminar(string Email)
        {
            nuevo.eliminarTienda(Email);
        }

        public int buscarEmpresa(string nombreTienda)
        {
           return nuevo.buscarTienda(nombreTienda);
        }

        public void activarTienda(string modo, string nombreTienda)
        {
            nuevo.activarTienda(modo, nombreTienda);
        }
    }
    
}