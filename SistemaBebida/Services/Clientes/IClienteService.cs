using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Services.Clientes
{
    public interface IClienteService
    {
        Task<Cliente> Create(Cliente cliente);

        Task<List<Cliente>> List(Guid clienteId);

        Task Delete(Guid clienteId);

        Task<Cliente> Update(Cliente cliente);
    }
}
