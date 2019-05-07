using domador.modelo;
using domador.orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domador.managers
{
    public class ClientesManager : ManagerBase
    {
        public ClientesManager()
        {

        }

        public ClientesManager(Session session) : base(session)
        {
        }

        public void Save(Cliente clientes)
        {
            //session.Save(clientes);
        }

        public List<Cliente> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
