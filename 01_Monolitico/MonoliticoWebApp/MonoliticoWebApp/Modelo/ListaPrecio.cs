using MonoliticoWebApp.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.Modelo
{
    public class ListaPrecio : EntityBase<ListaPrecio>
    {
        public virtual string Nombre { get; set; }
        public virtual IList<Precio> Precios { get; set; }
        public virtual IList<Cliente> Clientes { get; set; }
    }
}