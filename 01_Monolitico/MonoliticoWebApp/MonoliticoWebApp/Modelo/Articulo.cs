using MonoliticoWebApp.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.Modelo
{
    public class Articulo : EntityBase<Articulo>
    {
        public virtual string Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual IList<Precio> Precios { get; set; }
        public virtual decimal PrecioUnitario(Cliente cliente)
        {
            return Precios.Single(p => p.ListaPrecio.Id == cliente.ListaPrecio.Id).Valor;
        }
    }
}