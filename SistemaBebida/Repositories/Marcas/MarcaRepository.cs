using Microsoft.EntityFrameworkCore;
using SistemaBebida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBebida.Repositories.Marcas
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly ProgramContext _context;

        public MarcaRepository(ProgramContext context)
        {
            _context = context;
        }

        public Task Create(Marca marca)
        {
            _context.Marcas.Add(marca);
            return _context.SaveChangesAsync();
        }

        public Task Delete(Guid marcaId)
        {
            var marca = _context.Marcas.Where(c => c.MarcaId == marcaId).First();
            _context.Marcas.Remove(marca);
            return _context.SaveChangesAsync();
        }

        public Task<List<Marca>> List()
        {
            var marcas = _context.Marcas.AsQueryable();

            return marcas.AsNoTracking().ToListAsync();
        }

        public Task Update(Marca marca)
        {
            _context.Marcas.Update(marca);
            return _context.SaveChangesAsync();
        }
    }
}