using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp
{
    public class ApplicationConfiguration
    {
        public static void Initialize()
        {
            var helper = new ORM.NHibernateHelper();
            var cnn = new DB.SqlLocalDbHelper("MONOLITICO", "DATA").GetConnectionString();
            //helper.UpdateDb(cnn);
        }
    }
}