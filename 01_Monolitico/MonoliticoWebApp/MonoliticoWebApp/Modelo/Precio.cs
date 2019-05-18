using MonoliticoWebApp.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.Modelo
{
    public class Precio : EntityBase<Precio>
    {
        public virtual decimal Valor { get; set; }
        public virtual ListaPrecio ListaPrecio { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}