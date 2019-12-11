using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaBebida.Entities;
using SistemaBebida.Repositories.Clientes;
using SistemaBebida.Validations;

namespace SistemaBebida.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            cliente.ClienteId = Guid.NewGuid();
            await cliente.Validar<ClienteValidator, Cliente>();
            await _clienteRepository.Create(cliente);
            return cliente;

        }

        public Task Delete(Guid clienteId)
        {
            return _clienteRepository.Delete(clienteId);
        }

        public async Task<List<Cliente>> List(Guid clienteId)
        {
            var clientes = await _clienteRepository.List(clienteId);
            return clientes;
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            await _clienteRepository.Update(cliente);
            return cliente;
        }
    }
}
