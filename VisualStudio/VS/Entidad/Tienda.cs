using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisualStudio.Entidad
{
    public class Tienda
    {
        public String RazonSocial{set; get;}
        public int Id { set; get; }
        public int IdRegistracion { set; get; }
        public String Email { set; get; }
        public String Password { set; get; }
        //string ConfirmPassword{ set; get; }
        public String CUIT { set; get; }
        public String Estado { set; get; }
        public DateTime FechaRegistracion { set; get; }

        //public Tienda(string RazonSocial, string Email, string Password, string CUIT, string Estado)
        //{
        //    this.RazonSocial = RazonSocial;
        //    this.Email = Email;
        //    this.Password = Password;
        //    this.CUIT = CUIT;
        //    this.Estado = Estado;
        //}
    }


}