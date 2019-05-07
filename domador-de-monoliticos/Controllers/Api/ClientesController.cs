using domador.contracts;
using domador.contracts.Api;
using domador.managers;
using domador.modelo;
using domador.orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace domador_de_monoliticos.Controllers.Api
{
    public class ClientesController : ApiController
    {
        public CrearClienteResponseContract Crear(CrearClienteRequestContract req)
        {
            var res = new CrearClienteResponseContract();

            using (var session = new StatefullSession())
            {
                //es responsabilidad de los managers administrar la logica de negocio.
                var manager = new ClientesManager(session);

                //es responsablidad del controller realizar las conversiones de tipos de datos para poder dialogar con los managers.
                var cliente = new Cliente();
                cliente.ClienteId = Convert.ToInt32(req.Data.Id);
                cliente.Nombre = req.Data.Name;
                manager.Save(cliente);


                session.Commit();
            }

            res.Success = true;
            return res;

        }

        public ListarClientesResponseContract ListAll()
        {
            var res =new ListarClientesResponseContract();

            // la sesion sin estado no mantiene un registro de los cambios en las propiedades de los objetos mapeados por el ORM
            using (var session = new StatelessSession())
            {
                var manager = new ClientesManager(session);

                //es responsablidad del controller realizar las conversiones de tipos de datos para poder dialogar con los managers.
                res.Clientes = manager.ListAll().ConvertAll(c => new ClienteContract() { Id = c.ClienteId.ToString(), Name = c.Nombre });
                res.Success = true;
            }

            return res;
        }

    }
}
