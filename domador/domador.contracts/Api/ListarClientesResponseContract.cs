using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domador.contracts.Api
{
    public class ListarClientesResponseContract : ResponseContractBase
    {
        public List<ClienteContract> Clientes = new List<ClienteContract>();
    }
}
