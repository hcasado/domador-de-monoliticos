using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp
{
    public class ApplicationConfiguration
    {
        public static void Initialize()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["monolitico"].ConnectionString;
            var factory = ORM.NHibernateHelper.CreateSessionFactory(connectionString);
            //ORM.NHibernateHelper.Export();

        



        }
    }
}