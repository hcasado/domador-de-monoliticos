using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MonoliticoWebApp.Modelo;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.ORM
{
    public class NHibernateHelper
    {
        public void UpdateDb(string connectionString)
        {
            GetConfiguration(connectionString)
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(true, true));
        }

        private FluentConfiguration GetConfiguration(string connectionString)
        {
            var cfg = new Configuration();
            //cfg.SetProperty("connection.release_mode", "on_close");
            //cfg.SetInterceptor(new LoggingInterceptor(connectionString));
            //SetConfiguration(cfg);
            return Fluently.Configure(cfg)
                .Database(() => MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.AutoMappings.Add(
                    AutoMap.AssemblyOf<Articulo>()
                    .IgnoreBase(typeof(EntityBase<>))));
        }
    }
}