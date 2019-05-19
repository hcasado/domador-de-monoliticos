using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MonoliticoWebApp.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.Modelo
{
    public class ArticuloMap : IAutoMappingOverride<Articulo>
    {
        public void Override(AutoMapping<Articulo> mapping)
        {

        }
    }

    public class Articulo : EntityBase
    {
        public virtual string Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual IList<Precio> Precios { get; set; }
        public virtual decimal PrecioUnitario(Cliente cliente)
        {
            return Precios.Single(p => p.ListaDePrecios.Id == cliente.ListaDePrecios.Id).Valor;
        }
    }
}