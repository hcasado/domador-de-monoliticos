using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MonoliticoWebApp.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.Modelo
{
    public class PrecioMap : IAutoMappingOverride<Precio>
    {
        public void Override(AutoMapping<Precio> mapping)
        {

        }
    }

    public class Precio : EntityBase<Precio>
    {
        public virtual decimal Valor { get; set; }
        public virtual ListaDePrecios ListaDePrecios { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}