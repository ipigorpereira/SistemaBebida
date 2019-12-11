using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaBebida.Entities;

namespace SistemaBebida.Repositories.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ProgramContext _context;

        public ClienteRepository(ProgramContext context)
        {
            _context = context;
        }

        public Task Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            return _context.SaveChangesAsync();
        }

        public Task Delete(Guid clienteId)
        {
            var cliente = _context.Clientes.Where(c => c.ClienteId == clienteId).First();
            _context.Clientes.Remove(cliente);
            return _context.SaveChangesAsync();
        }

        public Task<List<Cliente>> List(Guid clienteId)
        {
            var clientes = _context.Clientes.AsQueryable();

            if (clienteId != Guid.Empty && clienteId != default)
                clientes = clientes.Where(x => x.ClienteId == clienteId);

            return clientes.AsNoTracking().ToListAsync();
        }

        public Task Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            return _context.SaveChangesAsync();
            

        }
    }
}
