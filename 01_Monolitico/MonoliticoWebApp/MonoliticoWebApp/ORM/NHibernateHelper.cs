using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MonoliticoWebApp.Modelo;
using NHibernate;
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
        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            var fluentConf = Fluently.Configure()
              .Database(
                MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)
              )
              .Mappings(m =>
              {
                  //https://github.com/FluentNHibernate/fluent-nhibernate/wiki/auto-mapping
                  m.AutoMappings.Add(AutoMap.AssemblyOf<Articulo>());
                  var u = m.WasUsed;
              });

            var nhibernateConf = fluentConf.BuildConfiguration();

            return fluentConf
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            //// delete the existing db on each run
            //if (File.Exists(DbFile))
            //    File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config).Create(true, true);
        }

    }
}