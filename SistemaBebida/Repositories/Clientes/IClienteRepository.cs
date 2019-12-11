using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories.Clientes
{
    public interface IClienteRepository
    {
        Task Create(Cliente cliente);

        Task<List<Cliente>> List(Guid clienteId);

        Task Delete(Guid clienteId);

        Task Update(Cliente cliente);
    }
}
