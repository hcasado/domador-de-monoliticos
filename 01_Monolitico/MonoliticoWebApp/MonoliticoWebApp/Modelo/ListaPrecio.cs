using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MonoliticoWebApp.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.Modelo
{
    public class ListaDePreciosMap : IAutoMappingOverride<ListaDePrecios>
    {
        public void Override(AutoMapping<ListaDePrecios> mapping)
        {
            mapping.Map(x => x.Clientes).LazyLoad();
            mapping.HasMany(x => x.Precios).Inverse().Cascade.AllDeleteOrphan();
        }
    }
    public class ListaDePrecios : EntityBase<ListaDePrecios>
    {
        public virtual string Nombre { get; set; }
        public virtual IList<Precio> Precios { get; set; }
        public virtual IList<Cliente> Clientes { get; set; }
    }
}