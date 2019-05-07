using domador.orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domador.managers
{
    public class ManagerBase
    {
        protected Session Session;

        public ManagerBase()
        {
            this.Session = new StatefullSession();
        }

        public ManagerBase(Session session)
        {
            this.Session = session;
        }
    }
}
