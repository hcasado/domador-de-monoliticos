using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using MonoliticoWebApp.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.Modelo
{
    public class ClienteMap : IAutoMappingOverride<Cliente>
    {
        public void Override(AutoMapping<Cliente> mapping)
        {

        }
    }

    public class Cliente : EntityBase
    {
        public virtual string Cuit { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string RazonSocial { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Localidad { get; set; }
        public virtual string Domicilio { get; set; }
        public virtual string CodigoPostal { get; set; }
        public virtual ListaDePrecios ListaDePrecios { get; set; }
    }
}